using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using NLog;
using System.Threading.Tasks;

namespace FinalDemo.Middleware
{
   
    public class LoggingMiddleware
    {
        // logger initialize show class name
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        // it is function to call next middleware
        private readonly RequestDelegate _next;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="next"></param>
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            // Log information about the input request
            // method get,post.
            // url path
            // statuc code
            _logger.Info($"Incoming request: {httpContext.Request.Method} {httpContext.Request.Path}");
           await  _next(httpContext);
            // Log information about the output response
            _logger.Info($"Outgoing response: {httpContext.Response.StatusCode}");
        }
    }

    // it is directly use in program.cs
    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
