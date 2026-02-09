<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_bematech
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_bematech))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DATA_COMP = New System.Windows.Forms.DateTimePicker()
        Me.mskData_venc = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtpdv = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtend = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtvlr_venda = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtlimite = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.mskcpf = New System.Windows.Forms.MaskedTextBox()
        Me.txtcodcli = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtcliente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtconvenio = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtrv = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TXTHORA = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TXTPDV_CAR = New System.Windows.Forms.TextBox()
        Me.txttipo = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.txtidstone = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtdoc = New System.Windows.Forms.TextBox()
        Me.txtaut = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtec = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.mskdata = New System.Windows.Forms.MaskedTextBox()
        Me.txtbandeira = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.lblof = New System.Windows.Forms.Label()
        Me.lblon = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.picon = New System.Windows.Forms.PictureBox()
        Me.picoff = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.picon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picoff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.DATA_COMP)
        Me.Panel1.Controls.Add(Me.mskData_venc)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtpdv)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtend)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtvlr_venda)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtlimite)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.mskcpf)
        Me.Panel1.Controls.Add(Me.txtcodcli)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtcliente)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtconvenio)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtrv)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 87)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(493, 163)
        Me.Panel1.TabIndex = 0
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(196, 163)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 28
        Me.Button3.Text = "impr"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'DATA_COMP
        '
        Me.DATA_COMP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DATA_COMP.Location = New System.Drawing.Point(6, 34)
        Me.DATA_COMP.Name = "DATA_COMP"
        Me.DATA_COMP.Size = New System.Drawing.Size(89, 20)
        Me.DATA_COMP.TabIndex = 27
        '
        'mskData_venc
        '
        Me.mskData_venc.Location = New System.Drawing.Point(6, 138)
        Me.mskData_venc.Mask = "00/00/0000"
        Me.mskData_venc.Name = "mskData_venc"
        Me.mskData_venc.Size = New System.Drawing.Size(92, 20)
        Me.mskData_venc.TabIndex = 26
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(242, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 13)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "PDV"
        '
        'txtpdv
        '
        Me.txtpdv.Location = New System.Drawing.Point(245, 34)
        Me.txtpdv.Name = "txtpdv"
        Me.txtpdv.Size = New System.Drawing.Size(47, 20)
        Me.txtpdv.TabIndex = 24
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(313, 164)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 22
        Me.Button2.Text = "Carregar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(410, 163)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Imprimir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(101, 122)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Endereço"
        '
        'txtend
        '
        Me.txtend.Location = New System.Drawing.Point(104, 138)
        Me.txtend.Name = "txtend"
        Me.txtend.Size = New System.Drawing.Size(381, 20)
        Me.txtend.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 122)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Data Venc."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(405, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Valor Venda"
        '
        'txtvlr_venda
        '
        Me.txtvlr_venda.Location = New System.Drawing.Point(408, 34)
        Me.txtvlr_venda.Name = "txtvlr_venda"
        Me.txtvlr_venda.Size = New System.Drawing.Size(77, 20)
        Me.txtvlr_venda.TabIndex = 14
        Me.txtvlr_venda.Text = "0,00"
        Me.txtvlr_venda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(308, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Valor Limite"
        '
        'txtlimite
        '
        Me.txtlimite.Location = New System.Drawing.Point(311, 34)
        Me.txtlimite.Name = "txtlimite"
        Me.txtlimite.Size = New System.Drawing.Size(77, 20)
        Me.txtlimite.TabIndex = 12
        Me.txtlimite.Text = "0,00"
        Me.txtlimite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(391, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "CNPJ/CPF"
        '
        'mskcpf
        '
        Me.mskcpf.Location = New System.Drawing.Point(394, 90)
        Me.mskcpf.Mask = "000.000.000-00"
        Me.mskcpf.Name = "mskcpf"
        Me.mskcpf.Size = New System.Drawing.Size(91, 20)
        Me.mskcpf.TabIndex = 10
        Me.mskcpf.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtcodcli
        '
        Me.txtcodcli.Location = New System.Drawing.Point(6, 90)
        Me.txtcodcli.Name = "txtcodcli"
        Me.txtcodcli.Size = New System.Drawing.Size(92, 20)
        Me.txtcodcli.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Cod. Cliente"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(102, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Nome Cliente"
        '
        'txtcliente
        '
        Me.txtcliente.Location = New System.Drawing.Point(104, 90)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.Size = New System.Drawing.Size(284, 20)
        Me.txtcliente.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(175, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Convênio"
        '
        'txtconvenio
        '
        Me.txtconvenio.Location = New System.Drawing.Point(178, 34)
        Me.txtconvenio.Name = "txtconvenio"
        Me.txtconvenio.Size = New System.Drawing.Size(61, 20)
        Me.txtconvenio.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(101, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "RV"
        '
        'txtrv
        '
        Me.txtrv.Location = New System.Drawing.Point(104, 34)
        Me.txtrv.Name = "txtrv"
        Me.txtrv.Size = New System.Drawing.Size(63, 20)
        Me.txtrv.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Data Compra"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TXTHORA)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.TXTPDV_CAR)
        Me.Panel2.Controls.Add(Me.txttipo)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.txttotal)
        Me.Panel2.Controls.Add(Me.txtidstone)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.txtdoc)
        Me.Panel2.Controls.Add(Me.txtaut)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.txtec)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.mskdata)
        Me.Panel2.Controls.Add(Me.txtbandeira)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Location = New System.Drawing.Point(11, 256)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(493, 129)
        Me.Panel2.TabIndex = 1
        '
        'TXTHORA
        '
        Me.TXTHORA.Location = New System.Drawing.Point(420, 3)
        Me.TXTHORA.Name = "TXTHORA"
        Me.TXTHORA.Size = New System.Drawing.Size(47, 20)
        Me.TXTHORA.TabIndex = 43
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(438, 70)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(29, 13)
        Me.Label22.TabIndex = 30
        Me.Label22.Text = "PDV"
        '
        'TXTPDV_CAR
        '
        Me.TXTPDV_CAR.Location = New System.Drawing.Point(441, 86)
        Me.TXTPDV_CAR.Name = "TXTPDV_CAR"
        Me.TXTPDV_CAR.Size = New System.Drawing.Size(47, 20)
        Me.TXTPDV_CAR.TabIndex = 29
        '
        'txttipo
        '
        Me.txttipo.Location = New System.Drawing.Point(221, 86)
        Me.txttipo.Name = "txttipo"
        Me.txttipo.Size = New System.Drawing.Size(206, 20)
        Me.txttipo.TabIndex = 42
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(218, 70)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(28, 13)
        Me.Label21.TabIndex = 41
        Me.Label21.Text = "Tipo"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(157, 109)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(202, 13)
        Me.Label20.TabIndex = 40
        Me.Label20.Text = "TRANSACAO APROVADA COM SENHA"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(131, 70)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(31, 13)
        Me.Label19.TabIndex = 39
        Me.Label19.Text = "Total"
        '
        'txttotal
        '
        Me.txttotal.Location = New System.Drawing.Point(134, 86)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(81, 20)
        Me.txttotal.TabIndex = 38
        '
        'txtidstone
        '
        Me.txtidstone.Location = New System.Drawing.Point(11, 86)
        Me.txtidstone.Name = "txtidstone"
        Me.txtidstone.Size = New System.Drawing.Size(112, 20)
        Me.txtidstone.TabIndex = 37
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 70)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 13)
        Me.Label18.TabIndex = 36
        Me.Label18.Text = "Stone Id"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(362, 20)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(27, 13)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "Doc"
        '
        'txtdoc
        '
        Me.txtdoc.Location = New System.Drawing.Point(365, 36)
        Me.txtdoc.Name = "txtdoc"
        Me.txtdoc.Size = New System.Drawing.Size(123, 20)
        Me.txtdoc.TabIndex = 34
        '
        'txtaut
        '
        Me.txtaut.Location = New System.Drawing.Point(298, 36)
        Me.txtaut.Name = "txtaut"
        Me.txtaut.Size = New System.Drawing.Size(61, 20)
        Me.txtaut.TabIndex = 33
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(296, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 13)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Autorizacao"
        '
        'txtec
        '
        Me.txtec.Location = New System.Drawing.Point(213, 36)
        Me.txtec.Name = "txtec"
        Me.txtec.Size = New System.Drawing.Size(79, 20)
        Me.txtec.TabIndex = 31
        Me.txtec.Text = "102397697"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(210, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(21, 13)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "EC"
        '
        'mskdata
        '
        Me.mskdata.Location = New System.Drawing.Point(134, 36)
        Me.mskdata.Mask = "00/00/0000"
        Me.mskdata.Name = "mskdata"
        Me.mskdata.Size = New System.Drawing.Size(70, 20)
        Me.mskdata.TabIndex = 29
        '
        'txtbandeira
        '
        Me.txtbandeira.Location = New System.Drawing.Point(11, 36)
        Me.txtbandeira.Name = "txtbandeira"
        Me.txtbandeira.Size = New System.Drawing.Size(112, 20)
        Me.txtbandeira.TabIndex = 29
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(131, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 13)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Data"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(155, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(149, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "STONE - Via Estabelecimento"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "Bandeira"
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Blue
        Me.Button4.Location = New System.Drawing.Point(258, 22)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(246, 44)
        Me.Button4.TabIndex = 29
        Me.Button4.Text = "Imprimir Ultima Venda"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'lblof
        '
        Me.lblof.AutoSize = True
        Me.lblof.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblof.ForeColor = System.Drawing.Color.Red
        Me.lblof.Location = New System.Drawing.Point(12, 30)
        Me.lblof.Name = "lblof"
        Me.lblof.Size = New System.Drawing.Size(157, 20)
        Me.lblof.TabIndex = 31
        Me.lblof.Text = "Impressora Offline"
        '
        'lblon
        '
        Me.lblon.AutoSize = True
        Me.lblon.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblon.ForeColor = System.Drawing.Color.Green
        Me.lblon.Location = New System.Drawing.Point(15, 30)
        Me.lblon.Name = "lblon"
        Me.lblon.Size = New System.Drawing.Size(155, 20)
        Me.lblon.TabIndex = 33
        Me.lblon.Text = "Impressora Online"
        Me.lblon.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(21, 9)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(91, 13)
        Me.LinkLabel1.TabIndex = 34
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Status Impressora"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Sincronizador Dados OneDrive"
        Me.NotifyIcon1.Visible = True
        '
        'picon
        '
        '  Me.picon.Image = Global.DFe_aplicativo.My.Resources.Resources.icons_online
        Me.picon.Location = New System.Drawing.Point(170, 22)
        Me.picon.Name = "picon"
        Me.picon.Size = New System.Drawing.Size(36, 33)
        Me.picon.TabIndex = 32
        Me.picon.TabStop = False
        Me.picon.Visible = False
        '
        'picoff
        '
        '   Me.picoff.Image = Global.DFe_aplicativo.My.Resources.Resources.off
        Me.picoff.Location = New System.Drawing.Point(170, 22)
        Me.picoff.Name = "picoff"
        Me.picoff.Size = New System.Drawing.Size(29, 33)
        Me.picoff.TabIndex = 30
        Me.picoff.TabStop = False
        '
        'frm_bematech
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 82)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.lblon)
        Me.Controls.Add(Me.picon)
        Me.Controls.Add(Me.lblof)
        Me.Controls.Add(Me.picoff)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frm_bematech"
        Me.Text = "Impressao Venda"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.picon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picoff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtend As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtvlr_venda As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtlimite As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents mskcpf As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtcodcli As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtconvenio As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtrv As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtpdv As System.Windows.Forms.TextBox
    Friend WithEvents mskData_venc As System.Windows.Forms.MaskedTextBox
    Friend WithEvents DATA_COMP As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents txtidstone As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtdoc As System.Windows.Forms.TextBox
    Friend WithEvents txtaut As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtec As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents mskdata As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtbandeira As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txttipo As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TXTPDV_CAR As System.Windows.Forms.TextBox
    Friend WithEvents TXTHORA As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents lblof As System.Windows.Forms.Label
    Friend WithEvents picoff As System.Windows.Forms.PictureBox
    Friend WithEvents lblon As System.Windows.Forms.Label
    Friend WithEvents picon As System.Windows.Forms.PictureBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
End Class
