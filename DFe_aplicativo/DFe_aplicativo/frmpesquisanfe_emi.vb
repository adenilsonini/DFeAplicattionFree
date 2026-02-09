Imports System.Text
Imports System.Xml
Imports System.Threading
Imports Microsoft.VisualBasic.Devices
Imports System.Drawing.Printing
Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Reflection

Public Class frmpesquisanfe_emi
    Dim rotina2 As Thread
    Dim nome_impressora As String
    Dim xmlnfe As String
    Dim xmldoc As New XmlDocument()
    Dim xmlnsManager As New XmlNamespaceManager(xmldoc.NameTable)
    Dim ambiente As Integer
    Dim status As String
    Dim desc As String, nsequencia As String, prot_evento As String
    Dim data_prot As Date, hora_prot As Date

    Dim doc_carta As Printing.PrintDocument

    Dim rs As New ADODB.Recordset

    Private Sub dgvpisquisa_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpisquisa.CellClick

    End Sub

    Private Sub txtnome_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnome.KeyPress
        If (e.KeyChar = Chr(13)) Then
            pesquisar_nfe()

            'MsgBox("Pesquisa por Nome destinatário Realizada !", MsgBoxStyle.Information, "Aviso !")
            If dgvpisquisa.RowCount = 1 Then
                dgvpisquisa.Focus()
            End If
        End If
    End Sub

    Public Sub pesquisar_nfe()
        Dim sql As String, xml_aut As String, xml_canc As String, xml As String, carta As String
        Dim status_nfe As String
        Dim data_ini As Date = Dataini.Text
        Dim data_fim As Date = datafin.Text
        dgvpisquisa.Rows.Clear()

        If cbostatus.Text = "NFe Autorizada" Then
            status = 100
        End If
        If cbostatus.Text = "NFe Cancelada" Then
            status = 135
        End If

        If cbostatus.Text = "Nao Transmitida" Then
            status = 0
        End If

        If cbostatus.Text = "NFe XML invalido" Then
            status = 5
        End If


        ambiente = empresa.ambiente_nfe




        sql = "select * from nfe_s INNER JOIN cliente ON nfe_s.cnpj_cli = cliente.cnpjcpf_cli WHERE nfe_s.ambiente = '" & ambiente & "'"

        If chkstatus.Checked = True Then
            sql = sql + " and nfe_s.cstat = " & status & ""
        End If

        If chkdescricao.Checked = True Then
            sql = sql + " and cliente.nome_cli like '%" & txtnome.Text & "%' and nfe_s.cnpj_emi = '" & cnpj_emp & "'"
        End If


        If chkdata.Checked = True Then
            sql = sql + " AND nfe_s.Data_emissao_nfe between '" & data_ini.ToString("yyyy-MM-dd 00:00:00") & "' AND '" & data_fim.ToString("yyyy-MM-dd 23:59:59") & "'"
        End If

        If chknumero.Checked = True Then
            txtnumero.Text = txtnumero.Text.PadLeft(9, "0")
            sql = sql + " and nfe_s.Numero_nfe = " & txtnumero.Text & ""
        End If


        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read

                If reader("nprot").ToString <> "" Then

                    status_nfe = "NF-e Autorizada"

                    Try
                        xml_aut = Base64Decode(reader("xml").ToString)
                    Catch ex As Exception
                        xml_aut = reader("xml").ToString
                    End Try


                Else

                    xml_aut = ""

                    If reader("xmotivo").ToString = "" Then
                        status_nfe = "NF-e Nao Transmitida"

                        xml = Base64Decode(reader("xml").ToString)

                    End If

                End If


                If reader("nprot_canc").ToString <> "" Then
                    status_nfe = "NF-e Cancelada"
                    xml_canc = Base64Decode(reader("XML_canc").ToString)
                Else
                    xml_canc = ""
                End If

                If reader("nProt_correcao").ToString <> "" Then
                    carta = Base64Decode(reader("XML_carta").ToString)
                Else
                    carta = ""
                End If
                status_nfe = reader("Status_nfe").ToString

                If pesquisa_grid(reader("Numero_nfe").ToString.PadLeft(9, "0")) = "R" Then
                    dgvpisquisa.Rows.Add(reader("Numero_nfe").ToString.PadLeft(9, "0"), reader("Serie_nfe").ToString.PadLeft(3, "0"), Convert.ToDateTime(reader("Data_emissao_nfe")).ToString("dd/MM/yyyy HH:mm:ss"), reader("nome_cli"), _
                                                 format_val_mysql_ret(reader("Valor_total_nfe")), status_nfe, xml_aut, xml_canc, reader("nprot_canc"), reader("xmotivo").ToString, _
                                                   xml, "", reader("Chave_nfe").ToString, reader("Status_nfe").ToString, carta, reader("cstat").ToString, reader("nrecibo").ToString, reader("nprot").ToString)
                End If



            End While

        End Using




        lbltotalnotas.Text = dgvpisquisa.RowCount

        cor_grid()


    End Sub


    Private Sub cor_grid()
        For Each row As DataGridViewRow In dgvpisquisa.Rows

            If row.Cells("cstatgrid").Value = "100" Then
                With Me.dgvpisquisa.Rows(row.Index).DefaultCellStyle
                    .BackColor = Color.PaleGreen
                    .ForeColor = Color.Blue
                End With
            End If

            If row.Cells("cstatgrid").Value = "135" Or row.Cells("cstatgrid").Value = "136" Then
                With Me.dgvpisquisa.Rows(row.Index).DefaultCellStyle
                    .BackColor = Color.Red
                    .ForeColor = Color.White
                End With
            End If

            If row.Cells("cstatgrid").Value = "0" Then
                With Me.dgvpisquisa.Rows(row.Index).DefaultCellStyle
                    .BackColor = Color.White
                    .ForeColor = Color.Blue
                End With
            End If

            If row.Cells("cstatgrid").Value = "5" Then
                With Me.dgvpisquisa.Rows(row.Index).DefaultCellStyle
                    .BackColor = Color.LightSalmon
                    .ForeColor = Color.White
                End With
            End If

        Next
    End Sub


    Private Sub dgvpisquisa_Click(sender As Object, e As EventArgs) Handles dgvpisquisa.Click

        If dgvpisquisa.RowCount = 0 Then
            Exit Sub
        End If


        'If dgvpisquisa.CurrentRow.Cells("status_NFe").Value.ToString.Length >= 9 Then
        'If dgvpisquisa.CurrentRow.Cells("status_NFe").Value.ToString.Substring(0, 9) = "Rejeicao:" Then
        'MsgBox(dgvpisquisa.CurrentRow.Cells("status_NFe").Value.ToString, MsgBoxStyle.Exclamation, "Aviso NF-e Rejeita Motivo !")
        '  End If
        ' End If



    End Sub

    Private Sub cbostatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbostatus.KeyPress
        If (e.KeyChar = Chr(13)) Then
            pesquisar_nfe()
            MsgBox("Pesquisa Realizada por Status NF-e", MsgBoxStyle.Information, "Aviso !")
        End If
    End Sub

    Private Sub cbostatus_Validated(sender As Object, e As EventArgs) Handles cbostatus.Validated

        If cbostatus.Text <> "" Then

            Dim verifica As Boolean = False
            For i As Integer = 0 To cbostatus.Items.Count - 1

                If cbostatus.Text = cbostatus.Items(i) Then
                    verifica = True
                End If

            Next

            If verifica = False Then
                MsgBox("O Valor digitado não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
                cbostatus.Text = ""
                cbostatus.Focus()
            End If

        End If
    End Sub

    Private Sub frmpesquisanfe_emi_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                pesquisar_nfe()
            Case Keys.Escape
                Me.Dispose()
        End Select
    End Sub

    Private Sub frmpesquisanfe_emi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbostatus.SelectedIndex = 0


        ' Dataini.Text = Now.ToString("01/MM/yyyy")
    End Sub

    Private Sub chkdata_CheckedChanged(sender As Object, e As EventArgs) Handles chkdata.CheckedChanged
        If chkdata.Checked = True Then
            Dataini.Enabled = True
            datafin.Enabled = True
        Else
            Dataini.Enabled = False
            datafin.Enabled = False
        End If
    End Sub

    Private Sub chkdescricao_CheckedChanged(sender As Object, e As EventArgs) Handles chkdescricao.CheckedChanged
        If chkdescricao.Checked = True Then
            txtnome.Enabled = True
            txtnome.Focus()
        Else
            txtnome.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pesquisar_nfe()

        If dgvpisquisa.RowCount = 1 Then
            dgvpisquisa.Focus()
        End If

        ' MsgBox("Pesquisa por Nome destinatário Realizada !", MsgBoxStyle.Information, "Aviso !")
    End Sub

    Private Sub chknumero_CheckedChanged(sender As Object, e As EventArgs) Handles chknumero.CheckedChanged
        If chknumero.Checked = True Then
            txtnumero.Enabled = True
            txtnumero.Focus()
        Else
            txtnumero.Enabled = False
            txtnumero.Clear()
        End If
    End Sub

    Private Sub txtnumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumero.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If

        If (e.KeyChar = Chr(13)) Then
            pesquisar_nfe()
            MsgBox("Pesquisa Realizada por Número da NF-e !", MsgBoxStyle.Information, "Aviso !")

            If dgvpisquisa.RowCount = 1 Then
                dgvpisquisa.Focus()
            End If
        End If
    End Sub

    Private Sub dgvpisquisa_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvpisquisa.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
        End If
    End Sub


    Private Sub dgvpisquisa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvpisquisa.KeyPress
        If (e.KeyChar = Chr(13)) Then

            If dgvpisquisa.Rows.Count <> 0 Then

                frmxml_nfe.ret_nfe_banco(dgvpisquisa.CurrentRow.Cells("chave_nfe").Value)

                frmxml_nfe.ativa_tab()
                Me.Close()

            End If

        End If
    End Sub

    Private Sub Dataini_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Dataini.KeyPress
        If (e.KeyChar = Chr(13)) Then
            pesquisar_nfe()
            MsgBox("Pesquisa Realizada por Dta emissão da NF-e !", MsgBoxStyle.Information, "Aviso !")
        End If
    End Sub

    Private Sub datafin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles datafin.KeyPress
        If (e.KeyChar = Chr(13)) Then
            pesquisar_nfe()
            MsgBox("Pesquisa Realizada por Data emissão da NF-e !", MsgBoxStyle.Information, "Aviso !")
        End If
    End Sub

    Private Sub chkstatus_CheckedChanged(sender As Object, e As EventArgs) Handles chkstatus.CheckedChanged
        If chkstatus.Checked = True Then
            cbostatus.Enabled = True
        Else
            cbostatus.Enabled = False
        End If
    End Sub

    Private Function pesquisa_grid(ByVal id As String) As String

        Dim r As String = "R"

        For Each row As DataGridViewRow In Me.dgvpisquisa.Rows

            If Not row.IsNewRow Then
                If row.Cells("numero_nfe").Value = id Then
                    Return row.Index
                End If
            End If

        Next

        Return r

    End Function

    Private Sub consulta_nfesefaz(ByVal nchave As String, ByVal xml As String, ByVal ambiente As String)
        Dim WebS As New C_WebService
        Dim retEnviNFe As retEnviNFe
        Dim retConsReciNFe As retConsReciNFe
        Dim retConsSitNFe As retConsSitNFe

        If xml <> "" Then
            Try
                xmldoc.LoadXml(gerar_xmlNFCe_envio(xml, ambiente))
            Catch ex As Exception
                xmldoc.LoadXml(xml)
            End Try
        End If


        retConsSitNFe = WebS.ConsultaStatusNfe(nchave, ambiente)

        Try
            ''''''''''''''Rotina abaixo para enviar a NFe para sefaz'''''''''''''''''''''

            If retConsSitNFe.cStat = "100" Then

                If xml <> "" Then
                    Dim dados As XmlDocument = New XmlDocument
                    dados = GerarNotaProcessadanfce(SepararNota_tagnfe(xmldoc.OuterXml), retConsSitNFe.xmlprot)
                    xmldoc.LoadXml(alterar_digestvalue(dados.OuterXml))

                    '''''''''''''''''''''''''''Salva info no banco''''''''''''''''''''''''''
                    executa_query("update nfe_s set xmotivo = '" & retConsSitNFe.protNFe.infProt.xMotivo & "', cstat = '" & retConsSitNFe.protNFe.infProt.cStat & "', xml = '" & Base64Encode(dados.OuterXml) & "', nprot = '" & retConsSitNFe.protNFe.infProt.nProt & "',  Status_nfe = 'NFe autorizada'  where Chave_nfe = '" & nchave & "'")

                    Dim Path As String = Application.StartupPath & "\NFe"
                    If Not Directory.Exists(Path) Then Directory.CreateDirectory(Path)

                    xmldoc.Save(Path & "\NFe-" & retConsSitNFe.protNFe.infProt.chNFe & ".xml")
                End If
                ' retConsReciNFe.protNFe.infProt.cStat

                MsgBox("Nota Fiscal Autorizada !" & vbCrLf & retConsSitNFe.protNFe.infProt.xMotivo & vbCrLf & "Protocolo Aut.: " & retConsSitNFe.protNFe.infProt.nProt, MsgBoxStyle.Information, "Aviso 1 !")

                Invoke(Sub() dgvpisquisa.CurrentRow.Cells("status_NFe").Value = "NFe autorizada")
                '''''''''''''''''''''Salvar arquivo ma pasta''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            End If

            If retConsSitNFe.cStat = "101" Then

                MsgBox("A Nota Fiscal esta Cancelada !" & vbCrLf & "Chave acesso: " & retConsSitNFe.chNFe & vbCrLf & "Protocolo Aut. Canc.: " & retConsSitNFe.procEventoNFe.retEvento.infEvento.nProt & vbCrLf & "Status: " & retConsSitNFe.procEventoNFe.retEvento.infEvento.xMotivo, MsgBoxStyle.Exclamation, "Aviso ")

                xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & retConsSitNFe.xmlprocevent & "")
                xmldoc.Save(Application.StartupPath & "\XML_nfecanc\" & retConsSitNFe.chNFe & "-procEventoNFe.xml")
                '   MsgBox("XML de Cancelamento gerado na pasta: " & Application.StartupPath & "\XML_nfecanc", MsgBoxStyle.Information, "Aviso ")

                dgvpisquisa.CurrentRow.Cells("xmotivogrid").Value = retConsSitNFe.procEventoNFe.retEvento.infEvento.xMotivo
                dgvpisquisa.CurrentRow.Cells("cStatgrid").Value = retConsSitNFe.procEventoNFe.retEvento.infEvento.cStat


                conectar_mysqlDFe()
                Dim sql As String = "update nfe_s set cstat = '" & retConsSitNFe.procEventoNFe.retEvento.infEvento.cStat & "', xmotivo = '" & retConsSitNFe.procEventoNFe.retEvento.infEvento.xMotivo & "', xml = '', Status_nfe = 'NFe Cancelada', xml_canc = '" & Convert.ToBase64String(Encoding.UTF8.GetBytes(xmldoc.OuterXml)) & "' where Chave_nfe = '" & retConsSitNFe.procEventoNFe.retEvento.infEvento.chNFe & "'"
                Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)

                insertSQL.ExecuteNonQuery()

                oConn.Close()

            End If


            If retConsSitNFe.cStat <> "100" Then
                If retConsSitNFe.cStat <> "101" Then

                    MsgBox(retConsSitNFe.cStat & "-" & retConsSitNFe.xMotivo, MsgBoxStyle.Exclamation, "Aviso 2 !")
                    Invoke(Sub() dgvpisquisa.CurrentRow.Cells("status_NFe").Value = retConsSitNFe.cStat & "-" & retConsSitNFe.xMotivo)
                    executa_query("update nfe_s set xmotivo = '" & retConsSitNFe.xMotivo & "', cstat = '" & retConsSitNFe.cStat & "', Status_nfe = '" & retConsSitNFe.xMotivo & "'  where Chave_nfe = '" & nchave & "'")

                End If
            End If

        Catch ex As Exception
            MsgBox(reterro, MsgBoxStyle.Exclamation, "Aviso erro!")
            Invoke(Sub() dgvpisquisa.CurrentRow.Cells("status_NFe").Value = reterro)
        End Try

        Pinfo.Visible = False
    End Sub

 
    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If dgvpisquisa.CurrentRow.Cells("xml_carta").Value.ToString <> "" Then

            CartaCorrecaoNFE_MenuItem.Enabled = True
        Else
            CartaCorrecaoNFE_MenuItem.Enabled = False
        End If

        If dgvpisquisa.CurrentRow.Cells("xml_aut").Value.ToString <> "" Then

            Baixa_xml_MenuItem.Enabled = True
            NFeAutorizadaToolStripMenuItem.Enabled = True

        Else

            Baixa_xml_MenuItem.Enabled = False
            NFeAutorizadaToolStripMenuItem.Enabled = False

        End If

        If dgvpisquisa.CurrentRow.Cells("xml_canc").Value.ToString <> "" Then
            NFeCanceladaToolStripMenuItem.Enabled = True
            Baixa_xml_MenuItem.Enabled = True
            XMLNFeCancelada_MenuItem.Enabled = True
            NFeAutorizadaToolStripMenuItem.Enabled = False
        Else
            XMLNFeCancelada_MenuItem.Enabled = False
            NFeCanceladaToolStripMenuItem.Enabled = False
        End If

        If dgvpisquisa.CurrentRow.Cells("xml_carta").Value.ToString <> "" Then
            CartaDeCorrecaoToolStripMenuItem.Enabled = True
        Else
            CartaDeCorrecaoToolStripMenuItem.Enabled = False

        End If

        If dgvpisquisa.CurrentRow.Cells("cstatgrid").Value.ToString = "100" Then
            GerarXMLToolStripMenuItem.Enabled = False
            danfeToolStripMenuItem.Enabled = True
            CancelaNFeToolStripMenuItem.Enabled = True
        Else
            GerarXMLToolStripMenuItem.Enabled = True
            danfeToolStripMenuItem.Enabled = False
            CancelaNFeToolStripMenuItem.Enabled = False
            XMLAutorizadoToolStripMenuItem.Enabled = False
        End If

    End Sub

    Private Sub XMLAutorizadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XMLAutorizadoToolStripMenuItem.Click
        Dim dialo_salve As New SaveFileDialog
        dialo_salve.Filter = "Arquivo XML (.xml)|*.xml"
        dialo_salve.FileName = dgvpisquisa.CurrentRow.Cells("chave_nfe").Value

        If dialo_salve.ShowDialog() = Windows.Forms.DialogResult.OK Then


            Dim Xml_danfe As XmlDocument = New XmlDocument
            Xml_danfe.LoadXml(dgvpisquisa.CurrentRow.Cells("xml_aut").Value)
            Xml_danfe.Save(dialo_salve.FileName)


            MsgBox("XML NF-e salvo com Sucesso !", MsgBoxStyle.Information, "Aviso !")

        End If
    End Sub

    Private Sub XMLNFeCancelada_MenuItem_Click(sender As Object, e As EventArgs) Handles XMLNFeCancelada_MenuItem.Click
        Dim dialo_salve As New SaveFileDialog
        dialo_salve.Filter = "Arquivo XML (.xml)|*.xml"
        dialo_salve.FileName = dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "-procEventoNFe"

        If dialo_salve.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim Xml_danfe As XmlDocument = New XmlDocument
            Xml_danfe.LoadXml(dgvpisquisa.CurrentRow.Cells("xml_canc").Value)
            Xml_danfe.Save(dialo_salve.FileName)


            MsgBox("XML Cancelamento salvo com Sucesso !", MsgBoxStyle.Information, "Aviso !")

        End If
    End Sub

    Private Sub OnsultaNFeSEFAZToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnsultaNFeSEFAZToolStripMenuItem.Click

        Control.CheckForIllegalCrossThreadCalls = False
        rotina2 = New Thread(AddressOf Consulta_statusnfe)
        rotina2.SetApartmentState(ApartmentState.STA)

        rotina2.Start()

    End Sub

    Private Sub Consulta_statusnfe()
        Dim xml As String
        If dgvpisquisa.CurrentRow.Cells("cstatgrid").Value <> "100" Then

            xml = Base64Decode(ret_valor_campo("select * from nfe_s where Chave_nfe = '" & dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "'", "xml"))

        End If

        Invoke(Sub() Pinfo.Visible = True)
        Invoke(Sub() txtinfo.Text = "Aguarde, Cosultando status NF-e na SEFAZ...")
        Invoke(Sub() Pinfo.Refresh())

        consulta_nfesefaz(dgvpisquisa.CurrentRow.Cells("chave_nfe").Value, xml, ambiente)
    End Sub

  
#Region "''''Rotina carta correcao os dados da NFe"

    Private Sub ler_dados_emitente()
        mskfone.Text = ""
        txtemail.Text = ""

        Dim xmldocret As New XmlDocument()
        '    xmldoc.Load("C:\Users\Dell\Desktop\Carta correção\31131110962965000119550010000002321000010008-proc-NFe-CCe.xml")
        xmldoc.LoadXml(dgvpisquisa.CurrentRow.Cells("xml_aut").Value)
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
        xmldoc.LoadXml(dgvpisquisa.CurrentRow.Cells("xml_carta").Value)
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
        Gra_Saida.Graphics.DrawImage(CodigoBarra.DrawBarCode(dgvpisquisa.CurrentRow.Cells("chave_nfe").Value), 184, 2, 100, 11)

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
        Gra_Saida.Graphics.DrawString("N.º " & Int32.Parse(dgvpisquisa.CurrentRow.Cells("numero_nfe").Value).ToString("000,000,000"), Font10_B, Brushes.Black, 131.5, 21)
        Gra_Saida.Graphics.DrawString("SÉRIE:", Font10_B, Brushes.Black, 131.5, 25)
        Gra_Saida.Graphics.DrawString(Int32.Parse(dgvpisquisa.CurrentRow.Cells("serie_nfe").Value).ToString("000"), Font10_B, Brushes.Black, 144.5, 25)

        If frmxml_nfe.optentrada.Checked = True Then
            Gra_Saida.Graphics.DrawString("0", Font8_B, Brushes.Black, 158, 15)
        Else
            Gra_Saida.Graphics.DrawString("1", Font8_B, Brushes.Black, 158, 15)
        End If

        Gra_Saida.Graphics.DrawString("CHAVE DE ACESSO", Font6, Brushes.Black, 167, 15.2)
        Gra_Saida.Graphics.DrawString(MascSTR(dgvpisquisa.CurrentRow.Cells("chave_nfe").Value, "#### #### #### #### #### #### #### #### #### #### ####"), Font12_B, Brushes.Black, 167, 17)
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

    Private Sub GerarPDFCartaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GerarPDFCartaToolStripMenuItem.Click


        Dim computerInfo As New ComputerInfo


        SaveFiled_carta.Title = "Local para salvar o Documento"

        SaveFiled_carta.Filter = "Arquivos (*.pdf)|*.pdf|All files (*.*)|*.*"

        SaveFiled_carta.FileName = dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "-CCe"



        If SaveFiled_carta.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '   Pinfo.Visible = True

            gerar_carta_print()


            If computerInfo.OSFullName.Substring(0, 20) = "Microsoft Windows 10" Then

                gerar_pdf_sistema(doc_carta, SaveFiled_carta.FileName)

            Else

                gerar_xps_PDF_sistema(doc_carta, dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "-CCe", SaveFiled_carta.FileName)

            End If

            Pinfo.Visible = False
            MsgBox("Carta de Correção no Formato PDF gerado com sucesso no local informado !", MsgBoxStyle.Information, "Aviso !")

        End If


    End Sub

    Private Sub ImprimirCartaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirCartaToolStripMenuItem.Click

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

#End Region


    Private Sub NFeCanceladaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NFeCanceladaToolStripMenuItem.Click

        If Directory.Exists(Application.StartupPath & "\XML_nfecanc") = False Then
            Directory.CreateDirectory(Application.StartupPath & "\XML_nfecanc")
        End If

        Dim xmlretcanc As New XmlDocument()
        xmlretcanc.LoadXml(dgvpisquisa.CurrentRow.Cells("xml_canc").Value)
        xmlretcanc.Save(Application.StartupPath + "\XML_nfecanc\" + dgvpisquisa.CurrentRow.Cells("chave_nfe").Value + "-procEventoNFe.xml")

        ler_dados_emitente()

        frmenvia_email.caminhoxml = Application.StartupPath + "\XML_nfecanc\" + dgvpisquisa.CurrentRow.Cells("chave_nfe").Value + "-procEventoNFe.xml"
        frmenvia_email.monta_nfe_cancelada(txtnome.Text, dgvpisquisa.CurrentRow.Cells("destinatario").Value, dgvpisquisa.CurrentRow.Cells("chave_nfe").Value,
             dgvpisquisa.CurrentRow.Cells("data_emissao").Value, dgvpisquisa.CurrentRow.Cells("nprot_canc").Value)

        frmenvia_email.txtDestino.Text = txtemail.Text
        frmenvia_email.Text = "Envio de Notificação de Nota Fiscal Cancelada para destinataria"
        frmenvia_email.ShowDialog()

    End Sub

    Private Sub CartaDeCorrecaoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CartaDeCorrecaoToolStripMenuItem.Click
        Dim computerInfo As New ComputerInfo

        If Directory.Exists(Application.StartupPath & "\XML_Carta_Correcao") = False Then
            Directory.CreateDirectory(Application.StartupPath & "\XML_Carta_Correcao")
        End If


        Dim xmlretcanc As New XmlDocument()
        xmlretcanc.LoadXml(dgvpisquisa.CurrentRow.Cells("xml_carta").Value)

        If File.Exists(Application.StartupPath & "\XML_Carta_Correcao\" & dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "-procEventoNFe.xml") = False Then
            xmlretcanc.Save(Application.StartupPath & "\XML_Carta_Correcao\" & dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "-procEventoNFe.xml")
        End If




        frmenvia_email.monta_nfe_carta_correcao(txtnome.Text, dgvpisquisa.CurrentRow.Cells("destinatario").Value, dgvpisquisa.CurrentRow.Cells("chave_nfe").Value,
                              dgvpisquisa.CurrentRow.Cells("data_emissao").Value, prot_evento)
        '
        frmenvia_email.txtDestino.Text = txtemail.Text

        gerar_carta_print()



        If computerInfo.OSFullName.Substring(0, 20) = "Microsoft Windows 10" Then

            gerar_pdf_sistema(doc_carta, Application.StartupPath & "\XML_Carta_Correcao\" & dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "-CCe.pdf")

        Else

            gerar_xps_PDF_sistema(doc_carta, dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "-CCe", Application.StartupPath & "\XML_Carta_Correcao\" & dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "-CCe.pdf")

        End If


        frmenvia_email.lstAnexos.Items.Add(Application.StartupPath & "\XML_Carta_Correcao\" & dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "-CCe.pdf")
        frmenvia_email.lstAnexos.Items.Add(Application.StartupPath & "\XML_Carta_Correcao\" & dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "-procEventoNFe.xml")




        frmenvia_email.Text = "Envio de Notificação de Carta correção da NF-e"
        frmenvia_email.ShowDialog()

    End Sub

    Private Sub EnvioEmailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnvioEmailToolStripMenuItem.Click

    End Sub

    Private Sub NFeAutorizadaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NFeAutorizadaToolStripMenuItem.Click

        criar_xml(dgvpisquisa.CurrentRow.Cells("chave_nfe").Value)

        geraPDF_microsoft(dgvpisquisa.CurrentRow.Cells("chave_nfe").Value)

        frmenvia_email.Text = "Envio de Nota Fiscal para empresa destinataria"
        frmenvia_email.ShowDialog()
    End Sub

    Private Sub criar_xml(ByVal chave As String)

        Dim xmldoc As New XmlDocument()

        xmldoc.LoadXml(dgvpisquisa.CurrentRow.Cells("xml_aut").Value)
        xmldoc.Save(Application.StartupPath & "\Temp_pdf\" & chave & ".xml")

        If File.Exists(Application.StartupPath & "\Temp_pdf\" & chave & ".xml") = False Then
            MsgBox("O Arqquivo xml da Nota Fiscal não existe !", MsgBoxStyle.Exclamation, "Aviso !")
        End If

        frmenvia_email.caminhoxml = Application.StartupPath & "\Temp_pdf\" & chave & ".xml"

    End Sub

    Private Sub geraPDF_microsoft(ByVal chave As String)
        Dim Danfe_doc As New PrintDocument
        Dim dados As XmlDocument = New XmlDocument
        Dim computerInfo As New ComputerInfo

        If Directory.Exists(Application.StartupPath & "\Temp_pdf") = False Then
            Directory.CreateDirectory(Application.StartupPath & "\Temp_pdf")
        End If


        Danfe_doc = frmxml_nfe.danfe(dgvpisquisa.CurrentRow.Cells("xml_aut").Value)


        If computerInfo.OSFullName.Substring(0, 20) = "Microsoft Windows 10" Then

            gerar_pdf_sistema(Danfe_doc, Application.StartupPath & "\Temp_pdf\" & chave & ".pdf")
            '
        Else

            gerar_xps_PDF_sistema(Danfe_doc, chave, "")

        End If

        frmenvia_email.caminhodanfe = Application.StartupPath & "\Temp_pdf\" & chave & ".pdf"
        ' frmenvia_email.caminhoxml = Application.StartupPath & "\Temp_pdf\" & chave & ".xml"


    End Sub

    Private Sub CancelaNFeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelaNFeToolStripMenuItem.Click
        If cnpj_cert <> empresa.sCNPJ Then
            MsgBox("Certificado Digital seleciona está incorreto, " & vbCrLf & "O CNPJ do Certificado e Diferente da Empresa Logada no SIstema !", MsgBoxStyle.Information, "Aviso !")
            Exit Sub
        End If

        If dgvpisquisa.CurrentRow.Cells("cstatgrid").Value = "135" Then
            MsgBox("A Nota Fiscal já está cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If


        If dgvpisquisa.CurrentRow.Cells("nprotgrid").Value = "" Then
            MsgBox("A Nota Fiscal Nã está autorizada !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If


        cancelar()

    End Sub

    Private Sub cancelar()

        '''''''''''''''''''''''''Regra de validacao de cnpj certificado''''''''''''''''''''
        '  If removeFormatacao(mskcnpjfor.Text) <> cnpj Then
        'MsgBox("CNPJ do Certificado Digital informado diferente do CNPJ Emitente da NF-e !" + vbCrLf + "Operação cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
        ' Exit Sub
        ' End If

        frmcancelanfe.Text = "Cancelamento NF-e emitida"
        frmcancelanfe.mskchave.Text = dgvpisquisa.CurrentRow.Cells("chave_nfe").Value
        frmcancelanfe.txtprotocolo.Text = dgvpisquisa.CurrentRow.Cells("nprotgrid").Value
        frmcancelanfe.mskcnpj.Text = empresa.sCNPJ
        frmcancelanfe.ShowDialog()

        '' If MessageBox.Show("Deseja Realmente cancelar a NF-e", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

        ' End If
    End Sub

    ''' <summary>
    ''' 'Rotina para gerar o arquivo xml da NF-e'''
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub gera_xmlnfe(ByVal chavenfe As String, tpemi As Integer)
        Dim chave_cont As String, nat As String
        Dim date_emi As Date
        Dim cnpj_em As String, cnpj_de As String, cnpj_tr As String
        Dim fin As Integer
        If mskcnpjfor.Text.Length = "11" Then
            MsgBox("Não é Permitido gerar Nota fiscal com CPF no Campo Emitente !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        Dim detalhamento As New det()
        Dim cst As String
        Dim ipi As String
        Dim pis As String
        Dim cofins As String
        Dim teste As New NFe()
        Dim DtMed As rastro

        teste.infNFE.Ide.cNF = chavenfe.Substring(35, 8)


        ''''''''''''''''''''''Rotina abaixo constroi a chave de acesso da nfe''''''''''''''
        If tpemi = "6" Then
            If chavenfe.Substring(34, 1) = "1" Then
                chave_cont = gerar_chave_acesso_cont(chavenfe)
                teste.Id = chave_cont
                teste.infNFE.Ide.cDV = chave_cont.Substring(43, 1)
                teste.infNFE.Ide.cNF = chave_cont.Substring(35, 8)
            Else
                teste.Id = chavenfe
                teste.infNFE.Ide.cDV = chavenfe.Substring(43, 1)
            End If
        Else
            teste.Id = chavenfe
            teste.infNFE.Ide.cDV = chavenfe.Substring(43, 1)
        End If


        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from nfe_s where Chave_nfe ='" & chavenfe & "'"
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read

                teste.versao = "4.00"
                teste.infNFE.Ide.cUF = "31"
                teste.infNFE.Ide.natOp = reader("Nat_op")
                nat = reader("Nat_op")
                '  teste.infNFE.Ide.indPag = cboindPag.Text.Substring(0, 1)
                teste.infNFE.Ide.[mod] = reader("Modelo_nfe")
                teste.infNFE.Ide.serie = reader("Serie_nfe").ToString.TrimStart("0", "")
                teste.infNFE.Ide.nNF = reader("Numero_nfe").ToString.TrimStart("0", "")
                date_emi = reader("Data_emissao_nfe")

                teste.infNFE.Ide.dhEmi = date_emi.ToString("yyyy-MM-ddTHH:mm:ss") & "-03:00"
                teste.infNFE.Ide.dhSaiEnt = Convert.ToDateTime(Now).ToString("yyyy-MM-ddTHH:mm:ss") & "-03:00"
                executa_query("update nfe_s set data_saida = '" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "' where Chave_nfe = '" & chavenfe & "'")

                teste.infNFE.Ide.idDest = reader("idDest")
                teste.infNFE.Ide.tpNF = reader("Tipo_operacao_nfe")
                teste.infNFE.Ide.cMunFG = empresa.sCodMunIBGE
                teste.infNFE.Ide.tpImp = empresa.ambiente_nfe


                If tpemi = 1 Then
                    teste.infNFE.Ide.tpEmis = "1" ''''''''''tipo contigencia''''''
                Else
                    teste.infNFE.Ide.tpEmis = "6" ''''''''''tipo contigencia''''''
                End If

                teste.infNFE.Ide.tpAmb = empresa.ambiente_nfe
                teste.infNFE.Ide.finNFe = reader("Tipo_nfe")
                fin = reader("Tipo_nfe")


                teste.infNFE.Ide.indFinal = reader("indFinal")

                teste.infNFE.Ide.indPres = "9"
                teste.infNFE.Ide.procEmi = "0"
                teste.infNFE.Ide.verProc = Assembly.GetExecutingAssembly.GetName.Version.ToString

                carregar_empresa(reader("cnpj_emi"))
                cnpj_de = reader("cnpj_cli")
                cnpj_tr = reader("cnpj_transp")

                If tpemi = "6" Or tpemi = "7" Then
                    teste.infNFE.Ide.dhCont = Now.ToString("yyyy-MM-ddTHH:mm:ss") + "-03:00"
                    teste.infNFE.Ide.xJust = "NAO FOI POSSIVEL ESTABELECER CONEXAO COM SEFAZ ORIGEM"
                End If


                If reader("Tipo_nfe") = "2" Or reader("Tipo_nfe") = "4" Then
                    If reader("chave_dv") <> "" Then
                        Dim NFrefS = New NFref("")
                        NFrefS.refNFe = reader("chave_dv")
                        teste.infNFE.Ide.NFRef.Add(NFrefS)
                    End If
                End If
            End While


        End Using






        'se For Nota Fiscal Manual cria a tag abaixo da cobertura de cupom fiscal

        conectar_mysqlDFe()
        Dim SQLcommand10 As MySqlCommand
        SQLcommand10 = oConn.CreateCommand
        SQLcommand10.CommandText = "select * from nfe_secf where Chave_nfe ='" & chavenfe & "'"
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand10.ExecuteReader

            While reader.Read
                Dim NFrefS = New NFref("ecf")

                NFrefS.ReECF.mod = reader("mod")
                NFrefS.ReECF.nECF = reader("nECF")
                NFrefS.ReECF.nCOO = reader("nCOO")
                teste.infNFE.Ide.NFRef.Add(NFrefS)

            End While

        End Using


        conectar_mysqlDFe()
        Dim SQLcommand11 As MySqlCommand
        SQLcommand11 = oConn.CreateCommand
        SQLcommand11.CommandText = "select * from nfe_snfce where Chave_nfe ='" & chavenfe & "'"
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand11.ExecuteReader

            While reader.Read
                Dim NFrefS = New NFref("")
                NFrefS.refNFe = reader("Chave_nfce")
                teste.infNFE.Ide.NFRef.Add(NFrefS)
            End While

        End Using

        '''''''''''''''''''''''''''''''#########################'''''''''''''''''''''''''''''

        ''''''''''''''''''''''Rotina abaixo constroi os dados do Emitente da nfe''''''''''''''

        teste.infNFE.Emit.CNPJ = empresa.sCNPJ
        teste.infNFE.Emit.xNome = empresa.sNomeRazao
        teste.infNFE.Emit.xFant = empresa.sNomefant
        teste.infNFE.Emit.IE = empresa.sIe

        If empresa.sIest <> "" Then
            teste.infNFE.Emit.IEST = empresa.sIest
        End If

        If empresa.sInscrMunic <> "" Then
            teste.infNFE.Emit.IM = empresa.sInscrMunic
        End If

        If empresa.Scnae <> "" Then
            teste.infNFE.Emit.CNAE = empresa.Scnae
        End If

        teste.infNFE.Emit.CRT = empresa.scod_trib
        teste.infNFE.Emit.EnderEmit.xLgr = empresa.send
        teste.infNFE.Emit.EnderEmit.nro = empresa.sNumero
        teste.infNFE.Emit.EnderEmit.xBairro = empresa.sBairro
        teste.infNFE.Emit.EnderEmit.cMun = empresa.sCodMunIBGE
        teste.infNFE.Emit.EnderEmit.xMun = empresa.sNomeMunic
        teste.infNFE.Emit.EnderEmit.UF = empresa.sSiglaUF
        teste.infNFE.Emit.EnderEmit.CEP = removeFormatacao(empresa.sCEP)
        teste.infNFE.Emit.EnderEmit.cPais = "1058"
        teste.infNFE.Emit.EnderEmit.xPais = "Brasil"
        teste.infNFE.Emit.EnderEmit.fone = removeFormatacao(empresa.Sfone)




        '''''''''''''''''''''''''''''''############################'''''''''''''''''''''''''''

        ''''''''''''''''''''''Rotina abaixo constroi os dados do Destinatario da nfe''''''''''''''
        If cnpj_de <> "99999999000191" Then
            conectar_mysqlDFe()
            Dim SQLcommand3 As MySqlCommand
            SQLcommand3 = oConn.CreateCommand
            SQLcommand3.CommandText = "SELECT * FROM cliente INNER JOIN municipio ON municipio.codigo_municipio = cliente.cod_munic where cnpjcpf_cli ='" & cnpj_de & "'"
            '   dr = SQLcommand.ExecuteReader()

            Using reader As MySqlDataReader = SQLcommand3.ExecuteReader

                While reader.Read
                    If reader("cnpjcpf_cli").ToString.Length = "14" Then
                        teste.infNFE.Dest.CNPJ = reader("cnpjcpf_cli").ToString
                    Else
                        teste.infNFE.Dest.CPF = reader("cnpjcpf_cli").ToString
                    End If

                    teste.infNFE.Dest.xNome = reader("nome_cli").ToString.TrimEnd()
                    teste.infNFE.Dest.EnderDest.xLgr = reader("end_cli").ToString.TrimEnd()
                    teste.infNFE.Dest.EnderDest.nro = reader("numero_cli")
                    teste.infNFE.Dest.EnderDest.xBairro = reader("bairro_cli").ToString.TrimEnd()
                    teste.infNFE.Dest.EnderDest.cMun = reader("cod_munic")
                    teste.infNFE.Dest.EnderDest.xMun = reader("NomeMunic").ToString.TrimEnd()
                    teste.infNFE.Dest.EnderDest.UF = reader("UF")
                    teste.infNFE.Dest.EnderDest.CEP = removeFormatacao(reader("cep_cli"))
                    teste.infNFE.Dest.EnderDest.cPais = "1058"
                    teste.infNFE.Dest.EnderDest.xPais = "Brasil"
                    teste.infNFE.Dest.EnderDest.fone = reader("fone_cli")

                    If reader("ind_dest") = "1" Then
                        teste.infNFE.Dest.IE = reader("ind_dest")
                    End If

                    teste.infNFE.Dest.indIEDest = reader("ierg_cli")
                    teste.infNFE.Dest.email = reader("email")
                End While

            End Using

        Else


            teste.infNFE.Dest.CNPJ = "99999999000191"
            teste.infNFE.Dest.xNome = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL"

            teste.infNFE.Dest.indIEDest = "9"
            txtiedest.Text = ""

            teste.infNFE.Dest.EnderDest.xLgr = "Rua teste"
            teste.infNFE.Dest.EnderDest.nro = "00"
            teste.infNFE.Dest.EnderDest.xBairro = "Bairro teste"

            teste.infNFE.Dest.EnderDest.xMun = "Cidade teste"
            teste.infNFE.Dest.EnderDest.cMun = "3135902"

            teste.infNFE.Dest.EnderDest.UF = "MG"

            teste.infNFE.Dest.EnderDest.CEP = "00000000"


            teste.infNFE.Dest.email = "teste@teste.com"

            teste.infNFE.Dest.EnderDest.cPais = "1058"
            teste.infNFE.Dest.EnderDest.xPais = "Brasil"

        End If
        '''''''''''''''''''''''''''''''############################'''''''''''''''''''''''''''

        ''''''''''''''''''''''Rotina abaixo Para construir os itens da nfe''''''''''''''

        conectar_mysqlDFe()
        Dim SQLcommand4 As MySqlCommand
        SQLcommand4 = oConn.CreateCommand
        SQLcommand4.CommandText = "SELECT * FROM nfe_sitens  where Chave_nfe ='" & chavenfe & "'"
        '   dr = SQLcommand.ExecuteReader()
        Dim n As Integer = 0
        Using reader As MySqlDataReader = SQLcommand4.ExecuteReader

            While reader.Read
                n += 1
                detalhamento = New det()
                detalhamento.nItem = n
                detalhamento.Prod.cProd = reader("codigo_prod")
                detalhamento.Prod.cEAN = reader("cod_barra")
                detalhamento.Prod.cEANTrib = reader("cod_barra")
                If reader("codigo_prod").ToString.Length >= 4 Then
                    If reader("codigo_prod").ToString.Substring(0, 4) <> "CFOP" Then
                        detalhamento.Prod.xProd = ret_valor_campo("select * from produto where codigo_prod =" & reader("codigo_prod") & "", "desc_prod")
                    Else
                        detalhamento.Prod.xProd = ret_valor_campo("select * from natureza_operacao where codigo =" & reader("Nat_op") & "", "descricao")
                    End If
                Else
                    detalhamento.Prod.xProd = ret_valor_campo("select * from produto where codigo_prod =" & reader("codigo_prod") & "", "desc_prod")
                End If

                detalhamento.Prod.NCM = reader("ncm")
                detalhamento.Prod.CFOP = reader("cfop")
                detalhamento.Prod.qCom = reader("qtde").ToString.Replace(",", ".")
                detalhamento.Prod.uCom = reader("un")


                If reader("vlr_desc") <> valor_campo_vazio() Then

                    detalhamento.Prod.vDesc = reader("vlr_desc").ToString.Replace(",", ".")

                End If

                If reader("cest").ToString <> "" Then

                    detalhamento.Prod.CEST = reader("cest")

                End If

                If reader("ncm_ex").ToString <> "" Then

                    detalhamento.Prod.EXTIPI = reader("ncm_ex").ToString.PadLeft(3, "0")

                End If

                If reader("vlr_frete") <> valor_campo_vazio() Then

                    detalhamento.Prod.vFrete = reader("vlr_frete").ToString.Replace(",", ".")
                    '
                End If

                If reader("vlr_outros") <> valor_campo_vazio() Then

                    detalhamento.Prod.vOutro = reader("vlr_outros").ToString.Replace(",", ".")

                End If

                detalhamento.Prod.vUnCom = reader("vlr_unit").ToString.Replace(",", ".")
                detalhamento.Prod.vProd = reader("vlr_totalcdesc").ToString.Replace(",", ".")
                detalhamento.Prod.vUnTrib = reader("vlr_unit").ToString.Replace(",", ".")
                detalhamento.Prod.uTrib = reader("un")
                detalhamento.Prod.qTrib = reader("qtde").ToString.Replace(",", ".")

                If fin = "3" Then
                    detalhamento.Prod.indTot = "0"
                Else
                    detalhamento.Prod.indTot = "1"
                End If

                If reader("lote").ToString <> "" Then
                    DtMed = New rastro
                    DtMed.nLote = reader("lote")
                    DtMed.qLote = reader("qtde").ToString.Replace(",", ".")
                    DtMed.dFab = Now.ToString("yyyy-MM-dd")
                    DtMed.dVal = reader("data_venc")
                    ' DtMed.cAgreg = formatar_valor(dgvgrid_xml.Rows.Item(i).Cells("pmc").Value)
                    detalhamento.Prod.Med.Add(DtMed)
                End If

                If reader("cst").ToString.Length = 3 Then
                    cst = reader("cst").ToString.Substring(1, 2)
                End If

                If reader("cst").ToString.Length = 4 Then
                    cst = reader("cst").ToString.Substring(1, 3)
                End If

                If reader("vlr_aproxtrib") <> valor_campo_vazio() Then
                    detalhamento.Imposto.vTotTrib = reader("vlr_aproxtrib").ToString.Replace(",", ".")
                End If



                If empresa.scod_trib = "3" Then

                    If cst = "60" Then

                        detalhamento.Imposto.Icms = New ICMS()
                        detalhamento.Imposto.Icms.Icms60 = New ICMS60()
                        detalhamento.Imposto.Icms.Icms60.CST = cst
                        detalhamento.Imposto.Icms.Icms60.orig = reader("cst").ToString.Substring(0, 1)

                        If reader("bc_st") <> valor_campo_vazio() Then
                            detalhamento.Imposto.Icms.Icms60.vBCSTRet = reader("bc_st").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms60.vICMSSTRet = reader("vlr_st").ToString.Replace(",", ".")
                        End If

                    End If

                    If cst = "00" Then

                        detalhamento.Imposto.Icms = New ICMS()
                        detalhamento.Imposto.Icms.Icms00 = New ICMS00()
                        detalhamento.Imposto.Icms.Icms00.CST = cst
                        detalhamento.Imposto.Icms.Icms00.orig = reader("cst").ToString.Substring(0, 1)
                        detalhamento.Imposto.Icms.Icms00.modBC = "3"
                        detalhamento.Imposto.Icms.Icms00.vBC = reader("bc_icms").ToString.Replace(",", ".")
                        detalhamento.Imposto.Icms.Icms00.pICMS = reader("aliq_icms").ToString.Replace(",", ".")
                        detalhamento.Imposto.Icms.Icms00.vICMS = reader("vlr_icms").ToString.Replace(",", ".")

                        If reader("pFCP") <> valor_campo_vazio() Then
                            detalhamento.Imposto.Icms.Icms00.pFCP = reader("pFCP").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms00.vFCP = reader("vFCP").ToString.Replace(",", ".")
                        End If

                    End If


                    If cst = "10" Then
                        detalhamento.Imposto.Icms = New ICMS()
                        detalhamento.Imposto.Icms.Icms10 = New ICMS10()
                        detalhamento.Imposto.Icms.Icms10.CST = cst
                        detalhamento.Imposto.Icms.Icms10.orig = reader("cst").ToString.Substring(0, 1)
                        detalhamento.Imposto.Icms.Icms10.modBC = "3"
                        detalhamento.Imposto.Icms.Icms10.vBC = reader("bc_icms").ToString.Replace(",", ".")
                        detalhamento.Imposto.Icms.Icms10.pICMS = reader("aliq_icms").ToString.Replace(",", ".")
                        detalhamento.Imposto.Icms.Icms10.vICMS = reader("vlr_icms").ToString.Replace(",", ".")
                        detalhamento.Imposto.Icms.Icms10.modBCST = "3"

                        If reader("mva") <> valor_campo_vazio() Then
                            detalhamento.Imposto.Icms.Icms10.pMVAST = reader("mva").ToString.Replace(",", ".")
                        End If

                        detalhamento.Imposto.Icms.Icms10.vBCST = reader("bc_st").ToString.Replace(",", ".")
                        detalhamento.Imposto.Icms.Icms10.pICMSST = reader("aliq_st").ToString.Replace(",", ".")
                        detalhamento.Imposto.Icms.Icms10.vICMSST = reader("vlr_st").ToString.Replace(",", ".")

                        If reader("pFCP") <> valor_campo_vazio() Then
                            detalhamento.Imposto.Icms.Icms10.vBCFCP = reader("vBCFCP").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms10.pFCP = reader("pFCP").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms10.vFCP = reader("vFCP").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms10.vBCFCPST = reader("vBCFCPST").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms10.pFCPST = reader("pFCPST").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms10.vFCPST = reader("vFCPST").ToString.Replace(",", ".")
                        End If
                    End If

                    If cst = "20" Then
                        detalhamento.Imposto.Icms = New ICMS()
                        detalhamento.Imposto.Icms.Icms20 = New ICMS20()
                        detalhamento.Imposto.Icms.Icms20.CST = cst
                        detalhamento.Imposto.Icms.Icms20.orig = reader("cst").ToString.Substring(0, 1)
                        detalhamento.Imposto.Icms.Icms20.modBC = "3"

                        If reader("pRedBC") <> valor_campo_vazio() Then
                            detalhamento.Imposto.Icms.Icms20.pRedBC = reader("pRedBC").ToString.Replace(",", ".")
                        End If

                        detalhamento.Imposto.Icms.Icms20.vBC = reader("bc_icms").ToString.Replace(",", ".").ToString.Replace(",", ".")
                        detalhamento.Imposto.Icms.Icms20.pICMS = reader("aliq_icms").ToString.Replace(",", ".")
                        detalhamento.Imposto.Icms.Icms20.vICMS = reader("vlr_icms").ToString.Replace(",", ".")

                        If reader("pFCP") <> valor_campo_vazio() Then
                            detalhamento.Imposto.Icms.Icms10.vBCFCP = reader("vBCFCP").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms10.pFCP = reader("pFCP").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms10.vFCP = reader("vFCP").ToString.Replace(",", ".")
                        End If
                    End If

                    If cst = "30" Then
                        detalhamento.Imposto.Icms = New ICMS()
                        detalhamento.Imposto.Icms.Icms30 = New ICMS30()
                        detalhamento.Imposto.Icms.Icms30.CST = cst
                        detalhamento.Imposto.Icms.Icms30.orig = reader("cst").ToString.Substring(0, 1)
                        detalhamento.Imposto.Icms.Icms30.modBCST = "3"
                        detalhamento.Imposto.Icms.Icms30.pICMSST = reader("aliq_st").ToString.Replace(",", ".")

                        If reader("mva") <> valor_campo_vazio() Then
                            detalhamento.Imposto.Icms.Icms30.pMVAST = reader("mva").ToString.Replace(",", ".")
                        End If
                        If reader("pRedBCST") <> valor_campo_vazio() Then
                            detalhamento.Imposto.Icms.Icms30.pRedBCST = reader("pRedBCST").ToString.Replace(",", ".")
                        End If
                        detalhamento.Imposto.Icms.Icms30.vBCST = reader("bc_st").ToString.Replace(",", ".")
                        detalhamento.Imposto.Icms.Icms30.vICMSST = reader("vlr_st").ToString.Replace(",", ".")

                        If reader("pFCP") <> valor_campo_vazio() Then
                            detalhamento.Imposto.Icms.Icms10.vBCFCPST = reader("vBCFCPST").Value.ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms10.pFCPST = reader("pFCPST").Value.ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms10.vFCPST = reader("vFCPST").Value.ToString.Replace(",", ".")
                        End If
                    End If

                    If cst = "40" Or cst = "41" Or cst = "50" Then
                        detalhamento.Imposto.Icms = New ICMS()
                        detalhamento.Imposto.Icms.Icms40 = New ICMS40()
                        detalhamento.Imposto.Icms.Icms40.CST = cst
                        detalhamento.Imposto.Icms.Icms40.orig = reader("cst").ToString.Substring(0, 1)
                    End If

                    If cst = "51" Then
                        ' detalhamento.Imposto.Icms = New ICMS()
                        '  detalhamento.Imposto.Icms.Icms51 = New ICMS51()
                        '  detalhamento.Imposto.Icms.Icms51.CST = cst
                        '  detalhamento.Imposto.Icms.Icms51.orig = dgvgrid_xml.Rows.Item(i).Cells("cst").Value.ToString.Substring(0, 1)
                        '  detalhamento.Imposto.Icms.Icms51.modBC = "3"
                        '  detalhamento.Imposto.Icms.Icms51.pRedBC = dgvgrid_xml.Rows.Item(i).Cells("pRedBC").Value.Replace(".", ",")
                        '  detalhamento.Imposto.Icms.Icms51.vBC = dgvgrid_xml.Rows.Item(i).Cells("baseicms").Value.Replace(".", ",")
                        '  detalhamento.Imposto.Icms.Icms51.pICMS = dgvgrid_xml.Rows.Item(i).Cells("aliqicms").Value.Replace(".", ",")
                        '  detalhamento.Imposto.Icms.Icms51.vICMS = dgvgrid_xml.Rows.Item(i).Cells("vlricms").Value.Replace(".", ",")
                    End If

                    If cst = "70" Then

                        detalhamento.Imposto.Icms = New ICMS()
                        detalhamento.Imposto.Icms.Icms70 = New ICMS70()
                        detalhamento.Imposto.Icms.Icms70.CST = cst
                        detalhamento.Imposto.Icms.Icms70.orig = reader("cst").ToString.Substring(0, 1)
                        detalhamento.Imposto.Icms.Icms70.modBC = "3"
                        detalhamento.Imposto.Icms.Icms70.modBCST = "3"
                        detalhamento.Imposto.Icms.Icms70.pICMS = reader("aliq_icms").ToString.Replace(",", ".")
                        detalhamento.Imposto.Icms.Icms70.pICMSST = reader("aliq_st").ToString.Replace(",", ".")

                        If reader("mva") <> valor_campo_vazio() Then
                            detalhamento.Imposto.Icms.Icms70.pMVAST = reader("mva").ToString.ToString.Replace(",", ".")
                        End If

                        If reader("pRedBC") <> valor_campo_vazio() Then
                            detalhamento.Imposto.Icms.Icms70.pRedBC = reader("pRedBC").ToString.Replace(",", ".")
                        End If

                        If reader("pRedBCST") <> valor_campo_vazio() Then
                            detalhamento.Imposto.Icms.Icms70.pRedBCST = reader("pRedBCST").ToString.Replace(",", ".")
                        End If

                        detalhamento.Imposto.Icms.Icms70.vBC = reader("bc_icms").ToString.Replace(",", ".")
                        detalhamento.Imposto.Icms.Icms70.vBCST = reader("bc_st").ToString.Replace(",", ".")
                        detalhamento.Imposto.Icms.Icms70.vICMS = reader("vlr_icms").ToString.Replace(",", ".")
                        detalhamento.Imposto.Icms.Icms70.vICMSST = reader("vlr_st").ToString.Replace(",", ".")

                        If reader("vICMSDeson") <> valor_campo_vazio() Then
                            detalhamento.Imposto.Icms.Icms70.vICMSDeson = reader("vICMSDeson").ToString.Replace(",", ".")
                        End If
                        If reader("motDesICMS") <> "" Then
                            detalhamento.Imposto.Icms.Icms70.motDesICMS = reader("motDesICMS")
                        End If

                        If reader("pFCP") <> valor_campo_vazio() Then
                            detalhamento.Imposto.Icms.Icms10.vBCFCP = reader("vBCFCP").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms10.pFCP = reader("pFCP").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms10.vFCP = reader("vFCP").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms10.vBCFCPST = reader("vBCFCPST").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms10.pFCPST = reader("pFCPST").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms10.vFCPST = reader("vFCPST").ToString.Replace(",", ".")
                        End If

                    End If

                    If cst = "90" Then

                        detalhamento.Imposto.Icms = New ICMS()
                        detalhamento.Imposto.Icms.Icms90 = New ICMS90()
                        detalhamento.Imposto.Icms.Icms90.CST = cst
                        detalhamento.Imposto.Icms.Icms90.orig = reader("cst").ToString.Substring(0, 1)
                        detalhamento.Imposto.Icms.Icms90.modBC = "3"

                        If fin <> "3" Then
                            detalhamento.Imposto.Icms.Icms90.modBCST = "3"
                            detalhamento.Imposto.Icms.Icms90.pICMSST = reader("aliq_st").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms90.vBCST = reader("bc_st").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms90.vICMSST = reader("vlr_st").ToString.Replace(",", ".")
                        End If


                        If reader("mva").ToString <> valor_campo_vazio() Then
                            detalhamento.Imposto.Icms.Icms90.pMVAST = reader("mva").ToString.Replace(",", ".")
                        End If


                        If reader("pRedBC").ToString <> valor_campo_vazio() Then
                            detalhamento.Imposto.Icms.Icms90.pRedBC = reader("pRedBC").ToString.Replace(",", ".")
                        End If


                        If reader("pRedBCST").ToString <> valor_campo_vazio() Then
                            detalhamento.Imposto.Icms.Icms90.pRedBCST = reader("pRedBCST").ToString.Replace(",", ".")
                        End If

                        detalhamento.Imposto.Icms.Icms90.vBC = reader("bc_icms").ToString.Replace(",", ".")
                        detalhamento.Imposto.Icms.Icms90.pICMS = reader("aliq_icms").ToString.Replace(",", ".")
                        detalhamento.Imposto.Icms.Icms90.vICMS = reader("vlr_icms").ToString.Replace(",", ".")


                        If reader("vICMSDeson").ToString <> valor_campo_vazio() Then
                            detalhamento.Imposto.Icms.Icms70.vICMSDeson = reader("vICMSDeson").ToString.Replace(",", ".")
                        End If
                        If reader("motDesICMS").ToString <> "" Then
                            detalhamento.Imposto.Icms.Icms70.motDesICMS = reader("motDesICMS")
                        End If


                        If reader("pFCP").ToString <> valor_campo_vazio() Then
                            detalhamento.Imposto.Icms.Icms10.vBCFCP = reader("vBCFCP").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms10.pFCP = reader("pFCP").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms10.vFCP = reader("vFCP").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms10.vBCFCPST = reader("vBCFCPST").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms10.pFCPST = reader("pFCPST").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.Icms10.vFCPST = reader("vFCPST").ToString.Replace(",", ".")
                        End If
                    End If

                End If

                If empresa.scod_trib = "1" Or empresa.scod_trib = "2" Then

                    If cst.Length = "4" Then
                        If cst.Substring(1, 3) = "101" Then
                            detalhamento.Imposto.Icms = New ICMS()
                            detalhamento.Imposto.Icms.ICMSSN101 = New ICMSSN101()
                            detalhamento.Imposto.Icms.ICMSSN101.orig = reader("cst").ToString.Substring(0, 1)
                            detalhamento.Imposto.Icms.ICMSSN101.CSOSN = cst.Substring(1, 3)
                            detalhamento.Imposto.Icms.ICMSSN101.pCredSN = reader("aliq_icms").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.ICMSSN101.vCredICMSSN = reader("vlr_icms").ToString.Replace(",", ".")
                        End If

                        If cst.Substring(1, 3) = "102" Or cst.Substring(1, 3) = "103" Or cst.Substring(1, 3) = "300" Or cst.Substring(1, 3) = "400" Then
                            detalhamento.Imposto.Icms = New ICMS()
                            detalhamento.Imposto.Icms.ICMSSN102 = New ICMSSN102()
                            detalhamento.Imposto.Icms.ICMSSN102.orig = reader("cst").ToString.Substring(0, 1)
                            detalhamento.Imposto.Icms.ICMSSN102.CSOSN = cst.Substring(1, 3)
                        End If

                        If cst.Substring(1, 3) = "201" Then

                            detalhamento.Imposto.Icms = New ICMS()
                            detalhamento.Imposto.Icms.ICMSSN201 = New ICMSSN201()
                            detalhamento.Imposto.Icms.ICMSSN201.CSOSN = cst.Substring(1, 3)
                            detalhamento.Imposto.Icms.ICMSSN201.orig = reader("cst").ToString.Substring(0, 1)
                            detalhamento.Imposto.Icms.ICMSSN201.modBCST = "4"

                            If reader("mva") <> valor_campo_vazio() Then
                                detalhamento.Imposto.Icms.ICMSSN201.pMVAST = reader("mva").ToString.Replace(",", ".")
                            End If

                            detalhamento.Imposto.Icms.ICMSSN201.vBCST = reader("bc_st").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.ICMSSN201.pICMSST = reader("aliq_st").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.ICMSSN201.vICMSST = reader("vlr_st").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.ICMSSN201.pCredSN = reader("aliq_icms").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.ICMSSN201.vCredICMSSN = reader("vlr_icms").ToString.Replace(",", ".")

                            If reader("pRedBCST") <> valor_campo_vazio() Then
                                detalhamento.Imposto.Icms.ICMSSN201.pRedBCST = reader("pRedBCST").ToString.Replace(",", ".")
                            End If

                            If reader("pFCP") <> valor_campo_vazio() Then
                                detalhamento.Imposto.Icms.Icms10.vBCFCPST = reader("vBCFCPST").ToString.Replace(",", ".")
                                detalhamento.Imposto.Icms.Icms10.pFCPST = reader("pFCPST").ToString.Replace(",", ".")
                                detalhamento.Imposto.Icms.Icms10.vFCPST = reader("vFCPST").ToString.Replace(",", ".")
                            End If
                        End If

                        If cst.Substring(1, 3) = "202" Then
                            detalhamento.Imposto.Icms = New ICMS()
                            detalhamento.Imposto.Icms.ICMSSN202 = New ICMSSN202()
                            detalhamento.Imposto.Icms.ICMSSN202.CSOSN = cst.Substring(1, 3)
                            detalhamento.Imposto.Icms.ICMSSN202.orig = reader("cst").ToString.Substring(0, 1)
                            detalhamento.Imposto.Icms.ICMSSN202.modBCST = "4"

                            If reader("mva") <> valor_campo_vazio() Then
                                detalhamento.Imposto.Icms.ICMSSN202.pMVAST = reader("mva").ToString.Replace(",", ".")
                            End If

                            detalhamento.Imposto.Icms.ICMSSN202.vBCST = reader("bc_st").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.ICMSSN202.pICMSST = reader("aliq_st").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.ICMSSN202.vICMSST = reader("vlr_st").ToString.Replace(",", ".")

                            If reader("pFCP") <> valor_campo_vazio() Then
                                detalhamento.Imposto.Icms.Icms10.vBCFCPST = reader("vBCFCPST").ToString.Replace(",", ".")
                                detalhamento.Imposto.Icms.Icms10.pFCPST = reader("pFCPST").ToString.Replace(",", ".")
                                detalhamento.Imposto.Icms.Icms10.vFCPST = reader("vFCPST").ToString.Replace(",", ".")
                            End If
                        End If

                        If cst.Substring(1, 3) = "500" Then
                            detalhamento.Imposto.Icms = New ICMS()
                            detalhamento.Imposto.Icms.ICMSSN500 = New ICMSSN500()
                            detalhamento.Imposto.Icms.ICMSSN500.CSOSN = cst.Substring(1, 3)
                            detalhamento.Imposto.Icms.ICMSSN500.orig = reader("cst").ToString.Substring(0, 1)

                            If reader("vlr_st") <> valor_campo_vazio() Then
                                detalhamento.Imposto.Icms.ICMSSN500.vBCSTRet = reader("bc_st").ToString.Replace(",", ".")
                                detalhamento.Imposto.Icms.ICMSSN500.vICMSSTRet = reader("vlr_st").ToString.Replace(",", ".")
                            End If
                        End If

                        If cst.Substring(1, 3) = "900" Then
                            detalhamento.Imposto.Icms = New ICMS()
                            detalhamento.Imposto.Icms.ICMSSN900 = New ICMSSN900()
                            detalhamento.Imposto.Icms.ICMSSN900.CSOSN = cst
                            detalhamento.Imposto.Icms.ICMSSN900.orig = reader("cst").ToString.Substring(0, 1)
                            detalhamento.Imposto.Icms.ICMSSN900.modBC = "3"
                            detalhamento.Imposto.Icms.ICMSSN900.modBCST = "3"
                            detalhamento.Imposto.Icms.ICMSSN900.pICMS = reader("aliq_icms").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.ICMSSN900.pICMSST = reader("aliq_st").ToString.Replace(",", ".")

                            If reader("mva") <> valor_campo_vazio() Then
                                detalhamento.Imposto.Icms.ICMSSN900.pMVAST = reader("mva").ToString.Replace(",", ".")
                            End If


                            If reader("pRedBC") <> valor_campo_vazio() Then
                                detalhamento.Imposto.Icms.ICMSSN900.pRedBC = reader("pRedBC").ToString.Replace(",", ".")
                            End If


                            If reader("pRedBCST") <> valor_campo_vazio() Then
                                detalhamento.Imposto.Icms.ICMSSN900.pRedBCST = reader("pRedBCST").ToString.Replace(",", ".")
                            End If

                            detalhamento.Imposto.Icms.ICMSSN900.vBC = reader("bc_icms").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.ICMSSN900.vBCST = reader("bc+st").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.ICMSSN900.vICMS = reader("vlr_icms").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.ICMSSN900.vICMSST = reader("vlr_st").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.ICMSSN900.pCredSN = reader("aliq_icms").ToString.Replace(",", ".")
                            detalhamento.Imposto.Icms.ICMSSN900.vCredICMSSN = reader("vlr_icms").ToString.Replace(",", ".")


                            If reader("pFCP") <> valor_campo_vazio() Then
                                detalhamento.Imposto.Icms.Icms10.vBCFCPST = reader("vBCFCPST").ToString.Replace(",", ".")
                                detalhamento.Imposto.Icms.Icms10.pFCPST = reader("pFCPST").ToString.Replace(",", ".")
                                detalhamento.Imposto.Icms.Icms10.vFCPST = reader("vFCPST").ToString.Replace(",", ".")
                            End If
                        End If

                    End If

                End If


                If reader("cst_ipi") = "51" Or reader("cst_ipi") = "52" Or reader("cst_ipi") = "53" Or reader("cst_ipi") = "54" Or reader("cst_ipi") = "55" Or reader("cst_ipi") = "01" Or reader("cst_ipi") = "02" Or reader("cst_ipi") = "03" Or reader("cst_ipi") = "04" Or reader("cst_ipi") = "05" Then
                    detalhamento.Imposto.Ipi = New IPI
                    ' detalhamento.Imposto.Ipi.cSelo = "0"
                    If reader("cst_ipi") = "53" Or reader("cst_ipi") = "51" Then
                        detalhamento.Imposto.Ipi.cEnq = "999"
                    End If

                    If reader("cst_ipi") = "02" Or reader("cst_ipi") = "52" Then
                        detalhamento.Imposto.Ipi.cEnq = "301"
                    End If

                    If reader("cst_ipi") = "04" Or reader("cst_ipi") = "54" Then
                        detalhamento.Imposto.Ipi.cEnq = "001"
                    End If

                    If reader("cst_ipi") = "05" Or reader("cst_ipi") = "55" Then
                        detalhamento.Imposto.Ipi.cEnq = "101"
                    End If

                    detalhamento.Imposto.Ipi.IpiNT = New IPINT()
                    detalhamento.Imposto.Ipi.IpiNT.CST = reader("cst_ipi")
                End If
                If reader("cst_ipi") = "50" Or reader("cst_ipi") = "00" Then

                    detalhamento.Imposto.Ipi = New IPI
                    ' detalhamento.Imposto.Ipi.cSelo = "0"
                    detalhamento.Imposto.Ipi.cEnq = "999"

                    detalhamento.Imposto.Ipi.IpiTrib = New IPITrib()
                    detalhamento.Imposto.Ipi.IpiTrib.CST = reader("cst_ipi")
                    detalhamento.Imposto.Ipi.IpiTrib.vBC = reader("vlr_totalcdesc").ToString.Replace(",", ".")
                    detalhamento.Imposto.Ipi.IpiTrib.pIPI = reader("aliq_ipi").ToString.Replace(",", ".")
                    detalhamento.Imposto.Ipi.IpiTrib.vIPI = reader("vlr_ipi").ToString.Replace(",", ".")
                End If

                pis = reader("cst_pis")

                If pis = "01" Or pis = "02" Or pis = "50" Then
                    detalhamento.Imposto.Pis = New PIS()
                    detalhamento.Imposto.Pis.PisAliq = New PISAliq
                    detalhamento.Imposto.Pis.PisAliq.CST = reader("cst_pis")
                    detalhamento.Imposto.Pis.PisAliq.pPIS = reader("aliq_pis").ToString.Replace(",", ".")
                    detalhamento.Imposto.Pis.PisAliq.vBC = reader("vlr_totalcdesc").ToString.Replace(",", ".")
                    detalhamento.Imposto.Pis.PisAliq.vPIS = reader("vlr_pis").ToString.Replace(",", ".")

                    detalhamento.Imposto.Cofins = New COFINS()
                    detalhamento.Imposto.Cofins.CofinsAliq = New COFINSAliq
                    detalhamento.Imposto.Cofins.CofinsAliq.CST = reader("cst_cofins")
                    detalhamento.Imposto.Cofins.CofinsAliq.pCOFINS = reader("aliq_cofins").ToString.Replace(",", ".")
                    detalhamento.Imposto.Cofins.CofinsAliq.vBC = reader("vlr_totalcdesc").ToString.Replace(",", ".")
                    detalhamento.Imposto.Cofins.CofinsAliq.vCOFINS = reader("vlr_cofins").ToString.Replace(",", ".")
                End If

                If pis = "04" Or pis = "05" Or pis = "06" Or pis = "07" Or pis = "08" Or pis = "09" Then
                    detalhamento.Imposto.Pis = New PIS()
                    detalhamento.Imposto.Pis.PisNT = New PISNT()
                    detalhamento.Imposto.Pis.PisNT.CST = reader("cst_pis")

                    detalhamento.Imposto.Cofins = New COFINS()
                    detalhamento.Imposto.Cofins.CofinsNT = New COFINSNT()
                    detalhamento.Imposto.Cofins.CofinsNT.CST = reader("cst_cofins")

                End If

                If pis = "05" Then
                    If reader("vlr_pis") <> valor_campo_vazio() Then
                        detalhamento.Imposto.PisST = New PISST()
                        detalhamento.Imposto.PisST.vBC = reader("vlr_totalcdesc").ToString.Replace(",", ".")
                        detalhamento.Imposto.PisST.pPIS = reader("aliq_pis").ToString.Replace(",", ".")
                        detalhamento.Imposto.PisST.vPIS = reader("vlr_pis").ToString.Replace(",", ".")
                    End If
                    If reader("vlr_cofins") <> valor_campo_vazio() Then
                        detalhamento.Imposto.CofinsST = New COFINSST()
                        detalhamento.Imposto.CofinsST.vBC = reader("vlr_totalcdesc").ToString.Replace(",", ".")
                        detalhamento.Imposto.CofinsST.pCOFINS = reader("aliq_cofins").ToString.Replace(",", ".")
                        detalhamento.Imposto.CofinsST.vCOFINS = reader("vlr_cofins").ToString.Replace(",", ".")
                    End If
                End If

                If pis = "03" Then
                    detalhamento.Imposto.Pis = New PIS()
                    detalhamento.Imposto.Pis.PisQtd = New PISQtde()
                    detalhamento.Imposto.Pis.PisQtd.CST = reader("cst_pis")
                    '  detalhamento.Imposto.Pis.PisQtd.qBCProd = dgvgrid_xml.Rows.Item(i).Cells("qtde").Value
                    ' detalhamento.Imposto.Pis.PisQtd.vAliqProd = dgvgrid_xml.Rows.Item(i).Cells("aliqpis").Value.Replace(".", ",")
                    detalhamento.Imposto.Pis.PisQtd.vPIS = reader("vlr_pis")

                    detalhamento.Imposto.Cofins = New COFINS()
                    detalhamento.Imposto.Cofins.CofinsQtde = New COFINSQtde()
                    detalhamento.Imposto.Cofins.CofinsQtde.CST = reader("cst_cofins")
                    ' detalhamento.Imposto.Cofins.CofinsQtde.qBCProd = dgvgrid_xml.Rows.Item(i).Cells("qtde").Value
                    ' detalhamento.Imposto.Cofins.CofinsQtde.vAliqProd = dgvgrid_xml.Rows.Item(i).Cells("aliqcofins").Value.Replace(".", ",")
                    detalhamento.Imposto.Cofins.CofinsQtde.vCOFINS = reader("vlr_cofins").ToString.Replace(",", ".")
                End If

                If pis = "49" Or pis = "51 " Or pis = "52" Or pis = "53" Or pis = "54" Or pis = "55" Or pis = "56" Or pis = "60" Or _
                   pis = "61" Or pis = "62" Or pis = "63" Or pis = "64" Or pis = "65" Or pis = "66" Or pis = "67" Or pis = "70" Or pis = "71" _
                  Or pis = "72" Or pis = "73" Or pis = "74" Or pis = "75" Or pis = "98" Or pis = "99" Then

                    detalhamento.Imposto.Pis = New PIS()
                    detalhamento.Imposto.Pis.PisOutr = New PISOutr
                    detalhamento.Imposto.Pis.PisOutr.CST = reader("cst_pis")

                    If reader("vlr_pis") = valor_campo_vazio() Then
                        detalhamento.Imposto.Pis.PisOutr.vBC = "0.00"
                    Else
                        detalhamento.Imposto.Pis.PisOutr.vBC = reader("vlr_totalcdesc")
                    End If

                    detalhamento.Imposto.Pis.PisOutr.pPIS = reader("aliq_pis").ToString.Replace(",", ".")
                    detalhamento.Imposto.Pis.PisOutr.vPIS = reader("vlr_pis").ToString.Replace(",", ".")

                    detalhamento.Imposto.Cofins = New COFINS()
                    detalhamento.Imposto.Cofins.CofinsOutr = New COFINSOutr
                    detalhamento.Imposto.Cofins.CofinsOutr.CST = reader("cst_cofins")
                    detalhamento.Imposto.Cofins.CofinsOutr.pCOFINS = reader("aliq_cofins").ToString.Replace(",", ".")

                    If reader("vlr_pis") = valor_campo_vazio() Then
                        detalhamento.Imposto.Cofins.CofinsOutr.vBC = "0.00"
                    Else
                        detalhamento.Imposto.Cofins.CofinsOutr.vBC = reader("vlr_totalcdesc").ToString.Replace(",", ".")
                    End If


                    detalhamento.Imposto.Cofins.CofinsOutr.vCOFINS = reader("vlr_cofins").ToString.Replace(",", ".")
                End If

                If pis = "03" Then
                    detalhamento.Imposto.Pis = New PIS()
                    detalhamento.Imposto.Pis.PisQtd = New PISQtde
                    detalhamento.Imposto.Pis.PisQtd.CST = reader("cst_pis")
                    detalhamento.Imposto.Pis.PisQtd.qBCProd = reader("qtde").ToString.Replace(",", ".")
                    detalhamento.Imposto.Pis.PisQtd.vAliqProd = reader("aliq_pis").ToString.Replace(",", ".")
                    detalhamento.Imposto.Pis.PisQtd.vPIS = reader("vlr_pis").ToString.Replace(",", ".")

                    detalhamento.Imposto.Cofins = New COFINS()
                    detalhamento.Imposto.Cofins.CofinsQtde = New COFINSQtde
                    detalhamento.Imposto.Cofins.CofinsQtde.CST = reader("cst_cofins")
                    detalhamento.Imposto.Cofins.CofinsQtde.qBCProd = reader("qtde").ToString.Replace(",", ".")
                    detalhamento.Imposto.Cofins.CofinsQtde.vAliqProd = reader("aliq_cofins").ToString.Replace(",", ".")
                    detalhamento.Imposto.Cofins.CofinsQtde.vCOFINS = reader("vlr_cofins").ToString.Replace(",", ".")
                End If

                If fin <> "3" Then

                    If reader("vBCUFDest") <> valor_campo_vazio() Then
                        detalhamento.Imposto.ICMSUFDest = New ICMSUFDest()
                        detalhamento.Imposto.ICMSUFDest.vBCUFDest = reader("vBCUFDest").ToString.Replace(",", ".")
                        detalhamento.Imposto.ICMSUFDest.pFCPUFDest = reader("pFCPUFDest").ToString.Replace(",", ".")
                        detalhamento.Imposto.ICMSUFDest.pICMSUFDest = reader("pICMSUFDest").ToString.Replace(",", ".")
                        detalhamento.Imposto.ICMSUFDest.pICMSInter = reader("pICMSInter").ToString.Replace(",", ".")

                        detalhamento.Imposto.ICMSUFDest.pICMSInterPart = reader("pICMSInterPart").ToString.Replace(",", ".")
                        detalhamento.Imposto.ICMSUFDest.vFCPUFDest = reader("vFCPUFDest").ToString.Replace(",", ".")

                        detalhamento.Imposto.ICMSUFDest.vICMSUFRemet = reader("vICMSUFRemet").ToString.Replace(",", ".")
                        detalhamento.Imposto.ICMSUFDest.vICMSUFDest = reader("vICMSUFDest").ToString.Replace(",", ".")
                    End If
                End If

                teste.infNFE.Det.Add(detalhamento)
            End While

        End Using


        Dim vtot As String, indPag As String, inf_ad As String, inf_adf As String
        conectar_mysqlDFe()
        Dim SQLcommand5 As MySqlCommand
        SQLcommand5 = oConn.CreateCommand
        SQLcommand5.CommandText = "select * from nfe_s where Chave_nfe ='" & chavenfe & "'"
        '   dr = SQLcommand.ExecuteReader()
        Dim modfrete As String
        Using reader As MySqlDataReader = SQLcommand5.ExecuteReader

            While reader.Read

                '''''''''''''''''''''''Inicia A tag da VALORES TOTAIS
                teste.infNFE.Total = New total()
                teste.infNFE.Total.IcmsTot = New ICMSTot()
                teste.infNFE.Total.IcmsTot.vBC = reader("Valor_BCICMS").ToString.Replace(",", ".")
                teste.infNFE.Total.IcmsTot.vICMS = reader("Valor_ICMS").ToString.Replace(",", ".")
                teste.infNFE.Total.IcmsTot.vICMSDeson = "0.00"

                If reader("vFCPUFDest") <> valor_campo_vazio() Then
                    teste.infNFE.Total.IcmsTot.vFCPUFDest = reader("vFCPUFDest").ToString.Replace(",", ".")
                End If
                If reader("vICMSUFDest") <> valor_campo_vazio() Then
                    teste.infNFE.Total.IcmsTot.vICMSUFDest = reader("vICMSUFDest").ToString.Replace(",", ".")
                End If
                If reader("vICMSUFRemet") <> valor_campo_vazio() Then
                    teste.infNFE.Total.IcmsTot.vICMSUFRemet = reader("vICMSUFRemet").ToString.Replace(",", ".")
                End If


                teste.infNFE.Total.IcmsTot.vFCP = reader("vFCP").ToString.Replace(",", ".")
                teste.infNFE.Total.IcmsTot.vFCPST = reader("vFCPST").ToString.Replace(",", ".")
                teste.infNFE.Total.IcmsTot.vFCPSTRet = reader("vFCPSTRet").ToString.Replace(",", ".")

                teste.infNFE.Total.IcmsTot.vIPIDevol = "0.00"

                teste.infNFE.Total.IcmsTot.vBCST = reader("Valor_BCICMSST").ToString.Replace(",", ".")
                teste.infNFE.Total.IcmsTot.vST = reader("Valor_ICMSST").ToString.Replace(",", ".")
                teste.infNFE.Total.IcmsTot.vProd = reader("Valor_total_prod").ToString.Replace(",", ".")
                teste.infNFE.Total.IcmsTot.vFrete = reader("Valor_frete_nfe").ToString.Replace(",", ".")
                vtot = reader("Valor_total_nfe").ToString.Replace(",", ".")
                indPag = reader("indPag")
                inf_ad = reader("inf_comp")
                inf_adf = reader("inf_comp_fisc")
                teste.infNFE.Total.IcmsTot.vSeg = reader("Valor_seguro").ToString.Replace(",", ".")
                teste.infNFE.Total.IcmsTot.vDesc = reader("Valor_desc").ToString.Replace(",", ".")
                teste.infNFE.Total.IcmsTot.vII = "0.00"
                teste.infNFE.Total.IcmsTot.vIPI = reader("Valor_ipi").ToString.Replace(",", ".")
                teste.infNFE.Total.IcmsTot.vPIS = reader("Valor_pis").ToString.Replace(",", ".")
                teste.infNFE.Total.IcmsTot.vCOFINS = reader("Valor_cofins").ToString.Replace(",", ".")
                teste.infNFE.Total.IcmsTot.vOutro = reader("Valor_outros").ToString.Replace(",", ".")
                teste.infNFE.Total.IcmsTot.vNF = reader("Valor_total_nfe").ToString.Replace(",", ".")
                If reader("vTotTrib").ToString <> "" Then
                    teste.infNFE.Total.IcmsTot.vTotTrib = reader("vTotTrib").ToString.Replace(",", ".")
                End If
                ''''''''''''''''''''''''''''#######################################'''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                '''''''''''''''''Inicia a TAG da TRANSPORTADORA
                teste.infNFE.Transp = New transp()
                teste.infNFE.Transp.modFrete = reader("mod_frete")
                modfrete = reader("mod_frete")
            End While

        End Using

        conectar_mysqlDFe()
        Dim SQLcommand6 As MySqlCommand
        SQLcommand6 = oConn.CreateCommand
        SQLcommand6.CommandText = "SELECT * FROM cliente INNER JOIN municipio ON municipio.codigo_municipio = cliente.cod_munic where cnpjcpf_cli ='" & cnpj_tr & "'"
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand6.ExecuteReader

            While reader.Read
                If modfrete <> "9" Then

                    teste.infNFE.Transp.Transporta = New transporta()

                    If reader("cnpjcpf_cli").ToString.Length = "14" Then

                        teste.infNFE.Transp.Transporta.CNPJ = removeFormatacao(reader("cnpjcpf_cli"))

                    End If

                    If reader("cnpjcpf_cli").ToString.Length = "11" Then

                        teste.infNFE.Transp.Transporta.CPF = removeFormatacao(reader("cnpjcpf_cli"))

                    End If

                    teste.infNFE.Transp.Transporta.xNome = reader("nome_cli").ToString.TrimEnd()
                    teste.infNFE.Transp.Transporta.IE = removeFormatacao(reader("ierg_cli").ToString)
                    teste.infNFE.Transp.Transporta.xEnder = reader("end_cli") & ", " & reader("numero_cli") & ", " & reader("bairro_cli")
                    teste.infNFE.Transp.Transporta.xMun = reader("NomeMunic").ToString.TrimEnd()
                    teste.infNFE.Transp.Transporta.UF = reader("UF").ToString

                End If
            End While

        End Using




        ' If txtplacatrp.Text <> "" Then
        'teste.infNFE.Transp.VeicTransp = New veicTransp()
        ' teste.infNFE.Transp.VeicTransp.placa = txtplacatrp.Text
        '  teste.infNFE.Transp.VeicTransp.UF = txtufplacatrp.Text
        '  If txtantt.Text <> "" Then
        'teste.infNFE.Transp.VeicTransp.RNTC = txtantt.Text
        '   End If
        'End If

        conectar_mysqlDFe()
        Dim SQLcommand7 As MySqlCommand
        SQLcommand7 = oConn.CreateCommand
        SQLcommand7.CommandText = "SELECT * FROM nfe_stransp where Chave_nfe ='" & chavenfe & "'"
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand7.ExecuteReader

            While reader.Read
                teste.infNFE.Transp.Vol = New vol()
                If reader("qtde").ToString <> "" Then
                    teste.infNFE.Transp.Vol.qVol = reader("qtde")
                End If
                If reader("esp").ToString <> "" Then
                    teste.infNFE.Transp.Vol.esp = reader("esp")
                End If
                If reader("n_vol").ToString <> "" Then
                    teste.infNFE.Transp.Vol.nVol = reader("n_vol")
                End If
                If reader("marca").ToString <> "" Then
                    teste.infNFE.Transp.Vol.marca = reader("marca")
                End If
                If reader("peso_b").ToString <> "" Then
                    'txtpesob.Text = Format(CDec(txtpesob.Text), "0.000")
                    teste.infNFE.Transp.Vol.pesoB = reader("peso_b").ToString.Replace(",", ".")
                End If
                If reader("peso_l").ToString <> "" Then
                    ' txtpesol.Text = Format(CDec(txtpesol.Text), "0.000")
                    teste.infNFE.Transp.Vol.pesoL = reader("peso_l").ToString.Replace(",", ".")
                End If
            End While

        End Using

        ''''''''''''''''''''''''''''#######################################'''''''''''''''''''''''''''''''''''''''''''''''''''''''''





        ''''''''''''''''''''''''''''''''''Rotina para gerar duplicata'''''''''''''''''''''''''''''''
        Dim ret As Integer = executa_query("SELECT COUNT(*) as Chave_nfe FROM nfe_sfat")

        If indPag = "14" Then
            conectar_mysqlDFe()
            Dim SQLcommand8 As MySqlCommand
            SQLcommand8 = oConn.CreateCommand
            SQLcommand8.CommandText = "SELECT * FROM nfe_sfat where Chave_nfe ='" & chavenfe & "'"
            '   dr = SQLcommand.ExecuteReader()
            Dim cobranca As New cobr()

            Dim DUPLICATA As New dup

            Using reader As MySqlDataReader = SQLcommand8.ExecuteReader

                While reader.Read
                    DUPLICATA = New dup
                    DUPLICATA.dVenc = reader("data_venc")
                    DUPLICATA.nDup = reader("ndup")
                    DUPLICATA.vDup = reader("vlr_dup")

                    cobranca.Dup.Add(DUPLICATA)
                End While
            End Using

            teste.infNFE.Cobr = cobranca
        End If

        teste.infNFE.pag = New pag()
        teste.infNFE.pag.detPag = New detPag()
        teste.infNFE.pag.detPag.tPag = indPag
        teste.infNFE.pag.detPag.vPag = vtot

        ''''''''''''''''''''''''''''#######################################'''''''''''''''''''''''''''''''''''''''''''''''''''''''''





        ''''''''''''''''''''''''''''''''''Rotina Informações complementres'''''''''''''''''''''''''''''''
        Dim Informacoes As New infAdic

        Informacoes.infAdFisco = inf_ad
        Informacoes.infCpl = inf_adf

        teste.infNFE.InfAdic = Informacoes


        'Gera o XML não assinado
        Dim xmlGerado As XmlDocument = teste.GerarXML()



        ' busca o cetificaod se não tiver sido selecionado
        If nfecer = "" Then
            certificado = SelecionarCertificado("")
        Else
            certificado = SelecionarCertificado(nfecer)
        End If


        'assina o xml para enviar para SEFAZ
        Dim xmlAssinado As XmlDocument = CertificadoDigital.Assinar(xmlGerado, "infNFe", certificado)

        'Valida o XML assinado
        Dim resultado As String = ValidaXML.ValidarXML(xmlAssinado, Application.StartupPath & "\Esquemas_XML_NF-e\nfe_v4.00.xsd")

        If resultado.Trim().Length = 0 Then
            '  MsgBox("XML da Nota Fiscal Gerado com Sucesso !" + vbCrLf + "Nota Fiscal pronta para ser Transmitida para SEFAZ", MsgBoxStyle.Information, "Aviso")
        End If

        '''''''''''''''''''''''''''''''Rotina para verificar pasta destino
        If Directory.Exists(Application.StartupPath & "\XML\NFE") = False Then
            Directory.CreateDirectory(Application.StartupPath & "\XML\NFE")
        End If

        If resultado.Trim().Length = 0 Then
            ' MsgBox("XML da Nota Fiscal Valido de acordo com estrutura da RFB", MsgBoxStyle.Information, "Aviso")
        End If
        xmlGerado.Save(Application.StartupPath & "\XML\NFE\" & cnpj_cert & "-" & Now.Date.ToString("dd-MM-yyyy") & "-XMLNaoAssinado.xml")
        If resultado.Trim().Length <> 0 Then
            MsgBox(resultado, MsgBoxStyle.Exclamation, "Aviso !")
            MsgBox("XML da Nota  Fiscal Invalido !!!", MsgBoxStyle.Critical, "Aviso Ret !")
            xmlGerado.Save(Application.StartupPath & "\XML\NFE\" & cnpj_cert & "-" & Now.Date.ToString("dd-MM-yyyy") & "-XMLNaoAssinado.xml")

            Dim frmVisualizarcs As frmvisualizar_xml = New frmvisualizar_xml(xmlGerado.OuterXml)

            frmVisualizarcs.ShowDialog()
        End If

        '''''''sai da rotina
        '  Exit Sub

        'Opcional - Função para gerar o Lote e deixar o arquivo pronto para ser enviado.

        teste.GerarLoteNfe(xmlAssinado)


        Using xmltw As New XmlTextWriter(Application.StartupPath & "\XML\NFE\" + chavenfe + " - EnviNFe.xml", New UTF8Encoding(False))
            xmlAssinado.WriteTo(xmltw)
            xmltw.Close()
        End Using


        xmldoc.Load(Application.StartupPath & "\XML\NFE\" + chavenfe + " - EnviNFe.xml")

        executa_query("update nfe_s set xml = '" & Base64Encode(xmldoc.OuterXml) & "' where Chave_nfe = '" & chavenfe & "'")

        If tpemi = "6" Then
            If chavenfe.Substring(34, 1) = "1" Then
                executa_query("update nfe_s set Chave_nfe = '" & chave_cont & "' where Chave_nfe = '" & chavenfe & "'")
                executa_query("update nfe_sitens set Chave_nfe = '" & chave_cont & "' where Chave_nfe = '" & chavenfe & "'")
                executa_query("update nfe_secf set Chave_nfe = '" & chave_cont & "' where Chave_nfe = '" & chavenfe & "'")
                executa_query("update nfe_sfat set Chave_nfe = '" & chave_cont & "' where Chave_nfe = '" & chavenfe & "'")
                executa_query("update nfe_snfce set Chave_nfe = '" & chave_cont & "' where Chave_nfe = '" & chavenfe & "'")
                executa_query("update nfe_stransp set Chave_nfe = '" & chave_cont & "' where Chave_nfe = '" & chavenfe & "'")
                Try
                    dgvpisquisa.CurrentRow.Cells("chave_nfe").Value = chave_cont
                Catch ex As Exception

                End Try
            End If
        End If


        ' File.Delete(Application.StartupPath & "\XML\NFE\" + chavenfe + " - EnviNFe.xml")

    End Sub

    Private Sub carregar_empresa(ByVal cnpj_e As String)
        conectar_mysqlDFe()
        Dim SQLcommand2 As MySqlCommand
        SQLcommand2 = oConn.CreateCommand
        SQLcommand2.CommandText = "SELECT * FROM empresa INNER JOIN municipio ON municipio.codigo_municipio = empresa.cod_munic where empresa.cnpj_emp ='" & cnpj_e & "'"
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand2.ExecuteReader

            While reader.Read
                empresa.sCNPJ = cnpj_e
                empresa.sNomeRazao = reader("razao_emp")
                empresa.sNomefant = reader("Nome_fantasia")
                empresa.sIe = reader("ie_emp")
                empresa.sIest = reader("Insc_st")
                empresa.Scnae = reader("cnae_emp")
                empresa.sInscrMunic = reader("im_emp")
                empresa.scod_trib = reader("reg_trib")
                empresa.send = reader("end_emp").ToString.TrimEnd()
                empresa.sNumero = reader("numero_emp")
                empresa.sBairro = reader("bairro_emp").ToString.TrimEnd()
                empresa.sCodMunIBGE = reader("cod_munic")
                empresa.sNomeMunic = reader("NomeMunic").ToString.TrimEnd()
                empresa.sSiglaUF = reader("UF").ToString.TrimEnd()
                empresa.sCEP = removeFormatacao(reader("cep_emp"))
                empresa.Sfone = removeFormatacao(reader("fone_emp"))
                empresa.saliq_simples = reader("aliq_simples")
            End While

        End Using
    End Sub

    Private Sub GerarXMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GerarXMLToolStripMenuItem.Click
        If dgvpisquisa.CurrentRow.Cells("cstatgrid").Value = "100" Then
            MsgBox("Nota Fiscal Já transmitida !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        gera_xmlnfe(dgvpisquisa.CurrentRow.Cells("chave_nfe").Value, "6")

        Control.CheckForIllegalCrossThreadCalls = False
        rotina2 = New Thread(AddressOf env_cont)
        rotina2.SetApartmentState(ApartmentState.STA)

        rotina2.Start()
    End Sub

    Private Function gerar_chave_acesso_cont(ByVal chave As String) As String

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from nfe_s where Chave_nfe ='" & chave & "'"
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read
                Dim chars = "0123456789"
                Dim random = New Random()
                Dim cNF = New String(Enumerable.Repeat(chars, 8).[Select](Function(s) s(random.[Next](s.Length))).ToArray())
                ''''''''''''''''''''''Rotina abaixo constroi a chave de acesso da nfe''''''''''''''
                Dim _codUF As String = "31"
                Dim _dEmi As String = Now.ToString("yyMM")
                Dim _cnpj As String = reader("cnpj_emi")
                Dim _mod As String = reader("Modelo_nfe")
                Dim _tpEmis As String = "6"
                Dim _serie As String = String.Format("{0:000}", Int32.Parse(reader("Serie_nfe")))
                Dim _numNF As String = String.Format("{0:000000000}", Int32.Parse(reader("Numero_nfe")))
                Dim _codigo As String = String.Format("{0:00000000}", Int32.Parse(cNF))
                Dim chaveNF As String = _codUF + _dEmi + _cnpj + _mod + _serie + _numNF + _tpEmis + _codigo

                Dim _dv As Integer = funcoesNfe.modulo11(chaveNF)

                Return chaveNF + _dv.ToString()
            End While

        End Using

    End Function

    Private Sub env_cont()
        Invoke(Sub() Pinfo.Visible = True)
        Invoke(Sub() txtinfo.Text = "Aguarde, enviando NFe Contigência SEFAZ...")
        Invoke(Sub() txtinfo.Refresh())
        Invoke(Sub() Pinfo.Refresh())

        Dim recibo As String

        Try
            If ret_valor_campo("select * from nfe_s where Chave_nfe = '" & dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "'", "xmotivo").ToString.Substring(0, 8) <> "Rejeicao" Then
                recibo = ret_valor_campo("select * from nfe_s where Chave_nfe = '" & dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "'", "nrecibo")
            End If

        Catch ex As Exception

        End Try

    
        If ret_valor_campo("select * from nfe_s where Chave_nfe = '" & dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "'", "cstat") = "217" Then
            recibo = ""
        End If

        If ret_valor_campo("select * from nfe_s where Chave_nfe = '" & dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "'", "cstat") = "105" Then
            recibo = ret_valor_campo("select * from nfe_s where Chave_nfe = '" & dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "'", "nrecibo")
        End If
       
        envia_nfecont(dgvpisquisa.CurrentRow.Cells("chave_nfe").Value, Base64Decode(ret_valor_campo("select * from nfe_s where Chave_nfe = '" & dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "'", "xml")), empresa.ambiente_nfe, recibo)

    End Sub

    Private Sub envia_nfecont(ByVal nchave As String, ByVal xml As String, ByVal ambiente As String, nrecibo As String)
        Dim WebS As New C_WebService
        Dim retEnviNFe As retEnviNFe
        Dim retConsReciNFe As retConsReciNFe
        Dim retConsSitNFe As retConsSitNFe


        If nrecibo = "" Then
            xmldoc.LoadXml(xml)

            retEnviNFe = WebS.EnviaLote4(xmldoc, nchave, ambiente)

            Try

           
                If Not retEnviNFe.infRec Is Nothing Then
                    If Not retEnviNFe.infRec.nRec Is Nothing Then
                        nrecibo = retEnviNFe.infRec.nRec
                        executa_query("update nfe_s set nrecibo = '" & nrecibo & "', Status_nfe = 'NFe enviada SEFAZ' where Chave_nfe = '" & nchave & "'")
                        Invoke(Sub() dgvpisquisa.CurrentRow.Cells("status_NFe").Value = "NFe enviada SEFAZ")
                    End If
                Else
                    Tretnfe.Dispose()
                    MsgBox(retEnviNFe.cStat & "-" & retEnviNFe.xMotivo, MsgBoxStyle.Exclamation, "Aviso Envio !")
                    Invoke(Sub() dgvpisquisa.CurrentRow.Cells("status_NFe").Value = retEnviNFe.cStat & "-" & retEnviNFe.xMotivo)
                End If

            Catch ex As Exception
                Tretnfe.Dispose()
                MsgBox(reterro, MsgBoxStyle.Exclamation, "Aviso erro 1 !")
                Invoke(Sub() dgvpisquisa.CurrentRow.Cells("status_NFe").Value = reterro)
            End Try

        End If

        '''''''''''''''''Rotina abaixo busca o retorno do webservice retnfe
        If nrecibo <> "" Then

            Invoke(Sub() Pinfo.Visible = True)
            Invoke(Sub() txtinfo.Text = "Aguarde, Consultando Recibo NFe Contigencia na SEFAZ ...")
            Invoke(Sub() txtinfo.Refresh())
            Invoke(Sub() Pinfo.Refresh())

            ''''''''''Rotina para consultar retorno envia xml para a SEFAZ'''''''''''''''''''''''''''''
            retConsReciNFe = WebS.ConsultaRecLote(nrecibo, ambiente, nchave)

            Try
                If retConsReciNFe.cStat = "104" Then


                    If retConsReciNFe.protNFe.infProt.cStat = "100" Then

                        If xml <> "" Then
                            Dim dados As XmlDocument = New XmlDocument
                            dados = GerarNotaProcessadanfce(SepararNota_tagnfe(xmldoc.OuterXml), retConsReciNFe.xmlprot)
                            '''''''''''''''''''''''''''Salva info no banco''''''''''''''''''''''''''
                            executa_query("update nfe_s set xmotivo = '" & retConsReciNFe.protNFe.infProt.xMotivo & "', cstat = '" & retConsReciNFe.protNFe.infProt.cStat & "', xml = '" & Base64Encode(dados.OuterXml) & "', nprot = '" & retConsReciNFe.protNFe.infProt.nProt & "',  Status_nfe = 'NFe autorizada'  where Chave_nfe = '" & nchave & "'")

                            '''''''''''''''''''''Salvar arquivo ma pasta''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                            Dim Path As String = Application.StartupPath & "\NFe"
                            If Not Directory.Exists(Path) Then Directory.CreateDirectory(Path)

                            dados.Save(Path & "\NFe-" & retConsReciNFe.protNFe.infProt.chNFe & ".xml")
                        End If

                        ' retConsReciNFe.protNFe.infProt.cStat
                        Tretnfe.Dispose()
                        MsgBox("Nota Fiscal Autorizada !" & vbCrLf & retConsReciNFe.protNFe.infProt.xMotivo & vbCrLf & "Protocolo Aut.: " & retConsReciNFe.protNFe.infProt.nProt, MsgBoxStyle.Information, "Aviso !")

                        Invoke(Sub() dgvpisquisa.CurrentRow.Cells("status_NFe").Value = "NFe autorizada")
                    Else

                        If retConsReciNFe.protNFe.infProt.cStat = "204" Then

                            Dim nPost As Int32 = retConsReciNFe.protNFe.infProt.xMotivo.IndexOf("nRec:")
                            Dim rec As String = retConsReciNFe.protNFe.infProt.xMotivo.Substring(nPost + 5, retConsReciNFe.protNFe.infProt.xMotivo.Length - nPost - 6).Trim
                            nrecibo = rec
                            executa_query("update nfe_s set nrecibo = '" & rec & "' where Chave_nfe = '" & nchave & "'")

                        End If
                        Tretnfe.Dispose()
                        MsgBox(retConsReciNFe.protNFe.infProt.cStat & "-" & retConsReciNFe.protNFe.infProt.xMotivo, MsgBoxStyle.Exclamation, "Aviso !")

                        Invoke(Sub() dgvpisquisa.CurrentRow.Cells("status_NFe").Value = retConsReciNFe.protNFe.infProt.cStat & "-" & retConsReciNFe.protNFe.infProt.xMotivo)
                        '''''''''''''''''''''''''''Salva info no banco''''''''''''''''''''''''''
                        executa_query("update nfe_s set nrecibo = '" & nrecibo & "', cStat = '" & retConsReciNFe.protNFe.infProt.cStat & "',  xmotivo = '" & retConsReciNFe.protNFe.infProt.xMotivo & "', Status_nfe = '" & retConsReciNFe.protNFe.infProt.xMotivo & "'  where Chave_nfe = '" & nchave & "'")

                    End If

                Else


                    If retConsReciNFe.cStat = "105" Then
                        executa_query("update nfe_s set xmotivo = '" & retConsReciNFe.xMotivo & "', cstat = '" & retConsReciNFe.cStat & "'  where Chave_nfe = '" & nchave & "'")
                        Invoke(Sub() Tretnfe.Enabled = True)
                    Else
                        MsgBox(retConsReciNFe.cStat & "-" & retConsReciNFe.xMotivo, MsgBoxStyle.Exclamation, "Aviso !")
                        Invoke(Sub() dgvpisquisa.CurrentRow.Cells("status_NFe").Value = retConsReciNFe.cStat & "-" & retConsReciNFe.xMotivo)
                        executa_query("update nfe_s set xmotivo = '" & retConsReciNFe.xMotivo & "', cstat = '" & retConsReciNFe.cStat & "'  where Chave_nfe = '" & nchave & "'")

                    End If

                End If

            Catch ex As Exception
                Tretnfe.Dispose()
                Pinfo.Visible = False
                MsgBox(reterro, MsgBoxStyle.Exclamation, "Aviso RetConsulta !")
                Invoke(Sub() dgvpisquisa.CurrentRow.Cells("status_NFe").Value = reterro)
            End Try

        End If
        Invoke(Sub() Pinfo.Visible = False)
        ' pesquisar_nfe()
    End Sub


    Private Sub COnsultaReciboNFeSEFAZToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles danfeToolStripMenuItem.Click

        If dgvpisquisa.CurrentRow.Cells("cstatgrid").Value = "100" Then
            frmxml_nfe.danfe_new(Base64Decode(ret_valor_campo("select * from nfe_s where Chave_nfe = '" & dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "'", "xml")))
        End If
    End Sub

    Private Sub Tretnfe_Tick(sender As Object, e As EventArgs) Handles Tretnfe.Tick
       
        If ret_valor_campo("select * from nfe_s where Chave_nfe = '" & dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "'", "cstat") = "105" Then

            envia_nfecont(dgvpisquisa.CurrentRow.Cells("chave_nfe").Value, Base64Decode(ret_valor_campo("select * from nfe_s where Chave_nfe = '" & dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "'", "xml")), empresa.ambiente_nfe, ret_valor_campo("select * from nfe_s where Chave_nfe = '" & dgvpisquisa.CurrentRow.Cells("chave_nfe").Value & "'", "nrecibo"))

        End If



        Tretnfe.Dispose()


    End Sub

 
    Private Sub txtnome_TextChanged(sender As Object, e As EventArgs) Handles txtnome.TextChanged

    End Sub
End Class
