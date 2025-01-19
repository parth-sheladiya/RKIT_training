using FinalDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalDemo.BL.Operations;
using FinalDemo.Models.DTO;
using FinalDemo.BL.Interface;

namespace FinalDemo.Controllers
{
    /// <summary>
    /// auth controller and call businesslogic method
    /// </summary>
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        /// <summary>
        /// object of Responce class
        /// </summary>
        public Responce _objResponce = new Responce();

        /// <summary>
        /// object of AuthHandler class
        /// </summary>
        private readonly AuthHandler _objAuthHandler = new AuthHandler();


        /// <summary>
        /// Register User and call RegisterUser method and check condition process
        /// </summary>
        /// <param name="userDto">is is userdto class object </param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register(UserDto userDto)
        {
            //check user is null or not 
            if (userDto == null)
            {
                _objResponce.IsError = true;
                _objResponce.Message = "User details are required.";
                return BadRequest(_objResponce.Message);
            }
    
            // call business logic meethod
            var responseMessage = _objAuthHandler.RegisterUser(userDto);

            // check response is error or not
            if (_objAuthHandler._objResponce.IsError)
            {
                return BadRequest(_objAuthHandler._objResponce.Message);
            }

            // return response message
            return Ok(_objAuthHandler._objResponce.Message);
        }

        /// <summary>
        /// it is login method and call business logic method
        /// </summary>
        /// <param name="authDto">it is authdto class object</param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(AuthDto authDto)
        {
            // check user is null or not
            if (authDto == null)
            {
                _objResponce.IsError = true;
                _objResponce.Message = "User details are required.";
                return BadRequest(_objResponce.Message);
            }

            // call business logic method
            var token = _objAuthHandler.AuthenticateUser(authDto);

            // check response is error or not
            if (_objAuthHandler._objResponce.IsError)
            {
                return BadRequest(_objAuthHandler._objResponce.Message);
            }

            // return token
            return Ok( new 
            { 
                Token = _objAuthHandler._objResponce.Data.Token, 
                Message = _objAuthHandler._objResponce.Message 
            });
        }

        /// <summary>
        /// it is authorize admin method and call business logic method
        /// </summary>
        /// <param name="userId">it is poco class id </param>
        /// <returns></returns>
        [HttpGet]
        [Route("authorize/admin/{userId}")]
        public IHttpActionResult AuthorizeAdmin(int userId)
        {
            // check user id is valid or not
            if (userId <= 0)
            {
                _objResponce.IsError = true;
                _objResponce.Message = "Invalid user ID.";
                return BadRequest(_objResponce.Message);
            }

            // call business logic method
            var isAdmin = _objAuthHandler.AuthorizeAdmin(userId);

            // check user is admin or not
            if (!isAdmin)
            {
                _objResponce.IsError = true;
                _objResponce.Message = "User is not authorized as Admin.";
                return Unauthorized();
            }

            // return response message
            return Ok("User is authorized as Admin.");
        }

        /// <summary>
        /// it is authorize user method and call business logic method
        /// </summary>
        /// <param name="userId">it is poco class method</param>
        /// <returns></returns>
        [HttpGet]
        [Route("authorize/user/{userId}")]
        public IHttpActionResult AuthorizerUser(int userId)
        {
            // check user id is valid or not
            if (userId <= 0)
            {
                _objResponce.IsError = true;
                _objResponce.Message = "Invalid user ID.";
                return BadRequest(_objResponce.Message);
            }

            // call business logic method
            var isUser = _objAuthHandler.AuthorizerUser(userId);

            // check user is user or not
            if (!isUser)
            {
                _objResponce.IsError = true;
                _objResponce.Message = "User is not authorized.";
                return Unauthorized();
            }

            // return response message
            return Ok("User is authorized.");
        }

        

    }
}
