using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Endpoints
{
    public static class OrderLineEndpoints
    {
        public static void MapOrderLineEndpoints(this WebApplication app)
        {
            app.MapGet("/OrderLine", async (AppDbContext db) =>
            {
                var orderLines = await db.OrderLine.ToListAsync();
                return Results.Ok(orderLines);
            });

        }
    }
}
