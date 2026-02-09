Public Class frm_conexao_banco
    Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")
    Dim ip_mysql As String = ArquivoIni.Read("ip_mysql", "DFe")
    Private _Task As String = ""
    Public Property Task() As String
        Get
            Return _Task
        End Get
        Set(ByVal value As String)
            If value <> _Task Then
                _Task = value
                Me.lbl_Task.Text = value
            End If
        End Set
    End Property

    Public Overloads Sub Show(ByVal task As String)
        Me.Task = task
        Me.Show()
        Application.DoEvents()
    End Sub

    Private Sub frm_Working_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.FormBorderStyle = FormBorderStyle.None
        Me.Height = Me.Height
        Me.Width = Me.Width
        Dim p As New Drawing2D.GraphicsPath()
        p.StartFigure()
        p.AddArc(New Rectangle(0, 0, 25, 25), 180, 90)
        p.AddLine(40, 0, Me.Width - 40, 0)
        p.AddArc(New Rectangle(Me.Width - 40, 0, 40, 40), -90, 90)
        p.AddLine(Me.Width, 40, Me.Width, Me.Height - 40)
        p.AddArc(New Rectangle(Me.Width - 40, Me.Height - 40, 40, 40), 0, 90)
        p.AddLine(Me.Width - 40, Me.Height, 40, Me.Height)
        p.AddArc(New Rectangle(0, Me.Height - 40, 40, 40), 90, 90)
        p.CloseFigure()
        Me.Region = New Region(p)

        If ip_mysql = "127.0.0.1" Then
            Dim processes2 As Process() = Process.GetProcessesByName("mysqld-nt")
            If processes2.Length = 0 Then 'se for maior que 0 então existem processos com o nome X
                Using myProcess As Process = New Process()
                    myProcess.StartInfo.UseShellExecute = False
                    myProcess.StartInfo.FileName = Application.StartupPath & "\mysql\bin\mysqld-nt.exe"
                    myProcess.StartInfo.CreateNoWindow = True
                    myProcess.Start()

                End Using

            End If

        
        End If

    End Sub

    Private Sub conexao()
     
        If ip_mysql = "127.0.0.1" Then
            Dim processes22 As Process() = Process.GetProcessesByName("mysqld-nt")

            If processes22.Length <> 0 Then
                Timer1.Dispose()
                frmcert.Show()
                Me.Close()
            End If
        Else
            Timer1.Dispose()
            frmcert.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        conexao()
    End Sub

    Private Sub Grouper1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub RoundPanel1_Enter(sender As Object, e As EventArgs) Handles RoundPanel1.Enter

    End Sub
End Class