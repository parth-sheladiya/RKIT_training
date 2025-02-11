using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net;
using System.Security.Claims;

namespace FinalDemo.Filters
{
    /// <summary>
    /// Custom authorization filter using JWT role-based authentication.
    /// </summary>
    public class AuthFilter : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public AuthFilter(params string[] roles)
        {
            _roles = roles.Length > 0 ? roles : null;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            // Check if AllowAnonymous is present, then skip authorization
            bool hasAllowAnonymous = context.ActionDescriptor.EndpointMetadata
                .OfType<Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute>().Any();

            if (hasAllowAnonymous)
            {
                return;
            }

            // Check if user is authenticated
            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new ObjectResult("Unauthorized: Token is missing or invalid.")
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };
                return;
            }

            // Retrieve user role from claims
            var roleClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (roleClaim == null || (_roles != null && !_roles.Contains(roleClaim)))
            {
                context.Result = new ObjectResult("Forbidden: Access Denied.")
                {
                    StatusCode = (int)HttpStatusCode.Forbidden
                };
            }
        }
    }
}
