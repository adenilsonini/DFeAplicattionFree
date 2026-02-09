Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class frmnat
    Dim rs As New ADODB.Recordset
    Dim tipo_nat As String, tp As String
    Private Sub frmnat_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmnat_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub frmnat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carrega_cad()
        carrega_cfop()
    End Sub

    Public Sub carrega_cad()
        dgvnat.Rows.Clear()

        conectar_mysqlDFe()

        Dim SQLcommand4 As MySqlCommand
        SQLcommand4 = oConn.CreateCommand
        SQLcommand4.CommandText = "SELECT * FROM natureza_operacao ORDER BY codigo ASC"
        '  dr = SQLcommand4.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand4.ExecuteReader

            While reader.Read
                dgvnat.Rows.Add(reader("descricao"), carrega_opt(reader("Tipo_nat")), reader("codigo"))
            End While

        End Using
       
    End Sub

    Public Sub carrega_cfop()


        cbocfop_d1.Items.Clear()
        cbocfop_d2.Items.Clear()
        cbocfop_f1.Items.Clear()
        cbocfop_f2.Items.Clear()

        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "SELECT * FROM cfop ORDER BY codigo ASC"
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())

            If chksaida.Checked = True Then
                If dr("codigo").ToString.Substring(0, 1) = "5" Then
                    cbocfop_d1.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))
                    cbocfop_d2.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))
                End If

                If dr("codigo").Substring(0, 1) = "6" Then
                    cbocfop_f1.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))
                    cbocfop_f2.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))
                End If

            Else

                If dr("codigo").Substring(0, 1) = "1" Then
                    cbocfop_d1.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))
                    cbocfop_d2.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))
                End If

                If dr("codigo").Substring(0, 1) = "2" Then
                    cbocfop_f1.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))
                    cbocfop_f2.Items.Add(New MTGCComboBoxItem(dr("codigo"), dr("descricao")))
                End If

            End If

           
        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()

    End Sub
   

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        Panel1.Enabled = True
        Panel4.Enabled = True

        txtnat.Focus()
        limpar()

        txtcod.Text = ProximoCodigo("natureza_operacao", "codigo")
    End Sub

    Private Sub optoutros_Click(sender As Object, e As EventArgs) Handles optoutros.Click
        If optoutros.Checked = True Then
            tipo_nat = "o"
        End If
    End Sub

    Private Sub optdevolucao_Click(sender As Object, e As EventArgs) Handles optdevolucao.Click
        If optdevolucao.Checked = True Then
            tipo_nat = "d"
        End If
    End Sub

    Private Sub optvenda_Click(sender As Object, e As EventArgs) Handles optvenda.Click
        If optvenda.Checked = True Then
            tipo_nat = "v"
        End If
    End Sub

    Private Sub optcomplemento_Click(sender As Object, e As EventArgs) Handles optcomplemento.Click
        If optcomplemento.Checked = True Then
            tipo_nat = "nc"
        End If
    End Sub

    Private Sub optajuste_Click(sender As Object, e As EventArgs) Handles optajuste.Click
        If optajuste.Checked = True Then
            tipo_nat = "a"
        End If
    End Sub

    Private Sub optbonificacao_Click(sender As Object, e As EventArgs) Handles optbonificacao.Click
        If optbonificacao.Checked = True Then
            tipo_nat = "b"
        End If
    End Sub

    Private Sub optcupom_Click(sender As Object, e As EventArgs) Handles optcupom.Click
        If optcupom.Checked = True Then
            tipo_nat = "c"
        End If
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        If txtnat.Text = "" Then
            MsgBox("Informe a Descrição da Natureza !", MsgBoxStyle.Exclamation, "Aviso !")
            txtnat.Focus()
            Exit Sub
        End If

        If optvenda.Checked = True Or optdevolucao.Checked = True Then
            If cbocfop_d1.Text = "" Then
                MsgBox("Informe o CFOP de ICMS dentro do estado !", MsgBoxStyle.Exclamation, "Aviso !")
                cbocfop_d1.Focus()
                Exit Sub
            End If
            If cbocfop_d2.Text = "" Then
                MsgBox("Informe o CFOP de ICMS/ST dentro do estado !", MsgBoxStyle.Exclamation, "Aviso !")
                cbocfop_d1.Focus()
                Exit Sub
            End If

            If cbocfop_f1.Text = "" Then
                MsgBox("Informe o CFOP de ICMS Fora do estado !", MsgBoxStyle.Exclamation, "Aviso !")
                cbocfop_f1.Focus()
                Exit Sub
            End If
            If cbocfop_f2.Text = "" Then
                MsgBox("Informe o CFOP de ICMS/ST Fora do estado !", MsgBoxStyle.Exclamation, "Aviso !")
                cbocfop_f2.Focus()
                Exit Sub
            End If
        End If


        If optbonificacao.Checked = False And optcomplemento.Checked = False And optentrada.Checked = False And optajuste.Checked = False And optoutros.Checked = False And optcupom.Checked = False And optvenda.Checked = False And optdevolucao.Checked = False Then
            MsgBox("Marque um das Caixa de Opções (Obrigatorio) !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        If optbonificacao.Checked = True Or optcomplemento.Checked = True Or optajuste.Checked = True Or optoutros.Checked = True Or optcupom.Checked = True Then
            If cbocfop_d1.Text = "" Then
                MsgBox("Informe o CFOP de ICMS dentro do estado !", MsgBoxStyle.Exclamation, "Aviso !")
                cbocfop_d1.Focus()
                Exit Sub
            End If

            If cbocfop_f1.Text = "" Then
                MsgBox("Informe o CFOP de ICMS Fora do estado !", MsgBoxStyle.Exclamation, "Aviso !")
                cbocfop_f1.Focus()
                Exit Sub
            End If
        End If

        Dim ret As Integer = verificar_regexiste("Select * from natureza_operacao where codigo = '" & txtcod.Text & "'")
        Dim sql As String

        If ret = 0 Then
            sql = "INSERT INTO natureza_operacao (codigo, descricao, Tipo_nat, cfop_d1, cfop_d2, cfop_f1, cfop_f2, Calc_trib, nfe_saida) VALUES (@codigo, @descricao, @Tipo_nat, @cfop_d1, @cfop_d2, @cfop_f1, @cfop_f2, @Calc_trib, @nfe_saida)"
        Else
            sql = "UPDATE natureza_operacao SET codigo = @codigo, descricao = @descricao , Tipo_nat = @Tipo_nat, cfop_d1 = @cfop_d1, cfop_d2 = @cfop_d2, cfop_f1 = @cfop_f1, cfop_f2 = @cfop_f2, Calc_trib = @Calc_trib, nfe_saida = @nfe_saida where codigo = '" & txtcod.Text & "'"
        End If

         conectar_mysqlDFe()
        Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)

        insertSQL.Parameters.Add(New MySqlParameter("codigo", txtcod.Text))
        insertSQL.Parameters.Add(New MySqlParameter("descricao", txtnat.Text))
        insertSQL.Parameters.Add(New MySqlParameter("Tipo_nat", tipo_nat))
        insertSQL.Parameters.Add(New MySqlParameter("cfop_d1", cbocfop_d1.Text))
        insertSQL.Parameters.Add(New MySqlParameter("cfop_d2", cbocfop_d2.Text))
        insertSQL.Parameters.Add(New MySqlParameter("cfop_f1", cbocfop_f1.Text))
        insertSQL.Parameters.Add(New MySqlParameter("cfop_f2", cbocfop_f2.Text))
        insertSQL.Parameters.Add(New MySqlParameter("Calc_trib", chktrib.Checked))
        insertSQL.Parameters.Add(New MySqlParameter("nfe_saida", chksaida.Checked))

        insertSQL.ExecuteNonQuery()
        oConn.Close()

        If sql.Substring(0, 6) = "INSERT" Then
            MsgBox("Cadastra Salvo com Sucesso !", MsgBoxStyle.Information, "Aviso !")
            limpar()
            Panel1.Enabled = False
            carrega_cad()
        Else
            MsgBox("Cadastra Alterado com Sucesso !", MsgBoxStyle.Information, "Aviso !")
            carrega_cad()
        End If
    End Sub

  
    Private Sub dgvnat_Click(sender As Object, e As EventArgs) Handles dgvnat.Click
        If dgvnat.Rows.Count <> 0 Then

            conectar_mysqlDFe()

            Dim SQLcommand As MySqlCommand
            SQLcommand = oConn.CreateCommand
            SQLcommand.CommandText = "select * from natureza_operacao where Codigo = '" & dgvnat.CurrentRow.Cells("cod").Value & "'"
            dr = SQLcommand.ExecuteReader()

            While (dr.Read())
                txtcod.Text = dr("codigo")
                txtnat.Text = dr("Descricao")
                tipo_nat = dr("Tipo_nat")
                cbocfop_d1.Text = dr("cfop_d1")
                cbocfop_d2.Text = dr("cfop_d2")
                cbocfop_f1.Text = dr("cfop_f1")
                cbocfop_f2.Text = dr("cfop_f2")
                chktrib.Checked = dr("Calc_trib")
                chksaida.Checked = dr("nfe_saida")
            End While

            dr.Close()
            SQLcommand.Dispose()
            oConn.Close()

           
            Panel4.Enabled = True
            carrega_opt(dgvnat.CurrentRow.Cells("tipo").Value)
            Panel1.Enabled = True


        End If

    End Sub

    Private Sub limpar()
        txtcod.Clear()
        txtnat.Clear()
        cbocfop_d1.Text = ""
        cbocfop_d2.Text = ""
        cbocfop_f1.Text = ""
        cbocfop_f2.Text = ""
        optajuste.Checked = False
        optbonificacao.Checked = False
        optcomplemento.Checked = False
        optvenda.Checked = False
        optdevolucao.Checked = False
        optoutros.Checked = False
        optcupom.Checked = False
        chktrib.Checked = False
        chksaida.Checked = True
    End Sub
    Private Function carrega_opt(ByVal valor As String) As String

        If valor = "v" Or valor = "Venda" Then
            optvenda.Checked = True
            tp = "Venda"
        End If

        If valor = "d" Or valor = "Devolucao" Then
            optdevolucao.Checked = True
            tp = "Devolucao"
        End If

        If valor = "nc" Or valor = "Complemento" Then
            optcomplemento.Checked = True
            tp = "Complemento"
        End If

        If valor = "a" Or valor = "Ajuste" Then
            optajuste.Checked = True
            tp = "Ajuste"
        End If

        If valor = "o" Or valor = "Outros" Then
            optoutros.Checked = True
            tp = "Outros"
        End If

        If valor = "b" Or valor = "Bonificacao" Then
            optbonificacao.Checked = True
            tp = "Bonificacao"
        End If

        If valor = "c" Or valor = "Cobertura Cupom" Then
            optcupom.Checked = True
            tp = "Cobertura Cupom"
        End If

        If valor = "e" Or valor = "NFe entrada" Then
            optentrada.Checked = True
            tp = "NFe entrada"
        End If

        Return tp
    End Function


    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If MessageBox.Show("Deseja Realmente excluir a Natureza: " & txtnat.Text, "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Dim ret As Boolean = executa_query("delete from natureza_operacao where codigo = '" & txtcod.Text & "'")

            If ret = True Then
                MsgBox("Natureza Excluida com Sucesso !", MsgBoxStyle.Information, "Aviso !")
                limpar()
                Panel1.Enabled = False
                carrega_cad()
            Else
                MsgBox("Ocorreu um erro na execução do comando !", MsgBoxStyle.Exclamation, "Aviso !")
            End If

        End If
    End Sub


    Private Sub chksaida_Click(sender As Object, e As EventArgs) Handles chksaida.Click
        carrega_cfop()
    End Sub

    Private Sub cbocfop_d1_Validated(sender As Object, e As EventArgs) Handles cbocfop_d1.Validated
        If cbocfop_d1.Text <> "" Then
            Dim verifica As Boolean = False
            For i As Integer = 0 To cbocfop_d1.Items.Count - 1

                If cbocfop_d1.Text = CType(cbocfop_d1.Items(i), MTGCComboBoxItem).Col1 Then
                    verifica = True
                End If

            Next

            If verifica = False Then
                MsgBox("O Valor digitado não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
                cbocfop_d1.Text = ""
                cbocfop_d1.Focus()
            End If

        End If
    End Sub

    Private Sub cbocfop_f2_Validated(sender As Object, e As EventArgs) Handles cbocfop_f2.Validated
        If cbocfop_f2.Text <> "" Then
            Dim verifica As Boolean = False
            For i As Integer = 0 To cbocfop_f2.Items.Count - 1

                If cbocfop_f2.Text = CType(cbocfop_f2.Items(i), MTGCComboBoxItem).Col1 Then
                    verifica = True
                End If

            Next

            If verifica = False Then
                MsgBox("O Valor digitado não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
                cbocfop_f2.Text = ""
                cbocfop_f2.Focus()
            End If

        End If
    End Sub

    Private Sub cbocfop_f1_Validated(sender As Object, e As EventArgs) Handles cbocfop_f1.Validated
        If cbocfop_f1.Text <> "" Then
            Dim verifica As Boolean = False
            For i As Integer = 0 To cbocfop_f1.Items.Count - 1

                If cbocfop_f1.Text = CType(cbocfop_f1.Items(i), MTGCComboBoxItem).Col1 Then
                    verifica = True
                End If

            Next

            If verifica = False Then
                MsgBox("O Valor digitado não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
                cbocfop_f1.Text = ""
                cbocfop_f1.Focus()
            End If

        End If
    End Sub

    Private Sub cbocfop_d2_Validated(sender As Object, e As EventArgs) Handles cbocfop_d2.Validated
        If cbocfop_d2.Text <> "" Then
            Dim verifica As Boolean = False
            For i As Integer = 0 To cbocfop_d2.Items.Count - 1

                If cbocfop_d2.Text = CType(cbocfop_d2.Items(i), MTGCComboBoxItem).Col1 Then
                    verifica = True
                End If

            Next

            If verifica = False Then
                MsgBox("O Valor digitado não é valido !", MsgBoxStyle.Exclamation, "Aviso !")
                cbocfop_d2.Text = ""
                cbocfop_d2.Focus()
            End If

        End If
    End Sub

    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub txtnat_LostFocus(sender As Object, e As EventArgs) Handles txtnat.LostFocus
        If txtnat.Text <> "" Then
            txtnat.Text = TirarAcento(txtnat.Text)
        End If
    End Sub

  
    Private Sub optentrada_CheckedChanged(sender As Object, e As EventArgs) Handles optentrada.CheckedChanged
        chksaida.Checked = False
        carrega_cfop()
    End Sub

    Private Sub optcupom_CheckedChanged(sender As Object, e As EventArgs) Handles optcupom.CheckedChanged

    End Sub

    Private Sub optentrada_Click(sender As Object, e As EventArgs) Handles optentrada.Click
        If optentrada.Checked = True Then
            tipo_nat = "e"
        End If
    End Sub

    Private Sub dgvnat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvnat.CellContentClick

    End Sub
End Class