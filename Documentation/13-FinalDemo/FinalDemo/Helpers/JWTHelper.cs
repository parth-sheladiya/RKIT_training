using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using FinalDemo.Models.ENUM;
using ServiceStack.Auth;
using System.Security.Cryptography;

namespace FinalDemo.Helpers
{
    /// <summary>
    ///generating and validating jwt tokens.
    /// </summary>
    public class JWTHelper
    {
        /// <summary>
        ///  secret key it is  used to token validation.
        /// </summary>
        private const string SecretKey = "parthsheladiya123456789sheladiyaparth";

        /// <summary>
        /// validates the jwt token and returns the claimsprincipal if valid.
        /// </summary>
        /// <param name="token">the jwt token to be validated.</param>
        /// <returns>a claimsprincipal if the token is valid, otherwise null.</returns>
        public static ClaimsPrincipal ValidateJwtToken(string token)
        {
            // generate symmetric security key
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

            // create jwt security token handler
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            try
            {
                // define token validation parameters
                var parameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = "Issuer",
                    ValidAudience = "Audience",
                    IssuerSigningKey = key
                };

                SecurityToken validatedToken;
                ClaimsPrincipal principal = handler.ValidateToken(token, parameters, out validatedToken);

                return principal; // return validated claims principal
            }
            catch
            {
                return null; // invalid token
            }
        }

        /// <summary>
        /// generates a jwt token for the specified username, with role claim and expiration.
        /// </summary>
        /// <param name="username">the username for which the token is being generated.</param>
        /// <param name="role">the role to assign to the user in the token.</param>
        /// <param name="userId">the user id associated with the token.</param>
        /// <returns>a string representing the generated jwt token.</returns>
        public static string GenerateJwtToken(string username, EnmRoleType role, int userId)
        {
            // convert enum to string
            string roleString = role.ToString();

            // create the claims for the token
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier , userId.ToString()),
                new Claim(ClaimTypes.Role, roleString) 
            };

            // generate symmetric security key
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

            // create signing credentials
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // create jwt token
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "Issuer",
                audience: "Audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            // return generated token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// extracts user id from the given jwt token.
        /// </summary>
        /// <param name="token">the jwt token.</param>
        /// <returns>returns user id as an integer.</returns>
        /// <exception cref="UnauthorizedAccessException">error.</exception>
        public static int GetUserIdFromToken(string token)
        {
            // create jwt security token handler
            JwtSecurityTokenHandler objJwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            // read token as jwt security token
            JwtSecurityToken jsonToken = objJwtSecurityTokenHandler.ReadToken(token) as JwtSecurityToken;

            // check if token is valid
            if (jsonToken == null)
            {
                throw new UnauthorizedAccessException("invalid jwt token.");
            }

            // get the user id claim from the token
            Claim userIdClaim = jsonToken?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            // return user id if found
            if (userIdClaim != null)
            {
                return int.Parse(userIdClaim.Value);
            }

            // throw exception if user id is missing
            throw new UnauthorizedAccessException("user id not found in the token.");
        }
    }
}
