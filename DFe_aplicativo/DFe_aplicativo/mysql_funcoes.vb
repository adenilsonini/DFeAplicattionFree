Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Net.NetworkInformation
Imports System.IO.Compression

Module mysql_funcoes
    Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")
    Public ip_mysqlr As String = arquivoIni.Read("ip_mysql", "DFe")
    Public Function UsuarioExisteBanco(ByVal nomeUsuario As String, ByVal host As String) As Boolean
        Dim mySqlDataReader As MySqlDataReader = CType(Nothing, MySqlDataReader)
        DB_mysql.host = ip_mysqlr

        Try
            Dim cmdText As String = "select user from mysql.user where user = '" & nomeUsuario & "' and host = '" & host & "'"

            Using connection As MySqlConnection = DB_mysql.ConexaoBD()

                Using mySqlCommand As MySqlCommand = New MySqlCommand(cmdText, connection)
                    mySqlDataReader = mySqlCommand.ExecuteReader()
                    Return mySqlDataReader.Read()
                End Using
            End Using

        Catch ex As Exception
            frmprincipal.Timer1.Dispose()
            '  MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Aviso ! (Module: mysql_funcoes | Function: UsuarioExisteBanco)")
        Finally

            If mySqlDataReader IsNot Nothing Then
            End If
        End Try
    End Function


    Public Function RecuperaHashSHA256String(ByVal texto As String) As String
        Using memoryStream As MemoryStream = New MemoryStream(Encoding.UTF8.GetBytes(texto))
            Return mysql_funcoes.RecuperaHashSHA256(CType(memoryStream, Stream))
        End Using
    End Function

    Public Function RecuperaHashSHA256Arquivo(ByVal diretorioArquivo As String) As String
        Try

            Using fileStream As FileStream = System.IO.File.OpenRead(diretorioArquivo)
                Return mysql_funcoes.RecuperaHashSHA256(CType(fileStream, Stream))
            End Using

        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function RecuperaHashSHA256(ByVal inputStream As Stream) As String
        Using shA256 As SHA256 = SHA256.Create()
            Return BitConverter.ToString(shA256.ComputeHash(inputStream)).Replace("-", String.Empty).ToLower()
        End Using
    End Function

    Public Function ConectadoInternet() As Boolean
        Try
            Dim ping As Ping = New Ping()
            Dim str As String = "google.com"
            Dim numArray As Byte() = New Byte(31) {}
            Dim num As Integer = 1000
            Dim pingOptions As PingOptions = New PingOptions()
            Dim hostNameOrAddress As String = str
            Dim timeout As Integer = num
            Dim buffer As Byte() = numArray
            Dim options As PingOptions = pingOptions
            Return ping.Send(hostNameOrAddress, timeout, buffer, options).Status = IPStatus.Success
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ExtrairArquivo(ByVal filePath As String) As Boolean
        Dim baseDirectory As String = AppDomain.CurrentDomain.BaseDirectory

        Try

            Using zipArchive As ZipArchive = ZipFile.OpenRead(filePath)

                For Each entry As ZipArchiveEntry In zipArchive.Entries
                    Dim fullName As String = entry.FullName

                    If fullName.EndsWith("/") AndAlso String.IsNullOrEmpty(entry.Name) Then
                        If Directory.Exists(baseDirectory & fullName) Then mysql_funcoes.ExcluirPasta(baseDirectory & fullName)
                        Directory.CreateDirectory(baseDirectory & fullName)
                    Else
                        entry.ExtractToFile(baseDirectory & fullName, True)
                    End If
                Next
            End Using

        Catch ex As Exception
            Throw
        End Try

        Return True
    End Function

    Public Sub ExcluirPasta(ByVal diretorio As String)
        Try
            If Not Directory.Exists(diretorio) Then Return

            For Each directory As String In System.IO.Directory.GetDirectories(diretorio)
                mysql_funcoes.ExcluirPasta(directory)
            Next

            For Each file As String In Directory.GetFiles(diretorio)
                System.IO.File.Delete(file)
            Next

            Directory.Delete(diretorio)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function FormataData(ByVal dates As DateTime, ByVal formato As Integer) As String
        Dim str As String = ""

        Try

            Select Case formato
                Case 0
                    str = String.Format("{0:yyyy-MM-dd}", CObj(dates))
                Case 1
                    str = String.Format("{0:HH:mm:ss}", CObj(dates))
                Case 2
                    str = String.Format("{0:yyyy-MM-dd HH:mm:ss}", CObj(dates))
            End Select

        Catch ex As Exception
            Throw
        End Try

        Return str
    End Function

    Public Function DataSistema() As DateTime
        Dim dateTime As DateTime = Now
        Dim mySqlDataReader As MySqlDataReader = CType(Nothing, MySqlDataReader)

        Try
            Dim cmdText As String = String.Format("select now() as data_atual ")

            Using connection As MySqlConnection = DB_mysql.ConexaoBD()

                Using mySqlCommand As MySqlCommand = New MySqlCommand(cmdText, connection)
                    mySqlDataReader = mySqlCommand.ExecuteReader()
                    If mySqlDataReader.Read() Then dateTime = mySqlDataReader.GetDateTime(mySqlDataReader.GetOrdinal("data_atual"))
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Aviso ! (Module: mysql_funcoes | Function: DataSistema)")
        Finally
            mySqlDataReader.Dispose()
        End Try

        Return dateTime
    End Function

    Public Function RecuperaDescricao(ByVal tabela As String, ByVal campo As String) As String
        Dim mySqlDataReader As MySqlDataReader = CType(Nothing, MySqlDataReader)

        Try

            Using connection As MySqlConnection = DB_mysql.ConexaoBD()

                Using mySqlCommand As MySqlCommand = New MySqlCommand(String.Format("select {0} from {1}", CObj(campo), CObj(tabela)), connection)
                    mySqlDataReader = mySqlCommand.ExecuteReader()
                    If mySqlDataReader.Read() Then Return mySqlDataReader.GetValue(0).ToString()
                End Using
            End Using

        Catch ex As Exception
            Throw
        Finally
            mySqlDataReader.Dispose()
        End Try

        Return ""
    End Function

    Public Function RecuperaVersaoMySQL() As String
        Dim mySqlDataReader As MySqlDataReader = CType(Nothing, MySqlDataReader)

        Try

            Using connection As MySqlConnection = DB_mysql.ConexaoBD()

                Using mySqlCommand As MySqlCommand = New MySqlCommand("select @@version", connection)
                    mySqlDataReader = mySqlCommand.ExecuteReader()
                    If Not mySqlDataReader.Read() Then Return "0"

                    '  If mySqlDataReader.GetString(0).Contains(Of Char)("-"c) Then
                    'Return mySqlDataReader.GetString(0).Substring(0, mySqlDataReader.GetString(0).IndexOf("-"c))
                    '   End If

                    Return mySqlDataReader.GetString(0)
                End Using
            End Using

        Catch ex As Exception
            Return "1.0"
        Finally

            If mySqlDataReader IsNot Nothing Then
            End If
        End Try
    End Function


End Module
