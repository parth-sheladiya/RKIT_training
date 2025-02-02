using FinalDemo.BL.Operations;
using FinalDemo.Models;
using FinalDemo.Models.POCO;
using System;
using System.Web.Http;
using FinalDemo.Helpers;

namespace FinalDemo.Controllers
{
    /// <summary>
    /// Controller for handling user authentication and JWT token generation.
    /// </summary>
    [RoutePrefix("api/CLAuthentication")]
    public class CLauthenticationController : ApiController
    {
        // private obj to user
        private BLuser _objBLuser;

        // response
        public Responce _objResponce;

        /// <summary>
        /// ctor 
        /// </summary>
        public CLauthenticationController()
        {
            _objBLuser = new BLuser();
            _objResponce = new Responce();
        }

        /// <summary>
        /// Generates a JWT token for a valid user based on username and password.
        /// </summary>
        /// <param name="userName">User's username</param>
        /// <param name="userPassword">User's password</param>
        /// <returns>Response containing JWT token or error message</returns>
        [HttpGet]
        [Route("generate")]
        public IHttpActionResult GenerateToken(string userName, string userPassword)
        {
            // Retrieve user details based on username and password
            USR01 objUser = _objBLuser.GetUser(userName, userPassword);

            if (objUser != null)
            {
                // Generate JWT token and return success response
                _objResponce.Data = JWTHelper.GenerateJwtToken(objUser.R01F02, objUser.R01F07, objUser.R01F01);
                _objResponce.Message = $"Token generated successfully. Now {objUser.R01F02} is {objUser.R01F07} ";
                _objResponce.IsError = false;
            }
            else
            {
                // Return error response for invalid credentials
                _objResponce.Message = "Invalid credentials. Please check your username or password.";
                _objResponce.IsError = true;
            }

            return Ok(_objResponce);
        }
    }
}