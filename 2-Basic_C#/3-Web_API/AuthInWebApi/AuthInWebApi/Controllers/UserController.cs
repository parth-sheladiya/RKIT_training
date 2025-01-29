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
        /// Retrieves a list of user-related data (dummy data in this case).
        /// The endpoint is protected with Basic Authentication, ensuring only authorized users can access the data.
        /// </summary>
        /// <returns>An IEnumerable of strings representing user data.</returns>
        [AuthAttr]
        [Route("api/userdata")]
        public IEnumerable<string> Get()
        {
            return new string[] { "parth", "raj" ,"jay" };
        }
    }
}
