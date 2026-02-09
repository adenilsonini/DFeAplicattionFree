Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Xml

Public Class ImprimirXMLNFCeBematech

    Private Shared iRet As Integer
   
    <DllImport("MP2032.DLL", SetLastError:=True)>
    Public Shared Function IniciaPorta(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef Porta As String) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function BematechTX(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef Comando As String) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ComandoTX(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef BufTrans As String, ByVal Flag As Integer) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function CaracterGrafico(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef BufTrans As String, ByVal TamBufTrans As Integer) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function Le_Status() As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function AutenticaDoc(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef texto As String, ByVal Tempo As Integer) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function DocumentInserted() As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function FechaPorta() As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function Le_Status_Gaveta() As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ConfiguraTamanhoExtrato(ByVal NumeroLinhas As Integer) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function HabilitaExtratoLongo(ByVal Flag As Integer) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function HabilitaEsperaImpressao(ByVal Flag As Integer) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function EsperaImpressao() As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ConfiguraModeloImpressora(ByVal ModeloImpressora As Integer) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function AcionaGuilhotina(ByVal modo As Integer) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function FormataTX(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef BufTrans As String, ByVal TpoLtra As Integer, ByVal Italic As Integer, ByVal Sublin As Integer, ByVal Expand As Integer, ByVal Enfat As Integer) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ConfiguraTaxaSerial(ByVal taxa As Integer) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function HabilitaPresenterRetratil(ByVal iFlag As Integer) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ProgramaPresenterRetratil(ByVal iTempo As Integer) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function VerificaPapelPresenter() As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function SelecionaQualidadeImpressao(ByVal iTipoQualidade As Integer) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ConfiguraCodigoBarras(ByVal Altura As Integer, ByVal Largura As Integer, ByVal PosicaoCaracteres As Integer, ByVal Fonte As Integer, ByVal Margem As Integer) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ImprimeCodigoBarrasUPCA(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef CODIGO As String) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ImprimeCodigoBarrasUPCE(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef CODIGO As String) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ImprimeCodigoBarrasEAN13(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef CODIGO As String) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ImprimeCodigoBarrasEAN8(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef CODIGO As String) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ImprimeCodigoBarrasCODE39(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef CODIGO As String) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ImprimeCodigoBarrasCODE93(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef CODIGO As String) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ImprimeCodigoBarrasCODE128(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef CODIGO As String) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ImprimeCodigoBarrasITF(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef CODIGO As String) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ImprimeCodigoBarrasCODABAR(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef CODIGO As String) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ImprimeCodigoBarrasISBN(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef CODIGO As String) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ImprimeCodigoBarrasMSI(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef CODIGO As String) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ImprimeCodigoBarrasPLESSEY(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef CODIGO As String) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ImprimeCodigoBarrasPDF417(ByVal NivelCorrecaoErros As Integer, ByVal Altura As Integer, ByVal Largura As Integer, ByVal Colunas As Integer,
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef CODIGO As String) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ImprimeCodigoQRCODE(ByVal errorCorrectionLevel As Integer, ByVal moduleSize As Integer, ByVal codeType As Integer, ByVal QRCodeVersion As Integer, ByVal encodingModes As Integer,
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef codeQr As String) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ImprimeBitmap(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef Name As String, ByVal mode As Integer) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function ImprimeBmpEspecial(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef Name As String, ByVal xScale As Integer, ByVal yScale As Integer, ByVal angle As Integer) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function AjustaLarguraPapel(ByVal width As Integer) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function PrinterReset() As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function IoControl(ByVal Flag As Integer, ByVal mode As Boolean) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function PrintNVBitmap(ByVal image As Integer, ByVal mode As Integer) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function Define1NVBitmap(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef fileName As String) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function DefineDLBitmap(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef fileName As String) As Integer
    End Function

    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function PrintDLBitmap(ByVal mode As Integer) As Integer
    End Function
    <DllImport("MP2032.DLL", CharSet:=CharSet.Ansi, SetLastError:=True)>
    Public Shared Function AtualizaFirmware(
    <MarshalAs(UnmanagedType.VBByRefStr)> ByRef fileName As String) As Integer
    End Function

    Public Shared Sub ImprimirXMLNFCeBematech(ByVal Parametros As Object)
        Try
            Dim stringList As List(Of String) = CType(Parametros, List(Of String))
            Dim clsPlugin As clsPlugin = New clsPlugin()
            Dim Expression As String = stringList(0)
            Dim strXML As String = Expression
            Dim str1 As String = stringList(1)
            Dim Porta As String = stringList(2)
            Conversions.ToInteger(stringList(3))
            Dim boolean2 As Boolean
            If Not Information.IsNothing(CObj(stringList(4))) Then boolean2 = Conversions.ToBoolean(stringList(4))
            Dim str2 As String = If(Information.IsNothing(CObj(stringList(5))), "3.10", stringList(5))
            Dim hashtable As Hashtable = New Hashtable()
            Dim num1 As Integer = 64
            Dim xmlDocument As XmlDocument = New XmlDocument()
            Dim str3 As String = Strings.Replace(Strings.Replace(Expression, "xmlns=""http://www.portalfiscal.inf.br/nfe""", "", 1, -1, CompareMethod.Binary), "xmlns=""http://www.w3.org/2000/09/xmldsig#""", "", 1, -1, CompareMethod.Binary)
            Dim Data As String


            xmlDocument.LoadXml(str3)

            Try

                For Each xmlElement As XmlElement In xmlDocument.GetElementsByTagName("Reference")

                    Try

                        For Each childNode As XmlElement In xmlElement.ChildNodes
                            If Operators.CompareString(childNode.Name, "DigestValue", False) = 0 Then Data = childNode.InnerText
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

            Dim chave_acesso As String

            Try

                For Each xmlElement As XmlElement In xmlDocument.GetElementsByTagName("NFe")

                    Try

                        For Each childNode As XmlElement In xmlElement.ChildNodes
                            If Operators.CompareString(childNode.Name, "infNFe", False) = 0 Then
                                chave_acesso = childNode.GetAttribute("Id").Substring(3, childNode.GetAttribute("Id").Length - 3)
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

            iRet = ConfiguraTaxaSerial(115200)

            iRet = FechaPorta()
            Thread.Sleep(1000)
            iRet = IniciaPorta(Porta)

            If iRet = 0 Then
                iRetTrImp = 9
            Else

                Try

                    For Each xmlElement As XmlElement In xmlDocument.GetElementsByTagName("ide")

                        Try

                            For Each childNode As XmlElement In xmlElement.ChildNodes
                                hashtable.Add(CObj(childNode.Name), CObj(childNode.InnerText))
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

                Dim hex As String = Conversions.ToString(hashtable(CObj("dhEmi")))
                Dim Left1 As String = Conversions.ToString(hashtable(CObj("tpAmb")))
                Dim Left2 As String = Conversions.ToString(hashtable(CObj("tpEmis")))
                Dim InputStr As String = Conversions.ToString(hashtable(CObj("serie")))
                Dim str4 As String = Conversions.ToString(hashtable(CObj("nNF")))
                Dim num2 As Long = Conversions.ToLong(hashtable(CObj("cNF")))
                '  Dim integer2 As Integer = Conversions.ToInteger(LeINI("SATNFCE", "CAIXA", "000", ""))
                hashtable.Clear()
                Dim innerText1 As String

                Try

                    For Each xmlElement As XmlElement In xmlDocument.GetElementsByTagName("dest")

                        Try

                            For Each childNode As XmlElement In xmlElement.ChildNodes
                                If Operators.CompareString(childNode.Name, "CNPJ", False) = 0 Or Operators.CompareString(childNode.Name, "CPF", False) = 0 Then innerText1 = childNode.InnerText
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

                Dim str5 As String = ""

                Try

                    For Each xmlElement1 As XmlElement In xmlDocument.GetElementsByTagName("emit")

                        Try

                            For Each childNode As XmlElement In xmlElement1.ChildNodes
                                If Operators.CompareString(childNode.Name, "enderEmit", False) <> 0 Then hashtable.Add(CObj(childNode.Name), CObj(childNode.InnerText))
                            Next

                        Finally
                            Dim enumerator As IEnumerator
                            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                        End Try

                        Try

                            For Each xmlElement2 As XmlElement In xmlElement1.GetElementsByTagName("enderEmit")

                                Try

                                    For Each childNode As XmlElement In xmlElement2.ChildNodes
                                        hashtable.Add(CObj(childNode.Name), CObj(childNode.InnerText))
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
                    Next

                Finally
                    Dim enumerator As IEnumerator
                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                End Try

                Dim str6 As String = Conversions.ToString(hashtable(CObj("UF")))
                Dim BufTrans1 As String = fFormata(hashtable(CObj("xNome")), " ", "C", num1, True, False) & vbCrLf
                iRet = FormataTX(BufTrans1, 1, 0, 0, 0, 1)

                str5 = ""
                Dim BufTrans2 As String = fFormata(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(hashtable(CObj("xLgr")), CObj(", ")), hashtable(CObj("nro"))), CObj(", ")), hashtable(CObj("xBairro"))), CObj(" - ")), CObj(str6))), " ", "C", num1, True, False) & vbCrLf
                iRet = FormataTX(BufTrans2, 1, 0, 0, 0, 0)
                str5 = ""

                Dim BufTrans33 As String = fFormata(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(CObj("CNPJ: "), hashtable(CObj("CNPJ"))), CObj(" - ")), Operators.ConcatenateObject(CObj("Insc E: "), hashtable(CObj("IE"))))), " ", "C", num1, True, False) & vbCrLf
                iRet = FormataTX(BufTrans33, 1, 0, 0, 0, 0)

                If hashtable(CObj("fone")) <> "" Then
                    Dim BufTrans44 As String = fFormata("Telefone: " & MascSTR(hashtable(CObj("fone")), "(##) #### ####"), " ", "C", num1, True, False) & vbCrLf
                    iRet = FormataTX(BufTrans44, 1, 0, 0, 0, 1)
                End If

                hashtable.Clear()

                Dim BufTrans3 As String
                BufTrans3 = BufTrans3 & "-----------------------------------------------------------------" & vbCrLf
                iRet = FormataTX(BufTrans3, 1, 0, 0, 0, 0)
                BufTrans3 = ""

                BufTrans3 = fFormata("Documento Auxiliar de Nota Fiscal de Consumidor", " ", "C", num1, True, False) & vbCrLf
                iRet = FormataTX(BufTrans3, 1, 0, 0, 0, 1)
                BufTrans3 = ""

                BufTrans3 = BufTrans3 & "-----------------------------------------------------------------" & vbCrLf
                iRet = FormataTX(BufTrans3, 1, 0, 0, 0, 0)


                str5 = ""

                If Operators.CompareString(Left2, "9", False) = 0 Then
                    Dim BufTrans4 As String = fFormata("EMITIDA EM CONTINGENCIA", "=", "C", (CInt(Math.Round((CDbl(num1) / 2.0)))), True, False)
                    iRet = FormataTX(BufTrans4, 1, 0, 0, 1, 1)
                    Dim BufTrans5 As String = fFormata("PENDENTE AUTORIZACAO", "=", "C", (num1 + 6), True, False) & vbCrLf
                    iRet = FormataTX(BufTrans5, 1, 0, 0, 0, 1)
                    str5 = ""
                End If

                If Operators.CompareString(Strings.Trim(innerText1), "", False) <> 0 Then
                    Dim BufTrans4 As String = "CPF/CNPJ do Consumidor: " & innerText1 & vbCrLf
                    iRet = FormataTX(BufTrans4, 1, 0, 0, 0, 0)
                End If

                Dim BufTrans6 As String = ""
                Dim cont_item As Integer

                If Not boolean2 Then
                    Dim BufTrans4 As String = fFormata("#|COD| DESC| QTD| UN| VL UN R$| VL ITEM R$" & vbCrLf, " ", "C", num1, True, False) & vbCrLf
                    iRet = FormataTX(BufTrans4, 1, 0, 1, 0, 1)
                    BufTrans6 = ""



                    Try

                        For Each obj As Object In xmlDocument.GetElementsByTagName("det")
                            Dim objectValue As Object = RuntimeHelpers.GetObjectValue(obj)

                            Try

                                For Each xmlElement As XmlElement In CType(NewLateBinding.LateGet(objectValue, CType(Nothing, Type), "childNodes", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())), IEnumerable)

                                    If Operators.CompareString(xmlElement.Name, "prod", False) = 0 Then

                                        Try

                                            For Each childNode As XmlElement In xmlElement.ChildNodes
                                                hashtable.Add(CObj(childNode.Name), CObj(childNode.InnerText))
                                            Next

                                        Finally
                                            Dim enumerator As IEnumerator
                                            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                                        End Try

                                        Dim num3 As Integer
                                        num3 += 1

                                        cont_item += 1

                                        BufTrans6 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(CObj((BufTrans6 & Strings.Format(CObj(num3), "00") & " ")), hashtable(CObj("cProd"))), CObj(" ")), CObj(fFormata(Conversions.ToString(hashtable(CObj("xProd"))), " ", "D", 21, True, False))))
                                        BufTrans6 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(CObj((BufTrans6 & " " & fFormata(Strings.FormatCurrency(CObj(Strings.Replace(Conversions.ToString(hashtable(CObj("qCom"))), ".", ",", 1, -1, CompareMethod.Binary)), 3, Microsoft.VisualBasic.TriState.[False], Microsoft.VisualBasic.TriState.[True], Microsoft.VisualBasic.TriState.UseDefault), " ", "E", 7, True, False))), hashtable(CObj("uCom"))), CObj(" ")), CObj(fFormata(Conversions.ToString(hashtable(CObj("vUnCom"))), " ", "E", 7, True, False))))
                                        BufTrans6 = Conversions.ToString(Operators.ConcatenateObject(CObj(BufTrans6), hashtable(CObj("vItem"))))
                                        BufTrans6 = BufTrans6 & " " & fFormata(Conversions.ToString(hashtable(CObj("vProd"))), " ", "E", 7, True, False) & vbCrLf
                                        iRet = FormataTX(BufTrans6, 1, 0, 0, 0, 0)
                                        Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(hashtable(CObj("vDesc"))))
                                        Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(hashtable(CObj("vOutro"))))
                                        hashtable.Clear()
                                        BufTrans6 = ""
                                    ElseIf Operators.CompareString(xmlElement.Name, "infAdProd", False) = 0 Then
                                        BufTrans6 = Strings.Trim(Strings.Replace(xmlElement.InnerText, ",", ".", 1, -1, CompareMethod.Binary)) & vbCrLf
                                        iRet = FormataTX(BufTrans6, 1, 0, 0, 0, 0)
                                        BufTrans6 = ""
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

                Dim str7 As String

                Try

                    For Each xmlElement1 As XmlElement In xmlDocument.GetElementsByTagName("total")

                        Try

                            For Each xmlElement2 As XmlElement In xmlElement1.GetElementsByTagName("ICMSTot")

                                Try

                                    For Each childNode As XmlElement In xmlElement2.ChildNodes
                                        hashtable.Add(CObj(childNode.Name), CObj(childNode.InnerText))
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

                        str7 = Conversions.ToString(hashtable(CObj("vTotTrib")))
                        Conversions.ToString(hashtable(CObj("vNF")))
                        Conversions.ToString(hashtable(CObj("vICMS")))
                        Dim texto1 As String = Conversions.ToString(hashtable(CObj("vOutro")))
                        Dim texto2 As String = Conversions.ToString(hashtable(CObj("vDesc")))
                        Dim s As String = Conversions.ToString(hashtable(CObj("vProd")))
                        Dim str8 As String = BufTrans6 & New String("-"c, num1) & vbCrLf

                        If Conversions.ToDouble(gVgPt(CObj(texto2), False)) > 0.0 Or Conversions.ToDouble(gVgPt(CObj(texto1), False)) > 0.0 Then
                            str8 = (str8 + ("SUBTOTAL R$" + (fFormata(Conversions.ToString(Decimal.Divide(Decimal.Parse(s), New Decimal(100L))), " ", "E", (num1 - 11), True, False) + "" & vbCrLf)))
                        End If


                        If Conversions.ToDouble(gVgPt(CObj(texto2), False)) > 0.0 Then
                            Dim BufTrans4 As String = str8 & "Desconto R$" + fFormata(texto2, " ", "E", (num1 - 11), True, False) & vbCrLf & New String("-"c, 22) & vbCrLf
                            iRet = FormataTX(BufTrans4, 1, 0, 0, 0, 1)
                        End If

                        Dim str9 As String = vbCrLf

                        If Conversions.ToDouble(gVgPt(CObj(texto1), False)) > 0.0 Then
                            Dim BufTrans4 As String = str9 & "Acrescimo R$" + fFormata(texto1, " ", "E", (num1 - 12), True, False) & vbCrLf & New String("-"c, 22) & vbCrLf
                            iRet = FormataTX(BufTrans4, 1, 0, 0, 0, 1)
                        End If

                        Dim str10 As String = ""

                        str10 = str10 & "-----------------------------------------------------------------" & vbCrLf
                        iRet = FormataTX(str10, 1, 0, 0, 0, 0)

                        str10 = ""

                        Dim BufTrans5 As String = str10 & "Qtde. Total de Itens: " + fFormata(Strings.Format(cont_item, "000"), " ", "E", (num1 - 22), True, False) & vbCrLf
                        iRet = FormataTX(BufTrans5, 1, 0, 0, 0, 1)

                        Dim BufTrans7 As String = "" & "TOTAL R$" & fFormata(Conversions.ToString(hashtable(CObj("vNF"))), " ", "E", (num1 - 8), True, False)
                        iRet = FormataTX(BufTrans7, 1, 0, 0, 0, 1)
                        hashtable.Clear()
                        BufTrans6 = ""

                    Next

                Finally
                    Dim enumerator As IEnumerator
                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                End Try

                Dim BufTrans8 As String = " " & vbCrLf
                Dim xmlElement3 As XmlElement

                If Operators.CompareString(str2, "3.10", False) <> 0 Then

                    If Operators.CompareString(str2, "4.00", False) = 0 Then

                        Try

                            For Each xmlElement1 As XmlElement In xmlDocument.GetElementsByTagName("pag")

                                Try

                                    For Each childNode1 As XmlElement In xmlElement1.ChildNodes

                                        If Operators.CompareString(childNode1.Name, "detPag", False) = 0 Then

                                            Try

                                                For Each childNode2 As XmlElement In childNode1.ChildNodes
                                                    hashtable.Add(CObj(childNode2.Name), CObj(childNode2.InnerText))

                                                    If Operators.CompareString(childNode2.Name, "card", False) = 0 Then

                                                        Try

                                                            For Each xmlElement2 As XmlElement In xmlElement1.GetElementsByTagName("card")
                                                                xmlElement3 = xmlElement2
                                                            Next

                                                        Finally
                                                            Dim enumerator As IEnumerator
                                                            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                                                        End Try
                                                    End If
                                                Next

                                            Finally
                                                Dim enumerator As IEnumerator
                                                If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                                            End Try

                                            BufTrans8 = BufTrans8 + RetMPDesc(Conversions.ToInteger(hashtable(CObj("tPag")))) + fFormata(Conversions.ToString(hashtable(CObj("vPag"))), " ", "E", (num1 - Strings.Len(RetMPDesc(Conversions.ToInteger(hashtable(CObj("tPag")))))), True, False) & vbCrLf
                                            iRet = FormataTX(BufTrans8, 1, 0, 0, 0, 0)
                                            hashtable.Clear()
                                            BufTrans8 = ""
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
                Else

                    Try

                        For Each xmlElement1 As XmlElement In xmlDocument.GetElementsByTagName("pag")

                            Try

                                For Each childNode As XmlElement In xmlElement1.ChildNodes
                                    hashtable.Add(CObj(childNode.Name), CObj(childNode.InnerText))

                                    If Operators.CompareString(childNode.Name, "card", False) = 0 Then

                                        Try

                                            For Each xmlElement2 As XmlElement In xmlElement1.GetElementsByTagName("card")
                                                xmlElement3 = xmlElement2
                                            Next

                                        Finally
                                            Dim enumerator As IEnumerator
                                            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                                        End Try
                                    End If
                                Next

                            Finally
                                Dim enumerator As IEnumerator
                                If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                            End Try

                            Dim BufTrans4 As String = BufTrans8 + RetMPDesc(Conversions.ToInteger(hashtable(CObj("tPag")))) + fFormata(Conversions.ToString(hashtable(CObj("vPag"))), " ", "E", (num1 - Strings.Len(RetMPDesc(Conversions.ToInteger(hashtable(CObj("tPag")))))), True, False) & vbCrLf
                            iRet = FormataTX(BufTrans4, 1, 0, 0, 0, 0)
                            hashtable.Clear()
                            BufTrans8 = ""
                        Next

                    Finally
                        Dim enumerator As IEnumerator
                        If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                    End Try
                End If

                str5 = ""

                str5 = str5 & "-----------------------------------------------------------------" & vbCrLf
                iRet = FormataTX(str5, 1, 0, 0, 0, 0)


                If Operators.CompareString(Left1, "2", False) = 0 Then
                    Dim BufTrans4 As String = fFormata("EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL ", " ", "C", num1, True, False) & vbCrLf
                    iRet = FormataTX(BufTrans4, 1, 0, 0, 0, 1)
                    str5 = ""
                End If

                Dim Instance As Object = CObj(Strings.Split(hex, "T", -1, CompareMethod.Binary))
                cAux = Strings.Format(CObj(Conversions.ToDate(NewLateBinding.LateIndexGet(Instance, New Object(0) {CObj(0)}, CType(Nothing, String())))), "dd/MM/yyyy")
                Dim BufTrans9 As String = "Caixa/Serie: " & Strings.Format(CObj(Conversions.ToInteger(InputStr)), "000") & " Num.NFCe: " + Strings.Format(CObj(Conversions.ToLong(str4)), "000000000") & " Emissao: " + cAux & " " + Strings.Left(Conversions.ToString(NewLateBinding.LateIndexGet(Instance, New Object(0) {CObj(1)}, CType(Nothing, String()))), 8) & vbCrLf
                iRet = FormataTX(BufTrans9, 1, 0, 0, 0, 0)
                str5 = str1 & vbCrLf
                str5 = ""
                Dim str11 As String = fFormata("Consulte pela Chave de Acesso em", " ", "C", num1, True, False) & vbCrLf
                cAux = "http://nfce.fazenda.mg.gov.br/portalnfce"
                Dim BufTrans10 As String = str11 & fFormata(cAux, " ", "C", num1, True, False)
                iRet = FormataTX(BufTrans10, 1, 0, 0, 0, 1)
                BufTrans10 = ""

                iRet = FormataTX(BufTrans10, 1, 0, 0, 0, 1)
                BufTrans10 = ""
                BufTrans10 = fFormata(MascSTR(chave_acesso, "#### #### #### #### #### #### #### #### #### #### ####"), " ", "C", num1, True, False)
                iRet = FormataTX(BufTrans10, 1, 0, 0, 0, 1)
                hex = StrToHex(hex)
                Data = If(Data IsNot Nothing, StrToHex(Data), CalculaDigestValueXML_MDL(strXML, True))
                Dim codeQr As String = funcoesNfe.GerarEndQRCodeXML(strXML)
                iRet = ConfiguraCodigoBarras(162, 1, 2, 0, 130)
                iRet = ImprimeCodigoQRCODE(0, 5, 0, 10, 1, codeQr)

                If Operators.CompareString(Left2, "1", False) = 0 Then
                    Dim innerText2 As String
                    Dim innerText3 As String

                    Try

                        For Each xmlElement1 As XmlElement In xmlDocument.GetElementsByTagName("infProt")

                            Try

                                For Each childNode As XmlElement In xmlElement1.ChildNodes
                                    If Operators.CompareString(childNode.Name, "dhRecbto", False) = 0 Then innerText2 = childNode.InnerText
                                    If Operators.CompareString(childNode.Name, "nProt", False) = 0 Then innerText3 = childNode.InnerText
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

                    BufTrans10 = fFormata("Prot. Autorizacao:" & innerText3 & "  " & Convert.ToDateTime(innerText2).ToString("dd/MM/yyyy HH:mm:ss"), " ", "C", num1, True, False) & vbCrLf
                    iRet = FormataTX(BufTrans10, 1, 0, 0, 0, 1)
                    BufTrans10 = ""
                End If

                BufTrans10 = "Trib. Totais Incidentes (Lei Federal 12.741/2012) R$ " & str7 & vbCrLf
                iRet = FormataTX(BufTrans10, 1, 0, 0, 0, 0)
                BufTrans10 = ""
                BufTrans10 = BufTrans10 & "-----------------------------------------------------------------" & vbCrLf
                iRet = FormataTX(BufTrans10, 1, 0, 0, 0, 0)
                BufTrans10 = ""

                Try

                    For Each xmlElement1 As XmlElement In xmlDocument.GetElementsByTagName("infAdic")

                        Try

                            For Each childNode As XmlElement In xmlElement1.ChildNodes

                                If Operators.CompareString(childNode.Name, "infCpl", False) = 0 Then
                                    BufTrans10 = fFormata("Informacoes de Interesse do Contribuinte", " ", "C", num1, True, False) & vbCrLf
                                    iRet = FormataTX(BufTrans10, 1, 0, 1, 0, 1)
                                    BufTrans10 = ""
                                    BufTrans10 = BufTrans10 & childNode.InnerText & vbCrLf
                                    BufTrans10 = Strings.Replace(BufTrans10, "|", vbCrLf, 1, -1, CompareMethod.Binary)
                                    iRet = FormataTX(BufTrans10, 1, 0, 0, 0, 0)
                                    BufTrans10 = ""
                                ElseIf Operators.CompareString(childNode.Name, "infAdFisco", False) = 0 Then
                                    BufTrans10 = fFormata("Informacoes de Interesse do Fisco", " ", "C", num1, True, False) & vbCrLf
                                    iRet = FormataTX(BufTrans10, 1, 0, 1, 0, 1)
                                    BufTrans10 = ""
                                    BufTrans10 = BufTrans10 & childNode.InnerText & vbCrLf
                                    BufTrans10 = BufTrans10
                                    BufTrans10 = Strings.Replace(BufTrans10, "|", vbCrLf, 1, -1, CompareMethod.Binary)
                                    iRet = FormataTX(BufTrans10, 1, 0, 0, 0, 0)
                                    BufTrans10 = ""
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

                iRet = AcionaGuilhotina(1)
                iRet = FechaPorta()
                str5 = ""
                iRetTrImp = 1
                End If

        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            iRetTrImp = 9
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class

    Public Shared Function RetMPDesc(ByVal CodMP As Integer) As String
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

    Public Shared Function StrToHex(ByRef Data As String) As String
        Dim str1 As String = ""

        While Data.Length > 0
            Dim str2 As String = Conversion.Hex(Strings.Asc(Data.Substring(0, 1).ToString()))
            Data = Data.Substring(1, (Data.Length - 1))
            str1 += str2
        End While

        Return str1
    End Function

   

   
    Public Shared Sub Imprimir_VENDA_PRAZO_Bematech(ByVal Parametros As Object)


        '  Try
        Dim stringList As List(Of String) = CType(Parametros, List(Of String))
        Dim Porta As String = stringList(0)
        Dim data_compra As Date = stringList(1)
        Dim rv As String = stringList(2)
        Dim Nome_cli As String = stringList(3)
        Dim cod_cli As String = stringList(4)
        Dim cpf As String = stringList(5)
        Dim limite As String = stringList(6)
        Dim vlr_compra As String = stringList(7)
        Dim data_venc As Date = stringList(8)
        Dim endereco As String = stringList(9)
        Dim razao As String = stringList(10)
        Dim convenio As String = stringList(11)
        Dim pdv As String = stringList(12)

        Dim hashtable As Hashtable = New Hashtable()
        Dim num1 As Integer = 64
        If rv = "" Then
            rv = "1"
        End If
        rv = Strings.Format(CObj(Conversions.ToInteger(rv)), "000000")


        Dim pular_linha As String

        iRet = ConfiguraTaxaSerial(115200)

        iRet = FechaPorta()
        Thread.Sleep(1000)
        iRet = IniciaPorta(Porta)

        If iRet = 0 Then
            iRetTrImp = 9
        Else

            Dim BufTrans As String
            BufTrans = fFormata("Data da Compra: " & data_compra, " ", "D", num1, False, False)
            iRet = FormataTX(BufTrans, 2, 0, 0, 0, 0)

            pular_linha = Chr(13) + Chr(10)
            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))

            BufTrans = fFormata("COO/RV Ref.: " & rv, " ", "D", num1, False, False)
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)


            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))

            BufTrans = fFormata("Convenio: " & convenio, " ", "D", num1, False, False)
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)


            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))

            BufTrans = fFormata("Nome Cliente: " & Nome_cli, " ", "D", num1, False, False)
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)


            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))

            BufTrans = fFormata("Codigo: " & Strings.Format(CObj(Conversions.ToInteger(cod_cli)), "00000000"), " ", "D", num1, False, False)
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)


            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))

            BufTrans = fFormata("CPF/CNPJ: " & cpf, " ", "D", num1, False, False)
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)


            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))

            BufTrans = fFormata("Limite Restante: " & limite, " ", "D", num1, False, False)
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)


            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))

            BufTrans = fFormata("Valor da Compra: " & vlr_compra, " ", "D", num1, False, False)
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)


            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))

            BufTrans = fFormata("Data de Vencimento: " & data_venc, " ", "D", num1, False, False)
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)


            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))

            BufTrans = fFormata("End. " & endereco, " ", "D", num1, False, False)
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)


            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))

            BufTrans = fFormata("PAGAREI A IMPORTANCIA ACIMA", " ", "C", num1, True, False)
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)


            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))

            BufTrans = fFormata("Ass:_______________________________________", " ", "D", num1, False, False)
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 1)

            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))

            BufTrans = ""
            BufTrans = BufTrans & "------------------------------------------------------------" & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)

            BufTrans = razao & " - LJ01" & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)

            BufTrans = "PDV:" & pdv & "    " & "Tipo: NFCe" & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)

            BufTrans = "Data:" & Now.ToString("dd/MM/yyyy") & "  " & "Hora: " & Now.ToString("HH:mm:ss")
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)

            iRet = AcionaGuilhotina(1)
            iRet = FechaPorta()

            iRetTrImp = 1
        End If

        '    Catch ex As Exception
        'ProjectData.SetProjectError(ex)
        '   iRetTrImp = 9
        '   ProjectData.ClearProjectError()
        '   End Try
    End Sub


    Public Shared Sub Imprimir_VENDA_CARTAO_Bematech(ByVal Parametros As Object)


        ' Try
        Dim stringList As List(Of String) = CType(Parametros, List(Of String))
        Dim Porta As String = stringList(0)
        Dim data_compra As Date = stringList(1)
        Dim rv As String = stringList(2)
        Dim EC As String = stringList(3)
        Dim AUT As String = stringList(4)
        Dim DOC As String = stringList(5)
        Dim STONE_ID As String = stringList(6)
        Dim TOTAL As String = stringList(7)
        Dim TIPO As String = stringList(8)
        Dim razao As String = stringList(9)
        Dim bandeira As String = stringList(10)
        Dim hora As String = stringList(11)
        Dim pdv As String = stringList(12)

        Dim hashtable As Hashtable = New Hashtable()
        Dim num1 As Integer = 64
        If rv = "" Then
            rv = "1"
        End If

        rv = Strings.Format(CObj(Conversions.ToInteger(rv)), "000000")


        Dim pular_linha As String = Chr(13) + Chr(10)

        iRet = ConfiguraTaxaSerial(115200)

        iRet = FechaPorta()
        Thread.Sleep(1000)
        iRet = IniciaPorta(Porta)

        If iRet = 0 Then
            iRetTrImp = 9
        Else

            Dim BufTrans As String
            BufTrans = fFormata("STONE - Via Estabelecimento", " ", "C", num1, True, False)
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)

            BufTrans = fFormata(bandeira, " ", "C", num1, True, False) & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)


            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))


            BufTrans = fFormata("Data: " & data_compra & " " & hora, " ", "D", num1, False, False) & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)


            Dim ler As String = "EC: " & EC
            BufTrans = ler & fFormata("AUT.:" & AUT, " ", "E", (num1 - ler.Length), False, False) & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)

            BufTrans = fFormata("DOC: " & DOC, " ", "D", num1, False, False) & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)

            BufTrans = fFormata("Stone ID: " & STONE_ID, " ", "D", num1, False, False) & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)


            BufTrans = fFormata(TIPO, " ", "C", num1, False, False) & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)

            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))


            BufTrans = "TOTAL" & fFormata(TOTAL, " ", "E", (num1 - 5), False, False) & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)


            BufTrans = fFormata("TRANSACAO APROVADA COM SENHA", " ", "C", num1, False, False) & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)
           
            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))

            BufTrans = ""
            BufTrans = BufTrans & "------------------------------------------------------------" & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)

            BufTrans = razao & " - LJ01" & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)

            BufTrans = "PDV:" & pdv & "    " & "Tipo: NFCe" & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)

            BufTrans = "Data:" & Now.ToString("dd/MM/yyyy") & "  " & "Hora: " & Now.ToString("HH:mm:ss")
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)

            iRet = AcionaGuilhotina(1)





            '''''''''''''''''''''''VIA PARA CLIENTE ABAIXO'''''''''''''''''''''''
            BufTrans = ""
            BufTrans = fFormata("STONE - Via CLIENTE", " ", "C", num1, True, False)
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)

            BufTrans = fFormata(bandeira, " ", "C", num1, True, False) & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)


            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))


            BufTrans = fFormata("Data: " & data_compra & " " & hora, " ", "D", num1, False, False) & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)

            BufTrans = fFormata("DOC: " & DOC, " ", "D", num1, False, False) & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)

            Dim ler2 As String = "AUT.: " & AUT
            BufTrans = ler2 & fFormata("ONL-CHIP", " ", "E", (num1 - ler2.Length), False, False) & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)

            BufTrans = fFormata("EC: " & EC, " ", "D", num1, False, False) & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)
           

            BufTrans = "TOTAL" & fFormata(TOTAL, " ", "E", (num1 - 5), False, False) & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)


            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))
            iRet = ComandoTX(pular_linha, Len(pular_linha))

            BufTrans = ""
            BufTrans = BufTrans & "------------------------------------------------------------" & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)

            BufTrans = razao & " - LJ01" & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)

            BufTrans = "PDV:" & pdv & "    " & "Tipo: NFCe" & vbCrLf
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)

            BufTrans = "Data:" & Now.ToString("dd/MM/yyyy") & "  " & "Hora: " & Now.ToString("HH:mm:ss")
            iRet = FormataTX(BufTrans, 1, 0, 0, 0, 0)







            iRet = AcionaGuilhotina(1)

            iRet = FechaPorta()

            iRetTrImp = 1
        End If

        ' Catch ex As Exception
        '  ProjectData.SetProjectError(ex)
        '   iRetTrImp = 9
        ' ProjectData.ClearProjectError()
        ' End Try
    End Sub
End Class
