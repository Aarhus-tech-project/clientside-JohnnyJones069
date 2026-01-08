using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Endpoints
{
    public static class OrderStatusEndpoints
    {
        public static void MapOrderStatusEndpoints(this WebApplication app)
        {
            app.MapGet("/OrderStatus", async (AppDbContext db) =>
            {
                var statuses = await db.OrderStatus.ToListAsync();
                return Results.Ok(statuses);
            });
        }
    }
}
