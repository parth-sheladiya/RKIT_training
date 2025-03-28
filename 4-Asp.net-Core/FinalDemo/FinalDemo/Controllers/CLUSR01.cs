﻿using FinalDemo.BL.Operations;
using FinalDemo.Filters;
using FinalDemo.Models;
using FinalDemo.Models.DTO;
using FinalDemo.Models.ENUM;
using FinalDemo.Models.POCO;
using FinalDemo.BL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLUSR01 : ControllerBase
    {
        private Response _objResponse;
        private IBLUSR _objBLUser;
        private IAuthentication _objBLAuth;

        /// <summary>
        /// ctor 
        /// </summary>
        public CLUSR01(Response objResponse , IBLUSR objBLUser , IAuthentication objBLAuth)
        {
            _objResponse = objResponse;
            _objBLUser = objBLUser;
            _objBLAuth = objBLAuth;
        }

        /// <summary>
        /// Get all user 
        /// </summary>
        /// <returns>list of all users</returns>
        [HttpGet]

        [Route("getAllUserResords")]
        [AuthFilter("Admin")]
        public IActionResult GetAllUser()
        {
            // get all user from set to response
            _objResponse = _objBLUser.GetAllUsers();
            return Ok(_objResponse);
        }

        /// <summary>
        ///speciific id 
        /// </summary>
        /// <returns>seach by id</returns>
        
        [HttpGet]
        [Route("getUserById")]
        [AuthFilter]
        public IActionResult GetUserByid(int id)
        {
            // get id and set to response
            _objResponse = _objBLUser.GetUserByid(id);
            return Ok(_objResponse);
        }

        /// <summary>
        /// add user
        /// </summary>
        /// <param name="objDtoUser01"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addUser")]

        public IActionResult AddUser(DTOUSR01 objDtoUser01)
        {
            //type is a
            _objBLUser.typeOfOperation = EnumType.A;
            // dto to poco
            _objBLUser.PreSave(objDtoUser01);
            // validation
            _objResponse = _objBLUser.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLUser.Save(); 
            }
            return Ok(_objResponse);
        }

        /// <summary>
        /// update user
        /// </summary>
        /// <param name="objDtoUser01"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateUser")]
        [AuthFilter]
        public IActionResult UpdateUser(DTOUSR01 objDtoUser01)
        {
            // validation token
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            // get user current login id current
            int loggedInUserId = _objBLAuth.GetLoggedInUserId(token);
            _objBLUser.typeOfOperation = EnumType.U;
            _objBLUser.PreSave(objDtoUser01);
            //_objResponse =  _objBLUser.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLUser.Update(loggedInUserId);
            }
            return Ok(_objResponse);
        }

        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deleteUser")]
        [AuthFilter]
        public IActionResult DeleteUser() 
        {
            // validate token
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            // current login user id
            int loggedInUserId = _objBLAuth.GetLoggedInUserId(token);
            // delete type
            _objBLUser.typeOfOperation = EnumType.D;
            // set response and delete
            _objResponse = _objBLUser.Delete( loggedInUserId);
            return Ok(_objResponse);
        }
        [HttpGet]
        [Route("GetProfile")]
        [AuthFilter]
        public IActionResult GetProfile()
        {
            // validate token
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            // current login user id
            int loggedInUserId = _objBLAuth.GetLoggedInUserId(token);

            _objResponse = _objBLUser.Profile(loggedInUserId);
            return Ok(_objResponse);
        }
    }
}
