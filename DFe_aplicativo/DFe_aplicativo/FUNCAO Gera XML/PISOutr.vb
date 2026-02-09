''' <summary>
''' TAG do grupo de PIS Outras Operações
''' CST = 99
''' </summary>
Public Class PISOutr
    ''' <summary>
    ''' 99 - Outras Operações;
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
    ''' Informar campos para cálculo do PIS em percentual (P07 e P08) ou campos para PIS em valor (P10 e P11).
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