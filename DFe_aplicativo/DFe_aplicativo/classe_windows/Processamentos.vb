Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Reflection
Imports System.IO


Module Processamentos
    Public AtualizandoSistema As Boolean
    Public Function FinalizarProcesso(ByVal processPath As String) As Boolean
        Try
            Dim processesByName As Process() = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(processPath))
            If processesByName.Length <> 0 Then processesByName(0).Kill()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ProcessoEmExecucao(ByVal processPath As String) As Boolean
        Try
            Return CUInt(Process.GetProcessesByName(Path.GetFileNameWithoutExtension(processPath)).Length) > 0UI
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function IniciarServico(ByVal caminho As String) As Boolean
        Try
            ' Dim configuracaoWsLinear As ConfiguracaoWSLinear = New ConfiguracaoWSLinear()

            '   If configuracaoWsLinear.Habilitado Then

            'If Not configuracaoWsLinear.PossuiErro Then
            If ProcessoEmExecucao(caminho) Then Throw New Exception("Processo " & caminho & " já está em execução.")
            If AtualizandoSistema Then Throw New Exception("Sistema em atualização. Não é possível iniciar o WSLinearApi.")

            Using process As Process = New Process()
                Dim startInfo As ProcessStartInfo = process.StartInfo
                startInfo.FileName = caminho
                process.StartInfo.UseShellExecute = False
                process.StartInfo.RedirectStandardOutput = True
                process.StartInfo.RedirectStandardError = True
                startInfo.WindowStyle = ProcessWindowStyle.Hidden
                '  startInfo.Arguments = configuracaoWsLinear.BaseUrl
                process.Start()
            End Using
            '  End If
            '  End If

        Catch ex As Exception
            Throw
        End Try

        Return True
    End Function

    Friend Sub VerificaLicenca(ByVal mysqlControl As MysqlControl)
        Try
            Dim cliente As LinxOSCliente = LinxOSCliente.LocalizarWebService(MysqlControl.Cnpj)

            If cliente.LicencaDisponivel Then
                Dim linxOSLicenca As LinxOSLicenca = New LinxOSLicenca(cliente, MysqlControl)
                If Not (HttpRequest.Post(ApiURL.LicenseGenerateUri(), BaseModel.ToJson(CObj(linxOSLicenca))) <> String.Empty) Then Return
                MysqlControl.GravarNovaLicenca(linxOSLicenca, MysqlControl.StatusLincesaUso.Disponivel)
            Else
                If Not (MysqlControl.License = MysqlControl.StatusLincesaUso.Disponivel.ToString()) Then Return
                Dim linxOSLicenca As LinxOSLicenca = New LinxOSLicenca(cliente, mysqlControl, RecuperaDiasLicencaClienteBloqueado())

                MysqlControl.GravarNovaLicenca(linxOSLicenca, MysqlControl.StatusLincesaUso.Indisponivel)
            End If

        Catch ex As Exception
            If ex.Message.Contains("500") Then Return
            Throw
        End Try
    End Sub

    Private Function RecuperaDiasLicencaClienteBloqueado() As Integer
        Try
            Dim dateTime As DateTime = DataSistema()
            If dateTime.DayOfWeek = DayOfWeek.Saturday Then Return 7
            Return If(dateTime.DayOfWeek = DayOfWeek.Sunday, 6, 5)
        Catch ex As Exception
            Throw
        End Try
    End Function
End Module
