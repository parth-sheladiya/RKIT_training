
namespace ExceptionHandler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseDeveloperExceptionPage();
            }
            else
            {
                // sterp production version
                // right click project -> properties -> Debug -> general -> open debug launch ui
                app.UseExceptionHandler(options =>
                {
                    options.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "application/json";

                        var errorResponse = new
                        {
                            message = "An unexpected error occurred. Please try again later.",
                            errorCode = "500"
                        };

                        await context.Response.WriteAsJsonAsync(errorResponse);

                    });
                });
            }

            // to test
            


            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}