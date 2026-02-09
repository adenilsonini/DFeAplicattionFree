Public Class ICMSInter
    Private _vBCICMSSTDest As String
    Public Property vBCICMSSTDest() As String
        Get
            Return _vBCICMSSTDest
        End Get
        Set(ByVal value As String)
            _vBCICMSSTDest = value
        End Set
    End Property
    Private _vICMSSTDest As String
    Public Property vICMSSTDest() As String
        Get
            Return _vICMSSTDest
        End Get
        Set(ByVal value As String)
            _vICMSSTDest = value
        End Set
    End Property
End Class