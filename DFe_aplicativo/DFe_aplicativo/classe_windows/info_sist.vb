
Imports Microsoft.VisualBasic.Devices
Imports MySql.Data.MySqlClient
Imports System
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Win32
Imports System.IO.Compression


<DataContract>
Friend Class MonitoramentoClienteServidor
    <DataMember(Name:="server_name")>
    Public Property NomeServidor As String
    <DataMember(Name:="so")>
    Public Property SistemaOperacional As String
    <DataMember(Name:="hd_size")>
    Public Property TamanhoHD As Long
    <DataMember(Name:="hd_free")>
    Public Property HDLivre As Long
    <DataMember(Name:="ram_size")>
    Public Property TamanhoRam As ULong
    <DataMember(Name:="ram_free")>
    Public Property RamLivre As ULong
    <DataMember(Name:="driver_type")>
    Public Property DriverType As String

    Public Shared Function NomeMaquina() As String
        Try
            Return Environment.MachineName.ToLower()
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Function Informacoes() As MonitoramentoClienteServidor
        Dim servidor As MonitoramentoClienteServidor

        Try
            servidor = New MonitoramentoClienteServidor()
            servidor.NomeServidor = NomeMaquina()
            MonitoramentoClienteServidor.RecuperaInfoHD(servidor)
            MonitoramentoClienteServidor.RecuperaInfoRam(servidor)
        Catch ex As Exception
            Throw
        End Try

        Return servidor
    End Function

    Private Shared Sub RecuperaInfoHD(ByVal servidor As MonitoramentoClienteServidor)
        Try

            For Each drive As DriveInfo In DriveInfo.GetDrives()
                Dim str As String = MonitoramentoClienteServidor.RecuperaLocalMysqlData()

                If drive.IsReady Then
                    Dim ch As Char = str(0)
                    Dim lower1 As String = ch.ToString().ToLower()
                    ch = drive.Name(0)
                    Dim lower2 As String = ch.ToString().ToLower()

                    If lower1 = lower2 Then
                        servidor.TamanhoHD = drive.TotalSize / 1024L / 1024L
                        servidor.HDLivre = drive.TotalFreeSpace / 1024L / 1024L
                        servidor.DriverType = drive.DriveType.ToString()
                        Exit For
                    End If
                End If
            Next

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Shared Function RecuperaLocalMysqlData() As String
        Dim str As String = ""

        Try

            Using connection As MySqlConnection = DBHelper.ConexaoBD()

                Using mySqlCommand As MySqlCommand = New MySqlCommand("show variables where variable_name like 'datadir'", connection)
                    Dim mySqlDataReader As MySqlDataReader = mySqlCommand.ExecuteReader()
                    If mySqlDataReader.Read() Then str = mySqlDataReader.GetString(mySqlDataReader.GetOrdinal("value"))
                End Using
            End Using

        Catch ex As Exception
            '  Throw
        End Try

        Return str
    End Function

    Private Shared Sub RecuperaInfoRam(ByVal servidor As MonitoramentoClienteServidor)
        Try
            Dim computerInfo As ComputerInfo = New ComputerInfo()
            servidor.TamanhoRam = computerInfo.TotalPhysicalMemory / 1024UL / 1024UL
            servidor.RamLivre = computerInfo.AvailablePhysicalMemory / 1024UL / 1024UL
            servidor.SistemaOperacional = String.Format("{0} | {1} | {2}", CObj(computerInfo.OSPlatform), CObj(computerInfo.OSFullName), CObj(computerInfo.OSVersion))
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Shared Function Generate(ByVal user As String, ByVal salt As String) As String
        Using shA512 As SHA512 = shA512.Create()
            ''  Dim bytes As Byte() = Encoding.UTF8.GetBytes(New String(user.Reverse(Of Char)().ToArray(Of Char)()) & salt)
            '   Return BitConverter.ToString(shA512.ComputeHash(bytes)).Replace("-", String.Empty).ToString().ToLower()
        End Using
    End Function

    Public Shared Sub ComprimirArquivo(ByVal arquivo As String, ByVal destino As String)
        Dim arquivos As Dictionary(Of String, String) = New Dictionary(Of String, String)()
        arquivos.Add(arquivo, Path.GetFileName(arquivo))
        ComprimirArquivo(arquivos, destino)
        arquivos.Clear()
    End Sub

    Public Shared Sub ComprimirArquivo(ByVal arquivos As Dictionary(Of String, String), ByVal destino As String)
        Using destination As ZipArchive = ZipFile.Open(destino, ZipArchiveMode.Update)

            For Each arquivo As KeyValuePair(Of String, String) In arquivos
                destination.CreateEntryFromFile(arquivo.Key, arquivo.Value, CompressionLevel.Optimal)
            Next
        End Using
    End Sub

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

End Class

