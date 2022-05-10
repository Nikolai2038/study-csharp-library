using CSharpStudyNetFramework.Helpers;
using CSharpStudyNetFramework.ORM.Models;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

// ######################################################################
// Форма данных - Вкладка "Формуляры"
// ######################################################################

namespace CSharpStudyNetFramework.Forms.Form_Data_Divided
{
    /// <summary>Форма с данными</summary>
    public partial class Form_Data : Form_Base
    {
        // ======================================================================
        // Таблица "Читатели"
        // ======================================================================
        /// <summary>Событие изменения выбранной строчки в таблице "Читатели"</summary>
        private void Grid_Orders_Readers_SelectionChanged(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, false, () => {
                // Если выбрана строчка - заменяем текст в текстбоксах на значения из выбранной записи; разблокируем кнопки изменения и удаления
                if (this.Grid_Orders_Readers.SelectedRows.Count > 0) {
                    this.Button_Orders_Readers_Edit.Enabled = this.Button_Orders_Readers_Delete.Enabled = true;

                    // Находим выбранную запись в БД
                    int selected_id = Convert.ToInt32(this.Grid_Orders_Readers.SelectedRows[0].Cells[0].Value);
                    Reader found_entity = DatabaseHelper.SelectFirstOrFormException(
                        DatabaseHelper.db.Readers,
                        selected_id
                    );

                    this.TextBox_Orders_Reader_LastName.Text = found_entity.LastName;
                    this.TextBox_Orders_Reader_FirstName.Text = found_entity.FirstName;
                    this.TextBox_Orders_Reader_MiddleName.Text = found_entity.MiddleName;
                    this.TextBox_Orders_Reader_Info.Text = found_entity.Info;
                }
                // Если нет выбора - очищаем текстбоксы; блокируем кнопки изменения и удаления
                else {
                    this.Button_Orders_Readers_Edit.Enabled = this.Button_Orders_Readers_Delete.Enabled = false;

                    this.TextBox_Orders_Reader_LastName.Clear();
                    this.TextBox_Orders_Reader_FirstName.Clear();
                    this.TextBox_Orders_Reader_MiddleName.Clear();
                    this.TextBox_Orders_Reader_Info.Clear();
                }

                // Обновляем таблицу записей (фильтрация идёт внутри метода)
                this.UpdateData(this.Grid_Orders_Orders);
            });
        }

        /// <summary>Событие изменения текста в форме добавления/редактирования читателя</summary>
        private void TextBox_Orders_Reader_TextChanged(object sender, EventArgs e)
        {
            // Кнопка создания доступна только если введена фамилия и имя читателя
            this.Button_Orders_Readers_Create.Enabled = (this.TextBox_Orders_Reader_LastName.Text.Trim() != "") && (this.TextBox_Orders_Reader_FirstName.Text.Trim() != "");
        }

        /// <summary>Событие нажатия на кнопку "Добавить читателя"</summary>
        private void Button_Orders_Readers_Add_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                // Создаём и сохраняем нового читателя
                Reader new_entity = new Reader {
                    LastName = this.TextBox_Orders_Reader_LastName.Text,
                    FirstName = this.TextBox_Orders_Reader_FirstName.Text,
                    MiddleName = this.TextBox_Orders_Reader_MiddleName.Text,
                    Info = this.TextBox_Orders_Reader_Info.Text
                };
                DatabaseHelper.db.Readers.Add(new_entity);
                DatabaseHelper.db.SaveChanges();
                this.UpdateCurrentSelectedTab();

                // Выбираем последнюю строчку в таблице
                this.Grid_Orders_Readers.ClearSelection();
                this.Grid_Orders_Readers.Rows[this.Grid_Orders_Readers.Rows.Count - 1].Selected = true;

