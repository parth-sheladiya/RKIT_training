using System;
using System.Web.Http;
using CachingDemo.Handler;

namespace CachingDemo.Controllers
{
    /// <summary>
    /// Controller responsible for handling product-related operations.
    /// </summary>
    [RoutePrefix("api/products")] 
    public class ProductController : ApiController
    {
        /// <summary>
        /// Retrieves a list of products. Checks cache first, then fetches and caches the data if not found.
        /// </summary>
        /// <returns>An IHttpActionResult containing a list of products.</returns>
        [HttpGet]
        [Route("get")]  
        public IHttpActionResult GetProducts()
        {
            string cacheKey = "productCacheKey";

            // Check if products are already in the cache
            var cachedProducts = CacheHandler.Get(cacheKey);

            if (cachedProducts != null)
            {
                // Return cached data
                return Ok(cachedProducts);
            }

            // If not cached, fetch the product data
            var products = new[]
            {
                new { Id = 1, Name = "Product1", Price = 100 },
                new { Id = 2, Name = "Product2", Price = 200 },
                new { Id = 3, Name = "Product3", Price = 300 }
            };

            // Cache the product data for 15 minutes
            CacheHandler.Set(cacheKey, products, TimeSpan.FromMinutes(15));

            return Ok(products);
        }
    }
}
