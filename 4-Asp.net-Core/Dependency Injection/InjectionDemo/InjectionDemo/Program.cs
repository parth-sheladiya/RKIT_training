using InjectionDemo.Service.ServiceHandler;
using InjectionDemo.Service;
using InjectionDemo.Extension;

namespace InjectionDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            // Add services to the container.
           // builder.Services.AddScoped<IPaymentService, RazorpayPaymentService>();
             builder.Services.AddScoped<IPaymentService, JuspayPaymentService>();

            // Register custom services using extension methods (e.g., AddProductServices)
            builder.Services.AddProductOrderService();

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

            app.MapControllers();

            app.Run();
        }
    }
}
