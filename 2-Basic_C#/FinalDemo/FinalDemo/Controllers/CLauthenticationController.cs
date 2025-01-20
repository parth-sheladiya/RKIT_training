using FinalDemo.BL.Operations;
using FinalDemo.Models;
using FinalDemo.Models.POCO;
using System;
using System.Web.Http;
using FinalDemo.Helpers;

namespace FinalDemo.Controllers
{
    [RoutePrefix("api/CLAuthentication")]
    public class CLauthenticationController : ApiController
    {
        private BLuser _objBLuser;
      

        public Responce _objResponce;

        public CLauthenticationController()
        {
            _objBLuser = new BLuser();
           
            _objResponce = new Responce();
        }



        [HttpGet]
        [Route("generate")]
        public IHttpActionResult GenerateToken(string userName, string userPassword)
        {
            User objUser = _objBLuser.GetUser(userName, userPassword);
            
            if (objUser != null)
            {
                _objResponce.Data = JWTHelper.GenerateJwtToken(objUser.userName, objUser.RoleType);
                _objResponce.Message = "Token generated successfully.";
                _objResponce.IsError = false;
            }
            else
            {
                _objResponce.Message = "Invalid credentials. Please check your username or password.";
                _objResponce.IsError = true;
            }

            return Ok(_objResponce);
        }
    }
}
