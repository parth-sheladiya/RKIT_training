using System;

namespace TypesOfClass
{
    /// <summary>
    /// example of static class 
    /// it is allow only static member
    /// it is not inheritad
    /// it is allow only static constructor
    /// it is class can't be created object
    /// </summary>
    public class ExampleStaticClass
    {
        // Static class definition inside ExampleStaticClass
        public static class MathUtilities
        {
            // only allow static method and members
            // Static method 
            public static int Add(int a, int b)
            {
                return a + b;
            }

            // Static method 
            public static int Multiply(int a, int b)
            {
                return a * b;
            }
        }

        //main method
        public static void CallMathUtilities()
        {
            // call nmethod using class name 

            int sum = MathUtilities.Add(5, 10);  
            Console.WriteLine($"Sum: {sum}");  

            int product = MathUtilities.Multiply(5, 10);  
            Console.WriteLine($"Product: {product}");  
        }
    }
}
