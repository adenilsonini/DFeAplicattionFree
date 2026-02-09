

Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Net
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml

Imports System.Security.Cryptography.X509Certificates
Imports System.Xml
Imports System.Text
Imports System.Threading
Imports System.Drawing.Text
Imports System.IO
Imports DFe_aplicativo.C_WebService
Imports DFe_aplicativo.NFe
Imports System.Xml.Linq
Imports System.Data.OleDb
Imports System.Globalization

Imports MessagingToolkit.QRCode.Codec
Imports System.Drawing.Printing
Imports System.Data.SQLite
Imports System.IO.Ports
Imports MySql.Data.MySqlClient

Public Class frmxml

    Public iRetTrImp As Integer
    Public importar_xml As Boolean
    Public cAux As String
    Private iRet As Integer
    Private strXml As String
    Private strTextoVias As String
    Private cPortaImp As String
    Private TPAmbiente As Integer
    Private versao_layout As String
    Private linhasPorPagina As Integer
    Private posicaoDaLinha As Decimal
    Private linhaAtual As Integer
    Private paginaAtual As Integer
    Private margemEsq As Single
    Private margemSup As Single
    Private margemDir As Single
    Private margemInf As Single
    Private caneta As Pen
    Private fonteTitulo As Font
    Private fonteTitulo2 As Font
    Private fonteRodape As Font
    Private fonteNormal As Font
    Private fonteColuna As Font
    Private tipoFonte As String
    Private ArquivoFonte As StreamReader
    Private mCaminhoLogo As String
    Private mReduzido As Boolean


    Dim WebS As New C_WebService

    Dim erro_validacao As Boolean = False
    Dim inclusao As Boolean = False

    Dim ind As Integer
    Dim rotina1 As Thread, rotina2 As Thread, rotina3 As Thread


    Dim data_emissao As Date, data_saida As Date, data_prot As Date

    Public valortotaltrib As String, hora As String, uf As String, tiponota As String, Recibonfe As String, xmlnfe As String
    Public versao As String = "Visualizador de Nota Fiscal Eletronica/NFC-e  Net 4.8  |  12/11/2019"

    Dim verifica As Boolean, reparaxml_auto As Boolean, contigencia As Boolean

    Dim rs As New ADODB.Recordset

    Public xmldoc As New XmlDocument()
    Dim xmlnsManager As New XmlNamespaceManager(xmldoc.NameTable)






#Region "''''Rotina Cria o Código de barra da nfe"



    Private Function carregalogo(ByVal fileName As String) As Byte()

        'Método para carregar uma imagem do disco e retorná-la como um byteStream
        Dim fs As FileStream = New FileStream(fileName, FileMode.Open, FileAccess.Read)
        Dim br As BinaryReader = New BinaryReader(fs)
        Return (br.ReadBytes(Convert.ToInt32(br.BaseStream.Length)))

    End Function

    Private Function carregaImagem(ByVal fileName As String) As Byte()

        'Método para carregar uma imagem do disco e retorná-la como um byteStream
        Dim fs As FileStream = New FileStream(fileName, FileMode.Open, FileAccess.Read)
        Dim br As BinaryReader = New BinaryReader(fs)
        Return (br.ReadBytes(Convert.ToInt32(br.BaseStream.Length)))

    End Function
#End Region


#Region "''''Rotina carrega os dados da NFe"

    Private Sub chave()

        Dim xmllist As System.Xml.XmlNodeList

        xmllist = xmldoc.GetElementsByTagName("infProt")

        For Each xmlnode In xmllist

            txtcoduf.Text = xmlnode("chNFe").InnerText.Substring(0, 2)
            mskchave.Text = xmlnode("chNFe").InnerText
            data_prot = xmlnode("dhRecbto").InnerText
            txtprotocolo.Text = xmlnode("nProt").InnerText & "  " & data_prot
            msknprot.Text = xmlnode("nProt").InnerText
            txtxmotivo.Text = xmlnode("xMotivo").InnerText

            '----------gera o codigo de barra para chave de acesso
            ' codBarImagem.Image.Save(Application.StartupPath & "\codbarranfe.jpg")

            '  geracodbarra()
            '  salvacodbarra()
            mskchave.Mask = "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000"
            lblnfe.Visible = True
            lblnfe.Text = "NF-e Autorizada"
            lblnfe.BackColor = Color.Blue
        Next

    End Sub

    Private Sub dadosnfe()

        ' Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode, xmlnode2 As System.Xml.XmlNode
        ' xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        '  xmllist = xmldoc.SelectNodes("//bk:NFe", xmlnsManager)

        '---------------------------Abre dados do fornecedor-------------------------------------------------
        limpar_abas()

        Dim xmllist As System.Xml.XmlNodeList

        xmllist = xmldoc.GetElementsByTagName("infNFe")

        For Each xmlnode In xmllist

            txtuffor.Text = xmlnode("emit")("enderEmit")("UF").InnerText

            txtpainel.Text = xmlnode("emit")("xNome").InnerText

            txtnomefor.Text = xmlnode("emit")("xNome").InnerText

            If Not xmlnode("emit")("CNPJ") Is Nothing Then

                mskcnpjfor.Mask = "00,000,000/0000-00"
                mskcnpjfor.Text = xmlnode("emit")("CNPJ").InnerText

            End If

            If Not xmlnode("emit")("CPF") Is Nothing Then

                mskcnpjfor.Mask = "000,000,000-00"
                mskcnpjfor.Text = xmlnode("emit")("CPF").InnerText

            End If

            txtendfor.Text = xmlnode("emit")("enderEmit")("xLgr").InnerText
            txtnumerofor.Text = xmlnode("emit")("enderEmit")("nro").InnerText
            txtiefor.Text = xmlnode("emit")("IE").InnerText
            txtbairrofor.Text = xmlnode("emit")("enderEmit")("xBairro").InnerText
            txtcidadefor.Text = xmlnode("emit")("enderEmit")("xMun").InnerText
            txtregime.Text = xmlnode("emit")("CRT").InnerText



            mskchave.Text = xmlnode.Attributes.ItemOf("Id").InnerText.Substring(3, 44)
            versao_nfe.Text = "Versão NF-e: " & xmlnode.Attributes.ItemOf("versao").InnerText

            If Not xmlnode("infNFeSupl") Is Nothing Then
                txtqrcodenfce.Text = xmlnode("infNFeSupl")("qrCode").InnerText
            End If

            If txtcoduf.Text = "" Then
                txtcoduf.Text = mskchave.Text.Substring(0, 2)
            End If

            If Not xmlnode("emit")("IEST") Is Nothing Then
                txtinscst.Text = xmlnode("emit")("IEST").InnerText
            End If
            If Not xmlnode("emit")("IM") Is Nothing Then
                txtim.Text = xmlnode("emit")("IM").InnerText
            End If
            If Not xmlnode("emit")("CNAE") Is Nothing Then
                txtcnae.Text = xmlnode("emit")("CNAE").InnerText
            End If
            If Not xmlnode("emit")("xFant") Is Nothing Then
                txtnomefanfor.Text = xmlnode("emit")("xFant").InnerText
            End If
            If Not xmlnode("emit")("enderEmit")("xPais") Is Nothing Then
                txtpaisfor.Text = xmlnode("emit")("enderEmit")("xPais").InnerText
            End If
            If Not xmlnode("ide")("idDest") Is Nothing Then
                txtidDest.Text = xmlnode("ide")("idDest").InnerText
            End If
            If Not xmlnode("emit")("enderEmit")("cMun") Is Nothing Then
                txtcmunfor.Text = xmlnode("emit")("enderEmit")("cMun").InnerText
            End If
            If Not xmlnode("emit")("enderEmit")("cPais") Is Nothing Then
                txtcodpaisfor.Text = xmlnode("emit")("enderEmit")("cPais").InnerText
            End If
            mskcepfor.Text = xmlnode("emit")("enderEmit")("CEP").InnerText

            If Not xmlnode("emit")("enderEmit")("fone") Is Nothing Then
                mskfonefor.Text = Format(Convert.ToDouble(xmlnode("emit")("enderEmit")("fone").InnerText), "##########")
                mskfonefor.Mask = "(00) 0000-0000"
            End If


            If mskcnpjfor.Text = "10.962.965/0001-19" Then
                txtemailfor.Text = "Supermercadodoka@gmail.com"
            End If

            If importar_xml = True Then
                If verificar_regexiste("select * from cliente where cnpjcpf_cli = '" & mskcnpjfor.Text & "'") = 0 Then
                    Button3.Visible = True
                    MsgBox("Fornecedor não cadastrado no Sistema ?", MsgBoxStyle.Exclamation, "Aviso !")
                    TabControl_nfe.SelectTab(Tab_emi_dest)
                End If

                pitens.Visible = False
                dgvgrid_xml.Location = New System.Drawing.Point(2, 1)
                dgvgrid_xml.Height = 450

            End If
            '---------------------------------------fecha dados do fornecedor-----------------------------------------------


            '---------------------------------------Abre dados do Destinatario---------------------------------------------
            If Not xmlnode("dest") Is Nothing Then

                If Not xmlnode("dest")("xFant") Is Nothing Then
                    txtnomefandest.Text = xmlnode("dest")("xFant").InnerText
                End If
                If Not xmlnode("dest")("CNPJ") Is Nothing Then
                    mskcnpjdest.Mask = "00,000,000/0000-00"
                    mskcnpjdest.Text = xmlnode("dest")("CNPJ").InnerText
                End If

                If Not xmlnode("dest")("CPF") Is Nothing Then
                    mskcnpjdest.Mask = "000,000,000-00"
                    mskcnpjdest.Text = xmlnode("dest")("CPF").InnerText
                End If
                If Not xmlnode("dest")("enderDest")("xPais") Is Nothing Then
                    txtpaisdest.Text = xmlnode("dest")("enderDest")("xPais").InnerText
                End If
                If Not xmlnode("dest")("email") Is Nothing Then
                    txtemaildest.Text = xmlnode("dest")("email").InnerText
                End If
                If Not xmlnode("dest")("enderDest")("cMun") Is Nothing Then
                    txtcmundest.Text = xmlnode("dest")("enderDest")("cMun").InnerText
                End If
                If Not xmlnode("dest")("enderDest")("cPais") Is Nothing Then
                    txtcodpaisdest.Text = xmlnode("dest")("enderDest")("cPais").InnerText
                End If

                If Not xmlnode("dest")("enderDest")("fone") Is Nothing Then
                    mskfonedest.Text = Format(Convert.ToDouble(xmlnode("dest")("enderDest")("fone").InnerText), "##########")
                    mskfonedest.Mask = "(00) 0000-0000"
                End If

                If Not xmlnode("dest")("xNome") Is Nothing Then
                    txtnomedest.Text = xmlnode("dest")("xNome").InnerText
                End If

                If Not xmlnode("dest")("enderDest")("xLgr") Is Nothing Then
                    txtenddest.Text = xmlnode("dest")("enderDest")("xLgr").InnerText
                End If

                If Not xmlnode("dest")("enderDest")("nro") Is Nothing Then
                    txtnumerodest.Text = xmlnode("dest")("enderDest")("nro").InnerText
                End If

                If Not xmlnode("dest")("IE") Is Nothing Then
                    txtiedest.Text = xmlnode("dest")("IE").InnerText
                End If

                If Not xmlnode("dest")("indIEDest") Is Nothing Then
                    txtindIEDest.Text = xmlnode("dest")("indIEDest").InnerText
                End If

                If Not xmlnode("dest")("enderDest")("xBairro") Is Nothing Then
                    txtbairrodest.Text = xmlnode("dest")("enderDest")("xBairro").InnerText
                End If

                If Not xmlnode("dest")("enderDest")("xMun") Is Nothing Then
                    txtcidadedest.Text = xmlnode("dest")("enderDest")("xMun").InnerText
                End If

                If Not xmlnode("dest")("enderDest")("CEP") Is Nothing Then
                    mskcepdest.Text = xmlnode("dest")("enderDest")("CEP").InnerText
                    mskcepdest.Mask = "00,000-000"
                End If

                If Not xmlnode("dest")("enderDest")("UF") Is Nothing Then
                    txtufdest.Text = xmlnode("dest")("enderDest")("UF").InnerText
                End If

            End If
            ' mskcnpjdest.Mask = "00,000,000/0000-00"
            '--------------------------------fecha dados do destinatario---------------------------------------------


            '--------------------------------Abre dados do Cabeçalho da Nfe--------------------------------------------

            If Not xmlnode("ide")("dEmi") Is Nothing Then
                '  data_emissao = xmlnode("infNFe")("ide")("dhEmi").InnerText
                txtdataemissao.Text = Convert.ToDateTime(xmlnode("ide")("dEmi").InnerText).ToString("dd/MM/yyyy HH:mm:ss")
            End If

            If Not xmlnode("ide")("dhEmi") Is Nothing Then
                '  data_emissao = xmlnode("infNFe")("ide")("dhEmi").InnerText
                txtdataemissao.Text = Convert.ToDateTime(xmlnode("ide")("dhEmi").InnerText).ToString("dd/MM/yyyy HH:mm:ss")
            End If


            txtnumeronfe.Text = xmlnode("ide")("nNF").InnerText
            txtserienfe.Text = xmlnode("ide")("serie").InnerText
            txtmodnfe.Text = xmlnode("ide")("mod").InnerText
            cbonat.Text = xmlnode("ide")("natOp").InnerText

            txttpNF.Text = xmlnode("ide")("tpNF").InnerText
            txttpEmis.Text = xmlnode("ide")("tpEmis").InnerText


            If xmlnode("ide")("finNFe").InnerText.Substring(0, 1) = "1" Then
                cbofinNFe.Text = "1-NFe normal"
            End If
            If xmlnode("ide")("finNFe").InnerText.Substring(0, 1) = "2" Then
                cbofinNFe.Text = "2-NFe complementar"
            End If
            If xmlnode("ide")("finNFe").InnerText.Substring(0, 1) = "3" Then
                cbofinNFe.Text = "3-NFe de ajuste"
            End If
            If xmlnode("ide")("finNFe").InnerText.Substring(0, 1) = "4" Then
                cbofinNFe.Text = "4-Devolução/Retorno"
            End If

            If Not xmlnode("ide")("indPag") Is Nothing Then
                If xmlnode("ide")("indPag").InnerText.Substring(0, 1) = "0" Then
                    cboindPag.Text = "0-Pagamento à vista"
                End If
                If xmlnode("ide")("indPag").InnerText.Substring(0, 1) = "1" Then
                    cboindPag.Text = "1-Pagamento à prazo"
                End If
                If xmlnode("ide")("indPag").InnerText.Substring(0, 1) = "2" Then
                    cboindPag.Text = "2-Outros"
                End If
            End If



            txttpAmb.Text = xmlnode("ide")("tpAmb").InnerText
            txtprocEmi.Text = xmlnode("ide")("procEmi").InnerText
            txtverProc.Text = xmlnode("ide")("verProc").InnerText

            '''''''''''''''''''Ler tag NFref'''''''''''''''''''''''''''''''''''''''''
            If Not xmlnode("ide")("NFref") Is Nothing Then

                If Not xmlnode("ide")("NFref")("refNFe") Is Nothing Then
                    mskchvdevolucao.Text = xmlnode("ide")("NFref")("refNFe").InnerText
                End If

                If Not xmlnode("ide")("NFref")("refECF") Is Nothing Then
                    TabControl_nfe.Controls.Add(aba_Cobertura_ECF)

                    For Each InnerNode2 As XmlNode In xmlnode("ide")
                        If InnerNode2.Name = "NFref" Then

                            For Each InnerNode3 As XmlNode In InnerNode2

                                If Not InnerNode2("refECF") Is Nothing Then
                                    dgvecf.Rows.Add(InnerNode3.ChildNodes(0).ChildNodes(0).InnerText, _
                                                                                  InnerNode3.ChildNodes(1).ChildNodes(0).InnerText, _
                                                                                  InnerNode3.ChildNodes(2).ChildNodes(0).InnerText)
                                End If

                                If Not InnerNode2("refNFe") Is Nothing Then
                                    dgvnfce_cobertura.Rows.Add(InnerNode3.ChildNodes(0).InnerText)
                                End If


                            Next

                        End If
                    Next

                End If
            End If


            If Not xmlnode("ide")("indFinal") Is Nothing Then
                cboindFinal.SelectedIndex = xmlnode("ide")("indFinal").InnerText
            End If

            If Not xmlnode("ide")("indPres") Is Nothing Then
                If xmlnode("ide")("indPres").InnerText = "9" Then
                    cboindPres.Text = "9-Não presencial, outros"
                ElseIf xmlnode("ide")("indPres").InnerText = "0" Then
                    cboindPres.Text = "0-Não se aplica (ex.: Nota Fiscal complementar ou de ajuste)"
                ElseIf xmlnode("ide")("indPres").InnerText = "1" Then
                    cboindPres.Text = "1-Operação presencial"
                ElseIf xmlnode("ide")("indPres").InnerText = "2" Then
                    cboindPres.Text = "2-Não presencial, internet"
                ElseIf xmlnode("ide")("indPres").InnerText = "3" Then
                    cboindPres.Text = "3-Não presencial, teleatendimento"
                ElseIf xmlnode("ide")("indPres").InnerText = "4" Then
                    cboindPres.Text = "4-NFC-e entrega em domicílio"
                    ' Else
                    ' cboindPres.SelectedIndex = xmlnode("infNFe")("ide")("indPres").InnerText
                End If
            End If

            If Not xmlnode("ide")("dhSaiEnt") Is Nothing Then

                txtdsaida.Text = Convert.ToDateTime(xmlnode("ide")("dhSaiEnt").InnerText).ToString("dd/MM/yyyy HH:mm:ss")

            End If

            If Not xmlnode("ide")("dSaiEnt") Is Nothing Then

                txtdsaida.Text = Convert.ToDateTime(xmlnode("ide")("dSaiEnt").InnerText).ToString("dd/MM/yyyy HH:mm:ss")

            End If



            If Not xmlnode("infAdic") Is Nothing Then

                If Not xmlnode("infAdic")("infAdFisco") Is Nothing Then
                    '  txtinfcompl.Width = 536
                    ' lbladifisco.Visible = True
                    '  txtadifisco.Visible = True
                    txtadifisco.Text = xmlnode("infAdic")("infAdFisco").InnerText
                End If

                If Not xmlnode("infAdic")("infCpl") Is Nothing Then
                    '  If txtadifisco.Text = "" Then
                    'lbladifisco.Visible = False
                    '   txtadifisco.Visible = False
                    '     txtinfcompl.Width = 967
                    ' End If
                    txtinfcompl.Text = xmlnode("infAdic")("infCpl").InnerText
                End If

            End If

            '----------------------------------Fecha dados do cabeçalho da nfe-------------------------------------------


            '----------------------------------Abre aba de Valores da Nfe------------------------------------------------
            If Not xmlnode("dest") Is Nothing Then
                uf = xmlnode("dest")("enderDest")("UF").InnerText
            End If

            txtvlrtotalbaseicms_nfe.Text = xmlnode("total")("ICMSTot")("vBC").InnerText.Replace(".", ",")
            txtvlrtotalicms_nfe.Text = xmlnode("total")("ICMSTot")("vICMS").InnerText.Replace(".", ",")
            txtvlrtotalbasest_nfe.Text = xmlnode("total")("ICMSTot")("vBCST").InnerText.Replace(".", ",")
            txtvlrtotalst_nfe.Text = xmlnode("total")("ICMSTot")("vST").InnerText.Replace(".", ",")
            txtvlrtotaldesc_nfe.Text = xmlnode("total")("ICMSTot")("vDesc").InnerText.Replace(".", ",")
            txtvlrtotalfrete_nfe.Text = xmlnode("total")("ICMSTot")("vFrete").InnerText.Replace(".", ",")
            txtvlrtotalpis_nfe.Text = xmlnode("total")("ICMSTot")("vPIS").InnerText.Replace(".", ",")
            txtvlrtotalcofins_nfe.Text = xmlnode("total")("ICMSTot")("vCOFINS").InnerText.Replace(".", ",")
            txtvrltotalipi_nfe.Text = xmlnode("total")("ICMSTot")("vIPI").InnerText.Replace(".", ",")
            txtvlrtotalprod_nfe.Text = xmlnode("total")("ICMSTot")("vProd").InnerText.Replace(".", ",")
            txtvlrtotalseg_nfe.Text = xmlnode("total")("ICMSTot")("vSeg").InnerText.Replace(".", ",")
            txtvlrtotaloutras_nfe.Text = xmlnode("total")("ICMSTot")("vOutro").InnerText.Replace(".", ",")
            txtvlrtotal_nfe.Text = xmlnode("total")("ICMSTot")("vNF").InnerText.Replace(".", ",")
            txtvlrtotal_nfe.Text = xmlnode("total")("ICMSTot")("vNF").InnerText.Replace(".", ",")
            If Not xmlnode("total")("ICMSTot")("vTotTrib") Is Nothing Then
                txtvlrtotalaproxtrib.Text = xmlnode("total")("ICMSTot")("vTotTrib").InnerText.Replace(".", ",")
            End If
            If Not xmlnode("total")("ICMSTot")("vFCPUFDest") Is Nothing Then
                txtvlrtotalvFCPUFDest.Text = xmlnode("total")("ICMSTot")("vFCPUFDest").InnerText.Replace(".", ",")
            End If
            If Not xmlnode("total")("ICMSTot")("vICMSUFDest") Is Nothing Then
                txtvlrtotalvICMSUFDest.Text = xmlnode("total")("ICMSTot")("vICMSUFDest").InnerText.Replace(".", ",")
            End If
            If Not xmlnode("total")("ICMSTot")("vICMSUFRemet") Is Nothing Then
                txtvlrtotalvICMSUFRemet.Text = xmlnode("total")("ICMSTot")("vICMSUFRemet").InnerText.Replace(".", ",")
            End If
            If Not xmlnode("total")("ICMSTot")("vFCPST") Is Nothing Then
                txtvlrfemst.Text = xmlnode("total")("ICMSTot")("vFCPST").InnerText.Replace(".", ",")
            End If

            '----------------------------------fecha aba Valores da NFe------------------------------------------------------
        Next
        ' Me.Width = 1010
        ' Me.Height = 630
    End Sub

    Private Sub fatura()
        Dim parcela As Integer
        Dim datavenc As Date
        Dim nduplicata As Integer = 0
        dgvfatura.Rows.Clear()

        Dim xmlnode As System.Xml.XmlNode
        Dim xmllist As System.Xml.XmlNodeList

        xmllist = xmldoc.GetElementsByTagName("dup")

        parcela = "0"
        For Each xmlnode In xmllist

            parcela += 1
            datavenc = xmlnode("dVenc").InnerText

            If Not xmlnode("nDup") Is Nothing Then
                dgvfatura.Rows.Add(parcela, xmlnode("nDup").InnerText.Replace(".", ","), xmlnode("vDup").InnerText.Replace(".", ","), datavenc.ToString("dd/MM/yyyy"))

            Else
                dgvfatura.Rows.Add(parcela, parcela, xmlnode("vDup").InnerText.Replace(".", ","), datavenc.ToString("dd/MM/yyyy"))

            End If

        Next



    End Sub

    Private Sub dadostrasp()
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode

        xmllist = xmldoc.GetElementsByTagName("infNFe")

        For Each xmlnode In xmllist
            System.Diagnostics.Debug.WriteLine(xmlnode.InnerText)

            If Not xmlnode("transp")("modFrete") Is Nothing Then
                txtfretecont.Text = xmlnode("transp")("modFrete").InnerText
            End If

            If Not xmlnode("transp")("vol") Is Nothing Then
                If Not xmlnode("transp")("vol")("qVol") Is Nothing Then
                    txtQvol.Text = xmlnode("transp")("vol")("qVol").InnerText
                End If
                If Not xmlnode("transp")("vol")("esp") Is Nothing Then
                    txtesp.Text = xmlnode("transp")("vol")("esp").InnerText
                End If
                If Not xmlnode("transp")("vol")("marca") Is Nothing Then
                    txtmarca.Text = xmlnode("transp")("vol")("marca").InnerText
                End If

                If Not xmlnode("transp")("vol")("nVol") Is Nothing Then
                    txtnvol.Text = xmlnode("transp")("vol")("nVol").InnerText
                End If

                If Not xmlnode("transp")("vol")("pesoB") Is Nothing Then
                    txtpesob.Text = xmlnode("transp")("vol")("pesoB").InnerText.Replace(".", ",")
                End If
                If Not xmlnode("transp")("vol")("pesoL") Is Nothing Then
                    txtpesol.Text = xmlnode("transp")("vol")("pesoL").InnerText.Replace(".", ",")
                End If
            End If

            If Not xmlnode("transp")("transporta") Is Nothing Then

                If Not xmlnode("transp")("transporta")("CNPJ") Is Nothing Then
                    mskcnpjtrp.Mask = "00,000,000/0000-00"
                    mskcnpjtrp.Text = xmlnode("transp")("transporta")("CNPJ").InnerText

                End If
                If Not xmlnode("transp")("transporta")("CPF") Is Nothing Then
                    mskcnpjtrp.Mask = "000,000,000-00"
                    mskcnpjtrp.Text = xmlnode("transp")("transporta")("CPF").InnerText

                End If
                If Not xmlnode("transp")("transporta")("xNome") Is Nothing Then
                    txtnometrp.Text = xmlnode("transp")("transporta")("xNome").InnerText
                End If
                If Not xmlnode("transp")("transporta")("Bairro") Is Nothing Then
                    txtbairrotrp.Text = xmlnode("transp")("transporta")("Bairro").InnerText
                End If
                If Not xmlnode("transp")("transporta")("xEnder") Is Nothing Then
                    txtendtrp.Text = xmlnode("transp")("transporta")("xEnder").InnerText
                End If
                If Not xmlnode("transp")("transporta")("IE") Is Nothing Then
                    txtietrp.Text = xmlnode("transp")("transporta")("IE").InnerText
                End If
                If Not xmlnode("transp")("transporta")("xMun") Is Nothing Then
                    txtcidadetrp.Text = xmlnode("transp")("transporta")("xMun").InnerText
                End If
                If Not xmlnode("transp")("transporta")("UF") Is Nothing Then
                    txtuftrp.Text = xmlnode("transp")("transporta")("UF").InnerText
                End If


                If Not xmlnode("transp")("veicTransp") Is Nothing Then
                    If Not xmlnode("transp")("veicTransp")("placa") Is Nothing Then
                        txtplacatrp.Text = xmlnode("transp")("veicTransp")("placa").InnerText
                    End If

                    If Not xmlnode("transp")("veicTransp")("UF") Is Nothing Then
                        txtufplacatrp.Text = xmlnode("transp")("veicTransp")("UF").InnerText
                    End If

                    If Not xmlnode("transp")("veicTransp")("RNTC") Is Nothing Then
                        txtantt.Text = xmlnode("transp")("veicTransp")("RNTC").InnerText
                    End If
                End If

            End If
        Next
    End Sub

    Private Sub itens_nfe()
        Dim i As Integer
        Dim datavmed As Date
        Dim xmlList As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode

        xmlList = xmldoc.GetElementsByTagName("det")

        dgvgrid_xml.Rows.Clear()



        chklote.Checked = False

        For Each xmlnode In xmlList
            limpar_itens()

            Try
                txtcodfor_item.Text = xmlnode("prod")("cProd").InnerText.Replace("-", "")

                txtcodfor_item.Text = xmlnode("prod")("cProd").InnerText.TrimStart("0")

            Catch ex As Exception
                txtcodfor_item.Text = xmlnode("prod")("cProd").InnerText
            End Try

            txtnr.Text = xmlnode.Attributes.ItemOf("nItem").InnerText

            txtdesc_item.Text = xmlnode("prod")("xProd").InnerText
            txtvlrunit_item.Text = format_val_mysql_ret(xmlnode("prod")("vUnCom").InnerText)
            txtqtde_item.Text = xmlnode("prod")("qCom").InnerText
            txtqtdecx_item.Text = "1"
            txtvlrtotal_item.Text = format_val_mysql_ret(xmlnode("prod")("vProd").InnerText)
            txtncm_item.Text = xmlnode("prod")("NCM").InnerText

            If Not xmlnode("prod")("CEST") Is Nothing Then
                txtcest_item.Text = xmlnode("prod")("CEST").InnerText
            End If

            If Not xmlnode("prod")("EXTIPI") Is Nothing Then
                txtncmex_item.Text = xmlnode("prod")("EXTIPI").InnerText
            End If

            txtun_item.Text = xmlnode("prod")("uCom").InnerText

            If optean.Checked = True Then
                txtcodbarra_item.Text = xmlnode("prod")("cEAN").InnerText
            Else
                txtcodbarra_item.Text = xmlnode("prod")("cEANTrib").InnerText
            End If
            txtcfop_item.Text = xmlnode("prod")("CFOP").InnerText

            If xmlnode("imposto")("ICMS").ChildNodes.Item(0).ChildNodes.Item(1).Name = "CSOSN" Then
                lbltagcst.Text = "CSOSN"

                lbltagcst.Location = New Point(177, 31)
            Else
                lbltagcst.Text = "CST:"
                lbltagcst.Location = New Point(193, 31)
            End If

            txtcst_item.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("orig").InnerText + xmlnode("imposto")("ICMS").ChildNodes.Item(0).ChildNodes.Item(1).InnerText

            If Not xmlnode("prod")("vDesc") Is Nothing Then
                txtvlrdesc_item.Text = format_val_mysql_ret(xmlnode("prod")("vDesc").InnerText)
            End If

            If Not xmlnode("prod")("vFrete") Is Nothing Then
                txtvlrfrete_item.Text = format_val_mysql_ret(xmlnode("prod")("vFrete").InnerText)
            End If

            If Not xmlnode("prod")("vOutro") Is Nothing Then
                txtvlroutros_item.Text = format_val_mysql_ret(xmlnode("prod")("vOutro").InnerText)
            End If

            If Not xmlnode("prod")("med") Is Nothing Then
                chklote.Checked = True
                txtlote_item.Text = xmlnode("prod")("med")("nLote").InnerText
            End If

            If Not xmlnode("prod")("med") Is Nothing Then
                txtpmc_item.Text = format_val_mysql_ret(xmlnode("prod")("med")("vPMC").InnerText)
            End If

            If Not xmlnode("prod")("med") Is Nothing Then
                datavmed = xmlnode("prod")("med")("dVal").InnerText
                mskdvenc_item.Text = datavmed.ToString("dd/MM/yyyy")
            End If

            If Not xmlnode("prod")("Med") Is Nothing Then
                mskdvenc_item.Text = Convert.ToDateTime(xmlnode("Prod")("Med")("dVal").InnerText).ToString("dd/MM/yyyy")
                txtlote_item.Text = xmlnode("prod")("Med")("nLote").InnerText
            End If

            If Not xmlnode("prod")("rastro") Is Nothing Then
                mskdvenc_item.Text = Convert.ToDateTime(xmlnode("prod")("rastro")("dVal").InnerText).ToString("dd/MM/yyyy")
                txtlote_item.Text = xmlnode("prod")("rastro")("nLote").InnerText
            End If

            If Not xmlnode("imposto")("vTotTrib") Is Nothing Then
                txtvlrtrib_item.Text = format_val_mysql_ret(xmlnode("imposto")("vTotTrib").InnerText)
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vICMSST") Is Nothing Then
                txtvlrst_item.Text = format_val_mysql_ret(xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vICMSST").InnerText)
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vFCPST") Is Nothing Then
                txtvlrfcpst_item.Text = format_val_mysql_ret(xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vFCPST").InnerText)
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vICMSSTRet") Is Nothing Then
                txtvlrst_item.Text = format_val_mysql_ret(xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vICMSSTRet").InnerText)
                ' txtvlrstprod.Text = "0,00"
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vBCSTRet") Is Nothing Then
                txtbasest_item.Text = format_val_mysql_ret(xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vBCSTRet").InnerText)
                '  txtbasestprod.Text = "0,00"
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vBCST") Is Nothing Then
                txtbasest_item.Text = format_val_mysql_ret(xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vBCST").InnerText)
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vICMSST") Is Nothing Then
                txtvlrst_item.Text = format_val_mysql_ret(xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vICMSST").InnerText)
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vBCST") Is Nothing Then
                txtbst.Text = format_val_mysql_ret(xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vBCST").InnerText)
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pICMSST") Is Nothing Then
                ' txtaliqst.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pICMSST").InnerText
                txtaliqst_item.Text = format_val_mysql_ret(xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pICMSST").InnerText)
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pMVAST") Is Nothing Then
                txtmva_item.Text = format_val_mysql_ret(xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pMVAST").InnerText)
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pICMS") Is Nothing Then
                '  txtaliqicmsprod.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pICMS").InnerText
                txtaliqicms_item.Text = format_val_mysql_ret(xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pICMS").InnerText)
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vICMS") Is Nothing Then
                txtvlricms_item.Text = format_val_mysql_ret(xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vICMS").InnerText)
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pCredSN") Is Nothing Then
                txtaliqicms_item.Text = format_val_mysql_ret(xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pCredSN").InnerText)
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vCredICMSSN") Is Nothing Then
                txtvlricms_item.Text = format_val_mysql_ret(xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vCredICMSSN").InnerText)
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vBC") Is Nothing Then
                txtbaseicms_item.Text = format_val_mysql_ret(xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vBC").InnerText)
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pRedBC") Is Nothing Then
                txtbaseredicms_item.Text = format_val_mysql_ret(xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pRedBC").InnerText)
            End If

            If Not xmlnode("imposto")("ICMS")("ICMS20") Is Nothing Then
                txtbaseredicms_item.Text = format_val_mysql_ret(xmlnode("imposto")("ICMS")("ICMS20")("pRedBC").InnerText)
            End If


            If Not xmlnode("imposto")("PIS") Is Nothing Then

                If Not xmlnode("imposto")("PIS") Is Nothing Then
                    txtcstpis_item.Text = xmlnode("imposto")("PIS").ChildNodes.Item(0).ChildNodes.Item(0).InnerText
                    txtcstcofins_item.Text = xmlnode("imposto")("COFINS").ChildNodes.Item(0).ChildNodes.Item(0).InnerText
                End If


                If Not xmlnode("imposto")("PIS").ChildNodes.Item(0).ChildNodes.Item(2) Is Nothing Then
                    txtaliqpis_item.Text = format_val_mysql_ret(xmlnode("imposto")("PIS").ChildNodes.Item(0).ChildNodes.Item(2).InnerText)
                End If

                If Not xmlnode("imposto")("PIS").ChildNodes.Item(0)("vPIS") Is Nothing Then
                    txtvlrpis_item.Text = format_val_mysql_ret(xmlnode("imposto")("PIS").ChildNodes.Item(0)("vPIS").InnerText)
                End If


                If Not xmlnode("imposto")("PISST") Is Nothing Then
                    txtaliqpis_item.Text = format_val_mysql_ret(xmlnode("imposto")("PISST")("pPIS").InnerText)
                End If

                If Not xmlnode("imposto")("PISST") Is Nothing Then
                    txtvlrpis_item.Text = format_val_mysql_ret(xmlnode("imposto")("PISST")("vPIS").InnerText)
                End If

                If Not xmlnode("imposto")("COFINSST") Is Nothing Then
                    txtaliqcofins_item.Text = format_val_mysql_ret(xmlnode("imposto")("COFINSST")("pCOFINS").InnerText)
                End If

                If Not xmlnode("imposto")("COFINSST") Is Nothing Then
                    txtvlrcofins_item.Text = format_val_mysql_ret(xmlnode("imposto")("COFINSST")("vCOFINS").InnerText)
                End If



                If Not xmlnode("imposto")("COFINS").ChildNodes.Item(0).ChildNodes.Item(2) Is Nothing Then
                    txtaliqcofins_item.Text = format_val_mysql_ret(xmlnode("imposto")("COFINS").ChildNodes.Item(0).ChildNodes.Item(2).InnerText)
                End If

                If Not xmlnode("imposto")("COFINS").ChildNodes.Item(0)("vCOFINS") Is Nothing Then
                    txtvlrcofins_item.Text = format_val_mysql_ret(xmlnode("imposto")("COFINS").ChildNodes.Item(0)("vCOFINS").InnerText)
                End If


            End If



            If Not xmlnode("imposto")("IPI") Is Nothing Then
                If Not xmlnode("imposto")("IPI").ChildNodes.Item(1)("vIPI") Is Nothing Then
                    txtvlripi_item.Text = format_val_mysql_ret(xmlnode("imposto")("IPI").ChildNodes.Item(1)("vIPI").InnerText)
                End If
                If Not xmlnode("imposto")("IPI").ChildNodes.Item(1)("pIPI") Is Nothing Then
                    txtaliqIPI_item.Text = format_val_mysql_ret(xmlnode("imposto")("IPI").ChildNodes.Item(1)("pIPI").InnerText)
                End If
                If Not xmlnode("imposto")("IPI").ChildNodes.Item(1)("CST") Is Nothing Then
                    txtcstipi_item.Text = xmlnode("imposto")("IPI").ChildNodes.Item(1)("CST").InnerText
                End If
            End If

            If Not xmlnode("imposto")("IPI") Is Nothing Then
                If Not xmlnode("imposto")("IPI")("IPITrib") Is Nothing Then
                    If Not xmlnode("imposto")("IPI")("IPITrib")("vIPI") Is Nothing Then
                        txtvlripi_item.Text = format_val_mysql_ret(xmlnode("imposto")("IPI")("IPITrib")("vIPI").InnerText)
                    End If
                    If Not xmlnode("imposto")("IPI")("IPITrib")("pIPI") Is Nothing Then
                        txtaliqIPI_item.Text = format_val_mysql_ret(xmlnode("imposto")("IPI")("IPITrib")("pIPI").InnerText)
                    End If
                    If Not xmlnode("imposto")("IPI")("IPITrib")("CST") Is Nothing Then
                        txtcstipi_item.Text = xmlnode("imposto")("IPI")("IPITrib")("CST").InnerText
                    End If
                End If
            End If

            If Not xmlnode("infAdProd") Is Nothing Then
                txtinfoadic_item.Text = xmlnode("infAdProd").InnerText
            End If

            ''''''''''Calcular valor final produto
            txtvlrfinal_prod_item.Text = (CDec(txtvlrtotal_item.Text) - CDec(txtvlrdesc_item.Text)) + CDec(txtvlrst_item.Text) + CDec(txtvlroutros_item.Text) + CDec(txtvlrfrete_item.Text) + CDec(txtvlripi_item.Text) + CDec(txtvlrfcpst_item.Text)
            txtvlrfinal_prod_item.Text = format_val_mysql_ret(txtvlrfinal_prod_item.Text)

            adiciona_iten_grid()

        Next


        limpar_itens()


        If importar_xml = True Then
            verifica_cadprod()
        End If


    End Sub


