Imports MySql.Data.MySqlClient

Public Class frmLogsitevb

    Private Sub bntpesquisa_Click(sender As Object, e As EventArgs) Handles bntpesquisa.Click
        conectar_mysqlSite()
        dgvlog.Rows.Clear()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand

        SQLcommand.CommandText = "select * from log where data_mysql BETWEEN '" & Convert.ToDateTime(mskdatainicial.Text).ToString("yyyy-MM-dd 00:00:00") & "' AND '" & Convert.ToDateTime(mskdatafinal.Text).ToString("yyyy-MM-dd 23:59:59") & "'"
        ' SQLcommand.CommandText = "select * from log"

        dr = SQLcommand.ExecuteReader()

        While (dr.Read())

            dgvlog.Rows.Add(dr("usuario"), dr("log"), dr("data"))


        End While


        MsgBox("Pesquisa realizada !", MsgBoxStyle.Information, "Aviso !")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        conectar_mysqlSite()
        For Each row As DataGridViewRow In Me.dgvlog.Rows

            Dim SQLcommand As MySqlCommand
            SQLcommand = oConn.CreateCommand

            'SQLcommand.CommandText = "select * from log where data BETWEEN '" & mskdatainicial.Text & "' AND '" & mskdatafinal.Text & "'"
            SQLcommand.CommandText = "update log set data_mysql = '" & Convert.ToDateTime(row.Cells(2).Value).ToString("yyyy-MM-dd HH:mm:ss") & "' where data= '" & row.Cells(2).Value & "' "

            SQLcommand.ExecuteNonQuery()

        Next

        MsgBox("pronto")
    End Sub
End Class