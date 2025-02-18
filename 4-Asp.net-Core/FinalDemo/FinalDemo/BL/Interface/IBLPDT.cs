using FinalDemo.Models;
using FinalDemo.Models.DTO;

namespace FinalDemo.BL.Interface
{
    /// <summary>
    /// BL product interface
    /// </summary>
    public interface IBLPDT : ICommonHandler<DTOPDT01>
    {
        /// <summary>
        /// get all products
        /// </summary>
        /// <returns></returns>
        public Response GetAllProducts();

        /// <summary>
        /// get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Response GetProductByid(int id);


        /// <summary>
        /// product is present or not
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsPDTExist(int id);

        /// <summary>
        /// delete product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Response Delete(int id);
    }
}
