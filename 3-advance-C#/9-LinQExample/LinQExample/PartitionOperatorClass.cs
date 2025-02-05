using System;
using System.Collections.Generic;
using System.Linq;

namespace LinQExample
{
    public class PartitionOperatorClass
    {
        /// <summary>
        /// Demonstrates the use of LINQ partition operators like Take and TakeWhile.
        /// </summary>
        public static void RunPartitionOperatorClass()
        {
            Partition part = new Partition();

            // Take first 3 countries from the list
            List<string> resTakeStr = part.countries.Take(3).ToList(); 

            Console.WriteLine("First 3 countries:");
            foreach (var country in resTakeStr)
            {
                Console.WriteLine(country);
            }
            //// doubt 
            // Use TakeWhile to take countries while the condition is true
            List<string> resTakeWhileStr = part.countries.TakeWhile(x => x.StartsWith("C")).ToList(); 

            Console.WriteLine("TakeWhile operator result:");
            foreach (var con in resTakeWhileStr)
            {
                Console.WriteLine(con);
            }

            // skip operator 
            List<string> resSkipStr = part.countries.Skip(3).ToList()  ;
            Console.WriteLine("skip operator result");

            foreach(var country in resSkipStr)
            {
                Console.WriteLine(country);
            }

            // skip while operatoer
            //// doubt
            List<string> resSkipWhileStr = part.countries.SkipWhile(x => x.StartsWith("I")).ToList();
            Console.WriteLine("skip while result ");
            foreach(var country in resSkipWhileStr)
            {
                Console.WriteLine(country);
            }
        }

        /// <summary>
        /// Data class to hold a list of countries.
        /// </summary>
        public class Partition
        {
            // Create data source
            public List<string> countries = new List<string> { "India", "USA", "Russia", "China", "Australia", "Argentina" };
        }
    }

    
}
