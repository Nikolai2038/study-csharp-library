using System;

namespace CSharpStudyNetFramework.ORM.Models
{
    /// <summary>Сущность "Книга"</summary>
    internal class Book : IEntity
    {
        public int? Id { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Group Group { get; set; }
        public Bookmaker Bookmaker { get; set; }
        public byte[] Photo { get; set; }
        public string Note { get; set; }

        public override string ToString()
        {
            string author = "-";
            if (this.Author != null) {
                author = this.Author.ToString();
            }
            string bookmaker = "-";
            if (this.Bookmaker != null) {
                bookmaker = this.Bookmaker.ToString();
            }
            return author + ", " + this.Title + " (" + bookmaker + ", " + this.PublicationYear + " год)";
        }
    }
}