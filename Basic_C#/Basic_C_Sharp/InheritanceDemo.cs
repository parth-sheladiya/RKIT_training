using System;
using System.ComponentModel.DataAnnotations;


namespace Basic_C_Sharp
{
   public class InheritanceDemo
    {
        public static void RunInheritanceDemo()
        {
            #region single inheritance
            Console.WriteLine("single inheritance");

            Car myCar = new Car();

            myCar.Established();


            Console.WriteLine(myCar.brand + " " + myCar.modalName);

            #endregion


            #region multilevel inheritance
            Console.WriteLine("multilevel inheritancwe");
            BabyDog myBabyDog = new BabyDog();
            myBabyDog.eat();
            myBabyDog.bark();
            myBabyDog.weep();

            #endregion

            #region Hierarchical Inheritance

            Console.WriteLine("Teacher Actions:");
            Teacher myTeacher = new Teacher();
            myTeacher.hName = "sir virat";
            myTeacher.Speak(); // Base class method
            myTeacher.Teach();

            Console.WriteLine("\nStudent Actions:");
            Student myStudent = new Student();
            myStudent.hName = "Rahul";
            myStudent.Speak(); // Base class method
            myStudent.Study();
            #endregion


            #region multiple inheritance via interface
            Console.WriteLine("multiple inheritance");
            PaymentProcess payment = new PaymentProcess();
            
            payment.ProcessBankTransfer();
            payment.ProcessCreditCard();
            #endregion

            #region polymorphisam with inheritance
            Parent obj = new Child();
            obj.Display();
            #endregion

        }


        #region single inheritance class

        public class Vehicle
        {
            public string brand = "toyota";
            public void Established()
            {
                Console.WriteLine("1990");
            }
        }

        class Car :Vehicle
        {
            public string modalName="innova";
        }




        #endregion


        #region multilevel inheritance
        public class Animal
        {
            public void eat()
            {
                Console.WriteLine("eating..");
            }
        }

        public class Dog :Animal
        {
            public void bark()
            {
                Console.WriteLine("barking...");
            }
        }

        public class BabyDog :Dog
        {
            public void weep()
            {
                Console.WriteLine("weeping");
            }
        }
        #endregion


        #region Hierarchical Inheritance
        public class Person
        {
            public string hName { get; set; }

            public void Speak()
            {
                Console.WriteLine(hName + " is speaking.");
            }
        }

        public class Teacher : Person
        {
            public void Teach()
            {
                Console.WriteLine(hName + " is teaching.");
            }
        }

        public class Student : Person
        {
            public void Study()
            {
                Console.WriteLine(hName + " is studying.");
            }
        }

        #endregion


        #region multiple inheritance
        interface CreditCardPayment
        {
            void ProcessCreditCard();
           
        }

        interface BankTransferPayment
        {
            void ProcessBankTransfer();
            

        }

        class PaymentProcess : CreditCardPayment , BankTransferPayment
        {
           

            
            public void ProcessCreditCard()
            {
                Console.WriteLine("complate credit car payment process");
                
            }
            public void ProcessBankTransfer()
            {
                Console.WriteLine("complate bank transfer paymrnt process");

            }
        }
        #endregion


        #region polymorphisam with inheritance class
        class Parent
        {
            public virtual void Display()
            {
                Console.WriteLine("parent class display method");
            }


        }
        class Child : Parent
        {
            public override  void Display()
            {
                Console.WriteLine("child class display method");
            }
        }

        #endregion

    }
}
