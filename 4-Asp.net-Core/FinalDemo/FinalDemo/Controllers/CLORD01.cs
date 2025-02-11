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
        private BLOrder _objBLOrder;
        private BLAuth _objBLAuth;

        public CLORD01(Response objResponse , BLOrder objBLOrder )
        {
            _objResponse = objResponse;
            _objBLOrder = objBLOrder;
        }

        

        [HttpGet]
        [Route("getAllOrders")]
        [AuthFilter("Admin")]
        public IActionResult GetAllOrder()
        {

            _objResponse = _objBLOrder.GetAll();
            return Ok(_objResponse);
        }

        [HttpGet]
        [Route("getProductById")]
        [AuthFilter("Admin")]
        public IActionResult GetOrderByid(int id)
        {

            _objResponse = _objBLOrder.GetByid(id);
            return Ok(_objResponse);
        }


        [HttpPost]
        [Route("CreateOrder")]
        [AuthFilter("User")]
        public IActionResult AddOrder(DTOORD01 objDtoORD01)
        {
           
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            int loggedInUserId = _objBLAuth.GetLoggedInUserId(token);

            

            _objBLOrder.typeOfOperation = EnumType.A;
            _objBLOrder.PreSave(objDtoORD01);
            _objResponse = _objBLOrder.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLOrder.Save();
            }
            return Ok(_objResponse);
        }

        [HttpPost]
        [Route("cancelOrder/{id}")]
        [AuthFilter("User")]
        public IActionResult CancelOrder(int id)
        {
            // cancel order
            _objResponse = _objBLOrder.CancelOrder(id);
            // response
            return Ok(_objResponse);
        }

        
    }
}
