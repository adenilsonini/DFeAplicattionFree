Imports Microsoft.Owin.StaticFiles
Imports Microsoft.Owin.StaticFiles.ContentTypes
Imports Newtonsoft.Json.Serialization
Imports Owin
Imports System.Linq
Imports System.Net.Http.Formatting
Imports System.Web.Http
Public Class Startup
    Public Sub Configuration(ByVal app As IAppBuilder)
        Dim httpConfiguration As HttpConfiguration = New HttpConfiguration()
        Me.ManipularRequisicaoHttp(httpConfiguration)
        app.UseWebApi(httpConfiguration)
        Dim fileServerOptions As FileServerOptions = New FileServerOptions()
        fileServerOptions.EnableDirectoryBrowsing = True
        fileServerOptions.EnableDefaultFiles = True
        fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("index.html")
        fileServerOptions.StaticFileOptions.ContentTypeProvider = CType(New Startup.CustomContentTypeProvider(), IContentTypeProvider)
        Dim options As FileServerOptions = fileServerOptions
        app.UseFileServer(options)

    End Sub

    Private Sub ManipularRequisicaoHttp(ByVal config As HttpConfiguration)
        config.MapHttpAttributeRoutes()
        config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", CObj(New With {Key .id = RouteParameter.[Optional]}))
        config.Formatters.OfType(Of JsonMediaTypeFormatter)().First()

        'config.Formatters.OfType(Of JsonMediaTypeFormatter)().First(Of JsonMediaTypeFormatter)().SerializerSettings.ContractResolver = CType(New CamelCasePropertyNamesContractResolver(), IContractResolver)
    End Sub

    Public Class CustomContentTypeProvider
        Inherits FileExtensionContentTypeProvider

        Public Sub New()
            Me.Mappings.Add(".json", "application/json")
        End Sub
    End Class
End Class
