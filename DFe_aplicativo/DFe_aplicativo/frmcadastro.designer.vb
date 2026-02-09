<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcadastro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmcadastro))
        Me.pcad = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cbouf = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lbltimer = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtultimadata = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtdatabaixa = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.mskdatacad = New System.Windows.Forms.MaskedTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtregime = New System.Windows.Forms.TextBox()
        Me.txtobriganfe = New System.Windows.Forms.TextBox()
        Me.txtcit = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtuf = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtbairro = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtcodmunicipio = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtie = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.mskcep = New System.Windows.Forms.MaskedTextBox()
        Me.mskcnpjre = New System.Windows.Forms.MaskedTextBox()
        Me.txtcidade = New System.Windows.Forms.TextBox()
        Me.txtnumero = New System.Windows.Forms.TextBox()
        Me.txtend = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtnomefan = New System.Windows.Forms.TextBox()
        Me.txtnome = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboweb = New System.Windows.Forms.ComboBox()
        Me.mskcnpj = New System.Windows.Forms.MaskedTextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.bntconsultacad = New System.Windows.Forms.Button()
        Me.tcad = New System.Windows.Forms.Timer(Me.components)
        Me.pcad.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pcad
        '
        Me.pcad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcad.Controls.Add(Me.Label21)
        Me.pcad.Controls.Add(Me.cbouf)
        Me.pcad.Controls.Add(Me.Label19)
        Me.pcad.Controls.Add(Me.lbltimer)
        Me.pcad.Controls.Add(Me.Panel1)
        Me.pcad.Controls.Add(Me.Label11)
        Me.pcad.Controls.Add(Me.txtuf)
        Me.pcad.Controls.Add(Me.Label10)
        Me.pcad.Controls.Add(Me.txtbairro)
        Me.pcad.Controls.Add(Me.Label9)
        Me.pcad.Controls.Add(Me.txtcodmunicipio)
        Me.pcad.Controls.Add(Me.Label8)
        Me.pcad.Controls.Add(Me.Label7)
        Me.pcad.Controls.Add(Me.txtie)
        Me.pcad.Controls.Add(Me.Label6)
        Me.pcad.Controls.Add(Me.Label5)
        Me.pcad.Controls.Add(Me.Label4)
        Me.pcad.Controls.Add(Me.Label3)
        Me.pcad.Controls.Add(Me.mskcep)
        Me.pcad.Controls.Add(Me.mskcnpjre)
        Me.pcad.Controls.Add(Me.txtcidade)
        Me.pcad.Controls.Add(Me.txtnumero)
        Me.pcad.Controls.Add(Me.txtend)
        Me.pcad.Controls.Add(Me.Label2)
        Me.pcad.Controls.Add(Me.Label1)
        Me.pcad.Controls.Add(Me.txtnomefan)
        Me.pcad.Controls.Add(Me.txtnome)
        Me.pcad.Location = New System.Drawing.Point(3, 46)
        Me.pcad.Name = "pcad"
        Me.pcad.Size = New System.Drawing.Size(596, 283)
        Me.pcad.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(478, 6)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(51, 13)
        Me.Label21.TabIndex = 42
        Me.Label21.Text = "UF Sefaz"
        Me.Label21.Visible = False
        '
        'cbouf
        '
        Me.cbouf.FormattingEnabled = True
        Me.cbouf.Items.AddRange(New Object() {"AC", "RN", "PB", "SC"})
        Me.cbouf.Location = New System.Drawing.Point(533, 3)
        Me.cbouf.Name = "cbouf"
        Me.cbouf.Size = New System.Drawing.Size(48, 21)
        Me.cbouf.TabIndex = 42
        Me.cbouf.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(220, 1)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(165, 16)
        Me.Label19.TabIndex = 40
        Me.Label19.Text = "Resultado da Consulta"
        '
        'lbltimer
        '
        Me.lbltimer.AutoSize = True
        Me.lbltimer.Location = New System.Drawing.Point(467, 152)
        Me.lbltimer.Name = "lbltimer"
        Me.lbltimer.Size = New System.Drawing.Size(13, 13)
        Me.lbltimer.TabIndex = 39
        Me.lbltimer.Text = "0"
        Me.lbltimer.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.txtultimadata)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.txtdatabaixa)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.mskdatacad)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtregime)
        Me.Panel1.Controls.Add(Me.txtobriganfe)
        Me.Panel1.Controls.Add(Me.txtcit)
        Me.Panel1.Location = New System.Drawing.Point(6, 178)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(575, 98)
        Me.Panel1.TabIndex = 22
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(340, 48)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(97, 13)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "Ultima Modificação"
        '
        'txtultimadata
        '
        Me.txtultimadata.Location = New System.Drawing.Point(343, 64)
        Me.txtultimadata.Name = "txtultimadata"
        Me.txtultimadata.Size = New System.Drawing.Size(110, 20)
        Me.txtultimadata.TabIndex = 31
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(467, 48)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 13)
        Me.Label16.TabIndex = 30
        Me.Label16.Text = "Data da Baixa"
        '
        'txtdatabaixa
        '
        Me.txtdatabaixa.Location = New System.Drawing.Point(470, 64)
        Me.txtdatabaixa.Name = "txtdatabaixa"
        Me.txtdatabaixa.Size = New System.Drawing.Size(100, 20)
        Me.txtdatabaixa.TabIndex = 29
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(340, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(108, 13)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Situação da Empresa"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(467, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(90, 13)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Data do Cadastro"
        '
        'mskdatacad
        '
        Me.mskdatacad.Location = New System.Drawing.Point(470, 25)
        Me.mskdatacad.Name = "mskdatacad"
        Me.mskdatacad.Size = New System.Drawing.Size(100, 20)
        Me.mskdatacad.TabIndex = 23
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(165, 13)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Obrigatóriedade de Emissão NF-e"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Regime Tributário"
        '
        'txtregime
        '
        Me.txtregime.Location = New System.Drawing.Point(3, 25)
        Me.txtregime.Name = "txtregime"
        Me.txtregime.Size = New System.Drawing.Size(323, 20)
        Me.txtregime.TabIndex = 25
        '
        'txtobriganfe
        '
        Me.txtobriganfe.Location = New System.Drawing.Point(3, 64)
        Me.txtobriganfe.Name = "txtobriganfe"
        Me.txtobriganfe.Size = New System.Drawing.Size(323, 20)
        Me.txtobriganfe.TabIndex = 24
        '
        'txtcit
        '
        Me.txtcit.Location = New System.Drawing.Point(343, 25)
        Me.txtcit.Name = "txtcit"
        Me.txtcit.Size = New System.Drawing.Size(110, 20)
        Me.txtcit.TabIndex = 23
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(262, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(21, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "UF"
        '
        'txtuf
        '
        Me.txtuf.AccessibleDescription = resources.GetString("txtuf.AccessibleDescription")
        Me.txtuf.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtuf.Location = New System.Drawing.Point(264, 72)
        Me.txtuf.Name = "txtuf"
        Me.txtuf.ReadOnly = True
        Me.txtuf.Size = New System.Drawing.Size(35, 20)
        Me.txtuf.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 136)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Bairro"
        '
        'txtbairro
        '
        Me.txtbairro.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtbairro.Location = New System.Drawing.Point(6, 152)
        Me.txtbairro.Name = "txtbairro"
        Me.txtbairro.ReadOnly = True
        Me.txtbairro.Size = New System.Drawing.Size(231, 20)
        Me.txtbairro.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(350, 136)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Código Municipio"
        '
        'txtcodmunicipio
        '
        Me.txtcodmunicipio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtcodmunicipio.Location = New System.Drawing.Point(350, 152)
        Me.txtcodmunicipio.Name = "txtcodmunicipio"
        Me.txtcodmunicipio.ReadOnly = True
        Me.txtcodmunicipio.Size = New System.Drawing.Size(88, 20)
        Me.txtcodmunicipio.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(350, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Cidade"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(122, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Insc. Estadual"
        '
        'txtie
        '
        Me.txtie.AccessibleDescription = resources.GetString("txtie.AccessibleDescription")
        Me.txtie.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtie.Location = New System.Drawing.Point(125, 72)
        Me.txtie.Name = "txtie"
        Me.txtie.ReadOnly = True
        Me.txtie.Size = New System.Drawing.Size(133, 20)
        Me.txtie.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(347, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Número"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Endereço"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(478, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "CEP"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "CNPJ"
        '
        'mskcep
        '
        Me.mskcep.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mskcep.Location = New System.Drawing.Point(481, 113)
        Me.mskcep.Name = "mskcep"
        Me.mskcep.ReadOnly = True
        Me.mskcep.Size = New System.Drawing.Size(100, 20)
        Me.mskcep.TabIndex = 8
        '
        'mskcnpjre
        '
        Me.mskcnpjre.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mskcnpjre.Location = New System.Drawing.Point(6, 72)
        Me.mskcnpjre.Name = "mskcnpjre"
        Me.mskcnpjre.ReadOnly = True
        Me.mskcnpjre.Size = New System.Drawing.Size(113, 20)
        Me.mskcnpjre.TabIndex = 7
        '
        'txtcidade
        '
        Me.txtcidade.AccessibleDescription = resources.GetString("txtcidade.AccessibleDescription")
        Me.txtcidade.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtcidade.Location = New System.Drawing.Point(350, 72)
        Me.txtcidade.Name = "txtcidade"
        Me.txtcidade.ReadOnly = True
        Me.txtcidade.Size = New System.Drawing.Size(231, 20)
        Me.txtcidade.TabIndex = 6
        '
        'txtnumero
        '
        Me.txtnumero.AccessibleDescription = resources.GetString("txtnumero.AccessibleDescription")
        Me.txtnumero.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtnumero.Location = New System.Drawing.Point(350, 113)
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.ReadOnly = True
        Me.txtnumero.Size = New System.Drawing.Size(67, 20)
        Me.txtnumero.TabIndex = 5
        '
        'txtend
        '
        Me.txtend.AccessibleDescription = resources.GetString("txtend.AccessibleDescription")
        Me.txtend.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtend.Location = New System.Drawing.Point(6, 113)
        Me.txtend.Name = "txtend"
        Me.txtend.ReadOnly = True
        Me.txtend.Size = New System.Drawing.Size(338, 20)
        Me.txtend.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(347, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nome Fantasia"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Razão Social"
        '
        'txtnomefan
        '
        Me.txtnomefan.AccessibleDescription = resources.GetString("txtnomefan.AccessibleDescription")
        Me.txtnomefan.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtnomefan.Location = New System.Drawing.Point(350, 33)
        Me.txtnomefan.Name = "txtnomefan"
        Me.txtnomefan.ReadOnly = True
        Me.txtnomefan.Size = New System.Drawing.Size(231, 20)
        Me.txtnomefan.TabIndex = 1
        '
        'txtnome
        '
        Me.txtnome.AccessibleDescription = resources.GetString("txtnome.AccessibleDescription")
        Me.txtnome.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtnome.Location = New System.Drawing.Point(6, 33)
        Me.txtnome.Name = "txtnome"
        Me.txtnome.ReadOnly = True
        Me.txtnome.Size = New System.Drawing.Size(338, 20)
        Me.txtnome.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.cboweb)
        Me.Panel2.Controls.Add(Me.mskcnpj)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.bntconsultacad)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(596, 37)
        Me.Panel2.TabIndex = 2
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(3, 8)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(66, 13)
        Me.Label20.TabIndex = 41
        Me.Label20.Text = "WebService"
        '
        'cboweb
        '
        Me.cboweb.FormattingEnabled = True
        Me.cboweb.Items.AddRange(New Object() {"Sefaz Minas Gerais - (MG)", "Sefaz São Paulo - (SP)", "Sefaz Paraná - (PR)", "Sefaz Rio Grande do Sul - (RS)", "Sefaz Amazonas - (AM)", "Sefaz Bahia - (BA)", "Sefaz Ceará - (CE)", "Sefaz Espírito Santo - (ES)", "Sefaz Goias - (GO)", "Sefaz Mato Grosso - (MT)", "Sefaz Mato Grosso do Sul - (MS)", "Sefaz Pernambuco - (PE)", "Sefaz Maranhão - (MA)", "Sefaz atendidas AC, RN, PB, SC"})
        Me.cboweb.Location = New System.Drawing.Point(71, 5)
        Me.cboweb.Name = "cboweb"
        Me.cboweb.Size = New System.Drawing.Size(197, 21)
        Me.cboweb.TabIndex = 40
        '
        'mskcnpj
        '
        Me.mskcnpj.Location = New System.Drawing.Point(314, 5)
        Me.mskcnpj.Mask = "00,000,000/0000-00"
        Me.mskcnpj.Name = "mskcnpj"
        Me.mskcnpj.Size = New System.Drawing.Size(114, 20)
        Me.mskcnpj.TabIndex = 39
        Me.mskcnpj.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(274, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(34, 13)
        Me.Label18.TabIndex = 38
        Me.Label18.Text = "CNPJ"
        '
        'bntconsultacad
        '
        Me.bntconsultacad.Location = New System.Drawing.Point(438, 5)
        Me.bntconsultacad.Name = "bntconsultacad"
        Me.bntconsultacad.Size = New System.Drawing.Size(153, 23)
        Me.bntconsultacad.TabIndex = 37
        Me.bntconsultacad.Text = "Consulta Cadastro Na Sefaz"
        Me.bntconsultacad.UseVisualStyleBackColor = True
        '
        'tcad
        '
        '
        'frmcadastro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 333)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pcad)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmcadastro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Cadastro do Contribuente Na Sefaz"
        Me.pcad.ResumeLayout(False)
        Me.pcad.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pcad As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtultimadata As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtdatabaixa As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents mskdatacad As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtregime As System.Windows.Forms.TextBox
    Friend WithEvents txtobriganfe As System.Windows.Forms.TextBox
    Friend WithEvents txtcit As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtuf As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtbairro As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtcodmunicipio As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtie As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents mskcep As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskcnpjre As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtcidade As System.Windows.Forms.TextBox
    Friend WithEvents txtnumero As System.Windows.Forms.TextBox
    Friend WithEvents txtend As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtnomefan As System.Windows.Forms.TextBox
    Friend WithEvents txtnome As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents bntconsultacad As System.Windows.Forms.Button
    Friend WithEvents mskcnpj As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboweb As System.Windows.Forms.ComboBox
    Friend WithEvents tcad As System.Windows.Forms.Timer
    Friend WithEvents lbltimer As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cbouf As System.Windows.Forms.ComboBox
End Class
