using FinalDemo.Models;
using FinalDemo.Models.DTO;

namespace FinalDemo.BL.Interface
{
    /// <summary>
    /// interface for BL
    /// </summary>
    public interface IBLORD : ICommonHandler<DTOORD01>
    {
        /// <summary>
        /// get all orders
        /// </summary>
        /// <returns></returns>
        public Response GetAllOrders();

        /// <summary>
        /// get order by id  search
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Response GetOrderByid(int id);

        /// <summary>
        /// order is exits or not
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsORDExist(int id);

        /// <summary>
        /// cancel order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="loggedInUserId"></param>
        /// <returns></returns>
        public Response CancelOrder(int id, int loggedInUserId);

        /// <summary>
        /// order status change
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="newStatus"></param>
        /// <returns></returns>
        public Response ChangeStatus(int orderId, string newStatus);
    }
}
