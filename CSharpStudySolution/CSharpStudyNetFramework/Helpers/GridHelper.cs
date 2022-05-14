using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSharpStudyNetFramework.Helpers
{
    internal abstract class GridHelper
    {
        /// <summary>Ширина колонок каждой таблицы в относительных единицах измерения</summary>
        public static Dictionary<DataGridView, List<int>> GridColumnsWidthUnits;

        /// <summary>Применяет сохранённые ширины столбцов для таблицы</summary>
        /// <param name="grid">Таблица</param>
        public static void AutoResizeGrid(DataGridView grid)
        {
            // Если ещё не сохранялась ширина столбцов - сохраняем
            if (!GridColumnsWidthUnits.ContainsKey(grid) || GridColumnsWidthUnits[grid].Count == 0) {
                GridColumnsWidthUnits[grid] = new List<int>();
                foreach (DataGridViewColumn column in grid.Columns) {
                    GridColumnsWidthUnits[grid].Add(column.Width);
                }
            }
            // Если уже сохранялась - устанавливаем (если колонки в таблице сейчас есть)
            else if (grid.ColumnCount > 0) {
                // --------------------------------------------
                // Проверка правильности заполнения массива
                // --------------------------------------------
                // Если указано больше колонок, чем есть в таблице - обрезаем лишние
                if (GridColumnsWidthUnits[grid].Count > grid.ColumnCount) {
                    GridColumnsWidthUnits[grid] = GridColumnsWidthUnits[grid].GetRange(0, grid.ColumnCount);
                }
                // Если указано меньше колонок, чем есть в таблице - остальные колонки будут добавлены со значением,
                // равному ширине самой минимальной указанной колонки
                else if (GridColumnsWidthUnits[grid].Count < grid.ColumnCount) {
                    int minimum_width_in_units = 1;
                    foreach (DataGridViewColumn column in grid.Columns) {
                        if (column.Width < minimum_width_in_units) {
                            minimum_width_in_units = column.Width;
                        }
                    }
                    for (int i = GridColumnsWidthUnits[grid].Count; i < grid.ColumnCount; i++) {
                        GridColumnsWidthUnits[grid].Add(minimum_width_in_units);
                    }
                }
                // --------------------------------------------

                for (int i = 0; i < grid.ColumnCount; i++) {
                    grid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    // Устанавливаем ширину колонки как процент от ширины всей таблицы
                    grid.Columns[i].Width = GetRealWidthFromWidthUnits(grid, i);
                }
            }
        }

        /// <summary>Возвращает реальную ширину колонки таблицы</summary>
        /// <param name="grid">Таблица</param>
        /// <param name="column_id">ID колонки таблицы</param>
        /// <returns>Реальная ширина, полученная из относительных единиц</returns>
        private static int GetRealWidthFromWidthUnits(DataGridView grid, int column_id)
        {
            // Находим ширину всех колонок вместе
            int all_columns_width = 0;
            foreach (DataGridViewColumn column in grid.Columns) {
                all_columns_width += column.Width;
            }

            // Находим ширину всех колонок вместе в относительных единицах измерения
            int all_columns_width_units = 0;
            foreach (int column_width_units in GridColumnsWidthUnits[grid]) {
                all_columns_width_units += column_width_units;
            }

            // Находим реальную ширину указанной колонки
            return Convert.ToInt32((float)GridColumnsWidthUnits[grid][column_id] * all_columns_width / all_columns_width_units);
        }

        /// <summary>Перезаписывает сохранённые ширины столбцов текущими для таблицы</summary>
        /// <param name="grid">Таблица</param>
        public static void SaveGridColumnsWidth(DataGridView grid)
        {
            if (grid.ColumnCount > 0) {
                GridColumnsWidthUnits[grid] = new List<int>();
                foreach (DataGridViewColumn column in grid.Columns) {
                    GridColumnsWidthUnits[grid].Add(column.Width);
                }
            }
        }
    }
}
