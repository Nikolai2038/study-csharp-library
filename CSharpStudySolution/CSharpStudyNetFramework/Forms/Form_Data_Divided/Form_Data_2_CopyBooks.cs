using CSharpStudyNetFramework.Extra;
using CSharpStudyNetFramework.Helpers;
using CSharpStudyNetFramework.ORM.Models;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

// ######################################################################
// Форма данных - Вкладка "Экземпляры книг"
// ######################################################################

namespace CSharpStudyNetFramework.Forms.Form_Data_Divided
{
    /// <summary>Форма с данными</summary>
    public partial class Form_Data : Form_Base
    {
        /// <summary>Событие изменения выбранной строчки в таблице во вкладке "Экземпляры книг"</summary>
        private void Grid_CopyBooks_SelectionChanged(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, false, () => {
                // Если выбрана строчка - заменяем текст в текстбоксах на значения из выбранной записи
                if (this.Grid_CopyBooks.SelectedRows.Count > 0) {
                    // Кнопки изменения и удаления делаем доступными
                    this.Button_CopyBooks_Edit.Enabled = this.Button_CopyBooks_Delete.Enabled = true;

                    // Находим сущность, выбранную в таблице
                    int selected_id = Convert.ToInt32(this.Grid_CopyBooks.SelectedRows[0].Cells[0].Value);
                    CopyBook selected_copy_book = DatabaseHelper.SelectFirstOrFormException(
                        DatabaseHelper.db.CopyBooks,
                        selected_id
                    );

                    // -----------------------------------------
                    // Заполняем форму значениями сущности
                    // -----------------------------------------
                    int selected_author_index_in_combobox = -1;
                    if (selected_copy_book.Book != null) {
                        selected_author_index_in_combobox = this.ComboBox_CopyBooks_Book.Items.IndexOf(selected_copy_book.Book.ToString());
                    }
                    this.ComboBox_CopyBooks_Book.SelectedIndex = selected_author_index_in_combobox;

                    this.TextBox_CopyBooks_Number.Text = selected_copy_book.Number;
                    // -----------------------------------------
                }
                // Если нет выбора - очищаем текстбоксы
                else {
                    // Кнопки изменения и удаления делаем недоступными
                    this.Button_CopyBooks_Edit.Enabled = this.Button_CopyBooks_Delete.Enabled = false;

                    // Очищаем форму (значения по умолчанию)
                    this.ComboBox_CopyBooks_Book.SelectedIndex = -1;
                    this.TextBox_CopyBooks_Number.Clear();
                }
            });
        }

        /// <summary>Событие изменения текста в поле "Номер"</summary>
        private void TextBox_CopyBooks_Number_TextChanged(object sender, EventArgs e)
        {
            // Кнопка создания блокируется, если поле ввода номера пустое
            this.Button_CopyBooks_Create.Enabled = this.TextBox_CopyBooks_Number.Text != "";
        }

        /// <summary>Событие нажатия на кнопку "Добавить экземпляр книги"</summary>
        private void Button_CopyBooks_Create_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                this.CreateOrEditCopyBook(true);
                this.UnfocusAll();

                // Выбираем последнюю строчку в таблице
                this.Grid_CopyBooks.ClearSelection();
                this.Grid_CopyBooks.Rows[this.Grid_CopyBooks.Rows.Count - 1].Selected = true;

                FormHelper.SendSuccessMessage(this, "Экземпляр книги успешно добавлен!");
            });
        }

        /// <summary>Событие нажатия на кнопку "Изменить информацию об экземпляре книги"</summary>
        private void Button_CopyBooks_Edit_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                this.CreateOrEditCopyBook(false);
                this.UnfocusAll();
                FormHelper.SendSuccessMessage(this, "Экземпляр книги успешно отредактирован!");
            });
        }

        /// <summary>Создаёт новый или изменяет выбранный экземпляр книги (смотрит на поля ввода)</summary>
        /// <param name="is_new">Если true - из введённых данных будет создан новый экземпляр книги. Если false - будет изменён выбранный экземпляр книги в таблице</param>
        private void CreateOrEditCopyBook(bool is_new)
        {
            // Книга
            Book selected_book = DatabaseHelper.SelectFirstOrFormException(
                DatabaseHelper.db.Books,
                this.ComboBox_CopyBooks_Book.Text
            );
            // Номер экземпляра
            string number = this.TextBox_CopyBooks_Number.Text.Trim();
            if (number == "") {
                throw new FormException("Необходимо указать номер экземпляра!");
            }

            // Создание новой книги
            if (is_new) {
                // Создаём и сохраняем новую книгу
                CopyBook new_entity = new CopyBook {
                    Book = selected_book,
                    Number = number
                };
                DatabaseHelper.db.CopyBooks.Add(new_entity);
            }
            // Изменение выбранной книги
            else {
                if (this.Grid_CopyBooks.SelectedRows.Count > 0) {
                    // Изменяем и сохраняем выбранного автора в таблице
                    int selected_id = Convert.ToInt32(this.Grid_CopyBooks.SelectedRows[0].Cells[0].Value);
                    CopyBook found_entity = DatabaseHelper.SelectFirstOrFormException(
                        DatabaseHelper.db.CopyBooks,
                        selected_id
                    );

                    // Обновление полей
                    found_entity.Book = selected_book;
                    found_entity.Number = number;

                    DatabaseHelper.db.CopyBooks.Update(found_entity);
                } else {
                    throw new FormException("Экземпляр книги для изменения не выбран!");
                }
            }

            DatabaseHelper.db.SaveChanges();
            this.UpdateCurrentSelectedTab();
        }

        /// <summary>Событие нажатия на кнопку "Удалить экземпляр книги"</summary>
        private void Button_CopyBooks_Delete_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                if (this.Grid_CopyBooks.SelectedRows.Count > 0) {
                    // Удаляем все выбранные записи
                    foreach (DataGridViewRow row in this.Grid_CopyBooks.SelectedRows) {
                        // Находим выбранную книгу в БД
                        int selected_id = Convert.ToInt32(row.Cells[0].Value);
                        CopyBook selected_copy_book = DatabaseHelper.SelectFirstOrFormException(
                            DatabaseHelper.db.CopyBooks,
                            selected_id
                        );

                        DatabaseHelper.db.CopyBooks.Remove(selected_copy_book);
                        DatabaseHelper.db.SaveChanges();
                    }

                    // Обновляем таблицу (также обновит все связанные комбобоксы)
                    this.UpdateData(new List<MetroGrid>() {
                        this.Grid_CopyBooks,
                    });

                    // Снимаем выделение в таблице
                    this.Grid_CopyBooks.ClearSelection();

                    FormHelper.SendSuccessMessage(this, "Экземпляр книги успешно удалён!");
                }
            });
        }
    }
}
