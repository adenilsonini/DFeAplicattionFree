Imports DFe_aplicativo.C_WebService
Imports System.Threading
Imports System.Security.Cryptography.X509Certificates
Imports System.IO

Public Class frmwebservice
    Public nsu As String, ambiente As String, tipo_processo As String, chave As String
    Dim WebS As New C_WebService
    Dim rotina_dfe As Thread
    Dim tempo As Integer
    Private Sub frmwebservice_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If txterro.Text <> "" Then
            FrmDfe.txtinfodfe.Text = txterro.Text
            FrmDfe.CalcucarHora()
        End If
        Me.Dispose()
        FrmDfe.Activate()
    End Sub
    Private Sub frmwebservice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nsu = FrmDfe.txtultnsudfe.Text
        chave = FrmDfe.txtchavedfe.Text
        Control.CheckForIllegalCrossThreadCalls = False
        rotina_dfe = New Thread(AddressOf webservice_dfe)
        rotina_dfe.SetApartmentState(ApartmentState.STA)
        rotina_dfe.Start()
    End Sub

    Private Sub webservice_dfe()
        reterro = String.Empty

        '''''''''''''''''''chama a rotina para consulta nfe no sefaz mg''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''BUSCA URL''''''''''''
        WebS.url_webservice(BuscaURL("AN31", ambiente, False, ""))
        ''''''''''''''ATIVA WEBSERVICE'''''''''''''''

        WebS.NFeDistribuicaoDFe(cnpj_cert, "1", "31", nsu, chave, tipo_processo)

        If reterro <> "" Then
            txterro.Text = reterro
        End If

        Me.Close()

        FrmDfe.Activate()



        ''''o Tdfe_status do formulario dfe carrega o retorno''''''''''''''

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FrmDfe.Tdfe_status.Dispose()
        FrmDfe.txtinfodfe.Text = "Consulta cancelada pelo usuário em " & Now.ToString
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tempo += 1

        lbltimer_total.Text = tempo & "/s" & " - 60/s"
        lbltimer_total.Refresh()

        If tempo = 60 Then
            reterro = "Tempo de Retorno de 60/s foi excedido..."
            FrmDfe.txtinfodfe.Text = "Tempo de Retorno de 60/s foi excedido, operação cancelada às " & Now.ToString("dd-MM-yyyy HH:mm:ss")
            Me.Close()
        End If

    End Sub


End Class