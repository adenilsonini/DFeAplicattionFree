Imports System.Xml
Imports System.IO
Imports System.Globalization
Imports System.Reflection
Imports System.Text
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports DFe_aplicativo.DefaultPrinter
Imports System.Drawing.Printing
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography

Imports System.Collections
Imports System.Linq
Imports System.Xml.Linq
Imports System.Data.SQLite
Imports System.Net
Imports System.Threading
Imports MySql.Data.MySqlClient
Imports System.Xml.Serialization
Imports Newtonsoft.Json
Imports System.IO.Compression
Imports System.Xml.Schema
Imports System.Management

Public Module funcoesNfe

    Public cert_windows As Boolean
    Public ativa_webservice As Boolean
    Public ds As DataSet
    Public nsufalta As Boolean, email As Boolean
    Public reterro As String, cnpj_emp As String, coduf As String
    Public nfecancelada As Boolean
    Public svc_status As String, hora_verao As String, versao_sist As String
    Public vempresa As String, vnome_usu As String
    Public webservice_download As Boolean
    Public ct As Integer, regimetrib As Integer
    Dim dr As SQLiteDataReader
    Public empresa As clsDadosempresa = New clsDadosempresa()
    Public Function formatar_valor(ByVal texto As String) As String
        If texto <> "" Then

            Dim txt As String = ""

            Try
                txt = Format(Convert.ToDouble(texto.Replace(".", ",")), "###0.00")
            Catch ex As Exception

                Try
                    txt = Format(Convert.ToDouble(texto), "###0.00")

                Catch ex1 As Exception

                End Try

            End Try

            Return txt.Replace(",", ".")
        End If
    End Function

    Public Function formatar_valor_4c(ByVal texto As String) As String
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

    Public Function removeFormatacao(ByVal texto As String) As String

        Dim txt As String = ""

        txt = texto.Replace(".", "")
        txt = txt.Replace("-", "")
        txt = txt.Replace("/", "")
        txt = txt.Replace("(", "")
        txt = txt.Replace(")", "")
        txt = txt.Replace(" ", "")

        Return txt
    End Function

    Public Function removezerodireita(ByVal txt As String) As String
        If txt.Substring(txt.Length - 1, 1) = "0" Then
            txt = txt.Remove(txt.Length - 1, 1)
        End If
        If txt.Substring(txt.Length - 1, 1) = "0" Then
            txt = txt.Remove(txt.Length - 2, 2)
        End If
        Return txt
    End Function

    Public Sub retornaAtributos(ByVal obj As Object(), ByRef cultura As CultureInfo, ByRef formato As String, ByRef obrigatorio As Boolean)
        cultura = CultureInfo.CreateSpecificCulture("en-US")
        formato = "###0.00"
        obrigatorio = False
        For Each objeto As Object In obj
            ' If TypeOf objeto Is Formato Then
            '    Dim culturaStr As String = DirectCast(objeto, Formato).cultura
            ''    formato = DirectCast(objeto, Formato).formato
            '     cultura = CultureInfo.CreateSpecificCulture(culturaStr)
            '  ElseIf TypeOf objeto Is Obrigatorio Then
            ' '      obrigatorio = DirectCast(objeto, Obrigatorio).propriedadeObrigatoria

            '  End If

            '   cultura.NumberFormat.NumberDecimalSeparator = ",";
            ' cultura.NumberFormat.NumberGroupSeparator = ".";
        Next
    End Sub

    Public Function modulo11(ByVal chaveNFE As String) As Integer
        If chaveNFE.Length <> 43 Then
            Throw New Exception("Chave inválida, não é possível calcular o digito verificador")
        End If


        Dim baseCalculo As String = "4329876543298765432987654329876543298765432"
        Dim somaResultados As Integer = 0

        For i As Integer = 0 To chaveNFE.Length - 1
            Dim numNF As Integer = Convert.ToInt32(chaveNFE(i).ToString())
            Dim numBaseCalculo As Integer = Convert.ToInt32(baseCalculo(i).ToString())

            somaResultados += (numBaseCalculo * numNF)
        Next

        Dim restoDivisao As Integer = (somaResultados Mod 11)
        Dim dv As Integer = 11 - restoDivisao
        If (dv = 0) OrElse (dv > 9) Then
            Return 0
        Else
            Return dv
        End If
    End Function

    Public Function TirarAcento(ByVal palavra As String) As String
        Dim palavraSemAcento As String = ""
        Dim caracterComAcento As String = "áàãâäéèêëíìîïóòõôöúùûüçÁÀÃÂÄÉÈÊËÍÌÎÏÓÒÕÖÔÚÙÛÜÇ"
        Dim caracterSemAcento As String = "aaaaaeeeeiiiiooooouuuucAAAAAEEEEIIIIOOOOOUUUUC"

        For i As Integer = 0 To palavra.Length - 1
            If caracterComAcento.IndexOf(Convert.ToChar(palavra.Substring(i, 1))) >= 0 Then
                Dim car As Integer = caracterComAcento.IndexOf(Convert.ToChar(palavra.Substring(i, 1)))
                palavraSemAcento += caracterSemAcento.Substring(car, 1)
            Else
                palavraSemAcento += palavra.Substring(i, 1)
            End If
        Next

        Return palavraSemAcento
    End Function

    ''' <summary>
    ''' Função que utilizo para saber se é uma propriedade simples (String, Int) ou uma nova classe, que deve gerar
    ''' uma nova tag xml
    ''' </summary>
    ''' <param name="propriedade"></param>
    ''' <returns></returns>
    Public Function novaTag(ByVal propriedade As PropertyInfo) As Boolean
        'TODO: Buscar uma forma melhor de identificar as subclasses.

        Select Case propriedade.PropertyType.ToString()
            'Propriedades que podem ser nulas (com ?)...
            Case "System.DateTime", "System.Int32", "System.String", "System.Double", "System.Nullable", "System.Decimal",
            "System.Nullable`1[System.Int32]", "System.Nullable`1[System.DateTime]", "System.Nullable`1[System.Decimal]", "System.Nullable`1[System.Double]"
                Return False
            Case Else
                Return True
        End Select
    End Function

    Public Sub gravarElemento(ByVal writer As XmlWriter, ByVal nomeTag As String, ByVal valorTag As Object, ByVal atributos As Object())
        'CultureInfo cultBR = new CultureInfo("pt-BR");
        ' CultureInfo cultUS = new CultureInfo("en-US");

        Dim cult As CultureInfo
        Dim formato As String
        Dim obrigatorio As Boolean
        retornaAtributos(atributos, cult, formato, obrigatorio)

        If valorTag IsNot Nothing Then
            Dim valor As String = ""
            Select Case valorTag.[GetType]().ToString()
                Case "System.DateTime"
                    valor = DirectCast((valorTag), DateTime).ToString("yyyy-MM-dd")
                    'formata no padrão necessário para a NFe
                    Exit Select
                Case "System.Int32"
                    valor = valorTag.ToString()
                    If valor.Trim() = "0" Then
                        'campos do tipo inteiro com valor 0 serão ignorados
                        valor = ""
                    End If
                    Exit Select
                Case "System.String"
                    valor = TirarAcento(valorTag.ToString().Replace(vbCr & vbLf, " - ")).Trim()
                    'remove linhas... e tira acentos
                    Exit Select
                Case "System.Double"
                    valor = CDbl(valorTag).ToString(formato, cult.NumberFormat)
                    'formata de acordo com o atributo
                    Exit Select
                Case "System.Decimal"
                    valor = CDec(valorTag).ToString(formato, cult.NumberFormat)
                    'formata de acordo com o atributo
                    Exit Select

            End Select
            If (valor.Trim().Length > 0) OrElse (obrigatorio) Then
                writer.WriteElementString(nomeTag, valor)
            End If
        End If
    End Sub

    Public Function tamanhoXML(ByVal documento As XmlDocument) As Long
        Dim nomeArquivo As String = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "")

        Try
            documento.Save(nomeArquivo)
            Dim info As New FileInfo(nomeArquivo)
            Dim tamanhoArquivo As Long = info.Length

            info.Delete()

            Return tamanhoArquivo
        Catch
            Return 0

        End Try
    End Function

    Public Function RandomNumber(ByVal MaxNumber As Integer,
   Optional ByVal MinNumber As Integer = 0) As Integer

        'initialize random number generator
        Dim r As New Random(System.DateTime.Now.Millisecond)

        'if passed incorrect arguments, swap them
        'can also throw exception or return 0

        If MinNumber > MaxNumber Then
            Dim t As Integer = MinNumber
            MinNumber = MaxNumber
            MaxNumber = t
        End If

        Return r.Next(MinNumber, MaxNumber)

    End Function

    Public Function SepararNota(ByVal vNfeDadosMsg As String) As String

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<NFe")
        Dim nPosF As Int32 = vNfeDadosMsg.Length - nPosI
        Dim vStringNfe As String = vNfeDadosMsg.Substring(nPosI, nPosF)

        Return vStringNfe

    End Function

    Public Function GerarNotaProcessada(ByVal vStringNfe As String, ByVal VStringRecibo As String, ByVal EmissaoNota As Date, ByVal chavenfe As String) As String
        Dim cVersaoDados As String = "4.00"

        'Montar a parte do XML referente ao Lote e acrescentar a Nota Fiscal
        Dim vStringLoteNfe As String = String.Empty
        vStringLoteNfe += "<?xml version=""1.0"" encoding=""utf-8""?>"
        vStringLoteNfe += "<nfeProc versao=""" & cVersaoDados & """ xmlns=""http://www.portalfiscal.inf.br/nfe"">"
        vStringLoteNfe += vStringNfe
        '  vStringLoteNfe += "<protNFe versao=""" & cVersaoDados & """>"
        vStringLoteNfe += VStringRecibo
        ' vStringLoteNfe += "</protNFe>"
        vStringLoteNfe += "</nfeProc>"

        Dim PastaNota As String = ""
        PastaNota = Application.StartupPath & "\NFE_XML\" & Date.Parse(EmissaoNota).ToString("dd-MM-yyyy") & "\"
        If Directory.Exists(PastaNota) = False Then
            Directory.CreateDirectory(PastaNota)
        End If


        Dim NDoc = New XmlDocument()

        NDoc.LoadXml(vStringLoteNfe)

        Using xmltw As New XmlTextWriter(PastaNota & chavenfe.Replace(" ", "") + ".xml", New UTF8Encoding(False))
            NDoc.WriteTo(xmltw)
            xmltw.Close()
        End Using

        Return PastaNota & chavenfe + ".xml"
    End Function

    Public Function SepararNotaxml(ByVal vNfeDadosMsg As String) As String

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<NFe")
        Dim n5t As Int32 = vNfeDadosMsg.IndexOf("<protNFe")
        Dim total As Int32 = vNfeDadosMsg.Length - n5t
        Dim nPosF As Int32 = vNfeDadosMsg.Length - nPosI
        Dim vStringNfe As String = vNfeDadosMsg.Substring(nPosI, nPosF - total)
        Return vStringNfe

    End Function


    Public Function validacnpj(ByVal cnpj As String)

        Dim Numero(13) As Integer

        Dim soma As Integer

        Dim i As Integer

        Dim valida As Boolean

        Dim resultado1 As Integer

        Dim resultado2 As Integer

        For i = 0 To Numero.Length - 1

            Try
                Numero(i) = CInt(cnpj.Substring(i, 1))
            Catch ex As Exception

            End Try


        Next

        soma = Numero(0) * 5 + Numero(1) * 4 + Numero(2) * 3 + Numero(3) * 2 + Numero(4) * 9 + Numero(5) * 8 + Numero(6) * 7 +
                   Numero(7) * 6 + Numero(8) * 5 + Numero(9) * 4 + Numero(10) * 3 + Numero(11) * 2

        soma = soma - (11 * (Int(soma / 11)))

        If soma = 0 Or soma = 1 Then

            resultado1 = 0

        Else

            resultado1 = 11 - soma

        End If

        If resultado1 = Numero(12) Then

            soma = Numero(0) * 6 + Numero(1) * 5 + Numero(2) * 4 + Numero(3) * 3 + Numero(4) * 2 + Numero(5) * 9 + Numero(6) * 8 +
                         Numero(7) * 7 + Numero(8) * 6 + Numero(9) * 5 + Numero(10) * 4 + Numero(11) * 3 + Numero(12) * 2

            soma = soma - (11 * (Int(soma / 11)))

            If soma = 0 Or soma = 1 Then

                resultado2 = 0

            Else

                resultado2 = 11 - soma

            End If

            If resultado2 = Numero(13) Then

                Return True

            Else

                Return False

            End If

        Else

            Return False

        End If

    End Function

    Function validaCPF(ByVal strCPFCliente As String) As Boolean

        '--Declaração das Variáveis
        Dim strCPFOriginal As String = strCPFCliente.Replace(".", "").Replace("-", "").Replace(",", "")
        Dim strCPF As String = Mid(strCPFOriginal, 1, 9)
        Dim strCPFTemp As String
        Dim intSoma As Integer
        Dim intResto As Integer
        Dim strDigito As String
        Dim intMultiplicador As Integer = 10
        Const constIntMultiplicador As Integer = 11
        Dim i As Integer
        '--------------------------

        For i = 0 To strCPF.ToString.Length - 1
            intSoma += CInt(strCPF.ToString.Chars(i).ToString) * intMultiplicador
            intMultiplicador -= 1
        Next

        If (intSoma Mod constIntMultiplicador) < 2 Then
            intResto = 0
        Else
            intResto = constIntMultiplicador - (intSoma Mod constIntMultiplicador)
        End If

        strDigito = intResto
        intSoma = 0

        strCPFTemp = strCPF & strDigito
        intMultiplicador = 11

        For i = 0 To strCPFTemp.Length - 1
            intSoma += CInt(strCPFTemp.Chars(i).ToString) * intMultiplicador
            intMultiplicador -= 1
        Next

        If (intSoma Mod constIntMultiplicador) < 2 Then
            intResto = 0
        Else
            intResto = constIntMultiplicador - (intSoma Mod constIntMultiplicador)
        End If

        strDigito &= intResto

        If strDigito = Mid(strCPFOriginal, 10, strCPFOriginal.Length) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function casasdecimal2(ByRef txt As TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs) As Integer
        'so aceita dois casas a pos a virgula'
        Dim texto As String
        Dim posição As Integer
        Dim cursorpos As Integer
        Dim depois As String

        If e.Handled <> 8 Then
            texto = txt.Text
            cursorpos = txt.SelectionStart
            posição = InStr(1, texto, ",")

            If e.KeyChar = "." Then
                e.Handled = True
            End If

            If cursorpos >= posição Then
                If posição > 0 Then
                    depois = Microsoft.VisualBasic.Right(texto, Len(texto) - posição)
                    If e.KeyChar = "," Then
                        e.Handled = True
                    End If
                    If Len(depois) > 1 Then
                        If Not e.KeyChar = vbBack Then
                            e.Handled = True
                        End If
                    End If
                End If
            End If
        End If
        casasdecimal2 = e.Handled
    End Function

    Public Function casasdecimal4(ByRef txt As TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs) As Integer
        'so aceita dois casas a pos a virgula'
        Dim texto As String
        Dim posição As Integer
        Dim cursorpos As Integer
        Dim depois As String

        If e.Handled <> 8 Then
            texto = txt.Text
            cursorpos = txt.SelectionStart
            posição = InStr(1, texto, ",")

            If e.KeyChar = "." Then
                e.Handled = True
            End If

            If cursorpos >= posição Then
                If posição > 0 Then
                    depois = Microsoft.VisualBasic.Right(texto, Len(texto) - posição)
                    If e.KeyChar = "," Then
                        e.Handled = True
                    End If
                    If Len(depois) > 3 Then
                        If Not e.KeyChar = vbBack Then
                            e.Handled = True
                        End If
                    End If
                End If
            End If
        End If
        casasdecimal4 = e.Handled
    End Function

    Public Function GetDataTable(path As String, seperator As Char) As DataTable
        Dim dt As New DataTable()
        Dim aFile As New FileStream(path, FileMode.Open)
        Using sr As New StreamReader(aFile, System.Text.Encoding.[Default])
            Dim strLine As String = sr.ReadLine()
            Dim strArray As String() = strLine.Split(seperator)

            For Each value As String In strArray

                dt.Columns.Add(value.Trim())
            Next

            Dim dr As DataRow = dt.NewRow()

            While sr.Peek() > -1
                strLine = sr.ReadLine()
                strArray = strLine.Split(seperator)
                dt.Rows.Add(strArray)
            End While
        End Using
        Return dt
    End Function

    Public Function FormatarCpfCnpj(strCpfCnpj As String) As String

        If strCpfCnpj.Length <= 8 Then

            Dim mtpCpf As New MaskedTextProvider("00,000-000")

            mtpCpf.[Set](ZerosEsquerda(strCpfCnpj, 8))


            Return mtpCpf.ToString()
        End If

        If strCpfCnpj.Length <= 10 Then

            Dim mtpCpf As New MaskedTextProvider("(00) 0000-0000")

            mtpCpf.[Set](ZerosEsquerda(strCpfCnpj, 10))


            Return mtpCpf.ToString()
        End If

        If strCpfCnpj.Length <= 11 Then


            Dim mtpCpf As New MaskedTextProvider("000\.000\.000-00")

            mtpCpf.[Set](ZerosEsquerda(strCpfCnpj, 11))


            Return mtpCpf.ToString()
        Else



            Dim mtpCnpj As New MaskedTextProvider("00\.000\.000/0000-00")

            mtpCnpj.[Set](ZerosEsquerda(strCpfCnpj, 11))


            Return mtpCnpj.ToString()
        End If

    End Function


    Public Function ZerosEsquerda(strString As String, intTamanho As Integer) As String


        Dim strResult As String = ""

        For intCont As Integer = 1 To (intTamanho - strString.Length)



            strResult += "0"
        Next

        Return strResult & strString

    End Function

    Public Function convert_valor(ByVal doublestring As String) As Double
        Dim retval As Double
        Dim sep As String = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator

        If Double.TryParse(Replace(Replace(doublestring, ".", sep), ",", sep), retval) Then
            Return retval
        Else
            Return Nothing
        End If
    End Function

    Public Function valor_campo_vazio()
        Dim sep As String = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim valor_ret As String

        valor_ret = "0" & sep & "00"

        Return valor_ret

    End Function

    Public Function formata_valor_campo(ByVal valor As String) As String

        Dim valor_ret As String
        valor = valor.Replace(".", "")
        valor = valor.Replace(",", ".")
        valor_ret = Format(CDec(valor), "#,##0.00")

        Return valor_ret

    End Function


    Public Function formata_valor_campo_4c(ByVal valor As String) As String
        Dim valor_ret As String
        valor = valor.Replace(".", "")
        valor = valor.Replace(",", ".")
        valor_ret = Format(CDec(valor), "#,##0.0000")

        Return valor_ret

    End Function

    Function BuscaCep(ByVal cep As String) As Hashtable

        Dim _resultado As String
        Dim ht As System.Collections.Hashtable

        Try
            ds = New DataSet()
            ds.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + cep.Replace("-", "").Trim() + "&formato=xml")

            If Not IsNothing(ds) Then

                If (ds.Tables(0).Rows.Count > 0) Then

                    _resultado = ds.Tables(0).Rows(0).Item("resultado").ToString()

                    ht = New Hashtable

                    Select Case _resultado

                        Case "1"
                            ht.Add("UF", ds.Tables(0).Rows(0).Item("uf").ToString().Trim())
                            ht.Add("cidade", ds.Tables(0).Rows(0).Item("cidade").ToString().Trim())
                            ht.Add("bairro", ds.Tables(0).Rows(0).Item("bairro").ToString().Trim())
                            ht.Add("tipologradouro", ds.Tables(0).Rows(0).Item("tipo_logradouro").ToString().Trim())
                            ht.Add("logradouro", ds.Tables(0).Rows(0).Item("logradouro").ToString().Trim())
                            ht.Add("tipo", 1)

                        Case "2"
                            ht.Add("UF", ds.Tables(0).Rows(0).Item("uf").ToString().Trim())
                            ht.Add("cidade", ds.Tables(0).Rows(0).Item("cidade").ToString().Trim())
                            ht.Add("tipo", 2)

                        Case Else
                            ht.Add("tipo", 0)

                    End Select

                End If

            End If

            Return ht

        Catch ex As Exception
            Throw New Exception("Falha ao Buscar o Cep" & vbCrLf & ex.ToString)
            Return Nothing
        End Try
    End Function

    Function SoLETRAS(ByVal KeyAscii As Integer) As Integer

        'Transformar letras minusculas em Maiúsculas

        KeyAscii = Asc(UCase(Chr(KeyAscii)))

        ' Intercepta um código ASCII recebido e admite somente letras

        If InStr("AÃÁBCÇDEÉÊFGHIÍJKLMNOPQRSTUÚVWXYZ", Chr(KeyAscii)) = 0 Then

            SoLETRAS = 0

        Else

            SoLETRAS = KeyAscii

        End If



        ' teclas adicionais permitidas

        If KeyAscii = 8 Then SoLETRAS = KeyAscii ' Backspace

        If KeyAscii = 13 Then SoLETRAS = KeyAscii ' Enter

        If KeyAscii = 32 Then SoLETRAS = KeyAscii ' Espace
    End Function

    Function SoNumeros(ByVal Keyascii As Short) As Short

        If InStr("1234567890", Chr(Keyascii)) = 0 Then

            SoNumeros = 0

        Else

            SoNumeros = Keyascii

        End If



        Select Case Keyascii

            Case 8

                SoNumeros = Keyascii

            Case 13

                SoNumeros = Keyascii

            Case 32

                SoNumeros = Keyascii

        End Select

    End Function

    Public Function validaGTIN(code As String) As Boolean
        If code <> (New Regex("[^0-9]")).Replace(code, "") Then
            ' is not numeric
            Return False
        End If
        ' pad with zeros to lengthen to 14 digits
        Select Case code.Length
            Case 8
                code = Convert.ToString("000000") & code
                Exit Select
            Case 12
                code = Convert.ToString("00") & code
                Exit Select
            Case 13
                code = Convert.ToString("0") & code
                Exit Select
            Case 14
                Exit Select
            Case Else
                ' wrong number of digits
                Return False
        End Select
        ' calculate check digit
        Dim a As Integer() = New Integer(12) {}
        a(0) = Integer.Parse(code(0).ToString()) * 3
        a(1) = Integer.Parse(code(1).ToString())
        a(2) = Integer.Parse(code(2).ToString()) * 3
        a(3) = Integer.Parse(code(3).ToString())
        a(4) = Integer.Parse(code(4).ToString()) * 3
        a(5) = Integer.Parse(code(5).ToString())
        a(6) = Integer.Parse(code(6).ToString()) * 3
        a(7) = Integer.Parse(code(7).ToString())
        a(8) = Integer.Parse(code(8).ToString()) * 3
        a(9) = Integer.Parse(code(9).ToString())
        a(10) = Integer.Parse(code(10).ToString()) * 3
        a(11) = Integer.Parse(code(11).ToString())
        a(12) = Integer.Parse(code(12).ToString()) * 3
        Dim sum As Integer = a(0) + a(1) + a(2) + a(3) + a(4) + a(5) + a(6) + a(7) + a(8) + a(9) + a(10) + a(11) + a(12)
        Dim check As Integer = (10 - (sum Mod 10)) Mod 10
        ' evaluate check digit
        Dim last As Integer = Integer.Parse(code(13).ToString())
        Return check = last
    End Function

    Public Function VerificaConectividade_net() As Boolean
        Dim vRetorno As Boolean = False

        Try
            If My.Computer.Network.Ping("www.google.com", 10000) = True Then
                vRetorno = True
            End If
        Catch ex As Exception

        End Try


        Return vRetorno
    End Function

    Public Function IsConectedToHost(ByVal uri As Uri) As Boolean
        Try
            Dns.GetHostEntry(uri.Host)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function GerarLote_manifestacao()

        'Pegar o último número de lote de NFe utilizado e acrescentar + 1 para novo envio
        Dim vArqXmlLote As String = "TryLote_manifestacao.xml"
        Dim nNumeroLote As Int32 = 1

        If File.Exists(vArqXmlLote) Then
            Dim oLerXml As New XmlTextReader(vArqXmlLote)

            While oLerXml.Read()
                If oLerXml.NodeType = XmlNodeType.Element Then
                    If oLerXml.Name = "UltimoLoteEnviado" Then
                        oLerXml.Read()
                        nNumeroLote = Convert.ToInt32(oLerXml.Value) + 1
                        Exit While
                    End If
                End If
            End While
            oLerXml.Close()
        End If

        'Salvar o número de lote de NFe utilizado
        Dim oSettings As New XmlWriterSettings()
        oSettings.Indent = True
        oSettings.IndentChars = ""
        oSettings.NewLineOnAttributes = False
        oSettings.OmitXmlDeclaration = False

        Dim oXmlGravar As XmlWriter = XmlWriter.Create("TryLote_manifestacao.xml", oSettings)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("DadosLoteNfe")
        oXmlGravar.WriteElementString("UltimoLoteEnviado", nNumeroLote.ToString())
        oXmlGravar.WriteEndElement()
        'DadosLoteNfe
        oXmlGravar.WriteEndDocument()
        oXmlGravar.Flush()
        oXmlGravar.Close()

        Return nNumeroLote.ToString("000000000000000")

    End Function


    Public Function gerar_pdf_sistema(Documento As PrintDocument, saida_doc_pdf As String)

        Dim Nome_impressora As String
        Nome_impressora = Documento.PrinterSettings.PrinterName

        Documento.PrinterSettings.PrinterName = "Microsoft Print To PDF"

        Documento.DefaultPageSettings.PrinterSettings.PrintToFile = True

        Documento.DefaultPageSettings.PrinterSettings.PrintFileName = saida_doc_pdf
        Documento.PrintController = New StandardPrintController()
        Documento.Print()


        Documento.DefaultPageSettings.PrinterSettings.PrintToFile = False

        DefaultPrinterName = Nome_impressora

    End Function

    Public Function gerar_xps_PDF_sistema(Documento As PrintDocument, nome_doc As String, caminho_saida_pdf As String)

        Dim Nome_impressora As String
        Nome_impressora = Documento.PrinterSettings.PrinterName

        Documento.PrinterSettings.PrinterName = "Microsoft XPS Document Writer"

        Documento.DefaultPageSettings.PrinterSettings.PrintToFile = True

        Documento.DefaultPageSettings.PrinterSettings.PrintFileName = Application.StartupPath & "\Temp_pdf\" & nome_doc & ".xps"
        Documento.PrintController = New StandardPrintController()
        Documento.Print()


        Documento.DefaultPageSettings.PrinterSettings.PrintToFile = False

        DefaultPrinterName = Nome_impressora


        Dim objArguments As String
        objArguments = "-sDEVICE=pdfwrite -sOutputFile=" & Application.StartupPath & "\Temp_pdf\" & nome_doc & ".pdf" & " -dNOPAUSE " & Application.StartupPath & "\Temp_pdf\" & nome_doc & ".xps" & ""

        Dim objStartInfo As New ProcessStartInfo()

        objStartInfo.UseShellExecute = False
        objStartInfo.RedirectStandardError = True
        objStartInfo.FileName = Application.StartupPath & "\pdf.exe"
        objStartInfo.Arguments = objArguments
        objStartInfo.WindowStyle = ProcessWindowStyle.Hidden
        objStartInfo.ErrorDialog = True


        Using objProcess As Process = New Process
            objProcess.StartInfo = objStartInfo
            objProcess.Start()

            objProcess.WaitForExit()
            objProcess.Close()
        End Using


        File.Delete(Application.StartupPath & "\Temp_pdf\" & nome_doc & ".xps")

        If caminho_saida_pdf <> "" Then
            File.Move(Application.StartupPath & "\Temp_pdf\" & nome_doc & ".pdf", caminho_saida_pdf)
        End If

    End Function

    Public Function converte_xmlbytes(ByVal fileName As String) As Byte()

        If fileName <> "" Then
            Dim encText As New System.Text.UTF8Encoding()
            Dim btText() As Byte
            btText = encText.GetBytes(fileName)
            Return btText
        End If
    End Function

    Public Function GetSerialHDD() As String
        Dim str1 As String

        Try

            Dim managementObjectSearcher As ManagementObjectSearcher = New ManagementObjectSearcher("select * from Win32_DiskDrive")
            Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator
            Dim str2 As String

            Try
                enumerator = managementObjectSearcher.[Get]().GetEnumerator()

                While enumerator.MoveNext()
                    str2 = Convert.ToString(enumerator.Current("SerialNumber"))
                End While

            Finally
                enumerator.Dispose()
            End Try

            str1 = str2
        Catch ex As Exception

            str1 = ""

        End Try

        Return str1
    End Function


    Public Function getSHA1Hash(ByVal strToHash As String) As String
        Dim hash As Byte() = New SHA1CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(strToHash))
        Dim str As String = ""
        Dim numArray As Byte() = hash
        Dim index As Integer = 0

        While index < numArray.Length
            Dim num As Byte = numArray(index)
            str += num.ToString("x2")
            index += 1
        End While

        Return str
    End Function

    Public Function RetornaSHA1(ByVal StrToHash As String) As String
        Return getSHA1Hash(StrToHash)
    End Function

    Public Function GerarHash_PDVLinear(ByVal nCaixa As Integer, cnpj As String, csc As String, idtoken As String) As String
        Dim str1 As String
        Dim ret As clsPlugin
        '  Try

        Dim str2 As String = ""

        str2 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(CObj(str2), Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(cnpj, CObj("|"))))
        str2 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(CObj(str2), Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(csc, CObj("|"))))
        str2 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(CObj(str2), Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(idtoken, CObj("|"))))




        Dim StrToHash As String = str2 & Convert.ToString(nCaixa) & "|" + GetSerialHDD() & "|"
        Dim query2 As String = "select cf.caixa, cf.serie, cf.inicial, cf.final, cn.num_nf from ctrl_faixa cf left outer join ctrl_num cn on cn.serie = cf.serie and cn.caixa = cf.caixa where cf.status=1 and cf.caixa ='103'"
        Dim dataTable2 As DataTable = ret_table(query2)


        For Each row As DataRow In dataTable2.Rows
            StrToHash = Convert.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(CObj(StrToHash), Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(row("serie"), CObj("|"))))
            StrToHash = Convert.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(CObj(StrToHash), Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(row("num_nf"), CObj("|"))))
            StrToHash = Convert.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(CObj(StrToHash), Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(row("inicial"), CObj("|"))))
            StrToHash += row("final").ToString()

        Next

        ''

        str1 = RetornaSHA1(StrToHash)

        ' Catch ex As Exception
        '     MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Tela gera Hash, Atenção !")
        '     str1 = ""

        '  End Try

        Return str1
    End Function


    Public Function ret_table(ByVal csql As String) As DataTable
        Dim flag As Boolean

        Dim ds As DataSet = Nothing
        Dim dataTable1 As DataTable = New DataTable()
        Dim dataTable2 As DataTable

        Try

            Dim connection As SQLiteConnection = New SQLiteConnection("Data Source=C:\Users\adeni\Desktop\TES\CFe.db3;Version=3;Password=R@enil2015#;")
            connection.Open()
            '   csql = "select cast(pr_valor as text) as pr_valor from parametro where pr_chave = 'PDV_NFCE_HABFUNCAO'"
            Dim da As SQLiteDataReader = New SQLiteCommand(csql, connection).ExecuteReader()

            Using cmd As SQLiteCommand = New SQLiteCommand(csql, connection)

                Using sqLiteDataAdapter As SQLiteDataAdapter = New SQLiteDataAdapter(cmd)
                    sqLiteDataAdapter.Fill(dataTable1)
                    dataTable2 = dataTable1
                End Using
            End Using

            Return dataTable2
        Catch ex As Exception

        End Try


    End Function



    Public Function Tamanho_campoDanfce(ByVal sEntrada As Integer) As Integer
        MsgBox(sEntrada)
        Dim calc As String
        If sEntrada > 87 Then
            sEntrada = 87
        End If
        If sEntrada < 87 Then
            calc = sEntrada - 87
            sEntrada = sEntrada + CDec(calc.Substring(1, calc.Length - 1))
        End If


        Return sEntrada
    End Function

    Public Function IsConnected(Optional ByVal sEnderPing As String = "") As Boolean
        Dim flag As Boolean

        Try
            If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Trim(sEnderPing), "", False) = 0 Then sEnderPing = "8.8.8.8"
            flag = My.Computer.Network.Ping(sEnderPing)
        Catch ex As Exception

            flag = False

        End Try

        Return flag
    End Function


    Public Function ImprimirXMLVenda(ByVal strXml As String, ByVal strTextoVias As String, ByVal cPortaImp As String, ByVal iTpAmb As Integer, Optional ByVal bReduzido As Boolean = False, Optional ByVal versao_layout As String = "4.00") As Integer
        Dim num1 As Integer

        Try

            Dim thread As Thread = New Thread(AddressOf ImprimirXMLNFCeBematech.ImprimirXMLNFCeBematech)
            thread.Start(CObj(New List(Of String)() From {
                strXml,
                strTextoVias,
                cPortaImp,
                Convert.ToString(iTpAmb),
                Convert.ToString(bReduzido),
                versao_layout
            }))
            iRetTrImp = 0

            While iRetTrImp = 0
                Dim num2 As Integer

                If num2 = 30 Then
                    '  mdlGeral.CriarArquivoLog("TimeOut da thread esgotado. A thread vai ser abortada!", "", "", False, False, False)
                    iRetTrImp = 9
                    Exit While
                End If

                num2 += 1

                Thread.Sleep(1000)
            End While

            If iRetTrImp = 9 Then
                ' mdlGeral.CriarArquivoLog("Ocorreu um erro ao tentar conexão com o WS!", "", "", False, False, False)
                thread.Abort()
            End If

            num1 = iRetTrImp
        Catch ex As Exception

            Dim num2 As Integer = CInt(Interaction.MsgBox(CObj(ex.Message), MsgBoxStyle.OkOnly, CObj(Nothing)))
            num1 = 0

        End Try

        Return num1
    End Function

    Public Function Imprimir_Venda_prazo(ByVal strXml As String, ByVal strTextoVias As String, ByVal cPortaImp As String, ByVal iTpAmb As Integer, Optional ByVal bReduzido As Boolean = False, Optional ByVal versao_layout As String = "4.00") As Integer
        Dim num1 As Integer

        Try

            Dim thread As Thread = New Thread(AddressOf ImprimirXMLNFCeBematech.Imprimir_VENDA_PRAZO_Bematech)
            thread.Start(CObj(New List(Of String)() From {
                strXml,
                strTextoVias,
                cPortaImp,
                Convert.ToString(iTpAmb),
                Convert.ToString(bReduzido),
                versao_layout
            }))
            iRetTrImp = 0

            While iRetTrImp = 0
                Dim num2 As Integer

                If num2 = 30 Then
                    '  mdlGeral.CriarArquivoLog("TimeOut da thread esgotado. A thread vai ser abortada!", "", "", False, False, False)
                    iRetTrImp = 9
                    Exit While
                End If

                num2 += 1

                Thread.Sleep(1000)
            End While

            If iRetTrImp = 9 Then
                ' mdlGeral.CriarArquivoLog("Ocorreu um erro ao tentar conexão com o WS!", "", "", False, False, False)
                thread.Abort()
            End If

            num1 = iRetTrImp
        Catch ex As Exception

            Dim num2 As Integer = CInt(Interaction.MsgBox(CObj(ex.Message), MsgBoxStyle.OkOnly, CObj(Nothing)))
            num1 = 0

        End Try

        Return num1
    End Function
    Public Function GerarEndQRCodeXML(ByVal strXML As String, Optional ByVal DigestValueHash As String = "", Optional ByVal sVersaoLayout As String = "4.00", Optional ByVal sCSC As String = "", Optional ByVal sIdtoken As String = "") As String
        Return GerarEndQRCode(strXML, DigestValueHash, sVersaoLayout, empresa.sCSC, empresa.Idtoken, empresa.sSiglaUF)
    End Function

    Public Function GerarEndQRCode(ByVal strXML As String, ByVal DigestValueHash As String, ByVal sVersaoLayout As String, ByVal sCSC As String, ByVal sIdtoken As String, ByVal NFCe_UF As String) As String
        Dim str1 As String
        sVersaoLayout = "4.00"

        Try
            Dim xmlDocument As XmlDocument = New XmlDocument()
            Dim clsPlugin As clsPlugin = New clsPlugin()
            xmlDocument.LoadXml(strXML)
            Dim str2 As String

            If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(DigestValueHash, "", False) <> 0 Then
                str2 = DigestValueHash
            Else

                Try

                    For Each obj1 As Object In xmlDocument.GetElementsByTagName("Reference")
                        Dim objectValue1 As Object = RuntimeHelpers.GetObjectValue(obj1)

                        Try

                            For Each obj2 As Object In CType(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue1, CType(Nothing, Type), "ChildNodes", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())), IEnumerable)
                                Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(obj2)

                                If Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "Name", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())), CObj("DigestValue"), False) Then
                                    str2 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "innertext", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
                                    Exit For
                                End If
                            Next

                        Finally
                            Dim enumerator As IEnumerator
                            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                        End Try
                    Next

                Finally
                    Dim enumerator As IEnumerator
                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                End Try

                If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str2, "", False) = 0 Then str2 = xmlDocument("NFe")("Signature")("SignedInfo")("Reference")("DigestValue").InnerText
            End If

            '  If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(sCSC, "", False) = 0 Then sCSC = mdlGeral.NFCe_CSC
            '  If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(sIdtoken, "", False) = 0 Then sIdtoken = mdlGeral.NFCe_ID_Token
            '  If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(sCSC, "", False) = 0 Then sCSC = mdlGeral.AppPathCSC
            '  If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(sIdtoken, "", False) = 0 Then sIdtoken = mdlGeral.AppPathIdToken
            Dim nfCeUf As String

            If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(NFCe_UF, "", False) = 0 Then

                Try

                    For Each obj1 As Object In xmlDocument.GetElementsByTagName("enderEmit")
                        Dim objectValue1 As Object = RuntimeHelpers.GetObjectValue(obj1)

                        Try

                            For Each obj2 As Object In CType(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue1, CType(Nothing, Type), "childnodes", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())), IEnumerable)
                                Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(obj2)

                                If Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "name", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())), CObj("UF"), False) Then
                                    nfCeUf = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "innertext", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
                                    Exit For
                                End If
                            Next

                        Finally
                            Dim enumerator As IEnumerator
                            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                        End Try
                    Next

                Finally
                    Dim enumerator As IEnumerator
                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                End Try
            Else
                nfCeUf = NFCe_UF
            End If

            Dim str3 As String

            Try

                For Each obj1 As Object In xmlDocument.GetElementsByTagName("NFe")
                    Dim objectValue1 As Object = RuntimeHelpers.GetObjectValue(obj1)

                    Try

                        For Each obj2 As Object In CType(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue1, CType(Nothing, Type), "ChildNodes", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())), IEnumerable)
                            Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(obj2)

                            If Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "Name", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())), CObj("infNFe"), False) Then
                                str3 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "GetAttribute", New Object(0) {CObj("Id")}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
                                sVersaoLayout = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "GetAttribute", New Object(0) {CObj("versao")}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
                                Exit For
                            End If
                        Next

                    Finally
                        Dim enumerator As IEnumerator
                        If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                    End Try
                Next

            Finally
                Dim enumerator As IEnumerator
                If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
            End Try

            Dim str4 As String
            Dim str5 As String
            Dim str6 As String

            Try

                For Each obj1 As Object In xmlDocument.GetElementsByTagName("ide")
                    Dim objectValue1 As Object = RuntimeHelpers.GetObjectValue(obj1)

                    Try

                        For Each obj2 As Object In CType(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue1, CType(Nothing, Type), "childnodes", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())), IEnumerable)
                            Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(obj2)
                            Dim Left As Object = Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "name", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean()))

                            If Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, CObj("dhEmi"), False) Then
                                str4 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "innertext", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
                            ElseIf Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, CObj("tpAmb"), False) Then
                                str5 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "innertext", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
                            ElseIf Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, CObj("tpEmis"), False) Then
                                str6 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "innertext", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
                            End If
                        Next

                    Finally
                        Dim enumerator As IEnumerator
                        If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                    End Try
                Next

            Finally
                Dim enumerator As IEnumerator
                If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
            End Try

            Dim str7 As String
            Dim str8 As String

            Try

                For Each obj1 As Object In xmlDocument.GetElementsByTagName("ICMSTot")
                    Dim objectValue1 As Object = RuntimeHelpers.GetObjectValue(obj1)

                    Try

                        For Each obj2 As Object In CType(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue1, CType(Nothing, Type), "childnodes", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())), IEnumerable)
                            Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(obj2)
                            Dim Left As Object = Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "name", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean()))

                            If Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, CObj("vNF"), False) Then
                                str7 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "innertext", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
                            ElseIf Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, CObj("vICMS"), False) Then
                                str8 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "innertext", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
                            End If
                        Next

                    Finally
                        Dim enumerator As IEnumerator
                        If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                    End Try
                Next

            Finally
                Dim enumerator As IEnumerator
                If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
            End Try

            Dim Left1 As String

            If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(sVersaoLayout, "3.10", False) = 0 And xmlDocument.GetElementsByTagName("dest").Count > 0 Then

                Try

                    For Each obj1 As Object In xmlDocument.GetElementsByTagName("dest")
                        Dim objectValue1 As Object = RuntimeHelpers.GetObjectValue(obj1)

                        Try
                            '  Microsoft.VisualBasic.CompilerServices.LateBinding.LateGet
                            For Each obj2 As Object In CType(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue1, CType(Nothing, Type), "childnodes", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())), IEnumerable)
                                Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(obj2)
                                Dim Left2 As Object = Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "name", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean()))

                                If Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left2, CObj("CPF"), False) Then
                                    Left1 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "innertext", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
                                ElseIf Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left2, CObj("CNPJ"), False) Then
                                    Left1 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "innertext", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
                                End If
                            Next

                        Finally
                            Dim enumerator As IEnumerator
                            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                        End Try
                    Next

                Finally
                    Dim enumerator As IEnumerator
                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                End Try
            End If

            Dim str9 As String

            If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(sVersaoLayout, "4.00", False) = 0 Then
                Dim str10 As String = Strings.Mid(str4, (Strings.InStr(str4, "T", CompareMethod.Binary) - 2), 2)
                cAux = Strings.Mid(str3, 4) & "|2|" & str5 & "|"

                If Convert.ToDouble(str6) = 1.0 Then
                    cAux += Convert.ToString(Conversion.Val(sIdtoken))
                Else
                    Dim hex As String = StringToHex(str2)
                    cAux = cAux & str10 & "|" & str7 & "|" & hex & "|" + Convert.ToString(Conversion.Val(sIdtoken))
                End If

                Dim shA1Hash As String = getSHA1Hash(cAux & sCSC)
                str9 = "https://nfce.fazenda.mg.gov.br/portalnfce/sistema/qrcode.xhtml?" & "p=" + cAux & "|" + Strings.UCase(shA1Hash)
            Else
                Dim hex1 As String = StringToHex(str4)
                cAux = "chNFe=" & Strings.Mid(str3, 4) & "&nVersao=100&tpAmb=" & str5
                If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "", False) <> 0 Then cAux = cAux & "&cDest=" & Left1
                cAux = cAux & "&dhEmi=" & hex1
                Dim hex2 As String = StringToHex(str2)
                cAux = cAux & "&vNF=" & str7
                cAux = cAux & "&vICMS=" & str8
                cAux = cAux & "&digVal=" & hex2
                cAux = cAux & "&cIdToken=" + Strings.Format(CObj(Conversion.Val(sIdtoken)), "000000")
                Dim shA1Hash As String = getSHA1Hash(cAux & sCSC)
                str9 = "https://nfce.fazenda.mg.gov.br/portalnfce/sistema/qrcode.xhtml?" & "&cHashQRCode=" + Strings.UCase(shA1Hash)
            End If

            CriarLog("QRCode CSC: " & sCSC & " / IdToken: " & sIdtoken & " / tpAmb: " & str5, "", "", False, False, False)
            CriarLog("QRCode Layout: " & sVersaoLayout & " / CodeQR: " & str9, "", "", False, False, False)
            str1 = str9
        Catch ex As Exception

            Dim exception As Exception = ex
            CriarLog("Erro(GerarEndQRCode) Layout: " & sVersaoLayout & " / Mensagem: " & exception.Message & " - " + exception.StackTrace, "", "", False, False, False)
            str1 = ""
            MsgBox(exception.Message)
        End Try

        Return str1
    End Function

    Public Function MascSTR(ByVal Txt As String, ByVal Mask As String) As String
        Dim num1 As Integer
        Dim str As String
        Dim num2 As Integer



        num1 = 2
        Dim CounterResult As Object = CObj(1)
        Dim Left As Object = CObj(1)

        If Strings.Len(Txt) = Strings.Len(Mask) Then
            str = ""

        ElseIf Not Microsoft.VisualBasic.CompilerServices.Versioned.IsNumeric(CObj(Txt)) Then
            str = ""

        Else
            Dim obj As Object = CObj(Txt)
            Txt = ""
            Dim LoopForResult As Object

            If Microsoft.VisualBasic.CompilerServices.ObjectFlowControl.ForLoopControl.ForLoopInitObj(CounterResult, CObj(1), CObj(Strings.Len(Mask)), CObj(1), LoopForResult, CounterResult) Then

                Do

                    If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Mid(Mask, Microsoft.VisualBasic.CompilerServices.Conversions.ToInteger(CounterResult), 1), "#", False) <> 0 Then
                        Txt += Strings.Mid(Mask, Microsoft.VisualBasic.CompilerServices.Conversions.ToInteger(CounterResult), 1)
                    Else
                        Txt += Strings.Mid(Microsoft.VisualBasic.CompilerServices.Conversions.ToString(obj), Microsoft.VisualBasic.CompilerServices.Conversions.ToInteger(Left), 1)
                        Left = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Left, CObj(1))
                    End If
                Loop While Microsoft.VisualBasic.CompilerServices.ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult, LoopForResult, CounterResult)
            End If

            str = Txt

        End If


        num2 = -1

        Select Case num1
            Case 2

        End Select
        Try


        Catch ex As Exception
            Dim num3 As Integer

            If TypeOf ex Is Exception And CUInt(num1) > 0UI And num3 = 0 Then
                'SuccessfulFiltering()
            Else
                Throw
            End If
        End Try

        If True Then
            ' ProjectData.SetProjectError(ex)
            ' GoTo label_10
        End If

        ' Throw ProjectData.CreateProjectError(-2146828237)

        '  If num2 <> 0 Then ProjectData.ClearProjectError()
        Return str
    End Function


    Public Function INI_dfe(ByVal Chave As String, ByVal Sessao As String, ByVal tipo As String, Optional ByVal Valor As String = "") As String
        Try
            Dim ret As String
            Dim baseDirectory As String = AppDomain.CurrentDomain.BaseDirectory
            Dim arquivoIni As ArquivoIni = New ArquivoIni(String.Format("{0}config_DFe.ini", CObj(AppDomain.CurrentDomain.BaseDirectory)))

            If tipo = "k_existe" Then
                If Not arquivoIni.KeyExists(Chave, Sessao) Then arquivoIni.Write(Chave, Valor, Sessao)
            End If
            If tipo = "L_key" Then
                ret = arquivoIni.Read(Chave, Sessao, Valor)
            End If
            If tipo = "E_key" Then
                arquivoIni.Write(Chave, Valor, Sessao)
            End If
            If tipo = "D_key" Then
                arquivoIni.DeleteKey(Sessao, Chave)
            End If
            If tipo = "D_sessao" Then
                arquivoIni.DeleteSection(Sessao)
            End If

            Return ret

        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function Serializar(ByVal objectToSerialize As Object, Optional ByVal strUrl As String = Nothing) As XmlDocument
        Dim namespaces As XmlSerializerNamespaces = New XmlSerializerNamespaces()
        If strUrl Is Nothing Then strUrl = "http://www.portalfiscal.inf.br/nfe"
        namespaces.Add("", strUrl)
        Dim stream As Stream = CType(New MemoryStream(), Stream)
        Dim xmlDocument As XmlDocument = New XmlDocument()
        Dim xmlWriter As XmlWriter = XmlWriter.Create(stream)
        Dim ser As New XmlSerializer(objectToSerialize.[GetType]())
        ser.Serialize(xmlWriter, RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(objectToSerialize)), namespaces)
        xmlWriter.Flush()
        stream.Flush()
        stream.Position = 0L
        xmlDocument.Load(stream)
        Return xmlDocument
    End Function

    Public Function DeserializarNFe(Of T As {Class, New})(ByVal xml As String) As T
        Dim xmlDocument As XmlDocument = New XmlDocument()
        Dim obj1 As T = Nothing

        Try
            Dim obj2 As T = New T()
            Dim stringReader As StringReader = New StringReader(xml)
            obj2 = CType(New XmlSerializer(obj2.[GetType]()).Deserialize(CType(stringReader, TextReader)), T)
            Return obj2
        Catch ex As Exception
            ' ProjectData.SetProjectError(ex)
            Throw
        End Try
    End Function

    Public Function LoadFromXMLString(Of T)(ByVal xmlText As String) As T
        Dim stringReader = New System.IO.StringReader(xmlText)
        Dim serializer = New XmlSerializer(GetType(T))
        Return CType(serializer.Deserialize(stringReader), T)
    End Function

    Function carrega_Sefez_aut_campo(ByVal cUF As String, ByVal modelo As String, ByVal tipo_ser As String) As String
        Dim sefez_aut As String, campo As String


        If modelo = "55" And tipo_ser = "1" Then
            campo = "SefazAutNFe"
        End If
        If modelo = "55" And tipo_ser = "9" Then
            campo = "SefazAutNFeCont"
        End If
        If modelo = "65" And tipo_ser = "1" Then
            campo = "SefazAut"
        End If
        If modelo = "65" And tipo_ser = "9" Then
            campo = "SefazAut"
        End If
        If modelo = "55" And tipo_ser = "6" Then
            campo = "SefazAutNFeCont"
        End If

        Return campo
    End Function
    Function carrega_Sefez_aut(ByVal cUF As String, ByVal modelo As String, ByVal tipo_ser As String) As String
        Dim sefez_aut As String, campo As String

        Dim name_space As String
        Dim stringBuilder As StringBuilder = New StringBuilder()
        stringBuilder.Append("Select * from SefazUFs where CodUF = '" & cUF & "'")



        conectar_sqlite()

        Dim SQLcommand As SQLiteCommand

        SQLcommand = Conn.CreateCommand

        SQLcommand.CommandText = stringBuilder.ToString

        dr = SQLcommand.ExecuteReader()


        If modelo = "55" And tipo_ser = "1" Then
            campo = "SefazAutNFe"
        End If
        If modelo = "55" And tipo_ser = "9" Then
            campo = "SefazAutNFeCont"
        End If
        If modelo = "65" And tipo_ser = "1" Then
            campo = "SefazAut"
        End If
        If modelo = "65" And tipo_ser = "9" Then
            campo = "SefazAut"
        End If
        If modelo = "55" And tipo_ser = "6" Then
            campo = "SefazAutNFeCont"
        End If

        While dr.Read()


            sefez_aut = dr("" & campo & "")


        End While

        dr.Close()
        SQLcommand.Dispose()
        Conn.Close()

        Return sefez_aut
    End Function
    Function carrega_wsdl(ByVal servico As String, ByVal cuf As String, ByVal modelo As String, Optional tipo As String = "1", Optional versao As String = "4.00", Optional ambiente As String = "1") As Dictionary(Of String, String)
        Dim dictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim par As Boolean = False
        Dim sefez_aut As String = carrega_Sefez_aut(cuf, modelo, tipo)

        Dim name_space As String
        Dim stringBuilder As StringBuilder = New StringBuilder()
        stringBuilder.Append("Select ")
        stringBuilder.Append("U.Servico, U.Versao, U.Servico, U.SefazAut, ")
        stringBuilder.Append("U.Url, U.Modelo, U.Ambiente, ")
        stringBuilder.Append("S.CodUF, S.CodUF ")
        stringBuilder.Append("From Url U ")
        stringBuilder.Append("Inner Join SefazUFs S ")
        stringBuilder.Append("On W.SefazAut = S.SefazAut ")
        stringBuilder.Append("where U.SefazAut = '" & sefez_aut & "' and U.Servico = '" & servico & "' and U.Versao = '" & versao & "' and U.Modelo = '" & modelo & "' and U.Ambiente = '" & ambiente & "'")


        conectar_sqlite()

        Dim SQLcommand As SQLiteCommand

        SQLcommand = Conn.CreateCommand

        SQLcommand.CommandText = stringBuilder.ToString

        dr = SQLcommand.ExecuteReader()


        While dr.Read()

            name_space = dr("SoapAction")
            name_space = name_space.Substring(0, name_space.Length - Len(dr("NomeMetodo")) - 1)
            dictionary.Add("url", dr("url"))
            dictionary.Add("NomeClasse", dr("NomeClasse"))
            dictionary.Add("NomeMetodo", dr("NomeMetodo"))
            dictionary.Add("coduf", dr("CodUF"))
            dictionary.Add("name_space", name_space)
            par = True

        End While

        dr.Close()
        SQLcommand.Dispose()
        Conn.Close()

        If par = False Then
            dictionary.Add("erro", "Nenhum informação localizada no banco !")
        End If

        Return dictionary


    End Function

    Function carrega_url(ByVal servico As String, ByVal cuf As String, ByVal modelo As String, Optional tipo As String = "1", Optional versao As String = "4.00", Optional ambiente As String = "1") As String
        Dim ret As String
        Dim par As Boolean = False
        Dim sefez_aut As String = carrega_Sefez_aut(cuf, modelo, tipo)

        Dim sefez_autcampo As String = carrega_Sefez_aut_campo(cuf, modelo, tipo)

        Dim stringBuilder As StringBuilder = New StringBuilder()
        stringBuilder.Append("Select ")
        stringBuilder.Append("U.Servico, U.Versao, U.Servico, U.SefazAut, ")
        stringBuilder.Append("U.Url, U.Modelo, U.Ambiente, ")
        '  stringBuilder.Append("W.NomeClasse, W.NomeMetodo, W.Servico, W.SoapAction, ")
        stringBuilder.Append("S.CodUF, S.CodUF ")
        stringBuilder.Append("From Url U ")
        '  stringBuilder.Append("Inner Join SefazWSUrls W ")
        ' stringBuilder.Append("On U.Servico = W.Servico ")
        sefez_autcampo = "S." & sefez_autcampo

        stringBuilder.Append("Inner Join SefazUFs S ")
        stringBuilder.Append("On U.SefazAut = " & sefez_autcampo & " ")
        stringBuilder.Append("where U.SefazAut = '" & sefez_aut & "' and U.Servico = '" & servico & "' and U.Versao = '" & versao & "' and U.Modelo = '" & modelo & "' and U.Ambiente = '" & ambiente & "'")


        conectar_sqlite()

        Dim SQLcommand As SQLiteCommand

        SQLcommand = Conn.CreateCommand

        SQLcommand.CommandText = stringBuilder.ToString

        dr = SQLcommand.ExecuteReader()


        While dr.Read()


            ret = dr("url")

        End While



        dr.Close()
        SQLcommand.Dispose()
        Conn.Close()


        Return ret


    End Function
    Public Function processarWS_nfe(Of T As {Class, New})(ByVal data As Dictionary(Of String, String), ByVal url As String, ByVal tipo_ret As String)
        Dim obj As T
        Dim retConsSitNfe2 As retConsSitNFe
        Dim retConsReciNfe As retConsSitNFe
        Dim retEnvEvento As retEnvEvento
        Dim retInutNfe As procInutNFe
        Dim XmlRetornoSefaz As New XmlDocument()
        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\WS_Cofing.ini")

        If arquivoIni.KeyExists("HOSTADDRESS", "Settings") = False Then
            arquivoIni.Write("HOSTADDRESS", "http://192.168.254.2:8900", "Settings")
        End If

        Dim str As String = arquivoIni.Read("HOSTADDRESS", "Settings")
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(CObj(data)))
        Dim uriString As String = String.Format("{0}/api/" & url & "", CObj(str))
        Dim uri As Uri = New Uri(uriString)
        '   mdlGeral.CriarArquivoLog("Enviar arquivo para URL: " & uriString, "", "", False, False, False)
        Dim jsonDataBytes As Byte() = bytes
        Dim ret As String = SendRequest(uri, jsonDataBytes, "")
        '  mdlGeral.CriarLog("Retorno WSLinear: " & Left1, NameOf(clsNFCe), NameOf(processarWS), False, False, False)


        If ret Is Nothing Then
            Exit Function
            'mdlGeral.CriarLog("Erro=> retWS.TipoRetorno = 2 (Sem conexão com o wslinear)", NameOf(clsNFCe), NameOf(processarWS), False, False, False)
        End If



        If ret.Substring(1, 1) = "<" Then
            ret = ret.Substring(1, ret.Length - 2)

            XmlRetornoSefaz.LoadXml(ret)

            If tipo_ret = "statusnf" Then

                retConsSitNfe2 = DeserializarNFe(Of retConsSitNFe)(XmlRetornoSefaz.OuterXml)

                Dim xmllist As System.Xml.XmlNodeList
                xmllist = XmlRetornoSefaz.GetElementsByTagName("protNFe")

                For Each xmlnode In xmllist
                    retConsSitNfe2.xmlprot = xmlnode.OuterXml
                Next

                xmllist = XmlRetornoSefaz.GetElementsByTagName("procEventoNFe")
                For Each xmlnode In xmllist
                    retConsSitNfe2.xmlprocevent = xmlnode.OuterXml
                Next

                Return retConsSitNfe2
                Exit Function
            End If

            If tipo_ret = "consultaretnf" Then
                retConsReciNfe = DeserializarNFe(Of retConsSitNFe)(XmlRetornoSefaz.OuterXml)
                Dim xmllist As System.Xml.XmlNodeList
                xmllist = XmlRetornoSefaz.GetElementsByTagName("protNFe")
                For Each xmlnode In xmllist
                    retConsReciNfe.xml = xmlnode.OuterXml
                Next

                Return retConsReciNfe
                Exit Function
            End If

            If tipo_ret = "inutilizanf" Then
                retInutNfe = DeserializarNFe(Of procInutNFe)(XmlRetornoSefaz.OuterXml)
                Dim xmllist As System.Xml.XmlNodeList
                xmllist = XmlRetornoSefaz.GetElementsByTagName("retInutNFe")
                For Each xmlnode In xmllist
                    retInutNfe.xml = xmlnode.OuterXml
                Next

                Return retInutNfe
                Exit Function
            End If

            If tipo_ret = "eventonf" Then
                retEnvEvento = DeserializarNFe(Of retEnvEvento)(XmlRetornoSefaz.OuterXml)
                Dim xmllist As System.Xml.XmlNodeList
                xmllist = XmlRetornoSefaz.GetElementsByTagName("retEvento")
                For Each xmlnode In xmllist
                    retEnvEvento.xml_ret.Add(xmlnode.OuterXml)
                Next

                Return retEnvEvento
                Exit Function
            End If

            obj = DeserializarNFe(Of T)(XmlRetornoSefaz.OuterXml)

            Return obj
        Else

            Return ret

        End If

    End Function

    Public Function processarWS_nfe4(ByVal data As Dictionary(Of String, String), ByVal url As String) As String


        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\WS_Cofing.ini")

        If arquivoIni.KeyExists("HOSTADDRESS", "Settings") = False Then
            arquivoIni.Write("HOSTADDRESS", "http://192.168.254.2:8900", "Settings")
        End If

        Dim str As String = arquivoIni.Read("HOSTADDRESS", "Settings")
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(CObj(data)))
        Dim uriString As String = String.Format("{0}/api/" & url & "", CObj(str))
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

    Public Function processarWS_nfe4_list(ByVal data As Dictionary(Of String, String), ByVal url As String) As Dictionary(Of String, String)
        Dim Retarquivo As Dictionary(Of String, String) = New Dictionary(Of String, String)

        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\WS_Cofing.ini")

        If arquivoIni.KeyExists("HOSTADDRESS", "Settings") = False Then
            arquivoIni.Write("HOSTADDRESS", "http://192.168.254.2:8900", "Settings")
        End If

        Dim str As String = arquivoIni.Read("HOSTADDRESS", "Settings")
        ' Dim str As String = "http://localhost:8900"
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(CObj(data)))
        Dim uriString As String = String.Format("{0}/api/" & url & "", CObj(str))
        Dim uri As Uri = New Uri(uriString)
        '   mdlGeral.CriarArquivoLog("Enviar arquivo para URL: " & uriString, "", "", False, False, False)
        Dim jsonDataBytes As Byte() = bytes
        Retarquivo = SendRequest_list(uri, jsonDataBytes, "")
        '  mdlGeral.CriarLog("Retorno WSLinear: " & Left1, NameOf(clsNFCe), NameOf(processarWS), False, False, False)

        If Retarquivo Is Nothing Then
            Retarquivo.Add("status", "Sem retorno do Host local !")
            Return Retarquivo
        Else
            Return Retarquivo
        End If

    End Function

    Function DecompressGZip(ByVal textBase64 As String) As String
        Dim buffer As Byte() = Convert.FromBase64String(textBase64)
        Dim byteArray As Byte()

        Using memoryStream As MemoryStream = New MemoryStream()
            memoryStream.Write(buffer, 0, buffer.Length)

            Using gzipStream As GZipStream = New GZipStream(CType(memoryStream, Stream), CompressionMode.Decompress, True)
                memoryStream.Position = 0L
                byteArray = ToByteArray(CType(gzipStream, Stream))
            End Using
        End Using

        Return Encoding.UTF8.GetString(byteArray)
    End Function

    Function DecompressGZip(ByVal bytes As Byte()) As String
        Dim byteArray As Byte()

        Using memoryStream As MemoryStream = New MemoryStream()
            memoryStream.Write(bytes, 0, bytes.Length)

            Using gzipStream As GZipStream = New GZipStream(CType(memoryStream, Stream), CompressionMode.Decompress, True)
                memoryStream.Position = 0L
                byteArray = ToByteArray(CType(gzipStream, Stream))
            End Using
        End Using

        Return Encoding.UTF8.GetString(byteArray)
    End Function

    Function CompresGZip(ByVal texto As String) As String
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(texto)
        Dim byteArray As Byte()

        Using memoryStream As MemoryStream = New MemoryStream()

            Using gzipStream As GZipStream = New GZipStream(CType(memoryStream, Stream), CompressionMode.Compress, True)
                gzipStream.Write(bytes, 0, bytes.Length)
            End Using

            memoryStream.Position = 0L
            byteArray = ToByteArray(CType(memoryStream, Stream))
        End Using

        Return Convert.ToBase64String(byteArray)
    End Function

    Private Function ToByteArray(ByVal stream As Stream) As Byte()
        Dim num1 As Integer = 0
        Dim byteList As List(Of Byte) = New List(Of Byte)()
        Dim buffer As Byte() = New Byte(131071) {}
        Dim num2 As Integer

        While (CSharpImpl.__Assign(num2, stream.Read(buffer, 0, 131072))) > 0
            num1 += num2

            For index As Integer = 0 To num2 - 1
                byteList.Add(buffer(index))
            Next
        End While

        Return byteList.ToArray()
    End Function

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class

    Public Function Extenso(ByVal nValor As Double) As String
        Dim strArray1 As String() = New String(4) {}
        Dim strArray2 As String() = New String(4) {}
        Dim strArray3 As String() = New String(19) {Nothing, "um ", "dois ", "tres ", "quatro ", "cinco ", "seis ", "sete ", "oito ", "nove ", "dez ", "onze ", "doze ", "treze ", "quatorze ", "quinze ", "dezesseis ", "dezessete ", "dezoito ", "dezenove "}
        Dim strArray4 As String() = New String(9) {Nothing, "dez ", "vinte ", "trinta ", "quarenta ", "cinquenta ", "sessenta ", "setenta ", "oitenta ", "noventa "}
        Dim strArray5 As String() = New String(9) {Nothing, "cento ", "duzentos ", "trezentos ", "quatrocentos ", "quinhentos ", "seiscentos ", "setecentos ", "oitocentos ", "novecentos "}
        Dim str1 As String = Strings.Format(CObj(nValor), "0000000000.00")
        strArray1(1) = Strings.Mid(str1, 2, 3)
        strArray1(2) = Strings.Mid(str1, 5, 3)
        strArray1(3) = Strings.Mid(str1, 8, 3)
        strArray1(4) = "0" & Strings.Mid(str1, 12, 2)
        Dim index As Integer = 1

        Do
            Dim str2 As String = strArray1(index)
            Dim num As Integer

            If Conversion.Val(str2) < 10.0 Then
                num = 1
            ElseIf Conversion.Val(str2) < 100.0 Then
                num = 2
            ElseIf Conversion.Val(str2) < 1000.0 Then
                num = 3
            End If

            If num = 3 Then

                If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Right(str2, 2), "00", False) <> 0 Then
                    strArray2(index) = strArray2(index) & strArray5(Microsoft.VisualBasic.CompilerServices.Conversions.ToInteger(Strings.Left(str2, 1))) & "e "
                    num = 2
                Else
                    strArray2(index) = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(CObj(strArray2(index)), Interaction.IIf(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Left(str2, 1), "1", False) = 0, CObj("cem "), CObj(strArray5(Microsoft.VisualBasic.CompilerServices.Conversions.ToInteger(Strings.Left(str2, 1)))))))
                End If
            End If

            If num = 2 Then

                If Conversion.Val(Strings.Right(str2, 2)) < 20.0 Then
                    strArray2(index) = strArray2(index) & strArray3(Microsoft.VisualBasic.CompilerServices.Conversions.ToInteger(Strings.Right(str2, 2)))
                Else
                    strArray2(index) = strArray2(index) & strArray4(Microsoft.VisualBasic.CompilerServices.Conversions.ToInteger(Strings.Mid(str2, 2, 1)))

                    If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Right(str2, 1), "0", False) <> 0 Then
                        strArray2(index) = strArray2(index) & "e "
                        num = 1
                    End If
                End If
            End If

            If num = 1 Then strArray2(index) = strArray2(index) + strArray3(Microsoft.VisualBasic.CompilerServices.Conversions.ToInteger(Strings.Right(str2, 1)))

            If True Then
                index += 1
            End If

        Loop While index <= 4

        Dim str3 As String

        If Conversion.Val(strArray1(1) & strArray1(2) & strArray1(3)) = 0.0 And Conversion.Val(strArray1(4)) <> 0.0 Then
            str3 = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(CObj(strArray2(4)), Interaction.IIf(Conversion.Val(strArray1(4)) = 1.0, CObj("centavo"), CObj("centavos"))))
        Else
            Dim str2 As String = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(CObj(""), Interaction.IIf(Conversion.Val(strArray1(1)) <> 0.0, Microsoft.VisualBasic.CompilerServices.Operators.AddObject(CObj(strArray2(1)), Interaction.IIf(Conversion.Val(strArray1(1)) > 1.0, CObj("milhões "), CObj("milhão "))), CObj(""))))
            str3 = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(CObj(Microsoft.VisualBasic.CompilerServices.Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(CObj(((If(Conversion.Val(strArray1(2) & strArray1(3)) <> 0.0, Microsoft.VisualBasic.CompilerServices.Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(CObj(str2), Interaction.IIf(Conversion.Val(strArray1(2)) <> 0.0, CObj((strArray2(2) & "mil ")), CObj("")))), str2 & "de ")) & strArray2(3))), Interaction.IIf(Conversion.Val(strArray1(1) & strArray1(2) & strArray1(3)) = 1.0, CObj("real "), CObj("reais "))))), Interaction.IIf(Conversion.Val(strArray1(4)) <> 0.0, Microsoft.VisualBasic.CompilerServices.Operators.AddObject(CObj(("e " & strArray2(4))), Interaction.IIf(Conversion.Val(strArray1(4)) = 1.0, CObj("centavo"), CObj("centavos"))), CObj(""))))
        End If

        Return str3
    End Function

    Public Function funcFormatData(ByVal pString As String, ByVal pCorrect As Boolean) As String
        Try
            Dim str As String = Regex.Replace(pString, "[^0-9 ]", "")
            If str.Length = 6 And pCorrect Then str = If(str.Substring(4).CompareTo("18") <= 0, str.Substring(0, 4) & "20" & str.Substring(4), str.Substring(0, 4) & "19" & str.Substring(4))
            If str.Length > 2 Then str = str.Substring(0, 2) & "/" & str.Substring(2)
            If str.Length > 5 Then str = str.Substring(0, 5) & "/" & str.Substring(5)
            Return str
        Catch
            Return String.Empty
        End Try
    End Function

    Private Function funcFormatCNPJ(ByVal pCNPJ As String) As String
        Return Convert.ToUInt64(pCNPJ).ToString("00\.000\.000\/0000\-00")
    End Function

    Private Function funcFormatCPF(ByVal pCPF As String) As String
        Return Convert.ToUInt64(pCPF).ToString("000\.000\.000\-00")
    End Function

    Public Function SemFormat(ByVal pCodigo As String) As String
        Return pCodigo.Replace(".", String.Empty).Replace("-", String.Empty).Replace("/", String.Empty).Replace(" ", String.Empty).Trim()
    End Function

    Public Function funcClearSpecialCaracter(ByVal pInput As String) As String
        Dim str1 As String = pInput

        Try
            Dim strArray1 As String() = New String(50) {"ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Á", "É", "Í", "Ó", "Ú", "Ý", "à", "è", "ì", "ò", "ù", "À", "È", "Ì", "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "Ä", "Ë", "Ï", "Ö", "Ü", "Ã", "Õ", "Ñ", "â", "ê", "î", "ô", "û", "Â", "Ê", "Î", "Ô", "Û"}
            Dim strArray2 As String() = New String(50) {"c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "A", "O", "N", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U"}

            For index As Integer = 0 To strArray1.Length - 1
                str1 = str1.Replace(strArray1(index), strArray2(index))
            Next

            Dim str2 As String = str1.Replace(Environment.NewLine, " ")
            Dim strArray3 As String() = New String(15) {".", ",", "-", ":", "(", ")", "ª", "|", "\\", "\", "°", "-", "/", "//", """", "."}

            For Each oldValue As String In strArray3
                str2 = str2.Replace(oldValue, "")
            Next

            Dim str3 As String = str2.Replace("^\s +", "").Replace("\s +$", "").Replace("\s +", " ")

            While str3.Contains("  ")
                str3 = str3.Replace("  ", " ")
            End While

            Return str3.Trim()
        Catch
            Return pInput
        End Try
    End Function

    Public Function Moeda(ByVal Valor As Double, Optional ByVal Casas As Integer = 2) As Double
        Try
            Return Format(Valor, "###0.00")
            ' Return Convert.ToDouble(String.Format("{0:N" & CObj(Casas) & "}", CObj(Valor)))
        Catch ex As Exception
            Return 0.0
        End Try
    End Function


    Public Function pesquisa_cep_online(ByVal cep As String)
        Try
            Dim ret As String
            Dim request As WebRequest = WebRequest.Create("https://viacep.com.br/ws/" & cep & "/xml/")
            request.Credentials = CredentialCache.DefaultCredentials
            Dim response As WebResponse = request.GetResponse()
            Console.WriteLine((CType(response, HttpWebResponse)).StatusDescription)

            Using dataStream As Stream = response.GetResponseStream()
                Dim reader As StreamReader = New StreamReader(dataStream)
                ret = reader.ReadToEnd()
            End Using

            response.Close()

            Return ret
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Public Function alterar_digestvalue(ByVal xml As String)


        Dim xmlDoc As XmlDocument = New XmlDocument()
        Dim xnList As XmlNodeList = xmlDoc.GetElementsByTagName("Reference")
        Dim cer As String, cer2 As String

        xmlDoc.LoadXml(xml)

        For Each xn As XmlNode In xnList
            cer = xn.InnerText
        Next

        Dim xnList2 As XmlNodeList = xmlDoc.GetElementsByTagName("infProt")
        For Each xn As XmlNode In xnList2
            cer2 = xn("digVal").InnerText
        Next

        Dim conte As String = xmlDoc.OuterXml
        conte = conte.Replace("<DigestValue>" & cer & "</DigestValue>", "<DigestValue>" & cer2 & "</DigestValue>")

        Return conte


    End Function


    Public Function processarWS_host(ByVal data As Dictionary(Of String, String)) As String

        ' Dim str As String = "http://localhost:31473/"
        Dim str As String = "http://nfesjp.online"
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(CObj(data)))
        Dim uriString As String = String.Format("{0}/api/licenca/Consulta", CObj(str))


        Dim uri As Uri = New Uri(uriString)
        '   mdlGeral.CriarArquivoLog("Enviar arquivo para URL: " & uriString, "", "", False, False, False)
        Dim jsonDataBytes As Byte() = bytes
        Dim ret As String = SendRequest(uri, jsonDataBytes, "")
        '  mdlGeral.CriarLog("Retorno WSLinear: " & Left1, NameOf(clsNFCe), NameOf(processarWS), False, False, False)

        If ret Is Nothing Then
            ret = "Sem retorno do Host nfesjp !"
        Else
            Return ret
        End If

    End Function
End Module






