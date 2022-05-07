using CSharpStudyNetFramework.ORM;

namespace CSharpStudyNetFramework.Helpers
{
    /// <summary>Вспомогательный класс для работы с БД</summary>
    internal abstract class DatabaseHelper
    {
        public static readonly CustomDbContext db = new CustomDbContext();
    }
}
