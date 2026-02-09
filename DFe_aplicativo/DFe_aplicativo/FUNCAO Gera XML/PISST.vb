''' <summary>
''' TAG do grupo de PIS Substituição Tributária
''' </summary>
Public Class PISST
    ''' <summary>
    ''' Informar campos para cálculo do PIS em percentual (R02 e R03) ou campos para PIS em valor (R04 e R05).
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
    Private _pPIS As String
    Public Property pPIS() As String
        Get
            Return _pPIS
        End Get
        Set(ByVal value As String)
            _pPIS = value
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
    Private _vPIS As String
    Public Property vPIS() As String
        Get
            Return _vPIS
        End Get
        Set(ByVal value As String)
            _vPIS = value
        End Set
    End Property
End Class
