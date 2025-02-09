namespace customMiddlewareDemo.Middleware
{
    public class BasicMiddleware :IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Before BasicMiddleware \n");
            await next(context);
            await context.Response.WriteAsync("After BasicMiddleware \n");
        }
    }

    public static class MyMiddlewareExtension
    {
        #region Extension Method

        /// <summary>
        /// add m.  to reques pipeline
        /// </summary>
        /// <param name="app">app</param>
        /// <returns>The updated IApplicationBuilder with MyMiddleware added.</returns>
        public static IApplicationBuilder BasicMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<BasicMiddleware>();
        }

        #endregion
    }
}
