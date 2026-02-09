
Imports System
Imports System.IO
Imports System.Web.Http
Imports System.Xml
Imports System.Data.SQLite
Imports System.Text

Public Class Web4_statusController
    Inherits ApiController

    Private LayoutNFCe As String = ""
    Private cpfcnpj As String = ""
    Private xmldoc = New XmlDocument()
    Private vlrNFCe As Decimal

    <HttpPost>
    <AcceptVerbs("POST")>
    Public Function Consulta(<FromBody> ByVal Arquivo As Web4_statusController.DadosArquivo) As String
        Try


            Dim ws As Webservice4S
            Dim retConsStatServ As String

            Dim Retarquivo As Dictionary(Of String, String) = New Dictionary(Of String, String)

            Retarquivo = carrega_wsdl(Arquivo.tipo, Strings.UCase(Arquivo.UF), Arquivo.versao, Arquivo.modelo, Arquivo.ambiente)


            ''''''''''Rotina para gerar evento do seft Host'''''''''''''''''''''''''''''
            gerar_evento_host("Solicitação de consulta Status serviço da UF: " & Arquivo.UF & ", No ambiente: " & Arquivo.ambiente & ", Modelo: " & Arquivo.modelo, "statussef")
            '''''''''''''''''''''''''''''''''''''''''''''#############################''''''''''''''''''''''''''''''


            Arquivo.cUF = Retarquivo("coduf").ToString()
            ws = New Webservice4S(Retarquivo("url").ToString(), Retarquivo("name_space").ToString(), Retarquivo("NomeClasse").ToString(), Retarquivo("NomeMetodo").ToString(), Arquivo.versao, "ESTADO", certificado)

            'SefazWSUrls

            xmldoc.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><consStatServ versao=""" & Arquivo.versao & """ xmlns=""http://www.portalfiscal.inf.br/nfe""><tpAmb>1</tpAmb><cUF>" & Arquivo.cUF & "</cUF><xServ>STATUS</xServ></consStatServ>")
            retConsStatServ = ws.NFeStatusServico(xmldoc)

            Dim XmlRetornoSefaz = New XmlDocument()
            XmlRetornoSefaz.LoadXml(retConsStatServ)

            ''''''''''Rotina para gerar evento do seft Host'''''''''''''''''''''''''''''
            If retConsStatServ.Substring(0, 1) = "<" Then
                gerar_evento_host("Solicitação de consulta Status serviço da UF: " & Arquivo.UF & ", SEFAZ Retornou: OK para consulta", "statussef")
            End If
            '''''''''''''''''''''''''''''''''''''''''''''#############################''''''''''''''''''''''''''''''

            Return retConsStatServ
        Catch ex As Exception
            '  clsGeral.CriarLog("Erro: " & ex.Message, "TransportadorController", NameOf(Upload), False, True, False, False)
            Return "Ocorreu um ERRO: " & ex.Message & " No modulo Web4_statusController"

            gerar_evento_host("Ocorreu um ERRO: " & ex.Message & " No modulo Web4_statusController", "statussef")
        End Try
    End Function

    Public Class DadosArquivo
        Public Property tipo As String
        Public Property cUF As String
        Public Property ambiente As String
        Public Property modelo As String
        Public Property versao As String
        Public Property UF As String
        Public Property name_space As String
    End Class

End Class
