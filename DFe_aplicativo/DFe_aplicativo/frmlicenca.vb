Imports System
Imports System.Globalization
Imports System.Runtime.Caching
Imports System.Runtime.Serialization
Imports System.Text
Imports MySql.Data.MySqlClient
Imports System.Reflection
Imports System.Net.Mail

Public Class frmlicenca
    Public cad_emp As String
    Public datae As DateTime
    Dim mail As New MailMessage()
    Dim mensagem As String
    Public local As Boolean = False
    Dim data_web As New clsDateTime
    Dim datas As Date
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cad_emp <> "" Then
            End
        End If
        If local = False Then
            End
        Else
            Me.Close()
        End If

    End Sub

    Private Sub frmlicenca_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        If local = True Then
            frmdfe2.Text = "Tela Webservice DFe  |  Versao: " & Assembly.GetExecutingAssembly.GetName.Version.ToString & " 21-07-2020   |   .Net 4.8  | Empresa Conectada: " & empresa.sNomeRazao & "  |  " & "Licença vencerá em: " & data_licenca
        End If

        Me.Dispose()
    End Sub

    Private Sub frmlicenca_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If local = True Then
            Label2.Visible = False
            Label3.Visible = False
        Else
            Label4.Visible = False
        End If

        If cad_emp = "" Then

            carregar_db()

        Else
            Label2.Text = "Informe a Licença abaixo:"
        End If

    End Sub

    Private Sub carregar()
        Dim ret As Boolean = False
        Dim key As String, key_id As String, tp As String

        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config.ini")

        If arquivoIni.KeyExists("key_id", "settings") = False Then
            arquivoIni.Write("key_id", "", "settings")
        End If
        key_id = Descriptografar(arquivoIni.Read("key_id", "settings"))

        If arquivoIni.KeyExists("key_tp", "settings") = False Then
            arquivoIni.Write("key_tp", "", "settings")
        End If
        tp = Descriptografar(arquivoIni.Read("key_tp", "settings"))

        If arquivoIni.KeyExists("key", "settings") = False Then
            arquivoIni.Write("key", Criptografar(""), "settings")
        End If

        key = Descriptografar(arquivoIni.Read("key", "settings"))

        '  If valida_date(RecuperarDataExpiracao(key)) = True Then
        'MsgBox("Licença vencida !!!", MsgBoxStyle.Exclamation, "Aviso !")
        '   ret = True
        '   End If

        '    If key_id = "" Then
        'Dim dados As String
        '    dados = InputBox("Informe o CNPJ da empresa Abaixo:", "Aviso !", " ")

        '    arquivoIni.Write("key_id", Criptografar(dados), "settings")

        '    Else

        '   If key_id <> RecuperarCNPJ(key) Then
        '   MsgBox("Licença vencida 2 !!!", MsgBoxStyle.Exclamation, "Aviso !")
        'ret = True
        '  End If

        ' End If

        ' data_licenca = RecuperarDataExpiracao(key)

        If tp = "" Then
            Dim dados As String
            dados = InputBox("Informe o tipo de sistema usado Abaixo:", "Aviso !", " ")

            arquivoIni.Write("key_tp", Criptografar(dados), "settings")
        Else
            '   If tp <> RecuperarTipoSistema(key) Then
            '    MsgBox("Licença vencida 3 !!!", MsgBoxStyle.Exclamation, "Aviso !")
            'ret = True
            '   End If
        End If


        If local = False Then
            If ret = False Then
                frmprincipal.Show()
                Me.Close()
            End If

        Else
            Label4.Visible = True
            '  Label4.Text = "Sua Licença vencerá em: " & RecuperarDataExpiracao(key)
        End If


    End Sub

    Private Sub carregar_db()
        Dim dados_cnpj As String
        Dim dados_tp As String
        Dim ret As Boolean = False
        Dim key As String, key_id As String, tp As String

        ''''''''''''''''busca licenca no banco online''''''''''''''''
        ''  licenca_liberada_online()

        ' If conexao_online = False Then
        conectar_mysqlDFe()
        '  Else
        '      conectar_mysqlDFe_ON()
        '  End If

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from licenca where key_sist = 'DFe' and key_id = '" & Criptografar(empresa.sCNPJ) & "'"
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read

                key_id = Descriptografar(reader("key_id").ToString)
                tp = Descriptografar(reader("key_tp").ToString)
                key = Descriptografar(reader("key_chave").ToString)

            End While

        End Using

        If key_id = "" Then
            MsgBox("Seu CNPJ não possui licença no sistema !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If


        ''   Dim cnpj_l As String = verificar_licenca_api(key, "cnpj")

        datae = Now
        Exit Sub

        'If valida_date(datae) = True Then
        '    MsgBox("Licença vencida !!!", MsgBoxStyle.Exclamation, "Aviso !")
        '    Exit Sub
        '    ret = True
        'Else
        '    Dim wD2 As Long = DateDiff(DateInterval.Day, CDate(Now.Date), datae)
        '    If wD2 < 8 Then

        '        If wD2 = 0 Then
        '            MsgBox("Sua licenca do sistema (Vence Hoje) !", MsgBoxStyle.Exclamation, "Aviso !")
        '        Else
        '            MsgBox("licenca do sistema esta vencendo, faltam: " & wD2, MsgBoxStyle.Exclamation, "Aviso !")
        '        End If

        '    End If

        'End If



        'If key_id <> cnpj_l Then
        '    MsgBox("Licença de outro CNPJ !!!", MsgBoxStyle.Exclamation, "Aviso !")
        '    ret = True
        'End If



        data_licenca = datae
        frmdfe2.Show()
        Me.Close()

        Exit Sub

        If tp <> verificar_licenca_api(key, "tipo_sistema") Then
            MsgBox("Tipo de Sistema diferente na licença !!!", MsgBoxStyle.Exclamation, "Aviso !")
            ret = True
        End If


        If local = False Then
            If ret = False Then

                frmdfe2.Show()
                Me.Close()
            End If

        Else
            Label4.Visible = True
            Label4.Text = "Sua Licença vencerá em: " & datae
        End If


    End Sub


    Private Sub inserir_dados(ByVal cnpj_d As String, Optional ByVal chave As String = "")
        Dim tp As String = Criptografar("1")
        Dim Sql As String = "INSERT INTO licenca (key_sist, key_chave, key_id, key_tp, data_cad) VALUES ('DFe', '" & chave & "', '" & cnpj_d & "', '" & tp & "', '" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "')"

        conectar_mysqlDFe()
        Dim insertSQL As MySqlCommand = New MySqlCommand(Sql, oConn)
        insertSQL.ExecuteNonQuery()
        oConn.Close()
    End Sub

    Private Sub inserir_licenca(ByVal texto As String)

        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config.ini")

        arquivoIni.Write("key", Criptografar(texto), "settings")

    End Sub

    Public Function valida_date(ByVal valor As Date) As Boolean
        Dim ret As Boolean = False
        datas = data_web.GetNetworkTime.ToString()

        If valor < datas.ToString("dd/MM/yyyy") Then
            '  MsgBox("Data invalida !", MsgBoxStyle.Exclamation, "Aviso !")
            ret = True
        End If
        Return ret
    End Function

    Private Sub bntlicenca_Click(sender As Object, e As EventArgs) Handles bntlicenca.Click
        If txtlicenca.Text = "" Then
            MsgBox("Informe a Licença no campo ?", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        If verificar_licenca_api(txtlicenca.Text, "chave") = "erro" Then
            MsgBox("Licença Invalida !!!", MsgBoxStyle.Exclamation, "Aviso !")
            txtlicenca.Clear()
            txtlicenca.Focus()
            Exit Sub
        End If

        If cad_emp = "" Then
            Dim Sql As String = "update licenca set key_chave = @key_chave where key_sist = 'DFe' and key_id = '" & Criptografar(empresa.sCNPJ) & "'"

            conectar_mysqlDFe()
            Dim insertSQL As MySqlCommand = New MySqlCommand(Sql, oConn)
            insertSQL.Parameters.Add(New MySqlParameter("key_chave", Criptografar(txtlicenca.Text.Replace("-", ""))))
            insertSQL.ExecuteNonQuery()
            oConn.Close()
        Else

            inserir_dados(Criptografar(cad_emp), Criptografar(txtlicenca.Text.Replace("-", "")))

            MsgBox("Empresa cadastrada e sistema ativado com Sucesso !", MsgBoxStyle.Information, "Aviso !")

            Me.Close()
            Exit Sub
        End If

        MsgBox("Sistema ativado com Sucesso !", MsgBoxStyle.Information, "Aviso !")

        frmdfe2.Show()
        Me.Close()
    End Sub


    Public Sub envia_email()

        monta_mensagem()


        Dim RET As Boolean = EmailSender("nfesjp@gmail.com", empresa.sNomeRazao, "adenilson.ini@gmail.com", mensagem, "SOLICITACAO LICENÇA", "Pe$$w0rd1@", "")

        If RET = True Then
            MsgBox("e-mail de Solicitação de licença enviado", MsgBoxStyle.Information, "Aviso !")
        End If

    End Sub


    Private Sub monta_mensagem()
        mensagem = String.Empty

        mensagem += "<div style=""margin:0px auto;max-width:600px"">"
        mensagem += "<table align=""center"" role=""presentation"" style=""width:100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">"
        mensagem += "<tbody>"
        mensagem += "<tr>"

        mensagem += "<table width=""600"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""margin:0 auto"">"
        mensagem += "<tbody><tr>"
        mensagem += "<td style=""text-align:center;border-bottom:1px solid #e4e4e4"">"
        mensagem += "<a href=""http://nfesjp.online"" style=""display:block"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=http://doka.sytes.net:8008"">"
        '  mensagem += "<img src=""http://nfesjp.online/Images/Slide/logo.jpg"" class=""CToWUd"">"
        mensagem += "</a>"
        mensagem += "</td>"
        mensagem += "</tr>"


        mensagem += "<td style=""width:272.1pt;border:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt"" valign=""top"" width=""629"" > "
        mensagem += "<p class=""MsoNormal"" style=""text-align:center;line-height:150%"" align=""center""><b>INFORMATIVO SUPERMERCADO DOKA LTDA<u></u><u></u></b></p></td></tr>"
        mensagem += "<tr><td style=""width:472.1pt;border:solid windowtext 1.0pt;border-top:none;padding:0cm 5.4pt 0cm 5.4pt"" valign=""top"" width=""629"">"


        mensagem += "<br>"
        mensagem += "<font face=""Verdana, Calibri"" size=""3"" color=""#122bff"">"
        mensagem += "<strong>Solicitação Licença,</strong> <br>"
        mensagem += "</font>"
        mensagem += "<br>"

        mensagem += "<br>"
        mensagem += "<font face=""Verdana, Calibri"" size=""5"" color=""#122bff"">"
        mensagem += "<strong>Empresa: " & empresa.sNomeRazao & "</strong> <br>"
        mensagem += "</font>"
        mensagem += "<br>"

        mensagem += "<br>"
        mensagem += "<font face=""Verdana, Calibri"" size=""5"" color=""#122bff"">"
        mensagem += "<strong>CNPJ da Empresa Solicitante: " & cnpj_emp & "</strong> <br>"
        mensagem += "</font>"
        mensagem += "<br>"


        mensagem += "<br>"
        mensagem += "<font face=""Verdana, Calibri"" size=""5"" color=""#122bff"">"
        mensagem += "<strong>E-mail Empresa: " & empresa.sEmail & "</strong> <br>"
        mensagem += "</font>"
        mensagem += "<br>"


        mensagem += "<br>"
        mensagem += "<font face=""Verdana, Calibri"" size=""5"" color=""#122bff"">"
        mensagem += "<strong>Telefone Empresa: " & empresa.Sfone & "</strong> <br>"
        mensagem += "</font>"
        mensagem += "<br>"


        mensagem += "<br>"
        mensagem += "<font face=""Verdana, Calibri"" size=""5"" color=""#122bff"">"
        mensagem += "<strong>Sistema DFe/visualiza XML</strong> <br>"
        mensagem += "</font>"
        mensagem += "<br>"

        mensagem += "<table role=""presentation"" width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">"
        mensagem += "<tbody><tr>"
        mensagem += "<td align=""center"" valign=""top"" style=""padding:30px 0 0px 0"" bgcolor=""#ffffff"">"
        mensagem += "<table role=""presentation"" width=""670"" border=""0"" align=""center"" cellpadding=""0"" cellspacing=""0"" class=""m_7275981257150110784w100pc"">"
        mensagem += "<tbody><tr>"

        mensagem += "</tr>"
        mensagem += "</tbody></table></td>"
        mensagem += "</tr>"
        mensagem += "</tbody></table>"

        mensagem += "<br></td><tr>"
        mensagem += "Essa mensagem foi gerada automaticamente pelo sistema de nota eletrônica (NFeSJP) Favor não responder.<br>"
        mensagem += "<br>Aviso Legal: esta mensagem eletrônica pode conter informações privilegiadas e/ou confidenciais, portanto, fica o seu receptor notificado de que qualquer disseminação, distribuição ou cópia não autorizada é estritamente proibida. Se você entende que recebeu esta mensagem indevidamente ou por engano, por favor, informe este fato ao remetente e apague-a de seu computador.</div></td>"

        mensagem += "</tbody></table>"

        mensagem += "</tr>"
        mensagem += "</tbody>"
        mensagem += "</table>"
        mensagem += "</div>"
    End Sub

    Private Function EmailSender(ByVal From As String, ByVal DisplayName As String, ByVal SendTo As String, ByVal Message As String, ByVal Subject As String, ByVal Password As String, ByVal copi_dest As String) As String

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

                ' If lstAnexos.Items.Count <> 0 Then
                'For i = 0 To lstAnexos.Items.Count - 1
                'mail.Attachments.Add(New Attachment(lstAnexos.Items.Item(i)))
                '  Next
                ' End If

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

                Return True
            Catch ex As Exception
                '  MessageBox.Show(ex.Message, "Erro no envio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End Try
        End Using
    End Function

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        frmpedido_licenca.ShowDialog()
    End Sub

    Private Sub licenca_liberada_online()
        Try

            conectar_mysqlDFe_ON()
            Dim SQLcommand4 As MySqlCommand
            SQLcommand4 = oConn.CreateCommand
            SQLcommand4.CommandText = "select * from licenca_liberada where cnpj_emp = '" & empresa.sCNPJ & "' and status = 'liberado' and tipo_sistema = 'dfe'"

            Using reader As MySqlDataReader = SQLcommand4.ExecuteReader

                While reader.Read

                    txtlicenca.Text = reader("serial_licenca").ToString

                End While

            End Using



            If txtlicenca.Text <> "" Then
                Dim Sql As String = "update licenca set key_chave = @key_chave where key_sist = 'DFe' and key_id = '" & Criptografar(empresa.sCNPJ) & "'"

                conectar_mysqlDFe()
                Dim insertSQL As MySqlCommand = New MySqlCommand(Sql, oConn)
                insertSQL.Parameters.Add(New MySqlParameter("key_chave", Criptografar(txtlicenca.Text.Replace("-", ""))))
                insertSQL.ExecuteNonQuery()
                oConn.Close()



                conectar_mysqlDFe_ON()
                Dim insertSQL2 As MySqlCommand = New MySqlCommand("update licenca_liberada set status = 'Utilizado em: " & Now & "' where cnpj_emp = '" & empresa.sCNPJ & "' and tipo_sistema = 'dfe'", oConn)
                insertSQL2.ExecuteNonQuery()
                oConn.Close()

            End If
        Catch ex As Exception
            MsgBox("Erro conexao na base Online", MsgBoxStyle.Critical, "Aviso !")
        End Try


    End Sub


End Class