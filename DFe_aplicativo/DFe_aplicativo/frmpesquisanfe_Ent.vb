Imports System.Text
Imports System.Xml
Imports System.Threading
Imports Microsoft.VisualBasic.Devices
Imports System.Drawing.Printing
Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Reflection

Public Class frmpesquisanfe_Ent
    Dim rotina2 As Thread
    Dim nome_impressora As String
    Dim xmlnfe As String
    Dim xmldoc As New XmlDocument()
    Dim xmlnsManager As New XmlNamespaceManager(xmldoc.NameTable)
    Dim ambiente As Integer
    Dim status As String
    Dim desc As String, nsequencia As String, prot_evento As String
    Dim data_prot As Date, hora_prot As Date

    Dim doc_carta As Printing.PrintDocument

    Dim rs As New ADODB.Recordset

    Private Sub dgvpisquisa_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpisquisa.CellClick

    End Sub

    Private Sub txtnome_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnome.KeyPress
        If (e.KeyChar = Chr(13)) Then
            pesquisar_nfe()

            'MsgBox("Pesquisa por Nome destinatário Realizada !", MsgBoxStyle.Information, "Aviso !")
            If dgvpisquisa.RowCount = 1 Then
                dgvpisquisa.Focus()
            End If
        End If
    End Sub

    Public Sub pesquisar_nfe()
        Dim sql As String, xml_aut As String, xml_canc As String, xml As String, carta As String
        Dim status_nfe As String
        Dim data_ini As Date = Dataini.Text
        Dim data_fim As Date = datafin.Text
        dgvpisquisa.Rows.Clear()

       


        sql = "select * from nfe_e INNER JOIN cliente ON nfe_e.cnpj_for = cliente.cnpjcpf_cli WHERE nfe_e.tipo_pag = '0'"

        
        If chkdescricao.Checked = True Then
            sql = sql + " and cliente.nome_cli like '%" & txtnome.Text & "%'"
        End If


        If chkdata.Checked = True Then
            sql = sql + " AND nfe_e.data_ent between '" & data_ini.ToString("yyyy-MM-dd") & "' AND '" & data_fim.ToString("yyyy-MM-dd") & "'"
        End If

        If chkvalor.Checked = True Then
            Dim valor As String = format_val_mysql_ent(txtvlrnf.Text)
            sql = sql + " and nfe_e.vlr_totalnf = '" & valor & "'"
        End If

        If chknumero.Checked = True Then
            sql = sql + " and nfe_e.numero_nfe = '" & txtnumero.Text & "'"
        End If



        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read

                dgvpisquisa.Rows.Add(reader("numero_nfe"), reader("serie_nfe"), reader("modelo_nfe"), Convert.ToDateTime(reader("data_emi")).ToString("dd/MM/yyyy"), Convert.ToDateTime(reader("data_ent")).ToString("dd/MM/yyyy"), reader("nome_cli"), _
                                             format_val_mysql_ret(reader("vlr_totalnf")), format_val_mysql_ret(reader("vlr_icms")), reader("cnpj_for"))


            End While

        End Using




        lbltotalnotas.Text = dgvpisquisa.RowCount

       
    End Sub


    Private Sub dgvpisquisa_Click(sender As Object, e As EventArgs) Handles dgvpisquisa.Click

        If dgvpisquisa.RowCount = 0 Then
            Exit Sub
        End If


        'If dgvpisquisa.CurrentRow.Cells("status_NFe").Value.ToString.Length >= 9 Then
        'If dgvpisquisa.CurrentRow.Cells("status_NFe").Value.ToString.Substring(0, 9) = "Rejeicao:" Then
        'MsgBox(dgvpisquisa.CurrentRow.Cells("status_NFe").Value.ToString, MsgBoxStyle.Exclamation, "Aviso NF-e Rejeita Motivo !")
        '  End If
        ' End If



    End Sub

    Private Sub cbostatus_KeyPress(sender As Object, e As KeyPressEventArgs)
        If (e.KeyChar = Chr(13)) Then
            pesquisar_nfe()
            MsgBox("Pesquisa Realizada por Status NF-e", MsgBoxStyle.Information, "Aviso !")
        End If
    End Sub

  
    Private Sub frmpesquisanfe_emi_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                pesquisar_nfe()
            Case Keys.Escape
                Me.Dispose()
        End Select
    End Sub

    Private Sub frmpesquisanfe_emi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dataini.Text = Now.ToString("01/MM/yyyy")
        Dataini.Enabled = True
        datafin.Enabled = True
    End Sub

    Private Sub chkdata_CheckedChanged(sender As Object, e As EventArgs) Handles chkdata.CheckedChanged
        If chkdata.Checked = True Then
            Dataini.Enabled = True
            datafin.Enabled = True
        Else
            Dataini.Enabled = False
            datafin.Enabled = False
        End If
    End Sub

    Private Sub chkdescricao_CheckedChanged(sender As Object, e As EventArgs) Handles chkdescricao.CheckedChanged
        If chkdescricao.Checked = True Then
            txtnome.Enabled = True
            txtnome.Focus()
        Else
            txtnome.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pesquisar_nfe()

        If dgvpisquisa.RowCount = 1 Then
            dgvpisquisa.Focus()
        End If

        ' MsgBox("Pesquisa por Nome destinatário Realizada !", MsgBoxStyle.Information, "Aviso !")
    End Sub

    Private Sub chknumero_CheckedChanged(sender As Object, e As EventArgs) Handles chknumero.CheckedChanged
        If chknumero.Checked = True Then
            txtnumero.Enabled = True
            txtnumero.Focus()
        Else
            txtnumero.Enabled = False
            txtnumero.Clear()
        End If
    End Sub

    Private Sub txtnumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumero.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If

        If (e.KeyChar = Chr(13)) Then
            pesquisar_nfe()
            MsgBox("Pesquisa Realizada por Número da NF-e !", MsgBoxStyle.Information, "Aviso !")

            If dgvpisquisa.RowCount = 1 Then
                dgvpisquisa.Focus()
            End If
        End If
    End Sub

    Private Sub dgvpisquisa_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvpisquisa.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
        End If
    End Sub


    Private Sub dgvpisquisa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvpisquisa.KeyPress
        If (e.KeyChar = Chr(13)) Then

            If dgvpisquisa.Rows.Count <> 0 Then

                frmnfe_entrada.carregar_emi(dgvpisquisa.CurrentRow.Cells("cnpj_for").Value)

                frmnfe_entrada.consulta(dgvpisquisa.CurrentRow.Cells("numero_nfe").Value & dgvpisquisa.CurrentRow.Cells("serie_nfe").Value & dgvpisquisa.CurrentRow.Cells("modelo_nf").Value & dgvpisquisa.CurrentRow.Cells("cnpj_for").Value)



                frmnfe_entrada.txtnumeronf.ReadOnly = True
                frmnfe_entrada.txtserienfe.ReadOnly = True
                frmnfe_entrada.cbomodelo.Enabled = False
                frmnfe_entrada.data_emissao.Enabled = False
                frmnfe_entrada.mskcnpj_emi.ReadOnly = True
                frmnfe_entrada.PictureBox5.Enabled = False

                frmnfe_entrada.Panel_ini.Enabled = True
                frmnfe_entrada.Panel_item.Enabled = True
                Me.Close()

            End If

        End If
    End Sub

    Private Sub Dataini_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Dataini.KeyPress
        If (e.KeyChar = Chr(13)) Then
            pesquisar_nfe()
            MsgBox("Pesquisa Realizada por Data emissão da NF-e !", MsgBoxStyle.Information, "Aviso !")
        End If
    End Sub

    Private Sub datafin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles datafin.KeyPress
        If (e.KeyChar = Chr(13)) Then
            pesquisar_nfe()
            MsgBox("Pesquisa Realizada por Data emissão da NF-e !", MsgBoxStyle.Information, "Aviso !")
        End If
    End Sub

   
    Private Function pesquisa_grid(ByVal id As String) As String

        Dim r As String = "R"

        For Each row As DataGridViewRow In Me.dgvpisquisa.Rows

            If Not row.IsNewRow Then
                If row.Cells("numero_nfe").Value = id Then
                    Return row.Index
                End If
            End If

        Next

        Return r

    End Function

    Private Sub chkvalor_CheckedChanged(sender As Object, e As EventArgs) Handles chkvalor.CheckedChanged
        If chkvalor.Checked = True Then
            txtvlrnf.Enabled = True
            txtvlrnf.Focus()
        Else
            txtvlrnf.Enabled = False
        End If
    End Sub

    Private Sub txtvlrnf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtvlrnf.KeyPress
        If (e.KeyChar = Chr(13)) Then
            pesquisar_nfe()
            MsgBox("Pesquisa Realizada por Valor total da NF-e !", MsgBoxStyle.Information, "Aviso !")

            If dgvpisquisa.RowCount = 1 Then
                dgvpisquisa.Focus()
            End If
        End If
    End Sub

    Private Sub txtvlrnf_LostFocus(sender As Object, e As EventArgs) Handles txtvlrnf.LostFocus
        If txtvlrnf.Text <> "" Then
            txtvlrnf.Text = Format(CDec(txtvlrnf.Text), "#,##0.00")
        Else
            txtvlrnf.Text = "0,00"
        End If
    End Sub

    Private Sub txtvlrnf_TextChanged(sender As Object, e As EventArgs) Handles txtvlrnf.TextChanged

    End Sub

    Private Sub dgvpisquisa_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpisquisa.CellContentClick

    End Sub

    Private Sub txtnumero_TextChanged(sender As Object, e As EventArgs) Handles txtnumero.TextChanged

    End Sub
End Class
