<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogsitevb
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
        Me.dgvlog = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Paneldata = New System.Windows.Forms.Panel()
        Me.lbldataini = New System.Windows.Forms.Label()
        Me.lbldatafim = New System.Windows.Forms.Label()
        Me.mskdatainicial = New System.Windows.Forms.DateTimePicker()
        Me.mskdatafinal = New System.Windows.Forms.DateTimePicker()
        Me.bntpesquisa = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgvlog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Paneldata.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvlog
        '
        Me.dgvlog.AllowUserToAddRows = False
        Me.dgvlog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvlog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.dgvlog.Location = New System.Drawing.Point(6, 57)
        Me.dgvlog.Name = "dgvlog"
        Me.dgvlog.RowHeadersWidth = 24
        Me.dgvlog.Size = New System.Drawing.Size(634, 312)
        Me.dgvlog.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Usuario"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Log Site"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 350
        '
        'Column3
        '
        Me.Column3.HeaderText = "Data Log"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 140
        '
        'Paneldata
        '
        Me.Paneldata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Paneldata.Controls.Add(Me.lbldataini)
        Me.Paneldata.Controls.Add(Me.lbldatafim)
        Me.Paneldata.Controls.Add(Me.mskdatainicial)
        Me.Paneldata.Controls.Add(Me.mskdatafinal)
        Me.Paneldata.Location = New System.Drawing.Point(6, 2)
        Me.Paneldata.Name = "Paneldata"
        Me.Paneldata.Size = New System.Drawing.Size(216, 49)
        Me.Paneldata.TabIndex = 40
        '
        'lbldataini
        '
        Me.lbldataini.AutoSize = True
        Me.lbldataini.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldataini.Location = New System.Drawing.Point(3, 3)
        Me.lbldataini.Name = "lbldataini"
        Me.lbldataini.Size = New System.Drawing.Size(74, 16)
        Me.lbldataini.TabIndex = 37
        Me.lbldataini.Text = "Data Inicial"
        '
        'lbldatafim
        '
        Me.lbldatafim.AutoSize = True
        Me.lbldatafim.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldatafim.Location = New System.Drawing.Point(108, 3)
        Me.lbldatafim.Name = "lbldatafim"
        Me.lbldatafim.Size = New System.Drawing.Size(69, 16)
        Me.lbldatafim.TabIndex = 38
        Me.lbldatafim.Text = "Data Final"
        '
        'mskdatainicial
        '
        Me.mskdatainicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.mskdatainicial.Location = New System.Drawing.Point(6, 22)
        Me.mskdatainicial.Name = "mskdatainicial"
        Me.mskdatainicial.Size = New System.Drawing.Size(99, 20)
        Me.mskdatainicial.TabIndex = 36
        '
        'mskdatafinal
        '
        Me.mskdatafinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.mskdatafinal.Location = New System.Drawing.Point(111, 22)
        Me.mskdatafinal.Name = "mskdatafinal"
        Me.mskdatafinal.Size = New System.Drawing.Size(99, 20)
        Me.mskdatafinal.TabIndex = 35
        '
        'bntpesquisa
        '
        Me.bntpesquisa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bntpesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntpesquisa.ForeColor = System.Drawing.Color.Blue
        Me.bntpesquisa.Location = New System.Drawing.Point(282, 13)
        Me.bntpesquisa.Name = "bntpesquisa"
        Me.bntpesquisa.Size = New System.Drawing.Size(122, 32)
        Me.bntpesquisa.TabIndex = 41
        Me.bntpesquisa.Text = "Pesquisar"
        Me.bntpesquisa.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(509, 25)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 42
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'frmLogsitevb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 373)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.bntpesquisa)
        Me.Controls.Add(Me.Paneldata)
        Me.Controls.Add(Me.dgvlog)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogsitevb"
        Me.Text = "Log do Site"
        CType(Me.dgvlog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Paneldata.ResumeLayout(False)
        Me.Paneldata.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvlog As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Paneldata As System.Windows.Forms.Panel
    Friend WithEvents lbldataini As System.Windows.Forms.Label
    Friend WithEvents lbldatafim As System.Windows.Forms.Label
    Friend WithEvents mskdatainicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents mskdatafinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents bntpesquisa As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
