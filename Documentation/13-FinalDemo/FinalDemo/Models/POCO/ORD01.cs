using ServiceStack.DataAnnotations;
using System;
using System.Web;

namespace FinalDemo.Models.POCO
{
    /// <summary>
    /// it is order class
    /// it is in include below field
    /// </summary>
    public class ORD01
    {
        /// <summary>
        /// order id
        /// </summary>
        [AutoIncrement]
        [PrimaryKey]
        public int D01F01 { get; set; }


        /// <summary>
        /// user id
        ///  Foreign Key (relation with User)
        /// </summary>
        public int R01F01 { get; set; } 


        /// <summary>
        /// product id
        /// foreign key relation with product 
        /// </summary>
        public int  T01F01 { get; set; }

        /// <summary>
        /// quantity
        /// </summary>
        public int D01F04 { get; set; }

        /// <summary>
        ///total amount
        /// </summary>
        public decimal D01F05 { get; set; }  // productPrice * qunt


        /// <summary>
        /// order status
        /// </summary>
        public string D01F06 { get; set; } = "pending"; // Example: Pending, Completed, Cancelled


        /// <summary>
        /// create at
        /// </summary>
        [IgnoreOnUpdate]
        public DateTime D01F07 { get; set; } = DateTime.Now;


        /// <summary>
        /// update at
        /// </summary>
        public DateTime D01F08 { get; set; } = DateTime.Now;
    }
}