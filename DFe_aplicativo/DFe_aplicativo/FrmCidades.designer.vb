<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCidades
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCidades))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtfiltro = New System.Windows.Forms.TextBox()
        Me.dgvcidade = New System.Windows.Forms.DataGridView()
        Me.uf_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomeMunic = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomeUF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cod_municipio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coduf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblregistro = New System.Windows.Forms.Label()
        Me.lbltotalregistro = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mskcep = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.dgvcidade, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, -1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nome Cidade:"
        '
        'txtfiltro
        '
        Me.txtfiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtfiltro.Location = New System.Drawing.Point(5, 18)
        Me.txtfiltro.Name = "txtfiltro"
        Me.txtfiltro.Size = New System.Drawing.Size(311, 20)
        Me.txtfiltro.TabIndex = 1
        '
        'dgvcidade
        '
        Me.dgvcidade.AllowUserToAddRows = False
        Me.dgvcidade.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvcidade.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvcidade.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvcidade.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvcidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvcidade.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.uf_grid, Me.NomeMunic, Me.NomeUF, Me.cod_municipio, Me.coduf})
        Me.dgvcidade.EnableHeadersVisualStyles = False
        Me.dgvcidade.GridColor = System.Drawing.Color.SlateGray
        Me.dgvcidade.Location = New System.Drawing.Point(5, 44)
        Me.dgvcidade.Name = "dgvcidade"
        Me.dgvcidade.ReadOnly = True
        Me.dgvcidade.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvcidade.RowHeadersVisible = False
        Me.dgvcidade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvcidade.Size = New System.Drawing.Size(546, 257)
        Me.dgvcidade.TabIndex = 2
        '
        'uf_grid
        '
        Me.uf_grid.HeaderText = "UF"
        Me.uf_grid.Name = "uf_grid"
        Me.uf_grid.ReadOnly = True
        Me.uf_grid.Width = 50
        '
        'NomeMunic
        '
        Me.NomeMunic.HeaderText = "Nome Cidade"
        Me.NomeMunic.Name = "NomeMunic"
        Me.NomeMunic.ReadOnly = True
        Me.NomeMunic.Width = 255
        '
        'NomeUF
        '
        Me.NomeUF.HeaderText = "Nome Estado"
        Me.NomeUF.Name = "NomeUF"
        Me.NomeUF.ReadOnly = True
        Me.NomeUF.Width = 120
        '
        'cod_municipio
        '
        Me.cod_municipio.HeaderText = "Cód. Cidade"
        Me.cod_municipio.Name = "cod_municipio"
        Me.cod_municipio.ReadOnly = True
        '
        'coduf
        '
        Me.coduf.HeaderText = "coduf"
        Me.coduf.Name = "coduf"
        Me.coduf.ReadOnly = True
        Me.coduf.Visible = False
        '
        'lblregistro
        '
        Me.lblregistro.AutoSize = True
        Me.lblregistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblregistro.Location = New System.Drawing.Point(347, 308)
        Me.lblregistro.Name = "lblregistro"
        Me.lblregistro.Size = New System.Drawing.Size(134, 20)
        Me.lblregistro.TabIndex = 3
        Me.lblregistro.Text = "Total Registro(s) :"
        '
        'lbltotalregistro
        '
        Me.lbltotalregistro.AutoSize = True
        Me.lbltotalregistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalregistro.Location = New System.Drawing.Point(487, 308)
        Me.lbltotalregistro.Name = "lbltotalregistro"
        Me.lbltotalregistro.Size = New System.Drawing.Size(57, 20)
        Me.lbltotalregistro.TabIndex = 4
        Me.lbltotalregistro.Text = "Label2"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"11-Rondônia", "12-Acre", "13-Amazonas", "14-Roraima", "15-Pará", "16-Amapá", "17-Tocantins", "21-Maranhão", "22-Piauí", "23-Ceará", "24-Rio Grande do Norte", "25-Paraíba", "26-Pernambuco", "27-Alagoas", "28-Sergipe", "29-Bahia", "31-Minas Gerais", "32-Espírito Santo", "33-Rio de Janeiro", "35-São Paulo", "42-Paraná", "42-Santa Catarina", "43-Rio Grande do Sul", "50-Mato Grosso do Sul", "51-Mato Grosso", "52-Goiás", "53-Distrito Federal"})
        Me.ComboBox1.Location = New System.Drawing.Point(399, 17)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(152, 21)
        Me.ComboBox1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(396, -2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nome Estado (Online)"
        '
        'mskcep
        '
        Me.mskcep.Location = New System.Drawing.Point(324, 18)
        Me.mskcep.Mask = "00-000.000"
        Me.mskcep.Name = "mskcep"
        Me.mskcep.Size = New System.Drawing.Size(69, 20)
        Me.mskcep.TabIndex = 90
        Me.mskcep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(321, 2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 91
        Me.Label9.Text = "CEP"
        '
        'FrmCidades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(556, 328)
        Me.Controls.Add(Me.mskcep)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.lbltotalregistro)
        Me.Controls.Add(Me.lblregistro)
        Me.Controls.Add(Me.dgvcidade)
        Me.Controls.Add(Me.txtfiltro)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCidades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Localizar Cidade"
        CType(Me.dgvcidade, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtfiltro As System.Windows.Forms.TextBox
    Friend WithEvents dgvcidade As System.Windows.Forms.DataGridView
    Friend WithEvents lblregistro As System.Windows.Forms.Label
    Friend WithEvents lbltotalregistro As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents uf_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomeMunic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomeUF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cod_municipio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coduf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mskcep As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
