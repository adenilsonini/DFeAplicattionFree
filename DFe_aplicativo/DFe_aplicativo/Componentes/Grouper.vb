Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms


<ToolboxBitmap(GetType(Grouper), "CodeVendor.Controls.Grouper.bmp")>
<Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", GetType(IDesigner))>
Public Class Grouper
    Inherits System.Windows.Forms.UserControl

    Public Enum GroupBoxGradientMode
        None = 4
        BackwardDiagonal = 3
        ForwardDiagonal = 2
        Horizontal = 0
        Vertical = 1
    End Enum

    Private components As System.ComponentModel.Container = Nothing
    Private V_RoundCorners As Integer = 10
    Private V_GroupTitle As String = "The Grouper"
    Private V_BorderColor As System.Drawing.Color = Color.Black
    Private V_BorderThickness As Single = 1
    Private V_ShadowControl As Boolean = False
    Private V_BackgroundColor As System.Drawing.Color = Color.White
    Private V_BackgroundGradientColor As System.Drawing.Color = Color.White
    Private V_BackgroundGradientMode As GroupBoxGradientMode = GroupBoxGradientMode.None
    Private V_ShadowColor As System.Drawing.Color = Color.DarkGray
    Private V_ShadowThickness As Integer = 3
    Private V_GroupImage As System.Drawing.Image = Nothing
    Private V_CustomGroupBoxColor As System.Drawing.Color = Color.White
    Private V_PaintGroupBox As Boolean = False
    Private V_BackColor As System.Drawing.Color = Color.Transparent

    <Category("Appearance"), Description("This feature will paint the background color of the control.")>
    Public Overrides Property BackColor As System.Drawing.Color
        Get
            Return V_BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            V_BackColor = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("This feature will paint the group title background to the specified color if PaintGroupBox is set to true.")>
    Public Property CustomGroupBoxColor As System.Drawing.Color
        Get
            Return V_CustomGroupBoxColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            V_CustomGroupBoxColor = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("This feature will paint the group title background to the CustomGroupBoxColor.")>
    Public Property PaintGroupBox As Boolean
        Get
            Return V_PaintGroupBox
        End Get
        Set(ByVal value As Boolean)
            V_PaintGroupBox = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("This feature can add a 16 x 16 image to the group title bar.")>
    Public Property GroupImage As System.Drawing.Image
        Get
            Return V_GroupImage
        End Get
        Set(ByVal value As System.Drawing.Image)
            V_GroupImage = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("This feature will change the control's shadow color.")>
    Public Property ShadowColor As System.Drawing.Color
        Get
            Return V_ShadowColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            V_ShadowColor = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("This feature will change the size of the shadow border.")>
    Public Property ShadowThickness As Integer
        Get
            Return V_ShadowThickness
        End Get
        Set(ByVal value As Integer)

            If value > 10 Then
                V_ShadowThickness = 10
            Else

                If value < 1 Then
                    V_ShadowThickness = 1
                Else
                    V_ShadowThickness = value
                End If
            End If

            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("This feature will change the group control color. This color can also be used in combination with BackgroundGradientColor for a gradient paint.")>
    Public Property BackgroundColor As System.Drawing.Color
        Get
            Return V_BackgroundColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            V_BackgroundColor = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("This feature can be used in combination with BackgroundColor to create a gradient background.")>
    Public Property BackgroundGradientColor As System.Drawing.Color
        Get
            Return V_BackgroundGradientColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            V_BackgroundGradientColor = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("This feature turns on background gradient painting.")>
    Public Property BackgroundGradientMode As GroupBoxGradientMode
        Get
            Return V_BackgroundGradientMode
        End Get
        Set(ByVal value As GroupBoxGradientMode)
            V_BackgroundGradientMode = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("This feature will round the corners of the control.")>
    Public Property RoundCorners As Integer
        Get
            Return V_RoundCorners
        End Get
        Set(ByVal value As Integer)

            If value > 25 Then
                V_RoundCorners = 25
            Else

                If value < 1 Then
                    V_RoundCorners = 1
                Else
                    V_RoundCorners = value
                End If
            End If

            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("This feature will add a group title to the control.")>
    Public Property GroupTitle As String
        Get
            Return V_GroupTitle
        End Get
        Set(ByVal value As String)
            V_GroupTitle = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("This feature will allow you to change the color of the control's border.")>
    Public Property BorderColor As System.Drawing.Color
        Get
            Return V_BorderColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            V_BorderColor = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("This feature will allow you to set the control's border size.")>
    Public Property BorderThickness As Single
        Get
            Return V_BorderThickness
        End Get
        Set(ByVal value As Single)

            If value > 3 Then
                V_BorderThickness = 3
            Else

                If value < 1 Then
                    V_BorderThickness = 1
                Else
                    V_BorderThickness = value
                End If
            End If

            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("This feature will allow you to turn on control shadowing.")>
    Public Property ShadowControl As Boolean
        Get
            Return V_ShadowControl
        End Get
        Set(ByVal value As Boolean)
            V_ShadowControl = value
            Me.Refresh()
        End Set
    End Property

    Public Sub New()
        InitializeStyles()
        InitializeGroupBox()
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then

            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If

        MyBase.Dispose(disposing)
    End Sub

    Private Sub InitializeStyles()
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub

    Private Sub InitializeGroupBox()
        components = New System.ComponentModel.Container()
        AddHandler Me.Resize, New EventHandler(AddressOf GroupBox_Resize)
        Me.DockPadding.All = 20
        Me.Name = "GroupBox"
        Me.Size = New System.Drawing.Size(368, 288)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        PaintBack(e.Graphics)
        PaintGroupText(e.Graphics)
    End Sub

    Private Sub PaintGroupText(ByVal g As System.Drawing.Graphics)
        If Me.GroupTitle = String.Empty Then
            Return
        End If

        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim StringSize As SizeF = g.MeasureString(Me.GroupTitle, Me.Font)
        Dim StringSize2 As Size = StringSize.ToSize()

        If Me.GroupImage IsNot Nothing Then
            StringSize2.Width += 18
        End If

        Dim ArcWidth As Integer = Me.RoundCorners
        Dim ArcHeight As Integer = Me.RoundCorners
        Dim ArcX1 As Integer = 20
        Dim ArcX2 As Integer = (StringSize2.Width + 34) - (ArcWidth + 1)
        Dim ArcY1 As Integer = 0
        Dim ArcY2 As Integer = 24 - (ArcHeight + 1)
        Dim path As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath()
        Dim BorderBrush As System.Drawing.Brush = New SolidBrush(Me.BorderColor)
        Dim BorderPen As System.Drawing.Pen = New Pen(BorderBrush, Me.BorderThickness)
        Dim BackgroundGradientBrush As System.Drawing.Drawing2D.LinearGradientBrush = Nothing
        Dim BackgroundBrush As System.Drawing.Brush = If((Me.PaintGroupBox), New SolidBrush(Me.CustomGroupBoxColor), New SolidBrush(Me.BackgroundColor))
        Dim TextColorBrush As System.Drawing.SolidBrush = New SolidBrush(Me.ForeColor)
        Dim ShadowBrush As System.Drawing.SolidBrush = Nothing
        Dim ShadowPath As System.Drawing.Drawing2D.GraphicsPath = Nothing

        If Me.ShadowControl Then
            ShadowBrush = New SolidBrush(Me.ShadowColor)
            ShadowPath = New System.Drawing.Drawing2D.GraphicsPath()
            ShadowPath.AddArc(ArcX1 + (Me.ShadowThickness - 1), ArcY1 + (Me.ShadowThickness - 1), ArcWidth, ArcHeight, 180, GroupBoxConstants.SweepAngle)
            ShadowPath.AddArc(ArcX2 + (Me.ShadowThickness - 1), ArcY1 + (Me.ShadowThickness - 1), ArcWidth, ArcHeight, 270, GroupBoxConstants.SweepAngle)
            ShadowPath.AddArc(ArcX2 + (Me.ShadowThickness - 1), ArcY2 + (Me.ShadowThickness - 1), ArcWidth, ArcHeight, 360, GroupBoxConstants.SweepAngle)
            ShadowPath.AddArc(ArcX1 + (Me.ShadowThickness - 1), ArcY2 + (Me.ShadowThickness - 1), ArcWidth, ArcHeight, 90, GroupBoxConstants.SweepAngle)
            ShadowPath.CloseAllFigures()
            g.FillPath(ShadowBrush, ShadowPath)
        End If

        path.AddArc(ArcX1, ArcY1, ArcWidth, ArcHeight, 180, GroupBoxConstants.SweepAngle)
        path.AddArc(ArcX2, ArcY1, ArcWidth, ArcHeight, 270, GroupBoxConstants.SweepAngle)
        path.AddArc(ArcX2, ArcY2, ArcWidth, ArcHeight, 360, GroupBoxConstants.SweepAngle)
        path.AddArc(ArcX1, ArcY2, ArcWidth, ArcHeight, 90, GroupBoxConstants.SweepAngle)
        path.CloseAllFigures()

        If Me.PaintGroupBox Then
            g.FillPath(BackgroundBrush, path)
        Else

            If Me.BackgroundGradientMode = GroupBoxGradientMode.None Then
                g.FillPath(BackgroundBrush, path)
            Else
                BackgroundGradientBrush = New LinearGradientBrush(New Rectangle(0, 0, Me.Width, Me.Height), Me.BackgroundColor, Me.BackgroundGradientColor, CType(Me.BackgroundGradientMode, LinearGradientMode))
                g.FillPath(BackgroundGradientBrush, path)
            End If
        End If

        g.DrawPath(BorderPen, path)
        Dim CustomStringWidth As Integer = If((Me.GroupImage IsNot Nothing), 44, 28)
        g.DrawString(Me.GroupTitle, Me.Font, TextColorBrush, CustomStringWidth, 5)

        If Me.GroupImage IsNot Nothing Then
            g.DrawImage(Me.GroupImage, 28, 4, 16, 16)
        End If

        If path IsNot Nothing Then
            path.Dispose()
        End If

        If BorderBrush IsNot Nothing Then
            BorderBrush.Dispose()
        End If

        If BorderPen IsNot Nothing Then
            BorderPen.Dispose()
        End If

        If BackgroundGradientBrush IsNot Nothing Then
            BackgroundGradientBrush.Dispose()
        End If

        If BackgroundBrush IsNot Nothing Then
            BackgroundBrush.Dispose()
        End If

        If TextColorBrush IsNot Nothing Then
            TextColorBrush.Dispose()
        End If

        If ShadowBrush IsNot Nothing Then
            ShadowBrush.Dispose()
        End If

        If ShadowPath IsNot Nothing Then
            ShadowPath.Dispose()
        End If
    End Sub

    Private Sub PaintBack(ByVal g As System.Drawing.Graphics)
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim ArcWidth As Integer = Me.RoundCorners * 2
        Dim ArcHeight As Integer = Me.RoundCorners * 2
        Dim ArcX1 As Integer = 0
        Dim ArcX2 As Integer = If((Me.ShadowControl), (Me.Width - (ArcWidth + 1)) - Me.ShadowThickness, Me.Width - (ArcWidth + 1))
        Dim ArcY1 As Integer = 10
        Dim ArcY2 As Integer = If((Me.ShadowControl), (Me.Height - (ArcHeight + 1)) - Me.ShadowThickness, Me.Height - (ArcHeight + 1))
        Dim path As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath()
        Dim BorderBrush As System.Drawing.Brush = New SolidBrush(Me.BorderColor)
        Dim BorderPen As System.Drawing.Pen = New Pen(BorderBrush, Me.BorderThickness)
        Dim BackgroundGradientBrush As System.Drawing.Drawing2D.LinearGradientBrush = Nothing
        Dim BackgroundBrush As System.Drawing.Brush = New SolidBrush(Me.BackgroundColor)
        Dim ShadowBrush As System.Drawing.SolidBrush = Nothing
        Dim ShadowPath As System.Drawing.Drawing2D.GraphicsPath = Nothing

        If Me.ShadowControl Then
            ShadowBrush = New SolidBrush(Me.ShadowColor)
            ShadowPath = New System.Drawing.Drawing2D.GraphicsPath()
            ShadowPath.AddArc(ArcX1 + Me.ShadowThickness, ArcY1 + Me.ShadowThickness, ArcWidth, ArcHeight, 180, GroupBoxConstants.SweepAngle)
            ShadowPath.AddArc(ArcX2 + Me.ShadowThickness, ArcY1 + Me.ShadowThickness, ArcWidth, ArcHeight, 270, GroupBoxConstants.SweepAngle)
            ShadowPath.AddArc(ArcX2 + Me.ShadowThickness, ArcY2 + Me.ShadowThickness, ArcWidth, ArcHeight, 360, GroupBoxConstants.SweepAngle)
            ShadowPath.AddArc(ArcX1 + Me.ShadowThickness, ArcY2 + Me.ShadowThickness, ArcWidth, ArcHeight, 90, GroupBoxConstants.SweepAngle)
            ShadowPath.CloseAllFigures()
            g.FillPath(ShadowBrush, ShadowPath)
        End If

        path.AddArc(ArcX1, ArcY1, ArcWidth, ArcHeight, 180, GroupBoxConstants.SweepAngle)
        path.AddArc(ArcX2, ArcY1, ArcWidth, ArcHeight, 270, GroupBoxConstants.SweepAngle)
        path.AddArc(ArcX2, ArcY2, ArcWidth, ArcHeight, 360, GroupBoxConstants.SweepAngle)
        path.AddArc(ArcX1, ArcY2, ArcWidth, ArcHeight, 90, GroupBoxConstants.SweepAngle)
        path.CloseAllFigures()

        If Me.BackgroundGradientMode = GroupBoxGradientMode.None Then
            g.FillPath(BackgroundBrush, path)
        Else
            BackgroundGradientBrush = New LinearGradientBrush(New Rectangle(0, 0, Me.Width, Me.Height), Me.BackgroundColor, Me.BackgroundGradientColor, CType(Me.BackgroundGradientMode, LinearGradientMode))
            g.FillPath(BackgroundGradientBrush, path)
        End If

        g.DrawPath(BorderPen, path)

        If path IsNot Nothing Then
            path.Dispose()
        End If

        If BorderBrush IsNot Nothing Then
            BorderBrush.Dispose()
        End If

        If BorderPen IsNot Nothing Then
            BorderPen.Dispose()
        End If

        If BackgroundGradientBrush IsNot Nothing Then
            BackgroundGradientBrush.Dispose()
        End If

        If BackgroundBrush IsNot Nothing Then
            BackgroundBrush.Dispose()
        End If

        If ShadowBrush IsNot Nothing Then
            ShadowBrush.Dispose()
        End If

        If ShadowPath IsNot Nothing Then
            ShadowPath.Dispose()
        End If
    End Sub

    Private Sub GroupBox_Resize(ByVal sender As Object, ByVal e As EventArgs)
        Me.Refresh()
    End Sub
End Class

