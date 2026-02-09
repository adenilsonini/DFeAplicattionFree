Imports System.Xml
Imports System.Security.Cryptography
Imports System.IO
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Text
Public Class frmenvia_email
    Public caminhodanfe As String, caminhoxml As String
    Dim data As String
    Dim senhacrip As String
    Dim textoCifrado As Byte()
    Dim sal() As Byte = {&H0, &H1, &H2, &H3, &H4, &H5, &H6, &H5, &H4, &H3, &H2, &H1, &H0}
    Dim senha As String = ""
    Dim mensagem As String
    Dim rs As New ADODB.Recordset
    Dim chavenfe As String
    Dim oFileInfo As FileInfo
    Dim xmldoc As New System.Xml.XmlDocument()
    Dim xmlnsManager As New System.Xml.XmlNamespaceManager(xmldoc.NameTable)
    Dim cn As New ADODB.Connection
    Dim mail As New MailMessage()
    Dim danfe As Boolean
    Dim path As String
    Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_email.ini")
  
    Private Sub btnProcurar_Click(sender As Object, e As EventArgs) Handles btnProcurar.Click
        Dim ofd1 As New OpenFileDialog()

        If opttodos.Checked = True Then
            ofd1.Filter = "Arquivo de Diversos (*)|*"
            If ofd1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                lstAnexos.Items.Add(ofd1.FileName)
            End If
        End If

        If optxml.Checked = True Then
            ofd1.Filter = "Arquivo de xml, pdf (*.xml)|*.xml;*.pdf"
            If ofd1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                lstAnexos.Items.Add(ofd1.FileName)
                If System.IO.Path.GetExtension(ofd1.FileName) = ".xml" Or System.IO.Path.GetExtension(ofd1.FileName) = ".XML" Then
                    txtassunto.Text = "Nota Fiscal Eletrônica"
                    xmldoc.Load(ofd1.FileName)
                    chave()
                End If
            End If

        End If
        If optsintegra.Checked = True Then
            ofd1.Filter = "Arquivos (.rar.txt)|*.rar;*.txt"
            If ofd1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                lstAnexos.Items.Add(ofd1.FileName)

                data = InputBox("Informe a data do Sintegra", "Atenção !")
                txtmensagem.Text = "Prezado(a) Cliente," + vbCrLf + vbCrLf + "Segue no anexo o arquivo do sintegra referente ao Mês de " + data + _
       " de 2013" + vbCrLf + vbCrLf + vbCrLf + "Essa mensagem foi gerada automaticamente pelo sistema de nota eletrônica. Favor não responder. " _
        + vbCrLf + vbCrLf + "Aviso Legal: esta mensagem eletrônica pode conter informações privilegiadas e/ou confidenciais, portanto, fica o seu receptor notificado de que qualquer disseminação, distribuição ou cópia não autorizada é estritamente proibida. Se você entende que recebeu esta mensagem indevidamente ou por engano, por favor, informe este fato ao remetente e apague-a de seu computador."
                txtassunto.Text = "Arquivo do Sintegra"

            End If
        End If

        If optsped.Checked = True Then
            ofd1.Filter = "Arquivos (.rar.txt)|*.rar;*.txt"
            If ofd1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                lstAnexos.Items.Add(ofd1.FileName)
                data = InputBox("Informe a data do SPED Contribuições", "Atenção !")
                txtmensagem.Text = "Prezado(a) Cliente," + vbCrLf + vbCrLf + "Segue no anexo o arquivo do SPED Contribuições referente ao Mês de " + data + _
       " de 2013" + vbCrLf + vbCrLf + vbCrLf + "Essa mensagem foi gerada automaticamente pelo sistema de nota eletrônica. Favor não responder. " _
        + vbCrLf + vbCrLf + "Aviso Legal: esta mensagem eletrônica pode conter informações privilegiadas e/ou confidenciais, portanto, fica o seu receptor notificado de que qualquer disseminação, distribuição ou cópia não autorizada é estritamente proibida. Se você entende que recebeu esta mensagem indevidamente ou por engano, por favor, informe este fato ao remetente e apague-a de seu computador."

                txtassunto.Text = "SPED Contribuições"
            End If
        End If
    End Sub

    Private Sub chave()

        Dim autorizacao As String
        Dim demissao As Date
        Dim xmllist1 As System.Xml.XmlNodeList
        Dim xmlnode1 As System.Xml.XmlNode
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode
        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist = xmldoc.SelectNodes("//bk:NFe", xmlnsManager)

        'abre o xml para obiter as informações''''''''''''''''
        xmllist1 = xmldoc.SelectNodes("//bk:infProt", xmlnsManager)
        For Each xmlnode1 In xmllist1
            chavenfe = xmlnode1("chNFe").InnerText
            autorizacao = xmlnode1("nProt").InnerText
        Next


        xmllist = xmldoc.GetElementsByTagName("infNFe")
        For Each xmlnode In xmllist

            If Not xmlnode("ide")("dhEmi") Is Nothing Then
                demissao = xmlnode("ide")("dhEmi").InnerText
            End If


            If Not xmlnode("dest")("email") Is Nothing Then
                txtDestino.Text = xmlnode("dest")("email").InnerText
            End If


            txtmensagem.Clear()
            txtmensagem.Text = "Prezado(a) Cliente," + vbCrLf + vbCrLf + "Segue em anexo, o arquivo eletrônico da sua Nota Fiscal devidamente autorizado." _
               + vbCrLf + vbCrLf + "Emitente: " & xmlnode("emit")("xNome").InnerText _
               + vbCrLf + "Destinatário: " & xmlnode("dest")("xNome").InnerText + vbCrLf + "Chave de Acesso: " & chavenfe + vbCrLf + "Data da emissão: " & demissao _
           + vbCrLf + "Protocolo de autorização: " & autorizacao + vbCrLf + vbCrLf + vbCrLf + "Essa mensagem foi gerada automaticamente pelo sistema de nota eletrônica. Favor não responder. "

            mensagem = String.Empty
            mensagem += "<td style=""width:272.1pt;border:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt"" valign=""top"" width=""629"" > "
            mensagem += "<p class=""MsoNormal"" style=""text-align:center;line-height:150%"" align=""center""><b>Segue em anexo o arquivo XML referente <span>a</span> NF eletrônica<u></u><u></u></b></p></td></tr>"
            mensagem += "<tr><td style=""width:472.1pt;border:solid windowtext 1.0pt;border-top:none;padding:0cm 5.4pt 0cm 5.4pt"" valign=""top"" width=""629"">"
            mensagem += "<br><div id="":1e8"" class=""a3s"" style=""overflow: hidden;"">Caro destinatário,<br>"
            mensagem += "<br>Segue abaixo os dados da NF.e emitida e em anexo o DANFE para ser armazenado. Para verificar a autenticidade da NF.e acesse <a href=""http://www.nfe.fazenda.gov.br"" rel=""noreferrer"" target=""_blank"">http://www.nfe.fazenda.gov.br</a> e consulte pela chave de acesso informada abaixo.<br>"
            mensagem += "<br>Emitente: " & xmlnode("emit")("xNome").InnerText & "<br>"
            mensagem += "Destinatário: " & xmlnode("dest")("xNome").InnerText & "<br>"
            mensagem += "Chave de Acesso: " & chavenfe & "<br>"
            mensagem += "Data da emissão: " & demissao & "<br>"
            mensagem += "Protocolo de autorização: " & autorizacao & "<br>"
            mensagem += "<br></td><tr>"
            mensagem += "Essa mensagem foi gerada automaticamente pelo sistema de nota eletrônica (NFeSJP) Favor não responder.<br>"
            mensagem += "<br>Aviso Legal: esta mensagem eletrônica pode conter informações privilegiadas e/ou confidenciais, portanto, fica o seu receptor notificado de que qualquer disseminação, distribuição ou cópia não autorizada é estritamente proibida. Se você entende que recebeu esta mensagem indevidamente ou por engano, por favor, informe este fato ao remetente e apague-a de seu computador.</div></td>"

        Next

      

    End Sub

    
    Private Sub frmenvia_email_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        sal_conteudo_combo()

        If Me.Text <> "Envio de Notificação de Nota Fiscal Cancelada para destinataria" Then
            Try
                For i As Integer = 0 To lstAnexos.Items.Count - 1
                    File.Delete(lstAnexos.Items.Item(i))
                Next
            Catch ex As Exception

            End Try
        End If




        mensagem = String.Empty

        Me.Dispose()
    End Sub

    Private Sub frmenvia_email_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtusuario.Text = "nfesjp@gmail.com"
        txtsenha.Text = "Pe$$w0rd1@"
        txttitle.Text = arquivoIni.Read("empresa", "EMAIL")

        If Me.Text = "Envio de Notificação de Nota Fiscal Cancelada para destinataria" Then
            lstAnexos.Items.Add(caminhoxml)
            txtassunto.Text = "Nota Fiscal Cancelada"
            carregar_combo()
            Exit Sub
        End If

        If Me.Text = "Envio de Notificação de Carta correção da NF-e" Then
            ' lstAnexos.Items.Add(caminhoxml)
            txtassunto.Text = "Carta correção da NF-e"
            carregar_combo()
            Exit Sub
        End If

        txtassunto.Text = arquivoIni.Read("assunto", "EMAIL")
        txtdest02.Text = arquivoIni.Read("destinatario02", "EMAIL")

      ''''''''''''''''''''''Rotina para buscar o xml da NFe'''''''''''''''''''''
        If Me.Text = "Envio de Nota Fiscal para empresa destinataria" Then
            lstAnexos.Items.Add(caminhoxml)
            lstAnexos.Items.Add(caminhodanfe)
            xmldoc.Load(caminhoxml)
        Else

            lstAnexos.Items.Add(frmxml.txtcaminhoxml.Text)
            lstAnexos.Items.Add(frmxml.txtcaminhoxml.Text.Substring(0, frmxml.txtcaminhoxml.Text.Length - 3) & "pdf")
            xmldoc.Load(frmxml.txtcaminhoxml.Text)
            caminhodanfe = ""
            caminhoxml = ""
        End If

        carregar_combo()


        txtassunto.Text = "Nota Fiscal Eletrônica"

        chave()

        Timer1.Enabled = True
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        If txtusuario.Text = "" Then
            MsgBox("Informe o e-mail da Empresa !", MsgBoxStyle.Exclamation, "Aviso !")
            txtusuario.Focus()
            Exit Sub
        End If
        If txtsenha.Text = "" Then
            MsgBox("Informe a senha do seu E-mail !", MsgBoxStyle.Exclamation, "Aviso !")
            txtsenha.Focus()
            Exit Sub
        End If
        If txtDestino.Text = "" Then
            MsgBox("Informe o E-mail do Destinatário principal !", MsgBoxStyle.Exclamation, "Aviso !")

            If txtdest02.Text <> "" Then
                If MessageBox.Show("Deseja usar o e-mail do destinatário-02 com principal ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    txtDestino.Text = txtdest02.Text
                Else
                    txtDestino.Focus()
                    Exit Sub
                End If

            Else
                txtDestino.Focus()
                Exit Sub
            End If

        End If
        If txttitle.Text = "" Then
            MsgBox("Informe o Nome da Empresa !", MsgBoxStyle.Exclamation, "Aviso !")
            txttitle.Focus()
            Exit Sub
        End If
        If txtassunto.Text = "" Then
            MsgBox("Informe o Assunto !", MsgBoxStyle.Exclamation, "Aviso !")
            txtassunto.Focus()
            Exit Sub
        End If

        pinfo.Visible = True
        txtinfo.Text = "Aguarde, Enviando E-mail para (" & txtDestino.Text & ") ..."
        pinfo.Refresh()

        verifica()

        If optxml.Checked = True Then
            If danfe = True Then
                MsgBox("E-mail não enviado !", MsgBoxStyle.Exclamation, "Aviso !")
                pinfo.Visible = False
                Exit Sub
            End If
        End If


        ' salva_dest()

        Try

            monta_mensagem()

            EmailSender(txtusuario.Text, txttitle.Text, txtDestino.Text, mensagem, txtassunto.Text, txtsenha.Text, txtdest02.Text)

            MsgBox("E-mail Enviado com Sucesso para: " & txtDestino.Text, MsgBoxStyle.Information, "Aviso !")

            Me.Text = "Aplicativo para envio de E-mail"

            pinfo.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Atenção !")
            MsgBox("Para enviar e-mail usando a conta do gmail," + vbCrLf + "é necessário configurar o Acesso IMAP." + vbCrLf + "Acesse o Gmail clique em configuração vá no Menu (Encaminhamento e POP/IMAP)," + vbCrLf + "e no iten (Acesso IMAP) no menu à esquerda marque a opção ''Ativar IMAP''", MsgBoxStyle.Information, "Aviso !")

            pinfo.Visible = False
        End Try


    End Sub

    Private Sub verifica()
        danfe = False
        For i = 0 To lstAnexos.Items.Count - 1
            If System.IO.File.Exists(lstAnexos.Items.Item(i)) = False Then
                danfe = True
                MsgBox("arquivo nâo exite  " & lstAnexos.Items.Item(i), MsgBoxStyle.Exclamation, "Aviso !")

                If MessageBox.Show("O danfe da NF-e Não está em Anexo" + vbCrLf + "Deseja envia somente o XML ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                    If System.IO.File.Exists(lstAnexos.Items.Item(i)) = False Then
                        lstAnexos.Items.Remove(lstAnexos.Items.Item(i))
                        danfe = False
                    End If

                End If

            End If
        Next

    End Sub
    Private Sub verifica1()
        danfe = False
        For i = 0 To lstAnexos.Items.Count - 1
            If System.IO.Path.GetExtension(lstAnexos.Items.Item(i)) = ".pdf" Or System.IO.Path.GetExtension(lstAnexos.Items.Item(i)) = ".PDF" Then
                danfe = True
            End If
        Next

    End Sub

    Private Sub salva_dest()
        '  conectar_baseNFe()
        rs.Open("select * from email_nfe where Email = '" & txtDestino.Text & "'", cn_nfe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockPessimistic)
        If rs.EOF = True Then
            rs.AddNew()
            rs.Fields("Email").Value = txtDestino.Text
            rs.Update()
        End If

        rs.Close()
        cn_nfe.Close()
    End Sub

    Private Sub EmailSender(ByVal From As String, ByVal DisplayName As String, ByVal SendTo As String, ByVal Message As String, ByVal Subject As String, ByVal Password As String, ByVal copi_dest As String)

        Using mailMessage As New MailMessage(New MailAddress(SendTo), New MailAddress(SendTo))
            mailMessage.Body = Message
            mailMessage.Subject = Subject

            Try
                Dim SmtpServer As New SmtpClient()
                SmtpServer.Credentials = New System.Net.NetworkCredential(From, Password)
                SmtpServer.EnableSsl = True
                SmtpServer.Port = 587

                Dim MS() As String = From.ToString.Split("@")
                Dim MailServer() As String = MS(1).ToString.Split(".")
                Select Case UCase(MailServer(0))
                    Case Is = "GMAIL"
                        SmtpServer.Credentials = New System.Net.NetworkCredential(From, Password)
                        SmtpServer.Host = "smtp.gmail.com"
                        SmtpServer.EnableSsl = True
                    Case Is = "YAHOO"
                        SmtpServer.Host = "smtp.mail.yahoo.com"
                        SmtpServer.EnableSsl = False
                    Case Is = "AOL"
                        SmtpServer.Host = "smtp.aol.com"
                        SmtpServer.EnableSsl = False
                    Case Is = "LIVE"
                        SmtpServer.Credentials = New System.Net.NetworkCredential(From, Password)
                        SmtpServer.Host = "smtp.live.com"
                        SmtpServer.EnableSsl = True
                End Select

                mail = New MailMessage()
                Dim addr() As String = SendTo.Split(",")
                mail.From = New MailAddress(From, DisplayName, System.Text.Encoding.UTF8)
                Dim i As Byte
                For i = 0 To addr.Length - 1
                    mail.To.Add(addr(i))
                Next i
                mail.Subject = Subject
                mail.Body = Message
                mail.BodyEncoding = System.Text.Encoding.UTF7

                If lstAnexos.Items.Count <> 0 Then
                    For i = 0 To lstAnexos.Items.Count - 1
                        mail.Attachments.Add(New Attachment(lstAnexos.Items.Item(i)))
                    Next
                End If

                '''''''''Rotina para apenas um arquivo''''''''''''
                '   If Attach.Length <> 0 Then
                'mail.Attachments.Add(New Attachment(Attach))
                '    End If

                mail.IsBodyHtml = True
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                mail.ReplyTo = New MailAddress(SendTo)


                If copi_dest <> "" Then
                    mail.CC.Add(copi_dest)
                End If


                SmtpServer.Send(mail)
                mail.Attachments.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "EMail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Using
    End Sub

    Private Sub monta_mensagem()
        If optxml.Checked = True Then
            '    chave()
        Else
            mensagem = txtmensagem.Text
        End If
    End Sub

    Private Sub btnlimpar_Click(sender As Object, e As EventArgs) Handles btnlimpar.Click
        txtmensagem.Clear()
        lstAnexos.Items.Clear()
        txtDestino.Text = ""
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs)
        For i As Integer = 0 To lstAnexos.Items.Count - 1
            If System.IO.File.Exists(lstAnexos.Items.Item(i)) = False Then
                lstAnexos.Items.Remove(lstAnexos.Items.Item(i))
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '   File.Delete(frmxml.txtcaminhoxml.Text.Substring(0, frmxml.txtcaminhoxml.Text.Length - 3) & "xps")
        Timer1.Dispose()
    End Sub


    Private Sub sal_conteudo_combo()
        Dim controle As Boolean = False
        Dim caminho As String = Application.StartupPath & "/lista_destinatario-email.txt"

        If File.Exists(caminho) Then
            File.Delete(caminho)
        End If

    
        Dim sw As StreamWriter = Nothing
        sw = New StreamWriter(caminho)

      
        For Each texto As String In txtDestino.Items
            If texto = txtDestino.Text Then
                controle = True
            End If
        Next


        If controle = False Then
            txtDestino.Items.Add(txtDestino.Text)
        End If


        For Each texto As String In txtDestino.Items
            ' Dim caminho As [String] = textBoxCaminhoSalva2.Text

            sw.Write(texto & vbCrLf)
            sw.Flush()

        Next

        sw.Close()

        ' MessageBox.Show("lista salva!")
    End Sub

    Private Sub carregar_combo()

        '    If txtArquivoOrigem.Text = String.Empty Or Not txtArquivoOrigem.Text.Contains(".txt") Then

        'MsgBox("Informe o caminho do arquivo texto origem.")

        '    Return

        '  End If

        Dim caminho As String = Application.StartupPath & "/lista_destinatario-email.txt"

        ' If File.Exists(Application.StartupPath & "/lista_destinatario-email.txt") = True Then
        'File.Delete(Application.StartupPath & "/lista_destinatario-email.txt")
        ' End If

        Try

            'declara um streamReader e passa o caminho e nome do arquivo texto

            Dim SR As New StreamReader(caminho)

            ' variavel que trata as linhas que são lidas

            Dim strTemp() As String

            Do While SR.Peek <> -1 ' Utilize Peek para ler o arquivo até que não haja mais linhas



                strTemp = SR.ReadLine.Split(Chr(9))

                ' Extrai o primeiro elemento na linha e atribui os dados a primeira coluna

                txtDestino.Items.Add(strTemp(0).ToString)

                '  Inclui o item no ListView


            Loop

            SR.Close() ' fecha o StreamReader 

        Catch ex As Exception

            MsgBox("Erro ao ler o arquivo texto." & ex.Message)

        End Try
    End Sub

   
    Private Sub txtDestino_TextChanged(sender As Object, e As EventArgs) Handles txtDestino.TextChanged
        Dim boxIndex As Integer, lExst As Boolean

        Dim box As ComboBox = sender
        Dim txt As String = box.Text
        Dim posCursor As Integer = box.SelectionStart

        ' Se o cursor não estiver no inicio do textbox inicia a busca
        If posCursor <> 0 Then
            lExst = False
            ' Procura na combo pela entrada na lista
            For boxIndex = 0 To box.Items.Count - 1
                If UCase(Mid(box.Items(boxIndex), 1, posCursor)) = UCase(Mid(txt, 1, posCursor)) Then
                    box.Text = box.Items(boxIndex)
                    box.SelectionStart = posCursor
                    lExst = True
                    Exit For
                End If
            Next
            ' Se não encontrar retorna o valor anterior
            ' If Not lExst Then
            ' box.Text = Mid(txt, 1, posCursor - 1) + Mid(txt, posCursor + 1)
            'box.SelectionStart = posCursor - 1
            '   End If
        End If
    End Sub

    Private Sub txtdest02_LostFocus(sender As Object, e As EventArgs) Handles txtdest02.LostFocus

        arquivoIni.Write("destinatario02", txtdest02.Text, "EMAIL")

    End Sub


    Private Sub modulo_ini_ler(ByVal filename As String)

        Dim sr As StreamReader
        'limpa listbox
        LstItems.Items.Clear()

        sr = New StreamReader(filename)
        While sr.Peek <> -1
            Dim sLine As String = sr.ReadLine().Trim()
            'Adiciona linha no listbox
            LstItems.Items.Add(sLine)
        End While

        If (LstItems.Items.Count > 0) Then
            LstItems.SelectedIndex = 0
        End If
        'limpa
        sr.Close()
        sr = Nothing



    End Sub


    Private Sub alterar_arq_ini(ByVal texto As String, ByVal secao As String)
        Dim SelectIndex As Integer = -1
        Dim par As Integer


        For l As Integer = 0 To texto.Length - 1

            If texto.Substring(l, 1) = "=" Then
                par = l
            End If
        Next




        Dim i As Integer = LstItems.FindString(texto.Substring(0, par))
        LstItems.SelectedIndex = i


        If i = -1 Then


            LstItems.SelectedIndex = LstItems.FindString("[" & secao & "]")
            'Adicona novo item na lista
            LstItems.Items.Add(texto)
        Else

            LstItems.Items(SelectIndex) = texto
        End If
    End Sub

    Private Sub SaveINI(ByVal Filename As String)
        Dim sw As StreamWriter
        Try
            sw = New StreamWriter(Filename)
            'Salva itens na listbox para o arquivo
            For x As Integer = 0 To LstItems.Items.Count - 1
                'escreve o arquivo
                sw.WriteLine(LstItems.Items(x))
            Next x
            'fecha o arquivo
            sw.Close()
        Catch ex As Exception
            '   SetError(ex.Message)
        End Try
        'limpa
        sw = Nothing
    End Sub

    Public Sub monta_nfe_cancelada(ByVal emitente As String, destinatario As String, chave As String, dataemissao As String, prot As String)

        txtmensagem.Clear()
        txtmensagem.Text = "Prezado(a) Cliente," + vbCrLf + vbCrLf + "Segue em anexo, o arquivo eletrônico da sua Nota Fiscal Cancelado." _
           + vbCrLf + vbCrLf + "Emitente: " & emitente _
           + vbCrLf + "Destinatário: " & destinatario + vbCrLf + "Chave de Acesso: " & chavenfe + vbCrLf + "Data da emissão: " & dataemissao _
       + vbCrLf + "Protocolo de Cancelamento: " & prot + vbCrLf + vbCrLf + vbCrLf + "Essa mensagem foi gerada automaticamente pelo sistema de nota eletrônica. Favor não responder. "

        mensagem = String.Empty
        mensagem += "<td style=""width:272.1pt;border:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt"" valign=""top"" width=""629"" > "
        mensagem += "<p class=""MsoNormal"" style=""text-align:center;line-height:150%"" align=""center""><b>Segue em anexo o arquivo XML referente <span>a</span> NF-e eletrônica Cancelada<u></u><u></u></b></p></td></tr>"
        mensagem += "<tr><td style=""width:472.1pt;border:solid windowtext 1.0pt;border-top:none;padding:0cm 5.4pt 0cm 5.4pt"" valign=""top"" width=""629"">"
        mensagem += "<br><div id="":1e8"" class=""a3s"" style=""overflow: hidden;"">Prezado(a) Cliente,<br>"
        mensagem += "<br>Segue em anexo, o arquivo eletrônico da sua Nota Fiscal Devidamente Cancelada pelo Emitente <a href=""http://www.nfe.fazenda.gov.br"" rel=""noreferrer"" target=""_blank"">http://www.nfe.fazenda.gov.br</a> e consulte pela chave de acesso informada abaixo.<br>"
        mensagem += "<br>Emitente: " & emitente & "<br>"
        mensagem += "Destinatário: " & destinatario & "<br>"
        mensagem += "Chave de Acesso: " & chave & "<br>"
        mensagem += "Data da emissão: " & dataemissao & "<br>"
        mensagem += "Protocolo de cancelamento: " & prot & "<br>"
        mensagem += "<br></td><tr>"
        mensagem += "Essa mensagem foi gerada automaticamente pelo sistema de Nota eletrônica (NFeSJP). Favor não responder.<br>"
        mensagem += "<br>Aviso Legal: esta mensagem eletrônica pode conter informações privilegiadas e/ou confidenciais, portanto, fica o seu receptor notificado de que qualquer disseminação, distribuição ou cópia não autorizada é estritamente proibida. Se você entende que recebeu esta mensagem indevidamente ou por engano, por favor, informe este fato ao remetente e apague-a de seu computador.</div></td>"
    End Sub


    Public Sub monta_nfe_carta_correcao(ByVal emitente As String, destinatario As String, chave As String, dataemissao As String, prot As String)

        txtmensagem.Clear()
        txtmensagem.Text = "Prezado(a) Cliente," + vbCrLf + vbCrLf + "Segue em anexo, A carta de Correção eletrônico da sua Nota Fiscal." _
           + vbCrLf + vbCrLf + "Emitente: " & emitente _
           + vbCrLf + "Destinatário: " & destinatario + vbCrLf + "Chave de Acesso: " & chavenfe + vbCrLf + "Data da emissão: " & dataemissao _
       + vbCrLf + "Protocolo do Registro Evento: " & prot + vbCrLf + vbCrLf + vbCrLf + "Essa mensagem foi gerada automaticamente pelo sistema de nota eletrônica. Favor não responder. "

        mensagem = String.Empty
        mensagem += "<td style=""width:272.1pt;border:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt"" valign=""top"" width=""629"" > "
        mensagem += "<p class=""MsoNormal"" style=""text-align:center;line-height:150%"" align=""center""><b>Segue em anexo o arquivo XML e PDF referente <span>a</span> Carta de Correção eletrônico<u></u><u></u></b></p></td></tr>"
        mensagem += "<tr><td style=""width:472.1pt;border:solid windowtext 1.0pt;border-top:none;padding:0cm 5.4pt 0cm 5.4pt"" valign=""top"" width=""629"">"
        mensagem += "<br><div id="":1e8"" class=""a3s"" style=""overflow: hidden;"">Prezado(a) Cliente,<br>"
        mensagem += "<br>Segue em anexo, A carta de Correção eletrônico da sua Nota Fiscal. <a href=""http://www.nfe.fazenda.gov.br"" rel=""noreferrer"" target=""_blank"">http://www.nfe.fazenda.gov.br</a> e consulte pela chave de acesso informada abaixo.<br>"
        mensagem += "<br>Emitente: " & emitente & "<br>"
        mensagem += "Destinatário: " & destinatario & "<br>"
        mensagem += "Chave de Acesso: " & chave & "<br>"
        mensagem += "Data da emissão: " & dataemissao & "<br>"
        mensagem += "Protocolo do Registro Evento: " & prot & "<br>"
        mensagem += "<br></td><tr>"
        mensagem += "Essa mensagem foi gerada automaticamente pelo sistema de Nota eletrônica (NFeSJP). Favor não responder.<br>"
        mensagem += "<br>Aviso Legal: esta mensagem eletrônica pode conter informações privilegiadas e/ou confidenciais, portanto, fica o seu receptor notificado de que qualquer disseminação, distribuição ou cópia não autorizada é estritamente proibida. Se você entende que recebeu esta mensagem indevidamente ou por engano, por favor, informe este fato ao remetente e apague-a de seu computador.</div></td>"
    End Sub

    Private Sub txttitle_LostFocus(sender As Object, e As EventArgs) Handles txttitle.LostFocus
        arquivoIni.Write("empresa", txttitle.Text, "EMAIL")
    End Sub

    Private Sub txtassunto_LostFocus(sender As Object, e As EventArgs) Handles txtassunto.LostFocus
        arquivoIni.Write("assunto", txtassunto.Text, "EMAIL")
    End Sub

 
End Class