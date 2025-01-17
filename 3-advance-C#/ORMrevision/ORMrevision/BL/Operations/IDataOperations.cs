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
using ServiceStack.Script;

namespace ORMrevision.BL.Operations
{
    public class IDataOperations :I_DataHandler<Product_DTO>
    {
        // import poco model
        private Product_POCO _objProductPOCO;
        // import responce
        private Responce _objResponce;

        // it is use to communicate with data base
        private readonly IDbConnectionFactory _connFactory;

        private int _id;
        // enumtype
        public EnumType Type { get; set; }

        // create constructor and create object responce and poco model
        public IDataOperations()
        {
            // create object for poco model
            _objProductPOCO = new Product_POCO();
            // create responce object 
            _objResponce = new Responce();

            //  db connection factory 
            _connFactory = HttpContext.Current.Application["DbFactory"] as IDbConnectionFactory;

            // check connection is exist or not
            if(_connFactory == null)
            {
                throw new Exception("connection not found ");
            }


        }

        /// <summary>
        /// it is  get all data to the database 
        /// </summary>
        /// <returns></returns>
        public Responce   GetAll() 
        {

           using(var db = _connFactory.OpenDbConnection())
            {
                // select method is used to get data to the data base 
                var res = db.Select<Product_POCO>();
                // if not exist data then give error 
                if(res.Count == 0)
                {
                    // error handler 
                    _objResponce.IsError = true;
                    _objResponce.Message = "no products available";
                    _objResponce.Data = null;
                }
                // data is availabale
                else
                {
                    // success responce 
                    _objResponce.Message = $"there are {res.Count} products available";
                }
                // in case not any error 
                _objResponce.IsError = false;
                _objResponce.Data = res;
                return _objResponce;
            }
           
        }
        /// <summary>
        /// get product by id it is interaction with data base and check if id is exists or not 
        /// </summary>
        /// <param name="id">id parameter</param>
        /// <returns></returns>
        public Responce GetByID(int id)
        {
            using (var db = _connFactory.OpenDbConnection())
            {
                // it is intract and perform in database 
                var product = db.SingleById<Product_POCO>(id);
                // check condition id id null or not 
                if (product == null)
                {
                    // error handler
                    _objResponce.IsError = true;
                    _objResponce.Message = $"Product with ID {id} not found";
                    _objResponce.Data = null;
                }
                // id is not null
                else
                {
                    // success respone
                    _objResponce.IsError = false;
                    _objResponce.Message = $"Product with ID {id} found";
                    _objResponce.Data = product;
                }

                return _objResponce;
            }
        }

        /// <summary>
        /// check products is exists or not 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Responce IsExists(int id)
        {
            using (var db = _connFactory.OpenDbConnection())
            {
                // it is return bool exists or not 
                bool exists = db.Exists<Product_POCO>(p => p.Id == id);

                if (!exists)
                {
                    // error handler
                    _objResponce.IsError = true;
                    _objResponce.Message = $"Product with ID {id} does not exist";
                    _objResponce.Data = null;
                }
                else
                {
                   // success responce  
                    _objResponce.Message = $"Product with ID {id} exists";
                    _objResponce.Data = exists;
                }

                return _objResponce;
            }
        }



        /// <summary>
        /// it is method before save 
        /// before save it is convert dto to poco and add, edit operation logic 
        /// </summary>
        /// <param name="objDTOproduct"></param>
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
            else if(EnumType.A == Type)
            {
                _id = objDTOproduct.Id;
                if (!IsExists(_id).IsError)
                {
                    // error handler 
                    _objResponce.IsError = true;
                    _objResponce.Message = "Error: Can't add product already is their";
                    _objResponce.Data = null;
                }
            }
            else
            {
                // Handle other cases if needed
                _id = 0; 
            }

           
        }


        /// <summary>
        /// it is method before save 
        /// it is used to check condition and verify then  save mehod 
        /// </summary>
        /// <returns></returns>
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
                // Check if the ID exists
                else if ((IsExists(_id).IsError))
                {
                    // obj error handler
                    _objResponce.IsError = true;
                    _objResponce.Message = "ID not found";
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
        /// it is method before delete method 
        /// it is check id is only posotive, non-zero and check some condition
        /// </summary>
        /// <returns></returns>
        public Responce PreValidationOnDelete()
        {
            if(EnumType.D == Type)
            {
                // id must be greater then 0
                if(!(_id > 0))
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
            if (IsExists(id).IsError)
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
                    // error responce for error handler
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


        /// <summary>
        /// save method after all condition is full fill and verify by above method then save mthod call
        /// </summary>
        /// <returns></returns>
        public Responce Save()
        {
            try
            {
                using (var db = _connFactory.OpenDbConnection())
                {
                    // add operation condition
                    if(EnumType.A == Type)
                    {
                        // insert 
                        db.Insert(_objProductPOCO);
                        // give responce
                        _objResponce.Message = "data addes";
                        _objResponce.Data = _objProductPOCO;
                    }
                    // edit operation condition
                    if (EnumType.E == Type)
                    {
                        // update method for poco model 
                        db.Update(_objProductPOCO);
                        // return responce object 
                        _objResponce.Message = "data updated";
                        _objResponce.Data = _objProductPOCO;
                    }
                }
            }
            // handle catch block for global error handler 
            catch (Exception e)
            {
                // give responce for error handler 
                _objResponce.IsError = true;
                _objResponce.Message = "error from global handler :  " + e.Message;
            }

            return _objResponce;
        }
    }
}