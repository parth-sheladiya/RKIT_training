using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using FinalDemo.Models;  // Make sure your Product and User models are in the correct namespace
using Microsoft.IdentityModel.Tokens;

namespace FinalDemo.Controllers
{
    public class AuthController : ApiController
    {
        #region Login Endpoint

        /// <summary>
        /// Authenticates the user and generates a JWT token.
        /// </summary>
        /// <param name="user">User details including username and password.</param>
        /// <returns>An action result containing the JWT token if authentication is successful.</returns>
        [HttpPost]
        [Route("api/auth/login")]
        public IHttpActionResult Login([FromBody] User user)
        {
            // Validate user credentials (this is hardcoded for the demo; replace with actual validation logic)
            if (user.UserName != "root" || user.Password != "admin@123")
                return Unauthorized(); // Invalid credentials

            // Generate JWT token
            var token = GenerateJwtToken(user.UserName);

            // Return token in response
            return Ok(new { Token = token });
        }

        #endregion

        #region JWT Token Generation

        /// <summary>
        /// Generates a JWT token for the authenticated user.
        /// </summary>
        /// <param name="username">The username of the authenticated user.</param>
        /// <returns>A JWT token as a string.</returns>
        private string GenerateJwtToken(string username)
        {
            // Define the secret key for signing the token (ensure it is stored securely)
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Your-32-Character-Secret-Key1234"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Define claims for the JWT (here we are just using the username, but you can add more claims)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };

            // Create the JWT token
            var token = new JwtSecurityToken(
                issuer: "YourIssuer",  // Issuer of the token
                audience: "YourAudience",  // Audience for whom the token is intended
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),  // Expiry time for the token
                signingCredentials: credentials  // The signing credentials (security key)
            );

            // Return the serialized JWT token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion

        #region Secure Data Endpoint

        /// <summary>
        /// Retrieves secure data for an authenticated user.
        /// </summary>
        /// <returns>An action result containing a secure message.</returns>
        [HttpGet]
        [Authorize]  // This endpoint is protected and requires a valid JWT token
        [Route("api/secure-data")]
        public IHttpActionResult GetSecureData()
        {
            // Get the username from the authenticated user's identity (from the JWT token)
            var username = User.Identity.Name;

            // Return a secure message containing the username
            return Ok(new { Message = $"Hello {username}, this is a secure message!" });
        }

        #endregion

        #region Product Management Endpoints

        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>List of products</returns>
        [HttpGet]
        // Protects this endpoint, requiring the user to be authenticated
        [Route("api/products")]
        public IHttpActionResult GetProducts()
        {
            // Dummy data for demonstration (replace with actual database logic)
            var products = new List<Product>
            {
                new Product { ProductId = 1, Name = "Product 1", Description = "Description of Product 1", Price = 100.50m, Category = "Electronics", DateAdded = DateTime.Now },
                new Product { ProductId = 2, Name = "Product 2", Description = "Description of Product 2", Price = 200.75m, Category = "Furniture", DateAdded = DateTime.Now }
            };

            return Ok(products);  // Return the list of products
        }

        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        /// <param name="product">Product details</param>
        /// <returns>Action result with success message</returns>
        [HttpPost]
        [Authorize] // Protects this endpoint, requiring the user to be authenticated
        [Route("api/products")]
        public IHttpActionResult AddProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest("Invalid product data");

            // Simulate adding the product to the database
            // In a real-world scenario, save the product to your database here

            return Ok(new { Message = "Product added successfully", Product = product });
        }

        /// <summary>
        /// Updates an existing product in the database.
        /// </summary>
        /// <param name="productId">Product ID</param>
        /// <param name="product">Updated product details</param>
        /// <returns>Action result with success message</returns>
        [HttpPut]
        [Authorize] // Protects this endpoint, requiring the user to be authenticated
        [Route("api/products/{productId}")]
        public IHttpActionResult UpdateProduct(int productId, [FromBody] Product product)
        {
            if (product == null)
                return BadRequest("Invalid product data");

            // Simulate updating the product in the database
            // In a real-world scenario, you would update the product in the database by productId

            return Ok(new { Message = "Product updated successfully", Product = product });
        }

        /// <summary>
        /// Deletes a product by ID.
        /// </summary>
        /// <param name="productId">Product ID</param>
        /// <returns>Action result with success message</returns>
        [HttpDelete]
        [Authorize] // Protects this endpoint, requiring the user to be authenticated
        [Route("api/products/{productId}")]
        public IHttpActionResult DeleteProduct(int productId)
        {
            // Simulate deleting the product by ID
            // In a real-world scenario, delete the product from your database by productId

            return Ok(new { Message = "Product deleted successfully", ProductId = productId });
        }

        #endregion
    }
}
