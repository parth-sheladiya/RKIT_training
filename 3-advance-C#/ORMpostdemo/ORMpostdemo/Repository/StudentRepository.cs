using ServiceStack.OrmLite;
using System.Configuration; // For reading connection string from web.config
using ORMpostdemo.Models;


namespace ORMpostdemo.Repository
{
    public class StudentRepository
    {
        private readonly OrmLiteConnectionFactory _dbFactory;

        // Constructor to initialize the OrmLiteConnectionFactory with dynamic connection string
        public StudentRepository()
        {
            // Fetch connection string from web.config dynamically
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            // Initialize OrmLiteConnectionFactory with the connection string
            _dbFactory = new OrmLiteConnectionFactory(connectionString, MySqlDialect.Provider);
        }

      

        // Method to add a student
        public void AddStudent(Student student)
        {
            using (var db = _dbFactory.Open()) // Open connection using DbFactory
            {
                // Create the table if it doesn't exist
                db.CreateTableIfNotExists<Student>();
                db.Insert(student); // Insert the student into the database
            }
        }
    }
}
