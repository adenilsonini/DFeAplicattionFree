Imports System.Security.Cryptography.X509Certificates
Imports System.Xml
Imports System.Text
Imports System.Drawing.Text
Imports System.IO
Imports System.Xml.Linq
Imports DFe_aplicativo.C_WebService

Public Class frmstatus
    Public urlstatus As String
    Public coduf As String

    Private Sub tstatus_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstatus.Tick
        lbltimer.Text = lbltimer.Text + 1

        If lbltimer.Text = "2" Then

            'cha a rotina para consulta nfe no sefaz mg
            Dim WebS As New C_WebService
            Dim status As New RetRetorno
            status = WebS.NfeStatusServico4("" & coduf & "", "" & urlstatus & "")

            If status.cStat = "107" Then
                MsgBox("Status do Sefaz: " & Chr(40) & status.xMotivo & Chr(41) & vbCrLf & _
                      "Versão do Aplicativo: " & Chr(40) & status.verAplic & Chr(41) & vbCrLf & "Tempo de Resposta: " & Chr(40) & status.tMed & "\s)", MsgBoxStyle.Information, "Retorno do sefaz")
                Label20.Text = "Nome Webservice"
            Else

                If status.xMotivo <> "" Then
                    MsgBox("Codigo Retorno: " & Chr(40) & status.cStat & Chr(41) & vbCrLf & "Status do Sefaz: " & Chr(40) & status.xMotivo & Chr(41), MsgBoxStyle.Information, "Retorno do sefaz")
                End If

                Label20.Text = "Nome Webservice"
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End If

        If lbltimer.Text = "3" Then
            tstatus.Dispose()
        End If

    End Sub

    Private Sub cboweb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboweb.SelectedIndexChanged
        If cboweb.Text = "Sefaz Minas Gerais - (MG)" Then
            coduf = "31"
            urlstatus = "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeStatusServico4"
        End If


        If cboweb.Text = "Sefaz Minas Gerais - (MG) NFCe" Then
            coduf = "31"
            urlstatus = "https://nfce.fazenda.mg.gov.br/nfce/services/NFeStatusServico4"
        End If

        If cboweb.Text = "Sefaz São Paulo - (SP)" Then
            coduf = "35"
            urlstatus = "https://nfe.fazenda.sp.gov.br/ws/nfestatusservico4.asmx"
        End If

        If cboweb.Text = "Sefaz Paraná - (PR)" Then
            coduf = "41"
            urlstatus = "https://nfe.sefa.pr.gov.br/nfe/NFeStatusServico4?wsdl"
        End If

        If cboweb.Text = "Sefaz Rio Grande do Sul - (RS)" Then
            coduf = "43"
            urlstatus = "https://nfe.sefazrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx"
        End If

        If cboweb.Text = "Sefaz Virtual Rio Grande do Sul - (SVRS)" Then
            coduf = "33"
            urlstatus = "https://nfe.svrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx"
        End If

        If cboweb.Text = "Sefaz Virtual Ambiente Nacional - (SVAN)" Then
            coduf = "21"
            urlstatus = "https://www.sefazvirtual.fazenda.gov.br/NFeStatusServico4/NFeStatusServico4.asmx"

        End If

        If cboweb.Text = "Sefaz Amazonas - (AM)" Then
            coduf = "13"
            urlstatus = "https://nfe.sefaz.am.gov.br/services2/services/NfeStatusServico4"
        End If

        If cboweb.Text = "Sefaz Bahia - (BA)" Then
            coduf = "29"
            urlstatus = "https://nfe.sefaz.ba.gov.br/webservices/NFeStatusServico4/NFeStatusServico4.asmx"

        End If

        If cboweb.Text = "Sefaz Ceará - (CE)" Then
            coduf = "23"
            urlstatus = "https://nfe.sefaz.ce.gov.br/nfe4/services/NFeStatusServico4?wsdl"

        End If

        If cboweb.Text = "Sefaz Goias - (GO)" Then
            coduf = "52"
            urlstatus = "https://nfe.sefaz.go.gov.br/nfe/services/NFeStatusServico4?wsdl"
        End If

        If cboweb.Text = "Sefaz Mato Grosso do Sul - (MS)" Then
            coduf = "50"
            urlstatus = "https://nfe.sefaz.ms.gov.br/ws/NFeStatusServico4"
        End If

        If cboweb.Text = "Sefaz Mato Grosso - (MT)" Then
            coduf = "51"
            urlstatus = "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeStatusServico4?wsdl"
        End If

        If cboweb.Text = "Sefaz Pernambuco - (PE)" Then
            coduf = "26"
            urlstatus = "https://nfe.sefaz.pe.gov.br/nfe-service/services/NFeStatusServico4"
        End If

        If cboweb.Text = "Sefaz Contingência (SVC-AN)" Then
            coduf = "31"
            urlstatus = "https://www.svc.fazenda.gov.br/NFeStatusServico4/NFeStatusServico4.asmx"
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub bntdownloadnfe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntdownloadnfe.Click
        Label20.Text = "Aguarde, Consulta do Status do Sefaz ..."
        If cboweb.Text = "" Then
            MsgBox("Informe a Sefaz do Web service ?", MsgBoxStyle.Exclamation, "Aviso !")
            Label20.Text = "Verifica o Status do webservice da SEFAZ"
            Exit Sub
        End If

        lbltimer.Text = "0"
        tstatus.Enabled = True
    End Sub

    Private Sub frmstatus_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub


End Class