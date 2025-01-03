using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using AuthJwt.Models;

namespace AuthJwt.Controllers
{
    /*
    Summary:
    This `AuthController` provides two main functionalities:
    1. **Login and Token Generation**: When a user logs in with valid credentials, a JWT (JSON Web Token) is generated and returned.
    2. **Secure Data Access**: Only authenticated users with a valid JWT token can access secure data (protected by the `[Authorize]` attribute).

    The controller uses a secret key to sign JWT tokens and includes user authentication logic for validation. It also has a route for generating tokens upon login and a route for retrieving secure data if the user is authenticated.
    */

    public class AuthController : ApiController
    {
        // Secret key used for signing JWT tokens (ensure this is kept safe and not hardcoded in production)
        private const string SecretKey = "YourSecretKeyForJWTYourSecretKeyForJWT";

        // POST Method for Login and Token Generation
        [HttpPost]
        [Route("api/auth/login")]
        public IHttpActionResult Login([FromBody] LoginModel login)
        {
            // Check if the provided login details are valid
            if (IsValidUser(login))
            {
                // Generate and return JWT token if the user is valid
                var token = GenerateJWTToken(login.Username);
                return Ok(new { Token = token }); // Return the generated token in the response
            }

            // If login is invalid, return Unauthorized status
            return Unauthorized();
        }

        // GET Method to fetch some secure data (only for authorized users)
        [HttpGet]
        [Route("api/auth/data")]
        [Authorize] // This attribute ensures that only authenticated users can access this method
        public IHttpActionResult GetSecureData()
        {
            // Return a message along with the authenticated user's username
            return Ok(new
            {
                message = "This is a secure resource.",
                user = User.Identity.Name // Extract the username from the authenticated user’s identity
            });
        }

        // Validate the user (example logic, replace with actual database authentication logic)
        private bool IsValidUser(LoginModel login)
        {
            // Basic validation (username and password matching - use secure method in production)
            return login.Username == "testuser" && login.Password == "password";
        }

        // Generate a JWT Token for authenticated users
        private string GenerateJWTToken(string username)
        {
            // Create the symmetric security key from the secret key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

            // Define signing credentials using the security key and HMAC-SHA256 algorithm
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Create claims for the user, including their username
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username) // Add the username as a claim
            };

            // Create the JWT token with issuer, audience, claims, and expiration time (1 hour)
            var token = new JwtSecurityToken(
                issuer: "YourIssuer",  // Define the expected issuer of the token
                audience: "YourAudience",  // Define the expected audience of the token
                claims: claims,  // Add the claims to the token
                expires: DateTime.Now.AddMinutes(60),  // Set the token expiration time (1 hour)
                signingCredentials: credentials  // Use the signing credentials for the token signature
            );

            // Return the token as a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
