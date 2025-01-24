using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace CustomMiddleware
{
    #region RequestLoggingMiddleware Class
    // This class represents the custom middleware that logs HTTP request details
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log the request details (method, URL, and timestamp)
            var method = context.Request.Method;  // HTTP method (GET, POST, etc.)
            var url = context.Request.Path;      // Requested URL
            var timestamp = DateTime.Now;        // Current timestamp

            // Log the request details to the console (you can log it to a file or database as well)
            Console.WriteLine($"[{timestamp}] {method} request to {url}");

            // Continue to the next middleware in the pipeline
            await _next(context);
        }
    }
    #endregion

    #region RequestLoggingMiddlewareExtensions Class
    // This class provides an extension method to add the RequestLoggingMiddleware to the pipeline
    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLoggingMiddleware(this IApplicationBuilder builder)
        {
            // Add the RequestLoggingMiddleware to the HTTP request pipeline
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
    #endregion
}
