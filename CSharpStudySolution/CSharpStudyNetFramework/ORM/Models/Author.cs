using System.Collections.Generic;

namespace CSharpStudyNetFramework.ORM.Models
{
    /// <summary>Сущность "Автор"</summary>
    internal class Author
    {
        public int? Id { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string mName { get; set; }
    }
}