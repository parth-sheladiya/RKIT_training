using System;
using System.Collections.Generic;
using System.Linq;

namespace LinQExample
{
    public class MethodSyntaxClass
    {
        /// <summary>
        /// It is for method syntax
        /// </summary>
        public static void RunMethodSyntaxClass()
        {
            // Data source directly yahan declare kar diya
            List<string> list = new List<string>()
            {
                "Hii ",
                " Welcome to linq ",
                " The topic is LINQ."
            };

            // Execute query
            var res = list.Where(r => r.Contains("LINQ"));
            var selectRes = list.Select(x => x);

            // Print select data 
            foreach (var item in selectRes)
            {
                Console.WriteLine(item);
            }

            // Print data
            foreach (var i in res)
            {
                Console.WriteLine(i);
            }
        }
    }

   
}
