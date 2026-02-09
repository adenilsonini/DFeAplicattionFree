Imports MessagingToolkit.QRCode.Codec
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Windows.Forms
Imports System.Xml

Imports System.Net
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports Newtonsoft.Json


Module Funcoes_linear
    Public iRetTrImp As Integer

    Public cAux As String
    Private iRet As Integer
    Private strXml As String
    Private strTextoVias As String
    Private cPortaImp As String
    Private TPAmbiente As Integer
    Private versao_layout As String
    Private linhasPorPagina As Integer

    Private linhaAtual As Integer
    Private paginaAtual As Integer
    Private margemEsq As Single
    Private margemSup As Single
    Private margemDir As Single
    Private margemInf As Single
    Private caneta As Pen
    Private fonteTitulo As Font
    Private fonteRodape As Font
    Private fonteNormal As Font
    Private fonteColuna As Font
    Private tipoFonte As String
    Private ArquivoFonte As StreamReader
    Private mCaminhoLogo As String
    Private mReduzido As Boolean
    Public Function RemoveXMLDeclaration(ByVal strXML As String) As Object
        Dim obj As Object

        Try
            Dim xmlDocument As XmlDocument = New XmlDocument()
            xmlDocument.LoadXml(strXML)

            Try

                For Each oldChild As XmlNode In CType(xmlDocument, XmlNode)
                    If oldChild.NodeType = XmlNodeType.XmlDeclaration Then xmlDocument.RemoveChild(oldChild)
                Next

            Finally
                Dim enumerator As IEnumerator
                If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
            End Try

            obj = CObj(xmlDocument.InnerXml)
        Catch ex As Exception

            obj = CObj("")

        End Try

        Return obj
    End Function

    Public Sub CriarLog(ByVal texto As String, Optional ByVal Modulo As String = "", Optional ByVal Rotina As String = "", Optional ByVal Principal As Boolean = False, Optional ByVal TrataErro As Boolean = False, Optional ByVal Rejeicao As Boolean = False)
        Try

            If CUInt(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(texto, "", False)) > 0UI And Not TrataErro Then

                If Principal Then

                    If CUInt(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Modulo, "", False)) > 0UI And CUInt(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Rotina, "", False)) > 0UI Then
                        texto = vbCrLf & vbCrLf & Strings.Space(24) & vbTab & ">>> " & Modulo & " " & Rotina & " - " + Strings.UCase(texto) & vbCrLf
                    ElseIf CUInt(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Modulo, "", False)) > 0UI And Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Rotina, "", False) = 0 Then
                        texto = vbCrLf & vbCrLf & Strings.Space(24) & vbTab & ">>> " & Modulo & " - " + Strings.UCase(texto) & vbCrLf
                    ElseIf Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Modulo, "", False) = 0 And CUInt(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Rotina, "", False)) > 0UI Then
                        texto = vbCrLf & vbCrLf & Strings.Space(24) & vbTab & ">>> " & Rotina & " - " + Strings.UCase(texto) & vbCrLf
                    Else
                        texto = vbCrLf & vbCrLf & Strings.Space(24) & vbTab & ">>> " + Strings.UCase(texto) & vbCrLf
                    End If
                ElseIf CUInt(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Modulo, "", False)) > 0UI And CUInt(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Rotina, "", False)) > 0UI Then
                    texto = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(DateTime.Now) + Strings.Space(3) & vbTab + Strings.Space(3) & "< " & Modulo & " " & Rotina & " - " & texto & " >"
                ElseIf CUInt(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Modulo, "", False)) > 0UI And Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Rotina, "", False) = 0 Then
                    texto = Convert.ToString(DateTime.Now) + Strings.Space(3) & vbTab + Strings.Space(3) & "< " & Modulo & " - " & texto & " >"
                ElseIf Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Modulo, "", False) = 0 And CUInt(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Rotina, "", False)) > 0UI Then
                    texto = Convert.ToString(DateTime.Now) + Strings.Space(3) & vbTab + Strings.Space(3) & "< " & Rotina & " - " & texto & " >"
                Else
                    texto = Convert.ToString(DateTime.Now) + Strings.Space(3) & vbTab + Strings.Space(3) & "< " & texto & " >"
                End If
            End If

            If Rejeicao Then
                Dim str As String = texto
                texto = vbCrLf & Strings.Space(24) & vbTab & "-----------------------***  REJEICAO ***---------------------------" & vbCrLf & texto
                texto = Convert.ToString(DateTime.Now) + Strings.Space(3) & vbTab + Strings.Space(3) & str
                texto = texto & vbCrLf & Strings.Space(24) & vbTab & "--------------------------------------------------------------------" & vbCrLf
            End If

            If TrataErro Then
                Dim str As String = texto
                texto = vbCrLf & Strings.Space(24) & vbTab & "-----------------------***  ERRO ***---------------------------" & vbCrLf
                texto = Convert.ToString(DateTime.Now) + Strings.Space(3) & vbTab + Strings.Space(3) & str
                texto = texto & vbCrLf & Strings.Space(24) & vbTab & "--------------------------------------------------------------------" & vbCrLf
            End If

            Dim path As String
            Dim str1 As String

            If System.IO.File.Exists(Application.StartupPath & "\LOGS") Then
                path = Application.StartupPath & "\LOGS"
                str1 = "LinearNFCe.log"
            Else
                str1 = "LinearNFCe" & Strings.Format(CObj(DateTime.Now), "dd-MM-yyyy") & ".log"
                path = AppDomain.CurrentDomain.BaseDirectory & "Logs\" + Strings.Format(CObj(DateTime.Now.Year), "0000") & "\" + Strings.Format(CObj(DateTime.Now.Month), "00")
            End If

            If Not Directory.Exists(path) Then Directory.CreateDirectory(path)
            If Not System.IO.File.Exists(path & "\" & str1) Then System.IO.File.CreateText(path & "\" & str1).Close()
            Dim streamWriter As StreamWriter = New StreamWriter(path & "\" & str1, True)
            streamWriter.WriteLine(texto)
            streamWriter.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Function ExisteConexaoInternet(ByVal url As String) As Boolean
        Dim webRequest1 As WebRequest = WebRequest.Create(New Uri(url))
        Dim webRequest2 As WebRequest
        Dim flag As Boolean

        Try
            webRequest1.GetResponse().Close()
            webRequest2 = CType(Nothing, WebRequest)
            flag = True
        Catch ex As Exception
            webRequest2 = CType(Nothing, WebRequest)
            flag = False
        End Try

        Return flag
    End Function

    Public Function StringToHex(ByVal StrToHex As String) As String
        Dim str As String = ""
        Dim num1 As Long = CLng(Strings.Len(StrToHex))
        Dim num2 As Long = 1

        While num2 <= num1
            Dim Expression As String = Conversion.Hex(Strings.Asc(Strings.Mid(StrToHex, (CInt(num2)), 1)))
            If Strings.Len(Expression) = 1 Then Expression = "0" & Expression
            str += Expression
            num2 += 1
        End While

        Return Strings.LCase(str)
    End Function

    Function HexToString(ByVal hex As String) As String
        Dim text As New System.Text.StringBuilder(hex.Length \ 2)
        For i As Integer = 0 To hex.Length - 2 Step 2
            text.Append(Chr(Convert.ToByte(hex.Substring(i, 2), 16)))
        Next
        Return text.ToString
    End Function

    Public Function CalculateSHA1(ByVal text As String, ByVal enc As Encoding) As String
        Try
            Return BitConverter.ToString(New SHA1CryptoServiceProvider().ComputeHash(enc.GetBytes(text))).Replace("-", "")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function CalculateSHA1(ByVal text As String) As String
        '''''''''''exemplo calcular Qrcode NFCe
        ''''''''para NFCe normal|chave NFCe|Versão do QR Code: 2|Identificação do Ambiente: 1 (Produção)|Identificação do CSC: 1 (informar sem os zeros não significativos) + o Numero CSC
        ''''CalculateSHA1("31190410962965000119650010000000161000000140|2|1|1877cc0059175a344ee8598297cfed2ca")

        ''''''''para NFCe normal|chave NFCe|Versão do QR Code: 2|Identificação do Ambiente: 1 (Produção)|Dia da data de emissão da NFC-e|Valor Total da NFC-e|DigestValue da NFC-e|Identificação do CSC: 1 (informar sem os zeros não significativos) + o Numero CSC
        'CalculateSHA1("31190710962965000119650010000179779000190476|2|1|12|10.50|" & StringToHex("tIfv3Km34pXcW2jwVxRxc9yCYGc=") & "|1877cc0059175a344ee8598297cfed2ca")

        Try
            Return BitConverter.ToString(New SHA1CryptoServiceProvider().ComputeHash(Encoding.[Default].GetBytes(text))).Replace("-", "")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function CalculaDigestValueXML_MDL(ByVal strXML As String, Optional ByVal bNFCe As Boolean = False) As String
        If bNFCe Then
            Dim xmlDocument1 As XmlDocument = New XmlDocument()
            xmlDocument1.LoadXml(strXML)
            xmlDocument1.Save(Application.StartupPath & "\xmlcorrigido.xml")
            Dim xmlDocument2 As XmlDocument = New XmlDocument()
            xmlDocument2.Load(Application.StartupPath & "\xmlcorrigido.xml")
            strXML = "<infNFe>" & xmlDocument2.GetElementsByTagName("NFe").Item(0).FirstChild.InnerXml & "</infNFe>"
        End If

        Return Convert.ToString(GerarDigestValueXML(strXML))

    End Function

    Public Function GerarDigestValueXML(ByVal strXML As String) As Object
        Dim base64String As Object

        Try
            Dim xmlDocument As XmlDocument = New XmlDocument()
            xmlDocument.LoadXml(strXML)
            CriarLog("xmlHAsh => " & strXML, "", "", False, False, False)
            Dim dsigC14Ntransform As XmlDsigC14NTransform = New XmlDsigC14NTransform()
            dsigC14Ntransform.LoadInput(CObj(xmlDocument))
            base64String = CObj(Convert.ToBase64String(SHA1.Create().ComputeHash(CType(dsigC14Ntransform.GetOutput(GetType(Stream)), Stream))))
        Catch ex As Exception

        End Try

        Return base64String
    End Function

    Public Function Base64Encode(ByVal plainText As String) As String
        Return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText))
    End Function

    Public Function Base64Decode(ByVal base64EncodedData As String) As String
        Return Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedData))
    End Function


    Public Function fFormata(ByVal texto As String, ByVal Caracter As String, ByVal Posicao As String, ByVal tamanho As Integer, Optional ByVal Maiusculo As Boolean = True, Optional ByVal RemoveCaracter As Boolean = False) As String

        Dim str1 As String

        Dim CharCode As Integer = 0
        Do
            texto = Strings.Replace(texto, Convert.ToString(Strings.Chr(CharCode)), " ", 1, -1, CompareMethod.Binary)
            CharCode += 1
        Loop While CharCode <= 31

        If RemoveCaracter Then
            texto = Strings.Replace(texto, ",", "", 1, -1, CompareMethod.Binary)
            texto = Strings.Replace(texto, ".", "", 1, -1, CompareMethod.Binary)
        End If

        If Maiusculo Then texto = Strings.UCase(texto)
        Dim str2 As String = If(Strings.Trim(texto), "")
        Posicao = Strings.UCase(Posicao)

        If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Posicao, "D", False) = 0 Then
            Dim str3 As String = If(Strings.Len(texto) >= tamanho, New String(Strings.ChrW(Strings.AscW(Caracter)), tamanho), New String(Strings.ChrW(Strings.AscW(Caracter)), (tamanho - Strings.Len(texto))))
            If tamanho > Strings.Len(str2) Then str2 = Strings.Trim(texto) & str3
            str2 = Strings.Left(str2, tamanho)
        End If

        If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Posicao, "E", False) = 0 Then
            Dim str3 As String = If(Strings.Len(texto) >= tamanho, New String(Strings.ChrW(Strings.AscW(Caracter)), tamanho), New String(Strings.ChrW(Strings.AscW(Caracter)), (tamanho - Strings.Len(texto))))
            If tamanho > Strings.Len(str2) Then str2 = str3 & texto
            str2 = Strings.Right(str2, tamanho)
        End If

        If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Posicao, "C", False) = 0 Then
            Dim count As Integer = (CInt(Math.Round((CDbl((tamanho - Strings.Len(texto))) / 2.0))))

            If tamanho > Strings.Len(str2) Then
                Dim Expression As String = New String(Strings.ChrW(Strings.AscW(Caracter)), count) & texto
                str2 = Expression & New String(Strings.ChrW(Strings.AscW(Caracter)), (tamanho - Strings.Len(Expression)))
            End If
        End If

        str1 = str2

        Return str1
    End Function

    Public Function CentimetrosParaCentesimasPolegada(ByVal cm As Double) As Integer
        Return (CInt(Math.Round(Math.Round((cm / 0.393701 * 100.0), MidpointRounding.AwayFromZero))))
    End Function

    Public Function RetMPDesc(ByVal CodMP As Integer) As String
        Dim str As String

        Select Case CodMP
            Case 1
                str = "Dinheiro"
            Case 2
                str = "Cheque"
            Case 3
                str = "Cartão de Crédito"
            Case 4
                str = "Cartão de Débito"
            Case 5
                str = "Crédito Loja"
            Case 10
                str = "Vale Alimentação"
            Case 11
                str = "Vale Refeição"
            Case 12
                str = "Vale Presente"
            Case 13
                str = "Vale Combustível"
            Case 99
                str = "Outros"
            Case Else
                str = "Outros"
        End Select

        Return str
    End Function

    Public Function gVgPt(ByVal sEntrada As Object, Optional ByVal bInvert As Boolean = False) As String
        Return If(Not Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.CompareObjectEqual(sEntrada, CObj(""), False), Operators.CompareObjectEqual(sEntrada, CObj("0.00"), False)), CObj(Not Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(sEntrada))))), (If(bInvert, Strings.Replace(Strings.Replace(Conversions.ToString(sEntrada), ",", "", 1, -1, CompareMethod.Binary), ".", ",", 1, -1, CompareMethod.Binary), Strings.Replace(Strings.Replace(Conversions.ToString(sEntrada), ".", "", 1, -1, CompareMethod.Binary), ",", ".", 1, -1, CompareMethod.Binary))), "0")
    End Function

    Public Function LeINI(ByVal section_name As String, ByVal key_name As String, ByVal default_value As String, Optional ByVal strFile As String = "") As String
        Dim lpReturnedString As StringBuilder = New StringBuilder(500)
        Dim lpFileName As String = If(Operators.CompareString(strFile.Trim(), "", False) <> 0, strFile, Application.StartupPath & "\pdvlinx.ini")
        GetPrivateProfileString(section_name, key_name, default_value, lpReturnedString, 500, lpFileName)
        Return lpReturnedString.ToString()
    End Function

    Public Function Trunca(ByVal vgValor As String, ByVal vgNumDecimais As Object) As Decimal
        Return Conversions.ToDecimal(Operators.DivideObject(CObj(Conversion.Int(Conversion.Val(Conversion.Str(Operators.MultiplyObject(CObj(vgValor), Operators.ExponentObject(CObj(10), vgNumDecimais)))))), Operators.ExponentObject(CObj(10), vgNumDecimais)))
    End Function

    Public Function RemoveTelefone(ByVal texto As String) As String
        texto = texto.Replace(",", "")
        texto = texto.Replace(".", "")
        texto = texto.Replace("-", "")
        texto = texto.Replace(" ", "")
        texto = texto.Replace(")", "")
        texto = texto.Replace("(", "")
        texto = texto.Replace("'", "")
        texto = texto.Replace(":", "")
        texto = texto.Replace("_", "")
        Return texto
    End Function

    Public Function RemoverAcentos(ByVal Texto As String) As String
        Dim comAcentos As String = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç"
        Dim semAcentos As String = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc"

        For i As Integer = 0 To comAcentos.Length - 1
            Texto = Texto.Replace(comAcentos(i).ToString(), semAcentos(i).ToString())
        Next

        Return Texto
    End Function
    Public Function ValidaCEP(ByRef cep As String) As Boolean
        cep = RemoveTelefone(cep)
        If cep.Length <> 8 OrElse cep = "00000000" Then Return False
        Return Regex.IsMatch(cep, "[0-9]{5}[0-9]{3}")
    End Function

    Public Function ValidaEmail(ByVal email As String) As Boolean
        Return Regex.IsMatch(email, "(?<user>[^@]+)@(?<host>.+)")
    End Function

    Public Function IsNumeric(ByVal StrNum As String) As Boolean
        Dim result As Double
        Return Double.TryParse(StrNum.Trim(), result)
    End Function

    Public Function SendRequest(ByVal uri As Uri, ByVal jsonDataBytes As Byte(), Optional ByVal Str_Authorization As String = "") As String
        Try
            Dim webRequest As WebRequest = webRequest.Create(uri)
            webRequest.ContentType = "application/json"
            webRequest.Method = "POST"

            If Operators.CompareString(Str_Authorization.Trim(), "", False) <> 0 Then
                webRequest.PreAuthenticate = True
                webRequest.Headers.Add("Authorization", Str_Authorization)
            End If

            '   Dim num As Integer = Conversions.ToInteger(mdlGeral.LeINI("WSLINEAR", "TIMEOUTWSLINEAR", "10000", ""))
            Dim num As Integer = 15000
            If num < 6000 Then num = 6000
            webRequest.Timeout = num

            Dim Left As String = "POST"

            If Operators.CompareString(Left, "POST", False) <> 0 AndAlso Operators.CompareString(Left, "DELETE", False) <> 0 Then

                If Operators.CompareString(Left, "GET", False) = 0 Then
                End If
            Else
                webRequest.ContentLength = CLng(jsonDataBytes.Length)
                Dim requestStream As Stream = webRequest.GetRequestStream()
                requestStream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
                requestStream.Close()
            End If


            Dim response As Net.HttpWebResponse = webRequest.GetResponse()
            Dim ret As String
            If response.StatusCode = Net.HttpStatusCode.OK Then
                Dim responseStream As IO.StreamReader = New IO.StreamReader(response.GetResponseStream())
                ret = responseStream.ReadToEnd()

                ret = JsonConvert.DeserializeObject(ret)

            End If
            response.Close()

            Return ret


        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Dim exception As Exception = ex
            ' mdlGeral.CriarLog("Erro: " & exception.Message & " // " + exception.StackTrace, NameOf(mdlGeral), NameOf(SendRequest), True, False, False)
            Return exception.Message
        End Try
    End Function

    Public Function SendRequest_list(ByVal uri As Uri, ByVal jsonDataBytes As Byte(), Optional ByVal Str_Authorization As String = "") As Dictionary(Of String, String)
        Dim json As Dictionary(Of String, String) = New Dictionary(Of String, String)

        Try

            Dim webRequest As WebRequest = webRequest.Create(uri)
            webRequest.ContentType = "application/json"
            webRequest.Method = "POST"

            If Operators.CompareString(Str_Authorization.Trim(), "", False) <> 0 Then
                webRequest.PreAuthenticate = True
                webRequest.Headers.Add("Authorization", Str_Authorization)
            End If

            '   Dim num As Integer = Conversions.ToInteger(mdlGeral.LeINI("WSLINEAR", "TIMEOUTWSLINEAR", "10000", ""))
            Dim num As Integer = 15000
            If num < 6000 Then num = 6000
            webRequest.Timeout = num

            Dim Left As String = "POST"

            If Operators.CompareString(Left, "POST", False) <> 0 AndAlso Operators.CompareString(Left, "DELETE", False) <> 0 Then

                If Operators.CompareString(Left, "GET", False) = 0 Then
                End If
            Else
                webRequest.ContentLength = CLng(jsonDataBytes.Length)
                Dim requestStream As Stream = webRequest.GetRequestStream()
                requestStream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
                requestStream.Close()
            End If


            Dim response As Net.HttpWebResponse = webRequest.GetResponse()
            Dim ret As String
            If response.StatusCode = Net.HttpStatusCode.OK Then
                Dim responseStream As IO.StreamReader = New IO.StreamReader(response.GetResponseStream())
                ret = responseStream.ReadToEnd()

                json = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(ret)

            End If
            response.Close()

            Return json


        Catch ex As Exception
            json.Add("status", "Erro rotina SendRequest_list: " & ex.Message)
            ' mdlGeral.CriarLog("Erro: " & exception.Message & " // " + exception.StackTrace, NameOf(mdlGeral), NameOf(SendRequest), True, False, False)
            Return json
        End Try
    End Function

   
    Public Function Enviar_Requisicao(ByVal data As Dictionary(Of String, String), ByRef Retorno As String, ByVal urlCompleta As String, Optional ByVal objPost As Object = Nothing) As Boolean
        Dim flag As Boolean

        Try
            Dim cookieContainer As CookieContainer = New CookieContainer()
            Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(urlCompleta), HttpWebRequest)
            httpWebRequest.Method = data("Method").ToString()
            httpWebRequest.ContentType = data("ContentType").ToString()
            If Operators.CompareString(data("token"), "", False) <> 0 Then httpWebRequest.Headers.Add("Authorization", data("token"))
            httpWebRequest.CookieContainer = cookieContainer
            httpWebRequest.Timeout = 8000
            Dim Left As String = data("Method")

            If Operators.CompareString(Left, "POST", False) <> 0 AndAlso Operators.CompareString(Left, "PUT", False) <> 0 Then

                If Operators.CompareString(Left, "DELETE", False) = 0 OrElse Operators.CompareString(Left, "GET", False) = 0 Then
                End If
            Else
                Dim s As String = JsonConvert.SerializeObject(RuntimeHelpers.GetObjectValue(objPost))
                Dim bytes As Byte() = Encoding.UTF8.GetBytes(s)
                ' mdlGeral.CriarLog("Json: " & s, "", "", False, False, False)
                httpWebRequest.ContentLength = CLng(bytes.Length)
                Dim requestStream As Stream = httpWebRequest.GetRequestStream()
                requestStream.Write(bytes, 0, bytes.Length)
                requestStream.Close()
            End If

            Using response As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
                Dim responseStream As Stream = response.GetResponseStream()
                Dim [end] As Object = CObj(New StreamReader(responseStream).ReadToEnd())
                responseStream.Close()
                Retorno = [end].ToString()

                Try
                    '  mdlGeral.CriarLog("Retorno Requisição Logs: " & Conversions.ToString(CInt(response.StatusCode)) & " - " + response.StatusDescription, "", "", False, False, False)
                Catch ex As Exception
                    ProjectData.SetProjectError(ex)
                    ' mdlGeral.CriarLog("Não foi possível gravar o status de retorno.", NameOf(mdlGeral), NameOf(Enviar_Requisicao), False, True, False)
                    ProjectData.ClearProjectError()
                End Try

                flag = True
            End Using

        Catch ex As WebException
            ProjectData.SetProjectError(CType(ex, Exception))
            Dim webException As WebException = ex

            If webException.Response.ContentLength <> 0L Then

                Using responseStream As Stream = webException.Response.GetResponseStream()

                    Using streamReader As StreamReader = New StreamReader(responseStream)
                        ''  mdlGeral.CriarLog("Erro: " & webException.Message & " - " + streamReader.ReadToEnd(), NameOf(mdlGeral), NameOf(Enviar_Requisicao), False, False, False)
                        Retorno = ""
                        flag = False
                        ProjectData.ClearProjectError()
                    End Using
                End Using
            Else
                ' mdlGeral.CriarLog("Erro: " & webException.Message, NameOf(mdlGeral), NameOf(Enviar_Requisicao), False, False, False)
                Retorno = ""
                flag = False
                ProjectData.ClearProjectError()
            End If

        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Dim exception As Exception = ex
            '  mdlGeral.CriarLog("Erro: " & exception.Message & vbCrLf + exception.StackTrace, NameOf(mdlGeral), NameOf(Enviar_Requisicao), False, False, False)
            Retorno = ""
            flag = False
            ProjectData.ClearProjectError()
        End Try

        Return flag
    End Function

    Public Function FormataTX(ByRef Relatorio As PrintPageEventArgs, ByVal strTexto As String, ByVal TamLetra As Integer, ByVal Bold As Integer, ByVal NewLine As Integer, fonteNormal As Font, posicaoDaLinha As Decimal) As Integer
      
        linhasPorPagina += CDbl(Relatorio.MarginBounds.Height) / CDbl(fonteNormal.GetHeight(Relatorio.Graphics)) - 10.0
        posicaoDaLinha += New Decimal(margemSup + CSng(linhaAtual) * fonteNormal.GetHeight(Relatorio.Graphics))
        fonteNormal = If(Bold <> 1, New Font(tipoFonte, CSng(TamLetra)), New Font(tipoFonte, CSng(TamLetra), FontStyle.Bold))
        Relatorio.Graphics.DrawString(strTexto, fonteNormal, Brushes.Black, margemEsq, Convert.ToSingle(posicaoDaLinha), New StringFormat())

        Dim local As Integer
        If NewLine = 1 Then
            Dim num As Integer = linhaAtual + 1
            local = num
        End If


        Return posicaoDaLinha
    End Function


    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
End Module