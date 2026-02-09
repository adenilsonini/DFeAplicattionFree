''' <summary>
''' Informar apenas um dos grupos O07 ou O08 com base valor atribuído ao campo O09 – CST do
''' IPI
''' </summary>
Public Class IPITrib
    ''' <summary>
    ''' 00-Entrada com recuperação de crédito
    ''' 49-Outras entradas
    ''' 50-Saída tributada
    ''' 99-Outras saídas
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
    ''' Campo 010
    '''
    ''' Informar os campos O10 e O14 caso o cálculo do IPI seja por
    ''' alíquota ou os campos O11 e O12 caso o cálculo do IPI seja valor por
    ''' unidade.
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
    ''' Campo 011
    '''
    ''' Informar os campos O10 e O14 caso o cálculo do IPI seja por
    ''' alíquota ou os campos O11 e O12 caso o cálculo do IPI seja valor por
    ''' unidade.
    ''' </summary>
    Private _qUnid As String
    Public Property qUnid() As String
        Get
            Return _qUnid
        End Get
        Set(ByVal value As String)
            _qUnid = value
        End Set
    End Property
    ''' <summary>
    ''' Campo 012
    '''
    ''' Informar os campos O10 e O14 caso o cálculo do IPI seja por
    ''' alíquota ou os campos O11 e O12 caso o cálculo do IPI seja valor por
    ''' unidade.
    ''' </summary>
    Private _vUnid As String
    Public Property vUnid() As String
        Get
            Return _vUnid
        End Get
        Set(ByVal value As String)
            _vUnid = value
        End Set
    End Property
    ''' <summary>
    ''' Campo 013
    '''
    ''' Informar os campos O10 e O14 caso o cálculo do IPI seja por
    ''' alíquota ou os campos O11 e O12 caso o cálculo do IPI seja valor por
    ''' unidade.
    ''' </summary>
    Private _pIPI As String
    Public Property pIPI() As String
        Get
            Return _pIPI
        End Get
        Set(ByVal value As String)
            _pIPI = value
        End Set
    End Property
    ''' <summary>
    ''' Valor do IPI
    ''' </summary>
    Private _vIPI As String
    Public Property vIPI() As String
        Get
            Return _vIPI
        End Get
        Set(ByVal value As String)
            _vIPI = value
        End Set
    End Property
End Class