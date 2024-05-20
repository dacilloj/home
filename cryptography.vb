Imports System.Security.Cryptography

Namespace net.wibit
    Public Class RSAPKCS1SHA256SignatureDescription
        Inherits SignatureDescription
        Public Shared Sub Register()
            CryptoConfig.AddAlgorithm(
                GetType(RSAPKCS1SHA256SignatureDescription),
                "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256")
        End Sub

        Public Sub New()
            KeyAlgorithm = "System.Security.Cryptography.RSACryptoServiceProvider"
            DigestAlgorithm = "System.Security.Cryptography.SHA256Managed"
            FormatterAlgorithm = "System.Security.Cryptography.RSAPKCS1SignatureFormatter"
            DeformatterAlgorithm = "System.Security.Cryptography.RSAPKCS1SignatureDeformatter"
        End Sub

        Public Overrides Function CreateDeformatter(key As AsymmetricAlgorithm) As AsymmetricSignatureDeformatter
            Dim asymmetricSignatureDeformatter = CType(CryptoConfig.CreateFromName(DeformatterAlgorithm), AsymmetricSignatureDeformatter)
            asymmetricSignatureDeformatter.SetKey(key)
            asymmetricSignatureDeformatter.SetHashAlgorithm("SHA256")
            Return asymmetricSignatureDeformatter
        End Function

        Public Overrides Function CreateFormatter(key As AsymmetricAlgorithm) As AsymmetricSignatureFormatter
            Dim asymmetricSignatureFormatter = CType(CryptoConfig.CreateFromName(FormatterAlgorithm), AsymmetricSignatureFormatter)
            asymmetricSignatureFormatter.SetKey(key)
            asymmetricSignatureFormatter.SetHashAlgorithm("SHA256")
            Return asymmetricSignatureFormatter
        End Function
    End Class
End Namespace
