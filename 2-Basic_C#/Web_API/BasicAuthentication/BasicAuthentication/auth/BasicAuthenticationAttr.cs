using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BasicAuthentication.auth
{
    /// <summary>
    /// basic auth is used to protect a websites and mobileapp etc. from unauthorized access 
    /// </summary>
    public class BasicAuthenticationAttr : AuthorizationFilterAttribute
    {
        /// <summary>
        /// it is override from AuthorizationFilterAttribute class 
        /// it is use to check authorize process before execution of action method 
        /// </summary>
        /// <param name="actionContext">it will get header details from a request </param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            
            base.OnAuthorization(actionContext);

            // first of all it will check request header is null or not
            if (actionContext.Request.Headers.Authorization != null)
            {   // if req. header is not null then we will get auth from the parameters 
                var authToken = actionContext.Request.Headers.Authorization.Parameter;

                // Decoding authToken we get decode value in 'Username:Password' format
                var decodeauthToken = System.Text.Encoding.UTF8.GetString(
                    Convert.FromBase64String(authToken));

                // Splitting decodeauthToken using ':'
                var arrUserNameandPassword = decodeauthToken.Split(':');


                // Store username and password in separate variables
                var username = arrUserNameandPassword[0];
                var password = arrUserNameandPassword[1];


                // username and password matching
                if (IsAuthorizedUser(username ,password))
                {
                    // if username and password are correct then we will create one thread and assign current user to thread
                    Thread.CurrentPrincipal = new GenericPrincipal(
                        new GenericIdentity(arrUserNameandPassword[0]), null);
                }
                else
                {
                    // if username and password are incorrect then  we will throw err. 
                    actionContext.Response = actionContext.Request
                        .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                // if req. header is null then we will throw err.
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        /// <summary>
        /// this method is used to match a predefined username and password
        /// </summary>
        /// <param name="Username">username from action context header </param>
        /// <param name="Password">password from action context header</param>
        /// <returns>username and password </returns>
        public static bool IsAuthorizedUser(string Username, string Password)
        {
            // return 
            return Username == "parth" && Password == "parth@123";
        }


    }


}