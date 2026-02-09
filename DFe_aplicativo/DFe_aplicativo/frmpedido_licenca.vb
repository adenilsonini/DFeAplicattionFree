Imports MySql.Data.MySqlClient

Public Class frmpedido_licenca

    Private Sub bntimprimir_Click(sender As Object, e As EventArgs) Handles bntimprimir.Click
        frmlicenca.envia_email()
    End Sub

    Private Sub frmpedido_licenca_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar_mysqlDFe()
        Dim SQLcommand4 As MySqlCommand
        SQLcommand4 = oConn.CreateCommand
        SQLcommand4.CommandText = "select * from valores_licenca where tipo_sistema = 'dfe'"

        Using reader As MySqlDataReader = SQLcommand4.ExecuteReader

            While reader.Read

                txtinfo.Text = reader("informacao").ToString

            End While

        End Using
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        System.Diagnostics.Process.Start("http://nfesjp.online/contato")
    End Sub
End Class