Imports System.Xml.Serialization

<XmlRoot(DataType:="string", ElementName:="retConsSitNFe", [Namespace]:="http://www.portalfiscal.inf.br/nfe")>
Public Class retConsSitNFe
    Private m_versao As String
    Private m_tpAmb As String
    Private m_verAplic As String
    Private m_cStat As String
    Private m_xMotivo As String
    Private m_cUF As String
    Private m_dhRecbto As String
    Private m_chNFe As String
    Private m_protNFe As protNFe
    Private m_procEventoNFe As List(Of procEventoNFe)
    Private m_retCancNFe As retCancNFe

    <XmlAttribute>
    Public Property versao As String
        Get
            Return Me.m_versao
        End Get
        Set(ByVal value As String)
            Me.m_versao = value
        End Set
    End Property

    Public Property tpAmb As String
        Get
            Return Me.m_tpAmb
        End Get
        Set(ByVal value As String)
            Me.m_tpAmb = value
        End Set
    End Property

    Public Property verAplic As String
        Get
            Return Me.m_verAplic
        End Get
        Set(ByVal value As String)
            Me.m_verAplic = value
        End Set
    End Property

    Public Property cStat As String
        Get
            Return Me.m_cStat
        End Get
        Set(ByVal value As String)
            Me.m_cStat = value
        End Set
    End Property

    Public Property xMotivo As String
        Get
            Return Me.m_xMotivo
        End Get
        Set(ByVal value As String)
            Me.m_xMotivo = value
        End Set
    End Property

    Public Property cUF As String
        Get
            Return Me.m_cUF
        End Get
        Set(ByVal value As String)
            Me.m_cUF = value
        End Set
    End Property

    Public Property dhRecbto As String
        Get
            Return Me.m_dhRecbto
        End Get
        Set(ByVal value As String)
            Me.m_dhRecbto = value
        End Set
    End Property

    Public Property chNFe As String
        Get
            Return Me.m_chNFe
        End Get
        Set(ByVal value As String)
            Me.m_chNFe = value
        End Set
    End Property

    Public Property protNFe As protNFe
        Get
            Return Me.m_protNFe
        End Get
        Set(ByVal value As protNFe)
            Me.m_protNFe = value
        End Set
    End Property

    <XmlElement("procEventoNFe")>
    Public Property procEventoNFe As List(Of procEventoNFe)
        Get
            Return Me.m_procEventoNFe
        End Get
        Set(ByVal value As List(Of procEventoNFe))
            Me.m_procEventoNFe = value
        End Set
    End Property

    <XmlElement("retCancNFe")>
    Public Property retCancNFe As retCancNFe
        Get
            Return Me.m_retCancNFe
        End Get
        Set(ByVal value As retCancNFe)
            Me.m_retCancNFe = value
        End Set
    End Property
End Class
