using Microsoft.OpenApi.Models;
using CoffeeMinimalAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Coffee API", Description = "Testing Minimal API", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Coffee API V1");
});

app.MapGet("/", () => "¡Hola mundo!");

app.MapGet("/Coffee/{id}", (int id) => CoffeeDB.GetCoffee(id));
app.MapGet("/Coffee", () => CoffeeDB.GetCoffee());
app.MapPost("/CoffeeOrder", (Coffee coffee) => CoffeeDB.CreateCoffeeOrder(coffee));
app.MapPut("/CoffeeUpdate", (Coffee coffee) => CoffeeDB.UpdateCoffeeOrder(coffee));

app.Run();
