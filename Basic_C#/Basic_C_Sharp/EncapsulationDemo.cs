using System;


namespace Basic_C_Sharp
{
    public class EncapsulationDemo
    {
        public static void RunEncapsulationDemo()
        {
            #region person data
            Person person = new Person();

            // Setting values using properties
            person.Name = "John";
            person.Age = 25;

            // Displaying information
            person.DisplayInfo();

            // Trying to set an invalid age
            person.Age = -5; // Invalid, won't update age

            // Displaying information again
            person.DisplayInfo();
            #endregion
        }


        #region  person class
        class Person
        {
            // Private fields
            private string name;
            private int age;

            // Public property to access private fields
            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            // Property with validation
            public int Age
            {
                get { return age; }
                set
                {
                    if (value > 0)
                    {
                        age = value;
                    }
                    else
                    {
                        Console.WriteLine("Age must be positive.");
                    }
                }
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Name: {name}, Age: {age}");
            }

        }
        #endregion

    }

}