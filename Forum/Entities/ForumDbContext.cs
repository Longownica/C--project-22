using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Entities
{
    public class ForumDbContext : DbContext
    {
        private string _connectionString =
        "Server=localhost\\MSSQLSERVER01;Database=ForumDb;Trusted_Connection=True;";
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .Property(r => r.body)
                .IsRequired()
                .HasMaxLength(2000);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
     }
}
