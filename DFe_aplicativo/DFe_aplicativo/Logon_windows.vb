Imports System.Runtime.InteropServices
Imports System.Security.Principal

Module Logon_windows
    <DllImport("advapi32.dll")>
    Private Function LogonUser(ByVal lpszUserName As String, ByVal lpszDomain As String, ByVal lpszPassword As String, ByVal dwLogonType As Integer, ByVal dwLogonProvider As Integer, ByRef phToken As IntPtr) As Boolean

    End Function
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Public Function CloseHandle(ByVal handle As IntPtr) As Boolean

    End Function

    Private _windowsImpersonationContext As WindowsImpersonationContext
    Private _tokenHandle As IntPtr
    Const LOGON32_PROVIDER_DEFAULT As Integer = 0
    Const LOGON32_LOGON_INTERACTIVE As Integer = 2


    Public Function login_windows(ByVal userName As String, ByVal domain As String, ByVal passWord As String) As Boolean
        Dim returnValue As Boolean = LogonUser(userName, domain, passWord, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, _tokenHandle)

        If False = returnValue Then
            Return False
        End If

        Dim newId As WindowsIdentity = New WindowsIdentity(_tokenHandle)
        _windowsImpersonationContext = newId.Impersonate()
        Return True
    End Function

End Module
