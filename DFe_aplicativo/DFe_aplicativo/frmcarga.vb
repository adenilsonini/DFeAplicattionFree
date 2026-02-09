Imports System.Text
Imports Newtonsoft.Json
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmcarga

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim arquivo As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim ret As String

        If chkult.Checked = False Then
            If File.Exists(Application.StartupPath & "\TX\carga.cac") = False Then
                MessageBox.Show("Não existem modificações para serem envia para o PDV !", "Aviso !", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If


        Try

            If chkult.Checked = True Then
                Using streamReader = New StreamReader(Application.StartupPath & "\TX\carga_ult.cac")
                    arquivo.Add("conteudo", streamReader.ReadToEnd)
                End Using
            Else
                Using streamReader = New StreamReader(Application.StartupPath & "\TX\carga.cac")
                    arquivo.Add("conteudo", streamReader.ReadToEnd)
                End Using
            End If


            For Each row As DataGridViewRow In dgvcaixa.Rows
                If row.Cells(0).Value = True Then
                    row.Cells("resp").Value = "Enviando carga caixa: " & row.Cells(1).Value & ", aguarde ..."
                    dgvcaixa.Refresh()

                    ret = processarWS_host(arquivo, row.Cells("ip").Value)

                    row.Cells("resp").Value = ret
                End If
            Next
            '  Dim thread As Thread = New Thread(AddressOf processarWS)
            '  thread.Start(CObj(arquivo))

            If ret = "ok" Then
                MsgBox("carga enviada !", MsgBoxStyle.Information, "Aviso !")
                File.Delete(Application.StartupPath & "\TX\carga_ult.cac")
                My.Computer.FileSystem.RenameFile(Application.StartupPath & "\TX\carga.cac", "carga_ult.cac")
            Else
                MsgBox(ret, MsgBoxStyle.Exclamation, "Aviso !")
            End If

            '   lblinfo.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Aviso !")
            ' lblinfo.Visible = False
        End Try
    End Sub

    Public Function processarWS_host(ByVal data As Dictionary(Of String, String), ByVal host As String) As String


        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\WS_Cofing.ini")

        ' Dim str As String = "http://localhost:8900"
        Dim str As String = "http://" & host & ":8900"

        Dim bytes As Byte() = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(CObj(data)))
        Dim uriString As String = String.Format("{0}/api/Processar_carga/processar", CObj(str))
        Dim uri As Uri = New Uri(uriString)
        '   mdlGeral.CriarArquivoLog("Enviar arquivo para URL: " & uriString, "", "", False, False, False)
        Dim jsonDataBytes As Byte() = bytes
        Dim ret As String = SendRequest(uri, jsonDataBytes, "")
        '  mdlGeral.CriarLog("Retorno WSLinear: " & Left1, NameOf(clsNFCe), NameOf(processarWS), False, False, False)

        If ret Is Nothing Then
            ret = "Sem retorno do Host local !"
        Else
            Return ret
        End If

    End Function

    Private Sub frmcarga_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carregar_caixa()
    End Sub

    Private Sub carregar_caixa()
        dgvcaixa.Rows.Clear()

        conectar_mysqlDFe()
        Dim SQLcommand2 As MySqlCommand
        SQLcommand2 = oConn.CreateCommand
        SQLcommand2.CommandText = "select * from caixa_cad"
        dr = SQLcommand2.ExecuteReader()

        While (dr.Read())
            dgvcaixa.Rows.Add(False, dr("caixa"), dr("ip"))
        End While

        dr.Close()
        SQLcommand2.Dispose()
        oConn.Close()

        For Each row As DataGridViewRow In dgvcaixa.Rows
            row.Cells(0).Value = True
        Next
        
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ipcaixa As String = InputBox("Informe o IP do Caixa: " & dgvcaixa.CurrentRow.Cells(1).Value)

        If ipcaixa.Length < 9 Then
            MessageBox.Show("IP Caixa Invalido !", "Aviso !", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        conectar_mysqlDFe()
        Dim SQLcommand2 As MySqlCommand
        SQLcommand2 = oConn.CreateCommand
        SQLcommand2.CommandText = "update caixa_cad set ip = '" & ipcaixa & "' where caixa = '" & dgvcaixa.CurrentRow.Cells(1).Value & "'"
        SQLcommand2.ExecuteNonQuery()
        SQLcommand2.Dispose()
        oConn.Close()

        MessageBox.Show("IP Caixa Alterado com Sucesso !", "Aviso !", MessageBoxButtons.OK, MessageBoxIcon.Information)

        carregar_caixa()
    End Sub
End Class