using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamdaExpressionExample
{
    public class SimpleExpressionClass
    {
        /// <summary>
        ///  main method of this class and call it to program.cs
        /// </summary>
        public static void  RunSimpleExpressionClass()
        {
            // create object of SimpleExpression class
            SimpleExpression simpleExpression = new SimpleExpression();
            var result = simpleExpression.square(5);
            Console.WriteLine("square is " + result);
        }

        /// <summary>
        /// it's class to learn 
        /// simple lamda expression 
        /// multiple parameters in lamda expression
        /// block of code in lamda expression 
        /// </summary>
        public class SimpleExpression
        { 
            // by defaualt private  so it's make to public
           public Func<int, int> square = x => x * x;
            

        }


    }
}
