using FinalDemo.Models.ENUM;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;

namespace FinalDemo.Models.POCO
{
    public class User
    {
        
        /// <summary>
        /// user id it is primary key and autoincrement
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }


        /// <summary>
        /// user name 
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// user email it is unique
        /// </summary>
        [Required]
        [Unique]
        public string Email { get; set; }


        /// <summary>
        /// user password
        /// </summary>
        [Required]
        public string Password { get; set; }


        /// <summary>
        /// user phone number 
        /// </summary>
        [Required]
        public long PhoneNumber { get; set; }


        /// <summary>
        /// user address 
        /// </summary>
        [Required]
        public string Address { get; set; }


        /// <summary>
        /// user created at
        /// </summary>
        [IgnoreOnUpdate]
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        /// <summary>
        /// user updated at
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        /// <summary>
        /// user role is it admin or user 
        /// </summary>
        [Required]
        [IgnoreOnUpdate]
        public RoleEnum Role { get; set; } = RoleEnum.User;
    }
}