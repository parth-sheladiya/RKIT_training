using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMdemo.Models.DTO
{
    /// <summary>
    /// dto class
    /// </summary>
    public class DTO_PDT01
    {
        #region Fields
      
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// product name
        /// </summary>
        public string prodName { get; set; }

        /// <summary>
        /// description
        /// </summary>
        public string prodDesc { get; set; }

        /// <summary>
        /// company
        /// </summary>
        public string prodCompany { get; set; }

        /// <summary>
        /// price
        /// </summary>
        public int prodPrice { get; set; }

       
        #endregion

    }
}