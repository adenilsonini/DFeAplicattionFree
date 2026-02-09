<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcancelanfe
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmcancelanfe))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bntopen = New System.Windows.Forms.Button()
        Me.chksubstituicao = New System.Windows.Forms.CheckBox()
        Me.mskchave_vinculada = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblambiente = New System.Windows.Forms.Label()
        Me.pinfo = New System.Windows.Forms.Panel()
        Me.pic_Ico = New System.Windows.Forms.PictureBox()
        Me.txtinfo = New System.Windows.Forms.TextBox()
        Me.lbltimer = New System.Windows.Forms.Label()
        Me.bntcancelar = New System.Windows.Forms.Button()
        Me.txtjust = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtprotocolo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mskcnpj = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mskchave = New System.Windows.Forms.MaskedTextBox()
        Me.tconsultanfe = New System.Windows.Forms.Timer(Me.components)
        Me.tenvicacelamento = New System.Windows.Forms.Timer(Me.components)
        Me.txtstatus_canc = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.pinfo.SuspendLayout()
        CType(Me.pic_Ico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.bntopen)
        Me.Panel1.Controls.Add(Me.chksubstituicao)
        Me.Panel1.Controls.Add(Me.mskchave_vinculada)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lblambiente)
        Me.Panel1.Controls.Add(Me.pinfo)
        Me.Panel1.Controls.Add(Me.lbltimer)
        Me.Panel1.Controls.Add(Me.bntcancelar)
        Me.Panel1.Controls.Add(Me.txtjust)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtprotocolo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.mskcnpj)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.mskchave)
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(446, 249)
        Me.Panel1.TabIndex = 0
        '
        'bntopen
        '
        Me.bntopen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bntopen.ForeColor = System.Drawing.Color.Blue
        Me.bntopen.Image = CType(resources.GetObject("bntopen.Image"), System.Drawing.Image)
        Me.bntopen.Location = New System.Drawing.Point(300, 57)
        Me.bntopen.Name = "bntopen"
        Me.bntopen.Size = New System.Drawing.Size(30, 23)
        Me.bntopen.TabIndex = 89
        Me.bntopen.UseVisualStyleBackColor = True
        '
        'chksubstituicao
        '
        Me.chksubstituicao.AutoSize = True
        Me.chksubstituicao.Location = New System.Drawing.Point(133, 79)
        Me.chksubstituicao.Name = "chksubstituicao"
        Me.chksubstituicao.Size = New System.Drawing.Size(171, 17)
        Me.chksubstituicao.TabIndex = 42
        Me.chksubstituicao.Text = "Cancelamento por substituicao"
        Me.chksubstituicao.UseVisualStyleBackColor = True
        Me.chksubstituicao.Visible = False
        '
        'mskchave_vinculada
        '
        Me.mskchave_vinculada.BackColor = System.Drawing.Color.White
        Me.mskchave_vinculada.Location = New System.Drawing.Point(3, 59)
        Me.mskchave_vinculada.Mask = "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000"
        Me.mskchave_vinculada.Name = "mskchave_vinculada"
        Me.mskchave_vinculada.Size = New System.Drawing.Size(301, 20)
        Me.mskchave_vinculada.TabIndex = 41
        Me.mskchave_vinculada.TabStop = False
        Me.mskchave_vinculada.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(3, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(209, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Chave da NFCe autorizada para Vinculada"
        '
        'lblambiente
        '
        Me.lblambiente.AutoSize = True
        Me.lblambiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblambiente.ForeColor = System.Drawing.Color.Blue
        Me.lblambiente.Location = New System.Drawing.Point(134, 220)
        Me.lblambiente.Name = "lblambiente"
        Me.lblambiente.Size = New System.Drawing.Size(175, 16)
        Me.lblambiente.TabIndex = 39
        Me.lblambiente.Text = "Ambiente Homologação"
        Me.lblambiente.Visible = False
        '
        'pinfo
        '
        Me.pinfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pinfo.Controls.Add(Me.pic_Ico)
        Me.pinfo.Controls.Add(Me.txtinfo)
        Me.pinfo.Location = New System.Drawing.Point(40, 98)
        Me.pinfo.Name = "pinfo"
        Me.pinfo.Size = New System.Drawing.Size(353, 79)
        Me.pinfo.TabIndex = 38
        Me.pinfo.Visible = False
        '
        'pic_Ico
        '
        Me.pic_Ico.Image = CType(resources.GetObject("pic_Ico.Image"), System.Drawing.Image)
        Me.pic_Ico.Location = New System.Drawing.Point(3, 60)
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
        'lbltimer
        '
        Me.lbltimer.AutoSize = True
        Me.lbltimer.Location = New System.Drawing.Point(248, 194)
        Me.lbltimer.Name = "lbltimer"
        Me.lbltimer.Size = New System.Drawing.Size(13, 13)
        Me.lbltimer.TabIndex = 9
        Me.lbltimer.Text = "0"
        Me.lbltimer.Visible = False
        '
        'bntcancelar
        '
        Me.bntcancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bntcancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bntcancelar.ForeColor = System.Drawing.Color.Red
        Me.bntcancelar.Location = New System.Drawing.Point(336, 54)
        Me.bntcancelar.Name = "bntcancelar"
        Me.bntcancelar.Size = New System.Drawing.Size(104, 25)
        Me.bntcancelar.TabIndex = 8
        Me.bntcancelar.Text = "&Cancelar NF-e "
        Me.bntcancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bntcancelar.UseVisualStyleBackColor = True
        '
        'txtjust
        '
        Me.txtjust.Location = New System.Drawing.Point(3, 111)
        Me.txtjust.MaxLength = 254
        Me.txtjust.Multiline = True
        Me.txtjust.Name = "txtjust"
        Me.txtjust.Size = New System.Drawing.Size(437, 112)
        Me.txtjust.TabIndex = 7
        Me.txtjust.Text = "NOTA FISCAL EMITIDA INDEVIDAMENTE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(0, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(414, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Justificativa do cancelamento                        (no Minimo 55 e no Maximo 25" & _
    "5 caracter)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(308, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Protocolo da NFe"
        '
        'txtprotocolo
        '
        Me.txtprotocolo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtprotocolo.Location = New System.Drawing.Point(311, 20)
        Me.txtprotocolo.Name = "txtprotocolo"
        Me.txtprotocolo.ReadOnly = True
        Me.txtprotocolo.Size = New System.Drawing.Size(129, 20)
        Me.txtprotocolo.TabIndex = 4
        Me.txtprotocolo.TabStop = False
        Me.txtprotocolo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 219)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "CNPJ do Emitente"
        Me.Label2.Visible = False
        '
        'mskcnpj
        '
        Me.mskcnpj.Location = New System.Drawing.Point(11, 222)
        Me.mskcnpj.Name = "mskcnpj"
        Me.mskcnpj.ReadOnly = True
        Me.mskcnpj.Size = New System.Drawing.Size(117, 20)
        Me.mskcnpj.TabIndex = 2
        Me.mskcnpj.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(0, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Chave de Acesso da NFe"
        '
        'mskchave
        '
        Me.mskchave.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.mskchave.Location = New System.Drawing.Point(3, 20)
        Me.mskchave.Mask = "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000"
        Me.mskchave.Name = "mskchave"
        Me.mskchave.ReadOnly = True
        Me.mskchave.Size = New System.Drawing.Size(301, 20)
        Me.mskchave.TabIndex = 0
        Me.mskchave.TabStop = False
        Me.mskchave.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtstatus_canc
        '
        Me.txtstatus_canc.Location = New System.Drawing.Point(182, 242)
        Me.txtstatus_canc.Name = "txtstatus_canc"
        Me.txtstatus_canc.Size = New System.Drawing.Size(100, 20)
        Me.txtstatus_canc.TabIndex = 1
        Me.txtstatus_canc.Visible = False
        '
        'frmcancelanfe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 257)
        Me.Controls.Add(Me.txtstatus_canc)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmcancelanfe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelar Nota Fiscal Eletronica"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pinfo.ResumeLayout(False)
        Me.pinfo.PerformLayout()
        CType(Me.pic_Ico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents mskcnpj As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mskchave As System.Windows.Forms.MaskedTextBox
    Friend WithEvents bntcancelar As System.Windows.Forms.Button
    Friend WithEvents txtjust As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtprotocolo As System.Windows.Forms.TextBox
    Friend WithEvents tconsultanfe As System.Windows.Forms.Timer
    Friend WithEvents lbltimer As System.Windows.Forms.Label
    Friend WithEvents pinfo As System.Windows.Forms.Panel
    Friend WithEvents txtinfo As System.Windows.Forms.TextBox
    Friend WithEvents tenvicacelamento As System.Windows.Forms.Timer
    Friend WithEvents pic_Ico As System.Windows.Forms.PictureBox
    Friend WithEvents lblambiente As System.Windows.Forms.Label
    Friend WithEvents txtstatus_canc As System.Windows.Forms.TextBox
    Friend WithEvents mskchave_vinculada As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chksubstituicao As System.Windows.Forms.CheckBox
    Friend WithEvents bntopen As System.Windows.Forms.Button
End Class
