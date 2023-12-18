using StockManagement.Shared.GenerateID;
using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IItemsRepository<Laptop>, CsvLaptopRepository>();
builder.Services.AddScoped<IItemsRepository<GraphicsCard>, CsvGraphicsCardRepository>();
builder.Services.AddScoped<IGenerateID>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();