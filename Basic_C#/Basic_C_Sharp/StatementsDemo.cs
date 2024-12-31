using System;

namespace Basic_C_Sharp
{
    public class StatementsDemo
    {
        public static void RunStatementsDemo()
        {
            #region only if statement
            int firstNumber = 8;
            if (firstNumber < 10)
            {
                Console.WriteLine("Your class is primary school");
            }
            #endregion

            #region only if else statement
            int secondNumber = 12;
            if (secondNumber < 10)
            {
                Console.WriteLine("Your number is below 10");
            }
            else
            {
                Console.WriteLine("Your number is 10 or more");
            }
            #endregion

            #region if else-if else statement
            int thirdNumber = 16;
            if (thirdNumber < 14)
            {
                Console.WriteLine("You cannot drive yet");
            }
            else if (thirdNumber >= 14 && thirdNumber < 18)
            {
                Console.WriteLine("You are eligible for a learning license");
            }
            else
            {
                Console.WriteLine("You are eligible for a driving license");
            }
            #endregion

            #region switch statement
            int fourthNumber = 20;
            switch (fourthNumber)
            {
                case 14:
                    Console.WriteLine("You entered Fourteen.");
                    break;
                case 15:
                    Console.WriteLine("You entered Fifteen.");
                    break;
                case 16:
                    Console.WriteLine("You entered Sixteen.");
                    break;
                default:
                    Console.WriteLine("Invalid number. Please enter 14, 15, or 16.");
                    break;
            }
            #endregion

            #region loops
            #region while loops
            int i = 0;
            while (i < 10)
            {
                Console.WriteLine("i :" + i);
                i++;
            }
            #endregion

            #region do while loop
            int j = 0;
            do
            {
                Console.WriteLine("j " + j);
                j++; // Increment added to prevent infinite loop
            } while (j < 5);
            #endregion

            #region for loop
            for (int k = 0; k < 5; k++)
            {
                Console.WriteLine("k " + k);
            }
            #endregion

            #region foreach
            int[] arr = { 10, 20, 30, 40, 50 };
            foreach (int ele in arr)
            {
                Console.WriteLine("ele is :" + ele);
            }
            #endregion

            #region break statement
            int x = 0;
            while (x < 5)
            {
                if (x == 2)
                {
                    break;
                }
                Console.WriteLine("x is :" + x);
                x++; // Increment added to prevent infinite loop
            }
            #endregion

            #region continue 
            int y = 0;
            while (y < 5)
            {
                if (y == 2)
                {
                    y++; // Increment added to prevent infinite loop
                    continue;
                }
                Console.WriteLine("y is :" + y);
                y++;
            }
            #endregion

            #endregion
        }
    }
}
