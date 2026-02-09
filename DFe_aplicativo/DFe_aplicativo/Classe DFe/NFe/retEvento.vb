
Imports System.Xml.Serialization
Imports System.Security.Cryptography.Xml

<XmlRoot(DataType:="string", ElementName:="retEvento", [Namespace]:="http://www.portalfiscal.inf.br/nfe")>
Public Class retEvento
    Private m_versao As String
    Private m_infEvento As infEventoRet
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

    Public Property infEvento As infEventoRet
        Get
            Return Me.m_infEvento
        End Get
        Set(ByVal value As infEventoRet)
            Me.m_infEvento = value
        End Set
    End Property

    Public Property Signature As Signature
        Get
            Return Me.m_Signature
        End Get
        Set(ByVal value As Signature)
            Me.m_Signature = value
        End Set
    End Property

    Private Function ShouldSerializeSignature() As Boolean
        Return Me.Signature IsNot Nothing
    End Function

    Public Sub New()
        Me.infEvento = New infEventoRet()
        Me.Signature = New Signature()
    End Sub
End Class

