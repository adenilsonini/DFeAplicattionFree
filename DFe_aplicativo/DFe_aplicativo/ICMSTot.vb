''' <summary>
''' TAG de grupo de Valores Totais referentes ao ICMS
''' </summary>
Public Class ICMSTot
    ''' <summary>
    ''' Base de Cálculo do ICMS
    ''' </summary>
    Private _vBC As String
    <Obrigatorio()> _
    Public Property vBC() As String
        Get
            Return _vBC
        End Get
        Set(ByVal value As String)
            _vBC = value
        End Set
    End Property
    ''' <summary>
    ''' Valor Total do ICMS
    ''' </summary>
    Private _vICMS As String
    <Obrigatorio()> _
    Public Property vICMS() As String
        Get
            Return _vICMS
        End Get
        Set(ByVal value As String)
            _vICMS = value
        End Set
    End Property

    ''' <summary>
    ''' Valor Total do ICMS desonerado
    ''' </summary>
    Private _vICMSDeson As String
    <Obrigatorio()> _
    Public Property vICMSDeson() As String
        Get
            Return _vICMSDeson
        End Get
        Set(ByVal value As String)
            _vICMSDeson = value
        End Set
    End Property


    ''' <summary>
    ''' Valor total do ICMS relativo ao Fundo de Combate à Pobreza (FCP) para a UF de destino.
    ''' </summary>
    Private _vFCPUFDest As String
    <Obrigatorio()> _
    Public Property vFCPUFDest() As String
        Get
            Return _vFCPUFDest
        End Get
        Set(ByVal value As String)
            _vFCPUFDest = value
        End Set
    End Property

    ''' <summary>
    '''Valor total do ICMS de partilha para a UF do destinatário
    ''' </summary>
    Private _vICMSUFDest As String
    <Obrigatorio()> _
    Public Property vICMSUFDest() As String
        Get
            Return _vICMSUFDest
        End Get
        Set(ByVal value As String)
            _vICMSUFDest = value
        End Set
    End Property


    ''' <summary>
    '''Valor total do ICMS de partilha para a UF do remetente
    ''' </summary>
    Private _vICMSUFRemet As String
    <Obrigatorio()> _
    Public Property vICMSUFRemet() As String
        Get
            Return _vICMSUFRemet
        End Get
        Set(ByVal value As String)
            _vICMSUFRemet = value
        End Set
    End Property

    ''' <summary>
    ''' Valor Total do FCP (Fundo de Combate à Pobreza).
    ''' </summary>
    Private _vFCP As String
    <Obrigatorio()>
    Public Property vFCP() As String
        Get
            Return _vFCP
        End Get
        Set(ByVal value As String)
            _vFCP = value
        End Set
    End Property

    ''' <summary>
    ''' Base de Cálculo do ICMS ST
    ''' </summary>
    Private _vBCST As String
    <Obrigatorio()> _
    Public Property vBCST() As String
        Get
            Return _vBCST
        End Get
        Set(ByVal value As String)
            _vBCST = value
        End Set
    End Property
    ''' <summary>
    ''' Valor Total do ICMS ST
    ''' </summary>
    Private _vST As String
    <Obrigatorio()> _
    Public Property vST() As String
        Get
            Return _vST
        End Get
        Set(ByVal value As String)
            _vST = value
        End Set
    End Property

    ''' <summary>
    ''' Valor Total do FCP (Fundo de Combate à Pobreza) retido por substituição tributária.
    ''' </summary>
    Private _vFCPST As String
    <Obrigatorio()>
    Public Property vFCPST() As String
        Get
            Return _vFCPST
        End Get
        Set(ByVal value As String)
            _vFCPST = value
        End Set
    End Property

    ''' <summary>
    ''' Valor Total do FCP (Fundo de Combate à Pobreza) retido anteriormente por substituição tributária.
    ''' </summary>
    Private _vFCPSTRet As String
    <Obrigatorio()>
    Public Property vFCPSTRet() As String
        Get
            Return _vFCPSTRet
        End Get
        Set(ByVal value As String)
            _vFCPSTRet = value
        End Set
    End Property

    ''' <summary>
    ''' Valor Total dos produtos e serviços
    ''' </summary>
    Private _vProd As String
    <Obrigatorio()> _
    Public Property vProd() As String
        Get
            Return _vProd
        End Get
        Set(ByVal value As String)
            _vProd = value
        End Set
    End Property
    ''' <summary>
    ''' Valor Total do Frete
    ''' </summary>
    Private _vFrete As String
    <Obrigatorio()> _
    Public Property vFrete() As String
        Get
            Return _vFrete
        End Get
        Set(ByVal value As String)
            _vFrete = value
        End Set
    End Property
    ''' <summary>
    ''' Valor Total do Seguro
    ''' </summary>
    Private _vSeg As String
    <Obrigatorio()> _
    Public Property vSeg() As String
        Get
            Return _vSeg
        End Get
        Set(ByVal value As String)
            _vSeg = value
        End Set
    End Property
    ''' <summary>
    ''' Valor Total do Desconto
    ''' </summary>
    Private _vDesc As String
    <Obrigatorio()> _
    Public Property vDesc() As String
        Get
            Return _vDesc
        End Get
        Set(ByVal value As String)
            _vDesc = value
        End Set
    End Property
    ''' <summary>
    ''' Valor Total do II
    ''' </summary>
    Private _vII As String
    <Obrigatorio()> _
    Public Property vII() As String
        Get
            Return _vII
        End Get
        Set(ByVal value As String)
            _vII = value
        End Set
    End Property
    ''' <summary>
    ''' Valor Total do IPI
    ''' </summary>
    Private _vIPI As String
    <Obrigatorio()> _
    Public Property vIPI() As String
        Get
            Return _vIPI
        End Get
        Set(ByVal value As String)
            _vIPI = value
        End Set
    End Property

    ''' <summary>
    ''' Valor Total do IPI devolvido. Deve ser informado quando preenchido o Grupo Tributos Devolvidos na emissão de nota finNFe=4 (devolução) nas operações com não contribuintes do IPI. Corresponde ao total da soma dos campos id: UA04.
    ''' </summary>
    Private _vIPIDevol As String
    <Obrigatorio()>
    Public Property vIPIDevol() As String
        Get
            Return _vIPIDevol
        End Get
        Set(ByVal value As String)
            _vIPIDevol = value
        End Set
    End Property
    ''' <summary>
    ''' Valor Total do PIS
    ''' </summary>
    Private _vPIS As String
    <Obrigatorio()> _
    Public Property vPIS() As String
        Get
            Return _vPIS
        End Get
        Set(ByVal value As String)
            _vPIS = value
        End Set
    End Property
    ''' <summary>
    ''' Valor total do COFINS
    ''' </summary>
    Private _vCOFINS As String
    <Obrigatorio()> _
    Public Property vCOFINS() As String
        Get
            Return _vCOFINS
        End Get
        Set(ByVal value As String)
            _vCOFINS = value
        End Set
    End Property
    ''' <summary>
    ''' Outras Despesas acessórias
    ''' </summary>
    Private _vOutro As String
    <Obrigatorio()> _
    Public Property vOutro() As String
        Get
            Return _vOutro
        End Get
        Set(ByVal value As String)
            _vOutro = value
        End Set
    End Property
    ''' <summary>
    ''' Valor total da NFE
    ''' </summary>
    Private _vNF As String
    <Obrigatorio()> _
    Public Property vNF() As String
        Get
            Return _vNF
        End Get
        Set(ByVal value As String)
            _vNF = value
        End Set
    End Property

    ''' <summary>
    ''' Valor aproximado total de tributos federais, estaduais e municipais
    ''' </summary>
    Private _vTotTrib As String
    <Obrigatorio()> _
    Public Property vTotTrib() As String
        Get
            Return _vTotTrib
        End Get
        Set(ByVal value As String)
            _vTotTrib = value
        End Set
    End Property
End Class