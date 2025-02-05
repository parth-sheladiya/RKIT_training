using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQExample
{
    /// <summary>
    /// Conversion operators allow converting one data type to another, 
    /// such as converting arrays to lists, lists to arrays, etc.
    /// </summary>
    public class ConversionOperatorClass
    {
        /// <summary>
        /// This method demonstrates different LINQ conversion methods:
        /// 1. ToList() - Converts an array to a List.
        /// 2. ToArray() - Converts a List to an array.
        /// 3. AsEnumerable() - Converts a collection to IEnumerable.
        /// </summary>
        public static void RunConversionOperatorClass()
        {
            // Creating an object of the Conversion class
            Conversion conversion = new Conversion();

            //  Converting string array to List<string> using ToList()
            List<string> resForLst = conversion.countries.ToList();
            Console.WriteLine("String array convert to List<string>");
            foreach (string s in resForLst)
            {
                Console.WriteLine(s);
            }

            //  Converting List<string> to string[] using ToArray()
            string[] countryArray = conversion.countries.ToArray();
            Console.WriteLine("List<string> convert to string array");
            foreach (string i in countryArray)
            {
                Console.WriteLine(i);
            }

            //  Using AsEnumerable() to convert array to IEnumerable<string>
            Console.WriteLine("AsEnumerable() method result:");
            var resForEnumMethod = conversion.countries.AsEnumerable();
            foreach (string i in resForEnumMethod)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        ///  data source 
        /// </summary>
        public class Conversion
        {
            // Data source: Array of country names
            public string[] countries = { "US", "UK", "India", "Russia", "China", "Australia", "Argentina" };
        }
    }
}
