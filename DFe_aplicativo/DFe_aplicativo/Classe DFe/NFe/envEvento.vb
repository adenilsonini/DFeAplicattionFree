Imports System.Xml.Serialization


<XmlRoot(DataType:="string", ElementName:="envEvento", [Namespace]:="http://www.portalfiscal.inf.br/nfe")>
Public Class envEvento
    Private m_versao As String
    Private m_idLote As String
    Private m_evento As evento

    <XmlAttribute>
    Public Property versao As String
        Get
            Return Me.m_versao
        End Get
        Set(ByVal value As String)
            Me.m_versao = value
        End Set
    End Property

    Public Property idLote As String
        Get
            Return Me.m_idLote
        End Get
        Set(ByVal value As String)
            Me.m_idLote = value
        End Set
    End Property

    Public Property evento As evento
        Get
            Return Me.m_evento
        End Get
        Set(ByVal value As evento)
            Me.m_evento = value
        End Set
    End Property

    Public Sub New()
        Me.evento = New evento()
    End Sub
End Class

