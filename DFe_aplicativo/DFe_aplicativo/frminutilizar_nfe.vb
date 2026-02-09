Imports System.Xml
Imports System.Threading
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frminutilizar_nfe
    Dim ambiente As String
    Dim numero_nfe As Integer
    Dim rs As New ADODB.Recordset
    Dim rotina1 As Thread, rotina2 As Thread
    Dim dataenv As String, xmlret_evento As String
    Dim WebS As New C_WebService
    Dim retorevento As New retInutNFe
    Dim xmlAssinado As XmlDocument
    Private Sub txtnfinal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnfinal.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtninicial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtninicial.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub gerar_inutilizacao()
        pinfo.Visible = True
        txtinfo.Text = "Aguarde, Gerando arquivo para Inutilizacao !"
        pinfo.Refresh()

        Dim xmlevento = New XmlDocument()
        Dim inutilizar As New NFe()



        inutilizar.versao = "4.00"
        ' inutilizar.Id = ""
        inutilizar.Id = txtcuf.Text & txtano.Text & empresa.sCNPJ & txtmod.Text & txtserie.Text.PadLeft(3, "0") & txtninicial.Text.PadLeft(9, "0") & txtnfinal.Text.PadLeft(9, "0")
        If lblambiente.Visible = True Then
            inutilizar.tpAmb = "2"
        Else
            inutilizar.tpAmb = "1"
        End If

        inutilizar.coduf = txtcuf.Text
        inutilizar.ano = txtano.Text
        inutilizar.cnpj = empresa.sCNPJ
        inutilizar.MOD_INU = txtmod.Text
        inutilizar.Serie = txtserie.Text
        inutilizar.NumNf_Ini = txtninicial.Text
        inutilizar.NumNf_Fin = txtnfinal.Text
        inutilizar.xJust = txtmotivo.Text.TrimEnd()





        Dim xmldoc As XmlDocument = inutilizar.GerarXMLinutilizacao()

        ' xmldoc.Save("c:\teste\testecancelamentoXMLNaoAssinado.xml")


        'assina o xml
        xmlAssinado = CertificadoDigital.Assinar(xmldoc, "infInut", certificado)



        '''''''''''''''''''''''Valida o XML assinado

        xmlevento.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?> " & xmlAssinado.InnerXml)

        Dim resultado As String = ValidaXML.ValidarXML(xmlevento, Application.StartupPath & "\Esquemas_XML_NF-e\inutNFe_v4.00.xsd")

        If resultado.Trim().Length = 0 Then
            '     resultado = "Xml gerado com sucesso, nenhum erro encontrado"
        End If

        If resultado.Trim().Length <> 0 Then
            MsgBox(resultado, MsgBoxStyle.Information, "Aviso !")
            xmlevento.Save(Application.StartupPath & "\XML\Inutilizacaonao_assinado.xml")
            pinfo.Visible = False
            Exit Sub
        End If

        Using xmltw As New XmlTextWriter(Application.StartupPath & "\XML\Inutilizacao_nfe.xml", New UTF8Encoding(False))
            xmlevento.WriteTo(xmltw)
            xmltw.Close()
        End Using

        '''''''''''''''''''''''''''''saida da rotina

        ' Exit Sub
        ''''''''''''''''''''''''''''''Rotina abaixo que envia o xml de cancelamento para sefaz'''''''''''''''''''''

        If IsConectedToHost(New Uri("http://www.google.com")) = False Then
            MsgBox("Seu computador esta sem acesso internet" + vbCrLf + "Operação cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        Control.CheckForIllegalCrossThreadCalls = False
        rotina1 = New Thread(AddressOf Envia_inutilizacao)
        rotina1.SetApartmentState(ApartmentState.STA)

        rotina1.Start()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If txtninicial.Text = "" Then
            MsgBox("Informe o Numero inicial a ser Inutilizado !", MsgBoxStyle.Exclamation, "Aviso")
            txtninicial.Focus()
            Exit Sub
        End If

        If txtnfinal.Text = "" Then
            MsgBox("Informe o Numero Final a ser Inutilizado !", MsgBoxStyle.Exclamation, "Aviso")
            txtnfinal.Focus()
            Exit Sub
        End If

        If txtmotivo.Text = "" Then
            MsgBox("Informe o motivo da Inutilizacao da Numeracao da NF-e", MsgBoxStyle.Exclamation, "Aviso")
            Exit Sub
        End If

        If txtmotivo.Text.Length < 15 Then
            MsgBox("Motivo da Inutilizacao da Numeracao da NF-e deve conter no minimo 15 caracter", MsgBoxStyle.Exclamation, "Aviso")
            Exit Sub
        End If

        gerar_inutilizacao()

    End Sub

    Private Sub Envia_inutilizacao(ByVal i As Integer)
        Dim xmlretcanc = New XmlDocument()
        Dim procInutNFe As New retInutNFe
        Dim sql As String

        pinfo.Visible = True
        txtinfo.Text = "Aguarde, Enviando Inutilizacao da NF-e para SEFAZ..."
        pinfo.Refresh()

        Try

            procInutNFe = WebS.NfeInutilizacao(Application.StartupPath & "\XML\Inutilizacao_nfe.xml", gerar_chave_acesso(), empresa.ambiente_nfe)



            If procInutNFe.infInut.cStat = "102" Then
                Directory.CreateDirectory(Application.StartupPath + "\XML_Inut")

                xmlretcanc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><procInutNFe versao=""2.00"" xmlns=""http://www.portalfiscal.inf.br/nfe"">" & xmlAssinado.InnerXml & "" & procInutNFe.xml & "</procInutNFe>")
                xmlretcanc.Save(Application.StartupPath + "\XML_Inut\" + retorevento.infInut.nProt + "-InutNfe.xml")
                '  xmlretcanc.Save(Application.StartupPath + "\XML_Inut\" + procInutNFe.infInut.nProt + "-InutNfe.xml")


                sql = "INSERT INTO nfe_nfe_inutilizada (N_ini, N_fim, serie, nprot, xmotivo, data_hora, ambiente, cnpj_emp) VALUES (@N_ini, @N_fim, @serie, @nprot, @xmotivo, @data_hora, @ambiente, @cnpj_emp)"



                conectar_mysqlDFe()
                Dim insertSQL2 As MySqlCommand = New MySqlCommand(sql, oConn)

                insertSQL2.Parameters.Add(New MySqlParameter("N_ini", txtninicial.Text))
                insertSQL2.Parameters.Add(New MySqlParameter("N_fim", txtnfinal.Text))
                insertSQL2.Parameters.Add(New MySqlParameter("serie", txtserie.Text))
                insertSQL2.Parameters.Add(New MySqlParameter("nprot", retorevento.infInut.nProt))
                insertSQL2.Parameters.Add(New MySqlParameter("xmotivo", txtmotivo.Text))
                insertSQL2.Parameters.Add(New MySqlParameter("data_hora", Convert.ToDateTime(retorevento.infInut.dhRecbto).ToString("yyyy-MM-dd HH:mm:ss")))
                insertSQL2.Parameters.Add(New MySqlParameter("ambiente", txtmotivo.Text))
                insertSQL2.Parameters.Add(New MySqlParameter("cnpj_emp", empresa.sCNPJ))

                insertSQL2.ExecuteNonQuery()
                oConn.Close()



                MsgBox(procInutNFe.infInut.cStat & "-" & procInutNFe.infInut.xMotivo, MsgBoxStyle.Information, "Aviso !")

             
            Else


                If procInutNFe.infInut.cStat = "241" Then
                    executa_query("delete from nfe_inutilizada where N_ini = '" & txtninicial.Text & "' and cnpj_emp = '" & empresa.sCNPJ & "' ")
                End If

                MsgBox(procInutNFe.infInut.cStat & "-" & procInutNFe.infInut.xMotivo, MsgBoxStyle.Exclamation, "Aviso !")


            End If

            carrega_dados()
            Invoke(Sub() pinfo.Visible = False)

            Invoke(Sub() limpar())

        Catch ex As Exception
            If reterro = "" Then
                MsgBox("Rotina: Envia_inutilizacao " & reterro, MsgBoxStyle.Exclamation, "Aviso !")
            Else
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Aviso 2 !")
            End If
            Invoke(Sub() pinfo.Visible = False)
        End Try
        ''''''''''''''''Rotina ativa webservice''''''''''''''''''''''''


    End Sub

    Private Sub limpar()
        txtninicial.Clear()
        txtnfinal.Clear()
        txtmotivo.Clear()
    End Sub
    Private Sub busca_info()
        conectar_baseNFe()
        Dim rsultlote As New ADODB.Recordset
        Dim Sql As String = "select * from numeracao_nfe where cnpj_emi = '" & empresa.sCNPJ & "'"
        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = Sql


        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read
                txtserie.Text = reader("serie_nf").ToString.PadLeft(3, "0")
                txtmod.Text = reader("modelo_nf")
                txtano.Text = Now.ToString("yy")
            End While

        End Using




    End Sub

    Private Sub frminutilizar_nfe_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frminutilizar_nfe_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub frminutilizar_nfe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If frmxml_nfe.chkambiente.Checked = True Then
            ambiente = 1
            lblambiente.Visible = True
            lblambiente.Text = "Ambiente Produção"
        Else
            ambiente = 2
            lblambiente.Visible = True
            lblambiente.Text = "Ambiente Homologação"
        End If

        busca_info()

        carrega_dados()


    End Sub

    Private Sub carrega_dados()
        Dim sql As String
        dgvinut.Rows.Clear()
        If empresa.ambiente_nfe = 1 Then
            sql = "select * from NFe_inutilizada where ambiente = 1 and cnpj_emp = '" & empresa.sCNPJ & "'"
        Else
            sql = "select * from NFe_inutilizada where ambiente = 2 and cnpj_emp = '" & empresa.sCNPJ & "'"
        End If

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql


        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read

                dgvinut.Rows.Add(reader("N_ini"), reader("N_fim"), reader("serie"), reader("nprot"), reader("xmotivo"))

            End While

        End Using

        For Each row As DataGridViewRow In dgvinut.Rows

            If row.Cells(3).Value.ToString = "" Then
                With Me.dgvinut.Rows(row.Index).DefaultCellStyle
                    .BackColor = Color.Red
                    .ForeColor = Color.White
                End With
            End If

        Next

    End Sub

    Private Sub txtninicial_LostFocus(sender As Object, e As EventArgs) Handles txtninicial.LostFocus
        If txtninicial.Text <> "" Then
            Dim ni As Integer = txtninicial.Text
            If ni >= numero_nfe Then
                MsgBox("Este Número não pode ser inutilizado porque ainda não Foi Usado !", MsgBoxStyle.Exclamation, "Aviso !")
                txtninicial.Text = ""
                txtninicial.Focus()
            End If
        End If
    End Sub

    Private Sub txtnfinal_LostFocus(sender As Object, e As EventArgs) Handles txtnfinal.LostFocus
        If txtnfinal.Text <> "" Then
            Dim ni As Integer = txtnfinal.Text
            If ni >= numero_nfe Then
                MsgBox("Este Número não pode ser inutilizado porque ainda não Foi Usado !", MsgBoxStyle.Exclamation, "Aviso !")
                txtnfinal.Text = ""
                txtnfinal.Focus()
            End If
        End If
    End Sub

    Private Sub dgvinut_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvinut.CellContentClick

    End Sub

    Private Sub dgvinut_Click(sender As Object, e As EventArgs) Handles dgvinut.Click
        If dgvinut.CurrentRow.Cells(3).Value.ToString = "" Then
            txtninicial.Text = dgvinut.CurrentRow.Cells(0).Value
            txtnfinal.Text = dgvinut.CurrentRow.Cells(1).Value
            txtmotivo.Text = "Falha na sequencia de Numeracao"
        End If
    End Sub

    Public Function gerar_chave_acesso()

        Dim chars = "0123456789"
        Dim random = New Random()
        Dim cNF = New String(Enumerable.Repeat(chars, 8).[Select](Function(s) s(random.[Next](s.Length))).ToArray())
        ''''''''''''''''''''''Rotina abaixo constroi a chave de acesso da nfe''''''''''''''
        Dim _codUF As String = txtcuf.Text
        Dim _dEmi As String = Now.ToString("yyMM")
        Dim _cnpj As String = empresa.sCNPJ
        Dim _mod As String = txtmod.Text
        Dim _tpEmis As String = "1"
        Dim _serie As String = String.Format("{0:000}", Int32.Parse(txtserie.Text))
        Dim _numNF As String = String.Format("{0:000000000}", Int32.Parse(txtninicial.Text))
        Dim _codigo As String = String.Format("{0:00000000}", Int32.Parse(cNF))
        Dim chaveNF As String = _codUF + _dEmi + _cnpj + _mod + _serie + _numNF + _tpEmis + _codigo

        Dim _dv As Integer = funcoesNfe.modulo11(chaveNF)
        Return chaveNF + _dv.ToString()

    End Function
End Class