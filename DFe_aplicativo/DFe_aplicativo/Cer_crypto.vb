Imports System.Security.Cryptography
Imports System.IO
Imports System.Security.Cryptography.X509Certificates

Public Class Cer_crypto
   
        '  EncryptFile(originalFile, CType(certificado.PublicKey.Key, RSACryptoServiceProvider))
        '  DecryptFile(encryptedFile, CType(certificado.PrivateKey, RSACryptoServiceProvider))
    Private Shared Function GetCertificateFromStore(ByVal certName As String) As X509Certificate2
        Dim store As X509Store = New X509Store(StoreLocation.CurrentUser)

        Try
            store.Open(OpenFlags.[ReadOnly])
            Dim certCollection As X509Certificate2Collection = store.Certificates
            Dim currentCerts As X509Certificate2Collection = certCollection.Find(X509FindType.FindByTimeValid, DateTime.Now, False)
            Dim signingCert As X509Certificate2Collection = currentCerts.Find(X509FindType.FindBySubjectDistinguishedName, certName, False)
            If signingCert.Count = 0 Then Return Nothing
            Return signingCert(0)
        Finally
            store.Close()
        End Try
    End Function


    Public Shared Function EncryptFile(ByVal origem_File As String, ByVal rsaPublicKey As RSACryptoServiceProvider)
        Dim pasta As String = Path.GetDirectoryName(origem_File)
        Dim ext_arq As String = Path.GetExtension(origem_File)
        Dim nome_arq As String = Path.GetFileName(origem_File)
        Dim rjndl As RijndaelManaged = New RijndaelManaged()
        rjndl.KeySize = 256
        rjndl.BlockSize = 256
        rjndl.Mode = CipherMode.CBC
        Dim transform As ICryptoTransform = rjndl.CreateEncryptor()
        Dim keyFormatter As RSAPKCS1KeyExchangeFormatter = New RSAPKCS1KeyExchangeFormatter(rsaPublicKey)
        Dim keyEncrypted As Byte() = keyFormatter.CreateKeyExchange(rjndl.Key, rjndl.[GetType]())
        Dim LenK As Byte() = New Byte(3) {}
        Dim LenIV As Byte() = New Byte(3) {}
        Dim lKey As Integer = keyEncrypted.Length
        LenK = BitConverter.GetBytes(lKey)
        Dim lIV As Integer = rjndl.IV.Length
        LenIV = BitConverter.GetBytes(lIV)
        Dim outFile As String = pasta & "\" & nome_arq.Substring(0, nome_arq.Length - 4) & ".cryp" & ext_arq.Substring(1, 3)

        Using outFs As FileStream = New FileStream(outFile, FileMode.Create)
            outFs.Write(LenK, 0, 4)
            outFs.Write(LenIV, 0, 4)
            outFs.Write(keyEncrypted, 0, lKey)
            outFs.Write(rjndl.IV, 0, lIV)

            Using outStreamEncrypted As CryptoStream = New CryptoStream(outFs, transform, CryptoStreamMode.Write)
                Dim count As Integer = 0
                Dim offset As Integer = 0
                Dim blockSizeBytes As Integer = rjndl.BlockSize / 8
                Dim data As Byte() = New Byte(blockSizeBytes - 1) {}
                Dim bytesRead As Integer = 0

                Using inFs As FileStream = New FileStream(origem_File, FileMode.Open)

                    Do
                        count = inFs.Read(data, 0, blockSizeBytes)
                        offset += count
                        outStreamEncrypted.Write(data, 0, count)
                        bytesRead += blockSizeBytes
                    Loop While count > 0

                    inFs.Close()
                End Using

                outStreamEncrypted.FlushFinalBlock()
                outStreamEncrypted.Close()
            End Using

            outFs.Close()
        End Using
    End Function

    Public Shared Function DecryptFile(ByVal origem_File As String, ByVal rsaPrivateKey As RSACryptoServiceProvider)
        Dim pasta As String = Path.GetDirectoryName(origem_File)
        Dim ext_arq As String = Path.GetExtension(origem_File)
        ext_arq = ext_arq.Substring(ext_arq.Length - 3, 3)
        Dim nome_arq As String = Path.GetFileName(origem_File)
        Dim rjndl As RijndaelManaged = New RijndaelManaged()
        rjndl.KeySize = 256
        rjndl.BlockSize = 256
        rjndl.Mode = CipherMode.CBC
        Dim LenK2 As Byte() = New Byte(3) {}
        Dim LenIV2 As Byte() = New Byte(3) {}
        Dim outFile As String = pasta & "\" & nome_arq.Substring(0, nome_arq.Length - 8) & "." & ext_arq

        Using inFs As FileStream = New FileStream(origem_File, FileMode.Open)
            inFs.Seek(0, SeekOrigin.Begin)
            inFs.Seek(0, SeekOrigin.Begin)
            inFs.Read(LenK2, 0, 3)
            inFs.Seek(4, SeekOrigin.Begin)
            inFs.Read(LenIV2, 0, 3)
            Dim lenK As Integer = BitConverter.ToInt32(LenK2, 0)
            Dim lenIV As Integer = BitConverter.ToInt32(LenIV2, 0)
            Dim startC As Integer = lenK + lenIV + 8
            Dim lenC As Integer = CInt(inFs.Length) - startC
            Dim KeyEncrypted As Byte() = New Byte(lenK - 1) {}
            Dim IV As Byte() = New Byte(lenIV - 1) {}
            inFs.Seek(8, SeekOrigin.Begin)
            inFs.Read(KeyEncrypted, 0, lenK)
            inFs.Seek(8 + lenK, SeekOrigin.Begin)
            inFs.Read(IV, 0, lenIV)
            Directory.CreateDirectory(pasta)
            Dim KeyDecrypted As Byte() = rsaPrivateKey.Decrypt(KeyEncrypted, False)
            Dim transform As ICryptoTransform = rjndl.CreateDecryptor(KeyDecrypted, IV)

            Using outFs As FileStream = New FileStream(outFile, FileMode.Create)
                Dim count As Integer = 0
                Dim offset As Integer = 0
                Dim blockSizeBytes As Integer = rjndl.BlockSize / 8
                Dim data As Byte() = New Byte(blockSizeBytes - 1) {}
                inFs.Seek(startC, SeekOrigin.Begin)

                Using outStreamDecrypted As CryptoStream = New CryptoStream(outFs, transform, CryptoStreamMode.Write)

                    Do
                        count = inFs.Read(data, 0, blockSizeBytes)
                        offset += count
                        outStreamDecrypted.Write(data, 0, count)
                    Loop While count > 0

                    outStreamDecrypted.FlushFinalBlock()
                    outStreamDecrypted.Close()
                End Using

                outFs.Close()
            End Using

            inFs.Close()
        End Using
    End Function
End Class
