Imports System.Xml.Serialization


Public Class detEvento
    Private m_versao As String
    Private m_descEvento As String
    Private m_cOrgaoAutor As String
    Private m_tpAutor As String
    Private m_verAplic As String
    Private m_nProt As String
    Private m_xJust As String
    Private m_chNFeRef As String
    Private m_xCorrecao As String
    Private m_xCondUso As String

    <XmlAttribute>
    Public Property versao As String
        Get
            Return Me.m_versao
        End Get
        Set(ByVal value As String)
            Me.m_versao = value
        End Set
    End Property

    Public Property descEvento As String
        Get
            Return Me.m_descEvento
        End Get
        Set(ByVal value As String)
            Me.m_descEvento = value
        End Set
    End Property

    Public Property cOrgaoAutor As String
        Get
            Return Me.m_cOrgaoAutor
        End Get
        Set(ByVal value As String)
            Me.m_cOrgaoAutor = value
        End Set
    End Property

    Public Property tpAutor As String
        Get
            Return Me.m_tpAutor
        End Get
        Set(ByVal value As String)
            Me.m_tpAutor = value
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

    Public Property nProt As String
        Get
            Return Me.m_nProt
        End Get
        Set(ByVal value As String)
            Me.m_nProt = value
        End Set
    End Property

    Public Property xJust As String
        Get
            Return Me.m_xJust
        End Get
        Set(ByVal value As String)
            Me.m_xJust = value
        End Set
    End Property

    Public Property chNFeRef As String
        Get
            Return Me.m_chNFeRef
        End Get
        Set(ByVal value As String)
            Me.m_chNFeRef = value
        End Set
    End Property

    Public Property xCorrecao As String
        Get
            Return Me.m_xCorrecao
        End Get
        Set(ByVal value As String)
            Me.m_xCorrecao = value
        End Set
    End Property

    Public Property xCondUso As String
        Get
            Return Me.m_xCondUso
        End Get
        Set(ByVal value As String)
            Me.m_xCondUso = value
        End Set
    End Property
End Class

