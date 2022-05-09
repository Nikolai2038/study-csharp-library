namespace CSharpStudyNetFramework.ORM.Models
{
    /// <summary>Сущность "Книга"</summary>
    internal class Book
    {
        public int? Id { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }
        public string PublicationYear { get; set; }
        public string RegistrationDate { get; set; }
        public Group Group { get; set; }
        public Bookmaker Bookmaker { get; set; }
        public string Photo { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
}