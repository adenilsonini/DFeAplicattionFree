Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.IO
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography.Xml
Imports System.Xml


Public Class Assinatura
    Public Shared bReinf As Boolean
    Public Shared Function Assinar(ByVal strArqXMLAssinar As XmlDocument, ByVal strUri As String, ByVal xCertificado As X509Certificate2) As XmlDocument

        Dim num As Integer = 0

        Try
           
            Try
                Dim x509Certificate2 As X509Certificate2 = New X509Certificate2()
                Dim certificate As X509Certificate2 = xCertificado
                certificate.GetKeyAlgorithm().ToString()
                Dim document As XmlDocument = New XmlDocument()
                document.PreserveWhitespace = False

                Try
                    document.LoadXml(strArqXMLAssinar.OuterXml)
                    Dim count As Integer = document.GetElementsByTagName(strUri).Count
                    If count = 0 Then Throw New Exception("A tag de assinatura " & strUri.Trim() & " não existe no XML. (Código do Erro: 4)")
                    If count > 1 Then Throw New Exception("A tag de assinatura " & strUri.Trim() & " não é unica. (Código do Erro: 5)")
                    If document.GetElementsByTagName("Signature").Count <> 0 Then

                    End If

                    Try
                        Dim signedXml As SignedXml = New SignedXml(document)

                        If bReinf Then
                            signedXml.SigningKey = certificate.PrivateKey
                            '   signedXml.SigningKey = CType(certificate.GetRSAPrivateKey(), AsymmetricAlgorithm)
                            signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256"
                        Else
                            signedXml.SigningKey = certificate.PrivateKey
                        End If

                        Dim reference As Reference = New Reference()
                        Dim attributes As XmlAttributeCollection = document.GetElementsByTagName(strUri).Item(0).Attributes

                        Try

                            For Each xmlAttribute As XmlAttribute In CType(attributes, XmlNamedNodeMap)
                                If Operators.CompareString(xmlAttribute.Name, "Id", False) = 0 Or Operators.CompareString(xmlAttribute.Name, "id", False) = 0 Then reference.Uri = "#" & xmlAttribute.InnerText
                            Next

                        Finally
                            Dim enumerator As IEnumerator
                            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                        End Try

                        Dim signatureTransform As XmlDsigEnvelopedSignatureTransform = New XmlDsigEnvelopedSignatureTransform()
                        reference.AddTransform(CType(signatureTransform, Transform))
                        Dim dsigC14Ntransform As XmlDsigC14NTransform = New XmlDsigC14NTransform()
                        reference.AddTransform(CType(dsigC14Ntransform, Transform))
                        If bReinf Then reference.DigestMethod = "http://www.w3.org/2001/04/xmlenc#sha256"
                        signedXml.AddReference(reference)
                        Dim keyInfo As KeyInfo = New KeyInfo()
                        keyInfo.AddClause(CType(New KeyInfoX509Data(CType(certificate, X509Certificate)), KeyInfoClause))
                        signedXml.KeyInfo = keyInfo
                        signedXml.ComputeSignature()
                        Dim xml As XmlElement = signedXml.GetXml()
                        document.DocumentElement.AppendChild(document.ImportNode(CType(xml, XmlNode), True))
                        Dim ser As New XmlDocument()
                        ser.PreserveWhitespace = False

                        Return document

                    Catch ex As Exception
                        ProjectData.SetProjectError(ex)
                        Dim exception As Exception = ex
                        If num = 0 Then num = 3
                        Throw exception
                    End Try

                Catch ex As Exception
                    ProjectData.SetProjectError(ex)
                    Dim exception As Exception = ex
                    If num = 0 Then num = 6
                    Throw exception
                End Try

            Catch ex As Exception
                ProjectData.SetProjectError(ex)
                Dim exception As Exception = ex
                If num = 0 Then num = 1
                Throw exception
            End Try

        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Dim exception As Exception = ex

            If num = 0 Then
            End If

            Throw exception
       
        End Try
    End Function

   
End Class
