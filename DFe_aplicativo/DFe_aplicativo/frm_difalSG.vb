Imports MySql.Data.MySqlClient

Public Class frm_difalSG

    Private Sub carregar()
        dgvproduto.Rows.Clear()

        Dim sql As String = "select * from preco_sg where dataemissao between '" & Convert.ToDateTime(Dataini.Text).ToString("yyyy-MM-dd 00:00:00") & "' AND '" & Convert.ToDateTime(datafin.Text).ToString("yyyy-MM-dd 23:59:59") & "'"

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql


        Using dr As MySqlDataReader = SQLcommand.ExecuteReader

            While dr.Read

                Dim re As String = dr("vlr_real")

                If re.ToString = "" Then
                    re = "0,00"
                End If

                dgvproduto.Rows.Add(dr("cod_for").ToString.TrimStart("0"), dr("cod_sg"), dr("desc_prd"), dr("precocusto_xml"), dr("precocusto_sg"), dr("vlrvendaSG"), dr("diferenca"), dr("margem_atual"), dr("qtde_cx"), dr("status"), _
                                    dr("chave_nfe"), dr("cnpj_for"), dr("nomefor"), Convert.ToDateTime(dr("dataemissao")).ToString("dd/MM/yyyy"), dr("valornfe"), dr("unxml"), Format(CDec(re), "#,##0.00"), dr("qtdexml"))




            End While

        End Using

    End Sub

    Private Sub inativo()
        Dim rs As New ADODB.Recordset
        Dim sql As String

        For Each row As DataGridViewRow In dgvproduto.Rows

            If row.Cells("codsggrid").Value = "" Then

                If verifica_cad(row.Cells("codforgrid").Value, cod_for(row.Cells("cnpj").Value)) <> "" Then
                    row.Cells("codsggrid").Value = verifica_cad(row.Cells("codforgrid").Value, cod_for(row.Cells("cnpj").Value))

                    If validar_preco(row.Cells("codsggrid").Value, row.Cells("precoxmlgrid").Value, row.Cells("qtdecxgrid").Value, row.Cells("chave").Value & row.Cells("codforgrid").Value) = False Then
                        executa_query("delete from preco_sg where chave_sist = '" & row.Cells("chave").Value & row.Cells("codforgrid").Value & "'")
                    End If

                    '  dgvproduto.Rows.RemoveAt(Me.dgvproduto.SelectedRows(0).Index)


                End If

            End If

            If row.Cells("codsggrid").Value <> "" Then
                conectarsqlinx()
                sql = "SELECT es1_cod, Es1_Ativo FROM es1 where es1_cod = '" & row.Cells("codsggrid").Value & "'"

                rs.Open(sql, cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

                If rs.Fields("Es1_Ativo").Value = "0" Then
                    row.Cells("statuscadgrid").Value = "Produto Inativo"
                    With Me.dgvproduto.Rows(row.Index).DefaultCellStyle
                        .BackColor = Color.Coral
                        .ForeColor = Color.White
                    End With


                End If

                rs.Close()
                cnsql.Close()
            End If
        Next

    End Sub
    Private Sub cor_grid()
        For Each row As DataGridViewRow In dgvproduto.Rows

            If row.Cells("statuscadgrid").Value <> "" Then
                With Me.dgvproduto.Rows(row.Index).DefaultCellStyle
                    .BackColor = Color.Red
                    .ForeColor = Color.White
                End With
            End If


        Next
    End Sub
    Private Sub dgvproduto_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvproduto.CellBeginEdit

    End Sub

    Private Sub dgvproduto_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvproduto.RowValidating

    End Sub


    Private Sub dgvproduto_SelectionChanged(sender As Object, e As EventArgs) Handles dgvproduto.SelectionChanged
        Try

            lbldescprod.Text = dgvproduto.CurrentRow.Cells("descgrid").Value
            mskchave.Text = dgvproduto.CurrentRow.Cells("chave").Value
            mskcnpj.Text = dgvproduto.CurrentRow.Cells("cnpj").Value
            txtnome.Text = dgvproduto.CurrentRow.Cells("nome").Value
            txtnumero.Text = mskchave.Text.Substring(25, 9)
            txtdata.Text = dgvproduto.CurrentRow.Cells("dataemissao").Value
            txtvalor.Text = dgvproduto.CurrentRow.Cells("valornfe").Value
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvproduto_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproduto.CellContentClick

    End Sub

    Private Sub dgvproduto_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvproduto.CellEndEdit
        If dgvproduto.CurrentRow.Cells("qtdecxgrid").Value <> "" Then
            dgvproduto.CurrentRow.Cells("qtdecxgrid").Value = dgvproduto.CurrentRow.Cells("qtdecxgrid").Value.ToString.Replace(".", ",")
            If dgvproduto.CurrentRow.Cells("qtdecxgrid").Value <> "0" Then
                dgvproduto.CurrentRow.Cells("precoxmlgrid").Value = Format(CDec(dgvproduto.CurrentRow.Cells("vlr_unitotal").Value) / CDec(dgvproduto.CurrentRow.Cells("qtdecxgrid").Value), "#,##0.00")

                dgvproduto.CurrentRow.Cells("margemgrid").Value = Format((CDec(dgvproduto.CurrentRow.Cells("preco_SG_venda").Value) - CDec(dgvproduto.CurrentRow.Cells("precoxmlgrid").Value)) * 100 / CDec(dgvproduto.CurrentRow.Cells("precoxmlgrid").Value), "#,##0.00")
                dgvproduto.CurrentRow.Cells("diferencagrid").Value = Format(CDec(dgvproduto.CurrentRow.Cells("precoxmlgrid").Value) - CDec(dgvproduto.CurrentRow.Cells("precosggrid").Value), "#,##0.00")


                executa_query("update preco_sg set diferenca = '" & dgvproduto.CurrentRow.Cells("diferencagrid").Value & "', margem_atual = '" & dgvproduto.CurrentRow.Cells("margemgrid").Value & "', precocusto_sg = '" & dgvproduto.CurrentRow.Cells("precoxmlgrid").Value & "',  precocusto_xml = '" & dgvproduto.CurrentRow.Cells("precoxmlgrid").Value & "' , qtde_cx = '" & dgvproduto.CurrentRow.Cells("qtdecxgrid").Value & "' where chave_sist = '" & mskchave.Text & dgvproduto.CurrentRow.Cells("codforgrid").Value & "'")

                Dim QTDE2 As String = dgvproduto.CurrentRow.Cells("qtdecxgrid").Value.ToString.Replace(",", ".")
                executa_query_SGlinx("update es1 set es1_qembc = '" & QTDE2 & "' where es1_cod = '" & dgvproduto.CurrentRow.Cells("codsggrid").Value & "'")
            End If

        End If
    End Sub

    Private Sub DivergenviaResolvidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DivergenviaResolvidaToolStripMenuItem.Click
        executa_query("delete from preco_sg where chave_sist = '" & mskchave.Text & dgvproduto.CurrentRow.Cells("codforgrid").Value & "'")
        dgvproduto.Rows.Remove(dgvproduto.CurrentRow)
        MsgBox("Informação salva com sucesso !", MsgBoxStyle.Information, "Aviso !")
    End Sub

    Private Sub AlterarPreçoSistemaSGToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlterarPreçoSistemaSGToolStripMenuItem.Click
        executa_query_SGlinx("update es1 set es1_prvarejo = '" & dgvproduto.CurrentRow.Cells("precosggrid").Value.ToString.Replace(".", "").Replace(",", ".") & "', es1_prcusto = '" & dgvproduto.CurrentRow.Cells("precoxmlgrid").Value.ToString.Replace(".", "").Replace(",", ".") & "', es1_prcompra = '" & dgvproduto.CurrentRow.Cells("precoxmlgrid").Value.ToString.Replace(".", "").Replace(",", ".") & "' where es1_cod = '" & dgvproduto.CurrentRow.Cells("codsggrid").Value & "'")
        MsgBox("Informação salva com sucesso !", MsgBoxStyle.Information, "Aviso !")
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If dgvproduto.CurrentRow.Cells("statuscadgrid").Value = "" Then
            AlterarPreçoSistemaSGToolStripMenuItem.Enabled = True
        Else
            AlterarPreçoSistemaSGToolStripMenuItem.Enabled = False
        End If

        If dgvproduto.CurrentRow.Cells("statuscadgrid").Value = "Produto Inativo" Then
            AtivarProdutoToolStripMenuItem.Enabled = True
        Else
            AtivarProdutoToolStripMenuItem.Enabled = False
        End If

    End Sub

    Private Sub AtivarProdutoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AtivarProdutoToolStripMenuItem.Click
        executa_query_SGlinx("update es1 set Es1_Ativo = '1', es1_prcusto = '" & dgvproduto.CurrentRow.Cells("precoxmlgrid").Value.ToString.Replace(".", "").Replace(",", ".") & "', es1_prcompra = '" & dgvproduto.CurrentRow.Cells("precoxmlgrid").Value.ToString.Replace(".", "").Replace(",", ".") & "' where es1_cod = '" & dgvproduto.CurrentRow.Cells("codsggrid").Value & "'")
        MsgBox("Produto Ativado!", MsgBoxStyle.Information, "Aviso !")
    End Sub

    Private Function cod_for(ByVal cnpj As String) As String
        Dim ret As String = ""
        conectarsqlinx()
        Dim RS As New ADODB.Recordset
        '''''''''''''''''verifica se o fornecedor esta cadastrado'''''''''''''''''''
        Dim Sql As String = "SELECT cg2_cgc, cg2_cod FROM cg2  where cg2_cgc = '" & cnpj & "'"
        RS.Open(Sql, cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If RS.EOF = False Then
            ret = RS.Fields("cg2_cod").Value
            RS.Close()
        End If
        cnsql.Close()

        Return ret
    End Function

    Private Function verifica_cad(ByVal codfor As String, ByVal cod_cad_for As String) As String
        Dim ret As String = ""

        conectarsqlinx()
        Dim RS As New ADODB.Recordset
        Dim Sql As String = "SELECT * FROM es1i where cg2_cod = '" & cod_cad_for & "' and es1_codforn = '" & codfor & "'"

        RS.Open(Sql, cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        If RS.EOF = False Then

            ret = RS.Fields("es1_cod").Value

        End If

        RS.Close()
        cnsql.Close()

        Return ret
    End Function

    Private Sub AlterarPreçoVendaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        executa_query_SGlinx("update es1 set preco_SG_venda = '" & dgvproduto.CurrentRow.Cells("precoxmlgrid").Value.ToString.Replace(".", "").Replace(",", ".") & "', es1_prcompra = '" & dgvproduto.CurrentRow.Cells("precoxmlgrid").Value.ToString.Replace(".", "").Replace(",", ".") & "' where es1_cod = '" & dgvproduto.CurrentRow.Cells("codsggrid").Value & "'")
        MsgBox("Informação salva com sucesso !", MsgBoxStyle.Information, "Aviso !")
    End Sub

    Private Sub frm_difalSG_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Function validar_preco(ByVal codsg As String, ByVal pr_real As String, ByVal qtdecx As String, ByVal chave_sist As String) As Boolean
        Dim ret As Boolean = False
        Dim preco_custo As String, pr_venda As String, margem As String, dir As String

        If codsg <> "" Then

            preco_custo = "0,00"
            pr_venda = "0,00"
            margem = "0,00"
            dir = "0"

            conectarsqlinx()
            Dim RS As New ADODB.Recordset
            Dim Sql As String = "SELECT * FROM es1 where es1_cod = '" & codsg & "'"

            RS.Open(Sql, cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

            If RS.EOF = False Then

                preco_custo = Format(CDec(RS.Fields("es1_prcompra").Value.ToString.Replace(".", ",")), "#,##0.00")

                qtdecx = RS.Fields("es1_qembc").Value

                pr_venda = Format(CDec(RS.Fields("es1_prvarejo").Value.ToString.Replace(".", ",")), "#,##0.00")

            End If

            RS.Close()
            cnsql.Close()




            '''''''''''Rotina busca o preço da tributação''''''''''''''''''

            margem = Format((CDec(pr_real) * 100) / CDec(pr_venda), "#,##0.00")


            Dim pr As Boolean = False
            If CDec(pr_real) <> CDec(preco_custo) Then
                dir = Format(CDec(pr_real) - CDec(preco_custo), "#,##0.00")



                Dim vlr As String

                If CDec(pr_real) - CDec(preco_custo) > "0,10" Then
                    vlr = CDec(pr_real) - CDec(preco_custo)
                    pr = True
                End If

                If CDec(preco_custo) - CDec(pr_real) > "0,10" Then
                    vlr = CDec(pr_real) - CDec(preco_custo)
                    pr = True
                End If



                If pr = True Then

                    executa_query("update preco_sg set cod_sg = '" & codsg & "', qtde_cx = '" & qtdecx & "',  status = '', precocusto_xml = '" & pr_real & "', vlrvendaSG = '" & pr_venda & "', precocusto_sg = '" & preco_custo & "', diferenca = '" & dir & "', margem_atual = '" & margem & "' where chave_sist = '" & chave_sist & "'")

                    pr = False

                    ret = True
                End If

            End If

        End If

        Return ret
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        carregar()

        cor_grid()

        inativo()

        carregar()

        cor_grid()

        Label9.Text = "Total Registro grid: " & dgvproduto.RowCount
        MsgBox("Pesquisa realizada com Sucesso !", MsgBoxStyle.Information, "Aviso !")


        oConn.Close()
    End Sub
End Class