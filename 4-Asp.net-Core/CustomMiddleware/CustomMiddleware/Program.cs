namespace CustomMiddleware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            // Use the custom request logging middleware
            app.UseMiddleware<RequestLoggingMiddleware>();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}