using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMrevision.Models.POCO
{
    /// <summary>
    /// it is poco model class 
    /// it is process data to the database and given responce 
    /// </summary>
    public class Product_POCO
    {
        // id field
        [AutoIncrement]
        [PrimaryKey]
        public int Id { get; set; }          
        //name field
        public string Name { get; set; }     

        // description field
        public string Description { get; set; } 
        // pricefield
        public decimal Price { get; set; }    
        // stock quantity
        public int StockQuantity { get; set; } 
        // it is field to created time but dont update on updated timne
        [IgnoreOnUpdate] 
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        
    }
}