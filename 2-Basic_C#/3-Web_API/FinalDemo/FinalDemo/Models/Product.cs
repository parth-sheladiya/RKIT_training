using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo.Models
{
    public class Product
    {
        #region Properties

        /// <summary>
        /// product  id
        /// </summary>
        
        public int ProductId { get; set; }

        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// desc
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// date
        /// </summary>
        public DateTime DateAdded { get; set; }

        #endregion
    }
}