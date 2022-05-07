using System.Collections.Generic;

namespace CSharpStudyNetFramework.ORM.Models
{
    /// <summary>Сущность "Книга"</summary>
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
    }
}