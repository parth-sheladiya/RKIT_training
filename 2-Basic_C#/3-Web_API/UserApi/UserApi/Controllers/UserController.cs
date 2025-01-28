using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using MySql.Data.MySqlClient;
using UserApi.Models;

namespace UserApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly string _connstring;


        public UserController()
        {
            _connstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        #region GET Methods

        // GET api/users
        /// <summary>
        /// Retrieves a list of all users.
        /// </summary>
        /// <returns>List of User objects</returns>
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            var users = new List<User>();
            using (var connection = new MySqlConnection(_connstring))
            {
                connection.Open();
                var query = "SELECT * FROM Users";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
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
            return users;
        }

        // GET api/users/5
        /// <summary>
        /// Retrieves a specific user by their UserId.
        /// </summary>
        /// <param name="id">The UserId of the user to retrieve</param>
        /// <returns>The User object if found, or NotFound if not found</returns>
        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            User user = null;
            using (var connection = new MySqlConnection(_connstring))
            {
                connection.Open();
                var query = "SELECT * FROM Users WHERE UserId = @id";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
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
            {
                return NotFound();
            }

            return Ok(user);
        }

        #endregion

        #region POST Methods

        // POST api/users
        /// <summary>
        /// Creates a new user in the database.
        /// </summary>
        /// <param name="user">The user object to create</param>
        /// <returns>HTTP Status code</returns>
        [HttpPost]
        public IHttpActionResult CreateUser(User user)
        {
            using (var connection = new MySqlConnection(_connstring))
            {
                connection.Open();
                var query = "INSERT INTO Users (FirstName, LastName, City, Pincode) VALUES (@FirstName, @LastName, @City, @Pincode)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@City", user.City);
                    cmd.Parameters.AddWithValue("@Pincode", user.Pincode);
                    cmd.ExecuteNonQuery();
                }
            }
            return Ok();
        }

        #endregion

        #region PUT Methods

        // PUT api/users/5
        /// <summary>
        /// Updates the details of an existing user.
        /// </summary>
        /// <param name="id">The UserId of the user to update</param>
        /// <param name="user">The updated user object</param>
        /// <returns>HTTP Status code</returns>
        [HttpPut]
        public IHttpActionResult UpdateUser(int id, User user)
        {
            using (var connection = new MySqlConnection(_connstring))
            {
                connection.Open();
                var query = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, City = @City, Pincode = @Pincode WHERE UserId = @UserId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@City", user.City);
                    cmd.Parameters.AddWithValue("@Pincode", user.Pincode);
                    cmd.Parameters.AddWithValue("@UserId", id);
                    cmd.ExecuteNonQuery();
                }
            }
            return Ok();
        }

        #endregion

        #region DELETE Methods

        // DELETE api/users/5
        /// <summary>
        /// Deletes an existing user by their UserId.
        /// </summary>
        /// <param name="id">The UserId of the user to delete</param>
        /// <returns>HTTP Status code</returns>
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            using (var connection = new MySqlConnection(_connstring))
            {
                connection.Open();
                var query = "DELETE FROM Users WHERE UserId = @UserId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", id);
                    cmd.ExecuteNonQuery();
                }
            }
            return Ok();
        }

        #endregion
    }
}
