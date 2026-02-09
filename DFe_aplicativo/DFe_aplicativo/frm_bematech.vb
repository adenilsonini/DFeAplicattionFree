Imports System.IO.Ports
Imports System.Threading
Imports System.Text
Imports System.Data.SQLite
Imports System.Xml

Public Class frm_bematech
    Dim dr As SQLiteDataReader
    Private Shared iRet As Integer
    Dim caminho_xml As String
    Private Sub imprimir_venda_aprazo()
        Dim porta As String = porta_imp()
        Dim thread As Thread = New Thread(AddressOf ImprimirXMLNFCeBematech.Imprimir_VENDA_PRAZO_Bematech)

        thread.Start(CObj(New List(Of String)() From {
            porta,
            DATA_COMP.Text,
            txtrv.Text,
            txtcliente.Text,
            txtcodcli.Text,
            mskcpf.Text,
            txtlimite.Text,
            txtvlr_venda.Text,
            mskData_venc.Text,
            txtend.Text,
        "SUPERMERCADO DOKA LTDA",
        txtconvenio.Text,
        txtpdv.Text
           }))

        iRetTrImp = 0


        While iRetTrImp = 0
            Dim num2 As Integer

            If num2 = 30 Then
                '  mdlGeral.CriarArquivoLog("TimeOut da thread esgotado. A thread vai ser abortada!", "", "", False, False, False)
                iRetTrImp = 9
                Exit While
            End If

            num2 += 1

            thread.Sleep(1000)
        End While

        If iRetTrImp = 9 Then
            ' mdlGeral.CriarArquivoLog("Ocorreu um erro ao tentar conexão com o WS!", "", "", False, False, False)
            thread.Abort()
        End If


        If iRetTrImp = 1 Then
            '  MsgBox("O impresso com Sucesso !", MsgBoxStyle.Information, "Aviso !")
        Else
            '  MsgBox("Ocorreu um erro na impressão !", MsgBoxStyle.Exclamation, "Aviso !")
        End If
    End Sub

    Private Sub imprimir()
        Dim xmldoc As New XmlDocument()
        Dim porta As String = porta_imp()
        LIMPAR()

        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\port_bematech.ini")
        If arquivoIni.KeyExists("porta", "Settings") = False Then
            arquivoIni.Write("porta", "COM2", "Settings")
        End If
        porta = arquivoIni.Read("porta", "Settings")

        DisparaInfo("Aguarde, Imprimindo Cupom...")

        conectar_sqlite_cfe()

        Dim SQLcommand As SQLiteCommand
        Dim sql As String = "SELECT * FROM DADOS_NFCe ORDER BY ID DESC limit 1"
        Dim rv As String, chave As String

        SQLcommand = Conn.CreateCommand

        SQLcommand.CommandText = sql

        dr = SQLcommand.ExecuteReader()


        While dr.Read()

            rv = dr("NRV")
            chave = dr("CHAVENFE")
            txtpdv.Text = dr("CAIXA")
        End While


        dr.Close()
        SQLcommand.Dispose()
        Conn.Close()

        Dim rs As New ADODB.Recordset
        Dim tab1 As String = "wslinear" & Now.ToString("MMyy") & "_arqs"
        sql = "select * FROM " & tab1 & " where chaveNFe ='" & chave & "'"

        conectarsqlinx()
        rs.Open(sql, cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockPessimistic)
        caminho_xml = Base64Decode(rs.Fields("XMLNFCE").Value.ToString)
        cnsql.Close()



        venda_aprazo(rv)

        cartao(rv)

        xmldoc.LoadXml(caminho_xml)

        Dim RE As Integer

        RE = ImprimirXMLVenda(xmldoc.InnerXml, "1", porta, 1)

        If txtcodcli.Text <> "" Then
            imprimir_venda_aprazo()
        End If

        If txtidstone.Text <> "" Then

            imprimir_cartao()

        End If

        If RE = 1 Then
            ' MsgBox("O DANFE da NFC-e foi impresso com Sucesso !", MsgBoxStyle.Information, "Aviso !")
        Else
            ' MsgBox("Ocorreu um erro na impressão do DANFE da NFC-e !", MsgBoxStyle.Exclamation, "Aviso !")
        End If

    End Sub

    Private Sub venda_aprazo(ByVal rv As String)
        conectar_sqlite_cfe()

        Dim SQLcommand As SQLiteCommand
        Dim sql As String = "SELECT * FROM VENDA_PRAZO where NRV  = '" & rv & "'"


        SQLcommand = Conn.CreateCommand

        SQLcommand.CommandText = sql

        dr = SQLcommand.ExecuteReader()


        While dr.Read()


            txtrv.Text = dr("NRV")
            DATA_COMP.Text = dr("DATA")
            txtconvenio.Text = "GERAL"
            txtlimite.Text = dr("CONVLIMITE")

            txtvlr_venda.Text = dr("CONVVALOR")
            txtcodcli.Text = dr("CONVCODINTERNO")
            txtcliente.Text = dr("CONVNOMECLI")

            mskcpf.Text = dr("CONVCNPJCPF")
            mskData_venc.Text = dr("CONVDATAVENC")
            txtend.Text = dr("CONVEND")
        End While

        dr.Close()
        SQLcommand.Dispose()
        Conn.Close()
    End Sub


    Private Sub cartao(ByVal rv As String)

        conectar_sqlite_cfe()

        Dim SQLcommand As SQLiteCommand
        Dim sql As String = "SELECT * FROM TEF where COO  = '" & rv & "'"


        SQLcommand = Conn.CreateCommand

        SQLcommand.CommandText = sql

        dr = SQLcommand.ExecuteReader()


        While dr.Read()


            txtbandeira.Text = dr("NOMEINSTITUICAO")

            mskdata.Text = dr("DATA")
            txtaut.Text = dr("AUTORIZATRANS")

            txtdoc.Text = dr("NSUSITEF") & dr("DATAHORATR")
            txtidstone.Text = dr("NSU")
            txttotal.Text = dr("VALORTEF")
            TXTHORA.Text = dr("DATAHORATR").ToString.Substring(dr("DATAHORATR").ToString.Length - 6, 2) & ":" & dr("DATAHORATR").ToString.Substring(dr("DATAHORATR").ToString.Length - 4, 2) & ":" & dr("DATAHORATR").ToString.Substring(dr("DATAHORATR").ToString.Length - 2, 2)

            txttipo.Text = dr("MODALIDADEDESC") & " APROVADO"

        End While

        dr.Close()
        SQLcommand.Dispose()
        Conn.Close()
    End Sub

    Private Sub LIMPAR()
        txtbandeira.Clear()
        mskdata.Text = ""
        txtaut.Clear()
        txtdoc.Clear()
        txtidstone.Clear()
        txttotal.Clear()
        txttipo.Clear()
        TXTHORA.Clear()

        DATA_COMP.Text = ""
        txtrv.Clear()
        txtcliente.Clear()
        txtcodcli.Clear()
        mskcpf.Text = ""
        txtlimite.Clear()
        txtvlr_venda.Clear()
        mskData_venc.Text = ""
        txtend.Clear()
        txtconvenio.Clear()
        txtpdv.Clear()
    End Sub

    Private Sub frm_bematech_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    End Sub
    Private Sub frm_bematech_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False
        status_impressora()

    End Sub

    Private Sub DisparaInfo(ByVal texto As String)
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon1.BalloonTipTitle = "informação!"
        NotifyIcon1.BalloonTipText = texto
        NotifyIcon1.ShowBalloonTip(1500)
        'Ou enviar a configuração em forma de argumentos:
        'NIcon.ShowBalloonTip(1500, "Excelente informação!", "Informo que estes balões são espectaculares!", ToolTipIcon.Info)
    End Sub
    Private Sub status_impressora()
        Dim porta As String = porta_imp()



        iRet = ImprimirXMLNFCeBematech.IniciaPorta(porta)

        If iRet = 1 Then
            ImprimirXMLNFCeBematech.FechaPorta()

            lblon.Visible = True
            picon.Visible = True

            lblof.Visible = False
            picoff.Visible = False

        Else

            lblof.Visible = True
            picoff.Visible = True

            lblon.Visible = False
            picon.Visible = False
        End If
    End Sub
    Private Sub imprimir_cartao()
        Dim porta As String = porta_imp()


        Dim thread As Thread = New Thread(AddressOf ImprimirXMLNFCeBematech.Imprimir_VENDA_CARTAO_Bematech)

        thread.Start(CObj(New List(Of String)() From {
            porta,
            DATA_COMP.Text,
            txtrv.Text,
            txtec.Text,
            txtaut.Text,
            txtdoc.Text,
            txtidstone.Text,
            txttotal.Text,
            txttipo.Text,
            "SUPERMERCADO DOKA LTDA",
            txtbandeira.Text,
            TXTHORA.Text,
            TXTPDV_CAR.Text
           }))

        iRetTrImp = 0



        While iRetTrImp = 0
            Dim num2 As Integer

            If num2 = 30 Then
                '  mdlGeral.CriarArquivoLog("TimeOut da thread esgotado. A thread vai ser abortada!", "", "", False, False, False)
                iRetTrImp = 9
                Exit While
            End If

            num2 += 1

            thread.Sleep(1000)
        End While


        If iRetTrImp = 1 Then
            ' MsgBox("O impresso com Sucesso !", MsgBoxStyle.Information, "Aviso !")
        Else
            ' MsgBox("Ocorreu um erro na impressão !", MsgBoxStyle.Exclamation, "Aviso !")
        End If
    End Sub


    Private Function porta_imp() As String
        Dim ports As String() = SerialPort.GetPortNames()
        Dim ret As Integer
        Dim porta As String

        ret = ImprimirXMLNFCeBematech.ConfiguraTaxaSerial(115200)

        For Each port As String In ports

            ret = ImprimirXMLNFCeBematech.IniciaPorta(port)

            If ret = 1 Then
                porta = port
                ImprimirXMLNFCeBematech.FechaPorta()
            End If

        Next

        Return porta
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        imprimir()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        status_impressora()
    End Sub

    Private Sub frm_bematech_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If (WindowState = FormWindowState.Minimized) Then
            Hide()
        End If
    End Sub

    Private Sub NotifyIcon1_Click(sender As Object, e As EventArgs) Handles NotifyIcon1.Click
        imprimir()
    End Sub

   
End Class