using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using UserJwtToken.Helpers;
using UserJWTtoken.Models;

namespace UserJwtToken.Controllers
{
    public class UserController : ApiController
    {
        private static List<User> users = new List<User>();

        [HttpPost]
        [Route("api/v1/register")]
        public IHttpActionResult Register(User user)
        {
            if (users.Any(u => u.Username == user.Username))
                return BadRequest("Username already exists.");

            users.Add(user);
            return Ok("User registered successfully!");
        }

        [HttpPost]
        [Route("api/v1/login")]
        public IHttpActionResult Login(User user)
        {
            var existingUser = users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (existingUser == null)
                return Unauthorized();

            var token = JwtHelper.GenerateToken(user.Username);
            return Ok(new { Token = token });
        }
    }
}