using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Endpoints
{
    public static class CustomerEndpoints
    {
        public static void MapCustomerEndpoints(this WebApplication app)
        {
            app.MapGet("/Customer", async (AppDbContext db) =>
            {
                var customers = await db.Customer.ToListAsync();
                return Results.Ok(customers);
            });
        }
    }
}
