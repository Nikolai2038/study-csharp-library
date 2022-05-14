namespace CSharpStudyNetFramework.ORM.Models
{
    /// <summary>Сущность "Группа"</summary>
    internal class Group : IEntity
    {
        public int? Id { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
