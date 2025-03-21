﻿using FinalDemo.BL.Operations;
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

    public class CLuserController : ApiController
    {
        private BLuser _objBLuser;
        private Responce _objResponce;

        public CLuserController()
        {
            _objBLuser = new BLuser();
            _objResponce = new Responce();
        }

        [HttpGet]
        [Route("Users")]
        [JWTAuthorizationFilter(EnmRoleType.Admin)] // Only Admin can access this method
        public IHttpActionResult GetAllUsers()
        {
            try
            {
                _objResponce.Data = _objBLuser.GetAll();
                return Ok(_objResponce);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error occurred: {ex.Message}"));
            }
        }

        [HttpGet]
        [Route("UserById")]
        [JWTAuthorizationFilter(EnmRoleType.Admin)]
        public IHttpActionResult GetUserById(int id)
        {
            _objResponce = _objBLuser.GetUserById(id);
            return Ok(_objResponce);
        }

        [HttpGet]
        [Route("GetUserProfile")]
        [JWTAuthorizationFilter]
        public IHttpActionResult GetUserProfile()
        {
            string token = GetTokenFromRequest();
            int userID = JWTHelper.GetUserIdFromToken(token);

            _objResponce = _objBLuser.GetProfile(userID);

            return Ok(_objResponce);
        }
        [HttpPost]
        [Route("AddUser")]
        
        public IHttpActionResult AddUser(UserDto objDtoUser)
        {

            if (objDtoUser == null)
            {
                _objResponce.IsError = true;
                _objResponce.Message = "User details are required.";
            }

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            _objBLuser.Type = EnumType.A;
            _objBLuser.PreSave(objDtoUser);
            _objResponce = _objBLuser.Validation();
            if (!_objResponce.IsError)
            {
                _objResponce = _objBLuser.Save();
                _objResponce.Message = "User Added Successfully";
            }
            return Ok(_objResponce);

        }


        [HttpPut]
        [Route("UpdateUser")]
        [JWTAuthorizationFilter(EnmRoleType.User)]
        public IHttpActionResult UpdateUser(UserDto objDtoUser)
        {
            if (objDtoUser == null)
            {
                _objResponce.IsError = true;
                _objResponce.Message = "User details are required.";
                return Ok(_objResponce);
            }

            _objBLuser.Type = EnumType.E;
            _objBLuser.PreSave(objDtoUser);
            _objResponce = _objBLuser.Validation();
            if (!_objResponce.IsError)
            {
                _objResponce = _objBLuser.Save();
                _objResponce.Message = "User Updated Successfully";
            }
            return Ok(_objResponce);
        }



        [HttpDelete]
        [Route("Delete")]
        [JWTAuthorizationFilter(EnmRoleType.User)]
        public IHttpActionResult DeleteUser(int id)
        {
            _objResponce = _objBLuser.Delete(id);
            return Ok(_objResponce);
        }



        private string GetTokenFromRequest()
        {
            var token = string.Empty;

            // Check if the Authorization header exists
            if (Request.Headers.Authorization != null)
            {
                // The token should be in the format 'Bearer <token>'
                var authorizationHeader = Request.Headers.Authorization.Parameter;
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
