Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports MySql.Data.MySqlClient

Public Class FrmEmpresa
    Dim certificado As X509Certificate2
    Dim sql As String
    Dim rs As New ADODB.Recordset
    Dim pesquisa As Boolean
    Dim calcularIPI As String, serial_cert As String
    Dim reg_tributario As String
    Dim reg_especial As String

    Private Sub GravaEmpresa()
        If txtrazaosocial.Text = "" Then
            MsgBox("Informa a razão social", MsgBoxStyle.Information)
            TabControl1.SelectTab(TabPage1)
            txtrazaosocial.Focus()
            Exit Sub

        ElseIf txtendereco.Text = "" Then
            MsgBox("Informe o endereço", MsgBoxStyle.Information)
            TabControl1.SelectTab(TabPage1)
            txtendereco.Focus()
            Exit Sub

        ElseIf txtbairro.Text = "" Then
            MsgBox("Informe o bairro", MsgBoxStyle.Information)
            TabControl1.SelectTab(TabPage1)
            txtbairro.Focus()
            Exit Sub

        ElseIf txtcidade.Text = "" Then
            MsgBox("Informa a cidade", MsgBoxStyle.Information)
            TabControl1.SelectTab(TabPage1)
            txtcidade.Focus()
            Exit Sub

        ElseIf txtcnpj.Text = "" Then
            MsgBox("Informe o CNPJ", MsgBoxStyle.Information)
            TabControl1.SelectTab(TabPage1)
            txtcnpj.Focus()
            Exit Sub

        ElseIf txtie.Text = "" Then
            MsgBox("Informe a Inscrição Estadual", MsgBoxStyle.Information)
            TabControl1.SelectTab(TabPage1)
            txtie.Focus()
            Exit Sub

        ElseIf txtcep.Text = "" Then
            MsgBox("Informe o CEP", MsgBoxStyle.Information)
            TabControl1.SelectTab(TabPage1)
            txtcep.Focus()
            Exit Sub

            '  ElseIf txtcnae.Text = "" Then
            '    MsgBox("Informe o CNAE", MsgBoxStyle.Information)
            '   TabControl1.SelectTab(TabPage1)
            '   txtcnae.Focus()
            '    Exit Sub

            'ElseIf txtim.Text = "" Then
            '    MsgBox("Informe a Inscrição Municipal", MsgBoxStyle.Information, "Aviso !")
            '    TabControl1.SelectTab(TabPage1)
            '    txtim.Focus()
            '    Exit Sub


        End If

        If txtcodigo.Text = "Novo" Or verifica_certificado() = False Then

            Try

                Dim ret2 As New X509Certificate2(txtcaminho.Text, txtsenha.Text, X509KeyStorageFlags.MachineKeySet)
                certificado = ret2

                If Convert.ToDateTime(certificado.NotAfter).ToString("dd/MM/yyyy") < Now.Date Then

                    MsgBox("O Certificado Digital Selecionado esta Vencido !" & vbCrLf & "Operação Cancelada !", MsgBoxStyle.Exclamation, "Aviso !")

                    Exit Sub
                Else

                    cnpj_cert = ExtrairCNPJ(certificado)

                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Aviso !")
                Exit Sub
            End Try

            If txtcnpj.Text <> cnpj_cert Then
                MsgBox("CNPJ do Certificado Digital Diferente do CNPJ do cadastro !" & vbCrLf & "Operação Cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
                Exit Sub
            End If

        End If


        If optlucroreal.Checked = True Then
            '  rs.Fields("reg_tributario").Value = "3"

            If cnpj_emp = txtcnpj.Text Then
                regimetrib = "3"
            End If

        End If

        If optlucropresumido.Checked = True Then
            If cnpj_emp = txtcnpj.Text Then
                regimetrib = "2"
            End If
        End If

        If optsimplesnacional.Checked = True Then
            If cnpj_emp = txtcnpj.Text Then
                regimetrib = "1"
            End If
        End If


        '''''''''''''''''''''''Rotina abaixo para salvar numeração NFe

        Dim ret As Integer = verificar_regexiste("Select * from empresa where cnpj_emp = '" & txtcnpj.Text & "'")
        Dim sql As String

        If ret = 0 Then
            sql = "INSERT INTO empresa (razao_emp, Nome_fantasia, end_emp, numero_emp, bairro_emp, cep_emp, cod_munic, cnpj_emp, ie_emp, im_emp, fone_emp, cnae_emp, email_emp, reg_trib, num_pta, aliq_simples, csc, idtoken, Insc_st, calcular_ipi, reg_esp, emp_ativa, obs, ambiente_nfe, ambiente_nfce, cert, senha_cert, datavenc_cert, PDV) VALUES (@razao_emp, @Nome_fantasia, @end_emp, @numero_emp, @bairro_emp, @cep_emp, @cod_munic, @cnpj_emp, @ie_emp, @im_emp, @fone_emp, @cnae_emp, @email_emp, @reg_trib, @num_pta, @aliq_simples, @csc, @idtoken, @Insc_st, @calcular_ipi, @reg_esp, @emp_ativa, @obs, @ambiente_nfe, @ambiente_nfce, @cert, @senha_cert, @datavenc_cert, @PDV)"
        Else
            If txtcaminho.Text <> "" Then
                sql = "UPDATE empresa SET razao_emp = @razao_emp, Nome_fantasia = @Nome_fantasia, end_emp = @end_emp, numero_emp = @numero_emp, bairro_emp = @bairro_emp, cep_emp = @cep_emp, cod_munic = @cod_munic, cnpj_emp = @cnpj_emp, ie_emp = @ie_emp, im_emp = @im_emp, fone_emp = @fone_emp, cnae_emp = @cnae_emp, email_emp = @email_emp, reg_trib = @reg_trib, num_pta = @num_pta, aliq_simples = @aliq_simples, csc = @csc, idtoken = @idtoken, Insc_st = @Insc_st, calcular_ipi = @calcular_ipi, reg_esp = @reg_esp, emp_ativa = @emp_ativa, obs = @obs, ambiente_nfe = @ambiente_nfe, ambiente_nfce = @ambiente_nfce, cert = @cert, senha_cert = @senha_cert, datavenc_cert = @datavenc_cert, PDV = @PDV where cnpj_emp = '" & txtcnpj.Text & "'"
            Else
                sql = "UPDATE empresa SET razao_emp = @razao_emp, Nome_fantasia = @Nome_fantasia, end_emp = @end_emp, numero_emp = @numero_emp, bairro_emp = @bairro_emp, cep_emp = @cep_emp, cod_munic = @cod_munic, cnpj_emp = @cnpj_emp, ie_emp = @ie_emp, im_emp = @im_emp, fone_emp = @fone_emp, cnae_emp = @cnae_emp, email_emp = @email_emp, reg_trib = @reg_trib, num_pta = @num_pta, aliq_simples = @aliq_simples, csc = @csc, idtoken = @idtoken, Insc_st = @Insc_st, calcular_ipi = @calcular_ipi, reg_esp = @reg_esp, emp_ativa = @emp_ativa, obs = @obs, ambiente_nfe = @ambiente_nfe, ambiente_nfce = @ambiente_nfce, PDV = @PDV where cnpj_emp = '" & txtcnpj.Text & "'"
            End If
        End If

        conectar_mysqlDFe()
        Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)

        insertSQL.Parameters.Add(New MySqlParameter("razao_emp", txtrazaosocial.Text))
        insertSQL.Parameters.Add(New MySqlParameter("Nome_fantasia", txtnomefant.Text))
        insertSQL.Parameters.Add(New MySqlParameter("end_emp", txtendereco.Text))
        insertSQL.Parameters.Add(New MySqlParameter("numero_emp", txtnumero.Text))
        insertSQL.Parameters.Add(New MySqlParameter("bairro_emp", txtbairro.Text))
        insertSQL.Parameters.Add(New MySqlParameter("cep_emp", txtcep.Text))
        insertSQL.Parameters.Add(New MySqlParameter("cod_munic", txtcodMunicipio.Text))
        insertSQL.Parameters.Add(New MySqlParameter("cnpj_emp", txtcnpj.Text))
        insertSQL.Parameters.Add(New MySqlParameter("ie_emp", txtie.Text))
        insertSQL.Parameters.Add(New MySqlParameter("im_emp", txtim.Text))
        insertSQL.Parameters.Add(New MySqlParameter("fone_emp", txtfone.Text))
        insertSQL.Parameters.Add(New MySqlParameter("cnae_emp", txtcnae.Text))
        insertSQL.Parameters.Add(New MySqlParameter("email_emp", txtemail.Text))
        insertSQL.Parameters.Add(New MySqlParameter("reg_trib", reg_tributario))
        insertSQL.Parameters.Add(New MySqlParameter("num_pta", txtpta.Text))
        insertSQL.Parameters.Add(New MySqlParameter("aliq_simples", txtaliquotasimples.Text))
        insertSQL.Parameters.Add(New MySqlParameter("csc", txtcsc.Text))
        insertSQL.Parameters.Add(New MySqlParameter("idtoken", txtidtoken.Text))
        insertSQL.Parameters.Add(New MySqlParameter("Insc_st", txtinsc_st.Text))
        insertSQL.Parameters.Add(New MySqlParameter("calcular_ipi", ckcalculaipi.Checked))
        insertSQL.Parameters.Add(New MySqlParameter("reg_esp", ckregespecial.Checked))
        insertSQL.Parameters.Add(New MySqlParameter("emp_ativa", chkemp_inativa.Checked))
        insertSQL.Parameters.Add(New MySqlParameter("obs", txtobsnfe.Text))
        insertSQL.Parameters.Add(New MySqlParameter("ambiente_nfe", cboambnfe.Text.Substring(0, 1)))
        insertSQL.Parameters.Add(New MySqlParameter("ambiente_nfce", cboambientenfce.Text.Substring(0, 1)))
        insertSQL.Parameters.Add(New MySqlParameter("PDV", chkpdv.Checked))

        If txtcaminho.Text <> "" Then
                insertSQL.Parameters.Add(New MySqlParameter("cert", File.ReadAllBytes(txtcaminho.Text)))
                insertSQL.Parameters.Add(New MySqlParameter("senha_cert", Crypto.Crip_licenca(txtsenha.Text)))
                insertSQL.Parameters.Add(New MySqlParameter("datavenc_cert", Convert.ToDateTime(certificado.NotAfter).ToString("dd/MM/yyyy")))
            End If

            insertSQL.ExecuteNonQuery()
            oConn.Close()



        conectar_mysqlDFe()
        Dim SQLcommand6 As MySqlCommand
        SQLcommand6 = oConn.CreateCommand
        SQLcommand6.CommandText = "Select * from empresa where cnpj_emp = '" & txtcnpj.Text & "'"
        '   dr = SQLcommand.ExecuteReader()
        Dim cert As String, pess As String
        Using reader As MySqlDataReader = SQLcommand6.ExecuteReader

            While reader.Read
                cert = Convert.ToBase64String(reader("cert"))
                pess = reader("senha_cert")
            End While

        End Using

        carga_emp(txtcodigo.Text, txtrazaosocial.Text, txtnomefant.Text, txtcnpj.Text, reg_tributario, txtendereco.Text, txtnumero.Text, txtbairro.Text,
                  txtcep.Text, txtuf.Text, txtcidade.Text, txtcodMunicipio.Text, txtcsc.Text, txtidtoken.Text, cboambientenfce.Text.Substring(0, 1),
                  txtaliquotasimples.Text, txtie.Text, txtim.Text, txtcnae.Text, txtfone.Text, txtemail.Text, cert, pess, chkpdv.Checked)
        ''''''''''''''''Sslvar numeração da nfe'''''''''''''''''''


        ret = verificar_regexiste("select * from Numeracao_nfe where cnpj_emi = '" & txtcnpj.Text & "'")


        If ret = 0 Then
            sql = "INSERT INTO Numeracao_nfe (Numero_nf, serie_nf, modelo_nf, cnpj_emi, Numero_nfh) VALUES (@Numero_nf, @serie_nf, @modelo_nf, @cnpj_emi, @Numero_nfh)"
        Else
            sql = "UPDATE Numeracao_nfe SET Numero_nf = @Numero_nf, serie_nf = @serie_nf, modelo_nf = @modelo_nf, cnpj_emi = @cnpj_emi, Numero_nfh = @Numero_nfh where cnpj_emi = '" & txtcnpj.Text & "'"
        End If


        If cboambnfe.Text.Substring(0, 1) = "2" Then
            txtnumeronfe.Text = ret_valor_campo("select * from Numeracao_nfe where cnpj_emi = '" & txtcnpj.Text & "'", "Numero_nfh")
        Else
            txtnumeronfe.Text = ret_valor_campo("select * from Numeracao_nfe where cnpj_emi = '" & txtcnpj.Text & "'", "Numero_nf")
        End If



        Dim nr As Integer, nrh As Integer
        If txtnumeronfe.Text = "0" Then
            If cboambnfe.Text.Substring(0, 1) = "2" Then
                nrh = 0
            Else
                nr = 0
            End If
        Else

            If cboambnfe.Text.Substring(0, 1) = "2" Then
                nrh = txtnumeronfe.Text
            Else
                nr = txtnumeronfe.Text
            End If

        End If

        If ret_valor_campo("select * from Numeracao_nfe where cnpj_emi = '" & txtcnpj.Text & "'", "serie_nf") <> txtserie.Text Then
            nr = 0
        End If

        conectar_mysqlDFe()
        Dim insertSQL2 As MySqlCommand = New MySqlCommand(sql, oConn)
        insertSQL2.Parameters.Add(New MySqlParameter("Numero_nf", nr))
        insertSQL2.Parameters.Add(New MySqlParameter("serie_nf", txtserie.Text))
        insertSQL2.Parameters.Add(New MySqlParameter("modelo_nf", txtmodnfe.Text))
        insertSQL2.Parameters.Add(New MySqlParameter("cnpj_emi", txtcnpj.Text))
        insertSQL2.Parameters.Add(New MySqlParameter("Numero_nfh", txtnumeronfe.Text))



        insertSQL2.ExecuteNonQuery()

        oConn.Close()


        If txtcodigo.Text = "Novo" Then
            MsgBox("Cadastro Salvo com sucesso !", MsgBoxStyle.Information, "Aviso !")
        Else
            MsgBox("Cadastro Alterado com sucesso !", MsgBoxStyle.Information, "Aviso !")
        End If

        If cboambnfe.Text.Substring(0, 1) = "2" Then
            If verificar_regexiste("Select * from cliente where cnpjcpf_cli = '99999999000191'") = 0 Then
                executa_query("INSERT INTO cliente (nome_cli, end_cli, numero_cli, bairro_cli, cep_cli, cod_munic, cnpjcpf_cli, ierg_cli, sexo_cli) VALUES ('NFe emitida em ambiente Homologacao', '0', '0', '0', '0', '0', '99999999000191', '0', '0')")
            End If

        End If

        limpaCampos()
        DesabilitaCampos()
        listarEmpresa()
        btnexcluir.Enabled = True
    End Sub


    Public Sub carga_emp(ByVal cod As String, ByVal nome_emp As String, ByVal nome_fan As String, ByVal cnpj_emp As String, ByVal regime As String,
        ByVal endi As String, ByVal numero As String, ByVal bairro As String, ByVal cep As String, ByVal uf As String, ByVal cidade As String, cod_munic As String,
                      ByVal csc As String, ByVal token As String, ByVal ambiente As String, aliq_simples As String, ByVal ie As String, ByVal im As String,
                      ByVal cnae As String, ByVal fone As String, ByVal email As String, ByVal cert As String, ByVal pess As String, ByVal pdv As Boolean)
        If cod = "" Then
            Exit Sub
        End If
        Dim parametro As New Utilitarios
        Dim AtivoPdv As Integer

        If pdv Then
            AtivoPdv = 1
        Else
            AtivoPdv = 0
        End If

        Directory.CreateDirectory(parametro.Caminho_arq_export())

        Dim arquivo As String = parametro.Caminho_arq_export() & "\carga.cac"
        Dim sep As String = "|"



        Dim fluxoTexto As IO.StreamReader
        Dim myList As New ArrayList


        If IO.File.Exists(arquivo) Then
            fluxoTexto = New IO.StreamReader(arquivo)
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

            writer.WriteLine("01" & sep & cod & sep & nome_emp & sep & nome_fan & sep & cnpj_emp & sep & regime & sep & endi & sep & numero & sep & bairro & sep & cep & sep & uf & sep & cidade _
                             & sep & cod_munic & sep & csc & sep & token & sep & ambiente & sep & aliq_simples & sep & ie & sep & im & sep & cnae & sep & fone _
                             & sep & email & sep & cert & sep & pess & sep & AtivoPdv)



        End Using
    End Sub

    Private Sub listarEmpresa()
        Dim sql As String

        Try

            If pesquisa = False Then

                sql = "SELECT * FROM empresa INNER JOIN municipio ON municipio.codigo_municipio = empresa.cod_munic"
            Else

                sql = "SELECT * FROM empresa INNER JOIN municipio ON municipio.codigo_municipio = empresa.cod_munic where empresa.razao_social like '%" & txtnome_pesq.Text & "%'"
            End If

            conectar_mysqlDFe()
            Dim CommandSQL As MySqlCommand = New MySqlCommand(sql, oConn)
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(CommandSQL)
            Dim dt As DataTable = New DataTable
            da.Fill(dt)
            oConn.Close()

            dgvempresa.Rows.Clear()
            For Each Row As DataRow In dt.Rows
                dgvempresa.Rows.Add(Row.Item("cod_emp"), Row.Item("razao_emp"), Row.Item("cnpj_emp"))
            Next Row

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso !")
        Finally
            oConn.Close()
        End Try
    End Sub

    Private Sub carregacampos()

        verifica_NumNFCe()

        Dim sql As String = "SELECT * FROM empresa INNER JOIN municipio ON municipio.codigo_municipio = empresa.cod_munic INNER JOIN Numeracao_nfe ON Numeracao_nfe.cnpj_emi = empresa.cnpj_emp WHERE empresa.cod_emp = " & dgvempresa.CurrentRow.Cells(0).Value & ""

        Dim ret As Integer = 0
        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())

            txtcodigo.Text = dr("cod_emp")
            txtrazaosocial.Text = dr("razao_emp")
            txtendereco.Text = dr("end_emp").ToString()
            txtnumero.Text = dr("numero_emp").ToString()
            txtbairro.Text = dr("bairro_emp").ToString()
            txtcodMunicipio.Text = dr("cod_munic")
            txtcidade.Text = dr("NomeMunic")
            txtcodUF.Text = dr("cod_UF")
            txtuf.Text = dr("UF")
            txtcnpj.Text = dr("cnpj_emp")
            txtie.Text = dr("ie_emp").ToString()
            txtim.Text = dr("im_emp").ToString()

            If dr("emp_ativa").ToString.Length = 0 Then
                chkemp_inativa.Checked = False
            Else
                chkemp_inativa.Checked = dr("emp_ativa")
            End If

            txtcsc.Text = dr("csc").ToString()
            txtidtoken.Text = dr("idtoken").ToString()
            txtobsnfe.Text = dr("obs").ToString()

            If dr("fone_emp").ToString.Length = 10 Then
                txtfone.Mask = "(00) 0000-0000"
            End If
            If dr("fone_emp").ToString.Length = 11 Then
                txtfone.Mask = "(00) 0-0000-0000"
            End If

            txtfone.Text = dr("fone_emp").ToString()

            txtcnae.Text = dr("cnae_emp").ToString()
            txtcep.Text = dr("cep_emp").ToString()
            txtemail.Text = dr("email_emp").ToString()
            txtinsc_st.Text = dr("Insc_st").ToString

            If dr("reg_trib").ToString = "2" Then
                optlucropresumido.Checked = True
            End If
            If dr("reg_trib").ToString = "1" Then
                optsimplesnacional.Checked = True
            End If

            If dr("reg_trib").ToString = "3" Then
                optlucroreal.Checked = True
            End If

            If dr("calcular_ipi").ToString.Length = 0 Then
                ckcalculaipi.Checked = False
            Else
                ckcalculaipi.Checked = dr("calcular_ipi")
            End If
            If dr("reg_esp").ToString.Length = 0 Then
                ckregespecial.Checked = False
            Else
                ckregespecial.Checked = dr("reg_esp")
            End If


            txtpta.Text = dr("num_pta").ToString()
            txtaliquotasimples.Text = dr("aliq_simples").ToString()
            txtserie.Text = dr("serie_nf")
            txtmodnfe.Text = dr("modelo_nf")

            If dr("Numero_nf") = 0 Then
                txtnumeronfe.Text = "000000001"
            Else
                txtnumeronfe.Text = dr("Numero_nf").ToString.PadLeft(9, "0")
            End If

            txtnomefant.Text = dr("Nome_fantasia").ToString

            cboambnfe.SelectedIndex = cboambnfe.FindString(dr("ambiente_nfe").ToString)
            cboambientenfce.SelectedIndex = cboambientenfce.FindString(dr("ambiente_nfce").ToString)

            If dr("PDV").ToString = "" Then
                chkpdv.Checked = False
            Else
                chkpdv.Checked = dr("PDV")
            End If

            ret += 1
        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()

        HabilitaCampos()

        btnexcluir.Enabled = True
        TabControl1.SelectTab(TabPage1)
    End Sub

    Private Sub DeletaEmpresa()

        Dim sql As String = "DELETE FROM empresa WHERE cod_empresa = '" & dgvempresa.CurrentRow.Cells(0).Value & "'"

        conectar_mysqlDFe()

        Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)

        insertSQL.ExecuteNonQuery()

        oConn.Close()

        MsgBox("Empresa excluida com sucesso!!!", MsgBoxStyle.Information)


    End Sub

    Private Sub regTributario()
        If optsimplesnacional.Checked = True Then
            txtaliquotasimples.Enabled = True
        End If
    End Sub

    Private Sub HabilitaCampos()
        TabControl1.TabPages(0).Enabled = True
        TabControl1.TabPages(1).Enabled = True
        btnSalvar.Enabled = True
    End Sub

    Private Sub DesabilitaCampos()
        TabControl1.TabPages(0).Enabled = False
        TabControl1.TabPages(1).Enabled = False
        btnexcluir.Enabled = False
        btnSalvar.Enabled = False
    End Sub

    Private Sub novo()
        txtcodigo.Text = "Novo"
        HabilitaCampos()
        txtnumeronfe.Text = "000000001"
        txtmodnfe.Text = "55"
        txtserie.BackColor = Color.White
        TabControl1.SelectTab(TabPage1)
        cboambnfe.SelectedIndex = 0
    End Sub

    Private Sub limpaCampos()
        txtcsc.Clear()
        txtidtoken.Clear()
        lblret_webservice.Text = ""
        chkemp_inativa.Checked = False
        txtobsnfe.Clear()
        txtnomefant.Clear()
        txtcaminho.Clear()
        txtsenha.Clear()
        txtbairro.Text = ""
        txtcep.Text = ""
        txtinsc_st.Clear()
        txtcnae.Text = ""
        txtcnpj.Text = ""
        txtemail.Text = ""
        txtendereco.Text = ""
        txtfone.Text = ""
        txtie.Text = ""
        txtim.Text = ""
        txtnumero.Text = ""
        txtrazaosocial.Text = ""
        txtcidade.Text = ""
        txtuf.Text = ""
        txtcodMunicipio.Text = ""
        txtcodUF.Text = "31"
        txtcodigo.Text = ""
        optlucroreal.Checked = False
        optlucropresumido.Checked = False
        optsimplesnacional.Checked = False
        txtpta.Text = ""
        txtserie.Text = ""
    End Sub

    Private Sub FrmEmpresa_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Me.Dispose()
    End Sub

    Private Sub FrmEmpresa_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If

        Select Case e.KeyCode

            Case Keys.F3
                novo()
            Case Keys.F10
                GravaEmpresa()
            Case Keys.F4
                If MessageBox.Show("Deseja Realmente excluir a empresa: " & txtrazaosocial.Text, "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    DeletaEmpresa()
                    listarEmpresa()
                    limpaCampos()
                    DesabilitaCampos()
                End If
            Case Keys.Escape
                Me.Dispose()
        End Select
    End Sub

    Private Sub FrmEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DesabilitaCampos()
        listarEmpresa()
    End Sub

    Private Sub verifica_NumNFCe()
        Dim ret As Integer = verificar_regexiste("select * from Numeracao_nfe where cnpj_emi = '" & dgvempresa.CurrentRow.Cells(2).Value & "'")

        If ret = 0 Then
            sql = "INSERT INTO Numeracao_nfe (Numero_nf, serie_nf, modelo_nf, cnpj_emi, Numero_nfh) VALUES (0, 1, 65, '" & dgvempresa.CurrentRow.Cells(2).Value & "', 0)"

            conectar_mysqlDFe()
            Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)
            insertSQL.ExecuteNonQuery()
            oConn.Close()
        End If
    End Sub
    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles ckregespecial.CheckedChanged
        If ckregespecial.Checked Then
            reg_especial = "S"
            txtpta.Enabled = True

            If txtpta.Text = "" Then
                MsgBox("Informe o N° Do PTA", MsgBoxStyle.Information)
                txtpta.Focus()
            End If
        Else
            txtpta.Enabled = False

            reg_especial = "N"
        End If
    End Sub


    Private Sub rblucroreal_CheckedChanged(sender As Object, e As EventArgs) Handles optlucroreal.CheckedChanged
        If optlucroreal.Checked = True Then
            reg_tributario = "3"
        Else
            If optlucropresumido.Checked = True Then
                reg_tributario = "2"
            End If
            If optsimplesnacional.Checked = True Then
                reg_tributario = "1"
            End If

        End If

    End Sub

    Private Sub txtcnpj_GotFocus(sender As Object, e As EventArgs) Handles txtcnpj.GotFocus
        If txtcidade.Text = "" Then
            btnBancodeDados.Focus()
        End If
    End Sub

    Private Sub txtcnpj_LostFocus(sender As Object, e As EventArgs) Handles txtcnpj.LostFocus
        If txtcnpj.Text = "" Then
            Exit Sub
        End If

        If txtcnpj.Text.Length < 14 Then
            MsgBox("CNPJ inválido!", MsgBoxStyle.Exclamation, "Aviso !")
            txtcnpj.Focus()
            Exit Sub
        End If

        If txtcnpj.Text.Length >= 11 Then
            If validacnpj(txtcnpj.Text) = False Then
                MsgBox("CNPJ inválido!", MsgBoxStyle.Exclamation, "Aviso !")
                txtcnpj.Focus()
                Exit Sub
            End If
        Else
            MsgBox("CNPJ inválido!", MsgBoxStyle.Exclamation, "Aviso !")
            txtcnpj.Focus()
            Exit Sub
        End If

        If txtcodigo.Text = "Novo" Then

            sql = "Select * from empresa where cnpj_emp = '" & txtcnpj.Text & "'"
            Dim reg As Integer = verificar_regexiste(sql)

            If reg = 1 Then
                MsgBox("O CNPJ já está cadastrado  na empresa: " & rs.Fields("razao_social").Value & vbCrLf & "Informe um Novo CNPJ para continuar ?", MsgBoxStyle.Exclamation, "Aviso !")
                txtcnpj.Focus()
            End If


        End If
    End Sub

    Private Sub dgvempresa_Click(sender As Object, e As EventArgs) Handles dgvempresa.Click
        carregacampos()
    End Sub

    Private Sub dgvempresa_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvempresa.MouseClick
        btnexcluir.Enabled = True
    End Sub

    Private Sub dgvempresa_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgvempresa.MouseDoubleClick
        carregacampos()
        HabilitaCampos()
    End Sub

    Private Sub rbsimplesnacional_Click(sender As Object, e As EventArgs) Handles optsimplesnacional.Click
        If optsimplesnacional.Checked = True Then
            txtaliquotasimples.Enabled = True
            txtaliquotasimples.ReadOnly = False
            txtaliquotasimples.Focus()
        Else
            txtaliquotasimples.Text = valor_campo_vazio()
            txtaliquotasimples.Enabled = False
        End If
    End Sub

    Private Sub txtaliquotasimples_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtaliquotasimples.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtaliquotasimples_LostFocus(sender As Object, e As EventArgs) Handles txtaliquotasimples.LostFocus
        If txtaliquotasimples.Text = "" Then
            txtaliquotasimples.Text = valor_campo_vazio()
        Else
            txtaliquotasimples.Text = formata_valor_campo(txtaliquotasimples.Text)
        End If
    End Sub

    Private Sub txtreducaost_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtpta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpta.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtserie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtserie.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnovo_Click(sender As Object, e As EventArgs) Handles btnovo.Click
        limpaCampos()
        novo()
        txtrazaosocial.Focus()
    End Sub

    Private Sub btnexcluir_Click(sender As Object, e As EventArgs) Handles btnexcluir.Click
        If MessageBox.Show("Deseja Realmente excluir a empresa: " & txtrazaosocial.Text, "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            DeletaEmpresa()
            listarEmpresa()
            limpaCampos()
            DesabilitaCampos()
        End If
    End Sub

    Private Sub btngravar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        If txtcnpj.Text = "" Then
            MsgBox("Informe o Número do CNPJ !", MsgBoxStyle.Exclamation, "Aviso !")
            txtcnpj.Focus()
            Exit Sub
        End If

        If txtserie.Text = "" Then
            MsgBox("Informe a Série que será utilizada na emissão de NF-e!", MsgBoxStyle.Exclamation, "Aviso !")
            TabControl1.SelectTab(TabPage2)
            txtserie.Focus()
            Exit Sub
        End If

        If txtcsc.Text = "" Then
            MsgBox("Não foi Informado o CSC para emissão da NFC-e !", MsgBoxStyle.Exclamation, "Aviso !")

            If MessageBox.Show("Deseja continuar assim mesmo ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                TabControl1.SelectTab(TabPage2)
                txtcsc.Focus()
                Exit Sub
            End If

        End If

        If txtidtoken.Text = "" Then
            MsgBox("Não foi Informado o IDtoken para emissão da NFC-e !", MsgBoxStyle.Exclamation, "Aviso !")

            If MessageBox.Show("Deseja continuar assim mesmo ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                TabControl1.SelectTab(TabPage2)
                txtidtoken.Focus()
                Exit Sub
            End If

        End If

        If optlucroreal.Checked = False And optlucropresumido.Checked = False And optsimplesnacional.Checked = False Then
            MsgBox("Informe o Regime tributario da Empresa !", MsgBoxStyle.Exclamation, "Aviso !")
            TabControl1.SelectTab(TabPage2)
            Exit Sub
        End If

        If txtcaminho.Text = "Novo" Then
            If txtcaminho.Text = "" Then
                MsgBox("Carregue o certificado Digital !", MsgBoxStyle.Exclamation, "Aviso !")
                TabControl1.SelectTab(TabPage1)
                Button1.Focus()
                Exit Sub
            End If

            If txtsenha.Text = "" Then
                MsgBox("Informe a senha do certificado Digital !", MsgBoxStyle.Exclamation, "Aviso !")
                TabControl1.SelectTab(TabPage1)
                txtsenha.Focus()
                Exit Sub
            End If
        End If


        GravaEmpresa()

    End Sub

    Private Function verifica_certificado() As Boolean
        Dim nullcert As Boolean = False
        conectar_mysqlDFe()
        Dim SQLcommand6 As MySqlCommand
        SQLcommand6 = oConn.CreateCommand
        SQLcommand6.CommandText = "Select * from empresa where cnpj_emp = '" & txtcnpj.Text & "'"
        '   dr = SQLcommand.ExecuteReader()
        Dim cert As String, pess As String
        Using reader As MySqlDataReader = SQLcommand6.ExecuteReader

            While reader.Read

                If reader("cert").ToString() <> "" Then
                    nullcert = True
                End If

            End While

        End Using
        oConn.Close()

        Return nullcert
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub txtnome_pesq_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnome_pesq.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            pesquisa = True
            listarEmpresa()
        End If
    End Sub

    Private Sub txtnome_pesq_TextChanged(sender As Object, e As EventArgs) Handles txtnome_pesq.TextChanged
        If txtnome_pesq.Text.Length = 0 Then
            pesquisa = False
            listarEmpresa()
        End If
    End Sub


    Private Sub txtie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtie.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtim_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtim.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtinsc_st_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtinsc_st.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

#Region "''''Rotina para capturar os dados do certificado digital"

    Private Sub busca_certificado()

        Try

            certificado = SelecionarCertificado("")
            serial_cert = nfecer

            nfecer = ""

            If serial_cert <> "" Then
                MsgBox("Certificado Carregado, Clique em salvar para confirma a operação !", MsgBoxStyle.Information, "Aviso !")
            End If

        Catch ex As Exception

        End Try


    End Sub

#End Region

    Private Sub txtemail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtemail.KeyPress
        If (e.KeyChar = Chr(13)) Then
            TabControl1.SelectTab(TabPage2)
            txtserie.Focus()
        End If
    End Sub

    Private Sub txtcnae_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcnae.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnBancodeDados_Click(sender As Object, e As EventArgs) Handles btnBancodeDados.Click

        FrmCidades.ShowDialog()

        If txtcidade.Text <> "" Then
            txtcnpj.Focus()
        End If
    End Sub

    Private Sub txtcep_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcep.KeyPress
        If (e.KeyChar = Chr(13)) Then

            If Len(txtcep.Text) < 8 Then
                MsgBox("Cep Invalido !", MsgBoxStyle.Critical, "Aviso !")
                txtcep.Clear()
                txtcep.Focus()
                Exit Sub
            End If

            If IsConectedToHost(New Uri("http://www.google.com")) = False Then
                MsgBox("Esta Consulta é feita Online, e você está sem conexão com Internet ?" & vbCrLf & "Operação cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
                Exit Sub
            End If

            '  If chkcorreios.Checked = True Then
            BuscaCep(txtcep.Text)
            txtcidade.Text = RemoverAcentos(ds.Tables(0).Rows(0).Item("cidade").ToString().Trim())
            txtuf.Text = ds.Tables(0).Rows(0).Item("uf").ToString().Trim()
            txtcep.Mask = "00.000-000"

            txtcodMunicipio.Text = ret_valor_campo("select * from municipio where NomeMunic = '" & txtcidade.Text & "'", "codigo_municipio")

            If txtcidade.Text <> "" Then

                If txtcodMunicipio.Text = "" Then
                    txtcodMunicipio.Text = pesquisar_online_codmunic(txtcidade.Text)
                End If

            End If

            txtcodMunicipio.Focus()
            '  Exit Sub
            'End If


        End If
    End Sub

    Private Sub txtcep_LostFocus(sender As Object, e As EventArgs) Handles txtcep.LostFocus
        If txtcep.Text.Length < 8 Then
            MsgBox("CEP invalido !", MsgBoxStyle.Exclamation, "Aviso !")
            txtcep.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtmodnfe_GotFocus(sender As Object, e As EventArgs) Handles txtmodnfe.GotFocus
        If txtserie.Text = "" Then
            txtserie.Focus()
        End If
    End Sub

    Private Sub txtcidade_TextChanged(sender As Object, e As EventArgs) Handles txtcidade.TextChanged
        txtcnpj.Focus()
    End Sub

    Public Sub busca_munic(ByVal valor As String)

        conectar_baseNFe()

        sql = "select * from municipio where codigo_municipio = '" & valor & "'"
        rs.Open(sql, conexao.cn_nfe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockPessimistic)

        txtcidade.Text = rs.Fields("NomeMunic").Value
        txtuf.Text = rs.Fields("UF").Value
        txtcodUF.Text = rs.Fields("cod_UF").Value

        conexao.cn_nfe.Close()

    End Sub

    Private Sub txtnumeronfe_GotFocus(sender As Object, e As EventArgs) Handles txtnumeronfe.GotFocus
        txtnumeronfe.BackColor = Color.White

        txtnumero.Text = txtnumero.Text.TrimStart("0", "")
    End Sub

    Private Sub txtfone_GotFocus(sender As Object, e As EventArgs) Handles txtfone.GotFocus

        txtfone.Mask = "(00) 000000000"

    End Sub

    Private Sub txtfone_LostFocus(sender As Object, e As EventArgs) Handles txtfone.LostFocus
        If txtfone.Text.Length = 10 Then
            txtfone.Mask = "(00) 0000-0000"
        End If
        If txtfone.Text.Length = 11 Then
            txtfone.Mask = "(00) 0-0000-0000"
        End If
    End Sub

    Private Sub txtrazaosocial_LostFocus(sender As Object, e As EventArgs) Handles txtrazaosocial.LostFocus
        If txtrazaosocial.Text <> "" Then
            txtrazaosocial.Text = TirarAcento(txtrazaosocial.Text)
        End If
    End Sub


    Private Sub txtnomefant_LostFocus(sender As Object, e As EventArgs) Handles txtnomefant.LostFocus
        If txtnomefant.Text <> "" Then
            txtnomefant.Text = TirarAcento(txtnomefant.Text)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dialogo As New OpenFileDialog
        dialogo.Filter = "Arquivos (.pfx)|*.pfx"

        If dialogo.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtcaminho.Text = dialogo.FileName
        End If
    End Sub

    Private Sub optsimplesnacional_CheckedChanged(sender As Object, e As EventArgs) Handles optsimplesnacional.CheckedChanged
        If optlucroreal.Checked = True Then
            reg_tributario = "1"
        Else
            If optlucropresumido.Checked = True Then
                reg_tributario = "2"
            End If
            optsimplesnacional.Checked = True
            reg_tributario = "3"
        End If
    End Sub

    Private Sub optlucropresumido_CheckedChanged(sender As Object, e As EventArgs) Handles optlucropresumido.CheckedChanged
        If optlucroreal.Checked = True Then
            reg_tributario = "1"
        Else
            If optlucropresumido.Checked = True Then
                reg_tributario = "2"
            End If
            optsimplesnacional.Checked = True
            reg_tributario = "3"
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgvempresa_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvempresa.CellContentClick

    End Sub
End Class