using System.Collections.Generic;

namespace CSharpStudyNetFramework.ORM.Models
{
    internal class Author
    {
        public int? Id { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string mName { get; set; }

        // ===============
        // Связанные поля
        // ===============
        // public List<Book> Books { get; set; }
        // ===============

        public Author(string fName)
        {
            this.fName = fName;
        }
    }
}