Imports System.Security
Imports System.Security.Principal.WindowsIdentity
Imports System.Data.OleDb
Imports System.Data.SQLite
Imports MySql.Data.MySqlClient
Imports System.IO
Imports ADODB
Public Module conexao
    Public conexao_online As Boolean = False
    Public data_licenca As Date
    Public cnsql As New ADODB.Connection
    Public cn_p As New ADODB.Connection
    Public cn As New ADODB.Connection
    Public cn_nfe As New ADODB.Connection
    Public cn_ONE As New ADODB.Connection
    Public cn_DFe As New ADODB.Connection
    Public cnemail As New ADODB.Connection
    Public dr As MySqlDataReader
    Public oConn As New MySqlConnection
    Public oConnsg As New MySqlConnection
    Public oConn2 As New MySqlConnection
    Public oConnS As New MySqlConnection
    Public Conn As New SQLiteConnection

    Public cnado As New OleDb.OleDbConnection
    Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")
    Public ip_mysql As String = arquivoIni.Read("ip_mysql", "DFe")
    Public sConnectionString As String

    Public Sub conectar_mysqlDFe()
        DB_mysql.host = ip_mysql
        Try


            If UsuarioExisteBanco("dfe", "localhost") Or UsuarioExisteBanco("dfe", "%") Then
                If arquivoIni.KeyExists("ip_mysql", "DFe") = False Then
                    arquivoIni.Write("ip_mysql", "127.0.0.1", "DFe")
                End If

                oConn = New MySqlConnection("server=" & ip_mysql & ";User Id=dfe;database=dfe; password=Pe$$w0rd1@;UseCompression=True;")
                '  oConn = New MySqlConnection("host=" & arquivoIni.Read("ip_mysql", "DFe") & "; port=5040; userid=spedfiscal; password=spedfiscal; database=dfe")


                If oConn.State = ConnectionState.Closed Then
                    oConn.Open()
                End If
            End If


        Catch ex As Exception
            MsgBox("Erro banco Local Conexao: " & ex.Message, MsgBoxStyle.Exclamation, "Aviso !")
            conexao_online = True

            If ip_mysql = "127.0.0.1" Then
                Dim proc As Process

                For Each proc In Process.GetProcesses
                    If proc.ProcessName = "mysqld-nt" Then
                        proc.Kill()
                    End If
                Next

                Using myProcess As Process = New Process()
                    myProcess.StartInfo.UseShellExecute = False
                    myProcess.StartInfo.FileName = Application.StartupPath & "\mysql\bin\mysqld-nt.exe"
                    myProcess.StartInfo.CreateNoWindow = True
                    myProcess.Start()
                End Using
            End If



        End Try



    End Sub


    Public Sub conectar_mysqlDFe_site()

      
        oConnS = New MySqlConnection("server=mysql5022.site4now.net;User Id=a6502e_dbsite;database=db_a6502e_dbsite; password=Drogstore1;UseCompression=True;Command Timeout=0")
        '  oConn = New MySqlConnection("host=" & arquivoIni.Read("ip_mysql", "DFe") & "; port=5040; userid=spedfiscal; password=spedfiscal; database=dfe")


        If oConnS.State = ConnectionState.Closed Then
            oConnS.Open()
        End If

    End Sub

    Public Sub conectar_mysqlDFe_ON()


        oConn = New MySqlConnection("server=mysql5022.site4now.net;User Id=a6502e_dbsite;database=db_a6502e_dbsite; password=Drogstore1;UseCompression=True;Command Timeout=0")
        '  oConn = New MySqlConnection("host=" & arquivoIni.Read("ip_mysql", "DFe") & "; port=5040; userid=spedfiscal; password=spedfiscal; database=dfe")


        If oConn.State = ConnectionState.Closed Then
            oConn.Open()
        End If

    End Sub

    Public Sub conectar_mysql_sglinx()

        If UsuarioExisteBanco("dfe", "%") = False Then
            MsgBox("O usuario de acesso banco (dfe, acesso rede %) não exite no mysql !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        If UsuarioExisteBanco("dfe", "localhost") = False Then
            MsgBox("O usuario de acesso banco (dfe, acesso rede localhost) não exite no mysql !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If


        If arquivoIni.KeyExists("ip_mysql", "DFe") = False Then
            arquivoIni.Write("ip_mysql", "127.0.0.1", "DFe")
        End If

        oConnsg = New MySqlConnection("server=" & ip_mysql & ";User Id=dfe;database=sglinx; password=Pe$$w0rd1@")
        '  oConn = New MySqlConnection("host=" & arquivoIni.Read("ip_mysql", "DFe") & "; port=5040; userid=spedfiscal; password=spedfiscal; database=dfe")


        If oConnsg.State = ConnectionState.Closed Then
            oConnsg.Open()
        End If

    End Sub

    Public Sub conectar_mysqlSite()

        If UsuarioExisteBanco("dfe", "%") = False Then
            MsgBox("O usuario de acesso banco (dfe, acesso rede %) não exite no mysql !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        If UsuarioExisteBanco("dfe", "localhost") = False Then
            MsgBox("O usuario de acesso banco (dfe, acesso rede localhost) não exite no mysql !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")
        If arquivoIni.KeyExists("ip_mysql", "DFe") = False Then
            arquivoIni.Write("ip_mysql", "127.0.0.1", "DFe")
        End If

        oConn = New MySqlConnection("server=" & arquivoIni.Read("ip_mysql", "DFe") & ";User Id=dfe;database=banco_site; password=Pe$$w0rd1@")
        '  oConn = New MySqlConnection("host=" & arquivoIni.Read("ip_mysql", "DFe") & "; port=5040; userid=spedfiscal; password=spedfiscal; database=dfe")


        If oConn.State = ConnectionState.Closed Then
            oConn.Open()
        End If

    End Sub
    Public Sub conectar_mysql2()

        If UsuarioExisteBanco("dfe", "%") = False Then
            MsgBox("O usuario de acesso banco (dfe, acesso rede %) não exite no mysql !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        If UsuarioExisteBanco("dfe", "localhost") = False Then
            MsgBox("O usuario de acesso banco (dfe, acesso rede localhost) não exite no mysql !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If


        If arquivoIni.KeyExists("ip_mysql", "DFe") = False Then
            arquivoIni.Write("ip_mysql", "127.0.0.1", "DFe")
        End If

        oConn2 = New MySqlConnection("server=" & ip_mysql & ";User Id=dfe;database=dfe; password=Pe$$w0rd1@;UseCompression=True;")
        '  oConn = New MySqlConnection("host=" & arquivoIni.Read("ip_mysql", "DFe") & "; port=5040; userid=spedfiscal; password=spedfiscal; database=dfe")


        If oConn2.State = ConnectionState.Closed Then
            oConn2.Open()
        End If

    End Sub
    Public Sub conectar_mysql_DFe2()

        If UsuarioExisteBanco("dfe", "%") = False Then
            MsgBox("O usuario de acesso banco (dfe, acesso rede %) não exite no mysql !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        If UsuarioExisteBanco("dfe", "localhost") = False Then
            MsgBox("O usuario de acesso banco (dfe, acesso rede localhost) não exite no mysql !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If


        If arquivoIni.KeyExists("ip_mysql", "DFe") = False Then
            arquivoIni.Write("ip_mysql", "127.0.0.1", "DFe")
        End If
        Try

            If cn_DFe.State = ConnectionState.Closed Then
                cn_DFe.Open("DRIVER={MySQL ODBC 3.51 Driver};Database=dfe;Server=" & ip_mysql & ";Port=3306;uid=dfe;pwd=Pe$$w0rd1@;STMT=;Opt")
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso !")
        End Try

    End Sub

    Public Sub conectar_sqlite()


        sConnectionString = "Data Source=" & AppDomain.CurrentDomain.BaseDirectory & "config.dat;Version=3;New=True;"

        'abre a conexão
        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = sConnectionString
            Conn.Open()
        End If
    End Sub

    Public Sub conectar_sqlite_cfe()


        ' sConnectionString = "Data Source=C:\Users\adeni\OneDrive\Área de Trabalho\teste\Cfe.db3;Version=3;New=True;"

        'abre a conexão
        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = "Data Source=C:\PDVLinx\Cfe.db3;Version=3;Password=R@enil2015#;"
            Conn.Open()
        End If
    End Sub

    Public Sub conectarsqlinx()

        If UsuarioExisteBanco("dfe", "%") = False Then
            MsgBox("O usuario de acesso banco (dfe, acesso rede %) não exite no mysql !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        If UsuarioExisteBanco("dfe", "localhost") = False Then
            MsgBox("O usuario de acesso banco (dfe, acesso rede localhost) não exite no mysql !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If


        Try



            If cnsql.State = ConnectionState.Closed Then
                cnsql.Open("DRIVER={MySQL ODBC 3.51 Driver};Database=sglinx;Server=" & ip_mysql & ";Port=3306;uid=dfe;pwd=Pe$$w0rd1@;STMT=;Opt")
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso, Erro Conexão Sistema SGLinear.")
        End Try

    End Sub

    Public Sub conectar_ado()
        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")
        If arquivoIni.KeyExists("caminho_banco", "DFe") = False Then
            arquivoIni.Write("caminho_banco", "", "DFe")
        End If

        caminho_banco = arquivoIni.Read("caminho_banco", "DFe")

        If cnado.State = ConnectionState.Closed Then
            cnado.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;data source= " & Application.StartupPath & "\sefaz.mdb"
            cnado.Open()
        End If

    End Sub

    Public Sub conectar_DFe()

        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")
        If arquivoIni.KeyExists("caminho_banco", "DFe") = False Then
            arquivoIni.Write("caminho_banco", "", "DFe")
        End If

        Try

            If cn_DFe.State = ConnectionState.Closed Then
                cn_DFe.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\sefaz.mdb")
            End If

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso, Erro conexão Sistema DFe.")

        End Try

    End Sub


    Public Sub conectar_preco()
        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\sglinear.ini")
        If arquivoIni.KeyExists("caminho_base_temp", "FORMA_PRECO") = False Then
            arquivoIni.Write("caminho_base_temp", "", "FORMA_PRECO")
        End If


        Try

            If cn_p.State = ConnectionState.Closed Then
                ' cn_p.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & arquivoIni.Read("caminho_base_temp", "FORMA_PRECO") & "")

                cn_p.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & arquivoIni.Read("caminho_base_temp", "FORMA_PRECO") & ";User Id=admin;Password=;")
            End If

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso, Erro conexão Sistema Forma Preço.")

        End Try

    End Sub


    Public Sub conectar_onedrive(ByVal caminho_one As String)

        Try

            If cn_ONE.State = ConnectionState.Closed Then
                cn_ONE.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & caminho_one & "")
            End If

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso, Erro conexão sistema OneDrive.")

        End Try

    End Sub


    Public Sub conectar_teste()

        '  Try

        If cn_p.State = ConnectionState.Closed Then
            cn_p.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\banco_duplicata.mdb")
        End If

        '  Catch ex As Exception

        '     MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso, Erro conexão Sistema Forma Preço.")

        '  End Try

    End Sub

    Public Sub conectar_boleto()
        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config.ini")
        If arquivoIni.KeyExists("caminho_dup", "BANCO") = False Then
            arquivoIni.Write("caminho_dup", "", "BANCO")
        End If


        Try

            If cn.State = ConnectionState.Closed Then
                cn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & arquivoIni.Read("caminho_dup", "BANCO") & "")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub conectar_baseNFe()

        ' Try
        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_sist.ini")
        If arquivoIni.KeyExists("caminho_nfe_mais", "BANCO") = False Then
            arquivoIni.Write("caminho_nfe_mais", Application.StartupPath, "BANCO")
        End If

        If cn_nfe.State = ConnectionState.Closed Then
            'cn_nfe.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & arquivoIni.Read("caminho_nfe_mais", "BANCO") & "\BD_NFE.mdb")
        End If

        ' Catch ex As Exception
        'MsgBox(ex.Message & "   |   " & "Arquivo config_sist.ini", MsgBoxStyle.Critical, "Aviso")

        ' End
        ' End Try
    End Sub

    Public Sub fecha_baseNFe()

        Try


            If cn_nfe.State = ConnectionState.Open Then
                cn_nfe.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso Rotina fecha_baseNFe")

        End Try
    End Sub
End Module
