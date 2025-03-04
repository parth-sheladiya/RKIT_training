using FinalDemo.BL.Interface;
using FinalDemo.BL.Operations;
using FinalDemo.Filters;
using FinalDemo.Models;
using FinalDemo.Models.DTO;
using FinalDemo.Models.ENUM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Web;

namespace FinalDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLORD01 : ControllerBase
    {
        private Response _objResponse;
        // private BLOrder _objBLOrder;
        //private BLAuth _objBLAuth;
        private IBLORD _objBLOrder;
        private IAuthentication _objBLAuth;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="objResponse"></param>
        /// <param name="objBLOrder"></param>
        public CLORD01(Response objResponse , IBLORD objBLOrder , IAuthentication objBLAuth )
        {
            _objResponse = objResponse;
            _objBLOrder = objBLOrder;
            _objBLAuth = objBLAuth;
        }

        
        /// <summary>
        /// get all orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAllOrders")]
        [AuthFilter("Admin")]
        public IActionResult GetAllOrder()
        {

            _objResponse = _objBLOrder.GetAllOrders();
            return Ok(_objResponse);
        }

        /// <summary>
        /// get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getProductById")]
        [AuthFilter("Admin")]
        public IActionResult GetOrderByid(int id)
        {

            _objResponse = _objBLOrder.GetOrderByid(id);
            return Ok(_objResponse);
        }

        /// <summary>
        /// create order
        /// </summary>
        /// <param name="objDtoORD01"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateOrder")]
        [AuthFilter("User")]
        public IActionResult AddOrder(DTOORD01 objDtoORD01)
        {
           

            string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            int loggedInUserId = _objBLAuth.GetLoggedInUserId(token);

            if (objDtoORD01.R01F01 != loggedInUserId)
            {
                _objResponse.IsError = true;
                _objResponse.Message = "Unauthorized access. You cannot place an order for another user.";
                return Unauthorized(_objResponse);
            }

            // type A
            _objBLOrder.typeOfOperation = EnumType.A;
            _objBLOrder.PreSave(objDtoORD01);
            _objResponse = _objBLOrder.Validation();

            if (!_objResponse.IsError)
            {
                _objResponse = _objBLOrder.Save();
            }

            return Ok(_objResponse);
        }

        /// <summary>
        /// cancel ordewr
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("cancelOrder/{id}")]
        [AuthFilter("User")]
        public IActionResult CancelOrder(int id)
        {
            // validate token
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            int loggedInUserId = _objBLAuth.GetLoggedInUserId(token);
            // cancel order
            _objResponse = _objBLOrder.CancelOrder(id, loggedInUserId);
            // response
            return Ok(_objResponse);
        }


        [HttpGet]
        [Route("/GetMyorders")]
        [AuthFilter("User")]
        public IActionResult GetMyOrders()
        {
            // validate token
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            int loggedInUserId = _objBLAuth.GetLoggedInUserId(token);

            // get order bl
            _objResponse = _objBLOrder.GetMyOrder(loggedInUserId);
            return Ok(_objResponse);
        }

        /// <summary>
        /// Changes the status of an order (Admin only)
        /// </summary>
        /// <param name="id">Order ID</param>
        /// <param name="newStatus">New order status</param>
        [HttpPut]
        [Route("OrderStatusChanges")]
        [AuthFilter("Admin")]
        public IActionResult StatusChanges(int id, string newStatus)
        {
            // id and status
            _objResponse = _objBLOrder.ChangeStatus(id, newStatus);
            if (_objResponse.IsError)
            {
                return BadRequest(_objResponse.Message);
            }
            return Ok(_objResponse.Message);
        }
    }
}
