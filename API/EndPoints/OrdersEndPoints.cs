using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Endpoints
{
    public static class OrderEndpoints
    {
        public static void MapOrderEndpoints(this WebApplication app)
        {
            app.MapGet("/Orders", async (AppDbContext db) =>
            {
                var orders = await db.Orders.ToListAsync();
                return Results.Ok(orders);
            });

        }
    }
}
