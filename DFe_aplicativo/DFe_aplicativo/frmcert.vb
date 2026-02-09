Imports System.Text
Imports System.Data.SQLite
Imports System.Security.Cryptography.X509Certificates
Imports System.Windows.Forms
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmcert
    Public tipoCertA3 = False
    Public par As String = False
    Dim caminho As String, senhac As String, data As String

    Private Sub frmcert_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        If par = False Then
            End
        End If

    End Sub
    Private Sub frmcert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim unc As String = Application.StartupPath.Substring(0, 3)
        ' Dim proc As Process

        '   For Each proc In process.GetProcesses
        'If proc.ProcessName = "mysqld-nt" Then
        'proc.Kill()
        '   End If
        '   Next


        '   Exit Sub



        '     Exit Sub

        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")
        '  Dim ip_mysql As String = arquivoIni.Read("ip_mysql", "DFe")


        '  If ip_mysql = "127.0.0.1" Then
        'Dim processes22 As Process() = Process.GetProcessesByName("mysqld-nt")

        ' If processes22.Length <> 0 Then
        'Dim proc As Process

        ' For Each proc In Process.GetProcesses
        'If proc.ProcessName = "mysqld-nt" Then
        'proc.Kill()
        '  End If
        '  Next
        '  End If

        '  End If
        ' Try
        '    If ip_mysql = "127.0.0.1" Then
        'Dim processes2 As Process() = Process.GetProcessesByName("mysqld-nt")
        '    If processes2.Length = 0 Then 'se for maior que 0 então existem processos com o nome X
        '       Using myProcess As Process = New Process()
        '  myProcess.StartInfo.UseShellExecute = False
        'myProcess.StartInfo.FileName = Application.StartupPath & "\mysql\bin\mysqld-nt.exe"
        '   myProcess.StartInfo.CreateNoWindow = True
        '   myProcess.Start()

        '     End Using
        '
        '  End If
        '  End If
        '  '  Catch ex As Exception

        '  End Try




        '' Dim processes As Process() = Process.GetProcessesByName("DFe_aplicativo")

        '' If processes.Length > 1 Then 'se for maior que 0 então existem processos com o nome X

        ''MsgBox("O aplicativo já está aberto !", MsgBoxStyle.Information, "Aviso !")
        '' End

        ''  End If




        If arquivoIni.KeyExists("tela_direta", "DFe") = False Then
            arquivoIni.Write("tela_direta", "false", "DFe")
        End If

        If arquivoIni.KeyExists("cnpj_cert_auto", "DFe") = False Then
            arquivoIni.Write("cnpj_cert_auto", "", "DFe")
        End If


        If arquivoIni.Read("tela_direta", "DFe") = "True" Then
            If arquivoIni.Read("cnpj_cert_auto", "DFe") <> "" Then
                empresa.sCNPJ = arquivoIni.Read("cnpj_cert_auto", "DFe")


                ''''''''''''''''''''''Rotina abaixo buscar cetificado''''''''''''''''''''''''''
                conectar_mysqlDFe()

                Dim SQLcommand As MySqlCommand

                SQLcommand = oConn.CreateCommand

                SQLcommand.CommandText = "Select * from cert where cnpj = '" & empresa.sCNPJ & "'"

                dr = SQLcommand.ExecuteReader()


                While (dr.Read())
                    senhac = Crypto.Decrypt2(dr("senha"))
                    data = dr("Data_venc")
                    If File.Exists(Application.StartupPath & "\cert\" & dr("cnpj") & Convert.ToDateTime(dr("Data_venc")).ToString("yyyy") & ".pfx") = False Then
                        Dim bytes = TryCast(dr("cert_arq"), Byte())
                        File.WriteAllBytes(Application.StartupPath & "\cert\" & dr("cnpj") & Convert.ToDateTime(dr("Data_venc")).ToString("yyyy") & ".pfx", bytes)
                    End If

                    caminho = Application.StartupPath & "\cert\" & dr("cnpj") & Convert.ToDateTime(dr("Data_venc")).ToString("yyyy") & ".pfx"
                End While

                senha_cert = senhac
                Dim cnpj_grid2 As String = empresa.sCNPJ & Convert.ToDateTime(data).ToString("yyyy")

                Dim ret2 As New X509Certificate2(AppDomain.CurrentDomain.BaseDirectory & "cert\" & cnpj_grid2 & ".pfx", senha_cert, X509KeyStorageFlags.MachineKeySet)

                certificado = ret2
                certificado2 = ret2

                frmdfe2.ShowDialog()

                ''   frmlicenca.Show()
                Me.Close()
                Exit Sub
            End If
        End If


        cert_banco()


        ' carregar_cert()
    End Sub

    Private Sub OpenWithStartInfo()
        Dim startInfo As ProcessStartInfo = New ProcessStartInfo("IExplore.exe")
        startInfo.WindowStyle = ProcessWindowStyle.Minimized
        Process.Start(startInfo)
        startInfo.Arguments = "www.northwindtraders.com"
        Process.Start(startInfo)
    End Sub

    Private Sub carregar_certificado_auto(ByVal cnpj1 As String)
        Dim cnpjg As String = cnpj1
        Dim ret As Integer = 0
        Try

            Dim stringBuilder As StringBuilder = New StringBuilder()
            stringBuilder.Append("Select * from cert ")

            stringBuilder.Append("where cnpj = '" & cnpj1 & "'")


            conectar_mysqlDFe()

            Dim SQLcommand As MySqlCommand

            SQLcommand = oConn.CreateCommand

            SQLcommand.CommandText = stringBuilder.ToString

            dr = SQLcommand.ExecuteReader()


            While (dr.Read())
                senhac = Crypto.Decrypt2(dr("senha"))
                data = dr("Data_venc")
                If File.Exists(Application.StartupPath & "\cert\" & dr("cnpj") & Convert.ToDateTime(dr("Data_venc")).ToString("yyyy") & ".pfx") = False Then
                    Dim bytes = TryCast(dr("cert_arq"), Byte())
                    File.WriteAllBytes(Application.StartupPath & "\cert\" & dr("cnpj") & Convert.ToDateTime(dr("Data_venc")).ToString("yyyy") & ".pfx", bytes)
                End If

                caminho = Application.StartupPath & "\cert\" & dr("cnpj") & Convert.ToDateTime(dr("Data_venc")).ToString("yyyy") & ".pfx"
            End While



            senha_cert = senhac
            Dim cnpj_grid2 As String = cnpj_cert & Convert.ToDateTime(data).ToString("yyyy")

            Dim ret2 As New X509Certificate2(caminho, senha_cert, X509KeyStorageFlags.MachineKeySet)

            certificado = ret2
            certificado2 = ret2

            cnpj_cert = ExtrairCNPJ(certificado)

            nfecer = certificado.SerialNumber

            If CDate(certificado.NotAfter.ToString("dd/MM/yyyy")) < Now.Date Then

                MsgBox("Certificado digital venceu em: " & certificado.NotAfter.ToString("dd/MM/yyyy") & "" & vbCrLf & "adquira um Novo Certificado para acessar o Sistema.", MsgBoxStyle.Critical, "Aviso !")
                'frmcert.ShowDialog()
                ' Me.Close()

            Else

                Dim wD2 As Long = DateDiff(DateInterval.Day, Now.Date, CDate(certificado.NotAfter.ToString))

                If wD2 <= 30 Then
                    ' MsgBox("Faltam " & wD2 & " dias para seu certificado digital vencer !", MsgBoxStyle.Exclamation, "Aviso !")
                End If

                frmdfe2.txtvenc_info.Text = certificado.NotAfter.ToString("dd/MM/yyyy")
                frmdfe2.lblvenc_info.Text = "Faltam " & wD2 & " dias p/venc."

                carrega_emp(certificado, "a1")
                frmlicenca.Show()
                Me.Close()


            End If



        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Modulo: certificado auto")
        End Try
    End Sub
    Private Sub carregar_cert()

        Dim di As New IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory & "\cert")
        Dim aryFi As IO.FileInfo() = di.GetFiles("*.pfx")
        Dim fi As IO.FileInfo
        dgvcert.Rows.Clear()
        For Each fi In aryFi
            dgvcert.Rows.Add(fi.Name.Substring(0, fi.Name.Length - 4))
        Next

        If dgvcert.Rows.Count <> 0 Then
            cert_banco()
        End If

    End Sub

    Private Sub cert_banco()
        dgvcert.Rows.Clear()
        Dim dictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim stringBuilder As StringBuilder = New StringBuilder()
        stringBuilder.Append("Select * from cert")


        conectar_mysqlDFe()


        Dim SQLcommand As MySqlCommand

        SQLcommand = oConn.CreateCommand

        SQLcommand.CommandText = stringBuilder.ToString

        dr = SQLcommand.ExecuteReader()


        While (dr.Read())


            If Directory.Exists(Application.StartupPath & "\cert") = False Then
                Directory.CreateDirectory(Application.StartupPath & "\cert")
            End If


            If File.Exists(Application.StartupPath & "\cert\" & dr("cnpj") & Convert.ToDateTime(dr("Data_venc")).ToString("yyyy") & ".pfx") = False Then
                Dim bytes = TryCast(dr("cert_arq"), Byte())
                File.WriteAllBytes(Application.StartupPath & "\cert\" & dr("cnpj") & Convert.ToDateTime(dr("Data_venc")).ToString("yyyy") & ".pfx", bytes)
            End If

            dictionary = abre_cert(dr("cnpj") & Convert.ToDateTime(dr("Data_venc")).ToString("yyyy"), Crypto.Decrypt2(dr("senha")))

            dgvcert.Rows.Add(PictureBox3.Image, dr("cnpj"), dictionary("razao").ToString, dictionary("data_Venc").ToString, Crypto.Decrypt2(dr("senha")))

            frmdfe2.cbocnpjdfe.Items.Add(dr("cnpj"))
        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()

        Me.Text = "Gerenciador de Certificado Digital: (Salvo no Sistema)"

        Grouper2.GroupTitle = "Certificados no repositório do (Sistema)"
    End Sub

    Private Function abre_cert(ByVal cnpj As String, ByVal senha As String) As Dictionary(Of String, String)
        Dim dictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim ret As New X509Certificate2(AppDomain.CurrentDomain.BaseDirectory & "cert\" & cnpj & ".pfx", senha, X509KeyStorageFlags.MachineKeySet)

        dictionary = dados_cert_Dictionary(ret)

        Return dictionary
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If txtcaminho.Text = "" Then
            MsgBox("Informe o caminho do Certificado !", MsgBoxStyle.Exclamation, "Aviso !")
            Button3.Focus()
            Exit Sub
        End If
        If txtsenha.Text = "" Then
            MsgBox("Informe a Senha do Certificado !", MsgBoxStyle.Exclamation, "Aviso !")
            txtsenha.Focus()
            Exit Sub
        End If

        importa_cert(txtcaminho.Text, txtsenha.Text)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dialogo As New OpenFileDialog
        dialogo.Filter = "Arquivos (.pfx)|*.pfx"

        If dialogo.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtcaminho.Text = dialogo.FileName
        End If
    End Sub


    Private Sub importa_cert(ByVal caminho As String, password As String)
        Dim cnpj As String
        Try


            Dim ret As New X509Certificate2(caminho, password, X509KeyStorageFlags.MachineKeySet)

            If Convert.ToDateTime(ret.NotAfter).ToString("dd/MM/yyyy") < Now.Date Then

                MsgBox("O Certificado Digital Selecionado esta Vencido !" & vbCrLf & "Operação Cancelada !", MsgBoxStyle.Exclamation, "Aviso !")

            Else


                certificado = ret

                cnpj = CertificadoDigital.busca_cnpjcert(ret)

                deleta_cnpj_antigo(cnpj)

                carregar_cer_banco(cnpj, txtsenha.Text, caminho, Convert.ToDateTime(ret.NotAfter).ToString("dd/MM/yyyy"))


                '''''''''''''''''''''Adicionar certificado no repositorio do windows ''''''''''''
                Dim storeMy As X509Store = New X509Store("MY", StoreLocation.CurrentUser)
                storeMy.Open(OpenFlags.ReadWrite)
                storeMy.Add(ret)
                '  MsgBox("ok")
                ''''''''''''''''''''''''''''''''''''''#################''''''''''''''''''''''''''

                If Directory.Exists(AppDomain.CurrentDomain.BaseDirectory & "\cert") = False Then
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory & "\cert")
                End If

                FileCopy(caminho, AppDomain.CurrentDomain.BaseDirectory & "\cert\" & cnpj & Convert.ToDateTime(ret.NotAfter).ToString("yyyy") & ".pfx")

                MsgBox("Certificado foi salvo No sistema !", MsgBoxStyle.Information, "Aviso !")

                txtcaminho.Clear()
                txtsenha.Clear()

                If cert_windows = False Then
                    cert_banco()
                Else
                    carregar_CertificadoA3()
                End If

            End If



        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Aviso !")

        End Try

    End Sub

    Private Sub deleta_cnpj_antigo(ByVal cnpjd As String)
        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand

        SQLcommand = oConn.CreateCommand

        SQLcommand.CommandText = "delete from cert where cnpj = '" & cnpjd & "'"

        dr = SQLcommand.ExecuteReader()

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()
    End Sub

    Private Sub ExcluirCertificadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExcluirCertificadoToolStripMenuItem.Click
        If MessageBox.Show("Deseja Realmente excluir o Certificado Digital ? ", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

            If cert_windows = True Then

                Dim storeMy As X509Store = New X509Store("MY", StoreLocation.CurrentUser)
                storeMy.Open(OpenFlags.ReadWrite)

                Dim store As New X509Store("MY", StoreLocation.CurrentUser)
                store.Open(OpenFlags.OpenExistingOnly)

                For Each cert3 In store.Certificates

                    If cert3.SerialNumber = dgvcert.CurrentRow.Cells("serial_certgrid").Value Then
                        storeMy.Remove(cert3)
                        dgvcert.Rows.Remove(dgvcert.CurrentRow)
                    End If

                Next

            Else

                Dim stringBuilder As StringBuilder = New StringBuilder()
                stringBuilder.Append("delete from cert ")

                stringBuilder.Append("where cnpj = '" & dgvcert.CurrentRow.Cells("cnpj_grid").Value & "'")


                conectar_mysqlDFe()

                Dim SQLcommand As MySqlCommand

                SQLcommand = oConn.CreateCommand

                SQLcommand.CommandText = stringBuilder.ToString

                dr = SQLcommand.ExecuteReader()

                dr.Close()
                SQLcommand.Dispose()
                oConn.Close()

                File.Delete(AppDomain.CurrentDomain.BaseDirectory & "cert\" & dgvcert.CurrentRow.Cells("cnpj_grid").Value & ".pfx")
                dgvcert.Rows.Remove(dgvcert.CurrentRow)

            End If



            MsgBox("Certificado excluido com Sucesso !", MsgBoxStyle.Information, "Aviso !")
        End If
    End Sub

    Function carregar_cer_banco(ByVal cnpj As String, ByVal senha As String, ByVal caminho_cert As String, ByVal data_venc As Date) As String
        Dim ret As Integer = 0
        Try

            Dim stringBuilder As StringBuilder = New StringBuilder()
            stringBuilder.Append("Select * from cert ")

            stringBuilder.Append("where cnpj = '" & cnpj & "'")


            conectar_mysqlDFe()

            Dim SQLcommand As MySqlCommand

            SQLcommand = oConn.CreateCommand

            SQLcommand.CommandText = stringBuilder.ToString

            dr = SQLcommand.ExecuteReader()


            While (dr.Read())
                ret += 1
            End While

            dr.Close()
            SQLcommand.Dispose()
            oConn.Close()


            If ret <> 1 Then


                conectar_mysqlDFe()
                Dim insertSQL As MySqlCommand = New MySqlCommand("INSERT INTO cert (cnpj, senha, cert_arq, Data_venc) VALUES (@cnpj, @senha, @cert_arq, @Data_venc)", oConn)

                insertSQL.Parameters.Add(New MySqlParameter("cnpj", cnpj))
                insertSQL.Parameters.Add(New MySqlParameter("senha", Crypto.Encrypt(senha)))
                insertSQL.Parameters.Add(New MySqlParameter("cert_arq", File.ReadAllBytes(caminho_cert)))
                insertSQL.Parameters.Add(New MySqlParameter("Data_venc", data_venc))

                insertSQL.ExecuteNonQuery()

                oConn.Close()

            End If

            Return ret

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Modulo: carrega_wsdl")
        End Try
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If dgvcert.RowCount = 0 Then
            MsgBox("Não existe cetificados no grid !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        Else
            If Grouper2.GroupTitle <> "Certificados no repositório do (Windows)" Then
                If dgvcert.CurrentRow.Cells("senha").Value = "" Then
                    MsgBox("Selecione um cetificados digital no grid !", MsgBoxStyle.Exclamation, "Aviso !")
                    Exit Sub
                End If
            End If
        End If

        Label3.Visible = True

        If Grouper2.GroupTitle <> "Certificados no repositório do (Windows)" Then

            senha_cert = dgvcert.CurrentRow.Cells("senha").Value
            Dim cnpj_grid2 As String = dgvcert.CurrentRow.Cells("cnpj_grid").Value & Convert.ToDateTime(dgvcert.CurrentRow.Cells("Data_venc").Value).ToString("yyyy")

            Dim ret2 As New X509Certificate2(AppDomain.CurrentDomain.BaseDirectory & "cert\" & cnpj_grid2 & ".pfx", senha_cert, X509KeyStorageFlags.MachineKeySet)

            certificado = ret2
            certificado2 = ret2
        Else
            certificado = SelecionarCertificado(dgvcert.CurrentRow.Cells("serial_certgrid").Value)
            certificado2 = certificado
        End If
        'salvar config a senha do certificado

        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")
        ' If arquivoIni.KeyExists("senha_cert", "" & dgvcert.CurrentRow.Cells("cnpj_grid").Value & "") = False Then
        arquivoIni.Write("senha_cert", Crypto.Crip_licenca(senha_cert), dgvcert.CurrentRow.Cells("cnpj_grid").Value)
        ' End If

        cnpj_cert = ExtrairCNPJ(certificado)

        If cnpj_cert = "" Then
            cnpj_cert = ExtrairCPF(certificado)
        End If

        nfecer = certificado.SerialNumber

        frmparametro.carregar_cert(certificado)

        frminfocertificado.carregar(certificado)

        If CDate(certificado.NotAfter.ToString("dd/MM/yyyy")) < Now.Date Then

            MsgBox("Certificado digital venceu em: " & certificado.NotAfter.ToString("dd/MM/yyyy") & "" & vbCrLf & "adquira um Novo Certificado para acessar o Sistema.", MsgBoxStyle.Critical, "Aviso !")
            ' Dim wD As Long = DateDiff(DateInterval.Day, CDate(certificado.NotAfter.ToString), Now.Date)

            '  MsgBox("Faltam " & wD.ToString & " dias para seu certificado digital vencer !", MsgBoxStyle.Exclamation, "Aviso !")
            Label3.Visible = False

        Else

            Dim wD2 As Long = DateDiff(DateInterval.Day, Now.Date, CDate(certificado.NotAfter.ToString))

            If wD2 <= 30 Then
                MsgBox("Faltam " & wD2 & " dias para seu certificado digital vencer !", MsgBoxStyle.Exclamation, "Aviso !")
            End If

            frmdfe2.txtvenc_info.Text = certificado.NotAfter.ToString("dd/MM/yyyy")
            frmdfe2.lblvenc_info.Text = "Faltam " & wD2 & " dias p/venc."

            If dgvcert.CurrentRow.Cells("senha").Value = "" Then
                carrega_emp(certificado, "a3")

            Else
                carrega_emp(certificado, "a1")
            End If

            frmdfe2.Show()

            par = True

            Me.Close()
        End If

    End Sub


    Public Sub carrega_emp(ByVal x509Certificate2 As X509Certificate2, ByVal tipo As String)
        Dim ret As Integer = 0
        Dim par As Boolean = False
        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "Select * from empresa INNER JOIN municipio ON municipio.codigo_municipio = empresa.cod_munic where empresa.cnpj_emp = '" & busca_cnpjcert(certificado) & "'"
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())

            empresa.sCNPJ = dr("cnpj_emp")
            empresa.sNomeRazao = dr("razao_emp")
            empresa.send = dr("end_emp").ToString
            empresa.sNumero = dr("numero_emp").ToString
            empresa.sBairro = dr("bairro_emp").ToString
            empresa.sCEP = dr("cep_emp").ToString
            empresa.sIe = dr("ie_emp").ToString
            empresa.sIm = dr("im_emp").ToString
            empresa.sInscrMunic = dr("im_emp").ToString
            empresa.Sfone = dr("fone_emp").ToString
            empresa.sCodMunIBGE = dr("cod_munic")
            empresa.sCSC = dr("csc").ToString
            empresa.Idtoken = dr("idtoken").ToString
            empresa.sSiglaUF = dr("uf").ToString
            empresa.sNomeMunic = dr("NomeMunic")
            empresa.scod_trib = dr("reg_trib").ToString
            empresa.saliq_simples = dr("aliq_simples").ToString
            empresa.Scnae = dr("cnae_emp").ToString
            empresa.ambiente_nfe = dr("ambiente_nfe")
            ret += 1
        End While

        par = dr.HasRows

        If dr.HasRows = False Then
            MsgBox("Empresa Não cadastrada no sistema !", MsgBoxStyle.Exclamation, "Aviso !")
            frmlicenca.cad_emp = dgvcert.CurrentRow.Cells("cnpj_grid").Value
            '' frmlicenca.ShowDialog()


            conectar_mysql2()

            Dim dictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)
            dictionary = dados_cert_Dictionary(x509Certificate2)

            Dim insertSQL As MySqlCommand = New MySqlCommand("INSERT INTO empresa (cnpj_emp, razao_emp, email_emp, senha_cert, cert, datavenc_cert, cod_munic, ambiente_nfe) VALUES (@cnpj_emp, @razao_emp, @email_emp, @senha_cert, @cert, @datavenc_cert, @cod_munic, @ambiente_nfe)", oConn2)


            Dim data As Date = dgvcert.CurrentRow.Cells("Data_Venc").Value
            Dim caminho As String = AppDomain.CurrentDomain.BaseDirectory & "cert\" & dgvcert.CurrentRow.Cells("cnpj_grid").Value & data.ToString("yyyy") & ".pfx"

            insertSQL.Parameters.Add(New MySqlParameter("cnpj_emp", dgvcert.CurrentRow.Cells("cnpj_grid").Value))
            empresa.sCNPJ = dgvcert.CurrentRow.Cells("cnpj_grid").Value
            insertSQL.Parameters.Add(New MySqlParameter("razao_emp", removecarrazao(x509Certificate2.SubjectName.Name)))
            insertSQL.Parameters.Add(New MySqlParameter("email_emp", dictionary("e-mail").ToString))
            If tipo = "a1" Then
                insertSQL.Parameters.Add(New MySqlParameter("senha_cert", Crypto.Encrypt(dgvcert.CurrentRow.Cells("senha").Value)))
                insertSQL.Parameters.Add(New MySqlParameter("cert", File.ReadAllBytes(caminho)))
            Else
                insertSQL.Parameters.Add(New MySqlParameter("senha_cert", ""))
                insertSQL.Parameters.Add(New MySqlParameter("cert", Nothing))
            End If

            insertSQL.Parameters.Add(New MySqlParameter("datavenc_cert", Convert.ToDateTime(x509Certificate2.NotAfter).ToString("dd/MM/yyyy")))
            insertSQL.Parameters.Add(New MySqlParameter("cod_munic", "3137809"))
            insertSQL.Parameters.Add(New MySqlParameter("ambiente_nfe", "1"))

            insertSQL.ExecuteNonQuery()

            oConn2.Close()

            ''   MsgBox("Empresa cadastrada no sistema !", MsgBoxStyle.Information, "Aviso !")
        End If

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()

        If par = False Then
            '' inserir_dados_chave(Criptografar(dgvcert.CurrentRow.Cells("cnpj_grid").Value))
        End If

    End Sub

    Private Sub inserir_dados_chave(ByVal cnpj_d As String)
        Dim tp As String = Criptografar("1")
        Dim Sql As String = "INSERT INTO licenca (key_sist, key_id, key_tp) VALUES ('DFe', '" & cnpj_d & "', '" & tp & "')"

        conectar_mysqlDFe()
        Dim insertSQL As MySqlCommand = New MySqlCommand(Sql, oConn)
        insertSQL.ExecuteNonQuery()
        oConn.Close()
    End Sub
    Public Function removecarrazao(ByVal razao As String)
        razao = razao.Remove(0, 3)
        For i As Integer = 0 To razao.Length - 1

            If razao.Substring(i, 1) = "," Then
                razao = razao.Remove(i, razao.Length - i)
                Exit For
            End If
        Next

        Return razao
    End Function

    Private Sub Grouper2_Load(sender As Object, e As EventArgs) Handles Grouper2.Load

    End Sub


    Private Sub CertificadoA3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CertificadoA3ToolStripMenuItem.Click



    End Sub


    Private Sub carregar_CertificadoA3()
        Dim razao As String
        Dim store As New X509Store("MY", StoreLocation.CurrentUser)
        store.Open(OpenFlags.OpenExistingOnly)

        dgvcert.Rows.Clear()

        For Each cert2 In store.Certificates

            razao = cert2.SubjectName.Name
            razao = razao.Remove(0, 3)
            For i As Integer = 0 To razao.Length - 1

                If razao.Substring(i, 1) = "," Then
                    razao = razao.Remove(i, razao.Length - i)
                    Exit For
                End If
            Next

            If CertificadoDigital.busca_cnpjcert(cert2) <> "" Then
                Dim v As String

                If CDate(cert2.NotAfter.ToString("dd/MM/yyyy")) < Now.Date Then
                    v = "vencido"
                Else
                    v = ""
                End If
                dgvcert.Rows.Add(PictureBox3.Image, CertificadoDigital.busca_cnpjcert(cert2), razao, Convert.ToDateTime(cert2.NotAfter).ToString("dd/MM/yyyy HH:mm:ss"), "", cert2.SerialNumber, v)
            End If

        Next

        For Each row As DataGridViewRow In dgvcert.Rows
            If row.Cells("vencido_grid").Value = "vencido" Then
                With Me.dgvcert.Rows(row.Index).DefaultCellStyle
                    .BackColor = Color.Red
                    .ForeColor = Color.White
                End With
            End If
        Next


        store.Close()

        Me.Text = "Gerenciador de Certificado Digital: (Repositório Windows)"
        Grouper2.GroupTitle = "Certificados no repositório do (Windows)"
        tipoCertA3 = True

    End Sub


    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If cert_windows = False Then
            addcertNoWindowsToolStripMenuItem.Visible = True
        Else
            addcertNoWindowsToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub InformaçõesCertificadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InformaçõesCertificadoToolStripMenuItem.Click
        If cert_windows = True Then

            If dgvcert.CurrentRow.Cells("vencido_grid").Value = "vencido" Then
                MsgBox("O Certificado Digital Selecionado esta Vencido !" & vbCrLf & "Operação Cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
                Exit Sub
            End If

            certificado = SelecionarCertificado(dgvcert.CurrentRow.Cells("serial_certgrid").Value)
            frminfocertificado.carregar(certificado)
            frminfocertificado.ShowDialog()

        Else
            MsgBox("Esta opção é para Certificado carregado do Windows !", MsgBoxStyle.Information, "Aviso !")
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        cert_windows = False
        cert_banco()
        PictureBox1.Visible = False
        PictureBox2.Visible = True
        Button4.Enabled = True
        Button3.Enabled = True
        txtsenha.Enabled = True
        frmdfe2.cbocnpjdfe.Enabled = True
    End Sub

    Private Sub addcertNoWindowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles addcertNoWindowsToolStripMenuItem.Click
        Dim password As String = dgvcert.CurrentRow.Cells("senha").Value
        Dim cm As String = Application.StartupPath & "\cert\" & dgvcert.CurrentRow.Cells("cnpj_grid").Value & Convert.ToDateTime(dgvcert.CurrentRow.Cells("Data_Venc").Value).ToString("yyyy") & ".pfx"
        '''''''''''''''''''''Adicionar certificado no repositorio do windows ''''''''''''
        Dim ret As New X509Certificate2(cm, password, X509KeyStorageFlags.MachineKeySet)



        Dim storeMy As X509Store = New X509Store("MY", StoreLocation.CurrentUser)
        storeMy.Open(OpenFlags.ReadWrite)
        storeMy.Add(ret)

        MsgBox("Certificado adicionado no Reporitório do windows !", MsgBoxStyle.Information, "Aviso !")
    End Sub

    Private Sub dgvcert_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvcert.CellContentClick

    End Sub

    Private Sub ContextMenuStrip2_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip2.Opening

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        cert_windows = True
        carregar_CertificadoA3()
        PictureBox1.Visible = True
        PictureBox2.Visible = False
        Button4.Enabled = False
        Button3.Enabled = False
        txtsenha.Enabled = False
        frmdfe2.cbocnpjdfe.Enabled = False
    End Sub
End Class