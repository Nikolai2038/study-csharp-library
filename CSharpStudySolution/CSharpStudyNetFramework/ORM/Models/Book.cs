using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpStudyNetFramework.ORM.Models
{
    /// <summary>Сущность "Книга"</summary>
    internal class Book
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
            return this.Title;
        }
    }
}