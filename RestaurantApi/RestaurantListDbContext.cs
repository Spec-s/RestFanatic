using Microsoft.EntityFrameworkCore;

namespace RestaurantApi
{
    public class RestaurantListDbContext : DbContext
    {
        public RestaurantListDbContext(DbContextOptions<RestaurantListDbContext> options) : base(options) 
        {
        }

        public DbSet<Restaurants> Restaurant { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Restaurants>().HasData(
                new Restaurants
                {
                    RestaurantId = 1,
                    RestaurantName = "Test",
                    Details = "just testing the api db",
                    Location = "Mandeville",
                    Image = "empty"

                },
                new Restaurants
                {
                    RestaurantId = 2,
                    RestaurantName = "Test2",
                    Details = "Say my name, say my name",
                    Image = "Empty",
                    Location = "Kingston",
                }
                
                ) ;
        }
    }
}