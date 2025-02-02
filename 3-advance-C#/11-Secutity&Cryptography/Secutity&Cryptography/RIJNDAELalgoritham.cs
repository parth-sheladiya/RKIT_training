using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Security_Cryptography
{
    public class RijndaelAlgorithm
    {
        // Main method that runs the Rijndael encryption and decryption process
        public static void RunRijndaelAlgorithm()
        {
            Console.WriteLine("Rijndael Encryption/Decryption Demonstration");

            // Define the plaintext message to be encrypted
            string plainText = "Hello, Rijndael Encryption!";

            // Generate random key and IV (Initialization Vector) for Rijndael encryption
            byte[] key = GenerateRandomKey(32); // Rijndael supports 128, 192, or 256-bit keys (16, 24, or 32 bytes)
            byte[] iv = GenerateRandomKey(16);  // IV size is 16 bytes

            // Display the generated key and IV in Base64 format
            Console.WriteLine("Generated Key (Base64): " + Convert.ToBase64String(key));
            Console.WriteLine("Generated IV (Base64): " + Convert.ToBase64String(iv));

            // Encrypt the plaintext and display the encrypted text in Base64 format
            string encryptedText = Encrypt(plainText, key, iv);
            Console.WriteLine("Encrypted Text (Base64): " + encryptedText);

            // Decrypt the encrypted text back to the original plaintext
            string decryptedText = Decrypt(encryptedText, key, iv);
            Console.WriteLine("Decrypted Text: " + decryptedText);
        }

        // Method to generate a random key of a specified size (in bytes)
        public static byte[] GenerateRandomKey(int size)
        {
            byte[] key = new byte[size]; // Create a byte array of the specified size
            using (var rng = RandomNumberGenerator.Create()) // Create a random number generator
            {
                rng.GetBytes(key); // Fill the byte array with random bytes
            }
            return key; // Return the generated key
        }

        // Encrypt method: Encrypts the given plaintext using Rijndael with the provided key and IV
        public static string Encrypt(string plainText, byte[] key, byte[] iv)
        {
            if (string.IsNullOrEmpty(plainText)) throw new ArgumentException("Plaintext cannot be null or empty.");
            if (key == null || key.Length == 0) throw new ArgumentException("Key cannot be null or empty.");
            if (iv == null || iv.Length == 0) throw new ArgumentException("IV cannot be null or empty.");

            using (var rijndael = new RijndaelManaged())
            {
                rijndael.Key = key; // Set the key for Rijndael encryption
                rijndael.IV = iv;   // Set the IV for Rijndael encryption

                using (var encryptor = rijndael.CreateEncryptor())
                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText); // Convert plaintext to bytes
                    cs.Write(plainBytes, 0, plainBytes.Length); // Write plaintext bytes to CryptoStream
                    cs.FlushFinalBlock(); // Ensure all data is written to the memory stream
                    return Convert.ToBase64String(ms.ToArray()); // Convert encrypted bytes to Base64 and return
                }
            }
        }

        // Decrypt method: Decrypts the given ciphertext using Rijndael with the provided key and IV
        public static string Decrypt(string cipherText, byte[] key, byte[] iv)
        {
            if (string.IsNullOrEmpty(cipherText)) throw new ArgumentException("Ciphertext cannot be null or empty.");
            if (key == null || key.Length == 0) throw new ArgumentException("Key cannot be null or empty.");
            if (iv == null || iv.Length == 0) throw new ArgumentException("IV cannot be null or empty.");

            using (var rijndael = new RijndaelManaged())
            {
                rijndael.Key = key; // Set the key for Rijndael decryption
                rijndael.IV = iv;   // Set the IV for Rijndael decryption

                using (var decryptor = rijndael.CreateDecryptor())
                using (var ms = new MemoryStream(Convert.FromBase64String(cipherText)))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    byte[] plainBytes = new byte[ms.Length]; // Create a byte array to hold the decrypted data
                    int bytesRead = cs.Read(plainBytes, 0, plainBytes.Length); // Read decrypted data into byte array
                    return Encoding.UTF8.GetString(plainBytes, 0, bytesRead); // Convert decrypted bytes to string and return
                }
            }
        }
    }
}
