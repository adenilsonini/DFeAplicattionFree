''' <summary>
''' TAG do grupo de COFINS outras operações
''' CST = 99
''' </summary>
Public Class COFINSOutr
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
    ''' Informar campos para cálculo do COFINS em percentual (S07 e S08) ou campos para COFINS em valor (S09 e S10).
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