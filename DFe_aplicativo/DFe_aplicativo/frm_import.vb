Imports System.Text
Imports MySql.Data.MySqlClient
Imports System.Xml

Public Class frm_import
    Dim xmldoc As New XmlDocument()
    Dim rs As New ADODB.Recordset
    Private Sub carregar()

        dgvimport.Rows.Clear()
        dgvsite.Rows.Clear()


        Dim bytePicData() As Byte
        conectar_mysql_DFe2()
        rs.Open("select * from nfe where year(Data_emi) = " & txtcont.Text & " and Tipo_nfe <> '0-NFe Entrada' ", conexao.cn_DFe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)


        Dim xmldisponivel As String, visualizar As String
        Do While rs.EOF = False
            Try
                bytePicData = rs.Fields("xml_nfe").Value
            Catch ex As Exception

            End Try

            dgvimport.Rows.Add(rs.Fields("chave_nfe").Value, Encoding.UTF8.GetString(bytePicData), rs.Fields("recibo").Value, _
                               rs.Fields("data_recibo").Value.ToString, rs.Fields("recibo_lanc").Value.ToString, rs.Fields("obs").Value.ToString, _
                               rs.Fields("nprot_manif").Value.ToString, rs.Fields("cStat").Value, rs.Fields("xmot_manif").Value.ToString)
            rs.MoveNext()
        Loop

        cn_DFe.Close()

        Try
            conectar_mysqlDFe_site()

            Dim SQLcommand As MySqlCommand
            SQLcommand = oConnS.CreateCommand
            SQLcommand.CommandText = "select * from nfe where year(Data_emi) = " & txtcont.Text & ""
            dr = SQLcommand.ExecuteReader()
            '  SQLcommand.CommandTimeout = 0
            While (dr.Read())

                If dr("xml_nfe").ToString <> "" Then
                    bytePicData = dr("xml_nfe")
                    dgvsite.Rows.Add(dr("chave_nfe"), Encoding.UTF8.GetString(bytePicData))
                End If


            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso !")
        End Try

        MsgBox("registro encontrador site !" & dgvsite.Rows.Count)

        MsgBox("registro encontrador !" & dgvimport.Rows.Count)


    End Sub

    Private Sub importar()
        Dim cont As Integer
        conectar_mysqlDFe()
        bar1.Maximum = dgvimport.Rows.Count

        For Each row As DataGridViewRow In Me.dgvimport.Rows
            cont += 1

            If row.Cells(1).Value <> "" Then

                If cont >= txtcont.Text Then

                    Try
                        importar_xml_banco(row.Cells(1).Value, cont, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, _
                                                                             row.Cells(6).Value, row.Cells(7).Value, row.Cells(8).Value)
                    Catch ex As Exception
                        dgverro.Rows.Add("erro ao importar o xml", row.Cells(1).Value)
                    End Try

                End If

            End If

            bar1.Value += 1
            Application.DoEvents()
        Next


        oConn.Close()

        MsgBox("processo concluido !")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '   Try
        importar()
        '  Catch ex As Exception
        '     dgvimport.Rows.Clear()
        '     carregar(True)
        '    importar()
        ' End Try

        MsgBox("processo concluido !")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        carregar()
    End Sub

    Private Sub frm_import_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmdfe2.Tws.Dispose()
    End Sub


    Private Sub importar_xml_banco(ByVal xml As String, ByVal total As Integer, ByVal recibo As String, ByVal data_recibo As String, ByVal recibo_lanc As String, ByVal obs As String, ByVal nprot_manif As String, ByVal cStat As String, ByVal xmot_manif As String)

        Dim chavevalida As String
        Dim dataemi As Date
        Dim nome As String, vnf As String, ie As String, tpnf As String, cnpj_emi As String, data_auto As String, protocolo As String
        Dim dialogo As New OpenFileDialog


        ''''''''''''''''Abre o arquivo xml para validacao deste''''''''''''''''''''
        xmldoc.LoadXml(xml)

        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode

        xmllist = xmldoc.GetElementsByTagName("infNFe")

        For Each xmlnode In xmllist
            chavevalida = xmlnode.Attributes.ItemOf("Id").InnerText.Substring(3, 44)

            If chavevalida.Substring(20, 2) = "65" Then
                '   MsgBox("Importação exclusiva para NF-e" + vbCrLf + "Operação cancelada !", MsgBoxStyle.Exclamation, "Atenção !")
                Exit Sub
            End If

        Next





        '''''''''''''''''''''''''''''''''''''''Rotina para captura os dados resumo da NFe"""""""""""""""""""""""""""'
        Try

            xmllist = xmldoc.GetElementsByTagName("infNFe")

            For Each xmlnode In xmllist

                If Not xmlnode("ide")("dhEmi") Is Nothing Then
                    dataemi = xmlnode("ide")("dhEmi").InnerText
                End If
                If Not xmlnode("ide")("dEmi") Is Nothing Then
                    dataemi = xmlnode("ide")("dEmi").InnerText
                End If

                If Not xmlnode("emit")("xNome") Is Nothing Then
                    nome = xmlnode("emit")("xNome").InnerText
                End If

                If Not xmlnode("dest")("CNPJ") Is Nothing Then
                    cnpj_emi = xmlnode("dest")("CNPJ").InnerText
                End If
                If Not xmlnode("dest")("CPF") Is Nothing Then
                    cnpj_emi = xmlnode("dest")("CPF").InnerText
                End If

                If Not xmlnode("total")("ICMSTot")("vNF") Is Nothing Then
                    vnf = xmlnode("total")("ICMSTot")("vNF").InnerText
                End If

                If Not xmlnode("emit")("IE") Is Nothing Then
                    ie = xmlnode("emit")("IE").InnerText
                End If

                If Not xmlnode("ide")("tpNF") Is Nothing Then

                    If xmlnode("ide")("tpNF").InnerText = "0" Then
                        tpnf = "0-NFe Entrada"
                    End If
                    If xmlnode("ide")("tpNF").InnerText = "1" Then
                        tpnf = "1-NFe Saida"
                    End If

                End If

            Next


            xmllist = xmldoc.GetElementsByTagName("protNFe")

            For Each xmlnode In xmllist

                If Not xmlnode("infProt")("dhRecbto") Is Nothing Then
                    data_auto = Convert.ToDateTime(xmlnode("infProt")("dhRecbto").InnerText).ToString("yyyy-MM-dd HH:mm:ss")
                End If
                If Not xmlnode("infProt")("nProt") Is Nothing Then
                    protocolo = xmlnode("infProt")("nProt").InnerText
                End If

                If Not xmlnode("infProt")("chNFe") Is Nothing Then
                    chavevalida = xmlnode("infProt")("chNFe").InnerText
                End If


            Next
        Catch ex As Exception

        End Try



        ''''''''''''''salvar no site'''''''''''''
        Try
            conectar_mysqlDFe_site()

            Dim insertSQL22 As MySqlCommand

            insertSQL22 = New MySqlCommand("INSERT INTO nfe (Chave_nfe, Nome_emi, Cnpj_emi, Ie_emi, Valor_nfe, Data_aut, Status_nfe, Tipo_nfe, xml_nfe, Data_emi, Numero_nfe, recibo, data_recibo, recibo_lanc, obs, nprot_manif, cStat, xmot_manif) VALUES (@Chave_nfe, @Nome_emi, @Cnpj_emi, @Ie_emi, @Valor_nfe, @Data_aut, @Status_nfe, @Tipo_nfe, @xml_nfe, @Data_emi, @Numero_nfe, @recibo, @data_recibo, @recibo_lanc, @obs, @nprot_manif, @cStat, @xmot_manif)", oConnS)

            insertSQL22.Parameters.Add(New MySqlParameter("Chave_nfe", chavevalida))
            insertSQL22.Parameters.Add(New MySqlParameter("Nome_emi", nome))
            insertSQL22.Parameters.Add(New MySqlParameter("Cnpj_emi", cnpj_emi))
            insertSQL22.Parameters.Add(New MySqlParameter("Ie_emi", ie))
            insertSQL22.Parameters.Add(New MySqlParameter("Valor_nfe", vnf))
            insertSQL22.Parameters.Add(New MySqlParameter("Data_aut", data_auto))
            insertSQL22.Parameters.Add(New MySqlParameter("Status_nfe", "NF-e autorizada"))
            insertSQL22.Parameters.Add(New MySqlParameter("Tipo_nfe", tpnf))
            Dim encText22 As New System.Text.UTF8Encoding()
            insertSQL22.Parameters.Add(New MySqlParameter("xml_nfe", encText22.GetBytes(xmldoc.OuterXml)))
            insertSQL22.Parameters.Add(New MySqlParameter("Data_emi", dataemi.ToString("yyyy-MM-dd")))
            insertSQL22.Parameters.Add(New MySqlParameter("Numero_nfe", chavevalida.Substring(25, 9)))

            insertSQL22.Parameters.Add(New MySqlParameter("recibo", recibo))
            insertSQL22.Parameters.Add(New MySqlParameter("data_recibo", data_recibo))
            insertSQL22.Parameters.Add(New MySqlParameter("recibo_lanc", recibo_lanc))

            insertSQL22.Parameters.Add(New MySqlParameter("obs", obs))

            insertSQL22.Parameters.Add(New MySqlParameter("nprot_manif", nprot_manif))
            insertSQL22.Parameters.Add(New MySqlParameter("cStat", cStat))
            insertSQL22.Parameters.Add(New MySqlParameter("xmot_manif", xmot_manif))
            insertSQL22.ExecuteNonQuery()

            oConnS.Close()
        Catch ex As Exception
            dgverro.Rows.Add(ex.Message, chavevalida)
        End Try

        lblinfo.Text = "Total de arquivos: " & dgvimport.Rows.Count & ", Importado: " & total

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Me.Height = 495 Then
            Me.Height = 335
        Else
            Me.Height = 495
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        For Each row As DataGridViewRow In Me.dgvimport.Rows
            Dim ret As String = getDataGridViewIndex(row.Cells(0).Value)

            If ret = "RR" Then
                dgvdi.Rows.Add(row.Cells(0).Value, row.Cells(1).Value)
            End If
        Next

        MsgBox("Processo realizado !" & dgvdi.Rows.Count)
    End Sub

    Private Function getDataGridViewIndex(ByVal id As String) As String

        Dim r As String = "RR"

        For Each row As DataGridViewRow In Me.dgvsite.Rows

            If Not row.IsNewRow Then
                If row.Cells(0).Value = id Then
                    Return row.Index
                End If
            End If

        Next

        Return r

    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Using f As New IO.StreamWriter("C:\Users\supermercado doka\Desktop\teste\nfe-" & txtcont.Text & ".txt", True)


            Dim col As String = ""

            Dim row As String = ""
            Dim i As Integer = 0
            For Each r As DataGridViewRow In dgvdi.Rows

                f.WriteLine(r.Cells(0).Value)


            Next



            MessageBox.Show("Arquivo exportado")

            MsgBox("Caminho exportacao: C:\Users\supermercado doka\Desktop\teste\nfe.txt")
        End Using

        dgvdi.Rows.Clear()
    End Sub
End Class