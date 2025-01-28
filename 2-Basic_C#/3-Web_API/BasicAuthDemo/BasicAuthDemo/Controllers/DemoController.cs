using System.Web.Http;

namespace BasicAuthDemo.Controllers
{
    public class DemoController : ApiController
    {

        //[BasicAuthDemo.Handlers.BasicAuthHandler] // Apply only here
        [AllowAnonymous]
        [HttpGet]
        [Route("api/public")]
        public IHttpActionResult GetPublicData()
        {
            return Ok("This is public data. No authentication required.");
        }

        [BasicAuthDemo.Handlers.BasicAuthHandler] // Apply only here
        [HttpGet]
        [Route("api/private")]
        public IHttpActionResult GetPrivateData()
        {
            return Ok("This is private data. Authentication successful.");
        }
    }
}