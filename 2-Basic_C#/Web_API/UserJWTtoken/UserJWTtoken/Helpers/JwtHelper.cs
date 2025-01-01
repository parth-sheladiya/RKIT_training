using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace UserJwtToken.Helpers
{
    public static class JwtHelper
    {
        private const string SecretKey = "ParthSheladiya12345678901234567890"; // Replace with a strong key
        public static string GenerateToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] { new Claim(ClaimTypes.Name, username) };

            var token = new JwtSecurityToken(
                issuer: "https://localhost:44306/",
                audience: "https://localhost:44306/",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}