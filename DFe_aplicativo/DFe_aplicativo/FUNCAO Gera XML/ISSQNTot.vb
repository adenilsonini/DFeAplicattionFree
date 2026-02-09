''' <summary>
''' TAG de grupo de Valores Totais referentes ao ISSQN
''' </summary>
Public Class ISSQNtot
    ''' <summary>
    ''' Valor Total dos Serviços sob não incidência ou não tributados pelo ICMS
    ''' </summary>
    Private _vServ As String
    Public Property vServ() As String
        Get
            Return _vServ
        End Get
        Set(ByVal value As String)
            _vServ = value
        End Set
    End Property
    ''' <summary>
    ''' Base de Cálculo do ISS
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
    ''' Valor Total do ISS
    ''' </summary>
    Private _vISS As String
    Public Property vISS() As String
        Get
            Return _vISS
        End Get
        Set(ByVal value As String)
            _vISS = value
        End Set
    End Property
    ''' <summary>
    ''' Valor do PIS sobre serviços
    ''' </summary>
    Private _vPIS As String
    Public Property vPIS() As String
        Get
            Return _vPIS
        End Get
        Set(ByVal value As String)
            _vPIS = value
        End Set
    End Property
    ''' <summary>
    ''' Valor do COFINS sobre serviços
    ''' </summary>
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