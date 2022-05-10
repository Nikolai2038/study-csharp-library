using CSharpStudyNetFramework.ORM.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharpStudyNetFramework.ORM
{
    /// <summary>Вспомогательный класс для работы с сущностями БД</summary>
    internal class CustomDbContext : DbContext
    {
        /// <summary>Таблица "Авторы"</summary>
        public DbSet<Author> Authors { get; set; }

        /// <summary>Таблица "Книги"</summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>Таблица "Издатели"</summary>
        public DbSet<Bookmaker> Bookmakers { get; set; }

        /// <summary>Таблица "Экземпляры книги"</summary>
        public DbSet<CopyBook> CopyBooks { get; set; }

        /// <summary>Таблица "Жанры книг"</summary>
        public DbSet<Group> Groups { get; set; }

        /// <summary>Таблица "Записи"</summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>Таблица "Читатели"</summary>
        public DbSet<Reader> Readers { get; set; }

        public CustomDbContext()
        {
            this.Database.EnsureCreated();
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=library_data_v_1_0_8.db");
        }
    }
}
