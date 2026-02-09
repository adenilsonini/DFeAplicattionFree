Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmoperador

    Private Sub frmoperador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carrega_cad()
    End Sub


    Public Sub carrega_cad()
        dgvop.Rows.Clear()

        conectar_mysqlDFe()

        Dim SQLcommand4 As MySqlCommand
        SQLcommand4 = oConn.CreateCommand
        SQLcommand4.CommandText = "SELECT * FROM operador"
        '  dr = SQLcommand4.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand4.ExecuteReader

            While reader.Read
                dgvop.Rows.Add(reader("codigo_op"), reader("nome_op"))
            End While

        End Using

    End Sub

    Private Sub dgvop_Click(sender As Object, e As EventArgs) Handles dgvop.Click

        If dgvop.Rows.Count = 0 Then
            Exit Sub
        End If

        Dim SQLcommand4 As MySqlCommand
        SQLcommand4 = oConn.CreateCommand
        SQLcommand4.CommandText = "SELECT * FROM operador where codigo_op = '" & dgvop.CurrentRow.Cells(0).Value & "'"
        '  dr = SQLcommand4.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand4.ExecuteReader

            While reader.Read
                txtcod.Text = reader("codigo_op")
                txtnome.Text = reader("nome_op")
                txtsenha.Text = reader("senha_op")
                chksaidaop.Checked = reader("saida_op")
                chkentop.Checked = reader("entrada_op")
                chkcancitem.Checked = reader("canc_item")
                chkativo.Checked = reader("ativo")
            End While

        End Using

        Panel1.Enabled = True
    End Sub

    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If txtnome.Text = "" Then
            MsgBox("Informe o Nome do Operador ?", MsgBoxStyle.Exclamation, "Aviso !")
            txtnome.Focus()
            Exit Sub
        End If
        If txtsenha.Text = "" Then
            MsgBox("Informe a senha do Operador ?", MsgBoxStyle.Exclamation, "Aviso !")
            txtsenha.Focus()
            Exit Sub
        End If
        salvar()

    End Sub


    Private Sub salvar()
        If txtcod.Text = "Novo" Then
            txtcod.Text = ProximoCodigo("operador", "codigo_op")
        End If


        Dim ret As Integer = verificar_regexiste("Select * from operador where codigo_op = '" & txtcod.Text & "'")
        Dim sql As String

        If ret = 0 Then
            sql = "INSERT INTO operador (codigo_op, nome_op, senha_op, saida_op, entrada_op, canc_item, ativo) VALUES (@codigo_op, @nome_op, @senha_op, @saida_op, @entrada_op, @canc_item, ativo)"
        Else
            sql = "UPDATE operador SET codigo_op = @codigo_op, nome_op = @nome_op, senha_op = @senha_op, saida_op = @saida_op, entrada_op = @entrada_op, canc_item = @canc_item , ativo = @ativo where codigo_op = '" & txtcod.Text & "'"
        End If

        conectar_mysqlDFe()
        Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)

        insertSQL.Parameters.Add(New MySqlParameter("codigo_op", txtcod.Text))
        insertSQL.Parameters.Add(New MySqlParameter("nome_op", txtnome.Text))
        insertSQL.Parameters.Add(New MySqlParameter("senha_op", txtsenha.Text))
        insertSQL.Parameters.Add(New MySqlParameter("saida_op", chksaidaop.Checked))
        insertSQL.Parameters.Add(New MySqlParameter("entrada_op", chkentop.Checked))
        insertSQL.Parameters.Add(New MySqlParameter("canc_item", chkcancitem.Checked))
        insertSQL.Parameters.Add(New MySqlParameter("ativo", chkativo.Checked))

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


        Dim SQLcommand4 As MySqlCommand
        SQLcommand4 = oConn.CreateCommand
        SQLcommand4.CommandText = "SELECT * FROM operador where ativo = '1'"
        '  dr = SQLcommand4.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand4.ExecuteReader

            While reader.Read

                export_op(reader("codigo_op"), reader("nome_op"), reader("senha_op"), reader("saida_op"), reader("entrada_op"), reader("canc_item"))

            End While

        End Using


    End Sub

    Private Sub limpar()
        txtcod.Clear()
        txtnome.Clear()
        txtsenha.Clear()
    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        txtcod.Text = "Novo"
        limpar()
        Panel1.Enabled = True
        txtnome.Focus()
    End Sub

    Public Sub export_op(ByVal cod As String, ByVal nome As String, ByVal senha As String, ByVal saida As String, ByVal entrada As String, ByVal canc As String)

        If cod = "" Then
            Exit Sub
        End If
        Dim parametro As New Utilitarios

        Directory.CreateDirectory(parametro.Caminho_arq_export())

        Dim arquivo As String = parametro.Caminho_arq_export() & "\carga.cac"
        Dim sep As String = "|"



        Dim fluxoTexto As IO.StreamReader
        Dim myList As New ArrayList


        If IO.File.Exists(arquivo) Then
            fluxoTexto = New IO.StreamReader(arquivo)
            While fluxoTexto.Peek() > -1
                myList.Add(fluxoTexto.ReadLine())
            End While
            fluxoTexto.Close()
        End If

        File.Delete(arquivo)

        Using writer As StreamWriter = New StreamWriter(arquivo, True)
            For Each l In myList
                writer.WriteLine(l)
            Next

            writer.WriteLine("02" & sep & cod & sep & nome & sep & Crypto.Crip_licenca(senha) & sep & saida & sep & entrada & sep & canc)

        End Using
    End Sub
End Class