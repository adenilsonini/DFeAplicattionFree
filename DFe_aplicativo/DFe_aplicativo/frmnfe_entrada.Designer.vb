<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmnfe_entrada
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmnfe_entrada))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel_ini = New System.Windows.Forms.Panel()
        Me.lbluf = New System.Windows.Forms.Label()
        Me.txtnumeronf = New System.Windows.Forms.TextBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.txtnome_emi = New System.Windows.Forms.TextBox()
        Me.Label172 = New System.Windows.Forms.Label()
        Me.mskcnpj_emi = New System.Windows.Forms.MaskedTextBox()
        Me.Label171 = New System.Windows.Forms.Label()
        Me.data_entrada = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbomodelo = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.data_emissao = New System.Windows.Forms.DateTimePicker()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtserienfe = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Panel_totais = New System.Windows.Forms.Panel()
        Me.txtsttotalxml = New System.Windows.Forms.TextBox()
        Me.txtoutrostotalxml = New System.Windows.Forms.TextBox()
        Me.txtfretetotalxml = New System.Windows.Forms.TextBox()
        Me.txtipitotalxml = New System.Windows.Forms.TextBox()
        Me.txtvlrxml = New System.Windows.Forms.TextBox()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.txtvlrfemst = New System.Windows.Forms.TextBox()
        Me.txtvlrtotalbaseicms_nfe = New System.Windows.Forms.TextBox()
        Me.txtvlrtotalicms_nfe = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.txtvlrtotalbasest_nfe = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.txtvrltotalipi_nfe = New System.Windows.Forms.TextBox()
        Me.txtvlrtotalst_nfe = New System.Windows.Forms.TextBox()
        Me.txtvlrtotalcofins_nfe = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.txtvlrtotalfrete_nfe = New System.Windows.Forms.TextBox()
        Me.txtvlrtotaloutras_nfe = New System.Windows.Forms.TextBox()
        Me.txtvlrtotaldesc_nfe = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.txtvlrtotalpis_nfe = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.txtvlrtotalseg_nfe = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Panel30 = New System.Windows.Forms.Panel()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtvlrtotal_nfe = New System.Windows.Forms.TextBox()
        Me.txtvlrtotalprod_nfe = New System.Windows.Forms.TextBox()
        Me.dgvitens = New System.Windows.Forms.DataGridView()
        Me.Nr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codprod_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descprod_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.un_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qtde_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlrunit_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlrdesc_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlrtotal_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ncm_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cest_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cfop_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cst_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.baseicms_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Redbcicms_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aliqicms_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlricms_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlrst_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cstpis_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aliqpis_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlrpis_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aliqcofins_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlrcofins_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cstipi_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aliqipi_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlripi_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.basest_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlrfrete_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlroutros_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlrseguro_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlrfcpst_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.obs_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtqtdecx_item = New System.Windows.Forms.TextBox()
        Me.txtvlrdesc_item = New System.Windows.Forms.TextBox()
        Me.lbldesc = New System.Windows.Forms.Label()
        Me.txtvlrtotal_item = New System.Windows.Forms.TextBox()
        Me.txtqtde_item = New System.Windows.Forms.TextBox()
        Me.Label169 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.txtvlrunit_item = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtqtde_xml = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbocest_item = New MTGCComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtncm_xml = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtcest_xml = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtcst_xml = New System.Windows.Forms.TextBox()
        Me.cbocst_item = New MTGCComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtaliqicms_item = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label96 = New System.Windows.Forms.Label()
        Me.txtbaseicms_item = New System.Windows.Forms.TextBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.txtvlricms_item = New System.Windows.Forms.TextBox()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.txtbaseredicms_item = New System.Windows.Forms.TextBox()
        Me.cboncm_item = New MTGCComboBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.txtvlrst_item = New System.Windows.Forms.TextBox()
        Me.cbocstipi_item = New MTGCComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtaliqipi_item = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtvlripi_item = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cbocstpis_item = New MTGCComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtaliqcofins_item = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtvlrcofins_item = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtaliqpis_item = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtvlrpis_item = New System.Windows.Forms.TextBox()
        Me.txtun_xml = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtcodigoprod_item = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtdescprod_item = New System.Windows.Forms.TextBox()
        Me.Panel_item = New System.Windows.Forms.Panel()
        Me.lbliten = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtbcst_item = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtfcpst_item = New System.Windows.Forms.TextBox()
        Me.cbocfop_item = New System.Windows.Forms.ComboBox()
        Me.lblun = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtvlrseguro_item = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtvlrfrete_item = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtvlroutros_item = New System.Windows.Forms.TextBox()
        Me.bntexcluir_item = New System.Windows.Forms.Button()
        Me.bntalterar_item = New System.Windows.Forms.Button()
        Me.bntok = New System.Windows.Forms.Button()
        Me.Pic_cfop = New System.Windows.Forms.PictureBox()
        Me.lblchave = New System.Windows.Forms.Label()
        Me.bntexcluir = New System.Windows.Forms.Button()
        Me.bntpesquisa = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.mskchavecte = New System.Windows.Forms.MaskedTextBox()
        Me.lblchave_cte = New System.Windows.Forms.Label()
        Me.txtfrete_vlr = New System.Windows.Forms.TextBox()
        Me.lblfrete_vlr = New System.Windows.Forms.Label()
        Me.lblicms_frete = New System.Windows.Forms.Label()
        Me.cboaliqfrete = New System.Windows.Forms.ComboBox()
        Me.lblpisfrete = New System.Windows.Forms.Label()
        Me.CBOCFOP_CORPO = New System.Windows.Forms.ComboBox()
        Me.LBLCFOP = New System.Windows.Forms.Label()
        Me.cbocstpisfrete = New System.Windows.Forms.ComboBox()
        Me.txtaliqpis_frete = New System.Windows.Forms.TextBox()
        Me.lblaliqpis_frete = New System.Windows.Forms.Label()
        Me.txtaliqcofins_frete = New System.Windows.Forms.TextBox()
        Me.lblaliqcofins_frete = New System.Windows.Forms.Label()
        Me.Panel_ini.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_totais.SuspendLayout()
        Me.Panel30.SuspendLayout()
        CType(Me.dgvitens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_item.SuspendLayout()
        CType(Me.Pic_cfop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel_ini
        '
        Me.Panel_ini.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel_ini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_ini.Controls.Add(Me.lbluf)
        Me.Panel_ini.Controls.Add(Me.txtnumeronf)
        Me.Panel_ini.Controls.Add(Me.PictureBox5)
        Me.Panel_ini.Controls.Add(Me.txtnome_emi)
        Me.Panel_ini.Controls.Add(Me.Label172)
        Me.Panel_ini.Controls.Add(Me.mskcnpj_emi)
        Me.Panel_ini.Controls.Add(Me.Label171)
        Me.Panel_ini.Controls.Add(Me.data_entrada)
        Me.Panel_ini.Controls.Add(Me.Label1)
        Me.Panel_ini.Controls.Add(Me.cbomodelo)
        Me.Panel_ini.Controls.Add(Me.Label37)
        Me.Panel_ini.Controls.Add(Me.data_emissao)
        Me.Panel_ini.Controls.Add(Me.Label34)
        Me.Panel_ini.Controls.Add(Me.Label35)
        Me.Panel_ini.Controls.Add(Me.txtserienfe)
        Me.Panel_ini.Controls.Add(Me.Label36)
        Me.Panel_ini.Enabled = False
        Me.Panel_ini.Location = New System.Drawing.Point(2, 5)
        Me.Panel_ini.Name = "Panel_ini"
        Me.Panel_ini.Size = New System.Drawing.Size(858, 52)
        Me.Panel_ini.TabIndex = 0
        '
        'lbluf
        '
        Me.lbluf.AutoSize = True
        Me.lbluf.ForeColor = System.Drawing.Color.Blue
        Me.lbluf.Location = New System.Drawing.Point(799, 27)
        Me.lbluf.Name = "lbluf"
        Me.lbluf.Size = New System.Drawing.Size(21, 13)
        Me.lbluf.TabIndex = 166
        Me.lbluf.Text = "UF"
        '
        'txtnumeronf
        '
        Me.txtnumeronf.BackColor = System.Drawing.Color.White
        Me.txtnumeronf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnumeronf.Location = New System.Drawing.Point(6, 24)
        Me.txtnumeronf.MaxLength = 9
        Me.txtnumeronf.Name = "txtnumeronf"
        Me.txtnumeronf.Size = New System.Drawing.Size(61, 20)
        Me.txtnumeronf.TabIndex = 0
        Me.txtnumeronf.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(824, 24)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(26, 22)
        Me.PictureBox5.TabIndex = 91
        Me.PictureBox5.TabStop = False
        '
        'txtnome_emi
        '
        Me.txtnome_emi.BackColor = System.Drawing.Color.White
        Me.txtnome_emi.Location = New System.Drawing.Point(511, 25)
        Me.txtnome_emi.Name = "txtnome_emi"
        Me.txtnome_emi.ReadOnly = True
        Me.txtnome_emi.Size = New System.Drawing.Size(287, 20)
        Me.txtnome_emi.TabIndex = 88
        Me.txtnome_emi.TabStop = False
        '
        'Label172
        '
        Me.Label172.AutoSize = True
        Me.Label172.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label172.Location = New System.Drawing.Point(508, 9)
        Me.Label172.Name = "Label172"
        Me.Label172.Size = New System.Drawing.Size(133, 16)
        Me.Label172.TabIndex = 90
        Me.Label172.Text = "Nome Fornecedor"
        '
        'mskcnpj_emi
        '
        Me.mskcnpj_emi.Location = New System.Drawing.Point(388, 25)
        Me.mskcnpj_emi.Name = "mskcnpj_emi"
        Me.mskcnpj_emi.Size = New System.Drawing.Size(117, 20)
        Me.mskcnpj_emi.TabIndex = 5
        Me.mskcnpj_emi.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label171
        '
        Me.Label171.AutoSize = True
        Me.Label171.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label171.Location = New System.Drawing.Point(388, 11)
        Me.Label171.Name = "Label171"
        Me.Label171.Size = New System.Drawing.Size(67, 13)
        Me.Label171.TabIndex = 89
        Me.Label171.Text = "CNPJ/CPF"
        '
        'data_entrada
        '
        Me.data_entrada.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.data_entrada.Location = New System.Drawing.Point(287, 25)
        Me.data_entrada.MinDate = New Date(2011, 1, 1, 0, 0, 0, 0)
        Me.data_entrada.Name = "data_entrada"
        Me.data_entrada.Size = New System.Drawing.Size(95, 20)
        Me.data_entrada.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(284, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Data Entrada"
        '
        'cbomodelo
        '
        Me.cbomodelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbomodelo.FormattingEnabled = True
        Me.cbomodelo.Items.AddRange(New Object() {"01", "06", "07", "08", "21", "22", "55", "57"})
        Me.cbomodelo.Location = New System.Drawing.Point(126, 24)
        Me.cbomodelo.Name = "cbomodelo"
        Me.cbomodelo.Size = New System.Drawing.Size(51, 21)
        Me.cbomodelo.TabIndex = 2
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(3, 11)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(44, 13)
        Me.Label37.TabIndex = 14
        Me.Label37.Text = "Número"
        '
        'data_emissao
        '
        Me.data_emissao.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.data_emissao.Location = New System.Drawing.Point(181, 25)
        Me.data_emissao.MinDate = New Date(2011, 1, 1, 0, 0, 0, 0)
        Me.data_emissao.Name = "data_emissao"
        Me.data_emissao.Size = New System.Drawing.Size(102, 20)
        Me.data_emissao.TabIndex = 3
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(181, 11)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(72, 13)
        Me.Label34.TabIndex = 17
        Me.Label34.Text = "Data Emissão"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(124, 11)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(45, 13)
        Me.Label35.TabIndex = 16
        Me.Label35.Text = "Modelo "
        '
        'txtserienfe
        '
        Me.txtserienfe.BackColor = System.Drawing.Color.White
        Me.txtserienfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtserienfe.Location = New System.Drawing.Point(71, 24)
        Me.txtserienfe.MaxLength = 30
        Me.txtserienfe.Name = "txtserienfe"
        Me.txtserienfe.Size = New System.Drawing.Size(51, 20)
        Me.txtserienfe.TabIndex = 1
        Me.txtserienfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(68, 11)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(31, 13)
        Me.Label36.TabIndex = 15
        Me.Label36.Text = "Série"
        '
        'Panel_totais
        '
        Me.Panel_totais.BackColor = System.Drawing.Color.LightGray
        Me.Panel_totais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_totais.Controls.Add(Me.txtsttotalxml)
        Me.Panel_totais.Controls.Add(Me.txtoutrostotalxml)
        Me.Panel_totais.Controls.Add(Me.txtfretetotalxml)
        Me.Panel_totais.Controls.Add(Me.txtipitotalxml)
        Me.Panel_totais.Controls.Add(Me.txtvlrxml)
        Me.Panel_totais.Controls.Add(Me.Label92)
        Me.Panel_totais.Controls.Add(Me.txtvlrfemst)
        Me.Panel_totais.Controls.Add(Me.txtvlrtotalbaseicms_nfe)
        Me.Panel_totais.Controls.Add(Me.txtvlrtotalicms_nfe)
        Me.Panel_totais.Controls.Add(Me.Label53)
        Me.Panel_totais.Controls.Add(Me.Label52)
        Me.Panel_totais.Controls.Add(Me.txtvlrtotalbasest_nfe)
        Me.Panel_totais.Controls.Add(Me.Label50)
        Me.Panel_totais.Controls.Add(Me.Label51)
        Me.Panel_totais.Controls.Add(Me.txtvrltotalipi_nfe)
        Me.Panel_totais.Controls.Add(Me.txtvlrtotalst_nfe)
        Me.Panel_totais.Controls.Add(Me.txtvlrtotalcofins_nfe)
        Me.Panel_totais.Controls.Add(Me.Label54)
        Me.Panel_totais.Controls.Add(Me.Label38)
        Me.Panel_totais.Controls.Add(Me.Label55)
        Me.Panel_totais.Controls.Add(Me.Label57)
        Me.Panel_totais.Controls.Add(Me.txtvlrtotalfrete_nfe)
        Me.Panel_totais.Controls.Add(Me.txtvlrtotaloutras_nfe)
        Me.Panel_totais.Controls.Add(Me.txtvlrtotaldesc_nfe)
        Me.Panel_totais.Controls.Add(Me.Label48)
        Me.Panel_totais.Controls.Add(Me.txtvlrtotalpis_nfe)
        Me.Panel_totais.Controls.Add(Me.Label49)
        Me.Panel_totais.Controls.Add(Me.txtvlrtotalseg_nfe)
        Me.Panel_totais.Controls.Add(Me.Label39)
        Me.Panel_totais.Controls.Add(Me.Panel30)
        Me.Panel_totais.Location = New System.Drawing.Point(2, 479)
        Me.Panel_totais.Name = "Panel_totais"
        Me.Panel_totais.Size = New System.Drawing.Size(858, 102)
        Me.Panel_totais.TabIndex = 63
        '
        'txtsttotalxml
        '
        Me.txtsttotalxml.Location = New System.Drawing.Point(393, 3)
        Me.txtsttotalxml.Name = "txtsttotalxml"
        Me.txtsttotalxml.Size = New System.Drawing.Size(49, 20)
        Me.txtsttotalxml.TabIndex = 100
        Me.txtsttotalxml.Visible = False
        '
        'txtoutrostotalxml
        '
        Me.txtoutrostotalxml.Location = New System.Drawing.Point(443, 71)
        Me.txtoutrostotalxml.Name = "txtoutrostotalxml"
        Me.txtoutrostotalxml.Size = New System.Drawing.Size(49, 20)
        Me.txtoutrostotalxml.TabIndex = 99
        Me.txtoutrostotalxml.Visible = False
        '
        'txtfretetotalxml
        '
        Me.txtfretetotalxml.Location = New System.Drawing.Point(443, 48)
        Me.txtfretetotalxml.Name = "txtfretetotalxml"
        Me.txtfretetotalxml.Size = New System.Drawing.Size(49, 20)
        Me.txtfretetotalxml.TabIndex = 98
        Me.txtfretetotalxml.Visible = False
        '
        'txtipitotalxml
        '
        Me.txtipitotalxml.Location = New System.Drawing.Point(443, 26)
        Me.txtipitotalxml.Name = "txtipitotalxml"
        Me.txtipitotalxml.Size = New System.Drawing.Size(49, 20)
        Me.txtipitotalxml.TabIndex = 97
        Me.txtipitotalxml.Visible = False
        '
        'txtvlrxml
        '
        Me.txtvlrxml.Location = New System.Drawing.Point(443, 3)
        Me.txtvlrxml.Name = "txtvlrxml"
        Me.txtvlrxml.Size = New System.Drawing.Size(49, 20)
        Me.txtvlrxml.TabIndex = 96
        Me.txtvlrxml.Visible = False
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.ForeColor = System.Drawing.Color.Black
        Me.Label92.Location = New System.Drawing.Point(340, 57)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(77, 13)
        Me.Label92.TabIndex = 95
        Me.Label92.Text = "Valor (FCP ST)"
        '
        'txtvlrfemst
        '
        Me.txtvlrfemst.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtvlrfemst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvlrfemst.Location = New System.Drawing.Point(343, 71)
        Me.txtvlrfemst.Name = "txtvlrfemst"
        Me.txtvlrfemst.ReadOnly = True
        Me.txtvlrfemst.Size = New System.Drawing.Size(77, 20)
        Me.txtvlrfemst.TabIndex = 94
        Me.txtvlrfemst.TabStop = False
        Me.txtvlrfemst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtvlrtotalbaseicms_nfe
        '
        Me.txtvlrtotalbaseicms_nfe.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtvlrtotalbaseicms_nfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvlrtotalbaseicms_nfe.Location = New System.Drawing.Point(6, 29)
        Me.txtvlrtotalbaseicms_nfe.Name = "txtvlrtotalbaseicms_nfe"
        Me.txtvlrtotalbaseicms_nfe.ReadOnly = True
        Me.txtvlrtotalbaseicms_nfe.Size = New System.Drawing.Size(74, 20)
        Me.txtvlrtotalbaseicms_nfe.TabIndex = 36
        Me.txtvlrtotalbaseicms_nfe.TabStop = False
        Me.txtvlrtotalbaseicms_nfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtvlrtotalicms_nfe
        '
        Me.txtvlrtotalicms_nfe.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtvlrtotalicms_nfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvlrtotalicms_nfe.Location = New System.Drawing.Point(89, 29)
        Me.txtvlrtotalicms_nfe.Name = "txtvlrtotalicms_nfe"
        Me.txtvlrtotalicms_nfe.ReadOnly = True
        Me.txtvlrtotalicms_nfe.Size = New System.Drawing.Size(77, 20)
        Me.txtvlrtotalicms_nfe.TabIndex = 38
        Me.txtvlrtotalicms_nfe.TabStop = False
        Me.txtvlrtotalicms_nfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.ForeColor = System.Drawing.Color.Black
        Me.Label53.Location = New System.Drawing.Point(3, 15)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(77, 13)
        Me.Label53.TabIndex = 35
        Me.Label53.Text = "Valor BC ICMS"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.ForeColor = System.Drawing.Color.Black
        Me.Label52.Location = New System.Drawing.Point(86, 15)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(60, 13)
        Me.Label52.TabIndex = 37
        Me.Label52.Text = "Valor ICMS"
        '
        'txtvlrtotalbasest_nfe
        '
        Me.txtvlrtotalbasest_nfe.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtvlrtotalbasest_nfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvlrtotalbasest_nfe.Location = New System.Drawing.Point(6, 71)
        Me.txtvlrtotalbasest_nfe.Name = "txtvlrtotalbasest_nfe"
        Me.txtvlrtotalbasest_nfe.ReadOnly = True
        Me.txtvlrtotalbasest_nfe.Size = New System.Drawing.Size(77, 20)
        Me.txtvlrtotalbasest_nfe.TabIndex = 40
        Me.txtvlrtotalbasest_nfe.TabStop = False
        Me.txtvlrtotalbasest_nfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(86, 58)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(79, 13)
        Me.Label50.TabIndex = 41
        Me.Label50.Text = "Valor ICMS/ST"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.ForeColor = System.Drawing.Color.Black
        Me.Label51.Location = New System.Drawing.Point(5, 57)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(75, 13)
        Me.Label51.TabIndex = 39
        Me.Label51.Text = "Valor Base ST"
        '
        'txtvrltotalipi_nfe
        '
        Me.txtvrltotalipi_nfe.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtvrltotalipi_nfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvrltotalipi_nfe.Location = New System.Drawing.Point(343, 29)
        Me.txtvrltotalipi_nfe.Name = "txtvrltotalipi_nfe"
        Me.txtvrltotalipi_nfe.ReadOnly = True
        Me.txtvrltotalipi_nfe.Size = New System.Drawing.Size(77, 20)
        Me.txtvrltotalipi_nfe.TabIndex = 46
        Me.txtvrltotalipi_nfe.TabStop = False
        Me.txtvrltotalipi_nfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtvlrtotalst_nfe
        '
        Me.txtvlrtotalst_nfe.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtvlrtotalst_nfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvlrtotalst_nfe.Location = New System.Drawing.Point(89, 71)
        Me.txtvlrtotalst_nfe.Name = "txtvlrtotalst_nfe"
        Me.txtvlrtotalst_nfe.ReadOnly = True
        Me.txtvlrtotalst_nfe.Size = New System.Drawing.Size(76, 20)
        Me.txtvlrtotalst_nfe.TabIndex = 42
        Me.txtvlrtotalst_nfe.TabStop = False
        Me.txtvlrtotalst_nfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtvlrtotalcofins_nfe
        '
        Me.txtvlrtotalcofins_nfe.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtvlrtotalcofins_nfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvlrtotalcofins_nfe.Location = New System.Drawing.Point(175, 29)
        Me.txtvlrtotalcofins_nfe.Name = "txtvlrtotalcofins_nfe"
        Me.txtvlrtotalcofins_nfe.ReadOnly = True
        Me.txtvlrtotalcofins_nfe.Size = New System.Drawing.Size(76, 20)
        Me.txtvlrtotalcofins_nfe.TabIndex = 50
        Me.txtvlrtotalcofins_nfe.TabStop = False
        Me.txtvlrtotalcofins_nfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.ForeColor = System.Drawing.Color.Black
        Me.Label54.Location = New System.Drawing.Point(340, 15)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(47, 13)
        Me.Label54.TabIndex = 45
        Me.Label54.Text = "Valor IPI"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(522, 15)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(110, 13)
        Me.Label38.TabIndex = 49
        Me.Label38.Text = "Valor Outra Despesas"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.ForeColor = System.Drawing.Color.Black
        Me.Label55.Location = New System.Drawing.Point(172, 15)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(73, 13)
        Me.Label55.TabIndex = 47
        Me.Label55.Text = "Valor COFINS"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.ForeColor = System.Drawing.Color.Black
        Me.Label57.Location = New System.Drawing.Point(172, 58)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(51, 13)
        Me.Label57.TabIndex = 49
        Me.Label57.Text = "Valor PIS"
        '
        'txtvlrtotalfrete_nfe
        '
        Me.txtvlrtotalfrete_nfe.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtvlrtotalfrete_nfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvlrtotalfrete_nfe.Location = New System.Drawing.Point(642, 72)
        Me.txtvlrtotalfrete_nfe.Name = "txtvlrtotalfrete_nfe"
        Me.txtvlrtotalfrete_nfe.Size = New System.Drawing.Size(76, 20)
        Me.txtvlrtotalfrete_nfe.TabIndex = 57
        Me.txtvlrtotalfrete_nfe.TabStop = False
        Me.txtvlrtotalfrete_nfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtvlrtotaloutras_nfe
        '
        Me.txtvlrtotaloutras_nfe.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtvlrtotaloutras_nfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvlrtotaloutras_nfe.Location = New System.Drawing.Point(525, 29)
        Me.txtvlrtotaloutras_nfe.Name = "txtvlrtotaloutras_nfe"
        Me.txtvlrtotaloutras_nfe.Size = New System.Drawing.Size(105, 20)
        Me.txtvlrtotaloutras_nfe.TabIndex = 50
        Me.txtvlrtotaloutras_nfe.TabStop = False
        Me.txtvlrtotaloutras_nfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtvlrtotaldesc_nfe
        '
        Me.txtvlrtotaldesc_nfe.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtvlrtotaldesc_nfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvlrtotaldesc_nfe.Location = New System.Drawing.Point(641, 29)
        Me.txtvlrtotaldesc_nfe.Name = "txtvlrtotaldesc_nfe"
        Me.txtvlrtotaldesc_nfe.ReadOnly = True
        Me.txtvlrtotaldesc_nfe.Size = New System.Drawing.Size(77, 20)
        Me.txtvlrtotaldesc_nfe.TabIndex = 48
        Me.txtvlrtotaldesc_nfe.TabStop = False
        Me.txtvlrtotaldesc_nfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.ForeColor = System.Drawing.Color.Black
        Me.Label48.Location = New System.Drawing.Point(639, 57)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(58, 13)
        Me.Label48.TabIndex = 56
        Me.Label48.Text = "Valor Frete"
        '
        'txtvlrtotalpis_nfe
        '
        Me.txtvlrtotalpis_nfe.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtvlrtotalpis_nfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvlrtotalpis_nfe.Location = New System.Drawing.Point(175, 72)
        Me.txtvlrtotalpis_nfe.Name = "txtvlrtotalpis_nfe"
        Me.txtvlrtotalpis_nfe.ReadOnly = True
        Me.txtvlrtotalpis_nfe.Size = New System.Drawing.Size(77, 20)
        Me.txtvlrtotalpis_nfe.TabIndex = 48
        Me.txtvlrtotalpis_nfe.TabStop = False
        Me.txtvlrtotalpis_nfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.ForeColor = System.Drawing.Color.Black
        Me.Label49.Location = New System.Drawing.Point(638, 15)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(80, 13)
        Me.Label49.TabIndex = 47
        Me.Label49.Text = "Valor Desconto"
        '
        'txtvlrtotalseg_nfe
        '
        Me.txtvlrtotalseg_nfe.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtvlrtotalseg_nfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvlrtotalseg_nfe.Location = New System.Drawing.Point(525, 72)
        Me.txtvlrtotalseg_nfe.Name = "txtvlrtotalseg_nfe"
        Me.txtvlrtotalseg_nfe.ReadOnly = True
        Me.txtvlrtotalseg_nfe.Size = New System.Drawing.Size(105, 20)
        Me.txtvlrtotalseg_nfe.TabIndex = 58
        Me.txtvlrtotalseg_nfe.TabStop = False
        Me.txtvlrtotalseg_nfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(522, 57)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(71, 13)
        Me.Label39.TabIndex = 59
        Me.Label39.Text = "Valor Seguro "
        '
        'Panel30
        '
        Me.Panel30.BackColor = System.Drawing.Color.White
        Me.Panel30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel30.Controls.Add(Me.Label56)
        Me.Panel30.Controls.Add(Me.Label33)
        Me.Panel30.Controls.Add(Me.txtvlrtotal_nfe)
        Me.Panel30.Controls.Add(Me.txtvlrtotalprod_nfe)
        Me.Panel30.Location = New System.Drawing.Point(724, 3)
        Me.Panel30.Name = "Panel30"
        Me.Panel30.Size = New System.Drawing.Size(123, 94)
        Me.Panel30.TabIndex = 16
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.BackColor = System.Drawing.Color.White
        Me.Label56.ForeColor = System.Drawing.Color.Black
        Me.Label56.Location = New System.Drawing.Point(10, 6)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(103, 13)
        Me.Label56.TabIndex = 29
        Me.Label56.Text = "Valor Total Produtos"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.White
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(14, 46)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(103, 15)
        Me.Label33.TabIndex = 27
        Me.Label33.Text = "Valor Total Nota   "
        '
        'txtvlrtotal_nfe
        '
        Me.txtvlrtotal_nfe.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtvlrtotal_nfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvlrtotal_nfe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvlrtotal_nfe.Location = New System.Drawing.Point(14, 65)
        Me.txtvlrtotal_nfe.Name = "txtvlrtotal_nfe"
        Me.txtvlrtotal_nfe.ReadOnly = True
        Me.txtvlrtotal_nfe.Size = New System.Drawing.Size(97, 22)
        Me.txtvlrtotal_nfe.TabIndex = 28
        Me.txtvlrtotal_nfe.TabStop = False
        Me.txtvlrtotal_nfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtvlrtotalprod_nfe
        '
        Me.txtvlrtotalprod_nfe.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtvlrtotalprod_nfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvlrtotalprod_nfe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvlrtotalprod_nfe.Location = New System.Drawing.Point(13, 21)
        Me.txtvlrtotalprod_nfe.Name = "txtvlrtotalprod_nfe"
        Me.txtvlrtotalprod_nfe.ReadOnly = True
        Me.txtvlrtotalprod_nfe.Size = New System.Drawing.Size(97, 22)
        Me.txtvlrtotalprod_nfe.TabIndex = 30
        Me.txtvlrtotalprod_nfe.TabStop = False
        Me.txtvlrtotalprod_nfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvitens
        '
        Me.dgvitens.AllowUserToAddRows = False
        Me.dgvitens.AllowUserToDeleteRows = False
        Me.dgvitens.AllowUserToOrderColumns = True
        Me.dgvitens.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgvitens.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvitens.BackgroundColor = System.Drawing.Color.Silver
        Me.dgvitens.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgvitens.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvitens.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvitens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvitens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nr, Me.codprod_grid, Me.descprod_grid, Me.un_grid, Me.qtde_grid, Me.vlrunit_grid, Me.vlrdesc_grid, Me.vlrtotal_grid, Me.ncm_grid, Me.cest_grid, Me.cfop_grid, Me.cst_grid, Me.baseicms_grid, Me.Redbcicms_grid, Me.aliqicms_grid, Me.vlricms_grid, Me.vlrst_grid, Me.cstpis_grid, Me.aliqpis_grid, Me.vlrpis_grid, Me.aliqcofins_grid, Me.vlrcofins_grid, Me.cstipi_grid, Me.aliqipi_grid, Me.vlripi_grid, Me.basest_grid, Me.vlrfrete_grid, Me.vlroutros_grid, Me.vlrseguro_grid, Me.vlrfcpst_grid, Me.obs_grid})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvitens.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvitens.EnableHeadersVisualStyles = False
        Me.dgvitens.GridColor = System.Drawing.Color.SlateGray
        Me.dgvitens.Location = New System.Drawing.Point(2, 229)
        Me.dgvitens.MultiSelect = False
        Me.dgvitens.Name = "dgvitens"
        Me.dgvitens.ReadOnly = True
        Me.dgvitens.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvitens.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvitens.RowHeadersVisible = False
        Me.dgvitens.RowHeadersWidth = 24
        Me.dgvitens.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        Me.dgvitens.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvitens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvitens.ShowEditingIcon = False
        Me.dgvitens.Size = New System.Drawing.Size(858, 248)
        Me.dgvitens.TabIndex = 65
        '
        'Nr
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Nr.DefaultCellStyle = DataGridViewCellStyle3
        Me.Nr.HeaderText = "Nr."
        Me.Nr.Name = "Nr"
        Me.Nr.ReadOnly = True
        Me.Nr.Width = 24
        '
        'codprod_grid
        '
        Me.codprod_grid.HeaderText = "Código"
        Me.codprod_grid.Name = "codprod_grid"
        Me.codprod_grid.ReadOnly = True
        Me.codprod_grid.Width = 68
        '
        'descprod_grid
        '
        Me.descprod_grid.HeaderText = "Descrição Do Produto"
        Me.descprod_grid.Name = "descprod_grid"
        Me.descprod_grid.ReadOnly = True
        Me.descprod_grid.Width = 270
        '
        'un_grid
        '
        Me.un_grid.HeaderText = "UN"
        Me.un_grid.Name = "un_grid"
        Me.un_grid.ReadOnly = True
        Me.un_grid.Width = 35
        '
        'qtde_grid
        '
        Me.qtde_grid.HeaderText = "Qtde"
        Me.qtde_grid.Name = "qtde_grid"
        Me.qtde_grid.ReadOnly = True
        Me.qtde_grid.Width = 60
        '
        'vlrunit_grid
        '
        Me.vlrunit_grid.HeaderText = "Valor Unit"
        Me.vlrunit_grid.Name = "vlrunit_grid"
        Me.vlrunit_grid.ReadOnly = True
        Me.vlrunit_grid.Width = 65
        '
        'vlrdesc_grid
        '
        Me.vlrdesc_grid.HeaderText = "Vlr Desc."
        Me.vlrdesc_grid.Name = "vlrdesc_grid"
        Me.vlrdesc_grid.ReadOnly = True
        Me.vlrdesc_grid.Width = 65
        '
        'vlrtotal_grid
        '
        Me.vlrtotal_grid.HeaderText = "Valor Total"
        Me.vlrtotal_grid.Name = "vlrtotal_grid"
        Me.vlrtotal_grid.ReadOnly = True
        Me.vlrtotal_grid.Width = 65
        '
        'ncm_grid
        '
        Me.ncm_grid.HeaderText = "NCM"
        Me.ncm_grid.Name = "ncm_grid"
        Me.ncm_grid.ReadOnly = True
        Me.ncm_grid.Width = 80
        '
        'cest_grid
        '
        Me.cest_grid.HeaderText = "CEST"
        Me.cest_grid.Name = "cest_grid"
        Me.cest_grid.ReadOnly = True
        Me.cest_grid.Width = 80
        '
        'cfop_grid
        '
        Me.cfop_grid.HeaderText = "CFOP"
        Me.cfop_grid.Name = "cfop_grid"
        Me.cfop_grid.ReadOnly = True
        Me.cfop_grid.Width = 45
        '
        'cst_grid
        '
        Me.cst_grid.HeaderText = "CST"
        Me.cst_grid.Name = "cst_grid"
        Me.cst_grid.ReadOnly = True
        Me.cst_grid.Width = 35
        '
        'baseicms_grid
        '
        Me.baseicms_grid.HeaderText = "BC ICMS"
        Me.baseicms_grid.Name = "baseicms_grid"
        Me.baseicms_grid.ReadOnly = True
        Me.baseicms_grid.Width = 65
        '
        'Redbcicms_grid
        '
        Me.Redbcicms_grid.HeaderText = "Red BC ICMS"
        Me.Redbcicms_grid.Name = "Redbcicms_grid"
        Me.Redbcicms_grid.ReadOnly = True
        Me.Redbcicms_grid.Width = 80
        '
        'aliqicms_grid
        '
        Me.aliqicms_grid.HeaderText = "% ICMS"
        Me.aliqicms_grid.Name = "aliqicms_grid"
        Me.aliqicms_grid.ReadOnly = True
        Me.aliqicms_grid.Width = 50
        '
        'vlricms_grid
        '
        Me.vlricms_grid.HeaderText = "Valor ICMS"
        Me.vlricms_grid.Name = "vlricms_grid"
        Me.vlricms_grid.ReadOnly = True
        Me.vlricms_grid.Width = 65
        '
        'vlrst_grid
        '
        Me.vlrst_grid.HeaderText = "Valor ST"
        Me.vlrst_grid.Name = "vlrst_grid"
        Me.vlrst_grid.ReadOnly = True
        Me.vlrst_grid.Width = 65
        '
        'cstpis_grid
        '
        Me.cstpis_grid.HeaderText = "CST Pis/Cofins"
        Me.cstpis_grid.Name = "cstpis_grid"
        Me.cstpis_grid.ReadOnly = True
        '
        'aliqpis_grid
        '
        Me.aliqpis_grid.HeaderText = "Aliq PIS"
        Me.aliqpis_grid.Name = "aliqpis_grid"
        Me.aliqpis_grid.ReadOnly = True
        Me.aliqpis_grid.Width = 50
        '
        'vlrpis_grid
        '
        Me.vlrpis_grid.HeaderText = "Vlr PIS"
        Me.vlrpis_grid.Name = "vlrpis_grid"
        Me.vlrpis_grid.ReadOnly = True
        Me.vlrpis_grid.Width = 60
        '
        'aliqcofins_grid
        '
        Me.aliqcofins_grid.HeaderText = "Aliq Cofins"
        Me.aliqcofins_grid.Name = "aliqcofins_grid"
        Me.aliqcofins_grid.ReadOnly = True
        Me.aliqcofins_grid.Width = 70
        '
        'vlrcofins_grid
        '
        Me.vlrcofins_grid.HeaderText = "Vlr Cofins"
        Me.vlrcofins_grid.Name = "vlrcofins_grid"
        Me.vlrcofins_grid.ReadOnly = True
        Me.vlrcofins_grid.Width = 60
        '
        'cstipi_grid
        '
        Me.cstipi_grid.HeaderText = "CST IPI"
        Me.cstipi_grid.Name = "cstipi_grid"
        Me.cstipi_grid.ReadOnly = True
        Me.cstipi_grid.Width = 50
        '
        'aliqipi_grid
        '
        Me.aliqipi_grid.DataPropertyName = "(none)"
        Me.aliqipi_grid.HeaderText = "Aliq IPI"
        Me.aliqipi_grid.Name = "aliqipi_grid"
        Me.aliqipi_grid.ReadOnly = True
        '
        'vlripi_grid
        '
        Me.vlripi_grid.HeaderText = "Vlr IPI"
        Me.vlripi_grid.Name = "vlripi_grid"
        Me.vlripi_grid.ReadOnly = True
        Me.vlripi_grid.Width = 60
        '
        'basest_grid
        '
        Me.basest_grid.HeaderText = "Base ST"
        Me.basest_grid.Name = "basest_grid"
        Me.basest_grid.ReadOnly = True
        '
        'vlrfrete_grid
        '
        Me.vlrfrete_grid.HeaderText = "Valor Frete"
        Me.vlrfrete_grid.Name = "vlrfrete_grid"
        Me.vlrfrete_grid.ReadOnly = True
        '
        'vlroutros_grid
        '
        Me.vlroutros_grid.HeaderText = "Valor Outros"
        Me.vlroutros_grid.Name = "vlroutros_grid"
        Me.vlroutros_grid.ReadOnly = True
        '
        'vlrseguro_grid
        '
        Me.vlrseguro_grid.HeaderText = "Valor Seguro"
        Me.vlrseguro_grid.Name = "vlrseguro_grid"
        Me.vlrseguro_grid.ReadOnly = True
        '
        'vlrfcpst_grid
        '
        Me.vlrfcpst_grid.HeaderText = "valor FCPST"
        Me.vlrfcpst_grid.Name = "vlrfcpst_grid"
        Me.vlrfcpst_grid.ReadOnly = True
        Me.vlrfcpst_grid.Width = 80
        '
        'obs_grid
        '
        Me.obs_grid.HeaderText = "Obs Adic."
        Me.obs_grid.Name = "obs_grid"
        Me.obs_grid.ReadOnly = True
        '
        'txtqtdecx_item
        '
        Me.txtqtdecx_item.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtqtdecx_item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtqtdecx_item.Location = New System.Drawing.Point(385, 16)
        Me.txtqtdecx_item.Name = "txtqtdecx_item"
        Me.txtqtdecx_item.Size = New System.Drawing.Size(48, 20)
        Me.txtqtdecx_item.TabIndex = 2
        Me.txtqtdecx_item.TabStop = False
        Me.txtqtdecx_item.Text = "1"
        Me.txtqtdecx_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtvlrdesc_item
        '
        Me.txtvlrdesc_item.BackColor = System.Drawing.Color.White
        Me.txtvlrdesc_item.Location = New System.Drawing.Point(558, 16)
        Me.txtvlrdesc_item.Name = "txtvlrdesc_item"
        Me.txtvlrdesc_item.Size = New System.Drawing.Size(58, 20)
        Me.txtvlrdesc_item.TabIndex = 5
        Me.txtvlrdesc_item.Text = "0,00"
        Me.txtvlrdesc_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbldesc
        '
        Me.lbldesc.AutoSize = True
        Me.lbldesc.Location = New System.Drawing.Point(555, 2)
        Me.lbldesc.Name = "lbldesc"
        Me.lbldesc.Size = New System.Drawing.Size(62, 13)
        Me.lbldesc.TabIndex = 100
        Me.lbldesc.Text = "Valor Desc."
        '
        'txtvlrtotal_item
        '
        Me.txtvlrtotal_item.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtvlrtotal_item.Location = New System.Drawing.Point(619, 16)
        Me.txtvlrtotal_item.Name = "txtvlrtotal_item"
        Me.txtvlrtotal_item.ReadOnly = True
        Me.txtvlrtotal_item.Size = New System.Drawing.Size(64, 20)
        Me.txtvlrtotal_item.TabIndex = 6
        Me.txtvlrtotal_item.TabStop = False
        Me.txtvlrtotal_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtqtde_item
        '
        Me.txtqtde_item.BackColor = System.Drawing.Color.White
        Me.txtqtde_item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtqtde_item.Location = New System.Drawing.Point(434, 16)
        Me.txtqtde_item.Name = "txtqtde_item"
        Me.txtqtde_item.Size = New System.Drawing.Size(58, 20)
        Me.txtqtde_item.TabIndex = 3
        Me.txtqtde_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label169
        '
        Me.Label169.AutoSize = True
        Me.Label169.Location = New System.Drawing.Point(616, 2)
        Me.Label169.Name = "Label169"
        Me.Label169.Size = New System.Drawing.Size(71, 13)
        Me.Label169.TabIndex = 103
        Me.Label169.Text = "Total C/Desc"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(431, 2)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(37, 13)
        Me.Label60.TabIndex = 99
        Me.Label60.Text = "QTDE"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label59.ForeColor = System.Drawing.Color.Black
        Me.Label59.Location = New System.Drawing.Point(493, 2)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(56, 13)
        Me.Label59.TabIndex = 98
        Me.Label59.Text = "Valor Unit."
        '
        'txtvlrunit_item
        '
        Me.txtvlrunit_item.Location = New System.Drawing.Point(496, 16)
        Me.txtvlrunit_item.Name = "txtvlrunit_item"
        Me.txtvlrunit_item.Size = New System.Drawing.Size(58, 20)
        Me.txtvlrunit_item.TabIndex = 4
        Me.txtvlrunit_item.TabStop = False
        Me.txtvlrunit_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(383, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Qtde/UN"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(0, 39)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(38, 13)
        Me.Label62.TabIndex = 106
        Me.Label62.Text = "CFOP:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(791, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "Qtde/XML"
        '
        'txtqtde_xml
        '
        Me.txtqtde_xml.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtqtde_xml.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtqtde_xml.Location = New System.Drawing.Point(794, 55)
        Me.txtqtde_xml.Name = "txtqtde_xml"
        Me.txtqtde_xml.ReadOnly = True
        Me.txtqtde_xml.Size = New System.Drawing.Size(53, 20)
        Me.txtqtde_xml.TabIndex = 109
        Me.txtqtde_xml.TabStop = False
        Me.txtqtde_xml.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(687, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "NCM"
        '
        'cbocest_item
        '
        Me.cbocest_item.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cbocest_item.ArrowColor = System.Drawing.Color.Black
        Me.cbocest_item.BindedControl = CType(resources.GetObject("cbocest_item.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cbocest_item.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cbocest_item.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cbocest_item.ColumnNum = 2
        Me.cbocest_item.ColumnWidth = "50;360"
        Me.cbocest_item.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cbocest_item.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cbocest_item.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cbocest_item.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cbocest_item.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cbocest_item.DisplayMember = "Text"
        Me.cbocest_item.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbocest_item.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cbocest_item.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cbocest_item.DropDownForeColor = System.Drawing.Color.Black
        Me.cbocest_item.DropDownHeight = 110
        Me.cbocest_item.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cbocest_item.DropDownWidth = 430
        Me.cbocest_item.GridLineColor = System.Drawing.Color.Blue
        Me.cbocest_item.GridLineHorizontal = True
        Me.cbocest_item.GridLineVertical = True
        Me.cbocest_item.HighlightBorderColor = System.Drawing.Color.Blue
        Me.cbocest_item.HighlightBorderOnMouseEvents = True
        Me.cbocest_item.IntegralHeight = False
        Me.cbocest_item.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cbocest_item.Location = New System.Drawing.Point(771, 15)
        Me.cbocest_item.ManagingFastMouseMoving = True
        Me.cbocest_item.ManagingFastMouseMovingInterval = 30
        Me.cbocest_item.Name = "cbocest_item"
        Me.cbocest_item.NormalBorderColor = System.Drawing.Color.Black
        Me.cbocest_item.SelectedItem = Nothing
        Me.cbocest_item.SelectedValue = Nothing
        Me.cbocest_item.Size = New System.Drawing.Size(76, 21)
        Me.cbocest_item.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(768, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 113
        Me.Label5.Text = "CEST"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(591, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 114
        Me.Label6.Text = "NCM/XML"
        '
        'txtncm_xml
        '
        Me.txtncm_xml.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtncm_xml.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtncm_xml.Location = New System.Drawing.Point(592, 55)
        Me.txtncm_xml.Name = "txtncm_xml"
        Me.txtncm_xml.ReadOnly = True
        Me.txtncm_xml.Size = New System.Drawing.Size(65, 20)
        Me.txtncm_xml.TabIndex = 115
        Me.txtncm_xml.TabStop = False
        Me.txtncm_xml.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(662, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 116
        Me.Label7.Text = "CEST/XML"
        '
        'txtcest_xml
        '
        Me.txtcest_xml.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtcest_xml.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcest_xml.Location = New System.Drawing.Point(662, 55)
        Me.txtcest_xml.Name = "txtcest_xml"
        Me.txtcest_xml.ReadOnly = True
        Me.txtcest_xml.Size = New System.Drawing.Size(63, 20)
        Me.txtcest_xml.TabIndex = 117
        Me.txtcest_xml.TabStop = False
        Me.txtcest_xml.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(525, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 118
        Me.Label8.Text = "CST/XML"
        '
        'txtcst_xml
        '
        Me.txtcst_xml.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtcst_xml.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcst_xml.Location = New System.Drawing.Point(528, 55)
        Me.txtcst_xml.Name = "txtcst_xml"
        Me.txtcst_xml.ReadOnly = True
        Me.txtcst_xml.Size = New System.Drawing.Size(58, 20)
        Me.txtcst_xml.TabIndex = 119
        Me.txtcst_xml.TabStop = False
        Me.txtcst_xml.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbocst_item
        '
        Me.cbocst_item.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cbocst_item.ArrowColor = System.Drawing.Color.Black
        Me.cbocst_item.BindedControl = CType(resources.GetObject("cbocst_item.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cbocst_item.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cbocst_item.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cbocst_item.ColumnNum = 2
        Me.cbocst_item.ColumnWidth = "40;360"
        Me.cbocst_item.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cbocst_item.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cbocst_item.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cbocst_item.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cbocst_item.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cbocst_item.DisplayMember = "Text"
        Me.cbocst_item.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbocst_item.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cbocst_item.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cbocst_item.DropDownForeColor = System.Drawing.Color.Black
        Me.cbocst_item.DropDownHeight = 110
        Me.cbocst_item.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cbocst_item.DropDownWidth = 420
        Me.cbocst_item.GridLineColor = System.Drawing.Color.Blue
        Me.cbocst_item.GridLineHorizontal = True
        Me.cbocst_item.GridLineVertical = True
        Me.cbocst_item.HighlightBorderColor = System.Drawing.Color.Blue
        Me.cbocst_item.HighlightBorderOnMouseEvents = True
        Me.cbocst_item.IntegralHeight = False
        Me.cbocst_item.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cbocst_item.Location = New System.Drawing.Point(3, 94)
        Me.cbocst_item.ManagingFastMouseMoving = True
        Me.cbocst_item.ManagingFastMouseMovingInterval = 30
        Me.cbocst_item.Name = "cbocst_item"
        Me.cbocst_item.NormalBorderColor = System.Drawing.Color.Black
        Me.cbocst_item.SelectedItem = Nothing
        Me.cbocst_item.SelectedValue = Nothing
        Me.cbocst_item.Size = New System.Drawing.Size(55, 21)
        Me.cbocst_item.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(0, 79)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 121
        Me.Label9.Text = "CST"
        '
        'txtaliqicms_item
        '
        Me.txtaliqicms_item.BackColor = System.Drawing.Color.White
        Me.txtaliqicms_item.Location = New System.Drawing.Point(64, 95)
        Me.txtaliqicms_item.Name = "txtaliqicms_item"
        Me.txtaliqicms_item.Size = New System.Drawing.Size(53, 20)
        Me.txtaliqicms_item.TabIndex = 11
        Me.txtaliqicms_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(64, 80)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 123
        Me.Label10.Text = "Aliq.ICMS"
        '
        'Label96
        '
        Me.Label96.AutoSize = True
        Me.Label96.Location = New System.Drawing.Point(121, 80)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(53, 13)
        Me.Label96.TabIndex = 127
        Me.Label96.Text = "BC ICMS:"
        '
        'txtbaseicms_item
        '
        Me.txtbaseicms_item.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtbaseicms_item.Location = New System.Drawing.Point(123, 95)
        Me.txtbaseicms_item.Name = "txtbaseicms_item"
        Me.txtbaseicms_item.ReadOnly = True
        Me.txtbaseicms_item.Size = New System.Drawing.Size(60, 20)
        Me.txtbaseicms_item.TabIndex = 12
        Me.txtbaseicms_item.TabStop = False
        Me.txtbaseicms_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(268, 79)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(63, 13)
        Me.Label67.TabIndex = 126
        Me.Label67.Text = "Valor ICMS:"
        '
        'txtvlricms_item
        '
        Me.txtvlricms_item.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtvlricms_item.Location = New System.Drawing.Point(268, 96)
        Me.txtvlricms_item.Name = "txtvlricms_item"
        Me.txtvlricms_item.ReadOnly = True
        Me.txtvlricms_item.Size = New System.Drawing.Size(60, 20)
        Me.txtvlricms_item.TabIndex = 14
        Me.txtvlricms_item.TabStop = False
        Me.txtvlricms_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.Location = New System.Drawing.Point(186, 80)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(76, 13)
        Me.Label99.TabIndex = 129
        Me.Label99.Text = "Red. BC ICMS"
        '
        'txtbaseredicms_item
        '
        Me.txtbaseredicms_item.Location = New System.Drawing.Point(189, 96)
        Me.txtbaseredicms_item.Name = "txtbaseredicms_item"
        Me.txtbaseredicms_item.Size = New System.Drawing.Size(73, 20)
        Me.txtbaseredicms_item.TabIndex = 13
        Me.txtbaseredicms_item.TabStop = False
        Me.txtbaseredicms_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboncm_item
        '
        Me.cboncm_item.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboncm_item.ArrowColor = System.Drawing.Color.Black
        Me.cboncm_item.BindedControl = CType(resources.GetObject("cboncm_item.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cboncm_item.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cboncm_item.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboncm_item.ColumnNum = 2
        Me.cboncm_item.ColumnWidth = "60;360"
        Me.cboncm_item.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboncm_item.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboncm_item.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboncm_item.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboncm_item.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboncm_item.DisplayMember = "Text"
        Me.cboncm_item.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboncm_item.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cboncm_item.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboncm_item.DropDownForeColor = System.Drawing.Color.Black
        Me.cboncm_item.DropDownHeight = 110
        Me.cboncm_item.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboncm_item.DropDownWidth = 450
        Me.cboncm_item.GridLineColor = System.Drawing.Color.Blue
        Me.cboncm_item.GridLineHorizontal = True
        Me.cboncm_item.GridLineVertical = True
        Me.cboncm_item.HighlightBorderColor = System.Drawing.Color.Blue
        Me.cboncm_item.HighlightBorderOnMouseEvents = True
        Me.cboncm_item.IntegralHeight = False
        Me.cboncm_item.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboncm_item.Location = New System.Drawing.Point(689, 15)
        Me.cboncm_item.ManagingFastMouseMoving = True
        Me.cboncm_item.ManagingFastMouseMovingInterval = 30
        Me.cboncm_item.Name = "cboncm_item"
        Me.cboncm_item.NormalBorderColor = System.Drawing.Color.Black
        Me.cboncm_item.SelectedItem = Nothing
        Me.cboncm_item.SelectedValue = Nothing
        Me.cboncm_item.Size = New System.Drawing.Size(76, 21)
        Me.cboncm_item.TabIndex = 7
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(357, 80)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(38, 13)
        Me.Label68.TabIndex = 131
        Me.Label68.Text = "BC ST"
        '
        'txtvlrst_item
        '
        Me.txtvlrst_item.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtvlrst_item.Location = New System.Drawing.Point(431, 96)
        Me.txtvlrst_item.Name = "txtvlrst_item"
        Me.txtvlrst_item.ReadOnly = True
        Me.txtvlrst_item.Size = New System.Drawing.Size(66, 20)
        Me.txtvlrst_item.TabIndex = 16
        Me.txtvlrst_item.TabStop = False
        Me.txtvlrst_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbocstipi_item
        '
        Me.cbocstipi_item.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cbocstipi_item.ArrowColor = System.Drawing.Color.Black
        Me.cbocstipi_item.BindedControl = CType(resources.GetObject("cbocstipi_item.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cbocstipi_item.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cbocstipi_item.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cbocstipi_item.ColumnNum = 2
        Me.cbocstipi_item.ColumnWidth = "40;360"
        Me.cbocstipi_item.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cbocstipi_item.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cbocstipi_item.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cbocstipi_item.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cbocstipi_item.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cbocstipi_item.DisplayMember = "Text"
        Me.cbocstipi_item.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbocstipi_item.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cbocstipi_item.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cbocstipi_item.DropDownForeColor = System.Drawing.Color.Black
        Me.cbocstipi_item.DropDownHeight = 110
        Me.cbocstipi_item.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cbocstipi_item.DropDownWidth = 420
        Me.cbocstipi_item.GridLineColor = System.Drawing.Color.Blue
        Me.cbocstipi_item.GridLineHorizontal = True
        Me.cbocstipi_item.GridLineVertical = True
        Me.cbocstipi_item.HighlightBorderColor = System.Drawing.Color.Blue
        Me.cbocstipi_item.HighlightBorderOnMouseEvents = True
        Me.cbocstipi_item.IntegralHeight = False
        Me.cbocstipi_item.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cbocstipi_item.Location = New System.Drawing.Point(3, 130)
        Me.cbocstipi_item.ManagingFastMouseMoving = True
        Me.cbocstipi_item.ManagingFastMouseMovingInterval = 30
        Me.cbocstipi_item.Name = "cbocstipi_item"
        Me.cbocstipi_item.NormalBorderColor = System.Drawing.Color.Black
        Me.cbocstipi_item.SelectedItem = Nothing
        Me.cbocstipi_item.SelectedValue = Nothing
        Me.cbocstipi_item.Size = New System.Drawing.Size(55, 21)
        Me.cbocstipi_item.TabIndex = 17
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 117)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 134
        Me.Label11.Text = "CST IPI"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(64, 118)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 136
        Me.Label13.Text = "Aliq.IPI"
        '
        'txtaliqipi_item
        '
        Me.txtaliqipi_item.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtaliqipi_item.Location = New System.Drawing.Point(67, 131)
        Me.txtaliqipi_item.Name = "txtaliqipi_item"
        Me.txtaliqipi_item.ReadOnly = True
        Me.txtaliqipi_item.Size = New System.Drawing.Size(46, 20)
        Me.txtaliqipi_item.TabIndex = 18
        Me.txtaliqipi_item.TabStop = False
        Me.txtaliqipi_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(118, 118)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 13)
        Me.Label12.TabIndex = 137
        Me.Label12.Text = "Valor IPI"
        '
        'txtvlripi_item
        '
        Me.txtvlripi_item.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtvlripi_item.Location = New System.Drawing.Point(119, 131)
        Me.txtvlripi_item.Name = "txtvlripi_item"
        Me.txtvlripi_item.ReadOnly = True
        Me.txtvlripi_item.Size = New System.Drawing.Size(55, 20)
        Me.txtvlripi_item.TabIndex = 19
        Me.txtvlripi_item.TabStop = False
        Me.txtvlripi_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(525, 80)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 13)
        Me.Label14.TabIndex = 139
        Me.Label14.Text = "CST Pis/Cofins"
        '
        'cbocstpis_item
        '
        Me.cbocstpis_item.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cbocstpis_item.ArrowColor = System.Drawing.Color.Black
        Me.cbocstpis_item.BindedControl = CType(resources.GetObject("cbocstpis_item.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cbocstpis_item.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cbocstpis_item.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cbocstpis_item.ColumnNum = 2
        Me.cbocstpis_item.ColumnWidth = "40;360"
        Me.cbocstpis_item.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cbocstpis_item.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cbocstpis_item.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cbocstpis_item.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cbocstpis_item.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cbocstpis_item.DisplayMember = "Text"
        Me.cbocstpis_item.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbocstpis_item.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cbocstpis_item.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cbocstpis_item.DropDownForeColor = System.Drawing.Color.Black
        Me.cbocstpis_item.DropDownHeight = 110
        Me.cbocstpis_item.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cbocstpis_item.DropDownWidth = 420
        Me.cbocstpis_item.GridLineColor = System.Drawing.Color.Blue
        Me.cbocstpis_item.GridLineHorizontal = True
        Me.cbocstpis_item.GridLineVertical = True
        Me.cbocstpis_item.HighlightBorderColor = System.Drawing.Color.Blue
        Me.cbocstpis_item.HighlightBorderOnMouseEvents = True
        Me.cbocstpis_item.IntegralHeight = False
        Me.cbocstpis_item.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cbocstpis_item.Location = New System.Drawing.Point(528, 96)
        Me.cbocstpis_item.ManagingFastMouseMoving = True
        Me.cbocstpis_item.ManagingFastMouseMovingInterval = 30
        Me.cbocstpis_item.Name = "cbocstpis_item"
        Me.cbocstpis_item.NormalBorderColor = System.Drawing.Color.Black
        Me.cbocstpis_item.SelectedItem = Nothing
        Me.cbocstpis_item.SelectedValue = Nothing
        Me.cbocstpis_item.Size = New System.Drawing.Size(76, 21)
        Me.cbocstpis_item.TabIndex = 19
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(728, 79)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 13)
        Me.Label16.TabIndex = 142
        Me.Label16.Text = "Aliq.Cofins"
        '
        'txtaliqcofins_item
        '
        Me.txtaliqcofins_item.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtaliqcofins_item.Location = New System.Drawing.Point(731, 96)
        Me.txtaliqcofins_item.Name = "txtaliqcofins_item"
        Me.txtaliqcofins_item.ReadOnly = True
        Me.txtaliqcofins_item.Size = New System.Drawing.Size(53, 20)
        Me.txtaliqcofins_item.TabIndex = 22
        Me.txtaliqcofins_item.TabStop = False
        Me.txtaliqcofins_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(783, 79)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 13)
        Me.Label15.TabIndex = 143
        Me.Label15.Text = "Vlr Cofins"
        '
        'txtvlrcofins_item
        '
        Me.txtvlrcofins_item.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtvlrcofins_item.Location = New System.Drawing.Point(786, 96)
        Me.txtvlrcofins_item.Name = "txtvlrcofins_item"
        Me.txtvlrcofins_item.ReadOnly = True
        Me.txtvlrcofins_item.Size = New System.Drawing.Size(61, 20)
        Me.txtvlrcofins_item.TabIndex = 23
        Me.txtvlrcofins_item.TabStop = False
        Me.txtvlrcofins_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(613, 80)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(41, 13)
        Me.Label18.TabIndex = 146
        Me.Label18.Text = "Aliq.Pis"
        '
        'txtaliqpis_item
        '
        Me.txtaliqpis_item.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtaliqpis_item.Location = New System.Drawing.Point(616, 96)
        Me.txtaliqpis_item.Name = "txtaliqpis_item"
        Me.txtaliqpis_item.ReadOnly = True
        Me.txtaliqpis_item.Size = New System.Drawing.Size(53, 20)
        Me.txtaliqpis_item.TabIndex = 20
        Me.txtaliqpis_item.TabStop = False
        Me.txtaliqpis_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(668, 79)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 13)
        Me.Label17.TabIndex = 147
        Me.Label17.Text = "Valor Pis"
        '
        'txtvlrpis_item
        '
        Me.txtvlrpis_item.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtvlrpis_item.Location = New System.Drawing.Point(671, 96)
        Me.txtvlrpis_item.Name = "txtvlrpis_item"
        Me.txtvlrpis_item.ReadOnly = True
        Me.txtvlrpis_item.Size = New System.Drawing.Size(55, 20)
        Me.txtvlrpis_item.TabIndex = 24
        Me.txtvlrpis_item.TabStop = False
        Me.txtvlrpis_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtun_xml
        '
        Me.txtun_xml.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtun_xml.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtun_xml.Location = New System.Drawing.Point(739, 55)
        Me.txtun_xml.Name = "txtun_xml"
        Me.txtun_xml.ReadOnly = True
        Me.txtun_xml.Size = New System.Drawing.Size(53, 20)
        Me.txtun_xml.TabIndex = 149
        Me.txtun_xml.TabStop = False
        Me.txtun_xml.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(736, 39)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(50, 13)
        Me.Label19.TabIndex = 150
        Me.Label19.Text = "UN/XML"
        '
        'txtcodigoprod_item
        '
        Me.txtcodigoprod_item.BackColor = System.Drawing.Color.White
        Me.txtcodigoprod_item.Location = New System.Drawing.Point(3, 15)
        Me.txtcodigoprod_item.Name = "txtcodigoprod_item"
        Me.txtcodigoprod_item.Size = New System.Drawing.Size(53, 20)
        Me.txtcodigoprod_item.TabIndex = 1
        Me.txtcodigoprod_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(3, 2)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 13)
        Me.Label20.TabIndex = 155
        Me.Label20.Text = "Codigo"
        '
        'txtdescprod_item
        '
        Me.txtdescprod_item.BackColor = System.Drawing.Color.White
        Me.txtdescprod_item.Location = New System.Drawing.Point(62, 16)
        Me.txtdescprod_item.Name = "txtdescprod_item"
        Me.txtdescprod_item.Size = New System.Drawing.Size(318, 20)
        Me.txtdescprod_item.TabIndex = 156
        '
        'Panel_item
        '
        Me.Panel_item.BackColor = System.Drawing.Color.LightGray
        Me.Panel_item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_item.Controls.Add(Me.lbliten)
        Me.Panel_item.Controls.Add(Me.Label25)
        Me.Panel_item.Controls.Add(Me.txtbcst_item)
        Me.Panel_item.Controls.Add(Me.Label21)
        Me.Panel_item.Controls.Add(Me.txtfcpst_item)
        Me.Panel_item.Controls.Add(Me.cbocfop_item)
        Me.Panel_item.Controls.Add(Me.lblun)
        Me.Panel_item.Controls.Add(Me.LinkLabel1)
        Me.Panel_item.Controls.Add(Me.Label24)
        Me.Panel_item.Controls.Add(Me.txtvlrseguro_item)
        Me.Panel_item.Controls.Add(Me.Label23)
        Me.Panel_item.Controls.Add(Me.txtvlrfrete_item)
        Me.Panel_item.Controls.Add(Me.Label22)
        Me.Panel_item.Controls.Add(Me.txtvlroutros_item)
        Me.Panel_item.Controls.Add(Me.txtdescprod_item)
        Me.Panel_item.Controls.Add(Me.Label20)
        Me.Panel_item.Controls.Add(Me.txtcodigoprod_item)
        Me.Panel_item.Controls.Add(Me.bntexcluir_item)
        Me.Panel_item.Controls.Add(Me.bntalterar_item)
        Me.Panel_item.Controls.Add(Me.bntok)
        Me.Panel_item.Controls.Add(Me.Label19)
        Me.Panel_item.Controls.Add(Me.txtun_xml)
        Me.Panel_item.Controls.Add(Me.txtvlrpis_item)
        Me.Panel_item.Controls.Add(Me.Label17)
        Me.Panel_item.Controls.Add(Me.txtaliqpis_item)
        Me.Panel_item.Controls.Add(Me.Label18)
        Me.Panel_item.Controls.Add(Me.txtvlrcofins_item)
        Me.Panel_item.Controls.Add(Me.Label15)
        Me.Panel_item.Controls.Add(Me.txtaliqcofins_item)
        Me.Panel_item.Controls.Add(Me.Label16)
        Me.Panel_item.Controls.Add(Me.cbocstpis_item)
        Me.Panel_item.Controls.Add(Me.Label14)
        Me.Panel_item.Controls.Add(Me.txtvlripi_item)
        Me.Panel_item.Controls.Add(Me.Label12)
        Me.Panel_item.Controls.Add(Me.txtaliqipi_item)
        Me.Panel_item.Controls.Add(Me.Label13)
        Me.Panel_item.Controls.Add(Me.Label11)
        Me.Panel_item.Controls.Add(Me.cbocstipi_item)
        Me.Panel_item.Controls.Add(Me.txtvlrst_item)
        Me.Panel_item.Controls.Add(Me.Label68)
        Me.Panel_item.Controls.Add(Me.cboncm_item)
        Me.Panel_item.Controls.Add(Me.txtbaseredicms_item)
        Me.Panel_item.Controls.Add(Me.Label99)
        Me.Panel_item.Controls.Add(Me.txtvlricms_item)
        Me.Panel_item.Controls.Add(Me.Label67)
        Me.Panel_item.Controls.Add(Me.txtbaseicms_item)
        Me.Panel_item.Controls.Add(Me.Label96)
        Me.Panel_item.Controls.Add(Me.Label10)
        Me.Panel_item.Controls.Add(Me.txtaliqicms_item)
        Me.Panel_item.Controls.Add(Me.Label9)
        Me.Panel_item.Controls.Add(Me.cbocst_item)
        Me.Panel_item.Controls.Add(Me.txtcst_xml)
        Me.Panel_item.Controls.Add(Me.Label8)
        Me.Panel_item.Controls.Add(Me.txtcest_xml)
        Me.Panel_item.Controls.Add(Me.Label7)
        Me.Panel_item.Controls.Add(Me.txtncm_xml)
        Me.Panel_item.Controls.Add(Me.Label6)
        Me.Panel_item.Controls.Add(Me.Label5)
        Me.Panel_item.Controls.Add(Me.cbocest_item)
        Me.Panel_item.Controls.Add(Me.Label4)
        Me.Panel_item.Controls.Add(Me.txtqtde_xml)
        Me.Panel_item.Controls.Add(Me.Label3)
        Me.Panel_item.Controls.Add(Me.Pic_cfop)
        Me.Panel_item.Controls.Add(Me.Label62)
        Me.Panel_item.Controls.Add(Me.Label2)
        Me.Panel_item.Controls.Add(Me.txtvlrunit_item)
        Me.Panel_item.Controls.Add(Me.Label59)
        Me.Panel_item.Controls.Add(Me.Label60)
        Me.Panel_item.Controls.Add(Me.Label169)
        Me.Panel_item.Controls.Add(Me.txtqtde_item)
        Me.Panel_item.Controls.Add(Me.txtvlrtotal_item)
        Me.Panel_item.Controls.Add(Me.lbldesc)
        Me.Panel_item.Controls.Add(Me.txtvlrdesc_item)
        Me.Panel_item.Controls.Add(Me.txtqtdecx_item)
        Me.Panel_item.Enabled = False
        Me.Panel_item.Location = New System.Drawing.Point(2, 63)
        Me.Panel_item.Name = "Panel_item"
        Me.Panel_item.Size = New System.Drawing.Size(858, 159)
        Me.Panel_item.TabIndex = 64
        '
        'lbliten
        '
        Me.lbliten.AutoSize = True
        Me.lbliten.ForeColor = System.Drawing.Color.Blue
        Me.lbliten.Location = New System.Drawing.Point(201, 2)
        Me.lbliten.Name = "lbliten"
        Me.lbliten.Size = New System.Drawing.Size(37, 13)
        Me.lbliten.TabIndex = 170
        Me.lbliten.Text = "Iten: 0"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(428, 80)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(48, 13)
        Me.Label25.TabIndex = 169
        Me.Label25.Text = "Valor ST"
        '
        'txtbcst_item
        '
        Me.txtbcst_item.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtbcst_item.Location = New System.Drawing.Point(360, 96)
        Me.txtbcst_item.Name = "txtbcst_item"
        Me.txtbcst_item.ReadOnly = True
        Me.txtbcst_item.Size = New System.Drawing.Size(65, 20)
        Me.txtbcst_item.TabIndex = 15
        Me.txtbcst_item.TabStop = False
        Me.txtbcst_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(428, 118)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(71, 13)
        Me.Label21.TabIndex = 167
        Me.Label21.Text = "Valor FCP ST"
        '
        'txtfcpst_item
        '
        Me.txtfcpst_item.BackColor = System.Drawing.Color.White
        Me.txtfcpst_item.Location = New System.Drawing.Point(431, 131)
        Me.txtfcpst_item.Name = "txtfcpst_item"
        Me.txtfcpst_item.Size = New System.Drawing.Size(66, 20)
        Me.txtfcpst_item.TabIndex = 23
        Me.txtfcpst_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbocfop_item
        '
        Me.cbocfop_item.BackColor = System.Drawing.Color.White
        Me.cbocfop_item.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbocfop_item.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbocfop_item.FormattingEnabled = True
        Me.cbocfop_item.Location = New System.Drawing.Point(3, 54)
        Me.cbocfop_item.Name = "cbocfop_item"
        Me.cbocfop_item.Size = New System.Drawing.Size(465, 21)
        Me.cbocfop_item.TabIndex = 9
        '
        'lblun
        '
        Me.lblun.AutoSize = True
        Me.lblun.ForeColor = System.Drawing.Color.Blue
        Me.lblun.Location = New System.Drawing.Point(357, 2)
        Me.lblun.Name = "lblun"
        Me.lblun.Size = New System.Drawing.Size(23, 13)
        Me.lblun.TabIndex = 165
        Me.lblun.Text = "UN"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(61, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(95, 13)
        Me.LinkLabel1.TabIndex = 164
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Descrição Produto"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(356, 118)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(68, 13)
        Me.Label24.TabIndex = 163
        Me.Label24.Text = "Valor Seguro"
        '
        'txtvlrseguro_item
        '
        Me.txtvlrseguro_item.BackColor = System.Drawing.Color.White
        Me.txtvlrseguro_item.Location = New System.Drawing.Point(359, 131)
        Me.txtvlrseguro_item.Name = "txtvlrseguro_item"
        Me.txtvlrseguro_item.Size = New System.Drawing.Size(66, 20)
        Me.txtvlrseguro_item.TabIndex = 22
        Me.txtvlrseguro_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(285, 118)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(58, 13)
        Me.Label23.TabIndex = 161
        Me.Label23.Text = "Valor Frete"
        '
        'txtvlrfrete_item
        '
        Me.txtvlrfrete_item.BackColor = System.Drawing.Color.White
        Me.txtvlrfrete_item.Location = New System.Drawing.Point(287, 131)
        Me.txtvlrfrete_item.Name = "txtvlrfrete_item"
        Me.txtvlrfrete_item.Size = New System.Drawing.Size(66, 20)
        Me.txtvlrfrete_item.TabIndex = 21
        Me.txtvlrfrete_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(201, 118)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(82, 13)
        Me.Label22.TabIndex = 159
        Me.Label22.Text = "Vlr outros Desp."
        '
        'txtvlroutros_item
        '
        Me.txtvlroutros_item.BackColor = System.Drawing.Color.White
        Me.txtvlroutros_item.Location = New System.Drawing.Point(204, 131)
        Me.txtvlroutros_item.Name = "txtvlroutros_item"
        Me.txtvlroutros_item.Size = New System.Drawing.Size(77, 20)
        Me.txtvlroutros_item.TabIndex = 20
        Me.txtvlroutros_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bntexcluir_item
        '
        Me.bntexcluir_item.BackColor = System.Drawing.Color.White
        Me.bntexcluir_item.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bntexcluir_item.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bntexcluir_item.ForeColor = System.Drawing.Color.Red
        Me.bntexcluir_item.Image = Global.DFe_aplicativo.My.Resources.Resources.Delete
        Me.bntexcluir_item.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bntexcluir_item.Location = New System.Drawing.Point(763, 123)
        Me.bntexcluir_item.Name = "bntexcluir_item"
        Me.bntexcluir_item.Size = New System.Drawing.Size(84, 28)
        Me.bntexcluir_item.TabIndex = 153
        Me.bntexcluir_item.Text = "      &Excluir Item"
        Me.bntexcluir_item.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bntexcluir_item.UseVisualStyleBackColor = False
        '
        'bntalterar_item
        '
        Me.bntalterar_item.BackColor = System.Drawing.Color.White
        Me.bntalterar_item.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bntalterar_item.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bntalterar_item.ForeColor = System.Drawing.Color.Blue
        Me.bntalterar_item.Image = Global.DFe_aplicativo.My.Resources.Resources.pencil
        Me.bntalterar_item.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bntalterar_item.Location = New System.Drawing.Point(626, 123)
        Me.bntalterar_item.Name = "bntalterar_item"
        Me.bntalterar_item.Size = New System.Drawing.Size(92, 28)
        Me.bntalterar_item.TabIndex = 152
        Me.bntalterar_item.Text = "       &Alterar Item"
        Me.bntalterar_item.UseVisualStyleBackColor = False
        '
        'bntok
        '
        Me.bntok.BackColor = System.Drawing.Color.White
        Me.bntok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bntok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bntok.ForeColor = System.Drawing.Color.DarkGreen
        Me.bntok.Image = Global.DFe_aplicativo.My.Resources.Resources.tick
        Me.bntok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bntok.Location = New System.Drawing.Point(528, 123)
        Me.bntok.Name = "bntok"
        Me.bntok.Size = New System.Drawing.Size(76, 28)
        Me.bntok.TabIndex = 24
        Me.bntok.Text = "     &Ok"
        Me.bntok.UseVisualStyleBackColor = False
        '
        'Pic_cfop
        '
        Me.Pic_cfop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Pic_cfop.Image = CType(resources.GetObject("Pic_cfop.Image"), System.Drawing.Image)
        Me.Pic_cfop.Location = New System.Drawing.Point(471, 53)
        Me.Pic_cfop.Name = "Pic_cfop"
        Me.Pic_cfop.Size = New System.Drawing.Size(26, 22)
        Me.Pic_cfop.TabIndex = 107
        Me.Pic_cfop.TabStop = False
        '
        'lblchave
        '
        Me.lblchave.AutoSize = True
        Me.lblchave.ForeColor = System.Drawing.Color.Blue
        Me.lblchave.Location = New System.Drawing.Point(81, 594)
        Me.lblchave.Name = "lblchave"
        Me.lblchave.Size = New System.Drawing.Size(13, 13)
        Me.lblchave.TabIndex = 172
        Me.lblchave.Text = "0"
        '
        'bntexcluir
        '
        Me.bntexcluir.BackColor = System.Drawing.Color.White
        Me.bntexcluir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bntexcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bntexcluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntexcluir.ForeColor = System.Drawing.Color.Red
        Me.bntexcluir.Image = Global.DFe_aplicativo.My.Resources.Resources.cross
        Me.bntexcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bntexcluir.Location = New System.Drawing.Point(745, 585)
        Me.bntexcluir.Name = "bntexcluir"
        Me.bntexcluir.Size = New System.Drawing.Size(115, 28)
        Me.bntexcluir.TabIndex = 175
        Me.bntexcluir.Text = "   &Excluir"
        Me.bntexcluir.UseVisualStyleBackColor = False
        '
        'bntpesquisa
        '
        Me.bntpesquisa.BackColor = System.Drawing.Color.White
        Me.bntpesquisa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bntpesquisa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bntpesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntpesquisa.ForeColor = System.Drawing.Color.Blue
        Me.bntpesquisa.Image = Global.DFe_aplicativo.My.Resources.Resources.magnifier
        Me.bntpesquisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bntpesquisa.Location = New System.Drawing.Point(608, 585)
        Me.bntpesquisa.Name = "bntpesquisa"
        Me.bntpesquisa.Size = New System.Drawing.Size(131, 28)
        Me.bntpesquisa.TabIndex = 174
        Me.bntpesquisa.Text = "     &Pesquisar"
        Me.bntpesquisa.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Blue
        Me.Button2.Image = Global.DFe_aplicativo.My.Resources.Resources.plus
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(386, 585)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(105, 28)
        Me.Button2.TabIndex = 173
        Me.Button2.Text = "     &Novo"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Blue
        Me.Button1.Image = Global.DFe_aplicativo.My.Resources.Resources.disk
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(497, 585)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 28)
        Me.Button1.TabIndex = 170
        Me.Button1.Text = "     &Salvar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.Color.Blue
        Me.Label26.Location = New System.Drawing.Point(3, 594)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(78, 13)
        Me.Label26.TabIndex = 176
        Me.Label26.Text = "Chave acesso:"
        '
        'mskchavecte
        '
        Me.mskchavecte.Location = New System.Drawing.Point(153, 65)
        Me.mskchavecte.Mask = "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000"
        Me.mskchavecte.Name = "mskchavecte"
        Me.mskchavecte.Size = New System.Drawing.Size(305, 20)
        Me.mskchavecte.TabIndex = 1
        Me.mskchavecte.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.mskchavecte.Visible = False
        '
        'lblchave_cte
        '
        Me.lblchave_cte.AutoSize = True
        Me.lblchave_cte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblchave_cte.Location = New System.Drawing.Point(3, 66)
        Me.lblchave_cte.Name = "lblchave_cte"
        Me.lblchave_cte.Size = New System.Drawing.Size(144, 16)
        Me.lblchave_cte.TabIndex = 171
        Me.lblchave_cte.Text = "Chave acesso CTe:"
        Me.lblchave_cte.Visible = False
        '
        'txtfrete_vlr
        '
        Me.txtfrete_vlr.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtfrete_vlr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtfrete_vlr.Location = New System.Drawing.Point(559, 66)
        Me.txtfrete_vlr.Name = "txtfrete_vlr"
        Me.txtfrete_vlr.Size = New System.Drawing.Size(76, 20)
        Me.txtfrete_vlr.TabIndex = 2
        Me.txtfrete_vlr.Text = "0,00"
        Me.txtfrete_vlr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtfrete_vlr.Visible = False
        '
        'lblfrete_vlr
        '
        Me.lblfrete_vlr.AutoSize = True
        Me.lblfrete_vlr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrete_vlr.ForeColor = System.Drawing.Color.Black
        Me.lblfrete_vlr.Location = New System.Drawing.Point(471, 68)
        Me.lblfrete_vlr.Name = "lblfrete_vlr"
        Me.lblfrete_vlr.Size = New System.Drawing.Size(80, 16)
        Me.lblfrete_vlr.TabIndex = 178
        Me.lblfrete_vlr.Text = "Valor frete"
        Me.lblfrete_vlr.Visible = False
        '
        'lblicms_frete
        '
        Me.lblicms_frete.AutoSize = True
        Me.lblicms_frete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblicms_frete.ForeColor = System.Drawing.Color.Black
        Me.lblicms_frete.Location = New System.Drawing.Point(642, 66)
        Me.lblicms_frete.Name = "lblicms_frete"
        Me.lblicms_frete.Size = New System.Drawing.Size(75, 16)
        Me.lblicms_frete.TabIndex = 180
        Me.lblicms_frete.Text = "Aliq ICMS"
        Me.lblicms_frete.Visible = False
        '
        'cboaliqfrete
        '
        Me.cboaliqfrete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboaliqfrete.FormattingEnabled = True
        Me.cboaliqfrete.Items.AddRange(New Object() {"0,00", "7,00", "12,00", "18,00", "25,00"})
        Me.cboaliqfrete.Location = New System.Drawing.Point(718, 65)
        Me.cboaliqfrete.Name = "cboaliqfrete"
        Me.cboaliqfrete.Size = New System.Drawing.Size(50, 21)
        Me.cboaliqfrete.TabIndex = 3
        Me.cboaliqfrete.Visible = False
        '
        'lblpisfrete
        '
        Me.lblpisfrete.AutoSize = True
        Me.lblpisfrete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpisfrete.ForeColor = System.Drawing.Color.Black
        Me.lblpisfrete.Location = New System.Drawing.Point(22, 92)
        Me.lblpisfrete.Name = "lblpisfrete"
        Me.lblpisfrete.Size = New System.Drawing.Size(127, 16)
        Me.lblpisfrete.TabIndex = 182
        Me.lblpisfrete.Text = "CST/PIS/COFINS"
        Me.lblpisfrete.Visible = False
        '
        'CBOCFOP_CORPO
        '
        Me.CBOCFOP_CORPO.BackColor = System.Drawing.Color.White
        Me.CBOCFOP_CORPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBOCFOP_CORPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CBOCFOP_CORPO.FormattingEnabled = True
        Me.CBOCFOP_CORPO.Location = New System.Drawing.Point(153, 118)
        Me.CBOCFOP_CORPO.Name = "CBOCFOP_CORPO"
        Me.CBOCFOP_CORPO.Size = New System.Drawing.Size(395, 21)
        Me.CBOCFOP_CORPO.TabIndex = 171
        Me.CBOCFOP_CORPO.Visible = False
        '
        'LBLCFOP
        '
        Me.LBLCFOP.AutoSize = True
        Me.LBLCFOP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCFOP.ForeColor = System.Drawing.Color.Black
        Me.LBLCFOP.Location = New System.Drawing.Point(99, 119)
        Me.LBLCFOP.Name = "LBLCFOP"
        Me.LBLCFOP.Size = New System.Drawing.Size(48, 16)
        Me.LBLCFOP.TabIndex = 183
        Me.LBLCFOP.Text = "CFOP"
        '
        'cbocstpisfrete
        '
        Me.cbocstpisfrete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbocstpisfrete.FormattingEnabled = True
        Me.cbocstpisfrete.Location = New System.Drawing.Point(153, 91)
        Me.cbocstpisfrete.Name = "cbocstpisfrete"
        Me.cbocstpisfrete.Size = New System.Drawing.Size(395, 21)
        Me.cbocstpisfrete.TabIndex = 4
        Me.cbocstpisfrete.Visible = False
        '
        'txtaliqpis_frete
        '
        Me.txtaliqpis_frete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtaliqpis_frete.Location = New System.Drawing.Point(597, 92)
        Me.txtaliqpis_frete.Name = "txtaliqpis_frete"
        Me.txtaliqpis_frete.Size = New System.Drawing.Size(53, 20)
        Me.txtaliqpis_frete.TabIndex = 184
        Me.txtaliqpis_frete.TabStop = False
        Me.txtaliqpis_frete.Text = "0,00"
        Me.txtaliqpis_frete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtaliqpis_frete.Visible = False
        '
        'lblaliqpis_frete
        '
        Me.lblaliqpis_frete.AutoSize = True
        Me.lblaliqpis_frete.Location = New System.Drawing.Point(554, 94)
        Me.lblaliqpis_frete.Name = "lblaliqpis_frete"
        Me.lblaliqpis_frete.Size = New System.Drawing.Size(41, 13)
        Me.lblaliqpis_frete.TabIndex = 187
        Me.lblaliqpis_frete.Text = "Aliq.Pis"
        Me.lblaliqpis_frete.Visible = False
        '
        'txtaliqcofins_frete
        '
        Me.txtaliqcofins_frete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtaliqcofins_frete.Location = New System.Drawing.Point(718, 91)
        Me.txtaliqcofins_frete.Name = "txtaliqcofins_frete"
        Me.txtaliqcofins_frete.Size = New System.Drawing.Size(50, 20)
        Me.txtaliqcofins_frete.TabIndex = 185
        Me.txtaliqcofins_frete.TabStop = False
        Me.txtaliqcofins_frete.Text = "0,00"
        Me.txtaliqcofins_frete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtaliqcofins_frete.Visible = False
        '
        'lblaliqcofins_frete
        '
        Me.lblaliqcofins_frete.AutoSize = True
        Me.lblaliqcofins_frete.Location = New System.Drawing.Point(661, 94)
        Me.lblaliqcofins_frete.Name = "lblaliqcofins_frete"
        Me.lblaliqcofins_frete.Size = New System.Drawing.Size(56, 13)
        Me.lblaliqcofins_frete.TabIndex = 186
        Me.lblaliqcofins_frete.Text = "Aliq.Cofins"
        Me.lblaliqcofins_frete.Visible = False
        '
        'frmnfe_entrada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 616)
        Me.Controls.Add(Me.txtaliqpis_frete)
        Me.Controls.Add(Me.lblaliqpis_frete)
        Me.Controls.Add(Me.txtaliqcofins_frete)
        Me.Controls.Add(Me.lblaliqcofins_frete)
        Me.Controls.Add(Me.LBLCFOP)
        Me.Controls.Add(Me.CBOCFOP_CORPO)
        Me.Controls.Add(Me.lblpisfrete)
        Me.Controls.Add(Me.cbocstpisfrete)
        Me.Controls.Add(Me.cboaliqfrete)
        Me.Controls.Add(Me.lblicms_frete)
        Me.Controls.Add(Me.txtfrete_vlr)
        Me.Controls.Add(Me.lblfrete_vlr)
        Me.Controls.Add(Me.lblchave_cte)
        Me.Controls.Add(Me.mskchavecte)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.bntexcluir)
        Me.Controls.Add(Me.bntpesquisa)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.lblchave)
        Me.Controls.Add(Me.dgvitens)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel_item)
        Me.Controls.Add(Me.Panel_totais)
        Me.Controls.Add(Me.Panel_ini)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmnfe_entrada"
        Me.Text = "Nota Fiscal de Entrada"
        Me.Panel_ini.ResumeLayout(False)
        Me.Panel_ini.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_totais.ResumeLayout(False)
        Me.Panel_totais.PerformLayout()
        Me.Panel30.ResumeLayout(False)
        Me.Panel30.PerformLayout()
        CType(Me.dgvitens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_item.ResumeLayout(False)
        Me.Panel_item.PerformLayout()
        CType(Me.Pic_cfop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel_ini As System.Windows.Forms.Panel
    Friend WithEvents data_entrada As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbomodelo As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents data_emissao As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtserienfe As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents txtnome_emi As System.Windows.Forms.TextBox
    Friend WithEvents Label172 As System.Windows.Forms.Label
    Friend WithEvents mskcnpj_emi As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label171 As System.Windows.Forms.Label
    Friend WithEvents Panel_totais As System.Windows.Forms.Panel
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents txtvlrfemst As System.Windows.Forms.TextBox
    Friend WithEvents txtvlrtotalbaseicms_nfe As System.Windows.Forms.TextBox
    Friend WithEvents txtvlrtotalicms_nfe As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txtvlrtotalbasest_nfe As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents txtvrltotalipi_nfe As System.Windows.Forms.TextBox
    Friend WithEvents txtvlrtotalst_nfe As System.Windows.Forms.TextBox
    Friend WithEvents txtvlrtotalcofins_nfe As System.Windows.Forms.TextBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents txtvlrtotalfrete_nfe As System.Windows.Forms.TextBox
    Friend WithEvents txtvlrtotaloutras_nfe As System.Windows.Forms.TextBox
    Friend WithEvents txtvlrtotaldesc_nfe As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents txtvlrtotalpis_nfe As System.Windows.Forms.TextBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents txtvlrtotalseg_nfe As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Panel30 As System.Windows.Forms.Panel
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtvlrtotal_nfe As System.Windows.Forms.TextBox
    Friend WithEvents txtvlrtotalprod_nfe As System.Windows.Forms.TextBox
    Friend WithEvents dgvitens As System.Windows.Forms.DataGridView
    Friend WithEvents txtqtdecx_item As System.Windows.Forms.TextBox
    Friend WithEvents txtvlrdesc_item As System.Windows.Forms.TextBox
    Friend WithEvents lbldesc As System.Windows.Forms.Label
    Friend WithEvents txtvlrtotal_item As System.Windows.Forms.TextBox
    Friend WithEvents txtqtde_item As System.Windows.Forms.TextBox
    Friend WithEvents Label169 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents txtvlrunit_item As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Pic_cfop As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtqtde_xml As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbocest_item As MTGCComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtncm_xml As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtcest_xml As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtcst_xml As System.Windows.Forms.TextBox
    Friend WithEvents cbocst_item As MTGCComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtaliqicms_item As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label96 As System.Windows.Forms.Label
    Friend WithEvents txtbaseicms_item As System.Windows.Forms.TextBox
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents txtvlricms_item As System.Windows.Forms.TextBox
    Friend WithEvents Label99 As System.Windows.Forms.Label
    Friend WithEvents txtbaseredicms_item As System.Windows.Forms.TextBox
    Friend WithEvents cboncm_item As MTGCComboBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents txtvlrst_item As System.Windows.Forms.TextBox
    Friend WithEvents cbocstipi_item As MTGCComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtaliqipi_item As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtvlripi_item As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbocstpis_item As MTGCComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtaliqcofins_item As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtvlrcofins_item As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtaliqpis_item As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtvlrpis_item As System.Windows.Forms.TextBox
    Friend WithEvents txtun_xml As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents bntok As System.Windows.Forms.Button
    Friend WithEvents bntalterar_item As System.Windows.Forms.Button
    Friend WithEvents bntexcluir_item As System.Windows.Forms.Button
    Friend WithEvents txtcodigoprod_item As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtdescprod_item As System.Windows.Forms.TextBox
    Friend WithEvents Panel_item As System.Windows.Forms.Panel
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtvlrseguro_item As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtvlrfrete_item As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtvlroutros_item As System.Windows.Forms.TextBox
    Friend WithEvents txtnumeronf As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents lblun As System.Windows.Forms.Label
    Friend WithEvents lbluf As System.Windows.Forms.Label
    Friend WithEvents cbocfop_item As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtfcpst_item As System.Windows.Forms.TextBox
    Friend WithEvents Nr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codprod_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descprod_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents un_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qtde_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlrunit_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlrdesc_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlrtotal_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ncm_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cest_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cfop_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cst_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents baseicms_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Redbcicms_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aliqicms_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlricms_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlrst_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cstpis_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aliqpis_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlrpis_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aliqcofins_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlrcofins_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cstipi_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aliqipi_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlripi_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents basest_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlrfrete_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlroutros_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlrseguro_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlrfcpst_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents obs_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtbcst_item As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblchave As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lbliten As System.Windows.Forms.Label
    Friend WithEvents txtvlrxml As System.Windows.Forms.TextBox
    Friend WithEvents txtipitotalxml As System.Windows.Forms.TextBox
    Friend WithEvents txtoutrostotalxml As System.Windows.Forms.TextBox
    Friend WithEvents txtfretetotalxml As System.Windows.Forms.TextBox
    Friend WithEvents txtsttotalxml As System.Windows.Forms.TextBox
    Friend WithEvents bntpesquisa As System.Windows.Forms.Button
    Friend WithEvents bntexcluir As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents mskchavecte As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblchave_cte As System.Windows.Forms.Label
    Friend WithEvents txtfrete_vlr As System.Windows.Forms.TextBox
    Friend WithEvents lblfrete_vlr As System.Windows.Forms.Label
    Friend WithEvents lblicms_frete As System.Windows.Forms.Label
    Friend WithEvents cboaliqfrete As System.Windows.Forms.ComboBox
    Friend WithEvents lblpisfrete As System.Windows.Forms.Label
    Friend WithEvents CBOCFOP_CORPO As System.Windows.Forms.ComboBox
    Friend WithEvents LBLCFOP As System.Windows.Forms.Label
    Friend WithEvents cbocstpisfrete As System.Windows.Forms.ComboBox
    Friend WithEvents txtaliqpis_frete As System.Windows.Forms.TextBox
    Friend WithEvents lblaliqpis_frete As System.Windows.Forms.Label
    Friend WithEvents txtaliqcofins_frete As System.Windows.Forms.TextBox
    Friend WithEvents lblaliqcofins_frete As System.Windows.Forms.Label
End Class
