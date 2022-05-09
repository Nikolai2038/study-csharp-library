namespace CSharpStudyNetFramework.ORM.Models
{
    /// <summary>Сущность "Читатель"</summary>
    internal class Reader
    {
        public int? Id { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string mName { get; set; }
        public bool IsTeacher { get; set; }
        public string Info { get; set; }

        /// <summary>Полное ФИО читателя</summary>
        [System.ComponentModel.Browsable(false)]
        public string FullName => this.lName + " " + this.fName + " " + this.mName;

        public override string ToString()
        {
            return this.FullName;
        }
    }
}