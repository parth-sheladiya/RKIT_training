using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace LinQExample
{
    public class QuerySyntax
    {
        /// <summary>
        /// method call to program.cs
        /// </summary>
        public static void RunQuerySyntax()
        {
            // create Query class object
            Query query = new Query();

            // step : execute Query
            var res = // first step vinitializatiom
                      from i in query.list
                      // Case-insensitive search
                      // second step condition
                      where i.ToLower().Contains("parth")
                      // third step selection
                      select i;

            // print query result
            foreach (var i in res)
            {
                Console.WriteLine(i);
            }
        }
        /// <summary>
        /// Steps to retrieve data using LINQ
        /// 1 Add System.Linq namespace
        /// 2 Define the data source
        /// 3 Create the LINQ query
        /// 4 Execute the query
        /// </summary>
        public class Query
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
