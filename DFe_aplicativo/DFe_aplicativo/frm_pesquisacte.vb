Imports System.Text
Imports System.Data.SQLite
Imports System.Xml
Imports MySql.Data.MySqlClient

Public Class frm_pesquisacte
    Dim xmldoc As New XmlDocument()
    Private Sub frm_pesquisacte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub pesquisar()
        Dim bytePicData() As Byte
        Dim xml As String, status As String
        Dim cont As Integer
        Dim encText As New System.Text.UTF8Encoding()
        Dim stringBuilder As StringBuilder = New StringBuilder()
        stringBuilder.Append("Select * from CTe ")

        stringBuilder.Append("where Nome_emi like '%" & txtnome.Text & "%'")

        dgvcte.Rows.Clear()

        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand

        SQLcommand = oConn.CreateCommand

        SQLcommand.CommandText = stringBuilder.ToString

        dr = SQLcommand.ExecuteReader()



        While (dr.Read())
            If dr("xml_cte").ToString <> "" Then
                bytePicData = dr("xml_cte")
                xml = Encoding.UTF8.GetString(bytePicData)
                status = "XML Sim"
          
            End If

            dgvcte.Rows.Add(MascSTR(dr("Cnpj_emi"), "##.###.###/####-##"), dr("Nome_emi"), Convert.ToDateTime(dr("Data")).ToString("dd/MM/yyyy"), dr("Valor_cte"), dr("Chave_cte"), encText.GetString(dr("xml_cte")), dr("Tomador"), status, xml)
            cont += 1
        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()

        MsgBox("Pesquisa Realizada, Total registros encontrados: " & cont, MsgBoxStyle.Information, "Atenção !")

    End Sub

    Private Sub pesquisar_tomador()
        Dim cont As Integer
        Dim encText As New System.Text.UTF8Encoding()
        Dim stringBuilder As StringBuilder = New StringBuilder()
        stringBuilder.Append("Select * from CTe ")

        stringBuilder.Append("where Tomador = '" & cbotomar.Text.Substring(0, 1) & "'")

        dgvcte.Rows.Clear()

        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand

        SQLcommand = oConn.CreateCommand

        SQLcommand.CommandText = stringBuilder.ToString

        dr = SQLcommand.ExecuteReader()



        While (dr.Read())
            dgvcte.Rows.Add(MascSTR(dr("Cnpj_emi"), "##.###.###/####-##"), dr("Nome_emi"), Convert.ToDateTime(dr("Data")).ToString("dd/MM/yyyy"), dr("Valor_cte"), dr("Chave_cte"), encText.GetString(dr("xml_cte")), dr("Tomador"))
            cont += 1
        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()

        MsgBox("Pesquisa Realizada, Total registros encontrados: " & cont, MsgBoxStyle.Information, "Atenção !")

    End Sub

    Private Sub pesquisar_cnpj()
        Dim bytePicData() As Byte
        Dim xml As String, status As String
        Dim cont As Integer
        Dim encText As New System.Text.UTF8Encoding()
        Dim stringBuilder As StringBuilder = New StringBuilder()
        stringBuilder.Append("Select * from CTe ")

        stringBuilder.Append("where Cnpj_emi = '" & mskcnpj.Text & "'")

        dgvcte.Rows.Clear()

        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand

        SQLcommand = oConn.CreateCommand

        SQLcommand.CommandText = stringBuilder.ToString

        dr = SQLcommand.ExecuteReader()



        While (dr.Read())
            If dr("xml_cte").ToString <> "" Then
                bytePicData = dr("xml_cte")
                xml = Encoding.UTF8.GetString(bytePicData)
                status = "XML Sim"

            End If

            dgvcte.Rows.Add(MascSTR(dr("Cnpj_emi"), "##.###.###/####-##"), dr("Nome_emi"), Convert.ToDateTime(dr("Data")).ToString("dd/MM/yyyy"), dr("Valor_cte"), dr("Chave_cte"), encText.GetString(dr("xml_cte")), dr("Tomador"), status, xml)
            cont += 1
        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()

        MsgBox("Pesquisa Realizada, Total registros encontrados: " & cont, MsgBoxStyle.Information, "Atenção !")

    End Sub
    Private Sub txtnome_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnome.KeyPress
        If (e.KeyChar = Chr(13)) Then
            pesquisar()
        End If
    End Sub


    Private Sub DownloadXMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadXMLToolStripMenuItem.Click
        Dim dialo_salve As New SaveFileDialog
        dialo_salve.Filter = "Arquivo XML (.xml)|*.xml"
        dialo_salve.FileName = "CTe-" & dgvcte.CurrentRow.Cells("chave_cte").Value

        If dialo_salve.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim Xml_danfe As XmlDocument = New XmlDocument
            Xml_danfe.LoadXml(dgvcte.CurrentRow.Cells("xml_cte").Value)
            Xml_danfe.Save(dialo_salve.FileName)


            MsgBox("XML salvo com Sucesso !", MsgBoxStyle.Information, "Aviso !")

        End If
    End Sub

    Private Sub cbotomar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbotomar.KeyPress
        If (e.KeyChar = Chr(13)) Then
            If cbotomar.Text = "" Then
                Exit Sub
            End If
            pesquisar_tomador()
        End If
    End Sub

    Private Sub cbotomar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbotomar.SelectedIndexChanged

    End Sub

    Private Sub dgvcte_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvcte.CellContentClick
        If dgvcte.CurrentCell.Value = "XML Sim" Then
            xmldoc.LoadXml(dgvcte.CurrentRow.Cells("xml_arq").Value)
            Dim saveFileDialog1 As New SaveFileDialog
            saveFileDialog1.FileName = "CTe-" & dgvcte.CurrentRow.Cells("chave_cte").Value + ".xml"

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                xmldoc.Save(saveFileDialog1.FileName)
                MsgBox("Arquivo XML CT-e salvo na pasta Informada !", MsgBoxStyle.Information, "Aviso !")
            End If

        End If
    End Sub

    Private Sub txtnome_TextChanged(sender As Object, e As EventArgs) Handles txtnome.TextChanged

    End Sub

    Private Sub mskcnpj_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskcnpj.KeyPress
        If (e.KeyChar = Chr(13)) Then
            pesquisar_cnpj()
        End If
    End Sub

    Private Sub mskcnpj_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskcnpj.MaskInputRejected

    End Sub
End Class