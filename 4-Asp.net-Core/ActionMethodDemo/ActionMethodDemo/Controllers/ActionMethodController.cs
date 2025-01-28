using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActionMethodDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionMethod : ControllerBase
    {
        #region Success Responses

        /// <summary>
        /// Returns a success message with a 200 OK status.
        /// </summary>
        [HttpGet("success")]
        public IActionResult Success()
        {
            return Ok("success message"); // 200 OK without data
        }

        /// <summary>
        /// Returns success with JSON data and a 200 OK status.
        /// </summary>
        [HttpGet("success-with-data")]
        public IActionResult SuccessWithData()
        {
            var data = new { Name = "parth", Age = 22 };
            return Ok(data); // 200 OK with JSON data
        }

        #endregion

        #region Create Resource

        /// <summary>
        /// Creates a student resource. Returns 400 Bad Request if the name is not provided.
        /// </summary>
        /// <param name="name">Name of the student</param>
        [HttpPost("create")]
        public IActionResult Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name is required."); // 400 Bad Request
            }
            return Ok($"Student {name} created!"); // 200 OK
        }

        #endregion

        #region Retrieve Resource

        /// <summary>
        /// Retrieves a student by ID. Returns 404 Not Found if the student does not exist.
        /// </summary>
        /// <param name="id">ID of the student</param>
        [HttpGet("student/{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id != 1) // Suppose student with ID 1 exists
            {
                return NotFound("Student not found."); // 404 Not Found
            }
            return Ok($"Student {id} found!"); // 200 OK
        }

        #endregion

        #region Authorization and Permission

        /// <summary>
        /// Simulates an authorization check. Returns 401 Unauthorized if the user is not authorized.
        /// </summary>
        [HttpGet("secure-data")]
        public IActionResult SecureData()
        {
            bool isAuthorized = false; // Simulate authorization check
            if (!isAuthorized)
            {
                return Unauthorized(); // 401 Unauthorized
            }
            return Ok("Secure data accessed."); // 200 OK
        }

        /// <summary>
        /// Simulates a permission check. Returns 403 Forbidden if the user does not have permission.
        /// </summary>
        [HttpGet("restricted-data")]
        public IActionResult RestrictedData()
        {
            bool hasPermission = false; // Simulate permission check
            if (!hasPermission)
            {
                return Forbid(); // 403 Forbidden
            }
            return Ok("Access granted."); // 200 OK
        }

        #endregion

        #region Custom Responses

        /// <summary>
        /// Returns custom HTML content with a text/html content type.
        /// </summary>
        [HttpGet("custom-content")]
        public IActionResult CustomContent()
        {
            return Content("<h1>Welcome to ASP.NET Core Web API</h1>", "text/html");
        }

        /// <summary>
        /// Redirects the user to Google's website.
        /// </summary>
        [HttpGet("redirect-google")]
        public IActionResult RedirectToGoogle()
        {
            return Redirect("https://www.google.com");
        }

        #endregion
    }
}
