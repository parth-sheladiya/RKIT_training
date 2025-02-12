var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouting();

app.MapGet("/home", async context =>
{
    await context.Response.WriteAsync("hello this is home page");
});

app.MapGet("/about", async context =>
{
    await context.Response.WriteAsync("hello this is about page");
});
// define the product route with optional id and name parameters
app.MapGet("/product/{id?}/{name}", async context =>
{
    var id = Convert.ToInt32(context.Request.RouteValues["id"]);
    var name = Convert.ToString(context.Request.RouteValues["name"]);
    await context.Response.WriteAsync($"product id is :{id} and product name is : {name}");
});
// define the create product route
app.MapPost("/createproduct", async context =>
{
    await context.Response.WriteAsync("create product successfully");
});

// Default controller route mapping
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Values}/{action=GetAll}/{id?}"
  );

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
