Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmsintegravb
    Dim reg90 As String = "90"
    Private Sub frmsintegravb_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmsintegravb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carrega_empresa()
        data_ini.Value = Now.ToString("01/MM/yyyy")
    End Sub

    Private Sub carrega_empresa()
        txtrazaosocial.Text = empresa.sNomeRazao
        txtnomefant.Text = empresa.sNomefant
        txtendereco.Text = empresa.send
        txtnumero.Text = empresa.sNumero
        txtbairro.Text = empresa.sBairro
        txtcep.Text = empresa.sCEP
        txtcidade.Text = empresa.sNomeMunic
        txtuf.Text = empresa.sSiglaUF
        txtcodMunicipio.Text = empresa.sCodMunIBGE

        txtcnpj.Text = empresa.sCNPJ
        txtie.Text = empresa.sIe
        txtim.Text = empresa.sIm
        txtcnae.Text = empresa.Scnae
        txtfone.Text = empresa.Sfone

        cboconvenio.SelectedIndex = 2
        cbofin.SelectedIndex = 0
        cboop.SelectedIndex = 2
        txtcontato.Focus()
    End Sub

    Public Sub gerar_registro10(ByVal cnpj As String, ByVal ie As String, ByVal razao As String, ByVal cidade As String, ByVal uf As String, _
                  ByVal fone As String, ByVal dataini As String, ByVal datafim As String, ByVal convenio As String,
                  ByVal operacao As String, ByVal finalidade As String)

        If cnpj = "" Then
            Exit Sub
        End If

        Directory.CreateDirectory(Application.StartupPath & "\SINTEGRA")

        Dim arquivo As String = Application.StartupPath & "\SINTEGRA\Sintegra.txt"
        Dim sep As String = "|"




        Dim myList As New ArrayList


        If IO.File.Exists(arquivo) Then
            File.Delete(arquivo)
        End If



        Using writer As StreamWriter = New StreamWriter(arquivo, True)

            writer.WriteLine("10" & cnpj & ie.PadRight(14, " ") & razao.PadRight(35, " ").Substring(0, 35) & cidade.PadRight(30, " ").Substring(0, 30) & uf & fone.PadRight(10, " ") & dataini & datafim & convenio & operacao & finalidade)

        End Using
    End Sub

    Public Sub gerar_registro11(ByVal endereco As String, ByVal nr As String, ByVal compl As String, ByVal bairro As String, ByVal cep As String, _
                  ByVal contato As String, ByVal fone As String)

        If cnpj_cert = "" Then
            Exit Sub
        End If

        Directory.CreateDirectory(Application.StartupPath & "\SINTEGRA")

        Dim arquivo As String = Application.StartupPath & "\SINTEGRA\Sintegra.txt"
        Dim sep As String = "|"



        Dim fluxoTexto As IO.StreamReader
        Dim myList As New ArrayList


        If IO.File.Exists(arquivo) Then
            fluxoTexto = New IO.StreamReader(arquivo)
            While fluxoTexto.Peek() > -1
                myList.Add(fluxoTexto.ReadLine())
            End While
            fluxoTexto.Close()
        End If

        File.Delete(arquivo)

        Using writer As StreamWriter = New StreamWriter(arquivo, True)
            For Each l In myList
                writer.WriteLine(l)
            Next

            writer.WriteLine("11" & endereco.PadRight(34, " ").Substring(0, 34) & nr.PadLeft(5, "0") & compl.PadRight(22, " ").Substring(0, 22) & bairro.PadRight(15, " ").Substring(0, 15) & cep & contato.PadRight(28, " ").Substring(0, 28) & fone.PadLeft(12, "0"))



        End Using
    End Sub

    Public Sub gerar_registro50(ByVal cnpj As String, ByVal ie As String, ByVal data_emissao As String, ByVal uf As String, ByVal mode As String, ByVal serie As String, _
                 ByVal nrnf As String, ByVal cfop As String, ByVal tipo As String, ByVal vlrtotal As String, ByVal bcicms As String, ByVal vlricms As String, _
                 ByVal vlrnaoisento As String, ByVal vlroutros As String, ByVal aliq As String, Optional ByVal ti As String = "N")


        If cnpj = "" Then
            Exit Sub
        End If

        If serie = "0" Then
            serie = ""
        End If

        If nrnf.Length > 6 Then
            nrnf = nrnf.Substring(nrnf.Length - 6, 6)
        End If

        Directory.CreateDirectory(Application.StartupPath & "\SINTEGRA")

        Dim arquivo As String = Application.StartupPath & "\SINTEGRA\Sintegra.txt"
        Dim sep As String = "|"



        Dim fluxoTexto As IO.StreamReader
        Dim myList As New ArrayList


        If IO.File.Exists(arquivo) Then
            fluxoTexto = New IO.StreamReader(arquivo)
            While fluxoTexto.Peek() > -1
                myList.Add(fluxoTexto.ReadLine())
            End While
            fluxoTexto.Close()
        End If

        File.Delete(arquivo)

        Using writer As StreamWriter = New StreamWriter(arquivo, True)
            For Each l In myList
                writer.WriteLine(l)
            Next

            writer.WriteLine("50" & cnpj & ie.PadRight(14, " ") & data_emissao & uf & mode & serie.PadRight(3, " ") & nrnf.PadLeft(6, "0") & cfop & tipo & vlrtotal.PadLeft(13, "0") & bcicms.PadLeft(13, "0") & vlricms.PadLeft(13, "0") & vlrnaoisento.PadLeft(13, "0") & vlroutros.PadLeft(13, "0") & aliq.PadRight(4, "0") & ti)

        End Using
    End Sub

    Public Sub gerar_registro53(ByVal cnpj As String, ByVal ie As String, ByVal data_emissao As String, ByVal uf As String, ByVal mode As String, ByVal serie As String, ByVal nr As String,
                              ByVal cfop As String, ByVal tipo As String, ByVal bcst As String, ByVal vlrst As String, ByVal vlroutros As String)

        If cnpj = "" Then
            Exit Sub
        End If
        Dim bc As String = ""

        If serie = "0" Then
            serie = ""
        End If

        Directory.CreateDirectory(Application.StartupPath & "\SINTEGRA")

        Dim arquivo As String = Application.StartupPath & "\SINTEGRA\Sintegra.txt"
        Dim sep As String = "|"



        Dim fluxoTexto As IO.StreamReader
        Dim myList As New ArrayList


        If IO.File.Exists(arquivo) Then
            fluxoTexto = New IO.StreamReader(arquivo)
            While fluxoTexto.Peek() > -1
                myList.Add(fluxoTexto.ReadLine())
            End While
            fluxoTexto.Close()
        End If

        File.Delete(arquivo)

        Using writer As StreamWriter = New StreamWriter(arquivo, True)
            For Each l In myList
                writer.WriteLine(l)
            Next

            writer.WriteLine("53" & cnpj & ie.PadRight(14, " ") & data_emissao & uf & mode & serie.PadRight(3, " ") & nr.PadLeft(6, "0") & cfop & tipo & bcst.PadLeft(13, "0") & vlrst.PadLeft(13, "0") & vlroutros.PadLeft(13, "0") & "N4" & bc.PadLeft(29, " "))

        End Using
    End Sub

    Public Sub gerar_registro54(ByVal cnpj As String, ByVal mode As String, ByVal serie As String, ByVal nrnf As String, ByVal cfop As String, ByVal cst As String,
                                ByVal nritem As String, ByVal cod_prod As String, ByVal qtde As String, ByVal vlrprod As String, ByVal vlrdesc As String, ByVal bcicms As String, _
                               ByVal bcsticms As String, ByVal vlripi As String, ByVal aliq_icms As String)

        If cnpj = "" Then
            Exit Sub
        End If

        If qtde <> "" Then
            qtde = Format(CDec(qtde), "###0.000")
            qtde = format_val_sintegra(qtde)
        End If

        If serie = "0" Then
            serie = ""
        End If

        If nrnf.Length > 6 Then
            nrnf = nrnf.Substring(nrnf.Length - 6, 6)
        End If

        Directory.CreateDirectory(Application.StartupPath & "\SINTEGRA")

        Dim arquivo As String = Application.StartupPath & "\SINTEGRA\Sintegra.txt"
        Dim sep As String = "|"



        Dim fluxoTexto As IO.StreamReader
        Dim myList As New ArrayList


        If IO.File.Exists(arquivo) Then
            fluxoTexto = New IO.StreamReader(arquivo)
            While fluxoTexto.Peek() > -1
                myList.Add(fluxoTexto.ReadLine())
            End While
            fluxoTexto.Close()
        End If

        File.Delete(arquivo)

        Using writer As StreamWriter = New StreamWriter(arquivo, True)
            For Each l In myList
                writer.WriteLine(l)
            Next

            writer.WriteLine("54" & cnpj & mode & serie.PadRight(3, " ") & nrnf.PadLeft(6, "0") & cfop & cst & nritem.PadLeft(3, "0") & cod_prod.PadRight(14, " ") & qtde.PadLeft(11, "0") & vlrprod.PadLeft(12, "0") & vlrprod.PadLeft(12, "0") & bcicms.PadLeft(12, "0") & bcsticms.PadLeft(12, "0") & vlripi.PadLeft(12, "0") & aliq_icms.PadRight(4, "0"))

        End Using
    End Sub

    Public Sub gerar_registro61(ByVal data_emi As String, ByVal mode As String, ByVal serie As String, ByVal nrnf_ini As String, ByVal nrnf_fim As String, ByVal vlrtotal As String, _
                                ByVal bcicms As String, ByVal vlricms As String, ByVal vlrisento As String, ByVal vlroutros As String, ByVal aliqicms As String)

        If cnpj_cert = "" Then
            Exit Sub
        End If
        Dim bc As String = ""
        Dim subs As String = ""

        If serie = "0" Then
            serie = ""
        End If

        If nrnf_ini.Length > 6 Then
            nrnf_ini = nrnf_ini.Substring(nrnf_ini.Length - 6, 6)
        End If
        If nrnf_fim.Length > 6 Then
            nrnf_fim = nrnf_fim.Substring(nrnf_fim.Length - 6, 6)
        End If

        Directory.CreateDirectory(Application.StartupPath & "\SINTEGRA")

        Dim arquivo As String = Application.StartupPath & "\SINTEGRA\Sintegra.txt"
        Dim sep As String = "|"



        Dim fluxoTexto As IO.StreamReader
        Dim myList As New ArrayList


        If IO.File.Exists(arquivo) Then
            fluxoTexto = New IO.StreamReader(arquivo)
            While fluxoTexto.Peek() > -1
                myList.Add(fluxoTexto.ReadLine())
            End While
            fluxoTexto.Close()
        End If

        File.Delete(arquivo)

        Using writer As StreamWriter = New StreamWriter(arquivo, True)
            For Each l In myList
                writer.WriteLine(l)
            Next

            writer.WriteLine("61" & bc.PadLeft(28, " ") & data_emi & mode & serie.PadRight(3, " ") & subs.PadRight(2, " ") & nrnf_ini.PadLeft(6, "0") & nrnf_fim.PadLeft(6, "0") & vlrtotal.PadLeft(13, "0") & bcicms.PadLeft(13, "0") & vlricms.PadLeft(12, "0") & vlrisento.PadLeft(13, "0") & vlroutros.PadLeft(13, "0") & aliqicms.PadRight(4, "0") & bc.PadLeft(1, " "))

        End Using
    End Sub

    Public Sub gerar_registro70(ByVal cnpj As String, ByVal ie As String, ByVal data_emissao As String, ByVal uf As String, ByVal mode As String, ByVal serie As String, _
               ByVal nrnf As String, ByVal cfop As String, ByVal vlrtotal As String, ByVal bcicms As String, ByVal vlricms As String, _
               ByVal vlrnaoisento As String, ByVal vlroutros As String)


        If cnpj = "" Then
            Exit Sub
        End If

        serie = serie.Substring(0, 1)





        If nrnf.Length > 6 Then
            nrnf = nrnf.Substring(nrnf.Length - 6, 6)
        End If

        Directory.CreateDirectory(Application.StartupPath & "\SINTEGRA")

        Dim arquivo As String = Application.StartupPath & "\SINTEGRA\Sintegra.txt"
        Dim sep As String = "|"



        Dim fluxoTexto As IO.StreamReader
        Dim myList As New ArrayList


        If IO.File.Exists(arquivo) Then
            fluxoTexto = New IO.StreamReader(arquivo)
            While fluxoTexto.Peek() > -1
                myList.Add(fluxoTexto.ReadLine())
            End While
            fluxoTexto.Close()
        End If

        File.Delete(arquivo)

        Using writer As StreamWriter = New StreamWriter(arquivo, True)
            For Each l In myList
                writer.WriteLine(l)
            Next

            writer.WriteLine("70" & cnpj & ie.PadRight(14, " ") & data_emissao & uf & mode & serie & "  " & nrnf.PadLeft(6, "0") & cfop & vlrtotal.PadLeft(13, "0") & bcicms.PadLeft(14, "0") & vlricms.PadLeft(14, "0") & vlrnaoisento.PadLeft(14, "0") & vlroutros.PadLeft(14, "0") & "1N")

        End Using
    End Sub

    Public Sub gerar_registro74(ByVal data_inv As String, ByVal cod_prod As String, ByVal qtde As String, ByVal vlr_prod As String, ByVal cnpj As String, ByVal ie As String, ByVal uf As String)

        Dim bc As String = ""
        If cnpj = "" Then
            Exit Sub
        End If

        Directory.CreateDirectory(Application.StartupPath & "\SINTEGRA")

        Dim arquivo As String = Application.StartupPath & "\SINTEGRA\Sintegra.txt"
        Dim sep As String = "|"



        Dim fluxoTexto As IO.StreamReader
        Dim myList As New ArrayList


        If IO.File.Exists(arquivo) Then
            fluxoTexto = New IO.StreamReader(arquivo)
            While fluxoTexto.Peek() > -1
                myList.Add(fluxoTexto.ReadLine())
            End While
            fluxoTexto.Close()
        End If

        File.Delete(arquivo)

        Using writer As StreamWriter = New StreamWriter(arquivo, True)
            For Each l In myList
                writer.WriteLine(l)
            Next

            writer.WriteLine("74" & data_inv & cod_prod.PadRight(14, " ") & qtde.PadLeft(13, "0") & vlr_prod.PadRight(13, "0") & "1" & cnpj & ie.PadRight(14, " ") & uf & bc.PadLeft(45, " "))

        End Using
    End Sub

    Public Sub gerar_registro75(ByVal dini As String, ByVal dfim As String, ByVal cod_prod As String, ByVal ncm As String, ByVal desc As String, ByVal un As String, _
               ByVal aliq_ipi As String, ByVal aliq_icms As String, ByVal red_bcicms As String, ByVal bcst As String)

        Directory.CreateDirectory(Application.StartupPath & "\SINTEGRA")

        Dim arquivo As String = Application.StartupPath & "\SINTEGRA\Sintegra.txt"
        Dim sep As String = "|"

        If desc.Length > 53 Then
            desc = desc.Substring(0, 53)
        End If

        Dim fluxoTexto As IO.StreamReader
        Dim myList As New ArrayList


        If IO.File.Exists(arquivo) Then
            fluxoTexto = New IO.StreamReader(arquivo)
            While fluxoTexto.Peek() > -1
                myList.Add(fluxoTexto.ReadLine())
            End While
            fluxoTexto.Close()
        End If

        File.Delete(arquivo)

        Using writer As StreamWriter = New StreamWriter(arquivo, True)
            For Each l In myList
                writer.WriteLine(l)
            Next

            writer.WriteLine("75" & dini & dfim & cod_prod.ToString.PadRight(14, " ") & ncm & desc.ToString.PadRight(53, " ") & un.ToString.PadRight(6, " ") & aliq_ipi.PadLeft(5, "0") & aliq_icms.PadLeft(4, "0") & red_bcicms.PadLeft(5, "0") & bcst.PadLeft(13, "0"))

        End Using
    End Sub

    Public Sub gerar_registro88(ByVal ean_p As String, ByVal cod_prod As String, ByVal desc As String, ByVal un As String, ByVal ean As String)

        Directory.CreateDirectory(Application.StartupPath & "\SINTEGRA")

        Dim arquivo As String = Application.StartupPath & "\SINTEGRA\Sintegra.txt"
        Dim sep As String = "|"

        If desc.Length > 53 Then
            desc = desc.Substring(0, 53)
        End If

        Dim fluxoTexto As IO.StreamReader
        Dim myList As New ArrayList


        If IO.File.Exists(arquivo) Then
            fluxoTexto = New IO.StreamReader(arquivo)
            While fluxoTexto.Peek() > -1
                myList.Add(fluxoTexto.ReadLine())
            End While
            fluxoTexto.Close()
        End If

        File.Delete(arquivo)

        Using writer As StreamWriter = New StreamWriter(arquivo, True)
            For Each l In myList
                writer.WriteLine(l)
            Next

            writer.WriteLine("88EAN" & ean_p & cod_prod.ToString.PadRight(14, " ") & desc.ToString.PadRight(53, " ") & un.ToString.PadRight(6, " ") & ean.PadLeft(14, "0"))

        End Using
    End Sub

    Public Sub gerar_registro90(ByVal reg As String)

        Directory.CreateDirectory(Application.StartupPath & "\SINTEGRA")

        Dim arquivo As String = Application.StartupPath & "\SINTEGRA\Sintegra.txt"
        Dim sep As String = "|"


        Dim fluxoTexto As IO.StreamReader
        Dim myList As New ArrayList


        If IO.File.Exists(arquivo) Then
            fluxoTexto = New IO.StreamReader(arquivo)
            While fluxoTexto.Peek() > -1
                myList.Add(fluxoTexto.ReadLine())
            End While
            fluxoTexto.Close()
        End If

        File.Delete(arquivo)

        Using writer As StreamWriter = New StreamWriter(arquivo, True)
            For Each l In myList
                writer.WriteLine(l)
            Next

            writer.WriteLine(reg)

        End Using
    End Sub

    Private Sub bntsintegra_Click(sender As Object, e As EventArgs) Handles bntsintegra.Click

        If txtcontato.Text = "" Then
            MsgBox("Informe o Contato ?", MsgBoxStyle.Exclamation, "Aviso !")
            txtcontato.Focus()
            Exit Sub
        End If

        lblinfo.Visible = True
        lblinfo.Text = "Gerando registro 10, aguarde..."
        lblinfo.Refresh()
        gerar_registro10(txtcnpj.Text, txtie.Text, txtrazaosocial.Text, txtcidade.Text, txtuf.Text, txtfone.Text, Convert.ToDateTime(data_ini.Text).ToString("yyyyMMdd"), _
                   Convert.ToDateTime(data_fim.Text).ToString("yyyyMMdd"), cboconvenio.Text.Substring(0, 1), cboop.Text.Substring(0, 1), cbofin.Text.Substring(0, 1))

        lblinfo.Text = "Gerando registro 11, aguarde..."
        lblinfo.Refresh()
        gerar_registro11(txtendereco.Text, txtnumero.Text, "", txtbairro.Text, txtcep.Text, txtcontato.Text, txtfone.Text)


        gerar50_ent()
        gerar50_sai()
        gerar53()
        gerar54_ent()
        gerar54_sai()
        gerar61()
        gerar70_ent()
        gerar75()

        gerar90()

        lblinfo.Visible = False
        MsgBox("Arquivo gerado com sucesso !")

    End Sub

    Private Sub gerar50_ent()
        Dim vlris As String = "0"
        Dim vlroutr As String = "0"
        Dim cont As Integer = 0
        Dim contreg As Integer = 0

        dgv50iten.Rows.Clear()
        executa_query("update sintegra_contreg set reg50 = '0', reg52 = '0', reg53 = '0', reg54 = '0', reg61 = '0', reg75 = '0', reg88 = '0'")

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from nfe_e INNER JOIN cliente ON nfe_e.cnpj_for = cliente.cnpjcpf_cli INNER JOIN municipio ON cliente.cod_munic = municipio.codigo_municipio WHERE nfe_e.data_ent between '" & Convert.ToDateTime(data_ini.Value).ToString("yyyy-MM-dd") & "' AND '" & Convert.ToDateTime(data_fim.Value).ToString("yyyy-MM-dd") & "' and (nfe_e.modelo_nfe = '55' or nfe_e.modelo_nfe = '01')"


        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read



                conectar_mysql2()
                Dim SQLcommand2 As MySqlCommand
                SQLcommand2 = oConn2.CreateCommand
                SQLcommand2.CommandText = "select * from nfe_eitens where chave_par = '" & reader("chave_par") & "'"

                dgv50iten.Rows.Clear()



                Using dr As MySqlDataReader = SQLcommand2.ExecuteReader

                    While dr.Read
                        cont += 1
                        lblinfo.Text = "Gerando registro 50, reg: " & cont & ", aguarde..."
                        lblinfo.Refresh()

                        Dim pes As String = pesquisa_grid(dr("cfop") & format_val_sintegra(dr("aliq_icms")))


                        If pes = "not" Then

                            If dr("cst").ToString.Length = 3 Then
                                If dr("cst").ToString.Substring(1, 2) = "40" Or dr("cst").ToString.Substring(1, 2) = "41" Then
                                    vlris = dr("vlr_total")
                                Else
                                    vlris = "0,00"
                                End If
                            Else
                                If dr("cst").ToString.Substring(1, 3) = "103" Or dr("cst").ToString.Substring(1, 2) = "300" Or dr("cst").ToString.Substring(1, 2) = "400" Or dr("cst").ToString.Substring(1, 2) = "103" Then
                                    vlris = dr("vlr_total")
                                Else
                                    vlris = "0,00"
                                End If
                            End If

                            If format_val_sintegra(dr("aliq_icms")) <> "000" Then
                                vlroutr = dr("vlr_outros")
                            Else
                                vlroutr = dr("vlr_total")
                            End If


                            dgv50iten.Rows.Add(reader("cnpjcpf_cli"), reader("ierg_cli"), Convert.ToDateTime(reader("data_ent")).ToString("yyyyMMdd"), reader("uf"), reader("modelo_nfe"), reader("serie_nfe"), reader("numero_nfe"), dr("cfop"), dr("vlr_total"), dr("bc_icms"), dr("vlr_icms"), vlris, vlroutr, format_val_sintegra(dr("aliq_icms")), dr("cfop") & format_val_sintegra(dr("aliq_icms")))

                        Else


                            If dr("cst").ToString.Length = 3 Then
                                If dr("cst").ToString.Substring(1, 2) = "40" Or dr("cst").ToString.Substring(1, 2) = "41" Then
                                    dgv50iten.Rows.Item(pes).Cells("vlr_isentogrid").Value = CDec(dgv50iten.Rows.Item(pes).Cells("vlr_isentogrid").Value) + CDec(dr("vlr_total"))
                                End If
                            Else
                                If dr("cst").ToString.Substring(1, 3) = "103" Or dr("cst").ToString.Substring(1, 2) = "300" Or dr("cst").ToString.Substring(1, 2) = "400" Or dr("cst").ToString.Substring(1, 2) = "103" Then
                                    dgv50iten.Rows.Item(pes).Cells("vlr_isentogrid").Value = CDec(dgv50iten.Rows.Item(pes).Cells("vlr_isentogrid").Value) + CDec(dr("vlr_total"))
                                End If
                            End If


                            If format_val_sintegra(dr("aliq_icms")) <> "000" Then
                                dgv50iten.Rows.Item(pes).Cells("vlr_outrosgrid").Value = CDec(dgv50iten.Rows.Item(pes).Cells("vlr_outrosgrid").Value) + CDec(dr("vlr_outros"))
                            Else
                                dgv50iten.Rows.Item(pes).Cells("vlr_outrosgrid").Value = CDec(dgv50iten.Rows.Item(pes).Cells("vlr_outrosgrid").Value) + CDec(dr("vlr_total"))
                            End If

                            dgv50iten.Rows.Item(pes).Cells("vlr_totalgrid").Value = CDec(dgv50iten.Rows.Item(pes).Cells("vlr_totalgrid").Value) + CDec(dr("vlr_total"))
                            dgv50iten.Rows.Item(pes).Cells("bc_icms_grid").Value = CDec(dgv50iten.Rows.Item(pes).Cells("bc_icms_grid").Value) + CDec(dr("bc_icms"))
                            dgv50iten.Rows.Item(pes).Cells("vlr_icmsgrid").Value = CDec(dgv50iten.Rows.Item(pes).Cells("vlr_icmsgrid").Value) + CDec(dr("vlr_icms"))

                        End If
                    End While

                End Using


                For Each row As DataGridViewRow In dgv50iten.Rows
                    gerar_registro50(row.Cells("cnpj_grid").Value, row.Cells("ie_grid").Value, row.Cells("data_entgrid").Value, row.Cells("uf_grid").Value, row.Cells("modelo_grid").Value, row.Cells("serie_grid").Value, row.Cells("nrnfe_grid").Value, row.Cells("cfop_grid").Value, "T", format_val_sintegra(row.Cells("vlr_totalgrid").Value), format_val_sintegra(row.Cells("bc_icms_grid").Value), format_val_sintegra(row.Cells("vlr_icmsgrid").Value), format_val_sintegra(row.Cells("vlr_isentogrid").Value), format_val_sintegra(row.Cells("vlr_outrosgrid").Value), row.Cells("aliq_grid").Value)

                    contreg += 1
                Next



            End While

        End Using

        executa_query("update sintegra_contreg set reg50 = '" & contreg & "'")

    End Sub

    Private Sub gerar50_sai()
        Dim vlris As String = "0"
        Dim vlroutr As String = "0"
        Dim cont As Integer = 0
        Dim contreg As Integer = 0

        dgv50iten.Rows.Clear()

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from nfe_s INNER JOIN cliente ON nfe_s.cnpj_cli = cliente.cnpjcpf_cli INNER JOIN municipio ON cliente.cod_munic = municipio.codigo_municipio WHERE nfe_s.Data_emissao_nfe between '" & Convert.ToDateTime(data_ini.Value).ToString("yyyy-MM-dd 00:00:00") & "' AND '" & Convert.ToDateTime(data_fim.Value).ToString("yyyy-MM-dd 23:59:59") & "' and (nfe_s.Modelo_nfe = '55' or nfe_s.Modelo_nfe = '01') and cstat = '100'"


        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read



                conectar_mysql2()
                Dim SQLcommand2 As MySqlCommand
                SQLcommand2 = oConn2.CreateCommand
                SQLcommand2.CommandText = "select * from nfe_sitens where Chave_nfe = '" & reader("Chave_nfe") & "'"

                dgv50iten.Rows.Clear()



                Using dr As MySqlDataReader = SQLcommand2.ExecuteReader

                    While dr.Read
                        cont += 1
                        lblinfo.Text = "Gerando registro 50, reg: " & cont & ", aguarde..."
                        lblinfo.Refresh()

                        Dim pes As String = pesquisa_grid(dr("cfop") & format_val_sintegra(dr("aliq_icms")))


                        If pes = "not" Then

                            If dr("cst").ToString.Length = 3 Then
                                If dr("cst").ToString.Substring(1, 2) = "40" Or dr("cst").ToString.Substring(1, 2) = "41" Then
                                    vlris = dr("vlr_total")
                                Else
                                    vlris = "0,00"
                                End If
                            Else
                                If dr("cst").ToString.Substring(1, 3) = "103" Or dr("cst").ToString.Substring(1, 2) = "300" Or dr("cst").ToString.Substring(1, 2) = "400" Or dr("cst").ToString.Substring(1, 2) = "103" Then
                                    vlris = dr("vlr_total")
                                Else
                                    vlris = "0,00"
                                End If
                            End If

                            If format_val_sintegra(dr("aliq_icms")) <> "000" Then
                                vlroutr = dr("vlr_outros")
                            Else
                                vlroutr = dr("vlr_total")
                            End If


                            dgv50iten.Rows.Add(reader("cnpjcpf_cli"), reader("ierg_cli"), Convert.ToDateTime(reader("Data_emissao_nfe")).ToString("yyyyMMdd"), reader("uf"), reader("Modelo_nfe"), reader("Serie_nfe"), reader("Numero_nfe"), dr("cfop"), dr("vlr_total"), dr("bc_icms"), dr("vlr_icms"), vlris, vlroutr, format_val_sintegra(dr("aliq_icms")), dr("cfop") & format_val_sintegra(dr("aliq_icms")))

                        Else


                            If dr("cst").ToString.Length = 3 Then
                                If dr("cst").ToString.Substring(1, 2) = "40" Or dr("cst").ToString.Substring(1, 2) = "41" Then
                                    dgv50iten.Rows.Item(pes).Cells("vlr_isentogrid").Value = CDec(dgv50iten.Rows.Item(pes).Cells("vlr_isentogrid").Value) + CDec(dr("vlr_total"))
                                End If
                            Else
                                If dr("cst").ToString.Substring(1, 3) = "103" Or dr("cst").ToString.Substring(1, 2) = "300" Or dr("cst").ToString.Substring(1, 2) = "400" Or dr("cst").ToString.Substring(1, 2) = "103" Then
                                    dgv50iten.Rows.Item(pes).Cells("vlr_isentogrid").Value = CDec(dgv50iten.Rows.Item(pes).Cells("vlr_isentogrid").Value) + CDec(dr("vlr_total"))
                                End If
                            End If


                            If format_val_sintegra(dr("aliq_icms")) <> "000" Then
                                dgv50iten.Rows.Item(pes).Cells("vlr_outrosgrid").Value = CDec(dgv50iten.Rows.Item(pes).Cells("vlr_outrosgrid").Value) + CDec(dr("vlr_outros"))
                            Else
                                dgv50iten.Rows.Item(pes).Cells("vlr_outrosgrid").Value = CDec(dgv50iten.Rows.Item(pes).Cells("vlr_outrosgrid").Value) + CDec(dr("vlr_total"))
                            End If

                            dgv50iten.Rows.Item(pes).Cells("vlr_totalgrid").Value = CDec(dgv50iten.Rows.Item(pes).Cells("vlr_totalgrid").Value) + CDec(dr("vlr_total"))
                            dgv50iten.Rows.Item(pes).Cells("bc_icms_grid").Value = CDec(dgv50iten.Rows.Item(pes).Cells("bc_icms_grid").Value) + CDec(dr("bc_icms"))
                            dgv50iten.Rows.Item(pes).Cells("vlr_icmsgrid").Value = CDec(dgv50iten.Rows.Item(pes).Cells("vlr_icmsgrid").Value) + CDec(dr("vlr_icms"))

                        End If
                    End While

                End Using


                For Each row As DataGridViewRow In dgv50iten.Rows
                    gerar_registro50(row.Cells("cnpj_grid").Value, row.Cells("ie_grid").Value, row.Cells("data_entgrid").Value, row.Cells("uf_grid").Value, row.Cells("modelo_grid").Value, row.Cells("serie_grid").Value, row.Cells("nrnfe_grid").Value, row.Cells("cfop_grid").Value, "P", format_val_sintegra(row.Cells("vlr_totalgrid").Value), format_val_sintegra(row.Cells("bc_icms_grid").Value), format_val_sintegra(row.Cells("vlr_icmsgrid").Value), format_val_sintegra(row.Cells("vlr_isentogrid").Value), format_val_sintegra(row.Cells("vlr_outrosgrid").Value), row.Cells("aliq_grid").Value)
                    contreg += 1
                Next



            End While

        End Using


        conectar_mysqlDFe()
        Dim SQLcommand33 As MySqlCommand
        SQLcommand33 = oConn.CreateCommand
        SQLcommand33.CommandText = "select * from nfe_s INNER JOIN cliente ON nfe_s.cnpj_cli = cliente.cnpjcpf_cli INNER JOIN municipio ON cliente.cod_munic = municipio.codigo_municipio WHERE nfe_s.Data_emissao_nfe between '" & Convert.ToDateTime(data_ini.Value).ToString("yyyy-MM-dd 00:00:00") & "' AND '" & Convert.ToDateTime(data_fim.Value).ToString("yyyy-MM-dd 23:59:59") & "' and (nfe_s.Modelo_nfe = '55' or nfe_s.Modelo_nfe = '01') cstat = '135'"


        Using reader As MySqlDataReader = SQLcommand33.ExecuteReader

            While reader.Read
                gerar_registro50(reader("cnpj_cli"), "ISENTO", Convert.ToDateTime(reader("Data_emissao_nfe")).ToString("yyyyMMdd"), reader("uf"), reader("Modelo_nfe"), reader("Serie_nfe"), reader("Numero_nfe"), "0000", "P", format_val_sintegra("0,00"), format_val_sintegra("0,00"), format_val_sintegra("0,00"), format_val_sintegra("0,00"), format_val_sintegra("0,00"), "0,00", "S")
                contreg += 1
            End While

        End Using

        contreg = CDec(contreg) + CDec(ret_valor_campo("select * from sintegra_contreg", "reg50"))
        executa_query("update sintegra_contreg set reg50 = '" & contreg & "'")
    End Sub

    Private Sub gerar54_sai()

        Dim cont As Integer = 0
        Dim cont2 As Integer = 0

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from nfe_s INNER JOIN cliente ON nfe_s.cnpj_cli = cliente.cnpjcpf_cli INNER JOIN municipio ON cliente.cod_munic = municipio.codigo_municipio WHERE nfe_s.Data_emissao_nfe between '" & Convert.ToDateTime(data_ini.Value).ToString("yyyy-MM-dd 00:00:00") & "' AND '" & Convert.ToDateTime(data_fim.Value).ToString("yyyy-MM-dd 23:59:59") & "' and (nfe_s.Modelo_nfe = '55' or nfe_s.Modelo_nfe = '01')"
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read

                conectar_mysql2()
                Dim SQLcommand2 As MySqlCommand
                SQLcommand2 = oConn2.CreateCommand
                SQLcommand2.CommandText = "select * from nfe_sitens where Chave_nfe = '" & reader("Chave_nfe") & "'"

                dgv50iten.Rows.Clear()

                cont = 0

                Using dr As MySqlDataReader = SQLcommand2.ExecuteReader

                    While dr.Read
                        cont += 1
                        cont2 += 1
                        lblinfo.Text = "Gerando registro 54, item: " & cont2 & ", aguarde..."
                        lblinfo.Refresh()

                        gerar_registro54(reader("cnpjcpf_cli"), reader("Modelo_nfe"), reader("Serie_nfe"), reader("Numero_nfe"), dr("cfop"), dr("cst"), cont, dr("codigo_prod"), dr("qtde"), format_val_sintegra(dr("vlr_unit")), format_val_sintegra(dr("vlr_desc")), format_val_sintegra(dr("bc_icms")), format_val_sintegra(dr("bc_st")), format_val_sintegra(dr("vlr_ipi")), format_val_sintegra(dr("aliq_icms")))


                        Dim re As String = pesquisa_grid_prod(dr("codigo_prod"))

                        If re = "not" Then
                            dgvprd.Rows.Add(dr("codigo_prod"))
                        End If

                    End While

                End Using



            End While

        End Using

        cont2 = CDec(cont2) + CDec(ret_valor_campo("select * from sintegra_contreg", "reg54"))
        executa_query("update sintegra_contreg set reg54 = '" & cont2 & "'")
    End Sub

    Private Sub gerar54_ent()

        Dim cont As Integer = 0
        Dim cont2 As Integer = 0

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from nfe_e INNER JOIN cliente ON nfe_e.cnpj_for = cliente.cnpjcpf_cli INNER JOIN municipio ON cliente.cod_munic = municipio.codigo_municipio WHERE nfe_e.data_ent between '" & Convert.ToDateTime(data_ini.Value).ToString("yyyy-MM-dd") & "' AND '" & Convert.ToDateTime(data_fim.Value).ToString("yyyy-MM-dd") & "' and (nfe_e.modelo_nfe = '55' or nfe_e.modelo_nfe = '01')"
        dgvprd.Rows.Clear()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read



                conectar_mysql2()
                Dim SQLcommand2 As MySqlCommand
                SQLcommand2 = oConn2.CreateCommand
                SQLcommand2.CommandText = "select * from nfe_eitens where chave_par = '" & reader("chave_par") & "'"

                dgv50iten.Rows.Clear()

                cont = 0

                Using dr As MySqlDataReader = SQLcommand2.ExecuteReader

                    While dr.Read
                        cont += 1
                        cont2 += 1
                        lblinfo.Text = "Gerando registro 54, item: " & cont2 & ", aguarde..."
                        lblinfo.Refresh()

                        gerar_registro54(reader("cnpjcpf_cli"), reader("modelo_nfe"), reader("serie_nfe"), reader("numero_nfe"), dr("cfop"), dr("cst"), cont, dr("codigo_prod"), dr("qtde"), format_val_sintegra(dr("vlr_unit")), format_val_sintegra(dr("vlr_desc")), format_val_sintegra(dr("bc_icms")), format_val_sintegra(dr("bc_st")), format_val_sintegra(dr("vlr_ipi")), format_val_sintegra(dr("aliq_icms")))


                        Dim re As String = pesquisa_grid_prod(dr("codigo_prod"))

                        If re = "not" Then
                            dgvprd.Rows.Add(dr("codigo_prod"))
                        End If

                    End While

                End Using



            End While

        End Using

        cont2 = CDec(cont2) + CDec(ret_valor_campo("select * from sintegra_contreg", "reg54"))
        executa_query("update sintegra_contreg set reg54 = '" & cont2 & "'")
    End Sub

    Private Sub gerar53()
        Dim vlris As String = "0"
        Dim vlroutr As String = "0"
        Dim cont As Integer = 0

        dgv50iten.Rows.Clear()

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from nfe_e INNER JOIN cliente ON nfe_e.cnpj_for = cliente.cnpjcpf_cli INNER JOIN municipio ON cliente.cod_munic = municipio.codigo_municipio WHERE nfe_e.Data_ent between '" & Convert.ToDateTime(data_ini.Value).ToString("yyyy-MM-dd") & "' AND '" & Convert.ToDateTime(data_fim.Value).ToString("yyyy-MM-dd") & "' and (nfe_e.modelo_nfe = '55' or nfe_e.modelo_nfe = '01')"


        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read
                Dim cfop As String
                If reader("uf") = empresa.sSiglaUF Then
                    cfop = "1403"
                Else
                    cfop = "2403"
                End If

                If reader("base_st") <> "0,00" Then
                    gerar_registro53(reader("cnpj_for"), reader("ierg_cli"), Convert.ToDateTime(reader("data_ent")).ToString("yyyyMMdd"), reader("uf"), reader("modelo_nfe"), reader("serie_nfe"), reader("numero_nfe"), cfop, "T", format_val_sintegra(reader("base_st")), format_val_sintegra(reader("vlr_st")), format_val_sintegra(reader("vlroutros")))
                    cont += 1
                End If


            End While

        End Using


        executa_query("update sintegra_contreg set reg53 = '" & cont & "'")
    End Sub

    Private Sub gerar61()
        Dim vlris As String = "0"
        Dim vlroutr As String = "0"
        Dim vlrisenta As String = "0"
        Dim bc_icms As String = "0"
        Dim vlricms As String = "0"
        Dim aliq As String = "0"
        Dim cont As Integer = 0
        Dim contreg As Integer = 0

        dgv50iten.Rows.Clear()

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from cfe WHERE data_emi between '" & Convert.ToDateTime(data_ini.Value).ToString("yyyy-MM-dd 00:00:00") & "' AND '" & Convert.ToDateTime(data_fim.Value).ToString("yyyy-MM-dd 23:59:59") & "' and cod_sit = '100'"


        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read



                conectar_mysql2()
                Dim SQLcommand2 As MySqlCommand
                SQLcommand2 = oConn2.CreateCommand
                SQLcommand2.CommandText = "select * from item_rv where rv = '" & reader("RV") & "'"

                dgv50iten.Rows.Clear()



                Using dr As MySqlDataReader = SQLcommand2.ExecuteReader
                    vlrisenta = "0"
                    bc_icms = "0"
                    vlricms = "0"
                    aliq = "0"

                    While dr.Read
                        cont += 1
                        lblinfo.Text = "Gerando registro 61, reg: " & cont & ", aguarde..."
                        lblinfo.Refresh()



                        aliq = dr("aliq_icms")

                        If dr("cst_prod").ToString.Length = 3 Then

                            If dr("cst_prod").ToString.Substring(1, 2) = "00" Or dr("cst_prod").ToString.Substring(1, 2) = "20" Then
                                bc_icms = Format(CDec(bc_icms) + CDec(dr("vlr_total")), "#,##0.00")
                                vlricms = Format(CDec(vlricms) + CDec(dr("vlr_icms")), "#,##0.00")
                            End If


                            If dr("cst_prod").ToString.Substring(1, 2) = "40" Or dr("cst_prod").ToString.Substring(1, 2) = "30" Or dr("cst_prod").ToString.Substring(1, 2) = "41" Then
                                vlrisenta = Format(CDec(vlrisenta) + CDec(dr("vlr_total")), "#,##0.00")
                            End If

                        Else

                            If dr("cst_prod").ToString.Length = 4 Then
                                If dr("cst_prod").ToString.Substring(1, 3) = "300" Or dr("cst_prod").ToString.Substring(1, 3) = "400" Or dr("cst_prod").ToString.Substring(1, 3) = "103" Then
                                    vlrisenta = Format(CDec(vlrisenta) + CDec(dr("vlr_total")), "#,##0.00")
                                End If
                            End If

                        End If


                    End While
                    contreg += 1
                    gerar_registro61(Convert.ToDateTime(reader("data_emi")).ToString("yyyyMMdd"), "65", reader("serie_nfce"), reader("numero_nfce"), reader("numero_nfce"), format_val_sintegra(reader("valor_total")), format_val_sintegra(bc_icms), format_val_sintegra(vlricms), format_val_sintegra(vlrisenta), format_val_sintegra("0,00"), format_val_sintegra(aliq))

                End Using

            End While

        End Using


        executa_query("update sintegra_contreg set reg61 = '" & contreg & "'")

    End Sub

    Private Sub gerar70_ent()
        Dim vlris As String = "0"
        Dim vlroutr As String = "0"
        Dim cont As Integer = 0

        dgv50iten.Rows.Clear()

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from nfe_e INNER JOIN cliente ON nfe_e.cnpj_for = cliente.cnpjcpf_cli INNER JOIN municipio ON cliente.cod_munic = municipio.codigo_municipio WHERE nfe_e.data_ent between '" & Convert.ToDateTime(data_ini.Value).ToString("yyyy-MM-dd") & "' AND '" & Convert.ToDateTime(data_fim.Value).ToString("yyyy-MM-dd") & "' and (nfe_e.modelo_nfe = '57' or nfe_e.modelo_nfe = '07' or nfe_e.modelo_nfe = '08')"
        '   dr = SQLcommand.ExecuteReader()

        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read

                cont += 1
                lblinfo.Text = "Gerando registro 70, Nr.: " & cont & ", aguarde..."
                lblinfo.Refresh()

                gerar_registro70(reader("cnpj_for"), reader("ierg_cli"), Convert.ToDateTime(reader("data_ent")).ToString("yyyyMMdd"), reader("uf"), reader("modelo_nfe"), reader("serie_nfe"), reader("numero_nfe"), reader("cfop"), format_val_sintegra(reader("vlr_totalnf")), format_val_sintegra(reader("base_icms")), format_val_sintegra(reader("vlr_icms")), format_val_sintegra("0,00"), format_val_sintegra(reader("vlroutros")))

            End While

        End Using


        executa_query("update sintegra_contreg set reg70 = '" & cont & "'")
    End Sub

    Private Sub gerar75()
        Dim cont As Integer = 0
        lblinfo.Text = "Gerando registro 75, aguarde..."
        lblinfo.Refresh()

        For Each row As DataGridViewRow In dgvprd.Rows


            conectar_mysqlDFe()
            Dim SQLcommand3 As MySqlCommand
            SQLcommand3 = oConn.CreateCommand
            SQLcommand3.CommandText = "select * from produto where codigo_prod = '" & row.Cells("codigo_prd").Value & "'"


            Using reader As MySqlDataReader = SQLcommand3.ExecuteReader

                While reader.Read

                    lblinfo.Text = "Gerando registro 75 Nr.: " & cont & ", aguarde..."
                    lblinfo.Refresh()

                    gerar_registro75(Convert.ToDateTime(data_ini.Text).ToString("yyyyMMdd"), Convert.ToDateTime(data_fim.Text).ToString("yyyyMMdd"), row.Cells("codigo_prd").Value, reader("ncm_prod"), RemoverAcentos(reader("desc_prod")), reader("unidade_prod"), format_val_sintegra(reader("aliq_ipi")), format_val_sintegra(reader("aliq_icms")), format_val_sintegra(reader("redbase_icms")), format_val_sintegra("0,00"))

                    cont += 1
                End While
            End Using

        Next



        executa_query("update sintegra_contreg set reg75 = '" & cont & "'")

        cont = 0
        For Each row As DataGridViewRow In dgvprd.Rows


            conectar_mysqlDFe()
            Dim SQLcommand3 As MySqlCommand
            SQLcommand3 = oConn.CreateCommand
            SQLcommand3.CommandText = "select * from produto where codigo_prod = '" & row.Cells("codigo_prd").Value & "'"


            Using reader As MySqlDataReader = SQLcommand3.ExecuteReader

                While reader.Read

                    lblinfo.Text = "Gerando registro 88 Nr.: " & cont & ", aguarde..."
                    lblinfo.Refresh()

                    Dim eanP As String = reader("barras_prod").ToString.TrimStart("0")

                    gerar_registro88(eanP.Length, row.Cells("codigo_prd").Value, reader("desc_prod"), reader("unidade_prod"), eanP)

                    cont += 1
                End While
            End Using

        Next


        executa_query("update sintegra_contreg set reg88 = '" & cont & "'")

        dgv50iten.Rows.Clear()
    End Sub

    Private Sub gerar90()
        Dim vlris As String = "0"
        Dim vlroutr As String = "0"
        Dim conttotal As Integer = 0
        reg90 = "90" & txtcnpj.Text & txtie.Text.PadRight(14, " ")

        dgv50iten.Rows.Clear()

        conectar_mysqlDFe()
        Dim SQLcommand As MySqlCommand
        SQLcommand = oConn.CreateCommand
        SQLcommand.CommandText = "select * from sintegra_contreg"


        Using reader As MySqlDataReader = SQLcommand.ExecuteReader

            While reader.Read
                conttotal = (CDec(reader("reg50")) + CDec(reader("reg52")) + CDec(reader("reg53")) + CDec(reader("reg54")) + CDec(reader("reg61")) + CDec(reader("reg70")) + CDec(reader("reg74")) + CDec(reader("reg75")) + CDec(reader("reg88"))) + 3
              
                If reader("reg50") <> "0" Then
                    reg90 = reg90 & "50" & reader("reg50").ToString.PadLeft(8, "0")
                End If
                If reader("reg52") <> "0" Then
                    reg90 = reg90 & "52" & reader("reg52").ToString.PadLeft(8, "0")
                End If
                If reader("reg53") <> "0" Then
                    reg90 = reg90 & "53" & reader("reg53").ToString.PadLeft(8, "0")
                End If
                If reader("reg54") <> "0" Then
                    reg90 = reg90 & "54" & reader("reg54").ToString.PadLeft(8, "0")
                End If
                If reader("reg61") <> "0" Then
                    reg90 = reg90 & "61" & reader("reg61").ToString.PadLeft(8, "0")
                End If
                If reader("reg70") <> "0" Then
                    reg90 = reg90 & "70" & reader("reg70").ToString.PadLeft(8, "0")
                End If
                If reader("reg74") <> "0" Then
                    reg90 = reg90 & "74" & reader("reg74").ToString.PadLeft(8, "0")
                End If
                If reader("reg75") <> "0" Then
                    reg90 = reg90 & "75" & reader("reg75").ToString.PadLeft(8, "0")
                End If
                If reader("reg88") <> "0" Then
                    reg90 = reg90 & "88" & reader("reg88").ToString.PadLeft(8, "0")
                End If

                If conttotal <> "0" Then
                    reg90 = reg90 & "99" & conttotal.ToString.PadLeft(8, "0")
                End If

                reg90 = reg90.ToString.PadRight(125, " ") & "1"

                gerar_registro90(reg90)

            End While

        End Using

    End Sub

    Private Function pesquisa_grid(ByVal id As String) As String

        Dim r As String = "not"

        For Each row As DataGridViewRow In Me.dgv50iten.Rows

            If Not row.IsNewRow Then
                If row.Cells("chave_pargrid").Value = id Then
                    Return row.Index
                End If
            End If

        Next

        Return r

    End Function

    Private Function pesquisa_grid_prod(ByVal id As String) As String

        Dim r As String = "not"

        For Each row As DataGridViewRow In Me.dgvprd.Rows

            If Not row.IsNewRow Then
                If row.Cells("codigo_prd").Value = id Then
                    Return row.Index
                End If
            End If

        Next

        Return r

    End Function

    Private Sub chkinven_CheckedChanged(sender As Object, e As EventArgs) Handles chkinven.CheckedChanged
        If chkinven.Checked = True Then
            Data_invent.Enabled = True
        Else
            Data_invent.Enabled = False
        End If
    End Sub
End Class