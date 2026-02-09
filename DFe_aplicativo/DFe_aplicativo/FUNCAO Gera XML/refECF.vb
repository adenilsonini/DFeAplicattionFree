''' <summary>
''' Grupo com as informações das NF referenciadas Idem a informação da TAG anterior, referenciando
''' uma Nota Fiscal modelo 1/1A normal (a NF referenciada não é uma NF-e).
''' </summary>
Public Class refECF
    
    ''' <summary>
    ''' Código do modelo do Documento Fiscal Preencher com "2B", quando se tratar de Cupom Fiscal emitido por máquina registradora (não ECF), com "2C", quando se tratar de Cupom Fiscal PDV, ou "2D", quando se tratar de Cupom Fiscal (emitido por ECF)
    ''' </summary>
    Private _mod As String
    Public Property [mod]() As String
        Get
            Return _mod
        End Get
        Set(ByVal value As String)
            _mod = value
        End Set
    End Property
    ''' <summary>
    ''' Informar o número de ordem seqüencial do ECF que emitiu o Cupom Fiscal vinculado à NF-e
    ''' </summary>
    Private _nECF As String
    Public Property nECF() As String
        Get
            Return _nECF
        End Get
        Set(ByVal value As String)
            _nECF = value
        End Set
    End Property
    ''' <summary>
    ''' Informar o Número do Contador de Ordem de Operação - COO vinculado à NF-e
    ''' </summary>
    Private _nCOO As String
    Public Property nCOO() As String
        Get
            Return _nCOO
        End Get
        Set(ByVal value As String)
            _nCOO = value
        End Set
    End Property

End Class
