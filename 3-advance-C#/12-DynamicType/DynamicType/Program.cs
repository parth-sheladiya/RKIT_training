using System;
using System.Collections.Generic;

namespace DynamicType
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Example 1: Dynamic with integer
            dynamic data = 100;
            Console.WriteLine($"Type: {data.GetType()}, Value: {data}");  // Output: Type: System.Int32, Value: 100

            // Example 2: Dynamic with string
            data = "Hello Dynamic!";
            Console.WriteLine($"Type: {data.GetType()}, Value: {data}");  // Output: Type: System.String, Value: Hello Dynamic!

            // Example 3: Dynamic with List<string>
            data = new List<string> { "A", "B", "C" };
            Console.WriteLine($"Type: {data.GetType()}, Value: {string.Join(", ", data)}"); // Output: Type: System.Collections.Generic.List`1[System.String], Value: A, B, C

            // Example 4: Dynamic with double
            data = 3.14159;
            Console.WriteLine($"Type: {data.GetType()}, Value: {data}");  // Output: Type: System.Double, Value: 3.14159

            // Example 5: Dynamic with DateTime
            data = DateTime.Now;
            Console.WriteLine($"Type: {data.GetType()}, Value: {data}");  // Output: Type: System.DateTime, Value: current date and time

            // Example 6: Dynamic with Dictionary
            data = new Dictionary<string, int> { { "Key1", 1 }, { "Key2", 2 } };
            Console.WriteLine($"Type: {data.GetType()}, Value: ");
            foreach (var kvp in data)
            {
                Console.WriteLine($"  {kvp.Key}: {kvp.Value}"); // Output: Key1: 1, Key2: 2
            }

            // Example 7: Dynamic with boolean
            data = true;
            Console.WriteLine($"Type: {data.GetType()}, Value: {data}");  // Output: Type: System.Boolean, Value: True

            // Example 8: Dynamic with Anonymous Type
            data = new { Name = "John", Age = 30 };
            Console.WriteLine($"Type: {data.GetType()}, Name: {data.Name}, Age: {data.Age}");  // Output: Type: AnonymousType, Name: John, Age: 30

            // Example 9: Dynamic with method invocation
            data = "Dynamic allows method calls!";
            Console.WriteLine($"UpperCase: {data.ToUpper()}"); // Output: UpperCase: DYNAMIC ALLOWS METHOD CALLS!

            // Example 10: Dynamic with mixed types in List
            data = new List<dynamic> { 1, "Two", 3.0, DateTime.Now };
            Console.WriteLine($"Type: {data.GetType()}, Values:");
            foreach (var item in data)
            {
                Console.WriteLine($"  Type: {item.GetType()}, Value: {item}");
            }

            // Example 11: Dynamic with null
            data = null;
            Console.WriteLine($"Value: {data}"); // Output: Value:

            // Example 12: Dynamic with Function Return
            data = GetDynamicValue();
            Console.WriteLine($"Type: {data.GetType()}, Value: {data}"); // Output depends on the returned type
        }

        // Method returning a dynamic value
        public static dynamic GetDynamicValue()
        {
            return new List<int> { 1, 2, 3 }; // Returning a dynamic List<int>
        }
    }
}
