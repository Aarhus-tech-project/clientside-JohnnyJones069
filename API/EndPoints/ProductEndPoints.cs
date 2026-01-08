using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Endpoints
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this WebApplication app)
        {
            app.MapGet("/Product", async (AppDbContext db) =>
            {
                var products = await db.Product.ToListAsync();
                return Results.Ok(products);
            });
        }
    }
}
