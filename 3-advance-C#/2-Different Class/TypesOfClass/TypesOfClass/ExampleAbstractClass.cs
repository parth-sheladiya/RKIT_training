using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesOfClass
{
    /// <summary>
    /// abstract class 
    /// obj not created 
    /// is is only allow abs method implementation
    /// one abs method must be include in abs class
    /// its only one sub class 
    /// </summary>
    public class ExampleAbstractClass
    {
        public abstract class Animal
        {
            // Abstract method no implementation 
            public  abstract void MakeSound();

            // Regular method implementation 
            public void Sleep()
            {
                Console.WriteLine("The animal is sleeping.");
            }
        }

        public class Dog : Animal
        {
            // implement abs method
            public override void MakeSound()
            {
                Console.WriteLine("Bark");
            }

           
        }

        // abs class obj not created and subclass object created
        public static void CallAnimalMethods()
        {
            Animal animal = new Dog();  
            animal.MakeSound(); 
            animal.Sleep();      
        }




    }
}
