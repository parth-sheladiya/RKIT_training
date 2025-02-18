using FinalDemo.Models.DTO;
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

        /// <summary>
        /// user details chek
        /// </summary>
        /// <param name="objDTOAuth"></param>
        /// <returns></returns>
        public USR01 AuthCred(DTOAUTH objDTOAuth);

        /// <summary>
        /// get user details from token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public int GetLoggedInUserId(string token);
    }
}
