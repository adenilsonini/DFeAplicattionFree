<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmcest))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbltotalregistro = New System.Windows.Forms.Label()
        Me.dgvcest = New System.Windows.Forms.DataGridView()
        Me.Cod_cest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ncm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.dgvcest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(583, 359)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Registro(s) Encontrado(s):"
        '
        'lbltotalregistro
        '
        Me.lbltotalregistro.AutoSize = True
        Me.lbltotalregistro.Location = New System.Drawing.Point(718, 359)
        Me.lbltotalregistro.Name = "lbltotalregistro"
        Me.lbltotalregistro.Size = New System.Drawing.Size(39, 13)
        Me.lbltotalregistro.TabIndex = 8
        Me.lbltotalregistro.Text = "Label1"
        '
        'dgvcest
        '
        Me.dgvcest.AllowDrop = True
        Me.dgvcest.AllowUserToAddRows = False
        Me.dgvcest.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvcest.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvcest.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvcest.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvcest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvcest.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cod_cest, Me.ncm, Me.Descricao})
        Me.dgvcest.EnableHeadersVisualStyles = False
        Me.dgvcest.GridColor = System.Drawing.Color.Blue
        Me.dgvcest.Location = New System.Drawing.Point(12, 12)
        Me.dgvcest.Name = "dgvcest"
        Me.dgvcest.ReadOnly = True
        Me.dgvcest.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvcest.RowHeadersVisible = False
        Me.dgvcest.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvcest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvcest.Size = New System.Drawing.Size(745, 330)
        Me.dgvcest.TabIndex = 0
        '
        'Cod_cest
        '
        Me.Cod_cest.HeaderText = "CEST"
        Me.Cod_cest.Name = "Cod_cest"
        Me.Cod_cest.ReadOnly = True
        Me.Cod_cest.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'ncm
        '
        Me.ncm.HeaderText = "NCM"
        Me.ncm.Name = "ncm"
        Me.ncm.ReadOnly = True
        Me.ncm.Width = 120
        '
        'Descricao
        '
        Me.Descricao.HeaderText = "Descrição"
        Me.Descricao.Name = "Descricao"
        Me.Descricao.ReadOnly = True
        Me.Descricao.Width = 500
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.DFe_aplicativo.My.Resources.Resources._002cert
        Me.PictureBox1.Location = New System.Drawing.Point(422, 109)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'frmcest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 388)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbltotalregistro)
        Me.Controls.Add(Me.dgvcest)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmcest"
        Me.Text = "Consulta CEST"
        CType(Me.dgvcest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbltotalregistro As System.Windows.Forms.Label
    Friend WithEvents dgvcest As System.Windows.Forms.DataGridView
    Friend WithEvents Cod_cest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ncm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
