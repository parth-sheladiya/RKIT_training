using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQExample
{
    /// <summary>
    /// This class demonstrates the use of LINQ Set Operators.
    /// Set operators allow us to perform operations like union, intersection, distinct, and except on sequences.
    /// </summary>
    public class SetOperatorClass
    {
        /// <summary>
        /// This describes the use of various LINQ Set Operators
        /// </summary>
        public static void RunSetOperatorClass()
        {
            // Create an instance of SetOperator to access data sources
            SetOperator setOperator = new SetOperator();

            //  Distinct keyword: Returns only unique elements in the list
            var distinctVal = setOperator.listInt.Distinct().ToList();
            Console.WriteLine("Distinct values are: ");
            foreach (var item in distinctVal)
            {
                Console.WriteLine(item);
            }

            //Union keyword Combines two sequences, excluding duplicates
            // If lists have different types, the compiler will give an error. Cast is used to resolve type issues
            var unionRes = setOperator.sListInt.Union(setOperator.listInt);
            Console.WriteLine("Union of lists: ");
            foreach (var item in unionRes)
            {
                Console.WriteLine(item);
            }

            //  Intersect keyword: Returns common elements between two sequences
            var intersectRes = setOperator.sListInt.Intersect(setOperator.listInt);
            Console.WriteLine("Common values between lists: ");
            foreach (var item in intersectRes)
            {
                Console.WriteLine(item);
            }

            // Except keyword Returns elements from the first list that are not in the second
            var exceptRes = setOperator.listInt.Except(setOperator.sListInt);
            Console.WriteLine("Elements in the first list but not in the second: ");
            foreach (var item in exceptRes)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// This class contains the data sources (integer lists) used for Set Operator demonstrations.
        /// </summary>
        public class SetOperator
        {
            // Data source for listInt it is for duplicate values
            public List<int> listInt = new List<int> { 1, 2, 2, 1, 3, 4, 2, 7, 11, 23, 11, 22, 34, 23, 22, 90, 34, 54, 90 };

            // Second data source sListInt used for union, intersection, and except operations
            public List<int> sListInt = new List<int> { 1, 2, 3, 4 };
        }
    }
}
