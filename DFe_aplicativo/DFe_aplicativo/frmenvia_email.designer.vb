<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmenvia_email
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmenvia_email))
        Me.optsped = New System.Windows.Forms.RadioButton()
        Me.txtDestino = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txttitle = New System.Windows.Forms.TextBox()
        Me.btnlimpar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnImagem = New System.Windows.Forms.Button()
        Me.txtImagemLogo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtsenha = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnProcurar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lstAnexos = New System.Windows.Forms.ListBox()
        Me.optsintegra = New System.Windows.Forms.RadioButton()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtmensagem = New System.Windows.Forms.TextBox()
        Me.opttodos = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.optxml = New System.Windows.Forms.RadioButton()
        Me.txtusuario = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtassunto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LstItems = New System.Windows.Forms.ListBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtdest02 = New System.Windows.Forms.TextBox()
        Me.pinfo = New System.Windows.Forms.Panel()
        Me.txtinfo = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pinfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'optsped
        '
        Me.optsped.AutoSize = True
        Me.optsped.Location = New System.Drawing.Point(294, 38)
        Me.optsped.Name = "optsped"
        Me.optsped.Size = New System.Drawing.Size(154, 17)
        Me.optsped.TabIndex = 50
        Me.optsped.TabStop = True
        Me.optsped.Text = "Enviar SPED Contribuições"
        Me.optsped.UseVisualStyleBackColor = True
        '
        'txtDestino
        '
        Me.txtDestino.FormattingEnabled = True
        Me.txtDestino.Location = New System.Drawing.Point(106, 9)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Size = New System.Drawing.Size(452, 21)
        Me.txtDestino.TabIndex = 48
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(103, 184)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(183, 13)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Mensagem que será Enviada Abaixo:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(28, 36)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 16)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "Empresa :"
        '
        'txttitle
        '
        Me.txttitle.Location = New System.Drawing.Point(106, 32)
        Me.txttitle.Name = "txttitle"
        Me.txttitle.Size = New System.Drawing.Size(452, 20)
        Me.txttitle.TabIndex = 45
        '
        'btnlimpar
        '
        Me.btnlimpar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnlimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlimpar.Location = New System.Drawing.Point(258, 404)
        Me.btnlimpar.Name = "btnlimpar"
        Me.btnlimpar.Size = New System.Drawing.Size(115, 29)
        Me.btnlimpar.TabIndex = 44
        Me.btnlimpar.Text = "&Limpar"
        Me.btnlimpar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Red
        Me.Button1.Location = New System.Drawing.Point(433, 404)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 28)
        Me.Button1.TabIndex = 43
        Me.Button1.Text = "&Sair"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnImagem
        '
        Me.btnImagem.Location = New System.Drawing.Point(481, 133)
        Me.btnImagem.Name = "btnImagem"
        Me.btnImagem.Size = New System.Drawing.Size(77, 22)
        Me.btnImagem.TabIndex = 42
        Me.btnImagem.Text = "Imagem"
        Me.btnImagem.UseVisualStyleBackColor = True
        Me.btnImagem.Visible = False
        '
        'txtImagemLogo
        '
        Me.txtImagemLogo.Location = New System.Drawing.Point(106, 135)
        Me.txtImagemLogo.Name = "txtImagemLogo"
        Me.txtImagemLogo.Size = New System.Drawing.Size(369, 20)
        Me.txtImagemLogo.TabIndex = 41
        Me.txtImagemLogo.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(304, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "Senha:"
        '
        'txtsenha
        '
        Me.txtsenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsenha.Location = New System.Drawing.Point(360, 9)
        Me.txtsenha.Name = "txtsenha"
        Me.txtsenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtsenha.ReadOnly = True
        Me.txtsenha.Size = New System.Drawing.Size(115, 20)
        Me.txtsenha.TabIndex = 46
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "E-mail:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(59, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 16)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Logo:"
        Me.Label5.Visible = False
        '
        'btnProcurar
        '
        Me.btnProcurar.Location = New System.Drawing.Point(481, 86)
        Me.btnProcurar.Name = "btnProcurar"
        Me.btnProcurar.Size = New System.Drawing.Size(77, 43)
        Me.btnProcurar.TabIndex = 39
        Me.btnProcurar.Text = "Procurar"
        Me.btnProcurar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(39, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 16)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Anexos :"
        '
        'lstAnexos
        '
        Me.lstAnexos.FormattingEnabled = True
        Me.lstAnexos.Location = New System.Drawing.Point(106, 86)
        Me.lstAnexos.Name = "lstAnexos"
        Me.lstAnexos.Size = New System.Drawing.Size(369, 43)
        Me.lstAnexos.TabIndex = 37
        '
        'optsintegra
        '
        Me.optsintegra.AutoSize = True
        Me.optsintegra.Location = New System.Drawing.Point(178, 38)
        Me.optsintegra.Name = "optsintegra"
        Me.optsintegra.Size = New System.Drawing.Size(97, 17)
        Me.optsintegra.TabIndex = 49
        Me.optsintegra.TabStop = True
        Me.optsintegra.Text = "Enviar Sintegra"
        Me.optsintegra.UseVisualStyleBackColor = True
        '
        'btnEnviar
        '
        Me.btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnviar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviar.ForeColor = System.Drawing.Color.Green
        Me.btnEnviar.Location = New System.Drawing.Point(106, 403)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(119, 29)
        Me.btnEnviar.TabIndex = 36
        Me.btnEnviar.Text = "Enviar Email"
        Me.ToolTip1.SetToolTip(Me.btnEnviar, "Clique para enviar o e-mail")
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'txtmensagem
        '
        Me.txtmensagem.Location = New System.Drawing.Point(106, 200)
        Me.txtmensagem.Multiline = True
        Me.txtmensagem.Name = "txtmensagem"
        Me.txtmensagem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtmensagem.Size = New System.Drawing.Size(449, 197)
        Me.txtmensagem.TabIndex = 35
        '
        'opttodos
        '
        Me.opttodos.AutoSize = True
        Me.opttodos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.opttodos.Location = New System.Drawing.Point(79, 38)
        Me.opttodos.Name = "opttodos"
        Me.opttodos.Size = New System.Drawing.Size(95, 17)
        Me.opttodos.TabIndex = 52
        Me.opttodos.Text = "E-mail diversos"
        Me.opttodos.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.opttodos)
        Me.Panel2.Controls.Add(Me.optxml)
        Me.Panel2.Controls.Add(Me.optsped)
        Me.Panel2.Controls.Add(Me.optsintegra)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtsenha)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txtusuario)
        Me.Panel2.Location = New System.Drawing.Point(311, 223)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(144, 11)
        Me.Panel2.TabIndex = 3
        Me.Panel2.Visible = False
        '
        'optxml
        '
        Me.optxml.AutoSize = True
        Me.optxml.Checked = True
        Me.optxml.Location = New System.Drawing.Point(466, 38)
        Me.optxml.Name = "optxml"
        Me.optxml.Size = New System.Drawing.Size(80, 17)
        Me.optxml.TabIndex = 51
        Me.optxml.TabStop = True
        Me.optxml.Text = "Enviar XML"
        Me.optxml.UseVisualStyleBackColor = True
        '
        'txtusuario
        '
        Me.txtusuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtusuario.Location = New System.Drawing.Point(79, 9)
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.ReadOnly = True
        Me.txtusuario.Size = New System.Drawing.Size(219, 20)
        Me.txtusuario.TabIndex = 45
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(35, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 16)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Assunto :"
        '
        'txtassunto
        '
        Me.txtassunto.Location = New System.Drawing.Point(106, 58)
        Me.txtassunto.Name = "txtassunto"
        Me.txtassunto.Size = New System.Drawing.Size(452, 20)
        Me.txtassunto.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Destinatário:"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.LstItems)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtdest02)
        Me.Panel1.Controls.Add(Me.pinfo)
        Me.Panel1.Controls.Add(Me.txtDestino)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txttitle)
        Me.Panel1.Controls.Add(Me.btnlimpar)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnImagem)
        Me.Panel1.Controls.Add(Me.txtImagemLogo)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.btnProcurar)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lstAnexos)
        Me.Panel1.Controls.Add(Me.btnEnviar)
        Me.Panel1.Controls.Add(Me.txtmensagem)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtassunto)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(573, 442)
        Me.Panel1.TabIndex = 2
        '
        'LstItems
        '
        Me.LstItems.FormattingEnabled = True
        Me.LstItems.Location = New System.Drawing.Point(177, 247)
        Me.LstItems.Name = "LstItems"
        Me.LstItems.Size = New System.Drawing.Size(120, 95)
        Me.LstItems.TabIndex = 51
        Me.LstItems.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 137)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 16)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "Destinatário2"
        '
        'txtdest02
        '
        Me.txtdest02.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtdest02.Location = New System.Drawing.Point(106, 136)
        Me.txtdest02.Name = "txtdest02"
        Me.txtdest02.Size = New System.Drawing.Size(369, 20)
        Me.txtdest02.TabIndex = 49
        '
        'pinfo
        '
        Me.pinfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pinfo.Controls.Add(Me.txtinfo)
        Me.pinfo.Location = New System.Drawing.Point(136, 32)
        Me.pinfo.Name = "pinfo"
        Me.pinfo.Size = New System.Drawing.Size(353, 60)
        Me.pinfo.TabIndex = 40
        Me.pinfo.Visible = False
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
        'Timer1
        '
        Me.Timer1.Interval = 2000
        '
        'frmenvia_email
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 443)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmenvia_email"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tela de envio do DANFE e XML da NF-e"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pinfo.ResumeLayout(False)
        Me.pinfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents optsped As System.Windows.Forms.RadioButton
    Friend WithEvents txtDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txttitle As System.Windows.Forms.TextBox
    Friend WithEvents btnlimpar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnImagem As System.Windows.Forms.Button
    Friend WithEvents txtImagemLogo As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtsenha As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnProcurar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lstAnexos As System.Windows.Forms.ListBox
    Friend WithEvents optsintegra As System.Windows.Forms.RadioButton
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents txtmensagem As System.Windows.Forms.TextBox
    Friend WithEvents opttodos As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents optxml As System.Windows.Forms.RadioButton
    Friend WithEvents txtusuario As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtassunto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents pinfo As System.Windows.Forms.Panel
    Friend WithEvents txtinfo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtdest02 As System.Windows.Forms.TextBox
    Friend WithEvents LstItems As System.Windows.Forms.ListBox
End Class
