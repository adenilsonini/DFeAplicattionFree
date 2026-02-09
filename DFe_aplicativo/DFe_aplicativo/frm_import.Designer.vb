<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_import
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
        Me.dgvimport = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.recibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.data_recibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.recibo_lanc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.obs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nprot_manif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cstat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xmot_manif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.bar1 = New System.Windows.Forms.ProgressBar()
        Me.lblinfo = New System.Windows.Forms.Label()
        Me.dgverro = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.txtcont = New System.Windows.Forms.TextBox()
        Me.dgvsite = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvdi = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dgvimport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgverro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvsite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvdi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvimport
        '
        Me.dgvimport.AllowUserToAddRows = False
        Me.dgvimport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvimport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.recibo, Me.data_recibo, Me.recibo_lanc, Me.obs, Me.nprot_manif, Me.cstat, Me.xmot_manif})
        Me.dgvimport.Location = New System.Drawing.Point(24, 41)
        Me.dgvimport.Name = "dgvimport"
        Me.dgvimport.RowHeadersVisible = False
        Me.dgvimport.Size = New System.Drawing.Size(470, 192)
        Me.dgvimport.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Chave"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 250
        '
        'Column2
        '
        Me.Column2.HeaderText = "xml"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 200
        '
        'recibo
        '
        Me.recibo.HeaderText = "recibo"
        Me.recibo.Name = "recibo"
        Me.recibo.Visible = False
        '
        'data_recibo
        '
        Me.data_recibo.HeaderText = "data_recibo"
        Me.data_recibo.Name = "data_recibo"
        Me.data_recibo.Visible = False
        '
        'recibo_lanc
        '
        Me.recibo_lanc.HeaderText = "recibo_lanc"
        Me.recibo_lanc.Name = "recibo_lanc"
        Me.recibo_lanc.Visible = False
        '
        'obs
        '
        Me.obs.HeaderText = "obs"
        Me.obs.Name = "obs"
        Me.obs.Visible = False
        '
        'nprot_manif
        '
        Me.nprot_manif.HeaderText = "nprot_manif"
        Me.nprot_manif.Name = "nprot_manif"
        Me.nprot_manif.Visible = False
        '
        'cstat
        '
        Me.cstat.HeaderText = "cstat"
        Me.cstat.Name = "cstat"
        Me.cstat.Visible = False
        '
        'xmot_manif
        '
        Me.xmot_manif.HeaderText = "xmot_manif"
        Me.xmot_manif.Name = "xmot_manif"
        Me.xmot_manif.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(24, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Carregar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(408, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(125, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Importar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'bar1
        '
        Me.bar1.Location = New System.Drawing.Point(24, 252)
        Me.bar1.Name = "bar1"
        Me.bar1.Size = New System.Drawing.Size(472, 20)
        Me.bar1.TabIndex = 3
        '
        'lblinfo
        '
        Me.lblinfo.AutoSize = True
        Me.lblinfo.ForeColor = System.Drawing.Color.Blue
        Me.lblinfo.Location = New System.Drawing.Point(21, 236)
        Me.lblinfo.Name = "lblinfo"
        Me.lblinfo.Size = New System.Drawing.Size(13, 13)
        Me.lblinfo.TabIndex = 4
        Me.lblinfo.Text = "0"
        '
        'dgverro
        '
        Me.dgverro.AllowUserToAddRows = False
        Me.dgverro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgverro.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column4})
        Me.dgverro.Location = New System.Drawing.Point(24, 295)
        Me.dgverro.Name = "dgverro"
        Me.dgverro.RowHeadersVisible = False
        Me.dgverro.Size = New System.Drawing.Size(470, 150)
        Me.dgverro.TabIndex = 5
        '
        'Column3
        '
        Me.Column3.HeaderText = "Erro"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 250
        '
        'Column4
        '
        Me.Column4.HeaderText = "chave"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 280
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(272, 279)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(72, 13)
        Me.LinkLabel1.TabIndex = 6
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Visualizar erro"
        '
        'txtcont
        '
        Me.txtcont.Location = New System.Drawing.Point(188, 15)
        Me.txtcont.Name = "txtcont"
        Me.txtcont.Size = New System.Drawing.Size(49, 20)
        Me.txtcont.TabIndex = 7
        '
        'dgvsite
        '
        Me.dgvsite.AllowUserToAddRows = False
        Me.dgvsite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvsite.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9})
        Me.dgvsite.Location = New System.Drawing.Point(502, 41)
        Me.dgvsite.Name = "dgvsite"
        Me.dgvsite.RowHeadersVisible = False
        Me.dgvsite.Size = New System.Drawing.Size(469, 192)
        Me.dgvsite.TabIndex = 8
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Chave"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 250
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "xml"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 200
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "recibo"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "data_recibo"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "recibo_lanc"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "obs"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "nprot_manif"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "cstat"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "xmot_manif"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'dgvdi
        '
        Me.dgvdi.AllowUserToAddRows = False
        Me.dgvdi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvdi.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18})
        Me.dgvdi.Location = New System.Drawing.Point(502, 265)
        Me.dgvdi.Name = "dgvdi"
        Me.dgvdi.RowHeadersVisible = False
        Me.dgvdi.Size = New System.Drawing.Size(469, 180)
        Me.dgvdi.TabIndex = 9
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Chave"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 250
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "xml"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 200
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "recibo"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "data_recibo"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "recibo_lanc"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Visible = False
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "obs"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Visible = False
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "nprot_manif"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Visible = False
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "cstat"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Visible = False
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.HeaderText = "xmot_manif"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(706, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "Conferir"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(642, 237)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Arquivos não localizado no site"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(861, 236)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(110, 23)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "exportar txt"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(153, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Ano:"
        '
        'frm_import
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 456)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.dgvdi)
        Me.Controls.Add(Me.dgvsite)
        Me.Controls.Add(Me.txtcont)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.dgverro)
        Me.Controls.Add(Me.lblinfo)
        Me.Controls.Add(Me.bar1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgvimport)
        Me.Name = "frm_import"
        Me.Text = "frm_import"
        CType(Me.dgvimport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgverro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvsite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvdi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvimport As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents bar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblinfo As System.Windows.Forms.Label
    Friend WithEvents dgverro As System.Windows.Forms.DataGridView
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents recibo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents data_recibo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents recibo_lanc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents obs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nprot_manif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cstat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents xmot_manif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtcont As System.Windows.Forms.TextBox
    Friend WithEvents dgvsite As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvdi As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
