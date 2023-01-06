using DIRP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIRP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Dipak", Email = "abc@outlook.com"},
                new Student { Id = 2, Name = "Manish", Email = "Manish@outlook.com" },
                new Student { Id = 3, Name = "Dipak", Email = "Dipak@outlook.com" }
                );
        }
    }
}
