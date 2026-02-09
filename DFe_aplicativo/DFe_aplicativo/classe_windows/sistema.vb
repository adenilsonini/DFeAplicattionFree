
Imports Microsoft.Win32
Imports System
Imports System.Management
Imports System.Security.Cryptography
Imports System.Text

Module sistema
    Function SerialHD(Optional ByVal gerarChave As Boolean = False) As String
        Dim str As String = ""

        Try
            Dim monitorConfig As MonitorConfig = New MonitorConfig()

            '   Select Case monitorConfig.ServerkeyType
            '  Case 0

            For Each managementObject As ManagementObject In New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive").[Get]()

                If managementObject("SerialNumber") IsNot Nothing Then
                    str = managementObject("SerialNumber").ToString().Trim()
                    Exit For
                End If
            Next

            If String.IsNullOrWhiteSpace(str) And gerarChave OrElse str.Length <= 3 Then
                str = sistema.PlacaMaeID()
                '   monitorConfig.SetarServerKeyType(3)
                '  If Not String.IsNullOrWhiteSpace(str) Then Exit Select
            End If

            If String.IsNullOrWhiteSpace(str) And gerarChave OrElse str.Length <= 3 Then
                str = sistema.CpuID()
                '    monitorConfig.SetarServerKeyType(2)
                '  If Not String.IsNullOrWhiteSpace(str) Then Exit Select
            End If

            If Not (String.IsNullOrWhiteSpace(str) And gerarChave) Then
                '   If str.Length > 3 Then Exit Select
            End If

            str = sistema.GerarServerKeyRegEdit()
            ' monitorConfig.SetarServerKeyType(1)
            ' If String.IsNullOrWhiteSpace(str) Then Exit Select
            '   '  Case 1
            '  str = Registry.LocalMachine.OpenSubKey("Software\TWService\SkReg").GetValue("guid").ToString()
            '    Case 2
            '  str = sistema.CpuID()
            '    Case 3
            '  str = sistema.PlacaMaeID()
            '   End Select

        Catch ex As Exception
            '  TrataErro.Excecao(ex)
            Throw
        End Try

        Return str
    End Function

    Private Function CpuID() As String
        Dim str As String = sistema.identifier("Win32_Processor", "UniqueId")
        If String.IsNullOrEmpty(str) Then str = sistema.identifier("Win32_Processor", "ProcessorId")
        Return str
    End Function

    Private Function PlacaMaeID() As String
        Return sistema.identifier("Win32_BaseBoard", "SerialNumber")
    End Function

    Private Function identifier(ByVal wmiClass As String, ByVal wmiProperty As String) As String
        Dim str As String = ""

        Using managementClass As ManagementClass = New ManagementClass(wmiClass)

            For Each instance As ManagementObject In managementClass.GetInstances()

                If String.IsNullOrWhiteSpace(str) Then

                    Try
                        str = instance(wmiProperty).ToString().Replace(".", "")
                        Exit For
                    Catch
                    End Try
                End If
            Next
        End Using

        Return str
    End Function

    Private Function GerarServerKeyRegEdit() As String
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

    Function ServidorRegistrado(ByVal serverKey As String) As Boolean
        Try
            Dim str As String = BitConverter.ToString(New SHA1CryptoServiceProvider().ComputeHash(Encoding.[Default].GetBytes(String.Format("{0}-LinearM@nit0r", CObj(sistema.SerialHD(False)))))).Replace("-", "")
            Return serverKey = str.ToLower()
        Catch ex As Exception
            Return False
        End Try
    End Function
End Module

