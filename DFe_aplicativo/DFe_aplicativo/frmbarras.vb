Imports MySql.Data.MySqlClient

Public Class frmbarras
    Dim rs As New ADODB.Recordset
    Private Sub txtbarras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbarras.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If validaGTIN(txtbarras.Text) = False Then
            MsgBox("Código de Barras Invalido !", MsgBoxStyle.Exclamation, "Aviso !")
            txtbarras.Focus()
            Exit Sub
        End If


        conectar_mysqlDFe()
        Dim SQL2 As MySqlCommand = New MySqlCommand("INSERT INTO codigo_barras (codigo_prod, Codigo_barra, un, qtde) VALUES ('" & txtcod.Text & "', '" & txtbarras.Text & "', '" & cbounidade.Text & "', '" & txtqtde.Text & "' )", oConn)
        SQL2.ExecuteNonQuery()
        oConn.Close()


        txtbarras.Clear()
        txtbarras.Focus()

        cbounidade.SelectedIndex = 0
        txtqtde.Text = "1"

        MsgBox("Codigo de Barras Adicionado com Sucesso !", MsgBoxStyle.Information, "Aviso !")

        carregar()
    End Sub

    Private Sub frmbarras_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        FrmProduto.txtbarras.Text = dgvbarras.CurrentRow.Cells(1).Value
        Me.Dispose()
    End Sub

    Private Sub carregar()
        dgvbarras.Rows.Clear()

        conectar_mysqlDFe()
        Dim SQLcommand2 As MySqlCommand
        SQLcommand2 = oConn.CreateCommand
        SQLcommand2.CommandText = "select * from Codigo_barras where codigo_prod = " & txtcod.Text & ""
        dr = SQLcommand2.ExecuteReader()

        While (dr.Read())
            dgvbarras.Rows.Add(dr("codigo_prod"), dr("Codigo_barra"), dr("un"), dr("qtde"))
        End While

        dr.Close()
        SQLcommand2.Dispose()
        oConn.Close()

    End Sub

    Private Sub frmbarras_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub frmbarras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carregar()
        carrega_unidade()
        cbounidade.SelectedIndex = 0
        txtqtde.Text = "1"
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
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If dgvbarras.CurrentRow.Cells(0).Value = dgvbarras.CurrentRow.Cells(1).Value.ToString.TrimStart("0") Then
            MsgBox("O codigo de barras não pode ser excluido !", MsgBoxStyle.Exclamation, "Aviso !")
        Else
            If MessageBox.Show("Deseja realmente excluir o codigo de barras selecionado ? ", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                conectar_mysqlDFe()
                Dim SQL2 As MySqlCommand = New MySqlCommand("delete from codigo_barras where codigo_barra = '" & dgvbarras.CurrentRow.Cells(1).Value & "'", oConn)
                SQL2.ExecuteNonQuery()
                oConn.Close()

                dgvbarras.Rows.Remove(dgvbarras.CurrentRow)

                MsgBox("Codigo de Barras excluido com sucesso !", MsgBoxStyle.Information, "Aviso !")
            End If
        End If
    End Sub

    Private Sub txtqtde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtqtde.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class