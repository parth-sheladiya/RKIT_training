using FinalDemo.Models;
using FinalDemo.Models.DTO;

namespace FinalDemo.BL.Interface
{
    /// <summary>
    /// user BL interface
    /// </summary>
    public interface IBLUSR : ICommonHandler<DTOUSR01>
    {

        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        public Response GetAllUsers();

        /// <summary>
        /// get usr by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Response GetUserByid(int id);

        /// <summary>
        /// user is exists or not
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsUSRExist(int id);

        /// <summary>
        /// update user
        /// </summary>
        /// <param name="loggedInUserId"></param>
        /// <returns></returns>
        public Response Update(int loggedInUserId);

        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="loggedInUserId">fromm token</param>
        /// <returns></returns>
        public Response Delete(int id, int loggedInUserId);
    }
}
