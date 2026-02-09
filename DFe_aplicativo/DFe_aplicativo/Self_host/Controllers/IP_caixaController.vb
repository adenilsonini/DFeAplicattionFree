
Imports System
Imports System.IO
Imports System.Web.Http
Imports System.Xml
Imports System.Data.SQLite
Imports System.Text

Public Class IP_caixaController
    Inherits ApiController

    <HttpPost>
    <AcceptVerbs("POST")>
    Public Function Consulta(<FromBody> ByVal Arquivo As IP_caixaController.DadosArquivo) As String
        Dim ret As String
        Try

            ''''''''''Rotina para gerar evento do seft Host'''''''''''''''''''''''''''''
            gerar_evento_host("Solicitacao infomacao caixa IP", "ip")
            ret = Funcoes_sist.salvar_caixa(Arquivo.caixa, Arquivo.ip, Arquivo.serie)
          
            gerar_evento_host("Solicitacao retorno: " & ret, "ip")
            Return ret

        Catch ex As Exception
            '  clsGeral.CriarLog("Erro: " & ex.Message, "TransportadorController", NameOf(Upload), False, True, False, False)
            If ret = "" Then
                Return "Ocorreu um ERRO: " & ex.Message & " No modulo IP_caixa"

                gerar_evento_host("Ocorreu um ERRO: " & ex.Message & " No modulo IP_caixa", "ip")
            Else
                Return "Ocorreu um ERRO: " & ret & " No Module Funcoes_sist"

                gerar_evento_host("Ocorreu um ERRO: " & ret & " No Module Funcoes_sist", "ip")
            End If
        End Try
    End Function

    Public Class DadosArquivo
        Public Property caixa As String
        Public Property ip As String
        Public Property serie As String
    End Class

End Class
