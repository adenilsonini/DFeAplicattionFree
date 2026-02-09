Imports System.Security.Cryptography.X509Certificates
Imports MySql.Data.MySqlClient
Imports System.Text

Public Class frminfocertificado

    Public Sub carregar(ByVal cert As X509Certificate2)

        txtdatavenc.Text = cert.NotAfter.ToString
        txtdataemi.Text = cert.NotBefore.ToString
        txtrazao.Text = cert.SubjectName.Name

        removecarrazao()
        mskcnpj.Text = ExtrairCNPJ(cert)
        If mskcnpj.Text = "" Then
            mskcnpj.Text = ExtrairCPF(cert)
        End If

        '' criptografa()

        ' Aplicação no seu código
        Dim dictionary As Dictionary(Of String, String) = dados_cert_Dictionary(cert)

        txtemail.Text = GetValor(dictionary, "e-mail")
        txtnomeresp.Text = GetValor(dictionary, "nome")
        txtnomeresp.Text = GetValor(dictionary, "razao")
        mskcpfresp.Text = GetValor(dictionary, "cpf")
        mskdata.Text = GetValor(dictionary, "data_nascimento")
        txtrg.Text = GetValor(dictionary, "rg")


    End Sub

    Private Function GetValor(dict As Dictionary(Of String, String), chave As String) As String
        Dim valor As String = ""
        If dict.TryGetValue(chave, valor) Then
            Return valor
        End If
        Return "" ' Retorna string vazia se não encontrar
    End Function



    Public Sub removecarrazao()
        txtrazao.Text = txtrazao.Text.Remove(0, 3)
        For i As Integer = 0 To txtrazao.Text.Length - 1

            If txtrazao.Text.Substring(i, 1) = "," Then
                txtrazao.Text = txtrazao.Text.Remove(i, txtrazao.Text.Length - i)
                Exit For
            End If
        Next
    End Sub

    Private Sub criptografa()
        txtnomeresp.PasswordChar = "@"
        mskcpfresp.PasswordChar = "@"
        mskdata.PasswordChar = "@"
        txtrg.PasswordChar = "@"
        txtorg.PasswordChar = "@"
    End Sub

    Private Sub descriptografa()
        mskcpfresp.PasswordChar = ""
        txtnomeresp.PasswordChar = ""
        mskdata.PasswordChar = ""
        If txtrg.Text.Length >= 1 Then
            If txtrg.Text.Substring(0, 1) = "0" Then
                txtrg.Clear()
            End If
        End If
        txtrg.PasswordChar = ""
        txtorg.PasswordChar = ""
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If psenha.Visible = False Then
            psenha.Visible = True
            txtsenha.Focus()
        Else
            psenha.Visible = False
        End If
    End Sub

    Private Sub txtsenha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsenha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtsenha.Text <> "" Then

                If txtsenha.Text = mskcnpj.Text Then
                    descriptografa()
                    psenha.Visible = False
                    txtsenha.Clear()
                    lblsenha.Visible = True
                Else
                    MsgBox("Senha Invalida !!!", MsgBoxStyle.Exclamation, "Aviso !")
                End If
            End If
        End If
    End Sub


    Private Sub txtsenha_TextChanged(sender As Object, e As EventArgs) Handles txtsenha.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        ' MessageBox.Show(ChrW(Convert.ToInt32("33", 16)))
        MessageBox.Show(Chr(CInt("&H" & "31")))
        '  MessageBox.Show(Chr(CInt("&H48")))
    End Sub

    Private Sub frminfocertificado_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        lblsenha.Visible = False
    End Sub


    Private Sub frminfocertificado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        frmcert.par = True
        frmcert.ShowDialog()
    End Sub

    Private Sub lblsenha_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblsenha.LinkClicked
        Dim stringBuilder As StringBuilder = New StringBuilder()
        stringBuilder.Append("Select * from cert ")

        stringBuilder.Append("where cnpj = '" & mskcnpj.Text & "'")


        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand

        SQLcommand = oConn.CreateCommand

        SQLcommand.CommandText = stringBuilder.ToString

        dr = SQLcommand.ExecuteReader()


        While (dr.Read())
            MsgBox(Crypto.Decrypt2(dr("senha")), MsgBoxStyle.Information, "Senha do Certificado !")
        End While
    End Sub
End Class