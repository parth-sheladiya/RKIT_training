using FinalDemo.Models.ENUM;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo.Models.POCO
{
    public class Order
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(User), OnDelete = "CASCADE", OnUpdate = "CASCADE")]
        public int UserId { get; set; }

        [ForeignKey(typeof(Product), OnDelete = "CASCADE", OnUpdate = "CASCADE")]
        public int ProductId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public OrderStatusEnum Status { get; set; } = OrderStatusEnum.Pending;
    }
}