Imports System.Data
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class FrmProduto
    Dim rs As New ADODB.Recordset
    Dim aliq_simples As String
    Dim fem As String, codigo_icms As String, codigo_pis As String, codigo_ipi As String

    Private Sub desabilitaCampos()

        TabControl1.TabPages(0).Enabled = False
        TabControl1.TabPages(1).Enabled = False
        btnsalvar.Enabled = False
        btnexcluir.Enabled = False
    End Sub

    Public Sub habilitaCampos()
        TabControl1.TabPages(0).Enabled = True
        TabControl1.TabPages(1).Enabled = True
    End Sub

    Public Sub limpa()
        txtaliq_ipi.Text = valor_campo_vazio()
        txtaliq_pis.Text = valor_campo_vazio()
        txtaliq_cofins.Text = valor_campo_vazio()

        txtmargem.Text = valor_campo_vazio()
        txtmva.Text = valor_campo_vazio()
        txtaliq_st.Text = valor_campo_vazio()
        txtred_icms.Text = valor_campo_vazio()
        txtex.Clear()
        txtncm.Text = ""
        cbocst_ipi_ent.Text = ""
        cbocst_ipi_saida.Text = ""
        cbocstpis_entrada.Text = ""
        cbocstpis_saida.Text = ""
        cbocsticms.Text = ""
        cboaliq_icms.Text = ""
        cbocod_receita.Text = ""

        txtdesc_ipi.Clear()
        txtdesc_ipi_entrada.Clear()
        txtdescicms.Clear()
        txtdescpis_entrada.Clear()
        txtdescpis_saida.Clear()
        txtcest.Text = ""
        txtbarras.Clear()
        txtdescricao.Clear()
        cbounidade.Text = ""
        txtqtembalagem.Text = "1"
        txtprecofab.Text = valor_campo_vazio()
        txtprecovenda.Text = valor_campo_vazio()
        txtlote.Clear()
        datavenc.Text = Now.Date
        cboorigem.Text = ""
        txtorigem_desc.Clear()
        txtinfo_adi_prod.Clear()
        txtaliqfem.Text = valor_campo_vazio()

       
    End Sub

    Private Sub FrmProduto_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        
        Me.Dispose()
    End Sub

    Private Sub FrmProduto_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If txtcodigo.Text = "Novo" Then
            If MessageBox.Show("Deseja realmente sair do cadastro ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub


    Private Sub FrmProduto_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
        Select Case e.KeyCode

            Case Keys.F3
                novo()
            Case Keys.F10
                salvar_prod()
            Case Keys.F4
                If txtcodigo.Text <> "" Then
                    If MessageBox.Show("Deseja Realmente excluir o Produto: " & txtdescricao.Text, "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        Deletaproduto()
                        txtcodigo.Clear()
                    End If
                End If
            Case Keys.F6
                '  FrmConsultaProduto.Show()
            Case Keys.Escape
                Me.Dispose()
        End Select
    End Sub

    Private Sub FrmProduto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Me.Text <> "Cadastro de Produto NF-e" Then
            desabilitaCampos()
            carregar_combo()
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        ' frmcest.Show()
    End Sub



    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs)
        ' FrmCstIcms.Show()
    End Sub


    Private Sub ckfem_Click(sender As Object, e As EventArgs) Handles ckfem.Click
        If ckfem.Checked = True Then
            fem = "S"
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        FrmNCM.Show()
        txtcest.Text = ""
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles pbcest.Click

        If txtncm.Text = "" Then
            MsgBox("Informe a NCM para consulta a CEST !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If
        frmcest.forme = "cad"
        frmcest.Show()
    End Sub

    Private Sub PictureBox3_Click_1(sender As Object, e As EventArgs)
        ' FrmOrigem.Show()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs)
        ' FrmPisConfis.Show()
    End Sub


    Private Sub txtbarras_LostFocus(sender As Object, e As EventArgs) Handles txtbarras.LostFocus

        If txtbarras.Text = "" Then
            Exit Sub
        End If

        If chkgtin.Checked = True Then
            If validaGTIN(txtbarras.Text) = False Then
                MsgBox("Código de Barras Invalido !", MsgBoxStyle.Exclamation, "Aviso !")
            End If
        End If
    End Sub

    Public Sub novo()

        Bnteditar.Visible = False
        bntcancelar.Visible = True

        txtcodigo.Enabled = False
        txtcodigo.Text = "Novo"
        habilitaCampos()
        limpa()

        fem = "N"
        carregar_combo()
        TabControl1.SelectTab(Tabdadosprod)
        txtbarras.Focus()
        btnovo.Enabled = False
        btnsalvar.Enabled = True
        btnexcluir.Enabled = False

        cbocst_ipi_ent.SelectedText = 0
        cbocst_ipi_saida.SelectedText = 0
        cbocst_ipi_ent.Text = "03"
        cbocst_ipi_saida.Text = "53"
        chkgtin.Checked = True
        cbounidade.SelectedText = 0
        cboorigem.SelectedText = 0
        cbounidade.SelectedIndex = 0
        cboorigem.SelectedIndex = 0

        Bnteditar.Visible = False
        bntcancelar.Visible = True
        cboaliq_icms.SelectedText = 0
        cboaliq_icms.Text = "0,00"

        If regimetrib = 3 Then
            txtaliq_cofins.Text = "7,60"
            txtaliq_pis.Text = "1,65"
        End If
    End Sub

    Private Sub carregar_combo()
        carrega_ncm()
        carrega_unidade()
        carrega_origem()
        carrega_IPI()
        carrega_pis_cofins()
        carrega_cst_icms()
        carrega_aliq()

        If empresa.scod_trib = 1 Then
            conectar_mysqlDFe()
            Dim SQLcommand2 As MySqlCommand
            SQLcommand2 = oConn.CreateCommand
            SQLcommand2.CommandText = "SELECT * FROM empresa where cnpj_emp = '" & empresa.sCNPJ & "'"
            dr = SQLcommand2.ExecuteReader()

            While (dr.Read())
                aliq_simples = dr("aliq_simples")
            End While

            dr.Close()
            SQLcommand2.Dispose()
            oConn.Close()

            cboaliq_icms.Items.Clear()
            cboaliq_icms.Text = aliq_simples
            cboaliq_icms.Enabled = False
        End If

    End Sub


#Region "''''Rotina da aba produtos"

    Private Sub btnovo_Click(sender As Object, e As EventArgs) Handles btnovo.Click
        novo()
    End Sub



    Private Sub btnsalvar_Click(sender As Object, e As EventArgs) Handles btnsalvar.Click

        If txtdescricao.Text = "" Then
            MsgBox("Informa a descrição do produto!", MsgBoxStyle.Exclamation, "Aviso !")
            TabControl1.SelectTab(Tabdadosprod)
            txtdescricao.Focus()
            Exit Sub

        ElseIf cbounidade.Text = "" Then
            MsgBox("Informe um tipo de unidade!", MsgBoxStyle.Exclamation, "Aviso !")
            TabControl1.SelectTab(Tabdadosprod)
            cbounidade.Focus()
            Exit Sub

        ElseIf cboorigem.Text = "" Then
            MsgBox("Informe a origem do produto!", MsgBoxStyle.Exclamation, "Aviso !")
            TabControl1.SelectTab(Tabdadosprod)
            cboorigem.Focus()
            Exit Sub

        ElseIf txtprecovenda.Text = valor_campo_vazio() Then
            MsgBox("Informe o preço de venda!", MsgBoxStyle.Exclamation, "Aviso !")
            TabControl1.SelectTab(Tabdadosprod)
            txtprecovenda.Focus()
            Exit Sub

        ElseIf txtncm.Text = "" Then
            MsgBox("Informe a NCM do Produto!", MsgBoxStyle.Exclamation, "Aviso !")
            TabControl1.SelectTab(Tabfiscal)
            txtncm.Focus()
            Exit Sub

        ElseIf cbocsticms.Text = "" Then
            MsgBox("Informe a CST do ICMS!", MsgBoxStyle.Exclamation, "Aviso !")
            TabControl1.SelectTab(Tabfiscal)
            cbocsticms.Focus()
            Exit Sub

        ElseIf cbocstpis_saida.Text = "" Then
            MsgBox("Informe a CST de Saída do PIS/CONFIS!", MsgBoxStyle.Exclamation, "Aviso !")
            TabControl1.SelectTab(Tabfiscal)
            cbocstpis_saida.Focus()
            Exit Sub

        ElseIf cbocstpis_entrada.Text = "" Then
            MsgBox("Informe a CST de Entrada do PIS/CONFIS!", MsgBoxStyle.Exclamation, "Aviso !")
            TabControl1.SelectTab(Tabfiscal)
            cbocstpis_entrada.Focus()
            Exit Sub

        ElseIf cboaliq_icms.Text = "" Then
            cboaliq_icms.Text = valor_campo_vazio()

        ElseIf txtaliq_st.Text = "" Then
            txtaliq_st.Text = valor_campo_vazio()

        ElseIf txtred_icms.Text = "" Then
            txtred_icms.Text = valor_campo_vazio()

        ElseIf txtmva.Text = "" Then
            txtmva.Text = valor_campo_vazio()

        ElseIf txtred_st_icms.Text = "" Then
            txtred_st_icms.Text = valor_campo_vazio()

        ElseIf txtaliq_ipi.Text = "" Then
            txtaliq_ipi = valor_campo_vazio()

        End If



        If cbocstpis_entrada.Text = "50" Or cbocstpis_saida.Text = "01" Then

            If txtaliq_pis.Text = "0,00" Then
                MsgBox("Informe a aliquota de entrada aliquota PIS ?", MsgBoxStyle.Exclamation, "Aviso !")
                TabControl1.SelectTab(Tabfiscal)
                txtaliq_pis.Focus()
            End If

            If txtaliq_cofins.Text = "0,00" Then
                MsgBox("Informe a aliquota de saida aliquota COFINS ?", MsgBoxStyle.Exclamation, "Aviso !")
                TabControl1.SelectTab(Tabfiscal)
                txtaliq_cofins.Focus()
            End If

        End If

    
        If empresa.scod_trib = 3 Then


            If cbocsticms.Text.Substring(1, 2) = "10" Or cbocsticms.Text.Substring(1, 2) = "70" Or cbocsticms.Text.Substring(1, 2) = "90" Or cbocsticms.Text.Substring(1, 2) = "60" Then
                If txtcest.Text = "" Then
                    MsgBox("Informe o Código CEST do Produto ?", MsgBoxStyle.Exclamation, "Aviso !")
                    TabControl1.SelectTab(Tabfiscal)
                    txtcest.Focus()
                    Exit Sub
                End If
            End If

            If cbocsticms.Text.Substring(1, 2) = "10" Or cbocsticms.Text.Substring(1, 2) = "70" Or cbocsticms.Text.Substring(1, 2) = "90" Then

                If cboaliq_icms.Text = valor_campo_vazio() Then
                    MsgBox("Informe a aliquota de ICMS ?", MsgBoxStyle.Exclamation, "Aviso !")
                    TabControl1.SelectTab(Tabfiscal)
                    cboaliq_icms.Focus()
                    Exit Sub
                End If

                If txtmva.Text = valor_campo_vazio() Then
                    MsgBox("Informe o percentual de MVA ?", MsgBoxStyle.Exclamation, "Aviso !")
                    TabControl1.SelectTab(Tabfiscal)
                    txtmva.Focus()
                    Exit Sub
                End If

                If txtaliq_st.Text = valor_campo_vazio() Then
                    MsgBox("Informe a aliquta interna de ST para calculo do Valor do ICMS/ST ?", MsgBoxStyle.Exclamation, "Aviso !")
                    TabControl1.SelectTab(Tabfiscal)
                    txtaliq_st.Focus()
                    Exit Sub
                End If

            End If



            If cbocsticms.Text.Substring(1, 2) = "70" Or cbocsticms.Text.Substring(1, 2) = "20" Then

                If txtred_icms.Text = valor_campo_vazio() Then
                    MsgBox("Informe a Percentual de Redução da Base de calculo do ICMS ?", MsgBoxStyle.Exclamation, "Aviso !")
                    TabControl1.SelectTab(Tabfiscal)
                    txtred_icms.Focus()
                    Exit Sub
                End If

            End If

            If cbocsticms.Text.Substring(1, 2) = "70" Then
                If txtred_st_icms.Text = valor_campo_vazio() Then
                    MsgBox("Informe a Percentual de Redução da Base de calculo do ICMS/ST ?", MsgBoxStyle.Exclamation, "Aviso !")
                    TabControl1.SelectTab(Tabfiscal)
                    txtred_st_icms.Focus()
                    Exit Sub
                End If
            End If



            If cbocsticms.Text.Substring(1, 2) = "00" Or cbocsticms.Text.Substring(1, 2) = "20" Then

                If cboaliq_icms.Text = valor_campo_vazio() Then
                    MsgBox("Informe a aliquota de ICMS ?", MsgBoxStyle.Exclamation, "Aviso !")
                    TabControl1.SelectTab(Tabfiscal)
                    cboaliq_icms.Focus()
                    Exit Sub
                End If

            End If




        Else



            If cbocsticms.Text.Substring(1, 3) = "201" Or cbocsticms.Text.Substring(1, 3) = "202" Then

                If txtmva.Text = valor_campo_vazio() Then
                    MsgBox("Informe o percentual de MVA ?", MsgBoxStyle.Exclamation, "Aviso !")
                    TabControl1.SelectTab(Tabfiscal)
                    txtmva.Focus()
                    Exit Sub
                End If
                If txtaliq_st.Text = valor_campo_vazio() Then
                    MsgBox("Informe a aliquta interna de ST para calculo do Valor do ICMS/ST?", MsgBoxStyle.Exclamation, "Aviso !")
                    TabControl1.SelectTab(Tabfiscal)
                    txtaliq_st.Focus()
                    Exit Sub
                End If


                If txtcest.Text = "" Then
                    MsgBox("Informe o Código CEST do Produto ?", MsgBoxStyle.Exclamation, "Aviso !")
                    TabControl1.SelectTab(Tabfiscal)
                    txtcest.Focus()
                    Exit Sub
                End If


            End If

        End If


        If chkgtin.Checked = True Then
            If validaGTIN(txtbarras.Text) = False Then
                MsgBox("Código de Barras Invalido !", MsgBoxStyle.Exclamation, "Aviso !")
                TabControl1.SelectTab(Tabdadosprod)
                txtbarras.Focus()
                Exit Sub
            End If
        End If

        salvar_prod()

        btnovo.Enabled = True
    End Sub

    Private Sub btnconsulta_Click(sender As Object, e As EventArgs) Handles btnconsulta.Click
        FrmConsultaProduto.Text = "Consulta de Produtos"
        FrmConsultaProduto.ShowDialog()
        If txtcodigo.Text <> "" Then
            Bnteditar.Visible = False
            bntcancelar.Visible = True
        End If
    End Sub

    Private Sub btnsair_Click(sender As Object, e As EventArgs) Handles btnsair.Click
        Bnteditar.Visible = True
        bntcancelar.Visible = false
        Me.Close()
    End Sub



    Private Sub cboorigem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboorigem.SelectedIndexChanged
        If Not cboorigem.SelectedItem Is Nothing Then

            txtorigem_desc.Text = cboorigem.SelectedItem.Col2
            carrega_cst_icms()
        End If
    End Sub

    Private Sub cboorigem_Validated(sender As Object, e As EventArgs) Handles cboorigem.Validated
        Dim verifica As Boolean = False
        For i As Integer = 0 To cboorigem.Items.Count - 1

            If cboorigem.Text = CType(cboorigem.Items(i), MTGCComboBoxItem).Col1 Then
                verifica = True
            End If

        Next
        If cboorigem.Text <> "" Then
            If verifica = False Then
                MsgBox("O valor informdo na origem do produto não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
                cboorigem.Text = ""
                cboorigem.Focus()
            End If
        End If
    End Sub



    Private Sub txtunidade_Validated(sender As Object, e As EventArgs) Handles cbounidade.Validated
        Dim verifica As Boolean = False
        For i As Integer = 0 To cbounidade.Items.Count - 1

            If cbounidade.Text = CType(cbounidade.Items(i), MTGCComboBoxItem).Col1 Then
                verifica = True
            End If

        Next
        If cbounidade.Text <> "" Then
            If verifica = False Then
                MsgBox("O Valor digitado não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
                cbounidade.Text = ""
                cbounidade.Focus()
            End If
        End If
    End Sub

    Private Sub txtqtembalagem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtqtembalagem.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtqtembalagem_LostFocus(sender As Object, e As EventArgs) Handles txtqtembalagem.LostFocus
        If txtqtembalagem.Text = "" Then
            txtqtembalagem.Text = "1"
        End If
    End Sub

    Private Sub txtprecofab_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtprecofab.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal4(txtprecofab, e)
    End Sub

    Private Sub txtprecovenda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtprecovenda.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal4(txtprecovenda, e)
    End Sub

    Private Sub txtprecofab_LostFocus(sender As Object, e As EventArgs) Handles txtprecofab.LostFocus
        If txtprecofab.Text = "" Then
            txtprecofab.Text = valor_campo_vazio()
        Else
            txtprecofab.Text = formata_valor_campo(txtprecofab.Text)
        End If
    End Sub

    Private Sub txtprecovenda_LostFocus(sender As Object, e As EventArgs) Handles txtprecovenda.LostFocus
        Try
            If txtprecovenda.Text = "" Then
                txtprecovenda.Text = valor_campo_vazio()
            Else
                txtprecovenda.Text = Format(CDec(txtprecovenda.Text), "#,##0.00")

                txtmargem.Text = (CDec(txtprecovenda.Text) - CDec(txtprecofab.Text)) * 100 / CDec(txtprecofab.Text)
                txtmargem.Text = Format(CDec(txtmargem.Text), "#,##0.00")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtinfo_adi_prod_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtinfo_adi_prod.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            TabControl1.SelectTab(Tabfiscal)
        End If
    End Sub

    Private Sub txtbarras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbarras.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If

        If (e.KeyChar = Chr(13)) Then


            If txtcodigo.Text <> "NOVO" Then
                If txtcodigo.Text = "" Then
                    If txtbarras.Text <> "" Then
                        carregar_produtos(txtbarras.Text, True)
                    End If
                End If
            End If


            If txtcodigo.Text = "NOVO" Then

                conectar_baseNFe()

                rs.Open("select * from produto INNER JOIN Codigo_barras ON produto.codigo_prod = Codigo_barras.codigo_prd where Codigo_barras.Codigo_barra = '" & txtbarras.Text & "'", conexao.cn_nfe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

                If rs.EOF = False Then
                    MsgBox("O Código de Barras ja esta cadastrado no Produto:" & vbCrLf & "Código: " & rs.Fields("codigo_prod").Value & " Descrição: " & rs.Fields("desc_prod").Value, MsgBoxStyle.Exclamation, "Aviso !")
                    txtbarras.Clear()
                    txtbarras.Focus()
                End If

                conexao.cn_nfe.Close()

            End If



        End If
    End Sub

#End Region




#Region "''''Rotina para carregar as combox"

    Public Sub carrega_ncm()

        txtncm.Items.Clear()

        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "SELECT * FROM NCM"
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())
            txtncm.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))
        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()


    End Sub

    Public Sub carrega_cest()

        txtcest.Items.Clear()

        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "SELECT * FROM cest WHERE ncm LIKE '" & txtncm.Text.Substring(0, 2) & "' OR ncm LIKE '" & txtncm.Text.Substring(0, 4) & "' OR ncm like '" & txtncm.Text.Substring(0, 6) & "' OR ncm LIKE '" & txtncm.Text.Substring(0, 8) & "'"
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())
            txtcest.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))
        End While


        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()


    End Sub

    Public Sub carrega_origem()


        cboorigem.Items.Clear()

        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "SELECT * FROM Origem_prod ORDER BY codigo ASC"
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())
            cboorigem.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))
        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()


    End Sub

    Public Sub carrega_unidade()
        cbounidade.Items.Clear()
        cbounidade.Items.Add(New MTGCComboBoxItem("UN", "Unidade"))
        cbounidade.Items.Add(New MTGCComboBoxItem("CX", "Caixa"))
        cbounidade.Items.Add(New MTGCComboBoxItem("PT", "Pacote"))
        cbounidade.Items.Add(New MTGCComboBoxItem("FD", "Fardo"))
        cbounidade.Items.Add(New MTGCComboBoxItem("SC", "Saco"))
        cbounidade.Items.Add(New MTGCComboBoxItem("GF", "Garrafa"))
        cbounidade.Items.Add(New MTGCComboBoxItem("CJ", "Conjunto"))
        cbounidade.Items.Add(New MTGCComboBoxItem("KG", "Kilo"))
    End Sub

    Public Sub carrega_aliq()
        cboaliq_icms.Items.Clear()

        If empresa.scod_trib = 3 Then
            cboaliq_icms.Enabled = True
            cboaliq_icms.Items.Add(New MTGCComboBoxItem(formata_valor_campo("7")))
            cboaliq_icms.Items.Add(New MTGCComboBoxItem(formata_valor_campo("12")))
            cboaliq_icms.Items.Add(New MTGCComboBoxItem(formata_valor_campo("18")))
            cboaliq_icms.Items.Add(New MTGCComboBoxItem(formata_valor_campo("25")))
            cboaliq_icms.Items.Add(New MTGCComboBoxItem(formata_valor_campo("27")))
            cboaliq_icms.Items.Add(New MTGCComboBoxItem(valor_campo_vazio))

        Else


            cboaliq_icms.Enabled = False

            conectar_mysqlDFe()

            Dim SQLcommand As MySqlCommand
            SQLcommand = oConn.CreateCommand
            SQLcommand.CommandText = "select * from empresa where cnpj_emp = '" & empresa.sCNPJ & "'"
            dr = SQLcommand.ExecuteReader()

            While (dr.Read())
                cboaliq_icms.Text = dr("aliq_simples").ToString
            End While

            dr.Close()
            SQLcommand.Dispose()
            oConn.Close()

        End If
    End Sub

    Public Sub carrega_cst_icms()

        cbocsticms.Items.Clear()

        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "SELECT * FROM cst_icms ORDER BY codigo ASC"
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())

            If cboorigem.Text <> "" Then

                If empresa.scod_trib = 3 Or empresa.scod_trib = 2 Then
                    If dr("codigo").ToString.Length = 2 Then
                        cbocsticms.Items.Add(New MTGCComboBoxItem(cboorigem.Text & dr("codigo"), dr("descricao")))
                    End If
                End If


                If empresa.scod_trib = 1 Or empresa.scod_trib = 2 Then
                    If dr("codigo").ToString.Length = 3 Then
                        cbocsticms.Items.Add(New MTGCComboBoxItem(cboorigem.Text & dr("codigo"), dr("descricao")))
                    End If
                End If

            End If


            If cboorigem.Text = "" Then


                If empresa.scod_trib = 3 Then
                    If dr("codigo").ToString.Length = 2 Then
                        cbocsticms.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))
                    End If
                End If

                If empresa.scod_trib = 3 Or empresa.scod_trib = 2 Then
                    If dr("codigo").ToString.Length = 2 Then
                        cbocsticms.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))
                    End If
                End If


            End If
        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()


    End Sub

    Public Sub carrega_pis_cofins()
        cbocstpis_entrada.Items.Clear()
        cbocstpis_saida.Items.Clear()



        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "SELECT * FROM cst_cofins ORDER BY codigo ASC"
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())
            If dr("codigo").ToString.Substring(0, 1) = "0" Or dr("codigo").ToString.Substring(0, 1) = "4" Then
                cbocstpis_saida.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))
            Else
                cbocstpis_entrada.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))
            End If
        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()

    End Sub

    Public Sub carrega_IPI()
        cbocst_ipi_ent.Items.Clear()
        cbocst_ipi_saida.Items.Clear()


        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "SELECT * FROM cst_ipi ORDER BY codigo ASC"
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())
            If dr("codigo").ToString.Substring(0, 1) = "0" Or dr("codigo").ToString.Substring(0, 1) = "4" Then
                cbocst_ipi_ent.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))
            Else
                cbocst_ipi_saida.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))
            End If
        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()


    End Sub


