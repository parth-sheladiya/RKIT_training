using FinalDemo.BL.Interface;
using FinalDemo.Extention;
using FinalDemo.Models;
using FinalDemo.Models.DTO;
using FinalDemo.Models.ENUM;
using FinalDemo.Models.POCO;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Data;

namespace FinalDemo.BL.Operations
{
    public class BLPdt : ICommonHandlergit<DTOPDT01>
    {
        // connection factory
        private readonly IDbConnectionFactory _dbfactory;
        private Response _objResponse;
        private int _id;
        private PDT01 _objPDT01;
        public EnumType typeOfOperation { get; set; }
        public EnumRole typeOfRole { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="dbfactory"></param>
        /// <param name="objResponse"></param>
        /// <param name="objPDT01"></param>
        public BLPdt(IDbConnectionFactory dbfactory, Response objResponse , PDT01 objPDT01)
        {
            _dbfactory = dbfactory;
            _objResponse = objResponse;
            _objPDT01 = objPDT01;
        }

        /// <summary>
        /// GetAllProducts
        /// </summary>
        /// <returns></returns>
        public Response GetAllProducts()
        {
            using (IDbConnection db = _dbfactory.OpenDbConnection())
            {
                // select list of user data
                List<PDT01> res = db.Select<PDT01>().ToList();

                // if no product found
                if (res.Count == 0)
                {
                    _objResponse.Data = null;
                    _objResponse.IsError = true;
                    _objResponse.Message = "No product found";
                }
                // if user found
                else
                {

                    // success responce 
                    _objResponse.Message = $"there are {res.Count} products available";
                    _objResponse.Data = res;

                }

                return _objResponse;
            }
        }
        /// <summary>
        /// GetProductByid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Response GetProductByid(int id)
        {
            using (var db = _dbfactory.OpenDbConnection())
            {
                _objPDT01 = db.SingleById<PDT01>(id);
            }

            if (_objPDT01 != null)
            {
                _objResponse.Data = _objPDT01;
                _objResponse.IsError = false;
                _objResponse.Message = "product id fetch successfully";
            }
            else
            {
                _objResponse.IsError = true;
                _objResponse.Message = "product id not found";

            }

            return _objResponse;

        }
        /// <summary>
        /// presave method it is in dto to poco 
        /// </summary>
        /// <param name="objPDTDto"></param>
        public void PreSave(DTOPDT01 objPDTDto)
        {
            _objPDT01 = objPDTDto.Convert<PDT01>();

            // edit 
            if (typeOfOperation == EnumType.U)
            {
                _id = objPDTDto.T01F01;
            }
        }

        /// <summary>
        /// is product exist or not
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsPDTExist(int id)
        {
            using (var db = _dbfactory.OpenDbConnection())
            {
                return db.Exists<PDT01>(id);
            }
        }
        /// <summary>
        /// validations
        /// </summary>
        /// <returns></returns>
        public Response Validation()
        {
            if (typeOfOperation == EnumType.U)
            {
                if (!(_id > 0))
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Enter Correct Id";
                }
                else if (!IsPDTExist(_id))
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "product Not Found";
                }
            }

            return _objResponse;
        }
        /// <summary>
        /// save method
        /// </summary>
        /// <returns></returns>
        public Response Save()
        {
            using (var db = _dbfactory.OpenDbConnection())
            {
                if (typeOfOperation == EnumType.A)
                {
                    db.Insert(_objPDT01);
                    _objResponse.Message = "PRoduct Added";
                }
                if (typeOfOperation == EnumType.U)
                {
                    if (!IsPDTExist(_id))
                    {
                        _objResponse.IsError = true;
                        _objResponse.Message = "Product ID not found";
                        return _objResponse;
                    }
                    db.Update(_objPDT01);
                    _objResponse.Message = "Product Updated";
                }

                return _objResponse;
            }
        }
        /// <summary>
        /// delete method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Response Delete(int id)
        {
            using (var db = _dbfactory.OpenDbConnection())
            {
                // Check if ID exists in the database before deleting
                if (!IsPDTExist(id))
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "ID not found";
                    return _objResponse;
                }
                db.DeleteById<PDT01>(id);
            }
            _objResponse.Message = "product Deleted";
            return _objResponse;
        }

    }
}
