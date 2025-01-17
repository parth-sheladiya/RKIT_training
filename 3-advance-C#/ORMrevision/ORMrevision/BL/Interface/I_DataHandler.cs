using ORMrevision.Models;
using ORMrevision.Models.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMrevision.BL.Interface
{
    /// <summary>
    /// it is interface . in this interface we have method declaration
    /// in this interface we have not any method implementation
    /// </summary>
    /// <typeparam name="T">T is denoted generic operator </typeparam>
    public interface I_DataHandler<T> where T : class
    {
       
        /// <summary>
        /// Enum type is A,E,D
        /// it is import from Enum 
        /// </summary>
        EnumType Type { get; set; }

        /// <summary>
        /// it is objdto because it is handle to add , edit operation 
        /// </summary>
        /// <param name="objDTO"></param>
        void preSave(T objDTO);

        /// <summary>
        /// it is save method it is use to savedata in database 
        /// before this method we have pass presave and validation method 
        /// </summary>
        /// <returns></returns>
        Responce Save();

        /// <summary>
        /// it is validation and validation will check condition for add,update, delete operation 
        /// </summary>
        /// <returns></returns>
        Responce Validation();






    }
}