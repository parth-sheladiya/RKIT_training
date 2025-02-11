using FinalDemo.BL.Operations;
using FinalDemo.Models;
using FinalDemo.Models.POCO;
using FinalDemo.Services.Interface;
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

namespace FinalDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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

            builder.Services.AddMemoryCache();
            builder.Services.AddControllers(options =>
            {
                // options.Filters.Add(typeof(AuthFilter)); ❌ **Remove this if not needed globally**
            });
            

            builder.Services.AddAuthorization();

            
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            
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

           
            var connectionString = builder.Configuration.GetConnectionString("EcomDB");
            builder.Services.AddSingleton<IDbConnectionFactory>(new OrmLiteConnectionFactory(
               connectionString,
               MySqlDialect.Provider
           ));

           
            builder.Services.AddScoped<BLUser>();
            builder.Services.AddScoped<Response>();
            builder.Services.AddScoped<BLAuth>();
            builder.Services.AddScoped<IUSR01, BLUser>();
            builder.Services.AddScoped<BLPdt>();
            builder.Services.AddScoped<BLOrder>();

            builder.Services.AddTransient<USR01>();
            builder.Services.AddTransient<PDT01>();
            builder.Services.AddTransient<ORD01>();

            builder.Services.AddSingleton<JwtSecurityTokenHandler>();

            var app = builder.Build();

            app.UseMiddleware<LoggingMiddleware>();

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
