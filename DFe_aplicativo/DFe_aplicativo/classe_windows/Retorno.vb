Imports System.Collections.Generic
Imports System.Runtime.Serialization


<DataContract>
Public Class Retorno
    <DataMember(Name:="company_id")>
    Public Property CnpjEmpresa As String
    <DataMember(Name:="task_id")>
    Public Property IdTarefa As Long
    <DataMember(Name:="execution_date")>
    Public Property DataExecucao As String
    <DataMember(Name:="records")>
    Public Property Registros As List(Of Registro)

    Public Sub New(ByVal cnpjEmpresa As String, ByVal idTarefa As Long, ByVal dataExecucao As String)
        Me.CnpjEmpresa = cnpjEmpresa
        Me.IdTarefa = idTarefa
        Me.DataExecucao = dataExecucao
    End Sub

    Public Sub New(ByVal cnpjEmpresa As String, ByVal registros As List(Of Registro), ByVal idTarefa As Long, ByVal dataExecucao As String)
        Me.New(cnpjEmpresa, idTarefa, dataExecucao)
        Me.Registros = registros
    End Sub

    Public Sub New(ByVal cnpjEmpresa As String, ByVal campo As Campo, ByVal idTarefa As Long, ByVal dataExecucao As String)
        Me.New(cnpjEmpresa, idTarefa, dataExecucao)
        Me.Registros = New List(Of Registro)() From {
            New Registro(New List(Of Campo)() From {
                campo
            })
        }
    End Sub
End Class

