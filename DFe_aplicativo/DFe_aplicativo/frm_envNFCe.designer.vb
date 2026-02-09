<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_envNFCe
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_envNFCe))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.bntenviar_nfce = New System.Windows.Forms.Button()
        Me.Pinfo = New System.Windows.Forms.PictureBox()
        Me.lblstatus = New System.Windows.Forms.Label()
        Me.txtrecibo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtret = New System.Windows.Forms.TextBox()
        Me.mskchave = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bntopen = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtcaminho = New System.Windows.Forms.TextBox()
        Me.dialogo = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1.SuspendLayout()
        CType(Me.Pinfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.bntenviar_nfce)
        Me.Panel1.Controls.Add(Me.Pinfo)
        Me.Panel1.Controls.Add(Me.lblstatus)
        Me.Panel1.Controls.Add(Me.txtrecibo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtret)
        Me.Panel1.Controls.Add(Me.mskchave)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.bntopen)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtcaminho)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(509, 246)
        Me.Panel1.TabIndex = 0
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(179, 85)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(48, 13)
        Me.LinkLabel1.TabIndex = 100
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Consulta"
        '
        'bntenviar_nfce
        '
        Me.bntenviar_nfce.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bntenviar_nfce.ForeColor = System.Drawing.Color.Blue
        Me.bntenviar_nfce.Location = New System.Drawing.Point(386, 55)
        Me.bntenviar_nfce.Name = "bntenviar_nfce"
        Me.bntenviar_nfce.Size = New System.Drawing.Size(117, 23)
        Me.bntenviar_nfce.TabIndex = 99
        Me.bntenviar_nfce.Text = "Enviar NFe/NFCe"
        Me.bntenviar_nfce.UseVisualStyleBackColor = True
        '
        'Pinfo
        '
        Me.Pinfo.BackColor = System.Drawing.Color.Transparent
        Me.Pinfo.Image = CType(resources.GetObject("Pinfo.Image"), System.Drawing.Image)
        Me.Pinfo.Location = New System.Drawing.Point(339, 81)
        Me.Pinfo.Name = "Pinfo"
        Me.Pinfo.Size = New System.Drawing.Size(164, 17)
        Me.Pinfo.TabIndex = 98
        Me.Pinfo.TabStop = False
        Me.Pinfo.Visible = False
        '
        'lblstatus
        '
        Me.lblstatus.AutoSize = True
        Me.lblstatus.Location = New System.Drawing.Point(231, 85)
        Me.lblstatus.Name = "lblstatus"
        Me.lblstatus.Size = New System.Drawing.Size(109, 13)
        Me.lblstatus.TabIndex = 97
        Me.lblstatus.Text = "Enviando, aguarde...."
        Me.lblstatus.Visible = False
        '
        'txtrecibo
        '
        Me.txtrecibo.Location = New System.Drawing.Point(73, 81)
        Me.txtrecibo.Name = "txtrecibo"
        Me.txtrecibo.Size = New System.Drawing.Size(100, 20)
        Me.txtrecibo.TabIndex = 95
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 94
        Me.Label3.Text = "Recibo envio:"
        '
        'txtret
        '
        Me.txtret.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtret.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtret.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtret.Location = New System.Drawing.Point(6, 105)
        Me.txtret.Multiline = True
        Me.txtret.Name = "txtret"
        Me.txtret.ReadOnly = True
        Me.txtret.Size = New System.Drawing.Size(497, 131)
        Me.txtret.TabIndex = 93
        '
        'mskchave
        '
        Me.mskchave.Location = New System.Drawing.Point(3, 57)
        Me.mskchave.Name = "mskchave"
        Me.mskchave.Size = New System.Drawing.Size(337, 20)
        Me.mskchave.TabIndex = 91
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "Chave NFCe"
        '
        'bntopen
        '
        Me.bntopen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bntopen.ForeColor = System.Drawing.Color.Blue
        Me.bntopen.Image = CType(resources.GetObject("bntopen.Image"), System.Drawing.Image)
        Me.bntopen.Location = New System.Drawing.Point(474, 17)
        Me.bntopen.Name = "bntopen"
        Me.bntopen.Size = New System.Drawing.Size(30, 23)
        Me.bntopen.TabIndex = 89
        Me.bntopen.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Caminho XML NFCe Envio"
        '
        'txtcaminho
        '
        Me.txtcaminho.Location = New System.Drawing.Point(3, 18)
        Me.txtcaminho.Name = "txtcaminho"
        Me.txtcaminho.Size = New System.Drawing.Size(472, 20)
        Me.txtcaminho.TabIndex = 0
        '
        'frm_envNFCe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 261)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_envNFCe"
        Me.Text = "Tela de Envio de NF-e/NFC-e"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Pinfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcaminho As System.Windows.Forms.TextBox
    Friend WithEvents txtrecibo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtret As System.Windows.Forms.TextBox
    Friend WithEvents mskchave As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents bntopen As System.Windows.Forms.Button
    Friend WithEvents lblstatus As System.Windows.Forms.Label
    Friend WithEvents Pinfo As System.Windows.Forms.PictureBox
    Friend WithEvents bntenviar_nfce As System.Windows.Forms.Button
    Friend WithEvents dialogo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
End Class
