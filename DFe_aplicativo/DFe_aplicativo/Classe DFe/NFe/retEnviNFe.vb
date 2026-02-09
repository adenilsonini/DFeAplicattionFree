
Imports Microsoft.VisualBasic
Imports System
Imports System.Runtime.InteropServices
Imports System.Xml.Serialization



<XmlRoot(DataType:="string", ElementName:="retEnviNFe", [Namespace]:="http://www.portalfiscal.inf.br/nfe")>
Public Class retEnviNFe

    Private m_versao As String
    Private m_tpAmb As String
    Private m_verAplic As String
    Private m_cStat As String
    Private m_xMotivo As String
    Private m_cUF As String
    Private m_dhRecbto As DateTime
    Private m_infRec As infRec
    Private m_protNFe As protNFe

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

    Public Property dhRecbto As DateTime
        Get
            Return Me.m_dhRecbto
        End Get
        Set(ByVal value As DateTime)
            Me.m_dhRecbto = value
        End Set
    End Property

    Public Property infRec As infRec
        Get
            Return Me.m_infRec
        End Get
        Set(ByVal value As infRec)
            Me.m_infRec = value
        End Set
    End Property

    <XmlElement("")>
    Public Property protNFe As protNFe
        Get
            Return Me.m_protNFe
        End Get
        Set(ByVal value As protNFe)
            Me.m_protNFe = value
        End Set
    End Property

    Public Sub New()
        Me.infRec = New infRec()
        Me.protNFe = New protNFe()
    End Sub


End Class

