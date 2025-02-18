using FinalDemo.BL.Operations;
using FinalDemo.Models;
using FinalDemo.Models.POCO;
using FinalDemo.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.OpenApi.Models;
using FinalDemo.Middleware;
using FinalDemo.BL.Interface;
using FinalDemo.Service;

namespace FinalDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // key issuer in appsetting json
            var jwtKey = builder.Configuration["Jwt:Key"];
            var jwtIssuer = builder.Configuration["Jwt:Issuer"];

            if (string.IsNullOrEmpty(jwtKey) || string.IsNullOrEmpty(jwtIssuer))
            {
                throw new InvalidOperationException("JWT Key or Issuer is not configured properly.");
            }

            
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtIssuer,
                        ValidAudience = jwtIssuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                    };
                });

            
            builder.Services.AddControllers(options =>
            {
                // it is not handle globally bcz it is used in action method
                // options.Filters.Add(typeof(AuthFilter)); 
            });
            

            builder.Services.AddAuthorization();

            
            

            // swagger ui setup for token barear
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer",
                    In = ParameterLocation.Header,
                    Description = "Enter <your-token> to authenticate."
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                        }
                    });
            });


           // data base  connection serive add singleton scope 
            var connectionString = builder.Configuration.GetConnectionString("EcomDB");
            builder.Services.AddSingleton<IDbConnectionFactory>(new OrmLiteConnectionFactory(
               connectionString,
               MySqlDialect.Provider
           ));

            // register services
            builder.Services.RegisterEcommerceServices();

           // /// BL service
           // builder.Services.AddScoped<Response>();
           builder.Services.AddScoped<IAuthentication,BLAuth>();
           //// builder.Services.AddScoped<IUSR01, BLUser>();
           // builder.Services.AddScoped<BLUser>();
           // builder.Services.AddScoped<BLPdt>();
           // builder.Services.AddScoped<BLOrder>();

            // builder.Services.AddTransient<USR01>();
            // builder.Services.AddTransient<PDT01>();
            // builder.Services.AddTransient<ORD01>();


            // auth
            builder.Services.AddSingleton<JwtSecurityTokenHandler>();

            var app = builder.Build();

            // add custom middleware for request and response logging
            app.UseMiddleware<LoggingMiddleware>();
            
            // development mode
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
           
            
            // enable auth and authorization
            app.UseAuthentication();
            app.UseAuthorization();

            // map controller and starting app run
            app.MapControllers();

            app.Run();
        }
    }
}
