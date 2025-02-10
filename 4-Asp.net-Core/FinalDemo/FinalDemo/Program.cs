
using FinalDemo.BL.Operations;
using FinalDemo.Models;
using FinalDemo.Models.POCO;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Configuration;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FinalDemo.Services.Interface;


namespace FinalDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });
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
            builder.Services.AddScoped< IUSR01,BLUser>();
            builder.Services.AddScoped<BLPdt>();
            builder.Services.AddScoped<BLOrder>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        
                app.Run();
        }
    }
}