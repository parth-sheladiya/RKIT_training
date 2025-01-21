using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo.Models.POCO
{
    public class Order
    {
        [AutoIncrement]
        [PrimaryKey]
        public int orderId { get; set; }

        public int userId { get; set; } // Foreign Key (relation with User)
        
        public int  productId { get; set; }

       // public string productName { get; set; }

        public int qunt { get; set; }

        
        public decimal totalAmount { get; set; }  // productPrice * qunt

        public string orderStatus { get; set; } = "pending"; // Example: Pending, Completed, Cancelled

        [IgnoreOnUpdate]
        public DateTime createdAt { get; set; } = DateTime.Now;

        public DateTime updatedAt { get; set; } = DateTime.Now;
    }
}