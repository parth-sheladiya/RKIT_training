using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamdaExpressionExample
{
    public class BlockOfCodeExpressionClass
    {
        /// <summary>
        /// this is main method of this class 
        /// </summary>
        public static void RunBlockOfCodeExpressionClass()
        {
            // create object and final result of factorial
            BlockOfCodeExpression blockOfCodeExpression = new BlockOfCodeExpression();
            int n = 5;
            var result = blockOfCodeExpression.fact(n);
            Console.WriteLine($"Factorial of {n}  is " + result);
        }

        /// <summary>
        /// BlockofcodeExp.. is means it is use block of code in lamda expression they have one integer and return integer
        /// => is lamda expression
        /// </summary>
        public class BlockOfCodeExpression
        {
            // by defaualt private  so it's make to public
            public Func<int, int> fact = n =>
                {
                    int res = 1;
                    // factorial logic
                    // it is start to 1 to n 
                    // because it's start to 0 so result is always 0
                    // then condition check one by one and return result and call it to RunBlockOfCodeExpressionClass
                    for (int i = 1; i <= n; i++)
                    {
                        res = res * i;
                    }
                    // return final result
                    return res;
                };
        }
    }
}