#End Region



    Private Sub txtcsticms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbocsticms.SelectedIndexChanged
        If Not cbocsticms.SelectedItem Is Nothing Then

            txtdescicms.Text = cbocsticms.SelectedItem.Col2

        End If
    End Sub

    Private Sub cbocstpis_saida_LostFocus(sender As Object, e As EventArgs) Handles cbocstpis_saida.LostFocus
        If cbocstpis_saida.Text = "01" Then
            cbocstpis_entrada.Text = "50"
        End If

        If cbocstpis_saida.Text = "04" Then
            cbocstpis_entrada.Text = "70"
        End If

        If cbocstpis_saida.Text = "06" Or cbocstpis_saida.Text = "05" Then
            cbocstpis_entrada.Text = "73"
        End If

        If cbocstpis_saida.Text = "49" Or cbocstpis_saida.Text = "03" Or cbocstpis_saida.Text = "02" Then
            cbocstpis_entrada.Text = "99"
        End If

        If cbocstpis_saida.Text = "07" Or cbocstpis_saida.Text = "09" Or cbocstpis_saida.Text = "09" Then
            cbocstpis_entrada.Text = "99"
        End If

        If cbocstpis_saida.Text = "01" Then

            txtaliq_cofins.TabStop = True
            txtaliq_pis.TabStop = True
            txtaliq_pis.Focus()

        End If
    End Sub

    Private Sub cstpis_saida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbocstpis_saida.SelectedIndexChanged
        If Not cbocstpis_saida.SelectedItem Is Nothing Then

            txtdescpis_saida.SelectedText = 0
            txtdescpis_saida.Text = cbocstpis_saida.SelectedItem.Col2
           
        End If
    End Sub

    Private Sub cstpis_entrada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbocstpis_entrada.SelectedIndexChanged
        If Not cbocstpis_entrada.SelectedItem Is Nothing Then

            txtdescpis_entrada.Text = cbocstpis_entrada.SelectedItem.Col2

            btnsalvar.Focus()
        End If
    End Sub

    Private Sub cst_ipi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbocst_ipi_ent.SelectedIndexChanged
        If Not cbocst_ipi_ent.SelectedItem Is Nothing Then

            txtdesc_ipi.Text = cbocst_ipi_ent.SelectedItem.Col2

        End If
    End Sub

    Private Sub cst_ipi_entrada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbocst_ipi_saida.SelectedIndexChanged
        If Not cbocst_ipi_saida.SelectedItem Is Nothing Then

            txtdesc_ipi_entrada.Text = cbocst_ipi_saida.SelectedItem.Col2

        End If
    End Sub

    Private Sub cstpis_saida_Validated(sender As Object, e As EventArgs) Handles cbocstpis_saida.Validated
        Dim verifica As Boolean = False
        For i As Integer = 0 To cbocstpis_saida.Items.Count - 1

            If cbocstpis_saida.Text = CType(cbocstpis_saida.Items(i), MTGCComboBoxItem).Col1 Then
                verifica = True
            End If

        Next
        If cbocstpis_saida.Text <> "" Then
            If verifica = False Then
                MsgBox("A CST de pis/cofins saida informada não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
                cbocstpis_saida.Text = ""
                cbocstpis_saida.Focus()
            End If
        End If
    End Sub

    Private Sub cstpis_entrada_Validated(sender As Object, e As EventArgs) Handles cbocstpis_entrada.Validated
        Dim verifica As Boolean = False
        For i As Integer = 0 To cbocstpis_entrada.Items.Count - 1

            If cbocstpis_entrada.Text = CType(cbocstpis_entrada.Items(i), MTGCComboBoxItem).Col1 Then
                verifica = True
            End If

        Next

        If cbocstpis_entrada.Text <> "" Then
            If verifica = False Then
                MsgBox("A CST de pis/cofins entrada informada não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
                cbocstpis_entrada.Text = ""
                cbocstpis_entrada.Focus()
            End If
        End If
    End Sub

    Private Sub cst_ipi_Validated(sender As Object, e As EventArgs) Handles cbocst_ipi_ent.Validated
        Dim verifica As Boolean = False
        For i As Integer = 0 To cbocst_ipi_ent.Items.Count - 1

            If cbocst_ipi_ent.Text = CType(cbocst_ipi_ent.Items(i), MTGCComboBoxItem).Col1 Then
                verifica = True
            End If

        Next

        If verifica = False Then
            MsgBox("O Valor digitado não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
            cbocst_ipi_ent.Text = ""
            cbocst_ipi_ent.Focus()
        End If
    End Sub

    Private Sub cst_ipi_entrada_Validated(sender As Object, e As EventArgs) Handles cbocst_ipi_saida.Validated
        Dim verifica As Boolean = False
        For i As Integer = 0 To cbocst_ipi_saida.Items.Count - 1

            If cbocst_ipi_saida.Text = CType(cbocst_ipi_saida.Items(i), MTGCComboBoxItem).Col1 Then
                verifica = True
            End If

        Next

        If verifica = False Then
            MsgBox("O Valor digitado não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
            cbocst_ipi_saida.Text = ""
            cbocst_ipi_saida.Focus()
        End If
    End Sub

    Private Sub txtncm_LostFocus(sender As Object, e As EventArgs) Handles txtncm.LostFocus

        If txtncm.Text <> "" Then
            carrega_cest()
        End If

    End Sub

    Private Sub txtncm_Validated(sender As Object, e As EventArgs) Handles txtncm.Validated
        Dim verifica As Boolean = False
        For i As Integer = 0 To txtncm.Items.Count - 1

            If txtncm.Text = CType(txtncm.Items(i), MTGCComboBoxItem).Col1 Then
                verifica = True
            End If

        Next

        If txtncm.Text <> "" Then
            If verifica = False Then
                MsgBox("A NCM informado não e valido !", MsgBoxStyle.Exclamation, "Aviso !")
                txtncm.Text = ""
                txtncm.Focus()
            End If
        End If
    End Sub

    Private Sub txtex_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtex.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtred_icms_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtred_icms.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtaliq_st_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtmva_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmva.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtaliq_ipi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtaliq_ipi.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtred_icms_LostFocus(sender As Object, e As EventArgs) Handles txtred_icms.LostFocus
        If txtred_icms.Text = "" Then
            txtred_icms.Text = valor_campo_vazio()
        Else
            txtred_icms.Text = formata_valor_campo(txtred_icms.Text)
            txtred_st_icms.Text = txtred_icms.Text
        End If
    End Sub

    Private Sub txtaliq_st_LostFocus(sender As Object, e As EventArgs)
        If txtaliq_st.Text = "" Then
            txtaliq_st.Text = valor_campo_vazio()
        Else
            txtaliq_st.Text = formata_valor_campo(txtaliq_st.Text)
        End If
    End Sub

    Private Sub txtmva_LostFocus(sender As Object, e As EventArgs) Handles txtmva.LostFocus
        If txtmva.Text = "" Then
            txtmva.Text = valor_campo_vazio()
        Else
            txtmva.Text = formata_valor_campo(txtmva.Text)
        End If
    End Sub

    Private Sub txtaliq_ipi_LostFocus(sender As Object, e As EventArgs) Handles txtaliq_ipi.LostFocus
        If txtaliq_ipi.Text = "" Then
            txtaliq_ipi.Text = valor_campo_vazio()
        Else
            txtaliq_ipi.Text = formata_valor_campo(txtaliq_ipi.Text)
        End If
    End Sub

    Private Sub txtaliq_icms_Validated(sender As Object, e As EventArgs) Handles cboaliq_icms.Validated
        If regimetrib = 3 Then

            If cbocsticms.Text.Substring(1, 2) = "70" Or cbocsticms.Text.Substring(0, 2) = "10" Or cbocsticms.Text.Substring(0, 2) = "00" Then

                Dim verifica As Boolean = False
                For i As Integer = 0 To cboaliq_icms.Items.Count - 1

                    If cboaliq_icms.Text = CType(cboaliq_icms.Items(i), MTGCComboBoxItem).Col1 Then
                        verifica = True
                    End If

                Next
                If cboaliq_icms.Text <> "" Then
                    If verifica = False Then
                        MsgBox("A aliquoda ICMS informada não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
                        cboaliq_icms.Text = ""
                        cboaliq_icms.Focus()
                    End If
                End If

            End If
        End If
    End Sub

    Private Sub salvar_prod()
        Dim codigo As Integer = 0

        If txtcodigo.Text = "NOVO" Or txtcodigo.Text = "Novo" Then
            Try

                codigo = ProximoCodigo("produto", "codigo_prod")

            Catch ex As Exception
                codigo = 1
            End Try

            txtcodigo.Text = codigo
        End If

        ' Try


        Dim ret As Integer = verificar_regexiste("Select * from produto where codigo_prod = '" & txtcodigo.Text & "'")
        Dim sql As String

        If ret = 0 Then
            sql = "INSERT INTO produto (desc_prod, barras_prod, valor_fab, valor_venda, valor_prom, unidade_prod, origem_prod, ncm_prod, EX_ncm, cest_prod, cst_icms, aliq_icms, aliq_int, redbase_icms, redbase_st, mva_prod, cst_pis_ent, cst_pis_sai, aliq_pis, aliq_cofins, cod_receita, fem_prod, GTIN, Qtde_emb_prod, Lote_prod, datavenc_prod, inf_adi_prod, cst_ipi_ent, cst_ipi_sai, aliq_ipi, prod_ativo, aliq_fem, vlr_prom, data_val_prom, data_nfent, data_ultvenda) VALUES (@desc_prod, @barras_prod, @valor_fab, @valor_venda, @valor_prom, @unidade_prod, @origem_prod, @ncm_prod, @EX_ncm, @cest_prod, @cst_icms, @aliq_icms, @aliq_int, @redbase_icms, @redbase_st, @mva_prod, @cst_pis_ent, @cst_pis_sai, @aliq_pis, @aliq_cofins, @cod_receita, @fem_prod, @GTIN, @Qtde_emb_prod, @Lote_prod, @datavenc_prod, @inf_adi_prod, @cst_ipi_ent, @cst_ipi_sai, @aliq_ipi, @prod_ativo, @aliq_fem, @vlr_prom, @data_val_prom, @data_nfent, @data_ultvenda)"
        Else
            sql = "UPDATE produto SET desc_prod = @desc_prod, barras_prod = @barras_prod, valor_fab = @valor_fab, valor_venda = @valor_venda, valor_prom = @valor_prom, unidade_prod = @unidade_prod, origem_prod = @origem_prod, ncm_prod = @ncm_prod, EX_ncm = @EX_ncm, cest_prod = @cest_prod, cst_icms = @cst_icms, aliq_icms = @aliq_icms, aliq_int = @aliq_int, redbase_icms = @redbase_icms, redbase_st = @redbase_st, mva_prod = @mva_prod, cst_pis_ent = @cst_pis_ent, cst_pis_sai = @cst_pis_sai, aliq_pis = @aliq_pis, aliq_cofins = @aliq_cofins, cod_receita = @cod_receita, fem_prod = @fem_prod, GTIN = @GTIN, Qtde_emb_prod = @Qtde_emb_prod, Lote_prod = @Lote_prod, datavenc_prod = @datavenc_prod, inf_adi_prod = @inf_adi_prod, cst_ipi_ent = @cst_ipi_ent, cst_ipi_sai = @cst_ipi_sai, aliq_ipi = @aliq_ipi, prod_ativo = @prod_ativo, aliq_fem = @aliq_fem, vlr_prom = @vlr_prom, data_val_prom = @data_val_prom, data_nfent = @data_nfent, data_ultvenda = @data_ultvenda where codigo_prod = " & txtcodigo.Text & ""
        End If

        If txtbarras.Text = "" Then
            txtbarras.Text = txtcodigo.Text.PadLeft(13, "0")
            chkgtin.Checked = False
        End If

        conectar_mysqlDFe()
        Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)

        insertSQL.Parameters.Add(New MySqlParameter("desc_prod", RemoverAcentos(txtdescricao.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("barras_prod", txtbarras.Text))
        insertSQL.Parameters.Add(New MySqlParameter("valor_fab", format_val_mysql_ent(txtprecofab.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("valor_venda", format_val_mysql_ent(txtprecovenda.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("valor_prom", "0.00"))
        insertSQL.Parameters.Add(New MySqlParameter("unidade_prod", cbounidade.Text))
        insertSQL.Parameters.Add(New MySqlParameter("origem_prod", cboorigem.Text))
        insertSQL.Parameters.Add(New MySqlParameter("ncm_prod", txtncm.Text))
        insertSQL.Parameters.Add(New MySqlParameter("EX_ncm", txtex.Text))

        insertSQL.Parameters.Add(New MySqlParameter("cest_prod", txtcest.Text))
        insertSQL.Parameters.Add(New MySqlParameter("cst_icms", cbocsticms.Text))
        insertSQL.Parameters.Add(New MySqlParameter("aliq_icms", format_val_mysql_ent(cboaliq_icms.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("aliq_int", format_val_mysql_ent(txtaliq_st.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("redbase_icms", format_val_mysql_ent(txtred_icms.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("redbase_st", format_val_mysql_ent(txtred_st_icms.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("mva_prod", format_val_mysql_ent(txtmva.Text)))

        insertSQL.Parameters.Add(New MySqlParameter("cst_pis_ent", cbocstpis_entrada.Text))
        insertSQL.Parameters.Add(New MySqlParameter("cst_pis_sai", cbocstpis_saida.Text))
        insertSQL.Parameters.Add(New MySqlParameter("aliq_pis", format_val_mysql_ent(txtaliq_pis.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("aliq_cofins", format_val_mysql_ent(txtaliq_cofins.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("cod_receita", cbocod_receita.Text))

        insertSQL.Parameters.Add(New MySqlParameter("fem_prod", ckfem.Checked))
        insertSQL.Parameters.Add(New MySqlParameter("GTIN", chkgtin.Checked))
        insertSQL.Parameters.Add(New MySqlParameter("Qtde_emb_prod", txtqtembalagem.Text))
        insertSQL.Parameters.Add(New MySqlParameter("Lote_prod", txtlote.Text))
        insertSQL.Parameters.Add(New MySqlParameter("datavenc_prod", Convert.ToDateTime(datavenc.Text).ToString("yyyy-MM-dd")))
        insertSQL.Parameters.Add(New MySqlParameter("inf_adi_prod", txtinfo_adi_prod.Text))

        insertSQL.Parameters.Add(New MySqlParameter("cst_ipi_ent", cbocst_ipi_ent.Text))
        insertSQL.Parameters.Add(New MySqlParameter("cst_ipi_sai", cbocst_ipi_saida.Text))
        insertSQL.Parameters.Add(New MySqlParameter("aliq_ipi", format_val_mysql_ent(txtaliq_ipi.Text)))

        insertSQL.Parameters.Add(New MySqlParameter("prod_ativo", chkprod_inativa.Checked))
        insertSQL.Parameters.Add(New MySqlParameter("aliq_fem", format_val_mysql_ent(txtaliqfem.Text)))

        insertSQL.Parameters.Add(New MySqlParameter("vlr_prom", format_val_mysql_ent(txtvlrprom.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("data_val_prom", Convert.ToDateTime(Dateprom.Text).ToString("yyyy-MM-dd")))

        insertSQL.Parameters.Add(New MySqlParameter("data_nfent", "0101-01-01"))
        insertSQL.Parameters.Add(New MySqlParameter("data_ultvenda", "0101-01-01"))


        insertSQL.ExecuteNonQuery()
        oConn.Close()

        carga_prod(txtcodigo.Text, txtdescricao.Text, cbounidade.Text, txtprecovenda.Text, txtvlrprom.Text, txtncm.Text, txtcest.Text, cbocsticms.Text, _
                   cboaliq_icms.Text, txtinfo_adi_prod.Text)

        ''''''''''Rotina para salvar produto na tabela codigos barras


        ret = verificar_regexiste("Select * from Codigo_barras where codigo_prod = '" & txtcodigo.Text & "'")


        If ret = 0 Then
            conectar_mysqlDFe()

            sql = "INSERT INTO codigo_barras (Codigo_prod, Codigo_barra, un, qtde) VALUES (@Codigo_prod, @Codigo_barra, @un, @qtde)"
            Dim insertSQL2 As MySqlCommand = New MySqlCommand(sql, oConn)
            insertSQL2.Parameters.Add(New MySqlParameter("Codigo_prod", txtcodigo.Text))
            insertSQL2.Parameters.Add(New MySqlParameter("Codigo_barra", txtbarras.Text))
            insertSQL2.Parameters.Add(New MySqlParameter("un", cbounidade.Text))
            insertSQL2.Parameters.Add(New MySqlParameter("qtde", txtqtembalagem.Text))
            insertSQL2.ExecuteNonQuery()
            oConn.Close()
        End If


        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from codigo_barras where codigo_prod =" & txtcodigo.Text & ""
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read
                carga_barras(reader("codigo_prod"), reader("codigo_barra"), reader("un").ToString, reader("qtde").ToString)
            End While

        End Using


        conectar_mysqlDFe()
        Dim SQLcommand2 As MySqlCommand
        SQLcommand2 = oConn.CreateCommand
        SQLcommand2.CommandText = "select * from ncm where codigo ='" & txtncm.Text & "'"
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand2.ExecuteReader

            While reader.Read
                export_ncm(reader("codigo"), reader("nacionalfederal"), reader("importadosfederal").ToString, reader("estadual").ToString, reader("municipal").ToString)
            End While

        End Using


        If codigo <> 0 Then
            MsgBox("Produto Salvo com sucesso !", MsgBoxStyle.Information, "Aviso !")
            limpa()
            txtcodigo.Text = ""
            desabilitaCampos()

            Bnteditar.Visible = True
            bntcancelar.Visible = False
        Else
            MsgBox("Produto alterado com sucesso !", MsgBoxStyle.Information, "Aviso !")
        End If


        If Me.Text = "Cadastro de Produto NF-e" Then
            Me.Close()
        End If

    End Sub


    Private Sub cbounidade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbounidade.SelectedIndexChanged
        If cbounidade.Text = "UN" Then
            txtqtembalagem.Text = "1"
            txtqtembalagem.Enabled = False
        Else
            txtqtembalagem.Enabled = True
        End If
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnexcluir.Click
        If txtcodigo.Text <> "" Then
            If MessageBox.Show("Deseja Realmente excluir o Produto: " & txtdescricao.Text, "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Deletaproduto()
                txtcodigo.Clear()

                btnovo.Enabled = True
                btnsalvar.Enabled = True

                bntcancelar.Visible = False
                Bnteditar.Visible = True
            End If
        End If
    End Sub

    Private Sub Deletaproduto()


        conectar_mysqlDFe()
        Dim SQL2 As MySqlCommand = New MySqlCommand("DELETE FROM produto WHERE codigo_prod = " & txtcodigo.Text & "", oConn)
        SQL2.ExecuteNonQuery()
        oConn.Close()

        conectar_mysqlDFe()
        Dim SQL3 As MySqlCommand = New MySqlCommand("DELETE FROM codigo_barras WHERE codigo_prod = " & txtcodigo.Text & "", oConn)
        SQL3.ExecuteNonQuery()
        oConn.Close()

        limpa()

        desabilitaCampos()

        MsgBox("Codigo de Barras excluido com sucesso !", MsgBoxStyle.Information, "Aviso !")


    End Sub

    Private Sub txtred_st_icms_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtred_st_icms.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtred_st_icms_LostFocus(sender As Object, e As EventArgs) Handles txtred_st_icms.LostFocus
        If txtred_st_icms.Text = "" Then
            txtred_st_icms.Text = valor_campo_vazio()
        Else
            txtred_st_icms.Text = formata_valor_campo(txtmva.Text)
        End If
    End Sub


    Private Sub Label27_Click(sender As Object, e As EventArgs) Handles Label27.Click
        If txtcodigo.Text <> "Novo" Then
            If txtcodigo.Text <> "" Then
                frmbarras.txtcod.Text = txtcodigo.Text
                frmbarras.ShowDialog()
            End If
        End If
    End Sub

    Public Sub carregar_produtos(ByVal codigo As String, ByVal codbarra As Boolean)


        ' 
        conectar_baseNFe()

        ''''''''Rotina para buscar pela codigo de barras'''''''''''
        If codbarra = True Then

            conectar_mysqlDFe()
            Dim SQLcommand2 As MySqlCommand
            SQLcommand2 = oConn.CreateCommand
            SQLcommand2.CommandText = "SELECT * FROM produto INNER JOIN Codigo_barras ON produto.codigo_prod = Codigo_barras.codigo_prod where Codigo_barras.codigo_barra ='" & codigo & "'"
            dr = SQLcommand2.ExecuteReader()

            While (dr.Read())
                codigo = dr("codigo_prod")
            End While

            dr.Close()
            SQLcommand2.Dispose()
            oConn.Close()

        End If

        ''''''''''Rotina limpa campos'''''''
        limpa()

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from produto where codigo_prod =" & codigo & ""
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read
                txtcodigo.Text = reader("codigo_prod")
                txtdescricao.Text = reader("desc_prod")
                txtbarras.Text = reader("barras_prod")

                txtprecofab.Text = format_val_mysql_ret(reader("valor_fab"))
                txtprecovenda.Text = format_val_mysql_ret(reader("valor_venda"))
                cbounidade.SelectedText = 0
                cbounidade.Text = reader("unidade_prod")
                cboorigem.SelectedText = 0
                cboorigem.Text = reader("origem_prod").ToString

                txtmargem.Text = (CDec(txtprecovenda.Text) - CDec(txtprecofab.Text)) * 100 / CDec(txtprecofab.Text)
                txtmargem.Text = Format(CDec(txtmargem.Text), "#,##0.00")

                txtncm.SelectedText = 0
                txtncm.Text = reader("ncm_prod")
                txtex.Text = reader("EX_ncm").ToString
                txtcest.SelectedText = 0
                txtcest.Text = reader("cest_prod").ToString

                cbocsticms.SelectedText = 0
                cbocsticms.Text = reader("cst_icms").ToString

                ''''''''''''Rotina abaixo trabalha com a aliquota do icms
                If empresa.scod_trib = 3 Then
                    cboaliq_icms.SelectedText = 0
                    cboaliq_icms.Text = reader("aliq_icms").ToString
                Else
                    cboaliq_icms.Items.Clear()
                    cboaliq_icms.SelectedText = 0
                    cboaliq_icms.Text = aliq_simples
                    cboaliq_icms.Enabled = False
                End If

                ''''''''''''''''''''''''''''#############''''''''''''''''''''''''''

                cbocstpis_entrada.SelectedText = 0
                cbocstpis_saida.Text = reader("cst_pis_sai").ToString
                cbocstpis_entrada.SelectedText = 0
                cbocstpis_entrada.Text = reader("cst_pis_ent").ToString
                cbocod_receita.SelectedText = 0
                cbocod_receita.Text = reader("cod_receita").ToString
                txtaliq_cofins.Text = format_val_mysql_ret(reader("aliq_cofins"))
                txtaliq_pis.Text = format_val_mysql_ret(reader("aliq_pis"))

                ckfem.Checked = reader("fem_prod")
                txtmva.Text = reader("mva_prod").ToString
                chkgtin.Checked = reader("GTIN")
                txtqtembalagem.Text = reader("Qtde_emb_prod").ToString
                txtlote.Text = reader("Lote_prod").ToString
                datavenc.Text = reader("datavenc_prod")
                txtinfo_adi_prod.Text = reader("Inf_adi_prod")
                txtaliq_ipi.Text = format_val_mysql_ret(reader("Aliq_ipi"))
                txtaliq_st.SelectedText = 0
                txtaliq_st.Text = format_val_mysql_ret(reader("Aliq_int").ToString)
                txtred_icms.Text = format_val_mysql_ret(reader("Redbase_icms").ToString)
                txtred_st_icms.Text = format_val_mysql_ret(reader("Redbase_st").ToString)
                chkprod_inativa.Checked = reader("prod_ativo")
                txtaliqfem.Text = format_val_mysql_ret(reader("aliq_fem").ToString)

                cbocst_ipi_saida.SelectedText = 0
                cbocst_ipi_saida.Text = reader("cst_ipi_sai")
                cbocst_ipi_ent.SelectedText = 0
                cbocst_ipi_ent.Text = reader("cst_ipi_ent")

                txtvlrprom.Text = format_val_mysql_ret(reader("vlr_prom").ToString)
                Dateprom.Text = reader("data_val_prom")

            End While
        End Using
     

        habilitaCampos()
       
        TabControl1.SelectTab(Tabdadosprod)

        If txtdescricao.Text = "" Then
            MsgBox("Produto não cadastrado !", MsgBoxStyle.Exclamation, "Aviso !")
            txtcodigo.Clear()
            txtcodigo.Focus()
            Exit Sub
        End If

        carrega_cest()

        btnsalvar.Enabled = True
        btnexcluir.Enabled = True
    End Sub

    Private Sub txtcodigo_Invalidated(sender As Object, e As InvalidateEventArgs) Handles txtcodigo.Invalidated

    End Sub

  
    Private Sub txtcodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcodigo.KeyPress
        If (e.KeyChar = Chr(13)) Then

            If txtcodigo.Text <> "" Then
                carregar_produtos(txtcodigo.Text, False)
            End If

        End If
    End Sub
    Private Sub txtaliq_st_LostFocus1(sender As Object, e As EventArgs) Handles txtaliq_st.LostFocus
        If txtaliq_st.Text = "" Then
            txtaliq_st.Text = valor_campo_vazio()
        Else
            txtaliq_st.Text = formata_valor_campo(txtaliq_st.Text)
        End If
    End Sub
    Private Sub txtdescricao_LostFocus(sender As Object, e As EventArgs) Handles txtdescricao.LostFocus

        If txtdescricao.Text <> "" Then
            txtdescricao.Text = TirarAcento(txtdescricao.Text)
        End If

    End Sub

    Private Sub txtex_LostFocus(sender As Object, e As EventArgs) Handles txtex.LostFocus
        If txtex.Text <> "" Then
            txtex.Text = txtex.Text.PadLeft(3, "0")
        End If
    End Sub

    Private Sub ckfem_CheckedChanged(sender As Object, e As EventArgs) Handles ckfem.CheckedChanged
        If ckfem.Checked = True Then
            txtaliqfem.Enabled = True
            txtaliqfem.Focus()
        Else
            txtaliqfem.Enabled = False
        End If
    End Sub

    Private Sub txtaliqfem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtaliqfem.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtaliqfem_LostFocus(sender As Object, e As EventArgs) Handles txtaliqfem.LostFocus
        If txtaliqfem.Text = "" Then
            txtaliqfem.Text = valor_campo_vazio()
        Else
            txtaliqfem.Text = formata_valor_campo(txtaliqfem.Text)
        End If
    End Sub


    Private Sub Label17_Click(sender As Object, e As EventArgs)

    End Sub

    Public Function GetConnection() As OleDbConnection
        Dim caminho_nfe As String
        Try

            caminho_nfe = lerINI(Application.StartupPath & "\config_nfe.ini", "BANCO", "caminho_banco")

            Dim sql As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & caminho_nfe & "\BD_NFE.mdb"
            Return New OleDbConnection(sql)

        Catch ex As Exception
            MsgBox(ex.Message & "   |   " & "Arquivo confing_nfe.ini", MsgBoxStyle.Critical, "Aviso")
            End
        End Try

    End Function

    Private Sub cboaliq_icms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboaliq_icms.SelectedIndexChanged

    End Sub


    Private Sub txtaliq_pis_LostFocus(sender As Object, e As EventArgs) Handles txtaliq_pis.LostFocus
        If txtaliq_pis.Text = "" Then
            txtaliq_pis.Text = valor_campo_vazio()
        Else
            txtaliq_pis.Text = formata_valor_campo(txtaliq_pis.Text)
        End If
    End Sub

    Private Sub txtaliq_cofins_LostFocus(sender As Object, e As EventArgs) Handles txtaliq_cofins.LostFocus
        If txtaliq_cofins.Text = "" Then
            txtaliq_cofins.Text = valor_campo_vazio()
        Else
            txtaliq_cofins.Text = formata_valor_campo(txtaliq_cofins.Text)
        End If
    End Sub

    Private Sub Bnteditar_Click(sender As Object, e As EventArgs) Handles Bnteditar.Click
        habilitaCampos()
        limpa()

        fem = "N"
        '' carregar_combo()
        TabControl1.SelectTab(Tabdadosprod)
        txtbarras.Focus()
        btnovo.Enabled = False
        btnsalvar.Enabled = True
        btnexcluir.Enabled = True
        txtcodigo.Enabled = True
        txtcodigo.Clear()
        txtcodigo.Focus()
        Bnteditar.Visible = False
        bntcancelar.Visible = True
    End Sub

    Private Sub bntcancelar_Click(sender As Object, e As EventArgs) Handles bntcancelar.Click
        limpa()
        txtcodigo.Text = ""
        desabilitaCampos()

        Bnteditar.Visible = True
        bntcancelar.Visible = False
        btnovo.Enabled = True
    End Sub


    Private Sub txtmargem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmargem.KeyPress

        If (e.KeyChar = Chr(13)) Then
            txtmargem.Text = Format(CDec(txtmargem.Text), "#,##0.00")
            txtprecovenda.Text = ((CDec(txtprecofab.Text) * CDec(txtmargem.Text)) / 100) + CDec(txtprecofab.Text)
            txtprecovenda.Text = Format(CDec(txtprecovenda.Text), "#,##0.00")
        End If

    End Sub

    Private Sub txtvlrprom_LostFocus(sender As Object, e As EventArgs) Handles txtvlrprom.LostFocus
        If txtvlrprom.Text = "" Then
            txtvlrprom.Text = valor_campo_vazio()
        Else
            If CDec(txtvlrprom.Text) > CDec(txtprecovenda.Text) Then
                MsgBox("O preço de promoção não pode ser maior que o preço venda !", MsgBoxStyle.Exclamation, "Aviso !")
                txtvlrprom.Focus()
            End If

            If CDec(txtvlrprom.Text) < CDec(txtprecofab.Text) Then
                MsgBox("O preço de promoção não pode ser menor que o preço custo !", MsgBoxStyle.Exclamation, "Aviso !")
                txtvlrprom.Focus()
            End If

            txtvlrprom.Text = Format(CDec(txtvlrprom.Text), "#,##0.00")
        End If
    End Sub

   
    Private Sub txtncm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtncm.SelectedIndexChanged
        carrega_cest()
    End Sub

    Private Sub txtcest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtcest.SelectedIndexChanged

    End Sub

    Private Sub txtcest_Validated(sender As Object, e As EventArgs) Handles txtcest.Validated
        Dim verifica As Boolean = False
        For i As Integer = 0 To txtcest.Items.Count - 1

            If txtcest.Text = CType(txtcest.Items(i), MTGCComboBoxItem).Col1 Then
                verifica = True
            End If

        Next
        If txtcest.Text <> "" Then
            If verifica = False Then
                MsgBox("O código cest informado não e valido !", MsgBoxStyle.Exclamation, "Aviso !")
                txtcest.Text = ""
                txtcest.Focus()
            End If
        End If
    End Sub

    Private Sub cbocsticms_Validated(sender As Object, e As EventArgs) Handles cbocsticms.Validated
        Dim verifica As Boolean = False
        For i As Integer = 0 To cbocsticms.Items.Count - 1

            If cbocsticms.Text = CType(cbocsticms.Items(i), MTGCComboBoxItem).Col1 Then
                verifica = True
            End If

        Next
        If cbocsticms.Text <> "" Then
            If verifica = False Then
                MsgBox("O CST Informada não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
                cbocsticms.Text = ""
                cbocsticms.Focus()
            End If
        End If
    End Sub

   
    Public Sub carga_prod(ByVal cod As String, ByVal desc As String, ByVal un As String, ByVal vlr_venda As String, ByVal vlr_promocao As String, _
                   ByVal ncm_prod As String, ByVal cest As String, ByVal cst As String, ByVal aliq_icms As String, ByVal Inf_adi_prod As String)

        If cod = "" Then
            Exit Sub
        End If
        Dim parametro As New Utilitarios

        Directory.CreateDirectory(parametro.Caminho_arq_export())

        Dim arquivo As String = parametro.Caminho_arq_export() & "\carga.cac"
        Dim sep As String = "|"



        Dim fluxoTexto As IO.StreamReader
        Dim myList As New ArrayList


        If IO.File.Exists(arquivo) Then
            fluxoTexto = New IO.StreamReader(arquivo)
            While fluxoTexto.Peek() > -1
                myList.Add(fluxoTexto.ReadLine())
            End While
            fluxoTexto.Close()
        End If

        File.Delete(arquivo)

        Using writer As StreamWriter = New StreamWriter(arquivo, True)
            For Each l In myList
                writer.WriteLine(l)
            Next

            writer.WriteLine("10" & sep & cod & sep & desc & sep & un & sep & vlr_venda & sep & vlr_promocao & sep & _
                            ncm_prod & sep & cest & sep & cst & sep & aliq_icms & sep & Inf_adi_prod.ToString.Trim())



        End Using
    End Sub


    Public Sub export_ncm(ByVal cod As String, ByVal nacional As String, ByVal nacional_imp As String, ByVal estadual As String, ByVal municipal As String)

        If cod = "" Then
            Exit Sub
        End If
        Dim parametro As New Utilitarios

        Directory.CreateDirectory(parametro.Caminho_arq_export())

        Dim arquivo As String = parametro.Caminho_arq_export() & "\carga.cac"
        Dim sep As String = "|"



        Dim fluxoTexto As IO.StreamReader
        Dim myList As New ArrayList


        If IO.File.Exists(arquivo) Then
            fluxoTexto = New IO.StreamReader(arquivo)
            While fluxoTexto.Peek() > -1
                myList.Add(fluxoTexto.ReadLine())
            End While
            fluxoTexto.Close()
        End If

        File.Delete(arquivo)

        Using writer As StreamWriter = New StreamWriter(arquivo, True)
            For Each l In myList
                writer.WriteLine(l)
            Next

            writer.WriteLine("15" & sep & cod & sep & nacional & sep & nacional_imp & sep & estadual & sep & municipal)

        End Using
    End Sub


    Public Sub carga_barras(ByVal cod As String, ByVal cod_barras As String, ByVal un As String, ByVal qtde As String)
        If cod = "" Then
            Exit Sub
        End If
        Dim parametro As New Utilitarios

        Directory.CreateDirectory(parametro.Caminho_arq_export())

        Dim arquivo As String = parametro.Caminho_arq_export() & "\carga.cac"
        Dim sep As String = "|"



        Dim fluxoTexto As IO.StreamReader
        Dim myList As New ArrayList


        If IO.File.Exists(arquivo) Then
            fluxoTexto = New IO.StreamReader(arquivo)
            While fluxoTexto.Peek() > -1
                myList.Add(fluxoTexto.ReadLine())
            End While
            fluxoTexto.Close()
        End If

        File.Delete(arquivo)

        Using writer As StreamWriter = New StreamWriter(arquivo, True)
            For Each l In myList
                writer.WriteLine(l)
            Next

            writer.WriteLine("11" & sep & cod & sep & cod_barras & sep & un & sep & qtde)



        End Using
    End Sub

    Private Sub txtcodigo_TextChanged(sender As Object, e As EventArgs) Handles txtcodigo.TextChanged

    End Sub

    Private Sub Tabdadosprod_Click(sender As Object, e As EventArgs) Handles Tabdadosprod.Click

    End Sub

    Private Sub Tabdadosprod_MouseMove(sender As Object, e As MouseEventArgs) Handles Tabdadosprod.MouseMove

        If txtcodigo.Text = "Novo" Then
            TabControl1.TabPages(0).Enabled = True
            TabControl1.TabPages(1).Enabled = True
        End If

    End Sub

    Private Sub txtqtembalagem_TextChanged(sender As Object, e As EventArgs) Handles txtqtembalagem.TextChanged

    End Sub
End Class