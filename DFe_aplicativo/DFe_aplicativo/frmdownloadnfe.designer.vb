<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmdownloadnfe
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmdownloadnfe))
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.txtcaptcha = New System.Windows.Forms.TextBox()
        Me.picerro = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bar = New System.Windows.Forms.ProgressBar()
        Me.picnfe = New System.Windows.Forms.PictureBox()
        Me.bntnovaconsulta = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.bntconsulta = New System.Windows.Forms.Button()
        Me.Dialogo = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkvisualizar = New System.Windows.Forms.CheckBox()
        Me.txtchave = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblcertificado = New System.Windows.Forms.Label()
        Me.tdownload = New System.Windows.Forms.Timer(Me.components)
        Me.lbltimer = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.picCapture = New System.Windows.Forms.PictureBox()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.picerro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picnfe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(6, 5)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScrollBarsEnabled = False
        Me.WebBrowser1.Size = New System.Drawing.Size(624, 111)
        Me.WebBrowser1.TabIndex = 46
        Me.WebBrowser1.Visible = False
        Me.WebBrowser1.WebBrowserShortcutsEnabled = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.LinkColor = System.Drawing.Color.Blue
        Me.LinkLabel3.Location = New System.Drawing.Point(262, 3)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(54, 13)
        Me.LinkLabel3.TabIndex = 87
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Sefaz MG"
        Me.ToolTip1.SetToolTip(Me.LinkLabel3, "nfe.fazenda.mg.gov.br")
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(133, 3)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(123, 13)
        Me.LinkLabel2.TabIndex = 86
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "www.nfe.fazenda.gov.br"
        Me.ToolTip1.SetToolTip(Me.LinkLabel2, "www.nfe.fazenda.gov.br")
        '
        'txtcaptcha
        '
        Me.txtcaptcha.BackColor = System.Drawing.Color.White
        Me.txtcaptcha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcaptcha.Location = New System.Drawing.Point(6, 67)
        Me.txtcaptcha.MaxLength = 6
        Me.txtcaptcha.Name = "txtcaptcha"
        Me.txtcaptcha.Size = New System.Drawing.Size(82, 20)
        Me.txtcaptcha.TabIndex = 60
        '
        'picerro
        '
        Me.picerro.BackColor = System.Drawing.Color.White
        Me.picerro.Location = New System.Drawing.Point(210, 107)
        Me.picerro.Name = "picerro"
        Me.picerro.Size = New System.Drawing.Size(313, 22)
        Me.picerro.TabIndex = 83
        Me.picerro.TabStop = False
        Me.picerro.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 15)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "1"
        Me.Label1.Visible = False
        '
        'bar
        '
        Me.bar.Location = New System.Drawing.Point(112, 73)
        Me.bar.Name = "bar"
        Me.bar.Size = New System.Drawing.Size(92, 12)
        Me.bar.TabIndex = 81
        Me.bar.Visible = False
        '
        'picnfe
        '
        Me.picnfe.Location = New System.Drawing.Point(527, 6)
        Me.picnfe.Name = "picnfe"
        Me.picnfe.Size = New System.Drawing.Size(103, 94)
        Me.picnfe.TabIndex = 80
        Me.picnfe.TabStop = False
        '
        'bntnovaconsulta
        '
        Me.bntnovaconsulta.Enabled = False
        Me.bntnovaconsulta.ForeColor = System.Drawing.Color.Red
        Me.bntnovaconsulta.Location = New System.Drawing.Point(216, 67)
        Me.bntnovaconsulta.Name = "bntnovaconsulta"
        Me.bntnovaconsulta.Size = New System.Drawing.Size(94, 23)
        Me.bntnovaconsulta.TabIndex = 79
        Me.bntnovaconsulta.Text = "&Nova Download"
        Me.bntnovaconsulta.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(7, 70)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(99, 13)
        Me.LinkLabel1.TabIndex = 78
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Recarregar imagem"
        '
        'bntconsulta
        '
        Me.bntconsulta.Enabled = False
        Me.bntconsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntconsulta.ForeColor = System.Drawing.Color.Black
        Me.bntconsulta.Location = New System.Drawing.Point(110, 67)
        Me.bntconsulta.Name = "bntconsulta"
        Me.bntconsulta.Size = New System.Drawing.Size(100, 23)
        Me.bntconsulta.TabIndex = 76
        Me.bntconsulta.Text = "&Download XML"
        Me.bntconsulta.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.chkvisualizar)
        Me.Panel1.Controls.Add(Me.txtchave)
        Me.Panel1.Controls.Add(Me.LinkLabel3)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.LinkLabel2)
        Me.Panel1.Controls.Add(Me.txtcaptcha)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.bntconsulta)
        Me.Panel1.Controls.Add(Me.bntnovaconsulta)
        Me.Panel1.Location = New System.Drawing.Point(206, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(317, 95)
        Me.Panel1.TabIndex = 88
        '
        'chkvisualizar
        '
        Me.chkvisualizar.AutoSize = True
        Me.chkvisualizar.Location = New System.Drawing.Point(216, 44)
        Me.chkvisualizar.Name = "chkvisualizar"
        Me.chkvisualizar.Size = New System.Drawing.Size(70, 17)
        Me.chkvisualizar.TabIndex = 92
        Me.chkvisualizar.Text = "Visualizar"
        Me.chkvisualizar.UseVisualStyleBackColor = True
        Me.chkvisualizar.Visible = False
        '
        'txtchave
        '
        Me.txtchave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtchave.Location = New System.Drawing.Point(6, 19)
        Me.txtchave.Mask = "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000"
        Me.txtchave.Name = "txtchave"
        Me.txtchave.Size = New System.Drawing.Size(304, 20)
        Me.txtchave.TabIndex = 88
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Código Imagem"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 13)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Chave de Acesso da NFe"
        '
        'lblcertificado
        '
        Me.lblcertificado.AutoSize = True
        Me.lblcertificado.Location = New System.Drawing.Point(3, 131)
        Me.lblcertificado.Name = "lblcertificado"
        Me.lblcertificado.Size = New System.Drawing.Size(39, 13)
        Me.lblcertificado.TabIndex = 89
        Me.lblcertificado.Text = "Label4"
        Me.lblcertificado.Visible = False
        '
        'lbltimer
        '
        Me.lbltimer.AutoSize = True
        Me.lbltimer.Location = New System.Drawing.Point(540, 57)
        Me.lbltimer.Name = "lbltimer"
        Me.lbltimer.Size = New System.Drawing.Size(13, 13)
        Me.lbltimer.TabIndex = 91
        Me.lbltimer.Text = "0"
        Me.lbltimer.Visible = False
        '
        'picCapture
        '
        Me.picCapture.BackColor = System.Drawing.Color.White
        Me.picCapture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picCapture.Location = New System.Drawing.Point(10, 5)
        Me.picCapture.Name = "picCapture"
        Me.picCapture.Size = New System.Drawing.Size(194, 62)
        Me.picCapture.TabIndex = 77
        Me.picCapture.TabStop = False
        '
        'dgv1
        '
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.dgv1.Location = New System.Drawing.Point(24, 168)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(493, 150)
        Me.dgv1.TabIndex = 92
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 400
        '
        'frmdownloadnfe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(635, 105)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.lbltimer)
        Me.Controls.Add(Me.lblcertificado)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.picerro)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bar)
        Me.Controls.Add(Me.picnfe)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.picCapture)
        Me.Controls.Add(Me.WebBrowser1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmdownloadnfe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Download do Arquivo XML da NFe          "
        CType(Me.picerro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picnfe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtcaptcha As System.Windows.Forms.TextBox
    Friend WithEvents picerro As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bar As System.Windows.Forms.ProgressBar
    Friend WithEvents picnfe As System.Windows.Forms.PictureBox
    Friend WithEvents bntnovaconsulta As System.Windows.Forms.Button
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents bntconsulta As System.Windows.Forms.Button
    Friend WithEvents Dialogo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblcertificado As System.Windows.Forms.Label
    Friend WithEvents txtchave As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tdownload As System.Windows.Forms.Timer
    Friend WithEvents lbltimer As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents chkvisualizar As System.Windows.Forms.CheckBox
    Friend WithEvents picCapture As System.Windows.Forms.PictureBox
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
