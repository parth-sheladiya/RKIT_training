using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CorsDemo.Controllers
{
    // Enable CORS for this controller
    [EnableCors("*", "*", "*")] 
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
