using System;

namespace DebugBasic
{
    // Function to add two numbers
    class Program
    {
        static int AddNumbers(int a, int b)
        {
            int result = a + b;
            return result;
        }

        // Function to subtract two numbers
        static int SubtractNumbers(int a, int b)
        {
            int result = a - b;
            return result;
        }

        // Function to multiply two numbers
        static int MultiplyNumbers(int a, int b)
        {
            int result = a * b;
            return result;
        }

        // Function to divide two numbers
        static double DivideNumbers(int a, int b)
        {   // error handle condition
            if (b == 0)
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
                return 0;
            }
            double result = (double)a / b;
            return result;
        }

        static void Main()
        {
            // Declaring and initializing variables
            int num1 = 10;
            int num2 = 5;

            // Additional variables for more operations
            int C = 20;
            int d = 30;
            int e = 40;
            int f = 70;

            // Debugging issue here for addition
            int sumResult = AddNumbers(num1, num2);
            Console.WriteLine("Sum of num1 and num2: " + sumResult); 

            // Debugging issue here for subtraction
            int diffResult = SubtractNumbers(num1, num2);
            Console.WriteLine("Difference between num1 and num2: " + diffResult); 

            // Debugging issue here for multiplication
            int multiplyResult = MultiplyNumbers(C, d);
            Console.WriteLine("Multiplication of C and d: " + multiplyResult); 

            // Debugging issue here for division
            double divideResult = DivideNumbers(e, f);
            Console.WriteLine("Division of e by f: " + divideResult); 

            // Intentional bug: Missing closing parenthesis in this line
            Console.WriteLine("Check for bug");
        }
    }
}
