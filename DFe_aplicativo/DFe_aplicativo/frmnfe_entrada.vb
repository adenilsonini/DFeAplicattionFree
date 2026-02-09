Imports MySql.Data.MySqlClient

Public Class frmnfe_entrada
    Dim importar As Boolean
    Dim cont_itenxml As Integer = 0
    Dim ir As Integer = 0
    Dim cont_itenxml_total As Integer = 0
    Public vlrunit As String
    Dim cont_item As Integer
    Private Sub txtqtdecx_item_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtqtdecx_item.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtqtde_item_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtqtde_item.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub calcular_valor_item()
        ''''''''''''''''''''calcular Valor Total dos itens'''''''''''''''''''''''''''''''
        If txtqtdecx_item.Text <> "0" Then
            If txtqtde_item.Text <> "0,000" Then
                If txtvlrunit_item.Text <> "0,00" Then

                    If txtqtdecx_item.Text <> "0" Then
                        txtvlrunit_item.Text = Format(CDec(vlrunit) / CDec(txtqtdecx_item.Text), "#,##0.00")
                    End If

                    txtvlrtotal_item.Text = Format(((CDec(txtqtdecx_item.Text) * CDec(txtqtde_item.Text)) * CDec(txtvlrunit_item.Text)) - CDec(txtvlrdesc_item.Text), "#,##0.00")


                    If txtaliqicms_item.Text <> "0,00" Then

                        txtbaseicms_item.Text = Format(CDec(txtvlrtotal_item.Text) + CDec(txtvlroutros_item.Text), "#,##0.00")
                        If txtbaseredicms_item.Text <> "0,00" Then
                            txtbaseicms_item.Text = Format(CDec(txtbaseicms_item.Text) - ((CDec(txtvlrtotal_item.Text) * CDec(txtbaseredicms_item.Text)) / 100), "#,##0.00")
                        End If

                        txtvlricms_item.Text = Format(CDec(txtbaseicms_item.Text) * (CDec(txtaliqicms_item.Text) / 100), "#,##0.00")
                    End If

                    If txtaliqipi_item.Text <> "0,00" Then
                        txtvlripi_item.Text = Format(CDec(txtvlrtotal_item.Text) * (CDec(txtaliqipi_item.Text) / 100), "#,##0.00")
                    End If

                    If txtaliqpis_item.Text <> "0,00" Then
                        txtvlrpis_item.Text = Format(CDec(txtvlrtotal_item.Text) * (CDec(txtaliqpis_item.Text) / 100), "#,##0.00")
                    End If
                    If txtaliqcofins_item.Text <> "0,00" Then
                        txtvlrcofins_item.Text = Format(CDec(txtvlrtotal_item.Text) * (CDec(txtaliqcofins_item.Text) / 100), "#,##0.00")
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub txtqtde_item_LostFocus(sender As Object, e As EventArgs) Handles txtqtde_item.LostFocus
        If txtqtde_item.Text <> "0,000" Then
            txtqtde_item.Text = Format(CDec(txtqtde_item.Text), "###0.000")
            calcular_valor_item()
        Else
            txtqtde_item.Text = "0,000"
        End If
    End Sub

    Private Sub txtvlrdesc_item_LostFocus(sender As Object, e As EventArgs) Handles txtvlrdesc_item.LostFocus

        If txtvlrdesc_item.Text <> "" Then
            txtvlrdesc_item.Text = Format(CDec(txtvlrdesc_item.Text), "#,##0.00")
            calcular_valor_item()
        Else
            txtvlrdesc_item.Text = "0,00"
        End If


    End Sub

    Private Sub txtvlrseguro_item_LostFocus(sender As Object, e As EventArgs) Handles txtvlrseguro_item.LostFocus

        If txtvlrseguro_item.Text <> "" Then
            txtvlrseguro_item.Text = Format(CDec(txtvlrseguro_item.Text), "#,##0.00")
        Else
            txtvlrseguro_item.Text = "0,00"
        End If

    End Sub

    Private Sub txtvlrfrete_item_LostFocus(sender As Object, e As EventArgs) Handles txtvlrfrete_item.LostFocus
        If txtvlrfrete_item.Text <> "" Then
            txtvlrfrete_item.Text = Format(CDec(txtvlrfrete_item.Text), "#,##0.00")
        Else
            txtvlrfrete_item.Text = "0,00"
        End If
    End Sub

    Private Sub txtvlroutros_item_LostFocus(sender As Object, e As EventArgs) Handles txtvlroutros_item.LostFocus
        If txtvlroutros_item.Text <> "" Then
            txtvlroutros_item.Text = Format(CDec(txtvlroutros_item.Text), "#,##0.00")
            calcular_valor_item()
        Else
            txtvlroutros_item.Text = "0,00"
        End If
    End Sub

    Private Sub txtvlrcofins_item_LostFocus(sender As Object, e As EventArgs) Handles txtvlrcofins_item.LostFocus
        If txtvlrcofins_item.Text <> "" Then
            txtvlrcofins_item.Text = Format(CDec(txtvlrcofins_item.Text), "#,##0.00")
            calcular_valor_item()
        Else
            txtvlrcofins_item.Text = "0,00"
        End If
    End Sub

    Private Sub txtvlrpis_item_LostFocus(sender As Object, e As EventArgs) Handles txtvlrpis_item.LostFocus
        If txtvlrpis_item.Text <> "" Then
            txtvlrpis_item.Text = Format(CDec(txtvlrpis_item.Text), "#,##0.00")
            calcular_valor_item()
        Else
            txtvlrpis_item.Text = "0,00"
        End If
    End Sub


    Private Sub txtvlripi_item_LostFocus(sender As Object, e As EventArgs) Handles txtvlripi_item.LostFocus
        If txtvlripi_item.Text <> "" Then
            txtvlripi_item.Text = Format(CDec(txtvlripi_item.Text), "#,##0.00")
            calcular_valor_item()
        Else
            txtvlripi_item.Text = "0,00"
        End If
    End Sub

    Private Sub txtvlrst_item_LostFocus(sender As Object, e As EventArgs) Handles txtvlrst_item.LostFocus
        If txtvlripi_item.Text <> "" Then
            txtvlripi_item.Text = Format(CDec(txtvlripi_item.Text), "#,##0.00")
            calcular_valor_item()
        Else
            txtvlripi_item.Text = "0,00"
        End If
    End Sub

    Private Sub txtaliqicms_item_LostFocus(sender As Object, e As EventArgs) Handles txtaliqicms_item.LostFocus
        If txtaliqicms_item.Text <> "" Then
            txtaliqicms_item.Text = Format(CDec(txtaliqicms_item.Text), "#,##0.00")
            calcular_valor_item()
        Else
            txtaliqicms_item.Text = "0,00"
        End If
    End Sub

    Private Sub txtbaseredicms_item_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbaseredicms_item.KeyPress

    End Sub

    Private Sub txtvlricms_item_LostFocus(sender As Object, e As EventArgs) Handles txtvlricms_item.LostFocus
        If txtvlricms_item.Text <> "" Then
            txtvlricms_item.Text = Format(CDec(txtvlricms_item.Text), "#,##0.00")
            calcular_valor_item()
        Else
            txtvlricms_item.Text = "0,00"
        End If
    End Sub

    Private Sub txtaliqipi_item_LostFocus(sender As Object, e As EventArgs) Handles txtaliqipi_item.LostFocus
        If txtaliqipi_item.Text <> "" Then
            txtaliqipi_item.Text = Format(CDec(txtaliqipi_item.Text), "#,##0.00")
            calcular_valor_item()
        Else
            txtaliqipi_item.Text = "0,00"
        End If
    End Sub

    Private Sub txtaliqpis_item_LostFocus(sender As Object, e As EventArgs) Handles txtaliqpis_item.LostFocus
        If txtaliqpis_item.Text <> "" Then
            txtaliqpis_item.Text = Format(CDec(txtaliqpis_item.Text), "#,##0.00")
            calcular_valor_item()
        Else
            txtaliqpis_item.Text = "0,00"
        End If
    End Sub

    Private Sub txtaliqcofins_item_LostFocus(sender As Object, e As EventArgs) Handles txtaliqcofins_item.LostFocus
        If txtaliqcofins_item.Text <> "" Then
            txtaliqcofins_item.Text = Format(CDec(txtaliqcofins_item.Text), "#,##0.00")
            calcular_valor_item()
        Else
            txtaliqcofins_item.Text = "0,00"
        End If
    End Sub

    Private Sub limpar_itens()
        txtvlrtotal_item.Text = "0,00"
        txtfcpst_item.Text = "0,00"
        txtvlrdesc_item.Text = "0,00"
        txtvlrunit_item.Text = "0,00"
        txtaliqicms_item.Text = "0,00"
        txtbcst_item.Text = "0,00"
        txtbaseicms_item.Text = "0,00"
        txtbaseredicms_item.Text = "0,00"
        txtvlricms_item.Text = "0,00"
        txtvlrst_item.Text = "0,00"
        txtaliqipi_item.Text = "0,00"
        txtaliqpis_item.Text = "0,00"
        txtaliqcofins_item.Text = "0,00"
        txtvlripi_item.Text = "0,00"
        txtvlrpis_item.Text = "0,00"
        txtvlrcofins_item.Text = "0,00"
        txtvlrfrete_item.Text = "0,00"
        txtvlrseguro_item.Text = "0,00"
        txtvlroutros_item.Text = "0,00"
        txtqtde_item.Text = "1,000"
        txtqtdecx_item.Text = "1"
        txtdescprod_item.Clear()
        txtcodigoprod_item.Clear()
    End Sub


    Private Sub limpar_principal()

        txtvlrfemst.Text = "0,00"
        txtvlrtotalprod_nfe.Text = "0,00"
        txtvlrtotalbaseicms_nfe.Text = "0,00"
        txtvlrtotalicms_nfe.Text = "0,00"
        txtvlrtotalbasest_nfe.Text = "0,00"
        txtvlrtotalst_nfe.Text = "0,00"
        txtvlrtotalpis_nfe.Text = "0,00"
        txtvlrtotalcofins_nfe.Text = "0,00"
        txtvrltotalipi_nfe.Text = "0,00"
        txtvlrtotaldesc_nfe.Text = "0,00"
        txtvlrtotalfrete_nfe.Text = "0,00"
        txtvlrtotalseg_nfe.Text = "0,00"
        txtvlrtotaloutras_nfe.Text = "0,00"
        txtnumeronf.Clear()
        txtnome_emi.Clear()
        txtserienfe.Clear()
        cbomodelo.Text = ""
        mskcnpj_emi.Text = ""

        '  txtvlrtotalvFCPUFDest.Text = "0,00"
        '   txtvlrtotalvICMSUFDest.Text = CDec(txtvlrtotalvICMSUFDest.Text) + CDec(txtbaseredicmsst_item.Text)
        '   txtvlrtotalvICMSUFRemet.Text = CDec(txtvlrtotalvICMSUFRemet.Text) + CDec(txtbaseredicmsst_item.Text)


        '  If chkfundopobreza.Checked = True Then


        'txtvlrtotalFCP.Text = CDec(txtvlrtotalFCP.Text) + CDec(txtvFCP.Text)

        ' txtvlrtotalFCPST.Text = CDec(txtvlrtotalFCPST.Text) + CDec(txtvFCPST.Text)

        '  End If

        txtvlrtotal_nfe.Text = "0,00"


    End Sub
    Private Sub txtvlrunit_item_LostFocus(sender As Object, e As EventArgs) Handles txtvlrunit_item.LostFocus
        If txtvlrunit_item.Text <> "" Then
            txtvlrunit_item.Text = Format(CDec(txtvlrunit_item.Text), "#,##0.00")
            calcular_valor_item()
        Else
            txtvlrunit_item.Text = "0,00"
        End If
    End Sub

    Private Sub frmnfe_entrada_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmnfe_entrada_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub txtcodigoprod_item_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcodigoprod_item.KeyPress
        If (e.KeyChar = Chr(13)) Then

            If lbliten.Text = "total" Then
                MsgBox("Todos os itens foram importados !", MsgBoxStyle.Information, "Aviso !")
                Exit Sub
            End If

            pesquisa_cod()
        End If
    End Sub

    Private Sub pesquisa_cod()

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from produto where codigo_prod = '" & txtcodigoprod_item.Text & "'"
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read


                txtdescprod_item.Text = reader("desc_prod")
                txtvlrunit_item.Text = format_val_mysql_ret(reader("valor_fab"))

                If importar = False Then
                    vlrunit = format_val_mysql_ret(reader("valor_fab"))
                    cboncm_item.Text = reader("ncm_prod")
                    cbocest_item.Text = reader("cest_prod")
                End If

                txtqtdecx_item.Text = reader("Qtde_emb_prod")
                cbocst_item.Text = reader("cst_icms")
                txtaliqicms_item.Text = format_val_mysql_ret(reader("aliq_icms"))
                cbocstipi_item.Text = reader("cst_ipi_ent")
                cbocstpis_item.Text = reader("cst_pis_ent")
                txtaliqpis_item.Text = format_val_mysql_ret(reader("aliq_pis"))
                txtaliqcofins_item.Text = format_val_mysql_ret(reader("aliq_cofins"))
                txtaliqipi_item.Text = format_val_mysql_ret(reader("aliq_ipi"))
                lblun.Text = reader("unidade_prod")


            End While
        End Using

        If txtdescprod_item.Text = "" Then

            MsgBox("Produto não cadastrado !", MsgBoxStyle.Exclamation, "Aviso !")

        End If

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        FrmConsultaProduto.Text = "Pesquisar Produto NF entrada"
        FrmConsultaProduto.ShowDialog()

        If txtdescprod_item.Text <> "" Then
            txtqtde_item.Focus()
        Else
            txtcodigoprod_item.Focus()
        End If

    End Sub

    Private Sub bntok_Click(sender As Object, e As EventArgs) Handles bntok.Click
        If importar = True Then
            If lbliten.Text = "total" Then
                MsgBox("Todos os itens foram importados !", MsgBoxStyle.Information, "Aviso !")
                Exit Sub
            End If
        End If
        If txtdescprod_item.Text = "" Then
            MsgBox("Informe o Produto !", MsgBoxStyle.Exclamation, "Aviso !")
            txtcodigoprod_item.Focus()
            Exit Sub
        End If
        If txtqtde_item.Text = "0,000" Then
            MsgBox("Informe a quantidade !", MsgBoxStyle.Exclamation, "Aviso !")
            txtqtde_item.Focus()
            Exit Sub
        End If
        If txtvlrunit_item.Text = "0,00" Then
            MsgBox("Informe o valor unitário do produto !", MsgBoxStyle.Exclamation, "Aviso !")
            txtvlrunit_item.Focus()
            Exit Sub
        End If
        If cboncm_item.Text = "" Then
            MsgBox("Informe a NCM do produto !", MsgBoxStyle.Exclamation, "Aviso !")
            cboncm_item.Focus()
            Exit Sub
        End If

        If cbocfop_item.Text = "" Then
            MsgBox("Informe o CFOP da operação !", MsgBoxStyle.Exclamation, "Aviso !")
            cbocfop_item.Focus()
            Exit Sub
        End If

        If cbocst_item.Text = "" Then
            MsgBox("Informe o CST do produto !", MsgBoxStyle.Exclamation, "Aviso !")
            cbocst_item.Focus()
            Exit Sub
        End If

        If cbocstpis_item.Text = "" Then
            MsgBox("Informe o CST PIS/COFINS do produto !", MsgBoxStyle.Exclamation, "Aviso !")
            cbocstpis_item.Focus()
            Exit Sub
        End If

        If cbocst_item.Text.Length = 3 Then

            If cbocst_item.Text.Substring(1, 2) = "60" Or cbocst_item.Text.Substring(1, 2) = "70" Or cbocst_item.Text.Substring(1, 2) = "10" Then

                If cbocest_item.Text = "" Then
                    MsgBox("Informe a CEST do produto !", MsgBoxStyle.Exclamation, "Aviso !")
                    cbocest_item.Focus()
                    Exit Sub
                End If

                If lbluf.Text = empresa.sSiglaUF Then
                    If cbocfop_item.Text.Substring(0, 4) = "1102" Then
                        MsgBox("CFOP (1102) invalido para operação," & vbCrLf & "Você deve usar o CFOP (1403) se for NF entrada Venda ?", MsgBoxStyle.Exclamation, "Aviso !")
                        cbocfop_item.Focus()
                        Exit Sub
                    End If
                Else
                    If cbocfop_item.Text.Substring(0, 4) = "2102" Then
                        MsgBox("CFOP (2102) invalido para operação," & vbCrLf & "Você deve usar o CFOP (2403) se for NF entrada Venda ?", MsgBoxStyle.Exclamation, "Aviso !")
                        cbocfop_item.Focus()
                        Exit Sub
                    End If
                End If

            End If

            If cbocst_item.Text.Substring(1, 2) = "00" Or cbocst_item.Text.Substring(1, 2) = "40" Or cbocst_item.Text.Substring(1, 2) = "41" Or cbocst_item.Text.Substring(1, 2) = "20" Or cbocst_item.Text.Substring(1, 2) = "30" Then

                If lbluf.Text = empresa.sSiglaUF Then
                    If cbocfop_item.Text.Substring(0, 4) = "1403" Then
                        MsgBox("CFOP (1403) invalido para operação," & vbCrLf & "Você deve usar o CFOP (1102) se for NF entrada Venda ?", MsgBoxStyle.Exclamation, "Aviso !")
                        cbocfop_item.Focus()
                        Exit Sub
                    End If
                Else
                    If cbocfop_item.Text.Substring(0, 4) = "2403" Then
                        MsgBox("CFOP (2403) invalido para operação," & vbCrLf & "Você deve usar o CFOP (2102) se for NF entrada Venda ?", MsgBoxStyle.Exclamation, "Aviso !")
                        cbocfop_item.Focus()
                        Exit Sub
                    End If
                End If

            End If

        Else

            If cbocst_item.Text.Substring(1, 2) = "201" Or cbocst_item.Text.Substring(1, 2) = "202" Or cbocst_item.Text.Substring(1, 2) = "500" Then

                If cbocest_item.Text = "" Then
                    MsgBox("Informe a CEST do produto !", MsgBoxStyle.Exclamation, "Aviso !")
                    cbocest_item.Focus()
                    Exit Sub
                End If

                If lbluf.Text = empresa.sSiglaUF Then
                    If cbocfop_item.Text.Substring(0, 4) = "1102" Then
                        MsgBox("CFOP (1102) invalido para operação," & vbCrLf & "Você deve usar o CFOP (1403) se for NF entrada Venda ?", MsgBoxStyle.Exclamation, "Aviso !")
                        cbocfop_item.Focus()
                        Exit Sub
                    End If
                Else
                    If cbocfop_item.Text.Substring(0, 4) = "2102" Then
                        MsgBox("CFOP (2102) invalido para operação," & vbCrLf & "Você deve usar o CFOP (2403) se for NF entrada Venda ?", MsgBoxStyle.Exclamation, "Aviso !")
                        cbocfop_item.Focus()
                        Exit Sub
                    End If
                End If

            End If

            If cbocst_item.Text.Substring(1, 2) = "101" Or cbocst_item.Text.Substring(1, 2) = "102" Or cbocst_item.Text.Substring(1, 2) = "103" Or cbocst_item.Text.Substring(1, 2) = "400" Or cbocst_item.Text.Substring(1, 2) = "300" Or cbocst_item.Text.Substring(1, 2) = "203" Then
                If lbluf.Text = empresa.sSiglaUF Then
                    If cbocfop_item.Text.Substring(0, 4) = "1403" Then
                        MsgBox("CFOP (1403) invalido para operação," & vbCrLf & "Você deve usar o CFOP (1102) se for NF entrada Venda ?", MsgBoxStyle.Exclamation, "Aviso !")
                        cbocfop_item.Focus()
                        Exit Sub
                    End If
                Else
                    If cbocfop_item.Text.Substring(0, 4) = "2403" Then
                        MsgBox("CFOP (2403) invalido para operação," & vbCrLf & "Você deve usar o CFOP (2102) se for NF entrada Venda ?", MsgBoxStyle.Exclamation, "Aviso !")
                        cbocfop_item.Focus()
                        Exit Sub
                    End If
                End If
            End If

        End If


        cont_item += 1
        dgvitens.Rows.Add(cont_item, txtcodigoprod_item.Text, txtdescprod_item.Text, lblun.Text, Format(CDec(txtqtdecx_item.Text) * CDec(txtqtde_item.Text), "###0.000"), _
                          txtvlrunit_item.Text, txtvlrdesc_item.Text, txtvlrtotal_item.Text, cboncm_item.Text, cbocest_item.Text, cbocfop_item.Text.Substring(0, 4), _
                          cbocst_item.Text, txtbaseicms_item.Text, txtbaseredicms_item.Text, txtaliqicms_item.Text, txtvlricms_item.Text, txtvlrst_item.Text, _
                          cbocstpis_item.Text, txtaliqpis_item.Text, txtvlrpis_item.Text, txtaliqcofins_item.Text, txtvlrcofins_item.Text, cbocstipi_item.Text, _
                          txtaliqipi_item.Text, txtvlripi_item.Text, txtbcst_item.Text, txtvlrfrete_item.Text, txtvlroutros_item.Text, txtvlrseguro_item.Text, txtfcpst_item.Text)

        calcular_valor_totais_nfe()

        limpar_itens()
        txtcodigoprod_item.Focus()

        If importar = True Then
            importacao()
        End If
    End Sub

    Private Sub txtqtdecx_item_LostFocus(sender As Object, e As EventArgs) Handles txtqtdecx_item.LostFocus

        If txtqtdecx_item.Text <> "" Then



        End If


    End Sub

    Public Sub carrega_ncm()

        cboncm_item.Items.Clear()

        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "SELECT * FROM NCM"
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())
            cboncm_item.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))
        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()


    End Sub

    Public Sub carrega_cest()

        cbocest_item.Items.Clear()

        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "SELECT * FROM cest WHERE ncm LIKE '" & cboncm_item.Text.Substring(0, 2) & "' OR ncm LIKE '" & cboncm_item.Text.Substring(0, 4) & "' OR ncm like '" & cboncm_item.Text.Substring(0, 6) & "' OR ncm LIKE '" & cboncm_item.Text.Substring(0, 8) & "'"
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())
            cbocest_item.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))
        End While


        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()


    End Sub

    Public Function carrega_cst_icms(ByVal origem As String) As String

        cbocst_item.Items.Clear()

       
        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "SELECT * FROM cst_icms ORDER BY codigo ASC"
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())

            If empresa.scod_trib = 3 Then
                If dr("codigo").ToString.Length = 2 Then
                    cbocst_item.Items.Add(New MTGCComboBoxItem(origem & dr("codigo"), dr("descricao")))
                End If
            End If

            If empresa.scod_trib = 1 Or empresa.scod_trib = 2 Then
                If dr("codigo").ToString.Length = 3 Then
                    cbocst_item.Items.Add(New MTGCComboBoxItem(origem & dr("codigo"), dr("descricao")))
                End If
            End If



        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()


    End Function


    Public Sub carrega_pis_cofins_frete()
        cbocstpisfrete.Items.Clear()

        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "SELECT * FROM cst_cofins ORDER BY codigo ASC"
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())

            If dr("codigo").ToString.Substring(0, 1) = "5" Or dr("codigo").ToString.Substring(0, 1) = "6" Or dr("codigo").ToString.Substring(0, 1) = "7" Then

                cbocstpisfrete.Items.Add(dr("codigo") & " - " & dr("descricao"))

            End If

        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()

    End Sub

    Public Sub carrega_pis_cofins()
        cbocstpis_item.Items.Clear()

        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "SELECT * FROM cst_cofins ORDER BY codigo ASC"
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())

            If dr("codigo").ToString.Substring(0, 1) = "5" Or dr("codigo").ToString.Substring(0, 1) = "6" Or dr("codigo").ToString.Substring(0, 1) = "7" Then

                cbocstpis_item.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))

            End If

        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()

        cbocstpis_item.Items.Add(New MTGCComboBoxItem("99", "outra Operações"))
    End Sub

    Public Sub carrega_IPI()
        cbocstipi_item.Items.Clear()



        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "SELECT * FROM cst_ipi ORDER BY codigo ASC"
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())
            If dr("codigo").ToString.Substring(0, 1) = "0" Or dr("codigo").ToString.Substring(0, 1) = "4" Then
                cbocstipi_item.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))
            End If
        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()


    End Sub


    Public Sub carrega_cfop()


        cbocfop_item.Items.Clear()

        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "SELECT * FROM cfop ORDER BY codigo ASC"
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())

            If lbluf.Text = empresa.sSiglaUF Then

                If dr("codigo").ToString <> "" Then
                    If dr("codigo").Substring(0, 1) = "1" Then
                        cbocfop_item.Items.Add(dr("codigo") & " - " & dr("descricao"))
                        CBOCFOP_CORPO.Items.Add(dr("codigo") & " - " & dr("descricao"))
                    End If
                End If

            Else

                If dr("codigo").ToString <> "" Then
                    If dr("codigo").Substring(0, 1) = "2" Then
                        cbocfop_item.Items.Add(dr("codigo") & " - " & dr("descricao"))
                        CBOCFOP_CORPO.Items.Add(dr("codigo") & " - " & dr("descricao"))
                    End If
                End If
            End If

        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()

    End Sub

    Private Sub mskcnpj_emi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskcnpj_emi.KeyPress
        If (e.KeyChar = Chr(13)) Then

            If txtnumeronf.Text = "" Then
                MsgBox("Informe o Número da Nota Fiscal ?", MsgBoxStyle.Exclamation, "Aviso !")
                txtnumeronf.Focus()
                Exit Sub
            End If

            If cbomodelo.Text = "" Then
                MsgBox("Informe o modelo da Nota Fiscal ?", MsgBoxStyle.Exclamation, "Aviso !")
                cbomodelo.Focus()
                Exit Sub
            End If

            carregar_emi(mskcnpj_emi.Text)

        End If
    End Sub

    Public Sub carregar_emi(ByVal cnpj As String)

        Dim Sql As String = "SELECT * FROM cliente INNER JOIN municipio ON cliente.cod_munic = municipio.codigo_municipio WHERE cliente.cliente_ativo = '1' and cliente.cnpjcpf_cli = '" & cnpj & "'"

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = Sql


        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read

                If cnpj.Length = 14 Then
                    mskcnpj_emi.Mask = "00,000,000/0000-00"
                Else
                    mskcnpj_emi.Mask = "000,000,000-00"
                End If

                mskcnpj_emi.Text = cnpj

                txtnome_emi.Text = reader("nome_cli")

                lbluf.Text = reader("UF")

                Panel_item.Enabled = True

                carrega_cfop()

                carrega_pis_cofins_frete()

            End While

        End Using


        SQLcommand.Dispose()
        oConn.Close()


        If txtnome_emi.Text = "" Then
            MsgBox("Fornecedor não cadastrado !", MsgBoxStyle.Exclamation, "Aviso !")
            mskcnpj_emi.Focus()
            Exit Sub
        End If


        If cbomodelo.Text = "57" Or cbomodelo.Text = "07" Or cbomodelo.Text = "08" Or cbomodelo.Text = "21" Or cbomodelo.Text = "22" Then
            lblaliqcofins_frete.Visible = True
            lblaliqpis_frete.Visible = True
            txtaliqcofins_frete.Visible = True
            txtaliqpis_frete.Visible = True

            Panel_item.Visible = False
            mskchavecte.Visible = True
            lblchave_cte.Visible = True

            lblfrete_vlr.Visible = True
            txtfrete_vlr.Visible = True
            lblicms_frete.Visible = True
            cboaliqfrete.Visible = True
            Panel_ini.Enabled = False
            cbocstpisfrete.Visible = True
            lblpisfrete.Visible = True
            LBLCFOP.Visible = True
            CBOCFOP_CORPO.Visible = True
            mskchavecte.Focus()
            carrega_pis_cofins_frete()
        End If

        If cbomodelo.Text = "06" Then

            lblaliqcofins_frete.Visible = True
            lblaliqpis_frete.Visible = True
            txtaliqcofins_frete.Visible = True
            txtaliqpis_frete.Visible = True

            lblfrete_vlr.Text = "Valor Conta"
            Panel_item.Visible = False
            lblchave_cte.Visible = True
            lblfrete_vlr.Visible = True
            txtfrete_vlr.Visible = True
            lblicms_frete.Visible = True
            cboaliqfrete.Visible = True
            LBLCFOP.Visible = True
            CBOCFOP_CORPO.Visible = True
            Panel_ini.Enabled = False
            cbocstpisfrete.Visible = True
            lblpisfrete.Visible = True
            carrega_pis_cofins_frete()

        End If

    End Sub

    Private Sub mskcnpj_emi_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskcnpj_emi.MaskInputRejected

    End Sub

    Private Sub cboncm_item_LostFocus(sender As Object, e As EventArgs) Handles cboncm_item.LostFocus
        Try
            If cboncm_item.Text <> "" Then
                carrega_cest()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub calcular_valor_totais_nfe()

        txtvlrtotalprod_nfe.Text = CDec(txtvlrtotalprod_nfe.Text) + CDec(txtvlrtotal_item.Text)
        txtvlrtotalprod_nfe.Text = formata_valor_campo(txtvlrtotalprod_nfe.Text)

        txtvlrtotalbaseicms_nfe.Text = CDec(txtvlrtotalbaseicms_nfe.Text) + CDec(txtbaseicms_item.Text)
        txtvlrtotalbaseicms_nfe.Text = formata_valor_campo(txtvlrtotalbaseicms_nfe.Text)

        txtvlrtotalicms_nfe.Text = CDec(txtvlrtotalicms_nfe.Text) + CDec(txtvlricms_item.Text)
        txtvlrtotalicms_nfe.Text = formata_valor_campo(txtvlrtotalicms_nfe.Text)

        ' txtvlrtotalbasest_nfe.Text = CDec(txtvlrtotalbasest_nfe.Text) + CDec(txtbasest_item.Text)
        '  txtvlrtotalbasest_nfe.Text = formata_valor_campo(txtvlrtotalbasest_nfe.Text)


        txtvlrtotalbasest_nfe.Text = CDec(txtvlrtotalbasest_nfe.Text) + CDec(txtbcst_item.Text)
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

        txtvlrtotaloutras_nfe.Text = CDec(txtvlrtotaloutras_nfe.Text) + CDec(txtvlroutros_item.Text)
        txtvlrtotaloutras_nfe.Text = formata_valor_campo(txtvlrtotaloutras_nfe.Text)

        txtvlrtotalseg_nfe.Text = CDec(txtvlrtotalseg_nfe.Text) + CDec(txtvlrseguro_item.Text)
        txtvlrtotalseg_nfe.Text = formata_valor_campo(txtvlrtotalseg_nfe.Text)

        txtvlrtotaloutras_nfe.Text = CDec(txtvlrtotaloutras_nfe.Text) + CDec(txtvlroutros_item.Text)
        txtvlrtotaloutras_nfe.Text = formata_valor_campo(txtvlrtotaloutras_nfe.Text)


        txtvlrfemst.Text = CDec(txtvlrfemst.Text) + CDec(txtfcpst_item.Text)
        txtvlrfemst.Text = formata_valor_campo(txtvlrfemst.Text)

        '    txtvlrtotalvFCPUFDest.Text = CDec(txtvlrtotalvFCPUFDest.Text) + CDec(txtbaseredicmsst_item.Text)
        '   txtvlrtotalvICMSUFDest.Text = CDec(txtvlrtotalvICMSUFDest.Text) + CDec(txtbaseredicmsst_item.Text)
        '   txtvlrtotalvICMSUFRemet.Text = CDec(txtvlrtotalvICMSUFRemet.Text) + CDec(txtbaseredicmsst_item.Text)


        '  If chkfundopobreza.Checked = True Then


        'txtvlrtotalFCP.Text = CDec(txtvlrtotalFCP.Text) + CDec(txtvFCP.Text)

        ' txtvlrtotalFCPST.Text = CDec(txtvlrtotalFCPST.Text) + CDec(txtvFCPST.Text)

        '  End If

        txtvlrtotal_nfe.Text = valor_campo_vazio()
        txtvlrtotal_nfe.Text = (CDec(txtvlrtotalprod_nfe.Text) + CDec(txtvlrtotalst_nfe.Text) + CDec(txtvrltotalipi_nfe.Text) + CDec(txtvlrtotalfrete_nfe.Text) + CDec(txtvlrtotaloutras_nfe.Text) + CDec(txtvlrtotalseg_nfe.Text) + CDec(txtvlrfemst.Text)) - CDec(txtvlrtotaldesc_nfe.Text)
        txtvlrtotal_nfe.Text = formata_valor_campo(txtvlrtotal_nfe.Text)


    End Sub


    Private Sub Subtrair_valor_totais_nfe()

        txtvlrtotalprod_nfe.Text = CDec(txtvlrtotalprod_nfe.Text) - CDec(dgvitens.CurrentRow.Cells("vlrtotal_grid").Value)
        txtvlrtotalprod_nfe.Text = formata_valor_campo(txtvlrtotalprod_nfe.Text)

        '  MsgBox(CDec(dgvgrid_xml.CurrentRow.Cells("baseicms").Value))
        ' MsgBox(CDec(txtvlrtotalbaseicms_nfe.Text))
        ' MsgBox(CDec(txtvlrtotalbaseicms_nfe.Text) - CDec(dgvgrid_xml.CurrentRow.Cells("baseicms").Value))
        txtvlrtotalbaseicms_nfe.Text = CDec(txtvlrtotalbaseicms_nfe.Text) - CDec(dgvitens.CurrentRow.Cells("baseicms_grid").Value)
        txtvlrtotalbaseicms_nfe.Text = formata_valor_campo(txtvlrtotalbaseicms_nfe.Text)

        txtvlrtotalicms_nfe.Text = CDec(txtvlrtotalicms_nfe.Text) - CDec(dgvitens.CurrentRow.Cells("vlricms_grid").Value)
        txtvlrtotalicms_nfe.Text = formata_valor_campo(txtvlrtotalicms_nfe.Text)

        txtvlrtotalbasest_nfe.Text = CDec(txtvlrtotalbasest_nfe.Text) - CDec(dgvitens.CurrentRow.Cells("basest_grid").Value)
        txtvlrtotalbasest_nfe.Text = formata_valor_campo(txtvlrtotalbasest_nfe.Text)

        txtvlrtotalst_nfe.Text = CDec(txtvlrtotalst_nfe.Text) - CDec(dgvitens.CurrentRow.Cells("vlrst_grid").Value)
        txtvlrtotalst_nfe.Text = formata_valor_campo(txtvlrtotalst_nfe.Text)

        txtvlrtotalpis_nfe.Text = CDec(txtvlrtotalpis_nfe.Text) - CDec(dgvitens.CurrentRow.Cells("vlrpis_grid").Value)
        txtvlrtotalpis_nfe.Text = formata_valor_campo(txtvlrtotalpis_nfe.Text)

        txtvlrtotalcofins_nfe.Text = CDec(txtvlrtotalcofins_nfe.Text) - CDec(dgvitens.CurrentRow.Cells("vlrcofins_grid").Value)
        txtvlrtotalcofins_nfe.Text = formata_valor_campo(txtvlrtotalcofins_nfe.Text)

        txtvrltotalipi_nfe.Text = CDec(txtvrltotalipi_nfe.Text) - CDec(dgvitens.CurrentRow.Cells("vlripi_grid").Value)
        txtvrltotalipi_nfe.Text = formata_valor_campo(txtvrltotalipi_nfe.Text)


        txtvlrtotaldesc_nfe.Text = CDec(txtvlrtotaldesc_nfe.Text) - CDec(dgvitens.CurrentRow.Cells("vlrdesc_grid").Value)
        txtvlrtotaldesc_nfe.Text = formata_valor_campo(txtvlrtotaldesc_nfe.Text)


        txtvlrtotalfrete_nfe.Text = CDec(txtvlrtotalfrete_nfe.Text) - CDec(dgvitens.CurrentRow.Cells("vlrfrete_grid").Value)
        txtvlrtotalfrete_nfe.Text = formata_valor_campo(txtvlrtotalfrete_nfe.Text)


        txtvlrtotalseg_nfe.Text = CDec(txtvlrtotalseg_nfe.Text) - CDec(dgvitens.CurrentRow.Cells("vlrseguro_grid").Value)
        txtvlrtotalseg_nfe.Text = formata_valor_campo(txtvlrtotalseg_nfe.Text)

        txtvlrtotaloutras_nfe.Text = CDec(txtvlrtotaloutras_nfe.Text) - CDec(dgvitens.CurrentRow.Cells("vlroutros_grid").Value)
        txtvlrtotaloutras_nfe.Text = formata_valor_campo(txtvlrtotaloutras_nfe.Text)


        txtvlrfemst.Text = CDec(txtvlrfemst.Text) - CDec(dgvitens.CurrentRow.Cells("vlrfcpst_grid").Value)
        txtvlrfemst.Text = formata_valor_campo(txtvlrfemst.Text)

        txtvlrtotal_nfe.Text = valor_campo_vazio()
        txtvlrtotal_nfe.Text = (CDec(txtvlrtotalprod_nfe.Text) + CDec(txtvlrtotalst_nfe.Text) + CDec(txtvrltotalipi_nfe.Text) + CDec(txtvlrtotalfrete_nfe.Text) + CDec(txtvlrtotaloutras_nfe.Text) + CDec(txtvlrtotalseg_nfe.Text)) - CDec(txtvlrtotaldesc_nfe.Text)
        txtvlrtotal_nfe.Text = formata_valor_campo(txtvlrtotal_nfe.Text)



        txtvlrseguro_item.Text = CDec(txtvlrtotaloutras_nfe.Text) - CDec(dgvitens.CurrentRow.Cells("vlrseguro_grid").Value)
        txtvlrseguro_item.Text = formata_valor_campo(txtvlrseguro_item.Text)

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        FrmConsultaDestinatario.Text = "Consulta Fornecedor NFe entrada"
        FrmConsultaDestinatario.ShowDialog()

        If txtnome_emi.Text <> "" Then
            txtcodigoprod_item.Focus()
        End If
    End Sub

    Private Sub bntexcluir_item_Click(sender As Object, e As EventArgs) Handles bntexcluir_item.Click
        If dgvitens.Rows.Count <> 0 Then
            If MessageBox.Show("Deseja realmente excluir o item selecionado ? ", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Subtrair_valor_totais_nfe()
                dgvitens.Rows.Remove(dgvitens.CurrentRow)
            End If
        End If
    End Sub

    Private Sub bntalterar_item_Click(sender As Object, e As EventArgs) Handles bntalterar_item.Click
        If dgvitens.Rows.Count <> 0 Then
            If MessageBox.Show("Deseja alterar o item selecionado ? ", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                txtcodigoprod_item.Text = dgvitens.CurrentRow.Cells("codprod_grid").Value
                txtdescprod_item.Text = dgvitens.CurrentRow.Cells("descprod_grid").Value
                lblun.Text = dgvitens.CurrentRow.Cells("un_grid").Value
                txtqtde_item.Text = dgvitens.CurrentRow.Cells("qtde_grid").Value
                txtvlrunit_item.Text = dgvitens.CurrentRow.Cells("vlrunit_grid").Value
                vlrunit = dgvitens.CurrentRow.Cells("vlrunit_grid").Value
                txtvlrdesc_item.Text = dgvitens.CurrentRow.Cells("vlrdesc_grid").Value
                txtvlrtotal_item.Text = dgvitens.CurrentRow.Cells("vlrtotal_grid").Value
                cboncm_item.Text = dgvitens.CurrentRow.Cells("ncm_grid").Value
                cbocest_item.Text = dgvitens.CurrentRow.Cells("cest_grid").Value
                cbocfop_item.Text = cbocfop_item.FindString(dgvitens.CurrentRow.Cells("cfop_grid").Value)
                cbocst_item.Text = dgvitens.CurrentRow.Cells("cst_grid").Value

                txtaliqicms_item.Text = dgvitens.CurrentRow.Cells("aliqicms_grid").Value
                txtbaseicms_item.Text = dgvitens.CurrentRow.Cells("baseicms_grid").Value
                txtbaseredicms_item.Text = dgvitens.CurrentRow.Cells("Redbcicms_grid").Value
                txtvlricms_item.Text = dgvitens.CurrentRow.Cells("vlricms_grid").Value
                txtvlrst_item.Text = dgvitens.CurrentRow.Cells("vlrst_grid").Value

                txtbcst_item.Text = dgvitens.CurrentRow.Cells("basest_grid").Value
                cbocstpis_item.Text = dgvitens.CurrentRow.Cells("cstpis_grid").Value
                txtaliqpis_item.Text = dgvitens.CurrentRow.Cells("aliqpis_grid").Value
                txtvlrpis_item.Text = dgvitens.CurrentRow.Cells("vlrpis_grid").Value

                txtaliqcofins_item.Text = dgvitens.CurrentRow.Cells("aliqcofins_grid").Value
                txtvlrcofins_item.Text = dgvitens.CurrentRow.Cells("vlrcofins_grid").Value

                cbocstipi_item.Text = dgvitens.CurrentRow.Cells("cstipi_grid").Value
                txtaliqipi_item.Text = dgvitens.CurrentRow.Cells("aliqipi_grid").Value
                txtvlripi_item.Text = dgvitens.CurrentRow.Cells("vlripi_grid").Value

                txtvlroutros_item.Text = dgvitens.CurrentRow.Cells("vlroutros_grid").Value
                txtvlrfrete_item.Text = dgvitens.CurrentRow.Cells("vlrfrete_grid").Value
                txtvlrseguro_item.Text = dgvitens.CurrentRow.Cells("vlrseguro_grid").Value
                txtvlrfemst.Text = dgvitens.CurrentRow.Cells("vlrfcpst_grid").Value

                Subtrair_valor_totais_nfe()
                dgvitens.Rows.Remove(dgvitens.CurrentRow)

                lbliten.Visible = False
                lbliten.Text = "alterar"


            End If
        End If
    End Sub

    Private Sub txtserienfe_GotFocus(sender As Object, e As EventArgs) Handles txtserienfe.GotFocus
        If txtnumeronf.Text = "" Then
            txtnumeronf.Focus()
        End If

        If importar = True Then
            txtqtde_item.Focus()
        End If
    End Sub

    Private Sub txtserienfe_TextChanged(sender As Object, e As EventArgs) Handles txtserienfe.TextChanged

    End Sub

    Private Sub txtbaseredicms_item_LostFocus(sender As Object, e As EventArgs) Handles txtbaseredicms_item.LostFocus
        If txtbaseredicms_item.Text <> "" Then
            txtbaseredicms_item.Text = Format(CDec(txtbaseredicms_item.Text), "#,##0.00")
            calcular_valor_item()
        Else
            txtbaseredicms_item.Text = "0,00"
        End If
    End Sub

    Private Sub salvar()

        If importar = True Then
            If txtvlrxml.Text <> txtvlrtotal_nfe.Text Then
                MsgBox("O valor Total da Nota fiscal esta Diferente do XML ?", MsgBoxStyle.Exclamation, "Aviso !")
                Exit Sub
            End If

            If txtvrltotalipi_nfe.Text <> txtipitotalxml.Text Then
                MsgBox("O valor Total do IPI esta Diferente do XML ?", MsgBoxStyle.Exclamation, "Aviso !")
                Exit Sub
            End If
            If txtvlrtotalfrete_nfe.Text <> txtfretetotalxml.Text Then
                MsgBox("O valor Total do Frete esta Diferente do XML ?", MsgBoxStyle.Exclamation, "Aviso !")
                Exit Sub
            End If
            If txtvlrtotaloutras_nfe.Text <> txtoutrostotalxml.Text Then
                MsgBox("O valor Total das Outroas despesas esta Diferente do XML ?", MsgBoxStyle.Exclamation, "Aviso !")
                Exit Sub
            End If

            If txtvlrtotalst_nfe.Text <> txtsttotalxml.Text Then
                MsgBox("O valor Total do ICMS ST esta Diferente do XML ?", MsgBoxStyle.Exclamation, "Aviso !")
                Exit Sub
            End If
        End If


        cont_item = 0
        Dim chave_par As String = txtnumeronf.Text & txtserienfe.Text & cbomodelo.Text & mskcnpj_emi.Text

        Dim ret As Integer
        Dim sql As String
        ret = verificar_regexiste("delete from nfe_e where Chave_par = '" & chave_par & "'")

        sql = "INSERT INTO nfe_e (chave_nfe, numero_nfe, serie_nfe, modelo_nfe, cnpj_for, data_emi, data_ent, tipo_pag, base_icms, vlr_icms, base_st, vlr_st, vlr_nfprod, vlr_totalnf, vlr_desc, vlr_frete, vlroutros, vlr_seguro, vlr_fcpst, vlr_ipi, vlr_pis, vlr_cofins, chave_par, aliqicms_frete, cstpis, cfop, aliq_pisfrete, aliq_cofinsfrete) VALUES (@Chave_nfe, @numero_nfe, @serie_nfe, @modelo_nfe, @cnpj_for, @data_emi, @data_ent, @tipo_pag, @base_icms, @vlr_icms, @base_st, @vlr_st, @vlr_nfprod, @vlr_totalnf, @vlr_desc, @vlr_frete, @vlroutros, @vlr_seguro, @vlr_fcpst, @vlr_ipi, @vlr_pis, @vlr_cofins, @chave_par, @aliqicms_frete, @cstpis, @cfop, @aliq_pisfrete, @aliq_cofinsfrete)"


        conectar_mysqlDFe()
        Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)

        insertSQL.Parameters.Add(New MySqlParameter("chave_nfe", lblchave.Text))


        insertSQL.Parameters.Add(New MySqlParameter("numero_nfe", txtnumeronf.Text))
        insertSQL.Parameters.Add(New MySqlParameter("serie_nfe", txtserienfe.Text))
        insertSQL.Parameters.Add(New MySqlParameter("modelo_nfe", cbomodelo.Text))

        insertSQL.Parameters.Add(New MySqlParameter("cnpj_for", mskcnpj_emi.Text))

        insertSQL.Parameters.Add(New MySqlParameter("data_emi", Convert.ToDateTime(data_emissao.Text).ToString("yyyy-MM-dd")))
        insertSQL.Parameters.Add(New MySqlParameter("data_ent", Convert.ToDateTime(data_entrada.Text).ToString("yyyy-MM-dd")))
        insertSQL.Parameters.Add(New MySqlParameter("tipo_pag", "0"))


        insertSQL.Parameters.Add(New MySqlParameter("base_icms", format_val_mysql_ent(txtvlrtotalbaseicms_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("vlr_icms", format_val_mysql_ent(txtvlrtotalicms_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("base_st", format_val_mysql_ent(txtvlrtotalbasest_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("vlr_st", format_val_mysql_ent(txtvlrtotalst_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("vlr_nfprod", format_val_mysql_ent(txtvlrtotalprod_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("vlr_totalnf", format_val_mysql_ent(txtvlrtotal_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("vlr_desc", format_val_mysql_ent(txtvlrtotaldesc_nfe.Text)))

        insertSQL.Parameters.Add(New MySqlParameter("vlr_frete", format_val_mysql_ent(txtvlrtotalfrete_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("vlroutros", format_val_mysql_ent(txtvlrtotaloutras_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("vlr_seguro", format_val_mysql_ent(txtvlrtotalseg_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("vlr_fcpst", format_val_mysql_ent(txtvlrfemst.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("vlr_ipi", format_val_mysql_ent(txtvrltotalipi_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("vlr_pis", format_val_mysql_ent(txtvlrtotalpis_nfe.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("vlr_cofins", format_val_mysql_ent(txtvlrtotalcofins_nfe.Text)))

        insertSQL.Parameters.Add(New MySqlParameter("chave_par", chave_par))
        insertSQL.Parameters.Add(New MySqlParameter("aliqicms_frete", format_val_mysql_ent(cboaliqfrete.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("cstpis", cbocstpisfrete.Text.Substring(0, 2)))
        insertSQL.Parameters.Add(New MySqlParameter("cfop", CBOCFOP_CORPO.Text.Substring(0, 4)))

        insertSQL.Parameters.Add(New MySqlParameter("aliq_pisfrete", format_val_mysql_ent(txtaliqpis_frete.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("aliq_cofinsfrete", format_val_mysql_ent(txtaliqcofins_frete.Text)))

        insertSQL.ExecuteNonQuery()
        oConn.Close()


        ''''''''''''''''''''''''''Rotina para salvar item''''''''''''''''''''''''''''''''''''''''''''
        ret = executa_query("delete from nfe_eitens where Chave_par = '" & chave_par & "'")


        sql = "INSERT INTO nfe_eitens (codigo_prod, un, qtde, ncm, cest, vlr_unit, vlr_desc, vlr_total, cfop, cst, aliq_icms, bc_icms, rebc_icms, vlr_icms, bc_st, vlr_st, cst_piscofins, aliq_pis, vlr_pis, aliq_cofins, vlr_cofins, cst_ipi, aliq_ipi, vlr_ipi, vlr_outros, vlr_frete, vlr_seguro, vlrfcp_st, chave_par, data_ent) VALUES (@codigo_prod, @un, @qtde, @ncm, @cest, @vlr_unit, @vlr_desc, @vlr_total, @cfop, @cst, @aliq_icms, @bc_icms, @rebc_icms, @vlr_icms, @bc_st, @vlr_st, @cst_piscofins, @aliq_pis, @vlr_pis, @aliq_cofins, @vlr_cofins, @cst_ipi, @aliq_ipi, @vlr_ipi, @vlr_outros, @vlr_frete, @vlr_seguro, @vlrfcp_st, @chave_par, @data_ent)"



        For Each row As DataGridViewRow In Me.dgvitens.Rows
            conectar_mysqlDFe()
            Dim insertSQL2 As MySqlCommand = New MySqlCommand(sql, oConn)

            insertSQL2.Parameters.Add(New MySqlParameter("codigo_prod", row.Cells("codprod_grid").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("un", row.Cells("un_grid").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("qtde", row.Cells("qtde_grid").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("ncm", row.Cells("ncm_grid").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("cest", row.Cells("cest_grid").Value))

            insertSQL2.Parameters.Add(New MySqlParameter("vlr_unit", format_val_mysql_ent(row.Cells("vlrunit_grid").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_desc", format_val_mysql_ent(row.Cells("vlrdesc_grid").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_total", format_val_mysql_ent(row.Cells("vlrtotal_grid").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("cfop", row.Cells("cfop_grid").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("cst", row.Cells("cst_grid").Value))


            insertSQL2.Parameters.Add(New MySqlParameter("aliq_icms", format_val_mysql_ent(row.Cells("aliqicms_grid").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("bc_icms", format_val_mysql_ent(row.Cells("baseicms_grid").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("rebc_icms", format_val_mysql_ent(row.Cells("Redbcicms_grid").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_icms", format_val_mysql_ent(row.Cells("vlricms_grid").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("bc_st", format_val_mysql_ent(row.Cells("basest_grid").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_st", format_val_mysql_ent(row.Cells("vlrst_grid").Value)))


            insertSQL2.Parameters.Add(New MySqlParameter("cst_piscofins", dgvitens.CurrentRow.Cells("cstpis_grid").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("aliq_pis", format_val_mysql_ent(dgvitens.CurrentRow.Cells("aliqpis_grid").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_pis", format_val_mysql_ent(dgvitens.CurrentRow.Cells("vlrpis_grid").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("aliq_cofins", format_val_mysql_ent(dgvitens.CurrentRow.Cells("aliqcofins_grid").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_cofins", format_val_mysql_ent(dgvitens.CurrentRow.Cells("vlrcofins_grid").Value)))


            insertSQL2.Parameters.Add(New MySqlParameter("cst_ipi", dgvitens.CurrentRow.Cells("cstipi_grid").Value))
            insertSQL2.Parameters.Add(New MySqlParameter("aliq_ipi", format_val_mysql_ent(dgvitens.CurrentRow.Cells("aliqipi_grid").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_ipi", format_val_mysql_ent(dgvitens.CurrentRow.Cells("vlripi_grid").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_outros", format_val_mysql_ent(dgvitens.CurrentRow.Cells("vlroutros_grid").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_frete", format_val_mysql_ent(dgvitens.CurrentRow.Cells("vlrfrete_grid").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlr_seguro", format_val_mysql_ent(dgvitens.CurrentRow.Cells("vlrseguro_grid").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("vlrfcp_st", format_val_mysql_ent(dgvitens.CurrentRow.Cells("vlrseguro_grid").Value)))
            insertSQL2.Parameters.Add(New MySqlParameter("chave_par", chave_par))
            insertSQL2.Parameters.Add(New MySqlParameter("data_ent", Convert.ToDateTime(data_entrada.Value).ToString("yyyy-MM-dd")))

            insertSQL2.ExecuteNonQuery()
            oConn.Close()

            executa_query("update produto set data_nfent = '" & Now.ToString("yyyy-MM-dd") & "' where codigo_prod = '" & row.Cells("codprod_grid").Value & "'")

            executa_query("update produto set Nr_nfe = '" & txtnumeronf.Text & "' where codigo_prod = '" & row.Cells("codprod_grid").Value & "'")

        Next

        MsgBox("Nota Fiscal salva no banco com Sucesso !", MsgBoxStyle.Information, "Aviso !")


        If cbomodelo.Text = "57" Or cbomodelo.Text = "06" Then

            Panel_item.Visible = True
            mskchavecte.Visible = False
            lblchave_cte.Visible = False

            lblfrete_vlr.Visible = False
            txtfrete_vlr.Visible = False
            lblicms_frete.Visible = False
            cboaliqfrete.Visible = False
            cbocstpisfrete.Visible = False
            lblpisfrete.Visible = False
            mskchavecte.Clear()
            txtfrete_vlr.Text = "0,00"
            cboaliqfrete.Text = "0,00"
            txtaliqcofins_frete.Text = "0,00"
            txtaliqpis_frete.Text = "0,00"

            LBLCFOP.Visible = False
            CBOCFOP_CORPO.Visible = False
            lblaliqcofins_frete.Visible = False
            lblaliqpis_frete.Visible = False
            txtaliqcofins_frete.Visible = False
            txtaliqpis_frete.Visible = False
        End If

        If importar = True Then
            Me.Close()
        End If

        dgvitens.Rows.Clear()
        Panel_item.Enabled = False
        Panel_ini.Enabled = False
        limpar_principal()
        txtnumeronf.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If txtnome_emi.Text <> "" Then
            salvar()
        End If



    End Sub

    Public Sub consulta(ByVal valor As String)
        Dim aliq As String, cfop As String
        Dim Sql As String = "SELECT * FROM nfe_e where chave_par = '" & valor & "'"

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = Sql
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read

                lblchave.Text = reader("chave_nfe")


                txtnumeronf.Text = reader("numero_nfe")
                txtserienfe.Text = reader("serie_nfe")
                cbomodelo.Text = reader("modelo_nfe")

                mskcnpj_emi.Text = reader("cnpj_for")
                txtnome_emi.Text = ret_valor_campo("select * from cliente where cnpjcpf_cli = '" & reader("cnpj_for") & "'", "nome_cli")

                data_emissao.Text = reader("data_emi")
                data_entrada.Text = reader("data_ent")

                txtvlrtotalbaseicms_nfe.Text = format_val_mysql_ret(reader("base_icms"))
                txtvlrtotalicms_nfe.Text = format_val_mysql_ret(reader("vlr_icms"))
                txtvlrtotalbasest_nfe.Text = format_val_mysql_ret(reader("base_st"))
                txtvlrtotalst_nfe.Text = format_val_mysql_ret(reader("vlr_st"))
                txtvlrtotalprod_nfe.Text = format_val_mysql_ret(reader("vlr_nfprod"))
                txtvlrtotal_nfe.Text = format_val_mysql_ret(reader("vlr_totalnf"))
                txtvlrtotaldesc_nfe.Text = format_val_mysql_ret(reader("vlr_desc"))

                txtvlrtotalfrete_nfe.Text = format_val_mysql_ret(reader("vlr_frete"))
                txtvlrtotaloutras_nfe.Text = format_val_mysql_ret(reader("vlroutros"))
                txtvlrtotalseg_nfe.Text = format_val_mysql_ret(reader("vlr_seguro"))
                txtvlrfemst.Text = format_val_mysql_ret(reader("vlr_fcpst"))
                txtvrltotalipi_nfe.Text = format_val_mysql_ret(reader("vlr_ipi"))
                txtvlrtotalpis_nfe.Text = format_val_mysql_ret(reader("vlr_pis"))
                txtvlrtotalcofins_nfe.Text = format_val_mysql_ret(reader("vlr_cofins"))
                cboaliqfrete.Text = format_val_mysql_ret(reader("aliqicms_frete"))

                aliq = reader("cstpis").ToString
                cfop = reader("cfop").ToString

                txtaliqpis_frete.Text = format_val_mysql_ret(reader("aliq_pisfrete"))
                txtaliqcofins_frete.Text = format_val_mysql_ret(reader("aliq_cofinsfrete"))

            End While

        End Using

        '  Dim chv_par As String = txtnumeronf.Text & txtserienfe.Text & cbomodelo.Text & mskcnpj_emi.Text
        dgvitens.Rows.Clear()

        Sql = "SELECT * FROM nfe_eitens where chave_par = '" & valor & "'"

        conectar_mysqlDFe()
        Dim SQLcommand2 As MySqlCommand
        SQLcommand2 = oConn.CreateCommand
        SQLcommand2.CommandText = Sql
        cont_item = 0

        Using reader As MySqlDataReader = SQLcommand2.ExecuteReader

            While reader.Read
                cont_item += 1

                dgvitens.Rows.Add(cont_item, reader("codigo_prod"), ret_valor_campo("select * from produto where codigo_prod = '" & reader("codigo_prod") & "'", "desc_prod"), reader("un"), reader("qtde"), format_val_mysql_ret(reader("vlr_unit")), _
                                  format_val_mysql_ret(reader("vlr_desc")), format_val_mysql_ret(reader("vlr_total")), reader("ncm"), reader("cest"), reader("cfop"), _
                        reader("cst"), format_val_mysql_ret(reader("bc_icms")), format_val_mysql_ret(reader("rebc_icms")), format_val_mysql_ret(reader("aliq_icms")), format_val_mysql_ret(reader("vlr_icms")), format_val_mysql_ret(reader("vlr_st")), _
                        reader("cst_piscofins"), format_val_mysql_ret(reader("aliq_pis")), format_val_mysql_ret(reader("vlr_pis")), format_val_mysql_ret(reader("aliq_cofins")), format_val_mysql_ret(reader("vlr_cofins")), reader("cst_ipi"), _
                        format_val_mysql_ret(reader("aliq_ipi")), format_val_mysql_ret(reader("vlr_ipi")), format_val_mysql_ret(reader("bc_st")), format_val_mysql_ret(reader("vlr_frete")), format_val_mysql_ret(reader("vlr_outros")), format_val_mysql_ret(reader("vlr_seguro")), format_val_mysql_ret(reader("vlrfcp_st")))

                Panel_item.Enabled = True
            End While

        End Using

        If Panel_item.Enabled = True Then


            carrega_cfop()

            carrega_ncm()

            carrega_cst_icms("0")

            carrega_IPI()

            carrega_pis_cofins()

        End If

        If cbomodelo.Text = "57" Or cbomodelo.Text = "06" Or cbomodelo.Text = "07" Or cbomodelo.Text = "08" Or cbomodelo.Text = "21" Or cbomodelo.Text = "22" Then

            Panel_item.Visible = False
            mskchavecte.Visible = True
            lblchave_cte.Visible = True

            lblfrete_vlr.Visible = True
            txtfrete_vlr.Visible = True
            lblicms_frete.Visible = True
            cboaliqfrete.Visible = True
            cbocstpisfrete.Visible = True
            lblpisfrete.Visible = True
            lblaliqcofins_frete.Visible = True
            lblaliqpis_frete.Visible = True
            txtaliqcofins_frete.Visible = True
            txtaliqpis_frete.Visible = True

            txtfrete_vlr.Text = txtvlrtotalfrete_nfe.Text

            mskchavecte.Text = lblchave.Text

            LBLCFOP.Visible = True
            CBOCFOP_CORPO.Visible = True

            cbocstpisfrete.SelectedIndex = cbocstpisfrete.FindString(aliq)

            ' CBOCFOP_CORPO.SelectedText = 0

            CBOCFOP_CORPO.SelectedIndex = CBOCFOP_CORPO.FindString(cfop)
        End If
    End Sub

    Private Sub txtnumeronf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumeronf.KeyPress
        If (e.KeyChar = Chr(13)) Then

        End If
    End Sub

    Private Sub txtnumeronf_TextChanged(sender As Object, e As EventArgs) Handles txtnumeronf.TextChanged

    End Sub

    Public Sub NOVO()
        Panel_ini.Enabled = True
        txtnumeronf.ReadOnly = False
        txtserienfe.ReadOnly = False
        cbomodelo.Enabled = False
        data_emissao.Enabled = True
        mskcnpj_emi.ReadOnly = False
        PictureBox5.Enabled = True
        cbomodelo.Enabled = True

        txtnumeronf.Focus()
        limpar_itens()
        limpar_principal()

        carrega_cfop()

        carrega_ncm()

        carrega_cst_icms("0")

        carrega_IPI()

        carrega_pis_cofins()

        If importar = False Then
            lbliten.Visible = False
        End If

        Panel_item.Visible = True
        mskchavecte.Visible = False
        lblchave_cte.Visible = False

        lblfrete_vlr.Visible = False
        txtfrete_vlr.Visible = False
        lblicms_frete.Visible = False
        cboaliqfrete.Visible = False
        cbocstpisfrete.Visible = False
        lblpisfrete.Visible = False
        LBLCFOP.Visible = False
        CBOCFOP_CORPO.Visible = False
        lblaliqcofins_frete.Visible = False
        lblaliqpis_frete.Visible = False
        txtaliqcofins_frete.Visible = False
        txtaliqpis_frete.Visible = False

        mskchavecte.Clear()
        txtfrete_vlr.Text = "0,00"
        cboaliqfrete.Text = "0,00"
        txtaliqcofins_frete.Text = "0,00"
        txtaliqpis_frete.Text = "0,00"
        cbomodelo.Text = "01"

    End Sub

    Public Sub importacao()
        importar = True
        txtnumeronf.ReadOnly = True
        txtserienfe.ReadOnly = True
        cbomodelo.Enabled = False
        data_emissao.Enabled = False
        mskcnpj_emi.ReadOnly = True
        lblchave.Text = frmxml.mskchave.Text

        txtvlrxml.Text = format_val_mysql_ret(frmxml.txtvlrtotal_nfe.Text)
        txtipitotalxml.Text = format_val_mysql_ret(frmxml.txtvrltotalipi_nfe.Text)
        txtfretetotalxml.Text = format_val_mysql_ret(frmxml.txtvlrtotalfrete_nfe.Text)
        txtoutrostotalxml.Text = format_val_mysql_ret(txtvlrtotaloutras_nfe.Text)
        txtsttotalxml.Text = format_val_mysql_ret(txtvlrtotalst_nfe.Text)

        txtnumeronf.Text = frmxml.txtnumeronfe.Text
        lbluf.Text = frmxml.txtuffor.Text
        txtserienfe.Text = frmxml.txtserienfe.Text
        cbomodelo.Text = frmxml.txtmodnfe.Text
        data_emissao.Value = frmxml.txtdataemissao.Text
        mskcnpj_emi.Text = frmxml.mskcnpjfor.Text
        txtnome_emi.Text = frmxml.txtnomefor.Text
        data_entrada.Value = Now.Date

        cont_itenxml += 1
        cont_itenxml_total = frmxml.dgvgrid_xml.Rows.Count

        lbliten.Text = "Iten: " & cont_itenxml & " de " & cont_itenxml_total
        If cont_itenxml <= cont_itenxml_total Then
            txtcodigoprod_item.Text = frmxml.dgvgrid_xml.Rows.Item(ir).Cells("codigo_prod_grid").Value
            pesquisa_cod()

            txtvlrunit_item.Text = format_val_mysql_ret(frmxml.dgvgrid_xml.Rows.Item(ir).Cells("vlrunit").Value)
            vlrunit = format_val_mysql_ret(frmxml.dgvgrid_xml.Rows.Item(ir).Cells("vlrunit").Value)
            cboncm_item.Text = frmxml.dgvgrid_xml.Rows.Item(ir).Cells("ncm").Value
            cbocest_item.Text = frmxml.dgvgrid_xml.Rows.Item(ir).Cells("cest").Value

            txtcst_xml.Text = frmxml.dgvgrid_xml.Rows.Item(ir).Cells("cst").Value

            carrega_cst_icms(frmxml.dgvgrid_xml.Rows.Item(ir).Cells("cst").Value.ToString.Substring(0, 1))

            txtbcst_item.Text = format_val_mysql_ret(frmxml.dgvgrid_xml.Rows.Item(ir).Cells("basest").Value)
            txtvlrst_item.Text = format_val_mysql_ret(frmxml.dgvgrid_xml.Rows.Item(ir).Cells("vlrst").Value)

            If txtcst_xml.Text.Length = 3 Then
                If txtcst_xml.Text.Substring(1, 2) = "60" Then
                    txtbcst_item.Text = "0,00"
                    txtvlrst_item.Text = "0,00"
                End If

                If txtcst_xml.Text.Substring(1, 2) = "60" Or txtcst_xml.Text.Substring(1, 2) = "70" Or txtcst_xml.Text.Substring(1, 2) = "10" Then

                    If lbluf.Text = empresa.sSiglaUF Then
                        cbocfop_item.SelectedIndex = cbocfop_item.FindString("1403")
                    Else
                        cbocfop_item.SelectedIndex = cbocfop_item.FindString("2403")
                    End If

                End If

                If txtcst_xml.Text.Substring(1, 2) = "00" Or txtcst_xml.Text.Substring(1, 2) = "40" Or txtcst_xml.Text.Substring(1, 2) = "41" Or txtcst_xml.Text.Substring(1, 2) = "20" Or txtcst_xml.Text.Substring(1, 2) = "30" Then

                    If lbluf.Text = empresa.sSiglaUF Then
                        cbocfop_item.SelectedIndex = cbocfop_item.FindString("1102")
                    Else
                        cbocfop_item.SelectedIndex = cbocfop_item.FindString("2102")
                    End If

                End If

            Else

                If txtcst_xml.Text.Substring(1, 3) = "500" Then
                    txtbcst_item.Text = "0,00"
                    txtvlrst_item.Text = "0,00"
                End If

                If txtcst_xml.Text.Substring(1, 3) = "201" Or txtcst_xml.Text.Substring(1, 3) = "202" Or txtcst_xml.Text.Substring(1, 3) = "500" Then

                    If lbluf.Text = empresa.sSiglaUF Then
                        cbocfop_item.SelectedIndex = cbocfop_item.FindString("1403")
                    Else
                        cbocfop_item.SelectedIndex = cbocfop_item.FindString("2403")
                    End If

                End If

                If txtcst_xml.Text.Substring(1, 3) = "101" Or txtcst_xml.Text.Substring(1, 3) = "102" Or txtcst_xml.Text.Substring(1, 3) = "103" Or txtcst_xml.Text.Substring(1, 3) = "400" Or txtcst_xml.Text.Substring(1, 3) = "300" Or txtcst_xml.Text.Substring(1, 3) = "203" Then
                    If lbluf.Text = empresa.sSiglaUF Then
                        cbocfop_item.SelectedIndex = cbocfop_item.FindString("1102")
                    Else
                        cbocfop_item.SelectedIndex = cbocfop_item.FindString("2102")
                    End If
                End If

            End If

            txtvlrfrete_item.Text = format_val_mysql_ret(frmxml.dgvgrid_xml.Rows.Item(ir).Cells("vlrfrete").Value)
            txtvlroutros_item.Text = format_val_mysql_ret(frmxml.dgvgrid_xml.Rows.Item(ir).Cells("vlroutros").Value)
            txtfcpst_item.Text = format_val_mysql_ret(frmxml.dgvgrid_xml.Rows.Item(ir).Cells("vFCP_st").Value)

            txtaliqipi_item.Text = format_val_mysql_ret(frmxml.dgvgrid_xml.Rows.Item(ir).Cells("aliqipi").Value)
            ' cbocstipi_item.Text = frmxml.dgvgrid_xml.Rows.Item(ir).Cells("cstipi").Value
            txtvlripi_item.Text = format_val_mysql_ret(frmxml.dgvgrid_xml.Rows.Item(ir).Cells("vlripi").Value)


            If frmxml.dgvgrid_xml.Rows.Item(ir).Cells("cstipi").Value = "50" Then
                cbocstipi_item.Text = "00"
            End If
            If frmxml.dgvgrid_xml.Rows.Item(ir).Cells("cstipi").Value = "51" Then
                cbocstipi_item.Text = "01"
            End If
            If frmxml.dgvgrid_xml.Rows.Item(ir).Cells("cstipi").Value = "52" Then
                cbocstipi_item.Text = "02"
            End If
            If frmxml.dgvgrid_xml.Rows.Item(ir).Cells("cstipi").Value = "53" Then
                cbocstipi_item.Text = "03"
            End If
            If frmxml.dgvgrid_xml.Rows.Item(ir).Cells("cstipi").Value = "54" Then
                cbocstipi_item.Text = "04"
            End If
            If frmxml.dgvgrid_xml.Rows.Item(ir).Cells("cstipi").Value = "55" Then
                cbocstipi_item.Text = "05"
            End If
            If frmxml.dgvgrid_xml.Rows.Item(ir).Cells("cstipi").Value = "99" Then
                cbocstipi_item.Text = "49"
            End If

            txtcest_xml.Text = frmxml.dgvgrid_xml.Rows.Item(ir).Cells("cest").Value
            txtncm_xml.Text = frmxml.dgvgrid_xml.Rows.Item(ir).Cells("ncm").Value
            txtun_xml.Text = frmxml.dgvgrid_xml.Rows.Item(ir).Cells("un").Value
            txtqtde_xml.Text = frmxml.dgvgrid_xml.Rows.Item(ir).Cells("qtde").Value
            txtqtde_item.Text = frmxml.dgvgrid_xml.Rows.Item(ir).Cells("qtde").Value.ToString.Replace(".", ",")

            If frmxml.dgvgrid_xml.Rows.Item(ir).Cells("cfop").Value = "5910" Then
                cbocfop_item.SelectedIndex = cbocfop_item.FindString("1910")
                cbocstpis_item.Text = "73"
                txtvlrpis_item.Text = "0,00"
                txtaliqpis_item.Text = "0,00"
                txtvlrcofins_item.Text = "0,00"
                txtaliqcofins_item.Text = "0,00"
            End If

            If frmxml.dgvgrid_xml.Rows.Item(ir).Cells("cfop").Value = "6910" Then
                cbocfop_item.SelectedIndex = cbocfop_item.FindString("2910")
                cbocstpis_item.Text = "73"
                txtvlrpis_item.Text = "0,00"
                txtaliqpis_item.Text = "0,00"
                txtvlrcofins_item.Text = "0,00"
                txtaliqcofins_item.Text = "0,00"
            End If


            If frmxml.dgvgrid_xml.Rows.Item(ir).Cells("cfop").Value = "5949" Then
                cbocfop_item.SelectedIndex = cbocfop_item.FindString("1949")
                cbocstpis_item.Text = "73"
                txtvlrpis_item.Text = "0,00"
                txtaliqpis_item.Text = "0,00"
                txtvlrcofins_item.Text = "0,00"
                txtaliqcofins_item.Text = "0,00"
            End If

            If frmxml.dgvgrid_xml.Rows.Item(ir).Cells("cfop").Value = "6949" Then
                cbocfop_item.SelectedIndex = cbocfop_item.FindString("2949")
                cbocstpis_item.Text = "73"
                txtvlrpis_item.Text = "0,00"
                txtaliqpis_item.Text = "0,00"
                txtvlrcofins_item.Text = "0,00"
                txtaliqcofins_item.Text = "0,00"
            End If

            ir += 1
            txtqtde_item.Focus()



        Else

            lbliten.Visible = False
            lbliten.Text = "total"
            MsgBox("Todos os itens foram importados !", MsgBoxStyle.Information, "Aviso !")

        End If



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        NOVO()
    End Sub

    Private Sub txtcodigoprod_item_TextChanged(sender As Object, e As EventArgs) Handles txtcodigoprod_item.TextChanged

    End Sub

    Private Sub txtqtde_item_TextChanged(sender As Object, e As EventArgs) Handles txtqtde_item.TextChanged

    End Sub


    Private Sub bntpesquisa_Click(sender As Object, e As EventArgs) Handles bntpesquisa.Click
        frmpesquisanfe_Ent.ShowDialog()
    End Sub

    Private Sub bntexcluir_Click(sender As Object, e As EventArgs) Handles bntexcluir.Click
        If mskcnpj_emi.Text = "" Then
            Exit Sub
        End If

        If MessageBox.Show("Deseja Realmente a Nota Fiscal ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Dim chave As String = txtnumeronf.Text & txtserienfe.Text & cbomodelo.Text & mskcnpj_emi.Text

            executa_query("delete from nfe_e where chave_par = '" & chave & "'")

            executa_query("delete from nfe_eitens where chave_par = '" & chave & "'")

            dgvitens.Rows.Clear()
            Panel_item.Enabled = False
            Panel_ini.Enabled = False
            limpar_principal()
            txtnumeronf.Focus()

            MsgBox("Nota fiscal excluida com Sucesso !", MsgBoxStyle.Information, "Aviso !")
        End If
    End Sub

    Private Sub cboncm_item_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboncm_item.SelectedIndexChanged

    End Sub

    Private Sub cboncm_item_Validated(sender As Object, e As EventArgs) Handles cboncm_item.Validated
        Dim verifica As Boolean = False
        For i As Integer = 0 To cboncm_item.Items.Count - 1

            If cboncm_item.Text = CType(cboncm_item.Items(i), MTGCComboBoxItem).Col1 Then
                verifica = True
            End If

        Next

        If cboncm_item.Text <> "" Then
            If verifica = False Then
                MsgBox("A NCM informado não e valido !", MsgBoxStyle.Exclamation, "Aviso !")
                cboncm_item.Text = ""
                cboncm_item.Focus()
            End If
        End If
    End Sub

    Private Sub cbocest_item_Validated(sender As Object, e As EventArgs) Handles cbocest_item.Validated
        Dim verifica As Boolean = False
        For i As Integer = 0 To cbocest_item.Items.Count - 1

            If cbocest_item.Text = CType(cbocest_item.Items(i), MTGCComboBoxItem).Col1 Then
                verifica = True
            End If

        Next
        If cbocest_item.Text <> "" Then
            If verifica = False Then
                MsgBox("O código cest informado não e valido !", MsgBoxStyle.Exclamation, "Aviso !")
                cbocest_item.Text = ""
                cbocest_item.Focus()
            End If
        End If
    End Sub

    Private Sub cbocst_item_Validated(sender As Object, e As EventArgs) Handles cbocst_item.Validated
        Dim verifica As Boolean = False
        For i As Integer = 0 To cbocst_item.Items.Count - 1

            If cbocst_item.Text = CType(cbocst_item.Items(i), MTGCComboBoxItem).Col1 Then
                verifica = True
            End If

        Next
        If cbocst_item.Text <> "" Then
            If verifica = False Then
                MsgBox("O CST Informada não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
                cbocst_item.Text = ""
                cbocst_item.Focus()
            End If
        End If
    End Sub

    Private Sub cbocstpis_item_Validated(sender As Object, e As EventArgs) Handles cbocstpis_item.Validated
        Dim verifica As Boolean = False
        For i As Integer = 0 To cbocstpis_item.Items.Count - 1

            If cbocstpis_item.Text = CType(cbocstpis_item.Items(i), MTGCComboBoxItem).Col1 Then
                verifica = True
            End If

        Next
        If cbocstpis_item.Text <> "" Then
            If verifica = False Then
                MsgBox("O CST PIS/COFINS Informada não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
                cbocstpis_item.Text = ""
                cbocstpis_item.Focus()
            End If
        End If
    End Sub

    Private Sub cbocstipi_item_Validated(sender As Object, e As EventArgs) Handles cbocstipi_item.Validated
        Dim verifica As Boolean = False
        For i As Integer = 0 To cbocstipi_item.Items.Count - 1

            If cbocstipi_item.Text = CType(cbocstipi_item.Items(i), MTGCComboBoxItem).Col1 Then
                verifica = True
            End If

        Next
        If cbocstipi_item.Text <> "" Then
            If verifica = False Then
                MsgBox("O CST IPI Informada não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
                cbocstipi_item.Text = ""
                cbocstipi_item.Focus()
            End If
        End If
    End Sub

    Private Sub cbomodelo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbomodelo.SelectedIndexChanged

    End Sub

    Private Sub txtfrete_vlr_LostFocus(sender As Object, e As EventArgs) Handles txtfrete_vlr.LostFocus

        calcular_cte_frete()

    End Sub

    Private Sub txtfrete_vlr_TextChanged(sender As Object, e As EventArgs) Handles txtfrete_vlr.TextChanged

    End Sub

    Private Sub cboaliqfrete_LostFocus(sender As Object, e As EventArgs)
        If txtfrete_vlr.Text = "" Then
            txtfrete_vlr.Text = "0,00"
        Else

            lblchave.Text = mskchavecte.Text

            txtfrete_vlr.Text = Format(Convert.ToDouble(txtfrete_vlr.Text), "#,##0.00")
            txtvlrtotalfrete_nfe.Text = txtfrete_vlr.Text

            If cboaliqfrete.Text <> "" Then
                If cboaliqfrete.Text <> "0,00" Then
                    txtvlrtotalbaseicms_nfe.Text = txtfrete_vlr.Text
                    txtvlrtotalicms_nfe.Text = Format(CDec(txtfrete_vlr.Text) * (CDec(cboaliqfrete.Text) / 100), "#,##0.00")
                Else
                    txtvlrtotalicms_nfe.Text = "0,00"
                    txtvlrtotalbaseicms_nfe.Text = "0,00"
                End If
            End If
        End If
    End Sub


    Private Sub cboaliqfrete_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cboaliqfrete_LostFocus1(sender As Object, e As EventArgs) Handles cboaliqfrete.LostFocus
        calcular_cte_frete()

    End Sub


    Private Sub txtaliqpis_item_TextChanged(sender As Object, e As EventArgs) Handles txtaliqpis_item.TextChanged

    End Sub

    Private Sub calcular_cte_frete()

        If txtfrete_vlr.Text = "" Then
            txtfrete_vlr.Text = "0,00"
        Else

            lblchave.Text = mskchavecte.Text

            txtfrete_vlr.Text = Format(Convert.ToDouble(txtfrete_vlr.Text), "#,##0.00")
            txtvlrtotalfrete_nfe.Text = txtfrete_vlr.Text

            If cboaliqfrete.Text = "" Then
                cboaliqfrete.Text = "0,00"
            Else

                If cboaliqfrete.Text <> "0,00" Then
                    txtvlrtotalbaseicms_nfe.Text = txtfrete_vlr.Text
                    txtvlrtotalicms_nfe.Text = Format(CDec(txtfrete_vlr.Text) * (CDec(cboaliqfrete.Text) / 100), "#,##0.00")
                Else
                    txtvlrtotalicms_nfe.Text = "0,00"
                    txtvlrtotalbaseicms_nfe.Text = "0,00"
                End If

            End If

            txtvlrtotal_nfe.Text = txtfrete_vlr.Text
        End If


        If txtaliqpis_frete.Text = "" Then
            txtaliqpis_frete.Text = "0,00"
        Else
            txtaliqpis_frete.Text = Format(Convert.ToDouble(txtaliqpis_frete.Text), "#,##0.00")
        End If

        If txtaliqcofins_frete.Text = "" Then
            txtaliqcofins_frete.Text = "0,00"
        Else
            txtaliqcofins_frete.Text = Format(Convert.ToDouble(txtaliqcofins_frete.Text), "#,##0.00")
        End If


        If cbocstpisfrete.Text <> "" Then
            If cbocstpisfrete.Text.Substring(0, 2) = "50" Then
                If txtaliqpis_frete.Text <> "0,00" Then
                    txtvlrtotalpis_nfe.Text = Format((CDec(txtfrete_vlr.Text) * (CDec(txtaliqpis_frete.Text) / 100)) + (txtvlrtotalpis_nfe.Text), "#,##0.00")
                End If
                If txtaliqcofins_frete.Text <> "0,00" Then
                    txtvlrtotalcofins_nfe.Text = Format((CDec(txtfrete_vlr.Text) * (CDec(txtaliqcofins_frete.Text) / 100)) + CDec(txtvlrtotalcofins_nfe.Text), "#,##0.00")
                End If
            Else
                txtvlrtotalpis_nfe.Text = "0,00"
                txtvlrtotalcofins_nfe.Text = "0,00"
            End If
        End If

        If cbocstpisfrete.Text = "" Then
            cbocstpisfrete.Text = "73"
        End If
    End Sub

    Private Sub cboaliqpisfrete_LostFocus(sender As Object, e As EventArgs) Handles cbocstpisfrete.LostFocus
        calcular_cte_frete()
    End Sub


    Private Sub txtaliqpis_frete_LostFocus(sender As Object, e As EventArgs) Handles txtaliqpis_frete.LostFocus
        calcular_cte_frete()
    End Sub

    Private Sub txtaliqcofins_frete_LostFocus(sender As Object, e As EventArgs) Handles txtaliqcofins_frete.LostFocus
        calcular_cte_frete()
    End Sub

   
    Private Sub cbocstpisfrete_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbocstpisfrete.SelectedIndexChanged
        If cbocstpisfrete.Text.Substring(0, 2) = "50" Then

            If txtaliqcofins_frete.Text = "0,00" Then
                txtaliqcofins_frete.Text = "7,60"
                txtaliqpis_frete.Text = "1,65"
            End If

        Else
            txtaliqcofins_frete.Text = "0,00"
            txtaliqpis_frete.Text = "0,00"
        End If
    End Sub

    Private Sub frmnfe_entrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtaliqpis_frete_TextChanged(sender As Object, e As EventArgs) Handles txtaliqpis_frete.TextChanged

    End Sub
End Class