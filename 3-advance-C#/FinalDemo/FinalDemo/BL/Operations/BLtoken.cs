using FinalDemo.Models.POCO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using FinalDemo.Models.ENUM;

namespace FinalDemo.BL.Operations
{
    public class BLtoken
    {
        #region Private Fields

        /// <summary>
        /// The secret key used for signing and validating JWT tokens
        /// </summary>
        private const string secretKey = "thisissecuritykeyofcustomjwttokenaut";

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Generates a JWT Token for the specified user.
        /// </summary>
        /// <param name="sessionId">Session id for one user login authentication.</param>
        /// <param name="objUser">Contains the information of the user.</param>
        /// <returns>
        /// JWT Token
        /// </returns>
        public string GenerateToken(Guid sessionId, User objUser)
        {
            DateTime createdAt = DateTime.Now;
            DateTime expires = createdAt.AddDays(7);

            JwtSecurityTokenHandler jwtSecurity = new JwtSecurityTokenHandler();
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                new Claim[]
                {
                    new Claim("SessionId", sessionId.ToString()),
                    new Claim(ClaimTypes.Role ,objUser.RoleType.ToString())
                });

            string issuer = "CustomJWTBearerTokenAPI";

            // Creating SymmetricSecurityKey and SigningCredentials
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretKey));

            SigningCredentials credentials = new SigningCredentials(symmetricSecurityKey,
                SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = jwtSecurity.CreateJwtSecurityToken(
                issuer: issuer,
                audience: issuer,
                subject: claimsIdentity,
                issuedAt: createdAt,
                expires: expires,
                signingCredentials: credentials);

            return jwtSecurity.WriteToken(token);
        }

        #endregion Public Methods
    }
}