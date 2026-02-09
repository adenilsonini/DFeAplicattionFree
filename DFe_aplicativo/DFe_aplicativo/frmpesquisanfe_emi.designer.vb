<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmpesquisanfe_emi
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmpesquisanfe_emi))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkstatus = New System.Windows.Forms.CheckBox()
        Me.txtnumero = New System.Windows.Forms.TextBox()
        Me.chknumero = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkdescricao = New System.Windows.Forms.CheckBox()
        Me.chkdata = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbostatus = New System.Windows.Forms.ComboBox()
        Me.datafin = New System.Windows.Forms.DateTimePicker()
        Me.Dataini = New System.Windows.Forms.DateTimePicker()
        Me.txtnome = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.mskfone = New System.Windows.Forms.MaskedTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtcidadeuf = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtbairrocep = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtendfor = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtprot_nfe = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtiedest = New System.Windows.Forms.TextBox()
        Me.mskcnpjdest = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtiefor = New System.Windows.Forms.TextBox()
        Me.mskcnpjfor = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Pinfo = New System.Windows.Forms.Panel()
        Me.txtinfo = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dgvpisquisa = New System.Windows.Forms.DataGridView()
        Me.numero_nfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.serie_nfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.data_emissao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.destinatario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valor_nfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status_NFe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xml_aut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xml_canc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nprot_canc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xmotivogrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.XML_Gerado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cfop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chave_nfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cod_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xml_carta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cstatgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.recibogrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nprotgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Pinfo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvpisquisa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.chkstatus)
        Me.Panel1.Controls.Add(Me.txtnumero)
        Me.Panel1.Controls.Add(Me.chknumero)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.chkdescricao)
        Me.Panel1.Controls.Add(Me.chkdata)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cbostatus)
        Me.Panel1.Controls.Add(Me.datafin)
        Me.Panel1.Controls.Add(Me.Dataini)
        Me.Panel1.Controls.Add(Me.txtnome)
        Me.Panel1.Location = New System.Drawing.Point(3, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(955, 56)
        Me.Panel1.TabIndex = 0
        '
        'chkstatus
        '
        Me.chkstatus.AutoSize = True
        Me.chkstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkstatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkstatus.Location = New System.Drawing.Point(8, 6)
        Me.chkstatus.Name = "chkstatus"
        Me.chkstatus.Size = New System.Drawing.Size(97, 20)
        Me.chkstatus.TabIndex = 62
        Me.chkstatus.Text = "Status NF-e"
        Me.chkstatus.UseVisualStyleBackColor = True
        '
        'txtnumero
        '
        Me.txtnumero.BackColor = System.Drawing.Color.White
        Me.txtnumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnumero.Enabled = False
        Me.txtnumero.Location = New System.Drawing.Point(142, 27)
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
        Me.chknumero.Location = New System.Drawing.Point(142, 6)
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
        Me.Button1.Location = New System.Drawing.Point(826, 22)
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
        Me.chkdescricao.Location = New System.Drawing.Point(237, 6)
        Me.chkdescricao.Name = "chkdescricao"
        Me.chkdescricao.Size = New System.Drawing.Size(158, 20)
        Me.chkdescricao.TabIndex = 58
        Me.chkdescricao.Text = "Nome do Destinatário"
        Me.chkdescricao.UseVisualStyleBackColor = True
        '
        'chkdata
        '
        Me.chkdata.AutoSize = True
        Me.chkdata.Checked = True
        Me.chkdata.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkdata.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdata.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkdata.Location = New System.Drawing.Point(593, 6)
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
        Me.Label3.Location = New System.Drawing.Point(688, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 16)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "à"
        '
        'cbostatus
        '
        Me.cbostatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbostatus.Enabled = False
        Me.cbostatus.FormattingEnabled = True
        Me.cbostatus.Items.AddRange(New Object() {"NFe Autorizada", "NFe Cancelada", "Nao Transmitida", "NFe XML invalido"})
        Me.cbostatus.Location = New System.Drawing.Point(8, 26)
        Me.cbostatus.Name = "cbostatus"
        Me.cbostatus.Size = New System.Drawing.Size(111, 21)
        Me.cbostatus.TabIndex = 3
        '
        'datafin
        '
        Me.datafin.Enabled = False
        Me.datafin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datafin.Location = New System.Drawing.Point(704, 27)
        Me.datafin.Name = "datafin"
        Me.datafin.Size = New System.Drawing.Size(95, 20)
        Me.datafin.TabIndex = 55
        '
        'Dataini
        '
        Me.Dataini.Enabled = False
        Me.Dataini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dataini.Location = New System.Drawing.Point(593, 27)
        Me.Dataini.Name = "Dataini"
        Me.Dataini.Size = New System.Drawing.Size(95, 20)
        Me.Dataini.TabIndex = 54
        '
        'txtnome
        '
        Me.txtnome.BackColor = System.Drawing.Color.White
        Me.txtnome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnome.Enabled = False
        Me.txtnome.Location = New System.Drawing.Point(237, 27)
        Me.txtnome.Name = "txtnome"
        Me.txtnome.Size = New System.Drawing.Size(328, 20)
        Me.txtnome.TabIndex = 1
        Me.txtnome.WordWrap = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Pinfo)
        Me.Panel2.Controls.Add(Me.dgvpisquisa)
        Me.Panel2.Location = New System.Drawing.Point(3, 67)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(955, 468)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.txtemail)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.mskfone)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.txtcidadeuf)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.txtbairrocep)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.txtendfor)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.TextBox1)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.txtprot_nfe)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txtiedest)
        Me.Panel3.Controls.Add(Me.mskcnpjdest)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtiefor)
        Me.Panel3.Controls.Add(Me.mskcnpjfor)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(46, 176)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(887, 10)
        Me.Panel3.TabIndex = 48
        Me.Panel3.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(594, 50)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 13)
        Me.Label14.TabIndex = 57
        Me.Label14.Text = "Email"
        '
        'txtemail
        '
        Me.txtemail.Location = New System.Drawing.Point(597, 62)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(272, 20)
        Me.txtemail.TabIndex = 56
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(450, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(28, 13)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "fone"
        '
        'mskfone
        '
        Me.mskfone.BackColor = System.Drawing.Color.White
        Me.mskfone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskfone.Location = New System.Drawing.Point(453, 62)
        Me.mskfone.Mask = "(00) 0000-0000"
        Me.mskfone.Name = "mskfone"
        Me.mskfone.ReadOnly = True
        Me.mskfone.Size = New System.Drawing.Size(122, 20)
        Me.mskfone.TabIndex = 54
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(745, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 53
        Me.Label12.Text = "cidade_uf"
        '
        'txtcidadeuf
        '
        Me.txtcidadeuf.Location = New System.Drawing.Point(748, 27)
        Me.txtcidadeuf.Name = "txtcidadeuf"
        Me.txtcidadeuf.Size = New System.Drawing.Size(121, 20)
        Me.txtcidadeuf.TabIndex = 52
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(592, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 13)
        Me.Label11.TabIndex = 51
        Me.Label11.Text = "bairro_cep"
        '
        'txtbairrocep
        '
        Me.txtbairrocep.Location = New System.Drawing.Point(597, 27)
        Me.txtbairrocep.Name = "txtbairrocep"
        Me.txtbairrocep.Size = New System.Drawing.Size(139, 20)
        Me.txtbairrocep.TabIndex = 50
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(450, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 13)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "endereço emitente"
        '
        'txtendfor
        '
        Me.txtendfor.Location = New System.Drawing.Point(452, 27)
        Me.txtendfor.Name = "txtendfor"
        Me.txtendfor.Size = New System.Drawing.Size(139, 20)
        Me.txtendfor.TabIndex = 48
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(280, 47)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Nome emitente"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(283, 62)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(158, 20)
        Me.TextBox1.TabIndex = 46
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(280, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "protocolo nfe"
        '
        'txtprot_nfe
        '
        Me.txtprot_nfe.BackColor = System.Drawing.Color.White
        Me.txtprot_nfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtprot_nfe.Location = New System.Drawing.Point(283, 27)
        Me.txtprot_nfe.Name = "txtprot_nfe"
        Me.txtprot_nfe.ReadOnly = True
        Me.txtprot_nfe.Size = New System.Drawing.Size(125, 20)
        Me.txtprot_nfe.TabIndex = 44
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(143, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "EI dest"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "cnpj dest"
        '
        'txtiedest
        '
        Me.txtiedest.BackColor = System.Drawing.Color.White
        Me.txtiedest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtiedest.Location = New System.Drawing.Point(143, 62)
        Me.txtiedest.Name = "txtiedest"
        Me.txtiedest.ReadOnly = True
        Me.txtiedest.Size = New System.Drawing.Size(125, 20)
        Me.txtiedest.TabIndex = 41
        '
        'mskcnpjdest
        '
        Me.mskcnpjdest.BackColor = System.Drawing.Color.White
        Me.mskcnpjdest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskcnpjdest.Location = New System.Drawing.Point(15, 62)
        Me.mskcnpjdest.Mask = "00,000,000/0000-00"
        Me.mskcnpjdest.Name = "mskcnpjdest"
        Me.mskcnpjdest.ReadOnly = True
        Me.mskcnpjdest.Size = New System.Drawing.Size(122, 20)
        Me.mskcnpjdest.TabIndex = 40
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(143, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "EI emi"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "cnpj emi"
        '
        'txtiefor
        '
        Me.txtiefor.BackColor = System.Drawing.Color.White
        Me.txtiefor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtiefor.Location = New System.Drawing.Point(143, 24)
        Me.txtiefor.Name = "txtiefor"
        Me.txtiefor.ReadOnly = True
        Me.txtiefor.Size = New System.Drawing.Size(125, 20)
        Me.txtiefor.TabIndex = 37
        '
        'mskcnpjfor
        '
        Me.mskcnpjfor.BackColor = System.Drawing.Color.White
        Me.mskcnpjfor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskcnpjfor.Location = New System.Drawing.Point(15, 24)
        Me.mskcnpjfor.Mask = "00,000,000/0000-00"
        Me.mskcnpjfor.Name = "mskcnpjfor"
        Me.mskcnpjfor.ReadOnly = True
        Me.mskcnpjfor.Size = New System.Drawing.Size(122, 20)
        Me.mskcnpjfor.TabIndex = 36
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(343, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Dados carta correção"
        '
        'Pinfo
        '
        Me.Pinfo.BackColor = System.Drawing.Color.Red
        Me.Pinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pinfo.Controls.Add(Me.txtinfo)
        Me.Pinfo.Controls.Add(Me.PictureBox1)
        Me.Pinfo.Location = New System.Drawing.Point(308, 39)
        Me.Pinfo.Name = "Pinfo"
        Me.Pinfo.Size = New System.Drawing.Size(414, 81)
        Me.Pinfo.TabIndex = 47
        Me.Pinfo.Visible = False
        '
        'txtinfo
        '
        Me.txtinfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtinfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinfo.ForeColor = System.Drawing.Color.Blue
        Me.txtinfo.Location = New System.Drawing.Point(8, 8)
        Me.txtinfo.Multiline = True
        Me.txtinfo.Name = "txtinfo"
        Me.txtinfo.ReadOnly = True
        Me.txtinfo.Size = New System.Drawing.Size(396, 65)
        Me.txtinfo.TabIndex = 1
        Me.txtinfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(406, 74)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'dgvpisquisa
        '
        Me.dgvpisquisa.AllowUserToAddRows = False
        Me.dgvpisquisa.AllowUserToDeleteRows = False
        Me.dgvpisquisa.AllowUserToOrderColumns = True
        Me.dgvpisquisa.AllowUserToResizeColumns = False
        Me.dgvpisquisa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvpisquisa.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvpisquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvpisquisa.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.numero_nfe, Me.serie_nfe, Me.data_emissao, Me.destinatario, Me.valor_nfe, Me.status_NFe, Me.xml_aut, Me.xml_canc, Me.nprot_canc, Me.xmotivogrid, Me.XML_Gerado, Me.cfop, Me.chave_nfe, Me.cod_status, Me.xml_carta, Me.cstatgrid, Me.recibogrid, Me.nprotgrid})
        Me.dgvpisquisa.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvpisquisa.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvpisquisa.EnableHeadersVisualStyles = False
        Me.dgvpisquisa.GridColor = System.Drawing.Color.Lime
        Me.dgvpisquisa.Location = New System.Drawing.Point(3, 3)
        Me.dgvpisquisa.MultiSelect = False
        Me.dgvpisquisa.Name = "dgvpisquisa"
        Me.dgvpisquisa.ReadOnly = True
        Me.dgvpisquisa.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvpisquisa.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvpisquisa.RowHeadersWidth = 24
        Me.dgvpisquisa.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver
        Me.dgvpisquisa.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvpisquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvpisquisa.Size = New System.Drawing.Size(947, 460)
        Me.dgvpisquisa.TabIndex = 0
        '
        'numero_nfe
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.numero_nfe.DefaultCellStyle = DataGridViewCellStyle2
        Me.numero_nfe.HeaderText = "Numero NFe"
        Me.numero_nfe.Name = "numero_nfe"
        Me.numero_nfe.ReadOnly = True
        Me.numero_nfe.Width = 80
        '
        'serie_nfe
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.serie_nfe.DefaultCellStyle = DataGridViewCellStyle3
        Me.serie_nfe.HeaderText = "Série"
        Me.serie_nfe.Name = "serie_nfe"
        Me.serie_nfe.ReadOnly = True
        Me.serie_nfe.Width = 45
        '
        'data_emissao
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "d"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.data_emissao.DefaultCellStyle = DataGridViewCellStyle4
        Me.data_emissao.HeaderText = "Data Emissão"
        Me.data_emissao.Name = "data_emissao"
        Me.data_emissao.ReadOnly = True
        Me.data_emissao.Width = 120
        '
        'destinatario
        '
        Me.destinatario.HeaderText = "Destinatário da Nota Fiscal"
        Me.destinatario.Name = "destinatario"
        Me.destinatario.ReadOnly = True
        Me.destinatario.Width = 300
        '
        'valor_nfe
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.valor_nfe.DefaultCellStyle = DataGridViewCellStyle5
        Me.valor_nfe.HeaderText = "Valor Total NFe"
        Me.valor_nfe.Name = "valor_nfe"
        Me.valor_nfe.ReadOnly = True
        Me.valor_nfe.Width = 95
        '
        'status_NFe
        '
        Me.status_NFe.HeaderText = "Status NFe"
        Me.status_NFe.Name = "status_NFe"
        Me.status_NFe.ReadOnly = True
        Me.status_NFe.Width = 265
        '
        'xml_aut
        '
        Me.xml_aut.HeaderText = "xml_aut"
        Me.xml_aut.Name = "xml_aut"
        Me.xml_aut.ReadOnly = True
        Me.xml_aut.Visible = False
        '
        'xml_canc
        '
        Me.xml_canc.HeaderText = "xml_canc"
        Me.xml_canc.Name = "xml_canc"
        Me.xml_canc.ReadOnly = True
        Me.xml_canc.Visible = False
        '
        'nprot_canc
        '
        Me.nprot_canc.HeaderText = "nprot_canc"
        Me.nprot_canc.Name = "nprot_canc"
        Me.nprot_canc.ReadOnly = True
        Me.nprot_canc.Visible = False
        '
        'xmotivogrid
        '
        Me.xmotivogrid.HeaderText = "xmotivo_canc"
        Me.xmotivogrid.Name = "xmotivogrid"
        Me.xmotivogrid.ReadOnly = True
        Me.xmotivogrid.Visible = False
        '
        'XML_Gerado
        '
        Me.XML_Gerado.HeaderText = "XML_Gerado"
        Me.XML_Gerado.Name = "XML_Gerado"
        Me.XML_Gerado.ReadOnly = True
        Me.XML_Gerado.Visible = False
        '
        'cfop
        '
        Me.cfop.HeaderText = "cfop"
        Me.cfop.Name = "cfop"
        Me.cfop.ReadOnly = True
        Me.cfop.Visible = False
        '
        'chave_nfe
        '
        Me.chave_nfe.HeaderText = "chave nfe"
        Me.chave_nfe.Name = "chave_nfe"
        Me.chave_nfe.ReadOnly = True
        Me.chave_nfe.Visible = False
        '
        'cod_status
        '
        Me.cod_status.HeaderText = "cod_status"
        Me.cod_status.Name = "cod_status"
        Me.cod_status.ReadOnly = True
        Me.cod_status.Visible = False
        '
        'xml_carta
        '
        Me.xml_carta.HeaderText = "xml_carta"
        Me.xml_carta.Name = "xml_carta"
        Me.xml_carta.ReadOnly = True
        Me.xml_carta.Visible = False
        '
        'cstatgrid
        '
        Me.cstatgrid.HeaderText = "cstat"
        Me.cstatgrid.Name = "cstatgrid"
        Me.cstatgrid.ReadOnly = True
        Me.cstatgrid.Visible = False
        '
        'recibogrid
        '
        Me.recibogrid.HeaderText = "recibogrid"
        Me.recibogrid.Name = "recibogrid"
        Me.recibogrid.ReadOnly = True
        Me.recibogrid.Visible = False
        '
        'nprotgrid
        '
        Me.nprotgrid.HeaderText = "nprotgrid"
        Me.nprotgrid.Name = "nprotgrid"
        Me.nprotgrid.ReadOnly = True
        Me.nprotgrid.Visible = False
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
        'frmpesquisanfe_emi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(962, 571)
        Me.Controls.Add(Me.lbltotalnotas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmpesquisanfe_emi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Notas Fiscais"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Pinfo.ResumeLayout(False)
        Me.Pinfo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvpisquisa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvpisquisa As System.Windows.Forms.DataGridView
    Friend WithEvents cbostatus As System.Windows.Forms.ComboBox
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
    Friend WithEvents chkstatus As System.Windows.Forms.CheckBox
    Friend WithEvents Pinfo As System.Windows.Forms.Panel
    Friend WithEvents txtinfo As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OnsultaNFeSEFAZToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Baixa_xml_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CartaCorrecaoNFE_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirCartaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GerarPDFCartaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XMLAutorizadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XMLNFeCancelada_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtiefor As System.Windows.Forms.TextBox
    Friend WithEvents mskcnpjfor As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtiedest As System.Windows.Forms.TextBox
    Friend WithEvents mskcnpjdest As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtprot_nfe As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtendfor As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtbairrocep As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents mskfone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtcidadeuf As System.Windows.Forms.TextBox
    Friend WithEvents EnvioEmailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NFeAutorizadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NFeCanceladaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CartaDeCorrecaoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFiled_carta As SaveFileDialog
    Friend WithEvents CancelaNFeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents numero_nfe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents serie_nfe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents data_emissao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents destinatario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor_nfe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status_NFe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents xml_aut As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents xml_canc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nprot_canc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents xmotivogrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents XML_Gerado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cfop As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chave_nfe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cod_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents xml_carta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cstatgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents recibogrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nprotgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GerarXMLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents danfeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tretnfe As System.Windows.Forms.Timer
End Class