#End Region


#Region "''''Rotina limpa controles"

    Public Sub limpar_itens()



        txtnr.Clear()
        txtqtdecx_item.ReadOnly = True

        txtvBCUFDest_item.Text = valor_campo_vazio()
        txtpFCPUFDest_item.Text = valor_campo_vazio()
        txtpICMSUFDest_item.Text = valor_campo_vazio()
        txtpICMSInter_item.Text = valor_campo_vazio()
        txtvlrdificms_item.Text = valor_campo_vazio()
        txtvlrfinal_prod_item.Text = valor_campo_vazio()

        txtvlrfcpst_item.Text = valor_campo_vazio()
        txtbaseredicmsst_item.Text = valor_campo_vazio()

        txtpICMSInterPart_item.Text = valor_campo_vazio()
        txtvFCPUFDest_item.Text = valor_campo_vazio()
        txtvICMSUFRemet_item.Text = valor_campo_vazio()
        txtvICMSUFDest_item.Text = valor_campo_vazio()

        txtvlrtrib_item.Text = valor_campo_vazio()

        txtbst.Text = valor_campo_vazio()

        txtbaseicms_item.Text = valor_campo_vazio()

        txtdesc_item.Clear()

        txtvlrfrete_item.Text = valor_campo_vazio()

        txtcodbarra_item.Clear()

        txtcodfor_item.Clear()

        txtvlrunit_item.Text = valor_campo_vazio()

        txtvlroutros_item.Text = valor_campo_vazio()

        txtqtde_item.Clear()

        If inclusao = False Then
            txtcfop_item.Text = ""
        End If

        txtncmex_item.Clear()

        txtcst_item.Clear()

        txtbaseredicms_item.Text = valor_campo_vazio()

        txtvlrdesc_item.Text = valor_campo_vazio()

        txtcstpis_item.Clear()

        txtaliqpis_item.Text = valor_campo_vazio()

        txtvlrpis_item.Text = valor_campo_vazio()

        txtcstcofins_item.Clear()

        txtaliqcofins_item.Text = valor_campo_vazio()

        txtvlrcofins_item.Text = valor_campo_vazio()

        txtncm_item.Clear()

        txtcest_item.Clear()

        txtun_item.Clear()

        txtmva_item.Text = valor_campo_vazio()

        txtaliqIPI_item.Text = valor_campo_vazio()

        txtvlrst_item.Text = valor_campo_vazio()

        txtaliqst_item.Text = valor_campo_vazio()

        txtlote_item.Clear()

        txtaliqicms_item.Text = valor_campo_vazio()

        txtvlricms_item.Text = valor_campo_vazio()

        mskdvenc_item.Clear()

        txtcstipi_item.Clear()

        txtvlripi_item.Text = valor_campo_vazio()

        txtvlrtotal_item.Text = valor_campo_vazio()

        txtpmc_item.Text = valor_campo_vazio()

        txtbasest_item.Text = valor_campo_vazio()

        txtinfoadic_item.Clear()

    End Sub

    Private Sub limpar_abas()
        txtprotocolocanc.Clear()

        txtqrcodenfce.Clear()
        txtxmotivocanc.Clear()
        txtemaildest.Clear()
        txtantt.Clear()
        txtemailfor.Clear()
        txtnomefor.Clear()
        txtnomefanfor.Clear()
        txtiefor.Clear()
        txtendfor.Clear()
        txtbairrofor.Clear()

        txtcidadefor.Clear()
        mskcnpjfor.Clear()
        txtuffor.Clear()
        mskcepfor.Clear()
        txtpaisfor.Clear()
        txtcodpaisfor.Clear()
        txtcmunfor.Clear()
        mskfonefor.Clear()
        txtcnae.Clear()
        txtnumerodest.Clear()
        txtnumerofor.Clear()
        txtim.Clear()
        txtinscst.Clear()
        txtregime.Clear()

        txtnomedest.Clear()
        txtnomefandest.Clear()
        mskcnpjdest.Clear()
        txtiedest.Clear()
        txtenddest.Clear()
        txtbairrodest.Clear()
        txtcidadedest.Clear()
        txtufdest.Clear()
        mskcepdest.Clear()
        txtcodpaisdest.Clear()
        txtidDest.Clear()
        txtpaisdest.Clear()
        txtcmundest.Clear()
        mskfonedest.Clear()
        txtemaildest.Clear()
        txtadifisco.Clear()

        txtnometrp.Clear()
        mskcnpjtrp.Clear()
        txtietrp.Clear()
        txtplacatrp.Clear()
        txtufplacatrp.Clear()
        txtendtrp.Clear()
        txtbairrotrp.Clear()
        txtcidadetrp.Clear()
        txtuftrp.Clear()
    End Sub

    Private Sub limpa_nfe()
        msknprot.Clear()

        txtvlrtotalvFCPUFDest.Text = valor_campo_vazio()
        txtvlrtotalvICMSUFDest.Text = valor_campo_vazio()
        txtvlrtotalvICMSUFRemet.Text = valor_campo_vazio()
        txtvlrfemst.Text = valor_campo_vazio()

        txttpEmis.Clear()
        txtcoduf.Clear()

        txttpNF.Clear()

        txttpAmb.Clear()
        txtprocEmi.Clear()
        txtverProc.Clear()
        txtdepc.Clear()
        txtinfcompl.Clear()
        dgvfatura.Rows.Clear()
        txtnumeronfe.Clear()
        txtidDest.Clear()
        txtserienfe.Clear()
        txtmodnfe.Clear()
        txtdataemissao.Clear()
        txtdsaida.Text = Now.ToString("dd/MM/yyyy HH:mm:ss")
        cbonat.Text = ""
        mskchave.Clear()

        txtcfop_item.Text = ""

        mskchave_cont.Clear()

        txtprotocolo.Clear()
        txtxmotivo.Clear()
        txtQvol.Clear()
        txtesp.Clear()
        txtmarca.Clear()
        txtpesob.Clear()
        txtnvol.Clear()
        txtpesol.Clear()
        txtfretecont.Text = valor_campo_vazio()
        txtvlrtotalprod_nfe.Text = valor_campo_vazio()
        txtvlrtotal_nfe.Text = valor_campo_vazio()
        txtvlrtotalbaseicms_nfe.Text = valor_campo_vazio()
        txtvlrtotalicms_nfe.Text = valor_campo_vazio()
        txtvlrtotalbasest_nfe.Text = valor_campo_vazio()
        txtvlrtotalst_nfe.Text = valor_campo_vazio()
        txtvrltotalipi_nfe.Text = valor_campo_vazio()
        txtvlrtotalaproxtrib.Text = valor_campo_vazio()
        txtvlrtotalpis_nfe.Text = valor_campo_vazio()
        txtvlrtotalcofins_nfe.Text = valor_campo_vazio()
        txtvlrtotaldesc_nfe.Text = valor_campo_vazio()
        txtvlrtotalfrete_nfe.Text = valor_campo_vazio()
        txtvlrtotalseg_nfe.Text = valor_campo_vazio()
        txtvlrtotaloutras_nfe.Text = valor_campo_vazio()
        dgvecf.Rows.Clear()
        dgvnfce_cobertura.Rows.Clear()
        TabControl_nfe.Controls.Remove(aba_Cobertura_ECF)
    End Sub

    Private Sub limpardup()
        txtndup1.Clear()
        txtndup2.Clear()
        txtndup3.Clear()
        txtndup4.Clear()
        txtndup5.Clear()
        txtndup6.Clear()

        txtddup1.Clear()
        txtddup2.Clear()
        txtddup3.Clear()
        txtddup4.Clear()
        txtddup5.Clear()
        txtddup6.Clear()

        txtvdup1.Clear()
        txtvdup2.Clear()
        txtvdup3.Clear()
        txtvdup4.Clear()
        txtvdup5.Clear()
        txtvdup6.Clear()
        dgvfatura.Rows.Clear()
    End Sub

#End Region





