using Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CSharpStudyNetFramework.Helpers
{
    /// <summary>Вспомогательный класс для экспорта Excel</summary>
    internal abstract class ExcelHelper
    {
        /// <summary>Запускает диалог для сохранения файла, и, в случае выбора "ОК", заполняет и сохраняет файл Excel данными переданной таблицы DataGridView</summary>
        /// <param name="grid">Таблица, откуда берутся данные (в том числе и столбцы)</param>
        /// <param name="file_name">Название файла, предлагаемого в окне сохранения</param>
        /// <returns>True в случае успешного сохранения, false - в случае отмены. А в случае ошибок могут вылетать исключения.</returns>
        public static bool ExportDataGridView(DataGridView grid, string file_name = "Отчёт")
        {
            // Если в таблице нет данных - ничего не экспортируем
            if (grid.Rows.Count == 0) {
                return false;
            }

            // ---------------------------------------------------
            // Создание документа Excel
            // ---------------------------------------------------
            // Тут прямая ссылка во избежания конфликта пространств имён
            Microsoft.Office.Interop.Excel.Application excel_application = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel_application.Workbooks.Add(Type.Missing);
            _Worksheet worksheet = null;
            // Тут важно указать "Лист1", так как Excel автоматически создаёт его
            worksheet = workbook.Sheets["Лист1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Output";
            worksheet.Application.ActiveWindow.SplitRow = 1;
            worksheet.Application.ActiveWindow.FreezePanes = true;
            // ---------------------------------------------------

            // ---------------------------------------------------
            // Изменение стиля ячеек
            // Стоит учитывать, что нумерация строчек и столбцов в Excel идёт не с нуля, а с единицы
            // ---------------------------------------------------
            // Стиль всех заполняемых ячеек (строчек на 1 больше, так как обрабатываем ещё и заголовки)
            Range cells_all_filled = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[grid.Rows.Count + 1, grid.Columns.Count]];
            cells_all_filled.Borders.LineStyle = XlLineStyle.xlLineStyleNone;
            cells_all_filled.Borders.Weight = 2;
            cells_all_filled.Font.Name = "Calibri";
            cells_all_filled.Font.Size = 11;
            // Стиль ячеек для первой строчки - заголовков
            Range cells_headers = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, grid.Columns.Count]];
            cells_headers.RowHeight = 30;
            cells_headers.Font.Bold = true;
            cells_headers.Interior.Color = Color.LightBlue;
            cells_headers.Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            cells_headers.Style.VerticalAlignment = XlVAlign.xlVAlignCenter;
            // Стиль ячеек для данных
            // Range cells_data = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[grid.Rows.Count + 1, grid.Columns.Count]];
            // ...
            // ---------------------------------------------------

            // ---------------------------------------------------
            // Заполнение данных
            // ---------------------------------------------------
            // Заполнение текста заголовков
            for (int i = 1; i < grid.Columns.Count + 1; i++) {
                worksheet.Cells[1, i] = grid.Columns[i - 1].HeaderText;
            }
            // Заполнение самих данных
            for (int i = 0; i < grid.Rows.Count; i++) {
                for (int j = 0; j < grid.Columns.Count; j++) {
                    worksheet.Cells[i + 2, j + 1] = grid.Rows[i].Cells[j].Value.ToString();
                }
            }
            // Автоматическая настройка ширины столбцов по заполненным данным
            worksheet.Columns.AutoFit();
            // ---------------------------------------------------

            // ---------------------------------------------------
            // Сохранение заполненного документа
            // ---------------------------------------------------
            // Создаём и показываем диалог сохранения файла
            SaveFileDialog save_dialog = new SaveFileDialog {
                Filter = "Excel (.xlsx)|  *.xlsx",
                FileName = file_name + ".xlsx"
            };
            if (save_dialog.ShowDialog() != DialogResult.OK) {
                return false;
            }
            // Удаляем файл, в который будем экспортировать, если он существует
            if (File.Exists(save_dialog.FileName)) {
                File.Delete(save_dialog.FileName);
            }
            // Само сохранение
            workbook.SaveAs(save_dialog.FileName);
            excel_application.Quit();
            // Очистка данных
            ReleaseObject(worksheet);
            ReleaseObject(workbook);
            ReleaseObject(excel_application);
            // ---------------------------------------------------

            return true;
        }

        /// <summary>Очищает память</summary>
        /// <param name="obj">Объект, который будет удалён</param>
        private static void ReleaseObject(object obj)
        {
            try {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            } catch (Exception exception) {
                obj = null;
                throw new Exception(exception.Message);
            } finally {
                GC.Collect();
            }
        }
    }
}
