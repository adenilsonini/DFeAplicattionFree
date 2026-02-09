Imports DFe_aplicativo.C_WebService
Public Class frmcadastro
    Dim WebS As New C_WebService
    Public ufsig As String
    Private Sub frmcadastro_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
  
    Private Sub cboweb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboweb.SelectedIndexChanged
        If cboweb.Text = "Sefaz Minas Gerais - (MG)" Then
            coduf = "31"
            ufsig = "MG"
            ' urlcad = "https://nfe.fazenda.mg.gov.br/nfe2/services/cadconsultacadastro2"

            WebS.url_webservice(BuscaURL("31", "1", False, "55"))

        End If

        If cboweb.Text = "Sefaz São Paulo - (SP)" Then
            coduf = "35"
            ufsig = "SP"
            '  urlcad = "https://nfe.fazenda.sp.gov.br/ws/cadconsultacadastro2.asmx"
            WebS.url_webservice(BuscaURL("35", "1", False, "55"))
        End If

        If cboweb.Text = "Sefaz Paraná - (PR)" Then
            coduf = "41"
            ufsig = "PR"
            '  urlcad = "https://nfe.fazenda.pr.gov.br/nfe/CadConsultaCadastro2?wsdl"
            WebS.url_webservice(BuscaURL("41", "1", False, "55"))
        End If

        If cboweb.Text = "Sefaz Rio Grande do Sul - (RS)" Then
            coduf = "43"
            ufsig = "RS"
            ' urlcad = "https://sef.sefaz.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro2.asmx"
            WebS.url_webservice(BuscaURL("43", "1", False, "55"))
        End If

        If cboweb.Text = "Sefaz Amazonas - (AM)" Then
            coduf = "13"
            ufsig = "AM"
            '    urlcad = "https://nfe.sefaz.am.gov.br/services2/services/cadconsultacadastro2"
            WebS.url_webservice(BuscaURL("13", "1", False, "55"))
        End If

        If cboweb.Text = "Sefaz Bahia - (BA)" Then
            coduf = "29"
            ufsig = "BA"
            '  urlcad = "https://nfe.sefaz.ba.gov.br/webservices/nfenw/CadConsultaCadastro2.asmx"
            WebS.url_webservice(BuscaURL("29", "1", False, "55"))
        End If

        If cboweb.Text = "Sefaz Ceará - (CE)" Then
            coduf = "23"
            ufsig = "CE"
            '  urlcad = "https://nfe.sefaz.ce.gov.br/nfe2/services/CadConsultaCadastro2"
            WebS.url_webservice(BuscaURL("23", "1", False, "55"))
        End If

        If cboweb.Text = "Sefaz Espírito Santo - (ES)" Then
            coduf = "32"
            ufsig = "ES"
            ' urlcad = "https://app.sefaz.es.gov.br/ConsultaCadastroService/CadConsultaCadastro2.asmx "
            WebS.url_webservice(BuscaURL("32", "1", False, "55"))
        End If

        If cboweb.Text = "Sefaz Goias - (GO)" Then
            coduf = "52"
            ufsig = "GO"
            '  urlcad = "https://nfe.sefaz.go.gov.br/nfe/services/v2/CadConsultaCadastro2?wsdl"
            WebS.url_webservice(BuscaURL("52", "1", False, "55"))
        End If

        If cboweb.Text = "Sefaz Mato Grosso - (MT)" Then
            coduf = "51"
            ufsig = "MT"
            '  urlcad = "https://nfe.sefaz.mt.gov.br/nfews/v2/services/CadConsultaCadastro2?wsdl"
            WebS.url_webservice(BuscaURL("51", "1", False, "55"))
        End If

        If cboweb.Text = "Sefaz Mato Grosso do Sul - (MS)" Then
            coduf = "50"
            ufsig = "MS"
            '   urlcad = "https://nfe.fazenda.ms.gov.br/producao/services2/CadConsultaCadastro2"
            WebS.url_webservice(BuscaURL("50", "1", False, "55"))
        End If

        If cboweb.Text = "Sefaz Pernambuco - (PE)" Then
            coduf = "26"
            ufsig = "PE"
            ' urlcad = "https://nfe.sefaz.pe.gov.br/nfe-service/services/CadConsultaCadastro2"
            WebS.url_webservice(BuscaURL("26", "1", False, "55"))
        End If

        If cboweb.Text = "Sefaz Maranhão - (MA)" Then
            coduf = "21"
            ufsig = "MA"
            ' urlcad = "https://sistemas.sefaz.ma.gov.br/wscadastro/CadConsultaCadastro2?wsdl"
            WebS.url_webservice(BuscaURL("21", "1", False, "55"))
        End If

        If cboweb.Text = "Sefaz atendidas AC, RN, PB, SC" Then
            cbouf.Visible = True
            Label21.Visible = True

            If cbouf.Text = "" Then
                MsgBox("Informe a UF da Sefaz Para Consulta !", MsgBoxStyle.Exclamation, "Aviso !")
                cbouf.Focus()
            End If

            If cbouf.Text = "AC" Then
                coduf = "12"
                WebS.url_webservice(BuscaURL("12", "1", False, "55"))
            ElseIf cbouf.Text = "RN" Then
                coduf = "24"
                WebS.url_webservice(BuscaURL("24", "1", False, "55"))
            ElseIf cbouf.Text = "PB" Then
                coduf = "25"
                WebS.url_webservice(BuscaURL("25", "1", False, "55"))
            ElseIf cbouf.Text = "SC" Then
                coduf = "42"
                WebS.url_webservice(BuscaURL("42", "1", False, "55"))
            End If

            ' urlcad = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro2.asmx"

        Else

            cbouf.Visible = False
            Label21.Visible = False

        End If


    End Sub

    Private Sub tcad_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcad.Tick
        lbltimer.Text = lbltimer.Text + 1

        If lbltimer.Text = "1" Then
            frminfo.txtinfo.Text = vbCrLf + "Aguarde, Realizando a Consulta do CNPJ Na " & cboweb.Text & " ..."
        End If
        If lbltimer.Text = "2" Then
            'cha a rotina para consulta nfe no sefaz mg

            Dim dadoscad As New Retcad
            '  dadoscad = WebS.CadConsultaCadastro2(mskcnpj.Text, ufsig)

            If ufsig = "MG" Then
                dadoscad = WebS.CadConsultaCadastro2(mskcnpj.Text, ufsig, coduf)
            Else
                dadoscad = WebS.CadConsultaCadastro4(mskcnpj.Text, ufsig, coduf)
            End If

            If dadoscad.cStat = "111" Or dadoscad.cStat = "112" Then
                MsgBox("Consulta Realizada, (1) registro encontrado !", MsgBoxStyle.Information, "Retorno do sefaz:")
            Else
                MsgBox("Retorno do sefaz: " & dadoscad.xmotivo, MsgBoxStyle.Exclamation, "Aviso!")
            End If


            If dadoscad.cStat = "111" Or dadoscad.cStat = "112" Then
                txtnome.Text = dadoscad.xnome
                txtnomefan.Text = dadoscad.xnomefan
                txtend.Text = dadoscad.xend
                txtnumero.Text = dadoscad.xnro
                mskcnpjre.Text = mskcnpj.Text
                mskcep.Text = dadoscad.xcep
                txtie.Text = dadoscad.xie
                txtcidade.Text = dadoscad.xmun
                txtcodmunicipio.Text = dadoscad.xcmun
                txtuf.Text = dadoscad.xuf
                txtbairro.Text = dadoscad.xbairro
                txtregime.Text = dadoscad.xRegApur
                txtcit.Text = dadoscad.xcSit
                mskdatacad.Text = dadoscad.xdIniAtiv
                txtobriganfe.Text = dadoscad.indCredNFe
                txtdatabaixa.Text = dadoscad.xdbaixa
                txtultimadata.Text = dadoscad.dUltSit

                If dadoscad.dUltSit <> "" Then
                    txtultimadata.Text = CDate(dadoscad.dUltSit).ToString("dd/MM/yyyy")
                End If

                pcad.Visible = True
                mskcnpjre.Mask = "00,000,000/0000-00"
                mskcep.Mask = "00,000-000"
                cadfuncao()
            End If


            'retorna o temino do processo1
         frminfo.Close()
        End If

        If lbltimer.Text = "3" Then
            tcad.Dispose()
        End If
    End Sub

    Private Sub cadfuncao()
        If txtobriganfe.Text = "0" Then
            txtobriganfe.Text = "Não credenciado para emissão da NF-e"
        End If
        If txtobriganfe.Text = "1" Then
            txtobriganfe.Text = "Credenciado a emissão da NF-e"
        End If
        If txtobriganfe.Text = "2" Then
            txtobriganfe.Text = "Credenciado com obrigatoriedade para todas operações"
        End If
        If txtobriganfe.Text = "3" Then
            txtobriganfe.Text = "Credenciado com obrigatoriedade parcial"
        End If
        If txtobriganfe.Text = "4" Then
            txtobriganfe.Text = "contribuinte é credenciado para emitir NF-e na SEFAZ consultada"
        End If

        If txtcit.Text = "0" Then
            txtcit.Text = "Não habilitado"
        End If
        If txtcit.Text = "1" Then
            txtcit.Text = "Habilitado"
        End If
    End Sub

    Private Sub bntconsultacad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntconsultacad.Click


        If cboweb.Text = "" Then
            MsgBox("Informe a Sefaz do Web service ?", MsgBoxStyle.Exclamation, "Aviso !")
            cboweb.Focus()
            Exit Sub
        End If
        If mskcnpj.Text = "" Then
            MsgBox("Informe o CNPJ No campo ao lado p/Consulta", MsgBoxStyle.Information, "Aviso !")
            mskcnpj.Focus()
            Exit Sub
        End If
        If cboweb.Text = "Sefaz Rio de Janeiro - (RJ)" Or cboweb.Text = "Sefaz Santa Catarina - (SC)" Then
            MsgBox("O sefaz Selecionado Não Possui consulta cadastro !", MsgBoxStyle.Exclamation, "Aviso !")
            cboweb.Focus()
            Exit Sub
        End If

        If cboweb.Text = "Sefaz atendidas AC, RN, PB, SC" Then
            If cbouf.Text = "" Then
                MsgBox("Informe a UF da Sefaz Para Consulta !", MsgBoxStyle.Exclamation, "Aviso !")
                cbouf.Focus()
                Exit Sub
            End If
        End If
        frminfo.Show()
        lbltimer.Text = "0"
        tcad.Enabled = True
    End Sub

    Private Sub cbouf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbouf.SelectedIndexChanged
        ufsig = cbouf.Text
    End Sub

    Private Sub mskcnpj_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskcnpj.MaskInputRejected

    End Sub
End Class