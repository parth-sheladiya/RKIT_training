using System;


namespace Basic_C_Sharp
{
    public class ExceptionHandlingDemo
    {
        public static void RunExceptionHandlingDemo()
        {
            #region basic exception handling
            try
            {
                int fNum = 10;
                int sNum = 0;
                int res = fNum / sNum;
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine("cannot divide by 0");
                Console.WriteLine($"error :{ex.Message}");
            }
            finally
            {
                Console.WriteLine("Execution completed.");
            }
            #endregion


            #region multiple exception handling
            try
            {
                int[] numbers = { 1, 2, 3, 4, 5 };
                Console.WriteLine(numbers[10]);
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine("array index is out of bound");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"error : {ex.Message}");
            }
            #endregion


            #region throw throw ex
            try
            {
                Method1();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught in Main:");
                Console.WriteLine(ex.StackTrace); // Stack trace ko display karega
            }
            #endregion


        }

        #region throw throw ex
        static void Method1()
        {
            try
            {
                Method2();
            }
            catch (Exception ex)
            {
                // throw: Original stack trace ko preserve karega
              ///  throw;

                // throw ex: Stack trace ko reset karega
                /// throw ex;
            }
        }

        static void Method2()
        {
            throw new Exception("Error occurred in Method2");
        }

        #endregion
    }
}
