namespace CSharpStudyNetFramework.ORM.Models
{
    /// <summary>Сущность "Запись"</summary>
    internal class Order : IEntity
    {
        public int? Id { get; set; }
        public Reader Reader { get; set; }
        public CopyBook CopyBook { get; set; }
        public string DateGiven { get; set; }
        public string DateReturned { get; set; }
        public string DateReturnedFact { get; set; }
        public bool IsReturned { get; set; }

        public override string ToString()
        {
            return this.Reader.FullName + " - " + this.CopyBook.Book.Title;
        }
    }
}