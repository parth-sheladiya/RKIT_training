using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using FinalDemo.Models;
using MySql.Data.MySqlClient;
using FinalDemo.Handler;
using System.Configuration;

namespace FinalDemo.Controllers
{
    /// <summary>
    /// Controller for handling authentication-related actions like login and JWT token generation.
    /// </summary>
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private readonly string connectionString;

        public AuthController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        /// <summary>
        /// Logs in the user by validating their credentials and generates a JWT token for authorized users.
        /// If credentials are valid, a token is returned; otherwise, the user is unauthorized.
        /// </summary>
        [HttpPost]  
        [Route("login")]
        public IHttpActionResult Login([FromBody] Auth objauth)
        {
            if (objauth == null || string.IsNullOrEmpty(objauth.username) || string.IsNullOrEmpty(objauth.password))
            {
                return BadRequest("Username and Password are required.");
            }

            User objuser = GetUser(objauth);

            if (objuser == null)
            {
                return BadRequest("Invalid Username or Password");
            }

           
            string token = JwtHandler.GenerateJwtToken(objuser.username, objuser.role);

            return Ok(new { token });
        }

        /// <summary>
        /// Fetches user from database based on username and password.
        /// </summary>
        private User GetUser(Auth objauthuser)
        {
            User user = null;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM user WHERE username = @UserName AND password = @Password";

                using (var command = new MySqlCommand(query, conn))
                {
                    
                    command.Parameters.AddWithValue("@UserName", objauthuser.username);
                    command.Parameters.AddWithValue("@Password", objauthuser.password);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                username = reader["username"].ToString(),
                                password = reader["password"].ToString(),
                                role = reader["role"].ToString()
                            };
                        }
                    }
                }
            }
            return user;
        }

        
    }
}
