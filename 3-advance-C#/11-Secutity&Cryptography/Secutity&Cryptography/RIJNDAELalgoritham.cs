using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Security_Cryptography
{
    public class RijndaelAlgorithm
    {
        /// <summary>
        /// Runs the Rijndael encryption and decryption demonstration.
        /// </summary>
        public static void RunRijndaelAlgorithm()
        {
            string originalText = "Hello, Rijndael Encryption!";
            string key = "1234567890123456"; // 16-byte (128-bit) key
            string iv = "abcdefghijklmnop"; // 16-byte IV (Initialization Vector)

            // Encrypt
            string encryptedText = EncryptRijndael(originalText, key, iv);
            Console.WriteLine($"Encrypted: {encryptedText}");

            // Decrypt
            string decryptedText = DecryptRijndael(encryptedText, key, iv);
            Console.WriteLine($"Decrypted: {decryptedText}");
        }

        /// <summary>
        /// Encrypts a given text using Rijndael algorithm.
        /// </summary>
        /// <param name="plainText">Text to be encrypted</param>
        /// <param name="key">16-byte encryption key</param>
        /// <param name="iv">16-byte IV</param>
        /// <returns>Encrypted text in Base64 format</returns>
        public static string EncryptRijndael(string plainText, string key, string iv)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);

            using (Rijndael rijndael = Rijndael.Create()) // Rijndael algorithm ka instance create kiya
            {
                rijndael.Key = keyBytes;
                rijndael.IV = ivBytes;

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, rijndael.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    cs.Write(plainBytes, 0, plainBytes.Length);
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray()); // Encrypted bytes ko Base64 me convert kiya
                }
            }
        }

        /// <summary>
        /// Decrypts an encrypted text using Rijndael algorithm.
        /// </summary>
        /// <param name="encryptedText">Base64-encoded encrypted text</param>
        /// <param name="key">16-byte decryption key</param>
        /// <param name="iv">16-byte IV</param>
        /// <returns>Original decrypted text</returns>
        public static string DecryptRijndael(string encryptedText, string key, string iv)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);

            using (Rijndael rijndael = Rijndael.Create()) // Rijndael algorithm ka instance create kiya
            {
                rijndael.Key = keyBytes;
                rijndael.IV = ivBytes;

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(encryptedText)))
                using (CryptoStream cs = new CryptoStream(ms, rijndael.CreateDecryptor(), CryptoStreamMode.Read))
                using (StreamReader reader = new StreamReader(cs))
                {
                    return reader.ReadToEnd(); // Decrypted text return karega
                }
            }
        }
    }
}
