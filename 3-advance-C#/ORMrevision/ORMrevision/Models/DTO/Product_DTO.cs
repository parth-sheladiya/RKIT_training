using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMrevision.Models.DTO
{
    public class Product_DTO
    {
        public int Id { get; set; }           // Product ki unique identifier
        public string Name { get; set; }      // Product ka naam
        public string Description { get; set; } // Product ka description
        public decimal Price { get; set; }    // Product ki price
       
    }
}