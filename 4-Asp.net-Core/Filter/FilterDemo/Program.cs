using FilterDemo.Filters;

namespace FilterDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();



     

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(new CustomActionFilter("global"));
                options.Filters.Add(new CustomResourceFilter("global"));
                options.Filters.Add(new CustomResultFilter("global"));
                options.Filters.Add(new CustomAuthorizationFilter("global"));
                options.Filters.Add(new CustomExceptionFilter());
            });

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