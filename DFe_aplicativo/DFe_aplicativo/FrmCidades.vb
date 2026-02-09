Imports System.Data
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.IO
Imports Newtonsoft.Json
Imports System.Web.Script.Serialization
Imports System.IO.Compression
Imports System.Text

Public Class FrmCidades

    Private Sub listarCidade()
        Dim sql As String

        Try

            If txtfiltro.Text = "" Then
                sql = "SELECT * FROM municipio"
            Else
                sql = "SELECT * FROM municipio WHERE NomeMunic LIKE '%" & txtfiltro.Text & "%'"
            End If

            conectar_mysqlDFe()
            Dim CommandSQL As MySqlCommand = New MySqlCommand(sql, oConn)
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(CommandSQL)
            Dim dt As DataTable = New DataTable
            da.Fill(dt)
            oConn.Close()

            For Each Row As DataRow In dt.Rows
                dgvcidade.Rows.Add(Row.Item("UF"), Row.Item("NomeMunic"), retorna_estado_nome(Row.Item("UF")), Row.Item("codigo_municipio"), Row.Item("cod_UF"))
            Next Row
            lbltotalregistro.Text = dgvcidade.RowCount
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso !")
        Finally
            oConn.Close()
        End Try

    End Sub
    Private Sub listaCidadeFiltro()

        Try

            Dim sql = "SELECT * FROM municipio WHERE NomeMunic LIKE '%" & txtfiltro.Text & "%'"
            conectar_mysqlDFe()
            Dim CommandSQL As MySqlCommand = New MySqlCommand(sql, oConn)
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(CommandSQL)
            Dim dt As DataTable = New DataTable
            da.Fill(dt)
            oConn.Close()

            dgvcidade.Rows.Clear()
            For Each Row As DataRow In dt.Rows
                dgvcidade.Rows.Add(Row.Item("UF"), Row.Item("NomeMunic"), Row.Item("NomeUF"), Row.Item("codigo_municipio"), Row.Item("cod_UF"))
            Next Row
            lbltotalregistro.Text = dgvcidade.RowCount

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso !")
        Finally
            oConn.Close()
        End Try

    End Sub

    Private Sub FrmCidades_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Dispose()
        End Select
    End Sub

    Private Sub FrmCidades_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If (e.KeyChar = Chr(13)) Then
            dgvcidade.Focus()
        End If
    End Sub

    Private Sub FrmCidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvcidade_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvcidade.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtfiltro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtfiltro.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            listaCidadeFiltro()
        End If
    End Sub

    Private Sub dgvcidade_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvcidade.KeyPress

        If Me.Text = "Localizar Cidade do Destinatário" Then
            '  FrmDestinatario.txtcidade.Text = dgvcidade.CurrentRow.Cells(1).Value
            '  FrmDestinatario.txtcodMunicipio.Text = dgvcidade.CurrentRow.Cells(3).Value
            '  FrmDestinatario.txtcodUF.Text = dgvcidade.CurrentRow.Cells(4).Value
            '  FrmDestinatario.txtuf.Text = dgvcidade.CurrentRow.Cells(2).Value

        Else

            FrmEmpresa.txtcidade.Text = dgvcidade.CurrentRow.Cells(1).Value
            FrmEmpresa.txtuf.Text = dgvcidade.CurrentRow.Cells(0).Value
            FrmEmpresa.txtcodMunicipio.Text = dgvcidade.CurrentRow.Cells(3).Value
            FrmEmpresa.txtcodUF.Text = dgvcidade.CurrentRow.Cells(4).Value

        End If

        Me.Close()

    End Sub

    Public Function retorna_estado_nome(ByVal uf As String) As String
        Dim retorno As String

        If uf = "AC" Then
            retorno = "Acre"
        ElseIf uf = "RO" Then
            retorno = "Rondônia"
        ElseIf uf = "AM" Then
            retorno = "Amazonas"
        ElseIf uf = "RR" Then
            retorno = "Roraima"
        ElseIf uf = "PA" Then
            retorno = "Pará"
        ElseIf uf = "AP" Then
            retorno = "Amapá"
        ElseIf uf = "TO" Then
            retorno = "Tocantins"


        ElseIf uf = "MA" Then
            retorno = "Maranhão"
        ElseIf uf = "PI" Then
            retorno = "Piauí"
        ElseIf uf = "CE" Then
            retorno = "Ceará"
        ElseIf uf = "RN" Then
            retorno = "Rio Grande do Norte"
        ElseIf uf = "PB" Then
            retorno = "Paraíba"
        ElseIf uf = "PE" Then
            retorno = "Pernambuco"
        ElseIf uf = "AL" Then
            retorno = "Alagoas"
        ElseIf uf = "SE" Then
            retorno = "Sergipe"
        ElseIf uf = "BA" Then
            retorno = "Bahia"



        ElseIf uf = "MG" Then
            retorno = "Minas Gerais"
        ElseIf uf = "ES" Then
            retorno = "Espírito Santo"
        ElseIf uf = "RJ" Then
            retorno = "Rio de Janeiro"
        ElseIf uf = "SP" Then
            retorno = "São Paulo"


        ElseIf uf = "PR" Then
            retorno = "Paraná"
        ElseIf uf = "SC" Then
            retorno = "Santa Catarina"
        ElseIf uf = "RS" Then
            retorno = "Rio Grande do Sul"



        ElseIf uf = "MS" Then
            retorno = "Mato Grosso do Sul"
        ElseIf uf = "MT" Then
            retorno = "Mato Grosso"
        ElseIf uf = "GO" Then
            retorno = "Goiás"
        ElseIf uf = "DF" Then
            retorno = "Distrito Federal"
        End If

        Return retorno

    End Function

    Public Function GetUrl_cidade(ByVal Url As String) As String
        Dim Http As HttpWebRequest = WebRequest.Create(Url)
        Dim ret As Dictionary(Of String, String) = New Dictionary(Of String, String)

        Using WebResponse As HttpWebResponse = Http.GetResponse()

            Dim responseStream As Stream = WebResponse.GetResponseStream()

            If (WebResponse.ContentEncoding.ToLower().Contains("gzip")) Then
                responseStream = New GZipStream(responseStream, CompressionMode.Decompress)
            ElseIf (WebResponse.ContentEncoding.ToLower().Contains("deflate")) Then
                responseStream = New DeflateStream(responseStream, CompressionMode.Decompress)
            End If

            Dim reader As StreamReader = New StreamReader(responseStream, Encoding.UTF8)

            Dim html As String = reader.ReadToEnd()

            responseStream.Close()

            Dim jss As New JavaScriptSerializer()
            ' ret = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(json)
            Dim dict As Dictionary(Of String, Object) = CType(jss.DeserializeObject(html), Dictionary(Of String, Object))


            Return html
        End Using

    End Function
   
    Public Function GetUrl(ByVal Url As String, ByVal PostData As String, ByVal GZip As Boolean) As String
        Dim Http As HttpWebRequest = WebRequest.Create(Url)

        If GZip = True Then
            Http.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate")
        End If

        If Not String.IsNullOrEmpty(PostData) Then
            Http.Method = "POST"
            Dim lbPostBuffer As Byte() = Encoding.Default.GetBytes(PostData)

            Http.ContentLength = lbPostBuffer.Length

            Using PostStream As Stream = Http.GetRequestStream()
                PostStream.Write(lbPostBuffer, 0, lbPostBuffer.Length)
            End Using
        End If

        Using WebResponse As HttpWebResponse = Http.GetResponse()

            Dim responseStream As Stream = WebResponse.GetResponseStream()

            If (WebResponse.ContentEncoding.ToLower().Contains("gzip")) Then
                responseStream = New GZipStream(responseStream, CompressionMode.Decompress)
            ElseIf (WebResponse.ContentEncoding.ToLower().Contains("deflate")) Then
                responseStream = New DeflateStream(responseStream, CompressionMode.Decompress)
            End If

            Dim reader As StreamReader = New StreamReader(responseStream, Encoding.UTF8)

            Dim html As String = reader.ReadToEnd()

            responseStream.Close()

            Return html
        End Using

    End Function
    Private Sub pesquisar_estado(ByVal cod As String)
        Dim dict As Object

        Dim jss As New JavaScriptSerializer()
        dict = jss.Deserialize(Of List(Of Object))(GetUrl("https://servicodados.ibge.gov.br/api/v1/localidades/estados/" & cod & "/municipios", String.Empty, True))

        For Each item As Object In dict

            dgvcidade.Rows.Add(item("microrregiao")("mesorregiao")("UF")("sigla"), item("nome"), item("microrregiao")("mesorregiao")("UF")("nome"), item("id"), item("microrregiao")("mesorregiao")("UF")("id"))

        Next

        lbltotalregistro.Text = dgvcidade.RowCount

        salvar()
    End Sub

    Private Sub pesquisar_cid(ByVal cidade As String)
        Dim html As String

        html = GetUrl_cidade("https://servicodados.ibge.gov.br/api/v1/localidades/municipios/" & cidade & "")

        Dim jss As New JavaScriptSerializer()
        ' ret = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(json)
        Dim dict As Dictionary(Of String, Object) = CType(jss.DeserializeObject(html), Dictionary(Of String, Object))
        dgvcidade.Rows.Clear()
        dgvcidade.Rows.Add(dict("microrregiao")("mesorregiao")("UF")("sigla"), dict("nome"), dict("microrregiao")("mesorregiao")("UF")("nome"), dict("id"), dict("microrregiao")("mesorregiao")("UF")("id"))

        lbltotalregistro.Text = dgvcidade.RowCount

        ' salvar()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        pesquisar_estado(ComboBox1.Text.Substring(0, 2))
    End Sub

    Private Sub salvar()


        For Each row As DataGridViewRow In dgvcidade.Rows
            Dim ret As Integer = verificar_regexiste("Select * from municipio where codigo_municipio = '" & row.Cells("cod_municipio").Value & "'")
            Dim sql As String

            If ret = 0 Then
                sql = "INSERT INTO municipio (NomeMunic, NomeUF, UF, cod_UF, codigo_municipio) VALUES (@NomeMunic, @NomeUF, @UF, @cod_UF, @codigo_municipio)"
            Else
                sql = "UPDATE municipio SET NomeMunic = @NomeMunic, NomeUF = @NomeUF, UF = @UF, cod_UF = @cod_UF, codigo_municipio = @codigo_municipio"
            End If

            conectar_mysqlDFe()
            Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)

            insertSQL.Parameters.Add(New MySqlParameter("NomeMunic", row.Cells("NomeMunic").Value))
            insertSQL.Parameters.Add(New MySqlParameter("NomeUF", row.Cells("NomeUF").Value))
            insertSQL.Parameters.Add(New MySqlParameter("UF", row.Cells("uf_grid").Value))
            insertSQL.Parameters.Add(New MySqlParameter("cod_UF", row.Cells("coduf").Value))
            insertSQL.Parameters.Add(New MySqlParameter("codigo_municipio", row.Cells("cod_municipio").Value))



            insertSQL.ExecuteNonQuery()

            oConn.Close()
        Next
    End Sub

    Private Sub txtfiltro_TextChanged(sender As Object, e As EventArgs) Handles txtfiltro.TextChanged

    End Sub

    Private Sub mskcep_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskcep.KeyPress
        If (e.KeyChar = Chr(13)) Then
           
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

                salvar()
            Catch ex As Exception
                MsgBox("Cidade não localizada !", MsgBoxStyle.Exclamation, "Aviso !")
            End Try

        End If


    End Sub


 
    Private Sub mskcep_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskcep.MaskInputRejected

    End Sub
End Class