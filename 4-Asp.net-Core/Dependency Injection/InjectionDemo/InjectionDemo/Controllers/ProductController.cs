using InjectionDemo.Service;
using InjectionDemo.Service.ServiceHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InjectionDemo.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// interfave 
        /// </summary>
        private readonly IProductService _productService;

        /// <summary>
        /// ctor for service
        /// </summary>
        /// <param name="productService"></param>
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// get product by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var result = _productService.GetProductDetails(id);
            return Ok(result);
        }
    }

}
