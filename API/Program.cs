using API.Endpoints;
using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5500", "https://127.0.0.1:5500") // Allow both HTTP and HTTPS for live server
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Build app
var app = builder.Build();

// Use middleware
app.UseStaticFiles();  // serve wwwroot files
app.UseCors("MyAllowSpecificOrigins");  // must be AFTER app exists

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Map endpoints
app.MapCategoryEndpoints();
app.MapCustomerEndpoints();
app.MapProductEndpoints();
app.MapOrderEndpoints();

// Run
app.Run();
