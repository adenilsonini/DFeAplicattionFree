Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Public Class Crypto

    Private Shared DES As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
    Private Shared TripleDES As New TripleDESCryptoServiceProvider()
    Private Shared MD5 As New MD5CryptoServiceProvider()

    Private Shared sal() As Byte = {&H0, &H1, &H2, &H3, &H4, &H5, &H6, &H5, &H4, &H3, &H2, &H1, &H0}
    ' Definição da chave de encriptação/desencriptação
    '  key antigo abaixo
    '  Private Const key As String = "ERMsJfHgBWWrh8vc5JXx8leIMnjlryyRB"

    Private Const key As String = "9T/X.vLw/=Ky}!OH5z$/0*jGZ1o ;`pqikn(NMcIx(>V`q-A@Y"

    Private Const keypassword As String = "8~L9a n!G|'U/6@:IvN~${Wj=Tzw4b"
    ''' <summary>
    ''' Calcula o MD5 Hash
    ''' </summary>
    ''' <param name="value">Chave</param>
    Public Shared Function MD5Hash(ByVal value As String) As Byte()

        ' Converte a chave para um array de bytes
        Dim byteArray() As Byte = ASCIIEncoding.ASCII.GetBytes(value)
        Return MD5.ComputeHash(byteArray)

    End Function

    ''' <summary>
    ''' Encripta uma string com base em uma chave
    ''' </summary>
    ''' <param name="stringToEncrypt">String a encriptar</param>
    Public Shared Function cryptomd5(ByVal stringToEncrypt As String) As String

        Try

            ' Definição da chave e da cifra (que neste caso é Electronic
            ' Codebook, ou seja, encriptação individual para cada bloco)
            TripleDES.Key = Crypto.MD5Hash(key)
            TripleDES.Mode = CipherMode.ECB

            ' Converte a string para bytes e encripta
            Dim Buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(stringToEncrypt)
            Return Convert.ToBase64String(TripleDES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return String.Empty

        End Try

    End Function

    Public Shared Function Encrypt(ByVal stringToEncrypt As String) As String
        If String.IsNullOrEmpty(stringToEncrypt) Then
            Return ""
        End If
        Crypto.DES.Key = Crypto.MD5Hash(key)
        Crypto.DES.Mode = CipherMode.ECB
        Dim bytes As Byte() = Encoding.ASCII.GetBytes(stringToEncrypt)
        Return Convert.ToBase64String(Crypto.DES.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length))
    End Function

    Public Shared Function Decrypt2(ByVal encryptedString As String) As String
        Dim str As String = ""

        Try
            Crypto.DES.Key = Crypto.MD5Hash(key)
            Crypto.DES.Mode = CipherMode.ECB
            Dim inputBuffer As Byte() = Convert.FromBase64String(encryptedString)
            str = Encoding.ASCII.GetString(Crypto.DES.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length))
        Catch ex As Exception
            Dim num As Integer = CInt(MessageBox.Show("Invalid Key", "Decryption Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation))

        End Try

        Return str
    End Function
    ''' <summary>
    ''' Desencripta uma string com base em uma chave
    ''' </summary>
    ''' <param name="encryptedString">String a decriptar</param>
    Public Shared Function Decrypt(ByVal encryptedString As String) As String

        Try

            ' Definição da chave e da cifra
            TripleDES.Key = Crypto.MD5Hash(key)
            TripleDES.Mode = CipherMode.ECB

            ' Converte a string encriptada para bytes e decripta
            Dim Buffer As Byte() = Convert.FromBase64String(encryptedString)
            Return ASCIIEncoding.ASCII.GetString(TripleDES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return String.Empty

        End Try

    End Function


    ''' <summary>
    ''' Rotina abaixo criptografia simetrica
    ''' </summary>
    Public Shared Function Crip_licenca(ByVal texto_cry As String) As String

        Try
            If String.IsNullOrEmpty(texto_cry) = False Then
                Dim chave As New Rfc2898DeriveBytes(key, sal)
                ' criptografa os dados
                Dim algoritmo = New RijndaelManaged()

                algoritmo.Key = chave.GetBytes(16)
                algoritmo.IV = chave.GetBytes(16)

                Dim fonteBytes() As Byte = New System.Text.UnicodeEncoding().GetBytes(texto_cry)

                Using StreamFonte = New MemoryStream(fonteBytes)

                    Using StreamDestino As New MemoryStream()

                        Using crypto As New CryptoStream(StreamFonte, algoritmo.CreateEncryptor(), CryptoStreamMode.Read)

                            moveBytes(crypto, StreamDestino)

                            Return Convert.ToBase64String(StreamDestino.ToArray())

                        End Using
                    End Using
                End Using
            Else
                Return ""
            End If
        Catch ex As Exception
            ''   MsgBox("Erro no Modulo de criptografia de Informação do Sistema !", MsgBoxStyle.Critical, "Aviso !")
            Return ""
        End Try

    End Function

    Public Shared Function moveBytes(ByVal fonte As Stream, ByVal destino As Stream) As Stream

        Dim bytes(2048) As Byte
        Dim contador = fonte.Read(bytes, 0, bytes.Length - 1)
        While (0 <> contador)
            destino.Write(bytes, 0, contador)
            contador = fonte.Read(bytes, 0, bytes.Length - 1)
        End While

    End Function

    Public Shared Function Descrip_licenca(ByVal conteudo As String) As String


        Try


            Dim gzBuffer As Byte() = Convert.FromBase64String(conteudo)

            If (gzBuffer Is Nothing) Then
                MessageBox.Show("Os dados não estão criptografados!")
                ' Return
            End If

            Dim chave As New Rfc2898DeriveBytes(key, sal)
            Dim algoritmo = New RijndaelManaged()

            algoritmo.Key = chave.GetBytes(16)
            algoritmo.IV = chave.GetBytes(16)

            Using StreamFonte = New MemoryStream(gzBuffer)

                Using StreamDestino As New MemoryStream()

                    Using crypto As New CryptoStream(StreamFonte, algoritmo.CreateDecryptor(), CryptoStreamMode.Read)

                        moveBytes(crypto, StreamDestino)

                        Dim bytesDescriptografados() As Byte = StreamDestino.ToArray()

                        Dim mensagemDescriptografada = New UnicodeEncoding().GetString(bytesDescriptografados)

                        Return mensagemDescriptografada

                    End Using
                End Using
            End Using


        Catch ex As Exception
            MsgBox("Erro no Modulo de descriptografia de Informação do Sistema !", MsgBoxStyle.Critical, "Aviso !")
            Return ""
        End Try

    End Function

    Public Shared Function cryptar_certificado(ByVal conteudo As String) As String
        Dim ByteConverter As ASCIIEncoding = New ASCIIEncoding()
        Dim dataToEncrypt As Byte() = ByteConverter.GetBytes(conteudo)
        Dim encryptedData As Byte()

        Dim RSA2 As RSACryptoServiceProvider = CType(certificado2.PublicKey.Key, RSACryptoServiceProvider)
        encryptedData = RSA2.Encrypt(dataToEncrypt, True)

        Return Convert.ToBase64String(encryptedData)
    End Function

    Public Shared Function descryptar_certificado(ByVal conteudo As String) As String
        Dim ByteConverter As ASCIIEncoding = New ASCIIEncoding()
        Dim base64EncodedBytes = System.Convert.FromBase64String(conteudo)
        Dim decryptedData As Byte()
        Dim RSA As RSACryptoServiceProvider = CType(certificado2.PrivateKey, RSACryptoServiceProvider)
        decryptedData = RSA.Decrypt(base64EncodedBytes, True)

        Return ByteConverter.GetString(decryptedData)
    End Function


    Public Function GetHash(ByVal data As String, ByVal salt As String) As String
        Using sha512 As SHA512 = sha512.Create()
            Dim bytes = Encoding.Unicode.GetBytes(data & salt)
            Dim hash = sha512.ComputeHash(bytes)
            Return Convert.ToBase64String(hash)
        End Using
    End Function

    Private Shared Function CreateSalt(ByVal size As Integer) As String
        Dim rng As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()
        Dim buff As Byte() = New Byte(size - 1) {}
        rng.GetBytes(buff)
        Return Convert.ToBase64String(buff)
    End Function
End Class
