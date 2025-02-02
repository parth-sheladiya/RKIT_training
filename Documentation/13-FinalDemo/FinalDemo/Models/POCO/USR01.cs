using ServiceStack.DataAnnotations;
using System;
using FinalDemo.Models.ENUM;
using System.ComponentModel.DataAnnotations;
namespace FinalDemo.Models.POCO
{
    /// <summary>
    /// it is user class below include field 
    /// </summary>
    public class USR01
    {
        /// <summary>
        /// user id 
        /// </summary>
        [AutoIncrement]
        [PrimaryKey]
        public int R01F01 { get; set; }


        /// <summary>
        /// username
        /// </summary>
        public string R01F02 { get; set; }

        /// <summary>
        /// user email
        /// </summary>
        [Unique]
        public string R01F03 { get; set; }

        /// <summary>
        /// user password
        /// </summary>
        public string R01F04 { get; set; }

        /// <summary>
        /// user phone number
        /// </summary>
        public long R01F05 { get; set; }

        /// <summary>
        /// user address
        /// </summary>
        public string R01F06 { get; set; }

        /// <summary>
        /// user role
        /// </summary>
        [IgnoreOnUpdate]
        [EnumDataType(typeof(EnmRoleType))]
        public EnmRoleType R01F07 { get; set; } 

        /// <summary>
        /// created at 
        /// </summary>
        [IgnoreOnUpdate]
        public DateTime R01F08 { get; set; } = DateTime.Now;

        /// <summary>
        /// updated at
        /// </summary>
         public DateTime R01F09 { get; set; } = DateTime.Now;
    }
}