Imports System.Drawing.Printing
Imports System.IO
Imports System.Text
Imports System.Xml
Imports MySql.Data.MySqlClient
Imports NetFwTypeLib
Imports System.Security.Cryptography.X509Certificates

Public Class frmprincipal

    Dim caminho As String, senha As String, data As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FrmDfe.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmxml.Show()
        Me.Close()
    End Sub



    Private Sub frmprincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblnetinfo.Text = "Versão NET Framework  PC: " & GetDotNetVersion.VersaoDOTNET()

        If UsuarioExisteBanco("dfe", "%") = False Or UsuarioExisteBanco("dfe", "localhost") = False Then
            Timer1.Dispose()
            frmconfig_UserBanco.ShowDialog()

        End If

        Timer1.Enabled = True

        If ConectadoInternet() = True Then
            Pic_conexao.Visible = True
        Else
            Label3.Visible = False
        End If

        lblversaomy.Text = "Versâo mysql: " & RecuperaVersaoMySQL()


        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")
        If arquivoIni.KeyExists("tela_direta", "DFe") = False Then
            arquivoIni.Write("tela_direta", "false", "DFe")
        End If

        If arquivoIni.KeyExists("cnpj_cert_auto", "DFe") = False Then
            arquivoIni.Write("cnpj_cert_auto", "", "DFe")
        End If

        If arquivoIni.Read("tela_direta", "DFe") = "True" Then
            If arquivoIni.Read("cnpj_cert_auto", "DFe") <> "" Then
                carregar_certificado_auto(arquivoIni.Read("cnpj_cert_auto", "DFe"))
                Timer2.Enabled = True
            End If
        Else
            If arquivoIni.KeyExists("servidorNFCe", "DFe") Then
                If arquivoIni.Read("servidorNFCe", "DFe") = "true" Then
                    frmcert.Show()
                    Me.Close()
                End If
            End If
        End If


    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frm_bematech.ShowDialog()
    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmdfe2.Show()
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        regimetrib = 3

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        FrmEmpresa.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        FrmDfe.ShowDialog()
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbldatas.Text = "Data Sistema: " & DataSistema()
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim licensa As String
        Dim dataatual As DateTime = Now
        Dim quantidadeDias As Integer = 60

        Dim hora As String = dataatual.ToString("hhmmss")
        Dim dateTime As DateTime = dataatual
        dateTime = dateTime.AddDays(CDbl(quantidadeDias))

        licensa = (LinxOSLicenca.GerarChave("10962965000119", hora, dataatual.AddDays(CDbl(quantidadeDias)), dataatual, 5))

        Using connection As MySqlConnection = DBHelper.ConexaoBDMysql()
            BaseModel.ExecutaQuery("update control set myControl = '" & licensa & "'", connection)
        End Using

        MsgBox("Atualizado !")

        'campo license tab control mysql=  cryptografia_linear.Descriptografar("/ZiS9af3tqkbGap0hUP2XpcNOc8EOiDhh5CgHK8PSBE=")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        frm_import.ShowDialog()
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
                senha = Crypto.Decrypt2(dr("senha"))
                data = dr("Data_venc")
                If File.Exists(Application.StartupPath & "\cert\" & dr("cnpj") & Convert.ToDateTime(dr("Data_venc")).ToString("yyyy") & ".pfx") = False Then
                    Dim bytes = TryCast(dr("cert_arq"), Byte())
                    File.WriteAllBytes(Application.StartupPath & "\cert\" & dr("cnpj") & Convert.ToDateTime(dr("Data_venc")).ToString("yyyy") & ".pfx", bytes)
                End If

                caminho = Application.StartupPath & "\cert\" & dr("cnpj") & Convert.ToDateTime(dr("Data_venc")).ToString("yyyy") & ".pfx"
            End While



            senha_cert = senha
            Dim cnpj_grid2 As String = cnpj_cert & Convert.ToDateTime(data).ToString("yyyy")

            Dim ret2 As New X509Certificate2(caminho, senha_cert, X509KeyStorageFlags.MachineKeySet)

            certificado = ret2
            certificado2 = ret2

            cnpj_cert = ExtrairCNPJ(certificado)

            nfecer = certificado.SerialNumber

            If CDate(certificado.NotAfter.ToString) < Now.Date Then

                Dim wD As Long = DateDiff(DateInterval.Day, CDate(certificado.NotAfter.ToString), Now.Date)

                MsgBox("Faltam " & wD.ToString & " dias para seu certificado digital vencer !", MsgBoxStyle.Exclamation, "Aviso !")
                frmcert.ShowDialog()
                Me.Close()

            Else

                carrega_emp(certificado)
                frmdfe2.WindowState = FormWindowState.Minimized
                frmdfe2.Timer2.Enabled = True
                frmdfe2.Show()
                '   Me.Close()


            End If



        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Modulo: certificado auto")
        End Try
    End Sub


    Private Sub carrega_emp(ByVal x509Certificate2 As X509Certificate2)
        Dim ret As Integer = 0
        conectar_mysqlDFe()

        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "Select * from empresa INNER JOIN municipio ON municipio.codigo_municipio = empresa.cod_munic where empresa.cnpj_emp = '" & empresa.sCNPJ & "'"
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())

            empresa.sCNPJ = dr("cnpj_emp")
            empresa.sNomeRazao = dr("razao_emp")
            empresa.send = dr("end_emp")
            empresa.sNumero = dr("numero_emp")
            empresa.sBairro = dr("bairro_emp")
            empresa.sCEP = dr("cep_emp")
            empresa.sIe = dr("ie_emp")
            empresa.sIm = dr("im_emp")
            empresa.sInscrMunic = dr("im_emp")
            empresa.Sfone = dr("fone_emp")
            empresa.sCodMunIBGE = dr("cod_munic")
            empresa.sCSC = dr("csc")
            empresa.Idtoken = dr("idtoken")
            empresa.sSiglaUF = dr("uf")
            empresa.sNomeMunic = dr("NomeMunic")
            empresa.scod_trib = dr("reg_trib").ToString
            empresa.saliq_simples = dr("aliq_simples")
            empresa.Scnae = dr("cnae_emp")
            empresa.ambiente_nfe = dr("ambiente_nfe")
            ret += 1
        End While

        If dr.HasRows = False Then
            conectar_mysql2()

            Dim dictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)
            dictionary = dados_cert_Dictionary(x509Certificate2)

            Dim insertSQL As MySqlCommand = New MySqlCommand("INSERT INTO empresa (cnpj_emp, razao_emp, email_emp, senha_cert, cert, datavenc_cert) VALUES (@cnpj_emp, @razao_emp, @email_emp, @senha_cert, @cert, @datavenc_cert)", oConn2)


            Dim data As Date = data
            Dim caminho As String = AppDomain.CurrentDomain.BaseDirectory & "cert\" & cnpj_cert & data.ToString("yyyy") & ".pfx"

            insertSQL.Parameters.Add(New MySqlParameter("cnpj_emp", empresa.sCNPJ))
            insertSQL.Parameters.Add(New MySqlParameter("razao_emp", removecarrazao(x509Certificate2.SubjectName.Name)))
            insertSQL.Parameters.Add(New MySqlParameter("email_emp", dictionary("e-mail").ToString))
            insertSQL.Parameters.Add(New MySqlParameter("senha_cert", Crypto.Encrypt(senha)))
            insertSQL.Parameters.Add(New MySqlParameter("cert", File.ReadAllBytes(caminho)))
            insertSQL.Parameters.Add(New MySqlParameter("datavenc_cert", Convert.ToDateTime(x509Certificate2.NotAfter).ToString("dd/MM/yyyy")))

            insertSQL.ExecuteNonQuery()

            oConn2.Close()
            MsgBox("Empresa cadastrada no sistema !", MsgBoxStyle.Information, "Aviso !")
        End If

        dr.Close()
        SQLcommand.Dispose()
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

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim retDistDFeInt As retDistDFeInt
        Dim xmldoc = New XmlDocument()

        xmldoc.Load(AppDomain.CurrentDomain.BaseDirectory & "/XML/DFe_consulta_ret.xml")

        xmldoc.DocumentElement.Attributes.RemoveNamedItem("NSU")

        retDistDFeInt = funcoesNfe.DeserializarNFe(Of retDistDFeInt)(xmldoc.OuterXml)

        MsgBox(retDistDFeInt.cStat)

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")
        If arquivoIni.KeyExists("tela_direta", "DFe") = False Then
            arquivoIni.Write("tela_direta", "false", "DFe")
        End If

        If arquivoIni.Read("tela_direta", "DFe") = "True" Then
            frmdfe2.Show()
            Me.Close()
        End If
    End Sub

    Private Sub teste12()


        Dim processes As Process() = Process.GetProcessesByName("winrar")

        If processes.Length >= 1 Then 'se for maior que 0 então existem processos com o nome X

            MsgBox("Aplicativo já esta aberto !", MsgBoxStyle.Exclamation, "Aviso !")

        End If
        '  For Each process As Process In processes

        'MsgBox("ativo")

        '  Next
    End Sub
End Class