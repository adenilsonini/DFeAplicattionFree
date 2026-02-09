Imports System.Data.SQLite
Imports System.Runtime.CompilerServices

Module teste
    Public cSql As String
    Private cn As SQLiteConnection
    Private constring As String = "Data Source=@filedb3;Version=3;Password=R@enil2015#;"
    Private constringNSenha As String = "Data Source=@filedb3;Version=3;"
    Public Property Licenca As String
    Public Property NumeroSerieCaixa As String
    Public Property Licenca_Data As String
    Public Property Data_Validade As String
    Public Property Status_Lic As Integer
    Public Function Iniciar_Conexao(ByVal strPathDb3 As String, Optional ByVal iTipoConsString As Integer = 0) As SQLiteConnection
        Dim sqLiteConnection As SQLiteConnection

        Try

            cn = New SQLiteConnection()
            cn.ConnectionString = If(iTipoConsString <> 0, constringNSenha.Replace("@filedb3", strPathDb3), constring.Replace("@filedb3", strPathDb3))
            cn.Open()
            sqLiteConnection = cn
        Catch ex As SQLiteException
            ' ProjectData.SetProjectError(CType(ex, Exception))
            sqLiteConnection = CType(Nothing, SQLiteConnection)
            ' ProjectData.ClearProjectError()
        End Try

        Return sqLiteConnection
    End Function

    Public Function Fechar_Conexao(ByVal cn As SQLiteConnection) As Boolean
        Dim flag As Boolean

        Try
            cn.Clone()
            flag = True
        Catch ex As SQLiteException
            ' ProjectData.SetProjectError(CType(ex, Exception))
            flag = False
            '  ProjectData.ClearProjectError()
        End Try

        Return flag
    End Function

    Public Function RetDataReader(ByVal cSql As String) As SQLiteDataReader
        Dim sqLiteDataReader As SQLiteDataReader

        Try
            sqLiteDataReader = New SQLiteCommand() With {
                .Connection = cn,
                .CommandText = cSql,
                .CommandType = CommandType.Text
            }.ExecuteReader()
        Catch ex As SQLiteException
            '  ProjectData.SetProjectError(CType(ex, Exception))
            sqLiteDataReader = CType(Nothing, SQLiteDataReader)
            '  ProjectData.ClearProjectError()
        End Try

        Return sqLiteDataReader
    End Function

    Public Function RetDataReader(ByVal cSql As String, ByVal cn As SQLiteConnection) As SQLiteDataReader
        Dim sqLiteDataReader As SQLiteDataReader

        Try
            sqLiteDataReader = New SQLiteCommand() With {
                .Connection = cn,
                .CommandText = cSql,
                .CommandType = CommandType.Text
            }.ExecuteReader()
        Catch ex As SQLiteException
            '  ProjectData.SetProjectError(CType(ex, Exception))
            sqLiteDataReader = CType(Nothing, SQLiteDataReader)
            '  ProjectData.ClearProjectError()
        End Try

        Return sqLiteDataReader
    End Function
    Public Function ExecutaQueryDT(ByVal query As String, Optional ByVal strPathFile As String = "") As DataTable
        Dim dataTable1 As DataTable = New DataTable()
        Dim dataTable2 As DataTable

        Try
            If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(strPathFile, "", False) = 0 Then strPathFile = "cfe.db3"

            Using sqLiteConnection As SQLiteConnection = Iniciar_Conexao(Application.StartupPath & "\" & strPathFile, 0)

                Using cmd As SQLiteCommand = New SQLiteCommand(query, sqLiteConnection)

                    Using sqLiteDataAdapter As SQLiteDataAdapter = New SQLiteDataAdapter(cmd)
                        sqLiteDataAdapter.Fill(dataTable1)
                        Fechar_Conexao(sqLiteConnection)
                        dataTable2 = dataTable1
                    End Using
                End Using
            End Using

        Catch ex As Exception
            ' ProjectData.SetProjectError(ex)
            dataTable2 = CType(Nothing, DataTable)
            ' ProjectData.ClearProjectError()
        End Try

        Return dataTable2
    End Function

    Public Function ExecuteSQL(ByVal cSql As String, Optional ByVal strPathDb3 As String = "", Optional ByVal iTipoCS As Integer = 0) As Boolean
        Dim flag As Boolean

        Try

            '  If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(strPathDb3, "", False) = 0 Then strPathDb3 = mdlGeral.AppPath & "\cfe.db3"

            Dim sqLiteConnection As SQLiteConnection = Iniciar_Conexao(strPathDb3, iTipoCS)

            flag = True


            Using Comm As New System.Data.SQLite.SQLiteCommand(sqLiteConnection)
                Comm.CommandText = cSql
                Comm.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            '  ProjectData.SetProjectError(ex)
            flag = False
            '  ProjectData.ClearProjectError()
        End Try


        Return flag
    End Function

    Public Function fgVerificaNulo(ByVal Valor As Object, Optional ByVal Retorno As Object = "") As Object
        Dim obj As Object

        Try
            obj = If(Not (Information.IsDBNull(RuntimeHelpers.GetObjectValue(Valor)) Or Strings.Len(RuntimeHelpers.GetObjectValue(Valor)) = 0), RuntimeHelpers.GetObjectValue(Valor), RuntimeHelpers.GetObjectValue(Retorno))
        Catch ex As Exception
            ' ProjectData.SetProjectError(ex)
            obj = Retorno
            'ProjectData.ClearProjectError()
        End Try

        Return obj
    End Function
    Public Function GerarDadosPDV(ByVal Caixa As Integer, ByVal cnpjfilial As String) As Object
        Dim serialHD As String, caixa2 As String
        Dim obj As Object

        '  Try
        caixa2 = Caixa.ToString()
        serialHD = GetSerialHDD()
        cSql = "select * from cadecf_licenca"
        Dim dataTable1 As DataTable = ExecutaQueryDT(cSql, "")
        MsgBox(dataTable1.Rows.Count)


        If dataTable1 IsNot Nothing Then

            Try

                For Each row As DataRow In dataTable1.Rows
                    Licenca = row("licenca").ToString()
                    NumeroSerieCaixa = row("numeroserie").ToString()
                    Licenca_Data = row("LICENCA_DATA").ToString()

                    ' Try
                    Data_Validade = fgVerificaNulo(RuntimeHelpers.GetObjectValue(row("licenca_validade")), CObj("")).ToString()

                    MsgBox(Data_Validade)
                    ' Catch ex As Exception
                    ' ProjectData.SetProjectError(ex)
                    'Data_Validade = ""
                    ' ProjectData.ClearProjectError()
                    '  End Try
                Next

            Finally
                Dim enumerator As IEnumerator
                If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
            End Try
        End If

        '  cSql = "select * from empresa"
        '  Dim dataTable2 As DataTable = ExecutaQueryDT(cSql, "plu.mdb")

        '  If dataTable2 IsNot Nothing Then

        'Try

        'For Each row As DataRow In dataTable2.Rows
        ' clsDadosPdv.empresapdv.Filial = Conversions.ToInteger(row("emp_codigo"))
        ' clsDadosPdv.empresapdv.CNPJ = Conversions.ToString(row("CNPJ"))
        '  clsDadosPdv.empresapdv.CSC = Conversions.ToString(row("CSC"))
        ' clsDadosPdv.empresapdv.idToken = Conversions.ToInteger(row("idToken"))
        '' Next

        ' Finally
        ' Dim enumerator As IEnumerator
        '    If TypeOf enumerator Is IDisposable Then (TryCast(enumerator, IDisposable)).Dispose()
        ' End Try
        '  Else
        '  clsDadosPdv.empresapdv.Filial = 0
        ' clsDadosPdv.empresapdv.CNPJ = cnpjfilial
        ' End If

        ' mdlGeral.cSql = "Select * from ctrl_faixa where status = 1 and caixa = " & Conversions.ToString(Caixa) & " and filial = " + Conversions.ToString(clsDadosPdv.empresapdv.Filial)
        '  Dim dataTable3 As DataTable = clsDal.ExecutaQueryDT(mdlGeral.cSql, "")

        ' If dataTable3 IsNot Nothing Then

        '  Try

        'For Each row As DataRow In dataTable3.Rows
        ' clsDadosPdv.faixanumeracaopdv.FaixaInicio = Conversions.ToLong(row("inicial"))
        '   clsDadosPdv.faixanumeracaopdv.FaixaFinal = Conversions.ToLong(row("final"))
        '  clsDadosPdv.faixanumeracaopdv.SerieFaixa = Conversions.ToInteger(row("serie"))
        '   Next

        ' Finally
        '   Dim enumerator As IEnumerator
        '     If TypeOf enumerator Is IDisposable Then (TryCast(enumerator, IDisposable)).Dispose()
        ' End Try
        '  End If

        ' mdlGeral.cSql = "select  max(num_nfce) as ultnfcepdv from dados_nfce where caixa = " & Conversions.ToString(Caixa) & " and serie = " + Conversions.ToString(clsDadosPdv.faixanumeracaopdv.SerieFaixa)
        '  Dim dataTable4 As DataTable = clsDal.ExecutaQueryDT(mdlGeral.cSql, "")

        '  If dataTable4 IsNot Nothing Then
        '
        'If dataTable4.Rows.Count > 0 Then

        '  Try

        ' For Each row As DataRow In dataTable4.Rows
        ' clsDadosPdv.faixanumeracaopdv.NumeracaoAtual = If(row("ultnfcepdv") = DBNull.Value, 0L, Conversions.ToLong(row("ultnfcepdv")))
        '  Next

        'Finally
        '    Dim enumerator As IEnumerator
        '     If TypeOf enumerator Is IDisposable Then (TryCast(enumerator, IDisposable)).Dispose()
        ' End Try
        ' Else
        'clsDadosPdv.faixanumeracaopdv.NumeracaoAtual = 0L
        '  End If
        '  End If

        '    obj = If(clsDadosPdv Is Nothing, CObj(Nothing), CObj(clsDadosPdv))
        ' Catch ex As Exception
        ' ProjectData.SetProjectError(ex)
        ' mdlGeral.CriarLog("Erro ao validar dados do PDV => " & ex.Message, NameOf(clsValidarPDV), NameOf(GerarDadosPDV), False, False, False)
        '  obj = CObj(Nothing)
        '  ProjectData.ClearProjectError()
        ' End Try

        Return obj
    End Function
End Module
