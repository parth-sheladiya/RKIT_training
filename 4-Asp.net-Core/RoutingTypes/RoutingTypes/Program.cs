using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RoutingTypes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region services configuration
            // add services to the container
            builder.Services.AddControllers(); // register controllers
            builder.Services.AddSwaggerGen();  // register swagger generation service
            #endregion

            var app = builder.Build();

            #region middleware configuration
            // configure the http request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); // swagger middleware
                app.UseSwaggerUI(); // swagger ui middleware
            }

            app.UseRouting(); // enable routing middleware
            app.MapControllers(); // map controllers for attribute routing
            #endregion

            #region conventional routes
            // define the home route
            app.MapGet("/home", async context =>
            {
                await context.Response.WriteAsync("hello this is home page");
            });

            // define the product route with optional id and name parameters
            app.MapGet("/product/{id?}/{name}", async context =>
            {
                var id = Convert.ToInt32(context.Request.RouteValues["id"]);
                var name = Convert.ToString(context.Request.RouteValues["name"]);

                await context.Response.WriteAsync($"product id is :{id} and product name is : {name}");
            });

            // define the create product route
            app.MapPost("/createproduct", async context =>
            {
                await context.Response.WriteAsync("create product successfully");
            });
            #endregion

            #region default route
            // default middleware to handle unhandled requests
            app.Run();
            #endregion
        }
    }
}
