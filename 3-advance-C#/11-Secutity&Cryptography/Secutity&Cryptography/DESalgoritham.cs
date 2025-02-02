using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Secutity_Cryptography
{
    public class DESalgoritham
    {
        // main method 
        public static void RunDESalgoritham()
        {
            // message for encrption
            Console.WriteLine("DES Encryption/Decryption Demonstration");
            Console.WriteLine("-----------------------------------------------------------");

            // first of plaintext 
            string plainText = "Hello, DES Encryption!";
            // function call GenerateRandomKey   for key and iv related
            byte[] key = GenerateRandomKey(8);  // DES uses 8-byte keys
            byte[] iv = GenerateRandomKey(8);   // IV is also 8 bytes for DES

            // convert to string 
            Console.WriteLine("Generated Key (Base64): " + Convert.ToBase64String(key));
            Console.WriteLine("Generated IV (Base64): " + Convert.ToBase64String(iv));

            string encryptedText = Encrypt(plainText, key, iv);
            Console.WriteLine("Encrypted Text (Base64): " + encryptedText);

            string decryptedText = Decrypt(encryptedText, key, iv);
            Console.WriteLine("Decrypted Text: " + decryptedText);

            

        }

        public static byte[] GenerateRandomKey(int size)
        {
            // create new byte array
            byte[] key = new byte[size];
            // use built in method of randomnumbergenerator 
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            return key;
        }

        // encrypt class
        public static string Encrypt(string plainText, byte[] key, byte[] iv)
        {
            // cherck condition for plaintext key iv  
            if (string.IsNullOrEmpty(plainText)) throw new ArgumentException("Plaintext cannot be null or empty.");
            if (key == null || key.Length == 0) throw new ArgumentException("Key cannot be null or empty.");
            if (iv == null || iv.Length == 0) throw new ArgumentException("IV cannot be null or empty.");

            using (var des = DES.Create())
            {
                // key assign to DES class var
                des.Key = key;
                des.IV = iv;
                // create machine which use key iv plain text and convert into cipher text
                using (var encryptor = des.CreateEncryptor())
                    // bufffer stream hold result
                using (var ms = new MemoryStream())
                    // perform incryption plaintext to bytes and using flush,method to clear buffer memory
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    // plainbytes,offset,length
                    cs.Write(plainBytes, 0, plainBytes.Length);
                    // flush
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText, byte[] key, byte[] iv)
        {
            if (string.IsNullOrEmpty(cipherText)) throw new ArgumentException("Ciphertext cannot be null or empty.");
            if (key == null || key.Length == 0) throw new ArgumentException("Key cannot be null or empty.");
            if (iv == null || iv.Length == 0) throw new ArgumentException("IV cannot be null or empty.");

            using (var des = DES.Create())
            {
                des.Key = key;
                des.IV = iv;
                using (var decryptor = des.CreateDecryptor())
                using (var ms = new MemoryStream(Convert.FromBase64String(cipherText)))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    byte[] plainBytes = new byte[ms.Length];
                    int bytesRead = cs.Read(plainBytes, 0, plainBytes.Length);
                    return Encoding.UTF8.GetString(plainBytes, 0, bytesRead);
                }
            }
        }

    }
}
