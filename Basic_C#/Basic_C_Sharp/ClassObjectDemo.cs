using System;


namespace Basic_C_Sharp
{
    public class ClassObjectDemo
    {
        public static void RunClassObjectDemo()
        {
            #region student data
            Student s1 = new Student();
            s1.id = 101;
            s1.sname = "parth";
            Console.WriteLine(s1.id);
            Console.WriteLine(s1.sname);
            #endregion

            #region teststudent data
            TestStudent s3 = new TestStudent();
            TestStudent s4 = new TestStudent();

            s3.insert(505, "ravi");
            s4.insert(606, "raj");

            s3.display();
            s4.display();
            #endregion

            #region employee data
            Console.WriteLine("Creating Employee object...");
            Employee e1 = new Employee();
            Console.WriteLine("End of scope for Employee object...");
            Console.WriteLine("Exiting program...");
            #endregion

            #region Company data
            Company c1 = new Company(1, "rkit", "accounting", 4.5f);
            c1.display();
            #endregion

            #region static acc data
            Account a1 = new Account(101, "Sonoo");
            Account a2 = new Account(102, "Mahesh");
            a1.display();
            a2.display();

            #endregion

        }


        #region student class
        class Student
        {
          public  int id;
          public  string sname;

        }
        #endregion

        #region teststudent class
        class TestStudent
        {
            public int id;
            public string tname; 
            public void insert(int i , string n)
            {
                id = i;
                tname=n;
            }
            public void display()
            {
                Console.WriteLine(id  + " " + tname); 
            }
        }
        #endregion

        #region Employee class
        class Employee
        {
            public Employee()
            {
                Console.WriteLine("default constructor call");
            }
            ~Employee()
            {
                Console.WriteLine("destructor called");
            }
        }
        #endregion

        #region Company class
        class Company
        {
            public int id;
            public string name;
            public string description;
            public float rating;

            public Company(int i , string n, string d, float r)
            {
               id = i;
               name = n;
               description = d;
               rating = r;
            }
            public void display()
            {
                Console.WriteLine (id + " " + name + " " + description + " " + rating);
            }
        }
        #endregion

        #region static keyword
        public class Account
        {
            public int accno;
            public string name;
            public static float rateOfInterest = 8.8f; // Static field  

            public Account(int accno, string name)
            {
                this.accno = accno;
                this.name = name;
            }

            public void display()
            {
                Console.WriteLine(accno + " " + name + " " + rateOfInterest);
            }
        }
        #endregion
    }
}
