Public Class frmportalnfe
    Public tipo As String
    Public chave As String
    Private Sub frmportalnfe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        muda_versao_webbroser()
        ' WebBrowser1.Navigate("http://www.nfe.fazenda.gov.br/portal/consultaRecaptcha.aspx?tipoConsulta=completa&tipoConteudo=XbSeqxE8pl8=")
        WebBrowser1.Navigate("http://www.nfe.fazenda.gov.br/portal/consultaRecaptcha.aspx?tipoConteudo=XbSeqxE8pl8=&tipoConsulta=completa&nfe=" & chave & "&")

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Me.Text = WebBrowser1.DocumentTitle()

        If tipo = "Consulta" Then
            ' WebBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_txtChaveAcessoCompleta").InnerText = chave
            ' WebBrowser1.Document.GetElementById("ctl00$ContentPlaceHolder1$btnConsultar").InvokeMember("Click")
            ' tipo = "ok"
            ' WebBrowser1.ScriptErrorsSuppressed = True
        End If

        If Not WebBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_bltMensagensErro") Is Nothing Then
            MsgBox(WebBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_bltMensagensErro").InnerText, MsgBoxStyle.Exclamation, "Portal Nacional NFe !")
            WebBrowser1.ScriptErrorsSuppressed = True
        End If

        If Not WebBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_btnVoltar") Is Nothing Then
            WebBrowser1.ScriptErrorsSuppressed = False
        End If
    End Sub

    Private Sub muda_versao_webbroser()
        Dim appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName)
        Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", appName, 11000, Microsoft.Win32.RegistryValueKind.DWord)
    End Sub
End Class