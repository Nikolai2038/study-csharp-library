namespace CSharpStudyNetFramework.ORM.Models
{
    /// <summary>Сущность "Запись"</summary>
    internal class Order
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public Reader Reader { get; set; }
        public CopyBook CopyBook { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
}