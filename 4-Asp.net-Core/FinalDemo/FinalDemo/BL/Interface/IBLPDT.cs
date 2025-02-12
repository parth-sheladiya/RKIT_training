using FinalDemo.Models;
using FinalDemo.Models.DTO;

namespace FinalDemo.BL.Interface
{
    public interface IBLPDT : ICommonHandler<DTOPDT01>
    {
        public Response GetAllProducts();

        public Response GetProductByid(int id);

        public bool IsPDTExist(int id);

        public Response Delete(int id);
    }
}
