namespace CSharpStudyNetFramework.ORM.Models
{
    internal class Author
    {
        public int? Id { get; set; }
        public string fName { get; set; }
        public string iName { get; set; }
        public string sName { get; set; }

        public Author(string fName)
        {
            this.fName = fName;
        }
    }
}