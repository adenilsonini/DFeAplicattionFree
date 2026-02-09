<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcarta_correcao
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmcarta_correcao))
        Me.txtinfomativo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtdesc = New System.Windows.Forms.TextBox()
        Me.bntexecutar = New System.Windows.Forms.Button()
        Me.mskchave = New System.Windows.Forms.MaskedTextBox()
        Me.pinfo = New System.Windows.Forms.Panel()
        Me.pic_Ico = New System.Windows.Forms.PictureBox()
        Me.txtinfo = New System.Windows.Forms.TextBox()
        Me.txtnsequencia = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblambiente = New System.Windows.Forms.Label()
        Me.txtxml = New System.Windows.Forms.TextBox()
        Me.Picprint = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.mskfone = New System.Windows.Forms.MaskedTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtcidadeuf = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtbairrocep = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtendfor = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtprot_nfe = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtiedest = New System.Windows.Forms.TextBox()
        Me.mskcnpjdest = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtiefor = New System.Windows.Forms.TextBox()
        Me.mskcnpjfor = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtnome = New System.Windows.Forms.TextBox()
        Me.picpdf = New System.Windows.Forms.PictureBox()
        Me.pinfo.SuspendLayout()
        CType(Me.pic_Ico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picprint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.picpdf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtinfomativo
        '
        Me.txtinfomativo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtinfomativo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinfomativo.Location = New System.Drawing.Point(3, 238)
        Me.txtinfomativo.Multiline = True
        Me.txtinfomativo.Name = "txtinfomativo"
        Me.txtinfomativo.ReadOnly = True
        Me.txtinfomativo.Size = New System.Drawing.Size(529, 138)
        Me.txtinfomativo.TabIndex = 5
        Me.txtinfomativo.TabStop = False
        Me.txtinfomativo.Text = resources.GetString("txtinfomativo.Text")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(526, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Correção a ser considerada         (no Minimo 15 e no Maximo 1000 caracter)"
        '
        'txtdesc
        '
        Me.txtdesc.Location = New System.Drawing.Point(3, 28)
        Me.txtdesc.MaxLength = 10000
        Me.txtdesc.Multiline = True
        Me.txtdesc.Name = "txtdesc"
        Me.txtdesc.Size = New System.Drawing.Size(529, 169)
        Me.txtdesc.TabIndex = 0
        '
        'bntexecutar
        '
        Me.bntexecutar.BackColor = System.Drawing.Color.Silver
        Me.bntexecutar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bntexecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bntexecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntexecutar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bntexecutar.Location = New System.Drawing.Point(355, 202)
        Me.bntexecutar.Name = "bntexecutar"
        Me.bntexecutar.Size = New System.Drawing.Size(174, 28)
        Me.bntexecutar.TabIndex = 1
        Me.bntexecutar.Text = "Emitir Carta Correção"
        Me.bntexecutar.UseVisualStyleBackColor = False
        '
        'mskchave
        '
        Me.mskchave.Location = New System.Drawing.Point(3, 203)
        Me.mskchave.Name = "mskchave"
        Me.mskchave.Size = New System.Drawing.Size(138, 20)
        Me.mskchave.TabIndex = 5
        Me.mskchave.Visible = False
        '
        'pinfo
        '
        Me.pinfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pinfo.Controls.Add(Me.pic_Ico)
        Me.pinfo.Controls.Add(Me.txtinfo)
        Me.pinfo.Location = New System.Drawing.Point(88, 42)
        Me.pinfo.Name = "pinfo"
        Me.pinfo.Size = New System.Drawing.Size(353, 77)
        Me.pinfo.TabIndex = 39
        Me.pinfo.Visible = False
        '
        'pic_Ico
        '
        Me.pic_Ico.Image = CType(resources.GetObject("pic_Ico.Image"), System.Drawing.Image)
        Me.pic_Ico.Location = New System.Drawing.Point(3, 60)
        Me.pic_Ico.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pic_Ico.Name = "pic_Ico"
        Me.pic_Ico.Size = New System.Drawing.Size(345, 11)
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
        'txtnsequencia
        '
        Me.txtnsequencia.Location = New System.Drawing.Point(227, 203)
        Me.txtnsequencia.Name = "txtnsequencia"
        Me.txtnsequencia.Size = New System.Drawing.Size(45, 20)
        Me.txtnsequencia.TabIndex = 40
        Me.txtnsequencia.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(118, 204)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 16)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Número Carta"
        Me.Label2.Visible = False
        '
        'lblambiente
        '
        Me.lblambiente.AutoSize = True
        Me.lblambiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblambiente.ForeColor = System.Drawing.Color.Blue
        Me.lblambiente.Location = New System.Drawing.Point(12, 204)
        Me.lblambiente.Name = "lblambiente"
        Me.lblambiente.Size = New System.Drawing.Size(175, 16)
        Me.lblambiente.TabIndex = 42
        Me.lblambiente.Text = "Ambiente Homologação"
        Me.lblambiente.Visible = False
        '
        'txtxml
        '
        Me.txtxml.Location = New System.Drawing.Point(366, 153)
        Me.txtxml.Name = "txtxml"
        Me.txtxml.Size = New System.Drawing.Size(100, 20)
        Me.txtxml.TabIndex = 46
        Me.txtxml.Visible = False
        '
        'Picprint
        '
        Me.Picprint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Picprint.Image = Global.DFe_aplicativo.My.Resources.Resources.impressao
        Me.Picprint.Location = New System.Drawing.Point(278, 197)
        Me.Picprint.Name = "Picprint"
        Me.Picprint.Size = New System.Drawing.Size(37, 31)
        Me.Picprint.TabIndex = 47
        Me.Picprint.TabStop = False
        Me.Picprint.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtnome)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.txtemail)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.mskfone)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.txtcidadeuf)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.txtbairrocep)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.txtendfor)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.TextBox1)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.txtprot_nfe)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txtiedest)
        Me.Panel3.Controls.Add(Me.mskcnpjdest)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtiefor)
        Me.Panel3.Controls.Add(Me.mskcnpjfor)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Location = New System.Drawing.Point(0, 181)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(509, 16)
        Me.Panel3.TabIndex = 49
        Me.Panel3.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(594, 50)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 13)
        Me.Label14.TabIndex = 57
        Me.Label14.Text = "Email"
        '
        'txtemail
        '
        Me.txtemail.Location = New System.Drawing.Point(597, 62)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(272, 20)
        Me.txtemail.TabIndex = 56
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(450, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(28, 13)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "fone"
        '
        'mskfone
        '
        Me.mskfone.BackColor = System.Drawing.Color.White
        Me.mskfone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskfone.Location = New System.Drawing.Point(453, 62)
        Me.mskfone.Mask = "(00) 0000-0000"
        Me.mskfone.Name = "mskfone"
        Me.mskfone.ReadOnly = True
        Me.mskfone.Size = New System.Drawing.Size(122, 20)
        Me.mskfone.TabIndex = 54
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(745, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 53
        Me.Label12.Text = "cidade_uf"
        '
        'txtcidadeuf
        '
        Me.txtcidadeuf.Location = New System.Drawing.Point(748, 27)
        Me.txtcidadeuf.Name = "txtcidadeuf"
        Me.txtcidadeuf.Size = New System.Drawing.Size(121, 20)
        Me.txtcidadeuf.TabIndex = 52
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(592, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 13)
        Me.Label11.TabIndex = 51
        Me.Label11.Text = "bairro_cep"
        '
        'txtbairrocep
        '
        Me.txtbairrocep.Location = New System.Drawing.Point(597, 27)
        Me.txtbairrocep.Name = "txtbairrocep"
        Me.txtbairrocep.Size = New System.Drawing.Size(139, 20)
        Me.txtbairrocep.TabIndex = 50
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(450, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 13)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "endereço emitente"
        '
        'txtendfor
        '
        Me.txtendfor.Location = New System.Drawing.Point(452, 27)
        Me.txtendfor.Name = "txtendfor"
        Me.txtendfor.Size = New System.Drawing.Size(139, 20)
        Me.txtendfor.TabIndex = 48
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(280, 47)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Nome emitente"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(283, 62)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(158, 20)
        Me.TextBox1.TabIndex = 46
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(280, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "protocolo nfe"
        '
        'txtprot_nfe
        '
        Me.txtprot_nfe.BackColor = System.Drawing.Color.White
        Me.txtprot_nfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtprot_nfe.Location = New System.Drawing.Point(283, 27)
        Me.txtprot_nfe.Name = "txtprot_nfe"
        Me.txtprot_nfe.ReadOnly = True
        Me.txtprot_nfe.Size = New System.Drawing.Size(125, 20)
        Me.txtprot_nfe.TabIndex = 44
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(143, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "EI dest"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "cnpj dest"
        '
        'txtiedest
        '
        Me.txtiedest.BackColor = System.Drawing.Color.White
        Me.txtiedest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtiedest.Location = New System.Drawing.Point(143, 62)
        Me.txtiedest.Name = "txtiedest"
        Me.txtiedest.ReadOnly = True
        Me.txtiedest.Size = New System.Drawing.Size(125, 20)
        Me.txtiedest.TabIndex = 41
        '
        'mskcnpjdest
        '
        Me.mskcnpjdest.BackColor = System.Drawing.Color.White
        Me.mskcnpjdest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskcnpjdest.Location = New System.Drawing.Point(15, 62)
        Me.mskcnpjdest.Mask = "00,000,000/0000-00"
        Me.mskcnpjdest.Name = "mskcnpjdest"
        Me.mskcnpjdest.ReadOnly = True
        Me.mskcnpjdest.Size = New System.Drawing.Size(122, 20)
        Me.mskcnpjdest.TabIndex = 40
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(143, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "EI emi"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "cnpj emi"
        '
        'txtiefor
        '
        Me.txtiefor.BackColor = System.Drawing.Color.White
        Me.txtiefor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtiefor.Location = New System.Drawing.Point(143, 24)
        Me.txtiefor.Name = "txtiefor"
        Me.txtiefor.ReadOnly = True
        Me.txtiefor.Size = New System.Drawing.Size(125, 20)
        Me.txtiefor.TabIndex = 37
        '
        'mskcnpjfor
        '
        Me.mskcnpjfor.BackColor = System.Drawing.Color.White
        Me.mskcnpjfor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskcnpjfor.Location = New System.Drawing.Point(15, 24)
        Me.mskcnpjfor.Mask = "00,000,000/0000-00"
        Me.mskcnpjfor.Name = "mskcnpjfor"
        Me.mskcnpjfor.ReadOnly = True
        Me.mskcnpjfor.Size = New System.Drawing.Size(122, 20)
        Me.mskcnpjfor.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(343, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Dados carta correção"
        '
        'txtnome
        '
        Me.txtnome.BackColor = System.Drawing.Color.White
        Me.txtnome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnome.Location = New System.Drawing.Point(289, 101)
        Me.txtnome.Name = "txtnome"
        Me.txtnome.ReadOnly = True
        Me.txtnome.Size = New System.Drawing.Size(158, 20)
        Me.txtnome.TabIndex = 58
        '
        'picpdf
        '
        Me.picpdf.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picpdf.Image = Global.DFe_aplicativo.My.Resources.Resources.pdf
        Me.picpdf.Location = New System.Drawing.Point(317, 197)
        Me.picpdf.Name = "picpdf"
        Me.picpdf.Size = New System.Drawing.Size(32, 33)
        Me.picpdf.TabIndex = 50
        Me.picpdf.TabStop = False
        Me.picpdf.Visible = False
        '
        'frmcarta_correcao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 380)
        Me.Controls.Add(Me.picpdf)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Picprint)
        Me.Controls.Add(Me.txtxml)
        Me.Controls.Add(Me.lblambiente)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtnsequencia)
        Me.Controls.Add(Me.pinfo)
        Me.Controls.Add(Me.mskchave)
        Me.Controls.Add(Me.bntexecutar)
        Me.Controls.Add(Me.txtdesc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtinfomativo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmcarta_correcao"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Emição de Carta de Correção da Nota Fiscal"
        Me.pinfo.ResumeLayout(False)
        Me.pinfo.PerformLayout()
        CType(Me.pic_Ico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picprint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.picpdf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtinfomativo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtdesc As System.Windows.Forms.TextBox
    Friend WithEvents bntexecutar As System.Windows.Forms.Button
    Friend WithEvents mskchave As System.Windows.Forms.MaskedTextBox
    Friend WithEvents pinfo As System.Windows.Forms.Panel
    Friend WithEvents txtinfo As System.Windows.Forms.TextBox
    Friend WithEvents txtnsequencia As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pic_Ico As System.Windows.Forms.PictureBox
    Friend WithEvents lblambiente As System.Windows.Forms.Label
    Friend WithEvents txtxml As System.Windows.Forms.TextBox
    Friend WithEvents Picprint As System.Windows.Forms.PictureBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents mskfone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtcidadeuf As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtbairrocep As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtendfor As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtprot_nfe As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtiedest As System.Windows.Forms.TextBox
    Friend WithEvents mskcnpjdest As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtiefor As System.Windows.Forms.TextBox
    Friend WithEvents mskcnpjfor As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnome As System.Windows.Forms.TextBox
    Friend WithEvents picpdf As System.Windows.Forms.PictureBox
End Class
