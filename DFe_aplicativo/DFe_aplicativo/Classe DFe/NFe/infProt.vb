Imports System
Imports System.Security.Cryptography.Xml


Public Class infProt
    Private m_Id As String
    Private m_tpAmb As String
    Private m_verAplic As String
    Private m_chNFe As String
    Private m_dhRecbto As DateTime
    Private m_nProt As String
    Private m_digVal As String
    Private m_cStat As Integer
    Private m_xMotivo As String
    Private m_Signature As Signature

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

    Public Property digVal As String
        Get
            Return Me.m_digVal
        End Get
        Set(ByVal value As String)
            Me.m_digVal = value
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

    Public Property Signature As Signature
        Get
            Return Me.m_Signature
        End Get
        Set(ByVal value As Signature)
            Me.m_Signature = value
        End Set
    End Property
End Class
