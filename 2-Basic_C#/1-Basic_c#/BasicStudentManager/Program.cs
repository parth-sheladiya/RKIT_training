using BasicStudentManager;
using System;

namespace BasicStudentManager
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();

            while (true)
            {
                Console.WriteLine("\nStudent Management System");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Search Student");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            manager.AddStudent();
                            break;
                        case 2:
                            manager.ViewAllStudents();
                            break;
                        case 3:
                            manager.UpdateStudent();
                            break;
                        case 4:
                            manager.DeleteStudent();
                            break;
                        case 5:
                            manager.SearchStudent();
                            break;
                        case 6:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }
    }
}
