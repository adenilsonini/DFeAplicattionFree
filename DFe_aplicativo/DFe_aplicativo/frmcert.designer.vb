<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcert
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExcluirCertificadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformaçõesCertificadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.addcertNoWindowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CertificadoA3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CertificadoSistemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Grouper2 = New DFe_aplicativo.Grouper()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvcert = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.cnpj_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.razao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Data_Venc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.senha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.serial_certgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vencido_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grouper1 = New DFe_aplicativo.Grouper()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtsenha = New System.Windows.Forms.TextBox()
        Me.txtcaminho = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.Grouper2.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvcert, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grouper1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcluirCertificadoToolStripMenuItem, Me.InformaçõesCertificadoToolStripMenuItem, Me.addcertNoWindowsToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(256, 70)
        '
        'ExcluirCertificadoToolStripMenuItem
        '
        Me.ExcluirCertificadoToolStripMenuItem.Name = "ExcluirCertificadoToolStripMenuItem"
        Me.ExcluirCertificadoToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.ExcluirCertificadoToolStripMenuItem.Text = "Excluir Certificado"
        '
        'InformaçõesCertificadoToolStripMenuItem
        '
        Me.InformaçõesCertificadoToolStripMenuItem.Name = "InformaçõesCertificadoToolStripMenuItem"
        Me.InformaçõesCertificadoToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.InformaçõesCertificadoToolStripMenuItem.Text = "Informações certificado"
        '
        'addcertNoWindowsToolStripMenuItem
        '
        Me.addcertNoWindowsToolStripMenuItem.Name = "addcertNoWindowsToolStripMenuItem"
        Me.addcertNoWindowsToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.addcertNoWindowsToolStripMenuItem.Text = "Adicionar Certificado no Windows"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CertificadoA3ToolStripMenuItem, Me.CertificadoSistemaToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(221, 48)
        '
        'CertificadoA3ToolStripMenuItem
        '
        Me.CertificadoA3ToolStripMenuItem.Name = "CertificadoA3ToolStripMenuItem"
        Me.CertificadoA3ToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.CertificadoA3ToolStripMenuItem.Text = "Certificado Windows A1/A3"
        '
        'CertificadoSistemaToolStripMenuItem
        '
        Me.CertificadoSistemaToolStripMenuItem.Name = "CertificadoSistemaToolStripMenuItem"
        Me.CertificadoSistemaToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.CertificadoSistemaToolStripMenuItem.Text = "Certificado no Sistema"
        '
        'Grouper2
        '
        Me.Grouper2.BackgroundColor = System.Drawing.Color.White
        Me.Grouper2.BackgroundGradientColor = System.Drawing.Color.SpringGreen
        Me.Grouper2.BackgroundGradientMode = DFe_aplicativo.Grouper.GroupBoxGradientMode.Vertical
        Me.Grouper2.BorderColor = System.Drawing.Color.Black
        Me.Grouper2.BorderThickness = 1.0!
        Me.Grouper2.Controls.Add(Me.PictureBox3)
        Me.Grouper2.Controls.Add(Me.Label3)
        Me.Grouper2.Controls.Add(Me.Button2)
        Me.Grouper2.Controls.Add(Me.Button1)
        Me.Grouper2.Controls.Add(Me.dgvcert)
        Me.Grouper2.CustomGroupBoxColor = System.Drawing.Color.White
        Me.Grouper2.GroupImage = Nothing
        Me.Grouper2.GroupTitle = "Certificados no repositório do sistema"
        Me.Grouper2.Location = New System.Drawing.Point(6, 87)
        Me.Grouper2.Name = "Grouper2"
        Me.Grouper2.Padding = New System.Windows.Forms.Padding(20)
        Me.Grouper2.PaintGroupBox = False
        Me.Grouper2.RoundCorners = 10
        Me.Grouper2.ShadowColor = System.Drawing.Color.DarkGray
        Me.Grouper2.ShadowControl = False
        Me.Grouper2.ShadowThickness = 3
        Me.Grouper2.Size = New System.Drawing.Size(602, 319)
        Me.Grouper2.TabIndex = 17
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.DFe_aplicativo.My.Resources.Resources.certif1
        Me.PictureBox3.Location = New System.Drawing.Point(283, 148)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(36, 22)
        Me.PictureBox3.TabIndex = 16
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(23, 289)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(260, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Carregando Informações, aguarde...."
        Me.Label3.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Gainsboro
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.Red
        Me.Button2.Image = Global.DFe_aplicativo.My.Resources.Resources.block
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(474, 282)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(122, 30)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "&Cancelar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gainsboro
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.Blue
        Me.Button1.Image = Global.DFe_aplicativo.My.Resources.Resources.tick1
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(348, 282)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 30)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "&Ok"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'dgvcert
        '
        Me.dgvcert.AllowUserToAddRows = False
        Me.dgvcert.AllowUserToDeleteRows = False
        Me.dgvcert.AllowUserToResizeColumns = False
        Me.dgvcert.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvcert.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvcert.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvcert.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvcert.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.cnpj_grid, Me.razao, Me.Data_Venc, Me.senha, Me.serial_certgrid, Me.vencido_grid})
        Me.dgvcert.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvcert.EnableHeadersVisualStyles = False
        Me.dgvcert.Location = New System.Drawing.Point(6, 30)
        Me.dgvcert.Name = "dgvcert"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvcert.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvcert.RowHeadersVisible = False
        Me.dgvcert.RowHeadersWidth = 24
        Me.dgvcert.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvcert.Size = New System.Drawing.Size(590, 246)
        Me.dgvcert.TabIndex = 10
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 25
        '
        'cnpj_grid
        '
        Me.cnpj_grid.HeaderText = "CNPJ/CPF"
        Me.cnpj_grid.Name = "cnpj_grid"
        '
        'razao
        '
        Me.razao.HeaderText = "Nome"
        Me.razao.Name = "razao"
        Me.razao.Width = 320
        '
        'Data_Venc
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Data_Venc.DefaultCellStyle = DataGridViewCellStyle3
        Me.Data_Venc.HeaderText = "Data Venc."
        Me.Data_Venc.Name = "Data_Venc"
        Me.Data_Venc.Width = 125
        '
        'senha
        '
        Me.senha.HeaderText = "senha"
        Me.senha.Name = "senha"
        Me.senha.Visible = False
        '
        'serial_certgrid
        '
        Me.serial_certgrid.HeaderText = "Serial cert"
        Me.serial_certgrid.Name = "serial_certgrid"
        Me.serial_certgrid.Visible = False
        '
        'vencido_grid
        '
        Me.vencido_grid.HeaderText = "vencido_grid"
        Me.vencido_grid.Name = "vencido_grid"
        Me.vencido_grid.Visible = False
        '
        'Grouper1
        '
        Me.Grouper1.BackgroundColor = System.Drawing.Color.White
        Me.Grouper1.BackgroundGradientColor = System.Drawing.Color.SpringGreen
        Me.Grouper1.BackgroundGradientMode = DFe_aplicativo.Grouper.GroupBoxGradientMode.Vertical
        Me.Grouper1.BorderColor = System.Drawing.Color.Black
        Me.Grouper1.BorderThickness = 1.0!
        Me.Grouper1.Controls.Add(Me.PictureBox2)
        Me.Grouper1.Controls.Add(Me.Button4)
        Me.Grouper1.Controls.Add(Me.Label2)
        Me.Grouper1.Controls.Add(Me.PictureBox1)
        Me.Grouper1.Controls.Add(Me.Label1)
        Me.Grouper1.Controls.Add(Me.txtsenha)
        Me.Grouper1.Controls.Add(Me.txtcaminho)
        Me.Grouper1.Controls.Add(Me.Button3)
        Me.Grouper1.CustomGroupBoxColor = System.Drawing.Color.White
        Me.Grouper1.GroupImage = Nothing
        Me.Grouper1.GroupTitle = ""
        Me.Grouper1.Location = New System.Drawing.Point(6, 0)
        Me.Grouper1.Name = "Grouper1"
        Me.Grouper1.Padding = New System.Windows.Forms.Padding(20)
        Me.Grouper1.PaintGroupBox = False
        Me.Grouper1.RoundCorners = 10
        Me.Grouper1.ShadowColor = System.Drawing.Color.DarkGray
        Me.Grouper1.ShadowControl = False
        Me.Grouper1.ShadowThickness = 3
        Me.Grouper1.Size = New System.Drawing.Size(602, 81)
        Me.Grouper1.TabIndex = 16
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = Global.DFe_aplicativo.My.Resources.Resources.cert_a3
        Me.PictureBox2.Location = New System.Drawing.Point(7, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(81, 63)
        Me.PictureBox2.TabIndex = 17
        Me.PictureBox2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox2, "Clique aqui para carregar certificado A3")
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.Location = New System.Drawing.Point(490, 45)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(106, 23)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Importar"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(382, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Senha Cert."
        '
        'PictureBox1
        '
        Me.PictureBox1.ContextMenuStrip = Me.ContextMenuStrip2
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.DFe_aplicativo.My.Resources.Resources._002cert
        Me.PictureBox1.Location = New System.Drawing.Point(7, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(74, 57)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(91, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Caminho Arquivo .pfx"
        '
        'txtsenha
        '
        Me.txtsenha.Location = New System.Drawing.Point(385, 47)
        Me.txtsenha.Name = "txtsenha"
        Me.txtsenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtsenha.Size = New System.Drawing.Size(99, 20)
        Me.txtsenha.TabIndex = 3
        '
        'txtcaminho
        '
        Me.txtcaminho.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtcaminho.Location = New System.Drawing.Point(94, 46)
        Me.txtcaminho.Name = "txtcaminho"
        Me.txtcaminho.ReadOnly = True
        Me.txtcaminho.Size = New System.Drawing.Size(252, 20)
        Me.txtcaminho.TabIndex = 1
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Image = Global.DFe_aplicativo.My.Resources.Resources.door_open_in
        Me.Button3.Location = New System.Drawing.Point(347, 47)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(29, 19)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "..."
        Me.Button3.UseVisualStyleBackColor = False
        '
        'frmcert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 412)
        Me.Controls.Add(Me.Grouper2)
        Me.Controls.Add(Me.Grouper1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmcert"
        Me.Text = "Gerenciador de Certificado Digital"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.Grouper2.ResumeLayout(False)
        Me.Grouper2.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvcert, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grouper1.ResumeLayout(False)
        Me.Grouper1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvcert As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents txtsenha As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtcaminho As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExcluirCertificadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Grouper1 As DFe_aplicativo.Grouper
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Grouper2 As DFe_aplicativo.Grouper
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CertificadoA3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CertificadoSistemaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformaçõesCertificadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents addcertNoWindowsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents cnpj_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents razao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Data_Venc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents senha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents serial_certgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vencido_grid As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
