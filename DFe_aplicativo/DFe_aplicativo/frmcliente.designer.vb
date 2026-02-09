<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmcliente))
        Me.gconvenio = New System.Windows.Forms.GroupBox()
        Me.cboconvenio = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtcodconv = New System.Windows.Forms.TextBox()
        Me.gcliente = New System.Windows.Forms.GroupBox()
        Me.chkfor = New System.Windows.Forms.CheckBox()
        Me.txtcod_munic = New System.Windows.Forms.TextBox()
        Me.cboind_dest = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.mskdatanasc = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.mskdatacad = New System.Windows.Forms.MaskedTextBox()
        Me.optjuridica = New System.Windows.Forms.RadioButton()
        Me.optfisica = New System.Windows.Forms.RadioButton()
        Me.txtcidade = New System.Windows.Forms.TextBox()
        Me.mskcpf = New System.Windows.Forms.MaskedTextBox()
        Me.mskcep = New System.Windows.Forms.MaskedTextBox()
        Me.lblinfo = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtjuro = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtvlrusado = New System.Windows.Forms.TextBox()
        Me.txtprozopag = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtdes = New System.Windows.Forms.TextBox()
        Me.chkcobrajuro = New System.Windows.Forms.CheckBox()
        Me.txtcredito = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.chkliberar = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mskfone = New System.Windows.Forms.MaskedTextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvfone = New System.Windows.Forms.DataGridView()
        Me.fone_cligrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cbosexo = New System.Windows.Forms.ComboBox()
        Me.label = New System.Windows.Forms.Label()
        Me.txtrg = New System.Windows.Forms.TextBox()
        Me.txtuf = New System.Windows.Forms.TextBox()
        Me.txtbairro = New System.Windows.Forms.TextBox()
        Me.txtnumero = New System.Windows.Forms.TextBox()
        Me.txtend = New System.Windows.Forms.TextBox()
        Me.txtnome = New System.Windows.Forms.TextBox()
        Me.txtcod = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.g = New System.Windows.Forms.GroupBox()
        Me.txtobs = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txttrabalho = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtpai = New System.Windows.Forms.TextBox()
        Me.txtmae = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.bntcancelar = New System.Windows.Forms.Button()
        Me.Bnteditar = New System.Windows.Forms.Button()
        Me.btnconsulta = New System.Windows.Forms.Button()
        Me.btnsair = New System.Windows.Forms.Button()
        Me.btnexcluir = New System.Windows.Forms.Button()
        Me.btnsalvar = New System.Windows.Forms.Button()
        Me.btnovo = New System.Windows.Forms.Button()
        Me.gconvenio.SuspendLayout()
        Me.gcliente.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvfone, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.g.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gconvenio
        '
        Me.gconvenio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.gconvenio.Controls.Add(Me.cboconvenio)
        Me.gconvenio.Controls.Add(Me.Label2)
        Me.gconvenio.Controls.Add(Me.txtcodconv)
        Me.gconvenio.Enabled = False
        Me.gconvenio.Location = New System.Drawing.Point(5, 9)
        Me.gconvenio.Name = "gconvenio"
        Me.gconvenio.Size = New System.Drawing.Size(559, 44)
        Me.gconvenio.TabIndex = 6
        Me.gconvenio.TabStop = False
        Me.gconvenio.Text = "Convênio"
        '
        'cboconvenio
        '
        Me.cboconvenio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboconvenio.FormattingEnabled = True
        Me.cboconvenio.Items.AddRange(New Object() {"1-Geral"})
        Me.cboconvenio.Location = New System.Drawing.Point(104, 16)
        Me.cboconvenio.Name = "cboconvenio"
        Me.cboconvenio.Size = New System.Drawing.Size(452, 21)
        Me.cboconvenio.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(0, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nome do Convênio"
        '
        'txtcodconv
        '
        Me.txtcodconv.Location = New System.Drawing.Point(422, 16)
        Me.txtcodconv.Name = "txtcodconv"
        Me.txtcodconv.Size = New System.Drawing.Size(60, 20)
        Me.txtcodconv.TabIndex = 5
        Me.txtcodconv.Visible = False
        '
        'gcliente
        '
        Me.gcliente.Controls.Add(Me.chkfor)
        Me.gcliente.Controls.Add(Me.txtcod_munic)
        Me.gcliente.Controls.Add(Me.gconvenio)
        Me.gcliente.Controls.Add(Me.cboind_dest)
        Me.gcliente.Controls.Add(Me.Label24)
        Me.gcliente.Controls.Add(Me.Label18)
        Me.gcliente.Controls.Add(Me.mskdatanasc)
        Me.gcliente.Controls.Add(Me.Label19)
        Me.gcliente.Controls.Add(Me.mskdatacad)
        Me.gcliente.Controls.Add(Me.optjuridica)
        Me.gcliente.Controls.Add(Me.optfisica)
        Me.gcliente.Controls.Add(Me.txtcidade)
        Me.gcliente.Controls.Add(Me.mskcpf)
        Me.gcliente.Controls.Add(Me.mskcep)
        Me.gcliente.Controls.Add(Me.lblinfo)
        Me.gcliente.Controls.Add(Me.GroupBox4)
        Me.gcliente.Controls.Add(Me.GroupBox3)
        Me.gcliente.Controls.Add(Me.Label14)
        Me.gcliente.Controls.Add(Me.cbosexo)
        Me.gcliente.Controls.Add(Me.label)
        Me.gcliente.Controls.Add(Me.txtrg)
        Me.gcliente.Controls.Add(Me.txtuf)
        Me.gcliente.Controls.Add(Me.txtbairro)
        Me.gcliente.Controls.Add(Me.txtnumero)
        Me.gcliente.Controls.Add(Me.txtend)
        Me.gcliente.Controls.Add(Me.txtnome)
        Me.gcliente.Controls.Add(Me.txtcod)
        Me.gcliente.Controls.Add(Me.Label13)
        Me.gcliente.Controls.Add(Me.Label12)
        Me.gcliente.Controls.Add(Me.Label10)
        Me.gcliente.Controls.Add(Me.Label9)
        Me.gcliente.Controls.Add(Me.Label8)
        Me.gcliente.Controls.Add(Me.Label7)
        Me.gcliente.Controls.Add(Me.Label6)
        Me.gcliente.Controls.Add(Me.Label5)
        Me.gcliente.Controls.Add(Me.Label4)
        Me.gcliente.Controls.Add(Me.Label3)
        Me.gcliente.Enabled = False
        Me.gcliente.ForeColor = System.Drawing.Color.Blue
        Me.gcliente.Location = New System.Drawing.Point(7, 6)
        Me.gcliente.Name = "gcliente"
        Me.gcliente.Size = New System.Drawing.Size(571, 368)
        Me.gcliente.TabIndex = 5
        Me.gcliente.TabStop = False
        '
        'chkfor
        '
        Me.chkfor.AutoSize = True
        Me.chkfor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkfor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkfor.Location = New System.Drawing.Point(332, 145)
        Me.chkfor.Name = "chkfor"
        Me.chkfor.Size = New System.Drawing.Size(80, 17)
        Me.chkfor.TabIndex = 57
        Me.chkfor.Text = "Fornecedor"
        Me.chkfor.UseVisualStyleBackColor = False
        '
        'txtcod_munic
        '
        Me.txtcod_munic.Location = New System.Drawing.Point(383, 145)
        Me.txtcod_munic.Name = "txtcod_munic"
        Me.txtcod_munic.Size = New System.Drawing.Size(45, 20)
        Me.txtcod_munic.TabIndex = 93
        Me.txtcod_munic.Visible = False
        '
        'cboind_dest
        '
        Me.cboind_dest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboind_dest.FormattingEnabled = True
        Me.cboind_dest.Items.AddRange(New Object() {"1–Contribuinte ICMS", "2–Contribuinte isento", "9–Não Contribuinte"})
        Me.cboind_dest.Location = New System.Drawing.Point(452, 169)
        Me.cboind_dest.Name = "cboind_dest"
        Me.cboind_dest.Size = New System.Drawing.Size(112, 21)
        Me.cboind_dest.TabIndex = 8
        Me.cboind_dest.TabStop = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(359, 172)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(88, 13)
        Me.Label24.TabIndex = 92
        Me.Label24.Text = "Ind. Contribuente"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(187, 200)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(71, 13)
        Me.Label18.TabIndex = 91
        Me.Label18.Text = "Insc Estadual"
        Me.Label18.Visible = False
        '
        'mskdatanasc
        '
        Me.mskdatanasc.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.mskdatanasc.Location = New System.Drawing.Point(261, 228)
        Me.mskdatanasc.Name = "mskdatanasc"
        Me.mskdatanasc.Size = New System.Drawing.Size(95, 20)
        Me.mskdatanasc.TabIndex = 9
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(432, 62)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 13)
        Me.Label19.TabIndex = 51
        Me.Label19.Text = "Data Cad."
        '
        'mskdatacad
        '
        Me.mskdatacad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mskdatacad.Location = New System.Drawing.Point(493, 58)
        Me.mskdatacad.Mask = "00/00/0000"
        Me.mskdatacad.Name = "mskdatacad"
        Me.mskdatacad.ReadOnly = True
        Me.mskdatacad.Size = New System.Drawing.Size(71, 20)
        Me.mskdatacad.TabIndex = 33
        '
        'optjuridica
        '
        Me.optjuridica.AutoSize = True
        Me.optjuridica.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.optjuridica.Location = New System.Drawing.Point(297, 62)
        Me.optjuridica.Name = "optjuridica"
        Me.optjuridica.Size = New System.Drawing.Size(99, 17)
        Me.optjuridica.TabIndex = 32
        Me.optjuridica.Text = "Pessoa Juridica"
        Me.optjuridica.UseVisualStyleBackColor = False
        '
        'optfisica
        '
        Me.optfisica.AutoSize = True
        Me.optfisica.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.optfisica.Checked = True
        Me.optfisica.Location = New System.Drawing.Point(185, 62)
        Me.optfisica.Name = "optfisica"
        Me.optfisica.Size = New System.Drawing.Size(89, 17)
        Me.optfisica.TabIndex = 31
        Me.optfisica.TabStop = True
        Me.optfisica.Text = "Pessoa física"
        Me.optfisica.UseVisualStyleBackColor = False
        '
        'txtcidade
        '
        Me.txtcidade.BackColor = System.Drawing.Color.White
        Me.txtcidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcidade.Location = New System.Drawing.Point(76, 169)
        Me.txtcidade.Name = "txtcidade"
        Me.txtcidade.ReadOnly = True
        Me.txtcidade.Size = New System.Drawing.Size(209, 20)
        Me.txtcidade.TabIndex = 25
        Me.txtcidade.TabStop = False
        '
        'mskcpf
        '
        Me.mskcpf.Location = New System.Drawing.Point(76, 197)
        Me.mskcpf.Mask = "000,000,000-00"
        Me.mskcpf.Name = "mskcpf"
        Me.mskcpf.Size = New System.Drawing.Size(105, 20)
        Me.mskcpf.TabIndex = 6
        Me.mskcpf.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'mskcep
        '
        Me.mskcep.Location = New System.Drawing.Point(495, 143)
        Me.mskcep.Mask = "00.000-000"
        Me.mskcep.Name = "mskcep"
        Me.mskcep.Size = New System.Drawing.Size(69, 20)
        Me.mskcep.TabIndex = 5
        Me.mskcep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'lblinfo
        '
        Me.lblinfo.AutoSize = True
        Me.lblinfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblinfo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblinfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblinfo.ForeColor = System.Drawing.Color.Black
        Me.lblinfo.Location = New System.Drawing.Point(295, 152)
        Me.lblinfo.Name = "lblinfo"
        Me.lblinfo.Size = New System.Drawing.Size(117, 13)
        Me.lblinfo.TabIndex = 28
        Me.lblinfo.Text = "Outras Informações"
        Me.lblinfo.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Controls.Add(Me.txtjuro)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Controls.Add(Me.txtvlrusado)
        Me.GroupBox4.Controls.Add(Me.txtprozopag)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.txtdes)
        Me.GroupBox4.Controls.Add(Me.chkcobrajuro)
        Me.GroupBox4.Controls.Add(Me.txtcredito)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.chkliberar)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 256)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(351, 104)
        Me.GroupBox4.TabIndex = 27
        Me.GroupBox4.TabStop = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(167, 73)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(15, 13)
        Me.Label26.TabIndex = 56
        Me.Label26.Text = "%"
        '
        'txtjuro
        '
        Me.txtjuro.Enabled = False
        Me.txtjuro.Location = New System.Drawing.Point(97, 70)
        Me.txtjuro.Name = "txtjuro"
        Me.txtjuro.Size = New System.Drawing.Size(70, 20)
        Me.txtjuro.TabIndex = 55
        Me.txtjuro.Text = "0,00"
        Me.txtjuro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(9, 49)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(83, 13)
        Me.Label25.TabIndex = 54
        Me.Label25.Text = "Valor Disponìvel"
        '
        'txtvlrusado
        '
        Me.txtvlrusado.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtvlrusado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvlrusado.Location = New System.Drawing.Point(97, 45)
        Me.txtvlrusado.Name = "txtvlrusado"
        Me.txtvlrusado.ReadOnly = True
        Me.txtvlrusado.Size = New System.Drawing.Size(70, 20)
        Me.txtvlrusado.TabIndex = 53
        Me.txtvlrusado.Text = "0,00"
        Me.txtvlrusado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtprozopag
        '
        Me.txtprozopag.Location = New System.Drawing.Point(264, 42)
        Me.txtprozopag.Name = "txtprozopag"
        Me.txtprozopag.Size = New System.Drawing.Size(78, 20)
        Me.txtprozopag.TabIndex = 12
        Me.txtprozopag.Text = "30"
        Me.txtprozopag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(199, 45)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 13)
        Me.Label16.TabIndex = 50
        Me.Label16.Text = "Prazo Pag."
        '
        'txtdes
        '
        Me.txtdes.Location = New System.Drawing.Point(264, 19)
        Me.txtdes.Name = "txtdes"
        Me.txtdes.Size = New System.Drawing.Size(78, 20)
        Me.txtdes.TabIndex = 11
        Me.txtdes.Text = "0,00"
        Me.txtdes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkcobrajuro
        '
        Me.chkcobrajuro.AutoSize = True
        Me.chkcobrajuro.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkcobrajuro.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkcobrajuro.Location = New System.Drawing.Point(11, 72)
        Me.chkcobrajuro.Name = "chkcobrajuro"
        Me.chkcobrajuro.Size = New System.Drawing.Size(80, 17)
        Me.chkcobrajuro.TabIndex = 14
        Me.chkcobrajuro.Text = "Cobrar Juro"
        Me.chkcobrajuro.UseVisualStyleBackColor = False
        '
        'txtcredito
        '
        Me.txtcredito.Location = New System.Drawing.Point(97, 19)
        Me.txtcredito.Name = "txtcredito"
        Me.txtcredito.Size = New System.Drawing.Size(70, 20)
        Me.txtcredito.TabIndex = 10
        Me.txtcredito.Text = "0,00"
        Me.txtcredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(205, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 13)
        Me.Label17.TabIndex = 50
        Me.Label17.Text = "Desconto"
        '
        'chkliberar
        '
        Me.chkliberar.AutoSize = True
        Me.chkliberar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkliberar.Checked = True
        Me.chkliberar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkliberar.Location = New System.Drawing.Point(240, 72)
        Me.chkliberar.Name = "chkliberar"
        Me.chkliberar.Size = New System.Drawing.Size(102, 17)
        Me.chkliberar.TabIndex = 15
        Me.chkliberar.Text = "Cliente Liberado"
        Me.chkliberar.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(18, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 13)
        Me.Label15.TabIndex = 52
        Me.Label15.Text = "Limite Credito"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Silver
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.mskfone)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.dgvfone)
        Me.GroupBox3.Location = New System.Drawing.Point(362, 204)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(202, 156)
        Me.GroupBox3.TabIndex = 22
        Me.GroupBox3.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 92
        Me.Label1.Text = "TELEFONE"
        '
        'mskfone
        '
        Me.mskfone.Location = New System.Drawing.Point(6, 26)
        Me.mskfone.Mask = "(00) 0-0000-0000"
        Me.mskfone.Name = "mskfone"
        Me.mskfone.Size = New System.Drawing.Size(100, 20)
        Me.mskfone.TabIndex = 95
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.DFe_aplicativo.My.Resources.Resources.Delete
        Me.Button2.Location = New System.Drawing.Point(153, 26)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(43, 21)
        Me.Button2.TabIndex = 94
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.DFe_aplicativo.My.Resources.Resources.file
        Me.Button1.Location = New System.Drawing.Point(109, 26)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 21)
        Me.Button1.TabIndex = 96
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgvfone
        '
        Me.dgvfone.AllowUserToAddRows = False
        Me.dgvfone.AllowUserToDeleteRows = False
        Me.dgvfone.AllowUserToResizeColumns = False
        Me.dgvfone.AllowUserToResizeRows = False
        Me.dgvfone.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgvfone.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.NavajoWhite
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvfone.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvfone.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fone_cligrid, Me.Column3})
        Me.dgvfone.EnableHeadersVisualStyles = False
        Me.dgvfone.GridColor = System.Drawing.Color.Blue
        Me.dgvfone.Location = New System.Drawing.Point(6, 52)
        Me.dgvfone.Name = "dgvfone"
        Me.dgvfone.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.NavajoWhite
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvfone.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvfone.RowHeadersWidth = 25
        Me.dgvfone.Size = New System.Drawing.Size(190, 97)
        Me.dgvfone.TabIndex = 13
        '
        'fone_cligrid
        '
        Me.fone_cligrid.DataPropertyName = "fone_cligird"
        Me.fone_cligrid.HeaderText = "TELEFONE"
        Me.fone_cligrid.MaxInputLength = 9
        Me.fone_cligrid.Name = "fone_cligrid"
        Me.fone_cligrid.Width = 145
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "chave_cli"
        Me.Column3.HeaderText = "CHAVE"
        Me.Column3.Name = "Column3"
        Me.Column3.Visible = False
        Me.Column3.Width = 80
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(184, 233)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 13)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "DATA NASC."
        '
        'cbosexo
        '
        Me.cbosexo.BackColor = System.Drawing.SystemColors.Window
        Me.cbosexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbosexo.FormattingEnabled = True
        Me.cbosexo.Items.AddRange(New Object() {"FEMININO", "MASCULINO", "OUTROS"})
        Me.cbosexo.Location = New System.Drawing.Point(76, 227)
        Me.cbosexo.Name = "cbosexo"
        Me.cbosexo.Size = New System.Drawing.Size(105, 21)
        Me.cbosexo.TabIndex = 8
        '
        'label
        '
        Me.label.AutoSize = True
        Me.label.Location = New System.Drawing.Point(34, 230)
        Me.label.Name = "label"
        Me.label.Size = New System.Drawing.Size(36, 13)
        Me.label.TabIndex = 53
        Me.label.Text = "SEXO"
        '
        'txtrg
        '
        Me.txtrg.Location = New System.Drawing.Point(261, 197)
        Me.txtrg.Name = "txtrg"
        Me.txtrg.Size = New System.Drawing.Size(95, 20)
        Me.txtrg.TabIndex = 7
        '
        'txtuf
        '
        Me.txtuf.BackColor = System.Drawing.Color.White
        Me.txtuf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtuf.Location = New System.Drawing.Point(319, 169)
        Me.txtuf.Name = "txtuf"
        Me.txtuf.ReadOnly = True
        Me.txtuf.Size = New System.Drawing.Size(37, 20)
        Me.txtuf.TabIndex = 26
        Me.txtuf.TabStop = False
        '
        'txtbairro
        '
        Me.txtbairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbairro.Location = New System.Drawing.Point(76, 143)
        Me.txtbairro.Name = "txtbairro"
        Me.txtbairro.Size = New System.Drawing.Size(209, 20)
        Me.txtbairro.TabIndex = 4
        '
        'txtnumero
        '
        Me.txtnumero.Location = New System.Drawing.Point(495, 117)
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(69, 20)
        Me.txtnumero.TabIndex = 3
        '
        'txtend
        '
        Me.txtend.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtend.Location = New System.Drawing.Point(76, 117)
        Me.txtend.Name = "txtend"
        Me.txtend.Size = New System.Drawing.Size(336, 20)
        Me.txtend.TabIndex = 2
        '
        'txtnome
        '
        Me.txtnome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnome.Location = New System.Drawing.Point(76, 89)
        Me.txtnome.Name = "txtnome"
        Me.txtnome.Size = New System.Drawing.Size(488, 20)
        Me.txtnome.TabIndex = 1
        '
        'txtcod
        '
        Me.txtcod.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtcod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcod.Location = New System.Drawing.Point(76, 59)
        Me.txtcod.Name = "txtcod"
        Me.txtcod.ReadOnly = True
        Me.txtcod.Size = New System.Drawing.Size(72, 20)
        Me.txtcod.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(43, 204)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(27, 13)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "CPF"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(232, 200)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(23, 13)
        Me.Label12.TabIndex = 55
        Me.Label12.Text = "RG"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(292, 172)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(21, 13)
        Me.Label10.TabIndex = 90
        Me.Label10.Text = "UF"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(459, 146)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 89
        Me.Label9.Text = "CEP"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 172)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 85
        Me.Label8.Text = "CIDADE"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 146)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 87
        Me.Label7.Text = "BAIRRO"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(434, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "NÚMERO"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "ENDEREÇO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "NOME"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "CÓDIGO"
        '
        'g
        '
        Me.g.BackColor = System.Drawing.Color.Silver
        Me.g.Controls.Add(Me.txtobs)
        Me.g.Controls.Add(Me.Label23)
        Me.g.Controls.Add(Me.txtemail)
        Me.g.Controls.Add(Me.Label11)
        Me.g.Controls.Add(Me.txttrabalho)
        Me.g.Controls.Add(Me.Label22)
        Me.g.Controls.Add(Me.txtpai)
        Me.g.Controls.Add(Me.txtmae)
        Me.g.Controls.Add(Me.Label21)
        Me.g.Controls.Add(Me.Label20)
        Me.g.Location = New System.Drawing.Point(65, 50)
        Me.g.Name = "g"
        Me.g.Size = New System.Drawing.Size(443, 197)
        Me.g.TabIndex = 33
        Me.g.TabStop = False
        Me.g.Text = "Outras Informações"
        '
        'txtobs
        '
        Me.txtobs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtobs.Location = New System.Drawing.Point(78, 117)
        Me.txtobs.Multiline = True
        Me.txtobs.Name = "txtobs"
        Me.txtobs.Size = New System.Drawing.Size(357, 73)
        Me.txtobs.TabIndex = 13
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(39, 128)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(32, 13)
        Me.Label23.TabIndex = 12
        Me.Label23.Text = "OBS:"
        '
        'txtemail
        '
        Me.txtemail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtemail.Location = New System.Drawing.Point(78, 91)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(357, 20)
        Me.txtemail.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(30, 98)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "E-MAIL"
        '
        'txttrabalho
        '
        Me.txttrabalho.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttrabalho.Location = New System.Drawing.Point(78, 68)
        Me.txttrabalho.Name = "txttrabalho"
        Me.txttrabalho.Size = New System.Drawing.Size(357, 20)
        Me.txttrabalho.TabIndex = 5
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(7, 71)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(65, 13)
        Me.Label22.TabIndex = 4
        Me.Label22.Text = "TRABALHO"
        '
        'txtpai
        '
        Me.txtpai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpai.Location = New System.Drawing.Point(78, 44)
        Me.txtpai.Name = "txtpai"
        Me.txtpai.Size = New System.Drawing.Size(357, 20)
        Me.txtpai.TabIndex = 3
        '
        'txtmae
        '
        Me.txtmae.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmae.Location = New System.Drawing.Point(78, 19)
        Me.txtmae.Name = "txtmae"
        Me.txtmae.Size = New System.Drawing.Size(357, 20)
        Me.txtmae.TabIndex = 2
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(13, 47)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 13)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "NOME PAI"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(7, 22)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 13)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "NOME MÃE"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(8, 51)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(589, 405)
        Me.TabControl1.TabIndex = 40
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gcliente)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(581, 379)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Principal"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.g)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(581, 379)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Outras"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'bntcancelar
        '
        Me.bntcancelar.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.bntcancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bntcancelar.Image = CType(resources.GetObject("bntcancelar.Image"), System.Drawing.Image)
        Me.bntcancelar.Location = New System.Drawing.Point(383, 2)
        Me.bntcancelar.Name = "bntcancelar"
        Me.bntcancelar.Size = New System.Drawing.Size(86, 43)
        Me.bntcancelar.TabIndex = 41
        Me.bntcancelar.TabStop = False
        Me.bntcancelar.UseVisualStyleBackColor = False
        Me.bntcancelar.Visible = False
        '
        'Bnteditar
        '
        Me.Bnteditar.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Bnteditar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Bnteditar.Image = CType(resources.GetObject("Bnteditar.Image"), System.Drawing.Image)
        Me.Bnteditar.Location = New System.Drawing.Point(384, 2)
        Me.Bnteditar.Name = "Bnteditar"
        Me.Bnteditar.Size = New System.Drawing.Size(86, 43)
        Me.Bnteditar.TabIndex = 39
        Me.Bnteditar.TabStop = False
        Me.Bnteditar.UseVisualStyleBackColor = False
        '
        'btnconsulta
        '
        Me.btnconsulta.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnconsulta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnconsulta.Image = CType(resources.GetObject("btnconsulta.Image"), System.Drawing.Image)
        Me.btnconsulta.Location = New System.Drawing.Point(289, 2)
        Me.btnconsulta.Name = "btnconsulta"
        Me.btnconsulta.Size = New System.Drawing.Size(88, 43)
        Me.btnconsulta.TabIndex = 37
        Me.btnconsulta.TabStop = False
        Me.btnconsulta.UseVisualStyleBackColor = False
        '
        'btnsair
        '
        Me.btnsair.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnsair.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsair.Image = CType(resources.GetObject("btnsair.Image"), System.Drawing.Image)
        Me.btnsair.Location = New System.Drawing.Point(510, 2)
        Me.btnsair.Name = "btnsair"
        Me.btnsair.Size = New System.Drawing.Size(83, 43)
        Me.btnsair.TabIndex = 38
        Me.btnsair.TabStop = False
        Me.btnsair.UseVisualStyleBackColor = False
        '
        'btnexcluir
        '
        Me.btnexcluir.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnexcluir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexcluir.Image = CType(resources.GetObject("btnexcluir.Image"), System.Drawing.Image)
        Me.btnexcluir.Location = New System.Drawing.Point(194, 2)
        Me.btnexcluir.Name = "btnexcluir"
        Me.btnexcluir.Size = New System.Drawing.Size(89, 43)
        Me.btnexcluir.TabIndex = 36
        Me.btnexcluir.TabStop = False
        Me.btnexcluir.UseVisualStyleBackColor = False
        '
        'btnsalvar
        '
        Me.btnsalvar.AllowDrop = True
        Me.btnsalvar.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnsalvar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsalvar.Image = CType(resources.GetObject("btnsalvar.Image"), System.Drawing.Image)
        Me.btnsalvar.Location = New System.Drawing.Point(95, 2)
        Me.btnsalvar.Name = "btnsalvar"
        Me.btnsalvar.Size = New System.Drawing.Size(93, 43)
        Me.btnsalvar.TabIndex = 34
        Me.btnsalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnsalvar.UseVisualStyleBackColor = False
        '
        'btnovo
        '
        Me.btnovo.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnovo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnovo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnovo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen
        Me.btnovo.Image = CType(resources.GetObject("btnovo.Image"), System.Drawing.Image)
        Me.btnovo.Location = New System.Drawing.Point(8, 2)
        Me.btnovo.Name = "btnovo"
        Me.btnovo.Size = New System.Drawing.Size(81, 43)
        Me.btnovo.TabIndex = 35
        Me.btnovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnovo.UseVisualStyleBackColor = False
        '
        'frmcliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 459)
        Me.Controls.Add(Me.bntcancelar)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Bnteditar)
        Me.Controls.Add(Me.btnconsulta)
        Me.Controls.Add(Me.btnsair)
        Me.Controls.Add(Me.btnexcluir)
        Me.Controls.Add(Me.btnsalvar)
        Me.Controls.Add(Me.btnovo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmcliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "cadastro de cliente"
        Me.gconvenio.ResumeLayout(False)
        Me.gconvenio.PerformLayout()
        Me.gcliente.ResumeLayout(False)
        Me.gcliente.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvfone, System.ComponentModel.ISupportInitialize).EndInit()
        Me.g.ResumeLayout(False)
        Me.g.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gconvenio As System.Windows.Forms.GroupBox
    Friend WithEvents cboconvenio As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtcodconv As System.Windows.Forms.TextBox
    Friend WithEvents gcliente As System.Windows.Forms.GroupBox
    Friend WithEvents txtcidade As System.Windows.Forms.TextBox
    Friend WithEvents mskcpf As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskcep As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblinfo As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents mskdatacad As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtprozopag As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtdes As System.Windows.Forms.TextBox
    Friend WithEvents txtcredito As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents chkliberar As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvfone As System.Windows.Forms.DataGridView
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbosexo As System.Windows.Forms.ComboBox
    Friend WithEvents label As System.Windows.Forms.Label
    Friend WithEvents txtrg As System.Windows.Forms.TextBox
    Friend WithEvents txtuf As System.Windows.Forms.TextBox
    Friend WithEvents txtbairro As System.Windows.Forms.TextBox
    Friend WithEvents txtnumero As System.Windows.Forms.TextBox
    Friend WithEvents txtend As System.Windows.Forms.TextBox
    Friend WithEvents txtnome As System.Windows.Forms.TextBox
    Friend WithEvents txtcod As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents optjuridica As System.Windows.Forms.RadioButton
    Friend WithEvents optfisica As System.Windows.Forms.RadioButton
    Friend WithEvents g As System.Windows.Forms.GroupBox
    Friend WithEvents txtobs As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txttrabalho As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtpai As System.Windows.Forms.TextBox
    Friend WithEvents txtmae As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtvlrusado As System.Windows.Forms.TextBox
    Friend WithEvents txtjuro As System.Windows.Forms.TextBox
    Friend WithEvents btnconsulta As System.Windows.Forms.Button
    Friend WithEvents btnsair As System.Windows.Forms.Button
    Friend WithEvents btnexcluir As System.Windows.Forms.Button
    Friend WithEvents btnsalvar As System.Windows.Forms.Button
    Friend WithEvents btnovo As System.Windows.Forms.Button
    Friend WithEvents Bnteditar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents mskfone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mskdatanasc As System.Windows.Forms.DateTimePicker
    Friend WithEvents fone_cligrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboind_dest As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtcod_munic As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents chkcobrajuro As System.Windows.Forms.CheckBox
    Friend WithEvents bntcancelar As System.Windows.Forms.Button
    Friend WithEvents chkfor As System.Windows.Forms.CheckBox
End Class
