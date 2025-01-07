using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    /// <summary>
    /// it is use to accecpt to generic type of parameter 
    /// it is allow to constraints
    /// </summary>
    public class GenericInterfaceExample
    {
        // Define a generic interface with a property
        public interface IBox<T>
        {
            // declaration
            T Item { get; set; }  
        }

        // Implementing the generic interface in a class
        public class Box<T> : IBox<T>
        {
            // Implementing the Item property from the interface
            public T Item { get; set; }  // Automatically handles setting and getting the value
        }


        public static void interfacePrint()
        {
            // Using the generic interface with  integer type
            // Set the item directly
            IBox<int> intBox = new Box<int>();
            intBox.Item = 100; 
            // Get the item directly
            Console.WriteLine(intBox.Item);  

            // Using the generic interface with  string type
            IBox<string> strBox = new Box<string>();
            // Set the item directly
            strBox.Item = "Hello, Generic Interface!";  
            // Get the item directly,
            Console.WriteLine(strBox.Item);  
        }
    }
}
