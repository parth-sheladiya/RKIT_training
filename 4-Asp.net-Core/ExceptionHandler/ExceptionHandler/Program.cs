namespace ExceptionHandler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddAuthorization();

            // Swagger Configuration
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Exception Handling Middleware 
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            //Define Custom Error Page**
            app.Map("/error", (HttpContext context) =>
            {
                return Results.Problem("error please try again");
            });

           

            
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
