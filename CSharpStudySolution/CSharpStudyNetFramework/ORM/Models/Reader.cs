namespace CSharpStudyNetFramework.ORM.Models
{
    internal class Reader
    {
        public int? Id { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string mName { get; set; }
        public bool IsTeacher { get; set; }
        public string Info { get; set; }

        // ===============
        // Связанные поля
        // ===============
        // public List<Order> Orders { get; set; }
        // ===============
    }
}