#Region "''''Rotina para gera criar o danfe da Nfe"

    Public Sub daNFCeRED(ByVal dados As String)
        Dim xmllist As System.Xml.XmlNodeList
        Dim InnerNode2 As XmlNode
        Dim IDanfe As New Nfe_DanfeRetratoNFCereduzido

        Dim Coutros As New Nfe_DanfeRetratoNFCereduzido.Doutros
        ' Coutros.emailfor = txtemailfor.Text
        '  Coutros.numero_epec = txtdepc.Text
        ' Coutros.protocolocanc = txtprotocolocanc.Text
        '  Path.GetExtension(TesteCaminho)

        Coutros.caminho_logo = Application.StartupPath & "\logonfe.png"


        ''''''''''''QRCode''''''''''''''''''''
        Dim picImagem As New PictureBox
        Dim qrencod As New QRCodeEncoder()
        Dim qrcode As Bitmap = qrencod.Encode(txtqrcodenfce.Text)

        picImagem.Image = TryCast(qrcode, Image)
        picImagem.Image.Save(Application.StartupPath & "\logonfecod.bmp")



        Coutros.caminho_QRCode = Application.StartupPath & "\logonfecod.bmp"

        xmldoc.LoadXml(dados)


        xmllist = xmldoc.GetElementsByTagName("emit")
        Dim CEmitente As Nfe_DanfeRetratoNFCereduzido.DEmitente_Retrato = Nothing
        For Each InnerNode2 In xmllist

            CEmitente.NOME = InnerNode2("xNome").InnerText
            CEmitente.MUNICIPIO = InnerNode2("enderEmit")("xMun").InnerText & " - " & InnerNode2("enderEmit")("UF").InnerText
            CEmitente.UF = InnerNode2("enderEmit")("UF").InnerText

            Dim comp As String
            If Not InnerNode2("enderEmit")("xCpl") Is Nothing Then
                comp = InnerNode2("enderEmit")("xCpl").InnerText
            End If
            CEmitente.ENDERECO_COMPLETO = InnerNode2("enderEmit")("xLgr").InnerText & ", " & InnerNode2("enderEmit")("nro").InnerText & " " & comp

            CEmitente.BAIRRO = InnerNode2("enderEmit")("xBairro").InnerText

            Dim cnpjd As String
            If Not InnerNode2("CNPJ") Is Nothing Then
                cnpjd = InnerNode2("CNPJ").InnerText
            End If
            If Not InnerNode2("CPF") Is Nothing Then
                cnpjd = InnerNode2("CPF").InnerText
            End If

            CEmitente.CNPJ = FormatarCpfCnpj(cnpjd)

            CEmitente.CEP = FormatarCpfCnpj(InnerNode2("enderEmit")("CEP").InnerText)

            If Not InnerNode2("enderEmit")("fone") Is Nothing Then
                CEmitente.TELEFONE = FormatarCpfCnpj(InnerNode2("enderEmit")("fone").InnerText)
            End If

            CEmitente.IE = InnerNode2("IE").InnerText
            If Not InnerNode2("IEST") Is Nothing Then
                CEmitente.IESUBS = InnerNode2("IEST").InnerText
            End If

        Next


        xmllist = xmldoc.GetElementsByTagName("dest")
        Dim CDestinatario As Nfe_DanfeRetratoNFCereduzido.DDestinatario_Retrato = Nothing
        For Each InnerNode2 In xmllist

            Dim cnpjd As String
            If Not InnerNode2("CNPJ") Is Nothing Then
                cnpjd = InnerNode2("CNPJ").InnerText
            End If
            If Not InnerNode2("CPF") Is Nothing Then
                cnpjd = InnerNode2("CPF").InnerText
            End If

            CDestinatario.NOME = InnerNode2("xNome").InnerText

            CDestinatario.CNPJ = FormatarCpfCnpj(cnpjd)

            If Not InnerNode2("enderDest")("CEP") Is Nothing Then
                CDestinatario.CEP = FormatarCpfCnpj(InnerNode2("enderDest")("CEP").InnerText)
            End If
            If Not InnerNode2("enderDest")("fone") Is Nothing Then
                CDestinatario.TELEFONE = FormatarCpfCnpj(InnerNode2("enderDest")("fone").InnerText)
            End If

            CDestinatario.ENDERECO = InnerNode2("enderDest")("xLgr").InnerText & " " & InnerNode2("enderDest")("nro").InnerText
            CDestinatario.BAIRRO = InnerNode2("enderDest")("xBairro").InnerText
            CDestinatario.IE = InnerNode2("IE").InnerText

            If Not InnerNode2("indIEDest") Is Nothing Then
                CDestinatario.IE_IND = InnerNode2("indIEDest").InnerText
            End If
            CDestinatario.UF = InnerNode2("enderDest")("UF").InnerText
            CDestinatario.MUNICIPIO = InnerNode2("enderDest")("xMun").InnerText

        Next

        Dim CDataHora As Nfe_DanfeRetratoNFCereduzido.DDataeHora_Retrato = Nothing
        Dim CDadosNF As New Nfe_DanfeRetratoNFCereduzido.DDadosNfe_Retrato
        CDadosNF.IMP_DV = "SIM"

        xmllist = xmldoc.GetElementsByTagName("infNFe")
        ' Dim InnerNode2 As XmlNode
        For Each InnerNode2 In xmllist

            CDadosNF.CHAVEACESSO_NFE = InnerNode2.Attributes.ItemOf("Id").InnerText.Substring(3, 44)

        Next

        xmllist = xmldoc.GetElementsByTagName("infNFeSupl")
        For Each InnerNode In xmllist
            CDadosNF.QRcodevlr = InnerNode("qrCode").InnerText
        Next

        xmllist = xmldoc.GetElementsByTagName("ide")
        For Each InnerNode2 In xmllist
            CDadosNF.NUMERO_NFE = InnerNode2("cNF").InnerText
            CDadosNF.SERIE_NFE = InnerNode2("serie").InnerText
            CDadosNF.NATUREZA_NFE = InnerNode2("natOp").InnerText



            If Not InnerNode2("dEmi") Is Nothing Then
                CDataHora.DATA_EMISSAO = InnerNode2("dEmi").InnerText
            End If
            If Not InnerNode2("dhEmi") Is Nothing Then
                CDataHora.DATA_EMISSAO = InnerNode2("dhEmi").InnerText
            End If
            If Not InnerNode2("dSaiEnt") Is Nothing Then
                CDataHora.DATA_ENTRADA_SAIDA = InnerNode2("dSaiEnt").InnerText
            End If

            If Not InnerNode2("xJust") Is Nothing Then
                CDadosNF.xJust = InnerNode2("xJust").InnerText
            End If
            If Not InnerNode2("dhCont") Is Nothing Then
                CDadosNF.DHCONT = InnerNode2("dhCont").InnerText
            End If

            If InnerNode2("tpNF").InnerText = 1 Then
                CDadosNF.TIPONOTA_NFE = Nfe_DanfeRetratoNFCereduzido.TipoNota_Retrato.SAIDA
            Else
                CDadosNF.TIPONOTA_NFE = Nfe_DanfeRetratoNFCereduzido.TipoNota_Retrato.ENTRADA
            End If
        Next

        xmllist = xmldoc.GetElementsByTagName("infProt")
        For Each InnerNode2 In xmllist
            CDadosNF.PROTOCOLO_NFE = InnerNode2("nProt").InnerText
            CDadosNF.DHRECBTO_NFE = Convert.ToDateTime(InnerNode2("dhRecbto").InnerText).ToString("dd/MM/yyyy HH:mm:ss")
        Next


        Dim CTransportadora As Nfe_DanfeRetratoNFCereduzido.DTransportadora_Retrato = Nothing
        xmllist = xmldoc.GetElementsByTagName("transporta")
        For Each InnerNode2 In xmllist

            Dim cnpjp As String
            If Not InnerNode2("CNPJ") Is Nothing Then
                cnpjp = InnerNode2("CNPJ").InnerText
            End If
            If Not InnerNode2("CPF") Is Nothing Then
                cnpjp = InnerNode2("CPF").InnerText
            End If
            CTransportadora.CNPJ = cnpjp
            If Not InnerNode2("xNome") Is Nothing Then
                CTransportadora.NOME = InnerNode2("xNome").InnerText
            End If
            If Not InnerNode2("xEnder") Is Nothing Then
                CTransportadora.ENDERECO = InnerNode2("xEnder").InnerText
            End If
            If Not InnerNode2("xMun") Is Nothing Then
                CTransportadora.MUNICIPIO = InnerNode2("xMun").InnerText
            End If
            If Not InnerNode2("UF") Is Nothing Then
                CTransportadora.UF = InnerNode2("UF").InnerText
            End If
            If Not InnerNode2("IE") Is Nothing Then
                CTransportadora.MUNICIPIO = InnerNode2("IE").InnerText
            End If
        Next

        xmllist = xmldoc.GetElementsByTagName("VeicTransp")
        For Each InnerNode2 In xmllist
            If Not InnerNode2("RNTC") Is Nothing Then
                CTransportadora.CODIGO_ANTT = InnerNode2("RNTC").InnerText
            End If
            If Not InnerNode2("placa") Is Nothing Then
                CTransportadora.PLACA_VEICULO = InnerNode2("placa").InnerText
            End If
            If Not InnerNode2("UF") Is Nothing Then
                CTransportadora.UF_PLACA = InnerNode2("UF").InnerText
            End If
        Next

        xmllist = xmldoc.GetElementsByTagName("Vol")
        For Each InnerNode2 In xmllist
            If Not InnerNode2("esp") Is Nothing Then
                CTransportadora.ESPECIE = InnerNode2("esp").InnerText
            End If
            If Not InnerNode2("marca") Is Nothing Then
                CTransportadora.MARCA = InnerNode2("marca").InnerText
            End If
            If Not InnerNode2("nVol") Is Nothing Then
                CTransportadora.NUMERO = InnerNode2("nVol").InnerText
            End If

            If Not InnerNode2("pesoB") Is Nothing Then
                CTransportadora.PESOBRUTO = InnerNode2("pesoB").InnerText
            End If
            If Not InnerNode2("pesoB") Is Nothing Then
                CTransportadora.PESOLIQUIDO = InnerNode2("pesoB").InnerText
            End If
            If Not InnerNode2("qVol") Is Nothing Then
                CTransportadora.QUANTIDADE = InnerNode2("qVol").InnerText
            End If
        Next

        xmllist = xmldoc.GetElementsByTagName("transp")
        For Each InnerNode2 In xmllist
            If InnerNode2("modFrete").InnerText = 0 Then
                CTransportadora.modfrete = "(0) Emitente"
            ElseIf InnerNode2("modFrete").InnerText = 1 Then
                CTransportadora.modfrete = "(1) Dest/Rem"
            ElseIf InnerNode2("modFrete").InnerText = 2 Then
                CTransportadora.modfrete = "(2) Terseiros"
            ElseIf InnerNode2("modFrete").InnerText = 9 Then
                CTransportadora.modfrete = "(9) Sem frete"
            End If
        Next


        xmllist = xmldoc.GetElementsByTagName("ICMSTot")
        Dim CValores As Nfe_DanfeRetratoNFCereduzido.DValores_Retrato = Nothing
        For Each InnerNode2 In xmllist

            CValores.BASE_CALCULO_ICMS = formata_valor_campo(InnerNode2("vBC").InnerText)
            CValores.BASE_CALCULO_ICMS_SUBS = formata_valor_campo(InnerNode2("vBCST").InnerText)
            CValores.DESCONTO = formata_valor_campo(InnerNode2("vDesc").InnerText)
            CValores.OUTRAS_DESPESAS = formata_valor_campo(InnerNode2("vOutro").InnerText)
            CValores.VALOR_FRETE = formata_valor_campo(InnerNode2("vFrete").InnerText)
            CValores.VALOR_ICMS = formata_valor_campo(InnerNode2("vICMS").InnerText)
            CValores.VALOR_ICMS_SUBS = formata_valor_campo(InnerNode2("vST").InnerText)
            CValores.VALOR_IPI = formata_valor_campo(InnerNode2("vIPI").InnerText)
            CValores.VALOR_PIS = formata_valor_campo(InnerNode2("vPIS").InnerText)
            CValores.VALOR_COFINS = formata_valor_campo(InnerNode2("vCOFINS").InnerText)
            CValores.VALOR_SEGURO = formata_valor_campo(InnerNode2("vSeg").InnerText)
            CValores.VALOR_TOTAL_NOTA = formata_valor_campo(InnerNode2("vNF").InnerText)
            CValores.VALOR_TOTAL_PRODUTOS = formata_valor_campo(InnerNode2("vProd").InnerText)
            If Not InnerNode2("vTotTrib") Is Nothing Then
                CValores.VALOR_TOTALTRIB = formata_valor_campo(InnerNode2("vTotTrib").InnerText)
            End If

        Next



        Dim CISSQN As Nfe_DanfeRetratoNFCereduzido.DISSQN_Retrato = Nothing
        CISSQN.BASE_CALCULO_ISSQN = ""
        CISSQN.IM = ""
        CISSQN.VALOR_TOTAL_SERVICOS = ""
        CISSQN.VALOR_ISSQN = ""




        'PEGA CLASSE PARA PREENCHER OS PRODUTOS
        xmllist = xmldoc.GetElementsByTagName("det")
        Dim PROD As ProdutoDanfe_Retrato

        For Each InnerNode2 In xmllist
            PROD = New ProdutoDanfe_Retrato

            Try

                If InnerNode2("prod")("cProd").InnerText.Length > 13 Then
                    PROD.DCodigoProd = InnerNode2("prod")("cProd").InnerText.ToString.Substring(InnerNode2("prod")("cProd").InnerText.Length - 13, 13)
                Else
                    PROD.DCodigoProd = InnerNode2("prod")("cProd").InnerText
                End If

            Catch ex As Exception
                PROD.DCodigoProd = InnerNode2("prod")("cProd").InnerText
            End Try


            PROD.DCodigoBARRA = InnerNode2("prod")("cEANTrib").InnerText
            PROD.DDescricao = InnerNode2("prod")("xProd").InnerText
            If PROD.DNCM = InnerNode2("prod")("NCM").InnerText.Length < "8" Then
                PROD.DNCM = InnerNode2("prod")("NCM").InnerText.ToString.Substring(0, 8)
            Else
                PROD.DNCM = InnerNode2("prod")("NCM").InnerText
            End If


            PROD.DCFOP = InnerNode2("prod")("CFOP").InnerText

            PROD.DUNID = InnerNode2("prod")("uCom").InnerText
            PROD.DQT = Decimal.Parse(InnerNode2("prod")("qCom").InnerText.ToString.Replace(".", ",")).ToString("0.000")
            PROD.DVALORUNI = formata_valor_campo_4c(InnerNode2("prod")("vUnCom").InnerText)
            PROD.DVALORTOTAL = formata_valor_campo(InnerNode2("prod")("vProd").InnerText)



            If Not InnerNode2("imposto")("vTotTrib") Is Nothing Then
                PROD.DVALOR_TRIB_ITEM = formata_valor_campo(InnerNode2("imposto")("vTotTrib").InnerText)
            End If
            PROD.DCST = InnerNode2("imposto")("ICMS").ChildNodes(0)("orig").InnerText & InnerNode2("imposto")("ICMS").ChildNodes(0)("CST").InnerText

            Try

                If Not InnerNode2("imposto")("ICMS")("ICMS20") Is Nothing Then

                    PROD.DBCALC_ICMS = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS20")("vBC").InnerText)
                    PROD.DVALORICMS = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS20")("vICMS").InnerText)
                    PROD.DALIQUOTAICMS = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS20")("pICMS").InnerText)

                End If

                If Not InnerNode2("imposto")("ICMS")("ICMS00") Is Nothing Then

                    PROD.DBCALC_ICMS = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS00")("vBC").InnerText)
                    PROD.DVALORICMS = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS00")("vICMS").InnerText)
                    PROD.DALIQUOTAICMS = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS00")("pICMS").InnerText)

                End If

                If Not InnerNode2("imposto")("ICMS")("ICMS70") Is Nothing Then

                    PROD.DBCALC_ICMS_ST = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS70")("vBCST").InnerText)
                    PROD.DVALORICMS_ST = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS70")("vICMSST").InnerText)
                    PROD.DALIQUOTAICMS = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS70")("pICMS").InnerText)
                End If

                If Not InnerNode2("imposto")("ICMS")("ICMS10") Is Nothing Then

                    PROD.DBCALC_ICMS_ST = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS10")("vBCST").InnerText)
                    PROD.DVALORICMS_ST = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS10")("vICMSST").InnerText)
                    PROD.DALIQUOTAICMS = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS10")("pICMS").InnerText)

                End If

                If Not InnerNode2("imposto")("ICMS")("ICMSSN201") Is Nothing Then

                    PROD.DBCALC_ICMS_ST = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMSSN201")("vBCST").InnerText)
                    PROD.DVALORICMS_ST = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMSSN201")("vICMSST").InnerText)
                    PROD.DALIQUOTAICMS = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMSSN201")("pICMSST").InnerText)

                End If

                If Not InnerNode2("imposto")("ICMS")("ICMSSN202") Is Nothing Then

                    PROD.DBCALC_ICMS_ST = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMSSN202")("vBCST").InnerText)
                    PROD.DVALORICMS_ST = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMSSN202")("vICMSST").InnerText)
                    PROD.DALIQUOTAICMS = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMSSN202")("pICMSST").InnerText)

                End If



                If Not InnerNode2("imposto")("IPI") Is Nothing Then
                    If Not InnerNode2("imposto")("IPI")("IPITrib") Is Nothing Then
                        PROD.DVALORIPI = formata_valor_campo(InnerNode2("imposto")("IPI")("IPITrib")("vIPI").InnerText)
                        PROD.DALIQUOTAIPI = formata_valor_campo(InnerNode2("imposto")("IPI")("IPITrib")("pIPI").InnerText)
                    End If

                Else
                    PROD.DVALORIPI = ""
                    PROD.DALIQUOTAIPI = ""
                End If

            Catch ex As Exception

            End Try

            If Not InnerNode2("prod")("Med") Is Nothing Then
                PROD.DLOTE = InnerNode2("Prod")("Med")("nLote").InnerText
                PROD.LinhaProd.Add("Lote: " & InnerNode2("prod")("Med")("nLote").InnerText & " Qtd: " & Decimal.Parse(InnerNode2("prod")("Med")("qLote").InnerText).ToString("#.##"))
            End If
            If Not InnerNode2("prod")("rastro") Is Nothing Then
                PROD.DLOTE = InnerNode2("Prod")("rastro")("nLote").InnerText
                PROD.LinhaProd.Add("Lote: " & InnerNode2("prod")("rastro")("nLote").InnerText & " Qtd: " & Decimal.Parse(InnerNode2("prod")("rastro")("qLote").InnerText).ToString("#.##"))
            End If

            'ADICIONA PRODUTOS NA DANFE
            IDanfe.AddProdutosDanfe.Add(PROD)
        Next




        Try

            xmllist = xmldoc.GetElementsByTagName("dup")
            Dim fat As FaturaDanfe_Retrato
            For Each InnerNode2 In xmllist
                fat = New FaturaDanfe_Retrato
                fat.DNumero = InnerNode2("nDup").InnerText
                fat.Dvalor = InnerNode2("vDup").InnerText
                fat.Dvenc = InnerNode2("dVenc").InnerText

                IDanfe.AddfaturaDanfe.Add(fat)
            Next


        Catch ex As Exception

        End Try




        Dim CFaturamento_Retrato As Nfe_DanfeRetratoNFCereduzido.DFaturamento_Retrato = Nothing

        Dim CINFO As Nfe_DanfeRetratoNFCereduzido.DINFOCOMPLEMENTAR_Retrato = Nothing


        Dim vp As String, vb As String
        xmllist = xmldoc.GetElementsByTagName("infAdic")
        For Each InnerNode2 In xmllist

            If Not InnerNode2("infCpl") Is Nothing Then
                vp = InnerNode2("infCpl").InnerText
            End If
            If Not InnerNode2("infAdFisco") Is Nothing Then
                vb = InnerNode2("infAdFisco").InnerText
            End If
            CINFO.DADOSADIC = vp + vbCrLf + vb
        Next


        IDanfe.Faturamento = CFaturamento_Retrato
        IDanfe.Identificacao_Emitente = CEmitente
        IDanfe.Identificacao_Destinatario = CDestinatario
        IDanfe.Data_Hora = CDataHora
        IDanfe.Valores_Nota = CValores
        IDanfe.Identificacao_Transportadora = CTransportadora
        IDanfe.Valores_ISSQN = CISSQN
        IDanfe.InformacoesComplementares = CINFO
        IDanfe.Dados_Nfe = CDadosNF

        IDanfe.Dados_outros = Coutros


        IDanfe.VisualizarImpressao()



    End Sub

    Public Sub daNFCe(ByVal dados As String)
        Dim xmllist As System.Xml.XmlNodeList
        Dim InnerNode2 As XmlNode
        Dim IDanfe As New Nfe_ImprimirDanfeRetratoNFCe

        Dim Coutros As New Nfe_ImprimirDanfeRetratoNFCe.Doutros
        ' Coutros.emailfor = txtemailfor.Text
        '  Coutros.numero_epec = txtdepc.Text
        ' Coutros.protocolocanc = txtprotocolocanc.Text
        '  Path.GetExtension(TesteCaminho)

        Coutros.caminho_logo = Application.StartupPath & "\logonfe.png"


        ''''''''''''QRCode''''''''''''''''''''
        Dim picImagem As New PictureBox
        Dim qrencod As New QRCodeEncoder()
        Dim qrcode As Bitmap = qrencod.Encode(txtqrcodenfce.Text)

        picImagem.Image = TryCast(qrcode, Image)
        picImagem.Image.Save(Application.StartupPath & "\logonfecod.bmp")



        Coutros.caminho_QRCode = Application.StartupPath & "\logonfecod.bmp"

        xmldoc.LoadXml(dados)


        xmllist = xmldoc.GetElementsByTagName("emit")
        Dim CEmitente As Nfe_ImprimirDanfeRetratoNFCe.DEmitente_Retrato = Nothing
        For Each InnerNode2 In xmllist

            CEmitente.NOME = InnerNode2("xNome").InnerText
            CEmitente.MUNICIPIO = InnerNode2("enderEmit")("xMun").InnerText & "/" & InnerNode2("enderEmit")("UF").InnerText
            CEmitente.UF = InnerNode2("enderEmit")("UF").InnerText

            Dim comp As String
            If Not InnerNode2("enderEmit")("xCpl") Is Nothing Then
                comp = InnerNode2("enderEmit")("xCpl").InnerText
            End If
            CEmitente.ENDERECO_COMPLETO = InnerNode2("enderEmit")("xLgr").InnerText & ", " & InnerNode2("enderEmit")("nro").InnerText & " " & comp

            CEmitente.BAIRRO = InnerNode2("enderEmit")("xBairro").InnerText

            Dim cnpjd As String
            If Not InnerNode2("CNPJ") Is Nothing Then
                cnpjd = InnerNode2("CNPJ").InnerText
            End If
            If Not InnerNode2("CPF") Is Nothing Then
                cnpjd = InnerNode2("CPF").InnerText
            End If

            CEmitente.CNPJ = FormatarCpfCnpj(cnpjd)

            CEmitente.CEP = FormatarCpfCnpj(InnerNode2("enderEmit")("CEP").InnerText)

            If Not InnerNode2("enderEmit")("fone") Is Nothing Then
                CEmitente.TELEFONE = FormatarCpfCnpj(InnerNode2("enderEmit")("fone").InnerText)
            End If

            CEmitente.IE = InnerNode2("IE").InnerText
            If Not InnerNode2("IEST") Is Nothing Then
                CEmitente.IESUBS = InnerNode2("IEST").InnerText
            End If

        Next


        xmllist = xmldoc.GetElementsByTagName("dest")
        Dim CDestinatario As Nfe_ImprimirDanfeRetratoNFCe.DDestinatario_Retrato = Nothing
        For Each InnerNode2 In xmllist

            Dim cnpjd As String
            If Not InnerNode2("CNPJ") Is Nothing Then
                cnpjd = InnerNode2("CNPJ").InnerText
            End If
            If Not InnerNode2("CPF") Is Nothing Then
                cnpjd = InnerNode2("CPF").InnerText
            End If

            CDestinatario.NOME = InnerNode2("xNome").InnerText

            CDestinatario.CNPJ = FormatarCpfCnpj(cnpjd)

            If Not InnerNode2("enderDest")("CEP") Is Nothing Then
                CDestinatario.CEP = FormatarCpfCnpj(InnerNode2("enderDest")("CEP").InnerText)
            End If
            If Not InnerNode2("enderDest")("fone") Is Nothing Then
                CDestinatario.TELEFONE = FormatarCpfCnpj(InnerNode2("enderDest")("fone").InnerText)
            End If

            CDestinatario.ENDERECO = InnerNode2("enderDest")("xLgr").InnerText & " " & InnerNode2("enderDest")("nro").InnerText
            CDestinatario.BAIRRO = InnerNode2("enderDest")("xBairro").InnerText
            CDestinatario.IE = InnerNode2("IE").InnerText

            If Not InnerNode2("indIEDest") Is Nothing Then
                CDestinatario.IE_IND = InnerNode2("indIEDest").InnerText
            End If
            CDestinatario.UF = InnerNode2("enderDest")("UF").InnerText
            CDestinatario.MUNICIPIO = InnerNode2("enderDest")("xMun").InnerText

        Next

        Dim CDataHora As Nfe_ImprimirDanfeRetratoNFCe.DDataeHora_Retrato = Nothing
        Dim CDadosNF As New Nfe_ImprimirDanfeRetratoNFCe.DDadosNfe_Retrato
        CDadosNF.IMP_DV = "SIM"

        xmllist = xmldoc.GetElementsByTagName("infNFe")
        ' Dim InnerNode2 As XmlNode
        For Each InnerNode2 In xmllist

            CDadosNF.CHAVEACESSO_NFE = InnerNode2.Attributes.ItemOf("Id").InnerText.Substring(3, 44)

        Next

        xmllist = xmldoc.GetElementsByTagName("infNFeSupl")
        For Each InnerNode In xmllist
            CDadosNF.QRcodevlr = InnerNode("qrCode").InnerText
        Next

        xmllist = xmldoc.GetElementsByTagName("ide")
        For Each InnerNode2 In xmllist
            CDadosNF.NUMERO_NFE = InnerNode2("cNF").InnerText
            CDadosNF.SERIE_NFE = InnerNode2("serie").InnerText
            CDadosNF.NATUREZA_NFE = InnerNode2("natOp").InnerText



            If Not InnerNode2("dEmi") Is Nothing Then
                CDataHora.DATA_EMISSAO = InnerNode2("dEmi").InnerText
            End If
            If Not InnerNode2("dhEmi") Is Nothing Then
                CDataHora.DATA_EMISSAO = InnerNode2("dhEmi").InnerText
            End If
            If Not InnerNode2("dSaiEnt") Is Nothing Then
                CDataHora.DATA_ENTRADA_SAIDA = InnerNode2("dSaiEnt").InnerText
            End If
            If Not InnerNode2("dhSaiEnt") Is Nothing Then
                CDataHora.DATA_ENTRADA_SAIDA = InnerNode2("dhSaiEnt").InnerText
            End If

            If Not InnerNode2("xJust") Is Nothing Then
                CDadosNF.xJust = InnerNode2("xJust").InnerText
            End If
            If Not InnerNode2("dhCont") Is Nothing Then
                CDadosNF.DHCONT = InnerNode2("dhCont").InnerText
            End If

            If InnerNode2("tpNF").InnerText = 1 Then
                CDadosNF.TIPONOTA_NFE = Nfe_ImprimirDanfeRetratoNFCe.TipoNota_Retrato.SAIDA
            Else
                CDadosNF.TIPONOTA_NFE = Nfe_ImprimirDanfeRetratoNFCe.TipoNota_Retrato.ENTRADA
            End If
        Next

        xmllist = xmldoc.GetElementsByTagName("infProt")
        For Each InnerNode2 In xmllist
            CDadosNF.PROTOCOLO_NFE = InnerNode2("nProt").InnerText
            CDadosNF.DHRECBTO_NFE = Convert.ToDateTime(InnerNode2("dhRecbto").InnerText).ToString("dd/MM/yyyy HH:mm:ss")
        Next


        Dim CTransportadora As Nfe_ImprimirDanfeRetratoNFCe.DTransportadora_Retrato = Nothing
        xmllist = xmldoc.GetElementsByTagName("transporta")
        For Each InnerNode2 In xmllist

            Dim cnpjp As String
            If Not InnerNode2("CNPJ") Is Nothing Then
                cnpjp = InnerNode2("CNPJ").InnerText
            End If
            If Not InnerNode2("CPF") Is Nothing Then
                cnpjp = InnerNode2("CPF").InnerText
            End If
            CTransportadora.CNPJ = cnpjp
            If Not InnerNode2("xNome") Is Nothing Then
                CTransportadora.NOME = InnerNode2("xNome").InnerText
            End If
            If Not InnerNode2("xEnder") Is Nothing Then
                CTransportadora.ENDERECO = InnerNode2("xEnder").InnerText
            End If
            If Not InnerNode2("xMun") Is Nothing Then
                CTransportadora.MUNICIPIO = InnerNode2("xMun").InnerText
            End If
            If Not InnerNode2("UF") Is Nothing Then
                CTransportadora.UF = InnerNode2("UF").InnerText
            End If
            If Not InnerNode2("IE") Is Nothing Then
                CTransportadora.MUNICIPIO = InnerNode2("IE").InnerText
            End If
        Next

        xmllist = xmldoc.GetElementsByTagName("VeicTransp")
        For Each InnerNode2 In xmllist
            If Not InnerNode2("RNTC") Is Nothing Then
                CTransportadora.CODIGO_ANTT = InnerNode2("RNTC").InnerText
            End If
            If Not InnerNode2("placa") Is Nothing Then
                CTransportadora.PLACA_VEICULO = InnerNode2("placa").InnerText
            End If
            If Not InnerNode2("UF") Is Nothing Then
                CTransportadora.UF_PLACA = InnerNode2("UF").InnerText
            End If
        Next

        xmllist = xmldoc.GetElementsByTagName("Vol")
        For Each InnerNode2 In xmllist
            If Not InnerNode2("esp") Is Nothing Then
                CTransportadora.ESPECIE = InnerNode2("esp").InnerText
            End If
            If Not InnerNode2("marca") Is Nothing Then
                CTransportadora.MARCA = InnerNode2("marca").InnerText
            End If
            If Not InnerNode2("nVol") Is Nothing Then
                CTransportadora.NUMERO = InnerNode2("nVol").InnerText
            End If

            If Not InnerNode2("pesoB") Is Nothing Then
                CTransportadora.PESOBRUTO = InnerNode2("pesoB").InnerText
            End If
            If Not InnerNode2("pesoB") Is Nothing Then
                CTransportadora.PESOLIQUIDO = InnerNode2("pesoB").InnerText
            End If
            If Not InnerNode2("qVol") Is Nothing Then
                CTransportadora.QUANTIDADE = InnerNode2("qVol").InnerText
            End If
        Next

        xmllist = xmldoc.GetElementsByTagName("transp")
        For Each InnerNode2 In xmllist
            If InnerNode2("modFrete").InnerText = 0 Then
                CTransportadora.modfrete = "(0) Emitente"
            ElseIf InnerNode2("modFrete").InnerText = 1 Then
                CTransportadora.modfrete = "(1) Dest/Rem"
            ElseIf InnerNode2("modFrete").InnerText = 2 Then
                CTransportadora.modfrete = "(2) Terseiros"
            ElseIf InnerNode2("modFrete").InnerText = 9 Then
                CTransportadora.modfrete = "(9) Sem frete"
            End If
        Next


        xmllist = xmldoc.GetElementsByTagName("ICMSTot")
        Dim CValores As Nfe_ImprimirDanfeRetratoNFCe.DValores_Retrato = Nothing
        For Each InnerNode2 In xmllist

            CValores.BASE_CALCULO_ICMS = format_val_mysql_ret(InnerNode2("vBC").InnerText)
            CValores.BASE_CALCULO_ICMS_SUBS = format_val_mysql_ret(InnerNode2("vBCST").InnerText)
            CValores.DESCONTO = format_val_mysql_ret(InnerNode2("vDesc").InnerText)
            CValores.OUTRAS_DESPESAS = format_val_mysql_ret(InnerNode2("vOutro").InnerText)
            CValores.VALOR_FRETE = format_val_mysql_ret(InnerNode2("vFrete").InnerText)
            CValores.VALOR_ICMS = format_val_mysql_ret(InnerNode2("vICMS").InnerText)
            CValores.VALOR_ICMS_SUBS = format_val_mysql_ret(InnerNode2("vST").InnerText)
            CValores.VALOR_IPI = format_val_mysql_ret(InnerNode2("vIPI").InnerText)
            CValores.VALOR_PIS = format_val_mysql_ret(InnerNode2("vPIS").InnerText)
            CValores.VALOR_COFINS = format_val_mysql_ret(InnerNode2("vCOFINS").InnerText)
            CValores.VALOR_SEGURO = format_val_mysql_ret(InnerNode2("vSeg").InnerText)
            CValores.VALOR_TOTAL_NOTA = format_val_mysql_ret(InnerNode2("vNF").InnerText)
            CValores.VALOR_TOTAL_PRODUTOS = format_val_mysql_ret(InnerNode2("vProd").InnerText)
            If Not InnerNode2("vTotTrib") Is Nothing Then
                CValores.VALOR_TOTALTRIB = format_val_mysql_ret(InnerNode2("vTotTrib").InnerText)
            End If

        Next



        Dim CISSQN As Nfe_ImprimirDanfeRetratoNFCe.DISSQN_Retrato = Nothing
        CISSQN.BASE_CALCULO_ISSQN = ""
        CISSQN.IM = ""
        CISSQN.VALOR_TOTAL_SERVICOS = ""
        CISSQN.VALOR_ISSQN = ""




        'PEGA CLASSE PARA PREENCHER OS PRODUTOS
        xmllist = xmldoc.GetElementsByTagName("det")
        Dim PROD As ProdutoDanfe_Retrato

        For Each InnerNode2 In xmllist
            PROD = New ProdutoDanfe_Retrato

            Try

                If InnerNode2("prod")("cProd").InnerText.Length > 13 Then
                    PROD.DCodigoProd = InnerNode2("prod")("cProd").InnerText.ToString.Substring(InnerNode2("prod")("cProd").InnerText.Length - 13, 13)
                Else
                    PROD.DCodigoProd = InnerNode2("prod")("cProd").InnerText
                End If

            Catch ex As Exception
                PROD.DCodigoProd = InnerNode2("prod")("cProd").InnerText
            End Try


            PROD.DCodigoBARRA = InnerNode2("prod")("cEANTrib").InnerText
            PROD.DDescricao = InnerNode2("prod")("xProd").InnerText
            If PROD.DNCM = InnerNode2("prod")("NCM").InnerText.Length < "8" Then
                PROD.DNCM = InnerNode2("prod")("NCM").InnerText.ToString.Substring(0, 8)
            Else
                PROD.DNCM = InnerNode2("prod")("NCM").InnerText
            End If


            PROD.DCFOP = InnerNode2("prod")("CFOP").InnerText

            PROD.DUNID = InnerNode2("prod")("uCom").InnerText
            PROD.DQT = Decimal.Parse(InnerNode2("prod")("qCom").InnerText.ToString.Replace(".", ",")).ToString("0.000")
            PROD.DVALORUNI = format_val_mysql_ret(InnerNode2("prod")("vUnCom").InnerText)
            PROD.DVALORTOTAL = format_val_mysql_ret(InnerNode2("prod")("vProd").InnerText)



            If Not InnerNode2("imposto")("vTotTrib") Is Nothing Then
                PROD.DVALOR_TRIB_ITEM = format_val_mysql_ret(InnerNode2("imposto")("vTotTrib").InnerText)
            End If
            PROD.DCST = InnerNode2("imposto")("ICMS").ChildNodes(0)("orig").InnerText & InnerNode2("imposto")("ICMS").ChildNodes(0)("CST").InnerText

            Try

                If Not InnerNode2("imposto")("ICMS")("ICMS20") Is Nothing Then

                    PROD.DBCALC_ICMS = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS20")("vBC").InnerText)
                    PROD.DVALORICMS = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS20")("vICMS").InnerText)
                    PROD.DALIQUOTAICMS = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS20")("pICMS").InnerText)

                End If

                If Not InnerNode2("imposto")("ICMS")("ICMS00") Is Nothing Then

                    PROD.DBCALC_ICMS = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS00")("vBC").InnerText)
                    PROD.DVALORICMS = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS00")("vICMS").InnerText)
                    PROD.DALIQUOTAICMS = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS00")("pICMS").InnerText)

                End If

                If Not InnerNode2("imposto")("ICMS")("ICMS70") Is Nothing Then

                    PROD.DBCALC_ICMS_ST = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS70")("vBCST").InnerText)
                    PROD.DVALORICMS_ST = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS70")("vICMSST").InnerText)
                    PROD.DALIQUOTAICMS = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS70")("pICMS").InnerText)
                End If

                If Not InnerNode2("imposto")("ICMS")("ICMS10") Is Nothing Then

                    PROD.DBCALC_ICMS_ST = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS10")("vBCST").InnerText)
                    PROD.DVALORICMS_ST = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS10")("vICMSST").InnerText)
                    PROD.DALIQUOTAICMS = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS10")("pICMS").InnerText)

                End If

                If Not InnerNode2("imposto")("ICMS")("ICMSSN201") Is Nothing Then

                    PROD.DBCALC_ICMS_ST = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMSSN201")("vBCST").InnerText)
                    PROD.DVALORICMS_ST = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMSSN201")("vICMSST").InnerText)
                    PROD.DALIQUOTAICMS = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMSSN201")("pICMSST").InnerText)

                End If

                If Not InnerNode2("imposto")("ICMS")("ICMSSN202") Is Nothing Then

                    PROD.DBCALC_ICMS_ST = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMSSN202")("vBCST").InnerText)
                    PROD.DVALORICMS_ST = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMSSN202")("vICMSST").InnerText)
                    PROD.DALIQUOTAICMS = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMSSN202")("pICMSST").InnerText)

                End If



                If Not InnerNode2("imposto")("IPI") Is Nothing Then
                    If Not InnerNode2("imposto")("IPI")("IPITrib") Is Nothing Then
                        PROD.DVALORIPI = format_val_mysql_ret(InnerNode2("imposto")("IPI")("IPITrib")("vIPI").InnerText)
                        PROD.DALIQUOTAIPI = format_val_mysql_ret(InnerNode2("imposto")("IPI")("IPITrib")("pIPI").InnerText)
                    End If

                Else
                    PROD.DVALORIPI = ""
                    PROD.DALIQUOTAIPI = ""
                End If

            Catch ex As Exception

            End Try

            If Not InnerNode2("prod")("Med") Is Nothing Then
                PROD.DLOTE = InnerNode2("Prod")("Med")("nLote").InnerText
                PROD.LinhaProd.Add("Lote: " & InnerNode2("prod")("Med")("nLote").InnerText & " Qtd: " & Decimal.Parse(InnerNode2("prod")("Med")("qLote").InnerText).ToString("#.##"))
            End If
            If Not InnerNode2("prod")("rastro") Is Nothing Then
                PROD.DLOTE = InnerNode2("Prod")("rastro")("nLote").InnerText
                PROD.LinhaProd.Add("Lote: " & InnerNode2("prod")("rastro")("nLote").InnerText & " Qtd: " & Decimal.Parse(InnerNode2("prod")("rastro")("qLote").InnerText).ToString("#.##"))
            End If

            'ADICIONA PRODUTOS NA DANFE
            IDanfe.AddProdutosDanfe.Add(PROD)
        Next




        Try

            xmllist = xmldoc.GetElementsByTagName("dup")
            Dim fat As FaturaDanfe_Retrato
            For Each InnerNode2 In xmllist
                fat = New FaturaDanfe_Retrato
                fat.DNumero = InnerNode2("nDup").InnerText
                fat.Dvalor = InnerNode2("vDup").InnerText
                fat.Dvenc = InnerNode2("dVenc").InnerText

                IDanfe.AddfaturaDanfe.Add(fat)
            Next


        Catch ex As Exception

        End Try




        Dim CFaturamento_Retrato As Nfe_ImprimirDanfeRetratoNFCe.DFaturamento_Retrato = Nothing

        Dim CINFO As Nfe_ImprimirDanfeRetratoNFCe.DINFOCOMPLEMENTAR_Retrato = Nothing


        Dim vp As String, vb As String
        xmllist = xmldoc.GetElementsByTagName("infAdic")
        For Each InnerNode2 In xmllist

            If Not InnerNode2("infCpl") Is Nothing Then
                vp = InnerNode2("infCpl").InnerText
            End If
            If Not InnerNode2("infAdFisco") Is Nothing Then
                vb = InnerNode2("infAdFisco").InnerText
            End If
            CINFO.DADOSADIC = vp + vbCrLf + vb
        Next


        IDanfe.Faturamento = CFaturamento_Retrato
        IDanfe.Identificacao_Emitente = CEmitente
        IDanfe.Identificacao_Destinatario = CDestinatario
        IDanfe.Data_Hora = CDataHora
        IDanfe.Valores_Nota = CValores
        IDanfe.Identificacao_Transportadora = CTransportadora
        IDanfe.Valores_ISSQN = CISSQN
        IDanfe.InformacoesComplementares = CINFO
        IDanfe.Dados_Nfe = CDadosNF

        IDanfe.Dados_outros = Coutros


        IDanfe.VisualizarImpressao()



    End Sub

    Public Sub danfe(ByVal xml As String)
        Dim vlrdesc As Boolean = False
        Dim xmllist As System.Xml.XmlNodeList
        Dim InnerNode2 As XmlNode

        Dim IDanfe As New Nfe_ImprimirDanfeRetrato

        Dim Coutros As New Nfe_ImprimirDanfeRetrato.Doutros
        Coutros.emailfor = txtemailfor.Text
        Coutros.numero_epec = txtdepc.Text
        Coutros.protocolocanc = txtprotocolocanc.Text
        '  Path.GetExtension(TesteCaminho)

        Coutros.caminho_logo = Application.StartupPath & "\logonfe.png"


        ''''''''''''QRCode''''''''''''''''''''
        Dim picImagem As New PictureBox
        Dim qrencod As New QRCodeEncoder()
        Dim qrcode As Bitmap = qrencod.Encode(mskchave.Text)

        picImagem.Image = TryCast(qrcode, Image)
        picImagem.Image.Save(Application.StartupPath & "\logonfecod.bmp")



        Coutros.caminho_QRCode = Application.StartupPath & "\logonfecod.bmp"



        xmldoc.LoadXml(xml)


        xmllist = xmldoc.GetElementsByTagName("emit")
        Dim CEmitente As Nfe_ImprimirDanfeRetrato.DEmitente_Retrato = Nothing
        For Each InnerNode2 In xmllist

            CEmitente.NOME = InnerNode2("xNome").InnerText
            CEmitente.MUNICIPIO = InnerNode2("enderEmit")("xMun").InnerText & "/" & InnerNode2("enderEmit")("UF").InnerText
            CEmitente.UF = InnerNode2("enderEmit")("UF").InnerText

            Dim comp As String
            If Not InnerNode2("enderEmit")("xCpl") Is Nothing Then
                comp = InnerNode2("enderEmit")("xCpl").InnerText
            End If
            CEmitente.ENDERECO_COMPLETO = InnerNode2("enderEmit")("xLgr").InnerText & ", " & InnerNode2("enderEmit")("nro").InnerText & " " & comp

            CEmitente.BAIRRO = InnerNode2("enderEmit")("xBairro").InnerText

            Dim cnpjd As String
            If Not InnerNode2("CNPJ") Is Nothing Then
                cnpjd = InnerNode2("CNPJ").InnerText
            End If
            If Not InnerNode2("CPF") Is Nothing Then
                cnpjd = InnerNode2("CPF").InnerText
            End If

            CEmitente.CNPJ = FormatarCpfCnpj(cnpjd)

            CEmitente.CEP = FormatarCpfCnpj(InnerNode2("enderEmit")("CEP").InnerText)

            If Not InnerNode2("enderEmit")("fone") Is Nothing Then
                CEmitente.TELEFONE = FormatarCpfCnpj(InnerNode2("enderEmit")("fone").InnerText)
            End If

            CEmitente.IE = InnerNode2("IE").InnerText
            If Not InnerNode2("IEST") Is Nothing Then
                CEmitente.IESUBS = InnerNode2("IEST").InnerText
            End If

        Next


        xmllist = xmldoc.GetElementsByTagName("dest")
        Dim CDestinatario As Nfe_ImprimirDanfeRetrato.DDestinatario_Retrato = Nothing
        For Each InnerNode2 In xmllist

            Dim cnpjd As String
            If Not InnerNode2("CNPJ") Is Nothing Then
                cnpjd = InnerNode2("CNPJ").InnerText
            End If
            If Not InnerNode2("CPF") Is Nothing Then
                cnpjd = InnerNode2("CPF").InnerText
            End If

            CDestinatario.NOME = InnerNode2("xNome").InnerText

            CDestinatario.CNPJ = FormatarCpfCnpj(cnpjd)

            If Not InnerNode2("enderDest")("CEP") Is Nothing Then
                CDestinatario.CEP = FormatarCpfCnpj(InnerNode2("enderDest")("CEP").InnerText)
            End If
            If Not InnerNode2("enderDest")("fone") Is Nothing Then
                CDestinatario.TELEFONE = FormatarCpfCnpj(InnerNode2("enderDest")("fone").InnerText)
            End If

            CDestinatario.ENDERECO = InnerNode2("enderDest")("xLgr").InnerText & " " & InnerNode2("enderDest")("nro").InnerText
            CDestinatario.BAIRRO = InnerNode2("enderDest")("xBairro").InnerText
            If Not InnerNode2("IE") Is Nothing Then
                CDestinatario.IE = InnerNode2("IE").InnerText
            End If


            If Not InnerNode2("indIEDest") Is Nothing Then
                Dim ind As String
                If InnerNode2("indIEDest").InnerText = "1" Then
                    ind = "1 – Contribuinte ICMS"
                End If
                If InnerNode2("indIEDest").InnerText = "2" Then
                    ind = "2 – Contribuinte isento de inscrição"
                End If
                If InnerNode2("indIEDest").InnerText = "3" Then
                    ind = "9 – Não Contribuinte"
                End If

                CDestinatario.IE_IND = ind
            End If



            CDestinatario.UF = InnerNode2("enderDest")("UF").InnerText
            CDestinatario.MUNICIPIO = InnerNode2("enderDest")("xMun").InnerText

        Next

        Dim CDataHora As Nfe_ImprimirDanfeRetrato.DDataeHora_Retrato = Nothing
        Dim CDadosNF As New Nfe_ImprimirDanfeRetrato.DDadosNfe_Retrato
        CDadosNF.IMP_DV = "SIM"

        xmllist = xmldoc.GetElementsByTagName("infNFe")
        ' Dim InnerNode2 As XmlNode
        For Each InnerNode2 In xmllist

            CDadosNF.CHAVEACESSO_NFE = InnerNode2.Attributes.ItemOf("Id").InnerText.Substring(3, 44)

        Next

        xmllist = xmldoc.GetElementsByTagName("ide")
        For Each InnerNode2 In xmllist
            CDadosNF.NUMERO_NFE = InnerNode2("nNF").InnerText
            CDadosNF.SERIE_NFE = InnerNode2("serie").InnerText
            CDadosNF.NATUREZA_NFE = InnerNode2("natOp").InnerText



            If Not InnerNode2("dEmi") Is Nothing Then
                CDataHora.DATA_EMISSAO = InnerNode2("dEmi").InnerText
            End If
            If Not InnerNode2("dhEmi") Is Nothing Then
                CDataHora.DATA_EMISSAO = InnerNode2("dhEmi").InnerText
            End If
            If Not InnerNode2("dhSaiEnt") Is Nothing Then
                CDataHora.DATA_ENTRADA_SAIDA = InnerNode2("dhSaiEnt").InnerText
            End If
            If Not InnerNode2("dSaiEnt") Is Nothing Then
                CDataHora.DATA_ENTRADA_SAIDA = InnerNode2("dSaiEnt").InnerText
            End If

            If Not InnerNode2("xJust") Is Nothing Then
                CDadosNF.xJust = InnerNode2("xJust").InnerText
            End If
            If Not InnerNode2("dhCont") Is Nothing Then
                CDadosNF.DHCONT = InnerNode2("dhCont").InnerText
            End If

            If InnerNode2("tpNF").InnerText = 1 Then
                CDadosNF.TIPONOTA_NFE = Nfe_ImprimirDanfeRetrato.TipoNota_Retrato.SAIDA
            Else
                CDadosNF.TIPONOTA_NFE = Nfe_ImprimirDanfeRetrato.TipoNota_Retrato.ENTRADA
            End If
        Next

        xmllist = xmldoc.GetElementsByTagName("infProt")
        For Each InnerNode2 In xmllist
            CDadosNF.PROTOCOLO_NFE = InnerNode2("nProt").InnerText
            CDadosNF.DHRECBTO_NFE = Convert.ToDateTime(InnerNode2("dhRecbto").InnerText).ToString("dd/MM/yyyy HH:mm:ss")
        Next


        Dim CTransportadora As Nfe_ImprimirDanfeRetrato.DTransportadora_Retrato = Nothing
        xmllist = xmldoc.GetElementsByTagName("transporta")
        For Each InnerNode2 In xmllist

            Dim cnpjp As String
            If Not InnerNode2("CNPJ") Is Nothing Then
                cnpjp = InnerNode2("CNPJ").InnerText
            End If
            If Not InnerNode2("CPF") Is Nothing Then
                cnpjp = InnerNode2("CPF").InnerText
            End If
            CTransportadora.CNPJ = cnpjp
            If Not InnerNode2("xNome") Is Nothing Then
                CTransportadora.NOME = InnerNode2("xNome").InnerText
            End If
            If Not InnerNode2("xEnder") Is Nothing Then
                CTransportadora.ENDERECO = InnerNode2("xEnder").InnerText
            End If
            If Not InnerNode2("xMun") Is Nothing Then
                CTransportadora.MUNICIPIO = InnerNode2("xMun").InnerText
            End If
            If Not InnerNode2("UF") Is Nothing Then
                CTransportadora.UF = InnerNode2("UF").InnerText
            End If
            If Not InnerNode2("IE") Is Nothing Then
                CTransportadora.MUNICIPIO = InnerNode2("IE").InnerText
            End If
        Next

        xmllist = xmldoc.GetElementsByTagName("VeicTransp")
        For Each InnerNode2 In xmllist
            If Not InnerNode2("RNTC") Is Nothing Then
                CTransportadora.CODIGO_ANTT = InnerNode2("RNTC").InnerText
            End If
            If Not InnerNode2("placa") Is Nothing Then
                CTransportadora.PLACA_VEICULO = InnerNode2("placa").InnerText
            End If
            If Not InnerNode2("UF") Is Nothing Then
                CTransportadora.UF_PLACA = InnerNode2("UF").InnerText
            End If
        Next

        xmllist = xmldoc.GetElementsByTagName("Vol")
        For Each InnerNode2 In xmllist
            If Not InnerNode2("esp") Is Nothing Then
                CTransportadora.ESPECIE = InnerNode2("esp").InnerText
            End If
            If Not InnerNode2("marca") Is Nothing Then
                CTransportadora.MARCA = InnerNode2("marca").InnerText
            End If
            If Not InnerNode2("nVol") Is Nothing Then
                CTransportadora.NUMERO = InnerNode2("nVol").InnerText
            End If

            If Not InnerNode2("pesoB") Is Nothing Then
                CTransportadora.PESOBRUTO = InnerNode2("pesoB").InnerText
            End If
            If Not InnerNode2("pesoB") Is Nothing Then
                CTransportadora.PESOLIQUIDO = InnerNode2("pesoB").InnerText
            End If
            If Not InnerNode2("qVol") Is Nothing Then
                CTransportadora.QUANTIDADE = InnerNode2("qVol").InnerText
            End If
        Next

        xmllist = xmldoc.GetElementsByTagName("transp")
        For Each InnerNode2 In xmllist
            If InnerNode2("modFrete").InnerText = 0 Then
                CTransportadora.modfrete = "(0) Emitente"
            ElseIf InnerNode2("modFrete").InnerText = 1 Then
                CTransportadora.modfrete = "(1) Dest/Rem"
            ElseIf InnerNode2("modFrete").InnerText = 2 Then
                CTransportadora.modfrete = "(2) Terseiros"
            ElseIf InnerNode2("modFrete").InnerText = 9 Then
                CTransportadora.modfrete = "(9) Sem frete"
            End If
        Next


        xmllist = xmldoc.GetElementsByTagName("ICMSTot")
        Dim CValores As Nfe_ImprimirDanfeRetrato.DValores_Retrato = Nothing
        For Each InnerNode2 In xmllist

            CValores.BASE_CALCULO_ICMS = format_val_mysql_ret(InnerNode2("vBC").InnerText)
            CValores.BASE_CALCULO_ICMS_SUBS = format_val_mysql_ret(InnerNode2("vBCST").InnerText)
            CValores.DESCONTO = format_val_mysql_ret(InnerNode2("vDesc").InnerText)
            CValores.OUTRAS_DESPESAS = format_val_mysql_ret(InnerNode2("vOutro").InnerText)
            CValores.VALOR_FRETE = format_val_mysql_ret(InnerNode2("vFrete").InnerText)
            CValores.VALOR_ICMS = format_val_mysql_ret(InnerNode2("vICMS").InnerText)
            CValores.VALOR_ICMS_SUBS = format_val_mysql_ret(InnerNode2("vST").InnerText)
            CValores.VALOR_IPI = format_val_mysql_ret(InnerNode2("vIPI").InnerText)
            CValores.VALOR_PIS = format_val_mysql_ret(InnerNode2("vPIS").InnerText)
            CValores.VALOR_COFINS = format_val_mysql_ret(InnerNode2("vCOFINS").InnerText)
            CValores.VALOR_SEGURO = format_val_mysql_ret(InnerNode2("vSeg").InnerText)
            CValores.VALOR_TOTAL_NOTA = format_val_mysql_ret(InnerNode2("vNF").InnerText)
            CValores.VALOR_TOTAL_PRODUTOS = format_val_mysql_ret(InnerNode2("vProd").InnerText)
            If Not InnerNode2("vTotTrib") Is Nothing Then
                CValores.VALOR_TOTALTRIB = format_val_mysql_ret(InnerNode2("vTotTrib").InnerText)
            End If

        Next



        Dim CISSQN As Nfe_ImprimirDanfeRetrato.DISSQN_Retrato = Nothing
        CISSQN.BASE_CALCULO_ISSQN = ""
        CISSQN.IM = ""
        CISSQN.VALOR_TOTAL_SERVICOS = ""
        CISSQN.VALOR_ISSQN = ""



        'PEGA CLASSE PARA PREENCHER OS PRODUTOS
        xmllist = xmldoc.GetElementsByTagName("det")
        Dim PROD As ProdutoDanfe_Retrato

        For Each InnerNode2 In xmllist
            PROD = New ProdutoDanfe_Retrato

            Try

                If InnerNode2("prod")("cProd").InnerText.Length > 13 Then
                    PROD.DCodigoProd = InnerNode2("prod")("cProd").InnerText.ToString.Substring(InnerNode2("prod")("cProd").InnerText.Length - 13, 13)
                Else
                    PROD.DCodigoProd = InnerNode2("prod")("cProd").InnerText
                End If

            Catch ex As Exception
                PROD.DCodigoProd = InnerNode2("prod")("cProd").InnerText
            End Try


            PROD.DCodigoBARRA = InnerNode2("prod")("cEANTrib").InnerText
            PROD.DDescricao = InnerNode2("prod")("xProd").InnerText
            If PROD.DNCM = InnerNode2("prod")("NCM").InnerText.Length < "8" Then
                PROD.DNCM = InnerNode2("prod")("NCM").InnerText.ToString.Substring(0, 8)
            Else
                PROD.DNCM = InnerNode2("prod")("NCM").InnerText
            End If


            PROD.DCFOP = InnerNode2("prod")("CFOP").InnerText

            PROD.DUNID = InnerNode2("prod")("uCom").InnerText
            PROD.DQT = Decimal.Parse(InnerNode2("prod")("qCom").InnerText.ToString.Replace(".", ",")).ToString("0.000")
            PROD.DVALORUNI = format_val_mysql_ret(InnerNode2("prod")("vUnCom").InnerText)

            If Not InnerNode2("prod")("vDesc") Is Nothing Then
                PROD.DVALORDESC = format_val_mysql_ret(InnerNode2("prod")("vDesc").InnerText)
                vlrdesc = True
            End If
            PROD.DVALORTOTAL = format_val_mysql_ret(InnerNode2("prod")("vProd").InnerText)



            If Not InnerNode2("imposto")("vTotTrib") Is Nothing Then
                PROD.DVALOR_TRIB_ITEM = format_val_mysql_ret(InnerNode2("imposto")("vTotTrib").InnerText)
            End If
            PROD.DCST = InnerNode2("imposto")("ICMS").ChildNodes(0)("orig").InnerText & InnerNode2("imposto")("ICMS").ChildNodes(0).ChildNodes(1).InnerText

            Try

                If Not InnerNode2("imposto")("ICMS")("ICMS20") Is Nothing Then

                    PROD.DBCALC_ICMS = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS20")("vBC").InnerText)
                    PROD.DVALORICMS = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS20")("vICMS").InnerText)
                    PROD.DALIQUOTAICMS = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS20")("pICMS").InnerText)

                End If

                If Not InnerNode2("imposto")("ICMS")("ICMS00") Is Nothing Then

                    PROD.DBCALC_ICMS = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS00")("vBC").InnerText)
                    PROD.DVALORICMS = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS00")("vICMS").InnerText)
                    PROD.DALIQUOTAICMS = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS00")("pICMS").InnerText)

                End If

                If Not InnerNode2("imposto")("ICMS")("ICMS70") Is Nothing Then

                    PROD.DBCALC_ICMS_ST = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS70")("vBCST").InnerText)
                    PROD.DVALORICMS_ST = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS70")("vICMSST").InnerText)
                    PROD.DALIQUOTAICMS = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS70")("pICMS").InnerText)
                End If

                If Not InnerNode2("imposto")("ICMS")("ICMS10") Is Nothing Then

                    PROD.DBCALC_ICMS_ST = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS10")("vBCST").InnerText)
                    PROD.DVALORICMS_ST = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS10")("vICMSST").InnerText)
                    PROD.DALIQUOTAICMS = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMS10")("pICMS").InnerText)

                End If

                If Not InnerNode2("imposto")("ICMS")("ICMSSN201") Is Nothing Then

                    PROD.DBCALC_ICMS_ST = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMSSN201")("vBCST").InnerText)
                    PROD.DVALORICMS_ST = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMSSN201")("vICMSST").InnerText)
                    PROD.DALIQUOTAICMS = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMSSN201")("pICMSST").InnerText)

                End If

                If Not InnerNode2("imposto")("ICMS")("ICMSSN202") Is Nothing Then

                    PROD.DBCALC_ICMS_ST = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMSSN202")("vBCST").InnerText)
                    PROD.DVALORICMS_ST = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMSSN202")("vICMSST").InnerText)
                    PROD.DALIQUOTAICMS = format_val_mysql_ret(InnerNode2("imposto")("ICMS")("ICMSSN202")("pICMSST").InnerText)

                End If



                If Not InnerNode2("imposto")("IPI") Is Nothing Then
                    If Not InnerNode2("imposto")("IPI")("IPITrib") Is Nothing Then
                        PROD.DVALORIPI = format_val_mysql_ret(InnerNode2("imposto")("IPI")("IPITrib")("vIPI").InnerText)
                        PROD.DALIQUOTAIPI = format_val_mysql_ret(InnerNode2("imposto")("IPI")("IPITrib")("pIPI").InnerText)
                    End If

                Else
                    PROD.DVALORIPI = ""
                    PROD.DALIQUOTAIPI = ""
                End If

            Catch ex As Exception

            End Try

            If Not InnerNode2("prod")("Med") Is Nothing Then
                PROD.DLOTE = InnerNode2("Prod")("Med")("nLote").InnerText
                PROD.LinhaProd.Add("Lote: " & InnerNode2("prod")("Med")("nLote").InnerText & " Qtd: " & Decimal.Parse(InnerNode2("prod")("Med")("qLote").InnerText).ToString("#.##"))
            End If
            If Not InnerNode2("prod")("rastro") Is Nothing Then
                PROD.DLOTE = InnerNode2("prod")("rastro")("nLote").InnerText
                PROD.LinhaProd.Add("Lote: " & InnerNode2("prod")("rastro")("nLote").InnerText & " Qtd: " & Decimal.Parse(InnerNode2("prod")("rastro")("qLote").InnerText).ToString("#.##"))
            End If

            'ADICIONA PRODUTOS NA DANFE
            IDanfe.AddProdutosDanfe.Add(PROD)
        Next




        Try

            xmllist = xmldoc.GetElementsByTagName("dup")
            Dim fat As FaturaDanfe_Retrato
            For Each InnerNode2 In xmllist
                fat = New FaturaDanfe_Retrato
                fat.DNumero = InnerNode2("nDup").InnerText
                fat.Dvalor = InnerNode2("vDup").InnerText
                fat.Dvenc = InnerNode2("dVenc").InnerText

                IDanfe.AddfaturaDanfe.Add(fat)
            Next


        Catch ex As Exception

        End Try




        Dim CFaturamento_Retrato As Nfe_ImprimirDanfeRetrato.DFaturamento_Retrato = Nothing

        Dim CINFO As Nfe_ImprimirDanfeRetrato.DINFOCOMPLEMENTAR_Retrato = Nothing


        Dim vp As String, vb As String
        xmllist = xmldoc.GetElementsByTagName("infAdic")
        For Each InnerNode2 In xmllist

            If Not InnerNode2("infCpl") Is Nothing Then
                vp = InnerNode2("infCpl").InnerText
            End If
            If Not InnerNode2("infAdFisco") Is Nothing Then
                vb = InnerNode2("infAdFisco").InnerText
            End If
            CINFO.DADOSADIC = vp + vbCrLf + vb
        Next
        Coutros.vlrdesc = vlrdesc

        IDanfe.Faturamento = CFaturamento_Retrato
        IDanfe.Identificacao_Emitente = CEmitente
        IDanfe.Identificacao_Destinatario = CDestinatario
        IDanfe.Data_Hora = CDataHora
        IDanfe.Valores_Nota = CValores
        IDanfe.Identificacao_Transportadora = CTransportadora
        IDanfe.Valores_ISSQN = CISSQN
        IDanfe.InformacoesComplementares = CINFO
        IDanfe.Dados_Nfe = CDadosNF

        IDanfe.Dados_outros = Coutros


        IDanfe.VisualizarImpressao()



    End Sub

    Private Sub optvisualizar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        danfe(txtcaminhoxml.Text)

    End Sub

    Private Sub optpdf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        danfe(txtcaminhoxml.Text)

    End Sub



