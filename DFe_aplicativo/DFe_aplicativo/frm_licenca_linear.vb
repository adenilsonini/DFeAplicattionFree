Public Class frm_licenca_linear

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If mskcnpj.Text = "" Then
            MsgBox("Informe o CNPJ da Empresa ?", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        Dim dataatual As DateTime = Now
        Dim quantidadeDias As Integer = 30

        Dim hora As String = dataatual.ToString("hhmmss")
        Dim dateTime As DateTime = dataatual
        dateTime = dateTime.AddDays(CDbl(quantidadeDias))

        txtlicenca.Text = LinxOSLicenca.GerarChave(mskcnpj.Text, hora, dataatual.AddDays(CDbl(quantidadeDias)), dataatual, 5)

        ' Using connection As MySqlConnection = DBHelper.ConexaoBDMysql()
        'BaseModel.ExecutaQuery("update control set myControl = '" & licensa & "'", connection)
        ' End Using


        MsgBox("Licença gerado com Sucesso !", MsgBoxStyle.Information, "Aviso !")

    End Sub
End Class