using CSharpStudyNetFramework.Extra;
using CSharpStudyNetFramework.Helpers;
using CSharpStudyNetFramework.ORM.Models;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            string selected_reader_as_string = this.ComboBox_Issuance_Reader.Text.Trim();
            // Если в списке комбобокса присутствует введённый текст
            if (this.ComboBox_Issuance_Reader.Items.Contains(selected_reader_as_string)) {
                // Находим выбранного в комбобоксе читателя в БД
                this.Issuance_SelectedReader = DatabaseHelper.SelectFirstOrFormException(
                    DatabaseHelper.db.Readers,
                    selected_reader_as_string,
                    false
                );

                // Если читатель не найден
                if (this.Issuance_SelectedReader == null) {
                    return false;
                }
            } else {
                this.Issuance_SelectedReader = null;
                return false;
            }
            // ---------------------------------------

            // Выбор книги не проверяем, так как проверяется экземпляр

            // ---------------------------------------
            // Проверка введённого экземпляра книги
            // ---------------------------------------
            string selected_copybook_as_string = this.ComboBox_Issuance_CopyBook.Text.Trim();
            // Если в списке комбобокса присутствует введённый текст
            if (this.ComboBox_Issuance_CopyBook.Items.Contains(selected_copybook_as_string)) {
                // Находим выбранный в комбобоксе экземпляр книги в БД
                this.Issuance_SelectedCopyBook = DatabaseHelper.SelectFirstOrFormException(
                    DatabaseHelper.db.CopyBooks,
                    selected_copybook_as_string,
                    false
                );

                // Если экземпляр книги не найден
                if (this.Issuance_SelectedCopyBook == null) {
                    return false;
                }
            } else {
                this.Issuance_SelectedCopyBook = null;
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
                if (this.Issuance_SelectedCopyBook.IsGiven) {
                    throw new FormException("Выбранный экземпляр книги уже отдан читатенлю какому-то читателю!");
                }
                if (this.Issuance_SelectedCopyBook.IsLost) {
                    throw new FormException("Выбранный экземпляр книги утерян!");
                }

                // Создаём запись
                Order order = new Order() {
                    Reader = Issuance_SelectedReader,
                    CopyBook = Issuance_SelectedCopyBook,
                    DateGiven = this.DateTime_Issuance_DateGiven.Value,
                    DateReturned = this.DateTime_Issuance_DateReturned.Value,
                    IsReturned = false,
                };

                // Делаем экземпляр книги выданным
                this.Issuance_SelectedCopyBook.IsGiven = true;

                DatabaseHelper.db.Orders.Add(order);
                DatabaseHelper.db.SaveChanges();

                // Обновляем таблицы записей, так как их данные могли поменяться
                this.UpdateData(new List<MetroGrid>() {
                    this.Grid_CopyBooks,
                    this.Grid_Orders_Orders,
                    this.Grid_Returns
                });

                // Вызываем метод изменения текста в комбобоксе выбора книги, чтобы пересчитать экземпляры книги
                this.ComboBox_Issuance_Book_TextChanged(sender, e);

                FormHelper.SendSuccessMessage(this, "Экземпляр книги успешно выдан!");
            });
            this.UnfocusAll();
        }

        /// <summary>Событие обновления текста в комбобоксе "Читатель"</summary>
        private void ComboBox_Issuance_Reader_TextChanged(object sender, EventArgs e)
        {
            // Блокируем кнопку, если что-то введено неправильно
            this.Button_Issuance_Issue.Enabled = this.CheckIssuanceConditions();
        }

        /// <summary>Событие обновления текста в комбобоксе "Книга"</summary>
        private void ComboBox_Issuance_Book_TextChanged(object sender, EventArgs e)
        {
            // Так как изменили книгу, очищаем список экземпляров книги
            this.ComboBox_Issuance_CopyBook.Items.Clear();
            this.ComboBox_Issuance_CopyBook.Text = "";
            this.ComboBox_Issuance_CopyBook.Enabled = false;

            string selected_book_as_string = this.ComboBox_Issuance_Book.Text.Trim();
            // Если в списке комбобокса присутствует введённый текст
            if (this.ComboBox_Issuance_Book.Items.Contains(selected_book_as_string)) {
                // Находим выбранную в комбобоксе книгу в БД
                Book book = DatabaseHelper.SelectFirstOrFormException(
                    DatabaseHelper.db.Books,
                    selected_book_as_string,
                    false
                );

                // Если книга найдена
                if (book != null) {
                    // Находим все не выданные экземпляры книги
                    IEnumerable<CopyBook> data_not_list = DatabaseHelper.db.CopyBooks.Where(
                        new Func<CopyBook, bool>((CopyBook entity) => {
                            return (entity.Book.Id == book.Id) && !entity.IsGiven && !entity.IsLost;
                        })
                    );
                    string[] data_for_combobox = DatabaseHelper.GetStringArrayForComboBoxes(data_not_list.ToList());

                    // ------------------------------------------------
                    // Записываем экземпляры книги в комбобокс
                    // ------------------------------------------------
                    this.ComboBox_Issuance_CopyBook.Enabled = true;
                    // Заполнение самого списка
                    this.ComboBox_Issuance_CopyBook.Items.Clear();
                    this.ComboBox_Issuance_CopyBook.Items.AddRange(data_for_combobox);
                    // Настройки для автодополнения
                    this.ComboBox_Issuance_CopyBook.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                    this.ComboBox_Issuance_CopyBook.AutoCompleteCustomSource.AddRange(data_for_combobox);
                    this.ComboBox_Issuance_CopyBook.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    this.ComboBox_Issuance_CopyBook.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    // ------------------------------------------------
                }
            }

            // Блокируем кнопку, если что-то введено неправильно
            this.Button_Issuance_Issue.Enabled = this.CheckIssuanceConditions();
        }

        /// <summary>Событие обновления текста в комбобоксе "Экземпляр книги"</summary>
        private void ComboBox_Issuance_CopyBook_TextChanged(object sender, EventArgs e)
        {
            // Блокируем кнопку, если что-то введено неправильно
            this.Button_Issuance_Issue.Enabled = this.CheckIssuanceConditions();
        }
    }
}
