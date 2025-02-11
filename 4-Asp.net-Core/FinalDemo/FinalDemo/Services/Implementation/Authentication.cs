using FinalDemo.Models.ENUM;
using FinalDemo.Services.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinalDemo.Services.Implementation
{
    public class Authentication : IAuthentication
    {
        private readonly IConfiguration _configuration;

        private readonly JwtSecurityTokenHandler _tokenHandler;

        public Authentication(IConfiguration configuration , JwtSecurityTokenHandler tokenHandler)
        {
            _configuration = configuration;
            _tokenHandler = new JwtSecurityTokenHandler();
        }
        public string GenerateJwtToken(string username, EnumRole role, int userId)
        {
            string roleString = role.ToString();

            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var Key = _configuration["Jwt:Key"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier , userId.ToString()),
                new Claim(ClaimTypes.Role, roleString)
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Token expires in 1 hour
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
                var Key = _configuration["Jwt:Key"];

                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(Key))
                };

                ClaimsPrincipal claimsPrincipal = _tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

                return claimsPrincipal;

            }
            catch (Exception ex)
            {
                // Handle token validation errors
                throw new Exception("Token validation failed.", ex);
            }
        }
    }
}
