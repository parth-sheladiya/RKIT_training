using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo.Models.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }              // Product ka unique ID
        public string Name { get; set; }         // Product ka name
        public string Description { get; set; }  // Product ki description
        public decimal Price { get; set; }       // Product ka price
        public int Stock { get; set; }           // Product ka stock quantity
    }
}