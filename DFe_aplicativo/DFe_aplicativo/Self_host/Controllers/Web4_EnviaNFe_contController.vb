
Imports System
Imports System.IO
Imports System.Web.Http
Imports System.Xml
Imports System.Data.SQLite
Imports System.Text

Public Class Web4_EnviaNFe_contController
    Inherits ApiController

    Private xmldoc = New XmlDocument()
    Private vlrNFCe As Decimal

    <HttpPost>
    <AcceptVerbs("POST")>
    Public Function enviaNFe(<FromBody> ByVal Arquivo As Web4_EnviaNFe_contController.DadosArquivo)
        Dim arquivoIni As ArquivoIni = New ArquivoIni(String.Format("{0}WS_Cofing.ini", CObj(AppDomain.CurrentDomain.BaseDirectory)))
        Dim xmldoc = New XmlDocument()
        Dim nrec As String
        Dim xmotivo As String = ""
        Dim ret2 As String

        '  Try

        Dim WebS As New C_WebService

        Dim retEnviNFe As retEnviNFe

        Dim retConsReciNFe As retConsReciNFe



        If Arquivo.nChave.Substring(34, 1) = "9" Then
            ''''''''''Rotina para envia xml para a SEFAZ'''''''''''''''''''''''''''''
            gerar_evento_host("Solicitação de recebimento arquivo xml contigencia, chave acesso: " & Arquivo.nChave, "envionfecont")

            xmldoc.LoadXml(gerar_xmlNFCe_envio(Arquivo.xml, Arquivo.ambiente))

            '   xmldoc.Save("C:\Users\adeni\OneDrive\Área de Trabalho\teste2\teste.xml")
            '''''''''''''''''''''''''''Salva info no banco''''''''''''''''''''''''''
            ret2 = Funcoes_sist.cfe(Arquivo.nChave, Arquivo.RV, xmldoc.OuterXml, Arquivo.ambiente, Arquivo.caixa, "Arquivo recebido em Contigencia", Arquivo.nChave.Substring(34, 1), "")

            Dim path As String = Application.StartupPath & "\CONTINGENCIA"

            If Not Directory.Exists(path) Then Directory.CreateDirectory(path)

            Using streamWriter As StreamWriter = New StreamWriter(String.Format(path & "\{0}", CObj(Arquivo.nChave & "-Contoff")))
                streamWriter.WriteLine(xmldoc.OuterXml)
            End Using

            gerar_evento_host("Retorno envio arquivo em contigencia, chave acesso: " & Arquivo.nChave & ", Processamento banco dados: " & ret2, "envionfecont")

        Else

            ''''''''''Rotina para envia xml para a SEFAZ'''''''''''''''''''''''''''''
            gerar_evento_host("Retorno envio arquivo Pendente, chave acesso: " & Arquivo.nChave & ", Processamento banco dados: " & ret2, "envionfecont")

            Funcoes_sist.cfe(Arquivo.nChave, Arquivo.RV, Arquivo.xml, Arquivo.ambiente, Arquivo.caixa, "Pendente, Sem retorno do servidor", Arquivo.nChave.Substring(34, 1), "")

        End If

        '''''''''''''''''''''''''''''''''''''''''''''#############################''''''''''''''''''''''''''''''

        Return "ok"

     
    End Function

    Public Class DadosArquivo
        Public Property ambiente As String
        Public Property xml As String
        Public Property nChave As String
        Public Property nRec As String
        Public Property RV As String
        Public Property caixa As String
    End Class

End Class
