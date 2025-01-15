using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMrevision.Models
{
    public class Responce
    {
        public bool IsError { get; set; }

        public string Message { get; set; }

       public  dynamic  Data { get; set; }
    }
}