using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Security_Cryptography
{
    public class AESAlgorithm
    {
        // Main method that runs the AES encryption and decryption process
        public static void RunAESAlgorithm()
        {
            // Message for encryption
            Console.WriteLine("AES Encryption/Decryption Demonstration");
           

            // Define the plaintext message to be encrypted
            string plainText = "Hello, AES Encryption!";

            // Generate random key and IV (Initialization Vector) for AES encryption
            byte[] key = GenerateRandomKey(16);  // AES typically uses 16, 24, or 32 byte keys (128, 192, or 256 bits)
            byte[] iv = GenerateRandomKey(16);   // IV is also 16 bytes for AES

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

        // Encrypt method: Encrypts the given plaintext using AES with the provided key and IV
        public static string Encrypt(string plainText, byte[] key, byte[] iv)
        {
            // Check for invalid input values
            if (string.IsNullOrEmpty(plainText)) throw new ArgumentException("Plaintext cannot be null or empty.");
            if (key == null || key.Length == 0) throw new ArgumentException("Key cannot be null or empty.");
            if (iv == null || iv.Length == 0) throw new ArgumentException("IV cannot be null or empty.");

            // Create a new AES instance and configure it with the provided key and IV
            using (var aes = Aes.Create())
            {
                aes.Key = key; // Set the key for AES encryption
                aes.IV = iv;   // Set the IV for AES encryption

                // Create an encryptor to perform encryption
                using (var encryptor = aes.CreateEncryptor())
                using (var ms = new MemoryStream()) // Memory stream to hold the encrypted data
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write)) // CryptoStream for encryption
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText); // Convert plaintext to bytes
                    cs.Write(plainBytes, 0, plainBytes.Length); // Write plaintext bytes to CryptoStream
                    cs.FlushFinalBlock(); // Ensure all data is written to the memory stream
                    return Convert.ToBase64String(ms.ToArray()); // Convert encrypted bytes to Base64 and return
                }
            }
        }

        // Decrypt method: Decrypts the given ciphertext using AES with the provided key and IV
        public static string Decrypt(string cipherText, byte[] key, byte[] iv)
        {
            // Check for invalid input values
            if (string.IsNullOrEmpty(cipherText)) throw new ArgumentException("Ciphertext cannot be null or empty.");
            if (key == null || key.Length == 0) throw new ArgumentException("Key cannot be null or empty.");
            if (iv == null || iv.Length == 0) throw new ArgumentException("IV cannot be null or empty.");

            // Create a new AES instance and configure it with the provided key and IV
            using (var aes = Aes.Create())
            {
                aes.Key = key; // Set the key for AES decryption
                aes.IV = iv;   // Set the IV for AES decryption

                // Create a decryptor to perform decryption
                using (var decryptor = aes.CreateDecryptor())
                using (var ms = new MemoryStream(Convert.FromBase64String(cipherText))) // Convert Base64 to byte array
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read)) // CryptoStream for decryption
                {
                    byte[] plainBytes = new byte[ms.Length]; // Create a byte array to hold the decrypted data
                    int bytesRead = cs.Read(plainBytes, 0, plainBytes.Length); // Read decrypted data into byte array
                    return Encoding.UTF8.GetString(plainBytes, 0, bytesRead); // Convert decrypted bytes to string and return
                }
            }
        }

      
    }
}
