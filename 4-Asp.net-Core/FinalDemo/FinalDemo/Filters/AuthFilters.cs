using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net;
using System.Security.Claims;

namespace FinalDemo.Filters
{
    /// <summary>
    ///AuthFilter custom filter for user roles
    /// IAuthorizationFilter is interface to use custom auth 
    /// Attribute is use bcz it is apply on controller and method 
    /// </summary>
    public class AuthFilter : Attribute, IAuthorizationFilter
    {
        // user roles
        private readonly string[] _userRoles;

        public AuthFilter(params string[] userRoles)
        {
            // if role not pass then return null
            if (userRoles.Length > 0)
            {
                // assing role
                _userRoles = userRoles;
            }
            else
            {
               // if role not found
                _userRoles = null;
            }
        }

        /// <summary>
        /// authentication  authorization validate
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            // Check if AllowAnonymous is present in controlller then skip authorization
            bool UserIsAllowAnonymous = context.ActionDescriptor.EndpointMetadata
                .OfType<Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute>().Any();

            if (UserIsAllowAnonymous)
            {
                return;
            }

            // Check if user is authenticated or not
            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new ObjectResult("missing token ")
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };
                return;
            }

            // role auth check
            var roleClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (roleClaim == null || (_userRoles != null && !_userRoles.Contains(roleClaim)))
            {
                context.Result = new ObjectResult("access denied for this user role")
                {
                    StatusCode = (int)HttpStatusCode.Forbidden
                };
            }
        }
    }
}
