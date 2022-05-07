using CSharpStudyNetFramework.ORM.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharpStudyNetFramework.ORM
{
    /// <summary>Вспомогательный класс по работе с БД</summary>
    internal class CustomDbContext : DbContext
    {
        /// <summary>Таблица "Авторы"</summary>
        public DbSet<Author> authors { get; set; }

        /// <summary>Таблица "Книги"</summary>
        public DbSet<Book> books { get; set; }

        /// <summary>Таблица "Издатели"</summary>
        public DbSet<Bookmaker> bookmakers { get; set; }

        /// <summary>Таблица "Экземпляры книги"</summary>
        public DbSet<CopyBook> copybooks { get; set; }

        /// <summary>Таблица "Жанры книг"</summary>
        public DbSet<Group> group { get; set; }

        /// <summary>Таблица "Записи"</summary>
        public DbSet<Order> orders { get; set; }

        /// <summary>Таблица "Читатели"</summary>
        public DbSet<Reader> readers { get; set; }

        public CustomDbContext()
        {
            this.Database.EnsureCreated();
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=library_data.db");
        }
    }
}
