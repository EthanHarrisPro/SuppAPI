using Microsoft.EntityFrameworkCore;
using SuppAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<SuppShopContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SuppShop")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("suppshopitems", async (SuppShopContext db) =>
await db.Products.ToListAsync());

app.Run();