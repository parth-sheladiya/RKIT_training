using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo.Models.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }                 // Order ka unique ID
        public int UserId { get; set; }             // User ID jo order place kar raha hai
        public List<int> ProductIds { get; set; }   // Product IDs jo order mein hain
    }
}