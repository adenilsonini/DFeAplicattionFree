<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frminutilizar_nfe
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frminutilizar_nfe))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblambiente = New System.Windows.Forms.Label()
        Me.pinfo = New System.Windows.Forms.Panel()
        Me.pic_Ico = New System.Windows.Forms.PictureBox()
        Me.txtinfo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtcuf = New System.Windows.Forms.TextBox()
        Me.txtmod = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtmotivo = New System.Windows.Forms.TextBox()
        Me.txtano = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtserie = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtninicial = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtnfinal = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvinut = New System.Windows.Forms.DataGridView()
        Me.numero_Ini = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numero_fin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.serie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Protocolo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xmotivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.pinfo.SuspendLayout()
        CType(Me.pic_Ico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvinut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblambiente)
        Me.Panel1.Controls.Add(Me.pinfo)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtcuf)
        Me.Panel1.Controls.Add(Me.txtmod)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtmotivo)
        Me.Panel1.Controls.Add(Me.txtano)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtserie)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtninicial)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtnfinal)
        Me.Panel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(739, 95)
        Me.Panel1.TabIndex = 0
        '
        'lblambiente
        '
        Me.lblambiente.AutoSize = True
        Me.lblambiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblambiente.ForeColor = System.Drawing.Color.Blue
        Me.lblambiente.Location = New System.Drawing.Point(553, 3)
        Me.lblambiente.Name = "lblambiente"
        Me.lblambiente.Size = New System.Drawing.Size(175, 16)
        Me.lblambiente.TabIndex = 40
        Me.lblambiente.Text = "Ambiente Homologação"
        Me.lblambiente.Visible = False
        '
        'pinfo
        '
        Me.pinfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pinfo.Controls.Add(Me.pic_Ico)
        Me.pinfo.Controls.Add(Me.txtinfo)
        Me.pinfo.Location = New System.Drawing.Point(199, 8)
        Me.pinfo.Name = "pinfo"
        Me.pinfo.Size = New System.Drawing.Size(353, 76)
        Me.pinfo.TabIndex = 39
        Me.pinfo.Visible = False
        '
        'pic_Ico
        '
        Me.pic_Ico.Image = CType(resources.GetObject("pic_Ico.Image"), System.Drawing.Image)
        Me.pic_Ico.Location = New System.Drawing.Point(8, 60)
        Me.pic_Ico.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pic_Ico.Name = "pic_Ico"
        Me.pic_Ico.Size = New System.Drawing.Size(340, 11)
        Me.pic_Ico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_Ico.TabIndex = 43
        Me.pic_Ico.TabStop = False
        Me.pic_Ico.WaitOnLoad = True
        '
        'txtinfo
        '
        Me.txtinfo.AccessibleDescription = resources.GetString("txtinfo.AccessibleDescription")
        Me.txtinfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtinfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinfo.Location = New System.Drawing.Point(3, 3)
        Me.txtinfo.Multiline = True
        Me.txtinfo.Name = "txtinfo"
        Me.txtinfo.ReadOnly = True
        Me.txtinfo.Size = New System.Drawing.Size(345, 52)
        Me.txtinfo.TabIndex = 38
        Me.txtinfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(158, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 16)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "cUF"
        '
        'txtcuf
        '
        Me.txtcuf.BackColor = System.Drawing.Color.White
        Me.txtcuf.Location = New System.Drawing.Point(157, 70)
        Me.txtcuf.Name = "txtcuf"
        Me.txtcuf.ReadOnly = True
        Me.txtcuf.Size = New System.Drawing.Size(33, 20)
        Me.txtcuf.TabIndex = 13
        Me.txtcuf.TabStop = False
        Me.txtcuf.Text = "31"
        Me.txtcuf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtmod
        '
        Me.txtmod.BackColor = System.Drawing.Color.White
        Me.txtmod.Location = New System.Drawing.Point(52, 70)
        Me.txtmod.Name = "txtmod"
        Me.txtmod.ReadOnly = True
        Me.txtmod.Size = New System.Drawing.Size(44, 20)
        Me.txtmod.TabIndex = 12
        Me.txtmod.TabStop = False
        Me.txtmod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(49, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Modelo"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.Image = Global.DFe_aplicativo.My.Resources.Resources.lixeira
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(591, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(141, 66)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Inutilizar NF-e"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(196, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(258, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Motivo Inutilização       (minimo 15 caracter)"
        '
        'txtmotivo
        '
        Me.txtmotivo.Location = New System.Drawing.Point(199, 24)
        Me.txtmotivo.Multiline = True
        Me.txtmotivo.Name = "txtmotivo"
        Me.txtmotivo.Size = New System.Drawing.Size(388, 66)
        Me.txtmotivo.TabIndex = 2
        '
        'txtano
        '
        Me.txtano.BackColor = System.Drawing.Color.White
        Me.txtano.Location = New System.Drawing.Point(105, 70)
        Me.txtano.Name = "txtano"
        Me.txtano.ReadOnly = True
        Me.txtano.Size = New System.Drawing.Size(46, 20)
        Me.txtano.TabIndex = 7
        Me.txtano.TabStop = False
        Me.txtano.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(102, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Ano"
        '
        'txtserie
        '
        Me.txtserie.BackColor = System.Drawing.Color.White
        Me.txtserie.Location = New System.Drawing.Point(6, 70)
        Me.txtserie.Name = "txtserie"
        Me.txtserie.ReadOnly = True
        Me.txtserie.Size = New System.Drawing.Size(40, 20)
        Me.txtserie.TabIndex = 5
        Me.txtserie.TabStop = False
        Me.txtserie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Sério"
        '
        'txtninicial
        '
        Me.txtninicial.Location = New System.Drawing.Point(6, 24)
        Me.txtninicial.MaxLength = 9
        Me.txtninicial.Name = "txtninicial"
        Me.txtninicial.Size = New System.Drawing.Size(88, 20)
        Me.txtninicial.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(102, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Número Final"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Número Inicial"
        '
        'txtnfinal
        '
        Me.txtnfinal.Location = New System.Drawing.Point(105, 24)
        Me.txtnfinal.MaxLength = 9
        Me.txtnfinal.Name = "txtnfinal"
        Me.txtnfinal.Size = New System.Drawing.Size(85, 20)
        Me.txtnfinal.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dgvinut)
        Me.Panel2.Location = New System.Drawing.Point(2, 104)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(739, 303)
        Me.Panel2.TabIndex = 1
        '
        'dgvinut
        '
        Me.dgvinut.AllowUserToAddRows = False
        Me.dgvinut.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvinut.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvinut.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvinut.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvinut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvinut.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.numero_Ini, Me.numero_fin, Me.serie, Me.Protocolo, Me.xmotivo})
        Me.dgvinut.EnableHeadersVisualStyles = False
        Me.dgvinut.GridColor = System.Drawing.Color.Blue
        Me.dgvinut.Location = New System.Drawing.Point(3, 3)
        Me.dgvinut.Name = "dgvinut"
        Me.dgvinut.ReadOnly = True
        Me.dgvinut.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvinut.RowHeadersWidth = 24
        Me.dgvinut.Size = New System.Drawing.Size(731, 295)
        Me.dgvinut.TabIndex = 0
        '
        'numero_Ini
        '
        Me.numero_Ini.HeaderText = "Numero Ini"
        Me.numero_Ini.Name = "numero_Ini"
        Me.numero_Ini.ReadOnly = True
        '
        'numero_fin
        '
        Me.numero_fin.HeaderText = "Numero Fin."
        Me.numero_fin.Name = "numero_fin"
        Me.numero_fin.ReadOnly = True
        '
        'serie
        '
        Me.serie.HeaderText = "Serie"
        Me.serie.Name = "serie"
        Me.serie.ReadOnly = True
        Me.serie.Width = 45
        '
        'Protocolo
        '
        Me.Protocolo.HeaderText = "Protocolo"
        Me.Protocolo.Name = "Protocolo"
        Me.Protocolo.ReadOnly = True
        Me.Protocolo.Width = 130
        '
        'xmotivo
        '
        Me.xmotivo.HeaderText = "Motivo da Inutilizacao"
        Me.xmotivo.Name = "xmotivo"
        Me.xmotivo.ReadOnly = True
        Me.xmotivo.Width = 310
        '
        'frminutilizar_nfe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 410)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frminutilizar_nfe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inutilização de Númeração da NF-e"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pinfo.ResumeLayout(False)
        Me.pinfo.PerformLayout()
        CType(Me.pic_Ico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvinut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtmotivo As System.Windows.Forms.TextBox
    Friend WithEvents txtano As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtserie As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtninicial As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtnfinal As System.Windows.Forms.TextBox
    Friend WithEvents txtmod As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pinfo As System.Windows.Forms.Panel
    Friend WithEvents txtinfo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtcuf As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvinut As System.Windows.Forms.DataGridView
    Friend WithEvents numero_Ini As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numero_fin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents serie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Protocolo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents xmotivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pic_Ico As System.Windows.Forms.PictureBox
    Friend WithEvents lblambiente As System.Windows.Forms.Label
End Class
