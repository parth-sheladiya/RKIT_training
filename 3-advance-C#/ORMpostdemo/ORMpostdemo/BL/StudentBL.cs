
using ORMpostdemo.Models;
using ORMpostdemo.Repository;

namespace ORMpostdemo.BL
{
    public class StudentBL
    {
        private readonly StudentRepository _studentRepository;

        // Constructor to initialize StudentRepository (if needed)
        public StudentBL()
        {
            _studentRepository = new StudentRepository(); // Ensure repository is correctly initialized
        }

        // Add student logic
        public Student AddStudent(Student student)
        {
            // Assuming you have a repository to handle database logic
            _studentRepository.AddStudent(student);

            return student; // Return the added student
        }
    }
}
