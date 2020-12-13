using System;
using System.Security.Cryptography;
using System.Text;

namespace Creditcard.Api.Helps
{
    public static class SymetricEncryptionHelper
    {
        private static string IV;
        private static readonly byte[] secretKey = GenerateByteArray(32);

        public static string Encrypt(string plainText)
        {
            Aes cipher = CreateCipher();
            IV = Convert.ToBase64String(cipher.IV);
            ICryptoTransform cryptTransform = cipher.CreateEncryptor();
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] cipherTextBytes = cryptTransform.TransformFinalBlock(plainTextBytes, 0, plainText.Length);
            string cipherText = Convert.ToBase64String(cipherTextBytes);
            return cipherText;
        }

        private static Aes CreateCipher()
        {
            Aes cipher = Aes.Create();
            cipher.Padding = PaddingMode.ISO10126;
            cipher.Key = secretKey;
            return cipher;
        }

        public static string Decrypt(string encryptedText)
        {
            Aes cipher = CreateCipher();
            cipher.IV = Convert.FromBase64String(IV);
            ICryptoTransform cryptTransform = cipher.CreateDecryptor();
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] plainTextBytes = cryptTransform.TransformFinalBlock(cipherTextBytes, 0, cipherTextBytes.Length);
            string plainText = Encoding.UTF8.GetString(plainTextBytes);
            return plainText;
        }

        private static byte[] GenerateByteArray(int length)
        {
            byte[] random = new byte[length];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(random);
            return random;
        }
    }
}
