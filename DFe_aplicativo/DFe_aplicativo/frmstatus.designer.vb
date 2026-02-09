<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmstatus
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
        Me.cboweb = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbltimer = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.bntdownloadnfe = New System.Windows.Forms.Button()
        Me.tstatus = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboweb
        '
        Me.cboweb.FormattingEnabled = True
        Me.cboweb.Items.AddRange(New Object() {"Sefaz Minas Gerais - (MG) NFCe", "Sefaz Amazonas - (AM)", "Sefaz Bahia - (BA)", "Sefaz Ceará - (CE)", "Sefaz Goias - (GO)", "Sefaz Minas Gerais - (MG)", "Sefaz Mato Grosso do Sul - (MS)", "Sefaz Mato Grosso - (MT)", "Sefaz Pernambuco - (PE)", "Sefaz São Paulo - (SP)", "Sefaz Paraná - (PR)", "Sefaz Rio Grande do Sul - (RS)", "Sefaz Virtual Rio Grande do Sul - (SVRS)", "Sefaz Virtual Ambiente Nacional - (SVAN)", "Sefaz Contingência (SVC-AN)"})
        Me.cboweb.Location = New System.Drawing.Point(3, 27)
        Me.cboweb.Name = "cboweb"
        Me.cboweb.Size = New System.Drawing.Size(292, 21)
        Me.cboweb.TabIndex = 27
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Gainsboro
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(5, 5)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(189, 13)
        Me.Label22.TabIndex = 41
        Me.Label22.Text = "Portais Estaduais da NF-e Versao 4.00"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lbltimer)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.cboweb)
        Me.Panel2.Controls.Add(Me.bntdownloadnfe)
        Me.Panel2.Location = New System.Drawing.Point(1, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(300, 83)
        Me.Panel2.TabIndex = 40
        '
        'lbltimer
        '
        Me.lbltimer.AutoSize = True
        Me.lbltimer.Location = New System.Drawing.Point(259, 54)
        Me.lbltimer.Name = "lbltimer"
        Me.lbltimer.Size = New System.Drawing.Size(13, 13)
        Me.lbltimer.TabIndex = 33
        Me.lbltimer.Text = "0"
        Me.lbltimer.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.ForeColor = System.Drawing.Color.Blue
        Me.Button1.Location = New System.Drawing.Point(243, 52)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(52, 23)
        Me.Button1.TabIndex = 32
        Me.Button1.Text = "&Sair"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(0, 8)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(123, 16)
        Me.Label20.TabIndex = 28
        Me.Label20.Text = "Nome WebService"
        '
        'bntdownloadnfe
        '
        Me.bntdownloadnfe.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bntdownloadnfe.ForeColor = System.Drawing.Color.Blue
        Me.bntdownloadnfe.Location = New System.Drawing.Point(2, 52)
        Me.bntdownloadnfe.Name = "bntdownloadnfe"
        Me.bntdownloadnfe.Size = New System.Drawing.Size(130, 23)
        Me.bntdownloadnfe.TabIndex = 31
        Me.bntdownloadnfe.Text = "&Status do Webservice"
        Me.bntdownloadnfe.UseVisualStyleBackColor = False
        '
        'tstatus
        '
        '
        'frmstatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(303, 98)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmstatus"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Verifica o Status do webservice da SEFAZ"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboweb As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents bntdownloadnfe As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tstatus As System.Windows.Forms.Timer
    Friend WithEvents lbltimer As System.Windows.Forms.Label
End Class
