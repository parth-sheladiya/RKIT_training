namespace ProjectCoreEmpty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/run", () => "Hello dot net core empty project");

            app.Run();
        }
    }
}