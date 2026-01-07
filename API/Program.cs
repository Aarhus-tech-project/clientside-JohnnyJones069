using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://127.0.0.1:5500") // your HTML origin
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});
// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

app.UseDefaultFiles();
app.UseStaticFiles();


// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS Redirection
// app.UseHttpsRedirection();




// Endpoints


// Category Endpoints
app.MapGet("/Category", async (AppDbContext db) =>
{
    var Category = await db.Category.ToListAsync();
    return Results.Ok(Category);
});

app.MapPost("/Category", async (Category category, AppDbContext db) =>
{
    db.Category.Add(category);
    await db.SaveChangesAsync();
    return Results.Created($"/Category/{category.CategoryID}", category);
});

app.MapDelete("/Category/{id:int}", async (int id, AppDbContext db) =>
{
    var category = await db.Category.FindAsync(id);
    if (category == null) return Results.NotFound();

    db.Category.Remove(category);
    await db.SaveChangesAsync();
    return Results.NoContent();
});


// Customer Endpoints
app.MapGet("/Customer", async (AppDbContext db) =>
{
    var customer = await db.Customer.ToListAsync();
    return Results.Ok(customer);
});


// Product Endpoints
app.MapGet("/Product", async (AppDbContext db) =>
{
    var product = await db.Product.ToListAsync();
    return Results.Ok(product);
});


// Order Endpoints
app.MapGet("/Orders", async (AppDbContext db) =>
{
    var orders = await db.Orders.ToListAsync();
    return Results.Ok(orders);
});


// OrderLine Endpoints
app.MapGet("/OrderLine", async (AppDbContext db) =>
{
    var orderLine = await db.OrderLine.ToListAsync();
    return Results.Ok(orderLine);
});


// OrderStatus Endpoints
app.MapGet("/OrderStatus", async (AppDbContext db) =>
{
    var status = await db.OrderStatus.ToListAsync();
    return Results.Ok(status);
});
app.Run();
