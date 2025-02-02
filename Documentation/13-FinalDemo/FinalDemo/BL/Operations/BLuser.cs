using FinalDemo.BL.Interface;
using FinalDemo.Extension;
using FinalDemo.Models;
using FinalDemo.Models.DTO;
using FinalDemo.Models.ENUM;
using FinalDemo.Models.POCO;
using Org.BouncyCastle.Ocsp;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace FinalDemo.BL.Operations
{
    /// <summary>
    /// business logic implementation
    /// </summary>
    public class BLuser : IDataHandler<DTOUSR01>
    {
        /// <summary>
        /// user pooco
        /// </summary>
        private USR01 _objUser;

        /// <summary>
        /// response object
        /// </summary>
        private Responce _objResponce;

        /// <summary>
        ///  data base connection 
        /// </summary>
        private IDbConnectionFactory _dbfactory;
        int _id;

        /// <summary>
        /// role ype
        /// </summary>
        public EnmRoleType roleType;
        public EnumType Type { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <exception cref="Exception"></exception>
        public BLuser()
        {
            _objUser = new USR01();
            _objResponce = new Responce();
            _dbfactory = HttpContext.Current.Application["Dbfactory"] as IDbConnectionFactory;

            if (_dbfactory == null)
            {
                throw new Exception("Db Connection not found");
            }
        }

        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        public Responce GetAll()
        {
            try
            {
             // open data base  
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    // select list of user data
                    List<USR01> res = db.Select<USR01>();

                    // if no user found
                    if (res.Count == 0)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "No data found";
                    }

                    // if user found
                    else
                    {

                        // success responce 
                        _objResponce.Message = $"there are {res.Count} users available";

                    }
                    // no error
                    _objResponce.IsError = false;
                    _objResponce.Data = res;
                    return _objResponce;
                }
            }
            catch (Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = $"error for get all users: {ex.Message}";
                return _objResponce;
            }
        }

        /// <summary>
        /// get user by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Responce GetUserById(int id)
        {
            try
            {
                // open data base 
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    // single data found
                    var userbyId = db.SingleById<USR01>(id);

                    // if not found
                    if (userbyId == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "No data found";
                    }

                    // user found
                    else
                    {
                        _objResponce.IsError = false;
                        _objResponce.Data = userbyId;
                    }

                    // no error
                    _objResponce.IsError = false;
                    _objResponce.Data = userbyId;
                }

            }
            catch (Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = $"error for get user by id: {ex.Message}";
            }

            return _objResponce;
        }

        // get user specific profile
        public Responce GetProfile(int userId)
        {
            try
            {
                // open datavase
                using (var db = _dbfactory.OpenDbConnection())
                {
                    // user specific data
                    List<USR01> result = db.Select<USR01>(u => u.R01F01 == userId).ToList(); 

                    // nno eerror
                    _objResponce.IsError = false;
                    _objResponce.Data = result;
                    _objResponce.Message = "User get successfully";
                }
            }
            catch (Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = ex.Message;
            }
            return _objResponce;
        }


        /// <summary>
        ///  user check it is found or not by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Responce IsExists(int id)
        {
            try
            {
                // open databse
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    // found or not
                    bool isExists = db.Exists<USR01>(u => u.R01F01 == id);
                    if (isExists)
                    {
                        _objResponce.IsError = false;
                        _objResponce.Message = $"user with ID  {id} does not exists";
                    }
                    else
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = $"user with ID {id} exists";
                    }
                }
            }
            catch (Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = $"error for check user exists: {ex.Message}";
            }

            return _objResponce;
        }
        public bool IsAdminExists()
        {
            try
            {
                // open databse
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    // check it is admin or not
                    bool isAdmin = db.Exists<USR01>(u => u.R01F07 == EnmRoleType.Admin);
                    return isAdmin;
                }
            }
            catch(Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = $"error for check admin exists: {ex.Message}";
            }

            return false;
        }

        /// <summary>
        /// before save method like user data is valid
        /// </summary>
        /// <param name="objUserDto"></param>
        public void PreSave(DTOUSR01 objUserDto)
        {
            _objUser = objUserDto.ConvertTo<USR01>();

            // encrypt password field
            _objUser.R01F04 = BLencryption.GetEncryptPassword(_objUser.R01F04);

            // edit 
            if (Type == EnumType.E)
            {
                _id = objUserDto.R01F01;
            }

            // add
            if(Type == EnumType.A)
            {
                if(IsAdminExists() && objUserDto.R01F07 == EnmRoleType.Admin)
                {
                    _objResponce.IsError = true;
                    _objResponce.Message = "only one admin allow in our store";
                }
            }
            if (objUserDto.R01F07 != null)
            {
                // Set the role from DTO to POCO
                _objUser.R01F07 = objUserDto.R01F07; 
            }
            else
            {
                // Handle other cases if needed
                _id = 0;
            }
        }

        /// <summary>
        /// validation method
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
        /// prevalidation on delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Responce PreValidationOnDelete(int id)
        {
            if (EnumType.D == Type)
            {
                // id must be greater than 0
                if (!(id > 0))
                {
                    _objResponce.IsError = true;
                    _objResponce.Message = "ID must be greater than 0";
                    return _objResponce;
                }
                else if ((IsExists(id).IsError))
                {
                    _objResponce.IsError = true;
                    _objResponce.Message = "ID not found";
                    return _objResponce;
                }
            }

            _objResponce.IsError = false;
            return _objResponce;
        }

        /// <summary>
        ///delete method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Responce Delete(int id)
        {
            // Pre-validation check before deletion
            var validateResponce = PreValidationOnDelete(id);

            // If validation fails, return the response with error message
            if (validateResponce.IsError)
            {
                return validateResponce;
            }

            // Check if the record exists before attempting to delete
            if (IsExists(id).IsError)
            {
                _objResponce.IsError = true;
                _objResponce.Message = "ID not found, cannot delete.";
                _objResponce.Data = null;
                return _objResponce;
            }

            // Get user details
            var user = GetUser(id);
            if (user != null && user.R01F07 == EnmRoleType.Admin)
            {
                _objResponce.IsError = true;
                _objResponce.Message = "Admin cannot be deleted.";
                _objResponce.Data = null;
                return _objResponce;
            }

            // Proceed with deletion if ID exists
            // open databse
            using (var db = _dbfactory.OpenDbConnection())
            {
                try
                {
                    // Check if any order for the user is in pending status
                    var pendingOrderExists = db.Exists<ORD01>(o => o.R01F01 == id && o.D01F06.ToLower() == "pending");
                    if (pendingOrderExists)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "User cannot be deleted as there are pending orders.";
                        return _objResponce;
                    }

                    // Delete the user if no pending orders exist
                    db.DeleteById<USR01>(id);
                }
                catch (Exception ex)
                {
                    _objResponce.IsError = true;
                    _objResponce.Message = $"Error while deleting data: {ex.Message}";
                  
                    return _objResponce;
                }
            }

            // Success response after deletion
            _objResponce.IsError = false;
            _objResponce.Message = "Data deleted successfully";
            
            return _objResponce;
        }


        /// <summary>
        /// save method
        /// </summary>
        /// <returns></returns>
        public Responce Save()
        {
            try
            {
                // open databse
                using (var db = _dbfactory.OpenDbConnection())
                {
                    // add operation condition
                    if (EnumType.A == Type)
                    {
                        // insert 
                        db.Insert(_objUser);
                        // give responce
                        _objResponce.Message = "data addes";
                        _objResponce.Data = _objUser;
                    }
                    // edit operation condition
                    if (EnumType.E == Type)
                    {
                        // update method for poco model 
                        db.Update(_objUser);
                        // return responce object 
                        _objResponce.Message = "data updated";
                        _objResponce.Data = _objUser;
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
        /// get user method
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public USR01 GetUser(string username, string password)
        {
            // open databse
            using (IDbConnection db = _dbfactory.OpenDbConnection())
            {
                var decrypt = BLencryption.GetEncryptPassword(password);
                return db.Single<USR01>(u => u.R01F02.Equals(username) && u.R01F04.Equals(decrypt));
            }
        }

        public USR01 GetUser(int id)
        {
            // open databse
            using (IDbConnection db = _dbfactory.OpenDbConnection())
            {
                return db.SingleById<USR01>(id);
            }
        }

        public Responce GetData()
        {
            try
            {
                // open databse
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    List<USR01> lstUser = db.Select<USR01>();
                    _objResponce.IsError = false;
                    _objResponce.Data = lstUser;
                }
                return _objResponce;
            }
            catch (Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = ex.Message;
                return _objResponce;
            }
        }


        public Responce Add(USR01 newUser)
        {
            try
            {
                // open databse
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    // check admin is exist or not 
                    

                    db.Insert(newUser);
                }
                _objResponce.IsError = false;
                _objResponce.Data = newUser;
                _objResponce.Message = "User Added Successfully";
            }
            catch (Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = $"data not added {ex.Message}";
            }

            return _objResponce;
        }


        public Responce Update(int userId, USR01 newUser)
        {
            try
            {
                // open databse
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    // If userId is provided in method parameter, override newUser.userId
                    if (userId > 0)
                    {
                        newUser.R01F01 = userId;
                    }

                    // Check if ID is provided and valid
                    if (newUser.R01F01 <= 0)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "ID not found or invalid.";
                        return _objResponce;
                    }

                    // Ensure that the user exists before updating
                    var existingUser = db.SingleById<USR01>(newUser.R01F01);
                    if (existingUser == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "User does not exist.";
                        return _objResponce;
                    }

                    // Update the user
                    db.Update(newUser);
                }
                _objResponce.IsError = false;
                _objResponce.Data = newUser;
                _objResponce.Message = "User Updated Successfully";
            }
            catch (Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = $"Data not Updated: {ex.Message}";
            }

            return _objResponce;
        }




    }
}