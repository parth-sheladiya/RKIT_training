﻿using JwtToken.TokenHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace JwtToken.Filters
{
    public class JwtAuthFilter : AuthorizationFilterAttribute
    {
        private readonly string[] _allowedRoles;

        /// <summary>
        /// Initializes the JWTAuthorizationFilter with the allowed roles.
        /// </summary>
        /// <param name="roles">The roles allowed to access the resource.</param>
        public JwtAuthFilter(params string[] roles)
        {
            _allowedRoles = roles;
        }


        /// <summary>
        /// Checks the presence and validity of the JWT token and validates user roles.
        /// </summary>
        /// <param name="actionContext">The context of the current HTTP action.</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {



            // Check if the Authorization header is present
            if (actionContext.Request.Headers.Authorization == null ||
                string.IsNullOrWhiteSpace(actionContext.Request.Headers.Authorization.Parameter))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Missing or invalid token.");
                return;
            }
            string token = actionContext.Request.Headers.Authorization.Parameter;

            try
            {
                var principal = JwtHandler.ValidateJwtToken(token);
                // Validate the JWT token
                if (principal == null)
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid or expired token.");
                    return;
                }

                // Extract role from the token
                var userRole = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                if (string.IsNullOrEmpty(userRole))
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Role information missing in token.");
                    return;
                }

                // Check if the user's role is allowed
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