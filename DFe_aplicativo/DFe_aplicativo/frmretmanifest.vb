Imports System.Xml

Public Class frmretmanifest

    Private Sub frmretmanifest_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
       
    End Sub
    Private Sub frmretmanifest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cont As Integer
        Dim cont1 As Integer
        cont = "0"
        cont1 = "0"

        For i As Integer = 0 To dgvsefaz.Rows.Count - 1
            If dgvsefaz.Rows.Item(i).Cells(1).Value = "Evento registrado e vinculado a NF-e" Or dgvsefaz.Rows.Item(i).Cells(1).Value = "Evento registrado, mas não vinculado a NF-e" Then
                cont = cont + 1
            Else
                cont1 = cont1 + 1
            End If
        Next
        lbltotal.Text = "Total de Notas Manifestadas: " & cont
        Label1.Text = "Total de Notas Rejeitadas: " & cont1
        limpar()


    End Sub

    Public Sub consulta_nfe()
        dgvsefaz.Columns(3).HeaderText = "Data do Evento"
        dgvsefaz.Columns(3).Width = 120
        dgvsefaz.Columns(3).Visible = True
        dgvsefaz.Width = 812
        Panel1.Width = 819
        Panel1.Height = 283
        Label2.Text = "Eventos da NF-e Homologados na SEFAZ"
        Me.Width = 825
        Me.Height = 315
    End Sub
  

    Private Sub limpar()
        For i As Integer = "0" To dgvsefaz.Rows.Count - 1

            If dgvsefaz.Rows.Item(i).Cells(1).Value.ToString.Length >= 8 Then

                If dgvsefaz.Rows.Item(i).Cells(1).Value.ToString.Substring(0, 8) = "Rejeicao" Then
                    dgvsefaz.Rows.Item(i).Cells(2).Value = ""
                End If

            End If

        Next
    End Sub

    Public Sub salva_xml()
        Dim xmldoc As New XmlDocument()
        Dim xmlnsManager As New XmlNamespaceManager(xmldoc.NameTable)

        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As Xml.XmlNode
        Dim data As Date

        dgvsefaz.Rows.Clear()
        xmldoc.Load(Application.StartupPath & "\XML\Retorno_consultaNFe.xml")

        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist = xmldoc.SelectNodes("//bk:protNFe", xmlnsManager)


        For Each xmlnode In xmllist
            data = xmlnode("infProt")("dhRecbto").InnerText

            dgvsefaz.Rows.Add(xmlnode("infProt")("chNFe").InnerText, xmlnode("infProt")("xMotivo").InnerText, _
                              xmlnode("infProt")("nProt").InnerText, data.ToString("dd-MM-yyyy HH:mm:ss"))

        Next


        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")
        xmllist = xmldoc.SelectNodes("//bk:procEventoNFe", xmlnsManager)


        For Each xmlnode In xmllist
            data = xmlnode("retEvento")("infEvento")("dhRegEvento").InnerText

            dgvsefaz.Rows.Add(xmlnode("evento")("infEvento")("chNFe").InnerText, xmlnode("evento")("infEvento")("detEvento")("descEvento").InnerText, _
                              xmlnode("retEvento")("infEvento")("nProt").InnerText, data.ToString("dd-MM-yyyy HH:mm:ss"))

        Next


    End Sub

    Private Sub carregar_cte()
        Dim xmldoc As New XmlDocument()
        Dim xmlnsManager As New XmlNamespaceManager(xmldoc.NameTable)
        Dim xmldocret As New XmlDocument()
        Dim xmllist As System.Xml.XmlNodeList
        Dim xmlnode As System.Xml.XmlNode


        xmlnsManager.AddNamespace("bk", "http://www.portalfiscal.inf.br/nfe")

        xmldoc.Load(Application.StartupPath & "\XML\Retorno_consultaNFe.xml")
        xmllist = xmldoc.SelectNodes("//bk:CTe", xmlnsManager)

        For Each xmlnode In xmllist

            txtchavecte.Text = xmlnode("chCTe").InnerText
            txtdatacte.Text = xmlnode("dhEmi").InnerText
            txtprotcte.Text = xmlnode("nProt").InnerText

        Next

        xmllist = xmldoc.SelectNodes("//bk:emit", xmlnsManager)

        For Each xmlnode In xmllist

            txtcnpjcte.Text = xmlnode("CNPJ").InnerText
            txtiecte.Text = xmlnode("IE").InnerText
            txtemitentecte.Text = xmlnode("xNome").InnerText

        Next




    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        salva_xml()
    End Sub

    Private Sub dgvsefaz_Click(sender As Object, e As EventArgs) Handles dgvsefaz.Click
        If dgvsefaz.CurrentRow.Cells(1).Value = "CT-e Autorizado" Then
            Panel1.Height = 407
            Me.Height = 447
            Panelcte.Visible = True

            carregar_cte()

        Else
            Panel1.Height = 305
            Me.Height = 315
            Panelcte.Visible = False
        End If
    End Sub

    Private Sub dgvsefaz_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsefaz.CellContentClick

    End Sub
End Class