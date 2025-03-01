//2025 - 02 - 19 14:58:59.0193 Info request is GET /swagger/index.html
//2025-02-19 14:58:59.4020 Info response is 200
//2025-02-19 14:58:59.6425 Info request is GET /swagger/v1/swagger.json
//2025-02-19 14:58:59.8730 Info response is 200
//2025-02-19 14:59:44.0778 Info request is POST /api/CLUSR01/addUser
//2025-02-19 14:59:44.6603 Info response is 200


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

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
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
                    Description = "Enter token"
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

           // BL service
           // builder.Services.AddScoped<Response>();
           builder.Services.AddScoped<IAuthentication,BLAuth>();
          


            // auth
            //builder.Services.AddSingleton<JwtSecurityTokenHandler>();

            var app = builder.Build();

            // add custom middleware for request and response logging
            app.UseMiddleware<LoggingMiddleware>();
            
            // development mode
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            //CORS Middleware Use Karo
            app.UseCors("AllowAllOrigins");


            // enable auth and authorization
            app.UseAuthentication();
            app.UseAuthorization();

            // map controller and starting app run
            app.MapControllers();

            app.Run();
        }
    }
}
