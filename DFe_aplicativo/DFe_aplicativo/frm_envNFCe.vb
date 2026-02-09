Imports DFe_aplicativo.C_WebService
Imports System.Xml
Imports System.Threading
Imports System.Text
Imports System.IO

Public Class frm_envNFCe
    Public xml_processar As New XmlDocument()
    Public xmldoc2 As New XmlDocument()
    Public xmldoc_PROC As New XmlDocument()
    Public xmldoc3 As New XmlDocument()
    Dim xmlnfe As String
    Dim xmldoc As New XmlDocument()
    Dim rotina1 As Thread, rotina2 As Thread, rotina3 As Thread, rotina4 As Thread
    Dim xmlnsManager As New XmlNamespaceManager(xmldoc.NameTable)
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frm_envNFCe_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frm_envNFCe_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub envialote()

        Dim WebS As New C_WebService()
        Dim xmlseguro As New System.Xml.XmlDocument()
        Dim StrRetorno As RetEnvio
        Dim ambiente As Integer = 1


        WebS.url_webservice(BuscaURL(mskchave.Text.Substring(0, 2), ambiente, False, mskchave.Text.Substring(20, 2)))
        '''''''''''''''''''''''''''''''''''#####################''''''''''''''''''''''''''''




        xmlseguro.Load(txtcaminho.Text)
        'ENVIA LOTE DE NOTAS VERSÃO 4.00
        StrRetorno = WebS.EnviaLote(xmlseguro)


        If Erro <> "" Or StrRetorno.cStat = "" Then
            MsgBox("Sistema da SEFAZ temporariamente fora do AR !" & vbCrLf & "Tente mais Tarde !", MsgBoxStyle.Exclamation, "Atenção !")
            Pinfo.Visible = False
            lblstatus.Visible = False
            txtret.Text = Erro
            Exit Sub
        End If

        If StrRetorno.cStat <> "103" Then

            If StrRetorno.cStat <> "104" Then
                txtret.Text = StrRetorno.xMotivo

                '  MsgBox(StrRetorno.xMotivo, MsgBoxStyle.Information, "Aviso1 !")
                Pinfo.Visible = False
            End If

        End If

        '''''''Rotorno processamento sincrono
        If StrRetorno.cStat = "104" Then

        End If


        If StrRetorno.cStat = "103" Then

            txtret.Text = StrRetorno.xMotivo & vbCrLf & "Numero Recibo: " & StrRetorno.nRec
            txtrecibo.Text = StrRetorno.nRec

        End If




        '---------------------------------Rotina abaixo para consulta recibo de envio da NFe-----------------------'''''''''''''''
        lblstatus.Visible = False

        Control.CheckForIllegalCrossThreadCalls = False
        rotina3 = New Thread(AddressOf Consulta_Retnfe)
        rotina3.SetApartmentState(ApartmentState.STA)

        rotina3.Start()




    End Sub


    Public Sub Consulta_Retnfe()

        '  If VerificaConectividade_net() = False Then
        'MsgBox("Seu computador esta sem acesso internet" + vbCrLf + "Operação cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
        '   Exit Sub
        '  End If
        Dim ambiente As Integer = 1
        Dim WebS As New C_WebService
        Dim RetonoConsulta As New RetRetorno

        Pinfo.Visible = True
        txtret.Text = "NFe Enviada para sefaz, Consultando O retorno da SEFAZ, Aguarde ..."
        Pinfo.Refresh()


        xmldoc.Load(txtcaminho.Text)
        xmldoc_PROC.LoadXml(SepararNota_PROC(xmldoc.InnerXml))



        WebS.url_webservice(BuscaURL(mskchave.Text.Substring(0, 2), ambiente, False, mskchave.Text.Substring(20, 2)))
        '''''''''''''''''''''''''''''''''''#####################''''''''''''''''''''''''''''

        ''''''''''''''''''''''''Aciona o webservice''''''''''''''''''''''''''''''''''''

        RetonoConsulta = WebS.ConsultaRecLote4(txtrecibo.Text, ambiente)

        If Erro <> "" Or RetonoConsulta.cStat = "" Then
            MsgBox("Sistema da SEFAZ temporariamente fora do AR !" & vbCrLf & "Tente mais Tarde !", MsgBoxStyle.Exclamation, "Atenção !")
            Pinfo.Visible = False
            txtret.Text = Erro
            Invoke(Sub() bntenviar_nfce.Text = "Consultar Ret")
            Salva_recibo(txtrecibo.Text, mskchave.Text)
            Exit Sub
        End If


        If RetonoConsulta.cStat = "105" Then
            txtret.Text = RetonoConsulta.cStat & " - " & RetonoConsulta.xMotivo & vbCrLf & "Tente Consultar Novamente o Retorno."
            Invoke(Sub() bntenviar_nfce.Text = "Consultar Ret")
            Invoke(Sub() Pinfo.Visible = False)
            Exit Sub
        End If


        txtret.Text = RetonoConsulta.cStat & " - " & RetonoConsulta.xMotivo & vbCrLf & "Prot.: " & RetonoConsulta.nProt
        ''''''''''''''''''''''''''''''Rotina Tratando Retorno da NFe (104 se o o lote foi processado)''''''''''''''''''''''''''''''''''''''
        If RetonoConsulta.cStat = "104" Then

            For Each RetC In RetonoConsulta.L_Retornos

                txtret.Text = RetC.xMotivo1

                If RetC.cStat1 = "204" Then
                    Dim nPost As Int32 = RetC.xMotivo1.IndexOf("nRec:")
                    txtrecibo.Text = RetC.xMotivo1.Substring(nPost + 5, RetC.xMotivo1.Length - nPost - 6).Trim
                    txtret.Text = "Troca de Recibo, Realize uma nova consulta..."
                    Invoke(Sub() bntenviar_nfce.Text = "Consultar Ret")
                End If

                If RetC.cStat1 <> "100" Then

                    txtret.Text = RetC.xMotivo1

                    If File.Exists(Application.StartupPath & "\XML\Recibo_Pend\" & mskchave.Text & "-nrecibo.xml") Then
                        File.Delete(Application.StartupPath & "\XML\Recibo_Pend\" & RetC.chNFe & "-nrecibo.xml")
                    End If

                    '  MsgBox(RetC.xMotivo, MsgBoxStyle.Exclamation, "Retorno do sefaz:")
                End If


                If RetC.cStat1 = "100" Then

                    xmldoc.Load(txtcaminho.Text)
                    ''''Chama a rotina para pegar o retorno do xml e montar a nota
                    Retxml()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    txtret.Text = RetC.chNFe & vbCrLf & RetC.xMotivo1 & vbCrLf & "Protocolo Autorizacao: " & RetC.nProt


                    'CRIA UM NOVO DOCUMENTO XML para salvar no banco de dados
                    Directory.CreateDirectory(Application.StartupPath & "\XML\NFCe")

                    Dim dados As XmlDocument = New XmlDocument
                    dados.Load(GerarNotaProcessada(xmldoc_PROC.InnerXml, xmlnfe, Date.Today, mskchave.Text))
                    dados.Save(Application.StartupPath & "\XML\NFCe\NFCe" & mskchave.Text & ".xml")


                    If File.Exists(Application.StartupPath & "\XML\Recibo_Pend\" & RetC.chNFe & "-nrecibo.xml") Then
                        File.Delete(Application.StartupPath & "\XML\Recibo_Pend\" & RetC.chNFe & "-nrecibo.xml")
                    End If

                End If
            Next


        End If


        Pinfo.Visible = False


        bntenviar_nfce.Enabled = True
    End Sub


    Private Sub Retxml()
        Dim xmldocret As New XmlDocument()
        xmldoc.Load(Application.StartupPath & "\xml\retenvioNFe.xml")
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode
        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist = xmldoc.SelectNodes("//bk:protNFe", xmlnsManager)

        For Each xmlnode In xmllist
            xmlnfe = xmlnode.OuterXml
        Next

        xmlnfe = xmlnfe.Replace("xmlns=""http://www.portalfiscal.inf.br/nfe""", "")

        ' xmlnfe = xmlnfe.Replace("<infProt", "<infProt xmlns=""http://www.portalfiscal.inf.br/nfe""")
    End Sub

    Private Sub bntopen_Click(sender As Object, e As EventArgs) Handles bntopen.Click
        dialogo.Filter = "Arquivos (*.xml)|*.xml|All files (*.*)|*.*"
        mskchave.Clear()
        bntenviar_nfce.Text = "Enviar NFe/NFCe"

        If dialogo.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtcaminho.Text = dialogo.FileName
            dadosnfe()

            Try
                '   gera_xml_env()
            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub gera_xml_env()
        Dim txtqrcodenfce As String
        Dim nome_arq As String
        Dim xmlAssinado12 As XmlDocument()
        ''''''''''''Rotina abaixo assinar o xml com certificado digital'''''''''''''''''''''''''
        xmldoc2.Load(txtcaminho.Text)
        nome_arq = Path.GetFileName(dialogo.FileName)

        xmldoc3.LoadXml(SepararNota3(xmldoc2.OuterXml))
        xmldoc2.LoadXml(SepararNota3(xmldoc2.OuterXml))

        Dim xmlAssinado As XmlDocument
        xmlAssinado = CertificadoDigital.Assinar(GerarNotaProcessada2(xmldoc2.OuterXml), "infNFe", certificado)


        If mskchave.Text.Substring(20, 2) = "65" Then

            ''''''''''''Rotina abaixo gera o QRCode da NFC-e'''''''''''''''''''''''''
            If txtqrcodenfce = "" Then

                txtqrcodenfce = GerarEndQRCodeXML(xmlAssinado.OuterXml)


                xmldoc2.LoadXml(xmlAssinado.OuterXml)


                xmlAssinado = Gerar_qrcode(xmldoc3.OuterXml, txtqrcodenfce, SepararNota_assinatura(xmlAssinado.OuterXml))

                xml_processar.LoadXml(xmlAssinado.OuterXml)

            End If

        End If

        Directory.CreateDirectory(Application.StartupPath & "\XML\NFCe_envie")
        ''''''''''''Rotina abaixo gera O Lote para envio'''''''''''''''''''''''''
        Dim lote As New NFe()

        xmlAssinado = lote.GerarLoteNfe(xmlAssinado)

        If Path.GetExtension(nome_arq) <> ".xml" Then
            nome_arq = nome_arq.Substring(0, nome_arq.Length - 4)
        End If

        If File.Exists(Application.StartupPath & "\XML\NFCe_envie\" & nome_arq) Then
            File.Delete(Application.StartupPath & "\XML\NFCe_envie\" & nome_arq)
        End If

        xmlAssinado.Save(Application.StartupPath & "\XML\NFCe_envie\" & nome_arq)




        MsgBox("XML assinado e salvo em," & vbCrLf & Application.StartupPath & "\XML\NFCe_envie\" & nome_arq)

        txtcaminho.Text = Application.StartupPath & "\XML\NFCe_envie\" & nome_arq
    End Sub

    Public Function SepararNota3(ByVal vNfeDadosMsg As String) As String

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        Dim nPost As Int32 = vNfeDadosMsg.IndexOf("</infNFe")

        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<infNFe")
        Dim vStringNfe2 As String = vNfeDadosMsg.Substring(nPosI, nPost + 4)

        Return vStringNfe2

    End Function
    Private Sub dadosnfe()
        xmldoc.Load(txtcaminho.Text)
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As XmlNode
        xmllist = xmldoc.GetElementsByTagName("infNFe")

        '---------------------------Abre dados do fornecedor-------------------------------------------------


        For Each xmlnode In xmllist
           
            mskchave.Text = xmlnode.Attributes.ItemOf("Id").InnerText.Substring(3, 44)

        Next
        ' Me.Width = 1010
        ' Me.Height = 630
    End Sub

    Private Sub bntenviar_nfce_Click(sender As Object, e As EventArgs) Handles bntenviar_nfce.Click

        If mskchave.Text = "" Then
            Exit Sub
        End If
        If MessageBox.Show("Deseja Enviar via WebHost ? ", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            '  If bntenviar_nfce.Text = "Enviar NFe/NFCe" Then
            txtret.Clear()

            lblstatus.Visible = True
            Pinfo.Visible = True

            Control.CheckForIllegalCrossThreadCalls = False
            rotina4 = New Thread(AddressOf envia_NF_host_list)
            rotina4.SetApartmentState(ApartmentState.STA)
            rotina4.Start()
           
            bntenviar_nfce.Text = "Enviar NFe/NFCe"

        Else
            gera_xml_env()
            txtret.Clear()

            lblstatus.Visible = True
            Pinfo.Visible = True

            Control.CheckForIllegalCrossThreadCalls = False
            rotina4 = New Thread(AddressOf envialote)
            rotina4.SetApartmentState(ApartmentState.STA)

            rotina4.Start()
       
            bntenviar_nfce.Text = "Enviar NFe/NFCe"

        End If

    End Sub

    Private Sub consultar_ret()
        If txtrecibo.Text = "" Then
            MsgBox("Informe o numero do Lote Recebido ?", MsgBoxStyle.Exclamation, "Aviso !")
            txtrecibo.Focus()
            Exit Sub
        End If

        txtret.Clear()
        Control.CheckForIllegalCrossThreadCalls = False
        rotina3 = New Thread(AddressOf Consulta_Retnfe)
        rotina3.SetApartmentState(ApartmentState.STA)

        rotina3.Start()
    End Sub

    Public Function GerarNotaProcessada2(ByVal vStringNfe As String) As XmlDocument
        Dim cVersaoDados As String = "4.00"

        'Montar a parte do XML referente ao Lote e acrescentar a Nota Fiscal
        Dim vStringLoteNfe As String = String.Empty
        vStringLoteNfe += "<?xml version=""1.0"" encoding=""utf-8""?>"
        vStringLoteNfe += "<NFe xmlns=""http://www.portalfiscal.inf.br/nfe"">"
        vStringLoteNfe += vStringNfe
        vStringLoteNfe += "</NFe>"

        Dim PastaNota As String = ""
        PastaNota = "C:\Users\adeni\Desktop\Nova_pasta" & "\"



        Dim NDoc = New XmlDocument()
     
        NDoc.LoadXml(vStringLoteNfe)



        '  Using xmltw As New XmlTextWriter(PastaNota & chavenfe + ".xml", New UTF8Encoding(False))
        'NDoc.WriteTo(xmltw)
        '   xmltw.Close()
        '  End Using

        Return NDoc
    End Function


    Public Function Gerar_qrcode(ByVal vStringNfe As String, ByVal QRCODE As String, ByVal assinatura As String) As XmlDocument
        Dim cVersaoDados As String = "4.00"

        'Montar a parte do XML referente ao Lote e acrescentar a Nota Fiscal
        Dim vStringLoteNfe As String = String.Empty
        vStringLoteNfe += "<?xml version=""1.0"" encoding=""utf-8""?>"
        vStringLoteNfe += "<NFe xmlns=""http://www.portalfiscal.inf.br/nfe"">"
        vStringLoteNfe += vStringNfe

        If QRCODE <> "" Then
            vStringLoteNfe += "<infNFeSupl>"
            vStringLoteNfe += "<qrCode>"
            vStringLoteNfe += "<![CDATA[" & QRCODE & "]]>"
            vStringLoteNfe += "</qrCode>"
            vStringLoteNfe += "<urlChave>http://nfce.fazenda.mg.gov.br/portalnfce</urlChave>"
            vStringLoteNfe += "</infNFeSupl>"
        End If
        vStringLoteNfe += assinatura
        vStringLoteNfe += "</NFe>"


        Dim NDoc = New XmlDocument()

        NDoc.LoadXml(vStringLoteNfe)

        Return NDoc
    End Function

    Public Function SepararNota_assinatura(ByVal vNfeDadosMsg As String) As String

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>

        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<Signature")
        Dim nPosF As Int32 = vNfeDadosMsg.Length - nPosI
        Dim vStringNfe As String = vNfeDadosMsg.Substring(nPosI, nPosF - 6)

        Return vStringNfe

    End Function

    Public Function SepararNota_PROC(ByVal vNfeDadosMsg As String) As String

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>

        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<NFe")
        Dim nPosF As Int32 = vNfeDadosMsg.Length - nPosI
        '   Dim vStringNfe As String = vNfeDadosMsg.Substring(nPosI, nPosF)

        '  Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<NFe")
        '  Dim nPost As Int32 = vNfeDadosMsg.IndexOf("</NFe")

        Dim vStringNfe2 As String = vNfeDadosMsg.Substring(nPosI, nPosF - 10)

        Return vStringNfe2

    End Function

  
 Public Function Salva_recibo(ByVal nrecibo As String, chv As String)



        'Salvar o número de lote de NFe utilizado
        Dim oSettings As New XmlWriterSettings()
        oSettings.Indent = True
        oSettings.IndentChars = ""
        oSettings.NewLineOnAttributes = False
        oSettings.OmitXmlDeclaration = False
        Directory.CreateDirectory(Application.StartupPath & "\XML\Recibo_Pend")
        Dim oXmlGravar As XmlWriter = XmlWriter.Create(Application.StartupPath & "\XML\Recibo_Pend\" & chv & "-nrecibo.xml", oSettings)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("DadosLoteNfe")
        oXmlGravar.WriteElementString("nRecibo", nrecibo)
        oXmlGravar.WriteElementString("ChaveNFe", chv)
        oXmlGravar.WriteEndElement()
        'DadosLoteNfe
        oXmlGravar.WriteEndDocument()
        oXmlGravar.Flush()
        oXmlGravar.Close()

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        ' Return nNumeroLote.ToString("000000000000000")

    End Function

    Public Function ler_recibo(ByVal chv As String)
        Dim ret As String
        'Pegar o último número de lote de NFe utilizado e acrescentar + 1 para novo envio
        Dim vArqXmlLote As String = Application.StartupPath & "\XML\Recibo_Pend\" & chv & "-nrecibo.xml"
        Dim nNumeroLote As Int32 = 1

        If File.Exists(vArqXmlLote) Then
            Dim oLerXml As New XmlTextReader(vArqXmlLote)

            While oLerXml.Read()
                If oLerXml.NodeType = XmlNodeType.Element Then
                    If oLerXml.Name = "nRecibo" Then
                        oLerXml.Read()
                        ret = oLerXml.Value
                        Exit While
                    End If
                End If
            End While
            oLerXml.Close()
        End If

       
        Return ret

    End Function

    Private Sub mskchave_TextChanged(sender As Object, e As EventArgs) Handles mskchave.TextChanged

        If ler_recibo(mskchave.Text) <> "" Then
            If MessageBox.Show("Existe Recibo Pendente de Consulta Para Esta NFe" & vbCrLf & "Deseja Consulta Recibo ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                txtrecibo.Text = ler_recibo(mskchave.Text)

                txtret.Clear()
                Control.CheckForIllegalCrossThreadCalls = False
                rotina3 = New Thread(AddressOf Consulta_Retnfe)
                rotina3.SetApartmentState(ApartmentState.STA)

                rotina3.Start()

            End If
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        consultar_ret()
    End Sub


    Private Sub envia_NF_host_list()

        Dim arquivo As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim ret As Dictionary(Of String, String) = New Dictionary(Of String, String)

        xmldoc.Load(txtcaminho.Text)

        arquivo.Add("ambiente", "1")
        arquivo.Add("tipo", mskchave.Text.Substring(34, 1))
        arquivo.Add("xml", xmldoc.OuterXml)
        arquivo.Add("nChave", mskchave.Text)
        arquivo.Add("nRec", txtrecibo.Text)

        Dim retConsSitNFe As retConsSitNFe
        Dim XmlRetornoSefaz As New XmlDocument()

        Try



            '  Dim thread As Thread = New Thread(AddressOf processarWS)
            '  thread.Start(CObj(arquivo))
            ret = processarWS_nfe4_list(arquivo, "Web4_EnviaNFe/enviaNFe")

            If ret("status") = "ok" Then

                txtret.Text = ret("cStat") & " - " & ret("xMotivo")
                Invoke(Sub() txtrecibo.Text = ret("nRec"))

                If ret("cStat") = "105" Then
                    txtret.Text = ret("cStat") & " - " & ret("xMotivo") & vbCrLf & "Tente Consultar Novamente o Retorno."
                    Invoke(Sub() bntenviar_nfce.Text = "Consultar Ret")
                    Invoke(Sub() Pinfo.Visible = False)
                    Exit Sub
                End If

                If ret("cStat") = "100" Then
                    Directory.CreateDirectory(Application.StartupPath & "\NFCe")
                    xmldoc.LoadXml(ret("xml"))
                    xmldoc.Save(Application.StartupPath & "\NFCe\NFCe-" & ret("chNFe") & ".xml")

                    txtret.Text = ret("chNFe") & vbCrLf & ret("xMotivo") & vbCrLf & "Protocolo Autorizacao: " & ret("nProt")

                    MsgBox("NF-e Autorizada !" & vbCrLf & "Chave acesso: " & ret("chNFe") & vbCrLf & "Protocolo Aut.: " & ret("nProt") & vbCrLf & "Status: " & ret("xMotivo"), MsgBoxStyle.Information, "Aviso ")
                    txtrecibo.Clear()
                    txtcaminho.Clear()
                    mskchave.Clear()
                End If

                If ret("cStat") = "204" Then
                    txtret.Text = ret("cStat") & " - " & ret("xMotivo") & vbCrLf & "Tente Consultar Novamente o Retorno."
                    txtrecibo.Text = ret("RecDup")
                End If

            Else
                MsgBox(ret("status"), MsgBoxStyle.Exclamation, "Aviso !")
                txtret.Text = ret("status")
            End If


            Invoke(Sub() Pinfo.Visible = False)

            Invoke(Sub() lblstatus.Visible = False)
        Catch ex As Exception
            txtret.Text = ret("status")

            MsgBox(ret("status"), MsgBoxStyle.Exclamation, "Aviso erro Rotina: consulta_statusNF_host_list !")


            Invoke(Sub() frminfo.Close())
        End Try
    End Sub
End Class
