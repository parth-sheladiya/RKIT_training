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
        public IHttpActionResult GetOrders()
        {
            try
            {
                _objResponce.Data = _objBLorder.GetAllOrder();
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
            if(objOrderDto == null)
            {
                return BadRequest("no data available");
            }
            _objBLorder.Type = EnumType.A;
            _objBLorder.PreSave(objOrderDto);
            _objResponce = _objBLorder.Validation();
            if (!_objResponce.IsError)
            {
                _objResponce = _objBLorder.Save();
                _objResponce.Message = "order Added Successfully";
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

    }
}
