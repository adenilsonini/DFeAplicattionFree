
Imports System.Collections.Generic
Imports System.Xml.Serialization


Public Class procEventoNFe
    Private m_versao As String
    Private m_evento As evento
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

    Public Property evento As evento
        Get
            Return Me.m_evento
        End Get
        Set(ByVal value As evento)
            Me.m_evento = value
        End Set
    End Property

    Public Property retEvento As List(Of retEvento)
        Get
            Return Me.m_retEvento
        End Get
        Set(ByVal value As List(Of retEvento))
            Me.m_retEvento = value
        End Set
    End Property
End Class

