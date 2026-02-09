Imports System.Security.Cryptography.X509Certificates
Imports System.Xml
Imports System.Threading
Imports System.Text
Imports System.Drawing.Text
Imports System.IO

Imports System.Xml.Linq
Imports System.Web
Imports DFe_aplicativo.C_WebService
Imports MySql.Data.MySqlClient

Public Class frmmanifestarind
    Dim valor As Integer
    Dim rsconsulta As New ADODB.Recordset
    Dim rsp As New ADODB.Recordset
    Dim WebS As New C_WebService
    Dim retorevento As New RetRetorno
    Dim rs As New ADODB.Recordset
    Dim xmldoc As New System.Xml.XmlDocument()
    Dim xmlAssinado As XmlDocument

    Dim xmlnsManager As New System.Xml.XmlNamespaceManager(xmldoc.NameTable)

    Private Sub frmmanifestarind_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmmanifestarind_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtjust.Text = "Declarando que a Operação não foi Realizada, com Recusa do Recebimento da mercadoria."
        txtdata.Text = Now
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbomanifestar.SelectedIndexChanged
        If cbomanifestar.Text = "Confirmacao da Operacao" Then
            txtcodevento.Text = "210200"
            txtjust.Text = ""
            txtjust.ReadOnly = True
        End If
        If cbomanifestar.Text = "Ciencia da Operacao" Then
            txtcodevento.Text = "210210"
            txtjust.Text = ""
            txtjust.ReadOnly = True
        End If
        If cbomanifestar.Text = "Desconhecimento da Operacao" Then
            txtcodevento.Text = "210220"
            txtjust.Text = ""
            txtjust.ReadOnly = True
        End If
        If cbomanifestar.Text = "Operacao nao Realizada" Then
            txtjust.ReadOnly = False
            txtjust.Text = "declarando que a Operação não foi Realizada (com Recusa do Recebimento da mercadoria)"
            txtcodevento.Text = "210240"
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cbomanifestar.Text = "" Then
            MsgBox("Informe o Tipo de Manifestação da NFe ?", MsgBoxStyle.Exclamation, "Aviso !")
            cbomanifestar.Focus()
            Exit Sub
        End If

        If mskcnpj.Text = "" Then
            MsgBox("Informe o CNPJ do Destinatário da NFe ?", MsgBoxStyle.Exclamation, "Aviso !")
            mskcnpj.Focus()
            Exit Sub
        End If

        If cbomanifestar.Text = "Operacao nao Realizada" Then
            If txtjust.Text = "" Then
                MsgBox("Informe a Justificativa por que a operação não foi Realizada ?", MsgBoxStyle.Exclamation, "Aviso !")
                txtjust.Focus()
                Exit Sub
            End If
            If txtjust.Text.Length < 15 Then
                MsgBox("A Justificativa deve conter no Minimo 15 caracter ?", MsgBoxStyle.Exclamation, "Aviso !")
                txtjust.Focus()
                Exit Sub
            End If
        End If

        If Len(txtchave.Text) < 44 Then
            MsgBox(" Cheve de Acesso da NFe Invalido ! ", MsgBoxStyle.Exclamation, "Aviso !")
            txtchave.Focus()
            Exit Sub
        End If



        If Not validachavenfe(txtchave.Text) Then
            MsgBox("O Número da Chave de Acesso é inválida! ", MsgBoxStyle.Critical, "SEFAZ SP !")
            txtchave.Focus()
            Exit Sub
        End If

        gerar_manifestacao(txtcodevento.Text, cbomanifestar.Text, txtjust.Text)
    End Sub

    Private Function validachavenfe(ByVal chave As String)
        Try


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
        Catch ex As Exception

        End Try
    End Function
    Private Sub gerar_manifestacao(ByVal codenv As String, ByVal descenv As String, ByVal xJust As String)
        Dim data_env As String
        Dim xmlevento = New XmlDocument()
        Dim manifestacao As New NFe()


        If horaverao = True Then
            data_env = Now.ToString("yyyy-MM-ddTHH:mm:ss") + "-02:00"
        Else
            data_env = Now.ToString("yyyy-MM-ddTHH:mm:ss") + "-03:00"
        End If

        txtinfo_manifest.Text = "Gerando arquivo da Manifestacao do destinatario para envio..."





        manifestacao.versao = "1.00"
        manifestacao.Id = codenv + txtchave.Text + "01"
        manifestacao.chave = txtchave.Text
        manifestacao.coduf = "91"
        manifestacao.cnpj = mskcnpj.Text
        manifestacao.dataenv = data_env
        manifestacao.codenv = codenv
        manifestacao.descenv = descenv
        manifestacao.xJust = xJust
        manifestacao.tpAmb = "1"

        Dim xmldoc As XmlDocument = manifestacao.Gerarmanifestacaodest()

        ' xmldoc.Save(Application.StartupPath & "\XML\manifestacaoNaoAssinado.xml")
     
        'assina os xml selecionados
        Dim xmlAssinado As XmlDocument = CertificadoDigital.Assinar(xmldoc, "infEvento", certificado)




        '''''''''''''''''''''''''''''''''''''''''''''''''''' GERA O ARQUIVO XML DA MANIFESTAÇÃO''''''''''''''''''''''''''''''''''
        xmlevento.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><envEvento versao=""1.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><idLote>" & GerarLote_manifestacao() & "</idLote>" & xmlAssinado.InnerXml & "</envEvento>")
        xmlevento.Save(Application.StartupPath & "\XML\evento.xml")

        'Valida o XML assinado
        Dim resultado As String = ValidaXML.ValidarXML(xmlevento, Application.StartupPath & "\Esquemas_XML_NF-e\envConfRecebto_v1.00.xsd")

        If resultado.Trim().Length <> 0 Then
            MsgBox(resultado)
            ' resultado = "Xml gerado com sucesso, nenhum erro encontrado"
            Exit Sub
        End If

        Using xmltw As New XmlTextWriter(Application.StartupPath & "\XML\evento.xml", New UTF8Encoding(False))
            xmlevento.WriteTo(xmltw)
            xmltw.Close()
        End Using



        Dim rotina1 As Thread
        Control.CheckForIllegalCrossThreadCalls = False
        rotina1 = New Thread(AddressOf envia_manifestacao_dest)
        rotina1.Start()

    End Sub

    Private Sub envia_manifestacao_dest()

        Dim xmlretcanc = New XmlDocument()

        Try

            '''''''''''BUSCA URL do webservice''''''''''''
            WebS.url_webservice(BuscaURL("AN31", 1, False, ""))

            'função envia o xml para receita''''''''''''''''''''''''''''''''''
            txtinfo_manifest.Text = "Enviando Manifestação Destinatário Para RFB..."

            retorevento = WebS.nfeRecepcaoEvento4(Application.StartupPath & "\XML\evento.xml")

            If reterro <> "" Then
                txtinfo_manifest.Text = reterro
                MsgBox(reterro, MsgBoxStyle.Exclamation, "Aviso !")
                reterro = String.Empty
                Pic_info.Visible = False
                Exit Sub
            End If

            If retorevento.cStat <> "128" Then
                MsgBox(retorevento.xMotivo, MsgBoxStyle.Exclamation, "Aviso !")
                Pic_info.Visible = False
                Exit Sub
            End If


            If retorevento.cStat = "128" Then

                '  frmretmanifest.Label2.Text = "Retorno Da SEFAZ das NFe Enviadas para Manifestação"
                txtinfo_manifest.Text = "Recebendo Retorno da Manifestacao enviada para RFB..."

                For Each RetC In retorevento.L_Retornos

                    ''''''''''''''''Rotina abaixo para evento desconhecimento da operação com retorno de nfe ja cancelada'''''''''''''''''


                    If RetC.cStat1 = "651" Then

                        conectar_mysqlDFe()
                        Dim insertSQL As MySqlCommand = New MySqlCommand("UPDATE NFe SET Status_nfe = 'NFe Cancelada', nprot_canc = '" & RetC.nProt & "'  WHERE Chave_nfe = '" & RetC.chNFe & "'", oConn)
                        insertSQL.ExecuteNonQuery()

                        oConn.Close()


                        ''''''''''''salvar no site''''''''''''
                        Try
                            '   conectar_mysqlDFe_site()
                            '   Dim insertSQL2 As MySqlCommand = New MySqlCommand("UPDATE NFe SET Status_nfe = 'NFe Cancelada', nprot_canc = '" & RetC.nProt & "'  WHERE Chave_nfe = '" & RetC.chNFe & "'", oConnS)
                            '   insertSQL2.ExecuteNonQuery()

                            '   oConnS.Close()
                        Catch ex As Exception

                        End Try


                    End If

                    If RetC.cStat1 = "135" Or RetC.cStat1 = "136" Or RetC.cStat1 = "596" Or RetC.cStat1 = "573" Then

                        conectar_mysqlDFe()
                        Dim insertSQL As MySqlCommand = New MySqlCommand("UPDATE NFe SET xmot_manif = '" & RetC.xEvento & "', nprot_manif = '" & RetC.nProt & "'  WHERE Chave_nfe = '" & RetC.chNFe & "'", oConn)
                        insertSQL.ExecuteNonQuery()

                        oConn.Close()

                        ''''''''''''salvar no site''''''''''''
                        Try
                            '   conectar_mysqlDFe_site()
                            '   Dim insertSQL3 As MySqlCommand = New MySqlCommand("UPDATE NFe SET xmot_manif = '" & RetC.xEvento & "', nprot_manif = '" & RetC.nProt & "'  WHERE Chave_nfe = '" & RetC.chNFe & "'", oConnS)
                            '   insertSQL3.ExecuteNonQuery()

                            '   oConnS.Close()
                        Catch ex As Exception

                        End Try



                    End If

                    txtinfo_manifest.Text = RetC.xMotivo1

                Next


            End If



            Pic_info.Visible = False

        Catch ex As Exception
            txtinfo_manifest.Text = ex.Message
            Pic_info.Visible = False
        End Try

    End Sub





End Class