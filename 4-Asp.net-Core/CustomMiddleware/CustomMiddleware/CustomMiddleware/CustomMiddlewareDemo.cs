using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CustomMiddleware.Middlewares
{
    public class CustomMiddlewareDemo : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Before MyMiddleware \n");
            await next(context);
            await context.Response.WriteAsync("After MyMiddleware \n");
        }
    }
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddlewareDemo>();
        }
    }
}
