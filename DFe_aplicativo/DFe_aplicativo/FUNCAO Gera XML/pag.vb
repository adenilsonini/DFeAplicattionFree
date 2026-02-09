''' <summary>
''' TAG de grupo de Cobrança
''' </summary>
Public Class pag

    Private _detPag As detPag
    Public Property detPag() As detPag
        Get
            Return _detPag
        End Get
        Set(ByVal value As detPag)
            _detPag = value
        End Set
    End Property

End Class