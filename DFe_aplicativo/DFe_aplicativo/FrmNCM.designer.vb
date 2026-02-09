<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNCM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNCM))
        Me.dgvncm = New System.Windows.Forms.DataGridView()
        Me.cod_ncm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cst_pis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblncm = New System.Windows.Forms.Label()
        Me.txtfiltro = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lbltotalregistro = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvncm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvncm
        '
        Me.dgvncm.AllowDrop = True
        Me.dgvncm.AllowUserToAddRows = False
        Me.dgvncm.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvncm.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvncm.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvncm.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvncm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvncm.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cod_ncm, Me.cst_pis})
        Me.dgvncm.EnableHeadersVisualStyles = False
        Me.dgvncm.GridColor = System.Drawing.Color.Blue
        Me.dgvncm.Location = New System.Drawing.Point(15, 32)
        Me.dgvncm.Name = "dgvncm"
        Me.dgvncm.ReadOnly = True
        Me.dgvncm.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvncm.RowHeadersVisible = False
        Me.dgvncm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvncm.Size = New System.Drawing.Size(574, 281)
        Me.dgvncm.TabIndex = 0
        '
        'cod_ncm
        '
        Me.cod_ncm.HeaderText = "NCM"
        Me.cod_ncm.Name = "cod_ncm"
        Me.cod_ncm.ReadOnly = True
        '
        'cst_pis
        '
        Me.cst_pis.HeaderText = "Descricao NCM"
        Me.cst_pis.Name = "cst_pis"
        Me.cst_pis.ReadOnly = True
        Me.cst_pis.Width = 450
        '
        'lblncm
        '
        Me.lblncm.AutoSize = True
        Me.lblncm.Location = New System.Drawing.Point(12, 9)
        Me.lblncm.Name = "lblncm"
        Me.lblncm.Size = New System.Drawing.Size(31, 13)
        Me.lblncm.TabIndex = 1
        Me.lblncm.Text = "NCM"
        '
        'txtfiltro
        '
        Me.txtfiltro.Location = New System.Drawing.Point(49, 6)
        Me.txtfiltro.MaxLength = 8
        Me.txtfiltro.Name = "txtfiltro"
        Me.txtfiltro.Size = New System.Drawing.Size(160, 20)
        Me.txtfiltro.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(216, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Pesquisar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lbltotalregistro
        '
        Me.lbltotalregistro.AutoSize = True
        Me.lbltotalregistro.Location = New System.Drawing.Point(329, 326)
        Me.lbltotalregistro.Name = "lbltotalregistro"
        Me.lbltotalregistro.Size = New System.Drawing.Size(39, 13)
        Me.lbltotalregistro.TabIndex = 5
        Me.lbltotalregistro.Text = "Label1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(184, 326)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Registro(s) Encontrado(s):"
        '
        'FrmNCM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 348)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbltotalregistro)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtfiltro)
        Me.Controls.Add(Me.lblncm)
        Me.Controls.Add(Me.dgvncm)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmNCM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta NCM"
        CType(Me.dgvncm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvncm As System.Windows.Forms.DataGridView
    Friend WithEvents lblncm As System.Windows.Forms.Label
    Friend WithEvents txtfiltro As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lbltotalregistro As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cod_ncm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cst_pis As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
