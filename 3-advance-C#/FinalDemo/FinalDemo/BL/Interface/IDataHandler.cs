using FinalDemo.Models;
using FinalDemo.Models.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo.BL.Interface
{
    public interface IDataHandler<T> where T : class
    {
        OrderStatusEnum OrderStatus { get; set; }

        RoleEnum Role { get; set; }

        void PreSave(T userDto);


        Responce Save();


        Responce Validation();
    }
}