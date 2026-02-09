
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Data.SQLite
Public Class conexao_sqlite
    Private cn As SQLiteConnection
    Private constring As String
    Private constringNSenha As String

    Public Sub New()
        Me.constring = "Data Source=@filedb3;Version=3;Password=R@enil2015#;"
        Me.constringNSenha = "Data Source=@filedb3;Version=3;"
    End Sub

    Public Function Iniciar_Conexao(ByVal strPathDb3 As String, Optional ByVal iTipoConsString As Integer = 0) As SQLiteConnection
        Dim sqLiteConnection As SQLiteConnection

        Try
            Me.cn = New SQLiteConnection()
            Me.cn.ConnectionString = If(iTipoConsString <> 0, Me.constringNSenha.Replace("@filedb3", strPathDb3), Me.constring.Replace("@filedb3", strPathDb3))
            Me.cn.Open()
            sqLiteConnection = Me.cn
        Catch ex As SQLiteException
            ProjectData.SetProjectError(CType(ex, Exception))
            sqLiteConnection = CType(Nothing, SQLiteConnection)
            ProjectData.ClearProjectError()
        End Try

        Return sqLiteConnection
    End Function

    Public Function Fechar_Conexao(ByRef cn As SQLiteConnection) As Boolean
        Dim flag As Boolean

        Try
            cn.Clone()
            flag = True
        Catch ex As SQLiteException
            ProjectData.SetProjectError(CType(ex, Exception))
            flag = False
            ProjectData.ClearProjectError()
        End Try

        Return flag
    End Function

    Public Function RetDataReader(ByVal cSql As String) As SQLiteDataReader
        Dim sqLiteDataReader As SQLiteDataReader

        Try
            sqLiteDataReader = New SQLiteCommand() With {
                .Connection = Me.cn,
                .CommandText = cSql,
                .CommandType = CommandType.Text
            }.ExecuteReader()
        Catch ex As SQLiteException
            ProjectData.SetProjectError(CType(ex, Exception))
            sqLiteDataReader = CType(Nothing, SQLiteDataReader)
            ProjectData.ClearProjectError()
        End Try

        Return sqLiteDataReader
    End Function

    Public Function RetDataReader(ByVal cSql As String, ByVal cn As SQLiteConnection) As SQLiteDataReader
        Dim sqLiteDataReader As SQLiteDataReader

        Try
            sqLiteDataReader = New SQLiteCommand() With {
                .Connection = cn,
                .CommandText = cSql,
                .CommandType = CommandType.Text
            }.ExecuteReader()
        Catch ex As SQLiteException
            ProjectData.SetProjectError(CType(ex, Exception))
            sqLiteDataReader = CType(Nothing, SQLiteDataReader)
            ProjectData.ClearProjectError()
        End Try

        Return sqLiteDataReader
    End Function

    Public Function ExecutaQueryDT(ByVal query As String, Optional ByVal strPathFile As String = "") As DataTable
        Dim dataTable1 As DataTable = New DataTable()
        Dim dataTable2 As DataTable

        Try
            If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(strPathFile, "", False) = 0 Then strPathFile = "cfe.db3"

            Using connection As SQLiteConnection = New SQLiteConnection(Me.constring.Replace("@filedb3", Application.StartupPath & "\" & strPathFile))

                Using cmd As SQLiteCommand = New SQLiteCommand(query, connection)

                    Using sqLiteDataAdapter As SQLiteDataAdapter = New SQLiteDataAdapter(cmd)
                        sqLiteDataAdapter.Fill(dataTable1)
                        Dim cn As SQLiteConnection = connection
                        Me.Fechar_Conexao(cn)
                        dataTable2 = dataTable1
                    End Using
                End Using
            End Using

        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            dataTable2 = CType(Nothing, DataTable)
            ProjectData.ClearProjectError()
        End Try

        Return dataTable2
    End Function

    Public Function ExecuteSQL(ByVal cSql As String, Optional ByVal strPathDb3 As String = "", Optional ByVal iTipoCS As Integer = 0) As Boolean
        Dim flag As Boolean

        Try
            If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(strPathDb3, "", False) = 0 Then strPathDb3 = Application.StartupPath & "\cfe.db3"
            Dim sqLiteConnection As SQLiteConnection = Me.Iniciar_Conexao(strPathDb3, iTipoCS)
            Dim cr As SQLiteCommand = New SQLiteCommand()
            cr.Connection = sqLiteConnection
            cr.CommandText = cSql
            cr.CommandType = CommandType.Text
            cr.ExecuteNonQuery()
            flag = True
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            flag = False
            ProjectData.ClearProjectError()
        End Try

        Return flag
    End Function
End Class
