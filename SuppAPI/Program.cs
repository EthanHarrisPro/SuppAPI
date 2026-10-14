using Microsoft.EntityFrameworkCore;
using SuppAPI.Data;
using SuppAPI.Models;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<SuppShopContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SuppShop")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/openapi/v1.json", "SuppShopAPI");
    });
}

app.MapGet("suppshopproducts", async (SuppShopContext db) =>
await db.Products.ToListAsync());

app.MapPost("suppshopproducts", async (ProductRequest request, SuppShopContext db) =>
{
    var product = new Product
    { 
        Name = request.Name,
        Description = request.Desc,
        Stock = request.Stock,
        Price = request.Price,
    };

    db.Products.Add(product);
    await db.SaveChangesAsync();

    return Results.Created($"/suppshopproducts/{product.Id}", product);
});

app.MapPut("suppshopproducts/{id:int}", async (int id, ProductRequest request, SuppShopContext db) =>
{
    var product = await db.Products.FindAsync(id);

    if (product is null)
    {
        return Results.NotFound();
    }

    product.Name = request.Name;
    product.Description = request.Desc;
    product.Stock = request.Stock;
    product.Price = request.Price;

    await db.SaveChangesAsync();

    return Results.Ok(product);
});

app.MapDelete("suppshopproducts/{id:int}", async (int id, SuppShopContext db) =>
{
    var product = await db.Products.FindAsync(id);

    if (product is null)
    {
        return Results.NotFound();
    }

    db.Remove(product);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();
public record ProductRequest(string Name, string Desc, int Stock, decimal Price);

