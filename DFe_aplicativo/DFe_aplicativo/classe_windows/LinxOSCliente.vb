
Imports System
Imports System.Runtime.Serialization
Imports System.IO
Imports System.Text


<DataContract>
Friend Class LinxOSCliente
    <DataMember(Name:="cg1_diaslic")>
    Public Property DiasLicenca As Integer
    <DataMember(Name:="license_available")>
    Public Property LicencaDisponivel As Boolean
    <DataMember(Name:="tiposglinx")>
    Public Property TipoSistema As Byte
    <DataMember(Name:="cg1_nfe")>
    Public Property CG1NFe As Byte
    <DataMember(Name:="cg1_licenca_somente_leitura")>
    Public Property LicencaSomenteLeitura As Boolean
    <DataMember(Name:="current_datetime")>
    Public Property CurrentDatetime As String

    <IgnoreDataMember>
    Public ReadOnly Property DataAtual As DateTime
        Get
            Return DateTime.Parse(Me.CurrentDatetime)
        End Get
    End Property

    Public Shared Function LocalizarWebService(ByVal cnpj As String) As LinxOSCliente
        Try
            Return DeserializeJSon(Of LinxOSCliente)(HttpRequest.[Get](String.Format(ApiURL.LicenseCustomerInfoUri(), CObj(cnpj))))
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function TipoSistemaFormatado() As Byte
        If Me.LicencaSomenteLeitura Then Return 7
        If Me.TipoSistema = CByte(0) AndAlso Me.CG1NFe = CByte(0) Then Return 1
        If Me.TipoSistema = CByte(0) AndAlso Me.CG1NFe = CByte(1) Then Return 4
        If Me.TipoSistema = CByte(1) AndAlso Me.CG1NFe = CByte(0) Then Return 2
        Return If(Me.TipoSistema = CByte(1) AndAlso Me.CG1NFe = CByte(1), CByte(5), CByte(0))
    End Function

    Public Shared Function DeserializeJSon(Of T)(ByVal jsonData As String) As T
        Try
            Return CType(New System.Runtime.Serialization.Json.DataContractJsonSerializer(GetType(T)).ReadObject(CType(New MemoryStream(Encoding.UTF8.GetBytes(jsonData)), Stream)), T)
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class

