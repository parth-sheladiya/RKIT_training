using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamdaExpressionExample
{
    public class ListExampleLamdaExpression
    {
        /// <summary>
        /// main method of this class and call it to program.cs
        /// </summary>
        public static void RunListExampleLamdaExpression()
        {
            // create object of ListExample class
            // Create object of ListExample class
            ListExample listExample = new ListExample();
            // Call method to print even numbers
            listExample.PrintEvenNumbers(); 
        }
        /// <summary>
        /// this class provides to print even numbers from list using lambda expression
        /// </summary>
        public class ListExample
        {
            // List of integers
            public List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 ,7,8,9,10,12,23 };

            // Method to find and print even numbers
            public void PrintEvenNumbers()
            {
                // Find all even numbers from list
                List<int> evenNumbers = list.FindAll(x => (x % 2) == 0);

                
                // even numbers logic
                foreach (var num in evenNumbers)
                {
                    Console.Write(" ", num);
                }
               
            }
        }
    }
}