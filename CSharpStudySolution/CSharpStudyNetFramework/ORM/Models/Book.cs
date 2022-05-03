using System.Collections.Generic;

namespace CSharpStudyNetFramework.ORM.Models
{
    internal class Book
    {
        public int? Id { get; set; }

        public Author Author { get; set; }
        public string Title { get; set; }
        public string YearPublication { get; set; }
        public string YearRegistr { get; set; }
        public Group Group { get; set; }
        public Bookmaker Bookmaker { get; set; }
        public string Photo { get; set; }

        // ===============
        // Связанные поля
        // ===============
        // public List<Bookmaker> Bookmakers { get; set; }
        // public List<Author> Authors { get; set; }
        // public List<Group> Groups { get; set; }
        // public List<CopyBook> CopyBooks { get; set; }
        // ===============
    }
}