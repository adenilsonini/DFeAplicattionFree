''' <summary>
''' CST – 60 - ICMS cobrado anteriormente por substituição tributária
''' </summary>
Public Class ICMSST
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
    Private _CST As String
    Public Property CST() As String
        Get
            Return _CST
        End Get
        Set(ByVal value As String)
            _CST = value
        End Set
    End Property
    ''' <summary>
    ''' Valor da base de calculo
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
    ''' Valor do ICMS ST cobrado anteriormente por ST
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
    ''' <summary>
    ''' Informar o valor da BC do ICMS ST da UF destino
    ''' </summary>
    Private _vBCSTDest As String
    Public Property vBCSTDest() As String
        Get
            Return _vBCSTDest
        End Get
        Set(ByVal value As String)
            _vBCSTDest = value
        End Set
    End Property

    ''' <summary>
    ''' Informar o valor da BC do ICMS ST da UF destino (v2.0)
    ''' </summary>
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