using System;

namespace TypesOfClass
{
    /// <summary>
    /// basic instance class and example is car's brand and model  
    /// </summary>
    public class InstanceClass
    {
        // Car class ki properties aur methods
        public class Car
        {
            // car company
            public string Brand { get; set; }
            // car model
            public string Model { get; set; }

            // Constructor 
            public Car()
            {
                Brand = "Toyota";   
                Model = "Corolla"; 
            }

            // Method 
            public void DisplayDetails()
            {
                // string interpolation
                Console.WriteLine($"Car: {Brand} {Model}");
            }
        }

       // main method
        public static void CreateAndDisplayCar()
        {
            // create car instance 
            Car myCar = new Car();

            // calling car details
            myCar.DisplayDetails();  
        }
    }
}
