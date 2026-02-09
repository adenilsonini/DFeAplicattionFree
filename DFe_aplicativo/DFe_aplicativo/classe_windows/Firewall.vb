Imports NetFwTypeLib


Public Class Firewall
    Public Shared Function AbrirPortaFirewall(ByVal descricao As String, ByVal porta As Integer) As Boolean
        RemoverRegraFirewall(descricao)
        Dim instance As INetFwOpenPort = TryCast(Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWOpenPort")), INetFwOpenPort)
        instance.Name = descricao
        instance.Port = porta
        instance.Scope = NET_FW_SCOPE_.NET_FW_SCOPE_ALL
        instance.Protocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP
        instance.IpVersion = NET_FW_IP_VERSION_.NET_FW_IP_VERSION_ANY
        Dim firewallManager As INetFwMgr = GetFirewallManager()

        Try
            firewallManager.LocalPolicy.CurrentProfile.GloballyOpenPorts.Add(instance)
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function
    Private Shared Function GetFirewallManager() As INetFwMgr
        Return TryCast(Activator.CreateInstance(Type.GetTypeFromCLSID(New Guid("{304CE942-6E39-40D8-943A-B913C40C9CD4}"))), INetFwMgr)
    End Function

    Private Shared Sub RemoverRegraFirewall(ByVal nomeRegra As String)
        Try
            Dim instance As INetFwPolicy2 = CType(Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2")), INetFwPolicy2)
            Dim currentProfileTypes As Integer = instance.CurrentProfileTypes

            For Each rule As INetFwRule In instance.Rules

                If rule.Name.IndexOf(nomeRegra) <> -1 Then
                    CType(Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2")), INetFwPolicy2).Rules.Remove(rule.Name)
                End If
            Next

        Catch
            MsgBox("Erro ao remover a regra '" & nomeRegra & "' do Firewall")
        End Try
    End Sub
End Class
