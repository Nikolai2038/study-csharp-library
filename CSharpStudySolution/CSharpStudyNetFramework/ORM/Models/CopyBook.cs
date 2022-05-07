namespace CSharpStudyNetFramework.ORM.Models
{
    /// <summary>Сущность "Экземпляр книги"</summary>
    internal class CopyBook
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string DaterReciept { get; set; }
        public int NumberInLibrary { get; set; }
        public bool IsExist { get; set; }
        public bool IsLost { get; set; }
        public Book Book { get; set; }
    }
}