using Microsoft.EntityFrameworkCore;
using CategoryApi.Models;

namespace CategoryApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "iPhone", Description ="Designed to be loved" },
                new Category { Id = 2, Name = "Mac", Description = "If you can dream it, Mac can do it"},
                new Category { Id = 3, Name = "iPad", Description = "Touch, draw, and type on one magical device"},
                new Category { Id = 4, Name = "Watch", Description = "The ultimate device for a healthy life"}
            );
        }
    }
}
