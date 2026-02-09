Imports System.Data.OleDb
Imports System.Data
Imports MySql.Data.MySqlClient

Public Class frmcest
    Public forme As String
    Private Sub listaCEST()
        Dim sql As String
        dgvcest.Rows.Clear()

        If forme = "cad" Then
            sql = "SELECT * FROM cest WHERE ncm LIKE '" & FrmProduto.txtncm.Text.Substring(0, 2) & "' OR ncm LIKE '" & FrmProduto.txtncm.Text.Substring(0, 4) & "' OR ncm like '" & FrmProduto.txtncm.Text.Substring(0, 6) & "' OR ncm LIKE '" & FrmProduto.txtncm.Text.Substring(0, 8) & "'"
        End If
        If forme = "nfe" Then
            sql = "SELECT * FROM cest WHERE ncm LIKE '" & frmxml_nfe.txtncm_item.Text.Substring(0, 2) & "' OR ncm LIKE '" & frmxml_nfe.txtncm_item.Text.Substring(0, 4) & "' OR ncm like '" & frmxml_nfe.txtncm_item.Text.Substring(0, 6) & "' OR ncm LIKE '" & frmxml_nfe.txtncm_item.Text.Substring(0, 8) & "'"
        End If

        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())

            dgvcest.Rows.Add(dr("codigo"), dr("ncm"), dr("descricao"))

            lbltotalregistro.Text = dgvcest.RowCount
        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()


        ' MsgBox(FrmProduto.txtncm.Text.Substring(0, 2))
    End Sub
    Private Sub frmcest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listaCEST()
    End Sub

    Private Sub txtfiltro_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(13) Then
            listaCEST()
        End If
    End Sub

    Private Sub dgvcest_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvcest.MouseClick
        If forme = "cad" Then
            FrmProduto.txtcest.Text = dgvcest.CurrentRow.Cells(0).Value
        End If
        If forme = "nfe" Then
            frmxml_nfe.txtcest_item.Text = dgvcest.CurrentRow.Cells(0).Value
        End If
        Me.Close()
    End Sub
End Class