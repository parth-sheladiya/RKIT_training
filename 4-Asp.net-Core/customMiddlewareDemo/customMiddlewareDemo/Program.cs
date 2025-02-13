
using customMiddlewareDemo.Middleware;

namespace customMiddlewareDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // add controllers 
            builder.Services.AddControllers();

            // Add services to the container.
            builder.Services.AddAuthorization();

            // register custom middleware as a service
            builder.Services.AddTransient<BasicMiddleware>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                await context.Response.WriteAsync("Before 1 Middlerware \n");
                await next(context);
                await context.Response.WriteAsync("After 1 Middlerware \n");
            });

            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                await context.Response.WriteAsync("Before 2 Middlerware \n");
                await next(context);
                await context.Response.WriteAsync("After 2 Middlerware \n");
            });


            // using custom middleware through service  
            app.UseMiddleware<BasicMiddleware>();
            // using custom middleware through extension
            app.BasicMiddleware();
            // using  middleware with built-in format
            app.UseBMiddleware();

            

            app.Run(async (HttpContext context) =>
            {
                await context.Response.WriteAsync("3 Middlerware \n");
            });

            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            

            app.UseAuthorization();
            app.Run();


        }
    }
}