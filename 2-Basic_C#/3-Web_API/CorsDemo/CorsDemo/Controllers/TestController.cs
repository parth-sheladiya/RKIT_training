using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CorsDemo.Controllers
{
    [EnableCors("*", "*", "*")] // Enable CORS for this controller
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("api/test")]
        public IHttpActionResult GetMessage()
        {
            return Ok("CORS is enabled!");
        }
    }
}
