using Microsoft.EntityFrameworkCore;
using Mynewapp.Models;

namespace Mynewapp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed some initial data
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    ID = 1,
                    Name = "First Item",
                    Description = "This is the first item in the database",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new Item
                {
                    ID = 2,
                    Name = "Second Item",
                    Description = "This is the second item in the database",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                }
            );
        }
    }
}
