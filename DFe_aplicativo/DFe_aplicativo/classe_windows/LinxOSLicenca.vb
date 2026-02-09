Imports System
Imports System.Globalization
Imports System.Runtime.Caching
Imports System.Runtime.Serialization
Imports System.Text


<DataContract>
Friend Class LinxOSLicenca
    <DataMember(Name:="licenca")>
    Public Property Licenca As String
    <DataMember(Name:="dataexpira")>
    Public Property DataExpiracao As String
    <DataMember(Name:="tipo")>
    Public Property DescricaoTipoSistema As String
    Public Property TipoSistema As Byte
    <DataMember(Name:="customer_cnpj")>
    Public Property CnpjCliente As String

    Public Sub New(ByVal cliente As LinxOSCliente, ByVal mysqlControl As MysqlControl, ByVal quantidadeDias As Integer)
        Me.InicializaAtributos(cliente, mysqlControl, quantidadeDias)
    End Sub

    Public Sub New(ByVal cliente As LinxOSCliente, ByVal mysqlControl As MysqlControl)
        Me.InicializaAtributos(cliente, mysqlControl, cliente.DiasLicenca)
    End Sub

    Private Sub InicializaAtributos(ByVal cliente As LinxOSCliente, ByVal mysqlControl As MysqlControl, ByVal quantidadeDias As Integer)
        Try
            Dim hora As String = cliente.DataAtual.ToString("hhmmss")
            Dim dateTime As DateTime = cliente.DataAtual
            dateTime = dateTime.AddDays(CDbl(quantidadeDias))
            Me.DataExpiracao = dateTime.ToString("dd/MM/yyyy")
            Me.TipoSistema = cliente.TipoSistemaFormatado()
            Me.DescricaoTipoSistema = Me.RecuperaDescricaoTipoSistema()
            Me.CnpjCliente = mysqlControl.Cnpj
            Me.Licenca = GerarChave(mysqlControl.Cnpj, hora, cliente.DataAtual.AddDays(CDbl(quantidadeDias)), cliente.DataAtual, CInt(Me.TipoSistema))
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Shared Function DesmontarChave(ByVal chave As String) As String
        If chave.Length = 0 Then Return ""

        Using memoryCache As MemoryCache = memoryCache.[Default]
            If memoryCache.Contains(chave, CStr(Nothing)) Then Return memoryCache.[Get](chave, CStr(Nothing)).ToString()
            Dim stringBuilder As StringBuilder = New StringBuilder()

            For startIndex As Integer = 0 To 36 - 1 Step 4
                Dim result As Long
                Long.TryParse(chave.Substring(startIndex, 4).Replace("X", String.Empty), NumberStyles.HexNumber, CType(Nothing, IFormatProvider), result)
                Dim str As String = String.Format("{0:0000}", CObj(result))
                stringBuilder.Append(str)
            Next

            Dim str1 As String = stringBuilder.ToString()
            memoryCache.Add(chave, CObj(str1), DateTimeOffset.Now.AddMinutes(1.0), CStr(Nothing))
            Return str1
        End Using
    End Function

    Public Shared Function RecuperarCNPJ(ByVal chave As String) As String
        Dim str1 As String = LinxOSLicenca.DesmontarChave(chave)
        If str1.Length <= 0 Then Return ""
        Dim str2 As String = str1.Substring(0, 14)
        Dim str3 As String = str1.Substring(str1.Length - 3, 3)
        Dim ch As Char = str3(0)
        Dim oldChar1 As Char = str3(1)
        Dim oldChar2 As Char = str3(2)
        '  Dim num As Integer = CInt(ch)
        Dim num As Integer = CInt(AscW(ch))
        Return str2.Replace(ChrW(num), "0"c).Replace(oldChar1, "1"c).Replace(oldChar2, "2"c)
    End Function

    Public Shared Function RecuperarDataExpiracao(ByVal chave As String) As DateTime
        Dim str As String = LinxOSLicenca.DesmontarChave(chave)
        If chave.Length <= 0 Then Return DateTime.MinValue
        Dim s1 As String = str.Substring(14, 2)
        Dim s2 As String = str.Substring(16, 2)
        Dim s3 As String = str.Substring(18, 2)
        Dim result1 As Integer
        Integer.TryParse(s1, result1)
        Dim result2 As Integer
        Integer.TryParse(s2, result2)
        Dim num As Integer
        
        Integer.TryParse(s3, num)
        Dim day As Integer = result1 - 20
        Dim month As Integer = result2 - 19
        Return New DateTime(num + 1965, month, day)
    End Function

    Public Shared Function RecuperarTipoSistema(ByVal chave As String) As Byte
        Dim result As Integer
        Integer.TryParse(LinxOSLicenca.DesmontarChave(chave)(32).ToString(), result)
        Return Convert.ToByte(result)
    End Function

    Public Shared Function GerarChave(ByVal cnpj As String, ByVal hora As String, ByVal dataProximaExpiracao As DateTime, ByVal dataBanco As DateTime, ByVal tipoSistema As Integer) As String
        '  Try
        Dim startIndex As Integer = 0

        If cnpj.Contains("0") Then
            startIndex = 12
            Dim num As Integer = 1

            While startIndex >= 10
                startIndex = New Random().[Next](10)

                Select Case startIndex
                    Case 0, 1, 2
                        startIndex = 12
                End Select

                If cnpj.Contains(startIndex.ToString()) Then startIndex = 12
                num += 1

                If num > 30 AndAlso startIndex = 12 Then
                    startIndex = 0
                    Exit While
                End If
            End While
        End If

        Dim str1 As String = startIndex.ToString()
        Dim s1 As String = startIndex.ToString()
        Dim str2 As String = cnpj.Replace("0", startIndex.ToString())
        startIndex = 1

        If cnpj.Contains("1") Then
            startIndex = 12
            Dim num As Integer = 1

            While startIndex >= 10
                startIndex = New Random().[Next](10)
                If startIndex = 0 OrElse startIndex = Integer.Parse(s1) OrElse (startIndex = 1 OrElse startIndex = 2) OrElse cnpj.Contains(startIndex.ToString()) Then startIndex = 12
                num += 1

                If num > 30 AndAlso startIndex = 12 Then
                    startIndex = 1
                    Exit While
                End If
            End While
        End If

        Dim str3 As String = str1 & startIndex.ToString()
        Dim s2 As String = startIndex.ToString()
        Dim str4 As String = str2.Replace("1", startIndex.ToString())
        startIndex = 2

        If cnpj.Contains("2") Then
            startIndex = 12
            Dim num As Integer = 1

            While startIndex >= 10
                startIndex = New Random().[Next](10)
                If startIndex = 0 OrElse startIndex = Integer.Parse(s1) OrElse (startIndex = Integer.Parse(s2) OrElse startIndex = 1) OrElse (startIndex = 2 OrElse cnpj.Contains(startIndex.ToString())) Then startIndex = 12
                num += 1

                If num > 30 AndAlso startIndex = 12 Then
                    startIndex = 2
                    Exit While
                End If
            End While
        End If

        Dim str5 As String = str3 & startIndex.ToString()
        Dim str6 As String = str4.Replace("2", startIndex.ToString()) & (dataProximaExpiracao.Day + 20).ToString() & (dataProximaExpiracao.Month + 19).ToString()
        Dim num1 As Integer = (If(dataProximaExpiracao.Year > 2000, dataProximaExpiracao.Year - 2000, dataProximaExpiracao.Year)) + 35
        Dim str7 As String = num1.ToString()
        Dim str8 As String = str6 & str7
        num1 = dataBanco.Day + 21
        Dim str9 As String = num1.ToString()
        Dim str10 As String = str8 & str9
        num1 = dataBanco.Month + 18
        Dim str11 As String = num1.ToString()
        Dim str12 As String = str10 & str11
        num1 = (If(dataBanco.Year > 2000, dataBanco.Year - 2000, dataBanco.Year)) + 32
        Dim str13 As String = num1.ToString()
        Dim str14 As String = str12 & str13
        num1 = Integer.Parse(hora.Substring(0, 2)) + 11
        Dim str15 As String = num1.ToString()
        Dim str16 As String = str14 & str15
        num1 = Integer.Parse(hora.Substring(2, 2)) + 12
        Dim str17 As String = num1.ToString()
        Dim str18 As String = str16 & str17
        num1 = Integer.Parse(hora.Substring(4, 2)) + 14
        Dim str19 As String = num1.ToString()
        Dim str20 As String = str18 & str19 & tipoSistema.ToString() & str5
        Dim str21 As String = ""

        For startIndex = 0 To 36 - 1 Step 4
            num1 = Integer.Parse(str20.Substring(startIndex, 4))
            cnpj = num1.ToString("X")
            If cnpj.Length <> 4 Then cnpj += New String("X"c, 4 - cnpj.Length)
            str21 += cnpj
        Next

        Return str21
        '  Catch ex As Exception
        '     Throw
        ' End Try
    End Function

    Private Function RecuperaDescricaoTipoSistema() As String
        Select Case Me.TipoSistema
            Case 1
                Return "Lite sem NF-e"
            Case 2
                Return "Completo sem NF-e"
            Case 4
                Return "Lite com NF-e"
            Case 5
                Return "Completo com NF-e"
            Case 6
                Return "Lite + Financeiro"
            Case 9
                Return "Pedido"
            Case Else
                Return ""
        End Select
    End Function
End Class

