using FinalDemo.Filter;
using FinalDemo.Handler;
using FinalDemo.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace FinalDemo.Controllers
{
    public class UserController : ApiController
    {
        private string connectionString;

        public UserController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>List of Product objects</returns>
        [HttpGet]
        
        public IHttpActionResult Get()
        {
         
            List<User> users = new List<User>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM User", conn);
                // reader reads each row from table row by row
                MySqlDataReader reader = cmd.ExecuteReader();

                // if we have row fetch it as obj & go to next row
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        username = reader["username"].ToString(),
                        password = reader["password"].ToString(),
                        role = reader["role"].ToString(),
                    });
                }
            }

            // Return 404 if no products found
            if (users.Count == 0)
            {
                return NotFound();
            }
            
            return Ok(users);
        }


        #region POST Method

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="user">user object containing the data to add</param>
        /// <returns>HTTP response with a success message</returns>
        [HttpPost]
       
        public IHttpActionResult Post(User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid product data");
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

            
                MySqlCommand cmd = new MySqlCommand("INSERT INTO User (Id, username, password, role) VALUES (@Id, @username, @password, @role)", conn);
                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@role", user.role);
       
                cmd.ExecuteNonQuery();
            }

            return Ok("user created success fully");
        }

        #endregion

            
    }
}
