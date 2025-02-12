using FinalDemo.Models;
using FinalDemo.Models.DTO;

namespace FinalDemo.BL.Interface
{
    public interface IBLUSR : ICommonHandler<DTOUSR01>
    {


        public Response GetAllUsers();

        public Response GetUserByid(int id);

        public bool IsUSRExist(int id);

        public Response Update(int loggedInUserId);

        public Response Delete(int id, int loggedInUserId);
    }
}
