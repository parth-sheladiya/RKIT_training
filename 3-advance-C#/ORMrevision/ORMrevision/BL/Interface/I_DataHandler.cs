using ORMrevision.Models;
using ORMrevision.Models.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMrevision.BL.Interface
{
    public interface I_DataHandler<T> where T : class
    {
        EnumType Type { get; set; }

        void preSave(T objDTO);


        Responce Save();


        Responce Validation();






    }
}