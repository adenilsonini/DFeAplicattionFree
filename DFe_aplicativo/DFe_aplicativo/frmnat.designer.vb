<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmnat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmnat))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtcod = New System.Windows.Forms.TextBox()
        Me.chksaida = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.optentrada = New System.Windows.Forms.RadioButton()
        Me.optcupom = New System.Windows.Forms.RadioButton()
        Me.optbonificacao = New System.Windows.Forms.RadioButton()
        Me.optoutros = New System.Windows.Forms.RadioButton()
        Me.optdevolucao = New System.Windows.Forms.RadioButton()
        Me.optajuste = New System.Windows.Forms.RadioButton()
        Me.optvenda = New System.Windows.Forms.RadioButton()
        Me.optcomplemento = New System.Windows.Forms.RadioButton()
        Me.chktrib = New System.Windows.Forms.CheckBox()
        Me.txtnat = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbocfop_f2 = New MTGCComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbocfop_f1 = New MTGCComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbocfop_d2 = New MTGCComboBox()
        Me.cbocfop_d1 = New MTGCComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvnat = New System.Windows.Forms.DataGridView()
        Me.desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnSair = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnNovo = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvnat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtcod)
        Me.Panel1.Controls.Add(Me.chksaida)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.txtnat)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(2, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(517, 110)
        Me.Panel1.TabIndex = 0
        '
        'txtcod
        '
        Me.txtcod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcod.Location = New System.Drawing.Point(3, 24)
        Me.txtcod.MaxLength = 60
        Me.txtcod.Name = "txtcod"
        Me.txtcod.Size = New System.Drawing.Size(55, 20)
        Me.txtcod.TabIndex = 0
        '
        'chksaida
        '
        Me.chksaida.AutoSize = True
        Me.chksaida.BackColor = System.Drawing.Color.Silver
        Me.chksaida.Checked = True
        Me.chksaida.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chksaida.Location = New System.Drawing.Point(428, 6)
        Me.chksaida.Name = "chksaida"
        Me.chksaida.Size = New System.Drawing.Size(81, 17)
        Me.chksaida.TabIndex = 14
        Me.chksaida.TabStop = False
        Me.chksaida.Text = "NF-e Saída"
        Me.chksaida.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Código"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.optentrada)
        Me.Panel3.Controls.Add(Me.optcupom)
        Me.Panel3.Controls.Add(Me.optbonificacao)
        Me.Panel3.Controls.Add(Me.optoutros)
        Me.Panel3.Controls.Add(Me.optdevolucao)
        Me.Panel3.Controls.Add(Me.optajuste)
        Me.Panel3.Controls.Add(Me.optvenda)
        Me.Panel3.Controls.Add(Me.optcomplemento)
        Me.Panel3.Controls.Add(Me.chktrib)
        Me.Panel3.Location = New System.Drawing.Point(6, 50)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(503, 54)
        Me.Panel3.TabIndex = 2
        '
        'optentrada
        '
        Me.optentrada.AutoSize = True
        Me.optentrada.Location = New System.Drawing.Point(235, 29)
        Me.optentrada.Name = "optentrada"
        Me.optentrada.Size = New System.Drawing.Size(84, 17)
        Me.optentrada.TabIndex = 8
        Me.optentrada.TabStop = True
        Me.optentrada.Text = "NFe entrada"
        Me.optentrada.UseVisualStyleBackColor = True
        '
        'optcupom
        '
        Me.optcupom.AutoSize = True
        Me.optcupom.Location = New System.Drawing.Point(89, 30)
        Me.optcupom.Name = "optcupom"
        Me.optcupom.Size = New System.Drawing.Size(137, 17)
        Me.optcupom.TabIndex = 6
        Me.optcupom.TabStop = True
        Me.optcupom.Text = "Cobertura Cupom Fiscal"
        Me.optcupom.UseVisualStyleBackColor = True
        '
        'optbonificacao
        '
        Me.optbonificacao.AutoSize = True
        Me.optbonificacao.Location = New System.Drawing.Point(2, 30)
        Me.optbonificacao.Name = "optbonificacao"
        Me.optbonificacao.Size = New System.Drawing.Size(81, 17)
        Me.optbonificacao.TabIndex = 5
        Me.optbonificacao.TabStop = True
        Me.optbonificacao.Text = "Bonificação"
        Me.optbonificacao.UseVisualStyleBackColor = True
        '
        'optoutros
        '
        Me.optoutros.AutoSize = True
        Me.optoutros.Location = New System.Drawing.Point(383, 7)
        Me.optoutros.Name = "optoutros"
        Me.optoutros.Size = New System.Drawing.Size(111, 17)
        Me.optoutros.TabIndex = 4
        Me.optoutros.TabStop = True
        Me.optoutros.Text = "Outros Operações"
        Me.optoutros.UseVisualStyleBackColor = True
        '
        'optdevolucao
        '
        Me.optdevolucao.AutoSize = True
        Me.optdevolucao.Location = New System.Drawing.Point(64, 7)
        Me.optdevolucao.Name = "optdevolucao"
        Me.optdevolucao.Size = New System.Drawing.Size(77, 17)
        Me.optdevolucao.TabIndex = 1
        Me.optdevolucao.TabStop = True
        Me.optdevolucao.Text = "Devolução"
        Me.optdevolucao.UseVisualStyleBackColor = True
        '
        'optajuste
        '
        Me.optajuste.AutoSize = True
        Me.optajuste.Location = New System.Drawing.Point(297, 6)
        Me.optajuste.Name = "optajuste"
        Me.optajuste.Size = New System.Drawing.Size(80, 17)
        Me.optajuste.TabIndex = 3
        Me.optajuste.TabStop = True
        Me.optajuste.Text = "NF-e Ajuste"
        Me.optajuste.UseVisualStyleBackColor = True
        '
        'optvenda
        '
        Me.optvenda.AutoSize = True
        Me.optvenda.Location = New System.Drawing.Point(2, 7)
        Me.optvenda.Name = "optvenda"
        Me.optvenda.Size = New System.Drawing.Size(56, 17)
        Me.optvenda.TabIndex = 0
        Me.optvenda.TabStop = True
        Me.optvenda.Text = "Venda"
        Me.optvenda.UseVisualStyleBackColor = True
        '
        'optcomplemento
        '
        Me.optcomplemento.AutoSize = True
        Me.optcomplemento.Location = New System.Drawing.Point(147, 7)
        Me.optcomplemento.Name = "optcomplemento"
        Me.optcomplemento.Size = New System.Drawing.Size(144, 17)
        Me.optcomplemento.TabIndex = 2
        Me.optcomplemento.TabStop = True
        Me.optcomplemento.Text = "NF-e Complemento ICMS"
        Me.optcomplemento.UseVisualStyleBackColor = True
        '
        'chktrib
        '
        Me.chktrib.AutoSize = True
        Me.chktrib.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chktrib.Location = New System.Drawing.Point(338, 29)
        Me.chktrib.Name = "chktrib"
        Me.chktrib.Size = New System.Drawing.Size(156, 17)
        Me.chktrib.TabIndex = 7
        Me.chktrib.TabStop = False
        Me.chktrib.Text = "Calcular Valor aprox.Tributo"
        Me.chktrib.UseVisualStyleBackColor = False
        '
        'txtnat
        '
        Me.txtnat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnat.Location = New System.Drawing.Point(64, 24)
        Me.txtnat.MaxLength = 60
        Me.txtnat.Name = "txtnat"
        Me.txtnat.Size = New System.Drawing.Size(445, 20)
        Me.txtnat.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(61, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Descrição Natureza"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.cbocfop_f2)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cbocfop_f1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(352, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(146, 66)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CFOP Fora Estado"
        '
        'cbocfop_f2
        '
        Me.cbocfop_f2.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cbocfop_f2.ArrowColor = System.Drawing.Color.Black
        Me.cbocfop_f2.BindedControl = Nothing
        Me.cbocfop_f2.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cbocfop_f2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cbocfop_f2.ColumnNum = 2
        Me.cbocfop_f2.ColumnWidth = "40;360"
        Me.cbocfop_f2.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cbocfop_f2.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cbocfop_f2.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cbocfop_f2.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cbocfop_f2.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cbocfop_f2.DisplayMember = "Text"
        Me.cbocfop_f2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbocfop_f2.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cbocfop_f2.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cbocfop_f2.DropDownForeColor = System.Drawing.Color.Black
        Me.cbocfop_f2.DropDownHeight = 110
        Me.cbocfop_f2.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cbocfop_f2.DropDownWidth = 420
        Me.cbocfop_f2.GridLineColor = System.Drawing.Color.Blue
        Me.cbocfop_f2.GridLineHorizontal = True
        Me.cbocfop_f2.GridLineVertical = True
        Me.cbocfop_f2.HighlightBorderColor = System.Drawing.Color.Blue
        Me.cbocfop_f2.HighlightBorderOnMouseEvents = True
        Me.cbocfop_f2.IntegralHeight = False
        Me.cbocfop_f2.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cbocfop_f2.Location = New System.Drawing.Point(84, 36)
        Me.cbocfop_f2.ManagingFastMouseMoving = True
        Me.cbocfop_f2.ManagingFastMouseMovingInterval = 30
        Me.cbocfop_f2.Name = "cbocfop_f2"
        Me.cbocfop_f2.NormalBorderColor = System.Drawing.Color.Black
        Me.cbocfop_f2.SelectedItem = Nothing
        Me.cbocfop_f2.SelectedValue = Nothing
        Me.cbocfop_f2.Size = New System.Drawing.Size(57, 21)
        Me.cbocfop_f2.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "ICMS"
        '
        'cbocfop_f1
        '
        Me.cbocfop_f1.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cbocfop_f1.ArrowColor = System.Drawing.Color.Black
        Me.cbocfop_f1.BindedControl = Nothing
        Me.cbocfop_f1.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cbocfop_f1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cbocfop_f1.ColumnNum = 2
        Me.cbocfop_f1.ColumnWidth = "40;360"
        Me.cbocfop_f1.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cbocfop_f1.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cbocfop_f1.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cbocfop_f1.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cbocfop_f1.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cbocfop_f1.DisplayMember = "Text"
        Me.cbocfop_f1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbocfop_f1.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cbocfop_f1.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cbocfop_f1.DropDownForeColor = System.Drawing.Color.Black
        Me.cbocfop_f1.DropDownHeight = 110
        Me.cbocfop_f1.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cbocfop_f1.DropDownWidth = 420
        Me.cbocfop_f1.GridLineColor = System.Drawing.Color.Blue
        Me.cbocfop_f1.GridLineHorizontal = True
        Me.cbocfop_f1.GridLineVertical = True
        Me.cbocfop_f1.HighlightBorderColor = System.Drawing.Color.Blue
        Me.cbocfop_f1.HighlightBorderOnMouseEvents = True
        Me.cbocfop_f1.IntegralHeight = False
        Me.cbocfop_f1.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cbocfop_f1.Location = New System.Drawing.Point(9, 36)
        Me.cbocfop_f1.ManagingFastMouseMoving = True
        Me.cbocfop_f1.ManagingFastMouseMovingInterval = 30
        Me.cbocfop_f1.Name = "cbocfop_f1"
        Me.cbocfop_f1.NormalBorderColor = System.Drawing.Color.Black
        Me.cbocfop_f1.SelectedItem = Nothing
        Me.cbocfop_f1.SelectedValue = Nothing
        Me.cbocfop_f1.Size = New System.Drawing.Size(57, 21)
        Me.cbocfop_f1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(81, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "ICMS/ST"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.cbocfop_d2)
        Me.GroupBox1.Controls.Add(Me.cbocfop_d1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(154, 66)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CFOP Dentro Estado"
        '
        'cbocfop_d2
        '
        Me.cbocfop_d2.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cbocfop_d2.ArrowColor = System.Drawing.Color.Black
        Me.cbocfop_d2.BindedControl = Nothing
        Me.cbocfop_d2.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cbocfop_d2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cbocfop_d2.ColumnNum = 2
        Me.cbocfop_d2.ColumnWidth = "40;360"
        Me.cbocfop_d2.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cbocfop_d2.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cbocfop_d2.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cbocfop_d2.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cbocfop_d2.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cbocfop_d2.DisplayMember = "Text"
        Me.cbocfop_d2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbocfop_d2.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cbocfop_d2.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cbocfop_d2.DropDownForeColor = System.Drawing.Color.Black
        Me.cbocfop_d2.DropDownHeight = 110
        Me.cbocfop_d2.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cbocfop_d2.DropDownWidth = 420
        Me.cbocfop_d2.GridLineColor = System.Drawing.Color.Blue
        Me.cbocfop_d2.GridLineHorizontal = True
        Me.cbocfop_d2.GridLineVertical = True
        Me.cbocfop_d2.HighlightBorderColor = System.Drawing.Color.Blue
        Me.cbocfop_d2.HighlightBorderOnMouseEvents = True
        Me.cbocfop_d2.IntegralHeight = False
        Me.cbocfop_d2.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cbocfop_d2.Location = New System.Drawing.Point(90, 36)
        Me.cbocfop_d2.ManagingFastMouseMoving = True
        Me.cbocfop_d2.ManagingFastMouseMovingInterval = 30
        Me.cbocfop_d2.Name = "cbocfop_d2"
        Me.cbocfop_d2.NormalBorderColor = System.Drawing.Color.Black
        Me.cbocfop_d2.SelectedItem = Nothing
        Me.cbocfop_d2.SelectedValue = Nothing
        Me.cbocfop_d2.Size = New System.Drawing.Size(57, 21)
        Me.cbocfop_d2.TabIndex = 1
        '
        'cbocfop_d1
        '
        Me.cbocfop_d1.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cbocfop_d1.ArrowColor = System.Drawing.Color.Black
        Me.cbocfop_d1.BindedControl = Nothing
        Me.cbocfop_d1.BorderStyle = MTGCComboBox.TipiBordi.FlatXP
        Me.cbocfop_d1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cbocfop_d1.ColumnNum = 2
        Me.cbocfop_d1.ColumnWidth = "40;360"
        Me.cbocfop_d1.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cbocfop_d1.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cbocfop_d1.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cbocfop_d1.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cbocfop_d1.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cbocfop_d1.DisplayMember = "Text"
        Me.cbocfop_d1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbocfop_d1.DropDownArrowBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cbocfop_d1.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cbocfop_d1.DropDownForeColor = System.Drawing.Color.Black
        Me.cbocfop_d1.DropDownHeight = 110
        Me.cbocfop_d1.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cbocfop_d1.DropDownWidth = 420
        Me.cbocfop_d1.GridLineColor = System.Drawing.Color.Blue
        Me.cbocfop_d1.GridLineHorizontal = True
        Me.cbocfop_d1.GridLineVertical = True
        Me.cbocfop_d1.HighlightBorderColor = System.Drawing.Color.Blue
        Me.cbocfop_d1.HighlightBorderOnMouseEvents = True
        Me.cbocfop_d1.IntegralHeight = False
        Me.cbocfop_d1.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cbocfop_d1.Location = New System.Drawing.Point(10, 36)
        Me.cbocfop_d1.ManagingFastMouseMoving = True
        Me.cbocfop_d1.ManagingFastMouseMovingInterval = 30
        Me.cbocfop_d1.Name = "cbocfop_d1"
        Me.cbocfop_d1.NormalBorderColor = System.Drawing.Color.Black
        Me.cbocfop_d1.SelectedItem = Nothing
        Me.cbocfop_d1.SelectedValue = Nothing
        Me.cbocfop_d1.Size = New System.Drawing.Size(57, 21)
        Me.cbocfop_d1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(87, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "ICMS/ST"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ICMS"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dgvnat)
        Me.Panel2.Location = New System.Drawing.Point(2, 253)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(517, 185)
        Me.Panel2.TabIndex = 1
        '
        'dgvnat
        '
        Me.dgvnat.AllowUserToAddRows = False
        Me.dgvnat.AllowUserToDeleteRows = False
        Me.dgvnat.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvnat.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvnat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvnat.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvnat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvnat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.desc, Me.tipo, Me.cod})
        Me.dgvnat.EnableHeadersVisualStyles = False
        Me.dgvnat.GridColor = System.Drawing.Color.Blue
        Me.dgvnat.Location = New System.Drawing.Point(3, 3)
        Me.dgvnat.Name = "dgvnat"
        Me.dgvnat.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvnat.RowHeadersVisible = False
        Me.dgvnat.Size = New System.Drawing.Size(509, 178)
        Me.dgvnat.TabIndex = 0
        '
        'desc
        '
        Me.desc.HeaderText = "Descricao Operacao"
        Me.desc.Name = "desc"
        Me.desc.Width = 350
        '
        'tipo
        '
        Me.tipo.HeaderText = "Tipo Natureza"
        Me.tipo.Name = "tipo"
        Me.tipo.Width = 136
        '
        'cod
        '
        Me.cod.HeaderText = "cod"
        Me.cod.Name = "cod"
        Me.cod.Visible = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Controls.Add(Me.GroupBox2)
        Me.Panel4.Enabled = False
        Me.Panel4.Location = New System.Drawing.Point(6, 181)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(513, 70)
        Me.Panel4.TabIndex = 1
        '
        'btnSair
        '
        Me.btnSair.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSair.Image = CType(resources.GetObject("btnSair.Image"), System.Drawing.Image)
        Me.btnSair.Location = New System.Drawing.Point(373, 4)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(85, 60)
        Me.btnSair.TabIndex = 5
        Me.btnSair.UseVisualStyleBackColor = False
        '
        'btnExcluir
        '
        Me.btnExcluir.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcluir.Image = CType(resources.GetObject("btnExcluir.Image"), System.Drawing.Image)
        Me.btnExcluir.Location = New System.Drawing.Point(274, 4)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(93, 60)
        Me.btnExcluir.TabIndex = 4
        Me.btnExcluir.UseVisualStyleBackColor = False
        '
        'btnSalvar
        '
        Me.btnSalvar.AllowDrop = True
        Me.btnSalvar.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSalvar.Image = CType(resources.GetObject("btnSalvar.Image"), System.Drawing.Image)
        Me.btnSalvar.Location = New System.Drawing.Point(175, 4)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(93, 60)
        Me.btnSalvar.TabIndex = 2
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalvar.UseVisualStyleBackColor = False
        '
        'btnNovo
        '
        Me.btnNovo.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnNovo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNovo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen
        Me.btnNovo.Image = CType(resources.GetObject("btnNovo.Image"), System.Drawing.Image)
        Me.btnNovo.Location = New System.Drawing.Point(76, 4)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(93, 60)
        Me.btnNovo.TabIndex = 3
        Me.btnNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNovo.UseVisualStyleBackColor = False
        '
        'frmnat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 437)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.btnSair)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.btnNovo)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmnat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Natureza Operação"
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        Me.Panel3.ResumeLayout(false)
        Me.Panel3.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.Panel2.ResumeLayout(false)
        CType(Me.dgvnat,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel4.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtnat As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cbocfop_f2 As MTGCComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbocfop_f1 As MTGCComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbocfop_d2 As MTGCComboBox
    Friend WithEvents cbocfop_d1 As MTGCComboBox
    Friend WithEvents dgvnat As System.Windows.Forms.DataGridView
    Friend WithEvents chktrib As System.Windows.Forms.CheckBox
    Friend WithEvents btnSair As System.Windows.Forms.Button
    Friend WithEvents btnExcluir As System.Windows.Forms.Button
    Friend WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents btnNovo As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents optvenda As System.Windows.Forms.RadioButton
    Friend WithEvents optdevolucao As System.Windows.Forms.RadioButton
    Friend WithEvents optoutros As System.Windows.Forms.RadioButton
    Friend WithEvents optajuste As System.Windows.Forms.RadioButton
    Friend WithEvents optcomplemento As System.Windows.Forms.RadioButton
    Friend WithEvents optbonificacao As System.Windows.Forms.RadioButton
    Friend WithEvents optcupom As System.Windows.Forms.RadioButton
    Friend WithEvents desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chksaida As System.Windows.Forms.CheckBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents txtcod As System.Windows.Forms.TextBox
    Friend WithEvents optentrada As System.Windows.Forms.RadioButton
End Class
