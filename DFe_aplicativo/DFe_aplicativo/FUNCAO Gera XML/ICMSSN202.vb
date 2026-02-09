Public Class ICMSSN202
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
    ''' Modalidade de determinação da BC do ICMS ST
    ''' 0 – Preço tabelado ou máximo sugerido;
    ''' 1 - Lista Negativa (valor);
    ''' 2 - Lista Positiva (valor);
    ''' 3 - Lista Neutra (valor);
    ''' 4 - Margem Valor Agregado (%);
    ''' 5 - Pauta (valor);
    ''' </summary>
    Private _modBCST As String
    Public Property modBCST() As String
        Get
            Return _modBCST
        End Get
        Set(ByVal value As String)
            _modBCST = value
        End Set
    End Property
    ''' <summary>
    ''' Percentual da margem de valor Adicionado do ICMS ST
    ''' </summary>
    Private _pMVAST As String
    Public Property pMVAST() As String
        Get
            Return _pMVAST
        End Get
        Set(ByVal value As String)
            _pMVAST = value
        End Set
    End Property
    ''' <summary>
    ''' Percentual da Redução de BC do ICMS ST
    ''' </summary>
    Private _pRedBCST As String
    Public Property pRedBCST() As String
        Get
            Return _pRedBCST
        End Get
        Set(ByVal value As String)
            _pRedBCST = value
        End Set
    End Property
    ''' <summary>
    ''' Valor do ICMS ST
    ''' </summary>
    Private _vBCST As String
    Public Property vBCST() As String
        Get
            Return _vBCST
        End Get
        Set(ByVal value As String)
            _vBCST = value
        End Set
    End Property
    ''' <summary>
    ''' Alíquota do imposto do ICMS ST
    ''' </summary>
    Private _pICMSST As String
    Public Property pICMSST() As String
        Get
            Return _pICMSST
        End Get
        Set(ByVal value As String)
            _pICMSST = value
        End Set
    End Property
    ''' <summary>
    ''' Valor do ICMS ST retido
    ''' </summary>
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
