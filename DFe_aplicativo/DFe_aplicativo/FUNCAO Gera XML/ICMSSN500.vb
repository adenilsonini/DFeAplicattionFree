Public Class ICMSSN500
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
    ''' Valor da BC do ICMS ST retido anteriormente (v2.0) 
    ''' </summary>
    Private _vBCSTRet As String
    Public Property vBCSTRet() As String
        Get
            Return _vBCSTRet
        End Get
        Set(ByVal value As String)
            _vBCSTRet = value
        End Set
    End Property
    ''' <summary>
    ''' Valor do ICMS ST retido anteriormente  (v2.0)
    ''' </summary>
    Private _vICMSSTRet As String
    Public Property vICMSSTRet() As String
        Get
            Return _vICMSSTRet
        End Get
        Set(ByVal value As String)
            _vICMSSTRet = value
        End Set
    End Property
End Class
