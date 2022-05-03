namespace CSharpStudyNetFramework.ORM.Models
{
    internal class Bookmaker
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }

        // ===============
        // Связанные поля
        // ===============
        // public List<Book> Books { get; set; }
        // ===============
    }
}