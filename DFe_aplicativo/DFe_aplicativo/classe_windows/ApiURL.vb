Imports System
Imports System.Diagnostics

Public MustInherit Class ApiURL
    Public Shared Function GetTasksUri() As String
        Return String.Format("http://{0}/api/v2/tasks.json", CObj(ApiURL.GetHost()))
    End Function

    Public Shared Function LicenseCustomerInfoUri() As String
        Return "http://" & ApiURL.GetHost() & "/api/v1/license/{0}/customer_info"
    End Function

    Public Shared Function LicenseGenerateUri() As String
        Return String.Format("http://{0}/api/v1/license/generate", CObj(ApiURL.GetHost()))
    End Function

    Public Shared Function CheckServerRegisterUri() As String
        Return "http://" & ApiURL.GetHost() & "/api/v1/server_authorization/{0}/{1}/check"
    End Function

    Public Shared Function GetCustomerMonitoringUri() As String
        Return "http://" & ApiURL.GetHost() & "/api/v1/customer_monitorings"
    End Function

    Public Shared Function GetApplicationsUpdateUri() As String
        Return "http://" & ApiURL.GetHost() & "/api/v1/solution_versions/available_versions"
    End Function

    Public Shared Function GetCustomerVersionMonitoringUri(ByVal cnpj As String) As String
        Return "http://" & ApiURL.GetHost() & "/api/v1/customer_version_solutions/" & cnpj
    End Function

    Public Shared Function GetMonitorUpdateUri() As String
        Return "http://" & ApiURL.GetHost() & "/api/v1/solution_versions/available_versions"
    End Function

    Public Shared Function GetErrorMessagesUri() As String
        Return "http://" & ApiURL.GetHost() & "/api/v1/error_messages"
    End Function

    Public Shared Function GetAnnouncementsUri() As String
        Return "http://" & ApiURL.GetHost() & "/api/v1/announcements"
    End Function

    Public Shared Function GetBackgroundsUri() As String
        Return "http://" & ApiURL.GetHost() & "/api/v1/solution_backgrounds"
    End Function

    Public Shared Function GetKnowledgeBasesUri() As String
        Return "http://" & ApiURL.GetHost() & "/api/v1/knowledge_bases"
    End Function

    Public Shared Function GetHealthCheckUri() As String
        Return "http://" & ApiURL.GetHost() & "/api/v1/health_check"
    End Function

    Private Shared Function GetHost() As String
        Return "ioty.linearsistemas.com.br"
    End Function

    Public Shared Function ScanntechUrl(ByVal url As String, ByVal idEmpresa As Long, Optional ByVal toLower As Boolean = True) As String
        url = If(Not toLower, url.Replace("{idempresa}", Convert.ToString(idEmpresa)), url.ToLower().Replace("{idempresa}", Convert.ToString(idEmpresa)))
        Return url
    End Function

    Public Shared Function ScanntechUrl(ByVal url As String, ByVal idEmpresa As Long, ByVal codigoProduto As Long, Optional ByVal toLower As Boolean = True) As String
        url = ApiURL.ScanntechUrl(url, idEmpresa, toLower).Replace("{codigoproduto}", Convert.ToString(codigoProduto))
        Return url
    End Function

    Public Shared Function ScanntechUrl(ByVal url As String, ByVal idEmpresa As Long, ByVal codigoProduto As Long, ByVal codigoBarra As String, Optional ByVal toLower As Boolean = True) As String
        url = ApiURL.ScanntechUrl(url, idEmpresa, codigoProduto, toLower).Replace("{codigobarra}", Convert.ToString(codigoBarra))
        Return url
    End Function

    Public Shared Function ScanntechUrl(ByVal url As String, ByVal idEmpresa As Long, ByVal codigoProduto As Long, ByVal idLocal As Long, Optional ByVal toLower As Boolean = True) As String
        url = ApiURL.ScanntechUrl(url, idEmpresa, codigoProduto, toLower).Replace("{idlocal}", Convert.ToString(idLocal))
        Return url
    End Function

    Public Shared Function ScanntechUrlPromocao(ByVal url As String, ByVal idEmpresa As Long, ByVal idLocal As Long, ByVal estadoPromocao As String, Optional ByVal toLower As Boolean = False) As String
        url = ApiURL.ScanntechUrl(url, idEmpresa, 0L, idLocal, toLower).Replace("{estado}", estadoPromocao)
        Return url
    End Function

    Public Shared Function GetScanntechHost() As String
        Return If(Not Debugger.IsAttached, "http://parceiro.scanntech.com", "http://test.parceiro.scanntech.com")
    End Function
End Class

