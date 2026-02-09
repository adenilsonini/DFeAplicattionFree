''' <summary>
''' TAG do grupo de PIS Substituição Tributária
''' </summary>
Public Class ICMSUFDest
    ''' <summary>
    ''' Valor da Base de Cálculo do ICMS na UF do destinatário..
    ''' </summary>
    Private _vBCUFDest As String
    Public Property vBCUFDest() As String
        Get
            Return _vBCUFDest
        End Get
        Set(ByVal value As String)
            _vBCUFDest = value
        End Set
    End Property

    ''' <summary>
    ''' Percentual adicional inserido na alíquota interna da UF de destino, relativo ao Fundo de Combate à Pobreza (FCP) naquela UF.
    ''' </summary>
    Private _pFCPUFDest As String
    Public Property pFCPUFDest() As String
        Get
            Return _pFCPUFDest
        End Get
        Set(ByVal value As String)
            _pFCPUFDest = value
        End Set
    End Property

    ''' <summary>
    ''' Alíquota adotada nas operações internas na UF do destinatário para o produto / mercadoria.
    ''' </summary>
    Private _pICMSUFDest As String
    Public Property pICMSUFDest() As String
        Get
            Return _pICMSUFDest
        End Get
        Set(ByVal value As String)
            _pICMSUFDest = value
        End Set
    End Property

    ''' <summary>
    ''' Alíquota interestadual das UF envolvidas: - 4% alíquota interestadual para produtos importados; - 7% para os Estados de origem do Sul e Sudeste (exceto ES), destinado para os Estados do Norte e Nordeste  ou ES; - 12% para os demais casos.
    ''' </summary>

    Private _pICMSInter As String
    Public Property pICMSInter() As String
        Get
            Return _pICMSInter
        End Get
        Set(ByVal value As String)
            _pICMSInter = value
        End Set
    End Property


    ''' <summary>
    ''' >Percentual de partilha para a UF do destinatário: - 40% em 2016; - 60% em 2017; - 80% em 2018; - 100% a partir de 2019.
    ''' </summary>
    Private _pICMSInterPart As String
    Public Property pICMSInterPart() As String
        Get
            Return _pICMSInterPart
        End Get
        Set(ByVal value As String)
            _pICMSInterPart = value
        End Set
    End Property

    ''' <summary>
    ''' Valor do ICMS relativo ao Fundo de Combate à Pobreza (FCP) da UF de destino.
    ''' </summary>
    Private _vFCPUFDest As String
    Public Property vFCPUFDest() As String
        Get
            Return _vFCPUFDest
        End Get
        Set(ByVal value As String)
            _vFCPUFDest = value
        End Set
    End Property

    ''' <summary>
    ''' Valor do ICMS de partilha para a UF do destinatário.
    ''' </summary>
    Private _vICMSUFDest As String
    Public Property vICMSUFDest() As String
        Get
            Return _vICMSUFDest
        End Get
        Set(ByVal value As String)
            _vICMSUFDest = value
        End Set
    End Property

    ''' <summary>
    ''' Valor do ICMS de partilha para a UF do remetente. Nota: A partir de 2019, este valor será zero.
    ''' </summary>
    Private _vICMSUFRemet As String
    Public Property vICMSUFRemet() As String
        Get
            Return _vICMSUFRemet
        End Get
        Set(ByVal value As String)
            _vICMSUFRemet = value
        End Set
    End Property
End Class
