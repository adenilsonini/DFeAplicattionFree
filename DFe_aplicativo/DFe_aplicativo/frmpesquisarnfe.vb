Imports System.Threading
Imports System.Xml
Imports System.Text
Imports System.Data.OleDb
Imports System.Data.SQLite
Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.Net.Mail

Public Class frmpesquisarnfe
    Dim urlsite As String = "http://doka.sytes.net"
    Dim mensagem As String
    Dim mail As New MailMessage()
    Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")
    Public bytePicData() As Byte
    Dim datai As Date, dataf As Date
    Dim xmldoc As New XmlDocument()
    Dim xmlnsManager As New XmlNamespaceManager(xmldoc.NameTable)
    Private Sub cbotipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbotipo.SelectedIndexChanged
        If cbotipo.Text = "Nome do Fornecedor" Then
            txtpar.Text = "Nome_emi"
            txtpesquisa.Focus()
            lblinfo.Visible = True
        End If

        If cbotipo.Text = "CNPJ Fornecedor" Then
            txtpar.Text = "Cnpj_emi"
            txtpesquisa.Focus()
            lblinfo.Visible = True
        End If

        If cbotipo.Text = "Valor NFe" Then
            txtpar.Text = "Valor_nfe"
            txtpesquisa.Focus()
            lblinfo.Visible = True
        End If

        If cbotipo.Text = "Numero NFe" Then
            txtpar.Text = "Numero_nfe"
            txtpesquisa.Focus()
            lblinfo.Visible = True
        End If

        If cbotipo.Text = "Chave de Acesso NFe" Then
            txtpar.Text = "Chave_nfe"
            txtpesquisa.Focus()
            lblinfo.Visible = False
        End If

        If cbotipo.Text = "Caixa-NFCe" Then
            txtpesquisa.Enabled = True
            txtpesquisa.Focus()
        End If

        If cbotipo.Text = "Serie-NFCe" Then
            txtpesquisa.Enabled = True
            txtpesquisa.Focus()
        End If

        If cbotipop.Text = "NFe" Then

            If cbotipo.Text = "Entre Datas" Or cbotipo.Text = "NFe nao lancada" Then
                Paneldata.Enabled = True
                txtpesquisa.Enabled = False
            Else
                Paneldata.Enabled = False
                txtpesquisa.Enabled = True
            End If
        Else
            Paneldata.Enabled = True
            txtpesquisa.Enabled = True
            txtpesquisa.Focus()
        End If

    End Sub

    Private Sub txtpesquisa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpesquisa.KeyPress
        If (e.KeyChar = Chr(13)) Then

            If cbotipop.Text = "NF-e" Then
                Pinfo.Visible = True
                txtinfo.Visible = True
                txtinfo.Text = "Aguarde, o sistema esta pesquisando a NF-e Informada..."
                txtinfo.Refresh()
                Pinfo.Refresh()

                pesquisar_sql()
            Else

                Pinfo.Visible = True
                txtinfo.Visible = True
                lblinfo.Text = "Aguarde, o sistema esta pesquisando a NFC-e Informada..."
                txtinfo.Refresh()
                Pinfo.Refresh()

                pesquisar_nfce()

            End If

        End If
    End Sub

    Private Sub pesquisar_nfce()
        Dim bytePicData() As Byte
        Dim log As String
        Dim rs As New ADODB.Recordset
        Dim sql As String
        '''''''''''''''Rotina abaixo é para login buscando no servidor informações'''''''''''''''''


        '   Try

        conectar_mysql_DFe2()
        ' cria um objeto Command

        sql = "Select * From nfce where data_emissao BETWEEN '" & Convert.ToDateTime(mskdatainicial.Text).ToString("yyyy-MM-dd") & "' and '" & Convert.ToDateTime(mskdatafinal.Text).ToString("yyyy-MM-dd") & "'"

        If cbostatusnfe.Text <> "" Then
            sql = sql + " and status='" & cbostatusnfe.Text.Substring(0, 1) & "'"
        End If

        If cbotipo.Text = "Numero NFe" Then
            sql = sql + " and numero_nfe='" & txtpesquisa.Text & "'"
        End If

        If cbotipo.Text = "Caixa-NFCe" Then
            sql = sql + " and caixa='" & txtpesquisa.Text & "'"
        End If

        If cbotipo.Text = "Serie-NFCe" Then
            txtpesquisa.Text = txtpesquisa.Text.PadLeft(3, "0")
            sql = sql + " and serie='" & txtpesquisa.Text & "'"
        End If

        If cbotipo.Text = "Chave de Acesso NFe" Then
            sql = sql + " and chave_nfe='" & txtpesquisa.Text & "'"
        End If

        If cbotipo.Text = "Valor NFe" Then
            If txtpesquisa.Text <> "0,00" Then
                txtpesquisa.Text = Format(CDec(txtpesquisa.Text), "#,##0.00")
                txtpesquisa.Text = txtpesquisa.Text.Replace(",", ".")
                sql = sql + " and vlr_total='" & txtpesquisa.Text & "'"
            End If
        End If


        rs.Open(sql, conexao.cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        If rs.EOF = True Then
            MsgBox("Nenhum Registro encontrado !", MsgBoxStyle.Exclamation, "Aviso !")
        End If

        Dim xmldisponivel As String, visualizar As String
        Do While rs.EOF = False

            If rs.Fields("xml_nfe").Value.ToString = "" Then
                xmldisponivel = "Download"
                visualizar = ""
            Else
                xmldisponivel = "XML SIM"
                visualizar = "XML Past."

                If rs.Fields("status").Value = "1" Then
                    bytePicData = rs.Fields("xml_nfe").Value
                End If
                If rs.Fields("status").Value = "2" Then
                    bytePicData = rs.Fields("xml_canc").Value
                End If
                If rs.Fields("status").Value = "3" Then
                    bytePicData = rs.Fields("xml_inut").Value
                End If

            End If

            dgvpesquisa.Rows.Add("", rs.Fields("numero_nfe").Value, Format(CDec(rs.Fields("vlr_total").Value), "#,##0.00"), _
                                 Convert.ToDateTime(rs.Fields("data_emissao").Value).ToString("dd/MM/yyyy"), _
                              xmldisponivel, visualizar, rs.Fields("chave_nfe").Value, "", rs.Fields("status_nfe").Value, Encoding.UTF8.GetString(bytePicData))

            rs.MoveNext()

        Loop



        conexao.cn_DFe.Close()
        lblinfo.Visible = False



    End Sub

    Private Sub pesquisar_sql()

        Dim sqlconsulta As String, sqlconsulta2 As String
        Dim xmldisponivel As String, visualizar As String, xml_64 As String
        dgvpesquisa.Rows.Clear()

        If txtpar.Text = "Numero_nfe" Then
            '  txtpesquisa.Text = txtpesquisa.Text.PadLeft(9, "0")
        End If

        sqlconsulta = "select * from nfe where cnpj_dest = '" & empresa.sCNPJ & "' and " & txtpar.Text & " like '%" & txtpesquisa.Text & "%' and Tipo_nfe = '1-NFe Saida'"


        If chkstatus_nfe.Checked = True Then
            sqlconsulta = "select * from nfe where cnpj_dest = '" & empresa.sCNPJ & "' and  " & txtpar.Text & " like '%" & txtpesquisa.Text & "%' and Tipo_nfe = '1-NFe Saida' and Status_nfe = '" & cbostatusnfe.Text.Substring(2, cbostatusnfe.Text.Length - 2) & "'"
        End If

        If cbotipo.Text = "Entre Datas" Then
            datai = mskdatainicial.Text
            dataf = mskdatafinal.Text
            If chkstatus_nfe.Checked = True Then
                sqlconsulta = "select * from nfe where cnpj_dest = '" & empresa.sCNPJ & "' and  Data_emi BETWEEN '" & datai.ToString("yyyy-MM-dd") & "' AND '" & dataf.ToString("yyyy-MM-dd") & "' and Tipo_nfe = '1-NFe Saida' and Status_nfe = '" & cbostatusnfe.Text.Substring(2, cbostatusnfe.Text.Length - 2) & "'"
            Else
                sqlconsulta = "select * from nfe where cnpj_dest = '" & empresa.sCNPJ & "' and  Data_emi BETWEEN '" & datai.ToString("yyyy-MM-dd") & "' AND '" & dataf.ToString("yyyy-MM-dd") & "' and Tipo_nfe = '1-NFe Saida'"
            End If
        End If

        If cbotipo.Text = "NFe nao lancada" Then
            datai = mskdatainicial.Text
            dataf = mskdatafinal.Text
            If chkstatus_nfe.Checked = True Then
                sqlconsulta = "select * from nfe where cnpj_dest = '" & empresa.sCNPJ & "' and Data_emi BETWEEN '" & datai.ToString("yyyy-MM-dd") & "' AND '" & dataf.ToString("yyyy-MM-dd") & "' and Tipo_nfe = '1-NFe Saida' and Status_nfe = '" & cbostatusnfe.Text.Substring(2, cbostatusnfe.Text.Length - 2) & "' and xmot_manif = 'Ciencia da Operacao'"
            Else
                sqlconsulta = "select * from nfe where cnpj_dest = '" & empresa.sCNPJ & "' and  Data_emi BETWEEN '" & datai.ToString("yyyy-MM-dd") & "' AND '" & dataf.ToString("yyyy-MM-dd") & "' and Tipo_nfe = '1-NFe Saida' and xmot_manif = 'Ciencia da Operacao'"
            End If
        End If

        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sqlconsulta
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())
            If dr("xml_nfe").ToString = "" Then
                xmldisponivel = "Download"
                visualizar = ""
            Else
                xmldisponivel = "XML SIM"
                visualizar = "XML Past."
                bytePicData = dr("xml_nfe")
            End If

            If Encoding.UTF8.GetString(bytePicData) = "" Then
                xml_64 = dr("xml_64")
            Else
                xml_64 = Encoding.UTF8.GetString(bytePicData)
            End If

            dgvpesquisa.Rows.Add(dr("Nome_emi"), dr("Numero_nfe"), format_val_mysql_ret(dr("Valor_nfe")), dr("data_emi"), _
                                   xmldisponivel, visualizar, dr("chave_nfe"), dr("obs_cont"), dr("Status_nfe"), xml_64, dr("xmot_manif"))


        End While

        If dr.HasRows = False Then
            MsgBox("Não foi Localizado nenhuma Nota Fiscal", MsgBoxStyle.Exclamation, "Aviso !")
        End If


        Pinfo.Visible = False
        oConn.Close()


        lblinfo.Text = dgvpesquisa.Rows.Count
    End Sub

    Private Sub consultar()
        Dim loc As Boolean = False
        Dim rssefaz As New ADODB.Recordset
        Dim xmldisponivel As String, visualizar As String
        Dim sqlconsulta As String

        dgvpesquisa.Rows.Clear()


        ''''''''''''''''''''''''''''Tira os espacos vazios que separam a chave de acesso da NFe'''''''''''''''''''''''''''''''

        sqlconsulta = "select * from nfe where " & txtpar.Text & " like '%" & txtpesquisa.Text & "%'"



        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sqlconsulta
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())
            If dr("xml_nfe").ToString = "" Then
                xmldisponivel = "Importar"
                visualizar = ""
            Else
                xmldisponivel = "XML SIM"
                visualizar = "Visualizar"
            End If

            If rssefaz.Fields("xml_nfe").Value.ToString <> "" Then
                xmldisponivel = "XML SIM"
                visualizar = "Visualizar"
            Else
                xmldisponivel = ""
                visualizar = ""
            End If

            If chkvlrboleto.Checked = True Then
                dgvpesquisa.Rows.Add(dr("Nome_emi"), dr("Numero_nfe"), dr("Valor_nfe"), dr("Data_emi"), _
                                    xmldisponivel, visualizar, dr("chave_nfe"), consulta_valor_boleto(dr("chave_nfe")), dr("Status_nfe"))
            Else
                dgvpesquisa.Rows.Add(dr("Nome_emi"), dr("Numero_nfe"), dr("Valor_nfe"), dr("Data_emi"), _
                                   xmldisponivel, visualizar, dr("chave_nfe"), "", dr("Status_nfe"))
            End If
            loc = True
        End While

        If loc = False Then
            MsgBox("Nenhum Notas Fiscais Localizada !", MsgBoxStyle.Exclamation, "Atenção")
        End If


        oConn.Close()

        lblinfo.Text = "Total de Notas Fiscais Encontradas: " & dgvpesquisa.Rows.Count
    End Sub


    Private Function consulta_valor_boleto(ByVal chave_n As String) As String

        Dim rssalvam As New ADODB.Recordset
        Dim ret As String = "0,00"

        conectar_boleto()

        rssalvam.Open("select * from fatura_codbarra where chave_nfe = '" & chave_n & "'", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockPessimistic)

        Do While rssalvam.EOF = False

            ret = CDec(ret) + CDec(rssalvam.Fields("valor_dup").Value)

            rssalvam.MoveNext()
        Loop

        cn.Close()


        Return Format(CDec(ret), "###0.00")

    End Function

    Private Sub frmpesquisarnfe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  Psenha.Visible = False
        '   txtsenha.Focus()
        '   Panel1.Enabled = False


        If cbotipo.Text = "" Then
            cbotipo.SelectedIndex = 0
        End If
        cbostatusnfe.SelectedIndex = 0
        cbotipop.SelectedIndex = 0

        Paneldata.Enabled = False

        txtpesquisa.Focus()
    End Sub

    Private Sub dgvpesquisa_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpesquisa.CellClick
        If e.ColumnIndex = 4 Then
            If dgvpesquisa.CurrentCell.Value = "XML SIM" Then
                Dim saveFileDialog1 As New SaveFileDialog()
                saveFileDialog1.FileName = dgvpesquisa.CurrentRow.Cells(6).Value + ".xml"

                If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                    xmldoc.LoadXml(dgvpesquisa.CurrentRow.Cells("xml_nfe").Value)
                    xmldoc.Save(saveFileDialog1.FileName)
                    MsgBox("Arquivo XML NF-e salvo na pasta Informada !", MsgBoxStyle.Information, "Aviso !")
                End If
            End If

            If dgvpesquisa.CurrentCell.Value = "Download" Then

                download_nfe()

            End If
        End If

        If e.ColumnIndex = 5 Then
            If dgvpesquisa.CurrentCell.Value = "XML Past." Then
                Pinfo.Visible = True
                Panelarq.Visible = True
                txtinfo.Visible = False

                If arquivoIni.KeyExists("caminho_xmltemp", "DFe") = False Then
                    arquivoIni.Write("caminho_xmltemp", "", "DFe")
                End If
                txtxml_nfe.Text = arquivoIni.Read("caminho_xmltemp", "DFe")
            End If
        End If
    End Sub


    Private Sub importar_xml_banco(ByVal grid As Boolean)

        Dim chavevalida As String
        Dim dataemi As Date
        Dim nome As String, vnf As String, ie As String, tpnf As String, cnpj_emi As String, data_auto As String, protocolo As String
        Dim dialogo As New OpenFileDialog

        dialogo.Title = "Selecione o Arquivo XML para salvar no Banco"
        dialogo.Filter = "Arquivos (.xml)|*.xml"

        If dialogo.ShowDialog() = Windows.Forms.DialogResult.OK Then

            ''''''''''''''''Abre o arquivo xml para validacao deste''''''''''''''''''''
            xmldoc.Load(dialogo.FileName)

            Dim xmllist As System.Xml.XmlNodeList
            Dim xmlnode As System.Xml.XmlNode

            xmllist = xmldoc.GetElementsByTagName("infNFe")

            For Each xmlnode In xmllist
                chavevalida = xmlnode.Attributes.ItemOf("Id").InnerText.Substring(3, 44)

                If chavevalida.Substring(20, 2) = "65" Then
                    MsgBox("Importação exclusiva para NF-e" + vbCrLf + "Operação cancelada !", MsgBoxStyle.Exclamation, "Atenção !")
                    Exit Sub
                End If

            Next





            '''''''''''''''''''''''''''''''''''''''Rotina para captura os dados resumo da NFe"""""""""""""""""""""""""""'
            Try

                xmllist = xmldoc.GetElementsByTagName("infNFe")

                For Each xmlnode In xmllist

                    If Not xmlnode("ide")("dhEmi") Is Nothing Then
                        dataemi = xmlnode("ide")("dhEmi").InnerText
                    End If
                    If Not xmlnode("ide")("dEmi") Is Nothing Then
                        dataemi = xmlnode("ide")("dEmi").InnerText
                    End If

                    If Not xmlnode("emit")("xNome") Is Nothing Then
                        nome = xmlnode("emit")("xNome").InnerText
                    End If

                    If Not xmlnode("dest")("CNPJ") Is Nothing Then
                        cnpj_emi = xmlnode("dest")("CNPJ").InnerText
                    End If
                    If Not xmlnode("dest")("CPF") Is Nothing Then
                        cnpj_emi = xmlnode("dest")("CPF").InnerText
                    End If

                    If Not xmlnode("total")("ICMSTot")("vNF") Is Nothing Then
                        vnf = xmlnode("total")("ICMSTot")("vNF").InnerText
                    End If

                    If Not xmlnode("emit")("IE") Is Nothing Then
                        ie = xmlnode("emit")("IE").InnerText
                    End If

                    If Not xmlnode("ide")("tpNF") Is Nothing Then

                        If xmlnode("ide")("tpNF").InnerText = "0" Then
                            tpnf = "0-NFe Entrada"
                        End If
                        If xmlnode("ide")("tpNF").InnerText = "1" Then
                            tpnf = "1-NFe Saida"
                        End If

                    End If

                Next


                xmllist = xmldoc.GetElementsByTagName("protNFe")

                For Each xmlnode In xmllist

                    If Not xmlnode("infProt")("dhRecbto") Is Nothing Then
                        data_auto = Convert.ToDateTime(xmlnode("infProt")("dhRecbto").InnerText).ToString("yyyy-MM-dd HH:mm:ss")
                    End If
                    If Not xmlnode("infProt")("nProt") Is Nothing Then
                        protocolo = xmlnode("infProt")("nProt").InnerText
                    End If

                    If Not xmlnode("infProt")("chNFe") Is Nothing Then
                        chavevalida = xmlnode("infProt")("chNFe").InnerText
                    End If


                Next
            Catch ex As Exception

            End Try


            ''''''''''''''''''''''''''#######################"""""""""""""""""""""""""""""''

            ''''''''''''''''Rotina para importar XML para o banco''''''''''''''''''''


            If protocolo <> "" Then


                If verificar_chave(chavevalida) = "xml" Then
                    MsgBox("A NF-e ja existe no Banco de Dados !", MsgBoxStyle.Exclamation, "Aviso !")

                    If MessageBox.Show("Deseja Atualizar as informações desta NF-e no banco ? ", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                        conectar_mysqlDFe()
                        Dim encText As New System.Text.UTF8Encoding()
                        Dim insertSQL As MySqlCommand = New MySqlCommand("UPDATE NFe SET xml_nfe = @xml_nfe, Nome_emi = @Nome_emi, Cnpj_emi = @Cnpj_emi, Ie_emi = @Ie_emi, Valor_nfe = @Valor_nfe, Data_aut = @Data_aut, Status_nfe = @Status_nfe, Tipo_nfe = @Tipo_nfe, Data_emi = @Data_emi, Numero_nfe = @Numero_nfe  WHERE cnpj_dest = '" & empresa.sCNPJ & "' and Chave_nfe = '" & chavevalida & "'", oConn)
                        insertSQL.Parameters.Add(New MySqlParameter("xml_nfe", encText.GetBytes(xmldoc.OuterXml)))

                        insertSQL.Parameters.Add(New MySqlParameter("Nome_emi", nome))
                        insertSQL.Parameters.Add(New MySqlParameter("Cnpj_emi", cnpj_emi))
                        insertSQL.Parameters.Add(New MySqlParameter("Ie_emi", ie))


                        insertSQL.Parameters.Add(New MySqlParameter("Valor_nfe", vnf))
                        insertSQL.Parameters.Add(New MySqlParameter("Data_aut", data_auto))
                        insertSQL.Parameters.Add(New MySqlParameter("Status_nfe", "NF-e autorizada"))

                        insertSQL.Parameters.Add(New MySqlParameter("Tipo_nfe", tpnf))
                        insertSQL.Parameters.Add(New MySqlParameter("Data_emi", dataemi.ToString("yyyy-MM-dd")))
                        insertSQL.Parameters.Add(New MySqlParameter("Numero_nfe", chavevalida.Substring(25, 9)))

                        insertSQL.ExecuteNonQuery()

                        oConn.Close()

                        ''''''''''''''salvar no site'''''''''''''
                        Try
                            '   conectar_mysqlDFe_site()
                            '   Dim encText1 As New System.Text.UTF8Encoding()
                            '   Dim insertSQL1 As MySqlCommand = New MySqlCommand("UPDATE NFe SET xml_nfe = @xml_nfe, Nome_emi = @Nome_emi, Cnpj_emi = @Cnpj_emi, Ie_emi = @Ie_emi, Valor_nfe = @Valor_nfe, Data_aut = @Data_aut, Status_nfe = @Status_nfe, Tipo_nfe = @Tipo_nfe, Data_emi = @Data_emi, Numero_nfe = @Numero_nfe  WHERE Chave_nfe = '" & chavevalida & "'", oConnS)
                            '   insertSQL1.Parameters.Add(New MySqlParameter("xml_nfe", encText.GetBytes(xmldoc.OuterXml)))

                            '   insertSQL1.Parameters.Add(New MySqlParameter("Nome_emi", nome))
                            '   insertSQL1.Parameters.Add(New MySqlParameter("Cnpj_emi", cnpj_emi))
                            '   insertSQL1.Parameters.Add(New MySqlParameter("Ie_emi", ie))


                            '  insertSQL1.Parameters.Add(New MySqlParameter("Valor_nfe", vnf))
                            '  insertSQL1.Parameters.Add(New MySqlParameter("Data_aut", data_auto))
                            '  insertSQL1.Parameters.Add(New MySqlParameter("Status_nfe", "NF-e autorizada"))

                            '  insertSQL1.Parameters.Add(New MySqlParameter("Tipo_nfe", tpnf))
                            '  insertSQL1.Parameters.Add(New MySqlParameter("Data_emi", dataemi.ToString("yyyy-MM-dd")))
                            '  insertSQL1.Parameters.Add(New MySqlParameter("Numero_nfe", chavevalida.Substring(25, 9)))

                            '  insertSQL1.ExecuteNonQuery()

                            '  oConnS.Close()
                        Catch ex As Exception

                        End Try

                        MsgBox("Todas as Informações foram Atualizadas no banco !", MsgBoxStyle.Information, "Aviso !")

                        Exit Sub
                    End If

                End If

                If verificar_chave(chavevalida) = "r" Then
                    conectar_mysqlDFe()

                    Dim insertSQL As MySqlCommand

                    insertSQL = New MySqlCommand("INSERT INTO nfe (Chave_nfe, Nome_emi, Cnpj_emi, Ie_emi, Valor_nfe, Data_aut, Status_nfe, Tipo_nfe, xml_nfe, Data_emi, Numero_nfe, cnpj_dest) VALUES (@Chave_nfe, @Nome_emi, @Cnpj_emi, @Ie_emi, @Valor_nfe, @Data_aut, @Status_nfe, @Tipo_nfe, @xml_nfe, @Data_emi, @Numero_nfe, cnpj_dest)", oConnS)

                    insertSQL.Parameters.Add(New MySqlParameter("Chave_nfe", chavevalida))
                    insertSQL.Parameters.Add(New MySqlParameter("Nome_emi", nome))
                    insertSQL.Parameters.Add(New MySqlParameter("Cnpj_emi", cnpj_emi))
                    insertSQL.Parameters.Add(New MySqlParameter("Ie_emi", ie))
                    insertSQL.Parameters.Add(New MySqlParameter("Valor_nfe", vnf))
                    insertSQL.Parameters.Add(New MySqlParameter("Data_aut", data_auto))
                    insertSQL.Parameters.Add(New MySqlParameter("Status_nfe", "NF-e autorizada"))
                    insertSQL.Parameters.Add(New MySqlParameter("Tipo_nfe", tpnf))
                    Dim encText As New System.Text.UTF8Encoding()
                    insertSQL.Parameters.Add(New MySqlParameter("xml_nfe", encText.GetBytes(xmldoc.OuterXml)))
                    insertSQL.Parameters.Add(New MySqlParameter("Data_emi", dataemi.ToString("yyyy-MM-dd")))
                    insertSQL.Parameters.Add(New MySqlParameter("Numero_nfe", chavevalida.Substring(25, 9)))

                    insertSQL.Parameters.Add(New MySqlParameter("cnpj_dest", empresa.sCNPJ))

                    insertSQL.ExecuteNonQuery()

                    oConn.Close()

                    '''''''''''salvar no site''''''''''
                    Try
                        '  conectar_mysqlDFe_site()

                        '   Dim insertSQL22 As MySqlCommand

                        '  insertSQL22 = New MySqlCommand("INSERT INTO nfe (Chave_nfe, Nome_emi, Cnpj_emi, Ie_emi, Valor_nfe, Data_aut, Status_nfe, Tipo_nfe, xml_nfe, Data_emi, Numero_nfe) VALUES (@Chave_nfe, @Nome_emi, @Cnpj_emi, @Ie_emi, @Valor_nfe, @Data_aut, @Status_nfe, @Tipo_nfe, @xml_nfe, @Data_emi, @Numero_nfe)", oConn)

                        '  insertSQL22.Parameters.Add(New MySqlParameter("Chave_nfe", chavevalida))
                        '  insertSQL22.Parameters.Add(New MySqlParameter("Nome_emi", nome))
                        ' insertSQL22.Parameters.Add(New MySqlParameter("Cnpj_emi", cnpj_emi))
                        '  insertSQL22.Parameters.Add(New MySqlParameter("Ie_emi", ie))
                        ' insertSQL22.Parameters.Add(New MySqlParameter("Valor_nfe", vnf))
                        '  insertSQL22.Parameters.Add(New MySqlParameter("Data_aut", data_auto))
                        '  insertSQL22.Parameters.Add(New MySqlParameter("Status_nfe", "NF-e autorizada"))
                        '  insertSQL22.Parameters.Add(New MySqlParameter("Tipo_nfe", tpnf))
                        '  Dim encText22 As New System.Text.UTF8Encoding()
                        '  insertSQL22.Parameters.Add(New MySqlParameter("xml_nfe", encText22.GetBytes(xmldoc.OuterXml)))
                        '  insertSQL22.Parameters.Add(New MySqlParameter("Data_emi", dataemi.ToString("yyyy-MM-dd")))
                        '  insertSQL22.Parameters.Add(New MySqlParameter("Numero_nfe", chavevalida.Substring(25, 9)))
                        '  insertSQL22.ExecuteNonQuery()

                        '   oConnS.Close()
                    Catch ex As Exception

                    End Try


                    MsgBox("XML importado com Sucesso !", MsgBoxStyle.Information, "Aviso !")
                    File.Delete(dialogo.FileName)

                    If grid = True Then
                        dgvpesquisa.CurrentRow.Cells(4).Value = "XML SIM"
                        dgvpesquisa.CurrentRow.Cells(5).Value = "Visualizar"
                        dgvpesquisa.CurrentRow.Cells("xml_nfe").Value = xmldoc.OuterXml
                    End If

                End If


                Dim r As String = pesquisa_grid(chavevalida)
                If r = "R" Then
                    dgvpesquisa.Rows.Add(nome, chavevalida.Substring(25, 9), vnf, dataemi.ToString("dd/MM/yyyy"), _
                                         "XML SIM", "XML Past.", chavevalida, "0,00", "NF-e autorizada", xmldoc.OuterXml)
                Else
                    dgvpesquisa.Rows.Item(r).Cells(4).Value = "XML SIM"
                    dgvpesquisa.Rows.Item(r).Cells(5).Value = "XML Past."
                    dgvpesquisa.Rows.Item(r).Cells("xml_nfe").Value = xmldoc.OuterXml
                End If


                ''''''''''''''''''''''Salvar xml da pasta''''''''''''''''''''''''''

                ' Dim dataemi As Date = xmlnode("ide")("dhEmi").InnerText
                Dim ano As String = dataemi.ToString("yyyy")
                Dim mes As String = dataemi.ToString("MM") & "-" & DateTimeFormatInfo.CurrentInfo.GetMonthName(dataemi.ToString("MM"))

                caminho_dfe_xml = arquivoIni.Read("caminho_xmlnfe", "DFe")
                If Directory.Exists(caminho_dfe_xml + "\" + ano + "\" + mes + "\" + dataemi.ToString("dd")) = False Then
                    Directory.CreateDirectory((caminho_dfe_xml + "\" + ano + "\" + mes + "\" + dataemi.ToString("dd")))
                End If

                xmldoc.Save(caminho_dfe_xml + "\" + ano + "\" + mes + "\" + dataemi.ToString("dd") + "\" & chavevalida + ".xml")

                File.Delete(dialogo.FileName)

            Else
                MsgBox("Arquivo XML importado é Invalido !!!, não Possui autorização da SEFAZ !", MsgBoxStyle.Exclamation, "Aviso !")

            End If


        End If


    End Sub

    Private Sub dgvpesquisa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvpesquisa.KeyPress

        If (e.KeyChar = Chr(13)) Then

            If dgvpesquisa.CurrentRow.Cells("xml_nfe").Value = "" Then
                MsgBox("O XML da NF-e ainda não esta Disponível para visualizar !", MsgBoxStyle.Exclamation, "Aviso !")
                Exit Sub
            End If
            xmldoc.LoadXml(dgvpesquisa.CurrentRow.Cells("xml_nfe").Value)
            frmxml.carregaxml_pesquisa(xmldoc.OuterXml)
            Me.Close()
        End If

    End Sub
    Private Sub dgvpesquisa_SelectionChanged(sender As Object, e As EventArgs) Handles dgvpesquisa.SelectionChanged
        txtchave.Text = dgvpesquisa.CurrentRow.Cells(6).Value
        lblobscont.Text = dgvpesquisa.CurrentRow.Cells("obscont_grid").Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rs As New ADODB.Recordset
        conectar_DFe()
        '''''''''''''''''nova rotina de arquivo xml'''''''''''''''''''''''''''
        rs.Open("update NFe_consultadaDFe set status_nfe = 'NF-e autorizada' where status_nfe = 'NF-e autorizado'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockPessimistic)

        cn_DFe.Close()

        MsgBox("executado")
    End Sub

    Private Sub mskdatafinal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskdatafinal.KeyPress
        If (e.KeyChar = Chr(13)) Then
            If cbotipop.Text = "NF-e" Then
                lblinfo.Visible = True
                lblinfo.Text = "Aguarde, o sistema esta pesquisando a NF-e Informada..."
                lblinfo.Refresh()
                pesquisar_sql()
            Else
                lblinfo.Visible = True
                lblinfo.Text = "Aguarde, o sistema esta pesquisando a NFC-e Informada..."
                lblinfo.Refresh()
                pesquisar_nfce()
            End If
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        '''''''''''''''''''''''''''''''''''''''Rotina para captura os dados resumo da NFe"""""""""""""""""""""""""""'
        Try

            Dim dialogo As New OpenFileDialog

            dialogo.Title = "Selecione o Arquivo XML para salvar no Banco"
            dialogo.Filter = "Arquivos (.xml)|*.xml"

            If dialogo.ShowDialog() = Windows.Forms.DialogResult.OK Then

                ''''''''''''''''Abre o arquivo xml para validacao deste''''''''''''''''''''
                xmldoc.Load(dialogo.FileName)
                Dim xmllist As System.Xml.XmlNodeList
                Dim xmlnode As System.Xml.XmlNode

                xmllist = xmldoc.GetElementsByTagName("infNFe")

                For Each xmlnode In xmllist

                    If Not xmlnode("ide")("dhEmi") Is Nothing Then
                        MsgBox(xmlnode("ide")("dhEmi").InnerText)
                        '  dgvnotas.CurrentRow.Cells(3).Value = dataemi.ToString("dd/MM/yyyy")
                    End If

                    If Not xmlnode("emit")("xNome") Is Nothing Then
                        MsgBox(xmlnode("emit")("xNome").InnerText)
                    End If

                    If Not xmlnode("dest")("CNPJ") Is Nothing Then
                        MsgBox(xmlnode("dest")("CNPJ").InnerText)
                    End If

                    If Not xmlnode("total")("ICMSTot")("vNF") Is Nothing Then
                        MsgBox(xmlnode("total")("ICMSTot")("vNF").InnerText)
                    End If

                    If Not xmlnode("emit")("IE") Is Nothing Then
                        MsgBox(xmlnode("emit")("IE").InnerText)
                    End If

                    If Not xmlnode("ide")("tpNF") Is Nothing Then

                        If xmlnode("ide")("tpNF").InnerText = "0" Then
                            '  tpnf = "0-NFe Entrada"
                        End If
                        If xmlnode("ide")("tpNF").InnerText = "1" Then
                            '   tpnf = "1-NFe Saida"
                        End If

                    End If

                Next


                xmllist = xmldoc.GetElementsByTagName("protNFe")

                For Each xmlnode In xmllist

                    If Not xmlnode("infProt")("dhRecbto") Is Nothing Then
                        MsgBox(xmlnode("infProt")("dhRecbto").InnerText)
                    End If

                Next

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ManifestacaoDestinatarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManifestacaoDestinatarioToolStripMenuItem.Click
        frmmanifestarind.txtchave.Text = dgvpesquisa.CurrentRow.Cells("chave_nfe").Value
        frmmanifestarind.mskcnpj.Text = empresa.sCNPJ
        frmmanifestarind.ShowDialog()
    End Sub

    Private Sub txtpesquisa_TextChanged(sender As Object, e As EventArgs) Handles txtpesquisa.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        importar_xml_banco(False)
    End Sub

    Private Function verificar_chave(ByVal chv As String) As String
        Dim ret As String = "r"
        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from nfe where Chave_nfe = '" & chv & "'"
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())
            If dr("xml_nfe").ToString <> "" Then
                ret = "xml"
            Else
                ret = "nfe"
            End If
        End While
        oConn.Close()


        Return ret
    End Function

    Private Function pesquisa_grid(ByVal id As String) As String

        Dim r As String = "R"

        For Each row As DataGridViewRow In Me.dgvpesquisa.Rows

            If Not row.IsNewRow Then
                If row.Cells("chave_nfe").Value = id Then
                    Return row.Index
                End If
            End If

        Next

        Return r

    End Function

    Private Sub download_nfe()
        Dim WebS As New C_WebService
        Dim retDFE As retDistDFeInt
        Pinfo.Visible = True
        txtinfo.Text = "Realizando Download da NFe Via WebService, aguarde...."
        Pinfo.Refresh()
        '  certificado = SelecionarCertificado(nfecer)

        retDFE = WebS.NFeDistribuicaoDFe4(empresa.sCNPJ, "1", "31", "0", dgvpesquisa.CurrentRow.Cells("chave_nfe").Value, "DFe_cons_chave")

        Try

            If retDFE.cStat = "138" Then

                For Each doc In retDFE.loteDistDFeInt
                    xmldoc.LoadXml(DecompressGZip(doc.Value))

                    If doc.schema.ToString.Substring(0, 6) = "resNFe" Then
                        MsgBox("Arquivo sem Manifestação do destinatario, Indiponível para Download !", MsgBoxStyle.Exclamation, "Aviso !")
                        Pinfo.Visible = False
                        Exit Sub
                    End If

                    If doc.schema.ToString.Substring(0, 7) = "procNFe" Then
                        importar_xml_banco2(xmldoc.OuterXml)
                    End If

                Next

            End If


            Pinfo.Visible = False

            MsgBox(retDFE.xMotivo & vbCrLf & "Consulta Realizada com Sucesso em: " & Now, MsgBoxStyle.Information, "Aviso !")

            If MessageBox.Show("Deseja Consulta NFe na Portal Nacional ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                frmportalnfe.tipo = "Consulta"
                frmportalnfe.chave = dgvpesquisa.CurrentRow.Cells("chave_nfe").Value
                frmportalnfe.WebBrowser1.ScriptErrorsSuppressed = True
                frmportalnfe.ShowDialog()
            End If



        Catch ex As Exception
            If reterro = "" Then
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Aviso !")
            Else
                MsgBox(reterro, MsgBoxStyle.Exclamation, "Aviso !")
            End If

            Invoke(Sub() Pinfo.Visible = False)

        End Try


    End Sub


    Private Sub importar_xml_banco2(ByVal xml As String)

        Dim chavevalida As String
        Dim dataemi As Date
        Dim nome As String, vnf As String, ie As String, tpnf As String, cnpj_emi As String, data_auto As String, protocolo As String
        Dim dialogo As New OpenFileDialog


        ''''''''''''''''Abre o arquivo xml para validacao deste''''''''''''''''''''
        xmldoc.LoadXml(xml)
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode
        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist = xmldoc.SelectNodes("//bk:NFe", xmlnsManager)

        For Each xmlnode In xmllist
            chavevalida = xmlnode("infNFe").Attributes.ItemOf("Id").InnerText.Substring(3, 44)

            If verificar_chave(chavevalida) = "xml" Then
                MsgBox("O arquivo Ja existe no Banco de Dados !", MsgBoxStyle.Exclamation, "Aviso !")
                File.Delete(dialogo.FileName)
                Exit Sub
            End If
        Next





        '''''''''''''''''''''''''''''''''''''''Rotina para captura os dados resumo da NFe"""""""""""""""""""""""""""'
        Try

            xmllist = xmldoc.GetElementsByTagName("infNFe")

            For Each xmlnode In xmllist

                If Not xmlnode("ide")("dhEmi") Is Nothing Then
                    dataemi = xmlnode("ide")("dhEmi").InnerText
                End If
                If Not xmlnode("ide")("dEmi") Is Nothing Then
                    dataemi = xmlnode("ide")("dEmi").InnerText
                End If

                If Not xmlnode("emit")("xNome") Is Nothing Then
                    nome = xmlnode("emit")("xNome").InnerText
                End If

                If Not xmlnode("dest")("CNPJ") Is Nothing Then
                    cnpj_emi = xmlnode("dest")("CNPJ").InnerText
                End If
                If Not xmlnode("dest")("CPF") Is Nothing Then
                    cnpj_emi = xmlnode("dest")("CPF").InnerText
                End If

                If Not xmlnode("total")("ICMSTot")("vNF") Is Nothing Then
                    vnf = xmlnode("total")("ICMSTot")("vNF").InnerText
                End If

                If Not xmlnode("emit")("IE") Is Nothing Then
                    ie = xmlnode("emit")("IE").InnerText
                End If

                If Not xmlnode("ide")("tpNF") Is Nothing Then

                    If xmlnode("ide")("tpNF").InnerText = "0" Then
                        tpnf = "0-NFe Entrada"
                    End If
                    If xmlnode("ide")("tpNF").InnerText = "1" Then
                        tpnf = "1-NFe Saida"
                    End If

                End If

            Next


            xmllist = xmldoc.GetElementsByTagName("protNFe")

            For Each xmlnode In xmllist

                If Not xmlnode("infProt")("dhRecbto") Is Nothing Then
                    data_auto = Convert.ToDateTime(xmlnode("infProt")("dhRecbto").InnerText).ToString("yyyy-MM-dd HH:mm:ss")
                End If
                If Not xmlnode("infProt")("nProt") Is Nothing Then
                    protocolo = xmlnode("infProt")("nProt").InnerText
                End If

                If Not xmlnode("infProt")("chNFe") Is Nothing Then
                    chavevalida = xmlnode("infProt")("chNFe").InnerText
                End If


            Next
        Catch ex As Exception

        End Try


        ''''''''''''''''''''''''''#######################"""""""""""""""""""""""""""""''

        ''''''''''''''''Rotina para importar XML para o banco''''''''''''''''''''


        If protocolo <> "" Then


            If verificar_chave(chavevalida) = "r" Then
                conectar_mysqlDFe()

                Dim insertSQL As MySqlCommand

                insertSQL = New MySqlCommand("INSERT INTO nfe (Chave_nfe, Nome_emi, Cnpj_emi, Ie_emi, Valor_nfe, Data_aut, Status_nfe, Tipo_nfe, xml_nfe, Data_emi, Numero_nfe) VALUES (@Chave_nfe, @Nome_emi, @Cnpj_emi, @Ie_emi, @Valor_nfe, @Data_aut, @Status_nfe, @Tipo_nfe, @xml_nfe, @Data_emi, @Numero_nfe)", oConn)

                insertSQL.Parameters.Add(New MySqlParameter("Chave_nfe", chavevalida))
                insertSQL.Parameters.Add(New MySqlParameter("Nome_emi", nome))
                insertSQL.Parameters.Add(New MySqlParameter("Cnpj_emi", cnpj_emi))
                insertSQL.Parameters.Add(New MySqlParameter("Ie_emi", ie))
                insertSQL.Parameters.Add(New MySqlParameter("Valor_nfe", vnf))
                insertSQL.Parameters.Add(New MySqlParameter("Data_aut", data_auto))
                insertSQL.Parameters.Add(New MySqlParameter("Status_nfe", "NF-e autorizada"))
                insertSQL.Parameters.Add(New MySqlParameter("Tipo_nfe", tpnf))
                Dim encText As New System.Text.UTF8Encoding()
                insertSQL.Parameters.Add(New MySqlParameter("xml_nfe", encText.GetBytes(xmldoc.OuterXml)))
                insertSQL.Parameters.Add(New MySqlParameter("Data_emi", dataemi.ToString("yyyy-MM-dd")))
                insertSQL.Parameters.Add(New MySqlParameter("Numero_nfe", chavevalida.Substring(25, 9)))
                insertSQL.ExecuteNonQuery()

                oConn.Close()



                '''''''''''''''''''salvar no site'''''''''''''''''''''''
                Try
                    conectar_mysqlDFe_site()

                    Dim insertSQL6 As MySqlCommand

                    insertSQL6 = New MySqlCommand("INSERT INTO nfe (Chave_nfe, Nome_emi, Cnpj_emi, Ie_emi, Valor_nfe, Data_aut, Status_nfe, Tipo_nfe, xml_nfe, Data_emi, Numero_nfe) VALUES (@Chave_nfe, @Nome_emi, @Cnpj_emi, @Ie_emi, @Valor_nfe, @Data_aut, @Status_nfe, @Tipo_nfe, @xml_nfe, @Data_emi, @Numero_nfe)", oConnS)

                    insertSQL6.Parameters.Add(New MySqlParameter("Chave_nfe", chavevalida))
                    insertSQL6.Parameters.Add(New MySqlParameter("Nome_emi", nome))
                    insertSQL6.Parameters.Add(New MySqlParameter("Cnpj_emi", cnpj_emi))
                    insertSQL6.Parameters.Add(New MySqlParameter("Ie_emi", ie))
                    insertSQL6.Parameters.Add(New MySqlParameter("Valor_nfe", vnf))
                    insertSQL6.Parameters.Add(New MySqlParameter("Data_aut", data_auto))
                    insertSQL6.Parameters.Add(New MySqlParameter("Status_nfe", "NF-e autorizada"))
                    insertSQL6.Parameters.Add(New MySqlParameter("Tipo_nfe", tpnf))
                    Dim encText3 As New System.Text.UTF8Encoding()
                    insertSQL6.Parameters.Add(New MySqlParameter("xml_nfe", encText3.GetBytes(xmldoc.OuterXml)))
                    insertSQL6.Parameters.Add(New MySqlParameter("Data_emi", dataemi.ToString("yyyy-MM-dd")))
                    insertSQL6.Parameters.Add(New MySqlParameter("Numero_nfe", chavevalida.Substring(25, 9)))
                    insertSQL6.ExecuteNonQuery()

                    oConnS.Close()
                Catch ex As Exception

                End Try



                dgvpesquisa.CurrentRow.Cells(4).Value = "XML SIM"
                dgvpesquisa.CurrentRow.Cells(5).Value = "Visualizar"


            End If


            If verificar_chave(chavevalida) = "nfe" Then
                conectar_mysqlDFe()
                Dim encText As New System.Text.UTF8Encoding()
                Dim insertSQL As MySqlCommand = New MySqlCommand("UPDATE NFe SET xml_nfe = @xml_nfe WHERE Chave_nfe = '" & chavevalida & "'", oConn)
                insertSQL.Parameters.Add(New MySqlParameter("xml_nfe", Base64Encode(xmldoc.OuterXml)))
                insertSQL.ExecuteNonQuery()

                oConn.Close()

                '  MsgBox("NFe existente, XML importado com Sucesso !", MsgBoxStyle.Information, "Aviso !")

            End If


            dgvpesquisa.CurrentRow.Cells(4).Value = "XML SIM"
            dgvpesquisa.CurrentRow.Cells(5).Value = "Visualizar"



            ''''''''''''''''''''''Salvar xml da pasta''''''''''''''''''''''''''

            ' Dim dataemi As Date = xmlnode("ide")("dhEmi").InnerText
            Dim ano As String = dataemi.ToString("yyyy")
            Dim mes As String = dataemi.ToString("MM") & "-" & DateTimeFormatInfo.CurrentInfo.GetMonthName(dataemi.ToString("MM"))

            caminho_dfe_xml = arquivoIni.Read("caminho_xmlnfe", "DFe")
            If Directory.Exists(caminho_dfe_xml + "\" + ano + "\" + mes + "\" + dataemi.ToString("dd")) = False Then
                Directory.CreateDirectory((caminho_dfe_xml + "\" + ano + "\" + mes + "\" + dataemi.ToString("dd")))
            End If

            xmldoc.Save(caminho_dfe_xml + "\" + ano + "\" + mes + "\" + dataemi.ToString("dd") + "\" & chavevalida + ".xml")



        Else
            MsgBox("Arquivo XML importado é Invalido !!!, não Possui autorização da SEFAZ !", MsgBoxStyle.Exclamation, "Aviso !")

        End If

    End Sub

    Private Sub cbotipop_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbotipop.SelectedIndexChanged
        If cbotipop.Text = "NFC-e" Then
            Paneldata.Enabled = True
        Else
            Paneldata.Enabled = False
        End If
    End Sub

    Private Sub dgvpesquisa_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvpesquisa.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
        End If
    End Sub

    Public Sub verifica_lancamento_sglinear()
        Try

            Pinfo.Visible = True
            txtinfo.Text = "Aguarde, realizando verificação SG..."
            txtinfo.Refresh()

            For Each row As DataGridViewRow In dgvpesquisa.Rows

                Dim rschave As New ADODB.Recordset

                conectarsqlinx()


                rschave.Open("select * from cmd where nfe_chave = '" & row.Cells("chave_nfe").Value & "'", cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

                If rschave.EOF = False Then
                    row.Cells("par_sg").Value = "ok"

                    With Me.dgvpesquisa.Rows(row.Index).DefaultCellStyle

                        .BackColor = Color.LightCyan
                        .ForeColor = Color.Blue

                    End With


                    conectar_mysqlDFe()

                    Dim SQLcommand As MySqlCommand
                    SQLcommand = oConn.CreateCommand
                    SQLcommand.CommandText = "update nfe set recibo_lanc = 'L' where chave_nfe = '" & row.Cells("chave_nfe").Value & "'"
                    SQLcommand.ExecuteReader()

                    oConn.Close()


                    Try
                        File.Delete(arquivoIni.Read("caminho_xmltemp", "DFe") & "\" & row.Cells("chave_nfe").Value & ".xml")
                    Catch ex As Exception

                    End Try




                Else
                    row.Cells("par_sg").Value = "erro"
                End If

                '  Application.DoEvents()

                cnsql.Close()


            Next
            Pinfo.Visible = False
            MsgBox("Verificacao concluida com sucesso !", MsgBoxStyle.Information, "Aviso !")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Aviso !")
        End Try

    End Sub

    Public Sub cria_relatorio()
        Dim dsCat As New DataSetDFe

        '  Try

        For i = 0 To dgvpesquisa.Rows.Count - 1

            If dgvpesquisa.Rows.Item(i).Cells("manifestagrid").Value.ToString = "Ciencia da Operacao" And dgvpesquisa.Rows.Item(i).Cells("par_sg").Value = "erro" Then

                dsCat.Tables("NFe_ciencia").Rows.Add(dgvpesquisa.Rows.Item(i).Cells("nomenfegrid").Value, dgvpesquisa.Rows.Item(i).Cells("nfegrid").Value, dgvpesquisa.Rows.Item(i).Cells("vnf").Value, _
                                         dgvpesquisa.Rows.Item(i).Cells("data_emi").Value)
            End If


        Next


        If dgvpesquisa.RowCount <> 0 Then
            VisualizarRelatorio_cliente(dsCat)
        Else
            MsgBox("Não ha registro neste Período", MsgBoxStyle.Exclamation, "Aviso !")
        End If



        '  Catch ex As Exception
        'MessageBox.Show(ex.Message)
        '   End Try
    End Sub


    Public Sub VisualizarRelatorio_cliente(ByRef ds As DataSet)

        Dim rpt As New ws02
        rpt.SetDataSource(ds)
        frm_visualiza_rel.CrystalReportViewer1.ReportSource = rpt
        frm_visualiza_rel.Show()

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked

        If dgvpesquisa.Rows.Count <> 0 Then
            verifica_lancamento_sglinear()
            cria_relatorio()
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim sqlconsulta As String
        Dim xmldisponivel As String, visualizar As String
        dgvpesquisa.Rows.Clear()
        lbltotal.Text = "0,00"

        sqlconsulta = "select * from nfe where recibo = '1' and Tipo_nfe = '1-NFe Saida' and recibo_lanc = 'n'"



        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sqlconsulta
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())
            If dr("xml_nfe").ToString = "" Then
                xmldisponivel = "Download"
                visualizar = ""
            Else
                xmldisponivel = "XML SIM"
                visualizar = "XML Past."
                bytePicData = dr("xml_nfe")
            End If


            dgvpesquisa.Rows.Add(dr("Nome_emi"), dr("Numero_nfe"), dr("Valor_nfe"), dr("data_emi"), _
                               xmldisponivel, visualizar, dr("chave_nfe"), "", dr("Status_nfe"), Encoding.UTF8.GetString(bytePicData), dr("xmot_manif"))

            If dr("Valor_nfe").ToString <> "" Then
                lbltotal.Text = Format(CDec(lbltotal.Text) + CDec(dr("Valor_nfe")), "#,##0.00")
            End If
        End While
        If dr.HasRows = False Then
            MsgBox("Não foi Localizado nenhuma Nota Fiscal", MsgBoxStyle.Exclamation, "Aviso !")
        End If

        Pinfo.Visible = False
        oConn.Close()


        lblinfo.Text = dgvpesquisa.Rows.Count


        verifica_lancamento_sglinear()
    End Sub

    Private Sub InserirObservacaoNFeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InserirObservacaoNFeToolStripMenuItem.Click
        Dim dados As String
        dados = InputBox("Informe abaixo a observacao da NFe", "Aviso !", " ")

        conectar_mysqlDFe()
        Dim insertSQL As MySqlCommand = New MySqlCommand("UPDATE nfe SET obs = '" & dados & "' WHERE Chave_nfe = '" & dgvpesquisa.CurrentRow.Cells("chave_nfe").Value & "'", oConn)
        insertSQL.ExecuteNonQuery()

        oConn.Close()


        MsgBox("Observação salva com Sucesso !", MsgBoxStyle.Information, "Aviso !")
    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        Dim sqlconsulta As String
        Dim xmldisponivel As String, visualizar As String
        dgvpesquisa.Rows.Clear()


        sqlconsulta = "select * from nfe where obs_cont <> '' and Tipo_nfe = '1-NFe Saida'"



        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sqlconsulta
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())
            If dr("xml_nfe").ToString = "" Then
                xmldisponivel = "Download"
                visualizar = ""
            Else
                xmldisponivel = "XML SIM"
                visualizar = "XML Past."
                bytePicData = dr("xml_nfe")
            End If


            dgvpesquisa.Rows.Add(dr("Nome_emi"), dr("Numero_nfe"), dr("Valor_nfe"), dr("data_emi"), _
                               xmldisponivel, visualizar, dr("chave_nfe"), dr("obs_cont"), dr("Status_nfe"), Encoding.UTF8.GetString(bytePicData), dr("xmot_manif"), "", dr("obs_cont"))


        End While


        Pinfo.Visible = False
        oConn.Close()


        lblinfo.Text = dgvpesquisa.Rows.Count



    End Sub

    Private Sub CriarPastaDocToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CriarPastaDocToolStripMenuItem.Click

        If Not System.IO.Directory.Exists("\\192.168.254.2\doc\" & dgvpesquisa.CurrentRow.Cells("chave_nfe").Value) Then
            System.IO.Directory.CreateDirectory("\\192.168.254.2\doc\" & dgvpesquisa.CurrentRow.Cells("chave_nfe").Value)
        End If

        Dim dialodest As New OpenFileDialog
        dialodest.Filter = "Arquivos ()|*"

        If dialodest.ShowDialog() = Windows.Forms.DialogResult.OK Then

            File.Copy(dialodest.FileName, "\\192.168.254.2\doc\" & dgvpesquisa.CurrentRow.Cells("chave_nfe").Value & "\" & Path.GetFileName(dialodest.FileName), True)

        End If

        MsgBox("Arquivo Movido para pasta !", MsgBoxStyle.Information, "Aviso !")


    End Sub

    Private Sub ImportaCTeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportaCTeToolStripMenuItem.Click
        Dim encText As New System.Text.UTF8Encoding()

        Dim dialodest As New OpenFileDialog
        dialodest.Filter = "Arquivos xml ()|*.xml"

        If dialodest.ShowDialog() = Windows.Forms.DialogResult.OK Then

            xmldoc.Load(dialodest.FileName)

            Dim name As String = Path.GetFileName(dialodest.FileName)

            conectar_mysqlDFe()
            Dim insertSQL As MySqlCommand = New MySqlCommand("UPDATE nfe SET chave_cte = '" & name.Substring(4, 44) & "', xml_cte = '" & Base64Encode(xmldoc.OuterXml) & "' WHERE Chave_nfe = '" & dgvpesquisa.CurrentRow.Cells("chave_nfe").Value & "'", oConn)
            insertSQL.ExecuteNonQuery()

            oConn.Close()
            MsgBox("CTe importado para Sistema !", MsgBoxStyle.Information, "Aviso !")
        End If


    End Sub

    Private Sub VisualizarNFePortalNacionalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizarNFePortalNacionalToolStripMenuItem.Click
        frmportalnfe.tipo = "Consulta"
        frmportalnfe.chave = dgvpesquisa.CurrentRow.Cells("chave_nfe").Value
        frmportalnfe.WebBrowser1.ScriptErrorsSuppressed = True
        frmportalnfe.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click


        For Each row As DataGridViewRow In dgvpesquisa.Rows
            conectar_mysqlDFe()
            Dim SQLcommand As MySqlCommand
            SQLcommand = oConn.CreateCommand
            SQLcommand.CommandText = "update nfe set recibo_lanc = 'n' where chave_nfe = '" & row.Cells("chave_nfe").Value & "' and xmot_manif = 'Ciencia da Operacao'"
            dr = SQLcommand.ExecuteReader()
            oConn.Close()
        Next


        MsgBox("executado")




    End Sub


    Private Sub monta_mensagem(ByVal nome_arq As String, ByVal desc_post As String)
        mensagem = String.Empty

        mensagem += "<table width=""600"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""margin:0 auto"">"
        mensagem += "<tbody><tr>"
        mensagem += "<td style=""text-align:left;border-bottom:1px solid #e4e4e4"">"
        mensagem += "<a href=""" & urlsite & """ style=""display:block"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=http://doka.sytes.net:8008"">"
        mensagem += "<img src=""" & urlsite & "/Images/Slide/logo.jpg"" class=""CToWUd"">"
        mensagem += "</a>"
        mensagem += "</td>"
        mensagem += "</tr>"
        mensagem += "</tbody></table>"

        mensagem += "<td style=""width:272.1pt;border:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt"" valign=""top"" width=""629"" > "
        mensagem += "<p class=""MsoNormal"" style=""text-align:center;line-height:150%"" align=""center""><b>INFORMATIVO SUPERMERCADO DOKA LTDA<u></u><u></u></b></p></td></tr>"
        mensagem += "<tr><td style=""width:472.1pt;border:solid windowtext 1.0pt;border-top:none;padding:0cm 5.4pt 0cm 5.4pt"" valign=""top"" width=""629"">"


        mensagem += "<br>"
        mensagem += "<font face=""Verdana, Calibri"" size=""3"" color=""#122bff"">"
        mensagem += "<strong>Caro Destinatário,</strong> <br>"
        mensagem += "</font>"
        mensagem += "<br>"

        mensagem += "<br>"
        mensagem += "<font face=""Verdana, Calibri"" size=""5"" color=""#122bff"">"
        mensagem += "<strong>SUPERMERCADO DOKA INFORMA:</strong> <br>"
        mensagem += "</font>"
        mensagem += "<br>"

        mensagem += "<br>"
        mensagem += "<font face=""Verdana, Calibri"" size=""5"" color=""#122bff"">"
        mensagem += "<strong>Foi postado " & desc_post & " no Site !</strong> <br>"
        mensagem += "</font>"
        mensagem += "<br>"

        mensagem += "<br>"
        mensagem += "<font face=""Verdana, Calibri"" size=""5"" color=""#f0170f"">"
        mensagem += "<strong>Arquivo postado: " & nome_arq & "<br></strong> <br>"
        mensagem += "</font>"


        mensagem += "<br>"
        mensagem += "<font face=""Verdana, Calibri"" size=""5"" color=""#122bff"">"
        mensagem += "<strong>Para baixar o arquivo acesse:<br>"
        mensagem += "<a href=""" & urlsite & "/NFe_for.aspx"" <b>Clique aqui para baixar o arquivo</b></a>"
        mensagem += "<strong>ou acesse: " & urlsite & "/NFe_for.aspx</strong> <br>"
        mensagem += "</font>"
        mensagem += "<br>"

        mensagem += "<br>"
        mensagem += "<font face=""Verdana, Calibri"" size=""5"" color=""#122bff"">"
        mensagem += "<strong>Realize o login no site e baixe o arquivo postado.</strong> <br>"
        mensagem += "</font>"
        mensagem += "<br>"

        mensagem += "<br></td><tr>"
        mensagem += "Essa mensagem foi gerada automaticamente pelo sistema de nota eletrônica (NFeSJP) Favor não responder.<br>"
        mensagem += "<br>Aviso Legal: esta mensagem eletrônica pode conter informações privilegiadas e/ou confidenciais, portanto, fica o seu receptor notificado de que qualquer disseminação, distribuição ou cópia não autorizada é estritamente proibida. Se você entende que recebeu esta mensagem indevidamente ou por engano, por favor, informe este fato ao remetente e apague-a de seu computador.</div></td>"
    End Sub

    Private Function EmailSender(ByVal From As String, ByVal DisplayName As String, ByVal SendTo As String, ByVal Message As String, ByVal Subject As String, ByVal Password As String, ByVal copi_dest As String) As Boolean
        Dim ret As Boolean
        Using mailMessage As New MailMessage(New MailAddress(SendTo), New MailAddress(SendTo))
            mailMessage.Body = Message
            mailMessage.Subject = Subject

            Try
                Dim SmtpServer As New SmtpClient()
                SmtpServer.Credentials = New System.Net.NetworkCredential(From, Password)
                SmtpServer.EnableSsl = True
                SmtpServer.Port = 587

                Dim MS() As String = From.ToString.Split("@")
                Dim MailServer() As String = MS(1).ToString.Split(".")
                Select Case UCase(MailServer(0))
                    Case Is = "GMAIL"
                        SmtpServer.Credentials = New System.Net.NetworkCredential(From, Password)
                        SmtpServer.Host = "smtp.gmail.com"
                        SmtpServer.EnableSsl = True
                    Case Is = "YAHOO"
                        SmtpServer.Host = "smtp.mail.yahoo.com"
                        SmtpServer.EnableSsl = False
                    Case Is = "AOL"
                        SmtpServer.Host = "smtp.aol.com"
                        SmtpServer.EnableSsl = False
                    Case Is = "LIVE"
                        SmtpServer.Credentials = New System.Net.NetworkCredential(From, Password)
                        SmtpServer.Host = "smtp.live.com"
                        SmtpServer.EnableSsl = True
                End Select

                mail = New MailMessage()
                Dim addr() As String = SendTo.Split(",")
                mail.From = New MailAddress(From, DisplayName, System.Text.Encoding.UTF8)
                Dim i As Byte
                For i = 0 To addr.Length - 1
                    mail.To.Add(addr(i))
                Next i
                mail.Subject = Subject
                mail.Body = Message
                mail.BodyEncoding = System.Text.Encoding.UTF7

                ' If lstAnexos.Items.Count <> 0 Then
                'For i = 0 To lstAnexos.Items.Count - 1
                'mail.Attachments.Add(New Attachment(lstAnexos.Items.Item(i)))
                '  Next
                ' End If

                '''''''''Rotina para apenas um arquivo''''''''''''
                '   If Attach.Length <> 0 Then
                'mail.Attachments.Add(New Attachment(Attach))
                '    End If

                mail.IsBodyHtml = True
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                mail.ReplyTo = New MailAddress(SendTo)


                If copi_dest <> "" Then
                    mail.CC.Add(copi_dest)
                End If


                SmtpServer.Send(mail)
                mail.Attachments.Dispose()

                ret = True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Erro no envio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ret = False
            End Try

            Return ret
        End Using
    End Function

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ' If Not Directory.Exists("\\192.168.254.2\Rel_nfce") Then
        'Directory.CreateDirectory("\\192.168.254.2\Rel_nfce")
        '  End If

        Dim dialodest As New OpenFileDialog
        dialodest.Filter = "Arquivos ()|*"

        Dim dados As String
        dados = InputBox("Informe a descrição da Postagem arquivo abaixo:", "Aviso !", " ")

        If dialodest.ShowDialog() = Windows.Forms.DialogResult.OK Then

            File.Copy(dialodest.FileName, "\\192.168.254.2\Rel_nfce\" & Path.GetFileName(dialodest.FileName), True)

            monta_mensagem(Path.GetFileName(dialodest.FileName), dados)

            If EmailSender("nfesjp@gmail.com", "SUPERMERCADO DOKA", "adenilson.ini2@gmail.com", mensagem, "NOVO ARQUIVO POSTADO", "Pe$$w0rd1@", "supermercado@ebmcontabil.com.br, supermercado4@ebmcontabil.com.br") = True Then
                MsgBox("email informativo enviado !", MsgBoxStyle.Information, "Aviso !")
            Else
                MsgBox("Ocorreu um erro no envio do e-mail !", MsgBoxStyle.Exclamation, "Aviso !")
            End If


        End If

        MsgBox("Arquivo Enviado para pasta !", MsgBoxStyle.Information, "Aviso !")
    End Sub

    Private Sub ProtocolarNFeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProtocolarNFeToolStripMenuItem.Click
        Dim sql As String = "update nfe set data_recibo = '" & Now.ToString("yyyy-MM-dd") & "', recibo = '1', recibo_lanc = 'n' where chave_nfe = '" & txtchave.Text & "'"

        conectar_mysqlDFe()
        Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)
        insertSQL.ExecuteNonQuery()

        MsgBox("Protocolo realizado com sucesso !", MsgBoxStyle.Information, "Aviso !")
    End Sub

    Private Sub VisualizarEstruturaXMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizarEstruturaXMLToolStripMenuItem.Click
        If dgvpesquisa.CurrentRow.Cells("xml_nfe").Value <> "" Then

            xmldoc.LoadXml(dgvpesquisa.CurrentRow.Cells("xml_nfe").Value)

            Dim frmVisualizarcs As frmvisualizar_xml = New frmvisualizar_xml(xmldoc.OuterXml)
            frmVisualizarcs.ShowDialog()
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        fbd1.Description = "Selecione uma pasta para realizar o XML NFe"
        fbd1.RootFolder = Environment.SpecialFolder.MyComputer
        fbd1.ShowNewFolderButton = True

        'Exibe a caixa de diálogo
        If fbd1.ShowDialog = Windows.Forms.DialogResult.OK Then

            'Exibe a pasta selecionada
            txtxml_nfe.Text = fbd1.SelectedPath

            arquivoIni.Write("caminho_xmlnfe", txtxml_nfe.Text, "DFe")

            txtxml_nfe.Focus()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim dataemi As Date = dgvpesquisa.CurrentRow.Cells("data_emi").Value
        Dim ano As String = dataemi.ToString("yyyy")
        Dim mes As String = dataemi.ToString("MM") & "-" & DateTimeFormatInfo.CurrentInfo.GetMonthName(dataemi.ToString("MM"))
        xmldoc.LoadXml(dgvpesquisa.CurrentRow.Cells("xml_nfe").Value)

        xmldoc.Save(txtxml_nfe.Text + "\" & dgvpesquisa.CurrentRow.Cells("chave_nfe").Value + ".xml")

        MsgBox("XML salvo na pasta do Sistema !", MsgBoxStyle.Information, "Aviso !")

        txtinfo.Visible = True
        Pinfo.Visible = False
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Pinfo.Visible = False

        txtinfo.Visible = True
    End Sub

    Private Sub txtxml_nfe_LostFocus(sender As Object, e As EventArgs) Handles txtxml_nfe.LostFocus

        If arquivoIni.KeyExists("caminho_xmltemp", "DFe") = False Then
            arquivoIni.Write("caminho_xmltemp", txtxml_nfe.Text, "DFe")
        End If
        arquivoIni.Write("caminho_xmltemp", txtxml_nfe.Text, "DFe")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        frmLogsitevb.ShowDialog()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        monta_mensagemnfe()

        If EmailSender("nfesjp@gmail.com", "SUPERMERCADO DOKA", "adenilson.ini2@gmail.com", mensagem, "NOVO LANÇAMENTOS NF-e", "Pe$$w0rd1@", "supermercado@ebmcontabil.com.br, supermercado4@ebmcontabil.com.br") = True Then
            MsgBox("email informativo enviado !", MsgBoxStyle.Information, "Aviso !")
        Else
            MsgBox("Ocorreu um erro no envio do e-mail !", MsgBoxStyle.Exclamation, "Aviso !")
        End If
    End Sub

    Private Sub monta_mensagemnfe()
        mensagem = String.Empty

        mensagem += "<table width=""600"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""margin:0 auto"">"
        mensagem += "<tbody><tr>"
        mensagem += "<td style=""text-align:left;border-bottom:1px solid #e4e4e4"">"
        mensagem += "<a href=""" & urlsite & """ style=""display:block"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=http://doka.sytes.net:8008"">"
        mensagem += "<img src=""" & urlsite & "/Images/Slide/logo.jpg"" class=""CToWUd"">"
        mensagem += "</a>"
        mensagem += "</td>"
        mensagem += "</tr>"
        mensagem += "</tbody></table>"

        mensagem += "<td style=""width:272.1pt;border:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt"" valign=""top"" width=""629"" > "
        mensagem += "<p class=""MsoNormal"" style=""text-align:center;line-height:150%"" align=""center""><b>INFORMATIVO SUPERMERCADO DOKA LTDA<u></u><u></u></b></p></td></tr>"
        mensagem += "<tr><td style=""width:472.1pt;border:solid windowtext 1.0pt;border-top:none;padding:0cm 5.4pt 0cm 5.4pt"" valign=""top"" width=""629"">"


        mensagem += "<br>"
        mensagem += "<font face=""Verdana, Calibri"" size=""3"" color=""#122bff"">"
        mensagem += "<strong>Caro contabilistas,</strong> <br>"
        mensagem += "</font>"
        mensagem += "<br>"

        mensagem += "<br>"
        mensagem += "<font face=""Verdana, Calibri"" size=""5"" color=""#122bff"">"
        mensagem += "<strong>SUPERMERCADO DOKA INFORMATIVO:</strong> <br>"
        mensagem += "</font>"
        mensagem += "<br>"

        mensagem += "<br>"
        mensagem += "<font face=""Verdana, Calibri"" size=""5"" color=""#122bff"">"
        mensagem += "<strong>Existem novos lancamentos de NFe fornecedor no Site !</strong> <br>"
        mensagem += "</font>"
        mensagem += "<br>"

        mensagem += "<br>"
        mensagem += "<font face=""Verdana, Calibri"" size=""5"" color=""#122bff"">"
        mensagem += "<strong>Acesso o link para ter acesso as NFe Lançadas: <br>"
        mensagem += "<a href=""" & urlsite & "/NFe_for.aspx"" <b>Clique aqui para Visualizar as NF-e Fornecedor</b></a>"
        mensagem += "<strong>ou acesse: " & urlsite & "/NFe_for.aspx</strong> <br>"
        mensagem += "</font>"
        mensagem += "<br>"

        mensagem += "<br>"
        mensagem += "<font face=""Verdana, Calibri"" size=""5"" color=""#122bff"">"
        mensagem += "<strong>Realize o login no site para baixar e visualize os lançamentos.</strong> <br>"
        mensagem += "</font>"
        mensagem += "<br>"

        mensagem += "<br></td><tr>"
        mensagem += "Essa mensagem foi gerada automaticamente pelo sistema de nota eletrônica (NFeSJP) Favor não responder.<br>"
        mensagem += "<br>Aviso Legal: esta mensagem eletrônica pode conter informações privilegiadas e/ou confidenciais, portanto, fica o seu receptor notificado de que qualquer disseminação, distribuição ou cópia não autorizada é estritamente proibida. Se você entende que recebeu esta mensagem indevidamente ou por engano, por favor, informe este fato ao remetente e apague-a de seu computador.</div></td>"
    End Sub


    Private Sub dgvpesquisa_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpesquisa.CellContentClick

    End Sub
End Class