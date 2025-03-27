using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models; // Student modelini kullanabilmek için

namespace Infrastructure.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        //public AppDbContext(DbContextOptions options) : base(options) { }
        //public AppDbContext()
        //{
        //}

        public DbSet<Student> Students { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<Course> Courses { get; set; }
        //public DbSet<UserCourse> UserCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            
        }


    }
}
