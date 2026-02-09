Imports System
Imports System.Xml.Serialization


Public Class infInutRet
    Private m_Id As String
    Private m_tpAmb As String
    Private m_verAplic As String
    Private m_cStat As Integer
    Private m_xMotivo As String
    Private m_cUF As String
    Private m_ano As Integer?
    Private m_CNPJ As String
    Private m_mod As String
    Private m_serie As Integer?
    Private m_nNFIni As Integer?
    Private m_nNFFin As Integer?
    Private m_dhRecbto As DateTime?
    Private m_nProt As String

    <XmlAttribute>
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
            Return Me.m_cUF
        End Get
        Set(ByVal value As String)
            Me.m_cUF = value
        End Set
    End Property

    Public Property ano As Integer?
        Get
            Return Me.m_ano
        End Get
        Set(ByVal value As Integer?)
            Me.m_ano = value
        End Set
    End Property

    Public Property CNPJ As String
        Get
            Return Me.m_CNPJ
        End Get
        Set(ByVal value As String)
            Me.m_CNPJ = value
        End Set
    End Property

    Public Property [mod] As String
        Get
            Return Me.m_mod
        End Get
        Set(ByVal value As String)
            Me.m_mod = value
        End Set
    End Property

    Public Property serie As Integer?
        Get
            Return Me.m_serie
        End Get
        Set(ByVal value As Integer?)
            Me.m_serie = value
        End Set
    End Property

    Public Property nNFIni As Integer?
        Get
            Return Me.m_nNFIni
        End Get
        Set(ByVal value As Integer?)
            Me.m_nNFIni = value
        End Set
    End Property

    Public Property nNFFin As Integer?
        Get
            Return Me.m_nNFFin
        End Get
        Set(ByVal value As Integer?)
            Me.m_nNFFin = value
        End Set
    End Property

    Public Property dhRecbto As DateTime?
        Get
            Return Me.m_dhRecbto
        End Get
        Set(ByVal value As DateTime?)
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

