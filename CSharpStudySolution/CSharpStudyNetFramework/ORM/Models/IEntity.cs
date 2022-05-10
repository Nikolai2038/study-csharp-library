namespace CSharpStudyNetFramework.ORM.Models
{
    /// <summary>Общий интерфейс для всех сущностей</summary>
    internal interface IEntity
    {
        int? Id { get; set; }
        string ToString();
    }
}
