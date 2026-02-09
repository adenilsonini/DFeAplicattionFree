Module Parametro
    Public execucao_automatico As Boolean, dfe_aba_ativa As Boolean
    Public caminho_banco As String, caminho_dfe_xml As String, intervalo_tempo As String
    Public horaverao As Boolean

    Public Sub carregar_parametro_DFe()

        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")

        If arquivoIni.KeyExists("ativa", "MANIFESTO_AUTOMATICO") = False Then
            arquivoIni.Write("ativa", "false", "MANIFESTO_AUTOMATICO")
        End If

        FrmDfe.chkmanifes.Checked = arquivoIni.Read("ativa", "MANIFESTO_AUTOMATICO")



        If arquivoIni.KeyExists("hora_verao", "DFe") = False Then
            arquivoIni.Write("hora_verao", "false", "DFe")
        End If
        horaverao = arquivoIni.Read("hora_verao", "DFe")



        If arquivoIni.KeyExists("ambiente", "DFe") = False Then
            arquivoIni.Write("ambiente", "2", "DFe")
        End If
        FrmDfe.cboambdfe.SelectedIndex = FrmDfe.cboambdfe.FindString(arquivoIni.Read("ambiente", "DFe"))

        If arquivoIni.KeyExists("caminho_banco", "DFe") = False Then
            arquivoIni.Write("caminho_banco", "", "DFe")
        End If

        If arquivoIni.KeyExists("caminho_xmlnfe", "DFe") = False Then
            arquivoIni.Write("caminho_xmlnfe", "", "DFe")
        End If
        caminho_dfe_xml = arquivoIni.Read("caminho_xmlnfe", "DFe")
        frmparametro.txtxml_nfe.Text = caminho_dfe_xml


        If arquivoIni.KeyExists("execucao_automatico", "DFe") = False Then
            arquivoIni.Write("execucao_automatico", "false", "DFe")
        End If
       

        If arquivoIni.KeyExists("dfe_ativa", "DFe") = False Then
            arquivoIni.Write("dfe_ativa", "false", "DFe")
        End If
        dfe_aba_ativa = arquivoIni.Read("dfe_ativa", "DFe")


        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''Carregar o NSU da consulta realizada'''''''''''''''''''
            Dim rssefaz As New ADODB.Recordset
            conectar_DFe()

            rssefaz.Open("select * from DFe_NSU where CNPJ = '" & cnpj_cert & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

            FrmDfe.txtultnsudfe.Text = rssefaz.Fields("NSU_ult").Value


            If FrmDfe.txtultnsudfe.Text = "" Then
                FrmDfe.txtultnsudfe.Text = "000000000000000"
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''Rotina abaixo verifica NSU faltante''''''''''''''''''''''


            cn_DFe.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Carrega NSU")
        End Try

    End Sub


End Module
