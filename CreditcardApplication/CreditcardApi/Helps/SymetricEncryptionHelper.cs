using System;
using System.Security.Cryptography;
using System.Text;

namespace CreditcardApi.Helps
{
    public static class SymetricEncryptionHelper
    {
        private const string IV = "2IcbeEiWEy9xrK7yLW1QpQ==";
        private const string secretKey = "os9X34vouSIby1UqaWQ1VwGhVvckVI2mLqGzoJsgDK8=";
        private static Aes aesInstance = Aes.Create();

        public static string Encrypt(string plainText)
        {
            Aes cipher = CreateCipher();
            ICryptoTransform cryptTransform = cipher.CreateEncryptor();
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] cipherTextBytes = cryptTransform.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);
            string cipherText = Convert.ToBase64String(cipherTextBytes);
            return cipherText;
        }

        private static Aes CreateCipher()
        {
            aesInstance.Padding = PaddingMode.ISO10126;
            aesInstance.Mode = CipherMode.CBC;
            aesInstance.Key = Convert.FromBase64String(secretKey);
            aesInstance.IV = Convert.FromBase64String(IV);
            return aesInstance;
        }

        public static string Decrypt(string encryptedText)
        {
            Aes cipher = CreateCipher();
            ICryptoTransform cryptTransform = cipher.CreateDecryptor();
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] plainTextBytes = cryptTransform.TransformFinalBlock(cipherTextBytes, 0, cipherTextBytes.Length);
            string plainText = Encoding.UTF8.GetString(plainTextBytes);
            return plainText;
        }

        private static string GenerateByteArray(int length)
        {
            byte[] random = new byte[length];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(random);
            return Convert.ToBase64String(random);
        }
    }
}
