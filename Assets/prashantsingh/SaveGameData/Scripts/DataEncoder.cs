using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
namespace Prashant.SaveGameData
{
    //https://tekeye.uk/visual_studio/encrypt-decrypt-c-sharp-string
    public static class DataEncoder
    {
        private const string initVector = "c2VuZG51ZGVzNjk=";
        private const int Keysize = 256;
        private const int DerivationIterations = 1000;
        public static string EncryptThis(string m_data, string password)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(m_data);
            PasswordDeriveBytes passPhrase = new PasswordDeriveBytes(password, null);
            byte[] keyBytes = passPhrase.GetBytes(Keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Decrypt(string encryptedText, string password)
        {

            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            PasswordDeriveBytes passPhrase = new PasswordDeriveBytes(password, null);
            byte[] keyBytes = passPhrase.GetBytes(Keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32];
            var rngCsp = new RNGCryptoServiceProvider();
            rngCsp.GetBytes(randomBytes);
            return randomBytes;
        }
    }
}