
Imports Newtonsoft.Json
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading.Tasks


Module HttpRequest
    Function [Get](ByVal requestUri As String) As String
        Try
            Dim monitorConfig As MonitorConfig = New MonitorConfig()
            Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(requestUri), HttpWebRequest)
            httpWebRequest.Method = "GET"
            httpWebRequest.Accept = "application/json"
            httpWebRequest.Headers.Add("X-Auth-Token", "9e7b310821d7f8b129199d4d6b50642561af1f29")

            Using streamReader As StreamReader = New StreamReader(httpWebRequest.GetResponse().GetResponseStream())
                Return streamReader.ReadToEnd()
            End Using

        Catch ex As Exception
            Throw
        End Try
    End Function

    Function GetTarefasServidor(ByVal requestUri As String) As List(Of Tarefa)
        Try
            Dim monitorConfig As MonitorConfig = New MonitorConfig()
            requestUri += String.Format("?last_update={0}&cnpj={1}", CObj(Tarefa.RecuperaDataHoraUltimaAtualizacao()), CObj(DBHelper.RecuperaCnpj()))
            Dim tarefaList As List(Of Tarefa) = New List(Of Tarefa)()
            Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(requestUri), HttpWebRequest)
            httpWebRequest.Method = "GET"
            httpWebRequest.Accept = "application/json"
            httpWebRequest.Headers.Add("X-Auth-Token", "9e7b310821d7f8b129199d4d6b50642561af1f29")

            Using streamReader As StreamReader = New StreamReader(httpWebRequest.GetResponse().GetResponseStream())
                tarefaList = JsonConvert.DeserializeObject(Of List(Of Tarefa))(streamReader.ReadToEnd())
            End Using

            Return tarefaList
        Catch ex As Exception
            Throw
        End Try
    End Function

    Function ChecarRegistroServidor() As MonitorConfig
        'server_key = 8734f215dcf9c340c00c76904f7ba1876cfcd8db
        Try
            Dim monitorConfig As MonitorConfig = New MonitorConfig()
            If String.IsNullOrEmpty("8734f215dcf9c340c00c76904f7ba1876cfcd8db") Then Return monitorConfig
            Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(String.Format(ApiURL.CheckServerRegisterUri(), CObj(DBHelper.RecuperaCnpj()), CObj("8734f215dcf9c340c00c76904f7ba1876cfcd8db"))), HttpWebRequest)
            httpWebRequest.Method = "GET"
            httpWebRequest.Accept = "application/json"

            Using streamReader As StreamReader = New StreamReader(httpWebRequest.GetResponse().GetResponseStream())
                Return LinxOSCliente.DeserializeJSon(Of MonitorConfig)(streamReader.ReadToEnd())
            End Using

        Catch ex As Exception
            '  TrataErro.EscreverLog("Exception ChecarRegistroServidor")
            '   TrataErro.EscreverLog(ex.Message)
            Throw
        End Try
    End Function


    Function Post(ByVal postUri As String, ByVal jsonData As String) As String
        'token = 9e7b310821d7f8b129199d4d6b50642561af1f29
        Try
            Dim headers As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))() From {
                New KeyValuePair(Of String, String)("X-Auth-Token", "9e7b310821d7f8b129199d4d6b50642561af1f29")
            }

            Using streamReader As StreamReader = New StreamReader(HttpRequest.Request(postUri, jsonData, headers, "POST").GetResponseStream())
                Return streamReader.ReadToEnd()
            End Using

        Catch
            Throw
        End Try
    End Function

    Async Function PostAsync(ByVal postUri As String, ByVal jsonData As String) As Task(Of String)
        Dim endAsync As String

        Try
            Dim monitorConfig As MonitorConfig = New MonitorConfig()

            Using streamReader As StreamReader = New StreamReader((Await HttpRequest.RequestAsync(postUri, jsonData, New List(Of KeyValuePair(Of String, String))() From {
                New KeyValuePair(Of String, String)("X-Auth-Token", "9e7b310821d7f8b129199d4d6b50642561af1f29")
            }, "POST")).GetResponseStream())
                endAsync = Await streamReader.ReadToEndAsync()
            End Using

        Catch
            Throw
        End Try

        Return endAsync
    End Function

    <Obsolete("Método usado no módulo de armazenagem de XMLs que foi descontinuado.")>
    Function Post(ByVal postUri As String, ByVal jsonData As String, ByVal headers As List(Of KeyValuePair(Of String, String))) As String
        Try
            Dim monitorConfig As MonitorConfig = New MonitorConfig()

            Using streamReader As StreamReader = New StreamReader(HttpRequest.Request(postUri, jsonData, headers, "POST").GetResponseStream())
                Return streamReader.ReadToEnd()
            End Using

        Catch ex As Exception
            Throw
        End Try
    End Function

    Function Request(ByVal postUri As String, ByVal jsonData As String, ByVal headers As List(Of KeyValuePair(Of String, String)), ByVal method As String) As HttpWebResponse
        Dim response As HttpWebResponse

        Try
            Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(postUri), HttpWebRequest)
            httpWebRequest.ContentType = "application/json; charset=utf-8"
            httpWebRequest.Accept = "application/json "
            httpWebRequest.Method = method

            For Each header As KeyValuePair(Of String, String) In headers
                httpWebRequest.Headers.Add(header.Key, header.Value)
            Next

            If Not String.IsNullOrEmpty(jsonData) Then

                Using streamWriter As StreamWriter = New StreamWriter(httpWebRequest.GetRequestStream())
                    streamWriter.Write(jsonData)
                    streamWriter.Flush()
                End Using
            End If

            Dim now1 As DateTime = DateTime.Now
            response = CType(httpWebRequest.GetResponse(), HttpWebResponse)
            Dim now2 As DateTime = DateTime.Now
            Dim timeSpan As TimeSpan = now2 - now1

            If timeSpan.TotalSeconds >= 2.0 Then
                Dim objArray As Object() = New Object(3) {CObj(postUri), CObj(now1), CObj(now2), Nothing}
                timeSpan = now2 - now1
                objArray(3) = CObj(timeSpan.TotalSeconds)
                Console.WriteLine("{0}" & vbLf & "Inicio: {1}, Fim: {2} - Diferença: {3}", objArray)
            End If

        Catch ex As Exception
            Throw
        End Try

        Return response
    End Function

    Async Function RequestAsync(ByVal postUri As String, ByVal jsonData As String, ByVal headers As List(Of KeyValuePair(Of String, String)), ByVal method As String) As Task(Of WebResponse)
        Dim responseAsync As WebResponse

        Try
            Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(postUri), HttpWebRequest)
            httpWebRequest.ContentType = "application/json; charset=utf-8"
            httpWebRequest.Accept = "application/json "
            httpWebRequest.Method = method

            For Each header As KeyValuePair(Of String, String) In headers
                httpWebRequest.Headers.Add(header.Key, header.Value)
            Next

            If Not String.IsNullOrEmpty(jsonData) Then

                Using streamWriter As StreamWriter = New StreamWriter(Await httpWebRequest.GetRequestStreamAsync())
                    streamWriter.Write(jsonData)
                    streamWriter.Flush()
                End Using
            End If

            Dim now As DateTime = DateTime.Now
            responseAsync = Await httpWebRequest.GetResponseAsync()
            Dim now1 As DateTime = DateTime.Now
            If (now1 - now).TotalSeconds >= 2.0 Then Console.WriteLine("{0}" & vbLf & "Inicio: {1}, Fim: {2} - Diferença: {3}", New Object(3) {CObj(postUri), CObj(now), CObj(now1), CObj((now1 - now).TotalSeconds)})
            httpWebRequest = CType(Nothing, HttpWebRequest)
        Catch ex As Exception
            Throw
        End Try

        Return responseAsync
    End Function

    Function LinearXmlHeaders(ByVal token As String) As List(Of KeyValuePair(Of String, String))
        Dim keyValuePairList As List(Of KeyValuePair(Of String, String))

        Try
            keyValuePairList = New List(Of KeyValuePair(Of String, String))()

            If token Is Nothing Then
                Dim bytes As Byte() = Encoding.UTF8.GetBytes(String.Format("{0}:{1}", CObj("0f14f86d-d93a-4ab9-9e99-0595ef7f4c97"), CObj("3b3e9c05-c52a-4010-aa07-0dd1b7ad7170")))
                keyValuePairList.Add(New KeyValuePair(Of String, String)("Authorization", "Basic " & Convert.ToBase64String(bytes)))
            Else
                keyValuePairList.Add(New KeyValuePair(Of String, String)("Authorization", "Bearer " & token))
            End If

        Catch ex As Exception
            Throw
        End Try

        Return keyValuePairList
    End Function
End Module

