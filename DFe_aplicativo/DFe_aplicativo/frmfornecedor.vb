Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Web.Script.Serialization

Public Class frmfornecedor
    Public nfe As Boolean
    Dim parametro As String
    Dim nome As String = "nome_for"
    Dim rs As New ADODB.Recordset
    Dim agenda As Boolean

    Private Sub frmfornecedor_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmfornecedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub


    Public Sub novo()
        limpar()
        txtcod.Text = ProximoCodigo("cliente", "codigo_cli")
        gfornecedor.Enabled = True
        lbldatacad.Text = Now.Date

        dgvfone.Rows.Clear()
        txtnome.Focus()
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
            mskcnpj.Focus()

            txtcodmunicipio.Text = ret_valor_campo("select * from municipio where NomeMunic = '" & txtcidade.Text & "'", "codigo_municipio")

            If txtcidade.Text <> "" Then

                If txtcodmunicipio.Text = "" Then
                    txtcodmunicipio.Text = pesquisar_online_codmunic(txtcidade.Text)
                End If

            End If
            '  Exit Sub
            'End If


        End If
    End Sub

    Private Sub txtie_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtie.GotFocus
        If mskcnpj.Text = "" Then
            mskcnpj.Focus()
        End If
    End Sub

    Private Sub salvar()
        Dim codigo As Integer = 0

        If verificar_regexiste("Select * from municipio where codigo_municipio = '" & txtcodmunicipio.Text & "'") = "0" Then
            busca_muni()
        End If

        Dim ret As Integer = verificar_regexiste("Select * from cliente where codigo_cli = '" & txtcod.Text & "'")
        Dim sql As String

        If ret = 0 Then
            sql = "INSERT INTO cliente (nome_cli, nome_fant, end_cli, numero_cli, bairro_cli, cep_cli, cod_munic, cod_pais, cnpjcpf_cli, ierg_cli, ie_munic, contato_cli, email, aliq_simples, obs, ind_dest, for_cli, data_cad, tipo, data_nasc, transportadora, cliente_ativo, cliente_for, fone_cli, codigo_conv, prazo_pag, vlr_limite, vlr_desc, vlr_disp, cliente_lib) VALUES (@nome_cli, @nome_fant, @end_cli, @numero_cli, @bairro_cli, @cep_cli, @cod_munic, @cod_pais, @cnpjcpf_cli, @ierg_cli, @ie_munic, @contato_cli, @email, @aliq_simples, @obs, @ind_dest, @for_cli, @data_cad, @tipo, @data_nasc, @transportadora, @cliente_ativo, @cliente_for, @fone_cli, @codigo_conv, @prazo_pag, @vlr_limite, @vlr_desc, @vlr_disp, @cliente_lib)"
        Else
            sql = "UPDATE cliente set nome_cli = @nome_cli, nome_fant = @nome_fant, end_cli = @end_cli, numero_cli = @numero_cli, bairro_cli = @bairro_cli, cep_cli = @cep_cli, cod_munic = @cod_munic, cod_pais = @cod_pais, cnpjcpf_cli = @cnpjcpf_cli, ierg_cli = @ierg_cli, ie_munic = @ie_munic, contato_cli = @contato_cli, email = @email, aliq_simples = @aliq_simples, obs = @obs, ind_dest = @ind_dest, for_cli = @for_cli, data_cad = @data_cad, tipo = @tipo, data_nasc = @data_nasc, transportadora = @transportadora, cliente_ativo = @cliente_ativo, cliente_for = @cliente_for, fone_cli = @fone_cli, codigo_conv = @codigo_conv, prazo_pag = @prazo_pag, vlr_limite = @vlr_limite, vlr_desc = @vlr_desc, vlr_disp = @vlr_disp, cliente_lib = @cliente_lib where codigo_cli = " & txtcod.Text & ""
        End If

        conectar_mysqlDFe()
        Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)


        insertSQL.Parameters.Add(New MySqlParameter("nome_cli", txtnome.Text))
        insertSQL.Parameters.Add(New MySqlParameter("nome_fant", txtsigla.Text))
        insertSQL.Parameters.Add(New MySqlParameter("end_cli", txtend.Text))
        insertSQL.Parameters.Add(New MySqlParameter("numero_cli", txtnumero.Text))
        insertSQL.Parameters.Add(New MySqlParameter("bairro_cli", txtbairro.Text))
        insertSQL.Parameters.Add(New MySqlParameter("cep_cli", mskcep.Text))
        insertSQL.Parameters.Add(New MySqlParameter("cod_munic", txtcodmunicipio.Text))
        insertSQL.Parameters.Add(New MySqlParameter("cod_pais", txtcodpais.Text))
        insertSQL.Parameters.Add(New MySqlParameter("cnpjcpf_cli", mskcnpj.Text))
        insertSQL.Parameters.Add(New MySqlParameter("ierg_cli", txtie.Text))
        insertSQL.Parameters.Add(New MySqlParameter("ie_munic", txtim.Text))
        insertSQL.Parameters.Add(New MySqlParameter("contato_cli", txtcontato.Text))
        insertSQL.Parameters.Add(New MySqlParameter("email", txtemail.Text))
        insertSQL.Parameters.Add(New MySqlParameter("aliq_simples", format_val_mysql_ent(txtaliqsimples.Text)))
        insertSQL.Parameters.Add(New MySqlParameter("obs", txtobs.Text))
        insertSQL.Parameters.Add(New MySqlParameter("ind_dest", "9"))
        insertSQL.Parameters.Add(New MySqlParameter("for_cli", chkcli.Checked))
        insertSQL.Parameters.Add(New MySqlParameter("data_cad", Convert.ToDateTime(lbldatacad.Text).ToString("yyyy-MM-dd")))
        insertSQL.Parameters.Add(New MySqlParameter("tipo", "F"))
        insertSQL.Parameters.Add(New MySqlParameter("data_nasc", Convert.ToDateTime(lbldatacad.Text).ToString("yyyy-MM-dd")))
        insertSQL.Parameters.Add(New MySqlParameter("transportadora", chktrans.Checked))
        insertSQL.Parameters.Add(New MySqlParameter("cliente_ativo", "1"))
        insertSQL.Parameters.Add(New MySqlParameter("cliente_for", chkcli.Checked))

        insertSQL.Parameters.Add(New MySqlParameter("prazo_pag", "30"))
        insertSQL.Parameters.Add(New MySqlParameter("vlr_limite", "100.00"))
        insertSQL.Parameters.Add(New MySqlParameter("vlr_desc", "0.00"))
        insertSQL.Parameters.Add(New MySqlParameter("vlr_disp", "0.00"))
        insertSQL.Parameters.Add(New MySqlParameter("cliente_lib", "1"))


        For Each row As DataGridViewRow In Me.dgvfone.Rows
            insertSQL.Parameters.Add(New MySqlParameter("fone_cli", removeFormatacao(row.Cells(0).Value)))
        Next

        If dgvfone.Rows.Count = 0 Then
            insertSQL.Parameters.Add(New MySqlParameter("fone_cli", ""))
        End If

        insertSQL.Parameters.Add(New MySqlParameter("codigo_conv", "1"))

        insertSQL.ExecuteNonQuery()
        oConn.Close()


        ''''''''''Rotina para salvar produto na tabela codigos barras

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


        If chkcli.Checked = True Then
            carga_cli(txtcod.Text, txtnome.Text, mskcnpj.Text, txtend.Text, txtnumero.Text, txtbairro.Text, mskcep.Text, txtcodmunicipio.Text, txtuf.Text, txtcidade.Text, txtie.Text, "30", "100.00", "0.00", lbldatacad.Text, "1", "0,00", txtemail.Text, fone)
        End If

        If sql.Substring(0, 6) = "INSERT" Then
            MsgBox("Produto Salvo com sucesso !", MsgBoxStyle.Information, "Aviso !")
            limpar()
            txtcod.Text = ""

        Else
            MsgBox("Produto alterado com sucesso !", MsgBoxStyle.Information, "Aviso !")
        End If

        limpar()
        dgvfone.Rows.Clear()
        gfornecedor.Enabled = False



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

        Dim arquivo As String = parametro.Caminho_arq_export & "\carga.cac"
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


    Public Sub carregar_FORNECEDOR(ByVal codigo As String, ByVal CNPJ As Boolean)

        txtcod.BackColor = Color.White
        limpar()
        dgvfone.Rows.Clear()
        gfornecedor.Enabled = True

        Dim sql As String
        ' 
        conectar_baseNFe()

        ''''''''Rotina para buscar pela codigo de barras'''''''''''
        sql = "SELECT * FROM cliente where codigo_cli =" & codigo & " and (tipo = 'F' or cliente_for = '1')"

        If CNPJ = True Then

            sql = "SELECT * FROM cliente where cnpjcpf_cli ='" & mskcnpj.Text & "' and (tipo = 'F' or cliente_for = '1')"

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

                txtcod.Text = reader("codigo_cli")
                txtnome.Text = reader("nome_cli")
                txtsigla.Text = reader("nome_fant").ToString
                txtend.Text = reader("end_cli")
                txtnumero.Text = reader("numero_cli")
                txtbairro.Text = reader("bairro_cli")
                mskcep.Text = reader("cep_cli")

                If reader("cnpjcpf_cli").ToString.Length = 11 Then
                    mskcnpj.Mask = "000-000-000-00"
                    mskcnpj.Text = reader("cnpjcpf_cli")
                Else
                    mskcnpj.Mask = "00,000,000/0000-00"
                    mskcnpj.Text = reader("cnpjcpf_cli")
                End If

                txtie.Text = reader("ierg_cli")
                txtim.Text = reader("ie_munic").ToString
                txtcodpais.Text = reader("cod_pais").ToString
                txtcodmunicipio.Text = reader("cod_munic")
                chkcli.Checked = reader("for_cli")
                txtemail.Text = reader("email")
                txtobs.Text = reader("obs")
                txtcontato.Text = reader("contato_cli").ToString
                chktrans.Checked = reader("transportadora")


                If reader("aliq_simples").ToString <> "0.00" Then
                    chkaliqsimples.Checked = True
                End If

                txtaliqsimples.Text = format_val_mysql_ret(reader("aliq_simples").ToString)

                lbldatacad.Text = Convert.ToDateTime(reader("data_cad")).ToString("dd/MM/yyyy")
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
        SQLcommand3.CommandText = "SELECT * FROM municipio where codigo_municipio = '" & txtcodmunicipio.Text & "'"
        dr = SQLcommand3.ExecuteReader()

        While (dr.Read())
            txtuf.Text = dr("UF")
            txtcidade.Text = dr("NomeMunic")
        End While

        dr.Close()
        SQLcommand3.Dispose()
        oConn.Close()

    End Sub

    Private Sub limpar()
        txtbairro.Clear()
        txtcidade.Clear()
        txtcod.Clear()
        txtcodmunicipio.Clear()
        txtcontato.Clear()
        txtemail.Clear()
        txtend.Clear()
        txtie.Clear()
        txtnome.Clear()
        txtnumero.Clear()
        txtobs.Clear()
        txtsigla.Clear()
        txtuf.Clear()
        txtim.Clear()
        mskcnpj.Clear()
        mskcep.Clear()
    End Sub

    Private Sub txtcodp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Chr(13)) Then

        End If
    End Sub


    Private Sub bexcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtcod.Text <> "" Then
            If MessageBox.Show("Deseja Realmente Excluir o Fornecedor: " & txtnome.Text, "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                ' conectar()

                ' rs.Open("select * from Nfentrada where codigo_for like '" & txtcod.Text & "'", conexao.cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                ' If rs.EOF = False Then
                '   MsgBox("O Fornecedor não Pode ser excluido !" + vbCrLf + "Existem Notas Lancadas no Fornecedor", MsgBoxStyle.Information, "Aviso !")
                '    rs.Close()
                '    conexao.cnsql.Close()
                '    Exit Sub
                '  Else
                '   rs.Close()
                ' End If

                ' rs.Open("select * from cheque where codigo_for like '" & txtcod.Text & "'", conexao.cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                '  If rs.EOF = False Then
                ' MsgBox("O Fornecedor não Pode ser excluido !" + vbCrLf + "Existem Cheques no Nome do Fornecedor", MsgBoxStyle.Information, "Aviso !")
                '  rs.Close()
                '  conexao.cnsql.Close()
                '    Exit Sub
                ' Else
                '     rs.Close()
                '  End If

                ' rsdelete.Open("delete * from fornecedor where codigo_for like '" & txtcod.Text & "'", conexao.cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                '   conexao.cnsql.Close()
                MsgBox("Fornecedor excluido com Sucesso !", MsgBoxStyle.Information, "Aviso !")
                limpar()
                dgvfone.Rows.Clear()
                gfornecedor.Enabled = False
            End If
        End If
    End Sub

    Private Sub bsair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub

    Private Sub chkcorreios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If My.Computer.Network.IsAvailable = False Then
            MsgBox("É Necessario conexão com a internet para essa opção", MsgBoxStyle.Exclamation, "Aviso !")

        End If
    End Sub

    Private Sub btnovo_Click(sender As Object, e As EventArgs) Handles btnovo.Click
        novo()
    End Sub

    Private Sub chkaliqsimples_CheckedChanged(sender As Object, e As EventArgs) Handles chkaliqsimples.CheckedChanged
        If chkaliqsimples.Checked = True Then
            txtaliqsimples.Enabled = True
            txtaliqsimples.Focus()
        Else
            txtaliqsimples.Enabled = False
            txtaliqsimples.Text = "0,00"
        End If
    End Sub

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

    Private Sub mskcep_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskcep.MaskInputRejected

    End Sub

    Private Sub btnsalvar_Click(sender As Object, e As EventArgs) Handles btnsalvar.Click
        If txtnome.Text = "" Then
            MsgBox("Informe A Razão Social do Fornecedor", MsgBoxStyle.Critical, "Aviso !")
            Exit Sub
        End If

        If txtend.Text = "" Then
            MsgBox("Informe O Endereço ! (Obrigatorio)", MsgBoxStyle.Critical, "Aviso !")
            Exit Sub
        End If

        If txtnumero.Text = "" Then
            MsgBox("Informe O Número ! (Obrigatorio)", MsgBoxStyle.Critical, "Aviso !")
            txtnumero.Focus()
            Exit Sub
        End If

        If txtbairro.Text = "" Then
            MsgBox("Informe O Bairro ! (Obrigatorio)", MsgBoxStyle.Critical, "Aviso !")
            Exit Sub
        End If

        If mskcep.Text = "" Then
            MsgBox("Informe O Cep ! (Obrigatorio)", MsgBoxStyle.Critical, "Aviso !")
            Exit Sub
        End If

        If mskcnpj.Text = "" Then
            MsgBox("Informe O CNPJ ! (Obrigatorio)", MsgBoxStyle.Critical, "Aviso !")
            Exit Sub
        End If

        If txtie.Text = "" Then
            MsgBox("Informe A Insc. Estadual ! (Obrigatorio)", MsgBoxStyle.Critical, "Aviso !")
            Exit Sub
        End If

        salvar()
    End Sub

    Private Sub txtcod_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcod.KeyPress
        If (e.KeyChar = Chr(13)) Then
            carregar_FORNECEDOR(txtcod.Text, False)
        End If
    End Sub

    Private Sub txtcod_TextChanged(sender As Object, e As EventArgs) Handles txtcod.TextChanged

    End Sub

    Private Sub Bnteditar_Click(sender As Object, e As EventArgs) Handles Bnteditar.Click
        txtcod.BackColor = Color.White
        limpar()
        dgvfone.Rows.Clear()
        gfornecedor.Enabled = True
        ' gconvenio.Enabled = fa

        txtcod.Focus()
        txtcod.ReadOnly = False

        Bnteditar.Visible = False
        bntcancelar.Visible = True
    End Sub

    Private Sub txtaliqsimples_LostFocus(sender As Object, e As EventArgs) Handles txtaliqsimples.LostFocus
        If txtaliqsimples.Text = "" Then
            txtaliqsimples.Text = "0,00"
        Else
            txtaliqsimples.Text = Convert.ToDouble(txtaliqsimples.Text).ToString("N2")
            txtaliqsimples.Text = txtaliqsimples.Text
        End If
    End Sub

    Private Sub txtaliqsimples_TextChanged(sender As Object, e As EventArgs) Handles txtaliqsimples.TextChanged

    End Sub

    Private Sub frmfornecedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub bntcancelar_Click(sender As Object, e As EventArgs) Handles bntcancelar.Click
        limpar()
        gfornecedor.Enabled = False
        bntcancelar.Visible = False
        Bnteditar.Visible = True
    End Sub

    Private Sub btnsair_Click(sender As Object, e As EventArgs) Handles btnsair.Click
        Me.Close()
    End Sub

    Private Sub mskcnpj_LostFocus(sender As Object, e As EventArgs) Handles mskcnpj.LostFocus


        If mskcnpj.Text.Length = 11 Then

            mskcnpj.Mask = "000-000-000-00"
            If validaCPF(mskcnpj.Text) = False Then
                MsgBox("O CPF informado é Invalido !!!", MsgBoxStyle.Exclamation, "Aviso !")
                mskcnpj.Focus()
            End If

        Else

            If validacnpj(mskcnpj.Text) = False Then
                MsgBox("O CNPJ informado é Invalido !!!", MsgBoxStyle.Exclamation, "Aviso !")
                mskcnpj.Focus()
            End If
            mskcnpj.Mask = "00,000,000/0000-00"

        End If
    End Sub

    Private Sub btnconsulta_Click(sender As Object, e As EventArgs) Handles btnconsulta.Click
        FrmConsultaDestinatario.Text = "Cadastro Fornecedor"
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