<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmresult_validacao
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
        Me.dgverro_xml = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txterro_valida_xml = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgverro_xml, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgverro_xml
        '
        Me.dgverro_xml.AllowUserToAddRows = False
        Me.dgverro_xml.AllowUserToDeleteRows = False
        Me.dgverro_xml.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgverro_xml.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.dgverro_xml.Location = New System.Drawing.Point(2, 3)
        Me.dgverro_xml.Name = "dgverro_xml"
        Me.dgverro_xml.RowHeadersVisible = False
        Me.dgverro_xml.Size = New System.Drawing.Size(263, 221)
        Me.dgverro_xml.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Tag XML Numero"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 245
        '
        'txterro_valida_xml
        '
        Me.txterro_valida_xml.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txterro_valida_xml.Location = New System.Drawing.Point(2, 264)
        Me.txterro_valida_xml.Multiline = True
        Me.txterro_valida_xml.Name = "txterro_valida_xml"
        Me.txterro_valida_xml.ReadOnly = True
        Me.txterro_valida_xml.Size = New System.Drawing.Size(263, 93)
        Me.txterro_valida_xml.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(-2, 237)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(230, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Erro encontrado abaixo"
        '
        'frmresult_validacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(267, 362)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txterro_valida_xml)
        Me.Controls.Add(Me.dgverro_xml)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmresult_validacao"
        Me.Text = "Resultado Validação XML"
        CType(Me.dgverro_xml, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgverro_xml As System.Windows.Forms.DataGridView
    Friend WithEvents txterro_valida_xml As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
