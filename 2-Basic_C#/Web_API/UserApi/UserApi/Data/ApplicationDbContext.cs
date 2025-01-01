using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

public class ApplicationDbContext
{
    private readonly string _connectionString;

    public ApplicationDbContext()
    {
        _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    }

    public IDbConnection Connection => new MySqlConnection(_connectionString);
}
