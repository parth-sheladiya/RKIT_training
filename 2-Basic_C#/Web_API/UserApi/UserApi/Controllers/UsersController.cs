using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using MySql.Data.MySqlClient;
using UserApi.Models;

public class UsersController : ApiController
{
    private readonly ApplicationDbContext _context;

    public UsersController()
    {
        _context = new ApplicationDbContext();
    }

    // GET api/users
    [HttpGet]
    public IEnumerable<User> GetUsers()
    {
        var users = new List<User>();
        using (var connection = _context.Connection)
        {
            connection.Open();
            var query = "SELECT * FROM Users";
            using (var cmd = new MySqlCommand(query, (MySqlConnection)connection))
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
    [HttpGet]
    public IHttpActionResult GetUser(int id)
    {
        User user = null;
        using (var connection = _context.Connection)
        {
            connection.Open();
            var query = "SELECT * FROM Users WHERE UserId = @id";
            using (var cmd = new MySqlCommand(query, (MySqlConnection)connection))
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

    // POST api/users
    [HttpPost]
    public IHttpActionResult CreateUser(User user)
    {
        using (var connection = _context.Connection)
        {
            connection.Open();
            var query = "INSERT INTO Users (FirstName, LastName, City, Pincode) VALUES (@FirstName, @LastName, @City, @Pincode)";
            using (var cmd = new MySqlCommand(query, (MySqlConnection)connection))
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

    // PUT api/users/5
    [HttpPut]
    public IHttpActionResult UpdateUser(int id, User user)
    {
        using (var connection = _context.Connection)
        {
            connection.Open();
            var query = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, City = @City, Pincode = @Pincode WHERE UserId = @UserId";
            using (var cmd = new MySqlCommand(query, (MySqlConnection)connection))
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

    // DELETE api/users/5
    [HttpDelete]
    public IHttpActionResult DeleteUser(int id)
    {
        using (var connection = _context.Connection)
        {
            connection.Open();
            var query = "DELETE FROM Users WHERE UserId = @UserId";
            using (var cmd = new MySqlCommand(query, (MySqlConnection)connection))
            {
                cmd.Parameters.AddWithValue("@UserId", id);
                cmd.ExecuteNonQuery();
            }
        }
        return Ok();
    }
}
