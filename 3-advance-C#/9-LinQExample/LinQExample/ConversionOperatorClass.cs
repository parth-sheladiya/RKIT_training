using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQExample
{
    public class ConversionOperatorClass
    {
        public static void RunConversionOperatorClass()
        {
            Conversion conversion = new Conversion();
           
            // to list method 
            List<string> resForLst = conversion.countries.ToList();


            Console.WriteLine("string convert to tolist");

            foreach(string s in resForLst)
            {
                Console.WriteLine(s);
            }

            // to array method 
            string[] countryArray = conversion.countries.ToArray();

            Console.WriteLine("string convert to str array");

            foreach(string i in countryArray)
            {
                Console.WriteLine(i);
            }

            // as enumerable method 

            Console.WriteLine("as enumerable method is ");

            var resForEnumMethod = conversion.countries.AsEnumerable();

            foreach(string i in resForEnumMethod)
            {
                Console.WriteLine(i);
            }

        }
        public class Conversion
        {
            // data source 
           public string[] countries = { "US", "UK", "India", "Russia", "China", "Australia", "Argentina" };


        }
    }
}