#End Region


#Region "''''Regras de validacao do CFOP_item e ICMS_item"
    Private Sub regua_validacao_icms()


        If txtcst_item.Text.Length = 3 Then

            If txtcst_item.Text.Substring(1, 2) = "60" Or txtcst_item.Text.Substring(1, 2) = "40" Then
                txtbaseicms_item.Text = valor_campo_vazio()
                txtvlricms_item.Text = valor_campo_vazio()
                txtaliqicms_item.Text = valor_campo_vazio()
                txtbaseredicms_item.Text = valor_campo_vazio()

                txtbasest_item.Text = valor_campo_vazio()
                txtaliqst_item.Text = valor_campo_vazio()
                txtvlrst_item.Text = valor_campo_vazio()
                txtmva_item.Text = valor_campo_vazio()
            End If

            If txtcst_item.Text.Substring(1, 2) = "00" Or txtcst_item.Text.Substring(1, 2) = "20" Then
                txtbasest_item.Text = valor_campo_vazio()
                txtaliqst_item.Text = valor_campo_vazio()
                txtvlrst_item.Text = valor_campo_vazio()
                txtmva_item.Text = valor_campo_vazio()
            End If

            If txtcst_item.Text.Substring(1, 2) = "30" Then
                txtbaseicms_item.Text = valor_campo_vazio()
                txtvlricms_item.Text = valor_campo_vazio()
                txtaliqicms_item.Text = valor_campo_vazio()
                txtbaseredicms_item.Text = valor_campo_vazio()
            End If

            If txtcst_item.Text.Substring(1, 2) = "10" Then
                txtbaseredicms_item.Text = valor_campo_vazio()
            End If

        End If

        If txtcst_item.Text.Length = 4 Then

            If txtcst_item.Text.Substring(1, 3) = "500" Or txtcst_item.Text.Substring(1, 3) = "102" Or txtcst_item.Text.Substring(1, 3) = "103" _
                Or txtcst_item.Text.Substring(1, 3) = "300" Or txtcst_item.Text.Substring(1, 3) = "400" Then

                txtbaseicms_item.Text = valor_campo_vazio()
                txtvlricms_item.Text = valor_campo_vazio()
                txtaliqicms_item.Text = valor_campo_vazio()
                txtbaseredicms_item.Text = valor_campo_vazio()

                txtbasest_item.Text = valor_campo_vazio()
                txtaliqst_item.Text = valor_campo_vazio()
                txtvlrst_item.Text = valor_campo_vazio()
                txtmva_item.Text = valor_campo_vazio()

            End If

            If txtcst_item.Text.Substring(1, 3) = "101" Then
                txtbasest_item.Text = valor_campo_vazio()
                txtaliqst_item.Text = valor_campo_vazio()
                txtvlrst_item.Text = valor_campo_vazio()
                txtmva_item.Text = valor_campo_vazio()
            End If

            If txtcst_item.Text.Substring(1, 3) = "202" Then
                txtbaseicms_item.Text = valor_campo_vazio()
                txtvlricms_item.Text = valor_campo_vazio()
                txtaliqicms_item.Text = valor_campo_vazio()
                txtbaseredicms_item.Text = valor_campo_vazio()
            End If

        End If


        ''''''''''''''''''''''''Valida campos obrigatorios
        If txtcst_item.Text.Length = 3 Then

            If txtcst_item.Text.Substring(1, 2) = "00" Then

                If txtaliqicms_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe a Aliquota de ICMS (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    txtaliqicms_item.Focus()
                End If

            End If


            If txtcst_item.Text.Substring(1, 2) = "20" Then

                If txtaliqicms_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe a Aliquota de ICMS (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    txtaliqicms_item.Focus()
                End If

                If txtbaseredicms_item = valor_campo_vazio() Then
                    MsgBox("Informe o Percentual da redução da Base do ICMS (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    txtbaseredicms_item.Focus()
                End If

            End If

            If txtcst_item.Text.Substring(1, 2) = "10" Then

                If txtaliqicms_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe a Aliquota de ICMS (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    txtaliqicms_item.Focus()
                End If

                If txtaliqst_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe a Aliquota interna do ICMS/ST (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    txtaliqst_item.Focus()
                End If

                If txtmva_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe o percentual da MVA (Obrigatorio ?)", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    txtmva_item.Focus()
                End If

                If txtbaseredicms_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe o Percentual da redução da Base do ICMS (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    txtbaseredicms_item.Focus()
                End If

            End If


            If txtcst_item.Text.Substring(1, 2) = "70" Then

                If txtaliqicms_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe a Aliquota de ICMS (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    txtaliqicms_item.Focus()
                End If

                If txtaliqst_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe a Aliquota interna do ICMS/ST (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    txtaliqst_item.Focus()
                End If

                If txtmva_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe o percentual da MVA (Obrigatorio ?)", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    txtmva_item.Focus()
                End If

                If txtbaseredicms_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe o Percentual da redução da Base do ICMS (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    txtbaseredicms_item.Focus()
                End If

                If txtbaseredicmsst_item.Text = valor_campo_vazio() Then
                    MsgBox("Informou o Percentual de Redução da Base do ICMS/ST (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    txtbaseredicmsst_item.Focus()
                End If

            End If


        End If

        '''''''''''''''''''''''''''Validacao simpre nacional
        If txtcst_item.Text.Length = 4 Then

            If txtcst_item.Text.Substring(1, 3) = "201" Or txtcst_item.Text.Substring(1, 3) = "202" Then


                If txtbaseredicmsst_item.Text = valor_campo_vazio() Then
                    MsgBox("Informou o Percentual de Redução da Base do ICMS/ST (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    txtbaseredicmsst_item.Focus()
                End If

                If txtmva_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe o percentual da MVA (Obrigatorio ?)", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    txtmva_item.Focus()
                End If

                If txtaliqst_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe a Aliquota interna do ICMS/ST (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    txtaliqst_item.Focus()
                End If

            End If




        End If

    End Sub

    Private Sub validar_item_cfop()



        erro_validacao = False

        Dim cst_calc As String

        If txtcst_item.Text <> "" Then
            If regimetrib = 3 Then
                cst_calc = txtcst_item.Text.Substring(1, 2)
            Else
                cst_calc = txtcst_item.Text.Substring(1, 3)
            End If
        Else
            cst_calc = "0"
        End If



        If cst_calc = "00" Or cst_calc = "20" Or cst_calc = "40" Or cst_calc = "51" Or cst_calc = "101" Or cst_calc = "102" Or cst_calc = "103" Or cst_calc = "300" Or cst_calc = "400" Then

            ' If txttipo.Text = "v" Then

            If txtcfop_item.Text.Substring(1, 1) <> "1" Then
                MsgBox("O CFOP de venda está incorreto, pois deve iniciar com (52) dentro do estado" & vbCrLf & "ou (62) fora do estado para produtos tributados pelo ICMS", MsgBoxStyle.Exclamation, "Regra de Validação CFOP!")
                erro_validacao = True
            End If

        End If

        '  If txttipo.Text = "d" Then

        If txtcfop_item.Text.Substring(1, 1) <> "2" Then
            MsgBox("O CFOP de Devolução está incorreto, pois deve iniciar com (52) dentro do estado" & vbCrLf & "ou (62) fora do estado para produtos tributados pelo ICMS", MsgBoxStyle.Exclamation, "Regra de Validação CFOP !")
            erro_validacao = True
        End If



        '  End If

        ' If cst_calc = "10" Or cst_calc = "30" Or cst_calc = "60" Or cst_calc = "70" Or cst_calc = "90" Or cst_calc = "500" Or cst_calc = "201" Or cst_calc = "202" Or cst_calc = "900" Then

        'If txttipo.Text = "v" Then

        If txtcfop_item.Text.Substring(1, 1) <> "4" Then
            MsgBox("O CFOP de venda ou Devolução está incorreto, pois deve iniciar com (54) dentro estado" & vbCrLf & "ou (64) fora do estado para produtos tributados pelo ICMS/ST !", MsgBoxStyle.Exclamation, "Regra de Validação CFOP !")
            erro_validacao = True
        End If

        '   End If

        ' End If

        ' End If
    End Sub

#End Region

    Private Sub imprimirDanfe()

        danfe(xmldoc.OuterXml)


    End Sub


    Public Sub carregaxml_pesquisa(ByVal xml As String)

        Try
            xmldoc.LoadXml(xml)
        Catch ex As Exception
            xmldoc.LoadXml(xml.Remove(0, 39))
        End Try

        dgvgrid_xml.Rows.Clear()
        txtprotocolocanc.Visible = False
        chave()
        dadosnfe()
        fatura()
        dadostrasp()
        itens_nfe()

        TabControl_nfe.SelectTab(TabPrincipal)


        ativa_tab()


        MsgBox("XML carregado Com sucesso !!", MsgBoxStyle.Information, "Aviso !")
    End Sub



#Region "''''Rotina para capturar os dados do certificado digital"

    Public Sub busca_certificado()

        If nfecer = "" Then
            frmcert.ShowDialog()
        Else
            certificado = SelecionarCertificado(nfecer)
        End If
    End Sub

    Public Sub carrega_dados_certificado()
        Dim lista_Tabelas As New List(Of String)

        If nfecer <> "" Then

            If CDate(certificado.NotAfter.ToString) < Now.Date Then

                Dim wD As Long = DateDiff(DateInterval.Day, CDate(certificado.NotAfter.ToString), Now.Date)

                MsgBox("Faltam " & wD.ToString & " dias para seu certificado digital vencer !", MsgBoxStyle.Exclamation, "Aviso !")
            End If

            frminfocertificado.txtdatavenc.Text = certificado.NotAfter.ToString
            frminfocertificado.txtdataemi.Text = certificado.NotBefore.ToString
            frminfocertificado.txtrazao.Text = certificado.SubjectName.Name


            lista_Tabelas = dados_cert(SelecionarCertificado(nfecer))
            frminfocertificado.txtemail.Text = lista_Tabelas.Item(0).ToString
            frminfocertificado.txtnomeresp.Text = lista_Tabelas.Item(1).ToString
            frminfocertificado.mskcnpj.Text = lista_Tabelas.Item(2).ToString
            frminfocertificado.mskdata.Text = lista_Tabelas.Item(3).ToString
            frminfocertificado.mskcpfresp.Text = lista_Tabelas.Item(4).ToString
            frminfocertificado.txtrg.Text = lista_Tabelas.Item(6).ToString
            cnpj_cert = lista_Tabelas.Item(2).ToString

        End If
    End Sub

#End Region


#Region "''''Função da tabpages"

    Public Sub desativa_tab()
        TabControl_nfe.TabPages(0).Enabled = False
        TabControl_nfe.TabPages(1).Enabled = False
        TabControl_nfe.TabPages(2).Enabled = False
        TabControl_nfe.TabPages(3).Enabled = False
    End Sub

    Public Sub ativa_tab()

        TabControl_nfe.TabPages(0).Enabled = True
        TabControl_nfe.TabPages(1).Enabled = True
        TabControl_nfe.TabPages(2).Enabled = True
        TabControl_nfe.TabPages(3).Enabled = True


    End Sub



#End Region




#Region "''''Rotinas do datagridview adicionar itens,excluir calcular valores da aba total"

    Private Sub dgvgrid_xml_Click(sender As Object, e As EventArgs) Handles dgvgrid_xml.Click

        If txtprotocolo.Text <> "" Then
            itenscod()
        End If

    End Sub

    Public Sub adiciona_iten_grid()
        Dim i As Integer
        dgvgrid_xml.Rows.Add()

        i = dgvgrid_xml.Rows.Count - 1

        If txtnr.Text = "" Then
            dgvgrid_xml.Rows.Item(i).Cells("Nr").Value = dgvgrid_xml.Rows.Count
        Else
            dgvgrid_xml.Rows.Item(i).Cells("Nr").Value = txtnr.Text
        End If


        dgvgrid_xml.Rows.Item(i).Cells("cod_sglinx").Value = "0"


        dgvgrid_xml.Rows.Item(i).Cells("codfor").Value = txtcodfor_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("descricao").Value = txtdesc_item.Text.TrimEnd()
        dgvgrid_xml.Rows.Item(i).Cells("qtde").Value = txtqtde_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vlrunit").Value = txtvlrunit_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vlrtotal").Value = txtvlrtotal_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("codbarra").Value = txtcodbarra_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("ncm").Value = txtncm_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("cfop").Value = txtcfop_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("cst").Value = txtcst_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("aliqicms").Value = txtaliqicms_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vlricms").Value = txtvlricms_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vlrst").Value = txtvlrst_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("cstpis").Value = txtcstpis_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("aliqpis").Value = txtaliqpis_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vlrpis").Value = txtvlrpis_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("cstcofins").Value = txtcstcofins_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("aliqcofins").Value = txtaliqcofins_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vlrcofins").Value = txtvlrcofins_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vFCP_st").Value = txtvlrfcpst_item.Text

        dgvgrid_xml.Rows.Item(i).Cells("un").Value = txtun_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("mva").Value = txtmva_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("aliqst").Value = txtaliqst_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("cstipi").Value = txtcstipi_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vlripi").Value = txtvlripi_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vlrdesc").Value = txtvlrdesc_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("lote").Value = txtlote_item.Text

        dgvgrid_xml.Rows.Item(i).Cells("pmc").Value = txtpmc_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("datavenc").Value = mskdvenc_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("baseicms").Value = txtbaseicms_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("basest").Value = txtbasest_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("predbc").Value = txtbaseredicms_item.Text

        dgvgrid_xml.Rows.Item(i).Cells("aliqipi").Value = txtaliqIPI_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("valor_aprox_trib").Value = txtvlrtrib_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("inf_adi_prod").Value = txtinfoadic_item.Text

        dgvgrid_xml.Rows.Item(i).Cells("vlroutros").Value = txtvlroutros_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("qtdecx").Value = "1"
        dgvgrid_xml.Rows.Item(i).Cells("vlrfrete").Value = txtvlrfrete_item.Text


        dgvgrid_xml.Rows.Item(i).Cells("cest").Value = txtcest_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("ex_tipe").Value = txtncmex_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("predbcst").Value = txtbaseredicmsst_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vicmsdeson").Value = "0.00"
        dgvgrid_xml.Rows.Item(i).Cells("motdesicms").Value = ""

        dgvgrid_xml.Rows.Item(i).Cells("vlrtotal_cdesc").Value = txtvlrfinal_prod_item.Text


        dgvgrid_xml.Rows.Item(i).Cells("vBCUFDest").Value = txtvBCUFDest_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("pFCPUFDest").Value = txtpFCPUFDest_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("pICMSUFDest").Value = txtpICMSUFDest_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("pICMSInter").Value = txtpICMSInter_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("pICMSInterPart").Value = txtpICMSInterPart_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vFCPUFDest").Value = txtvFCPUFDest_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vICMSUFRemet").Value = txtvICMSUFRemet_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vICMSUFDest").Value = txtvICMSUFDest_item.Text

    End Sub


    Private Sub itenscod()
        If dgvgrid_xml.Rows.Count <> "0" Then

            limpar_itens()
            txtdesc_item.Text = RemoverAcentos(dgvgrid_xml.CurrentRow.Cells("descricao").Value.ToString.ToUpper)
            txtcodbarra_item.Text = dgvgrid_xml.CurrentRow.Cells("codbarra").Value
            txtcodfor_item.Text = dgvgrid_xml.CurrentRow.Cells("codfor").Value
            txtvlrunit_item.Text = dgvgrid_xml.CurrentRow.Cells("vlrunit").Value
            txtqtde_item.Text = dgvgrid_xml.CurrentRow.Cells("qtde").Value
            txtqtdecx_item.Text = dgvgrid_xml.CurrentRow.Cells("Qtdecx").Value

            txtvlrfcpst_item.Text = dgvgrid_xml.CurrentRow.Cells("vFCP_st").Value

            txtcfop_item.Text = dgvgrid_xml.CurrentRow.Cells("cfop").Value
            txtcst_item.Text = dgvgrid_xml.CurrentRow.Cells("cst").Value
            txtvlrdesc_item.Text = dgvgrid_xml.CurrentRow.Cells("vlrdesc").Value
            txtcstpis_item.Text = dgvgrid_xml.CurrentRow.Cells("cstpis").Value
            txtaliqpis_item.Text = dgvgrid_xml.CurrentRow.Cells("aliqpis").Value
            txtvlrpis_item.Text = dgvgrid_xml.CurrentRow.Cells("vlrpis").Value
            txtcstcofins_item.Text = dgvgrid_xml.CurrentRow.Cells("cstcofins").Value
            txtaliqcofins_item.Text = dgvgrid_xml.CurrentRow.Cells("aliqcofins").Value
            txtvlrcofins_item.Text = dgvgrid_xml.CurrentRow.Cells("vlrcofins").Value
            txtncm_item.Text = dgvgrid_xml.CurrentRow.Cells("ncm").Value

            txtncmex_item.Text = dgvgrid_xml.CurrentRow.Cells("ex_tipe").Value
            txtcest_item.Text = dgvgrid_xml.CurrentRow.Cells("cest").Value
            txtun_item.Text = dgvgrid_xml.CurrentRow.Cells("un").Value
            txtvlrfrete_item.Text = dgvgrid_xml.CurrentRow.Cells("vlrfrete").Value
            txtmva_item.Text = dgvgrid_xml.CurrentRow.Cells("mva").Value
            txtvlrst_item.Text = dgvgrid_xml.CurrentRow.Cells("vlrst").Value
            txtaliqst_item.Text = dgvgrid_xml.CurrentRow.Cells("aliqst").Value
            txtlote_item.Text = dgvgrid_xml.CurrentRow.Cells("lote").Value
            txtaliqicms_item.Text = dgvgrid_xml.CurrentRow.Cells("aliqicms").Value
            txtvlricms_item.Text = dgvgrid_xml.CurrentRow.Cells("vlricms").Value
            mskdvenc_item.Text = dgvgrid_xml.CurrentRow.Cells("datavenc").Value
            txtcstipi_item.Text = dgvgrid_xml.CurrentRow.Cells("cstipi").Value
            txtvlripi_item.Text = dgvgrid_xml.CurrentRow.Cells("vlripi").Value
            txtvlrtotal_item.Text = dgvgrid_xml.CurrentRow.Cells("vlrtotal").Value

            If dgvgrid_xml.CurrentRow.Cells("pmc").Value <> "" Then
                txtpmc_item.Text = dgvgrid_xml.CurrentRow.Cells("pmc").Value
            End If



            txtbaseicms_item.Text = dgvgrid_xml.CurrentRow.Cells("baseicms").Value
            txtbasest_item.Text = dgvgrid_xml.CurrentRow.Cells("basest").Value
            txtbaseredicms_item.Text = dgvgrid_xml.CurrentRow.Cells("predbc").Value
            txtaliqIPI_item.Text = dgvgrid_xml.CurrentRow.Cells("aliqipi").Value
            txtvlrtrib_item.Text = dgvgrid_xml.CurrentRow.Cells("Valor_aprox_trib").Value
            txtvlroutros_item.Text = dgvgrid_xml.CurrentRow.Cells("vlroutros").Value

            txtvlrfinal_prod_item.Text = dgvgrid_xml.CurrentRow.Cells("vlrtotal_cdesc").Value


            If dgvgrid_xml.CurrentRow.Cells("inf_adi_prod").Value <> "" Then
                inf_adici_prod.Visible = True
                txtinfoadic_item.Text = dgvgrid_xml.CurrentRow.Cells("inf_adi_prod").Value
            Else
                inf_adici_prod.Visible = False
            End If


            If dgvgrid_xml.CurrentRow.Cells("Qtdecx").Value <> "0" Then

                txtvlrunit_item.Text = CDec(txtvlrunit_item.Text) / CDec(dgvgrid_xml.CurrentRow.Cells("Qtdecx").Value)
                txtvlrunit_item.Text = format_val_mysql_ret(txtvlrunit_item.Text)

            End If



        End If
    End Sub



#End Region






    Private Sub txttpEmis_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttpEmis.TextChanged
        If txttpEmis.Text = "1" Then
            txttpEmis.Text = "1-Emissão Normal"
        End If
        If txttpEmis.Text = "2" Then
            txttpEmis.Text = "2-Contingência FS"
        End If
        If txttpEmis.Text = "3" Then
            txttpEmis.Text = "3-Contingência SCAN"
        End If
        If txttpEmis.Text = "4" Then
            txttpEmis.Text = "4-Contingência DPEC"
        End If
        If txttpEmis.Text = "5" Then
            txttpEmis.Text = "5-Contingência FSDA"
        End If
        If txttpEmis.Text = "6" Then
            txttpEmis.Text = "6-Contingência SVC - AN"

        End If
        If txttpEmis.Text = "7" Then
            txttpEmis.Text = "7-Contingência SVC - RS"
        End If
    End Sub

    Private Sub tpAmb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttpAmb.TextChanged
        If txttpAmb.Text = "1" Then
            txttpAmb.Text = "1-Ambiente Produção"
        End If
        If txttpAmb.Text = "2" Then
            txttpAmb.Text = "2-Ambiente Homologação"
        End If
    End Sub

    Private Sub txtprocEmi_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprocEmi.TextChanged
        If txtprocEmi.Text = "0" Then
            txtprocEmi.Text = "0-Aplicativo do contribuinte"
        End If
        If txtprocEmi.Text = "1" Then
            txtprocEmi.Text = "1-Emissão de NF-e avulsa pelo Fisco"
        End If
        If txtprocEmi.Text = "2" Then
            txtprocEmi.Text = "2-emissão de NF-e avulsa, pelo contribuinte com seu certificado digital, através do site do Fisco"
        End If
        If txtprocEmi.Text = "3" Then
            txtprocEmi.Text = "3-Aplicativo fornecido pelo Fisco"
        End If
    End Sub

    Private Sub txttpNF_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttpNF.TextChanged
        If txttpNF.Text = "0" Then
            txttpNF.Text = "0-NFe de Entrada"
            tiponota = "0"
            optentrada.Checked = True
        End If
        If txttpNF.Text = "1" Then
            txttpNF.Text = "1-NFe de Saída"
            tiponota = "1"
            optsaida.Checked = True
        End If
    End Sub

    Private Sub txtregime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtregime.TextChanged
        If txtregime.Text = "1" Then
            txtregime.Text = "1-Simples Nacional"
        End If
        If txtregime.Text = "2" Then
            txtregime.Text = "2-Simples Nacional – excesso de sublimite de receita bruta"
        End If
        If txtregime.Text = "3" Then
            txtregime.Text = "3-Regime Normal"
        End If
    End Sub

    Private Sub txtfretecont_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfretecont.TextChanged
        If txtfretecont.Text = "0" Then
            txtfretecont.Text = "(0) Emitente"
            optemi.Checked = True
        End If
        If txtfretecont.Text = "1" Then
            txtfretecont.Text = "(1) Dest/Rem"
            optdest.Checked = True
        End If
        If txtfretecont.Text = "2" Then
            txtfretecont.Text = "(2) Terseiros"
            optter.Checked = True
        End If
        If txtfretecont.Text = "9" Then
            txtfretecont.Text = "(9) Sem frete"
            optsem.Checked = True
        End If
    End Sub

    Private Sub txtinddest_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidDest.TextChanged
        If txtidDest.TextLength = "1" Then
            If txtidDest.Text = "1" Then
                txtidDest.Text = "1-Interna"
            End If
            If txtidDest.Text = "2" Then
                txtidDest.Text = "2-Interestadual"
            End If
            If txtidDest.Text = "3" Then
                txtidDest.Text = "3-Exterior"
            End If
        End If
    End Sub

    Private Sub txtcodbarra_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodbarra_item.Click
        txtcodbarra_item.SelectAll()
    End Sub

    Private Sub txtcodbarra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodbarra_item.GotFocus
        txtcodbarra_item.BackColor = Color.White
        txtcodbarra_item.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub txtcodbarra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodbarra_item.KeyPress
        If (e.KeyChar = Chr(13)) Then

            If txtcodbarra_item.Text <> "" Then

                txtcodfor_item.Clear()


            End If
        End If
    End Sub

    Private Sub txtcodbarra_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodbarra_item.LostFocus
        txtcodbarra_item.BackColor = Color.LemonChiffon
        'txtcodbarra.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub mskchave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskchave.KeyPress
        If (e.KeyChar = Chr(13)) Then
            If mskchave.Text = "" Then
                MsgBox("Informe a Chave de acesso da NF-e", MsgBoxStyle.Exclamation, "Aviso !")
                mskchave.Focus()
                Exit Sub
            End If

            busca_xml_consultadest()
        End If

    End Sub

    Private Sub mskchave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskchave.LostFocus
        If mskchave.Text <> "" Then
            mskchave.Mask = "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000"
        End If
    End Sub

    Private Sub frmxml_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If frmnfelocal.Text <> "Pesquisa Notas fiscais  para Realizar o Download da NF-e xml" Then
            Me.Dispose()
        End If
        Button4.Enabled = True
    End Sub

    Private Sub frmxml_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If

        Select Case e.KeyCode

            Case Keys.F8
                imprimirDanfe()

            Case Keys.Escape
                Me.Dispose()
        End Select
    End Sub


    Private Sub frmxml_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pitens.Enabled = False

        '   desativa_tab()

        '  TabControl_nfe.Controls.Remove(aba_Cobertura_ECF)

        Me.Text = versao
        cbosefaz.Text = "Selecione"

        pitens.Enabled = True


        '''''''''''''''''''''''''''''''''''''''Rotina busca certificado digital'''''''''''''''''''''''''''''''''

        lbllicenca.Text = "Sua licença de uso deste sistema vencerá em: " & data_licenca

        Try
            If certificado.ToString = "" Then
                frmcert.ShowDialog()
            End If
        Catch ex As Exception
            frmcert.ShowDialog()
        End Try


    End Sub

    Private Sub carregar_par01()
        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")
        If arquivoIni.KeyExists("importar_xml", "DFe") = False Then
            arquivoIni.Write("importar_xml", "false", "DFe")
        End If

        importar_xml = arquivoIni.Read("importar_xml", "DFe")

        If importar_xml = False Then
            Button5.Visible = False
        End If
    End Sub

    Private Sub cbosefaz_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbosefaz.SelectedIndexChanged
        If cbosefaz.Text = "Acre" Then
            Process.Start("http://www.sefaz.ac.gov.br/sefaz2010/")
        End If
        If cbosefaz.Text = "Alagoas" Then
            Process.Start("http://www.sefaz.al.gov.br/nfe/")
        End If
        If cbosefaz.Text = "Amazonas" Then
            Process.Start("http://sistemas.sefaz.am.gov.br/nfeweb/portal/index.do")
        End If
        If cbosefaz.Text = "Bahia" Then
            Process.Start("http://www.sefaz.ba.gov.br/nfen/portal/home.htm")
        End If
        If cbosefaz.Text = "Ceará" Then
            Process.Start("http://nfe.sefaz.ce.gov.br/")
        End If
        If cbosefaz.Text = "Distrito Federal" Then
            Process.Start("http://dec.fazenda.df.gov.br/")
        End If
        If cbosefaz.Text = "Espirito Santo" Then
            Process.Start("http://internet.sefaz.es.gov.br/informacoes/nfe/")
        End If
        If cbosefaz.Text = "Goiás" Then
            Process.Start("http://nfe.sefaz.go.gov.br/")
        End If
        If cbosefaz.Text = "Maranhão" Then
            Process.Start("http://www.sefaz.ma.gov.br/NFE/")
        End If
        If cbosefaz.Text = "Mato Grosso" Then
            Process.Start("http://www.sefaz.mt.gov.br/portal/nfe/")
        End If
        If cbosefaz.Text = "Mato Grosso do Sul" Then
            Process.Start("http://www1.nfe.ms.gov.br/")
        End If
        If cbosefaz.Text = "Minas Gerais" Then
            Process.Start("http://portalnfe.fazenda.mg.gov.br/")
        End If
        If cbosefaz.Text = "Pará" Then
            Process.Start("http://www.sefa.pa.gov.br/site/")
        End If
        If cbosefaz.Text = "Paraíba" Then
            Process.Start("http://www.receita.pb.gov.br/portalnf-e.php")
        End If
        If cbosefaz.Text = "Paraná" Then
            Process.Start("http://www.sped.fazenda.pr.gov.br/")
        End If
        If cbosefaz.Text = "Pernambuco" Then
            Process.Start("http://www.sefaz.pe.gov.br/sefaz2/asp2/mostra.asp?pai=1040")
        End If
        If cbosefaz.Text = "Piauí" Then
            Process.Start("http://www.sefaz.pi.gov.br/conteudo_internet.php?p=nfe_home")
        End If
        If cbosefaz.Text = "Rio de Janeiro" Then
            Process.Start("http://www.fazenda.rj.gov.br/portal/")
        End If
        If cbosefaz.Text = "Rio Grande do Norte" Then
            Process.Start("http://www.set.rn.gov.br/contentProducao/aplicacao/set_v2/nfe/gerados/inicio.asp")
        End If
        If cbosefaz.Text = "Rio Grande do Sul" Then
            Process.Start("http://www.sefaz.rs.gov.br/SEF_ROOT/inf/SEF-NFE.htm")
        End If
        If cbosefaz.Text = "Rondônia" Then
            Process.Start("http://www.portal.sefin.ro.gov.br/site/conteudo.action?conteudo=234")
        End If
        If cbosefaz.Text = "Santa Catarina" Then
            Process.Start("http://nfe.sef.sc.gov.br/")
        End If
        If cbosefaz.Text = "São Paulo" Then
            Process.Start("http://www.fazenda.sp.gov.br/nfe/")
        End If
        If cbosefaz.Text = "Sergipe" Then
            Process.Start("http://nfe.sefaz.se.gov.br/")
        End If
        If cbosefaz.Text = "Tocantins" Then
            Process.Start("http://www.sefaz.to.gov.br/nfe/consultanfe.php")
        End If

    End Sub

    Private Sub txtqtdecx_item_DoubleClick(sender As Object, e As EventArgs) Handles txtqtdecx_item.DoubleClick
        txtqtdecx_item.ReadOnly = False
    End Sub

    Private Sub txtqtdecx_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtqtdecx_item.LostFocus
        If txtvlrunit_item.Text <> "" Then
            If txtqtdecx_item.Text = "" Then
                txtqtdecx_item.Text = "1"
            End If
            txtvlrunit_item.Text = CDec(txtvlrunit_item.Text) / CDec(txtqtdecx_item.Text)
            If Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator = "." Then
                txtvlrunit_item.Text = Format(CDec(txtvlrunit_item.Text), "#,##0.0000")
            End If
        End If
    End Sub

    Private Sub txtdesc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdesc_item.GotFocus

    End Sub


    Private Sub Label129_Click(sender As Object, e As EventArgs)
        txtdataemissao.Text = Now
        txtdsaida.Text = Now
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Process.Start(Application.StartupPath & "\projeto_atualizacao.exe")
        End
    End Sub

    Private Sub Label59_Click(sender As Object, e As EventArgs) Handles Label59.Click

        If dgvgrid_xml.Rows.Count <> "0" Then
            MsgBox(dgvgrid_xml.CurrentRow.Cells("custofinal").Value)
        End If

    End Sub

    Private Sub dgvgrid_xml_DoubleClick(sender As Object, e As EventArgs) Handles dgvgrid_xml.DoubleClick
        carregar_par01()
        If importar_xml = False Then

            frmcalcpreco.txtcod_sg.Text = ""

            If dgvgrid_xml.CurrentRow.Cells("cod_sglinx").Value = "0" Then
                verifica_cadastro_sglinx()
            End If

            frmcalcpreco.txtcod_sg.Text = dgvgrid_xml.CurrentRow.Cells("cod_sglinx").Value


            If txtuffor.Text <> "MG" Then
                MsgBox("Nota Fiscal de outro estado, O calculo pode ser feito errado !", MsgBoxStyle.Exclamation, "Aviso !")
            End If


            Try
                If lerINI(Application.StartupPath & "\sglinear.ini", "FORMA_PRECO", "calc_preco") = True Then
                    frmcalcpreco.ShowDialog()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso, chama forme Preço")
            End Try


            frmcalcpreco.txtmargem.Text = "0,00 %"

        End If

    End Sub


    Private Sub CapturarDadosNFePortalNacionalToolStripMenuItem_Click(sender As Object, e As EventArgs)
        limpa_nfe()
        limpar_abas()
        limpar_itens()
        limpardup()
        dgvgrid_xml.Rows.Clear()

    End Sub

    Private Sub CapturarDadosNFeSEFAZMGToolStripMenuItem_Click(sender As Object, e As EventArgs)
        limpa_nfe()
        limpar_abas()
        limpar_itens()
        limpardup()
        dgvgrid_xml.Rows.Clear()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)

        If cnpj_cert <> cnpj_emp Then
            MsgBox("Certificado Digital seleciona está incorreto, " & vbCrLf & "O CNPJ do Certificado e Diferente da Empresa Logada no Sistema !" & vbCrLf & "Operação cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        If nfecer = "" Then
            MsgBox("Informe um Certificado Digital !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If




    End Sub

    Private Sub tcad_Tick(sender As Object, e As EventArgs) Handles tcad.Tick
        lbltimer.Text = lbltimer.Text + 1


        If lbltimer.Text = "2" Then
            'cha a rotina para consulta nfe no sefaz mg
            Dim WebS As New C_WebService
            Dim dadoscad As New C_WebService.Retcad
            If txtuffor.Text = "MG" Then
                dadoscad = WebS.CadConsultaCadastro2(removeFormatacao(mskcnpjfor.Text), txtuffor.Text, mskchave.Text.Substring(0, 2))
            Else
                dadoscad = WebS.CadConsultaCadastro4(removeFormatacao(mskcnpjfor.Text), txtuffor.Text, mskchave.Text.Substring(0, 2))
            End If


            If dadoscad.cStat = "111" Or dadoscad.cStat = "112" Then
                ' MsgBox("Consulta Realizada, (1) registro encontrado !", MsgBoxStyle.Information, "Retorno do sefaz:")
            Else
                MsgBox("Retorno do sefaz: " & dadoscad.xmotivo, MsgBoxStyle.Exclamation, "Aviso!")
            End If


            If dadoscad.cStat = "111" Or dadoscad.cStat = "112" Then
                '    MsgBox(dadoscad.xnome + vbCrLf + dadoscad.indCredNFe + vbCrLf + dadoscad.xcSit, MsgBoxStyle.Information, "Retorno do Sefaz " + ufsig)
                If txtregime.Text.Substring(0, 1) = "1" And dadoscad.xRegApur = "SIMPLES NACIONAL" Or txtregime.Text.Substring(0, 1) = "3" And dadoscad.xRegApur = "DEBITO E CREDITO" Then
                    MsgBox("Regime tributario Valido : " & dadoscad.xRegApur, MsgBoxStyle.Information, "Aviso !")
                Else

                    If txtuffor.Text = "MG" Then
                        MsgBox("Regime tributario Invalida !!! " + vbCrLf + "Regime tributario cadastrado na SEFAZ: " & dadoscad.xRegApur, MsgBoxStyle.Exclamation, "Aviso !")
                    Else
                        MsgBox("Regime tributario Cadastrado na SEFAZ : " & dadoscad.xRegApur, MsgBoxStyle.Information, "Aviso !")
                    End If

                End If


            End If


            'retorna o temino do processo1
            Label91.Text = "Emitente/Fornecedor"
        End If

        If lbltimer.Text = "3" Then
            tcad.Dispose()
        End If
    End Sub

    Private Sub bntconsregime_Click(sender As Object, e As EventArgs) Handles bntconsregime.Click
        If txtuffor.Text = "MG" Then
            coduf = "31"

        End If

        ' If txtuffor.Text <> "MG" Then
        'MsgBox("Esta operação só é Permitida para Fornecedores de Minas Gerais", MsgBoxStyle.Exclamation, "Aviso !")
        ' Exit Sub
        ' End If


        If txtuffor.Text = "SP" Then
            coduf = "35"

        End If

        If txtuffor.Text = "PR" Then
            coduf = "41"

        End If

        If txtuffor.Text = "RS" Then
            coduf = "43"

        End If

        If txtuffor.Text = "AM" Then
            coduf = "13"

        End If

        If txtuffor.Text = "BA" Then
            coduf = "29"

        End If

        If txtuffor.Text = "CE" Then
            coduf = "23"

        End If

        If txtuffor.Text = "ES" Then
            coduf = "32"

        End If

        If txtuffor.Text = "GO" Then
            coduf = "52"

        End If

        If txtuffor.Text = "MT" Then
            coduf = "51"

        End If

        If txtuffor.Text = "MS" Then
            coduf = "50"

        End If

        If txtuffor.Text = "PE" Then
            coduf = "26"

        End If

        If txtuffor.Text = "MA" Then
            coduf = "21"

        End If

        If txtuffor.Text = "AC" Or txtuffor.Text = "RN" Or txtuffor.Text = "PB" Or txtuffor.Text = "SC" Then



            If txtuffor.Text = "AC" Then
                coduf = "12"
            ElseIf txtuffor.Text = "RN" Then
                coduf = "24"
            ElseIf txtuffor.Text = "PB" Then
                coduf = "25"
            ElseIf txtuffor.Text = "SC" Then
                coduf = "42"
            End If
        End If

        Label91.Text = "Validando a Regime tributario do Fornecedor..."

        lbltimer.Text = "0"
        tcad.Enabled = True
    End Sub


    Private Sub txtpainel_Click(sender As Object, e As EventArgs) Handles txtpainel.Click
        If txtpainel.Text.Substring(0, 19) = "Ultima consulta DFe" Then
            Me.TabControl_nfe.SelectTab("DFe")
        End If
    End Sub


    Private Sub EnviaEmailNFeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If txtcaminhoxml.Text = "" Then
            MsgBox("Abra primeiro o xml no Visualizador, para depois enviá-lo por e-mail !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        If File.Exists(txtcaminhoxml.Text) = False Then
            MsgBox("Arquivo xml que você esta tentando enviar não existe !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        email = True

        danfe(txtcaminhoxml.Text)


    End Sub



    Private Sub VisualizarNFeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizarNFeToolStripMenuItem.Click

        Try

            dgvgrid_xml.Rows.Clear()
            txtprotocolocanc.Visible = False
            chave()
            dadosnfe()
            fatura()
            dadostrasp()
            itens_nfe()

            ' frminfo.Close()
            TabControl_nfe.SelectTab(TabPrincipal)

            Label78.Text = "Protocolo de Autorização"



            MsgBox("Arquivo Carregado !", MsgBoxStyle.Information, "Aviso !")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso !")
        End Try
    End Sub

    Private Sub txtindIEDest_TextChanged(sender As Object, e As EventArgs) Handles txtindIEDest.TextChanged
        If txtindIEDest.Text = "1" Then
            txtindIEDest.Text = "1 – Contribuinte ICMS"
        End If
        If txtindIEDest.Text = "2" Then
            txtindIEDest.Text = "2 – Contribuinte isento de inscrição"
        End If
        If txtindIEDest.Text = "9" Then
            txtindIEDest.Text = "9 – Não Contribuinte"
        End If

    End Sub

    Private Function pes_Gridibpt(ByVal id As String) As String

        For Each row As DataGridViewRow In Me.dgvibpt.Rows

            If Not row.IsNewRow Then
                If row.Cells(0).Value + row.Cells(1).Value = id Then
                    Return row.Index
                End If
            End If

        Next

        Return 0

    End Function

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)

        txttpNF.Text = "0-NFe de Entrada"
        tiponota = "0"

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)

        txttpNF.Text = "1-NFe de Saída"
        tiponota = "1"

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If cbomod_ecf.Text = "" Then
            MsgBox("Informe 0 Código do modelo do Documento Fiscal Preencher com(2B), quando se tratar de Cupom Fiscal emitido por máquina registradora (não ECF), com (2C), quando se tratar de Cupom Fiscal PDV, ou (2D), quando se tratar de Cupom Fiscal (emitido por ECF)", MsgBoxStyle.Exclamation, "Aviso !")
            cbomod_ecf.Focus()
            Exit Sub
        End If
        If txtnecf.Text = "" Or txtnecf.Text = "000" Then
            MsgBox("Informar o número de ordem seqüencial do ECF que emitiu o Cupom Fiscal vinculado à NF-e", MsgBoxStyle.Exclamation, "Aviso !")
            txtnecf.Focus()
            Exit Sub
        End If

        If txtncoo.Text = "" Or txtncoo.Text = "000000" Then
            MsgBox("Informar o Número do Contador de Ordem de Operação - COO vinculado à NF-e", MsgBoxStyle.Exclamation, "Aviso !")
            txtncoo.Focus()
            Exit Sub
        End If

        dgvecf.Rows.Add(cbomod_ecf.Text, txtnecf.Text, txtncoo.Text)

        cbomod_ecf.Text = ""
        txtnecf.Text = ""
        txtncoo.Text = ""
    End Sub

    Private Sub txtnecf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnecf.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtncoo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtncoo.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Pic_pis_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub txtvlrunit_item_TextChanged(sender As Object, e As EventArgs) Handles txtvlrunit_item.TextChanged

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If dgvecf.RowCount = "0" Then
            Exit Sub
        End If

        If MessageBox.Show("Deseja Realmente excluir o item selecionado ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

            dgvecf.Rows.Remove(dgvecf.CurrentRow)

            MsgBox("Item excluido com sucesso !", MsgBoxStyle.Information, "Aviso !")
        End If
    End Sub

    Private Sub btndanfe_Click(sender As Object, e As EventArgs) Handles btndanfe.Click

        If txtmodnfe.Text = "55" Then
            imprimirDanfe()
        Else
            MsgBox("Impressão exclusiva para NF-e", MsgBoxStyle.Exclamation, "Atenção !")
        End If

    End Sub

    Private Sub txtcalc_prod_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtnecf_LostFocus(sender As Object, e As EventArgs) Handles txtnecf.LostFocus
        txtnecf.Text = txtnecf.Text.PadLeft(3, "0")
    End Sub

    Private Sub txtncoo_LostFocus(sender As Object, e As EventArgs) Handles txtncoo.LostFocus
        txtncoo.Text = txtncoo.Text.PadLeft(6, "0")
    End Sub


    Private Sub txtufdest_TextChanged(sender As Object, e As EventArgs) Handles txtufdest.TextChanged

        If txtufdest.Text = txtuffor.Text Then
            txtidDest.Text = "1-Interna"
        End If
        If txtufdest.Text <> txtuffor.Text Then
            txtidDest.Text = "2-Interestadual"
        End If


    End Sub

    Private Sub LinkLabel1_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        carregar_precovenda()
    End Sub

    Private Sub bntcancelar_Click(sender As Object, e As EventArgs)

        If cnpj_cert <> cnpj_emp Then
            MsgBox("Certificado Digital seleciona está incorreto, " & vbCrLf & "O CNPJ do Certificado e Diferente da Empresa Logada no SIstema !", MsgBoxStyle.Information, "Aviso !")
            Exit Sub
        End If

        If nfecer = "" Then
            MsgBox("Informe um Certificado Digital !", MsgBoxStyle.Information, "Aviso !")
            Exit Sub
        End If



    End Sub

    Private Sub txtadifisco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtadifisco.KeyPress
        If e.KeyChar = Chr(13) Then


            TabControl_nfe.SelectTab(Tabitens)
            txtcodfor_item.Focus()

        End If
    End Sub

    Public Sub abrir_xml(ByVal xml As String)


        xmldoc.LoadXml(xml)
        dgvgrid_xml.Rows.Clear()

        txtdsaida.Format = DateTimePickerFormat.Custom
        txtdsaida.CustomFormat = "dd/MM/yyyy HH:mm:ss"

        '''''''''''''''''''''''Rotina para carregar os dados da NFe abaixo:''''''''''''''''''''''''''''''''''''
        ' LerNFE(txtcaminhoxml.Text)
        chave()
        dadosnfe()
        fatura()
        dadostrasp()
        itens_nfe()


        lblcanc.Visible = True
        lblmotcanc.Visible = True
        txtprotocolocanc.Visible = True
        txtxmotivocanc.Visible = True


        TabControl_nfe.SelectTab(TabPrincipal)
        '    verificar_ean()

        '  valida_icms()

        ativa_tab()
    End Sub
    Private Sub bntopen_Click(sender As Object, e As EventArgs) Handles bntopen.Click
        '   Try

        txtcaminhoxml.BackColor = Color.White
        frminfo.Show()
        frminfo.txtinfo.Text = vbCrLf + "Aguarde, Carregando o arquivo XML ..."


        ' dialogo.Filter = "Arquivos (.xml .txt)|*.xml;*.txt"
        dialogo.Filter = "Arquivos (*.xml)|*.xml|All files (*.*)|*.*"

        If dialogo.ShowDialog() = Windows.Forms.DialogResult.OK Then

            txtcaminhoxml.Text = dialogo.FileName

            ' If Path.GetExtension(txtcaminhoxml.Text) = ".xml" Or Path.GetExtension(txtcaminhoxml.Text) = ".XML" Then

            xmldoc.Load(txtcaminhoxml.Text)
            dgvgrid_xml.Rows.Clear()

            txtdsaida.Format = DateTimePickerFormat.Custom
            txtdsaida.CustomFormat = "dd/MM/yyyy HH:mm:ss"
            '''''''''''''''''''''''Rotina para carregar os dados da NFe abaixo:''''''''''''''''''''''''''''''''''''
            ' LerNFE(txtcaminhoxml.Text)
            chave()
            dadosnfe()
            fatura()
            dadostrasp()
            itens_nfe()

            If txtmodnfe.Text = "65" Then
                If txtqrcodenfce.Text = "" Then
                    txtqrcodenfce.Text = GerarEndQRCodeXML(xmldoc.InnerXml)
                End If
            End If


            lblcanc.Visible = True
            lblmotcanc.Visible = True
            txtprotocolocanc.Visible = True
            txtxmotivocanc.Visible = True


            frminfo.Close()

            If importar_xml = False Then
                TabControl_nfe.SelectTab(TabPrincipal)
            End If

            '    verificar_ean()

            '  valida_icms()

            ativa_tab()

        End If

        ' End If

        frminfo.Close()

        '''''''''''''''''''''Evento abaixo executado quando ocorrer um erro'''''''''''''''''''''''''''''''''''
        '   Catch ex As Exception
        'MsgBox(ex.Message + vbCrLf + "Contate o Administrador do Sistema." + vbCrLf + "Operação cancelada !", MsgBoxStyle.Critical, "Aviso !")
        '   frminfo.Close()
        '  End Try
    End Sub

    Private Sub cbonat_TextChanged(sender As Object, e As EventArgs) Handles cbonat.TextChanged
        Dim boxIndex As Integer, lExst As Boolean


        Dim box As ComboBox = sender

        Dim txt As String = box.Text

        Dim posCursor As Integer = box.SelectionStart

        ' Se o cursor não estiver no inicio do textbox inicia a busca

        If posCursor <> 0 Then

            lExst = False

            ' Procura na combo pela entrada na lista

            For boxIndex = 0 To box.Items.Count - 1

                If UCase(Mid(box.Items(boxIndex), 1, posCursor)) = UCase(Mid(txt, 1, posCursor)) Then

                    box.Text = box.Items(boxIndex)

                    box.SelectionStart = posCursor

                    lExst = True

                    Exit For

                End If

            Next

            ' Se não encontrar retorna o valor anterior

            If Not lExst Then

                box.Text = Mid(txt, 1, posCursor - 1) + Mid(txt, posCursor + 1)

                box.SelectionStart = posCursor - 1

            End If

        End If
    End Sub


    Private Sub btncarta_Click(sender As Object, e As EventArgs)
        If txtprotocolo.Text = "" Then
            MsgBox("Carregue abaixo a Nota Fiscal para gerar a carta de correção !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        '''''''''''''''''''''''''Regra de validacao de cnpj certificado''''''''''''''''''''
        If removeFormatacao(mskcnpjfor.Text) <> cnpj_cert Then
            MsgBox("CNPJ do Certificado Digital informado diferente do CNPJ Emitente da NF-e !" + vbCrLf + "Operação cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If


    End Sub
    Private Sub inf_adici_prod_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles inf_adici_prod.LinkClicked
        MsgBox(txtinfoadic_item.Text, MsgBoxStyle.Information, "Informação adicional Produto !")
    End Sub

    Private Sub txtcalc_prod_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Public Sub carregar_precovenda()
        Try

            conectar_preco()

            For i As Integer = 0 To dgvgrid_xml.Rows.Count - 1


                rs.Open("select * from preco_nfe where chave_pr = '" & mskchave.Text + dgvgrid_xml.Rows.Item(i).Cells("Nr").Value & "'", cn_p, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

                If rs.EOF = False Then

                    dgvgrid_xml.Rows.Item(i).Cells("pmc").Value = rs.Fields("preco_vd").Value
                    '   dgvgrid_xml.Rows.Item(i).Cells("custofinal").Value = rs.Fields("precocusto_vd").Value

                    If rs.Fields("Qtdecx").Value.ToString.Trim = "" Then
                        dgvgrid_xml.Rows.Item(i).Cells("Qtdecx").Value = "1"
                    Else
                        dgvgrid_xml.Rows.Item(i).Cells("Qtdecx").Value = rs.Fields("Qtdecx").Value
                    End If

                End If

                rs.Close()

            Next

            cn_p.Close()

            MsgBox("Os preços de venda foram carregado com Sucesso !", MsgBoxStyle.Information, "Aviso !")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso !")
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmpesquisarnfe.ShowDialog()
    End Sub

    Private Sub ValidaXMLTagNFeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ValidaXMLTagNFeToolStripMenuItem.Click
        Dim xml_NFe As New XmlDocument()
        Dim xml_validar As New XmlDocument()


        Dim dialodest As New OpenFileDialog
        '  dialodest.Filter = "Arquivo XML NF-e (.xml)|*.xml"

        If dialodest.ShowDialog() = Windows.Forms.DialogResult.OK Then

            xml_NFe.Load(dialodest.FileName)



            'Valida A NFe com retorno (completa valida juridica''''''''

            Dim resultado_ret As String = ValidaXML.ValidarXML(xml_NFe, Application.StartupPath & "\Esquemas_XML_NF-e\envEvento_v1.00.xsd")

            If resultado_ret.Trim().Length = 0 Then
                MsgBox("XML da Nota Fiscal Valido de acordo com estrutura da RFB", MsgBoxStyle.Information, "Aviso")
            End If

            If resultado_ret.Trim().Length <> 0 Then
                MsgBox(resultado_ret, MsgBoxStyle.Exclamation, "Aviso !")

                MsgBox("XML da Nota  Fiscal Invalido !!!", MsgBoxStyle.Critical, "Aviso Ret !")

                Dim frmVisualizarcs As frmvisualizar_xml = New frmvisualizar_xml(xml_NFe.OuterXml)

                frmVisualizarcs.ShowDialog()
            End If



        End If
    End Sub

    Private Sub ValidaXMLCompletoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ValidaXMLCompletoToolStripMenuItem.Click
        Dim xml_NFe As New XmlDocument()
        Dim xml_validar As New XmlDocument()


        Dim dialodest As New OpenFileDialog
        dialodest.Filter = "Arquivo XML NF-e (.xml)|*.xml"

        If dialodest.ShowDialog() = Windows.Forms.DialogResult.OK Then

            xml_NFe.Load(dialodest.FileName)



            'Valida A NFe com retorno (completa valida juridica''''''''

            Dim resultado_ret As String = ValidaXML.ValidarXML(xml_NFe, Application.StartupPath & "\Esquemas_XML_NF-e\envEvento_v1.00.xsd")

            If resultado_ret.Trim().Length = 0 Then
                MsgBox("XML da Nota Fiscal Valido de acordo com estrutura da RFB", MsgBoxStyle.Information, "Aviso")
            End If

            If resultado_ret.Trim().Length <> 0 Then
                MsgBox(resultado_ret, MsgBoxStyle.Exclamation, "Aviso !")
                MsgBox("XML da Nota  Fiscal Invalido 1!!!", MsgBoxStyle.Critical, "Aviso Ret !")

                Dim frmVisualizarcs As frmvisualizar_xml = New frmvisualizar_xml(xml_NFe.OuterXml)
                frmresult_validacao.ShowDialog()
            End If

            '''''''sai da rotina
            Exit Sub


            'Valida o Tag NFe''''''''
            xml_validar.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & SepararNota(xml_NFe.OuterXml))

            'Valida o corpo do XML da NFe''''''''
            Dim resultado As String = ValidaXML.ValidarXML(xml_validar, Application.StartupPath & "\Esquemas_XML_NF-e\nfe_v3.10.xsd")

            If resultado.Trim().Length = 0 Then
                '  MsgBox("XML da Nota Fiscal Valido de acordo com estrutura da RFB", MsgBoxStyle.Information, "Aviso")
            End If

            If resultado.Trim().Length <> 0 Then
                MsgBox(resultado, MsgBoxStyle.Exclamation, "Aviso !")
            End If

        End If
    End Sub


#Region "''''Rotina DO sistema SGlinx"


    Private Sub verifica_cadastro_sglinx()
        Dim cod_cad_for As String

        Dim sql As String


        Try


            conectarsqlinx()


            '''''''''''''''''verifica se o fornecedor esta cadastrado'''''''''''''''''''
            sql = "SELECT cg2_cgc, cg2_cod FROM cg2  where cg2_cgc = '" & mskcnpjfor.Text & "'"

            rs.Open(sql, cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)


            If rs.EOF = True Then
                MsgBox("CNPJ Não Cadastrado no Banco", MsgBoxStyle.Exclamation, "Aviso !")
                cnsql.Close()
                Exit Sub
            Else
                cod_cad_for = rs.Fields("cg2_cod").Value
                rs.Close()
            End If



            For Each row As DataGridViewRow In dgvgrid_xml.Rows

                row.Cells("cod_sglinx").Value = "0"



                'Rotina Busca pelo codigo de barras cadastrado'''''''''''''''''''''''''
                sql = "SELECT es1_cod, es1_codbarra FROM es1a  where es1_codbarra = '" & row.Cells("codbarra").Value & "'"

                rs.Open(sql, cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

                If rs.EOF = False Then

                    row.Cells("cod_sglinx").Value = rs.Fields("es1_cod").Value


                End If

                rs.Close()



                'Rotina Busca pelo codigo fornecedor'''''''''''''''''''''''''

                If row.Cells("cod_sglinx").Value = "0" Then

                    sql = "SELECT cg2_cod , es1_cod, es1_codforn FROM es1i  where cg2_cod = '" & cod_cad_for & "' and es1_codforn = '" & row.Cells("codfor").Value & "' "

                    rs.Open(sql, cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

                    If rs.EOF = True Then

                        With Me.dgvgrid_xml.Rows(row.Index).DefaultCellStyle
                            .BackColor = Color.Red
                            .ForeColor = Color.White
                        End With

                    Else

                        row.Cells("cod_sglinx").Value = rs.Fields("es1_cod").Value

                    End If

                    rs.Close()

                End If




                'Rotina Busca pelo verificar se o produto esta ativo'''''''''''''''''''''''''

                If row.Cells("cod_sglinx").Value <> "0" Then

                    sql = "SELECT es1_cod, Es1_Ativo FROM es1 where es1_cod = '" & row.Cells("cod_sglinx").Value & "'"

                    rs.Open(sql, cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

                    If rs.Fields("Es1_Ativo").Value = "0" Then

                        With Me.dgvgrid_xml.Rows(row.Index).DefaultCellStyle
                            .BackColor = Color.Coral
                            .ForeColor = Color.White
                        End With


                    End If

                    rs.Close()

                End If



            Next


            cnsql.Close()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso verifica cod SGlinx")
            cnsql.Close()
        End Try


    End Sub

    Private Sub VerificaCadastroSGLinearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerificaCadastroSGLinearToolStripMenuItem.Click
        verifica_cadastro_sglinx()
    End Sub

    Private Sub ContextMenuStrip_grid_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_grid.Opening

        If dgvgrid_xml.RowCount = 0 Then
            Exit Sub
        End If

        If dgvgrid_xml.CurrentRow.Cells("codigo_prod_grid").Value = "" Then
            Toolmenuproduto.Visible = True
        Else
            Toolmenuproduto.Visible = False
        End If


        Try
            If lerINI(Application.StartupPath & "\sglinear.ini", "SGLINX", "verifica_cad") = True Then
                VerificaCadastroSGLinearToolStripMenuItem.Visible = True
            Else
                VerificaCadastroSGLinearToolStripMenuItem.Visible = False
            End If
        Catch ex As Exception

        End Try


        If importar_xml = True Then
            VerificaCadastroSGLinearToolStripMenuItem.Visible = False
        End If

    End Sub
#End Region




    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Try
            frmlogin_windows.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub busca_xml_consultadest()
        Try


            conectar_DFe()
            '''''''''''''''''nova rotina de arquivo xml'''''''''''''''''''''''''''
            rs.Open("select * from NFe_consultadaDFe where chave_nfe = '" & mskchave.Text & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockPessimistic)

            If rs.EOF = True Then
                MsgBox("Chave de Acessso da NFe não encontrada no Banco de dados !", MsgBoxStyle.Exclamation, "Aviso !")
                cn_DFe.Close()
                Exit Sub
            End If

            Dim bytePicData() As Byte = rs.Fields("XML_NFe").Value

            txtcaminhoxml.Text = "Arquivo XML carregado do Banco de dados !"
            txtcaminhoxml.BackColor = Color.Khaki

            Try
                xmldoc.LoadXml(Encoding.UTF8.GetString(bytePicData))
            Catch ex As Exception
                xmldoc.LoadXml(Encoding.UTF8.GetString(bytePicData).Remove(0, 39))
            End Try

            dgvgrid_xml.Rows.Clear()
            txtprotocolocanc.Visible = False
            chave()
            dadosnfe()
            fatura()
            dadostrasp()
            itens_nfe()

            ' frminfo.Close()
            ' TabControl1.SelectTab(TabPage3)
            '  verificar_ean()

            cn_DFe.Close()
            MsgBox("Nota Fiscal carregado com Sucesso !", MsgBoxStyle.Information, "Aviso !")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso !")
            cn_DFe.Close()
        End Try

    End Sub


    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        frmcadastro.Show()
    End Sub

    Private Sub ConsultaNFeDownloadToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frmnfelocal.Text = "Pesquisa Notas fiscais  para Realizar o Download da NF-e xml"
        frmnfelocal.ShowDialog()
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        frminfocertificado.carregar(certificado)

        frminfocertificado.ShowDialog()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        frmstatus.ShowDialog()
    End Sub

    Public Function GerarNotaProcessada(ByVal vStringNfe As String) As XmlDocument
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



        '  Using xmltw As New XmlTextWriter(PastaNota & chavenfe + ".xml", New UTF8Encoding(False))
        'NDoc.WriteTo(xmltw)
        '   xmltw.Close()
        '  End Using

        Return NDoc
    End Function

    Private Sub reparaxml(ByVal folder As System.IO.DirectoryInfo, caminho As String)
        Dim xmldoc2 As New XmlDocument()

        For Each fi As System.IO.FileInfo In folder.GetFiles




            xmldoc2.Load(caminho & "\" & fi.Name)
            '   MsgBox(fi.Name)
            Dim xml As String = xmldoc2.OuterXml

            xmldoc2.LoadXml(SepararNota(xmldoc2.OuterXml))

            Dim xmlAssinado As XmlDocument = CertificadoDigital.Assinar(GerarNotaProcessada(xmldoc2.OuterXml), "infNFe", certificado)

            xmlAssinado.Save("C:\Users\adeni\Desktop\Nova_pasta\" & fi.Name)


        Next

        MsgBox("XML assinado !")
    End Sub

    Public Function SepararNota(ByVal vNfeDadosMsg As String) As String

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<infNFe")
        Dim nPosF As Int32 = vNfeDadosMsg.IndexOf("</infNFe")

        Dim vStringNfe As String = vNfeDadosMsg.Substring(nPosI, nPosF - nPosI + 9)

        Return vStringNfe

    End Function

    Public Function SepararNota_assinatura(ByVal vNfeDadosMsg As String) As String

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>

        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<Signature")
        Dim nPosF As Int32 = vNfeDadosMsg.Length - nPosI
        Dim vStringNfe As String = vNfeDadosMsg.Substring(nPosI, nPosF - 6)

        Return vStringNfe

    End Function

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click

        For Each row As DataGridViewRow In dgvgrid_xml.Rows

            If validaGTIN(row.Cells("codbarra").Value) = False Then
                With Me.dgvgrid_xml.Rows(row.Index).DefaultCellStyle
                    .BackColor = Color.Yellow
                    .ForeColor = Color.Red
                End With
            End If

        Next

        valida_prefixo()

        MsgBox("Processo executado !")
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        For Each row As DataGridViewRow In dgvgrid_xml.Rows

            If row.Cells("cst").Value = "060" And row.Cells("cest").Value = "" Then
                With Me.dgvgrid_xml.Rows(row.Index).DefaultCellStyle
                    .BackColor = Color.Yellow
                    .ForeColor = Color.Red
                End With
            End If

        Next



        MsgBox("Processo executado !")
    End Sub

    Private Sub valida_prefixo()
        For Each row As DataGridViewRow In dgvgrid_xml.Rows

            If row.Cells("codbarra").Value.ToString.Substring(0, 2) = "78" Then

                If row.Cells("codbarra").Value.ToString.Substring(0, 3) <> "789" Then
                    If row.Cells("codbarra").Value.ToString.Substring(0, 3) <> "790" Then
                        With Me.dgvgrid_xml.Rows(row.Index).DefaultCellStyle
                            .BackColor = Color.Yellow
                            .ForeColor = Color.Red
                        End With
                    End If
                End If


            End If


            If row.Cells("codbarra").Value.ToString.Substring(0, 2) = "56" Then

                If row.Cells("codbarra").Value.ToString.Substring(0, 3) <> "560" Then
                    With Me.dgvgrid_xml.Rows(row.Index).DefaultCellStyle
                        .BackColor = Color.Yellow
                        .ForeColor = Color.Red
                    End With
                End If


            End If


        Next

        MsgBox("Processo executado !")
    End Sub


    Private Sub Button1_MouseUp(sender As Object, e As MouseEventArgs) Handles Button1.MouseUp
        Me.ContextMenuStrip3.Show(TryCast(sender, Control), e.X, e.Y)
    End Sub


    Private Sub consultanfce_sefaz()
        Dim rsconsulta As New ADODB.Recordset
        Dim WebS As New C_WebService
        Dim retornonfe As New RetRetorno
        Dim xmlretcanc = New XmlDocument()

        txtprotocolo.Clear()
        txtxmotivo.Clear()
        txtxmotivocanc.Clear()
        txtprotocolocanc.Clear()

        Try

            '''''''''''BUSCA URL do webservice''''''''''''
            WebS.url_webservice(BuscaURL(mskchave.Text.Substring(0, 2), 1, False, mskchave.Text.Substring(20, 2)))


            lblconsultanfe.Text = "Recebendo retorno consulta na SEFAZ...."


            retornonfe = WebS.ConsultaStatusNfe4(mskchave.Text, 1)


            If retornonfe.cStat <> "100" Then

                If retornonfe.cStat <> "1010" Then
                    MsgBox(retornonfe.xMotivo, MsgBoxStyle.Exclamation, "Aviso !")
                    '  txtxmotivo.Text = retornonfe.xMotivo
                End If

            End If


            For Each RetC In retornonfe.L_Retornos

                txtxmotivocanc.Text = RetC.xMotivo1
                txtprotocolocanc.Text = RetC.nProtc & " " & Convert.ToDateTime(RetC.dhRecbtoori).ToString("dd/MM/yyyy HH:mm:ss")

                If RetC.xMotivo1 = "" Then
                    txtxmotivo.Text = RetC.xMotivo
                    txtprotocolo.Text = RetC.nProt & " " & Convert.ToDateTime(RetC.dhRecbto).ToString("dd/MM/yyyy HH:mm:ss")
                End If

            Next

            If retornonfe.xMotivo <> "" Then
                MsgBox(retornonfe.xMotivo & vbCrLf & retornonfe.chNFe, MsgBoxStyle.Information, "Aviso !")
            End If


            '''''''''''''''''''Rotina abaixo para ler o retorno no xml de ret''''''''''''


            Dim xmldoc As New XmlDocument()
            Dim xmlnsManager As New XmlNamespaceManager(xmldoc.NameTable)

            Dim xmllist As System.Xml.XmlNodeList
            'Dim xmlnode As Xml.XmlNode

            xmldoc.Load(Application.StartupPath & "\XML\Retorno_consultaNFe.xml")

            xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
            xmllist = xmldoc.SelectNodes("//bk:protNFe", xmlnsManager)


            For Each xmlnode In xmllist

                '  txtxmotivo.Text = xmlnode("infProt")("xMotivo").InnerText

                ' txtprotocolo.Text = xmlnode("infProt")("nProt").InnerText & "  " & Convert.ToDateTime(xmlnode("infProt")("dhRecbto").InnerText).ToString("dd/MM/yyyy HH:mm:ss")

            Next

            xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
            xmllist = xmldoc.SelectNodes("//bk:procEventoNFe", xmlnsManager)


            For Each xmlnode In xmllist


                '  xmlnode("evento")("infEvento")("detEvento")("descEvento").InnerText
                ' xmlnode("retEvento")("infEvento")("tpEvento").InnerText
                '  xmlnode("evento")("infEvento")("detEvento")("descEvento").InnerText



            Next

            lblconsultanfe.Text = "Retorno recebido, consulta Realizada !"


        Catch ex As Exception
            '  txtinfo_manifest.Text = ex.Message
            '     dgvpesquisanfe.Rows.Item(i).Cells(7).Value = "Sem retorno da SEFAZ"
            '     Button8.Enabled = True

            lblconsultanfe.Text = "Erro Conexao com WEbservice"

        End Try





    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        If nfecer = "" Then
            MsgBox("Não existe certificado Digital Selecionado !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If
        If mskchave.Text = "" Then
            MsgBox("Informe a Chave de acesso da NF-e", MsgBoxStyle.Exclamation, "Aviso !")
            mskchave.Focus()
            Exit Sub
        End If

        lblconsultanfe.Visible = True
        lblconsultanfe.Text = "Realizando consulta na SEFAZ, Aguarde...."

        Dim rotina3 As Thread
        Control.CheckForIllegalCrossThreadCalls = False
        rotina3 = New Thread(AddressOf consultanfce_sefaz)
        rotina3.SetApartmentState(ApartmentState.STA)
        rotina3.Start()

    End Sub

    Private Sub mskchave_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskchave.MaskInputRejected

    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        frm_envNFCe.ShowDialog()
    End Sub


    Private Sub LinkLabel8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        frmcancelanfe.ShowDialog()
    End Sub




#Region "''''Rotina para gerar danfeNFCe nfe"



#End Region


#Region "''''Rotina Cria DANFE NFCe"


    Public Sub rptDanfeNFCe(ByVal sender As Object, ByVal Relatorio As PrintPageEventArgs)
        Try
            caneta = New Pen(Brushes.DeepSkyBlue)
            Dim hashtable As Hashtable = New Hashtable()
            Dim TamLetra As Integer = 7
            Dim num1 As Integer = 0
            Dim clsPlugin As clsPlugin = New clsPlugin()
            margemEsq = 5.0F
            margemSup = 5.0F
            margemDir = 5.0F
            margemInf = 5.0F
            posicaoDaLinha = New Decimal()
            linhaAtual = 1
            fonteTitulo = New Font(tipoFonte, CSng(TamLetra), FontStyle.Bold)
            fonteTitulo2 = New Font(tipoFonte, CSng(6), FontStyle.Bold)
            fonteRodape = New Font(tipoFonte, CSng(TamLetra))
            fonteNormal = New Font(tipoFonte, CSng(TamLetra))
            fonteColuna = New Font(tipoFonte, CSng(TamLetra))
            caneta.Width = 2.0F
            caneta.LineJoin = LineJoin.Bevel

            Dim num2 As Integer = 55
            Dim xmlDocument As XmlDocument = New XmlDocument()
            xmlDocument.Load(txtcaminhoxml.Text)
            Dim innerText1 As String

            Try

                For Each xmlElement As XmlElement In xmlDocument.GetElementsByTagName("Reference")

                    Try

                        For Each childNode As XmlElement In xmlElement.ChildNodes
                            If Operators.CompareString(childNode.Name, "DigestValue", False) = 0 Then innerText1 = childNode.InnerText
                        Next

                    Finally
                        Dim enumerator As IEnumerator
                        If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                    End Try
                Next

            Finally
                Dim enumerator As IEnumerator
                If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
            End Try

            Dim attribute As String
            Dim str1 As String

            Try

                For Each xmlElement As XmlElement In xmlDocument.GetElementsByTagName("NFe")

                    Try

                        For Each childNode As XmlElement In xmlElement.ChildNodes

                            If Operators.CompareString(childNode.Name, "infNFe", False) = 0 Then
                                attribute = childNode.GetAttribute("Id")
                                str1 = childNode.GetAttribute("versao")
                            End If
                        Next

                    Finally
                        Dim enumerator As IEnumerator
                        If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                    End Try
                Next

            Finally
                Dim enumerator As IEnumerator
                If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
            End Try

            If Operators.CompareString(str1, "", False) = 0 Then str1 = "3.10"

            Try

                For Each xmlElement As XmlElement In xmlDocument.GetElementsByTagName("ide")

                    Try

                        For Each childNode As XmlElement In xmlElement.ChildNodes
                            hashtable.Add(CObj(childNode.Name), CObj(childNode.InnerText))
                        Next

                    Finally
                        Dim enumerator As IEnumerator
                        If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                    End Try
                Next

            Finally
                Dim enumerator As IEnumerator
                If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
            End Try



            Dim hex As String = Conversions.ToString(hashtable(CObj("dhEmi")))
            Dim str2 As String = Conversions.ToString(hashtable(CObj("tpAmb")))
            Dim Left As String = Conversions.ToString(hashtable(CObj("tpEmis")))
            Dim str3 As String = Conversions.ToString(hashtable(CObj("serie")))
            Dim str4 As String = Conversions.ToString(hashtable(CObj("nNF")))
            hashtable.Clear()
            Dim innerText2 As String

            Try

                For Each xmlElement As XmlElement In xmlDocument.GetElementsByTagName("dest")

                    Try

                        For Each childNode As XmlElement In xmlElement.ChildNodes
                            If Operators.CompareString(childNode.Name, "CNPJ", False) = 0 Or Operators.CompareString(childNode.Name, "CPF", False) = 0 Then innerText2 = childNode.InnerText
                        Next

                    Finally
                        Dim enumerator As IEnumerator
                        If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                    End Try
                Next

            Finally
                Dim enumerator As IEnumerator
                If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
            End Try

            Dim str5 As String = ""

            Try

                For Each xmlElement1 As XmlElement In xmlDocument.GetElementsByTagName("emit")

                    Try

                        For Each childNode As XmlElement In xmlElement1.ChildNodes
                            If Operators.CompareString(childNode.Name, "enderEmit", False) <> 0 Then hashtable.Add(CObj(childNode.Name), CObj(childNode.InnerText))
                        Next

                    Finally
                        Dim enumerator As IEnumerator
                        If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                    End Try

                    Try

                        For Each xmlElement2 As XmlElement In xmlElement1.GetElementsByTagName("enderEmit")

                            Try

                                For Each childNode As XmlElement In xmlElement2.ChildNodes
                                    hashtable.Add(CObj(childNode.Name), CObj(childNode.InnerText))
                                Next

                            Finally
                                Dim enumerator As IEnumerator
                                If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                            End Try
                        Next

                    Finally
                        Dim enumerator As IEnumerator
                        If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                    End Try
                Next

            Finally
                Dim enumerator As IEnumerator
                If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
            End Try

            Relatorio.PageSettings.Margins.Left = 200

            Dim num3 As Integer

            If File.Exists(mCaminhoLogo) Then
                Relatorio.Graphics.DrawImage(Image.FromFile(mCaminhoLogo), 2, 2, 40, 40)
                num3 = 36
            Else
                num3 = 0
            End If

            Dim str6 As String = Conversions.ToString(hashtable(CObj("UF")))
            Dim s1 As String = fFormata(Conversions.ToString(Operators.ConcatenateObject(CObj("CNPJ:"), hashtable(CObj("CNPJ")) & " - " & hashtable(CObj("xNome")))), " ", "D", num2, True, False)
            Relatorio.Graphics.DrawString(s1, fonteTitulo, Brushes.Black, margemEsq + CSng(num3), margemSup, New StringFormat())
            posicaoDaLinha += New Decimal(margemSup + CSng(linhaAtual) * fonteTitulo.GetHeight(Relatorio.Graphics))

            Dim local1 As Integer

            Dim num4 As Integer = linhaAtual + 1
            local1 = num4

            '  Dim s2 As String = fFormata(Conversions.ToString(hashtable(CObj("xNome"))), " ", "D", num4, True, False)
            '  Relatorio.Graphics.DrawString(s2, fonteTitulo, Brushes.Black, margemEsq + CSng(num4), Convert.ToSingle(posicaoDaLinha), New StringFormat())

            '  posicaoDaLinha += New Decimal(margemSup + CSng(linhaAtual) * fonteTitulo.GetHeight(Relatorio.Graphics))

            Dim s3 As String = fFormata(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(hashtable(CObj("xLgr")), CObj(", ")), hashtable(CObj("nro"))), CObj(", ")), hashtable(CObj("xBairro"))), CObj(" - ")), CObj(str6))), " ", "D", num2, True, False)
            Relatorio.Graphics.DrawString(s3, fonteTitulo, Brushes.Black, margemEsq + CSng(num4), Convert.ToSingle(posicaoDaLinha), New StringFormat())

            Dim local2 As Integer

            Dim num5 As Integer = linhaAtual + 1
            local2 = num5

            posicaoDaLinha += New Decimal(margemSup + CSng(linhaAtual) * fonteTitulo.GetHeight(Relatorio.Graphics))
            Dim s4 As String = fFormata("Documento Auxiliar de Nota Fiscal de Consumidor", " ", "C", (num5 - 10), True, False)
            Relatorio.Graphics.DrawString(s4, fonteTitulo2, Brushes.Black, margemEsq + CSng(num5), Convert.ToSingle(posicaoDaLinha), New StringFormat())
            hashtable.Clear()

            Dim local3 As Integer

            Dim num6 As Integer = linhaAtual + 1
            local3 = num6


            If Operators.CompareString(Strings.Trim(innerText2), "", False) <> 0 Then
                iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
                Dim strTexto As String = "CPF/CNPJ do Consumidor: " & innerText2
                iRet = FormataTX(Relatorio, strTexto, TamLetra, 0, 1)
            End If

            If Conversions.ToDouble(Left) = 9.0 Then
                Dim strTexto1 As String = fFormata("EMITIDA EM CONTINGENCIA", "=", "C", num6, True, False)
                iRet = FormataTX(Relatorio, strTexto1, TamLetra, 1, 1)
                Dim strTexto2 As String = fFormata("Pendente Liberacao", "=", "C", num6, True, False)
                iRet = FormataTX(Relatorio, strTexto2, TamLetra, 1, 1)
            End If

            If Not mReduzido Then
                Dim strTexto As String = "Código        Descrição        Qtd UN Vl Unit Vl Total"
                iRet = FormataTX(Relatorio, strTexto, TamLetra, 1, 1)
            End If


            Try

                For Each obj As Object In xmlDocument.GetElementsByTagName("det")
                    Dim objectValue As Object = RuntimeHelpers.GetObjectValue(obj)

                    Try

                        For Each xmlElement As XmlElement In CType(NewLateBinding.LateGet(objectValue, CType(Nothing, System.Type), "childNodes", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, System.Type()), CType(Nothing, Boolean())), IEnumerable)

                            If Operators.CompareString(xmlElement.Name, "prod", False) = 0 Then

                                Try

                                    For Each childNode As XmlElement In xmlElement.ChildNodes
                                        hashtable.Add(CObj(childNode.Name), CObj(childNode.InnerText))
                                    Next

                                Finally
                                    Dim enumerator As IEnumerator
                                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                                End Try

                                Dim num7 As Integer
                                num7 += 1
                                num1 += 1

                                If Not mReduzido Then
                                    Dim strTexto As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(CObj((Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(hashtable(CObj("cProd")), CObj(" ")), CObj(fFormata(Conversions.ToString(hashtable(CObj("xProd"))), " ", "D", 15, True, False)))) & " " + fFormata(Strings.FormatCurrency(CObj(Strings.Replace(Conversions.ToString(hashtable(CObj("qCom"))), ".", ",", 1, -1, CompareMethod.Binary)), 3, Microsoft.VisualBasic.TriState.[False], Microsoft.VisualBasic.TriState.[True], Microsoft.VisualBasic.TriState.UseDefault), " ", "E", 7, True, False).Replace("$", ""))), hashtable(CObj("uCom"))), CObj(fFormata(Conversions.ToString(hashtable(CObj("vUnCom"))), " ", "E", 7, True, False)))) & " " + fFormata(Conversions.ToString(hashtable(CObj("vProd"))), " ", "E", 7, True, False)
                                    iRet = FormataTX(Relatorio, strTexto, TamLetra, 1, 1)
                                    Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(hashtable(CObj("vDesc"))))
                                    Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(hashtable(CObj("vOutro"))))
                                End If

                                hashtable.Clear()
                                str5 = ""
                            ElseIf Operators.CompareString(xmlElement.Name, "infAdProd", False) = 0 Then
                                Dim strTexto As String = Strings.Trim(Strings.Replace(xmlElement.InnerText, ",", ".", 1, -1, CompareMethod.Binary)) & vbCrLf
                                iRet = FormataTX(Relatorio, strTexto, TamLetra, 1, 1)
                            End If
                        Next

                    Finally
                        Dim enumerator As IEnumerator
                        If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                    End Try
                Next

            Finally
                Dim enumerator As IEnumerator
                If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
            End Try

            iRet = FormataTX(Relatorio, "", TamLetra, 1, 1)
            Dim strTexto3 As String = "Qtde. Total de Itens" & fFormata(Strings.Format(CObj(num1), "000"), ".", "E", (num2 + 6), True, False)
            iRet = FormataTX(Relatorio, strTexto3, TamLetra, 1, 1)
            Dim texto1 As String
            Dim str7 As String
            Dim str8 As String

            Try

                For Each xmlElement1 As XmlElement In xmlDocument.GetElementsByTagName("total")

                    Try

                        For Each xmlElement2 As XmlElement In xmlElement1.GetElementsByTagName("ICMSTot")

                            Try

                                For Each childNode As XmlElement In xmlElement2.ChildNodes
                                    hashtable.Add(CObj(childNode.Name), CObj(childNode.InnerText))
                                Next

                            Finally
                                Dim enumerator As IEnumerator
                                If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                            End Try
                        Next

                    Finally
                        Dim enumerator As IEnumerator
                        If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                    End Try

                    texto1 = Conversions.ToString(hashtable(CObj("vTotTrib")))
                    str7 = Conversions.ToString(hashtable(CObj("vNF")))
                    str8 = Conversions.ToString(hashtable(CObj("vICMS")))
                    Dim texto2 As String = Conversions.ToString(hashtable(CObj("vOutro")))
                    Dim texto3 As String = Conversions.ToString(hashtable(CObj("vDesc")))
                    Dim s5 As String = Conversions.ToString(hashtable(CObj("vProd")))
                    str5 = strTexto3 & New String("-"c, num2) & vbCrLf

                    If Conversions.ToDouble(gVgPt(CObj(texto3), False)) > 0.0 Then
                        Dim strTexto1 As String = "SUBTOTAL R$" & fFormata(Conversions.ToString(Decimal.Divide(Decimal.Parse(s5), New Decimal(100L))), " ", "E", (num2 - 15), True, False)
                        iRet = FormataTX(Relatorio, strTexto1, TamLetra, 1, 1)
                        Dim strTexto2 As String = "Desconto R$" & fFormata(texto3, " ", "E", (num2 + 10), True, False)
                        iRet = FormataTX(Relatorio, strTexto2, TamLetra, 1, 1)
                        Dim strTexto4 As String = New String("-"c, 22)
                        iRet = FormataTX(Relatorio, strTexto4, TamLetra, 0, 1)
                    End If

                    If Conversions.ToDouble(gVgPt(CObj(texto2), False)) > 0.0 Then
                        Dim strTexto1 As String = "SUBTOTAL R$" & fFormata(Conversions.ToString(Decimal.Divide(Decimal.Parse(s5), New Decimal(100L))), " ", "E", (num2 - 15), True, False)
                        iRet = FormataTX(Relatorio, strTexto1, TamLetra, 0, 1)
                        Dim strTexto2 As String = "Acréscimo R$" & fFormata(texto2, " ", "E", (num2 + 10), True, False)
                        iRet = FormataTX(Relatorio, strTexto2, TamLetra, 0, 1)
                        Dim strTexto4 As String = strTexto2 & New String("-"c, 22) & vbCrLf
                        iRet = FormataTX(Relatorio, strTexto4, TamLetra, 0, 1)
                    End If
                    Dim strTexto5 As String = "Valor a Pagar R$" & fFormata(Conversions.ToString(hashtable(CObj("vNF"))), ".", "E", (num2 + 10), True, False)
                    iRet = FormataTX(Relatorio, strTexto5, TamLetra, 1, 1)
                    strTexto3 = "FORMA DE PAGAMENTO                     VALOR PAGO(R$)"
                    iRet = FormataTX(Relatorio, strTexto3, TamLetra, 0, 1)
                    hashtable.Clear()
                Next

            Finally
                Dim enumerator As IEnumerator
                If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
            End Try

            Dim xmlElement3 As XmlElement

            If Operators.CompareString(str1, "3.10", False) <> 0 Then

                If Operators.CompareString(str1, "4.00", False) = 0 Then

                    Try

                        For Each xmlElement1 As XmlElement In xmlDocument.GetElementsByTagName("pag")

                            Try

                                For Each childNode1 As XmlElement In xmlElement1.ChildNodes

                                    If Operators.CompareString(childNode1.Name, "detPag", False) = 0 Then

                                        Try

                                            For Each childNode2 As XmlElement In childNode1.ChildNodes
                                                hashtable.Add(CObj(childNode2.Name), CObj(childNode2.InnerText))

                                                If Operators.CompareString(childNode2.Name, "card", False) = 0 Then

                                                    Try

                                                        For Each xmlElement2 As XmlElement In xmlElement1.GetElementsByTagName("card")
                                                            xmlElement3 = xmlElement2
                                                        Next

                                                    Finally
                                                        Dim enumerator As IEnumerator
                                                        If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                                                    End Try
                                                End If
                                            Next

                                        Finally
                                            Dim enumerator As IEnumerator
                                            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                                        End Try
                                        ' MsgBox(Conversions.ToInteger(hashtable(CObj("tPag"))))
                                        Dim strTexto1 As String = RetMPDesc(Conversions.ToInteger(hashtable(CObj("tPag")))) + fFormata(Conversions.ToString(hashtable(CObj("vPag"))), ".", "E", (num2 + 38 - Strings.Len(RetMPDesc(Conversions.ToInteger(hashtable(CObj("tPag")))))), True, False)
                                        iRet = FormataTX(Relatorio, strTexto1, TamLetra, 0, 1)
                                        hashtable.Clear()
                                    End If
                                Next

                            Finally
                                Dim enumerator As IEnumerator
                                If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                            End Try
                        Next

                    Finally
                        Dim enumerator As IEnumerator
                        If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                    End Try
                End If
            Else

                Try

                    For Each xmlElement1 As XmlElement In xmlDocument.GetElementsByTagName("pag")

                        Try

                            For Each childNode As XmlElement In xmlElement1.ChildNodes
                                hashtable.Add(CObj(childNode.Name), CObj(childNode.InnerText))

                                If Operators.CompareString(childNode.Name, "card", False) = 0 Then

                                    Try

                                        For Each xmlElement2 As XmlElement In xmlElement1.GetElementsByTagName("card")
                                            xmlElement3 = xmlElement2
                                        Next

                                    Finally
                                        Dim enumerator As IEnumerator
                                        If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                                    End Try
                                End If
                            Next

                        Finally
                            Dim enumerator As IEnumerator
                            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                        End Try

                        Dim strTexto1 As String = RetMPDesc(Conversions.ToInteger(hashtable(CObj("tPag")))) + fFormata(Conversions.ToString(hashtable(CObj("vPag"))), ".", "E", (num2 + 38 - Strings.Len(RetMPDesc(Conversions.ToInteger(hashtable(CObj("tPag")))))), True, False)

                        iRet = FormataTX(Relatorio, strTexto1, TamLetra, 0, 1)
                        hashtable.Clear()
                    Next

                Finally
                    Dim enumerator As IEnumerator
                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                End Try
            End If

            If Conversions.ToDouble(str2) = 2.0 Then
                Dim strTexto1 As String = fFormata("EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL ", " ", "C", num2, True, False)
                iRet = FormataTX(Relatorio, strTexto1, TamLetra, 1, 1)
                str5 = ""
            End If
            iRet = FormataTX(Relatorio, "", TamLetra, 1, 1)

            Dim s6 As String = "Numero: " & Strings.Format(CObj(Conversions.ToLong(str4)), "000000000") & "  Serie: " + Strings.Format(CObj(Conversions.ToInteger(str3)) & "  Emissão: " + Strings.Format(CObj(Conversions.ToDate(hex)), ""))
            iRet = FormataTX(Relatorio, s6, TamLetra, 1, 1)


            Dim strTexto6 As String = fFormata("Consulte pela Chave de Acesso em", " ", "C", num2, True, False)
            iRet = FormataTX(Relatorio, strTexto6, TamLetra, 0, 1)
            Dim strTexto7 As String = fFormata("http://hinternet.sefaz.ba.gov.br/nfce/consulta", " ", "C", num2, True, False)
            iRet = FormataTX(Relatorio, strTexto7, TamLetra, 0, 1)

            Dim strTexto8 As String = fFormata("3119 0720 7310 0300 0102 5500 1000 0034 4110 0003 4416", " ", "C", num2, True, False)
            iRet = FormataTX(Relatorio, strTexto8, TamLetra, 0, 1)

            Dim Instance As Object = CObj(Strings.Split(hex, "T", -1, CompareMethod.Binary))
            cAux = Convert.ToDateTime(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Instance, New Object(0) {CObj(0)}, CType(Nothing, String())))).ToString("dd/MM/yyyy")
            iRet = FormataTX(Relatorio, "", TamLetra, 1, 1)
            iRet = FormataTX(Relatorio, "", TamLetra, 1, 1)

            Relatorio.Graphics.DrawString(s6, fonteTitulo, Brushes.Black, margemEsq + 102.0F, Convert.ToSingle(posicaoDaLinha), New StringFormat())
            Dim s7 As String = "Emissao: " & cAux & " " + Strings.Left(Conversions.ToString(NewLateBinding.LateIndexGet(Instance, New Object(0) {CObj(1)}, CType(Nothing, String()))), 8) & vbCrLf
            iRet = FormataTX(Relatorio, "", TamLetra, 1, 1)
            iRet = FormataTX(Relatorio, "", TamLetra, 1, 1)

            Relatorio.Graphics.DrawString(s7, fonteTitulo, Brushes.Black, margemEsq + 102.0F, Convert.ToSingle(posicaoDaLinha), New StringFormat())
            ' hex = StrToHex(hex)
            '  Dim str10 As String = If(innerText1 IsNot Nothing, mdlBematechNF.StrToHex(innerText1), mdlGeral.CalculaDigestValueXML_MDL(Me.strXml, True))
            cAux = "chNFe=" & Strings.Mid(attribute, 4) & "&nVersao=100&tpAmb=" & str2
            If Operators.CompareString(innerText2, "", False) <> 0 Then cAux = cAux & "&cDest=" & innerText2
            cAux = cAux & "&dhEmi=" & hex
            cAux = cAux & "&vNF=" & str7
            cAux = cAux & "&vICMS=" & str8
            '  cAux = cAux & "&digVal=" & str10
            ' cAux = cAux & "&cIdToken=" + Strings.Format(CObj(Conversion.Val(mdlGeral.NFCe_ID_Token)), "000000")
            '   Dim shA1Hash As String = mdlGeral.getSHA1Hash(cAux + Strings.UCase(mdlGeral.NFCe_CSC))
            Dim str9 As String = "http://hinternet.sefaz.ba.gov.br/nfce/consulta"

            Dim content As String = str9 & cAux & txtqrcodenfce.Text
            Relatorio.Graphics.DrawImage(New PictureBox() With {
                .Image = (CType(New QRCodeEncoder() With {
                    .QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE,
                    .QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M,
                    .QRCodeVersion = 0,
                    .QRCodeScale = 3
                }.Encode(content), Image))
            }.Image, margemEsq, Convert.ToSingle(posicaoDaLinha) - 2.0F * fonteNormal.GetHeight(Relatorio.Graphics), 100.0F, 100.0F)
            iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
            iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)

            If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "1", False) = 0 Then
                Dim innerText3 As String
                Dim innerText4 As String

                Try

                    For Each xmlElement1 As XmlElement In xmlDocument.GetElementsByTagName("infProt")

                        Try

                            For Each childNode As XmlElement In xmlElement1.ChildNodes
                                If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(childNode.Name, "dhRecbto", False) = 0 Then innerText3 = childNode.InnerText
                                If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(childNode.Name, "nProt", False) = 0 Then innerText4 = childNode.InnerText
                            Next

                        Finally
                            Dim enumerator As IEnumerator
                            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                        End Try
                    Next

                Finally
                    Dim enumerator As IEnumerator
                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                End Try

                Dim s5 As String = "Prot. Autorizacao:" & innerText4
                Relatorio.Graphics.DrawString(s5, fonteTitulo, Brushes.Black, margemEsq + 102.0F, Convert.ToSingle(posicaoDaLinha), New StringFormat())
                iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)

                Dim s8 As String = "Data Autorizacao:" & innerText3
                Relatorio.Graphics.DrawString(s8, fonteTitulo, Brushes.Black, margemEsq + 102.0F, Convert.ToSingle(posicaoDaLinha), New StringFormat())
                iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
            Else
                iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
                iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
                iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
            End If

            iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
            iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
            iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)


            Dim strTexto9 As String = " Trib. Totais Incidentes (lei Federal 12.741/2012) R$ " & fFormata(texto1, " ", "C", (num2 - 40), True, False) & vbCrLf
            iRet = FormataTX(Relatorio, strTexto9, TamLetra, 1, 1)



            For Each xmlElement1 As XmlElement In xmlDocument.GetElementsByTagName("infAdic")

                Try

                    For Each childNode As XmlElement In xmlElement1.ChildNodes

                        If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(childNode.Name, "infCpl", False) = 0 Then
                            Dim strTexto1 As String = fFormata("INFORMACOES ADICIONAIS DE INTERESSE DO CONTRIBUINTE", " ", "C", num2, True, False) & vbCrLf
                            iRet = FormataTX(Relatorio, strTexto1, TamLetra, 1, 1)
                            Dim strTexto2 As String = Strings.Replace(childNode.InnerText, "|", vbCrLf, 1, -1, CompareMethod.Binary)
                            iRet = FormataTX(Relatorio, strTexto2, TamLetra, 0, 1)
                        ElseIf Microsoft.VisualBasic.CompilerServices.Operators.CompareString(childNode.Name, "infAdFisco", False) = 0 Then
                            Dim strTexto1 As String = fFormata("Informacoes de Interesse do Fisco", " ", "C", num2, True, False) & vbCrLf
                            iRet = FormataTX(Relatorio, strTexto1, TamLetra, 1, 1)
                            Dim strTexto2 As String = Strings.Replace("" & childNode.InnerText & vbCrLf, "|", vbCrLf, 1, -1, CompareMethod.Binary)
                            iRet = FormataTX(Relatorio, strTexto2, TamLetra, 0, 1)
                            str5 = ""
                        End If
                    Next

                Finally
                    Dim enumerator As IEnumerator
                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                End Try
            Next

        Finally
            Dim enumerator As IEnumerator
            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
        End Try


        iRetTrImp = 1

    End Sub


    Public Sub ImprimirDANFeNFCeSpool(ByVal pstrXml As String, ByVal pstrTextoVias As String, ByVal pcPortaImp As String, ByVal piTpAmb As Integer, Optional ByVal iTipoImpViz As Integer = 1, Optional ByVal sversao_layout As String = "3.10")
        '  Try
        Me.strXml = pstrXml
        Me.strTextoVias = pstrTextoVias
        Me.cPortaImp = pcPortaImp
        Me.TPAmbiente = piTpAmb
        Me.versao_layout = sversao_layout
        Me.linhaAtual = 1
        Me.posicaoDaLinha = New Decimal()
        Dim printDocument As PrintDocument = New PrintDocument()
        Dim standardPrintController As StandardPrintController = New StandardPrintController()
        Dim num As Integer = CentimetrosParaCentesimasPolegada(0.05)
        printDocument.DefaultPageSettings.Margins = New Margins(num, num, num, num)
        printDocument.PrintController = CType(standardPrintController, PrintController)

        AddHandler printDocument.PrintPage, New Printing.PrintPageEventHandler(AddressOf Me.rptDanfeNFCe)

        Dim obj As Object = CObj(New PrintPreviewDialog())

        '  If iTipoImpViz = 2 Then
        Dim Instance As Object = obj
        NewLateBinding.LateSet(Instance, CType(Nothing, System.Type), "Document", New Object(0) {CObj(printDocument)}, CType(Nothing, String()), CType(Nothing, System.Type()))
        NewLateBinding.LateSet(Instance, CType(Nothing, System.Type), "WindowState", New Object(0) {CObj(FormWindowState.Maximized)}, CType(Nothing, String()), CType(Nothing, System.Type()))
        NewLateBinding.LateSetComplex(NewLateBinding.LateGet(Instance, CType(Nothing, System.Type), "PrintPreviewControl", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, System.Type()), CType(Nothing, Boolean())), CType(Nothing, System.Type), "Zoom", New Object(0) {CObj(1)}, CType(Nothing, String()), CType(Nothing, System.Type()), False, True)
        NewLateBinding.LateSet(Instance, CType(Nothing, System.Type), "Text", New Object(0) {CObj("PDVLinear - DANFe NFCe")}, CType(Nothing, String()), CType(Nothing, System.Type()))
        NewLateBinding.LateCall(Instance, CType(Nothing, System.Type), "ShowDialog", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, System.Type()), CType(Nothing, Boolean()), True)
        '  Else
        '  printDocument.Print()
        ' End If

        '    Catch ex As Exception
        'ProjectData.SetProjectError(ex)
        ' ProjectData.ClearProjectError()
        ' End Try
    End Sub

    Public Function FormataTX(ByRef Relatorio As PrintPageEventArgs, ByVal strTexto As String, ByVal TamLetra As Integer, ByVal Bold As Integer, ByVal NewLine As Integer) As Integer


        linhasPorPagina += (CInt(Math.Round((CDbl(Relatorio.MarginBounds.Height) / CDbl(fonteNormal.GetHeight(Relatorio.Graphics)) - 10.0))))
        posicaoDaLinha += New Decimal(margemSup + CSng(linhaAtual) * fonteNormal.GetHeight(Relatorio.Graphics))
        fonteNormal = If(Bold <> 1, New Font(tipoFonte, CSng(TamLetra)), New Font(tipoFonte, CSng(TamLetra), FontStyle.Bold))
        Relatorio.Graphics.DrawString(strTexto, fonteNormal, Brushes.Black, margemEsq, Convert.ToSingle(posicaoDaLinha), New StringFormat())


        If NewLine = 1 Then
            Dim local As Integer
            Dim num As Integer = (local = linhaAtual) + 1
            local = num
        End If

        Dim num1 As Integer
        Return num1
    End Function
