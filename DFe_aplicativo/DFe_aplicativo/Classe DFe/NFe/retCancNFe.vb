Imports System.Xml.Serialization


Public Class retCancNFe
    Private m_versao As String
    Private m_infCanc As infCanc

    <XmlAttribute>
    Public Property versao As String
        Get
            Return Me.m_versao
        End Get
        Set(ByVal value As String)
            Me.m_versao = value
        End Set
    End Property

    Public Property infCanc As infCanc
        Get
            Return Me.m_infCanc
        End Get
        Set(ByVal value As infCanc)
            Me.m_infCanc = value
        End Set
    End Property
End Class

