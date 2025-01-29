using JwtToken.Models;
using JwtToken.TokenHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JwtToken.Controllers
{
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
            if (login.Username == "admin" && login.Password == "password")
            {
                string token = JwtHandler.GenerateJwtToken(login.Username);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}
