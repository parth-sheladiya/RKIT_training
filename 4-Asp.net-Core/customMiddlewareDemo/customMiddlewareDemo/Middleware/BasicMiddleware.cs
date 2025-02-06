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
        /// Adds MyMiddleware to the application's request pipeline.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <returns>The updated IApplicationBuilder with MyMiddleware added.</returns>
        public static IApplicationBuilder BasicMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<BasicMiddleware>();
        }

        #endregion
    }
}
