using CSharpStudyNetFramework.Helpers;
using CSharpStudyNetFramework.ORM.Models;
using System;

// ######################################################################
// Форма данных - Вкладка "Возврат книг"
// ######################################################################

namespace CSharpStudyNetFramework.Forms.Form_Data_Divided
{
    /// <summary>Форма с данными</summary>
    public partial class Form_Data : Form_Base
    {
        /// <summary>Выбранный читатель на вкладке "Возврат книг"</summary>
        private Reader Returns_SelectedReader = null;

        /// <summary>Событие изменения текста в комбобоксе "Читатель"</summary>
        private void ComboBox_Returns_Reader_TextUpdate(object sender, EventArgs e)
        {
            // ---------------------------------------
            // Проверка введённого читателя
            // ---------------------------------------
            string selected_reader_as_string = this.ComboBox_Issuance_Reader.Text;
            // Если в списке комбобокса присутствует введённый текст
            if (this.ComboBox_Issuance_Reader.Items.Contains(selected_reader_as_string)) {
                this.Returns_SelectedReader = null;

                // TODO: Ищем читателя в БД
                // ...
            }
            // ---------------------------------------

            // Обновляем таблицу (так как кнопки привязаны к выделению в таблице - нет необходимости их обрабатывать тут)
            this.UpdateData(this.Grid_Returns);
        }

        /// <summary>Событие изменения выбранной строчки в таблице "Формуляры"</summary>
        private void Grid_Returns_SelectionChanged(object sender, EventArgs e)
        {
            // Разблокируем кнопки, если выбрана строчка. Иначе - блокируем
            this.Button_Returns_Return.Enabled = this.Button_Returns_Lost.Enabled = this.Grid_Returns.SelectedRows.Count > 0;
        }

        /// <summary>Событие нажатия на кнопку "Возврат выделенной книги"</summary>
        private void Button_Returns_Return_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                // TODO: Делаем выделенную книгу в таблице возвращённой
                // ...

                // Обновляем таблицу (отображаются только забранные читателем книги)
                this.UpdateCurrentSelectedTab();

                this.UnfocusAll();
                FormHelper.SendSuccessMessage(this, "Экземпляр книги успешно возвращён!");
            });
        }

        /// <summary>Событие нажатия на кнопку "Выделенная книга потеряна"</summary>
        private void Button_Returns_Lost_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                // TODO: Делаем выделенную книгу в таблице потерянной
                // ...

                // Обновляем таблицу (отображаются только забранные читателем книги)
                this.UpdateCurrentSelectedTab();

                this.UnfocusAll();
                FormHelper.SendSuccessMessage(this, "Экземпляр книги помечен как потерянный!");
            });
        }

        // ======================================================================
        // Фильтрация на вкладке "Возврат книг"
        // ======================================================================
        /// <summary>Событие изменения параметров фильтрации</summary>
        private void Component_Returns_Search_ConditionsChanged(object sender, EventArgs e)
        {
            // Обновляем данные только если установлена галочка "Поиск в реальном времени"
            if (this.CheckBox_Returns_Search_IsInRealTime.Checked) {
                // Нужно обновить только одну таблицу и ничего больше - поэтому не используем UpdateCurrentSelectedTab()
                this.UpdateData(this.Grid_Returns);
            }
        }

        /// <summary>Событие нажатия на кнопку "Поиск"</summary>
        private void Button_Returns_Search_Click(object sender, EventArgs e)
        {
            // Нужно обновить только одну таблицу и ничего больше - поэтому не используем UpdateCurrentSelectedTab()
            this.UpdateData(this.Grid_Returns);

            this.UnfocusAll();
        }

        /// <summary>Событие изменения галочки "Поиск в реальном времени"</summary>
        private void CheckBox_Returns_Search_IsInRealTime_CheckedChanged(object sender, EventArgs e)
        {
            // Блокируем кнопку поиска, если включён поиск в реальном времени, и наоборот
            this.Button_Returns_Search.Enabled = !this.CheckBox_Returns_Search_IsInRealTime.Checked;

            // Нужно обновить только одну таблицу и ничего больше - поэтому не используем UpdateCurrentSelectedTab()
            this.UpdateData(this.Grid_Returns);

            this.UnfocusAll();
        }

        /// <summary>Событие нажатия на кнопку "Сбросить фильтр"</summary>
        private void Button_Returns_Search_Reset_Click(object sender, EventArgs e)
        {
            // Очищаем фильтр и фокусируемся на текстовом поле ввода
            this.RadioButton_Returns_Search_Author.Checked = true;
            this.TextBox_Returns_Search.Text = "";
            this.TextBox_Returns_Search.Focus();

            // Нужно обновить только одну таблицу и ничего больше - поэтому не используем UpdateCurrentSelectedTab()
            this.UpdateData(this.Grid_Returns);
        }
        // ======================================================================
    }
}
