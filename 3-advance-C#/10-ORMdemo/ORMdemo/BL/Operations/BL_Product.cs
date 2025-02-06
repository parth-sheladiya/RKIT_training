using ORMdemo.BL.Interface;
using ORMdemo.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.MySql;
using ORMdemo.Models.ENUM;
using ORMdemo.Models.POCO;
using ORMdemo.Models;
using ServiceStack.Data;
using System.Web.Security;
using ORMdemo.Extensions;

namespace ORMdemo.BL.Operations
{
    /// <summary>
    /// BL_Product class implements IDataHandler interface for handling product operations.
    /// </summary>
    public class BL_Product : IDataHandler<DTO_PDT01>
    {
        // POCO class instance for product
        private PDT01 _objPDT01;
        private int _id;

        // Response object for returning operation results
        private Response _objresponce;

        // Database connection factory (retrieved from global.asax or web.config)
        private readonly IDbConnectionFactory _dbfactory;

        // EnumType for defining Add (A) or Edit (E) operation
        public EnumType Type { get; set; }

        /// <summary>
        /// Constructor - Initializes response object and database connection factory.
        /// </summary>
        /// <exception cref="Exception">Throws exception if database connection is not found.</exception>
        public BL_Product()
        {
            _objresponce = new Response();
            _dbfactory = HttpContext.Current.Application["DbFactory"] as IDbConnectionFactory;

            if (_dbfactory == null)
            {
                throw new Exception("Database connection not found");
            }
        }

        /// <summary>
        /// Fetch all products from the database.
        /// </summary>
        /// <returns>List of all products.</returns>
        public Response GetAllPDT()
        {
            // open database
            using (var db = _dbfactory.OpenDbConnection())
            {
                List<PDT01> res = db.Select<PDT01>().ToList();

                if (res.Count == 0)
                {
                    _objresponce.IsError = true;
                    _objresponce.Message = "no pdt available";
                    _objresponce.Data = null;
                    return _objresponce;
                }
                _objresponce.IsError = false;
                _objresponce.Data = res;
                return _objresponce;
            }
        }

        /// <summary>
        /// Fetch a product by its ID.
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Returns product object if found, otherwise null.</returns>
        public PDT01 GetPDTbyID(int id)
        {
            // open database
            using (var db = _dbfactory.OpenDbConnection())
            {
                return db.SingleById<PDT01>(id);
            }
        }

        /// <summary>
        /// Checks if a product exists in the database by ID.
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Returns true if product exists, otherwise false.</returns>
        private bool IsProductExists(int id)
        {
            // open database
            using (var db = _dbfactory.OpenDbConnection())
            {
                var temp =    db.Exists<PDT01>(e => e.Id == id);
                return temp;
            }
        }

        /// <summary>
        /// Fetches the product before deletion.
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Returns product object if exists, otherwise null.</returns>
        private PDT01 PreDelete(int id)
        {
            if (IsProductExists(id))
            {
                return GetPDTbyID(id);
            }
            return null;
        }

        /// <summary>
        /// Validates if a product can be deleted.
        /// </summary>
        /// <param name="objPDT01">Product object</param>
        /// <returns>Returns response object with validation result.</returns>
        public Response validateOndelete(PDT01 objPDT01)
        {
            if (objPDT01 == null)
            {
                _objresponce.IsError = true;
                _objresponce.Message = "Product not found";
                return _objresponce;
            }

            _objresponce.IsError = false;
            return _objresponce;
        }

        /// <summary>
        /// Deletes a product by ID after validation.
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Returns response object with deletion status.</returns>
        public Response Delete(int id)
        {
            var product = PreDelete(id);
            var validateResponce = validateOndelete(product);

            if (validateResponce.IsError)
            {
                return validateResponce;
            }
            // open database
            using (var db = _dbfactory.OpenDbConnection())
            {
                db.DeleteById<PDT01>(id);
            }

            _objresponce.Message = "Data Deleted";
            return _objresponce;
        }

        /// <summary>
        /// Prepares the DTO object for saving by converting it to POCO.
        /// </summary>
        /// <param name="objDTO">DTO object</param>
        public void PreSave(DTO_PDT01 objDTO)
        {
            _objPDT01 = objDTO.Convert<PDT01>();

            if (Type == EnumType.E && objDTO.Id > 0)
            {
                _id = objDTO.Id;
            }
        }

        /// <summary>
        /// Validates product data before saving.
        /// </summary>
        /// <returns>Returns response object with validation status.</returns>
        public Response Validation()
        {
            if (Type == EnumType.E)
            {
                if (!(_id > 0))
                {
                    _objresponce.IsError = true;
                    _objresponce.Message = "Enter correct ID";
                }
                else if (!IsProductExists(_id))
                {
                    _objresponce.IsError = true;
                    _objresponce.Message = "Product not found";
                }
                return _objresponce;
            }
            return _objresponce;
        }

        /// <summary>
        /// Saves the product data (Insert or Update).
        /// </summary>
        /// <returns>Returns response object with save status.</returns>
        public Response Save()
        {
            try
            {
                // open database
                using (var db = _dbfactory.OpenDbConnection())
                {
                    if (Type == EnumType.A)
                    {
                        int insertedId = (int)db.Insert(_objPDT01, selectIdentity:true);
                        _objresponce.Message = "user id is " + insertedId;
                    }
                    else if (Type == EnumType.E)
                    {
                        // Check if product exists before updating
                        if (!IsProductExists(_id))
                        {
                            _objresponce.IsError = true;
                            _objresponce.Message = "ID not found, update failed.";
                            return _objresponce;
                        }

                        db.Update(_objPDT01);
                        _objresponce.Message = "Data Updated";

                    }
                }
            }
            catch (Exception ex)
            {
                _objresponce.IsError = true;
                _objresponce.Message = "Error from global handler: " + ex.Message;
            }

            return _objresponce;
        }
    }
}
