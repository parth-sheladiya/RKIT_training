using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ActionMethodResponce.Models;

namespace ActionMethodResponce.Controllers
{
    #region Product Controller
    /// <summary>
    /// ProductController is responsible for managing products.
    /// Provides methods for creating, retrieving, updating, and deleting products.
    /// 
    /// HTTP Response Status Codes:
    /// - 200 OK: Successful retrieval or update
    /// - 201 Created: Product successfully created
    /// - 400 Bad Request: Invalid data or missing parameters
    /// - 404 Not Found: Product not found for the given ID
    /// </summary>
    public class ProductController : ApiController
    {
        // Static list to store products. In a real-world application, this would likely be replaced with a database.
        public static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Washing Machine", Category = "Electronics", Price = 96000.63 },
            new Product { Id = 2, Name = "TV", Category = "Electronics", Price = 50000.544 },
            new Product { Id = 3, Name = "Innova", Category = "Car", Price = 50000.45 }
        };

        #region GET Methods

        /// <summary>
        /// Retrieves all products.
        /// 
        /// HTTP Response Status Code: 
        /// - 200 OK: Returns the list of products.
        /// </summary>
        /// <returns>A list of all products.</returns>
        [Route("api/getAllProductData")]
        public List<Product> Get()
        {
            return products; // Return all products
        }

        /// <summary>
        /// Retrieves a product by its unique ID.
        /// 
        /// HTTP Response Status Codes:
        /// - 200 OK: Returns the product if found.
        /// - 404 Not Found: If no product is found for the given ID.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <returns>The product with the specified ID, or a 404 if not found.</returns>
        [Route("api/getDataByid/{id}")]
        public IHttpActionResult GetDataById(int id)
        {
            Product product = products.FirstOrDefault(p => p.Id == id); // Find the product by id
            if (product == null)
            {
                return NotFound(); // If product not found, return 404
            }
            return Ok(product); // Return the product data if found
        }

        #endregion

        #region POST Method

        /// <summary>
        /// Adds a new product to the list.
        /// Generates a new product ID based on the highest existing ID.
        /// 
        /// HTTP Response Status Codes:
        /// - 201 Created: Product is successfully created.
        /// - 400 Bad Request: If no product data is provided.
        /// </summary>
        /// <param name="product">The product to add.</param>
        /// <returns>A list of all products after adding the new product.</returns>
        [Route("api/addProduct")]
        public List<Product> PostProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return null; // Return null if no data is provided
            }

            // Generate new ID based on the highest current ID
            product.Id = products.Max(p => p.Id) + 1;

            // Add the new product to the List
            products.Add(product);

            return products; // Return updated list of products
        }

        #endregion

        #region PUT Method

        /// <summary>
        /// Updates an existing product based on its ID.
        /// 
        /// HTTP Response Status Codes:
        /// - 200 OK: Product is successfully updated.
        /// - 400 Bad Request: If product data is invalid or ID mismatch.
        /// - 404 Not Found: If product is not found by the given ID.
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <param name="product">The product data to update.</param>
        /// <returns>The updated product if successful, or a 404 if the product does not exist.</returns>
        [Route("api/updateProduct/{id}")]
        public IHttpActionResult PutProduct(int id, [FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product data is required for updating.");
            }

            if (product.Id != id)
            {
                return BadRequest("ID cannot be modified."); // Validate that the provided ID matches the URL ID
            }

            var existingProduct = products.FirstOrDefault(p => p.Id == id); // Find the product by id
            if (existingProduct == null)
            {
                return NotFound(); // If product not found, return 404
            }

            // Update the existing product with the new data
            existingProduct.Name = product.Name;
            existingProduct.Category = product.Category;
            existingProduct.Price = product.Price;

            return Ok(existingProduct); // Return the updated product data
        }

        #endregion

        #region DELETE Method

        /// <summary>
        /// Deletes a product by its ID.
        /// 
        /// HTTP Response Status Codes:
        /// - 200 OK: Product successfully deleted.
        /// - 404 Not Found: If product not found by the given ID.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>A status indicating whether the product was successfully deleted.</returns>
        [Route("api/deleteProduct/{id}")]
        public IHttpActionResult DeleteProduct(int id)
        {
            var productToDelete = products.FirstOrDefault(p => p.Id == id); // Find the product to delete by id

            if (productToDelete == null)
            {
                return NotFound(); // If product not found, return 404
            }

            products.Remove(productToDelete); // Remove the product from the list
            return Ok(); // Return a 200 OK response indicating successful deletion
        }

        #endregion
    }
    #endregion
}
