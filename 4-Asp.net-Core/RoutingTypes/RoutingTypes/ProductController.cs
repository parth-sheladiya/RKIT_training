using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoutingTypes
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A message indicating all products are retrieved successfully.</returns>
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok("All products retrieved successfully.");
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <returns>A message indicating the product is created successfully.</returns>
        [HttpPost]
        public IActionResult CreateProduct()
        {
            return Ok("Product created successfully.");
        }

        /// <summary>
        /// Updates an existing product by id.
        /// </summary>
        /// <param name="id">The id of the product to update.</param>
        /// <returns>A message indicating the product is updated successfully.</returns>
        [HttpPut("{id:int}")]
        public IActionResult UpdateProduct(int id)
        {
            return Ok($"Product with ID {id} updated successfully.");
        }

        /// <summary>
        /// Deletes a product by id.
        /// </summary>
        /// <param name="id">The id of the product to delete.</param>
        /// <returns>A message indicating the product is deleted successfully.</returns>
        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            return Ok($"Product with ID {id} deleted successfully.");
        }

        // Example with MinLength, MaxLength, and Alpha constraint
        /// <summary>
        /// Retrieves a product by its name, ensuring the name has a minimum length of 3 characters, maximum of 10, and is alphabetic.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <returns>A message indicating the product with the specified name is retrieved successfully.</returns>
        [HttpGet("name/{name:minlength(3):maxlength(10):alpha}")]
        public IActionResult GetProductByName(string name)
        {
            return Ok($"Product with name {name} retrieved successfully.");
        }

        // Example with Range constraint
        /// <summary>
        /// Retrieves a product by its price, ensuring the price is within a specific range.
        /// </summary>
        /// <param name="price">The price of the product.</param>
        /// <returns>A message indicating the product with the specified price is retrieved successfully.</returns>
        [HttpGet("price/{price:range(10,1000)}")]
        public IActionResult GetProductByPrice(decimal price)
        {
            return Ok($"Product with price {price} retrieved successfully.");
        }

        // Example with Int constraint
        /// <summary>
        /// Retrieves a product by its ID, ensuring the ID is an integer.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <returns>A message indicating the product with the specified ID is retrieved successfully.</returns>
        [HttpGet("id/{id:int}")]
        public IActionResult GetProductById(int id)
        {
            return Ok($"Product with ID {id} retrieved successfully.");
        }

        // Example with DateTime constraint
        /// <summary>
        /// Retrieves a product based on the date, ensuring the date is in a valid DateTime format.
        /// </summary>
        /// <param name="date">The date of the product.</param>
        /// <returns>A message indicating the product retrieved for the specified date.</returns>
        [HttpGet("date/{date:datetime}")]
        public IActionResult GetProductByDate(DateTime date)
        {
            return Ok($"Product retrieved for the date {date.ToShortDateString()}.");
        }

        // Default route for invalid input or unrecognized routes
        [HttpGet("{*catchall}")]
        public IActionResult DefaultRoute()
        {
            return NotFound("The route you requested is invalid. Please check your input and try again.");
        }
    }
}
