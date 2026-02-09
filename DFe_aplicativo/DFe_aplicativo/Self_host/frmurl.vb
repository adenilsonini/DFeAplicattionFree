Imports System.Windows.Forms
Imports System.Data.SQLite
Imports System.Text

Public Class frmurl
    Dim dr As SQLiteDataReader
    Private Sub limpar_url()
        txturl_aut.Clear()
        txturl_ret_aut.Clear()
        txturl_cons_nf.Clear()
        txturl_evento.Clear()
        txturl_cad.Clear()
        txturl_inut.Clear()
        txturl_status.Clear()
    End Sub


    Private Sub salvar()

        
        If txtversao.Text = "" Then
            MsgBox("Informe a Versão da NF ?", MsgBoxStyle.Exclamation, "Aviso !")
            txtversao.Focus()
            Exit Sub
        End If

        If cboambiente.Text = "" Then
            MsgBox("Informe o Ambiente da NF ?", MsgBoxStyle.Exclamation, "Aviso !")
            cboambiente.Focus()
            Exit Sub
        End If
        If cbomodelo.Text = "" Then
            MsgBox("Informe o Modelo da NF ?", MsgBoxStyle.Exclamation, "Aviso !")
            cbomodelo.Focus()
            Exit Sub
        End If

        If cbomodelo.Text = "" Then
            MsgBox("Informe a SEFAZ Autorizadora ?", MsgBoxStyle.Exclamation, "Aviso !")
            cbosefaz_aut.Focus()
            Exit Sub
        End If


        If chkser_aut.Checked = True Then

            If txturl_aut.Text = "" Then
                MsgBox("Informe a URL de Autorização ?", MsgBoxStyle.Exclamation, "Aviso !")
                txturl_aut.Focus()
                Exit Sub
            End If

            If Strings.UCase(txturl_aut.Text.Substring(txturl_aut.Text.Length - txtser_aut.Text.Length, txtser_aut.Text.Length)) <> Strings.UCase(txtser_aut.Text) Then
                If MessageBox.Show("A URL esta Diferente do Serviço Autorização ? ", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    txturl_aut.Focus()
                    Exit Sub
                End If
            End If

            If salvar_servico(txtser_aut.Text, txturl_aut.Text) = False Then
                MsgBox("O Serviço Autorização não Foi Salvo ?", MsgBoxStyle.Exclamation, "Aviso !")
            End If
        End If





        If chkser_ret_aut.Checked = True Then

            If txturl_ret_aut.Text = "" Then
                MsgBox("Informe a URL de Retorno Autorização ?", MsgBoxStyle.Exclamation, "Aviso !")
                txturl_ret_aut.Focus()
                Exit Sub
            End If

            If Strings.UCase(txturl_ret_aut.Text.Substring(txturl_ret_aut.Text.Length - txtser_ret_aut.Text.Length, txtser_ret_aut.Text.Length)) <> Strings.UCase(txtser_ret_aut.Text) Then
                If MessageBox.Show("A URL esta Diferente do Serviço Ret Autorização ? ", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    txturl_ret_aut.Focus()
                    Exit Sub
                End If
            End If

           If salvar_servico(txtser_ret_aut.Text, txturl_ret_aut.Text) = False Then
                MsgBox("O Serviço Ret Autorização não Foi Salvo ?", MsgBoxStyle.Exclamation, "Aviso !")
            End If

        End If



        If chkser_cons_nf.Checked = True Then

            If txturl_cons_nf.Text = "" Then
                MsgBox("Informe a URL Consulta Protocolo NF ?", MsgBoxStyle.Exclamation, "Aviso !")
                txturl_cons_nf.Focus()
                Exit Sub
            End If


            If Strings.UCase(txturl_cons_nf.Text.Substring(txturl_cons_nf.Text.Length - txtser_consultanf.Text.Length, txtser_consultanf.Text.Length)) <> Strings.UCase(txtser_consultanf.Text) Then
                If MessageBox.Show("A URL esta Diferente do Serviço Consulta NF ? ", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    txturl_cons_nf.Focus()
                    Exit Sub
                End If
            End If

            If salvar_servico(txtser_consultanf.Text, txturl_cons_nf.Text) = False Then
                MsgBox("O Serviço Consulta NF não Foi Salvo ?", MsgBoxStyle.Exclamation, "Aviso !")
            End If
        End If




        If chkser_evento.Checked = True Then

            If txturl_evento.Text = "" Then
                MsgBox("Informe a URL do Evento NF ?", MsgBoxStyle.Exclamation, "Aviso !")
                txturl_evento.Focus()
                Exit Sub
            End If


            If Strings.UCase(txturl_evento.Text.Substring(txturl_evento.Text.Length - txtser_evento.Text.Length, txtser_evento.Text.Length)) <> Strings.UCase(txtser_evento.Text) Then
                If MessageBox.Show("A URL esta Diferente do Serviço Evento ? ", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    txturl_evento.Focus()
                    Exit Sub
                End If
            End If
       
            If salvar_servico(txtser_evento.Text, txturl_evento.Text) = False Then
                MsgBox("O Serviço evento NF não Foi Salvo ?", MsgBoxStyle.Exclamation, "Aviso !")
            End If

        End If




        If chkser_cad.Checked = True Then

            If txturl_cad.Text = "" Then
                MsgBox("Informe a URL para Consulta Cadastro ?", MsgBoxStyle.Exclamation, "Aviso !")
                txturl_cad.Focus()
                Exit Sub
            End If

            If Strings.UCase(txturl_cad.Text.Substring(txturl_cad.Text.Length - txtser_cad.Text.Length, txtser_cad.Text.Length)) <> Strings.UCase(txtser_cad.Text) Then
                If MessageBox.Show("A URL esta Diferente do Serviço Consulta Cadastro ? ", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    txturl_cad.Focus()
                    Exit Sub
                End If
            End If

            If salvar_servico(txtser_cad.Text, txturl_cad.Text) = False Then
                MsgBox("O Serviço Consulta Cadastro não Foi Salvo ?", MsgBoxStyle.Exclamation, "Aviso !")
            End If
        End If





        If chkser_inut.Checked = True Then

            If txturl_inut.Text = "" Then
                MsgBox("Informe a URL de Inutilização da NF ?", MsgBoxStyle.Exclamation, "Aviso !")
                txturl_inut.Focus()
                Exit Sub
            End If

            If Strings.UCase(txturl_inut.Text.Substring(txturl_inut.Text.Length - txtser_inut.Text.Length, txtser_inut.Text.Length)) <> Strings.UCase(txtser_inut.Text) Then
                If MessageBox.Show("A URL esta Diferente do Serviço Inutilização ? ", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    txturl_inut.Focus()
                    Exit Sub
                End If
            End If

            If salvar_servico(txtser_inut.Text, txturl_inut.Text) = False Then
                MsgBox("O Serviço Inutilizacao NF não Foi Salvo ?", MsgBoxStyle.Exclamation, "Aviso !")
            End If
        End If




        If chkser_status.Checked = True Then

            If txturl_status.Text = "" Then
                MsgBox("Informe a URL de Consulta Status ?", MsgBoxStyle.Exclamation, "Aviso !")
                txturl_status.Focus()
                Exit Sub
            End If

            If Strings.UCase(txturl_status.Text.Substring(txturl_status.Text.Length - txtser_status.Text.Length, txtser_status.Text.Length)) <> Strings.UCase(txtser_status.Text) Then
                If MessageBox.Show("A URL esta Diferente do Serviço Status ? ", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    txturl_status.Focus()
                    Exit Sub
                End If
            End If

            If salvar_servico(txtser_status.Text, txturl_status.Text) = False Then
                MsgBox("O Serviço Consulta Status Webservice não Foi Salvo ?", MsgBoxStyle.Exclamation, "Aviso !")
            End If
        End If



        MsgBox("Informações salvas com Sucesso !", MsgBoxStyle.Information, "Atenção")
        limpar_url()


    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        limpar_url()
        MsgBox("Comando executado !", MsgBoxStyle.Information, "Atenção")
    End Sub

    Private Sub bntsalvar_Click(sender As Object, e As EventArgs) Handles bntsalvar.Click

        salvar()

    End Sub

    Private Function salvar_servico(ByVal servico As String, url As String)

        '     Try

        Dim ret As Integer = 0
        Dim stringBuilder As StringBuilder = New StringBuilder()
        stringBuilder.Append("Select * from url ")

        stringBuilder.Append("where Servico = '" & servico & "'")


        conectar_sqlite()

        Dim SQLcommand As SQLiteCommand

        SQLcommand = Conn.CreateCommand

        SQLcommand.CommandText = stringBuilder.ToString

        dr = SQLcommand.ExecuteReader()


        While (dr.Read())
            ret += 1
        End While

        dr.Close()
        SQLcommand.Dispose()
        Conn.Close()


        If ret <> 1 Then


            conectar_sqlite()
            Dim insertSQL As SQLiteCommand = New SQLiteCommand("INSERT INTO url (Ambiente, Modelo, Versao, Servico, Url, tipo, SefazAut) VALUES (?,?,?,?,?,?,?)", Conn)

            insertSQL.Parameters.Add("@Ambiente", SqlDbType.VarChar).Value = cboambiente.Text.Substring(0, 1)
            insertSQL.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = cbomodelo.Text.Substring(0, 2)
            insertSQL.Parameters.Add("@Versao", SqlDbType.VarChar).Value = txtversao.Text
            insertSQL.Parameters.Add("@Servico", SqlDbType.VarChar).Value = servico
            insertSQL.Parameters.Add("@Url", SqlDbType.VarChar).Value = url.Trim
            insertSQL.Parameters.Add("@Utipo", SqlDbType.VarChar).Value = "S"
            insertSQL.Parameters.Add("@SefazAut", SqlDbType.VarChar).Value = cbosefaz_aut.Text

            insertSQL.ExecuteNonQuery()

            Conn.Close()

        End If

        Return True

        '' Catch ex As Exception
        '     Return False
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Modulo: Cadastro Serviço")
        ' End Try

    End Function

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbosefaz_aut.SelectedIndexChanged

    End Sub

    Private Sub CARREGAR_SEAUT()
        Dim stringBuilder As StringBuilder = New StringBuilder()
        stringBuilder.Append("Select * from SefazUFs ")

        ' stringBuilder.Append("where Servico = '" & servico & "'")


        conectar_sqlite()

        Dim SQLcommand As SQLiteCommand

        SQLcommand = Conn.CreateCommand

        SQLcommand.CommandText = stringBuilder.ToString

        dr = SQLcommand.ExecuteReader()


        While (dr.Read())
            cbosefaz_aut.Items.Add(dr("SefazAut"))
        End While

        dr.Close()
        SQLcommand.Dispose()
        Conn.Close()
    End Sub

    Private Sub frmurl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CARREGAR_SEAUT()
    End Sub
End Class