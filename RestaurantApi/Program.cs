using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RestaurantApi.Migrations;

namespace RestaurantApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(o =>
            {
                o.AddPolicy("AllowAll", a => a.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());  
            });

            var dbPath = Path.Join(Directory.GetCurrentDirectory(), "Restaurants.db");
            var conn = new SqliteConnection($"Data Source =C:\\restFanaticdb\\Restaurants.db");
            builder.Services.AddDbContext<RestaurantListDbContext>(o => o.UseSqlite(conn));
                        
            var app = builder.Build();

            // Configure the HTTP request pipeline.
          
                app.UseSwagger();
                app.UseSwaggerUI();
            

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            app.MapGet("/Restaurants", async (RestaurantListDbContext db) => await db.Restaurant.ToListAsync());
            app.MapGet("/Restaurants/{id}", async (int id, RestaurantListDbContext db) =>
            await db.Restaurant.FindAsync(id) is Restaurants restaurants ? Results.Ok(restaurants) : Results.NotFound()
            );

            app.MapPut("/Restaurants/{id}", async (int id, Restaurants restaurants, RestaurantListDbContext db) =>
            {
                var record = await db.Restaurant.FindAsync(id);
                if (record != null) return Results.NotFound();

                record.RestaurantName = restaurants.RestaurantName;
                record.Details = restaurants.Details;
                record.Image = restaurants.Image;
                record.Location = restaurants.Location;

                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            app.MapDelete("/Restaurants/{id}", async (int id, RestaurantListDbContext db) =>
            {
                var record = await db.Restaurant.FindAsync(id);
                if (record != null) return Results.NotFound();
                db.Remove(record);

                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            app.MapPost("/Restaurants", async (Restaurants restaurants, RestaurantListDbContext db) =>
            {
                await db.AddAsync(restaurants);

                await db.SaveChangesAsync();

                return Results.Created($"/Restaurants/{restaurants.RestaurantId}", restaurants);
            });



            app.Run();
        }
    }
}