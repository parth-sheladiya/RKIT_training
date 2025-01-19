using FinalDemo.Extension;
using FinalDemo.Models;
using FinalDemo.Models.DTO;
using FinalDemo.Models.ENUM;
using FinalDemo.Models.POCO;
using Microsoft.IdentityModel.Tokens;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Legacy;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace FinalDemo.BL.Operations
{
    /// <summary>
    /// method implementation
    /// </summary>
    public class AuthHandler
    {
        // db connection factory
        private readonly IDbConnectionFactory _connFactory;

        // JWT secret key it is 48 bytes long
        private const string SecretKey = "ThisIsASecretKeyThisIsASecretKeyThisIsASecretKey";

        // JWT token expiry time in minutes
        private readonly int _jwtExpireMinutes = 50;

        // create object to Responce class
        public Responce _objResponce = new Responce();

        // create object to User class poco
        public User _objectPocoUser = new User();

        /// <summary>
        /// constructor of AuthHandler
        /// in this constructor it is set a connection factory
        /// </summary>
        public AuthHandler()
        {
            //  db connection factory 
            _connFactory = HttpContext.Current.Application["DbFactory"] as IDbConnectionFactory;

            // check connection is exist or not
            if (_connFactory == null)
            {
                _objResponce.IsError = true;
                _objResponce.Message = "connection not found ";
            }

            _objResponce = new Responce();
        }

        /// <summary>
        /// registration method implementation
        /// </summary>
        /// <param name="userDto">it is dto class object </param>
        /// <returns></returns>
        public string RegisterUser(UserDto userDto)
        {
            // open db connection and process it 
            using (var db = _connFactory.OpenDbConnection())
            {
                // user check if user already exists
                var existingUser = db.Single<User>(x => x.Email == userDto.Email);

                // if user is exists
                if(existingUser != null)
                {
                    _objResponce.IsError = true;
                    _objResponce.Message = "User already exists.";
                   
                }

                // Check if there is already an admin in the system
                var adminCount = db.Count<User>(x => x.Role == RoleEnum.Admin);

                if (adminCount >= 1 && userDto.Role == RoleEnum.Admin)
                {
                    _objResponce.IsError = true;
                    _objResponce.Message = "Only one admin is allowed in the system.";
                    return _objResponce.Message;
                }

                // convert dto to poco 
                _objectPocoUser = userDto.ConvertTo<User>();


                try
                {
                    // insert user into database
                    db.Insert(_objectPocoUser);

                    // set response message
                    _objResponce.IsError = false;
                    _objResponce.Message = "User registered successfully.";
                    _objResponce.Data = _objectPocoUser;
                }
                catch (Exception ex)
                {
                    // set response message
                    _objResponce.IsError = true;
                    _objResponce.Message = $"Error: {ex.Message}";
                    
                }

                // if error is true then return message
                return _objResponce.Message;
            }
        }

        /// <summary>
        /// login method implementation
        /// </summary>
        /// <param name="authDto">it is authdto class </param>
        /// <returns></returns>
        public Responce AuthenticateUser(AuthDto authDto)
        {
            try
            {
                // open db connection and process it
                using (var db = _connFactory.OpenDbConnection())
                {
                    // fetch user by email and password
                    var user = db.Single<User>(x => x.Email == authDto.Email && x.Password == authDto.Password);

                    // if user is null then return message
                    if (user == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "Invalid email or password.";
                    }
                    else
                    {
                        // set response message
                        _objResponce.IsError = false;
                        _objResponce.Message = "User logged in successfully.";
                        _objResponce.Data = new
                        {
                            Token = GenerateJwtToken(user),
                            UserDetails = user
                        };
                    }
                }
            }
            // if any exception is occur then return message
            catch (Exception ex)
            {
                _objResponce.IsError = true;
                _objResponce.Message = "An error occurred: " + ex.Message;
            }
            // return response message
            return _objResponce;
        }

        /// <summary>
        /// method to authorize user is admin as Admin
        /// </summary>
        /// <param name="userId">it is poco class userId</param>
        /// <returns>bool</returns>
        public bool AuthorizeAdmin(int userId)
        {
            try
            {
                // open db connection and process it
                using (var db = _connFactory.OpenDbConnection())
                {
                    // retrive user bu id
                    var user = db.Single<User>(x => x.Id == userId);

                    // user is null then return message
                    if (user == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "User not found.";
                        return false;
                    }

                   


                    // if not any error then return message
                    _objResponce.IsError = false;
                    _objResponce.Message = "User is authorized as Admin.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                // error handle globally
                _objResponce.IsError = true;
                _objResponce.Message = "An error occurred: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// method to authorize user is user as User 
        /// </summary>
        /// <param name="userId">it is poco class useID</param>
        /// <returns>oool</returns>
        public bool AuthorizerUser(int userId)
        {
            try
            {
                // open db connection and process it
                using (var db = _connFactory.OpenDbConnection())
                {
                    // retrive user by id
                    var user = db.Single<User>(x => x.Id == userId);

                    // Check if user exists
                    if (user == null)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "User not found.";
                        return false;
                    }


                    // Check if user is authorized as User
                    if (user.Role != RoleEnum.User)
                    {
                        _objResponce.IsError = true;
                        _objResponce.Message = "User does not have the required 'User' role.";
                        return false;
                    }

                    // All checks passed, user is authorized as User
                    _objResponce.IsError = false;
                    _objResponce.Message = "User is authorized.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                // eror handle globally
                _objResponce.IsError = true;
                _objResponce.Message = "An error occurred: " + ex.Message;
                return false;
            }
        }

        



        /// <summary>
        /// generate jwt token 
        /// </summary>
        /// <param name="user">it is poco class user object </param>
        /// <returns>token</returns>
        private string GenerateJwtToken(User user)
        {
            // claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            // key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // token
            var token = new JwtSecurityToken(
                issuer: "YourIssuer",
                audience: "YourAudience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtExpireMinutes),
                signingCredentials: creds
            );
            // return token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}