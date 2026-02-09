Imports System.Security.Cryptography
Imports System.Security.Permissions
Imports System.IO
Imports System.Threading
Imports System.Web.Services.Protocols
Imports System.Security.Cryptography.X509Certificates
Imports System.Xml
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks
Imports System.Net.Security
Imports System.Security.Authentication
Imports Org.BouncyCastle.Crypto.Agreement

Public Class C_WebService

    'VARIAVEL COM AS INFORMACOES DA NFE PARA USAR NA CONSULTA RETORNO
    Public Structure RetRecibo
        Dim Id As String
        Dim tpAmb As String
        Dim verAplic As String
        Dim chNFe As String
        Dim dhRecbto As Date
        Dim dhRecbtoori As String
        Dim digVal As String
        Dim cStat As String
        Dim cStat1 As String
        Dim xMotivo As String
        Dim xMotivo1 As String
        Dim nProt As String
        Dim nProtc As String
        Dim Xmlcanc As String
        Dim XmlRecibo As String
        Dim xEvento As String
        Dim tpnf As String
        Dim xMotivoent As String

        Dim xNome As String
        Dim CPF As String
        Dim CNPJemi As String
        Dim IE As String
        Dim dEmi As Date
        Dim vNF As String
        Dim cSitNFe As String
        Dim cSitConf As String
        Dim minifesta As String
        Dim NSU As String

    End Structure

    Public Structure RetEnvio
        Dim verAplic As String
        Dim cStat As String
        Dim xMotivo As String
        Dim cUF As String
        Dim nRec As String
        Dim dhRecbto As String
        Dim tMed As String
    End Structure
    Public Structure Retcad

        Dim xdhCons As String
        Dim indCredNFe As String
        Dim xmotivo As String
        Dim xnomefan As String
        Dim xnome As String
        Dim xcnpj As String
        Dim xie As String
        Dim xcSit As String
        Dim xuf As String
        Dim xRegApur As String
        Dim xdIniAtiv As String
        Dim xdbaixa As String
        Dim dUltSit As String

        Dim xend As String
        Dim xbairro As String
        Dim xcep As String
        Dim xmun As String
        Dim xcmun As String
        Dim xnro As String
        Dim cStat As String

    End Structure

    'VARIAVEL QUE VAI RECEBER O RETORNO DA CONSULTA DE ENVIO
    Public Structure RetRetorno
        Dim xmlret As String
        Dim idLote As String
        Dim statuslote As String
        Dim codstatuslote As String
        Dim retdown As String

        Dim ultNSU As String
        Dim maxNSU As String
        Dim indCont As String
        Dim id As String
        Dim tpAmb As String
        Dim verAplic As String
        Dim cStat As String
        Dim cStatdown As String
        Dim xMotivo As String
        Dim xMotivoret As String
        Dim cUF As String
        Dim nRec As String
        Dim dhRecbto As Date
        Dim chNFe As String
        Dim nProt As String
        Dim digVal As String
        Dim tMed As String
        Dim L_Retornos As List(Of RetRecibo) 'LISTA DE NOTAS PARA QUANDO MAIS DE UMA NOTA FOI ENVIADA NO LOTE
    End Structure

    Public Structure ListaUrl
        Dim UrlnfeConsultaNFDest As String
        Dim UrlRecepcaoEvento As String
        Dim UrlNFeAutorizacao As String
        Dim UrlNFeRetAutorizacao As String
        Dim UrlNfeInutilizacao As String
        Dim UrlNfeConsultaCadastro As String
        Dim UrlNfeConsultaProtocolo As String
        Dim UrlNfeStatusServico As String
        Dim UrlDFe As String
        Dim UrlDownload As String
        Dim CodigoUF As String
    End Structure

    Private S_Url As ListaUrl

    Public Function url_webservice(ByVal ListadeUrl As ListaUrl)
        S_Url = ListadeUrl
    End Function

    Public Function NfeStatusServico4(ByVal UF As String, url As String) As RetRetorno
        Dim strRetorno As XmlElement
        Dim xmldoc = New XmlDocument()

        'BUSCA CERTIFICADO SE DEIXAR EM BRANCO ABRE JANELA DE SELEÇÃO DO WINDOWS

        Try
            Dim wsMsg As NfeStatusServico4
            Dim cab As New nfeCabecMsg

            'CRIA UMA INSTANCIA DA CONEXÃO COM O WEBSERVICE
            wsMsg = New NfeStatusServico4(url)

            'DEFINE TEMPO MAXIMO DE ESPERA POR RETORNO
            wsMsg.Timeout = 100000

            'ASSOCIA CERTIFICADO A CONEXAO WEBSERVICE
            wsMsg.ClientCertificates.Add(certificado)

            'DEFINE PROTOCOLO USADO NA CONEXÃO
            wsMsg.SoapVersion = SoapProtocolVersion.Soap12

            xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><consStatServ versao=""4.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>1</tpAmb><cUF>" & UF & "</cUF><xServ>STATUS</xServ></consStatServ>")

            strRetorno = wsMsg.nfeStatusServicoNF(xmldoc)


            Dim Retornos As New RetRetorno

            For Each outerNode As XmlNode In strRetorno
                'PARA CADA NO VERIFICA SE O MESMO POSSUI FILHOS E VARRE OS MESMOS
                If (outerNode.Name = "tpAmb") Then
                    Retornos.tpAmb = outerNode.InnerText
                End If
                If (outerNode.Name = "verAplic") Then
                    Retornos.verAplic = outerNode.InnerText
                End If
                If (outerNode.Name = "cStat") Then
                    Retornos.cStat = outerNode.InnerText
                End If
                If (outerNode.Name = "xMotivo") Then
                    Retornos.xMotivo = outerNode.InnerText
                End If
                If (outerNode.Name = "cUF") Then
                    Retornos.cUF = outerNode.InnerText
                End If
                If (outerNode.Name = "tMed") Then
                    Retornos.tMed = outerNode.InnerText
                End If
            Next

            Return Retornos
        Catch ex As Exception
            MsgBox("Ocorreu um erro ao receber retorno: " & ex.Message, MsgBoxStyle.Information, "Retorno do Sefaz:")
            Return Nothing
        End Try
    End Function
    Public Function ConsultaStatusNfe2(ByVal IDNfe As String, ambiente As String) As RetRetorno
        Dim strRetorno As XmlElement

        Dim xmldoc = New XmlDocument()

        'BUSCA CERTIFICADO SE DEIXAR EM BRANCO ABRE JANELA DE SELEÇÃO DO WINDOWS

        Try
            Dim wsMsg As NfeConsulta2
            Dim cab As New nfeCabecMsg

            'UF E VERSÃO DO CABEÇALHO
            cab.cUF = S_Url.CodigoUF
            cab.versaoDados = "3.10"

            'CRIA UMA INSTANCIA DA CONEXÃO COM O WEBSERVICE
            wsMsg = New NfeConsulta2(S_Url.UrlNfeConsultaProtocolo)

            'ASSOCIA CABEÇALHO NFE
            wsMsg.nfeCabecMsgValue = cab

            'DEFINE TEMPO MAXIMO DE ESPERA POR RETORNO
            wsMsg.Timeout = 100000

            'ASSOCIA CERTIFICADO A CONEXAO WEBSERVICE
            wsMsg.ClientCertificates.Add(certificado)

            'DEFINE PROTOCOLO USADO NA CONEXÃO
            wsMsg.SoapVersion = SoapProtocolVersion.Soap12


            xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><consSitNFe versao=""3.10"" xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>" & ambiente & "</tpAmb><xServ>CONSULTAR</xServ><chNFe>" & IDNfe & "</chNFe></consSitNFe>")


            ''''CHAMA O WEBSERVICE DA RECEITA
            strRetorno = wsMsg.nfeConsultaNF2(xmldoc)


            ''''''''''''''Rotina para salvar retor em xml''''''''''''''''''''''''''''
            xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & strRetorno.OuterXml & "")

            xmldoc.Save(Application.StartupPath & "\xml\Retorno_consultaNFe.xml")
            ''''''''''------------------------------------------------------------'''

            'VARIAVER QUE VAI RECEBER O RETORNO
            Dim Retornos As New RetRetorno

            Retornos.L_Retornos = New List(Of RetRecibo)

            Dim VarRecibo As New RetRecibo

            'PERCORRE TODOS OS NOS DO XML E PROCURA A TAG DE RETORNO infProt
            For Each outerNode As XmlNode In strRetorno
                If outerNode.OuterXml.Length > 13 Then
                    If outerNode.OuterXml.Substring(0, 14) = "<procEventoNFe" Then
                        Retornos.xmlret = outerNode.OuterXml
                    End If
                End If
                'PARA CADA NO VERIFICA SE O MESMO POSSUI FILHOS E VARRE OS MESMOS
                If (outerNode.Name = "tpAmb") Then
                    Retornos.tpAmb = outerNode.InnerText
                End If
                If (outerNode.Name = "verAplic") Then
                    Retornos.verAplic = outerNode.InnerText
                End If
                If (outerNode.Name = "nRec") Then
                    Retornos.nRec = outerNode.InnerText
                End If
                If (outerNode.Name = "cStat") Then
                    Retornos.cStat = outerNode.InnerText
                End If
                If (outerNode.Name = "xMotivo") Then
                    Retornos.xMotivo = outerNode.InnerText
                End If
                If (outerNode.Name = "cUF") Then
                    Retornos.cUF = outerNode.InnerText
                End If
                If (outerNode.Name = "chNFe") Then
                    Retornos.chNFe = outerNode.InnerText
                End If

                For Each InnerNode As XmlNode In outerNode.ChildNodes
                    VarRecibo.XmlRecibo = InnerNode.OuterXml
                    If Retornos.cStat = "101" Then

                        If InnerNode.Name = "retEvento" Then

                            For Each InnerNode2 As XmlNode In InnerNode.ChildNodes

                                If InnerNode2.Name = "infEvento" Then
                                    For Each InnerNode3 As XmlNode In InnerNode2.ChildNodes

                                        If (InnerNode3.Name = "dhRegEvento") Then
                                            VarRecibo.dhRecbto = InnerNode3.InnerText
                                            VarRecibo.dhRecbtoori = InnerNode3.InnerText
                                        End If

                                        If (InnerNode3.Name = "nProt") Then
                                            ' frmxml.txtprotocolocanc.Text = InnerNode3.InnerText + "    " + VarRecibo.dhRecbto
                                        End If

                                        If (InnerNode3.Name = "xEvento") Then
                                            VarRecibo.xEvento = InnerNode3.InnerText
                                        End If

                                        If (InnerNode3.Name = "xMotivo") Then
                                            VarRecibo.xMotivoent = InnerNode3.InnerText
                                        End If

                                    Next
                                End If

                            Next
                        End If

                    End If

                    If Retornos.cStat = "100" Then
                        If InnerNode.Name = "infProt" Then
                            'PERCORRE CAMPOS DO RETORNO PARA CAPTURAR AS INFORMAÇÕES
                            For Each InnerNode2 As XmlNode In InnerNode.ChildNodes
                                If (InnerNode2.Name = "tpAmb") Then
                                    VarRecibo.tpAmb = InnerNode2.InnerText
                                End If
                                If (InnerNode2.Name = "verAplic") Then
                                    VarRecibo.verAplic = InnerNode2.InnerText
                                End If
                                If (InnerNode2.Name = "chNFe") Then
                                    VarRecibo.chNFe = InnerNode2.InnerText
                                End If
                                If (InnerNode2.Name = "dhRecbto") Then
                                    VarRecibo.dhRecbto = InnerNode2.InnerText
                                    VarRecibo.dhRecbtoori = InnerNode2.InnerText
                                End If
                                If (InnerNode2.Name = "digVal") Then
                                    VarRecibo.digVal = InnerNode2.InnerText
                                End If
                                If (InnerNode2.Name = "cStat") Then
                                    VarRecibo.cStat = InnerNode2.InnerText
                                End If
                                If (InnerNode2.Name = "nProt") Then
                                    VarRecibo.nProt = InnerNode2.InnerText
                                End If
                                If (InnerNode2.Name = "xMotivo") Then
                                    VarRecibo.xMotivo = InnerNode2.InnerText
                                End If
                            Next
                            'ADICIONA A NOTA NA LISTA DE RETORNO
                            Retornos.L_Retornos.Add(VarRecibo)
                        End If
                    End If
                Next
            Next

            Return Retornos

        Catch ex As Exception
            MsgBox("Ocorreu um erro ao receber retorno: " & ex.Message, MsgBoxStyle.Information, "Retorno do Sefaz:")
            Return Nothing
        End Try

    End Function


    Public Function ConsultaStatusNfe(ByVal IDNfe As String, ambiente As String, Optional ByVal host As Boolean = False)
        Dim strRetorno As XmlNode
        Dim retConsReciNFe As retConsSitNFe
        Dim xmldoc = New XmlDocument
        Dim url As String

        'BUSCA CERTIFICADO SE DEIXAR EM BRANCO ABRE JANELA DE SELEÇÃO DO WINDOWS

        ' Try
        Dim wsMsg As NfeConsulta4

        url = carrega_url("NFeConsultaProtocolo4", IDNfe.Substring(0, 2), IDNfe.Substring(20, 2), IDNfe.Substring(34, 1), "4.00", ambiente)

        'CRIA UMA INSTANCIA DA CONEXÃO COM O WEBSERVICE
        wsMsg = New NfeConsulta4(url)

        'DEFINE TEMPO MAXIMO DE ESPERA POR RETORNO
        wsMsg.Timeout = 100000

        'ASSOCIA CERTIFICADO A CONEXAO WEBSERVICE
        wsMsg.ClientCertificates.Add(certificado)

        'DEFINE PROTOCOLO USADO NA CONEXÃO
        wsMsg.SoapVersion = SoapProtocolVersion.Soap12


        xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><consSitNFe versao=""4.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>" & ambiente & "</tpAmb><xServ>CONSULTAR</xServ><chNFe>" & IDNfe & "</chNFe></consSitNFe>")
        reterro = ""

        ''''CHAMA O WEBSERVICE DA RECEITA
        strRetorno = wsMsg.nfeConsultaNF(xmldoc)



        If host = False Then
            If strRetorno.InnerText <> "" Then


                Dim ret As String = strRetorno.OuterXml
                ret = ret.Replace("xmlns=""http://www.portalfiscal.inf.br/nfe""", "")
                ret = ret.Replace("versao=""4.00""", "")
                ret = ret.Replace("<retConsSitNFe ", "<retConsSitNFe xmlns=""http://www.portalfiscal.inf.br/nfe""")


                xmldoc.LoadXml(ret)
                xmldoc.Save(Application.StartupPath & "\xml\Retorno_EventoNFe.xml")
                retConsReciNFe = funcoesNfe.DeserializarNFe(Of retConsSitNFe)(ret)

                Dim xmllist As System.Xml.XmlNodeList
                xmllist = xmldoc.GetElementsByTagName("protNFe")
                For Each xmlnode In xmllist
                    retConsReciNFe.xmlprot = xmlnode.OuterXml
                Next

                xmllist = xmldoc.GetElementsByTagName("procEventoNFe")
                For Each xmlnode In xmllist
                    retConsReciNFe.xmlprocevent = xmlnode.OuterXml
                Next

                Return retConsReciNFe

                retConsReciNFe = funcoesNfe.DeserializarNFe(Of retConsSitNFe)(strRetorno.OuterXml)

                Return retConsReciNFe
            End If
        Else
            Return strRetorno.OuterXml
        End If

        '  Catch ex As Exception
        '   reterro = "Erro: Module C_WebService: " & ex.Message
        '    Return Nothing
        '   End Try

    End Function

    Public Function ConsultaStatusNfe4(ByVal IDNfe As String, ambiente As String) As RetRetorno
        Dim strRetorno As XmlElement

        Dim xmldoc = New XmlDocument()

        'BUSCA CERTIFICADO SE DEIXAR EM BRANCO ABRE JANELA DE SELEÇÃO DO WINDOWS

        Try
            Dim wsMsg As NfeConsulta4

            'CRIA UMA INSTANCIA DA CONEXÃO COM O WEBSERVICE
            wsMsg = New NfeConsulta4(S_Url.UrlNfeConsultaProtocolo)

            'DEFINE TEMPO MAXIMO DE ESPERA POR RETORNO
            wsMsg.Timeout = 100000

            'ASSOCIA CERTIFICADO A CONEXAO WEBSERVICE
            wsMsg.ClientCertificates.Add(certificado)

            'DEFINE PROTOCOLO USADO NA CONEXÃO
            wsMsg.SoapVersion = SoapProtocolVersion.Soap12


            xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><consSitNFe versao=""4.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>" & ambiente & "</tpAmb><xServ>CONSULTAR</xServ><chNFe>" & IDNfe & "</chNFe></consSitNFe>")


            ''''CHAMA O WEBSERVICE DA RECEITA
            strRetorno = wsMsg.nfeConsultaNF(xmldoc)


            ''''''''''''''Rotina para salvar retor em xml''''''''''''''''''''''''''''
            xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & strRetorno.OuterXml & "")

            xmldoc.Save(Application.StartupPath & "\xml\Retorno_consultaNFe.xml")
            ''''''''''------------------------------------------------------------'''

            'VARIAVER QUE VAI RECEBER O RETORNO
            Dim Retornos As New RetRetorno

            Retornos.L_Retornos = New List(Of RetRecibo)

            Dim VarRecibo As New RetRecibo

            'PERCORRE TODOS OS NOS DO XML E PROCURA A TAG DE RETORNO infProt
            For Each outerNode As XmlNode In strRetorno
                If outerNode.OuterXml.Length > 13 Then
                    If outerNode.OuterXml.Substring(0, 14) = "<procEventoNFe" Then
                        Retornos.xmlret = outerNode.OuterXml
                    End If
                End If
                'PARA CADA NO VERIFICA SE O MESMO POSSUI FILHOS E VARRE OS MESMOS
                If (outerNode.Name = "tpAmb") Then
                    Retornos.tpAmb = outerNode.InnerText
                End If
                If (outerNode.Name = "verAplic") Then
                    Retornos.verAplic = outerNode.InnerText
                End If
                If (outerNode.Name = "nRec") Then
                    Retornos.nRec = outerNode.InnerText
                End If
                If (outerNode.Name = "cStat") Then
                    Retornos.cStat = outerNode.InnerText
                End If
                If (outerNode.Name = "xMotivo") Then
                    Retornos.xMotivo = outerNode.InnerText
                End If
                If (outerNode.Name = "cUF") Then
                    Retornos.cUF = outerNode.InnerText
                End If
                If (outerNode.Name = "chNFe") Then
                    Retornos.chNFe = outerNode.InnerText
                End If

                For Each InnerNode As XmlNode In outerNode.ChildNodes
                    VarRecibo.XmlRecibo = InnerNode.OuterXml
                    If Retornos.cStat = "101" Then

                        If InnerNode.Name = "retEvento" Then

                            For Each InnerNode2 As XmlNode In InnerNode.ChildNodes

                                If InnerNode2.Name = "infEvento" Then
                                    For Each InnerNode3 As XmlNode In InnerNode2.ChildNodes

                                        If (InnerNode3.Name = "dhRegEvento") Then
                                            VarRecibo.dhRecbto = InnerNode3.InnerText
                                            VarRecibo.dhRecbtoori = InnerNode3.InnerText
                                        End If

                                        If (InnerNode3.Name = "nProt") Then
                                            VarRecibo.nProtc = InnerNode3.InnerText
                                        End If

                                        If (InnerNode3.Name = "xEvento") Then
                                            VarRecibo.xEvento = InnerNode3.InnerText
                                        End If

                                        If (InnerNode3.Name = "xMotivo") Then
                                            VarRecibo.xMotivo1 = InnerNode3.InnerText

                                        End If

                                    Next
                                    Retornos.L_Retornos.Add(VarRecibo)
                                End If

                            Next
                        End If

                    End If

                    If Retornos.cStat = "100" Then
                        If InnerNode.Name = "infProt" Then
                            'PERCORRE CAMPOS DO RETORNO PARA CAPTURAR AS INFORMAÇÕES
                            For Each InnerNode2 As XmlNode In InnerNode.ChildNodes
                                If (InnerNode2.Name = "tpAmb") Then
                                    VarRecibo.tpAmb = InnerNode2.InnerText
                                End If
                                If (InnerNode2.Name = "verAplic") Then
                                    VarRecibo.verAplic = InnerNode2.InnerText
                                End If
                                If (InnerNode2.Name = "chNFe") Then
                                    VarRecibo.chNFe = InnerNode2.InnerText
                                End If
                                If (InnerNode2.Name = "dhRecbto") Then
                                    VarRecibo.dhRecbto = InnerNode2.InnerText
                                End If
                                If (InnerNode2.Name = "digVal") Then
                                    VarRecibo.digVal = InnerNode2.InnerText
                                End If
                                If (InnerNode2.Name = "cStat") Then
                                    VarRecibo.cStat = InnerNode2.InnerText
                                End If
                                If (InnerNode2.Name = "nProt") Then
                                    VarRecibo.nProt = InnerNode2.InnerText
                                End If
                                If (InnerNode2.Name = "xMotivo") Then
                                    VarRecibo.xMotivo = InnerNode2.InnerText
                                End If
                            Next
                            'ADICIONA A NOTA NA LISTA DE RETORNO
                            Retornos.L_Retornos.Add(VarRecibo)
                        End If
                    End If
                Next
            Next

            Return Retornos

        Catch ex As Exception
            MsgBox("Ocorreu um erro ao receber retorno: " & ex.Message, MsgBoxStyle.Information, "Retorno do Sefaz:")
            Return Nothing
        End Try

    End Function

    Public Function nfeRecepcaoEvento4(ByVal EndArquivoXml As String) As RetRetorno
        Dim strRetorno As XmlElement
        Dim xmldoc = New XmlDocument()

        xmldoc.Load(EndArquivoXml) 'Carrega o arquivo XML 


        Try

            If S_Url.UrlRecepcaoEvento = "" Then

                S_Url.UrlRecepcaoEvento = "https://www.nfe.fazenda.gov.br/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx"

            End If



            Dim wsMsgrfb As NFeRecepcaoEvento4rfb
            Dim wsMsg As NFeRecepcaoEvento4

            'CABEÇALHO USADA PARA ENVIO DE LOTE
            wsMsg = New NFeRecepcaoEvento4(S_Url.UrlRecepcaoEvento)
            wsMsgrfb = New NFeRecepcaoEvento4rfb(S_Url.UrlRecepcaoEvento)

            wsMsgrfb.Timeout = 100000
            wsMsgrfb.ClientCertificates.Add(certificado)
            wsMsgrfb.SoapVersion = SoapProtocolVersion.Soap12

            wsMsg.Timeout = 100000
            wsMsg.ClientCertificates.Add(certificado)
            wsMsg.SoapVersion = SoapProtocolVersion.Soap12

            If S_Url.UrlRecepcaoEvento = "https://www.nfe.fazenda.gov.br/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx" Then

                strRetorno = wsMsgrfb.nfeRecepcaoEventoNF(xmldoc)
            Else
                strRetorno = wsMsg.nfeRecepcaoEvento(xmldoc)
            End If



            ''''''''''''''Rotina para salvar retor em xml''''''''''''''''''''''''''''
            xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & strRetorno.OuterXml & "")
            xmldoc.Save(Application.StartupPath & "\xml\Retorno_EventoNFe.xml")
            ''''''''''------------------------------------------------------------'''

            'DESMEMBRA RETORNO XML
            Dim Retornos As New RetRetorno

            'CRIA LISTA PARA RECEBER RETORNOS
            Retornos.L_Retornos = New List(Of RetRecibo)

            'VARIAVEL QUE VAI RECEBER A LISTA ANTES DE SER COLOCADA NO RETORNO
            Dim VarRecibo As New RetRecibo

            For Each outerNode As XmlNode In strRetorno

                If (outerNode.Name = "cStat") Then
                    Retornos.cStat = outerNode.InnerText
                End If
                If (outerNode.Name = "idLote") Then
                    Retornos.idLote = outerNode.InnerText
                End If
                If (outerNode.Name = "xMotivo") Then
                    Retornos.xMotivo = outerNode.InnerText
                End If

                For Each InnerNode2 As XmlNode In outerNode.ChildNodes
                    VarRecibo.XmlRecibo = InnerNode2.OuterXml

                    If InnerNode2.Name = "infEvento" Then
                        For Each InnerNode3 As XmlNode In InnerNode2.ChildNodes
                            If (InnerNode3.Name = "cStat") Then
                                VarRecibo.cStat1 = InnerNode3.InnerText
                            End If
                            If (InnerNode3.Name = "xMotivo") Then
                                VarRecibo.xMotivo1 = InnerNode3.InnerText
                            End If

                            If (InnerNode3.Name = "chNFe") Then
                                VarRecibo.chNFe = InnerNode3.InnerText
                            End If

                            If (InnerNode3.Name = "tpEvento") Then
                                VarRecibo.xEvento = InnerNode3.InnerText
                                If VarRecibo.xEvento = "210200" Then
                                    VarRecibo.xEvento = "Confirmada Operacao"
                                End If
                                If VarRecibo.xEvento = "210210" Then
                                    VarRecibo.xEvento = "Ciencia da Operacao"
                                End If
                                If VarRecibo.xEvento = "210220" Then
                                    VarRecibo.xEvento = "Desconhecimento da Operacao"
                                End If
                                If VarRecibo.xEvento = "210240" Then
                                    VarRecibo.xEvento = "Operacao nao Realizada"
                                End If
                            End If
                            If (InnerNode3.Name = "nProt") Then
                                VarRecibo.nProt = InnerNode3.InnerText
                            End If
                            If (InnerNode3.Name = "cStat") Then
                                VarRecibo.cStat1 = InnerNode3.InnerText
                            End If
                            If (InnerNode3.Name = "dhRegEvento") Then
                                VarRecibo.dhRecbto = InnerNode3.InnerText
                            End If
                        Next
                        Retornos.L_Retornos.Add(VarRecibo)
                    End If
                Next

            Next

            Return Retornos

        Catch ex As Exception
            reterro = "Ocorreu um erro No Webservice (Manifestacao11) da SEFAZ: " & ex.Message
            '   MsgBox("Ocorreu um erro No Webservice da SEFAZ: " & ex.Message, MsgBoxStyle.Information, "Retorno do Sefaz: erro webservice")
            Return Nothing
        End Try

    End Function

    Public Function nfeRecepcaoEvento_canc(ByVal IDNfe As String, ByVal EndArquivoXml As String, ByVal ambiente As String) As RetRetorno
        Dim strRetorno As XmlElement
        Dim xmldoc = New XmlDocument()
        Dim url As String
        xmldoc.Load(EndArquivoXml) 'Carrega o arquivo XML 


        Try


            url = carrega_url("NFeRecepcaoEvento4", IDNfe.Substring(0, 2), IDNfe.Substring(20, 2), IDNfe.Substring(34, 1), "4.00", ambiente)


            Dim wsMsg As NFeRecepcaoEvento4

            'CABEÇALHO USADA PARA ENVIO DE LOTE
            wsMsg = New NFeRecepcaoEvento4(url)

            wsMsg.Timeout = 100000
            wsMsg.ClientCertificates.Add(certificado)
            wsMsg.SoapVersion = SoapProtocolVersion.Soap12

            strRetorno = wsMsg.nfeRecepcaoEvento(xmldoc)


            ''''''''''''''Rotina para salvar retor em xml''''''''''''''''''''''''''''
            xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & strRetorno.OuterXml & "")
            xmldoc.Save(Application.StartupPath & "\xml\ret_cancelamento.xml")
            ''''''''''------------------------------------------------------------'''

            'DESMEMBRA RETORNO XML
            Dim Retornos As New RetRetorno

            'CRIA LISTA PARA RECEBER RETORNOS
            Retornos.L_Retornos = New List(Of RetRecibo)

            'VARIAVEL QUE VAI RECEBER A LISTA ANTES DE SER COLOCADA NO RETORNO
            Dim VarRecibo As New RetRecibo

            For Each outerNode As XmlNode In strRetorno

                If (outerNode.Name = "cStat") Then
                    Retornos.cStat = outerNode.InnerText
                End If
                If (outerNode.Name = "idLote") Then
                    Retornos.idLote = outerNode.InnerText
                End If
                If (outerNode.Name = "xMotivo") Then
                    Retornos.xMotivo = outerNode.InnerText
                End If

                For Each InnerNode2 As XmlNode In outerNode.ChildNodes
                    VarRecibo.XmlRecibo = InnerNode2.OuterXml

                    If InnerNode2.Name = "infEvento" Then
                        For Each InnerNode3 As XmlNode In InnerNode2.ChildNodes
                            If (InnerNode3.Name = "cStat") Then
                                VarRecibo.cStat1 = InnerNode3.InnerText
                            End If
                            If (InnerNode3.Name = "xMotivo") Then
                                VarRecibo.xMotivo1 = InnerNode3.InnerText
                            End If

                            If (InnerNode3.Name = "chNFe") Then
                                VarRecibo.chNFe = InnerNode3.InnerText
                            End If

                            If (InnerNode3.Name = "tpEvento") Then
                                VarRecibo.xEvento = InnerNode3.InnerText
                                If VarRecibo.xEvento = "210200" Then
                                    VarRecibo.xEvento = "Confirmada Operacao"
                                End If
                                If VarRecibo.xEvento = "210210" Then
                                    VarRecibo.xEvento = "Ciencia da Operacao"
                                End If
                                If VarRecibo.xEvento = "210220" Then
                                    VarRecibo.xEvento = "Desconhecimento da Operacao"
                                End If
                                If VarRecibo.xEvento = "210240" Then
                                    VarRecibo.xEvento = "Operacao nao Realizada"
                                End If
                            End If
                            If (InnerNode3.Name = "nProt") Then
                                VarRecibo.nProt = InnerNode3.InnerText
                            End If
                            If (InnerNode3.Name = "cStat") Then
                                VarRecibo.cStat1 = InnerNode3.InnerText
                            End If
                            If (InnerNode3.Name = "dhRegEvento") Then
                                VarRecibo.dhRecbto = InnerNode3.InnerText
                            End If
                        Next
                        Retornos.L_Retornos.Add(VarRecibo)
                    End If
                Next

            Next

            Return Retornos

        Catch ex As Exception
            reterro = "Ocorreu um erro No Webservice (Manifestacao) da SEFAZ: " & ex.Message
            '   MsgBox("Ocorreu um erro No Webservice da SEFAZ: " & ex.Message, MsgBoxStyle.Information, "Retorno do Sefaz: erro webservice")
            Return Nothing
        End Try

    End Function

    Public Function CadConsultaCadastro2(ByVal cnpj As String, ByVal uf As String, Optional ByVal cuf As String = "91") As Retcad
        Dim strRetorno As XmlElement
        Dim xmldoc = New XmlDocument()

        'BUSCA CERTIFICADO SE DEIXAR EM BRANCO ABRE JANELA DE SELEÇÃO DO WINDOWS

        Try
            Dim wsMsg As CadConsultaCadastro2
            Dim cab As New nfeCabecMsg

            If cuf = "91" Then
                cuf = S_Url.CodigoUF
            End If
            'UF E VERSÃO DO CABEÇALHO
            cab.cUF = cuf

            cab.versaoDados = "2.00"

            'CRIA UMA INSTANCIA DA CONEXÃO COM O WEBSERVICE
            wsMsg = New CadConsultaCadastro2("https://nfe.fazenda.mg.gov.br/nfe2/services/cadconsultacadastro2")

            'ASSOCIA CABEÇALHO NFE
            wsMsg.nfeCabecMsgValue = cab

            'DEFINE TEMPO MAXIMO DE ESPERA POR RETORNO
            wsMsg.Timeout = 100000

            'ASSOCIA CERTIFICADO A CONEXAO WEBSERVICE
            wsMsg.ClientCertificates.Add(certificado)

            'DEFINE PROTOCOLO USADO NA CONEXÃO
            wsMsg.SoapVersion = SoapProtocolVersion.Soap12

            xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><ConsCad versao=""2.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><infCons><xServ>CONS-CAD</xServ><UF>" & uf & "</UF><CNPJ>" & cnpj & "</CNPJ></infCons></ConsCad>")

            strRetorno = wsMsg.consultaCadastro2(xmldoc)

            xmldoc.LoadXml(strRetorno.OuterXml)
            xmldoc.Save(Application.StartupPath & "/XML/Retconscad.xml")
            '   MsgBox(strRetorno.OuterXml)

            Dim dadoscad As New Retcad

            For Each outerNode As XmlNode In strRetorno
                'PARA CADA NO VERIFICA SE O MESMO POSSUI FILHOS E VARRE OS MESMOS

                If outerNode.Name = "infCons" Then

                    For Each InnerNode As XmlNode In outerNode.ChildNodes
                        If (InnerNode.Name = "dhCons") Then
                            dadoscad.xdhCons = InnerNode.InnerText
                        End If
                        If (InnerNode.Name = "cStat") Then
                            dadoscad.cStat = InnerNode.InnerText
                        End If
                        If (InnerNode.Name = "xMotivo") Then
                            dadoscad.xmotivo = InnerNode.InnerText
                        End If

                        For Each InnerNode2 As XmlNode In outerNode.ChildNodes

                            If InnerNode2.Name = "infCad" Then
                                'captura os dados da empresa
                                For Each InnerNode3 As XmlNode In InnerNode2.ChildNodes

                                    If (InnerNode3.Name = "IE") Then
                                        dadoscad.xie = InnerNode3.InnerText
                                    End If
                                    If (InnerNode3.Name = "CNPJ") Then
                                        dadoscad.xcnpj = InnerNode3.InnerText
                                    End If
                                    If (InnerNode3.Name = "UF") Then
                                        dadoscad.xuf = InnerNode3.InnerText
                                    End If
                                    If (InnerNode3.Name = "cSit") Then
                                        dadoscad.xcSit = InnerNode3.InnerText
                                    End If
                                    If (InnerNode3.Name = "xNome") Then
                                        dadoscad.xnome = InnerNode3.InnerText
                                    End If
                                    If (InnerNode3.Name = "xFant") Then
                                        dadoscad.xnomefan = InnerNode3.InnerText
                                    End If
                                    If (InnerNode3.Name = "xRegApur") Then
                                        dadoscad.xRegApur = InnerNode3.InnerText
                                    End If
                                    If (InnerNode3.Name = "indCredNFe") Then
                                        dadoscad.indCredNFe = InnerNode3.InnerText
                                    End If
                                    If (InnerNode3.Name = "dBaixa") Then
                                        dadoscad.xdbaixa = InnerNode3.InnerText
                                    End If
                                    If (InnerNode3.Name = "dUltSit") Then
                                        dadoscad.dUltSit = InnerNode3.InnerText
                                    End If
                                    If (InnerNode3.Name = "dIniAtiv") Then
                                        Dim datai As Date
                                        datai = InnerNode3.InnerText
                                        dadoscad.xdIniAtiv = datai.ToString("dd/MM/yyyy")
                                    End If
                                    'captura o endere do empresa
                                    If InnerNode3.Name = "ender" Then

                                        For Each InnerNod4 As XmlNode In InnerNode3.ChildNodes

                                            If (InnerNod4.Name = "xLgr") Then
                                                dadoscad.xend = InnerNod4.InnerText
                                            End If
                                            If (InnerNod4.Name = "nro") Then
                                                dadoscad.xnro = InnerNod4.InnerText
                                            End If
                                            If (InnerNod4.Name = "xBairro") Then
                                                dadoscad.xbairro = InnerNod4.InnerText
                                            End If
                                            If (InnerNod4.Name = "cMun") Then
                                                dadoscad.xcmun = InnerNod4.InnerText
                                            End If
                                            If (InnerNod4.Name = "xMun") Then
                                                dadoscad.xmun = InnerNod4.InnerText
                                            End If
                                            If (InnerNod4.Name = "CEP") Then
                                                dadoscad.xcep = InnerNod4.InnerText
                                            End If
                                        Next
                                    End If

                                Next
                            End If
                        Next
                    Next


                End If
            Next
            Return dadoscad

        Catch ex As Exception
            MsgBox("Ocorreu um erro ao receber retorno: " & ex.Message, MsgBoxStyle.Information, "Retorno do Sefaz:")
            Return Nothing
        End Try

    End Function

    Public Function CadConsultaCadastro4(ByVal cnpj As String, ByVal uf As String, ByVal cuf As String) As Retcad
        Dim strRetorno As XmlNode
        Dim xmldoc = New XmlDocument()
        Dim retEnviNFe As retEnviNFe
        Dim url As String
        'Carrega o arquivo XML 

        url = carrega_url("CadConsultaCadastro4", cuf, "55")


        Try

            Dim wsMsg As CadConsultaCadastro4


            'Associa a URl da SEFAZ no Webservice
            wsMsg = New CadConsultaCadastro4(url)


            wsMsg.Timeout = 100000
            wsMsg.ClientCertificates.Add(certificado)
            wsMsg.SoapVersion = SoapProtocolVersion.Soap12

            xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><ConsCad versao=""2.00"" xmlns=""http://www.portalfiscal.inf.br/nfe""><infCons><xServ>CONS-CAD</xServ><UF>" & uf & "</UF><CNPJ>" & cnpj & "</CNPJ></infCons></ConsCad>")

            strRetorno = wsMsg.consultaCadastro(xmldoc)

            xmldoc.LoadXml(strRetorno.OuterXml)
            xmldoc.Save(Application.StartupPath & "/XML/Retconscad.xml")
            '   MsgBox(strRetorno.OuterXml)

            Dim dadoscad As New Retcad

            For Each outerNode As XmlNode In strRetorno
                'PARA CADA NO VERIFICA SE O MESMO POSSUI FILHOS E VARRE OS MESMOS

                If outerNode.Name = "infCons" Then

                    For Each InnerNode As XmlNode In outerNode.ChildNodes
                        If (InnerNode.Name = "dhCons") Then
                            dadoscad.xdhCons = InnerNode.InnerText
                        End If
                        If (InnerNode.Name = "cStat") Then
                            dadoscad.cStat = InnerNode.InnerText
                        End If
                        If (InnerNode.Name = "xMotivo") Then
                            dadoscad.xmotivo = InnerNode.InnerText
                        End If

                        For Each InnerNode2 As XmlNode In outerNode.ChildNodes

                            If InnerNode2.Name = "infCad" Then
                                'captura os dados da empresa
                                For Each InnerNode3 As XmlNode In InnerNode2.ChildNodes

                                    If (InnerNode3.Name = "IE") Then
                                        dadoscad.xie = InnerNode3.InnerText
                                    End If
                                    If (InnerNode3.Name = "CNPJ") Then
                                        dadoscad.xcnpj = InnerNode3.InnerText
                                    End If
                                    If (InnerNode3.Name = "UF") Then
                                        dadoscad.xuf = InnerNode3.InnerText
                                    End If
                                    If (InnerNode3.Name = "cSit") Then
                                        dadoscad.xcSit = InnerNode3.InnerText
                                    End If
                                    If (InnerNode3.Name = "xNome") Then
                                        dadoscad.xnome = InnerNode3.InnerText
                                    End If
                                    If (InnerNode3.Name = "xFant") Then
                                        dadoscad.xnomefan = InnerNode3.InnerText
                                    End If
                                    If (InnerNode3.Name = "xRegApur") Then
                                        dadoscad.xRegApur = InnerNode3.InnerText
                                    End If
                                    If (InnerNode3.Name = "indCredNFe") Then
                                        dadoscad.indCredNFe = InnerNode3.InnerText
                                    End If
                                    If (InnerNode3.Name = "dBaixa") Then
                                        dadoscad.xdbaixa = InnerNode3.InnerText
                                    End If
                                    If (InnerNode3.Name = "dUltSit") Then
                                        dadoscad.dUltSit = InnerNode3.InnerText
                                    End If
                                    If (InnerNode3.Name = "dIniAtiv") Then
                                        Dim datai As Date
                                        datai = InnerNode3.InnerText
                                        dadoscad.xdIniAtiv = datai.ToString("dd/MM/yyyy")
                                    End If
                                    'captura o endere do empresa
                                    If InnerNode3.Name = "ender" Then

                                        For Each InnerNod4 As XmlNode In InnerNode3.ChildNodes

                                            If (InnerNod4.Name = "xLgr") Then
                                                dadoscad.xend = InnerNod4.InnerText
                                            End If
                                            If (InnerNod4.Name = "nro") Then
                                                dadoscad.xnro = InnerNod4.InnerText
                                            End If
                                            If (InnerNod4.Name = "xBairro") Then
                                                dadoscad.xbairro = InnerNod4.InnerText
                                            End If
                                            If (InnerNod4.Name = "cMun") Then
                                                dadoscad.xcmun = InnerNod4.InnerText
                                            End If
                                            If (InnerNod4.Name = "xMun") Then
                                                dadoscad.xmun = InnerNod4.InnerText
                                            End If
                                            If (InnerNod4.Name = "CEP") Then
                                                dadoscad.xcep = InnerNod4.InnerText
                                            End If
                                        Next
                                    End If

                                Next
                            End If
                        Next
                    Next


                End If
            Next
            Return dadoscad

        Catch ex As Exception
            MsgBox("Ocorreu um erro ao receber retorno: " & ex.Message, MsgBoxStyle.Information, "Retorno do Sefaz:")
            Return Nothing
        End Try
    End Function

    Public Function nfeRecepcaoEvento_2(ByVal EndArquivoXml As String) As RetRetorno
        Dim strRetorno As XmlElement
        Dim xmldoc = New XmlDocument()

        xmldoc.Load(EndArquivoXml) 'Carrega o arquivo XML 


        Try
            Dim wsMsg As NFeRecepcaoEvento4
            Dim cab As New nfeCabecMsg

            'UF E VERSÃO DO CABEÇALHO
            cab.cUF = S_Url.CodigoUF
            cab.versaoDados = "1.00"

            'CABEÇALHO USADA PARA ENVIO DE LOTE
            wsMsg = New NFeRecepcaoEvento4(S_Url.UrlRecepcaoEvento)
            '   wsMsg.nfeCabecMsgValue = cab

            wsMsg.Timeout = 100000
            wsMsg.ClientCertificates.Add(certificado)
            wsMsg.SoapVersion = SoapProtocolVersion.Soap12

            '''''''''''''''Chama o webservice'''''''''''''''''
            ativa_webservice = True
            strRetorno = wsMsg.nfeRecepcaoEvento(xmldoc)

            ''''''''''''''Rotina para salvar retor em xml''''''''''''''''''''''''''''


            xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & strRetorno.OuterXml & "")
            xmldoc.Save(Application.StartupPath & "\xml\Retorno_EventoNFe.xml")
            ''''''''''------------------------------------------------------------'''
            'DESMEMBRA RETORNO XML
            Dim Retornos As New RetRetorno

            'CRIA LISTA PARA RECEBER RETORNOS
            Retornos.L_Retornos = New List(Of RetRecibo)

            'VARIAVEL QUE VAI RECEBER A LISTA ANTES DE SER COLOCADA NO RETORNO
            Dim VarRecibo As New RetRecibo

            For Each outerNode As XmlNode In strRetorno

                If (outerNode.Name = "cStat") Then
                    Retornos.cStat = outerNode.InnerText
                End If
                If (outerNode.Name = "idLote") Then
                    Retornos.idLote = outerNode.InnerText
                End If
                If (outerNode.Name = "xMotivo") Then
                    Retornos.xMotivo = outerNode.InnerText
                End If

                For Each InnerNode2 As XmlNode In outerNode.ChildNodes
                    VarRecibo.XmlRecibo = InnerNode2.OuterXml

                    If InnerNode2.Name = "infEvento" Then
                        For Each InnerNode3 As XmlNode In InnerNode2.ChildNodes
                            If (InnerNode3.Name = "cStat") Then
                                VarRecibo.cStat1 = InnerNode3.InnerText
                            End If
                            If (InnerNode3.Name = "xMotivo") Then
                                VarRecibo.xMotivo1 = InnerNode3.InnerText
                            End If

                            If (InnerNode3.Name = "chNFe") Then
                                VarRecibo.chNFe = InnerNode3.InnerText
                            End If

                            If (InnerNode3.Name = "tpEvento") Then
                                VarRecibo.xEvento = InnerNode3.InnerText
                                If VarRecibo.xEvento = "210200" Then
                                    VarRecibo.xEvento = "Confirmada Operacao"
                                End If
                                If VarRecibo.xEvento = "210210" Then
                                    VarRecibo.xEvento = "Ciencia da Operacao"
                                End If
                                If VarRecibo.xEvento = "210220" Then
                                    VarRecibo.xEvento = "Desconhecimento da Operacao"
                                End If
                                If VarRecibo.xEvento = "210240" Then
                                    VarRecibo.xEvento = "Operacao nao Realizada"
                                End If
                            End If
                            If (InnerNode3.Name = "nProt") Then
                                VarRecibo.nProt = InnerNode3.InnerText
                            End If
                            If (InnerNode3.Name = "cStat") Then
                                VarRecibo.cStat1 = InnerNode3.InnerText
                            End If
                            If (InnerNode3.Name = "dhRegEvento") Then
                                VarRecibo.dhRecbto = InnerNode3.InnerText
                            End If
                        Next
                        Retornos.L_Retornos.Add(VarRecibo)
                    End If
                Next

            Next

            Return Retornos
        Catch ex As Exception
            MsgBox("Ocorreu um erro no Webservice Ret: " & ex.Message, MsgBoxStyle.Information, "Retorno do Sefaz:")
            Return Nothing
        End Try
    End Function

    Public Function NFeDistribuicaoDFe(ByVal cnpj As String, ByVal ambiente As String, ByVal cuf As String, ByVal ultNSU As String, ByVal chave As String, tipo_cons As String) As RetRetorno
        Dim strRetorno As XmlElement
        Dim xmldoc = New XmlDocument()

        'BUSCA CERTIFICADO SE DEIXAR EM BRANCO ABRE JANELA DE SELEÇÃO DO WINDOWS

        Try
            Dim wsMsg As NFeDistribuicaoDFe

            'CRIA UMA INSTANCIA DA CONEXÃO COM O WEBSERVICE
            wsMsg = New NFeDistribuicaoDFe("https://www1.nfe.fazenda.gov.br/NFeDistribuicaoDFe/NFeDistribuicaoDFe.asmx")

            'DEFINE TEMPO MAXIMO DE ESPERA POR RETORNO
            wsMsg.Timeout = 100000

            'ASSOCIA CERTIFICADO A CONEXAO WEBSERVICE
            wsMsg.ClientCertificates.Add(certificado)

            'DEFINE PROTOCOLO USADO NA CONEXÃO
            wsMsg.SoapVersion = SoapProtocolVersion.Soap12

            If tipo_cons = "Dfe" Then
                xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><distDFeInt versao=""1.01"" xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>" & ambiente & "</tpAmb><cUFAutor>" & cuf & "</cUFAutor><CNPJ>" & cnpj & "</CNPJ><distNSU><ultNSU>" & ultNSU & "</ultNSU></distNSU></distDFeInt>")
            End If
            If tipo_cons = "Dfe_cons" Then
                xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><distDFeInt versao=""1.01"" xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>" & ambiente & "</tpAmb><cUFAutor>" & cuf & "</cUFAutor><CNPJ>" & cnpj & "</CNPJ><consNSU><NSU>" & ultNSU & "</NSU></consNSU></distDFeInt>")
            End If
            If tipo_cons = "Dfe_cons_chave" Then
                xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><distDFeInt versao=""1.01"" xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>" & ambiente & "</tpAmb><cUFAutor>" & cuf & "</cUFAutor><CNPJ>" & cnpj & "</CNPJ><consChNFe><chNFe>" & chave & "</chNFe></consChNFe></distDFeInt>")
            End If
            '  xmldoc.Save(Application.StartupPath & "\XML\xmldef.xml")


            strRetorno = wsMsg.nfeDistDFeInteresse(xmldoc)

            '  MsgBox(strRetorno.OuterXml)
            ''''''''''''''''''''''''''''''''''####################''"'''''''''''''''''''''''''''''''''''''''
            If Directory.Exists(Application.StartupPath & "\XML") = False Then
                Directory.CreateDirectory(Application.StartupPath & "\XML")
            End If

            xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?>" & strRetorno.OuterXml & "")
            xmldoc.Save(Application.StartupPath & "\XML\retDistDFeInt.xml")
            '''''''''''''''''''''''''''''''''''''''###############''''''''''''''''''''''



            Dim Retornos As New RetRetorno
            'CRIA LISTA PARA RECEBER RETORNOS
            Retornos.L_Retornos = New List(Of RetRecibo)
            'VARIAVEL QUE VAI RECEBER A LISTA ANTES DE SER COLOCADA NO RETORNO
            Dim VarRecibo As New RetRecibo

            For Each outerNode As XmlNode In strRetorno
                'PARA CADA NO VERIFICA SE O MESMO POSSUI FILHOS E VARRE OS MESMOS
                If (outerNode.Name = "cStat") Then
                    Retornos.cStat = outerNode.InnerText
                End If
                If (outerNode.Name = "xMotivo") Then
                    Retornos.xMotivo = outerNode.InnerText
                End If
                If (outerNode.Name = "ultNSU") Then
                    Retornos.ultNSU = outerNode.InnerText
                End If
                If (outerNode.Name = "maxNSU") Then
                    Retornos.maxNSU = outerNode.InnerText
                End If
            Next

            Return Retornos

        Catch ex As Exception
            reterro = "Ocorreu erro na Conexão com Webservice (DFe): " & ex.Message
            Return Nothing
        End Try
    End Function

    Public Function EnviaLote4(ByVal xml_envio As XmlDocument, ByVal IDNfe As String, ByVal ambiente As String)
        Dim strRetorno As XmlNode
        Dim xmldoc = New XmlDocument()
        Dim retEnviNFe As retEnviNFe
        Dim url As String
        'Carrega o arquivo XML 

        url = carrega_url("NFeAutorizacao4", IDNfe.Substring(0, 2), IDNfe.Substring(20, 2), IDNfe.Substring(34, 1), "4.00", ambiente)

        Try

            Dim wsMsg As NfeAutorizacao4


            'Associa a URl da SEFAZ no Webservice
            wsMsg = New NfeAutorizacao4(url)


            wsMsg.Timeout = 100000
            wsMsg.ClientCertificates.Add(certificado)
            wsMsg.SoapVersion = SoapProtocolVersion.Soap12

            'Chama o webservice da SEFAZ
            strRetorno = wsMsg.nfeAutorizacaoLote(xml_envio)

            xmldoc.LoadXml(strRetorno.OuterXml)
            xmldoc.Save(Application.StartupPath & "\XML\envionfe.xml")

            If strRetorno.InnerText <> "" Then
                retEnviNFe = funcoesNfe.DeserializarNFe(Of retEnviNFe)(strRetorno.OuterXml)
                Return retEnviNFe
            End If

        Catch ex As Exception

            reterro = "Ocorreu erro na Conexão com Webservice (DFe): " & ex.Message

            Return reterro

        End Try
    End Function

    Public Function EnviaLote(ByVal xml_envio As XmlDocument) As RetEnvio
        Dim strRetorno As XmlElement
        Dim xmldoc = New XmlDocument()

        '  xmldoc.Load(EndArquivoXml) 'Carrega o arquivo XML 




        Try

            Dim wsMsg As NfeAutorizacao4

            'Associa a URl da SEFAZ no Webservice
            wsMsg = New NfeAutorizacao4(S_Url.UrlNFeAutorizacao)


            wsMsg.Timeout = 100000
            wsMsg.ClientCertificates.Add(certificado)
            wsMsg.SoapVersion = SoapProtocolVersion.Soap12
            reterro = ""
            'Chama o webservice da SEFAZ
            strRetorno = wsMsg.nfeAutorizacaoLote(xml_envio)

            xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?> " & strRetorno.OuterXml & "")
            ' erro nessa estrutura xmldoc.Load("<?xml version=""1.0"" encoding=""utf-8""?> " & strRetorno.OuterXml & "")
            xmldoc.Save(Application.StartupPath & "\XML\envionfe.xml")
            'DESMEMBRA RETORNO XML
            Dim StrRetNota As RetEnvio = Nothing
            Dim XmlText As XmlDocument = New XmlDocument

            For Each outerNode As XmlNode In strRetorno
                For Each InnerNode As XmlNode In outerNode.ChildNodes
                    If (InnerNode.Name = "verAplic" Or outerNode.Name = "verAplic") Then
                        StrRetNota.verAplic = InnerNode.InnerText
                    End If
                    If (InnerNode.Name = "cStat" Or outerNode.Name = "cStat") Then
                        StrRetNota.cStat = InnerNode.InnerText
                    End If
                    If (InnerNode.Name = "xMotivo" Or outerNode.Name = "xMotivo") Then
                        StrRetNota.xMotivo = InnerNode.InnerText
                    End If
                    If (InnerNode.Name = "cUF" Or outerNode.Name = "cUF") Then
                        StrRetNota.cUF = InnerNode.InnerText
                    End If
                    If (InnerNode.Name = "nRec" Or outerNode.Name = "nRec") Then
                        StrRetNota.nRec = InnerNode.InnerText
                    End If
                    If (InnerNode.Name = "dhRecbto" Or outerNode.Name = "dhRecbto") Then
                        StrRetNota.dhRecbto = InnerNode.InnerText
                    End If
                    If (InnerNode.Name = "tMed" Or outerNode.Name = "tMed") Then
                        StrRetNota.tMed = InnerNode.InnerText
                    End If
                Next
            Next

            Return StrRetNota

        Catch ex As Exception

            reterro = "Ocorreu erro na Conexão com Webservice (DFe): " & ex.Message

            Return Nothing

        End Try
    End Function

    Public Function ConsultaRecLote(ByVal NAutorizacao As String, ambiente As String, ByVal IDNfe As String)
        Dim strRetorno As XmlNode
        Dim xmldoc = New XmlDocument()
        Dim retConsReciNFe As retConsReciNFe
        Dim url As String
        'BUSCA CERTIFICADO SE DEIXAR EM BRANCO ABRE JANELA DE SELEÇÃO DO WINDOWS

        Try

            Dim wsMsg As NfeRetAutorizacao4

            url = carrega_url("NFeRetAutorizacao4", IDNfe.Substring(0, 2), IDNfe.Substring(20, 2), IDNfe.Substring(34, 1), "4.00", ambiente)
            'CRIA UMA INSTANCIA DA CONEXÃO COM O WEBSERVICE

            wsMsg = New NfeRetAutorizacao4(url)

            'DEFINE TEMPO MAXIMO DE ESPERA POR RETORNO
            wsMsg.Timeout = 100000

            'ASSOCIA CERTIFICADO A CONEXAO WEBSERVICE
            wsMsg.ClientCertificates.Add(certificado)

            'DEFINE PROTOCOLO USADO NA CONEXÃO
            wsMsg.SoapVersion = SoapProtocolVersion.Soap12

            'CRIA UM NOVO DOCUMENTO XML
            Dim dados As XmlDocument = New XmlDocument

            'ASSOCIA O NOVO XML COM A VARIAVEL DE RETORNO DA SEFAZ
            dados.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><consReciNFe xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""4.00""><tpAmb>" & ambiente & "</tpAmb><nRec>" & NAutorizacao & "</nRec></consReciNFe>")

            'ENVIA CONSULTA PARA SEFAZ E OBTEM RETORNO EM FORMATO STRING
            strRetorno = wsMsg.nfeRetAutorizacaoLote(dados)

            xmldoc.LoadXml(strRetorno.OuterXml)
            xmldoc.Save(Application.StartupPath & "\xml\RetenvioNFe.xml")


            If strRetorno.InnerText <> "" Then


                Dim ret As String = strRetorno.OuterXml
                ret = ret.Replace("xmlns=""http://www.portalfiscal.inf.br/nfe""", "")
                ret = ret.Replace("<retConsReciNFe ", "<retConsReciNFe xmlns=""http://www.portalfiscal.inf.br/nfe""")
                ret = ret.Replace("versao=""4.00""", "")

                xmldoc.LoadXml(ret)
                xmldoc.Save(Application.StartupPath & "\xml\Retorno_EventoNFe.xml")
                retConsReciNFe = funcoesNfe.DeserializarNFe(Of retConsReciNFe)(ret)

                Dim xmllist As System.Xml.XmlNodeList
                xmllist = xmldoc.GetElementsByTagName("protNFe")
                For Each xmlnode In xmllist
                    retConsReciNFe.xmlprot = xmlnode.OuterXml
                Next


                Return retConsReciNFe


            End If

        Catch ex As Exception
            reterro = "Ocorreu erro na Conexão com Webservice (DFe): " & ex.Message
            Return Nothing
        End Try
    End Function

    Public Function ConsultaRecLote4(ByVal NAutorizacao As String, ambiente As String) As RetRetorno
        Dim strRetorno As XmlElement
        Dim CERT As X509Certificate2
        'BUSCA CERTIFICADO SE DEIXAR EM BRANCO ABRE JANELA DE SELEÇÃO DO WINDOWS

        Try

            Dim wsMsg As NfeRetAutorizacao4

            'CRIA UMA INSTANCIA DA CONEXÃO COM O WEBSERVICE
            wsMsg = New NfeRetAutorizacao4(S_Url.UrlNFeRetAutorizacao)

            'DEFINE TEMPO MAXIMO DE ESPERA POR RETORNO
            wsMsg.Timeout = 100000

            'ASSOCIA CERTIFICADO A CONEXAO WEBSERVICE
            wsMsg.ClientCertificates.Add(certificado)

            'DEFINE PROTOCOLO USADO NA CONEXÃO
            wsMsg.SoapVersion = SoapProtocolVersion.Soap12

            'CRIA UM NOVO DOCUMENTO XML
            Dim dados As XmlDocument = New XmlDocument

            'ASSOCIA O NOVO XML COM A VARIAVEL DE RETORNO DA SEFAZ
            dados.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><consReciNFe xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""4.00""><tpAmb>" & ambiente & "</tpAmb><nRec>" & NAutorizacao & "</nRec></consReciNFe>")

            'ENVIA CONSULTA PARA SEFAZ E OBTEM RETORNO EM FORMATO STRING
            strRetorno = wsMsg.nfeRetAutorizacaoLote(dados)

            dados.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?> " & strRetorno.OuterXml & "")
            dados.Save(Application.StartupPath & "\xml\retenvioNFe.xml")
            'DESMEMBRA RETORNO XML
            '-----------------------------------------------------------------------------------

            'VARIAVER QUE VAI RECEBER O RETORNO
            Dim Retornos As New RetRetorno
            'CRIA LISTA PARA RECEBER RETORNOS
            Retornos.L_Retornos = New List(Of RetRecibo)
            'VARIAVEL QUE VAI RECEBER A LISTA ANTES DE SER COLOCADA NO RETORNO
            Dim VarRecibo As New RetRecibo

            'PERCORRE TODOS OS NOS DO XML E PROCURA A TAG DE RETORNO infProt
            For Each outerNode As XmlNode In strRetorno

                'PARA CADA NO VERIFICA SE O MESMO POSSUI FILHOS E VARRE OS MESMOS
                If (outerNode.Name = "tpAmb") Then
                    Retornos.tpAmb = outerNode.InnerText
                End If
                If (outerNode.Name = "verAplic") Then
                    Retornos.verAplic = outerNode.InnerText
                End If
                If (outerNode.Name = "nRec") Then
                    Retornos.nRec = outerNode.InnerText
                End If
                If (outerNode.Name = "cStat") Then
                    Retornos.cStat = outerNode.InnerText
                End If
                If (outerNode.Name = "xMotivo") Then
                    Retornos.xMotivo = outerNode.InnerText
                End If
                If (outerNode.Name = "cUF") Then
                    Retornos.cUF = outerNode.InnerText
                End If
                For Each InnerNode As XmlNode In outerNode.ChildNodes
                    VarRecibo.XmlRecibo = InnerNode.OuterXml
                    'SE O NOME DO NO FOR infProt ENTRA NO MESMO
                    If InnerNode.Name = "infProt" Then
                        'PEGA A VARIAVEL ID QUE É UM ATRIBUTO E NAO UM ITEM
                        VarRecibo.Id = "" 'InnerNode.Attributes.ItemOf("Id").InnerText
                        'PERCORRE CAMPOS DO RETORNO PARA CAPTURAR AS INFORMAÇÕES
                        For Each InnerNode2 As XmlNode In InnerNode.ChildNodes
                            If (InnerNode2.Name = "tpAmb") Then
                                VarRecibo.tpAmb = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "verAplic") Then
                                VarRecibo.verAplic = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "chNFe") Then
                                VarRecibo.chNFe = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "dhRecbto") Then
                                VarRecibo.dhRecbto = InnerNode2.InnerText
                                VarRecibo.dhRecbtoori = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "digVal") Then
                                VarRecibo.digVal = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "cStat") Then
                                VarRecibo.cStat1 = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "nProt") Then
                                VarRecibo.nProt = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "xMotivo") Then
                                VarRecibo.xMotivo1 = InnerNode2.InnerText
                            End If
                        Next
                        'ADICIONA A NOTA NA LISTA DE RETORNO
                        Retornos.L_Retornos.Add(VarRecibo)
                    End If
                Next
            Next

            Return Retornos

        Catch ex As Exception
            reterro = "Ocorreu erro na Conexão com Webservice (DFe): " & ex.Message
            Return Nothing
        End Try
    End Function

    Public Function EnviarSefaz(certificado As X509Certificate2, xml As String) As String
        Dim url As String = "https://www1.nfe.fazenda.gov.br/NFeDistribuicaoDFe/NFeDistribuicaoDFe.asmx"

        ' 1. Configurações de Infraestrutura (Obrigatórias para o Portal Nacional)
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        ServicePointManager.CheckCertificateRevocationList = False
        ServicePointManager.Expect100Continue = False ' O AN rejeita se isso for True

        ' Limpa o cache de conexões para evitar "lixo" de tentativas anteriores
        Dim sp As ServicePoint = ServicePointManager.FindServicePoint(New Uri(url))
        sp.ConnectionLeaseTimeout = 0
        sp.CloseConnectionGroup(Nothing)

        Dim request = CType(WebRequest.Create(url), HttpWebRequest)

        ' 3. Cabeçalhos que o Portal Nacional exige
        request.Method = "POST"
        request.ContentType = "application/soap+xml; charset=utf-8"
        request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; MS Web Services Client Protocol 4.0.30319.42000)"
        request.ClientCertificates.Add(certificado)
        request.Timeout = 120000 ' 2 minutos
        request.KeepAlive = True

        ' 4. Montagem do Envelope (Garanta que o namespace esteja correto)
        Dim xmlEnvelope As String = CriarEnvelopeSoap(xml)
        Dim bytes = Encoding.UTF8.GetBytes(xmlEnvelope)
        request.ContentLength = bytes.Length

        ' Envio do Stream
        Try
            Using stream = request.GetRequestStream()
                stream.Write(bytes, 0, bytes.Length)
            End Using
        Catch ex As Exception
            Throw New Exception("Erro ao enviar dados (Stream): " & ex.Message)
        End Try

        ' Recebimento da Resposta
        Try
            Using response = CType(request.GetResponse(), HttpWebResponse)
                Using reader As New IO.StreamReader(response.GetResponseStream())
                    Return reader.ReadToEnd()
                End Using
            End Using
        Catch ex As WebException
            ' Se houver resposta de erro do servidor (XML de erro), captura aqui
            If ex.Response IsNot Nothing Then
                Using reader As New IO.StreamReader(ex.Response.GetResponseStream())
                    Return reader.ReadToEnd()
                End Using
            End If
            Throw New Exception("Erro de Canal Seguro no Ambiente Nacional: " & ex.Message)
        End Try
    End Function

    Public Function NFeDistribuicaoDFe_Http(ByVal certificado As X509Certificate2, ByVal xmlEnvio As String) As String

        Dim url As String = "https://www1.nfe.fazenda.gov.br/NFeDistribuicaoDFe/NFeDistribuicaoDFe.asmx"

        ' === 1. Configurações de Segurança e Handshake ===
        ' Permitir TLS 1.2 e fallback para segurança de negociação
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls
        ServicePointManager.Expect100Continue = False
        ServicePointManager.UseNagleAlgorithm = False

        ' Desativar CRL evita que a requisição caia por timeout enquanto o token processa o PIN
        ServicePointManager.CheckCertificateRevocationList = False

        ' === 2. Validação de Certificado (Server Side) ===
        ServicePointManager.ServerCertificateValidationCallback =
        Function(sender As Object, cert As X509Certificate, chain As X509Chain, errors As Security.SslPolicyErrors) As Boolean
            Return True ' Ignora erros de cadeia do servidor para evitar queda de conexão no A3
        End Function

        ' === 3. Acordar o Hardware StarSign (O Pulo do Gato) ===
        Try
            ' Como ToXmlString funcionou para você, mantemos aqui para garantir que 
            ' a sessão do token esteja aberta ANTES de iniciar a conexão HTTP.
            Dim forcarPIN As String = certificado.PrivateKey.ToXmlString(False)
            Debug.WriteLine("Sessão com Token StarSign iniciada com sucesso.")
        Catch ex As Exception
            Throw New Exception("Falha ao acessar chave privada do Token A3: " & ex.Message)
        End Try

        ' Envelope SOAP 1.2
        Dim soap As String = CriarEnvelopeSoap(xmlEnvio)

        Dim data() As Byte = System.Text.Encoding.UTF8.GetBytes(soap)

        ' === 4. Criação e Configuração da Requisição ===
        Dim req As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        req.ServicePoint.CloseConnectionGroup(Nothing)
        req.Method = "POST"
        req.ContentType = "application/soap+xml; charset=utf-8"
        req.ContentLength = data.Length
        req.ClientCertificates.Add(certificado)

        ' Ajustes vitais para A3: KeepAlive ajuda a não perder o handshake após o PIN
        req.KeepAlive = True
        req.Timeout = 180000
        req.ReadWriteTimeout = 180000
        req.ProtocolVersion = HttpVersion.Version11
        req.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; MS Web Services Client Protocol 4.0.30319.42000)"

        ' Envia o envelope SOAP
        Try
            Using stream = req.GetRequestStream()
                stream.Write(data, 0, data.Length)
            End Using
        Catch ex As Exception
            Throw New Exception("Erro ao abrir stream de envio (Token A3 pode ter desconectado): " & ex.Message)
        End Try

        ' === 5. Resposta do Servidor ===
        Try
            Using resp As HttpWebResponse = CType(req.GetResponse(), HttpWebResponse)
                Using sr As New StreamReader(resp.GetResponseStream())
                    Return sr.ReadToEnd()
                End Using
            End Using
        Catch ex As WebException
            ' Se houver resposta do servidor (ex: erro 500 da SEFAZ), retorna o XML de erro
            If ex.Response IsNot Nothing Then
                Using sr As New StreamReader(ex.Response.GetResponseStream())
                    Return sr.ReadToEnd()
                End Using
            Else
                ' Se caiu aqui sem Response, o erro ainda é no aperto de mão SSL
                Throw New Exception("Erro de Canal Seguro (Handshake): " & ex.Message, ex)
            End If
        End Try

    End Function
    Public Function NFeDistribuicaoDFe4(ByVal cnpj As String, ByVal ambiente As String, ByVal cuf As String, ByVal ultNSU As String, ByVal chave As String, tipo_cons As String, Optional ByVal host As Boolean = False)
        Dim strRetorno As XmlNode
        Dim retDistDFeInt As retDistDFeInt
        Dim xmldoc = New XmlDocument()

        '
        Try

            Dim wsMsg As NFeDistribuicaoDFe

            'CRIA UMA INSTANCIA DA CONEXÃO COM O WEBSERVICE
            wsMsg = New NFeDistribuicaoDFe("https://www1.nfe.fazenda.gov.br/NFeDistribuicaoDFe/NFeDistribuicaoDFe.asmx")

            'DEFINE TEMPO MAXIMO DE ESPERA POR RETORNO
            wsMsg.Timeout = 100000

            'ASSOCIA CERTIFICADO A CONEXAO WEBSERVICE
            wsMsg.ClientCertificates.Add(certificado)

            'DEFINE PROTOCOLO USADO NA CONEXÃO
            wsMsg.SoapVersion = SoapProtocolVersion.Soap12

            wsMsg.PreAuthenticate = True


            Dim tag As String

            If cnpj.Length = 11 Then
                tag = "CPF"
            Else
                tag = "CNPJ"
            End If

            If tipo_cons = "DFe" Then
                xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><distDFeInt versao=""1.01"" xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>" & ambiente & "</tpAmb><cUFAutor>" & cuf & "</cUFAutor><" & tag & ">" & cnpj & "</" & tag & "><distNSU><ultNSU>" & ultNSU & "</ultNSU></distNSU></distDFeInt>")
            End If
            If tipo_cons = "DFe_cons" Then
                xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><distDFeInt versao=""1.01"" xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>" & ambiente & "</tpAmb><cUFAutor>" & cuf & "</cUFAutor><" & tag & ">" & cnpj & "</" & tag & "><consNSU><NSU>" & ultNSU & "</NSU></consNSU></distDFeInt>")
            End If
            If tipo_cons = "DFe_cons_chave" Then
                xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><distDFeInt versao=""1.01"" xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>" & ambiente & "</tpAmb><cUFAutor>" & cuf & "</cUFAutor><" & tag & ">" & cnpj & "</" & tag & "><consChNFe><chNFe>" & chave & "</chNFe></consChNFe></distDFeInt>")
            End If
            xmldoc.Save(AppDomain.CurrentDomain.BaseDirectory + "\XML\DFe_consulta.xml")
            reterro = ""
            '''''''''''''''Chama o webservice'''''''''''''''''''
            Try
                strRetorno = wsMsg.nfeDistDFeInteresse(xmldoc)
            Catch ex As Exception
                reterro = "Ocorreu erro na Conexão com Webservice (DFe NFe): " & ex.Message
                Return "Ocorreu erro na Conexão com Webservice (DFe NFe): " & ex.Message
            End Try

            xmldoc.LoadXml(strRetorno.OuterXml)

            xmldoc.Save(AppDomain.CurrentDomain.BaseDirectory + "\XML\DFe_consulta_ret.xml")

            If host = False Then
                If strRetorno.InnerText <> "" Then
                    retDistDFeInt = funcoesNfe.DeserializarNFe(Of retDistDFeInt)(strRetorno.OuterXml)
                    Return retDistDFeInt
                End If
            Else
                Return strRetorno.OuterXml
            End If

        Catch ex As Exception
            reterro = "Ocorreu erro na Conexão com Webservice (DFe NFe): " & ex.Message
            Return "Ocorreu erro na Conexão com Webservice (DFe NFe): " & ex.Message
        End Try
    End Function

    Public Function NFeDistribuicaoDFecte(ByVal cnpj As String, ByVal ambiente As String, ByVal cuf As String, ByVal ultNSU As String, ByVal chave As String, tipo_cons As String) As retDistDFeInt
        Dim strRetorno As XmlNode
        Dim retDistDFeInt As retDistDFeInt
        Dim xmldoc = New XmlDocument()


        Try

            Dim wsMsg As CTeDistribuicaoDFe

            'CRIA UMA INSTANCIA DA CONEXÃO COM O WEBSERVICE
            wsMsg = New CTeDistribuicaoDFe("https://www1.cte.fazenda.gov.br/CTeDistribuicaoDFe/CTeDistribuicaoDFe.asmx")

            'DEFINE TEMPO MAXIMO DE ESPERA POR RETORNO
            wsMsg.Timeout = 100000

            'ASSOCIA CERTIFICADO A CONEXAO WEBSERVICE
            wsMsg.ClientCertificates.Add(certificado)

            'DEFINE PROTOCOLO USADO NA CONEXÃO
            wsMsg.SoapVersion = SoapProtocolVersion.Soap12

            Dim tag As String

            If cnpj.Length = 11 Then
                tag = "CPF"
            Else
                tag = "CNPJ"
            End If

            If tipo_cons = "cte" Then
                xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><distDFeInt versao=""1.00"" xmlns=""http://www.portalfiscal.inf.br/cte""><tpAmb>" & ambiente & "</tpAmb><cUFAutor>" & cuf & "</cUFAutor><" & tag & ">" & cnpj & "</" & tag & "><distNSU><ultNSU>" & ultNSU & "</ultNSU></distNSU></distDFeInt>")
            End If
            If tipo_cons = "cte_cons" Then
                xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><distDFeInt versao=""1.00"" xmlns=""http://www.portalfiscal.inf.br/cte""><tpAmb>" & ambiente & "</tpAmb><cUFAutor>" & cuf & "</cUFAutor><" & tag & ">" & cnpj & "</" & tag & "><consNSU><NSU>" & ultNSU & "</NSU></consNSU></distDFeInt>")
            End If
            If tipo_cons = "cte_cons_chave" Then
                xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><distDFeInt versao=""1.00"" xmlns=""http://www.portalfiscal.inf.br/cte""><tpAmb>" & ambiente & "</tpAmb><cUFAutor>" & cuf & "</cUFAutor><" & tag & ">" & cnpj & "</" & tag & "><consChNFe><chNFe>" & chave & "</chNFe></consChNFe></distDFeInt>")
            End If
            reterro = ""
            '''''''''''''''Chama o webservice'''''''''''''''''''
            strRetorno = wsMsg.cteDistDFeInteresse(xmldoc)

            If strRetorno.InnerText <> "" Then
                Dim xmlDocument As XmlDocument = New XmlDocument()
                xmlDocument.LoadXml(strRetorno.OuterXml)
                Dim ret As String = xmlDocument.OuterXml
                ret = ret.Replace("http://www.portalfiscal.inf.br/cte", "http://www.portalfiscal.inf.br/nfe")
                xmlDocument.LoadXml(ret)

                retDistDFeInt = funcoesNfe.DeserializarNFe(Of retDistDFeInt)(xmlDocument.OuterXml)
                Return retDistDFeInt
            End If

        Catch ex As Exception
            reterro = "Ocorreu erro na Conexão com Webservice (DFe CTe): " & ex.Message
            Return Nothing
        End Try
    End Function

    Public Function nfeRecepcaoEvento4new(ByVal IDNfe As String, ByVal EndArquivoXml As String, ByVal amb As String) As retEnvEvento
        Dim strRetorno As XmlNode
        Dim retEnvEvento As New retEnvEvento
        Dim xmldoc = New XmlDocument()
        Dim url As String
        xmldoc.Load(EndArquivoXml) 'Carrega o arquivo XML 


        Try

            Dim wsMsgrfb As NFeRecepcaoEvento4rfb
            Dim wsMsg As NFeRecepcaoEvento4


            If IDNfe = "an" Then
                url = "https://www.nfe.fazenda.gov.br/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx"
            Else
                url = carrega_url("NFeRecepcaoEvento4", IDNfe.Substring(0, 2), IDNfe.Substring(20, 2), IDNfe.Substring(34, 1), "4.00", amb)
            End If

            'CABEÇALHO USADA PARA ENVIO DE LOTE
            wsMsg = New NFeRecepcaoEvento4(url)
            wsMsgrfb = New NFeRecepcaoEvento4rfb(url)

            wsMsgrfb.Timeout = 100000
            wsMsgrfb.ClientCertificates.Add(certificado)
            wsMsgrfb.SoapVersion = SoapProtocolVersion.Soap12

            wsMsg.Timeout = 100000
            wsMsg.ClientCertificates.Add(certificado)
            wsMsg.SoapVersion = SoapProtocolVersion.Soap12
            reterro = ""

            If url = "https://www.nfe.fazenda.gov.br/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx" Then
                strRetorno = wsMsgrfb.nfeRecepcaoEventoNF(xmldoc)
            Else
                strRetorno = wsMsg.nfeRecepcaoEvento(xmldoc)
            End If


            If strRetorno.InnerText <> "" Then

                xmldoc.LoadXml(strRetorno.OuterXml)
                xmldoc.Save(Application.StartupPath & "\XML\Ret_evento.xml")

                retEnvEvento = funcoesNfe.DeserializarNFe(Of retEnvEvento)(strRetorno.OuterXml)

                Dim xmllist As System.Xml.XmlNodeList
                xmllist = xmldoc.GetElementsByTagName("retEvento")
                For Each xmlnode In xmllist
                    retEnvEvento.xml_ret.Add(xmlnode.OuterXml)
                    retEnvEvento.xml = xmlnode.OuterXml
                Next

                Return retEnvEvento
            End If

        Catch ex As Exception
            reterro = "Ocorreu um erro No Webservice (Manifestacao) da SEFAZ: " & ex.Message
            '   MsgBox("Ocorreu um erro No Webservice da SEFAZ: " & ex.Message, MsgBoxStyle.Information, "Retorno do Sefaz: erro webservice")
            Return Nothing
        End Try

    End Function

    Public Function NfeInutilizacao(ByVal EndArquivoXml As String, ByVal IDNfe As String, ByVal ambiente As String) As retInutNFe
        Dim strRetorno As XmlNode
        Dim procInutNFe As New retInutNFe
        Dim xmldoc = New XmlDocument()
        Dim url As String

        xmldoc.Load(EndArquivoXml) 'Carrega o arquivo XML 


        Try
            Dim wsMsg As NfeInutilizacao4
            Dim cab As New nfeCabecMsg


            url = carrega_url("NFeInutilizacao4", IDNfe.Substring(0, 2), IDNfe.Substring(20, 2), IDNfe.Substring(34, 1), "4.00", ambiente)

            wsMsg = New NfeInutilizacao4(url)

            wsMsg.Timeout = 100000
            wsMsg.ClientCertificates.Add(certificado)
            wsMsg.SoapVersion = SoapProtocolVersion.Soap12

            strRetorno = wsMsg.nfeInutilizacaoNF(xmldoc)

            ''''''''''''''Rotina para salvar retor em xml''''''''''''''''''''''''''''
            xmldoc.LoadXml(strRetorno.OuterXml)
            xmldoc.Save(Application.StartupPath & "\xml\RetInutNFe.xml")
            ''''''''''------------------------------------------------------------'''
            If strRetorno.InnerText <> "" Then
                Dim ret As String = strRetorno.OuterXml
                ret = ret.Replace("xmlns=""http://www.portalfiscal.inf.br/nfe""", "")
                ret = ret.Replace("<retInutNFe", "<retInutNFe xmlns=""http://www.portalfiscal.inf.br/nfe""")


                xmldoc.LoadXml(ret)

                procInutNFe = funcoesNfe.DeserializarNFe(Of retInutNFe)(ret)

                Dim xmllist As System.Xml.XmlNodeList
                xmllist = xmldoc.GetElementsByTagName("retInutNFe")
                For Each xmlnode In xmllist
                    procInutNFe.xml = xmlnode.OuterXml
                Next

                Return procInutNFe
            End If



        Catch ex As Exception
            reterro = "Ocorreu um erro No Webservice (NfeInutilizacao) da SEFAZ: " & ex.Message
            Return Nothing
        End Try
    End Function

    Private Function CriarEnvelopeSoap(xmlDados As String) As String
        Return "<soap12:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" " &
               "xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" " &
               "xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">" &
               "<soap12:Body>" &
               "<nfeDistDFeInteresse xmlns=""http://www.portalfiscal.inf.br/nfe/wsdl/NFeDistribuicaoDFe"">" &
               "<nfeDadosMsg>" & xmlDados & "</nfeDadosMsg>" &
               "</nfeDistDFeInteresse>" &
               "</soap12:Body>" &
               "</soap12:Envelope>"
    End Function
End Class
