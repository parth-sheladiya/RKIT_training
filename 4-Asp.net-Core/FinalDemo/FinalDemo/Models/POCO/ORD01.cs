﻿using ServiceStack.DataAnnotations;

namespace FinalDemo.Models.POCO
{
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
        public int T01F01 { get; set; }

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
        //  Pending, Completed, Cancelled
        public string D01F06 { get; set; } = "pending";


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
