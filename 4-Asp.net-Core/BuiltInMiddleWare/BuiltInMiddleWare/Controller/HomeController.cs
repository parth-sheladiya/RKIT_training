using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuiltInMiddleWare.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // it is for static file middlewsare and they havew to give response 
        // if i was not changes in get request then will error responce 
        // solution change route
        [HttpGet("staticFiles")]
        public IActionResult GetMessageFromStaticFile()
        {
            return Ok(new { Message = "Welcome to ASP.NET Core Web API with Static Files!" });
        }


        // it is for routing middleware 
        [HttpGet("RoutingMessage")]
        public IActionResult GetMessageFromRouting()
        {
            return Ok(new { Message = "welcome to routing middleware" });
        }

        // endpoint with routing middleware example with parameter
        [HttpGet("RoutingMessage/{name}")]
        public IActionResult GetPersonalizedMessage(string name)
        {
            return Ok($"hello {name} Welcome to Routing Middleware Example ");
        }



        // it is for error exception handalling

        [HttpGet("error")]
        public IActionResult ThrowError()
        {
            throw new Exception("error generated");
        }


        // it is for cors middleware
        [HttpGet("cors-message")]
        public IActionResult GetMessFromCors()
        {
            return Ok("hello from cors api ");
        }

        // it is for session middleware 
        // it is must be run in post man
        [HttpPost("add-to-cart/{item}")]
        public IActionResult AddToCart(string item)
        {
            // Get existing cart from session or create a new one
            var cart = HttpContext.Session.GetString("Cart");
            if (cart == null)
            {
                cart = item; // If cart is empty, start with the first item
            }
            else
            {
                cart += "," + item; // Add item to the existing cart
            }

            // Store the updated cart in session
            HttpContext.Session.SetString("Cart", cart);

            return Ok($"Item {item} added to cart.");
        }

        // Get cart items from session
        [HttpGet("view-cart")]
        public IActionResult ViewCart()
        {
            // Retrieve cart from session
            var cart = HttpContext.Session.GetString("Cart");

            if (cart == null)
            {
                return Ok("Your cart is empty.");
            }

            return Ok($"Your cart contains: {cart}");
        }

    }
}
