Imports MySql.Data.MySqlClient
Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Threading


Friend Class MysqlControl
    Public Property MyDate As String
    Public Property MyControl As String
    Public Property MyTable As String
    Public Property Cnpj As String
    Public Property License As String
    Public Property DataExpiracao As DateTime
    Public Property TipoSistema As Byte

    Public Function GravarNovaLicenca(ByVal linxOSLicenca As LinxOSLicenca, ByVal statusLincesaUso As MysqlControl.StatusLincesaUso) As Boolean
        Try

            Using connection As MySqlConnection = DBHelper.ConexaoBDMysql()
                Return BaseModel.ExecutaQuery(String.Format("update control set myControl = '{0}', license = '{1}', mynum = {2}", CObj(linxOSLicenca.Licenca), CObj(cryptografia_linear.Criptografar(statusLincesaUso.ToString())), CObj(Me.QuantidadeUsuarios())) & String.Format(" where myTable = '{0}' ", CObj(Me.MyTable)), connection)
            End Using

        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function QuantidadeUsuarios() As Integer
        Try
            Dim cmdText As String = "select count(us_cod) from usuario"

            Using connection As MySqlConnection = DBHelper.ConexaoBD()

                Using mySqlCommand As MySqlCommand = New MySqlCommand(cmdText, connection)

                    Using mySqlDataReader As MySqlDataReader = mySqlCommand.ExecuteReader()
                        If Not mySqlDataReader.Read() Then Return 20
                        Dim int32 As Integer = mySqlDataReader.GetInt32(0)
                        If int32 <= 0 Then Return 20
                        Return int32 * 50
                    End Using
                End Using
            End Using

        Catch
            Throw
        End Try
    End Function

    Public Shared Function LicencaSistema() As List(Of MysqlControl)
        Dim mysqlControlList As List(Of MysqlControl) = New List(Of MysqlControl)()

        Try
            Thread.CurrentThread.CurrentCulture = New CultureInfo("pt-BR")

            Using connection As MySqlConnection = DBHelper.ConexaoBDMysql()

                Using mySqlCommand As MySqlCommand = New MySqlCommand("select * from control", connection)

                    Using mySqlDataReader As MySqlDataReader = mySqlCommand.ExecuteReader()

                        While mySqlDataReader.Read()
                            Dim mysqlControl As MysqlControl = New MysqlControl() With {
                                .MyControl = mySqlDataReader.GetString("myControl"),
                                .MyTable = mySqlDataReader.GetString("myTable"),
                                .MyDate = mySqlDataReader.GetString("myDate")
                            }
                            Dim texto As String = cryptografia_linear.Criptografar(mysqlControl.StatusLincesaUso.Disponivel.ToString())
                            If Not mySqlDataReader.IsDBNull(mySqlDataReader.GetOrdinal("license")) Then texto = mySqlDataReader.GetString(mySqlDataReader.GetOrdinal("license"))
                            mysqlControl.License = cryptografia_linear.Descriptografar(texto)
                            mysqlControl.DataExpiracao = LinxOSLicenca.RecuperarDataExpiracao(mysqlControl.MyControl)
                            mysqlControl.Cnpj = LinxOSLicenca.RecuperarCNPJ(mysqlControl.MyControl)
                            mysqlControl.TipoSistema = LinxOSLicenca.RecuperarTipoSistema(mysqlControl.MyControl)
                            mysqlControlList.Add(mysqlControl)
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Throw
        End Try

        Return mysqlControlList
    End Function

    Public Enum StatusLincesaUso
        Disponivel
        Indisponivel
    End Enum
End Class

