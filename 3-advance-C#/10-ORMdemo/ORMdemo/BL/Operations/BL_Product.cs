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
    /// Handles Product Data Operations (CRUD)
    /// </summary>
    public class BL_Product : IDataHandler<DTO_PDT01>
    {
        // poco object
        private PDT01 _objPDT01;
        // specific id for update
        private int _id;
        // response object
        private Response _objresponce;
        // database connection factory
        private readonly IDbConnectionFactory _dbfactory;
        // operation type enum
        public EnumType Type { get; set; }

        /// <summary>
        /// Initializes BL_Product and sets up DB connection
        /// </summary>
        /// <exception cref="Exception">if database connection is not found</exception>
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
        /// Retrieves all products from the database
        /// </summary>
        /// <returns>Response object </returns>
        public Response GetAllPDT()
        {
            using (var db = _dbfactory.OpenDbConnection())
            {
                List<PDT01> res = db.Select<PDT01>().ToList();

                if (res.Count == 0)
                {
                    _objresponce.IsError = true;
                    _objresponce.Message = "No product available";
                    _objresponce.Data = null;
                }
                else
                {
                    _objresponce.IsError = false;
                    _objresponce.Data = res;
                }
                return _objresponce;
            }
        }

        /// <summary>
        /// Retrieves a product by ID
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Response object </returns>
        public Response GetPDTbyID(int id)
        {
            using (var db = _dbfactory.OpenDbConnection())
            {
                var product = db.SingleById<PDT01>(id);
                if (product == null)
                {
                    _objresponce.IsError = true;
                    _objresponce.Message = "Product not found";
                }
                else
                {
                    _objresponce.IsError = false;
                    _objresponce.Data = product;
                }
                return _objresponce;
            }
        }

        /// <summary>
        /// Checks if a product exists in the database
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>True if product exists</returns>
        private bool IsProductExists(int id)
        {
            using (var db = _dbfactory.OpenDbConnection())
            {
                return db.Exists<PDT01>(e => e.Id == id);
            }
        }

        /// <summary>
        /// Prepares response before deleting a product
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Response object </returns>
        private Response PreDelete(int id)
        {
            if (IsProductExists(id))
            {
                return GetPDTbyID(id);
            }
            _objresponce.IsError = true;
            _objresponce.Message = "Product not found";
            return _objresponce;
        }

        /// <summary>
        /// Validates product before deletion
        /// </summary>
        /// <param name="objPDT01">Product object</param>
        /// <returns>Response object </returns>
        public Response validateOndelete(PDT01 objPDT01)
        {
            if (objPDT01 == null)
            {
                _objresponce.IsError = true;
                _objresponce.Message = "Product not found";
            }
            else
            {
                _objresponce.IsError = false;
            }
            return _objresponce;
        }

        /// <summary>
        /// Deletes a product by ID
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Response object </returns>
        public Response Delete(int id)
        {
            var productResponse = PreDelete(id);
            if (productResponse.IsError)
            {
                return productResponse;
            }

            using (var db = _dbfactory.OpenDbConnection())
            {
                db.DeleteById<PDT01>(id);
            }

            _objresponce.IsError = false;
            _objresponce.Message = "Data Deleted";
            return _objresponce;
        }

        /// <summary>
        ///  product object for save operation
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
        /// Validates product before save operation
        /// </summary>
        /// <returns>Response object </returns>
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
                else
                {
                    _objresponce.IsError = false;
                }
            }
            return _objresponce;
        }

        /// <summary>
        /// Saves product data 
        /// </summary>
        /// <returns>Response object </returns>
        public Response Save()
        {
            try
            {
                using (var db = _dbfactory.OpenDbConnection())
                {
                    if (Type == EnumType.A)
                    {
                        int insertedId = (int)db.Insert(_objPDT01, selectIdentity: true);
                        _objresponce.IsError = false;
                        _objresponce.Message = "User ID is " + insertedId;
                    }
                    else if (Type == EnumType.E)
                    {
                        if (!IsProductExists(_id))
                        {
                            _objresponce.IsError = true;
                            _objresponce.Message = "ID not found, update failed.";
                        }
                        else
                        {
                            db.Update(_objPDT01);
                            _objresponce.IsError = false;
                            _objresponce.Message = "Data Updated";
                        }
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