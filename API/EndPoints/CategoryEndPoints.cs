using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Endpoints
{
    public static class CategoryEndpoints
    {
        public static void MapCategoryEndpoints(this WebApplication app)
        {
            app.MapGet("/Category", async (AppDbContext db) =>
            {
                var categories = await db.Category.ToListAsync();
                return Results.Ok(categories);
            });

            app.MapPost("/Category", async (Category category, AppDbContext db) =>
            {
                db.Category.Add(category);
                await db.SaveChangesAsync();
                return Results.Created($"/Category/{category.CategoryID}", category);
            });

            // DELETE
            app.MapDelete("/Category/{id:int}", async (int id, AppDbContext db) =>
            {
                var category = await db.Category.FindAsync(id);
                if (category == null) return Results.NotFound();

                db.Category.Remove(category);
                await db.SaveChangesAsync();
                return Results.NoContent(); // 204
            });
        }
    }
}
