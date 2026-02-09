Imports System.Xml
Public Class frmretdowload
    Public recupera As Boolean
    Dim rs As New ADODB.Recordset
    Dim parametro As Boolean
    Private Sub dgvarquivos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvarquivos.CellContentClick
        Dim xmldoc = New XmlDocument()
        If dgvarquivos.CurrentCell.ColumnIndex = "2" Then
            SaveFileDialog1.FileName = dgvarquivos.CurrentRow.Cells(0).Value + ".xml"

            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & dgvarquivos.CurrentRow.Cells(3).Value & "")
                xmldoc.Save(SaveFileDialog1.FileName)
                MsgBox("XML Movido para Pasta Selecionada !", MsgBoxStyle.Information, "Aviso !")
                dgvarquivos.CurrentRow.Cells(2).Value = "Salvo"
            End If

        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim xmldoc = New XmlDocument()

        For i As Integer = 0 To dgvarquivos.Rows.Count - 1
            If dgvarquivos.Rows.Item(i).Cells(3).Value <> "" Then
                xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & dgvarquivos.Rows.Item(i).Cells(3).Value & "")
                xmldoc.Save(txtcaminho.Text + "\" + dgvarquivos.Rows.Item(i).Cells(0).Value + ".xml")
                dgvarquivos.Rows.Item(i).Cells(2).Value = "Salvo"
            End If
        Next

        MsgBox("Arquivos salvo com Sucesso !", MsgBoxStyle.Information, "Aviso !")
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtcaminho.Text = FolderBrowserDialog1.SelectedPath
            salvar()
        End If
    End Sub

    Private Sub salvar()
        Dim encText As New System.Text.UTF8Encoding()
        Dim btText() As Byte

        conectar_DFe()

        For i As Integer = 0 To dgvarquivos.Rows.Count - 1
            rs.Open("select * from NFe_consultadaDFe where chave_nfe like '" & dgvarquivos.Rows.Item(i).Cells(0).Value & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

            btText = encText.GetBytes("<?xml version=""1.0"" encoding=""utf-8""?>" & dgvarquivos.Rows.Item(i).Cells(3).Value & "")
            rs.Fields("XML_NFe").Value = btText
            rs.Fields("XML").Value = True

            rs.Update()
            rs.Close()
        Next

        cn_DFe.Close()
    End Sub

    Private Sub pesquisa()
        conectar_DFe()
        rs.Open("select * from NSU where Serial_cert like '" & nfecer & "'", cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        txtcaminho.Text = rs.Fields("caminhodownload").Value.ToString
        cn_DFe.Close()
    End Sub


    Private Sub frmretdowload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        salvar()
    End Sub
End Class