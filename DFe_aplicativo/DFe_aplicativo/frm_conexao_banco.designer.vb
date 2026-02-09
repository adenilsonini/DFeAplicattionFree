<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_conexao_banco
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_conexao_banco))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.RoundPanel1 = New DFe_aplicativo.RoundPanel()
        Me.pic_Ico = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_Task = New System.Windows.Forms.Label()
        Me.lbl_Task_lbl = New System.Windows.Forms.Label()
        Me.RoundPanel1.SuspendLayout()
        CType(Me.pic_Ico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'RoundPanel1
        '
        Me.RoundPanel1.BackColor = System.Drawing.Color.Transparent
        Me.RoundPanel1.Controls.Add(Me.pic_Ico)
        Me.RoundPanel1.Controls.Add(Me.Label1)
        Me.RoundPanel1.Controls.Add(Me.lbl_Task)
        Me.RoundPanel1.Controls.Add(Me.lbl_Task_lbl)
        Me.RoundPanel1.Location = New System.Drawing.Point(0, 0)
        Me.RoundPanel1.Name = "RoundPanel1"
        Me.RoundPanel1.Radious = 25
        Me.RoundPanel1.Size = New System.Drawing.Size(341, 194)
        Me.RoundPanel1.TabIndex = 5
        Me.RoundPanel1.TabStop = False
        Me.RoundPanel1.Text = "Inciando Banco Dados..."
        Me.RoundPanel1.TitleBackColor = System.Drawing.Color.SteelBlue
        Me.RoundPanel1.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 16.25!, System.Drawing.FontStyle.Bold)
        Me.RoundPanel1.TitleForeColor = System.Drawing.Color.White
        Me.RoundPanel1.TitleHatchStyle = System.Drawing.Drawing2D.HatchStyle.Percent60
        '
        'pic_Ico
        '
        Me.pic_Ico.Image = CType(resources.GetObject("pic_Ico.Image"), System.Drawing.Image)
        Me.pic_Ico.Location = New System.Drawing.Point(21, 63)
        Me.pic_Ico.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pic_Ico.Name = "pic_Ico"
        Me.pic_Ico.Size = New System.Drawing.Size(297, 11)
        Me.pic_Ico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_Ico.TabIndex = 2
        Me.pic_Ico.TabStop = False
        Me.pic_Ico.WaitOnLoad = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(272, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Conectando no Banco de dados, aguarde..."
        '
        'lbl_Task
        '
        Me.lbl_Task.AutoSize = True
        Me.lbl_Task.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Task.Location = New System.Drawing.Point(63, 95)
        Me.lbl_Task.Name = "lbl_Task"
        Me.lbl_Task.Size = New System.Drawing.Size(107, 13)
        Me.lbl_Task.TabIndex = 0
        Me.lbl_Task.Text = "Conectando base...."
        '
        'lbl_Task_lbl
        '
        Me.lbl_Task_lbl.AutoSize = True
        Me.lbl_Task_lbl.Location = New System.Drawing.Point(21, 95)
        Me.lbl_Task_lbl.Name = "lbl_Task_lbl"
        Me.lbl_Task_lbl.Size = New System.Drawing.Size(42, 13)
        Me.lbl_Task_lbl.TabIndex = 3
        Me.lbl_Task_lbl.Text = "Status:"
        '
        'frm_conexao_banco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 195)
        Me.ControlBox = False
        Me.Controls.Add(Me.RoundPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_conexao_banco"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Status conexão banco"
        Me.TopMost = True
        Me.RoundPanel1.ResumeLayout(False)
        Me.RoundPanel1.PerformLayout()
        CType(Me.pic_Ico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_Task As System.Windows.Forms.Label
    Friend WithEvents pic_Ico As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_Task_lbl As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents RoundPanel1 As DFe_aplicativo.RoundPanel
End Class
