Imports System


Public Class infCanc
    Private m_Id As String
    Private m_tpAmb As String
    Private m_verAplic As String
    Private m_cStat As Integer
    Private m_xMotivo As String
    Private m_cuf As String
    Private m_chNFe As String
    Private m_dhRecbto As DateTime
    Private m_nProt As String

    Public Property Id As String
        Get
            Return Me.m_Id
        End Get
        Set(ByVal value As String)
            Me.m_Id = value
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

    Public Property cUF As String
        Get
            Return Me.m_cuf
        End Get
        Set(ByVal value As String)
            Me.m_cuf = value
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

    Public Property dhRecbto As DateTime
        Get
            Return Me.m_dhRecbto
        End Get
        Set(ByVal value As DateTime)
            Me.m_dhRecbto = value
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
End Class

