using JwtToken.Filters;
using JwtToken.TokenHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JwtToken.Controllers
{
    /// <summary>
    /// Controller that handles secure data retrieval.
    /// </summary>
    public class DataMessageController : ApiController
    {
        /// <summary>
        /// Retrieves secured data after successful JWT authentication.
        /// </summary>
        /// <returns>An IHttpActionResult containing secured data.</returns>
        [HttpGet]
        [Route("api/secure/data")]
        [JwtAuthFilter]
        public IHttpActionResult GetData()
        {
            return Ok("This is secured data.");
        }
    }
}
