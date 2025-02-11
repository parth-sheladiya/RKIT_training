using FinalDemo.BL.Operations;
using FinalDemo.Models.DTO;
using FinalDemo.Models.POCO;
using FinalDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLAuth : ControllerBase
    {
        private Response _objResponse;
        private BLAuth _objBLAuth;
        private USR01 _objUSR01;


        public CLAuth(Response objResponse, USR01 objUSR01, BLAuth objBLAuth)
        {
            _objResponse = objResponse;
            _objUSR01 = objUSR01;
            _objBLAuth = objBLAuth;
        }

        [HttpPost("Login")]

        public IActionResult Login(DTOAUTH objDTO)
        {
            _objUSR01 = _objBLAuth.AuthCred(objDTO);

            if (_objUSR01 == null)
            {
                _objResponse.IsError = true;
                _objResponse.Message = "invalid";
                return BadRequest();
            }

            string token = _objBLAuth.GenerateJwtToken(_objUSR01);



            _objResponse.IsError = false;
            _objResponse.Data = token;
            return Ok(_objResponse);
        }
    }
}
