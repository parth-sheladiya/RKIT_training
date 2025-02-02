using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQExample
{
    public class ConcatClass
    {
        public static void RunConcatClass()
        {
            // create object
            Concat concatObj = new Concat();

            // concat
            // it is return a duplicate data if store it otherwise normal data 
            // if concat give duplicate data then use distinct keyword for one solutuion
            // second solution we use group by keyword
            // third solution we learn for data structure (hash set)
            var res = concatObj.listInt.Concat(concatObj.sListInt);
            foreach( var item in res )
            {
                Console.WriteLine(item);
            }
        }
        public class Concat
        {
            // first create data source 
            public List<int> listInt = new List<int> { 1, 2, 3, 4, 4, 5 };
            public List<int> sListInt = new List<int> { 3, 4, 5, 6, 7 };
        }
    }
}
