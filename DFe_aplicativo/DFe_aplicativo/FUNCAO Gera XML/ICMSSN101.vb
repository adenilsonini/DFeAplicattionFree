Public Class ICMSSN101
    ''' <summary>
    ''' Origem da mercadoria:
    ''' 0 – Nacional;
    ''' 1 – Estrangeira – Importação direta;
    ''' 2 – Estrangeira – Adquirida no mercado interno.
    ''' </summary>
    Private _orig As String
    Public Property orig() As String
        Get
            Return _orig
        End Get
        Set(ByVal value As String)
            _orig = value
        End Set
    End Property
    ''' <summary>
    ''' Tributação do ICMS: 00 – Tributada integralmente
    ''' </summary>
    Private _CSOSN As String
    Public Property CSOSN() As String
        Get
            Return _CSOSN
        End Get
        Set(ByVal value As String)
            _CSOSN = value
        End Set
    End Property

    ''' <summary>
    ''' Aliquota do imposto
    ''' </summary>
    Private _pCredSN As String
    Public Property pCredSN() As String
        Get
            Return _pCredSN
        End Get
        Set(ByVal value As String)
            _pCredSN = value
        End Set
    End Property

    ''' <summary>
    ''' Valor do ICMS
    ''' </summary>
    Private _vCredICMSSN As String
    Public Property vCredICMSSN() As String
        Get
            Return _vCredICMSSN
        End Get
        Set(ByVal value As String)
            _vCredICMSSN = value
        End Set
    End Property
End Class
