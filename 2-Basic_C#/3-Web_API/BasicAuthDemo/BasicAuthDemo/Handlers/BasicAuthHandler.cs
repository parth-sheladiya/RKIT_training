using System;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Filters;

namespace BasicAuthDemo.Handlers
{
    public class BasicAuthHandler : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            // Check if Authorization header exists
            var authHeader = actionContext.Request.Headers.Authorization;
            if (authHeader != null && authHeader.Scheme == "Basic")
            {
                var encodedCredentials = authHeader.Parameter;
                var decodedBytes = Convert.FromBase64String(encodedCredentials);
                var decodedCredentials = Encoding.UTF8.GetString(decodedBytes);
                var credentials = decodedCredentials.Split(':');

                var username = credentials[0];
                var password = credentials[1];

                // Validate credentials (hardcoded for demo)
                if (username == "admin" && password == "password")
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                    return;
                }
            }

            // If invalid, return 401 Unauthorized
            actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
            {
                Content = new System.Net.Http.StringContent("Unauthorized")
            };
        }
    }
}
