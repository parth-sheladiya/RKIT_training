using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQExample
{
    public class MethodSyntaxClass
    {
        /// <summary>
        /// 
        /// </summary>
        public static void RunMethodSyntaxClass()
        {
            // create method class object 
            Method method = new Method();

            // execute query
            var res = method.list.Where(r => r.Contains("LINQ"));
            var selectRes = method.list.Select(x => x);

            // print select data 

            foreach (var item in selectRes)
            {
               Console.WriteLine(item);
            }

            // print daata
            foreach(var i in res)
            {
                Console.WriteLine(i);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public class Method
        {
            // Data source
            public List<string> list = new List<string>()
            {
                "Hii ",
                " Welcome to linq ",
                " The topic is LINQ."
            };
        }
    }
}
