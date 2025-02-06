using System;

namespace LamdaExpressionExample
{ 
    class Program
    {
        public static void Main(string[] args)
        {
            // method call for simpleExpression class
            SimpleExpressionClass.RunSimpleExpressionClass();

            // method call for multipleParams class
            MultipleParamsExample.RunMultipleParamsExample();  

            // call method for ListExampleExpression 
            ListExampleLamdaExpression.RunListExampleLamdaExpression();
        }
    }
}