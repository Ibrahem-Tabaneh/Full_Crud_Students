using EducationPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
       



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Alice", Age = 20, Grade = 90,Email= "Alice@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("123456") },

                new Student { Id = 2, Name = "Bob", Age = 22, Grade = 85,Email= "BobBob@gmail.com", Password= BCrypt.Net.BCrypt.HashPassword("123456") },

                new Student { Id = 3, Name = "Charlie", Age = 21, Grade = 92 ,Email= "Charlie@gmail.com", Password =BCrypt.Net.BCrypt.HashPassword("123456") }
            );
        }
    }

}
