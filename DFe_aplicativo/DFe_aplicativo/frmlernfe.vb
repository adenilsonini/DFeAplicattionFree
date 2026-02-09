Imports System.Web
Imports System.Xml
Imports System.IO
Imports System.Xml.Linq
Public Class frmlernfe
    Dim chave As String
    Public consulta As Boolean = False
    ' Dim d As New BarcodeLib.Barcode()
    Dim origem As String
    Dim cst As String
    Dim verificar As Boolean
    Dim xmldoc As New System.Xml.XmlDocument()
    Dim nfe As String
    Dim xmlnsManager As New System.Xml.XmlNamespaceManager(xmldoc.NameTable)
    Dim parametro As String

    Private Sub frmlernfe_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = "Aguarde, carregando Imagem da RFB..."
        Label1.Visible = True
        WebBrowser1.Navigate("http://www.nfe.fazenda.gov.br/portal/consultaResumoCompletaAntiga.aspx?tipoConsulta=completa&tipoConteudo=XbSeqxE8pl8=")
        parametro = "0"

    End Sub

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

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

        If parametro = "0" Then
            carrega_captcha()
        End If

        If parametro = "1" Then
            bntconsulta.Enabled = True
            bntnovaconsulta.Enabled = False
            txtcaptcha.ReadOnly = False
            txtchave.ReadOnly = False
            txtchave.Enabled = True
            txtcaptcha.Enabled = True
            txtcaptcha.Clear()
            txtchave.Focus()
        End If

        If parametro = "2" Then
            picCapture.Visible = False
            txtinfonfe.Visible = True
            verifica()

            If verificar = True Then

                If consulta = True Then
                    '''''''''''''''''''''Rotina abaixo consulta chave de NFe entrada de devolucao'''''''''''''''''''''''''''''''''''''''''''
                    busca_ref_nfe()
                    consulta = False
                Else
                    '''''''''''''''''''''Rotina abaixo recarrega os dados da NFe'''''''''''''''''''''''''''''''''''''''''''
                    ' dados_Nfe()
                End If

                If lerINI(Application.StartupPath & "\config.ini", "FORMAPRECO", "carregapreco") = True Then
                    frmxml.Linkpreco.Visible = True
                End If

                Me.Close()

            End If
        End If

        WebBrowser1.Location = New System.Drawing.Point(-3, 5)
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

    Private Sub verifica()
        txtinfonfe.Text = "Validando Informações dos Campos..."
        verificar = True

        If Not WebBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_bltMensagensErro") Is Nothing Then
            MsgBox(WebBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_bltMensagensErro").InnerText, MsgBoxStyle.Exclamation, "Portal Nacional NFe !")
            txtinfonfe.Visible = False
            picCapture.Visible = True
            verificar = False
            txtcaptcha.Focus()
            bntconsulta.Enabled = True
            txtcaptcha.Clear()
            txtcaptcha.Focus()
        End If

        If Not WebBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_lblResultadoConsulta") Is Nothing Then
            MsgBox(WebBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_lblResultadoConsulta").InnerText, MsgBoxStyle.Information, "Portal Nacional NFe !")
            txtinfonfe.Visible = False
            verificar = False
            picCapture.Visible = True
            txtcaptcha.Focus()
            bntconsulta.Enabled = True
            txtcaptcha.Clear()
            txtcaptcha.Focus()
        End If
        Label1.Text = "Aguarde, Carregando os dados da NF-e...."
    End Sub

    Private Sub bntconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntconsulta.Click
        If txtcaptcha.Text = "" Then
            MsgBox("Informe o Código da Imagem ao lado ?", MsgBoxStyle.Exclamation, "Aviso !")
            txtcaptcha.Focus()
            Exit Sub
        End If

        If txtchave.Text = "" Then
            MsgBox("Informe a Cheve de Acesso da NFe ?", MsgBoxStyle.Exclamation, "Aviso !")
            txtchave.Focus()
            Exit Sub
        End If

        If Len(txtchave.Text) < 44 Then
            MsgBox(" Cheve de Acesso da NFe Invalido ! ", MsgBoxStyle.Exclamation, "Aviso !")
            txtchave.Focus()
            Exit Sub
        End If

        frmxml.limpar_itens()


        chave = txtchave.Text.Replace(" ", "")

        If Not validachavenfe(chave) Then
            MsgBox("O Número da Chave de Acesso é inválida! ", MsgBoxStyle.Critical, "Porta Nacional NFe !")
            txtchave.Focus()
            Exit Sub
        End If

   
        WebBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_txtChaveAcessoCompleta").InnerText = txtchave.Text.Replace(" ", "")
        WebBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_txtCaptcha").InnerText = txtcaptcha.Text
        WebBrowser1.Document.GetElementById("ctl00$ContentPlaceHolder1$btnConsultar").InvokeMember("Click")

        bar.Visible = True
        txtinfonfe.Visible = True
        txtinfonfe.Text = "Validando Informações dos Campos..."


        WebBrowser1.Location = New System.Drawing.Point(3, 22)

        Label1.Visible = True
        Label1.Text = "Validando Informações dos Campos..."

        parametro = "2"

        bntconsulta.Enabled = False
        bntnovaconsulta.Enabled = False

        WebBrowser1.Visible = False



    End Sub

   
#Region "'''''''Cria o Código de barra da nfe"

    Private Sub geracodbarra()
        Dim W As Integer = Convert.ToInt32("286")
        Dim H As Integer = Convert.ToInt32("40")
        frmxml.mskchave.Mask = "00000000000000000000000000000000000000000000"
        ' Dim tipo As BarcodeLib.TYPE = BarcodeLib.TYPE.UNSPECIFIED
        'tipo = BarcodeLib.TYPE.CODE128C

        Try
            '    If tipo <> BarcodeLib.TYPE.UNSPECIFIED Then

            '    '===== gera a imagem para o codigo de barras =====
            '  frmxml.codBarImagem.Image = d.Encode(tipo, frmxml.mskchave.Text.Trim(), Color.Black, Color.White, W, H)
            '===================================
            'mostra o código gerado 
            '   frmxml.txtCodigoCodBar.Text = d.EncodedValue
            '    End If
            frmxml.codBarImagem.Width = frmxml.codBarImagem.Image.Width
            frmxml.codBarImagem.Height = frmxml.codBarImagem.Image.Height
            frmxml.mskchave.Mask = "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
    Private Sub salvacodbarra()

        '   Dim salvartipo As BarcodeLib.SaveTypes = BarcodeLib.SaveTypes.UNSPECIFIED
        ' salvartipo = BarcodeLib.SaveTypes.JPG
        '  d.SaveImage(Application.StartupPath & "\codbarranfe.jpg", salvartipo)

    End Sub
#End Region

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

   
    Private Sub busca_ref_nfe()


        With WebBrowser1

            Dim Objlabel As HtmlElementCollection = .Document.All 'Busca todas tags span


            For A As Integer = 0 To Objlabel.Count - 1


                If Objlabel.Item(A).InnerHtml = "Data de Emissão" Then
                    A += 1
                    MsgBox("Data Emissão NFe: " & CDate(Objlabel.Item(A).InnerHtml).ToString("dd/MM/yyyy HH:mm:ss"))

                End If


                If Objlabel.Item(A).InnerHtml = "Dados do Emitente" Then

                    Dim limite As Integer = A

                    For e As Integer = A To Objlabel.Count - 1

                        If frmxml.txtregime.Text = "" Then

                            If Objlabel.Item(e).InnerHtml = "Nome / Razão Social" Then
                                e += 1
                                MsgBox(Objlabel.Item(e).InnerHtml)
                            End If
                        End If

                    Next

                End If

                '''''''''''''''''''''''''''''''Rotna dados do Informações Complementares''''''''''''''''''''''''''''''''''''
                '   If Objlabel.Item(A).InnerHtml = "Documentos Fiscais Referenciados" Then

                'Documentos Fiscais Referenciados chave NFe'

                'A = A + 8
                '    frmnfelocal.dgvnotas.CurrentRow.Cells("nferef").Value = Objlabel.Item(A).InnerHtml.Replace(" ", "")
                '   MsgBox("Chave NFe origem: " & Objlabel.Item(A).InnerHtml.Replace(" ", ""), MsgBoxStyle.Information, "Aviso !")



                '  End If

            Next


        End With

        txtinfonfe.Text = "Consulta Concluida !"

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Not WebBrowser1.Document.GetElementById("ctl00_ContentPlaceHolder1_txtCaptcha") Is Nothing Then
            WebBrowser1.Navigate("http://www.nfe.fazenda.gov.br/portal/consulta.aspx?tipoConsulta=completa&tipoConteudo=XbSeqxE8pl8%3d")
            Label1.Text = "Aguarde, Recarregando imagem da RFB..."
            parametro = "0"
        Else
            WebBrowser1.Document.GetElementById("ContentPlaceHolder1_hlkAlterarCaptcha").InvokeMember("Click")
        End If
    End Sub


    Private Sub muda_versao_webbroser()
        Dim appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName)
        Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", appName, 11000, Microsoft.Win32.RegistryValueKind.DWord)
    End Sub

End Class
