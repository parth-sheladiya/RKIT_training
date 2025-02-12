using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net;
using System.Security.Claims;

namespace FinalDemo.Filters
{
    /// <summary>
    /// custom filter for user roles
    /// IAuthorizationFilter is interface to use custom auth 
    /// </summary>
    public class AuthFilter : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public AuthFilter(params string[] roles)
        {
            // if role not pass then return null
            _roles = roles.Length > 0 ? roles : null;
        }

        /// <summary>
        /// authentication  authorization validate
        /// </summary>
        /// <param name="context"></param>
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

            // Check if user is authenticated or not
            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new ObjectResult("token is missing or invalid.")
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };
                return;
            }

            // role auth check
            var roleClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (roleClaim == null || (_roles != null && !_roles.Contains(roleClaim)))
            {
                context.Result = new ObjectResult("access denied")
                {
                    StatusCode = (int)HttpStatusCode.Forbidden
                };
            }
        }
    }
}
