Imports System.Collections.Generic
Imports System.Runtime.Serialization


<DataContract>
Public Class Registro
    <DataMember(Name:="fields")>
    Public Property Campos As List(Of Campo)

    Public Sub New(ByVal campos As List(Of Campo))
        Me.Campos = campos
    End Sub
End Class

