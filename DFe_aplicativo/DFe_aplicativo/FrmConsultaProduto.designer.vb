<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsultaProduto
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsultaProduto))
        Me.dgvprodutos = New System.Windows.Forms.DataGridView()
        Me.codigo_prod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.desc_prod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.barras_prod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valor_fab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valor_venda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbotipo = New System.Windows.Forms.ComboBox()
        Me.chkprod_inativa = New System.Windows.Forms.CheckBox()
        Me.txtfiltrobarras = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtfiltrodesc = New System.Windows.Forms.TextBox()
        CType(Me.dgvprodutos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvprodutos
        '
        Me.dgvprodutos.AllowUserToAddRows = False
        Me.dgvprodutos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvprodutos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvprodutos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvprodutos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvprodutos.ColumnHeadersHeight = 22
        Me.dgvprodutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvprodutos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo_prod, Me.desc_prod, Me.barras_prod, Me.valor_fab, Me.valor_venda})
        Me.dgvprodutos.EnableHeadersVisualStyles = False
        Me.dgvprodutos.GridColor = System.Drawing.Color.Blue
        Me.dgvprodutos.Location = New System.Drawing.Point(10, 66)
        Me.dgvprodutos.Name = "dgvprodutos"
        Me.dgvprodutos.ReadOnly = True
        Me.dgvprodutos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvprodutos.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvprodutos.RowHeadersWidth = 24
        Me.dgvprodutos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvprodutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvprodutos.Size = New System.Drawing.Size(712, 299)
        Me.dgvprodutos.TabIndex = 0
        '
        'codigo_prod
        '
        Me.codigo_prod.HeaderText = "Código"
        Me.codigo_prod.Name = "codigo_prod"
        Me.codigo_prod.ReadOnly = True
        Me.codigo_prod.Width = 70
        '
        'desc_prod
        '
        Me.desc_prod.HeaderText = "Descrição do Produto"
        Me.desc_prod.Name = "desc_prod"
        Me.desc_prod.ReadOnly = True
        Me.desc_prod.Width = 300
        '
        'barras_prod
        '
        Me.barras_prod.HeaderText = "Código Barras"
        Me.barras_prod.Name = "barras_prod"
        Me.barras_prod.ReadOnly = True
        '
        'valor_fab
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.valor_fab.DefaultCellStyle = DataGridViewCellStyle3
        Me.valor_fab.HeaderText = "Valor Custo"
        Me.valor_fab.Name = "valor_fab"
        Me.valor_fab.ReadOnly = True
        '
        'valor_venda
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.valor_venda.DefaultCellStyle = DataGridViewCellStyle4
        Me.valor_venda.HeaderText = "Valor Venda"
        Me.valor_venda.Name = "valor_venda"
        Me.valor_venda.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.cbotipo)
        Me.GroupBox1.Controls.Add(Me.chkprod_inativa)
        Me.GroupBox1.Controls.Add(Me.txtfiltrobarras)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtfiltrodesc)
        Me.GroupBox1.Location = New System.Drawing.Point(11, -2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(710, 62)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'cbotipo
        '
        Me.cbotipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbotipo.FormattingEnabled = True
        Me.cbotipo.Items.AddRange(New Object() {"Descricao Produto", "Codigo Interno", "NCM", "CEST", "Valor Venda", "Valor Custo"})
        Me.cbotipo.Location = New System.Drawing.Point(6, 13)
        Me.cbotipo.Name = "cbotipo"
        Me.cbotipo.Size = New System.Drawing.Size(174, 21)
        Me.cbotipo.TabIndex = 49
        '
        'chkprod_inativa
        '
        Me.chkprod_inativa.AutoSize = True
        Me.chkprod_inativa.Location = New System.Drawing.Point(216, 15)
        Me.chkprod_inativa.Name = "chkprod_inativa"
        Me.chkprod_inativa.Size = New System.Drawing.Size(107, 17)
        Me.chkprod_inativa.TabIndex = 48
        Me.chkprod_inativa.Text = "Produtos inativos"
        Me.chkprod_inativa.UseVisualStyleBackColor = True
        '
        'txtfiltrobarras
        '
        Me.txtfiltrobarras.Location = New System.Drawing.Point(569, 36)
        Me.txtfiltrobarras.Name = "txtfiltrobarras"
        Me.txtfiltrobarras.Size = New System.Drawing.Size(131, 20)
        Me.txtfiltrobarras.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(566, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Código Barras"
        '
        'txtfiltrodesc
        '
        Me.txtfiltrodesc.Location = New System.Drawing.Point(6, 36)
        Me.txtfiltrodesc.Name = "txtfiltrodesc"
        Me.txtfiltrodesc.Size = New System.Drawing.Size(317, 20)
        Me.txtfiltrodesc.TabIndex = 0
        '
        'FrmConsultaProduto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(733, 374)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvprodutos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConsultaProduto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Produtos"
        CType(Me.dgvprodutos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvprodutos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtfiltrobarras As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtfiltrodesc As System.Windows.Forms.TextBox
    Friend WithEvents chkprod_inativa As System.Windows.Forms.CheckBox
    Friend WithEvents cbotipo As System.Windows.Forms.ComboBox
    Friend WithEvents codigo_prod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desc_prod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents barras_prod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor_fab As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor_venda As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
