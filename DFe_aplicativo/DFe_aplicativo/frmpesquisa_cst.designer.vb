<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmpesquisa_cst
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmpesquisa_cst))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvdados = New System.Windows.Forms.DataGridView()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aliq_pis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aliq_cofins = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtcod = New System.Windows.Forms.TextBox()
        Me.txtdesc = New System.Windows.Forms.TextBox()
        Me.lblcst = New System.Windows.Forms.Label()
        Me.lbldesc = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvdados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dgvdados)
        Me.Panel1.Location = New System.Drawing.Point(2, 47)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(575, 291)
        Me.Panel1.TabIndex = 0
        '
        'dgvdados
        '
        Me.dgvdados.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvdados.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvdados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvdados.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvdados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvdados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.descricao, Me.aliq_pis, Me.aliq_cofins})
        Me.dgvdados.EnableHeadersVisualStyles = False
        Me.dgvdados.GridColor = System.Drawing.Color.Blue
        Me.dgvdados.Location = New System.Drawing.Point(3, 3)
        Me.dgvdados.MultiSelect = False
        Me.dgvdados.Name = "dgvdados"
        Me.dgvdados.ReadOnly = True
        Me.dgvdados.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvdados.RowHeadersVisible = False
        Me.dgvdados.RowHeadersWidth = 24
        Me.dgvdados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvdados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvdados.Size = New System.Drawing.Size(567, 283)
        Me.dgvdados.TabIndex = 0
        '
        'codigo
        '
        Me.codigo.HeaderText = "Codigo"
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Width = 80
        '
        'descricao
        '
        Me.descricao.HeaderText = "Descricao"
        Me.descricao.Name = "descricao"
        Me.descricao.ReadOnly = True
        Me.descricao.Width = 470
        '
        'aliq_pis
        '
        Me.aliq_pis.HeaderText = "aliq_pis"
        Me.aliq_pis.Name = "aliq_pis"
        Me.aliq_pis.ReadOnly = True
        Me.aliq_pis.Visible = False
        '
        'aliq_cofins
        '
        Me.aliq_cofins.HeaderText = "aliq_cofins"
        Me.aliq_cofins.Name = "aliq_cofins"
        Me.aliq_cofins.ReadOnly = True
        Me.aliq_cofins.Visible = False
        '
        'txtcod
        '
        Me.txtcod.Location = New System.Drawing.Point(6, 21)
        Me.txtcod.Name = "txtcod"
        Me.txtcod.Size = New System.Drawing.Size(59, 20)
        Me.txtcod.TabIndex = 1
        '
        'txtdesc
        '
        Me.txtdesc.Location = New System.Drawing.Point(150, 21)
        Me.txtdesc.Name = "txtdesc"
        Me.txtdesc.Size = New System.Drawing.Size(423, 20)
        Me.txtdesc.TabIndex = 2
        '
        'lblcst
        '
        Me.lblcst.AutoSize = True
        Me.lblcst.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcst.Location = New System.Drawing.Point(3, 2)
        Me.lblcst.Name = "lblcst"
        Me.lblcst.Size = New System.Drawing.Size(35, 16)
        Me.lblcst.TabIndex = 3
        Me.lblcst.Text = "CST"
        '
        'lbldesc
        '
        Me.lbldesc.AutoSize = True
        Me.lbldesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldesc.Location = New System.Drawing.Point(147, 2)
        Me.lbldesc.Name = "lbldesc"
        Me.lbldesc.Size = New System.Drawing.Size(70, 16)
        Me.lbldesc.TabIndex = 4
        Me.lbldesc.Text = "Descricao"
        '
        'frmpesquisa_cst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 340)
        Me.Controls.Add(Me.lbldesc)
        Me.Controls.Add(Me.lblcst)
        Me.Controls.Add(Me.txtdesc)
        Me.Controls.Add(Me.txtcod)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmpesquisa_cst"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmpesquisa_cst"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvdados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtcod As System.Windows.Forms.TextBox
    Friend WithEvents txtdesc As System.Windows.Forms.TextBox
    Friend WithEvents lblcst As System.Windows.Forms.Label
    Friend WithEvents lbldesc As System.Windows.Forms.Label
    Friend WithEvents dgvdados As System.Windows.Forms.DataGridView
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aliq_pis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aliq_cofins As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
