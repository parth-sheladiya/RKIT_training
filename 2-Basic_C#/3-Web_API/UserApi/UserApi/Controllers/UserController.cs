using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using MySql.Data.MySqlClient;
using UserApi.Models;

namespace UserApi.Controllers
{
    [RoutePrefix("api/users")] // 🔹 Route Prefix added
    public class UserController : ApiController
    {
        private readonly string _connstring;

        public UserController()
        {
            _connstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        #region GET Methods

        // GET api/users
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetUsers()
        {
            try
            {
                List<User> users = new List<User>();
                using (MySqlConnection connection = new MySqlConnection(_connstring))
                {
                    connection.Open();
                    string query = "SELECT * FROM Users";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                users.Add(new User
                                {
                                    UserId = reader.GetInt32("UserId"),
                                    FirstName = reader.GetString("FirstName"),
                                    LastName = reader.GetString("LastName"),
                                    City = reader.GetString("City"),
                                    Pincode = reader.GetString("Pincode")
                                });
                            }
                        }
                    }
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET api/users/5
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetUser(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid User ID");

            try
            {
                User user = null;
                using (MySqlConnection connection = new MySqlConnection(_connstring))
                {
                    connection.Open();
                    string query = "SELECT * FROM Users WHERE UserId = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new User
                                {
                                    UserId = reader.GetInt32("UserId"),
                                    FirstName = reader.GetString("FirstName"),
                                    LastName = reader.GetString("LastName"),
                                    City = reader.GetString("City"),
                                    Pincode = reader.GetString("Pincode")
                                };
                            }
                        }
                    }
                }

                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        #endregion

        #region POST Methods

        // POST api/users
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateUser(User user)
        {
            if (user == null)
                return BadRequest("User data cannot be null");

            if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName) ||
                string.IsNullOrWhiteSpace(user.City) || string.IsNullOrWhiteSpace(user.Pincode))
                return BadRequest("All fields are required");

            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connstring))
                {
                    connection.Open();
                    string query = "INSERT INTO Users (FirstName, LastName, City, Pincode) VALUES (@FirstName, @LastName, @City, @Pincode)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", user.LastName);
                        cmd.Parameters.AddWithValue("@City", user.City);
                        cmd.Parameters.AddWithValue("@Pincode", user.Pincode);
                        cmd.ExecuteNonQuery();
                    }
                }
                return Ok("User created successfully");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        #endregion

        #region PUT Methods

        // PUT api/users/5
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateUser(int id, User user)
        {
            if (id <= 0)
                return BadRequest("Invalid User ID");

            if (user == null)
                return BadRequest("User data cannot be null");

            if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName) ||
                string.IsNullOrWhiteSpace(user.City) || string.IsNullOrWhiteSpace(user.Pincode))
                return BadRequest("All fields are required");

            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connstring))
                {
                    connection.Open();
                    string query = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, City = @City, Pincode = @Pincode WHERE UserId = @UserId";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", user.LastName);
                        cmd.Parameters.AddWithValue("@City", user.City);
                        cmd.Parameters.AddWithValue("@Pincode", user.Pincode);
                        cmd.Parameters.AddWithValue("@UserId", id);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                            return NotFound();
                    }
                }
                return Ok("User updated successfully");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        #endregion

        #region DELETE Methods

        // DELETE api/users/5
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteUser(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid User ID");

            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connstring))
                {
                    connection.Open();
                    string query = "DELETE FROM Users WHERE UserId = @UserId";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserId", id);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                            return NotFound();
                    }
                }
                return Ok("User deleted successfully");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        #endregion
    }
}
