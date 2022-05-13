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
                // TODO: В зависимости от выбора радиокнопки делаем отчёт
                if (this.RadioButton_Reports_Overdue.Checked) {
                    // ...
                } else if (this.RadioButton_Reports_History.Checked) {
                    // ...
                } else if (this.RadioButton_Reports_Lost.Checked) {
                    // ...
                }

                this.UnfocusAll();
                FormHelper.SendSuccessMessage(this, "Отчёт успешно экспортирован!");
            });
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
