Imports Newtonsoft.Json
Imports System
Imports System.IO
Imports System.Reflection
Imports System.Text
Imports System.Data.SQLite
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient



Module Monitoramento
    Public tabe As New DataTable
    Public logs_text() As String
    Public DataHoraAtivacao As DateTime
    Public DataHoraUltimaNfceProcessada As DateTime
    Public HorasEmExecucao As Double

    Function RecuperarDados() As String
        Try
            Dim jsonSerializer As JsonSerializer = New JsonSerializer()
            Dim sb As StringBuilder = New StringBuilder()
            Dim jsonTextWriter As JsonTextWriter = New JsonTextWriter(CType(New StringWriter(sb), TextWriter))
            '   Dim data = New With {Key .versaoApp = Assembly.GetExecutingAssembly().GetName().Version.ToString(), Key .dataHoraUltimaNfceProcessada = If(Monitoramento.DataHoraUltimaNfceProcessada.HasValue, New DateTime(), Monitoramento.DataHoraUltimaNfceProcessada), Key .horasEmExecucao = Monitoramento.TempoEmExecucao(), Key .nomeBanco = DBHelper.nomeBanco, Key .provider = DBHelper.host
            '   }
            '   jsonSerializer.Serialize(CType(jsonTextWriter, JsonWriter), CObj(data))
            Return sb.ToString()
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function TempoEmExecucao() As Double
        Try
            Return DateTime.Now.Subtract(Monitoramento.DataHoraAtivacao).TotalHours
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub gerar_evento_host(ByVal evento As String, ByVal modulo As String)
        'Try
        '    salvar(evento, modulo)
        '    tabe.Rows.Add(evento, Now)
        'Catch ex As Exception
        '    criar_tabela()
        '    tabe.Rows.Add(evento, Now)
        '    salvar(evento, modulo)
        'End Try

    End Sub

    Public Sub criar_tabela()
        'Try
        '    tabe.Columns.Add("evento", GetType(String))
        '    tabe.Columns.Add("data", GetType(Date))
        'Catch ex As Exception

        'End Try

    End Sub


    Private Sub salvar(ByVal evento As String, ByVal modulo As String)
        Dim oConn3 As New MySqlConnection
        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DFe.ini")
        If arquivoIni.KeyExists("ip_mysql", "DFe") = False Then
            arquivoIni.Write("ip_mysql", "127.0.0.1", "DFe")
        End If

        oConn3 = New MySqlConnection("server=" & arquivoIni.Read("ip_mysql", "DFe") & ";User Id=dfe;database=dfe; password=Pe$$w0rd1@")

        If oConn3.State = ConnectionState.Closed Then
            oConn3.Open()
        End If

        Dim insertSQL As MySqlCommand = New MySqlCommand("INSERT INTO evento_host (funcao, modulo, data) VALUES (@funcao, @modulo, @data)", oConn3)

        insertSQL.Parameters.Add(New MySqlParameter("funcao", evento))
        insertSQL.Parameters.Add(New MySqlParameter("modulo", modulo))
        insertSQL.Parameters.Add(New MySqlParameter("data", Now))
      
        insertSQL.ExecuteNonQuery()

        oConn3.Close()

    End Sub

End Module

