Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.IO.Compression
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Xml.Schema

Module NFe_funcoes4

    Public Function Serializar(ByVal objectToSerialize As Object, Optional ByVal strUrl As String = Nothing) As XmlDocument
        Dim namespaces As XmlSerializerNamespaces = New XmlSerializerNamespaces()
        If strUrl Is Nothing Then strUrl = "http://www.portalfiscal.inf.br/nfe"
        namespaces.Add("", strUrl)
        Dim stream As Stream = CType(New MemoryStream(), Stream)
        Dim xmlDocument As XmlDocument = New XmlDocument()
        Dim xmlWriter As XmlWriter = xmlWriter.Create(stream)
        Dim x As New XmlSerializer(objectToSerialize.GetType)
        x.Serialize(xmlWriter, RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(objectToSerialize)), namespaces)
        xmlWriter.Flush()
        stream.Flush()
        stream.Position = 0L
        xmlDocument.Load(stream)
        Return xmlDocument
    End Function
    Public Function CompresGZip(ByVal texto As String) As String
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

    Public Function DecompressGZip(ByVal bytes As Byte()) As String
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

    Public Function DecompressGZip(ByVal textBase64 As String) As String
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

    Private Function ToByteArray(ByVal stream As Stream) As Byte()
        Dim num1 As Integer = 0
        Dim byteList As List(Of Byte) = New List(Of Byte)()
        Dim buffer As Byte() = New Byte(131071) {}
        Dim target As Integer = 0

        While InlineAssignHelper(Of Integer)(target, stream.Read(buffer, 0, 131072)) > 0

            If True Then
                num1 += target
            End If

            Dim num2 As Integer = (target - 1)
            Dim index As Integer = 0

            While index <= num2
                byteList.Add(buffer(index))

                If True Then
                    index += 1
                End If
            End While
        End While

        Return byteList.ToArray()
    End Function

    Private Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function

    Public Function DeserializarNFe(ByVal iTipoClasse As Integer, ByVal xml As String) As Object
        Dim obj As Object

        Select Case iTipoClasse
            Case 1
                obj = CObj(DeserializarNFe(Of retConsSitNFe)(xml))
            Case 2
                obj = CObj(DeserializarNFe(Of retEnvEvento)(xml))
            Case 3
                obj = CObj(DeserializarNFe(Of retConsStatServ)(xml))
            Case 4
                obj = CObj(DeserializarNFe(Of infInutRet)(xml))
            Case 5
                obj = CObj(DeserializarNFe(Of retEnviNFe)(xml))
            Case 6
                obj = CObj(DeserializarNFe(Of retConsReciNFe)(xml))
        End Select

        Return obj
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
            '  ProjectData.SetProjectError(ex)
            Throw
        End Try
    End Function

    Public Function DeserializeStringListT(Of T)(ByVal strTexto As String) As List(Of T)
        Using memoryStream As MemoryStream = New MemoryStream(Encoding.ASCII.GetBytes(strTexto))
            memoryStream.Position = 1L
            memoryStream.Seek(0L, SeekOrigin.Begin)
            Dim xmlSerializer As XmlSerializer = New XmlSerializer(GetType(List(Of T)))
            If strTexto.Length > 1 Then Return CType(xmlSerializer.Deserialize(CType(memoryStream, Stream)), List(Of T))
            Return New List(Of T)()
        End Using
    End Function

    Public Function GeraXMLEventoNFe(ByVal eventoRef As evento) As XmlDocument
        Dim xmlDocument1 As XmlDocument

        Try
            Dim settings As XmlWriterSettings = New XmlWriterSettings()
            settings.Indent = True
            settings.IndentChars = ""
            settings.NewLineOnAttributes = False
            settings.OmitXmlDeclaration = False
            settings.Encoding = Encoding.UTF8
            Dim stream As Stream = CType(New MemoryStream(), Stream)
            Dim xmlWriter As XmlWriter = xmlWriter.Create(stream, settings)
            xmlWriter.WriteStartDocument()
            xmlWriter.WriteStartElement("evento", "http://www.portalfiscal.inf.br/nfe")
            xmlWriter.WriteAttributeString("versao", "1.00")
            xmlWriter.WriteAttributeString("xmlns", "http://www.portalfiscal.inf.br/nfe")
            xmlWriter.WriteStartElement("infEvento")
            xmlWriter.WriteAttributeString("Id", eventoRef.infEvento.Id)
            xmlWriter.WriteElementString("cOrgao", eventoRef.infEvento.cOrgao)
            xmlWriter.WriteElementString("tpAmb", eventoRef.infEvento.tpAmb)

            If eventoRef.infEvento.CNPJ.Length > 0 Then
                xmlWriter.WriteElementString("CNPJ", eventoRef.infEvento.CNPJ)
            Else
                xmlWriter.WriteElementString("CPF", eventoRef.infEvento.CPF)
            End If

            xmlWriter.WriteElementString("chNFe", eventoRef.infEvento.chNFe)
            xmlWriter.WriteElementString("dhEvento", eventoRef.infEvento.dhEvento)
            xmlWriter.WriteElementString("tpEvento", eventoRef.infEvento.tpEvento)
            xmlWriter.WriteElementString("nSeqEvento", eventoRef.infEvento.nSeqEvento)
            xmlWriter.WriteElementString("verEvento", eventoRef.infEvento.verEvento)
            xmlWriter.WriteStartElement("detEvento")
            xmlWriter.WriteAttributeString("versao", eventoRef.infEvento.detEvento.versao)
            xmlWriter.WriteElementString("descEvento", eventoRef.infEvento.detEvento.descEvento)
            If eventoRef.infEvento.detEvento.xCorrecao IsNot Nothing Then xmlWriter.WriteElementString("xCorrecao", eventoRef.infEvento.detEvento.xCorrecao)
            If eventoRef.infEvento.detEvento.xCondUso IsNot Nothing Then xmlWriter.WriteElementString("xCondUso", eventoRef.infEvento.detEvento.xCondUso)
            If eventoRef.infEvento.detEvento.nProt IsNot Nothing Then xmlWriter.WriteElementString("nProt", eventoRef.infEvento.detEvento.nProt)
            If eventoRef.infEvento.detEvento.xJust IsNot Nothing Then xmlWriter.WriteElementString("xJust", eventoRef.infEvento.detEvento.xJust)
            xmlWriter.WriteEndElement()
            xmlWriter.WriteEndElement()
            xmlWriter.WriteEndElement()
            xmlWriter.Flush()
            stream.Flush()
            stream.Position = 0L
            Dim xmlDocument2 As XmlDocument = New XmlDocument()
            xmlDocument2.Load(stream)
            xmlWriter.Close()
            xmlDocument1 = xmlDocument2
        Catch ex As Exception
            ' ProjectData.SetProjectError(ex)
            xmlDocument1 = CType(Nothing, XmlDocument)
            '  ProjectData.ClearProjectError()
        End Try

        Return xmlDocument1
    End Function

    Public Function GerarLoteEventoNFe(ByVal xmlEventos As XmlDocument, ByVal numLote As Integer, versao As String) As XmlDocument
        Dim stringBuilder As StringBuilder = New StringBuilder()
        stringBuilder.Append("<?xml version=""1.0"" encoding=""utf-8""?>")
        stringBuilder.AppendFormat("<envEvento versao =""{0}"" xmlns=""http://www.portalfiscal.inf.br/nfe"">", CObj(versao))
        stringBuilder.AppendFormat("<idLote>{0}</idLote>", CObj(numLote.ToString("000000000000000")))
        stringBuilder.AppendFormat(xmlEventos.OuterXml)
        stringBuilder.Append("</envEvento>")
        Dim xmlDocument As XmlDocument = New XmlDocument()
        xmlDocument.LoadXml(stringBuilder.ToString())
        Return xmlDocument
    End Function

    Public Function GerarLoteEnvioNFe(ByVal xmlnfe As XmlDocument, ByVal numLote As Integer, ByVal versao As String) As XmlDocument
        Dim stringBuilder As StringBuilder = New StringBuilder()
        stringBuilder.Append("<?xml version=""1.0"" encoding=""utf-8""?>")
        stringBuilder.AppendFormat("<enviNFe versao =""{0}"" xmlns=""http://www.portalfiscal.inf.br/nfe"">", CObj(versao))
        stringBuilder.AppendFormat("<idLote>{0}</idLote>", CObj(numLote.ToString("000000000000000")))
        stringBuilder.Append("<indSinc>0</indSinc>")
        stringBuilder.AppendFormat(xmlnfe.OuterXml)
        stringBuilder.Append("</enviNFe>")
        Dim xmlDocument As XmlDocument = New XmlDocument()
        xmlDocument.LoadXml(stringBuilder.ToString())
        Return xmlDocument
    End Function

    Public Function GerarTagNFeProc(ByVal versao As String) As XmlDocument
        Dim stringBuilder As StringBuilder = New StringBuilder()
        stringBuilder.Append("<?xml version=""1.0"" encoding=""utf-8""?>")
        stringBuilder.Append("<nfeProc xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" ")
        stringBuilder.Append("xmlns:ds=""http://www.w3.org/2001/XMLSchema-instance"" ")
        stringBuilder.AppendFormat("xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""{0}"">", CObj(versao))
        stringBuilder.Append("</nfeProc>")
        stringBuilder.ToString()
        Dim xmlDocument As XmlDocument = New XmlDocument()
        xmlDocument.LoadXml(stringBuilder.ToString())
        Return xmlDocument
    End Function


    
End Module
