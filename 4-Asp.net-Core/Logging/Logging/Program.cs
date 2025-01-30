
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;

namespace Logging
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Early init of NLog to allow startup and exception logging, before host is built
            var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            // configure built in loggin

            //builder.Logging
            //    .ClearProviders()
            //    .AddConsole()
            //    .AddDebug()
            //    .AddNLog();

            builder.Services.AddLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
                logging.AddDebug();
               // logging.AddNLog();
                logging.AddNLogWeb();
            });
                
            //// NLog: Setup NLog for Dependency injection
            //builder.Logging.ClearProviders();
            //builder.Host.UseNLog();
            builder.Services.AddControllers();
            // Add services to the container.
            builder.Services.AddAuthorization();

           
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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