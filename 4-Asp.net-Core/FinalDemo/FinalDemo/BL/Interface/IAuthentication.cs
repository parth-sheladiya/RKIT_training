﻿using FinalDemo.Models.DTO;
using FinalDemo.Models.ENUM;
using FinalDemo.Models.POCO;
using System.Security.Claims;

namespace FinalDemo.BL.Interface
{
    /// <summary>
    /// interface
    /// </summary>
    public interface IAuthentication
    {
        /// <summary>
        /// generte token methiod
        ///  username, userId, aur role store
        /// </summary>
        /// <param name="objUSR01">user</param>
        /// <returns></returns>
        string GenerateJwtToken(USR01 objUSR01);

        /// <summary>
        /// validate token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        ClaimsPrincipal ValidateToken(string token);

        public USR01 AuthCred(DTOAUTH objDTOAuth);
        public int GetLoggedInUserId(string token);
    }
}
