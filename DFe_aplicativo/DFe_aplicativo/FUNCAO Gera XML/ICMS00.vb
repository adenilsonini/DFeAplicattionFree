Public Class ICMS00
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
    <Obrigatorio()>
    Public Property vICMS() As String
        Get
            Return _vICMS
        End Get
        Set(ByVal value As String)
            _vICMS = value
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
End Class