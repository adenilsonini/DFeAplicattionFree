''' <summary>
''' TAG do grupo do ISSQN
''' Informar os campos para cálculo do ISSQN nas NFe conjugadas, onde há a prestação de serviços
''' sujeitos ao ISSQN e fornecimento de peças sujeitas ao ICMS
''' </summary>
Public Class ISSQN
    Private _vBC As String
    Public Property vBC() As String
        Get
            Return _vBC
        End Get
        Set(ByVal value As String)
            _vBC = value
        End Set
    End Property
    Private _vAliq As String
    Public Property vAliq() As String
        Get
            Return _vAliq
        End Get
        Set(ByVal value As String)
            _vAliq = value
        End Set
    End Property
    Private _vISSQN As String
    Public Property vISSQN() As String
        Get
            Return _vISSQN
        End Get
        Set(ByVal value As String)
            _vISSQN = value
        End Set
    End Property
    ''' <summary>
    ''' Informar o município de ocorrência do fato gerador do ISSQN. Utilizar
    ''' a Tabela do IBGE (Anexo IV - Tabela de UF, Município e País)
    ''' </summary>
    Private _cMunFG As Integer
    Public Property cMunFG() As Integer
        Get
            Return _cMunFG
        End Get
        Set(ByVal value As Integer)
            _cMunFG = value
        End Set
    End Property
    ''' <summary>
    ''' Informar o código da lista de serviços da LC 116/03 em que se
    ''' classifica o serviço.
    ''' </summary>
    Private _cListServ As String
    Public Property cListServ() As String
        Get
            Return _cListServ
        End Get
        Set(ByVal value As String)
            _cListServ = value
        End Set
    End Property
End Class