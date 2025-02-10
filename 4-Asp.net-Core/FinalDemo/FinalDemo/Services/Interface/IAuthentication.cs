using FinalDemo.Models.ENUM;
using System.Security.Claims;

namespace FinalDemo.Services.Interface
{
    public interface IAuthentication
    {
        string GenerateJwtToken(string username, EnumRole role, int userId);

        ClaimsPrincipal ValidateToken(string token);
    }
}
