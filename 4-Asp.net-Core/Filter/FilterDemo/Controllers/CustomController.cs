using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FilterDemo.Filters;

namespace FilterDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomActionFilter("controller")]
    [CustomResourceFilter("controller")]
    [CustomResultFilter("controller")]
    [CustomAuthorizationFilter("controller")]
    public class CustomController : ControllerBase
    {

        [HttpGet("getdetails")]
        [CustomActionFilter("actionmethod")]
        [CustomResourceFilter("actionmethod")]
        [CustomResultFilter("actionmethod")]
        [CustomAuthorizationFilter("actionmethod")]
        public IActionResult Get()
        {
            // Simulate some logic
            return Ok( "Hello from the Custom Controller!" );
        }

        [HttpPost("postdetails")]
        public IActionResult Post([FromBody] string value)
        {
            // Simulate some logic
            if (string.IsNullOrEmpty(value))
            {
                return Ok("Value cannot be null or empty");
            }
            
            return Ok("Data received successfully!" );
        }
    }
}
