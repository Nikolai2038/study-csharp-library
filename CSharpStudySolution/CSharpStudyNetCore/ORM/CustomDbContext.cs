using CSharpStudyNetCore.ORM.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharpStudyNetCore.ORM
{
    internal class CustomDbContext : DbContext
    {
        public DbSet<Author> authors { get; set; }
        public DbSet<Group> group { get; set; }

        public CustomDbContext()
        {
            this.Database.EnsureCreated();
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Users.db");
        }
    }
}