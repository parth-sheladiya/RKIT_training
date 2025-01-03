using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthJwt.Models
{
    public class LoginModel
    {
        // The username provided by the user during login
        public string Username { get; set; }

        // The password provided by the user during login
        public string Password { get; set; }
    }
}
