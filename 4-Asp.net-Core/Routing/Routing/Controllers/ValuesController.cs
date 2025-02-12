using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Routing.Controllers
{
    
    
    public class ValuesController : ControllerBase
    {

        public IActionResult GetAll()
        {
            return Content("Welcome to Get all user!");
        }
    }
}
