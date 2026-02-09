Imports Microsoft.Win32
Imports System.Management
Imports System.IO.Compression
Imports System.IO

Imports MySql.Data.MySqlClient


Public Class Utilitarios
    Public Function RegistrarDLL() As Boolean
        Try


            Dim path1 As String = String.Format("{0}ConciliadorLinearWeb.dll", CObj(AppDomain.CurrentDomain.BaseDirectory))
            If Not System.IO.File.Exists(path1) Then Throw New Exception(String.Format("Dll não Localizada: {0}", CObj(path1)))
            Dim process1 As Process = New Process()
            Dim str1 As String = String.Format("/s {0}", CObj(path1))
            process1.StartInfo.FileName = "regsvr32.exe"
            process1.StartInfo.Arguments = str1
            process1.StartInfo.Verb = "runas"
            process1.StartInfo.UseShellExecute = True
            process1.StartInfo.CreateNoWindow = True
            process1.StartInfo.RedirectStandardOutput = False
            process1.Start()
            process1.WaitForExit()
            process1.Close()
            Dim path2 As String = String.Format("{0}LinearConciliaServices.dll", CObj(AppDomain.CurrentDomain.BaseDirectory))
            If Not System.IO.File.Exists(path2) Then Throw New Exception(String.Format("Dll não Localizada: {0}", CObj(path2)))
            Dim str2 As String = Environment.GetEnvironmentVariable("SystemRoot") & "\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe"
            Dim str3 As String = path2 & " /codebase"
            Dim process2 As Process = New Process()
            process2.StartInfo.FileName = str2
            process2.StartInfo.Arguments = str3
            process2.StartInfo.Verb = "runas"
            process2.StartInfo.UseShellExecute = True
            process2.StartInfo.CreateNoWindow = True
            process2.StartInfo.RedirectStandardOutput = False
            process2.Start()
            process2.WaitForExit()
            process2.Close()


        Catch ex As Exception
            ' TrataErro.Excecao(ex)
        End Try

        Return True
    End Function

    Public Function SerialHD(Optional ByVal gerarChave As Boolean = False) As String
        Dim str As String = ""

        Try
            ' Dim monitorConfig As MonitorConfig = New MonitorConfig()

            '  Select Case monitorConfig.ServerkeyType
            '  Case 0
            '
            For Each managementObject As ManagementObject In New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive").[Get]()

                If managementObject("SerialNumber") IsNot Nothing Then
                    str = managementObject("SerialNumber").ToString().Trim()
                    Exit For
                End If
            Next

            If str.Trim() = String.Empty And gerarChave OrElse str.Length <= 3 Then
                str = PlacaMaeID()
                '  monitorConfig.SetarServerKeyType(3)
                ' If str.Trim() <> String.Empty Then Exit Select
            End If

            If str.Trim() = String.Empty And gerarChave OrElse str.Length <= 3 Then
                str = CpuID()
                '  monitorConfig.SetarServerKeyType(2)
                '   If str.Trim() <> String.Empty Then Exit Select
            End If

            If Not (str.Trim() = String.Empty And gerarChave) Then
                '  If str.Length > 3 Then Exit Select
            End If

            str = GerarServerKeyRegEdit()
            '  monitorConfig.SetarServerKeyType(1)
            'If Not (str.Trim() <> String.Empty) Then Exit Select
            ' Case 1
            str = Registry.LocalMachine.OpenSubKey("Software\TWService\SkReg").GetValue("guid").ToString()
            '  Case 2
            str = CpuID()
            ' Case 3
            str = PlacaMaeID()
            ' End Select

        Catch ex As Exception
            '  TrataErro.Excecao(ex)
            Throw
        End Try

        Return str
    End Function

    Private Shared Function CpuID() As String
        Dim str As String = identifier("Win32_Processor", "UniqueId")
        If str = "" Then str = identifier("Win32_Processor", "ProcessorId")
        Return str
    End Function

    Private Shared Function PlacaMaeID() As String
        Return identifier("Win32_BaseBoard", "SerialNumber")
    End Function

    Private Shared Function identifier(ByVal wmiClass As String, ByVal wmiProperty As String) As String
        Dim str As String = ""

        For Each instance As ManagementObject In New ManagementClass(wmiClass).GetInstances()

            If str = "" Then

                Try
                    str = instance(wmiProperty).ToString().Replace(".", "")
                    Exit For
                Catch
                End Try
            End If
        Next

        Return str
    End Function

    Private Shared Function GerarServerKeyRegEdit() As String
        Dim str1 As String

        Try
            Dim registryKey1 As RegistryKey = Registry.Users.OpenSubKey("Software", True)
            registryKey1.CreateSubKey("TWService")
            Dim registryKey2 As RegistryKey = registryKey1.OpenSubKey("TWService", True)
            registryKey2.CreateSubKey("SkReg")
            Dim registryKey3 As RegistryKey = registryKey2.OpenSubKey("SkReg", True)
            str1 = String.Format("{0}{1}", CObj(Guid.NewGuid().ToString().Replace("-", "")), CObj(DateTime.Now.ToString("yyyyMMddHHmmssffff")))
            Dim str2 As String = str1
            registryKey3.SetValue("guid", CObj(str2))
        Catch ex As Exception
            Throw
        End Try

        Return str1
    End Function

    Public Shared Function RetornaParteDecimal(ByVal numero As Decimal) As Integer
        Try
            Return Integer.Parse(numero.ToString().Substring(numero.ToString().IndexOf(","c)))
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function NumeroInteiro(ByVal numero As String) As Boolean
        Try
            Dim result As Integer
            Return Integer.TryParse(numero, result)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function FormataData(ByVal data As DateTime, ByVal formato As Integer) As String
        Dim str As String = ""

        Try

            Select Case formato
                Case 0
                    str = String.Format("{0:yyyy-MM-dd}", CObj(data))
                Case 1
                    str = String.Format("{0:HH:mm:ss}", CObj(data))
                Case 2
                    str = String.Format("{0:yyyy-MM-dd HH:mm:ss}", CObj(data))
            End Select

        Catch ex As Exception
            Throw
        End Try

        Return str
    End Function

    Public Shared Function FormataValorDecimal(ByVal value As Decimal, Optional ByVal casasDecimais As Integer = 2) As Decimal
        Try
            Return Convert.ToDecimal(String.Format("{0:0." & New String("0"c, casasDecimais) & "}", CObj(value)))
        Catch ex As Exception
            Throw
        End Try
    End Function
  

    Public Shared Function VerificaSeUrlValida(ByVal url As String) As Boolean
        Try
            Dim result As Uri
            Return Uri.TryCreate(url, UriKind.Absolute, result) AndAlso (result.Scheme Is Uri.UriSchemeHttp OrElse result.Scheme Is Uri.UriSchemeHttps)
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Function Caminho_arq_export() As String
        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config.ini")

        If arquivoIni.KeyExists("caminho", "PATH_CARGA") = False Then
            arquivoIni.Write("caminho", "", "PATH_CARGA")
        End If
        If arquivoIni.KeyExists("local", "PATH_CARGA") = False Then
            arquivoIni.Write("local", "false", "PATH_CARGA")
        End If


        If arquivoIni.Read("local", "PATH_CARGA") = "True" Then
            Return arquivoIni.Read("caminho", "PATH_CARGA")
        Else
            Return Application.StartupPath & "\TX"
        End If
    End Function

End Class
