''' <summary>
''' TAG do grupo de COFINS Substituição Tributária
''' </summary>
Public Class COFINSST
    ''' <summary>
    ''' Informar campos para cálculo do COFINS Substituição Tributária em percentual (T02 e T03) ou campos
    ''' para COFINS em valor (T04 e T05).
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
    Private _pCOFINS As String
    Public Property pCOFINS() As String
        Get
            Return _pCOFINS
        End Get
        Set(ByVal value As String)
            _pCOFINS = value
        End Set
    End Property
    Private _qBCProd As String
    Public Property qBCProd() As String
        Get
            Return _qBCProd
        End Get
        Set(ByVal value As String)
            _qBCProd = value
        End Set
    End Property
    Private _vAliqProd As String
    Public Property vAliqProd() As String
        Get
            Return _vAliqProd
        End Get
        Set(ByVal value As String)
            _vAliqProd = value
        End Set
    End Property
    Private _vCOFINS As String
    Public Property vCOFINS() As String
        Get
            Return _vCOFINS
        End Get
        Set(ByVal value As String)
            _vCOFINS = value
        End Set
    End Property
End Class