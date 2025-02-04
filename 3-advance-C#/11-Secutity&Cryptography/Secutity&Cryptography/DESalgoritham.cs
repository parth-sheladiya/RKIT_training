using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Security_Cryptography
{
    public class DESAlgoritham
    {
        /// <summary>
        /// Runs the DES encryption and decryption demonstration.
        /// </summary>
        public static void RunDESAlgorithm()
        {
            string originalText = "Hello, DES Encryption!";
            string key = "12345678"; // DES ke liye 8-byte key honi chahiye

            // Encrypt
            string encryptedText = EncryptDES(originalText, key);
            Console.WriteLine($"Encrypted: {encryptedText}");

            // Decrypt
            string decryptedText = DecryptDES(encryptedText, key);
            Console.WriteLine($"Decrypted: {decryptedText}");
        }

        /// <summary>
        /// Encrypts a given text using DES algorithm.
        /// </summary>
        /// <param name="plainText">Text to be encrypted</param>
        /// <param name="key">8-byte encryption key</param>
        /// <returns>Encrypted text in Base64 format</returns>
        public static string EncryptDES(string plainText, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] iv = keyBytes; // DES IV bhi 8-byte hota hai

            using (DES des = DES.Create()) // DES algorithm ka instance create kiya
            {
                des.Key = keyBytes;
                des.IV = iv;

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    cs.Write(plainBytes, 0, plainBytes.Length);
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray()); // Encrypted bytes ko Base64 me convert kiya
                }
            }
        }

        /// <summary>
        /// Decrypts an encrypted text using DES algorithm.
        /// </summary>
        /// <param name="encryptedText">Base64-encoded encrypted text</param>
        /// <param name="key">8-byte decryption key</param>
        /// <returns>Original decrypted text</returns>
        public static string DecryptDES(string encryptedText, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] iv = keyBytes;

            using (DES des = DES.Create()) // DES algorithm ka instance create kiya
            {
                des.Key = keyBytes;
                des.IV = iv;

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(encryptedText)))
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Read))
                using (StreamReader reader = new StreamReader(cs))
                {
                    return reader.ReadToEnd(); // Decrypted text return karega
                }
            }
        }
    }
}
