Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports SevenZip
Imports System
Imports System.IO
Imports System.Windows.Forms


Public Class clsZip
    Public Function compactaArquivo(ByVal arquivoOrigem As String, Optional ByVal arquivoDestino As String = "", Optional ByVal strPathLib As String = "") As Boolean
        Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
        Dim flag As Boolean

        Try

            If Operators.CompareString(strPathLib.Trim(), "", False) = 0 Then
                strPathLib = AppDomain.CurrentDomain.BaseDirectory.ToString()
                strPathLib = strPathLib.Remove(strPathLib.LastIndexOf("\"))
            End If

            SevenZipBase.SetLibraryPath(strPathLib & "\7z.dll")
            Dim strArray As String() = New String(0) {arquivoOrigem}

            If Operators.CompareString(arquivoDestino.Trim(), "", False) = 0 Then
                Dim withoutExtension As String = Path.GetFileNameWithoutExtension(arquivoOrigem)
                arquivoDestino = Path.GetDirectoryName(arquivoOrigem) & "\" & withoutExtension & ".7z"
            End If

            Dim theCompressor As New SevenZipCompressor()
            With theCompressor
                .ArchiveFormat = OutArchiveFormat.SevenZip
                .CompressionMode = CompressionMode.Create
                .CompressionMethod = CompressionMethod.Default
                .DirectoryStructure = False
                .CompressionLevel = CompressionLevel.Ultra
                .CompressFiles(arquivoDestino, strArray)
            End With


            flag = True
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Dim num As Integer = CInt(Interaction.MsgBox(CObj(ex.Message), MsgBoxStyle.Exclamation, CObj(Nothing)))
            flag = False
            ProjectData.ClearProjectError()
        End Try

        Return flag
    End Function

    Public Function descompactaArquivo(ByVal arquivoOrigem As String, ByVal arquivoDestino As String) As Boolean
        Dim flag As Boolean

        Try
           
            Dim Extractor As New SevenZipExtractor(arquivoOrigem)
            Extractor.ExtractArchive(arquivoDestino)

            flag = True
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Dim num As Integer = CInt(Interaction.MsgBox(CObj(ex.Message), MsgBoxStyle.OkOnly, CObj(Nothing)))
            flag = False
            ProjectData.ClearProjectError()
        End Try

        Return flag
    End Function

    Public Function Compress7Zip(ByVal cArqIn As String, ByVal cArqOut As String) As Object
        SevenZipBase.SetLibraryPath("c:\temp\zip\7z.dll")
        Dim strArray As String() = New String(1) {cArqIn, "c:\temp\zip\nfce2.log"}

        Dim theCompressor As New SevenZipCompressor()
        With theCompressor
            .ArchiveFormat = OutArchiveFormat.SevenZip
            .CompressionMode = CompressionMode.Create
            .CompressionMethod = CompressionMethod.Default
            .DirectoryStructure = False
            .CompressionLevel = CompressionLevel.Ultra
            .CompressFilesEncrypted(cArqOut, "1234", strArray)
        End With
        Dim num As Integer = CInt(Interaction.MsgBox(CObj("Compactado!!!"), MsgBoxStyle.OkOnly, CObj(Nothing)))
        Return CObj(True)
    End Function
End Class
