using FinalDemo.Models.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo.Models.DTO
{
    /// <summary>
    /// it is userDto class it is used to client side communication
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// user name for client side
        /// </summary>
        public string Name { get; set; }     


        /// <summary>
        /// user email
        /// </summary>
        public string Email { get; set; }    


        /// <summary>
        /// user password
        /// </summary>
        public string Password { get; set; }


        /// <summary>
        /// phone number
        /// </summary>
        public long PhoneNumber { get; set; }


        /// <summary>
        /// user address
        /// </summary>
        public string Address { get; set; }


        /// <summary>
        /// user role if user enter 0 then it is user and if user enter 1 then it is admin
        /// </summary>
        public RoleEnum Role { get; set; }   
    }
}