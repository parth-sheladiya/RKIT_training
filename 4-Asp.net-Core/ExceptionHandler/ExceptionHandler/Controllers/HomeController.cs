using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandler.Controllers
{
    /// <summary>
    /// HomeController for testing exception handling.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// It is used to test error handling
        /// </summary>
        /// <returns>Throws an exception.</returns>
        /// <exception cref="Exception">Always throws an exception with a test message.</exception>
        [HttpGet("error")]
        public IActionResult GenerateError()
        {
            // Forcefully throwing an exception to test Developer Exception Page
            throw new Exception("hello from error");
        }

        /// <summary>
        ///no error
        /// </summary>
        /// <returns> 200 OK response </returns>
        [HttpGet("hello")]
        public IActionResult Get()
        {
            return Ok("Hello, ASP.NET Core!");
        }
    }
}
