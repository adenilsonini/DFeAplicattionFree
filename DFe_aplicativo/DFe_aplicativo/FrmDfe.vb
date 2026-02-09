Imports DFe_aplicativo.C_WebService
Imports System.Threading
Imports System.Data.OleDb
Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.Win32
Imports System.Globalization
Imports Microsoft.Owin.Hosting
Public Class FrmDfe

    Dim webApp3 As IDisposable
    Dim download_site As Boolean, par_down As Boolean, captcha As Boolean
    Dim status_consulta As String, consulta As Boolean
    Dim rs As New ADODB.Recordset
    Dim WebS As New C_WebService
    Dim retorevento As New RetRetorno
    Dim xmldoc As New XmlDocument()
    Dim xmlnsManager As New XmlNamespaceManager(xmldoc.NameTable)
    Public rotina As Thread, rotina2 As Thread, rotina_dfe As Thread
    Dim tipo_processo As String

    Public Structure Retdfe
        Dim cStat As String
        Dim xMotivo As String
        Dim ultNSU As String
        Dim maxNSU As String
        Dim dhResp As Date
    End Structure
    Private Sub Timer_hora_Tick(sender As Object, e As EventArgs) Handles Timer_hora.Tick
        lblhoradfe.Text = Now.ToString("HH:mm:ss")
    End Sub


