<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmprincipal
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblnetinfo = New System.Windows.Forms.Label()
        Me.Pic_conexao = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.lblversaomy = New System.Windows.Forms.Label()
        Me.lbldatas = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Button10 = New System.Windows.Forms.Button()
        CType(Me.Pic_conexao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Blue
        Me.Button1.Location = New System.Drawing.Point(12, 33)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(235, 41)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "DFe"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Red
        Me.Button2.Location = New System.Drawing.Point(383, 33)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(235, 41)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Visualizar XML"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(236, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nova Versão Sistema 10-06-2022"
        '
        'lblnetinfo
        '
        Me.lblnetinfo.AutoSize = True
        Me.lblnetinfo.BackColor = System.Drawing.Color.Transparent
        Me.lblnetinfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnetinfo.ForeColor = System.Drawing.Color.White
        Me.lblnetinfo.Location = New System.Drawing.Point(380, 10)
        Me.lblnetinfo.Name = "lblnetinfo"
        Me.lblnetinfo.Size = New System.Drawing.Size(204, 16)
        Me.lblnetinfo.TabIndex = 4
        Me.lblnetinfo.Text = "Versão NET Framework  PC:"
        '
        'Pic_conexao
        '
        Me.Pic_conexao.Image = Global.DFe_aplicativo.My.Resources.Resources._on
        Me.Pic_conexao.Location = New System.Drawing.Point(292, 68)
        Me.Pic_conexao.Name = "Pic_conexao"
        Me.Pic_conexao.Size = New System.Drawing.Size(41, 42)
        Me.Pic_conexao.TabIndex = 5
        Me.Pic_conexao.TabStop = False
        Me.Pic_conexao.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(253, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Conexão Internet"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(263, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Sem Conexão"
        Me.Label3.Visible = False
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Red
        Me.Button3.Location = New System.Drawing.Point(383, 90)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(235, 41)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Reimprimir Venda"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Blue
        Me.Button4.Location = New System.Drawing.Point(12, 33)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(235, 41)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "DFe"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(279, 107)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "Button5"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.Blue
        Me.Button6.Location = New System.Drawing.Point(12, 90)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(235, 41)
        Me.Button6.TabIndex = 11
        Me.Button6.Text = "Cadastro Empresa"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(256, 165)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(121, 23)
        Me.Button7.TabIndex = 12
        Me.Button7.Text = "DFe access local"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'lblversaomy
        '
        Me.lblversaomy.AutoSize = True
        Me.lblversaomy.BackColor = System.Drawing.Color.Transparent
        Me.lblversaomy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblversaomy.ForeColor = System.Drawing.Color.White
        Me.lblversaomy.Location = New System.Drawing.Point(380, 134)
        Me.lblversaomy.Name = "lblversaomy"
        Me.lblversaomy.Size = New System.Drawing.Size(106, 16)
        Me.lblversaomy.TabIndex = 14
        Me.lblversaomy.Text = "Versâo mysql:"
        '
        'lbldatas
        '
        Me.lbldatas.AutoSize = True
        Me.lbldatas.BackColor = System.Drawing.Color.Transparent
        Me.lbldatas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldatas.ForeColor = System.Drawing.Color.White
        Me.lbldatas.Location = New System.Drawing.Point(12, 134)
        Me.lbldatas.Name = "lbldatas"
        Me.lbldatas.Size = New System.Drawing.Size(108, 16)
        Me.lbldatas.TabIndex = 15
        Me.lbldatas.Text = "Data Sistema: "
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(436, 165)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(165, 23)
        Me.Button9.TabIndex = 18
        Me.Button9.Text = "gerar licenca Linear"
        Me.Button9.UseVisualStyleBackColor = True
        Me.Button9.Visible = False
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(55, 158)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 19
        Me.Button8.Text = "Button8"
        Me.Button8.UseVisualStyleBackColor = True
        Me.Button8.Visible = False
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(149, 158)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 23)
        Me.Button10.TabIndex = 20
        Me.Button10.Text = "teste"
        Me.Button10.UseVisualStyleBackColor = True
        Me.Button10.Visible = False
        '
        'frmprincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.DFe_aplicativo.My.Resources.Resources.gradiente_tendencia_cover
        Me.ClientSize = New System.Drawing.Size(625, 193)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.lbldatas)
        Me.Controls.Add(Me.lblversaomy)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Pic_conexao)
        Me.Controls.Add(Me.lblnetinfo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmprincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Principal"
        CType(Me.Pic_conexao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblnetinfo As System.Windows.Forms.Label
    Friend WithEvents Pic_conexao As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents lblversaomy As System.Windows.Forms.Label
    Friend WithEvents lbldatas As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Button10 As Button
End Class
