Imports MySql.Data.MySqlClient
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.IO
Imports System.Linq



Public Class DBHelper
    Public Shared nomeBanco As String = "sglinx"
    Public Shared host As String = "localhost"
    Public Shared porta As String = "3306"
    Private Shared mysqlConnection As MySqlConnection = CType(Nothing, MySqlConnection)
    Public Shared maquinaConcentrado As Boolean = False

    Public Shared Function ConexaoBD() As MySqlConnection
        Try
            Return DBHelper.ConexaoBD(False)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function ConexaoBD(ByVal PermitirUsoVariaveis As Boolean) As MySqlConnection
        Dim mySqlConnection As MySqlConnection = CType(Nothing, MySqlConnection)

        Try
            If String.IsNullOrEmpty(DBHelper.host) Then DBHelper.CarregaConfiguracoes()
            Return DBHelper.AbrirConexao(DBHelper.nomeBanco, PermitirUsoVariaveis)
        Catch ex As Exception

            If mySqlConnection.State = ConnectionState.Open Then
                mySqlConnection.Close()
                mySqlConnection.Dispose()
            End If

            Throw
        End Try
    End Function

    Public Shared Function ConexaoBDMysql() As MySqlConnection
        Try
            If String.IsNullOrEmpty(DBHelper.host) Then DBHelper.CarregaConfiguracoes()
            DBHelper.mysqlConnection = DBHelper.AbrirConexao("mysql")
            Return DBHelper.mysqlConnection
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Shared Function AbrirConexao(ByVal nomeBancoConexao As String) As MySqlConnection
        Return DBHelper.AbrirConexao(nomeBancoConexao, False)
    End Function

    Private Shared Function AbrirConexao(ByVal nomeBancoConexao As String, ByVal PermitirUsoVariaveis As Boolean) As MySqlConnection
        Dim mySqlConnection As MySqlConnection = New MySqlConnection(New MySqlConnectionStringBuilder() With {
            .Server = DBHelper.host,
            .UserID = "root",
            .Password = "Pe$$w0rd1@",
            .Database = nomeBancoConexao,
            .ConnectionTimeout = 120UI,
            .AllowUserVariables = PermitirUsoVariaveis
        }.ToString())
        mySqlConnection.Open()
        Return mySqlConnection
    End Function

    Public Shared Function TrataCaracteresEspeciaisBD(ByVal texto As String) As String
        texto = texto.Replace("'", "''")
        Return texto
    End Function

    Public Shared Sub CarregaConfiguracoes()
        Try
            Dim str1 As String = String.Format("{0}sglinx.ini", CObj("\\192.168.254.2\SGLinx\WSLinear\"))
            If Not File.Exists(str1) Then Throw New IO.IOException(String.Format("Arquivo sglinx.ini não localizado do diretório - ({0})", CObj(str1)))
            Dim arquivoIni As ArquivoIni = New ArquivoIni(str1)
            DBHelper.host = arquivoIni.Read("Provider", "Settings", "")
            DBHelper.nomeBanco = arquivoIni.Read("nomebanco", "Settings", "")
            Dim str2 As String = arquivoIni.Read("PORTA", "Settings", "")
            If String.IsNullOrEmpty(str2) Then str2 = "3306"
            DBHelper.porta = str2
            If String.IsNullOrEmpty(DBHelper.host) Then Throw New IO.IOException("Provider não definido no arquivo de configuração (INI)")
            If String.IsNullOrEmpty(DBHelper.nomeBanco) Then Throw New IO.IOException("Banco de dados não definido no arquivo de configuração (INI)")
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Shared Function RecuperaCnpj() As String
        Dim str As String = ""
        Dim mySqlDataReader As MySqlDataReader = CType(Nothing, MySqlDataReader)

        Try

            Using connection As MySqlConnection = DBHelper.ConexaoBD()

                Using mySqlCommand As MySqlCommand = New MySqlCommand("select emp_cgc from empresa order by emp_codigo limit 1", connection)
                    mySqlDataReader = mySqlCommand.ExecuteReader()

                    While mySqlDataReader.Read()
                        str = mySqlDataReader.GetString(mySqlDataReader.GetOrdinal("emp_cgc"))
                    End While
                End Using
            End Using

        Catch ex As Exception
            Throw
        Finally
            mySqlDataReader.Dispose()
        End Try

        Return str
    End Function

    Public Shared Function ExecucaoPermitida(ByVal comando As String) As Boolean
        Dim flag As Boolean = True
        comando = comando.ToLower()

        If comando.IndexOf("add index") > 0 OrElse comando.IndexOf("create index") > -1 OrElse (comando.IndexOf("create unique index") > -1 OrElse comando.IndexOf("add unique index") > -1) Then
            flag = Not DBHelper.IndexExistente(comando)
        ElseIf comando.IndexOf("drop index") > -1 Then
            flag = DBHelper.IndexExistente(comando)
        ElseIf comando.IndexOf("create table") >= 0 Then
            flag = Not DBHelper.TabelaExistente(comando)
        ElseIf comando.IndexOf("drop table") >= 0 Then
            flag = DBHelper.TabelaExistente(comando)
        ElseIf comando.IndexOf("create procedure") > -1 Then
            flag = Not DBHelper.ProcedureExistente(comando)
        ElseIf comando.IndexOf("create trigger") > -1 Then
            flag = Not DBHelper.TriggerExistente(comando)
        ElseIf comando.IndexOf("drop trigger") > -1 Then
            flag = DBHelper.TriggerExistente(comando)
        ElseIf comando.IndexOf("add") > 0 Then
            Dim num As Integer = comando.IndexOf("add column")
            Dim posIni As Integer = If(num <= -1, comando.IndexOf("add") + 4, num + 11)
            flag = Not DBHelper.CampoExistente(comando, posIni)
        ElseIf comando.IndexOf("drop") > 0 Then
            Dim num As Integer = comando.IndexOf("drop column")
            Dim posIni As Integer = If(num <= -1, comando.IndexOf("drop") + 5, num + 12)
            flag = DBHelper.CampoExistente(comando, posIni)
        End If

        Return flag
    End Function

    Private Shared Function IndexExistente(ByVal comando As String) As Boolean
        Dim mySqlDataReader As MySqlDataReader = CType(Nothing, MySqlDataReader)

        Try
            Dim str1 As String = If(comando.IndexOf("table") <= -1, DBHelper.RecuperaPalavra(comando.IndexOf(" on ") + 4, comando), DBHelper.RecuperaPalavra(comando.IndexOf("table") + 6, comando))
            Dim str2 As String = DBHelper.RecuperaPalavra(comando.IndexOf("index") + 6, comando)

            Using connection As MySqlConnection = DBHelper.ConexaoBD()

                Using mySqlCommand As MySqlCommand = New MySqlCommand(String.Format("show indexes from {0}", CObj(str1)), connection)
                    mySqlDataReader = mySqlCommand.ExecuteReader()

                    While mySqlDataReader.Read()
                        If mySqlDataReader.GetString(mySqlDataReader.GetOrdinal("key_name")).ToLower() = str2.ToLower() Then Return True
                    End While
                End Using
            End Using

        Catch ex As Exception
            Throw
        Finally
            mySqlDataReader.Dispose()
        End Try

        Return False
    End Function

    Public Shared Function LerNome(ByVal sNomeTabela As String, ByVal sCriterio As String, ByVal sCampoRetorno As String, Optional ByVal sTipo As String = "C", Optional ByVal sApelido As String = "", Optional ByVal sOrdem As String = "") As String
        Try
            Dim mySqlConnection As MySqlConnection = DBHelper.ConexaoBD()
            Dim mySqlCommand As MySqlCommand = New MySqlCommand()
            Dim str1 As String = ""
            Dim str2 As String = "select " & sCampoRetorno & " from " & sNomeTabela
            If sCriterio <> "" Then str2 = str2 & " where " & sCriterio
            If sOrdem <> "" Then str2 = str2 & " order by " & sOrdem
            mySqlCommand.Connection = mySqlConnection
            mySqlCommand.CommandText = str2
            mySqlCommand.CommandType = CommandType.Text
            Dim mySqlDataReader As MySqlDataReader = mySqlCommand.ExecuteReader()
            If mySqlDataReader.Read() Then str1 = If(Not (sApelido <> ""), Convert.ToString(mySqlDataReader(sCampoRetorno)), Convert.ToString(mySqlDataReader(sApelido)))

            If str1 = "" OrElse str1 Is Nothing Then
                If sTipo = "N" Then str1 = "0"
                If sTipo = "C" OrElse sTipo = "D" Then str1 = ""
            End If

            mySqlConnection.Close()
            mySqlDataReader.Close()
            mySqlDataReader.Dispose()
            Return str1
        Catch ex As Exception
            Dim str As String = ""

            If sTipo IsNot Nothing Then

                If Not (sTipo = "N") Then
                    If sTipo = "C" OrElse sTipo = "D" Then str = ""
                Else
                    str = "0"
                End If
            End If

            Return str
        End Try
    End Function

    Public Shared Function LerParametro(ByVal c_chave As String, Optional ByVal Zero As Boolean = False, Optional ByVal nEmpresa As Integer = 9999) As String
        Try
            Dim mySqlConnection As MySqlConnection = DBHelper.ConexaoBD()
            Dim mySqlCommand As MySqlCommand = New MySqlCommand()
            Dim str1 As String = "select * from parametro where pr_chave = '" & c_chave & "'"
            If nEmpresa <> 9999 Then str1 = str1 & " and empresa = " & CObj(nEmpresa)
            mySqlCommand.Connection = mySqlConnection
            mySqlCommand.CommandText = str1
            mySqlCommand.CommandType = CommandType.Text
            Dim mySqlDataReader As MySqlDataReader = mySqlCommand.ExecuteReader()
            Dim str2 As String

            If mySqlDataReader.Read() Then
                str2 = mySqlDataReader("pr_valor").ToString()
            Else
                str2 = ""
                If Zero Then str2 = "0"
            End If

            mySqlDataReader.Close()
            mySqlDataReader.Dispose()
            mySqlConnection.Close()
            Return str2
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function TabelaSaudavel(ByVal nomeTabela As String, ByVal nomeBanco As String) As Boolean
        Try

            Using connection As MySqlConnection = DBHelper.ConexaoBD()

                Using mySqlCommand As MySqlCommand = New MySqlCommand("CHECK TABLE `" & nomeBanco & "`.`" & nomeTabela & "`", connection)

                    Using mySqlDataReader As MySqlDataReader = mySqlCommand.ExecuteReader()

                        While mySqlDataReader.Read()
                            Dim lowerInvariant As String = mySqlDataReader.GetString("Msg_text").ToLowerInvariant()
                            If lowerInvariant.Equals("ok") OrElse lowerInvariant.Equals("table is already up to date") Then Return True
                        End While

                        Return False
                    End Using
                End Using
            End Using

        Catch
            Throw
        End Try
    End Function

    Public Shared Function TabelaSaudavel(ByVal nomeTabela As String) As Boolean
        Try
            Return DBHelper.TabelaSaudavel(nomeTabela, DBHelper.nomeBanco)
        Catch
            Throw
        End Try
    End Function

    Public Shared Function RepararTabela(ByVal nomeTabela As String, ByVal options As String, ByVal nomeBanco As String) As Boolean
        Try

            Using connection As MySqlConnection = DBHelper.ConexaoBD()
                Dim cmdText As String = "REPAIR TABLE `" & nomeBanco & "`.`" & nomeTabela & "` "
                If options.Trim().Length > 0 Then cmdText += options

                Using mySqlCommand As MySqlCommand = New MySqlCommand(cmdText, connection)

                    Using mySqlDataReader As MySqlDataReader = mySqlCommand.ExecuteReader()

                        While mySqlDataReader.Read()
                            If mySqlDataReader.GetString("Msg_text").ToLowerInvariant().Equals("ok") Then Return True
                        End While

                        Return False
                    End Using
                End Using
            End Using

        Catch
            Throw
        End Try
    End Function

    Public Shared Function RepararTabela(ByVal nomeTabela As String, ByVal options As String) As Boolean
        Return DBHelper.RepararTabela(nomeTabela, options, DBHelper.nomeBanco)
    End Function

    Public Shared Function gvgpt(ByVal sEntrada As String) As String
        If sEntrada = "" OrElse sEntrada = "0.00" Then Return "0"
        sEntrada = sEntrada.Replace(".", "")
        Return sEntrada.Replace(",", ".")
    End Function

    Public Shared Function TabelaExistente(ByVal comando As String) As Boolean
        Try
            Return DBHelper.TabelaExistente(DBHelper.RecuperaPalavra(comando.IndexOf("table") + 6, comando).Replace("`", ""), DBHelper.nomeBanco)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function TabelaExistente(ByVal nomeTabela As String, ByVal nomeSchema As String) As Boolean
        Try

            Using connection As MySqlConnection = DBHelper.ConexaoBD()

                Using mySqlCommand As MySqlCommand = New MySqlCommand("SELECT 1 FROM information_schema.`TABLES` t WHERE t.TABLE_SCHEMA  = '" & nomeSchema & "' and t.TABLE_NAME = '" & nomeTabela & "' limit 1; ", connection)

                    Using mySqlDataReader As MySqlDataReader = mySqlCommand.ExecuteReader()
                        Return mySqlDataReader.Read()
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Shared Function ProcedureExistente(ByVal comando As String) As Boolean
        Dim mySqlDataReader As MySqlDataReader = CType(Nothing, MySqlDataReader)

        Try
            Dim str As String = DBHelper.RecuperaPalavra(comando.IndexOf("procedure") + 10, comando).Replace("`", "")

            Using connection As MySqlConnection = DBHelper.ConexaoBD()

                Using mySqlCommand As MySqlCommand = New MySqlCommand("SELECT IF( COUNT(*) = 0, 'F' , 'T' ) AS ProcedureExists" & "  FROM INFORMATION_SCHEMA.ROUTINES " & String.Format("  WHERE ROUTINE_SCHEMA = '{0}' AND ROUTINE_TYPE = 'PROCEDURE'", CObj(DBHelper.nomeBanco)) & String.Format("  AND UCASE(ROUTINE_NAME) = UCASE('{0}');", CObj(str)), connection)
                    mySqlDataReader = mySqlCommand.ExecuteReader()
                    If mySqlDataReader.Read() Then Return mySqlDataReader.GetString(0) = "T"
                End Using
            End Using

        Catch ex As Exception
            Throw
        Finally
            mySqlDataReader.Dispose()
        End Try

        Return False
    End Function

    Private Shared Function TriggerExistente(ByVal comando As String) As Boolean
        Dim mySqlDataReader As MySqlDataReader = CType(Nothing, MySqlDataReader)

        Try
            Dim str As String = DBHelper.RecuperaPalavra(comando.IndexOf("trigger") + 8, comando).Replace("`", "")

            Using connection As MySqlConnection = DBHelper.ConexaoBD()

                Using mySqlCommand As MySqlCommand = New MySqlCommand("" & " select 1 " & " from information_schema.triggers  " & String.Format(" where trigger_schema = '{0}'", CObj(DBHelper.nomeBanco)) & String.Format(" and trigger_name = '{0}'", CObj(str)), connection)
                    mySqlDataReader = mySqlCommand.ExecuteReader()
                    Return mySqlDataReader.Read()
                End Using
            End Using

        Catch ex As Exception
            Throw
        Finally
            mySqlDataReader.Dispose()
        End Try
    End Function

    Private Shared Function CampoExistente(ByVal comando As String, ByVal posIni As Integer) As Boolean
        Dim mySqlDataReader As MySqlDataReader = CType(Nothing, MySqlDataReader)

        Try
            Dim str1 As String = DBHelper.RecuperaPalavra(comando.IndexOf("table") + 6, comando)
            Dim str2 As String = DBHelper.RecuperaPalavra(posIni, comando)

            Using connection As MySqlConnection = DBHelper.ConexaoBD()

                Using mySqlCommand As MySqlCommand = New MySqlCommand(String.Format("show columns from {0} like '{1}'; ", CObj(str1), CObj(str2)), connection)
                    mySqlDataReader = mySqlCommand.ExecuteReader()

                    While mySqlDataReader.Read()
                        If mySqlDataReader.GetString(mySqlDataReader.GetOrdinal("Field")).ToLower() = str2.ToLower() Then Return True
                    End While
                End Using
            End Using

        Catch ex As Exception
            Throw
        Finally
            mySqlDataReader.Dispose()
        End Try

        Return False
    End Function

    Private Shared Function RecuperaPalavra(ByVal posIni As Integer, ByVal comando As String) As String
        Dim str As String = ""
        Dim charArray As Char() = comando.ToCharArray()
        Dim index As Integer = posIni

        While index < (CType(charArray, IEnumerable(Of Char))).Count() AndAlso (charArray(index) <> " "c AndAlso charArray(index) <> "("c) AndAlso charArray(index) <> ";"c
            str += charArray(index).ToString()
            index += 1
        End While

        Return str.Trim()
    End Function
End Class


