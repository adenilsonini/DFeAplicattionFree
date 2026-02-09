Imports System.Security.Cryptography.Xml
Imports System.Xml.Serialization


<XmlRoot(DataType:="string", ElementName:="evento", [Namespace]:="http://www.portalfiscal.inf.br/nfe")>
Public Class evento
    Private m_versao As String
    Private m_infEvento As infEventoEnv
    Private m_Signature As Signature

    <XmlAttribute>
    Public Property versao As String
        Get
            Return Me.m_versao
        End Get
        Set(ByVal value As String)
            Me.m_versao = value
        End Set
    End Property

    Public Property infEvento As infEventoEnv
        Get
            Return Me.m_infEvento
        End Get
        Set(ByVal value As infEventoEnv)
            Me.m_infEvento = value
        End Set
    End Property

    <XmlElement([Namespace]:="http://www.w3.org/2000/09/xmldsig#")>
    Public Property Signature As Signature
        Get
            Return Me.m_Signature
        End Get
        Set(ByVal value As Signature)
            Me.m_Signature = value
        End Set
    End Property
End Class

