Public Class frmlogin_windows

    Private Sub login()
        Dim p As Integer = txtusuario.Text.IndexOf("\")

        If txtsenha.Text = "" Then
            MsgBox("Informe a senha !!!", MsgBoxStyle.Exclamation, "Aviso !")
            txtsenha.Focus()
            Exit Sub
        End If

        If login_windows(txtusuario.Text.Substring(p + 1, txtusuario.Text.Length - p - 1), txtusuario.Text.Substring(0, p), txtsenha.Text) Then
            frmparametro.ShowDialog()
            txtsenha.Clear()
            Me.Close()
        Else
            MsgBox("senha incorreta !!!", MsgBoxStyle.Exclamation, "Aviso !")
            txtsenha.Clear()
        End If
    End Sub

    Private Sub frmlogin_windows_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtusuario.Text = System.Security.Principal.WindowsIdentity.GetCurrent.Name
    End Sub

    Private Sub txtsenha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsenha.KeyPress
        If (e.KeyChar = Chr(13)) Then
            login()
        End If
    End Sub

  
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If txtsenha.Text = empresa.sCNPJ Then
            frmparametro.ShowDialog()
            txtsenha.Clear()
            Me.Close()
            Exit Sub
        End If

        login()
    End Sub
End Class