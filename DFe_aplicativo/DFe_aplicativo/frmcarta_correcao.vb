Imports System.Security.Cryptography.X509Certificates
Imports System.Xml
Imports System.Text
Imports System.Drawing.Text
Imports System.IO
Imports System.Xml.Linq
Imports System.Threading
Imports System.Drawing.Printing
Imports Microsoft.VisualBasic.Devices
Imports DFe_aplicativo.C_WebService
Imports MySql.Data.MySqlClient

Public Class frmcarta_correcao
    Dim doc_carta As Printing.PrintDocument
    Dim desc As String, nsequencia As String
    Dim prot_evento As String
    Dim data_prot As Date, hora_prot As Date
    Dim rs As New ADODB.Recordset
    Dim rotina1 As Thread, rotina2 As Thread
    Dim dataenv As String, xmlret_evento As String
    Dim WebS As New C_WebService
    Dim retorevento As New RetRetorno
    Dim xmlAssinado As XmlDocument
    Dim xmldoc As New XmlDocument()
    Dim xmlnsManager As New XmlNamespaceManager(xmldoc.NameTable)
    Private Sub frmcarta_correcao_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmpesquisanfe_emi.pesquisar_nfe()
    End Sub


    Private Sub frmcarta_correcao_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Me.Dispose()

    End Sub

    Private Sub frmcarta_correcao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dataenv = Now.ToString("yyyy-MM-ddTHH:mm:ss") + "-03:00"

        If frmxml_nfe.chkambiente.Checked = False Then
            lblambiente.Visible = True
        Else
            lblambiente.Visible = False
        End If
    End Sub

    Private Sub busca_sequencia()

        conectar_mysqlDFe()
        Dim SQLcommand10 As MySqlCommand
        SQLcommand10 = oConn.CreateCommand
        SQLcommand10.CommandText = "select * from nfe_s where Chave_nfe ='" & mskchave.Text & "'"
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand10.ExecuteReader

            While reader.Read
                txtnsequencia.Text = CDec(reader("nSeqEvento_carta")) + 1
            End While

        End Using


    End Sub
    Private Sub gerar_carta()
        pinfo.Visible = True
        txtinfo.Text = "Aguarde, Gerando arquivo da Carta de correção !"
        pinfo.Refresh()
        ''''''busca sequencia da carta correcao
        busca_sequencia()

        Dim xmlevento = New XmlDocument()
        Dim carta_correcao As New NFe()

        carta_correcao.versao = "1.00"
        carta_correcao.Id = "110110" + mskchave.Text + txtnsequencia.Text.PadLeft(2, "0")
        carta_correcao.coduf = mskchave.Text.Substring(0, 2)


        carta_correcao.tpAmb = empresa.ambiente_nfe


        carta_correcao.cnpj = mskchave.Text.Substring(6, 14)
        carta_correcao.chave = mskchave.Text
        carta_correcao.nSeqEvento = txtnsequencia.Text
        carta_correcao.dataenv = dataenv
        carta_correcao.xCorrecao = txtdesc.Text.TrimEnd()
        carta_correcao.xCondUso = txtinfomativo.Text


        Dim xmldoc As XmlDocument = carta_correcao.GerarXML_cartacorrecao

        xmldoc.Save(Application.StartupPath & "\XML\CARTA_XMLNaoAssinado.xml")


        'assina o xml
        xmlAssinado = CertificadoDigital.Assinar(xmldoc, "infEvento", certificado)


        ''''''''''''''''''''''''''''Rotina para buscar lote de envio evento
        Dim nlote As String = carta_correcao.GerarLote()

        '''''''''''''''''''''''Valida o XML assinado

        xmlevento.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><envEvento versao=""1.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><idLote>" & nlote & "</idLote>" & xmlAssinado.InnerXml & "</envEvento>")

        Dim resultado As String = ValidaXML.ValidarXML(xmlevento, Application.StartupPath & "\Esquemas_XML_NF-e\envCCe_v1.00.xsd")

        If resultado.Trim().Length = 0 Then
            '     resultado = "Xml gerado com sucesso, nenhum erro encontrado"
        End If

        If resultado.Trim().Length <> 0 Then
            MsgBox(resultado, MsgBoxStyle.Information, "Aviso !")
            xmlevento.Save(Application.StartupPath & "\XML\carta_correcao-nao_assinado.xml")
            pinfo.Visible = False
            Exit Sub
        End If

        Using xmltw As New XmlTextWriter(Application.StartupPath & "\XML\carta_correcao.xml", New UTF8Encoding(False))
            xmlevento.WriteTo(xmltw)
            xmltw.Close()
        End Using

        '''''''''''''''''''''''''''''saida da rotina

        '  Exit Sub
        ''''''''''''''''''''''''''''''Rotina abaixo que envia o xml de cancelamento para sefaz'''''''''''''''''''''
        If IsConectedToHost(New Uri("http://www.google.com")) = False Then
            MsgBox("Seu computador esta sem acesso internet" + vbCrLf + "Operação cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
            pinfo.Visible = False
            Exit Sub
        End If



        Control.CheckForIllegalCrossThreadCalls = False
        rotina1 = New Thread(AddressOf Envia_carta_correcao)
        rotina1.SetApartmentState(ApartmentState.STA)

        rotina1.Start()


    End Sub


    Private Sub Envia_carta_correcao()
        Dim xmlretcanc = New XmlDocument()

        pinfo.Visible = True
        txtinfo.Text = "Aguarde, Enviando a Carta de Correçao da NF-e para SEFAZ..."
        pinfo.Refresh()


        ''''''''''''''''Rotina ativa webservice''''''''''''''''''''''''
        retorevento = WebS.nfeRecepcaoEvento_canc(mskchave.Text, Application.StartupPath & "\XML\carta_correcao.xml", empresa.ambiente_nfe)




        If retorevento.cStat = "128" Then

            For Each RetC In retorevento.L_Retornos


                If RetC.cStat1 <> "135" Then
                    If RetC.cStat1 <> "136" Then
                        MsgBox(RetC.xMotivo1, MsgBoxStyle.Exclamation, "Retorno do sefaz:")
                    End If
                End If


                If RetC.cStat1 = "135" Or RetC.cStat1 = "136" Then

                    MsgBox(RetC.xMotivo1 & vbCrLf & "Carta de correcao Recebida com Sucesso !", MsgBoxStyle.Information, "Retorno do sefaz:")

                    ''''''Rotina abaixo busca retorno no xml''''
                    Retxml_cancelamento(RetC.chNFe)


                    '''''''''''''''''''''''''''''''Rotina para verificar pasta destino
                    If Directory.Exists(Application.StartupPath & "\XML_Carta_Correcao") = False Then
                        Directory.CreateDirectory(Application.StartupPath & "\XML_Carta_Correcao")
                    End If



                    xmlretcanc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><procEventoNFe versao=""1.00"" xmlns=""http://www.portalfiscal.inf.br/nfe"">" & xmlAssinado.InnerXml & "" & xmlret_evento & "</procEventoNFe>")
                    xmlretcanc.Save(Application.StartupPath + "\XML_Carta_Correcao\" + RetC.chNFe + "-procEventoNFe.xml")



                    ''''''''Rotina salva retorno no banco de dados''''''''''''''''''''''''''''''
                    executa_query("update nfe_s set Data_hora_carta = '" & Convert.ToDateTime(RetC.dhRecbto).ToString("yyyy-MM-dd HH:mm:ss") & "', nSeqEvento_carta = '" & txtnsequencia.Text & "', nProt_correcao = '" & RetC.nProt & "', XML_carta = '" & Base64Encode(xmlretcanc.OuterXml) & "' where Chave_nfe = '" & mskchave.Text & "'")

                    ''''''''''''''''''''''''''''''''''''''''########################''''''''''''''''''


                    MsgBox("XML de Carta de correcao gerado na Pasta abaixo: " + vbCrLf + Application.StartupPath + "\XML_Carta_Correcao\", MsgBoxStyle.Information, "Aviso !")

                    Invoke(Sub() Picprint.Visible = True)
                    Invoke(Sub() picpdf.Visible = True)
                End If

            Next

        End If



        If retorevento.cStat <> "128" Then
            MsgBox("Retorno do Sefaz: " & retorevento.xMotivo, MsgBoxStyle.Information, "Retorno do Sefaz:")
        End If

        pinfo.Visible = False
    End Sub


    Private Sub Retxml_cancelamento(ByVal nome As String)

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


        Dim xml_ret As XmlDocument = New XmlDocument

        xml_ret.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & xmlret_evento & "")

        xml_ret.Save(Application.StartupPath & "\xml\" & nome & "-RetCCE-procEventoNFe.xml")


    End Sub
    Private Sub bntexecutar_Click(sender As Object, e As EventArgs) Handles bntexecutar.Click

        If txtdesc.Text.Length < "15" Then
            MsgBox("A descrição deve ser de No mínimo 15 Caracter !", MsgBoxStyle.Exclamation, "Aviso !")
            txtdesc.Focus()
            Exit Sub
        End If

        If prot_evento <> "" Then
            MsgBox("A carta de correção já foi Transmitida para SEFAZ !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        gerar_carta()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles Picprint.Click

        gerar_carta_print()

        Dim objPrintPreview As New PrintPreviewDialog


        Try

            'define o formulário como maximizado e com Zoom

            With objPrintPreview

                .Document = doc_carta

                .WindowState = FormWindowState.Maximized

                .PrintPreviewControl.Zoom = 1

                .Text = "Relacao de Impressao"

                .ShowDialog()

            End With

        Catch ex As Exception

            MessageBox.Show(ex.ToString())

        End Try
    End Sub


    Private Sub ler_dados_emitente()
        mskfone.Text = ""
        txtemail.Text = ""

        Dim xmldocret As New XmlDocument()
        '    xmldoc.Load("C:\Users\Dell\Desktop\Carta correção\31131110962965000119550010000002321000010008-proc-NFe-CCe.xml")
        xmldoc.LoadXml(Base64Decode(ret_valor_campo("select * from nfe_s where Chave_nfe = '" & mskchave.Text & "'", "xml")))
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode

        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist = xmldoc.SelectNodes("//bk:emit", xmlnsManager)

        For Each xmlnode In xmllist

            If Not xmlnode("CNPJ") Is Nothing Then
                mskcnpjfor.Text = xmlnode("CNPJ").InnerText
            End If

            If Not xmlnode("xNome") Is Nothing Then
                txtnome.Text = xmlnode("xNome").InnerText
            End If
            If Not xmlnode("IE") Is Nothing Then
                txtiefor.Text = xmlnode("IE").InnerText
            End If

            If Not xmlnode("enderEmit") Is Nothing Then
                txtendfor.Text = xmlnode("enderEmit")("xLgr").InnerText & ", " & xmlnode("enderEmit")("nro").InnerText
            End If

            If Not xmlnode("enderEmit") Is Nothing Then
                txtbairrocep.Text = xmlnode("enderEmit")("xBairro").InnerText & " - " & FormatarCpfCnpj(xmlnode("enderEmit")("CEP").InnerText)
            End If

            If Not xmlnode("enderEmit") Is Nothing Then
                txtcidadeuf.Text = xmlnode("enderEmit")("xMun").InnerText & "/" & xmlnode("enderEmit")("UF").InnerText
            End If
            If Not xmlnode("enderEmit")("fone") Is Nothing Then
                mskfone.Text = xmlnode("enderEmit")("fone").InnerText
            End If
        Next

        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist = xmldoc.SelectNodes("//bk:dest", xmlnsManager)

        For Each xmlnode In xmllist
            If Not xmlnode("CNPJ") Is Nothing Then
                mskcnpjdest.Text = xmlnode("CNPJ").InnerText
            End If

            If Not xmlnode("IE") Is Nothing Then
                txtiedest.Text = xmlnode("IE").InnerText
            End If

            If Not xmlnode("email") Is Nothing Then
                txtemail.Text = xmlnode("email").InnerText
            End If

        Next

        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist = xmldoc.SelectNodes("//bk:infProt", xmlnsManager)

        For Each xmlnode In xmllist
            If Not xmlnode("nProt") Is Nothing Then
                txtprot_nfe.Text = xmlnode("nProt").InnerText
            End If
            If Not xmlnode("dhRecbto") Is Nothing Then
                txtprot_nfe.Text = txtprot_nfe.Text & "  " & Convert.ToDateTime(xmlnode("dhRecbto").InnerText).ToString("dd/MM/yyyy HH:mm:ss")
            End If
        Next


        conectar_baseNFe()

        rs.Open("select * from empresa where cnpj_emp = '" & removeFormatacao(mskcnpjfor.Text) & "'", conexao.cn_nfe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockPessimistic)
        txtemail.Text = rs.Fields("Email").Value

        cn_nfe.Close()

    End Sub

    Private Sub ler_dados_carta_correcao()

        Dim xmldocret As New XmlDocument()
        '    xmldoc.Load("C:\Users\Dell\Desktop\Carta correção\31131110962965000119550010000002321000010008-proc-NFe-CCe.xml")
        xmldoc.LoadXml(Base64Decode(ret_valor_campo("select * from nfe_s where Chave_nfe = '" & mskchave.Text & "'", "XML_carta")))
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode

        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist = xmldoc.SelectNodes("//bk:infEvento", xmlnsManager)

        For Each xmlnode In xmllist

            If Not xmlnode("detEvento") Is Nothing Then
                desc = xmlnode("detEvento")("xCorrecao").InnerText
                '  MsgBox(xmlnode("detEvento")("xCorrecao").InnerText)
            End If


            If Not xmlnode("dhRegEvento") Is Nothing Then
                data_prot = Convert.ToDateTime(xmlnode("dhRegEvento").InnerText).ToString("dd/MM/yyyy")
                hora_prot = Convert.ToDateTime(xmlnode("dhRegEvento").InnerText).ToString("HH:mm:ss")
                '  MsgBox(xmlnode("dhRegEvento").InnerText)
            End If

            If Not xmlnode("nSeqEvento") Is Nothing Then
                nsequencia = xmlnode("nSeqEvento").InnerText
                '   MsgBox(xmlnode("nSeqEvento").InnerText)
            End If

            If Not xmlnode("nProt") Is Nothing Then
                prot_evento = xmlnode("nProt").InnerText
                '   MsgBox(xmlnode("nProt").InnerText)
            End If



        Next
    End Sub
    ''' <summary>
    ''' '''''Rotina que gera o DOcumento da carta de correcao'''''''''''''
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="Gra_Saida"></param>
    Private Sub carta_PrintPage(ByVal sender As System.Object, ByVal Gra_Saida As System.Drawing.Printing.PrintPageEventArgs)
        ' Variaveis das linhas


        Dim Font12_B As New Font("Times New Roman", 12, FontStyle.Bold)
        Dim Font12 As New Font("Times New Roman", 12, FontStyle.Regular)
        Dim Font6 As New Font("Times New Roman", 6, FontStyle.Regular)
        Dim Font6_Courier As New Font("Courier New", 6, FontStyle.Regular)
        Dim Font6_B As New Font("Times New Roman", 6, FontStyle.Bold)
        Dim Font5 As New Font("Times New Roman", 5, FontStyle.Regular)
        Dim Font5_B As New Font("Courier New", 5, FontStyle.Bold)
        Dim Font12_S As New Font("Times New Roman", 12, FontStyle.Underline)
        Dim Font8 As New Font("Times New Roman", 8, FontStyle.Regular)
        Dim Font7 As New Font("Times New Roman", 7, FontStyle.Regular)
        Dim Font10 As New Font("Times New Roman", 10, FontStyle.Regular)
        Dim Font10_B As New Font("Times New Roman", 10, FontStyle.Bold)
        Dim Font10_S As New Font("Times New Roman", 10, FontStyle.Underline)
        Dim Font8_B As New Font("Times New Roman", 8, FontStyle.Bold)
        Dim FontArial7 As New Font("Arial", 7, FontStyle.Bold)



        Dim pen As New Pen(Brushes.Black, 0.2)
        Gra_Saida.Graphics.PageUnit = GraphicsUnit.Millimeter


        ''''''''''''''''''''''''''''''CABECALHO DA DANFE
        Dim CodigoBarra As CodigodeBarra
        CodigoBarra = New CodigodeBarra(CodigodeBarra.BCEncoding.Code128C)
        Gra_Saida.Graphics.DrawImage(CodigoBarra.DrawBarCode(mskchave.Text), 184, 2, 100, 11)

        'RETANGULOS ENTRADA E SAÍDA E FRETE POR CONTA
        Gra_Saida.Graphics.DrawRectangle(pen, 157, 14, 5, 5)


        'RETANGULOS carta correcao cabecalho
        Gra_Saida.Graphics.DrawRectangle(pen, 8, 45, 272, 60)
        'CONJUNTO DE LINHAS HORIZONTAIS DADOS EMPRESA
        Gra_Saida.Graphics.DrawLine(pen, 8, 53, 280, 53)

        Gra_Saida.Graphics.DrawString("CARTA DE CORREÇÃO ELETRÔNICA (CCe)", Font12_B, Brushes.Black, 105, 47)

        Gra_Saida.Graphics.DrawLine(pen, 8, 53, 280, 53)
        Gra_Saida.Graphics.DrawString("CONDIÇOES DE  USO DA CARTA CORREÇÃO", Font10_B, Brushes.Black, 10, 54)

        Dim Alinhamento As New StringFormat()
        Alinhamento.Alignment = StringAlignment.Near
        Gra_Saida.Graphics.DrawString("A Carta de Correção é disciplinada pelo § 1º-A do art. 7º do Convênio S/N, de 15 de dezembro de 1970 e pode ser utilizada para regularização de erro ocorrido na emissão de documento fiscal, desde que o erro não esteja relacionado com:", Font12_B, Brushes.Black, New RectangleF(10, 60, 270, 30), Alinhamento)

        Gra_Saida.Graphics.DrawString("I - as variáveis que determinam o valor do imposto tais como: base de cálculo, alíquota, diferença de preço, quantidade, valor da operação ou da prestação;", Font12_B, Brushes.Black, New RectangleF(10, 73, 270, 30), Alinhamento)
        Gra_Saida.Graphics.DrawString("II - a correção de dados cadastrais que implique mudança do remetente ou do destinatário;", Font12_B, Brushes.Black, New RectangleF(10, 85, 270, 30), Alinhamento)
        Gra_Saida.Graphics.DrawString("III - a data de emissao ou de saida.", Font12_B, Brushes.Black, New RectangleF(10, 94, 270, 30), Alinhamento)
        ''''''''''''''''''''''''''''''''''###########################''''''''''''''''''''''''''''''


        'RETANGULOS carta correcao corpo
        Gra_Saida.Graphics.DrawRectangle(pen, 8, 108, 272, 80)
        Gra_Saida.Graphics.DrawString("CORREÇÃO:", Font10_B, Brushes.Black, 10, 110)
        Gra_Saida.Graphics.DrawString(desc, Font12_B, Brushes.Black, New RectangleF(10, 115, 270, 30), Alinhamento)

        ''''''''''''''''''''''''#############################'''''''''''''''''''''''''''
        'RETANGULOS carta correcao Rodape
        Gra_Saida.Graphics.DrawRectangle(pen, 8, 189, 50, 10)
        Gra_Saida.Graphics.DrawString("EVENTO", Font6_B, Brushes.Black, 10, 190)
        Gra_Saida.Graphics.DrawString("CARTA DE CORREÇÃO", Font12, Brushes.Black, 10, 193)

        Gra_Saida.Graphics.DrawRectangle(pen, 65, 189, 50, 10)
        Gra_Saida.Graphics.DrawString("PROTOCOLO", Font6_B, Brushes.Black, 66, 190)
        Gra_Saida.Graphics.DrawString(prot_evento, Font12, Brushes.Black, 66, 193)

        Gra_Saida.Graphics.DrawRectangle(pen, 126, 189, 50, 10)
        Gra_Saida.Graphics.DrawString("SEQUÊNCIA", Font6_B, Brushes.Black, 126, 190)
        Gra_Saida.Graphics.DrawString(nsequencia, Font12, Brushes.Black, 126, 193)

        Gra_Saida.Graphics.DrawRectangle(pen, 178, 189, 50, 10)
        Gra_Saida.Graphics.DrawString("DATA DO EVENTO", Font6_B, Brushes.Black, 178, 190)
        Gra_Saida.Graphics.DrawString(data_prot, Font12, Brushes.Black, 178, 193)

        Gra_Saida.Graphics.DrawRectangle(pen, 230, 189, 50, 10)
        Gra_Saida.Graphics.DrawString("HORA DO EVENTO", Font6_B, Brushes.Black, 230, 190)
        Gra_Saida.Graphics.DrawString(hora_prot, Font12, Brushes.Black, 230, 193)

        'CONJUNTO DE LINHAS LATERAIS ESQUERDAS
        Gra_Saida.Graphics.DrawLine(pen, 2, 201, 2, 2)

        Gra_Saida.Graphics.DrawLine(pen, 287, 201, 287, 2)

        'CONJUNTO DE LINHAS HORIZONTAIS DADOS EMPRESA
        Gra_Saida.Graphics.DrawLine(pen, 2, 33, 287, 33)
        Gra_Saida.Graphics.DrawLine(pen, 2, 40, 287, 40)
        ' Gra_Saida.Graphics.DrawLine(pen, 23, 47, 287, 47)

        'CONJUNTO DE LINHAS ESQUADRAR A PAGINA
        Gra_Saida.Graphics.DrawLine(pen, 2, 2, 287, 2)
        Gra_Saida.Graphics.DrawLine(pen, 2, 201, 287, 201)

        'CONJUNTO DE LINHAS VERTICAIS DADOS DA NOTA
        Gra_Saida.Graphics.DrawLine(pen, 130, 2, 130, 33)
        Gra_Saida.Graphics.DrawLine(pen, 166, 2, 166, 40)



        'CONJUNTO DE LINHAS HORIZONTAIS CODIGO DE BARRAS
        Gra_Saida.Graphics.DrawLine(pen, 166, 15, 287, 15)
        Gra_Saida.Graphics.DrawLine(pen, 166, 22, 287, 22)



        'Gra_Saida.Graphics.DrawImage(Image.FromFile("Logo.jpg"), 27, 4, 95, 28)
        'Gra_Saida.Graphics.DrawString("Identificação do Emitente", Font10_B, Brushes.Black, 25, 2)
        Gra_Saida.Graphics.DrawString("DANFE (CCe)", Font12_B, Brushes.Black, 135, 2)
        Gra_Saida.Graphics.DrawString("DOCUMENTO AUXILIAR DA", Font7, Brushes.Black, 131.2, 7)
        Gra_Saida.Graphics.DrawString("CARTA DE CORREÇÃO", Font7, Brushes.Black, 133.5, 10)
        Gra_Saida.Graphics.DrawString("0 - ENTRADA", Font7, Brushes.Black, 134.5, 13.5)
        Gra_Saida.Graphics.DrawString("1 - SAÍDA", Font7, Brushes.Black, 134.5, 17)
        Gra_Saida.Graphics.DrawString("N.º " & Int32.Parse(ret_valor_campo("select * from nfe_s where Chave_nfe = '" & mskchave.Text & "'", "Numero_nfe")).ToString("000,000,000"), Font10_B, Brushes.Black, 131.5, 21)
        Gra_Saida.Graphics.DrawString("SÉRIE:", Font10_B, Brushes.Black, 131.5, 25)
        Gra_Saida.Graphics.DrawString(Int32.Parse(ret_valor_campo("select * from nfe_s where Chave_nfe = '" & mskchave.Text & "'", "Serie_nfe")).ToString("000"), Font10_B, Brushes.Black, 144.5, 25)

        If frmxml_nfe.optentrada.Checked = True Then
            Gra_Saida.Graphics.DrawString("0", Font8_B, Brushes.Black, 158, 15)
        Else
            Gra_Saida.Graphics.DrawString("1", Font8_B, Brushes.Black, 158, 15)
        End If

        Gra_Saida.Graphics.DrawString("CHAVE DE ACESSO", Font6, Brushes.Black, 167, 15.2)
        Gra_Saida.Graphics.DrawString(MascSTR(mskchave.Text, "#### #### #### #### #### #### #### #### #### #### ####"), Font12_B, Brushes.Black, 167, 17)
        Gra_Saida.Graphics.DrawString("Consulta de autenticidade no portal nacional da NF-e", Font12, Brushes.Black, 167, 22)
        Gra_Saida.Graphics.DrawString("www.nfe.fazenda.gov.br/portal", Font12_S, Brushes.Black, 167, 26)
        Gra_Saida.Graphics.DrawString("ou no site da Sefaz Autorizadora", Font12, Brushes.Black, 220.9, 26)


        Gra_Saida.Graphics.DrawString("CNPJ Emitente", Font6, Brushes.Black, 3, 33.2)
        Gra_Saida.Graphics.DrawString(mskcnpjfor.Text, Font10_B, Brushes.Black, 3, 35)
        Gra_Saida.Graphics.DrawLine(pen, 39, 33, 39, 40)

        Gra_Saida.Graphics.DrawString("INSCRIÇÃO ESTADUAL", Font6, Brushes.Black, 40, 33.2)
        Gra_Saida.Graphics.DrawString(txtiefor.Text, Font10_B, Brushes.Black, 40, 35)
        Gra_Saida.Graphics.DrawLine(pen, 80, 33, 80, 40)

        Gra_Saida.Graphics.DrawString("CNPJ DESTINATÁRIO", Font6, Brushes.Black, 81, 33.2)
        Gra_Saida.Graphics.DrawString(mskcnpjdest.Text, Font10_B, Brushes.Black, 81, 35)
        Gra_Saida.Graphics.DrawLine(pen, 120, 33, 120, 40)

        Gra_Saida.Graphics.DrawString("INSCRIÇÃO ESTADUAL DESTINATÁRIO", Font6, Brushes.Black, 121, 33.2)
        Gra_Saida.Graphics.DrawString(txtiedest.Text, Font10_B, Brushes.Black, 121, 35)

        Gra_Saida.Graphics.DrawString("PROTOCOLO DE AUTORIZAÇÃO DE USO", Font6, Brushes.Black, 167, 33.2)
        Gra_Saida.Graphics.DrawString(txtprot_nfe.Text, Font12_B, Brushes.Black, 167, 35)



        Gra_Saida.Graphics.DrawString("CONTROLE DO FISCO", Font5_B, Brushes.Black, 570, 20, New StringFormat)
        Gra_Saida.Graphics.DrawString("IDENTIFICAÇÃO DO EMITENTE", Font5_B, Brushes.Black, 40, 3, New StringFormat)
        'quadro de informações sobre o Emitente
        '  Gra_Saida.Graphics.DrawRectangle(pen, 10, 20, 335, 129)
        ' frmxml.txtnomefor.Text = "SUPERMERCADO DOKA LTDA, SUPERMERCADO DOKA LTDA"

        '  If frmxml.txtnomefor.Text.Length > 30 Then

        Alinhamento.Alignment = StringAlignment.Center
        Gra_Saida.Graphics.DrawString(txtnome.Text, Font12_B, Brushes.Black, New RectangleF(31, 5, 85, 12), Alinhamento)

        ' Else

        '  Alinhamento.Alignment = StringAlignment.Center
        '   Gra_Saida.Graphics.DrawString(frmxml.txtnomefor.Text, Font12_B, Brushes.Black, New RectangleF(12, 5, 110, 12), Alinhamento)

        ' End If

        ' If frmxml.txtnomefor.Text.Length > 40 Then
        Dim Alinhamento1 As New StringFormat()
        Alinhamento1.Alignment = StringAlignment.Near
        Gra_Saida.Graphics.DrawString(txtendfor.Text, FontArial7, Brushes.Black, New RectangleF(35, 15, 250, 50), Alinhamento1)
        ' Else
        '     Gra_Saida.Graphics.DrawString(frmxml.txtendfor.Text & ", " & frmxml.txtnumerofor.Text, FontArial7, Brushes.Black, 35, 10, New StringFormat)
        ' End If

        Gra_Saida.Graphics.DrawString(txtbairrocep.Text, FontArial7, Brushes.Black, 35, 18, New StringFormat)
        Gra_Saida.Graphics.DrawString(txtcidadeuf.Text & "/" & frmxml_nfe.txtuffor.Text, FontArial7, Brushes.Black, 35, 21, New StringFormat)
        Gra_Saida.Graphics.DrawString(mskfone.Text, FontArial7, Brushes.Black, 35, 24, New StringFormat)

        Gra_Saida.Graphics.DrawString(txtemail.Text, FontArial7, Brushes.Black, 35, 27, New StringFormat)

        '''''''''''''''''Carrega a imagem do logo da NF-e para o DANFE'''''''''''''''''''   
        Try
            Gra_Saida.Graphics.DrawImage(Image.FromFile(frmxml_nfe.txtcaminho_logo.Text), 2, 2, 30, 30)
        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' ''''''Rotina para gerar o Documento da carta de correção
    ''' </summary>
    Private Sub gerar_carta_print()
        Dim doc As Printing.PrintDocument = New Printing.PrintDocument()
        AddHandler doc.PrintPage, New Printing.PrintPageEventHandler(AddressOf Me.carta_PrintPage)
        doc.DefaultPageSettings.Landscape = True

        doc_carta = doc

        ler_dados_emitente()
        ler_dados_carta_correcao()
    End Sub

    Private Sub picpdf_Click(sender As Object, e As EventArgs) Handles picpdf.Click
        Dim computerInfo As New ComputerInfo
        Dim SaveFiled_carta As New SaveFileDialog

        SaveFiled_carta.Title = "Local para salvar o Documento"

        SaveFiled_carta.Filter = "Arquivos (*.pdf)|*.pdf|All files (*.*)|*.*"

        SaveFiled_carta.FileName = mskchave.Text & "-CCe"



        If SaveFiled_carta.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '   Pinfo.Visible = True

            gerar_carta_print()


            If computerInfo.OSFullName.Substring(0, 20) = "Microsoft Windows 10" Then

                gerar_pdf_sistema(doc_carta, SaveFiled_carta.FileName)

            Else

                gerar_xps_PDF_sistema(doc_carta, mskchave.Text & "-CCe", SaveFiled_carta.FileName)

            End If

            pinfo.Visible = False
            MsgBox("Carta de Correção no Formato PDF gerado com sucesso no local informado !", MsgBoxStyle.Information, "Aviso !")

        End If


    End Sub
End Class