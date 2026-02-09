Imports Microsoft.Win32


Public Class GetDotNetVersion
    Public Shared Function VersaoDOTNET() As String
        Dim strA As String = GetDotNetVersion.GetVersionFromRegistry()

        If String.Compare(strA, "4.5") >= 0 Then
            Dim str As String = GetDotNetVersion.Get45PlusFromRegistry()
            If str <> "" Then strA = str
        End If

        Return strA
    End Function

    Private Shared Function Get45PlusFromRegistry() As String
        Dim str As String = ""

        Using registryKey As RegistryKey = registryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\")

            If registryKey IsNot Nothing Then
                If registryKey.GetValue("Release") IsNot Nothing Then str = GetDotNetVersion.CheckFor45PlusVersion(CInt(registryKey.GetValue("Release")))
            End If
        End Using

        Return str
    End Function

    Private Shared Function CheckFor45PlusVersion(ByVal releaseKey As Integer) As String
        If releaseKey >= 528049 Then Return "4.8"
        If releaseKey >= 461814 Then Return "4.7.2"
        If releaseKey >= 461308 Then Return "4.7.1"
        If releaseKey >= 460798 Then Return "4.7"
        If releaseKey >= 394802 Then Return "4.6.2"
        If releaseKey >= 394254 Then Return "4.6.1"
        If releaseKey >= 393295 Then Return "4.6"
        If releaseKey >= 379893 Then Return "4.5.2"
        If releaseKey >= 378675 Then Return "4.5.1"
        Return If(releaseKey >= 378389, "4.5", "")
    End Function

    Private Shared Function GetVersionFromRegistry() As String
        Dim strA As String = ""

        Using registryKey1 As RegistryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "").OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\")

            For Each subKeyName1 As String In registryKey1.GetSubKeyNames()

                If subKeyName1.StartsWith("v") Then
                    Dim registryKey2 As RegistryKey = registryKey1.OpenSubKey(subKeyName1)
                    Dim strB1 As String = CStr(registryKey2.GetValue("Version", CObj("")))
                    Dim str1 As String = registryKey2.GetValue("SP", CObj("")).ToString()
                    Dim str2 As String = registryKey2.GetValue("Install", CObj("")).ToString()

                    If str2 = "" Then
                        If String.Compare(strA, strB1) < 0 Then strA = strB1
                    ElseIf str1 <> "" AndAlso str2 = "1" AndAlso String.Compare(strA, strB1) < 0 Then
                        strA = strB1
                    End If

                    If Not (strB1 <> "") Then

                        For Each subKeyName2 As String In registryKey2.GetSubKeyNames()
                            Dim registryKey3 As RegistryKey = registryKey2.OpenSubKey(subKeyName2)
                            Dim strB2 As String = CStr(registryKey3.GetValue("Version", CObj("")))
                            If strB2 <> "" Then str1 = registryKey3.GetValue("SP", CObj("")).ToString()
                            Dim str3 As String = registryKey3.GetValue("Install", CObj("")).ToString()

                            If str3 = "" Then
                                If String.Compare(strA, strB2) < 0 Then strA = strB2
                            ElseIf str1 <> "" AndAlso str3 = "1" Then
                                If String.Compare(strA, strB2) < 0 Then strA = strB2
                            ElseIf str3 = "1" AndAlso String.Compare(strA, strB2) < 0 Then
                                strA = strB2
                            End If
                        Next
                    End If
                End If
            Next
        End Using

        Return strA
    End Function
End Class
