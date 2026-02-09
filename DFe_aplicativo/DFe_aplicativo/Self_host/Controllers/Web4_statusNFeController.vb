
Imports System
Imports System.IO
Imports System.Web.Http
Imports System.Xml
Imports System.Data.SQLite
Imports System.Text

Public Class Web4_statusNFeController
    Inherits ApiController

    Private xmldoc = New XmlDocument()
    Private vlrNFCe As Decimal

    <HttpPost>
    <AcceptVerbs("POST")>
    Public Function Consulta(<FromBody> ByVal Arquivo As Web4_statusNFeController.DadosArquivo) As String
        Try

            Dim WebS As New C_WebService

            Dim ret As String

            ret = WebS.ConsultaStatusNfe(Arquivo.nChave, Arquivo.ambiente, True)

            ''''''''''Rotina para gerar evento do seft Host'''''''''''''''''''''''''''''
            gerar_evento_host("Solicitação de consulta Protocolo NFe da chave acesso: " & Arquivo.nChave, "statusnfe")
            '''''''''''''''''''''''''''''''''''''''''''''#############################''''''''''''''''''''''''''''''

            If ret.Substring(0, 1) = "<" Then
                gerar_evento_host("Solicitação de consulta Protocolo NFe, SEFAZ Retornou: OK para Consulta", "statusnfe")
            End If
            '''''''''''''''''''''''''''''''''''''''''''''#############################''''''''''''''''''''''''''''''

            Return ret

        Catch ex As Exception
            '  clsGeral.CriarLog("Erro: " & ex.Message, "TransportadorController", NameOf(Upload), False, True, False, False)

            If reterro = "" Then
                Return "Ocorreu um ERRO: " & ex.Message & " No modulo Web4_statusNFeController"

                gerar_evento_host("Ocorreu um ERRO: " & ex.Message & " No modulo Web4_statusNFeController", "statusnfe")
            Else
                Return "Ocorreu um ERRO: " & reterro & " No modulo Web4_statusNFeController"

                gerar_evento_host("Ocorreu um ERRO: " & reterro & " No modulo Web4_statusNFeController", "statusnfe")
            End If
        End Try
    End Function

    Public Class DadosArquivo
        
        Public Property ambiente As String
        Public Property nChave As String


    End Class

End Class
