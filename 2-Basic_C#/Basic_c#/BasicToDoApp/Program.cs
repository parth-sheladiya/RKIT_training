using System;

namespace TodoListApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager manager = new TaskManager();

            while (true)
            {
                Console.WriteLine("\nTodo List Application");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View All Tasks");
                Console.WriteLine("3. Update Task");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Mark Task as Complete");
                Console.WriteLine("6. Mark Task as Pending");
                Console.WriteLine("7. View Overdue Tasks");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            manager.AddTask();
                            break;
                        case 2:
                            manager.ViewAllTasks();
                            break;
                        case 3:
                            manager.UpdateTask();
                            break;
                        case 4:
                            manager.DeleteTask();
                            break;
                        case 5:
                            manager.MarkTaskAsComplete();
                            break;
                        case 6:
                            manager.MarkTaskAsPending();
                            break;
                        case 7:
                            manager.ViewOverdueTasks();
                            break;
                        case 8:
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
