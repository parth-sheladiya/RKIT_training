using System;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace JwtWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Secret key should be 32 bytes (256 bits)
            var key = Encoding.UTF8.GetBytes("Your32BytesLongSecretKeyHere12345!"); // Ensure 32 bytes key

            // JWT Authentication Configuration
            var jwtOptions = new JwtBearerAuthenticationOptions
            {
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true, // Optional: To validate the token expiry
                }
            };

            // Configure JWT Authentication
            app.UseJwtBearerAuthentication(jwtOptions);

            // Web API Configuration
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);  // Ensure WebApiConfig is correctly defined
            app.UseWebApi(config);          // Use Web API in Owin pipeline
        }
    }
}
