Imports System.Data.OleDb
Imports System.Data
Imports MySql.Data.MySqlClient

Public Class FrmNCM

    Public codigo As String


    Private Sub listaNcm()
        dgvncm.Rows.Clear()
        Dim sql As String

        If txtfiltro.Text = "" Then
            sql = "SELECT * FROM ncm"
        Else
            sql = "SELECT * FROM ncm WHERE codigo LIKE '" & txtfiltro.Text & "%'"
        End If

        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())

            dgvncm.Rows.Add(dr("codigo"), dr("descricao"))

            lbltotalregistro.Text = dgvncm.RowCount
        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()

    End Sub


    Private Sub FrmNCM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listaNcm()
        txtfiltro.Focus()
    End Sub

    Private Sub txtfiltro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtfiltro.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            listaNcm()

            If dgvncm.RowCount = 1 Then
                dgvncm.Focus()
            End If
        End If
    End Sub


    Private Sub dgvncm_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvncm.MouseClick
        FrmProduto.txtncm.Text = dgvncm.CurrentRow.Cells(0).Value
        Me.Close()
        FrmProduto.pbcest.Enabled = True
    End Sub

    Private Sub dgvncm_SelectionChanged(sender As Object, e As EventArgs) Handles dgvncm.SelectionChanged

    End Sub

    Private Sub txtfiltro_TextChanged(sender As Object, e As EventArgs) Handles txtfiltro.TextChanged

    End Sub
End Class