#End Region

    Private Sub SurroundingSub()
        If rotina1 IsNot Nothing Then rotina1.Abort()
        ' rotina1 = New Thread(New ThreadStart(imprimirDanfe))
        '   rotina1.IsBackground = True
        '  rotina1.Priority = ThreadPriority.Lowest

        '  rotina1.Start()
    End Sub

    Public Function VersaoDotNet() As String
        Dim str As String = ""

        Try
            str = GetDotNetVersion.VersaoDOTNET()
        Catch ex As Exception
            '  clsGeral.CriarLog("Não foi possível verificar versão DOTNET - Erro: " & ex.Message & " / Linha: " + ex.StackTrace, "", "", False, False, False, False)
        End Try

        Return str
    End Function

    Private Sub Button2_MouseUp(sender As Object, e As MouseEventArgs) Handles Button2.MouseUp
        Me.ContextMenuStrip5.Show(TryCast(sender, Control), e.X, e.Y)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TesteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TesteToolStripMenuItem.Click
        Dim porta As String
        If txtcaminhoxml.Text = "" Then
            MsgBox("Carregue o XML para Gerar o DANFE NFC-e", MsgBoxStyle.Exclamation, "Atenção !")
            bntopen.Focus()
            Exit Sub
        End If

        If txtmodnfe.Text <> "65" Then
            MsgBox("Impressão exclusiva para NFC-e", MsgBoxStyle.Exclamation, "Atenção !")
            Exit Sub
        End If

        ' Dim dados As String
        '  dados = InputBox("Informe abaixo a Porta da Impressora Bematech MP-4200:", "Aviso !", " ")

        '  If dados = "" Or dados = " " Then
        'MsgBox("Operação Cancelada, porta Impressora não informada ?", MsgBoxStyle.Exclamation, "Atenção !")
        '  Exit Sub
        ' End If

        '''''''''''''''Rotina abixo abre porta impressora'''''''''''''''''''''''''''''''''''

        ImprimirXMLNFCeBematech.ConfiguraTaxaSerial(115200)

        Dim ports As String() = SerialPort.GetPortNames()
        Dim ret As Integer
        For Each port As String In ports

            ret = ImprimirXMLNFCeBematech.IniciaPorta(port)

            If ret = 1 Then
                porta = port
                ImprimirXMLNFCeBematech.FechaPorta()
            End If

        Next



        Dim RE As Integer
        RE = ImprimirXMLVenda(xmldoc.InnerXml, txttpAmb.Text.Substring(0, 1), porta, 1)

        If RE = 1 Then
            MsgBox("O DANFE da NFC-e foi impresso com Sucesso !", MsgBoxStyle.Information, "Aviso !")
        Else
            MsgBox("Ocorreu um erro na impressão do DANFE da NFC-e !", MsgBoxStyle.Exclamation, "Aviso !")
        End If

    End Sub

    Private Sub DANFENFCeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DANFENFCeToolStripMenuItem.Click

        If txtmodnfe.Text <> "65" Then
            MsgBox("Impressão exclusiva para NFC-e", MsgBoxStyle.Exclamation, "Atenção !")
            Exit Sub
        End If

        Dim dados As XmlDocument = New XmlDocument

        '  Try

        ''''''gera o danfe

        daNFCe(xmldoc.OuterXml)

    End Sub


    Private Sub DownloadXMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadXMLToolStripMenuItem.Click

        If nfecer = "" Then
            MsgBox("Não existe certificado Digital Selecionado !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If
        If mskchave.Text = "" Then
            MsgBox("Informe a Chave de acesso da NF-e", MsgBoxStyle.Exclamation, "Aviso !")
            mskchave.Focus()
            Exit Sub
        End If

        frminfo.Show()
        frminfo.txtinfo.Text = vbCrLf + "Realizando Download da NF No Self Host...."
        frminfo.Refresh()



        Dim newThread As System.Threading.Thread
        newThread = New Thread(AddressOf download)
        newThread.SetApartmentState(System.Threading.ApartmentState.STA)
        newThread.Start()
    End Sub

    Private Sub download()
        Dim ret As Boolean = False
        Dim arquivo As Dictionary(Of String, String) = New Dictionary(Of String, String)

        arquivo.Add("servico", "NFeDistribuicaoDFe")
        arquivo.Add("tipo_cons", "Dfe_cons_chave")
        arquivo.Add("cUF", "31")
        arquivo.Add("ambiente", "1")
        arquivo.Add("versao", "4.00")
        arquivo.Add("cnpj", cnpj_cert)
        arquivo.Add("chave", mskchave.Text)

        Dim retDistDFeInt As retDistDFeInt

        Try


            retDistDFeInt = processarWS_nfe(Of retDistDFeInt)(arquivo, "Web4_DFe/Consulta", "DFe")


            If retDistDFeInt.cStat = "138" Then
                MsgBox(retDistDFeInt.xMotivo, MsgBoxStyle.Information, "Aviso !")
                Invoke(Sub() frminfo.Close())

                For Each RetC In retDistDFeInt.loteDistDFeInt
                    xmldoc.LoadXml(DecompressGZip(RetC.Value))
                Next


                Dim svfd1 As New SaveFileDialog
                svfd1.Title = "Salvar Arquivo XML"
                svfd1.Filter = "Arquivo XML|.xml"
                'define o indice do filtro
                svfd1.FilterIndex = 0
                'Atribui um valor vazio ao nome do arquivo
                svfd1.FileName = mskchave.Text

                'Exibe a caixa de diálogo
                If svfd1.ShowDialog = Windows.Forms.DialogResult.OK Then

                    'Exibe a pasta selecionada
                    xmldoc.Save(svfd1.FileName)

                End If
                ret = True
            End If


            If ret = False Then
                MsgBox(retDistDFeInt.xMotivo, MsgBoxStyle.Exclamation, "Aviso !")
            End If

            Invoke(Sub() frminfo.Close())

        Catch ex As Exception
            Dim ret2 As String
            ret2 = processarWS_nfe(Of retDistDFeInt)(arquivo, "Web4_DFe/Consulta", "DFe")
            If ret2 <> "" Then
                MsgBox(ret2, MsgBoxStyle.Exclamation, "Aviso !")
            End If
            Invoke(Sub() frminfo.Close())
        End Try
    End Sub

    Private Sub ConsultaNFHostToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaNFHostToolStripMenuItem.Click

        If nfecer = "" Then
            MsgBox("Não existe certificado Digital Selecionado !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If
        If mskchave.Text = "" Then
            MsgBox("Informe a Chave de acesso da NF-e", MsgBoxStyle.Exclamation, "Aviso !")
            mskchave.Focus()
            Exit Sub
        End If

        frminfo.Show()
        frminfo.txtinfo.Text = vbCrLf + "Cosultando NF no Self Host Servidor...."
        frminfo.Refresh()



        Dim newThread As System.Threading.Thread
        newThread = New Thread(AddressOf consulta_statusNF_host_list)
        newThread.SetApartmentState(System.Threading.ApartmentState.STA)
        newThread.Start()

    End Sub
    Private Sub consulta_statusNF_host()

        Dim arquivo As Dictionary(Of String, String) = New Dictionary(Of String, String)


        arquivo.Add("ambiente", "1")
        arquivo.Add("nChave", mskchave.Text)

        Dim retConsSitNFe As retConsSitNFe
        Dim XmlRetornoSefaz As New XmlDocument()
        Dim ret As String
        Try



            '  Dim thread As Thread = New Thread(AddressOf processarWS)
            '  thread.Start(CObj(arquivo))
            ret = processarWS_nfe4(arquivo, "Web4_statusNFe/Consulta")


            If ret <> "" Then

                XmlRetornoSefaz.LoadXml(ret)

                retConsSitNFe = DeserializarNFe(Of retConsSitNFe)(XmlRetornoSefaz.OuterXml)

                Dim xmllist As System.Xml.XmlNodeList

                xmllist = XmlRetornoSefaz.GetElementsByTagName("protNFe")
                For Each xmlnode In xmllist
                    retConsSitNFe.xmlprot = xmlnode.OuterXml
                Next

                xmllist = XmlRetornoSefaz.GetElementsByTagName("procEventoNFe")
                For Each xmlnode In xmllist
                    retConsSitNFe.xmlprocevent = xmlnode.OuterXml
                Next

            End If

            If retConsSitNFe.cStat = "100" Then
                MsgBox("A Nota Fiscal Abaixo Esta Autorizada !" & vbCrLf & "Chave acesso: " & retConsSitNFe.chNFe & vbCrLf & "Protocolo Aut.: " & retConsSitNFe.protNFe.infProt.nProt & vbCrLf & "Status: " & retConsSitNFe.protNFe.infProt.xMotivo, MsgBoxStyle.Information, "Aviso ")
                ret = True
                Invoke(Sub() txtprotocolo.Text = retConsSitNFe.protNFe.infProt.nProt & " " & Convert.ToDateTime(retConsSitNFe.protNFe.infProt.dhRecbto).ToString("dd/MM/yyyy HH:mm:ss"))
                Invoke(Sub() txtxmotivo.Text = retConsSitNFe.protNFe.infProt.xMotivo)
            End If

            If retConsSitNFe.cStat = "101" Then
                ret = True
                MsgBox("A Nota Fiscal Abaixo foi Cancelada !" & vbCrLf & "Chave acesso: " & retConsSitNFe.chNFe & vbCrLf & "Protocolo Aut. Canc.: " & retConsSitNFe.procEventoNFe.retEvento.infEvento.nProt & vbCrLf & "Status: " & retConsSitNFe.procEventoNFe.retEvento.infEvento.xMotivo, MsgBoxStyle.Exclamation, "Aviso ")
                Invoke(Sub() txtprotocolocanc.Text = retConsSitNFe.procEventoNFe.retEvento.infEvento.nProt & " " & Convert.ToDateTime(retConsSitNFe.procEventoNFe.retEvento.infEvento.dhRegEvento).ToString("dd/MM/yyyy HH:mm:ss"))
                Invoke(Sub() txtxmotivocanc.Text = retConsSitNFe.procEventoNFe.retEvento.infEvento.xMotivo)

                xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & retConsSitNFe.xmlprocevent & "")
                xmldoc.Save(Application.StartupPath & "\XML_nfecanc\" & retConsSitNFe.chNFe & "-procEventoNFe.xml")
                MsgBox("XML de Cancelamento gerado na pasta: " & Application.StartupPath & "\XML_nfecanc", MsgBoxStyle.Information, "Aviso ")
            End If

            If ret = False Then
                MsgBox(retConsSitNFe.xMotivo, MsgBoxStyle.Exclamation, "Aviso !")
            End If
            Invoke(Sub() frminfo.Close())


        Catch ex As Exception

            If ret <> "" Then
                MsgBox(ret, MsgBoxStyle.Exclamation, "Aviso !")
            Else
                MsgBox("Erro local: " & ex.Message, MsgBoxStyle.Exclamation, "Aviso !")
            End If

            Invoke(Sub() frminfo.Close())
        End Try
    End Sub

    Private Sub consulta_statusNF_host_list()

        Dim arquivo As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim ret As Dictionary(Of String, String) = New Dictionary(Of String, String)

        arquivo.Add("ambiente", "1")
        arquivo.Add("nChave", mskchave.Text)

        Dim retConsSitNFe As retConsSitNFe
        Dim XmlRetornoSefaz As New XmlDocument()

        Try



            '  Dim thread As Thread = New Thread(AddressOf processarWS)
            '  thread.Start(CObj(arquivo))
            ret = processarWS_nfe4_list(arquivo, "Web4_statusNFe_list/Consulta")

            If ret("status") = "ok" Then

                If ret("cStat") = "100" Then
                    MsgBox("NF-e Autorizada !" & vbCrLf & "Chave acesso: " & ret("chNFe") & vbCrLf & "Protocolo Aut.: " & ret("nProt") & vbCrLf & "Status: " & ret("xMotivo2"), MsgBoxStyle.Information, "Aviso ")
                    Invoke(Sub() txtprotocolo.Text = ret("nProt") & " " & ret("dhRecbto"))
                    Invoke(Sub() txtxmotivo.Text = ret("xMotivo2"))
                End If

                If ret("cStat") = "101" Then
                    MsgBox("Nota Fiscal Cancelada !" & vbCrLf & "Chave acesso: " & ret("chNFe") & vbCrLf & "Protocolo Aut. Canc.: " & ret("nProt") & vbCrLf & "Status: " & ret("xMotivo2"), MsgBoxStyle.Exclamation, "Aviso ")
                    Invoke(Sub() txtprotocolocanc.Text = ret("nProt") & " " & ret("dhRegEvento"))
                    Invoke(Sub() txtxmotivocanc.Text = ret("xMotivo"))

                    xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & ret("xml") & "")
                    xmldoc.Save(Application.StartupPath & "\XML_nfecanc\" & ret("chNFe") & "-procEventoNFe.xml")
                    MsgBox("XML de Cancelamento gerado na pasta: " & Application.StartupPath & "\XML_nfecanc", MsgBoxStyle.Information, "Aviso ")
                End If
            Else
                MsgBox(ret("status"), MsgBoxStyle.Exclamation, "Aviso !")
            End If


            Invoke(Sub() frminfo.Close())


        Catch ex As Exception


            MsgBox(ret("status"), MsgBoxStyle.Exclamation, "Aviso erro Rotina: consulta_statusNF_host_list !")


            Invoke(Sub() frminfo.Close())
        End Try
    End Sub
    Private Sub ConsultarNFOnlineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultarNFOnlineToolStripMenuItem.Click

        If nfecer = "" Then
            MsgBox("Não existe certificado Digital Selecionado !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If
        If mskchave.Text = "" Then
            MsgBox("Informe a Chave de acesso da NF-e", MsgBoxStyle.Exclamation, "Aviso !")
            mskchave.Focus()
            Exit Sub
        End If

        frminfo.Show()
        frminfo.txtinfo.Text = vbCrLf + "Aguarde, Consultando Chave acesso NF SEFAZ Online..."
        frminfo.Refresh()

        Dim newThread As System.Threading.Thread
        newThread = New Thread(AddressOf consulta_statusNF_online)
        newThread.SetApartmentState(System.Threading.ApartmentState.STA)
        newThread.Start()
    End Sub

    Private Sub consulta_statusNF_online()
        Dim ret As Boolean = False
        Dim ws As Webservice4
        Dim retConsSitNFe As retConsSitNFe


        Try


            retConsSitNFe = WebS.ConsultaStatusNfe(mskchave.Text, "1")

            If retConsSitNFe.cStat = "100" Then
                MsgBox("A Nota Fiscal Abaixo Esta Autorizada !" & vbCrLf & "Chave acesso: " & retConsSitNFe.chNFe & vbCrLf & "Protocolo Aut.: " & retConsSitNFe.protNFe.infProt.nProt & vbCrLf & "Status: " & retConsSitNFe.protNFe.infProt.xMotivo, MsgBoxStyle.Information, "Aviso ")
                ret = True
                Invoke(Sub() txtprotocolo.Text = retConsSitNFe.protNFe.infProt.nProt & " " & Convert.ToDateTime(retConsSitNFe.protNFe.infProt.dhRecbto).ToString("dd/MM/yyyy HH:mm:ss"))
                Invoke(Sub() txtxmotivo.Text = retConsSitNFe.protNFe.infProt.xMotivo)
            End If

            If retConsSitNFe.cStat = "101" Then
                ret = True
                MsgBox("A Nota Fiscal Abaixo foi Cancelada !" & vbCrLf & "Chave acesso: " & retConsSitNFe.chNFe & vbCrLf & "Protocolo Aut. Canc.: " & retConsSitNFe.procEventoNFe.retEvento.infEvento.nProt & vbCrLf & "Status: " & retConsSitNFe.procEventoNFe.retEvento.infEvento.xMotivo, MsgBoxStyle.Exclamation, "Aviso ")
                Invoke(Sub() txtprotocolocanc.Text = retConsSitNFe.procEventoNFe.retEvento.infEvento.nProt & " " & Convert.ToDateTime(retConsSitNFe.procEventoNFe.retEvento.infEvento.dhRegEvento).ToString("dd/MM/yyyy HH:mm:ss"))
                Invoke(Sub() txtxmotivocanc.Text = retConsSitNFe.procEventoNFe.retEvento.infEvento.xMotivo)

                xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & retConsSitNFe.xmlprocevent & "")
                xmldoc.Save(Application.StartupPath & "\XML_nfecanc\" & retConsSitNFe.chNFe & "-procEventoNFe.xml")
                MsgBox("XML de Cancelamento gerado na pasta: " & Application.StartupPath & "\XML_nfecanc", MsgBoxStyle.Information, "Aviso ")
            End If

            If ret = False Then
                MsgBox(retConsSitNFe.xMotivo, MsgBoxStyle.Exclamation, "Aviso !")
            End If

            Invoke(Sub() frminfo.Close())
            If txtprotocolocanc.Text <> "" Then
                email_canc()
            End If


        Catch ex As Exception
            If reterro <> "" Then
                MsgBox(reterro, MsgBoxStyle.Exclamation, "Aviso !")
            Else
                MsgBox("Erro local Rotina: consulta_statusNF_online, " & ex.Message, MsgBoxStyle.Exclamation, "Aviso !")
            End If

            Invoke(Sub() frminfo.Close())
        End Try
    End Sub



    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        frm_pesquisacte.ShowDialog()
    End Sub

    Private Sub LinkLabel9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        If mskchave.Text = "" Then
            MsgBox("Informe a Chave de acesso da NF-e", MsgBoxStyle.Exclamation, "Aviso !")
            mskchave.Focus()
            Exit Sub
        End If

        If Directory.Exists(Application.StartupPath & "\XML_nfecanc") Then
            Directory.CreateDirectory(Application.StartupPath & "\XML_nfecanc")
        End If
        txtprotocolocanc.Visible = True


        '  If File.Exists(Application.StartupPath & "\XML_nfecanc\" & mskchave.Text & "-procEventoNFe.xml") = False Then

        frminfo.Show()
        frminfo.txtinfo.Text = vbCrLf + "Aguarde, Consultando Chave acesso NF SEFAZ Online..."
        frminfo.Refresh()

        Dim newThread As System.Threading.Thread
        newThread = New Thread(AddressOf consulta_statusNF_online)
        newThread.SetApartmentState(System.Threading.ApartmentState.STA)
        newThread.Start()

        '   End If



    End Sub

    Private Sub email_canc()
        Dim xmlretcanc As New XmlDocument()
        xmlretcanc.Load(Application.StartupPath & "\XML_nfecanc\" & mskchave.Text & "-procEventoNFe.xml")

        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode
        xmllist = xmlretcanc.GetElementsByTagName("retEvento")
        For Each xmlnode In xmllist
            txtprotocolocanc.Text = xmlnode("infEvento")("nProt").InnerText & " " & Convert.ToDateTime(xmlnode("infEvento")("dhRegEvento").InnerText).ToString("dd/MM/yyyy HH:mm:ss")
            txtxmotivocanc.Text = xmlnode("infEvento")("xMotivo").InnerText
        Next

        conectar_mysqlDFe()
        Dim insertSQL As MySqlCommand = New MySqlCommand("UPDATE nfe SET recibo_lanc = @recibo_lanc, obs= @obs, xml_nfe = @xml_nfe WHERE Chave_nfe = '" & mskchave.Text & "'", oConn)
        insertSQL.Parameters.Add(New MySqlParameter("xml_nfe", arq_bits(xmlretcanc.OuterXml)))
        insertSQL.Parameters.Add(New MySqlParameter("recibo_lanc", "c"))
        insertSQL.Parameters.Add(New MySqlParameter("obs", "NFe cancelada pelo emitente"))
        insertSQL.ExecuteNonQuery()

        oConn.Close()

        frmenvia_email.caminhoxml = Application.StartupPath & "\XML_nfecanc\" & mskchave.Text & "-procEventoNFe.xml"
        frmenvia_email.monta_nfe_cancelada(txtnomefor.Text, txtnomedest.Text, mskchave.Text,
        txtdataemissao.Text, txtprotocolocanc.Text)

        frmenvia_email.txtDestino.Text = txtemaildest.Text
        frmenvia_email.Text = "Envio de Notificação de Nota Fiscal Cancelada para destinataria"
        frmenvia_email.ShowDialog()
    End Sub

    Private Function arq_bits(ByVal xml As String) As Byte()
        Dim Arq_xml() As Byte
        If xml <> "" Then
            Dim encText As New System.Text.UTF8Encoding()
            Arq_xml = encText.GetBytes(xml)
        End If

        Return Arq_xml
    End Function
    Private Sub VisualizarEstruturaXMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizarEstruturaXMLToolStripMenuItem.Click
        Dim xml_NFe As New XmlDocument()

        Dim dialodest As New OpenFileDialog
        '  dialodest.Filter = "Arquivo XML NF-e (.xml)|*.xml"

        If dialodest.ShowDialog() = Windows.Forms.DialogResult.OK Then
            xml_NFe.Load(dialodest.FileName)

            Dim frmVisualizarcs As frmvisualizar_xml = New frmvisualizar_xml(xml_NFe.OuterXml)
            frmVisualizarcs.ShowDialog()
        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If txtnomefor.Text <> "" Then
            frmfornecedor.novo()

            frmfornecedor.txtnome.Text = txtnomefor.Text
            frmfornecedor.txtsigla.Text = txtnomefanfor.Text
            frmfornecedor.txtend.Text = txtendfor.Text
            frmfornecedor.txtnumero.Text = txtnumerofor.Text
            frmfornecedor.txtbairro.Text = txtbairrofor.Text
            frmfornecedor.mskcep.Text = mskcepfor.Text
            frmfornecedor.txtcodmunicipio.Text = txtcmunfor.Text
            frmfornecedor.txtcodpais.Text = txtcodpaisfor.Text
            frmfornecedor.mskcnpj.Text = mskcnpjfor.Text
            frmfornecedor.txtie.Text = txtiefor.Text
            frmfornecedor.txtim.Text = txtim.Text
            frmfornecedor.txtcontato.Text = ""
            frmfornecedor.txtemail.Text = txtemailfor.Text
            frmfornecedor.txtaliqsimples.Text = "0,00"
            frmfornecedor.lbldatacad.Text = Now.Date
            frmfornecedor.txtcidade.Text = txtcidadefor.Text
            frmfornecedor.txtuf.Text = txtuffor.Text

            If mskfonefor.Text <> "" Then
                frmfornecedor.dgvfone.Rows.Add(mskfonefor.Text, frmfornecedor.txtcod.Text)
            End If

            frmfornecedor.ShowDialog()
        End If
    End Sub

    Private Sub verifica_cadprod()
        For Each row As DataGridViewRow In Me.dgvgrid_xml.Rows

            Dim cod As String = ret_valor_campo("select * from codigo_barras where codigo_barra = '" & row.Cells("codbarra").Value & "'", "codigo_prod")
            If cod <> "" Then
                row.Cells("codigo_prod_grid").Value = cod
            End If

            If cod = "" Then
                cod = ret_valor_campo("select * from codigo_forprod where codigo_for = '" & row.Cells("codfor").Value & "'", "codigo_prod")
                row.Cells("codigo_prod_grid").Value = cod
            End If

            If row.Cells("codigo_prod_grid").Value = "" Then

                With Me.dgvgrid_xml.Rows(row.Index).DefaultCellStyle
                    .BackColor = Color.Red
                    .ForeColor = Color.White
                End With

            Else
                With Me.dgvgrid_xml.Rows(row.Index).DefaultCellStyle
                    .BackColor = Color.White
                    .ForeColor = Color.Black
                End With
            End If
        Next
    End Sub

    Private Sub dgvgrid_xml_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvgrid_xml.CellContentClick

    End Sub

    Private Sub ToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles Toolmenuproduto.Click

        If dgvgrid_xml.CurrentRow.Cells("codigo_prod_grid").Value = "" Then
            Dim pr As Integer = ProximoCodigo("produto", "codigo_prod")

            FrmProduto.novo()

            FrmProduto.txtdescricao.Text = dgvgrid_xml.CurrentRow.Cells("descricao").Value
            FrmProduto.txtprecofab.Text = dgvgrid_xml.CurrentRow.Cells("vlrunit").Value
            FrmProduto.cboorigem.SelectedText = 0
            FrmProduto.cboorigem.SelectedIndex = FrmProduto.cboorigem.FindString(dgvgrid_xml.CurrentRow.Cells("cst").Value.ToString.Substring(0, 1))
            FrmProduto.txtncm.SelectedText = 0
            FrmProduto.txtncm.SelectedIndex = FrmProduto.txtncm.FindString(dgvgrid_xml.CurrentRow.Cells("ncm").Value.ToString.Substring(0, 8))
            FrmProduto.txtcest.SelectedText = 0
            FrmProduto.txtcest.Text = dgvgrid_xml.CurrentRow.Cells("cest").Value.ToString

            FrmProduto.cbocsticms.SelectedText = 0
            FrmProduto.cbocsticms.SelectedIndex = FrmProduto.cbocsticms.FindString(dgvgrid_xml.CurrentRow.Cells("cst").Value.ToString)


            If dgvgrid_xml.CurrentRow.Cells("cst").Value.ToString.Length = 3 Then

                If dgvgrid_xml.CurrentRow.Cells("cst").Value.ToString.Substring(1, 2) = "60" Or dgvgrid_xml.CurrentRow.Cells("cst").Value.ToString.Substring(1, 2) = "70" Or dgvgrid_xml.CurrentRow.Cells("cst").Value.ToString.Substring(1, 2) = "10" Then
                    If empresa.scod_trib = 3 Then
                        FrmProduto.cbocsticms.Text = FrmProduto.cboorigem.Text & "60"
                    Else
                        FrmProduto.cbocsticms.Text = FrmProduto.cboorigem.Text & "500"
                    End If
                End If

                If dgvgrid_xml.CurrentRow.Cells("cst").Value.ToString.Substring(1, 2) = "00" Or dgvgrid_xml.CurrentRow.Cells("cst").Value.ToString.Substring(1, 2) = "20" Then

                    If empresa.scod_trib = 3 Then
                        FrmProduto.cbocsticms.Text = FrmProduto.cboorigem.Text & "00"
                    Else
                        FrmProduto.cbocsticms.Text = FrmProduto.cboorigem.Text & "102"
                    End If

                End If


            Else

                If dgvgrid_xml.CurrentRow.Cells("cst").Value.ToString.Substring(1, 3) = "201" Or dgvgrid_xml.CurrentRow.Cells("cst").Value.ToString.Substring(1, 3) = "202" Or dgvgrid_xml.CurrentRow.Cells("cst").Value.ToString.Substring(1, 3) = "500" Then

                    If empresa.scod_trib = 3 Then
                        FrmProduto.cbocsticms.Text = FrmProduto.cboorigem.Text & "60"
                    Else
                        FrmProduto.cbocsticms.Text = FrmProduto.cboorigem.Text & "500"
                    End If

                End If

                If dgvgrid_xml.CurrentRow.Cells("cst").Value.ToString.Substring(1, 3) = "101" Or dgvgrid_xml.CurrentRow.Cells("cst").Value.ToString.Substring(1, 3) = "102" Or dgvgrid_xml.CurrentRow.Cells("cst").Value.ToString.Substring(1, 3) = "103" Then
                    If empresa.scod_trib = 3 Then
                        FrmProduto.cbocsticms.Text = FrmProduto.cboorigem.Text & "00"
                    Else
                        FrmProduto.cbocsticms.Text = FrmProduto.cboorigem.Text & "102"
                    End If
                End If

            End If

            FrmProduto.cbocstpis_saida.SelectedText = 0
            FrmProduto.cbocstpis_saida.SelectedIndex = FrmProduto.cbocstpis_saida.FindString(dgvgrid_xml.CurrentRow.Cells("cstcofins").Value.ToString)

            FrmProduto.txtaliq_pis.Text = dgvgrid_xml.CurrentRow.Cells("aliqpis").Value
            FrmProduto.txtaliq_cofins.Text = dgvgrid_xml.CurrentRow.Cells("aliqcofins").Value

            If dgvgrid_xml.CurrentRow.Cells("codbarra").Value.ToString.Length = 13 Then
                FrmProduto.txtbarras.Text = dgvgrid_xml.CurrentRow.Cells("codbarra").Value
            End If

            FrmProduto.cbocst_ipi_saida.SelectedText = 0
            FrmProduto.cbocst_ipi_saida.SelectedIndex = FrmProduto.cbocst_ipi_saida.FindString(dgvgrid_xml.CurrentRow.Cells("cstipi").Value.ToString)

            FrmProduto.txtaliq_ipi.Text = dgvgrid_xml.CurrentRow.Cells("aliqipi").Value

            If FrmProduto.cbocstpis_saida.Text = "01" Then
                FrmProduto.cbocstpis_entrada.SelectedText = 0
                FrmProduto.cbocstpis_entrada.Text = "50"
            End If

            If FrmProduto.cbocstpis_saida.Text = "04" Then
                FrmProduto.cbocstpis_entrada.SelectedText = 0
                FrmProduto.cbocstpis_entrada.Text = "70"
            End If

            If FrmProduto.cbocstpis_saida.Text = "06" Or FrmProduto.txtaliq_pis.Text = "05" Then
                FrmProduto.cbocstpis_entrada.SelectedText = 0
                FrmProduto.cbocstpis_entrada.Text = "73"
            End If

            If FrmProduto.txtaliq_pis.Text = "49" Or FrmProduto.txtaliq_pis.Text = "03" Or FrmProduto.txtaliq_pis.Text = "02" Then
                FrmProduto.cbocstpis_entrada.SelectedText = 0
                FrmProduto.cbocstpis_entrada.Text = "99"
            End If

            If FrmProduto.cbocstpis_saida.Text = "07" Or FrmProduto.txtaliq_pis.Text = "09" Or FrmProduto.txtaliq_pis.Text = "09" Then
                FrmProduto.cbocstpis_entrada.SelectedText = 0
                FrmProduto.cbocstpis_entrada.Text = "99"
            End If

            If FrmProduto.cbocstpis_saida.Text = "01" Then

                FrmProduto.txtaliq_cofins.TabStop = True
                FrmProduto.txtaliq_pis.TabStop = True

            End If

            If dgvgrid_xml.CurrentRow.Cells("cstcofins").Value.ToString = "99" Then
                FrmProduto.cbocstpis_saida.SelectedText = 0
                FrmProduto.cbocstpis_saida.SelectedIndex = FrmProduto.cbocstpis_saida.FindString("49")
                FrmProduto.cbocstpis_entrada.SelectedText = 0
                FrmProduto.cbocstpis_entrada.SelectedIndex = FrmProduto.cbocstpis_entrada.FindString("99")
            End If

            FrmProduto.Text = "Cadastro de Produto NF-e"
            FrmProduto.Enabled = True

            FrmProduto.TabControl1.TabPages(0).Enabled = True
            FrmProduto.TabControl1.TabPages(1).Enabled = True
            FrmProduto.btnsalvar.Enabled = True
            FrmProduto.btnexcluir.Enabled = False
            FrmProduto.ShowDialog()

            If pr <> ProximoCodigo("produto", "codigo_prod") Then
                dgvgrid_xml.CurrentRow.Cells("codigo_prod_grid").Value = pr

                executa_query("INSERT INTO codigo_forprod (codigo_prod, codigo_for, cnpj_for) VALUES ('" & dgvgrid_xml.CurrentRow.Cells("codigo_prod_grid").Value & "', '" & dgvgrid_xml.CurrentRow.Cells("codfor").Value & "', '" & mskcnpjfor.Text & "')")

                verifica_cadprod()
            End If

        End If
    End Sub

    Private Sub AtualizarCodigoFornecedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AtualizarCodigoFornecedorToolStripMenuItem.Click
        frmcod_for.lblcnpj.Text = mskcnpjfor.Text
        frmcod_for.lblcodfor.Text = dgvgrid_xml.CurrentRow.Cells("codfor").Value
        frmcod_for.ShowDialog()
        verifica_cadprod()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        If verificar_regexiste("select * from cliente where cnpjcpf_cli = '" & mskcnpjfor.Text & "'") = "0" Then
            MsgBox("O fornecedor não esta cadastrado !", MsgBoxStyle.Exclamation, "Aviso !")
            TabControl_nfe.SelectTab(Tab_emi_dest)
            Exit Sub
        End If

        Dim prod As Boolean = False
        For Each row As DataGridViewRow In Me.dgvgrid_xml.Rows
            If row.Cells("codigo_prod_grid").Value = "" Then
                prod = True
            End If
        Next
        If prod = True Then
            MsgBox("Existem Produtos sem cadastro !", MsgBoxStyle.Exclamation, "Aviso !")
            TabControl_nfe.SelectTab(Tabitens)
            Exit Sub
        End If


        If verificar_regexiste("select * from nfe_e where chave_nfe = '" & mskchave.Text & "'") = "1" Then
            MsgBox("A Nota Fiscal já foi importada !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If



        frmnfe_entrada.lbluf.Text = txtuffor.Text
        frmnfe_entrada.NOVO()
        frmnfe_entrada.importacao()
        frmnfe_entrada.Panel_ini.Enabled = True
        frmnfe_entrada.Panel_item.Enabled = True
        frmnfe_entrada.ShowDialog()
    End Sub

    Private Sub LinkLabel10_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked
        frm_difalSG.ShowDialog()
    End Sub

    Private Sub CalcularPreçoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalcularPreçoToolStripMenuItem.Click
        carregar_par01()
        If importar_xml = False Then

            frmcalcpreco.txtcod_sg.Text = ""

            If dgvgrid_xml.CurrentRow.Cells("cod_sglinx").Value = "0" Then
                verifica_cadastro_sglinx()
            End If

            frmcalcpreco.txtcod_sg.Text = dgvgrid_xml.CurrentRow.Cells("cod_sglinx").Value


            If txtuffor.Text <> "MG" Then
                MsgBox("Nota Fiscal de outro estado, O calculo pode ser feito errado !", MsgBoxStyle.Exclamation, "Aviso !")
            End If

            frmcalcpreco.ShowDialog()
            

            frmcalcpreco.txtmargem.Text = "0,00 %"

        End If
    End Sub

    Private Sub txtdesc_item_TextChanged(sender As Object, e As EventArgs) Handles txtdesc_item.TextChanged

    End Sub

  
End Class