using Microsoft.EntityFrameworkCore;
using WebApp.Models; // Student modelini kullanabilmek için

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<StudentDB> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Data (Başlangıç verileri)
            modelBuilder.Entity<StudentDB>().HasData(
                new StudentDB
                {
                    Id = 1,
                    Name = "Lale",
                    Surname = "Bozkurt",
                    Email = "lale@gmail.com",
                    Phone = "1234567890",
                    BirthDate = new DateTime(2001, 3, 9),
                    RegisterDate = DateTime.Now,
                    WillAttend = 1
                },
                new StudentDB
                {
                    Id = 2,
                    Name = "Nihal",
                    Surname = "Sengul",
                    Email = "nihal@gmail.com",
                    Phone = "0987654321",
                    BirthDate = new DateTime(2002, 5, 25),
                    RegisterDate = DateTime.Now,
                    WillAttend = 0
                }
            );
        }
    }
}
