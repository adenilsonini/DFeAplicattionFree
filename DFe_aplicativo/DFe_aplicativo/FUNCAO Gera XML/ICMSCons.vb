Public Class ICMSCons
    Private _vBCICMSSTCons As String
    Public Property vBCICMSSTCons() As String
        Get
            Return _vBCICMSSTCons
        End Get
        Set(ByVal value As String)
            _vBCICMSSTCons = value
        End Set
    End Property
    Private _vICMSSTCons As String
    Public Property vICMSSTCons() As String
        Get
            Return _vICMSSTCons
        End Get
        Set(ByVal value As String)
            _vICMSSTCons = value
        End Set
    End Property
    Private _UFcons As String
    Public Property UFcons() As String
        Get
            Return _UFcons
        End Get
        Set(ByVal value As String)
            _UFcons = value
        End Set
    End Property
End Class