using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;

namespace AuthJwt
{
    /*
    Summary:
    This code demonstrates how to configure JWT authentication for a Web API. It uses a custom `JwtAuthenticationHandler` to validate JWT tokens passed in the `Authorization` header of incoming HTTP requests. The Web API configuration class (`WebApiConfig`) sets up the necessary routes and adds the JWT handler to the HTTP message pipeline.

    Key Features:
    - Validates JWT tokens based on the issuer, audience, and signature.
    - Extracts the user identity from the token and sets it as the principal for the current request.
    - If the token is missing or invalid, returns an Unauthorized HTTP response.
    - If no token is provided, continues the request processing without returning Unauthorized.
    */

    // WebApiConfig class is used to configure Web API services and routes
    public static class WebApiConfig
    {
        // Register method sets up Web API configuration, routes, and handlers
        public static void Register(HttpConfiguration config)
        {
            // Enable attribute-based routing (e.g., using [Route] annotations on controller actions)
            config.MapHttpAttributeRoutes();

            // Add the custom JWT authentication handler to validate tokens on incoming requests
            config.MessageHandlers.Add(new JwtAuthenticationHandler());

            // Set up default route for the API (example: api/{controller}/{id})
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

    // Custom handler for validating JWT tokens in incoming HTTP requests
    public class JwtAuthenticationHandler : DelegatingHandler
    {
        // Intercepts the HTTP request and validates the JWT token if it exists in the Authorization header
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Check if the request contains the Authorization header
            if (request.Headers.Authorization != null)
            {
                // Extract the JWT token from the Authorization header
                var token = request.Headers.Authorization.Parameter;

                try
                {
                    // Create a new JwtSecurityTokenHandler for token validation
                    var tokenHandler = new JwtSecurityTokenHandler();
                    // Define the secret key used for validating the token's signature
                    var key = Encoding.UTF8.GetBytes("YourSecretKeyForJWTYourSecretKeyForJWT");

                    // Set the parameters for token validation
                    var validationParameters = new TokenValidationParameters
                    {
                        // Enable issuer validation (the token's Issuer should match this value)
                        ValidateIssuer = true,
                        // Enable audience validation (the token's Audience should match this value)
                        ValidateAudience = true,
                        // Validate the token's signature against the key
                        ValidateIssuerSigningKey = true,
                        // Define the expected Issuer (e.g., "YourIssuer")
                        ValidIssuer = "YourIssuer",
                        // Define the expected Audience (e.g., "YourAudience")
                        ValidAudience = "YourAudience",
                        // Define the symmetric key used to validate the JWT's signature
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };

                    // Validate the token and extract the ClaimsPrincipal (user info)
                    var principal = tokenHandler.ValidateToken(token, validationParameters, out _);

                    // Set the principal (user info) for the current thread, enabling access control
                    Thread.CurrentPrincipal = principal;

                    // In the Web API context, set the principal for the request's current context
                    if (request.GetRequestContext() != null)
                    {
                        request.GetRequestContext().Principal = principal;
                    }
                }
                catch (Exception)
                {
                    // If validation fails (e.g., invalid token), return an Unauthorized response with an error message
                    return request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid token.");
                }
            }

            // If no Authorization header is found, the request is processed normally
            // This avoids unauthorized responses for requests without a token
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
