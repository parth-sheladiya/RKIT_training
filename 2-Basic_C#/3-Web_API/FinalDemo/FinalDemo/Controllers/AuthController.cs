using System;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using FinalDemo.Models;
using FinalDemo.Handler;

namespace FinalDemo.Controllers
{
    /// <summary>
    /// Controller for handling authentication-related actions like login and JWT token generation.
    /// </summary>
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        /// <summary>
        /// Logs in the user by validating their credentials and generates a JWT token for authorized users.
        /// If credentials are valid, a token is returned; otherwise, the user is unauthorized.
        /// </summary>
        /// <param name="login">The login model containing the username and password.</param>
        /// <returns>An IHttpActionResult containing the generated JWT token or an Unauthorized response.</returns>
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] User login)
        {
            // Validate user credentials (this is just a simple example)
            if (login.UserName == "admin" && login.Password == "password")
            {
                var token = JwtHandler.GenerateJwtToken(login.UserName, "Admin"); // Admin role
                return Ok(new { token });
            }
            else if (login.UserName == "user" && login.Password == "password")
            {
                var token = JwtHandler.GenerateJwtToken(login.UserName, "User"); // User role
                return Ok(new { token });
            }
            

            return BadRequest("Invalid Username or Password");
        }
    }
}