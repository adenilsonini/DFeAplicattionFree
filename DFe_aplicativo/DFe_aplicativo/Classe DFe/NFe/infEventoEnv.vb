Imports Microsoft.VisualBasic.CompilerServices
Imports System.Xml.Serialization


Public Class infEventoEnv
    Private m_Id As String
    Private m_cOrgao As String
    Private m_tpAmb As String
    Private m_CNPJ As String
    Private m_CPF As String
    Private m_chNFe As String
    Private m_dhEvento As String
    Private m_tpEvento As String
    Private m_nSeqEvento As String
    Private m_verEvento As String
    Private m_detEvento As detEvento

    <XmlAttribute>
    Public Property Id As String
        Get
            Return Me.m_Id
        End Get
        Set(ByVal value As String)
            Me.m_Id = value
        End Set
    End Property

    Public Property cOrgao As String
        Get
            Return Me.m_cOrgao
        End Get
        Set(ByVal value As String)
            Me.m_cOrgao = value
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

    Public Property CNPJ As String
        Get
            Return Me.m_CNPJ
        End Get
        Set(ByVal value As String)
            Me.m_CNPJ = value
        End Set
    End Property

    Public Function ShouldSerializeCNPJ() As Boolean
        If Me.CNPJ IsNot Nothing Then Return CUInt(Operators.CompareString(Me.CNPJ, String.Empty, False)) > 0UI
        Return False
    End Function

    Public Property CPF As String
        Get
            Return Me.m_CPF
        End Get
        Set(ByVal value As String)
            Me.m_CPF = value
        End Set
    End Property

    Public Function ShouldSerializeCPF() As Boolean
        If Me.CPF IsNot Nothing Then Return CUInt(Operators.CompareString(Me.CPF, String.Empty, False)) > 0UI
        Return False
    End Function

    Public Property chNFe As String
        Get
            Return Me.m_chNFe
        End Get
        Set(ByVal value As String)
            Me.m_chNFe = value
        End Set
    End Property

    Public Property dhEvento As String
        Get
            Return Me.m_dhEvento
        End Get
        Set(ByVal value As String)
            Me.m_dhEvento = value
        End Set
    End Property

    Public Property tpEvento As String
        Get
            Return Me.m_tpEvento
        End Get
        Set(ByVal value As String)
            Me.m_tpEvento = value
        End Set
    End Property

    Public Property nSeqEvento As String
        Get
            Return Me.m_nSeqEvento
        End Get
        Set(ByVal value As String)
            Me.m_nSeqEvento = value
        End Set
    End Property

    Public Property verEvento As String
        Get
            Return Me.m_verEvento
        End Get
        Set(ByVal value As String)
            Me.m_verEvento = value
        End Set
    End Property

    Public Property detEvento As detEvento
        Get
            Return Me.m_detEvento
        End Get
        Set(ByVal value As detEvento)
            Me.m_detEvento = value
        End Set
    End Property

    Public Sub New()
        Me.detEvento = New detEvento()
    End Sub
End Class

