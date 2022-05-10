namespace CSharpStudyNetFramework.ORM.Models
{
    /// <summary>Сущность "Автор"</summary>
    internal class Author : IEntity
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        /// <summary>Полное ФИО автора</summary>
        [System.ComponentModel.Browsable(false)]
        public string FullName => this.LastName + " " + this.FirstName + " " + this.MiddleName;

        public override string ToString()
        {
            return this.FullName;
        }
    }
}