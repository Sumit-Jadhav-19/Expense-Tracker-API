using Expense_Tracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users => Set<User>();
        public DbSet<Category> Categories => Set<Category>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Admin User
            var admin = new User
            {
                Id = 1,
                UserName = "admin",
                Email = "admin@test.com",
                Password = BCrypt.Net.BCrypt.HashPassword("admin123"),
                Role = "Admin"
            };
            modelBuilder.Entity<User>().HasData(admin);
        }
    }
}
