Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class RoundPanel
    Inherits GroupBox

    Public Sub New()
        Me.DoubleBuffered = True
        Me.TitleBackColor = Color.SteelBlue
        Me.TitleForeColor = Color.White
        Me.TitleFont = New Font(Me.Font.FontFamily, Font.Size + 8, FontStyle.Bold)
        Me.BackColor = Color.Transparent
        Me.Radious = 25
        Me.TitleHatchStyle = HatchStyle.Percent60
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        GroupBoxRenderer.DrawParentBackground(e.Graphics, Me.ClientRectangle, Me)
        Dim rect = ClientRectangle

        Using path = GetRoundRectagle(Me.ClientRectangle, Radious)
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            rect = New Rectangle(0, 0, rect.Width, TitleFont.Height + Padding.Bottom + Padding.Top)

            If Me.BackColor <> Color.Transparent Then

                Using brush = New SolidBrush(BackColor)
                    e.Graphics.FillPath(brush, path)
                End Using
            End If

            Dim clip = e.Graphics.ClipBounds
            e.Graphics.SetClip(rect)

            Using brush = New HatchBrush(TitleHatchStyle, TitleBackColor, ControlPaint.Light(TitleBackColor))
                e.Graphics.FillPath(brush, path)
            End Using

            Using pen = New Pen(TitleBackColor, 1)
                e.Graphics.DrawPath(pen, path)
            End Using

            TextRenderer.DrawText(e.Graphics, Text, TitleFont, rect, TitleForeColor)
            e.Graphics.SetClip(clip)

            Using pen = New Pen(TitleBackColor, 1)
                e.Graphics.DrawPath(pen, path)
            End Using
        End Using
    End Sub

    Public Property TitleBackColor As Color
    Public Property TitleHatchStyle As HatchStyle
    Public Property TitleFont As Font
    Public Property TitleForeColor As Color
    Public Property Radious As Integer

    Private Function GetRoundRectagle(ByVal b As Rectangle, ByVal r As Integer) As GraphicsPath
        Dim path As GraphicsPath = New GraphicsPath()
        path.AddArc(b.X, b.Y, r, r, 180, 90)
        path.AddArc(b.X + b.Width - r - 1, b.Y, r, r, 270, 90)
        path.AddArc(b.X + b.Width - r - 1, b.Y + b.Height - r - 1, r, r, 0, 90)
        path.AddArc(b.X, b.Y + b.Height - r - 1, r, r, 90, 90)
        path.CloseAllFigures()
        Return path
    End Function
End Class

