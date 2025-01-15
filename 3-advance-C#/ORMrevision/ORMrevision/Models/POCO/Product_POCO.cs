using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMrevision.Models.POCO
{
    public class Product_POCO
    {
        [AutoIncrement]
        [PrimaryKey]
        public int Id { get; set; }           // Product ki unique identifier
        public string Name { get; set; }      // Product ka naam
        
        public string Description { get; set; } // Product ka description
        public decimal Price { get; set; }    // Product ki price
        public int StockQuantity { get; set; } // Product ka stock quantity
        [IgnoreOnUpdate]
        public DateTime CreatedAt { get; set; } // Product ka creation date

        public Product_POCO()
        {
            CreatedAt = DateTime.Now; // Set current date and time
        }
    }
}