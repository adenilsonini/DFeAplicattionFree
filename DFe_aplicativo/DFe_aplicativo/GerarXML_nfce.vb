Imports System.Xml
Imports System.IO


Module GerarXML_nfce

    Public xml_processar As New XmlDocument()
    Public xmldoc2 As New XmlDocument()
    Public xmldoc_PROC As New XmlDocument()
    Public xmldoc3 As New XmlDocument()

    Dim xmlAssinado As XmlDocument

    Public Function gerar_xmlNFCe_envio(ByVal xml As String, ByVal ambiente As String) As String
        Dim txtqrcodenfce As String
        Dim xmlAssinado12 As XmlDocument()
        ''''''''''''Rotina abaixo assinar o xml com certificado digital'''''''''''''''''''''''''
        xmldoc2.LoadXml(xml)

        xmldoc3.LoadXml(SepararNota3(xmldoc2.OuterXml))
        xmldoc2.LoadXml(SepararNota3(xmldoc2.OuterXml))


        xmlAssinado = CertificadoDigital.Assinar(GerarNotaProcessada2(xmldoc2.OuterXml), "infNFe", certificado)


        'If mskchave.Text.Substring(20, 2) = "65" Then

        ''''''''''''Rotina abaixo gera o QRCode da NFC-e'''''''''''''''''''''''''
        If txtqrcodenfce = "" Then

            txtqrcodenfce = GerarEndQRCodeXML(xmlAssinado.OuterXml)


            xmldoc2.LoadXml(xmlAssinado.OuterXml)


            xmlAssinado = Gerar_qrcode(xmldoc3.OuterXml, txtqrcodenfce, SepararNota_assinatura(xmlAssinado.OuterXml), ambiente)

            xml_processar.LoadXml(xmlAssinado.OuterXml)

        End If

        '   End If


        ''''''''''''Rotina abaixo gera O Lote para envio'''''''''''''''''''''''''
        Dim lote As New NFe()

        xmlAssinado = lote.GerarLoteNfe(xmlAssinado)

        '  MsgBox("XML assinado e salvo em," & vbCrLf & dest & nome_arq)

        Return xmlAssinado.OuterXml
    End Function


    Public Function gerar_xmlNFCe_envio2(ByVal xml As String, ByVal ambiente As String) As String
        Dim txtqrcodenfce As String
        Dim xmlAssinado12 As XmlDocument()
        ''''''''''''Rotina abaixo assinar o xml com certificado digital'''''''''''''''''''''''''
        xmldoc2.LoadXml(xml)

        xmldoc3.LoadXml(SepararNota3(xmldoc2.OuterXml))
        xmldoc2.LoadXml(SepararNota3(xmldoc2.OuterXml))


        xmlAssinado = CertificadoDigital.Assinar(GerarNotaProcessada2(xmldoc2.OuterXml), "infNFe", certificado)


        'If mskchave.Text.Substring(20, 2) = "65" Then

        ''''''''''''Rotina abaixo gera o QRCode da NFC-e'''''''''''''''''''''''''
        If txtqrcodenfce = "" Then

            txtqrcodenfce = GerarEndQRCodeXML(xmlAssinado.OuterXml)


            xmldoc2.LoadXml(xmlAssinado.OuterXml)


            xmlAssinado = Gerar_qrcode(xmldoc3.OuterXml, txtqrcodenfce, SepararNota_assinatura(xmlAssinado.OuterXml), ambiente)

            xml_processar.LoadXml(xmlAssinado.OuterXml)

        End If

        '   End If



        '  MsgBox("XML assinado e salvo em," & vbCrLf & dest & nome_arq)

        Return xmlAssinado.OuterXml
    End Function

    Public Function SepararNota3(ByVal vNfeDadosMsg As String) As String

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<infNFe")
        Dim nPosf As Int32 = vNfeDadosMsg.IndexOf("</infNFe")
        Dim vStringNfe2 As String
        Try
            vStringNfe2 = vNfeDadosMsg.Substring(nPosI, nPosf + 4)
        Catch ex As Exception
            vStringNfe2 = vNfeDadosMsg.Substring(nPosI, nPosf + 9 - nPosI)
        End Try


        Return vStringNfe2

    End Function

    Public Function GerarNotaProcessada2(ByVal vStringNfe As String) As XmlDocument
        Dim cVersaoDados As String = "4.00"

        'Montar a parte do XML referente ao Lote e acrescentar a Nota Fiscal
        Dim vStringLoteNfe As String = String.Empty
        vStringLoteNfe += "<?xml version=""1.0"" encoding=""utf-8""?>"
        vStringLoteNfe += "<NFe xmlns=""http://www.portalfiscal.inf.br/nfe"">"
        vStringLoteNfe += vStringNfe
        vStringLoteNfe += "</NFe>"

        Dim PastaNota As String = ""
        PastaNota = "C:\Users\adeni\Desktop\Nova_pasta" & "\"



        Dim NDoc = New XmlDocument()

        NDoc.LoadXml(vStringLoteNfe)



        '  Using xmltw As New XmlTextWriter(PastaNota & chavenfe + ".xml", New UTF8Encoding(False))
        'NDoc.WriteTo(xmltw)
        '   xmltw.Close()
        '  End Using

        Return NDoc
    End Function

    Public Function SepararNota_assinatura(ByVal vNfeDadosMsg As String) As String

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>

        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<Signature")
        Dim nPosF As Int32 = vNfeDadosMsg.IndexOf("</Signature>")

        ' MsgBox(nPosF - nPosI)

        Dim vStringNfe As String = vNfeDadosMsg.Substring(nPosI, nPosF - nPosI + 12)

        Return vStringNfe

    End Function

   
    Public Function Gerar_qrcode(ByVal vStringNfe As String, ByVal QRCODE As String, ByVal assinatura As String, ByVal ambiente As String) As XmlDocument
        Dim cVersaoDados As String = "4.00"

        'Montar a parte do XML referente ao Lote e acrescentar a Nota Fiscal
        Dim vStringLoteNfe As String = String.Empty
        vStringLoteNfe += "<?xml version=""1.0"" encoding=""utf-8""?>"
        vStringLoteNfe += "<NFe xmlns=""http://www.portalfiscal.inf.br/nfe"">"
        vStringLoteNfe += vStringNfe

        If QRCODE <> "" Then
            vStringLoteNfe += "<infNFeSupl>"
            vStringLoteNfe += "<qrCode>"
            vStringLoteNfe += "<![CDATA[" & QRCODE & "]]>"
            vStringLoteNfe += "</qrCode>"
            If ambiente = "2" Then
                vStringLoteNfe += "<urlChave>http://hnfce.fazenda.mg.gov.br/portalnfce</urlChave>"
            Else
                vStringLoteNfe += "<urlChave>http://nfce.fazenda.mg.gov.br/portalnfce</urlChave>"
            End If

            vStringLoteNfe += "</infNFeSupl>"
        End If
            vStringLoteNfe += assinatura
            vStringLoteNfe += "</NFe>"


            Dim NDoc = New XmlDocument()

            NDoc.LoadXml(vStringLoteNfe)

            Return NDoc
    End Function

    Public Function SepararNota_tagnfe(ByVal vNfeDadosMsg As String) As String
        Dim ass As String = SepararNota_assinatura(vNfeDadosMsg)
        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<infNFe")
        Dim nPosf As Int32 = vNfeDadosMsg.IndexOf("</infNFe")

        Dim vStringNfe As String

        vStringNfe += "<NFe xmlns=""http://www.portalfiscal.inf.br/nfe"">"
        vStringNfe += vNfeDadosMsg.Substring(nPosI, nPosf - nPosI + 9)
        vStringNfe += ass
        vStringNfe += "</NFe>"


        Return vStringNfe

    End Function
     Public Function SepararNota_prot(ByVal vNfeDadosMsg As String) As String

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<infNFe")
        Dim nPosf As Int32 = vNfeDadosMsg.IndexOf("</infNFe")

        Dim vStringNfe As String

        vStringNfe += "<NFe xmlns=""http://www.portalfiscal.inf.br/nfe"">"
        vStringNfe += vNfeDadosMsg.Substring(nPosI, nPosf - nPosI + 9)
        vStringNfe += "</NFe>"

      
        Return vStringNfe

    End Function

    Public Function SepararNota_NFe(ByVal vNfeDadosMsg As String) As String

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<NFe")
        Dim nPosf As Int32 = vNfeDadosMsg.IndexOf("</NFe")

        Dim vStringNfe As String

        vStringNfe += "<NFe xmlns=""http://www.portalfiscal.inf.br/nfe"">"
        vStringNfe += vNfeDadosMsg.Substring(nPosI, nPosf - nPosI + 6)
        vStringNfe += "</NFe>"


        Return vStringNfe

    End Function

    Public Function GerarNotaProcessadanfce(ByVal vStringNfe As String, ByVal VStringRecibo As String) As XmlDocument
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


        Dim NDoc = New XmlDocument()
        Try
            NDoc.LoadXml(vStringLoteNfe)
        Catch ex As Exception
            MsgBox(vStringLoteNfe, MsgBoxStyle.Exclamation, "a")
        End Try



        Return NDoc
    End Function


    Public Function SepararNota_prot34(ByVal vNfeDadosMsg As String) As String
        Dim vStringNfe2 As String
        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<NFe")
        If nPosI <> 21 Then
            vStringNfe2 = vNfeDadosMsg.Substring(nPosI, vNfeDadosMsg.Length - nPosI - 10)
        Else


            vNfeDadosMsg = gerar_xmlNFCe_envio(vNfeDadosMsg, empresa.ambiente_nfe)
            Dim nPosI2 As Int32 = vNfeDadosMsg.IndexOf("<NFe")
            vStringNfe2 = vNfeDadosMsg.Substring(nPosI2, vNfeDadosMsg.Length - nPosI2 - 10)
            '  vNfeDadosMsg = vNfeDadosMsg.ToString.Replace("<?xml version=""1.0""?>", "")
            '  vNfeDadosMsg = vNfeDadosMsg.ToString.Replace("<?xml version=""1.0"" encoding=""utf-8""?>", "")
            ' vStringNfe2 = vNfeDadosMsg
            ' MsgBox(vStringNfe2)
        End If



        Return vStringNfe2

    End Function
End Module
