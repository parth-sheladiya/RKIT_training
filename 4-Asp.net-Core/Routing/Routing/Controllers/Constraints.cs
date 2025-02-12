using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Routing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Constraints : ControllerBase
    {
        /// <summary>
        /// retrieves all products.
        /// </summary>
        /// <returns></returns>
        
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok("All products retrieved successfully.");
        }

        /// <summary>
        /// creates products
        /// </summary>
        /// <returns>.</returns>
        [HttpPost]
        public IActionResult CreateProduct()
        {
            return Ok("Product created successfully.");
        }

        /// <summary>
        /// updates
        /// </summary>
        /// <param name="id">the id of the product to update.</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public IActionResult UpdateProduct(int id)
        {
            return Ok($"Product with ID {id} updated successfully.");
        }

        /// <summary>
        /// delete  
        /// </summary>
        /// <param name="id">id </param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            return Ok($"Product with ID {id} deleted successfully.");
        }
        
        /// <summary>
        /// Retrieves a product by its name
        /// </summary>
        /// <param name="name"> nam</param>
        /// <returns></returns>
        [HttpGet("name/{name:minlength(3):maxlength(10):alpha}")]
        public IActionResult GetProductByName(string name)
        {
            return Ok($"Product with name {name} retrieved successfully.");
        }
       
        /// <summary>
        /// Retrieves a product by its pric
        /// </summary>
        /// <param name="price"> price</param>
        /// <returns></returns>
        [HttpGet("price/{price:range(10,1000)}")]
        public IActionResult GetProductByPrice(decimal price)
        {
            return Ok($"Product with price {price} retrieved successfully.");
        }
 
   
    }
}
