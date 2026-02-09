Imports System.Data
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class FrmConsultaDestinatario
    Dim valor_cnpj As String
    Dim sql As String

    Private Sub FrmConsultaDestinatario_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Me.Text = "Consulta Destinatário NF-e" Then
            chkdest_inativa.Visible = False
        End If

        If Me.Text = "Consulta Transportadora NF-e" Then
            chkdest_inativa.Visible = False
        End If

        If Me.Text = "Consulta Destinátios Cadastrados" Then
            chkdest_inativa.Visible = True
        End If
    End Sub

    Private Sub FrmConsultaDestinatario_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub FrmConsultaDestinatario_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Dispose()
        End Select
    End Sub

    Private Sub listarDestinatario(ByVal codigo As String, ByVal tipo As Integer)


        dgvDestinatarios.Rows.Clear()

        If Me.Text = "Consulta Transportadora NF-e" Then
            sql = "SELECT * FROM cliente INNER JOIN municipio ON municipio.codigo_municipio = cliente.cod_munic WHERE  nome_cli like '%" & codigo & "%' and transportadora = '1'"
        Else
            If tipo = 1 Then
                sql = "SELECT * FROM cliente INNER JOIN municipio ON municipio.codigo_municipio = cliente.cod_munic WHERE (tipo = 'C' or for_cli = '1') and nome_cli like '%" & codigo & "%' and cliente_ativo = '1'"
            End If
            If tipo = 2 Then
                sql = "SELECT * FROM cliente INNER JOIN municipio ON municipio.codigo_municipio = cliente.cod_munic WHERE (tipo = 'C' or for_cli = '1') and cnpjcpf_cli = '" & codigo & "' and cliente_ativo = '1'"
            End If
        End If

     
        If Me.Text = "Cadastro Fornecedor" Or Me.Text = "Consulta Fornecedor NFe entrada" Then
            If tipo = 1 Then
                sql = "SELECT * FROM cliente INNER JOIN municipio ON municipio.codigo_municipio = cliente.cod_munic WHERE (tipo = 'F' or for_cli = '1') and nome_cli like '%" & codigo & "%' and cliente_ativo = '1'"
            End If
            If tipo = 2 Then
                sql = "SELECT * FROM cliente INNER JOIN municipio ON municipio.codigo_municipio = cliente.cod_munic WHERE (tipo = 'F' or for_cli = '1') and cnpjcpf_cli = '" & codigo & "' and cliente_ativo = '1'"
            End If
        End If

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read

                valor_cnpj = reader("cnpjcpf_cli")

                If valor_cnpj.Length = 14 Or valor_cnpj.Length = 11 Then
                    valor_cnpj = FormatarCpfCnpj(valor_cnpj)
                End If

                dgvDestinatarios.Rows.Add(reader("codigo_cli"), reader("nome_cli"), valor_cnpj, reader("ierg_cli"), reader("uf"))

            End While

        End Using


        If dgvDestinatarios.Rows.Count = 0 Then
            MsgBox("Fornecedor não cadastrado !", MsgBoxStyle.Exclamation, "Aviso !")
            txtrazaosocial.Focus()
        End If

    End Sub

  
    Private Sub txtrazaosocial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtrazaosocial.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            listarDestinatario(txtrazaosocial.Text, 1)
        End If
    End Sub

    Private Sub txtcnpj_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcnpj.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            listarDestinatario(txtcnpj.Text, 2)
        End If
    End Sub

    Private Sub dgvDestinatarios_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDestinatarios.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
        End If
    End Sub

    Private Sub dgvDestinatarios_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvDestinatarios.KeyPress
        If (e.KeyChar = Chr(13)) Then
            If dgvDestinatarios.Rows.Count <> 0 Then

                If Me.Text = "Consulta Fornecedor NFe entrada" Then
                    frmnfe_entrada.carregar_emi(removeFormatacao(dgvDestinatarios.CurrentRow.Cells("cnpj").Value))
                End If

                If Me.Text = "Consulta Transportadora NF-e" Then
                    frmxml_nfe.pesquisa_transportadora(dgvDestinatarios.CurrentRow.Cells(2).Value, "")
                End If

                If Me.Text = "Cadastro Cliente" Then
                    frmcliente.carregar_cliente(dgvDestinatarios.CurrentRow.Cells(0).Value, False)
                End If

                If Me.Text = "Cadastro Fornecedor" Then
                    frmfornecedor.carregar_FORNECEDOR(dgvDestinatarios.CurrentRow.Cells(0).Value, False)
                End If

                If Me.Text = "Consulta Destinatário NF-e" Then

                    frmxml_nfe.txtnomecli.Text = dgvDestinatarios.CurrentRow.Cells(1).Value


                    If removeFormatacao(dgvDestinatarios.CurrentRow.Cells(2).Value.ToString.Length) = 18 Then
                        frmxml_nfe.mskcnpjcpf_cli.Mask = "00.000.000/0000-00"
                        frmxml_nfe.mskcnpjcpf_cli.Text = removeFormatacao(dgvDestinatarios.CurrentRow.Cells(2).Value)
                    Else
                        frmxml_nfe.mskcnpjcpf_cli.Mask = "000.000.000-00"
                        frmxml_nfe.mskcnpjcpf_cli.Text = removeFormatacao(dgvDestinatarios.CurrentRow.Cells(2).Value)
                    End If

                    frmxml_nfe.pesquisa_destinatario(frmxml_nfe.mskcnpjcpf_cli.Text, empresa.ambiente_nfe)

                End If

                Me.Close()

            End If
        End If
    End Sub

    Private Sub dgvDestinatarios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDestinatarios.CellContentClick

    End Sub

    Private Sub txtrazaosocial_TextChanged(sender As Object, e As EventArgs) Handles txtrazaosocial.TextChanged

    End Sub

    Private Sub FrmConsultaDestinatario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class