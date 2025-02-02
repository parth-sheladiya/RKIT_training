using FinalDemo.Helpers;
using FinalDemo.Models.ENUM;
using System.Linq;
using System.Net;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System;
using System.Net.Http;
using System.Security.Claims;

/// <summary>
/// jwt authorization filter class to handle authentication and role-based access control.
/// </summary>
public class JWTAuthorizationFilter : AuthorizationFilterAttribute
{
    /// <summary>
    /// allowed roles for the api endpoint.
    /// </summary>
    private readonly EnmRoleType[] _allowedRoles;

    /// <summary>
    /// constructor to initialize allowed roles.
    /// </summary>
    /// <param name="roles">roles allowed for access</param>
    public JWTAuthorizationFilter(params EnmRoleType[] roles)
    {
        _allowedRoles = roles;
    }

    /// <summary>
    /// method to handle authorization logic.
    /// </summary>
    /// <param name="actionContext">http action context</param>
    public override void OnAuthorization(HttpActionContext actionContext)
    {
        // check if authorization header is present
        if (actionContext.Request.Headers.Authorization == null ||
            string.IsNullOrWhiteSpace(actionContext.Request.Headers.Authorization.Parameter))
        {
            actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "missing or invalid token.");
            return;
        }

        // extract token from header
        string token = actionContext.Request.Headers.Authorization.Parameter;

        try
        {
            // validate jwt token
            ClaimsPrincipal principal = JWTHelper.ValidateJwtToken(token);

            // check if token is valid
            if (principal == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "invalid or expired token.");
                return;
            }

            // get user role from token claims
            string userRole = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            // check if role exists in token
            if (string.IsNullOrEmpty(userRole))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "role information missing in token.");
                return;
            }

            // convert role string to enum
            if (!Enum.TryParse(userRole, out EnmRoleType roleEnum))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "invalid role in token.");
                return;
            }

            // check if user role is allowed
            if (_allowedRoles != null && _allowedRoles.Length > 0 && !_allowedRoles.Contains(roleEnum))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden, "access denied.");
                return;
            }
        }
        catch (Exception ex)
        {
            actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, $"invalid token. error: {ex.Message}");
        }
    }
}
