<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmbarras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmbarras))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtqtde = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbounidade = New MTGCComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtbarras = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtcod = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvbarras = New System.Windows.Forms.DataGridView()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigo_barras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.un = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qtde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvbarras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.txtqtde)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cbounidade)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.txtbarras)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(317, 51)
        Me.Panel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(168, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Qtde"
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.DFe_aplicativo.My.Resources.Resources.Delete
        Me.Button2.Location = New System.Drawing.Point(267, 21)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(44, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtqtde
        '
        Me.txtqtde.Location = New System.Drawing.Point(171, 23)
        Me.txtqtde.MaxLength = 14
        Me.txtqtde.Name = "txtqtde"
        Me.txtqtde.Size = New System.Drawing.Size(44, 20)
        Me.txtqtde.TabIndex = 3
        Me.txtqtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(119, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "UN"
        '
        'cbounidade
        '
        Me.cbounidade.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cbounidade.ArrowColor = System.Drawing.Color.Black
        Me.cbounidade.BindedControl = CType(resources.GetObject("cbounidade.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cbounidade.BorderStyle = MTGCComboBox.TipiBordi.Fixed3D
        Me.cbounidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cbounidade.ColumnNum = 2
        Me.cbounidade.ColumnWidth = "30;100"
        Me.cbounidade.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cbounidade.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cbounidade.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cbounidade.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cbounidade.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cbounidade.DisplayMember = "Text"
        Me.cbounidade.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbounidade.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cbounidade.DropDownForeColor = System.Drawing.Color.Black
        Me.cbounidade.DropDownHeight = 90
        Me.cbounidade.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cbounidade.DropDownWidth = 130
        Me.cbounidade.GridLineColor = System.Drawing.Color.Blue
        Me.cbounidade.GridLineHorizontal = True
        Me.cbounidade.GridLineVertical = True
        Me.cbounidade.IntegralHeight = False
        Me.cbounidade.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cbounidade.Location = New System.Drawing.Point(119, 23)
        Me.cbounidade.ManagingFastMouseMoving = True
        Me.cbounidade.ManagingFastMouseMovingInterval = 30
        Me.cbounidade.MaxLength = 2
        Me.cbounidade.Name = "cbounidade"
        Me.cbounidade.SelectedItem = Nothing
        Me.cbounidade.SelectedValue = Nothing
        Me.cbounidade.Size = New System.Drawing.Size(46, 21)
        Me.cbounidade.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.DFe_aplicativo.My.Resources.Resources.file
        Me.Button1.Location = New System.Drawing.Point(221, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtbarras
        '
        Me.txtbarras.Location = New System.Drawing.Point(6, 23)
        Me.txtbarras.MaxLength = 14
        Me.txtbarras.Name = "txtbarras"
        Me.txtbarras.Size = New System.Drawing.Size(107, 20)
        Me.txtbarras.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código Barras"
        '
        'txtcod
        '
        Me.txtcod.Location = New System.Drawing.Point(54, 58)
        Me.txtcod.MaxLength = 14
        Me.txtcod.Name = "txtcod"
        Me.txtcod.Size = New System.Drawing.Size(44, 20)
        Me.txtcod.TabIndex = 3
        Me.txtcod.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtcod)
        Me.Panel2.Controls.Add(Me.dgvbarras)
        Me.Panel2.Location = New System.Drawing.Point(3, 58)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(317, 129)
        Me.Panel2.TabIndex = 1
        '
        'dgvbarras
        '
        Me.dgvbarras.AllowUserToAddRows = False
        Me.dgvbarras.AllowUserToDeleteRows = False
        Me.dgvbarras.AllowUserToResizeColumns = False
        Me.dgvbarras.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvbarras.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvbarras.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvbarras.ColumnHeadersHeight = 20
        Me.dgvbarras.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.codigo_barras, Me.un, Me.qtde})
        Me.dgvbarras.EnableHeadersVisualStyles = False
        Me.dgvbarras.GridColor = System.Drawing.Color.Blue
        Me.dgvbarras.Location = New System.Drawing.Point(3, 3)
        Me.dgvbarras.Name = "dgvbarras"
        Me.dgvbarras.ReadOnly = True
        Me.dgvbarras.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvbarras.RowHeadersWidth = 24
        Me.dgvbarras.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvbarras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvbarras.Size = New System.Drawing.Size(308, 121)
        Me.dgvbarras.TabIndex = 0
        '
        'codigo
        '
        Me.codigo.HeaderText = "Código Produto"
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Width = 85
        '
        'codigo_barras
        '
        Me.codigo_barras.HeaderText = "Codigo Barras"
        Me.codigo_barras.Name = "codigo_barras"
        Me.codigo_barras.ReadOnly = True
        Me.codigo_barras.Width = 110
        '
        'un
        '
        Me.un.HeaderText = "UN"
        Me.un.Name = "un"
        Me.un.ReadOnly = True
        Me.un.Width = 30
        '
        'qtde
        '
        Me.qtde.HeaderText = "Qtde"
        Me.qtde.Name = "qtde"
        Me.qtde.ReadOnly = True
        Me.qtde.Width = 40
        '
        'frmbarras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(323, 188)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmbarras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Adicionar Código Barras"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvbarras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvbarras As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtbarras As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcod As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtqtde As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbounidade As MTGCComboBox
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codigo_barras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents un As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qtde As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
