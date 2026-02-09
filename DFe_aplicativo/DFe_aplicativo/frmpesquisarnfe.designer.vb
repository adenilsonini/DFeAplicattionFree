<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmpesquisarnfe
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cbotipop = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.chkstatus_nfe = New System.Windows.Forms.CheckBox()
        Me.cbostatusnfe = New System.Windows.Forms.ComboBox()
        Me.Paneldata = New System.Windows.Forms.Panel()
        Me.lbldataini = New System.Windows.Forms.Label()
        Me.lbldatafim = New System.Windows.Forms.Label()
        Me.mskdatainicial = New System.Windows.Forms.DateTimePicker()
        Me.mskdatafinal = New System.Windows.Forms.DateTimePicker()
        Me.txtpar = New System.Windows.Forms.TextBox()
        Me.txtpesquisa = New System.Windows.Forms.TextBox()
        Me.cbotipo = New System.Windows.Forms.ComboBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.chkvlrboleto = New System.Windows.Forms.CheckBox()
        Me.txtchave = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblinfo = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Pinfo = New System.Windows.Forms.Panel()
        Me.Panelarq = New System.Windows.Forms.Panel()
        Me.txtinfo = New System.Windows.Forms.TextBox()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtxml_nfe = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvpesquisa = New System.Windows.Forms.DataGridView()
        Me.nomenfegrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nfegrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vnf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.data_emi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.chave_nfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.obs_cont = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status_nfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xml_nfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.manifestagrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.par_sg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.obscont_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ManifestacaoDestinatarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InserirObservacaoNFeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CriarPastaDocToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportaCTeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VisualizarNFePortalNacionalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProtocolarNFeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VisualizarEstruturaXMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.lblobscont = New System.Windows.Forms.TextBox()
        Me.fbd1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Panel1.SuspendLayout()
        Me.Paneldata.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Pinfo.SuspendLayout()
        Me.Panelarq.SuspendLayout()
        CType(Me.dgvpesquisa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.cbotipop)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.chkstatus_nfe)
        Me.Panel1.Controls.Add(Me.cbostatusnfe)
        Me.Panel1.Controls.Add(Me.Paneldata)
        Me.Panel1.Controls.Add(Me.txtpar)
        Me.Panel1.Controls.Add(Me.txtpesquisa)
        Me.Panel1.Controls.Add(Me.cbotipo)
        Me.Panel1.Location = New System.Drawing.Point(5, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1054, 54)
        Me.Panel1.TabIndex = 0
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(510, 4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 53
        Me.Button5.Text = "Button5"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ForeColor = System.Drawing.Color.Red
        Me.Button4.Location = New System.Drawing.Point(714, 23)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(103, 23)
        Me.Button4.TabIndex = 51
        Me.Button4.Text = "&NFe Protocolo"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'cbotipop
        '
        Me.cbotipop.BackColor = System.Drawing.Color.Yellow
        Me.cbotipop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbotipop.FormattingEnabled = True
        Me.cbotipop.Items.AddRange(New Object() {"NF-e", "NFC-e"})
        Me.cbotipop.Location = New System.Drawing.Point(510, 26)
        Me.cbotipop.Name = "cbotipop"
        Me.cbotipop.Size = New System.Drawing.Size(58, 21)
        Me.cbotipop.TabIndex = 48
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.Blue
        Me.Button3.Location = New System.Drawing.Point(611, 24)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(85, 23)
        Me.Button3.TabIndex = 47
        Me.Button3.Text = "&Importar XML"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'chkstatus_nfe
        '
        Me.chkstatus_nfe.AutoSize = True
        Me.chkstatus_nfe.Checked = True
        Me.chkstatus_nfe.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkstatus_nfe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkstatus_nfe.ForeColor = System.Drawing.Color.Blue
        Me.chkstatus_nfe.Location = New System.Drawing.Point(7, 2)
        Me.chkstatus_nfe.Name = "chkstatus_nfe"
        Me.chkstatus_nfe.Size = New System.Drawing.Size(103, 20)
        Me.chkstatus_nfe.TabIndex = 46
        Me.chkstatus_nfe.Text = "NFe Status"
        Me.chkstatus_nfe.UseVisualStyleBackColor = True
        '
        'cbostatusnfe
        '
        Me.cbostatusnfe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbostatusnfe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbostatusnfe.FormattingEnabled = True
        Me.cbostatusnfe.Items.AddRange(New Object() {"1-NF-e autorizada", "2-NF-e cancelada", "3-NF-e inutilizada"})
        Me.cbostatusnfe.Location = New System.Drawing.Point(6, 24)
        Me.cbostatusnfe.Name = "cbostatusnfe"
        Me.cbostatusnfe.Size = New System.Drawing.Size(118, 21)
        Me.cbostatusnfe.TabIndex = 45
        '
        'Paneldata
        '
        Me.Paneldata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Paneldata.Controls.Add(Me.lbldataini)
        Me.Paneldata.Controls.Add(Me.lbldatafim)
        Me.Paneldata.Controls.Add(Me.mskdatainicial)
        Me.Paneldata.Controls.Add(Me.mskdatafinal)
        Me.Paneldata.Enabled = False
        Me.Paneldata.Location = New System.Drawing.Point(833, 0)
        Me.Paneldata.Name = "Paneldata"
        Me.Paneldata.Size = New System.Drawing.Size(216, 49)
        Me.Paneldata.TabIndex = 39
        '
        'lbldataini
        '
        Me.lbldataini.AutoSize = True
        Me.lbldataini.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldataini.Location = New System.Drawing.Point(3, 3)
        Me.lbldataini.Name = "lbldataini"
        Me.lbldataini.Size = New System.Drawing.Size(74, 16)
        Me.lbldataini.TabIndex = 37
        Me.lbldataini.Text = "Data Inicial"
        '
        'lbldatafim
        '
        Me.lbldatafim.AutoSize = True
        Me.lbldatafim.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldatafim.Location = New System.Drawing.Point(108, 3)
        Me.lbldatafim.Name = "lbldatafim"
        Me.lbldatafim.Size = New System.Drawing.Size(69, 16)
        Me.lbldatafim.TabIndex = 38
        Me.lbldatafim.Text = "Data Final"
        '
        'mskdatainicial
        '
        Me.mskdatainicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.mskdatainicial.Location = New System.Drawing.Point(6, 22)
        Me.mskdatainicial.Name = "mskdatainicial"
        Me.mskdatainicial.Size = New System.Drawing.Size(99, 20)
        Me.mskdatainicial.TabIndex = 36
        '
        'mskdatafinal
        '
        Me.mskdatafinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.mskdatafinal.Location = New System.Drawing.Point(111, 22)
        Me.mskdatafinal.Name = "mskdatafinal"
        Me.mskdatafinal.Size = New System.Drawing.Size(99, 20)
        Me.mskdatafinal.TabIndex = 35
        '
        'txtpar
        '
        Me.txtpar.Location = New System.Drawing.Point(290, 3)
        Me.txtpar.Name = "txtpar"
        Me.txtpar.Size = New System.Drawing.Size(65, 20)
        Me.txtpar.TabIndex = 32
        Me.txtpar.Text = "Nome_emi"
        Me.txtpar.Visible = False
        '
        'txtpesquisa
        '
        Me.txtpesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpesquisa.Location = New System.Drawing.Point(140, 26)
        Me.txtpesquisa.Name = "txtpesquisa"
        Me.txtpesquisa.Size = New System.Drawing.Size(337, 20)
        Me.txtpesquisa.TabIndex = 14
        '
        'cbotipo
        '
        Me.cbotipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbotipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbotipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbotipo.ForeColor = System.Drawing.Color.Blue
        Me.cbotipo.FormattingEnabled = True
        Me.cbotipo.Items.AddRange(New Object() {"Nome do Fornecedor", "CNPJ Fornecedor", "Valor NFe", "Chave de Acesso NFe", "Numero NFe", "Entre Datas", "Caixa-NFCe", "Serie-NFCe", "NFe nao lancada"})
        Me.cbotipo.Location = New System.Drawing.Point(140, 3)
        Me.cbotipo.Name = "cbotipo"
        Me.cbotipo.Size = New System.Drawing.Size(144, 21)
        Me.cbotipo.TabIndex = 13
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(340, 8)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(57, 13)
        Me.LinkLabel1.TabIndex = 52
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "OBS Cont."
        Me.LinkLabel1.Visible = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(726, 8)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(118, 13)
        Me.LinkLabel2.TabIndex = 50
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Visualizar NFe Falte SG"
        Me.LinkLabel2.Visible = False
        '
        'chkvlrboleto
        '
        Me.chkvlrboleto.AutoSize = True
        Me.chkvlrboleto.Location = New System.Drawing.Point(502, 186)
        Me.chkvlrboleto.Name = "chkvlrboleto"
        Me.chkvlrboleto.Size = New System.Drawing.Size(83, 17)
        Me.chkvlrboleto.TabIndex = 40
        Me.chkvlrboleto.Text = "Valor Boleto"
        Me.chkvlrboleto.UseVisualStyleBackColor = True
        Me.chkvlrboleto.Visible = False
        '
        'txtchave
        '
        Me.txtchave.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtchave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtchave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtchave.Location = New System.Drawing.Point(712, 3)
        Me.txtchave.Name = "txtchave"
        Me.txtchave.ReadOnly = True
        Me.txtchave.Size = New System.Drawing.Size(337, 22)
        Me.txtchave.TabIndex = 34
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(644, 105)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "sql"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'lblinfo
        '
        Me.lblinfo.AutoSize = True
        Me.lblinfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblinfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblinfo.Location = New System.Drawing.Point(2, 4)
        Me.lblinfo.Name = "lblinfo"
        Me.lblinfo.Size = New System.Drawing.Size(39, 20)
        Me.lblinfo.TabIndex = 33
        Me.lblinfo.Text = "info"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(563, 105)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 39
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.LinkLabel4)
        Me.Panel2.Controls.Add(Me.LinkLabel3)
        Me.Panel2.Controls.Add(Me.Button6)
        Me.Panel2.Controls.Add(Me.Pinfo)
        Me.Panel2.Controls.Add(Me.LinkLabel1)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.LinkLabel2)
        Me.Panel2.Controls.Add(Me.chkvlrboleto)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.lblinfo)
        Me.Panel2.Controls.Add(Me.dgvpesquisa)
        Me.Panel2.Controls.Add(Me.txtchave)
        Me.Panel2.Location = New System.Drawing.Point(5, 62)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1054, 413)
        Me.Panel2.TabIndex = 1
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.Location = New System.Drawing.Point(252, 8)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(82, 13)
        Me.LinkLabel4.TabIndex = 56
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Informativo NFe"
        Me.LinkLabel4.Visible = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(418, 8)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(29, 13)
        Me.LinkLabel3.TabIndex = 55
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "LOG"
        '
        'Button6
        '
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.ForeColor = System.Drawing.Color.Blue
        Me.Button6.Location = New System.Drawing.Point(483, 1)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(102, 23)
        Me.Button6.TabIndex = 54
        Me.Button6.Text = "&Postar NFC-e Rel"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'Pinfo
        '
        Me.Pinfo.BackColor = System.Drawing.Color.Red
        Me.Pinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pinfo.Controls.Add(Me.Panelarq)
        Me.Pinfo.Location = New System.Drawing.Point(338, 57)
        Me.Pinfo.Name = "Pinfo"
        Me.Pinfo.Size = New System.Drawing.Size(430, 97)
        Me.Pinfo.TabIndex = 48
        Me.Pinfo.Visible = False
        '
        'Panelarq
        '
        Me.Panelarq.BackColor = System.Drawing.Color.LightGray
        Me.Panelarq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panelarq.Controls.Add(Me.txtinfo)
        Me.Panelarq.Controls.Add(Me.Button8)
        Me.Panelarq.Controls.Add(Me.Button7)
        Me.Panelarq.Controls.Add(Me.Button9)
        Me.Panelarq.Controls.Add(Me.Label1)
        Me.Panelarq.Controls.Add(Me.txtxml_nfe)
        Me.Panelarq.Location = New System.Drawing.Point(3, 3)
        Me.Panelarq.Name = "Panelarq"
        Me.Panelarq.Size = New System.Drawing.Size(422, 89)
        Me.Panelarq.TabIndex = 0
        '
        'txtinfo
        '
        Me.txtinfo.BackColor = System.Drawing.Color.Yellow
        Me.txtinfo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtinfo.Enabled = False
        Me.txtinfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinfo.Location = New System.Drawing.Point(2, 2)
        Me.txtinfo.Multiline = True
        Me.txtinfo.Name = "txtinfo"
        Me.txtinfo.Size = New System.Drawing.Size(415, 82)
        Me.txtinfo.TabIndex = 48
        Me.txtinfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button8
        '
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.Red
        Me.Button8.Location = New System.Drawing.Point(291, 61)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(125, 23)
        Me.Button8.TabIndex = 108
        Me.Button8.Text = "&Cancelar"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.Blue
        Me.Button7.Location = New System.Drawing.Point(7, 61)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(125, 23)
        Me.Button7.TabIndex = 107
        Me.Button7.Text = "&Salvar Arquivo"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button9.Location = New System.Drawing.Point(386, 34)
        Me.Button9.Margin = New System.Windows.Forms.Padding(4)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(30, 24)
        Me.Button9.TabIndex = 106
        Me.Button9.Text = ". . ."
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(213, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Local p/salvar arquivo xml"
        '
        'txtxml_nfe
        '
        Me.txtxml_nfe.BackColor = System.Drawing.Color.White
        Me.txtxml_nfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtxml_nfe.Location = New System.Drawing.Point(7, 36)
        Me.txtxml_nfe.Margin = New System.Windows.Forms.Padding(4)
        Me.txtxml_nfe.Name = "txtxml_nfe"
        Me.txtxml_nfe.Size = New System.Drawing.Size(381, 20)
        Me.txtxml_nfe.TabIndex = 105
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(619, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 16)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Chave NF-e"
        '
        'dgvpesquisa
        '
        Me.dgvpesquisa.AllowUserToAddRows = False
        Me.dgvpesquisa.AllowUserToDeleteRows = False
        Me.dgvpesquisa.AllowUserToResizeColumns = False
        Me.dgvpesquisa.AllowUserToResizeRows = False
        Me.dgvpesquisa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvpesquisa.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvpesquisa.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nomenfegrid, Me.nfegrid, Me.vnf, Me.data_emi, Me.Column4, Me.Column5, Me.chave_nfe, Me.obs_cont, Me.status_nfe, Me.xml_nfe, Me.manifestagrid, Me.par_sg, Me.obscont_grid})
        Me.dgvpesquisa.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvpesquisa.EnableHeadersVisualStyles = False
        Me.dgvpesquisa.GridColor = System.Drawing.Color.Red
        Me.dgvpesquisa.Location = New System.Drawing.Point(3, 27)
        Me.dgvpesquisa.Name = "dgvpesquisa"
        Me.dgvpesquisa.ReadOnly = True
        Me.dgvpesquisa.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvpesquisa.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvpesquisa.RowHeadersWidth = 22
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        Me.dgvpesquisa.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvpesquisa.Size = New System.Drawing.Size(1046, 381)
        Me.dgvpesquisa.TabIndex = 2
        '
        'nomenfegrid
        '
        Me.nomenfegrid.HeaderText = "Nome do Fornecedor"
        Me.nomenfegrid.Name = "nomenfegrid"
        Me.nomenfegrid.ReadOnly = True
        Me.nomenfegrid.Width = 300
        '
        'nfegrid
        '
        Me.nfegrid.HeaderText = "Número NFe"
        Me.nfegrid.Name = "nfegrid"
        Me.nfegrid.ReadOnly = True
        Me.nfegrid.Width = 75
        '
        'vnf
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.vnf.DefaultCellStyle = DataGridViewCellStyle2
        Me.vnf.HeaderText = "Valor NFe"
        Me.vnf.Name = "vnf"
        Me.vnf.ReadOnly = True
        Me.vnf.Width = 80
        '
        'data_emi
        '
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.data_emi.DefaultCellStyle = DataGridViewCellStyle3
        Me.data_emi.HeaderText = "Data Emissão"
        Me.data_emi.Name = "data_emi"
        Me.data_emi.ReadOnly = True
        Me.data_emi.Width = 85
        '
        'Column4
        '
        Me.Column4.HeaderText = "XML NFe"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column4.Width = 60
        '
        'Column5
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column5.HeaderText = "XML Past."
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column5.Width = 80
        '
        'chave_nfe
        '
        Me.chave_nfe.HeaderText = "chave nfe"
        Me.chave_nfe.Name = "chave_nfe"
        Me.chave_nfe.ReadOnly = True
        Me.chave_nfe.Visible = False
        '
        'obs_cont
        '
        Me.obs_cont.HeaderText = "OBS Cont."
        Me.obs_cont.Name = "obs_cont"
        Me.obs_cont.ReadOnly = True
        Me.obs_cont.Width = 80
        '
        'status_nfe
        '
        Me.status_nfe.HeaderText = "Status NF-e"
        Me.status_nfe.Name = "status_nfe"
        Me.status_nfe.ReadOnly = True
        '
        'xml_nfe
        '
        Me.xml_nfe.HeaderText = "xml nfe"
        Me.xml_nfe.Name = "xml_nfe"
        Me.xml_nfe.ReadOnly = True
        Me.xml_nfe.Visible = False
        '
        'manifestagrid
        '
        Me.manifestagrid.HeaderText = "Manifestação dest"
        Me.manifestagrid.Name = "manifestagrid"
        Me.manifestagrid.ReadOnly = True
        Me.manifestagrid.Width = 145
        '
        'par_sg
        '
        Me.par_sg.HeaderText = "par_sg"
        Me.par_sg.Name = "par_sg"
        Me.par_sg.ReadOnly = True
        Me.par_sg.Visible = False
        '
        'obscont_grid
        '
        Me.obscont_grid.HeaderText = "obs cont"
        Me.obscont_grid.Name = "obscont_grid"
        Me.obscont_grid.ReadOnly = True
        Me.obscont_grid.Visible = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManifestacaoDestinatarioToolStripMenuItem, Me.InserirObservacaoNFeToolStripMenuItem, Me.CriarPastaDocToolStripMenuItem, Me.ImportaCTeToolStripMenuItem, Me.VisualizarNFePortalNacionalToolStripMenuItem, Me.ProtocolarNFeToolStripMenuItem, Me.VisualizarEstruturaXMLToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(232, 180)
        '
        'ManifestacaoDestinatarioToolStripMenuItem
        '
        Me.ManifestacaoDestinatarioToolStripMenuItem.Name = "ManifestacaoDestinatarioToolStripMenuItem"
        Me.ManifestacaoDestinatarioToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.ManifestacaoDestinatarioToolStripMenuItem.Text = "Manifestacao Destinatario"
        '
        'InserirObservacaoNFeToolStripMenuItem
        '
        Me.InserirObservacaoNFeToolStripMenuItem.Name = "InserirObservacaoNFeToolStripMenuItem"
        Me.InserirObservacaoNFeToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.InserirObservacaoNFeToolStripMenuItem.Text = "Inserir Observacao NFe"
        '
        'CriarPastaDocToolStripMenuItem
        '
        Me.CriarPastaDocToolStripMenuItem.Name = "CriarPastaDocToolStripMenuItem"
        Me.CriarPastaDocToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.CriarPastaDocToolStripMenuItem.Text = "Mover arquivo Pasta Doc"
        '
        'ImportaCTeToolStripMenuItem
        '
        Me.ImportaCTeToolStripMenuItem.Name = "ImportaCTeToolStripMenuItem"
        Me.ImportaCTeToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.ImportaCTeToolStripMenuItem.Text = "Importa CTe"
        '
        'VisualizarNFePortalNacionalToolStripMenuItem
        '
        Me.VisualizarNFePortalNacionalToolStripMenuItem.Name = "VisualizarNFePortalNacionalToolStripMenuItem"
        Me.VisualizarNFePortalNacionalToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.VisualizarNFePortalNacionalToolStripMenuItem.Text = "Visualizar NFe Portal Nacional"
        '
        'ProtocolarNFeToolStripMenuItem
        '
        Me.ProtocolarNFeToolStripMenuItem.Name = "ProtocolarNFeToolStripMenuItem"
        Me.ProtocolarNFeToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.ProtocolarNFeToolStripMenuItem.Text = "Protocolar NF-e"
        '
        'VisualizarEstruturaXMLToolStripMenuItem
        '
        Me.VisualizarEstruturaXMLToolStripMenuItem.Name = "VisualizarEstruturaXMLToolStripMenuItem"
        Me.VisualizarEstruturaXMLToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.VisualizarEstruturaXMLToolStripMenuItem.Text = "Visualizar estrutura XML"
        '
        'lbltotal
        '
        Me.lbltotal.AutoSize = True
        Me.lbltotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.ForeColor = System.Drawing.Color.Blue
        Me.lbltotal.Location = New System.Drawing.Point(973, 481)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(44, 20)
        Me.lbltotal.TabIndex = 54
        Me.lbltotal.Text = "0,00"
        '
        'lblobscont
        '
        Me.lblobscont.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblobscont.Location = New System.Drawing.Point(5, 481)
        Me.lblobscont.Multiline = True
        Me.lblobscont.Name = "lblobscont"
        Me.lblobscont.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.lblobscont.Size = New System.Drawing.Size(749, 20)
        Me.lblobscont.TabIndex = 53
        '
        'frmpesquisarnfe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1063, 505)
        Me.Controls.Add(Me.lbltotal)
        Me.Controls.Add(Me.lblobscont)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmpesquisarnfe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tela de Pesquisa de Notas Fiscais"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Paneldata.ResumeLayout(False)
        Me.Paneldata.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Pinfo.ResumeLayout(False)
        Me.Panelarq.ResumeLayout(False)
        Me.Panelarq.PerformLayout()
        CType(Me.dgvpesquisa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtpesquisa As System.Windows.Forms.TextBox
    Friend WithEvents cbotipo As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvpesquisa As System.Windows.Forms.DataGridView
    Friend WithEvents txtpar As System.Windows.Forms.TextBox
    Friend WithEvents lblinfo As System.Windows.Forms.Label
    Friend WithEvents txtchave As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents mskdatainicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents mskdatafinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbldatafim As System.Windows.Forms.Label
    Friend WithEvents lbldataini As System.Windows.Forms.Label
    Friend WithEvents Paneldata As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents chkvlrboleto As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ManifestacaoDestinatarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cbostatusnfe As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkstatus_nfe As System.Windows.Forms.CheckBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Pinfo As System.Windows.Forms.Panel
    Friend WithEvents txtinfo As System.Windows.Forms.TextBox
    Friend WithEvents cbotipop As System.Windows.Forms.ComboBox
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents InserirObservacaoNFeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents CriarPastaDocToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportaCTeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblobscont As System.Windows.Forms.TextBox
    Friend WithEvents VisualizarNFePortalNacionalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents lbltotal As System.Windows.Forms.Label
    Friend WithEvents nomenfegrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nfegrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vnf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents data_emi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents chave_nfe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents obs_cont As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status_nfe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents xml_nfe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents manifestagrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents par_sg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents obscont_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents ProtocolarNFeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VisualizarEstruturaXMLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panelarq As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents txtxml_nfe As System.Windows.Forms.TextBox
    Friend WithEvents fbd1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
End Class
