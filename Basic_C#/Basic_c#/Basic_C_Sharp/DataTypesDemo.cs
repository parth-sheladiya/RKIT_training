namespace Basic_C_Sharp
{
    public class DataTypesDemo
    {
        public static void RunDataTypesDemo()
        {
            /// <summary>
            /// Part 1: Data Types
            /// </summary>

            #region Value Type Data
            int integerNumber = 10;
            double doubleNumber = 20;
            char c = 'a';
            bool isTrue = false;
            float floatingNumber = 50.45F;
            #endregion

            #region Reference Type Data
            string firstString = "hello c#";

            object myInt = 100;
            object myString = "Hello, C#!";
            object myFloat = 3.14f;
            #endregion

            #region Nullable Type Data
            int? nullableInt = null;
            double? nullableDbl = 52;
            #endregion

            /// <summary>
            /// Display Value Type Data
            /// </summary>
            #region Display Value Type Data
            Console.WriteLine("int number is: " + integerNumber);
            Console.WriteLine("double number is: " + doubleNumber);
            Console.WriteLine("char is: " + c);
            Console.WriteLine("true or false: " + isTrue);
            Console.WriteLine("float number is: " + floatingNumber);
            #endregion

            /// <summary>
            /// Display Reference Type Data
            /// </summary>
            #region Display Reference Type Data
            Console.WriteLine("string is: " + firstString);
            Console.WriteLine($"obj is: {myInt}, type: {myInt.GetType()}");
            Console.WriteLine($"obj is: {myString}, type: {myString.GetType()}");
            Console.WriteLine($"obj is: {myFloat}, type: {myFloat.GetType()}");
            #endregion

            /// <summary>
            /// Display Nullable Type Data
            /// </summary>
            #region Display Nullable Type Data
            Console.WriteLine($"nullable int: {nullableInt ?? 0}");
            Console.WriteLine($"nullable double: {nullableDbl}");
            #endregion

            /// <summary>
            /// Part 2: Variables in C#
            /// </summary>

            #region Local Variables
            int age = 30; // Local variable
            string name = "Rahul"; // Local variable

            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
            #endregion

            // Implicit Conversion
            Console.WriteLine("inplicit typecasting");
            int num = 10;
            double result = num;
            Console.WriteLine( "double num is : " + result);

            // Explicit Conversion (Type Casting)
            Console.WriteLine("Explicit Conversion");
            double value = 9.78;
            int newValue = (int)value;
            Console.WriteLine("new value" + newValue);

            // Using Convert Class
            string strNum = "50";
            int convertedNum = Convert.ToInt32(strNum);
            Console.WriteLine("convertednum is :" + convertedNum);

            // Using Parse() Method
            string strFloat = "19.99";
            float parsedFloat = float.Parse(strFloat);
            Console.WriteLine("str to float : " + parsedFloat);


           
        }

        void Display()
        {
            #region Local Variable
            int number = 10; // Local variable
            Console.WriteLine(number);
            #endregion
        }

        class Person
        {
            #region Instance Variable
            string name; // Instance variable
            #endregion
        }

        class PersonStatic
        {
            #region Static Variable
            static int population = 0; // Static variable
            #endregion
        }


    }
}
