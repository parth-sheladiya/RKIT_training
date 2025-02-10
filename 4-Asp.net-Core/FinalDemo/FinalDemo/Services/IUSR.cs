using FinalDemo.BL.Interface;
using FinalDemo.Models;
using FinalDemo.Models.DTO;

namespace FinalDemo.Services
{
    public interface IUSR01 
    {
        public Response GetAll();

        public Response GetByid(int id);

        public Response Delete(int id);
    }
}
