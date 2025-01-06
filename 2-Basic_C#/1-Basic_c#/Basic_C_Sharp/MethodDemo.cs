using System;
using System.Diagnostics.Metrics;


namespace Basic_C_Sharp
{
    public class MethodDemo
    {
        public static void RunMethodDemo()
        {
            #region basic method
            // Call a method with no parameters
            ShownMessage();
            ShownMessage();
            ShownMessage();
            ShownMessage();
            // Call a method with a single parameter
            ShownMessage("hello .net");
            ShownMessage(message : "hello message parameter");

            ShownMessage("this", "is", "csharp");


            MyMethod("Sweden");
            MyMethod("India");
            MyMethod();
            MyMethod("USA");
            #endregion




            // Call a method with a return value
            int sum = AddTwoNumbers(12, 13);
            Console.WriteLine("two number a and b sum is : " + sum);

            // Call a method with a return value
            int ans = MultiplyThreeNum(2, 3, 4);
            Console.WriteLine("multiply three number ans is : " + ans);

            ChildMethod(child3: "John", child1: "Liam", child2: "Liam");

            PrintDetails(name: "virat", age: 38, city: "mumbai");

            int myNum1 = PlusMethod(8, 5);
            Console.WriteLine("int method :" + myNum1);

            double myNum2 = PlusMethod(4.3, 6.26);
            Console.WriteLine("double method : " + myNum2);


            Console.WriteLine("Factorial of 5 is: " + Factorial(5));


            int number = 5;
            ModifyValue(ref number);
            Console.WriteLine("pass by ref : " + number);

            int sumOfProduct, product;
            CalculateSumAndProduct(5, 10, out sumOfProduct, out product);
            Console.WriteLine("sumofproduct is :"+ sumOfProduct);
            Console.WriteLine("Product: " + product);
        }

        // Method to handle single message with a default value
        static void ShownMessage(string message = "hello default message")
        {
            Console.WriteLine(message);
        }

        // Overloaded method to handle multiple messages
        static void ShownMessage(params string[] messages)
        {
            Console.WriteLine(string.Join(" ", messages));
        }

        static int AddTwoNumbers(int a , int b)
        {
            return a + b;
        }

        static int MultiplyThreeNum(int c , int d , int e)
        {
            return c * d * e;
        }


        static void MyMethod(string country = "norway")
        {
            Console.WriteLine(country);
        }

        static void ChildMethod(string child1 , string child2 , string child3)
        {
            Console.WriteLine("the youngest child is :" + child3);
        }

         static void PrintDetails(string name, int age, string city)
        {
            Console.WriteLine($"Name: {name}, Age: {age}, City: {city}");
        }


        static int PlusMethod(int x, int y)
        {
            return x + y;
        }

        static double PlusMethod(double x, double y)
        {
            return x + y;
        }

        static int Factorial(int n)
        {
            if (n == 1)  // Base case
                return 1;
            return n * Factorial(n - 1);  // Recursive call
        }


        static void ModifyValue(ref int num)
        {
            num += 10;  // Changes the original value
            Console.WriteLine("Inside method: " + num);
        }

        static void CalculateSumAndProduct(int a, int b, out int sumOfProduct, out int product)
        {
            sumOfProduct = a + b;         
            product = a * b;    
        }


    }
    

    

    }


