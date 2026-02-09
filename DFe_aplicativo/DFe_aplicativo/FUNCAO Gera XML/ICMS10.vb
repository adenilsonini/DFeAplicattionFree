Public Class ICMS10
    ''' <summary>
    ''' Origem da mercadoria:
    ''' 0 – Nacional;
    ''' 1 – Estrangeira – Importação direta;
    ''' 2 – Estrangeira – Adquirida no mercado interno.
    ''' </summary>
    Private _orig As String
    <Obrigatorio()> _
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
    <Obrigatorio()> _
       Public Property CST() As String
        Get
            Return _CST
        End Get
        Set(ByVal value As String)
            _CST = value
        End Set
    End Property
    ''' <summary>
    ''' 0 - Margem Valor Agregado (%);
    ''' 1 - Pauta (Valor);
    ''' 2 - Preço Tabelado Máx. (valor);
    ''' 3 - valor da operação.
    ''' </summary>
    Private _modBC As String
    <Obrigatorio()> _
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
    <Obrigatorio()> _
       Public Property vBC() As String
        Get
            Return _vBC
        End Get
        Set(ByVal value As String)
            _vBC = value
        End Set
    End Property
    ''' <summary>
    ''' Aliquota do imposto
    ''' </summary>
    Private _pICMS As String
    <Obrigatorio()> _
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
    <Obrigatorio()> _
       Public Property vICMS() As String
        Get
            Return _vICMS
        End Get
        Set(ByVal value As String)
            _vICMS = value
        End Set
    End Property

    ''' <summary>
    '''Base de calculo do ICMS relativo ao Fundo de Combate à Pobreza (FCP).
    ''' </summary>
    Private _vBCFCP As String
    '   <Obrigatorio()>
    Public Property vBCFCP() As String
        Get
            Return _vBCFCP
        End Get
        Set(ByVal value As String)
            _vBCFCP = value
        End Set
    End Property

    ''' <summary>
    '''Percentual de ICMS relativo ao Fundo de Combate à Pobreza (FCP).
    ''' </summary>
    Private _pFCP As String
    '   <Obrigatorio()>
    Public Property pFCP() As String
        Get
            Return _pFCP
        End Get
        Set(ByVal value As String)
            _pFCP = value
        End Set
    End Property

    ''' <summary>
    ''' Valor do ICMS relativo ao Fundo de Combate à Pobreza (FCP).
    ''' </summary>
    Private _vFCP As String
    '' <Obrigatorio()>
    Public Property vFCP() As String
        Get
            Return _vFCP
        End Get
        Set(ByVal value As String)
            _vFCP = value
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
    <Obrigatorio()> _
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
    <Obrigatorio()> _
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
    <Obrigatorio()> _
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
    <Obrigatorio()> _
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
    <Obrigatorio()>
    Public Property vICMSST() As String
        Get
            Return _vICMSST
        End Get
        Set(ByVal value As String)
            _vICMSST = value
        End Set
    End Property

    ''' <summary>
    ''' Valor da Base de cálculo do FCP.
    ''' </summary>
    Private _vBCFCPST As String
    '  <Obrigatorio()>
    Public Property vBCFCPST() As String
        Get
            Return _vBCFCPST
        End Get
        Set(ByVal value As String)
            _vBCFCPST = value
        End Set
    End Property

    ''' <summary>
    ''' Percentual de FCP retido por substituição tributária.
    ''' </summary>
    Private _pFCPST As String
    '  <Obrigatorio()>
    Public Property pFCPST() As String
        Get
            Return _pFCPST
        End Get
        Set(ByVal value As String)
            _pFCPST = value
        End Set
    End Property

    ''' <summary>
    ''' Valor do FCP retido por substituição tributária.
    ''' </summary>
    Private _vFCPST As String
    ' <Obrigatorio()>
    Public Property vFCPST() As String
        Get
            Return _vFCPST
        End Get
        Set(ByVal value As String)
            _vFCPST = value
        End Set
    End Property
End Class