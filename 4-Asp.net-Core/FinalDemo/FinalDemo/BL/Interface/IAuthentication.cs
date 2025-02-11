using FinalDemo.Models.ENUM;
using FinalDemo.Models.POCO;
using System.Security.Claims;

namespace FinalDemo.BL.Interface
{
    public interface IAuthentication
    {
        string GenerateJwtToken(USR01 objUSR01);

        ClaimsPrincipal ValidateToken(string token);
    }
}
