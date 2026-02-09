Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class frmpesquisa_cst
    Public parametro As String, entrada As Boolean
    Public filtro_tiponfe As String, filtro_tiponfe2 As String
    Public origem As String
    Public campo_pesquisa As String
    Public tabela As String
    Private Sub frmpesquisa_cst_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub


    Private Sub frmpesquisa_cst_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Me.Text = "Tela para alteração da CSOSN" Or Me.Text = "Tela para alteração da CST" Then


            If frmxml_nfe.txtregime.Text.Substring(0, 1) = "1" Then
                txtcod.MaxLength = "4"
            Else
                txtcod.MaxLength = "3"
            End If

        Else

            txtcod.MaxLength = "2"

        End If


        If Me.Text = "Tela para alteração de CFOP" Then
            txtcod.MaxLength = "4"
        End If

    End Sub

    Public Sub carrega_grid_filtro_cfop(ByVal codigo As String, ByVal tipo As Integer)

        Dim sql As String


        If tipo = 1 Then
            sql = "SELECT * FROM cfop where codigo like '%" & codigo & "%'"
        End If

        If tipo = 2 Then
            sql = "SELECT * FROM cfop where descricao like '%" & codigo & "%'"
        End If

        If tipo = 3 Then
            sql = "SELECT * FROM cfop"
        End If

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read

                If entrada = True Then

                    If reader("codigo").ToString.Substring(0, 1) = "1" Or reader("codigo").ToString.Substring(0, 1) = "2" Then
                        dgvdados.Rows.Add(reader("codigo"), reader("descricao"))
                    End If

                End If

                If entrada = False Then

                    If reader("codigo").ToString.Substring(0, 1) = "5" Or reader("codigo").ToString.Substring(0, 1) = "6" Then
                        dgvdados.Rows.Add(reader("codigo"), reader("descricao"))
                    End If

                End If

            End While

        End Using

    End Sub

    Public Sub carrega_grid_filtro_cst(ByVal codigo As String, ByVal tipo As Integer)
        Dim dr As OleDbDataReader = Nothing



        Dim sql As String


        If tipo = 1 Then
            sql = "SELECT * FROM cst_icms where codigo like '%" & codigo & "%'"
        End If

        If tipo = 2 Then
            sql = "SELECT * FROM cst_icms where descricao like '%" & codigo & "%'"
        End If

        If tipo = 3 Then
            sql = "SELECT * FROM cst_icms"
        End If

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read
                If frmxml_nfe.txtregime.Text.Substring(0, 1) = "1" Then

                    If reader("codigo").ToString.Length = 3 Then
                        dgvdados.Rows.Add(frmxml_nfe.txtcst_item.Text.Substring(0, 1) & reader("codigo"), reader("descricao"))
                    End If

                Else

                    If reader("codigo").ToString.Length = 2 Then
                        dgvdados.Rows.Add(frmxml_nfe.txtcst_item.Text.Substring(0, 1) & reader("codigo"), reader("descricao"))
                    End If

                End If

            End While

        End Using


    End Sub

    Public Sub carrega_grid_filtro_cofins(ByVal codigo As String, ByVal tipo As Integer)

        Dim dr As OleDbDataReader = Nothing


        Dim sql As String


        If tipo = 1 Then
            sql = "SELECT * FROM cst_cofins where codigo like '%" & codigo & "%'"
        End If

        If tipo = 2 Then
            sql = "SELECT * FROM cst_cofins where descricao like '%" & codigo & "%'"
        End If

        If tipo = 3 Then
            sql = "SELECT * FROM cst_cofins"
        End If

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read
                If entrada = False Then

                    If reader("codigo").ToString.Substring(0, 1) = "0" Or reader("codigo").ToString.Substring(0, 1) = "4" Then
                        dgvdados.Rows.Add(reader("codigo"), reader("descricao"))
                    End If

                Else

                    If reader("codigo").ToString.Substring(0, 1) = "5" Or reader("codigo").ToString.Substring(0, 1) = "6" Or reader("codigo").ToString.Substring(0, 1) = "7" Or reader("codigo").ToString.Substring(0, 1) = "9" Then
                        dgvdados.Rows.Add(reader("codigo"), reader("descricao"))
                    End If

                End If
            End While

        End Using

    End Sub

    Public Sub carrega_grid_filtro_ipi(ByVal codigo As String, ByVal tipo As Integer)

        Dim dr As OleDbDataReader = Nothing


        Dim sql As String


        If tipo = 1 Then
            sql = "SELECT * FROM cst_ipi where codigo like '%" & codigo & "%'"
        End If

        If tipo = 2 Then
            sql = "SELECT * FROM cst_ipi where descricao like '%" & codigo & "%'"
        End If

        If tipo = 3 Then
            sql = "SELECT * FROM cst_ipi"
        End If

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read
                If entrada = True Then

                    If reader("codigo").ToString.Substring(0, 1) = "0" Or reader("codigo").ToString.Substring(0, 1) = "4" Then
                        dgvdados.Rows.Add(reader("codigo"), reader("descricao"))
                    End If

                Else

                    If reader("codigo").ToString.Substring(0, 1) = "5" Or reader("codigo").ToString.Substring(0, 1) = "9" Then
                        dgvdados.Rows.Add(reader("codigo"), reader("descricao"))
                    End If

                End If
            End While

        End Using

    End Sub

   Private Sub txtcod_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcod.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            dgvdados.Rows.Clear()

            If Me.Text = "Tela para alteração de CST PIS" Or Me.Text = "Tela para alteração de CST COFINS" Or Me.Text = "Tela para alteração de CST IPI" Then
                carrega_grid_filtro_cofins(txtcod.Text, 1)
            End If

            If Me.Text = "Tela para alteração de CFOP" Then
                carrega_grid_filtro_cfop(txtcod.Text, 1)
            End If

            If Me.Text = "Tela para alteração da CSOSN" Or Me.Text = "Tela para alteração da CST" Then
                If txtcod.Text = "" Then
                    carrega_grid_filtro_cst("", 3)
                Else

                    carrega_grid_filtro_cst(txtcod.Text, 1)
                   
                End If

            End If

            If Me.Text = "Tela para alteração da IPI" Then
                carrega_grid_filtro_ipi(txtcod.Text, 1)
            End If

            If dgvdados.RowCount = 1 Then
                dgvdados.Focus()
            End If

        End If



        
    End Sub

    Private Sub txtdesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdesc.KeyPress
        If e.KeyChar = Chr(13) Then
            dgvdados.Rows.Clear()

            If e.KeyChar = Chr(13) Then
                dgvdados.Rows.Clear()

                If Me.Text = "Tela para alteração de CST PIS" Or Me.Text = "Tela para alteração de CST COFINS" Or Me.Text = "Tela para alteração de CST IPI" Then
                    carrega_grid_filtro_cofins(txtdesc.Text, 2)
                End If

                If Me.Text = "Tela para alteração de CFOP" Then
                    carrega_grid_filtro_cfop(txtdesc.Text, 2)
                End If

                If Me.Text = "Tela para alteração da CSOSN" Or Me.Text = "Tela para alteração da CST" Then
                    carrega_grid_filtro_cst(txtdesc.Text, 2)
                End If

                If Me.Text = "Tela para alteração da IPI" Then
                    carrega_grid_filtro_ipi(txtdesc.Text, 2)
                End If

                If dgvdados.RowCount = 1 Then
                    dgvdados.Focus()
                End If

            End If
        End If
    End Sub



    Private Sub dgvdados_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvdados.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
        End If
    End Sub

    Private Sub dgvdados_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvdados.KeyPress

        If e.KeyChar = Chr(13) Then

            If Me.Text = "Tela para alteração de CFOP" Then
                frmxml_nfe.txtcfop_item.Text = dgvdados.CurrentRow.Cells(0).Value
            End If

            If Me.Text = "Tela para alteração da CSOSN" Or Me.Text = "Tela para alteração da CST" Then
                frmxml_nfe.txtcst_item.Text = dgvdados.CurrentRow.Cells(0).Value
            End If

            If Me.Text = "Tela para alteração de CST PIS" Or Me.Text = "Tela para alteração de CST COFINS" Then
                frmxml_nfe.txtcstpis_item.Text = dgvdados.CurrentRow.Cells(0).Value
                frmxml_nfe.txtcstcofins_item.Text = dgvdados.CurrentRow.Cells(0).Value
                ' frmxml_nfe.txtaliqpis_item.Text = dgvdados.CurrentRow.Cells("aliq_pis").Value.ToString
                ' frmxml_nfe.txtaliqcofins_item.Text = dgvdados.CurrentRow.Cells("aliq_cofins").Value.ToString
            End If

            If Me.Text = "Tela para alteração da IPI" Then
                frmxml_nfe.txtcstipi_item.Text = dgvdados.CurrentRow.Cells(0).Value

            End If

           
            Me.Close()

        End If
    End Sub

    Private Sub txtcod_TextChanged(sender As Object, e As EventArgs) Handles txtcod.TextChanged

    End Sub

    Private Sub txtdesc_TextChanged(sender As Object, e As EventArgs) Handles txtdesc.TextChanged

    End Sub
End Class