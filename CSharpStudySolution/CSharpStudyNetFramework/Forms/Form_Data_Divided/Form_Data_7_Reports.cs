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
        private void Button_Reports_Create_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                // TODO: В зависимости от выбора радиокнопки делаем отчёт
                if (this.RadioButton_Reports_Orders.Checked) {
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
    }
}
