using FinalDemo.Models;
using FinalDemo.Models.ENUM;

namespace FinalDemo.BL.Interface
{
    public interface ICommonHandler<T> where T : class
    {
        /// <summary>
        /// enum for add update delete
        /// </summary>
        EnumType typeOfOperation { get; set; }


        /// <summary>
        /// save before presave check all method
        /// </summary>
        /// <param name="objDto"></param>
        void PreSave(T objDto);

        /// <summary>
        /// validation
        /// </summary>
        /// <returns></returns>
        Response Validation();

        /// <summary>
        /// save for insert update
        /// </summary>
        /// <returns></returns>
        Response Save();
        
    }
}
