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

namespace FinalDemo.Controllers
{
    public class ProductController : ApiController
    {
        #region Connection String
        // Connection string 
        private string connectionString;
        
        #endregion

        public ProductController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }


        #region GET Methods

        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>List of Product objects</returns>
        [HttpGet]
        [JwtFilter]
        public IHttpActionResult Get()
        {
            List<Product> products = new List<Product>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Products", conn);
                // reader reads each row from table row by row
                MySqlDataReader reader = cmd.ExecuteReader();

                // if we have row fetch it as obj & go to next row
                while (reader.Read()) 
                {
                    products.Add(new Product
                    {
                        ProductId = Convert.ToInt32(reader["ProductId"]),
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Category = reader["Category"].ToString(),
                        DateAdded = Convert.ToDateTime(reader["DateAdded"])
                    });
                }
            }

            // Return 404 if no products found
            if (products.Count == 0)
            {
                return NotFound();
            }
           
            return Ok(products);
        }

        /// <summary>
        /// Retrieves a specific product by ID.
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Product object</returns>
        // GET: api/products/3
        [HttpGet]
        [JwtFilter]
        public IHttpActionResult Get(int id)
        {
            Product product = null;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Products WHERE ProductId = @ProductId", conn);
                cmd.Parameters.AddWithValue("@ProductId", id);
                // reader reads each row as obj from table one by one
                MySqlDataReader reader = cmd.ExecuteReader();

                // if we found row 
                if (reader.Read()) 
                {
                    product = new Product
                    {
                        ProductId = Convert.ToInt32(reader["ProductId"]),
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Category = reader["Category"].ToString(),
                        DateAdded = Convert.ToDateTime(reader["DateAdded"])
                    };
                }
            }
            // Return 404 if product not found
            if (product == null)
            {
                return NotFound(); 
            }

            return Ok(product);
        }

        #endregion

        #region POST Method

        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        /// <param name="product">Product object containing the data to add</param>
        /// <returns>HTTP response with a success message</returns>
        [HttpPost]
        [JwtFilter("admin")]
        public IHttpActionResult Post(Product product)
        {
            if (product == null)
            {
                return BadRequest("Invalid product data"); 
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

               
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Products (Name, Description, Price, Category, DateAdded) VALUES (@Name, @Description, @Price, @Category, @DateAdded)", conn);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Category", product.Category);
                cmd.Parameters.AddWithValue("@DateAdded", product.DateAdded);
                cmd.ExecuteNonQuery();
            }
            
            return Ok(product);
        }

        #endregion

        #region PUT Method

        /// <summary>
        /// Updates an existing product's details in the database.
        /// </summary>
        /// <param name="id">Product ID to update</param>
        /// <param name="product">Product object with updated data</param>
        /// <returns>HTTP response with a success message</returns>
        [HttpPut]
        [JwtFilter("admin")]
        public IHttpActionResult Put(int id, Product product)
        {
            if (product == null)
            {
                return BadRequest("Invalid product data"); 
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE Products SET Name = @Name, Description = @Description, Price = @Price, Category = @Category, DateAdded = @DateAdded WHERE ProductId = @ProductId", conn);
                cmd.Parameters.AddWithValue("@ProductId", id);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Category", product.Category);
                cmd.Parameters.AddWithValue("@DateAdded", product.DateAdded);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    return NotFound(); 
                }
            }
           
            return Ok("Product updated successfully!"); 
        }

        #endregion

        #region DELETE Method

        /// <summary>
        /// Deletes a product from the database by ID.
        /// </summary>
        /// <param name="id">Product ID to delete</param>
        /// <returns>HTTP response with a success message</returns>
        [HttpDelete]
        [JwtFilter("admin")]
        public IHttpActionResult Delete(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM Products WHERE ProductId = @ProductId", conn);
                cmd.Parameters.AddWithValue("@ProductId", id);
                int rowsAffected = cmd.ExecuteNonQuery();
                // Return 404 if product not found
                if (rowsAffected == 0)
                {
                    return NotFound(); 
                }
            }
            
            return Ok("Product deleted successfully!"); 
        }

        #endregion
    }
}
