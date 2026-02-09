Imports System.Xml


Public Class LerXmlNFE
    Public Structure NotaEletronica
        Dim NotaEletronica As NFe
        Dim ProtocoloAutorizacao As String
        Dim Datarecibo As Date
    End Structure
    Public Function LerNFE(ByVal dados As XmlDocument) As NotaEletronica


        'CRIA UM NOVO DOCUMENTO XML
        '   Dim dados As XmlDocument = New XmlDocument

        '  dados.Load(CaminhoNFE)

        'DESMEMBRA RETORNO XML
        '-----------------------------------------------------------------------------------
        Dim NotaComProtocolo As New NotaEletronica

        For Each outerNode As XmlNode In dados
            If outerNode.Name = "enviNFe" Then
                For Each InnerNode As XmlNode In outerNode
                    If InnerNode.Name = "NFe" Then
                        NotaComProtocolo = PegaDadosNodeNFe(InnerNode)
                    End If

                Next
            ElseIf outerNode.Name = "nfeProc" Then
                For Each InnerNode As XmlNode In outerNode
                    If InnerNode.Name = "NFe" Then
                        NotaComProtocolo = PegaDadosNodeNFe(InnerNode)
                    End If
                    If InnerNode.Name = "protNFe" Then
                        NotaComProtocolo.ProtocoloAutorizacao = InnerNode("infProt")("nProt").InnerText
                        NotaComProtocolo.Datarecibo = InnerNode("infProt")("dhRecbto").InnerText
                    End If
                Next
            ElseIf outerNode.Name = "NFe" Then
                NotaComProtocolo = PegaDadosNodeNFe(outerNode)
            End If
        Next

        Return NotaComProtocolo

        'Dim xmlGerado As XmlDocument = NotaComProtocolo.NotaEletronica.GerarXML()
        'Salva uma cópia do XML não assinado - ATENÇÃO - se você está utilizando Windows Vista/7/Server, salvar na Unidade C pode não ser possível caso o VS2008 não esteja rodando como administrador
        'xmlGerado.Save("c:\TESTELEITURA.xml")

    End Function

    Private Function PegaDadosNodeNFe(ByRef NodeNota As XmlNode) As NotaEletronica

        Dim NotaLida As New NFe()
        Dim ContarDet As Integer = 0

        For Each InnerNode As XmlNode In NodeNota.ChildNodes
            If InnerNode.Name = "infNFe" Then
                NotaLida.Id = InnerNode.Attributes.ItemOf("Id").InnerText.Replace("NFe", "")
                NotaLida.versao = InnerNode.Attributes.ItemOf("versao").InnerText

                For Each InnerNode2 As XmlNode In InnerNode.ChildNodes

                    If (InnerNode2.Name = "ide") Then
                        Dim ContarEntradas As Integer = 0

                        NotaLida.infNFE.Ide.cUF = InnerNode2("cUF").InnerText
                        NotaLida.infNFE.Ide.cNF = InnerNode2("cNF").InnerText
                        NotaLida.infNFE.Ide.natOp = InnerNode2("natOp").InnerText
                        '  NotaLida.infNFE.Ide.indPag = InnerNode2("indPag").InnerText
                        NotaLida.infNFE.Ide.[mod] = InnerNode2("mod").InnerText
                        NotaLida.infNFE.Ide.serie = InnerNode2("serie").InnerText
                        NotaLida.infNFE.Ide.nNF = InnerNode2("nNF").InnerText
                        NotaLida.infNFE.Ide.tpNF = InnerNode2("tpNF").InnerText
                        NotaLida.infNFE.Ide.cMunFG = InnerNode2("cMunFG").InnerText
                        NotaLida.infNFE.Ide.tpImp = InnerNode2("tpImp").InnerText
                        NotaLida.infNFE.Ide.tpEmis = InnerNode2("tpEmis").InnerText
                        NotaLida.infNFE.Ide.cDV = InnerNode2("cDV").InnerText
                        NotaLida.infNFE.Ide.tpAmb = InnerNode2("tpAmb").InnerText
                        NotaLida.infNFE.Ide.finNFe = InnerNode2("finNFe").InnerText
                        NotaLida.infNFE.Ide.procEmi = InnerNode2("procEmi").InnerText
                        NotaLida.infNFE.Ide.verProc = InnerNode2("verProc").InnerText

                        NotaLida.infNFE.Ide.dEmi = InnerNode2("dhEmi").InnerText

                        NotaLida.infNFE.Ide.indFinal = InnerNode2("indFinal").InnerText
                        NotaLida.infNFE.Ide.indPres = InnerNode2("indPres").InnerText

                        If Not InnerNode2("dhSaiEnt") Is Nothing Then
                            NotaLida.infNFE.Ide.dSaiEnt = InnerNode2("dhSaiEnt").InnerText
                        End If

                        If Not InnerNode2("dhCont") Is Nothing Then
                            NotaLida.infNFE.Ide.dhCont = InnerNode2("dhCont").InnerText
                        End If
                        If Not InnerNode2("xJust") Is Nothing Then
                            NotaLida.infNFE.Ide.xJust = InnerNode2("xJust").InnerText
                        End If


                    ElseIf (InnerNode2.Name = "emit") Then

                        If Not InnerNode2("CNPJ") Is Nothing Then
                            NotaLida.infNFE.Emit.CNPJ = InnerNode2("CNPJ").InnerText
                        End If
                        If Not InnerNode2("CPF") Is Nothing Then
                            NotaLida.infNFE.Emit.CNPJ = InnerNode2("CPF").InnerText
                        End If

                        NotaLida.infNFE.Emit.xNome = InnerNode2("xNome").InnerText

                        If Not InnerNode2("xFant") Is Nothing Then
                            NotaLida.infNFE.Emit.xFant = InnerNode2("xFant").InnerText
                        End If

                        NotaLida.infNFE.Emit.EnderEmit.xLgr = InnerNode2("enderEmit")("xLgr").InnerText
                        NotaLida.infNFE.Emit.EnderEmit.nro = InnerNode2("enderEmit")("nro").InnerText

                        If Not InnerNode2("enderEmit")("xCpl") Is Nothing Then
                            NotaLida.infNFE.Emit.EnderEmit.xCpl = InnerNode2("enderEmit")("xCpl").InnerText
                        End If

                        NotaLida.infNFE.Emit.EnderEmit.xBairro = InnerNode2("enderEmit")("xBairro").InnerText
                        NotaLida.infNFE.Emit.EnderEmit.cMun = InnerNode2("enderEmit")("cMun").InnerText
                        NotaLida.infNFE.Emit.EnderEmit.xMun = InnerNode2("enderEmit")("xMun").InnerText
                        NotaLida.infNFE.Emit.EnderEmit.UF = InnerNode2("enderEmit")("UF").InnerText
                        NotaLida.infNFE.Emit.EnderEmit.CEP = InnerNode2("enderEmit")("CEP").InnerText

                        If Not InnerNode2("enderEmit")("xPais") Is Nothing Then
                            NotaLida.infNFE.Emit.EnderEmit.xPais = InnerNode2("enderEmit")("xPais").InnerText
                        End If

                        If Not InnerNode2("enderEmit")("fone") Is Nothing Then
                            NotaLida.infNFE.Emit.EnderEmit.fone = InnerNode2("enderEmit")("fone").InnerText
                        End If

                        NotaLida.infNFE.Emit.IE = InnerNode2("IE").InnerText
                        If Not InnerNode2("IEST") Is Nothing Then
                            NotaLida.infNFE.Emit.IEST = InnerNode2("IEST").InnerText
                        End If
                        If Not InnerNode2("IM") Is Nothing Then
                            NotaLida.infNFE.Emit.IM = InnerNode2("IM").InnerText
                        End If
                        If Not InnerNode2("CNAE") Is Nothing Then
                            NotaLida.infNFE.Emit.CNAE = InnerNode2("CNAE").InnerText
                        End If
                        NotaLida.infNFE.Emit.CRT = InnerNode2("CRT").InnerText


                    ElseIf (InnerNode2.Name = "dest") Then

                        If Not InnerNode2("CNPJ") Is Nothing Then
                            NotaLida.infNFE.Dest.CNPJ = InnerNode2("CNPJ").InnerText
                        End If
                        If Not InnerNode2("CPF") Is Nothing Then
                            NotaLida.infNFE.Dest.CPF = InnerNode2("CPF").InnerText
                        End If

                        NotaLida.infNFE.Dest.xNome = InnerNode2("xNome").InnerText
                        NotaLida.infNFE.Dest.EnderDest.xLgr = InnerNode2("enderDest")("xLgr").InnerText
                        NotaLida.infNFE.Dest.EnderDest.nro = InnerNode2("enderDest")("nro").InnerText
                        NotaLida.infNFE.Dest.EnderDest.xBairro = InnerNode2("enderDest")("xBairro").InnerText
                        NotaLida.infNFE.Dest.EnderDest.cMun = InnerNode2("enderDest")("cMun").InnerText
                        NotaLida.infNFE.Dest.EnderDest.xMun = InnerNode2("enderDest")("xMun").InnerText
                        NotaLida.infNFE.Dest.EnderDest.UF = InnerNode2("enderDest")("UF").InnerText

                        If Not InnerNode2("email") Is Nothing Then
                            NotaLida.infNFE.Dest.email = InnerNode2("email").InnerText
                        End If
                        If Not InnerNode2("enderDest")("CEP") Is Nothing Then
                            NotaLida.infNFE.Dest.EnderDest.CEP = InnerNode2("enderDest")("CEP").InnerText
                        End If
                        If Not InnerNode2("enderDest")("cPais") Is Nothing Then
                            NotaLida.infNFE.Dest.EnderDest.cPais = InnerNode2("enderDest")("cPais").InnerText
                        End If
                        If Not InnerNode2("enderDest")("xPais") Is Nothing Then
                            NotaLida.infNFE.Dest.EnderDest.xPais = InnerNode2("enderDest")("xPais").InnerText
                        End If
                        If Not InnerNode2("enderDest")("fone") Is Nothing Then
                            NotaLida.infNFE.Dest.EnderDest.fone = InnerNode2("enderDest")("fone").InnerText
                        End If
                        If Not InnerNode2("IE") Is Nothing Then
                            NotaLida.infNFE.Dest.IE = InnerNode2("IE").InnerText
                        End If
                        If Not InnerNode2("indIEDest") Is Nothing Then

                            If InnerNode2("indIEDest").InnerText = "1" Then
                                NotaLida.infNFE.Dest.indIEDest = "1 – Contribuinte ICMS"
                            End If
                            If InnerNode2("indIEDest").InnerText = "2" Then
                                NotaLida.infNFE.Dest.indIEDest = "2 – Contribuinte isento de inscrição"
                            End If
                            If InnerNode2("indIEDest").InnerText = "9" Then
                                NotaLida.infNFE.Dest.indIEDest = "9 – Não Contribuinte"
                            End If

                        End If



                    ElseIf (InnerNode2.Name = "det") Then


                        ContarDet += 1

                        Dim Detalhamento As New det
                        Detalhamento.nItem = ContarDet
                        Detalhamento.Prod.cProd = InnerNode2("prod")("cProd").InnerText
                        Detalhamento.Prod.cEAN = InnerNode2("prod")("cEAN").InnerText
                        Detalhamento.Prod.xProd = InnerNode2("prod")("xProd").InnerText
                        Detalhamento.Prod.NCM = InnerNode2("prod")("NCM").InnerText

                        If Not InnerNode2("prod")("EXTIPI") Is Nothing Then
                            Detalhamento.Prod.EXTIPI = InnerNode2("prod")("EXTIPI").InnerText
                        End If

                        Detalhamento.Prod.CFOP = InnerNode2("prod")("CFOP").InnerText
                        Detalhamento.Prod.uCom = InnerNode2("prod")("uCom").InnerText
                        Detalhamento.Prod.qCom = InnerNode2("prod")("qCom").InnerText.Replace(".", ",")
                        Detalhamento.Prod.vUnCom = InnerNode2("prod")("vUnCom").InnerText.Replace(".", ",")
                        Detalhamento.Prod.vProd = InnerNode2("prod")("vProd").InnerText.Replace(".", ",")
                        Detalhamento.Prod.cEANTrib = InnerNode2("prod")("cEANTrib").InnerText
                        Detalhamento.Prod.uTrib = InnerNode2("prod")("uTrib").InnerText.Replace(".", ",")
                        Detalhamento.Prod.qTrib = InnerNode2("prod")("qTrib").InnerText.Replace(".", ",")
                        Detalhamento.Prod.vUnTrib = InnerNode2("prod")("vUnTrib").InnerText.Replace(".", ",")

                        If Not InnerNode2("prod")("vDesc") Is Nothing Then
                            Detalhamento.Prod.vDesc = InnerNode2("prod")("vDesc").InnerText
                        End If
                        If Not InnerNode2("prod")("vFrete") Is Nothing Then
                            Detalhamento.Prod.vFrete = InnerNode2("prod")("vFrete").InnerText
                        End If
                        If Not InnerNode2("prod")("vSeg") Is Nothing Then
                            Detalhamento.Prod.vSeg = InnerNode2("prod")("vSeg").InnerText
                        End If
                        If Not InnerNode2("prod")("vOutro") Is Nothing Then
                            Detalhamento.Prod.vOutro = InnerNode2("prod")("vOutro").InnerText
                        End If
                        If Not InnerNode2("prod")("indTot") Is Nothing Then
                            Detalhamento.Prod.indTot = InnerNode2("prod")("indTot").InnerText
                        End If
                        Detalhamento.Prod.cst = InnerNode2("imposto")("ICMS").ChildNodes.Item(0)("orig").InnerText + InnerNode2("imposto")("ICMS").ChildNodes.Item(0).ChildNodes.Item(1).InnerText


                        For Each InnerNode3 As XmlNode In InnerNode2.ChildNodes
                            If (InnerNode3.Name = "prod") Then
                                For Each InnerNode4 As XmlNode In InnerNode3.ChildNodes
                                    If (InnerNode4.Name = "med") Then
                                        Dim Cmed As New rastro
                                        Cmed.nLote = InnerNode4("nLote").InnerText
                                        Cmed.qLote = InnerNode4("qLote").InnerText.Replace(".", ",")
                                        Cmed.dFab = InnerNode4("dFab").InnerText
                                        Cmed.dVal = InnerNode4("dVal").InnerText
                                        Cmed.vPMC = InnerNode4("vPMC").InnerText.Replace(".", ",")
                                        Detalhamento.Prod.Med.Add(Cmed)
                                    End If
                                Next
                            End If

                            If (InnerNode3.Name = "infAdProd") Then
                                Detalhamento.infAdProd = InnerNode3.InnerText
                            End If

                            If (InnerNode3.Name = "imposto") Then

                                If Not InnerNode3("vTotTrib") Is Nothing Then
                                    Detalhamento.Imposto.vTotTrib = InnerNode3("vTotTrib").InnerText.Replace(".", ",")
                                End If

                                For Each InnerNode4 As XmlNode In InnerNode3.ChildNodes

                                    If InnerNode4.Name = "ICMS" Then

                                        Select Case InnerNode4.ChildNodes(0).Name

                                            Case Is = "ICMS40"
                                                Detalhamento.Imposto.Icms = New ICMS()
                                                Detalhamento.Imposto.Icms.Icms40 = New ICMS40()
                                                Detalhamento.Imposto.Icms.Icms40.orig = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText
                                                Detalhamento.Imposto.Icms.Icms40.CST = InnerNode4.ChildNodes(0).ChildNodes(1).InnerText

                                            Case Is = "ICMS60"
                                                Detalhamento.Imposto.Icms = New ICMS()
                                                Detalhamento.Imposto.Icms.Icms60 = New ICMS60()
                                                Detalhamento.Imposto.Icms.Icms60.orig = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText
                                                Detalhamento.Imposto.Icms.Icms60.CST = InnerNode4.ChildNodes(0).ChildNodes(1).InnerText

                                                If Not InnerNode4("ICMS60")("vBCSTRet") Is Nothing Then
                                                    Detalhamento.Imposto.Icms.Icms60.vBCSTRet = InnerNode4("ICMS60")("vBCSTRet").InnerText
                                                End If

                                                If Not InnerNode4("ICMS60")("vICMSSTRet") Is Nothing Then
                                                    Detalhamento.Imposto.Icms.Icms60.vICMSSTRet = InnerNode4("ICMS60")("vICMSSTRet").InnerText
                                                End If

                                            Case Is = "ICMS00"
                                                Detalhamento.Imposto.Icms = New ICMS()
                                                Detalhamento.Imposto.Icms.Icms00 = New ICMS00()
                                                Detalhamento.Imposto.Icms.Icms00.orig = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText
                                                Detalhamento.Imposto.Icms.Icms00.CST = InnerNode4.ChildNodes(0).ChildNodes(1).InnerText
                                                Detalhamento.Imposto.Icms.Icms00.modBC = InnerNode4.ChildNodes(0).ChildNodes(2).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms00.vBC = InnerNode4.ChildNodes(0).ChildNodes(3).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms00.pICMS = InnerNode4.ChildNodes(0).ChildNodes(4).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms00.vICMS = InnerNode4.ChildNodes(0).ChildNodes(5).InnerText.Replace(".", ",")

                                            Case Is = "ICMS20"
                                                Detalhamento.Imposto.Icms = New ICMS()
                                                Detalhamento.Imposto.Icms.Icms20 = New ICMS20()
                                                Detalhamento.Imposto.Icms.Icms20.orig = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText
                                                Detalhamento.Imposto.Icms.Icms20.CST = InnerNode4.ChildNodes(0).ChildNodes(1).InnerText
                                                Detalhamento.Imposto.Icms.Icms20.modBC = InnerNode4.ChildNodes(0).ChildNodes(2).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms20.pRedBC = InnerNode4.ChildNodes(0).ChildNodes(3).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms20.vBC = InnerNode4.ChildNodes(0).ChildNodes(4).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms20.pICMS = InnerNode4.ChildNodes(0).ChildNodes(5).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms20.vICMS = InnerNode4.ChildNodes(0).ChildNodes(6).InnerText.Replace(".", ",")

                                            Case Is = "ICMS10"
                                                Detalhamento.Imposto.Icms = New ICMS()
                                                Detalhamento.Imposto.Icms.Icms10 = New ICMS10()
                                                Detalhamento.Imposto.Icms.Icms10.orig = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText
                                                Detalhamento.Imposto.Icms.Icms10.CST = InnerNode4.ChildNodes(0).ChildNodes(1).InnerText
                                                Detalhamento.Imposto.Icms.Icms10.modBC = InnerNode4.ChildNodes(0).ChildNodes(2).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms10.vBC = InnerNode4.ChildNodes(0).ChildNodes(3).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms10.pICMS = InnerNode4.ChildNodes(0).ChildNodes(4).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms10.vICMS = InnerNode4.ChildNodes(0).ChildNodes(5).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms10.modBCST = InnerNode4.ChildNodes(0).ChildNodes(6).InnerText.Replace(".", ",")

                                                If Not InnerNode4("ICMS10")("pMVAST") Is Nothing Then
                                                    Detalhamento.Imposto.Icms.Icms10.pMVAST = InnerNode4("ICMS10")("pMVAST").InnerText.Replace(".", ",")
                                                End If

                                                Detalhamento.Imposto.Icms.Icms10.vBCST = InnerNode4("ICMS10")("vBCST").InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms10.pICMSST = InnerNode4("ICMS10")("pICMSST").InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms10.vICMSST = InnerNode4("ICMS10")("vICMSST").InnerText.Replace(".", ",")

                                            Case Is = "ICMS70"

                                                Detalhamento.Imposto.Icms = New ICMS()
                                                Detalhamento.Imposto.Icms.Icms70 = New ICMS70()
                                                Detalhamento.Imposto.Icms.Icms70.orig = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText
                                                Detalhamento.Imposto.Icms.Icms70.CST = InnerNode4.ChildNodes(0).ChildNodes(1).InnerText
                                                Detalhamento.Imposto.Icms.Icms70.modBC = InnerNode4.ChildNodes(0).ChildNodes(2).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms70.pRedBC = InnerNode4.ChildNodes(0).ChildNodes(3).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms70.vBC = InnerNode4.ChildNodes(0).ChildNodes(4).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms70.pICMS = InnerNode4.ChildNodes(0).ChildNodes(5).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms70.vICMS = InnerNode4.ChildNodes(0).ChildNodes(6).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms70.modBCST = InnerNode4.ChildNodes(0).ChildNodes(7).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms70.pRedBCST = InnerNode4.ChildNodes(0).ChildNodes(8).InnerText.Replace(".", ",")
                                                If Not InnerNode4("ICMS70")("pMVAST") Is Nothing Then
                                                    Detalhamento.Imposto.Icms.Icms70.pMVAST = InnerNode4("ICMS70")("pMVAST").InnerText.Replace(".", ",")
                                                End If
                                                Detalhamento.Imposto.Icms.Icms70.vBCST = InnerNode4("ICMS70")("vBCST").InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms70.pICMSST = InnerNode4("ICMS70")("pICMSST").InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms70.vICMSST = InnerNode4("ICMS70")("vICMSST").InnerText.Replace(".", ",")

                                            Case Is = "ICMSSN101"
                                                Detalhamento.Imposto.Icms = New ICMS()
                                                Detalhamento.Imposto.Icms.ICMSSN101 = New ICMSSN101()
                                                Detalhamento.Imposto.Icms.ICMSSN101.orig = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText
                                                Detalhamento.Imposto.Icms.ICMSSN101.CSOSN = InnerNode4.ChildNodes(0).ChildNodes(1).InnerText
                                                Detalhamento.Imposto.Icms.ICMSSN101.pCredSN = InnerNode4.ChildNodes(0).ChildNodes(2).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN101.vCredICMSSN = InnerNode4.ChildNodes(0).ChildNodes(3).InnerText.Replace(".", ",")

                                            Case Is = "ICMSSN102"
                                                Detalhamento.Imposto.Icms = New ICMS()
                                                Detalhamento.Imposto.Icms.ICMSSN102 = New ICMSSN102()
                                                Detalhamento.Imposto.Icms.ICMSSN102.orig = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText
                                                Detalhamento.Imposto.Icms.ICMSSN102.CSOSN = InnerNode4.ChildNodes(0).ChildNodes(1).InnerText

                                            Case Is = "ICMSSN201"
                                                Detalhamento.Imposto.Icms = New ICMS()
                                                Detalhamento.Imposto.Icms.ICMSSN201 = New ICMSSN201()
                                                Detalhamento.Imposto.Icms.ICMSSN201.orig = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText
                                                Detalhamento.Imposto.Icms.ICMSSN201.CSOSN = InnerNode4.ChildNodes(0).ChildNodes(1).InnerText
                                                Detalhamento.Imposto.Icms.ICMSSN201.modBCST = InnerNode4.ChildNodes(0).ChildNodes(2).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN201.pMVAST = InnerNode4.ChildNodes(0).ChildNodes(3).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN201.pRedBCST = InnerNode4.ChildNodes(0).ChildNodes(4).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN201.vBCST = InnerNode4.ChildNodes(0).ChildNodes(5).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN201.pICMSST = InnerNode4.ChildNodes(0).ChildNodes(6).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN201.vICMSST = InnerNode4.ChildNodes(0).ChildNodes(7).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN201.pCredSN = InnerNode4.ChildNodes(0).ChildNodes(8).InnerText.Replace(".", ",")
                                                '   Detalhamento.Imposto.Icms.ICMSSN201.vCredICMSSN = InnerNode4.ChildNodes(0).ChildNodes(9).InnerText.Replace(".", ",")

                                            Case Is = "ICMSSN202"
                                                Detalhamento.Imposto.Icms = New ICMS()
                                                Detalhamento.Imposto.Icms.ICMSSN202 = New ICMSSN202()
                                                Detalhamento.Imposto.Icms.ICMSSN202.orig = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText
                                                Detalhamento.Imposto.Icms.ICMSSN202.CSOSN = InnerNode4.ChildNodes(0).ChildNodes(1).InnerText
                                                Detalhamento.Imposto.Icms.ICMSSN202.modBCST = InnerNode4.ChildNodes(0).ChildNodes(2).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN202.pMVAST = InnerNode4.ChildNodes(0).ChildNodes(3).InnerText.Replace(".", ",")

                                                If Not InnerNode4("ICMSSN202")("pMVAST") Is Nothing Then
                                                    Detalhamento.Imposto.Icms.ICMSSN202.pMVAST = InnerNode4("ICMSSN202")("pMVAST").InnerText.Replace(".", ",")
                                                End If
                                                If Not InnerNode4("ICMSSN202")("pRedBCST") Is Nothing Then
                                                    Detalhamento.Imposto.Icms.ICMSSN202.pRedBCST = InnerNode4("ICMSSN202")("pRedBCST").InnerText.Replace(".", ",")
                                                End If

                                                Detalhamento.Imposto.Icms.ICMSSN202.vBCST = InnerNode4("ICMSSN202")("vBCST").InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN202.pICMSST = InnerNode4("ICMSSN202")("pICMSST").InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN202.vICMSST = InnerNode4("ICMSSN202")("vICMSST").InnerText.Replace(".", ",")


                                            Case Is = "ICMSSN500"
                                                Detalhamento.Imposto.Icms = New ICMS()
                                                Detalhamento.Imposto.Icms.ICMSSN500 = New ICMSSN500()
                                                Detalhamento.Imposto.Icms.ICMSSN500.orig = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText
                                                Detalhamento.Imposto.Icms.ICMSSN500.CSOSN = InnerNode4.ChildNodes(0).ChildNodes(1).InnerText

                                                If Not InnerNode4("ICMSSN500")("vBCSTRet") Is Nothing Then
                                                    Detalhamento.Imposto.Icms.ICMSSN500.vBCSTRet = InnerNode4("ICMSSN500")("vBCSTRet").InnerText.Replace(".", ",")
                                                End If
                                                If Not InnerNode4("ICMSSN500")("vICMSSTRet") Is Nothing Then
                                                    Detalhamento.Imposto.Icms.ICMSSN500.vICMSSTRet = InnerNode4("ICMSSN500")("vICMSSTRet").InnerText.Replace(".", ",")
                                                End If


                                            Case Is = "ICMSSN900"
                                                Detalhamento.Imposto.Icms = New ICMS()
                                                Detalhamento.Imposto.Icms.ICMSSN900 = New ICMSSN900()
                                                Detalhamento.Imposto.Icms.ICMSSN900.orig = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText
                                                Detalhamento.Imposto.Icms.ICMSSN900.CSOSN = InnerNode4.ChildNodes(0).ChildNodes(1).InnerText
                                                Detalhamento.Imposto.Icms.ICMSSN900.modBC = InnerNode4.ChildNodes(0).ChildNodes(2).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN900.vBC = InnerNode4.ChildNodes(0).ChildNodes(3).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN900.pRedBC = InnerNode4.ChildNodes(0).ChildNodes(4).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN900.pICMS = InnerNode4.ChildNodes(0).ChildNodes(5).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN900.vICMS = InnerNode4.ChildNodes(0).ChildNodes(6).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN900.modBCST = InnerNode4.ChildNodes(0).ChildNodes(7).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN900.pMVAST = InnerNode4.ChildNodes(0).ChildNodes(8).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN900.pRedBCST = InnerNode4.ChildNodes(0).ChildNodes(9).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN900.vBCST = InnerNode4.ChildNodes(0).ChildNodes(10).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN900.pICMSST = InnerNode4.ChildNodes(0).ChildNodes(11).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN900.vICMSST = InnerNode4.ChildNodes(0).ChildNodes(12).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN900.pCredSN = InnerNode4.ChildNodes(0).ChildNodes(13).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.ICMSSN900.vCredICMSSN = InnerNode4.ChildNodes(0).ChildNodes(14).InnerText.Replace(".", ",")

                                        End Select



                                    End If

                                    If InnerNode4.Name = "IPI" Then

                                        If Not InnerNode4("IPITrib") Is Nothing Then

                                            Select Case InnerNode4("IPITrib").Name

                                                Case Is = "IPITrib"
                                                    Detalhamento.Imposto.Ipi = New IPI
                                                    Detalhamento.Imposto.Ipi.IpiTrib = New IPITrib()

                                                    Detalhamento.Imposto.Ipi.IpiTrib.CST = InnerNode4("IPITrib")("CST").InnerText.Replace(".", ",")

                                                    If Not InnerNode4("IPITrib")("vBC") Is Nothing Then
                                                        Detalhamento.Imposto.Ipi.IpiTrib.vBC = InnerNode4("IPITrib")("vBC").InnerText.Replace(".", ",")
                                                    End If
                                                    If Not InnerNode4("IPITrib")("pIPI") Is Nothing Then
                                                        Detalhamento.Imposto.Ipi.IpiTrib.pIPI = InnerNode4("IPITrib")("pIPI").InnerText.Replace(".", ",")
                                                    End If
                                                    If Not InnerNode4("IPITrib")("vIPI") Is Nothing Then
                                                        Detalhamento.Imposto.Ipi.IpiTrib.vIPI = InnerNode4("IPITrib")("vIPI").InnerText.Replace(".", ",")
                                                    End If

                                            End Select
                                        End If


                                    End If

                                    If InnerNode4.Name = "PIS" Then
                                        Select Case InnerNode4.ChildNodes(0).Name
                                            Case Is = "PISAliq"
                                                Detalhamento.Imposto.Pis = New PIS()
                                                Detalhamento.Imposto.Pis.PisAliq = New PISAliq()
                                                Detalhamento.Imposto.Pis.PisAliq.CST = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Pis.PisAliq.vBC = InnerNode4.ChildNodes(0).ChildNodes(1).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Pis.PisAliq.pPIS = InnerNode4.ChildNodes(0).ChildNodes(2).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Pis.PisAliq.vPIS = InnerNode4.ChildNodes(0).ChildNodes(3).InnerText.Replace(".", ",")
                                            Case Is = "PISNT"
                                                Detalhamento.Imposto.Pis = New PIS()
                                                Detalhamento.Imposto.Pis.PisNT = New PISNT()
                                                Detalhamento.Imposto.Pis.PisNT.CST = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText
                                        End Select
                                    End If

                                    If InnerNode4.Name = "COFINS" Then
                                        Select Case InnerNode4.ChildNodes(0).Name
                                            Case Is = "COFINSAliq"
                                                Detalhamento.Imposto.Cofins = New COFINS()
                                                Detalhamento.Imposto.Cofins.CofinsAliq = New COFINSAliq()
                                                Detalhamento.Imposto.Cofins.CofinsAliq.CST = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Cofins.CofinsAliq.vBC = InnerNode4.ChildNodes(0).ChildNodes(1).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Cofins.CofinsAliq.pCOFINS = InnerNode4.ChildNodes(0).ChildNodes(2).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Cofins.CofinsAliq.vCOFINS = InnerNode4.ChildNodes(0).ChildNodes(3).InnerText.Replace(".", ",")
                                            Case Is = "COFINSNT"
                                                Detalhamento.Imposto.Cofins = New COFINS()
                                                Detalhamento.Imposto.Cofins.CofinsNT = New COFINSNT()
                                                Detalhamento.Imposto.Cofins.CofinsNT.CST = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText
                                        End Select
                                    End If
                                Next
                            End If
                        Next

                        NotaLida.infNFE.Det.Add(Detalhamento)

                    ElseIf (InnerNode2.Name = "total") Then


                        NotaLida.infNFE.Total = New total()
                        NotaLida.infNFE.Total.IcmsTot = New ICMSTot()
                        NotaLida.infNFE.Total.IcmsTot.vBC = InnerNode2("ICMSTot")("vBC").InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vICMS = InnerNode2("ICMSTot")("vICMS").InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vBCST = InnerNode2("ICMSTot")("vBCST").InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vST = InnerNode2("ICMSTot")("vST").InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vProd = InnerNode2("ICMSTot")("vProd").InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vFrete = InnerNode2("ICMSTot")("vFrete").InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vSeg = InnerNode2("ICMSTot")("vSeg").InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vDesc = InnerNode2("ICMSTot")("vDesc").InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vII = InnerNode2("ICMSTot")("vII").InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vIPI = InnerNode2("ICMSTot")("vIPI").InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vPIS = InnerNode2("ICMSTot")("vPIS").InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vCOFINS = InnerNode2("ICMSTot")("vCOFINS").InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vOutro = InnerNode2("ICMSTot")("vOutro").InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vNF = InnerNode2("ICMSTot")("vNF").InnerText.Replace(".", ",")

                        If Not InnerNode2("ICMSTot")("vTotTrib") Is Nothing Then
                            NotaLida.infNFE.Total.IcmsTot.vTotTrib = InnerNode2("ICMSTot")("vTotTrib").InnerText.Replace(".", ",")
                        End If

                    ElseIf (InnerNode2.Name = "transp") Then

                        NotaLida.infNFE.Transp = New transp()
                        NotaLida.infNFE.Transp.modFrete = InnerNode2.ChildNodes(0).InnerText
                        NotaLida.infNFE.Transp.Transporta = New transporta
                        NotaLida.infNFE.veic = New Veiculo
                        NotaLida.infNFE.Transp.Vol = New vol

                        If Not InnerNode2.ChildNodes(1) Is Nothing Then

                            For Each InnerNode3 As XmlNode In InnerNode2.ChildNodes
                                If (InnerNode3.Name = "transporta") Then
                                    If Not InnerNode3("CNPJ") Is Nothing Then
                                        NotaLida.infNFE.Transp.Transporta.CNPJ = InnerNode3("CNPJ").InnerText
                                    End If
                                    If Not InnerNode3("CPF") Is Nothing Then
                                        NotaLida.infNFE.Transp.Transporta.CNPJ = InnerNode3("CPF").InnerText
                                    End If
                                    If Not InnerNode3("xNome") Is Nothing Then
                                        NotaLida.infNFE.Transp.Transporta.xNome = InnerNode3("xNome").InnerText
                                    End If
                                    If Not InnerNode3("UF") Is Nothing Then
                                        NotaLida.infNFE.Transp.Transporta.UF = InnerNode3("UF").InnerText
                                    End If
                                    If Not InnerNode3("xEnder") Is Nothing Then
                                        NotaLida.infNFE.Transp.Transporta.xEnder = InnerNode3("xEnder").InnerText
                                    End If
                                    If Not InnerNode3("xMun") Is Nothing Then
                                        NotaLida.infNFE.Transp.Transporta.xMun = InnerNode3("xMun").InnerText
                                    End If
                                    If Not InnerNode3("IE") Is Nothing Then
                                        NotaLida.infNFE.Transp.Transporta.IE = InnerNode3("IE").InnerText
                                    End If

                                End If
                                If (InnerNode3.Name = "veicTransp") Then

                                    If Not InnerNode3("placa") Is Nothing Then
                                        'NotaLida.infNFE.Transp.VeicTransp.placa = InnerNode3("placa").InnerText
                                    End If
                                    If Not InnerNode3("UF") Is Nothing Then
                                        '  NotaLida.infNFE.Transp.VeicTransp.UF = InnerNode3("UF").InnerText
                                    End If
                                    If Not InnerNode3("RNTC") Is Nothing Then
                                        '  NotaLida.infNFE.Transp.VeicTransp.RNTC = InnerNode3("RNTC").InnerText
                                    End If
                                End If
                                If (InnerNode3.Name = "vol") Then

                                    If Not InnerNode3("qVol") Is Nothing Then
                                        NotaLida.infNFE.Transp.Vol.qVol = InnerNode3("qVol").InnerText
                                    End If
                                    If Not InnerNode3("marca") Is Nothing Then
                                        NotaLida.infNFE.Transp.Vol.marca = InnerNode3("marca").InnerText
                                    End If
                                    If Not InnerNode3("esp") Is Nothing Then
                                        NotaLida.infNFE.Transp.Vol.esp = InnerNode3("esp").InnerText
                                    End If
                                    If Not InnerNode3("nVol") Is Nothing Then
                                        NotaLida.infNFE.Transp.Vol.nVol = InnerNode3("nVol").InnerText
                                    End If
                                    If Not InnerNode3("pesoL") Is Nothing Then
                                        NotaLida.infNFE.Transp.Vol.pesoL = InnerNode3("pesoL").InnerText
                                    End If
                                    If Not InnerNode3("pesoB") Is Nothing Then
                                        NotaLida.infNFE.Transp.Vol.pesoB = InnerNode3("pesoB").InnerText
                                    End If
                                End If
                            Next
                        End If

                    ElseIf (InnerNode2.Name = "cobr") Then

                        Dim cobranca As New cobr()
                        For Each InnerNode3 As XmlNode In InnerNode2.ChildNodes
                            If (InnerNode3.Name = "dup") Then
                                Dim DUPLICATA As New dup

                                DUPLICATA.nDup = InnerNode3.ChildNodes(0).InnerText
                                DUPLICATA.dVenc = InnerNode3.ChildNodes(1).InnerText
                                DUPLICATA.vDup = InnerNode3.ChildNodes(2).InnerText.Replace(".", ",")

                                cobranca.Dup.Add(DUPLICATA)
                            End If
                        Next
                        NotaLida.infNFE.Cobr = cobranca


                    ElseIf (InnerNode2.Name = "infAdic") Then

                        Dim InfAd As New infAdic

                        If Not InnerNode2.ChildNodes(0) Is Nothing Then

                            If Not InnerNode2("infCpl") Is Nothing Then
                                InfAd.infCpl = InnerNode2("infCpl").InnerText
                            End If

                            If Not InnerNode2("infAdFisco") Is Nothing Then
                                InfAd.infAdFisco = InnerNode2("infAdFisco").InnerText
                            End If

                            NotaLida.infNFE.InfAdic = InfAd
                        Else
                            InfAd.infCpl = ""
                            NotaLida.infNFE.InfAdic = InfAd
                        End If
                    End If

                Next
            End If
        Next

        Dim VNotaE As New NotaEletronica

        VNotaE.NotaEletronica = NotaLida
        VNotaE.ProtocoloAutorizacao = ""

        Return VNotaE

    End Function
End Class
