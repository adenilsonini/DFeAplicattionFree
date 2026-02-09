
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Threading
Imports System.Web.Services.Description
Imports System.Web.Services.Protocols
Imports System.Xml
Imports System.Xml.Serialization


Public Class Webservice4S
    Private m_timeout As Integer
    Private certDig As X509Certificate2
    Private assemblyWS As CompilerResults
    Public msgErros As String

    Private objEnvioSefaz As Object
    Private objRetornoWS As Object
    Private iTipoRetTr As Integer
    Private VersaoLayoutNFCe As String
    Private m_XmlRetornoSefaz As XmlDocument

    Public Sub New(ByVal url As String, ByVal nome_space As String, ByVal servico As String, ByVal NomeMetodo As String, ByVal VersaoLayout As String, WEBSERVICE As String, ByVal CertificadoDigital As X509Certificate2)
        Me.m_timeout = 15000
        Me.m_url = url
        Me.m_NomeClasse = servico
        Me.m_NomeMetodo = NomeMetodo
        Me.m_Wsdl = wsdl_cons(m_url, nome_space, NomeMetodo, servico, WEBSERVICE)
        Me.msgErros = String.Empty
        '  Me.servico = CType(Nothing, SefazXmlWsdl)


        Try

            Me.VersaoLayoutNFCe = VersaoLayout
            Me.certDig = CertificadoDigital

            Me.CreateAssembly(CType(New MemoryStream(Encoding.UTF8.GetBytes(Me.m_Wsdl)), Stream))

        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Me.msgErros = ex.Message
            ProjectData.ClearProjectError()
        End Try
    End Sub


    Public WriteOnly Property Timeout As Integer
        Set(ByVal value As Integer)
            Me.m_timeout = value
        End Set
    End Property


    Private m_url As String
    Public WriteOnly Property url As String
        Set(ByVal value As String)
            Me.m_url = value
        End Set
    End Property

    Private m_Wsdl As String
    Public WriteOnly Property Wsdl As String
        Set(ByVal value As String)
            Me.m_Wsdl = value
        End Set
    End Property


    Private m_NomeClasse As String
    Public WriteOnly Property NomeClasse As String
        Set(ByVal value As String)
            Me.m_NomeClasse = value
        End Set
    End Property

    Private m_NomeMetodo As String
    Public WriteOnly Property NomeMetodo As String
        Set(ByVal value As String)
            Me.m_NomeMetodo = value
        End Set
    End Property


    Public ReadOnly Property GetErros As String
        Get
            Return Me.msgErros
        End Get
    End Property

    Public Function wsdl_cons(ByVal url As String, name_space As String, metodo As String, servico As String, WEBSERVICE As String) As String
        Dim wsdl_ret As String

        If WEBSERVICE = "ESTADO" Then
            wsdl_ret = "<wsdl:definitions xmlns:s=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://schemas.xmlsoap.org/wsdl/soap12/"" xmlns:http=""http://schemas.xmlsoap.org/wsdl/http/"" xmlns:mime=""http://schemas.xmlsoap.org/wsdl/mime/"" xmlns:tns=""" & name_space & """ xmlns:soap=""http://schemas.xmlsoap.org/wsdl/soap/"" xmlns:tm=""http://microsoft.com/wsdl/mime/textMatching/"" xmlns:soapenc=""http://schemas.xmlsoap.org/soap/encoding/"" targetNamespace=""" & name_space & """ xmlns:wsdl=""http://schemas.xmlsoap.org/wsdl/""><wsdl:types><s:schema elementFormDefault=""qualified"" targetNamespace=""" & name_space & """><s:element name=""nfeDadosMsg""><s:complexType mixed=""true""><s:sequence><s:any /></s:sequence></s:complexType></s:element><s:element name=""nfeResultMsg"" nillable=""true""><s:complexType mixed=""true""><s:sequence><s:any /></s:sequence></s:complexType></s:element></s:schema></wsdl:types><wsdl:message name=""" & metodo & "SoapIn""><wsdl:part name=""nfeDadosMsg"" element=""tns:nfeDadosMsg"" /></wsdl:message><wsdl:message name=""" & metodo & "SoapOut""><wsdl:part name=""" & metodo & "Result"" element=""tns:nfeResultMsg"" /></wsdl:message><wsdl:portType name=""" & servico & "Soap""><wsdl:operation name=""" & metodo & """><wsdl:input message=""tns:" & metodo & "SoapIn"" /><wsdl:output message=""tns:" & metodo & "SoapOut"" /></wsdl:operation></wsdl:portType><wsdl:binding name=""" & servico & "Soap"" type=""tns:" & servico & "Soap""><soap:binding transport=""http://schemas.xmlsoap.org/soap/http"" /><wsdl:operation name=""" & metodo & """><soap:operation soapAction=""" & name_space & "/" & "" & metodo & """ style=""document"" /><wsdl:input><soap:body use=""literal"" /></wsdl:input><wsdl:output><soap:body use=""literal"" /></wsdl:output></wsdl:operation></wsdl:binding><wsdl:binding name=""" & servico & "Soap12"" type=""tns:" & servico & "Soap""><soap12:binding transport=""http://schemas.xmlsoap.org/soap/http"" /><wsdl:operation name=""" & metodo & """><soap12:operation soapAction=""" & name_space & "/" & "" & metodo & """ style=""document"" /><wsdl:input><soap12:body use=""literal"" /></wsdl:input><wsdl:output><soap12:body use=""literal"" /></wsdl:output></wsdl:operation></wsdl:binding><wsdl:service name=""" & servico & """><wsdl:port name=""" & servico & "Soap"" binding=""tns:" & servico & "Soap""><soap:address location=""" & url & """ /></wsdl:port><wsdl:port name=""" & servico & "Soap12"" binding=""tns:" & servico & "Soap12""><soap12:address location=""" & url & """ /></wsdl:port></wsdl:service></wsdl:definitions>"
        End If
        If WEBSERVICE = "ANDFE" Then
            wsdl_ret = "<wsdl:definitions xmlns:s=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://schemas.xmlsoap.org/wsdl/soap12/"" xmlns:http=""http://schemas.xmlsoap.org/wsdl/http/"" xmlns:mime=""http://schemas.xmlsoap.org/wsdl/mime/"" xmlns:tns=""http://www.portalfiscal.inf.br/nfe/wsdl/NFeDistribuicaoDFe"" xmlns:soap=""http://schemas.xmlsoap.org/wsdl/soap/"" xmlns:tm=""http://microsoft.com/wsdl/mime/textMatching/"" xmlns:soapenc=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:wsdl=""http://schemas.xmlsoap.org/wsdl/"" targetNamespace=""http://www.portalfiscal.inf.br/nfe/wsdl/NFeDistribuicaoDFe""><wsdl:types><s:schema elementFormDefault=""qualified"" targetNamespace=""http://www.portalfiscal.inf.br/nfe/wsdl/NFeDistribuicaoDFe""><s:element name=""nfeDistDFeInteresse""><s:complexType><s:sequence><s:element minOccurs=""0"" maxOccurs=""1"" name=""nfeDadosMsg""><s:complexType mixed=""true""><s:sequence><s:any/></s:sequence></s:complexType></s:element></s:sequence></s:complexType></s:element><s:element name=""nfeDistDFeInteresseResponse""><s:complexType><s:sequence><s:element minOccurs=""0"" maxOccurs=""1"" name=""nfeDistDFeInteresseResult""><s:complexType mixed=""true""><s:sequence><s:any/></s:sequence></s:complexType></s:element></s:sequence></s:complexType></s:element></s:schema></wsdl:types><wsdl:message name=""nfeDistDFeInteresseSoapIn""><wsdl:part name=""parameters"" element=""tns:nfeDistDFeInteresse""/></wsdl:message><wsdl:message name=""nfeDistDFeInteresseSoapOut""><wsdl:part name=""parameters"" element=""tns:nfeDistDFeInteresseResponse""/></wsdl:message><wsdl:portType name=""NFeDistribuicaoDFeSoap""><wsdl:operation name=""nfeDistDFeInteresse""><wsdl:input message=""tns:nfeDistDFeInteresseSoapIn""/><wsdl:output message=""tns:nfeDistDFeInteresseSoapOut""/></wsdl:operation></wsdl:portType><wsdl:binding name=""NFeDistribuicaoDFeSoap"" type=""tns:NFeDistribuicaoDFeSoap""><soap:binding transport=""http://schemas.xmlsoap.org/soap/http""/><wsdl:operation name=""nfeDistDFeInteresse""><soap:operation soapAction=""http://www.portalfiscal.inf.br/nfe/wsdl/NFeDistribuicaoDFe/nfeDistDFeInteresse"" style=""document""/><wsdl:input><soap:body use=""literal""/></wsdl:input><wsdl:output><soap:body use=""literal""/></wsdl:output></wsdl:operation></wsdl:binding><wsdl:binding name=""NFeDistribuicaoDFeSoap12"" type=""tns:NFeDistribuicaoDFeSoap""><soap12:binding transport=""http://schemas.xmlsoap.org/soap/http""/><wsdl:operation name=""nfeDistDFeInteresse""><soap12:operation soapAction=""http://www.portalfiscal.inf.br/nfe/wsdl/NFeDistribuicaoDFe/nfeDistDFeInteresse"" style=""document""/><wsdl:input><soap12:body use=""literal""/></wsdl:input><wsdl:output><soap12:body use=""literal""/></wsdl:output></wsdl:operation></wsdl:binding><wsdl:service name=""NFeDistribuicaoDFe""><wsdl:port name=""NFeDistribuicaoDFeSoap"" binding=""tns:NFeDistribuicaoDFeSoap""><soap:address location=""https://www1.nfe.fazenda.gov.br/NFeDistribuicaoDFe/NFeDistribuicaoDFe.asmx""/></wsdl:port><wsdl:port name=""NFeDistribuicaoDFeSoap12"" binding=""tns:NFeDistribuicaoDFeSoap12""><soap12:address location=""https://www1.nfe.fazenda.gov.br/NFeDistribuicaoDFe/NFeDistribuicaoDFe.asmx""/></wsdl:port></wsdl:service></wsdl:definitions>"
        End If
        If WEBSERVICE = "ANEVENTO" Then
            wsdl_ret = "<wsdl:definitions xmlns:s=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://schemas.xmlsoap.org/wsdl/soap12/"" xmlns:http=""http://schemas.xmlsoap.org/wsdl/http/"" xmlns:mime=""http://schemas.xmlsoap.org/wsdl/mime/"" xmlns:tns=""http://www.portalfiscal.inf.br/nfe/wsdl/NFeRecepcaoEvento4"" xmlns:soap=""http://schemas.xmlsoap.org/wsdl/soap/"" xmlns:tm=""http://microsoft.com/wsdl/mime/textMatching/"" xmlns:soapenc=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:wsdl=""http://schemas.xmlsoap.org/wsdl/"" targetNamespace=""http://www.portalfiscal.inf.br/nfe/wsdl/NFeRecepcaoEvento4""><wsdl:types><s:schema elementFormDefault=""qualified"" targetNamespace=""http://www.portalfiscal.inf.br/nfe/wsdl/NFeRecepcaoEvento4""><s:element name=""nfeDadosMsg""><s:complexType mixed=""true""><s:sequence><s:any/></s:sequence></s:complexType></s:element><s:element name=""nfeRecepcaoEventoNFResult""><s:complexType mixed=""true""><s:sequence><s:any/></s:sequence></s:complexType></s:element></s:schema></wsdl:types><wsdl:message name=""nfeRecepcaoEventoNFSoapIn""><wsdl:part name=""nfeDadosMsg"" element=""tns:nfeDadosMsg""/></wsdl:message><wsdl:message name=""nfeRecepcaoEventoNFSoapOut""><wsdl:part name=""nfeRecepcaoEventoNFResult"" element=""tns:nfeRecepcaoEventoNFResult""/></wsdl:message><wsdl:portType name=""NFeRecepcaoEvento4Soap""><wsdl:operation name=""nfeRecepcaoEventoNF""><wsdl:documentation xmlns:wsdl=""http://schemas.xmlsoap.org/wsdl/"">Serviço destinado à recepção de mensagem de Evento da NF-e.</wsdl:documentation><wsdl:input message=""tns:nfeRecepcaoEventoNFSoapIn""/><wsdl:output message=""tns:nfeRecepcaoEventoNFSoapOut""/></wsdl:operation></wsdl:portType><wsdl:binding name=""NFeRecepcaoEvento4Soap"" type=""tns:NFeRecepcaoEvento4Soap""><soap:binding transport=""http://schemas.xmlsoap.org/soap/http""/><wsdl:operation name=""nfeRecepcaoEventoNF""><soap:operation soapAction=""http://www.portalfiscal.inf.br/nfe/wsdl/NFeRecepcaoEvento4/nfeRecepcaoEventoNF"" style=""document""/><wsdl:input><soap:body use=""literal""/></wsdl:input><wsdl:output><soap:body use=""literal""/></wsdl:output></wsdl:operation></wsdl:binding><wsdl:binding name=""NFeRecepcaoEvento4Soap12"" type=""tns:NFeRecepcaoEvento4Soap""><soap12:binding transport=""http://schemas.xmlsoap.org/soap/http""/><wsdl:operation name=""nfeRecepcaoEventoNF""><soap12:operation soapAction=""http://www.portalfiscal.inf.br/nfe/wsdl/NFeRecepcaoEvento4/nfeRecepcaoEventoNF"" style=""document""/><wsdl:input><soap12:body use=""literal""/></wsdl:input><wsdl:output><soap12:body use=""literal""/></wsdl:output></wsdl:operation></wsdl:binding><wsdl:service name=""NFeRecepcaoEvento4""><wsdl:port name=""NFeRecepcaoEvento4Soap"" binding=""tns:NFeRecepcaoEvento4Soap""><soap:address location=""https://www.nfe.fazenda.gov.br/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx""/></wsdl:port><wsdl:port name=""NFeRecepcaoEvento4Soap12"" binding=""tns:NFeRecepcaoEvento4Soap12""><soap12:address location=""https://www.nfe.fazenda.gov.br/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx""/></wsdl:port></wsdl:service></wsdl:definitions>"
        End If

        If WEBSERVICE = "ANDFECTE" Then
            wsdl_ret = "<wsdl:definitions xmlns:s=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://schemas.xmlsoap.org/wsdl/soap12/"" xmlns:http=""http://schemas.xmlsoap.org/wsdl/http/"" xmlns:mime=""http://schemas.xmlsoap.org/wsdl/mime/"" xmlns:tns=""http://www.portalfiscal.inf.br/cte/wsdl/CTeDistribuicaoDFe"" xmlns:soap=""http://schemas.xmlsoap.org/wsdl/soap/"" xmlns:tm=""http://microsoft.com/wsdl/mime/textMatching/"" xmlns:soapenc=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:wsdl=""http://schemas.xmlsoap.org/wsdl/"" targetNamespace=""http://www.portalfiscal.inf.br/cte/wsdl/CTeDistribuicaoDFe""><wsdl:types><s:schema elementFormDefault=""qualified"" targetNamespace=""http://www.portalfiscal.inf.br/cte/wsdl/CTeDistribuicaoDFe""><s:element name=""cteDistDFeInteresse""><s:complexType><s:sequence><s:element minOccurs=""0"" maxOccurs=""1"" name=""cteDadosMsg""><s:complexType mixed=""true""><s:sequence><s:any/></s:sequence></s:complexType></s:element></s:sequence></s:complexType></s:element><s:element name=""cteDistDFeInteresseResponse""><s:complexType><s:sequence><s:element minOccurs=""0"" maxOccurs=""1"" name=""cteDistDFeInteresseResult""><s:complexType mixed=""true""><s:sequence><s:any/></s:sequence></s:complexType></s:element></s:sequence></s:complexType></s:element></s:schema></wsdl:types><wsdl:message name=""cteDistDFeInteresseSoapIn""><wsdl:part name=""parameters"" element=""tns:cteDistDFeInteresse""/></wsdl:message><wsdl:message name=""cteDistDFeInteresseSoapOut""><wsdl:part name=""parameters"" element=""tns:cteDistDFeInteresseResponse""/></wsdl:message><wsdl:portType name=""CTeDistribuicaoDFeSoap""><wsdl:operation name=""cteDistDFeInteresse""><wsdl:input message=""tns:cteDistDFeInteresseSoapIn""/><wsdl:output message=""tns:cteDistDFeInteresseSoapOut""/></wsdl:operation></wsdl:portType><wsdl:binding name=""CTeDistribuicaoDFeSoap"" type=""tns:CTeDistribuicaoDFeSoap""><soap:binding transport=""http://schemas.xmlsoap.org/soap/http""/><wsdl:operation name=""cteDistDFeInteresse""><soap:operation soapAction=""http://www.portalfiscal.inf.br/cte/wsdl/CTeDistribuicaoDFe/cteDistDFeInteresse"" style=""document""/><wsdl:input><soap:body use=""literal""/></wsdl:input><wsdl:output><soap:body use=""literal""/></wsdl:output></wsdl:operation></wsdl:binding><wsdl:binding name=""CTeDistribuicaoDFeSoap12"" type=""tns:CTeDistribuicaoDFeSoap""><soap12:binding transport=""http://schemas.xmlsoap.org/soap/http""/><wsdl:operation name=""cteDistDFeInteresse""><soap12:operation soapAction=""http://www.portalfiscal.inf.br/cte/wsdl/CTeDistribuicaoDFe/cteDistDFeInteresse"" style=""document""/><wsdl:input><soap12:body use=""literal""/></wsdl:input><wsdl:output><soap12:body use=""literal""/></wsdl:output></wsdl:operation></wsdl:binding><wsdl:service name=""CTeDistribuicaoDFe""><wsdl:port name=""CTeDistribuicaoDFeSoap"" binding=""tns:CTeDistribuicaoDFeSoap""><soap:address location=""https://www1.cte.fazenda.gov.br/CTeDistribuicaoDFe/CTeDistribuicaoDFe.asmx""/></wsdl:port><wsdl:port name=""CTeDistribuicaoDFeSoap12"" binding=""tns:CTeDistribuicaoDFeSoap12""><soap12:address location=""https://www1.cte.fazenda.gov.br/CTeDistribuicaoDFe/CTeDistribuicaoDFe.asmx""/></wsdl:port></wsdl:service></wsdl:definitions>"
        End If
        Return wsdl_ret
    End Function
    Public Function NFeAutorizacao(ByVal xmlDoc As XmlDocument, Optional ByVal objRetCont As Object = Nothing) As String
        Dim retEnviNfe As String

        Try
            ' mdlGeral.CriarArquivoLog("xmlDoc: " & xmlDoc.InnerXml, NameOf(NFeAutorizacao), NameOf(DynamicWS), False, False, False)
            retEnviNfe = Me.EnviarSefaz(xmlDoc, True, False, objRetCont)
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            ' mdlGeral.CriarArquivoLog("Erro: " & exception.Message & " / " & exception.StackTrace, NameOf(NFeAutorizacao), NameOf(DynamicWS), False, False, False)
            If Me.msgErros = "" Then
                Me.msgErros = ex.Message & ", Class Webservice4: NFeAutorizacao"
            End If
            retEnviNfe = Me.msgErros
            ProjectData.ClearProjectError()
        End Try

        Return retEnviNfe
    End Function

    Public Function NFeRetAutorizacao(ByVal xmlDoc As XmlDocument) As String
        Dim retConsReciNfe As String

        Try
            Dim xmlDoc1 As XmlDocument = xmlDoc
            Dim obj As Object = CObj(Nothing)
            Dim local As Object = obj
            retConsReciNfe = Me.EnviarSefaz(xmlDoc1, True, False, local)
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            If Me.msgErros = "" Then
                Me.msgErros = ex.Message & ", Class Webservice4: NFeRetAutorizacao"
            End If
            ProjectData.ClearProjectError()
            retConsReciNfe = msgErros
        End Try

        Return retConsReciNfe
    End Function

    Public Function NFeConsultaProtocolo(ByVal xmlDoc As XmlDocument) As String
        Dim retConsSitNfe As String

        Try
            Dim xmlDoc1 As XmlDocument = xmlDoc
            Dim obj As Object = CObj(Nothing)
            Dim local As Object = obj
            retConsSitNfe = Me.EnviarSefaz(xmlDoc1, True, False, local)

        Catch ex As Exception
            ProjectData.SetProjectError(ex)

            If Me.msgErros = "" Then
                Me.msgErros = ex.Message & ", Class Webservice4: NFeConsultaProtocolo"
            End If

            retConsSitNfe = msgErros

            ProjectData.ClearProjectError()
        End Try

        Return retConsSitNfe
    End Function

    Public Function RecepcaoEvento(ByVal xmlDoc As XmlDocument) As String
        Dim retEnvEvento As String

        Try
            Dim xmlDoc1 As XmlDocument = xmlDoc
            Dim obj As Object = CObj(Nothing)
            Dim local As Object = obj
            retEnvEvento = Me.EnviarSefaz(xmlDoc1, True, False, local)
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            If Me.msgErros = "" Then
                Me.msgErros = ex.Message & ", Class Webservice4: RecepcaoEvento"
            End If
            retEnvEvento = Me.msgErros
            ProjectData.ClearProjectError()
        End Try

        Return retEnvEvento
    End Function
    Public Function NFeInutilizacao(ByVal xmlDoc As XmlDocument) As String
        Dim retInutNfe As String

        Try
            Dim xmlDoc1 As XmlDocument = xmlDoc
            Dim obj As Object = CObj(Nothing)
            Dim local As Object = obj
            retInutNfe = Me.EnviarSefaz(xmlDoc1, True, False, local)
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            If Me.msgErros = "" Then
                Me.msgErros = ex.Message & ", Class Webservice4: NFeInutilizacao"
            End If
            retInutNfe = Me.msgErros
            ProjectData.ClearProjectError()
        End Try

        Return retInutNfe
    End Function

    Public Function NFeStatusServico(ByVal xmlDoc As XmlDocument) As String

        Dim retConsStatServ As String

        Try
            Dim xmlDoc1 As XmlDocument = xmlDoc
            Dim obj As Object = CObj(Nothing)
            Dim local As Object = obj


            retConsStatServ = Me.EnviarSefaz(xmlDoc1, True, False, local)

        Catch ex As Exception
            ProjectData.SetProjectError(ex)

            If Me.msgErros = "" Then
                Me.msgErros = ex.Message & ", Class Webservice4: NFeStatusServico"
            End If

            retConsStatServ = Me.msgErros
            ProjectData.ClearProjectError()
        End Try

        Return retConsStatServ
    End Function
    Public Function NFeDistribuicaoDFe(ByVal xmlDoc As XmlDocument) As String
        Dim retDistDfeInt As String

        Try
            Dim xmlDoc1 As XmlDocument = xmlDoc
            Dim obj As Object = CObj(Nothing)
            Dim local As Object = obj
            retDistDfeInt = Me.EnviarSefaz(xmlDoc1, True, False, local)
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            If Me.msgErros = "" Then
                Me.msgErros = ex.Message & ", Class Webservice4: NFeDistribuicaoDFe"
            End If
            retDistDfeInt = Me.msgErros
            ProjectData.ClearProjectError()
        End Try

        Return retDistDfeInt
    End Function
    Public Function NFeConsultaCadastro(ByVal xmlDoc As XmlDocument) As String
        Dim retConsCad As String

        Try
            Dim xmlDoc1 As XmlDocument = xmlDoc
            Dim obj As Object = CObj(Nothing)
            Dim local As Object = obj
            retConsCad = Me.EnviarSefaz(xmlDoc1, True, False, local)
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            If Me.msgErros = "" Then
                Me.msgErros = ex.Message & ", Class Webservice4: NFeConsultaCadastro"
            End If
            retConsCad = Me.msgErros
            ProjectData.ClearProjectError()
        End Try

        Return retConsCad
    End Function

    Public Property XmlRetornoSefaz As XmlDocument
        Get
            Return Me.m_XmlRetornoSefaz
        End Get
        Set(ByVal value As XmlDocument)
            Me.m_XmlRetornoSefaz = value
        End Set
    End Property

    Private Function EnviarSefaz(ByVal xmlDoc As XmlDocument, Optional ByVal deserializar As Boolean = True, Optional ByVal cabecMsg As Boolean = True, Optional ByRef objRetCont As Object = Nothing) As String
        Dim obj As String
        Me.msgErros = ""


        Try
            ServicePointManager.SecurityProtocol = CType(4080, SecurityProtocolType)
            Me.XmlRetornoSefaz = CType(Nothing, XmlDocument)
            ' mdlGeral.CriarArquivoLog("Depuração EnviarSefaz/DynamicWS... Início!", "", "", False, False, False)

            If Me.assemblyWS IsNot Nothing Then
                ' mdlGeral.CriarArquivoLog("Depuração EnviarSefaz/DynamicWS... NomeClasse", "", "", False, False, False)
                Me.objEnvioSefaz = RuntimeHelpers.GetObjectValue(Me.assemblyWS.CompiledAssembly.CreateInstance(Me.m_NomeClasse))
                Me.SetPropertyValue(RuntimeHelpers.GetObjectValue(Me.objEnvioSefaz), "Url", CObj(Me.m_url))
                ' mdlGeral.CriarArquivoLog("Depuração EnviarSefaz/DynamicWS... URL", "", "", False, False, False)
                '   mdlGeral.CriarArquivoLog("Depuração EnviarSefaz/DynamicWS... Timeout", "", "", False, False, False)
                If Me.m_timeout < 6000 Then Me.m_timeout = 6000

                Me.SetPropertyValue(RuntimeHelpers.GetObjectValue(Me.objEnvioSefaz), "Timeout", CObj(Me.m_timeout))
                '     mdlGeral.CriarArquivoLog("Depuração EnviarSefaz/DynamicWS... SoapProtocolo", "", "", False, False, False)
                Me.SetPropertyValue(RuntimeHelpers.GetObjectValue(Me.objEnvioSefaz), "SoapVersion", CObj(SoapProtocolVersion.Soap12))

                If Operators.CompareString(Me.VersaoLayoutNFCe, "4.00", False) = 0 Then cabecMsg = False
                '  mdlGeral.CriarArquivoLog("Depuração EnviarSefaz/DynamicWS... Cabeçalho: " & cabecMsg.ToString(), "", "", False, False, False)

                If cabecMsg Then
                    Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Me.assemblyWS.CompiledAssembly.CreateInstance("nfeCabecMsg"))
                    ' Me.SetPropertyValue(RuntimeHelpers.GetObjectValue(objectValue), "cUF", CObj(Me.nfeConfig.CodUF))
                    ' Me.SetPropertyValue(RuntimeHelpers.GetObjectValue(objectValue), "versaoDados", CObj(Me.nfeConfig.Versao))
                    Me.SetPropertyValue(RuntimeHelpers.GetObjectValue(Me.objEnvioSefaz), "nfeCabecMsgValue", RuntimeHelpers.GetObjectValue(objectValue))
                End If

                '    mdlGeral.CriarArquivoLog("Depuração EnviarSefaz/DynamicWS... Instanciar certificado digital", "", "", False, False, False)
                Dim objectValue1 As Object = RuntimeHelpers.GetObjectValue(Me.objEnvioSefaz.[GetType]().InvokeMember("ClientCertificates", BindingFlags.GetProperty, CType(Nothing, Binder), RuntimeHelpers.GetObjectValue(Me.objEnvioSefaz), New Object(-1) {}))
                objectValue1.[GetType]().InvokeMember("Add", BindingFlags.InvokeMethod, CType(Nothing, Binder), RuntimeHelpers.GetObjectValue(objectValue1), New Object(0) {CObj(Me.certDig)})
                '   mdlGeral.CriarArquivoLog("Thread envio XML(" & xmlDoc.InnerXml & ")", "", "", False, False, False)
                Me.iTipoRetTr = 0
                Dim thread As Thread = New Thread(CType((Sub(a0) Me.mEnvioSefaz(CType(a0, XmlDocument))), ParameterizedThreadStart))
                thread.Start(CObj(xmlDoc))

                While Me.objRetornoWS Is Nothing
                    Dim num As Integer

                    If CDbl(num) = CDbl(Me.m_timeout) / 1000.0 + 1.0 Then
                        '  mdlGeral.CriarArquivoLog("TimeOut da thread esgotado. A thread vai ser abortada!", "", "", False, False, False)
                        Me.iTipoRetTr = 999
                        thread.Abort()
                        Exit While
                    End If

                    If Me.iTipoRetTr = 9 Then
                        ' mdlGeral.CriarArquivoLog("Ocorreu um erro ao tentar conexão com o WS!", "", "", False, False, False)
                        thread.Abort()
                        Exit While
                    End If

                    num += 1

                    thread.Sleep(1000)
                End While

                objRetCont = CObj(New retEnviNFe())
                ' mdlGeral.CriarArquivoLog("Depuração EnviarSefaz/DynamicWS... retorno => OK", "", "", False, False, False)

                If Me.objRetornoWS IsNot Nothing Then
                    Dim objRetornoWs As XmlNode = CType(Me.objRetornoWS, XmlNode)
                    Me.XmlRetornoSefaz = New XmlDocument()
                    Me.XmlRetornoSefaz.LoadXml(objRetornoWs.OuterXml)
                    obj = objRetornoWs.OuterXml
                    '  mdlGeral.CriarArquivoLog("Depuração EnviarSefaz/DynamicWS... retorno => " & objRetornoWs.OuterXml, "", "", False, False, False)
                Else

                    Select Case Me.iTipoRetTr
                        Case 9
                            NewLateBinding.LateSet(objRetCont, CType(Nothing, Type), "cstat", New Object(0) {CObj(9003)}, CType(Nothing, String()), CType(Nothing, Type()))
                            NewLateBinding.LateSet(objRetCont, CType(Nothing, Type), "xmotivo", New Object(0) {CObj("Serviço fora de operação ou erro na conexão")}, CType(Nothing, String()), CType(Nothing, Type()))
                            Me.msgErros = "Serviço fora de operação ou erro na conexão"
                            gerar_evento_host("Serviço fora de operação ou erro na conexão," & ", Class Webservice4: EnviarSefaz", "Webservice4S")
                        Case 999
                            NewLateBinding.LateSet(objRetCont, CType(Nothing, Type), "cstat", New Object(0) {CObj(9001)}, CType(Nothing, String()), CType(Nothing, Type()))
                            NewLateBinding.LateSet(objRetCont, CType(Nothing, Type), "xmotivo", New Object(0) {CObj("Timeout de transmissão atingido")}, CType(Nothing, String()), CType(Nothing, Type()))
                            Me.msgErros = "Timeout de transmissão atingido"
                            gerar_evento_host("Timeout de transmissão atingido," & ", Class Webservice4: EnviarSefaz", "Webservice4S")
                    End Select
                    obj = Nothing

                End If
            Else
                obj = Nothing
            End If

        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Dim exception As Exception = ex
            NewLateBinding.LateSet(objRetCont, CType(Nothing, Type), "cstat", New Object(0) {CObj(9003)}, CType(Nothing, String()), CType(Nothing, Type()))
            NewLateBinding.LateSet(objRetCont, CType(Nothing, Type), "xmotivo", New Object(0) {CObj("Serviço fora de operação ou erro na conexão")}, CType(Nothing, String()), CType(Nothing, Type()))

            Me.msgErros = "Erro ao tentar enviar o xml ao sefaz => " & exception.Message & ""
            gerar_evento_host("Erro ao tentar enviar o xml ao sefaz => " & exception.Message & ", Class Webservice4: EnviarSefaz", "Webservice4S")

            obj = Nothing
            ProjectData.ClearProjectError()
        End Try

        Return obj
    End Function

    Private Sub mEnvioSefaz(ByVal xmlDoc As XmlDocument)
        Try
            Me.objRetornoWS = RuntimeHelpers.GetObjectValue(Me.objEnvioSefaz.[GetType]().GetMethod(Me.m_NomeMetodo).Invoke(RuntimeHelpers.GetObjectValue(Me.objEnvioSefaz), New Object(0) {CObj(xmlDoc)}))

            Me.XmlRetornoSefaz = New XmlDocument()
            Me.XmlRetornoSefaz.LoadXml(objRetornoWS.OuterXml)
            Me.XmlRetornoSefaz.Save(AppDomain.CurrentDomain.BaseDirectory & "\XML\RET.xml")

            If Me.objRetornoWS Is Nothing Then Return
            Me.iTipoRetTr = 1

        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Dim exception As Exception = ex
            gerar_evento_host("Falha ao tentar estabelecer conexão com o WebService" & ", Class Webservice4: mEnvioSefaz", "Webservice4S")
            Me.msgErros = exception.Message & ", Class Webservice4: mEnvioSefaz"
            Me.iTipoRetTr = 9
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Sub SetPropertyValue(ByVal instance As Object, ByVal propertyName As String, ByVal novoValor As Object)
        instance.[GetType]().GetProperty(propertyName, BindingFlags.Instance Or BindingFlags.[Public]).SetValue(RuntimeHelpers.GetObjectValue(instance), RuntimeHelpers.GetObjectValue(novoValor), CType(Nothing, Object()))
    End Sub

    Private Sub CreateAssembly(ByVal requestStream As Stream)
        Try
            Dim serviceDescription As ServiceDescription = serviceDescription.Read(requestStream)
            Dim descriptionImporter As ServiceDescriptionImporter = New ServiceDescriptionImporter()
            descriptionImporter.ProtocolName = "Soap12"
            descriptionImporter.AddServiceDescription(serviceDescription, CStr(Nothing), CStr(Nothing))
            descriptionImporter.Style = ServiceDescriptionImportStyle.Client
            descriptionImporter.CodeGenerationOptions = CodeGenerationOptions.GenerateProperties
            Dim codeNamespace As CodeNamespace = New CodeNamespace()
            Dim codeCompileUnit As CodeCompileUnit = New CodeCompileUnit()
            codeCompileUnit.Namespaces.Add(codeNamespace)
            Dim descriptionImportWarnings As ServiceDescriptionImportWarnings = descriptionImporter.Import(codeNamespace, codeCompileUnit)

            If descriptionImportWarnings = CType(0, ServiceDescriptionImportWarnings) Then
                Me.assemblyWS = CodeDomProvider.CreateProvider("CSharp").CompileAssemblyFromDom(New CompilerParameters(New String(3) {"System.dll", "System.Xml.dll", "System.Web.Services.dll", "System.Data.dll"}), codeCompileUnit)
            Else
                Me.assemblyWS = CType(Nothing, CompilerResults)
                Me.msgErros = descriptionImportWarnings.ToString()
            End If

        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Me.msgErros = ex.Message
            ProjectData.ClearProjectError()

            gerar_evento_host("Erro ao criar CreateAssembly => " & ex.Message & ", Class Webservice4: CreateAssembly", "Webservice4S")
        End Try
    End Sub
End Class




