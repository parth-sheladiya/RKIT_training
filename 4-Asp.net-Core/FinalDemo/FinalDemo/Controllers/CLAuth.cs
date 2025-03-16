using FinalDemo.BL.Operations;
using FinalDemo.Models.DTO;
using FinalDemo.Models.POCO;
using FinalDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalDemo.BL.Interface;

namespace FinalDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLAuth : ControllerBase
    {
        private Response _objResponse;
       // private BLAuth _objBLAuth;
        private USR01 _objUSR01;
        private IAuthentication _objBLAuth;

        /// <summary>
        /// ctore
        /// </summary>
        /// <param name="objResponse"></param>
        /// <param name="objUSR01"></param>
        /// <param name="objBLAuth"></param>
        public CLAuth(Response objResponse, IAuthentication objBLAuth)
        {
            _objResponse = objResponse;
            _objBLAuth = objBLAuth;
        }


        /// <summary>
        /// login method for username and password
        /// </summary>
        /// <param name="objDTO"></param>
        /// <returns></returns>
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

            // generate token
            string token = _objBLAuth.GenerateJwtToken(_objUSR01);



            _objResponse.IsError = false;
            _objResponse.Data = new
            {
                Token = token,
                Role = _objUSR01.R01F07.ToString(), 
                
            };
            return Ok(_objResponse);
        }
    }
}
