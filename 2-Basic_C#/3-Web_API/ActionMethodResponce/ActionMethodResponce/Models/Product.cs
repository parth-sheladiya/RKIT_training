using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActionMethodResponce.Models
{
    
    #region product model
    /// <summary>
    /// there are four part of model id , name , category , price 
    /// </summary>
    
    public class Product
    {
       


        #region public members
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }

        #endregion


    }
    #endregion
}