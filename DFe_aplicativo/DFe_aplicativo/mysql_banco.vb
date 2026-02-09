Imports MySql.Data.MySqlClient

Module mysql_banco
    Public Function UsuarioExisteBanco(ByVal nomeUsuario As String, ByVal host As String) As Boolean
        Dim mySqlDataReader As MySqlDataReader = CType(Nothing, MySqlDataReader)

        Try
            Dim cmdText As String = "select user from mysql.user where user = '" & nomeUsuario & "' and host = '" & host & "'"

            Using connection As MySqlConnection = DB_mysql.ConexaoBD()

                Using mySqlCommand As MySqlCommand = New MySqlCommand(cmdText, connection)
                    mySqlDataReader = mySqlCommand.ExecuteReader()
                    Return mySqlDataReader.Read()
                End Using
            End Using

        Catch ex As Exception
            Throw
        Finally

            If mySqlDataReader IsNot Nothing Then
            End If
        End Try
    End Function


    Public Function RecuperarParametro(Of T)(ByVal chave As String, ByVal codigoEmpresa As Long?) As T
        Dim str As String = ""
        Dim mySqlDataReader As MySqlDataReader = CType(Nothing, MySqlDataReader)

        Try

            Using connection As MySqlConnection = DB_mysql.ConexaoBD()
                Dim cmdText As String = String.Format("select pr_valor from parametro where controle = 0 and pr_chave = '{0}'", CObj(chave))
                If codigoEmpresa.HasValue Then cmdText += String.Format(" and empresa = {0}", CObj(codigoEmpresa))

                Using mySqlCommand As MySqlCommand = New MySqlCommand(cmdText, connection)
                    mySqlDataReader = mySqlCommand.ExecuteReader()

                    If mySqlDataReader.Read() Then
                        str = mySqlDataReader.GetString(0)
                    ElseIf String.IsNullOrEmpty(str) Then
                        If GetType(T).Name <> "String" Then str = "0"
                    End If
                End Using
            End Using

        Catch ex As Exception
            Throw
        Finally

            If mySqlDataReader IsNot Nothing Then
                If Not mySqlDataReader.IsClosed Then mySqlDataReader.Close()
                mySqlDataReader.Dispose()
            End If
        End Try

        Return CType(Convert.ChangeType(CObj(str), GetType(T)), T)
    End Function
End Module
