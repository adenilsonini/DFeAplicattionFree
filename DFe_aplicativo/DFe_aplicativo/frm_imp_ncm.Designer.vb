<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_imp_ncm
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
        Me.btnArquivo = New System.Windows.Forms.Button()
        Me.txtArquivo = New System.Windows.Forms.TextBox()
        Me.lblinfo = New System.Windows.Forms.Label()
        Me.optncm = New System.Windows.Forms.RadioButton()
        Me.optcest = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'btnArquivo
        '
        Me.btnArquivo.Location = New System.Drawing.Point(356, 29)
        Me.btnArquivo.Name = "btnArquivo"
        Me.btnArquivo.Size = New System.Drawing.Size(31, 23)
        Me.btnArquivo.TabIndex = 8
        Me.btnArquivo.Text = "..."
        Me.btnArquivo.UseVisualStyleBackColor = True
        '
        'txtArquivo
        '
        Me.txtArquivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArquivo.Location = New System.Drawing.Point(12, 30)
        Me.txtArquivo.Name = "txtArquivo"
        Me.txtArquivo.Size = New System.Drawing.Size(347, 22)
        Me.txtArquivo.TabIndex = 7
        '
        'lblinfo
        '
        Me.lblinfo.AutoSize = True
        Me.lblinfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblinfo.ForeColor = System.Drawing.Color.Blue
        Me.lblinfo.Location = New System.Drawing.Point(12, 55)
        Me.lblinfo.Name = "lblinfo"
        Me.lblinfo.Size = New System.Drawing.Size(55, 16)
        Me.lblinfo.TabIndex = 9
        Me.lblinfo.Text = "Label1"
        Me.lblinfo.Visible = False
        '
        'optncm
        '
        Me.optncm.AutoSize = True
        Me.optncm.Checked = True
        Me.optncm.Location = New System.Drawing.Point(12, 7)
        Me.optncm.Name = "optncm"
        Me.optncm.Size = New System.Drawing.Size(49, 17)
        Me.optncm.TabIndex = 10
        Me.optncm.TabStop = True
        Me.optncm.Text = "NCM"
        Me.optncm.UseVisualStyleBackColor = True
        '
        'optcest
        '
        Me.optcest.AutoSize = True
        Me.optcest.Location = New System.Drawing.Point(76, 7)
        Me.optcest.Name = "optcest"
        Me.optcest.Size = New System.Drawing.Size(53, 17)
        Me.optcest.TabIndex = 11
        Me.optcest.Text = "CEST"
        Me.optcest.UseVisualStyleBackColor = True
        '
        'frm_imp_ncm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 76)
        Me.Controls.Add(Me.optcest)
        Me.Controls.Add(Me.optncm)
        Me.Controls.Add(Me.lblinfo)
        Me.Controls.Add(Me.btnArquivo)
        Me.Controls.Add(Me.txtArquivo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_imp_ncm"
        Me.Text = "Importar NCM/CEST"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnArquivo As System.Windows.Forms.Button
    Friend WithEvents txtArquivo As System.Windows.Forms.TextBox
    Friend WithEvents lblinfo As System.Windows.Forms.Label
    Friend WithEvents optncm As System.Windows.Forms.RadioButton
    Friend WithEvents optcest As System.Windows.Forms.RadioButton
End Class
