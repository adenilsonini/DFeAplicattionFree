Public Class frmParCarga
    Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config.ini")
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles btncaminho.Click

        fbd1.Description = "Selecione uma pasta para realizar o XML NFe"
        fbd1.RootFolder = Environment.SpecialFolder.MyComputer
        fbd1.ShowNewFolderButton = True

        'Exibe a caixa de diálogo
        If fbd1.ShowDialog = Windows.Forms.DialogResult.OK Then

            'Exibe a pasta selecionada
            txtcaminho.Text = fbd1.SelectedPath

            arquivoIni.Write("caminho", fbd1.SelectedPath, "PATH_CARGA")
        End If
    End Sub

    Private Sub chklocal_CheckedChanged(sender As Object, e As EventArgs) Handles chklocal.CheckedChanged
        If chklocal.Checked Then
            btncaminho.Enabled = True
        Else
            btncaminho.Enabled = False
            arquivoIni.Write("caminho", "", "PATH_CARGA")
        End If

        arquivoIni.Write("local", chklocal.Checked, "PATH_CARGA")
    End Sub

    Private Sub carregar()
        If arquivoIni.KeyExists("caminho", "PATH_CARGA") = False Then
            arquivoIni.Write("caminho", "", "PATH_CARGA")
        End If
        If arquivoIni.KeyExists("local", "PATH_CARGA") = False Then
            arquivoIni.Write("local", "false", "PATH_CARGA")
        End If

        txtcaminho.Text = arquivoIni.Read("caminho", "PATH_CARGA")
        chklocal.Checked = arquivoIni.Read("local", "PATH_CARGA")
    End Sub

    Private Sub frmParCarga_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carregar()
    End Sub
End Class