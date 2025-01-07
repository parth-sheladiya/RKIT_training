using System;

namespace Basic_C_Sharp
{
    public class ArrayDemo
    {
        public static void RunArrayDemo()
        {
            #region single dimensional array
            int[] arrNumbers = new int[5];
            arrNumbers[0] = 10;
            arrNumbers[1] = 20;
            arrNumbers[2] = 30;
            arrNumbers[3] = 40;
            arrNumbers[4] = 50;

            Console.WriteLine(arrNumbers[3]);
            Console.WriteLine(arrNumbers[4]);
            for (int i = 0; i < arrNumbers.Length; i++)
            {
                Console.WriteLine("arrnumbers of arr is " + arrNumbers[i]);
            }
            #endregion

            #region multi dimensional array
            int[,] arr = new int[2, 2];
            arr[0, 0] = 10;
            arr[1, 0] = 20;
            arr[0, 1] = 30;
            arr[1, 1] = 40;

            // Corrected loops
            for (int i = 0; i < 2; i++) 
            {
                for (int j = 0; j < 2; j++) 
                {
                    Console.WriteLine("2 d arr is :" + arr[i, j]);
                }
            }
            Console.WriteLine("arr of 1,1 is :" + arr[1, 1]);
            #endregion

            #region jagged array
            int[][] jaggedArr = new int[2][];
            jaggedArr[0] = new int[] { 1, 2 };
            jaggedArr[1] = new int[] { 3, 4, 5 };
            Console.WriteLine("jagged arr of 1,2 is: " + jaggedArr[1][2]);
            #endregion

            #region string array
            string[] names = { "Amit", "Ravi", "Priya" };
            Console.WriteLine(names[0]);
            #endregion

            #region float array
            float[] prices = { 12.5f, 34.7f, 50.2f };
            Console.WriteLine(prices[1]);
            #endregion

            #region mixed array
            object[] mixedArray = { 1, "Hello", 3.14, true };

            Console.WriteLine(mixedArray[1]);
            Console.WriteLine(mixedArray[3]);
            #endregion

            #region array methods
            int[] numbers = { 5, 1, 8, 3 };
            Array.Sort(numbers); 
            for(int i = 0;i < numbers.Length;i++)
            {
                Console.WriteLine(numbers[i]);
            }

            int[] rNumbers = { 1, 2, 3, 4 };
            Array.Reverse(rNumbers); 
            for(int i = 0; i < rNumbers.Length;i++)
            {
                Console.WriteLine(rNumbers[i]);
            }

            int[] iNumbers = { 10, 20, 30, 20 };
            int index = Array.IndexOf(iNumbers, 20);
            Console.WriteLine(index);

            int[] lNumbers = { 10, 20, 30, 20 };
            int lIndex = Array.LastIndexOf(lNumbers, 20); // index: 3
            Console.WriteLine(lIndex);

            int[] cNumbers = { 1, 2, 3, 4 };
            Array.Clear(cNumbers, 1, 2); 
            for(int i = 0;i<cNumbers.Length;i++)
            {
                Console.WriteLine(cNumbers[i]);
            }

            int[] source = { 1, 2, 3 };
            int[] destination = new int[3];
            Array.Copy(source, destination, 3); 

            for(int i = 0;i<destination.Length;i++)
            {
                Console.WriteLine(destination[i]);
            }

            int[] fNumbers = { 1, 2, 3, 4 };
            int result = Array.Find(fNumbers, x => x > 2); 
            Console.WriteLine(result);

            int[] fAllNumbers = { 1, 2, 3, 4 };
            int[] fResult = Array.FindAll(fAllNumbers, x => x > 2);

            int[] resizeNumbers = { 1, 2, 3 };
            Array.Resize(ref resizeNumbers, 5);
            for (int i = 0; i < resizeNumbers.Length; i++)
            {
                Console.WriteLine(resizeNumbers[i]);
            }







            #endregion
        }
    }
}
