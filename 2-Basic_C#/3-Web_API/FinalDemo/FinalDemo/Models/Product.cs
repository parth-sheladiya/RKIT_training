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
        /// Gets or sets the unique identifier for the product.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the product.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the category of the product (e.g., Electronics, Clothing, etc.).
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the date when the product was added.
        /// </summary>
        public DateTime DateAdded { get; set; }

        #endregion
    }
}