using System;


namespace Basic_C_Sharp
{
    public class AbstractionDemo
    {
        public static void RunAbstractionDemo()
        {
            #region abstract data
            Console.WriteLine("abstraction");
            Shape circle = new Circle();
            circle.Draw();       
            circle.Display();    

            Shape rectangle = new Rectangle();
            rectangle.Draw();    
            rectangle.Display();
            #endregion


            #region interface
            Console.WriteLine("interface");

            IVehicle car = new Car();
            car.Start(); 
            car.Stop();  

            IVehicle bike = new Bike();
            bike.Start(); 
            bike.Stop();  

            #endregion



        }

        #region abstract class
        abstract class Shape
        {
            public abstract void Draw(); // Abstract method (no implementation)

            public void Display()
            {
                Console.WriteLine("This is a shape.");
            }
        }

        
        class Circle : Shape
        {
            public override void Draw()
            {
                Console.WriteLine("Drawing a circle.");
            }
        }

        class Rectangle : Shape
        {
            public override void Draw()
            {
                Console.WriteLine("Drawing a rectangle.");
            }
        }

        #endregion

        #region interface 
        interface IVehicle
        {
            void Start();  // Method signature
            void Stop();
        }

        class Car : IVehicle
        {
            public void Start()
            {
                Console.WriteLine("Car is starting...");
            }

            public void Stop()
            {
                Console.WriteLine("Car is stopping...");
            }
        }
        class Bike : IVehicle
        {
            public void Start()
            {
                Console.WriteLine("Bike is starting...");
            }

            public void Stop()
            {
                Console.WriteLine("Bike is stopping...");
            }
        }
        #endregion
    }
}
