using System;
using Mathlibrary; // Import the library namespace

class Program
{
    static void Main()
    {
        // Library ka object banake method call karo
        MathClass math = new MathClass();
        int addResult = math.Add(5, 10);
        int multiplyResult = math.Multiply(5, 10);

        Console.WriteLine($"Addition Result: {addResult}");
        Console.WriteLine($"Multiply Result: {multiplyResult}");
    }
}
