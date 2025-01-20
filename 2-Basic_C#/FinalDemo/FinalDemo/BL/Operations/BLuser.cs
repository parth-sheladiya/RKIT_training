using FinalDemo.BL.Interface;
using FinalDemo.Extension;
using FinalDemo.Models;
using FinalDemo.Models.DTO;
using FinalDemo.Models.ENUM;
using FinalDemo.Models.POCO;
using Org.BouncyCastle.Ocsp;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace FinalDemo.BL.Operations
{
    public class BLuser : IDataHandler<UserDto>
    {
        private User _objUser;
        private Responce _objResponce;
        private IDbConnectionFactory _dbfactory;
        int _id;
        public EnmRoleType roleType;
        public EnumType Type { get; set; }
        public BLuser()
        {
            _objUser = new User();
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
                    var res = db.Select<User>();

                    if (res.Count == 0)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "No data found";
                    }
                    else
                    {

                        // success responce 
                        _objResponce.Message = $"there are {res.Count} users available";

                    }

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

        public Responce GetUserById(int id)
        {
            try
            {
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    var userbyId = db.SingleById<User>(id);
                    if (userbyId == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "No data found";
                    }
                    else
                    {
                        _objResponce.IsError = false;
                        _objResponce.Data = userbyId;
                    }
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



        public Responce IsExists(int id)
        {
            try
            {
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    bool isExists = db.Exists<User>(u => u.userId == id);
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

        public void PreSave(UserDto objUserDto)
        {
            _objUser = objUserDto.ConvertTo<User>();
            _objUser.userPassword = BLencryption.GetEncryptPassword(_objUser.userPassword);

            if (Type == EnumType.E)
            {
                _id = objUserDto.userId;
            }

            if (objUserDto.Role != null)
            {
                _objUser.RoleType = objUserDto.Role; // Set the role from DTO to POCO
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
                    db.DeleteById<User>(id);  // Deleting the record by ID
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
        public User GetUser(string username, string password)
        {
            using (IDbConnection db = _dbfactory.OpenDbConnection())
            {
                var decrypt = BLencryption.GetEncryptPassword(password);
                return db.Single<User>(u => u.userName.Equals(username) && u.userPassword.Equals(decrypt));
            }
        }

        public User GetUser(int id)
        {
            using (IDbConnection db = _dbfactory.OpenDbConnection())
            {
                return db.SingleById<User>(id);
            }
        }

        public Responce GetData()
        {
            try
            {
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    List<User> lstUser = db.Select<User>();
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


        public Responce Add(User newUser)
        {
            try
            {
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {

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


        public Responce Update(int userId, User newUser)
        {
            try
            {
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    // If userId is provided in method parameter, override newUser.userId
                    if (userId > 0)
                    {
                        newUser.userId = userId;
                    }

                    // Check if ID is provided and valid
                    if (newUser.userId <= 0)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "ID not found or invalid.";
                        return _objResponce;
                    }

                    // Ensure that the user exists before updating
                    var existingUser = db.SingleById<User>(newUser.userId);
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