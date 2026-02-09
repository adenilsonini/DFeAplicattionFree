Imports MySql.Data.MySqlClient

Public Class frmconfig_UserBanco
    Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\config_DB_Root.ini")
    Private Sub frmconfig_UserBanco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtuser.Text = arquivoIni.Read("User", "ROOT")
        txtpassword.Text = Crypto.Descrip_licenca(arquivoIni.Read("Password", "ROOT"))
        MsgBox("O usuario de acesso banco (dfe) não exite no banco mysql !", MsgBoxStyle.Exclamation, "Aviso user Rede !")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        arquivoIni.Write("User", txtuser.Text, "ROOT")

        If txtpassword.Text.Length <> 0 Then
            arquivoIni.Write("Password", Crypto.Crip_licenca(txtpassword.Text), "ROOT")
        End If



        Try

            Using connection As MySqlConnection = DB_mysql.ConexaoBD()

                If UsuarioExisteBanco("dfe", "localhost") = False Then
                    Using mySqlCommand As MySqlCommand = New MySqlCommand("create user 'dfe' @'localhost'", connection)
                        mySqlCommand.ExecuteNonQuery()
                    End Using

                    Using mySqlCommand As MySqlCommand = New MySqlCommand("GRANT ALL PRIVILEGES ON *.* TO 'dfe' @'localhost' IDENTIFIED BY 'Pe$$w0rd1@' WITH GRANT OPTION", connection)
                        mySqlCommand.ExecuteNonQuery()
                    End Using
                End If

                If UsuarioExisteBanco("dfe", "%") = False Then
                    Using mySqlCommand As MySqlCommand = New MySqlCommand("create user 'dfe' @'%'", connection)

                        mySqlCommand.ExecuteNonQuery()
                    End Using
                    Using mySqlCommand As MySqlCommand = New MySqlCommand("GRANT ALL PRIVILEGES ON *.* TO 'dfe' @'%' IDENTIFIED BY 'Pe$$w0rd1@' WITH GRANT OPTION", connection)
                        mySqlCommand.ExecuteNonQuery()
                    End Using
                End If


                MsgBox("Conexão testada, Retorno Ok !", MsgBoxStyle.Information, "Aviso Config Erro:")

                Me.Close()
                frmcert.Show()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Aviso Config Erro:")
            MsgBox("Usuario ou senha invalidos !!!!", MsgBoxStyle.Exclamation, "Aviso Config Erro:")
            txtuser.Focus()
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub
End Class