Imports System.IO
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Threading
Imports MySql.Data.MySqlClient
Imports System.Text
Imports Microsoft.Win32
Imports System.Security.Cryptography.X509Certificates


Public Class frmparametro
    Dim caminho_nfexml As String
    Dim banco_backup As String
    Dim contb As Integer
    Dim hora As String
    Dim c_restore As String
    Dim optoreparo As String
    Dim oFileInfo As FileInfo
    Dim rs As New ADODB.Recordset
    Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")
    Dim dr As OdbcDataReader
    Dim conexao1 As OdbcConnection
    Private Sub frmparametro_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed



        ' Me.Dispose()
    End Sub

    Public Shared Sub CompactarMdb(caminhoMdb As String)

        '  Try

        Dim jetEngine As JRO.JetEngine = DirectCast(Activator.CreateInstance(Type.GetTypeFromProgID("JRO.JetEngine")), JRO.JetEngine)
        Dim arquivoTemporario = System.IO.Path.GetTempFileName()

        arquivoTemporario = System.IO.Path.ChangeExtension(arquivoTemporario, "mdb")

        Dim templateConnectionString As String = "Data Source={0};Provider=Microsoft.Jet.OLEDB.4.0;"
        Dim connectionStringFonte As String = String.Format(templateConnectionString, caminhoMdb)
        Dim connectionStringTemp As String = String.Format(templateConnectionString, arquivoTemporario)


        jetEngine.CompactDatabase(connectionStringFonte, connectionStringTemp)
        System.IO.File.Copy(arquivoTemporario, caminhoMdb, True)
        System.IO.File.Delete(arquivoTemporario)



        '  Catch ex As Exception
        'MsgBox(ex.Message)
        '  End Try
    End Sub

    Public Function compactaDB(ByVal origem_path As String, ByVal destino_path As String)

        Try

            Dim DB_origem As String, DB_destino As String
            Dim JRO As JRO.JetEngine
            JRO = New JRO.JetEngine


            DB_origem = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & origem_path
            DB_destino = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & destino_path & " ;Jet OLEDB:Engine Type=5"

            JRO.CompactDatabase(DB_origem, DB_destino)

            MsgBox("banco Reparado e compactado com Sucesso !", MsgBoxStyle.Information, "Aviso !")


        Catch ex As Exception

            MsgBox(Err.Description, vbExclamation)
        End Try

    End Function



    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        '  Define as propriedades do controle FolderBrowserDialog

        fbd1.Description = "Selecione uma pasta para realizar o XML NFe"
        fbd1.RootFolder = Environment.SpecialFolder.MyComputer
        fbd1.ShowNewFolderButton = True

        'Exibe a caixa de diálogo
        If fbd1.ShowDialog = Windows.Forms.DialogResult.OK Then

            'Exibe a pasta selecionada
            txtxml_nfe.Text = fbd1.SelectedPath

            arquivoIni.Write("caminho_xmlnfe", txtxml_nfe.Text, "DFe")
        End If
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click


        For Each nome As String In Directory.GetDirectories(txtxml_nfe.Text, "*")

            Try

                Directory.Delete(nome, False)

            Catch ex As Exception

            End Try
        Next

        MsgBox("Pastas Vazias deletadas !", MsgBoxStyle.Information, "Aviso !")
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim rsclisg As New ADODB.Recordset

        For Each nome As String In Directory.GetDirectories(txtxml_nfe.Text, "*")


            Dim DirDiretorio As DirectoryInfo = New DirectoryInfo(nome)
            Dim oFileInfoCollection() As FileInfo

            oFileInfoCollection = DirDiretorio.GetFiles("*.xml")

            For i As Integer = 0 To oFileInfoCollection.Length() - 1
                oFileInfo = oFileInfoCollection.GetValue(i)

                conectarsqlinx()
                rsclisg.Open("select * from cmd where nfe_chave like '" & oFileInfo.Name.ToString.Substring(0, oFileInfo.Name.ToString.Length - 4) & "'", cnsql, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

                If rsclisg.EOF = False Then
                    File.Delete(nome & "\" & oFileInfo.Name)
                End If

                cnsql.Close()

            Next


        Next

        MsgBox("Arquivos XML lancado no Sistema SGLinx deletados !", MsgBoxStyle.Information, "Aviso !")
    End Sub



    Private Sub Button8_Click(sender As Object, e As EventArgs)
        escreveINI(lerINI(Application.StartupPath & "\config.ini", "MANIFESTO_AUTOMATICO", "caminho_parametro"), "PARAMETRO", "ativar", "true")
        MsgBox("Comando executado com Sucesso !", MsgBoxStyle.Information, "Aviso !")
    End Sub




    Private Sub Button11_Click_2(sender As Object, e As EventArgs)

        Dim comando As OleDbCommand

        Dim sql As String

        conectar_ado()


        comando = New OleDbCommand("ALTER TABLE NFe_consultadaDFe ADD COLUMN Chave_NFe_ref TEXT(44)", cnado)
        comando.ExecuteNonQuery()

        '  sql = "SELECT COUNT(Chave_NFe_ref) AS RESULTADO FROM sefaz.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'NFe_consultadaDFe'"


        ' Dim da As New OleDbDataAdapter()
        '  da.SelectCommand = New OleDbCommand(sql, cnn)

        '   Dim dtp As New DataTable()
        '  da.Fill(dtp)


        '   If dtp.Rows.Count = "0" Then
        'MsgBox("ok")
        '   End If


        cnado.Close()


        MsgBox("Banco atualizado Com Sucesso !", MsgBoxStyle.Information, "Aviso !")
    End Sub

    Private Sub frmparametro_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        arquivoIni.Write("cnpj_cert_auto", "", "DFe")
        arquivoIni.Write("caminho_xmlnfe", txtxml_nfe.Text, "DFe")

    End Sub


    Private Sub frmparametro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtultnsucte_par.Text = frmdfe2.txtultnsucte.Text
        txtultnsudfe_par.Text = frmdfe2.txtultnsudfe.Text
        txttotal_reg.Text = frmdfe2.txttotal_reg.Text
        cboambdfe.Text = frmdfe2.cboambdfe.Text

        ler_par()

        pesquisa_tabela()

        ' txtdirmy.Text = MonitoramentoClienteServidor.RecuperaLocalMysqlData()

        txtip.Text = ip_mysql

        carregar_cert(certificado)

        ' certificados()
    End Sub

    Public Sub carregar_cert(ByVal cert As X509Certificate2)

        txtdatavenc.Text = cert.NotAfter.ToString
        txtdataemi.Text = cert.NotBefore.ToString
        txtrazao.Text = razao_cert(cert.SubjectName.Name)


        mskcnpjcert.Text = ExtrairCNPJ(cert)

        If mskcnpjcert.Text = "" Then
            mskcnpjcert.Text = ExtrairCPF(cert)
        End If

        '' criptografa()

        Dim dictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)

        dictionary = dados_cert_Dictionary(cert)
        txtemail.Text = dictionary("e-mail").ToString


        Dim wD2 As Long = DateDiff(DateInterval.Day, Now.Date, CDate(certificado.NotAfter.ToString))

        If wD2 <= 30 Then
            lblinfocert.BackColor = Color.Red
            lblinfocert.ForeColor = Color.White
        End If

        lblinfocert.Text = "Faltam " & wD2 & " dias para o certificado selecionado vencer"
    End Sub

    Public Function razao_cert(ByVal valor As String)
        valor = valor.Remove(0, 3)
        For i As Integer = 0 To valor.Length - 1

            If valor.Substring(i, 1) = "," Then
                valor = valor.Remove(i, valor.Length - i)
                Exit For
            End If
        Next
        Return valor
    End Function

    Private Sub parametro_sglinx()
        txtip_sglinx.Text = lerINI(Application.StartupPath & "\sglinear.ini", "SGLINX", "IP")
        chkverifica_sglinx.Checked = lerINI(Application.StartupPath & "\sglinear.ini", "SGLINX", "verifica_cad")
        chkcalc_preco.Checked = lerINI(Application.StartupPath & "\sglinear.ini", "FORMA_PRECO", "calc_preco")


    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        escreveINI(Application.StartupPath & "\sglinear.ini", "SGLINX", "IP", txtip_sglinx.Text)
        escreveINI(Application.StartupPath & "\sglinear.ini", "SGLINX", "verifica_cad", chkverifica_sglinx.Checked)
        escreveINI(Application.StartupPath & "\sglinear.ini", "FORMA_PRECO", "calc_preco", chkverifica_sglinx.Checked)

        MsgBox("Informações Salva Com Sucesso !", MsgBoxStyle.Information, "Aviso !")
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        frminfocertificado.carregar(certificado)

        frminfocertificado.ShowDialog()
    End Sub

    Private Sub ler_par()

        If arquivoIni.KeyExists("salva_xml_Plocal", "DFe") = False Then
            arquivoIni.Write("salva_xml_Plocal", "True", "DFe")
        End If
        chklocal.Checked = arquivoIni.Read("salva_xml_Plocal", "DFe")


        If arquivoIni.Read("salva_xml_Plocal", "DFe") = "True" Then
            txtxml_nfe.Text = Application.StartupPath & "\xml_tempRFB"
        End If

        If arquivoIni.KeyExists("cnpj_cert_auto", "DFe") = False Then
            arquivoIni.Write("cnpj_cert_auto", "", "DFe")
        End If
        mskcnpj.Text = arquivoIni.Read("cnpj_cert_auto", "DFe")

        If arquivoIni.KeyExists("execucao_automatico", "DFe") = False Then
            arquivoIni.Write("execucao_automatico", "", "DFe")
        End If

        If arquivoIni.Read("execucao_automatico", "DFe") = "True" Then
            optcontaprog.Checked = True

        Else
            optcontamanual.Checked = True
        End If

        If arquivoIni.KeyExists("intenvalotempo", "DFe") = False Then
            arquivoIni.Write("intenvalotempo", "false", "DFe")
        End If
        mskhoraprog.Text = arquivoIni.Read("intenvalotempo", "DFe")

        ' If arquivoIni.KeyExists("caminho_banco", "DFe") = False Then
        '   arquivoIni.Write("caminho_banco", "", "DFe")
        ' End If
        '  txtcaminho_bancoDfe.Text = arquivoIni.Read("caminho_banco", "DFe")

        If arquivoIni.KeyExists("caminho_xmlnfe", "DFe") = False Then
            arquivoIni.Write("caminho_xmlnfe", "", "DFe")
        End If
        txtxml_nfe.Text = arquivoIni.Read("caminho_xmlnfe", "DFe")

        If arquivoIni.KeyExists("IP", "SGLINX") = False Then
            arquivoIni.Write("IP", "127.1.1", "SGLINX")
        End If
        txtip_sglinx.Text = arquivoIni.Read("IP", "SGLINX")

        If arquivoIni.KeyExists("verifica_cad", "SGLINX") = False Then
            arquivoIni.Write("verifica_cad", "false", "SGLINX")
        End If
        chkverifica_sglinx.Checked = arquivoIni.Read("verifica_cad", "SGLINX")

        If arquivoIni.KeyExists("calc_preco", "SGLINX") = False Then
            arquivoIni.Write("calc_preco", "false", "SGLINX")
        End If
        chkverifica_sglinx.Checked = arquivoIni.Read("calc_preco", "SGLINX")

        If arquivoIni.KeyExists("caminho_banco_sql", "DFe") = False Then
            arquivoIni.Write("caminho_banco_sql", "", "DFe")
        End If
        txtbase_sql.Text = arquivoIni.Read("caminho_banco_sql", "DFe")



        If arquivoIni.KeyExists("Conferencia_ativa", "DFe_custoSG") = False Then
            arquivoIni.Write("Conferencia_ativa", "false", "DFe_custoSG")
        End If
        chkconf_custosg.Checked = arquivoIni.Read("Conferencia_ativa", "DFe_custoSG")


        If arquivoIni.KeyExists("Tela_conf_ativa", "DFe_custoSG") = False Then
            arquivoIni.Write("Tela_conf_ativa", "false", "DFe_custoSG")
        End If
        chktela_conf_ativa.Checked = arquivoIni.Read("Tela_conf_ativa", "DFe_custoSG")


        If arquivoIni.KeyExists("valor_dif", "DFe_custoSG") = False Then
            arquivoIni.Write("valor_dif", "0,10", "DFe_custoSG")
        End If
        txtvlrdif.Text = arquivoIni.Read("valor_dif", "DFe_custoSG")


    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dialodest As New OpenFileDialog
        dialodest.Filter = "Arquivo Sqlite (.db)|*.db"

        If dialodest.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtbase_sql.Text = Path.GetDirectoryName(dialodest.FileName)
            arquivoIni.Write("caminho_banco_sql", txtbase_sql.Text, "DFe")
        End If
    End Sub

    Private Sub mskhoraprog_LostFocus(sender As Object, e As EventArgs) Handles mskhoraprog.LostFocus
        arquivoIni.Write("intenvalotempo", mskhoraprog.Text, "DFe")
    End Sub


    Private Sub optcontaprog_Click(sender As Object, e As EventArgs) Handles optcontaprog.Click
        arquivoIni.Write("execucao_automatico", "True", "DFe")
    End Sub

    Private Sub optcontamanual_Click(sender As Object, e As EventArgs) Handles optcontamanual.Click
        arquivoIni.Write("execucao_automatico", "False", "DFe")
    End Sub

    Private Sub txtvlrdif_LostFocus(sender As Object, e As EventArgs) Handles txtvlrdif.LostFocus
        If txtvlrdif.Text = "" Then
            txtvlrdif.Text = "0,10"
        End If
        arquivoIni.Write("valor_dif", txtvlrdif.Text, "DFe_custoSG")

        vlrdifal = txtvlrdif.Text
    End Sub

    Private Sub CheckBox1_LostFocus(sender As Object, e As EventArgs) Handles chkconf_custosg.LostFocus
        arquivoIni.Write("Conferencia_ativa", chkconf_custosg.Checked, "DFe_custoSG")
        frmdfe2.chkcusto.Checked = chkconf_custosg.Checked
    End Sub

    Private Sub CheckBox2_LostFocus(sender As Object, e As EventArgs) Handles chktela_conf_ativa.LostFocus
        arquivoIni.Write("Tela_conf_ativa", chktela_conf_ativa.Checked, "DFe_custoSG")
    End Sub

    Private Sub txtultnsudfe_par_LostFocus(sender As Object, e As EventArgs) Handles txtultnsudfe_par.LostFocus
        If txtultnsudfe_par.Text = "" Then
            txtultnsudfe_par.Text = "000000000000000"
            frmdfe2.txtultnsudfe.Text = "000000000000000"
        Else
            frmdfe2.txtultnsudfe.Text = txtultnsudfe_par.Text
        End If
    End Sub

    Private Sub txtultnsucte_par_LostFocus(sender As Object, e As EventArgs) Handles txtultnsucte_par.LostFocus
        If txtultnsucte_par.Text = "" Then
            txtultnsucte_par.Text = "000000000000000"
            frmdfe2.txtultnsucte.Text = "000000000000000"
        Else
            frmdfe2.txtultnsucte.Text = txtultnsucte_par.Text
        End If
    End Sub

    Private Sub txttotal_reg_LostFocus(sender As Object, e As EventArgs) Handles txttotal_reg.LostFocus
        If txttotal_reg.Text = "" Then
            txttotal_reg.Text = "30"
            frmdfe2.txttotal_reg.Text = "30"
        Else
            frmdfe2.txttotal_reg.Text = txttotal_reg.Text
        End If

        If arquivoIni.KeyExists("total_reg_grid", "DFe") = False Then
            arquivoIni.Write("total_reg_grid", "30", "DFe")
        End If
        arquivoIni.Write("total_reg_grid", txttotal_reg.Text, "DFe")
    End Sub

    Private Sub cboambdfe_LostFocus(sender As Object, e As EventArgs) Handles cboambdfe.LostFocus
        If cboambdfe.Text = "" Then
            cboambdfe.SelectedIndex = 0
        End If
        frmdfe2.cboambdfe.Text = cboambdfe.Text
    End Sub


    Private Sub chkconf_custosg_CheckedChanged(sender As Object, e As EventArgs) Handles chkconf_custosg.CheckedChanged
        frmdfe2.chkcusto.Checked = chkconf_custosg.Checked
    End Sub

    Private Sub txtvlrdif_TextChanged(sender As Object, e As EventArgs) Handles txtvlrdif.TextChanged

    End Sub

    Private Sub chktela_conf_ativa_CheckedChanged(sender As Object, e As EventArgs) Handles chktela_conf_ativa.CheckedChanged
        If chktela_conf_ativa.Checked = True Then

            frmdfe2.btndifal.Visible = True
        Else

            frmdfe2.btndifal.Visible = False
        End If
    End Sub

    Private Sub chkxml_CheckedChanged(sender As Object, e As EventArgs) Handles chkxml.CheckedChanged

    End Sub

    Private Sub pesquisa_tabela()
        Dim conexao1 As OdbcConnection
        cbotable.Items.Clear()

        Dim sql As String = "select table_name from tables where table_schema = 'dfe'"



        conexao1 = New OdbcConnection("Driver={MySQL ODBC 3.51 Driver};Server=" & ip_mysql & ";Database=information_schema;uid=dfe;pwd=Pe$$w0rd1@;")
        conexao1.Open()

        Dim cmd As OdbcCommand = New OdbcCommand(sql, conexao1)
        Try

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        While (dr.Read())

            cbotable.Items.Add(dr("table_name"))

        End While

        dr.Close()

        conexao1.Close()

        conexao1 = Nothing



    End Sub

    Private Sub pesquisa_tabela_backup(ByVal banco As String)
        Dim conexao1 As OdbcConnection

        dgvbackup.Rows.Clear()
        Dim sql As String = "select table_name from tables where table_schema = '" & banco & "'"

        conexao1 = New OdbcConnection("Driver={MySQL ODBC 3.51 Driver};Server=" & ip_mysql & ";Database=information_schema;uid=adminlinear;pwd=@2013linear;")

        '  conexao1 = New OdbcConnection("Driver={MySQL ODBC 3.51 Driver};Server=" & ip_mysql & ";Database=information_schema;uid=dfe;pwd=Pe$$w0rd1@;")
        conexao1.Open()

        Dim cmd As OdbcCommand = New OdbcCommand(sql, conexao1)
        Try

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        While (dr.Read())
            dgvbackup.Rows.Add(dr("table_name"))
        End While

        dr.Close()

        conexao1.Close()

        conexao1 = Nothing



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtretbd.Text = ""
        txtretbd.Visible = True
        txtretbd.Text = "Aguarde, analisando tabela " & cbotable.Text & "..."
        txtretbd.Refresh()
        pic_info.Visible = True

        Try

            Control.CheckForIllegalCrossThreadCalls = False
            Dim rotina_dfe As New Thread(AddressOf analizar)
            rotina_dfe.SetApartmentState(ApartmentState.STA)
            rotina_dfe.Start()
        Catch ex As Exception
            txtretbd.Text = "Erro iniciar Rotina(analizar) " & ex.Message
        End Try


    End Sub

    Private Sub analizar()
        txtretbd.Text = "Retorno da analize: Tabela " & DB_mysql.TabelaSaudavel(cbotable.Text)
        pic_info.Visible = False
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If cbotable.Text = "" Then
            MsgBox("Informe o nome da tabela !", MsgBoxStyle.Exclamation, "Aviso !")
            cbotable.Focus()
            Exit Sub
        End If

        If cboopcao.Text = "" Then
            MsgBox("Informa a opção do reparo !", MsgBoxStyle.Exclamation, "Aviso !")
            cboopcao.Focus()
            Exit Sub
        End If

        txtretbd.Text = ""
        txtretbd.Visible = True
        txtretbd.Text = "Aguarde, Reparando Tabela " & cbotable.Text & "..."
        txtretbd.Refresh()
        pic_info.Visible = True


        Try

            Control.CheckForIllegalCrossThreadCalls = False
            Dim rotina_dfe As New Thread(AddressOf reparar)
            rotina_dfe.SetApartmentState(ApartmentState.STA)
            rotina_dfe.Start()
        Catch ex As Exception
            txtretbd.Text = "Erro iniciar Rotina(reparar) " & ex.Message
        End Try


    End Sub

    Private Sub reparar()
        txtretbd.Text = "Retorno da Reparo: Tabela " & DB_mysql.RepararTabela(cbotable.Text, optoreparo)
        pic_info.Visible = False
    End Sub
    Private Sub cboopcao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboopcao.SelectedIndexChanged

        If cboopcao.Text = "Rapido" Then
            optoreparo = "QUICK"
        End If
        If cboopcao.Text = "Estendido" Then
            optoreparo = "EXTENDED"
        End If
    End Sub

    Private Sub cboambdfe_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboambdfe.SelectedIndexChanged
        frmdfe2.cboambdfe.Text = cboambdfe.Text
    End Sub


    Private Sub mskcnpj_LostFocus(sender As Object, e As EventArgs) Handles mskcnpj.LostFocus
        arquivoIni.Write("cnpj_cert_auto", mskcnpj.Text, "DFe")
    End Sub

    Private Sub mskcnpj_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskcnpj.MaskInputRejected

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Try


            txtretbd.Text = "Realizando Backup do banco de dados...."
            txtretbd.Refresh()
            txtretbd.Visible = True
            pic_info.Visible = True
            Button6.Enabled = False

            Control.CheckForIllegalCrossThreadCalls = False
            Dim rotina_dfe As New Thread(AddressOf Backup_mysql)
            rotina_dfe.SetApartmentState(ApartmentState.STA)
            rotina_dfe.Start()
        Catch ex As Exception
            txtretbd.Text = "Erro iniciar Rotina(reparar) " & ex.Message
        End Try

    End Sub

    Public Sub Backup_mysql()
        Dim constring As String = "server=" & ip_mysql & ";user=dfe;pwd=Pe$$w0rd1@;database=dfe;"

        ' Important Additional Connection Options
        constring += "charset=utf8;convertzerodatetime=true;"

        Dim caminho As String = Application.StartupPath
        Dim CaminhoBackup As String = caminho & "\backup\" & Now.ToString("yyyy-MM-dd HH-mm-ss") & "dfe.sql"

        If Directory.Exists(caminho & "\backup") = False Then
            Directory.CreateDirectory(caminho & "\backup")
        End If


        Using connb As MySqlConnection = New MySqlConnection(constring)

            Using cmdd As MySqlCommand = New MySqlCommand()

                Using mb As MySqlBackup = New MySqlBackup(cmdd)
                    cmdd.Connection = connb
                    connb.Open()
                    cmdd.CommandTimeout = 0
                    mb.ExportToFile(CaminhoBackup)
                    connb.Close()
                End Using
            End Using
        End Using

        txtretbd.Visible = False
        pic_info.Visible = False
        Button6.Enabled = True
    End Sub

    Public Sub Restore_Backup()

        For Each row As DataGridViewRow In dgvrestore.Rows
            If row.Cells(0).Value = True Then
                dgvrestore.CurrentCell = row.Cells(0)
                row.Cells(2).Value = "Restorando Tabela no banco, aguarde..."

                Dim ret As String = Restore_Backup_mysql(row.Cells("caminho_arqgrid").Value)

                If ret.Substring(0, 4) = "True" Then
                    row.Cells(2).Value = "ok"
                Else
                    row.Cells(2).Value = ret
                End If

            End If
        Next

        Button10.Text = "Carregar Backup"

        MsgBox("Restauracao Concluida !", MsgBoxStyle.Information, "Aviso !")
    End Sub
    Public Function Restore_Backup_mysql(ByVal Caminhotabela As String) As String

        ' aumentar_tamanho_consulta()
        Try
            Dim constring As String = "server=" & ip_mysql & ";user=dfe;pwd=Pe$$w0rd1@;database=dfe;"

            ' Important Additional Connection Options
            constring += "charset=utf8;convertzerodatetime=true;"

            Using connb As MySqlConnection = New MySqlConnection(constring)

                Using cmdd As MySqlCommand = New MySqlCommand()

                    Using mb As MySqlBackup = New MySqlBackup(cmdd)
                        cmdd.Connection = connb
                        connb.Open()
                        cmdd.CommandTimeout = 0
                        mb.ImportFromFile(Caminhotabela)
                        connb.Close()
                    End Using
                End Using
            End Using

            Return "True"
            Button10.Enabled = True
        Catch ex As Exception
            Return "Erro na restauracao: " & ex.Message
        End Try

    End Function

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        dialogo.Filter = "Script SQL (*.sql)|*.sql"

        If dialogo.ShowDialog() = Windows.Forms.DialogResult.OK Then

            c_restore = dialogo.FileName

            Try


                txtretbd.Text = "Restaurando Backup do banco de dados, aguarde..."
                txtretbd.Refresh()
                txtretbd.Visible = True
                pic_info.Visible = True
                Button8.Enabled = False

                Control.CheckForIllegalCrossThreadCalls = False
                Dim rotina_dfe As New Thread(AddressOf Restore_Backup_mysql)
                rotina_dfe.SetApartmentState(ApartmentState.STA)
                rotina_dfe.Start()

            Catch ex As Exception
                txtretbd.Text = "Erro iniciar Rotina(reparar) " & ex.Message
            End Try

        End If
    End Sub

    Private Sub aumentar_tamanho_consulta()

        Dim connectionString As String = "server=" & ip_mysql & ";user=root;pwd=root;database=dfe;"
        Using conn As MySqlConnection = New MySqlConnection(connectionString)

            Using cmd As MySqlCommand = New MySqlCommand()
                cmd.Connection = conn
                conn.Open()
                cmd.CommandText = "SET GLOBAL max_allowed_packet=1024*1024*1024;"
                cmd.ExecuteNonQuery()

                ' Start to take effect here...
                ' Do something....

                conn.Close()
            End Using
        End Using


    End Sub


    Private Sub backup()
        Dim exportPath As StringBuilder = New StringBuilder()
        exportPath.Append(" > C:\Users\supermercado doka\Desktop\xml temp\backup.sql")
        Dim MySQLDump As Process = New Process()
        MySQLDump.StartInfo.UseShellExecute = True
        MySQLDump.StartInfo.FileName = "C:\Program Files\MySQL\MySQL Server 5.5\bin\mysqldump.exe"
        MySQLDump.StartInfo.Arguments = "-u root -p root -h localhost dfe caixa_cad" & exportPath.ToString
        MySQLDump.Start()
        MySQLDump.WaitForExit()
        MySQLDump.Close()


    End Sub

    Private Function backup_tab(ByVal tabela As String, ByVal hora As String) As String

        Dim constring As String = "server=" & ip_mysql & ";user=dfe;pwd=Pe$$w0rd1@;database=" & banco_backup & ";"
        '  If Not Program.TargetDirectoryIsValid() Then Return

        If Directory.Exists(Application.StartupPath & "\backup") = False Then
            Directory.CreateDirectory(Application.StartupPath & "\backup")
        End If

        If Directory.Exists(Application.StartupPath & "\backup\" & hora & "-" & banco_backup) = False Then
            Directory.CreateDirectory(Application.StartupPath & "\backup\" & hora & "-" & banco_backup)
        End If

        Dim file As String = Application.StartupPath & "\backup\" & hora & "-" & banco_backup & "\" & tabela & ".sql"

        Try
            Dim lst As List(Of String) = New List(Of String)()

            For Each row As DataGridViewRow In Me.dgvbackup.Rows

                If row.Cells(0).Value.ToString <> tabela Then

                    lst.Add(row.Cells(0).Value)

                End If

            Next

            Using conn As MySqlConnection = New MySqlConnection(constring)

                Using cmd As MySqlCommand = New MySqlCommand()

                    Using mb As MySqlBackup = New MySqlBackup(cmd)
                        cmd.Connection = conn
                        conn.Open()
                        cmd.CommandTimeout = 0
                        mb.ExportInfo.ExcludeTables = lst
                        mb.ExportToFile(file)
                    End Using
                End Using
            End Using

            Return "true"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Sub iniciar_backup()
        hora = Now.ToString("yyyy-MM-dd_HH_mm_ss")
        For Each row As DataGridViewRow In Me.dgvbackup.Rows
            row.Cells(1).Value = "Realizando Backup tabela, aguarde..."
            dgvbackup.CurrentCell = row.Cells(0)

            Dim ret As String = backup_tab(row.Cells(0).Value, hora)
            If ret = "true" Then
                row.Cells(1).Value = "ok"
            Else
                row.Cells(1).Value = "tabela não copiada, erro: " & ret
            End If

        Next

        Invoke(Sub() Panel3.Visible = True)
        Invoke(Sub() Timer1.Enabled = True)

        If verifica_winrar() = True Then
            compactar(Application.StartupPath & "\backup\" & hora & "-" & banco_backup, Application.StartupPath & "\backup\" & hora & "-" & banco_backup)
        End If

        dgvbackup.Rows.Clear()
        '  MsgBox("Backup realizado com Sucesso !", MsgBoxStyle.Information, "Aviso !")

    End Sub

    Private Sub bntbackup_Click(sender As Object, e As EventArgs) Handles bntbackup.Click
        dgvrestore.Visible = False
        chksel.Visible = False
        If chkbanco.Checked = True Then
            banco_backup = "sglinx"
        Else
            banco_backup = "dfe"
        End If

        pesquisa_tabela_backup(banco_backup)

        contb = 0
        Control.CheckForIllegalCrossThreadCalls = False
        Dim rotina_dfe As New Thread(AddressOf iniciar_backup)
        rotina_dfe.SetApartmentState(ApartmentState.STA)
        rotina_dfe.Start()
    End Sub

    Public Function verifica_winrar()

        If Directory.Exists("C:\Program Files\WinRAR") = False Then

            If Directory.Exists("C:\Program Files (x86)\WinRAR") = False Then
                MsgBox("Informação: é necessário instalar o aplicativo do WinRAR !", MsgBoxStyle.Exclamation, "Aviso !")
                Return False

                If MessageBox.Show("Deseja Instalar o WinRar 64 bits, " + vbCrLf + "Se optar por não sera Instalado o WinRar 32 Bits.", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Process.Start(Application.StartupPath & "\winrar-x64-53b4.exe")
                Else
                    Process.Start(Application.StartupPath & "\wrar53b4.exe")
                End If


            End If

        End If

        Return True
    End Function

    Private Sub compactar(inputfilename As String, outputfilename As String)
        Dim the_rar As String
        Dim the_Reg As RegistryKey
        Dim the_Obj As Object
        Dim the_Info As String
        Dim the_StartInfo As ProcessStartInfo
        Dim the_Process As Process
        Try
            the_Reg = Registry.ClassesRoot.OpenSubKey("WinRAR\shell\open\command")
            'for winrar path
            the_Obj = the_Reg.GetValue("")
            the_rar = the_Obj.ToString()
            the_Reg.Close()
            the_rar = the_rar.Substring(1, the_rar.Length - 7)
            the_Info = Convert.ToString((Convert.ToString("a -ep1" + " ") & outputfilename) + " " + " ") & inputfilename
            'i dare say for parameter
            the_StartInfo = New ProcessStartInfo()

            the_StartInfo.FileName = the_rar
            the_StartInfo.Arguments = the_Info
            the_StartInfo.WindowStyle = ProcessWindowStyle.Normal
            ' the_StartInfo.WorkingDirectory = workingfolder
            the_Process = New Process()
            the_Process.StartInfo = the_StartInfo
            the_Process.Start()
            'starting compress Process
            the_Process.Close()
            the_Process.Dispose()
        Catch
        End Try
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        contb += 1

        If contb >= 4 Then

            Dim processes As Process() = Process.GetProcessesByName("winrar")

            If processes.Length = 0 Then 'se for maior que 0 então existem processos com o nome X

                Invoke(Sub() Timer1.Dispose())
                Invoke(Sub() Timer1.Enabled = False)

                Directory.Delete(Application.StartupPath & "\backup\" & hora & "-" & banco_backup, True)

                MsgBox("Backup Realizado com sucesso !", MsgBoxStyle.Information, "Aviso !")

                Panel3.Visible = False

            End If

        End If


    End Sub



    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        If Button10.Text = "Importar Backup" Then
            Control.CheckForIllegalCrossThreadCalls = False
            Dim rotina_dfe As New Thread(AddressOf Restore_Backup)
            rotina_dfe.SetApartmentState(ApartmentState.STA)
            rotina_dfe.Start()
        End If

        If Button10.Text = "Carregar Backup" Then
            fbd1.Description = "Selecione uma pasta onde esta o backup"
            fbd1.RootFolder = Environment.SpecialFolder.MyComputer
            fbd1.ShowNewFolderButton = True

            'Exibe a caixa de diálogo
            If fbd1.ShowDialog = Windows.Forms.DialogResult.OK Then

                carregar_tabelas(New System.IO.DirectoryInfo(fbd1.SelectedPath))

                Button10.Text = "Importar Backup"

            End If


        End If


    End Sub

    Private Sub carregar_tabelas(folder As System.IO.DirectoryInfo)
        dgvrestore.Visible = True
        dgvrestore.Rows.Clear()
        chksel.Visible = True

        For Each fi As System.IO.FileInfo In folder.GetFiles

            dgvrestore.Rows.Add(False, fi.Name.Substring(0, fi.Name.Length - 4), "", fi.FullName)

        Next

        Button10.Text = "Importar Backup"
    End Sub

    Private Sub chksel_CheckedChanged(sender As Object, e As EventArgs) Handles chksel.CheckedChanged
        If chksel.Checked = True Then
            For Each row As DataGridViewRow In dgvrestore.Rows
                row.Cells(0).Value = True

            Next
        Else
            For Each row As DataGridViewRow In dgvrestore.Rows
                row.Cells(0).Value = False

            Next
        End If
    End Sub

    Private Sub TabPage3_Click(sender As Object, e As EventArgs) Handles TabPage3.Click
        dgvrestore.Visible = False
        chksel.Visible = False
    End Sub


    Private Sub certificados()
        Dim dr As MySqlDataReader
        Dim stringBuilder As StringBuilder = New StringBuilder()
        stringBuilder.Append("Select * from cert")

        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand

        SQLcommand = oConn.CreateCommand

        SQLcommand.CommandText = stringBuilder.ToString

        dr = SQLcommand.ExecuteReader()
        ' cbocert.Items.Clear()

        While (dr.Read())
            Dim senhac As String = Crypto.Decrypt2(dr("senha"))
            Dim bytes = TryCast(dr("cert_arq"), Byte())
            If Directory.Exists(Application.StartupPath & "\temp") = False Then
                Directory.CreateDirectory(Application.StartupPath & "\temp")
            End If
            File.WriteAllBytes(Application.StartupPath & "\temp\" & dr("cnpj") & ".pfx", bytes)
            Dim caminho As String = Application.StartupPath & "\temp\" & dr("cnpj") & ".pfx"

            Dim cert2 As New X509Certificate2(caminho, senhac, X509KeyStorageFlags.MachineKeySet)
            ' cbocert.Items.Add(razao_cert(cert2.SubjectName.Name))
            File.Delete(caminho)
        End While
    End Sub


    Private Sub chkxml_Click(sender As Object, e As EventArgs) Handles chkxml.Click
        frmdfe2.chkxml.Checked = chkxml.Checked
        arquivoIni.Write("salva_xmlpasta", chkxml.Checked, "MANIFESTO_AUTOMATICO")
    End Sub

    Private Sub chklocal_CheckedChanged(sender As Object, e As EventArgs) Handles chklocal.CheckedChanged

        If chklocal.Checked = True Then
            Button9.Enabled = False
            txtxml_nfe.Text = Application.StartupPath & "\xml_tempRFB"
            txtxml_nfe.Enabled = False

        Else

            txtxml_nfe.Enabled = True
            Button9.Enabled = True
            txtxml_nfe.Text = arquivoIni.Read("caminho_xmlnfe", "DFe")

        End If
    End Sub

    Private Sub chklocal_Click(sender As Object, e As EventArgs) Handles chklocal.Click

        arquivoIni.Write("salva_xml_Plocal", chklocal.Checked, "DFe")


    End Sub

    Private Sub txtultnsucte_par_TextChanged(sender As Object, e As EventArgs) Handles txtultnsucte_par.TextChanged

    End Sub

    Private Sub txttotal_reg_TextChanged(sender As Object, e As EventArgs) Handles txttotal_reg.TextChanged

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frm_licenca_linear.Show()
    End Sub
End Class