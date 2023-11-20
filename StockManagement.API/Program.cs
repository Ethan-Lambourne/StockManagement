using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IItemsRepository<Laptop>, LaptopRepository>();
builder.Services.AddScoped<IItemsRepository<GraphicsCard>, GraphicsCardRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();