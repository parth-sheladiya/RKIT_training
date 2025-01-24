using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoutingTypes
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// retrieves all products.
        /// </summary>
        /// <returns>a message indicating all products are retrieved successfully.</returns>
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok("All products retrieved successfully.");
        }

        /// <summary>
        /// creates a new product.
        /// </summary>
        /// <returns>a message indicating the product is created successfully.</returns>
        [HttpPost]
        public IActionResult CreateProduct()
        {
            return Ok("Product created successfully.");
        }

        /// <summary>
        /// updates an existing product by id.
        /// </summary>
        /// <param name="id">the id of the product to update.</param>
        /// <returns>a message indicating the product is updated successfully.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id)
        {
            return Ok($"Product with ID {id} updated successfully.");
        }

        /// <summary>
        /// deletes a product by id.
        /// </summary>
        /// <param name="id">the id of the product to delete.</param>
        /// <returns>a message indicating the product is deleted successfully.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            return Ok($"Product with ID {id} deleted successfully.");
        }
    }
}
