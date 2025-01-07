using System;
using System.Globalization;


namespace Basic_C_Sharp
{
    public class OperatorsDemo
    {
        public static void RunOperatorsDemo()
        {
            int firstNumber = 10;
            int secondNumber = 20;

            bool x=true;
            bool y = false;

            #region arithmetic operator


            Console.WriteLine("firstNumber +  secondNumber is :" + (firstNumber + secondNumber));
            Console.WriteLine("firstNumber -  secondNumber is :" + (firstNumber - secondNumber));
            Console.WriteLine("firstNumber *  secondNumber is :" + (firstNumber * secondNumber));
            Console.WriteLine("firstNumber /  secondNumber is :" + (firstNumber / secondNumber));
            Console.WriteLine("firstNumber %  secondNumber is :" + (firstNumber % secondNumber));

            #endregion

            #region relational operator
            Console.WriteLine("firstNumber == secondNumber : " + (firstNumber == secondNumber));
            Console.WriteLine("firstNumber != secondNumber : " + (firstNumber != secondNumber));
            Console.WriteLine("firstNumber >= secondNumber : " + (firstNumber >= secondNumber));
            Console.WriteLine("firstNumber <= secondNumber : " + (firstNumber <= secondNumber));
            Console.WriteLine("firstNumber > secondNumber : " + (firstNumber > secondNumber));
            Console.WriteLine("firstNumber < secondNumber : " + (firstNumber < secondNumber));
            

            #endregion

            #region logical operator
            Console.WriteLine("x && y " + (x && y));
            Console.WriteLine("x || y" + (x || y));
            Console.WriteLine("!x" + (!x));
            #endregion

            #region assignment operator
            Console.WriteLine("firstNumber +=  secondNumber is :" + (firstNumber += secondNumber));
            Console.WriteLine("firstNumber -=  secondNumber is :" + (firstNumber -= secondNumber));
            Console.WriteLine("firstNumber *=  secondNumber is :" + (firstNumber *= secondNumber));
            Console.WriteLine("firstNumber /=  secondNumber is :" + (firstNumber /= secondNumber));

            #endregion

            #region incre-decre operator
            Console.WriteLine("firstNumber++:" + (firstNumber++));
            Console.WriteLine("++firstNumber:" + (++firstNumber));
            #endregion

            #region bitwise operator
            Console.WriteLine("firstnumber & secondnumber" + (firstNumber & secondNumber));
            Console.WriteLine("~firstNumber :" + (~firstNumber));
            Console.WriteLine("firstNumber<<1:" + (firstNumber<<1));
            Console.WriteLine("firstNumber>>:" + (firstNumber>>1));
            #endregion

            #region ternory operator
            String result = (firstNumber > secondNumber) ? "a is greater than b" : "a is not grater than b";
            Console.WriteLine(result);
            #endregion

        }
    }
}
