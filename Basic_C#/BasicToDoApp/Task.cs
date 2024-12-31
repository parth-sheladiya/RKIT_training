using System;

namespace TodoListApplication
{
    class Task
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, DueDate: {DueDate:yyyy-MM-dd}, Status: {(IsComplete ? "Complete" : "Pending")}";
        }
    }
}
