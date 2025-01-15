using ORMrevision.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ORMrevision.Models;
using ORMrevision.Models.DTO;
using ORMrevision.Models.POCO;
using ServiceStack.Data;
using System.Data.Odbc;
using ServiceStack.OrmLite;
using ORMrevision.Models.ENUM;
using ServiceStack;

namespace ORMrevision.BL.Operations
{
    public class IDataOperations :I_DataHandler<Product_DTO>
    {
        private Product_POCO _objProductPOCO;

        private Responce _objResponce;

        private readonly IDbConnectionFactory _connFactory;

        private int _id;
        public EnumType Type { get; set; }

        public IDataOperations()
        {
            _objProductPOCO = new Product_POCO();

            _objResponce = new Responce();

            //  db connection factory 
            _connFactory = HttpContext.Current.Application["DbFactory"] as IDbConnectionFactory;

            if(_connFactory == null)
            {
                throw new Exception("connection not found ");
            }


        }

        public Responce   GetAll() 
        {

           using(var db = _connFactory.OpenDbConnection())
            {
                var res = db.Select<Product_POCO>();

                if(res.Count == 0)
                {
                    _objResponce.IsError = true;
                    _objResponce.Message = "no products available";
                    _objResponce.Data = null;
                }
                else
                {
                    _objResponce.Message = $"there are {res.Count} products available";
                }
                _objResponce.IsError = false;
                _objResponce.Data = res;
                return _objResponce;
            }
           
        }

        public Responce GetByID(int id)
        {
            using (var db = _connFactory.OpenDbConnection())
            {
                var product = db.SingleById<Product_POCO>(id);

                if (product == null)
                {
                    _objResponce.IsError = true;
                    _objResponce.Message = $"Product with ID {id} not found";
                    _objResponce.Data = null;
                }
                else
                {
                    _objResponce.IsError = false;
                    _objResponce.Message = $"Product with ID {id} found";
                    _objResponce.Data = product;
                }

                return _objResponce;
            }
        }


        public bool IsExists(int id)
        {
            using (var db = _connFactory.OpenDbConnection())
            {
                bool exists = db.Exists<Product_POCO>(id);

                if (!exists)
                {
                    _objResponce.IsError = true;
                    _objResponce.Message = $"Product with ID {id} does not exist";
                    _objResponce.Data = null;
                }
                else
                {
                    _objResponce.IsError = false;
                    _objResponce.Message = $"Product with ID {id} exists";
                    _objResponce.Data = exists; // You can return data if needed
                }

                return exists;
            }
        }


        public void preSave(Product_DTO objDTOproduct)
        {
            // Convert DTO to POCO
            _objProductPOCO = objDTOproduct.ConvertTo<Product_POCO>();

            // Check if the Type is EnumType.E and handle accordingly
            if (EnumType.E == Type)
            {
                // Set the _id if the condition is true
                _id = objDTOproduct.Id;
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
                    _objResponce.IsError = true;
                    _objResponce.Message = "ID must be greater than 0";
                    _objResponce.Data = null;  // No data in case of error
                }
                // Check if the ID exists
                else if (!(IsExists(_id)))
                {
                    _objResponce.IsError = true;
                    _objResponce.Message = "ID not found";
                    _objResponce.Data = null;  // No data in case of error
                }
                else
                {
                    _objResponce.IsError = false;
                    _objResponce.Message = "Validation successful";
                    _objResponce.Data = new { _id };  // Returning the validated ID as data (or any other data you want)
                }

                return _objResponce;
            }

            // Return the response in case the condition is not met
            _objResponce.IsError = false;
            _objResponce.Message = "No validation needed for this type";
            _objResponce.Data = null;  // No data in case no validation is required
            return _objResponce;
        }


        public Responce PreValidationOnDelete()
        {
            if(EnumType.D == Type)
            {
                if(!(_id > 0))
                {
                    _objResponce.IsError = true;
                    _objResponce.Message = "id must be greater then 0";
                }
                else if (!(IsExists(_id)))
                {
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
            if (!IsExists(id))
            {
                // If ID does not exist, return error message
                _objResponce.IsError = true;
                _objResponce.Message = "ID not found, cannot delete.";
                _objResponce.Data = null;  // No data to return
                return _objResponce;
            }

            // Proceed with deletion if ID exists
            using (var db = _connFactory.OpenDbConnection())
            {
                try
                {
                    db.DeleteById<Product_POCO>(id);  // Deleting the record by ID
                }
                catch (Exception ex)
                {
                    _objResponce.IsError = true;
                    _objResponce.Message = $"Error while deleting data: {ex.Message}";
                    _objResponce.Data = null;
                    return _objResponce;
                }
            }

            // Success response after deletion
            _objResponce.IsError = false;
            _objResponce.Message = "Data deleted successfully";
            _objResponce.Data = null;  // No data to return after deletion
            return _objResponce;
        }



        public Responce Save()
        {
            try
            {
                using (var db = _connFactory.OpenDbConnection())
                {
                    if(EnumType.A == Type)
                    {
                        db.Insert(_objProductPOCO);
                        _objResponce.Message = "data addes";
                    }
                    if (EnumType.E == Type)
                    {
                        db.Update(_objProductPOCO);
                        _objResponce.Message = "data updated";
                    }
                }
            }
            catch (Exception e)
            {
                _objResponce.IsError = true;
                _objResponce.Message = "error from global handler :  " + e.Message;
            }

            return _objResponce;
        }
    }
}