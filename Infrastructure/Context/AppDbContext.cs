using Microsoft.EntityFrameworkCore;
using WebApp.Models; // Student modelini kullanabilmek için

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<Course> Courses { get; set; }
        //public DbSet<UserCourse> UserCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<UserCourse>()
            //    .HasOne(uc => uc.User)
            //    .WithMany(u => u.UserCourses)
            //    .HasForeignKey(uc => uc.UserId);

            //modelBuilder.Entity<UserCourse>()
            //    .HasOne(uc => uc.Course)
            //    .WithMany(c => c.UserCourses)
            //    .HasForeignKey(uc => uc.CourseId);

            // Seed Data (Başlangıç verileri)
            //modelBuilder.Entity<Student>().HasData(
            //    new Student
            //    {
            //        Id = 1,
            //        Name = "Lale",
            //        Surname = "Bozkurt",
            //        Email = "lale@gmail.com",
            //        Phone = "1234567890",
            //        BirthDate = new DateTime(2001, 3, 9),
            //        RegisterDate = DateTime.Now,
            //        WillAttend = 1
            //    },
            //    new Student
            //    {
            //        Id = 2,
            //        Name = "Nihal",
            //        Surname = "Sengul",
            //        Email = "nihal@gmail.com",
            //        Phone = "0987654321",
            //        BirthDate = new DateTime(2002, 5, 25),
            //        RegisterDate = DateTime.Now,
            //        WillAttend = 0
            //    }
            //);
        }


    }
}
