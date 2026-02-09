<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParCarga
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.chklocal = New System.Windows.Forms.CheckBox()
        Me.btncaminho = New System.Windows.Forms.Button()
        Me.txtcaminho = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.fbd1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chklocal
        '
        Me.chklocal.AutoSize = True
        Me.chklocal.ForeColor = System.Drawing.Color.Blue
        Me.chklocal.Location = New System.Drawing.Point(4, 9)
        Me.chklocal.Name = "chklocal"
        Me.chklocal.Size = New System.Drawing.Size(83, 17)
        Me.chklocal.TabIndex = 108
        Me.chklocal.Text = "Carga Local"
        Me.chklocal.UseVisualStyleBackColor = True
        '
        'btncaminho
        '
        Me.btncaminho.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btncaminho.Enabled = False
        Me.btncaminho.Location = New System.Drawing.Point(430, 32)
        Me.btncaminho.Margin = New System.Windows.Forms.Padding(4)
        Me.btncaminho.Name = "btncaminho"
        Me.btncaminho.Size = New System.Drawing.Size(43, 24)
        Me.btncaminho.TabIndex = 104
        Me.btncaminho.Text = ". . ."
        Me.btncaminho.UseVisualStyleBackColor = False
        '
        'txtcaminho
        '
        Me.txtcaminho.BackColor = System.Drawing.Color.White
        Me.txtcaminho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcaminho.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcaminho.Location = New System.Drawing.Point(4, 33)
        Me.txtcaminho.Margin = New System.Windows.Forms.Padding(4)
        Me.txtcaminho.Name = "txtcaminho"
        Me.txtcaminho.ReadOnly = True
        Me.txtcaminho.Size = New System.Drawing.Size(426, 22)
        Me.txtcaminho.TabIndex = 97
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.chklocal)
        Me.Panel1.Controls.Add(Me.txtcaminho)
        Me.Panel1.Controls.Add(Me.btncaminho)
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(476, 65)
        Me.Panel1.TabIndex = 111
        '
        'frmParCarga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(481, 69)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmParCarga"
        Me.Text = "Parametros de Carga"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents chklocal As CheckBox
    Friend WithEvents btncaminho As Button
    Friend WithEvents txtcaminho As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents fbd1 As FolderBrowserDialog
End Class
