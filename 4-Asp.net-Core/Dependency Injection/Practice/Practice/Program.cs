
using Practice.Services;
using Practice.Services.ServiceHandler;

namespace Practice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddScoped<IScopeService, ScopeService>();
            builder.Services.AddSingleton<ISingletonService, SingletonService>();
            builder.Services.AddTransient<ITransientService, TransientService>();
            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapControllers();

           

            app.Run();
        }
    }
}