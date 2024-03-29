﻿using CSharpStudyNetFramework.Extra;
using CSharpStudyNetFramework.ORM;
using CSharpStudyNetFramework.ORM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpStudyNetFramework.Helpers
{
    /// <summary>Вспомогательный класс для работы с БД</summary>
    internal abstract class DatabaseHelper
    {
        /// <summary>База данных</summary>
        public static readonly CustomDbContext db = new CustomDbContext();

        /// <summary>
        /// Ассоциативный массив соответствий для сущностей.
        /// Значением является массив из двух строк: [0 = "Название", 1 = "найден"/"найдена"]
        /// </summary>
        private static readonly Dictionary<Type, string[]> EntitiesTexts;

        static DatabaseHelper()
        {
            EntitiesTexts = new Dictionary<Type, string[]> {
                { typeof(Author), new string[] { "Автор", "найден" } },
                { typeof(Book), new string[] { "Книга", "найдена" } },
                { typeof(Bookmaker), new string[] { "Издатель", "найден" } },
                { typeof(CopyBook), new string[] { "Экземпляр книги", "найден" } },
                { typeof(Group), new string[] { "Жанр", "найден" } },
                { typeof(Order), new string[] { "Запись", "найдена" } },
                { typeof(Reader), new string[] { "Читатель", "найден" } }
            };
        }

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

        /// <summary>Возвращает сущность, найденную в указанной выборке</summary>
        /// <typeparam name="T">Класс сущности</typeparam>
        /// <param name="entities">DbSet сущностей в БД</param>
        /// <param name="text_to_find">Текст, с которым должен совпадать результат метода ToString() для сущности</param>
        /// <param name="throw_exception_on_not_found">Если true - в случае ненахождения записи вылетит исключение. Если false - просто вернётся null</param>
        /// <returns>Найденная сущность</returns>
        /// <exception cref="FormException">Исключение формы, вызываемое, если сущность не найдена</exception>
        public static T SelectFirstOrFormException<T>(
            DbSet<T> entities,
            string text_to_find,
            bool throw_exception_on_not_found = true
        ) where T : class, IEntity
        {
            try {
                // Находим первую сущность, результат метода ToString() на которой совпадает с указанной строкой
                // Если сущность не найдена - будет вызвано исключение
                return entities.First(
                    new Func<T, bool>((T entity) => {
                        return entity.ToString().Trim() == text_to_find.Trim();
                    })
                );
            }
            // В случае вызова исключения вызываем исключение формы для его последующей обработки
            catch (Exception) {
                if (throw_exception_on_not_found) {
                    throw new FormException(EntitiesTexts[typeof(T)][0] + " \"" + text_to_find + "\"" + " не " + EntitiesTexts[typeof(T)][1] + " в базе данных!");
                } else {
                    return null;
                }
            }
        }

        /// <summary>Возвращает сущность, найденную в указанной выборке</summary>
        /// <typeparam name="T">Класс сущности</typeparam>
        /// <param name="entities">DbSet сущностей в БД</param>
        /// <param name="id_to_find">ID сущности</param>
        /// <param name="throw_exception_on_not_found">Если true - в случае ненахождения записи вылетит исключение. Если false - просто вернётся null</param>
        /// <returns>Найденная сущность</returns>
        /// <exception cref="FormException">Исключение формы, вызываемое, если сущность не найдена</exception>
        public static T SelectFirstOrFormException<T>(
            DbSet<T> entities,
            int id_to_find,
            bool throw_exception_on_not_found = true
        ) where T : class, IEntity
        {
            try {
                // Находим первую сущность, результат метода ToString() на которой совпадает с указанной строкой
                // Если сущность не найдена - будет вызвано исключение
                return entities.First(
                    new Func<T, bool>((T entity) => {
                        return entity.Id == id_to_find;
                    })
                );
            }
            // В случае вызова исключения вызываем исключение формы для его последующей обработки
            catch (Exception) {
                if (throw_exception_on_not_found) {
                    throw new FormException(EntitiesTexts[typeof(T)][0] + " c ID = " + id_to_find + " не " + EntitiesTexts[typeof(T)][1] + " в базе данных!");
                } else {
                    return null;
                }
            }
        }

        /// <summary>
        /// Проверяет, существует ли уже такая сущность в БД
        /// (существование проверяется совпадением результатов методов .ToString()).
        /// Если да - выводит исключение формы. Если нет - добавляет/изменяет переданную сущность в БД
        /// </summary>
        /// <typeparam name="T">Класс сущности</typeparam>
        /// <param name="entities">DbSet сущностей в БД</param>
        /// <param name="new_entity">Новая/Изменяемая сущность</param>
        /// <param name="is_new">Добавлять или изменять сущность</param>
        /// <exception cref="FormException">Исключение формы, вызываемое, если сущность уже существует</exception>
        public static void TryToAddOrEditEntity<T>(
            DbSet<T> entities,
            T new_entity,
            bool is_new
        ) where T : class, IEntity
        {
            // Пытаемся найти создаваемую сущность в БД (результат метода .ToString() для них должен отличаться)
            T found_exact_entity = DatabaseHelper.SelectFirstOrFormException(
                entities,
                new_entity.ToString(),
                false
            );

            // Если сущность создаётся - просто проверяем, что такой ещё нет
            if ((is_new && found_exact_entity == null)) {
                entities.Add(new_entity);
            }
            // Если сущность изменяется - проверяем, что либо такой сущности нет, либо изменяется она же
            // (ведь сравнение результатов методов .ToString() не выведет разницы, например, при изменении изображения, а сущность обновить нужно)
            else if (!is_new && ((found_exact_entity == null) || (found_exact_entity.Id == new_entity.Id))) {
                entities.Update(new_entity);
            } else {
                // Если модель изменялась - сбрасываем её на старые значения
                if (!is_new) {
                    DatabaseHelper.db.Entry(new_entity).Reload();
                }
                throw new FormException(EntitiesTexts[typeof(T)][0] + " \"" + found_exact_entity.ToString() + "\" уже существует!");
            }
        }
    }
}
