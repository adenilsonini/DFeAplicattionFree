Imports System.IO
Imports System.Xml
Imports System.Text
Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.Web.Script.Serialization
Imports System.IO.Compression
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography.X509Certificates

Module Funcoes_sist
    Public certificado2 As New X509Certificate2
    Dim rs As New ADODB.Recordset
    Public vlrdifal As String


    Public Function cfe(ByVal chave_nfce As String, ByVal rv As String, ByVal xml As String, ByVal amb As String, ByVal caixa As String, ByVal xmot As String, ByVal cod_sit As String, ByVal nRec As String)
        Dim xmldoc = New XmlDocument()
        Dim nNF As String, serie As String, data_emi As String, valor_total As String, valor_desc As String, cnpj_dest As String, ind_pag As String, nprot As String, data_aut As String, vlr_icms As String
        Dim chv As String
        Dim ret2 As String

        Try

            nNF = chave_nfce.Substring(25, 9)

            If xml <> "" Then

                xmldoc.LoadXml(xml)

                Dim xmllist As System.Xml.XmlNodeList
                Dim xmlnode As XmlNode


                xmllist = xmldoc.GetElementsByTagName("ide")
                For Each xmlnode In xmllist
                    data_emi = Convert.ToDateTime(xmlnode("dhEmi").InnerText).ToString("yyyy-MM-dd HH:mm:ss")
                    serie = xmlnode("serie").InnerText
                Next

                xmllist = xmldoc.GetElementsByTagName("ICMSTot")
                For Each xmlnode In xmllist
                    valor_total = xmlnode("vNF").InnerText
                    valor_desc = xmlnode("vDesc").InnerText
                    vlr_icms = xmlnode("vICMS").InnerText
                Next

                xmllist = xmldoc.GetElementsByTagName("dest")
                For Each xmlnode In xmllist
                    cnpj_dest = xmlnode("CNPJ").InnerText
                Next


                xmllist = xmldoc.GetElementsByTagName("detPag")
                For Each xmlnode In xmllist
                    ind_pag = xmlnode("indPag").InnerText
                Next

                xmllist = xmldoc.GetElementsByTagName("infProt")
                For Each xmlnode In xmllist
                    nprot = xmlnode("nProt").InnerText
                    data_aut = Convert.ToDateTime(xmlnode("dhRecbto").InnerText).ToString("yyyy-MM-dd HH:mm:ss")
                Next

            End If


            Dim ret As Integer = verificar_regexiste("Select * from cfe where chave_nfce = '" & chave_nfce & "'")

            If ret = 0 Then

                conectar_mysqlDFe()
                Dim insertSQL As MySqlCommand = New MySqlCommand("INSERT INTO cfe (caixa, cnpj_dest, numero_nfce, serie_nfce, chave_nfce, data_emi, valor_total, valor_desc, ind_pag, sit_nfce, cod_sit, RV, nRec, tipo_nfce, nprot, data_aut, vlr_icms, xml, tp) VALUES (@caixa, @cnpj_dest, @numero_nfce, @serie_nfce, @chave_nfce, @data_emi, @valor_total, @valor_desc, @ind_pag, @sit_nfce, @cod_sit, @RV, @nRec, @tipo_nfce, @nprot, @data_aut, @vlr_icms, @xml, @tp)", oConn)

                insertSQL.Parameters.Add(New MySqlParameter("caixa", caixa))
                insertSQL.Parameters.Add(New MySqlParameter("cnpj_dest", cnpj_dest))
                insertSQL.Parameters.Add(New MySqlParameter("numero_nfce", nNF))
                insertSQL.Parameters.Add(New MySqlParameter("serie_nfce", serie))
                insertSQL.Parameters.Add(New MySqlParameter("chave_nfce", chave_nfce))
                insertSQL.Parameters.Add(New MySqlParameter("data_emi", data_emi))
                insertSQL.Parameters.Add(New MySqlParameter("valor_total", valor_total))
                insertSQL.Parameters.Add(New MySqlParameter("valor_desc", valor_desc))
                insertSQL.Parameters.Add(New MySqlParameter("ind_pag", ind_pag))
                insertSQL.Parameters.Add(New MySqlParameter("sit_nfce", xmot))
                insertSQL.Parameters.Add(New MySqlParameter("cod_sit", cod_sit))
                insertSQL.Parameters.Add(New MySqlParameter("RV", rv))
                insertSQL.Parameters.Add(New MySqlParameter("nRec", nRec))
                insertSQL.Parameters.Add(New MySqlParameter("tipo_nfce", chave_nfce.Substring(34, 1)))
                insertSQL.Parameters.Add(New MySqlParameter("nprot", nprot))
                insertSQL.Parameters.Add(New MySqlParameter("data_aut", data_aut))
                insertSQL.Parameters.Add(New MySqlParameter("vlr_icms", vlr_icms))
                insertSQL.Parameters.Add(New MySqlParameter("xml", Convert.ToBase64String(Encoding.UTF8.GetBytes(xml))))
                insertSQL.Parameters.Add(New MySqlParameter("tp", chave_nfce.Substring(34, 1)))

                insertSQL.ExecuteNonQuery()

                oConn.Close()

                ret2 = "ok"

            Else


                Dim sql As String = "UPDATE cfe SET chave_nfce = '" & chave_nfce & "'"

                If caixa <> "" Then
                    sql = sql + ", caixa = '" & caixa & "'"
                End If

                If cnpj_dest <> "" Then
                    sql = sql + ", cnpj_dest = '" & cnpj_dest & "'"
                End If

                If nNF <> "" Then
                    sql = sql + ", numero_nfce = '" & nNF & "'"
                End If

                If serie <> "" Then
                    sql = sql + ", serie_nfce = '" & serie & "'"
                End If

                If data_emi <> "" Then
                    sql = sql + ", data_emi = '" & data_emi & "'"
                End If

                If valor_total <> "" Then
                    sql = sql + ", valor_total = '" & valor_total & "'"
                End If

                If valor_desc <> "" Then
                    sql = sql + ", valor_desc = '" & valor_desc & "'"
                End If

                If ind_pag <> "" Then
                    sql = sql + ", ind_pag = '" & ind_pag & "'"
                End If

                If xmot <> "" Then
                    sql = sql + ", sit_nfce = '" & xmot & "'"
                End If

                If cod_sit <> "" Then
                    sql = sql + ", cod_sit = '" & cod_sit & "'"
                End If

                If rv <> "" Then
                    sql = sql + ", RV = '" & rv & "'"
                End If

                If nRec <> "" Then
                    sql = sql + ", nRec = '" & nRec & "'"
                End If

                If chave_nfce <> "" Then
                    sql = sql + ", tipo_nfce = '" & chave_nfce.Substring(34, 1) & "'"
                End If

                If nprot <> "" Then
                    sql = sql + ", nprot = '" & nprot & "'"
                End If

                If data_aut <> "" Then
                    sql = sql + ", data_aut = '" & data_aut & "'"
                End If

                If vlr_icms <> "" Then
                    sql = sql + ", vlr_icms = '" & vlr_icms & "'"
                End If

                If xml <> "" Then
                    sql = sql + ", xml = '" & Convert.ToBase64String(Encoding.UTF8.GetBytes(xml)) & "'"
                End If


                sql = sql + " where chave_nfce = '" & chave_nfce & "'"

                conectar_mysqlDFe()

                Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)

                insertSQL.ExecuteNonQuery()

                oConn.Close()

                ret2 = "ok"
            End If


            Return ret2

        Catch ex As Exception

            Return ex.Message
            ret2 = ex.Message


        End Try

    End Function

    Private Function arq_bits(ByVal xml As String) As Byte()
        Dim Arq_xml() As Byte
        If xml <> "" Then
            Dim encText As New System.Text.UTF8Encoding()
            Arq_xml = encText.GetBytes(xml)
        End If

        Return Arq_xml
    End Function

    Public Function consulta_cli(ByVal cnpj_dest As String)

        Dim Retarquivo As Dictionary(Of String, String) = New Dictionary(Of String, String)


        Try

            conectar_mysqlDFe()
            Dim SQLcommand As MySqlCommand
            SQLcommand = oConn.CreateCommand
            SQLcommand.CommandText = "Select * from cliente where cnpjcpf_cli = '" & cnpj_dest & "'"
            '   dr = SQLcommand.ExecuteReader()

            Using reader As MySqlDataReader = SQLcommand.ExecuteReader

                While reader.Read
                    Retarquivo.Add("vlrusado_cli", reader("vlr_disp"))
                    Retarquivo.Add("credito_dest", reader("vlr_limite"))
                    Retarquivo.Add("diapag_dest", reader("prazo_pag"))
                    Retarquivo.Add("status", "ok")

                    txt_cli(reader("cnpjcpf_cli"), reader("vlr_disp"), reader("vlr_limite"), reader("prazo_pag"))
                End While

            End Using

            Return Retarquivo

        Catch ex As Exception
            Return ex.Message
            Retarquivo.Add("status", ex.Message)
        End Try

    End Function

    Public Sub txt_cli(ByVal cnpj_dest As String, ByVal vlrusado_cli As String, ByVal credito_dest As String, ByVal diapag_dest As String)
        Dim parametro As New Utilitarios
        Dim arquivo As String = parametro.Caminho_arq_export() & "\cargacli.cac"
        Dim sep As String = "|"

        If File.Exists(arquivo) Then
            File.Delete(arquivo)
        End If
        Directory.CreateDirectory(parametro.Caminho_arq_export())

        Using writer As StreamWriter = New StreamWriter(arquivo, True)

            writer.WriteLine("5" & sep & cnpj_dest & sep & vlrusado_cli & sep & credito_dest & sep & diapag_dest)

        End Using
    End Sub

    Public Function salvar_caixa(ByVal caixa As String, ByVal ip As String, ByVal serie As String)
        Try

            Dim ret As Integer = verificar_regexiste("Select * from caixa_cad where caixa = '" & caixa & "'")

            If ret = 0 Then

                conectar_mysqlDFe()
                Dim insertSQL As MySqlCommand = New MySqlCommand("INSERT INTO caixa_cad (caixa, ip, serie) VALUES (@caixa, @ip, @serie)", oConn)

                insertSQL.Parameters.Add(New MySqlParameter("caixa", caixa))
                insertSQL.Parameters.Add(New MySqlParameter("ip", ip))
                insertSQL.Parameters.Add(New MySqlParameter("serie", serie))

                insertSQL.ExecuteNonQuery()

                oConn.Close()
            Else

                conectar_mysqlDFe()
                Dim insertSQL As MySqlCommand = New MySqlCommand("update caixa_cad set caixa = @caixa , ip = @ip, serie = @serie where caixa = '" & caixa & "'", oConn)

                insertSQL.Parameters.Add(New MySqlParameter("caixa", caixa))
                insertSQL.Parameters.Add(New MySqlParameter("ip", ip))
                insertSQL.Parameters.Add(New MySqlParameter("serie", serie))

                insertSQL.ExecuteNonQuery()

                oConn.Close()

            End If

            Return "ok"

        Catch ex As Exception
            Return ex.Message
            fecha_baseNFe()
        End Try

    End Function

    Public Function processar_venda(ByVal caixa As String, ByVal arquivo As String)

        Try

            Dim delimitador As String = "|"
            Dim ret As Integer = 0


            For Each line As String In File.ReadLines(arquivo)
                Dim separar = Split(line, delimitador)
                '''''''''''RV''''''
                If separar(0) = "10" Then

                    ret = verificar_regexiste("Select * from rv where rv = '" & separar(1) & "' and chave_nfe = '" & separar(11) & "'")

                    If separar(11) = "" Then
                        ret = 1
                    End If

                    If ret = 0 Then
                        conectar_mysqlDFe()
                        Dim insertSQL As MySqlCommand = New MySqlCommand("INSERT INTO rv (rv, caixa, valor_rv, forma_pag, data, obs, operador, vlr_canc, maquina_rv, vlrdesconto_rv, chave_nfe, chave_cont, status_rv, cnpj_dest) VALUES (@rv, @caixa, @valor_rv, @forma_pag, @data, @obs, @operador, @vlr_canc, @maquina_rv, @vlrdesconto_rv, @chave_nfe, @chave_cont, @status_rv, @cnpj_dest)", oConn)

                        insertSQL.Parameters.Add(New MySqlParameter("rv", separar(1)))
                        insertSQL.Parameters.Add(New MySqlParameter("caixa", separar(2)))
                        insertSQL.Parameters.Add(New MySqlParameter("valor_rv", format_vlrmy(separar(3))))
                        insertSQL.Parameters.Add(New MySqlParameter("forma_pag", separar(4)))
                        insertSQL.Parameters.Add(New MySqlParameter("data", Convert.ToDateTime(separar(5)).ToString("yyyy-MM-dd HH:mm:ss")))
                        insertSQL.Parameters.Add(New MySqlParameter("obs", separar(6)))
                        insertSQL.Parameters.Add(New MySqlParameter("operador", separar(7)))
                        insertSQL.Parameters.Add(New MySqlParameter("vlr_canc", format_vlrmy(separar(8))))
                        insertSQL.Parameters.Add(New MySqlParameter("maquina_rv", separar(9)))
                        insertSQL.Parameters.Add(New MySqlParameter("vlrdesconto_rv", format_vlrmy(separar(10))))
                        insertSQL.Parameters.Add(New MySqlParameter("chave_nfe", separar(11)))
                        insertSQL.Parameters.Add(New MySqlParameter("chave_cont", separar(12)))
                        insertSQL.Parameters.Add(New MySqlParameter("status_rv", separar(13)))
                        Try
                            insertSQL.Parameters.Add(New MySqlParameter("cnpj_dest", separar(14)))
                        Catch ex As Exception
                            insertSQL.Parameters.Add(New MySqlParameter("cnpj_dest", ""))
                        End Try

                        insertSQL.ExecuteNonQuery()

                        oConn.Close()

                    End If

                End If
                ''''''''''''''Iten rv'''''''
                If separar(0) = "11" Then

                    If ret = 0 Then
                        conectar_mysqlDFe()
                        Dim insertSQL As MySqlCommand = New MySqlCommand("INSERT INTO item_rv (rv, N_item, codigo_prod, codigo_barras, ncm_prod, cfop_item, cest_prod, cst_prod, aliq_icms, vlr_icms, un_item, qtde_item, vlrdesc_item, vlr_unit, vlr_total, data) VALUES (@rv, @N_item, @codigo_prod, @codigo_barras, @ncm_prod, @cfop_item, @cest_prod, @cst_prod, @aliq_icms, @vlr_icms, @un_item, @qtde_item, @vlrdesc_item, @vlr_unit, @vlr_total, @data)", oConn)

                        insertSQL.Parameters.Add(New MySqlParameter("rv", separar(1)))
                        insertSQL.Parameters.Add(New MySqlParameter("N_item", separar(2)))
                        insertSQL.Parameters.Add(New MySqlParameter("codigo_prod", separar(3)))
                        insertSQL.Parameters.Add(New MySqlParameter("codigo_barras", separar(4)))
                        insertSQL.Parameters.Add(New MySqlParameter("ncm_prod", separar(5)))
                        insertSQL.Parameters.Add(New MySqlParameter("cfop_item", separar(6)))
                        insertSQL.Parameters.Add(New MySqlParameter("cest_prod", separar(7)))
                        insertSQL.Parameters.Add(New MySqlParameter("cst_prod", separar(8)))
                        insertSQL.Parameters.Add(New MySqlParameter("aliq_icms", separar(9)))
                        insertSQL.Parameters.Add(New MySqlParameter("vlr_icms", format_vlrmy(separar(10))))
                        insertSQL.Parameters.Add(New MySqlParameter("un_item", separar(11)))
                        insertSQL.Parameters.Add(New MySqlParameter("qtde_item", separar(12)))
                        insertSQL.Parameters.Add(New MySqlParameter("vlrdesc_item", format_vlrmy(separar(13))))
                        insertSQL.Parameters.Add(New MySqlParameter("vlr_unit", format_vlrmy(separar(14))))
                        insertSQL.Parameters.Add(New MySqlParameter("vlr_total", format_vlrmy(separar(15))))
                        insertSQL.Parameters.Add(New MySqlParameter("data", Convert.ToDateTime(separar(16)).ToString("yyyy-MM-dd HH:mm:ss")))
                        insertSQL.ExecuteNonQuery()

                        oConn.Close()

                        executa_query("update produto set data_ultvenda = '" & Convert.ToDateTime(separar(16)).ToString("yyyy-MM-dd") & "' where codigo_prod = '" & separar(3) & "'")

                    End If
                End If
                ''''''''Estoque'''''''''''
                If separar(0) = "12" Then
                    If ret = 0 Then
                        Dim qtde As String


                        Dim ret2 As Integer = verificar_regexiste("select * from estoque where codigo_prod = " & separar(1) & "")
                        Dim sql3 As String

                        If ret2 = 0 Then
                            conectar_mysqlDFe()
                            sql3 = "INSERT INTO estoque (codigo_prod, Qtde_saida, datasaida_mov) VALUES (@codigo_prod, @Qtde_saida, @datasaida_mov)"
                            Dim insertSQL3 As MySqlCommand = New MySqlCommand(sql3, oConn)
                            insertSQL3.Parameters.Add(New MySqlParameter("codigo_prod", separar(1)))
                            insertSQL3.Parameters.Add(New MySqlParameter("Qtde_saida", separar(2)))
                            insertSQL3.Parameters.Add(New MySqlParameter("datasaida_mov", separar(3)))
                            insertSQL3.ExecuteNonQuery()
                            oConn.Close()
                        Else
                            conectar_mysqlDFe()
                            sql3 = "UPDATE estoque SET Qtde_saida = @Qtde_saida, datasaida_mov = @datasaida_mov where codigo_prod = '" & separar(1) & "'"
                            Dim insertSQL4 As MySqlCommand = New MySqlCommand(sql3, oConn)

                            qtde = CDec(ret_valor_banco("estoque", "codigo_prod", separar(1), "Qtde_saida") + CDec(separar(2)))

                            insertSQL4.Parameters.Add(New MySqlParameter("Qtde_saida", qtde))
                            insertSQL4.Parameters.Add(New MySqlParameter("datasaida_mov", Convert.ToDateTime(separar(3)).ToString("yyyy-MM-dd HH:mm:ss")))
                            insertSQL4.ExecuteNonQuery()
                            oConn.Close()
                        End If

                    End If
                End If
                '''''Documento contas a pagar'''''''''''''
                If separar(0) = "13" Then
                    If ret = 0 Then
                        Dim data As Date
                        data = Now.Date
                        Dim vrl_use As String = Format(CDec(ret_valor_banco("cliente", "cnpjcpf_cli", separar(3), "vlr_disp")) + CDec(separar(4)), "#,##0.00")
                        Dim sql4 As String = "INSERT INTO documento (codigo_rv, datahora_rv, chave_cli, valor_rv, tido_doc, Status_doc, Vencimento_doc, vlr_usado) VALUES (@codigo_rv, @datahora_rv, @chave_cli, @valor_rv, @tido_doc, @Status_doc, @Vencimento_doc, @vlr_usado)"

                        conectar_mysqlDFe()
                        Dim insertSQL5 As MySqlCommand = New MySqlCommand(sql4, oConn)
                        insertSQL5.Parameters.Add(New MySqlParameter("codigo_rv", separar(1)))
                        insertSQL5.Parameters.Add(New MySqlParameter("datahora_rv", Convert.ToDateTime(separar(2)).ToString("yyyy-MM-dd HH:mm:ss")))
                        insertSQL5.Parameters.Add(New MySqlParameter("chave_cli", separar(3)))
                        insertSQL5.Parameters.Add(New MySqlParameter("valor_rv", format_val_mysql_ent(separar(4))))
                        insertSQL5.Parameters.Add(New MySqlParameter("tido_doc", separar(5)))

                        insertSQL5.Parameters.Add(New MySqlParameter("Status_doc", separar(6)))
                        insertSQL5.Parameters.Add(New MySqlParameter("Vencimento_doc", Convert.ToDateTime(separar(7)).ToString("yyyy-MM-dd")))
                        insertSQL5.Parameters.Add(New MySqlParameter("vlr_usado", format_val_mysql_ent(vrl_use.ToString)))

                        insertSQL5.ExecuteNonQuery()
                        oConn.Close()

                        executa_query("update cliente set vlr_disp = '" & format_val_mysql_ent(vrl_use) & "' where cnpjcpf_cli = '" & separar(3) & "'")
                    End If
                End If

            Next





            Return "ok"
        Catch ex As Exception
            Return ex.Message

        End Try

    End Function

    Private Function format_vlrmy(ByVal valor As String)
        Dim ret As String

        ret = valor.Replace(".", "")
        ret = valor.Replace(",", ".")

        Return ret
    End Function
    Public Function verificar_regexiste(ByVal sql As String)
        Dim ret As Integer = 0
        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = sql
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())
            ret += 1
        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()

        Return ret
    End Function

    Public Function ret_valor_campo(ByVal sql As String, ByVal campo As String)
        Dim ret As String = ""
        conectar_mysql2()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn2.CreateCommand
        SQLcommand.CommandText = sql
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())
            ret = dr("" & campo & "").ToString
        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn2.Close()

        Return ret
    End Function

    Public Function ret_valor_banco(ByVal tabela As String, ByVal campo_pesq As String, ByVal valor As String, ByVal campo_ret As String)
        Dim ret As String
        Dim dr As MySqlDataReader

        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand

        SQLcommand = oConn.CreateCommand

        SQLcommand.CommandText = "select * from " & tabela & " where " & campo_pesq & " = '" & valor & "'"

        dr = SQLcommand.ExecuteReader()


        While dr.Read()


            ret = dr("" & campo_ret & "").ToString

        End While



        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()

        Return ret
    End Function
    Public Function format_val_mysql_ret(ByVal valor As String) As String
        If valor <> "" Then
            valor = valor.Replace(".", ",")

            valor = Format(CDec(valor), "#,##0.00")

            Return valor
        Else
            valor = "0,00"
        End If
    End Function

    Public Function format_val_sintegra(ByVal valor As String) As String
        If valor <> "" Then
            valor = valor.Replace(".", "")
            valor = valor.Replace(",", "")
            Return valor
        Else
            valor = "0"
        End If
    End Function
    Public Function format_val_mysql_ent(ByVal valor As String) As String
        If valor <> "" Then
            valor = valor.Replace(".", "")
            valor = valor.Replace(",", ".")
            Return valor
        Else
            valor = "0.00"
        End If
    End Function

    Public Function executa_query(ByVal sql As String) As Boolean
        Dim ret As Boolean

        Try
            conectar_mysqlDFe()
            Dim insertSQL2 As MySqlCommand = New MySqlCommand(sql, oConn)
            insertSQL2.ExecuteNonQuery()
            oConn.Close()
            ret = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "erro execute query")
        End Try


        Return ret
    End Function

    Public Function executa_query_SGlinx(ByVal sql As String) As Boolean
        Dim ret As Boolean

        Try
            conectar_mysql_sglinx()
            Dim insertSQL2 As MySqlCommand = New MySqlCommand(sql, oConnsg)
            insertSQL2.ExecuteNonQuery()
            oConnsg.Close()
            ret = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "erro execute query")
        End Try


        Return ret
    End Function
    Function pesquisar_online_codmunic(ByVal cidade As String)
        Dim html As String

        cidade = cidade.Replace(" ", "-")

        html = GetUrl_cidade("https://servicodados.ibge.gov.br/api/v1/localidades/municipios/" & cidade & "")

        Dim jss As New JavaScriptSerializer()
        ' ret = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(json)
        Dim dict As Dictionary(Of String, Object) = CType(jss.DeserializeObject(html), Dictionary(Of String, Object))


        Dim ret As Integer = verificar_regexiste("Select * from municipio where codigo_municipio = '" & dict("id") & "'")
        Dim sql As String

        If ret = 0 Then
            sql = "INSERT INTO municipio (NomeMunic, NomeUF, UF, cod_UF, codigo_municipio) VALUES (@NomeMunic, @NomeUF, @UF, @cod_UF, @codigo_municipio)"
        Else
            sql = "UPDATE municipio SET NomeMunic = @NomeMunic, NomeUF = @NomeUF, UF = @UF, cod_UF = @cod_UF, codigo_municipio = @codigo_municipio"
        End If

        conectar_mysqlDFe()
        Dim insertSQL As MySqlCommand = New MySqlCommand(sql, oConn)

        insertSQL.Parameters.Add(New MySqlParameter("NomeMunic", dict("nome")))
        insertSQL.Parameters.Add(New MySqlParameter("NomeUF", dict("microrregiao")("mesorregiao")("UF")("nome")))
        insertSQL.Parameters.Add(New MySqlParameter("UF", dict("microrregiao")("mesorregiao")("UF")("sigla")))
        insertSQL.Parameters.Add(New MySqlParameter("cod_UF", dict("microrregiao")("mesorregiao")("UF")("id")))
        insertSQL.Parameters.Add(New MySqlParameter("codigo_municipio", dict("id")))



        insertSQL.ExecuteNonQuery()

        oConn.Close()


        Return dict("id")
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

    Public Function ProximoCodigo(ByVal tabela As String, ByVal campo As String) As Long
        Dim num As Long = 1
        Dim mySqlDataReader As MySqlDataReader = CType(Nothing, MySqlDataReader)

        Try

            Dim cmdText As String = String.Format("select max({0}) as codigo from {1}", CObj(campo), CObj(tabela))

            conectar_mysqlDFe()
            Using mySqlCommand As MySqlCommand = New MySqlCommand(cmdText, oConn)
                mySqlDataReader = mySqlCommand.ExecuteReader()

                If mySqlDataReader.Read() Then
                    If Not mySqlDataReader.IsDBNull(mySqlDataReader.GetOrdinal("codigo")) Then num += Convert.ToInt64(mySqlDataReader.GetValue(mySqlDataReader.GetOrdinal("codigo")))
                End If
            End Using
            oConn.Close()

        Catch ex As Exception
            Throw
        Finally
            mySqlDataReader.Dispose()
        End Try

        Return num
    End Function

    Public Function retorna_mod_frete(valor As Integer) As String
        Dim ret As String

        If valor = 0 Then
            ret = "0- Contratação do Frete por conta do Remetente (CIF)"
        End If
        If valor = 1 Then
            ret = "1- Contratação do Frete por conta do destinatário/remetente (FOB)"
        End If
        If valor = 2 Then
            ret = "2- Contratação do Frete por conta de terceiros"
        End If
        If valor = 3 Then
            ret = "3- Transporte próprio por conta do remetente"
        End If
        If valor = 4 Then
            ret = "4- Transporte próprio por conta do destinatário"
        End If
        If valor = 9 Then
            ret = "9- Sem Ocorrência de transporte"
        End If

        Return ret

    End Function

    Public Function formatar_valor_4xml(ByVal texto As String) As String
        If texto <> "" Then

            Dim txt As String = ""

            Try
                txt = Format(Convert.ToDouble(texto.Replace(".", ",")), "###0.0000")
            Catch ex As Exception

                Try
                    txt = Format(Convert.ToDouble(texto), "###0.0000")

                Catch ex1 As Exception

                End Try

            End Try

            Return txt.Replace(",", ".")
        End If
    End Function


    <Extension()>
    Public Function Left(ByVal sValue As String, ByVal iMaxLength As Integer) As String
        If String.IsNullOrEmpty(sValue) Then
            sValue = String.Empty
        ElseIf String.IsNullOrWhiteSpace(sValue) Then
            sValue = String.Empty
        ElseIf sValue.Length >= iMaxLength Then
            sValue = sValue.Substring(0, iMaxLength)
        End If

        Return sValue
    End Function

    <Extension()>
    Public Function Right(ByVal sValue As String, ByVal iMaxLength As Integer) As String
        If String.IsNullOrEmpty(sValue) Then
            sValue = String.Empty
        ElseIf sValue.Length > iMaxLength Then
            sValue = sValue.Substring(sValue.Length - iMaxLength, iMaxLength)
        End If

        Return sValue
    End Function

    Public Function FormatABNT(ByVal Valor As String) As Decimal
        Try
            If Valor = "" Then Valor = "0"

            If Valor.Substring(Valor.IndexOf(",") + 3, 1) = "5" Then
                Dim num As Double = Convert.ToDouble(Valor.Substring(Valor.IndexOf(",") + 2, 1))
                Valor = If(Not (num = 0.0 Or num = 2.0 Or num = 4.0 Or num = 6.0 Or num = 8.0), Moeda(Convert.ToDouble(Valor), 2).ToString(), (If(Convert.ToDouble(Valor.Substring(Valor.IndexOf(",") + 4, 1)) <> 0.0, Moeda(Convert.ToDouble(Valor), 2).ToString(), Moeda(Convert.ToDouble(Truncar(Valor)), 2).ToString())))
            Else
                Valor = Moeda(Convert.ToDouble(Valor), 2).ToString()
            End If

        Catch ex As Exception
        End Try

        Return Convert.ToDecimal(Valor)
    End Function

    Public Function Truncar(ByVal valor2 As String) As String
        Dim d As Double = Convert.ToDouble(valor2)

        Try

            d *= 100.0
            d = Math.Truncate(d)
            d /= 100.0
        Catch ex As Exception
        End Try

        Return CSharpImpl.__Assign(valor2, d.ToString())
    End Function

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class


    Public Function valida_date_licenca() As Boolean
        Dim data_web As New clsDateTime
        Dim datas As Date
        Dim ret As Boolean = False


        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from licenca where key_sist = 'DFe' and key_id = '" & Criptografar(empresa.sCNPJ) & "'"
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read

                data_licenca = verificar_licenca_api(Descriptografar(reader("key_chave").ToString), "data_exp")

            End While

        End Using

        datas = data_web.GetNetworkTime.ToString()

        If data_licenca < datas.ToString("dd/MM/yyyy") Then
            '  MsgBox("Data invalida !", MsgBoxStyle.Exclamation, "Aviso !")
            ret = True
        End If


        Return ret
    End Function


    Public Function verificar_licenca_api(ByVal chave As String, ByVal tipo As String) As String

        Try
            Dim arquivo As Dictionary(Of String, String) = New Dictionary(Of String, String)
            Dim ret As String


            arquivo.Add("chave", chave)
            arquivo.Add("tipo", tipo)
            'data_exp
            'tipo_sistema'
            '  Dim thread As Thread = New Thread(AddressOf processarWS)
            '  thread.Start(CObj(arquivo))
            ret = processarWS_host(arquivo)
            Return ret

        Catch ex As Exception
            Return ex.Message
        End Try


    End Function
End Module
