using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace JwtToken.TokenHandler
{
    public class JwtHandler
    {
        private const string SecretKey = "parthpatelpatelparthparthpatelparth"; // The secret key used for token validation.

        /// <summary>
        /// validate jwt token and return ClaimsPrincipal if valid credentials
        /// </summary>
        /// <param name="token">The JWT token to be validated.</param>
        /// <returns>A ClaimsPrincipal if the token is valid, otherwise null.</returns>
        public static ClaimsPrincipal ValidateJwtToken(string token)
        {
            // it is validation with secret key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            // create built in obj. it is handle to jwttoken
            var handler = new JwtSecurityTokenHandler();

            // main validation parameters
            try
            {
                var parameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = "Issuer",
                    ValidAudience = "Audience",
                    // it is key to assign token
                    IssuerSigningKey = key
                };
                // it is variable to store validate topken
                SecurityToken validatedToken;
                // it is method . it is use to validate token 
                // if token is valid then return to claims principal
                // otherwise return null
                var principal = handler.ValidateToken(token, parameters, out validatedToken);

                return principal;
            }
            catch
            {
                return null; // Invalid token
            }
        }

        /// <summary>
        /// it is generate token method
        /// </summary>
        /// <param name="username">The username for which the token is being generated.</param>
        /// <returns>A string representing the generated JWT token.</returns>
        public static string GenerateJwtToken(string username)
        {
            // it is arr to store username and role
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, "Admin") // Example of adding a role claim
        };
            // security key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            // it is use to sign token
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // create jwt security token
            var token = new JwtSecurityToken(
                issuer: "Issuer",
                audience: "Audience",
                // claim arr to store user credentials
                claims: claims,
                // expire time
                expires: DateTime.Now.AddMinutes(30),
                // credentials to sigin the token
                signingCredentials: creds
            );
            // return token to string format
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}