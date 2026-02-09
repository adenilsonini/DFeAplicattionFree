Imports System.Security.Cryptography.X509Certificates
Imports System.Xml
Imports System.Text
Imports System.Threading
Imports System.Drawing.Text
Imports System.IO
Imports System.Xml.Linq
Imports System.Data.OleDb
Imports System.Globalization
Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient
Imports DFe_aplicativo.C_WebService
Imports System.Reflection
Imports MessagingToolkit.QRCode.Codec
Public Class frmxml_nfe

    Dim WebS As New C_WebService
    Dim nrecibo As String, xmotivo As String, cstat As String, nprot As String



    Dim erro_validacao As Boolean = False
    Dim inclusao As Boolean = False

    Dim ind As Integer
    Dim rotina1 As Thread, rotina2 As Thread, rotina3 As Thread

    Dim retorevento As New RetRetorno
    Dim data_emissao As Date, data_saida As Date, data_prot As Date

    Public valortotaltrib As String, hora As String, uf As String, tiponota As String, Recibonfe As String, xmlnfe As String
    Public versao As String = "Emissor de Nota Fiscal Eletronica 4.00    |  Versao: " & Assembly.GetExecutingAssembly.GetName.Version.ToString & "  24-12-2019"

    Dim verifica As Boolean, reparaxml_auto As Boolean, contigencia As Boolean

    Dim rs As New ADODB.Recordset

    Dim xmldoc As New XmlDocument()
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

    ''' <summary>
    ''' ''''''''''''''' Rotina abaixo e exclusivamente para  importar devolucao
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub chave_devolucao()
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode
        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")



        xmllist = xmldoc.SelectNodes("//bk:infProt", xmlnsManager)

        For Each xmlnode In xmllist

            mskchvdevolucao.Text = xmlnode("chNFe").InnerText


            mskchvdevolucao.Mask = "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000"

        Next


    End Sub

    Private Sub carregar_totalnfe_devolucao()

        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode, xmlnode2 As System.Xml.XmlNode
        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist = xmldoc.SelectNodes("//bk:NFe", xmlnsManager)

        '---------------------------Abre dados do fornecedor-------------------------------------------------
        For Each xmlnode In xmllist
            txtvlrtotalbaseicms_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vBC").InnerText.Replace(".", ",")
            txtvlrtotalicms_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vICMS").InnerText.Replace(".", ",")
            txtvlrtotalbasest_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vBCST").InnerText.Replace(".", ",")
            txtvlrtotalst_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vST").InnerText.Replace(".", ",")
            txtvlrtotaldesc_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vDesc").InnerText.Replace(".", ",")
            txtvlrtotalfrete_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vFrete").InnerText.Replace(".", ",")
            txtvlrtotalpis_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vPIS").InnerText.Replace(".", ",")
            txtvlrtotalcofins_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vCOFINS").InnerText.Replace(".", ",")
            txtvrltotalipi_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vIPI").InnerText.Replace(".", ",")
            txtvlrtotalprod_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vProd").InnerText.Replace(".", ",")
            txtvlrtotalseg_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vSeg").InnerText.Replace(".", ",")
            txtvlrtotaloutras_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vOutro").InnerText.Replace(".", ",")
            txtvlrtotal_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vNF").InnerText.Replace(".", ",")
            txtvlrtotal_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vNF").InnerText.Replace(".", ",")
            If Not xmlnode("infNFe")("total")("ICMSTot")("vTotTrib") Is Nothing Then
                txtvlrtotalaproxtrib.Text = xmlnode("infNFe")("total")("ICMSTot")("vTotTrib").InnerText.Replace(".", ",")
            End If
            If Not xmlnode("infNFe")("total")("ICMSTot")("vFCPUFDest") Is Nothing Then
                txtvlrtotalvFCPUFDest.Text = xmlnode("infNFe")("total")("ICMSTot")("vFCPUFDest").InnerText.Replace(".", ",")
            End If
            If Not xmlnode("infNFe")("total")("ICMSTot")("vICMSUFDest") Is Nothing Then
                txtvlrtotalvICMSUFDest.Text = xmlnode("infNFe")("total")("ICMSTot")("vICMSUFDest").InnerText.Replace(".", ",")
            End If
            If Not xmlnode("infNFe")("total")("ICMSTot")("vICMSUFRemet") Is Nothing Then
                txtvlrtotalvICMSUFRemet.Text = xmlnode("infNFe")("total")("ICMSTot")("vICMSUFRemet").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("infNFe")("total")("ICMSTot")("vFCP") Is Nothing Then
                txtvlrtotalFCP.Text = xmlnode("infNFe")("total")("ICMSTot")("vFCP").InnerText.Replace(".", ",")
            End If
            If Not xmlnode("infNFe")("total")("ICMSTot")("vFCPST") Is Nothing Then
                txtvlrtotalFCPST.Text = xmlnode("infNFe")("total")("ICMSTot")("vFCPST").InnerText.Replace(".", ",")
            End If
            If Not xmlnode("infNFe")("total")("ICMSTot")("vFCPSTRet") Is Nothing Then
                txtvlrtotalFCPSTret.Text = xmlnode("infNFe")("total")("ICMSTot")("vFCPSTRet").InnerText.Replace(".", ",")
            End If

            '----------------------------------fecha aba Valores da NFe------------------------------------------------------
        Next

    End Sub

    ''' <summary>
    ''' ''''''''''''''' Rotina abaixo e para carregar os dados da nfe
    ''' </summary>
    ''' <remarks></remarks>

    Private Sub chave()
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode
        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        limpa_nfe()


        xmllist = xmldoc.SelectNodes("//bk:infProt", xmlnsManager)

        For Each xmlnode In xmllist


            mskchave.Text = xmlnode("chNFe").InnerText
            txtcoduf.Text = xmlnode("chNFe").InnerText.Substring(0, 2)
            data_prot = xmlnode("dhRecbto").InnerText
            txtprotocolo.Text = xmlnode("nProt").InnerText & "  " & data_prot
            msknprot.Text = xmlnode("nProt").InnerText
            txtxmotivo.Text = xmlnode("xMotivo").InnerText

            lblnfe.Visible = True
            lblnfe.Text = "NF-e Autorizada"
            lblnfe.BackColor = Color.Blue


            '----------gera o codigo de barra para chave de acesso
            ' codBarImagem.Image.Save(Application.StartupPath & "\codbarranfe.jpg")

            '  geracodbarra()
            '  salvacodbarra()
            mskchave.Mask = "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000"

        Next


        lblcanc.Visible = False
        lblmotcanc.Visible = False
        txtprotocolocanc.Visible = False
        txtxmotivocanc.Visible = False
    End Sub

    Private Sub dadosnfe()

        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode, xmlnode2 As System.Xml.XmlNode
        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist = xmldoc.SelectNodes("//bk:NFe", xmlnsManager)

        '---------------------------Abre dados do fornecedor-------------------------------------------------
        limpar_abas()

        For Each xmlnode In xmllist
            System.Diagnostics.Debug.WriteLine(xmlnode.InnerText)
            txtuffor.Text = xmlnode("infNFe")("emit")("enderEmit")("UF").InnerText

            txtpainel.Text = xmlnode("infNFe")("emit")("xNome").InnerText

            txtnomefor.Text = xmlnode("infNFe")("emit")("xNome").InnerText

            If Not xmlnode("infNFe")("emit")("CNPJ") Is Nothing Then

                mskcnpjfor.Mask = "00,000,000/0000-00"
                mskcnpjfor.Text = xmlnode("infNFe")("emit")("CNPJ").InnerText

            End If

            If Not xmlnode("infNFe")("emit")("CPF") Is Nothing Then

                mskcnpjfor.Mask = "000,000,000-00"
                mskcnpjfor.Text = xmlnode("infNFe")("emit")("CPF").InnerText

            End If

            txtendfor.Text = xmlnode("infNFe")("emit")("enderEmit")("xLgr").InnerText
            txtnumerofor.Text = xmlnode("infNFe")("emit")("enderEmit")("nro").InnerText
            txtiefor.Text = xmlnode("infNFe")("emit")("IE").InnerText
            txtbairrofor.Text = xmlnode("infNFe")("emit")("enderEmit")("xBairro").InnerText
            txtcidadefor.Text = xmlnode("infNFe")("emit")("enderEmit")("xMun").InnerText
            txtregime.Text = xmlnode("infNFe")("emit")("CRT").InnerText



            mskchave.Text = xmlnode("infNFe").Attributes.ItemOf("Id").InnerText.Substring(3, 44)
            '  lblversao.Text = "A Versão XML: " & xmlnode("infNFe").Attributes.ItemOf("versao").InnerText


            If txtcoduf.Text = "" Then
                txtcoduf.Text = mskchave.Text.Substring(0, 2)
            End If

            If Not xmlnode("infNFe")("emit")("IEST") Is Nothing Then
                txtinscst.Text = xmlnode("infNFe")("emit")("IEST").InnerText
            End If
            If Not xmlnode("infNFe")("emit")("IM") Is Nothing Then
                txtim.Text = xmlnode("infNFe")("emit")("IM").InnerText
            End If
            If Not xmlnode("infNFe")("emit")("CNAE") Is Nothing Then
                txtcnae.Text = xmlnode("infNFe")("emit")("CNAE").InnerText
            End If
            If Not xmlnode("infNFe")("emit")("xFant") Is Nothing Then
                txtnomefanfor.Text = xmlnode("infNFe")("emit")("xFant").InnerText
            End If
            If Not xmlnode("infNFe")("emit")("enderEmit")("xPais") Is Nothing Then
                txtpaisfor.Text = xmlnode("infNFe")("emit")("enderEmit")("xPais").InnerText
            End If
            If Not xmlnode("infNFe")("ide")("idDest") Is Nothing Then
                txtidDest.Text = xmlnode("infNFe")("ide")("idDest").InnerText
            End If
            If Not xmlnode("infNFe")("emit")("enderEmit")("cMun") Is Nothing Then
                txtcmunfor.Text = xmlnode("infNFe")("emit")("enderEmit")("cMun").InnerText
            End If
            If Not xmlnode("infNFe")("emit")("enderEmit")("cPais") Is Nothing Then
                txtcodpaisfor.Text = xmlnode("infNFe")("emit")("enderEmit")("cPais").InnerText
            End If
            mskcepfor.Text = xmlnode("infNFe")("emit")("enderEmit")("CEP").InnerText

            If Not xmlnode("infNFe")("emit")("enderEmit")("fone") Is Nothing Then
                mskfonefor.Mask = "00000000000"
                mskfonefor.Text = xmlnode("infNFe")("emit")("enderEmit")("fone").InnerText.ToString.TrimStart("0")

                If mskfonefor.Text.ToString.Length = 10 Then
                    mskfonefor.Mask = "(00) 0000-0000"
                End If
                If mskfonefor.Text.Length = 11 Then
                    mskfonefor.Mask = "(00) 0-0000-0000"
                End If

            End If


            If mskcnpjfor.Text = "10.962.965/0001-19" Then
                txtemailfor.Text = "Supermercadodoka@gmail.com"
            End If
            '---------------------------------------fecha dados do fornecedor-----------------------------------------------


            '---------------------------------------Abre dados do Destinatario---------------------------------------------

            If Not xmlnode("infNFe")("dest")("xFant") Is Nothing Then
                txtnomefandest.Text = xmlnode("infNFe")("dest")("xFant").InnerText
            End If
            If Not xmlnode("infNFe")("dest")("CNPJ") Is Nothing Then
                mskcnpjdest.Mask = "00,000,000/0000-00"
                mskcnpjdest.Text = xmlnode("infNFe")("dest")("CNPJ").InnerText
                mskcnpjcpf_cli.Text = mskcnpjdest.Text
            End If

            If Not xmlnode("infNFe")("dest")("CPF") Is Nothing Then
                mskcnpjdest.Mask = "000,000,000-00"
                mskcnpjdest.Text = xmlnode("infNFe")("dest")("CPF").InnerText
                mskcnpjcpf_cli.Text = mskcnpjdest.Text
            End If
            If Not xmlnode("infNFe")("dest")("enderDest")("xPais") Is Nothing Then
                txtpaisdest.Text = xmlnode("infNFe")("dest")("enderDest")("xPais").InnerText
            End If
            If Not xmlnode("infNFe")("dest")("email") Is Nothing Then
                txtemaildest.Text = xmlnode("infNFe")("dest")("email").InnerText
            End If
            If Not xmlnode("infNFe")("dest")("enderDest")("cMun") Is Nothing Then
                txtcmundest.Text = xmlnode("infNFe")("dest")("enderDest")("cMun").InnerText
            End If
            If Not xmlnode("infNFe")("dest")("enderDest")("cPais") Is Nothing Then
                txtcodpaisdest.Text = xmlnode("infNFe")("dest")("enderDest")("cPais").InnerText
            End If

            If Not xmlnode("infNFe")("dest")("enderDest")("fone") Is Nothing Then
                mskfonedest.Mask = "00000000000"
                mskfonedest.Text = xmlnode("infNFe")("dest")("enderDest")("fone").InnerText.ToString.TrimStart("0")

                If mskfonedest.Text.ToString.Length = 10 Then
                    mskfonedest.Mask = "(00) 0000-0000"
                End If
                If mskfonedest.Text.Length = 11 Then
                    mskfonedest.Mask = "(00) 0-0000-0000"
                End If

            End If


            txtnomedest.Text = xmlnode("infNFe")("dest")("xNome").InnerText
            txtnomecli.Text = xmlnode("infNFe")("dest")("xNome").InnerText
            txtenddest.Text = xmlnode("infNFe")("dest")("enderDest")("xLgr").InnerText
            txtnumerodest.Text = xmlnode("infNFe")("dest")("enderDest")("nro").InnerText

            If Not xmlnode("infNFe")("dest")("IE") Is Nothing Then
                txtiedest.Text = xmlnode("infNFe")("dest")("IE").InnerText
            End If

            txtindIEDest.Text = xmlnode("infNFe")("dest")("indIEDest").InnerText


            txtbairrodest.Text = xmlnode("infNFe")("dest")("enderDest")("xBairro").InnerText
            txtcidadedest.Text = xmlnode("infNFe")("dest")("enderDest")("xMun").InnerText

            If Not xmlnode("infNFe")("dest")("enderDest")("CEP") Is Nothing Then
                mskcepdest.Text = xmlnode("infNFe")("dest")("enderDest")("CEP").InnerText
                mskcepdest.Mask = "00,000-000"
            End If
            txtufdest.Text = xmlnode("infNFe")("dest")("enderDest")("UF").InnerText

            ' mskcnpjdest.Mask = "00,000,000/0000-00"
            '--------------------------------fecha dados do destinatario---------------------------------------------


            '--------------------------------Abre dados do Cabeçalho da Nfe--------------------------------------------

            If Not xmlnode("infNFe")("ide")("dhEmi") Is Nothing Then
                data_emissao = xmlnode("infNFe")("ide")("dhEmi").InnerText
                txtdataemissao.Text = data_emissao.ToString("dd/MM/yyyy HH:mm:ss")
            End If

            txtnumeronfe.Text = xmlnode("infNFe")("ide")("nNF").InnerText
            txtserienfe.Text = xmlnode("infNFe")("ide")("serie").InnerText
            txtmodelonfe.Text = xmlnode("infNFe")("ide")("mod").InnerText

            Try
                carrega_natureza(txttpNF.Text.Substring(0, 1))
            Catch ex As Exception

            End Try

            cbonat.Text = xmlnode("infNFe")("ide")("natOp").InnerText



            txttpNF.Text = xmlnode("infNFe")("ide")("tpNF").InnerText
            txttpEmis.Text = xmlnode("infNFe")("ide")("tpEmis").InnerText


            If xmlnode("infNFe")("ide")("finNFe").InnerText.Substring(0, 1) = "1" Then
                cbofinNFe.Text = "1-NFe normal"
            End If
            If xmlnode("infNFe")("ide")("finNFe").InnerText.Substring(0, 1) = "2" Then
                cbofinNFe.Text = "2-NFe complementar"
            End If
            If xmlnode("infNFe")("ide")("finNFe").InnerText.Substring(0, 1) = "3" Then
                cbofinNFe.Text = "3-NFe de ajuste"
            End If
            If xmlnode("infNFe")("ide")("finNFe").InnerText.Substring(0, 1) = "4" Then
                cbofinNFe.Text = "4-Devolução/Retorno"
            End If

            '  If xmlnode("infNFe")("ide")("indPag").InnerText.Substring(0, 1) = "0" Then
            'cboindPag.Text = "0-Pagamento à vista"
            '   End If
            ' If xmlnode("infNFe")("ide")("indPag").InnerText.Substring(0, 1) = "1" Then
            'cboindPag.Text = "1-Pagamento à prazo"
            '  End If
            ' If xmlnode("infNFe")("ide")("indPag").InnerText.Substring(0, 1) = "2" Then
            'cboindPag.Text = "2-Outros"
            '  End If

            If xmlnode("infNFe")("ide")("indFinal").InnerText = "0" Then
                cboindFinal.Text = "0-Não"
            End If
            If xmlnode("infNFe")("ide")("indFinal").InnerText = "1" Then
                cboindFinal.Text = "1-Consumidor Final"
            End If

            txttpAmb.Text = xmlnode("infNFe")("ide")("tpAmb").InnerText
            txtprocEmi.Text = xmlnode("infNFe")("ide")("procEmi").InnerText
            txtverProc.Text = xmlnode("infNFe")("ide")("verProc").InnerText

            '''''''''''''''''''Ler tag NFref'''''''''''''''''''''''''''''''''''''''''
            If Not xmlnode("infNFe")("ide")("NFref") Is Nothing Then

                If Not xmlnode("infNFe")("ide")("NFref")("refNFe") Is Nothing Then
                    mskchvdevolucao.Text = xmlnode("infNFe")("ide")("NFref")("refNFe").InnerText
                End If

                If Not xmlnode("infNFe")("ide")("NFref")("refECF") Is Nothing Then
                    TabControl_nfe.Controls.Add(aba_Cobertura_ECF)

                    For Each InnerNode2 As XmlNode In xmlnode("infNFe")("ide")
                        If InnerNode2.Name = "NFref" Then
                            For Each InnerNode3 As XmlNode In InnerNode2

                                dgvecf.Rows.Add(InnerNode3.ChildNodes(0).ChildNodes(0).InnerText, _
                                               InnerNode3.ChildNodes(1).ChildNodes(0).InnerText, _
                                               InnerNode3.ChildNodes(2).ChildNodes(0).InnerText)

                            Next
                        End If
                    Next

                End If
            End If




            If Not xmlnode("infNFe")("ide")("indPres") Is Nothing Then
                If xmlnode("infNFe")("ide")("indPres").InnerText = "9" Then
                    cboindPres.Text = "9-Não presencial, outros"
                ElseIf xmlnode("infNFe")("ide")("indPres").InnerText = "0" Then
                    cboindPres.Text = "0-Não se aplica (ex.: Nota Fiscal complementar ou de ajuste)"
                ElseIf xmlnode("infNFe")("ide")("indPres").InnerText = "1" Then
                    cboindPres.Text = "1-Operação presencial"
                ElseIf xmlnode("infNFe")("ide")("indPres").InnerText = "2" Then
                    cboindPres.Text = "2-Não presencial, internet"
                ElseIf xmlnode("infNFe")("ide")("indPres").InnerText = "3" Then
                    cboindPres.Text = "3-Não presencial, teleatendimento"
                ElseIf xmlnode("infNFe")("ide")("indPres").InnerText = "4" Then
                    cboindPres.Text = "4-NFC-e entrega em domicílio"
                    ' Else
                    ' cboindPres.SelectedIndex = xmlnode("infNFe")("ide")("indPres").InnerText
                End If
            End If

            If Not xmlnode("infNFe")("ide")("dhSaiEnt") Is Nothing Then
                data_saida = xmlnode("infNFe")("ide")("dhSaiEnt").InnerText
                data_saida.ToString("dd/MM/yyyy HH:mm:ss")
                txtdsaida.Text = data_saida
            End If

            If Not xmlnode("infNFe")("ide")("dSaiEnt") Is Nothing Then
                data_saida = xmlnode("infNFe")("ide")("dSaiEnt").InnerText
                data_saida.ToString("dd/MM/yyyy")
                txtdsaida.Text = data_saida
            End If

            If Not xmlnode("infNFe")("infAdic") Is Nothing Then

                If Not xmlnode("infNFe")("infAdic")("infAdFisco") Is Nothing Then
                    '  txtinfcompl.Width = 536
                    ' lbladifisco.Visible = True
                    '  txtadifisco.Visible = True
                    txtadifisco.Text = xmlnode("infNFe")("infAdic")("infAdFisco").InnerText
                End If

                If Not xmlnode("infNFe")("infAdic")("infCpl") Is Nothing Then
                    '  If txtadifisco.Text = "" Then
                    'lbladifisco.Visible = False
                    '   txtadifisco.Visible = False
                    '     txtinfcompl.Width = 967
                    ' End If
                    txtinfcompl.Text = xmlnode("infNFe")("infAdic")("infCpl").InnerText
                End If

            End If

            '----------------------------------Fecha dados do cabeçalho da nfe-------------------------------------------


            '----------------------------------Abre aba de Valores da Nfe------------------------------------------------
            uf = xmlnode("infNFe")("dest")("enderDest")("UF").InnerText
            txtvlrtotalbaseicms_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vBC").InnerText.Replace(".", ",")
            txtvlrtotalicms_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vICMS").InnerText.Replace(".", ",")
            txtvlrtotalbasest_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vBCST").InnerText.Replace(".", ",")
            txtvlrtotalst_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vST").InnerText.Replace(".", ",")
            txtvlrtotaldesc_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vDesc").InnerText.Replace(".", ",")
            txtvlrtotalfrete_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vFrete").InnerText.Replace(".", ",")
            txtvlrtotalpis_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vPIS").InnerText.Replace(".", ",")
            txtvlrtotalcofins_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vCOFINS").InnerText.Replace(".", ",")
            txtvrltotalipi_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vIPI").InnerText.Replace(".", ",")
            txtvlrtotalprod_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vProd").InnerText.Replace(".", ",")
            txtvlrtotalseg_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vSeg").InnerText.Replace(".", ",")
            txtvlrtotaloutras_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vOutro").InnerText.Replace(".", ",")
            txtvlrtotal_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vNF").InnerText.Replace(".", ",")
            txtvlrtotal_nfe.Text = xmlnode("infNFe")("total")("ICMSTot")("vNF").InnerText.Replace(".", ",")

            If Not xmlnode("infNFe")("total")("ICMSTot")("vTotTrib") Is Nothing Then
                txtvlrtotalaproxtrib.Text = xmlnode("infNFe")("total")("ICMSTot")("vTotTrib").InnerText.Replace(".", ",")
            End If
            If Not xmlnode("infNFe")("total")("ICMSTot")("vFCPUFDest") Is Nothing Then
                txtvlrtotalvFCPUFDest.Text = xmlnode("infNFe")("total")("ICMSTot")("vFCPUFDest").InnerText.Replace(".", ",")
            End If
            If Not xmlnode("infNFe")("total")("ICMSTot")("vICMSUFDest") Is Nothing Then
                txtvlrtotalvICMSUFDest.Text = xmlnode("infNFe")("total")("ICMSTot")("vICMSUFDest").InnerText.Replace(".", ",")
            End If
            If Not xmlnode("infNFe")("total")("ICMSTot")("vICMSUFRemet") Is Nothing Then
                txtvlrtotalvICMSUFRemet.Text = xmlnode("infNFe")("total")("ICMSTot")("vICMSUFRemet").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("infNFe")("total")("ICMSTot")("vFCP") Is Nothing Then
                txtvlrtotalFCP.Text = xmlnode("infNFe")("total")("ICMSTot")("vFCP").InnerText.Replace(".", ",")
            End If
            If Not xmlnode("infNFe")("total")("ICMSTot")("vFCPST") Is Nothing Then
                txtvlrtotalFCPST.Text = xmlnode("infNFe")("total")("ICMSTot")("vFCPST").InnerText.Replace(".", ",")
            End If
            If Not xmlnode("infNFe")("total")("ICMSTot")("vFCPSTRet") Is Nothing Then
                txtvlrtotalFCPSTret.Text = xmlnode("infNFe")("total")("ICMSTot")("vFCPSTRet").InnerText.Replace(".", ",")
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


        Dim xmllist5 As System.Xml.XmlNodeList
        Dim xmlnode5 As System.Xml.XmlNode
        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist5 = xmldoc.SelectNodes("//bk:NFe", xmlnsManager)
        Try



            For Each xmlnode5 In xmllist5

                If Not xmlnode5("infNFe")("cobr") Is Nothing Then
                    If Not xmlnode5("infNFe")("cobr")("dup") Is Nothing Then
                        Dim xmllist As System.Xml.XmlNodeList
                        Dim xmlnode As System.Xml.XmlNode
                        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
                        xmllist = xmldoc.SelectNodes("//bk:dup", xmlnsManager)

                        parcela = "0"
                        For Each xmlnode In xmllist

                            parcela = parcela + 1
                            datavenc = xmlnode("dVenc").InnerText

                            If Not xmlnode("nDup") Is Nothing Then
                                dgvfatura.Rows.Add(parcela, xmlnode("nDup").InnerText.Replace(".", ","), xmlnode("vDup").InnerText.Replace(".", ","), datavenc.ToString("dd/MM/yyyy"))


                            Else
                                dgvfatura.Rows.Add(parcela, parcela, xmlnode("vDup").InnerText.Replace(".", ","), datavenc.ToString("dd/MM/yyyy"))

                            End If

                        Next
                    End If
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub dadostrasp()
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode
        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist = xmldoc.SelectNodes("//bk:NFe", xmlnsManager)

        For Each xmlnode In xmllist
            System.Diagnostics.Debug.WriteLine(xmlnode.InnerText)

            If Not xmlnode("infNFe")("transp")("modFrete") Is Nothing Then
                cbomodfrete.Text = retorna_mod_frete(xmlnode("infNFe")("transp")("modFrete").InnerText)
            End If

            If Not xmlnode("infNFe")("transp")("vol") Is Nothing Then
                If Not xmlnode("infNFe")("transp")("vol")("qVol") Is Nothing Then
                    txtQvol.Text = xmlnode("infNFe")("transp")("vol")("qVol").InnerText
                End If
                If Not xmlnode("infNFe")("transp")("vol")("esp") Is Nothing Then
                    txtesp.Text = xmlnode("infNFe")("transp")("vol")("esp").InnerText
                End If
                If Not xmlnode("infNFe")("transp")("vol")("marca") Is Nothing Then
                    txtmarca.Text = xmlnode("infNFe")("transp")("vol")("marca").InnerText
                End If

                If Not xmlnode("infNFe")("transp")("vol")("nVol") Is Nothing Then
                    txtnvol.Text = xmlnode("infNFe")("transp")("vol")("nVol").InnerText
                End If

                If Not xmlnode("infNFe")("transp")("vol")("pesoB") Is Nothing Then
                    txtpesob.Text = xmlnode("infNFe")("transp")("vol")("pesoB").InnerText.Replace(".", ",")
                End If
                If Not xmlnode("infNFe")("transp")("vol")("pesoL") Is Nothing Then
                    txtpesol.Text = xmlnode("infNFe")("transp")("vol")("pesoL").InnerText.Replace(".", ",")
                End If
            End If

            If Not xmlnode("infNFe")("transp")("transporta") Is Nothing Then

                If Not xmlnode("infNFe")("transp")("transporta")("CNPJ") Is Nothing Then
                    mskcnpjtrp.Mask = "00,000,000/0000-00"
                    mskcnpjtrp.Text = xmlnode("infNFe")("transp")("transporta")("CNPJ").InnerText

                End If
                If Not xmlnode("infNFe")("transp")("transporta")("CPF") Is Nothing Then
                    mskcnpjtrp.Mask = "000,000,000-00"
                    mskcnpjtrp.Text = xmlnode("infNFe")("transp")("transporta")("CPF").InnerText

                End If
                If Not xmlnode("infNFe")("transp")("transporta")("xNome") Is Nothing Then
                    txtnometrp.Text = xmlnode("infNFe")("transp")("transporta")("xNome").InnerText
                End If
                If Not xmlnode("infNFe")("transp")("transporta")("Bairro") Is Nothing Then
                    txtbairrotrp.Text = xmlnode("infNFe")("transp")("transporta")("Bairro").InnerText
                End If
                If Not xmlnode("infNFe")("transp")("transporta")("xEnder") Is Nothing Then
                    txtendtrp.Text = xmlnode("infNFe")("transp")("transporta")("xEnder").InnerText
                End If
                If Not xmlnode("infNFe")("transp")("transporta")("IE") Is Nothing Then
                    txtietrp.Text = xmlnode("infNFe")("transp")("transporta")("IE").InnerText
                End If
                If Not xmlnode("infNFe")("transp")("transporta")("xMun") Is Nothing Then
                    txtcidadetrp.Text = xmlnode("infNFe")("transp")("transporta")("xMun").InnerText
                End If
                If Not xmlnode("infNFe")("transp")("transporta")("UF") Is Nothing Then
                    txtuftrp.Text = xmlnode("infNFe")("transp")("transporta")("UF").InnerText
                End If


                If Not xmlnode("infNFe")("transp")("veicTransp") Is Nothing Then
                    If Not xmlnode("infNFe")("transp")("veicTransp")("placa") Is Nothing Then
                        'txtplacatrp.Text = xmlnode("infNFe")("transp")("veicTransp")("placa").InnerText
                    End If

                    If Not xmlnode("infNFe")("transp")("veicTransp")("UF") Is Nothing Then
                        '  txtufplacatrp.Text = xmlnode("infNFe")("transp")("veicTransp")("UF").InnerText
                    End If

                    If Not xmlnode("infNFe")("transp")("veicTransp")("RNTC") Is Nothing Then
                        '  txtantt.Text = xmlnode("infNFe")("transp")("veicTransp")("RNTC").InnerText
                    End If
                End If

            End If
        Next
    End Sub

    Private Sub itens_nfe()
        Dim i As Integer
        Dim datavmed As Date
        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        Dim xmlList As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode
        xmlList = xmldoc.SelectNodes("//bk:det", xmlnsManager)

        dgvgrid_xml.Rows.Clear()



        chklote.Checked = False

        For Each xmlnode In xmlList
            limpar_itens()

            Try
                txtcodfor_item.Text = xmlnode("prod")("cProd").InnerText.Replace("-", "")
                If xmlnode("prod")("cProd").InnerText.Length > "8" Then
                    txtcodfor_item.Text = Format(CDec(txtcodfor_item.Text), "00000000")
                End If
            Catch ex As Exception
                txtcodfor_item.Text = xmlnode("prod")("cProd").InnerText
            End Try

            txtnr.Text = xmlnode.Attributes.ItemOf("nItem").InnerText

            txtdesc_item.Text = xmlnode("prod")("xProd").InnerText
            txtvlrunit_item.Text = xmlnode("prod")("vUnCom").InnerText
            txtvlrunit_item.Text = Format(CDec(txtvlrunit_item.Text.Replace(".", ",")), "#,##0.0000")
            txtqtde_item.Text = xmlnode("prod")("qCom").InnerText
            txtqtdecx_item.Text = "1"
            txtvlrtotal_item.Text = xmlnode("prod")("vProd").InnerText.Replace(".", ",")
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

                lbltagcst.Location = New Point(157, 41)
            Else
                lbltagcst.Text = "CST:"
                lbltagcst.Location = New Point(173, 43)
            End If

            txtcst_item.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("orig").InnerText + xmlnode("imposto")("ICMS").ChildNodes.Item(0).ChildNodes.Item(1).InnerText

            If Not xmlnode("prod")("vDesc") Is Nothing Then
                txtvlrdesc_item.Text = xmlnode("prod")("vDesc").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("prod")("vFrete") Is Nothing Then
                txtvlrfrete_item.Text = xmlnode("prod")("vFrete").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("prod")("vOutro") Is Nothing Then
                txtvlroutros_item.Text = xmlnode("prod")("vOutro").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("prod")("med") Is Nothing Then
                chklote.Checked = True
                txtlote_item.Text = xmlnode("prod")("med")("nLote").InnerText
            End If

            If Not xmlnode("prod")("med") Is Nothing Then
                txtpmc_item.Text = xmlnode("prod")("med")("vPMC").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("prod")("med") Is Nothing Then
                datavmed = xmlnode("prod")("med")("dVal").InnerText
                mskdvenc_item.Text = datavmed.ToString("dd/MM/yyyy")
            End If

            If Not xmlnode("imposto")("vTotTrib") Is Nothing Then
                txtvlrtrib_item.Text = xmlnode("imposto")("vTotTrib").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vICMSST") Is Nothing Then
                txtvlrst_item.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vICMSST").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vICMSSTRet") Is Nothing Then
                txtvlrst_item.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vICMSSTRet").InnerText.Replace(".", ",")
                ' txtvlrstprod.Text = "0,00"
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vBCSTRet") Is Nothing Then
                txtbasest_item.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vBCSTRet").InnerText.Replace(".", ",")
                '  txtbasestprod.Text = "0,00"
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vBCST") Is Nothing Then
                txtbasest_item.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vBCST").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vICMSST") Is Nothing Then
                txtvlrst_item.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vICMSST").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vBCST") Is Nothing Then
                txtbst.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vBCST").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pICMSST") Is Nothing Then
                ' txtaliqst.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pICMSST").InnerText
                cboaliqst_item.Text = Format(CDec(xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pICMSST").InnerText.Replace(".", ",")), "#,##0.00")
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pMVAST") Is Nothing Then
                txtmva_item.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pMVAST").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pICMS") Is Nothing Then
                '  txtaliqicmsprod.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pICMS").InnerText
                cboaliqicms_item.Text = Format(CDec(xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pICMS").InnerText.Replace(".", ",")), "#,##0.00")
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vICMS") Is Nothing Then
                txtvlricms_item.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vICMS").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pCredSN") Is Nothing Then
                cboaliqicms_item.Text = Format(CDec(xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pCredSN").InnerText.Replace(".", ",")), "#,##0.00")
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vCredICMSSN") Is Nothing Then
                txtvlricms_item.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vCredICMSSN").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vBC") Is Nothing Then
                txtbaseicms_item.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vBC").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pRedBC") Is Nothing Then
                txtbaseredicms_item.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pRedBC").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("imposto")("ICMS")("ICMS20") Is Nothing Then
                txtbaseredicms_item.Text = xmlnode("imposto")("ICMS")("ICMS20")("pRedBC").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vBCFCP") Is Nothing Then
                txtvBCFCP.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vBCFCP").InnerText.Replace(".", ",")
            End If
            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vBCFCPST") Is Nothing Then
                txtvBCFCPST.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vBCFCPST").InnerText.Replace(".", ",")
            End If
            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pFCP") Is Nothing Then
                txtpFCP.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pFCP").InnerText.Replace(".", ",")
            End If
            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pFCPST") Is Nothing Then
                txtpFCPST.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("pFCPST").InnerText.Replace(".", ",")
            End If
            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vFCP") Is Nothing Then
                txtvFCP.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vFCP").InnerText.Replace(".", ",")
            End If
            If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vFCPST") Is Nothing Then
                txtvFCPST.Text = xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vFCPST").InnerText.Replace(".", ",")
            End If

            txtcstpis_item.Text = xmlnode("imposto")("PIS").ChildNodes.Item(0).ChildNodes.Item(0).InnerText
            txtcstcofins_item.Text = xmlnode("imposto")("COFINS").ChildNodes.Item(0).ChildNodes.Item(0).InnerText

            If Not xmlnode("imposto")("PIS").ChildNodes.Item(0).ChildNodes.Item(2) Is Nothing Then
                txtaliqpis_item.Text = xmlnode("imposto")("PIS").ChildNodes.Item(0).ChildNodes.Item(2).InnerText.Replace(".", ",")
            End If

            If Not xmlnode("imposto")("PIS").ChildNodes.Item(0)("vPIS") Is Nothing Then
                txtvlrpis_item.Text = xmlnode("imposto")("PIS").ChildNodes.Item(0)("vPIS").InnerText.Replace(".", ",")
            End If


            If Not xmlnode("imposto")("PISST") Is Nothing Then
                txtaliqpis_item.Text = xmlnode("imposto")("PISST")("pPIS").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("imposto")("PISST") Is Nothing Then
                txtvlrpis_item.Text = xmlnode("imposto")("PISST")("vPIS").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("imposto")("COFINSST") Is Nothing Then
                txtaliqcofins_item.Text = xmlnode("imposto")("COFINSST")("pCOFINS").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("imposto")("COFINSST") Is Nothing Then
                txtvlrcofins_item.Text = xmlnode("imposto")("COFINSST")("vCOFINS").InnerText.Replace(".", ",")
            End If



            If Not xmlnode("imposto")("COFINS").ChildNodes.Item(0).ChildNodes.Item(2) Is Nothing Then
                txtaliqcofins_item.Text = xmlnode("imposto")("COFINS").ChildNodes.Item(0).ChildNodes.Item(2).InnerText.Replace(".", ",")
            End If

            If Not xmlnode("imposto")("COFINS").ChildNodes.Item(0)("vCOFINS") Is Nothing Then
                txtvlrcofins_item.Text = xmlnode("imposto")("COFINS").ChildNodes.Item(0)("vCOFINS").InnerText.Replace(".", ",")
            End If

            If Not xmlnode("imposto")("IPI") Is Nothing Then
                If Not xmlnode("imposto")("IPI").ChildNodes.Item(1)("vIPI") Is Nothing Then
                    txtvlripi_item.Text = xmlnode("imposto")("IPI").ChildNodes.Item(1)("vIPI").InnerText.Replace(".", ",")
                End If
                If Not xmlnode("imposto")("IPI").ChildNodes.Item(1)("pIPI") Is Nothing Then
                    txtaliqIPI_item.Text = xmlnode("imposto")("IPI").ChildNodes.Item(1)("pIPI").InnerText.Replace(".", ",")
                End If
                If Not xmlnode("imposto")("IPI").ChildNodes.Item(1)("CST") Is Nothing Then
                    txtcstipi_item.Text = xmlnode("imposto")("IPI").ChildNodes.Item(1)("CST").InnerText
                End If
            End If

            If Not xmlnode("imposto")("IPI") Is Nothing Then
                If Not xmlnode("imposto")("IPI")("IPITrib") Is Nothing Then
                    If Not xmlnode("imposto")("IPI")("IPITrib")("vIPI") Is Nothing Then
                        txtvlripi_item.Text = xmlnode("imposto")("IPI")("IPITrib")("vIPI").InnerText.Replace(".", ",")
                    End If
                    If Not xmlnode("imposto")("IPI")("IPITrib")("pIPI") Is Nothing Then
                        txtaliqIPI_item.Text = xmlnode("imposto")("IPI")("IPITrib")("pIPI").InnerText.Replace(".", ",")
                    End If
                    If Not xmlnode("imposto")("IPI")("IPITrib")("CST") Is Nothing Then
                        txtcstipi_item.Text = xmlnode("imposto")("IPI")("IPITrib")("CST").InnerText
                    End If
                End If
            End If

            If Not xmlnode("infAdProd") Is Nothing Then
                txtinfoadic_item.Text = xmlnode("infAdProd").InnerText
            End If


            adiciona_iten_grid()

            '  dgvgrid_xml.Rows.Add(txtcodfor.Text, txtdesc.Text, txtqtde.Text, txtvlrunit_item.Text, txtvlrtotal_item.Text, txtcodbarra.Text, txtncm.Text, txtcfop.Text, txtcst.Text, _
            '      txtaliqicmsprod.Text, txtvlricms_item.Text, txtvlrst_item.Text, txtcstpis.Text, txtaliqpis.Text, txtvlrpis_item.Text, txtcstcofins.Text, txtaliqcofins.Text, txtvlrcofins_item.Text, _
            '        txtun.Text, txtmva.Text, txtaliqst.Text, txtcstipi.Text, txtvlripi_item.Text, txtvlrdesc_item.Text, txtlote.Text, txtpmc.Text, mskdvenc.Text, txtbaseicmsprod.Text, txtbasestprod.Text, _
            '     txtbaseredicms.Text, txtaliqIPI.Text, txtvlrtrib_item.Text, txtinfoadicprod.Text, "", txtvlroutrositem.Text, "", "", txtvlrfrete_item.Text, txtcest.Text, txtncmex.Text)

        Next


        limpar_itens()


    End Sub

#End Region


#Region "''''Rotina limpa controles"

    Public Sub limpar_itens()

        txtnr.Clear()
        txtqtdecx_item.ReadOnly = True

        txtpercdesc_item.Text = valor_campo_vazio()

        txtvBCUFDest_item.Text = valor_campo_vazio()
        txtpFCPUFDest_item.Text = valor_campo_vazio()
        txtpICMSUFDest_item.Text = valor_campo_vazio()
        txtpICMSInter_item.Text = valor_campo_vazio()
        txtvlrdificms_item.Text = valor_campo_vazio()
        txtvlrtotal_cdesc_item.Text = valor_campo_vazio()


        txtvFCP.Text = valor_campo_vazio()
        txtpFCP.Text = valor_campo_vazio()
        txtvBCFCP.Text = valor_campo_vazio()
        txtvFCPST.Text = valor_campo_vazio()
        txtpFCPST.Text = valor_campo_vazio()
        txtvBCFCPST.Text = valor_campo_vazio()


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

        cboaliqst_item.Text = valor_campo_vazio()

        txtlote_item.Clear()

        cboaliqicms_item.Text = valor_campo_vazio()

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


        txtxmotivocanc.Clear()
        txtemaildest.Clear()
        txtemailfor.Clear()
        txtnomefor.Clear()
        txtnomefanfor.Clear()
        txtiefor.Clear()
        txtendfor.Clear()
        txtbairrofor.Clear()


        txtnomecli.Clear()
        mskcnpjcpf_cli.Clear()

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
        ' txtplacatrp.Clear()
        ' txtufplacatrp.Clear()
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


        txtvlrtotalFCP.Text = valor_campo_vazio()
        txtvlrtotalFCPST.Text = valor_campo_vazio()
        txtvlrtotalFCPSTret.Text = valor_campo_vazio()

        txtcfop_ST.Clear()
        txtcfop_icms.Clear()
        txttipo.Clear()

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
        txtmodelonfe.Clear()
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
        cbomodfrete.Text = "9- Sem Ocorrência de transporte"
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


