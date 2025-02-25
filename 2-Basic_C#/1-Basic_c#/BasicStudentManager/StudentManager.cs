using System;
using System.Collections.Generic;
using System.IO;

namespace BasicStudentManager
{
    /// <summary>
    /// Interface creation for managing students
    /// </summary>
    public interface IStudentOperationsManager
    {
        public void AddStudent();
        public void ViewAllStudents();
        public void UpdateStudent();
        public void DeleteStudent();
        public void SearchStudent();
    }

    /// <summary>
    /// Create student manager class and implement IStudentOperationsManager methods
    /// </summary>
     #region  student manage class like add , update , delete , view
    public class StudentManager : IStudentOperationsManager
    {
        private const string FilePath = "students.txt";
        private List<Student> students = new List<Student>();
        private int nextStudentId = 1;

        /// <summary>
        /// Constructor and initialization logic for setting loading students from the file
        /// </summary>
        public StudentManager()
        {
            LoadStudentsFromFile();
            SaveStudentsToFile();
        }

        /// <summary>
        /// Add student based on user input, tryparse method, and then add student to list and data table
        /// </summary>
        #region AddStudent Method
        public void AddStudent()
        {
            try
            {
                // enter name
                Console.Write("Enter student name: ");
                string name = Console.ReadLine();

                // enter class
                int studentClass;
                Console.Write("Enter class (1 to 12): ");
                if (!int.TryParse(Console.ReadLine(), out studentClass) || studentClass < 1 || studentClass > 12)
                {
                    Console.WriteLine("Class must be a number between 1 and 12.");
                    return;
                }

                // enter mark
                double marks;
                Console.Write("Enter Marks: ");
                if (!double.TryParse(Console.ReadLine(), out marks) || marks < 0 || marks > 100)
                {
                    Console.WriteLine("Marks must be a number between 0 and 100.");
                    return;
                }

                // enter dob
                DateTime dob;
                Console.Write("Enter Date of Birth (yyyy-MM-dd): ");
                string dobInput = Console.ReadLine();

                // Directly try to parse the date without validation
                dob = DateTime.Parse(dobInput);


                // Then, check if the date is in the future
                if (dob > DateTime.Now)
                {
                    Console.WriteLine("Date of Birth cannot be in the future.");
                    return;
                }

                var student = new Student
                {
                    ID = nextStudentId++,
                    Name = name,
                    Class = studentClass.ToString(),
                    Marks = marks,
                    DateOfBirth = dob
                };
                // add student to list
                students.Add(student);
                // success message
                Console.WriteLine("Student added successfully.");
                // save student 
                SaveStudentsToFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        #endregion

        /// <summary>
        /// View all students by checking if student count is non-zero and displaying data from DataTable
        /// </summary>

        #region ViewAllStudents Method
        public void ViewAllStudents()
        {
            // check student count zero or not
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }
            // itration   then show data
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.ID}, Name: {student.Name}, Class: {student.Class}, Marks: {student.Marks}, Date of Birth: {student.DateOfBirth:yyyy-MM-dd}");
            }
        }
        #endregion

        /// <summary>
        /// Update student by checking if the student exists, input updated data, and save to list and DataTable
        /// </summary>
        #region UpdateStudent Method
        public void UpdateStudent()
        {
            try
            {
                Console.Write("Enter Student ID to update: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID.");
                    return;
                }

                var student = students.Find(s => s.ID == id);
                if (student == null)
                {
                    Console.WriteLine("Student not found.");
                    return;
                }

                Console.Write("Enter updated name");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    student.Name = name;
                }
                // Class validation: Only numbers 1 to 12 allowed
                Console.Write("Enter updated class  ");
                string classInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(classInput) && int.TryParse(classInput, out int studentClass) && studentClass >= 1 && studentClass <= 12)
                {
                    student.Class = studentClass.ToString();
                }
                else if (!string.IsNullOrEmpty(classInput))
                {
                    Console.WriteLine("Invalid class. Please enter a number between 1 and 12.");
                    return;
                }

                Console.Write("Enter updated marks  ");
                string marksInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(marksInput))
                {
                    if (double.TryParse(marksInput, out double marks))
                    {
                        if (marks < 0 || marks > 100)
                        {
                            Console.WriteLine("Marks must be between 0 and 100.");
                            return;
                        }
                        student.Marks = marks;
                    }
                    else
                    {
                        Console.WriteLine("Invalid marks. Please enter a valid number.");
                        return;
                    }
                }

                // sucess message
                Console.WriteLine("Student updated successfully.");
                // Save updated students list to file
                SaveStudentsToFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
        #endregion

        /// <summary>
        /// Delete student by fetching ID, removing student from list and DataTable
        /// </summary>
        #region DeleteStudent Method
        public void DeleteStudent()
        {
            Console.Write("Enter Student ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            var student = students.Find(s => s.ID == id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            students.Remove(student);

            Console.WriteLine("Student deleted successfully.");

            SaveStudentsToFile();
        }
        #endregion

        /// <summary>
        /// Search student by ID, check if student exists, and display student details
        /// </summary>
        #region SearchStudent Method
        public void SearchStudent()
        {
            Console.Write("Enter Student ID to search: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            var student = students.Find(s => s.ID == id);
            if (student == null)
            {
                Console.WriteLine("No student found.");
                return;
            }

            Console.WriteLine(student);
        }
        #endregion


        #endregion  

        /// <summary>
        /// File operations for loading and sa.ving students to/from a text file
        /// </summary>
        #region File Handling Methods
        private void LoadStudentsFromFile()
        {
            try
            {
                if (!File.Exists(FilePath))

                {
                    Console.WriteLine("File not found.");
                    return;
                }

                using (StreamReader reader = new StreamReader(FilePath))
                {
                    while (reader.Peek() >= 0)
                    {
                        string line = reader.ReadLine();
                        string[] parts = line.Split(',');

                        string idPart = parts[0];
                        string namePart = parts[1];
                        string classPart = parts[2];
                        string marksPart = parts[3];
                        string dobPart = parts[4];

                        if (int.TryParse(idPart, out int id) &&
                            double.TryParse(marksPart, out double marks) &&
                            DateTime.TryParse(dobPart, out DateTime dob))
                        {
                            var student = new Student
                            {
                                ID = id,
                                Name = namePart,
                                Class = classPart,
                                Marks = marks,
                                DateOfBirth = dob
                            };

                            students.Add(student);
                            nextStudentId = Math.Max(nextStudentId, id + 1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading students: {ex.Message}");
            }
        }

        private void SaveStudentsToFile()
        {


            try
            {
                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    foreach (var student in students)
                    {
                        writer.WriteLine($"{student.ID},{student.Name},{student.Class},{student.Marks},{student.DateOfBirth:yyyy-MM-dd}");
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error saving students: {ex.Message}");
            }

            FileInfoManager.DisplayFileInfo(FilePath);
        }
        #endregion
    }
}
