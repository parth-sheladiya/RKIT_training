using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.DataAnnotations;
namespace FinalDemo.Models.POCO
{
    public class PDT01
    {
        /// <summary>
        /// productId
        /// </summary>
        [AutoIncrement]
        [PrimaryKey]
        public int T01F01 { get; set; }

        /// <summary>
        /// productName
        /// </summary>
        [Required]
        public int T01F02 { get; set; }
        /// <summary>
        /// productDescription
        /// </summary>
        [Required]
        public string T01F03 { get; set; }
        /// <summary>
        /// productPrice
        /// </summary>
        [Required]
        public int T01F04 { get; set; }
        /// <summary>
        /// created At
        /// </summary>
        [IgnoreOnUpdate]
        public DateTime T01F05 { get; set; } = DateTime.Now;
        /// <summary>
        /// updatedAt
        /// </summary>
        
        public DateTime T01F06 { get; set; }


       
    }
}