<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frminfocertificado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frminfocertificado))
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtdatavenc = New System.Windows.Forms.TextBox()
        Me.txtdataemi = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblsenha = New System.Windows.Forms.LinkLabel()
        Me.psenha = New System.Windows.Forms.Panel()
        Me.txtsenha = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtorg = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtrg = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.mskdata = New System.Windows.Forms.MaskedTextBox()
        Me.mskcpfresp = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtnomeresp = New System.Windows.Forms.TextBox()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtrazao = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mskcnpj = New System.Windows.Forms.MaskedTextBox()
        Me.txtdadosbruto = New System.Windows.Forms.TextBox()
        Me.txtrespbruto = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Grouper2 = New DFe_aplicativo.Grouper()
        Me.Grouper1 = New DFe_aplicativo.Grouper()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.psenha.SuspendLayout()
        Me.Grouper2.SuspendLayout()
        Me.Grouper1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(12, 91)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(39, 37)
        Me.PictureBox2.TabIndex = 94
        Me.PictureBox2.TabStop = False
        '
        'txtdatavenc
        '
        Me.txtdatavenc.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtdatavenc.Location = New System.Drawing.Point(323, 104)
        Me.txtdatavenc.Name = "txtdatavenc"
        Me.txtdatavenc.ReadOnly = True
        Me.txtdatavenc.Size = New System.Drawing.Size(148, 20)
        Me.txtdatavenc.TabIndex = 20
        Me.txtdatavenc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtdataemi
        '
        Me.txtdataemi.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtdataemi.Location = New System.Drawing.Point(143, 104)
        Me.txtdataemi.Name = "txtdataemi"
        Me.txtdataemi.ReadOnly = True
        Me.txtdataemi.Size = New System.Drawing.Size(145, 20)
        Me.txtdataemi.TabIndex = 17
        Me.txtdataemi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(320, 85)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(151, 15)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Data Hora Vencimento"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(140, 85)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(131, 15)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Data Hora Emissão"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(155, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Razão social empresa"
        '
        'lblsenha
        '
        Me.lblsenha.AutoSize = True
        Me.lblsenha.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblsenha.Location = New System.Drawing.Point(92, 110)
        Me.lblsenha.Name = "lblsenha"
        Me.lblsenha.Size = New System.Drawing.Size(83, 13)
        Me.lblsenha.TabIndex = 19
        Me.lblsenha.TabStop = True
        Me.lblsenha.Text = "Info Senha cert."
        Me.lblsenha.Visible = False
        '
        'psenha
        '
        Me.psenha.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.psenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.psenha.Controls.Add(Me.txtsenha)
        Me.psenha.Controls.Add(Me.Label12)
        Me.psenha.Location = New System.Drawing.Point(138, 37)
        Me.psenha.Name = "psenha"
        Me.psenha.Size = New System.Drawing.Size(175, 53)
        Me.psenha.TabIndex = 18
        Me.psenha.Visible = False
        '
        'txtsenha
        '
        Me.txtsenha.BackColor = System.Drawing.Color.White
        Me.txtsenha.Location = New System.Drawing.Point(23, 19)
        Me.txtsenha.Name = "txtsenha"
        Me.txtsenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtsenha.Size = New System.Drawing.Size(121, 20)
        Me.txtsenha.TabIndex = 21
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(30, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 16)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Informe a senha"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LinkLabel1.Location = New System.Drawing.Point(385, 21)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(51, 13)
        Me.LinkLabel1.TabIndex = 17
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Visualizar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(345, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 16)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "CPF Responsável"
        '
        'txtorg
        '
        Me.txtorg.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtorg.Location = New System.Drawing.Point(381, 103)
        Me.txtorg.Name = "txtorg"
        Me.txtorg.PasswordChar = Global.Microsoft.VisualBasic.ChrW(64)
        Me.txtorg.ReadOnly = True
        Me.txtorg.Size = New System.Drawing.Size(78, 20)
        Me.txtorg.TabIndex = 15
        Me.txtorg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(209, 87)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "RG Responsável"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(378, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Orgão expididor"
        '
        'txtrg
        '
        Me.txtrg.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtrg.Location = New System.Drawing.Point(212, 103)
        Me.txtrg.Name = "txtrg"
        Me.txtrg.PasswordChar = Global.Microsoft.VisualBasic.ChrW(64)
        Me.txtrg.ReadOnly = True
        Me.txtrg.Size = New System.Drawing.Size(86, 20)
        Me.txtrg.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(2, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Data Nacimento"
        '
        'mskdata
        '
        Me.mskdata.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mskdata.Location = New System.Drawing.Point(5, 103)
        Me.mskdata.Mask = "00/00/0000"
        Me.mskdata.Name = "mskdata"
        Me.mskdata.PasswordChar = Global.Microsoft.VisualBasic.ChrW(64)
        Me.mskdata.ReadOnly = True
        Me.mskdata.Size = New System.Drawing.Size(81, 20)
        Me.mskdata.TabIndex = 9
        Me.mskdata.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'mskcpfresp
        '
        Me.mskcpfresp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mskcpfresp.Location = New System.Drawing.Point(348, 64)
        Me.mskcpfresp.Mask = "000,000,000-00"
        Me.mskcpfresp.Name = "mskcpfresp"
        Me.mskcpfresp.PasswordChar = Global.Microsoft.VisualBasic.ChrW(64)
        Me.mskcpfresp.ReadOnly = True
        Me.mskcpfresp.Size = New System.Drawing.Size(112, 20)
        Me.mskcpfresp.TabIndex = 7
        Me.mskcpfresp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Nome Responsável"
        '
        'txtnomeresp
        '
        Me.txtnomeresp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtnomeresp.Location = New System.Drawing.Point(6, 64)
        Me.txtnomeresp.Name = "txtnomeresp"
        Me.txtnomeresp.PasswordChar = Global.Microsoft.VisualBasic.ChrW(64)
        Me.txtnomeresp.ReadOnly = True
        Me.txtnomeresp.Size = New System.Drawing.Size(293, 20)
        Me.txtnomeresp.TabIndex = 7
        '
        'txtemail
        '
        Me.txtemail.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtemail.Location = New System.Drawing.Point(63, 62)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.ReadOnly = True
        Me.txtemail.Size = New System.Drawing.Size(408, 20)
        Me.txtemail.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(9, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "E-mail:"
        '
        'txtrazao
        '
        Me.txtrazao.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtrazao.Location = New System.Drawing.Point(158, 36)
        Me.txtrazao.Name = "txtrazao"
        Me.txtrazao.ReadOnly = True
        Me.txtrazao.Size = New System.Drawing.Size(313, 20)
        Me.txtrazao.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(9, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CNPJ /CPF"
        '
        'mskcnpj
        '
        Me.mskcnpj.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.mskcnpj.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.mskcnpj.Location = New System.Drawing.Point(9, 36)
        Me.mskcnpj.Name = "mskcnpj"
        Me.mskcnpj.ReadOnly = True
        Me.mskcnpj.Size = New System.Drawing.Size(125, 20)
        Me.mskcnpj.TabIndex = 0
        Me.mskcnpj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mskcnpj.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtdadosbruto
        '
        Me.txtdadosbruto.Location = New System.Drawing.Point(15, 469)
        Me.txtdadosbruto.Multiline = True
        Me.txtdadosbruto.Name = "txtdadosbruto"
        Me.txtdadosbruto.Size = New System.Drawing.Size(475, 11)
        Me.txtdadosbruto.TabIndex = 7
        '
        'txtrespbruto
        '
        Me.txtrespbruto.Location = New System.Drawing.Point(12, 358)
        Me.txtrespbruto.Multiline = True
        Me.txtrespbruto.Name = "txtrespbruto"
        Me.txtrespbruto.Size = New System.Drawing.Size(478, 10)
        Me.txtrespbruto.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(518, 82)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(518, 54)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Grouper2
        '
        Me.Grouper2.BackgroundColor = System.Drawing.Color.White
        Me.Grouper2.BackgroundGradientColor = System.Drawing.SystemColors.ButtonShadow
        Me.Grouper2.BackgroundGradientMode = DFe_aplicativo.Grouper.GroupBoxGradientMode.Vertical
        Me.Grouper2.BorderColor = System.Drawing.Color.Black
        Me.Grouper2.BorderThickness = 1.0!
        Me.Grouper2.Controls.Add(Me.lblsenha)
        Me.Grouper2.Controls.Add(Me.psenha)
        Me.Grouper2.Controls.Add(Me.txtnomeresp)
        Me.Grouper2.Controls.Add(Me.LinkLabel1)
        Me.Grouper2.Controls.Add(Me.Label5)
        Me.Grouper2.Controls.Add(Me.Label6)
        Me.Grouper2.Controls.Add(Me.mskcpfresp)
        Me.Grouper2.Controls.Add(Me.txtorg)
        Me.Grouper2.Controls.Add(Me.mskdata)
        Me.Grouper2.Controls.Add(Me.Label9)
        Me.Grouper2.Controls.Add(Me.Label7)
        Me.Grouper2.Controls.Add(Me.Label8)
        Me.Grouper2.Controls.Add(Me.txtrg)
        Me.Grouper2.CustomGroupBoxColor = System.Drawing.Color.White
        Me.Grouper2.ForeColor = System.Drawing.Color.Black
        Me.Grouper2.GroupImage = Nothing
        Me.Grouper2.GroupTitle = "Responsável pelo Certificado"
        Me.Grouper2.Location = New System.Drawing.Point(6, 134)
        Me.Grouper2.Name = "Grouper2"
        Me.Grouper2.Padding = New System.Windows.Forms.Padding(20)
        Me.Grouper2.PaintGroupBox = False
        Me.Grouper2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Grouper2.RoundCorners = 12
        Me.Grouper2.ShadowColor = System.Drawing.Color.DarkGray
        Me.Grouper2.ShadowControl = True
        Me.Grouper2.ShadowThickness = 3
        Me.Grouper2.Size = New System.Drawing.Size(470, 133)
        Me.Grouper2.TabIndex = 115
        '
        'Grouper1
        '
        Me.Grouper1.BackgroundColor = System.Drawing.Color.White
        Me.Grouper1.BackgroundGradientColor = System.Drawing.Color.White
        Me.Grouper1.BackgroundGradientMode = DFe_aplicativo.Grouper.GroupBoxGradientMode.None
        Me.Grouper1.BorderColor = System.Drawing.Color.Black
        Me.Grouper1.BorderThickness = 1.0!
        Me.Grouper1.Controls.Add(Me.Grouper2)
        Me.Grouper1.Controls.Add(Me.Label1)
        Me.Grouper1.Controls.Add(Me.PictureBox2)
        Me.Grouper1.Controls.Add(Me.mskcnpj)
        Me.Grouper1.Controls.Add(Me.txtdatavenc)
        Me.Grouper1.Controls.Add(Me.txtrazao)
        Me.Grouper1.Controls.Add(Me.txtdataemi)
        Me.Grouper1.Controls.Add(Me.Label3)
        Me.Grouper1.Controls.Add(Me.Label11)
        Me.Grouper1.Controls.Add(Me.txtemail)
        Me.Grouper1.Controls.Add(Me.Label10)
        Me.Grouper1.Controls.Add(Me.Label2)
        Me.Grouper1.CustomGroupBoxColor = System.Drawing.Color.White
        Me.Grouper1.GroupImage = Nothing
        Me.Grouper1.GroupTitle = ""
        Me.Grouper1.Location = New System.Drawing.Point(6, 0)
        Me.Grouper1.Name = "Grouper1"
        Me.Grouper1.Padding = New System.Windows.Forms.Padding(20)
        Me.Grouper1.PaintGroupBox = False
        Me.Grouper1.RoundCorners = 10
        Me.Grouper1.ShadowColor = System.Drawing.Color.DarkGray
        Me.Grouper1.ShadowControl = True
        Me.Grouper1.ShadowThickness = 3
        Me.Grouper1.Size = New System.Drawing.Size(484, 276)
        Me.Grouper1.TabIndex = 11
        '
        'frminfocertificado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 276)
        Me.Controls.Add(Me.Grouper1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtrespbruto)
        Me.Controls.Add(Me.txtdadosbruto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frminfocertificado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informações do certificado digital selecionado"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.psenha.ResumeLayout(False)
        Me.psenha.PerformLayout()
        Me.Grouper2.ResumeLayout(False)
        Me.Grouper2.PerformLayout()
        Me.Grouper1.ResumeLayout(False)
        Me.Grouper1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtrg As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents mskdata As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskcpfresp As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtnomeresp As System.Windows.Forms.TextBox
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtrazao As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mskcnpj As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtdadosbruto As System.Windows.Forms.TextBox
    Friend WithEvents txtrespbruto As System.Windows.Forms.TextBox
    Friend WithEvents txtorg As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtdatavenc As System.Windows.Forms.TextBox
    Friend WithEvents txtdataemi As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents psenha As System.Windows.Forms.Panel
    Friend WithEvents txtsenha As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblsenha As System.Windows.Forms.LinkLabel
    Friend WithEvents Grouper2 As DFe_aplicativo.Grouper
    Friend WithEvents Grouper1 As DFe_aplicativo.Grouper
End Class
