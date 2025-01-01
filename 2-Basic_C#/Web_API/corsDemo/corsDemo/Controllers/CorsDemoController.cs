using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace corsDemo.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CorsDemoController : ApiController
    {
        [HttpGet]
        [Route("api/CorsDemo/message")]
        [DisableCors]
        public IHttpActionResult GetMessage()
        {
            return Ok(new { Message = "CORS is disables in ASP.NET Web API!" });
        }
    }
}
