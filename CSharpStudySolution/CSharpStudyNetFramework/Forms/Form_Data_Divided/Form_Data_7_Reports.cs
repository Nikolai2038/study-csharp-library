using CSharpStudyNetFramework.Helpers;
using System;

// ######################################################################
// Форма данных - Вкладка "Отчёты"
// ######################################################################

namespace CSharpStudyNetFramework.Forms.Form_Data_Divided
{
    /// <summary>Форма с данными</summary>
    public partial class Form_Data : Form_Base
    {
        /// <summary>Событие нажатия на кнопку "Создать отчёт"</summary>
        private void Button_Reports_Export_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                // Название файла отчёта берётся от названия радиокнопки
                string file_name;
                if (this.RadioButton_Reports_Overdue.Checked) {
                    file_name = this.RadioButton_Reports_Overdue.Text;
                } else if (this.RadioButton_Reports_Lost.Checked) {
                    file_name = this.RadioButton_Reports_Lost.Text;
                } else if (this.RadioButton_Reports_History.Checked) {
                    file_name = this.RadioButton_Reports_History.Text + " " + this.ComboBox_Reports_Reader.Text;
                } else {
                    throw new Exception("При экспорте отчёта не была выбрана ни одна радиокнопка!");
                }

                // Сам экспорт документа
                bool is_success = ExcelHelper.ExportDataGridView(this.Grid_Reports, file_name);

                // Если экспорт вернул false - значит, была отмена (исключения не перехватываются и в случае ошибки покажутся)
                if (is_success) {
                    FormHelper.SendSuccessMessage(this, "Отчёт успешно экспортирован!");
                }
            });
            this.UnfocusAll();
        }

        /// <summary>Событие изменения условий экспорта на вкладке "Отчёты"</summary>
        private void Component_Reports_Export_ConditionsChanged(object sender, EventArgs e)
        {
            // Комбобокс выбора читателя доступен только если выбран пункт "Формуляр читателя:"
            this.ComboBox_Reports_Reader.Enabled = this.RadioButton_Reports_History.Checked;

            // Обновляем таблицу отчёта
            this.UpdateData(this.Grid_Reports);
        }
    }
}
