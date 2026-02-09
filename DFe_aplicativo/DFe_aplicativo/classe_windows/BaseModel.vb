
Imports MySql.Data.MySqlClient
Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports System.Threading.Tasks


<DataContract>
<Serializable>
Public Class BaseModel
    Public campos As List(Of Campo) = New List(Of Campo)()
    Public camposCorrentes As List(Of Campo) = New List(Of Campo)()
    Public Overridable Property Id As Long
    Public Property NomeTabela As String
    Public Property NomeCampoId As String
    Public Property IdAutoIncrement As Boolean

    Protected Function Salvar() As Long
        Return Me.Salvar(Me, "")
    End Function

    Protected Function Salvar(ByVal modelo As BaseModel) As Long
        Return Me.Salvar(modelo, "")
    End Function

    Protected Function Salvar(ByVal modelo As BaseModel, ByVal condicao As String) As Long
        If modelo.Id = 0L Then Return modelo.Incluir()
        Return modelo.Atualizar(condicao)
    End Function

    Protected Function Salvar(ByVal modelo As BaseModel, ByVal condicao As String, ByVal valorBase As Integer) As Long
        If modelo.Id = CLng(valorBase) Then Return modelo.Incluir()
        Return modelo.Atualizar(condicao)
    End Function

    Protected Sub AlimentaValoresCorrentes(ByVal reader As MySqlDataReader)
        For ordinal As Integer = 0 To reader.FieldCount - 1
            Dim campo As Campo = New Campo()
            campo.Nome = reader.GetName(ordinal)
            campo.Valor = If(reader.IsDBNull(ordinal), CObj(Nothing), reader.GetValue(ordinal))

            Select Case reader.GetFieldType(ordinal).Name
                Case "Int16", "Int32", "Int64"
                    campo.TipoDado = "Integer"
                Case Else
                    campo.TipoDado = reader.GetFieldType(ordinal).Name
            End Select

            Me.camposCorrentes.Add(campo)
        Next
    End Sub

    Public Shared Function TabelaExiste(ByVal nomeTabela As String) As Boolean
        Try
            Return DBHelper.TabelaExistente(nomeTabela, DBHelper.nomeBanco)
        Catch
            Throw
        End Try
    End Function

    Public Shared Function TabelaExisteMySql(ByVal nomeTabela As String) As Boolean
        Try
            Return DBHelper.TabelaExistente(nomeTabela, "mysql")
        Catch
            Throw
        End Try
    End Function

    Public Shared Async Function ExecutaQueryAsync(ByVal query As String) As Task(Of Boolean)
        Try

            Using conn As MySqlConnection = DBHelper.ConexaoBD()
                Dim num As Integer = If(Await BaseModel.ExecutaQueryAsync(query, conn), 1, 0)
            End Using

        Catch ex As Exception
            Throw
        End Try

        Return True
    End Function

    Public Shared Async Function ExecutaQueryAsync(ByVal query As String, ByVal connection As MySqlConnection) As Task(Of Boolean)
        Try

            Using command As MySqlCommand = New MySqlCommand(query, connection)
                Dim num As Integer = Await command.ExecuteNonQueryAsync()
            End Using

        Catch ex As Exception
            Throw
        End Try

        Return True
    End Function

    Public Shared Function ExecutaQuery(ByVal query As String, Optional ByVal IgnoreErro As Boolean = False) As Boolean
        Try

            Using connection As MySqlConnection = DBHelper.ConexaoBD()
                BaseModel.ExecutaQuery(query, connection)
            End Using

        Catch ex As Exception
            If Not IgnoreErro Then Throw
        End Try

        Return True
    End Function

    Public Shared Function ExecutaQuery(ByVal query As String) As Boolean
        Try

            Using connection As MySqlConnection = DBHelper.ConexaoBD()
                BaseModel.ExecutaQuery(query, connection)
            End Using

        Catch ex As Exception
            Throw
        End Try

        Return True
    End Function

    Public Shared Function ExecutaQuery(ByVal query As String, ByVal connection As MySqlConnection) As Boolean
        Try

            Using mySqlCommand As MySqlCommand = New MySqlCommand(query, connection)
                mySqlCommand.ExecuteNonQuery()
            End Using

        Catch ex As MySqlException
            If ex.Number = 1235 AndAlso query.ToLower().IndexOf("create trigger") > -1 OrElse ex.Number = 1360 Then Return True
            Throw
        Catch ex As Exception
            Throw New Exception("Query: " & query & " ||", ex)
        End Try

        Return True
    End Function

    Public Shared Function ExecutaQueryReader(ByVal query As String) As MySqlDataReader
        Try
            Dim connection As MySqlConnection = DBHelper.ConexaoBD()
            Return New MySqlCommand(query, connection).ExecuteReader()
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ToJson() As String
        Try
            Return BaseModel.ToJson(CObj(Me))
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function ToJson(ByVal obj As Object) As String
        Try
            Dim memoryStream As MemoryStream = New MemoryStream()
            Dim r As New DataContractJsonSerializer(obj.[GetType]())
            r.WriteObject(CType(memoryStream, Stream), obj)
            memoryStream.Position = 0L
            Return New StreamReader(CType(memoryStream, Stream)).ReadToEnd()
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function DeserializeJSon(Of T)(ByVal jsonData As String) As T
        Try
            Return CType(New DataContractJsonSerializer(GetType(T)).ReadObject(CType(New MemoryStream(Encoding.UTF8.GetBytes(jsonData)), Stream)), T)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function Incluir() As Long
        Dim str1 As String = ""

        Try
            Dim str2 As String = str1 & String.Format("insert into {0} (", CObj(Me.NomeTabela))
            Dim str3 As String = ""
            Dim str4 As String = ""

            For Each campo As Campo In Me.campos
                Dim flag As Boolean = Me.campos.IndexOf(campo) = Me.campos.Count - 1
                str3 += String.Format("{0}{1}", CObj(campo.Nome), If(flag, CObj(""), CObj(",")))
                str4 += String.Format("{0}{1}", CObj(BaseModel.ValorFormatado(campo)), If(flag, CObj(""), CObj(",")))
            Next

            Using connection As MySqlConnection = DBHelper.ConexaoBD()
                BaseModel.ExecutaQuery(str2 & String.Format("{0}) values ({1})", CObj(str3), CObj(str4)), connection)
                If Me.IdAutoIncrement Then Return BaseModel.RecuperaAutoIncrementID(connection)
                Return 0
            End Using

        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function Atualizar(ByVal condicao As String) As Long
        Dim str1 As String = ""
        Dim str2 As String = ""

        Try
            Dim str3 As String = str1 & String.Format("update {0} set ", CObj(Me.NomeTabela))

            For Each campo As Campo In Me.campos
                Me.campos.IndexOf(campo)
                Dim count As Integer = Me.campos.Count

                For Each camposCorrente As Campo In Me.camposCorrentes

                    If camposCorrente.Nome = campo.Nome AndAlso Not Me.ValoresIguais(camposCorrente, campo) Then
                        str2 += String.Format("{0}={1},", CObj(campo.Nome), CObj(BaseModel.ValorFormatado(campo)))
                        Exit For
                    End If
                Next
            Next

            If String.IsNullOrEmpty(str2) Then Return 0
            If str2.EndsWith(",") Then str2 = str2.Substring(0, str2.Length - 1)
            If String.IsNullOrEmpty(condicao.Trim()) Then condicao = String.Format("{0} = {1}", CObj(Me.NomeCampoId), CObj(Me.Id))
            BaseModel.ExecutaQuery(str3 & String.Format("{0} where {1}", CObj(str2), CObj(condicao)))
        Catch ex As Exception
            Throw
        End Try

        Return Me.Id
    End Function

    Public Shared Function ValorFormatado(ByVal campo As Campo) As String
        Dim str As String

        Try

            Select Case campo.TipoDado
                Case "Integer"
                    str = Convert.ToString(campo.Valor)
                Case "Date"
                    str = String.Format("'{0}'", CObj(String.Format("{0:yyyy-MM-dd}", campo.Valor)))
                Case "DateTime"
                    str = String.Format("'{0}'", CObj(String.Format("{0:yyyy-MM-dd HH:mm:ss}", campo.Valor)))
                Case "Decimal"
                    Dim result As Decimal
                    str = If(Not Decimal.TryParse(campo.Valor.ToString(), result), "0", result.ToString(CType(CultureInfo.InvariantCulture, IFormatProvider)))
                Case "null"
                    str = campo.Valor.ToString()
                Case Else
                    str = String.Format("'{0}'", campo.Valor).Replace("\", "\\\")
            End Select

        Catch ex As Exception
            Throw
        End Try

        Return str
    End Function

    Private Function ValoresIguais(ByVal c1 As Campo, ByVal c2 As Campo) As Boolean
        Try

            Select Case c1.TipoDado
                Case "Integer"
                    Return Convert.ToInt64(c1.Valor) = Convert.ToInt64(c2.Valor)
                Case "Decimal"
                    Return Convert.ToDecimal(c1.Valor) = Convert.ToDecimal(c2.Valor)
                Case "Date", "DateTime"
                    Dim valor As String = TryCast(c2.Valor, String)
                    If valor IsNot Nothing Then Return valor.Equals("null") AndAlso c1.Valor Is Nothing
                    Return Convert.ToDateTime(c1.Valor) = Convert.ToDateTime(c2.Valor)
                Case Else
                    Return Convert.ToString(c1.Valor) = Convert.ToString(c2.Valor)
            End Select

        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function RecuperaAutoIncrementID(ByVal connection As MySqlConnection) As Long
        Dim mySqlDataReader As MySqlDataReader = CType(Nothing, MySqlDataReader)

        Try

            Using mySqlCommand As MySqlCommand = New MySqlCommand("select last_insert_id() as last_id", connection)
                mySqlDataReader = mySqlCommand.ExecuteReader()
                If mySqlDataReader.Read() Then Return mySqlDataReader.GetInt64(mySqlDataReader.GetOrdinal("last_id"))
            End Using

            Return 0
        Catch ex As Exception
            Throw
        Finally
            mySqlDataReader.Dispose()
        End Try
    End Function
End Class

