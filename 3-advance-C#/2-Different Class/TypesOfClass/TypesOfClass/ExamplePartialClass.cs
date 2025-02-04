using System;

namespace TypesOfClass
{
    /// <summary>
    /// partial class
    /// it is use a saprate part of other file 
    /// it is only allow same name of class
    /// if we not use same name class compiler will give compile error 
    /// </summary>
    // First part of the partial class
    public partial class ExamplePartialClass
    {
        // method
        public void DisplayMessage()
        {
            Console.WriteLine("This is the first part of ExamplePartialClass.");
        }

        // main method
        public static void CallMethods()
        {
            // create object
            ExamplePartialClass example = new ExamplePartialClass();

            // calling methoid
            example.DisplayMessage();
            example.DisplayAnotherMessage();
        }
    }

    // Second part of the partial class
    public partial class ExamplePartialClass
    {
        public void DisplayAnotherMessage()
        {
            Console.WriteLine("This is the second part of ExamplePartialClass.");
        }

       
    }




}
