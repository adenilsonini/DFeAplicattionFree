Imports System.Xml
Imports System.IO
Imports System.Reflection
Imports System.Globalization

Public Class NFe
    Public nfe1 As String

    Public Function GerarXML_cartacorrecao() As XmlDocument
        Dim configXML As New XmlWriterSettings()
        configXML.Indent = True
        configXML.IndentChars = ""
        configXML.NewLineOnAttributes = False
        configXML.OmitXmlDeclaration = False

        Dim xmlSaida As Stream = New MemoryStream()

        Dim oXmlGravar As XmlWriter = XmlWriter.Create(xmlSaida, configXML)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("evento", "http://www.portalfiscal.inf.br/nfe")
        oXmlGravar.WriteAttributeString("versao", versao.ToString())
        oXmlGravar.WriteStartElement("infEvento")
        oXmlGravar.WriteAttributeString("Id", "ID" & Id)
        oXmlGravar.WriteElementString("cOrgao", coduf)
        oXmlGravar.WriteElementString("tpAmb", _tpAmb)
        oXmlGravar.WriteElementString("CNPJ", cnpj)
        oXmlGravar.WriteElementString("chNFe", chave)
        oXmlGravar.WriteElementString("dhEvento", dataenv)
        oXmlGravar.WriteElementString("tpEvento", "110110")
        oXmlGravar.WriteElementString("nSeqEvento", _nSeqEvento)
        oXmlGravar.WriteElementString("verEvento", versao.ToString())
        oXmlGravar.WriteStartElement("detEvento")
        oXmlGravar.WriteAttributeString("versao", versao.ToString())
        oXmlGravar.WriteElementString("descEvento", "Carta de Correcao")
        oXmlGravar.WriteElementString("xCorrecao", _xCorrecao)
        oXmlGravar.WriteElementString("xCondUso", _xCondUso)
        oXmlGravar.WriteEndElement()
        oXmlGravar.WriteEndElement()
        'Fecha Tag infInut
        oXmlGravar.WriteEndElement()
        'Fecha Tag inutNFe
        oXmlGravar.Flush()
        xmlSaida.Flush()
        xmlSaida.Position = 0

        Dim documento As New XmlDocument()
        documento.Load(xmlSaida)
        oXmlGravar.Close()

        Return documento
    End Function
    Public Function GerarLoteNfe_dfe()
        Dim cVersaoDados As String = "1.00"




        'Pegar o último número de lote de NFe utilizado e acrescentar + 1 para novo envio
        Dim vArqXmlLote As String = "TryNfeLote_dfe.xml"
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

        Dim oXmlGravar As XmlWriter = XmlWriter.Create("TryNfeLote_dfe.xml", oSettings)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("DadosLoteNfe")
        oXmlGravar.WriteElementString("UltimoLoteEnviado", nNumeroLote.ToString())
        oXmlGravar.WriteEndElement()
        'DadosLoteNfe
        oXmlGravar.WriteEndDocument()
        oXmlGravar.Flush()
        oXmlGravar.Close()

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        Return nNumeroLote.ToString("000000000000000")

    End Function


    ''' <summary>
    ''' Evento inutilizacao NFCe 4.00
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GerarXMLinutilizacao() As XmlDocument
        Dim configXML As New XmlWriterSettings()
        configXML.Indent = True
        configXML.IndentChars = ""
        configXML.NewLineOnAttributes = False
        configXML.OmitXmlDeclaration = False

        Dim xmlSaida As Stream = New MemoryStream()

        Dim oXmlGravar As XmlWriter = XmlWriter.Create(xmlSaida, configXML)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("inutNFe", "http://www.portalfiscal.inf.br/nfe")
        oXmlGravar.WriteAttributeString("versao", versao.ToString())
        oXmlGravar.WriteStartElement("infInut")
        oXmlGravar.WriteAttributeString("Id", "ID" & Id)
        oXmlGravar.WriteElementString("tpAmb", _tpAmb)
        oXmlGravar.WriteElementString("xServ", "INUTILIZAR")
        oXmlGravar.WriteElementString("cUF", _coduf)
        oXmlGravar.WriteElementString("ano", _ano)
        oXmlGravar.WriteElementString("CNPJ", _cnpj)
        oXmlGravar.WriteElementString("mod", MOD_INU)
        oXmlGravar.WriteElementString("serie", Serie)
        oXmlGravar.WriteElementString("nNFIni", _NumNf_Ini)
        oXmlGravar.WriteElementString("nNFFin", NumNf_Fin)
        oXmlGravar.WriteElementString("xJust", xJust)
        oXmlGravar.WriteEndElement()
        oXmlGravar.WriteEndElement()
        'Fecha Tag infInut

        'Fecha Tag inutNFe
        oXmlGravar.Flush()
        xmlSaida.Flush()
        xmlSaida.Position = 0

        Dim documento As New XmlDocument()
        documento.Load(xmlSaida)
        oXmlGravar.Close()

        Return documento
    End Function
    ''' <summary>
    ''' Evento de cancelamento da NFE no modelo 2.00
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GerarXMLCancelamento() As XmlDocument
        Dim configXML As New XmlWriterSettings()
        configXML.Indent = True
        configXML.IndentChars = ""
        configXML.NewLineOnAttributes = False
        configXML.OmitXmlDeclaration = False

        Dim xmlSaida As Stream = New MemoryStream()

        Dim oXmlGravar As XmlWriter = XmlWriter.Create(xmlSaida, configXML)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("evento", "http://www.portalfiscal.inf.br/nfe")
        oXmlGravar.WriteAttributeString("versao", versao.ToString())
        oXmlGravar.WriteStartElement("infEvento")
        oXmlGravar.WriteAttributeString("Id", "ID" & Id)
        oXmlGravar.WriteElementString("cOrgao", coduf)
        oXmlGravar.WriteElementString("tpAmb", _tpAmb)
        oXmlGravar.WriteElementString("CNPJ", cnpj)
        oXmlGravar.WriteElementString("chNFe", chave)
        oXmlGravar.WriteElementString("dhEvento", dataenv)
        oXmlGravar.WriteElementString("tpEvento", codenv)
        oXmlGravar.WriteElementString("nSeqEvento", "1")
        oXmlGravar.WriteElementString("verEvento", versao.ToString())

        oXmlGravar.WriteStartElement("detEvento")
        oXmlGravar.WriteAttributeString("versao", versao.ToString())
        oXmlGravar.WriteElementString("descEvento", descenv)
        If tipo_cancelamento = "NFCe" Then
            oXmlGravar.WriteElementString("cOrgaoAutor", "31")
            oXmlGravar.WriteElementString("tpAutor", "1")
            oXmlGravar.WriteElementString("verAplic", versao.ToString())
        End If

        oXmlGravar.WriteElementString("nProt", nProt)
        oXmlGravar.WriteElementString("xJust", xJust)

        If tipo_cancelamento = "NFCe" Then
            oXmlGravar.WriteElementString("chNFeRef", chaveNFCE_vinculada)
        End If

        oXmlGravar.WriteEndElement()
        oXmlGravar.WriteEndElement()
        'Fecha Tag infInut
        oXmlGravar.WriteEndElement()
        'Fecha Tag inutNFe
        oXmlGravar.Flush()
        xmlSaida.Flush()
        xmlSaida.Position = 0

        Dim documento As New XmlDocument()
        documento.Load(xmlSaida)
        oXmlGravar.Close()

        Return documento
    End Function

    Public Function GerarDPEC() As XmlDocument
        Dim configXML As New XmlWriterSettings()
        configXML.Indent = True
        configXML.IndentChars = ""
        configXML.NewLineOnAttributes = False
        configXML.OmitXmlDeclaration = False

        Dim xmlSaida As Stream = New MemoryStream()

        Dim oXmlGravar As XmlWriter = XmlWriter.Create(xmlSaida, configXML)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("envDPEC", "http://www.portalfiscal.inf.br/nfe")
        oXmlGravar.WriteAttributeString("versao", "1.01")
        oXmlGravar.WriteStartElement("infDPEC")
        'oXmlGravar.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
        oXmlGravar.WriteAttributeString("Id", "DPEC" & funcoesNfe.removeFormatacao(infNFE.Emit.CNPJ))

        oXmlGravar.WriteStartElement("ideDec")
        oXmlGravar.WriteElementString("cUF", infNFE.Ide.cUF.ToString())
        oXmlGravar.WriteElementString("tpAmb", infNFE.Ide.tpAmb.ToString())
        oXmlGravar.WriteElementString("verProc", infNFE.Ide.verProc.ToString())
        oXmlGravar.WriteElementString("CNPJ", funcoesNfe.removeFormatacao(infNFE.Emit.CNPJ))
        oXmlGravar.WriteElementString("IE", funcoesNfe.removeFormatacao(infNFE.Emit.IE))
        oXmlGravar.WriteEndElement()
        'fecha ideDec
        oXmlGravar.WriteStartElement("resNFe")
        oXmlGravar.WriteElementString("chNFe", Id)

        If (infNFE.Dest.CNPJ IsNot Nothing) AndAlso (infNFE.Dest.CNPJ.Length > 0) Then
            oXmlGravar.WriteElementString("CNPJ", funcoesNfe.removeFormatacao(infNFE.Dest.CNPJ))
        Else
            oXmlGravar.WriteElementString("CPF", funcoesNfe.removeFormatacao(infNFE.Dest.CPF))
        End If

        oXmlGravar.WriteElementString("UF", infNFE.Dest.EnderDest.UF)
        Dim cultura As New CultureInfo("en-US")
        ' oXmlGravar.WriteElementString("vNF", infNFE.Total.IcmsTot.vNF.ToString("#0.00", cultura.NumberFormat))
        '  oXmlGravar.WriteElementString("vICMS", infNFE.Total.IcmsTot.vICMS.ToString("#0.00", cultura.NumberFormat))
        ' oXmlGravar.WriteElementString("vST", infNFE.Total.IcmsTot.vST.ToString("#0.00", cultura.NumberFormat))
        oXmlGravar.WriteEndElement()
        'fecha resNFe
        oXmlGravar.WriteEndElement()
        'fecha infDPEC
        oXmlGravar.WriteEndElement()
        'fecha envDPEC
        oXmlGravar.Flush()
        xmlSaida.Flush()
        xmlSaida.Position = 0

        Dim documento As New XmlDocument()
        documento.Load(xmlSaida)

        oXmlGravar.Close()


        Return documento
    End Function

    'FUNÇÃO QUE POR RECURSIVIDADE PREENCHE ESCREVE OS DADOS DO XML
    Private Sub objetoParaXML(ByVal xmlWriter As XmlWriter, ByVal objeto As Object, ByVal ignorarDeclaracaoElemento As Boolean)
        If objeto Is Nothing Then
            Exit Sub
        End If

        Dim tipoObjeto As Type
        tipoObjeto = objeto.[GetType]()
        Dim propriedades As PropertyInfo()
        propriedades = tipoObjeto.GetProperties()

        'VERIFICA SE É UM CAMPO DO TIPO LIST
        'SE FOR ADICIONA NOVO ELEMENTE
        If Not ignorarDeclaracaoElemento And tipoObjeto.Name <> "List`1" Then
            xmlWriter.WriteStartElement(tipoObjeto.Name)
        End If

        'SE FORM UMA LISTA CHAMA FUNÇÃO NOVAMENTE PARA PREENCHER ELEMENTOS DA LISTA
        If tipoObjeto.Name = "List`1" Then
            If objeto.ToString.Contains("dup") Then
                For Each Ddup As dup In objeto
                    objetoParaXML(xmlWriter, Ddup, False)
                    Continue For
                Next
            ElseIf objeto.ToString.Contains("med") Then
                For Each Dmed As rastro In objeto
                    objetoParaXML(xmlWriter, Dmed, False)
                    Continue For
                Next

                '''' NOVO COLOCADO POR ANTONIO
            ElseIf objeto.ToString.Contains("VeicProd") Then
                For Each Dmed As rastro In objeto
                    objetoParaXML(xmlWriter, Dmed, False)
                    Continue For
                Next

            Else
                For Each DNFref As NFref In objeto
                    objetoParaXML(xmlWriter, DNFref, False)
                    Continue For
                Next
            End If
            Exit Sub
        End If

        'VERIFICA CAMPOS E ADICIONA TAGS E ELEMENTOS XML
        For Each propriedade As PropertyInfo In propriedades

            If funcoesNfe.novaTag(propriedade) AndAlso Not (propriedade.GetValue(objeto, Nothing) Is Nothing) Then
                objetoParaXML(xmlWriter, propriedade.GetValue(objeto, Nothing), False)
                Continue For
            End If

            Dim obj As Object() = propriedade.GetCustomAttributes(False)
            funcoesNfe.gravarElemento(xmlWriter, propriedade.Name, propriedade.GetValue(objeto, Nothing), obj)
        Next
        If Not ignorarDeclaracaoElemento Then
            xmlWriter.WriteEndElement()
        End If
    End Sub

    Public Function GerarLote() As String
      
        'Pegar o último número de lote de NFe utilizado e acrescentar + 1 para novo envio
        Dim vArqXmlLote As String = "TryNfeLote.xml"
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

        Dim oXmlGravar As XmlWriter = XmlWriter.Create("TryNfeLote.xml", oSettings)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("DadosLoteNfe")
        oXmlGravar.WriteElementString("UltimoLoteEnviado", nNumeroLote.ToString())
        oXmlGravar.WriteEndElement()
        'DadosLoteNfe
        oXmlGravar.WriteEndDocument()
        oXmlGravar.Flush()
        oXmlGravar.Close()




        ' documentoXML.Save(Application.StartupPath & "\XML\" & nome_arq & " - EnviNFe.xml")

        Return nNumeroLote.ToString("000000000000000")

    End Function

    Public Function GerarLoteNfe(ByRef documentoXML As XmlDocument) As XmlDocument
        Dim cVersaoDados As String = "4.00"
        Dim tipoenvio As String = "0"

        'Montar a string da Nfe a ser montado o Lote
        Dim vNfeDadosMsg As String = documentoXML.OuterXml

        'Pegar o último número de lote de NFe utilizado e acrescentar + 1 para novo envio
        Dim vArqXmlLote As String = "TryNfeLote.xml"
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

        Dim oXmlGravar As XmlWriter = XmlWriter.Create("TryNfeLote.xml", oSettings)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("DadosLoteNfe")
        oXmlGravar.WriteElementString("UltimoLoteEnviado", nNumeroLote.ToString())
        oXmlGravar.WriteEndElement()
        'DadosLoteNfe
        oXmlGravar.WriteEndDocument()
        oXmlGravar.Flush()
        oXmlGravar.Close()




        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<NFe")
        Dim nPosF As Int32 = vNfeDadosMsg.Length - nPosI
        Dim vStringNfe As String = vNfeDadosMsg.Substring(nPosI, nPosF)

        'Montar a parte do XML referente ao Lote e acrescentar a Nota Fiscal
        Dim vStringLoteNfe As String = String.Empty
        vStringLoteNfe += "<?xml version=""1.0"" encoding=""utf-8""?>"
        vStringLoteNfe += "<enviNFe xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""" & cVersaoDados & """>"
        vStringLoteNfe += "<idLote>" & nNumeroLote.ToString("000000000000000") & "</idLote>"
        vStringLoteNfe += "<indSinc>" & tipoenvio & "</indSinc>"
        vStringLoteNfe += vStringNfe
        vStringLoteNfe += "</enviNFe>"

        documentoXML.LoadXml(vStringLoteNfe)

       
        ' documentoXML.Save(Application.StartupPath & "\XML\" & nome_arq & " - EnviNFe.xml")

        Return documentoXML

    End Function


    Public Function GerarXML() As XmlDocument
        Dim configXML As New XmlWriterSettings()
        configXML.Indent = True
        configXML.IndentChars = ""
        configXML.NewLineOnAttributes = False
        configXML.OmitXmlDeclaration = False

        Dim xmlSaida As Stream = New MemoryStream()

        Dim oXmlGravar As XmlWriter = XmlWriter.Create(xmlSaida, configXML)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("NFe", "http://www.portalfiscal.inf.br/nfe")
        'abre nfe
        oXmlGravar.WriteStartElement("infNFe")
        oXmlGravar.WriteAttributeString("Id", "NFe" & Id.ToString())
        oXmlGravar.WriteAttributeString("versao", versao.ToString())

        Dim tipoObjeto As Type
        tipoObjeto = infNFE.Ide.[GetType]()
        Dim propriedades As PropertyInfo()
        propriedades = tipoObjeto.GetProperties()

        objetoParaXML(oXmlGravar, infNFE.Ide, False)
        objetoParaXML(oXmlGravar, infNFE.Emit, False)
        objetoParaXML(oXmlGravar, infNFE.Dest, False)


        For Each detalhe As det In infNFE.Det
            oXmlGravar.WriteStartElement("det")
            oXmlGravar.WriteAttributeString("nItem", detalhe.nItem.ToString())

            objetoParaXML(oXmlGravar, detalhe.Prod, False)

            '  oXmlGravar.WriteStartElement("imposto")
            objetoParaXML(oXmlGravar, detalhe.Imposto, False)
            '  objetoParaXML(oXmlGravar, detalhe.Imposto.Ii, False)
            '   objetoParaXML(oXmlGravar, detalhe.Imposto.Ipi, False)
            '  objetoParaXML(oXmlGravar, detalhe.Imposto.Pis, False)
            ' objetoParaXML(oXmlGravar, detalhe.Imposto.Cofins, False)

            'fecha TAG imposto...
            '  oXmlGravar.WriteEndElement()

            'fecha TAG det...
            oXmlGravar.WriteEndElement()
        Next

        objetoParaXML(oXmlGravar, infNFE.Total, False)
        objetoParaXML(oXmlGravar, infNFE.Transp, False)
        ' objetoParaXML(oXmlGravar, infNFE.veic, False)
        objetoParaXML(oXmlGravar, infNFE.Cobr, False)

        objetoParaXML(oXmlGravar, infNFE.pag, False)

        objetoParaXML(oXmlGravar, infNFE.InfAdic, False)

        oXmlGravar.WriteEndElement()
        'fecha infNFe
        oXmlGravar.WriteEndElement()
        'fecha NFe
        oXmlGravar.Flush()
        xmlSaida.Flush()
        xmlSaida.Position = 0

        Dim documento As New XmlDocument()
        documento.Load(xmlSaida)

        'documento.Save("c:\\testeXML.xml");

        oXmlGravar.Close()

        Return documento
    End Function

    Public Function GerarXMLRecibo() As XmlDocument
        Dim configXML As New XmlWriterSettings()
        configXML.Indent = True
        configXML.IndentChars = ""
        configXML.NewLineOnAttributes = False
        configXML.OmitXmlDeclaration = False

        Dim xmlSaida As Stream = New MemoryStream()

        Dim oXmlGravar As XmlWriter = XmlWriter.Create(xmlSaida, configXML)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("consReciNFe", "http://www.portalfiscal.inf.br/nfe")
        oXmlGravar.WriteAttributeString("versao", versao)
        oXmlGravar.WriteElementString("tpAmb", infNFE.Ide.tpAmb.ToString())
        oXmlGravar.WriteElementString("nRec", nRec)


        oXmlGravar.WriteEndElement()
        'Fecha elemento consReciNFe
        oXmlGravar.Flush()
        xmlSaida.Flush()
        xmlSaida.Position = 0

        Dim documento As New XmlDocument()
        documento.Load(xmlSaida)
        oXmlGravar.Close()

        Return documento
    End Function


    Public Function Gerarmanifestacaodest() As XmlDocument
        Dim configXML As New XmlWriterSettings()
        configXML.Indent = True
        configXML.IndentChars = ""
        configXML.NewLineOnAttributes = False
        configXML.OmitXmlDeclaration = False

        Dim xmlSaida As Stream = New MemoryStream()

        Dim oXmlGravar As XmlWriter = XmlWriter.Create(xmlSaida, configXML)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("evento", "http://www.portalfiscal.inf.br/nfe")
        oXmlGravar.WriteAttributeString("versao", versao.ToString())
        oXmlGravar.WriteStartElement("infEvento")
        oXmlGravar.WriteAttributeString("Id", "ID" & Id)
        oXmlGravar.WriteElementString("cOrgao", coduf)
        oXmlGravar.WriteElementString("tpAmb", _tpAmb)
        oXmlGravar.WriteElementString("CNPJ", cnpj)
        oXmlGravar.WriteElementString("chNFe", chave)
        oXmlGravar.WriteElementString("dhEvento", dataenv)
        oXmlGravar.WriteElementString("tpEvento", codenv)
        oXmlGravar.WriteElementString("nSeqEvento", "1")
        oXmlGravar.WriteElementString("verEvento", versao.ToString())
        oXmlGravar.WriteStartElement("detEvento")
        oXmlGravar.WriteAttributeString("versao", versao.ToString())
        oXmlGravar.WriteElementString("descEvento", descenv)
        If xJust <> "" Then
            oXmlGravar.WriteElementString("xJust", xJust)
        End If
        oXmlGravar.WriteEndElement()
        oXmlGravar.WriteEndElement()
        'Fecha Tag infInut
        oXmlGravar.WriteEndElement()
        'Fecha Tag inutNFe
        oXmlGravar.Flush()
        xmlSaida.Flush()
        xmlSaida.Position = 0

        Dim documento As New XmlDocument()
        documento.Load(xmlSaida)
        oXmlGravar.Close()

        Return documento
    End Function


    Public Sub geravalidacao(ByRef documentoXML As XmlDocument)
        Dim cVersaoDados As String = "3.10"
        Dim nNumeroLote As Int32 = 1
        'Montar a string da Nfe a ser montado o Lote
        Dim vNfeDadosMsg As String = documentoXML.OuterXml



        'Salvar o número de lote de NFe utilizado
        Dim oSettings As New XmlWriterSettings()
        oSettings.Indent = True
        oSettings.IndentChars = ""
        oSettings.NewLineOnAttributes = False
        oSettings.OmitXmlDeclaration = False

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<NFe")
        Dim n5t As Int32 = vNfeDadosMsg.IndexOf("<protNFe")
        Dim total As Int32 = vNfeDadosMsg.Length - n5t
        Dim nPosF As Int32 = vNfeDadosMsg.Length - nPosI
        Dim vStringNfe As String = vNfeDadosMsg.Substring(nPosI, nPosF - total)

        'Montar a parte do XML referente ao Lote e acrescentar a Nota Fiscal
        Dim vStringLoteNfe As String = String.Empty
        vStringLoteNfe += "<?xml version=""1.0"" encoding=""utf-8""?>"
        vStringLoteNfe += "<enviNFe xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""" & cVersaoDados & """>"
        vStringLoteNfe += "<idLote>" & nNumeroLote.ToString("000000000000000") & "</idLote>"
        vStringLoteNfe += "<indSinc>0</indSinc>"
        vStringLoteNfe += vStringNfe
        vStringLoteNfe += "</enviNFe>"

        documentoXML.LoadXml(vStringLoteNfe)
    End Sub

    Private _infNFE As infNFE

    'private string _Id;

    Private _versao As String
    Public Property versao() As String
        Get
            Return _versao
        End Get
        Set(ByVal value As String)
            _versao = value
        End Set
    End Property

    Private _tpAmb As String
    Public Property tpAmb() As String
        Get
            Return _tpAmb
        End Get
        Set(ByVal value As String)
            _tpAmb = value
        End Set
    End Property

    Private _Id As String
    Public Property Id() As String
        Get
            Return _Id
        End Get
        Set(ByVal value As String)
            _Id = value
        End Set
    End Property
    ''' <summary>
    ''' Utilizado na geração de XML para consulta de recibo
    ''' </summary>
    Private _nRec As String
    Public Property nRec() As String
        Get
            Return _nRec
        End Get
        Set(ByVal value As String)
            _nRec = value
        End Set
    End Property
    ''' <summary>
    ''' Informar o número do Protocolo de Autorização da NF-e a ser Cancelada.
    ''' 1 posição (1 – Secretaria de Fazenda Estadual
    ''' 2 – Receita Federal); 2 posições para código da UF;
    ''' 2 posições ano;
    ''' 10 seqüencial no ano
    ''' </summary>
    Private _nProt As String
    Public Property nProt() As String
        Get
            Return _nProt
        End Get
        Set(ByVal value As String)
            _nProt = value
        End Set
    End Property
    Private _xJust As String
    Public Property xJust() As String
        Get
            Return _xJust
        End Get
        Set(ByVal value As String)
            _xJust = value
        End Set
    End Property
    Private _ano As String
    Public Property ano() As String
        Get
            Return _ano
        End Get
        Set(ByVal value As String)
            _ano = value
        End Set
    End Property
    Private _NumNf_Ini As Integer
    Public Property NumNf_Ini() As Integer
        Get
            Return _NumNf_Ini
        End Get
        Set(ByVal value As Integer)
            _NumNf_Ini = value
        End Set
    End Property
    Private _NumNf_Fin As Integer
    Public Property NumNf_Fin() As Integer
        Get
            Return _NumNf_Fin
        End Get
        Set(ByVal value As Integer)
            _NumNf_Fin = value
        End Set
    End Property

    Public ReadOnly Property infNFE() As infNFE
        Get
            Return _infNFE
        End Get
    End Property

    Public Sub New()
        _infNFE = New infNFE()
    End Sub
    Private _dataenv As String
    Public Property dataenv() As String
        Get
            Return _dataenv
        End Get
        Set(ByVal value As String)
            _dataenv = value
        End Set
    End Property

    Private _descenv As String
    Public Property descenv() As String
        Get
            Return _descenv
        End Get
        Set(ByVal value As String)
            _descenv = value
        End Set
    End Property

    Private _codenv As String
    Public Property codenv() As String
        Get
            Return _codenv
        End Get
        Set(ByVal value As String)
            _codenv = value
        End Set
    End Property

    Private _cnpj As String
    Public Property cnpj() As String
        Get
            Return _cnpj
        End Get
        Set(ByVal value As String)
            _cnpj = value
        End Set
    End Property

    ' Esta função diz ao Serializador para NÃO criar a tag se o campo estiver vazio
    Public Function ShouldSerializecnpj() As Boolean
        Return Not String.IsNullOrEmpty(_cnpj)
    End Function

    Private _cpf As String
    Public Property cpf() As String
        Get
            Return _cpf
        End Get
        Set(ByVal value As String)
            _cpf = value
        End Set
    End Property

    ' Esta função diz ao Serializador para NÃO criar a tag se o campo estiver vazio
    Public Function ShouldSerializecpf() As Boolean
        Return Not String.IsNullOrEmpty(_cpf)
    End Function

    Private _coduf As String
    Public Property coduf() As String
        Get
            Return _coduf
        End Get
        Set(ByVal value As String)
            _coduf = value
        End Set
    End Property

    Private _chave As String
    Public Property chave() As String
        Get
            Return _chave
        End Get
        Set(ByVal value As String)
            _chave = value
        End Set
    End Property

    Private _chaveNFCE_vinculada As String
    Public Property chaveNFCE_vinculada() As String
        Get
            Return _chaveNFCE_vinculada
        End Get
        Set(ByVal value As String)
            _chaveNFCE_vinculada = value
        End Set
    End Property

    Private _xCorrecao As String
    Public Property xCorrecao() As String
        Get
            Return _xCorrecao
        End Get
        Set(ByVal value As String)
            _xCorrecao = value
        End Set
    End Property

    Private _xCondUso As String
    Public Property xCondUso() As String
        Get
            Return _xCondUso
        End Get
        Set(ByVal value As String)
            _xCondUso = value
        End Set
    End Property

    Private _Serie As Integer
    Public Property Serie() As Integer
        Get
            Return _Serie
        End Get
        Set(ByVal value As Integer)
            _Serie = value
        End Set
    End Property

    Private _MOD_INUT As String
    Public Property MOD_INU() As String
        Get
            Return _MOD_INUT
        End Get
        Set(ByVal value As String)
            _MOD_INUT = value
        End Set
    End Property


    Private _nSeqEvento As String
    Public Property nSeqEvento() As String
        Get
            Return _nSeqEvento
        End Get
        Set(ByVal value As String)
            _nSeqEvento = value
        End Set
    End Property

    Private _tipo_cancelamento As String
    Public Property tipo_cancelamento() As String
        Get
            Return _tipo_cancelamento
        End Get
        Set(ByVal value As String)
            _tipo_cancelamento = value
        End Set
    End Property

End Class