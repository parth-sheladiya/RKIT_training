using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamdaExpressionExample
{
    public class MultipleParamsExample
    {
        /// <summary>
        /// main method of this class and call it to program.cs
        /// </summary>
        public static void RunMultipleParamsExample()
        {
            MultipleParams multipleParams = new MultipleParams();
            var result = multipleParams.add(5, 6);
            Console.WriteLine("Addition of x and y  is " + result);
        }
        /// <summary>
        /// it is multipleparams class is in delegates have 2 integers and one integer will return .
        /// => is lamda expression symbol 
        /// </summary>
        public class  MultipleParams
        {
            // by default private  so it's make to public
            public Func<int, int, int> add = (x, y) => x + y;

        }
    }
}
