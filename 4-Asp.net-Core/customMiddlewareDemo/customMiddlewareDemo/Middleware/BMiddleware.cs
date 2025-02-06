using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace customMiddlewareDemo.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class BMiddleware
    {
        private readonly RequestDelegate _next;

        public BMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            await httpContext.Response.WriteAsync("Before BMiddleware \n");
            await _next(httpContext);
            await httpContext.Response.WriteAsync("After BMiddleware \n");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseBMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BMiddleware>();
        }
    }
}
