using CSharpStudyNetFramework.Helpers;
using CSharpStudyNetFramework.ORM.Models;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
        private void ComboBox_Returns_Reader_TextChanged(object sender, EventArgs e)
        {
            // ---------------------------------------
            // Проверка введённого читателя
            // ---------------------------------------
            string selected_reader_as_string = this.ComboBox_Returns_Reader.Text.Trim();
            // Если в списке комбобокса присутствует введённый текст
            if (this.ComboBox_Returns_Reader.Items.Contains(selected_reader_as_string)) {
                // Находим выбранного в комбобоксе читателя в БД
                this.Returns_SelectedReader = DatabaseHelper.SelectFirstOrFormException(
                    DatabaseHelper.db.Readers,
                    selected_reader_as_string,
                    false
                );
            } else {
                this.Returns_SelectedReader = null;
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
                if (this.Grid_Returns.SelectedRows.Count > 0) {
                    // Удаляем все выбранные записи
                    foreach (DataGridViewRow row in this.Grid_Returns.SelectedRows) {
                        // Находим выбранную в таблице запись в БД
                        int selected_id = Convert.ToInt32(row.Cells[0].Value);
                        Order found_entity = DatabaseHelper.SelectFirstOrFormException(
                            DatabaseHelper.db.Orders,
                            selected_id
                        );

                        found_entity.DateReturnedFact = DateTime.Now;
                        found_entity.IsReturned = true;
                        found_entity.CopyBook.IsGiven = false;
                        found_entity.CopyBook.IsLost = false;

                        DatabaseHelper.db.Orders.Update(found_entity);
                        DatabaseHelper.db.SaveChanges();
                    }

                    // Обновляем все таблицы с записями
                    this.UpdateData(new List<MetroGrid>() {
                        this.Grid_Orders_Orders,
                        this.Grid_Returns,
                        // Таблицу экземпляров книг тоже нужно обновить, так как там есть чекбоксы, которые могли измениться
                        this.Grid_CopyBooks,
                    });

                    // Снимаем выделение в таблице
                    this.Grid_Orders_Orders.ClearSelection();

                    FormHelper.SendSuccessMessage(this, "Экземпляр книги успешно возвращён!");
                }
            });
            this.UnfocusAll();
        }

        /// <summary>Событие нажатия на кнопку "Выделенная книга потеряна"</summary>
        private void Button_Returns_Lost_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                if (this.Grid_Returns.SelectedRows.Count > 0) {
                    // Удаляем все выбранные записи
                    foreach (DataGridViewRow row in this.Grid_Returns.SelectedRows) {
                        // Находим выбранную в таблице запись в БД
                        int selected_id = Convert.ToInt32(row.Cells[0].Value);
                        Order found_entity = DatabaseHelper.SelectFirstOrFormException(
                            DatabaseHelper.db.Orders,
                            selected_id
                        );

                        found_entity.CopyBook.IsLost = true;

                        DatabaseHelper.db.Orders.Update(found_entity);
                        DatabaseHelper.db.SaveChanges();
                    }

                    // Обновляем все таблицы с записями
                    this.UpdateData(new List<MetroGrid>() {
                        this.Grid_Orders_Orders,
                        this.Grid_Returns,
                        // Таблицу экземпляров книг тоже нужно обновить, так как там есть чекбоксы, которые могли измениться
                        this.Grid_CopyBooks,
                    });

                    // Снимаем выделение в таблице
                    this.Grid_Orders_Orders.ClearSelection();

                    FormHelper.SendSuccessMessage(this, "Экземпляр книги успешно возвращён!");
                }
            });
            this.UnfocusAll();
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
