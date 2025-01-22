using FinalDemo.BL.Operations;
using FinalDemo.Models;
using FinalDemo.Models.DTO;
using FinalDemo.Models.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace FinalDemo.Controllers
{
    public class CLorderController : ApiController
    {
       private BLorder _objBLorder;
       private Responce _objResponce;

        public CLorderController()
        {
            _objBLorder = new BLorder();
            _objResponce = new Responce();
        }

        [HttpGet]
        [Route("Orders")]
        [JWTAuthorizationFilter(EnmRoleType.Admin)]
        public IHttpActionResult GetOrders(string status)
        {
            try
            {
                _objResponce.Data = _objBLorder.GetAllOrder(status);
                return Ok(_objResponce);
            }
            catch(Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = $"error for getallorders {ex.Message}";
            }

            return Ok(_objResponce);
        }


        [HttpPost]
        [Route("createOrder")]
        [JWTAuthorizationFilter(EnmRoleType.User)]
        public IHttpActionResult PostOrders(OrderDto objOrderDto)
        {
            if (objOrderDto == null)
            {
                return BadRequest("No data available.");
            }

            _objBLorder.Type = EnumType.A; // Set type to Add
            _objBLorder.PreSave(objOrderDto); // Pre-save logic

            // Validate the order
            _objResponce = _objBLorder.Validation();
            if (_objResponce.IsError)
            {
                return Content(HttpStatusCode.BadRequest, _objResponce);
            }

            // Save the order
            _objResponce = _objBLorder.Save();
            if (_objResponce.IsError)
            {
                return Content(HttpStatusCode.InternalServerError, _objResponce);
            }

            return Ok(_objResponce);
        }


        [HttpPost]
        [Route("cancelOrder/{id}")]
        [JWTAuthorizationFilter(EnmRoleType.User)]
        public IHttpActionResult CancelOrder(int id)
        {
            try
            {
                // Call the CancelOrder method in BLorder
                _objResponce = _objBLorder.CancelOrder(id);

                // Return response to the client
                return Ok(_objResponce);
            }
            catch (Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = $"Error while cancelling order: {ex.Message}";
                return Ok(_objResponce);
            }
        }

        [HttpPut]
        [Route("OrderStatusChanges")]
        [JWTAuthorizationFilter(EnmRoleType.Admin)]
        public IHttpActionResult StatusChanges(int id, string newStatus)
        {
            var response = _objBLorder.ChangeStatus(id, newStatus);

            if (response.IsError)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Message);
        }

    }
}
