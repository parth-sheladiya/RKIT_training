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

            // method call for blockOfcode class
            BlockOfCodeExpressionClass.RunBlockOfCodeExpressionClass();

            // call method for ListExampleExpression 
            ListExampleLamdaExpression.RunListExampleLamdaExpression();
        }
    }
}