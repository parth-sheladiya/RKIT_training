using System;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Filters;

namespace BasicAuthDemo.Handlers
{
    /// <summary>
    /// basicauthhandler it is custom authorization 
    /// it is inherit from  AuthorizationFilterAttribute and check authorization header
    /// </summary>

    public class BasicAuthHandler : AuthorizationFilterAttribute
    {
        /// <summary>
        /// OnAuthorization it is handle authorization process
        /// validates the credentials, and sets the current principal if authorized, otherwise responds with Unauthorized status.
        /// </summary>
        /// <param name="actionContext">The action context containing the request and response details.</param>
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
           
            var authHeader = actionContext.Request.Headers.Authorization;
            if (authHeader != null && authHeader.Scheme == "Basic")
            {
                var encodedCredentials = authHeader.Parameter;
                var decodedBytes = Convert.FromBase64String(encodedCredentials);
                var decodedCredentials = Encoding.UTF8.GetString(decodedBytes);
                var credentials = decodedCredentials.Split(':');

                var username = credentials[0];
                var password = credentials[1];

                // Validate credentials 
                if (username == "admin" && password == "password")
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                    return;
                }
            }

            // if authorization header is missing then will give 401 Unauthorized responce
            actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
            {
                Content = new System.Net.Http.StringContent("Unauthorized")
            };
        }
    }
}