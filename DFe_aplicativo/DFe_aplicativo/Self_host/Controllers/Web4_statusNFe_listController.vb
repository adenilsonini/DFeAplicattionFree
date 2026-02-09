
Imports System
Imports System.IO
Imports System.Web.Http
Imports System.Xml
Imports System.Data.SQLite
Imports System.Text

Public Class Web4_statusNFe_listController
    Inherits ApiController

    Private xmldoc = New XmlDocument()
    Private vlrNFCe As Decimal

    <HttpPost>
    <AcceptVerbs("POST")>
    Public Function Consulta(<FromBody> ByVal Arquivo As Web4_statusNFe_listController.DadosArquivo)
        Dim Retarquivo As Dictionary(Of String, String) = New Dictionary(Of String, String)

        Try

            Dim WebS As New C_WebService

            Dim retConsSitNFe As retConsSitNFe

            ''''''''''Rotina para gerar evento do seft Host'''''''''''''''''''''''''''''
            gerar_evento_host("Solicitação de consulta Protocolo NFe da chave acesso: " & Arquivo.nChave, "statusnfe")


            retConsSitNFe = WebS.ConsultaStatusNfe(Arquivo.nChave, Arquivo.ambiente)

            '''''''''''''''''''''''''''''''''''''''''''''#############################''''''''''''''''''''''''''''''

            gerar_evento_host("Solicitação de consulta Protocolo NFe, SEFAZ Retornou: " & retConsSitNFe.xMotivo & " - " & retConsSitNFe.xMotivo, "statusnfe")

            Retarquivo.Add("status", "ok")
            Retarquivo.Add("cStat", retConsSitNFe.cStat)
            Retarquivo.Add("xMotivo", retConsSitNFe.xMotivo)

            If retConsSitNFe.cStat = "100" Then

                Retarquivo.Add("chNFe", retConsSitNFe.chNFe)
                Retarquivo.Add("nProt", retConsSitNFe.protNFe.infProt.nProt)
                Retarquivo.Add("xMotivo2", retConsSitNFe.protNFe.infProt.xMotivo)
                Retarquivo.Add("dhRecbto", Convert.ToDateTime(retConsSitNFe.protNFe.infProt.dhRecbto).ToString("dd/MM/yyyy HH:mm:ss"))
                Retarquivo.Add("xml", retConsSitNFe.xmlprot)

            End If

            If retConsSitNFe.cStat = "101" Then

                Retarquivo.Add("chNFe", retConsSitNFe.chNFe)
                Retarquivo.Add("nProt", retConsSitNFe.procEventoNFe.retEvento.infEvento.nProt)
                Retarquivo.Add("xMotivo2", retConsSitNFe.procEventoNFe.retEvento.infEvento.xMotivo)
                Retarquivo.Add("dhRegEvento", Convert.ToDateTime(retConsSitNFe.procEventoNFe.retEvento.infEvento.dhRegEvento).ToString("dd/MM/yyyy HH:mm:ss"))
                Retarquivo.Add("xml", retConsSitNFe.xmlprocevent)

            End If

            '''''''''''''''''''''''''''''''''''''''''''''#############################''''''''''''''''''''''''''''''

            Return Retarquivo

        Catch ex As Exception
            '  clsGeral.CriarLog("Erro: " & ex.Message, "TransportadorController", NameOf(Upload), False, True, False, False)

            If reterro = "" Then
                Retarquivo.Add("status", "Ocorreu um ERRO: " & ex.Message & " No modulo Web4_statusNFeController")

                Return Retarquivo

                gerar_evento_host("Ocorreu um ERRO: " & ex.Message & " No modulo Web4_statusNFeController", "statusnfe")
            Else

                Retarquivo.Add("status", "Ocorreu um ERRO: " & reterro & " No modulo Web4_statusNFeController")

                Return Retarquivo

                gerar_evento_host("Ocorreu um ERRO: " & reterro & " No modulo Web4_statusNFeController", "statusnfe")
            End If
        End Try
    End Function

    Public Class DadosArquivo

        Public Property ambiente As String
        Public Property nChave As String


    End Class

End Class