#Region "''''Rotina para consulta Produtos destinatario e transportadora para descarregar os itens"

    Public Sub consulta_prod()
        Dim ret As Boolean = False

        If txtcodbarra_item.Text = "" And txtcodfor_item.Text = "" Then
            Exit Sub
        End If

        Dim rs2 As New ADODB.Recordset
        Dim sql As String

        conectar_baseNFe()


        If txtcodbarra_item.Text <> "" Then
            sql = "SELECT * FROM produto INNER JOIN Codigo_barras ON produto.codigo_prod = Codigo_barras.codigo_prod where produto.prod_ativo = 0 and Codigo_barras.codigo_barra ='" & txtcodbarra_item.Text & "'"
        End If

        If txtcodfor_item.Text <> "" Then
            sql = "SELECT * FROM produto where codigo_prod =" & txtcodfor_item.Text
        End If

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read

                txtcodfor_item.Text = reader("codigo_prod")

                txtdesc_item.Text = reader("desc_prod").ToString


                txtun_item.Text = reader("unidade_prod")

                txtncm_item.Text = reader("ncm_prod")

                txtncmex_item.Text = reader("EX_ncm").ToString

                txtlote_item.Text = reader("Lote_prod").ToString

                txtcodbarra_item.Text = reader("barras_prod")



                txtvlrunit_item.Text = format_val_mysql_ret(reader("valor_venda"))


                '''''''''''''''''''campo para comparaco de preco venda
                txtvrlvd_cad.Text = format_val_mysql_ret(reader("valor_venda"))
                txtvrlvd_cad.Text = formata_valor_campo_4c(txtvrlvd_cad.Text)
                '''''''''''''''''''''###################''''''''''''''''''''''

                txtqtdecx_item.Text = reader("Qtde_emb_prod").ToString

                txtcst_item.Text = reader("cst_icms")


                '''''''''''''''''Rotina de conversão de cst simple nacional''''''''''''''''''''
                If empresa.scod_trib = 1 Then

                    If txtcst_item.Text.Length < 4 Then

                        If txtcst_item.Text.Substring(1, 2) = "40" Then
                            txtcst_item.Text = txtcst_item.Text.Substring(0, 1) & "102"
                        End If

                        If txtcst_item.Text.Substring(1, 2) = "00" Or txtcst_item.Text.Substring(1, 2) = "20" Then
                            txtcst_item.Text = txtcst_item.Text.Substring(0, 1) & "101"
                        End If

                        If txtcst_item.Text.Substring(1, 2) = "10" Or txtcst_item.Text.Substring(1, 2) = "70" Then
                            txtcst_item.Text = txtcst_item.Text.Substring(0, 1) & "201"
                        End If

                        If txtcst_item.Text.Substring(1, 2) = "60" Then
                            txtcst_item.Text = txtcst_item.Text.Substring(0, 1) & "500"
                        End If

                        If txtcst_item.Text.Substring(1, 2) = "90" Then
                            txtcst_item.Text = txtcst_item.Text.Substring(0, 1) & "900"
                        End If


                    End If
                End If


                If reader("cest_prod").ToString <> "" Then
                    txtcest_item.Text = reader("cest_prod").ToString.Replace(".", "")
                End If

                mskdvenc_item.Text = reader("datavenc_prod").ToString

                cboaliqst_item.Text = format_val_mysql_ret(reader("Aliq_int").ToString)
                txtbaseredicms_item.Text = format_val_mysql_ret(reader("Redbase_icms").ToString)

                txtmva_item.Text = format_val_mysql_ret(reader("mva_prod").ToString)


                txtaliqIPI_item.Text = format_val_mysql_ret(reader("Aliq_ipi").ToString)

                If optentrada.Checked = True Then
                    txtcstipi_item.Text = reader("cst_ipi_ent").ToString
                Else
                    txtcstipi_item.Text = reader("cst_ipi_sai").ToString
                End If

                txtbaseredicmsst_item.Text = format_val_mysql_ret(reader("redbase_st").ToString)

                If reader("aliq_fem") <> "0.00" Then
                    chkfundopobreza.Checked = True
                    txtpFCP.Text = format_val_mysql_ret(reader("aliq_fem"))
                    txtpFCPST.Text = format_val_mysql_ret(reader("aliq_fem"))
                Else
                    chkfundopobreza.Checked = False
                End If


                txtlote_item.Text = reader("Lote_prod").ToString
                txtinfoadic_item.Text = reader("Inf_adi_prod").ToString


                ''''''''''''''''''''''''''''#############''''''''''''''''''''''''''
                If optentrada.Checked = True Then
                    txtcstcofins_item.Text = reader("cst_pis_ent").ToString
                    txtcstpis_item.Text = reader("cst_pis_ent").ToString
                Else
                    txtcstcofins_item.Text = reader("cst_pis_sai").ToString
                    txtcstpis_item.Text = reader("cst_pis_sai").ToString
                End If

                txtaliqcofins_item.Text = reader("aliq_cofins").ToString
                txtaliqpis_item.Text = reader("aliq_pis").ToString


                txtlote_item.Focus()

                ''''''''''''Rotina abaixo trabalha com a aliquota do icms

                If empresa.scod_trib = 3 Then

                    cboaliqicms_item.Text = format_val_mysql_ret(reader("Aliq_icms").ToString)
                    cboaliqicms_item.Enabled = True

                Else

                    cboaliqicms_item.Text = empresa.saliq_simples
                    cboaliqicms_item.Enabled = False

                End If

                ret = True
            End While

        End Using

        If ret = False Then
            MsgBox("Produto não cadastrado !", MsgBoxStyle.Exclamation, "Aviso !")
            If txtcodbarra_item.Text <> "" Then
                txtcodbarra_item.Focus()
                txtcodbarra_item.Clear()
            End If
            If txtcodfor_item.Text <> "" Then
                txtcodfor_item.Focus()
                txtcodfor_item.Clear()
            End If
            Exit Sub
        End If


        ''''''''''''''''''rotina abaixo para montar cfop de acordo com cst
        Dim cst_calc As String

        If txtcst_item.Text <> "" Then
            If empresa.scod_trib = 3 Then
                cst_calc = txtcst_item.Text.Substring(1, 2)
            Else
                cst_calc = txtcst_item.Text.Substring(1, 3)
            End If
        Else
            cst_calc = "0"
        End If

        If txttipo.Text = "v" Or txttipo.Text = "d" Then
            carrega_cfop_item()

            If cst_calc = "00" Or cst_calc = "20" Or cst_calc = "40" Or cst_calc = "51" Or cst_calc = "101" Or cst_calc = "102" Or cst_calc = "103" Or cst_calc = "300" Or cst_calc = "400" Then
                txtcfop_item.Text = txtcfop_icms.Text
            End If

            If cst_calc = "10" Or cst_calc = "30" Or cst_calc = "60" Or cst_calc = "70" Or cst_calc = "90" Or cst_calc = "500" Or cst_calc = "201" Or cst_calc = "202" Or cst_calc = "900" Then
                txtcfop_item.Text = txtcfop_ST.Text
            End If

        End If

        mskdvenc_item.Text = ""


        '  txtqtde_item.Focus()
        '''''''''''''''''''''''''''''''''''#########################'''''''''''''''''''''''''''''''''''''''''''''
        If empresa.scod_trib = 3 Then
            If txtcst_item.Text.Substring(1, 2) = "60" Or txtcst_item.Text.Substring(1, 2) = "10" Or txtcst_item.Text.Substring(1, 2) = "70" Then
                txtcfop_item.Text = txtcfop_ST.Text
            Else
                txtcfop_item.Text = txtcfop_icms.Text
            End If

        Else
            If txtcst_item.Text.Substring(1, 3) = "201" Or txtcst_item.Text.Substring(1, 3) = "202" Or txtcst_item.Text.Substring(1, 3) = "500" Then
                txtcfop_item.Text = txtcfop_ST.Text
            Else
                txtcfop_item.Text = txtcfop_icms.Text
            End If
        End If

    End Sub


    Private Sub carrega_empresa(ByVal cnpj_p As String, ByVal par As String)
        Dim numero_nf As Integer
        Dim sql As String
        conectar_baseNFe()

        sql = "SELECT * FROM empresa INNER JOIN municipio ON municipio.codigo_municipio = empresa.cod_munic INNER JOIN numeracao_nfe ON numeracao_nfe.cnpj_emi = empresa.cnpj_emp WHERE cnpj_emp = '" & cnpj_p & "'"

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read

                If par = "novo" Then

                    If empresa.ambiente_nfe = 1 Then
                        numero_nf = reader("Numero_nf")
                    End If

                    If empresa.ambiente_nfe = 2 Then
                        If reader("Numero_nfh").ToString = "" Then
                            numero_nf = 0
                        Else
                            numero_nf = reader("Numero_nfh")
                        End If

                    End If

                    If numero_nf = 0 Then
                        txtnumeronfe.Text = "000000001"
                    Else
                        txtnumeronfe.Text = numero_nf + 1
                        txtnumeronfe.Text = txtnumeronfe.Text.PadLeft(9, "0")
                    End If

                    txtmodelonfe.Text = reader("modelo_nf")
                    txtserienfe.Text = reader("serie_nf")
                    txtserienfe.Text = txtserienfe.Text.PadLeft(3, "0")
                    txtdataemissao.Text = Now.ToString("dd/MM/yyyy HH:mm:ss")

                End If

                '''''''''''''''''Busca informacao da emitente da nfe
                txtnomefor.Text = reader("razao_emp")
                txtnomefanfor.Text = reader("Nome_fantasia")
                mskcnpjfor.Mask = "00.000.000/0000-00"
                mskcnpjfor.Text = reader("cnpj_emp")

                txtiefor.Text = reader("ie_emp")
                ' txtinscst.Text = rs.Fields("Insc_st").Value.ToString
                txtim.Text = reader("im_emp")
                txtcnae.Text = reader("cnae_emp")
                txtregime.Text = reader("reg_trib")
                txtendfor.Text = reader("end_emp")
                txtnumerofor.Text = reader("numero_emp")

                txtbairrofor.Text = reader("bairro_emp")

                txtuffor.Text = reader("UF")
                txtcoduf.Text = reader("cod_UF")
                txtcmunfor.Text = reader("cod_munic")
                txtcidadefor.Text = reader("NomeMunic")
                mskcepfor.Text = reader("cep_emp")
                txtemailfor.Text = reader("email_emp")
                txtcodpaisfor.Text = "1058"
                txtpaisfor.Text = "BRASIL"

                txtinfcompl.Text = reader("obs").ToString

                If reader("fone_emp").ToString.Length = 10 Then
                    mskfonefor.Mask = "(00) 0000-0000"
                End If
                If reader("fone_emp").ToString.Length = 11 Then
                    mskfonefor.Mask = "(00) 0-0000-0000"
                End If

                mskfonefor.Text = reader("fone_emp")
            End While

        End Using

        If txtnomefor.Text = "" Then
            MsgBox("Empresa Não cadastrada no Sistema para emissão de NF-e", MsgBoxStyle.Exclamation, "Aviso !")
            conexao.cn_nfe.Close()
            limpa_nfe()
            limpar_abas()
            limpar_itens()
            limpardup()

            dgvgrid_xml.Rows.Clear()

            desativa_tab()

            bntnovo.Enabled = True
            FrmEmpresa.ShowDialog()
            Exit Sub
        End If


    End Sub

    Public Sub pesquisa_destinatario(ByVal cnpj_pesq As String, ByVal amb As String)
        Dim ret As Boolean = False
        Dim codigo As Integer
        Dim sql As String


        If amb = 2 Then

            mskcnpjcpf_cli.Mask = "00.000.000/0000-00"
            mskcnpjcpf_cli.Text = "99,999,999/0001-91"
            txtnomecli.Text = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO"
        txtnomedest.Text = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL"
        mskcnpjdest.Mask = "00.000.000/0000-00"
        mskcnpjdest.Text = "99999999000191"
            txtindIEDest.Text = "9 – Não Contribuinte"
            ' txtindIEDest.Text = "1–Contribuinte ICMS"
        txtiedest.Text = ""
            cboindFinal.Text = "1-Consumidor Final"
            ' cboindFinal.Text = "0-Não"


        txtenddest.Text = "Rua teste"

        txtnumerodest.Text = "00"
        txtbairrodest.Text = "Bairro teste"

        txtcidadedest.Text = "Cidade teste"
        txtcmundest.Text = "3135902"
        cboindFinal.SelectedIndex = cboindFinal.FindString("1")
        cboindPag.SelectedIndex = cboindPag.FindString("01")

            txtufdest.Text = "MG"

        mskcepdest.Text = "00000000"


        txtemaildest.Text = "teste@teste.com"

        txtcodpaisdest.Text = "1058"
        txtpaisdest.Text = "BRASIL"
            cbonat.Focus()
        Exit Sub
        End If


        conectar_baseNFe()

        sql = "SELECT * FROM cliente INNER JOIN municipio ON cliente.cod_munic = municipio.codigo_municipio WHERE cliente.cliente_ativo = '0' and cliente.cnpjcpf_cli = '" & cnpj_pesq & "'"

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read
                ret = True

                txtnomedest.Text = reader("nome_cli")
                txtnomecli.Text = reader("nome_cli")
                codigo = reader("codigo_cli")
                txtiedest.Text = reader("ierg_cli")

                If reader("cnpjcpf_cli").ToString.Length = 14 Then
                    mskcnpjdest.Mask = "00.000.000/0000-00"
                    mskcnpjdest.Text = reader("cnpjcpf_cli")
                Else
                    mskcnpjdest.Mask = "000.000.000-00"
                    mskcnpjdest.Text = reader("cnpjcpf_cli")
                End If

                txtindIEDest.Text = reader("ind_dest")

                txtenddest.Text = reader("end_cli")

                txtnumerodest.Text = reader("numero_cli")
                txtbairrodest.Text = reader("bairro_cli")

                txtcidadedest.Text = reader("NomeMunic")
                txtcmundest.Text = reader("codigo_municipio")
                cboindFinal.SelectedIndex = cboindFinal.FindString(reader("indfinal"))
                cboindPag.SelectedIndex = cboindPag.FindString(reader("forma_pag"))

                txtufdest.Text = reader("UF")

                mskcepdest.Text = reader("cep_cli")


                txtemaildest.Text = reader("email")

                txtcodpaisdest.Text = "1058"
                txtpaisdest.Text = "BRASIL"

               End While

        End Using


        SQLcommand.Dispose()
        oConn.Close()



        conectar_mysqlDFe()
        Dim SQLcommand2 As MySqlCommand
        SQLcommand2 = oConn.CreateCommand
        SQLcommand2.CommandText = "SELECT * FROM fone_cli where codigo_cli = '" & codigo & "'"
        dr = SQLcommand2.ExecuteReader()

        Dim fone As String
        While (dr.Read())
            fone = dr("fone_cli")

            If fone.ToString.Length = 11 Then
                fone = MascSTR(dr("fone_cli"), "(##) #-####-####")
            Else
                fone = MascSTR(dr("fone_cli"), "(##) ####-####")
            End If

        End While

        dr.Close()
        SQLcommand2.Dispose()
        oConn.Close()
        mskfonedest.Text = fone


        If ret = False Then
            MsgBox("Cliente não cadastrado !", MsgBoxStyle.Exclamation, "Aviso !")
            mskcnpjcpf_cli.Clear()
            mskcnpjcpf_cli.Focus()
            Exit Sub
        End If

        cbonat.Focus()


    End Sub

    Public Sub pesquisa_transportadora(ByVal cnpjtr As String, ByVal par As String)
        Dim sql As String

        conectar_baseNFe()

        sql = "SELECT * FROM cliente INNER JOIN municipio ON municipio.codigo_municipio = cliente.cod_munic  WHERE cnpjcpf_cli = '" & removeFormatacao(cnpjtr) & "'"


        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read
                txtnometrp.Text = reader("nome_cli")


                txtietrp.Text = reader("ierg_cli")



                If reader("cnpjcpf_cli").ToString.Length = 14 Then
                    mskcnpjtrp.Mask = "00.000.000/0000-00"
                    mskcnpjtrp.Text = reader("cnpjcpf_cli")
                Else
                    mskcnpjtrp.Mask = "000.000.000-00"
                    mskcnpjtrp.Text = reader("cnpjcpf_cli")
                End If


                txtendtrp.Text = reader("end_cli") & ", N°" & reader("numero_cli") & ", " & reader("bairro_cli")
                txtbairrotrp.Text = reader("bairro_cli")
                txtcidadetrp.Text = reader("NomeMunic")
                txtuftrp.Text = reader("UF")

            End While

        End Using

        If par = "" Then

            If mskcnpjtrp.Text = "" Then
                MsgBox("Transportadora Não cadastrada no Sistema para emissão de NF-e", MsgBoxStyle.Exclamation, "Aviso !")
                mskcnpjcpf_cli.Clear()
                conexao.cn_nfe.Close()
                Exit Sub
            End If

        End If

        '''''''''''''''''Busca informacao da emitente da nfe


    End Sub

#End Region


