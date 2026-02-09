Imports System.Xml.Serialization


    <XmlRoot(DataType:="string", ElementName:="infEvento")>
    Public Class infEventoRet
        Private m_tpAmb As String
        Private m_verAplic As String
        Private m_cOrgao As String
        Private m_cStat As String
        Private m_xMotivo As String
        Private m_chNFe As String
        Private m_tpEvento As String
        Private m_xEvento As String
        Private m_nSeqEvento As String
        Private m_cOrgaoAutor As String
        Private m_CNPJDest As String
        Private m_CPFDest As String
        Private m_emailDest As String
        Private m_dhRegEvento As String
        Private m_nProt As String

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

        Public Property cOrgao As String
            Get
                Return Me.m_cOrgao
            End Get
            Set(ByVal value As String)
                Me.m_cOrgao = value
            End Set
        End Property

        Public Property cStat As String
            Get
                Return Me.m_cStat
            End Get
            Set(ByVal value As String)
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

        Public Property chNFe As String
            Get
                Return Me.m_chNFe
            End Get
            Set(ByVal value As String)
                Me.m_chNFe = value
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

        Public Property xEvento As String
            Get
                Return Me.m_xEvento
            End Get
            Set(ByVal value As String)
                Me.m_xEvento = value
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

        Public Property cOrgaoAutor As String
            Get
                Return Me.m_cOrgaoAutor
            End Get
            Set(ByVal value As String)
                Me.m_cOrgaoAutor = value
            End Set
        End Property

        Public Property CNPJDest As String
            Get
                Return Me.m_CNPJDest
            End Get
            Set(ByVal value As String)
                Me.m_CNPJDest = value
            End Set
        End Property

        Public Property CPFDest As String
            Get
                Return Me.m_CPFDest
            End Get
            Set(ByVal value As String)
                Me.m_CPFDest = value
            End Set
        End Property

        Public Property emailDest As String
            Get
                Return Me.m_emailDest
            End Get
            Set(ByVal value As String)
                Me.m_emailDest = value
            End Set
        End Property

        Public Property dhRegEvento As String
            Get
                Return Me.m_dhRegEvento
            End Get
            Set(ByVal value As String)
                Me.m_dhRegEvento = value
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

