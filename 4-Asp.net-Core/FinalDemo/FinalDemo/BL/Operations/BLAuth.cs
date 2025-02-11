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
    public class BLAuth : IAuthentication
    {
        private readonly IConfiguration _configuration;
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly IDbConnectionFactory _dbFactory;

        public BLAuth(IConfiguration configuration, JwtSecurityTokenHandler tokenHandler, IDbConnectionFactory dbFactory)
        {
            _configuration = configuration;
            _tokenHandler = tokenHandler;
            _dbFactory = dbFactory;
        }

        public string GenerateJwtToken(USR01 objUSR01)
        {
            string username = objUSR01.R01F02;
            string roleString = objUSR01.R01F07.ToString();
            int userId = objUSR01.R01F01;

            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = _configuration["Jwt:Key"];

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier , userId.ToString()),
                new Claim(ClaimTypes.Role, roleString)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return _tokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal ValidateToken(string token)
        {
            try
            {
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

                ClaimsPrincipal claimsPrincipal = _tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                return claimsPrincipal;
            }
            catch (SecurityTokenException ex)
            {
                Console.WriteLine($"Token validation failed: {ex.Message}");
                return null;
            }
        }

        public USR01 AuthCred(DTOAUTH objDTOAuth)
        {
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                if (db == null)
                {
                    throw new Exception("Database connection failed. Check DB connection settings.");
                }

                Console.WriteLine("Database connection successful.");

                var result = db.Single<USR01>(u => u.R01F02 == objDTOAuth.R01F02 && u.R01F04 == objDTOAuth.R01F04);

                if (result == null)
                {
                    Console.WriteLine("User not found.");
                    return null;
                }

                return result;
            }
        }


        public int GetLoggedInUserId(string token)
        {
            var claimsPrincipal = ValidateToken(token);
            if (claimsPrincipal == null)
            {
                throw new Exception("Invalid Token");
            }

            var userIdClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                throw new Exception("UserId claim not found in token");
            }

            // Safe integer conversion with error handling
            if (int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;  // Integer UserId return karega
            }

            throw new Exception("Invalid UserId format in token");
        }


    }
}