#Region "''''Rotina Função de gerar XML da NFe e grava a nfe no banco de dados"


    Private Sub gerar_chave_acesso()

        Dim chars = "0123456789"
        Dim random = New Random()
        Dim cNF = New String(Enumerable.Repeat(chars, 8).[Select](Function(s) s(random.[Next](s.Length))).ToArray())
        ''''''''''''''''''''''Rotina abaixo constroi a chave de acesso da nfe''''''''''''''
        Dim _codUF As String = txtcoduf.Text
        Dim _dEmi As String = Now.ToString("yyMM")
        Dim _cnpj As String = mskcnpjfor.Text
        Dim _mod As String = txtmodelonfe.Text
        Dim _tpEmis As String = txttpEmis.Text.Substring(0, 1)
        Dim _serie As String = String.Format("{0:000}", Int32.Parse(txtserienfe.Text))
        Dim _numNF As String = String.Format("{0:000000000}", Int32.Parse(txtnumeronfe.Text))
        Dim _codigo As String = String.Format("{0:00000000}", Int32.Parse(cNF))
        Dim chaveNF As String = _codUF + _dEmi + _cnpj + _mod + _serie + _numNF + _tpEmis + _codigo

        Dim _dv As Integer = funcoesNfe.modulo11(chaveNF)
        mskchave.Text = chaveNF + _dv.ToString()

    End Sub
   
    ''' <summary>
    ''' 'Rotina par salvar a nota fiscal sal para sr transmitida'''
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub gravar_nfe()
        Dim ret As Integer
        Dim sql As String
        ret = verificar_regexiste("delete from nfe_s where Chave_nfe = '" & mskchave.Text & "'")

        sql = "INSERT INTO nfe_s (Chave_nfe, Numero_nfe, Modelo_nfe, Serie_nfe, cnpj_emi, cnpj_cli, cnpj_transp, Data_emissao_nfe, data_saida, Tipo_nfe, Tipo_operacao_nfe, Valor_total_prod, Valor_total_nfe, Valor_BCICMS, Valor_ICMS, Valor_BCICMSST, Valor_ICMSST, Valor_frete_nfe, Valor_pis, Valor_cofins, Valor_ipi, Valor_outros, Valor_desc, Valor_seguro, vFCPST, vFCPSTRet, vFCP, vTotTrib, vFCPUFDest, vICMSUFDest, vICMSUFRemet, email_cli, ambiente, Status_nfe, xmotivo, cstat, nprot, nprot_canc, xml, chave_cont, Nat_op, inf_comp, inf_comp_fisc, idDest, mod_frete, indFinal, chave_dv, indPag, nSeqEvento_carta) VALUES (@Chave_nfe, @Numero_nfe, @Modelo_nfe, @Serie_nfe, @cnpj_emi, @cnpj_cli, @cnpj_transp, @Data_emissao_nfe, @data_saida, @Tipo_nfe, @Tipo_operacao_nfe, @Valor_total_prod, @Valor_total_nfe, @Valor_BCICMS, @Valor_ICMS, @Valor_BCICMSST, @Valor_ICMSST, @Valor_frete_nfe, @Valor_pis, @Valor_cofins, @Valor_ipi, @Valor_outros, @Valor_desc, @Valor_seguro, @vFCPST, @vFCPSTRet, @vFCP, @vTotTrib, @vFCPUFDest, @vICMSUFDest, @vICMSUFRemet, @email_cli, @ambiente, @Status_nfe, @xmotivo, @cstat, @nprot, @nprot_canc, @xml, @chave_cont, @Nat_op, @inf_comp, @inf_comp_fisc, @idDest, @mod_frete, @indFinal, @chave_dv, @indPag, nSeqEvento_carta)"


        conectar_mysqlDFe()
        Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)

        insertSQL.Parameters.Add(New MySqlParameter("Chave_nfe", mskchave.Text))


        insertSQL.Parameters.Add(New MySqlParameter("Numero_nfe", txtnumeronfe.Text))
        insertSQL.Parameters.Add(New MySqlParameter("Modelo_nfe", txtmodelonfe.Text))
        insertSQL.Parameters.Add(New MySqlParameter("Serie_nfe", txtserienfe.Text.TrimStart("0", "")))
        insertSQL.Parameters.Add(New MySqlParameter("cnpj_emi", mskcnpjfor.Text))
        insertSQL.Parameters.Add(New MySqlParameter("cnpj_cli", mskcnpjdest.Text))
        insertSQL.Parameters.Add(New MySqlParameter("cnpj_transp", mskcnpjtrp.Text))
        insertSQL.Parameters.Add(New MySqlParameter("Data_emissao_nfe", Convert.ToDateTime(txtdataemissao.Text).ToString("yyyy-MM-dd HH:mm:ss")))
        insertSQL.Parameters.Add(New MySqlParameter("data_saida", Convert.ToDateTime(txtdsaida.Text).ToString("yyyy-MM-dd HH:mm:ss")))
        insertSQL.Parameters.Add(New MySqlParameter("Tipo_nfe", cbofinNFe.Text.Substring(0, 1)))
        insertSQL.Parameters.Add(New MySqlParameter("Tipo_operacao_nfe", txttpNF.Text.Substring(0, 1)))

        insertSQL.Parameters.Add(New MySqlParameter("Valor_total_prod", format_val_mysql_ent(txtvlrtotalprod_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("Valor_total_nfe", format_val_mysql_ent(txtvlrtotal_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("Valor_BCICMS", format_val_mysql_ent(txtvlrtotalbaseicms_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("Valor_ICMS", format_val_mysql_ent(txtvlrtotalicms_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("Valor_BCICMSST", format_val_mysql_ent(txtvlrtotalbasest_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("Valor_ICMSST", format_val_mysql_ent(txtvlrtotalst_nfe.Text)))

        insertSQL.Parameters.Add(New MySqlParameter("Valor_frete_nfe", format_val_mysql_ent(txtvlrtotalfrete_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("Valor_pis", format_val_mysql_ent(txtvlrtotalpis_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("Valor_cofins", format_val_mysql_ent(txtvlrtotalcofins_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("Valor_ipi", format_val_mysql_ent(txtvrltotalipi_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("Valor_outros", format_val_mysql_ent(txtvlrtotaloutras_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("Valor_desc", format_val_mysql_ent(txtvlrtotaldesc_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("Valor_seguro", format_val_mysql_ent(txtvlrtotalseg_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("vFCPST", format_val_mysql_ent(txtvlrtotalFCPST.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("vFCPSTRet", format_val_mysql_ent(txtvlrtotalFCPSTret.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("vFCP", format_val_mysql_ent(txtvlrtotalFCP.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("vTotTrib", format_val_mysql_ent(txtvlrtotalaproxtrib.Text)))


        insertSQL.Parameters.Add(New MySqlParameter("vFCPUFDest", format_val_mysql_ent(txtvlrtotalvFCPUFDest.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("vICMSUFDest", format_val_mysql_ent(txtvlrtotalvICMSUFDest.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("vICMSUFRemet", format_val_mysql_ent(txtvlrtotalvICMSUFRemet.Text)))

        insertSQL.Parameters.Add(New MySqlParameter("email_cli", txtemailfor.Text))
        insertSQL.Parameters.Add(New MySqlParameter("ambiente", empresa.ambiente_nfe))
        insertSQL.Parameters.Add(New MySqlParameter("Status_nfe", "0"))
        insertSQL.Parameters.Add(New MySqlParameter("xmotivo", ""))
        insertSQL.Parameters.Add(New MySqlParameter("cstat", "0"))
        insertSQL.Parameters.Add(New MySqlParameter("nprot", txtprotocolo.Text))
        insertSQL.Parameters.Add(New MySqlParameter("nprot_canc", txtprotocolocanc.Text))

        If File.Exists(Application.StartupPath & "\XML\NFE\" & mskchave.Text.Replace(" ", "") & " - EnviNFe.xml") = True Then
            xmldoc.Load(Application.StartupPath & "\XML\NFE\" & mskchave.Text.Replace(" ", "") & " - EnviNFe.xml")
            insertSQL.Parameters.Add(New MySqlParameter("xml", Convert.ToBase64String(Encoding.UTF8.GetBytes(xmldoc.OuterXml))))
        Else
            insertSQL.Parameters.Add(New MySqlParameter("xml", Nothing))
        End If

        insertSQL.Parameters.Add(New MySqlParameter("chave_cont", ""))
        insertSQL.Parameters.Add(New MySqlParameter("Nat_op", txtcodnat.Text))
        insertSQL.Parameters.Add(New MySqlParameter("inf_comp", txtinfcompl.Text))
        insertSQL.Parameters.Add(New MySqlParameter("inf_comp_fisc", txtadifisco.Text))
        insertSQL.Parameters.Add(New MySqlParameter("idDest", txtidDest.Text.Substring(0, 1)))
        insertSQL.Parameters.Add(New MySqlParameter("mod_frete", cbomodfrete.Text.Substring(0, 1)))
        insertSQL.Parameters.Add(New MySqlParameter("indFinal", cboindFinal.Text.Substring(0, 1)))
        insertSQL.Parameters.Add(New MySqlParameter("chave_dv", mskchvdevolucao.Text))
        insertSQL.Parameters.Add(New MySqlParameter("indPag", cboindPag.Text.Substring(0, 2)))
        insertSQL.Parameters.Add(New MySqlParameter("nSeqEvento_carta", "0"))
        insertSQL.ExecuteNonQuery()
        oConn.Close()


        ''''''''''''''''''''''''''Rotina para salvar item''''''''''''''''''''''''''''''''''''''''''''
        ret = executa_query("delete from nfe_sitens where Chave_nfe = '" & mskchave.Text & "'")


        sql = "INSERT INTO nfe_sitens (codigo_prod, qtde, vlr_unit, vlr_total, vlr_totalcdesc, cod_barra, ncm, cfop, cst, aliq_icms, vlr_icms, vlr_st, cst_pis, aliq_pis, vlr_pis, cst_cofins, aliq_cofins, vlr_cofins, un, mva, aliq_st, cst_ipi, aliq_ipi, vlr_ipi, vlr_desc, lote, pmc, data_venc, bc_icms, bc_st, pRedBC, vlr_aproxtrib, inf_adic, vlr_outros, vlr_frete, cest, ncm_ex, pRedBCST, vICMSDeson, motDesICMS, vBCUFDest, pFCPUFDest, pICMSUFDest, pICMSInter, pICMSInterPart, vFCPUFDest, vICMSUFRemet, vICMSUFDest, vBCFCP, pFCP, vFCP, vBCFCPST, pFCPST, vFCPST, Chave_nfe) VALUES (@codigo_prod, @qtde, @vlr_unit, @vlr_total, @vlr_totalcdesc, @cod_barra, @ncm, @cfop, @cst, @aliq_icms, @vlr_icms, @vlr_st, @cst_pis, @aliq_pis, @vlr_pis, @cst_cofins, @aliq_cofins, @vlr_cofins, @un, @mva, @aliq_st, @cst_ipi, @aliq_ipi, @vlr_ipi, @vlr_desc, @lote, @pmc, @data_venc, @bc_icms, @bc_st, @pRedBC, @vlr_aproxtrib, @inf_adic, @vlr_outros, @vlr_frete, @cest, @ncm_ex, @pRedBCST, @vICMSDeson, @motDesICMS, @vBCUFDest, @pFCPUFDest, @pICMSUFDest, @pICMSInter, @pICMSInterPart, @vFCPUFDest, @vICMSUFRemet, @vICMSUFDest, @vBCFCP, @pFCP, @vFCP, @vBCFCPST, @pFCPST, @vFCPST, @Chave_nfe)"



        For Each row As DataGridViewRow In Me.dgvgrid_xml.Rows
            conectar_mysqlDFe()
            Dim insertSQL2 As MySqlCommand = New MySqlCommand(sql, oConn)

            insertSQL2.Parameters.Add(New MySqlParameter("codigo_prod", row.Cells("codfor").Value))

            insertSQL2.Parameters.Add(New MySqlParameter("qtde", row.Cells("qtde").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_unit", format_val_mysql_ent(row.Cells("vlrunit").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_total", format_val_mysql_ent(row.Cells("vlrtotal").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_totalcdesc", format_val_mysql_ent(row.Cells("vlrtotal_cdesc").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("cod_barra", row.Cells("codbarra").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("ncm", row.Cells("ncm").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("cfop", row.Cells("cfop").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("cst", row.Cells("cst").Value))


            insertSQL2.Parameters.Add(New MySqlParameter("aliq_icms", format_val_mysql_ent(row.Cells("aliqicms").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_icms", format_val_mysql_ent(row.Cells("vlricms").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_st", format_val_mysql_ent(row.Cells("vlrst").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("cst_pis", row.Cells("cstpis").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("aliq_pis", format_val_mysql_ent(row.Cells("aliqpis").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_pis", format_val_mysql_ent(row.Cells("vlrpis").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("cst_cofins", row.Cells("cstcofins").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("aliq_cofins", format_val_mysql_ent(row.Cells("aliqcofins").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_cofins", format_val_mysql_ent(row.Cells("vlrcofins").Value)))


            insertSQL2.Parameters.Add(New MySqlParameter("un", row.Cells("un").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("mva", format_val_mysql_ent(row.Cells("mva").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("aliq_st", format_val_mysql_ent(row.Cells("aliqst").Value)))

            insertSQL2.Parameters.Add(New MySqlParameter("cst_ipi", row.Cells("cstipi").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("aliq_ipi", format_val_mysql_ent(row.Cells("aliqipi").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_ipi", format_val_mysql_ent(row.Cells("vlripi").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_desc", format_val_mysql_ent(row.Cells("vlrdesc").Value)))

            insertSQL2.Parameters.Add(New MySqlParameter("lote", row.Cells("lote").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("pmc", format_val_mysql_ent(row.Cells("pmc").Value)))

            insertSQL2.Parameters.Add(New MySqlParameter("data_venc", row.Cells("datavenc").Value))

            insertSQL2.Parameters.Add(New MySqlParameter("bc_icms", format_val_mysql_ent(row.Cells("baseicms").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("bc_st", format_val_mysql_ent(row.Cells("basest").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("pRedBC", format_val_mysql_ent(row.Cells("pRedBC").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_aproxtrib", format_val_mysql_ent(row.Cells("Valor_aprox_trib").Value)))

            insertSQL2.Parameters.Add(New MySqlParameter("inf_adic", row.Cells("inf_adi_prod").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_outros", format_val_mysql_ent(row.Cells("vlroutros").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_frete", format_val_mysql_ent(row.Cells("vlrfrete").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("cest", row.Cells("cest").Value))

            insertSQL2.Parameters.Add(New MySqlParameter("ncm_ex", row.Cells("ex_tipe").Value))


            insertSQL2.Parameters.Add(New MySqlParameter("pRedBCST", format_val_mysql_ent(row.Cells("pRedBCST").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vICMSDeson", format_val_mysql_ent(row.Cells("vICMSDeson").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("motDesICMS", row.Cells("motDesICMS").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("vBCUFDest", format_val_mysql_ent(row.Cells("vBCUFDest").Value)))

            insertSQL2.Parameters.Add(New MySqlParameter("pFCPUFDest", format_val_mysql_ent(row.Cells("pFCPUFDest").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("pICMSUFDest", format_val_mysql_ent(row.Cells("pICMSUFDest").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("pICMSInter", format_val_mysql_ent(row.Cells("pICMSInter").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("pICMSInterPart", format_val_mysql_ent(row.Cells("pICMSInterPart").Value)))

            insertSQL2.Parameters.Add(New MySqlParameter("vFCPUFDest", format_val_mysql_ent(row.Cells("vFCPUFDest").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vICMSUFRemet", format_val_mysql_ent(row.Cells("vICMSUFRemet").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vICMSUFDest", format_val_mysql_ent(row.Cells("vICMSUFDest").Value)))

            insertSQL2.Parameters.Add(New MySqlParameter("vBCFCP", format_val_mysql_ent(row.Cells("vBCFCP").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("pFCP", format_val_mysql_ent(row.Cells("pFCP").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vFCP", format_val_mysql_ent(row.Cells("vFCP").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vBCFCPST", format_val_mysql_ent(row.Cells("vBCFCPST").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("pFCPST", format_val_mysql_ent(row.Cells("pFCPST").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vFCPST", format_val_mysql_ent(row.Cells("vFCPST").Value)))

            insertSQL2.Parameters.Add(New MySqlParameter("Chave_nfe", mskchave.Text))

            insertSQL2.ExecuteNonQuery()
            oConn.Close()

            executa_query("update produto set data_ultvenda = '" & Now.ToString("yyyy-MM-dd") & "' where codigo_prod = '" & row.Cells("codfor").Value & "'")

        Next


        ''''''''''''''''''''''''''Rotina para salvar duplicatas NFe''''''''''''''''''''''''''''''''''''''''''''
        ret = executa_query("delete from nfe_sfat where Chave_nfe = '" & mskchave.Text & "'")


        sql = "INSERT INTO nfe_sitens (par, ndup, valordup, vencdup, Chave_nfe) VALUES (@par, @ndup, @valordup, @vencdup, @Chave_nfe)"


        For Each row As DataGridViewRow In Me.dgvfatura.Rows
            conectar_mysqlDFe()
            Dim insertSQL2 As MySqlCommand = New MySqlCommand(sql, oConn)

            insertSQL2.Parameters.Add(New MySqlParameter("par", row.Cells("par").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("ndup", row.Cells("ndup").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("valordup", row.Cells("valordup").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("vencdup", Convert.ToDateTime(row.Cells("vencdup").Value)).ToString("yyyy-MM-dd"))
            insertSQL2.Parameters.Add(New MySqlParameter("Chave_nfe", mskchave.Text))

            insertSQL2.ExecuteNonQuery()
            oConn.Close()
        Next


        ''''''''''''''''''''''''''Rotina para salvar duplicatas NFe''''''''''''''''''''''''''''''''''''''''''''
        ret = executa_query("delete from nfe_secf where Chave_nfe = '" & mskchave.Text & "'")


        sql = "INSERT INTO nfe_secf (mod, nECF, nCOO, Chave_nfe) VALUES (@mod, @nECF, @nCOO, @Chave_nfe)"


        For Each row As DataGridViewRow In Me.dgvecf.Rows
            conectar_mysqlDFe()
            Dim insertSQL2 As MySqlCommand = New MySqlCommand(sql, oConn)

            insertSQL2.Parameters.Add(New MySqlParameter("mod", row.Cells(0).Value))
            insertSQL2.Parameters.Add(New MySqlParameter("nECF", row.Cells(1).Value))
            insertSQL2.Parameters.Add(New MySqlParameter("nCOO", row.Cells(2).Value))
            insertSQL2.Parameters.Add(New MySqlParameter("Chave_nfe", mskchave.Text))

            insertSQL2.ExecuteNonQuery()
            oConn.Close()
        Next


        ''''''''''''''''''''''''''Rotina para salvar duplicatas NFe''''''''''''''''''''''''''''''''''''''''''''
        ret = executa_query("delete from nfe_snfce where Chave_nfe = '" & mskchave.Text & "'")


        sql = "INSERT INTO nfe_secf (Chave_nfe, Chave_nfce) VALUES (@Chave_nfe, @Chave_nfce)"


        For Each row As DataGridViewRow In Me.dgvnfce_cobertura.Rows
            conectar_mysqlDFe()
            Dim insertSQL2 As MySqlCommand = New MySqlCommand(sql, oConn)


            insertSQL2.Parameters.Add(New MySqlParameter("Chave_nfce", row.Cells(0).Value))
            insertSQL2.Parameters.Add(New MySqlParameter("Chave_nfe", mskchave.Text))

            insertSQL2.ExecuteNonQuery()
            oConn.Close()
        Next

        ''''''''''''''''''''''''''Rotina para salvar Valomes transp''''''''''''''''''''''''''''''''''''''''''''
        If Not (txtQvol.Text = "" And txtesp.Text = "" And txtmarca.Text = "" And txtnvol.Text = "" And txtpesob.Text = "" And txtpesol.Text = "") Then

            ret = executa_query("delete from nfe_sfat where Chave_nfe = '" & mskchave.Text & "'")


            sql = "INSERT INTO nfe_stransp (qtde, esp, marca, n_vol, peso_b, peso_l, Chave_nfe) VALUES (@qtde, @esp, @marca, @n_vol, @peso_b, @peso_l, @Chave_nfe)"

            conectar_mysqlDFe()
            Dim insertSQL3 As MySqlCommand = New MySqlCommand(sql, oConn)


            insertSQL3.Parameters.Add(New MySqlParameter("qtde", txtQvol.Text))
            insertSQL3.Parameters.Add(New MySqlParameter("esp", txtesp.Text))
            insertSQL3.Parameters.Add(New MySqlParameter("marca", txtmarca.Text))
            insertSQL3.Parameters.Add(New MySqlParameter("n_vol", txtnvol.Text))
            insertSQL3.Parameters.Add(New MySqlParameter("peso_b", txtpesob.Text))
            insertSQL3.Parameters.Add(New MySqlParameter("peso_l", txtpesol.Text))

            insertSQL3.Parameters.Add(New MySqlParameter("Chave_nfe", mskchave.Text))

            insertSQL3.ExecuteNonQuery()
            oConn.Close()

        End If



        '''''''''''''''''''''Rotina abaixo salva o Numeração da NFe na tabela de numeracao

        If empresa.ambiente_nfe = 1 Then
            executa_query("update numeracao_nfe set Numero_nf = '" & txtnumeronfe.Text & "' where cnpj_emi = '" & mskcnpjfor.Text & "'")
        Else
            executa_query("update numeracao_nfe set Numero_nfh = '" & txtnumeronfe.Text & "' where cnpj_emi = '" & mskcnpjfor.Text & "'")
        End If


        If File.Exists(Application.StartupPath & "\XML\NFE\" & mskchave_cont.Text.Replace(" ", "") & " - EnviNFe.xml") = True Then
            MsgBox("Nota Fiscal Gravado com Sucesso !", MsgBoxStyle.Information, "Aviso !")
        End If




        If empresa.ambiente_nfe = 2 Then
            MsgBox("NF-e gerada no Ambiente Homologação sem validade Fiscal!", MsgBoxStyle.Information, "Aviso !")
        End If

        pinfo.Visible = False


    End Sub


    ''' <summary>
    ''' 'Rotina para retornar valores no tela'''
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ret_nfe_banco(ByVal chave As String)

        limpa_nfe()
        limpar_abas()
        limpar_itens()
        limpardup()

        dgvgrid_xml.Rows.Clear()


        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from nfe_s where Chave_nfe ='" & chave & "'"


        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read
                mskchave.Text = reader("Chave_nfe")

                txtnumeronfe.Text = reader("Numero_nfe")
                txtmodelonfe.Text = reader("Modelo_nfe")
                txtserienfe.Text = reader("Serie_nfe")
                mskcnpjfor.Text = reader("cnpj_emi")
                mskcnpjdest.Text = reader("cnpj_cli")
                mskcnpjtrp.Text = reader("cnpj_transp")
                txtdataemissao.Text = Convert.ToDateTime(reader("Data_emissao_nfe")).ToString("dd/MM/yyyy HH:mm:ss")
                txtdsaida.Text = Convert.ToDateTime(reader("data_saida")).ToString("dd/MM/yyyy")
                txttpNF.Text = reader("Tipo_nfe")
                txttpEmis.Text = reader("Tipo_operacao_nfe")
                '
                '  txtvlrtotalprod_nfe.Text = format_val_mysql_ret(reader("Valor_total_prod"))
                ' txtvlrtotal_nfe.Text = format_val_mysql_ret(reader("Valor_total_nfe"))
                ' txtvlrtotalbaseicms_nfe.Text = format_val_mysql_ret(reader("Valor_BCICMS"))
                ' txtvlrtotalicms_nfe.Text = format_val_mysql_ret(reader("Valor_ICMS"))
                ' txtvlrtotalbasest_nfe.Text = format_val_mysql_ret(reader("Valor_BCICMSST"))
                ' txtvlrtotalst_nfe.Text = format_val_mysql_ret(reader("Valor_ICMSST"))

                '  txtvlrtotalfrete_nfe.Text = format_val_mysql_ret(reader("Valor_frete_nfe"))
                ' txtvlrtotalcofins_nfe.Text = format_val_mysql_ret(reader("Valor_pis"))
                ' txtvlrtotalpis_nfe.Text = format_val_mysql_ret(reader("Valor_cofins"))
                ' txtvrltotalipi_nfe.Text = format_val_mysql_ret(reader("Valor_ipi"))
                ' txtvlrtotaloutras_nfe.Text = format_val_mysql_ret(reader("Valor_outros"))
                ' txtvlrtotaldesc_nfe.Text = format_val_mysql_ret(reader("Valor_desc"))
                ' txtvlrtotalseg_nfe.Text = format_val_mysql_ret(reader("Valor_seguro"))
                ' txtvlrtotalFCPST.Text = format_val_mysql_ret(reader("vFCPST"))
                ' txtvlrtotalFCPSTret.Text = format_val_mysql_ret(reader("vFCPSTRet"))
                ' txtvlrtotalFCP.Text = format_val_mysql_ret(reader("vFCP"))
                'txtvlrtotalaproxtrib.Text = format_val_mysql_ret(reader("vTotTrib"))

                txtvlrtotalprod_nfe.Text = valor_campo_vazio()
                txtvlrtotal_nfe.Text = valor_campo_vazio()
                txtvlrtotalbaseicms_nfe.Text = valor_campo_vazio()
                txtvlrtotalicms_nfe.Text = valor_campo_vazio()
                txtvlrtotalbasest_nfe.Text = valor_campo_vazio()
                txtvlrtotalst_nfe.Text = valor_campo_vazio()

                txtvlrtotalfrete_nfe.Text = valor_campo_vazio()
                txtvlrtotalcofins_nfe.Text = valor_campo_vazio()
                txtvlrtotalpis_nfe.Text = valor_campo_vazio()
                txtvrltotalipi_nfe.Text = valor_campo_vazio()
                txtvlrtotaloutras_nfe.Text = valor_campo_vazio()
                txtvlrtotaldesc_nfe.Text = valor_campo_vazio()
                txtvlrtotalseg_nfe.Text = valor_campo_vazio()
                txtvlrtotalFCPST.Text = valor_campo_vazio()
                txtvlrtotalFCPSTret.Text = valor_campo_vazio()
                txtvlrtotalFCP.Text = valor_campo_vazio()
                txtvlrtotalaproxtrib.Text = valor_campo_vazio()

                If reader("nprot") <> "" Then
                    lblnfe.Visible = True
                    bntgravanfe.Enabled = False
                End If


                txtvlrtotalvFCPUFDest.Text = format_val_mysql_ret(reader("vFCPUFDest"))
                txtvlrtotalvICMSUFDest.Text = format_val_mysql_ret(reader("vICMSUFDest"))
                txtvlrtotalvICMSUFRemet.Text = format_val_mysql_ret(reader("vICMSUFRemet"))

                txtemailfor.Text = reader("email_cli")
                txttpAmb.Text = reader("ambiente")
                txtxmotivo.Text = reader("xmotivo")

                txtprotocolo.Text = reader("nprot")
                txtprotocolocanc.Text = reader("nprot_canc")
                bntimprimir.Enabled = True
                ' reader("chave_cont", ""))
                txtcodnat.Text = reader("Nat_op")

                cbonat.Text = ret_valor_campo("select * from natureza_operacao where codigo =" & reader("Nat_op") & "", "descricao")
                txtinfcompl.Text = reader("inf_comp")
                txtadifisco.Text = reader("inf_comp_fisc")
                txtidDest.Text = reader("idDest")
                cbomodfrete.SelectedIndex = cbomodfrete.FindString(reader("mod_frete"))
                cboindFinal.SelectedIndex = cboindFinal.FindString(reader("indFinal"))
                mskchvdevolucao.Text = reader("chave_dv").ToString
                cboindPag.SelectedIndex = cboindPag.FindString(reader("indPag"))

                carrega_cfop_item()
                carrega_natureza(txttpNF.Text.Substring(0, 1))
            End While

        End Using

        conectar_mysqlDFe()
        Dim SQLcommand2 As MySqlCommand
        SQLcommand2 = oConn.CreateCommand
        SQLcommand2.CommandText = "select * from nfe_sitens where Chave_nfe ='" & chave & "'"


        Using reader As MySqlDataReader = SQLcommand2.ExecuteReader

            While reader.Read
                txtcodfor_item.Text = reader("codigo_prod")

                If reader("codigo_prod").ToString.Length >= 4 Then
                    If reader("codigo_prod").ToString.Substring(0, 4) <> "CFOP" Then
                        txtdesc_item.Text = ret_valor_campo("select * from produto where codigo_prod =" & reader("codigo_prod") & "", "desc_prod")
                        txtcfop_item.Text = reader("cfop")
                    Else
                        txtdesc_item.Text = cbonat.Text
                        txtcfop_item.Text = reader("codigo_prod").ToString.Substring(4, 4)
                        txtun_item.Text = "R$"
                        txtcstpis_item.Text = "07"
                        txtcstcofins_item.Text = "07"

                    End If
                Else
                    txtdesc_item.Text = ret_valor_campo("select * from produto where codigo_prod =" & reader("codigo_prod") & "", "desc_prod")
                    txtcfop_item.Text = reader("cfop")
                End If


                txtqtde_item.Text = reader("qtde")
                txtvlrunit_item.Text = format_val_mysql_ret(reader("vlr_unit"))
                txtvlrtotal_item.Text = format_val_mysql_ret(reader("vlr_total"))

                If reader("cod_barra").ToString = "" Then
                    txtcodbarra_item.Text = "SEM GTIN"
                Else
                    txtcodbarra_item.Text = reader("cod_barra")
                End If



                txtncm_item.Text = reader("ncm")



                txtcst_item.Text = reader("cst")
                cboaliqicms_item.Text = format_val_mysql_ret(reader("aliq_icms"))
                txtvlricms_item.Text = format_val_mysql_ret(reader("vlr_icms"))

              
                        txtvlrst_item.Text = format_val_mysql_ret(reader("vlr_st"))
                        txtcstpis_item.Text = reader("cst_pis")
                        txtaliqpis_item.Text = format_val_mysql_ret(reader("aliq_pis"))
                        txtvlrpis_item.Text = format_val_mysql_ret(reader("vlr_pis"))
                        txtcstcofins_item.Text = reader("cst_cofins")
                        txtaliqcofins_item.Text = format_val_mysql_ret(reader("aliq_cofins"))
                        txtvlrcofins_item.Text = format_val_mysql_ret(reader("vlr_cofins"))



                        txtun_item.Text = reader("un")
                        txtmva_item.Text = reader("mva")
                        cboaliqst_item.Text = format_val_mysql_ret(reader("aliq_st"))

                        txtcstipi_item.Text = reader("cst_ipi")
                        txtaliqIPI_item.Text = format_val_mysql_ret(reader("aliq_ipi"))
                        txtvlripi_item.Text = format_val_mysql_ret(reader("vlr_ipi"))
                        txtvlrdesc_item.Text = format_val_mysql_ret(reader("vlr_desc"))

                        txtlote_item.Text = reader("lote")
                        txtpmc_item.Text = reader("pmc")
                        mskdvenc_item.Text = reader("data_venc")


                        txtbaseicms_item.Text = format_val_mysql_ret(reader("bc_icms"))
                        txtbasest_item.Text = format_val_mysql_ret(reader("bc_st"))
                        txtbaseredicms_item.Text = format_val_mysql_ret(reader("pRedBC"))


                        txtvlrtrib_item.Text = format_val_mysql_ret(reader("vlr_aproxtrib"))
                        txtinfoadic_item.Text = reader("inf_adic")

                        txtvlroutros_item.Text = format_val_mysql_ret(reader("vlr_outros"))

                        txtvlrfrete_item.Text = format_val_mysql_ret(reader("vlr_frete"))


                        txtcest_item.Text = reader("cest")
                        txtncmex_item.Text = reader("ncm_ex")
                        txtbaseredicmsst_item.Text = format_val_mysql_ret(reader("pRedBCST"))
                        ' dgvgrid_xml.Rows.Item(i).Cells("vicmsdeson").Value = "0.00"
                        ' dgvgrid_xml.Rows.Item(i).Cells("motdesicms").Value = ""

                        txtvlrtotal_cdesc_item.Text = format_val_mysql_ret(reader("vlr_totalcdesc"))


                        txtvBCUFDest_item.Text = format_val_mysql_ret(reader("vBCUFDest"))
                        txtpFCPUFDest_item.Text = format_val_mysql_ret(reader("pFCPUFDest"))
                        txtpICMSUFDest_item.Text = format_val_mysql_ret(reader("pICMSUFDest"))
                        txtpICMSInter_item.Text = format_val_mysql_ret(reader("pICMSInter"))
                        txtpICMSInterPart_item.Text = format_val_mysql_ret(reader("pICMSInterPart"))
                        txtvFCPUFDest_item.Text = format_val_mysql_ret(reader("vFCPUFDest"))
                        txtvICMSUFRemet_item.Text = format_val_mysql_ret(reader("vICMSUFRemet"))
                        txtvICMSUFDest_item.Text = format_val_mysql_ret(reader("vICMSUFDest"))


                        txtvBCFCP.Text = format_val_mysql_ret(reader("vBCFCP"))
                        txtpFCP.Text = format_val_mysql_ret(reader("pFCP"))
                        txtvFCP.Text = format_val_mysql_ret(reader("vFCP"))

                        txtvBCFCPST.Text = format_val_mysql_ret(reader("vBCFCPST"))
                        txtpFCPST.Text = format_val_mysql_ret(reader("pFCPST"))
                        txtvFCPST.Text = format_val_mysql_ret(reader("vFCPST"))
                  
                calcular_valor_totais_nfe()

                adiciona_iten_grid()
                limpar_itens()
            End While

        End Using


        carrega_empresa(mskcnpjfor.Text, "")

        pesquisa_destinatario(mskcnpjcpf_cli.Text, txttpAmb.Text.Substring(0, 1))

        pesquisa_transportadora(mskcnpjtrp.Text, "c")


        conectar_mysqlDFe()
        Dim SQLcommand3 As MySqlCommand
        SQLcommand3 = oConn.CreateCommand
        SQLcommand3.CommandText = "select * from nfe_sfat where Chave_nfe ='" & chave & "'"

        dgvfatura.Rows.Clear()
        Using reader As MySqlDataReader = SQLcommand3.ExecuteReader

            While reader.Read
                dgvfatura.Rows.Add(reader("par"), reader("ndup"), format_val_mysql_ret(reader("vlr_dup")), Convert.ToDateTime(reader("data_venc")).ToString("dd/MM/yyyy"))
            End While

        End Using


        conectar_mysqlDFe()
        Dim SQLcommand8 As MySqlCommand
        SQLcommand8 = oConn.CreateCommand
        SQLcommand8.CommandText = "select * from nfe_secf where Chave_nfe ='" & chave & "'"

        dgvecf.Rows.Clear()
        Using reader As MySqlDataReader = SQLcommand8.ExecuteReader

            While reader.Read
                dgvecf.Rows.Add(reader("mod"), reader("ndup"), reader("nECF"), reader("nCOO"))
            End While

        End Using

        conectar_mysqlDFe()
        Dim SQLcommand15 As MySqlCommand
        SQLcommand15 = oConn.CreateCommand
        SQLcommand15.CommandText = "select * from nfe_snfce where Chave_nfe ='" & chave & "'"

        dgvecf.Rows.Clear()
        Using reader As MySqlDataReader = SQLcommand15.ExecuteReader

            While reader.Read
                dgvnfce_cobertura.Rows.Add(reader("Chave_nfce"))
            End While

        End Using


        conectar_mysqlDFe()
        Dim SQLcommand4 As MySqlCommand
        SQLcommand4 = oConn.CreateCommand
        SQLcommand4.CommandText = "select * from nfe_stransp where Chave_nfe ='" & chave & "'"

        Using reader As MySqlDataReader = SQLcommand4.ExecuteReader

            While reader.Read
                
                txtQvol.Text = reader("qtde")
                txtesp.Text = reader("esp")
                txtmarca.Text = reader("marca")
                txtnvol.Text = reader("n_vol")
                txtpesob.Text = reader("peso_b")
                txtpesol.Text = reader("peso_l")

            End While

        End Using


        If dgvecf.Rows.Count <> 0 Then
            TabControl_nfe.Controls.Add(aba_Cobertura_ECF)
            Exit Sub
        End If

        If dgvnfce_cobertura.Rows.Count <> 0 Then
            TabControl_nfe.Controls.Add(aba_Cobertura_ECF)
        End If

        If lblnfe.Visible = False Then
            bntexcluirnfe.Enabled = True
        Else
            bntgravanfe.Enabled = False
        End If
    End Sub


    Private Sub bntgravanfe_Click(sender As Object, e As EventArgs) Handles bntgravanfe.Click
        salvar()
    End Sub
#End Region


#Region "''''Rotina para gera criar o danfe da Nfe"
    Public Function danfe(ByVal dados As String) As PrintDocument
        Dim Danfe_doc As New PrintDocument
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



        xmldoc.LoadXml(dados)


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
                CDestinatario.IE_IND = InnerNode2("indIEDest").InnerText
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
            If Not InnerNode2("dSaiEnt") Is Nothing Then
                CDataHora.DATA_ENTRADA_SAIDA = InnerNode2("dSaiEnt").InnerText
            End If

            If Not InnerNode2("  dhSaiEnt") Is Nothing Then
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

        Danfe_doc = IDanfe.ret_DANFE()

        Return Danfe_doc

    End Function

    Private Sub optvisualizar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


        Dim dados As XmlDocument = New XmlDocument

        dados.Load(txtcaminhoxml.Text)

        danfe(dados.OuterXml)



    End Sub

    Private Sub optpdf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


        Dim dados As XmlDocument = New XmlDocument

        dados.Load(txtcaminhoxml.Text)

        danfe(dados.OuterXml)

    End Sub

    Private Sub bntimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntimprimir.Click

        imprimirDanfe()

    End Sub

#End Region


#Region "''''Rotina Abre A NFe no Arquivo txt"

    Private Sub carregar_txt()
        Dim nrdup As Integer = 0
        Dim nr As Integer = 0
        dgvgrid_xml.Rows.Clear()
        dgvfatura.Rows.Clear()


        Dim delimitador As String = "|"

        For Each line As String In File.ReadLines(txtcaminhoxml.Text)

            Dim separar = Split(line, delimitador)

            'cabeçalho da NFe
            ativa_tab()
            PainelNaturezaOp.Enabled = True

            If separar(0) = "A" Then
                mskchave.Text = separar(2).Substring(3, separar(2).Length - 3)
            End If

            If separar(0) = "B" Then
                txtcoduf.Text = separar(1)
                cbonat.Text = separar(3)
                cboindPag.SelectedIndex = cboindPag.FindString(separar(4))
                txtmodelonfe.Text = separar(5)
                txtserienfe.Text = separar(6)
                txtnumeronfe.Text = separar(7)
                txtdataemissao.Text = Convert.ToDateTime(separar(8)).ToString("dd/MM/yyyy HH:mm:ss")
                If separar(9) <> "" Then
                    txtdsaida.Text = Convert.ToDateTime(separar(9)).ToString("dd/MM/yyyy HH:mm:ss")
                End If
                txttpNF.Text = separar(10)
                txtidDest.Text = separar(11)
                txttpEmis.Text = separar(14)
                txttpAmb.Text = separar(16)
                cbofinNFe.SelectedIndex = cbofinNFe.FindString(separar(17))
                cboindFinal.SelectedIndex = cboindFinal.FindString(separar(18))
                cboindPres.SelectedIndex = cboindPres.FindString(separar(19))
                txtprocEmi.Text = "0-Aplicativo do contribuinte"
                txtverProc.Text = "NFe++"
            End If

            ''''refNFe

            ''''refNFe
            If separar(0) = "BA02" Then
                mskchvdevolucao.Text = separar(1)
            End If

            If separar(0) = "BA20" Then

            End If

            ''''''''''''''''''''''''''Dados do Emitente da NFe''''''''''''''''''''''''''''''''''''''''
            If separar(0) = "C" Then
                txtnomecli.Text = separar(1)
                txtnomefor.Text = separar(1)
                txtnomefanfor.Text = separar(2)
                txtiefor.Text = separar(3)
                txtinscst.Text = separar(4)
                txtim.Text = separar(5)
                txtcnae.Text = separar(6)
                txtregime.Text = separar(7)
            End If
            If separar(0) = "C02" Then
                mskcnpjfor.Text = separar(1)
                mskcnpjcpf_cli.Text = separar(1)
            End If

            If separar(0) = "C05" Then
                txtendfor.Text = separar(1)
                txtnumerofor.Text = separar(2)
                txtbairrofor.Text = separar(4)
                txtcmunfor.Text = separar(5)
                txtcidadefor.Text = separar(6)
                txtuffor.Text = separar(7)
                mskcepfor.Text = separar(8)
                txtcodpaisfor.Text = separar(9)
                txtpaisfor.Text = separar(10)
                mskfonefor.Text = separar(11)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''###############################''''''''''''''''''''''''''''


            '''''''''''''''''''''''''Dados do Destinatario da NFe'''''''''''''''''''''''''''''''''''''
            If separar(0) = "E" Then
                txtnomedest.Text = separar(1)
                txtindIEDest.Text = separar(2)
                txtiedest.Text = separar(3)
                txtemaildest.Text = separar(6)
            End If

            If separar(0) = "E02" Then
                mskcnpjdest.Mask = "00.000.000/0000-00"
                mskcnpjdest.Text = separar(1)
            End If
            If separar(0) = "E03" Then
                mskcnpjdest.Mask = "000.000.000-00"
                mskcnpjfor.Text = separar(1)
            End If

            If separar(0) = "E05" Then
                txtenddest.Text = separar(1)
                txtnumerodest.Text = separar(2)
                txtbairrodest.Text = separar(4)
                txtcmundest.Text = separar(5)
                txtcidadedest.Text = separar(6)
                txtufdest.Text = separar(7)
                mskcepdest.Text = separar(8)
                txtcodpaisdest.Text = separar(9)
                txtpaisdest.Text = separar(10)
                mskfonedest.Text = separar(11)
            End If
            ''''''''''''''''''''''''''''''''''#######################''''''''''''''''''''''''''''''''''''''''''


            '''''''''''''''''''''''''Dados do Produto'''''''''''''''''''''''''''''''''''''


            If separar(0) = "H" Then
                txtnr.Text = separar(1)
                txtinfoadic_item.Text = separar(2)
            End If

            If separar(0) = "I" Then
                txtcodfor_item.Text = separar(1)
                txtcodbarra_item.Text = separar(2)
                txtdesc_item.Text = separar(3)
                txtncm_item.Text = separar(4)
                txtncmex_item.Text = separar(5)
                txtcfop_item.Text = separar(6)
                txtun_item.Text = separar(7)
                txtqtde_item.Text = separar(8)
                txtvlrunit_item.Text = formata_valor_campo_4c(separar(9))
                txtvlrtotal_cdesc_item.Text = formata_valor_campo(separar(10))
                txtvlrfrete_item.Text = formata_valor_campo(separar(15))
                txtvlroutros_item.Text = formata_valor_campo(separar(16))
                txtvlrdesc_item.Text = formata_valor_campo(separar(17))
            End If
            '''''''CEST
            If separar(0) = "I05c" Then
                txtcest_item.Text = separar(1)
            End If

            If separar(0) = "K" Then
                txtlote_item.Text = separar(1)
                mskdvenc_item.Text = separar(4)
                txtpmc_item.Text = separar(5)
            End If
            '''''''''''''''''''''''Inicia os Valores do ICMS/ST
            If separar(0) = "M" Then
                txtvlrtrib_item.Text = formata_valor_campo(separar(1))
            End If

            '''''''ICMS Tags''''
            If separar(0) = "N02" Then
                txtcst_item.Text = separar(1) + separar(2)
                txtbaseicms_item.Text = formata_valor_campo(separar(4))
                cboaliqicms_item.Text = formata_valor_campo(separar(5))
                txtvlricms_item.Text = formata_valor_campo(separar(6))
            End If
            If separar(0) = "N03" Then
                txtcst_item.Text = separar(1) + separar(2)
                txtbaseicms_item.Text = formata_valor_campo(separar(4))
                cboaliqicms_item.Text = formata_valor_campo(separar(5))
                txtvlricms_item.Text = formata_valor_campo(separar(6))
                txtmva_item.Text = formata_valor_campo(separar(8))
                txtbaseredicmsst_item.Text = formata_valor_campo(separar(9))
                txtbasest_item.Text = formata_valor_campo(separar(10))
                cboaliqst_item.Text = formata_valor_campo(separar(11))
                txtvlrst_item.Text = formata_valor_campo((12))
            End If


            If separar(0) = "N04" Then
                txtcst_item.Text = separar(1) + separar(2)
                txtbaseredicms_item.Text = formata_valor_campo(separar(4))
                txtbaseicms_item.Text = formata_valor_campo(separar(5))
                cboaliqicms_item.Text = formata_valor_campo(separar(6))
                txtvlricms_item.Text = formata_valor_campo(separar(7))
            End If

            If separar(0) = "N05" Then
                txtcst_item.Text = separar(1) + separar(2)
                txtbaseicms_item.Text = formata_valor_campo(separar(4))

                txtmva_item.Text = formata_valor_campo(separar(4))
                txtbaseredicmsst_item.Text = formata_valor_campo(separar(5))
                txtbasest_item.Text = formata_valor_campo(separar(6))
                cboaliqst_item.Text = formata_valor_campo(separar(7))
                txtvlrst_item.Text = formata_valor_campo(separar(8))
            End If

            If separar(0) = "N06" Then
                txtcst_item.Text = separar(1) + separar(2)
            End If

            If separar(0) = "N07" Then
                txtcst_item.Text = separar(1) + separar(2)
                txtbaseredicms_item.Text = formata_valor_campo(separar(4))
                txtbaseicms_item.Text = formata_valor_campo(separar(5))
                cboaliqicms_item.Text = formata_valor_campo(separar(6))
                txtvlricms_item.Text = formata_valor_campo(separar(10))
            End If

            If separar(0) = "N08" Then
                txtcst_item.Text = separar(1) + separar(2)
            End If

            If separar(0) = "N09" Then
                txtcst_item.Text = separar(1) + separar(2)
                txtbaseredicms_item.Text = formata_valor_campo(separar(4))
                txtbaseicms_item.Text = formata_valor_campo(separar(5))
                cboaliqicms_item.Text = formata_valor_campo(separar(6))
                txtvlricms_item.Text = formata_valor_campo(separar(7))
                txtmva_item.Text = formata_valor_campo(separar(9))
                txtbaseredicmsst_item.Text = formata_valor_campo(separar(10))
                txtbasest_item.Text = formata_valor_campo(separar(11))
                cboaliqst_item.Text = formata_valor_campo(separar(12))
                txtvlrst_item.Text = formata_valor_campo(separar(13))
            End If

            If separar(0) = "N10" Then
                txtcst_item.Text = separar(1) + separar(2)
                txtbaseredicms_item.Text = formata_valor_campo(separar(5))
                txtbaseicms_item.Text = formata_valor_campo(separar(4))
                cboaliqicms_item.Text = formata_valor_campo(separar(6))
                txtvlricms_item.Text = formata_valor_campo(separar(7))

                txtmva_item.Text = formata_valor_campo(separar(9))
                txtbaseredicmsst_item.Text = formata_valor_campo(separar(10))
                txtbasest_item.Text = formata_valor_campo(separar(11))
                cboaliqst_item.Text = formata_valor_campo(separar(12))
                txtvlrst_item.Text = formata_valor_campo(separar(13))
            End If

            If separar(0) = "N10a" Then
                txtcst_item.Text = separar(1) + separar(2)
                txtbaseredicms_item.Text = formata_valor_campo(separar(5))
                txtbaseicms_item.Text = formata_valor_campo(separar(4))
                cboaliqicms_item.Text = formata_valor_campo(separar(6))
                txtvlricms_item.Text = formata_valor_campo(separar(7))

                txtmva_item.Text = formata_valor_campo(separar(9))
                txtbaseredicmsst_item.Text = formata_valor_campo(separar(10))
                txtbasest_item.Text = formata_valor_campo(separar(11))
                cboaliqst_item.Text = formata_valor_campo(separar(12))
                txtvlrst_item.Text = formata_valor_campo(separar(13))
            End If

            If separar(0) = "N10b" Then
                txtcst_item.Text = separar(1) + separar(2)
            End If

            If separar(0) = "N10c" Then
                txtcst_item.Text = separar(1) + separar(2)
                cboaliqicms_item.Text = formata_valor_campo(separar(3))
                txtvlricms_item.Text = formata_valor_campo(separar(4))
            End If

            If separar(0) = "N10d" Then
                txtcst_item.Text = separar(1) + separar(2)
            End If

            If separar(0) = "N10e" Then
                txtcst_item.Text = separar(1) + separar(2)
                txtmva_item.Text = formata_valor_campo(separar(4))
                txtbaseredicmsst_item.Text = formata_valor_campo(separar(5))
                txtbasest_item.Text = formata_valor_campo(separar(6))
                cboaliqst_item.Text = formata_valor_campo(separar(7))
                txtvlrst_item.Text = formata_valor_campo(separar(8))
            End If

            If separar(0) = "N10f" Then
                txtcst_item.Text = separar(1) + separar(2)
                txtmva_item.Text = formata_valor_campo(separar(4))
                txtbaseredicmsst_item.Text = formata_valor_campo(separar(5))
                txtbasest_item.Text = formata_valor_campo(separar(6))
                cboaliqst_item.Text = formata_valor_campo(separar(7))
                txtvlrst_item.Text = formata_valor_campo(separar(8))
            End If

            If separar(0) = "N10g" Then
                txtcst_item.Text = separar(1) + separar(2)
            End If

            If separar(0) = "N10h" Then
                txtcst_item.Text = separar(1) + separar(2)
                txtbaseredicms_item.Text = formata_valor_campo(separar(5))
                txtbaseicms_item.Text = formata_valor_campo(separar(4))
                cboaliqicms_item.Text = formata_valor_campo(separar(6))
                txtvlricms_item.Text = formata_valor_campo(separar(7))

                txtmva_item.Text = formata_valor_campo(separar(9))
                txtbaseredicmsst_item.Text = formata_valor_campo(separar(10))
                txtbasest_item.Text = formata_valor_campo(separar(11))
                cboaliqst_item.Text = formata_valor_campo(separar(12))
                txtvlrst_item.Text = formata_valor_campo(separar(13))
            End If
            '''''''''''''''''''''###############'''''''''''''''''''''''''''''''''''''''''

            '''''''IPI Tags''''
            If separar(0) = "007" Then
                txtcstipi_item.Text = separar(1)
                txtvlripi_item.Text = formata_valor_campo(separar(2))
            End If
            If separar(0) = "010" Then
                txtaliqIPI_item.Text = formata_valor_campo(separar(1))
            End If
            If separar(0) = "008" Then
                txtcstipi_item.Text = separar(1)
            End If
            '''''''''''''''''''''###############'''''''''''''''''''''''''''''''''''''''''

            '''''''PIS Tags''''
            If separar(0) = "Q02" Then
                txtcstpis_item.Text = separar(1)
                txtaliqpis_item.Text = formata_valor_campo(separar(3))
                txtvlrpis_item.Text = formata_valor_campo(separar(4))
            End If

            If separar(0) = "Q03" Then
                txtaliqpis_item.Text = formata_valor_campo(separar(3))
                txtvlrpis_item.Text = formata_valor_campo(separar(4))
            End If
            If separar(0) = "Q04" Or separar(0) = "Q05" Then
                txtcstpis_item.Text = separar(1)
            End If
            If separar(0) = "Q07" Then
                txtaliqpis_item.Text = formata_valor_campo(separar(2))
                txtvlrpis_item.Text = formata_valor_campo(separar(3))
            End If
            If separar(0) = "Q10" Then
                txtaliqpis_item.Text = formata_valor_campo(separar(2))
            End If
            If separar(0) = "R" Then
                txtvlrpis_item.Text = formata_valor_campo(separar(1))
            End If
            If separar(0) = "R02" Then
                txtaliqpis_item.Text = formata_valor_campo(separar(2))
            End If
            If separar(0) = "R04" Then
                txtaliqpis_item.Text = formata_valor_campo(separar(1))
            End If

            '''''''COFINS Tags''''
            If separar(0) = "S02" Then
                txtcstcofins_item.Text = separar(1)
                txtaliqcofins_item.Text = formata_valor_campo(separar(3))
                txtvlrcofins_item.Text = formata_valor_campo(separar(4))
            End If

            If separar(0) = "S03" Then
                txtaliqcofins_item.Text = formata_valor_campo(separar(3))
                txtvlrcofins_item.Text = formata_valor_campo(separar(4))
            End If
            If separar(0) = "S04" Or separar(0) = "Q05" Then
                txtcstcofins_item.Text = separar(1)
            End If
            If separar(0) = "S07" Then
                txtaliqcofins_item.Text = formata_valor_campo(separar(2))
                txtvlrcofins_item.Text = formata_valor_campo(separar(3))
            End If
            If separar(0) = "S09" Then
                txtaliqcofins_item.Text = formata_valor_campo(separar(2))
            End If
            If separar(0) = "T" Then
                txtvlrcofins_item.Text = formata_valor_campo(separar(1))
            End If
            If separar(0) = "T02" Then
                txtaliqcofins_item.Text = formata_valor_campo(separar(2))
            End If
            If separar(0) = "T04" Then
                txtaliqcofins_item.Text = formata_valor_campo(separar(2))
            End If

            '''''''tributação UF Deestinatario''''
            If separar(0) = "NA" Then
                txtvBCUFDest_item.Text = formata_valor_campo(separar(1))
                txtpFCPUFDest_item.Text = formata_valor_campo(separar(2))
                txtpICMSUFDest_item.Text = formata_valor_campo(separar(3))
                txtpICMSInter_item.Text = formata_valor_campo(separar(4))
                txtpICMSInterPart_item.Text = formata_valor_campo(separar(5))
                txtvFCPUFDest_item.Text = formata_valor_campo((6))
                txtvICMSUFDest_item.Text = formata_valor_campo(separar(7))
                txtvICMSUFRemet_item.Text = formata_valor_campo(separar(8))
            End If

            If separar(0) = "H" Or separar(0) = "W" Then

                If txtcodfor_item.Text <> "" Then
                    adiciona_iten_grid()
                    limpar_itens()
                End If
            End If

            '''''''Rotina dos Valores Totais da NFe''''

            If separar(0) = "W02" Then
                txtvlrtotalbaseicms_nfe.Text = formata_valor_campo(separar(1))
                txtvlrtotalicms_nfe.Text = formata_valor_campo(separar(2))
                ''''''
                txtvlrtotalbasest_nfe.Text = formata_valor_campo(separar(4))
                txtvlrtotalst_nfe.Text = formata_valor_campo(separar(5))
                '''''''''''''
                txtvlrtotalprod_nfe.Text = formata_valor_campo(separar(6))
                txtvlrtotalfrete_nfe.Text = formata_valor_campo(separar(7))
                txtvlrtotalseg_nfe.Text = formata_valor_campo(separar(8))
                txtvlrtotaldesc_nfe.Text = formata_valor_campo(separar(9))
                '''''''
                txtvrltotalipi_nfe.Text = formata_valor_campo(separar(11))
                txtvlrtotalpis_nfe.Text = formata_valor_campo(separar(12))
                txtvlrtotalcofins_nfe.Text = formata_valor_campo(separar(13))
                txtvlrtotaloutras_nfe.Text = formata_valor_campo(separar(14))
                txtvlrtotal_nfe.Text = formata_valor_campo(separar(15))
                txtvlrtotalaproxtrib.Text = formata_valor_campo(separar(16))
            End If

            If separar(0) = "W04c" Then
                txtvlrtotalvFCPUFDest.Text = formata_valor_campo(separar(1))
            End If
            If separar(0) = "W04e" Then
                txtvlrtotalvICMSUFDest.Text = formata_valor_campo(separar(1))
            End If
            If separar(0) = "W04g" Then
                txtvlrtotalvICMSUFRemet.Text = formata_valor_campo(separar(1))
            End If

            '''''''Rotina dos VModalida de frete''''
            If separar(0) = "X" Then
                cbomodfrete.Text = retorna_mod_frete(separar(1))
            End If
            '''''''Rotina Transportadora''''
            If separar(0) = "X03" Then
                txtnometrp.Text = separar(1)
                txtietrp.Text = separar(2)
                txtendtrp.Text = separar(3)
                txtcidadetrp.Text = separar(4)
                txtuftrp.Text = separar(5)
            End If
            If separar(0) = "X04" Then
                mskcnpjtrp.Mask = "00.000.000/0000-00"
                mskcnpjtrp.Text = separar(1)
            End If
            If separar(0) = "X05" Then
                mskcnpjtrp.Mask = "000.000.000-00"
                mskcnpjtrp.Text = separar(1)
            End If
          
            '''''''Rotina Volumes''''
            If separar(0) = "X26" Then
                txtQvol.Text = separar(1)
                txtesp.Text = separar(2)
                txtmarca.Text = separar(3)
                txtnvol.Text = separar(4)
                txtpesol.Text = separar(5)
                txtpesob.Text = separar(6)
            End If

            '''''''Rotina Faturas''''
            If separar(0) = "Y07" Then
                nrdup += 1

                dgvfatura.Rows.Add(nrdup, separar(1), separar(2), separar(3))

            End If
            '''''''Rotina informacao complementar''''
            If separar(0) = "Z" Then
                txtadifisco.Text = separar(1)
                txtinfcompl.Text = separar(2)
            End If
        Next

        ordem_itens()

        MsgBox("Arquivo carregado com Sucesso !", MsgBoxStyle.Information, "Aviso !")
    End Sub

#End Region


#Region "''''Rotina e funções de validação e tabela IBPT, edicao NFe"

    Public Sub carregaxml_pesquisa()

        Try
            xmldoc.LoadXml(Encoding.UTF8.GetString(frmpesquisarnfe.bytePicData))
        Catch ex As Exception
            xmldoc.LoadXml(Encoding.UTF8.GetString(frmpesquisarnfe.bytePicData).Remove(0, 39))
        End Try

        dgvgrid_xml.Rows.Clear()

        chave()
        dadosnfe()
        fatura()
        dadostrasp()
        itens_nfe()

        ' frminfo.Close()
        TabControl_nfe.SelectTab(TabPrincipal)
        verificar_ean()
        Label78.Text = "Protocolo de Autorização"



        MsgBox("XML carregado Com sucesso !!", MsgBoxStyle.Information, "Aviso !")
    End Sub

    Private Sub carregar_tabela_ibpt()

        Dim DirDiretorio As DirectoryInfo = New DirectoryInfo(Application.StartupPath & "\Tabelas IBPT")

        Dim oFileInfoCollection() As FileInfo

        Dim oFileInfo As FileInfo

        oFileInfoCollection = DirDiretorio.GetFiles("*.csv")

        For i As Integer = 0 To oFileInfoCollection.Length() - 1

            oFileInfo = oFileInfoCollection.GetValue(i)


            If oFileInfo.Name.Substring(0, 14) = "TabelaIBPTax" & txtuffor.Text Then
                txtArquivoibpt.Text = oFileInfo.FullName
            End If


        Next

        If txtArquivoibpt.Text <> "" Then

            dgvibpt.DataSource = GetDataTable(txtArquivoibpt.Text, ";")

            '  MessageBox.Show("Arquivo Carregado com sucesso !", "Arquivo", MessageBoxButtons.OK)
        End If

    End Sub

    Private Sub verificar_ean()
        Dim ean As Boolean = False
        For i As Integer = 0 To dgvgrid_xml.Rows.Count - 1
            If dgvgrid_xml.Rows.Item(i).Cells(5).Value.ToString.Trim = "" Then
                ean = True
            End If
        Next

        If ean = True Then
            MsgBox("Existem Produtos que Não Possui o Código de Barras no Arquivo XML !", MsgBoxStyle.Exclamation, "Aviso !")
        End If
    End Sub

    Public Sub editar_xml_nfe(ByVal xml As String)

        xmldoc.LoadXml(xml)

        dgvgrid_xml.Rows.Clear()
        txtprotocolocanc.Visible = False
        chave()
        dadosnfe()
        fatura()
        dadostrasp()
        itens_nfe()

        ' frminfo.Close()
        TabControl_nfe.SelectTab(TabPrincipal)
        verificar_ean()
        Label78.Text = "Protocolo de Autorização"



        MsgBox("Nota Fiscal carregada com Sucesso !", MsgBoxStyle.Information, "Aviso !")



    End Sub

    Private Sub valida_icms()
        For i As Integer = 0 To dgvgrid_xml.Rows.Count - 1
            If txtuffor.Text = "MG" Then

                If dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5405" Or dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5403" Or dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5401" Or dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5102" Or dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5101" Then
                    dgvgrid_xml.Rows.Item(i).Cells(33).Value = "F"

                    If dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Length = "3" Then
                        If dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 2) = "60" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5405" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 2) = "60" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5403" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 2) = "60" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5401" Then
                            dgvgrid_xml.Rows.Item(i).Cells(33).Value = "V"
                        End If
                        If dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 2) = "70" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5405" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 2) = "70" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5403" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 2) = "70" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5401" Then
                            dgvgrid_xml.Rows.Item(i).Cells(33).Value = "V"
                        End If
                        If dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 2) = "10" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5405" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 2) = "10" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5403" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 2) = "10" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5401" Then
                            dgvgrid_xml.Rows.Item(i).Cells(33).Value = "V"
                        End If
                        If dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 2) = "00" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5102" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 2) = "20" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5101" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 2) = "00" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5101" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 2) = "20" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5102" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 2) = "40" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5102" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 2) = "41" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5102" Then
                            dgvgrid_xml.Rows.Item(i).Cells(33).Value = "V"
                        End If
                    End If

                    If dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Length = "4" Then
                        If dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 3) = "101" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5102" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 3) = "102" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5102" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 3) = "400" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5102" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 3) = "101" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5101" Then
                            dgvgrid_xml.Rows.Item(i).Cells(33).Value = "V"
                        End If
                        If dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 3) = "500" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5405" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 3) = "500" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5403" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 3) = "500" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5401" Then
                            dgvgrid_xml.Rows.Item(i).Cells(33).Value = "V"
                        End If
                        If dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 3) = "201" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5405" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 3) = "201" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5403" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 3) = "201" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5401" Then
                            dgvgrid_xml.Rows.Item(i).Cells(33).Value = "V"
                        End If
                        If dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 3) = "202" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5405" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 3) = "202" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5403" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 3) = "202" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5401" Then
                            dgvgrid_xml.Rows.Item(i).Cells(33).Value = "V"
                        End If
                        If dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 3) = "203" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5405" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 3) = "203" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5403" Or dgvgrid_xml.Rows.Item(i).Cells(8).Value.ToString.Substring(1, 3) = "203" And dgvgrid_xml.Rows.Item(i).Cells(7).Value = "5401" Then
                            dgvgrid_xml.Rows.Item(i).Cells(33).Value = "V"
                        End If
                    End If

                Else
                    dgvgrid_xml.Rows.Item(i).Cells(33).Value = "B"
                End If

            End If




        Next

        '  MsgBox("Validado")
        mudar_cor()
    End Sub

    Private Sub mudar_cor()
        ' colore as notas abaixo de 6 de cor vermelha fundo branco
        Dim estilo_nota As New DataGridViewCellStyle
        estilo_nota.BackColor = Color.Gray
        estilo_nota.ForeColor = Color.Blue

        'percorre as linhas da tabela e verifica se o criterio foi atendido
        'alterando definindo o estilo do item no grid
        For r As Integer = 0 To dgvgrid_xml.Rows.Count - 1

            If dgvgrid_xml.Rows.Item(r).Cells(33).Value = "F" Then
                dgvgrid_xml.Item(0, r).Style = estilo_nota
                dgvgrid_xml.Item(1, r).Style = estilo_nota
                dgvgrid_xml.Item(2, r).Style = estilo_nota
                dgvgrid_xml.Item(3, r).Style = estilo_nota
                dgvgrid_xml.Item(4, r).Style = estilo_nota
                dgvgrid_xml.Item(5, r).Style = estilo_nota
                dgvgrid_xml.Item(6, r).Style = estilo_nota
                dgvgrid_xml.Item(7, r).Style = estilo_nota
                dgvgrid_xml.Item(8, r).Style = estilo_nota
                dgvgrid_xml.Item(9, r).Style = estilo_nota
                dgvgrid_xml.Item(10, r).Style = estilo_nota
                dgvgrid_xml.Item(11, r).Style = estilo_nota
                dgvgrid_xml.Item(12, r).Style = estilo_nota
                dgvgrid_xml.Item(13, r).Style = estilo_nota
                dgvgrid_xml.Item(14, r).Style = estilo_nota
                dgvgrid_xml.Item(15, r).Style = estilo_nota
                dgvgrid_xml.Item(16, r).Style = estilo_nota
                dgvgrid_xml.Item(17, r).Style = estilo_nota
                dgvgrid_xml.Item(18, r).Style = estilo_nota
                dgvgrid_xml.Item(19, r).Style = estilo_nota
                dgvgrid_xml.Item(20, r).Style = estilo_nota
                dgvgrid_xml.Item(21, r).Style = estilo_nota
                dgvgrid_xml.Item(22, r).Style = estilo_nota
                dgvgrid_xml.Item(23, r).Style = estilo_nota
                dgvgrid_xml.Item(24, r).Style = estilo_nota
                dgvgrid_xml.Item(25, r).Style = estilo_nota
                dgvgrid_xml.Item(26, r).Style = estilo_nota
                dgvgrid_xml.Item(27, r).Style = estilo_nota
                dgvgrid_xml.Item(28, r).Style = estilo_nota

                MsgBox("Existem Tributações incorreta nesta Nota fiscal, " & vbCrLf & "A linha Incorreta será marcada em Cor Diferente das demais.", MsgBoxStyle.Exclamation, "Aviso !")
            End If

        Next
    End Sub


#End Region


#Region "''''Regras de validacao do CFOP_item e ICMS_item"
    Private Sub regua_validacao_icms()


        If txtcst_item.Text.Length = 3 Then

            If txtcst_item.Text.Substring(1, 2) = "60" Or txtcst_item.Text.Substring(1, 2) = "40" Then
                txtbaseicms_item.Text = valor_campo_vazio()
                txtvlricms_item.Text = valor_campo_vazio()
                cboaliqicms_item.Text = valor_campo_vazio()
                txtbaseredicms_item.Text = valor_campo_vazio()

                txtbasest_item.Text = valor_campo_vazio()
                cboaliqst_item.Text = valor_campo_vazio()
                txtvlrst_item.Text = valor_campo_vazio()
                txtmva_item.Text = valor_campo_vazio()
            End If

            If txtcst_item.Text.Substring(1, 2) = "00" Or txtcst_item.Text.Substring(1, 2) = "20" Then
                txtbasest_item.Text = valor_campo_vazio()
                cboaliqst_item.Text = valor_campo_vazio()
                txtvlrst_item.Text = valor_campo_vazio()
                txtmva_item.Text = valor_campo_vazio()
            End If

            If txtcst_item.Text.Substring(1, 2) = "30" Then
                txtbaseicms_item.Text = valor_campo_vazio()
                txtvlricms_item.Text = valor_campo_vazio()
                cboaliqicms_item.Text = valor_campo_vazio()
                txtbaseredicms_item.Text = valor_campo_vazio()
            End If

            If txtcst_item.Text.Substring(1, 2) = "10" Then
                'txtbaseredicmsst_item.Text = valor_campo_vazio()
            End If

        End If

        If txtcst_item.Text.Length = 4 Then

            If txtcst_item.Text.Substring(1, 3) = "500" Or txtcst_item.Text.Substring(1, 3) = "102" Or txtcst_item.Text.Substring(1, 3) = "103" _
                Or txtcst_item.Text.Substring(1, 3) = "300" Or txtcst_item.Text.Substring(1, 3) = "400" Then

                txtbaseicms_item.Text = valor_campo_vazio()
                txtvlricms_item.Text = valor_campo_vazio()
                cboaliqicms_item.Text = valor_campo_vazio()
                txtbaseredicms_item.Text = valor_campo_vazio()

                txtbasest_item.Text = valor_campo_vazio()
                cboaliqst_item.Text = valor_campo_vazio()
                txtvlrst_item.Text = valor_campo_vazio()
                txtmva_item.Text = valor_campo_vazio()

            End If

            If txtcst_item.Text.Substring(1, 3) = "101" Then
                txtbasest_item.Text = valor_campo_vazio()
                cboaliqst_item.Text = valor_campo_vazio()
                txtvlrst_item.Text = valor_campo_vazio()
                txtmva_item.Text = valor_campo_vazio()
            End If

            If txtcst_item.Text.Substring(1, 3) = "202" Then
                txtbaseicms_item.Text = valor_campo_vazio()
                txtvlricms_item.Text = valor_campo_vazio()
                cboaliqicms_item.Text = valor_campo_vazio()
                txtbaseredicms_item.Text = valor_campo_vazio()
            End If

        End If


        ''''''''''''''''''''''''Valida campos obrigatorios
        If txtcst_item.Text.Length = 3 Then

            If txtcst_item.Text.Substring(1, 2) = "00" Then

                If cboaliqicms_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe a Aliquota de ICMS (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    cboaliqicms_item.Focus()
                End If

            End If


            If txtcst_item.Text.Substring(1, 2) = "20" Then

                If cboaliqicms_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe a Aliquota de ICMS (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    cboaliqicms_item.Focus()
                End If

                If txtbaseredicms_item = valor_campo_vazio() Then
                    MsgBox("Informe o Percentual da redução da Base do ICMS (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    txtbaseredicms_item.Focus()
                End If

            End If

            If txtcst_item.Text.Substring(1, 2) = "10" Then

                If cboaliqicms_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe a Aliquota de ICMS (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    cboaliqicms_item.Focus()
                End If

                If cboaliqst_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe a Aliquota interna do ICMS/ST (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    cboaliqst_item.Focus()
                End If

                If txtmva_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe o percentual da MVA (Obrigatorio ?)", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    txtmva_item.Focus()
                End If

                '    If txtbaseredicms_item.Text = valor_campo_vazio() Then
                'MsgBox("Informe o Percentual da redução da Base do ICMS (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                '  erro_validacao = True
                '    txtbaseredicms_item.Focus()
                ' End If

            End If


            If txtcst_item.Text.Substring(1, 2) = "70" Then

                If cboaliqicms_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe a Aliquota de ICMS (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    cboaliqicms_item.Focus()
                End If

                If cboaliqst_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe a Aliquota interna do ICMS/ST (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    cboaliqst_item.Focus()
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

                If cboaliqst_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe a Aliquota interna do ICMS/ST (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Regra de Validação ICMS !")
                    erro_validacao = True
                    cboaliqst_item.Focus()
                End If

            End If




        End If

    End Sub

    Private Sub validar_item_cfop()

        If chk_valida_cfop.Checked = True Then

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


            If txtufdest.Text <> txtuffor.Text And txtcfop_item.Text.Substring(0, 1) <> "6" Then
                MsgBox("O CFOP Fora do estado deve inicial com (6)", MsgBoxStyle.Exclamation, "Regra de Validação CFOP!")
                erro_validacao = True
            End If



            If cst_calc = "00" Or cst_calc = "20" Or cst_calc = "40" Or cst_calc = "51" Or cst_calc = "101" Or cst_calc = "102" Or cst_calc = "103" Or cst_calc = "300" Or cst_calc = "400" Then

                If txttipo.Text = "v" Then

                    If txtcfop_item.Text.Substring(1, 1) <> "1" Then
                        MsgBox("O CFOP de venda está incorreto, pois deve iniciar com (51) dentro do estado" & vbCrLf & "ou (61) fora do estado para produtos tributados pelo ICMS", MsgBoxStyle.Exclamation, "Regra de Validação CFOP!")
                        erro_validacao = True
                    End If

                End If

                If txttipo.Text = "d" Then

                    If txtcfop_item.Text.Substring(1, 1) <> "2" Then
                        MsgBox("O CFOP de Devolução está incorreto, pois deve iniciar com (52) dentro do estado" & vbCrLf & "ou (62) fora do estado para produtos tributados pelo ICMS", MsgBoxStyle.Exclamation, "Regra de Validação CFOP !")
                        erro_validacao = True
                    End If

                End If

            End If

            If cst_calc = "10" Or cst_calc = "30" Or cst_calc = "60" Or cst_calc = "70" Or cst_calc = "90" Or cst_calc = "500" Or cst_calc = "201" Or cst_calc = "202" Or cst_calc = "900" Then

                If txttipo.Text = "v" Then

                    If txtcfop_item.Text.Substring(1, 1) <> "4" Then
                        MsgBox("O CFOP de venda ou Devolução está incorreto, pois deve iniciar com (54) dentro estado" & vbCrLf & "ou (64) fora do estado para produtos tributados pelo ICMS/ST !", MsgBoxStyle.Exclamation, "Regra de Validação CFOP !")
                        erro_validacao = True
                    End If

                End If

            End If

        End If
    End Sub

#End Region


#Region "''''Rotina de carregar COMBOBOX"
    Public Sub carrega_natureza(ByVal ent As Integer)
        cbonat.Items.Clear()


        Dim sql As String
        '  Using con As OleDbConnection = GetConnection()

        sql = "SELECT * FROM Natureza_operacao where nfe_saida = '" & ent & "'"
        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read
                cbonat.Items.Add(reader("descricao"))
                'dgvnat.Rows.Add(reader("descricao"), reader("Tipo_nat"), reader("cfop_d1"), reader("cfop_d2"), reader("cfop_f1"), reader("cfop_f2"), reader("Calc_trib"))
            End While

        End Using

    End Sub

    Public Sub carrega_cfop_item()
        Dim sql As String
        txtcfop_item.Items.Clear()

        If optentrada.Checked = True Then
            sql = "SELECT * FROM cfop where codigo like '1%' or codigo like '2%'"
        Else
            sql = "SELECT * FROM cfop where codigo like '5%' or codigo like '6%'"
        End If

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read
                txtcfop_item.Items.Add(New MTGCComboBoxItem(reader("codigo"), reader("descricao")))
            End While

        End Using

        '  End Using
    End Sub
#End Region


#Region "''''Regras de validacao dos COMBOBOX"

    Private Sub cbonat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbonat.KeyPress

        If (e.KeyChar = Chr(13)) Then
            TabControl_nfe.SelectTab(Tabitens)
            txtcodfor_item.Focus()
        End If

    End Sub

    Private Sub cbonat_Validated(sender As Object, e As EventArgs) Handles cbonat.Validated

        If txtprotocolo.Text = "" Then
            If cbofinNFe.Text <> "2-NFe complementar" Then



                Dim verifica As Boolean = False
                For i As Integer = 0 To cbonat.Items.Count - 1

                    If cbonat.Text = cbonat.Items(i).ToString.Trim Then
                        verifica = True
                    End If
                Next

                If verifica = False Then

                    If cbonat.Text <> "" Then
                        MsgBox("O Valor digitado não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
                    End If

                    cbonat.Focus()
                End If



            Else

                cbonat.Text = valor_campo_vazio()
            End If

        End If

    End Sub


    Private Sub txtcfop_item_Validated(sender As Object, e As EventArgs) Handles txtcfop_item.Validated
        If txtprotocolo.Text = "" Then



            Dim verifica As Boolean = False
            For i As Integer = 0 To txtcfop_item.Items.Count - 1

                If txtcfop_item.Text = CType(txtcfop_item.Items(i), MTGCComboBoxItem).Col1 Then
                    verifica = True
                End If

            Next

            If verifica = False Then
                MsgBox("O Valor digitado não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
                txtcfop_item.Focus()
            End If


        End If
    End Sub

    Private Sub cbomod_ecf_Validated(sender As Object, e As EventArgs) Handles cbomod_ecf.Validated
        Dim verifica As Boolean = False
        For i As Integer = 0 To cbomod_ecf.Items.Count - 1

            If cbomod_ecf.Text = cbomod_ecf.Items(i).ToString.Trim Then
                verifica = True
            End If
        Next

        If verifica = False Then
            MsgBox("O Valor digitado não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
            MsgBox("Informação: Código do modelo do Documento Fiscal Preencher com(2B), quando se tratar de Cupom Fiscal emitido por máquina registradora (não ECF), com (2C), quando se tratar de Cupom Fiscal PDV, ou (2D), quando se tratar de Cupom Fiscal (emitido por ECF)", MsgBoxStyle.Exclamation, "Aviso !")
            cbomod_ecf.Focus()
        End If
    End Sub

    Private Sub cbofinNFe_Validated(sender As Object, e As EventArgs) Handles cbofinNFe.Validated
        Dim verifica As Boolean = False
        For i As Integer = 0 To cbofinNFe.Items.Count - 1

            If cbofinNFe.Text = cbofinNFe.Items(i).ToString.Trim Then
                verifica = True
            End If
        Next

        If verifica = False Then
            MsgBox("O Valor digitado não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
            cbofinNFe.Focus()
        End If
    End Sub

    Private Sub cboindPag_Validated(sender As Object, e As EventArgs) Handles cboindPag.Validated
        Dim verifica As Boolean = False
        For i As Integer = 0 To cboindPag.Items.Count - 1

            If cboindPag.Text = cboindPag.Items(i).ToString.Trim Then
                verifica = True
            End If
        Next

        If verifica = False Then
            MsgBox("O Valor digitado não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
            cboindPag.Focus()
        End If
    End Sub

    Private Sub cboindPres_Validated(sender As Object, e As EventArgs) Handles cboindPres.Validated
        Dim verifica As Boolean = False
        For i As Integer = 0 To cboindPres.Items.Count - 1

            If cboindPres.Text = cboindPres.Items(i).ToString.Trim Then
                verifica = True
            End If
        Next

        If verifica = False Then
            MsgBox("O Valor digitado não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
            cboindPres.Focus()
        End If
    End Sub

    Private Sub cboindFinal_Validated(sender As Object, e As EventArgs) Handles cboindFinal.Validated
        Dim verifica As Boolean = False
        For i As Integer = 0 To cboindFinal.Items.Count - 1

            If cboindFinal.Text = cboindFinal.Items(i).ToString.Trim Then
                verifica = True
            End If
        Next

        If verifica = False Then
            MsgBox("O Valor digitado não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
            cboindFinal.Focus()
        End If
    End Sub


    Private Sub cboaliqicms_item_Validated(sender As Object, e As EventArgs) Handles cboaliqicms_item.Validated
        If txtprotocolo.Text = "" Then

            If cbofinNFe.Text <> "2-NFe complementar" Then


                If cboaliqicms_item.Text <> "" Then




                    If cboaliqicms_item.TabStop = True Then

                        Dim verifica As Boolean = False
                        For i As Integer = 0 To cboaliqicms_item.Items.Count - 1

                            If cboaliqicms_item.Text = cboaliqicms_item.Items(i).ToString.Trim Then
                                verifica = True
                            End If
                        Next

                        If verifica = False Then
                            MsgBox("O Valor digitado não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
                            cboaliqicms_item.Focus()
                        End If

                    Else
                        cboaliqicms_item.Text = valor_campo_vazio()
                    End If



                End If



            End If
        End If
    End Sub


    Private Sub cboaliqst_item_Validated(sender As Object, e As EventArgs) Handles cboaliqst_item.Validated

        If cboaliqst_item.Text <> "" Then
            cboaliqst_item.Text = Format(CDec(cboaliqst_item.Text), "#,##0.00")
        End If

        If txtprotocolo.Text = "" Then

            If cbofinNFe.Text <> "2-NFe complementar" Then


                If cboaliqst_item.Text <> "" Then

                    If cboaliqst_item.Text = valor_campo_vazio() Then
                        Exit Sub
                    End If

                    If cboaliqst_item.TabStop = True Then

                        Dim verifica As Boolean = False
                        For i As Integer = 0 To cboaliqst_item.Items.Count - 1

                            If cboaliqst_item.Text = cboaliqst_item.Items(i).ToString.Trim Then
                                verifica = True
                            End If
                        Next

                        If verifica = False Then
                            MsgBox("O Valor digitado não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
                            cboaliqst_item.Focus()
                        End If

                    Else

                        cboaliqst_item.Text = valor_campo_vazio()
                    End If

                End If


            End If
        End If

    End Sub

#End Region


#Region "''''Rotina dos Butoes acima"

    Private Sub novo()
        If cnpj_cert = "" Then
            MsgBox("Esta operação só é permitida com Certificado Digital !" & vbCrLf & "Operação  Cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If
        If cnpj_cert.Length = 11 Then
            MsgBox("Só é permitido emitir NF-e com Certificado Digital de Pessoa Jurídica !" & vbCrLf & "Operação  Cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        '  If cnpj_emp <> cnpj Then
        'MsgBox("CNPJ do Certificado Digital selecionado, Diferente do CNPJ da Empresa Logada No Sistema !" & vbCrLf & "Operação  Cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
        ' Exit Sub
        '

        bntexcluir_item.Enabled = False
        bntalterar_item.Enabled = False

        bntexcluirnfe.Enabled = False
        ' Bntemitirnfe.Enabled = False
        bntimprimir.Enabled = False
        '  bntcancelar.Enabled = False
        bntgravanfe.Enabled = True
        btncarta.Enabled = False
        btninutilizar.Enabled = False
        bntopen.Enabled = False

        ativa_tab()


        limpa_nfe()
        limpar_abas()
        limpar_itens()
        limpardup()

        dgvgrid_xml.Rows.Clear()

        TabControl_nfe.SelectTab(TabPrincipal)

        txtdsaida.Format = DateTimePickerFormat.Custom

        txtdsaida.CustomFormat = "dd/MM/yyyy HH:mm:ss"


        ''''''''''''''''''''Rotina abaixo para preenche emitente da nfe'''''''''''''''''''''''''
        carrega_empresa(empresa.sCNPJ, "novo")



        '''''''''''''''''################'''''''''''''''''''''''''''

        cbomodfrete.Text = "9- Sem Ocorrência de transporte"

        If empresa.scod_trib = 3 Or empresa.scod_trib = 2 Then

            cboaliqicms_item.Items.Clear()

            cboaliqicms_item.Enabled = True

            cboaliqicms_item.Items.Add(formata_valor_campo("7"))
            cboaliqicms_item.Items.Add(formata_valor_campo("12"))
            cboaliqicms_item.Items.Add(formata_valor_campo("18"))
            cboaliqicms_item.Items.Add(formata_valor_campo("27"))
            cboaliqicms_item.Items.Add(valor_campo_vazio())

            cboaliqst_item.Items.Clear()
            cboaliqst_item.Items.Add(formata_valor_campo("7"))
            cboaliqst_item.Items.Add(formata_valor_campo("12"))
            cboaliqst_item.Items.Add(formata_valor_campo("18"))
            cboaliqst_item.Items.Add(formata_valor_campo("25"))
            cboaliqst_item.Items.Add(formata_valor_campo("27"))
            cboaliqst_item.Items.Add(valor_campo_vazio())

        Else

            cboaliqicms_item.Enabled = False

        End If

        ''''''''''''''''''''Rotina preenche campos da nfe da nfe'''''''''''''''''''''''''

        lblnfe.Visible = False

        cbofinNFe.SelectedIndex = cbofinNFe.FindString(1)

        cboindPag.SelectedIndex = cboindPag.FindString(0)
        cboindFinal.SelectedIndex = cboindFinal.FindString(1)
        cboindPres.SelectedIndex = cboindPres.FindString(0)
        cboindPag.SelectedIndex = cboindPag.FindString(99)


        txtprocEmi.Text = "0-Aplicativo do contribuinte"
        '  txtverProc.Text = "NFe++" & FrmPrinciapal.lblver_a.Text.Substring(0, 5)
        txttpEmis.Text = "1-Emissão Normal"

        If optentrada.Checked = True Then
            txttpNF.Text = "0-NFe de Entrada"
            tiponota = "0"
        End If

        If optsaida.Checked = True Then
            txttpNF.Text = "1-NFe de Saída"
            tiponota = "1"
        End If


        If empresa.ambiente_nfe = 1 Then
            txttpAmb.Text = "1-Ambiente Produção"
        Else
            txttpAmb.Text = "2-Ambiente Homologação"
        End If


        inclusao = True

        carrega_cfop_item()
        carrega_natureza(txttpNF.Text.Substring(0, 1))
        mskcnpjcpf_cli.Focus()

        txtverProc.Text = Assembly.GetExecutingAssembly.GetName.Version.ToString
    End Sub

    Private Sub salvar()
        '''''''''''''''Rotina abaixo Gera o xml da nfe normal
        If TabControl_nfe.TabPages(0).Enabled = False Then
            Exit Sub
        End If

        If lblnfe.Visible = True Then
            Exit Sub
        End If

        pinfo.Visible = True
        txtinfo.Text = "Aguarde, Validando Informações..."
        txtinfo.Refresh()

        If cnpj_cert.Length = 11 Then
            MsgBox("Só é permitido emitir NF-e com Certificado Digital de Pessoa Jurídica !" & vbCrLf & "Operação  Cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
            pinfo.Visible = False
            Exit Sub
        End If

        If txtindIEDest.Text = "9 – Não Contribuinte" And cboindFinal.Text = "0-Não" Then
            cboindFinal.Text = "1-Consumidor Final"
        End If


        ' If cnpj_emp <> cnpj Then
        ' MsgBox("CNPJ do Certificado Digital selecionado, Diferente do CNPJ da Empresa Logada No Sistema !" & vbCrLf & "Operação  Cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
        'pinfo.Visible = False
        'Exit Sub
        ' End If

        If cbomodfrete.Text.Substring(0, 1) <> "9" Then
            If txtnometrp.Text = "" Then
                MsgBox("Informe os Dados da  Transportadora ?" & vbCrLf & "Operação Cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
                pinfo.Visible = False
                Exit Sub
            End If
        End If

        '''''''''''''''''''Rotina verifica nfe no banco se esta transmitida ''''''''''''''''''
        '''''''''''''''''''''''''Regra de validacao de cnpj certificado''''''''''''''''''''


        If mskcnpjfor.Text <> cnpj_cert Then
            MsgBox("CNPJ do Certificado Digital informado diferente do CNPJ Emitente da NF-e !" + vbCrLf + "Operação cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
            pinfo.Visible = False
            Exit Sub
        End If

        If cbonat.Text = "" Then
            MsgBox("Informe a Natureza da Operação !" + vbCrLf + "Operação cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
            pinfo.Visible = False
            Exit Sub
        End If


        If cbofinNFe.Text = "3-NFe de ajuste" Then

            ''''''''''''''''''''''Rotinas de validacao nota fisccal de ajuste de campos vazios''''''''''

            If txtvlrtotalicms_nfe.Text = valor_campo_vazio() Then
                MsgBox("Informe o Valor do ICMS da NF-e de Ajuste" + vbCrLf + "Operação cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
                TabControl_nfe.SelectTab(pitens)
                txtvlrtotalicms_nfe.Focus()
                pinfo.Visible = False
                Exit Sub
            End If
            '''''''''''''''''''##########################'''''''''''''''''''''

        End If

        '''''''''''''''''''''''''''''''''''''################################""""""""""""""""""""""""""""""""""""""""""""""""""""""'''''''''''



        If cbofinNFe.Text = "3-NFe de ajuste" Then


            If cbonat.Text = "" Then
                MsgBox("Informe o CFOP da Nota Fiscal de Ajuste (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Aviso !")
                TabControl_nfe.SelectTab(TabPrincipal)
                cbonat.Focus()
                pinfo.Visible = False
                Exit Sub
            End If

            If txtvlrtotalicms_nfe.Text = valor_campo_vazio() Then
                MsgBox("Informe o Valor do ICMS da Nota Fiscal de Ajuste (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Aviso !")
                TabControl_nfe.SelectTab(Tabitens)
                txtvlrtotalicms_nfe.Focus()
                pinfo.Visible = False
                Exit Sub
            End If


            adiciona_item_ajuste()

        End If





        If cbofinNFe.Text = "2-NFe complementar" Then
            If mskchvdevolucao.Text = "" Then
                MsgBox("Informe a chave de acesso da NF-e que será complementada (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Aviso !")
                TabControl_nfe.SelectTab(Tabitens)
                mskchvdevolucao.Focus()
                pinfo.Visible = False
                Exit Sub
            End If
        End If

        If cbofinNFe.Text = "4-Devolução/Retorno" Then
            If mskchvdevolucao.Text = "" Then
                MsgBox("Informe a chave da NF-e referente a está devolução (Obrigatorio) ?", MsgBoxStyle.Exclamation, "Aviso !")
                TabControl_nfe.SelectTab(Tabitens)
                mskchvdevolucao.Focus()
                pinfo.Visible = False
                Exit Sub
            End If
        End If

        '''''''''''Rotina para salvar NFe no banco'''''''''
        If mskchave.Text = "" Then
            gerar_chave_acesso()
        End If

        gravar_nfe()
        ''####################################



        '''''''''''''''''''''''Rotina abaixo gera o xml da NF-e
        txtinfo.Text = "Aguarde, Atualizando informações da NF-e ..."
        txtinfo.Refresh()

        ' carrega_empresa()
        'pesquisa_destinatario()



        '''''''''''''''''''''''Rotina abaixo gera o xml da NF-e
        txtinfo.Text = "Aguarde, Gerando o arquivo da NF-e ..."
        txtinfo.Refresh()

        frmpesquisanfe_emi.gera_xmlnfe(mskchave.Text, "1")


        '''''''''''''''''''''''Rotina gerar xml da NF-e em contigencia'''''''''''''''''''''''''''
        If File.Exists(Application.StartupPath & "\XML\NFE\" & mskchave.Text.Replace(" ", "") & " - EnviNFe.xml") = True Then

            If IsConectedToHost(New Uri("http://www.google.com")) = False Then
                MsgBox("A Nota Fiscal não será transmitida para a SEFAZ, pois você está sem acesso a internet !", MsgBoxStyle.Exclamation, "Aviso !")
                finaliza_emi()
                Exit Sub
            End If

            nrecibo = ""
            xmotivo = ""
            cstat = ""
            xmldoc.LoadXml(Base64Decode(ret_valor_campo("select * from nfe_s where Chave_nfe = '" & mskchave.Text & "'", "xml")))
            '''''''''''''''Rotina abaixo Grava a NF-e no banco de dados'''''''
            txtinfo.Text = "Aguarde, Enviando NFe para SEFAZ..."
            txtinfo.Refresh()
            pinfo.Refresh()


            envia_nfe(mskchave.Text, xmldoc.OuterXml, empresa.ambiente_nfe)

            If cstat = "105" Then
                Tretnfe.Enabled = True
           End If



            ' Bntemitirnfe.Enabled = True
            ' MsgBox("XML gerado com sucesso !")
        Else

            MsgBox("Houve um erro na geração do NF-e, contate o administrador do Sistema" & vbCrLf & "Operação cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
            pinfo.Visible = False

        End If


    End Sub

    Private Sub finaliza_emi()
        limpa_nfe()
        limpar_abas()
        limpar_itens()
        limpardup()

        dgvgrid_xml.Rows.Clear()

        desativa_tab()

        inclusao = False

        bntexcluirnfe.Enabled = True
        ' Bntemitirnfe.Enabled = True
        bntimprimir.Enabled = True
        ' bntcancelar.Enabled = True
        bntgravanfe.Enabled = False
        btncarta.Enabled = True
        btninutilizar.Enabled = True
        bntopen.Enabled = True
        bntnovo.Enabled = True
    End Sub

    Private Sub excluir()

        If TabControl_nfe.TabPages(0).Enabled = False Then
            Exit Sub
        End If

        If mskchave.Text = "" Then
            Exit Sub
        End If

        If txtprotocolo.Text <> "" Then
            MsgBox("A Nota fiscal não pode ser excluida, pois já foi transmitida  para a SEFAZ !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        '''''''''''''''''''Rotina verifica nfe no banco se esta transmitida ''''''''''''''''''


        If MessageBox.Show("Deseja Realmente excluir A Nota Fiscal", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then


            executa_query("delete from nfe_s where Chave_nfe = '" & mskchave.Text & "'")
            executa_query("delete from nfe_sitens where Chave_nfe = '" & mskchave.Text & "'")
            executa_query("delete from nfe_sfat where Chave_nfe = '" & mskchave.Text & "'")
            executa_query("delete from nfe_stransp where Chave_nfe = '" & mskchave.Text & "'")


            MsgBox("A Nota Fiscal foi Excluida com Sucesso !", MsgBoxStyle.Information, "Aviso !")


            Dim Sql As String = "INSERT INTO nfe_inutilizada (N_ini, N_fim, serie, ambiente, cnpj_emp, Chave, xmotivo) VALUES (@N_ini, @N_fim, @serie, @ambiente, @cnpj_emp, @Chave, @xmotivo)"



            conectar_mysqlDFe()
            Dim insertSQL2 As MySqlCommand = New MySqlCommand(Sql, oConn)

            insertSQL2.Parameters.Add(New MySqlParameter("N_ini", mskchave.Text.Substring(25, 9).TrimStart("0")))
            insertSQL2.Parameters.Add(New MySqlParameter("N_fim", mskchave.Text.Substring(25, 9).TrimStart("0")))
            insertSQL2.Parameters.Add(New MySqlParameter("serie", mskchave.Text.Substring(22, 3).TrimStart("0")))
            insertSQL2.Parameters.Add(New MySqlParameter("ambiente", empresa.ambiente_nfe))
            insertSQL2.Parameters.Add(New MySqlParameter("cnpj_emp", empresa.sCNPJ))
            insertSQL2.Parameters.Add(New MySqlParameter("Chave", mskchave.Text))
            insertSQL2.Parameters.Add(New MySqlParameter("xmotivo", "Nota Fiscal excluida, Numeracao Pendente de Inutilizada"))

            insertSQL2.ExecuteNonQuery()
            oConn.Close()

            MsgBox("A Númeração desta NF-e excluida deverá (obrigatoriamente) Ser inutilizada !", MsgBoxStyle.Exclamation, "Aviso !")
        End If

        limpa_nfe()
        limpar_abas()
        limpar_itens()
        limpardup()

        dgvgrid_xml.Rows.Clear()

        desativa_tab()
        bntnovo.Enabled = True


        inclusao = False
    End Sub

    Private Sub imprimirDanfe()

        If cnpj_emp <> removeFormatacao(mskcnpjfor.Text) Then

            ' If File.Exists(txtcaminhoxml.Text) = False Then
            'MsgBox("O arquivo XML foi Excluido ou Caminho não existe !", MsgBoxStyle.Exclamation, "Aviso !")
            '  Exit Sub
            ' End If

        End If

        If txtprotocolo.Text = "" Then
            MsgBox("A Nota Fiscal está sem autorização da SEFaZ !" & vbCrLf & "Operação cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        If mskchave.Text = "" Then
            MsgBox("A Carregue os dados da NF-e para Impressão do DANFE ?", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        Try
            xmldoc.LoadXml(Base64Decode(ret_valor_campo("select * from nfe_s where Chave_nfe = '" & mskchave.Text & "'", "xml")))
        Catch ex As Exception
            xmldoc.LoadXml(ret_valor_campo("select * from nfe_s where Chave_nfe = '" & mskchave.Text & "'", "xml"))
        End Try


        danfe_new(xmldoc.OuterXml)

    End Sub



#End Region


#Region "''''Rotina para capturar os dados do certificado digital"

    Public Sub busca_certificado()

        If nfecer = "" Then
            certificado = SelecionarCertificado("")
        Else
            certificado = SelecionarCertificado(nfecer)
        End If

    End Sub

    Public Sub carrega_dados_certificado()
        If nfecer <> "" Then

            If CDate(certificado.NotAfter.ToString) < Now.Date Then

                Dim wD As Long = DateDiff(DateInterval.Day, CDate(certificado.NotAfter.ToString), Now.Date)

                MsgBox("Faltam " & wD.ToString & " dias para seu certificado digital vencer !", MsgBoxStyle.Exclamation, "Aviso !")
            End If

            frminfocertificado.txtdatavenc.Text = certificado.NotAfter.ToString
            frminfocertificado.txtdataemi.Text = certificado.NotBefore.ToString
            frminfocertificado.txtrazao.Text = certificado.SubjectName.Name

            frminfocertificado.removecarrazao()
            For i As Integer = 0 To certificado.Extensions.Count - 1
                If certificado.Extensions.Item(i).Oid.Value = "2.5.29.17" Then

                    frminfocertificado.txtdadosbruto.Text = certificado.Extensions.Item(i).Format(True)

                End If
            Next

            'frminfocertificado.pegacnpj()


            '  FrmPrinciapal.lbldatacert.Text = frminfocertificado.txtdatavenc.Text
            '  FrmPrinciapal.txtnome_cert.Text = frminfocertificado.txtrazao.Text

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
        pitens.Enabled = True
        bntgravanfe.Enabled = True

        txtprocEmi.Text = "0-Aplicativo do contribuinte"
        txtverProc.Text = Assembly.GetExecutingAssembly.GetName.Version.ToString

        cboindPres.SelectedIndex = cboindPres.FindString("9")
        Try
            cbofinNFe.SelectedIndex = cbofinNFe.FindString(mskchave.Text.Substring(34, 1))
        Catch ex As Exception
            cbofinNFe.SelectedIndex = cbofinNFe.FindString("1")
        End Try

    End Sub



#End Region


#Region "''''Rotinas dos Timers"

    Private Sub tconsultanfe_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tconsultanfe.Tick
        lbltimer.Text = lbltimer.Text + 1
        Dim xmlretcanc = New XmlDocument()

        If lbltimer.Text = "1" Then
            If nfecancelada = False Then
                frminfo.txtinfo.Text = "Aguarde, Realizando a Consulta de Autenticidade da NF-e "
            End If
            If nfecancelada = True Then
                frminfo.txtinfo.Text = "Aguarde, Consultando o protocolo de Cancelamento da NF-e "
            End If
            frminfo.Show()
        End If

        If lbltimer.Text = "2" Then
            'chama a rotina para consulta nfe no sefaz mg
            Dim WebS As New C_WebService
            Dim retornonfe As New RetRetorno


            If mskchave.Text.Replace(" ", "").ToString.Substring(34, 1) = "6" Or mskchave.Text.Replace(" ", "").ToString.Substring(34, 1) = "7" Then
                contigencia = True
            Else
                contigencia = False
            End If


            ' WebS.url_webservice(BuscaURL(mskchave.Text.Replace(" ", "").ToString.Substring(0, 2), 1, contigencia))

            retornonfe = WebS.ConsultaStatusNfe2(mskchave.Text.Replace(" ", ""), 1)

            If retornonfe.cStat <> "100" Then

                If retornonfe.cStat <> "1010" Then
                    MsgBox(retornonfe.xMotivo, MsgBoxStyle.Information, "Retorno do Sefaz")
                    frminfo.Close()
                    tconsultanfe.Dispose()
                End If

            End If



            If retornonfe.cStat = "100" Or retornonfe.cStat = "101" Then
                frmretmanifest.salva_xml()

                If retornonfe.cStat = "101" Then
                    lblcanc.Visible = True
                    lblmotcanc.Visible = True
                    txtprotocolocanc.Visible = True
                    txtxmotivocanc.Visible = True
                    txtxmotivocanc.Text = retornonfe.xMotivo

                    nfecancelada = True
                End If

                If frmretmanifest.dgvsefaz.Rows.Count > 1 Then
                    frmretmanifest.consulta_nfe()
                    frmretmanifest.ShowDialog()
                    frminfo.Close()

                Else

                    For Each RetC In retornonfe.L_Retornos
                        MsgBox("Data da Autorização: " & RetC.dhRecbto & Chr(13) & "Status da NF-e: " & RetC.xMotivo & Chr(13) & "Protocolo da NF-e: " & RetC.nProt, MsgBoxStyle.Information, "Retorno do Sefaz:")

                        If Me.txtprotocolo.Text = "" Then
                            txtprotocolo.Text = RetC.nProt + "  " + RetC.dhRecbto
                            txtxmotivo.Text = RetC.xMotivo
                            Label78.Text = "Protocolo de Autorização"
                        End If

                    Next
                End If

            End If



            frminfo.Close()

        End If

        If lbltimer.Text = "3" Then
            tconsultanfe.Dispose()
        End If
    End Sub



#End Region


#Region "''''Rotinas do datagridview adicionar itens,excluir calcular valores da aba total"

    Private Sub dgvgrid_xml_Click(sender As Object, e As EventArgs) Handles dgvgrid_xml.Click
        If inclusao = False Then

            If txtprotocolo.Text <> "" Then
                itenscod()
            End If

        End If
    End Sub


    Private Sub calcular_valor_totais_nfe()

        txtvlrtotalprod_nfe.Text = CDec(txtvlrtotalprod_nfe.Text) + CDec(txtvlrtotal_item.Text)
        txtvlrtotalprod_nfe.Text = formata_valor_campo(txtvlrtotalprod_nfe.Text)

        txtvlrtotalbaseicms_nfe.Text = CDec(txtvlrtotalbaseicms_nfe.Text) + CDec(txtbaseicms_item.Text)
        txtvlrtotalbaseicms_nfe.Text = formata_valor_campo(txtvlrtotalbaseicms_nfe.Text)

        txtvlrtotalicms_nfe.Text = CDec(txtvlrtotalicms_nfe.Text) + CDec(txtvlricms_item.Text)
        txtvlrtotalicms_nfe.Text = formata_valor_campo(txtvlrtotalicms_nfe.Text)

        txtvlrtotalbasest_nfe.Text = CDec(txtvlrtotalbasest_nfe.Text) + CDec(txtbasest_item.Text)
        txtvlrtotalbasest_nfe.Text = formata_valor_campo(txtvlrtotalbasest_nfe.Text)

        txtvlrtotalst_nfe.Text = CDec(txtvlrtotalst_nfe.Text) + CDec(txtvlrst_item.Text)
        txtvlrtotalst_nfe.Text = formata_valor_campo(txtvlrtotalst_nfe.Text)

        txtvlrtotalpis_nfe.Text = CDec(txtvlrtotalpis_nfe.Text) + CDec(txtvlrpis_item.Text)
        txtvlrtotalpis_nfe.Text = formata_valor_campo(txtvlrtotalpis_nfe.Text)

        txtvlrtotalcofins_nfe.Text = CDec(txtvlrtotalcofins_nfe.Text) + CDec(txtvlrcofins_item.Text)
        txtvlrtotalcofins_nfe.Text = formata_valor_campo(txtvlrtotalcofins_nfe.Text)


        txtvrltotalipi_nfe.Text = CDec(txtvrltotalipi_nfe.Text) + CDec(txtvlripi_item.Text)
        txtvrltotalipi_nfe.Text = formata_valor_campo(txtvrltotalipi_nfe.Text)


        txtvlrtotaldesc_nfe.Text = CDec(txtvlrtotaldesc_nfe.Text) + CDec(txtvlrdesc_item.Text)
        txtvlrtotaldesc_nfe.Text = formata_valor_campo(txtvlrtotaldesc_nfe.Text)


        txtvlrtotalfrete_nfe.Text = CDec(txtvlrtotalfrete_nfe.Text) + CDec(txtvlrfrete_item.Text)
        txtvlrtotalfrete_nfe.Text = formata_valor_campo(txtvlrtotalfrete_nfe.Text)

        '  txtvlrtotalseg_nfe.Text = CDec(txtvlrtotalseg_nfe.Text)

        txtvlrtotaloutras_nfe.Text = CDec(txtvlrtotaloutras_nfe.Text) + CDec(txtvlroutros_item.Text)
        txtvlrtotaloutras_nfe.Text = formata_valor_campo(txtvlrtotaloutras_nfe.Text)

        If chktrib.Checked = True Then
            txtvlrtotalaproxtrib.Text = CDec(txtvlrtotalaproxtrib.Text) + CDec(txtvlrtrib_item.Text)
            txtvlrtotalaproxtrib.Text = formata_valor_campo(txtvlrtotalaproxtrib.Text)
        End If



        '    txtvlrtotalvFCPUFDest.Text = CDec(txtvlrtotalvFCPUFDest.Text) + CDec(txtbaseredicmsst_item.Text)
        '   txtvlrtotalvICMSUFDest.Text = CDec(txtvlrtotalvICMSUFDest.Text) + CDec(txtbaseredicmsst_item.Text)
        '   txtvlrtotalvICMSUFRemet.Text = CDec(txtvlrtotalvICMSUFRemet.Text) + CDec(txtbaseredicmsst_item.Text)


        If chkfundopobreza.Checked = True Then


            txtvlrtotalFCP.Text = CDec(txtvlrtotalFCP.Text) + CDec(txtvFCP.Text)

            txtvlrtotalFCPST.Text = CDec(txtvlrtotalFCPST.Text) + CDec(txtvFCPST.Text)

        End If

        txtvlrtotal_nfe.Text = valor_campo_vazio()
        txtvlrtotal_nfe.Text = (CDec(txtvlrtotalprod_nfe.Text) + CDec(txtvlrtotalst_nfe.Text) + CDec(txtvrltotalipi_nfe.Text) + CDec(txtvlrtotalfrete_nfe.Text) + CDec(txtvlrtotaloutras_nfe.Text) + CDec(txtvlrtotalseg_nfe.Text) + CDec(txtvlrtotalFCPST.Text)) - CDec(txtvlrtotaldesc_nfe.Text)
        txtvlrtotal_nfe.Text = formata_valor_campo(txtvlrtotal_nfe.Text)


    End Sub


    Private Sub Subtrair_valor_totais_nfe()

        txtvlrtotalprod_nfe.Text = CDec(txtvlrtotalprod_nfe.Text) - CDec(dgvgrid_xml.CurrentRow.Cells("vlrtotal").Value)
        txtvlrtotalprod_nfe.Text = formata_valor_campo(txtvlrtotalprod_nfe.Text)

        '  MsgBox(CDec(dgvgrid_xml.CurrentRow.Cells("baseicms").Value))
        ' MsgBox(CDec(txtvlrtotalbaseicms_nfe.Text))
        ' MsgBox(CDec(txtvlrtotalbaseicms_nfe.Text) - CDec(dgvgrid_xml.CurrentRow.Cells("baseicms").Value))
        txtvlrtotalbaseicms_nfe.Text = CDec(txtvlrtotalbaseicms_nfe.Text) - CDec(dgvgrid_xml.CurrentRow.Cells("baseicms").Value)
        txtvlrtotalbaseicms_nfe.Text = formata_valor_campo(txtvlrtotalbaseicms_nfe.Text)

        txtvlrtotalicms_nfe.Text = CDec(txtvlrtotalicms_nfe.Text) - CDec(dgvgrid_xml.CurrentRow.Cells("vlricms").Value)
        txtvlrtotalicms_nfe.Text = formata_valor_campo(txtvlrtotalicms_nfe.Text)

        txtvlrtotalbasest_nfe.Text = CDec(txtvlrtotalbasest_nfe.Text) - CDec(dgvgrid_xml.CurrentRow.Cells("basest").Value)
        txtvlrtotalbasest_nfe.Text = formata_valor_campo(txtvlrtotalbasest_nfe.Text)

        txtvlrtotalst_nfe.Text = CDec(txtvlrtotalst_nfe.Text) - CDec(dgvgrid_xml.CurrentRow.Cells("vlrst").Value)
        txtvlrtotalst_nfe.Text = formata_valor_campo(txtvlrtotalst_nfe.Text)

        txtvlrtotalpis_nfe.Text = CDec(txtvlrtotalpis_nfe.Text) - CDec(dgvgrid_xml.CurrentRow.Cells("vlrpis").Value)
        txtvlrtotalpis_nfe.Text = formata_valor_campo(txtvlrtotalpis_nfe.Text)

        txtvlrtotalcofins_nfe.Text = CDec(txtvlrtotalcofins_nfe.Text) - CDec(dgvgrid_xml.CurrentRow.Cells("vlrcofins").Value)
        txtvlrtotalcofins_nfe.Text = formata_valor_campo(txtvlrtotalcofins_nfe.Text)

        txtvrltotalipi_nfe.Text = CDec(txtvrltotalipi_nfe.Text) - CDec(dgvgrid_xml.CurrentRow.Cells("vlripi").Value)
        txtvrltotalipi_nfe.Text = formata_valor_campo(txtvrltotalipi_nfe.Text)


        txtvlrtotaldesc_nfe.Text = CDec(txtvlrtotaldesc_nfe.Text) - CDec(dgvgrid_xml.CurrentRow.Cells("vlrdesc").Value)
        txtvlrtotaldesc_nfe.Text = formata_valor_campo(txtvlrtotaldesc_nfe.Text)


        txtvlrtotalfrete_nfe.Text = CDec(txtvlrtotalfrete_nfe.Text) - CDec(dgvgrid_xml.CurrentRow.Cells("vlrfrete").Value)
        txtvlrtotalfrete_nfe.Text = formata_valor_campo(txtvlrtotalfrete_nfe.Text)



        txtvlrtotaloutras_nfe.Text = CDec(txtvlrtotaloutras_nfe.Text) - CDec(dgvgrid_xml.CurrentRow.Cells("vlroutros").Value)
        txtvlrtotaloutras_nfe.Text = formata_valor_campo(txtvlrtotaloutras_nfe.Text)

        If chktrib.Checked = True Then
            If txtvlrtotalaproxtrib.Text <> "" Then
                txtvlrtotalaproxtrib.Text = CDec(txtvlrtotalaproxtrib.Text) - CDec(dgvgrid_xml.CurrentRow.Cells("valor_aprox_trib").Value)
                txtvlrtotalaproxtrib.Text = formata_valor_campo(txtvlrtotalaproxtrib.Text)
            End If
        End If

        If txtvlrtotalvFCPUFDest.Text <> "" Then
            txtvlrtotalvFCPUFDest.Text = CDec(txtvlrtotalvFCPUFDest.Text) - CDec(dgvgrid_xml.CurrentRow.Cells("vFCPUFDest").Value)
        End If
        If txtvlrtotalvICMSUFRemet.Text <> "" Then
            txtvlrtotalvICMSUFRemet.Text = CDec(txtvlrtotalvICMSUFDest.Text) - CDec(dgvgrid_xml.CurrentRow.Cells("vICMSUFRemet").Value)
        End If
        If txtvlrtotalvICMSUFDest.Text <> "" Then
            txtvlrtotalvICMSUFDest.Text = CDec(txtvlrtotalvICMSUFRemet.Text) - CDec(dgvgrid_xml.CurrentRow.Cells("vICMSUFDest").Value)
        End If






        txtvlrtotal_nfe.Text = valor_campo_vazio()
        txtvlrtotal_nfe.Text = (CDec(txtvlrtotalprod_nfe.Text) + CDec(txtvlrtotalst_nfe.Text) + CDec(txtvrltotalipi_nfe.Text) + CDec(txtvlrtotalfrete_nfe.Text) + CDec(txtvlrtotaloutras_nfe.Text) + CDec(txtvlrtotalseg_nfe.Text)) - CDec(txtvlrtotaldesc_nfe.Text)
        txtvlrtotal_nfe.Text = formata_valor_campo(txtvlrtotal_nfe.Text)



        txtvlrtotalFCP.Text = formata_valor_campo(CDec(txtvlrtotalFCP.Text) - CDec(txtvFCP.Text))
        txtvlrtotalFCPST.Text = formata_valor_campo(CDec(txtvlrtotalFCPST.Text) - CDec(txtvFCPST.Text))

    End Sub


    Private Sub calcula_icms_partilha()

        txtpICMSInterPart_item.Text = formata_valor_campo("100,00")

        txtpFCPUFDest_item.Text = valor_campo_vazio()
        txtvBCUFDest_item.Text = valor_campo_vazio()

        If txtufdest.Text = "MG" Or txtufdest.Text = "RJ" Or txtufdest.Text = "SP" Or txtufdest.Text = "PR" Or txtufdest.Text = "SC" Or txtufdest.Text = "RS" Then
            txtpICMSInter_item.Text = formata_valor_campo("12,00")
        End If

        If txtufdest.Text = "RO" Or txtufdest.Text = "AC" Or txtufdest.Text = "AM" Or txtufdest.Text = "RR" Or txtufdest.Text = "PA" _
            Or txtufdest.Text = "AP" Or txtufdest.Text = "TO" Or txtufdest.Text = "MA" Or txtufdest.Text = "PI" Or txtufdest.Text = "CE" _
            Or txtufdest.Text = "RN" Or txtufdest.Text = "PB" Or txtufdest.Text = "PE" Or txtufdest.Text = "AL" Or txtufdest.Text = "SE" _
           Or txtufdest.Text = "BA" Or txtufdest.Text = "ES" Then
            txtpICMSInter_item.Text = formata_valor_campo("7,00")
        End If

        If cboaliqicms_item.Text = "4,00" Then
            txtpICMSInter_item.Text = formata_valor_campo("4,00")
        End If

        If txtcst_item.Text.Substring(txtcst_item.Text.Length - 2, 2) = "00" Then

            txtpICMSUFDest_item.Text = cboaliqicms_item.Text

            'Base do ICMS = Valor do produto + Frete + Outras Despesas Acessórias – Descontos + IPI
            txtvBCUFDest_item.Text = CDec(txtvlrtotal_item.Text) + CDec(txtvlrfrete_item.Text) + CDec(txtvlroutros_item.Text) - CDec(txtvlrdesc_item.Text) + CDec(txtvlripi_item.Text)


            'Base do ICMS * ((%Alíquota do ICMS Intra – %Alíquota do ICMS Inter) / 100)
            txtvlrdificms_item.Text = CDec(txtvBCUFDest_item.Text) * (((CDec(txtpICMSUFDest_item.Text) - CDec(txtpICMSInter_item.Text)) / 100))

            'Parte UF Destino = Valor do DIFAL * (%40Destino / 100)
            txtvICMSUFDest_item.Text = CDec(txtvlrdificms_item.Text) * (CDec(txtpICMSInterPart_item.Text) / 100)
            txtvICMSUFDest_item.Text = formata_valor_campo(txtvICMSUFDest_item.Text)

            ' Passo 2 – calcular o Fundo de Combate à Pobreza
            If chkfundopobreza.Checked = True Then
                txtvICMSUFDest_item.Text = CDec(txtvICMSUFDest_item.Text) + (CDec(txtvBCUFDest_item.Text) * 2 / 100)
                txtvICMSUFDest_item.Text = formata_valor_campo(txtvICMSUFDest_item.Text)
            End If

            'preenche os valores totais''''''''''''
            txtvlrtotalvICMSUFDest.Text = CDec(txtvlrtotalvICMSUFDest.Text) + CDec(txtvICMSUFDest_item.Text)
            txtvlrtotalvICMSUFDest.Text = formata_valor_campo(txtvlrtotalvICMSUFDest.Text)

            'Parte UF Origem = Valor do DIFAL * (%60Origem / 100)
            txtvICMSUFRemet_item.Text = CDec(txtvlrdificms_item.Text) * ((100 - CDec(txtpICMSInterPart_item.Text)) / 100)
            txtvICMSUFRemet_item.Text = formata_valor_campo(txtvICMSUFRemet_item.Text)

            'preenche os valores totais''''''''''''
            txtvlrtotalvICMSUFRemet.Text = CDec(txtvlrtotalvICMSUFRemet.Text) + CDec(txtvICMSUFRemet_item.Text)
            txtvlrtotalvICMSUFRemet.Text = formata_valor_campo(txtvlrtotalvICMSUFRemet.Text)



        End If


    End Sub

    Private Sub calcular_valor_itens()

        ''''''''''''''''''''Pega a cst para calculo dos valores do tributo'''''''''''''''''''''''''''''''
        Dim cst_calc As String

        If txtcst_item.Text <> "" Then

            If empresa.scod_trib = 3 Then
                cst_calc = txtcst_item.Text.Substring(1, 2)
            Else
                cst_calc = txtcst_item.Text.Substring(1, 3)
            End If
        Else
            cst_calc = "0"
        End If

        If txtqtdecx_item.Text = "" Then
            txtqtdecx_item.Text = "1"
        End If

        ''''''''''''''''''''calcular Valor Total dos itens'''''''''''''''''''''''''''''''
        If txtqtde_item.Text <> "" Then
            txtvlrtotal_item.Text = CDec(txtvlrunit_item.Text) * CDec(txtqtde_item.Text)
            txtvlrtotal_item.Text = formata_valor_campo(txtvlrtotal_item.Text)
        End If
        ''''''''''''''''''''''#####################################""""""""""""""""""""""""""""""'


        ''''''''''''''''''''calcular Valor Total com desconto'''''''''''''''''''''''''''''''

        If txtvlrdesc_item.Text <> valor_campo_vazio() Then
            txtvlrtotal_cdesc_item.Text = CDec(txtvlrtotal_item.Text) - CDec(txtvlrdesc_item.Text)
            txtvlrtotal_cdesc_item.Text = formata_valor_campo(txtvlrtotal_cdesc_item.Text)
        End If

        If txtvlrdesc_item.Text = valor_campo_vazio() Then
            txtvlrtotal_cdesc_item.Text = txtvlrtotal_item.Text
            txtvlrtotal_cdesc_item.Text = formata_valor_campo(txtvlrtotal_cdesc_item.Text)
        End If
        ''''''''''''''''''''''#####################################"""


        ''''''''''''''''''''calcular Valor da Base de ICMS e valor ICMS'''''''''''''''''''''''''''''''
        If txtbaseredicms_item.Text = "" Then
            txtbaseredicms_item.Text = "0"
        End If


        If cst_calc = "00" Or cst_calc = "20" Or cst_calc = "30" Or cst_calc = "10" Or cst_calc = "70" Or cst_calc = "90" Or cst_calc = "101" Or cst_calc = "201" Or cst_calc = "202" Or cst_calc = "900" Then

            txtbaseicms_item.Text = CDec(txtvlrtotal_cdesc_item.Text) - (CDec(txtvlrtotal_cdesc_item.Text) * CDec(txtbaseredicms_item.Text) / 100)
            txtbaseicms_item.Text = formata_valor_campo(txtbaseicms_item.Text)

            cboaliqicms_item.TabStop = True
            txtbaseredicms_item.TabStop = True
        Else
            cboaliqicms_item.TabStop = False
            txtbaseredicms_item.TabStop = False
        End If



        ''''''''''''''''''''calcular Reducao base da ICMS cst020'''''''''''''''''''''''''''''''


        If txtbaseredicms_item.Text <> valor_campo_vazio() Then
            txtbaseicms_item.Text = CDec(txtbaseicms_item.Text) - (CDec(txtbaseicms_item.Text) * (CDec(txtbaseredicms_item.Text) / 100))
            txtbaseicms_item.Text = formata_valor_campo(txtbaseicms_item.Text)
        End If

        If cboaliqicms_item.Text = "" Then
            cboaliqicms_item.Text = "0,00"
        End If

        cboaliqicms_item.Text = formata_valor_campo(cboaliqicms_item.Text)
        txtvlricms_item.Text = CDec(txtbaseicms_item.Text) * (CDec(cboaliqicms_item.Text) / 100)
        txtvlricms_item.Text = formata_valor_campo(txtvlricms_item.Text)
        ''''''''''''''''''''''#####################################""""""""""""""""""""""""""""""'



        ''''''''''''''''''''calcular Valor da Base de ICMS ST e valor ICMS ST'''''''''''''''''''''''''''''''
        If cst_calc = "30" Or cst_calc = "10" Or cst_calc = "70" Or cst_calc = "90" Or cst_calc = "201" Or cst_calc = "202" Or cst_calc = "900" Then


            txtbasest_item.Text = CDec(txtvlrtotal_cdesc_item.Text) + ((CDec(txtvlrtotal_cdesc_item.Text) * CDec(txtmva_item.Text)) / 100)
            txtbasest_item.Text = formata_valor_campo(txtbasest_item.Text)

            If txtbaseredicmsst_item.Text = "" Then
                txtbaseredicmsst_item.Text = "0"
            End If
            If cboaliqst_item.Text = "" Then
                cboaliqst_item.Text = "0"
            End If

            If txtbaseredicmsst_item.Text <> valor_campo_vazio() Then
                ''''''''''''''''''''calcular Reducao base da ST cst070'''''''''''''''''''''''''''''''
                txtbasest_item.Text = CDec(txtbasest_item.Text) - (CDec(txtbasest_item.Text) * (CDec(txtbaseredicmsst_item.Text) / 100))
                txtbasest_item.Text = formata_valor_campo(txtbasest_item.Text)
            End If

            txtvlrst_item.Text = ((CDec(txtbasest_item.Text) * CDec(cboaliqst_item.Text)) / 100) - CDec(txtvlricms_item.Text)
            txtvlrst_item.Text = formata_valor_campo(txtvlrst_item.Text)

            cboaliqst_item.TabStop = True
            txtmva_item.TabStop = True
        Else
            cboaliqst_item.TabStop = False
            txtmva_item.TabStop = False
        End If
        ''''''''''''''''''''''#####################################""""""""""""""""""""""""""""""'




        ''''''''''''''''''''calcular Valor e Base do PIS/PASEP'''''''''''''''''''''''''''''''
        If txtaliqpis_item.Text = "" Then
            txtaliqpis_item.Text = valor_campo_vazio()
        End If
        If txtaliqcofins_item.Text = "" Then
            txtaliqcofins_item.Text = valor_campo_vazio()
        End If

        txtvlrpis_item.Text = CDec(txtvlrtotal_cdesc_item.Text) * (CDec(txtaliqpis_item.Text) / 100)
        txtvlrpis_item.Text = formata_valor_campo(txtvlrpis_item.Text)


        ''''''''''''''''''''calcular Valor e Base do COFINS'''''''''''''''''''''''''''''''
        txtvlrcofins_item.Text = CDec(txtvlrtotal_cdesc_item.Text) * (CDec(txtaliqcofins_item.Text) / 100)
        txtvlrcofins_item.Text = formata_valor_campo(txtvlrcofins_item.Text)
        ''''''''''''''''''''''#####################################""""""""""""""""""""""""""""""'


        ''''''''''''''''''''calcular Valor e Base do IPI'''''''''''''''''''''''''''''''
        txtvlripi_item.Text = CDec(txtvlrtotal_cdesc_item.Text) * (CDec(txtaliqIPI_item.Text) / 100)
        txtvlripi_item.Text = formata_valor_campo(txtvlripi_item.Text)




        ''''''''''''''''''''calcular FUndo de combate a pobresa FCP'''''''''''''''''''''''''''''''
        If chkfundopobreza.Checked = True Then

            If cst_calc = "00" Or cst_calc = "20" Then
                txtvBCFCP.Text = formata_valor_campo(CDec(txtbaseicms_item.Text) + ((CDec(txtpFCP.Text) * CDec(txtbaseicms_item.Text)) / 100))
                txtvFCP.Text = formata_valor_campo((CDec(txtpFCP.Text) * CDec(txtvBCFCP.Text)) / 100)
            End If

            If cst_calc = "10" Or cst_calc = "70" Then
                txtvBCFCP.Text = txtbaseicms_item.Text
                txtvFCP.Text = formata_valor_campo((CDec(txtpFCP.Text) * CDec(txtvBCFCP.Text)) / 100)


                txtvBCFCPST.Text = txtbasest_item.Text
                txtvFCPST.Text = formata_valor_campo((CDec(txtpFCPST.Text) * CDec(txtvBCFCPST.Text)) / 100)
            End If
        End If





    End Sub


    Private Sub ordem_itens()

        For i As Integer = 0 To dgvgrid_xml.Rows.Count - 1
            dgvgrid_xml.Rows.Item(i).Cells("Nr").Value = i + 1
        Next

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



        dgvgrid_xml.Rows.Item(i).Cells("codfor").Value = txtcodfor_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("descricao").Value = txtdesc_item.Text.TrimEnd()
        dgvgrid_xml.Rows.Item(i).Cells("qtde").Value = txtqtde_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vlrunit").Value = txtvlrunit_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vlrtotal").Value = txtvlrtotal_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("codbarra").Value = txtcodbarra_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("ncm").Value = txtncm_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("cfop").Value = txtcfop_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("cst").Value = txtcst_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("aliqicms").Value = cboaliqicms_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vlricms").Value = txtvlricms_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vlrst").Value = txtvlrst_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("cstpis").Value = txtcstpis_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("aliqpis").Value = txtaliqpis_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vlrpis").Value = txtvlrpis_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("cstcofins").Value = txtcstcofins_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("aliqcofins").Value = txtaliqcofins_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vlrcofins").Value = txtvlrcofins_item.Text



        dgvgrid_xml.Rows.Item(i).Cells("un").Value = txtun_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("mva").Value = txtmva_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("aliqst").Value = cboaliqst_item.Text

        dgvgrid_xml.Rows.Item(i).Cells("cstipi").Value = txtcstipi_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("aliqipi").Value = txtaliqIPI_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vlripi").Value = txtvlripi_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vlrdesc").Value = txtvlrdesc_item.Text

        dgvgrid_xml.Rows.Item(i).Cells("lote").Value = txtlote_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("pmc").Value = txtpmc_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("datavenc").Value = mskdvenc_item.Text


        dgvgrid_xml.Rows.Item(i).Cells("baseicms").Value = txtbaseicms_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("basest").Value = txtbasest_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("predbc").Value = txtbaseredicms_item.Text


        dgvgrid_xml.Rows.Item(i).Cells("valor_aprox_trib").Value = txtvlrtrib_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("inf_adi_prod").Value = txtinfoadic_item.Text

        dgvgrid_xml.Rows.Item(i).Cells("vlroutros").Value = txtvlroutros_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("qtdecx").Value = txtqtdecx_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vlrfrete").Value = txtvlrfrete_item.Text


        dgvgrid_xml.Rows.Item(i).Cells("cest").Value = txtcest_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("ex_tipe").Value = txtncmex_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("predbcst").Value = txtbaseredicmsst_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vicmsdeson").Value = "0.00"
        dgvgrid_xml.Rows.Item(i).Cells("motdesicms").Value = ""

        dgvgrid_xml.Rows.Item(i).Cells("vlrtotal_cdesc").Value = txtvlrtotal_cdesc_item.Text


        dgvgrid_xml.Rows.Item(i).Cells("vBCUFDest").Value = txtvBCUFDest_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("pFCPUFDest").Value = txtpFCPUFDest_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("pICMSUFDest").Value = txtpICMSUFDest_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("pICMSInter").Value = txtpICMSInter_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("pICMSInterPart").Value = txtpICMSInterPart_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vFCPUFDest").Value = txtvFCPUFDest_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vICMSUFRemet").Value = txtvICMSUFRemet_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vICMSUFDest").Value = txtvICMSUFDest_item.Text


        dgvgrid_xml.Rows.Item(i).Cells("vBCFCP").Value = txtvBCFCP.Text
        dgvgrid_xml.Rows.Item(i).Cells("pFCP").Value = txtpFCP.Text
        dgvgrid_xml.Rows.Item(i).Cells("vFCP").Value = txtvFCP.Text

        dgvgrid_xml.Rows.Item(i).Cells("vBCFCPST").Value = txtvBCFCPST.Text
        dgvgrid_xml.Rows.Item(i).Cells("pFCPST").Value = txtpFCPST.Text
        dgvgrid_xml.Rows.Item(i).Cells("vFCPST").Value = txtvFCPST.Text


    End Sub


    Private Sub itenscod()
        If dgvgrid_xml.Rows.Count <> "0" Then
            limpar_itens()
            txtdesc_item.Text = dgvgrid_xml.CurrentRow.Cells("descricao").Value
            txtcodbarra_item.Text = dgvgrid_xml.CurrentRow.Cells("codbarra").Value
            txtcodfor_item.Text = dgvgrid_xml.CurrentRow.Cells("codfor").Value
            txtvlrunit_item.Text = dgvgrid_xml.CurrentRow.Cells("vlrunit").Value
            txtvrlvd_cad.Text = dgvgrid_xml.CurrentRow.Cells("vlrunit").Value
            txtqtde_item.Text = dgvgrid_xml.CurrentRow.Cells("qtde").Value.ToString.Replace(".", ",")
            txtqtdecx_item.Text = dgvgrid_xml.CurrentRow.Cells("Qtdecx").Value


            txtcfop_item.SelectedText = 0
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
            cboaliqst_item.SelectedText = 0
            cboaliqst_item.Text = dgvgrid_xml.CurrentRow.Cells("aliqst").Value
            txtlote_item.Text = dgvgrid_xml.CurrentRow.Cells("lote").Value
            cboaliqicms_item.SelectedText = 0
            cboaliqicms_item.Text = dgvgrid_xml.CurrentRow.Cells("aliqicms").Value
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

            txtvlrtotal_cdesc_item.Text = CDec(txtvlrtotal_item.Text) - CDec(txtvlrdesc_item.Text)
            txtvlrtotal_cdesc_item.Text = Format(CDec(txtvlrtotal_cdesc_item.Text), "#,##0.00")

            If dgvgrid_xml.CurrentRow.Cells("inf_adi_prod").Value <> "" Then
                inf_adici_prod.Visible = True
                txtinfoadic_item.Text = dgvgrid_xml.CurrentRow.Cells("inf_adi_prod").Value
            Else
                inf_adici_prod.Visible = False
            End If


            txtvBCFCP.Text = dgvgrid_xml.CurrentRow.Cells("vBCFCP").Value
            txtpFCP.Text = dgvgrid_xml.CurrentRow.Cells("pFCP").Value
            txtvFCP.Text = dgvgrid_xml.CurrentRow.Cells("vFCP").Value

            txtvBCFCPST.Text = dgvgrid_xml.CurrentRow.Cells("vBCFCPST").Value
            txtpFCPST.Text = dgvgrid_xml.CurrentRow.Cells("pFCPST").Value
            txtvFCPST.Text = dgvgrid_xml.CurrentRow.Cells("vFCPST").Value

            If txtvFCP.Text <> valor_campo_vazio() Then
                chkfundopobreza.Checked = True
            Else
                chkfundopobreza.Checked = False
            End If

        End If
    End Sub


    Private Sub formata_grid()

        For i As Integer = 0 To dgvgrid_xml.Rows.Count - 1

            dgvgrid_xml.Rows.Item(i).Cells("qtde").Value = dgvgrid_xml.Rows.Item(i).Cells("qtde").Value.Replace(".", ",")
            dgvgrid_xml.Rows.Item(i).Cells("qtde").Value = Format(CDec(dgvgrid_xml.Rows.Item(i).Cells("qtde").Value), "#####0.000")
            dgvgrid_xml.Rows.Item(i).Cells("qtde").Value = dgvgrid_xml.Rows.Item(i).Cells("qtde").Value.Replace(",", ".")

            dgvgrid_xml.Rows.Item(i).Cells("aliqicms").Value = formata_valor_campo(dgvgrid_xml.Rows.Item(i).Cells("aliqicms").Value)
            dgvgrid_xml.Rows.Item(i).Cells("vlricms").Value = formata_valor_campo(dgvgrid_xml.Rows.Item(i).Cells("vlricms").Value)
            dgvgrid_xml.Rows.Item(i).Cells("vlrst").Value = formata_valor_campo(dgvgrid_xml.Rows.Item(i).Cells("vlrst").Value)

            dgvgrid_xml.Rows.Item(i).Cells("aliqpis").Value = formata_valor_campo(dgvgrid_xml.Rows.Item(i).Cells("aliqpis").Value)
            dgvgrid_xml.Rows.Item(i).Cells("vlrpis").Value = formata_valor_campo(dgvgrid_xml.Rows.Item(i).Cells("vlrpis").Value)

            dgvgrid_xml.Rows.Item(i).Cells("aliqcofins").Value = formata_valor_campo(dgvgrid_xml.Rows.Item(i).Cells("aliqcofins").Value)
            dgvgrid_xml.Rows.Item(i).Cells("vlrcofins").Value = formata_valor_campo(dgvgrid_xml.Rows.Item(i).Cells("vlrcofins").Value)

            dgvgrid_xml.Rows.Item(i).Cells("mva").Value = formata_valor_campo(dgvgrid_xml.Rows.Item(i).Cells("mva").Value)
            dgvgrid_xml.Rows.Item(i).Cells("aliqst").Value = formata_valor_campo(dgvgrid_xml.Rows.Item(i).Cells("aliqst").Value)

            dgvgrid_xml.Rows.Item(i).Cells("vlripi").Value = formata_valor_campo(dgvgrid_xml.Rows.Item(i).Cells("vlripi").Value)
            dgvgrid_xml.Rows.Item(i).Cells("vlrdesc").Value = formata_valor_campo(dgvgrid_xml.Rows.Item(i).Cells("vlrdesc").Value)

            dgvgrid_xml.Rows.Item(i).Cells("aliqipi").Value = formata_valor_campo(dgvgrid_xml.Rows.Item(i).Cells("aliqipi").Value)
            dgvgrid_xml.Rows.Item(i).Cells("valor_aprox_trib").Value = formata_valor_campo(dgvgrid_xml.Rows.Item(i).Cells("valor_aprox_trib").Value)

            dgvgrid_xml.Rows.Item(i).Cells("vlroutros").Value = formata_valor_campo(dgvgrid_xml.Rows.Item(i).Cells("vlroutros").Value)

            dgvgrid_xml.Rows.Item(i).Cells("vlrfrete").Value = formata_valor_campo(dgvgrid_xml.Rows.Item(i).Cells("vlrfrete").Value)
            dgvgrid_xml.Rows.Item(i).Cells("predbcst").Value = formata_valor_campo(dgvgrid_xml.Rows.Item(i).Cells("predbcst").Value)

            dgvgrid_xml.Rows.Item(i).Cells("vicmsdeson").Value = formata_valor_campo(dgvgrid_xml.Rows.Item(i).Cells("vicmsdeson").Value)
        Next
    End Sub


    Private Sub adiciona_item_ajuste()
        Dim i As Integer
        dgvgrid_xml.Rows.Add()

        i = dgvgrid_xml.Rows.Count - 1

        dgvgrid_xml.Rows.Item(i).Cells("codfor").Value = "CFOP" & txtcfop_icms.Text
        dgvgrid_xml.Rows.Item(i).Cells("descricao").Value = cbonat.Text
        dgvgrid_xml.Rows.Item(i).Cells("qtde").Value = "0.000"
        dgvgrid_xml.Rows.Item(i).Cells("vlrunit").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("vlrtotal").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("codbarra").Value = "SEM GTIN"
        dgvgrid_xml.Rows.Item(i).Cells("ncm").Value = "96170010"
        dgvgrid_xml.Rows.Item(i).Cells("cfop").Value = txtcfop_icms.Text




        dgvgrid_xml.Rows.Item(i).Cells("un").Value = "R$"

        dgvgrid_xml.Rows.Item(i).Cells("cst").Value = "090"
        dgvgrid_xml.Rows.Item(i).Cells("aliqicms").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("vlricms").Value = txtvlrtotalicms_nfe.Text
        dgvgrid_xml.Rows.Item(i).Cells("baseicms").Value = valor_campo_vazio()


        dgvgrid_xml.Rows.Item(i).Cells("vlrst").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("cstpis").Value = "07"
        dgvgrid_xml.Rows.Item(i).Cells("aliqpis").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("vlrpis").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("cstcofins").Value = "07"
        dgvgrid_xml.Rows.Item(i).Cells("aliqcofins").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("vlrcofins").Value = valor_campo_vazio()




        dgvgrid_xml.Rows.Item(i).Cells("mva").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("aliqst").Value = valor_campo_vazio()

        dgvgrid_xml.Rows.Item(i).Cells("cstipi").Value = txtcstipi_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("aliqipi").Value = txtaliqIPI_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vlripi").Value = txtvlripi_item.Text
        dgvgrid_xml.Rows.Item(i).Cells("vlrdesc").Value = txtvlrdesc_item.Text

        dgvgrid_xml.Rows.Item(i).Cells("lote").Value = ""
        dgvgrid_xml.Rows.Item(i).Cells("pmc").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("datavenc").Value = ""



        dgvgrid_xml.Rows.Item(i).Cells("basest").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("predbc").Value = valor_campo_vazio()


        dgvgrid_xml.Rows.Item(i).Cells("valor_aprox_trib").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("inf_adi_prod").Value = ""

        dgvgrid_xml.Rows.Item(i).Cells("vlroutros").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("qtdecx").Value = "1"
        dgvgrid_xml.Rows.Item(i).Cells("vlrfrete").Value = valor_campo_vazio()


        dgvgrid_xml.Rows.Item(i).Cells("cest").Value = ""
        dgvgrid_xml.Rows.Item(i).Cells("ex_tipe").Value = ""
        dgvgrid_xml.Rows.Item(i).Cells("predbcst").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("vicmsdeson").Value = "0.00"
        dgvgrid_xml.Rows.Item(i).Cells("motdesicms").Value = ""

        dgvgrid_xml.Rows.Item(i).Cells("vlrtotal_cdesc").Value = valor_campo_vazio()


        dgvgrid_xml.Rows.Item(i).Cells("vBCUFDest").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("pFCPUFDest").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("pICMSUFDest").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("pICMSInter").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("pICMSInterPart").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("vFCPUFDest").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("vICMSUFRemet").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("vICMSUFDest").Value = valor_campo_vazio()


        dgvgrid_xml.Rows.Item(i).Cells("vBCFCP").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("pFCP").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("vFCP").Value = valor_campo_vazio()

        dgvgrid_xml.Rows.Item(i).Cells("vBCFCPST").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("pFCPST").Value = valor_campo_vazio()
        dgvgrid_xml.Rows.Item(i).Cells("vFCPST").Value = valor_campo_vazio()


    End Sub

#End Region


#Region "''''formatacao dos campos textbox no evento _keypress e lostfocus"
    Private Sub txtvlrtotalfrete_nfe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtvlrtotalfrete_nfe.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal2(txtvlrtotalfrete_nfe, e)
    End Sub

    Private Sub txtvlrtotalfrete_nfe_LostFocus(sender As Object, e As EventArgs) Handles txtvlrtotalfrete_nfe.LostFocus
        If txtvlrtotalfrete_nfe.Text = "" Then
            txtvlrtotalfrete_nfe.Text = valor_campo_vazio()
        Else
            txtvlrtotalfrete_nfe.Text = formata_valor_campo(txtvlrtotalfrete_nfe.Text)
        End If
    End Sub

    Private Sub txtvlrtotalseg_nfe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtvlrtotalseg_nfe.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal2(txtvlrtotalseg_nfe, e)
    End Sub

    Private Sub txtvlrtotalseg_nfe_LostFocus(sender As Object, e As EventArgs) Handles txtvlrtotalseg_nfe.LostFocus
        If txtvlrtotalseg_nfe.Text = "" Then
            txtvlrtotalseg_nfe.Text = valor_campo_vazio()
        Else
            txtvlrtotalseg_nfe.Text = formata_valor_campo(txtvlrtotalseg_nfe.Text)
        End If
    End Sub

    Private Sub txtvlrtotaloutras_nfe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtvlrtotaloutras_nfe.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal2(txtvlrtotaloutras_nfe, e)
    End Sub

    Private Sub txtvlrtotaloutras_nfe_LostFocus(sender As Object, e As EventArgs) Handles txtvlrtotaloutras_nfe.LostFocus
        If txtvlrtotaloutras_nfe.Text = "" Then
            txtvlrtotaloutras_nfe.Text = valor_campo_vazio()
        Else
            txtvlrtotaloutras_nfe.Text = formata_valor_campo(txtvlrtotaloutras_nfe.Text)
        End If
    End Sub

    Private Sub txtvlrtotaldesc_nfe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtvlrtotaldesc_nfe.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal2(txtvlrtotaldesc_nfe, e)
    End Sub

    Private Sub txtvlrtotaldesc_nfe_LostFocus(sender As Object, e As EventArgs) Handles txtvlrtotaldesc_nfe.LostFocus
        If txtvlrtotaldesc_nfe.Text = "" Then
            txtvlrtotaldesc_nfe.Text = valor_campo_vazio()
        Else
            txtvlrtotaldesc_nfe.Text = formata_valor_campo(txtvlrtotaldesc_nfe.Text)
        End If
    End Sub


    Private Sub txtvalor_dup_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtvalor_dup.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal2(txtvalor_dup, e)
    End Sub

    Private Sub txtvalor_dup_LostFocus(sender As Object, e As EventArgs) Handles txtvalor_dup.LostFocus
        If txtvalor_dup.Text = "" Then
            txtvalor_dup.Text = valor_campo_vazio()
        Else
            txtvalor_dup.Text = formata_valor_campo(txtvalor_dup.Text)
        End If
    End Sub

    Private Sub txtvlrtotalbaseicms_nfe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtvlrtotalbaseicms_nfe.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal2(txtvlrtotalbaseicms_nfe, e)
    End Sub

    Private Sub txtvlrtotalbaseicms_nfe_LostFocus(sender As Object, e As EventArgs) Handles txtvlrtotalbaseicms_nfe.LostFocus
        If txtvlrtotaloutras_nfe.Text = "" Then
            txtvlrtotalbaseicms_nfe.Text = valor_campo_vazio()
        Else
            txtvlrtotalbaseicms_nfe.Text = formata_valor_campo(txtvlrtotalbaseicms_nfe.Text)
        End If
    End Sub

    Private Sub txtvlrtotalicms_nfe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtvlrtotalicms_nfe.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal2(txtvlrtotalicms_nfe, e)
    End Sub

    Private Sub txtvlrtotalicms_nfe_LostFocus(sender As Object, e As EventArgs) Handles txtvlrtotalicms_nfe.LostFocus
        If txtvlrtotalicms_nfe.Text = "" Then
            txtvlrtotalicms_nfe.Text = valor_campo_vazio()
        Else
            txtvlrtotalicms_nfe.Text = formata_valor_campo(txtvlrtotalicms_nfe.Text)
        End If
    End Sub

    Private Sub txtbasest_item_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbasest_item.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal2(txtbasest_item, e)
    End Sub

    Private Sub txtbasest_item_LostFocus(sender As Object, e As EventArgs) Handles txtbasest_item.LostFocus
        If txtbasest_item.Text = "" Then
            txtbasest_item.Text = valor_campo_vazio()
        Else
            txtbasest_item.Text = formata_valor_campo(txtbasest_item.Text)
        End If

        If cbofinNFe.Text = "2-NFe complementar" Then
            If txtvlrtotal_cdesc_item.Text = valor_campo_vazio() Then
                txtvlrst_item.Text = ((CDec(txtbasest_item.Text) * CDec(cboaliqst_item.Text)) / 100) - CDec(txtvlricms_item.Text)
                txtvlrst_item.Text = formata_valor_campo(txtvlrst_item.Text)
                txtmva_item.Text = valor_campo_vazio()
            End If
        End If
    End Sub

    Private Sub txtbaseicms_item_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbaseicms_item.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal2(txtbaseicms_item, e)
    End Sub

    Private Sub txtbaseicms_item_LostFocus(sender As Object, e As EventArgs) Handles txtbaseicms_item.LostFocus
        If txtbaseicms_item.Text = "" Then
            txtbaseicms_item.Text = valor_campo_vazio()
        Else
            txtbaseicms_item.Text = formata_valor_campo(txtbaseicms_item.Text)
        End If

        If cbofinNFe.Text = "2-NFe complementar" Then
            If txtvlrtotal_cdesc_item.Text = valor_campo_vazio() Then
                cboaliqicms_item.Text = formata_valor_campo(cboaliqicms_item.Text)
                txtvlricms_item.Text = CDec(txtbaseicms_item.Text) * (CDec(cboaliqicms_item.Text) / 100)
                txtvlricms_item.Text = formata_valor_campo(txtvlricms_item.Text)
            End If
        End If
    End Sub

    Private Sub txtvlrst_item_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtvlrst_item.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal2(txtvlrst_item, e)
    End Sub

    Private Sub txtvlrst_item_LostFocus(sender As Object, e As EventArgs) Handles txtvlrst_item.LostFocus
        If txtvlrst_item.Text = "" Then
            txtvlrst_item.Text = valor_campo_vazio()
        Else
            txtvlrst_item.Text = formata_valor_campo(txtvlrst_item.Text)
        End If
    End Sub

    Private Sub txtvlricms_item_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtvlricms_item.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal2(txtvlricms_item, e)
    End Sub

    Private Sub txtvlricms_item_LostFocus(sender As Object, e As EventArgs) Handles txtvlricms_item.LostFocus
        If txtvlricms_item.Text = "" Then
            txtvlricms_item.Text = valor_campo_vazio()
        Else
            txtvlricms_item.Text = formata_valor_campo(txtvlricms_item.Text)
        End If
    End Sub

    Private Sub txtvlrfrete_item_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtvlrfrete_item.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal2(txtvlrfrete_item, e)
    End Sub

    Private Sub txtvlrfrete_item_LostFocus(sender As Object, e As EventArgs) Handles txtvlrfrete_item.LostFocus
        If txtvlrfrete_item.Text = "" Then
            txtvlrfrete_item.Text = valor_campo_vazio()
        Else
            txtvlrfrete_item.Text = formata_valor_campo(txtvlrfrete_item.Text)
        End If
    End Sub

    Private Sub txtvlroutros_item_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtvlroutros_item.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal2(txtvlroutros_item, e)
    End Sub

    Private Sub txtvlroutros_item_LostFocus(sender As Object, e As EventArgs) Handles txtvlroutros_item.LostFocus
        If txtvlroutros_item.Text = "" Then
            txtvlroutros_item.Text = valor_campo_vazio()
        Else
            txtvlroutros_item.Text = formata_valor_campo(txtvlroutros_item.Text)
        End If
    End Sub

    Private Sub txtvlrdesc_item_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtvlrdesc_item.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal2(txtvlrdesc_item, e)
    End Sub

    Private Sub txtvlrdesc_item_LostFocus(sender As Object, e As EventArgs) Handles txtvlrdesc_item.LostFocus

        If txtvlrdesc_item.Text = "" Then
            txtvlrdesc_item.Text = valor_campo_vazio()
        Else

            If txtvlrdesc_item.Text <> valor_campo_vazio() Then
                txtvlrdesc_item.Text = formata_valor_campo(txtvlrdesc_item.Text)

                txtpercdesc_item.Text = (CDec(txtvlrdesc_item.Text) * 100) / CDec(txtvlrtotal_item.Text)
                txtpercdesc_item.Text = formata_valor_campo(txtpercdesc_item.Text)

                calcular_valor_itens()
            End If

        End If



        If CDec(txtvlrdesc_item.Text) > CDec(txtvlrtotal_item.Text) Then
            MsgBox("O Valor do Desconto não pode Ser maior que o Valor Total dos Produto !", MsgBoxStyle.Exclamation, "Aviso !")
            txtvlrdesc_item.Focus()
            Exit Sub
        End If

        If txtvlrdesc_item.Text <> valor_campo_vazio() Then
            If txtvlrtotal_cdesc_item.Text = valor_campo_vazio() Then
                MsgBox("O Valor do Desconto não pode Ser igual ao  Valor Total dos Produto !", MsgBoxStyle.Exclamation, "Aviso !")
                txtvlrdesc_item.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtvlrunit_item_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtvlrunit_item.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal4(txtvlrunit_item, e)
    End Sub

    Private Sub txtvlrunit_item_LostFocus(sender As Object, e As EventArgs) Handles txtvlrunit_item.LostFocus
        If txtvlrunit_item.Text = "" Then
            txtvlrunit_item.Text = valor_campo_vazio()
        Else
            txtvlrunit_item.Text = Format(CDec(txtvlrunit_item.Text), "#,##0.00")
        End If

        If txtqtdecx_item.Text = "" Then
            txtqtdecx_item.Text = "1"
        End If

        ' Try
        calcular_valor_itens()
        '  Catch ex As Exception
        'MsgBox(ex.Message)
        '  End Try


        If txtprotocolo.Text = "" Then

            If txtcodfor_item.Text <> "" Then

                If txtvlrunit_item.Text <> txtvrlvd_cad.Text Then

                    ' If MessageBox.Show("O preço de venda Informado na NF-e R$ " & txtvlrunit_item.Text & vbCrLf & ", é diferente do Cadastrado no Sistema R$ " & txtvrlvd_cad.Text & vbCrLf & "Deseja ajustar o Preço Informado ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    'txtvlrunit_item.Focus()
                    '  End If

                End If
            End If

        End If
    End Sub

    Private Sub txtbaseredicms_item_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbaseredicms_item.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal2(txtbaseredicms_item, e)
    End Sub

    Private Sub txtbaseredicms_item_LostFocus(sender As Object, e As EventArgs) Handles txtbaseredicms_item.LostFocus

        If txtbaseredicms_item.Text = "" Then
            txtbaseredicms_item.Text = valor_campo_vazio()
        Else
            txtbaseredicms_item.Text = formata_valor_campo(txtbaseredicms_item.Text)
        End If
        ''''''''''''''''''''''''''''Regra de validação obrigatorio''''''''''''
        If txtcst_item.Text.Length = 3 Then
            If txtcst_item.Text.Substring(1, 2) = "70" Then

                If txtbaseredicms_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe o valor da Redução da Base do ICMS (Obrigatorio)", MsgBoxStyle.Exclamation, "Aviso !")
                    txtbaseredicms_item.Focus()
                End If

            End If
        End If
        ''''''''''''''''''''''''''''''''''''''''''''####################''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If txtvlrtotal_cdesc_item.Text <> valor_campo_vazio() Then
            calcular_valor_itens()
        End If

        If txtbaseicms_item.Text <> valor_campo_vazio() Then
            txtbaseicms_item.Text = CDec(txtbaseicms_item.Text) - (CDec(txtbaseicms_item.Text) * (CDec(txtbaseredicms_item.Text) / 100))
            txtbaseicms_item.Text = formata_valor_campo(txtbaseicms_item.Text)
        End If
    End Sub

    Private Sub txtmva_item_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmva_item.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal2(txtmva_item, e)
    End Sub

    Private Sub txtmva_item_LostFocus(sender As Object, e As EventArgs) Handles txtmva_item.LostFocus
        If txtmva_item.Text = "" Then
            txtmva_item.Text = valor_campo_vazio()
        Else
            txtmva_item.Text = formata_valor_campo(txtmva_item.Text)
        End If

        If txtvlrtotal_cdesc_item.Text <> valor_campo_vazio() Then
            calcular_valor_itens()
        End If

    End Sub

    Private Sub txtqtde_item_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtqtde_item.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtqtde_item_LostFocus(sender As Object, e As EventArgs) Handles txtqtde_item.LostFocus

        Dim sep As String = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator

        If txtqtdecx_item.Text = "" Then
            txtqtdecx_item.Text = "1"
        End If

        If txtcodfor_item.Text <> "" Then
            If txtqtde_item.Text = "" Then
                txtqtde_item.Text = "1,000"
            End If
        Else
            txtqtde_item.Text = "0"
        End If

        If sep = "," Then
            txtqtde_item.Text = Format(CDec(txtqtde_item.Text.Replace(".", ",")), "#####0.000")
        Else
            txtqtde_item.Text = Format(CDec(txtqtde_item.Text.Replace(",", ".")), "#####0.000")
        End If

        calcular_valor_itens()


        '''''''''''''''''''''''''''''''''''Rotina abaixa para calcular valores aproximado tributo''''''''''''''''''''''''''''''''

        If chktrib.Checked = True Then

            If dgvibpt.RowCount <> "0" Then

                Dim result As String
                If txtncmex_item.Text <> "" Then
                    result = pes_Gridibpt(txtncm_item.Text & txtncmex_item.Text.Substring(txtncmex_item.Text.Length - 2, 2))
                Else
                    result = pes_Gridibpt(txtncm_item.Text)
                End If

                dgvibpt.CurrentCell = dgvibpt.Rows(result).Cells(0)
                dgvibpt.CurrentCell = dgvibpt.Rows(result).Cells(0)

                txtvlrtrib_item.Text = (CDec(txtvlrtotal_item.Text) * ((CDec(dgvibpt.CurrentRow.Cells(4).Value) + CDec(dgvibpt.CurrentRow.Cells(6).Value)) / 100)) / 100
                txtvlrtrib_item.Text = formata_valor_campo(txtvlrtrib_item.Text)

            End If


        End If


        If txtcodfor_item.Text = "" Then
            txtcodfor_item.Focus()
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
        If txttpNF.Text = "0" Or txttpNF.Text = "3" Then
            txttpNF.Text = "0-NFe de Entrada"
            tiponota = "0"

        End If
        If txttpNF.Text = "1" Then
            txttpNF.Text = "1-NFe de Saída"
            tiponota = "1"
           
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
                consulta_prod()

            End If
        End If
    End Sub

    Private Sub txtcodbarra_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodbarra_item.LostFocus
        txtcodbarra_item.BackColor = Color.LemonChiffon
        'txtcodbarra.BorderStyle = BorderStyle.FixedSingle
    End Sub


    Private Sub mskchave_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskchave.DoubleClick

        If nfecer = "" Then
            MsgBox("Não existe certificado Digital Selecionado !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If
        If mskchave.Text = "" Then
            MsgBox("Informe a Chave de acesso da NF-e", MsgBoxStyle.Exclamation, "Aviso !")
            mskchave.Focus()
            Exit Sub
        End If



        lbltimer.Text = "0"
        tconsultanfe.Enabled = True
    End Sub

    Private Sub mskchave_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskchave.GotFocus
        mskchave.Mask = "00000000000000000000000000000000000000000000"
    End Sub

    Private Sub mskchave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskchave.LostFocus
        If mskchave.Text <> "" Then
            mskchave.Mask = "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000"
        End If
    End Sub

    Private Sub frmxml_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub


    Private Sub frmxml_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If

        Select Case e.KeyCode

            Case Keys.F3
                novo()

            Case Keys.F10
                salvar()

            Case Keys.F4
                excluir()

            Case Keys.F6



                If TabControl_nfe.TabPages(0).Focus = True Then
                    '  FrmConsultaDestinatario.Text = "Consulta Destinatário NF-e"
                    '  FrmConsultaDestinatario.ShowDialog()
                    PainelNaturezaOp.Enabled = True
                End If

                If TabControl_nfe.TabPages(1).Focus = True Then
                    FrmConsultaProduto.Text = "Pesquisar Produtos"
                    FrmConsultaProduto.ShowDialog()
                End If

               

            Case Keys.F7
                ' cancelar()

            Case Keys.F8
                imprimirDanfe()

            Case Keys.F2
                If chkambiente.Checked = False Then
                    MsgBox("Ambiente Homologação Ativo sem validade Fiscal!", MsgBoxStyle.Information, "Aviso !")
                End If
                ' frmlotesnfe.ShowDialog()
            Case Keys.Escape
                Me.Dispose()
        End Select
    End Sub


    Private Sub frmxml_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pitens.Enabled = False
        bntgravanfe.Enabled = False

        bntimprimir.Enabled = False
        desativa_tab()


        TabControl_nfe.Controls.Remove(parametro_nfe_tab)

        TabControl_nfe.Controls.Remove(aba_Cobertura_ECF)

        Me.Text = versao
        cbosefaz.Text = "Selecione"



        '''''''''''''''''''''''''''''''''''''''Rotina abaixo para carregar os parametro que estao no mudolo parametros'''''''''''''''''''''''''''''''''
        '  parametro_nfe.carregar_parametro_nfe()


        '''''''''''''''''''''''''''''''''''''''''''''''''#################''''''''''''''''''''''''''''''''''
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


    Private Sub mskchave_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mskchave.MouseMove
        Label125.Visible = True
    End Sub

    Private Sub Panel11_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel11.MouseMove
        Label125.Visible = False
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
        txtdesc_item.Text = txtdesc_item.Text.ToUpper
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
        If txtuffor.Text <> "MG" Then
            MsgBox("Nota Fiscal de outro estado, O calculo pode ser feito errado !", MsgBoxStyle.Exclamation, "Aviso !")
        End If
        frmcalcpreco.ShowDialog()
    End Sub


    Private Sub CapturarDadosNFePortalNacionalToolStripMenuItem_Click(sender As Object, e As EventArgs)
        limpa_nfe()
        limpar_abas()
        limpar_itens()
        limpardup()
        dgvgrid_xml.Rows.Clear()
        frmlernfe.ShowDialog()
    End Sub

    Private Sub CapturarDadosNFeSEFAZMGToolStripMenuItem_Click(sender As Object, e As EventArgs)
        limpa_nfe()
        limpar_abas()
        limpar_itens()
        limpardup()
        dgvgrid_xml.Rows.Clear()
        '   frmlernfemg.Show()
    End Sub

    Private Sub ViaWebserviceToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        ' frmdownload_webservice.Show()
    End Sub

    Private Sub PortalNacionaNFeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frmdownloadnfe.Show()
    End Sub

    Private Sub ConsultaDFeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        '  frmdfemanifesto.Show()
    End Sub


    Private Sub Label77_Click(sender As Object, e As EventArgs) Handles Label77.Click
        frmpesquisarnfe.ShowDialog()
    End Sub

    Private Sub tcad_Tick(sender As Object, e As EventArgs) Handles tcad.Tick
        lbltimer.Text = lbltimer.Text + 1


        If lbltimer.Text = "2" Then
            'cha a rotina para consulta nfe no sefaz mg
            Dim WebS As New C_WebService
            Dim dadoscad As New C_WebService.Retcad
            dadoscad = WebS.CadConsultaCadastro2(removeFormatacao(mskcnpjfor.Text), txtuffor.Text)

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

        If txtuffor.Text <> "MG" Then
            MsgBox("Esta operação só é Permitida para Forneccedores de Minas Gerais", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If


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

        Dim dados As XmlDocument = New XmlDocument

        dados.Load(txtcaminhoxml.Text)

        danfe(dados.OuterXml)

        frmenvia_email.ShowDialog()
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
            verificar_ean()
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


    Private Sub bntok_Click(sender As Object, e As EventArgs) Handles bntok.Click
        If lblnfe.Visible = True Then
            MsgBox("Esta Nota Ja Foi transmitida, só é permitido visualização !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If
        If txtcodfor_item.Text = "" Then
            Exit Sub
        End If

        If txtcfop_item.Text.Length < 4 Then

            MsgBox("CFOP invalido !", MsgBoxStyle.Exclamation, "Aviso !")
            txtcfop_item.Focus()
            Exit Sub

        End If

        ''''''''''''''''''Monta unidade de medida

        If txtun_item.Text.Length > 2 Then
            txtun_item.Text = txtun_item.Text.Substring(0, 2)
        End If
        If txtun_item.Text <> "KG" Then
            txtun_item.Text = txtun_item.Text & txtqtdecx_item.Text
        End If


        If regimetrib = "1" Then
            If txtcst_item.Text.Length <> 4 Then
                MsgBox("CSOSN: " & txtcst_item.Text & " Informada esta incorreta para o regime tributario cadastrado: " & txtregime.Text, MsgBoxStyle.Exclamation, "Aviso !")
                txtcst_item.Focus()
                Exit Sub
            End If
        End If

        If regimetrib = "3" Or regimetrib = "2" Then
            If txtcst_item.Text.Length <> 3 Then
                MsgBox("A CST: " & txtcst_item.Text & " Informada esta incorreta para o regime tributario cadastrado: " & txtregime.Text, MsgBoxStyle.Exclamation, "Aviso !")
                txtcst_item.Focus()
                Exit Sub
            End If
        End If


        If validaGTIN(txtcodbarra_item.Text) = False Then
            txtcodbarra_item.Text = "SEM GTIN"
        End If

        If txtcst_item.Text.Length = 3 Then
            If txtcst_item.Text.Substring(1, 2) = "70" Then

                If txtbaseredicms_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe o valor da Redução da Base do ICMS (Obrigatorio)", MsgBoxStyle.Exclamation, "Aviso 2 !")
                    txtbaseredicms_item.Focus()
                    Exit Sub
                End If

                '   If txtbaseredicmsst_item.Text = valor_campo_vazio() Then
                'MsgBox("Informe o valor da Redução da Base do ICMS/ST (Obrigatorio)", MsgBoxStyle.Exclamation, "Aviso !")
                '   Exit Sub
                '   End If

            End If
        End If




        If cbofinNFe.Text <> "2-NFe complementar" Then

            ''''''''''''''''''''''Rotinas de validacao de campos vazios''''''''''
            If txtqtde_item.Text = "0.000" Or txtqtde_item.Text = "0,000" Then
                MsgBox("Informe a Quantidade do Produto (Obrigatorio)", MsgBoxStyle.Exclamation, "Aviso !")
                txtqtde_item.Focus()
                Exit Sub
            End If

            If txtvlrunit_item.Text = valor_campo_vazio() Then
                MsgBox("Informe o valor unitario do Produto (Obrigatorio)", MsgBoxStyle.Exclamation, "Aviso !")
                txtvlrunit_item.Focus()
                Exit Sub
            End If

            '''''''''''''''''''##########################'''''''''''''''''''''

        End If

        ''''''''''''''''''''''''''Rotina abaixo para calcular o valor dos itens e valida os campos

        If cbofinNFe.Text = "1-NFe normal" Or cbofinNFe.Text = "4-Devolução/Retorno" Then

            If txtcstipi_item.Text = "01" Or txtcstipi_item.Text = "02" Or txtcstipi_item.Text = "50" Then
                If txtaliqIPI_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe aliquora do IPI (Obrigatorio)", MsgBoxStyle.Exclamation, "Aviso !")
                    txtaliqIPI_item.ReadOnly = True
                    txtaliqIPI_item.Focus()
                    Exit Sub
                End If

                If txtvlripi_item.Text = valor_campo_vazio() Then
                    MsgBox("Informe aliquora do valor IPI (Obrigatorio)", MsgBoxStyle.Exclamation, "Aviso !")
                    txtvlripi_item.ReadOnly = True
                    txtvlripi_item.Focus()
                    Exit Sub
                End If
            End If
            ''''''''''''''''''''''''''Rotina abaixo para calcular o valor dos itens
            calcular_valor_itens()



            ''''''''''''''''''''''''''Rotina calcular partilha icms'''''''''''''''''
            If txtidDest.Text.Substring(0, 1) = "2" Then

                If cboindFinal.Text.Substring(0, 1) = "1" Then

                    If txtindIEDest.Text.Substring(0, 1) = "9" Then

                        calcula_icms_partilha()

                    End If

                End If
            End If


            '''''''''''''''''Rotina para validar icms_st
            erro_validacao = False

            If chk_valida_icms.Checked = True Then

                regua_validacao_icms()

                If erro_validacao = True Then
                    Exit Sub
                End If
            End If

            '''''''''''''''''''Rotina de validacao de cfop'''''''''''''''''''''''''''

            If chk_valida_cfop.Checked = True Then

                validar_item_cfop()

                If erro_validacao = True Then
                    txtcfop_item.Focus()
                    Exit Sub
                End If


            End If


            '''''''''''''''''''''''''''''###################''''''''''''''''''''''

        End If


        If txtlote_item.Text <> "" Then
            If mskdvenc_item.Text = "  /  /" Then
                MsgBox("Você preencheu o campo Lote, por favor Informe a data de vencimento do Produto ou exclua o lote !", MsgBoxStyle.Exclamation, "Aviso valida Lote")
                mskdvenc_item.Focus()
                Exit Sub
            End If
            If txtpmc_item.Text = valor_campo_vazio() Then
                MsgBox("Você preencheu o campo Lote, por favor Informe o PMC do Produto ou exclua o lote !", MsgBoxStyle.Exclamation, "Aviso valida Lote")
                txtpmc_item.Focus()
                Exit Sub
            End If
        End If

        If empresa.scod_trib = 3 Then

            If txtcst_item.Text.Substring(1, 2) = "10" Or txtcst_item.Text.Substring(1, 2) = "70" Or txtcst_item.Text.Substring(1, 2) = "90" Or txtcst_item.Text.Substring(1, 2) = "60" Then
                If txtcest_item.Text = "" Then
                    MsgBox("Informe o Código CEST do Produto ?", MsgBoxStyle.Exclamation, "Aviso !")
                    txtcest_item.Focus()
                    Exit Sub
                End If
            End If


        Else


            If txtcst_item.Text.Substring(1, 3) = "201" Or txtcst_item.Text.Substring(1, 3) = "202" Then

                If txtcst_item.Text = "" Then
                    MsgBox("Informe o Código CEST do Produto ?", MsgBoxStyle.Exclamation, "Aviso !")
                    txtcst_item.Focus()
                    Exit Sub
                End If

            End If

        End If


        If txtcstpis_item.Text = "00" Or txtcstpis_item.Text = "50" Then
            If txtaliqpis_item.Text = "0,00" Then
                MsgBox("Informe a aliquota de PIS ?", MsgBoxStyle.Exclamation, "Aviso !")
                txtaliqpis_item.ReadOnly = False
                txtaliqcofins_item.ReadOnly = False
                txtaliqpis_item.Focus()
                Exit Sub
            End If

            If txtaliqcofins_item.Text = "0,00" Then
                MsgBox("Informe a aliquota de COFINS ?", MsgBoxStyle.Exclamation, "Aviso !")
                txtaliqpis_item.ReadOnly = False
                txtaliqcofins_item.ReadOnly = False
                txtaliqcofins_item.Focus()
                Exit Sub
            End If
        End If

        ''''''''''''''Rotina Principal para carregaar os itens'''''''''''''''''

        calcular_valor_totais_nfe()


        adiciona_iten_grid()


        limpar_itens()


        txtcodfor_item.Focus()
        bntalterar_item.Enabled = False
        bntexcluir_item.Enabled = False

    End Sub


    Private Sub bntalterar_item_Click(sender As Object, e As EventArgs) Handles bntalterar_item.Click
        If dgvgrid_xml.RowCount = "0" Then
            Exit Sub
        End If

        If lblnfe.Visible = True Then
            Exit Sub
        End If
        ' Rotina para alterar primeiro exclui e depois salva os intes arterados

        If txtdesc_item.Text <> "" Then
            limpar_itens()
        End If

        If MessageBox.Show("Deseja Realmente Alterar o Item: " & dgvgrid_xml.CurrentRow.Cells("descricao").Value, "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            itenscod()
            Subtrair_valor_totais_nfe()
            dgvgrid_xml.Rows.Remove(dgvgrid_xml.CurrentRow)

            ordem_itens()

            carrega_cfop_item()

            If txtvlrdesc_item.Text <> valor_campo_vazio() Then
                txtpercdesc_item.Text = (CDec(txtvlrdesc_item.Text) * 100) / CDec(txtvlrtotal_item.Text)
                txtpercdesc_item.Text = formata_valor_campo(txtpercdesc_item.Text)
            End If

        End If

    End Sub



    Private Sub bntexcluir_item_Click(sender As Object, e As EventArgs) Handles bntexcluir_item.Click

        If dgvgrid_xml.RowCount = "0" Then
            Exit Sub
        End If

        If lblnfe.Visible = True Then
            Exit Sub
        End If

        If MessageBox.Show("Deseja Realmente excluir o Iten: " & dgvgrid_xml.CurrentRow.Cells("descricao").Value, "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Subtrair_valor_totais_nfe()
            dgvgrid_xml.Rows.Remove(dgvgrid_xml.CurrentRow)

            MsgBox("Item excluido com sucesso !", MsgBoxStyle.Information, "Aviso !")
            bntexcluir_item.Enabled = False

            ordem_itens()
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

    Private Sub txtuffor_TextChanged(sender As Object, e As EventArgs) Handles txtuffor.TextChanged
        If txtuffor.Text.Length = "2" Then
            carregar_tabela_ibpt()
        End If
    End Sub



    Private Sub Pic_cfop_Click(sender As Object, e As EventArgs) Handles Pic_cfop.Click
        frmpesquisa_cst.Text = "Tela para alteração de CFOP"
        frmpesquisa_cst.lblcst.Text = "CFOP"
        frmpesquisa_cst.lbldesc.Text = "Descrição do CFOP"

        If optentrada.Checked = True Then
            frmpesquisa_cst.Enabled = True
        Else
            frmpesquisa_cst.Enabled = False
        End If


        frmpesquisa_cst.carrega_grid_filtro_cfop("", 3)
        frmpesquisa_cst.Enabled = True
        frmpesquisa_cst.ShowDialog()
    End Sub

    Private Sub Pic_cst_Click(sender As Object, e As EventArgs) Handles Pic_cst.Click

        If empresa.scod_trib = "1" Then
            frmpesquisa_cst.Text = "Tela para alteração da CSOSN"
            frmpesquisa_cst.lblcst.Text = "CSOSN"
            frmpesquisa_cst.lbldesc.Text = "Descrição do CSOSN"
        Else
            frmpesquisa_cst.Text = "Tela para alteração da CST"
            frmpesquisa_cst.lblcst.Text = "CST"
            frmpesquisa_cst.lbldesc.Text = "Descrição do CST"
        End If

        If optentrada.Checked = True Then
            frmpesquisa_cst.Enabled = True
        Else
            frmpesquisa_cst.Enabled = False
        End If

        frmpesquisa_cst.carrega_grid_filtro_cst("", 3)
        frmpesquisa_cst.Enabled = True
        frmpesquisa_cst.ShowDialog()
    End Sub

    Private Sub Pic_pis_Click(sender As Object, e As EventArgs) Handles Pic_pis.Click
        frmpesquisa_cst.Text = "Tela para alteração de CST PIS"
        frmpesquisa_cst.lblcst.Text = "CST PIS"
        frmpesquisa_cst.lbldesc.Text = "Descrição CST PIS"

       If optentrada.Checked = True Then
            frmpesquisa_cst.entrada = True
        Else
            frmpesquisa_cst.entrada = False
        End If



        frmpesquisa_cst.carrega_grid_filtro_cofins("", 3)
        frmpesquisa_cst.Enabled = True
        frmpesquisa_cst.ShowDialog()
    End Sub

    Private Sub Pic_cofins_Click(sender As Object, e As EventArgs) Handles Pic_cofins.Click
        frmpesquisa_cst.Text = "Tela para alteração de CST COFINS"
        frmpesquisa_cst.lblcst.Text = "CST COFINS"
        frmpesquisa_cst.lbldesc.Text = "Descrição CST COFINS"
        frmpesquisa_cst.tabela = "CST_PIS_CONFIS"

      
        If optentrada.Checked = True Then
            frmpesquisa_cst.entrada = True
        Else
            frmpesquisa_cst.entrada = False
        End If



        frmpesquisa_cst.carrega_grid_filtro_cofins("", 3)
        frmpesquisa_cst.Enabled = True
        frmpesquisa_cst.ShowDialog()

    End Sub

    Private Sub Pic_ipi_Click(sender As Object, e As EventArgs)
        '  frmpesquisa_cst.Text = "Tela para alteração de CST IPI"
        ' frmpesquisa_cst.lblcst.Text = "CST IPI"
        '  frmpesquisa_cst.lbldesc.Text = "Descrição CST IPI"
        ' frmpesquisa_cst.tabela = "CST_IPI"

        If optentrada.Checked = True Then
            '' frmpesquisa_cst.filtro_tiponfe = "0"
            ' frmpesquisa_cst.filtro_tiponfe2 = "4"
        Else
            'frmpesquisa_cst.filtro_tiponfe = ""
            ' frmpesquisa_cst.filtro_tiponfe = ""
        End If


        '  frmpesquisa_cst.carrega_grid()
        ' frmpesquisa_cst.ShowDialog()
    End Sub

    Private Sub cboaliqst_item_LostFocus(sender As Object, e As EventArgs) Handles cboaliqst_item.LostFocus



        If txtvlrtotal_cdesc_item.Text <> valor_campo_vazio() Then
            calcular_valor_itens()
        End If

        If cbofinNFe.Text = "2-NFe complementar" Then
            If txtvlrtotal_cdesc_item.Text = valor_campo_vazio() Then
                cboaliqst_item.Text = formata_valor_campo(cboaliqst_item.Text)
                txtvlrst_item.Text = ((CDec(txtbasest_item.Text) * CDec(cboaliqst_item.Text)) / 100) - CDec(txtvlricms_item.Text)
                txtvlrst_item.Text = formata_valor_campo(txtvlrst_item.Text)
            End If
        End If
    End Sub

    Private Sub cboaliqicms_item_LostFocus(sender As Object, e As EventArgs) Handles cboaliqicms_item.LostFocus

        If txtvlrtotal_cdesc_item.Text <> valor_campo_vazio() Then
            calcular_valor_itens()
        End If

        If cbofinNFe.Text = "2-NFe complementar" Then
            If txtvlrtotal_cdesc_item.Text = valor_campo_vazio() Then
                cboaliqicms_item.Text = formata_valor_campo(cboaliqicms_item.Text)
                txtvlricms_item.Text = CDec(txtbaseicms_item.Text) * (CDec(cboaliqicms_item.Text) / 100)
                txtvlricms_item.Text = formata_valor_campo(txtvlricms_item.Text)
            End If
        End If
    End Sub

    Private Sub Pic_cest_Click(sender As Object, e As EventArgs) Handles Pic_cest.Click
        If txtncm_item.Text = "" Then
            MsgBox("Informe a NCM para consulta a CEST !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If
        frmcest.forme = "nfe"
        frmcest.Show()
    End Sub


    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)

        txttpNF.Text = "0-NFe de Entrada"
        tiponota = "0"

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)

        txttpNF.Text = "1-NFe de Saída"
        tiponota = "1"

    End Sub


    Private Sub cbofinNFe_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbofinNFe.SelectedIndexChanged
        If cbofinNFe.Text = "4-Devolução/Retorno" Then
            Paneldev.Enabled = True
            mskchvdevolucao.Focus()

            lblnfcomp.Text = "Chave da NF-e Devolvida"

        End If

        If cbofinNFe.Text = "2-NFe complementar" Then
            Paneldev.Enabled = True
            mskchvdevolucao.Focus()
            lblnfcomp.Text = "Chave da NF-e complementar (NF-e que será complementada)"

            txtbaseicms_item.ReadOnly = False
            txtmva_item.ReadOnly = True
            txtbasest_item.ReadOnly = False

            txtvlrtotaloutras_nfe.ReadOnly = True
            txtvlrtotalfrete_nfe.ReadOnly = True
            txtvlrtotalseg_nfe.ReadOnly = True
            txtvlrtotaldesc_nfe.ReadOnly = True
            txtvlrtotaloutras_nfe.ReadOnly = False
            txtvlrtotalfrete_nfe.ReadOnly = False
            txtvlrtotalseg_nfe.ReadOnly = False
            txtvlrtotaldesc_nfe.ReadOnly = False
        Else

            txtbaseicms_item.ReadOnly = True
            txtmva_item.ReadOnly = False
            txtbasest_item.ReadOnly = True


        End If

        If cbofinNFe.Text = "3-NFe de ajuste" Then
            pitens.Enabled = False
            txtvlrtotalbaseicms_nfe.ReadOnly = False
            txtvlrtotalicms_nfe.ReadOnly = False
            txtvlrtotalbaseicms_nfe.BackColor = Color.White
            txtvlrtotalicms_nfe.BackColor = Color.White

            Paneldev.Enabled = False
            mskchvdevolucao.Clear()

            txtvlrtotaloutras_nfe.ReadOnly = True
            txtvlrtotalfrete_nfe.ReadOnly = True
            txtvlrtotalseg_nfe.ReadOnly = True
            txtvlrtotaldesc_nfe.ReadOnly = True

            '  TabControl_nfe.SelectTab(Tabitens)
            ' txtvlrtotalicms_nfe.Focus()
        Else
            pitens.Enabled = True
            txtvlrtotalbaseicms_nfe.ReadOnly = True
            txtvlrtotalbaseicms_nfe.BackColor = Color.Khaki
            txtvlrtotalicms_nfe.BackColor = Color.Khaki
            txtvlrtotalicms_nfe.ReadOnly = True
            txtvlrtotaloutras_nfe.ReadOnly = False
            txtvlrtotalfrete_nfe.ReadOnly = False
            txtvlrtotalseg_nfe.ReadOnly = False
            txtvlrtotaldesc_nfe.ReadOnly = False
        End If

        If cbofinNFe.Text = "1-NFe normal" Then
            Paneldev.Enabled = False
            mskchvdevolucao.Clear()
        End If
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        If txtnumero_dup.Text = "" Then
            MsgBox("Informe o Número da Duplicata (Obrigatório)", MsgBoxStyle.Exclamation, "Aviso !")
            txtnumero_dup.Focus()
            Exit Sub
        End If

        If txtvalor_dup.Text = valor_campo_vazio() Or txtvalor_dup.Text = "" Then
            MsgBox("Informe o Valor da Duplicata (Obrigatório)", MsgBoxStyle.Exclamation, "Aviso !")
            txtvalor_dup.Focus()
            Exit Sub
        End If

        Dim parcela As Integer
        parcela = dgvfatura.RowCount

        dgvfatura.Rows.Add(parcela, txtnumero_dup.Text, txtvalor_dup.Text, mskdatavencc_dup.Text)

        txtnumero_dup.Clear()
        txtvalor_dup.Text = valor_campo_vazio()
        mskdatavencc_dup.Text = ""

    End Sub

    Private Sub bntexcluir_Click(sender As Object, e As EventArgs) Handles bntexcluir.Click

        If MessageBox.Show("Deseja Realmente a Duplicada ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            dgvfatura.Rows.Remove(dgvfatura.CurrentRow)
        End If

    End Sub

    Private Sub cboindPag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboindPag.SelectedIndexChanged
        If cboindPag.Text = "14 - Duplicata Mercantil" Then
            GBxfatura.Enabled = True
            txtnumero_dup.Focus()
        Else
            dgvfatura.Rows.Clear()
            GBxfatura.Enabled = False
            txtinfcompl.Focus()
        End If
    End Sub


    Private Sub txtcst_item_TextChanged(sender As Object, e As EventArgs) Handles txtcst_item.TextChanged
        If txtcst_item.Text.Length = 3 Then
            If txtcst_item.Text.Substring(1, 2) = "10" Or txtcst_item.Text.Substring(1, 2) = "30" Or txtcst_item.Text.Substring(1, 2) = "70" Or txtcst_item.Text.Substring(1, 2) = "90" Then
                chkcalc_st.Checked = True
            Else
                chkcalc_st.Checked = False
            End If
        End If


        If txtcst_item.Text.Length = 4 Then
            If txtcst_item.Text.Substring(1, 3) = "201" Or txtcst_item.Text.Substring(1, 2) = "202" Or txtcst_item.Text.Substring(1, 2) = "900" Then
                chkcalc_st.Checked = True
            Else
                chkcalc_st.Checked = False
            End If
        End If
    End Sub

    Private Sub txtvlrst_item_TextChanged(sender As Object, e As EventArgs) Handles txtvlrst_item.TextChanged
        If txtvlrst_item.Text <> "" Then
            If txtvlrst_item.Text.Substring(0, 1) = "-" Then
                txtvlrst_item.Text = valor_campo_vazio()
            End If
        End If
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

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If dgvecf.RowCount = "0" Then
            Exit Sub
        End If

        If MessageBox.Show("Deseja Realmente excluir o item selecionado ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

            dgvecf.Rows.Remove(dgvecf.CurrentRow)

            MsgBox("Item excluido com sucesso !", MsgBoxStyle.Information, "Aviso !")
        End If
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

    Private Sub Pic_nat_Click(sender As Object, e As EventArgs)
        TabControl_nfe.TabPages(1).Enabled = True
        pitens.Enabled = True
        '  frmpesquisa_cst.Text = "Tela para Pesquisa de Natureza Operação"
        '  frmpesquisa_cst.lblcst.Text = "CFOP"
        ' frmpesquisa_cst.lbldesc.Text = "Descrição do CFOP"
        ' frmpesquisa_cst.tabela = "CFOP"

        If optentrada.Checked = True Then
            ' frmpesquisa_cst.filtro_tiponfe = "1"
            ' frmpesquisa_cst.filtro_tiponfe2 = "2"
        Else
            ' frmpesquisa_cst.filtro_tiponfe = ""
            ' frmpesquisa_cst.filtro_tiponfe = ""
        End If


        '  frmpesquisa_cst.carrega_grid()
        ' frmpesquisa_cst.ShowDialog()
    End Sub

    Private Sub bntnovo_Click(sender As Object, e As EventArgs) Handles bntnovo.Click
        novo()
    End Sub

    Private Sub txtadifisco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtadifisco.KeyPress
        If e.KeyChar = Chr(13) Then


            TabControl_nfe.SelectTab(Tabitens)
            txtcodfor_item.Focus()

        End If
    End Sub



    Private Sub bntexcluirnfe_Click(sender As Object, e As EventArgs) Handles bntexcluirnfe.Click
        excluir()

    End Sub


    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

        If lblnfe.Visible = True Then
            Exit Sub
        End If

        FrmConsultaDestinatario.Text = "Consulta Destinatário NF-e"
        FrmConsultaDestinatario.ShowDialog()
        PainelNaturezaOp.Enabled = True
    End Sub

    Private Sub mskcnpjcpf_cli_GotFocus(sender As Object, e As EventArgs) Handles mskcnpjcpf_cli.GotFocus

        mskcnpjcpf_cli.Mask = "00000000000000"

    End Sub

    Private Sub mskcnpjcpf_cli_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskcnpjcpf_cli.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            If lblnfe.Visible = True Then
                Exit Sub
            End If
            pesquisa_destinatario(mskcnpjcpf_cli.Text, empresa.ambiente_nfe)
        End If
    End Sub

    Private Sub mskcnpjcpf_cli_LostFocus(sender As Object, e As EventArgs) Handles mskcnpjcpf_cli.LostFocus
        If mskcnpjcpf_cli.Text.Length = 14 Then
            mskcnpjcpf_cli.Mask = "00.000.000/0000-00"
        Else
            mskcnpjcpf_cli.Mask = "000.000.000-00"
        End If
    End Sub


    Private Sub Pictransporte_Click(sender As Object, e As EventArgs) Handles Pictransporte.Click
        If lblnfe.Visible = True Then
            Exit Sub
        End If

        If cbomodfrete.Text.Substring(0, 1) = "9" Then
            MsgBox("A opção sem frete esta Marcada," & vbCrLf & "Marque outra opção para inserir os dados do Transportador !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If
        FrmConsultaDestinatario.Text = "Consulta Transportadora NF-e"
        FrmConsultaDestinatario.ShowDialog()
    End Sub

    Private Sub cadastra_destxml()

        ' FrmDestinatario.txtrazaosocial.Text = txtnomefor.Text
        '' FrmDestinatario.txtendereco.Text = txtendfor.Text
        ' FrmDestinatario.txtbairro.Text = txtbairrofor.Text
        ' FrmDestinatario.txtnumero.Text = txtnumerofor.Text
        'FrmDestinatario.txtcodMunicipio.Text = txtcmunfor.Text
        ' FrmDestinatario.txtcidade.Text = txtcidadefor.Text
        ' FrmDestinatario.txtuf.Text = txtuffor.Text
        ' FrmDestinatario.txtcodUF.Text = ""
        'FrmDestinatario.txtfone.Text = mskfonefor.Text
        'FrmDestinatario.txtemail.Text = txtemailfor.Text
        'FrmDestinatario.txtie.Text = txtiefor.Text
        ' FrmDestinatario.txtcep.Text = mskcepfor.Text

        If mskcnpjfor.Text.Length = 18 Then
            '  FrmDestinatario.txtcnpj.Mask = "00.000.000/0000-00"
            ' FrmDestinatario.txtcnpj.Text = removeFormatacao(mskcnpjfor.Text)


        Else
            ' FrmDestinatario.txtcnpj.Mask = "000.000.000-00"
            ' FrmDestinatario.txtcnpj.Text = removeFormatacao(mskcnpjfor.Text)

        End If


        '  FrmDestinatario.cboind_dest.SelectedIndex = FrmDestinatario.cboind_dest.FindString(txtindIEDest.Text.Substring(0, 1))

        '   FrmDestinatario.cboind_dest.Text = dr.Item("ind_dest")


        '  FrmDestinatario.txtcodigo.Text = "Novo"
        ' FrmDestinatario.ShowDialog()
    End Sub

    Private Sub btncad_dest_Click(sender As Object, e As EventArgs) Handles btncad_dest.Click
        cadastra_destxml()
    End Sub

    Private Sub AtivacaoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        '   frmativacao.Show()
    End Sub

    Private Sub Picproduto_Click(sender As Object, e As EventArgs) Handles Picproduto.Click
        txtqtde_item.Focus()
        FrmConsultaProduto.Text = "Pesquisar Produtos"
        FrmConsultaProduto.ShowDialog()

    End Sub

    Private Sub txtdesc_item_TextChanged(sender As Object, e As EventArgs) Handles txtdesc_item.TextChanged
        txtvlrunit_item.Focus()
    End Sub

    Private Sub txtcodfor_item_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcodfor_item.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            txtcodbarra_item.Clear()
            consulta_prod()
        End If
    End Sub


    Private Sub PesquisarNFeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ' frmpesquisanfe_emi.ShowDialog()
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click


        If lblnfe.Visible = False Then
            If TabControl_nfe.TabPages(0).Focus = True Then
                FrmConsultaDestinatario.Text = "Consulta Destinatário NF-e"
                FrmConsultaDestinatario.ShowDialog()
                PainelNaturezaOp.Enabled = True
                Exit Sub
            End If

            If TabControl_nfe.TabPages(1).Focus = True Then
                FrmConsultaProduto.Text = "Pesquisar Produtos"
                FrmConsultaProduto.ShowDialog()
                Exit Sub
            End If

        End If

        frmpesquisanfe_emi.ShowDialog()



    End Sub

    Private Sub dgvgrid_xml_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvgrid_xml.MouseClick
        bntalterar_item.Enabled = True
        bntexcluir_item.Enabled = True
    End Sub


    Private Sub cbonat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbonat.SelectedIndexChanged
      
        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "SELECT * FROM natureza_operacao where descricao = '" & cbonat.Text & "'"
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read
                txtcodnat.Text = reader("codigo")

                If txtuffor.Text = txtufdest.Text Then

                    txtcfop_icms.Text = reader("cfop_d1").ToString
                    txtcfop_ST.Text = reader("cfop_d2").ToString

                Else

                    txtcfop_icms.Text = reader("cfop_f1")
                    txtcfop_ST.Text = reader("cfop_f2")


                End If

                chktrib.Checked = reader("Calc_trib")
                txttipo.Text = reader("Tipo_nat")
            End While

        End Using

        If txttipo.Text = "c" Then
            cbofinNFe.Text = "1-NFe normal"
            TabControl_nfe.Controls.Add(aba_Cobertura_ECF)
        Else
            TabControl_nfe.Controls.Remove(aba_Cobertura_ECF)
        End If

        If txttipo.Text = "v" Or txttipo.Text = "b" Or txttipo.Text = "0" Then
            cbofinNFe.Text = "1-NFe normal"
        End If

        If txttipo.Text = "d" Then
            cbofinNFe.Text = "4-Devolução/Retorno"
            btnimport_devolucao.Visible = True
        Else
            btnimport_devolucao.Visible = False
        End If

        If txttipo.Text = "nc" Then
            cbofinNFe.Text = "2-NFe complementar"
        End If

        If txttipo.Text = "a" Then
            cbofinNFe.Text = "3-NFe de ajuste"
        End If
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


    Private Sub btncarta_Click(sender As Object, e As EventArgs) Handles btncarta.Click
        If mskchave.Text = "" Then
            MsgBox("Carregue abaixo a Nota Fiscal para gerar a carta de correção !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        If mskchave.Text.Substring(34, 1) = "6" Then
            MsgBox("Não é possível emitir carta de correção para NF-e emitida em Contigência !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        If txtprotocolo.Text = "" Then
            MsgBox("A Nota fiscal carregada Não foi Transmitida para SEFAZ !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        '''''''''''''''''''''''''Regra de validacao de cnpj certificado''''''''''''''''''''
        If removeFormatacao(mskcnpjfor.Text) <> cnpj_cert Then
            MsgBox("CNPJ do Certificado Digital informado diferente do CNPJ Emitente da NF-e !" + vbCrLf + "Operação cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        frmcarta_correcao.mskchave.Text = mskchave.Text
        frmcarta_correcao.txtxml.Text = Base64Decode(ret_valor_campo("select * from nfe_s where Chave_nfe = '" & mskchave.Text & "'", "xml"))

        If frmcarta_correcao.txtxml.Text = "" Then
            MsgBox("XML da NF-e não carregado !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        frmcarta_correcao.ShowDialog()
    End Sub

    Private Sub btninutilizar_Click(sender As Object, e As EventArgs) Handles btninutilizar.Click
        If cnpj_cert <> empresa.sCNPJ Then
            MsgBox("Certificado Digital seleciona está incorreto, " & vbCrLf & "O CNPJ do Certificado e Diferente da Empresa Logada no SIstema !", MsgBoxStyle.Information, "Aviso !")
            Exit Sub
        End If
        frminutilizar_nfe.ShowDialog()
    End Sub


    Private Sub bntopen_Click(sender As Object, e As EventArgs) Handles bntopen.Click
        Try

            txtcaminhoxml.BackColor = Color.White
            frminfo.Show()
            frminfo.txtinfo.Text = vbCrLf + "Aguarde, Carregando o arquivo XML ..."

            txtdsaida.Format = DateTimePickerFormat.Custom
            txtdsaida.CustomFormat = "dd/MM/yyyy HH:mm:ss"

            dialogo.Filter = "Arquivos (.xml .txt)|*.xml;*.txt"

            If dialogo.ShowDialog() = Windows.Forms.DialogResult.OK Then

                txtcaminhoxml.Text = dialogo.FileName

                If Path.GetExtension(txtcaminhoxml.Text) = ".xml" Or Path.GetExtension(txtcaminhoxml.Text) = ".XML" Then

                    xmldoc.Load(txtcaminhoxml.Text)
                    dgvgrid_xml.Rows.Clear()


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

                    If txtprotocolo.Text = "" Then
                        MsgBox("Nota Fiscal Ainda Não Foi Transmitida Para Sefaz", MsgBoxStyle.Information, "Aviso !")
                        bntgravanfe.Enabled = True
                    Else
                        bntimprimir.Enabled = True
                    End If

                    frminfo.Close()
                    TabControl_nfe.SelectTab(TabPrincipal)
                    '    verificar_ean()

                    '  valida_icms()

                    ativa_tab()



                    ''''''''''Verifica se o cnpj esta cadastrado com detinatario
                    If mskcnpjdest.Text.Length > 11 Then
                        Dim cnpjrr As New ADODB.Recordset
                        conectar_baseNFe()
                        cnpjrr.Open("select * from destinatario where cnpj_dest = '" & mskcnpjfor.Text & "'", conexao.cn_nfe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockPessimistic)
                        If cnpjrr.EOF = True Then
                            btncad_dest.Visible = True
                        Else
                            btncad_dest.Visible = False
                        End If

                        conexao.cn_nfe.Close()

                    End If



                End If

                If Path.GetExtension(txtcaminhoxml.Text) = ".txt" Or Path.GetExtension(txtcaminhoxml.Text) = ".TXT" Then


                    limpar_itens()

                    carregar_txt()

                    frminfo.Close()

                    TabControl_nfe.SelectTab(TabPrincipal)

                    Label78.Text = "Protocolo de Autorização"

                    If nfecer = "" Then
                        MsgBox("Não existe certificado Digital Selecionado !", MsgBoxStyle.Exclamation, "Aviso !")
                        Exit Sub
                    End If

                    If txtprotocolo.Text = "" Then
                        MsgBox("Nota Fiscal Ainda Não Foi Transmitida Para Sefaz", MsgBoxStyle.Information, "Aviso !")
                        bntgravanfe.Enabled = True
                    End If



                End If
            End If

            frminfo.Close()

            '''''''''''''''''''''Evento abaixo executado quando ocorrer um erro'''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            MsgBox(ex.Message + vbCrLf + "Contate o Administrador do Sistema." + vbCrLf + "Operação cancelada !", MsgBoxStyle.Critical, "Aviso !")
            frminfo.Close()
        End Try
    End Sub


    Private Sub inf_adici_prod_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles inf_adici_prod.LinkClicked
        MsgBox(txtinfoadic_item.Text, MsgBoxStyle.Information, "Informação adicional Produto !")
    End Sub

    Private Sub txtpercdesc_item_LostFocus(sender As Object, e As EventArgs) Handles txtpercdesc_item.LostFocus
        If txtpercdesc_item.Text = "" Then
            txtpercdesc_item.Text = valor_campo_vazio()
        End If

        If txtpercdesc_item.Text <> valor_campo_vazio() Then
            txtpercdesc_item.Text = formata_valor_campo(txtpercdesc_item.Text)

            txtvlrdesc_item.Text = (CDec(txtpercdesc_item.Text) * CDec(txtvlrtotal_item.Text)) / 100
            txtvlrdesc_item.Text = formata_valor_campo(txtvlrdesc_item.Text)
            calcular_valor_itens()
        End If

        If CDec(txtpercdesc_item.Text) > 99 Then
            MsgBox("O Valor do Percentual de Desconto não pode Ser maior que (99) Porcento !", MsgBoxStyle.Exclamation, "Aviso !")
            txtpercdesc_item.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub mskdvenc_item_LostFocus(sender As Object, e As EventArgs) Handles mskdvenc_item.LostFocus

        If mskdvenc_item.Text = "  /  /" Then
            Exit Sub
        End If

        If IsDate(mskdvenc_item.Text) = False Then
            MsgBox("A data informada é invalida !!!", MsgBoxStyle.Exclamation, "Aviso valida data !")
            mskdvenc_item.Focus()
        End If
    End Sub

    Private Sub btnimport_devolucao_Click(sender As Object, e As EventArgs) Handles btnimport_devolucao.Click
        txtcaminhoxml.BackColor = Color.White
        frminfo.Show()
        frminfo.txtinfo.Text = vbCrLf + "Aguarde, Carregando o arquivo XML ..."

        dialogo.Filter = "Arquivos (.xml)|*.xml"


        If dialogo.ShowDialog() = Windows.Forms.DialogResult.OK Then

            txtcaminhoxml.Text = dialogo.FileName

            If Path.GetExtension(txtcaminhoxml.Text) = ".xml" Or Path.GetExtension(txtcaminhoxml.Text) = ".XML" Then

                xmldoc.Load(txtcaminhoxml.Text)
                dgvgrid_xml.Rows.Clear()


                '''''''''''''''''''''''Rotina para carregar os dados da NFe abaixo:''''''''''''''''''''''''''''''''''''
                ' LerNFE(txtcaminhoxml.Text)
                chave_devolucao()
                itens_nfe()
                carregar_totalnfe_devolucao()


                frminfo.Close()

            End If

        End If

    End Sub

    Private Sub mskchvdevolucao_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskchvdevolucao.MaskInputRejected

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub chkfundopobreza_CheckedChanged(sender As Object, e As EventArgs) Handles chkfundopobreza.CheckedChanged
        If chkfundopobreza.Checked = True Then
            pitens.Height = 221
            dgvgrid_xml.Height = 224
            dgvgrid_xml.Location = New Point(3, 228)

            txtvBCFCP.Text = txtvlrtotal_cdesc_item.Text
            txtpFCP.Text = "2,00"
        Else

            dgvgrid_xml.Height = 253
            pitens.Height = 193
            dgvgrid_xml.Location = New Point(3, 200)
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frmnat.ShowDialog()
        carrega_natureza(txttpNF.Text.Substring(0, 1))
    End Sub

    Private Sub TabPrincipal_Validated(sender As Object, e As EventArgs) Handles TabPrincipal.Validated
        If cbonat.Text = "" Then
            TabControl_nfe.SelectTab(TabPrincipal)
            cbonat.Focus()
        End If
    End Sub

    Private Sub txtcodfor_item_TextChanged(sender As Object, e As EventArgs) Handles txtcodfor_item.TextChanged

    End Sub

    Private Sub Pic_ipi_Click_1(sender As Object, e As EventArgs) Handles Pic_ipi.Click
        frmpesquisa_cst.Text = "Tela para alteração da IPI"
        frmpesquisa_cst.lblcst.Text = "CST"
        frmpesquisa_cst.lbldesc.Text = "Descrição do IPI"

        If optentrada.Checked = True Then
            frmpesquisa_cst.entrada = True
        Else
            frmpesquisa_cst.entrada = False
        End If


        frmpesquisa_cst.carrega_grid_filtro_ipi("", 3)
        frmpesquisa_cst.Enabled = True
        frmpesquisa_cst.ShowDialog()
    End Sub

    Private Sub mskchave_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskchave.MaskInputRejected

    End Sub

    Private Sub mskchave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskchave.KeyPress

        If (e.KeyChar = Chr(13)) Then
            ret_nfe_banco(mskchave.Text)
        End If
    End Sub

    Private Sub txtaliqpis_item_LostFocus(sender As Object, e As EventArgs) Handles txtaliqpis_item.LostFocus
        If txtaliqpis_item.Text = "" Then
            txtaliqpis_item.Text = valor_campo_vazio()
        Else
            txtaliqpis_item.Text = formata_valor_campo(txtaliqpis_item.Text)
        End If

        If txtaliqpis_item.Text <> valor_campo_vazio() Then
            calcular_valor_itens()
        End If
    End Sub

    Private Sub txtaliqcofins_item_LostFocus(sender As Object, e As EventArgs) Handles txtaliqcofins_item.LostFocus
        If txtaliqcofins_item.Text = "" Then
            txtaliqcofins_item.Text = valor_campo_vazio()
        Else
            txtaliqcofins_item.Text = formata_valor_campo(txtaliqpis_item.Text)
        End If

        If txtaliqcofins_item.Text <> valor_campo_vazio() Then
            calcular_valor_itens()
        End If
    End Sub

    Private Sub envia_nfe(ByVal nchave As String, ByVal xml As String, ByVal ambiente As String)
        Dim WebS As New C_WebService
        Dim retEnviNFe As retEnviNFe
        Dim retConsReciNFe As retConsReciNFe
        pinfo.Visible = True
        pinfo.Refresh()

        Try
            xmldoc.LoadXml(gerar_xmlNFCe_envio(xml, ambiente))
        Catch ex As Exception
            xmldoc.LoadXml(xml)
        End Try

        If nrecibo = "" Then

            Try
                retEnviNFe = WebS.EnviaLote4(xmldoc, nchave, ambiente)


                If Not retEnviNFe.infRec Is Nothing Then
                    If Not retEnviNFe.infRec.nRec Is Nothing Then
                        nrecibo = retEnviNFe.infRec.nRec
                        executa_query("update nfe_s set nrecibo = '" & nrecibo & "', Status_nfe = 'NFe enviada SEFAZ' where Chave_nfe = '" & nchave & "'")
                    End If
                Else

                    xmotivo = retEnviNFe.cStat & "-" & retEnviNFe.xMotivo

                End If
            Catch ex As Exception
                MsgBox("Sem Conexão Com a internet !", MsgBoxStyle.Exclamation, "Aviso !")
            End Try



        End If

        If nrecibo <> "" Then

            txtinfo.Text = "Aguarde, Consultando Recibo NFe na SEFAZ..."
            txtinfo.Refresh()
            pinfo.Refresh()

            ''''''''''Rotina para consultar retorno envia xml para a SEFAZ'''''''''''''''''''''''''''''
            retConsReciNFe = WebS.ConsultaRecLote(nrecibo, ambiente, nchave)

            If retConsReciNFe.cStat = "104" Then


                If retConsReciNFe.protNFe.infProt.cStat = "100" Then
                    Dim dados As XmlDocument = New XmlDocument
                    dados = GerarNotaProcessadanfce(SepararNota_tagnfe(xmldoc.OuterXml), retConsReciNFe.xmlprot)
                    '''''''''''''''''''''''''''Salva info no banco''''''''''''''''''''''''''
                    executa_query("update nfe_s set xmotivo = '" & retConsReciNFe.protNFe.infProt.xMotivo & "', cstat = '" & retConsReciNFe.protNFe.infProt.cStat & "', xml = '" & Base64Encode(dados.OuterXml) & "', nprot = '" & retConsReciNFe.protNFe.infProt.nProt & "',  Status_nfe = 'NFe autorizada'  where Chave_nfe = '" & nchave & "'")

                    cstat = retConsReciNFe.protNFe.infProt.cStat
                    xmotivo = retConsReciNFe.protNFe.infProt.xMotivo
                    nprot = retConsReciNFe.protNFe.infProt.nProt

                    '''''''''''''''''''''Salvar arquivo ma pasta''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim Path As String = Application.StartupPath & "\NFe"
                    If Not Directory.Exists(Path) Then Directory.CreateDirectory(Path)

                    dados.Save(Path & "\NFe-" & retConsReciNFe.protNFe.infProt.chNFe & ".xml")

                    Tretnfe.Dispose()

                    MsgBox("NF-e Autorizada !" & vbCrLf & xmotivo & vbCrLf & "Protocolo Aut.:" & nprot, MsgBoxStyle.Information, "Aviso !")

                    danfe_new(Base64Decode(ret_valor_campo("select * from nfe_s where Chave_nfe = '" & mskchave.Text & "'", "xml")))

                    finaliza_emi()

                Else

                    If retConsReciNFe.protNFe.infProt.cStat = "204" Then

                        Dim nPost As Int32 = retConsReciNFe.protNFe.infProt.xMotivo.IndexOf("nRec:")
                        Dim rec As String = retConsReciNFe.protNFe.infProt.xMotivo.Substring(nPost + 5, retConsReciNFe.protNFe.infProt.xMotivo.Length - nPost - 6).Trim
                        nrecibo = rec

                    End If

                    cstat = retConsReciNFe.protNFe.infProt.cStat
                    xmotivo = retConsReciNFe.protNFe.infProt.xMotivo

                    '''''''''''''''''''''''''''Salva info no banco''''''''''''''''''''''''''

                    executa_query("update nfe_s set nrecibo = '" & nrecibo & "', xmotivo = '" & retConsReciNFe.protNFe.infProt.xMotivo & "', cstat = '" & retConsReciNFe.protNFe.infProt.cStat & "', Status_nfe = '" & retConsReciNFe.protNFe.infProt.xMotivo & "'  where Chave_nfe = '" & nchave & "'")

                    Tretnfe.Dispose()
                    MsgBox(retConsReciNFe.protNFe.infProt.cStat & "-" & retConsReciNFe.protNFe.infProt.xMotivo, MsgBoxStyle.Exclamation, "Aviso !")

                End If

            Else

                cstat = retConsReciNFe.cStat
                xmotivo = retConsReciNFe.xMotivo
                executa_query("update nfe_s set xmotivo = '" & retConsReciNFe.cStat & "', cstat = '" & retConsReciNFe.xMotivo & "'  where Chave_nfe = '" & nchave & "'")

                If retConsReciNFe.cStat <> "105" Then
                    Tretnfe.Dispose()
                    MsgBox(retConsReciNFe.cStat & "-" & retConsReciNFe.xMotivo, MsgBoxStyle.Exclamation, "Aviso !")
                End If

            End If

        End If

        pinfo.Visible = False
    End Sub

    Private Sub Tretnfe_Tick(sender As Object, e As EventArgs) Handles Tretnfe.Tick
        pinfo.Visible = True
        pinfo.Refresh()

        envia_nfe(mskchave.Text, xmldoc.OuterXml, empresa.ambiente_nfe)

        Tretnfe.Dispose()
    End Sub

    Public Sub danfe_new(ByVal xml As String)
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dgvnfce_cobertura.Rows.Add(msknfce.Text)
        msknfce.Clear()
        msknfce.Mask = "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000"
    End Sub

    Private Sub txtaliqpis_item_TextChanged(sender As Object, e As EventArgs) Handles txtaliqpis_item.TextChanged

    End Sub

    Private Sub txtpesob_LostFocus(sender As Object, e As EventArgs) Handles txtpesob.LostFocus
        If txtpesob.Text <> "" Then
            txtpesob.Text = Format(Convert.ToDouble(txtpesob.Text), "###0.00")
        End If
    End Sub

    Private Sub txtpesol_LostFocus(sender As Object, e As EventArgs) Handles txtpesol.LostFocus
        If txtpesol.Text <> "" Then
            txtpesol.Text = Format(Convert.ToDouble(txtpesol.Text), "###0.00")
        End If
    End Sub

    Private Sub txtvBCFCP_LostFocus(sender As Object, e As EventArgs) Handles txtvBCFCP.LostFocus
        If txtvBCFCP.Text <> "" Then
            txtvBCFCP.Text = formata_valor_campo(txtvBCFCP.Text)
        End If
    End Sub

    Private Sub txtpFCP_LostFocus(sender As Object, e As EventArgs) Handles txtpFCP.LostFocus
        If txtpFCP.Text <> "" Then
            txtpFCP.Text = formata_valor_campo(txtpFCP.Text)
        End If
    End Sub

    Private Sub txtvFCP_LostFocus(sender As Object, e As EventArgs) Handles txtvFCP.LostFocus
        If txtvFCP.Text <> "" Then
            txtvFCP.Text = formata_valor_campo(txtvFCP.Text)
        End If
    End Sub

    Private Sub txtpFCPST_LostFocus(sender As Object, e As EventArgs) Handles txtpFCPST.LostFocus
        If txtpFCPST.Text <> "" Then
            txtpFCPST.Text = formata_valor_campo(txtpFCPST.Text)
        End If
    End Sub

    Private Sub txtvFCPST_LostFocus(sender As Object, e As EventArgs) Handles txtvFCPST.LostFocus
        If txtvFCPST.Text <> "" Then
            txtvFCPST.Text = formata_valor_campo(txtvFCPST.Text)
        End If
    End Sub

    Private Sub txtvBCFCPST_LostFocus(sender As Object, e As EventArgs) Handles txtvBCFCPST.LostFocus
        If txtvBCFCPST.Text <> "" Then
            txtvBCFCPST.Text = formata_valor_campo(txtvBCFCPST.Text)
        End If
    End Sub

    Private Sub optentrada_CheckedChanged(sender As Object, e As EventArgs) Handles optentrada.CheckedChanged
        txttpNF.Text = "0"
        carrega_natureza("0")
    End Sub

    Private Sub optsaida_CheckedChanged(sender As Object, e As EventArgs) Handles optsaida.CheckedChanged
        txttpNF.Text = "1"
        carrega_natureza("1")
    End Sub

    Private Sub cboindFinal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboindFinal.SelectedIndexChanged

    End Sub

    Private Sub txtvlrunit_item_TextChanged(sender As Object, e As EventArgs) Handles txtvlrunit_item.TextChanged

    End Sub

    Private Sub mskcnpjcpf_cli_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskcnpjcpf_cli.MaskInputRejected

    End Sub

    Private Sub txtqtde_item_TextChanged(sender As Object, e As EventArgs) Handles txtqtde_item.TextChanged

    End Sub
End Class