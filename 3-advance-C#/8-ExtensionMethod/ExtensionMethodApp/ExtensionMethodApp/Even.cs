using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodApp
{
    /// <summary>
    /// IntExtensions class to check number is even or node
    /// </summary>
    public static class IntExtensions
    {
        // check if number is even
        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }

        // Check if a number is Odd
        public static bool IsOdd(this int number)
        {
            return number % 2 != 0;
        }
    }

    
}
