using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using NLog;
using System.Threading.Tasks;

namespace FinalDemo.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoggingMiddleware
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            // Log information about the incoming request
            _logger.Info($"Incoming request: {httpContext.Request.Method} {httpContext.Request.Path}");
           await  _next(httpContext);
            // Log information about the outgoing response
            _logger.Info($"Outgoing response: {httpContext.Response.StatusCode}");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
