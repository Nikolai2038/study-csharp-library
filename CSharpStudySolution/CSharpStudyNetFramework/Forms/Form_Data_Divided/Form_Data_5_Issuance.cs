using CSharpStudyNetFramework.Helpers;
using CSharpStudyNetFramework.ORM.Models;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;

// ######################################################################
// Форма данных - Вкладка "Выдача книг"
// ######################################################################

namespace CSharpStudyNetFramework.Forms.Form_Data_Divided
{
    /// <summary>Форма с данными</summary>
    public partial class Form_Data : Form_Base
    {
        /// <summary>Выбранный читатель на вкладке "Выдача книг"</summary>
        private Reader Issuance_SelectedReader = null;

        /// <summary>Выбранный экземпляр книги на вкладке "Выдача книг"</summary>
        private CopyBook Issuance_SelectedCopyBook = null;

        /// <summary>Проверяет, все ли необходимые поля указаны для того, чтобы выдать книгу</summary>
        /// <returns>True - если поля заполнены правильно, false - если нет</returns>
        private bool CheckIssuanceConditions()
        {
            // ---------------------------------------
            // Проверка введённого читателя
            // ---------------------------------------
            string selected_reader_as_string = this.ComboBox_Issuance_Reader.Text;
            // Если в списке комбобокса присутствует введённый текст
            if (this.ComboBox_Issuance_Reader.Items.Contains(selected_reader_as_string)) {
                this.Issuance_SelectedReader = null;

                // TODO: Ищем читателя в БД
                // ...

                // Если читатель не найден
                if (this.Issuance_SelectedReader == null) {
                    return false;
                }
            } else {
                return false;
            }
            // ---------------------------------------

            // Выбор книги не проверяем, так как проверяется экземпляр

            // ---------------------------------------
            // Проверка введённого экземпляра книги
            // ---------------------------------------
            string selected_copybook_as_string = this.ComboBox_Issuance_CopyBook.Text;
            // Если в списке комбобокса присутствует введённый текст
            if (this.ComboBox_Issuance_CopyBook.Items.Contains(selected_copybook_as_string)) {
                this.Issuance_SelectedCopyBook = null;

                // TODO: Ищем экземпляр книги в БД
                // ...

                // Если экземпляр книги не найден
                if (this.Issuance_SelectedCopyBook == null) {
                    return false;
                }
            } else {
                return false;
            }
            // ---------------------------------

            // Если всё было найдено, значит, поля введены корректно
            return true;
        }


        /// <summary>Событие нажатия на кнопку "Выдать книгу"</summary>
        private void Button_Issuance_Issue_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                // TODO: Выдаём экземпляр книги Issuance_SelectedCopyBook читателю Issuance_SelectedReader
                // ...

                // Обновляем таблицы записей, так как их данные могли поменяться
                this.UpdateData(new List<MetroGrid>() {
                    this.Grid_Orders_Orders,
                    this.Grid_Returns
                });

                this.UnfocusAll();
                FormHelper.SendSuccessMessage(this, "Экземпляр книги успешно выдан!");
            });
        }

        /// <summary>Событие обновления текста в комбобоксе "Читатель"</summary>
        private void ComboBox_Issuance_Reader_TextUpdate(object sender, EventArgs e)
        {
            // Блокируем кнопку, если что-то введено неправильно
            this.Button_Issuance_Issue.Enabled = this.CheckIssuanceConditions();
        }

        /// <summary>Событие обновления текста в комбобоксе "Книга"</summary>
        private void ComboBox_Issuance_Book_TextUpdate(object sender, EventArgs e)
        {
            // Так как изменили книгу, очищаем список экземпляров книги
            this.ComboBox_Issuance_CopyBook.Items.Clear();
            this.ComboBox_Issuance_CopyBook.Text = "";

            string selected_book_as_string = this.ComboBox_Issuance_Book.Text;
            // Если в списке комбобокса присутствует введённый текст
            if (this.ComboBox_Issuance_Book.Items.Contains(selected_book_as_string)) {
                Book book = null;

                // TODO: Ищем книгу в БД
                // ...

                // Если книга найдена
                if (book != null) {
                    // TODO: Находим все не выданные экземпляры книги
                    // ...

                    // TODO: Записываем экземпляры книги в комбобокс
                    // this.ComboBox_Issuance_CopyBook.Items = ...;
                }
            }

            // Блокируем кнопку, если что-то введено неправильно
            this.Button_Issuance_Issue.Enabled = this.CheckIssuanceConditions();
        }

        /// <summary>Событие обновления текста в комбобоксе "Экземпляр книги"</summary>
        private void ComboBox_Issuance_CopyBook_TextUpdate(object sender, EventArgs e)
        {
            // Блокируем кнопку, если что-то введено неправильно
            this.Button_Issuance_Issue.Enabled = this.CheckIssuanceConditions();
        }
    }
}
