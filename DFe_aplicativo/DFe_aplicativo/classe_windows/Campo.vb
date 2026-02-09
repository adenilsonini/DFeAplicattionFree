Imports System.Runtime.Serialization


<DataContract>
Public Class Campo
    <DataMember(Name:="name")>
    Public Property Nome As String
    <DataMember(Name:="value")>
    Public Property Valor As Object
    Public Property TipoDado As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal nome As String, ByVal valor As Object, ByVal tipoDado As String)
        Me.Nome = nome
        Me.Valor = valor
        Me.TipoDado = If(String.IsNullOrEmpty(tipoDado), "String", tipoDado)
    End Sub

    Public Sub New(ByVal nome As String, ByVal valor As Object)
        Me.New(nome, valor, "")
    End Sub
End Class

