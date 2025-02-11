using FinalDemo.BL.Operations;
using FinalDemo.Helpers;
using FinalDemo.Models;
using FinalDemo.Models.DTO;
using FinalDemo.Models.ENUM;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalDemo.Controllers
{
    /// <summary>
    /// Controller for  Order-related operations
    /// </summary>
    public class CLorderController : ApiController
    {
        private BLorder _objBLorder;
        private Responce _objResponce;

        /// <summary>
        /// ctor 
        /// </summary>
        public CLorderController()
        {
            _objBLorder = new BLorder();
            _objResponce = new Responce();
        }

        /// <summary>
        /// Retrieves all orders based on status Admin only 
        /// </summary>
        /// <param name="status">Order status filter</param>
        [HttpGet]
        [Route("Orders")]
        [JWTAuthorizationFilter(EnmRoleType.Admin)]
        public IHttpActionResult GetOrders(string status)
        {
            // get orders
            _objResponce.Data = _objBLorder.GetAllOrder(status);
            // response
            return Ok(_objResponce);
        }




        /// <summary>
        /// Retrieves the order profile for the logged-in user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetOrderProfile")]
        [JWTAuthorizationFilter]
        public IHttpActionResult GetOrderProfile()
        {
            // token 
            string token = GetTokenFromRequest();
            // user specific token
            int userID = JWTHelper.GetUserIdFromToken(token);
            // response
            _objResponce = _objBLorder.GetProfile(userID);
            return Ok(_objResponce);
        }

        /// <summary>
        /// Creates a new order (User only)
        /// </summary>
        /// <param name="objOrderDto">Order details DTO</param>
        [HttpPost]
        [Route("createOrder")]
        [JWTAuthorizationFilter(EnmRoleType.User)]
        public IHttpActionResult PostOrders(DTOORD01 objOrderDto)
        {
            // null ornnot
            if (objOrderDto == null)
            {
                return BadRequest("No data available.");
            }

            // add
            _objBLorder.Type = EnumType.A;
            // presave 
            _objBLorder.PreSave(objOrderDto);
            // validation
            _objResponce = _objBLorder.Validation();

          

            _objResponce = _objBLorder.Save();
           
            return Ok(_objResponce);
        }

        /// <summary>
        /// Cancels an order by ID User only
        /// </summary>
        /// <param name="id">Order ID</param>
        [HttpPost]
        [Route("cancelOrder/{id}")]
        [JWTAuthorizationFilter(EnmRoleType.User)]
        public IHttpActionResult CancelOrder(int id)
        {
            // cancel order
            _objResponce = _objBLorder.CancelOrder(id);
            // response
            return Ok(_objResponce);
        }

        /// <summary>
        /// Changes the status of an order (Admin only)
        /// </summary>
        /// <param name="id">Order ID</param>
        /// <param name="newStatus">New order status</param>
        [HttpPut]
        [Route("OrderStatusChanges")]
        [JWTAuthorizationFilter(EnmRoleType.Admin)]
        public IHttpActionResult StatusChanges(int id, string newStatus)
        {
            // id and status
            Responce response = _objBLorder.ChangeStatus(id, newStatus);
            if (response.IsError)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }

        /// <summary>
        /// Retrieves the JWT token from the request header
        /// </summary>
        /// <returns>JWT Token string</returns>
        private string GetTokenFromRequest()
        {
            string token = string.Empty;
            if (Request.Headers.Authorization != null)
            {
                string authorizationHeader = Request.Headers.Authorization.Parameter;
                if (!string.IsNullOrEmpty(authorizationHeader))
                {
                    token = authorizationHeader;
                }
            }

            if (string.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Authorization token is missing.");
            }

            return token;
        }
    }
}
