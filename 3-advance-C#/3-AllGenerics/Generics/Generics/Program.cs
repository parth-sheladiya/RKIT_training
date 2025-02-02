using System;


namespace Generics
{
    /// <summary>
    /// it is use to  method call for below types. 
    /// generic method
    /// generic class
    /// generic interface
    /// </summary>
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("hello") ;
            Console.WriteLine("generic method");
            #region generic method
            // method call for generic method
            GenericMethodExample.Print("hello");
            GenericMethodExample.Print(100);
            GenericMethodExample.Print(100.200);
            #endregion

            #region generic class
            Console.WriteLine("generic class");
            // method call fro generic class
            GenericClassExample.TestBoxOperations();
            #endregion


            #region generic interface
            Console.WriteLine("generic interface");
            // method call for generic interface 
            GenericInterfaceExample.interfacePrint();
            #endregion
        }
    }
}