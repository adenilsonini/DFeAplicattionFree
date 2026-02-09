Imports System.Security.Cryptography.X509Certificates
Imports System.Xml
Imports System.Text
Imports System.Drawing.Text
Imports System.IO
Imports DFe_aplicativo.C_WebService
Imports System.Xml.Linq
Imports System.Threading

Public Class frmcancelanfe
    Dim teste12 As Boolean
    Dim nprot As String, xm As String
    Dim rs As New ADODB.Recordset
    Public canc As Boolean
    Dim rotina1 As Thread, rotina2 As Thread
    Dim dataenv As String, xmlret_evento As String
    Dim certificado As X509Certificate2
    Dim WebS As New C_WebService
    Dim retorevento As New RetRetorno
    Dim xmldoc As New XmlDocument()
    Dim xmlAssinado As XmlDocument

    Private Sub bntcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntcancelar.Click

        If txtjust.Text.Length < 15 Then
            MsgBox("A Justificativa de ser No Minimo (15) caracter", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        If txtjust.Text.Length > 255 Then
            MsgBox("A Justificativa de ser No Maximo (255) caracter", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        If txtjust.Text = "" Then
            MsgBox("É Obrigatorio Informar a Justificativa do Cancelamento", MsgBoxStyle.Exclamation, "Aviso !")
            txtjust.Focus()
            Exit Sub
        End If

        If mskchave.Text = "" Then
            MsgBox("É Obrigatorio Informar a Chave de acesso da NFe", MsgBoxStyle.Exclamation, "Aviso !")
            mskchave.Focus()
            Exit Sub
        End If

        If mskchave.Text.Substring(0, 2) <> "31" Then
            MsgBox("Cancelamento Autorizado somente para SEFAZ MG", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        If chksubstituicao.Checked = True Then
            If mskchave.Text.Substring(20, 2) = "65" Then
                If mskchave_vinculada.Text = "" Then
                    MsgBox("Informe a chave da NFCe autorizada para Vincular", MsgBoxStyle.Exclamation, "Aviso !")
                    mskchave_vinculada.Focus()
                    Exit Sub
                End If
            End If
        End If

        If chksubstituicao.Checked = True Then
            If mskchave_vinculada.Text.Substring(34, 1) <> "9" Then
                MsgBox("A chave Vinculada deve ser de uma NFCe em Contigencia ?", MsgBoxStyle.Exclamation, "Aviso !")
                mskchave_vinculada.Focus()
                Exit Sub
            End If
        End If

        txtstatus_canc.Clear()


        mskcnpj.Text = mskchave.Text.Substring(6, 14)
        '  txtdatanfe.Clear()
        '  txthorafinal.Clear()

        xmlret_evento = ""

        ''''''''''Rotina para cancelar nfe abaixo

        cancelamento()
    End Sub

    Private Sub cancelamento()
        pinfo.Visible = True
        txtinfo.Text = "Aguarde, Gerando arquivo para cancelamento !"
        pinfo.Refresh()

        Dim xmlevento = New XmlDocument()
        Dim cancelamento As New NFe()

        cancelamento.versao = "1.00"
        cancelamento.tipo_cancelamento = "NFe"

        If chksubstituicao.Checked = True Then

            cancelamento.Id = "110112" + mskchave.Text + "01"
        Else
            cancelamento.Id = "110111" + mskchave.Text + "01"
        End If

        cancelamento.coduf = mskchave.Text.Substring(0, 2)
        cancelamento.tpAmb = empresa.ambiente_nfe
        cancelamento.cnpj = cnpj_cert
        cancelamento.chave = mskchave.Text
        cancelamento.dataenv = Now.ToString("yyyy-MM-ddTHH:mm:ss%K")
        cancelamento.xJust = txtjust.Text.TrimEnd()
        cancelamento.nProt = txtprotocolo.Text
        cancelamento.chaveNFCE_vinculada = mskchave_vinculada.Text

        If chksubstituicao.Checked = True Then
            cancelamento.tipo_cancelamento = "NFCe"
            cancelamento.descenv = "Cancelamento por substituicao"
            cancelamento.codenv = "110112"
        Else
            cancelamento.descenv = "Cancelamento"
            cancelamento.codenv = "110111"
        End If

        Dim xmldoc As XmlDocument = cancelamento.GerarXMLCancelamento()

        ' xmldoc.Save("c:\teste\testecancelamentoXMLNaoAssinado.xml")

        If nfecer = "" Then
            certificado = SelecionarCertificado("")
        Else
            certificado = SelecionarCertificado(nfecer)
        End If

        'assina o xml
        xmlAssinado = CertificadoDigital.Assinar(xmldoc, "infEvento", certificado)

        Dim teste As New NFe()
        Dim nNumeroLote As String
        ''''''''''''''''''''''''''''Rotina para buscar lote de envio evento
        nNumeroLote = teste.GerarLoteNfe_dfe

        Dim esquema_receita As String

        If chksubstituicao.Checked = True Then
            esquema_receita = "Evento_CancSubst\envEventoCancSubst_v1.00.xsd"
        Else
            esquema_receita = "Evento_Canc\envEventoCancNFe_v1.00.xsd"
        End If
        '''''''''''''''''''''''Valida o XML assinado

        xmlevento.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><envEvento versao=""1.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><idLote>" & nNumeroLote & "</idLote>" & xmlAssinado.InnerXml & "</envEvento>")

        Dim resultado As String = ValidaXML.ValidarXML(xmlevento, Application.StartupPath & "\Esquemas_XML_NF-e\" & esquema_receita & "")



        If resultado.Trim().Length = 0 Then
            '     resultado = "Xml gerado com sucesso, nenhum erro encontrado"
        End If

        If resultado.Trim().Length <> 0 Then
            MsgBox(resultado, MsgBoxStyle.Information, "Aviso !")
            xmlevento.Save(Application.StartupPath & "\XML\nfecancelamento-nao_assinado.xml")
            pinfo.Visible = False
            Exit Sub
        End If

        Using xmltw As New XmlTextWriter(Application.StartupPath & "\XML\nfecancelamento.xml", New UTF8Encoding(False))
            xmlevento.WriteTo(xmltw)
            xmltw.Close()
        End Using

        '''''''''''''''''''''''''''''saida da rotina


        ''''''''''''''''''''''''''''''Rotina abaixo que envia o xml de cancelamento para sefaz'''''''''''''''''''''

        If IsConectedToHost(New Uri("http://www.google.com")) = True Then

            Control.CheckForIllegalCrossThreadCalls = False
            rotina1 = New Thread(AddressOf Envia_celamento)
            rotina1.SetApartmentState(ApartmentState.STA)

            rotina1.Start()


        Else
            MsgBox("Seu computador esta sem acesso internet" + vbCrLf + "Operação cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
            pinfo.Visible = False
        End If


    End Sub

    Private Sub Envia_celamento()
        Dim xmlretcanc = New XmlDocument()


       
        pinfo.Visible = True
        txtinfo.Text = "Aguarde, Enviando o Cancelamento da NF-e para SEFAZ..."
        pinfo.Refresh()


        ''''''''''''''''Rotina ativa webservice''''''''''''''''''''''''
        retorevento = WebS.nfeRecepcaoEvento_canc(mskchave.Text, Application.StartupPath & "\XML\nfecancelamento.xml", empresa.ambiente_nfe)



        If retorevento.cStat = "128" Then

            For Each RetC In retorevento.L_Retornos

                If RetC.cStat1 <> "135" Then
                    If RetC.cStat1 <> "136" Then
                        If RetC.cStat1 <> "155" Then
                            MsgBox(RetC.xMotivo1, MsgBoxStyle.Exclamation, "Retorno do sefaz:")
                        End If
                    End If
                End If

                If RetC.cStat1 = "135" Or RetC.cStat1 = "136" Or RetC.cStat1 = "155" Then

                    MsgBox(RetC.xMotivo1 & vbCrLf & "Cancelamento efetuado com Sucesso !", MsgBoxStyle.Information, "Retorno do sefaz:")

                    ''''''Rotina abaixo busca retorno no xml''''
                    Retxml_cancelamento()

                    ' MsgBox("Retorno do Sefaz: " & retorevento.xMotivo + vbCrLf + "protocolo Canc: " + RetC.nProt, MsgBoxStyle.Information, "Retorno do Sefaz:")

                    '''''''''''''''''''''''''''''''Rotina para verificar pasta destino
                    If Directory.Exists(Application.StartupPath & "\XML_nfecanc") = False Then
                        Directory.CreateDirectory(Application.StartupPath & "\XML_nfecanc")
                    End If


                    xmlretcanc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><procEventoNFe versao=""4.00"" xmlns=""http://www.portalfiscal.inf.br/nfe"">" & xmlAssinado.InnerXml & "" & xmlret_evento & "</procEventoNFe>")
                    xmlretcanc.Save(Application.StartupPath + "\XML_nfecanc\" + RetC.chNFe + "-procEventoNFe.xml")

                    txtstatus_canc.Text = "cancelada"

                    nprot = RetC.nProt & " " & Convert.ToDateTime(RetC.dhRecbto).ToString("dd/MM/yyyy HH:mm:ss")
                    xm = RetC.xMotivo1


                    ''''''''''''''''''''''''''########################''''''''''''''''''''''''

                    If Me.Text = "Cancelamento NF-e emitida" Then
                        executa_query("update nfe_s set xmotivo = '" & RetC.xMotivo1 & "', cstat = '" & RetC.cStat1 & "', XML_canc = '" & Base64Encode(xmlretcanc.OuterXml) & "', nprot_canc = '" & RetC.nProt & "',  Status_nfe = 'NFe Cancelada'  where Chave_nfe = '" & mskchave.Text & "'")
                    End If



                    MsgBox("XML de Cancelamento gerado na Pasta abaixo: " + vbCrLf + Application.StartupPath + "\XML_nfecanc\", MsgBoxStyle.Information, "Aviso !")

                End If

            Next

        End If



        If retorevento.cStat <> "128" Then
            MsgBox("Retorno do Sefaz: " & retorevento.xMotivo, MsgBoxStyle.Information, "Retorno do Sefaz:")
        End If

        pinfo.Visible = False

    End Sub

    Private Sub Retxml_cancelamento()

        Dim dados As XmlDocument = New XmlDocument

        dados.Load(Application.StartupPath & "\xml\ret_cancelamento.xml")

        'DESMEMBRA RETORNO XML
        '-----------------------------------------------------------------------------------

        For Each outerNode As XmlNode In dados
            '  If outerNode.Name = "retEvento" Then


            For Each InnerNode As XmlNode In outerNode
                If InnerNode.Name = "retEvento" Then
                    xmlret_evento = InnerNode.OuterXml

                End If

            Next




        Next

    End Sub

    Private Sub frmcancelanfe_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub frmcancelanfe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      
        ' mskchave.Text = frmxml.mskchave.Text
        '  txtprotocolo.Text = frmxml.txtprotocolo.Text.Substring(0, 15)

        If mskchave.Text.Substring(20, 2) = "65" Then
            chksubstituicao.Visible = True
            chksubstituicao.Checked = True
        Else
            chksubstituicao.Checked = False
            Label5.Visible = False
            mskchave_vinculada.Visible = False
            bntopen.Visible = False
            chksubstituicao.Visible = False
        End If

     
    End Sub



    Private Sub bntopen_Click(sender As Object, e As EventArgs) Handles bntopen.Click
        Dim dialogo As New OpenFileDialog
        dialogo.Filter = "Arquivos (*.xml)|*.xml|All files (*.*)|*.*"

        If dialogo.ShowDialog() = Windows.Forms.DialogResult.OK Then
            xmldoc.Load(dialogo.FileName)

            Dim xmllist As System.Xml.XmlNodeList

            xmllist = xmldoc.GetElementsByTagName("infProt")

            For Each xmlnode In xmllist

                mskchave_vinculada.Text = xmlnode("chNFe").InnerText

            Next
        End If
    End Sub

   
End Class