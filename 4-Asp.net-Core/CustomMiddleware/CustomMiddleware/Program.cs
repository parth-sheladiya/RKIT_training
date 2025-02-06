using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CustomMiddleware.Middlewares;

namespace CustomMiddleware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //Middleware ko service me register kare
            builder.Services.AddTransient<CustomMiddlewareDemo>();

            var app = builder.Build();

            //Middleware ko correctly use kare
            app.UseCustomMiddleware();  //Corrected method call

            

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
