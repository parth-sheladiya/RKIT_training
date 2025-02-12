using FinalDemo.Models;
using FinalDemo.Models.DTO;

namespace FinalDemo.BL.Interface
{
    public interface IBLORD : ICommonHandler<DTOORD01>
    {
        public Response GetAllOrders();

        public Response GetOrderByid(int id);

        public bool IsORDExist(int id);

        public Response CancelOrder(int id, int loggedInUserId);

        public Response ChangeStatus(int orderId, string newStatus);
    }
}
