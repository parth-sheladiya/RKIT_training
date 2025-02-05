using System;


namespace ExtensionMethodApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 10;
            int num2 = 7;

            // Calling the extension methods
            Console.WriteLine($"{num1} is Even: {num1.IsEven()}"); 
            Console.WriteLine($"{num1} is Odd: {num1.IsOdd()}");    
            Console.WriteLine($"{num2} is Even: {num2.IsEven()}");  
            Console.WriteLine($"{num2} is Odd: {num2.IsOdd()}");   
        }
    }
}
