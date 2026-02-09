
'''<remarks/>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe"), _
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe", IsNullable:=False)> _
Partial Public Class retEnviNFe

    Private tpAmbField As String

    Private verAplicField As String

    Private cStatField As String

    Private xMotivoField As String

    Private cUFField As String

    Private dhRecbtoField As Date

    Private infRecField As retEnviNFeInfRec

    Private versaoField As String

    '''<remarks/>
    Public Property tpAmb() As String
        Get
            Return Me.tpAmbField
        End Get
        Set(value As String)
            Me.tpAmbField = value
        End Set
    End Property

    '''<remarks/>
    Public Property verAplic() As String
        Get
            Return Me.verAplicField
        End Get
        Set(value As String)
            Me.verAplicField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property cStat() As String
        Get
            Return Me.cStatField
        End Get
        Set(value As String)
            Me.cStatField = value
        End Set
    End Property

    '''<remarks/>
    Public Property xMotivo() As String
        Get
            Return Me.xMotivoField
        End Get
        Set(value As String)
            Me.xMotivoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property cUF() As String
        Get
            Return Me.cUFField
        End Get
        Set(value As String)
            Me.cUFField = value
        End Set
    End Property

    '''<remarks/>
    Public Property dhRecbto() As Date
        Get
            Return Me.dhRecbtoField
        End Get
        Set(value As Date)
            Me.dhRecbtoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property infRec() As retEnviNFeInfRec
        Get
            Return Me.infRecField
        End Get
        Set(value As retEnviNFeInfRec)
            Me.infRecField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As String
        Get
            Return Me.versaoField
        End Get
        Set(value As String)
            Me.versaoField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
Partial Public Class retEnviNFeInfRec

    Private nRecField As String

    Private tMedField As String

    '''<remarks/>
    Public Property nRec() As String
        Get
            Return Me.nRecField
        End Get
        Set(value As String)
            Me.nRecField = value
        End Set
    End Property

    '''<remarks/>
    Public Property tMed() As String
        Get
            Return Me.tMedField
        End Get
        Set(value As String)
            Me.tMedField = value
        End Set
    End Property
End Class


