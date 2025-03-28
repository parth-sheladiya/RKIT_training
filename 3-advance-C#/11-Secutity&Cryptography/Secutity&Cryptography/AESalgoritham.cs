﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Security_Cryptography
{
    /// <summary>
    /// Class to perform AES (Advanced Encryption Standard) encryption and decryption.
    /// AES is a symmetric encryption algorithm that uses a single key for both encryption and decryption.
    /// </summary>
    public class AESAlgorithm
    {
        /// <summary>
        /// Runs the AES encryption and decryption process with a sample text and key.
        /// </summary>
        public static void RunAESAlgorithm()
        {
            string text = "hello everyone my name is parth";
            // 16-byte key (128-bit AES key)
            string key = "abcdefghijklmnop";  

            // Encrypt the original text
            string encrypteText = EncryptAES(text, key);
            Console.WriteLine($"Encrypted text is  {encrypteText}");

            // Decrypt the encrypted text
            string decryptedText = DecryptAES(encrypteText, key);
            Console.WriteLine($"Decrypted text is  {decryptedText}");
        }

        /// <summary>
        /// Encrypts a plaintext string using AES encryption.
        /// </summary>
        /// <param name="plainText">The text to be encrypted.</param>
        /// <param name="key">The 16-byte encryption key.</param>
        /// <returns>The encrypted text in Base64 format.</returns>
        static string EncryptAES(string plainText, string key)
        {
            // convert key to byte arr
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            // Initialization Vector 16 bytes of zeros
            byte[] iv = new byte[16]; 

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = iv;

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    // convert tx to byte arr
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    cs.Write(plainBytes, 0, plainBytes.Length);
                    cs.FlushFinalBlock();
                    

                   string res=  Convert.ToBase64String(ms.ToArray()); 
                    return res;
                }
            }
        }

        /// <summary>
        /// Decrypts an AES-encrypted string back to its original plaintext form.
        /// </summary>
        /// <param name="encryptedText">The encrypted text in Base64 format.</param>
        /// <param name="key">The 16-byte decryption key.</param>
        /// <returns>The decrypted plaintext string.</returns>
        static string DecryptAES(string encryptedText, string key)
        {
            // convert key to byte arr
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] iv = new byte[16]; 

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = iv;

                // convert base 64 to byte and store memeory stream
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(encryptedText)))
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))

                // data read using stream reader
                using (StreamReader reader = new StreamReader(cs))
                {
                    return reader.ReadToEnd(); 
                }
            }
        }
    }
}
