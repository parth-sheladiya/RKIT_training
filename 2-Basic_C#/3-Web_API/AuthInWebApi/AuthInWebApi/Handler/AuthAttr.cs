using System;
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
    /// <summary>
    /// authattr is custom authorization attribute 
    /// it is inherit from  AuthorizationFilterAttribute and check authorization header
    /// </summary>
    public class AuthAttr : AuthorizationFilterAttribute
    {
        /// <summary>
        /// OnAuthorization it is handle authorization process
        /// validates the credentials, and sets the current principal if authorized, otherwise responds with Unauthorized status.
        /// </summary>
        /// <param name="actionContext">The action context containing the request and response details.</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // if authorization header is missing then will give 401 Unauthorized responce
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            // extract user Credentials 
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                // FromBase64String it is use to extract username and password
                var res = Convert.FromBase64String(authenticationToken);
                string credentials = Encoding.UTF8.GetString(res);
                // split method to : and then we have two parts of credentials username , password
                string[] credentialsValues = credentials.Split(':');
                //allocate seperate index
                string username = credentialsValues[0];
                string password = credentialsValues[1];

                // validate user credentials
                // IsAuthorizedUser it is method use to verify username and password
                // if credentials is true then it will set a thred current principal
                if (IsAuthorizedUser(username, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                }
                // if credentialsis false then it will return response 401
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