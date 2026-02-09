<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmpesquisanfe_Ent
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmpesquisanfe_Ent))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtvlrnf = New System.Windows.Forms.TextBox()
        Me.chkvalor = New System.Windows.Forms.CheckBox()
        Me.txtnumero = New System.Windows.Forms.TextBox()
        Me.chknumero = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkdescricao = New System.Windows.Forms.CheckBox()
        Me.chkdata = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.datafin = New System.Windows.Forms.DateTimePicker()
        Me.Dataini = New System.Windows.Forms.DateTimePicker()
        Me.txtnome = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvpisquisa = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OnsultaNFeSEFAZToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Baixa_xml_MenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XMLAutorizadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XMLNFeCancelada_MenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CartaCorrecaoNFE_MenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirCartaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GerarPDFCartaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnvioEmailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NFeAutorizadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NFeCanceladaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CartaDeCorrecaoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelaNFeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GerarXMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.danfeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbltotalnotas = New System.Windows.Forms.Label()
        Me.SaveFiled_carta = New System.Windows.Forms.SaveFileDialog()
        Me.Tretnfe = New System.Windows.Forms.Timer(Me.components)
        Me.numero_nfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.serie_nfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.modelo_nf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.data_emissao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.data_ent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nome_for = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valor_nfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valor_icms = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cnpj_for = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvpisquisa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtvlrnf)
        Me.Panel1.Controls.Add(Me.chkvalor)
        Me.Panel1.Controls.Add(Me.txtnumero)
        Me.Panel1.Controls.Add(Me.chknumero)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.chkdescricao)
        Me.Panel1.Controls.Add(Me.chkdata)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.datafin)
        Me.Panel1.Controls.Add(Me.Dataini)
        Me.Panel1.Controls.Add(Me.txtnome)
        Me.Panel1.Location = New System.Drawing.Point(3, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(893, 56)
        Me.Panel1.TabIndex = 0
        '
        'txtvlrnf
        '
        Me.txtvlrnf.BackColor = System.Drawing.Color.White
        Me.txtvlrnf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtvlrnf.Enabled = False
        Me.txtvlrnf.Location = New System.Drawing.Point(89, 27)
        Me.txtvlrnf.MaxLength = 9
        Me.txtvlrnf.Name = "txtvlrnf"
        Me.txtvlrnf.Size = New System.Drawing.Size(74, 20)
        Me.txtvlrnf.TabIndex = 63
        Me.txtvlrnf.Text = "0,00"
        Me.txtvlrnf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtvlrnf.WordWrap = False
        '
        'chkvalor
        '
        Me.chkvalor.AutoSize = True
        Me.chkvalor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkvalor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkvalor.Location = New System.Drawing.Point(89, 6)
        Me.chkvalor.Name = "chkvalor"
        Me.chkvalor.Size = New System.Drawing.Size(80, 20)
        Me.chkvalor.TabIndex = 62
        Me.chkvalor.Text = "Valor NF"
        Me.chkvalor.UseVisualStyleBackColor = True
        '
        'txtnumero
        '
        Me.txtnumero.BackColor = System.Drawing.Color.White
        Me.txtnumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnumero.Enabled = False
        Me.txtnumero.Location = New System.Drawing.Point(8, 27)
        Me.txtnumero.MaxLength = 9
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(74, 20)
        Me.txtnumero.TabIndex = 61
        Me.txtnumero.WordWrap = False
        '
        'chknumero
        '
        Me.chknumero.AutoSize = True
        Me.chknumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chknumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chknumero.Location = New System.Drawing.Point(8, 6)
        Me.chknumero.Name = "chknumero"
        Me.chknumero.Size = New System.Drawing.Size(75, 20)
        Me.chknumero.TabIndex = 60
        Me.chknumero.Text = "Número"
        Me.chknumero.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Green
        Me.Button1.Image = Global.DFe_aplicativo.My.Resources.Resources.magnifier_left
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(767, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 25)
        Me.Button1.TabIndex = 59
        Me.Button1.Text = "Pesquisar "
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'chkdescricao
        '
        Me.chkdescricao.AutoSize = True
        Me.chkdescricao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdescricao.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkdescricao.Location = New System.Drawing.Point(170, 6)
        Me.chkdescricao.Name = "chkdescricao"
        Me.chkdescricao.Size = New System.Drawing.Size(156, 20)
        Me.chkdescricao.TabIndex = 58
        Me.chkdescricao.Text = "Nome do Fornecedor"
        Me.chkdescricao.UseVisualStyleBackColor = True
        '
        'chkdata
        '
        Me.chkdata.AutoSize = True
        Me.chkdata.Checked = True
        Me.chkdata.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkdata.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdata.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkdata.Location = New System.Drawing.Point(526, 6)
        Me.chkdata.Name = "chkdata"
        Me.chkdata.Size = New System.Drawing.Size(140, 20)
        Me.chkdata.TabIndex = 57
        Me.chkdata.Text = "Pesquisa Por Data"
        Me.chkdata.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(621, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 16)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "à"
        '
        'datafin
        '
        Me.datafin.Enabled = False
        Me.datafin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datafin.Location = New System.Drawing.Point(637, 27)
        Me.datafin.Name = "datafin"
        Me.datafin.Size = New System.Drawing.Size(95, 20)
        Me.datafin.TabIndex = 55
        '
        'Dataini
        '
        Me.Dataini.Enabled = False
        Me.Dataini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dataini.Location = New System.Drawing.Point(526, 27)
        Me.Dataini.Name = "Dataini"
        Me.Dataini.Size = New System.Drawing.Size(95, 20)
        Me.Dataini.TabIndex = 54
        '
        'txtnome
        '
        Me.txtnome.BackColor = System.Drawing.Color.White
        Me.txtnome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnome.Enabled = False
        Me.txtnome.Location = New System.Drawing.Point(170, 27)
        Me.txtnome.Name = "txtnome"
        Me.txtnome.Size = New System.Drawing.Size(328, 20)
        Me.txtnome.TabIndex = 1
        Me.txtnome.WordWrap = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dgvpisquisa)
        Me.Panel2.Location = New System.Drawing.Point(3, 67)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(893, 468)
        Me.Panel2.TabIndex = 1
        '
        'dgvpisquisa
        '
        Me.dgvpisquisa.AllowUserToAddRows = False
        Me.dgvpisquisa.AllowUserToDeleteRows = False
        Me.dgvpisquisa.AllowUserToOrderColumns = True
        Me.dgvpisquisa.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvpisquisa.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvpisquisa.BackgroundColor = System.Drawing.Color.LightGray
        Me.dgvpisquisa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvpisquisa.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvpisquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvpisquisa.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.numero_nfe, Me.serie_nfe, Me.modelo_nf, Me.data_emissao, Me.data_ent, Me.nome_for, Me.valor_nfe, Me.valor_icms, Me.cnpj_for})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvpisquisa.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvpisquisa.EnableHeadersVisualStyles = False
        Me.dgvpisquisa.GridColor = System.Drawing.Color.Lime
        Me.dgvpisquisa.Location = New System.Drawing.Point(3, 3)
        Me.dgvpisquisa.MultiSelect = False
        Me.dgvpisquisa.Name = "dgvpisquisa"
        Me.dgvpisquisa.ReadOnly = True
        Me.dgvpisquisa.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvpisquisa.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvpisquisa.RowHeadersWidth = 24
        Me.dgvpisquisa.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        Me.dgvpisquisa.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvpisquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvpisquisa.Size = New System.Drawing.Size(884, 460)
        Me.dgvpisquisa.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OnsultaNFeSEFAZToolStripMenuItem, Me.Baixa_xml_MenuItem, Me.CartaCorrecaoNFE_MenuItem, Me.EnvioEmailToolStripMenuItem, Me.CancelaNFeToolStripMenuItem, Me.GerarXMLToolStripMenuItem, Me.danfeToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(202, 158)
        '
        'OnsultaNFeSEFAZToolStripMenuItem
        '
        Me.OnsultaNFeSEFAZToolStripMenuItem.Name = "OnsultaNFeSEFAZToolStripMenuItem"
        Me.OnsultaNFeSEFAZToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.OnsultaNFeSEFAZToolStripMenuItem.Text = "Consulta NFe SEFAZ"
        '
        'Baixa_xml_MenuItem
        '
        Me.Baixa_xml_MenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.XMLAutorizadoToolStripMenuItem, Me.XMLNFeCancelada_MenuItem})
        Me.Baixa_xml_MenuItem.Enabled = False
        Me.Baixa_xml_MenuItem.Name = "Baixa_xml_MenuItem"
        Me.Baixa_xml_MenuItem.Size = New System.Drawing.Size(201, 22)
        Me.Baixa_xml_MenuItem.Text = "Baixar XML NFe"
        '
        'XMLAutorizadoToolStripMenuItem
        '
        Me.XMLAutorizadoToolStripMenuItem.Name = "XMLAutorizadoToolStripMenuItem"
        Me.XMLAutorizadoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.XMLAutorizadoToolStripMenuItem.Text = "XML Autorizado"
        '
        'XMLNFeCancelada_MenuItem
        '
        Me.XMLNFeCancelada_MenuItem.Enabled = False
        Me.XMLNFeCancelada_MenuItem.Name = "XMLNFeCancelada_MenuItem"
        Me.XMLNFeCancelada_MenuItem.Size = New System.Drawing.Size(180, 22)
        Me.XMLNFeCancelada_MenuItem.Text = "XML NFe Cancelada"
        '
        'CartaCorrecaoNFE_MenuItem
        '
        Me.CartaCorrecaoNFE_MenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirCartaToolStripMenuItem, Me.GerarPDFCartaToolStripMenuItem})
        Me.CartaCorrecaoNFE_MenuItem.Enabled = False
        Me.CartaCorrecaoNFE_MenuItem.Name = "CartaCorrecaoNFE_MenuItem"
        Me.CartaCorrecaoNFE_MenuItem.Size = New System.Drawing.Size(201, 22)
        Me.CartaCorrecaoNFE_MenuItem.Text = "Carta Correcao NFE"
        '
        'ImprimirCartaToolStripMenuItem
        '
        Me.ImprimirCartaToolStripMenuItem.Name = "ImprimirCartaToolStripMenuItem"
        Me.ImprimirCartaToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ImprimirCartaToolStripMenuItem.Text = "Imprimir Carta"
        '
        'GerarPDFCartaToolStripMenuItem
        '
        Me.GerarPDFCartaToolStripMenuItem.Name = "GerarPDFCartaToolStripMenuItem"
        Me.GerarPDFCartaToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.GerarPDFCartaToolStripMenuItem.Text = "Gerar PDF Carta"
        '
        'EnvioEmailToolStripMenuItem
        '
        Me.EnvioEmailToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NFeAutorizadaToolStripMenuItem, Me.NFeCanceladaToolStripMenuItem, Me.CartaDeCorrecaoToolStripMenuItem})
        Me.EnvioEmailToolStripMenuItem.Name = "EnvioEmailToolStripMenuItem"
        Me.EnvioEmailToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.EnvioEmailToolStripMenuItem.Text = "Envio e-mail NFe"
        '
        'NFeAutorizadaToolStripMenuItem
        '
        Me.NFeAutorizadaToolStripMenuItem.Enabled = False
        Me.NFeAutorizadaToolStripMenuItem.Name = "NFeAutorizadaToolStripMenuItem"
        Me.NFeAutorizadaToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.NFeAutorizadaToolStripMenuItem.Text = "NFe Autorizada "
        '
        'NFeCanceladaToolStripMenuItem
        '
        Me.NFeCanceladaToolStripMenuItem.Enabled = False
        Me.NFeCanceladaToolStripMenuItem.Name = "NFeCanceladaToolStripMenuItem"
        Me.NFeCanceladaToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.NFeCanceladaToolStripMenuItem.Text = "NFe Cancelada"
        '
        'CartaDeCorrecaoToolStripMenuItem
        '
        Me.CartaDeCorrecaoToolStripMenuItem.Enabled = False
        Me.CartaDeCorrecaoToolStripMenuItem.Name = "CartaDeCorrecaoToolStripMenuItem"
        Me.CartaDeCorrecaoToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.CartaDeCorrecaoToolStripMenuItem.Text = "Carta de correcao"
        '
        'CancelaNFeToolStripMenuItem
        '
        Me.CancelaNFeToolStripMenuItem.Name = "CancelaNFeToolStripMenuItem"
        Me.CancelaNFeToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.CancelaNFeToolStripMenuItem.Text = "Cancelar NF-e"
        '
        'GerarXMLToolStripMenuItem
        '
        Me.GerarXMLToolStripMenuItem.Name = "GerarXMLToolStripMenuItem"
        Me.GerarXMLToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.GerarXMLToolStripMenuItem.Text = "Emitir Contigencia NF-e"
        '
        'danfeToolStripMenuItem
        '
        Me.danfeToolStripMenuItem.Name = "danfeToolStripMenuItem"
        Me.danfeToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.danfeToolStripMenuItem.Text = "DANFE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 538)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(294, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Total de Nota(s) Encontradas: "
        '
        'lbltotalnotas
        '
        Me.lbltotalnotas.AutoSize = True
        Me.lbltotalnotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalnotas.Location = New System.Drawing.Point(292, 538)
        Me.lbltotalnotas.Name = "lbltotalnotas"
        Me.lbltotalnotas.Size = New System.Drawing.Size(72, 24)
        Me.lbltotalnotas.TabIndex = 3
        Me.lbltotalnotas.Text = "Label4"
        '
        'Tretnfe
        '
        Me.Tretnfe.Interval = 1000
        '
        'numero_nfe
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.numero_nfe.DefaultCellStyle = DataGridViewCellStyle3
        Me.numero_nfe.HeaderText = "Numero NFe"
        Me.numero_nfe.Name = "numero_nfe"
        Me.numero_nfe.ReadOnly = True
        Me.numero_nfe.Width = 80
        '
        'serie_nfe
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.serie_nfe.DefaultCellStyle = DataGridViewCellStyle4
        Me.serie_nfe.HeaderText = "Série"
        Me.serie_nfe.Name = "serie_nfe"
        Me.serie_nfe.ReadOnly = True
        Me.serie_nfe.Width = 45
        '
        'modelo_nf
        '
        Me.modelo_nf.HeaderText = "Modelo"
        Me.modelo_nf.Name = "modelo_nf"
        Me.modelo_nf.ReadOnly = True
        Me.modelo_nf.Width = 60
        '
        'data_emissao
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.data_emissao.DefaultCellStyle = DataGridViewCellStyle5
        Me.data_emissao.HeaderText = "Data Emissão"
        Me.data_emissao.Name = "data_emissao"
        Me.data_emissao.ReadOnly = True
        Me.data_emissao.Width = 80
        '
        'data_ent
        '
        Me.data_ent.HeaderText = "Data Ent."
        Me.data_ent.Name = "data_ent"
        Me.data_ent.ReadOnly = True
        Me.data_ent.Width = 80
        '
        'nome_for
        '
        Me.nome_for.HeaderText = "Fornecedor da Nota Fiscal"
        Me.nome_for.Name = "nome_for"
        Me.nome_for.ReadOnly = True
        Me.nome_for.Width = 300
        '
        'valor_nfe
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.valor_nfe.DefaultCellStyle = DataGridViewCellStyle6
        Me.valor_nfe.HeaderText = "Valor Total NFe"
        Me.valor_nfe.Name = "valor_nfe"
        Me.valor_nfe.ReadOnly = True
        Me.valor_nfe.Width = 95
        '
        'valor_icms
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.valor_icms.DefaultCellStyle = DataGridViewCellStyle7
        Me.valor_icms.HeaderText = "Valor ICMS"
        Me.valor_icms.Name = "valor_icms"
        Me.valor_icms.ReadOnly = True
        '
        'cnpj_for
        '
        Me.cnpj_for.HeaderText = "cnpj for"
        Me.cnpj_for.Name = "cnpj_for"
        Me.cnpj_for.ReadOnly = True
        Me.cnpj_for.Visible = False
        '
        'frmpesquisanfe_Ent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(899, 571)
        Me.Controls.Add(Me.lbltotalnotas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmpesquisanfe_Ent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Notas Fiscais"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvpisquisa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvpisquisa As System.Windows.Forms.DataGridView
    Friend WithEvents txtnome As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents datafin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dataini As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkdata As System.Windows.Forms.CheckBox
    Friend WithEvents chkdescricao As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtnumero As System.Windows.Forms.TextBox
    Friend WithEvents chknumero As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbltotalnotas As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OnsultaNFeSEFAZToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Baixa_xml_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CartaCorrecaoNFE_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirCartaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GerarPDFCartaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XMLAutorizadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XMLNFeCancelada_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnvioEmailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NFeAutorizadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NFeCanceladaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CartaDeCorrecaoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFiled_carta As SaveFileDialog
    Friend WithEvents CancelaNFeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GerarXMLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents danfeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tretnfe As System.Windows.Forms.Timer
    Friend WithEvents txtvlrnf As System.Windows.Forms.TextBox
    Friend WithEvents chkvalor As System.Windows.Forms.CheckBox
    Friend WithEvents numero_nfe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents serie_nfe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents modelo_nf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents data_emissao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents data_ent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nome_for As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor_nfe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor_icms As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cnpj_for As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
