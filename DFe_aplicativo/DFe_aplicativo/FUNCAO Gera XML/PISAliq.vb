Public Class PISAliq
    ''' <summary>
    ''' Código de situação tributária do PIS
    ''' 01 – Operação Tributável (base de cálculo = valor da operação alíquota normal (cumulativo/não cumulativo));
    ''' 02 - Operação Tributável (base de cálculo = valor da operação(alíquota diferenciada));
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
    ''' Valor da Base de Cálculo do PIS
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
    ''' Alíquota do PIS (em percentual)
    ''' </summary>
    Private _pPIS As String
    Public Property pPIS() As String
        Get
            Return _pPIS
        End Get
        Set(ByVal value As String)
            _pPIS = value
        End Set
    End Property
    ''' <summary>
    ''' Valor do PIS
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
End Class