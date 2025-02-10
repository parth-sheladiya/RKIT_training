
using FinalDemo.BL.Operations;
using FinalDemo.Models;
using FinalDemo.Models.POCO;
using FinalDemo.Services;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Configuration;
using ServiceStack.Data;
using ServiceStack.OrmLite;


namespace FinalDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI 
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configure ORM Lite
            //builder.Services.AddSingleton<IDbConnectionFactory>(new OrmLiteConnectionFactory(
            //builder.Configuration.GetConnectionString("EcomDB"), MySqlDialect.Provider));


            var connectionString = builder.Configuration.GetConnectionString("EcomDB");
            builder.Services.AddSingleton<IDbConnectionFactory>(new OrmLiteConnectionFactory(
               connectionString,
               MySqlDialect.Provider
           ));

            builder.Services.AddScoped<BLUser>();
            

           
            builder.Services.AddScoped<Response>();
            builder.Services.AddScoped<USR01>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

           

            app.UseAuthorization();

            app.MapControllers();
        
                app.Run();
        }
    }
}