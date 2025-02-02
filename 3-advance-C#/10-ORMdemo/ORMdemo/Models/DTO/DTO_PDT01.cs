using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMdemo.Models.DTO
{
    public class DTO_PDT01
    {
        #region Fields
      
        public int Id { get; set; }

        public string prodName { get; set; }

        public string prodDesc { get; set; }

        public string prodCompany { get; set; }

        public int prodPrice { get; set; }

       
        #endregion

    }
}