                this.UnfocusAll();
                FormHelper.SendSuccessMessage(this, "Читатель успешно добавлен!");
            });
        }

        /// <summary>Событие нажатия на кнопку "Изменить информацию о читателе"</summary>
        private void Button_Orders_Readers_Edit_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                if (this.Grid_Orders_Readers.SelectedRows.Count > 0) {
                    // Находим выбранного в таблице читателя в БД
                    int selected_id = Convert.ToInt32(this.Grid_Orders_Readers.SelectedRows[0].Cells[0].Value);
                    Reader found_entity = DatabaseHelper.SelectFirstOrFormException(
                        DatabaseHelper.db.Readers,
                        selected_id
                    );

                    found_entity.FirstName = this.TextBox_Orders_Reader_LastName.Text;
                    found_entity.LastName = this.TextBox_Orders_Reader_FirstName.Text;
                    found_entity.MiddleName = this.TextBox_Orders_Reader_MiddleName.Text;
                    found_entity.Info = this.TextBox_Orders_Reader_Info.Text;

                    DatabaseHelper.db.Readers.Update(found_entity);
                    DatabaseHelper.db.SaveChanges();

                    // Обновляем как читателей, так и записи
                    this.UpdateData(new List<MetroGrid>() {
                        this.Grid_Orders_Readers,
                        this.Grid_Orders_Orders,
                    });

                    this.UnfocusAll();
                    FormHelper.SendSuccessMessage(this, "Информация о читателе успешно отредактирована!");
                }
            });
        }

        /// <summary>Событие нажатия на кнопку "Удалить читателя"</summary>
        private void Button_Orders_Readers_Delete_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                if (this.Grid_Orders_Readers.SelectedRows.Count > 0) {
                    // Удаляем все выбранные записи
                    foreach (DataGridViewRow row in this.Grid_Orders_Readers.SelectedRows) {
                        // Находим выбранного в таблице читателя в БД
                        int selected_id = Convert.ToInt32(row.Cells[0].Value);
                        Reader found_entity = DatabaseHelper.SelectFirstOrFormException(
                            DatabaseHelper.db.Readers,
                            selected_id
                        );

                        DatabaseHelper.db.Readers.Remove(found_entity);
                        DatabaseHelper.db.SaveChanges();
                    }

                    // Обновляем как читателей, так и записи
                    this.UpdateData(new List<MetroGrid>() {
                        this.Grid_Orders_Readers,
                        this.Grid_Orders_Orders,
                    });

                    // Снимаем выделение в таблице
                    this.Grid_Orders_Readers.ClearSelection();

                    this.UnfocusAll();
                    FormHelper.SendSuccessMessage(this, "Читатель успешно удалён!");
                }
            });
        }

        // ----------------------------------------------------------------------
        // Фильтрация таблицы "Читатели"
        // ----------------------------------------------------------------------
        /// <summary>Событие изменения параметров фильтрации</summary>
        private void Component_Orders_Readers_Search_ConditionsChanged(object sender, EventArgs e)
        {
            // Обновляем данные только если установлена галочка "Поиск в реальном времени"
            if (this.CheckBox_Orders_Readers_Search_IsInRealTime.Checked) {
                // Нужно обновить только одну таблицу и ничего больше - поэтому не используем UpdateCurrentSelectedTab()
                this.UpdateData(this.Grid_Orders_Readers);
            }
        }

        /// <summary>Событие нажатия на кнопку "Поиск"</summary>
        private void Button_Orders_Readers_Search_Click(object sender, EventArgs e)
        {
            // Нужно обновить только одну таблицу и ничего больше - поэтому не используем UpdateCurrentSelectedTab()
            this.UpdateData(this.Grid_Orders_Readers);

            this.UnfocusAll();
        }

        /// <summary>Событие изменения галочки "Поиск в реальном времени"</summary>
        private void CheckBox_Orders_Readers_Search_IsInRealTime_CheckedChanged(object sender, EventArgs e)
        {
            // Блокируем кнопку поиска, если включён поиск в реальном времени, и наоборот
            this.Button_Orders_Readers_Search.Enabled = !this.CheckBox_Orders_Readers_Search_IsInRealTime.Checked;

            // Нужно обновить только одну таблицу и ничего больше - поэтому не используем UpdateCurrentSelectedTab()
            this.UpdateData(this.Grid_Orders_Readers);

            this.UnfocusAll();
        }

        /// <summary>Событие нажатия на кнопку "Сбросить фильтр"</summary>
        private void Button_Orders_Readers_Search_Reset_Click(object sender, EventArgs e)
        {
            // Очищаем фильтр и фокусируемся на текстовом поле ввода
            this.TextBox_Orders_Readers_Search.Text = "";
            this.TextBox_Orders_Readers_Search.Focus();

            // Нужно обновить только одну таблицу и ничего больше - поэтому не используем UpdateCurrentSelectedTab()
            this.UpdateData(this.Grid_Orders_Readers);
        }
        // ----------------------------------------------------------------------
        // ======================================================================

        // ======================================================================
        // Таблица "Формуляры"
        // ======================================================================
        /// <summary>Событие изменения выбранной строчки в таблице "Формуляры"</summary>
        private void Grid_Orders_Orders_SelectionChanged(object sender, EventArgs e)
        {
            // Кнопка удаления записей доступна только если выбрана хотя бы одна строчка
            this.Button_Orders_Orders_Delete.Enabled = this.Grid_Orders_Orders.SelectedRows.Count > 0;
        }

        /// <summary>Событие нажатия на кнопку "Удалить выбранные записи"</summary>
        private void Button_Orders_Orders_Delete_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                if (this.Grid_Orders_Orders.SelectedRows.Count > 0) {
                    // Удаляем все выбранные записи
                    foreach (DataGridViewRow row in this.Grid_Orders_Orders.SelectedRows) {
                        // Находим выбранную в таблице запись в БД
                        int selected_id = Convert.ToInt32(row.Cells[0].Value);
                        Order found_entity = DatabaseHelper.SelectFirstOrFormException(
                            DatabaseHelper.db.Orders,
                            selected_id
                        );

                        // Так как запись удаляем, возвращаем свойства "Выдана ли" и "Потеряна ли"
                        // так как другого способа вернуть книги из этих свойств не будет
                        found_entity.CopyBook.IsGiven = false;
                        found_entity.CopyBook.IsLost = false;

                        DatabaseHelper.db.Orders.Remove(found_entity);
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

                    this.UnfocusAll();
                    FormHelper.SendSuccessMessage(this, "Запись успешно удалена!");
                }
            });
        }
        // ======================================================================
    }
}
