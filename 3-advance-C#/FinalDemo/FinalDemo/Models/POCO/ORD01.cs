using FinalDemo.Models.ENUM;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo.Models.POCO
{
    public class ORD01
    {
        /// <summary>
        /// orderID
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        public int D01F01 { get; set; }
        /// <summary>
        /// userID
        /// </summary>

        [ForeignKey(typeof(USR01), OnDelete = "CASCADE", OnUpdate = "CASCADE")]
        [Alias("D01F02")]
        public int D01F02 { get;set; }
        /// <summary>
        /// productID
        /// </summary>
        [ForeignKey(typeof(PDT01), OnDelete = "CASCADE", OnUpdate = "CASCADE")]
        [Alias("D01F03")]
        public int D01F03 { get; set; }
        /// <summary>
        /// CREATED AT
        /// </summary>
        public DateTime D01F04 { get; set; } = DateTime.Now;

        /// <summary>
        /// address
        /// </summary>
        public enmOrderStatus D01F05 { get; set; } = enmOrderStatus.P;

        

    }
}