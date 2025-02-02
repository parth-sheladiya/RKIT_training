using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalDemo.Models.ENUM;
using System.ComponentModel.DataAnnotations;
namespace FinalDemo.Models.POCO
{
    public class User
    {
        [AutoIncrement]
        [PrimaryKey]
        public int userId { get; set; }


        public string userName { get; set; }

        [Unique]
        public string userEmail { get; set; }

        public string userPassword { get; set; }

        public long userMobile { get; set; }

        public string userAddress { get; set; }

        [IgnoreOnUpdate]
        [EnumDataType(typeof(EnmRoleType))]
        public EnmRoleType RoleType { get; set; } 

        [IgnoreOnUpdate]
        public DateTime createdAt { get; set; } = DateTime.Now;

        public DateTime updatedAt { get; set; } = DateTime.Now;
    }
}