using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace CustomMiddleware
{
    #region RequestLoggingMiddleware Class
    // This class represents the custom middleware that logs HTTP request details
    /// <summary>
    /// Middleware that logs HTTP request details including method, URL, and timestamp.
    /// This middleware allows you to monitor and log the requests passing through the pipeline.
    /// </summary>
    public class RequestLoggingMiddleware
    {
        // it is used to process HTTP request and invoke the next request in the pipeline
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestLoggingMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middleware delegate in the pipeline.</param>
        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // it is the entry point of the custom middleware
        // this method processes the HTTP request in the middleware pipeline
        /// <summary>
        /// Logs the HTTP request details (method, URL, timestamp) and passes control to the next middleware.
        /// </summary>
        /// <param name="context">The HTTP context for the current request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
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
}
