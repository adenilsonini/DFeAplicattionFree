Public Class detPag
    ''' <summary>
    ''' Número da Fatura
    ''' </summary>
    Private _tPag As String
    Public Property tPag() As String
        Get
            Return _tPag
        End Get
        Set(ByVal value As String)
            _tPag = value
        End Set
    End Property

    Private _vPag As String
    Public Property vPag() As String
        Get
            Return _vPag
        End Get
        Set(ByVal value As String)
            _vPag = value
        End Set
    End Property

End Class