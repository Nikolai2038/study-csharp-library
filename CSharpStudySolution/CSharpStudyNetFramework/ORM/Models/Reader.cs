namespace CSharpStudyNetFramework.ORM.Models
{
    /// <summary>Сущность "Читатель"</summary>
    internal class Reader : IEntity
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Info { get; set; }

        /// <summary>Полное ФИО читателя</summary>
        [System.ComponentModel.Browsable(false)]
        public string FullName => this.LastName + " " + this.FirstName + " " + this.MiddleName;

        public override string ToString()
        {
            return this.FullName;
        }
    }
}