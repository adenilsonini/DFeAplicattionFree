
Imports System
Imports System.IO
Imports System.Web.Http
Imports System.Xml

Public Class TranspFileAsJSonController
    Inherits ApiController

    Private LayoutNFCe As String = ""
    Private cpfcnpj As String = ""
    Private xmlDoc As XmlDocument
    Private vlrNFCe As Decimal

    <HttpPost>
    <AcceptVerbs("POST")>
    Public Function Upload(<FromBody> ByVal Arquivo As TranspFileAsJSonController.DadosArquivo) As String
        Try

         
            If Arquivo.TipoArquivo = "ARQ_TRANS" Then

                Dim path As String = Application.StartupPath & "\PAST_DADOS"
                If Not Directory.Exists(path) Then Directory.CreateDirectory(path)

                Using streamWriter As StreamWriter = New StreamWriter(String.Format(path & "\{0}", CObj(Arquivo.NomeArq)))
                    streamWriter.WriteLine(Arquivo.Conteudo)
                End Using

                gerar_evento_host("Foi Recebido o arquivo: " & Arquivo.NomeArq & " Na Rotina ARQ_TRANS", "transarq")
            End If


            Return "OK"
        Catch ex As Exception
            '  clsGeral.CriarLog("Erro: " & ex.Message, "TransportadorController", NameOf(Upload), False, True, False, False)
            Return "Ocorreu um ERRO: " & ex.Message
            gerar_evento_host("Ocorreu um ERRO: " & ex.Message & " No modulo TranspFileAsJSonController", "transarq")
        End Try
    End Function

    Public Class DadosArquivo
        Public Property NomeArq As String
        Public Property Caixa As String
        Public Property Loja As String
        Public Property Conteudo As String
        Public Property TipoArquivo As String
        Public Property DataXml As String
        Public Property cStat As String
        Public Property xMotivo As String
        Public Property DataMov As String
    End Class
End Class
