<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmpesq_onedrive
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.pbDados = New System.Windows.Forms.ProgressBar()
        Me.txtxml = New System.Windows.Forms.TextBox()
        Me.lbltimer = New System.Windows.Forms.Label()
        Me.ginfo = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgvpesquisa = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.xml = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtcaminho = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtnome = New System.Windows.Forms.TextBox()
        Me.chkinicio = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtcnpj = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtnumero = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox2.SuspendLayout()
        Me.ginfo.SuspendLayout()
        CType(Me.dgvpesquisa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Gray
        Me.GroupBox2.Controls.Add(Me.pbDados)
        Me.GroupBox2.Controls.Add(Me.txtxml)
        Me.GroupBox2.Controls.Add(Me.lbltimer)
        Me.GroupBox2.Controls.Add(Me.ginfo)
        Me.GroupBox2.Controls.Add(Me.dgvpesquisa)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(7, 67)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(990, 410)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Resultado da Pesquisa"
        '
        'pbDados
        '
        Me.pbDados.Location = New System.Drawing.Point(256, 4)
        Me.pbDados.Name = "pbDados"
        Me.pbDados.Size = New System.Drawing.Size(729, 10)
        Me.pbDados.TabIndex = 7
        Me.pbDados.Visible = False
        '
        'txtxml
        '
        Me.txtxml.Location = New System.Drawing.Point(360, 186)
        Me.txtxml.Multiline = True
        Me.txtxml.Name = "txtxml"
        Me.txtxml.Size = New System.Drawing.Size(247, 51)
        Me.txtxml.TabIndex = 3
        Me.txtxml.Visible = False
        '
        'lbltimer
        '
        Me.lbltimer.AutoSize = True
        Me.lbltimer.Location = New System.Drawing.Point(604, 91)
        Me.lbltimer.Name = "lbltimer"
        Me.lbltimer.Size = New System.Drawing.Size(13, 13)
        Me.lbltimer.TabIndex = 2
        Me.lbltimer.Text = "0"
        Me.lbltimer.Visible = False
        '
        'ginfo
        '
        Me.ginfo.BackColor = System.Drawing.Color.Blue
        Me.ginfo.Controls.Add(Me.Label5)
        Me.ginfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ginfo.Location = New System.Drawing.Point(294, 65)
        Me.ginfo.Name = "ginfo"
        Me.ginfo.Size = New System.Drawing.Size(453, 56)
        Me.ginfo.TabIndex = 1
        Me.ginfo.TabStop = False
        Me.ginfo.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Blue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(28, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(408, 31)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Aguarde, Carregando Pesquisa ..."
        '
        'dgvpesquisa
        '
        Me.dgvpesquisa.AllowUserToAddRows = False
        Me.dgvpesquisa.AllowUserToDeleteRows = False
        Me.dgvpesquisa.AllowUserToResizeColumns = False
        Me.dgvpesquisa.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvpesquisa.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvpesquisa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgvpesquisa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvpesquisa.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvpesquisa.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column6, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column7, Me.xml})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvpesquisa.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvpesquisa.EnableHeadersVisualStyles = False
        Me.dgvpesquisa.GridColor = System.Drawing.Color.Blue
        Me.dgvpesquisa.Location = New System.Drawing.Point(3, 15)
        Me.dgvpesquisa.Name = "dgvpesquisa"
        Me.dgvpesquisa.ReadOnly = True
        Me.dgvpesquisa.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvpesquisa.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvpesquisa.RowHeadersWidth = 24
        Me.dgvpesquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvpesquisa.Size = New System.Drawing.Size(982, 389)
        Me.dgvpesquisa.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "Numero_nfe"
        Me.Column1.HeaderText = "Número NFe"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 72
        '
        'Column6
        '
        Me.Column6.HeaderText = "Razão Social"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 265
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Cnpj_emi"
        Me.Column2.HeaderText = "CNPJ Emitente"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 110
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "dataemissao"
        Me.Column3.HeaderText = "Data Emissão"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 80
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "Chave_nfe"
        Me.Column4.HeaderText = "Chave de Acesso"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 280
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "Download"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column5.HeaderText = "Download"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column5.Width = 70
        '
        'Column7
        '
        Me.Column7.HeaderText = "Visualizar"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column7.Width = 60
        '
        'xml
        '
        Me.xml.HeaderText = "xml"
        Me.xml.Name = "xml"
        Me.xml.ReadOnly = True
        Me.xml.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.txtcaminho)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtnome)
        Me.GroupBox1.Controls.Add(Me.chkinicio)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtcnpj)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtnumero)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(990, 49)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(846, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(36, 23)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtcaminho
        '
        Me.txtcaminho.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtcaminho.Location = New System.Drawing.Point(576, 21)
        Me.txtcaminho.MaxLength = 14
        Me.txtcaminho.Name = "txtcaminho"
        Me.txtcaminho.ReadOnly = True
        Me.txtcaminho.Size = New System.Drawing.Size(274, 20)
        Me.txtcaminho.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(573, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(179, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Caminho Banco De dados OneDrive"
        '
        'txtnome
        '
        Me.txtnome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnome.Location = New System.Drawing.Point(85, 20)
        Me.txtnome.MaxLength = 500
        Me.txtnome.Name = "txtnome"
        Me.txtnome.Size = New System.Drawing.Size(346, 20)
        Me.txtnome.TabIndex = 14
        '
        'chkinicio
        '
        Me.chkinicio.AutoSize = True
        Me.chkinicio.Location = New System.Drawing.Point(240, 4)
        Me.chkinicio.Name = "chkinicio"
        Me.chkinicio.Size = New System.Drawing.Size(89, 17)
        Me.chkinicio.TabIndex = 13
        Me.chkinicio.Text = "inicio Palavra"
        Me.chkinicio.UseVisualStyleBackColor = True
        Me.chkinicio.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(82, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(138, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Nome da Empresa Emitente"
        '
        'txtcnpj
        '
        Me.txtcnpj.Location = New System.Drawing.Point(437, 20)
        Me.txtcnpj.MaxLength = 14
        Me.txtcnpj.Name = "txtcnpj"
        Me.txtcnpj.Size = New System.Drawing.Size(112, 20)
        Me.txtcnpj.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(434, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "CNPJ Emitente:"
        '
        'txtnumero
        '
        Me.txtnumero.Location = New System.Drawing.Point(6, 19)
        Me.txtnumero.MaxLength = 9
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(73, 20)
        Me.txtnumero.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Número NFe"
        '
        'frmpesq_onedrive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 479)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmpesq_onedrive"
        Me.Text = "frmpesq_onedrive"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ginfo.ResumeLayout(False)
        Me.ginfo.PerformLayout()
        CType(Me.dgvpesquisa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents pbDados As System.Windows.Forms.ProgressBar
    Friend WithEvents txtxml As System.Windows.Forms.TextBox
    Friend WithEvents lbltimer As System.Windows.Forms.Label
    Friend WithEvents ginfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgvpesquisa As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtcaminho As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnome As System.Windows.Forms.TextBox
    Friend WithEvents chkinicio As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtcnpj As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtnumero As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents xml As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
