using CSharpStudyNetCore.ORM;

namespace CSharpStudyNetCore.Helpers
{
    internal abstract class DatabaseHelper
    {
        public static readonly CustomDbContext db_context = new CustomDbContext();
    }
}
