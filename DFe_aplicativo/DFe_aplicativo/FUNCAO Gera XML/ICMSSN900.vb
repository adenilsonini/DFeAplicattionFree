Public Class ICMSSN900
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
    ''' 0 - Margem Valor Agregado (%);
    ''' 1 - Pauta (Valor);
    ''' 2 - Preço Tabelado Máx. (valor);
    ''' 3 - valor da operação.
    ''' </summary>
    Private _modBC As String
    Public Property modBC() As String
        Get
            Return _modBC
        End Get
        Set(ByVal value As String)
            _modBC = value
        End Set
    End Property
    ''' <summary>
    ''' Valor da base de calculo do imposto
    ''' </summary>
    Private _vBC As String
    Public Property vBC() As String
        Get
            Return _vBC
        End Get
        Set(ByVal value As String)
            _vBC = value
        End Set
    End Property
    ''' <summary>
    ''' Percentual da Redução de BC
    ''' </summary>
    Private _pRedBC As String
    Public Property pRedBC() As String
        Get
            Return _pRedBC
        End Get
        Set(ByVal value As String)
            _pRedBC = value
        End Set
    End Property
    ''' <summary>
    ''' Aliquota do imposto
    ''' </summary>
    Private _pICMS As String
    Public Property pICMS() As String
        Get
            Return _pICMS
        End Get
        Set(ByVal value As String)
            _pICMS = value
        End Set
    End Property
    ''' <summary>
    ''' Valor do ICMS
    ''' </summary>
    Private _vICMS As String
    Public Property vICMS() As String
        Get
            Return _vICMS
        End Get
        Set(ByVal value As String)
            _vICMS = value
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
