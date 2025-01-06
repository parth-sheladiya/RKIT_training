using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BasicAuthentication.auth;

namespace BasicAuthentication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Adding the BasicAuthentication filter to the global filter collection
            config.Filters.Add(new BasicAuthenticationAttr());
            // Web API configuration and services



            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
