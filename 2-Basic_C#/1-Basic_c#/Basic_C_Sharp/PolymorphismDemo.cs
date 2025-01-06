using System;


namespace Basic_C_Sharp
{
    public class PolymorphismDemo
    {
        public static void RunPolymorphismDemo()
        {
            #region compile time polymorphism
            Console.WriteLine("compile time polymorphism");

            Calculator calc = new Calculator();
            Console.WriteLine(calc.Add(2, 3));
            Console.WriteLine(calc.Add(2.1, 5.6, 8.9));
            Console.WriteLine(calc.Add("hello ", "c#"));

            #endregion

            #region run time poly..
            Console.WriteLine("runtimme polymorphism");
            Animal animal = new Dog();
            animal.Sound();
            #endregion
        }

            #region compiletime poly..
        class Calculator
        {
            public int Add(int a, int b)
            {
                return a + b;
            }

            public double Add(double a, double b, double c)
            {
                return a + b + c;
            }

            public string Add(string a, string b)
            {
                return a + b;
            }
        }
        #endregion

            #region run time poly...
        class Animal
        {
            public virtual void Sound()
            {
                Console.WriteLine("Animal makes a sound.");
            }
        }

        class Dog : Animal
        {
            public override void Sound()
            {
                Console.WriteLine("Dog barks.");
            }
        }
        #endregion
    }
}
