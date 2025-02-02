using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQExample
{
    public class AggregateFunctionClass
    {
        /// <summary>
        /// this is main function to call a aggregate functin class
        /// </summary>
        public static void RunAggregateFunctionClass()
        {
            // create object for agg fun class 

            AggregateFunction aggFun = new AggregateFunction();

            // min function
            int minVal = aggFun.numbers.Min();
            Console.WriteLine("min val is " + minVal);

            // max function
            int maxVal = aggFun.numbers.Max();
            Console.WriteLine("max val is " + maxVal);

            // sum function
            int sumVal = aggFun.numbers.Sum();
            Console.WriteLine("sum is " +  sumVal);

            // count functuioin
            int cntVal = aggFun.numbers.Count();
            Console.WriteLine("count val is " + cntVal);

            // aggerate function 
            int fAggVal = aggFun.numbers.Aggregate((a, b) => a + b);
            int sAggVal = aggFun.numbers.Aggregate((a, b) => a * b);
            int sumOfVals = fAggVal + sAggVal;
            Console.WriteLine("aggerate fun val (faggvals + saggvals) is " + sumOfVals);



        }
        /// <summary>
        /// aggg function min , max , avg , sum , aggerate 
        /// we are use method syntax 
        /// step are initialization , condition , selection 
        /// </summary>
        public class AggregateFunction
        {
            // create data source 
            // execution 
            // first of data source
            // condition 
            // selection 
            public List<int> numbers = new List<int>() { 1, 2, 3, 4 };
        }
    }
}
