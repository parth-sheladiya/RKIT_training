using FinalDemo.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo.BL.Interface
{
    /// <summary>
    /// it is interface of AuthHandler
    /// it is used for authentication and authorization , token generate method 
    /// </summary>
    public interface IAuthHandler
    {
        /// <summary>
        /// it is registration method declaration
        /// </summary>
        /// <param name="userDto">is is dto class object </param>
        /// <returns></returns>
        string RegisterUser(UserDto userDto);


        /// <summary>
        /// it is authentication method declaration
        /// </summary>
        /// <param name="authDto">it is authdto class object</param>
        /// <returns></returns>
        string AuthenticateUser(AuthDto authDto);


        /// <summary>
        /// it is authorization method declaration it is check user is admin ? 
        /// </summary>
        /// <param name="userId">poco class id userID</param>
        /// <returns></returns>
        bool AuthorizeAdmin(int userId);


        /// <summary>
        /// it is authorization method declaration it is check user is user or not ?
        /// </summary>
        /// <param name="userId">poco class id userId</param>
        /// <returns></returns>
        bool AuthorizeUser(int userId);          
    }
}