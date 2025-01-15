using System.Web.Http;
using ORMpostdemo.BL;  // Replace with your actual namespace
using ORMpostdemo.Models;  // Replace with your actual namespace

namespace ORMpostdemo.Controllers  // Replace with your actual namespace
{
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        private readonly StudentBL _studentBL;

        // Constructor to initialize StudentBL
        public StudentController()
        {
            // Ensure this is correct for your StudentBL class initialization
            _studentBL = new StudentBL();
        }

        // POST request to add a student
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Student data is null");
            }

            // Add the student using Business Logic
            var addedStudent = _studentBL.AddStudent(student);

            // Return the added student with 201 Created status
            return Created("", addedStudent);
        }
    }
}
