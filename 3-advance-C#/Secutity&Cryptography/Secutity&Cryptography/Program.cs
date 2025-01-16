using Security_Cryptography;
using Secutity_Cryptography;
using System;

namespace SecurityCryptography
{
    public class Program
    {
        public static void Main(string[] data) 
        {
            // call RunDESalgoritham method
            DESalgoritham.RunDESalgoritham();

            // call RunAESAlgorithm method
            AESAlgorithm.RunAESAlgorithm();

            // call RunRijndaelAlgorithm method
            RijndaelAlgorithm.RunRijndaelAlgorithm();
        }
    }
}

