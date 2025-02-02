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
    /// Controller for handling Order-related operations
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
        /// Retrieves all orders based on status (Admin only)
        /// </summary>
        /// <param name="status">Order status filter</param>
        [HttpGet]
        [Route("Orders")]
        [JWTAuthorizationFilter(EnmRoleType.Admin)]
        public IHttpActionResult GetOrders(string status)
        {
            try
            {
                // get all oreder method call
                _objResponce.Data = _objBLorder.GetAllOrder(status);

                // response
                return Ok(_objResponce);
            }
            catch (Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = $"Error while fetching orders: {ex.Message}";
            }

            // response
            return Ok(_objResponce);
        }

        /// <summary>
        /// Retrieves the order profile for the logged-in user
        /// </summary>
        [HttpGet]
        [Route("GetOrderProfile")]
        [JWTAuthorizationFilter]
        public IHttpActionResult GetOrderProfile()
        {
            // token for specific data
            // Extract token from request
            string token = GetTokenFromRequest();

            // Get user ID from token
            int userID = JWTHelper.GetUserIdFromToken(token); 

            // get profile method call
            _objResponce = _objBLorder.GetProfile(userID);

            // response
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
            if (objOrderDto == null)
            {
                return BadRequest("No data available.");
            }

            // Set type to Add
            _objBLorder.Type = EnumType.A;

            // Pre-save logic
            _objBLorder.PreSave(objOrderDto); 

            // validation method call
            _objResponce = _objBLorder.Validation();

            // if any error
            if (_objResponce.IsError)
            {
                return Content(HttpStatusCode.BadRequest, _objResponce);
            }

            // Save order
            _objResponce = _objBLorder.Save();
            if (_objResponce.IsError)
            {
                return Content(HttpStatusCode.InternalServerError, _objResponce);
            }

            // response
            return Ok(_objResponce);
        }

        /// <summary>
        /// Cancels an order by ID (User only)
        /// </summary>
        /// <param name="id">Order ID</param>
        [HttpPost]
        [Route("cancelOrder/{id}")]
        [JWTAuthorizationFilter(EnmRoleType.User)]
        public IHttpActionResult CancelOrder(int id)
        {
            try
            {
                // Cancel order
                _objResponce = _objBLorder.CancelOrder(id);


                // response
                return Ok(_objResponce);
            }
            catch (Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = $"Error while cancelling order: {ex.Message}";

                // response
                return Ok(_objResponce);
            }
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

            // status change 
            var response = _objBLorder.ChangeStatus(id, newStatus);
            if (response.IsError)
            {
                // response
                return BadRequest(response.Message);
            }

            // response
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
