using FinalDemo.Models.DTO;
using FinalDemo.Models.ENUM;
using FinalDemo.Models.POCO;
using FinalDemo.BL.Interface;
using Microsoft.IdentityModel.Tokens;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinalDemo.BL.Operations
{
    /// <summary>
    /// it is for generate token and  validate token
    /// </summary>
    public class BLAuth : IAuthentication
    {
        
        private readonly IConfiguration _configuration;
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly IDbConnectionFactory _dbFactory;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="configuration">it is for aap </param>
        /// <param name="tokenHandler"></param>
        /// <param name="dbFactory"></param>
        public BLAuth(IConfiguration configuration, IDbConnectionFactory dbFactory)
        {
            _configuration = configuration;
            _tokenHandler = new JwtSecurityTokenHandler();
            _dbFactory = dbFactory;
        }

        public string GenerateJwtToken(USR01 objUSR01)
        {
            // name role and id store in claims
            string username = objUSR01.R01F02;
            string roleString = objUSR01.R01F07.ToString();
            int userId = objUSR01.R01F01;

            // appsetting.json through work
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = _configuration["Jwt:Key"];

            // defines claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier , userId.ToString()),
                new Claim(ClaimTypes.Role, roleString)
            };

            // token sign and encrypt
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // generate tokern
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return _tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// validate token if valid othrewrwise null
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public ClaimsPrincipal ValidateToken(string token)
        {
            try
            {
                //appsetting.json through work
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var key = _configuration["Jwt:Key"];

               
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
                // token validate
                ClaimsPrincipal claimsPrincipal = _tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                return claimsPrincipal;
            }
            // if token is invalid
            catch (SecurityTokenException ex)
            {
                Console.WriteLine($"Token validation failed: {ex.Message}");
                return null;
            }
        }
        /// <summary>
        /// chewck user credsss
        /// </summary>
        /// <param name="objDTOAuth"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public USR01 AuthCred(DTOAUTH objDTOAuth)
        {
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                var UserDetails = db.Single<USR01>(lUser => lUser.R01F02 == objDTOAuth.R01F02 && lUser.R01F04 == objDTOAuth.R01F04);

                if (UserDetails == null)
                {
                    Console.WriteLine("User not found.");
                    return null;
                }

                return UserDetails;
            }
        }

        /// <summary>
        /// user specific operations
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int GetLoggedInUserId(string token)
        {
            // validate token
            var claimsPrincipal = ValidateToken(token);
            if (claimsPrincipal == null)
            {
                throw new Exception("Invalid Token");
            }

            // find user id and it is string formate
            var userIdClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                throw new Exception("UserId claim not found in token");
            }

            // string to int  id 
            if (int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;  
            }

            throw new Exception("Invalid UserId format in token");
        }


    }
}
