using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQExample
{
    public class SetOperatorClass
    {
        public static void RunSetOperatorClass()
        {
            SetOperator setOperator = new SetOperator();

            // distinct keyword 
            var distinctVal = setOperator.listInt.Distinct();

            Console.WriteLine("distinctVal is ");
            foreach (var item in distinctVal)
            {
                Console.WriteLine(item);
            }

            // union keyword 
            // if one list is int and second is string so compiler will give error
            // it's solve too use cast keyword and 
            var unionRes = setOperator.sListInt.Union(setOperator.listInt);
            Console.WriteLine("union val is ");
            foreach(var item in unionRes)
            {
                Console.WriteLine(item);
            }

            // intersect keyword
            // it is return common element 
            var  intersetRes = setOperator.sListInt.Intersect(setOperator.listInt);
            Console.WriteLine("common number is ");
            foreach(var item in intersetRes)
            {
                Console.WriteLine(item);
            }

            // except keyword

            var exceptRes = setOperator.listInt.Except(setOperator.sListInt);
            Console.WriteLine("except number is ");
            foreach(var item in exceptRes)
            {
                Console.WriteLine(item);
            }
        }
        public class SetOperator
        {
            // create data source 
            public List<int> listInt = new List<int>{1,2,2,1,3,4,2,7,11,23,11,22,34,23,22,90,34,54,90};

            // create second data source bcz this source related to union 
            public List<int> sListInt = new List<int> { 1, 2, 3, 4 };

        }
    }
}
