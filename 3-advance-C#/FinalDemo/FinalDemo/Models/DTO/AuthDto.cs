using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo.Models.DTO
{
    public class AuthDto
    {
        public string Email { get; set; }     // User's email for authentication
        public string Password { get; set; }  // User's password for authentication
    }
}