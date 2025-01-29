using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AuthInWebApi.Handler;

namespace AuthInWebApi.Controllers
{
    public class UserController : ApiController
    {
        /// <summary>
        /// get all users data
        /// authattr is provide authorization 
        /// </summary>
        /// <returns>list all data.</returns>
        [AuthAttr]
        [Route("api/userdata")]
        public IHttpActionResult Get()
        {
            var users = new List<string> { "parth", "raj", "jay" };
            return Ok(users); 
        }

    }
}
