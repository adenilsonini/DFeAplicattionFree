
Public Class infRec
    Private m_nRec As String
    Private m_tMed As Integer

    Public Property nRec As String
        Get
            Return Me.m_nRec
        End Get
        Set(ByVal value As String)
            Me.m_nRec = value
        End Set
    End Property

    Public Property tMed As Integer
        Get
            Return Me.m_tMed
        End Get
        Set(ByVal value As Integer)
            Me.m_tMed = value
        End Set
    End Property
End Class

