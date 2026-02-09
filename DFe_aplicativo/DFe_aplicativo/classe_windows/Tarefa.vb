Imports MySql.Data.MySqlClient
Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization


<DataContract>
Public Class Tarefa
    Private CamposRetorno As List(Of Campo) = New List(Of Campo)()
    Private Const OPERACAO_MONITORAMENTO As Integer = 1
    Private Const OPERACAO_ATUALIZACAO As Integer = 2
    Private Const EXECUCAO_SIMPLES As Integer = 1
    Private Const EXECUCAO_EM_LOTE As Integer = 2
    Private Const NAO_EXECUTADO As Integer = 0
    Private Const EXECUCAO_COM_ERRO As Integer = 1
    Private Const EXECUCAO_COM_SUCESSO As Integer = 2
    Private Const RETORNO_PENDENTE As Integer = 0
    Private Const RETORNO_COM_SUCESSO As Integer = 1
    Private Const RETORNO_COM_ERRO As Integer = 2
    <DataMember(Name:="id")>
    Public Property IdTarefa As Long
    <DataMember(Name:="command")>
    Public Property Comando As String
    <DataMember(Name:="api_uri")>
    Public Property API As String
    <DataMember(Name:="return_fields")>
    Private Property JsonCamposRetorno As String
    <DataMember(Name:="periodicity")>
    Private Property Periodicidade As Integer
    <DataMember(Name:="schedule_date")>
    Private Property DataAgendamento As String
    <DataMember(Name:="periodicity_minutes")>
    Public Property IntervaloEmMinutos As Integer
    <DataMember(Name:="operation")>
    Public Property Operacao As Integer
    <DataMember(Name:="type_of_execution")>
    Public Property TipoExecucao As Integer
    Public Property MsgRetorno As String
    <DataMember(Name:="updated_at")>
    Public Property DataHoraUltimaAtualizacao As DateTime
    <DataMember(Name:="is_active")>
    Public Property Habilitado As Boolean

    Public Sub ExecutarComando()
        Me.ExecutarComando(Me.Comando)
    End Sub

    Private Sub ExecutarComando(ByVal query As String)
        Dim errorMsg As String = String.Empty
        Dim msgRetorno As String = String.Empty

        Try
            query = Me.TrataComando(query)

            If query.Contains("##EXECUCAO_MISTA##") Then
                msgRetorno = Me.ExecutarInstrucaoMista(query)
            Else

                Using connection As MySqlConnection = DBHelper.ConexaoBD()

                    Using mySqlCommand As MySqlCommand = New MySqlCommand(query, connection)

                        Select Case Me.Operacao
                            Case 1
                                msgRetorno = Me.RecuperaInformacao(mySqlCommand)
                            Case 2
                                msgRetorno = Me.ExecutarAtualizacao(mySqlCommand, Me.TipoExecucao)
                        End Select
                    End Using
                End Using
            End If

        Catch ex As Exception
            errorMsg = String.Format("Erro:{0} " & vbLf & " StackTrace: {1}", CObj(ex.Message), CObj(ex.StackTrace))
        Finally
            Me.AtualizaProcesso(errorMsg, msgRetorno)
        End Try
    End Sub

    Private Function TrataComando(ByVal comando As String) As String
        comando = comando.Replace("$nome_banco$", DBHelper.nomeBanco)
        Return comando
    End Function

    Private Sub AtualizaProcesso(ByVal errorMsg As String, ByVal msgRetorno As String)
        Try
            If Not String.IsNullOrEmpty(errorMsg) Then errorMsg = cryptografia_linear.Criptografar(errorMsg)
            msgRetorno = cryptografia_linear.Criptografar(msgRetorno)
            Dim str1 As String = String.Format("update monitor_tarefas set data_execucao ='{0}',", CObj(FormataData(DateTime.Now, 0)))
            Dim str2 As String

            If String.IsNullOrEmpty(errorMsg) Then
                str2 = str1 & String.Format("erro_executacao = '', retornado = 0,") & String.Format("executado = {0}, msg_retorno = '{1}'", CObj(2), CObj(msgRetorno))
                If Me.Periodicidade <> PeriodicidadeConst.EXECUCAO_UNICA AndAlso Me.Periodicidade <> PeriodicidadeConst.PROGRAMADA Then str2 = If(Me.Periodicidade <> PeriodicidadeConst.DIARIO OrElse Me.IntervaloEmMinutos <= 0, str2 & String.Format(" ,data_prox_execucao = '{0}' ", CObj(FormataData(DateTime.Now.AddDays(CDbl(Me.Periodicidade)), 2))), str2 & String.Format(" ,data_prox_execucao = '{0}' ", CObj(FormataData(DateTime.Now.AddMinutes(CDbl(Me.IntervaloEmMinutos)), 2))))
            Else
                str2 = str1 & String.Format("executado = {0}, erro_executacao = '{1}', msg_retorno = ''", CObj(1), CObj(errorMsg.Replace("'", "")))
            End If

            BaseModel.ExecutaQuery(str2 & String.Format(" where id_tarefa = {0}", CObj(Me.IdTarefa)))
        Catch ex As Exception
            MsgBox("Rotina:AtualizaProcesso, classe: tarefa, " & ex.Message)
        End Try
    End Sub

    Private Function RecuperaInformacao(ByVal command As MySqlCommand) As String
        Try
            Dim registros As List(Of Registro) = New List(Of Registro)()

            Using mySqlDataReader As MySqlDataReader = command.ExecuteReader()

                While mySqlDataReader.Read()
                    Dim campos As List(Of Campo) = New List(Of Campo)()

                    For Each campo As Campo In Me.CamposRetorno
                        Dim obj As Object = mySqlDataReader.GetValue(mySqlDataReader.GetOrdinal(campo.Nome.Trim()))
                        Dim result As DateTime

                        If DateTime.TryParse(obj.ToString(), result) Then
                            campos.Add(New Campo(campo.Nome, CObj(FormataData(result, 2))))
                        Else
                            campos.Add(New Campo(campo.Nome, CObj(obj.ToString())))
                        End If
                    Next

                    registros.Add(New Registro(campos))
                End While

                Return BaseModel.ToJson(CObj(New Retorno(DBHelper.RecuperaCnpj(), registros, Me.IdTarefa, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"))))
            End Using

        Catch ex As MySqlException
            Throw New Exception(ex.Message, CType(ex, Exception))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        End Try
    End Function

    Private Function ExecutarInstrucaoMista(ByVal query As String) As String
        Try
            Dim cmdText1 As String = ""
            Dim cmdText2 As String = ""
            Dim cmdText3 As String = ""
            Dim str1 As String = "##INICIO_EXECUCAO##"
            Dim str2 As String = "##FIM_EXECUCAO##"
            Dim str3 As String = "##INICIO_GERACAO_QUERIES##"
            Dim str4 As String = "##FIM_GERACAO_QUERIES##"
            Dim str5 As String = "##INICIO_COLETA_DADOS##"
            Dim str6 As String = "##FIM_COLETA_DADOS##"
            Dim startIndex1 As Integer = query.IndexOf(str1) + str1.Length
            Dim num1 As Integer = query.LastIndexOf(str2)
            If startIndex1 > -1 AndAlso num1 > -1 Then cmdText1 = query.Substring(startIndex1, num1 - startIndex1)
            Dim startIndex2 As Integer = query.IndexOf(str3) + str3.Length
            Dim num2 As Integer = query.LastIndexOf(str4)
            If startIndex2 > -1 AndAlso num2 > -1 Then cmdText2 = query.Substring(startIndex2, num2 - startIndex2)
            Dim startIndex3 As Integer = query.IndexOf(str5) + str5.Length
            Dim num3 As Integer = query.LastIndexOf(str6)
            If startIndex3 > -1 AndAlso num3 > -1 Then cmdText3 = query.Substring(startIndex3, num3 - startIndex3)

            Using connection As MySqlConnection = DBHelper.ConexaoBD()

                Using commandExecute1 As MySqlCommand = New MySqlCommand(cmdText1, connection)

                    Using commandExecute2 As MySqlCommand = New MySqlCommand(cmdText2, connection)

                        Using command As MySqlCommand = New MySqlCommand(cmdText3, connection)
                            If Not String.IsNullOrEmpty(commandExecute1.CommandText) Then Me.ExecutarAtualizacao(commandExecute1, 1, connection)
                            If Not String.IsNullOrEmpty(commandExecute2.CommandText) Then Me.ExecutarAtualizacao(commandExecute2, 2, connection)
                            Return Me.RecuperaInformacao(command)
                        End Using
                    End Using
                End Using
            End Using

        Catch ex As MySqlException
            Throw New Exception(ex.Message, CType(ex, Exception))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        End Try
    End Function

    Private Function ExecutarAtualizacao(ByVal commandExecute As MySqlCommand, ByVal tipoExecucao As Integer) As String
        Try

            Using connection As MySqlConnection = DBHelper.ConexaoBD()
                Return Me.ExecutarAtualizacao(commandExecute, tipoExecucao, connection)
            End Using

        Catch ex As MySqlException
            Throw New Exception(ex.Message, CType(ex, Exception))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        End Try
    End Function

    Private Function ExecutarAtualizacao(ByVal commandExecute As MySqlCommand, ByVal tipoExecucao As Integer, ByVal connection As MySqlConnection) As String
        Dim mySqlDataReader As MySqlDataReader = CType(Nothing, MySqlDataReader)
        Dim stringList As List(Of String) = New List(Of String)()

        Try

            Select Case tipoExecucao
                Case 1

                    If DBHelper.ExecucaoPermitida(commandExecute.CommandText) Then
                        commandExecute.ExecuteNonQuery()
                        Exit Select
                    End If

                Case 2
                    mySqlDataReader = commandExecute.ExecuteReader()

                    While mySqlDataReader.Read()

                        For ordinal As Integer = 0 To mySqlDataReader.FieldCount - 1
                            stringList.Add(mySqlDataReader.GetString(ordinal))
                        Next
                    End While

                    mySqlDataReader.Close()
                    mySqlDataReader = CType(Nothing, MySqlDataReader)

                    Using enumerator As List(Of String).Enumerator = stringList.GetEnumerator()

                        While enumerator.MoveNext()

                            Using commandExecute1 As MySqlCommand = New MySqlCommand(enumerator.Current, connection)
                                Me.ExecutarAtualizacao(commandExecute1, 1, connection)
                            End Using
                        End While

                        Exit Select
                    End Using
            End Select

            Return BaseModel.ToJson(CObj(New Retorno(DBHelper.RecuperaCnpj(), New Campo("x_executado", CObj("true")), Me.IdTarefa, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"))))
        Catch ex As MySqlException
            Throw New Exception(ex.Message, CType(ex, Exception))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            mySqlDataReader.Dispose()
        End Try
    End Function

    Public Shared Function PendentesDeExecucao() As List(Of Tarefa)
        Dim tarefaList As List(Of Tarefa) = New List(Of Tarefa)()
        Dim mySqlDataReader As MySqlDataReader = CType(Nothing, MySqlDataReader)

        Try
            Dim cmdText As String = "select t.id_tarefa,t.comando,t.campos_retorno,t.api_uri,t.estrutura,t.operacao, t.tipo_execucao, periodicidade, intervalo_em_minutos from monitor_tarefas t where (habilitado = 1) and " & String.Format("(executado = 0 and periodicidade <> {0}) or ", CObj(PeriodicidadeConst.PROGRAMADA)) & String.Format("(periodicidade not in ({0},{1}) and data_prox_execucao <= Now()) or ", CObj(PeriodicidadeConst.EXECUCAO_UNICA), CObj(PeriodicidadeConst.PROGRAMADA)) & String.Format("(executado = 0 and periodicidade = {0} and data_prox_execucao <= Now())  ", CObj(PeriodicidadeConst.PROGRAMADA))

            Using connection As MySqlConnection = DBHelper.ConexaoBD()

                Using mySqlCommand As MySqlCommand = New MySqlCommand(cmdText, connection)
                    mySqlDataReader = mySqlCommand.ExecuteReader()

                    While mySqlDataReader.Read()
                        Dim str As String = mySqlDataReader.GetString(mySqlDataReader.GetOrdinal("comando"))
                        Dim tarefa As Tarefa = New Tarefa() With {
                            .IdTarefa = mySqlDataReader.GetInt64(mySqlDataReader.GetOrdinal("id_tarefa")),
                            .Comando = cryptografia_linear.Descriptografar(str.Replace("''", "'")),
                            .API = cryptografia_linear.Descriptografar(mySqlDataReader.GetString(mySqlDataReader.GetOrdinal("api_uri"))),
                            .Operacao = CInt(mySqlDataReader.GetInt16(mySqlDataReader.GetOrdinal("operacao"))),
                            .TipoExecucao = CInt(mySqlDataReader.GetInt16(mySqlDataReader.GetOrdinal("tipo_execucao"))),
                            .Periodicidade = mySqlDataReader.GetInt32(mySqlDataReader.GetOrdinal("periodicidade")),
                            .IntervaloEmMinutos = mySqlDataReader.GetInt32(mySqlDataReader.GetOrdinal("intervalo_em_minutos"))
                        }
                        Dim jsonData As String = cryptografia_linear.Descriptografar(mySqlDataReader.GetString(mySqlDataReader.GetOrdinal("campos_retorno")))
                        If String.IsNullOrWhiteSpace(jsonData) Then jsonData = "[]"
                        tarefa.CamposRetorno = BaseModel.DeserializeJSon(Of List(Of Campo))(jsonData)
                        tarefaList.Add(tarefa)
                    End While
                End Using
            End Using

        Catch ex As MySqlException
            Throw New Exception(ex.Message, CType(ex, Exception))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            mySqlDataReader.Dispose()
        End Try

        Return tarefaList
    End Function

    Public Shared Function RecuperaDataHoraUltimaAtualizacao() As Long
        Dim mySqlDataReader As MySqlDataReader = CType(Nothing, MySqlDataReader)

        Try
            Dim cmdText As String = "select max(data_hora_ultima_atualizacao) as data_hora from monitor_tarefas"

            Using connection As MySqlConnection = DBHelper.ConexaoBD()

                Using mySqlCommand As MySqlCommand = New MySqlCommand(cmdText, connection)
                    mySqlDataReader = mySqlCommand.ExecuteReader()
                    ''  If mySqlDataReader.Read() AndAlso Not mySqlDataReader.IsDBNull(0) Then Return New DateTimeOffset(mySqlDataReader.GetDateTime(0)).ToUnixTimeSeconds()
                    Return 0
                End Using
            End Using

        Catch ex As Exception
            Throw
        Finally
            mySqlDataReader.Dispose()
        End Try
    End Function

    Public Shared Function PendentesDeRetorno() As List(Of Tarefa)
        Dim tarefaList As List(Of Tarefa) = New List(Of Tarefa)()

        Try
            Dim cmdText As String = "select msg_retorno,id_tarefa,api_uri from monitor_tarefas t where habilitado = 1 and executado = " & 2.ToString() & " and retornado <> " & 1.ToString()

            Using connection As MySqlConnection = DBHelper.ConexaoBD()

                Using mySqlCommand As MySqlCommand = New MySqlCommand(cmdText, connection)

                    Using mySqlDataReader As MySqlDataReader = mySqlCommand.ExecuteReader()

                        While mySqlDataReader.Read()
                            Dim tarefa As Tarefa = New Tarefa() With {
                                .IdTarefa = mySqlDataReader.GetInt64(mySqlDataReader.GetOrdinal("id_tarefa")),
                                .MsgRetorno = mySqlDataReader.GetString(mySqlDataReader.GetOrdinal("msg_retorno")),
                                .API = mySqlDataReader.GetString(mySqlDataReader.GetOrdinal("api_uri"))
                            }
                            tarefaList.Add(tarefa)
                        End While
                    End Using
                End Using
            End Using

            Return tarefaList
        Catch ex As MySqlException
            Throw New Exception(ex.Message, CType(ex, Exception))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        End Try
    End Function

    Public Sub Inserir()
        Try
            BaseModel.ExecutaQuery(String.Format("delete from monitor_tarefas where id_tarefa = {0}", CObj(Me.IdTarefa)))
            Dim str As String = "null"
            If Me.DataAgendamento IsNot Nothing Then str = String.Format("'{0}'", CObj(DateTime.Parse(Me.DataAgendamento).ToString("yyyy-MM-dd hh:mm:ss")))
            BaseModel.ExecutaQuery(String.Format("insert into monitor_tarefas (id_tarefa,comando,api_uri,campos_retorno,operacao,tipo_execucao,periodicidade,data_prox_execucao, intervalo_em_minutos, habilitado, data_hora_ultima_atualizacao) values ({0},'{1}','{2}','{3}',{4},{5},{6},{7}, {8}, {9}, '{10}')", CObj(Me.IdTarefa), CObj(cryptografia_linear.Criptografar(Me.Comando)), CObj(cryptografia_linear.Criptografar(Me.API)), CObj(cryptografia_linear.Criptografar(Me.JsonCamposRetorno)), CObj(Me.Operacao), CObj(Me.TipoExecucao), CObj(Me.Periodicidade), CObj(str), CObj(Me.IntervaloEmMinutos), CObj(Me.Habilitado), CObj(FormataData(Me.DataHoraUltimaAtualizacao, 2))))
        Catch ex As MySqlException

            If ex.ErrorCode = 1062 AndAlso ex.Source = "23000" Then
                MsgBox("Rotina:Inserir classe: tarefa ", ex.Message)
            Else
                MsgBox("Rotina:Inserir classe: tarefa ", ex.Message)
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Shared Sub TransmitirResposta(ByVal idTarefa As Long, ByVal api As String, ByVal msg As String)
        Try
            api = cryptografia_linear.Descriptografar(api)
            msg = cryptografia_linear.Descriptografar(msg)
            HttpRequest.Post(api, msg)
            Tarefa.TransmitidoComSucesso(idTarefa)
        Catch ex As Exception
            Tarefa.ErroTransmissao(idTarefa, ex)
        End Try
    End Sub

    Public Shared Sub TransmitidoComSucesso(ByVal idTarefa As Long)
        Try
            BaseModel.ExecutaQuery(String.Format("update monitor_tarefas set erro_retorno = null, retornado = {0} where id_tarefa = {1}", CObj(1), CObj(idTarefa)))
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Shared Sub ErroTransmissao(ByVal idTarefa As Long, ByVal ex As Exception)
        Try
            BaseModel.ExecutaQuery(String.Format("update monitor_tarefas set retornado = {0}, erro_retorno = '{1}', data_retorno = now() where id_tarefa = {2}", CObj(2), CObj(cryptografia_linear.Criptografar(String.Format("Erro:{0} " & vbLf & " StackTrace: {1}", CObj(ex.Message), CObj(ex.StackTrace)))), CObj(idTarefa)))
        Catch ex1 As Exception
            Throw
        End Try
    End Sub
End Class

