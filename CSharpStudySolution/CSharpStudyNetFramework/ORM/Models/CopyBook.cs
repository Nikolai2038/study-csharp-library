namespace CSharpStudyNetFramework.ORM.Models
{
    /// <summary>Сущность "Экземпляр книги"</summary>
    internal class CopyBook : IEntity
    {
        public int? Id { get; set; }
        // TODO: Не забыть поменять на string
        public int Number { get; set; }
        public bool IsGiven { get; set; }
        public bool IsLost { get; set; }
        public Book Book { get; set; }

        public override string ToString()
        {
            return this.Number.ToString();
        }
    }
}