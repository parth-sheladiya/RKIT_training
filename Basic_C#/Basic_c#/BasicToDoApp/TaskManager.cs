using System;
using System.Collections.Generic;
using System.Linq;

namespace TodoListApplication
{
    class TaskManager
    {
        private List<Task> tasks = new List<Task>();
        private int nextTaskId = 1;

        public void AddTask()
        {
            try
            {
                Console.Write("Enter Task Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Due Date (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
                {
                    tasks.Add(new Task { ID = nextTaskId++, Name = name, DueDate = dueDate, IsComplete = false });
                    Console.WriteLine("Task added successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid date format.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void ViewAllTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
                return;
            }

            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
        }

        public void UpdateTask()
        {
            Console.Write("Enter Task ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var task = tasks.FirstOrDefault(t => t.ID == id);
                if (task != null)
                {
                    Console.Write("Enter new Name (leave blank to keep unchanged): ");
                    string name = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(name)) task.Name = name;

                    Console.Write("Enter new Due Date (yyyy-MM-dd, leave blank to keep unchanged): ");
                    string dateInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(dateInput) && DateTime.TryParse(dateInput, out DateTime dueDate))
                    {
                        task.DueDate = dueDate;
                    }

                    Console.WriteLine("Task updated successfully.");
                }
                else
                {
                    Console.WriteLine("Task not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        public void DeleteTask()
        {
            Console.Write("Enter Task ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var task = tasks.FirstOrDefault(t => t.ID == id);
                if (task != null)
                {
                    tasks.Remove(task);
                    Console.WriteLine("Task deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Task not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        public void MarkTaskAsComplete()
        {
            Console.Write("Enter Task ID to mark as complete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var task = tasks.FirstOrDefault(t => t.ID == id);
                if (task != null)
                {
                    if (task.IsComplete)
                    {
                        Console.WriteLine("Your task is already marked as complete.");
                    }
                    else
                    {
                        task.IsComplete = true;
                        Console.WriteLine("Task marked as complete.");
                    }
                }
                else
                {
                    Console.WriteLine("Task not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        public void MarkTaskAsPending()
        {
            Console.Write("Enter Task ID to mark as pending: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var task = tasks.FirstOrDefault(t => t.ID == id);
                if (task != null)
                {
                    if (!task.IsComplete)
                    {
                        Console.WriteLine("Your task is already marked as pending.");
                    }
                    else
                    {
                        task.IsComplete = false;
                        Console.WriteLine("Task marked as pending.");
                    }
                }
                else
                {
                    Console.WriteLine("Task not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        public void ViewOverdueTasks()
        {
            var overdueTasks = tasks.Where(t => t.DueDate < DateTime.Now && !t.IsComplete).ToList();

            if (overdueTasks.Count == 0)
            {
                Console.WriteLine("No overdue tasks.");
                return;
            }

            Console.WriteLine("Overdue Tasks:");
            foreach (var task in overdueTasks)
            {
                Console.WriteLine(task);
            }
        }
    }
}
