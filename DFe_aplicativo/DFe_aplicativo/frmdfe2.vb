Imports System.Xml
Imports DFe_aplicativo.C_WebService
Imports System.Threading
Imports System.Text
Imports System.Data.SQLite
Imports System.IO
Imports Microsoft.Owin.Hosting
Imports System.Globalization
Imports MySql.Data.MySqlClient
Imports System.Reflection
Imports System.Runtime.Caching
Imports System.Security.Cryptography.X509Certificates
Imports Amazon.S3
Imports Amazon.S3.Model
Imports System.Threading.Tasks
Imports System.Security.Cryptography

Public Class frmdfe2
    Dim controleExec As Integer, HoraExeDfe As String
    Dim versao_sist As String = "DFe/Local  |  Versao: " & Assembly.GetExecutingAssembly.GetName.Version.ToString & "   |  14/04/2026  | Empresa Conectada: "
    Dim logar As Boolean
    Dim nrecibo_cont As String, xmotivo_cont As String, cstat_cont As String, nprot_cont As String
    Dim xmlAssinado As XmlDocument
    Dim canc_sub As Boolean, autcont As Boolean
    Dim versao As String
    Dim tipo_consulta As String, chave As String
    Dim data_web As New clsDateTime
    Dim datas As Date, data_venc_cert As Date

    Dim cont_manifest As Integer, cont_manifest_t As Integer


    Dim webApp3 As IDisposable

    Private rotina_dfe_m As Thread

    Private rotina_dfe As Thread
    Private rotina_nfce As Thread
    Private WebS As New C_WebService
    Private xmldoc As New XmlDocument()
    Private xmlnsManager As New XmlNamespaceManager(xmldoc.NameTable)
    Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")

    Private Sub frmdfe2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If logar = False Then
            If MessageBox.Show("Deseja realmente fechar o Sistema ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            Else

                Dim proc As Process

                For Each proc In Process.GetProcesses
                    If proc.ProcessName = "mysqld-nt" Then
                        proc.Kill()
                    End If
                Next

                End

            End If
        End If
    End Sub

    Private Sub parametroServido_NFCe()

        If arquivoIni.KeyExists("TelaDfe", "DFe") Then
            If arquivoIni.Read("TelaDfe", "DFe") = "false" Then
                Tabdfe.TabPages.Remove(TabPage1_dfe)
            End If
        Else
            arquivoIni.Write("TelaDfe", "false", "DFe")
        End If

        If arquivoIni.KeyExists("servidorNFCe", "DFe") Then
            If arquivoIni.Read("servidorNFCe", "DFe") = "true" Then
                ativar_servidor()
            End If
        Else
            arquivoIni.Write("servidorNFCe", "false", "DFe")
        End If
    End Sub
    Private Sub frmdfe2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' parametroServido_NFCe()

        Tabdfe.TabPages.Remove(TabPage2)
        Tabdfe.TabPages.Remove(TabPage1)

        If certificado Is Nothing Then
            frmcert.ShowDialog()
        End If

        '    End If
        ' Catch ex As Exception
        'frmcert.ShowDialog()
        '  End Try

        cboambdfe.SelectedIndex = 0

        If arquivoIni.KeyExists("Conferencia_ativa", "DFe_custoSG") = False Then
            arquivoIni.Write("Conferencia_ativa", "false", "DFe_custoSG")
        End If
        chkcusto.Checked = arquivoIni.Read("Conferencia_ativa", "DFe_custoSG")


        If arquivoIni.KeyExists("Tela_conf_ativa", "DFe_custoSG") = False Then
            arquivoIni.Write("Tela_conf_ativa", "false", "DFe_custoSG")
        End If

        If arquivoIni.Read("Tela_conf_ativa", "DFe_custoSG") = True Then
            btndifal.Visible = True
        End If


        If arquivoIni.KeyExists("valor_dif", "DFe_custoSG") = False Then
            arquivoIni.Write("valor_dif", "0,10", "DFe_custoSG")
        End If
        vlrdifal = arquivoIni.Read("valor_dif", "DFe_custoSG")



        If Not certificado Is Nothing Then

            cnpj_cert = ExtrairCNPJ(certificado)
            If cnpj_cert = "" Then
                cnpj_cert = ExtrairCPF(certificado)
            End If
            carregar_nsu()
            CalcucarHora()

            Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")
            If arquivoIni.KeyExists("execucao_automatico", "DFe") = False Then
                arquivoIni.Write("execucao_automatico", "false", "DFe")
            End If

            If arquivoIni.Read("execucao_automatico", "DFe") = True Then
                Texecucao_dfe.Enabled = True
            End If

            If arquivoIni.KeyExists("salva_xmlpasta", "MANIFESTO_AUTOMATICO") = False Then
                arquivoIni.Write("salva_xmlpasta", "false", "MANIFESTO_AUTOMATICO")
            End If
            chkxml.Checked = arquivoIni.Read("salva_xmlpasta", "MANIFESTO_AUTOMATICO")

            carregar_cbocert()


            Me.Text = versao

            manifes_auto()

            Try
                ''  ativar_servidor()
            Catch ex As Exception

            End Try

        Else
            bntpesqDFe.Enabled = False
        End If


        criar_tabela()

        Me.Text = versao_sist & empresa.sNomeRazao & "  |  " & "Versão Free"

        carregar_caixa()


        ' Verifica se o CNPJ do certificado não é vazio
        If Not String.IsNullOrEmpty(cnpj_cert) Then
            ' Verifica se o item JÁ EXISTE no ComboBox para não duplicar
            If Not cbocnpjdfe.Items.Contains(cnpj_cert) Then
                cbocnpjdfe.Items.Add(cnpj_cert)
            End If
        End If


        cbocnpjdfe.Text = cnpj_cert


        If arquivoIni.KeyExists("total_reg_grid", "DFe") = False Then
            arquivoIni.Write("total_reg_grid", "30", "DFe")
        End If

        txttotal_reg.Text = arquivoIni.Read("total_reg_grid", "DFe")

        controleExec = 1
    End Sub

    Private Sub manifes_auto()
        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")
        If arquivoIni.KeyExists("ativa", "MANIFESTO_AUTOMATICO") = False Then
            arquivoIni.Write("ativa", "", "MANIFESTO_AUTOMATICO")
        End If

        chkmanifes.Checked = arquivoIni.Read("ativa", "MANIFESTO_AUTOMATICO")
    End Sub

    Private Sub licenca_liberada_online()
        Dim txtlicenca As String
        Try

            conectar_mysqlDFe_ON()
            Dim SQLcommand4 As MySqlCommand
            SQLcommand4 = oConn.CreateCommand
            SQLcommand4.CommandText = "select * from licenca_liberada where cnpj_emp = '" & empresa.sCNPJ & "' and status = 'liberado' and tipo_sistema = 'dfe'"

            Using reader As MySqlDataReader = SQLcommand4.ExecuteReader

                While reader.Read

                    txtlicenca = reader("serial_licenca").ToString

                End While

            End Using



            If txtlicenca <> "" Then
                Dim Sql As String = "update licenca set key_chave = @key_chave where key_sist = 'DFe' and key_id = '" & Criptografar(empresa.sCNPJ) & "'"

                conectar_mysqlDFe()
                Dim insertSQL As MySqlCommand = New MySqlCommand(Sql, oConn)
                insertSQL.Parameters.Add(New MySqlParameter("key_chave", Criptografar(txtlicenca.Replace("-", ""))))
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

    Private Sub executar_dfe()
        panel_chave.Visible = False

        Try

            '     If valida_date_licenca() Then
            '  txtinfodfe.Text = "Sua licença de uso do Sistema venceu em: " & data_licenca
            'licenca_liberada_online()
            'Exit Sub
            ' End If


            Dim wD2 As Long = DateDiff(DateInterval.Day, Now.Date, CDate(certificado.NotAfter.ToString))

            txtvenc_info.Text = certificado.NotAfter.ToString("dd/MM/yyyy")
            lblvenc_info.Text = "Faltam " & wD2 & " dias p/venc."

            tipo_consulta = "DFe"

            Invoke(Sub() bntcancelar.Visible = True)

            txtinfodfe.Text = "Aguarde, Sistema em execução...."
            Control.CheckForIllegalCrossThreadCalls = False
            rotina_dfe = New Thread(AddressOf DFeconsulta_nfe4)
            rotina_dfe.SetApartmentState(ApartmentState.STA)
            rotina_dfe.Start()

        Catch ex As Exception
            txtinfodfe.Text = "Rotina (executar_dfe): " & ex.Message
            CalcucarHora()
        End Try



    End Sub

    Private Sub DFeconsulta_nfe4()
        Dim retDFE As retDistDFeInt
        Invoke(Sub() Pic_prog.Visible = True)


        Try

            retDFE = WebS.NFeDistribuicaoDFe4(empresa.sCNPJ, cboambdfe.Text.Substring(0, 1), "31", txtultnsudfe.Text, chave, tipo_consulta)


            txtinfodfe.Text = retDFE.xMotivo & ", Pesquisa realizada em: " & Convert.ToDateTime(retDFE.dhResp).ToString("dd/MM/yyyy HH:mm:ss")

            lblultimaexec.Text = Convert.ToDateTime(retDFE.dhResp).ToString("dd/MM/yyyy HH:mm:ss")

            If tipo_consulta = "DFe" Then
                If retDFE.ultNSU <> "000000000000000" Then

                    If retDFE.cStat <> "656" Then
                        txtultnsudfe.Text = retDFE.ultNSU
                    End If

                End If
                txtmaxNSU.Text = retDFE.maxNSU
            End If


            If retDFE.cStat = "138" Then

                For Each doc In retDFE.loteDistDFeInt
                    xmldoc.LoadXml(DecompressGZip(doc.Value))

                    total_reg()

                    If doc.schema.ToString.Substring(0, 6) = "resNFe" Then
                        resnfe(xmldoc)
                    End If
                    If doc.schema.ToString.Substring(0, 13) = "procEventoNFe" Then
                        resprotnfe(xmldoc)
                    End If
                    If doc.schema.ToString.Substring(0, 7) = "procNFe" Then
                        resprotnfe(xmldoc)
                    End If

                Next

            End If

            If tipo_consulta = "DFe" Then

                If txtinfodfe.Text.Length >= 8 Then
                    If txtinfodfe.Text.Substring(0, 9) = "Rejeicao:" Then
                        Invoke(Sub() Pic_prog.Visible = False)
                        Invoke(Sub() bntcancelar.Visible = False)
                        CalcucarHora()
                    Else
                        continuacao("nfe")
                    End If
                End If
            End If


            If tipo_consulta = "DFe_cons_chave" Then
                Invoke(Sub() Pic_prog.Visible = False)
                Invoke(Sub() bntcancelar.Visible = False)
                MsgBox(retDFE.xMotivo & vbCrLf & "Consulta Realizada com Sucesso em: " & Now, MsgBoxStyle.Information, "Aviso !")
            End If

            If tipo_consulta = "DFe_cons" Then
                Invoke(Sub() Pic_prog.Visible = False)
                Invoke(Sub() bntcancelar.Visible = False)
                Invoke(Sub() lblfaltamexec.Text = "00:00:00")
                MsgBox(retDFE.xMotivo & vbCrLf & "Consulta Realizada com Sucesso em: " & Now, MsgBoxStyle.Information, "Aviso !")
            End If

        Catch ex As Exception
            If reterro = "" Then
                txtinfodfe.Text = "Rotina (DFeconsulta_nfe4): " & ex.Message
                gerar_txterro(ex.Message)
            Else
                txtinfodfe.Text = "Rotina (DFeconsulta_nfe4): " & reterro
                gerar_txterro(reterro)
            End If
            CalcucarHora()
            Invoke(Sub() Pic_prog.Visible = False)
            Invoke(Sub() bntcancelar.Visible = False)
        End Try


    End Sub
    Private Sub total_reg()
        If dgvnfe.Rows.Count = txttotal_reg.Text Then
            dgvnfe.Rows.Remove(dgvnfe.Rows.Item(0))
        End If
    End Sub

    Private Sub color_grid()
        For Each row As DataGridViewRow In dgvnfe.Rows
            If row.Cells("par_salvo").Value = "false" Then
                With Me.dgvnfe.Rows(row.Index).DefaultCellStyle
                    .BackColor = Color.Red
                    .ForeColor = Color.White
                End With
            End If
        Next
    End Sub
    Public Function continuacao(ByVal par As String)

        If par = "nfe" Then
            If CDec(txtultnsudfe.Text) < CDec(txtmaxNSU.Text) Then
                txtinfodfe.Text = "Nova Execucao sendo realizada NFe, aguarde...."
                Thread.Sleep(2000)
                DFeconsulta_nfe4()
            Else
                HoraExeDfe = Now
                salvar_nsu()
                color_grid()
                DFeconsulta_CTe4()
            End If
        End If

        If par = "cte" Then
            If CDec(txtultnsucte.Text) < CDec(txtmaxnsucte.Text) Then
                txtinfodfe.Text = "Nova Execucao sendo realizada CTe, aguarde...."
                Thread.Sleep(2000)
                DFeconsulta_CTe4()
            Else
                salvar_nsucte()
                CalcucarHora()

                If chkmanifes.Checked = True And chkBucketS3.Checked = False Then

                    gerar_evento_lote_cont()

                    Invoke(Sub() Timer_manifest.Enabled = True)

                    '   gerar_evento_auto()

                End If

                If chkcusto.Checked = True Then
                    validar_CUSTO()
                End If

                Invoke(Sub() Pic_prog.Visible = False)
                Invoke(Sub() bntcancelar.Visible = False)

            End If
        End If
    End Function

    Private Sub DFeconsulta_CTe4()
        Dim retDFE As retDistDFeInt
        Invoke(Sub() Pic_prog.Visible = True)

        txtinfodfe.Text = txtinfodfe.Text & vbCrLf & "Pesquisando CTe, aguarde...."
        retDFE = WebS.NFeDistribuicaoDFecte(cnpj_cert, cboambdfe.Text.Substring(0, 1), "31", txtultnsucte.Text, "", "cte")

        Try

            txtinfodfe.Text = retDFE.xMotivo & " Pesquisa realizada em: " & Convert.ToDateTime(retDFE.dhResp).ToString("dd/MM/yyyy HH:mm:ss")
            If retDFE.ultNSU <> "000000000000000" Then
                txtultnsucte.Text = retDFE.ultNSU
            End If
            txtmaxnsucte.Text = retDFE.maxNSU


            Dim cont As Integer
            If retDFE.cStat = "138" Then


                For Each doc In retDFE.loteDistDFeInt
                    cont += 1
                    xmldoc.LoadXml(DecompressGZip(doc.Value))


                    If doc.schema.ToString.Substring(0, 7) = "procCTe" Then
                        resprotcte(xmldoc)
                    End If


                Next

            End If

            continuacao("cte")

        Catch ex As Exception
            If reterro = "" Then
                txtinfodfe.Text = ex.Message
            Else
                txtinfodfe.Text = reterro
            End If
        End Try
    End Sub

    Private Sub resprotcte(ByVal xmlret As XmlDocument)
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode
        Dim xmllist2 As System.Xml.XmlNodeList
        Dim xmlnode2 As System.Xml.XmlNode
        Dim dataprot As Date
        Dim chave As String


        xmllist2 = xmlret.GetElementsByTagName("infProt")
        For Each xmlnode2 In xmllist2
            dataprot = xmlnode2("dhRecbto").InnerText
            chave = xmlnode2("chCTe").InnerText
        Next

        xmllist = xmlret.GetElementsByTagName("infCte")
        For Each xmlnode In xmllist

            Dim tiponfe As String = xmlnode("ide")("tpCTe").InnerText

            If tiponfe = "0" Then
                tiponfe = "CT-e Normal"
            End If
            If tiponfe = "1" Then
                tiponfe = "CT-e de Complemento de Valores"
            End If
            If tiponfe = "2" Then
                tiponfe = "CT-e de Anulação"
            End If
            If tiponfe = "3" Then
                tiponfe = "CT-e de Substituição"
            End If

            Dim CNPJ_ret As String
            If Not xmlnode("emit")("CNPJ") Is Nothing Then
                CNPJ_ret = xmlnode("emit")("CNPJ").InnerText
            End If
            If Not xmlnode("emit")("CPF") Is Nothing Then
                CNPJ_ret = xmlnode("emit")("CPF").InnerText
            End If

            Dim CNPJ_rem As String
            If Not xmlnode("rem")("CNPJ") Is Nothing Then
                CNPJ_rem = xmlnode("rem")("CNPJ").InnerText
            End If
            If Not xmlnode("rem")("CPF") Is Nothing Then
                CNPJ_rem = xmlnode("rem")("CPF").InnerText
            End If

            Dim tomador As String = "0"
            If Not xmlnode("ide")("toma3") Is Nothing Then
                tomador = xmlnode("ide")("toma3")("toma").InnerText
            End If


            Salvar_CTe(chave, xmlnode("emit")("xNome").InnerText, CNPJ_ret, xmlnode("vPrest")("vTPrest").InnerText, xmlret.OuterXml, CNPJ_rem, Convert.ToDateTime(xmlnode("ide")("dhEmi").InnerText).ToString("dd/MM/yyyy"), tomador)


            Invoke(Sub() dgvcte.Rows.Add("CTe", xmlnode("emit")("xNome").InnerText, Convert.ToDateTime(xmlnode("ide")("dhEmi").InnerText).ToString("dd/MM/yyyy"),
                                xmlnode("vPrest")("vTPrest").InnerText, dataprot.ToString("dd/MM/yyyy HH:mm:ss"), "CT-e autorizada",
                                tiponfe, chave, xmlret.OuterXml, tomador_cte(tomador)))



        Next
    End Sub

    Function tomador_cte(ByVal valor As String) As String

        If valor = "0" Then
            valor = "0-Remetente"
        End If

        If valor = "1" Then
            valor = "1-Expedidor"
        End If

        If valor = "2" Then
            valor = "2-Recebedor"
        End If
        If valor = "3" Then
            valor = "3-Destinatário"
        End If

        Return valor
    End Function

    Private Async Function resnfeAsync(ByVal xmlret As XmlDocument) As Task
        ' Usamos Task.Run para processar o XML em uma thread separada
        ' Isso evita lentidão se houver muitos nós para processar
        Await Task.Run(Sub()
                           Dim xmllist As System.Xml.XmlNodeList
                           ' Importante: Certifique-se que o xmlnsManager está acessível aqui
                           xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
                           xmllist = xmlret.SelectNodes("//bk:resNFe", xmlnsManager)

                           For Each xmlnode As System.Xml.XmlNode In xmllist
                               ' Lógica de conversão de Tipos
                               Dim tiponfe As String = xmlnode("tpNF").InnerText
                               If tiponfe = "0" Then tiponfe = "0-NFe Entrada"
                               If tiponfe = "1" Then tiponfe = "1-NFe Saida"

                               ' Lógica de Situação
                               Dim SitNFe As String = xmlnode("cSitNFe").InnerText
                               Select Case SitNFe
                                   Case "1" : SitNFe = "NF-e autorizada"
                                   Case "2" : SitNFe = "Uso denegado"
                                   Case "3" : SitNFe = "NF-e cancelada"
                               End Select

                               ' CNPJ ou CPF
                               Dim CNPJ_ret As String = ""
                               If xmlnode("CNPJ") IsNot Nothing Then
                                   CNPJ_ret = xmlnode("CNPJ").InnerText
                               ElseIf xmlnode("CPF") IsNot Nothing Then
                                   CNPJ_ret = xmlnode("CPF").InnerText
                               End If

                               ' Se Salvar_NFe for síncrono, ele roda aqui na thread secundária sem travar a UI
                               Dim ret As Boolean = Salvar_NFe("1", xmlnode("chNFe").InnerText, xmlnode("xNome").InnerText, CNPJ_ret, xmlnode("IE").InnerText, xmlnode("vNF").InnerText, Convert.ToDateTime(xmlnode("dhRecbto").InnerText).ToString("dd/MM/yyyy HH:mm:ss"), tiponfe, "", Convert.ToDateTime(xmlnode("dhEmi").InnerText).ToString("dd/MM/yyyy"))

                               ' IMPORTANTE: Atualização de UI (DataGridView) precisa do Invoke
                               ' Como estamos dentro de uma Task, o Invoke é obrigatório
                               Me.Invoke(Sub()
                                             dgvnfe.Rows.Add("NF-e", CNPJ_ret, xmlnode("xNome").InnerText,
                                                       Convert.ToDateTime(xmlnode("dhEmi").InnerText).ToString("dd/MM/yyyy"),
                                                       format_val_mysql_ret(xmlnode("vNF").InnerText),
                                                       Convert.ToDateTime(xmlnode("dhRecbto").InnerText).ToString("dd/MM/yyyy HH:mm:ss"),
                                                       SitNFe, tiponfe,
                                                       xmlnode("chNFe").InnerText, xmlnode("IE").InnerText,
                                                       "Sem manifestacao", "", ret, cnpj_cert)
                                         End Sub)
                           Next
                       End Sub)
    End Function

    Private Sub resnfe(ByVal xmlret As XmlDocument)
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode
        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist = xmlret.SelectNodes("//bk:resNFe", xmlnsManager)

        For Each xmlnode In xmllist

            Dim tiponfe As String = xmlnode("tpNF").InnerText
            If tiponfe = "0" Then
                tiponfe = "0-NFe Entrada"
            End If
            If tiponfe = "1" Then
                tiponfe = "1-NFe Saida"
            End If

            Dim SitNFe As String = xmlnode("cSitNFe").InnerText
            If SitNFe = "1" Then
                SitNFe = "NF-e autorizada"
            End If
            If SitNFe = "2" Then
                SitNFe = "Uso denegado"
            End If
            If SitNFe = "3" Then
                SitNFe = "NF-e cancelada"
            End If

            Dim CNPJ_ret As String
            If Not xmlnode("CNPJ") Is Nothing Then
                CNPJ_ret = xmlnode("CNPJ").InnerText
            End If
            If Not xmlnode("CPF") Is Nothing Then
                CNPJ_ret = xmlnode("CPF").InnerText
            End If

            ''''''''''''''''''''''''Rotina para salvar nfe no banco de dados''''''''
            Dim ret As Boolean = Salvar_NFe("1", xmlnode("chNFe").InnerText, xmlnode("xNome").InnerText, CNPJ_ret, xmlnode("IE").InnerText, xmlnode("vNF").InnerText, Convert.ToDateTime(xmlnode("dhRecbto").InnerText).ToString("dd/MM/yyyy HH:mm:ss"), tiponfe, "", Convert.ToDateTime(xmlnode("dhEmi").InnerText).ToString("dd/MM/yyyy"))

            ''''''''''''''''''''''''Rotina para salvar nfe no banco de dados site''''''''
            '  Salvar_NFe_site("1", xmlnode("chNFe").InnerText, xmlnode("xNome").InnerText, CNPJ_ret, xmlnode("IE").InnerText, xmlnode("vNF").InnerText, Convert.ToDateTime(xmlnode("dhRecbto").InnerText).ToString("dd/MM/yyyy HH:mm:ss"), tiponfe, "", Convert.ToDateTime(xmlnode("dhEmi").InnerText).ToString("dd/MM/yyyy"))

            ''''''''''''''''''''''''Rotina para carregar nfe no grid''''''''
            Invoke(Sub() dgvnfe.Rows.Add("NF-e", CNPJ_ret, xmlnode("xNome").InnerText, Convert.ToDateTime(xmlnode("dhEmi").InnerText).ToString("dd/MM/yyyy"), format_val_mysql_ret(xmlnode("vNF").InnerText),
                                                                            Convert.ToDateTime(xmlnode("dhRecbto").InnerText).ToString("dd/MM/yyyy HH:mm:ss"), SitNFe, tiponfe,
                                                                            xmlnode("chNFe").InnerText, xmlnode("IE").InnerText, "Sem manifestacao", "", ret, cnpj_cert))



        Next
    End Sub

    Private Async Function reseventoAsync(ByVal xmlret As XmlDocument) As Task
        ' Move o processamento para background para não travar a UI
        Await Task.Run(Sub()
                           Dim xmllist As System.Xml.XmlNodeList
                           xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
                           xmllist = xmlret.SelectNodes("//bk:procEventoNFe", xmlnsManager)

                           For Each xmlnode As System.Xml.XmlNode In xmllist
                               ' Navegação segura nos nós do XML
                               Dim infEvento = xmlnode("evento")("infEvento")
                               Dim descEvento = infEvento("detEvento")("descEvento").InnerText

                               If descEvento = "Cancelamento" Then
                                   Dim chaveNFe As String = infEvento("chNFe").InnerText
                                   Dim nProt As String = infEvento("nProt").InnerText

                                   ' Precisamos do Invoke para ler do Grid ou escrever nele
                                   Dim result As String = ""
                                   Me.Invoke(Sub() result = getDataGridViewIndex(chaveNFe))

                                   ' Atualização da Interface
                                   Me.Invoke(Sub()
                                                 If result = "R" Then
                                                     dgvnfe.Rows.Add("", "", "", "", "", "", chaveNFe, "", descEvento, "", "", "", cnpj_cert)
                                                 Else
                                                     dgvnfe.Rows.Item(CInt(result)).Cells("situacao_nfe").Value = descEvento
                                                 End If
                                             End Sub)

                                   ' Operação de Banco de Dados (Thread de background)
                                   Try
                                       conectar_mysqlDFe()
                                       ' Use parâmetros para evitar SQL Injection e erros de string
                                       Dim sql As String = "UPDATE NFe SET Status_nfe = 'NFe cancelada', nprot_canc = @nprot WHERE Chave_nfe = @chave"
                                       Using insertSQL As New MySqlCommand(sql, oConn)
                                           insertSQL.Parameters.AddWithValue("@nprot", nProt)
                                           insertSQL.Parameters.AddWithValue("@chave", chaveNFe)
                                           insertSQL.ExecuteNonQuery()
                                       End Using
                                   Catch ex As Exception
                                       ' Trate o erro de banco aqui
                                   Finally
                                       If oConn.State = ConnectionState.Open Then oConn.Close()
                                   End Try
                               End If
                           Next
                       End Sub)
    End Function

    Private Sub resevento(ByVal xmlret As XmlDocument)
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode
        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist = xmlret.SelectNodes("//bk:procEventoNFe", xmlnsManager)

        For Each xmlnode In xmllist

            If xmlnode("evento")("infEvento")("detEvento")("descEvento").InnerText = "Cancelamento" Then
                Dim result As String = getDataGridViewIndex(xmlnode("evento")("infEvento")("chNFe").InnerText)

                If result = "R" Then
                    Invoke(Sub() dgvnfe.Rows.Add("", "", "", "", "", "", xmlnode("evento")("infEvento")("chNFe").InnerText, "", xmlnode("evento")("infEvento")("detEvento")("descEvento").InnerText), "", "", "", cnpj_cert)
                Else
                    dgvnfe.Rows.Item(result).Cells("situacao_nfe").Value = xmlnode("evento")("infEvento")("detEvento")("descEvento").InnerText
                End If

                conectar_mysqlDFe()
                Dim insertSQL As MySqlCommand = New MySqlCommand("UPDATE NFe SET Status_nfe = 'NFe cancelada', nprot_canc = '" & xmlnode("evento")("infEvento")("nProt").InnerText & "' WHERE Chave_nfe = '" & xmlnode("evento")("infEvento")("chNFe").InnerText & "'", oConn)

                insertSQL.ExecuteNonQuery()

                oConn.Close()


            End If


        Next
    End Sub

    Private Async Function resprotnfeAsync(ByVal xmlret As XmlDocument) As Task
        ' Captura o estado de controles da UI antes de ir para a thread de background
        Dim salvarXmlLocal As Boolean = chkxml.Checked

        Await Task.Run(Sub()
                           Dim xmllist As System.Xml.XmlNodeList
                           Dim xmllist2 As System.Xml.XmlNodeList
                           Dim dataprot As Date
                           Dim chave As String = ""

                           ' 1. Extração do Protocolo
                           xmllist2 = xmlret.GetElementsByTagName("infProt")
                           For Each xmlnode2 As System.Xml.XmlNode In xmllist2
                               dataprot = Convert.ToDateTime(xmlnode2("dhRecbto").InnerText)
                               chave = xmlnode2("chNFe").InnerText
                           Next

                           ' 2. Processamento da NFe
                           xmllist = xmlret.GetElementsByTagName("infNFe")
                           For Each xmlnode As System.Xml.XmlNode In xmllist

                               ' Precisamos do Invoke para consultar o índice no Grid
                               Dim result As String = ""
                               Me.Invoke(Sub() result = getDataGridViewIndex(chave))

                               ' Lógica de Tipo de NFe
                               Dim tiponfe As String = xmlnode("ide")("tpNF").InnerText
                               tiponfe = If(tiponfe = "0", "0-NFe Entrada", "1-NFe Saida")

                               ' Lógica de CNPJ/CPF
                               Dim cn As String = If(xmlnode("emit")("CNPJ") IsNot Nothing,
                                                xmlnode("emit")("CNPJ").InnerText,
                                                xmlnode("emit")("CPF").InnerText)

                               If result = "R" Then
                                   ' --- Fluxo de Inserção Nova ---
                                   Dim ret As Boolean = Salvar_NFe("2", chave, xmlnode("emit")("xNome").InnerText, cn, xmlnode("emit")("IE").InnerText, xmlnode("total")("ICMSTot")("vNF").InnerText, dataprot.ToString("dd/MM/yyyy HH:mm:ss"), tiponfe, xmlret.OuterXml, Convert.ToDateTime(xmlnode("ide")("dhEmi").InnerText).ToString("dd/MM/yyyy"))

                                   Me.Invoke(Sub()
                                                 dgvnfe.Rows.Add("NF-e/xml", cn, xmlnode("emit")("xNome").InnerText, Convert.ToDateTime(xmlnode("ide")("dhEmi").InnerText).ToString("dd/MM/yyyy"),
                                                           format_val_mysql_ret(xmlnode("total")("ICMSTot")("vNF").InnerText), dataprot.ToString("dd/MM/yyyy HH:mm:ss"), "NF-e autorizada",
                                                           tiponfe, chave, xmlnode("emit")("IE").InnerText, "", xmlret.OuterXml, ret, "false", cnpj_cert)
                                             End Sub)
                               Else
                                   ' --- Fluxo de Atualização ---
                                   Dim ret As Boolean = Salvar_NFe("5", chave, xmlnode("emit")("xNome").InnerText, cn, xmlnode("emit")("IE").InnerText, xmlnode("total")("ICMSTot")("vNF").InnerText, dataprot.ToString("dd/MM/yyyy HH:mm:ss"), tiponfe, xmlret.OuterXml, Convert.ToDateTime(xmlnode("ide")("dhEmi").InnerText).ToString("dd/MM/yyyy"))
                                   Salvar_NFe_site("5", chave, xmlnode("emit")("xNome").InnerText, cn, xmlnode("emit")("IE").InnerText, xmlnode("total")("ICMSTot")("vNF").InnerText, dataprot.ToString("dd/MM/yyyy HH:mm:ss"), tiponfe, xmlret.OuterXml, Convert.ToDateTime(xmlnode("ide")("dhEmi").InnerText).ToString("dd/MM/yyyy"))

                                   Me.Invoke(Sub()
                                                 Dim idx As Integer = CInt(result)
                                                 dgvnfe.Rows.Item(idx).Cells(0).Value = "NF-e/xml"
                                                 dgvnfe.Rows.Item(idx).Cells("xml_nfe").Value = xmlret.OuterXml
                                                 dgvnfe.Rows.Item(idx).Cells("situacao_nfe").Value = ""
                                                 dgvnfe.Rows.Item(idx).Cells("par_salvo").Value = ret
                                                 dgvnfe.Rows.Item(idx).Cells("custo_griddgvnfe").Value = "false"
                                             End Sub)
                               End If

                               ' 3. Salvar XML em disco
                               If salvarXmlLocal Then
                                   Try
                                       Dim dataemi As Date = Convert.ToDateTime(xmlnode("ide")("dhEmi").InnerText)
                                       Dim ano As String = dataemi.ToString("yyyy")
                                       Dim mes As String = dataemi.ToString("MM") & "-" & System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(dataemi.Month)

                                       ' Lógica simplificada de diretório
                                       Dim caminhoBase As String = If(arquivoIni.Read("salva_xml_Plocal", "DFe") = "True",
                                                                 Application.StartupPath & "\xml_tempRFB",
                                                                 arquivoIni.Read("caminho_xmlnfe", "DFe"))

                                       Dim diretorioFinal As String = Path.Combine(caminhoBase, empresa.sCNPJ, ano, mes)

                                       If Not Directory.Exists(diretorioFinal) Then Directory.CreateDirectory(diretorioFinal)

                                       xmlret.Save(Path.Combine(diretorioFinal, chave & ".xml"))
                                   Catch ex As Exception
                                       ' Silenciar ou logar erro de salvamento de arquivo
                                   End Try
                               End If
                           Next
                       End Sub)
    End Function

    Private Sub resprotnfe(ByVal xmlret As XmlDocument)
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode
        Dim xmllist2 As System.Xml.XmlNodeList
        Dim xmlnode2 As System.Xml.XmlNode
        Dim dataprot As Date
        Dim chave As String


        xmllist2 = xmlret.GetElementsByTagName("infProt")
        For Each xmlnode2 In xmllist2
            dataprot = Convert.ToDateTime(xmlnode2("dhRecbto").InnerText).ToString("dd/MM/yyyy HH:mm:ss")
            chave = xmlnode2("chNFe").InnerText
        Next

        xmllist = xmlret.GetElementsByTagName("infNFe")
        For Each xmlnode In xmllist

            Dim result As String = getDataGridViewIndex(chave)

            If result = "R" Then

                Dim tiponfe As String = xmlnode("ide")("tpNF").InnerText
                If tiponfe = "0" Then
                    tiponfe = "0-NFe Entrada"
                End If
                If tiponfe = "1" Then
                    tiponfe = "1-NFe Saida"
                End If

                Dim cn As String
                If Not xmlnode("emit")("CNPJ") Is Nothing Then
                    cn = xmlnode("emit")("CNPJ").InnerText
                Else
                    cn = xmlnode("emit")("CPF").InnerText
                End If

                ''''''''''''''''''''''''Rotina para salvar nfe no banco de dados''''''''
                Dim ret As Boolean = Salvar_NFe("2", chave, xmlnode("emit")("xNome").InnerText, cn, xmlnode("emit")("IE").InnerText, xmlnode("total")("ICMSTot")("vNF").InnerText, dataprot, tiponfe, xmlret.OuterXml, Convert.ToDateTime(xmlnode("ide")("dhEmi").InnerText).ToString("dd/MM/yyyy"))

                ''''''''''''''''''''''''Rotina para salvar nfe no banco de dados no site''''''''
                '    Salvar_NFe_site("2", chave, xmlnode("emit")("xNome").InnerText, xmlnode("emit")("CNPJ").InnerText, xmlnode("emit")("IE").InnerText, xmlnode("total")("ICMSTot")("vNF").InnerText, dataprot, tiponfe, xmlret.OuterXml, Convert.ToDateTime(xmlnode("ide")("dhEmi").InnerText).ToString("dd/MM/yyyy"))

                ''''''''''''''''''''''''Rotina para carregar nfe no grid''''''''
                Invoke(Sub() dgvnfe.Rows.Add("NF-e/xml", cn, xmlnode("emit")("xNome").InnerText, Convert.ToDateTime(xmlnode("ide")("dhEmi").InnerText).ToString("dd/MM/yyyy"),
                                    format_val_mysql_ret(xmlnode("total")("ICMSTot")("vNF").InnerText), dataprot.ToString("dd/MM/yyyy HH:mm:ss"), "NF-e autorizada",
                                    tiponfe, chave, xmlnode("emit")("IE").InnerText, "", xmlret.OuterXml, ret, "false", cnpj_cert))


            Else

                Dim tiponfe As String = xmlnode("ide")("tpNF").InnerText
                If tiponfe = "0" Then
                    tiponfe = "0-NFe Entrada"
                End If
                If tiponfe = "1" Then
                    tiponfe = "1-NFe Saida"
                End If
                ''''''''''''''''''''''''Rotina para salvar nfe no banco de dados''''''''
                '   Dim ret As Boolean = Salvar_NFe(chave, "", "", "", "", dataprot, "", xmlret.OuterXml, Now.Date)

                Dim cnpj3 As String

                If Not xmlnode("emit")("CNPJ") Is Nothing Then
                    cnpj3 = xmlnode("emit")("CNPJ").InnerText
                End If

                If Not xmlnode("emit")("CPF") Is Nothing Then
                    cnpj3 = xmlnode("emit")("CPF").InnerText
                End If

                Dim ret As Boolean = Salvar_NFe("5", chave, xmlnode("emit")("xNome").InnerText, cnpj3, xmlnode("emit")("IE").InnerText, xmlnode("total")("ICMSTot")("vNF").InnerText, dataprot, tiponfe, xmlret.OuterXml, Convert.ToDateTime(xmlnode("ide")("dhEmi").InnerText).ToString("dd/MM/yyyy"))

                ''''''''''''''''''''''''Rotina para salvar nfe no banco de dados no site''''''''
                Salvar_NFe_site("5", chave, xmlnode("emit")("xNome").InnerText, cnpj3, xmlnode("emit")("IE").InnerText, xmlnode("total")("ICMSTot")("vNF").InnerText, dataprot, tiponfe, xmlret.OuterXml, Convert.ToDateTime(xmlnode("ide")("dhEmi").InnerText).ToString("dd/MM/yyyy"))

                dgvnfe.Rows.Item(result).Cells(0).Value = "NF-e/xml"

                dgvnfe.Rows.Item(result).Cells("xml_nfe").Value = xmlret.OuterXml

                dgvnfe.Rows.Item(result).Cells("situacao_nfe").Value = ""

                dgvnfe.Rows.Item(result).Cells("par_salvo").Value = ret

                dgvnfe.Rows.Item(result).Cells("custo_griddgvnfe").Value = "false"
                ''''''''''''''''''''''''''''asalvar para salvar as informações posteriormente

            End If


            ''''''''''''''''''''''Salvar xml da pasta''''''''''''''''''''''''''
            If chkxml.Checked = True Then
                Dim dataemi As Date = xmlnode("ide")("dhEmi").InnerText
                Dim ano As String = dataemi.ToString("yyyy")
                Dim mes As String = dataemi.ToString("MM") & "-" & DateTimeFormatInfo.CurrentInfo.GetMonthName(dataemi.ToString("MM"))


                If arquivoIni.KeyExists("salva_xml_Plocal", "DFe") = False Then
                    arquivoIni.Write("salva_xml_Plocal", "True", "DFe")
                End If

                If arquivoIni.Read("salva_xml_Plocal", "DFe") = "True" Then
                    caminho_dfe_xml = Application.StartupPath & "\xml_tempRFB"
                Else
                    caminho_dfe_xml = arquivoIni.Read("caminho_xmlnfe", "DFe")
                End If

                If Directory.Exists(caminho_dfe_xml) = False Then
                    Directory.CreateDirectory(caminho_dfe_xml)
                End If

                If Directory.Exists(caminho_dfe_xml + "\" + empresa.sCNPJ + "\" + ano + "\" + mes) = False Then
                    Directory.CreateDirectory(caminho_dfe_xml + "\" + empresa.sCNPJ + "\" + ano + "\" + mes)
                End If

                xmlret.Save(caminho_dfe_xml + "\" + empresa.sCNPJ + "\" + ano + "\" + mes + "\" & chave + ".xml")
            End If
        Next
    End Sub


    Private Sub validar_CUSTO()
        Dim cod_cad_for As String = ""
        Dim codsg As String = ""
        Dim nome As String, vlrtotal As String
        Dim dataemi As Date
        Dim unxml As String


        For i As Integer = 0 To dgvnfe.Rows.Count - 1


            If dgvnfe.Rows.Item(i).Cells("custo_griddgvnfe").Value = "false" Then

                Dim cont_total As Integer = 0
                Dim cont_barra As Integer = 0

                Dim xml_cod As New XmlDocument()

                xml_cod.LoadXml(dgvnfe.Rows.Item(i).Cells("xml_nfe").Value)

                Dim xmlnode As System.Xml.XmlNode
                Dim xmllist As System.Xml.XmlNodeList

                xmllist = xml_cod.GetElementsByTagName("emit")
                For Each xmlnode In xmllist
                    nome = xmlnode("xNome").InnerText

                    conectarsqlinx()
                    Dim RS As New ADODB.Recordset
                    '''''''''''''''''verifica se o fornecedor esta cadastrado'''''''''''''''''''
                    Dim Sql As String = "SELECT * FROM cg2  where cg2_cgc = '" & xmlnode("CNPJ").InnerText & "'"
                    RS.Open(Sql, cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                    If RS.EOF = False Then
                        cod_cad_for = RS.Fields("cg2_cod").Value
                        RS.Close()
                    End If
                    cnsql.Close()
                Next

                xmllist = xml_cod.GetElementsByTagName("ide")
                For Each xmlnode In xmllist
                    dataemi = xmlnode("dhEmi").InnerText
                Next

                xmllist = xml_cod.GetElementsByTagName("ICMSTot")
                For Each xmlnode In xmllist
                    vlrtotal = xmlnode("vNF").InnerText
                Next


                xmllist = xml_cod.GetElementsByTagName("det")

                For Each xmlnode In xmllist
                    Dim preco_custo As String, pr_venda As String, qtdecx As String, margem As String, pr_real As String, dir As String, vlroutras As String, vlripi As String, vlricms As String, vlrfcp As String, vdes As String, vlrfrete As String, vlrreal2 As String

                    codsg = ""
                    '''''''''''Rotina busca o produto pelo codigo de barras do produto
                    If xmlnode("prod")("cEANTrib").InnerText <> "SEM GTIN" Then

                        conectarsqlinx()
                        Dim RS As New ADODB.Recordset
                        'Rotina Busca pelo codigo de barras cadastrado'''''''''''''''''''''''''
                        Dim Sql As String = "SELECT * FROM es1a where es1_codbarra = '" & xmlnode("prod")("cEANTrib").InnerText & "'"

                        RS.Open(Sql, cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

                        If RS.EOF = False Then

                            codsg = RS.Fields("es1_cod").Value


                        End If

                        RS.Close()

                        cnsql.Close()
                    End If


                    '''''''''''Rotina busca o produto pelo codigo do fornecedor
                    If codsg = "" Then

                        conectarsqlinx()
                        Dim RS As New ADODB.Recordset
                        Dim Sql As String = "SELECT * FROM es1i where cg2_cod = '" & cod_cad_for & "' and es1_codforn = '" & xmlnode("prod")("cProd").InnerText.ToString.TrimStart("0") & "' "

                        RS.Open(Sql, cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

                        If RS.EOF = False Then

                            codsg = RS.Fields("es1_cod").Value

                        End If

                        RS.Close()
                        cnsql.Close()

                    End If


                    '''''''''''Rotina busca o produto na tabela dos produtos
                    If codsg <> "" Then
                        unxml = xmlnode("prod")("uTrib").InnerText

                        preco_custo = "0,00"
                        pr_real = "0,00"
                        pr_venda = "0,00"
                        margem = "0,00"
                        dir = "0"
                        vlricms = "0,00"
                        vlripi = "0,00"
                        vlrfcp = "0,00"
                        vlroutras = "0,00"
                        vdes = "0,00"
                        vlrreal2 = "0,00"
                        qtdecx = "0"

                        conectarsqlinx()
                        Dim RS As New ADODB.Recordset
                        Dim Sql As String = "SELECT * FROM es1 where es1_cod = '" & codsg & "'"

                        RS.Open(Sql, cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

                        If RS.EOF = False Then

                            preco_custo = Format(CDec(RS.Fields("es1_prcompra").Value.ToString.Replace(".", ",")), "#,##0.00")

                            qtdecx = RS.Fields("es1_qembc").Value.ToString.Replace(".", ",")

                            pr_venda = Format(CDec(RS.Fields("es1_prvarejo").Value.ToString.Replace(".", ",")), "#,##0.00")

                        End If

                        RS.Close()
                        cnsql.Close()



                        pr_real = Format(CDec(xmlnode("prod")("vProd").InnerText.ToString.Replace(".", ",")), "#,##0.00")
                        '''''''''''Rotina busca o preço da tributação''''''''''''''''''

                        If Not xmlnode("prod")("vDesc") Is Nothing Then

                            vdes = Format(CDec(xmlnode("prod")("vDesc").InnerText.Replace(".", ",")), "#,##0.00")

                        End If

                        If Not xmlnode("prod")("vFrete") Is Nothing Then

                            vlrfrete = Format(CDec(xmlnode("prod")("vFrete").InnerText.Replace(".", ",")), "#,##0.00")

                        End If

                        If Not xmlnode("prod")("vOutro") Is Nothing Then

                            vlroutras = Format(CDec(xmlnode("prod")("vOutro").InnerText.Replace(".", ",")), "#,##0.00")

                        End If

                        If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vICMSST") Is Nothing Then

                            vlricms = Format(CDec(xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vICMSST").InnerText.Replace(".", ",")), "#,##0.00")

                        End If

                        If Not xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vFCPST") Is Nothing Then

                            vlrfcp = Format(CDec(xmlnode("imposto")("ICMS").ChildNodes.Item(0)("vFCPST").InnerText.Replace(".", ",")), "#,##0.00")

                        End If


                        If Not xmlnode("imposto")("IPI") Is Nothing Then

                            If Not xmlnode("imposto")("IPI").ChildNodes.Item(1)("vIPI") Is Nothing Then
                                vlripi = Format(CDec(xmlnode("imposto")("IPI").ChildNodes.Item(1)("vIPI").InnerText.Replace(".", ",")), "#,##0.00")
                            End If

                        End If

                        pr_real = Format(CDec(pr_real) + (CDec(vlricms) + CDec(vlripi) + CDec(vlroutras) + CDec(vlrfrete) + CDec(vlrfcp)), "#,##0.00")
                        '   MsgBox(nome & "   " & xmlnode("prod")("cProd").InnerText)

                        '  MsgBox(vlricms & "   " & vlripi & "   " & vlroutras & "   " & vlrfrete & "   " & vlrfcp)

                        pr_real = Format(CDec(pr_real) - CDec(vdes), "#,##0.00")

                        ' MsgBox(pr_real & "   1")
                        pr_real = Format(CDec(pr_real) / CDec(xmlnode("prod")("qCom").InnerText.Replace(".", ",")))

                        vlrreal2 = pr_real

                        '  MsgBox(pr_real & "   2")
                        pr_real = Format(CDec(pr_real) / CDec(qtdecx), "#,##0.00")



                        '   MsgBox(pr_real & "   3")
                        margem = Format(((CDec(pr_venda) - CDec(pr_real)) * 100) / CDec(pr_real), "#,##0.00")


                        Dim pr As Boolean = False
                        If CDec(pr_real) <> CDec(preco_custo) Then
                            dir = Format(CDec(pr_real) - CDec(preco_custo), "#,##0.00")



                            Dim vlr As String

                            If (CDec(pr_real) - CDec(preco_custo)) > vlrdifal Then
                                vlr = CDec(pr_real) - CDec(preco_custo)
                                pr = True
                            End If

                            If (CDec(preco_custo) - CDec(pr_real)) > vlrdifal Then
                                vlr = CDec(pr_real) - CDec(preco_custo)
                                pr = True
                            End If



                            If pr = True Then
                                If verificar_regexiste("select * from preco_sg where chave_sist = '" & dgvnfe.Rows.Item(i).Cells("chave_nfe").Value & xmlnode("prod")("cProd").InnerXml & "'") = 0 Then
                                    executa_query("INSERT INTO preco_sg (cnpj_for, cod_for, desc_prd, cod_sg, chave_nfe, precocusto_xml, precocusto_sg, qtde_cx, diferenca, margem_atual, status, chave_sist, nomefor, dataemissao, valornfe, unxml, vlrvendaSG, vlr_real, qtdexml) values ('" & dgvnfe.Rows.Item(i).Cells("cnpj_nfe").Value & "', '" & xmlnode("prod")("cProd").InnerText.TrimStart("0") & "', '" & xmlnode("prod")("xProd").InnerText & "', '" & codsg & "', '" & dgvnfe.Rows.Item(i).Cells("chave_nfe").Value & "', '" & pr_real & "', '" & preco_custo & "', '" & qtdecx & "', '" & dir & "', '" & margem & "','', '" & dgvnfe.Rows.Item(i).Cells("chave_nfe").Value & xmlnode("prod")("cProd").InnerText.TrimStart("0") & "', '" & nome & "' , '" & dataemi.ToString("yyyy-MM-dd HH:mm:ss") & "' , '" & vlrtotal & "', '" & unxml & "', '" & pr_venda & "', '" & vlrreal2 & "', '" & xmlnode("prod")("qCom").InnerText.Replace(".", ",") & "')")
                                Else
                                    executa_query("update preco_sg set qtdexml = '" & xmlnode("prod")("qCom").InnerText.Replace(".", ",") & "', precocusto_xml = '" & pr_real & "', precocusto_sg = '" & preco_custo & "', diferenca = '" & dir & "', margem_atual = '" & margem & "', desc_prd = '" & xmlnode("prod")("xProd").InnerText & "' where chave_sist = '" & dgvnfe.Rows.Item(i).Cells("chave_nfe").Value & xmlnode("prod")("cProd").InnerText.TrimStart("0") & "'")
                                End If
                                pr = False
                            End If

                        End If




                    Else

                        executa_query("INSERT INTO preco_sg (cnpj_for, cod_for, desc_prd, cod_sg, chave_nfe, precocusto_xml, precocusto_sg, qtde_cx, diferenca, margem_atual, status, chave_sist, nomefor, dataemissao, valornfe, unxml, vlrvendaSG, vlr_real) values ('" & dgvnfe.Rows.Item(i).Cells("cnpj_nfe").Value & "', '" & xmlnode("prod")("cProd").InnerText.TrimStart("0") & "', '" & xmlnode("prod")("xProd").InnerText & "', '" & codsg & "', '" & dgvnfe.Rows.Item(i).Cells("chave_nfe").Value & "', '" & Format(CDec(xmlnode("prod")("vUnTrib").InnerText.Replace(".", ",")), "#,##0.00") & "', '0,00', '0,00', '0,00', '0,00', 'Produto sem cadastro', '" & dgvnfe.Rows.Item(i).Cells("chave_nfe").Value & xmlnode("prod")("cProd").InnerText.TrimStart("0") & "', '" & nome & "' , '" & dataemi.ToString("yyyy-MM-dd HH:mm:ss") & "' , '" & vlrtotal & "', '" & unxml & "', '0', '" & vlrreal2 & "')")


                    End If

                Next



                dgvnfe.Rows.Item(i).Cells("custo_griddgvnfe").Value = "true"

            End If

        Next



    End Sub
    Private Function Salvar_NFe(ByVal p As String, ByVal nchave As String, ByVal nome_emi As String, ByVal cnpj_emi As String, ByVal ie As String, ByVal valor_nfe As String, ByVal Data_aut As Date, ByVal Tipo_nf As String, ByVal xml As String, ByVal data_emi As Date) As Boolean
        Dim ret As Integer = 0
        Dim SQLcommand As MySqlCommand
        Dim ret_salvo As Boolean = True

        Try



            Dim sql As String = "Select * from NFe where cnpj_dest = '" & cnpj_cert & "' and Chave_nfe = '" & nchave & "'"

            conectar_mysqlDFe()

            SQLcommand = oConn.CreateCommand

            SQLcommand.CommandText = sql

            dr = SQLcommand.ExecuteReader()


            While (dr.Read())
                ret += 1
            End While

            dr.Close()
            SQLcommand.Dispose()
            oConn.Close()



            If ret = 1 Then

                conectar_mysqlDFe()
                Dim insertSQL As MySqlCommand = New MySqlCommand("UPDATE NFe SET xml_nfe = @xml_nfe, Nome_emi = @Nome_emi, Cnpj_emi = @Cnpj_emi, Ie_emi = @Ie_emi, Valor_nfe = @Valor_nfe, Data_aut = @Data_aut , Tipo_nfe = @Tipo_nfe, Data_emi = @Data_emi, Numero_nfe = @Numero_nfe, Status_nfe = @Status_nfe WHERE cnpj_dest = '" & cnpj_cert & "' and Chave_nfe = '" & nchave & "'", oConn)
                insertSQL.Parameters.Add(New MySqlParameter("xml_nfe", arq_bits(xml)))

                insertSQL.Parameters.Add(New MySqlParameter("Nome_emi", nome_emi))
                insertSQL.Parameters.Add(New MySqlParameter("Cnpj_emi", cnpj_emi))
                insertSQL.Parameters.Add(New MySqlParameter("Ie_emi", ie))
                insertSQL.Parameters.Add(New MySqlParameter("Valor_nfe", valor_nfe))
                insertSQL.Parameters.Add(New MySqlParameter("Data_aut", Data_aut))
                insertSQL.Parameters.Add(New MySqlParameter("Tipo_nfe", Tipo_nf))
                insertSQL.Parameters.Add(New MySqlParameter("Data_emi", data_emi))
                insertSQL.Parameters.Add(New MySqlParameter("Numero_nfe", nchave.Substring(25, 9)))
                insertSQL.Parameters.Add(New MySqlParameter("Status_nfe", "NF-e autorizada"))
                insertSQL.ExecuteNonQuery()

                oConn.Close()


            End If

            If ret = 0 Then


                conectar_mysqlDFe()
                Dim insertSQL As MySqlCommand = New MySqlCommand("INSERT INTO NFe (Chave_nfe, Nome_emi, Cnpj_emi, Ie_emi, Valor_nfe, Data_aut, Tipo_nfe, xml_nfe, Data_emi, Numero_nfe, Status_nfe, cnpj_dest, numero_sintegra, cnpj_chave) VALUES (@Chave_nfe, @Nome_emi, @Cnpj_emi, @Ie_emi, @Valor_nfe, @Data_aut, @Tipo_nfe, @xml_nfe, @Data_emi, @Numero_nfe, @Status_nfe, @cnpj_dest, @numero_sintegra, @cnpj_chave)", oConn)

                insertSQL.Parameters.Add(New MySqlParameter("Chave_nfe", nchave))
                insertSQL.Parameters.Add(New MySqlParameter("Nome_emi", nome_emi))
                insertSQL.Parameters.Add(New MySqlParameter("Cnpj_emi", cnpj_emi))
                insertSQL.Parameters.Add(New MySqlParameter("Ie_emi", ie))
                insertSQL.Parameters.Add(New MySqlParameter("Valor_nfe", valor_nfe))
                insertSQL.Parameters.Add(New MySqlParameter("Data_aut", Data_aut))
                insertSQL.Parameters.Add(New MySqlParameter("Tipo_nfe", Tipo_nf))
                If xml = "" Then
                    insertSQL.Parameters.Add(New MySqlParameter("xml_nfe", Nothing))
                Else
                    insertSQL.Parameters.Add(New MySqlParameter("xml_nfe", arq_bits(xml)))
                End If
                insertSQL.Parameters.Add(New MySqlParameter("Data_emi", data_emi))
                insertSQL.Parameters.Add(New MySqlParameter("Numero_nfe", nchave.Substring(25, 9)))
                insertSQL.Parameters.Add(New MySqlParameter("Status_nfe", "NF-e autorizada"))

                insertSQL.Parameters.Add(New MySqlParameter("cnpj_dest", cnpj_cert))

                insertSQL.Parameters.Add(New MySqlParameter("cnpj_chave", nchave.Substring(6, 14)))
                insertSQL.Parameters.Add(New MySqlParameter("numero_sintegra", nchave.Substring(3, 6)))

                insertSQL.ExecuteNonQuery()

                oConn.Close()

            End If


        Catch ex As Exception
            ret_salvo = False
            dgverro.Rows.Add(ex.Message, Now)
        End Try

        Return ret_salvo
    End Function

    Private Function Salvar_NFe_site(ByVal p As String, ByVal nchave As String, ByVal nome_emi As String, ByVal cnpj_emi As String, ByVal ie As String, ByVal valor_nfe As String, ByVal Data_aut As Date, ByVal Tipo_nf As String, ByVal xml As String, ByVal data_emi As Date)
        Dim ret As Integer = 0
        Dim SQLcommand As MySqlCommand
        Dim ret_salvo As Boolean = True

        Try



            Dim sql As String = "Select * from NFe where Chave_nfe = '" & nchave & "'"

            conectar_mysqlDFe_site()

            SQLcommand = oConnS.CreateCommand

            SQLcommand.CommandText = sql

            dr = SQLcommand.ExecuteReader()


            While (dr.Read())
                ret += 1
            End While

            dr.Close()
            SQLcommand.Dispose()
            oConn.Close()



            If ret = 1 Then

                conectar_mysqlDFe_site()
                Dim insertSQL As MySqlCommand = New MySqlCommand("UPDATE NFe SET xml_nfe = @xml_nfe, Nome_emi = @Nome_emi, Cnpj_emi = @Cnpj_emi, Ie_emi = @Ie_emi, Valor_nfe = @Valor_nfe, Data_aut = @Data_aut , Tipo_nfe = @Tipo_nfe, Data_emi = @Data_emi, Numero_nfe = @Numero_nfe, Status_nfe = @Status_nfe WHERE Chave_nfe = '" & nchave & "'", oConnS)
                insertSQL.Parameters.Add(New MySqlParameter("xml_nfe", arq_bits(xml)))

                insertSQL.Parameters.Add(New MySqlParameter("Nome_emi", nome_emi))
                insertSQL.Parameters.Add(New MySqlParameter("Cnpj_emi", cnpj_emi))
                insertSQL.Parameters.Add(New MySqlParameter("Ie_emi", ie))
                insertSQL.Parameters.Add(New MySqlParameter("Valor_nfe", valor_nfe))
                insertSQL.Parameters.Add(New MySqlParameter("Data_aut", Data_aut))
                insertSQL.Parameters.Add(New MySqlParameter("Tipo_nfe", Tipo_nf))
                insertSQL.Parameters.Add(New MySqlParameter("Data_emi", data_emi))
                insertSQL.Parameters.Add(New MySqlParameter("Numero_nfe", nchave.Substring(25, 9)))
                insertSQL.Parameters.Add(New MySqlParameter("Status_nfe", "NF-e autorizada"))
                insertSQL.ExecuteNonQuery()

                oConnS.Close()


            End If

            If ret = 0 Then


                conectar_mysqlDFe_site()
                Dim insertSQL As MySqlCommand = New MySqlCommand("INSERT INTO NFe (Chave_nfe, Nome_emi, Cnpj_emi, Ie_emi, Valor_nfe, Data_aut, Tipo_nfe, xml_nfe, Data_emi, Numero_nfe, Status_nfe) VALUES (@Chave_nfe, @Nome_emi, @Cnpj_emi, @Ie_emi, @Valor_nfe, @Data_aut, @Tipo_nfe, @xml_nfe, @Data_emi, @Numero_nfe, @Status_nfe)", oConnS)

                insertSQL.Parameters.Add(New MySqlParameter("Chave_nfe", nchave))
                insertSQL.Parameters.Add(New MySqlParameter("Nome_emi", nome_emi))
                insertSQL.Parameters.Add(New MySqlParameter("Cnpj_emi", cnpj_emi))
                insertSQL.Parameters.Add(New MySqlParameter("Ie_emi", ie))
                insertSQL.Parameters.Add(New MySqlParameter("Valor_nfe", valor_nfe))
                insertSQL.Parameters.Add(New MySqlParameter("Data_aut", Data_aut))
                insertSQL.Parameters.Add(New MySqlParameter("Tipo_nfe", Tipo_nf))
                If xml = "" Then
                    insertSQL.Parameters.Add(New MySqlParameter("xml_nfe", Nothing))
                Else
                    insertSQL.Parameters.Add(New MySqlParameter("xml_nfe", arq_bits(xml)))
                End If
                insertSQL.Parameters.Add(New MySqlParameter("Data_emi", data_emi))
                insertSQL.Parameters.Add(New MySqlParameter("Numero_nfe", nchave.Substring(25, 9)))
                insertSQL.Parameters.Add(New MySqlParameter("Status_nfe", "NF-e autorizada"))

                insertSQL.ExecuteNonQuery()

                oConnS.Close()

            End If


        Catch ex As Exception

            dgverro.Rows.Add(ex.Message, Now)

        End Try


    End Function

    Private Sub Salvar_CTe(ByVal nchave As String, ByVal nome_emi As String, ByVal cnpj_emi As String, ByVal valor_cte As String, ByVal xml As String, ByVal CNPJ_rem As String, ByVal data_emi As Date, ByVal tomador As String)
        Dim ret As Integer = 0
        Dim SQLcommand As MySqlCommand


        Try



            Dim sql As String = "Select * from CTe where cnpj_dest = '" & empresa.sCNPJ & "' and  Chave_cte = '" & nchave & "'"

            conectar_mysqlDFe()

            SQLcommand = oConn.CreateCommand

            SQLcommand.CommandText = sql

            dr = SQLcommand.ExecuteReader()


            While (dr.Read())
                ret += 1
            End While

            dr.Close()
            SQLcommand.Dispose()
            oConn.Close()


            If ret = 1 Then

                conectar_mysqlDFe()
                Dim insertSQL As MySqlCommand = New MySqlCommand("UPDATE CTe SET xml_cte = @xml_cte WHERE cnpj_dest = '" & empresa.sCNPJ & "' and  Chave_cte = '" & nchave & "'", oConn)
                insertSQL.Parameters.Add(New MySqlParameter("xml_cte", arq_bits(xml)))
                insertSQL.ExecuteNonQuery()

                oConn.Close()


            End If

            If ret = 0 Then


                conectar_mysqlDFe()
                Dim insertSQL As MySqlCommand = New MySqlCommand("INSERT INTO CTe (Chave_cte, Nome_emi, Cnpj_emi, Valor_cte, xml_cte, CNPJ_rem, Data, Tomador, cnpj_dest, Numero_cte) VALUES (@Chave_nfe, @Nome_emi, @Cnpj_emi, @Valor_nfe, @xml_cte, @CNPJ_rem, @Data, @Tomador, @cnpj_dest, @Numero_cte)", oConn)

                insertSQL.Parameters.Add(New MySqlParameter("Chave_nfe", nchave))
                insertSQL.Parameters.Add(New MySqlParameter("Nome_emi", nome_emi))
                insertSQL.Parameters.Add(New MySqlParameter("Cnpj_emi", cnpj_emi))
                insertSQL.Parameters.Add(New MySqlParameter("Valor_nfe", valor_cte))

                If xml = "" Then
                    insertSQL.Parameters.Add(New MySqlParameter("xml_cte", Nothing))
                Else
                    insertSQL.Parameters.Add(New MySqlParameter("xml_cte", arq_bits(xml)))
                End If
                insertSQL.Parameters.Add(New MySqlParameter("CNPJ_rem", CNPJ_rem))
                insertSQL.Parameters.Add(New MySqlParameter("Data", data_emi))
                insertSQL.Parameters.Add(New MySqlParameter("Tomador", tomador))
                insertSQL.Parameters.Add(New MySqlParameter("cnpj_dest", empresa.sCNPJ))

                insertSQL.Parameters.Add(New MySqlParameter("Numero_cte", nchave.Substring(25, 9)))

                insertSQL.ExecuteNonQuery()

                oConn.Close()

            End If





        Catch ex As Exception
            txtinfodfe.Text = "Erro: Rotina salvar CTe, " & ex.Message
        End Try
    End Sub

    Private Function arq_bits(ByVal xml As String) As Byte()
        Dim Arq_xml() As Byte
        If xml <> "" Then
            Dim encText As New System.Text.UTF8Encoding()
            Arq_xml = encText.GetBytes(xml)
        End If

        Return Arq_xml
    End Function

    Private Sub salvar_nsu()
        Dim ret As Integer = 0
        Try

            Dim stringBuilder As StringBuilder = New StringBuilder()
            stringBuilder.Append("Select * from NSU ")

            stringBuilder.Append("where CNPJ = '" & empresa.sCNPJ & "'")


            conectar_mysqlDFe()

            Dim SQLcommand As MySqlCommand

            SQLcommand = oConn.CreateCommand

            SQLcommand.CommandText = stringBuilder.ToString

            dr = SQLcommand.ExecuteReader()


            While (dr.Read())
                ret += 1
            End While

            dr.Close()
            SQLcommand.Dispose()
            oConn.Close()


            If ret = 1 Then

                conectar_mysqlDFe()
                Dim insertSQL As MySqlCommand = New MySqlCommand("UPDATE NSU SET Ult_nsu = '" & txtultnsudfe.Text & "', Max_nsu = '" & txtmaxNSU.Text & "' WHERE CNPJ = '" & empresa.sCNPJ & "'", oConn)
                insertSQL.ExecuteNonQuery()

                oConn.Close()

            End If

            If ret = 0 Then
                Dim caminho_cert As String = Application.StartupPath & "\cert\" & cnpj_cert & Convert.ToDateTime(certificado.NotAfter.ToString).ToString("yyyy") & ".pfx"

                conectar_mysqlDFe()
                Dim insertSQL As MySqlCommand = New MySqlCommand("INSERT INTO NSU (Ult_nsu, CNPJ, Max_nsu, Cert, senha_cert) VALUES (@Ult_nsu, @CNPJ, @Max_nsu, @Cert, @senha_cert)", oConn)

                insertSQL.Parameters.Add(New MySqlParameter("Ult_nsu", txtultnsudfe.Text))
                insertSQL.Parameters.Add(New MySqlParameter("CNPJ", cnpj_cert))
                insertSQL.Parameters.Add(New MySqlParameter("Max_nsu", txtmaxNSU.Text))

                If File.Exists(caminho_cert) Then
                    insertSQL.Parameters.Add(New MySqlParameter("Cert", File.ReadAllBytes(caminho_cert)))
                Else
                    insertSQL.Parameters.Add(New MySqlParameter("Cert", Nothing))
                End If

                insertSQL.Parameters.Add(New MySqlParameter("senha_cert", Crypto.Encrypt(senha_cert)))
                insertSQL.ExecuteNonQuery()

                oConn.Close()

            End If


        Catch ex As Exception

            '  MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Rotina salvar_nsu")
            txtinfodfe.Text = "Erro: Rotina salvar_nsu, " & ex.Message
        End Try
    End Sub

    Private Sub salvar_nsucte()
        Dim ret As Integer = 0
        Try

            Dim stringBuilder As StringBuilder = New StringBuilder()
            stringBuilder.Append("Select * from NSU_cte ")

            stringBuilder.Append("where CNPJ = '" & empresa.sCNPJ & "'")


            conectar_mysqlDFe()

            Dim SQLcommand As MySqlCommand

            SQLcommand = oConn.CreateCommand

            SQLcommand.CommandText = stringBuilder.ToString

            dr = SQLcommand.ExecuteReader()


            While (dr.Read())
                ret += 1
            End While

            dr.Close()
            SQLcommand.Dispose()
            oConn.Close()


            If ret = 1 Then

                conectar_mysqlDFe()
                Dim insertSQL As MySqlCommand = New MySqlCommand("UPDATE NSU_cte SET Ult_nsu = '" & txtultnsucte.Text & "', Max_nsu = '" & txtmaxnsucte.Text & "' WHERE CNPJ = '" & empresa.sCNPJ & "'", oConn)
                insertSQL.ExecuteNonQuery()

                oConn.Close()

            End If

            If ret = 0 Then


                conectar_mysqlDFe()
                Dim insertSQL As MySqlCommand = New MySqlCommand("INSERT INTO NSU_cte (CNPJ, Ult_nsu, Max_nsu) VALUES (@CNPJ, @Ult_nsu, @Max_nsu)", oConn)

                insertSQL.Parameters.Add(New MySqlParameter("CNPJ", cnpj_cert))
                insertSQL.Parameters.Add(New MySqlParameter("Ult_nsu", txtultnsucte.Text))
                insertSQL.Parameters.Add(New MySqlParameter("Max_nsu", txtmaxnsucte.Text))

                insertSQL.ExecuteNonQuery()

                oConn.Close()

            End If


        Catch ex As Exception
            txtinfodfe.Text = "Erro: Rotina salvar_nsu CTe, " & ex.Message
            ' MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Rotina salvar_nsu")
        End Try
    End Sub

    Private Sub carregar_nsu()

        Try

            Dim stringBuilder As StringBuilder = New StringBuilder()
            stringBuilder.Append("Select * from NSU ")

            stringBuilder.Append("where CNPJ = '" & cnpj_cert & "'")


            conectar_mysqlDFe()

            Dim SQLcommand As MySqlCommand

            SQLcommand = oConn.CreateCommand

            SQLcommand.CommandText = stringBuilder.ToString

            dr = SQLcommand.ExecuteReader()


            While (dr.Read())
                txtultnsudfe.Text = dr("Ult_nsu")
                txtmaxNSU.Text = dr("Max_nsu")
            End While

            dr.Close()
            SQLcommand.Dispose()
            oConn.Close()



            Dim sql As String = "Select * from NSU_cte where CNPJ = '" & cnpj_cert & "'"

            conectar_mysqlDFe()
            SQLcommand = oConn.CreateCommand

            SQLcommand.CommandText = sql

            dr = SQLcommand.ExecuteReader()


            While (dr.Read())
                txtultnsucte.Text = dr("Ult_nsu")
                txtmaxnsucte.Text = dr("Max_nsu")
            End While

            dr.Close()
            SQLcommand.Dispose()
            oConn.Close()



        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Rotina carregar nsu")
        End Try
    End Sub

    Private Function getDataGridViewIndex(ByVal id As String) As String

        Dim r As String = "R"

        For Each row As DataGridViewRow In Me.dgvnfe.Rows

            If Not row.IsNewRow Then
                If row.Cells("chave_nfe").Value = id Then
                    Return row.Index
                End If
            End If

        Next

        Return r

    End Function


    ''' <summary>
    ''' 'Rotina abaixo gera o XML evento de Manifestação destinatario''''''''''''''''''''''''''''''''''''''''''''''''
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub gerar_evento_auto()

        Dim cont As Integer = 0

        Dim teste As New NFe()
        Dim xml As String, dataevento As String
        Dim xmlevento = New XmlDocument()
        Dim manifestacao As New NFe()




        dataevento = Now.ToString("yyyy-MM-ddTHH:mm:ss%K")




        For i As Integer = 0 To dgvnfe.Rows.Count - 1
            If dgvnfe.Rows.Item(i).Cells("tipo_nfe").Value.ToString.Substring(0, 1) = "1" Then

                If dgvnfe.Rows.Item(i).Cells(0).Value = "NF-e" Then


                    If dgvnfe.Rows.Item(i).Cells("situacao_nfe").Value <> "Sem manifestacao" Then

                        If dgvnfe.Rows.Item(i).Cells("situacao_nfe").Value <> "Ciencia da Operacao" Then
                            dgvnfe.Rows.Item(i).Cells("situacao_nfe").Value = "Sem manifestacao"
                        End If

                    End If


                    If dgvnfe.Rows.Item(i).Cells("situacao_nfe").Value = "Sem manifestacao" And dgvnfe.Rows.Item(i).Cells("cnpj_dest_grid").Value = cnpj_cert Then

                        cont += 1

                        If cont <= 20 Then

                            manifestacao.versao = "1.00"
                            '''''''''''''codico ciencia operação''''''''''''''''''
                            manifestacao.Id = "210210" + dgvnfe.Rows.Item(i).Cells("chave_nfe").Value + "01"
                            manifestacao.chave = dgvnfe.Rows.Item(i).Cells("chave_nfe").Value
                            manifestacao.coduf = "91"
                            If cnpj_cert.Length = 11 Then
                                manifestacao.cpf = cnpj_cert
                                manifestacao.cnpj = Nothing
                            Else
                                manifestacao.cnpj = cnpj_cert
                                manifestacao.cpf = Nothing
                            End If
                            manifestacao.dataenv = dataevento
                            manifestacao.codenv = "210210"
                            manifestacao.descenv = "Ciencia da Operacao"
                            manifestacao.xJust = ""
                            manifestacao.tpAmb = "1"

                            Dim xmldoc As XmlDocument = manifestacao.Gerarmanifestacaodest()

                            'assina os xml selecionados
                            Dim xmlAssinado As XmlDocument = CertificadoDigital.Assinar(xmldoc, "infEvento", certificado)
                            xml = xml + xmlAssinado.InnerXml

                        Else
                            Exit For
                        End If


                    End If

                End If

            End If
        Next

        '''''''''''''''''CRIAR E GERA LOTE DOS EVENTOS''''''''''''''''''''''''''''''''''''''''''''''''''
        If xml <> "" Then
            '''''''''''''''''''''''''''''''''''''''''''''''''''' GERA O ARQUIVO XML DA MANIFESTAÇÃO''''''''''''''''''''''''''''''''''
            xmlevento.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><envEvento versao=""1.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><idLote>" & teste.GerarLoteNfe_dfe() & "</idLote>" & xml & "</envEvento>")
            xmlevento.Save(Application.StartupPath & "\XML\evento.xml")

            'Valida o XML assinado
            Dim resultado As String = ValidaXML.ValidarXML(xmlevento, Application.StartupPath & "\Esquemas_XML_NF-e\envConfRecebto_v1.00.xsd")

            If resultado.Trim().Length <> 0 Then
                MsgBox(resultado)
                ' resultado = "Xml gerado com sucesso, nenhum erro encontrado"
                Exit Sub
            End If

            Using xmltw As New XmlTextWriter(Application.StartupPath & "\XML\evento_auto.xml", New UTF8Encoding(False))
                xmlevento.WriteTo(xmltw)
                xmltw.Close()
            End Using


            '''''''''''''''''Rotina para enviar manifestacao da RFB''''''''


            txtinfodfe.Text = "Consulta DFe Realizado / Aguarde, Realizando Manifestacao (Ciencia Operacao Automatica)..."
            manifestacao_dest_auto()

        Else

            Invoke(Sub() Pic_prog.Visible = False)
            Invoke(Sub() bntcancelar.Visible = False)
        End If
    End Sub


    ''' <summary>
    ''' 'Rotina abaixo gera o XML evento de Manifestação destinatario''''''''''''''''''''''''''''''''''''''''''''''''
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub gerar_evento_nfe(ByVal i As String, ByVal codevento As String, desc_event As String, just As String)



        Dim teste As New NFe()
        Dim xml As String, dataevento As String
        Dim xmlevento = New XmlDocument()
        Dim manifestacao As New NFe()



        If horaverao = True Then
            dataevento = Now.ToString("yyyy-MM-ddTHH:mm:ss") + "-02:00"
        Else
            'dataevento = Now.ToString("yyyy-MM-ddTHH:mm:ss") + "-03:00"
            dataevento = "2025-09-07T10:00:00-03:00"
        End If


        txtinfodfe.Text = "Gerando xml manifestação, aguarde...."



        manifestacao.versao = "1.00"
        '''''''''''''codico ciencia operação''''''''''''''''''
        manifestacao.Id = codevento + "31250905017780000287550030150134261631995132" + "01"
        manifestacao.chave = "31250905017780000287550030150134261631995132"
        manifestacao.coduf = "91"
        manifestacao.cnpj = "20131534000164"
        manifestacao.dataenv = dataevento
        manifestacao.codenv = codevento
        manifestacao.descenv = desc_event
        manifestacao.xJust = just
        manifestacao.tpAmb = "1"


        Dim xmldoc As XmlDocument = manifestacao.Gerarmanifestacaodest()

        ' xmldoc.Save(Application.StartupPath & "\XML\manifestacaoNaoAssinado.xml")

        'assina os xml selecionados
        Dim xmlAssinado As XmlDocument = CertificadoDigital.Assinar(xmldoc, "infEvento", certificado)

        Dim teste12 As String = xmlAssinado.InnerXml

        '''''''''''''''''''''''''''''''''''''''''''''''''''' GERA O ARQUIVO XML DA MANIFESTAÇÃO''''''''''''''''''''''''''''''''''
        xmlevento.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><envEvento versao=""1.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><idLote>" & teste.GerarLoteNfe_dfe() & "</idLote>" & xmlAssinado.InnerXml & "</envEvento>")
        xmlevento.Save(Application.StartupPath & "\XML\evento.xml")

        'Valida o XML assinado
        Dim resultado As String = ValidaXML.ValidarXML(xmlevento, Application.StartupPath & "\Esquemas_XML_NF-e\Evento_ManifestaDest\envConfRecebto_v1.00.xsd")

        If resultado.Trim().Length <> 0 Then
            MsgBox(resultado)
            '  dgvdferet.CurrentRow.Cells("  situacao_nfe").Value = resultado
            ' resultado = "Xml gerado com sucesso, nenhum erro encontrado"
            Exit Sub
        End If

        Using xmltw As New XmlTextWriter(Application.StartupPath & "\XML\evento_auto.xml", New UTF8Encoding(False))
            xmlevento.WriteTo(xmltw)
            xmltw.Close()
        End Using



        Dim rotina1 As Thread
        Control.CheckForIllegalCrossThreadCalls = False
        rotina1 = New Thread(AddressOf manifestacao_dest_auto)
        rotina1.Start()


    End Sub
    ''' <summary>
    ''' 'Rotina abaixo envia manifestação do destinatario automatica''''''''''''''''''''''''''''''''''''''''''''''''
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub manifestacao_dest_auto()
        Dim ret As Boolean = False
        Dim retEnvEvento As New retEnvEvento

        txtinfodfe.Text += vbCrLf & "Enviando Manifestação Destinatário para RFB..."

        Dim xmlretcanc = New XmlDocument()

        '   Try



        'função envia o xml para receita''''''''''''''''''''''''''''''''''
        retEnvEvento = WebS.nfeRecepcaoEvento4new("an", Application.StartupPath & "\XML\evento_auto.xml", cboambdfe.Text.Substring(0, 1))

        If reterro <> "" Then
            txtinfodfe.Text = reterro
            reterro = String.Empty
            Invoke(Sub() Pic_prog.Visible = False)
            Invoke(Sub() bntcancelar.Visible = False)
            Exit Sub
        End If

        If retEnvEvento.cStat <> "128" Then
            txtinfodfe.Text = retEnvEvento.xMotivo
            Invoke(Sub() Pic_prog.Visible = False)
            Invoke(Sub() bntcancelar.Visible = False)
            Exit Sub
        End If


        If retEnvEvento.cStat = "128" Then

            '  frmretmanifest.Label2.Text = "Retorno Da SEFAZ das NFe Enviadas para Manifestação"
            txtinfodfe.Text += vbCrLf & "Recebendo Retorno da RFB, manifestacao destinatario:"

            For Each RetC In retEnvEvento.retEvento

                ''''''''''''''''Rotina abaixo para evento desconhecimento da operação com retorno de nfe ja cancelada'''''''''''''''''


                If RetC.infEvento.cStat = "651" Then
                    ret = True

                    conectar_mysqlDFe()
                    Dim insertSQL As MySqlCommand = New MySqlCommand("UPDATE NFe SET Status_nfe = 'NFe Cancelada', nprot_canc = '" & RetC.infEvento.nProt & "', xmot_manif = '" & RetC.infEvento.xEvento & "' WHERE cnpj_dest = '" & cnpj_cert & "' and Chave_nfe = '" & RetC.infEvento.chNFe & "'", oConn)

                    insertSQL.ExecuteNonQuery()

                    oConn.Close()

                    ''''''''''''''Salvar no site''''''''''''''''
                    Try

                        '  conectar_mysqlDFe_site()
                        '    Dim insertSQL2 As MySqlCommand = New MySqlCommand("UPDATE NFe SET Status_nfe = 'NFe Cancelada', nprot_canc = '" & RetC.infEvento.nProt & "', xmot_manif = '" & RetC.infEvento.xEvento & "' WHERE Chave_nfe = '" & RetC.infEvento.chNFe & "'", oConnS)

                        '   insertSQL2.ExecuteNonQuery()

                        '   oConnS.Close()

                    Catch ex As Exception
                        dgverro.Rows.Add(ex.Message, Now)
                    End Try


                End If

                If RetC.infEvento.cStat = "135" Or RetC.infEvento.cStat = "136" Or RetC.infEvento.cStat = "596" Or RetC.infEvento.cStat = "573" Then
                    ret = True

                    conectar_mysqlDFe()
                    Dim insertSQL As MySqlCommand = New MySqlCommand("UPDATE NFe SET nprot_manif = '" & RetC.infEvento.nProt & "', xmot_manif = '" & RetC.infEvento.xEvento & "' WHERE cnpj_dest = '" & cnpj_cert & "' and  Chave_nfe = '" & RetC.infEvento.chNFe & "'", oConn)

                    insertSQL.ExecuteNonQuery()

                    oConn.Close()


                    ''''''Salvar no site''''''''''''''''''''
                    Try
                        '   conectar_mysqlDFe_site()
                        '   Dim insertSQL4 As MySqlCommand = New MySqlCommand("UPDATE NFe SET nprot_manif = '" & RetC.infEvento.nProt & "', xmot_manif = '" & RetC.infEvento.xEvento & "' WHERE Chave_nfe = '" & RetC.infEvento.chNFe & "'", oConnS)

                        '   insertSQL4.ExecuteNonQuery()

                        '   oConnS.Close()
                    Catch ex As Exception
                        dgverro.Rows.Add(ex.Message, Now)
                    End Try

                End If



                If ret = False Then
                    conectar_mysqlDFe()
                    Dim insertSQL As MySqlCommand = New MySqlCommand("UPDATE NFe SET xmot_manif = '" & RetC.infEvento.xEvento & "' WHERE cnpj_dest = '" & cnpj_cert & "' and Chave_nfe = '" & RetC.infEvento.chNFe & "'", oConn)

                    insertSQL.ExecuteNonQuery()

                    oConn.Close()
                End If

                '''''''''''''''''Pesquisa e passa o retorno para grid de manifestacao'''
                Dim result As String = getDataGridViewIndex(RetC.infEvento.chNFe)

                If RetC.infEvento.cStat = "135" Or RetC.infEvento.cStat = "136" Then

                    If result <> "R" Then
                        txtinfodfe.Text += vbCrLf & RetC.infEvento.chNFe & " | " & RetC.infEvento.xEvento

                        dgvnfe.Rows.Item(result).Cells("situacao_nfe").Value = RetC.infEvento.xEvento

                        dgvnfe.Rows.Item(result).Cells(1).Style.BackColor = Color.LightGreen
                    End If

                Else

                    txtinfodfe.Text += vbCrLf & RetC.infEvento.chNFe & " | " & RetC.infEvento.xMotivo
                    If result <> "R" Then
                        dgvnfe.Rows.Item(result).Cells("situacao_nfe").Value = RetC.infEvento.xMotivo

                        dgvnfe.Rows.Item(result).Cells(1).Style.ForeColor = Color.White
                        dgvnfe.Rows.Item(result).Cells(1).Style.BackColor = Color.DarkRed
                    End If

                End If

            Next



        End If

        txtinfodfe.Text = "Ultimo Processo de Consulta DFe Realizado em: " & Now
        Invoke(Sub() Pic_prog.Visible = False)


        '  Catch ex As Exception

        'txtinfodfe.Text = "Erro Rotina manifestacao_dest_auto: " & ex.Message
        ' Invoke(Sub() Pic_prog.Visible = False)
        ' End Try

    End Sub

    Private Sub bntcancelar_Click(sender As Object, e As EventArgs) Handles bntcancelar.Click

        Try
            If rotina_dfe.IsAlive Then
                rotina_dfe.Abort()
                MsgBox("execução Cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
                txtinfodfe.Text = "Execução Cancelada em: " & Now
                Pic_prog.Visible = False
                salvar_nsu()
            End If
        Catch ex As Exception

        End Try


    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblhoradfe.Text = Now.ToString("HH:mm:ss")
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        frminfocertificado.carregar(certificado)

        frminfocertificado.ShowDialog()
    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frm_pesquisacte.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        bar_status.Visible = True
        Dim bytePicData() As Byte
        Dim rs As New ADODB.Recordset
        conectar_DFe()
        rs.Open("select * from NFe_consultadadfe", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        bar_status.Value = 0
        bar_status.Maximum = rs.RecordCount

        Do While rs.EOF = False
            Dim data As Date


            If rs.Fields("Data_Emissao").Value.ToString = "" Then
                data = Now.Date
            Else
                data = rs.Fields("Data_Emissao").Value
            End If

            Dim data2 As Date
            If rs.Fields("data_consulta").Value.ToString = "" Then
                data2 = Now.Date
            Else
                data2 = rs.Fields("data_consulta").Value
            End If


            If rs.Fields("XML_NFe").Value.ToString <> "" Then

                bytePicData = rs.Fields("XML_NFe").Value
                Try
                    Salvar_NFe("3", rs.Fields("chave_nfe").Value, rs.Fields("Nome_emi").Value, rs.Fields("CNPJ_Emi").Value, rs.Fields("IE_emi").Value, rs.Fields("Valor_nfe").Value, data2, rs.Fields("Tipo_nf").Value, Encoding.UTF8.GetString(bytePicData), Convert.ToDateTime(data).ToString("dd/MM/yyyy"))
                Catch ex As Exception
                    dgvnfe.Rows.Add("erroimp", "", rs.Fields("chave_nfe").Value)
                End Try
            Else
                Salvar_NFe("6", rs.Fields("chave_nfe").Value, rs.Fields("Nome_emi").Value, rs.Fields("CNPJ_Emi").Value, rs.Fields("IE_emi").Value, rs.Fields("Valor_nfe").Value, data2, rs.Fields("Tipo_nf").Value, Nothing, Convert.ToDateTime(data).ToString("dd/MM/yyyy"))
                If rs.Fields("situacao_nfe").Value = "Confirmada Operacao" Or rs.Fields("situacao_nfe").Value.ToString = "" Then

                    dgvnfe.Rows.Add("semxml", "", rs.Fields("chave_nfe").Value)
                End If

            End If
            rs.MoveNext()

            Application.DoEvents()
            Thread.Sleep(1)
            bar_status.Value += 1


        Loop

        cn_DFe.Close()

        MsgBox("Arquivos Importados !")
    End Sub


    ''' <summary>
    ''' 'Rotina abaixo calcula a Tempo de uma execução para outra''''''''''''''''''''''''''''''''''''''''''''''''
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CalcucarHora()

        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")
        If arquivoIni.KeyExists("intenvalotempo", "DFe") = False Then
            arquivoIni.Write("intenvalotempo", "01:00:00", "DFe")
        End If

        intervalo_tempo = arquivoIni.Read("intenvalotempo", "DFe")

        Dim NewDT As DateTime = Now()
        NewDT = NewDT.AddHours(intervalo_tempo.Substring(0, 2)) 'It adds 8 hours from the current datetime.
        NewDT = NewDT.AddMinutes(intervalo_tempo.Substring(3, 2))
        NewDT = NewDT.AddSeconds(intervalo_tempo.Substring(6, 2))

        lblhoraprog.Text = NewDT

    End Sub

    Private Async Sub bntpesqDFe_Click(sender As Object, e As EventArgs) Handles bntpesqDFe.Click

        If chkBucketS3.Checked = True Then
            ' 1. Executa e AGUARDA terminar completamente
            Pic_prog.Visible = True
            Await PesquisarBucketS3Dfe()
            Pic_prog.Visible = False
            ' 2. Agora que terminou, inicia a próxima parte
            Control.CheckForIllegalCrossThreadCalls = False
            rotina_dfe = New Thread(AddressOf DFeconsulta_CTe4)
            rotina_dfe.SetApartmentState(ApartmentState.STA)
            rotina_dfe.Start()

        Else

            If controleExec = 1 Then
                executar_dfe()
                controleExec = 2
            Else
                If validar_ultima_exec() = False Then
                    MsgBox("Aguarde o intervalo de 1 hora para nova consulta !", MsgBoxStyle.Exclamation, "Aviso !")
                Else
                    executar_dfe()
                End If
            End If
        End If

    End Sub
    Private Sub Texecucao_dfe_Tick(sender As Object, e As EventArgs) Handles Texecucao_dfe.Tick

        Dim dataHoraPar As DateTime = Convert.ToDateTime(lblhoraprog.Text)
        Dim diferenca As TimeSpan = dataHoraPar - Now

        lblfaltamexec.Text = diferenca.Hours.ToString("D2") & ":" & diferenca.Minutes.ToString("D2") & ":" & diferenca.Seconds.ToString("D2")

        lblhoradfe.Visible = True
        If Now.ToString("dd/MM/yyyy HH:mm:ss") = lblhoraprog.Text Then
            executar_dfe()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If lblon.Visible = True Then
            MsgBox("O Servidor já esta ativo !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        '  If cbocert.Text = "" Then
        'MsgBox("Selecione um Certificado Digital para Conexao na SEFAZ ?", MsgBoxStyle.Exclamation, "Aviso !")
        '  cbocert.Focus()
        '  Exit Sub
        '  End If

        ativar_servidor()

        If dgvhost.RowCount <> 0 Then
            dgvhost.CurrentCell = Me.dgvhost.Rows(dgvhost.Rows.Count - 1).Cells(0)
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        PararServico()
    End Sub

    Private Sub ativar_servidor()
        '' Dim baseAddress As String = "http://*:8901"

        '' lblurlhost.Text = "Url Host" & baseAddress
        Dim baseAddress As String = "http://localhost:8900"
        If webApp3 IsNot Nothing Then Return
        webApp3 = WebApp.Start(Of Startup)(baseAddress)

        lblon.Visible = True
        picon.Visible = True

        Timerhost.Enabled = True
        gerar_evento_host("Servidor esta Online !", "ativa")

        lblof.Visible = False
        picoff.Visible = False
    End Sub

    Public Sub PararServico()
        Try
            If webApp3 Is Nothing Then Return
            webApp3.Dispose()
            webApp3 = CType(Nothing, IDisposable)

            picoff.Visible = True
            lblof.Visible = True

            gerar_evento_host("Servidor Foi Desconectado !", "ativa")
            Timerhost.Dispose()

            dgvhost.Rows.Add("Servidor Foi Desconectado !", Now)

            lblon.Visible = False
            picon.Visible = False

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub Timerhost_Tick(sender As Object, e As EventArgs) Handles Timerhost.Tick
        Try
            For Each row As DataRow In tabe.Rows
                dgvhost.Rows.Add(row.Item("evento"), row.Item("data"))
            Next
            tabe.Rows.Clear()
            If dgvhost.RowCount <> 0 Then
                dgvhost.CurrentCell = Me.dgvhost.Rows(dgvhost.Rows.Count - 1).Cells(0)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Timer_status_inter_Tick(sender As Object, e As EventArgs) Handles Timer_status_inter.Tick
        If IsConectedToHost(New Uri("http://www.google.com")) = True Then
            Pic_on_inter.Visible = True
            Pic_off_inter.Visible = False
        Else
            Pic_on_inter.Visible = False
            Pic_off_inter.Visible = True
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)
        frmcert.ShowDialog()
    End Sub

    Private Sub carregar_cbocert()
        Dim di As New System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory & "\cert")
        Dim aryFi As System.IO.FileInfo() = di.GetFiles("*.pfx")
        Dim fi As System.IO.FileInfo
        cbocert.Items.Clear()
        For Each fi In aryFi
            cbocert.Items.Add(fi.Name.Substring(0, fi.Name.Length - 4))
        Next
    End Sub


    Private Sub VisualizarNFeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizarNFeToolStripMenuItem.Click
        panel_chave.Visible = False

        If dgvnfe.RowCount <> 0 Then
            If dgvnfe.CurrentRow.Cells("xml_nfe").Value <> "" Then
                frmxml.abrir_xml(dgvnfe.CurrentRow.Cells("xml_nfe").Value)
            End If
        End If

        frmxml.ShowDialog()
    End Sub

    Private Sub dgvnfe_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvnfe.CellClick
        If e.ColumnIndex = 0 Then

            If dgvnfe.CurrentRow.Cells(0).Value = "NF-e + xml" Then

                If dgvnfe.CurrentRow.Cells("xml_nfe").Value <> "" Then
                    Dim dialo_salve As New SaveFileDialog
                    dialo_salve.Filter = "Arquivo XML (.xml)|*.xml"
                    dialo_salve.FileName = dgvnfe.CurrentRow.Cells("chave_nfe").Value

                    If dialo_salve.ShowDialog() = Windows.Forms.DialogResult.OK Then

                        Dim Xml_danfe As XmlDocument = New XmlDocument
                        Xml_danfe.LoadXml(dgvnfe.CurrentRow.Cells("xml_nfe").Value)
                        Xml_danfe.Save(dialo_salve.FileName)


                        MsgBox("XML salvo com Sucesso !", MsgBoxStyle.Information, "Aviso !")

                    End If

                End If

            End If

        End If
    End Sub

    Private Sub dgvnfe_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvnfe.CellContentClick

    End Sub

    Private Sub dgvnfe_SelectionChanged(sender As Object, e As EventArgs) Handles dgvnfe.SelectionChanged
        If dgvnfe.RowCount <> 0 Then
            mskchave.Text = dgvnfe.CurrentRow.Cells("chave_nfe").Value
        End If
    End Sub

    Private Sub VisualizarNFePortalNacionalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizarNFePortalNacionalToolStripMenuItem.Click
        panel_chave.Visible = False
        frmportalnfe.tipo = "Consulta"
        frmportalnfe.chave = mskchave.Text
        frmportalnfe.WebBrowser1.ScriptErrorsSuppressed = True
        frmportalnfe.ShowDialog()
    End Sub

    Private Sub pesquisa_chave()

        panel_chave.Visible = False

        If mskchave.Text = "" Then
            MsgBox("Informe a Chave de Acesso da NFe ?", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        Try

            tipo_consulta = "DFe_cons"
            tipo_consulta = "DFe_cons_chave"
            chave = mskchave.Text
            bntcancelar.Visible = True
            txtinfodfe.Text = "Aguarde, Sistema em execução (Cosulta Chave NFe)...."
            Control.CheckForIllegalCrossThreadCalls = False
            rotina_dfe = New Thread(AddressOf DFeconsulta_nfe4)
            rotina_dfe.SetApartmentState(ApartmentState.STA)
            rotina_dfe.Start()
        Catch ex As Exception
            txtinfodfe.Text = "Rotina (pesquisa_chave): " & ex.Message
        End Try


    End Sub


    Private Sub ConsultaChaveViaWebserviceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaChaveViaWebserviceToolStripMenuItem.Click
        pesquisa_chave()
    End Sub

    Private Sub mskchave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskchave.KeyPress
        If (e.KeyChar = Chr(13)) Then
            pesquisa_chave()
        End If
    End Sub


    Private Sub CienciaOperacaoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CienciaOperacaoToolStripMenuItem.Click
        If mskchave.Text = "" Then
            MsgBox("Informe a Chave de Acesso da NFe ?", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If
        gerar_evento_nfe(dgvnfe.CurrentRow.Index, "210210", "Ciencia da Operacao", "")
    End Sub

    Private Sub ConfirmacaoOperacaoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfirmacaoOperacaoToolStripMenuItem.Click
        If mskchave.Text = "" Then
            MsgBox("Informe a Chave de Acesso da NFe ?", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If
        gerar_evento_nfe(dgvnfe.CurrentRow.Index, "210200", "Confirmacao da Operacao", "")
    End Sub

    Private Sub DesconhecimentoDaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesconhecimentoDaToolStripMenuItem.Click
        If mskchave.Text = "" Then
            MsgBox("Informe a Chave de Acesso da NFe ?", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If
        gerar_evento_nfe(dgvnfe.CurrentRow.Index, "210220", "Desconhecimento da Operacao", "")
    End Sub

    Private Sub OperaçãoNãoRealizadaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperaçãoNãoRealizadaToolStripMenuItem.Click
        If mskchave.Text = "" Then
            MsgBox("Informe a Chave de Acesso da NFe ?", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        Dim valor As Object
        valor = InputBox("Informe o Motivo da Não Realização da Operação (Campo Obrigatorio)" & vbCrLf & vbCrLf & vbCrLf & "Exemplo abaixo:",
                           "Manifestação NF-e", "Declarando que a Operação não foi Realizada, com Recusa do Recebimento da mercadoria.")

        If valor = "" Then
            MsgBox("O campo Motivo deve estar Preenchido ?", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If


        gerar_evento_nfe(dgvnfe.CurrentRow.Index, "210240", "Operacao nao Realizada", valor)
    End Sub

    Private Sub chkmanifes_ChangeUICues(sender As Object, e As UICuesEventArgs) Handles chkmanifes.ChangeUICues

    End Sub

    Private Sub chkmanifes_LostFocus(sender As Object, e As EventArgs) Handles chkmanifes.LostFocus
        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")
        arquivoIni.Write("ativa", chkmanifes.Checked, "MANIFESTO_AUTOMATICO")
    End Sub

    Private Sub SalvarNFeBancoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalvarNFeBancoToolStripMenuItem.Click

        For i As Integer = 0 To dgvnfe.RowCount - 1

            If dgvnfe.Rows.Item(i).DefaultCellStyle.BackColor = Color.Red Then


                If dgvnfe.Rows.Item(i).Cells("xml_nfe").Value <> "" Then

                    Dim ret As Boolean = Salvar_NFe("4", dgvnfe.Rows.Item(i).Cells("chave_nfe").Value, dgvnfe.Rows.Item(i).Cells("Nome_emi_nfe").Value, dgvnfe.Rows.Item(i).Cells("cnpj_nfe").Value, dgvnfe.Rows.Item(i).Cells("ie_nfe").Value, dgvnfe.Rows.Item(i).Cells("vlr_nfe").Value, dgvnfe.Rows.Item(i).Cells("data_prot").Value, dgvnfe.Rows.Item(i).Cells("tipo_nfe").Value, dgvnfe.Rows.Item(i).Cells("xml_nfe").Value, dgvnfe.Rows.Item(i).Cells("Data_emi_nfe").Value)

                    If ret = True Then
                        '  MsgBox("Registro Salvo com sucesso !", MsgBoxStyle.Information, "Atenção !")

                        With Me.dgvnfe.Rows.Item(i).DefaultCellStyle
                            .BackColor = Color.White
                            .ForeColor = Color.Black
                        End With

                    Else
                        MsgBox("Erro ao salvar o registro !", MsgBoxStyle.Exclamation, "Atenção !")
                    End If

                End If

            End If
        Next


    End Sub

    Private Sub NotifyIcon1_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon1.DoubleClick
        If WindowState = FormWindowState.Minimized Then

            Show()

            WindowState = FormWindowState.Normal

        End If
    End Sub

    Private Sub frmdfe2_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If (WindowState = FormWindowState.Minimized) Then
            Hide()
        End If
    End Sub



#Region "'''''''''''''Panel de NFCe''''''''''''''"

    Private Sub PESQUISA_NFCE()
        Dim dr As MySqlDataReader
        Dim ret As Integer = 0
        Dim xml As String
        Dim sql As String, aut As String, campo As String
        dgvws.Rows.Clear()

        sql = "select cfe.caixa, cfe.tp, cfe.nprot, cfe.cod_sit, cfe.RV, cfe.valor_total, cfe.numero_nfce, cfe.data_emi, cfe.chave_nfce, cfe.sit_nfce, cfe.nRec, cfe.xml, rv.chave_cont, rv.status_rv, cfe.cnpj_dest from cfe INNER JOIN rv ON rv.rv = cfe.RV where cfe.data_emi between '" & Convert.ToDateTime(mskdatainicial.Text).ToString("yyyy-MM-dd 00:00:00") & "' and '" & Convert.ToDateTime(mskdatafinal.Text).ToString("yyyy-MM-dd 23:59:59") & "'"

        If chkc.Checked = True Then
            sql = sql + " and cfe.tp = '9'"
        End If

        If chkrv.Checked = True Then
            campo = txtrv.Text.PadLeft(9, "0")
            sql = sql + " and cfe.rv = '" & campo & "'"
        End If

        If chkstatus.Checked = True Then
            Dim c As Integer
            If cbostatus.Text = "NFC-e Inutilizada" Then
                c = 4
            End If
            If cbostatus.Text = "NFC-e Cancelada" Then
                c = 3
            End If
            If cbostatus.Text = "NFC-e Autorizada" Then
                c = 100
            End If
            sql = sql + " and cfe.cod_sit = '" & c & "'"
        End If

        If chknumero.Checked = True Then
            campo = txtnumero.Text.PadLeft(9, "0")
            sql = sql + " and cfe.numero_nfce = '" & campo & "'"
        End If

        If chkcaixa.Checked = True Then
            campo = cbocaixa.Text.TrimStart("0")
            sql = sql + " and cfe.caixa = '" & campo & "'"
        End If

        If chkdest.Checked = True Then
            sql = sql + " and cfe.cnpj_dest = '" & mskdest.Text & "'"
        End If

        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())

            If dr("cod_sit") = "100" Then
                aut = "Autorizada"
            Else
                If dr("cod_sit").ToString.Length >= 2 Then
                    aut = "Rejeitada"
                End If
            End If

            If dr("cod_sit") = "1" Or dr("cod_sit") = "2" Or dr("cod_sit") = "5" Then
                aut = "Pendente"
            End If

            If dr("cod_sit") = "3" Then
                aut = "Cancelada"
            End If

            If dr("cod_sit") = "4" Then
                aut = "Inutilizada"
            End If

            If dr("cod_sit") = "9" Then
                aut = "Contigencia"
            End If

            If dr("xml").ToString <> "" Then
                xml = Base64Decode(dr("xml"))
            End If

            If dgvws_pesqn(dr("caixa") & dr("numero_nfce")) = "R" Then

                dgvws.Rows.Add(False, dr("caixa"), aut, dr("RV"), dr("numero_nfce"), dr("data_emi"), dr("chave_nfce"), dr("sit_nfce"), dr("nRec"), xml, dr("nprot"), dr("chave_cont"), dr("valor_total"), dr("caixa") & dr("numero_nfce"), tp(dr("tp")))

            End If
            ret += 1
        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()



        cor_grid()

        MsgBox("Pesquisa realizada, Total registro encontrado: " & ret, MsgBoxStyle.Information, "Aviso Pesquisa !")

    End Sub

    Private Function tp(ByVal valor As Integer) As String

        If valor = 1 Then
            Return "NOR"
        Else
            Return "CON"
        End If
    End Function
    Private Sub cor_grid()


        For Each row As DataGridViewRow In dgvws.Rows

            If row.Cells("status").Value = "Autorizada" Then
                ' row.Cells("status").Style.BackColor = Color.LightGreen
                ' row.Cells("status").Style.ForeColor = Color.Blue

                With row.DefaultCellStyle
                    .BackColor = Color.LightGreen
                    .ForeColor = Color.Blue
                End With
            End If

            If row.Cells("status").Value = "Cancelada" Then
                ' row.Cells("status").Style.BackColor = Color.Red
                '  row.Cells("status").Style.ForeColor = Color.White

                With row.DefaultCellStyle
                    .BackColor = Color.Red
                    .ForeColor = Color.White
                End With
            End If

            If row.Cells("status").Value = "Rejeitada" Then
                ' row.Cells("status").Style.BackColor = Color.Red
                '  row.Cells("status").Style.ForeColor = Color.White

                With row.DefaultCellStyle
                    .BackColor = Color.Sienna
                    .ForeColor = Color.White
                End With
            End If

            If row.Cells("status").Value = "Inutilizada" Then
                ' row.Cells("status").Style.BackColor = Color.Red
                '  row.Cells("status").Style.ForeColor = Color.White

                With row.DefaultCellStyle
                    .BackColor = Color.PeachPuff
                    .ForeColor = Color.Black
                End With
            End If

            If row.Cells("status").Value = "Contigencia" Then
                '  row.Cells("status").Style.BackColor = Color.RoyalBlue
                '  row.Cells("status").Style.ForeColor = Color.White

                With row.DefaultCellStyle
                    .BackColor = Color.Thistle
                    .ForeColor = Color.Blue
                End With
            End If

            If row.Cells("status").Value = "Pendente" Then
                ' row.Cells("status").Style.BackColor = Color.LightSlateGray
                '  row.Cells("status").Style.ForeColor = Color.White

                With row.DefaultCellStyle
                    .BackColor = Color.LightSlateGray
                    .ForeColor = Color.White
                End With
            End If
        Next
    End Sub

    Private Sub consulta_recibo_nfce(ByVal i As Integer, ByVal cont As Integer, ByVal cont2 As Integer)
        Dim retConsReciNFe As retConsReciNFe
        Dim chv As String
        '  Try

        txtinfo_nfce.Text = "Aguarde, Consultando Status Recibo NFC-e, " & cont2 & " de " & cont & "..."
        txtinfo_nfce.Refresh()

        retConsReciNFe = WebS.ConsultaRecLote(dgvws.Rows.Item(i).Cells("nRec").Value, empresa.ambiente_nfe, dgvws.Rows.Item(i).Cells("chave_nfce").Value)

        If retConsReciNFe.cStat = "104" Then


            If retConsReciNFe.protNFe.infProt.cStat = "100" Then
                Dim dados As XmlDocument = New XmlDocument

                If dgvws.Rows.Item(i).Cells("xml_nfcegrid").Value <> "" Then
                    dgvws.Rows.Item(i).Cells("xml_nfcegrid").Value = dgvws.Rows.Item(i).Cells("xml_nfcegrid").Value.ToString.Replace("<?xml version=""1.0"" encoding=""utf-8""?>", "")

                    xmldoc.LoadXml(dgvws.Rows.Item(i).Cells("xml_nfcegrid").Value)



                    ''''''''''''''''''''''''''Valida chave acesso'''''''''''''''''''''''
                    Dim xmllist As System.Xml.XmlNodeList
                    Dim xmlnode As XmlNode

                    xmllist = xmldoc.GetElementsByTagName("infNFe")

                    For Each xmlnode In xmllist
                        chv = xmlnode.Attributes.ItemOf("Id").InnerText.Substring(3, 44)
                    Next




                    dados = GerarNotaProcessadanfce(SepararNota_prot34(xmldoc.OuterXml), retConsReciNFe.xmlprot)

                    Dim Path As String = Application.StartupPath & "\NFCe"
                    If Not Directory.Exists(Path) Then Directory.CreateDirectory(Path)

                    dados.Save(Path & "\NFCe-" & dgvws.Rows.Item(i).Cells("chave_nfce").Value & ".xml")

                End If

                If cont = 1 Then
                    MsgBox(retConsReciNFe.protNFe.infProt.chNFe & vbCrLf & retConsReciNFe.protNFe.infProt.xMotivo & vbCrLf & retConsReciNFe.protNFe.infProt.nProt & " " & Convert.ToDateTime(retConsReciNFe.protNFe.infProt.dhRecbto).ToString("dd/MM/yyyy HH:mm:ss"), MsgBoxStyle.Information, "Aviso 2!")
                End If

                '''''''''''''''''''''''''''Salva info no banco''''''''''''''''''''''''''

                If dgvws.Rows.Item(i).Cells("chave_nfce").Value.ToString.Substring(34, 1) = "9" Then
                    Dim ret2 As String = ret_valor_campo("select * from rv where chave_cont = '" & dgvws.Rows.Item(i).Cells("chave_nfce").Value & "'", "status_rv")
                    If ret2 = "Contigencia" Then
                        Dim ret As String = ret_valor_campo("select * from cfe where chave_nfce = '" & dgvws.Rows.Item(i).Cells("chave_nfce").Value & "'", "RV")
                        executa_query("update rv set status_rv = 'Pendente' where rv = '" & ret & "'")
                    End If
                End If

                dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = retConsReciNFe.protNFe.infProt.xMotivo
                dgvws.Rows.Item(i).Cells("status").Value = "Autorizada"


                If dgvws.Rows.Item(i).Cells("chave_nfce").Value <> chv Then
                    Funcoes_sist.cfe(dgvws.Rows.Item(i).Cells("chave_nfce").Value, "", "", empresa.ambiente_nfe, dgvws.Rows.Item(i).Cells("caixa").Value, "XML do banco com Divergencia de Chave acesso", "", "")
                Else
                    Funcoes_sist.cfe(dgvws.Rows.Item(i).Cells("chave_nfce").Value, "", dados.OuterXml, empresa.ambiente_nfe, dgvws.CurrentRow.Cells("caixa").Value, retConsReciNFe.protNFe.infProt.xMotivo, retConsReciNFe.protNFe.infProt.cStat, "")
                End If

                ''''''''''''''''''Rotina para cancelar nfce duplicada com contigencia''''''''''''''

                If dgvws.Rows.Item(i).Cells("chave_cont").Value <> "" Then
                    If dgvws.Rows.Item(i).Cells("chave_nfce").Value.ToString.Substring(34, 1) = "1" Then
                        gerar_cancelamento(i, True, dgvws.Rows.Item(i).Cells("chave_nfce").Value.ToString, dgvws.Rows.Item(i).Cells("prot_grid").Value.ToString, dgvws.Rows.Item(i).Cells("chave_cont").Value.ToString)
                    End If
                End If

            Else

                If retConsReciNFe.protNFe.infProt.cStat = "204" Then

                    Dim nPost As Int32 = retConsReciNFe.protNFe.infProt.xMotivo.IndexOf("nRec:")
                    Dim rec As String = retConsReciNFe.protNFe.infProt.xMotivo.Substring(nPost + 5, retConsReciNFe.protNFe.infProt.xMotivo.Length - nPost - 6).Trim
                    ' Retarquivo.Add("RecDup", rec)

                    dgvws.Rows.Item(i).Cells("nRec").Value = rec
                    conectar_mysqlDFe()
                    Dim sql2 As String = "update cfe set nRec = '" & rec & "' where chave_nfce = '" & dgvws.Rows.Item(i).Cells("chave_nfce").Value & "'"
                    Dim insertSQL2 As MySqlCommand = New MySqlCommand(sql2, oConn)

                    insertSQL2.ExecuteNonQuery()

                    oConn.Close()

                End If

                If retConsReciNFe.protNFe.infProt.cStat = "539" Then
                    consulta_recibo_nfce_auto(dgvws.Rows.Item(i).Cells("chave_nfce").Value, dgvws.Rows.Item(i).Cells("nRec").Value, dgvws.Rows.Item(i).Cells("xml_nfcegrid").Value)
                End If



                If cont = 1 Then
                    MsgBox(retConsReciNFe.protNFe.infProt.chNFe & vbCrLf & retConsReciNFe.protNFe.infProt.xMotivo, MsgBoxStyle.Information, "Aviso 3!")
                End If

                dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = retConsReciNFe.protNFe.infProt.xMotivo
                dgvws.Rows.Item(i).Cells("status").Value = "Rejeitada"

                conectar_mysqlDFe()
                Dim sql As String = "update cfe set cod_sit = '" & retConsReciNFe.protNFe.infProt.cStat & "', sit_nfce = '" & retConsReciNFe.protNFe.infProt.xMotivo & "' where chave_nfce = '" & dgvws.Rows.Item(i).Cells("chave_nfce").Value & "'"
                Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)

                insertSQL.ExecuteNonQuery()

                oConn.Close()


            End If

        Else

            If cont = 1 Then
                MsgBox(retConsReciNFe.cStat & "-" & retConsReciNFe.xMotivo, MsgBoxStyle.Information, "Aviso 4!")
            End If
            dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = retConsReciNFe.xMotivo

        End If

        cor_grid()

        Panel_nfce.Visible = False

        dgvws.Rows.Item(i).Cells(0).Value = False

        '  Catch ex As Exception
        'If reterro <> "" Then
        'dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = "Erro Rotina1: Webservice, " & reterro
        ' Else
        'dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = "Erro local1 Rotina: consulta_statusNF_online, " & ex.Message
        ' End If

        ' Invoke(Sub() Panel_nfce.Visible = False)
        '  End Try


    End Sub


    Private Sub consulta_statusNF(ByVal i As Integer, ByVal cont As Integer, ByVal cont2 As Integer)

        Dim ws As Webservice4
        Dim retConsSitNFe As retConsSitNFe
        Dim chv As String

        Try

            txtinfo_nfce.Text = "Aguarde, Consultando Status NFC-e, " & cont2 & " de " & cont & "..."
            txtinfo_nfce.Refresh()

            retConsSitNFe = WebS.ConsultaStatusNfe(dgvws.Rows.Item(i).Cells("chave_nfce").Value, empresa.ambiente_nfe)

            If retConsSitNFe.cStat = "100" Then
                If cont = 1 Then
                    MsgBox(retConsSitNFe.chNFe & vbCrLf & retConsSitNFe.protNFe.infProt.xMotivo & vbCrLf & retConsSitNFe.protNFe.infProt.nProt & " " & Convert.ToDateTime(retConsSitNFe.protNFe.infProt.dhRecbto).ToString("dd/MM/yyyy HH:mm:ss"), MsgBoxStyle.Information, "Aviso !")
                    ' MsgBox("A Nota Fiscal Autorizada !" & vbCrLf & "Chave acesso: " & retConsSitNFe.chNFe & vbCrLf & "Protocolo Aut.: " & retConsSitNFe.protNFe.infProt.nProt & vbCrLf & "Status: " & retConsSitNFe.protNFe.infProt.xMotivo, MsgBoxStyle.Information, "Aviso ")
                End If
                dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = retConsSitNFe.protNFe.infProt.xMotivo
                dgvws.Rows.Item(i).Cells("status").Value = "Autorizada"


                Dim dados As XmlDocument = New XmlDocument

                If dgvws.Rows.Item(i).Cells("xml_nfcegrid").Value <> "" Then
                    dgvws.Rows.Item(i).Cells("xml_nfcegrid").Value = dgvws.Rows.Item(i).Cells("xml_nfcegrid").Value.ToString.Replace("<?xml version=""1.0"" encoding=""utf-8""?>", "")
                    xmldoc.LoadXml(dgvws.Rows.Item(i).Cells("xml_nfcegrid").Value)


                    ''''''''''''''''''''''''rotina para validar chave acesso banco

                    Dim xmllist As System.Xml.XmlNodeList
                    Dim xmlnode As XmlNode

                    xmllist = xmldoc.GetElementsByTagName("infNFe")

                    For Each xmlnode In xmllist
                        chv = xmlnode.Attributes.ItemOf("Id").InnerText.Substring(3, 44)
                    Next



                    dados = GerarNotaProcessadanfce(SepararNota_prot34(xmldoc.OuterXml), retConsSitNFe.xmlprot)

                    Dim Path As String = Application.StartupPath & "\NFCe"
                    If Not Directory.Exists(Path) Then Directory.CreateDirectory(Path)

                    dados.Save(Path & "\NFCe-" & retConsSitNFe.chNFe & ".xml")
                End If



                If dgvws.Rows.Item(i).Cells("chave_nfce").Value <> chv Then
                    Funcoes_sist.cfe(dgvws.Rows.Item(i).Cells("chave_nfce").Value, "", "", empresa.ambiente_nfe, dgvws.Rows.Item(i).Cells("caixa").Value, "XML do banco com Divergencia de Chave acesso", "", "")
                Else
                    Funcoes_sist.cfe(dgvws.Rows.Item(i).Cells("chave_nfce").Value, "", dados.OuterXml, empresa.ambiente_nfe, dgvws.Rows.Item(i).Cells("caixa").Value, retConsSitNFe.protNFe.infProt.xMotivo, retConsSitNFe.protNFe.infProt.cStat, "")
                End If


                If dgvws.Rows.Item(i).Cells("chave_nfce").Value.ToString.Substring(34, 1) = "9" Then
                    Dim ret2 As String = ret_valor_campo("select * from rv where chave_cont = '" & dgvws.Rows.Item(i).Cells("chave_nfce").Value & "'", "status_rv")
                    If ret2 = "Contigencia" Then
                        Dim ret As String = ret_valor_campo("select * from cfe where chave_nfce = '" & dgvws.Rows.Item(i).Cells("chave_nfce").Value & "'", "RV")
                        executa_query("update rv set status_rv = 'Pendente' where rv = '" & ret & "'")
                    End If
                End If
                ''''''''''''''''''Rotina para cancelar nfce duplicada com contigencia''''''''''''''

                If dgvws.Rows.Item(i).Cells("chave_cont").Value <> "" Then
                    If dgvws.Rows.Item(i).Cells("chave_nfce").Value.ToString.Substring(34, 1) = "1" Then
                        gerar_cancelamento(i, True, dgvws.Rows.Item(i).Cells("chave_nfce").Value, dgvws.Rows.Item(i).Cells("prot_grid").Value, dgvws.Rows.Item(i).Cells("chave_cont").Value)
                    End If
                End If


            End If

            If retConsSitNFe.cStat = "101" Then

                If cont = 1 Then
                    MsgBox("A Nota Fiscal Cancelada !" & vbCrLf & "Chave acesso: " & retConsSitNFe.chNFe & vbCrLf & "Protocolo Aut. Canc.: " & retConsSitNFe.procEventoNFe.retEvento.infEvento.nProt & vbCrLf & "Status: " & retConsSitNFe.procEventoNFe.retEvento.infEvento.xMotivo, MsgBoxStyle.Exclamation, "Aviso ")
                End If
                xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & retConsSitNFe.xmlprocevent & "")
                xmldoc.Save(Application.StartupPath & "\XML_nfecanc\" & retConsSitNFe.chNFe & "-procEventoNFe.xml")
                '   MsgBox("XML de Cancelamento gerado na pasta: " & Application.StartupPath & "\XML_nfecanc", MsgBoxStyle.Information, "Aviso ")

                dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = retConsSitNFe.procEventoNFe.retEvento.infEvento.xMotivo
                dgvws.Rows.Item(i).Cells("status").Value = "Cancelada"


                conectar_mysqlDFe()
                Dim sql As String = "update cfe set cod_sit = '3', sit_nfce = '" & retConsSitNFe.procEventoNFe.retEvento.infEvento.xMotivo & "',xml = '', xml_canc = '" & Convert.ToBase64String(Encoding.UTF8.GetBytes(xmldoc.OuterXml)) & "' where chave_nfce = '" & dgvws.Rows.Item(i).Cells("chave_nfce").Value & "'"
                Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)

                insertSQL.ExecuteNonQuery()

                oConn.Close()


            End If

            If retConsSitNFe.cStat <> "100" Then
                If retConsSitNFe.cStat <> "101" Then
                    If cont = 1 Then
                        MsgBox(retConsSitNFe.cStat & "-" & retConsSitNFe.xMotivo, MsgBoxStyle.Exclamation, "Aviso ")
                    End If
                    dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = retConsSitNFe.xMotivo


                    If dgvws.Rows.Item(i).Cells("status").Value <> "Inutilizada" Then
                        ' Funcoes_sist.cfe(dgvws.Rows.Item(i).Cells("chave_nfce").Value, "", "", empresa.ambiente_nfe, dgvws.Rows.Item(i).Cells("caixa").Value, retConsSitNFe.xMotivo, retConsSitNFe.cStat, "")
                    End If

                    ''''''''''''''''''''Rotina para gerar inutilizacao da numeração''''''''''''''
                    If retConsSitNFe.cStat = "217" Then

                        If dgvws.Rows.Item(i).Cells("status").Value <> "Inutilizada" Then

                            If dgvws.Rows.Item(i).Cells("chave_nfce").Value.ToString.Substring(34, 1) <> "9" Then
                                inutilizar(i, dgvws.Rows.Item(i).Cells("chave_nfce").Value, cont, cont2)
                            End If

                        End If


                    End If


                End If
            End If

            cor_grid()


            dgvws.Rows.Item(i).Cells(0).Value = False

            Invoke(Sub() Panel_nfce.Visible = False)

        Catch ex As Exception
            If reterro <> "" Then
                dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = "Erro Rotina: Webservice, " & reterro
            Else
                dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = "Erro local Rotina: consulta_statusNF_online, " & ex.Message
            End If

            Invoke(Sub() Panel_nfce.Visible = False)
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If dgvws.Rows.Count = 0 Then
            Exit Sub
        End If

        dgvws.CurrentRow.Cells(0).Value = True
        Panel_nfce.Visible = True
        txtinfo_nfce.Text = "Aguarde, Consultando Status NFC-e..."
        Control.CheckForIllegalCrossThreadCalls = False

        rotina_nfce = New Thread(AddressOf consult_sefaz)
        rotina_nfce.SetApartmentState(ApartmentState.STA)
        rotina_nfce.Start()

    End Sub

    Private Sub consult_sefaz()
        Dim cont As Integer, cont2 As Integer


        For Each row As DataGridViewRow In dgvws.Rows
            If row.Cells(0).Value = True Then
                cont += 1
            End If
        Next


        For Each row As DataGridViewRow In dgvws.Rows
            ' dgvws.CurrentCell = row.Cells("caixa")

            If row.Cells(0).Value = True Then
                cont2 += 1

                If row.Cells("status").Value.ToString <> "Contigencia" Then

                    If row.Cells("nRec").Value.ToString = "" Then
                        consulta_statusNF(row.Index, cont, cont2)
                    Else
                        consulta_recibo_nfce(row.Index, cont, cont2)
                    End If

                End If

            End If

        Next

        cor_grid()
        Invoke(Sub() Panel_nfce.Visible = False)
    End Sub


    Private Sub Envia_celamento(ByVal i As Integer, ByVal nchave As String, Optional ByVal auto As Boolean = False)
        Dim xmlretcanc = New XmlDocument()
        Dim retEnvEvento As New retEnvEvento

        If auto = False Then
            Invoke(Sub() Panel_nfce.Visible = True)
            Invoke(Sub() txtinfo_nfce.Text = "NFCe: " & nchave & ", Enviando o Cancelamento da NFC-e para SEFAZ...")
            Invoke(Sub() Panel_nfce.Refresh())
        Else
            Invoke(Sub() lblinfo_auto.Text = "NFCe: " & nchave & ", Enviando Pedido cancelamento por substituicao...")
        End If

        ' Try


        ''''''''''''''''Rotina ativa webservice''''''''''''''''''''''''
        retEnvEvento = WebS.nfeRecepcaoEvento4new(nchave, Application.StartupPath & "\XML\nfecancelamento.xml", empresa.ambiente_nfe)



        If retEnvEvento.cStat = "128" Then

            For Each RetC In retEnvEvento.retEvento
                executa_query("update cfe set sit_nfce = '" & RetC.infEvento.xMotivo & "', xml = '', xml_canc = '' where chave_nfce = '" & RetC.infEvento.chNFe & "'")

                If RetC.infEvento.cStat <> "135" Then
                    If RetC.infEvento.cStat <> "136" Then
                        If RetC.infEvento.cStat <> "155" Then

                            If RetC.infEvento.cStat = "573" Then

                                executa_query("update cfe set cod_sit = '3', sit_nfce = 'Evento registrado e vinculado a NF-e', xml = '', xml_canc = '' where chave_nfce = '" & RetC.infEvento.chNFe & "'")

                            End If

                            If auto = False Then

                                If RetC.infEvento.cStat = "912" Then
                                    executa_query("delete from cfe where chave_nfce = '" & dgvws.Rows.Item(i).Cells("chave_cont").Value & "'")
                                    executa_query("update rv set chave_cont = '' where rv = '" & dgvws.Rows.Item(i).Cells("rv").Value & "'")
                                End If

                                dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = RetC.infEvento.cStat & "-" & RetC.infEvento.xMotivo
                                dgvws.Refresh()
                            Else
                                Invoke(Sub() lblinfo_auto.Text = lblinfo_auto.Text & ", " & RetC.infEvento.cStat & "-" & RetC.infEvento.xMotivo)
                                Invoke(Sub() lblinfo_auto.Refresh())
                            End If

                            'dgvws.CurrentCell = dgvws.Rows(i).Cells("status")

                            'MsgBox(RetC.xMotivo1, MsgBoxStyle.Exclamation, "Retorno do sefaz:")

                        End If
                    End If
                End If

                If RetC.infEvento.cStat = "135" Or RetC.infEvento.cStat = "136" Or RetC.infEvento.cStat = "155" Then

                    ' MsgBox("Retorno do Sefaz: " & retorevento.xMotivo + vbCrLf + "protocolo Canc: " + RetC.nProt, MsgBoxStyle.Information, "Retorno do Sefaz:")

                    '''''''''''''''''''''''''''''''Rotina para verificar pasta destino
                    If Directory.Exists(Application.StartupPath & "\XML_nfecanc") = False Then
                        Directory.CreateDirectory(Application.StartupPath & "\XML_nfecanc")
                    End If


                    xmlretcanc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><procEventoNFe versao=""4.00"" xmlns=""http://www.portalfiscal.inf.br/nfe"">" & xmlAssinado.InnerXml & "" & retEnvEvento.xml & "</procEventoNFe>")
                    xmlretcanc.Save(Application.StartupPath + "\XML_nfecanc\" + RetC.infEvento.chNFe + "-procEventoNFe.xml")

                    If auto = False Then
                        dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = RetC.infEvento.xMotivo
                        dgvws.Rows.Item(i).Cells("status").Value = "Cancelada"
                        '     dgvws.CurrentCell = dgvws.Rows(i).Cells("status")
                        With Me.dgvws.Rows(i).DefaultCellStyle
                            .BackColor = Color.Red
                            .ForeColor = Color.White
                        End With
                        dgvws.Refresh()

                    End If


                    executa_query("update cfe set cod_sit = '3', sit_nfce = '" & RetC.infEvento.xMotivo & "',xml = '', xml_canc = '" & Convert.ToBase64String(Encoding.UTF8.GetBytes(xmlretcanc.OuterXml)) & "' where chave_nfce = '" & RetC.infEvento.chNFe & "'")



                    Invoke(Sub() lblinfo_auto.Text = lblinfo_auto.Text & ", " & RetC.infEvento.cStat & "-" & RetC.infEvento.xMotivo)
                    Invoke(Sub() lblinfo_auto.Refresh())
                    ''''''''''''''''''''''''''########################''''''''''''''''''''''''


                    '  MsgBox("XML de Cancelamento gerado na Pasta abaixo: " + vbCrLf + Application.StartupPath + "\XML_nfecanc\", MsgBoxStyle.Information, "Aviso !")

                End If


            Next

        Else

            If auto = False Then
                dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = retEnvEvento.cStat & "-" & retEnvEvento.xMotivo
            Else
                Invoke(Sub() lblinfo_auto.Text = lblinfo_auto.Text & ", " & retEnvEvento.cStat & "-" & retEnvEvento.xMotivo)
                Invoke(Sub() lblinfo_auto.Refresh())
            End If

        End If



        ' If retEnvEvento.cStat <> "128" Then

        '  MsgBox("Retorno do Sefaz: " & retEnvEvento.xMotivo, MsgBoxStyle.Information, "Retorno do Sefaz:")
        ' End If
        If auto = False Then
            Invoke(Sub() Panel_nfce.Visible = False)
        End If






    End Sub

    Private Sub inutilizar(ByVal i As Integer, ByVal chave As String, ByVal cont As Integer, ByVal cont2 As Integer, Optional ByVal auto As Boolean = False)
        canc_sub = False
        If auto = False Then
            Invoke(Sub() Panel_nfce.Visible = True)
            Invoke(Sub() txtinfo_nfce.Text = "Aguarde, Gerando arquivo para Inutilizar, Arquivo: " & cont2 & " de " & cont)
            Invoke(Sub() Panel_nfce.Refresh())
        Else
            Invoke(Sub() lblinfo_auto.Text = "NFCe: " & chave & ", Gerando XML Inutilizacao....")
            Invoke(Sub() lblinfo_auto.Refresh())
        End If

        Dim xmlevento = New XmlDocument()
        Dim inut As New NFe()

        inut.versao = "4.00"


        inut.Id = chave.Substring(0, 4) & chave.Substring(6, 14) & chave.Substring(20, 2) & chave.Substring(22, 3) & chave.Substring(25, 9) & chave.Substring(25, 9)


        inut.tpAmb = empresa.ambiente_nfe
        inut.coduf = chave.Substring(0, 2)
        inut.ano = chave.Substring(2, 2)
        inut.cnpj = chave.Substring(6, 14)
        inut.MOD_INU = chave.Substring(20, 2)
        inut.Serie = chave.Substring(22, 3).TrimStart("0")
        inut.NumNf_Ini = chave.Substring(25, 9)
        inut.NumNf_Fin = chave.Substring(25, 9)
        inut.xJust = "Falha na Sequência de Numeração"
        Dim xmldoc As XmlDocument = inut.GerarXMLinutilizacao()

        ' xmldoc.Save("c:\teste\testecancelamentoXMLNaoAssinado.xml")

        If nfecer = "" Then
            certificado = SelecionarCertificado("")
        Else
            certificado = SelecionarCertificado(nfecer)
        End If

        'assina o xml
        xmlAssinado = CertificadoDigital.Assinar(xmldoc, "infInut", certificado)


        '''''''''''''''''''''''Valida o XML assinado

        ' xmlevento.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><inutNFe versao=""1.00"" xmlns=""http://www.portalfiscal.inf.br/nfe"">" & xmlAssinado.InnerXml & "</inutNFe>")

        Dim resultado As String = ValidaXML.ValidarXML(xmlAssinado, Application.StartupPath & "\Esquemas_XML_NF-e\inutNFe_v4.00.xsd")



        If resultado.Trim().Length = 0 Then
            '     resultado = "Xml gerado com sucesso, nenhum erro encontrado"
        End If

        If resultado.Trim().Length <> 0 Then
            If auto = False Then
                MsgBox(resultado, MsgBoxStyle.Information, "Aviso !")
                xmlAssinado.Save(Application.StartupPath & "\XML\inut-nao_assinado.xml")
                Panel_nfce.Visible = False
                Exit Sub
            End If
        End If

        Using xmltw As New XmlTextWriter(Application.StartupPath & "\XML\inut.xml", New UTF8Encoding(False))
            xmlAssinado.WriteTo(xmltw)
            xmltw.Close()
        End Using

        '''''''''''''''''''''''''''''saida da rotina


        ''''''''''''''''''''''''''''''Rotina abaixo que envia o xml de cancelamento para sefaz'''''''''''''''''''''
        '  MsgBox("XML Gerado inutilizacao !")


        ' Control.CheckForIllegalCrossThreadCalls = False
        ' Dim rotina1 As Thread = New Thread(AddressOf Envia_inutilizacao)
        ' rotina1.SetApartmentState(ApartmentState.STA)

        '   rotina1.Start(i)

        Envia_inutilizacao(i, cont, cont2, chave, auto)


    End Sub

    Private Sub Envia_inutilizacao(ByVal i As Integer, ByVal cont As Integer, ByVal cont2 As Integer, ByVal chave As String, Optional ByVal auto As Boolean = False)
        Dim xmlretcanc = New XmlDocument()
        Dim procInutNFe As New retInutNFe

        If auto = False Then
            Invoke(Sub() Panel_nfce.Visible = True)
            Invoke(Sub() txtinfo_nfce.Text = "Aguarde, Enviando o Inutilizacao da NFC-e para SEFAZ..., Arquivo: " & cont2 & " de " & cont)
            Invoke(Sub() Panel_nfce.Refresh())
        Else
            Invoke(Sub() lblinfo_auto.Text = "NFCe: " & chave & ", Enviando Pedido Inutilizacao SEFAZ...")
        End If

        Try

            procInutNFe = WebS.NfeInutilizacao(Application.StartupPath & "\XML\inut.xml", chave, empresa.ambiente_nfe)



            If procInutNFe.infInut.cStat = "102" Then
                Directory.CreateDirectory(Application.StartupPath + "\XML_Inut")

                xmlretcanc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><procInutNFe versao=""2.00"" xmlns=""http://www.portalfiscal.inf.br/nfe"">" & xmlAssinado.InnerXml & "" & procInutNFe.xml & "</procInutNFe>")
                xmlretcanc.Save(Application.StartupPath + "\XML_Inut\" + dgvws.Rows.Item(i).Cells("nnfce").Value + dgvws.Rows.Item(i).Cells("caixa").Value + ".xml")
                '  xmlretcanc.Save(Application.StartupPath + "\XML_Inut\" + procInutNFe.infInut.nProt + "-InutNfe.xml")

                If auto = False Then
                    dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = procInutNFe.infInut.xMotivo
                    dgvws.Rows.Item(i).Cells("status").Value = "Inutilizada"

                    dgvws.CurrentCell = dgvws.Rows(i).Cells("status")

                    With Me.dgvws.Rows(i).DefaultCellStyle
                        .BackColor = Color.PeachPuff
                        .ForeColor = Color.Black
                    End With

                    dgvws.Refresh()

                Else
                    Invoke(Sub() lblinfo_auto.Text = "NFCe: " & chave & ", Retorno SEFAZ: " & procInutNFe.infInut.cStat & "-" & procInutNFe.infInut.xMotivo)

                End If

                executa_query("update cfe set cod_sit = '4', sit_nfce = '" & procInutNFe.infInut.xMotivo & "', xml = '', xml_inut = '" & Convert.ToBase64String(Encoding.UTF8.GetBytes(xmlretcanc.OuterXml)) & "' where  chave_nfce = '" & chave & "'")


                If cont = 1 Then
                    ' MsgBox(procInutNFe.infInut.xMotivo & vbCrLf & "Cancelamento efetuado com Sucesso !", MsgBoxStyle.Information, "Retorno do sefaz:")
                End If
                ''''''''''''''''''''''''''########################''''''''''''''''''''''''


                '  MsgBox("XML de Cancelamento gerado na Pasta abaixo: " + vbCrLf + Application.StartupPath + "\XML_nfecanc\", MsgBoxStyle.Information, "Aviso !")

            Else

                If auto = False Then
                    dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = procInutNFe.infInut.xMotivo

                    With Me.dgvws.Rows(i).DefaultCellStyle
                        .BackColor = Color.Red
                        .ForeColor = Color.White
                    End With
                    dgvws.Refresh()
                Else
                    Invoke(Sub() lblinfo_auto.Text = "NFCe: " & chave & ", Retorno SEFAZ: " & procInutNFe.infInut.xMotivo & "-" & procInutNFe.infInut.xMotivo)
                End If


                If cont = 1 Then
                    '  MsgBox(procInutNFe.infInut.xMotivo & procInutNFe.infInut.xMotivo & vbCrLf & "Cancelamento não efetuado !", MsgBoxStyle.Information, "Retorno do sefaz:")
                End If



                If procInutNFe.infInut.cStat = "563" Then

                    executa_query("update cfe set cod_sit = '4', sit_nfce = 'Inutilização de número homologado', xml = '' where  chave_nfce = '" & chave & "'")

                    If auto = False Then

                        With Me.dgvws.Rows(i).DefaultCellStyle
                            .BackColor = Color.PeachPuff
                            .ForeColor = Color.Black
                        End With

                    End If

                End If




            End If

            If auto = False Then
                Invoke(Sub() Panel_nfce.Visible = False)
            End If
        Catch ex As Exception
            If auto = False Then
                If reterro = "" Then
                    dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = "Rotina: local " & reterro
                Else
                    dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = "Rotina: Webservice " & reterro
                End If
                Invoke(Sub() Panel_nfce.Visible = False)
            End If

        End Try
        ''''''''''''''''Rotina ativa webservice''''''''''''''''''''''''


    End Sub

    Private Sub btnpesquisar_Click(sender As Object, e As EventArgs) Handles btnpesquisar.Click
        PESQUISA_NFCE()
    End Sub

    Private Function dgvws_pesqn(ByVal id As String) As String

        Dim r As String = "R"

        For Each row As DataGridViewRow In Me.dgvws.Rows

            If Not row.IsNewRow Then
                If row.Cells("chvpar").Value = id Then
                    Return row.Index
                End If
            End If

        Next

        Return r

    End Function
    Private Sub chkclique_CheckedChanged(sender As Object, e As EventArgs) Handles chkclique.CheckedChanged
        If chkclique.Checked = True Then
            For Each row As DataGridViewRow In dgvws.Rows
                row.Cells(0).Value = True

            Next
        Else
            For Each row As DataGridViewRow In dgvws.Rows
                row.Cells(0).Value = False

            Next
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If dgvws.Rows.Count = 0 Then
            Exit Sub
        End If

        Panel_nfce.Visible = True
        txtinfo_nfce.Text = "Aguarde, Consultando Status NFC-e..."
        Control.CheckForIllegalCrossThreadCalls = False

        rotina_nfce = New Thread(AddressOf consult_sefaz)
        rotina_nfce.SetApartmentState(ApartmentState.STA)
        rotina_nfce.Start()
    End Sub

    Private Sub envia_contigencia(ByVal i As Integer, ByVal nchave As String, ByVal xml As String, ByVal ambiente As String, ByVal cont_total As Integer, ByVal cont2 As Integer, ByVal rep As Boolean)
        Dim WebS As New C_WebService
        Dim retEnviNFe As retEnviNFe



        If rep = False Then
            If cont_total = 1 Then
                Invoke(Sub() txtinfo_nfce.Text = "Aguarde, Enviando NFCe em Contigência para SEFAZ ...")
                Invoke(Sub() Panel_nfce.Refresh())
            Else
                Invoke(Sub() txtinfo_nfce.Text = "Aguarde, Enviando NFCe em Contigência para SEFAZ, " & cont2 & " de " & cont_total)
                Invoke(Sub() Panel_nfce.Refresh())
            End If
        Else
            If cont_total = 1 Then
                Invoke(Sub() txtinfo_nfce.Text = "Aguarde, Reprocessando XML na SEFAZ ...")
                Invoke(Sub() Panel_nfce.Refresh())
            Else
                Invoke(Sub() txtinfo_nfce.Text = "Aguarde, Reprocessando XML na SEFAZ, " & cont2 & " de " & cont_total)
                Invoke(Sub() Panel_nfce.Refresh())
            End If
        End If



        Try
            xmldoc.LoadXml(gerar_xmlNFCe_envio(xml, ambiente))
        Catch ex As Exception
            xmldoc.LoadXml(xml)
        End Try

        xmldoc.Save(Application.StartupPath & "\xml\nfe\" & nchave & "env.xml")

        retEnviNFe = WebS.EnviaLote4(xmldoc, nchave, ambiente)


        If Not retEnviNFe.infRec Is Nothing Then
            If Not retEnviNFe.infRec.nRec Is Nothing Then
                nrecibo_cont = retEnviNFe.infRec.nRec
                Funcoes_sist.cfe(nchave, "", "", ambiente, "", "Contigencia Arquivo enviado", "2", nrecibo_cont)
            End If
        Else

            Invoke(Sub() dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = retEnviNFe.cStat & "-" & retEnviNFe.xMotivo)
            Funcoes_sist.cfe(nchave, "", "", ambiente, "", retEnviNFe.xMotivo, retEnviNFe.cStat, "")
            Panel_nfce.Visible = False
            Exit Sub
        End If



        ''''''''''Rotina para consultar retorno envia xml para a SEFAZ'''''''''''''''''''''''''''''

        consultaRetEnvio(nrecibo_cont, i, cont_total, ambiente, nchave, xml, True)

        dgvws.Rows.Item(i).Cells(0).Value = False
        Panel_nfce.Visible = False
        color_grid()
    End Sub

    Private Sub consultaRetEnvio(ByVal NR As String, ByVal i As Integer, ByVal cont_total As Integer, ByVal ambiente As String, ByVal nchave As String, ByVal xml As String, Optional ByVal par As Boolean = False)
        Dim retConsReciNFe As retConsReciNFe

        If par = False Then
            Invoke(Sub() Panel_nfce.Visible = True)

            Invoke(Sub() txtinfo_nfce.Text = "Aguarde, Consultando Retorno NFCe envianda SEFAZ ...")
            Invoke(Sub() Panel_nfce.Refresh())
        End If


        If NR <> "" Then

            Try
                xmldoc.LoadXml(gerar_xmlNFCe_envio(xml, ambiente))
            Catch ex As Exception
                xmldoc.LoadXml(xml)
            End Try
            ''''''''''Rotina para consultar retorno envia xml para a SEFAZ'''''''''''''''''''''''''''''
            retConsReciNFe = WebS.ConsultaRecLote(NR, ambiente, nchave)

            If retConsReciNFe.cStat = "104" Then


                If retConsReciNFe.protNFe.infProt.cStat = "100" Then
                    Dim dados As XmlDocument = New XmlDocument
                    dados = GerarNotaProcessadanfce(SepararNota_NFe(xmldoc.OuterXml), retConsReciNFe.xmlprot)
                    '''''''''''''''''''''''''''Salva info no banco''''''''''''''''''''''''''

                    Funcoes_sist.cfe(nchave, "", dados.OuterXml, ambiente, "", retConsReciNFe.protNFe.infProt.xMotivo, retConsReciNFe.protNFe.infProt.cStat, "")

                    Invoke(Sub() dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = retConsReciNFe.protNFe.infProt.xMotivo)
                    Invoke(Sub() dgvws.Rows.Item(i).Cells("status").Value = "Autorizada")
                    Invoke(Sub() dgvws.Rows.Item(i).Cells("prot_grid").Value = retConsReciNFe.protNFe.infProt.nProt)
                    '''''''''''''''''''''Salvar arquivo ma pasta''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim Path As String = Application.StartupPath & "\NFCe"
                    If Not Directory.Exists(Path) Then Directory.CreateDirectory(Path)

                    dados.Save(Path & "\NFCe-" & retConsReciNFe.protNFe.infProt.chNFe & ".xml")

                    If cont_total = 1 Then
                        MsgBox("A Nota Fiscal Autorizada !" & vbCrLf & "Chave acesso: " & retConsReciNFe.protNFe.infProt.chNFe & vbCrLf & "Protocolo Aut.: " & retConsReciNFe.protNFe.infProt.nProt & vbCrLf & "Status: " & retConsReciNFe.protNFe.infProt.xMotivo, MsgBoxStyle.Information, "Aviso ")
                    End If

                Else

                    If retConsReciNFe.protNFe.infProt.cStat = "204" Then

                        Dim nPost As Int32 = retConsReciNFe.protNFe.infProt.xMotivo.IndexOf("nRec:")
                        Dim rec As String = retConsReciNFe.protNFe.infProt.xMotivo.Substring(nPost + 5, retConsReciNFe.protNFe.infProt.xMotivo.Length - nPost - 6).Trim
                        nrecibo_cont = rec
                        Invoke(Sub() dgvws.Rows.Item(i).Cells("nRec").Value = rec)

                    End If

                    If cont_total = 1 Then
                        MsgBox(retConsReciNFe.protNFe.infProt.xMotivo & " - " & retConsReciNFe.protNFe.infProt.xMotivo, MsgBoxStyle.Exclamation, "Aviso !")
                    End If

                    Invoke(Sub() dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = retConsReciNFe.protNFe.infProt.xMotivo)
                    '''''''''''''''''''''''''''Salva info no banco''''''''''''''''''''''''''
                    Funcoes_sist.cfe(nchave, "", "", ambiente, "", retConsReciNFe.protNFe.infProt.xMotivo, retConsReciNFe.protNFe.infProt.cStat, "")

                End If

            Else

                Invoke(Sub() dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = retConsReciNFe.xMotivo)

                If cont_total = 1 Then
                    MsgBox(retConsReciNFe.cStat & " - " & retConsReciNFe.xMotivo, MsgBoxStyle.Exclamation, "Aviso !")
                End If

            End If
        End If

        Invoke(Sub() Panel_nfce.Visible = False)
    End Sub
    Private Sub XmlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XmlToolStripMenuItem.Click

        Dim frmVisualizarcs As frmvisualizar_xml = New frmvisualizar_xml(dgvws.CurrentRow.Cells("xml_nfcegrid").Value)

        frmVisualizarcs.ShowDialog()
        ' MsgBox(SepararNota_NFe(dgvws.CurrentRow.Cells("xml_nfcegrid").Value))
    End Sub

#End Region


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        frmcliente.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        frmfornecedor.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        FrmProduto.ShowDialog()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        FrmEmpresa.ShowDialog()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        frmxml_nfe.ShowDialog()
    End Sub

    Private Sub GroupBox1_Click(sender As Object, e As EventArgs) Handles GroupBox1.Click
        If IsConectedToHost(New Uri("http://www.google.com")) = True Then
            Pic_on_inter.Visible = True
            Pic_off_inter.Visible = False
        Else
            Pic_off_inter.Visible = True
            Pic_on_inter.Visible = False
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        frmcarga.ShowDialog()
    End Sub


    Public Function recriar_xml(ByVal chv As String, ByVal rvv As String) As String
        Dim compo_chv As String
        If chv.Substring(34, 1) = "9" Then
            compo_chv = "chave_cont"
        Else
            compo_chv = "chave_nfe"
        End If

        Dim PathFile As String = ""
        Dim sVersaoLayout As String = "4.00"
        Dim sSerie As String = chv.Substring(22, 3)
        Dim sCaixa As String = ret_valor_campo("select * from rv where " & compo_chv & " = '" & chv & "'", "caixa")

        If sCaixa = "" Then

            If chv.Substring(34, 1) = "9" Then
                executa_query("update rv set chave_cont = '" & chv & "' where rv = '" & rvv & "'")
                sCaixa = ret_valor_campo("select * from rv where " & compo_chv & " = '" & chv & "'", "caixa")
            End If

        End If

        Dim srv As String = ret_valor_campo("select * from rv where " & compo_chv & " = '" & chv & "'", "rv")
        Dim cnpj_dest As String = ret_valor_campo("select * from rv where " & compo_chv & " = '" & chv & "'", "cnpj_dest")
        Dim flag1 As Boolean = True
        Dim xmlDocument As XmlDocument = New XmlDocument()
        xmlDocument.PreserveWhitespace = False
        ' Dim empresa As String = "1"

        Dim dateTime1 As DateTime

        Dim sNF As String

        sNF = chv.Substring(25, 9)


        If PathFile <> "" Then
            Dim directoryName As String = Path.GetDirectoryName(PathFile)
            If Not Directory.Exists(directoryName) Then Directory.CreateDirectory(directoryName)
        End If


        If sCaixa <> "" Then sCaixa = sCaixa.PadLeft(3, "0"c)
        If sSerie <> "" Then sSerie = sSerie.PadLeft(3, "0"c)
        If sNF <> "" Then sNF = sNF.PadLeft(9, "0"c)
        If srv <> "" Then srv = srv.PadLeft(8, "0"c)

        If Not flag1 Then Return False

        ' Try
        Dim str1 As String = Application.StartupPath & "\XML_NFCe"
        Directory.CreateDirectory(str1)
        Dim str2 As String = ""
        If sCaixa <> "" Then str2 = str2 & " and caixa = " & sCaixa
        If sSerie <> "" Then str2 = str2 & " and serie = " & sSerie
        If sNF <> "" Then str2 = str2 & " and num_nfce = " & sNF
        If srv <> "" Then str2 = str2 & " and rv = " & srv

        Dim Valor1 As Decimal = New Decimal()
        Dim Valor2 As Decimal = New Decimal()
        Dim Valor3 As Decimal = New Decimal()
        Dim num1 As Decimal = New Decimal()
        Dim Valor4 As Decimal = New Decimal()
        Dim Valor5 As Decimal = New Decimal()
        Dim Valor6 As Decimal = New Decimal()
        Dim num2 As Decimal = New Decimal()
        Dim Valor7 As Decimal = New Decimal()
        Dim Valor8 As Decimal = New Decimal()
        Dim Valor9 As Decimal = New Decimal()
        Dim Valor10 As Decimal = New Decimal()
        Dim num3 As Decimal = New Decimal()
        Dim Valor11 As Decimal = New Decimal()
        Dim Valor12 As Decimal = New Decimal()
        Dim num4 As Decimal = New Decimal()
        Dim num5 As Decimal = New Decimal()
        Dim num6 As Decimal = New Decimal()
        Dim num7 As Decimal = New Decimal()
        Dim num8 As Decimal = New Decimal()
        Dim str3 As String = ""
        Dim str4 As String = ""
        Dim str5 As String = ""
        Dim str6 As String = ""
        Dim num9 As Integer = 0
        Dim numori As Integer = 0
        Dim num10 As Integer = 0
        Dim num11 As Decimal = New Decimal()
        Dim num12 As Decimal = New Decimal()
        Dim num13 As Decimal = New Decimal()
        Dim cAliqInt As Decimal = New Decimal()
        Dim cRedBase As Decimal = New Decimal()



        If File.Exists(str1 & "\xmlrec.tmp") Then
            GC.Collect()
            GC.WaitForPendingFinalizers()
            File.Delete(str1 & "\xmlrec.tmp")
        End If

        Dim xmlTextWriter1 As XmlTextWriter = New XmlTextWriter(str1 & "\xmlrec.tmp", CType(Nothing, Encoding))
        xmlTextWriter1.WriteStartDocument()
        xmlTextWriter1.WriteStartElement("NFe", "http://www.portalfiscal.inf.br/nfe")
        xmlTextWriter1.WriteStartElement("infNFe")

        Dim dEmi As Date
        Try
            dEmi = ret_valor_campo("select * from rv where " & compo_chv & " = '" & chv & "'", "data")
            ' dEmi = dEmi.ToString("yyyy-MM-ddTHH:mm:ss")
            dEmi = Now.ToString("yyyy-MM-ddTHH:mm:ss")
        Catch ex As Exception
            dEmi = Now
            dEmi = dEmi.ToString("yyyy-MM-ddTHH:mm:ss")
        End Try






        Dim _codUF As String = "31"
        Dim _dEmi As String = dEmi.ToString("yyMM")
        Dim _cnpj As String = empresa.sCNPJ
        Dim _mod As String = "65"
        Dim cNF As String
        Dim _tpEmis As String
        If chv.Substring(34, 1) = "1" Then
            _tpEmis = "1"
        Else
            _tpEmis = "9"
        End If



        cNF = chv.Substring(35, 8)



        Dim _serie As String = sSerie
        Dim _numNF As String = sNF
        Dim _codigo As String = String.Format("{0:00000000}", Int32.Parse(cNF))


        Dim _dv As Integer = chv.Substring(43, 1)



        xmlTextWriter1.WriteAttributeString("Id", "NFe" & chv)

        xmlTextWriter1.WriteAttributeString("versao", "4.00")
        xmlTextWriter1.WriteStartElement("ide")
        xmlTextWriter1.WriteElementString("cUF", _codUF.ToString())
        xmlTextWriter1.WriteElementString("cNF", cNF.ToString())
        xmlTextWriter1.WriteElementString("natOp", "VENDA AO CONSUMIDOR")
        xmlTextWriter1.WriteElementString("mod", "65")
        xmlTextWriter1.WriteElementString("serie", sSerie.ToString.TrimStart("0"))
        xmlTextWriter1.WriteElementString("nNF", sNF.ToString.TrimStart("0"))
        Dim xmlTextWriter2 As XmlTextWriter = xmlTextWriter1
        Dim str12 As String = dEmi.ToString("yyyy-MM-ddTHH:mm:ss") & "-03:00"
        xmlTextWriter2.WriteElementString("dhEmi", str12)
        xmlTextWriter1.WriteElementString("tpNF", "1")
        xmlTextWriter1.WriteElementString("idDest", "1")

        xmlTextWriter1.WriteElementString("cMunFG", empresa.sCodMunIBGE)

        fecha_baseNFe()

        xmlTextWriter1.WriteElementString("tpImp", "4")
        xmlTextWriter1.WriteElementString("tpEmis", String.Format("{0}", CObj(_tpEmis)))


        xmlTextWriter1.WriteElementString("cDV", chv.Substring(43, 1))


        xmlTextWriter1.WriteElementString("tpAmb", String.Format("{0}", CObj(empresa.ambiente_nfe)))
        xmlTextWriter1.WriteElementString("finNFe", "1")
        xmlTextWriter1.WriteElementString("indFinal", "1")
        xmlTextWriter1.WriteElementString("indPres", "1")
        xmlTextWriter1.WriteElementString("procEmi", "0")
        xmlTextWriter1.WriteElementString("verProc", "11.0.0")

        If chv.Substring(34, 1) = 9 Then
            Dim xmlTextWriter345 As XmlTextWriter = xmlTextWriter1
            Dim str100 As String = dEmi.ToString("yyyy-MM-ddTHH:mm:ss") & "-03:00"
            xmlTextWriter345.WriteElementString("dhCont", str100)
            xmlTextWriter1.WriteElementString("xJust", "falta de conexao com os servicos da sefaz")
        End If

        'sNF = rsvenda.Fields("Numero").Value

        xmlTextWriter1.WriteEndElement()
        xmlTextWriter1.WriteStartElement("emit")
        xmlTextWriter1.WriteElementString("CNPJ", empresa.sCNPJ.ToString())
        xmlTextWriter1.WriteElementString("xNome", empresa.sNomeRazao.ToString())

        If empresa.sNomefant.ToString() <> "" Then
            xmlTextWriter1.WriteElementString("xFant", empresa.sNomefant.ToString())
        End If

        xmlTextWriter1.WriteStartElement("enderEmit")

        If empresa.send.ToString() <> "" Then
            xmlTextWriter1.WriteElementString("xLgr", empresa.send.ToString())
        Else
            xmlTextWriter1.WriteElementString("xLgr", "ENDERECO NAO INFORMADO")
        End If

        If empresa.sNumero.ToString() <> "" Then
            xmlTextWriter1.WriteElementString("nro", empresa.sNumero.ToString())
        Else
            xmlTextWriter1.WriteElementString("nro", "NUMERO NAO INFORMADO")
        End If

        If empresa.sBairro.ToString() <> "" Then
            xmlTextWriter1.WriteElementString("xBairro", empresa.sBairro.ToString())
        Else
            xmlTextWriter1.WriteElementString("xBairro", "BAIRRO NAO INFORMADO")
        End If

        xmlTextWriter1.WriteElementString("cMun", empresa.sCodMunIBGE)
        xmlTextWriter1.WriteElementString("xMun", empresa.sNomeMunic)
        xmlTextWriter1.WriteElementString("UF", empresa.sSiglaUF)


        xmlTextWriter1.WriteElementString("CEP", empresa.sCEP.ToString())
        xmlTextWriter1.WriteEndElement()
        xmlTextWriter1.WriteElementString("IE", empresa.sIe.ToString())
        xmlTextWriter1.WriteElementString("CRT", empresa.scod_trib.ToString())
        xmlTextWriter1.WriteEndElement()

        fecha_baseNFe()


        Dim clsDadosDest As clsDadosDest = New clsDadosDest()
        If empresa.ambiente_nfe Then

            clsDadosDest.sCPFCNPJ = "99999999000191"
            clsDadosDest.sNomeRazao = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL"
            clsDadosDest.sLogradouro = "Rua teste"
            clsDadosDest.sNumero = "00"
            clsDadosDest.sBairro = "Bairro teste"
            clsDadosDest.sNomeMunic = "Cidade teste"
            clsDadosDest.dCodMunIBGE = "3135902"
            clsDadosDest.sSiglaUF = "MG"
            clsDadosDest.sCEP = "00000000"
            clsDadosDest.sEmail = "teste@teste.com"
            clsDadosDest.sCodPaisIBGE = "1058"
            clsDadosDest.sNomePais = "BRASIL"

        Else

            conectar_mysqlDFe()
            Dim SQLcommand10 As MySqlCommand
            SQLcommand10 = oConn.CreateCommand
            SQLcommand10.CommandText = "SELECT * FROM cliente INNER JOIN municipio ON cliente.cod_munic = municipio.codigo_municipio WHERE cliente.cliente_ativo = '0' and cliente.cnpjcpf_cli = '" & cnpj_dest & "'"

            Using reader As MySqlDataReader = SQLcommand10.ExecuteReader

                While reader.Read

                    clsDadosDest.sCPFCNPJ = reader("cnpjcpf_cli").ToString()
                    clsDadosDest.sNomeRazao = RemoverAcentos(reader("nome_cli").ToString().Trim())
                    If clsDadosDest.sNomeRazao = "" Then clsDadosDest.sNomeRazao = "NOME NAO INFORMADO"
                    clsDadosDest.sLogradouro = RemoverAcentos(reader("end_cli").ToString().Trim())
                    If clsDadosDest.sLogradouro = "" Then clsDadosDest.sLogradouro = "ENDERECO NAO INFORMADO"
                    clsDadosDest.sNumero = RemoverAcentos(reader("numero_cli").ToString().Trim())
                    If clsDadosDest.sNumero = "" Then clsDadosDest.sNumero = "S/N"
                    clsDadosDest.sBairro = RemoverAcentos(reader("bairro_cli").ToString().Trim())
                    If clsDadosDest.sBairro = "" Then clsDadosDest.sBairro = "BAIRRO NAO INFORMADO"
                    clsDadosDest.dCodMunIBGE = reader("cod_munic").ToString().Trim()
                    clsDadosDest.sNomeMunic = RemoverAcentos(reader("NomeMunic").ToString().Trim())
                    If clsDadosDest.sNomeMunic = "" Then clsDadosDest.sNomeMunic = "NOME NAO INFORMADO"
                    clsDadosDest.sSiglaUF = reader("UF").ToString().Trim()
                    Dim cep As String = reader("cep_cli").ToString().Trim()
                    clsDadosDest.sCEP = If(Not ValidaCEP(cep), "", cep)
                    clsDadosDest.sCodPaisIBGE = "1058"
                    clsDadosDest.sNomePais = "BRASIL"
                    clsDadosDest.sTelefone = RemoverAcentos(reader("fone_cli").ToString.Replace(" ", ""))
                    If clsDadosDest.sTelefone.Length < 6 Then clsDadosDest.sTelefone = ""
                    clsDadosDest.sEmail = RemoverAcentos(reader("email").ToString().Trim().Replace(" ", ""))

                End While

            End Using

        End If

        If cnpj_dest.ToString <> "" Then
            xmlTextWriter1.WriteStartElement("dest")

            If clsDadosDest.sCPFCNPJ.ToString().Length = 11 Then
                xmlTextWriter1.WriteElementString("CPF", clsDadosDest.sCPFCNPJ.ToString())
            Else
                xmlTextWriter1.WriteElementString("CNPJ", clsDadosDest.sCPFCNPJ.ToString())
            End If

            If empresa.ambiente_nfe = 2 Then
                xmlTextWriter1.WriteElementString("xNome", "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL")
            Else
                xmlTextWriter1.WriteElementString("xNome", RemoverAcentos(clsDadosDest.sNomeRazao.Trim().Left(60)))
            End If

            xmlTextWriter1.WriteStartElement("enderDest")
            xmlTextWriter1.WriteElementString("xLgr", clsDadosDest.sLogradouro.Left(60))
            xmlTextWriter1.WriteElementString("nro", clsDadosDest.sNumero.Left(60))
            If clsDadosDest.sComplemento.Left(60) <> "" Then xmlTextWriter1.WriteElementString("xCpl", clsDadosDest.sComplemento.Left(60))
            xmlTextWriter1.WriteElementString("xBairro", clsDadosDest.sBairro.Left(60))
            xmlTextWriter1.WriteElementString("cMun", clsDadosDest.dCodMunIBGE.ToString().Left(7))
            xmlTextWriter1.WriteElementString("xMun", clsDadosDest.sNomeMunic.Left(60))
            xmlTextWriter1.WriteElementString("UF", clsDadosDest.sSiglaUF.Left(2))
            If clsDadosDest.sCEP <> "" Then xmlTextWriter1.WriteElementString("CEP", clsDadosDest.sCEP.Left(8))
            xmlTextWriter1.WriteElementString("cPais", clsDadosDest.sCodPaisIBGE.Left(4))
            xmlTextWriter1.WriteElementString("xPais", clsDadosDest.sNomePais.Left(60))

            If clsDadosDest.sTelefone <> "" Then
                xmlTextWriter1.WriteElementString("fone", clsDadosDest.sTelefone.Left(14))
            ElseIf clsDadosDest.sCelular <> "" Then
                xmlTextWriter1.WriteElementString("fone", clsDadosDest.sCelular.Left(14))
            Else
                xmlTextWriter1.WriteElementString("fone", "999999")
            End If

            xmlTextWriter1.WriteEndElement()
            xmlTextWriter1.WriteElementString("indIEDest", "9")
            If clsDadosDest.sEmail <> "" Then xmlTextWriter1.WriteElementString("email", clsDadosDest.sEmail.Left(60))
            xmlTextWriter1.WriteEndElement()

        End If

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from item_rv where rv ='" & srv & "'"
        Dim ncm As String
        Dim conti As Integer = 0
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read
                conti += 1
                xmlTextWriter1.WriteStartElement("det")
                xmlTextWriter1.WriteAttributeString("nItem", conti)

                xmlTextWriter1.WriteStartElement("prod")
                xmlTextWriter1.WriteElementString("cProd", reader("codigo_prod").ToString())

                If validaGTIN(reader("codigo_barras").ToString().PadLeft(13, "0"c)) Then
                    xmlTextWriter1.WriteElementString("cEAN", reader("codigo_barras").ToString().PadLeft(13, "0"c))
                Else
                    xmlTextWriter1.WriteElementString("cEAN", "SEM GTIN")
                End If


                Dim sValue As String = ""

                If empresa.ambiente_nfe = 2 Then
                    xmlTextWriter1.WriteElementString("xProd", "NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL")
                Else
                    xmlTextWriter1.WriteElementString("xProd", ret_valor_campo("select * from produto where codigo_prod = '" & reader("codigo_prod") & "'", "desc_prod").ToString().Trim())
                End If

                ncm = RemoveTelefone(ret_valor_campo("select * from produto where codigo_prod = '" & reader("codigo_prod") & "'", "ncm_prod"))
                xmlTextWriter1.WriteElementString("NCM", RemoveTelefone(ret_valor_campo("select * from produto where codigo_prod = '" & reader("codigo_prod") & "'", "ncm_prod").ToString().PadLeft(8, "0"c)))
                If RemoveTelefone(ret_valor_campo("select * from produto where codigo_prod = '" & reader("codigo_prod") & "'", "cest_prod").ToString.Trim()) <> "" Then
                    xmlTextWriter1.WriteElementString("CEST", RemoveTelefone(ret_valor_campo("select * from produto where codigo_prod = '" & reader("codigo_prod") & "'", "cest_prod").ToString.Trim()))
                End If


                Dim cfop As String
                Dim aliq As String = ret_valor_campo("select * from produto where codigo_prod = '" & reader("codigo_prod") & "'", "aliq_icms").ToString

                If aliq = "0" Or aliq = "0,00" Then
                    cfop = "5405"
                Else
                    cfop = "5102"
                End If
                xmlTextWriter1.WriteElementString("CFOP", cfop)
                xmlTextWriter1.WriteElementString("uCom", reader("un_item").ToString())

                Dim Valor13 As Decimal
                Dim Valor14 As Decimal
                Dim Valor15 As Decimal
                Dim num15 As Decimal


                xmlTextWriter1.WriteElementString("qCom", reader("qtde_item").ToString.Replace(",", "."))
                xmlTextWriter1.WriteElementString("vUnCom", formatar_valor(reader("vlr_unit").ToString.Replace(",", ".")))
                xmlTextWriter1.WriteElementString("vProd", formatar_valor(reader("vlr_total").ToString.Replace(",", ".")))
                Valor15 = Moeda(FormatABNT(reader("vlr_total").ToString), 2)
                Dim num16 As Decimal = Valor15
                Valor1 += num16

                If validaGTIN(reader("codigo_barras").ToString().PadLeft(13, "0"c)) Then
                    xmlTextWriter1.WriteElementString("cEANTrib", reader("codigo_barras").ToString().PadLeft(13, "0"c))
                Else
                    xmlTextWriter1.WriteElementString("cEANTrib", "SEM GTIN")
                End If
                xmlTextWriter1.WriteElementString("uTrib", reader("un_item").ToString().ToUpper())


                Dim xmlTextWriter333 As XmlTextWriter = xmlTextWriter1
                num15 = Moeda(Valor13, 4)


                xmlTextWriter333.WriteElementString("qTrib", reader("qtde_item").ToString.Replace(",", "."))
                Dim xmlTextWriter4 As XmlTextWriter = xmlTextWriter1
                num15 = Moeda(Valor14, 3)
                Dim str17 As String = formatar_valor(reader("vlr_unit").ToString())
                xmlTextWriter4.WriteElementString("vUnTrib", str17)

                If Convert.ToDecimal(reader("vlrdesc_item").ToString()) > Decimal.Zero Then
                    Dim xmlTextWriter5 As XmlTextWriter = xmlTextWriter1
                    num15 = formatar_valor(reader("vlrdesc_item").ToString())
                    Dim str100 As String = gVgPt(num15.ToString())
                    xmlTextWriter5.WriteElementString("vDesc", str100)
                    Valor2 += Convert.ToDecimal(reader("vlrdesc_item"))
                End If

                '   If Convert.ToDecimal(row2("acrescimo")) > Decimal.Zero Then
                'Dim xmlTextWriter5 As XmlTextWriter = xmlTextWriter1
                '   num15 = Moeda(Convert.ToDecimal(row2("acrescimo")), 2)
                '   Dim str10 As String = DBHelper.gvgpt(num15.ToString())
                '  xmlTextWriter5.WriteElementString("vOutro", str10)
                Valor3 += Convert.ToDecimal("0,00")
                '  End If
                Dim acres As String = "0,00"

                xmlTextWriter1.WriteElementString("indTot", "1")
                xmlTextWriter1.WriteEndElement()
                xmlTextWriter1.WriteStartElement("imposto")

                conectar_mysql2()
                Dim SQLcommand6 As MySqlCommand
                SQLcommand6 = oConn2.CreateCommand
                SQLcommand6.CommandText = "select * from ncm where codigo = '" & ncm & "'"

                Dim num177 As Decimal
                Dim num188 As Decimal
                Dim num199 As Decimal
                Using reader2 As MySqlDataReader = SQLcommand6.ExecuteReader

                    While reader2.Read
                        num177 = CDec(reader("vlr_total").ToString) * CDec(reader2("nacionalfederal")) / New Decimal(100)
                        num188 = CDec(reader("vlr_total").ToString) * CDec(reader2("estadual")) / New Decimal(100)
                        num199 = CDec(reader("vlr_total").ToString) * CDec(reader2("municipal")) / New Decimal(100)
                    End While

                End Using



                If num177 < Decimal.Zero Then num177 = New Decimal()
                If num188 < Decimal.Zero Then num188 = New Decimal()
                If num199 < Decimal.Zero Then num199 = New Decimal()
                Dim Valor16 As Decimal = num177 + num188 + num199
                If Valor16 < Decimal.Zero Then Valor16 = New Decimal()
                Dim xmlTextWriter6 As XmlTextWriter = xmlTextWriter1
                num15 = Moeda(Valor16, 2)
                Dim str18 As String = formatar_valor(num15.ToString())
                xmlTextWriter6.WriteElementString("vTotTrib", str18)
                Valor4 += num177
                Valor5 += num188
                Valor6 += num199

                xmlTextWriter1.WriteStartElement("ICMS")

                num9 = ret_valor_campo("select * from produto where codigo_prod = '" & reader("codigo_prod") & "'", "cst_icms")

                numori = ret_valor_campo("select * from produto where codigo_prod = '" & reader("codigo_prod") & "'", "cst_icms").ToString.Substring(0, 1)

                Select Case num9
                    Case 0
                        Dim Valor17 As Decimal = Moeda(Moeda(Valor15, 2) - Convert.ToDecimal(reader("vlrdesc_item").ToString()) + Convert.ToDecimal(acres), 2)
                        xmlTextWriter1.WriteStartElement("ICMS00")
                        xmlTextWriter1.WriteElementString("orig", numori.ToString())
                        xmlTextWriter1.WriteElementString("CST", num9.ToString().PadLeft(2, "0"c))
                        xmlTextWriter1.WriteElementString("modBC", "3")
                        Dim xmlTextWriter7 As XmlTextWriter = xmlTextWriter1
                        num15 = Moeda(Valor17, 2)
                        Dim str19 As String = formatar_valor(num15.ToString())
                        xmlTextWriter7.WriteElementString("vBC", str19)
                        Valor7 += Valor17
                        Valor8 += Valor17 * CDec(aliq) / New Decimal(100)
                        Dim xmlTextWriter8 As XmlTextWriter = xmlTextWriter1
                        num15 = formatar_valor(aliq)
                        Dim str20 As String = formatar_valor(num15.ToString())
                        xmlTextWriter8.WriteElementString("pICMS", aliq.ToString.Replace(",", "."))
                        Dim xmlTextWriter9 As XmlTextWriter = xmlTextWriter1
                        num15 = Moeda(Valor17 * CDec(aliq) / New Decimal(100), 2)
                        Dim str21 As String = formatar_valor(num15.ToString())
                        xmlTextWriter9.WriteElementString("vICMS", str21)


                        If sVersaoLayout IsNot Nothing Then
                            Dim num20 As Integer = If(sVersaoLayout = "4.00", 1, 0)
                        End If

                        xmlTextWriter1.WriteEndElement()
                    Case 20
                        Dim num21 As Decimal = Moeda(Moeda(Valor15, 2) - Convert.ToDecimal(reader("vlrdesc_item").ToString()) + Convert.ToDecimal(acres), 2)
                        xmlTextWriter1.WriteStartElement("ICMS20")
                        Dim Valor18 As Decimal = Moeda(Convert.ToDecimal(num21 * cRedBase / New Decimal(100)), 2)
                        xmlTextWriter1.WriteElementString("orig", numori)
                        xmlTextWriter1.WriteElementString("CST", num9.ToString().PadLeft(2, "0"c))
                        xmlTextWriter1.WriteElementString("modBC", "3")
                        Dim xmlTextWriter10 As XmlTextWriter = xmlTextWriter1
                        num15 = Moeda(cRedBase, 2)
                        Dim str21 As String = formatar_valor(num15.ToString())
                        xmlTextWriter10.WriteElementString("pRedBC", str21)
                        Dim xmlTextWriter11 As XmlTextWriter = xmlTextWriter1
                        num15 = Moeda(Valor18, 2)
                        Dim str233 As String = formatar_valor(num15.ToString())
                        xmlTextWriter11.WriteElementString("vBC", str233)
                        Valor7 += Valor18

                        If cAliqInt <> Decimal.Zero Then
                            Valor8 += Moeda(Valor18 * cAliqInt / New Decimal(100), 2)
                            Dim xmlTextWriter5 As XmlTextWriter = xmlTextWriter1
                            num15 = Moeda(cAliqInt, 2)
                            Dim str100 As String = formatar_valor(num15.ToString())
                            xmlTextWriter5.WriteElementString("pICMS", aliq.ToString.Replace(",", "."))
                            Dim xmlTextWriter12 As XmlTextWriter = xmlTextWriter1
                            num15 = Moeda(Valor18 * cAliqInt / New Decimal(100), 2)
                            Dim str244 As String = formatar_valor(num15.ToString())
                            xmlTextWriter12.WriteElementString("vICMS", str244)
                        Else
                            Valor8 += Valor18 * CDec(aliq) / New Decimal(100)
                            Dim xmlTextWriter5 As XmlTextWriter = xmlTextWriter1
                            num15 = aliq.ToString
                            Dim str100 As String = formatar_valor(num15.ToString())
                            xmlTextWriter5.WriteElementString("pICMS", aliq.ToString.Replace(",", "."))
                            Dim xmlTextWriter12 As XmlTextWriter = xmlTextWriter1
                            num15 = Valor18 * CDec(aliq) / New Decimal(100)
                            Dim str244 As String = formatar_valor(num15.ToString())
                            xmlTextWriter12.WriteElementString("vICMS", str244)
                        End If

                        If sVersaoLayout IsNot Nothing Then
                            Dim num22 As Integer = If(sVersaoLayout = "4.00", 1, 0)
                        End If

                        xmlTextWriter1.WriteEndElement()
                    Case 40, 41, 50
                        xmlTextWriter1.WriteStartElement("ICMS40")
                        xmlTextWriter1.WriteElementString("orig", numori.ToString())
                        xmlTextWriter1.WriteElementString("CST", num9.ToString().PadLeft(2, "0"c))
                        xmlTextWriter1.WriteEndElement()
                    Case 60
                        xmlTextWriter1.WriteStartElement("ICMS60")
                        xmlTextWriter1.WriteElementString("orig", numori.ToString())
                        xmlTextWriter1.WriteElementString("CST", num9.ToString().PadLeft(2, "0"c))
                        xmlTextWriter1.WriteEndElement()
                    Case 102, 300
                        xmlTextWriter1.WriteStartElement("ICMSSN102")
                        xmlTextWriter1.WriteElementString("orig", numori.ToString())
                        xmlTextWriter1.WriteElementString("CSOSN", num9.ToString().PadLeft(3, "0"c))
                        xmlTextWriter1.WriteEndElement()
                    Case 400
                        xmlTextWriter1.WriteStartElement("ICMSSN400")
                        xmlTextWriter1.WriteElementString("orig", numori.ToString())
                        xmlTextWriter1.WriteElementString("CSOSN", num9.ToString().PadLeft(3, "0"c))
                        xmlTextWriter1.WriteEndElement()
                    Case 500
                        xmlTextWriter1.WriteStartElement("ICMSSN500")
                        xmlTextWriter1.WriteElementString("orig", numori.ToString())
                        xmlTextWriter1.WriteElementString("CSOSN", num9.ToString().PadLeft(3, "0"c))
                        xmlTextWriter1.WriteEndElement()
                End Select

                xmlTextWriter1.WriteEndElement()


                If "" <> "" Then xmlTextWriter1.WriteElementString("infAdProd", "")
                xmlTextWriter1.WriteEndElement()
                xmlTextWriter1.WriteEndElement()
            End While

        End Using




        Dim Valor23 As Decimal = Valor1 - Valor2 + Valor3
        xmlTextWriter1.WriteStartElement("total")
        xmlTextWriter1.WriteStartElement("ICMSTot")
        Dim xmlTextWriter27 As XmlTextWriter = xmlTextWriter1
        Dim num23 As Decimal = Moeda(Valor7, 2)
        Dim str39 As String = formatar_valor(num23.ToString())
        xmlTextWriter27.WriteElementString("vBC", str39)
        Dim xmlTextWriter28 As XmlTextWriter = xmlTextWriter1
        num23 = Moeda(Valor8, 2)
        Dim str40 As String = formatar_valor(num23.ToString())
        xmlTextWriter28.WriteElementString("vICMS", str40)
        xmlTextWriter1.WriteElementString("vICMSDeson", "0")

        If sVersaoLayout IsNot Nothing AndAlso sVersaoLayout = "4.00" Then
            Dim xmlTextWriter344 As XmlTextWriter = xmlTextWriter1
            num23 = Moeda(Valor11, 2)
            Dim str100 As String = formatar_valor(num23.ToString())
            xmlTextWriter344.WriteElementString("vFCP", str100)
        End If

        xmlTextWriter1.WriteElementString("vBCST", "0")
        xmlTextWriter1.WriteElementString("vST", "0")

        If sVersaoLayout IsNot Nothing AndAlso sVersaoLayout = "4.00" Then
            xmlTextWriter1.WriteElementString("vFCPST", "0")
            xmlTextWriter1.WriteElementString("vFCPSTRet", "0")
        End If

        Dim xmlTextWriter29 As XmlTextWriter = xmlTextWriter1
        num23 = Moeda(Valor1, 2)
        Dim str41 As String = formatar_valor(num23.ToString())
        xmlTextWriter29.WriteElementString("vProd", str41)
        xmlTextWriter1.WriteElementString("vFrete", "0.00")
        xmlTextWriter1.WriteElementString("vSeg", "0.00")
        Dim xmlTextWriter30 As XmlTextWriter = xmlTextWriter1
        num23 = Moeda(Valor2, 2)
        Dim str42 As String = formatar_valor(num23.ToString())
        xmlTextWriter30.WriteElementString("vDesc", str42)
        xmlTextWriter1.WriteElementString("vII", "0.00")
        xmlTextWriter1.WriteElementString("vIPI", "0.00")
        If sVersaoLayout IsNot Nothing AndAlso sVersaoLayout = "4.00" Then xmlTextWriter1.WriteElementString("vIPIDevol", "0")
        Dim xmlTextWriter31 As XmlTextWriter = xmlTextWriter1
        num23 = Moeda(Valor9, 2)
        Dim str43 As String = formatar_valor(num23.ToString())
        xmlTextWriter31.WriteElementString("vPIS", str43)
        Dim xmlTextWriter32 As XmlTextWriter = xmlTextWriter1
        num23 = Moeda(Valor10, 2)
        Dim str44 As String = formatar_valor(num23.ToString())
        xmlTextWriter32.WriteElementString("vCOFINS", str44)
        Dim xmlTextWriter33 As XmlTextWriter = xmlTextWriter1
        num23 = Moeda(Valor3, 2)
        Dim str45 As String = formatar_valor(num23.ToString())
        xmlTextWriter33.WriteElementString("vOutro", str45)
        Dim xmlTextWriter34 As XmlTextWriter = xmlTextWriter1
        num23 = Moeda(Valor23, 2)
        Dim str46 As String = formatar_valor(num23.ToString())
        xmlTextWriter34.WriteElementString("vNF", str46)
        Dim xmlTextWriter35 As XmlTextWriter = xmlTextWriter1
        num23 = Moeda(Valor4 + Valor5 + Valor6, 2)
        Dim str47 As String = formatar_valor(num23.ToString())
        xmlTextWriter35.WriteElementString("vTotTrib", str47)
        xmlTextWriter1.WriteEndElement()
        xmlTextWriter1.WriteEndElement()
        xmlTextWriter1.WriteStartElement("transp")
        xmlTextWriter1.WriteElementString("modFrete", "9")
        xmlTextWriter1.WriteEndElement()

        Dim codigo_fin As String = ret_valor_campo("select * from rv where rv = '" & srv & "'", "forma_pag")
        Dim vPag As String = str46
        xmlTextWriter1.WriteStartElement("pag")
        xmlTextWriter1.WriteStartElement("detPag")
        xmlTextWriter1.WriteElementString("indPag", "0")
        xmlTextWriter1.WriteElementString("tPag", codigo_fin.PadLeft(2, "0"c))
        Dim xmlTextWriter3 As XmlTextWriter = xmlTextWriter1
        num23 = vPag
        Dim str22 As String = formatar_valor(num23.ToString())
        xmlTextWriter3.WriteElementString("vPag", str46)


        xmlTextWriter1.WriteEndElement()

        '  If codigo_fin = "1" Then
        ' If vPag > vTroco Then
        'Valor12 = vTroco
        ' Dim str100 As String = formatar_valor(Valor12.ToString())
        '  xmlTextWriter1.WriteElementString("vTroco", str100)
        ' End If
        '  End If

        xmlTextWriter1.WriteEndElement()




        xmlTextWriter1.WriteStartElement("infAdic")

        If Valor11 <> Decimal.Zero Then
            ' Dim xmlTextWriter3 As XmlTextWriter = xmlTextWriter1
            '   num23 = Moeda(Valor11, 2)
            '  Dim str10 As String = "Fundo Combate a Pobreza(FCP): R$ " & DBHelper.gvgpt(num23.ToString())
            ' xmlTextWriter3.WriteElementString("infAdFisco", str10)
        End If

        Dim dateTime2 As DateTime
        Dim strArray6 As String() = New String(8) {}
        dateTime2 = Convert.ToDateTime(dEmi)
        strArray6(0) = dateTime2.ToString("dd/MM/yy")
        strArray6(1) = " "
        dateTime2 = Convert.ToDateTime(Now)
        strArray6(2) = dateTime2.ToString("HH:mm")
        strArray6(3) = " - CUPOM: "
        strArray6(4) = String.Format("{0:D6}", CObj(srv))
        strArray6(5) = " - PDV: "
        strArray6(6) = String.Format("{0:D3}", CObj(sCaixa))
        strArray6(7) = " - OPR: "
        Dim c As String = ret_valor_campo("select * from rv where rv = '" & srv & "'", "operador")
        strArray6(8) = ret_valor_campo("select * from operador where codigo_op = '" & c & "'", "nome_op")
        Dim str23 As String = String.Concat(strArray6)

        If Valor12 <> Decimal.Zero Then
            Dim str100 As String = str23
            Dim str11 As String = formatar_valor(vPag.ToString())
            Dim str17 As String = str100 & " | Valor Recebimento: R$" & str11
            Dim str18 As String = formatar_valor("0,00")
            str23 = str17 & " | Valor do Troco: R$" & str18
        End If

        ' If Valor24 > Decimal.Zero Then
        'Dim str10 As String = str23
        ' num23 = Moeda(Valor24, 2)
        ' Dim str11 As String = DBHelper.gvgpt(num23.ToString())
        ' str23 = str10 & " |Desconto Sub-Total: R$" & str11
        ' End If

        ' If clsDadosDest.sCPFCNPJ <> "" Then
        'Dim str10 As String = str23 & "|** Dados Identif. Cliente: **|NOME  : " & clsDadosDest.sNomeRazao
        '  str23 = (If(clsDadosDest.sCPFCNPJ.Length <> 11, str10 & "|CNPJ  : " & clsDadosDest.sCPFCNPJ, str10 & "|CPF  : " & clsDadosDest.sCPFCNPJ)) & "|ENDER.: " + clsDadosDest.sLogradouro & "|BAIRRO: " + clsDadosDest.sBairro & "|MUN: " + clsDadosDest.sNomeMunic & "|CEP: " + clsDadosDest.sCEP
        '  If clsDadosDest.sObservacao.ToString() <> "" Then str23 = str23 & "|OBSERVACAO NF: " & clsDadosDest.sObservacao
        '  End If

        If Valor4 + Valor5 + Valor6 > Decimal.Zero Then
            num23 = Moeda(Valor4 + Valor5 + Valor6, 2)
            Dim strArray9 As String() = New String(5) {str23, "|Valor Total Aprox. dos Tributos:R$ ", Nothing, Nothing, Nothing, Nothing}
            num23 = Moeda(Valor4 + Valor5 + Valor6, 2)
            strArray9(2) = formatar_valor(num23.ToString())
            strArray9(3) = "("
            num23 = Moeda(New Decimal(100) / Valor1 * (Valor4 + Valor5 + Valor6), 2)
            strArray9(4) = formatar_valor(num23.ToString())
            strArray9(5) = "%)"
            Dim str100 As String = String.Concat(strArray9)
            Dim strArray10 As String() = New String(7) {}
            strArray10(0) = str100
            strArray10(1) = "|Federais: R$ "
            num23 = Moeda(Valor4, 2)
            strArray10(2) = formatar_valor(num23.ToString())
            strArray10(3) = " Estaduais: R$ "
            num23 = Moeda(Valor5, 2)
            strArray10(4) = formatar_valor(num23.ToString())
            strArray10(5) = " Municipais: R$ "
            num23 = Moeda(Valor6, 2)
            strArray10(6) = formatar_valor(num23.ToString())
            strArray10(7) = "|Fonte: IBPT"
            str23 = String.Concat(strArray10)
        End If

        xmlTextWriter1.WriteStartElement("infCpl")
        xmlTextWriter1.WriteCData(str23.Trim().Replace(Environment.NewLine, " "))
        xmlTextWriter1.WriteEndElement()
        xmlTextWriter1.WriteEndElement()
        xmlTextWriter1.WriteEndElement()
        xmlTextWriter1.WriteEndElement()
        xmlTextWriter1.Close()
        Dim str24 As String = str1
        dateTime2 = DateTime.Now
        dateTime2 = Convert.ToDateTime(dateTime2.Date)
        Dim str25 As String = dateTime2.ToString("ddMMyy")




        xmlDocument.Load(str1 & "\xmlrec.tmp")


        Dim str10 As String = xmlDocument.OuterXml

        File.Delete(str1 & "\xmlrec.tmp")


        executa_query("update rv set " & compo_chv & " = '" & chv & "' where rv = '" & srv & "'")



        'assina o xml para enviar para SEFAZ
        '  Dim xmlAssinado As XmlDocument = CertificadoDigital.Assinar(xmlDocument, "infNFe", certificado)

        'Valida o XML assinado
        '  Dim resultado As String = ValidaXML.ValidarXML(xmlAssinado, Application.StartupPath & "\Esquemas_XML_NF-e\nfe_v4.00.xsd")


        '  If resultado.Trim().Length <> 0 Then

        'xmlDocument.Save(Application.StartupPath & "\XML_NFCe\teste.xml")
        '   MsgBox(resultado, MsgBoxStyle.Exclamation, "Aviso !")
        '   End If


        ' xmlDocument.LoadXml(str10)
        '   SalvarXML(xmlDocument.InnerXml, str1 & "\xmlrec.tmp")
        '  Thread.Sleep(2000)

        ' File.Move(str1 & "\xmlrec.tmp", PathFile)


        Return str10
        '   Catch ex As Exception
        'MsgBox("Erro ao recriar arquivo: " & ex.Message & vbCrLf + ex.StackTrace, MsgBoxStyle.Exclamation, "Aviso !bMSG")

        '  Return ""
        '  End Try
    End Function


    Private Sub RecriarXML()

        dgvws.CurrentRow.Cells("xml_nfcegrid").Value = gerar_xmlNFCe_envio(recriar_xml(dgvws.CurrentRow.Cells("chave_nfce").Value, dgvws.CurrentRow.Cells("rv").Value), empresa.ambiente_nfe)



        executa_query("update cfe set xml = '" & Base64Encode(dgvws.CurrentRow.Cells("xml_nfcegrid").Value) & "' where chave_nfce = '" & dgvws.CurrentRow.Cells("chave_nfce").Value & "'")

    End Sub

    Private Sub ContextMenuStrip2_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip2.Opening
        If dgvws.CurrentRow.Cells("xmotivo_grid").Value = "XML do banco com Divergencia de Chave acesso" Then
            ReprocessarXMLToolStripMenuItem.Enabled = True
        Else
            If dgvws.CurrentRow.Cells("status").Value = "Rejeitada" Then
                ReprocessarXMLToolStripMenuItem.Enabled = True
            Else
                ReprocessarXMLToolStripMenuItem.Enabled = False
            End If
        End If


        If dgvws.CurrentRow.Cells("chave_cont").Value <> "" Then
            CancelamentoPorSubstituicaoToolStripMenuItem.Enabled = True
        Else
            CancelamentoPorSubstituicaoToolStripMenuItem.Enabled = False
        End If

        If dgvws.CurrentRow.Cells("chave_nfce").Value.ToString.Substring(34, 1) = "9" Then
            If dgvws.CurrentRow.Cells("status").Value <> "Autorizada" Then
                EnviarContigenciaToolStripMenuItem.Enabled = True
            End If
        Else
            EnviarContigenciaToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub gerar_cancelamento(ByVal i As Integer, ByVal subist As Boolean, ByVal chv As String, ByVal prot As String, ByVal chv_cont As String, Optional ByVal auto As Boolean = False)

        If auto = False Then
            Invoke(Sub() Panel_nfce.Visible = True)
            Invoke(Sub() txtinfo_nfce.Text = "NFCe: " & chv & ", Gerando arquivo para cancelamento !")
            Invoke(Sub() Panel_nfce.Refresh())

        Else
            Invoke(Sub() lblinfo_auto.Text = "NFCe: " & chv & ", Gerando XML Cancelamento....")
            Invoke(Sub() lblinfo_auto.Refresh())
        End If

        Dim xmlevento = New XmlDocument()
        Dim cancelamento As New NFe()

        cancelamento.versao = "1.00"
        cancelamento.tipo_cancelamento = "NFe"

        If subist = True Then

            cancelamento.Id = "110112" + chv + "01"
        Else
            cancelamento.Id = "110111" + chv + "01"
        End If

        cancelamento.coduf = chv.Substring(0, 2)
        cancelamento.tpAmb = empresa.ambiente_nfe
        cancelamento.cnpj = empresa.sCNPJ
        cancelamento.chave = chv
        cancelamento.dataenv = Now.ToString("yyyy-MM-ddTHH:mm:ss%K")
        cancelamento.xJust = "NOTA FISCAL EMITIDA INDEVIDAMENTE"
        cancelamento.nProt = prot
        cancelamento.chaveNFCE_vinculada = chv_cont

        If subist = True Then
            cancelamento.tipo_cancelamento = "NFCe"
            cancelamento.descenv = "Cancelamento por substituicao"
            cancelamento.codenv = "110112"
        Else
            cancelamento.descenv = "Cancelamento"
            cancelamento.codenv = "110111"
        End If

        Dim xmldoc As XmlDocument = cancelamento.GerarXMLCancelamento()

        ' xmldoc.Save("c:\teste\testecancelamentoXMLNaoAssinado.xml")

        If nfecer = "" Then
            certificado = SelecionarCertificado("")
        Else
            certificado = SelecionarCertificado(nfecer)
        End If

        'assina o xml
        xmlAssinado = CertificadoDigital.Assinar(xmldoc, "infEvento", certificado)

        Dim teste As New NFe()
        Dim nNumeroLote As String
        ''''''''''''''''''''''''''''Rotina para buscar lote de envio evento
        nNumeroLote = teste.GerarLoteNfe_dfe

        Dim esquema_receita As String

        If subist = True Then
            esquema_receita = "Evento_CancSubst\envEventoCancSubst_v1.00.xsd"
        Else
            esquema_receita = "Evento_Canc\envEventoCancNFe_v1.00.xsd"
        End If
        '''''''''''''''''''''''Valida o XML assinado

        xmlevento.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><envEvento versao=""1.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><idLote>" & nNumeroLote & "</idLote>" & xmlAssinado.InnerXml & "</envEvento>")

        Dim resultado As String = ValidaXML.ValidarXML(xmlevento, Application.StartupPath & "\Esquemas_XML_NF-e\" & esquema_receita & "")



        If resultado.Trim().Length = 0 Then
            '     resultado = "Xml gerado com sucesso, nenhum erro encontrado"
        End If

        If auto = False Then
            If resultado.Trim().Length <> 0 Then
                MsgBox(resultado, MsgBoxStyle.Information, "Aviso !")
                xmlevento.Save(Application.StartupPath & "\XML\nfecancelamento-nao_assinado.xml")
                Panel_nfce.Visible = False
                Exit Sub
            End If
        End If

        Using xmltw As New XmlTextWriter(Application.StartupPath & "\XML\nfecancelamento.xml", New UTF8Encoding(False))
            xmlevento.WriteTo(xmltw)
            xmltw.Close()
        End Using

        '''''''''''''''''''''''''''''saida da rotina


        ''''''''''''''''''''''''''''''Rotina abaixo que envia o xml de cancelamento para sefaz'''''''''''''''''''''

        If IsConectedToHost(New Uri("http://www.google.com")) = True Then

            If auto = False Then
                Envia_celamento(i, chv)
            Else
                Envia_celamento(0, chv, auto)
            End If


        Else
            '  MsgBox("Seu computador esta sem acesso internet" + vbCrLf + "Operação cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
            Invoke(Sub() Panel_nfce.Visible = False)
        End If


    End Sub

    Private Sub CancelamentoPorSubstituicaoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelamentoPorSubstituicaoToolStripMenuItem.Click
        If dgvws.CurrentRow.Cells("chave_cont").Value <> "" Then

            Control.CheckForIllegalCrossThreadCalls = False
            Dim rotina1 As Thread = New Thread(AddressOf ativa_cancelar)
            rotina1.SetApartmentState(ApartmentState.STA)

            rotina1.Start()


        End If

    End Sub


    Private Sub ativa_cancelar()
        gerar_cancelamento(dgvws.CurrentRow.Index, True, dgvws.CurrentRow.Cells("chave_nfce").Value, dgvws.CurrentRow.Cells("prot_grid").Value, dgvws.CurrentRow.Cells("chave_cont").Value)
    End Sub


    Private Sub env_reproc()
        Dim cont As Integer, cont2 As Integer
        Invoke(Sub() Panel_nfce.Visible = True)

        For Each row As DataGridViewRow In dgvws.Rows

            If row.Cells(0).Value = True Then
                cont += 1
            End If

        Next

        For Each row As DataGridViewRow In dgvws.Rows

            If row.Cells(0).Value = True Then
                cont2 += 1


                envia_contigencia(row.Index, dgvws.CurrentRow.Cells("chave_nfce").Value, dgvws.CurrentRow.Cells("xml_nfcegrid").Value, empresa.ambiente_nfe, cont, cont2, True)

            End If

        Next


    End Sub
    Private Sub env_cont()
        Dim cont As Integer, cont2 As Integer
        Invoke(Sub() Panel_nfce.Visible = True)

        For Each row As DataGridViewRow In dgvws.Rows

            If row.Cells(0).Value = True Then
                cont += 1
            End If

        Next

        For Each row As DataGridViewRow In dgvws.Rows

            If row.Cells(0).Value = True Then
                cont2 += 1
                envia_contigencia(row.Index, dgvws.CurrentRow.Cells("chave_nfce").Value, dgvws.CurrentRow.Cells("xml_nfcegrid").Value, empresa.ambiente_nfe, cont, cont2, False)
            End If

        Next


    End Sub

    Private Sub EnviarContigenciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnviarContigenciaToolStripMenuItem.Click
        dgvws.CurrentRow.Cells(0).Value = True
        Control.CheckForIllegalCrossThreadCalls = False
        Dim rotina1 As Thread = New Thread(AddressOf env_cont)
        rotina1.SetApartmentState(ApartmentState.STA)

        rotina1.Start()
    End Sub

    Private Sub ReprocessarXMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReprocessarXMLToolStripMenuItem.Click
        RecriarXML()

        dgvws.CurrentRow.Cells(0).Value = True
        Control.CheckForIllegalCrossThreadCalls = False
        Dim rotina1 As Thread = New Thread(AddressOf env_reproc)
        rotina1.SetApartmentState(ApartmentState.STA)

        rotina1.Start()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        frmoperador.ShowDialog()
    End Sub

    Private Sub envia_cont_auto()

        'Thread.Sleep(2000)

        'Invoke(Sub() lblinfo_auto.Visible = True)

        'conectar_mysqlDFe()
        'Dim SQLcommand22 As MySqlCommand
        'SQLcommand22 = oConn.CreateCommand
        'SQLcommand22.CommandText = "select * from cfe where (cod_sit ='1' or cod_sit ='9' or cod_sit ='2')"
        '   dr = SQLcommand.ExecuteReader()

        ' Using reader As MySqlDataReader = SQLcommand22.ExecuteReader

        'While reader.Read
        '    If ret_valor_campo("select * from cfe where chave_nfce ='" & reader("chave_nfce") & "'", "xml").ToString <> "" Then

        '        xmldoc.LoadXml(Base64Decode(ret_valor_campo("select * from cfe where chave_nfce ='" & reader("chave_nfce") & "'", "xml")))

        '        consulta_statusNF_auto(reader("chave_nfce"), xmldoc.OuterXml)
        '    End If
        'End While

        'End Using

        'resolve_pen()

        ' Invoke(Sub() lblinfo_auto.Visible = False)


    End Sub

    Private Sub resolve_pen()
        Dim chvc As String = ""

        conectar_mysqlDFe()
        Dim SQLcommand2 As MySqlCommand
        SQLcommand2 = oConn.CreateCommand
        SQLcommand2.CommandText = "select * from rv where (status_rv = 'Pendente' or status_rv = 'Contigencia')"
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand2.ExecuteReader

            While reader.Read

                '''''''''''''''''''''''Rotina abaixo verifica se a NFCe em contigencia esta autorizada'''''''
                If ret_valor_campo("select * from cfe where chave_nfce ='" & reader("chave_cont") & "'", "cod_sit").ToString = "100" Then

                    '''''''''''''''''''''''Rotina abaixo cancela a NFCe emitida indevidamente poara NFce com contigencia autorizada '''''''
                    If ret_valor_campo("select * from cfe where chave_nfce ='" & reader("chave_nfe") & "'", "xml").ToString <> "" Then

                        xmldoc.LoadXml(Base64Decode(ret_valor_campo("select * from cfe where chave_nfce ='" & reader("chave_nfe") & "'", "xml")))

                        consulta_statusNF_auto(reader("chave_nfe"), xmldoc.OuterXml)

                    End If

                Else


                    '''''''''''''''''''''''Rotina abaixo busca na tab CFe a chave da NFCe emitida em contigencia''''
                    Dim contnf As Integer = 0

                    conectar_mysql2()
                    Dim SQLcommand23 As MySqlCommand
                    SQLcommand23 = oConn2.CreateCommand
                    SQLcommand23.CommandText = "select * from cfe where rv ='" & reader("rv") & "'"

                    Using reader2 As MySqlDataReader = SQLcommand23.ExecuteReader

                        While reader2.Read
                            contnf += 1
                            If reader2("chave_nfce").ToString.Substring(34, 1) = "9" Then
                                chvc = reader2("chave_nfce").ToString
                            End If

                        End While

                    End Using
                    '''''''''''''''''''''''''''''''''###########################''''''''''''''''''''''''''''''''''''



                    '''''''''''''''''''''''Rotina abaixo e para buscar as NFCe emitida indevidamente para uma unica RV''''

                    If contnf > 2 Then
                        conectar_mysql2()
                        Dim SQLcommand233 As MySqlCommand
                        SQLcommand233 = oConn2.CreateCommand
                        SQLcommand233.CommandText = "select * from cfe where rv ='" & reader("rv") & "'"

                        Using reader2 As MySqlDataReader = SQLcommand233.ExecuteReader

                            While reader2.Read

                                If reader2("chave_nfce").ToString.Substring(34, 1) <> "9" Then

                                    If chvc <> "" Then
                                        Dim xml As String = Base64Decode(ret_valor_campo("select * from cfe where chave_nfce ='" & reader2("chave_nfce") & "'", "xml"))
                                        consulta_statusNF_auto(reader2("chave_nfce"), xml, chvc)
                                    End If

                                End If

                            End While

                        End Using

                    End If
                    ''''''''''''''''''''''''''''''''''''''##########################''''''''''''''''''''''''''''''''''''''''''''''''



                End If


            End While

        End Using


        '''''''''''''''Rotina abaixo para resolver o status da RV emitida em contigencia'''''''''''''''''

        conectar_mysqlDFe()
        Dim SQLcommand22 As MySqlCommand
        SQLcommand22 = oConn.CreateCommand
        SQLcommand22.CommandText = "select * from rv where (status_rv = 'Pendente' or status_rv = 'Contigencia')"
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand22.ExecuteReader

            While reader.Read

                If reader("chave_cont").ToString <> "" Then
                    If ret_valor_campo("select * from cfe where chave_nfce ='" & reader("chave_cont") & "'", "cod_sit").ToString = "100" Then

                        If ret_valor_campo("select * from cfe where chave_nfce ='" & reader("chave_nfe") & "'", "cod_sit").ToString = "4" Or ret_valor_campo("select * from cfe where chave_nfce ='" & reader("chave_nfe") & "'", "cod_sit").ToString = "3" Then

                            executa_query("update rv set status_rv = 'RV Autorizada' where rv = '" & reader("rv") & "'")

                        End If

                    End If
                End If

            End While

        End Using



        '''''''''''''''Rotina abaixo para resolver o status da RV'''''''''''''''''


    End Sub


    Private Sub envia_contigencia_auto(ByVal nchave As String, ByVal xml As String, ByVal ambiente As String)
        Dim WebS As New C_WebService
        Dim retEnviNFe As retEnviNFe
        Dim retConsReciNFe As retConsReciNFe

        Try
            xmldoc.LoadXml(gerar_xmlNFCe_envio(xml, ambiente))
        Catch ex As Exception
            xmldoc.LoadXml(xml)
        End Try

        xmldoc.Save(Application.StartupPath & "\xml\nfe\" & nchave & "env.xml")

        retEnviNFe = WebS.EnviaLote4(xmldoc, nchave, ambiente)


        If Not retEnviNFe.infRec Is Nothing Then
            If Not retEnviNFe.infRec.nRec Is Nothing Then
                nrecibo_cont = retEnviNFe.infRec.nRec
                Funcoes_sist.cfe(nchave, "", "", ambiente, "", "Contigencia Arquivo enviado", "2", nrecibo_cont)
            End If
        Else

            Invoke(Sub() lblinfo_auto.Text = "NFCe: " & chave & ", Ret envio: " & retEnviNFe.cStat & "-" & retEnviNFe.xMotivo)
            Invoke(Sub() lblinfo_auto.Refresh())
            Funcoes_sist.cfe(nchave, "", "", ambiente, "", retEnviNFe.xMotivo, retEnviNFe.cStat, "")
            Exit Sub
        End If


        If nrecibo_cont <> "" Then
            ''''''''''Rotina para consultar retorno envia xml para a SEFAZ'''''''''''''''''''''''''''''
            Invoke(Sub() lblinfo_auto.Text = "NFCe: " & chave & ", Consultando Recibo de Envio da NFCe SEFAZ...")
            Invoke(Sub() lblinfo_auto.Refresh())

            retConsReciNFe = WebS.ConsultaRecLote(nrecibo_cont, ambiente, nchave)

            If retConsReciNFe.cStat = "104" Then


                If retConsReciNFe.protNFe.infProt.cStat = "100" Then
                    Dim dados As XmlDocument = New XmlDocument
                    dados = GerarNotaProcessadanfce(SepararNota_NFe(xmldoc.OuterXml), retConsReciNFe.xmlprot)
                    '''''''''''''''''''''''''''Salva info no banco''''''''''''''''''''''''''
                    Funcoes_sist.cfe(nchave, "", dados.OuterXml, ambiente, "", retConsReciNFe.protNFe.infProt.xMotivo, retConsReciNFe.protNFe.infProt.cStat, "")

                    Invoke(Sub() lblinfo_auto.Text = "NFCe: " & chave & ", Retorno da SEFAZ: " & retEnviNFe.cStat & "-" & retEnviNFe.xMotivo & ", Protocolo aut.: " & retConsReciNFe.protNFe.infProt.nProt)
                    Invoke(Sub() lblinfo_auto.Refresh())
                    '''''''''''''''''''''Salvar arquivo ma pasta''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim Path As String = Application.StartupPath & "\NFCe"
                    If Not Directory.Exists(Path) Then Directory.CreateDirectory(Path)

                    dados.Save(Path & "\NFCe-" & retConsReciNFe.protNFe.infProt.chNFe & ".xml")

                    File.Delete(Application.StartupPath & "\CONTINGENCIA" & nchave & "-Contoff")
                    '''''''''''''''''Chama Rotina para resolver pendencia'''''''''''''''''
                    Dim ret As String = ret_valor_campo("select * from cfe where chave_nfce = '" & nchave & "'", "RV")
                    Dim ret2 As String = ret_valor_campo("select * from rv where chave_cont = '" & nchave & "'", "status_rv")

                    If ret2 <> "RV Autorizada" Then
                        executa_query("update rv set status_rv = 'Pendente' where rv = '" & ret & "'")
                    End If

                Else

                    If retConsReciNFe.protNFe.infProt.cStat = "204" Then

                        Dim nPost As Int32 = retConsReciNFe.protNFe.infProt.xMotivo.IndexOf("nRec:")
                        Dim rec As String = retConsReciNFe.protNFe.infProt.xMotivo.Substring(nPost + 5, retConsReciNFe.protNFe.infProt.xMotivo.Length - nPost - 6).Trim
                        nrecibo_cont = rec
                        executa_query("update cfe set nRec = '" & rec & "' where chave_nfce = '" & nchave & "'")

                    End If


                    Invoke(Sub() lblinfo_auto.Text = "NFCe: " & chave & ", Retorno da SEFAZ: " & retConsReciNFe.protNFe.infProt.cStat & "-" & retConsReciNFe.protNFe.infProt.xMotivo)
                    Invoke(Sub() lblinfo_auto.Refresh())
                    '''''''''''''''''''''''''''Salva info no banco''''''''''''''''''''''''''
                    Funcoes_sist.cfe(nchave, "", "", ambiente, "", retConsReciNFe.protNFe.infProt.xMotivo, retConsReciNFe.protNFe.infProt.cStat, "")

                End If

            Else

                Invoke(Sub() lblinfo_auto.Text = "NFCe: " & chave & ", Retorno da SEFAZ: " & retConsReciNFe.cStat & "-" & retConsReciNFe.xMotivo)
                Invoke(Sub() lblinfo_auto.Refresh())
            End If
        End If

    End Sub


    Private Sub consulta_statusNF_auto(ByVal nchave As String, ByVal xml As String, Optional ByVal chvc As String = "")

        Dim ws As Webservice4
        Dim retConsSitNFe As retConsSitNFe
        Dim chv As String
        autcont = False

        Try


            Dim rn As String = ret_valor_campo("select * from cfe where chave_nfce = '" & nchave & "'", "nRec")

            '  If rn = "" Then


            Invoke(Sub() lblinfo_auto.Text = "NFCe: " & nchave & ", Consultando status na SEFAZ...")
            Invoke(Sub() lblinfo_auto.Refresh())

            retConsSitNFe = WebS.ConsultaStatusNfe(nchave, empresa.ambiente_nfe)

            If retConsSitNFe.cStat = "100" Then

                Invoke(Sub() lblinfo_auto.Text = "NFCe: " & nchave & ", Retorno SEFAZ: " & retConsSitNFe.protNFe.infProt.xMotivo & " " & retConsSitNFe.protNFe.infProt.nProt & " " & Convert.ToDateTime(retConsSitNFe.protNFe.infProt.dhRecbto).ToString("dd/MM/yyyy HH:mm:ss"))
                Invoke(Sub() lblinfo_auto.Refresh())
                ' MsgBox("A Nota Fiscal Autorizada !" & vbCrLf & "Chave acesso: " & retConsSitNFe.chNFe & vbCrLf & "Protocolo Aut.: " & retConsSitNFe.protNFe.infProt.nProt & vbCrLf & "Status: " & retConsSitNFe.protNFe.infProt.xMotivo, MsgBoxStyle.Information, "Aviso ")

                Dim dados As XmlDocument = New XmlDocument

                If xml <> "" Then
                    xml = xml.ToString.Replace("<?xml version=""1.0"" encoding=""utf-8""?>", "")
                    xmldoc.LoadXml(xml)


                    ''''''''''''''''''''''''rotina para validar chave acesso banco

                    Dim xmllist As System.Xml.XmlNodeList
                    Dim xmlnode As XmlNode

                    xmllist = xmldoc.GetElementsByTagName("infNFe")

                    For Each xmlnode In xmllist
                        chv = xmlnode.Attributes.ItemOf("Id").InnerText.Substring(3, 44)
                    Next



                    dados = GerarNotaProcessadanfce(SepararNota_prot34(xmldoc.OuterXml), retConsSitNFe.xmlprot)

                    Dim Path As String = Application.StartupPath & "\NFCe"
                    If Not Directory.Exists(Path) Then Directory.CreateDirectory(Path)

                    dados.Save(Path & "\NFCe-" & retConsSitNFe.chNFe & ".xml")
                End If


                If nchave <> chv Then
                    Funcoes_sist.cfe(nchave, "", "", empresa.ambiente_nfe, "", "XML do banco com Divergencia de Chave acesso", "", "")
                Else
                    Funcoes_sist.cfe(nchave, "", dados.OuterXml, empresa.ambiente_nfe, "", retConsSitNFe.protNFe.infProt.xMotivo, retConsSitNFe.protNFe.infProt.cStat, "")
                End If


                ''''''''''''''''''Rotina para cancelar nfce duplicada com contigencia''''''''''''''
                If nchave.ToString.Substring(34, 1) = "1" Then

                    Dim par As String = ret_valor_campo("select * from cfe where chave_nfce = '" & nchave & "'", "RV")
                    Dim prot As String = ret_valor_campo("select * from cfe where chave_nfce = '" & nchave & "'", "nprot")
                    Dim par2 As String = ret_valor_campo("select * from rv where rv = '" & par & "'", "chave_cont")

                    If par2 <> "" Then

                        Invoke(Sub() lblinfo_auto.Text = "NFCe: " & nchave & ", Gerando xml cancelamento por Substituicao da NFCe duplicada...")
                        Invoke(Sub() lblinfo_auto.Refresh())
                        ''''''''''''''''''''rotina para para cancelar nfce em duplicidade.....
                        gerar_cancelamento(0, True, nchave, prot, par2, True)
                    End If


                    If chvc <> "" Then

                        Invoke(Sub() lblinfo_auto.Text = "NFCe: " & nchave & ", Gerando xml cancelamento por Substituicao da NFCe duplicada 2...")
                        Invoke(Sub() lblinfo_auto.Refresh())
                        ''''''''''''''''''''rotina para para cancelar nfce em duplicidade.....
                        gerar_cancelamento(0, True, nchave, prot, chvc, True)
                    End If
                End If

                If nchave.ToString.Substring(34, 1) = "9" Then

                    Dim ret As String = ret_valor_campo("select * from cfe where chave_nfce = '" & nchave & "'", "RV")
                    Dim ret2 As String = ret_valor_campo("select * from rv where chave_cont = '" & nchave & "'", "status_rv")

                    If ret2 <> "RV Autorizada" Then
                        executa_query("update rv set status_rv = 'Pendente' where rv = '" & ret & "'")
                    End If

                End If

            End If

            If retConsSitNFe.cStat = "101" Then


                Invoke(Sub() lblinfo_auto.Text = "NFCe: " & nchave & ", Nota Fiscal Cancelada, Protocolo Canc.: " & retConsSitNFe.procEventoNFe.retEvento.infEvento.nProt & ", Status: " & retConsSitNFe.procEventoNFe.retEvento.infEvento.xMotivo)
                Invoke(Sub() lblinfo_auto.Refresh())

                xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & retConsSitNFe.xmlprocevent & "")
                xmldoc.Save(Application.StartupPath & "\XML_nfecanc\" & retConsSitNFe.chNFe & "-procEventoNFe.xml")
                '   MsgBox("XML de Cancelamento gerado na pasta: " & Application.StartupPath & "\XML_nfecanc", MsgBoxStyle.Information, "Aviso ")

                conectar_mysqlDFe()
                Dim sql As String = "update cfe set cod_sit = '3', sit_nfce = '" & retConsSitNFe.procEventoNFe.retEvento.infEvento.xMotivo & "',xml = '', xml_canc = '" & Convert.ToBase64String(Encoding.UTF8.GetBytes(xmldoc.OuterXml)) & "' where chave_nfce = '" & nchave & "'"
                Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)

                insertSQL.ExecuteNonQuery()

                oConn.Close()


            End If

            If retConsSitNFe.cStat <> "100" Then
                If retConsSitNFe.cStat <> "101" Then

                    Invoke(Sub() lblinfo_auto.Text = "NFCe: " & nchave & ", " & retConsSitNFe.cStat & "-" & retConsSitNFe.xMotivo)
                    Invoke(Sub() lblinfo_auto.Refresh())



                    ''''''''''''''''''''Rotina para gerar inutilizacao da numeração''''''''''''''
                    If retConsSitNFe.cStat = "217" Then

                        Dim par As String = ret_valor_campo("select * from cfe where chave_nfce = '" & nchave & "'", "cod_sit")

                        If nchave.ToString.Substring(34, 1) <> "9" Then

                            '  Funcoes_sist.cfe(nchave, "", "", empresa.ambiente_nfe, "", retConsSitNFe.xMotivo, retConsSitNFe.cStat, "")

                            If par <> "4" Then
                                Invoke(Sub() lblinfo_auto.Text = "NFCe: " & nchave & ", Gerando xml Inutilizacao de Numero da NFCe gerado...")
                                Invoke(Sub() lblinfo_auto.Refresh())
                                ''''''''''''''''''''rotina para inutilizar numeracao.....
                                inutilizar(0, nchave, 0, 0, True)
                            End If

                        Else
                            ''''''''''''''''''''rotina para enviar contigencia.....

                            Invoke(Sub() lblinfo_auto.Text = "NFCe: " & nchave & ", Enviando xml NFCe para SEFAZ...")
                            Invoke(Sub() lblinfo_auto.Refresh())

                            envia_contigencia_auto(nchave, xml, empresa.ambiente_nfe)


                        End If

                    End If




                End If


            End If


        Catch ex As Exception
            ' MsgBox("Erro Rotina: consulta_statusNF_auto, " & ex.Message, MsgBoxStyle.Exclamation, "Aviso !")
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Control.CheckForIllegalCrossThreadCalls = False
        Dim rotina1 As Thread = New Thread(AddressOf envia_cont_auto)
        rotina1.SetApartmentState(ApartmentState.STA)

        rotina1.Start()
    End Sub

    Private Sub trat_rec(ByVal chv As String, ByVal rn As String)
        Invoke(Sub() lblinfo_auto.Text = "NFCe: " & chv & ", Verificano Recibo na SEFAZ...")
        Invoke(Sub() lblinfo_auto.Refresh())

        xmldoc.LoadXml(Base64Decode(ret_valor_campo("select * from cfe where chave_nfce ='" & chv & "'", "xml")))

        consulta_recibo_nfce_auto(chv, rn, xmldoc.OuterXml)
    End Sub


    Private Sub consulta_recibo_nfce_auto(ByVal chv As String, ByVal rn As String, ByVal xml As String)
        Dim retConsReciNFe As retConsReciNFe

        retConsReciNFe = WebS.ConsultaRecLote(rn, empresa.ambiente_nfe, chv)

        If retConsReciNFe.cStat = "104" Then


            If retConsReciNFe.protNFe.infProt.cStat = "100" Then
                Dim dados As XmlDocument = New XmlDocument


                If xml <> "" Then
                    xml = xml.ToString.Replace("<?xml version=""1.0"" encoding=""utf-8""?>", "")
                    xmldoc.LoadXml(xml)


                    ''''''''''''''''''''''''rotina para validar chave acesso banco

                    Dim xmllist As System.Xml.XmlNodeList
                    Dim xmlnode As XmlNode

                    xmllist = xmldoc.GetElementsByTagName("infNFe")

                    For Each xmlnode In xmllist
                        chv = xmlnode.Attributes.ItemOf("Id").InnerText.Substring(3, 44)
                    Next



                    dados = GerarNotaProcessadanfce(SepararNota_prot34(xmldoc.OuterXml), retConsReciNFe.xmlprot)

                    Dim Path As String = Application.StartupPath & "\NFCe"
                    If Not Directory.Exists(Path) Then Directory.CreateDirectory(Path)

                    dados.Save(Path & "\NFCe-" & retConsReciNFe.protNFe.infProt.chNFe & ".xml")
                End If


                Funcoes_sist.cfe(chv, "", dados.OuterXml, empresa.ambiente_nfe, "", retConsReciNFe.protNFe.infProt.xMotivo, retConsReciNFe.protNFe.infProt.cStat, "")


                If chv.Substring(34, 1) = "9" Then
                    Dim ret2 As String = ret_valor_campo("select * from rv where chave_cont = '" & chv & "'", "status_rv")
                    If ret2 = "Contigencia" Then
                        Dim ret As String = ret_valor_campo("select * from cfe where chave_nfce = '" & chv & "'", "RV")
                        executa_query("update rv set status_rv = 'Pendente' where rv = '" & ret & "'")
                    End If
                End If



            End If


            If retConsReciNFe.protNFe.infProt.cStat <> "100" Then

                executa_query("update cfe set nRec ='',  sit_nfce = '" & retConsReciNFe.protNFe.infProt.xMotivo & "', cod_sit = '" & retConsReciNFe.protNFe.infProt.cStat & "'  where chave_nfce = '" & chv & "'")

                If retConsReciNFe.protNFe.infProt.cStat = "204" Then

                    Dim nPost As Int32 = retConsReciNFe.protNFe.infProt.xMotivo.IndexOf("nRec:")
                    Dim rec As String = retConsReciNFe.protNFe.infProt.xMotivo.Substring(nPost + 5, retConsReciNFe.protNFe.infProt.xMotivo.Length - nPost - 6).Trim
                    ' Retarquivo.Add("RecDup", rec)
                    conectar_mysqlDFe()
                    Dim sql2 As String = "update cfe set nRec = '" & rec & "' where chave_nfce = '" & chv & "'"
                    Dim insertSQL2 As MySqlCommand = New MySqlCommand(sql2, oConn)

                    insertSQL2.ExecuteNonQuery()

                    oConn.Close()

                End If


                If retConsReciNFe.protNFe.infProt.cStat = "539" Then

                    Dim nPost As Int32 = retConsReciNFe.protNFe.infProt.xMotivo.IndexOf("nRec:")
                    Dim rec As String = retConsReciNFe.protNFe.infProt.xMotivo.Substring(nPost + 5, retConsReciNFe.protNFe.infProt.xMotivo.Length - nPost - 8).Trim

                    Dim nPost2 As Int32 = retConsReciNFe.protNFe.infProt.xMotivo.IndexOf("chNFe:")
                    Dim chv2 As String = retConsReciNFe.protNFe.infProt.xMotivo.Substring(nPost2 + 6, 44).Trim
                    ' Retarquivo.Add("RecDup", rec)

                    executa_query("update cfe set nRec = '" & rec & "', chave_nfce = '" & chv2 & "'  where chave_nfce = '" & chv & "'")

                    Dim ret As String = ret_valor_campo("select * from cfe where chave_nfce = '" & chv & "'", "RV")

                    If chv.Substring(34, 1) = "9" Then
                        executa_query("update rv set chave_cont = '" & chv2 & "'  where rv = '" & ret & "'")
                    Else
                        executa_query("update rv set chave_nfe = '" & chv2 & "'  where rv = '" & ret & "'")
                    End If

                End If

            End If

        End If



        '  Catch ex As Exception
        'If reterro <> "" Then
        'dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = "Erro Rotina1: Webservice, " & reterro
        ' Else
        'dgvws.Rows.Item(i).Cells("xmotivo_grid").Value = "Erro local1 Rotina: consulta_statusNF_online, " & ex.Message
        ' End If

        ' Invoke(Sub() Panel_nfce.Visible = False)
        '  End Try


    End Sub

    Private Sub Tws_Tick(sender As Object, e As EventArgs) Handles Tws.Tick
        lbltimer.Text += 1

        If lbltimer.Text = "1800" Then
            Control.CheckForIllegalCrossThreadCalls = False
            Dim rotina1 As Thread = New Thread(AddressOf envia_cont_auto)
            rotina1.SetApartmentState(ApartmentState.STA)

            rotina1.Start()

            lbltimer.Text = "0"
        End If
    End Sub

    Private Sub chkauto_CheckedChanged(sender As Object, e As EventArgs) Handles chkauto.CheckedChanged
        If chkauto.Checked = True Then
            Tws.Enabled = True
        Else
            Tws.Enabled = False
        End If
    End Sub


    Private Sub chkstatus_CheckedChanged(sender As Object, e As EventArgs) Handles chkstatus.CheckedChanged
        If chkstatus.Checked = True Then
            cbostatus.Enabled = True
            cbostatus.Focus()
        Else
            cbostatus.Enabled = False
        End If
    End Sub

    Private Sub chkcaixa_CheckedChanged(sender As Object, e As EventArgs) Handles chkcaixa.CheckedChanged
        If chkcaixa.Checked = True Then
            cbocaixa.Enabled = True
            cbocaixa.Focus()
        Else
            cbocaixa.Enabled = False
        End If
    End Sub

    Private Sub chknumero_CheckedChanged(sender As Object, e As EventArgs) Handles chknumero.CheckedChanged
        If chknumero.Checked = True Then
            txtnumero.Enabled = True
            txtnumero.Focus()
        Else
            txtnumero.Enabled = False
        End If
    End Sub

    Private Sub chkrv_CheckedChanged(sender As Object, e As EventArgs) Handles chkrv.CheckedChanged
        If chkrv.Checked = True Then
            txtrv.Enabled = True
            txtrv.Focus()
        Else
            txtrv.Enabled = False
        End If
    End Sub

    Private Sub chkdest_CheckedChanged(sender As Object, e As EventArgs) Handles chkdest.CheckedChanged
        If chkdest.Checked = True Then
            mskdest.Enabled = True
            mskdest.Focus()
        Else
            mskdest.Enabled = False
        End If
    End Sub

    Private Sub carregar_caixa()
        cbocaixa.Items.Clear()

        conectar_mysqlDFe()
        Dim SQLcommand2 As MySqlCommand
        SQLcommand2 = oConn.CreateCommand
        SQLcommand2.CommandText = "select * from caixa_cad"
        dr = SQLcommand2.ExecuteReader()

        While (dr.Read())
            cbocaixa.Items.Add(dr("caixa").ToString.PadLeft(3, "0"))
        End While

        dr.Close()
        SQLcommand2.Dispose()
        oConn.Close()

    End Sub

    Private Sub txtnumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumero.KeyPress
        If (e.KeyChar = Chr(13)) Then
            PESQUISA_NFCE()
        End If
    End Sub

    Private Sub txtrv_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtrv.KeyPress
        If (e.KeyChar = Chr(13)) Then
            PESQUISA_NFCE()
        End If
    End Sub

    Private Sub mskdest_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskdest.KeyPress
        If (e.KeyChar = Chr(13)) Then
            PESQUISA_NFCE()
        End If
    End Sub

    Private Sub cbocaixa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbocaixa.KeyPress
        If (e.KeyChar = Chr(13)) Then
            PESQUISA_NFCE()
        End If
    End Sub

    Private Sub cbostatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbostatus.KeyPress
        If (e.KeyChar = Chr(13)) Then
            PESQUISA_NFCE()
        End If
    End Sub

    Private Sub cbostatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbostatus.SelectedIndexChanged

    End Sub

    Private Sub txtnumero_TextChanged(sender As Object, e As EventArgs) Handles txtnumero.TextChanged

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        frmnfe_entrada.ShowDialog()
    End Sub

    Private Sub bntsintegra_Click(sender As Object, e As EventArgs) Handles bntsintegra.Click
        frmsintegravb.ShowDialog()
    End Sub

    Public Sub gerar_txterro(ByVal erro As String)

        Directory.CreateDirectory(Application.StartupPath & "\log_DFeerros")

        Dim arquivo As String = Application.StartupPath & "\log_DFeerros\" & Now.ToString("dd-MM-yyyy") & ".txt"
        Dim sep As String = "|"



        Dim fluxoTexto As System.IO.StreamReader
        Dim myList As New ArrayList


        If System.IO.File.Exists(arquivo) Then
            fluxoTexto = New System.IO.StreamReader(arquivo)
            While fluxoTexto.Peek() > -1
                myList.Add(fluxoTexto.ReadLine())
            End While
            fluxoTexto.Close()
        End If

        File.Delete(arquivo)

        Using writer As StreamWriter = New StreamWriter(arquivo, True)
            For Each l In myList
                writer.WriteLine(l)
            Next

            writer.WriteLine(erro & " - " & Now)

        End Using
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked

    End Sub

    Private Sub txtultnsudfe_TextChanged(sender As Object, e As EventArgs) Handles txtultnsudfe.TextChanged

    End Sub

    Private Sub btndifal_Click(sender As Object, e As EventArgs) Handles btndifal.Click
        frm_difalSG.Show()
    End Sub

    Private Sub bntpar_Click(sender As Object, e As EventArgs) Handles bntpar.Click
        frmparametro.ShowDialog()
    End Sub


    Private Sub chkcusto_CheckedChanged(sender As Object, e As EventArgs) Handles chkcusto.CheckedChanged

    End Sub

    Private Sub chkmanifes_CheckedChanged(sender As Object, e As EventArgs) Handles chkmanifes.CheckedChanged

    End Sub

    Private Sub chkxml_CheckedChanged(sender As Object, e As EventArgs) Handles chkxml.CheckedChanged

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If (WindowState = FormWindowState.Minimized) Then
            Hide()
        End If
    End Sub

    Private Sub lbllicenca_Click(sender As Object, e As EventArgs) Handles lbllicenca.Click
        frmlicenca.local = True
        frmlicenca.ShowDialog()
    End Sub


    Private Sub picon_Click(sender As Object, e As EventArgs) Handles picon.Click
        PararServico()
    End Sub

    Private Sub picoff_Click(sender As Object, e As EventArgs) Handles picoff.Click
        ativar_servidor()
    End Sub


    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        If IsConectedToHost(New Uri("http://www.google.com")) = True Then
            Pic_on_inter.Visible = True
            Pic_off_inter.Visible = False
        Else
            Pic_off_inter.Visible = True
            Pic_on_inter.Visible = False
        End If

        LinkLabel2.Visible = False
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        If dgverro.Visible = True Then
            dgverro.Visible = False
        Else
            dgverro.Visible = True
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        data_licenca = "01/01/0101"
        frmcert.Show()

        logar = True
        Me.Close()
    End Sub

    Private Sub chkxml_LostFocus(sender As Object, e As EventArgs) Handles chkxml.LostFocus
        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")
        arquivoIni.Write("salva_xmlpasta", chkxml.Checked, "MANIFESTO_AUTOMATICO")
    End Sub

    Private Function verifica_licenca(ByVal cnpj_l As String) As Boolean

        Dim dados_cnpj As String
        Dim dados_tp As String
        Dim ret As Boolean = False
        Dim key As String, key_id As String, tp As String

        ''''''''''''''''''''''licenca busca online'''''''''''''''''''''''
        licenca_liberada_online()

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from licenca where key_sist = 'DFe' and key_id = '" & Criptografar(cnpj_l) & "'"
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read

                key_id = Descriptografar(reader("key_id").ToString)
                tp = Descriptografar(reader("key_tp").ToString)
                key = Descriptografar(reader("key_chave").ToString)

            End While

        End Using


        If key = "" Then
            MsgBox("Você não possui Licença para esse CNPJ: " & cbocnpjdfe.Text & " !!!", MsgBoxStyle.Exclamation, "Aviso !")
            cbocnpjdfe.Text = cnpj_cert
            Return False
        End If

        If valida_date(RecuperarDataExpiracao(key)) = True Then
            MsgBox("Licença vencida !!!", MsgBoxStyle.Exclamation, "Aviso !")
            cbocnpjdfe.Text = cnpj_cert
            Return False
        End If



        If key_id <> RecuperarCNPJ(key) Then
            MsgBox("Licença de outro CNPJ !!!", MsgBoxStyle.Exclamation, "Aviso !")
            cbocnpjdfe.Text = cnpj_cert
            Return False
        End If


        If tp <> RecuperarTipoSistema(key) Then
            MsgBox("Tipo de Sistema diferente na licença !!!", MsgBoxStyle.Exclamation, "Aviso !")
            cbocnpjdfe.Text = cnpj_cert
            Return False
        End If


        data_licenca = RecuperarDataExpiracao(key)




        Return True

    End Function

    Public Shared Function DesmontarChave(ByVal chave As String) As String
        If chave.Length = 0 Then Return ""
        Try
            Using memoryCache As MemoryCache = MemoryCache.[Default]
                If memoryCache.Contains(chave, CStr(Nothing)) Then Return memoryCache.[Get](chave, CStr(Nothing)).ToString()
                Dim stringBuilder As StringBuilder = New StringBuilder()

                For startIndex As Integer = 0 To 36 - 1 Step 4
                    Dim result As Long
                    Long.TryParse(chave.Substring(startIndex, 4).Replace("X", String.Empty), NumberStyles.HexNumber, CType(Nothing, IFormatProvider), result)
                    Dim str As String = String.Format("{0:0000}", CObj(result))
                    stringBuilder.Append(str)
                Next

                Dim str1 As String = stringBuilder.ToString()
                memoryCache.Add(chave, CObj(str1), DateTimeOffset.Now.AddMinutes(1.0), CStr(Nothing))
                Return str1
            End Using
        Catch ex As Exception
            Return "erro"
        End Try

    End Function

    Public Shared Function RecuperarCNPJ(ByVal chave As String) As String
        Dim str1 As String = DesmontarChave(chave)
        If str1.Length <= 0 Then Return ""
        Dim str2 As String = str1.Substring(0, 14)
        Dim str3 As String = str1.Substring(str1.Length - 3, 3)
        Dim ch As Char = str3(0)
        Dim oldChar1 As Char = str3(1)
        Dim oldChar2 As Char = str3(2)
        '  Dim num As Integer = CInt(ch)
        Dim num As Integer = CInt(AscW(ch))
        Return str2.Replace(ChrW(num), "0"c).Replace(oldChar1, "1"c).Replace(oldChar2, "2"c)
    End Function

    Public Shared Function RecuperarDataExpiracao(ByVal chave As String) As DateTime
        Dim str As String = DesmontarChave(chave)
        If chave.Length <= 0 Then Return DateTime.MinValue
        Dim s1 As String = str.Substring(14, 2)
        Dim s2 As String = str.Substring(16, 2)
        Dim s3 As String = str.Substring(18, 2)
        Dim result1 As Integer
        Integer.TryParse(s1, result1)
        Dim result2 As Integer
        Integer.TryParse(s2, result2)
        Dim num As Integer

        Integer.TryParse(s3, num)
        Dim day As Integer = result1 - 20
        Dim month As Integer = result2 - 19
        Return New DateTime(num + 1965, month, day)
    End Function

    Public Shared Function RecuperarTipoSistema(ByVal chave As String) As Byte
        Dim result As Integer
        Integer.TryParse(DesmontarChave(chave)(32).ToString(), result)
        Return Convert.ToByte(result)
    End Function

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick

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

    Private Sub cbocnpjdfe_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbocnpjdfe.SelectedIndexChanged

        If frmcert.tipoCertA3 Then
            Exit Sub
        End If
        ''If verifica_licenca(cbocnpjdfe.Text) = True Then
        Dim cn As String = cbocnpjdfe.Text
        Dim senha_cert As String

        senha_cert = Busca_senha_cert(cbocnpjdfe.Text)
        Dim cnpj_grid2 As String = cbocnpjdfe.Text & Convert.ToDateTime(data_venc_cert).ToString("yyyy")

        Dim ret2 As New X509Certificate2(AppDomain.CurrentDomain.BaseDirectory & "cert\" & cnpj_grid2 & ".pfx", senha_cert, X509KeyStorageFlags.MachineKeySet)

        certificado = ret2
        certificado2 = ret2


        If CDate(certificado.NotAfter.ToString("dd/MM/yyyy")) < Now.Date Then

            MsgBox("Certificado digital venceu em: " & certificado.NotAfter.ToString("dd/MM/yyyy") & "" & vbCrLf & "adquira um Novo Certificado para acessar o Sistema.", MsgBoxStyle.Critical, "Aviso !")
            ' Dim wD As Long = DateDiff(DateInterval.Day, CDate(certificado.NotAfter.ToString), Now.Date)

            '  MsgBox("Faltam " & wD.ToString & " dias para seu certificado digital vencer !", MsgBoxStyle.Exclamation, "Aviso !")

            cbocnpjdfe.Text = cnpj_cert
            Exit Sub
        Else

            Dim wD2 As Long = DateDiff(DateInterval.Day, Now.Date, CDate(certificado.NotAfter.ToString))

            If wD2 <= 30 Then
                'MsgBox("Faltam " & wD2 & " dias para seu certificado digital vencer !", MsgBoxStyle.Exclamation, "Aviso !")
            End If

            txtvenc_info.Text = certificado.NotAfter.ToString("dd/MM/yyyy")
            lblvenc_info.Text = "Faltam " & wD2 & " dias p/venc."

        End If



        cnpj_cert = ExtrairCNPJ(certificado)


        frmcert.carrega_emp(ret2, "a1")

        frmparametro.carregar_cert(certificado)

        frminfocertificado.carregar(certificado)

        Me.Text = versao_sist & empresa.sNomeRazao & "  |  " & "Versão sem Licença (Frree)"

        carregar_nsu()

        ''    End If
    End Sub

    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click
        If WindowState = FormWindowState.Minimized Then

            Show()

            WindowState = FormWindowState.Normal

        End If
    End Sub

    Private Sub SairToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SairToolStripMenuItem.Click
        If MessageBox.Show("Deseja realmente fechar o Sistema ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            End
        End If
    End Sub

    Private Sub ConsultaRetornoSEFAZToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaRetornoSEFAZToolStripMenuItem.Click
        Control.CheckForIllegalCrossThreadCalls = False
        Dim rotina1 As Thread = New Thread(AddressOf retSefaz)
        rotina1.SetApartmentState(ApartmentState.STA)

        rotina1.Start()
    End Sub

    Private Sub retSefaz()
        consultaRetEnvio(dgvws.CurrentRow.Cells("nRec").Value, dgvws.CurrentRow.Index, 1, empresa.ambiente_nfe, dgvws.CurrentRow.Cells("chave_nfce").Value, dgvws.CurrentRow.Cells("xml_nfcegrid").Value)
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        frmParCarga.ShowDialog()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        gerar_evento_nfe(1, "210210", "Ciencia da Operacao", "")
    End Sub

    Private Sub ConsultaPorNSUToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaPorNSUToolStripMenuItem.Click
        consulta_NSU()
    End Sub

    Private Sub ConsultaNSUToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaNSUToolStripMenuItem.Click
        consulta_NSU()
    End Sub

    Private Async Function PesquisarBucketS3Dfe() As Task

        Try
            Dim chavesParaDeletar As New List(Of KeyVersion)
            Dim retDFE As retDistDFeInt
            Dim bucketName As String = "dfe-xml-rfb-02"
            Dim listaXmls As New List(Of String)

            Dim config = New AmazonS3Config With {
                .RegionEndpoint = Amazon.RegionEndpoint.USEast1,
                .Timeout = TimeSpan.FromSeconds(20) ' Aumentei um pouco para garantir a deleção
            }

            txtinfodfe.Text = "Conectando ao S3 DFe, aguarde..."
            txtinfodfe.Refresh()

            ' MANTEMOS O USING ABERTO PARA TODA A OPERAÇÃO
            Using client As New AmazonS3Client(config)

                ' 1. LISTAGEM E DOWNLOAD
                Dim listRequest As New ListObjectsV2Request With {
                    .BucketName = bucketName,
                    .Prefix = $"{cbocnpjdfe.Text}/"
                }

                Dim listResponse = Await client.ListObjectsV2Async(listRequest)

                For Each s3Object As S3Object In listResponse.S3Objects
                    ' IMPORTANTE: Apenas processa e deleta ARQUIVOS (Size > 0)
                    If s3Object.Size > 0 Then
                        chavesParaDeletar.Add(New KeyVersion With {.Key = s3Object.Key})

                        Dim getRequest As New GetObjectRequest With {
                            .BucketName = bucketName,
                            .Key = s3Object.Key
                        }

                        Using getResponse As GetObjectResponse = Await client.GetObjectAsync(getRequest)
                            Using reader As New StreamReader(getResponse.ResponseStream)
                                Dim xmlString As String = Await reader.ReadToEndAsync()
                                If Not String.IsNullOrWhiteSpace(xmlString) Then
                                    listaXmls.Add(xmlString)
                                End If
                            End Using
                        End Using
                    End If
                Next

                ' 2. PROCESSAMENTO (SUA LÓGICA DE NEGÓCIO)
                Dim count = 1
                For Each docS3 As String In listaXmls
                    retDFE = Await funcoesNfe.DeserializarNFeAsync(Of retDistDFeInt)(docS3)
                    txtinfodfe.Text = $"Processando registro encontrados no bucket S3 DFe: {count} de {listaXmls.Count}"
                    txtinfodfe.Refresh()
                    count += 1

                    For Each doc In retDFE.loteDistDFeInt
                        xmldoc.LoadXml(Await DecompressGZipAsync(doc.Value))
                        total_reg()

                        ' Suas validações de schema...
                        If doc.schema.ToLower().StartsWith("resnfe") Then Await resnfeAsync(xmldoc)
                        If doc.schema.ToLower().Contains("proceventonfe") Then Await resprotnfeAsync(xmldoc)
                        If doc.schema.ToLower().StartsWith("procnfe") Then Await resprotnfeAsync(xmldoc)
                    Next
                Next

                ' 3. DELEÇÃO (DENTRO DO USING CLIENT)
                If chavesParaDeletar.Count > 0 Then
                    txtinfodfe.Text = "Limpando bucket S3..."
                    txtinfodfe.Refresh()

                    Dim deleteRequest As New DeleteObjectsRequest With {
                        .BucketName = bucketName,
                        .Objects = chavesParaDeletar
                    }

                    ' Chamada da deleção usando o mesmo client
                    Await client.DeleteObjectsAsync(deleteRequest)
                End If

            End Using ' O client só é fechado aqui no final de tudo

            txtinfodfe.Text = "Pesquisa realizada em: " & DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")

            ''  MessageBox.Show("Leitura e limpeza realizadas com sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As AmazonS3Exception
            txtinfodfe.Text = $"Erro S3: {ex.ErrorCode} - {ex.Message}"
            MessageBox.Show($"Erro S3: {ex.ErrorCode} - {ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            txtinfodfe.Text = $"Erro Geral: {ex.Message}"
            MessageBox.Show($"Erro Geral: {ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Function Busca_senha_cert(ByVal cnpj_r As String) As String
        Dim ret As String
        Dim dictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim stringBuilder As StringBuilder = New StringBuilder()
        stringBuilder.Append("Select * from cert where cnpj = '" & cnpj_r & "'")


        conectar_mysqlDFe()


        Dim SQLcommand As MySqlCommand

        SQLcommand = oConn.CreateCommand

        SQLcommand.CommandText = stringBuilder.ToString

        dr = SQLcommand.ExecuteReader()


        If Directory.Exists(Application.StartupPath & "\cert") = False Then
            Directory.CreateDirectory(Application.StartupPath & "\cert")
        End If

        While (dr.Read())

            If File.Exists(Application.StartupPath & "\cert\" & dr("cnpj") & Convert.ToDateTime(dr("Data_venc")).ToString("yyyy") & ".pfx") = False Then
                Dim bytes = TryCast(dr("cert_arq"), Byte())
                File.WriteAllBytes(Application.StartupPath & "\cert\" & dr("cnpj") & Convert.ToDateTime(dr("Data_venc")).ToString("yyyy") & ".pfx", bytes)
            End If

            ret = Crypto.Decrypt2(dr("senha"))

            data_venc_cert = dr("Data_venc")

        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()

        Return ret

    End Function

    Private Sub Timer_manifest_Tick(sender As Object, e As EventArgs) Handles Timer_manifest.Tick
        If cont_manifest_t <> 0 Then

            Try
                If rotina_dfe_m Is Nothing OrElse Not rotina_dfe_m.IsAlive Then
                    lbltimer_m.Visible = True
                    lblinfo_m.Visible = True


                    cont_manifest_t = cont_manifest_t - cont_manifest
                    lblinfo_m.Text = cont_manifest_t
                    Control.CheckForIllegalCrossThreadCalls = False
                    rotina_dfe_m = New Thread(AddressOf gerar_evento_lote)
                    rotina_dfe_m.SetApartmentState(ApartmentState.STA)
                    rotina_dfe_m.Start()
                End If
            Catch ex As Exception
                lbltimer_m.Visible = True
                lblinfo_m.Visible = True


                cont_manifest_t = cont_manifest_t - cont_manifest
                lblinfo_m.Text = cont_manifest_t
                Control.CheckForIllegalCrossThreadCalls = False
                rotina_dfe_m = New Thread(AddressOf gerar_evento_lote)
                rotina_dfe_m.SetApartmentState(ApartmentState.STA)
                rotina_dfe_m.Start()
            End Try

        End If

        If cont_manifest_t = 0 Then
            lbltimer_m.Text = "0"
            lbltimer_m.Visible = False
            lblinfo_m.Visible = False
            Timer_manifest.Dispose()
        End If

        lbltimer_m.Text += 1
    End Sub


    Private Sub gerar_evento_lote_cont()

        cont_manifest_t = 0

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from nfe where cnpj_dest= '" & cnpj_cert & "' and nprot_manif IS NULL and xml_nfe IS NULL and Tipo_nfe ='1-NFe Saida' and xmot_manif IS NULL"
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())
            cont_manifest_t += 1
        End While
        oConnS.Close()

    End Sub
    Private Sub gerar_evento_lote()

        Dim cont As Integer = 0

        Dim teste As New NFe()
        Dim xml As String, dataevento As String
        Dim xmlevento = New XmlDocument()
        Dim manifestacao As New NFe()

        Invoke(Sub() Pic_prog.Visible = True)


        dataevento = Now.ToString("yyyy-MM-ddTHH:mm:ss%K")


        txtinfodfe.Text = "Gerando xml Manifestacao (Ciencia Operacao Automatica)..."

        cont_manifest = 0


        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from nfe where cnpj_dest= '" & cnpj_cert & "' and nprot_manif IS NULL and xml_nfe IS NULL and Tipo_nfe ='1-NFe Saida' and xmot_manif IS NULL"
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())


            cont += 1

            If cont <= 20 Then

                manifestacao.versao = "1.00"
                '''''''''''''codico ciencia operação''''''''''''''''''
                manifestacao.Id = "210210" + dr("chave_nfe") + "01"
                manifestacao.chave = dr("chave_nfe")
                manifestacao.coduf = "91"

                If cnpj_cert.Length = 11 Then
                    manifestacao.cpf = cnpj_cert
                    manifestacao.cnpj = Nothing
                Else
                    manifestacao.cnpj = cnpj_cert
                    manifestacao.cpf = Nothing
                End If

                manifestacao.dataenv = dataevento
                manifestacao.codenv = "210210"
                manifestacao.descenv = "Ciencia da Operacao"
                manifestacao.xJust = ""
                manifestacao.tpAmb = "1"

                Dim xmldoc As XmlDocument = manifestacao.Gerarmanifestacaodest()

                ' xmldoc.Save(Application.StartupPath & "\XML\manifestacaoNaoAssinado.xml")

                'assina os xml selecionados
                Dim xmlAssinado As XmlDocument = CertificadoDigital.Assinar(xmldoc, "infEvento", certificado)
                xml = xml + xmlAssinado.InnerXml

                cont_manifest += 1
            Else
                Exit While
            End If


        End While
        oConn.Close()

        If dr.HasRows = False Then
            Invoke(Sub() Pic_prog.Visible = False)
            txtinfodfe.Text = "Cunsulta Realiza em " & Now
        End If

        '''''''''''''''''CRIAR E GERA LOTE DOS EVENTOS''''''''''''''''''''''''''''''''''''''''''''''''''
        If xml <> "" Then

            '''''''''''''''''''''''''''''''''''''''''''''''''''' GERA O ARQUIVO XML DA MANIFESTAÇÃO''''''''''''''''''''''''''''''''''
            xmlevento.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><envEvento versao=""1.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><idLote>" & teste.GerarLoteNfe_dfe() & "</idLote>" & xml & "</envEvento>")
            xmlevento.Save(Application.StartupPath & "\XML\evento.xml")

            'Valida o XML assinado
            Dim resultado As String = ValidaXML.ValidarXML(xmlevento, Application.StartupPath & "\Esquemas_XML_NF-e\envConfRecebto_v1.00.xsd")

            If resultado.Trim().Length <> 0 Then
                MsgBox(resultado)
                ' resultado = "Xml gerado com sucesso, nenhum erro encontrado"
                Exit Sub
            End If

            Using xmltw As New XmlTextWriter(Application.StartupPath & "\XML\evento_auto.xml", New UTF8Encoding(False))
                xmlevento.WriteTo(xmltw)
                xmltw.Close()
            End Using


            '''''''''''''''''Rotina para enviar manifestacao da RFB''''''''

            txtinfodfe.Text = "Realizando Manifestacao do destinatário (Ciencia Operacao em Lote)..."
            manifestacao_dest_auto()

        Else

            Invoke(Sub() Pic_prog.Visible = False)

        End If

    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        If panel_chave.Visible = False Then
            panel_chave.Visible = True
        Else
            panel_chave.Visible = False
        End If
    End Sub

    Private Sub consulta_NSU()
        Try

            tipo_consulta = "DFe_cons"
            bntcancelar.Visible = True
            txtinfodfe.Text = "Aguarde, Sistema em execução (Cosultando o NSU: " & txtultnsudfe.Text & ")...."
            Control.CheckForIllegalCrossThreadCalls = False
            rotina_dfe = New Thread(AddressOf DFeconsulta_nfe4)
            rotina_dfe.SetApartmentState(ApartmentState.STA)
            rotina_dfe.Start()
        Catch ex As Exception
            txtinfodfe.Text = "Rotina (pesquisa_chave): " & ex.Message
        End Try
    End Sub

    Private Sub NotifyIcon1_MouseMove(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseMove
        Dim nome As String = empresa.sNomeRazao
        If nome.Length >= 58 Then
            nome = empresa.sNomeRazao.Substring(0, 58)
        End If
        NotifyIcon1.Text = "DFe: " & nome
    End Sub

    Private Function validar_ultima_exec()
        Dim dataHoraPar As DateTime = Convert.ToDateTime(lblultimaexec.Text)
        Dim diferenca As TimeSpan = Now - dataHoraPar

        If diferenca.Hours >= 1 Then
            Return True
        End If

        Return False
    End Function

End Class