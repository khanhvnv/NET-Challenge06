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
                new Category { Id = 1, Name = "Bánh kem", Description ="Bánh kem, bánh kem bắp, bánh kem nhân mứt" },
                new Category { Id = 2, Name = "Bánh nướng", Description = "Bánh mì, bánh quy, donut"},
                new Category { Id = 3, Name = "Bánh lạnh", Description = "Bánh flan, bánh su kem, pudding "},
                new Category { Id = 4, Name = "Cà rem", Description = "Kem vani, kem đậu xanh, kem dâu, kem chuối"}
            );
        }
    }
}
