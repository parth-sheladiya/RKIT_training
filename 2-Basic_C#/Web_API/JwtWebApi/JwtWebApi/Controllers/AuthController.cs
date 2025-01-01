using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using JwtWebApi.Models;

namespace JwtWebApi.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/auth/login")]
        public IHttpActionResult Login([FromBody] UserLogin user)
        {
            if (user.Username != "admin" || user.Password != "password")
                return Unauthorized();

            var token = GenerateJwtToken(user.Username);
            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(string username)
        {
            var key = Encoding.UTF8.GetBytes("Your32BytesLongSecretKeyHere12345!");
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Admin")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
