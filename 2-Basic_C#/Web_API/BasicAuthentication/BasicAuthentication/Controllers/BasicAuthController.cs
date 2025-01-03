using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BasicAuthentication.auth;

namespace BasicAuthentication.Controllers
{
    public class BasicAuthController : ApiController
    {
        [BasicAuthenticationAttr]
        public string Get()
        {
            return "web api method call";
        }
    }
}
