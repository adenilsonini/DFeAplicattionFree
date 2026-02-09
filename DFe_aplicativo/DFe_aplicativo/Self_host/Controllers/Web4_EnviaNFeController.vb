
Imports System
Imports System.IO
Imports System.Web.Http
Imports System.Xml
Imports System.Data.SQLite
Imports System.Text

Public Class Web4_EnviaNFeController
    Inherits ApiController

    Private xmldoc = New XmlDocument()
    Private vlrNFCe As Decimal

    <HttpPost>
    <AcceptVerbs("POST")>
    Public Function enviaNFe(<FromBody> ByVal Arquivo As Web4_EnviaNFeController.DadosArquivo)
        Dim Retarquivo As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim xmldoc = New XmlDocument()
        Dim nrec As String
        Dim xmotivo As String = ""
        Dim errow As String = ""

        Try

            Dim WebS As New C_WebService

            Dim retEnviNFe As retEnviNFe

            Dim retConsReciNFe As retConsReciNFe

            ''''''''''Rotina para envia xml para a SEFAZ'''''''''''''''''''''''''''''
            gerar_evento_host("Solicitação de envio NFe, chave acesso: " & Arquivo.nChave, "envionfe")


            xmldoc.LoadXml(gerar_xmlNFCe_envio(Arquivo.xml, Arquivo.ambiente))


            '   xmldoc.Save("C:\Users\adeni\OneDrive\Área de Trabalho\teste2\teste.xml")
            '''''''''''''''''''''''''''Salva info no banco''''''''''''''''''''''''''
            Funcoes_sist.cfe(Arquivo.nChave, Arquivo.RV, Arquivo.xml, Arquivo.ambiente, Arquivo.caixa, "Arquivo recebido", "1", "")

            If Arquivo.nRec = "" Then
                Try

                    retEnviNFe = WebS.EnviaLote4(xmldoc, Arquivo.nChave, Arquivo.ambiente)

                    gerar_evento_host("Solicitação de envio NFe, SEFAZ Retornou: " & retEnviNFe.cStat & " - " & retEnviNFe.xMotivo & ", chave: " & Arquivo.nChave, "envionfe")

                    If Not retEnviNFe.infRec Is Nothing Then
                        If Not retEnviNFe.infRec.nRec Is Nothing Then
                            Retarquivo.Add("nRec", retEnviNFe.infRec.nRec)
                            nrec = retEnviNFe.infRec.nRec
                        End If
                    Else

                        xmotivo = retEnviNFe.cStat & "-" & retEnviNFe.xMotivo
                        gerar_evento_host("Retorno da SEFAZ do envio: " & retEnviNFe.cStat & "-" & retEnviNFe.xMotivo, "envionfe")
                        Funcoes_sist.cfe(Arquivo.nChave, Arquivo.RV, "", Arquivo.ambiente, Arquivo.caixa, retEnviNFe.xMotivo, retEnviNFe.cStat, "")

                    End If


                    '''''''''''''''''''''''''''Salva info no banco''''''''''''''''''''''''''
                    Funcoes_sist.cfe(Arquivo.nChave, Arquivo.RV, "", Arquivo.ambiente, Arquivo.caixa, "Arquivo enviado", Arquivo.ambiente, nrec)

                Catch ex As Exception
                    If reterro = "" Then
                        errow = "Erro Modulo envio:" & ex.Message
                        gerar_evento_host("Erro Modulo envio:" & ex.Message, "envionfe")
                    Else
                        errow = "Erro Modulo Webservice4 envio:" & reterro
                        gerar_evento_host("Erro Modulo Webservice4 envio:" & reterro, "envionfe")
                    End If
                    erro = True
                End Try

            Else
                nrec = Arquivo.nRec
                Retarquivo.Add("nRec", Arquivo.nRec)
            End If


            If xmotivo <> "" Then
                Retarquivo.Add("status", xmotivo)
                Return Retarquivo
                Exit Function
            End If

            '''''''''''''''''''''''''''''''''''''''''''''#############################''''''''''''''''''''''''''''''

            If xmotivo = "" Then


                If nrec <> "" Then

                    gerar_evento_host("Solicitação de Consulta envio NFe, N° Recibo " & nrec, "Retenvionfe")

                    Try

                        ''''''''''Rotina para consultar retorno envia xml para a SEFAZ'''''''''''''''''''''''''''''
                        retConsReciNFe = WebS.ConsultaRecLote(nrec, Arquivo.ambiente, Arquivo.nChave)

                        If retConsReciNFe.cStat = "104" Then


                            If retConsReciNFe.protNFe.infProt.cStat = "100" Then
                                Dim dados As XmlDocument = New XmlDocument
                                dados = GerarNotaProcessadanfce(SepararNota_prot34(xmldoc.OuterXml), retConsReciNFe.xmlprot)
                                '''''''''''''''''''''''''''Salva info no banco''''''''''''''''''''''''''
                                Funcoes_sist.cfe(Arquivo.nChave, Arquivo.RV, dados.OuterXml, Arquivo.ambiente, Arquivo.caixa, retConsReciNFe.protNFe.infProt.xMotivo, retConsReciNFe.protNFe.infProt.cStat, "")

                                Retarquivo.Add("xml", dados.OuterXml)

                                Retarquivo.Add("cStat", retConsReciNFe.protNFe.infProt.cStat)
                                Retarquivo.Add("xMotivo", retConsReciNFe.protNFe.infProt.xMotivo)
                                Retarquivo.Add("chNFe", retConsReciNFe.protNFe.infProt.chNFe)
                                Retarquivo.Add("nProt", retConsReciNFe.protNFe.infProt.nProt)
                                Retarquivo.Add("dhRecbto", Convert.ToDateTime(retConsReciNFe.protNFe.infProt.dhRecbto).ToString("dd/MM/yyyy HH:mm:ss"))


                                gerar_evento_host("Retorno Solicitação de Consulta envio NFe: " & retConsReciNFe.protNFe.infProt.cStat & " - " & retConsReciNFe.protNFe.infProt.xMotivo, "Retenvionfe")

                                '''''''''''''''''''''Salvar arquivo ma pasta''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                                Dim Path As String = Application.StartupPath & "\NFCe"
                                If Not Directory.Exists(Path) Then Directory.CreateDirectory(Path)

                                dados.Save(Path & "\NFCe-" & retConsReciNFe.protNFe.infProt.chNFe & ".xml")

                            Else

                                If retConsReciNFe.protNFe.infProt.cStat = "204" Then

                                    Dim nPost As Int32 = retConsReciNFe.protNFe.infProt.xMotivo.IndexOf("nRec:")
                                    Dim rec As String = retConsReciNFe.protNFe.infProt.xMotivo.Substring(nPost + 5, retConsReciNFe.protNFe.infProt.xMotivo.Length - nPost - 6).Trim
                                    Retarquivo.Add("RecDup", rec)

                                End If

                                Retarquivo.Add("cStat", retConsReciNFe.protNFe.infProt.cStat)
                                Retarquivo.Add("xMotivo", retConsReciNFe.protNFe.infProt.xMotivo)

                                '''''''''''''''''''''''''''Salva info no banco''''''''''''''''''''''''''
                                Funcoes_sist.cfe(Arquivo.nChave, Arquivo.RV, "", Arquivo.ambiente, Arquivo.caixa, retConsReciNFe.protNFe.infProt.xMotivo, retConsReciNFe.protNFe.infProt.cStat, "")

                            End If

                        Else

                            Retarquivo.Add("cStat", retConsReciNFe.cStat)
                            Retarquivo.Add("xMotivo", retConsReciNFe.xMotivo)
                            gerar_evento_host("Retorno Solicitação de Consulta enviado NFe: " & retConsReciNFe.cStat & " - " & retConsReciNFe.xMotivo & ", chave: " & Arquivo.nChave, "Retenvionfe")
                            Funcoes_sist.cfe(Arquivo.nChave, Arquivo.RV, "", Arquivo.ambiente, Arquivo.caixa, retConsReciNFe.xMotivo, retConsReciNFe.cStat, "")

                        End If

                        Retarquivo.Add("status", "ok")

                    Catch ex As Exception

                        If reterro = "" Then
                            errow = errow & " Erro Modulo Retenvio:" & ex.Message
                            gerar_evento_host("Solicitação de Consulta envio NFe, SEFAZ Retornou: " & "Erro Modulo Retenvio:" & ex.Message, "Retenvionfe")
                        Else
                            errow = errow & " Erro Modulo Retenvio:" & reterro
                            gerar_evento_host("Solicitação de Consulta envio NFe, SEFAZ Retornou: " & "Erro Modulo Webservice4 Retenvio:" & reterro, "Retenvionfe")
                        End If

                    End Try

                Else

                    Retarquivo.Add("cStat", retEnviNFe.cStat)
                    Retarquivo.Add("xMotivo", retEnviNFe.xMotivo)

                    Funcoes_sist.cfe(Arquivo.nChave, Arquivo.RV, "", Arquivo.ambiente, Arquivo.caixa, retEnviNFe.xMotivo, retEnviNFe.cStat, "")

                End If

            End If


            '''''''''''''''''''''''''''''''''''''''''''''#############################''''''''''''''''''''''''''''''

            Return Retarquivo

        Catch ex As Exception


            If reterro = "" Then
                Retarquivo.Add("status", errow & " Ocorreu um ERRO: " & ex.Message & " No modulo Web4_EnviaNFeController")

                Return Retarquivo

                gerar_evento_host("Ocorreu um ERRO: " & ex.Message & " No modulo Web4_EnviaNFeController", "envionfe")
            Else

                Retarquivo.Add("status", errow & " Ocorreu um ERRO: " & reterro & " No modulo Webservice4")

                Return Retarquivo

                gerar_evento_host("Ocorreu um ERRO: " & reterro & " No modulo Webservice4", "envionfe")
            End If
        End Try
    End Function

    Public Class DadosArquivo

        Public Property ambiente As String
        Public Property tipo As String
        Public Property xml As String
        Public Property nChave As String
        Public Property nRec As String
        Public Property RV As String
        Public Property caixa As String
    End Class

End Class
