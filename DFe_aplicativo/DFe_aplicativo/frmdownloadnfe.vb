
Imports System.Security.Cryptography.X509Certificates
Imports System.Xml
Imports System.Threading
Imports System.Text
Imports System.Drawing.Text
Imports System.IO
Imports DFe_aplicativo.C_WebService
Imports System.Xml.Linq
Imports System.Web

Public Class frmdownloadnfe

    Private Declare Function URLDownloadToFile Lib "urlmon" _
   Alias "URLDownloadToFileA" (ByVal pCaller As Integer, _
   ByVal szURL As String, ByVal szFileName As String, _
   ByVal dwReserved As Integer, ByVal lpfnCB As Integer) As Integer


    Dim campo_chave As String, campo_Captcha As String, btnConsultar As String, btndownload As String
    Dim valor As Integer
    Dim certificado As X509Certificate2
    Dim rsconsulta As New ADODB.Recordset
    Dim WebS As New C_WebService
    Dim retorevento As New RetRetorno
    Dim rssefaz As New ADODB.Recordset
    Public lote_evento As String
    Dim codevento As String
    Dim chave As String
    Dim verificar As Boolean
    Dim xmldoc As New System.Xml.XmlDocument()
    Dim nfe As String
    Dim xmlnsManager As New System.Xml.XmlNamespaceManager(xmldoc.NameTable)
    Dim parametro As String


    Public Function Base64ToImage(base64String As String) As Image
        ' Convert Base64 String to byte[]
        Dim imageBytes As Byte() = Convert.FromBase64String(base64String)
        Dim ms As New MemoryStream(imageBytes, 0, imageBytes.Length)

        ' Convert byte[] to Image
        ms.Write(imageBytes, 0, imageBytes.Length)
        Dim image__1 As Image = Image.FromStream(ms, True)
        Return image__1
    End Function

    Private Sub carrega_captcha()
        For Each ele As HtmlElement In WebBrowser1.Document.All

            Dim imgsrc As String = ele.GetAttribute("src")

            If imgsrc <> "" Then

                If imgsrc.Substring(0, 5) = "data:" Then

                    picCapture.Image = Base64ToImage(imgsrc.Remove(0, 22))

                    parametro = "1"

                End If

            End If
        Next
    End Sub

    Private Sub verifica()
        verificar = True

        If Not WebBrowser1.Document.GetElementById("ContentPlaceHolder1_bltMensagensErro") Is Nothing Then
            MsgBox(WebBrowser1.Document.GetElementById("ContentPlaceHolder1_bltMensagensErro").InnerText, MsgBoxStyle.Exclamation, "Portal Nacional !")
            bntconsulta.Enabled = True
            bntnovaconsulta.Enabled = False
            txtcaptcha.ReadOnly = False
            txtchave.ReadOnly = False
            txtcaptcha.Focus()
            verificar = False
            parametro = "3"
            Exit Sub
        End If

        If Not WebBrowser1.Document.GetElementById("ContentPlaceHolder1_lblResultadoConsulta") Is Nothing Then
            MsgBox(WebBrowser1.Document.GetElementById("ContentPlaceHolder1_lblResultadoConsulta").InnerText, MsgBoxStyle.Information, "Portal Nacional !")
            bntconsulta.Enabled = True
            bntnovaconsulta.Enabled = False
            picCapture.Image = Image.FromFile(Application.StartupPath + "\nfe.gif")
            txtcaptcha.ReadOnly = False
            txtchave.ReadOnly = False
            verificar = False
            parametro = "3"
            Exit Sub
        End If

        If Not WebBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_lblResultadoConsulta") Is Nothing Then
            MsgBox(WebBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_lblResultadoConsulta").InnerText, MsgBoxStyle.Information, "Portal Nacional !")
            bntconsulta.Enabled = True
            bntnovaconsulta.Enabled = False
            picCapture.Image = Image.FromFile(Application.StartupPath + "\nfe.gif")
            txtcaptcha.ReadOnly = False
            txtchave.ReadOnly = False
            verificar = False
            parametro = "3"
            Exit Sub
        End If

        busca_info_rfb_download()

        bntconsulta.Enabled = False
        bntnovaconsulta.Enabled = True
        picCapture.Image = Image.FromFile(Application.StartupPath + "\nfe.gif")
    End Sub

    Private Sub bntnovaconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntnovaconsulta.Click
        Try

            WebBrowser1.Navigate("http://www.nfe.fazenda.gov.br/portal/consulta.aspx?tipoConsulta=resumo&tipoConteudo=d09fwabTnLk=")
            parametro = "1"
            Label1.Visible = True
            Label1.Text = "Aguarde, Nova Download da NFe..."

            bntconsulta.Enabled = True
            bntnovaconsulta.Enabled = False
            txtcaptcha.ReadOnly = False
            txtchave.ReadOnly = False
            txtchave.Clear()

        Catch ex As Exception

        End Try

    End Sub


    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        WebBrowser1.Navigate("http://www.nfe.fazenda.gov.br/portal/consulta.aspx?tipoConsulta=resumo&tipoConteudo=d09fwabTnLk=")
        picnfe.Image = Image.FromFile(Application.StartupPath + "\nfe.gif")
        Label1.Text = "Aguarde, Recarregando imagem ..."
        bntconsulta.Enabled = True

    End Sub

    Private Sub frmdownloadnfe_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmdownloadnfe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' MsgBox(CertificadoDigital.nome, MsgBoxStyle.Information, "Nome do certificado Selecionado:")
        WebBrowser1.Navigate("http://www.nfe.fazenda.gov.br/portal/consulta.aspx?tipoConsulta=resumo&tipoConteudo=d09fwabTnLk=")
        picnfe.Image = Image.FromFile(Application.StartupPath + "\nfe.gif")
        parametro = "1"
        Label1.Text = "Aguarde, carregando captcha ..."

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        WebBrowser1.Document.Window.ScrollTo(60, 326)

        If parametro = "1" Then
            carrega_captcha()
            bntconsulta.Enabled = True
            LinkLabel1.Enabled = True
            bntnovaconsulta.Enabled = False
            txtcaptcha.ReadOnly = False
            txtchave.ReadOnly = False
            txtchave.Enabled = True
            txtcaptcha.Enabled = True
            txtcaptcha.Clear()
            txtchave.Focus()
        End If

        If parametro = "2" Then
            verifica()
            If chkvisualizar.Checked = False Then


                If verificar = True Then
                    WebBrowser1.Document.GetElementById(btndownload).InvokeMember("Click")

                    '    Dim Ret As Integer
                    '    Dim strURL As String
                    '     Dim strPath As String

                    '~~> URL of the Path
                    '  strURL = WebBrowser1.Url.ToString
                    '~~> Destination for the file
                    '  strPath = "C:\Users\Adenilson\Desktop\NFe\teste.xml"

                    '  Ret = URLDownloadToFile(0, strURL, strPath, 0, 0)

                    '  If Ret = 0 Then
                    '      '   MessageBox.Show("File suceesfully downloaded")
                    'Else
                    '   MessageBox.Show("Unable to download the file")
                    '   End If

                End If


            Else
                If verificar = True Then
                    MsgBox("NFe carregado !", MsgBoxStyle.Information, "Aviso !")
                    Me.Close()
                End If
            End If
        End If

        dgv1.Rows.Add(WebBrowser1.Url.ToString)
    End Sub

    Private Sub busca_info_rfb_download()


        With WebBrowser1

            Dim Objlabel As HtmlElementCollection = .Document.All 'Busca todas tags span


            For i = 0 To Objlabel.Count - 1

                If Objlabel.Item(i).Id <> "" Then

                    If Objlabel.Item(i).Id.Length > 21 Then

                        If Objlabel.Item(i).Id.Substring(Objlabel.Item(i).Id.Length - 11, 11) = "btnDownload" Then
                            btndownload = Objlabel.Item(i).Id
                        End If

                    End If

                End If


            Next
        End With

    End Sub

    Private Sub WebBrowser1_ProgressChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserProgressChangedEventArgs) Handles WebBrowser1.ProgressChanged

        Try
            If e.CurrentProgress <= 0 Then
                bar.Visible = False
                Label1.Visible = False
            Else
                bar.Visible = True
                bar.Maximum = e.MaximumProgress
                bar.Value = e.CurrentProgress
                Label1.Visible = True
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("http://www.nfe.fazenda.gov.br/portal/consulta.aspx?tipoConsulta=completa&tipoConteudo=XbSeqxE8pl8%3d")
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start("http://nfe.fazenda.mg.gov.br/consulta/Welcome.do;jsessionid=A0AC0CCA9AA713659554666234EC3EA7.nfe_node")
    End Sub

    Private Sub txtchave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Label1.Visible = True Then
            MsgBox("Aguarde o Carregamento da Imagem para Realizar o Download", MsgBoxStyle.Exclamation, "Aviso !")

        End If
    End Sub


    Private Sub bntconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntconsulta.Click

        If txtchave.Text = "                                                  " Then
            MsgBox("Informe a Chave de Acesso da NFe ?", MsgBoxStyle.Exclamation, "Aviso !")
            txtchave.Focus()
            Exit Sub
        End If

        If Len(txtchave.Text) < 44 Then
            MsgBox(" Cheve de Acesso da NFe Invalido ! ", MsgBoxStyle.Exclamation, "Aviso !")
            txtchave.Focus()
            Exit Sub
        End If


        chave = txtchave.Text.Replace(" ", "")
        If Not validachavenfe(chave) Then
            MsgBox("O Número da Chave de Acesso é inválida! ", MsgBoxStyle.Critical, "SEFAZ SP !")
            txtchave.Focus()
            Exit Sub
        End If

        If txtcaptcha.Text = "" Then
            MsgBox("Informe o Código da Imagem ao lado ?", MsgBoxStyle.Exclamation, "Aviso !")
            txtcaptcha.Focus()
            Exit Sub
        End If

        verificar = False
        picerro.Visible = False
        busca_info_rfb()

        WebBrowser1.Document.GetElementById(campo_chave).InnerText = txtchave.Text.Replace(" ", "")
        WebBrowser1.Document.GetElementById(campo_Captcha).InnerText = txtcaptcha.Text
        WebBrowser1.Document.GetElementById(btnConsultar).InvokeMember("Click")

        bar.Visible = True

        Label1.Visible = True
        Label1.Text = "Aguarde, Download do arquivo XML da NF-e...."
        parametro = "2"
        bntconsulta.Enabled = False
        bntnovaconsulta.Enabled = False

    End Sub

    Private Sub busca_info_rfb()


        With WebBrowser1

            Dim Objlabel As HtmlElementCollection = .Document.All 'Busca todas tags span


            For i As Integer = 0 To Objlabel.Count - 1

                If Objlabel.Item(i).Id <> "" Then

                    If Objlabel.Item(i).Id.Length > 21 Then

                        If Objlabel.Item(i).Id.Substring(Objlabel.Item(i).Id.Length - 20, 20) = "txtChaveAcessoResumo" Then
                            campo_chave = Objlabel.Item(i).Id
                        End If

                        If Objlabel.Item(i).Id.Substring(Objlabel.Item(i).Id.Length - 10, 10) = "txtCaptcha" Then
                            campo_Captcha = Objlabel.Item(i).Id
                        End If

                        If Objlabel.Item(i).Id.Substring(Objlabel.Item(i).Id.Length - 12, 12) = "btnConsultar" Then
                            btnConsultar = Objlabel.Item(i).Id
                        End If

                    End If

                End If


            Next
        End With

    End Sub

    Private Function validachavenfe(ByVal chave As String)

        'Pausa para explicação
        'Dim Vetor(4) As Integer Define um array com 5 elementos iniciados com zero
        'Dim Vetor As Integer = new Integer(4) {} Define um array com 5 elementos iniciados com zero
        'Dim Vetor() As Integer = {1, 2, 3, 4, 5} Define um array com 5 elementos e atribui valores a cada elemento
        'Dim Vetor As Integer = new Integer(4) { 0, 1, 2, 3, 4} Define um array com 5 elementos e atribui valores a cada elemento
        'Redim Vetor(10) Redimensiona o array Vetor para 11 elementos
        'ReDim Preserve Vetor(10) Redimensiona o array Vetor para 11 elementos


        'Vetor que irá receber os dígitos da chave
        Dim Numero(42) As Integer

        'Vetor com o peso de cada um dos dígitos
        Dim pesos() As Integer = {4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2}

        Dim soma As Integer = 0

        Dim i As Integer

        Dim resultado1 As Integer

        'Atribuindo ao vetor cada valor da chave até o indice 43.

        For i = 0 To Numero.Length - 1
            Numero(i) = CInt(chave.Substring(i, 1))
        Next

        'Multiplica os valors da chave pelo seu peso e soma o resultado.

        For i = 0 To Numero.Length - 1
            soma = soma + (Numero(i) * pesos(i))
        Next

        'Efetua o resto da divisão

        soma = soma - (11 * (Int(soma / 11)))

        'Como regra da validação se o resultado for 0 ou 1 o digito verificador tem que ser igual a 0

        If soma = 0 Or soma = 1 Then
            resultado1 = 0
        Else
            'Se for maior que 1 tem que diminuir de 11;
            resultado1 = 11 - soma
        End If


        'Verifica se o resultado é igual ao ultimo digito e retorna true ou false

        If resultado1 = CInt(chave.Substring(43, 1)) Then
            Return True
        Else
            Return False
        End If

        'Fim da Função
    End Function




End Class