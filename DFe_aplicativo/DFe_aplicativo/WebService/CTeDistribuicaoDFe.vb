Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization
'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0"), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code"), _
 System.Web.Services.WebServiceBindingAttribute(Name:="CTeDistribuicaoDFeSoap", [Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CTeDistribuicaoDFe")> _
Partial Public Class CTeDistribuicaoDFe
    Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

    Private cteDistDFeInteresseOperationCompleted As System.Threading.SendOrPostCallback

    Private useDefaultCredentialsSetExplicitly As Boolean

    '''<remarks/>
     Public Sub New(ByVal V_Url As String)
        MyBase.New()
        Me.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12
        Me.Url = V_Url
    End Sub

    Public Shadows Property Url() As String
        Get
            Return MyBase.Url
        End Get
        Set(value As String)
            If (((Me.IsLocalFileSystemWebService(MyBase.Url) = True) _
                        AndAlso (Me.useDefaultCredentialsSetExplicitly = False)) _
                        AndAlso (Me.IsLocalFileSystemWebService(value) = False)) Then
                MyBase.UseDefaultCredentials = False
            End If
            MyBase.Url = value
        End Set
    End Property

    Public Shadows Property UseDefaultCredentials() As Boolean
        Get
            Return MyBase.UseDefaultCredentials
        End Get
        Set(value As Boolean)
            MyBase.UseDefaultCredentials = value
            Me.useDefaultCredentialsSetExplicitly = True
        End Set
    End Property

    '''<remarks/>
    Public Event cteDistDFeInteresseCompleted As cteDistDFeInteresseCompletedEventHandler

    '''<remarks/>
    <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/cte/wsdl/CTeDistribuicaoDFe/cteDistDFeInteresse", RequestNamespace:="http://www.portalfiscal.inf.br/cte/wsdl/CTeDistribuicaoDFe", ResponseNamespace:="http://www.portalfiscal.inf.br/cte/wsdl/CTeDistribuicaoDFe", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)> _
    Public Function cteDistDFeInteresse(ByVal cteDadosMsg As System.Xml.XmlNode) As System.Xml.XmlNode
        Dim results() As Object = Me.Invoke("cteDistDFeInteresse", New Object() {cteDadosMsg})
        Return CType(results(0), System.Xml.XmlNode)
    End Function

    '''<remarks/>
    Public Overloads Sub cteDistDFeInteresseAsync(ByVal cteDadosMsg As System.Xml.XmlNode)
        Me.cteDistDFeInteresseAsync(cteDadosMsg, Nothing)
    End Sub

    '''<remarks/>
    Public Overloads Sub cteDistDFeInteresseAsync(ByVal cteDadosMsg As System.Xml.XmlNode, ByVal userState As Object)
        If (Me.cteDistDFeInteresseOperationCompleted Is Nothing) Then
            Me.cteDistDFeInteresseOperationCompleted = AddressOf Me.OncteDistDFeInteresseOperationCompleted
        End If
        Me.InvokeAsync("cteDistDFeInteresse", New Object() {cteDadosMsg}, Me.cteDistDFeInteresseOperationCompleted, userState)
    End Sub

    Private Sub OncteDistDFeInteresseOperationCompleted(ByVal arg As Object)
        If (Not (Me.cteDistDFeInteresseCompletedEvent) Is Nothing) Then
            Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
            RaiseEvent cteDistDFeInteresseCompleted(Me, New cteDistDFeInteresseCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
        End If
    End Sub

    '''<remarks/>
    Public Shadows Sub CancelAsync(ByVal userState As Object)
        MyBase.CancelAsync(userState)
    End Sub

    Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
        If ((url Is Nothing) _
                    OrElse (url Is String.Empty)) Then
            Return False
        End If
        Dim wsUri As System.Uri = New System.Uri(url)
        If ((wsUri.Port >= 1024) _
                    AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
            Return True
        End If
        Return False
    End Function
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")> _
Public Delegate Sub cteDistDFeInteresseCompletedEventHandler(ByVal sender As Object, ByVal e As cteDistDFeInteresseCompletedEventArgs)

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0"), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code")> _
Partial Public Class cteDistDFeInteresseCompletedEventArgs
    Inherits System.ComponentModel.AsyncCompletedEventArgs

    Private results() As Object

    Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
        MyBase.New(exception, cancelled, userState)
        Me.results = results
    End Sub

    '''<remarks/>
    Public ReadOnly Property Result() As System.Xml.XmlNode
        Get
            Me.RaiseExceptionIfNecessary()
            Return CType(Me.results(0), System.Xml.XmlNode)
        End Get
    End Property
End Class
