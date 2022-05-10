using CSharpStudyNetFramework.Helpers;
using CSharpStudyNetFramework.ORM.Models;
using System;

// ######################################################################
// Форма данных - Вкладка "Формуляры"
// ######################################################################

namespace CSharpStudyNetFramework.Forms.Form_Data_Divided
{
    /// <summary>Форма с данными</summary>
    public partial class Form_Data : Form_Base
    {
        // ======================================================================
        // Таблица "Читатели" на вкладке "Формуляры"
        // ======================================================================
        /// <summary>Событие изменения выбранной строчки в таблице во вкладке "Формуляры"</summary>
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
            });
        }

        /// <summary>Событие нажатия на кнопку создания во вкладке "Формуляры"</summary>
        private void Button_Orders_Readers_Add_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, false, () => {
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

                FormHelper.SendSuccessMessage(this, "Читатель успешно добавлен!");
            });
        }

        private void Button_Orders_Readers_Edit_Click(object sender, EventArgs e)
        {

        }

        private void Button_Orders_Readers_Delete_Click(object sender, EventArgs e)
        {

        }
        // ======================================================================

        // ======================================================================
        // Фильтрация на вкладке "Формуляры"
        // ======================================================================
        private void Component_Orders_Readers_Search_ConditionsChanged(object sender, EventArgs e)
        {

        }

        private void Button_Orders_Readers_Search_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox_Orders_Readers_Search_IsInRealTime_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button_Orders_Readers_Search_Reset_Click(object sender, EventArgs e)
        {
            this.TextBox_Orders_Readers_Search.Clear();
        }
        // ======================================================================

        // ======================================================================
        // Таблица "Формуляры" на вкладке "Формуляры"
        // ======================================================================
        private void Grid_Orders_Orders_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void Button_Orders_Orders_Delete_Click(object sender, EventArgs e)
        {

        }
        // ======================================================================
    }
}
