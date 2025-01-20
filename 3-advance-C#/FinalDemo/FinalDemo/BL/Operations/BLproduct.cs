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

namespace FinalDemo.BL.Operations
{
    public class BLproduct : IDataHandler<ProductDto>
    {
        private Product _objProduct;
        private Responce _objResponce;
        private IDbConnectionFactory _dbfactory;
        int _id;
        private EnmRoleType roleType;
        public EnumType Type { get; set; }


        public BLproduct()
        {
            _objProduct = new Product();
            _objResponce = new Responce();

            _dbfactory = HttpContext.Current.Application["Dbfactory"] as IDbConnectionFactory;

            if (_dbfactory == null)
            {
                throw new Exception("Db Connection not found");
            }
        }

        public Responce GetAll()
        {
            try
            {
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    var res = db.Select<Product>();

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


        public Responce GetProductById(int id)
        {
            try
            {
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    var prodbyId = db.SingleById<Product>(id);
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

        public Responce IsExists(int id)
        {
            try
            {
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    bool isExists = db.Exists<Product>(u => u.productId == id);
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
        public void PreSave(ProductDto objProductDto)

        {
            _objProduct = objProductDto.ConvertTo<Product>();


            if (Type == EnumType.E)
            {
                _id = objProductDto.productId;
            }
            else
            {
                // Handle other cases if needed
                _id = 0;
            }
        }

        public Responce Validation()
        {
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

        public Responce PreValidationOnDelete()
        {
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

            _objResponce.IsError = false;
            return _objResponce;
        }


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
            if (IsExists(id).IsError)
            {
                // If ID does not exist, return error message
                _objResponce.IsError = true;
                _objResponce.Message = "ID not found, cannot delete.";
                _objResponce.Data = null;  // No data to return
                return _objResponce;
            }

            // Proceed with deletion if ID exists
            using (var db = _dbfactory.OpenDbConnection())
            {
                try
                {
                    db.DeleteById<Product>(id);  // Deleting the record by ID
                }
                catch (Exception ex)
                {
                    // error responce for error handler
                    _objResponce.IsError = true;
                    _objResponce.Message = $"Error while deleting product: {ex.Message}";
                    _objResponce.Data = null;
                    return _objResponce;
                }
            }

            // Success response after deletion
            _objResponce.IsError = false;
            _objResponce.Message = "product deleted successfully";
            _objResponce.Data = null;  // No data to return after deletion
            return _objResponce;
        }


        public Responce Save()
        {
            try
            {
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

        public Responce Add(Product newUser)
        {
            try
            {

                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    // check admin is exist or not 


                    db.Insert(newUser);
                }
                _objResponce.IsError = false;
                _objResponce.Data = newUser;
                _objResponce.Message = "product Added Successfully";
            }
            catch (Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = $"product not added {ex.Message}";
            }

            return _objResponce;
        }


        public Responce Update(int productId, Product newUser)
        {
            try
            {
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    // If userId is provided in method parameter, override newUser.userId
                    if (productId > 0)
                    {
                        newUser.productId = productId;
                    }

                    // Check if ID is provided and valid
                    if (newUser.productId <= 0)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "ID not found or invalid.";
                        return _objResponce;
                    }

                    // Ensure that the user exists before updating
                    var existingUser = db.SingleById<User>(newUser.productId);
                    if (existingUser == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "product does not exist.";
                        return _objResponce;
                    }

                    // Update the user
                    db.Update(newUser);
                }
                _objResponce.IsError = false;
                _objResponce.Data = newUser;
                _objResponce.Message = "product Updated Successfully";
            }
            catch (Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = $"product not Updated: {ex.Message}";
            }

            return _objResponce;
        }

    }
}