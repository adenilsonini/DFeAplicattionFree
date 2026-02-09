Imports System.Xml.Serialization


Public Class protNFe
    Private m_versao As String
    Private m_infProt As infProt

    <XmlAttribute>
    Public Property versao As String
        Get
            Return Me.m_versao
        End Get
        Set(ByVal value As String)
            Me.m_versao = value
        End Set
    End Property

    Public Property infProt As infProt
        Get
            Return Me.m_infProt
        End Get
        Set(ByVal value As infProt)
            Me.m_infProt = value
        End Set
    End Property
End Class

