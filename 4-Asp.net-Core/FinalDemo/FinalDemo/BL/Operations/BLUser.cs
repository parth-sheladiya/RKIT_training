using FinalDemo.BL.Interface;
using FinalDemo.Extention;
using FinalDemo.Models;
using FinalDemo.Models.DTO;
using FinalDemo.Models.ENUM;
using FinalDemo.Models.POCO;
using Microsoft.AspNetCore.Identity;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Data;


namespace FinalDemo.BL.Operations
{
    //public class BLUser : IUSR01, ICommonHandler<DTOUSR01>
    public class BLUser :  IBLUSR
    {
        // connetion factore
        private readonly IDbConnectionFactory _dbfactory;
        
        // response
        private Response _objResponse;
        public int _id;
        private USR01 _objUSR01;
        public EnumType typeOfOperation { get; set; }


        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="dbfactory">dbfactory</param>
        /// <param name="objResponse">objResponse</param>
       
        public BLUser(IDbConnectionFactory dbfactory, Response objResponse )
        {
            _dbfactory = dbfactory;
            _objResponse = objResponse;
            
            
        }

        /// <summary>
        /// get all user list
        /// </summary>
        /// <returns></returns>
        public Response GetAllUsers()
        {
            using (IDbConnection db = _dbfactory.OpenDbConnection())
            {
                // select list of user data
                List<USR01> res = db.Select<USR01>();

                // if no user found
                if (res.Count == 0)
                {
                    _objResponse.Data = null;
                    _objResponse.IsError = true;
                    _objResponse.Message = "No data found";
                }
                // if user found
                else
                {

                    // success responce 
                    _objResponse.Message = $"there are {res.Count} users available";
                    _objResponse.Data= res;

                }
                
                return _objResponse;
            }
        }

        /// <summary>
        /// get user by id 
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>user or null</returns>
        public Response GetUserByid(int id)
        {
            using (var db = _dbfactory.OpenDbConnection())
            {
                _objUSR01 = db.SingleById<USR01>(id);
            }

            if(_objUSR01 != null)
            {
                _objResponse.Data = _objUSR01;
                _objResponse.IsError = false;
                _objResponse.Message = "user id fetch successfully";
            }
            else
            {
                _objResponse.IsError = true;
                _objResponse.Message = "user id not found";

            }

            return _objResponse;

        }
        /// <summary>
        /// presave 
        /// </summary>
        /// <param name="objUsrDto">dto</param>
        public void PreSave(DTOUSR01 objUsrDto)
        {
            _objUSR01 = objUsrDto.Convert<USR01>();

            //edit
            if (typeOfOperation == EnumType.U)
            {
                _id = objUsrDto.R01F01;
            }
            if (typeOfOperation == EnumType.D)
            {
                _id = objUsrDto.R01F01;
            }

        }

        /// <summary>
        /// if user is exists or not
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsUSRExist(int id)
        {
            using (var db = _dbfactory.OpenDbConnection())
            {
                return db.Exists<USR01>(id);
            }
        }
        /// <summary>
        /// validation
        /// </summary>
        /// <returns></returns>
        public Response Validation()
        {
            if (typeOfOperation == EnumType.U) 
            {
                
                if (!IsUSRExist(_id))
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "user Not Found";
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
                    db.Insert(_objUSR01); 
                    _objResponse.Message = "User details Added successfully";
                }
                if (typeOfOperation == EnumType.U) 
                {
                    if (!IsUSRExist(_id))
                    {
                        _objResponse.IsError = true;
                        _objResponse.Message = "User ID not found";
                        return _objResponse;
                    }
                    db.Update(_objUSR01); 
                    _objResponse.Message = "USer Updated";
                }

                return _objResponse;
            }
        }

        /// <summary>
        /// update method
        /// </summary>
        /// <param name="loggedInUserId"></param>
        /// <returns></returns>
        public Response Update(int loggedInUserId)
        {
            using (var db = _dbfactory.OpenDbConnection())
            {
                var existingUser = db.SingleById<USR01>(_id);

                // ID Exist Check
                if (existingUser == null)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "User ID not found.";
                    return _objResponse;
                }

                //Unauthorized Access Check
                if (existingUser.R01F01 != loggedInUserId)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "you can not update other user profile";
                    return _objResponse;
                }

                db.Update(_objUSR01);
                _objResponse.Message = "User Updated";
            }

            return _objResponse;
        }

        /// <summary>
        /// delete method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="loggedInUserId"></param>
        /// <returns></returns>
        public Response Delete(int id , int loggedInUserId)
        {
            using (var db = _dbfactory.OpenDbConnection())
            {
                var existingUser = db.SingleById<USR01>(id);

                // ID Exist Check
                if (existingUser == null)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "User ID not found.";
                    return _objResponse;
                }
                // Check if any order for the user is in pending status
                var pendingOrderExists = db.Exists<ORD01>(o => o.R01F01 == id && o.D01F06.ToLower() == "pending");
                if (pendingOrderExists)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "User cannot deleted there are pending orders.";
                    return _objResponse;
                }
                // Unauthorized Access Check
                if (existingUser.R01F01 != loggedInUserId)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "you can not update other user profile";
                    return _objResponse;
                }

                db.Delete(existingUser);
                _objResponse.Message = "User deleted successfully.";
            }

            return _objResponse;
        }



    }
}
