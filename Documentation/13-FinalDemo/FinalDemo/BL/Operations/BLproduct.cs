using FinalDemo.BL.Interface;
using FinalDemo.Extension;
using FinalDemo.Models;
using FinalDemo.Models.DTO;
using FinalDemo.Models.ENUM;
using FinalDemo.Models.POCO;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace FinalDemo.BL.Operations
{
    /// <summary>
    /// business logic implementationb
    /// </summary>
    public class BLproduct : IDataHandler<DTOPDT01>
    {
        // product poco
        private PDT01 _objProduct;

        // response
        private Responce _objResponce;

        // data base connection
        private IDbConnectionFactory _dbfactory;
        int _id;

        // role type
        private EnmRoleType roleType;

        // enum type
        public EnumType Type { get; set; }


        /// <summary>
        /// ctor
        /// </summary>
        /// <exception cref="Exception"></exception>
        public BLproduct()
        {
            _objProduct = new PDT01();
            _objResponce = new Responce();

            _dbfactory = HttpContext.Current.Application["Dbfactory"] as IDbConnectionFactory;

            if (_dbfactory == null)
            {
                throw new Exception("Db Connection not found");
            }
        }

        /// <summary>
        /// get all method
        /// </summary>
        /// <returns></returns>
        public Responce GetAll()
        {
            try
            {
                // open data base
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    // all product fetch
                    List<PDT01> res = db.Select<PDT01>();

                    if (res.Count == 0)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "No Product found";
                    }
                    else
                    {
                        // success responce 
                        _objResponce.Message = $"there are {res.Count} Products available";
                    }

                    // no error
                    _objResponce.IsError = false;
                    _objResponce.Data = res;
                    return _objResponce;

                }
            }
            catch(Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = $"error for get all Products : {ex.Message}";
                return _objResponce;
            }
        }

        /// <summary>
        /// product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Responce GetProductById(int id)
        {
            try
            {
                // open data base
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    // single user by id
                    var prodbyId = db.SingleById<PDT01>(id);
                    if (prodbyId == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "No Product found";
                    }
                    else
                    {
                        _objResponce.IsError = false;
                        _objResponce.Data = prodbyId;
                    }
                    _objResponce.IsError = false;
                    _objResponce.Data = prodbyId;


                }

            }
            catch (Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = $"error for get product by id: {ex.Message}";
            }

            return _objResponce;
        }

        /// <summary>
        /// product is exits or not
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Responce IsExists(int id)
        {
            try
            {
                // open data base
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    // id throuh found
                    bool isExists = db.Exists<PDT01>(u => u.T01F01 == id);
                    if (isExists)
                    {
                        _objResponce.IsError = false;
                        _objResponce.Message = $"product with ID  {id} does not exists";
                    }
                    else
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = $"product with ID {id} exists";
                    }
                }
            }
            catch (Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = $"error for check product exists: {ex.Message}";
            }

            return _objResponce;
        }

        /// <summary>
        /// presave method
        /// </summary>
        /// <param name="objProductDto"></param>
        public void PreSave(DTOPDT01 objProductDto)

        {
            // convert dto to poco
            _objProduct = objProductDto.ConvertTo<PDT01>();

            // edit
            if (Type == EnumType.E)
            {
                _id = objProductDto.T01F01;
            }
            else
            {
                // Handle other cases if needed
                _id = 0;
            }
        }

        
        /// <summary>
        /// validtion method
        /// </summary>
        /// <returns></returns>
        public Responce Validation()
        {
            // edit
            if (Type == EnumType.E)
            {
                // Check if the ID is greater than 0
                if (!(_id > 0))
                {
                    // error handler
                    _objResponce.IsError = true;
                    _objResponce.Message = "ID must be greater than 0";
                    _objResponce.Data = null;  // No data in case of error
                }
                else
                {
                    // obj error handler
                    _objResponce.IsError = false;
                    _objResponce.Message = "Validation successful";
                    _objResponce.Data = new { _id };  // Returning the validated ID as data (or any other data you want)
                }


                return _objResponce;
            }

            return _objResponce;
        }

        /// <summary>
        /// before delete
        /// </summary>
        /// <returns></returns>
        public Responce PreValidationOnDelete()
        {
            // delete
            if (EnumType.D == Type)
            {
                // id must be greater then 0
                if (!(_id > 0))
                {
                    // error handler 
                    _objResponce.IsError = true;
                    _objResponce.Message = "id must be greater then 0";
                }
                else if ((IsExists(_id).IsError))
                {
                    // error handler 
                    _objResponce.IsError = true;
                    _objResponce.Message = "id not found";
                }
                return _objResponce;

            }

           
            return _objResponce;
        }

        /// <summary>
        /// delete method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Responce Delete(int id)
        {
            // Pre-validation check before deletion
            var validateResponce = PreValidationOnDelete();

            // If validation fails, return the response with error message
            if (validateResponce.IsError)
            {
                return validateResponce;
            }

            // Check if the record exists before attempting to delete
            var product = GetProductById(id); // Fetch the product by ID
            //if (product.IsError)
            //{
            //    // If ID does not exist, return error message
            //    _objResponce.IsError = true;
            //    _objResponce.Message = "ID not found, cannot delete.";
            //    _objResponce.Data = null;  // No data to return
            //    return _objResponce;
            //}

            // Check if product quantity is 0 before deleting
            var productDetails = product.Data as PDT01;  // Assuming you have a Product object
            if (productDetails != null && productDetails.T01F05 == 0)
            {
                using (var db = _dbfactory.OpenDbConnection())
                {
                    try
                    {
                        db.DeleteById<PDT01>(id);  // Deleting the record by ID
                    }
                    catch (Exception ex)
                    {
                        // error response for error handler
                        _objResponce.IsError = true;
                        _objResponce.Message = $"Error while deleting product: {ex.Message}";
                        _objResponce.Data = null;
                        return _objResponce;
                    }
                }

                // Success response after deletion
                _objResponce.IsError = false;
                _objResponce.Message = "Product deleted successfully";
                _objResponce.Data = null;  // No data to return after deletion
            }
            else
            {
                // Prevent deletion if quantity is not 0
                _objResponce.IsError = true;
                _objResponce.Message = "Product cannot be deleted as quantity is not 0.";
                _objResponce.Data = null;
            }

            return _objResponce;
        }

        /// <summary>
        /// save mehthod
        /// </summary>
        /// <returns></returns>

        public Responce Save()
        {
            try
            {
                // open data base
                using (var db = _dbfactory.OpenDbConnection())
                {
                    // add operation condition
                    if (EnumType.A == Type)
                    {
                        // insert 
                        db.Insert(_objProduct);
                        // give responce
                        _objResponce.Message = "data addes";
                        _objResponce.Data = _objProduct;
                    }
                    // edit operation condition
                    if (EnumType.E == Type)
                    {
                        // update method for poco model 
                        db.Update(_objProduct);
                        // return responce object 
                        _objResponce.Message = "data updated";
                        _objResponce.Data = _objProduct;
                    }
                }
            }
            catch (Exception ex)
            {
                // error handler 
                _objResponce.IsError = true;
                _objResponce.Message = $"error for save data: {ex.Message}";
            }
            return _objResponce;
        }

        /// <summary>
        /// get product by category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public Responce GetProcuctByCategory(string category)
        {
            try
            {
                // open data base
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    // list of product
                    List<PDT01> pdtByCategory = db.Select<PDT01>(p => p.T01F04 == category);

                    if(pdtByCategory.Count ==0)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = $"No products found in category: {category}";
                    }
                    else
                    {
                        var showAllpdtNameInCategory = pdtByCategory.Select(p => p.T01F02).ToList();

                        if(showAllpdtNameInCategory.Count==0)
                        {
                            _objResponce.IsError = true;
                            _objResponce.Message = "category is exists but no product available in this category";

                        }

                        _objResponce.IsError = false;
                        _objResponce.Data = showAllpdtNameInCategory;
                        _objResponce.Message = $"there are {showAllpdtNameInCategory.Count} product avaialble in {category} category ";

                    }
                }
            }
            catch(Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = $"Error while fetching products by category: {ex.Message}";
            }

            return _objResponce;
        }
    }
}