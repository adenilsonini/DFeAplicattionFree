Imports System.IO
Imports System.Xml
Imports System.Text
Imports FastColoredTextBoxNS

Public Class frmvisualizar_xml
    Dim texto As String
    Public Sub New(Optional ByVal sTexto As String = "")
        Me.InitializeComponent()
        Me.txtxml.Language = Language.XML
        texto = sTexto
    End Sub

    Private Sub frmvisualizar_xml_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub frmvisualizar_xml_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtxml.Text = FormatXML(texto)
    End Sub


    Public Shared Function FormatXML(ByVal xml As String) As String
        Dim str As String = ""
        Dim memoryStream As MemoryStream = New MemoryStream()
        Dim xmlTextWriter As XmlTextWriter = New XmlTextWriter(CType(memoryStream, Stream), Encoding.Unicode)
        Dim xmlDocument As XmlDocument = New XmlDocument()

        Try
            xmlDocument.LoadXml(xml)
            xmlTextWriter.Formatting = System.Xml.Formatting.Indented
            xmlDocument.WriteContentTo(CType(xmlTextWriter, XmlWriter))
            xmlTextWriter.Flush()
            memoryStream.Flush()
            memoryStream.Position = 0L
            str = New StreamReader(CType(memoryStream, Stream)).ReadToEnd()
        Catch ex As XmlException
        End Try

        memoryStream.Close()
        xmlTextWriter.Close()
        Return str
    End Function
End Class