using InjectionDemo.Service.ServiceHandler;
using InjectionDemo.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InjectionDemo.Controllers
{
    /// <summary>
    /// manage order service
    /// </summary>
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        /// <summary>
        /// Private field to hold the instance of IOrderService injected through constructor
        /// </summary>
        private readonly IOrderService _orderService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderService"></param>
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// order service
        /// </summary>
        /// <param name="productId">id</param>
        /// <param name="quantity">quantity</param>
        /// <returns></returns>
        [HttpPost("place")]
        public IActionResult PlaceOrder(int productId, int quantity)
        {
            string result = _orderService.PlaceOrder(productId, quantity);
            return Ok(result);
        }
    }

}
