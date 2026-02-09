Imports System.Threading
Imports System.IO
Imports System.Xml

Public Class frmpesq_onedrive

    Dim nome_tabela As String, campo As String
    Dim rsconsulta1 As New ADODB.Recordset
    Dim rs As New ADODB.Recordset
    Dim rspesquisar As New ADODB.Recordset
    Private Sub txtnumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumero.KeyPress
        If (e.KeyChar = Chr(13)) Then

            If txtcaminho.Text = "" Then
                MsgBox("Informe o caminho do Banco de Dados OneDrive ?", MsgBoxStyle.Exclamation, "Aviso !")
                Button1.Focus()
                Exit Sub
            End If

            If ginfo.Visible = True Then
                Exit Sub
            End If


            nome_tabela = "Numero_nfe"
            campo = txtnumero.Text

            ginfo.Visible = True
            ginfo.Refresh()
            pbDados.Visible = True

            Dim rotina As Thread
            Control.CheckForIllegalCrossThreadCalls = False
            rotina = New Thread(AddressOf pesquisa_fornecedor)
            rotina.SetApartmentState(ApartmentState.STA)

            If rotina.IsAlive = False Then
                rotina.Start()
            End If

        End If
    End Sub

    Private Sub txtnome_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnome.KeyPress
        If (e.KeyChar = Chr(13)) Then

            If txtcaminho.Text = "" Then
                MsgBox("Informe o caminho do Banco de Dados OneDrive ?", MsgBoxStyle.Exclamation, "Aviso !")
                Button1.Focus()
                Exit Sub
            End If

            If ginfo.Visible = True Then
                Exit Sub
            End If

            nome_tabela = "razaosocial_for"
            campo = txtnome.Text

            ginfo.Visible = True
            ginfo.Refresh()
            pbDados.Visible = True

            Dim rotina As Thread
            Control.CheckForIllegalCrossThreadCalls = False
            rotina = New Thread(AddressOf pesquisa_fornecedor)
            rotina.SetApartmentState(ApartmentState.STA)

            If rotina.IsAlive = False Then
                rotina.Start()
            End If


        End If
    End Sub

    Private Sub txtcnpj_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcnpj.KeyPress
        If (e.KeyChar = Chr(13)) Then

            If txtcaminho.Text = "" Then
                MsgBox("Informe o caminho do Banco de Dados OneDrive ?", MsgBoxStyle.Exclamation, "Aviso !")
                Button1.Focus()
                Exit Sub
            End If

            If ginfo.Visible = True Then
                Exit Sub
            End If

            nome_tabela = "cnpj_emi"
            campo = txtcnpj.Text

            ginfo.Visible = True
            ginfo.Refresh()
            pbDados.Visible = True

            Dim rotina As Thread
            Control.CheckForIllegalCrossThreadCalls = False
            rotina = New Thread(AddressOf pesquisa_fornecedor)
            rotina.SetApartmentState(ApartmentState.STA)

            If rotina.IsAlive = False Then
                rotina.Start()
            End If


        End If
    End Sub

    Private Sub pesquisa_fornecedor()

      

        dgvpesquisa.Rows.Clear()


        conectar_onedrive(txtcaminho.Text & "\Banco_xml.mdb")

        If nome_tabela = "Numero_nfe" Or nome_tabela = "cnpj_emi" Then
            rspesquisar.Open("select * from Arquivos_xml where " & nome_tabela & " = '" + campo + "'", cn_ONE, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        Else
            rspesquisar.Open("select * from Arquivos_xml where " & nome_tabela & " like '%" + campo + "%'", cn_ONE, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        End If




        pbDados.Maximum = Integer.Parse(rspesquisar.RecordCount)
        pbDados.Value = 0


        Do While rspesquisar.EOF = False

            Dim xml_NFe As New XmlDocument()

            If rspesquisar.Fields("Chave_nfe").Value.ToString.Substring(6, 14) <> "10962965000119" Then
                xml_NFe.Load(txtcaminho.Text.Substring(0, txtcaminho.Text.Length - 15) + "\Arquivos XML\Arquivos de Fornecedor\" + rspesquisar.Fields("Chave_nfe").Value + ".xml")
            Else
                xml_NFe.Load(txtcaminho.Text.Substring(0, txtcaminho.Text.Length - 15) + "\Arquivos XML\Arquivos da Empresa\" + rspesquisar.Fields("Chave_nfe").Value + ".xml")
            End If

            dgvpesquisa.Invoke(DirectCast(Function() dgvpesquisa.Rows.Add(rspesquisar.Fields("Numero_nfe").Value, rspesquisar.Fields("razaosocial_for").Value, rspesquisar.Fields("Cnpj_emi").Value, rspesquisar.Fields("dataemissao").Value, rspesquisar.Fields("Chave_nfe").Value, "Baixar", "Visualizar", xml_NFe.OuterXml), MethodInvoker))

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

    Private Sub dgvpesquisa_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpesquisa.CellClick
        If dgvpesquisa.CurrentCell.Value = "Baixar" Then
            SaveFileDialog1.FileName = dgvpesquisa.CurrentRow.Cells(4).Value + ".xml"

            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim xml_NFe As New XmlDocument()
                If dgvpesquisa.CurrentRow.Cells("xml").Value <> "" Then
                    xml_NFe.LoadXml(dgvpesquisa.CurrentRow.Cells("xml").Value)
                End If

                xml_NFe.Save(SaveFileDialog1.FileName)

                MsgBox("Download Realizado Com Sucesso !", MsgBoxStyle.Information, "Aviso !")


            End If

        End If

        If dgvpesquisa.CurrentCell.Value = "Visualizar" Then

        
            If dgvpesquisa.CurrentRow.Cells("xml").Value <> "" Then
                frmxml.abrir_xml(dgvpesquisa.CurrentRow.Cells("xml").Value)
            End If


            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dialodest As New OpenFileDialog
        dialodest.Filter = "Arquivo access (.mdb)|*.mdb"

        If dialodest.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtcaminho.Text = Path.GetDirectoryName(dialodest.FileName)
            txtcaminho.Focus()
        End If
    End Sub

    Private Sub txtcaminho_LostFocus(sender As Object, e As EventArgs) Handles txtcaminho.LostFocus
        escreveINI(Application.StartupPath & "\config_DFe.ini", "DFe", "caminho_ONEdrive", txtcaminho.Text)
    End Sub

   
    Private Sub txtcaminho_TextChanged(sender As Object, e As EventArgs) Handles txtcaminho.TextChanged

    End Sub

    Private Sub frmpesq_onedrive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtcaminho.Text = lerINI(Application.StartupPath & "\config_DFe.ini", "DFe", "caminho_ONEdrive")
    End Sub
End Class