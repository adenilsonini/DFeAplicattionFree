<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcarga
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvcaixa = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.resp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkult = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvcaixa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(3, 181)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(164, 33)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Enviar Carga"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dgvcaixa)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(460, 172)
        Me.Panel1.TabIndex = 2
        '
        'dgvcaixa
        '
        Me.dgvcaixa.AllowUserToAddRows = False
        Me.dgvcaixa.AllowUserToDeleteRows = False
        Me.dgvcaixa.AllowUserToResizeColumns = False
        Me.dgvcaixa.AllowUserToResizeRows = False
        Me.dgvcaixa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvcaixa.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column1, Me.ip, Me.resp})
        Me.dgvcaixa.Location = New System.Drawing.Point(3, 3)
        Me.dgvcaixa.Name = "dgvcaixa"
        Me.dgvcaixa.RowHeadersVisible = False
        Me.dgvcaixa.Size = New System.Drawing.Size(451, 164)
        Me.dgvcaixa.TabIndex = 0
        '
        'Column2
        '
        Me.Column2.HeaderText = ""
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 30
        '
        'Column1
        '
        Me.Column1.HeaderText = "Caixa"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 50
        '
        'ip
        '
        Me.ip.HeaderText = "IP Caixa"
        Me.ip.Name = "ip"
        '
        'resp
        '
        Me.resp.HeaderText = "Status envio"
        Me.resp.Name = "resp"
        Me.resp.Width = 250
        '
        'chkult
        '
        Me.chkult.AutoSize = True
        Me.chkult.Location = New System.Drawing.Point(205, 190)
        Me.chkult.Name = "chkult"
        Me.chkult.Size = New System.Drawing.Size(73, 17)
        Me.chkult.TabIndex = 3
        Me.chkult.Text = "Ult. Carga"
        Me.chkult.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(337, 181)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(126, 33)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Altera IP Caixa"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmcarga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 216)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.chkult)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmcarga"
        Me.Text = "Envio de Carga PDV"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvcaixa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvcaixa As System.Windows.Forms.DataGridView
    Friend WithEvents chkult As System.Windows.Forms.CheckBox
    Friend WithEvents Column2 As DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents ip As DataGridViewTextBoxColumn
    Friend WithEvents resp As DataGridViewTextBoxColumn
    Friend WithEvents Button2 As Button
End Class
