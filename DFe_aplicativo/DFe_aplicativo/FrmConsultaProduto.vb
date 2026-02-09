Imports System.Data
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class FrmConsultaProduto
    Public par As String
    Dim rs As New ADODB.Recordset
    Dim rs2 As New ADODB.Recordset

    Private Sub listaProduto()
        dgvprodutos.Rows.Clear()
        Dim sql As String

        If cbotipo.Text = "Descricao Produto" Then
            sql = "SELECT * FROM produto WHERE prod_ativo = " & chkprod_inativa.Checked & " and desc_prod LIKE '%" & txtfiltrodesc.Text & "%'"
        End If

        If cbotipo.Text = "Codigo Interno" Then
            sql = "SELECT * FROM produto WHERE prod_ativo = " & chkprod_inativa.Checked & " and codigo_prod = '" & txtfiltrodesc.Text & "'"
        End If

        If cbotipo.Text = "NCM" Then
            sql = "SELECT * FROM produto WHERE prod_ativo = " & chkprod_inativa.Checked & " and ncm_prod = '" & txtfiltrodesc.Text & "'"
        End If

        If cbotipo.Text = "CEST" Then
            sql = "SELECT * FROM produto WHERE prod_ativo = " & chkprod_inativa.Checked & " and cest_prod = '" & txtfiltrodesc.Text & "'"
        End If

        If cbotipo.Text = "Valor Venda" Then
            If txtfiltrodesc.Text <> "" Then
                sql = "SELECT * FROM produto WHERE prod_ativo = " & chkprod_inativa.Checked & " and valor_fab = '" & format_val_mysql_ent(txtfiltrodesc.Text) & "'"
            End If
        End If

        If cbotipo.Text = "Valor Custo" Then
            If txtfiltrodesc.Text <> "" Then
                sql = "SELECT * FROM produto WHERE prod_ativo = " & chkprod_inativa.Checked & " and valor_venda = '" & format_val_mysql_ent(txtfiltrodesc.Text) & "'"
            End If
        End If

        If txtfiltrobarras.Text <> "" Then
            sql = "SELECT * FROM produto INNER JOIN Codigo_barras ON produto.codigo_prod = Codigo_barras.codigo_prd where produto.prod_ativo = " & chkprod_inativa.Checked & " and Codigo_barras.codigo_barra ='" & txtfiltrobarras.Text & "'"
        End If

       


        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read


                dgvprodutos.Rows.Add(reader("codigo_prod"), reader("desc_prod"), reader("barras_prod"), format_val_mysql_ret(reader("valor_fab")), format_val_mysql_ret(reader("valor_venda")))


                'lbltotalregistro.Text = dgvncm.RowCount

            End While
        End Using
        txtfiltrobarras.Clear()

        If dgvprodutos.Rows.Count = 0 Then
            MsgBox("Produto não cadastrado !", MsgBoxStyle.Exclamation, "Aviso !")
            txtfiltrodesc.Focus()
        End If
    End Sub


    Private Sub FrmConsultaProduto_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Me.Text = "Consulta de Produtos" Then
            chkprod_inativa.Visible = True
        End If

        If Me.Text = "Pesquisar Produtos" Then
            chkprod_inativa.Visible = False
        End If

        txtfiltrodesc.Focus()
    End Sub

    Private Sub FrmConsultaProduto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbotipo.SelectedIndex = 0

        'listaProduto()
    End Sub

    Private Sub txtfiltrodesc_GotFocus(sender As Object, e As EventArgs) Handles txtfiltrodesc.GotFocus
        txtfiltrobarras.Clear()
    End Sub

    Private Sub txtfiltrodesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtfiltrodesc.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            If txtfiltrodesc.Text = "" Then
                txtfiltrodesc.Text = "%"
            End If
            listaProduto()
            If dgvprodutos.RowCount = 1 Then
                dgvprodutos.Focus()
            End If
        End If
    End Sub

    Private Sub txtfiltrobarras_GotFocus(sender As Object, e As EventArgs) Handles txtfiltrobarras.GotFocus
        txtfiltrodesc.Clear()
    End Sub

    Private Sub txtfiltrobarras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtfiltrobarras.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then


            If txtfiltrobarras.Text = "" Then
                MsgBox("Informe um Código de Barra para COnsulta ?", MsgBoxStyle.Exclamation, "Aviso !")
                Exit Sub
            End If

            listaProduto()
            If dgvprodutos.RowCount = 1 Then
                dgvprodutos.Focus()
            End If
        End If
    End Sub

    Private Sub dgvprodutos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvprodutos.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
        End If

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Dispose()
        End Select
    End Sub

    Private Sub dgvprodutos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvprodutos.KeyPress
        If (e.KeyChar = Chr(13)) Then

            If Me.Text = "Consulta cad Fornecedor" Then
                frmcod_for.txtcodigo.Text = dgvprodutos.CurrentRow.Cells("codigo_prod").Value
                frmcod_for.txtdescricao.Text = ret_valor_campo("select * from produto where codigo_prod = " & dgvprodutos.CurrentRow.Cells("codigo_prod").Value & "", "desc_prod")
            End If

            If Me.Text = "Consulta de Produtos" Then

                FrmProduto.carregar_produtos(dgvprodutos.CurrentRow.Cells("codigo_prod").Value, False)

            End If

            If Me.Text = "Pesquisar Produto NF entrada" Then

                conectar_mysqlDFe()
                Dim SQLcommand As MySqlCommand
                SQLcommand = oConn.CreateCommand
                SQLcommand.CommandText = "select * from produto where codigo_prod = '" & dgvprodutos.CurrentRow.Cells("codigo_prod").Value & "'"
                '   dr = SQLcommand.ExecuteReader()

                Using reader As MySqlDataReader = SQLcommand.ExecuteReader

                    While reader.Read
                        frmnfe_entrada.txtcodigoprod_item.Text = reader("codigo_prod")
                        frmnfe_entrada.txtdescprod_item.Text = reader("desc_prod")
                        frmnfe_entrada.txtvlrunit_item.Text = format_val_mysql_ret(reader("valor_fab"))
                        frmnfe_entrada.txtqtdecx_item.Text = reader("Qtde_emb_prod")
                        frmnfe_entrada.cboncm_item.Text = reader("ncm_prod")
                        frmnfe_entrada.cbocest_item.Text = reader("cest_prod")
                        frmnfe_entrada.cbocst_item.Text = reader("cst_icms")
                        frmnfe_entrada.txtaliqicms_item.Text = format_val_mysql_ret(reader("aliq_icms"))
                        frmnfe_entrada.cbocstipi_item.Text = reader("cst_ipi_ent")
                        frmnfe_entrada.cbocstpis_item.Text = reader("cst_pis_ent")
                        frmnfe_entrada.txtaliqpis_item.Text = format_val_mysql_ret(reader("aliq_pis"))
                        frmnfe_entrada.txtaliqcofins_item.Text = format_val_mysql_ret(reader("aliq_cofins"))
                        frmnfe_entrada.txtaliqipi_item.Text = format_val_mysql_ret(reader("aliq_ipi"))
                        frmnfe_entrada.lblun.Text = reader("unidade_prod")
                        frmnfe_entrada.vlrunit = format_val_mysql_ret(reader("valor_fab"))
                    End While
                End Using

            End If

            If par = "pdv" Then
                conectar_baseNFe()
                Dim rsconsulta As New ADODB.Recordset
                rsconsulta.Open("select * from produto where codigo_prod = " & dgvprodutos.CurrentRow.Cells("codigo_prod").Value & "", conexao.cn_nfe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                '   frmpdv.txtdesconto.Text = "0,00"
                ' frmpdv.txtdescricao.Text = rsconsulta.Fields("desc_prod").Value

                '  frmpdv.txtvlrunit.Text = rsconsulta.Fields("valor_venda").Value
                '  frmpdv.txtncm.Text = rsconsulta.Fields("ncm_prod").Value
                '  frmpdv.txtcst.Text = rsconsulta.Fields("cst_icms_prod").Value
                '  frmpdv.txtcest.Text = rsconsulta.Fields("cest_prod").Value.ToString.Replace(".", "")
                ' frmpdv.txtaliqicms.Text = rsconsulta.Fields("aliquota_icms").Value.ToString
                ' frmpdv.txtvlrunit.Text = rsconsulta.Fields("promocao_prod").Value

                ' frmpdv.txtcod.Text = rsconsulta.Fields("codigo_prod").Value
                ' frmpdv.txtcodbarra.Text = rsconsulta.Fields("barras_prod").Value
                '  frmpdv.txtun.Text = rsconsulta.Fields("unidade_prod").Value.ToString.Substring(0, 2)
                '  If frmpdv.txtqtde.Text = "" Then
                'frmpdv.txtqtde.Text = "1,000"
                ' End If

                'If rsconsulta.Fields("Inf_adi_prod").Value.ToString <> "" Then
                'MsgBox(rsconsulta.Fields("Inf_adi_prod").Value, MsgBoxStyle.Information, "Observação do Produto !")
                ' frmpdv.txtqtde.Focus()
                ' End If

                'fecha_baseNFe()
                ' frmpdv.txtcodbarra.Focus()
            End If


            If Me.Text = "Pesquisar Produtos" Then

                frmxml_nfe.txtcodfor_item.Text = dgvprodutos.CurrentRow.Cells(0).Value
                frmxml_nfe.consulta_prod()
            End If

            Me.Close()
        End If
    End Sub


    Private Sub dgvprodutos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvprodutos.CellContentClick

    End Sub
End Class