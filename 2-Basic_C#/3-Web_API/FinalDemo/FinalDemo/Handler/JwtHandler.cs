using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace FinalDemo.Handler
{
    public class JwtHandler
    {
        private const string SecretKey = "patelparthparthpatelpatelparthparthpatel"; // The secret key used for token validation.

        /// <summary>
        /// validate jwt token 
        /// </summary>
        /// <param name="token">token</param>
        /// <returns>if claim is correct to return token else null</returns>
        public static ClaimsPrincipal ValidateJwtToken(string token)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            try
            {
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

                return principal;
            }
            catch(Exception ex)
            {
                Console.WriteLine("error", ex.Message);
                return null;
            }
        }

        /// <summary>
        /// generate token
        /// </summary>
        /// <param name="username">The username for which the token is being generated.</param>
        /// <param name="role">The role to assign to the user in the token.</param>
        /// <returns>A string representing the generated JWT token.</returns>
        public static string GenerateJwtToken(string username, string role)
        {
            Claim[] claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role) 
        };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "Issuer",
                audience: "Audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}