
Imports System
Imports System.IO
Imports System.Web.Http
Imports System.Xml
Imports System.Data.SQLite
Imports System.Text

Public Class Processar_vendasistController
    Inherits ApiController

    Private LayoutNFCe As String = ""
    Private cpfcnpj As String = ""
    Private xmldoc = New XmlDocument()
    Private vlrNFCe As Decimal

    <HttpPost>
    <AcceptVerbs("POST")>
    Public Function processar(<FromBody> ByVal Arquivo As Processar_vendasistController.DadosArquivo) As String
        Dim ret As String, caixa As String
        Try

            ''''''''''Rotina para gerar evento do seft Host'''''''''''''''''''''''''''''
            gerar_evento_host("Solicitacao de processamento venda...", "processarrv")

            '''''''''''''''''''''''''''''''''''''''''''''#############################''''''''''''''''''''''''''''''

            caixa = Arquivo.caixa
            caixa = caixa.PadLeft(3, "0")


            Dim path As String = Application.StartupPath & "\RX"
            If Not Directory.Exists(path) Then Directory.CreateDirectory(path)

            Using streamWriter As StreamWriter = New StreamWriter(String.Format(path & "\{0}", CObj(Arquivo.RV & "." & caixa)))
                streamWriter.WriteLine(Arquivo.Conteudo)
            End Using

            ret = Funcoes_sist.processar_venda(Arquivo.caixa, path & "\" & Arquivo.RV & "." & caixa)


            gerar_evento_host("Foi Recebido o arquivo: " & Arquivo.RV & " Retorno Processamento Banco dados: " & ret, "processarrv")

            Return ret

        Catch ex As Exception
            '  clsGeral.CriarLog("Erro: " & ex.Message, "TransportadorController", NameOf(Upload), False, True, False, False)
            If ret = "" Then
                Return "Ocorreu um ERRO: " & ex.Message & " No modulo processar RV"

                gerar_evento_host("Ocorreu um ERRO: " & ex.Message & " No modulo processar RV", "processarrv")
            Else
                Return "Ocorreu um ERRO: " & ret & " No Module Funcoes_sist"

                gerar_evento_host("Ocorreu um ERRO: " & ret & " No Module Funcoes_sist", "processarrv")
            End If
        End Try
    End Function

    Public Class DadosArquivo
        Public Property caixa As String
        Public Property Conteudo As String
        Public Property RV As String

    End Class

End Class
