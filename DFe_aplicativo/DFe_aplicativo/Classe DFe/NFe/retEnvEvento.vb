Imports System.Collections.Generic
Imports System.Xml.Serialization


<XmlRoot(DataType:="string", ElementName:="retEnvEvento", [Namespace]:="http://www.portalfiscal.inf.br/nfe")>
Public Class retEnvEvento
    Private m_versao As String
    Private m_idLote As Integer
    Private m_tpAmb As String
    Private m_verAplic As String
    Private m_cOrgao As String
    Private m_cStat As Integer
    Private m_xMotivo As String
    Private m_retEvento As List(Of retEvento)

    <XmlAttribute>
    Public Property versao As String
        Get
            Return Me.m_versao
        End Get
        Set(ByVal value As String)
            Me.m_versao = value
        End Set
    End Property

    Public Property idLote As Integer
        Get
            Return Me.m_idLote
        End Get
        Set(ByVal value As Integer)
            Me.m_idLote = value
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

    Public Property cOrgao As String
        Get
            Return Me.m_cOrgao
        End Get
        Set(ByVal value As String)
            Me.m_cOrgao = value
        End Set
    End Property

    Public Property cStat As Integer
        Get
            Return Me.m_cStat
        End Get
        Set(ByVal value As Integer)
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

    <XmlElement("retEvento")>
    Public Property retEvento As List(Of retEvento)
        Get
            Return Me.m_retEvento
        End Get
        Set(ByVal value As List(Of retEvento))
            Me.m_retEvento = value
        End Set
    End Property
End Class

