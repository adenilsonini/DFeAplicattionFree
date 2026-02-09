Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Web.Script.Serialization

Public Class frmcliente
    Dim indfinal As Integer
    Dim pesq As Boolean
    Dim parametro As String
    Dim nome As String = "nome_cli"
    Dim agenda As Boolean
    Dim rscod As New ADODB.Recordset
    Dim rs As New ADODB.Recordset
    Private Sub novo()

        limpar()
        dgvfone.Rows.Clear()
        gcliente.Enabled = True
        gconvenio.Enabled = True
        pesq = False
        cboconvenio.Focus()
        chkliberar.Checked = True
        cboconvenio.SelectedIndex = 0
        cboind_dest.SelectedIndex = 0

        txtcod.Text = ProximoCodigo("cliente", "codigo_cli")

        Bnteditar.Visible = False
        bntcancelar.Visible = True
        btnexcluir.Enabled = False
        btnconsulta.Enabled = False

        txtcod.Focus()
    End Sub

    Private Sub cboconvenio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboconvenio.SelectedIndexChanged
        txtcodconv.Text = "1"
        gcliente.Enabled = True
        txtnome.Focus()
        gconvenio.Enabled = False
        mskdatacad.Text = Now.Date

    End Sub

    Private Sub mskcep_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mskcep.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If

        If (e.KeyChar = Chr(13)) Then

            If Len(mskcep.Text) < 8 Then
                MsgBox("Cep Invalido !", MsgBoxStyle.Critical, "Aviso !")
                mskcep.Clear()
                mskcep.Focus()
                Exit Sub
            End If

            If IsConectedToHost(New Uri("http://www.google.com")) = False Then
                MsgBox("Esta Consulta é feita Online, e você está sem conexão com Internet ?" & vbCrLf & "Operação cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
                Exit Sub
            End If

            '  If chkcorreios.Checked = True Then
            BuscaCep(mskcep.Text)
            txtcidade.Text = RemoverAcentos(ds.Tables(0).Rows(0).Item("cidade").ToString().Trim())
            txtuf.Text = ds.Tables(0).Rows(0).Item("uf").ToString().Trim()
            mskcep.Mask = "00.000-000"
            mskcpf.Focus()

            txtcod_munic.Text = ret_valor_campo("select * from municipio where NomeMunic = '" & txtcidade.Text & "'", "codigo_municipio")

            If txtcidade.Text <> "" Then

                If txtcod_munic.Text = "" Then
                    txtcod_munic.Text = pesquisar_online_codmunic(txtcidade.Text)
                End If

            End If
            '  Exit Sub
            'End If


        End If
    End Sub


    Private Sub optjuridica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optjuridica.CheckedChanged
        Label13.Text = "CNPJ"
        Label18.Visible = True
        Label12.Visible = False
        Label13.Location = New System.Drawing.Point(37, 204)

        cbosexo.Enabled = False
        cbosexo.Text = "OUTROS"
        mskcpf.Mask = "00,000,000/0000-00"
    End Sub

    Private Sub optjurica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optfisica.CheckedChanged
        Label13.Text = "CPF"
        Label18.Visible = False
        Label12.Visible = True
        cbosexo.Enabled = True
        Label13.Location = New System.Drawing.Point(44, 204)

        mskcpf.Mask = "000,000,000-00"
    End Sub

    Private Sub txtcredito_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcredito.GotFocus
        If txtcredito.Text = "0,00" Then
            txtcredito.Text = ""
        End If
    End Sub

    Private Sub txtcredito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcredito.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal2(txtcredito, e)
    End Sub

    Private Sub txtcredito_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcredito.LostFocus
        If txtcredito.Text = "" Then
            txtcredito.Text = "0,00"
        Else
            txtcredito.Text = Convert.ToDouble(txtcredito.Text).ToString("N2")
            txtvlrusado.Text = txtcredito.Text
        End If
    End Sub

    Private Sub txtdes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdes.GotFocus
        If txtdes.Text = "0,00" Then
            txtdes.Clear()
        End If
    End Sub

    Private Sub txtdes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdes.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal4(txtdes, e)
    End Sub

    Private Sub limpar()
        txtbairro.Clear()
        txtcod_munic.Clear()
        mskcep.Clear()
        txtcod.Clear()
        txtcodconv.Clear()
        mskcep.Clear()
        mskcpf.Clear()
        cbosexo.Text = ""
        txtemail.Clear()
        txtend.Clear()
        txtmae.Clear()
        txtnome.Clear()
        txtnumero.Clear()
        txtobs.Clear()
        txtpai.Clear()
        txtrg.Clear()
        txttrabalho.Clear()
        txtuf.Clear()
        txtcidade.Clear()
        cboconvenio.Text = ""
        txtjuro.Text = "0,00"
        txtcredito.Text = "0,00"
        mskdatacad.Clear()
        txtvlrusado.Text = "0,00"
        txtdes.Text = "0,00"
        txtprozopag.Text = "30"
        cbosexo.Text = ""

    End Sub

    Private Sub lblinfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblinfo.Click
        '   If g.Visible = False Then
        'g.Width = 443
        '  g.Height = 170
        ' g.Location = New System.Drawing.Point(89, 90)
        ' g.Visible = True

        ' Else
        ' g.Visible = False
        ' End If
    End Sub

    Private Sub bsair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub

    Private Sub txtcodp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        parametro = "codigo"
    End Sub

    Private Sub dgvpesquisa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Chr(13)) Then

        End If
    End Sub

    Private Sub txtnomep_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Chr(13)) Then

        End If
    End Sub

    Private Sub txtnomep_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        parametro = "nome"
    End Sub

    Private Sub mskcnpjp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Chr(13)) Then

        End If
    End Sub

    Private Sub mskcnpjp_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs)
        parametro = "cnpj"
    End Sub

    Private Sub frmcliente_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmcliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub txtdes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdes.LostFocus
        If txtdes.Text = "" Then
            txtdes.Text = "0,00"
        Else
            txtdes.Text = Convert.ToDouble(txtdes.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtrg_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrg.GotFocus

        If mskcpf.Text = "" Then
            mskcpf.Focus()
        End If

    End Sub

    Private Sub txtend_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtend.GotFocus
        If txtnome.Text = "" Then
            txtnome.Focus()
        End If
    End Sub

    Private Sub bexcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtcod.Text <> "" Then
            If MessageBox.Show("Deseja Realmente Excluir o Cliente: " & txtnome.Text, "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                '  conectar()

                '  rs.Open("select * from DOCUMENTO where chave_cli like '" & txtcod.Text + txtcodconv.Text & "'", conexao.cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                ' If rs.EOF = False Then
                '  MsgBox("Cliente não Pode ser excluido !" + vbCrLf + "Existem Documentos no Nome do Cliente", MsgBoxStyle.Information, "Aviso !")
                '   rs.Close()
                '   conexao.cnsql.Close()
                '   Exit Sub
                '  Else
                '     rs.Close()
                ' End If

                ' rs.Open("select * from cheque where chave_cli like '" & txtcod.Text + txtcodconv.Text & "'", conexao.cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                ' If rs.EOF = False Then
                '  MsgBox("Cliente não Pode ser excluido !" + vbCrLf + "Existem Cheques no Nome do Cliente", MsgBoxStyle.Information, "Aviso !")
                '  rs.Close()
                '  conexao.cnsql.Close()
                '  Exit Sub
                ' Else
                '      rs.Close()
                '  End If

                '  rsdelete.Open("delete * from clientes where chave_cli like '" & txtcod.Text + txtcodconv.Text & "'", conexao.cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                ' conexao.cnsql.Close()
                '  MsgBox("Cliente excluido com Sucesso !", MsgBoxStyle.Information, "Aviso !")
                ' limpar()
                ' dgvfone.Rows.Clear()
                ' gcliente.Enabled = False
            End If
        End If
    End Sub

    Private Sub grid_cli_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvfone.RowsRemoved
        agenda = True
    End Sub

    Private Sub txtdiapag_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtprozopag.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub chkcobrajuro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkcobrajuro.CheckedChanged
        If chkcobrajuro.Checked = True Then
            txtjuro.Enabled = True
            txtjuro.Focus()
        Else
            txtjuro.Enabled = False
            txtjuro.Text = "0,00 %"
        End If
    End Sub

    Private Sub txtjuro_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtjuro.GotFocus
        If txtjuro.Text = "0,00 %" Then
            txtjuro.Text = ""
        Else
            txtjuro.Text = txtjuro.Text.Remove(txtjuro.Text.Length - 1, 1)
        End If
    End Sub

    Private Sub txtjuro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtjuro.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal2(txtcredito, e)
    End Sub

    Private Sub txtjuro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtjuro.LostFocus
        If txtjuro.Text = "" Then
            txtjuro.Text = "0,00"
        Else
            txtjuro.Text = Convert.ToDouble(txtjuro.Text).ToString("N2")
            txtjuro.Text = txtjuro.Text
        End If
    End Sub


    Private Sub btnovo_Click(sender As Object, e As EventArgs) Handles btnovo.Click
        novo()
    End Sub

    Private Function pesquisa_gridfone(ByVal id As String) As String

        Dim r As String = "R"

        For Each row As DataGridViewRow In Me.dgvfone.Rows

            If Not row.IsNewRow Then
                If row.Cells("fone_cligrid").Value = id Then
                    Return row.Index
                End If
            End If

        Next

        Return r

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If mskfone.Text.Length = 15 Then
            mskfone.Mask = "(00) 0000-0000"
        Else
            mskfone.Mask = "(00) 0-0000-0000"
        End If
        Dim ret As String = pesquisa_gridfone(mskfone.Text)

        If ret = "R" Then
            dgvfone.Rows.Add(mskfone.Text, txtcod.Text)
        Else
            dgvfone.Rows.Item(ret).Cells(0).Value = mskfone.Text
        End If

        mskfone.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If dgvfone.Rows.Count <> 0 Then
            dgvfone.Rows.Remove(dgvfone.CurrentRow)
        End If

    End Sub

    Private Sub btnsair_Click(sender As Object, e As EventArgs) Handles btnsair.Click
        Me.Close()
    End Sub

    Private Sub btnsalvar_Click(sender As Object, e As EventArgs) Handles btnsalvar.Click
        If txtcod.Text = "" Then
            Exit Sub
        End If
        If txtnome.Text = "" Then
            MsgBox("Informe o Nome do Cliente (obrigatorio)", MsgBoxStyle.Critical, "Aviso")
            txtnome.Focus()
            Exit Sub
        End If

        If txtend.Text = "" Then
            MsgBox("Informe o Endereço (obrigatorio)", MsgBoxStyle.Critical, "Aviso")
            txtend.Focus()
            Exit Sub
        End If

        If txtnumero.Text = "" Then
            MsgBox("Informe o Nùmero (obrigatorio)", MsgBoxStyle.Critical, "Aviso")
            txtnumero.Focus()
            Exit Sub
        End If

        If txtbairro.Text = "" Then
            MsgBox("Informe o Bairro (obrigatorio)", MsgBoxStyle.Critical, "Aviso")
            txtbairro.Focus()
            Exit Sub
        End If

        If mskcep.Text = "" Then
            MsgBox("Informe o Cep (obrigatorio)", MsgBoxStyle.Critical, "Aviso")
            mskcep.Focus()
            Exit Sub
        End If

        If cbosexo.Text = "" Then
            MsgBox("Informe o Sexo (obrigatorio)", MsgBoxStyle.Critical, "Aviso")
            cbosexo.Focus()
            Exit Sub
        End If
        If mskdatanasc.Text.Length < 11 Then
            mskdatanasc.Text = Now.Date
        End If
        If mskdatanasc.Text = "" Then
            MsgBox("Informe a Data de nascimento (obrigatorio)", MsgBoxStyle.Critical, "Aviso")
            mskdatanasc.Focus()
            Exit Sub
        End If

        If txtcredito.Text = "" Or txtcredito.Text = "0,00" Then
            MsgBox("Informe O Limite de Credito (obrigatorio)", MsgBoxStyle.Critical, "Aviso")
            txtcredito.Focus()
            Exit Sub
        End If

        If optfisica.Checked = True Then
            If mskcpf.Text = "   .   .   -" Then
                MsgBox("Informe O CPF do Cliente (obrigatorio)", MsgBoxStyle.Critical, "Aviso")
                mskcpf.Focus()
                Exit Sub
            End If

        Else

            If mskcpf.Text = "" Then
                MsgBox("Informe O CNPJ da Empresa (obrigatorio)", MsgBoxStyle.Critical, "Aviso")
                mskcpf.Focus()
                Exit Sub
            End If
        End If
        txtnome.Focus()

        salvar()
    End Sub

    Private Sub salvar()
        Dim codigo As Integer = 0


        If verificar_regexiste("Select * from municipio where codigo_municipio = '" & txtcod_munic.Text & "'") = "0" Then
            busca_muni()
        End If

        Dim ret As Integer = verificar_regexiste("Select * from cliente where codigo_cli = '" & txtcod.Text & "'")
        Dim sql As String

        If ret = 0 Then
            sql = "INSERT INTO cliente (codigo_conv, nome_cli, end_cli, numero_cli, bairro_cli, cep_cli, cod_munic, cnpjcpf_cli, ierg_cli, sexo_cli, data_nasc, vlr_limite,vlr_disp, vlr_desc, perc_juro, prazo_pag, cliente_lib, nome_mae, nome_pai, trabalho, email, obs, ind_dest, cliente_for, data_cad, tipo, indfinal, forma_pag, for_cli, transportadora, cliente_ativo, fone_cli) VALUES (@codigo_conv, @nome_cli, @end_cli, @numero_cli, @bairro_cli, @cep_cli, @cod_munic, @cnpjcpf_cli, @ierg_cli, @sexo_cli, @data_nasc, @vlr_limite, @vlr_disp, @vlr_desc, @perc_juro, @prazo_pag, @cliente_lib, @nome_mae, @nome_pai, @trabalho, @email, @obs, @ind_dest, @cliente_for, @data_cad, @tipo, @indfinal, @forma_pag, @for_cli, @transportadora, @cliente_ativo, @fone_cli)"
        Else
            sql = "UPDATE cliente set codigo_conv = @codigo_conv, nome_cli = @nome_cli, end_cli = @end_cli, numero_cli = @numero_cli, bairro_cli = @bairro_cli, cep_cli = @cep_cli, cod_munic = @cod_munic, cnpjcpf_cli = @cnpjcpf_cli, ierg_cli = @ierg_cli, sexo_cli = @sexo_cli, data_nasc = @data_nasc, vlr_limite = @vlr_limite, vlr_disp = @vlr_disp, vlr_desc = @vlr_desc, perc_juro = @perc_juro, prazo_pag = @prazo_pag, cliente_lib = @cliente_lib, nome_mae = @nome_mae, nome_pai = @nome_pai, trabalho = @trabalho, email = @email, obs = @obs, ind_dest = @ind_dest, cliente_for = @cliente_for, data_cad = @data_cad, tipo = @tipo, indfinal = @indfinal, forma_pag = @forma_pag, for_cli = @for_cli, transportadora = @transportadora, cliente_ativo = @cliente_ativo, fone_cli = @fone_cli where codigo_cli = " & txtcod.Text & ""
        End If

        conectar_mysqlDFe()
        Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)

        insertSQL.Parameters.Add(New MySqlParameter("codigo_conv", cboconvenio.Text.Substring(0, 1)))
        insertSQL.Parameters.Add(New MySqlParameter("nome_cli", txtnome.Text))
        insertSQL.Parameters.Add(New MySqlParameter("end_cli", txtend.Text))
        insertSQL.Parameters.Add(New MySqlParameter("numero_cli", txtnumero.Text))
        insertSQL.Parameters.Add(New MySqlParameter("bairro_cli", txtbairro.Text))
        insertSQL.Parameters.Add(New MySqlParameter("cep_cli", mskcep.Text))
        insertSQL.Parameters.Add(New MySqlParameter("cod_munic", txtcod_munic.Text))
        insertSQL.Parameters.Add(New MySqlParameter("cnpjcpf_cli", mskcpf.Text))
        insertSQL.Parameters.Add(New MySqlParameter("ierg_cli", txtrg.Text))


        insertSQL.Parameters.Add(New MySqlParameter("sexo_cli", cbosexo.Text))
        insertSQL.Parameters.Add(New MySqlParameter("data_nasc", Convert.ToDateTime(mskdatanasc.Text).ToString("yyyy-MM-dd")))
        insertSQL.Parameters.Add(New MySqlParameter("vlr_limite", format_val_mysql_ent(txtcredito.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("vlr_disp", format_val_mysql_ent(txtvlrusado.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("vlr_desc", format_val_mysql_ent(txtdes.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("perc_juro", format_val_mysql_ent(txtjuro.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("prazo_pag", txtprozopag.Text))
        insertSQL.Parameters.Add(New MySqlParameter("cliente_lib", chkliberar.Checked))

        insertSQL.Parameters.Add(New MySqlParameter("nome_mae", txtmae.Text))
        insertSQL.Parameters.Add(New MySqlParameter("nome_pai", txtpai.Text))
        insertSQL.Parameters.Add(New MySqlParameter("trabalho", txttrabalho.Text))
        insertSQL.Parameters.Add(New MySqlParameter("email", txtemail.Text))
        insertSQL.Parameters.Add(New MySqlParameter("obs", txtobs.Text))
        insertSQL.Parameters.Add(New MySqlParameter("ind_dest", cboind_dest.Text.Substring(0, 1)))
        insertSQL.Parameters.Add(New MySqlParameter("cliente_for", chkfor.Checked))
        insertSQL.Parameters.Add(New MySqlParameter("data_cad", Convert.ToDateTime(mskdatacad.Text).ToString("yyyy-MM-dd")))
        insertSQL.Parameters.Add(New MySqlParameter("tipo", "C"))
        insertSQL.Parameters.Add(New MySqlParameter("indfinal", indfinal))
        insertSQL.Parameters.Add(New MySqlParameter("forma_pag", "01"))
        insertSQL.Parameters.Add(New MySqlParameter("for_cli", chkfor.Checked))
        insertSQL.Parameters.Add(New MySqlParameter("transportadora", "0"))
        insertSQL.Parameters.Add(New MySqlParameter("cliente_ativo", "1"))
        For Each row As DataGridViewRow In Me.dgvfone.Rows
            insertSQL.Parameters.Add(New MySqlParameter("fone_cli", removeFormatacao(row.Cells(0).Value)))
        Next

        If dgvfone.Rows.Count = 0 Then
            insertSQL.Parameters.Add(New MySqlParameter("fone_cli", ""))
        End If

        insertSQL.ExecuteNonQuery()
        oConn.Close()


        ''''''''''Rotina para salvar produto na tabela 

        ret = executa_query("delete from fone_cli where codigo_cli = '" & txtcod.Text & "'")
        Dim fone As String
        For Each row As DataGridViewRow In Me.dgvfone.Rows
            conectar_mysqlDFe()

            sql = "INSERT INTO fone_cli (Codigo_cli, fone_cli) VALUES (@Codigo_cli, @fone_cli)"
            Dim insertSQL2 As MySqlCommand = New MySqlCommand(sql, oConn)
            insertSQL2.Parameters.Add(New MySqlParameter("Codigo_cli", row.Cells(1).Value))
            insertSQL2.Parameters.Add(New MySqlParameter("fone_cli", RemoveTelefone(row.Cells(0).Value)))
            fone = RemoveTelefone(row.Cells(0).Value)
            insertSQL2.ExecuteNonQuery()
            oConn.Close()
        Next


        carga_cli(txtcod.Text, txtnome.Text, mskcpf.Text, txtend.Text, txtnumero.Text, txtbairro.Text, mskcep.Text, txtcod_munic.Text, txtuf.Text, txtcidade.Text, txtrg.Text, txtprozopag.Text, txtcredito.Text, txtvlrusado.Text, mskdatacad.Text, chkliberar.Checked, txtdes.Text, txtemail.Text, fone)

        If sql.Substring(0, 6) = "INSERT" Then
            MsgBox("Produto Salvo com sucesso !", MsgBoxStyle.Information, "Aviso !")
            limpar()
            txtcod.Text = ""

        Else
            MsgBox("Produto alterado com sucesso !", MsgBoxStyle.Information, "Aviso !")
        End If

        limpar()
        dgvfone.Rows.Clear()
        gcliente.Enabled = False
        gconvenio.Enabled = False


        Bnteditar.Visible = True
        bntcancelar.Visible = False
        btnexcluir.Enabled = True
        btnconsulta.Enabled = True
        btnovo.Focus()
    End Sub

    Public Sub carga_cli(ByVal cod As String, ByVal nome_cli As String, ByVal cnpj_cli As String, ByVal end_cli As String, ByVal n_cli As String, ByVal bairro_cli As String, _
                        ByVal cep_cli As String, ByVal cod_munic As String, ByVal uf As String, ByVal cidade As String, ByVal ie_cli As String, _
                         ByVal prazo As String, ByVal credito As String, vlr_usado As String, ByVal datacad As Date, ByVal liberado As String, ByVal vlr_desc As String, ByVal email As String, ByVal fone As String)
        If cod = "" Then
            Exit Sub
        End If
        Dim parametro As New Utilitarios
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

            writer.WriteLine("12" & sep & cod & sep & nome_cli & sep & cnpj_cli & sep & end_cli & sep & n_cli & sep & bairro_cli & sep & cep_cli & sep & cod_munic & sep & uf & sep & cidade & sep & ie_cli & sep & prazo & sep & credito & sep & vlr_usado & sep & datacad & sep & liberado & sep & vlr_desc & sep & email & sep & fone)



        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        FrmCidades.ShowDialog()
    End Sub

    Private Sub txtjuro_TextChanged(sender As Object, e As EventArgs) Handles txtjuro.TextChanged

    End Sub

    Private Sub txtcod_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcod.KeyDown

    End Sub

    Private Sub txtcod_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcod.KeyPress

        If (e.KeyChar = Chr(13)) Then

            If txtcod.Text <> "" Then
                carregar_cliente(txtcod.Text, False)
            End If

        End If

    End Sub

    Private Sub txtcod_TextChanged(sender As Object, e As EventArgs) Handles txtcod.TextChanged

    End Sub

    Public Sub carregar_cliente(ByVal codigo As String, ByVal cpf As Boolean)

        limpar()
        dgvfone.Rows.Clear()
        gcliente.Enabled = True
        gconvenio.Enabled = True

        Dim sql As String
        ' 
        conectar_baseNFe()

        ''''''''Rotina para buscar pela codigo de barras'''''''''''
        sql = "SELECT * FROM cliente where codigo_cli =" & codigo & " and (tipo = 'C' or for_cli = '1')"

        If cpf = True Then

            sql = "SELECT * FROM cliente where cnpjcpf_cli ='" & mskcpf.Text & "' and (tipo = 'C' or for_cli = '1')"

        End If

        ''''''''''Rotina limpa campos'''''''
        limpar()

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read

                cboconvenio.SelectedIndex = cboconvenio.FindString(reader("codigo_conv"))
                cboind_dest.SelectedIndex = cboind_dest.FindString(reader("ind_dest"))
                txtcod.Text = reader("codigo_cli")
                txtnome.Text = reader("nome_cli")
                txtend.Text = reader("end_cli")
                txtnumero.Text = reader("numero_cli")
                txtbairro.Text = reader("bairro_cli")
                mskcep.Text = reader("cep_cli")
                If reader("cnpjcpf_cli").ToString.Length = 11 Then
                    optfisica.Checked = True
                    mskcpf.Text = reader("cnpjcpf_cli")
                Else
                    optjuridica.Checked = True
                    mskcpf.Text = reader("cnpjcpf_cli")
                End If
                txtrg.Text = reader("ierg_cli")
                cbosexo.Text = reader("sexo_cli")
                mskdatanasc.Text = reader("data_nasc")
                txtcod_munic.Text = reader("cod_munic")
                txtcredito.Text = format_val_mysql_ret(reader("vlr_limite"))
                txtvlrusado.Text = format_val_mysql_ret(reader("vlr_disp"))
                txtjuro.Text = format_val_mysql_ret(reader("perc_juro"))
                If format_val_mysql_ret(reader("perc_juro")) <> "0,00" Then
                    chkcobrajuro.Checked = True
                End If
                txtdes.Text = format_val_mysql_ret(reader("vlr_desc"))
                txtprozopag.Text = reader("prazo_pag")
                chkliberar.Checked = reader("cliente_lib")

                txtmae.Text = reader("nome_mae")
                txtpai.Text = reader("nome_pai")
                txttrabalho.Text = reader("trabalho")
                txtemail.Text = reader("email")
                txtobs.Text = reader("obs")

                chkfor.Checked = reader("cliente_for")
                mskdatacad.Text = Convert.ToDateTime(reader("data_cad")).ToString("dd/MM/yyyy")
            End While
        End Using


        If txtcod.Text = "" Then
            MsgBox("Produto não cadastrado !", MsgBoxStyle.Exclamation, "Aviso !")
            txtcod.Clear()
            txtcod.Focus()
            Exit Sub
        End If

        conectar_mysqlDFe()
        Dim SQLcommand2 As MySqlCommand
        SQLcommand2 = oConn.CreateCommand
        SQLcommand2.CommandText = "SELECT * FROM fone_cli where codigo_cli = '" & txtcod.Text & "'"
        dr = SQLcommand2.ExecuteReader()

        Dim fone As String
        While (dr.Read())
            fone = dr("fone_cli")

            If fone.ToString.Length = 11 Then
                fone = MascSTR(dr("fone_cli"), "(##) #-####-####")
            Else
                fone = MascSTR(dr("fone_cli"), "(##) ####-####")
            End If
            dgvfone.Rows.Add(fone, dr("codigo_cli"))
        End While

        dr.Close()
        SQLcommand2.Dispose()
        oConn.Close()


        conectar_mysqlDFe()
        Dim SQLcommand3 As MySqlCommand
        SQLcommand3 = oConn.CreateCommand
        SQLcommand3.CommandText = "SELECT * FROM municipio where codigo_municipio = '" & txtcod_munic.Text & "'"
        dr = SQLcommand3.ExecuteReader()

        While (dr.Read())
            txtuf.Text = dr("UF")
            txtcidade.Text = dr("NomeMunic")
        End While

        dr.Close()
        SQLcommand3.Dispose()
        oConn.Close()

    End Sub

    Private Sub Bnteditar_Click(sender As Object, e As EventArgs) Handles Bnteditar.Click
        txtcod.BackColor = Color.White
        limpar()
        dgvfone.Rows.Clear()
        gcliente.Enabled = True
        ' gconvenio.Enabled = fa
        pesq = False

        chkliberar.Checked = True

        txtcod.Focus()
        txtcod.ReadOnly = False
        gconvenio.Enabled = True

        Bnteditar.Visible = False
        bntcancelar.Visible = True
    End Sub

    Private Sub bntcancelar_Click(sender As Object, e As EventArgs) Handles bntcancelar.Click
        limpar()
        dgvfone.Rows.Clear()
        gcliente.Enabled = False
        gconvenio.Enabled = False


        Bnteditar.Visible = True
        bntcancelar.Visible = False
        btnexcluir.Enabled = True
        btnconsulta.Enabled = True
    End Sub

    Private Sub mskcpf_LostFocus(sender As Object, e As EventArgs) Handles mskcpf.LostFocus
        If mskcpf.Text.Length = 11 Then
            mskcpf.Mask = "000-000-000-00"
            If validaCPF(mskcpf.Text) = False Then
                MsgBox("O CPF informado é Invalido !!!", MsgBoxStyle.Exclamation, "Aviso !")
                mskcpf.Focus()
            End If
        Else

            mskcpf.Mask = "00,000,000/0000-00"
            If validacnpj(mskcpf.Text) = False Then
                MsgBox("O CNPJ informado é Invalido !!!", MsgBoxStyle.Exclamation, "Aviso !")
                mskcpf.Focus()
            End If

        End If
    End Sub


    Private Sub mskcpf_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskcpf.MaskInputRejected

    End Sub

    Private Sub frmcliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboind_dest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboind_dest.SelectedIndexChanged
        If cboind_dest.Text = "9–Não Contribuinte" Then
            indfinal = 1
        Else
            indfinal = 0
        End If
    End Sub

    Private Sub btnconsulta_Click(sender As Object, e As EventArgs) Handles btnconsulta.Click
        FrmConsultaDestinatario.Text = "Cadastro Cliente"
        FrmConsultaDestinatario.ShowDialog()
    End Sub

    Private Sub busca_muni()

        Try
            If Len(mskcep.Text) < 8 Then
                MsgBox("Cep Invalido !", MsgBoxStyle.Critical, "Aviso !")
                mskcep.Clear()
                mskcep.Focus()
                Exit Sub
            End If

            If IsConectedToHost(New Uri("http://www.google.com")) = False Then
                MsgBox("Esta Consulta é feita Online, e você está sem conexão com Internet ?" & vbCrLf & "Operação cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
                Exit Sub
            End If

            '  If chkcorreios.Checked = True Then
            BuscaCep(mskcep.Text)
            '  txtfiltro.Text = removerAc(ds.Tables(0).Rows(0).Item("cidade").ToString().Trim())
            pesquisar_cid(RemoverAcentos(ds.Tables(0).Rows(0).Item("cidade").ToString().Trim()))


        Catch ex As Exception
            MsgBox("Cidade não localizada !", MsgBoxStyle.Exclamation, "Aviso !")
        End Try


    End Sub

    Private Sub pesquisar_cid(ByVal cidade As String)
        Dim html As String

        html = GetUrl_cidade("https://servicodados.ibge.gov.br/api/v1/localidades/municipios/" & cidade & "")

        Dim jss As New JavaScriptSerializer()
        ' ret = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(json)
        Dim dict As Dictionary(Of String, Object) = CType(jss.DeserializeObject(html), Dictionary(Of String, Object))

        Dim ret As Integer = verificar_regexiste("Select * from municipio where codigo_municipio = '" & dict("id") & "'")
        Dim sql As String

        If ret = 0 Then
            sql = "INSERT INTO municipio (NomeMunic, NomeUF, UF, cod_UF, codigo_municipio) VALUES (@NomeMunic, @NomeUF, @UF, @cod_UF, @codigo_municipio)"
        Else
            sql = "UPDATE municipio SET NomeMunic = @NomeMunic, NomeUF = @NomeUF, UF = @UF, cod_UF = @cod_UF, codigo_municipio = @codigo_municipio"
        End If

        conectar_mysqlDFe()
        Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)

        insertSQL.Parameters.Add(New MySqlParameter("NomeMunic", dict("nome")))
        insertSQL.Parameters.Add(New MySqlParameter("NomeUF", dict("microrregiao")("mesorregiao")("UF")("nome")))
        insertSQL.Parameters.Add(New MySqlParameter("UF", dict("microrregiao")("mesorregiao")("UF")("sigla")))
        insertSQL.Parameters.Add(New MySqlParameter("cod_UF", dict("microrregiao")("mesorregiao")("UF")("id")))
        insertSQL.Parameters.Add(New MySqlParameter("codigo_municipio", dict("id")))



        insertSQL.ExecuteNonQuery()

        oConn.Close()

    End Sub

End Class