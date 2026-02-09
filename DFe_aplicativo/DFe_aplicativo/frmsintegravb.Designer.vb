<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmsintegravb
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvprd = New System.Windows.Forms.DataGridView()
        Me.codigo_prd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtcontato = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcep = New System.Windows.Forms.MaskedTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtnomefant = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtcodMunicipio = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtuf = New System.Windows.Forms.TextBox()
        Me.txtcnae = New System.Windows.Forms.TextBox()
        Me.txtfone = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtim = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtie = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtcnpj = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtcidade = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtnumero = New System.Windows.Forms.TextBox()
        Me.txtbairro = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtendereco = New System.Windows.Forms.TextBox()
        Me.txtrazaosocial = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Data_invent = New System.Windows.Forms.DateTimePicker()
        Me.chkinven = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cbofin = New System.Windows.Forms.ComboBox()
        Me.cboop = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboconvenio = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.data_fim = New System.Windows.Forms.DateTimePicker()
        Me.data_ini = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.bntsintegra = New System.Windows.Forms.Button()
        Me.lblinfo = New System.Windows.Forms.Label()
        Me.dgv50iten = New System.Windows.Forms.DataGridView()
        Me.cnpj_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ie_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.data_entgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.uf_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.modelo_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.serie_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nrnfe_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cfop_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlr_totalgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bc_icms_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlr_icmsgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlr_isentogrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlr_outrosgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aliq_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chave_pargrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvprd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgv50iten, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dgvprd)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtcontato)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtcep)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtnomefant)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.txtcodMunicipio)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.txtuf)
        Me.Panel1.Controls.Add(Me.txtcnae)
        Me.Panel1.Controls.Add(Me.txtfone)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtim)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtie)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtcnpj)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtcidade)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtnumero)
        Me.Panel1.Controls.Add(Me.txtbairro)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtendereco)
        Me.Panel1.Controls.Add(Me.txtrazaosocial)
        Me.Panel1.Location = New System.Drawing.Point(6, 31)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(630, 170)
        Me.Panel1.TabIndex = 0
        '
        'dgvprd
        '
        Me.dgvprd.AllowUserToAddRows = False
        Me.dgvprd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvprd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo_prd})
        Me.dgvprd.Location = New System.Drawing.Point(470, -1)
        Me.dgvprd.Name = "dgvprd"
        Me.dgvprd.Size = New System.Drawing.Size(152, 18)
        Me.dgvprd.TabIndex = 95
        Me.dgvprd.Visible = False
        '
        'codigo_prd
        '
        Me.codigo_prd.HeaderText = "codigo_prd"
        Me.codigo_prd.Name = "codigo_prd"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(508, 126)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 13)
        Me.Label12.TabIndex = 82
        Me.Label12.Text = "CNAE"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(508, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "Contato"
        '
        'txtcontato
        '
        Me.txtcontato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcontato.Location = New System.Drawing.Point(511, 102)
        Me.txtcontato.MaxLength = 30
        Me.txtcontato.Name = "txtcontato"
        Me.txtcontato.Size = New System.Drawing.Size(114, 20)
        Me.txtcontato.TabIndex = 80
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "CNPJ"
        '
        'txtcep
        '
        Me.txtcep.Location = New System.Drawing.Point(6, 102)
        Me.txtcep.Mask = "00000-999"
        Me.txtcep.Name = "txtcep"
        Me.txtcep.ReadOnly = True
        Me.txtcep.Size = New System.Drawing.Size(63, 20)
        Me.txtcep.TabIndex = 77
        Me.txtcep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 86)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(28, 13)
        Me.Label13.TabIndex = 78
        Me.Label13.Text = "CEP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Endereço empresa"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Nome empresa"
        '
        'txtnomefant
        '
        Me.txtnomefant.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnomefant.Location = New System.Drawing.Point(342, 23)
        Me.txtnomefant.MaxLength = 60
        Me.txtnomefant.Name = "txtnomefant"
        Me.txtnomefant.ReadOnly = True
        Me.txtnomefant.Size = New System.Drawing.Size(283, 20)
        Me.txtnomefant.TabIndex = 47
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(339, 6)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(78, 13)
        Me.Label25.TabIndex = 74
        Me.Label25.Text = "Nome Fantasia"
        '
        'txtcodMunicipio
        '
        Me.txtcodMunicipio.BackColor = System.Drawing.SystemColors.Control
        Me.txtcodMunicipio.Location = New System.Drawing.Point(342, 102)
        Me.txtcodMunicipio.Name = "txtcodMunicipio"
        Me.txtcodMunicipio.ReadOnly = True
        Me.txtcodMunicipio.Size = New System.Drawing.Size(76, 20)
        Me.txtcodMunicipio.TabIndex = 56
        Me.txtcodMunicipio.TabStop = False
        Me.txtcodMunicipio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(339, 86)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(79, 13)
        Me.Label20.TabIndex = 71
        Me.Label20.Text = "Cód. Município"
        '
        'txtuf
        '
        Me.txtuf.BackColor = System.Drawing.SystemColors.Control
        Me.txtuf.Location = New System.Drawing.Point(300, 102)
        Me.txtuf.Name = "txtuf"
        Me.txtuf.ReadOnly = True
        Me.txtuf.Size = New System.Drawing.Size(36, 20)
        Me.txtuf.TabIndex = 54
        Me.txtuf.TabStop = False
        Me.txtuf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtcnae
        '
        Me.txtcnae.Location = New System.Drawing.Point(511, 142)
        Me.txtcnae.Name = "txtcnae"
        Me.txtcnae.ReadOnly = True
        Me.txtcnae.Size = New System.Drawing.Size(114, 20)
        Me.txtcnae.TabIndex = 63
        '
        'txtfone
        '
        Me.txtfone.Location = New System.Drawing.Point(422, 102)
        Me.txtfone.Mask = "(99) 0000-0000"
        Me.txtfone.Name = "txtfone"
        Me.txtfone.ReadOnly = True
        Me.txtfone.Size = New System.Drawing.Size(85, 20)
        Me.txtfone.TabIndex = 64
        Me.txtfone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(419, 86)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 68
        Me.Label11.Text = "Telefone"
        '
        'txtim
        '
        Me.txtim.Location = New System.Drawing.Point(342, 142)
        Me.txtim.MaxLength = 15
        Me.txtim.Name = "txtim"
        Me.txtim.ReadOnly = True
        Me.txtim.Size = New System.Drawing.Size(94, 20)
        Me.txtim.TabIndex = 61
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(339, 126)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 13)
        Me.Label10.TabIndex = 67
        Me.Label10.Text = "Insc. Municipal"
        '
        'txtie
        '
        Me.txtie.Location = New System.Drawing.Point(152, 142)
        Me.txtie.MaxLength = 30
        Me.txtie.Name = "txtie"
        Me.txtie.ReadOnly = True
        Me.txtie.Size = New System.Drawing.Size(145, 20)
        Me.txtie.TabIndex = 59
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(149, 126)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "Insc. Estadual"
        '
        'txtcnpj
        '
        Me.txtcnpj.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtcnpj.Location = New System.Drawing.Point(6, 142)
        Me.txtcnpj.Mask = "00.000.000/0000-00"
        Me.txtcnpj.Name = "txtcnpj"
        Me.txtcnpj.ReadOnly = True
        Me.txtcnpj.Size = New System.Drawing.Size(114, 20)
        Me.txtcnpj.TabIndex = 57
        Me.txtcnpj.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(297, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 13)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "UF"
        '
        'txtcidade
        '
        Me.txtcidade.BackColor = System.Drawing.SystemColors.Control
        Me.txtcidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcidade.Location = New System.Drawing.Point(75, 102)
        Me.txtcidade.Name = "txtcidade"
        Me.txtcidade.ReadOnly = True
        Me.txtcidade.Size = New System.Drawing.Size(222, 20)
        Me.txtcidade.TabIndex = 52
        Me.txtcidade.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(72, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Cidade"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(339, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Número"
        '
        'txtnumero
        '
        Me.txtnumero.Location = New System.Drawing.Point(342, 63)
        Me.txtnumero.MaxLength = 6
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.ReadOnly = True
        Me.txtnumero.Size = New System.Drawing.Size(55, 20)
        Me.txtnumero.TabIndex = 49
        '
        'txtbairro
        '
        Me.txtbairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbairro.Location = New System.Drawing.Point(403, 63)
        Me.txtbairro.MaxLength = 30
        Me.txtbairro.Name = "txtbairro"
        Me.txtbairro.ReadOnly = True
        Me.txtbairro.Size = New System.Drawing.Size(222, 20)
        Me.txtbairro.TabIndex = 50
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(400, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Bairro"
        '
        'txtendereco
        '
        Me.txtendereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtendereco.Location = New System.Drawing.Point(6, 63)
        Me.txtendereco.MaxLength = 100
        Me.txtendereco.Name = "txtendereco"
        Me.txtendereco.ReadOnly = True
        Me.txtendereco.Size = New System.Drawing.Size(330, 20)
        Me.txtendereco.TabIndex = 48
        '
        'txtrazaosocial
        '
        Me.txtrazaosocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrazaosocial.Location = New System.Drawing.Point(6, 23)
        Me.txtrazaosocial.MaxLength = 60
        Me.txtrazaosocial.Name = "txtrazaosocial"
        Me.txtrazaosocial.ReadOnly = True
        Me.txtrazaosocial.Size = New System.Drawing.Size(330, 20)
        Me.txtrazaosocial.TabIndex = 46
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Location = New System.Drawing.Point(6, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(630, 24)
        Me.Panel2.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(172, 2)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(245, 21)
        Me.Label14.TabIndex = 83
        Me.Label14.Text = "DADOS DO ESTABELECIMENTO"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Silver
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Data_invent)
        Me.Panel3.Controls.Add(Me.chkinven)
        Me.Panel3.Controls.Add(Me.Label19)
        Me.Panel3.Controls.Add(Me.cbofin)
        Me.Panel3.Controls.Add(Me.cboop)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.cboconvenio)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.data_fim)
        Me.Panel3.Controls.Add(Me.data_ini)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Location = New System.Drawing.Point(6, 207)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(630, 91)
        Me.Panel3.TabIndex = 2
        '
        'Data_invent
        '
        Me.Data_invent.Enabled = False
        Me.Data_invent.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Data_invent.Location = New System.Drawing.Point(522, 65)
        Me.Data_invent.Name = "Data_invent"
        Me.Data_invent.Size = New System.Drawing.Size(100, 20)
        Me.Data_invent.TabIndex = 94
        '
        'chkinven
        '
        Me.chkinven.AutoSize = True
        Me.chkinven.Location = New System.Drawing.Point(386, 68)
        Me.chkinven.Name = "chkinven"
        Me.chkinven.Size = New System.Drawing.Size(130, 17)
        Me.chkinven.TabIndex = 93
        Me.chkinven.Text = "Registro 74 Inventário"
        Me.chkinven.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(467, 8)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(94, 13)
        Me.Label19.TabIndex = 92
        Me.Label19.Text = "Finalidade Arquivo"
        '
        'cbofin
        '
        Me.cbofin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbofin.FormattingEnabled = True
        Me.cbofin.Items.AddRange(New Object() {"1 - Normal", "2 - Retificação Total de arquivo", "3 - Desfazimento"})
        Me.cbofin.Location = New System.Drawing.Point(470, 24)
        Me.cbofin.Name = "cbofin"
        Me.cbofin.Size = New System.Drawing.Size(152, 21)
        Me.cbofin.TabIndex = 91
        '
        'cboop
        '
        Me.cboop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboop.FormattingEnabled = True
        Me.cboop.Items.AddRange(New Object() {"1 - Interestaduais somente operações sujeitas ao regime de Subst. Tributária", "2 -  Interestaduais operações com ou sem Subst. Tributária", "3 - Totalidade das operações do informante"})
        Me.cboop.Location = New System.Drawing.Point(6, 64)
        Me.cboop.Name = "cboop"
        Me.cboop.Size = New System.Drawing.Size(363, 21)
        Me.cboop.TabIndex = 90
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(3, 48)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(169, 13)
        Me.Label18.TabIndex = 89
        Me.Label18.Text = "Identificação Natureza Operações"
        '
        'cboconvenio
        '
        Me.cboconvenio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboconvenio.FormattingEnabled = True
        Me.cboconvenio.Items.AddRange(New Object() {"1 - Convênio ICMS 31/99", "2 - Convênio ICMS xx/02", "3 - Convênio ICMS 76/03"})
        Me.cboconvenio.Location = New System.Drawing.Point(217, 25)
        Me.cboconvenio.Name = "cboconvenio"
        Me.cboconvenio.Size = New System.Drawing.Size(152, 21)
        Me.cboconvenio.TabIndex = 88
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(214, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(116, 13)
        Me.Label17.TabIndex = 87
        Me.Label17.Text = "Identificação Convênio"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(109, 9)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 13)
        Me.Label16.TabIndex = 86
        Me.Label16.Text = "Data Final"
        '
        'data_fim
        '
        Me.data_fim.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.data_fim.Location = New System.Drawing.Point(112, 25)
        Me.data_fim.Name = "data_fim"
        Me.data_fim.Size = New System.Drawing.Size(100, 20)
        Me.data_fim.TabIndex = 85
        '
        'data_ini
        '
        Me.data_ini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.data_ini.Location = New System.Drawing.Point(6, 25)
        Me.data_ini.Name = "data_ini"
        Me.data_ini.Size = New System.Drawing.Size(100, 20)
        Me.data_ini.TabIndex = 84
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 13)
        Me.Label15.TabIndex = 83
        Me.Label15.Text = "Data Inicial"
        '
        'bntsintegra
        '
        Me.bntsintegra.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bntsintegra.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bntsintegra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntsintegra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bntsintegra.Location = New System.Drawing.Point(6, 304)
        Me.bntsintegra.Name = "bntsintegra"
        Me.bntsintegra.Size = New System.Drawing.Size(121, 30)
        Me.bntsintegra.TabIndex = 47
        Me.bntsintegra.Text = "Gerar Arquivo"
        Me.bntsintegra.UseVisualStyleBackColor = True
        '
        'lblinfo
        '
        Me.lblinfo.AutoSize = True
        Me.lblinfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblinfo.ForeColor = System.Drawing.Color.Blue
        Me.lblinfo.Location = New System.Drawing.Point(133, 314)
        Me.lblinfo.Name = "lblinfo"
        Me.lblinfo.Size = New System.Drawing.Size(11, 13)
        Me.lblinfo.TabIndex = 83
        Me.lblinfo.Text = "-"
        '
        'dgv50iten
        '
        Me.dgv50iten.AllowUserToAddRows = False
        Me.dgv50iten.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv50iten.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cnpj_grid, Me.ie_grid, Me.data_entgrid, Me.uf_grid, Me.modelo_grid, Me.serie_grid, Me.nrnfe_grid, Me.cfop_grid, Me.vlr_totalgrid, Me.bc_icms_grid, Me.vlr_icmsgrid, Me.vlr_isentogrid, Me.vlr_outrosgrid, Me.aliq_grid, Me.chave_pargrid})
        Me.dgv50iten.Location = New System.Drawing.Point(13, 359)
        Me.dgv50iten.Name = "dgv50iten"
        Me.dgv50iten.RowHeadersVisible = False
        Me.dgv50iten.Size = New System.Drawing.Size(616, 105)
        Me.dgv50iten.TabIndex = 84
        '
        'cnpj_grid
        '
        Me.cnpj_grid.HeaderText = "cnpj"
        Me.cnpj_grid.Name = "cnpj_grid"
        '
        'ie_grid
        '
        Me.ie_grid.HeaderText = "ie"
        Me.ie_grid.Name = "ie_grid"
        '
        'data_entgrid
        '
        Me.data_entgrid.HeaderText = "data_ent"
        Me.data_entgrid.Name = "data_entgrid"
        '
        'uf_grid
        '
        Me.uf_grid.HeaderText = "uf"
        Me.uf_grid.Name = "uf_grid"
        '
        'modelo_grid
        '
        Me.modelo_grid.HeaderText = "modelo"
        Me.modelo_grid.Name = "modelo_grid"
        '
        'serie_grid
        '
        Me.serie_grid.HeaderText = "serie"
        Me.serie_grid.Name = "serie_grid"
        '
        'nrnfe_grid
        '
        Me.nrnfe_grid.HeaderText = "nrnfe"
        Me.nrnfe_grid.Name = "nrnfe_grid"
        '
        'cfop_grid
        '
        Me.cfop_grid.HeaderText = "cfop"
        Me.cfop_grid.Name = "cfop_grid"
        '
        'vlr_totalgrid
        '
        Me.vlr_totalgrid.HeaderText = "vlr_total"
        Me.vlr_totalgrid.Name = "vlr_totalgrid"
        '
        'bc_icms_grid
        '
        Me.bc_icms_grid.HeaderText = "bc_icms"
        Me.bc_icms_grid.Name = "bc_icms_grid"
        '
        'vlr_icmsgrid
        '
        Me.vlr_icmsgrid.HeaderText = "vlr_icms"
        Me.vlr_icmsgrid.Name = "vlr_icmsgrid"
        '
        'vlr_isentogrid
        '
        Me.vlr_isentogrid.HeaderText = "vlr_isento"
        Me.vlr_isentogrid.Name = "vlr_isentogrid"
        '
        'vlr_outrosgrid
        '
        Me.vlr_outrosgrid.HeaderText = "vlr_outros"
        Me.vlr_outrosgrid.Name = "vlr_outrosgrid"
        '
        'aliq_grid
        '
        Me.aliq_grid.HeaderText = "aliq"
        Me.aliq_grid.Name = "aliq_grid"
        '
        'chave_pargrid
        '
        Me.chave_pargrid.HeaderText = "chave_pargrid"
        Me.chave_pargrid.Name = "chave_pargrid"
        '
        'frmsintegravb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 338)
        Me.Controls.Add(Me.dgv50iten)
        Me.Controls.Add(Me.lblinfo)
        Me.Controls.Add(Me.bntsintegra)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmsintegravb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gerar Arquivo do Sintegra"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvprd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgv50iten, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtnomefant As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtcodMunicipio As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtuf As System.Windows.Forms.TextBox
    Friend WithEvents txtcnae As System.Windows.Forms.TextBox
    Friend WithEvents txtfone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtim As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtie As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtcnpj As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtcidade As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtnumero As System.Windows.Forms.TextBox
    Friend WithEvents txtbairro As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtendereco As System.Windows.Forms.TextBox
    Friend WithEvents txtrazaosocial As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtcontato As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcep As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Data_invent As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkinven As System.Windows.Forms.CheckBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cbofin As System.Windows.Forms.ComboBox
    Friend WithEvents cboop As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboconvenio As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents data_fim As System.Windows.Forms.DateTimePicker
    Friend WithEvents data_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents bntsintegra As System.Windows.Forms.Button
    Friend WithEvents lblinfo As System.Windows.Forms.Label
    Friend WithEvents dgv50iten As System.Windows.Forms.DataGridView
    Friend WithEvents cnpj_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ie_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents data_entgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents uf_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents modelo_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents serie_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nrnfe_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cfop_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlr_totalgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bc_icms_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlr_icmsgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlr_isentogrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlr_outrosgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aliq_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chave_pargrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvprd As System.Windows.Forms.DataGridView
    Friend WithEvents codigo_prd As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
