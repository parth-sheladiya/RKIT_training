using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalDemo.Models.ENUM;
using ServiceStack.DataAnnotations;

namespace FinalDemo.Models.POCO
{
    public class Product
    {
        [AutoIncrement]
        [PrimaryKey]
        public int productId { get; set; }

        public string productName { get; set; }

        public string productDescription { get; set; }

        public string productCategory { get; set; }
        public int productQuantity { get; set; }
        public int  productPrice { get; set; }

        [IgnoreOnUpdate]
        public DateTime createdAt { get; set; } = DateTime.Now;

        public DateTime updatedAt { get; set; } = DateTime.Now;
    }
}