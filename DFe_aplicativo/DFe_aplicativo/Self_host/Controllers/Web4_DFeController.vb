
Imports System
Imports System.IO
Imports System.Web.Http
Imports System.Xml
Imports System.Data.SQLite
Imports System.Text

Public Class Web4_DFeController
    Inherits ApiController

    Private LayoutNFCe As String = ""
    Private cpfcnpj As String = ""
    Private xmldoc = New XmlDocument()
    Private vlrNFCe As Decimal

    <HttpPost>
    <AcceptVerbs("POST")>
    Public Function Consulta(<FromBody> ByVal Arquivo As Web4_DFeController.DadosArquivo) As String
        Try


            Dim WebS As New C_WebService
            Dim retDistDFeInt As String

            Dim Retarquivo As Dictionary(Of String, String) = New Dictionary(Of String, String)
            gerar_evento_host("Solicitação serviço DFe", "dfe")

            retDistDFeInt = WebS.NFeDistribuicaoDFe4(Arquivo.cnpj, Arquivo.ambiente, Arquivo.cUF, Arquivo.ultNSU, Arquivo.chave, Arquivo.tipo_cons)

            ''''''''''Rotina para gerar evento do seft Host'''''''''''''''''''''''''''''
            If retDistDFeInt.Substring(0, 1) = "<" Then
                gerar_evento_host("Solicitação serviço DFe da UF:AN, SEFAZ Retornou: OK para serviço DFe", "dfe")
            End If
            '''''''''''''''''''''''''''''''''''''''''''''#############################''''''''''''''''''''''''''''''

            Return retDistDFeInt

        Catch ex As Exception
            '  clsGeral.CriarLog("Erro: " & ex.Message, "TransportadorController", NameOf(Upload), False, True, False, False)
            Return "Ocorreu um ERRO: " & ex.Message & ", No class Web4_DFeController"

            gerar_evento_host("Ocorreu um ERRO: " & ex.Message & ", No class Web4_DFeController", "dfe")
        End Try
    End Function

    Public Class DadosArquivo

        Public Property cnpj As String
        Public Property cUF As String
        Public Property ambiente As String
        Public Property ultNSU As String
        Public Property chave As String
        Public Property tipo_cons As String

    End Class

End Class
