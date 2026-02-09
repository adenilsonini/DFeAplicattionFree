Imports System.IO
Imports System.Text
Imports System.Threading

Public Class frmpesquisa
    Dim nome_tabela As String, campo As String
    Dim rsconsulta1 As New ADODB.Recordset
    Dim rs As New ADODB.Recordset
    Dim rspesquisar As New ADODB.Recordset


    Private Sub dgvpesquisa_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvpesquisa.CellContentClick
     
    End Sub

   Private Sub txtnumero_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumero.KeyPress
        If (e.KeyChar = Chr(13)) Then

            '   nome_tabela = "razaosocial_for"
            nome_tabela = "Numero_nfe"
            campo = txtnumero.Text

            Dim rotina As Thread
            Control.CheckForIllegalCrossThreadCalls = False
            rotina = New Thread(AddressOf pesquisa_fornecedor)
            rotina.SetApartmentState(ApartmentState.STA)

            If rotina.ThreadState = ThreadState.Running Then
                rotina.Abort()
                Return
            End If

            rotina.Start()
        End If
    End Sub

    Private Sub txtcnpj_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcnpj.KeyPress
       
    End Sub

    ''' <summary>
    ''' 'Rotina pesquisa nome do fornecedor para esta funcionando''''''''''''''''
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub pesquisa_fornecedor()

        ginfo.Visible = True
        ginfo.Refresh()

        dgvpesquisa.Rows.Clear()

        conectar_onedrive(txtcaminho.Text)


        rspesquisar.Open("select * from Arquivos_xml where " & nome_tabela & " like '%" + campo + "%'", cn_ONE, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)


        pbDados.Maximum = Integer.Parse(rspesquisar.RecordCount)
        pbDados.Value = 0
        pbDados.Visible = True

        Do While rspesquisar.EOF = False
            dgvpesquisa.Invoke(DirectCast(Function() dgvpesquisa.Rows.Add(rspesquisar.Fields("Numero_nfe").Value, rspesquisar.Fields("razaosocial_for").Value, rspesquisar.Fields("Cnpj_emi").Value, rspesquisar.Fields("dataemissao").Value, rspesquisar.Fields("Chave_nfe").Value, "Baixar", "Visualizar"), MethodInvoker))

            pbDados.Value += 1
            Application.DoEvents()
            Thread.Sleep(1)

            rspesquisar.MoveNext()
        Loop

        cn_ONE.Close()

        ginfo.Visible = False

        GroupBox2.Text = "Resultado da Pesquisa: " & dgvpesquisa.RowCount & " Registros Encontrados"

        MsgBox("pesquisa realizada com sucesso !", MsgBoxStyle.Information, "Aviso !")

        pbDados.Value = "0"
        pbDados.Visible = False
    End Sub

    Private Sub txtnome_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnome.KeyPress
       
    End Sub

   
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dialodest As New OpenFileDialog
        dialodest.Filter = "Arquivo access (.mdb)|*.mdb"

        If dialodest.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtcaminho.Text = Path.GetDirectoryName(dialodest.FileName)
            Dim teste As New FileInfo(txtcaminho.Text)
            MsgBox(teste.FullName)
        End If
    End Sub

    Private Sub frmpesquisa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtnumero_TextChanged(sender As Object, e As EventArgs) Handles txtnumero.TextChanged

    End Sub

    Private Sub txtnome_TextChanged(sender As Object, e As EventArgs) Handles txtnome.TextChanged

    End Sub

    Private Sub txtcnpj_TextChanged(sender As Object, e As EventArgs) Handles txtcnpj.TextChanged

    End Sub
End Class