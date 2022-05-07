using CSharpStudyNetFramework.Helpers;
using CSharpStudyNetFramework.ORM.Models;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CSharpStudyNetFramework.Forms
{
    /// <summary>Форма с данными</summary>
    public partial class Form_Data : Form_Base
    {
        /// <summary>Конструктор формы</summary>
        public Form_Data() : base()
        {
            this.InitializeComponent();
            // Установка темы для формы
            this.SetStyleManager();
        }

        /// <summary>Событие загрузки формы</summary>
        private void Form_Data_Load(object sender, EventArgs e)
        {
            // Обновление данных таблицы
            this.UpdateData();
        }

        /// <summary>Событие нажатия на кнопку обновления данных</summary>
        private void Button_UpdateData_Click(object sender, EventArgs e)
        {
            // Обновление данных таблицы
            this.UpdateData();
        }

        /// <summary>Событие нажатия на кнопку удаления выбранной записи</summary>
        private void Button_DeleteData_Click(object sender, EventArgs e)
        {
            // Должна быть выбрана строчка
            if (this.Grid_Data.SelectedRows.Count > 0) {
                // Находим ID строчки, которую нужно выбрать после удаления данных
                int first_selected_row_id = this.Grid_Data.SelectedRows[0].Index;
                int last_selected_row_id = this.Grid_Data.SelectedRows[this.Grid_Data.SelectedRows.Count - 1].Index;
                int row_id_to_select = first_selected_row_id;
                if (last_selected_row_id < first_selected_row_id) {
                    row_id_to_select = last_selected_row_id;
                }

                // Удаляем все выбранные записи
                foreach (DataGridViewRow row in this.Grid_Data.SelectedRows) {
                    // Находим ID записи, которую необходимо удалить
                    int selected_row_id = row.Index;
                    int item_id = Convert.ToInt32(this.Grid_Data.Rows[selected_row_id].Cells[0].Value);

                    ExceptionHelper.CheckCode(this, () => {
                        // Ищем запись с нужным ID
                        Author item = DatabaseHelper.db_context.authors.FirstOrDefault(c => c.Id == item_id);

                        // Если запись не найдена - вызываем исключение
                        if (item == null) {
                            throw new Exception("Запись с ID = " + item_id + " не найдена!");
                        }
                        // Иначе - удаляем найденную запись и сохраняем БД
                        else {
                            DatabaseHelper.db_context.authors.Remove(item);
                            DatabaseHelper.db_context.SaveChanges();
                        }
                    });
                }

                // Так как таблица обновилась - выбираем ранее сохранённую строчку
                this.Grid_Data.ClearSelection();
                if (row_id_to_select < this.Grid_Data.Rows.Count) {
                    this.Grid_Data.Rows[row_id_to_select].Selected = true;
                }

                // Обновление данных таблицы
                this.UpdateData();
            }
        }

        /// <summary>Событие нажатия на кнопку создания новой записи</summary>
        private void Button_Author_Create_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, () => {
                // Создаём и добавляем в БД новую запись
                Author item = new Author {
                    fName = this.TextBox_Author_FirstName.Text,
                    lName = this.TextBox_Author_LastName.Text,
                    mName = this.TextBox_Author_MiddleName.Text
                };
                DatabaseHelper.db_context.authors.Add(item);
                DatabaseHelper.db_context.SaveChanges();
            });
            // Обновление данных таблицы
            this.UpdateData();
        }

        /// <summary>Обновляет данные в таблице</summary>
        private void UpdateData()
        {
            // Сохраняем ID выбранных строчек
            List<int> selected_rows_ids = new List<int>();
            foreach (DataGridViewRow row in this.Grid_Data.SelectedRows) {
                selected_rows_ids.Add(row.Index);
            }

            ExceptionHelper.CheckCode(this, () => {
                // Обновляем сами данные
                this.Grid_Data.DataSource = DatabaseHelper.db_context.authors.ToList();
            });

            // Так как таблица обновилась - заново выбираем все строчки, которые были выбраны
            this.Grid_Data.ClearSelection();
            foreach (int selected_row_id in selected_rows_ids) {
                // Выбираем строчку только если сохранённое значение выбранной строки не превышает количество строк
                if (selected_row_id < this.Grid_Data.Rows.Count) {
                    this.Grid_Data.Rows[selected_row_id].Selected = true;
                }
            }
        }

        private void TabControl_Data_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected_tab_index = this.TabControl_Data.SelectedIndex;
            MetroGrid grid_to_update;

            switch (selected_tab_index)
            {
                case 0:
                    grid_to_update = this.Grid_Data;
                    break;
                case 1:
                    grid_to_update = this.BookGrid;
                    break;
                default:
                    return;
            }
        }
    }
}
