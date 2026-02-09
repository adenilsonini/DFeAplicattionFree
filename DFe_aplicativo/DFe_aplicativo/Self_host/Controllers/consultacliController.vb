
Imports System
Imports System.IO
Imports System.Web.Http
Imports System.Xml
Imports System.Data.SQLite
Imports System.Text

Public Class consultacliController
    Inherits ApiController

    Private LayoutNFCe As String = ""
    Private cpfcnpj As String = ""
    Private xmldoc = New XmlDocument()
    Private vlrNFCe As Decimal

    <HttpPost>
    <AcceptVerbs("POST")>
    Public Function Consulta(<FromBody> ByVal Arquivo As consultacliController.DadosArquivo)
        Dim Ret As Dictionary(Of String, String) = New Dictionary(Of String, String)

        Try

            ''''''''''Rotina para gerar evento do seft Host'''''''''''''''''''''''''''''

            gerar_evento_host("Solicitacao de venda aprazo feita pela caixa: " & Arquivo.caixa & ", para o cliente: " & Arquivo.nome_cli, "consultacli")
            Ret = Funcoes_sist.consulta_cli(Arquivo.cnpj_dest)
            '''''''''''''''''''''''''''''''''''''''''''''#############################''''''''''''''''''''''''''''''
            gerar_evento_host("Solicitacao retorno: " & Ret("status"), "consultacli")

            Return Ret

        Catch ex As Exception
            '  clsGeral.CriarLog("Erro: " & ex.Message, "TransportadorController", NameOf(Upload), False, True, False, False)
            If Ret("status") = "" Then
                Return "Ocorreu um ERRO: " & ex.Message & " No modulo consulta cli"

                gerar_evento_host("Ocorreu um ERRO: " & ex.Message & " No consulta cli", "consultacli")
            Else
                Return "Ocorreu um ERRO: " & Ret("status") & " Na Function consulta_cli"

                gerar_evento_host("Ocorreu um ERRO: " & Ret("status") & " Na Function consulta_cli", "consultacli")
            End If
        End Try
    End Function

    Public Class DadosArquivo
        Public Property caixa As String
        Public Property cnpj_dest As String
        Public Property nome_cli As String

    End Class

End Class
