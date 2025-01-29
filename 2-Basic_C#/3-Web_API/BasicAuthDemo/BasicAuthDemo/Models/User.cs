using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuthDemo.Models
{
    /// <summary>
    /// user model
    /// </summary>
    public class User
    {
        /// <summary>
        /// username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// password 
        /// </summary>
        public string Password { get; set; }
    }
}