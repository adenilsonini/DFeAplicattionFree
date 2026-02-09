
Imports System
Imports System.IO
Imports System.Web.Http
Imports System.Xml
Imports System.Data.SQLite
Imports System.Text

Public Class datahora_servidorController
    Inherits ApiController

   
    <HttpPost>
    <AcceptVerbs("POST")>
    Public Function Consulta(<FromBody> ByVal Arquivo As datahora_servidorController.DadosArquivo) As String
        Dim ret As String
        Dim data_web As New clsDateTime

        Try

            ''''''''''Rotina para gerar evento do seft Host'''''''''''''''''''''''''''''
            gerar_evento_host("Solicitacao Data e hora servidor do caixa: " & Arquivo.caixa, "datahora_servidor")

            '''''''''''''''''''''''''''''''''''''''''''''#############################''''''''''''''''''''''''''''''
            ret = data_web.GetNetworkTime.ToString()



            gerar_evento_host("Solicitacao retorno: " & ret, "datahora_servidor")

            Return ret

        Catch ex As Exception
            '  clsGeral.CriarLog("Erro: " & ex.Message, "TransportadorController", NameOf(Upload), False, True, False, False)

            Return "Ocorreu um ERRO: " & ex.Message & " No modulo datahora_servidor"

            gerar_evento_host("Ocorreu um ERRO: " & ex.Message & " No datahora_servidor", "datahora_servidor")

        End Try
    End Function

    Public Class DadosArquivo
        Public Property caixa As String
      
    End Class

End Class
