Imports DFe_aplicativo.C_WebService

Module url_webservice
    Public UrlAcesso As ListaUrl

    Public Function BuscaURL(ByVal coduf As String, ByVal AmbienteNFe As Integer, contigencia As Boolean, nfce As String) As C_WebService.ListaUrl

        Dim UrlWs As C_WebService.ListaUrl = Nothing

        If contigencia = False Then

            Select Case coduf

                Case Is = "13"  'AC USA SEFAZ VIRTUAL DO RIO GRANDE DO SUL


                    If AmbienteNFe = "2" Then
                        UrlWs.UrlRecepcaoEvento = ""

                        UrlWs.UrlNFeAutorizacao = ""

                        UrlWs.UrlNFeRetAutorizacao = ""

                        UrlWs.UrlNfeInutilizacao = ""

                        UrlWs.UrlNfeConsultaProtocolo = ""

                        UrlWs.UrlNfeConsultaCadastro = ""

                        UrlWs.UrlNfeStatusServico = ""

                        UrlWs.CodigoUF = coduf
                    Else

                        UrlWs.UrlRecepcaoEvento = "https://nfe.sefaz.am.gov.br/services2/services/RecepcaoEvento"

                        UrlWs.UrlNFeAutorizacao = "https://nfe.sefaz.am.gov.br/services2/services/NfeAutorizacao"

                        UrlWs.UrlNFeRetAutorizacao = "https://nfe.sefaz.am.gov.br/services2/services/NfeRetAutorizacao"

                        UrlWs.UrlNfeInutilizacao = "https://nfe.sefaz.am.gov.br/services2/services/NfeInutilizacao2 "

                        UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefaz.am.gov.br/services2/services/NfeConsulta4"

                        UrlWs.UrlNfeConsultaCadastro = "https://nfe.sefaz.am.gov.br/services2/services/cadconsultacadastro2"

                        UrlWs.UrlNfeStatusServico = "https://nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"

                        UrlWs.CodigoUF = coduf
                    End If



                Case Is = "29" 'AC USA SEFAZ VIRTUAL DO RIO GRANDE DO SUL


                    If AmbienteNFe = "2" Then

                        UrlWs.UrlRecepcaoEvento = ""

                        UrlWs.UrlNFeAutorizacao = ""

                        UrlWs.UrlNFeRetAutorizacao = ""

                        UrlWs.UrlNfeInutilizacao = ""

                        UrlWs.UrlNfeConsultaProtocolo = ""

                        UrlWs.UrlNfeConsultaCadastro = ""

                        UrlWs.UrlNfeStatusServico = ""

                        UrlWs.CodigoUF = coduf

                    Else

                        UrlWs.UrlRecepcaoEvento = "https://nfe.sefaz.ba.gov.br/webservices/sre/recepcaoevento.asmx"

                        UrlWs.UrlNFeAutorizacao = "https://nfe.sefaz.ba.gov.br/webservices/NfeAutorizacao/NfeAutorizacao.asmx"

                        UrlWs.UrlNFeRetAutorizacao = "https://nfe.sefaz.ba.gov.br/webservices/NfeRetAutorizacao/NfeRetAutorizacao.asm"

                        UrlWs.UrlNfeInutilizacao = "https://nfe.sefaz.ba.gov.br/webservices/NfeInutilizacao/NfeInutilizacao.asmx"

                        UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefaz.ba.gov.br/webservices/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx"

                        UrlWs.UrlNfeConsultaCadastro = "https://nfe.sefaz.ba.gov.br/webservices/CadConsultaCadastro4/CadConsultaCadastro4.asmx"

                        UrlWs.UrlNfeStatusServico = "https://nfe.sefaz.ba.gov.br/webservices/NfeStatusServico/NfeStatusServico.asmx"

                        UrlWs.CodigoUF = coduf
                    End If



                Case Is = "23"


                    If AmbienteNFe = "2" Then

                        UrlWs.UrlRecepcaoEvento = ""

                        UrlWs.UrlNFeAutorizacao = ""

                        UrlWs.UrlNFeRetAutorizacao = ""

                        UrlWs.UrlNfeInutilizacao = ""

                        UrlWs.UrlNfeConsultaProtocolo = ""

                        UrlWs.UrlNfeConsultaCadastro = ""

                        UrlWs.UrlNfeStatusServico = ""

                        UrlWs.CodigoUF = coduf

                    Else

                        UrlWs.UrlRecepcaoEvento = "https://nfe.sefaz.ce.gov.br/nfe2/services/RecepcaoEvento?wsdl"

                        UrlWs.UrlNFeAutorizacao = "https://nfe.sefaz.ce.gov.br/nfe2/services/NfeAutorizacao?wsdl"

                        UrlWs.UrlNFeRetAutorizacao = "https://nfe.sefaz.ce.gov.br/nfe2/services/NfeRetAutorizacao?wsdl"

                        UrlWs.UrlNfeInutilizacao = "https://nfe.sefaz.ce.gov.br/nfe2/services/NfeConsulta2?wsdl"

                        UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefaz.ce.gov.br/nfe4/services/NFeConsultaProtocolo4?wsdl"

                        UrlWs.UrlNfeConsultaCadastro = "https://nfe.sefaz.ce.gov.br/nfe2/services/CadConsultaCadastro2?wsdl"

                        UrlWs.UrlNfeStatusServico = "https://nfe.sefaz.ce.gov.br/nfe2/services/NfeStatusServico2?wsdl"

                        UrlWs.CodigoUF = coduf
                    End If



                Case Is = "52"


                    If AmbienteNFe = "2" Then

                        UrlWs.UrlRecepcaoEvento = ""

                        UrlWs.UrlNFeAutorizacao = ""

                        UrlWs.UrlNFeRetAutorizacao = ""

                        UrlWs.UrlNfeInutilizacao = ""

                        UrlWs.UrlNfeConsultaProtocolo = ""

                        UrlWs.UrlNfeConsultaCadastro = ""

                        UrlWs.UrlNfeStatusServico = ""

                        UrlWs.CodigoUF = coduf

                    Else

                        UrlWs.UrlRecepcaoEvento = "https://nfe.sefaz.go.gov.br/nfe/services/v2/RecepcaoEvento?wsdl"

                        UrlWs.UrlNFeAutorizacao = "https://nfe.sefaz.go.gov.br/nfe/services/v2/NfeAutorizacao?wsdl"

                        UrlWs.UrlNFeRetAutorizacao = "https://nfe.sefaz.go.gov.br/nfe/services/v2/NfeRetAutorizacao?wsdl"

                        UrlWs.UrlNfeInutilizacao = "https://nfe.sefaz.go.gov.br/nfe/services/v2/NfeInutilizacao2?wsdl"

                        UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefaz.go.gov.br/nfe/services/NFeConsultaProtocolo4?wsdl"

                        UrlWs.UrlNfeConsultaCadastro = "https://nfe.sefaz.go.gov.br/nfe/services/v2/CadConsultaCadastro2?wsdl"

                        UrlWs.UrlNfeStatusServico = "https://nfe.sefaz.go.gov.br/nfe/services/v2/NfeStatusServico2?wsdl"

                        UrlWs.CodigoUF = coduf
                    End If



                Case Is = "31"


                    If AmbienteNFe = "2" Then

                        UrlWs.UrlRecepcaoEvento = "https://hnfe.fazenda.mg.gov.br/nfe2/services/RecepcaoEvento"

                        UrlWs.UrlNFeAutorizacao = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NfeAutorizacao"

                        UrlWs.UrlNFeRetAutorizacao = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NfeRetAutorizacao"

                        UrlWs.UrlNfeInutilizacao = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NfeInutilizacao2"

                        UrlWs.UrlNfeConsultaProtocolo = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NfeConsulta2"

                        UrlWs.UrlNfeConsultaCadastro = "https://hnfe.fazenda.mg.gov.br/nfe2/services/cadconsultacadastro2"

                        UrlWs.UrlNfeStatusServico = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NfeStatus2"

                        UrlWs.CodigoUF = coduf

                    Else

                        If nfce = 65 Then
                            UrlWs.UrlNfeConsultaProtocolo = "https://nfce.fazenda.mg.gov.br/nfce/services/NFeConsultaProtocolo4"

                            UrlWs.UrlNFeAutorizacao = "https://nfce.fazenda.mg.gov.br/nfce/services/NFeAutorizacao4"

                            UrlWs.UrlNFeRetAutorizacao = "https://nfce.fazenda.mg.gov.br/nfce/services/NFeRetAutorizacao4"

                            UrlWs.UrlRecepcaoEvento = "https://nfce.fazenda.mg.gov.br/nfce/services/NFeRecepcaoEvento4"

                        Else

                            UrlWs.UrlRecepcaoEvento = "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeRecepcaoEvento4"

                            UrlWs.UrlNFeAutorizacao = "https://nfe.fazenda.mg.gov.br/nfe2/services/NfeAutorizacao"

                            UrlWs.UrlNFeRetAutorizacao = "https://nfe.fazenda.mg.gov.br/nfe2/services/NfeRetAutorizacao"

                            UrlWs.UrlNfeInutilizacao = "https://nfe.fazenda.mg.gov.br/nfe2/services/NfeInutilizacao2"

                            UrlWs.UrlNfeConsultaProtocolo = "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeConsultaProtocolo4"

                            UrlWs.UrlNfeConsultaCadastro = "https://nfe.fazenda.mg.gov.br/nfe2/services/cadconsultacadastro2"

                            UrlWs.UrlNfeStatusServico = "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeStatusServico4"

                            UrlWs.UrlDownload = "https://nfe.fazenda.mg.gov.br/nfe2/services/NfeDownloadNF"

                        End If



                        UrlWs.CodigoUF = coduf
                    End If



                Case Is = "50"


                    If AmbienteNFe = "2" Then

                        UrlWs.UrlRecepcaoEvento = ""

                        UrlWs.UrlNFeAutorizacao = ""

                        UrlWs.UrlNFeRetAutorizacao = ""

                        UrlWs.UrlNfeInutilizacao = ""

                        UrlWs.UrlNfeConsultaProtocolo = ""

                        UrlWs.UrlNfeConsultaCadastro = ""

                        UrlWs.UrlNfeStatusServico = ""

                        UrlWs.CodigoUF = coduf

                    Else

                        UrlWs.UrlRecepcaoEvento = "https://nfe.fazenda.ms.gov.br/producao/services2/RecepcaoEvento"

                        UrlWs.UrlNFeAutorizacao = "https://nfe.fazenda.ms.gov.br/producao/services2/NfeAutorizacao"

                        UrlWs.UrlNFeRetAutorizacao = "https://nfe.fazenda.ms.gov.br/producao/services2/NfeRetAutorizacao"

                        UrlWs.UrlNfeInutilizacao = "https://nfe.fazenda.ms.gov.br/producao/services2/NfeInutilizacao2"

                        UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefaz.ms.gov.br/ws/NFeConsultaProtocolo4"

                        UrlWs.UrlNfeConsultaCadastro = "https://nfe.fazenda.ms.gov.br/producao/services2/CadConsultaCadastro2"

                        UrlWs.UrlNfeStatusServico = "https://nfe.fazenda.ms.gov.br/producao/services2/NfeStatusServico2"

                        UrlWs.CodigoUF = coduf
                    End If



                Case Is = "51"


                    If AmbienteNFe = "2" Then

                        UrlWs.UrlRecepcaoEvento = ""

                        UrlWs.UrlNFeAutorizacao = ""

                        UrlWs.UrlNFeRetAutorizacao = ""

                        UrlWs.UrlNfeInutilizacao = ""

                        UrlWs.UrlNfeConsultaProtocolo = ""

                        UrlWs.UrlNfeConsultaCadastro = ""

                        UrlWs.UrlNfeStatusServico = ""

                        UrlWs.CodigoUF = coduf

                    Else

                        UrlWs.UrlRecepcaoEvento = "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeRecepcao2?wsdl"

                        UrlWs.UrlNFeAutorizacao = "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeAutorizacao?wsdl"

                        UrlWs.UrlNFeRetAutorizacao = "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeRetAutorizacao?wsdl"

                        UrlWs.UrlNfeInutilizacao = "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeInutilizacao2?wsdl"

                        UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeConsulta4?wsdl"

                        UrlWs.UrlNfeConsultaCadastro = "https://nfe.sefaz.mt.gov.br/nfews/v2/services/CadConsultaCadastro2?wsdl"

                        UrlWs.UrlNfeStatusServico = "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeStatusServico2?wsdl"

                        UrlWs.CodigoUF = coduf
                    End If



                Case Is = "26"


                    If AmbienteNFe = "2" Then

                        UrlWs.UrlRecepcaoEvento = ""

                        UrlWs.UrlNFeAutorizacao = ""

                        UrlWs.UrlNFeRetAutorizacao = ""

                        UrlWs.UrlNfeInutilizacao = ""

                        UrlWs.UrlNfeConsultaProtocolo = ""

                        UrlWs.UrlNfeConsultaCadastro = ""

                        UrlWs.UrlNfeStatusServico = ""

                        UrlWs.CodigoUF = coduf

                    Else

                        UrlWs.UrlRecepcaoEvento = "https://nfe.sefaz.pe.gov.br/nfe-service/services/RecepcaoEventol"

                        UrlWs.UrlNFeAutorizacao = "https://nfe.sefaz.pe.gov.br/nfe-service/services/NfeAutorizacao?wsdl"

                        UrlWs.UrlNFeRetAutorizacao = "https://nfe.sefaz.pe.gov.br/nfe-service/services/NfeRetAutorizacao?wsdl"

                        UrlWs.UrlNfeInutilizacao = "https://nfe.sefaz.pe.gov.br/nfe-service/services/NfeInutilizacao2"

                        UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefaz.pe.gov.br/nfe-service/services/NFeConsultaProtocolo4"

                        UrlWs.UrlNfeConsultaCadastro = "https://nfe.sefaz.pe.gov.br/nfe-service/services/CadConsultaCadastro2"

                        UrlWs.UrlNfeStatusServico = "https://nfe.sefaz.pe.gov.br/nfe-service/services/NfeStatusServico2"

                        UrlWs.CodigoUF = coduf
                    End If



                Case Is = "41"


                    If AmbienteNFe = "2" Then

                        UrlWs.UrlRecepcaoEvento = ""

                        UrlWs.UrlNFeAutorizacao = ""

                        UrlWs.UrlNFeRetAutorizacao = ""

                        UrlWs.UrlNfeInutilizacao = ""

                        UrlWs.UrlNfeConsultaProtocolo = ""

                        UrlWs.UrlNfeConsultaCadastro = ""

                        UrlWs.UrlNfeStatusServico = ""

                        UrlWs.CodigoUF = coduf

                    Else

                        UrlWs.UrlRecepcaoEvento = "https://nfe.fazenda.pr.gov.br/nfe/NFeRecepcaoEvento?wsdl"

                        UrlWs.UrlNFeAutorizacao = "https://nfe.fazenda.pr.gov.br/nfe/NFeAutorizacao3?wsdl"

                        UrlWs.UrlNFeRetAutorizacao = "https://nfe.fazenda.pr.gov.br/nfe/NFeRetAutorizacao3?wsdl"

                        UrlWs.UrlNfeInutilizacao = "https://nfe.fazenda.pr.gov.br/nfe/NFeInutilizacao3?wsdl"

                        UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefa.pr.gov.br/nfe/NFeConsultaProtocolo4?wsdl"

                        UrlWs.UrlNfeConsultaCadastro = "https://nfe.fazenda.pr.gov.br/nfe/CadConsultaCadastro2?wsdl"

                        UrlWs.UrlNfeStatusServico = "https://nfe.fazenda.pr.gov.br/nfe/NFeStatusServico3?wsdl"

                        UrlWs.CodigoUF = coduf
                    End If


                Case Is = "43"


                    If AmbienteNFe = "2" Then

                        UrlWs.UrlRecepcaoEvento = "https://nfe-homologacao.sefazrs.rs.gov.br/ws/recepcaoevento/recepcaoevento.asmx"

                        UrlWs.UrlNFeAutorizacao = "https://nfe-homologacao.sefazrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao.asmx"

                        UrlWs.UrlNFeRetAutorizacao = "https://nfe-homologacao.sefazrs.rs.gov.br/ws/NfeRetAutorizacao/NFeRetAutorizacao.asmx"

                        UrlWs.UrlNfeInutilizacao = "https://nfe-homologacao.sefazrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao2.asmx"

                        UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefazrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx"

                        UrlWs.UrlNfeConsultaCadastro = "https://cad.sefazrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro2.asmx"

                        UrlWs.UrlNfeStatusServico = "https://nfe-homologacao.sefazrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico2.asmx"

                        UrlWs.CodigoUF = coduf

                    Else

                        UrlWs.UrlRecepcaoEvento = "https://nfe.sefazrs.rs.gov.br/ws/recepcaoevento/recepcaoevento.asmx"

                        UrlWs.UrlNFeAutorizacao = "https://nfe.sefazrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao.asmx"

                        UrlWs.UrlNFeRetAutorizacao = "https://nfe.sefazrs.rs.gov.br/ws/NfeRetAutorizacao/NFeRetAutorizacao.asmx"

                        UrlWs.UrlNfeInutilizacao = "https://nfe.sefazrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao2.asmx"

                        UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefazrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx"

                        UrlWs.UrlNfeConsultaCadastro = "https://cad.sefazrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx"

                        UrlWs.UrlNfeStatusServico = "https://nfe.sefazrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico2.asmx"

                        UrlWs.CodigoUF = coduf
                    End If



                Case Is = "35"


                    If AmbienteNFe = "2" Then

                        UrlWs.UrlRecepcaoEvento = "https://homologacao.nfe.fazenda.sp.gov.br/ws/recepcaoevento.asmx"

                        UrlWs.UrlNFeAutorizacao = "https://homologacao.nfe.fazenda.sp.gov.br/ws/nfeautorizacao.asmx"

                        UrlWs.UrlNFeRetAutorizacao = "https://homologacao.nfe.fazenda.sp.gov.br/ws/nferetautorizacao.asmx"

                        UrlWs.UrlNfeInutilizacao = "https://homologacao.nfe.fazenda.sp.gov.br/ws/nfeinutilizacao2.asmx"

                        UrlWs.UrlNfeConsultaProtocolo = "https://homologacao.nfe.fazenda.sp.gov.br/ws/nfeconsulta2.asmx"

                        UrlWs.UrlNfeConsultaCadastro = "https://homologacao.nfe.fazenda.sp.gov.br/ws/cadconsultacadastro2.asmx"

                        UrlWs.UrlNfeStatusServico = "https://homologacao.nfe.fazenda.sp.gov.br/ws/nfestatusservico2.asmx"

                        UrlWs.CodigoUF = coduf

                    Else

                        UrlWs.UrlRecepcaoEvento = "https://nfe.fazenda.sp.gov.br/ws/recepcaoevento.asmx"

                        UrlWs.UrlNFeAutorizacao = "https://nfe.fazenda.sp.gov.br/ws/nfeautorizacao.asmx"

                        UrlWs.UrlNFeRetAutorizacao = "https://nfe.fazenda.sp.gov.br/ws/nferetautorizacao.asmx"

                        UrlWs.UrlNfeInutilizacao = "https://nfe.fazenda.sp.gov.br/ws/nfeinutilizacao4.asmx"

                        UrlWs.UrlNfeConsultaProtocolo = "https://nfe.fazenda.sp.gov.br/ws/nfeconsultaprotocolo4.asmx"

                        UrlWs.UrlNfeConsultaCadastro = "https://nfe.fazenda.sp.gov.br/ws/cadconsultacadastro4.asmx"

                        UrlWs.UrlNfeStatusServico = "https://nfe.fazenda.sp.gov.br/ws/nfestatusservico4.asmx"

                        UrlWs.CodigoUF = coduf
                    End If


                Case Is = "15", "21", "22" 'Sefaz Virtual Ambiente Nacional - (SVAN)  


                    If AmbienteNFe = "2" Then

                        UrlWs.UrlRecepcaoEvento = "https://hom.sefazvirtual.fazenda.gov.br/RecepcaoEvento/RecepcaoEvento.asmx"

                        UrlWs.UrlNFeAutorizacao = "https://hom.sefazvirtual.fazenda.gov.br/NfeAutorizacao/NfeAutorizacao.asmx"

                        UrlWs.UrlNFeRetAutorizacao = "https://hom.sefazvirtual.fazenda.gov.br/NfeRetAutorizacao/NfeRetAutorizacao.asmx"

                        UrlWs.UrlNfeInutilizacao = "https://hom.sefazvirtual.fazenda.gov.br/NfeInutilizacao2/NfeInutilizacao2.asmx"

                        UrlWs.UrlNfeConsultaProtocolo = "https://hom.sefazvirtual.fazenda.gov.br/NfeConsulta2/NfeConsulta2.asmx"

                        UrlWs.UrlNfeStatusServico = "https://hom.sefazvirtual.fazenda.gov.br/NfeStatusServico2/NfeStatusServico2.asmx"

                        UrlWs.CodigoUF = coduf

                    Else


                        UrlWs.UrlRecepcaoEvento = "https://www.sefazvirtual.fazenda.gov.br/RecepcaoEvento/RecepcaoEvento.asmx"

                        UrlWs.UrlNFeAutorizacao = "https://www.sefazvirtual.fazenda.gov.br/NfeAutorizacao/NfeAutorizacao.asmx"

                        UrlWs.UrlNFeRetAutorizacao = "https://www.sefazvirtual.fazenda.gov.br/NfeRetAutorizacao/NfeRetAutorizacao.asmx"

                        UrlWs.UrlNfeInutilizacao = "https://www.sefazvirtual.fazenda.gov.br/NfeInutilizacao2/NfeInutilizacao2.asmx"

                        UrlWs.UrlNfeConsultaProtocolo = "https://www.sefazvirtual.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx"

                        UrlWs.UrlNfeStatusServico = "https://www.sefazvirtual.fazenda.gov.br/NfeStatusServico2/NfeStatusServico2.asmx"

                        UrlWs.CodigoUF = coduf
                    End If


                Case Is = "11", "12", "14", "16", "17", "24", "25", "27", "28", "32", "33", "42", "53" 'Sefaz Virtual Rio Grande do Sul - (SVRS)


                    If AmbienteNFe = "2" Then

                        UrlWs.UrlRecepcaoEvento = "https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento.asmx"

                        UrlWs.UrlNFeAutorizacao = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao.asmx"

                        UrlWs.UrlNFeRetAutorizacao = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeRetAutorizacao/NFeRetAutorizacao.asmx"

                        UrlWs.UrlNfeInutilizacao = "https://nfe-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao2.asmx"

                        UrlWs.UrlNfeConsultaProtocolo = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta2.asmx"

                        UrlWs.UrlNfeConsultaCadastro = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro2.asmx"

                        UrlWs.UrlNfeStatusServico = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico2.asmx"

                    Else

                        UrlWs.UrlRecepcaoEvento = "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento.asmx"

                        UrlWs.UrlNFeAutorizacao = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao.asmx"

                        UrlWs.UrlNFeRetAutorizacao = "https://nfe.svrs.rs.gov.br/ws/NfeRetAutorizacao/NFeRetAutorizacao.asmx"

                        UrlWs.UrlNfeInutilizacao = "https://nfe.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao2.asmx"

                        UrlWs.UrlNfeConsultaProtocolo = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx"

                        UrlWs.UrlNfeConsultaCadastro = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx"

                        UrlWs.UrlNfeStatusServico = "https://nfe.svrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico2.asmx"

                        UrlWs.CodigoUF = coduf

                    End If


                Case Is = "AN" & coduf.ToString.Substring(2, 2) '"AN Ambiente Nacional - (AN)"

                    If AmbienteNFe = "1" Then

                        UrlWs.UrlnfeConsultaNFDest = "https://www.nfe.fazenda.gov.br/NFeConsultaDest/NFeConsultaDest.asmx"
                        UrlWs.UrlRecepcaoEvento = "https://www.nfe.fazenda.gov.br/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx"
                        UrlWs.UrlDFe = "https://www1.nfe.fazenda.gov.br/NFeDistribuicaoDFe/NFeDistribuicaoDFe.asmx"
                        UrlWs.UrlDownload = "https://www.nfe.fazenda.gov.br/NfeDownloadNF/NfeDownloadNF.asmx"
                        UrlWs.CodigoUF = coduf.ToString.Substring(2, 2)

                    End If
            End Select


        End If

        '''''''''''''''''''''''''''Rotina para selecionar os webservice de contigencia'''''''''''''''''''''''''''''''''''''''''''''''''' 

        If contigencia = True Then

            Select Case coduf

                'Sefaz Virtual de Contingência Ambiente Nacional - (SVC-AN) 
                Case Is = "12", "27", "16", "53", "32", "31", "25", "33", "24", "11", "14", "43", "42", "28", "35", "17"


                    If AmbienteNFe = "2" Then

                        UrlWs.UrlRecepcaoEvento = "https://hom.svc.fazenda.gov.br/RecepcaoEvento/RecepcaoEvento.asmx"

                        UrlWs.UrlNFeAutorizacao = "https://hom.svc.fazenda.gov.br/NfeAutorizacao/NfeAutorizacao.asmx"

                        UrlWs.UrlNFeRetAutorizacao = "https://hom.svc.fazenda.gov.br/NfeRetAutorizacao/NfeRetAutorizacao.asmx"

                        UrlWs.UrlNfeConsultaProtocolo = "https://hom.svc.fazenda.gov.br/NfeConsulta2/NfeConsulta2.asmx"

                        UrlWs.UrlNfeStatusServico = "https://hom.svc.fazenda.gov.br/NfeStatusServico2/NfeStatusServico2.asmx"

                        UrlWs.CodigoUF = coduf

                    Else

                        UrlWs.UrlRecepcaoEvento = "https://www.svc.fazenda.gov.br/RecepcaoEvento/RecepcaoEvento.asmx"

                        UrlWs.UrlNFeAutorizacao = "https://www.svc.fazenda.gov.br/NfeAutorizacao/NfeAutorizacao.asmx"

                        UrlWs.UrlNFeRetAutorizacao = "https://www.svc.fazenda.gov.br/NfeRetAutorizacao/NfeRetAutorizacao.asmx"

                        UrlWs.UrlNfeConsultaProtocolo = "https://www.svc.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx"

                        UrlWs.UrlNfeStatusServico = "https://www.svc.fazenda.gov.br/NfeStatusServico2/NfeStatusServico2.asmx"

                        UrlWs.CodigoUF = coduf
                    End If




                    'Sefaz Virtual de Contingência Rio Grande do Sul - (SVC-RS)  "
                Case Is = "13", "29", "23", "52", "21", "50", "51", "15", "26", "22", "41"


                    If AmbienteNFe = "2" Then

                        UrlWs.UrlRecepcaoEvento = "https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento.asmx"

                        UrlWs.UrlNFeAutorizacao = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao.asmx"

                        UrlWs.UrlNFeRetAutorizacao = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeRetAutorizacao/NFeRetAutorizacao.asmx"

                        UrlWs.UrlNfeConsultaProtocolo = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta2.asmx"

                        UrlWs.UrlNfeStatusServico = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico2.asmx"

                        UrlWs.CodigoUF = coduf

                    Else


                        UrlWs.UrlRecepcaoEvento = "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento.asmx"

                        UrlWs.UrlNFeAutorizacao = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao.asmx"

                        UrlWs.UrlNFeRetAutorizacao = "https://nfe.svrs.rs.gov.br/ws/NfeRetAutorizacao/NFeRetAutorizacao.asmx"

                        UrlWs.UrlNfeConsultaProtocolo = "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx"

                        UrlWs.UrlNfeStatusServico = "https://nfe.svrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico2.asmx"

                        UrlWs.CodigoUF = coduf

                    End If

            End Select

        End If



        Return UrlWs
    End Function
End Module

