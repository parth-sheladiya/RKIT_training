using FinalDemo.Handler;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FinalDemo.Filter
{
    /// <summary>
    /// is inherit from AuthorizationFilterAttribute
    /// it is check to userrole  and auth check
    /// </summary>
    public class JwtFilter : AuthorizationFilterAttribute
    {
        // it is store to roles
        private readonly string[] _allowedRoles;

        public JwtFilter(params string[] roles)
        {
            _allowedRoles = roles;
        }

        /// <summary>
        /// Checks the presence and validity of the JWT token and validates user roles.
        /// onauth is work to auth 
        /// </summary>
        /// <param name="actionContext">it is obj </param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // Check if the Authorization header is present or not
            if (actionContext.Request.Headers.Authorization == null ||
                string.IsNullOrWhiteSpace(actionContext.Request.Headers.Authorization.Parameter))
            {
                // if headers is null 
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Missing or invalid token.");
                return;
            }

            // if headers is not null and assign token
            string token = actionContext.Request.Headers.Authorization.Parameter;

            try
            {
                ClaimsPrincipal principal = JwtHandler.ValidateJwtToken(token);
                // Validate the JWT token
                if (principal == null)
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid or expired token.");
                    return;
                }

                // Extract role from the token
                string userRole = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                if (string.IsNullOrEmpty(userRole))
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Role information missing in token.");
                    return;
                }

                // Check if the user's role is allowed
                // chek user role
                if (_allowedRoles != null && _allowedRoles.Length > 0 && !_allowedRoles.Contains(userRole, StringComparer.OrdinalIgnoreCase))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden, "Access denied.");
                    return;
                }

            }
            catch (Exception ex)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, $"Invalid token. Error: {ex.Message}");
            }
        }
    }
}