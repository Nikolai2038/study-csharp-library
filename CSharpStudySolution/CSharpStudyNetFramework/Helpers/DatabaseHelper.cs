using CSharpStudyNetFramework.ORM;
using System.Collections.Generic;

namespace CSharpStudyNetFramework.Helpers
{
    /// <summary>Вспомогательный класс для работы с БД</summary>
    internal abstract class DatabaseHelper
    {
        /// <summary>База данных</summary>
        public static readonly CustomDbContext db = new CustomDbContext();

        /// <summary>Возвращает список строк для комбобоксов с информацией о сущностях</summary>
        /// <typeparam name="T">Класс сущности</typeparam>
        /// <param name="entities">Список сущностей</param>
        /// <returns>Массив строк с информацией о каждой сущности</returns>
        public static string[] GetStringArrayForComboBoxes<T>(List<T> entities)
        {
            string[] result = new string[entities.Count];
            for (int i = 0; i < entities.Count; i++) {
                result[i] = entities[i].ToString();
            }
            return result;
        }
    }
}
