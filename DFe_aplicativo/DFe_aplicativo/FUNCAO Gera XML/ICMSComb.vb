Public Class ICMSComb
    Private _vBCICMS As String
    Public Property vBCICMS() As String
        Get
            Return _vBCICMS
        End Get
        Set(ByVal value As String)
            _vBCICMS = value
        End Set
    End Property
    Private _vICMS As String
    Public Property vICMS() As String
        Get
            Return _vICMS
        End Get
        Set(ByVal value As String)
            _vICMS = value
        End Set
    End Property
    Private _vBCICMSST As String
    Public Property vBCICMSST() As String
        Get
            Return _vBCICMSST
        End Get
        Set(ByVal value As String)
            _vBCICMSST = value
        End Set
    End Property
    Private _vICMSST As String
    Public Property vICMSST() As String
        Get
            Return _vICMSST
        End Get
        Set(ByVal value As String)
            _vICMSST = value
        End Set
    End Property
End Class