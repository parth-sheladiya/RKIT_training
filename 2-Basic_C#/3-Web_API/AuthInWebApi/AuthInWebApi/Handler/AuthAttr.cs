﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AuthInWebApi.Handler
{
    public class AuthAttr : AuthorizationFilterAttribute
    {
        /// <summary>
        /// OnAuthorization method is called during the authorization process. It checks the presence of an Authorization header,
        /// validates the credentials, and sets the current principal if authorized, otherwise responds with Unauthorized status.
        /// </summary>
        /// <param name="actionContext">The action context containing the request and response details.</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] credentialsValues = credentials.Split(':');
                string username = credentialsValues[0];
                string password = credentialsValues[1];

                if (IsAuthorizedUser(username, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }

        /// <summary>
        /// Validates the provided username and password to check if the user is authorized.
        /// </summary>
        /// <param name="username">The username provided in the request.</param>
        /// <param name="password">The password associated with the username.</param>
        /// <returns>True if the user is authorized, false otherwise.</returns>
        private bool IsAuthorizedUser(string username, string password)
        {
            // Replace this with actual validation logic, such as checking against a database
            return username == "admin" && password == "password";
        }
    }
}