Imports System.Web
Imports System.Xml
Imports System.Text
Imports System.IO
Imports DFe_aplicativo.C_WebService
Imports System.Security.Cryptography.X509Certificates
Imports System.Xml.Linq
Imports System.Threading
Imports System.Data.OleDb

Public Class frmnfelocal
    Dim chave As String
    Dim rotina_dfe As Thread
    Dim manifesto_tipo As Boolean
    Dim xmlnfe As String, xmlnferodape As String, xmlversao As String, emitente As String
    Dim rotina1 As Thread, rotina2 As Thread
    Dim xmldoc As New XmlDocument()
    Dim xmlnsManager As New XmlNamespaceManager(xmldoc.NameTable)
    Dim statusnfe As String
    Dim certificado As X509Certificate2
    Dim xmlAssinado As XmlDocument
    Dim data As Date
    Dim WebS As New C_WebService
    Dim retorevento As New RetRetorno
    Dim dataenv As String, sqlconsulta As String, sqlopt As String, tabelaconsulta As String
    Dim rsconsulta As New ADODB.Recordset
    Dim rssefaz As New ADODB.Recordset

    Private Sub consultar()
        Dim chave_xml As String
        Dim xml As String = ""

        Dim datai As Date = mskdatainicial.Text
        Dim dataf As Date = mskdatafinal.Text
        dgvnotas.Rows.Clear()
        '    conectar_base("sefaz")


        lblpar.Text = "e"

        ''''''''''''''''''''''''''''Tira os espacos vazios que separam a chave de acesso da NFe'''''''''''''''''''''''''''''''
        If txtpar.Text = "Numero_NFe" Then
            mskpesquisa.Text = mskpesquisa.Text.PadLeft(9, "0")

            If chknumero_ap.Checked = True Then
                sqlconsulta = "select * from " & tabelaconsulta & " where " & txtpar.Text & " like '%" & mskpesquisa.Text & "%'"
            Else
                sqlconsulta = "select * from " & tabelaconsulta & " where " & txtpar.Text & " = '" & mskpesquisa.Text & "'"
            End If

        End If

        If txtpar.Text = "chave_nfe" Or txtpar.Text = "cnpj_Emi" Or txtpar.Text = "Valor NFe" Then
            sqlconsulta = "select * from " & tabelaconsulta & " where " & txtpar.Text & " = '" & mskpesquisa.Text & "'"
        End If

        If txtpar.Text = "Nome do Fornecedor" Then
            sqlconsulta = "select * from " & tabelaconsulta & " where " & txtpar.Text & " like '%" & mskpesquisa.Text & "%'"
        End If

       
        ''''''''''''''''''''''''''''Acrescenta Filtros na pesquisa da NFe'''''''''''''''''''''''''''''''
        If chkstatus.Checked = True Then
            sqlconsulta = sqlconsulta + "and status_nfe like '" & cbostatusnfe.Text & "'"
        End If

        If chkdata.Checked = True Then
            sqlconsulta = sqlconsulta + "and data_Emissao BETWEEN #" & datai.ToString("yyyy-MM-dd") & "# AND #" & dataf.ToString("yyyy-MM-dd") & "#"
        End If

        If chksit.Checked = True Then
            If cbomanifestacao.Text = "Ciencia da Operacao" Then
                sqlconsulta = sqlconsulta + " and (situacao_nfe like '" & cbomanifestacao.Text & "' or situacao_nfe is null)"
            Else
                sqlconsulta = sqlconsulta + " and situacao_nfe like '" & cbomanifestacao.Text & "'"
            End If

        End If

        ''''''''''''''''''''''''''''''''''''''''Chama a Rotina com a Condição SQL ja montada''''''''''''''''''''''''''''''''''''''''''

        If chknfeincompleta.Checked = True Then
            sqlconsulta = "select * from NFe_consultadaDFe where Nome_emi is null"
        End If

        If mskcnpj_esp.Text <> "" Then
            If mskcnpj_esp.Text.Length = 14 Then
                sqlconsulta = sqlconsulta + "and cnpj_dest = '" & mskcnpj_esp.Text & "'"
            End If
        End If

            ''''''''''''''''''''''Rotina de nova conexao ADO.net''''''''''''''''''''''''''''''''''''''''''

        '   Try



        conectar_ado()

        Dim da As New OleDbDataAdapter()
        da.SelectCommand = New OleDbCommand(sqlconsulta, cnado)

        Dim dtp As New DataTable()
        da.Fill(dtp)


        If dtp.Rows.Count = "0" Then

            If chkdata.Checked = True Then
                MsgBox("Não foi Localizado Notas Fiscal para este Fornecedor entre a Data de: " & mskdatainicial.Text + " a " & mskdatafinal.Text, MsgBoxStyle.Exclamation, "Aviso !")
            Else
                MsgBox("Não foi Localizado Notas Fiscal Para este Fornecedor", MsgBoxStyle.Exclamation, "Aviso !")
            End If

        End If



        For Each row As DataRow In dtp.Rows


            If row.Item("data_consulta").ToString <> "" Then

                data = row.Item("Data_consulta")
            Else
                data = Now.Date
            End If


            If row.Item("Nome_emi").ToString <> "" Then
                emitente = row.Item("Nome_emi")
            Else
                emitente = "Nota Fiscal Não recebida no Ambiente Nacional"
            End If

            If row.Item("XML_NFe").ToString <> "" Then

                Dim bytePicData As Byte()
                bytePicData = row.Item("XML_NFe")
                xmldoc.LoadXml(Encoding.UTF8.GetString(bytePicData))

                xml = "SIM"

                Dim xmllist2 As System.Xml.XmlNodeList

                Dim dataprot As Date

                xmllist2 = xmldoc.GetElementsByTagName("infProt")

                For Each xmlnode2 In xmllist2
                    If Not xmlnode2("chNFe") Is Nothing Then
                        chave_xml = xmlnode2("chNFe").InnerText
                    End If
                Next

            End If


            dgvnotas.Invoke(DirectCast(Function() dgvnotas.Rows.Add(False, emitente, row.Item("chave_nfe").Substring(25, 9), data.ToString("dd/MM/yyyy"), _
                             row.Item("Valor_nfe"), row.Item("chave_nfe"), row.Item("situacao_nfe"), row.Item("Tipo_nf"), _
                            row.Item("CNPJ_Dest"), row.Item("IE_emi"), xmldoc.OuterXml, chave_xml, "", xml), MethodInvoker))

        Next row

        cnado.Close()



        ' data_download()

        lblinfo.Visible = False
        lblpar.Text = "l"
        chknfeincompleta.Checked = False


        '  Catch ex As Exception
        'cnado.Close()
        '  End Try
    End Sub

    Private Sub frmnfelocal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub frmnfelocal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbomanifestacao.SelectedIndex = 2
        cbotipo.Text = "Nome do Fornecedor"
        mskdatainicial.Text = Now.ToString("01/MM/yyyy")
        cbostatusnfe.Text = "NF-e Autorizada"


        tabelaconsulta = "NFe_consultadaDFe"

    End Sub

    Private Sub mskpesquisa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskpesquisa.Click
        mskpesquisa.SelectAll()
    End Sub

    Private Sub mskpesquisa_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskpesquisa.GotFocus
        mskpesquisa.SelectAll()
    End Sub

    Private Sub mskpesquisa_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskpesquisa.LostFocus
        If cbotipo.Text = "Valor NFe" Then
            mskpesquisa.Text = Format(CDec(mskpesquisa.Text), "###0.00")
        End If

    End Sub

    Private Sub dgvnotas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvnotas.CellClick
        If e.ColumnIndex = 12 Then

            If dgvnotas.CurrentRow.Cells("xml").Value = "SIM" Then
                baiar_xml_grid()
            End If

        End If
    End Sub

    Private Sub dgvnotas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvnotas.CellContentClick

        ''''''''''''''''''''''''''''''''Rotina para manifestar outra formas'''''''''''''''''''''

        If dgvnotas.CurrentCell.ColumnIndex = 0 Then

            dgvnotas.EndEdit()


            Dim cont As Integer

            For i As Integer = 0 To dgvnotas.Rows.Count - 1

                If dgvnotas.Rows.Item(i).Cells(0).Value = True Then

                    cont += 1

                End If

            Next

            If chkdownload.Checked = False Then

                If cont > 20 Then
                    MsgBox("Só é permitido Manifestar 20 Notas Fiscais por Vez !", MsgBoxStyle.Exclamation, "Aviso !")
                    dgvnotas.CurrentRow.Cells(0).Value = False
                End If


            End If

        End If
        ''''''''''''''''''''''''''''''''''''###################'''''''''''''''''''''''''''''
        Exit Sub






            If dgvnotas.CurrentCell.Value = "Indisponivel" Then
                MsgBox("A Data limite para Download de 30 dias foi excedida !", MsgBoxStyle.Exclamation, "Aviso !")
                MsgBox("Seu Download foi Direcionado para o Porta Naciona da NFe", MsgBoxStyle.Information, "Aviso !")
                frmdownloadnfe.txtchave.Text = dgvnotas.CurrentRow.Cells(5).Value
                frmdownloadnfe.txtchave.Enabled = False
                frmdownloadnfe.bntnovaconsulta.Visible = False
                frmdownloadnfe.Show()
            End If


    End Sub

    Private Sub mskpesquisa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mskpesquisa.KeyPress
        If (e.KeyChar = Chr(13)) Then

            If lblpar.Text = "e" Then
                MsgBox("Consulta em Execução, aguarde ...", MsgBoxStyle.Exclamation, "Aviso !")
            Else

                lblinfo.Visible = True
                lblinfo.Refresh()

                Dim rotina As Thread
                Control.CheckForIllegalCrossThreadCalls = False
                rotina = New Thread(AddressOf consultar)
                rotina.SetApartmentState(ApartmentState.STA)
                rotina.Start()
            End If

        End If
    End Sub




    Private Sub busca_ret()

        Dim xmlretcanc = New XmlDocument()


        txtinfo.Text = "Aguarde, Realizando a Consulta de Autenticidade da NF-e Na SEFAZ MG"
        txtinfo.Refresh()


        'chama a rotina para consulta nfe no sefaz mg
        Dim WebS As New C_WebService
        Dim retornonfe As New RetRetorno

        If mskchavemg.Visible = True Then
            '   retornonfe = WebS.ConsultaStatusNfe2(mskchavemg.Text.Replace(" ", ""))
        Else
            '  retornonfe = WebS.ConsultaStatusNfe2(dgvnotas.CurrentRow.Cells(5).Value)
        End If


        If retornonfe.cStat <> "100" Then

            If retornonfe.cStat <> "1010" Then
                MsgBox(retornonfe.xMotivo, MsgBoxStyle.Information, "Retorno do Sefaz")
                frminfo.Close()
                tconsultanfe.Dispose()
            End If

        End If



        If retornonfe.cStat = "100" Or retornonfe.cStat = "101" Then
            '''''''''''''''''''''''Rotina abaixo monta o xml recebido da SEFAZ MG''''''''''''''''

            pega_retconsulta()

            Dim vStringNfe As String = String.Empty
            vStringNfe += "<?xml version=""1.0"" encoding=""utf-8""?>"
            vStringNfe += "<nfeProc versao=""" & xmlversao & """ xmlns=""http://www.portalfiscal.inf.br/nfe"">"
            vStringNfe += xmlnfe
            ' vStringNfe += "<protNFe versao=""" & xmlversao & """>"
            vStringNfe += xmlnferodape
            '  vStringNfe += "</protNFe>"
            vStringNfe += "</nfeProc>"

            xmldoc.LoadXml(vStringNfe)

            frminfo.Close()
            pinfo.Visible = False

            Dim SaveFileDialog2 As New SaveFileDialog
            SaveFileDialog2.Filter = "Arquivo XML (*.xml*)|*.xml"

            If mskchavemg.Visible = True Then
                SaveFileDialog2.FileName = mskchavemg.Text.Replace(" ", "") + ".xml"
            Else
                SaveFileDialog2.FileName = dgvnotas.CurrentRow.Cells("chave_nfe").Value + ".xml"
            End If


            If chkpasta.Checked = False Then

                If SaveFileDialog2.ShowDialog = Windows.Forms.DialogResult.OK Then
                    xmldoc.Save(SaveFileDialog2.FileName)
                    '   MsgBox("Download Realizado com Sucesso !", MsgBoxStyle.Information, "Aviso !")
                End If

            Else

                Dim cxmlnfe As String = lerINI(Application.StartupPath & "\config.ini", "DFe", "caminho_salvarxmlnfe")


                ''''''''''''''''''''''''''''''''''''''''''Pega dados do xml abaixo'''''''''''''


                Dim xmllist2 As System.Xml.XmlNodeList

                Dim dataprot As Date

                xmllist2 = xmldoc.GetElementsByTagName("infProt")

                For Each xmlnode2 In xmllist2

                    If Not xmlnode2("dhRecbto") Is Nothing Then
                        dataprot = xmlnode2("dhRecbto").InnerText

                    End If
                    If Not xmlnode2("chNFe") Is Nothing Then
                        chave = xmlnode2("chNFe").InnerText
                    End If
                Next




                If Directory.Exists(cxmlnfe + "\" + dataprot.ToString("dd-MM-yyyy")) = False Then
                    Directory.CreateDirectory(cxmlnfe + "\" + dataprot.ToString("dd-MM-yyyy"))
                End If

                xmldoc.Save(cxmlnfe + "\" + dataprot.ToString("dd-MM-yyyy") + "\" & dgvnotas.CurrentRow.Cells("chave_nfe").Value + ".xml")

            End If



            '''''''''''''''''''''''''''''''''''''''''''''######################'''''''''''''''''''''''''
        End If


    End Sub

    Public Function Separarxmlnfe_corrompido(ByVal vNfeDadosMsg As String) As String

        Try
            Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<infNFe")
            Dim nPosF As Int32 = vNfeDadosMsg.IndexOf("</infNFe")

            Dim vStringNfe As String = vNfeDadosMsg.Substring(nPosI, nPosF - nPosI)

            Return vStringNfe
        Catch ex As Exception
            Return "erro"
        End Try
    End Function

    Public Function Separarxml(ByVal vNfeDadosMsg As String) As String
        Try
            Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<NFe")
            Dim nPosF As Int32 = vNfeDadosMsg.IndexOf("<protNFe")

            Dim vStringNfe As String = vNfeDadosMsg.Substring(nPosI, nPosF - nPosI)

            Return vStringNfe
        Catch ex As Exception
            Return "erro"
        End Try
    End Function

   

    Private Sub cbotipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbotipo.SelectedIndexChanged
        If cbotipo.Text = "Nome do Fornecedor" Then
            mskpesquisa.Visible = True
            mskpesquisa.Width = 376
            mskpesquisa.Mask = ""
            txtpar.Text = "Nome_emi"
            chknumero_ap.Visible = False
        End If

        If cbotipo.Text = "CNPJ Fornecedor" Then
            mskpesquisa.Visible = True
            mskpesquisa.Width = 122
            mskpesquisa.Mask = "00000000000000"
            txtpar.Text = "cnpj_Emi"
            chknumero_ap.Visible = False
        End If

        If cbotipo.Text = "Valor NFe" Then
            mskpesquisa.Visible = True
            mskpesquisa.Width = 90
            mskpesquisa.Mask = ""
            txtpar.Text = "Valor_nfe"
            chknumero_ap.Visible = False
        End If

        If cbotipo.Text = "Numero NFe" Then
            mskpesquisa.Visible = True
            mskpesquisa.Width = 90
            mskpesquisa.Mask = ""
            txtpar.Text = "Numero_NFe"
            chknumero_ap.Visible = True
        End If

        If cbotipo.Text = "Chave de Acesso NFe" Then
            mskpesquisa.Visible = True
            mskpesquisa.Width = 324
            mskpesquisa.Mask = "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000"
            txtpar.Text = "chave_nfe"
            chknumero_ap.Visible = False
        End If
    End Sub


    ''' <summary>
    ''' ''''''''''''''''Manifestação de apenas um Nota Fiscal''''''''
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub xmlevento()

        Dim xmlevento = New XmlDocument()
        Dim manifestacao As New NFe()

        manifestacao.versao = "1.00"

        manifestacao.Id = txtcodevento.Text + dgvnotas.CurrentRow.Cells("chave_nfe").Value + "01"
        manifestacao.chave = dgvnotas.CurrentRow.Cells("chave_nfe").Value
       
        manifestacao.coduf = "91"
        manifestacao.cnpj = cnpj_cert
        manifestacao.dataenv = dataenv
        manifestacao.codenv = txtcodevento.Text
        manifestacao.descenv = cbomanifestar.Text
        manifestacao.tpAmb = "1"



        If cbomanifestar.Text = "Operacao nao Realizada" Then
            manifestacao.xJust = txtjust.Text
        End If

        Dim xmldoc As XmlDocument = manifestacao.Gerarmanifestacaodest()

        ' xmldoc.Save(Application.StartupPath & "\XML\manifestacaoNaoAssinado.xml")
        If nfecer = "" Then
            certificado = CertificadoDigital.SelecionarCertificado("")
        Else
            certificado = CertificadoDigital.SelecionarCertificado(nfecer)
        End If

        'assina os xml selecionados
        xmlAssinado = CertificadoDigital.Assinar(xmldoc, "infEvento", certificado)
        '    xmlAssinado.Save(Application.StartupPath + "\XML\eventociencia.xml")


        ''captura o ultimo lote
        conectar_DFe()
        Dim rsultlote As New ADODB.Recordset
        rsultlote.Open("select * from NSU where CNPJ_emp = '" & cnpj_cert & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        Dim nNumeroLote As Int32 = 1
        nNumeroLote = Convert.ToInt32(rsultlote.Fields("Lote_env").Value) + 1
        rsultlote.Close()

        '''''''''''salva o ultimo lote'''''''''''''''''''''''''''
        Dim rslote As New ADODB.Recordset
        rslote.Open("select * from NSU where CNPJ_emp = '" & cnpj_cert & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        rslote.Fields("Lote_env").Value = nNumeroLote.ToString("000000000000000")
        rslote.Update()
        rslote.Close()
        cn_DFe.Close()
        '''''''''''''''''''''''''''''''''''''''''''''FECHA GERAÇÃO DE LOTE''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '''''''''''''''''''''''''''''''''''''''''''''''''''' GERA O ARQUIVO XML DA MANIFESTAÇÃO''''''''''''''''''''''''''''''''''
        xmlevento.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><envEvento versao=""1.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><idLote>" & nNumeroLote.ToString("000000000000000") & "</idLote>" & xmlAssinado.OuterXml & "</envEvento>")
        '  xmlevento.Save(Application.StartupPath & "\XML\evento.xml")

        'Valida o XML assinado
        Dim resultado As String = ValidaXML.ValidarXML(xmlevento, Application.StartupPath & "\Esquemas_XML_NF-e\envConfRecebto_v1.00.xsd")

        If resultado.Trim().Length <> 0 Then
            MsgBox(resultado)
            ' resultado = "Xml gerado com sucesso, nenhum erro encontrado"
            Exit Sub
        End If

        Using xmltw As New XmlTextWriter(Application.StartupPath & "\XML\evento_nfe.xml", New UTF8Encoding(False))
            xmlevento.WriteTo(xmltw)
            xmltw.Close()
        End Using

        pinfo.Visible = True
        txtinfo.Text = "Aguarde, o sistema está realizando a manifestação de " & cbomanifestar.Text & ", aguarde ..."

        Control.CheckForIllegalCrossThreadCalls = False
        rotina1 = New Thread(AddressOf manifestanfe)
        rotina1.Start()

    End Sub

    Private Sub manifestanfe()
        ' urlevento = "https://www.nfe.fazenda.gov.br/RecepcaoEvento/RecepcaoEvento.asmx"
        Dim xmlretcanc = New XmlDocument()
        Dim ret As String
        'função envia o xml para receita''''''''''''''''''''''''''''''''''
        retorevento = WebS.nfeRecepcaoEvento4(Application.StartupPath & "\XML\evento_nfe.xml")

        If retorevento.cStat = "128" Then
            conectar_DFe()
            For Each RetC In retorevento.L_Retornos

                MsgBox(RetC.xMotivo1, MsgBoxStyle.Information, "Retorno SEFAZ:")

                If RetC.xMotivo1 = "Evento registrado e vinculado a NF-e" Or RetC.xMotivo1 = "Evento registrado, mas não vinculado a NF-e" Then
                    rssefaz.Open("select * from NFe_consultadaDFe where chave_nfe like '" & RetC.chNFe & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                    rssefaz.Fields("protocolo_NFe").Value = RetC.nProt
                    rssefaz.Fields("protocolo_ciencia").Value = RetC.nProt
                    rssefaz.Fields("situacao_nfe").Value = RetC.xEvento
                    rssefaz.Update()
                    rssefaz.Close()

                    ret = RetC.xEvento
                    If cbomanifestar.Text = "Ciencia da Operacao" Then
                        dgvnotas.CurrentRow.Cells(6).Value = "Ciencia da Operacao"
                    Else
                        dgvnotas.CurrentRow.Cells(6).Value = RetC.xEvento
                    End If


                End If

            Next
            cn_DFe.Close()

           End If

        If retorevento.cStat <> "128" Then
            MsgBox("Retorno do Sefaz: " & retorevento.xMotivo, MsgBoxStyle.Information, "Retorno do Sefaz:")
            pinfo.Visible = False
            Exit Sub
        End If

    End Sub

    ''' <summary>
    ''' ''''''''''''''''Manifestação de ate 20 Notas Nota Fiscal''''''''
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub gerar_manifestacao()

        Dim xml As String
        Dim xmlevento = New XmlDocument()
        Dim manifestacao As New NFe()


        If horaverao = True Then
            dataenv = Now.ToString("yyyy-MM-ddTHH:mm:ss") + "-02:00"
        Else
            dataenv = Now.ToString("yyyy-MM-ddTHH:mm:ss") + "-03:00"
        End If


        For i As Integer = "0" To dgvnotas.Rows.Count - 1
            If dgvnotas.Rows.Item(i).Cells(0).Value = True Then

                manifestacao.versao = "1.00"
                manifestacao.Id = txtcodevento.Text + dgvnotas.Rows.Item(i).Cells("chave_nfe").Value + "01"
                manifestacao.chave = dgvnotas.Rows.Item(i).Cells("chave_nfe").Value
                manifestacao.coduf = "91"
                manifestacao.cnpj = cnpj_cert
                manifestacao.dataenv = dataenv
                manifestacao.codenv = txtcodevento.Text
                manifestacao.descenv = cbomanifestar.Text
                manifestacao.tpAmb = "1"

                If cbomanifestar.Text = "Operacao nao Realizada" Then
                    manifestacao.xJust = txtjust.Text
                End If

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

        '''''''''''''''''CRIAR E GERA LOTE DOS EVENTOS''''''''''''''''''''''''''''''''''''''''''''''''''

        ''captura o ultimo lote
        conectar_DFe()
        Dim rsultlote As New ADODB.Recordset
        rsultlote.Open("select * from NSU where CNPJ_emp = '" & cnpj_cert & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        Dim nNumeroLote As Int32 = 1
        nNumeroLote = Convert.ToInt32(rsultlote.Fields("Lote_Env").Value) + 1
        rsultlote.Close()

        '''''''''''salva o ultimo lote'''''''''''''''''''''''''''
        Dim rslote As New ADODB.Recordset
        rslote.Open("select * from NSU where CNPJ_emp = '" & cnpj_cert & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        rslote.Fields("Lote_Env").Value = nNumeroLote.ToString("000000000000000")
        rslote.Update()
        rslote.Close()
        cn_DFe.Close()
        '''''''''''''''''''''''''''''''''''''''''''''FECHA GERAÇÃO DE LOTE''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '''''''''''''''''''''''''''''''''''''''''''''''''''' GERA O ARQUIVO XML DA MANIFESTAÇÃO''''''''''''''''''''''''''''''''''
        xmlevento.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><envEvento versao=""1.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><idLote>" & nNumeroLote.ToString("000000000000000") & "</idLote>" & xml & "</envEvento>")
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

        pinfo.Visible = True
        txtinfo.Text = "Aguarde, o sistema está realizando a manifestação de " & cbomanifestar.Text & ", aguarde ..."

        Control.CheckForIllegalCrossThreadCalls = False
        rotina1 = New Thread(AddressOf envia_manifestacao)
        rotina1.Start()
    End Sub

    Private Sub envia_manifestacao()

        ' urlevento = "https://www.nfe.fazenda.gov.br/RecepcaoEvento/RecepcaoEvento.asmx"
        Dim xmlretcanc = New XmlDocument()

        Try

            '''''''''''BUSCA URL do webservice''''''''''''
            WebS.url_webservice(BuscaURL("AN31", 1, False, ""))

            'função envia o xml para receita''''''''''''''''''''''''''''''''''
            retorevento = WebS.nfeRecepcaoEvento4(Application.StartupPath & "\XML\evento.xml")

            If retorevento.cStat <> "128" Then
                MsgBox(retorevento.xMotivo, MsgBoxStyle.Information, "Retorno SEFAZ Nacional:")
                pinfo.Visible = False
                Exit Sub
            End If


            If retorevento.cStat = "128" Then

                frmretmanifest.Label2.Text = "Retorno Da SEFAZ das NFe Enviadas para Manifestação"

                For Each RetC In retorevento.L_Retornos
                    txtinfo.Text = "Recebendo o Retorno EFAZ da manifestação de " & cbomanifestar.Text & ", aguarde ..."
                    ''''''''''''''''Rotina abaixo para evento desconhecimento da operação com retorno de nfe ja cancelada'''''''''''''''''


                    If RetC.cStat1 = "651" Then


                        conectar_ado()

                        Dim cmd As OleDbCommand = cnado.CreateCommand

                        cmd.CommandText = "update NFe_consultadaDFe set situacao_nfe = 'NFe Cancelada' where chave_nfe = '" & RetC.chNFe & "'"

                        cmd.ExecuteNonQuery()

                        cnado.Close()

                    End If

                    If RetC.cStat1 = "135" Or RetC.cStat1 = "136" Or RetC.cStat1 = "596" Or RetC.cStat1 = "573" Then

                        conectar_ado()

                        Dim cmd As OleDbCommand = cnado.CreateCommand

                        cmd.CommandText = "update NFe_consultadaDFe set situacao_nfe = '" & RetC.xEvento & "', protocolo_NFe = = '" & RetC.nProt & "' where chave_nfe = '" & RetC.chNFe & "'"

                        cmd.ExecuteNonQuery()

                        cnado.Close()

                    End If





                    frmretmanifest.dgvsefaz.Rows.Add(RetC.chNFe, RetC.xMotivo1, RetC.nProt, RetC.xEvento, RetC.cStat1)

                    '''''''''''''''''Pesquisa e passa o retorno para grid de manifestacao'''
                    Dim result As String = getDataGridViewIndex(RetC.chNFe)

                    If RetC.cStat1 = "135" Or RetC.cStat1 = "136" Then
                        dgvnotas.Rows.Item(result).Cells("sit_nfe").Value = RetC.xEvento

                        dgvnotas.Rows.Item(result).Cells("sit_nfe").Style.BackColor = Color.LightGreen
                    Else
                        dgvnotas.Rows.Item(result).Cells("sit_nfe").Value = RetC.xMotivo1

                        dgvnotas.Rows.Item(result).Cells("sit_nfe").Style.ForeColor = Color.White
                        dgvnotas.Rows.Item(result).Cells("sit_nfe").Style.BackColor = Color.DarkRed
                    End If

                    dgvnotas.Rows.Item(result).Cells(0).Value = False



                Next


                pinfo.Visible = False

                frmretmanifest.Height = 342
                frmretmanifest.ShowDialog()

            End If

        Catch ex As Exception

            pinfo.Visible = False
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Retorno SEFAZ Nacional")
        End Try
    End Sub

   

   Private Sub salva_xml_nfe()


        xmldoc.Load(Application.StartupPath & "\XML\Retdownload.xml")
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode
        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist = xmldoc.SelectNodes("//bk:retNFe", xmlnsManager)

        For Each xmlnode In xmllist
            Dim xmlnfe As String
            '  MsgBox(xmlnode("xMotivo").InnerText)

            For Each InnerNode2 As XmlNode In xmlnode.ChildNodes
                If InnerNode2.Name = "procNFe" Then

                    For Each InnerNode3 As XmlNode In InnerNode2.ChildNodes
                        If InnerNode3.Name = "nfeProc" Then
                            xmlnfe = InnerNode3.OuterXml

                        End If

                    Next
                End If

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''##############################'''''''''''''''''''''''''''''''''''''''



            ''''''''''''''''''''''''''''''''''''''''''Pega dados do xml abaixo'''''''''''''

            If xmlnfe <> "" Then


                xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & xmlnfe & "")

                Dim xmllist2 As System.Xml.XmlNodeList

                Dim dataprot As Date

                xmllist2 = xmldoc.GetElementsByTagName("infProt")

                For Each xmlnode2 In xmllist2

                    If Not xmlnode2("dhRecbto") Is Nothing Then
                        dataprot = xmlnode2("dhRecbto").InnerText

                    End If
                    If Not xmlnode2("chNFe") Is Nothing Then
                        chave = xmlnode2("chNFe").InnerText
                    End If
                Next




                ''''''''''''''''''''''''''''#####################'''''''''''''''''''''''

                Dim result As String = getDataGridViewIndex(chave)
                dgvnotas.Rows.Item(result).Cells("xml_nfe").Value = xmldoc.OuterXml
                dgvnotas.CurrentRow.Cells("nferef").Value = chave

                If dgvnotas.Rows.Count <> "0" Then
                    dgvnotas.CurrentRow.Cells("xml").Value = "SIM"
                End If

                Dim cxmlnfe As String = lerINI(Application.StartupPath & "\config_DFe.ini", "DFe", "caminho_xmlnfe")
                '  Dim dataprot As Date = dgvnotas.Rows.Item(result).Cells("data_auto").Value

                If Directory.Exists(cxmlnfe + "\" + dataprot.ToString("dd-MM-yyyy")) = False Then
                    Directory.CreateDirectory(cxmlnfe + "\" + dataprot.ToString("dd-MM-yyyy"))
                End If



                xmldoc.Save(cxmlnfe + "\" + dataprot.ToString("dd-MM-yyyy") + "\" & chave + ".xml")

            End If


            frmretdowload.dgvarquivos.Rows.Add(xmlnode("chNFe").InnerText, xmlnode("xMotivo").InnerText, "", xmlnfe)


            xmlnfe = ""

        Next


        frmretdowload.ShowDialog()
        frmretdowload.Text = "Retorno do sefaz P/Pedido de Download"
    End Sub






    Private Function getDataGridViewIndex(ByVal id As String) As String

        For Each row As DataGridViewRow In Me.dgvnotas.Rows

            If Not row.IsNewRow Then
                If row.Cells(5).Value = id Then
                    Return row.Index
                End If
            End If

        Next

        Return 0

    End Function

    Private Sub cbostatusnfe_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbostatusnfe.SelectedIndexChanged
        statusnfe = cbostatusnfe.Text
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If SaveFileDialog2.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub data_download()
        For i As Integer = 0 To dgvnotas.Rows.Count - 1
            If dgvnotas.Rows.Item(i).Cells("download").Value.ToString = "" Then

                Dim datanota As Date = dgvnotas.Rows.Item(i).Cells(3).Value

                If datanota.AddDays("30").Date >= Now.Date Then
                    dgvnotas.Rows.Item(i).Cells(7).Value = "Download XML"
                Else
                    dgvnotas.Rows.Item(i).Cells(7).Value = "Indisponivel"
                End If

            End If
        Next
    End Sub

    Private Sub salva_xml()
        Dim xmldocret As New XmlDocument()
        xmldoc.Load(Application.StartupPath & "\XML\Retdownload.xml")
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode
        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist = xmldoc.SelectNodes("//bk:retNFe", xmlnsManager)

        For Each xmlnode In xmllist
            Dim xmlnfe As String
            '  MsgBox(xmlnode("xMotivo").InnerText)

            For Each InnerNode2 As XmlNode In xmlnode.ChildNodes
                If InnerNode2.Name = "procNFe" Then

                    For Each InnerNode3 As XmlNode In InnerNode2.ChildNodes
                        If InnerNode3.Name = "nfeProc" Then
                            xmlnfe = InnerNode3.OuterXml
                        End If

                    Next
                End If

            Next
            xmldocret.LoadXml(xmlnfe)

            SaveFileDialog1.FileName = xmlnode("chNFe").InnerText + ".xml"
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                xmldocret.Save(SaveFileDialog1.FileName)
                MsgBox("Download do XML Recuperado !" & vbCrLf & "Chave de acesso da Nota Recuperada: " & xmlnode("chNFe").InnerText, MsgBoxStyle.Information, "Aviso !")
            End If
            xmlnfe = ""
        Next


    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If chkdownload.Checked = False Then
            salva_xml()
        Else
            salva_xml_nfe()
        End If
    End Sub


    Private Sub chksit_CheckedChanged(sender As Object, e As EventArgs) Handles chksit.CheckedChanged
        If chksit.Checked = True Then

            cbomanifestacao.Enabled = True
        Else

            cbomanifestacao.Enabled = False
        End If
    End Sub

    Private Sub chkdata_CheckedChanged(sender As Object, e As EventArgs) Handles chkdata.CheckedChanged
        If chkdata.Checked = True Then

            mskdatainicial.Enabled = True
            mskdatafinal.Enabled = True
        Else

            mskdatainicial.Enabled = False
            mskdatafinal.Enabled = False
        End If
    End Sub

    Private Sub chkstatus_CheckedChanged(sender As Object, e As EventArgs) Handles chkstatus.CheckedChanged
        If chkstatus.Checked = True Then
            cbostatusnfe.Enabled = True
        Else
            cbostatusnfe.Enabled = False
        End If
    End Sub

   
   

    Private Sub pega_retconsulta()
        Dim xmlret = New XmlDocument()
        xmlret.Load(Application.StartupPath & "\XML\Retorno_consultaNFe.xml")

        Dim datadest As Date, dataprot As Date

        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode
        Dim xmlnode1 As System.Xml.XmlNode
        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist = xmlret.SelectNodes("//bk:retConsSitNFe", xmlnsManager)

        For Each xmlnode In xmllist
            For Each xmlnode1 In xmlnode

                If xmlnode1.Name = "protNFe" Then
                    xmlversao = xmlnode1.Attributes.ItemOf(0).Value
                    xmlnferodape = xmlnode1.OuterXml
                End If

            Next
        Next
    End Sub

    Private Sub bntcancela_Click(sender As Object, e As EventArgs) Handles bntcancela.Click
        pinfo.Visible = False
        pinfo.Height = 123

    End Sub

    Private Sub bntdownloadmg_Click(sender As Object, e As EventArgs) Handles bntdownloadmg.Click

    End Sub

    Private Function validachavenfe(ByVal chave As String)

        'Pausa para explicação
        'Dim Vetor(4) As Integer Define um array com 5 elementos iniciados com zero
        'Dim Vetor As Integer = new Integer(4) {} Define um array com 5 elementos iniciados com zero
        'Dim Vetor() As Integer = {1, 2, 3, 4, 5} Define um array com 5 elementos e atribui valores a cada elemento
        'Dim Vetor As Integer = new Integer(4) { 0, 1, 2, 3, 4} Define um array com 5 elementos e atribui valores a cada elemento
        'Redim Vetor(10) Redimensiona o array Vetor para 11 elementos
        'ReDim Preserve Vetor(10) Redimensiona o array Vetor para 11 elementos


        'Vetor que irá receber os dígitos da chave
        Dim Numero(42) As Integer

        'Vetor com o peso de cada um dos dígitos
        Dim pesos() As Integer = {4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2}

        Dim soma As Integer = 0

        Dim i As Integer

        Dim resultado1 As Integer

        'Atribuindo ao vetor cada valor da chave até o indice 43.

        For i = 0 To Numero.Length - 1
            Numero(i) = CInt(chave.Substring(i, 1))
        Next

        'Multiplica os valors da chave pelo seu peso e soma o resultado.

        For i = 0 To Numero.Length - 1
            soma = soma + (Numero(i) * pesos(i))
        Next

        'Efetua o resto da divisão

        soma = soma - (11 * (Int(soma / 11)))

        'Como regra da validação se o resultado for 0 ou 1 o digito verificador tem que ser igual a 0

        If soma = 0 Or soma = 1 Then
            resultado1 = 0
        Else
            'Se for maior que 1 tem que diminuir de 11;
            resultado1 = 11 - soma
        End If


        'Verifica se o resultado é igual ao ultimo digito e retorna true ou false

        If resultado1 = CInt(chave.Substring(43, 1)) Then
            Return True
        Else
            Return False
        End If

        'Fim da Função
    End Function

  Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        lblinfo.Visible = True
        lblinfo.Refresh()
        chknfeincompleta.Checked = True
        consultar()

        lblinfo.Visible = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbomanifestar.SelectedIndexChanged
        If cbomanifestar.Text = "Confirmacao da Operacao" Then
            txtcodevento.Text = "210200"
            txtjust.Text = ""
            Paneljust.Visible = False
            bntmanifes.Enabled = True
            bntmanifes.Text = "Manifestar NFe"
            chkdownload.Checked = False
        End If
        If cbomanifestar.Text = "Ciencia da Operacao" Then
            txtcodevento.Text = "210210"
            txtjust.Text = ""
            Paneljust.Visible = False
            bntmanifes.Enabled = True
            bntmanifes.Text = "Manifestar NFe"
            chkdownload.Checked = False
        End If
        If cbomanifestar.Text = "Desconhecimento da Operacao" Then
            txtcodevento.Text = "210220"
            txtjust.Text = ""
            Paneljust.Visible = False
            bntmanifes.Enabled = True
            bntmanifes.Text = "Manifestar NFe"
            chkdownload.Checked = False
        End If

        If cbomanifestar.Text = "Operacao nao Realizada" Then
            Paneljust.Visible = True
            txtjust.Text = "declarando que a Operação não foi Realizada (com Recusa do Recebimento da mercadoria)"
            txtcodevento.Text = "210240"
            bntmanifes.Enabled = False
            bntmanifes.Text = "Manifestar NFe"
            chkdownload.Checked = False
        End If

      
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        bntmanifes.Enabled = True
        bntmanifes.Focus()
        Paneljust.Visible = False


        If horaverao = True Then
            dataenv = Now.ToString("yyyy-MM-ddTHH:mm:ss") + "-02:00"
        Else
            dataenv = Now.ToString("yyyy-MM-ddTHH:mm:ss") + "-03:00"
        End If

        manifesto_tipo = True

        chkdownload.Checked = False

        If chkdownload.Checked = False Then

            gerar_manifestacao()

        End If
    End Sub

    Private Sub bntmanifes_Click(sender As Object, e As EventArgs) Handles bntmanifes.Click


        If dgvnotas.RowCount = "0" Then
            Exit Sub
        End If



        If dgvnotas.CurrentCell.ColumnIndex = 0 Then

            Dim cont As Integer
            dgvnotas.EndEdit()

            For i As Integer = 0 To dgvnotas.Rows.Count - 1
                If dgvnotas.Rows.Item(i).Cells(0).Value = True Then

                    cont += 1

                End If
            Next

            If cont = 0 Then
                MsgBox("Selecione apenas um NFe para manifestação !", MsgBoxStyle.Exclamation, "Aviso !")
                Exit Sub
            End If
        End If



        If horaverao = True Then
            dataenv = Now.ToString("yyyy-MM-ddTHH:mm:ss") + "-02:00"
        Else
            dataenv = Now.ToString("yyyy-MM-ddTHH:mm:ss") + "-03:00"
        End If





        manifesto_tipo = True

     


        If chkdownload.Checked = False Then

            gerar_manifestacao()

        End If



    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        txtjust.Clear()
        Paneljust.Visible = False
    End Sub

    Private Sub chkdownload_CheckedChanged(sender As Object, e As EventArgs) Handles chkdownload.CheckedChanged
        If chkdownload.Checked = True Then
            bntmanifes.Text = "Download NFe"
            bntmanifes.Enabled = True
        Else
            bntmanifes.Text = "Manifestar NFe"
            If cbomanifestar.Text = "" Then
                bntmanifes.Enabled = False
            End If
        End If
    End Sub


    Private Sub carregar_Retorno()
        Dim xmldoc As New XmlDocument()
        Dim xmlnsManager As New XmlNamespaceManager(xmldoc.NameTable)
        Dim xmldocret As New XmlDocument()
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode
        Dim xmlnode2 As System.Xml.XmlNode

        txtpar.Text = "chave_nfe"

        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")


        xmldoc.Load(Application.StartupPath & "\xml\Retorno_EventoNFe.xml")
        xmllist = xmldoc.SelectNodes("//bk:retEvento", xmlnsManager)

        For Each xmlnode In xmllist

            For Each xmlnode2 In xmlnode

                mskpesquisa.Text = xmlnode2("chNFe").InnerText
                mskpesquisa.Text.Replace(" ", "")

                consultar()

                If xmlnode2("cStat").InnerText = "135" Or xmlnode2("cStat").InnerText = "136" Or xmlnode2("cStat").InnerText = "573" Then
                    '   conectarbase()
                    '   rssefaz.Open("select * from NFe_consultadaDFe where chave_nfe like '" & xmlnode2("chNFe").InnerText & "'", conexao.cnbase, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

                    '    If rssefaz.EOF = True Then
                    'rssefaz.AddNew()
                    '     rssefaz.Fields("Chave_nfe").Value = xmlnode2("chNFe").InnerText
                    ' End If

                    '      If xmlnode2("cStat").InnerText = "573" Then
                    'rssefaz.Fields("protocolo_NFe").Value = xmlnode2("tpEvento").InnerText
                    '   Else
                    '      rssefaz.Fields("protocolo_NFe").Value = xmlnode2("nProt").InnerText
                    '   End If

                    '    If Not xmlnode2("nProt") Is Nothing Then
                    'rssefaz.Fields("Protocolo_ciencia").Value = xmlnode2("nProt").InnerText
                    '   End If

                    'rssefaz.Fields("situacao_nfe").Value = xmlnode2("xEvento").InnerText
                    '   rssefaz.Update()
                    '  rssefaz.Close()
                    '   conexao.cnbase.Close()

                End If

            Next
        Next

        txtinfo.Text = "Informações salva com sucesso !"

        '''''''''''''''''Chama a Rotina para realizar donload do xml'''''''''''''''''
       

    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        salva_xml_nfe()
    End Sub

    Private Sub ExcluirNotaFiscalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExcluirNotaFisca.Click
        If dgvnotas.RowCount <> "0" Then
            If MessageBox.Show("Deseja Excluir está Nota Fiscal do Banco de Dados ? ", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                conectar_DFe()
                Dim rsdeletar As New ADODB.Recordset
                rsdeletar.Open("delete * from NFe_consultadaDFe where chave_nfe like '" & dgvnotas.CurrentRow.Cells(5).Value & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                cn_DFe.Close()

                MsgBox("Nota Fiscal Excluida com sucesso !", MsgBoxStyle.Information, "Aviso !")
            End If
        End If
    End Sub

    Private Sub ConsultaStatusNFeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaStatusNFe.Click
        If dgvnotas.RowCount <> "0" Then

            pinfo.Visible = True
            txtinfo.Text = "Aguarde, Enquanto o sistema Consulta as NF-e na Sefaz ..."
            pinfo.Visible = True
            System.IO.File.Delete(Application.StartupPath & "\XML\Retorno_consultaNFe.xml")

            Dim rotina3 As Thread
            Control.CheckForIllegalCrossThreadCalls = False
            rotina3 = New Thread(AddressOf consultanfe_sefaz)
            rotina3.SetApartmentState(ApartmentState.STA)
            rotina3.Start()

        End If
    End Sub

    Private Sub consultanfe_sefaz()

        Dim WebS As New C_WebService
        Dim retornonfe As New RetRetorno
        Dim xmlretcanc = New XmlDocument()



        Try

            'chama a rotina para consulta nfe no sefaz mg
            WebS.url_webservice(BuscaURL(dgvnotas.CurrentRow.Cells("chave_nfe").Value.ToString.Substring(0, 2), "1", False, ""))


            'chama a rotina para consulta nfe no sefaz mg

            retornonfe = WebS.ConsultaStatusNfe2(dgvnotas.CurrentRow.Cells("chave_nfe").Value, "1")

            If retornonfe.cStat <> "100" Then

                If retornonfe.cStat <> "1010" Then
                    MsgBox(retornonfe.xMotivo, MsgBoxStyle.Information, "Retorno do Sefaz")
                End If

            End If



            If retornonfe.cStat = "100" Or retornonfe.cStat = "101" Then


                If retornonfe.cStat = "101" Then

                    conectar_DFe()

                    rsconsulta.Open("select * from NFe_consultadaDFe where chave_nfe = '" & dgvnotas.CurrentRow.Cells(5).Value & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

                    rsconsulta.Fields("status_nfe").Value = "NF-e cancelada"
                    rsconsulta.Fields("situacao_nfe").Value = "NF-e cancelada"

                    rsconsulta.Update()
                    cn_DFe.Close()

                    dgvnotas.CurrentRow.Cells(6).Value = "NF-e cancelada"
                    '   MsgBox(retornonfe.xMotivo)

                End If



                For Each RetC In retornonfe.L_Retornos
                    MsgBox("Chave NF-e: " & dgvnotas.CurrentRow.Cells(5).Value & Chr(13) & "Data da Autorização: " & RetC.dhRecbto & Chr(13) & "Status da NF-e: " & RetC.xMotivo & Chr(13) & "Protocolo da NF-e: " & RetC.nProt, MsgBoxStyle.Information, "Retorno do Sefaz:")
                    dgvnotas.CurrentRow.Cells(6).Value = RetC.xMotivo
                Next

            End If









            System.IO.File.Delete(Application.StartupPath & "\XML\Retorno_consultaNFe.xml")

        Catch ex As Exception
            dgvnotas.CurrentRow.Cells(6).Value = "Sem retorno da SEFAZ"
        End Try





        pinfo.Visible = False
    End Sub

    Private Sub dgvnotas_DoubleClick(sender As Object, e As EventArgs) Handles dgvnotas.DoubleClick
        If dgvnotas.RowCount <> "0" Then
            If dgvnotas.CurrentRow.Cells(11).Value = "0-NFe Entrada" Then
                If MessageBox.Show("Deseja Arquivar a Nota fiscal de Entrada", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                    Dim rssefaz As New ADODB.Recordset
                    conectar_DFe()

                    rssefaz.Open("select * from NFe_consultadaDFe where chave_nfe like '" & dgvnotas.CurrentRow.Cells(5).Value & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                    rssefaz.Fields("situacao_nfe").Value = "Nota Fiscal de Devolucao"
                    rssefaz.Update()
                    cn_DFe.Close()
                    dgvnotas.Rows.Remove(dgvnotas.CurrentRow)

                End If
            End If

        End If
    End Sub

    Private Sub ConsultaChaveOrigemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaChaveOrigem.Click
        frmlernfe.txtchave.Text = dgvnotas.CurrentRow.Cells("chave_nfe").Value
        frmlernfe.consulta = True
        frmlernfe.ShowDialog()
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If dgvnotas.RowCount = "0" Then
            ExcluirNotaFisca.Visible = False
            ConsultaChaveOrigem.Visible = False
            ConsultaStatusNFe.Visible = False
        Else
            ExcluirNotaFisca.Visible = True
            ConsultaStatusNFe.Visible = True

            Try



                If dgvnotas.CurrentRow.Cells("nferef").Value <> "" Then
                    MsgBox("Chave nfe Origem: " & dgvnotas.CurrentRow.Cells("nferef").Value, MsgBoxStyle.Information, "Aviso !")
                Else
                    ConsultaChaveOrigem.Visible = True
                End If

               

            Catch ex As Exception

        End Try


        End If


    End Sub

    Private Sub dgvnotas_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvnotas.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
        End If
    End Sub

    Private Sub dgvnotas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvnotas.KeyPress
        If (e.KeyChar = Chr(13)) Then

            If dgvnotas.RowCount <> 0 Then



                If dgvnotas.CurrentRow.Cells("xml_nfe").Value <> "" Then


                    If dgvnotas.CurrentRow.Cells("chave_nfe").Value.ToString <> dgvnotas.CurrentRow.Cells("nferef").Value.ToString Then
                        MsgBox("Chave de acesso NF-e Diferente do XML !", MsgBoxStyle.Exclamation, "Aviso !")
                        deletarnfe_griid()
                        Exit Sub
                    End If


                    frmxml.abrir_xml(dgvnotas.CurrentRow.Cells("xml_nfe").Value)


                    Me.Close()
                

                Else

                    MsgBox("Xml Não localizado no Banco de Dados !", MsgBoxStyle.Exclamation, "Aviso !")

            End If

            End If





        End If
    End Sub

   


    Private Sub dgvnotas_SelectionChanged(sender As Object, e As EventArgs) Handles dgvnotas.SelectionChanged
        If dgvnotas.RowCount <> 0 Then
            If dgvnotas.CurrentRow.Cells("xml_nfe").Value <> "" Then
                dgvnotas.CurrentRow.Cells("xml").Value = "SIM"
           End If
        End If
    End Sub

    Private Sub baiar_xml_grid()
        xmldoc.LoadXml(dgvnotas.CurrentRow.Cells("xml_nfe").Value)


        If chkpasta.Checked = False Then

            SaveFileDialog2.Filter = "Arquivo XML (*.xml*)|*.xml"

            SaveFileDialog2.FileName = dgvnotas.CurrentRow.Cells("chave_nfe").Value

            If SaveFileDialog2.ShowDialog = Windows.Forms.DialogResult.OK Then
                xmldoc.Save(SaveFileDialog2.FileName)
                MsgBox("Download Realizado com Sucesso !", MsgBoxStyle.Information, "Aviso !")
            End If


        Else

            Dim dataprot As Date = dgvnotas.CurrentRow.Cells("data_autorizacao").Value
            Dim cxmlnfe As String = lerINI(Application.StartupPath & "\config_DFe.ini", "DFe", "caminho_xmlnfe")

            If Directory.Exists(cxmlnfe + "\" + dataprot.ToString("dd-MM-yyyy")) = False Then
                Directory.CreateDirectory(cxmlnfe + "\" + dataprot.ToString("dd-MM-yyyy"))
            End If

            xmldoc.Save(cxmlnfe + "\" + dataprot.ToString("dd-MM-yyyy") + "\" & dgvnotas.CurrentRow.Cells("chave_nfe").Value + ".xml")
            MsgBox("Arquivo XML salvo na pasta !", MsgBoxStyle.Information, "Aviso !")
        End If
    End Sub

    Private Sub deletarnfe_griid()
        conectar_DFe()

        rsconsulta.Open("select * from NFe_consultadaDFe where chave_nfe = '" & dgvnotas.CurrentRow.Cells("chave_nfe").Value & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        rsconsulta.Fields("XML_NFe").Value = Nothing
        rsconsulta.Fields("XML").Value = False

        dgvnotas.CurrentRow.Cells("nferef").Value = ""
        dgvnotas.CurrentRow.Cells("xml_nfe").Value = ""

        rsconsulta.Update()

        cn_DFe.Close()

        MsgBox("XML Invalido deletado !!!", MsgBoxStyle.Exclamation, "Aviso !")
    End Sub

    Private Sub DownloadPortalNFeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadPortalNFeToolStripMenuItem.Click
        frmdownloadnfe.txtchave.Text = dgvnotas.CurrentRow.Cells("chave_nfe").Value
        frmdownloadnfe.ShowDialog()
    End Sub


#Region "''''''Webservice DFe consulta nfe"


    Private Sub rotinaconsulta_DFedest()

        Dim WebS As New C_WebService
        Dim RetonoConsulta As New RetRetorno

        Try

            '''''''''''''''''''chama a rotina para consulta nfe no sefaz mg''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''BUSCA URL''''''''''''
            WebS.url_webservice(BuscaURL("AN31", "1", False, ""))

            ''''''''''''''ATIVA WEBSERVICE'''''''''''''''
            RetonoConsulta = WebS.NFeDistribuicaoDFe(cnpj_cert, "1", mskchavemg.Text.Substring(0, 2), "000000000000000", mskchavemg.Text, "Dfe_cons_chave")

            txtinfo.Text = RetonoConsulta.xMotivo



            ''''''''''''''''''''''''Rotina para tratar o erro se ocorrer abaixo'''''''''''''''''''''
            If reterro <> "" Then
                txtinfo.Text = "Ocorre um erro: " & reterro
                pic_Ico.Visible = False
                reterro = String.Empty
                Exit Sub
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''##########''''''''''''''''''''''''''''''''''''''
            If RetonoConsulta.cStat = "137" Or RetonoConsulta.cStat = "138" Then

                decryptografar_arq()

                ' dgvdferet.Invoke(CType(AddressOf abrir_xml, MethodInvoker))


                txtinfo.Text = "Consulta Chave Acesso Realizado com Sucesso em " & Now.ToString("dd-MM-yyyy HH:mm:ss") & vbCrLf & "Retorno da Consulta está no Grid abaixo !"

            Else

                ''''''''''''Se hover um errro no retorno da consulta chama a rotina abaixo'''''''''''''''''
                txtinfo.Text = RetonoConsulta.xMotivo
               

            End If

            pic_Ico.Visible = False


        Catch ex As Exception

            txtinfo.Text = ex.Message
            pic_Ico.Visible = False
        End Try


    End Sub

    Private Sub decryptografar_arq()


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
                            ler_nfe_ret_dfe(rdr.ReadToEnd, InnerNode2.Attributes.Item(1).Value)
                        End Using 'rdr
                    End Using 'gzs
                End Using 'ms
            Next

        Next

    End Sub

    Private Sub ler_nfe_ret_dfe(ByVal xml As String, ByVal tipo_ret As String)

        If tipo_ret.Substring(0, 6) = "resNFe" Then

            Dim xmlret = New XmlDocument()
            xmlret.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & xml & "")


            Dim xmllist As System.Xml.XmlNodeList
            Dim xmlnode As System.Xml.XmlNode
            xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
            xmllist = xmlret.SelectNodes("//bk:resNFe", xmlnsManager)

            For Each xmlnode In xmllist
              

                '''''''''''''''''''''''''''''''''''''''''''###################################'''''''''''''''''''''''''''''''''

                dgvnotas.Rows.Add(False, xmlnode("xNome").InnerText, xmlnode("chNFe").InnerText.Substring(25, 9), Convert.ToDateTime(xmlnode("dhRecbto").InnerText).ToString("dd/MM/yyyy"),
                                      xmlnode("vNF").InnerText, xmlnode("chNFe").InnerText, "NFe Resumo", xmlnode("tpNF").InnerText, xmlnode("CNPJ").InnerText, "")

            Next


        End If




        If tipo_ret.Substring(0, 13) = "procEventoNFe" Then

            Dim xmlret = New XmlDocument()
            xmlret.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & xml & "")

            Dim xmllist As System.Xml.XmlNodeList
            Dim xmlnode As XmlNode
            xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
            xmllist = xmlret.SelectNodes("//bk:procEventoNFe", xmlnsManager)

            For Each xmlnode In xmllist

                ''''''''''''''''''''''''''''''''Rotina abaixo trato o retorno de cancelamento da nfe'''''''''''''''''''''''


                If xmlnode("evento")("infEvento")("detEvento")("descEvento").InnerText = "Cancelamento" Then

                    Dim rssefaz As New ADODB.Recordset
                    conectar_DFe()
                    rssefaz.Open("select * from NFe_consultadaDFe where chave_nfe = '" & xmlnode("evento")("infEvento")("chNFe").InnerText & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

                    If rssefaz.EOF = True Then
                        rssefaz.Fields("status_nfe").Value = "NFe cancelada"
                        rssefaz.Fields("situacao_nfe").Value = "Cancelamento"
                        rssefaz.Fields("protocolo_NFe").Value = xmlnode("retEvento")("infEvento")("nProt").InnerText
                        rssefaz.Update()
                    End If

                    cn_DFe.Close()

                    MsgBox("A Nota Fiscal Foi Cancelada pelo Emitente" + vbCrLf + "Protocolo Cancelamento: " & xmlnode("retEvento")("infEvento")("xMotivo").InnerText, MsgBoxStyle.Information, "Aviso !")

                End If

            Next


        End If




        If tipo_ret.Substring(0, 7) = "procNFe" Then


            Dim xmlret = New XmlDocument()
            xmlret.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & xml & "")

            Dim xmllist As System.Xml.XmlNodeList
            Dim xmlnode As XmlNode
            xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
            xmllist = xmlret.SelectNodes("//bk:nfeProc", xmlnsManager)


            For Each xmlnode In xmllist



                Dim result As String = pesquisa_grid_chave(chave)

                If result = "R" Then

                    dgvnotas.Rows.Add(False, xmlnode("NFe")("infNFe")("emit")("xNome").InnerText, xmlnode("protNFe")("infProt")("chNFe").InnerText.Substring(25, 9), Convert.ToDateTime(xmlnode("protNFe")("infProt")("dhRecbto").InnerText).ToString("dd/MM/yyyy"),
                                      xmlnode("NFe")("infNFe")("total")("ICMSTot")("vNF").InnerText, xmlnode("protNFe")("infProt")("chNFe").InnerText, "NFe autorizada", tipo_nfe_ret(xmlnode("NFe")("infNFe")("ide")("tpNF").InnerText), _
                                      xmlnode("NFe")("infNFe")("dest")("CNPJ").InnerText, "", xml, "", "SIM")
                Else

                    dgvnotas.Rows.Item(result).Cells("xml").Value = "SIM"
                    dgvnotas.Rows.Item(result).Cells("xml_nfe").Value = xml

                End If



                If chkpasta.Checked = True Then
                    Dim dataprot As String = Convert.ToDateTime(xmlnode("protNFe")("infProt")("dhRecbto").InnerText).ToString("dd/MM/yyyy")
                    Dim cxmlnfe As String = lerINI(Application.StartupPath & "\config.ini", "DFe", "caminho_salvarxmlnfe")

                    If Directory.Exists(cxmlnfe + "\" + dataprot) = False Then
                        Directory.CreateDirectory(cxmlnfe + "\" + dataprot)
                    End If

                    xmlret.Save(cxmlnfe + "\" + dataprot + "\" & xmlnode("protNFe")("infProt")("chNFe").InnerText + ".xml")
                End If


            Next

        End If

    End Sub

    Private Function pesquisa_grid_chave(ByVal id As String) As String

        Dim r As String = "R"

        For Each row As DataGridViewRow In Me.dgvnotas.Rows

            If Not row.IsNewRow Then
                If row.Cells("chave_nfe").Value = id Then
                    Return row.Index
                End If
            End If

        Next

        Return r

    End Function

    Private Function tipo_nfe_ret(ByVal id As String) As String

        If id = "0" Then
            id = "0-NFe Entrada"
        End If
        If id = "1" Then
            id = "1-NFe Saida"
        End If

        Return id

    End Function

#End Region

    Private Sub bntdownloadmg_MouseUp(sender As Object, e As MouseEventArgs) Handles bntdownloadmg.MouseUp
        Me.ContextMenuStrip3.Show(TryCast(sender, Control), e.X, e.Y)
    End Sub

  Private Sub ValidaXMLCompletoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ValidaXMLCompletoToolStripMenuItem.Click

        If mskchavemg.Text = "" Then
            MsgBox("Infome a Chave de Acesso da NF-e ?", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If


        If Len(mskchavemg.Text) < 44 Then
            MsgBox(" Cheve de Acesso da NFe Invalido ! ", MsgBoxStyle.Exclamation, "Aviso !")
            mskchavemg.Focus()
            Exit Sub
        End If


        If Not validachavenfe(mskchavemg.Text) Then
            MsgBox("O Número da Chave de Acesso é inválida! ", MsgBoxStyle.Critical, "SEFAZ SP !")
            mskchavemg.Focus()
            Exit Sub
        End If


        pinfo.Visible = True
        pinfo.Height = 148
        txtinfo.Text = "Aguarde, Consultando chave acesso informada..."

        '''''''''''''''''''''''''''Ativa a Rotina de Pesquisa dos Documento na receita'''''''''''''''''''



        Control.CheckForIllegalCrossThreadCalls = False
        rotina_dfe = New Thread(AddressOf rotinaconsulta_DFedest)
        rotina_dfe.SetApartmentState(ApartmentState.STA)
        rotina_dfe.Start()

    End Sub

    Private Sub mskpesquisa_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskpesquisa.MaskInputRejected

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If lblpar.Text = "e" Then
            MsgBox("Consulta em Execução, aguarde ...", MsgBoxStyle.Exclamation, "Aviso !")
        Else

            lblinfo.Visible = True
            lblinfo.Refresh()

            Dim rotina As Thread
            Control.CheckForIllegalCrossThreadCalls = False
            rotina = New Thread(AddressOf consultar)
            rotina.SetApartmentState(ApartmentState.STA)
            rotina.Start()
        End If
    End Sub
End Class