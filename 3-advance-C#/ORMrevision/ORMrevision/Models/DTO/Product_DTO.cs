using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMrevision.Models.DTO
{
    /// <summary>
    /// it is product fto class
    /// it is class to communicate to the user
    /// it is not communicate to the database 
    /// </summary>
    public class Product_DTO
    {
        // id field
        public int Id { get; set; }           
        // name field
        public string Name { get; set; }     
        // description field
        public string Description { get; set; } 
        // price field
        public decimal Price { get; set; }   
       
    }
}