using FinalDemo.BL.Operations;
using FinalDemo.Helpers;
using FinalDemo.Models;
using FinalDemo.Models.DTO;
using FinalDemo.Models.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalDemo.Controllers
{
    [RoutePrefix("api/CLuser")]

    /// <summary>
    /// user controller
    /// </summary>
    public class CLuserController : ApiController
    {
        /// <summary>
        /// business logic object
        /// </summary>
        private BLuser _objBLuser;

        /// <summary>
        /// responce object
        /// </summary>
        private Responce _objResponce;

        /// <summary>
        /// ctor
        /// </summary>
        public CLuserController()
        {
            _objBLuser = new BLuser();
            _objResponce = new Responce();
        }


        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Users")]
        [JWTAuthorizationFilter(EnmRoleType.Admin)] // Only Admin can access this method
        public IHttpActionResult GetAllUsers()
        {
            // getall method is in businesslogic
            try
            {
                // gett all method to pass 
                _objResponce.Data = _objBLuser.GetAll();
                // responce 
                return Ok(_objResponce);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error occurred: {ex.Message}"));
            }
        }


        /// <summary>
        /// user by id method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("UserById")]
        [JWTAuthorizationFilter(EnmRoleType.Admin)]
        public IHttpActionResult GetUserById(int id)
        {
            // getuserbyid method call and store to response
            _objResponce = _objBLuser.GetUserById(id);

            // response
            return Ok(_objResponce);
        }


        /// <summary>
        /// get user profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserProfile")]
        [JWTAuthorizationFilter]
        public IHttpActionResult GetUserProfile()
        {
            // user specific token
            string token = GetTokenFromRequest();

            // id from token
            int userID = JWTHelper.GetUserIdFromToken(token);

            // method call
            _objResponce = _objBLuser.GetProfile(userID);

            // response
            return Ok(_objResponce);
        }

        /// <summary>
        /// add user 
        /// </summary>
        /// <param name="objDtoUser"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUser")]
        public IHttpActionResult AddUser(DTOUSR01 objDtoUser)
        {
            //
            if (objDtoUser == null)
            {
                _objResponce.IsError = true;
                _objResponce.Message = "User details are required.";
            }

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            // enum type add
            _objBLuser.Type = EnumType.A;

            // presave method 
            _objBLuser.PreSave(objDtoUser);

            // validation method
            _objResponce = _objBLuser.Validation();

            // is any eror
            if (!_objResponce.IsError)
            {
                _objResponce = _objBLuser.Save();
                _objResponce.Message = "User Added Successfully";
            }

            // response
            return Ok(_objResponce);

        }


        /// <summary>
        ///  update user 
        /// </summary>
        /// <param name="objDtoUser"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateUser")]
        [JWTAuthorizationFilter(EnmRoleType.User)]
        public IHttpActionResult UpdateUser(DTOUSR01 objDtoUser)
        {
            if (objDtoUser == null)
            {
                _objResponce.IsError = true;
                _objResponce.Message = "User details are required.";
                return Ok(_objResponce);
            }


            // enum type edit
            _objBLuser.Type = EnumType.E;

            // presave method
            _objBLuser.PreSave(objDtoUser);

            // validation method 
            _objResponce = _objBLuser.Validation();

            // if any error while validation and presave
            if (!_objResponce.IsError)
            {
                _objResponce = _objBLuser.Save();
                _objResponce.Message = "User Updated Successfully";
            }

            // response
            return Ok(_objResponce);
        }


        /// <summary>
        /// delete user 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        [JWTAuthorizationFilter(EnmRoleType.User)]
        public IHttpActionResult DeleteUser(int id)
        {
            // delete user
            _objResponce = _objBLuser.Delete(id);

            // responce to delete
            return Ok(_objResponce);
        }


        /// <summary>
        /// purpose for user spacific details 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        private string GetTokenFromRequest()
        {
            string token = string.Empty;

            // Check if the Authorization header exists
            if (Request.Headers.Authorization != null)
            {
                // The token should be in the format 'Bearer <token>'
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
