using System;

namespace BasicStudentManager
{
    /// <summary>
    /// Student details like ID, Name, Class, Marks, Date of Birth
    /// </summary>
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; } 
        public string Class { get; set; }
        public double Marks { get; set; }
        public DateTime DateOfBirth { get; set; }

        
    }
}
