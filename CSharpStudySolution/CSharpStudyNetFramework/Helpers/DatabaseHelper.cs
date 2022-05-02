using CSharpStudyNetFramework.ORM;

namespace CSharpStudyNetFramework.Helpers
{
    internal abstract class DatabaseHelper
    {
        public static readonly CustomDbContext db_context = new CustomDbContext();
    }
}
