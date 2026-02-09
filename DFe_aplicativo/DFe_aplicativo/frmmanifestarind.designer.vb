<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmmanifestarind
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmmanifestarind))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.mskcnpj = New System.Windows.Forms.MaskedTextBox()
        Me.lbltimer = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtjust = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtchave = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtcodevento = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtdata = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbomanifestar = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtinfo_manifest = New System.Windows.Forms.TextBox()
        Me.Label145 = New System.Windows.Forms.Label()
        Me.Pic_info = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.Pic_info, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.mskcnpj)
        Me.Panel1.Controls.Add(Me.lbltimer)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtjust)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtchave)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtcodevento)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtdata)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cbomanifestar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(399, 202)
        Me.Panel1.TabIndex = 0
        '
        'mskcnpj
        '
        Me.mskcnpj.Location = New System.Drawing.Point(6, 21)
        Me.mskcnpj.Mask = "00.000.000/0000-00"
        Me.mskcnpj.Name = "mskcnpj"
        Me.mskcnpj.Size = New System.Drawing.Size(114, 20)
        Me.mskcnpj.TabIndex = 14
        Me.mskcnpj.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'lbltimer
        '
        Me.lbltimer.AutoSize = True
        Me.lbltimer.Location = New System.Drawing.Point(194, 108)
        Me.lbltimer.Name = "lbltimer"
        Me.lbltimer.Size = New System.Drawing.Size(13, 13)
        Me.lbltimer.TabIndex = 13
        Me.lbltimer.Text = "0"
        Me.lbltimer.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(235, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Justificativa porque a operação não foi realizada"
        '
        'txtjust
        '
        Me.txtjust.BackColor = System.Drawing.Color.White
        Me.txtjust.Location = New System.Drawing.Point(6, 138)
        Me.txtjust.Multiline = True
        Me.txtjust.Name = "txtjust"
        Me.txtjust.Size = New System.Drawing.Size(385, 58)
        Me.txtjust.TabIndex = 11
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.Blue
        Me.Button1.Location = New System.Drawing.Point(267, 57)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(123, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "&Manifestar NF-e"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Chave de Acesso da NF-e"
        '
        'txtchave
        '
        Me.txtchave.Location = New System.Drawing.Point(6, 99)
        Me.txtchave.Mask = "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000"
        Me.txtchave.Name = "txtchave"
        Me.txtchave.Size = New System.Drawing.Size(385, 20)
        Me.txtchave.TabIndex = 8
        Me.txtchave.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(157, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Código Evento"
        '
        'txtcodevento
        '
        Me.txtcodevento.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtcodevento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcodevento.Location = New System.Drawing.Point(160, 60)
        Me.txtcodevento.Name = "txtcodevento"
        Me.txtcodevento.ReadOnly = True
        Me.txtcodevento.Size = New System.Drawing.Size(74, 20)
        Me.txtcodevento.TabIndex = 6
        Me.txtcodevento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Data e Hora do Evento"
        '
        'txtdata
        '
        Me.txtdata.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtdata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdata.Location = New System.Drawing.Point(6, 60)
        Me.txtdata.Name = "txtdata"
        Me.txtdata.ReadOnly = True
        Me.txtdata.Size = New System.Drawing.Size(120, 20)
        Me.txtdata.TabIndex = 4
        Me.txtdata.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(157, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tipo de Manifestação"
        '
        'cbomanifestar
        '
        Me.cbomanifestar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbomanifestar.FormattingEnabled = True
        Me.cbomanifestar.Items.AddRange(New Object() {"Confirmacao da Operacao", "Ciencia da Operacao", "Desconhecimento da Operacao", "Operacao nao Realizada"})
        Me.cbomanifestar.Location = New System.Drawing.Point(160, 21)
        Me.cbomanifestar.Name = "cbomanifestar"
        Me.cbomanifestar.Size = New System.Drawing.Size(231, 21)
        Me.cbomanifestar.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CNPJ Destinatário"
        '
        'txtinfo_manifest
        '
        Me.txtinfo_manifest.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtinfo_manifest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtinfo_manifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinfo_manifest.Location = New System.Drawing.Point(3, 226)
        Me.txtinfo_manifest.Multiline = True
        Me.txtinfo_manifest.Name = "txtinfo_manifest"
        Me.txtinfo_manifest.ReadOnly = True
        Me.txtinfo_manifest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtinfo_manifest.Size = New System.Drawing.Size(399, 71)
        Me.txtinfo_manifest.TabIndex = 47
        Me.txtinfo_manifest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label145
        '
        Me.Label145.AutoSize = True
        Me.Label145.BackColor = System.Drawing.SystemColors.Control
        Me.Label145.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label145.ForeColor = System.Drawing.Color.Black
        Me.Label145.Location = New System.Drawing.Point(0, 208)
        Me.Label145.Name = "Label145"
        Me.Label145.Size = New System.Drawing.Size(141, 16)
        Me.Label145.TabIndex = 48
        Me.Label145.Text = "Retorno da SEFAZ:"
        '
        'Pic_info
        '
        Me.Pic_info.Image = CType(resources.GetObject("Pic_info.Image"), System.Drawing.Image)
        Me.Pic_info.Location = New System.Drawing.Point(149, 211)
        Me.Pic_info.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Pic_info.Name = "Pic_info"
        Me.Pic_info.Size = New System.Drawing.Size(253, 10)
        Me.Pic_info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_info.TabIndex = 49
        Me.Pic_info.TabStop = False
        Me.Pic_info.Visible = False
        Me.Pic_info.WaitOnLoad = True
        '
        'frmmanifestarind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 302)
        Me.Controls.Add(Me.Pic_info)
        Me.Controls.Add(Me.txtinfo_manifest)
        Me.Controls.Add(Me.Label145)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmmanifestarind"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manifestar NF-e Individualmente"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Pic_info, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbomanifestar As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtdata As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtchave As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtcodevento As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtjust As System.Windows.Forms.TextBox
    Friend WithEvents lbltimer As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtinfo_manifest As System.Windows.Forms.TextBox
    Friend WithEvents Label145 As System.Windows.Forms.Label
    Friend WithEvents Pic_info As System.Windows.Forms.PictureBox
    Friend WithEvents mskcnpj As System.Windows.Forms.MaskedTextBox
End Class
