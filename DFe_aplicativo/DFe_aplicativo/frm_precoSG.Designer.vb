<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_precoSG
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
        Me.dgvproduto = New System.Windows.Forms.DataGridView()
        Me.codforgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codsggrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precoxmlgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precosggrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.diferencagrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.margemgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qtdecxgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.statuscadgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvproduto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvproduto
        '
        Me.dgvproduto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codforgrid, Me.codsggrid, Me.descgrid, Me.precoxmlgrid, Me.precosggrid, Me.diferencagrid, Me.margemgrid, Me.qtdecxgrid, Me.statuscadgrid})
        Me.dgvproduto.Location = New System.Drawing.Point(12, 122)
        Me.dgvproduto.Name = "dgvproduto"
        Me.dgvproduto.RowHeadersWidth = 24
        Me.dgvproduto.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvproduto.Size = New System.Drawing.Size(956, 334)
        Me.dgvproduto.TabIndex = 0
        '
        'codforgrid
        '
        Me.codforgrid.HeaderText = "Cod. For"
        Me.codforgrid.Name = "codforgrid"
        Me.codforgrid.Width = 80
        '
        'codsggrid
        '
        Me.codsggrid.HeaderText = "Cod. SG"
        Me.codsggrid.Name = "codsggrid"
        Me.codsggrid.Width = 60
        '
        'descgrid
        '
        Me.descgrid.HeaderText = "Descrição Produto XML"
        Me.descgrid.Name = "descgrid"
        Me.descgrid.Width = 230
        '
        'precoxmlgrid
        '
        Me.precoxmlgrid.HeaderText = "Preço XML"
        Me.precoxmlgrid.Name = "precoxmlgrid"
        Me.precoxmlgrid.Width = 70
        '
        'precosggrid
        '
        Me.precosggrid.HeaderText = "Preço SG"
        Me.precosggrid.Name = "precosggrid"
        Me.precosggrid.Width = 70
        '
        'diferencagrid
        '
        Me.diferencagrid.HeaderText = "Diferença"
        Me.diferencagrid.Name = "diferencagrid"
        Me.diferencagrid.Width = 70
        '
        'margemgrid
        '
        Me.margemgrid.HeaderText = "Margem %"
        Me.margemgrid.Name = "margemgrid"
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
        Me.statuscadgrid.Width = 200
        '
        'frm_precoSG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 468)
        Me.Controls.Add(Me.dgvproduto)
        Me.Name = "frm_precoSG"
        Me.Text = "frm_precoSG"
        CType(Me.dgvproduto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvproduto As System.Windows.Forms.DataGridView
    Friend WithEvents codforgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codsggrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precoxmlgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precosggrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents diferencagrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents margemgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qtdecxgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents statuscadgrid As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
