namespace CSharpStudyNetFramework.ORM.Models
{
    /// <summary>Сущность "Издатель"</summary>
    internal class Bookmaker : IEntity
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            if (this.City.Trim() == "") {
                return this.Title;
            } else {
                return this.Title + " г. " + this.City;
            }
        }
    }
}