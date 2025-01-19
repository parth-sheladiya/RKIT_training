using FinalDemo.Models.ENUM;
using FinalDemo.Models.POCO;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo.Models.DTO
{
    public class UserDto
    {
        public int userId { get; set; }
        public string userName { get; set; }

        public string userEmail { get; set; }
        public string userPassword { get; set; }

        public long userMobile { get; set; }

        public string userAddress { get; set; }

       
        public EnmRoleType Role { get; set; } 
    }
}