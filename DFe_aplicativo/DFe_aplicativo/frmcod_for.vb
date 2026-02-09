Imports MySql.Data.MySqlClient

Public Class frmcod_for

    Private Sub frmcod_for_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            FrmConsultaProduto.Text = "Consulta cad Fornecedor"
            FrmConsultaProduto.ShowDialog()
        End If
    End Sub

    Private Sub frmcod_for_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carregar()
    End Sub

    Private Sub carregar()
        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from codigo_forprod where cnpj_for ='" & lblcnpj.Text & "'"
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read
                dgvdados.Rows.Add(reader("codigo_prod"), ret_valor_campo("select * from produto where codigo_prod = " & reader("codigo_prod") & "", "desc_prod"), reader("codigo_for"))
            End While
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtcodigo.Text = "" Then
            MsgBox("Informe o Código do produto !", MsgBoxStyle.Exclamation, "Aviso !")
            txtcodigo.Focus()
        End If
        If verificar_regexiste("select * from produto where codigo_for = '" & lblcodfor.Text & "'") = 0 Then
            executa_query("INSERT INTO codigo_forprod (codigo_prod, codigo_for, cnpj_for) VALUES ('" & txtcodigo.Text & "', '" & lblcodfor.Text & "', '" & lblcnpj.Text & "')")
            MsgBox("Codigo atualizado com sucesso !", MsgBoxStyle.Information, "Aviso !")
            Me.Close()
        Else
            MsgBox("Já existe um produto vinculado a este Código", MsgBoxStyle.Exclamation, "Aviso !")
        End If

    End Sub
End Class