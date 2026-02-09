<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmlernfe
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmlernfe))
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.bntimpor = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bar = New System.Windows.Forms.ProgressBar()
        Me.picnfe = New System.Windows.Forms.PictureBox()
        Me.bntnovaconsulta = New System.Windows.Forms.Button()
        Me.Dialogo = New System.Windows.Forms.OpenFileDialog()
        Me.picerro = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lbliten = New System.Windows.Forms.Label()
        Me.txtvlr = New System.Windows.Forms.TextBox()
        Me.txtcod = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtchave = New System.Windows.Forms.MaskedTextBox()
        Me.bntconsulta = New System.Windows.Forms.Button()
        Me.txtcaptcha = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtinfonfe = New System.Windows.Forms.TextBox()
        Me.picCapture = New System.Windows.Forms.PictureBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        CType(Me.picnfe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picerro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowser1.Location = New System.Drawing.Point(6, 116)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScriptErrorsSuppressed = True
        Me.WebBrowser1.ScrollBarsEnabled = False
        Me.WebBrowser1.Size = New System.Drawing.Size(633, 92)
        Me.WebBrowser1.TabIndex = 45
        Me.WebBrowser1.WebBrowserShortcutsEnabled = False
        '
        'bntimpor
        '
        Me.bntimpor.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.bntimpor.Location = New System.Drawing.Point(491, 25)
        Me.bntimpor.Name = "bntimpor"
        Me.bntimpor.Size = New System.Drawing.Size(30, 20)
        Me.bntimpor.TabIndex = 70
        Me.bntimpor.Text = ". . ."
        Me.bntimpor.UseVisualStyleBackColor = True
        Me.bntimpor.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(208, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 15)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "1"
        Me.Label1.Visible = False
        '
        'bar
        '
        Me.bar.Location = New System.Drawing.Point(6, 98)
        Me.bar.Name = "bar"
        Me.bar.Size = New System.Drawing.Size(198, 12)
        Me.bar.TabIndex = 68
        Me.bar.Visible = False
        '
        'picnfe
        '
        Me.picnfe.Location = New System.Drawing.Point(527, 5)
        Me.picnfe.Name = "picnfe"
        Me.picnfe.Size = New System.Drawing.Size(103, 98)
        Me.picnfe.TabIndex = 66
        Me.picnfe.TabStop = False
        '
        'bntnovaconsulta
        '
        Me.bntnovaconsulta.Enabled = False
        Me.bntnovaconsulta.ForeColor = System.Drawing.Color.Red
        Me.bntnovaconsulta.Location = New System.Drawing.Point(427, 69)
        Me.bntnovaconsulta.Name = "bntnovaconsulta"
        Me.bntnovaconsulta.Size = New System.Drawing.Size(94, 23)
        Me.bntnovaconsulta.TabIndex = 65
        Me.bntnovaconsulta.Text = "&Nova Download"
        Me.bntnovaconsulta.UseVisualStyleBackColor = True
        Me.bntnovaconsulta.Visible = False
        '
        'picerro
        '
        Me.picerro.BackColor = System.Drawing.Color.White
        Me.picerro.Location = New System.Drawing.Point(185, 286)
        Me.picerro.Name = "picerro"
        Me.picerro.Size = New System.Drawing.Size(314, 20)
        Me.picerro.TabIndex = 71
        Me.picerro.TabStop = False
        Me.picerro.Visible = False
        '
        'lbliten
        '
        Me.lbliten.AutoSize = True
        Me.lbliten.Location = New System.Drawing.Point(465, 51)
        Me.lbliten.Name = "lbliten"
        Me.lbliten.Size = New System.Drawing.Size(0, 13)
        Me.lbliten.TabIndex = 74
        Me.lbliten.Visible = False
        '
        'txtvlr
        '
        Me.txtvlr.Location = New System.Drawing.Point(192, -1)
        Me.txtvlr.Name = "txtvlr"
        Me.txtvlr.Size = New System.Drawing.Size(65, 20)
        Me.txtvlr.TabIndex = 63
        Me.txtvlr.Visible = False
        '
        'txtcod
        '
        Me.txtcod.Location = New System.Drawing.Point(114, -1)
        Me.txtcod.Name = "txtcod"
        Me.txtcod.Size = New System.Drawing.Size(65, 20)
        Me.txtcod.TabIndex = 62
        Me.txtcod.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(5, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Código Imagem"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtchave)
        Me.Panel1.Controls.Add(Me.txtvlr)
        Me.Panel1.Controls.Add(Me.txtcod)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.bntconsulta)
        Me.Panel1.Controls.Add(Me.txtcaptcha)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(206, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(318, 87)
        Me.Panel1.TabIndex = 76
        '
        'txtchave
        '
        Me.txtchave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtchave.Location = New System.Drawing.Point(6, 19)
        Me.txtchave.Mask = "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000"
        Me.txtchave.Name = "txtchave"
        Me.txtchave.Size = New System.Drawing.Size(304, 20)
        Me.txtchave.TabIndex = 89
        '
        'bntconsulta
        '
        Me.bntconsulta.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.bntconsulta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bntconsulta.Enabled = False
        Me.bntconsulta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bntconsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bntconsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntconsulta.ForeColor = System.Drawing.Color.Black
        Me.bntconsulta.Location = New System.Drawing.Point(139, 57)
        Me.bntconsulta.Name = "bntconsulta"
        Me.bntconsulta.Size = New System.Drawing.Size(170, 22)
        Me.bntconsulta.TabIndex = 59
        Me.bntconsulta.Text = "Capturar Dados NFe"
        Me.bntconsulta.UseVisualStyleBackColor = False
        '
        'txtcaptcha
        '
        Me.txtcaptcha.BackColor = System.Drawing.Color.White
        Me.txtcaptcha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcaptcha.Enabled = False
        Me.txtcaptcha.Location = New System.Drawing.Point(5, 58)
        Me.txtcaptcha.MaxLength = 6
        Me.txtcaptcha.Name = "txtcaptcha"
        Me.txtcaptcha.Size = New System.Drawing.Size(80, 20)
        Me.txtcaptcha.TabIndex = 60
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(5, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Chave de Acesso"
        '
        'dgv1
        '
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.dgv1.Location = New System.Drawing.Point(69, 312)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(508, 67)
        Me.dgv1.TabIndex = 77
        '
        'Column1
        '
        Me.Column1.HeaderText = "cont"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 50
        '
        'Column2
        '
        Me.Column2.HeaderText = "Descricao"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 400
        '
        'txtinfonfe
        '
        Me.txtinfonfe.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtinfonfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtinfonfe.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinfonfe.Location = New System.Drawing.Point(6, 5)
        Me.txtinfonfe.Multiline = True
        Me.txtinfonfe.Name = "txtinfonfe"
        Me.txtinfonfe.ReadOnly = True
        Me.txtinfonfe.Size = New System.Drawing.Size(194, 87)
        Me.txtinfonfe.TabIndex = 0
        Me.txtinfonfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtinfonfe.Visible = False
        '
        'picCapture
        '
        Me.picCapture.BackColor = System.Drawing.Color.White
        Me.picCapture.Location = New System.Drawing.Point(6, 5)
        Me.picCapture.Name = "picCapture"
        Me.picCapture.Size = New System.Drawing.Size(198, 87)
        Me.picCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCapture.TabIndex = 79
        Me.picCapture.TabStop = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(63, 5)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(77, 13)
        Me.LinkLabel1.TabIndex = 93
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Alterar Imagem"
        '
        'frmlernfe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(635, 307)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.picCapture)
        Me.Controls.Add(Me.txtinfonfe)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbliten)
        Me.Controls.Add(Me.picerro)
        Me.Controls.Add(Me.bntimpor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bar)
        Me.Controls.Add(Me.picnfe)
        Me.Controls.Add(Me.bntnovaconsulta)
        Me.Controls.Add(Me.WebBrowser1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmlernfe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura os dados da NFe do Porta Nacional"
        CType(Me.picnfe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picerro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents bntimpor As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bar As System.Windows.Forms.ProgressBar
    Friend WithEvents picnfe As System.Windows.Forms.PictureBox
    Friend WithEvents bntnovaconsulta As System.Windows.Forms.Button
    Friend WithEvents Dialogo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents picerro As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lbliten As System.Windows.Forms.Label
    Friend WithEvents txtvlr As System.Windows.Forms.TextBox
    Friend WithEvents txtcod As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents bntconsulta As System.Windows.Forms.Button
    Friend WithEvents txtcaptcha As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtchave As System.Windows.Forms.MaskedTextBox
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtinfonfe As System.Windows.Forms.TextBox
    Friend WithEvents picCapture As System.Windows.Forms.PictureBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel

End Class
