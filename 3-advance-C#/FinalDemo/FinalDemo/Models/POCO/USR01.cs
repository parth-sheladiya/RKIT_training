using FinalDemo.Models.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.DataAnnotations;

namespace FinalDemo.Models.POCO
{
    public class USR01
    {
        /// <summary>
        /// UserId 
        /// </summary>
        [AutoIncrement]
        [PrimaryKey]
        public int R01F01 { get; set; }
        /// <summary>
        /// userName
        /// </summary>
        [Required]
        public string R01F02 { get; set; }
        /// <summary>
        /// userEmail
        /// </summary>
        [Required]
        public string R01F03 { get; set; }
        /// <summary>
        /// password
        /// </summary>
        [Required]
        public string R01F04 { get; set; }
        /// <summary>
        /// created at 
        /// </summary>
        [IgnoreOnUpdate]
        public DateTime R01F05 { get; set; } = DateTime.Now;
        /// <summary>
        /// updated at 
        /// </summary>
        public DateTime R01F06 { get; set; } = DateTime.Now;
        /// <summary>
        /// userRole
        /// </summary>
        [Required]
        public enmUserRole R01F07 { get; set; }

        
    }
}