
using Microsoft.AspNetCore.Http;

namespace MiddleWare
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
          
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

           

            var app = builder.Build();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync($"Request Path: {context.Request.Path}\n");
                await context.Response.WriteAsync("Middleware 1: Request received\n");
                await next();  // Next middleware ko call kar raha hai
                await context.Response.WriteAsync("Middleware 1: Response sent\n");
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Middleware 2: Request received\n");
                await next();
                await context.Response.WriteAsync("Middleware 2: Response sent\n");
            });
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Middleware 3: Request handled completely\n");
                await context.Response.WriteAsync("Final Response");
            });
            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}