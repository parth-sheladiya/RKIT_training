using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
    }
}