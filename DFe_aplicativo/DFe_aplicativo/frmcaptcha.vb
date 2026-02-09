Public Class frmcaptcha
    Public captcha As Boolean
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub txtcaptcha_TextChanged(sender As Object, e As EventArgs) Handles txtcaptcha.TextChanged
        If txtcaptcha.Text.Length = 6 Then
            FrmDfe.WebBrowser1.Document.GetElementById("ctl00$ContentPlaceHolder1$btnConsultar").InvokeMember("Click")
            Me.Close()
        End If
    End Sub

    Private Sub frmcaptcha_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

  
End Class