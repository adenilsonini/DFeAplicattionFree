Imports System.Security.Cryptography.X509Certificates

Public Class frmtela_cert
    Dim ListaCertificados As New List(Of X509Certificate2)()

    Private Sub frmtela_cert_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        '  If nfecer = "" Then
        'MsgBox("Nenhum Certificado Digital Selecionado ?", MsgBoxStyle.Exclamation, "Aviso !")
        '    End If
    End Sub
    Private Sub frmtela_cert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvcert.Rows.Clear()
        ler_Certs()
    End Sub


    Private Sub ler_Certs()
        Dim i As Integer
        Dim Store As X509Store = New X509Store(StoreName.My, StoreLocation.CurrentUser)
        Store.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)

        Dim _certs As X509Certificate2Collection = Store.Certificates.Find(X509FindType.FindByTimeValid, DateTime.Now, True).Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, True)

        For Each certificado In _certs

            ListaCertificados.Add(certificado)


            dgvcert.Rows.Add(PictureBox3.Image, ListaCertificados.Item(i).SubjectName.Name.Substring(3, ListaCertificados.Item(i).SubjectName.Name.IndexOf(",") - 3), _
                             ListaCertificados.Item(i).IssuerName.Name.Substring(3, ListaCertificados.Item(i).IssuerName.Name.IndexOf(",") - 3), _
                             ListaCertificados.Item(i).NotAfter.ToString("dd/MM/yyyy"), ListaCertificados.Item(i).SerialNumber)


            ' MsgBox("Emitido por: " & ListaCertificados.Item(i).IssuerName.Name.Substring(3, ListaCertificados.Item(i).IssuerName.Name.IndexOf(",") - 3))

            i += 1

        Next
    End Sub

    Private Sub dgvcert_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvcert.CellClick
        '  If MessageBox.Show("Deseja Selecionar este Certificado ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

        ' End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If dgvcert.RowCount = 0 Then
            MsgBox("Não existe cetificados no grid !", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        If nfecer = "" Then

            nfecer = dgvcert.CurrentRow.Cells("serial_cert").Value

            ' CertificadoDigital.SelecionarCertificado(nfecer)

            certificado = SelecionarCertificado(nfecer)

            cnpj_cert = ExtrairCNPJ(certificado)


            If CDate(certificado.NotAfter.ToString) < Now.Date Then

                Dim wD As Long = DateDiff(DateInterval.Day, CDate(certificado.NotAfter.ToString), Now.Date)

                MsgBox("Faltam " & wD.ToString & " dias para seu certificado digital vencer !", MsgBoxStyle.Exclamation, "Aviso !")

            Else
                Me.Close()
            End If


        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class