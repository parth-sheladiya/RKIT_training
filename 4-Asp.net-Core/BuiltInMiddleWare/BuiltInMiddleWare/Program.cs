namespace BuiltInMiddleWare
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // add controller services 
            builder.Services.AddControllers();

            // Configure CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", policy =>
                {
                    policy.WithOrigins("http://localhost:5017")  
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

         

            var app = builder.Build();
            // Use Session Middleware
            app.UseSession(); // Enable session support
            // Use CORS middleware
            app.UseCors("AllowSpecificOrigin");
            // Enable Exception Handling Middleware
            app.UseExceptionHandler("/error");
            // mapping a static files middleware 
            app.UseStaticFiles();
            // add userounting middleware register
            app.UseRouting();

            // Map default controller route (for APIs).
            app.MapControllers();
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}