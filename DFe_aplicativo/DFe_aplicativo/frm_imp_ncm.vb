Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frm_imp_ncm
    Dim nomeArquivo As String = ""
    Private Sub btnArquivo_Click(sender As Object, e As EventArgs) Handles btnArquivo.Click
        ' Try

        Dim AbrirComo As OpenFileDialog = New OpenFileDialog()
        Dim caminho As DialogResult
        AbrirComo.Title = "Abrir como"
        AbrirComo.InitialDirectory = "C:\Dados"
        AbrirComo.FileName = "Nome Arquivo"
        AbrirComo.Filter = "Arquivos .csv (*.csv)|*.csv|arquivo .txt (*.txt*)|*.txt*"

        nomeArquivo = AbrirComo.FileName

        If nomeArquivo = Nothing Then
            MessageBox.Show("Arquivo Inválido", "Arquivo", MessageBoxButtons.OK)
        Else

            If AbrirComo.ShowDialog = DialogResult.OK Then

                txtArquivo.Text = AbrirComo.FileName
                txtArquivo.Refresh()
                If optncm.Checked = True Then
                    GetDataTable_ncm(txtArquivo.Text, ";")
                Else

                    If Path.GetExtension(txtArquivo.Text) = ".csv" Then
                        conectar_mysqlDFe()
                        Dim SQL2 As MySqlCommand = New MySqlCommand("delete from cest", oConn)
                        SQL2.ExecuteNonQuery()
                        oConn.Close()
                        GetDataTable_cest(txtArquivo.Text, ";")
                    Else
                        GetDataTable_cest(txtArquivo.Text, "|")
                    End If

                End If
                MsgBox("Arquivo Carregado com sucesso !", MsgBoxStyle.Information, "Aviso !")

            End If
            End If



    End Sub


    Private Sub GetDataTable_ncm(path As String, seperator As Char)
        Dim cont As Integer
        Dim dt As New DataTable()
        Dim aFile As New FileStream(path, FileMode.Open)

      

        Dim sql As String = "INSERT INTO ncm (codigo, ex, tipo, descricao, nacionalfederal, importadosfederal, estadual, municipal, vigenciainicio, vigenciafim, chave, versao, fonte) VALUES (@codigo, @ex, @tipo, @descricao, @nacionalfederal, @importadosfederal, @estadual, @municipal, @vigenciainicio, @vigenciafim, @chave, @versao, @fonte)"
        conectar_mysqlDFe()
        lblinfo.Visible = True

        Using sr As New StreamReader(aFile, System.Text.Encoding.[Default])


            Dim strLine As String = sr.ReadLine()
            Dim strArray As String() = strLine.Split(seperator)

            While sr.Peek() > -1
                cont += 1
                strLine = sr.ReadLine()
                strArray = strLine.Split(seperator)

                If strArray(0).ToString.Length = 8 Then
                    Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)
                    insertSQL.Parameters.Add(New MySqlParameter("codigo", strArray(0)))
                    insertSQL.Parameters.Add(New MySqlParameter("ex", strArray(1)))
                    insertSQL.Parameters.Add(New MySqlParameter("tipo", strArray(2)))
                    insertSQL.Parameters.Add(New MySqlParameter("descricao", strArray(3).ToString.Replace("""", "")))
                    insertSQL.Parameters.Add(New MySqlParameter("nacionalfederal", strArray(4)))
                    insertSQL.Parameters.Add(New MySqlParameter("importadosfederal", strArray(5)))
                    insertSQL.Parameters.Add(New MySqlParameter("estadual", strArray(6)))
                    insertSQL.Parameters.Add(New MySqlParameter("municipal", strArray(7)))
                    insertSQL.Parameters.Add(New MySqlParameter("vigenciainicio", Convert.ToDateTime(strArray(8)).ToString("yyyy-MM-dd")))

                    insertSQL.Parameters.Add(New MySqlParameter("vigenciafim", Convert.ToDateTime(strArray(8)).ToString("yyyy-MM-dd")))
                    insertSQL.Parameters.Add(New MySqlParameter("chave", strArray(10)))
                    insertSQL.Parameters.Add(New MySqlParameter("versao", strArray(11)))
                    insertSQL.Parameters.Add(New MySqlParameter("fonte", strArray(12)))
                    insertSQL.ExecuteNonQuery()

                    lblinfo.Text = "Salvando registro: " & cont & ", aguarde...."
                    lblinfo.Refresh()
                End If

            End While

        End Using
        oConn.Close()
        lblinfo.Text = "Processo concluido com sucesso !"

    End Sub
    Private Sub GetDataTable_cest(path As String, seperator As Char)
        Dim cont As Integer
        Dim data_ini As Date, data_fim As Date
        Dim sqlr As String
        Dim dt As New DataTable()
        Dim aFile As New FileStream(path, FileMode.Open)

        lblinfo.Visible = True

        Using sr As New StreamReader(aFile, System.Text.Encoding.[Default])


            Dim strLine As String = sr.ReadLine()
            Dim strArray As String() = strLine.Split(seperator)

            While sr.Peek() > -1

                cont += 1
                strLine = sr.ReadLine()
                strArray = strLine.Split(seperator)

                If strArray(0).ToString <> "" Then

                    If seperator = "|" Then

                        Dim ret As Integer = verificar_regexiste("Select * from cest where codigo = '" & strArray(0) & "'")

                        data_ini = strArray(2).ToString.Substring(0, 2) & "-" & strArray(2).ToString.Substring(2, 2) & "-" & strArray(2).ToString.Substring(4, 4)

                        If strArray(3) <> "" Then
                            data_fim = strArray(3).ToString.Substring(0, 2) & "-" & strArray(3).ToString.Substring(2, 2) & "-" & strArray(3).ToString.Substring(4, 4)
                        Else
                            data_fim = "01-01-9999"
                        End If


                        If ret = 0 Then

                            sqlr = "INSERT INTO cest (codigo, descricao, ncm, data_ini, data_fim) VALUES (@codigo, @descricao, @ncm, @data_ini, @data_fim)"
                            conectar_mysqlDFe()
                            Dim insertSQL As MySqlCommand = New MySqlCommand(sqlr, oConn)
                            insertSQL.Parameters.Add(New MySqlParameter("codigo", strArray(0)))
                            insertSQL.Parameters.Add(New MySqlParameter("descricao", strArray(1)))
                            insertSQL.Parameters.Add(New MySqlParameter("ncm", ""))
                            insertSQL.Parameters.Add(New MySqlParameter("data_ini", data_ini.ToString("yyyy-MM-dd")))
                            insertSQL.Parameters.Add(New MySqlParameter("data_fim", data_fim.ToString("yyyy-MM-dd")))
                            insertSQL.ExecuteNonQuery()
                            oConn.Close()


                        Else

                            sqlr = "update cest set descricao = '" & strArray(1) & "', data_ini = '" & data_ini.ToString("yyyy-MM-dd") & "', data_fim = '" & data_fim.ToString("yyyy-MM-dd") & "' where codigo = '" & strArray(0) & "'"

                            conectar_mysqlDFe()
                            Dim insertSQL As MySqlCommand = New MySqlCommand(sqlr, oConn)
                            insertSQL.ExecuteNonQuery()
                            oConn.Close()
                        End If





                        lblinfo.Text = "Importando RFB registros: " & cont & ", aguarde...."
                        lblinfo.Refresh()


                    Else

                        Dim sql As String = "INSERT INTO cest (codigo, descricao, ncm) VALUES (@codigo, @descricao, @ncm)"
                        conectar_mysqlDFe()
                        Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)
                        insertSQL.Parameters.Add(New MySqlParameter("codigo", strArray(0).ToString.PadLeft(7, "0")))
                        insertSQL.Parameters.Add(New MySqlParameter("descricao", strArray(4)))
                        insertSQL.Parameters.Add(New MySqlParameter("ncm", strArray(1).Replace(".", "")))
                        insertSQL.ExecuteNonQuery()

                        lblinfo.Text = "Importando registros: " & cont & ", aguarde...."
                        lblinfo.Refresh()
                        oConn.Close()

                    End If



                End If

            End While

        End Using

        lblinfo.Text = "Processo concluido com sucesso !"

    End Sub


    Private Sub frm_imp_ncm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class