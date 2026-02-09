<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmoperador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmoperador))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnSair = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnNovo = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvop = New System.Windows.Forms.DataGridView()
        Me.cod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtsenha = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtcod = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.chkcancitem = New System.Windows.Forms.CheckBox()
        Me.chkentop = New System.Windows.Forms.CheckBox()
        Me.chksaidaop = New System.Windows.Forms.CheckBox()
        Me.txtnome = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkativo = New System.Windows.Forms.CheckBox()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSair
        '
        Me.btnSair.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSair.Image = CType(resources.GetObject("btnSair.Image"), System.Drawing.Image)
        Me.btnSair.Location = New System.Drawing.Point(374, 3)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(85, 60)
        Me.btnSair.TabIndex = 11
        Me.btnSair.UseVisualStyleBackColor = False
        '
        'btnExcluir
        '
        Me.btnExcluir.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcluir.Image = CType(resources.GetObject("btnExcluir.Image"), System.Drawing.Image)
        Me.btnExcluir.Location = New System.Drawing.Point(255, 3)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(93, 60)
        Me.btnExcluir.TabIndex = 10
        Me.btnExcluir.UseVisualStyleBackColor = False
        '
        'btnSalvar
        '
        Me.btnSalvar.AllowDrop = True
        Me.btnSalvar.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSalvar.Image = CType(resources.GetObject("btnSalvar.Image"), System.Drawing.Image)
        Me.btnSalvar.Location = New System.Drawing.Point(143, 3)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(93, 60)
        Me.btnSalvar.TabIndex = 8
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalvar.UseVisualStyleBackColor = False
        '
        'btnNovo
        '
        Me.btnNovo.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnNovo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNovo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen
        Me.btnNovo.Image = CType(resources.GetObject("btnNovo.Image"), System.Drawing.Image)
        Me.btnNovo.Location = New System.Drawing.Point(31, 3)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(93, 60)
        Me.btnNovo.TabIndex = 9
        Me.btnNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNovo.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dgvop)
        Me.Panel2.Location = New System.Drawing.Point(3, 180)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(482, 185)
        Me.Panel2.TabIndex = 7
        '
        'dgvop
        '
        Me.dgvop.AllowUserToAddRows = False
        Me.dgvop.AllowUserToDeleteRows = False
        Me.dgvop.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvop.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvop.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvop.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvop.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cod, Me.desc})
        Me.dgvop.EnableHeadersVisualStyles = False
        Me.dgvop.GridColor = System.Drawing.Color.Blue
        Me.dgvop.Location = New System.Drawing.Point(3, 3)
        Me.dgvop.Name = "dgvop"
        Me.dgvop.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvop.RowHeadersVisible = False
        Me.dgvop.Size = New System.Drawing.Size(474, 178)
        Me.dgvop.TabIndex = 0
        '
        'cod
        '
        Me.cod.HeaderText = "Código"
        Me.cod.Name = "cod"
        '
        'desc
        '
        Me.desc.HeaderText = "Nome Operador"
        Me.desc.Name = "desc"
        Me.desc.Width = 350
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.chkativo)
        Me.Panel1.Controls.Add(Me.txtsenha)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtcod)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.txtnome)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(3, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(482, 110)
        Me.Panel1.TabIndex = 6
        '
        'txtsenha
        '
        Me.txtsenha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtsenha.Location = New System.Drawing.Point(359, 24)
        Me.txtsenha.MaxLength = 60
        Me.txtsenha.Name = "txtsenha"
        Me.txtsenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtsenha.Size = New System.Drawing.Size(118, 20)
        Me.txtsenha.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(356, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Senha"
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
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.chkcancitem)
        Me.Panel4.Controls.Add(Me.chkentop)
        Me.Panel4.Controls.Add(Me.chksaidaop)
        Me.Panel4.Location = New System.Drawing.Point(3, 50)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(474, 54)
        Me.Panel4.TabIndex = 2
        '
        'chkcancitem
        '
        Me.chkcancitem.AutoSize = True
        Me.chkcancitem.Location = New System.Drawing.Point(235, 7)
        Me.chkcancitem.Name = "chkcancitem"
        Me.chkcancitem.Size = New System.Drawing.Size(88, 17)
        Me.chkcancitem.TabIndex = 2
        Me.chkcancitem.Text = "Cancela Item"
        Me.chkcancitem.UseVisualStyleBackColor = True
        '
        'chkentop
        '
        Me.chkentop.AutoSize = True
        Me.chkentop.Location = New System.Drawing.Point(109, 7)
        Me.chkentop.Name = "chkentop"
        Me.chkentop.Size = New System.Drawing.Size(110, 17)
        Me.chkentop.TabIndex = 1
        Me.chkentop.Text = "Entrada Operador"
        Me.chkentop.UseVisualStyleBackColor = True
        '
        'chksaidaop
        '
        Me.chksaidaop.AutoSize = True
        Me.chksaidaop.Location = New System.Drawing.Point(3, 7)
        Me.chksaidaop.Name = "chksaidaop"
        Me.chksaidaop.Size = New System.Drawing.Size(100, 17)
        Me.chksaidaop.TabIndex = 0
        Me.chksaidaop.Text = "Saida Operador"
        Me.chksaidaop.UseVisualStyleBackColor = True
        '
        'txtnome
        '
        Me.txtnome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnome.Location = New System.Drawing.Point(64, 24)
        Me.txtnome.MaxLength = 60
        Me.txtnome.Name = "txtnome"
        Me.txtnome.Size = New System.Drawing.Size(280, 20)
        Me.txtnome.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(61, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nome operador"
        '
        'chkativo
        '
        Me.chkativo.AutoSize = True
        Me.chkativo.Checked = True
        Me.chkativo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkativo.Location = New System.Drawing.Point(294, 6)
        Me.chkativo.Name = "chkativo"
        Me.chkativo.Size = New System.Drawing.Size(50, 17)
        Me.chkativo.TabIndex = 3
        Me.chkativo.Text = "Ativo"
        Me.chkativo.UseVisualStyleBackColor = True
        '
        'frmoperador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 366)
        Me.Controls.Add(Me.btnSair)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.btnNovo)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.Name = "frmoperador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro Operador PDV"
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSair As System.Windows.Forms.Button
    Friend WithEvents btnExcluir As System.Windows.Forms.Button
    Friend WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents btnNovo As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvop As System.Windows.Forms.DataGridView
    Friend WithEvents cod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtsenha As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtcod As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents chkcancitem As System.Windows.Forms.CheckBox
    Friend WithEvents chkentop As System.Windows.Forms.CheckBox
    Friend WithEvents chksaidaop As System.Windows.Forms.CheckBox
    Friend WithEvents txtnome As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkativo As System.Windows.Forms.CheckBox
End Class
