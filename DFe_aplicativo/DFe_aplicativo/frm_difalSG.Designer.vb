<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_difalSG
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtvalor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtdata = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtnumero = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtnome = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mskcnpj = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mskchave = New System.Windows.Forms.MaskedTextBox()
        Me.dgvproduto = New System.Windows.Forms.DataGridView()
        Me.codforgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codsggrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precoxmlgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precosggrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.preco_SG_venda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.diferencagrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.margemgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qtdecxgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.statuscadgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cnpj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataemissao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valornfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unxml_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlr_unitotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qtdexml = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DivergenviaResolvidaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlterarPreçoSistemaSGToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AtivarProdutoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.datafin = New System.Windows.Forms.DateTimePicker()
        Me.Dataini = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbldescprod = New System.Windows.Forms.Label()
        CType(Me.dgvproduto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(990, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 15)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Valor NFe"
        '
        'txtvalor
        '
        Me.txtvalor.Location = New System.Drawing.Point(993, 27)
        Me.txtvalor.Name = "txtvalor"
        Me.txtvalor.Size = New System.Drawing.Size(86, 20)
        Me.txtvalor.TabIndex = 37
        Me.txtvalor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(893, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 15)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Data Emissão"
        '
        'txtdata
        '
        Me.txtdata.Location = New System.Drawing.Point(896, 27)
        Me.txtdata.Name = "txtdata"
        Me.txtdata.Size = New System.Drawing.Size(93, 20)
        Me.txtdata.TabIndex = 35
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(802, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 15)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Numero NFe"
        '
        'txtnumero
        '
        Me.txtnumero.Location = New System.Drawing.Point(805, 27)
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(85, 20)
        Me.txtnumero.TabIndex = 33
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(430, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 15)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Nome Fornecedor"
        '
        'txtnome
        '
        Me.txtnome.Location = New System.Drawing.Point(433, 27)
        Me.txtnome.Name = "txtnome"
        Me.txtnome.Size = New System.Drawing.Size(366, 20)
        Me.txtnome.TabIndex = 31
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(310, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 15)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "CNPJ Fornecedor"
        '
        'mskcnpj
        '
        Me.mskcnpj.Location = New System.Drawing.Point(315, 27)
        Me.mskcnpj.Name = "mskcnpj"
        Me.mskcnpj.Size = New System.Drawing.Size(116, 20)
        Me.mskcnpj.TabIndex = 29
        Me.mskcnpj.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 15)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Chave acesso NF-e"
        '
        'mskchave
        '
        Me.mskchave.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.mskchave.Location = New System.Drawing.Point(5, 27)
        Me.mskchave.Mask = "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000"
        Me.mskchave.Name = "mskchave"
        Me.mskchave.Size = New System.Drawing.Size(304, 20)
        Me.mskchave.TabIndex = 27
        Me.mskchave.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'dgvproduto
        '
        Me.dgvproduto.AllowUserToAddRows = False
        Me.dgvproduto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvproduto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codforgrid, Me.codsggrid, Me.descgrid, Me.precoxmlgrid, Me.precosggrid, Me.preco_SG_venda, Me.diferencagrid, Me.margemgrid, Me.qtdecxgrid, Me.statuscadgrid, Me.chave, Me.cnpj, Me.nome, Me.dataemissao, Me.valornfe, Me.unxml_grid, Me.vlr_unitotal, Me.qtdexml})
        Me.dgvproduto.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvproduto.EnableHeadersVisualStyles = False
        Me.dgvproduto.GridColor = System.Drawing.Color.Blue
        Me.dgvproduto.Location = New System.Drawing.Point(5, 80)
        Me.dgvproduto.Name = "dgvproduto"
        Me.dgvproduto.RowHeadersWidth = 24
        Me.dgvproduto.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvproduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvproduto.Size = New System.Drawing.Size(1081, 412)
        Me.dgvproduto.TabIndex = 26
        '
        'codforgrid
        '
        Me.codforgrid.HeaderText = "Cod. For"
        Me.codforgrid.Name = "codforgrid"
        Me.codforgrid.ReadOnly = True
        Me.codforgrid.Width = 70
        '
        'codsggrid
        '
        Me.codsggrid.HeaderText = "Cod. SG"
        Me.codsggrid.Name = "codsggrid"
        Me.codsggrid.ReadOnly = True
        Me.codsggrid.Width = 60
        '
        'descgrid
        '
        Me.descgrid.HeaderText = "Descrição Produto XML"
        Me.descgrid.Name = "descgrid"
        Me.descgrid.ReadOnly = True
        Me.descgrid.Width = 255
        '
        'precoxmlgrid
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.precoxmlgrid.DefaultCellStyle = DataGridViewCellStyle1
        Me.precoxmlgrid.HeaderText = "Preço XML"
        Me.precoxmlgrid.Name = "precoxmlgrid"
        Me.precoxmlgrid.ReadOnly = True
        Me.precoxmlgrid.Width = 70
        '
        'precosggrid
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.precosggrid.DefaultCellStyle = DataGridViewCellStyle2
        Me.precosggrid.HeaderText = "Preço SG"
        Me.precosggrid.Name = "precosggrid"
        Me.precosggrid.ReadOnly = True
        Me.precosggrid.Width = 65
        '
        'preco_SG_venda
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.preco_SG_venda.DefaultCellStyle = DataGridViewCellStyle3
        Me.preco_SG_venda.HeaderText = "Preço Venda"
        Me.preco_SG_venda.Name = "preco_SG_venda"
        Me.preco_SG_venda.Width = 80
        '
        'diferencagrid
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.diferencagrid.DefaultCellStyle = DataGridViewCellStyle4
        Me.diferencagrid.HeaderText = "Diferença"
        Me.diferencagrid.Name = "diferencagrid"
        Me.diferencagrid.ReadOnly = True
        Me.diferencagrid.Width = 65
        '
        'margemgrid
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.margemgrid.DefaultCellStyle = DataGridViewCellStyle5
        Me.margemgrid.HeaderText = "Margem %"
        Me.margemgrid.Name = "margemgrid"
        Me.margemgrid.ReadOnly = True
        Me.margemgrid.Width = 70
        '
        'qtdecxgrid
        '
        Me.qtdecxgrid.HeaderText = "Qtde CX"
        Me.qtdecxgrid.Name = "qtdecxgrid"
        Me.qtdecxgrid.Width = 60
        '
        'statuscadgrid
        '
        Me.statuscadgrid.HeaderText = "Status Cadastro"
        Me.statuscadgrid.Name = "statuscadgrid"
        Me.statuscadgrid.ReadOnly = True
        Me.statuscadgrid.Width = 120
        '
        'chave
        '
        Me.chave.HeaderText = "chave"
        Me.chave.Name = "chave"
        Me.chave.Visible = False
        '
        'cnpj
        '
        Me.cnpj.HeaderText = "cnpj"
        Me.cnpj.Name = "cnpj"
        Me.cnpj.Visible = False
        '
        'nome
        '
        Me.nome.HeaderText = "nome"
        Me.nome.Name = "nome"
        Me.nome.Visible = False
        '
        'dataemissao
        '
        Me.dataemissao.HeaderText = "dataemissao"
        Me.dataemissao.Name = "dataemissao"
        Me.dataemissao.Visible = False
        '
        'valornfe
        '
        Me.valornfe.HeaderText = "valornfe"
        Me.valornfe.Name = "valornfe"
        Me.valornfe.Visible = False
        '
        'unxml_grid
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.unxml_grid.DefaultCellStyle = DataGridViewCellStyle6
        Me.unxml_grid.HeaderText = "UN XML"
        Me.unxml_grid.Name = "unxml_grid"
        Me.unxml_grid.Width = 55
        '
        'vlr_unitotal
        '
        Me.vlr_unitotal.HeaderText = "vlr_unitotal"
        Me.vlr_unitotal.Name = "vlr_unitotal"
        Me.vlr_unitotal.Visible = False
        '
        'qtdexml
        '
        Me.qtdexml.HeaderText = "Qtde XML"
        Me.qtdexml.Name = "qtdexml"
        Me.qtdexml.Width = 65
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DivergenviaResolvidaToolStripMenuItem, Me.AlterarPreçoSistemaSGToolStripMenuItem, Me.AtivarProdutoToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(204, 70)
        '
        'DivergenviaResolvidaToolStripMenuItem
        '
        Me.DivergenviaResolvidaToolStripMenuItem.Name = "DivergenviaResolvidaToolStripMenuItem"
        Me.DivergenviaResolvidaToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.DivergenviaResolvidaToolStripMenuItem.Text = "Divergenvia resolvida"
        '
        'AlterarPreçoSistemaSGToolStripMenuItem
        '
        Me.AlterarPreçoSistemaSGToolStripMenuItem.Enabled = False
        Me.AlterarPreçoSistemaSGToolStripMenuItem.Name = "AlterarPreçoSistemaSGToolStripMenuItem"
        Me.AlterarPreçoSistemaSGToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.AlterarPreçoSistemaSGToolStripMenuItem.Text = "Alterar Preço Sistema SG"
        '
        'AtivarProdutoToolStripMenuItem
        '
        Me.AtivarProdutoToolStripMenuItem.Name = "AtivarProdutoToolStripMenuItem"
        Me.AtivarProdutoToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.AtivarProdutoToolStripMenuItem.Text = "Ativar Produto SG"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(460, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 16)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "à"
        '
        'datafin
        '
        Me.datafin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datafin.Location = New System.Drawing.Point(482, 54)
        Me.datafin.Name = "datafin"
        Me.datafin.Size = New System.Drawing.Size(95, 20)
        Me.datafin.TabIndex = 58
        '
        'Dataini
        '
        Me.Dataini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dataini.Location = New System.Drawing.Point(359, 54)
        Me.Dataini.Name = "Dataini"
        Me.Dataini.Size = New System.Drawing.Size(95, 20)
        Me.Dataini.TabIndex = 57
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(241, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 15)
        Me.Label8.TabIndex = 60
        Me.Label8.Text = "Pesquisar entre:"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(583, 53)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 23)
        Me.Button1.TabIndex = 61
        Me.Button1.Text = "Pesquisar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(2, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 15)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "Total Registro grid: "
        '
        'lbldescprod
        '
        Me.lbldescprod.AutoSize = True
        Me.lbldescprod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldescprod.ForeColor = System.Drawing.Color.Blue
        Me.lbldescprod.Location = New System.Drawing.Point(687, 58)
        Me.lbldescprod.Name = "lbldescprod"
        Me.lbldescprod.Size = New System.Drawing.Size(12, 15)
        Me.lbldescprod.TabIndex = 63
        Me.lbldescprod.Text = "-"
        '
        'frm_difalSG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1090, 496)
        Me.Controls.Add(Me.lbldescprod)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.datafin)
        Me.Controls.Add(Me.Dataini)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtvalor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtdata)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtnumero)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtnome)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.mskcnpj)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mskchave)
        Me.Controls.Add(Me.dgvproduto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frm_difalSG"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Divergencia de produtos"
        CType(Me.dgvproduto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtvalor As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtdata As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtnumero As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnome As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents mskcnpj As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mskchave As System.Windows.Forms.MaskedTextBox
    Friend WithEvents dgvproduto As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents datafin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dataini As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DivergenviaResolvidaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlterarPreçoSistemaSGToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AtivarProdutoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents codforgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codsggrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precoxmlgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precosggrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents preco_SG_venda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents diferencagrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents margemgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qtdecxgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents statuscadgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cnpj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dataemissao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valornfe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents unxml_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlr_unitotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qtdexml As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbldescprod As System.Windows.Forms.Label
End Class
