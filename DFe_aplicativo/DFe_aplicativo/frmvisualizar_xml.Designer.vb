<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmvisualizar_xml
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmvisualizar_xml))
        Me.txtxml = New FastColoredTextBoxNS.FastColoredTextBox()
        CType(Me.txtxml, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtxml
        '
        Me.txtxml.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.txtxml.AutoScrollMinSize = New System.Drawing.Size(179, 14)
        Me.txtxml.BackBrush = Nothing
        Me.txtxml.CharHeight = 14
        Me.txtxml.CharWidth = 8
        Me.txtxml.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtxml.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtxml.IsReplaceMode = False
        Me.txtxml.Location = New System.Drawing.Point(6, 6)
        Me.txtxml.Name = "txtxml"
        Me.txtxml.Paddings = New System.Windows.Forms.Padding(0)
        Me.txtxml.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtxml.ServiceColors = CType(resources.GetObject("txtxml.ServiceColors"), FastColoredTextBoxNS.ServiceColors)
        Me.txtxml.Size = New System.Drawing.Size(941, 494)
        Me.txtxml.TabIndex = 0
        Me.txtxml.Text = "FastColoredTextBox1"
        Me.txtxml.Zoom = 100
        '
        'frmvisualizar_xml
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 506)
        Me.Controls.Add(Me.txtxml)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmvisualizar_xml"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tela Visualizar XML"
        CType(Me.txtxml, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtxml As FastColoredTextBoxNS.FastColoredTextBox
End Class
