<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmnfelocal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmnfelocal))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chknumero_ap = New System.Windows.Forms.CheckBox()
        Me.txtpar = New System.Windows.Forms.TextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.chkdata = New System.Windows.Forms.CheckBox()
        Me.chksit = New System.Windows.Forms.CheckBox()
        Me.chkstatus = New System.Windows.Forms.CheckBox()
        Me.cbostatusnfe = New System.Windows.Forms.ComboBox()
        Me.cbomanifestacao = New System.Windows.Forms.ComboBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.cbotipo = New System.Windows.Forms.ComboBox()
        Me.chknfeincompleta = New System.Windows.Forms.CheckBox()
        Me.mskdatainicial = New System.Windows.Forms.DateTimePicker()
        Me.mskdatafinal = New System.Windows.Forms.DateTimePicker()
        Me.mskpesquisa = New System.Windows.Forms.MaskedTextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.chkpasta = New System.Windows.Forms.CheckBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.lbltimer = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SaveFileDialog2 = New System.Windows.Forms.SaveFileDialog()
        Me.pinfo = New System.Windows.Forms.Panel()
        Me.bntcancela = New System.Windows.Forms.Button()
        Me.pic_Ico = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtinfo = New System.Windows.Forms.TextBox()
        Me.lblpar = New System.Windows.Forms.Label()
        Me.dgvnotas = New System.Windows.Forms.DataGridView()
        Me.chkselecao = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.emitente_nfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numero_nfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.data_autorizacao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valor_nfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chave_nfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sit_nfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipo_nfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cnpj_dest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xml_nfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nferef = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xml = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExcluirNotaFisca = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultaStatusNFe = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultaChaveOrigem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadPortalNFeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblinfo = New System.Windows.Forms.Label()
        Me.tconsultanfe = New System.Windows.Forms.Timer(Me.components)
        Me.mskchavemg = New System.Windows.Forms.MaskedTextBox()
        Me.bntdownloadmg = New System.Windows.Forms.Button()
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ValidaXMLCompletoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ValidaXMLTagNFeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chkdownload = New System.Windows.Forms.CheckBox()
        Me.txtcodevento = New System.Windows.Forms.TextBox()
        Me.cbomanifestar = New System.Windows.Forms.ComboBox()
        Me.bntmanifes = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Paneljust = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtjust = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mskcnpj_esp = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.pinfo.SuspendLayout()
        CType(Me.pic_Ico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvnotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Paneljust.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.chknumero_ap)
        Me.Panel1.Controls.Add(Me.txtpar)
        Me.Panel1.Controls.Add(Me.LinkLabel3)
        Me.Panel1.Controls.Add(Me.chkdata)
        Me.Panel1.Controls.Add(Me.chksit)
        Me.Panel1.Controls.Add(Me.chkstatus)
        Me.Panel1.Controls.Add(Me.cbostatusnfe)
        Me.Panel1.Controls.Add(Me.cbomanifestacao)
        Me.Panel1.Controls.Add(Me.LinkLabel2)
        Me.Panel1.Controls.Add(Me.cbotipo)
        Me.Panel1.Controls.Add(Me.chknfeincompleta)
        Me.Panel1.Controls.Add(Me.mskdatainicial)
        Me.Panel1.Controls.Add(Me.mskdatafinal)
        Me.Panel1.Controls.Add(Me.mskpesquisa)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Location = New System.Drawing.Point(3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1048, 51)
        Me.Panel1.TabIndex = 0
        '
        'chknumero_ap
        '
        Me.chknumero_ap.AutoSize = True
        Me.chknumero_ap.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chknumero_ap.Location = New System.Drawing.Point(283, 5)
        Me.chknumero_ap.Name = "chknumero_ap"
        Me.chknumero_ap.Size = New System.Drawing.Size(81, 17)
        Me.chknumero_ap.TabIndex = 54
        Me.chknumero_ap.Text = "Aproximado"
        Me.chknumero_ap.UseVisualStyleBackColor = True
        Me.chknumero_ap.Visible = False
        '
        'txtpar
        '
        Me.txtpar.Location = New System.Drawing.Point(375, 1)
        Me.txtpar.Name = "txtpar"
        Me.txtpar.Size = New System.Drawing.Size(75, 20)
        Me.txtpar.TabIndex = 31
        Me.txtpar.Text = "Nome_emi"
        Me.txtpar.Visible = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(391, 4)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(59, 13)
        Me.LinkLabel3.TabIndex = 45
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "LinkLabel3"
        Me.LinkLabel3.Visible = False
        '
        'chkdata
        '
        Me.chkdata.AutoSize = True
        Me.chkdata.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkdata.Location = New System.Drawing.Point(696, 5)
        Me.chkdata.Name = "chkdata"
        Me.chkdata.Size = New System.Drawing.Size(81, 17)
        Me.chkdata.TabIndex = 43
        Me.chkdata.Text = "Aproximado"
        Me.chkdata.UseVisualStyleBackColor = True
        '
        'chksit
        '
        Me.chksit.AutoSize = True
        Me.chksit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chksit.Location = New System.Drawing.Point(456, 5)
        Me.chksit.Name = "chksit"
        Me.chksit.Size = New System.Drawing.Size(224, 17)
        Me.chksit.TabIndex = 31
        Me.chksit.Text = "Situação da Manifestação do Destinatário"
        Me.chksit.UseVisualStyleBackColor = True
        '
        'chkstatus
        '
        Me.chkstatus.AutoSize = True
        Me.chkstatus.Checked = True
        Me.chkstatus.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkstatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkstatus.Location = New System.Drawing.Point(8, 5)
        Me.chkstatus.Name = "chkstatus"
        Me.chkstatus.Size = New System.Drawing.Size(97, 17)
        Me.chkstatus.TabIndex = 44
        Me.chkstatus.Text = "Status da NF-e"
        Me.chkstatus.UseVisualStyleBackColor = True
        '
        'cbostatusnfe
        '
        Me.cbostatusnfe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbostatusnfe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbostatusnfe.FormattingEnabled = True
        Me.cbostatusnfe.Items.AddRange(New Object() {"NF-e Autorizada", "NF-e cancelada"})
        Me.cbostatusnfe.Location = New System.Drawing.Point(8, 23)
        Me.cbostatusnfe.Name = "cbostatusnfe"
        Me.cbostatusnfe.Size = New System.Drawing.Size(118, 21)
        Me.cbostatusnfe.TabIndex = 16
        '
        'cbomanifestacao
        '
        Me.cbomanifestacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbomanifestacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbomanifestacao.FormattingEnabled = True
        Me.cbomanifestacao.Items.AddRange(New Object() {"Sem Manifestacao do Destinatario", "Confirmada Operacao", "Ciencia da Operacao", "Desconhecimento da Operacao", "Operacao nao Realizada"})
        Me.cbomanifestacao.Location = New System.Drawing.Point(456, 23)
        Me.cbomanifestacao.Name = "cbomanifestacao"
        Me.cbomanifestacao.Size = New System.Drawing.Size(234, 21)
        Me.cbomanifestacao.TabIndex = 13
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LinkLabel2.LinkColor = System.Drawing.Color.Maroon
        Me.LinkLabel2.Location = New System.Drawing.Point(911, 26)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(136, 13)
        Me.LinkLabel2.TabIndex = 49
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Carregar NFe's incompletas"
        '
        'cbotipo
        '
        Me.cbotipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbotipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbotipo.ForeColor = System.Drawing.Color.Blue
        Me.cbotipo.FormattingEnabled = True
        Me.cbotipo.Items.AddRange(New Object() {"Nome do Fornecedor", "CNPJ Fornecedor", "Valor NFe", "Chave de Acesso NFe", "Numero NFe"})
        Me.cbotipo.Location = New System.Drawing.Point(132, 3)
        Me.cbotipo.Name = "cbotipo"
        Me.cbotipo.Size = New System.Drawing.Size(144, 21)
        Me.cbotipo.TabIndex = 12
        '
        'chknfeincompleta
        '
        Me.chknfeincompleta.AutoSize = True
        Me.chknfeincompleta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chknfeincompleta.Location = New System.Drawing.Point(904, 27)
        Me.chknfeincompleta.Name = "chknfeincompleta"
        Me.chknfeincompleta.Size = New System.Drawing.Size(155, 17)
        Me.chknfeincompleta.TabIndex = 46
        Me.chknfeincompleta.Text = "Carregar NFe's incompletas"
        Me.chknfeincompleta.UseVisualStyleBackColor = True
        Me.chknfeincompleta.Visible = False
        '
        'mskdatainicial
        '
        Me.mskdatainicial.Enabled = False
        Me.mskdatainicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.mskdatainicial.Location = New System.Drawing.Point(696, 24)
        Me.mskdatainicial.Name = "mskdatainicial"
        Me.mskdatainicial.Size = New System.Drawing.Size(99, 20)
        Me.mskdatainicial.TabIndex = 9
        '
        'mskdatafinal
        '
        Me.mskdatafinal.Enabled = False
        Me.mskdatafinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.mskdatafinal.Location = New System.Drawing.Point(801, 24)
        Me.mskdatafinal.Name = "mskdatafinal"
        Me.mskdatafinal.Size = New System.Drawing.Size(99, 20)
        Me.mskdatafinal.TabIndex = 8
        '
        'mskpesquisa
        '
        Me.mskpesquisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskpesquisa.Culture = New System.Globalization.CultureInfo("en-US")
        Me.mskpesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskpesquisa.Location = New System.Drawing.Point(132, 24)
        Me.mskpesquisa.Name = "mskpesquisa"
        Me.mskpesquisa.Size = New System.Drawing.Size(317, 20)
        Me.mskpesquisa.TabIndex = 4
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(909, 4)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(138, 13)
        Me.LinkLabel1.TabIndex = 29
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Recuperar última Download"
        '
        'chkpasta
        '
        Me.chkpasta.AutoSize = True
        Me.chkpasta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkpasta.Location = New System.Drawing.Point(438, 77)
        Me.chkpasta.Name = "chkpasta"
        Me.chkpasta.Size = New System.Drawing.Size(111, 17)
        Me.chkpasta.TabIndex = 50
        Me.chkpasta.Text = "Salvar XML Pasta"
        Me.chkpasta.UseVisualStyleBackColor = True
        '
        'lbltimer
        '
        Me.lbltimer.AutoSize = True
        Me.lbltimer.Location = New System.Drawing.Point(687, 250)
        Me.lbltimer.Name = "lbltimer"
        Me.lbltimer.Size = New System.Drawing.Size(13, 13)
        Me.lbltimer.TabIndex = 2
        Me.lbltimer.Text = "0"
        Me.lbltimer.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(597, 245)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'pinfo
        '
        Me.pinfo.BackColor = System.Drawing.Color.Red
        Me.pinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pinfo.Controls.Add(Me.bntcancela)
        Me.pinfo.Controls.Add(Me.pic_Ico)
        Me.pinfo.Controls.Add(Me.PictureBox2)
        Me.pinfo.Controls.Add(Me.txtinfo)
        Me.pinfo.Location = New System.Drawing.Point(411, 165)
        Me.pinfo.Name = "pinfo"
        Me.pinfo.Size = New System.Drawing.Size(353, 123)
        Me.pinfo.TabIndex = 40
        Me.pinfo.Visible = False
        '
        'bntcancela
        '
        Me.bntcancela.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntcancela.Location = New System.Drawing.Point(5, 120)
        Me.bntcancela.Name = "bntcancela"
        Me.bntcancela.Size = New System.Drawing.Size(343, 25)
        Me.bntcancela.TabIndex = 47
        Me.bntcancela.Text = "&Sair"
        Me.bntcancela.UseVisualStyleBackColor = True
        '
        'pic_Ico
        '
        Me.pic_Ico.Image = CType(resources.GetObject("pic_Ico.Image"), System.Drawing.Image)
        Me.pic_Ico.Location = New System.Drawing.Point(5, 104)
        Me.pic_Ico.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pic_Ico.Name = "pic_Ico"
        Me.pic_Ico.Size = New System.Drawing.Size(340, 11)
        Me.pic_Ico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_Ico.TabIndex = 42
        Me.pic_Ico.TabStop = False
        Me.pic_Ico.WaitOnLoad = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PictureBox2.Location = New System.Drawing.Point(118, 65)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(112, 38)
        Me.PictureBox2.TabIndex = 40
        Me.PictureBox2.TabStop = False
        '
        'txtinfo
        '
        Me.txtinfo.AccessibleDescription = resources.GetString("txtinfo.AccessibleDescription")
        Me.txtinfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtinfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinfo.Location = New System.Drawing.Point(3, 3)
        Me.txtinfo.Multiline = True
        Me.txtinfo.Name = "txtinfo"
        Me.txtinfo.Size = New System.Drawing.Size(345, 115)
        Me.txtinfo.TabIndex = 38
        Me.txtinfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblpar
        '
        Me.lblpar.AutoSize = True
        Me.lblpar.Location = New System.Drawing.Point(236, 241)
        Me.lblpar.Name = "lblpar"
        Me.lblpar.Size = New System.Drawing.Size(13, 13)
        Me.lblpar.TabIndex = 42
        Me.lblpar.Text = "0"
        Me.lblpar.Visible = False
        '
        'dgvnotas
        '
        Me.dgvnotas.AllowUserToAddRows = False
        Me.dgvnotas.AllowUserToDeleteRows = False
        Me.dgvnotas.AllowUserToOrderColumns = True
        Me.dgvnotas.AllowUserToResizeRows = False
        Me.dgvnotas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvnotas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvnotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chkselecao, Me.emitente_nfe, Me.numero_nfe, Me.data_autorizacao, Me.valor_nfe, Me.chave_nfe, Me.sit_nfe, Me.tipo_nfe, Me.cnpj_dest, Me.ie, Me.xml_nfe, Me.nferef, Me.xml})
        Me.dgvnotas.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvnotas.EnableHeadersVisualStyles = False
        Me.dgvnotas.GridColor = System.Drawing.Color.Blue
        Me.dgvnotas.Location = New System.Drawing.Point(3, 105)
        Me.dgvnotas.MultiSelect = False
        Me.dgvnotas.Name = "dgvnotas"
        Me.dgvnotas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvnotas.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvnotas.RowHeadersVisible = False
        Me.dgvnotas.RowHeadersWidth = 22
        Me.dgvnotas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        Me.dgvnotas.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvnotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvnotas.Size = New System.Drawing.Size(1048, 446)
        Me.dgvnotas.TabIndex = 1
        '
        'chkselecao
        '
        Me.chkselecao.HeaderText = ""
        Me.chkselecao.Name = "chkselecao"
        Me.chkselecao.Width = 22
        '
        'emitente_nfe
        '
        Me.emitente_nfe.HeaderText = "Nome do Fornecedor"
        Me.emitente_nfe.Name = "emitente_nfe"
        Me.emitente_nfe.Width = 310
        '
        'numero_nfe
        '
        Me.numero_nfe.HeaderText = "Número NFe"
        Me.numero_nfe.Name = "numero_nfe"
        Me.numero_nfe.Width = 75
        '
        'data_autorizacao
        '
        Me.data_autorizacao.HeaderText = "Data Autoriz."
        Me.data_autorizacao.Name = "data_autorizacao"
        Me.data_autorizacao.Width = 75
        '
        'valor_nfe
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.valor_nfe.DefaultCellStyle = DataGridViewCellStyle6
        Me.valor_nfe.HeaderText = "Valor NFe"
        Me.valor_nfe.Name = "valor_nfe"
        Me.valor_nfe.Visible = False
        Me.valor_nfe.Width = 80
        '
        'chave_nfe
        '
        Me.chave_nfe.HeaderText = "Chave Acesso NFe"
        Me.chave_nfe.Name = "chave_nfe"
        Me.chave_nfe.Width = 275
        '
        'sit_nfe
        '
        Me.sit_nfe.HeaderText = "Situação da NF-e"
        Me.sit_nfe.Name = "sit_nfe"
        Me.sit_nfe.Width = 160
        '
        'tipo_nfe
        '
        Me.tipo_nfe.HeaderText = "Tipo NFe"
        Me.tipo_nfe.Name = "tipo_nfe"
        Me.tipo_nfe.Width = 70
        '
        'cnpj_dest
        '
        Me.cnpj_dest.HeaderText = "Cnpj dest"
        Me.cnpj_dest.Name = "cnpj_dest"
        Me.cnpj_dest.Visible = False
        '
        'ie
        '
        Me.ie.HeaderText = "ie"
        Me.ie.Name = "ie"
        Me.ie.Visible = False
        '
        'xml_nfe
        '
        Me.xml_nfe.HeaderText = "XML_nfe"
        Me.xml_nfe.Name = "xml_nfe"
        Me.xml_nfe.Visible = False
        '
        'nferef
        '
        Me.nferef.HeaderText = "chave ref"
        Me.nferef.Name = "nferef"
        Me.nferef.Visible = False
        '
        'xml
        '
        Me.xml.HeaderText = "XML"
        Me.xml.Name = "xml"
        Me.xml.Width = 45
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcluirNotaFisca, Me.ConsultaStatusNFe, Me.ConsultaChaveOrigem, Me.DownloadPortalNFeToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(201, 92)
        '
        'ExcluirNotaFisca
        '
        Me.ExcluirNotaFisca.Name = "ExcluirNotaFisca"
        Me.ExcluirNotaFisca.Size = New System.Drawing.Size(200, 22)
        Me.ExcluirNotaFisca.Text = "Excluir Nota Fiscal"
        '
        'ConsultaStatusNFe
        '
        Me.ConsultaStatusNFe.Name = "ConsultaStatusNFe"
        Me.ConsultaStatusNFe.Size = New System.Drawing.Size(200, 22)
        Me.ConsultaStatusNFe.Text = "Consulta Status NF-e"
        '
        'ConsultaChaveOrigem
        '
        Me.ConsultaChaveOrigem.Name = "ConsultaChaveOrigem"
        Me.ConsultaChaveOrigem.Size = New System.Drawing.Size(200, 22)
        Me.ConsultaChaveOrigem.Text = "Consulta Chave Origem"
        '
        'DownloadPortalNFeToolStripMenuItem
        '
        Me.DownloadPortalNFeToolStripMenuItem.Name = "DownloadPortalNFeToolStripMenuItem"
        Me.DownloadPortalNFeToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.DownloadPortalNFeToolStripMenuItem.Text = "Download Portal NF-e"
        '
        'lblinfo
        '
        Me.lblinfo.AutoSize = True
        Me.lblinfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblinfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblinfo.ForeColor = System.Drawing.Color.White
        Me.lblinfo.Location = New System.Drawing.Point(421, 136)
        Me.lblinfo.Name = "lblinfo"
        Me.lblinfo.Size = New System.Drawing.Size(336, 26)
        Me.lblinfo.TabIndex = 45
        Me.lblinfo.Text = "Aguarde, Realizando a Consulta ..."
        Me.lblinfo.Visible = False
        '
        'tconsultanfe
        '
        Me.tconsultanfe.Interval = 1000
        '
        'mskchavemg
        '
        Me.mskchavemg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskchavemg.Culture = New System.Globalization.CultureInfo("en-US")
        Me.mskchavemg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskchavemg.Location = New System.Drawing.Point(8, 74)
        Me.mskchavemg.Mask = "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000"
        Me.mskchavemg.Name = "mskchavemg"
        Me.mskchavemg.Size = New System.Drawing.Size(311, 20)
        Me.mskchavemg.TabIndex = 46
        Me.mskchavemg.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'bntdownloadmg
        '
        Me.bntdownloadmg.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.bntdownloadmg.ContextMenuStrip = Me.ContextMenuStrip3
        Me.bntdownloadmg.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bntdownloadmg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bntdownloadmg.ForeColor = System.Drawing.Color.Black
        Me.bntdownloadmg.Location = New System.Drawing.Point(325, 74)
        Me.bntdownloadmg.Name = "bntdownloadmg"
        Me.bntdownloadmg.Size = New System.Drawing.Size(107, 22)
        Me.bntdownloadmg.TabIndex = 47
        Me.bntdownloadmg.Text = "Download XML"
        Me.ToolTip1.SetToolTip(Me.bntdownloadmg, "Clique aqui para realizar o Download na SEFAZ MG")
        Me.bntdownloadmg.UseVisualStyleBackColor = False
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ValidaXMLCompletoToolStripMenuItem, Me.ValidaXMLTagNFeToolStripMenuItem})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip3"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(226, 48)
        '
        'ValidaXMLCompletoToolStripMenuItem
        '
        Me.ValidaXMLCompletoToolStripMenuItem.Name = "ValidaXMLCompletoToolStripMenuItem"
        Me.ValidaXMLCompletoToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ValidaXMLCompletoToolStripMenuItem.Text = "Consulta Chave NF-e na RFB"
        '
        'ValidaXMLTagNFeToolStripMenuItem
        '
        Me.ValidaXMLTagNFeToolStripMenuItem.Name = "ValidaXMLTagNFeToolStripMenuItem"
        Me.ValidaXMLTagNFeToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ValidaXMLTagNFeToolStripMenuItem.Text = "Download XML SEFAZ MG"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.chkdownload)
        Me.Panel3.Controls.Add(Me.txtcodevento)
        Me.Panel3.Controls.Add(Me.cbomanifestar)
        Me.Panel3.Controls.Add(Me.bntmanifes)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Location = New System.Drawing.Point(555, 58)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(317, 44)
        Me.Panel3.TabIndex = 51
        '
        'chkdownload
        '
        Me.chkdownload.AutoSize = True
        Me.chkdownload.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdownload.ForeColor = System.Drawing.Color.Navy
        Me.chkdownload.Location = New System.Drawing.Point(196, 0)
        Me.chkdownload.Name = "chkdownload"
        Me.chkdownload.Size = New System.Drawing.Size(108, 19)
        Me.chkdownload.TabIndex = 54
        Me.chkdownload.Text = "Download NFe"
        Me.chkdownload.UseVisualStyleBackColor = False
        '
        'txtcodevento
        '
        Me.txtcodevento.Location = New System.Drawing.Point(140, 1)
        Me.txtcodevento.Name = "txtcodevento"
        Me.txtcodevento.Size = New System.Drawing.Size(51, 20)
        Me.txtcodevento.TabIndex = 4
        Me.txtcodevento.Visible = False
        '
        'cbomanifestar
        '
        Me.cbomanifestar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbomanifestar.FormattingEnabled = True
        Me.cbomanifestar.Items.AddRange(New Object() {"Confirmacao da Operacao", "Ciencia da Operacao", "Desconhecimento da Operacao", "Operacao nao Realizada"})
        Me.cbomanifestar.Location = New System.Drawing.Point(3, 20)
        Me.cbomanifestar.Name = "cbomanifestar"
        Me.cbomanifestar.Size = New System.Drawing.Size(188, 21)
        Me.cbomanifestar.TabIndex = 3
        '
        'bntmanifes
        '
        Me.bntmanifes.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bntmanifes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bntmanifes.Enabled = False
        Me.bntmanifes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bntmanifes.Location = New System.Drawing.Point(196, 18)
        Me.bntmanifes.Name = "bntmanifes"
        Me.bntmanifes.Size = New System.Drawing.Size(115, 23)
        Me.bntmanifes.TabIndex = 2
        Me.bntmanifes.Text = "Manifestar NFe"
        Me.bntmanifes.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tipo Manifestacao"
        '
        'Paneljust
        '
        Me.Paneljust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Paneljust.Controls.Add(Me.Button4)
        Me.Paneljust.Controls.Add(Me.Button3)
        Me.Paneljust.Controls.Add(Me.Label6)
        Me.Paneljust.Controls.Add(Me.txtjust)
        Me.Paneljust.Controls.Add(Me.ComboBox1)
        Me.Paneljust.Location = New System.Drawing.Point(371, 128)
        Me.Paneljust.Name = "Paneljust"
        Me.Paneljust.Size = New System.Drawing.Size(428, 137)
        Me.Paneljust.TabIndex = 52
        Me.Paneljust.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(308, 108)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(115, 23)
        Me.Button4.TabIndex = 17
        Me.Button4.Text = "&Cancelar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(3, 108)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(203, 23)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "&Comfimar Justificativa"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(12, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(398, 20)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Justificativa porque a operação não foi realizada"
        '
        'txtjust
        '
        Me.txtjust.BackColor = System.Drawing.Color.White
        Me.txtjust.Location = New System.Drawing.Point(3, 28)
        Me.txtjust.Multiline = True
        Me.txtjust.Name = "txtjust"
        Me.txtjust.Size = New System.Drawing.Size(420, 74)
        Me.txtjust.TabIndex = 14
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Confirmacao da Operacao", "Ciencia da Operacao", "Desconhecimento da Operacao", "Operacao nao Realizada"})
        Me.ComboBox1.Location = New System.Drawing.Point(172, -128)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(231, 21)
        Me.ComboBox1.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(905, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 16)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "CNPJ Empresa DFe"
        '
        'mskcnpj_esp
        '
        Me.mskcnpj_esp.Location = New System.Drawing.Point(908, 80)
        Me.mskcnpj_esp.Name = "mskcnpj_esp"
        Me.mskcnpj_esp.Size = New System.Drawing.Size(125, 20)
        Me.mskcnpj_esp.TabIndex = 56
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(5, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 13)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Chave Acesso NF-e"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(801, 1)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 21)
        Me.Button2.TabIndex = 55
        Me.Button2.Text = "&Pesquisa"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmnfelocal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 556)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.mskcnpj_esp)
        Me.Controls.Add(Me.chkpasta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Paneljust)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.bntdownloadmg)
        Me.Controls.Add(Me.mskchavemg)
        Me.Controls.Add(Me.lblinfo)
        Me.Controls.Add(Me.lblpar)
        Me.Controls.Add(Me.pinfo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lbltimer)
        Me.Controls.Add(Me.dgvnotas)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmnfelocal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pesquisa Notas fiscais  para Realizar o Download da NF-e"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pinfo.ResumeLayout(False)
        Me.pinfo.PerformLayout()
        CType(Me.pic_Ico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvnotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Paneljust.ResumeLayout(False)
        Me.Paneljust.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents mskpesquisa As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskdatafinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents mskdatainicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lbltimer As System.Windows.Forms.Label
    Friend WithEvents cbotipo As System.Windows.Forms.ComboBox
    Friend WithEvents cbomanifestacao As System.Windows.Forms.ComboBox
    Friend WithEvents cbostatusnfe As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents SaveFileDialog2 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents pinfo As System.Windows.Forms.Panel
    Friend WithEvents pic_Ico As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txtinfo As System.Windows.Forms.TextBox
    Friend WithEvents lblpar As System.Windows.Forms.Label
    Friend WithEvents chksit As System.Windows.Forms.CheckBox
    Friend WithEvents chkdata As System.Windows.Forms.CheckBox
    Friend WithEvents dgvnotas As System.Windows.Forms.DataGridView
    Friend WithEvents txtpar As System.Windows.Forms.TextBox
    Friend WithEvents lblinfo As System.Windows.Forms.Label
    Friend WithEvents tconsultanfe As System.Windows.Forms.Timer
    Friend WithEvents bntcancela As System.Windows.Forms.Button
    Friend WithEvents mskchavemg As System.Windows.Forms.MaskedTextBox
    Friend WithEvents bntdownloadmg As System.Windows.Forms.Button
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents chkpasta As System.Windows.Forms.CheckBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents bntmanifes As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbomanifestar As System.Windows.Forms.ComboBox
    Friend WithEvents txtcodevento As System.Windows.Forms.TextBox
    Friend WithEvents Paneljust As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtjust As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents chkdownload As System.Windows.Forms.CheckBox
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExcluirNotaFisca As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultaStatusNFe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultaChaveOrigem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chknfeincompleta As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label2 As Label
    Friend WithEvents mskcnpj_esp As MaskedTextBox
    Friend WithEvents DownloadPortalNFeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chknumero_ap As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkselecao As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents emitente_nfe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numero_nfe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents data_autorizacao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor_nfe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chave_nfe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sit_nfe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipo_nfe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cnpj_dest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents xml_nfe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nferef As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents xml As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents ContextMenuStrip3 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ValidaXMLCompletoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ValidaXMLTagNFeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkstatus As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
