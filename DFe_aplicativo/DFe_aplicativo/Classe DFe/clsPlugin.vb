Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SQLite
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Public Class clsPlugin
    Public Function IsUsuarioAdministrado() As Boolean
        Dim flag As Boolean

        Try
            flag = New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)
        Catch ex As UnauthorizedAccessException
            ProjectData.SetProjectError(CType(ex, Exception))
            flag = False
            ProjectData.ClearProjectError()
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            flag = False
            ProjectData.ClearProjectError()
        End Try

        Return flag
    End Function

    Public Shared Function ExecutarSQL_CFe(ByVal SQL As String) As Object
        Dim obj As Object

        Try
            Dim connection As SQLiteConnection = New SQLiteConnection("Data Source=" & Application.StartupPath & "\cfe.db3;Version=3;Password=R@enil2015#;")
            connection.Open()
            obj = CObj(New SQLiteCommand(SQL, connection).ExecuteReader())
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            obj = CObj(Nothing)
            ProjectData.ClearProjectError()
        End Try

        Return obj
    End Function

    Public Function gVgPt(ByVal sEntrada As String, Optional ByVal Invert As Boolean = False) As String
        Return If(Not (Operators.CompareString(sEntrada, "", False) = 0 Or Operators.CompareString(sEntrada, "0.00", False) = 0), (If(Versioned.IsNumeric(CObj(sEntrada)), (If(Not Invert, Strings.Replace(Strings.Replace(sEntrada, ".", "", 1, -1, CompareMethod.Binary), ",", ".", 1, -1, CompareMethod.Binary), Strings.Replace(Strings.Replace(sEntrada, ",", vbNullChar, 1, -1, CompareMethod.Binary), ".", ",", 1, -1, CompareMethod.Binary))), "0")), "0")
    End Function

    Public Function Moeda(ByVal Valor As Object, Optional ByVal Casas As Integer = 2) As Double
        Dim num As Double

        Try
            num = Conversions.ToDouble(String.Format(Conversions.ToString(Conversions.ToDouble("{0:N") + CDbl(Casas) + Conversions.ToDouble("}")), CObj(Convert.ToDecimal(RuntimeHelpers.GetObjectValue(Valor)))))
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            num = 0.0
            ProjectData.ClearProjectError()
        End Try

        Return num
    End Function

    Public Function Trunca(ByVal vgValor As String, ByVal vgNumDecimais As Object) As Decimal
        Return Conversions.ToDecimal(Operators.DivideObject(CObj(Conversion.Int(Conversion.Val(Conversion.Str(Operators.MultiplyObject(CObj(vgValor), Operators.ExponentObject(CObj(10), vgNumDecimais)))))), Operators.ExponentObject(CObj(10), vgNumDecimais)))
    End Function

    Public Function ret_table(ByVal csql As String) As DataTable
        Dim flag As Boolean

        Dim ds As DataSet = Nothing
        Dim dataTable1 As DataTable = New DataTable()
        Dim dataTable2 As DataTable

        Try

            Dim connection As SQLiteConnection = New SQLiteConnection("Data Source=C:\Users\adeni\Desktop\TES\CFe.db3;Version=3;Password=R@enil2015#;")
            connection.Open()
            '   csql = "select cast(pr_valor as text) as pr_valor from parametro where pr_chave = 'PDV_NFCE_HABFUNCAO'"
            Dim da As SQLiteDataReader = New SQLiteCommand(csql, connection).ExecuteReader()

            Using cmd As SQLiteCommand = New SQLiteCommand(csql, connection)

                Using sqLiteDataAdapter As SQLiteDataAdapter = New SQLiteDataAdapter(cmd)
                    sqLiteDataAdapter.Fill(dataTable1)
                    dataTable2 = dataTable1
                End Using
            End Using

            Return dataTable2
        Catch ex As Exception

        End Try


    End Function

    Public Function ValidarFuncNFCe(ByVal sLinha As String, ByVal TipoValidar As Integer) As Boolean
        Dim boolean2 As Boolean

        Try
            boolean2 = Conversions.ToBoolean(Strings.Mid(sLinha, TipoValidar, 1))
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            'mdlGeral.CriarLog("Erro: " & ex.Message, NameOf(clsPlugin), "ValidaFuncaoNFCe", False, True, False)
            ProjectData.ClearProjectError()
        End Try

        Return boolean2
    End Function

   
   
End Class
