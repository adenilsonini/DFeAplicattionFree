Public Class frm_visualiza_rel

    Private Sub frm_visualiza_rel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CrystalReportViewer1.RefreshReport()
    End Sub
End Class