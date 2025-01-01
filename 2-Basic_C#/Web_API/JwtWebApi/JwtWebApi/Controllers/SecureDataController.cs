using System.Web.Http;

namespace JwtWebApi.Controllers
{
    public class SecureDataController : ApiController
    {
        [Authorize]
        [Route("api/secure-data")]  // Ensure this route is correct
        [HttpGet]
        public IHttpActionResult GetSecureData()
        {
            var username = User.Identity.Name;
            return Ok(new { Message = $"Hello {username}, this is a secure message!" });
        }
    }
}
