using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesOfClass
{
    /// <summary>
    /// restrict inheritance
    /// private and protected are not allow in seald class
    /// </summary>
    // Sealed class definition
    public sealed class ExampleSealedClass
    {
        // Method to call the Drive method
        public void Drive()
        {
            Console.WriteLine("Vehicle is driving");
        }

        // Static method to create an object and call Drive()
        public static void CallDriveMethodStatic()
        {
            // Creating object of ExampleSealedClass inside the static method
            ExampleSealedClass vehicle = new ExampleSealedClass();

            // Calling the Drive method
            vehicle.Drive();
        }
    }

}