#Region "''''''Consulta distribuição fiscal eletronica"






    Private Sub Tverifica_dfe_Tick(sender As Object, e As EventArgs) Handles Tverifica_dfe.Tick


        If Not rotina_dfe.IsAlive Then
            If status_consulta = "executado" Then
                '  verificar_continuacaopesq()
            End If
        End If

        If txtdfepara.Text <> "Ativa" Then
            Tverifica_dfe.Dispose()
        End If

    End Sub





    ''' <summary>
    ''' 'Rotina descriptogra o retorno enviado pela receita federal''''''''''''''''''''''''''''''''''''''''''''''''
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub decryptografar_arq1()

        '''''''''''''''''''Limpa o grid anterior''''''''''''''
        dgvdfe.Rows.Clear()

        '''''''''''''''''''''''''''''''
        xmldoc.Load(Application.StartupPath & "\XML\retDistDFeInt.xml")
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode
        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist = xmldoc.SelectNodes("//bk:loteDistDFeInt", xmlnsManager)




        For Each xmlnode In xmllist


            For Each InnerNode2 As XmlNode In xmlnode.ChildNodes



                Dim gz As Compression.GZipStream

                Dim gzBuffer As Byte() = Convert.FromBase64String(InnerNode2.InnerText)


                ''''''''''''''''''''''Nova Rotina Descripar Gzip''''''''''''''''''''

                Using ms As New IO.MemoryStream(gzBuffer)
                    Using gzs As New System.IO.Compression.GZipStream(ms, IO.Compression.CompressionMode.Decompress)
                        Using rdr As New IO.StreamReader(gzs)
                            dgvdfe.Rows.Add(InnerNode2.Attributes.Item(0).Value, InnerNode2.Attributes.Item(1).Value, rdr.ReadToEnd)
                        End Using 'rdr
                    End Using 'gzs
                End Using 'ms
            Next

        Next

        txttotalarqdfe_ultim.Text = CDec(txttotalarqdfe_ultim.Text) + dgvdfe.Rows.Count


    End Sub


    Public Function Separarxmlnfe_corrompido(ByVal vNfeDadosMsg As String) As String
        Try
            Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<NFe")
            Dim nPosF As Int32 = vNfeDadosMsg.IndexOf("</dest")

            Dim vStringNfe As String = vNfeDadosMsg.Substring(nPosI, nPosF - nPosI)

            Return vStringNfe
        Catch ex As Exception
            Return "erro"
        End Try
    End Function



    ''' <summary>
    ''' 'Rotina abaixo gera o XML evento de Manifestação destinatario''''''''''''''''''''''''''''''''''''''''''''''''
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub gerar_evento_Recusa_nfe(ByVal i As String, ByVal codevento As String, desc_event As String, just As String)



        Dim teste As New NFe()
        Dim xml As String, dataevento As String
        Dim xmlevento = New XmlDocument()
        Dim manifestacao As New NFe()



        If horaverao = True Then
            dataevento = Now.ToString("yyyy-MM-ddTHH:mm:ss") + "-02:00"
        Else
            dataevento = Now.ToString("yyyy-MM-ddTHH:mm:ss") + "-03:00"
        End If






        manifestacao.versao = "1.00"
        '''''''''''''codico ciencia operação''''''''''''''''''
        manifestacao.Id = codevento + dgvdferet.Rows.Item(i).Cells("chave_nfe").Value + "01"
        manifestacao.chave = dgvdferet.Rows.Item(i).Cells("chave_nfe").Value
        manifestacao.coduf = "91"
        manifestacao.cnpj = cnpj_cert
        manifestacao.dataenv = dataevento
        manifestacao.codenv = codevento
        manifestacao.descenv = desc_event
        manifestacao.xJust = just
        manifestacao.tpAmb = "1"


        Dim xmldoc As XmlDocument = manifestacao.Gerarmanifestacaodest()

        ' xmldoc.Save(Application.StartupPath & "\XML\manifestacaoNaoAssinado.xml")
        If nfecer = "" Then
            certificado = CertificadoDigital.SelecionarCertificado("")
        Else
            certificado = CertificadoDigital.SelecionarCertificado(nfecer)
        End If


        'assina os xml selecionados
        Dim xmlAssinado As XmlDocument = CertificadoDigital.Assinar(xmldoc, "infEvento", certificado)

        '''''''''''''''''''''''''''''''''''''''''''''''''''' GERA O ARQUIVO XML DA MANIFESTAÇÃO''''''''''''''''''''''''''''''''''
        xmlevento.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><envEvento versao=""1.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><idLote>" & teste.GerarLoteNfe_dfe() & "</idLote>" & xmlAssinado.InnerXml & "</envEvento>")
        xmlevento.Save(Application.StartupPath & "\XML\evento.xml")

        'Valida o XML assinado
        Dim resultado As String = ValidaXML.ValidarXML(xmlevento, Application.StartupPath & "\Esquemas_XML_NF-e\Evento_ManifestaDest\envConfRecebto_v1.00.xsd")

        If resultado.Trim().Length <> 0 Then
            MsgBox(resultado)
            '  dgvdferet.CurrentRow.Cells("  situacao_nfe").Value = resultado
            ' resultado = "Xml gerado com sucesso, nenhum erro encontrado"
            Exit Sub
        End If

        Using xmltw As New XmlTextWriter(Application.StartupPath & "\XML\evento_auto.xml", New UTF8Encoding(False))
            xmlevento.WriteTo(xmltw)
            xmltw.Close()
        End Using



        Dim rotina1 As Thread
        Control.CheckForIllegalCrossThreadCalls = False
        rotina1 = New Thread(AddressOf manifestacao_dest_auto)
        rotina1.Start()


    End Sub




    Private Sub validar_duplicata()



        For i As Integer = 0 To dgvdferet.Rows.Count - 1

            If dgvdferet.Rows.Item(i).Cells("valida_dup").Value = "validar duplicata" Then

                dgvdferet.Rows.Item(i).Cells("valida_dup").Value = "dup_valido"

                Dim cont_total As Integer = 0


                Dim xml_cod As New XmlDocument()

                xml_cod.LoadXml(dgvdferet.Rows.Item(i).Cells("xml_nfe").Value)


                Dim xmllist As System.Xml.XmlNodeList
                Dim xmlnode As System.Xml.XmlNode
                xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
                xmllist = xml_cod.SelectNodes("//bk:NFe", xmlnsManager)

                For Each xmlnode In xmllist

                    If Not xmlnode("infNFe")("cobr") Is Nothing Then

                        If Not xmlnode("infNFe")("cobr")("dup") Is Nothing Then

                            cont_total += 1

                        End If
                    End If

                Next
                '  MsgBox(cont_total)
                If cont_total = 0 Then


                    dgvdferet.Rows.Item(i).Cells("valida_dup").Value = "dup_invalido"


                    ''''''''''colori o grid''''''''''''''''''
                    With Me.dgvdferet.Rows(i).DefaultCellStyle
                        .BackColor = Color.PaleGreen
                        .ForeColor = Color.Blue
                    End With


                End If









            End If
        Next



    End Sub

#End Region


#Region "''''''Consulta distribuição fiscal eletronica New"
    Private Sub Tdfe_status_Tick(sender As Object, e As EventArgs) Handles Tdfe_status.Tick


        If File.Exists(Application.StartupPath & "\XML\retDistDFeInt.xml") = True Then
            txtinfodfe.Text = "Carregando Dados recebidos da RFB, aguarde..."
            txtinfodfe.Refresh()

            Tdfe_status.Dispose()


            pic_info.Visible = True


            ' Control.CheckForIllegalCrossThreadCalls = False
            '  rotina = New Thread(AddressOf decryptografar_arq)
            '  rotina.SetApartmentState(ApartmentState.STA)
            ' rotina.Start()

            ' Tcontinuacao_dfe.Enabled = True

            decryptografar_arq()

        End If
    End Sub

    ''' <summary>
    ''' 'Rotina abaixo ativa a consulta''''''''''''''''''''''''''''''''''''''''''''''''
    ''' </summary>
    ''' <remarks></remarks>

    Private Sub bntpesqDFe_Click(sender As Object, e As EventArgs) Handles bntpesqDFe.Click
        txtultnsudfe.BackColor = Color.Yellow


        If cboambdfe.Text = "" Then
            txtinfodfe.Text = "Informe o tipo de Ambiente a ser consultado na Receita Federal "
            MsgBox("Informe o tipo de Ambiente a ser consultado na Receita Federal", MsgBoxStyle.Exclamation, "Aviso !")
            cboambdfe.Focus()
            Exit Sub
        End If


        tipo_processo = "Dfe"
        File.Delete(Application.StartupPath & "\XML\retDistDFeInt.xml")
        Tdfe_status.Enabled = True
        frmwebservice.ambiente = cboambdfe.Text.Substring(0, 1)
        frmwebservice.tipo_processo = tipo_processo
        frmwebservice.ShowDialog()
        '''''''''''''''''''''''''''Ativa a Rotina de Pesquisa dos Documento na receita'''''''''''''''''''

    End Sub



    ''' <summary>
    ''' 'Rotina descriptogra o retorno enviado pela receita federal''''''''''''''''''''''''''''''''''''''''''''''''
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub decryptografar_arq()

        '''''''''''''''''''Limpa o grid anterior''''''''''''''

        Try


            ret_dfe_xml()

            dgvdfe.Rows.Clear()

            '''''''''''''''''''''''''''''''
            xmldoc.Load(Application.StartupPath & "\XML\retDistDFeInt.xml")
            Dim xmllist As System.Xml.XmlNodeList
            Dim xmlnode As System.Xml.XmlNode
            xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
            xmllist = xmldoc.SelectNodes("//bk:loteDistDFeInt", xmlnsManager)




            For Each xmlnode In xmllist


                For Each InnerNode2 As XmlNode In xmlnode.ChildNodes



                    '  Dim gz As Compression.GZipStream

                    Dim gzBuffer As Byte() = Convert.FromBase64String(InnerNode2.InnerText)


                    ''''''''''''''''''''''Nova Rotina Descripar Gzip''''''''''''''''''''

                    Using ms As New IO.MemoryStream(gzBuffer)
                        Using gzs As New System.IO.Compression.GZipStream(ms, IO.Compression.CompressionMode.Decompress)
                            Using rdr As New IO.StreamReader(gzs)
                                dgvdfe.Rows.Add(InnerNode2.Attributes.Item(0).Value, InnerNode2.Attributes.Item(1).Value, rdr.ReadToEnd)
                            End Using 'rdr
                        End Using 'gzs
                    End Using 'ms
                Next

            Next

            txttotalarqdfe_ultim.Text = CDec(txttotalarqdfe_ultim.Text) + dgvdfe.Rows.Count


            ''''''''''''''''''ROTINA ABAIXO CARREGA OS DADOS DO XML RET'''''

            ret_dfe_dados()



        Catch ex As Exception
            CalcucarHora()

        End Try
    End Sub

    Public Function ret_dfe_xml() As Retdfe
        xmldoc.Load(Application.StartupPath & "\XML\retDistDFeInt.xml")
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode
        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist = xmldoc.SelectNodes("//bk:retDistDFeInt", xmlnsManager)



        Dim Retornos As New Retdfe
        For Each xmlnode In xmllist

            Retornos.cStat = xmlnode("cStat").InnerText
            Retornos.xMotivo = xmlnode("xMotivo").InnerText
            Retornos.dhResp = xmlnode("dhResp").InnerText

            If Not xmlnode("ultNSU") Is Nothing Then
                Retornos.ultNSU = xmlnode("ultNSU").InnerText
            End If
            If Not xmlnode("maxNSU") Is Nothing Then
                Retornos.maxNSU = xmlnode("maxNSU").InnerText
            End If



        Next

        Return Retornos
    End Function


    Private Sub ret_dfe_dados()


        lbltotalnfe.Text = "0"



        '''''''''''''''''''''''''''''''''''''''''''''''''''''##########''''''''''''''''''''''''''''''''''''''
        If ret_dfe_xml.cStat = "137" Or ret_dfe_xml.cStat = "138" Then


            abrir_xml()


            '  dgvdferet.Invoke(CType(AddressOf abrir_xml, MethodInvoker))

            ''''''''''''''''''''''''''''''Rotina abaixo Trata do retorno da Consulta NSU faltante'''''''''''''''''''''''''''
            If tipo_processo = "Dfe_cons" Then

                txtinfodfe.Text = "Consulta por NSU Faltante Realizado em: " & ret_dfe_xml.dhResp & vbCrLf & ret_dfe_xml.xMotivo
                MsgBox("Consulta NSU Realizada, " & ret_dfe_xml.xMotivo & vbCrLf & " Conteudo do Retorno esta no grid abaixo !", MsgBoxStyle.Information, "Atençao !!")
                pic_info.Visible = False
            End If

            ''''''''''''''''''''''''''''''Rotina abaixo Trata do retorno da Consulta Por chave de acesso'''''''''''''''''''''''''''
            If tipo_processo = "Dfe_cons_chave" Then

                txtinfodfe.Text = "Consulta Chave Por Acesso Realizado em: " & ret_dfe_xml.dhResp & vbCrLf & ret_dfe_xml.xMotivo
                MsgBox("Consulta Realizada, " & ret_dfe_xml.xMotivo & vbCrLf & " Conteudo do Retorno esta no grid abaixo !", MsgBoxStyle.Information, "Atençao !!")
                pic_info.Visible = False
            End If


            ''''''''''''''''''''''''''''''Rotina abaixo Trata do retorno da Consulta Tipo DFe'''''''''''''''''''''''''''
            If tipo_processo = "Dfe" Then

                ''''''''''''''''''''''''''''''Rotina abaixo Confere seguencia NSU dos documentos'''''''''''''''''''''''''''

                seguencia_NSU()


                If ret_dfe_xml.ultNSU <> "000000000000000" Then
                    txtultnsudfe.Text = ret_dfe_xml.ultNSU
                End If

                txtmaxNSU.Text = ret_dfe_xml.maxNSU

                txtinfodfe.Text = "Consulta Realizado em: " & ret_dfe_xml.dhResp + vbCrLf + "Não Há mais Documentos na Receita Federal para o CNPJ Informado !"
                bntpesqDFe.Text = "Pesquisar NF-e"

                salva_nsu()

                CalcucarHora()

                continuacao()

            End If

        Else

            txtinfodfe.Text = ret_dfe_xml.cStat & " - " & ret_dfe_xml.xMotivo

        End If



    End Sub


    Private Sub continuacao()

        If txtultnsudfe.Text < txtmaxNSU.Text Then
            pic_info.Visible = False

            txtinfodfe.Text = "Aguarde, Executando Novamente a consulta (DFe) para localizar mais Documentos..."
            txtinfodfe.Refresh()

            File.Delete(Application.StartupPath & "\XML\retDistDFeInt.xml")

            Tdfe_status.Enabled = True

            frmwebservice.ambiente = cboambdfe.Text.Substring(0, 1)
            frmwebservice.tipo_processo = tipo_processo
            frmwebservice.ShowDialog()

        End If

        If txtultnsudfe.Text = txtmaxNSU.Text Then

            pic_info.Visible = False
            '''''''''''''''''''''''Chama manifstacao automatica do destinatario''''''
            If chkmanifes.Checked = True Then

                If dgvdferet.RowCount <> "0" Then

                    Dim ver As Boolean = False
                    For i As Integer = 0 To dgvdferet.Rows.Count - 1

                        If dgvdferet.Rows.Item(i).Cells("tipo_nfe").Value.ToString.Substring(0, 1) = "1" Then
                            If dgvdferet.Rows.Item(i).Cells("situacao_nfe").Value = "Sem manifestacao" Then
                                ver = True
                            End If
                        End If

                    Next

                    If ver = True Then
                        gerar_evento_auto()
                    End If

                End If
            End If

            '''''''''''''''''''''''Chama Valida codigo barra NFe''''''

          

        End If
    End Sub

    '<summary>'''
    '''''''Rotina abaixo abre o XML de Retorno da receita federal''''''''''''''''''''''''''''''''''''''''''''''''
    '</summary>
    ''' <remarks></remarks>
    Private Sub abrir_xml()



        For i As Integer = 0 To dgvdfe.Rows.Count - 1

            ''''''''''''''''''''''''''''''''''''Rotina abaixo trabalha com o Retorno dos eventos da NFe''''''''''''''''''

            If dgvdfe.Rows.Item(i).Cells(1).Value.ToString.Substring(0, 13) = "procEventoNFe" Then

                Try

                    Dim xmlret = New XmlDocument()

                    xmlret.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & dgvdfe.Rows.Item(i).Cells(2).Value & "")
                    xmlret.Save(Application.StartupPath & "\XML\Retprocevento.xml")

                    Dim xmllist As System.Xml.XmlNodeList
                    Dim xmlnode As XmlNode
                    xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
                    xmllist = xmlret.SelectNodes("//bk:procEventoNFe", xmlnsManager)

                    For Each xmlnode In xmllist

                        If xmlnode("evento")("infEvento")("detEvento")("descEvento").InnerText = "CT-e Autorizado" Then
                            dgvevento.Rows.Add(xmlnode("evento")("infEvento")("detEvento")("descEvento").InnerText, xmlnode("evento")("infEvento")("chNFe").InnerText,
                                                   xmlnode("evento")("infEvento")("detEvento")("CTe")("chCTe").InnerText, xmlnode("retEvento")("infEvento")("xMotivo").InnerText)
                        End If



                        ''''''''''''''''''''''''''''''''Rotina abaixo trato o retorno de cancelamento da nfe'''''''''''''''''''''''
                        Try

                            If xmlnode("evento")("infEvento")("detEvento")("descEvento").InnerText = "Cancelamento" Then

                                Dim rssefaz As New ADODB.Recordset
                                conectar_DFe()
                                rssefaz.Open("select * from NFe_consultadaDFe where chave_nfe = '" & xmlnode("evento")("infEvento")("chNFe").InnerText & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

                                If rssefaz.EOF = True Then
                                    rssefaz.AddNew()
                                    rssefaz.Fields("chave_nfe").Value = xmlnode("evento")("infEvento")("chNFe").InnerText
                                End If

                                rssefaz.Fields("status_nfe").Value = "NFe cancelada"
                                rssefaz.Fields("situacao_nfe").Value = "Cancelamento"
                                rssefaz.Fields("protocolo_NFe").Value = xmlnode("retEvento")("infEvento")("nProt").InnerText
                                rssefaz.Fields("data_dados").Value = Now.Date
                                rssefaz.Update()


                                cn_DFe.Close()

                                dgvevento.Rows.Add(xmlnode("evento")("infEvento")("detEvento")("descEvento").InnerText, xmlnode("evento")("infEvento")("chNFe").InnerText,
                                                   "Protocolo de Cancelamento: " & xmlnode("retEvento")("infEvento")("nProt").InnerText, xmlnode("retEvento")("infEvento")("xMotivo").InnerText)
                            End If

                        Catch ex As Exception
                            dgverrodoc.Rows.Add(dgvdfe.Rows.Item(i).Cells(0).Value, dgvdfe.Rows.Item(i).Cells(2).Value)
                        End Try


                        '''''''''''''''''''''''''''''''''''''''''''Trato de manifesto da nfe emitade pela empresa''''''''''''''''''''''''''''
                        If xmlnode("evento")("infEvento")("detEvento")("descEvento").InnerText = "Ciencia da Operacao" Or xmlnode("evento")("infEvento")("detEvento")("descEvento").InnerText = "Confirmacao da Operacao" _
                               Or xmlnode("evento")("infEvento")("detEvento")("descEvento").InnerText = "Desconhecimento da Operacao" Or xmlnode("evento")("infEvento")("detEvento")("descEvento").InnerText = "Operacao nao Realizada" Then

                            dgvevento.Rows.Add(xmlnode("evento")("infEvento")("detEvento")("descEvento").InnerText, xmlnode("evento")("infEvento")("chNFe").InnerText,
                                                "Protocolo de Registro Evento: " & xmlnode("retEvento")("infEvento")("nProt").InnerText, xmlnode("retEvento")("infEvento")("xMotivo").InnerText)

                        End If



                    Next


                Catch ex As Exception
                    dgverrodoc.Rows.Add(dgvdfe.Rows.Item(i).Cells(0).Value, dgvdfe.Rows.Item(i).Cells(2).Value)
                End Try

            End If





            ''''''''''''''''''''''''''''''''''''Rotina abaixo pega o resumo da NF-e''''''''''''''''''

            If dgvdfe.Rows.Item(i).Cells(1).Value.ToString.Substring(0, 6) = "resNFe" Then

                lbltotalnfe.Text = CDec(lbltotalnfe.Text) + 1

                Try

                    Dim xmlret = New XmlDocument()
                    xmlret.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & dgvdfe.Rows.Item(i).Cells(2).Value & "")

                    Dim datadest As Date, dataprot As Date

                    Dim xmllist As System.Xml.XmlNodeList
                    Dim xmlnode As System.Xml.XmlNode
                    xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
                    xmllist = xmlret.SelectNodes("//bk:resNFe", xmlnsManager)

                    For Each xmlnode In xmllist
                        datadest = xmlnode("dhEmi").InnerText
                        dataprot = xmlnode("dhRecbto").InnerText
                        txtdfetiponfe.Text = xmlnode("tpNF").InnerText
                        txtdfesitnfe.Text = xmlnode("cSitNFe").InnerText

                        '''''''''''''''''''''''''''''''''''''''''''###################################'''''''''''''''''''''''''''''''''


                        dgvdferet.Rows.Add("NF-e", "", xmlnode("xNome").InnerText, datadest.ToString("dd/MM/yyyy"), xmlnode("vNF").InnerText,
                                                              dataprot.ToString("dd/MM/yyyy HH:mm:ss"), txtdfesitnfe.Text, txtdfetiponfe.Text, xmlnode("chNFe").InnerText,
                                                              xmlnode("IE").InnerText, "", "asalvar", "Sem manifestacao", "", dgvdfe.Rows.Item(i).Cells(0).Value)


                    Next

                Catch ex As Exception
                    dgverrodoc.Rows.Add(dgvdfe.Rows.Item(i).Cells(0).Value, dgvdfe.Rows.Item(i).Cells(2).Value)
                End Try

            End If


            '''''''''''''''''''''''''''''''''''########################''''''''''''''''''''''''''''''''''
            If dgvdfe.Rows.Item(i).Cells(1).Value.ToString.Substring(0, 9) = "resEvento" Then

                Try

                    Dim xmlret = New XmlDocument()
                    xmlret.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & dgvdfe.Rows.Item(i).Cells(2).Value & "")
                    xmlret.Save(Application.StartupPath & "\XML\Retevento.xml")

                    Dim xmllist As System.Xml.XmlNodeList
                    Dim xmlnode As XmlNode
                    xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
                    xmllist = xmlret.SelectNodes("//bk:resEvento", xmlnsManager)

                    For Each xmlnode In xmllist

                        dgvevento.Rows.Add(xmlnode("xEvento").InnerText, xmlnode("chNFe").InnerText,
                                                "", "Protocolo de Registro Evento: " & xmlnode("nProt").InnerText)

                    Next

                Catch ex As Exception
                    dgverrodoc.Rows.Add(dgvdfe.Rows.Item(i).Cells(0).Value, dgvdfe.Rows.Item(i).Cells(2).Value)
                End Try

            End If




            '''''''''''''''''''''''Rotina abaixo e para trar o Retorna da NFe por completa'''''''''''''''''''''''''''''''


            If dgvdfe.Rows.Item(i).Cells(1).Value.ToString.Substring(0, 7) = "procNFe" Then

                lbltotalnfe.Text = CDec(lbltotalnfe.Text) + 1

                Try


                    Dim chave As String
                    Dim dataemi As Date, dataprot As Date
                    Dim xmlret = New XmlDocument()
                    xmlret.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & dgvdfe.Rows.Item(i).Cells(2).Value & "")

                    Dim xmllist As System.Xml.XmlNodeList
                    Dim xmlnode As XmlNode
                    xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
                    xmllist = xmlret.SelectNodes("//bk:nfeProc", xmlnsManager)


                    For Each xmlnode In xmllist

                        If Not xmlnode("NFe")("infNFe")("ide")("dEmi") Is Nothing Then
                            dataemi = xmlnode("NFe")("infNFe")("ide")("dEmi").InnerText
                        End If

                        If Not xmlnode("NFe")("infNFe")("ide")("dhEmi") Is Nothing Then
                            dataemi = xmlnode("NFe")("infNFe")("ide")("dhEmi").InnerText
                        End If


                        dataprot = xmlnode("protNFe")("infProt")("dhRecbto").InnerText

                        chave = xmlnode("protNFe")("infProt")("chNFe").InnerText
                        txtdfetiponfe.Text = xmlnode("NFe")("infNFe")("ide")("tpNF").InnerText

                        Dim result As String = getDataGridViewIndex(chave)

                        If result = "R" Then

                            dgvdferet.Rows.Add("NF-e/xml", "", xmlnode("NFe")("infNFe")("emit")("xNome").InnerText, dataemi.ToString("dd/MM/yyyy HH:mm:ss"),
                                              xmlnode("NFe")("infNFe")("total")("ICMSTot")("vNF").InnerText, dataprot.ToString("dd/MM/yyyy HH:mm:ss"), "NF-e autorizada",
                                              txtdfetiponfe.Text, chave, xmlnode("NFe")("infNFe")("emit")("IE").InnerText, xmlret.OuterXml, "asalvar", "", "validar codbarra", dgvdfe.Rows.Item(i).Cells(0).Value)


                        Else



                            dgvdferet.Rows.Item(result).Cells(0).Value = "NF-e/xml"

                            dgvdferet.Rows.Item(result).Cells("xml_nfe").Value = xmlret.OuterXml

                            dgvdferet.Rows.Item(result).Cells("situacao_nfe").Value = ""
                            ''''''''''''''''''''''''''''asalvar para salvar as informações posteriormente
                            dgvdferet.Rows.Item(result).Cells("cont").Value = "asalvar"

                            dgvdferet.Rows.Item(result).Cells("Par_codBarra").Value = "validar codbarra"

                            dgvdferet.Rows.Item(result).Cells("nsu_doc").Value = dgvdfe.Rows.Item(i).Cells(0).Value

                        End If

                    Next

                    ''''''''''''''''''''''Salvar xml da pasta''''''''''''''''''''''''''
                    Dim ano As String = dataemi.ToString("yyyy")
                    Dim mes As String = dataemi.ToString("MM") & "-" & DateTimeFormatInfo.CurrentInfo.GetMonthName(dataemi.ToString("MM"))


                    If Directory.Exists(Application.StartupPath + "\xmltemp" + ano + "\" + mes + "\" + dataemi.ToString("dd")) = False Then
                        Directory.CreateDirectory((Application.StartupPath + "\" + ano + "\" + mes + "\" + dataemi.ToString("dd")))
                    End If

                    xmlret.Save(Application.StartupPath + "\xmltemp" + ano + "\" + mes + "\" + dataemi.ToString("dd") + "\" & chave + ".xml")



                Catch ex As Exception
                    dgverrodoc.Rows.Add(dgvdfe.Rows.Item(i).Cells(0).Value, dgvdfe.Rows.Item(i).Cells(2).Value)
                End Try


            End If

            Application.DoEvents()

        Next



        ''''''''''''''''''''''''Chama a Rotina de Salvar as NFe''''''''''''''''''''''''''

        bardfe.Visible = True
        salva_informacoes_dfe()


    End Sub

    Private Sub salva_informacoes_dfe()
        Dim rs_salvar As New ADODB.Recordset

        bardfe.Value = 0
        bardfe.Maximum = dgvdferet.RowCount
        bardfe.Value = 0

        For i As Integer = 0 To dgvdferet.Rows.Count - 1
            '''''''''''''''''''''''''''''''''Rotina para Salvar no Banco de Dados''''''''''''''''''
            If dgvdferet.Rows.Item(i).Cells("cont").Value = "asalvar" Then



                conectar_DFe()
                rs_salvar.Open("select * from NFe_consultadaDFe where chave_nfe like '" & dgvdferet.Rows.Item(i).Cells("chave_nfe").Value & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

                If rs_salvar.EOF = True Then
                    rs_salvar.AddNew()
                End If

                rs_salvar.Fields("Numero_NFe").Value = dgvdferet.Rows.Item(i).Cells("chave_nfe").Value.ToString.Substring(25, 9)
                rs_salvar.Fields("CNPJ_Emi").Value = dgvdferet.Rows.Item(i).Cells("chave_nfe").Value.ToString.Substring(6, 14)
                rs_salvar.Fields("Data_Emissao").Value = dgvdferet.Rows.Item(i).Cells(3).Value
                rs_salvar.Fields("Valor_nfe").Value = dgvdferet.Rows.Item(i).Cells(4).Value
                rs_salvar.Fields("chave_nfe").Value = dgvdferet.Rows.Item(i).Cells("chave_nfe").Value
                rs_salvar.Fields("Nome_emi").Value = dgvdferet.Rows.Item(i).Cells(2).Value
                rs_salvar.Fields("IE_emi").Value = dgvdferet.Rows.Item(i).Cells("ie").Value
                rs_salvar.Fields("data_consulta").Value = dgvdferet.Rows.Item(i).Cells(5).Value
                rs_salvar.Fields("status_nfe").Value = dgvdferet.Rows.Item(i).Cells(6).Value
                rs_salvar.Fields("CNPJ_Dest").Value = empresa.sCNPJ
                rs_salvar.Fields("Tipo_nf").Value = dgvdferet.Rows.Item(i).Cells(7).Value

                If dgvdferet.Rows.Item(i).Cells("xml_nfe").Value <> "" Then
                    Dim encText As New System.Text.UTF8Encoding()
                    Dim btText() As Byte
                    btText = encText.GetBytes(dgvdferet.Rows.Item(i).Cells("xml_nfe").Value)
                    rs_salvar.Fields("XML_NFe").Value = btText
                    rs_salvar.Fields("XML").Value = True
                End If

                rs_salvar.Update()


                cn_DFe.Close()

                dgvdferet.Rows.Item(i).Cells("cont").Value = "salvo"

            End If

            Application.DoEvents()
            '  Thread.Sleep(1)
            bardfe.Value += 1
        Next

        bardfe.Visible = False
    End Sub

    Private Sub seguencia_NSU()
        Dim rsp As New ADODB.Recordset
        Dim cont As Integer = txtultnsudfe.Text
        Dim cont2 As Integer

        For i As Integer = 0 To dgvdfe.Rows.Count - 1
            cont = cont + 1
            cont2 = dgvdfe.Rows.Item(i).Cells(0).Value

            If cont2 <> cont Then

                conectar_DFe()
                rsp.Open("select * from NSU_faltaDFe where CNPJ = '" & cnpj_cert & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                If rsp.EOF = True Then
                    rsp.AddNew()
                    rsp.Fields("CNPJ").Value = cnpj_cert
                    rsp.Fields("NSU").Value = cont
                End If
                rsp.Update()
                cn_DFe.Close()

            End If

        Next


    End Sub

    Private Sub salva_nsu()

        Dim rsp As New ADODB.Recordset
        ''''''''''''''''''''''Rotina para salvar ultimo NSU consultado''''''''''''''''''''''''

        conectar_DFe()

        rsp.Open("select * from DFe_NSU where CNPJ = '" & cnpj_cert & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        If rsp.EOF = True Then
            rsp.AddNew()
            rsp.Fields("CNPJ").Value = cnpj_cert
            rsp.Fields("Serial_cert").Value = nfecer
        End If

        rsp.Fields("NSU_ult").Value = txtultnsudfe.Text
        rsp.Update()

        cn_DFe.Close()

    End Sub

    Private Sub consulta_ultnsuDFe()

        Dim rssefaz As New ADODB.Recordset
        conectar_DFe()


        ''''''''''''''''''''''''''''''''''''''''''''''''Salvar os NSU para Controle de consulta'''''''''''''''''''
        rssefaz.Open("select * from DFe_NSU where CNPJ = '" & cnpj_cert & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        txtultnsudfe.Text = rssefaz.Fields("NSU_ult").Value

        rssefaz.Close()

        If txtultnsudfe.Text = "" Then
            txtultnsudfe.Text = "000000000000000"
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''Rotina abaixo verifica NSU faltante''''''''''''''''''''''
        rssefaz.Open("select * from NSU_faltaDFe where CNPJ = '" & cnpj_cert & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        Do While rssefaz.EOF = False
            cbonsufalta.Items.Add(rssefaz.Fields("NSU").Value.ToString.PadLeft(15, "0"))
            rssefaz.MoveNext()
        Loop


        cn_DFe.Close()

    End Sub

    ''' <summary>
    ''' 'Rotina abaixo calcula a Tempo de uma execução para outra''''''''''''''''''''''''''''''''''''''''''''''''
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CalcucarHora()

        Try
            Dim NewDT As DateTime = Now()
            NewDT = NewDT.AddHours(intervalo_tempo.Substring(0, 2)) 'It adds 8 hours from the current datetime.
            NewDT = NewDT.AddMinutes(intervalo_tempo.Substring(3, 2))
            NewDT = NewDT.AddSeconds(intervalo_tempo.Substring(6, 2))

            lblhoraprog.Text = NewDT
        Catch ex As Exception

        End Try


    End Sub


    ''' <summary>
    ''' 'Rotina abaixo gera o XML evento de Manifestação destinatario''''''''''''''''''''''''''''''''''''''''''''''''
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub gerar_evento_auto()

        pic_info.Visible = True
        txtinfodfe.Text = "Consulta DFe Realizado / Aguarde, Realizando Manifestacao (Ciencia Operacao Automatica)..."



        Dim cont As Integer = 0

        Dim teste As New NFe()
        Dim xml As String, dataevento As String
        Dim xmlevento = New XmlDocument()
        Dim manifestacao As New NFe()




        dataevento = Now.ToString("yyyy-MM-ddTHH:mm:ss%K")




        For i As Integer = "0" To dgvdferet.Rows.Count - 1
            If dgvdferet.Rows.Item(i).Cells("tipo_nfe").Value.ToString.Substring(0, 1) = "1" Then

                If dgvdferet.Rows.Item(i).Cells(0).Value = "NF-e" Then


                    If dgvdferet.Rows.Item(i).Cells("situacao_nfe").Value <> "Sem manifestacao" Then

                        If dgvdferet.Rows.Item(i).Cells("situacao_nfe").Value <> "Ciencia da Operacao" Then
                            dgvdferet.Rows.Item(i).Cells("situacao_nfe").Value = "Sem manifestacao"
                        End If

                    End If


                    If dgvdferet.Rows.Item(i).Cells("situacao_nfe").Value = "Sem manifestacao" Then

                        cont += 1

                        If cont <= 20 Then



                            manifestacao.versao = "1.00"
                            '''''''''''''codico ciencia operação''''''''''''''''''
                            manifestacao.Id = "210210" + dgvdferet.Rows.Item(i).Cells("chave_nfe").Value + "01"
                            manifestacao.chave = dgvdferet.Rows.Item(i).Cells("chave_nfe").Value
                            manifestacao.coduf = "91"
                            manifestacao.cnpj = cnpj_cert
                            manifestacao.dataenv = dataevento
                            manifestacao.codenv = "210210"
                            manifestacao.descenv = "Ciencia da Operacao"
                            manifestacao.xJust = ""
                            manifestacao.tpAmb = "1"

                            Dim xmldoc As XmlDocument = manifestacao.Gerarmanifestacaodest()

                            ' xmldoc.Save(Application.StartupPath & "\XML\manifestacaoNaoAssinado.xml")
                            If nfecer = "" Then
                                certificado = CertificadoDigital.SelecionarCertificado("")
                            Else
                                certificado = CertificadoDigital.SelecionarCertificado(nfecer)
                            End If

                            'assina os xml selecionados
                            Dim xmlAssinado As XmlDocument = CertificadoDigital.Assinar(xmldoc, "infEvento", certificado)
                            xml = xml + xmlAssinado.InnerXml

                        Else
                            Exit For
                        End If


                    End If

                End If

            End If
        Next

        '''''''''''''''''CRIAR E GERA LOTE DOS EVENTOS''''''''''''''''''''''''''''''''''''''''''''''''''
        If xml <> "" Then
            Dim xmldoc As New XmlDocument()
            xmldoc.Load(Application.StartupPath & "\XML\evento_manual.xml")
            xml = xmldoc.InnerXml
            '''''''''''''''''''''''''''''''''''''''''''''''''''' GERA O ARQUIVO XML DA MANIFESTAÇÃO''''''''''''''''''''''''''''''''''
            xmlevento.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><envEvento versao=""1.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><idLote>" & teste.GerarLoteNfe_dfe() & "</idLote>" & xml & "</envEvento>")
            xmlevento.Save(Application.StartupPath & "\XML\evento.xml")

            'Valida o XML assinado
            Dim resultado As String = ValidaXML.ValidarXML(xmlevento, Application.StartupPath & "\Esquemas_XML_NF-e\envConfRecebto_v1.00.xsd")

            If resultado.Trim().Length <> 0 Then
                MsgBox(resultado)
                ' resultado = "Xml gerado com sucesso, nenhum erro encontrado"
                Exit Sub
            End If

            Using xmltw As New XmlTextWriter(Application.StartupPath & "\XML\evento_auto.xml", New UTF8Encoding(False))
                xmlevento.WriteTo(xmltw)
                xmltw.Close()
            End Using



            Dim rotina1 As Thread
            Control.CheckForIllegalCrossThreadCalls = False
            rotina1 = New Thread(AddressOf manifestacao_dest_auto)
            rotina1.Start()

        End If
    End Sub


    ''' <summary>
    ''' 'Rotina abaixo envia manifestação do destinatario automatica''''''''''''''''''''''''''''''''''''''''''''''''
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub manifestacao_dest_auto()


        txtinfodfe.Text += vbCrLf & "Enviando Manifestação Destinatário para RFB..."

        Dim xmlretcanc = New XmlDocument()

        Try

            lbltempo.Text = "0"
            timer_manif.Enabled = True

          
            'função envia o xml para receita''''''''''''''''''''''''''''''''''
            retorevento = WebS.nfeRecepcaoEvento4(Application.StartupPath & "\XML\evento_auto.xml")

            If reterro <> "" Then
                txtinfodfe.Text = reterro
                reterro = String.Empty
                pic_info.Visible = False
                Exit Sub
            End If

            If retorevento.cStat <> "128" Then
                txtinfodfe.Text = retorevento.xMotivo
                pic_info.Visible = False
                Exit Sub
            End If


            If retorevento.cStat = "128" Then

                '  frmretmanifest.Label2.Text = "Retorno Da SEFAZ das NFe Enviadas para Manifestação"
                txtinfodfe.Text += vbCrLf & "Recebendo Retorno da RFB, manifestacao destinatario:"

                For Each RetC In retorevento.L_Retornos

                    ''''''''''''''''Rotina abaixo para evento desconhecimento da operação com retorno de nfe ja cancelada'''''''''''''''''


                    If RetC.cStat1 = "651" Then

                        conectar_DFe()
                        rs.Open("select * from NFe_consultadaDFe where chave_nfe = '" & RetC.chNFe & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                        rs.Fields("situacao_nfe").Value = "NFe Cancelada"
                        rs.Fields("data_dados").Value = Now.Date
                        rs.Update()
                        cn_DFe.Close()


                    End If

                    If RetC.cStat1 = "135" Or RetC.cStat1 = "136" Or RetC.cStat1 = "596" Or RetC.cStat1 = "573" Then

                        conectar_DFe()
                        rs.Open("select * from NFe_consultadaDFe where chave_nfe = '" & RetC.chNFe & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                        rs.Fields("situacao_nfe").Value = RetC.xEvento
                        rs.Fields("protocolo_NFe").Value = RetC.nProt
                        rs.Fields("data_dados").Value = Now.Date
                        rs.Update()
                        cn_DFe.Close()

                    End If





                    '     frmretmanifest.dgvsefaz.Rows.Add(RetC.chNFe, RetC.xMotivo1, RetC.nProt, RetC.xEvento, RetC.cStat1)

                    '''''''''''''''''Pesquisa e passa o retorno para grid de manifestacao'''
                    Dim result As String = getDataGridViewIndex(RetC.chNFe)

                    If RetC.cStat1 = "135" Or RetC.cStat1 = "136" Then

                        txtinfodfe.Text += vbCrLf & RetC.chNFe & " | " & RetC.xEvento

                        dgvdferet.Rows.Item(result).Cells("situacao_nfe").Value = RetC.xEvento

                        dgvdferet.Rows.Item(result).Cells(1).Style.BackColor = Color.LightGreen

                        dgvdferet.Rows.Item(result).Cells("Par_codBarra").Value = RetC.xEvento

                    Else

                        txtinfodfe.Text += vbCrLf & RetC.chNFe & " | " & RetC.xMotivo1

                        dgvdferet.Rows.Item(result).Cells("situacao_nfe").Value = RetC.xMotivo1

                        dgvdferet.Rows.Item(result).Cells(1).Style.ForeColor = Color.White
                        dgvdferet.Rows.Item(result).Cells(1).Style.BackColor = Color.DarkRed

                    End If





                Next



            End If

            txtinfodfe.Text = "Ultimo Processo de Consulta DFe Realizado em: " & ret_dfe_xml.dhResp
            pic_info.Visible = False


        Catch ex As Exception
            pic_info.Visible = False
        End Try

    End Sub

    Private Function getDataGridViewIndex(ByVal id As String) As String

        Dim r As String = "R"

        For Each row As DataGridViewRow In Me.dgvdferet.Rows

            If Not row.IsNewRow Then
                If row.Cells("chave_nfe").Value = id Then
                    Return row.Index
                End If
            End If

        Next

        Return r

    End Function


    Private Sub validar_codigo_barra()

        For i As Integer = 0 To dgvdferet.Rows.Count - 1

            If dgvdferet.Rows.Item(i).Cells("Par_codBarra").Value = "validar codbarra" Then

                dgvdferet.Rows.Item(i).Cells("Par_codBarra").Value = "codbarra_valido"

                Dim cont_total As Integer = 0
                Dim cont_barra As Integer = 0

                Dim xml_cod As New XmlDocument()

                xml_cod.LoadXml(dgvdferet.Rows.Item(i).Cells("xml_nfe").Value)


                Dim xmllist As System.Xml.XmlNodeList
                Dim xmlnode As System.Xml.XmlNode
                xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
                xmllist = xml_cod.SelectNodes("//bk:prod", xmlnsManager)

                For Each xmlnode In xmllist

                    If xmlnode("uCom").InnerXml.Length >= 2 Then

                        If xmlnode("uCom").InnerXml.Substring(0, 2) <> "KG" Then
                            cont_total += 1

                            If xmlnode("cEAN").InnerXml = "" Then
                                cont_barra += 1
                            End If
                        End If


                    End If
                Next


                If cont_barra <> 0 Then

                    If (CDec(cont_barra) * 100) / CDec(cont_total) > 50 Then

                        'MsgBox("codigo faltando " & cont_total & "|" & cont_barra)

                        dgvdferet.Rows.Item(i).Cells("Par_codBarra").Value = "codbarra_invalido"

                        ''''''''''colori o grid''''''''''''''''''
                        With Me.dgvdferet.Rows(i).DefaultCellStyle
                            .BackColor = Color.LightSalmon
                            .ForeColor = Color.Blue
                        End With

                    End If

                End If





            End If

        Next



    End Sub


#End Region



#Region "''''''Manifestacao do Destinatario"

    Private Sub carregar_nfe_manifestacao()
        Dim sqlconsulta As String

        dgvpesquisanfe.Rows.Clear()

        '  sqlconsulta = "select * from NFe_consultadadfe where (situacao_nfe is null or situacao_nfe = 'Ciencia da Operacao') and status_nfe <>'NF-e cancelada' and CNPJ_Dest = '" & mskcnpj_esp.Text & "' and Nome_emi like '" & txtnome_pesq.Text & "%'"
        sqlconsulta = "select * from NFe_consultadadfe where (situacao_nfe is null or situacao_nfe = 'Ciencia da Operacao') and CNPJ_Dest = '" & mskcnpj_esp.Text & "'"

        If chktipo.Checked = True Then
            sqlconsulta = sqlconsulta + "and Tipo_nf = '" & cbotipo.Text & "'"
        End If
        If chkstatus.Checked = True Then
            sqlconsulta = sqlconsulta + "and status_nfe = '" & cbostatus_nfe.Text & "'"
        End If
        If chkdata.Checked = True Then
            sqlconsulta = sqlconsulta + "and data_Emissao BETWEEN #" & Convert.ToDateTime(mskdatainicial.Text).ToString("yyyy-MM-dd") & "# AND #" & Convert.ToDateTime(mskdatafinal.Text).ToString("yyyy-MM-dd") & "#"
        End If
        If chknome.Checked = True Then
            sqlconsulta = sqlconsulta + "and Nome_emi like '" & txtnome_pesq.Text & "%'"
        End If
        '''''''Rotina abaixo conecta no banco de dados conexao ADO.net


        conectar_DFe()
        rs.Open(sqlconsulta, cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        bar_status.Value = 0
        bar_status.Maximum = rs.RecordCount

        Do While rs.EOF = False

            If rs.Fields("CNPJ_Emi").Value <> "10962965000119" Then

                dgvpesquisanfe.Rows.Add(False, rs.Fields("chave_nfe").Value, rs.Fields("Nome_emi").Value, rs.Fields("CNPJ_Emi").Value,
                                        rs.Fields("Data_Emissao").Value, rs.Fields("Valor_nfe").Value, rs.Fields("data_consulta").Value,
                                        rs.Fields("situacao_nfe").Value, rs.Fields("Tipo_nf").Value, rs.Fields("CNPJ_Dest").Value)

            End If

            rs.MoveNext()

            Application.DoEvents()
            Thread.Sleep(1)
            bar_status.Value += 1
            lblperc.Text = CType((bar_status.Value / bar_status.Maximum * 100), Integer).ToString & "%"

        Loop

        cn_DFe.Close()


        lbltotal.Text = "Total de NFe carregadas: " & dgvpesquisanfe.RowCount

    End Sub


    Public Sub verifica_lancamento_sglinear()
        Try

            bar_status.Value = 0
            bar_status.Maximum = dgvpesquisanfe.RowCount

            For Each row As DataGridViewRow In dgvpesquisanfe.Rows



                If row.Cells("cnpj_empresa").Value = "10962965000119" Then


                    Dim rschave As New ADODB.Recordset

                    conectarsqlinx()


                    rschave.Open("select * from cmd where nfe_chave = '" & row.Cells(1).Value & "'", cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

                    If rschave.EOF = True Then

                        With Me.dgvpesquisanfe.Rows(row.Index).DefaultCellStyle


                            .BackColor = Color.LightCyan
                            .ForeColor = Color.Blue


                        End With

                    End If

                    '  Application.DoEvents()
                    Thread.Sleep(1)
                    bar_status.Value += 1
                    lblperc.Text = CType((bar_status.Value / bar_status.Maximum * 100), Integer).ToString & "%"

                    cnsql.Close()
                End If

            Next

        Catch ex As Exception

        End Try

    End Sub


    Private Sub gerar_manifestacao(ByVal codenv As String, ByVal descenv As String, ByVal xJust As String)
        Dim data_env As String
        Dim xml As String
        Dim xmlevento = New XmlDocument()
        Dim manifestacao As New NFe()



        data_env = Now.ToString("yyyy-MM-ddTHH:mm:ss%K")

        txtinfo_manifest.Text = "Gerando arquivo da Manifestacao do destinatario para envio..."

        For i As Integer = 0 To dgvpesquisanfe.Rows.Count - 1

            If dgvpesquisanfe.Rows.Item(i).Cells(0).Value = True Then

                manifestacao.versao = "1.00"
                manifestacao.Id = codenv + dgvpesquisanfe.Rows.Item(i).Cells(1).Value + "01"
                manifestacao.chave = dgvpesquisanfe.Rows.Item(i).Cells(1).Value
                manifestacao.coduf = "91"
                manifestacao.cnpj = dgvpesquisanfe.Rows.Item(i).Cells("cnpj_empresa").Value
                manifestacao.dataenv = data_env
                manifestacao.codenv = codenv
                manifestacao.descenv = descenv
                manifestacao.xJust = xJust
                manifestacao.tpAmb = "1"

                Dim xmldoc As XmlDocument = manifestacao.Gerarmanifestacaodest()

                ' xmldoc.Save(Application.StartupPath & "\XML\manifestacaoNaoAssinado.xml")
                If nfecer = "" Then
                    certificado = CertificadoDigital.SelecionarCertificado("")
                Else
                    certificado = CertificadoDigital.SelecionarCertificado(nfecer)
                End If

                'assina os xml selecionados
                Dim xmlAssinado As XmlDocument = CertificadoDigital.Assinar(xmldoc, "infEvento", certificado)
                xml = xml + xmlAssinado.InnerXml

            End If

        Next

        '''''''''''''''''''''''''''''''''''''''''''''''''''' GERA O ARQUIVO XML DA MANIFESTAÇÃO''''''''''''''''''''''''''''''''''
        xmlevento.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><envEvento versao=""1.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><idLote>" & GerarLote_manifestacao() & "</idLote>" & xml & "</envEvento>")
        xmlevento.Save(Application.StartupPath & "\XML\evento.xml")

        'Valida o XML assinado
        Dim resultado As String = ValidaXML.ValidarXML(xmlevento, Application.StartupPath & "\Esquemas_XML_NF-e\envConfRecebto_v1.00.xsd")

        If resultado.Trim().Length <> 0 Then
            MsgBox(resultado)
            ' resultado = "Xml gerado com sucesso, nenhum erro encontrado"
            Exit Sub
        End If

        Using xmltw As New XmlTextWriter(Application.StartupPath & "\XML\evento.xml", New UTF8Encoding(False))
            xmlevento.WriteTo(xmltw)
            xmltw.Close()
        End Using



        Dim rotina1 As Thread
        Control.CheckForIllegalCrossThreadCalls = False
        rotina1 = New Thread(AddressOf envia_manifestacao_dest)
        rotina1.Start()

    End Sub

    Private Sub envia_manifestacao_dest()

        Dim xmlretcanc = New XmlDocument()

        Try

            '''''''''''BUSCA URL do webservice''''''''''''
            WebS.url_webservice(BuscaURL("AN31", 1, False, ""))

            'função envia o xml para receita''''''''''''''''''''''''''''''''''
            txtinfo_manifest.Text = "Enviando Manifestação Destinatário Para RFB..."

            retorevento = WebS.nfeRecepcaoEvento4(Application.StartupPath & "\XML\evento.xml")

            If reterro <> "" Then
                txtinfo_manifest.Text = reterro
                MsgBox(reterro, MsgBoxStyle.Exclamation, "Aviso !")
                reterro = String.Empty
                Exit Sub
            End If

            If retorevento.cStat <> "128" Then
                txtinfo_manifest.Text = retorevento.xMotivo
                pinfo.Visible = False
                Exit Sub
            End If


            If retorevento.cStat = "128" Then

                '  frmretmanifest.Label2.Text = "Retorno Da SEFAZ das NFe Enviadas para Manifestação"
                txtinfo_manifest.Text = "Recebendo Retorno da Manifestacao enviada para RFB..."

                For Each RetC In retorevento.L_Retornos

                    ''''''''''''''''Rotina abaixo para evento desconhecimento da operação com retorno de nfe ja cancelada'''''''''''''''''


                    If RetC.cStat1 = "651" Then

                        conectar_DFe()
                        rs.Open("select * from NFe_consultadaDFe where chave_nfe = '" & RetC.chNFe & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                        rs.Fields("situacao_nfe").Value = "NFe Cancelada"
                        rs.Fields("data_dados").Value = Now.Date
                        rs.Update()
                        cn_DFe.Close()


                    End If

                    If RetC.cStat1 = "135" Or RetC.cStat1 = "136" Or RetC.cStat1 = "596" Or RetC.cStat1 = "573" Then

                        conectar_DFe()
                        rs.Open("select * from NFe_consultadaDFe where chave_nfe = '" & RetC.chNFe & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                        rs.Fields("situacao_nfe").Value = RetC.xEvento
                        rs.Fields("protocolo_NFe").Value = RetC.nProt
                        rs.Fields("data_dados").Value = Now.Date
                        rs.Update()
                        cn_DFe.Close()


                    End If





                    '     frmretmanifest.dgvsefaz.Rows.Add(RetC.chNFe, RetC.xMotivo1, RetC.nProt, RetC.xEvento, RetC.cStat1)

                    '''''''''''''''''Pesquisa e passa o retorno para grid de manifestacao'''
                    Dim result As String = getDataGridViewIndex_manifest(RetC.chNFe)

                    If RetC.cStat1 = "135" Or RetC.cStat1 = "136" Then

                        dgvpesquisanfe.Rows.Item(result).Cells("situacao_nfe_m").Value = RetC.xEvento

                        dgvpesquisanfe.Rows.Item(result).Cells(7).Style.BackColor = Color.LightGreen

                    Else

                        dgvpesquisanfe.Rows.Item(result).Cells("situacao_nfe_m").Value = RetC.xMotivo1

                        dgvpesquisanfe.Rows.Item(result).Cells(7).Style.ForeColor = Color.White
                        dgvpesquisanfe.Rows.Item(result).Cells(7).Style.BackColor = Color.DarkRed

                    End If



                    dgvpesquisanfe.Rows.Item(result).Cells(0).Value = False

                Next



            End If

            txtinfo_manifest.Text = "Manifestacao Do destinatario Realizada com Sucesso."

            pinfo.Visible = False

        Catch ex As Exception
            txtinfo_manifest.Text = ex.Message
            pinfo.Visible = False
        End Try

    End Sub


    Private Sub consultanfe_sefaz()
        Dim rsconsulta As New ADODB.Recordset
        Dim WebS As New C_WebService
        Dim retornonfe As New RetRetorno
        Dim xmlretcanc = New XmlDocument()

        Button8.Enabled = False

        For i As Integer = 0 To dgvpesquisanfe.Rows.Count - 1

            If dgvpesquisanfe.Rows.Item(i).Cells(0).Value = True Then


                Try

                    '''''''''''BUSCA URL do webservice''''''''''''
                    WebS.url_webservice(BuscaURL(dgvpesquisanfe.Rows.Item(i).Cells(1).Value.Substring(0, 2), 1, False, ""))

                    lblinfo_sefaz.Visible = True
                    lblinfo_sefaz.Text = "Realizando consulta na SEFAZ...."

                    retornonfe = WebS.ConsultaStatusNfe4(dgvpesquisanfe.Rows.Item(i).Cells(1).Value, 1)


                    If retornonfe.cStat <> "100" Then

                        If retornonfe.cStat <> "1010" Then
                            txtinfo_manifest.Text = retornonfe.xMotivo
                        End If

                    End If

                    '''''''''''''''''''Rotina abaixo para ler o retorno no xml de ret''''''''''''
                    lblinfo_sefaz.Text = "Recebendo retorno consulta na SEFAZ...."

                    Dim xmldoc As New XmlDocument()
                    Dim xmlnsManager As New XmlNamespaceManager(xmldoc.NameTable)

                    Dim xmllist As System.Xml.XmlNodeList
                    Dim xmlnode As Xml.XmlNode

                    xmldoc.Load(Application.StartupPath & "\XML\Retorno_consultaNFe.xml")

                    xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
                    xmllist = xmldoc.SelectNodes("//bk:protNFe", xmlnsManager)


                    For Each xmlnode In xmllist
                        dgvpesquisanfe.Rows.Item(i).Cells(7).Value = xmlnode("infProt")("xMotivo").InnerText
                        dgvpesquisanfe.Rows.Item(i).Cells("nprot").Value = xmlnode("infProt")("nProt").InnerText
                        dgvpesquisanfe.Rows.Item(i).Cells("data_aut").Value = Convert.ToDateTime(xmlnode("infProt")("dhRecbto").InnerText).ToString("dd/MM/yyyy HH:mm:ss")
                    Next

                    xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
                    xmllist = xmldoc.SelectNodes("//bk:procEventoNFe", xmlnsManager)


                    For Each xmlnode In xmllist

                        If xmlnode("retEvento")("infEvento")("tpEvento").InnerText = "210200" Or xmlnode("retEvento")("infEvento")("tpEvento").InnerText = "210210" _
                           Or dgvpesquisanfe.Rows.Item(i).Cells(7).Value = "210220" Or xmlnode("retEvento")("infEvento")("tpEvento").InnerText = "210240" _
                           Or xmlnode("retEvento")("infEvento")("tpEvento").InnerText = "110111" Then

                            If dgvpesquisanfe.Rows.Item(i).Cells(10).Value <> "210200" Then
                                dgvpesquisanfe.Rows.Item(i).Cells(7).Value = xmlnode("evento")("infEvento")("detEvento")("descEvento").InnerText
                                dgvpesquisanfe.Rows.Item(i).Cells(10).Value = xmlnode("retEvento")("infEvento")("tpEvento").InnerText


                                conectar_DFe()

                                rsconsulta.Open("select * from NFe_consultadaDFe where chave_nfe = '" & xmlnode("retEvento")("infEvento")("chNFe").InnerText & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                                rsconsulta.Fields("protocolo_NFe").Value = xmlnode("retEvento")("infEvento")("nProt").InnerText

                                If xmlnode("retEvento")("infEvento")("tpEvento").InnerText = "210210" Then
                                    rsconsulta.Fields("Protocolo_ciencia").Value = xmlnode("retEvento")("infEvento")("nProt").InnerText
                                End If

                                If xmlnode("retEvento")("infEvento")("tpEvento").InnerText = "110111" Then
                                    rsconsulta.Fields("status_nfe").Value = "NFe cancelada"
                                End If

                                rsconsulta.Fields("situacao_nfe").Value = xmlnode("evento")("infEvento")("detEvento")("descEvento").InnerText
                                rsconsulta.Fields("data_dados").Value = Now.Date
                                rsconsulta.Update()
                                cn_DFe.Close()

                            End If

                        End If
                    Next

                    If dgvpesquisanfe.Rows.Item(i).Cells(7).Value.ToString = "" Then
                        dgvpesquisanfe.Rows.Item(i).Cells(7).Value = "Sem retorno da SEFAZ"
                    End If

                    dgvpesquisanfe.Rows.Item(i).Cells(0).Value = False
                    '  System.IO.File.Delete(Application.StartupPath & "\XML\Retorno_consultaNFe.xml")


                    lblinfo_sefaz.Text = "Consulta Realizada com Sucesso."
                    lblinfo_sefaz.Visible = False
                    Button8.Enabled = True
                    File.Delete(Application.StartupPath & "\XML\Retorno_consultaNFe.xml")

                Catch ex As Exception
                    '  txtinfo_manifest.Text = ex.Message
                    dgvpesquisanfe.Rows.Item(i).Cells(7).Value = "Sem retorno da SEFAZ"
                    Button8.Enabled = True
                End Try




            End If
        Next

        pinfo.Visible = False
    End Sub

    Private Function getDataGridViewIndex_manifest(ByVal id As String) As String

        Dim r As String = "R"

        For Each row As DataGridViewRow In Me.dgvpesquisanfe.Rows

            If Not row.IsNewRow Then
                If row.Cells("chave_nfe_m").Value = id Then
                    Return row.Index
                End If
            End If

        Next

        Return r

    End Function

    Private Sub bntconfimarda_Click(sender As Object, e As EventArgs) Handles bntconfimarda.Click
        Dim selecao As Boolean = False
        For i As Integer = 0 To dgvpesquisanfe.Rows.Count - 1

            If dgvpesquisanfe.Rows.Item(i).Cells(0).Value = True Then
                selecao = True
            End If

        Next

        If selecao = False Then
            MsgBox("Não existe nenhuma Nota Fiscal Selecionada Para Manifestação !" & vbCrLf & "Operação Cancelada !", MsgBoxStyle.Exclamation, "Atenção !")
            txtinfo_manifest.Text = "Não existe nenhuma Nota Fiscal Selecionada Para Manifestação !"
            Exit Sub
        End If


        If MessageBox.Show("Será Realizado a Manifestação de" + vbCrLf + "(Confirmacao da Operacao) para As Nota Selecionadas, " & vbCrLf & "Deseja continuar ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            pinfo.Visible = True
            gerar_manifestacao("210200", "Confirmacao da Operacao", "")
        End If




    End Sub


    Private Sub bntciencia_Click(sender As Object, e As EventArgs) Handles bntciencia.Click
        Dim selecao As Boolean = False
        For i As Integer = 0 To dgvpesquisanfe.Rows.Count - 1

            If dgvpesquisanfe.Rows.Item(i).Cells(0).Value = True Then
                selecao = True
            End If

        Next

        If selecao = False Then
            MsgBox("Não existe nenhuma Nota Fiscal Selecionada Para Manifestação !" & vbCrLf & "Operação Cancelada !", MsgBoxStyle.Exclamation, "Atenção !")
            txtinfo_manifest.Text = "Não existe nenhuma Nota Fiscal Selecionada Para Manifestação !"
            Exit Sub
        End If



        If MessageBox.Show("Será Realizado a Manifestação de" + vbCrLf + "(Ciencia da Operaca) para As Nota Selecionadas, " & vbCrLf & "Deseja continuar ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            pinfo.Visible = True
            gerar_manifestacao("210210", "Ciencia da Operacao", "")
        End If



    End Sub

    Private Sub bntdesc_Click(sender As Object, e As EventArgs) Handles bntdesc.Click
        Dim selecao As Boolean = False
        For i As Integer = 0 To dgvpesquisanfe.Rows.Count - 1

            If dgvpesquisanfe.Rows.Item(i).Cells(0).Value = True Then
                selecao = True
            End If

        Next

        If selecao = False Then
            MsgBox("Não existe nenhuma Nota Fiscal Selecionada Para Manifestação !" & vbCrLf & "Operação Cancelada !", MsgBoxStyle.Exclamation, "Atenção !")
            txtinfo_manifest.Text = "Não existe nenhuma Nota Fiscal Selecionada Para Manifestação !"
            Exit Sub
        End If



        If MessageBox.Show("Será Realizado a Manifestação de" + vbCrLf + "(Desconhecimento da Operacao) para As Nota Selecionadas, " & vbCrLf & "Deseja continuar ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            pinfo.Visible = True
            gerar_manifestacao("210220", "Desconhecimento da Operacao", "")
        End If

    End Sub

    Private Sub bntopenao_Click(sender As Object, e As EventArgs) Handles bntopenao.Click
        Dim selecao As Boolean = False
        For i As Integer = 0 To dgvpesquisanfe.Rows.Count - 1

            If dgvpesquisanfe.Rows.Item(i).Cells(0).Value = True Then
                selecao = True
            End If

        Next

        If selecao = False Then
            MsgBox("Não existe nenhuma Nota Fiscal Selecionada Para Manifestação !" & vbCrLf & "Operação Cancelada !", MsgBoxStyle.Exclamation, "Atenção !")
            txtinfo_manifest.Text = "Não existe nenhuma Nota Fiscal Selecionada Para Manifestação !"
            Exit Sub
        End If


        dgvpesquisanfe.Enabled = False
        Pdest.Visible = True

    End Sub


    Private Sub btnconfirmar_Click(sender As Object, e As EventArgs) Handles btnconfirmar.Click
        If txtjustificativa.Text.Length < 15 Then
            MsgBox("A Justificativa deve conter no Minimo 15 caracter ?", MsgBoxStyle.Exclamation, "Aviso !")
            txtjustificativa.Focus()
            Exit Sub
        End If

        If txtjustificativa.Text.Length > 255 Then
            MsgBox("A Justificativa deve conter no máximo 255 caracter ?", MsgBoxStyle.Exclamation, "Aviso !")
            txtjustificativa.Focus()
            Exit Sub
        End If

        If txtjustificativa.Text = "" Then
            MsgBox("Informe Justificativa campo Obrigatorio ?", MsgBoxStyle.Exclamation, "Aviso !")
            txtjustificativa.Focus()
            Exit Sub
        End If

        dgvpesquisanfe.Enabled = True
        Pdest.Visible = False


        If MessageBox.Show("Será Realizado a Manifestação de" + vbCrLf + "(Operacao nao Realizada) para As Nota Selecionadas, " & vbCrLf & "Deseja continuar ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            pinfo.Visible = True
            gerar_manifestacao("210240", "Operacao nao Realizada", txtjustificativa.Text)
        End If

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Dim selecao As Boolean = False
        For i As Integer = 0 To dgvpesquisanfe.Rows.Count - 1

            If dgvpesquisanfe.Rows.Item(i).Cells(0).Value = True Then
                selecao = True
            End If

        Next

        If selecao = False Then
            MsgBox("Não existe nenhuma Nota Fiscal Selecionada Para Consulta !" & vbCrLf & "Operação Cancelada !", MsgBoxStyle.Exclamation, "Atenção !")
            txtinfo_manifest.Text = "Não existe nenhuma Nota Fiscal Selecionada Para Consulta !"
            Exit Sub
        End If

        pinfo.Visible = True
        Dim rotina3 As Thread
        Control.CheckForIllegalCrossThreadCalls = False
        rotina3 = New Thread(AddressOf consultanfe_sefaz)
        rotina3.SetApartmentState(ApartmentState.STA)
        rotina3.Start()
    End Sub



#End Region





#Region "''''''Download via Site do portal nacional"




#End Region

    ''' <summary>
    ''' 'Rotina abaixo para consulta NSU faltando''''''''''''''''''''''''''''''''''''''''''''''''
    ''' </summary>
    ''' <remarks></remarks>

    Private Sub bntnsufalta_Click(sender As Object, e As EventArgs) Handles bntnsufalta.Click

        If cboambdfe.Text = "" Then
            txtinfodfe.Text = "Informe o tipo de Ambiente a ser consultado na Receita Federal"
            cboambdfe.Focus()
            Exit Sub
        End If

        If cbonsufalta.Text = "" Then
            txtinfodfe.Text = "Informe o NSU que esta Faltando na seguencia no campo NSU Pendentes"
            cbonsufalta.Focus()
            Exit Sub
        End If

        bntnsufalta.Enabled = False

        txtinfodfe.Text = "Consultando NSU que Faltou em execução..."

        tipo_processo = "Dfe_cons"
        File.Delete(Application.StartupPath & "\XML\retDistDFeInt.xml")
        Tdfe_status.Enabled = True
        frmwebservice.ambiente = cboambdfe.Text.Substring(0, 1)
        frmwebservice.tipo_processo = tipo_processo
        frmwebservice.ShowDialog()


    End Sub

    Private Sub FrmDfe_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    End Sub


    Private Sub FrmDfe_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '''''''''''''''''''''''''''''''''''''''Rotina busca certificado digital'''''''''''''''''''''''''''''''''
        Try
            Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")
            If arquivoIni.KeyExists("cert_tela_inicial", "DFe") = False Then
                arquivoIni.Write("cert_tela_inicial", "false", "DFe")
            End If

            If arquivoIni.Read("cert_tela_inicial", "DFe") = True Then


                busca_certificado()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Aviso DFe !")
        End Try


        ''''''''''''''''Carrega parametro''
        Parametro.carregar_parametro_DFe()


        ''''''''''''''desativa a aba DFe''''''
        If dfe_aba_ativa = False Then
            TabControl1.TabPages(0).Enabled = False
        End If

        ''''''''''''''Consulta  automatica atiiva''''''
        If execucao_automatico = True Then
            TconsultaDFe.Enabled = True
            CalcucarHora()
        End If


        mskcnpj_esp.Text = cnpj_cert

        criar_tabela()

        Try
            If certificado.ToString = "" Then
                frmcert.ShowDialog()
            End If
        Catch ex As Exception
            frmcert.ShowDialog()
        End Try

    End Sub

#Region "''''Rotina para capturar os dados do certificado digital"

    Public Sub busca_certificado()

        If nfecer = "" Then
            frmcert.ShowDialog()
        Else
            certificado = SelecionarCertificado(nfecer)
        End If

        If nfecer = "" Then
            bntpesqDFe.Enabled = False
            bntnsufalta.Enabled = False
        End If

        Dim di As New IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory & "\cert")
        Dim aryFi As IO.FileInfo() = di.GetFiles("*.pfx")
        Dim fi As IO.FileInfo
        cbocert.Items.Clear()
        For Each fi In aryFi
            cbocert.Items.Add(fi.Name.Substring(0, fi.Name.Length - 4))
        Next
    End Sub


#End Region

    Private Sub TconsultaDFe_Tick(sender As Object, e As EventArgs) Handles TconsultaDFe.Tick


        If Now.ToString("dd/MM/yyyy HH:mm:ss") = lblhoraprog.Text Then


            frmxml.Close()
            txttotalarqdfe_ultim.Text = "0"
            txtinfodfe.Text = "Consulta automatica (DFe) em execução, aguarde...."

            tipo_processo = "Dfe"
            File.Delete(Application.StartupPath & "\XML\retDistDFeInt.xml")
            Tdfe_status.Enabled = True
            frmwebservice.ambiente = cboambdfe.Text.Substring(0, 1)
            frmwebservice.tipo_processo = tipo_processo
            frmwebservice.ShowDialog()

        End If


    End Sub

    Private Sub txtdfetiponfe_TextChanged(sender As Object, e As EventArgs) Handles txtdfetiponfe.TextChanged
        If txtdfetiponfe.Text = "0" Then
            txtdfetiponfe.Text = "0-NFe Entrada"
        End If
        If txtdfetiponfe.Text = "1" Then
            txtdfetiponfe.Text = "1-NFe Saida"
        End If
    End Sub

    Private Sub txtdfesitnfe_TextChanged(sender As Object, e As EventArgs) Handles txtdfesitnfe.TextChanged
        If txtdfesitnfe.Text = "1" Then
            txtdfesitnfe.Text = "NF-e autorizada"
        End If
        If txtdfesitnfe.Text = "2" Then
            txtdfesitnfe.Text = "Uso denegado"
        End If

        If txtdfesitnfe.Text = "3" Then
            txtdfesitnfe.Text = "NF-e cancelada"
        End If

    End Sub


    Private Sub cboambdfe_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboambdfe.SelectedIndexChanged
        escreveINI(Application.StartupPath & "\config_DFe.ini", "DFe", "ambiente", cboambdfe.Text.Substring(0, 1))
    End Sub

    Private Sub chkmanifes_CheckedChanged(sender As Object, e As EventArgs) Handles chkmanifes.CheckedChanged
        escreveINI(Application.StartupPath & "\config_DFe.ini", "MANIFESTO_AUTOMATICO", "ativa", chkmanifes.Checked)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        carregar_dfe()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        abrir_xml()
    End Sub



    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        If dgverrodoc.Visible = False Then
            dgverrodoc.Visible = True
            dgvevento.Visible = False
        Else
            dgverrodoc.Visible = False
            dgvevento.Visible = True
        End If
    End Sub

    Private Sub txtultnsudfe_TextChanged(sender As Object, e As EventArgs) Handles txtultnsudfe.TextChanged

    End Sub

    Public Function SepararNota(ByVal vNfeDadosMsg As String) As String

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<NFe")
        Dim n5t As Int32 = vNfeDadosMsg.IndexOf("</NFe")
        Dim total As Int32 = vNfeDadosMsg.Length - n5t
        Dim nPosF As Int32 = vNfeDadosMsg.Length - nPosI
        Dim vStringNfe As String = vNfeDadosMsg.Substring(nPosI, nPosF - total + 6)
        Return vStringNfe

    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        bar_status.Visible = True
        lblperc.Visible = True

        carregar_nfe_manifestacao()

        If chksg.Checked = True Then
            verifica_lancamento_sglinear()
        End If


        bar_status.Visible = False
        lblperc.Visible = False

        MsgBox("Pesquisa Concluida !", MsgBoxStyle.Information, "Aviso !")
    End Sub

    Private Sub bntsair_Click(sender As Object, e As EventArgs) Handles bntsair.Click
        Pdest.Visible = False
        dgvpesquisanfe.Enabled = True
    End Sub

    Private Sub carregar_dfe()
        '''''''''''''''''''Limpa o grid anterior''''''''''''''
        dgvdfe.Rows.Clear()

        '''''''''''''''''''''''''''''''
        xmldoc.Load(Application.StartupPath & "\XML\retDistDFeInt.xml")
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode
        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist = xmldoc.SelectNodes("//bk:loteDistDFeInt", xmlnsManager)




        For Each xmlnode In xmllist


            For Each InnerNode2 As XmlNode In xmlnode.ChildNodes



                Dim gz As Compression.GZipStream

                Dim gzBuffer As Byte() = Convert.FromBase64String(InnerNode2.InnerText)


                ''''''''''''''''''''''Nova Rotina Descripar Gzip''''''''''''''''''''

                Using ms As New IO.MemoryStream(gzBuffer)
                    Using gzs As New System.IO.Compression.GZipStream(ms, IO.Compression.CompressionMode.Decompress)
                        Using rdr As New IO.StreamReader(gzs)
                            dgvdfe.Rows.Add(InnerNode2.Attributes.Item(0).Value, InnerNode2.Attributes.Item(1).Value, rdr.ReadToEnd)
                        End Using 'rdr
                    End Using 'gzs
                End Using 'ms
            Next

        Next

        txttotalarqdfe_ultim.Text = CDec(txttotalarqdfe_ultim.Text) + dgvdfe.Rows.Count
    End Sub

    Private Sub txtultnsudfe_DoubleClick(sender As Object, e As EventArgs) Handles txtultnsudfe.DoubleClick
        txtultnsudfe.BackColor = Color.White
        txtultnsudfe.ReadOnly = False
    End Sub

    Private Sub txtnome_pesq_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnome_pesq.KeyPress
        If (e.KeyChar = Chr(13)) Then
            carregar_nfe_manifestacao()
            verifica_lancamento_sglinear()
        End If
    End Sub

    Private Sub manifestacao_nfe_Enter(sender As Object, e As EventArgs) Handles manifestacao_nfe.Enter
        dgvpesquisanfe.Rows.Clear()

        mskdatainicial.Text = Now.Date.AddDays(-NumericUpDown1.Value)
        Timer_hora.Enabled = False

        cbotipo.SelectedIndex = 0
        cbostatus_nfe.SelectedIndex = 0
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        site.Text = WebBrowser1.DocumentTitle



        If consulta = True Then
            WebBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_txtChaveAcessoCompleta").InnerText = txtchavedfe.Text.Replace(" ", "")
            ' WebBrowser1.Document.GetElementById("ctl00$ContentPlaceHolder1$btnConsultar").InvokeMember("Click")
            consulta = False
            par_down = True
        End If

        If Not WebBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_bltMensagensErro") Is Nothing Then

            MsgBox(WebBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_bltMensagensErro").InnerText, MsgBoxStyle.Exclamation, "Portal Nacional NFe !")

        End If

        ''''''''''''''''''Rotina abaixo para realizar download'''''''''''''''''''''
        If Not WebBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_btnVoltar") Is Nothing Then
            captcha = False

            If par_down = True Then

                If download_site = True Then
                    WebBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_btnDownload").InvokeMember("Click")
                    download_site = True

                End If
            End If


        End If


        '  WebBrowser1.Document.Window.ScrollTo(30, 470)
    End Sub

    Private Sub dfe_Enter(sender As Object, e As EventArgs) Handles dfe.Enter
        Timer_hora.Enabled = True
    End Sub

    Private Sub site_Enter(sender As Object, e As EventArgs) Handles site.Enter

        If My.Computer.Network.IsAvailable = True Then

            Pportal.Visible = False
            If WebBrowser1.Visible = False Then

                If consulta = False Then
                    muda_versao_webbroser()
                    WebBrowser1.ScriptErrorsSuppressed = True
                    WebBrowser1.Navigate("http://www.nfe.fazenda.gov.br/portal")

                End If

            End If

            WebBrowser1.Visible = True
            site.Text = WebBrowser1.DocumentTitle

        Else

            Pportal.Visible = True

        End If


    End Sub

    Private Sub WebBrowser1_ProgressChanged(sender As Object, e As WebBrowserProgressChangedEventArgs) Handles WebBrowser1.ProgressChanged
        Try

            If e.CurrentProgress <= 0 Then
                bar.Visible = False

            Else
                bar.Visible = True
                bar.Maximum = e.MaximumProgress
                bar.Value = e.CurrentProgress


            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvpesquisanfe_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpesquisanfe.CellClick
        If dgvpesquisanfe.CurrentCell.ColumnIndex = 7 Then

            If dgvpesquisanfe.CurrentRow.Cells("situacao_nfe_m").Value.ToString <> "" Then

                Try
                    If dgvpesquisanfe.CurrentRow.Cells("nprot").Value.ToString <> "" Then

                        MsgBox(dgvpesquisanfe.CurrentRow.Cells("situacao_nfe_m").Value & vbCrLf & dgvpesquisanfe.CurrentRow.Cells("nprot").Value & vbCrLf & dgvpesquisanfe.CurrentRow.Cells("data_aut").Value, MsgBoxStyle.Information, "Aviso !")
                    End If
                Catch ex As Exception

                End Try


            End If
        End If
        If dgvpesquisanfe.CurrentCell.ColumnIndex = 0 Then

            If dgvpesquisanfe.CurrentRow.DefaultCellStyle.BackColor = Color.LightCyan Then
                MsgBox("Nota Fiscal não lancada no Sistema !", MsgBoxStyle.Exclamation, "Aviso !")
            End If

            If dgvpesquisanfe.CurrentRow.Cells("situacao_nfe_m").Value.ToString = "Confirmacao da Operacao" Or dgvpesquisanfe.CurrentRow.Cells("situacao_nfe_m").Value.ToString = "Confirmada Operacao" Then
                dgvpesquisanfe.EndEdit()
                dgvpesquisanfe.CurrentRow.Cells(0).Value = False
                MsgBox("A Operação ja foi confirmada, Manifestacao não mais permitida !", MsgBoxStyle.Information, "Aviso !")
            End If

            If dgvpesquisanfe.CurrentRow.Cells("tiponfe").Value = "0-NFe Entrada" Then
                dgvpesquisanfe.EndEdit()
                dgvpesquisanfe.CurrentRow.Cells(0).Value = False
                MsgBox("Nota Fiscal de entrada !", MsgBoxStyle.Information, "Aviso !")
            End If


            Dim cont As Integer = 0

            For i As Integer = 0 To dgvpesquisanfe.Rows.Count - 1
                If dgvpesquisanfe.Rows.Item(i).Cells(0).Value = True Then
                    cont = cont + 1
                End If
            Next

            If cont > 19 Then

                If dgvpesquisanfe.CurrentRow.Cells(0).Value = True Then
                    dgvpesquisanfe.CurrentRow.Cells(0).ReadOnly = False
                Else
                    dgvpesquisanfe.CurrentRow.Cells(0).ReadOnly = True
                    MsgBox("Só é permitido Manifestar (20) Notas Fiscais por Vez !", MsgBoxStyle.Exclamation, "Aviso !")
                End If

                Exit Sub

            End If

            dgvpesquisanfe.CurrentRow.Cells(0).ReadOnly = False

        End If

    End Sub


    Private Sub dgvdferet_SelectionChanged(sender As Object, e As EventArgs) Handles dgvdferet.SelectionChanged

        If dgvdferet.RowCount <> 0 Then
            txtchavedfe.Text = dgvdferet.CurrentRow.Cells("chave_nfe").Value

            txtnsudoc.Text = dgvdferet.CurrentRow.Cells("nsu_doc").Value
        End If

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        mskcnpj_esp.Text = cnpj_cert
    End Sub

    Private Sub dgvdferet_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdferet.CellClick

        If e.ColumnIndex = 0 Then

            If dgvdferet.CurrentRow.Cells(0).Value = "NF-e + xml" Then

                If dgvdferet.CurrentRow.Cells("xml_nfe").Value <> "" Then
                    Dim dialo_salve As New SaveFileDialog
                    dialo_salve.Filter = "Arquivo XML (.xml)|*.xml"
                    dialo_salve.FileName = dgvdferet.CurrentRow.Cells("chave_nfe").Value

                    If dialo_salve.ShowDialog() = Windows.Forms.DialogResult.OK Then

                        Dim Xml_danfe As XmlDocument = New XmlDocument
                        Xml_danfe.LoadXml(dgvdferet.CurrentRow.Cells("xml_nfe").Value)
                        Xml_danfe.Save(dialo_salve.FileName)


                        MsgBox("XML salvo com Sucesso !", MsgBoxStyle.Information, "Aviso !")

                    End If

                End If

            End If

        End If
    End Sub


    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        frmparametro.ShowDialog()
    End Sub

    Private Sub ConsultaNFeDownloadToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frmnfelocal.Text = "Pesquisa Notas fiscais  para Realizar o Download da NF-e"
        frmnfelocal.Show()
    End Sub

    Private Sub PesquisaOneDriveToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frmpesq_onedrive.ShowDialog()
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmnfelocal.ShowDialog()
    End Sub

    Private Sub Button4_MouseWheel(sender As Object, e As MouseEventArgs) Handles Button4.MouseWheel

    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

        If dgvdferet.RowCount = 0 Then
            EventosNFeToolStripMenuItem.Enabled = False
            Exit Sub
        Else
            EventosNFeToolStripMenuItem.Enabled = True
        End If

        If dgvdferet.CurrentRow.Cells("Par_codBarra").Value = "codbarra_invalido" Then
            RejeitarNFeErroEANToolStripMenuItem.Enabled = True
        Else
            RejeitarNFeErroEANToolStripMenuItem.Enabled = False
        End If



    End Sub

    Private Sub RejeitarNFeErroEANToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RejeitarNFeErroEANToolStripMenuItem.Click
        gerar_evento_Recusa_nfe(dgvdferet.CurrentRow.Index, "210240", "Operacao nao Realizada", "Declaro que a Operação não foi Realizada, com Recusa do Recebimento da mercadoria, pois Segundo o § 6º, da cláusula quarta do Ajuste SINIEF 07/2005, e obrigatório o preenchimento dos campos cEAN e cEANTrib da NF-e, e isto nao foi feito pelo emitente.")
    End Sub

    Private Sub VisualizarNFeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizarNFeToolStripMenuItem.Click
        If dgvdferet.RowCount <> 0 Then
            If dgvdferet.CurrentRow.Cells("xml_nfe").Value <> "" Then
                frmxml.abrir_xml(dgvdferet.CurrentRow.Cells("xml_nfe").Value)
            End If
        End If

        frmxml.ShowDialog()
    End Sub

    Private Sub CienciaOperacaoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CienciaOperacaoToolStripMenuItem.Click
        gerar_evento_Recusa_nfe(dgvdferet.CurrentRow.Index, "210210", "Ciencia da Operacao", "")
    End Sub

    Private Sub ConfirmacaoOperacaoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfirmacaoOperacaoToolStripMenuItem.Click
        gerar_evento_Recusa_nfe(dgvdferet.CurrentRow.Index, "210200", "Confirmacao da Operacao", "")
    End Sub

    Private Sub DesconhecimentoDaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesconhecimentoDaToolStripMenuItem.Click
        gerar_evento_Recusa_nfe(dgvdferet.CurrentRow.Index, "210220", "Desconhecimento da Operacao", "")
    End Sub

    Private Sub OperaçãoNãoRealizadaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperaçãoNãoRealizadaToolStripMenuItem.Click
        Dim valor As Object
        valor = InputBox("Informe o Motivo da Não Realização da Operação (Campo Obrigatorio)" & vbCrLf & vbCrLf & vbCrLf & "Exemplo abaixo:", _
                           "Manifestação NF-e", "Declarando que a Operação não foi Realizada, com Recusa do Recebimento da mercadoria.")

        If valor = "" Then
            MsgBox("O campo Motivo deve estar Preenchido ?", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If


        gerar_evento_Recusa_nfe(dgvdferet.CurrentRow.Index, "210240", "Operacao nao Realizada", valor)
    End Sub

    Private Sub VisualizarNFePortalNacionalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizarNFePortalNacionalToolStripMenuItem.Click
        muda_versao_webbroser()
        TabControl1.SelectTab(site)
        WebBrowser1.Navigate("http://www.nfe.fazenda.gov.br/portal/consultaRecaptcha.aspx?tipoConsulta=completa&tipoConteudo=XbSeqxE8pl8=")
        consulta = True
        TabControl1.SelectTab(site)
    End Sub


    Private Sub Button6_MouseUp(sender As Object, e As MouseEventArgs) Handles Button6.MouseUp
        Me.ContextMenuStrip2.Show(TryCast(sender, Control), e.X, e.Y)
    End Sub

    Private Sub consulta_via_chave()
        If cboambdfe.Text = "" Then
            txtinfodfe.Text = "Informe o tipo de Ambiente a ser consultado na Receita Federal"
            cboambdfe.Focus()
            Exit Sub
        End If

        If txtchavedfe.Text = "" Then
            MsgBox("Informe a Chave de acesso da NF-e para Consulta Via (Webservice) ?", MsgBoxStyle.Exclamation, "Aviso !")
            txtchavedfe.Focus()
            Exit Sub
        End If



        txtinfodfe.Text = "Aguarde, Consultando chave acesso informada..."

        '''''''''''''''''''''''''''Ativa a Rotina de Pesquisa dos Documento na receita'''''''''''''''''''
        tipo_processo = "Dfe_cons_chave"
        File.Delete(Application.StartupPath & "\XML\retDistDFeInt.xml")
        Tdfe_status.Enabled = True
        frmwebservice.ambiente = cboambdfe.Text.Substring(0, 1)
        frmwebservice.tipo_processo = tipo_processo
        frmwebservice.ShowDialog()



    End Sub

    Private Sub COnsultaViaSitePortalNFeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles COnsultaViaSitePortalNFeToolStripMenuItem.Click
        If txtchavedfe.Text = "" Then
            MsgBox("Informe a Chave de acesso da NF-e para Consulta Via ( Site Portanl NF-e ) ?", MsgBoxStyle.Exclamation, "Aviso !")
            txtchavedfe.Focus()
            Exit Sub
        End If

        muda_versao_webbroser()
        TabControl1.SelectTab(site)
        WebBrowser1.Navigate("http://www.nfe.fazenda.gov.br/portal/consultaRecaptcha.aspx?tipoConsulta=completa&tipoConteudo=XbSeqxE8pl8=")
        consulta = True

    End Sub

    Private Sub DownloadXMLNoPortalNFeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadXMLNoPortalNFeToolStripMenuItem.Click
        If txtchavedfe.Text = "" Then
            MsgBox("Informe a Chave de acesso da NF-e para Realizar o Download ( Site Portanl NF-e ) ?", MsgBoxStyle.Exclamation, "Aviso !")
            txtchavedfe.Focus()
            Exit Sub
        End If

        muda_versao_webbroser()
        TabControl1.SelectTab(site)
        WebBrowser1.Navigate("http://www.nfe.fazenda.gov.br/portal/consultaRecaptcha.aspx?tipoConsulta=completa&tipoConteudo=XbSeqxE8pl8=")
        consulta = True
        '    TabControl1.SelectTab(site)
        download_site = True
        TabControl1.SelectTab(site)

    End Sub

    Private Sub timer_manif_Tick(sender As Object, e As EventArgs) Handles timer_manif.Tick
        lbltempo.Text += 1

    End Sub

    Private Sub muda_versao_webbroser()
        Dim appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName)
        Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", appName, 11000, Microsoft.Win32.RegistryValueKind.DWord)
    End Sub




    Private Sub carregar_cert()
        If nfecer = "" Then
            busca_certificado()

        Else
            certificado = SelecionarCertificado(nfecer)

            frminfocertificado.ShowDialog()
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        If MessageBox.Show("Deseja Recarregar o Certificado Digital ? ", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            nfecer = ""
            busca_certificado()
        End If

        carregar_cert()
    End Sub


    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        mskdatainicial.Text = Now.Date.AddDays(-NumericUpDown1.Value)
    End Sub

    Private Sub dgvpesquisanfe_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpesquisanfe.CellContentClick

    End Sub

    Private Sub chkdata_Click(sender As Object, e As EventArgs) Handles chkdata.Click
        If chkdata.Checked = True Then
            mskdatainicial.Enabled = True
            mskdatafinal.Enabled = True
        Else
            mskdatainicial.Enabled = False
            mskdatafinal.Enabled = False
        End If
    End Sub


    Private Sub chkstatus_Click(sender As Object, e As EventArgs) Handles chkstatus.Click
        If chkstatus.Checked = True Then
            cbostatus_nfe.Enabled = True
        Else
            cbostatus_nfe.Enabled = False
        End If

    End Sub

    Private Sub chktipo_CheckedChanged(sender As Object, e As EventArgs) Handles chktipo.CheckedChanged

    End Sub

    Private Sub chktipo_Click(sender As Object, e As EventArgs) Handles chktipo.Click
        If chktipo.Checked = True Then
            cbotipo.Enabled = True
        Else
            cbotipo.Enabled = False
        End If
    End Sub

    Private Sub chknome_Click(sender As Object, e As EventArgs) Handles chknome.Click
        If chknome.Checked = True Then
            txtnome_pesq.Enabled = True
            txtnome_pesq.Focus()
        Else
            txtnome_pesq.Enabled = False
        End If
    End Sub

    Private Sub ConsultaViaWebserviceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaViaWebserviceToolStripMenuItem.Click
        consulta_via_chave()
    End Sub

    Private Sub ConsultaChaveViaWebserviceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaChaveViaWebserviceToolStripMenuItem.Click
        consulta_via_chave()
    End Sub

    Private Sub Tcontinuacao_dfe_Tick(sender As Object, e As EventArgs) Handles Tcontinuacao_dfe.Tick
        If Not rotina.IsAlive Then
            '  Tcontinuacao_dfe.Dispose()
            ' continuacao()
        End If
    End Sub


    Private Sub site_Click(sender As Object, e As EventArgs) Handles site.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If lblon.Visible = True Then
            MsgBox("O Servidor já esta ativo !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        '  If cbocert.Text = "" Then
        'MsgBox("Selecione um Certificado Digital para Conexao na SEFAZ ?", MsgBoxStyle.Exclamation, "Aviso !")
        '  cbocert.Focus()
        '  Exit Sub
        '  End If

        ativar_servidor()

        If dgvhost.RowCount <> 0 Then
            dgvhost.CurrentCell = Me.dgvhost.Rows(dgvhost.Rows.Count - 1).Cells(0)
        End If
    End Sub


    Private Sub ativar_servidor()
        Dim baseAddress As String = "http://*:8900"

        If webApp3 IsNot Nothing Then Return
        webApp3 = WebApp.Start(Of Startup)(baseAddress)

        lblon.Visible = True
        picon.Visible = True
        dgvhost.Rows.Add("Servidor esta Online !", Now)
        Timerhost.Enabled = True

        lblof.Visible = False
        picoff.Visible = False
    End Sub

    Public Sub PararServico()
        Try
            If webApp3 Is Nothing Then Return
            webApp3.Dispose()
            webApp3 = CType(Nothing, IDisposable)
            lblon.Visible = False
            picon.Visible = False
            picoff.Visible = True
            lblof.Visible = True

            dgvhost.Rows.Add("Servidor Foi Desconectado !", Now)
            Timerhost.Dispose()

            If dgvhost.RowCount <> 0 Then
                dgvhost.CurrentCell = Me.dgvhost.Rows(dgvhost.Rows.Count - 1).Cells(0)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        frmcert.ShowDialog()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        PararServico()
    End Sub

    Private Sub Timerhost_Tick(sender As Object, e As EventArgs) Handles Timerhost.Tick
        For Each row As DataRow In tabe.Rows
            dgvhost.Rows.Add(row.Item("evento"), row.Item("data"))
        Next
        tabe.Rows.Clear()
        If dgvhost.RowCount <> 0 Then
            dgvhost.CurrentCell = Me.dgvhost.Rows(dgvhost.Rows.Count - 1).Cells(0)
        End If
    End Sub

    Private Sub Timer_status_inter_Tick(sender As Object, e As EventArgs) Handles Timer_status_inter.Tick
        If IsConectedToHost(New Uri("http://www.google.com")) = True Then
            Pic_on_inter.Visible = True
            Pic_off_inter.Visible = False
        Else
            Pic_on_inter.Visible = False
            Pic_off_inter.Visible = True
        End If
    End Sub


   
    Private Sub dgvdferet_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdferet.CellContentClick

    End Sub

    Private Sub cbocert_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbocert.SelectedIndexChanged

    End Sub
End Class