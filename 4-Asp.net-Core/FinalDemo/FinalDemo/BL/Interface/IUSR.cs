using FinalDemo.Models;
using FinalDemo.Models.DTO;

namespace FinalDemo.BL.Interface
{
    public interface IUSR01
    {
        public Response GetAllUsers();

        public Response GetUserByid(int id);

        public Response Delete(int id, int loggedInUserId);
    }
}
