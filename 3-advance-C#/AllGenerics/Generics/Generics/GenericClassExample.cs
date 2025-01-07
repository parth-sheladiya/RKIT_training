using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    /// <summary>
    /// .it is not used to specific types of data
    /// it's default access specifier is same as normal class access specifier
    /// T is generic type parameter 
    /// </summary>
    public class GenericClassExample
    {

        // create generic class 
        public class Box<T> 
        {
            // private field
            private T item;

            // get set method
            public void SetItem(T item)
            {
                this.item = item;
            }

            public T GetItem()
            {
                return item;
            }
        }


        // main method 
        public static void TestBoxOperations()
        {
            // Creating an instance of Box with type is int
            var intBox = new Box<int>();
            intBox.SetItem(100);
            Console.WriteLine(intBox.GetItem());  

            // Creating an instance of Box with type is string
            var strBox = new Box<string>();
            strBox.SetItem("Hello, Generic!");
            Console.WriteLine(strBox.GetItem());  
        }
    }
}
