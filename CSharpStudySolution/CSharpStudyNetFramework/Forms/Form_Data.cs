using CSharpStudyNetFramework.Helpers;
using CSharpStudyNetFramework.ORM.Models;
using System;
using System.Linq;

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

        /// <summary>Событие нажатия на кнопку создания новой записи</summary>
        private void Button_Create_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, () => {
                // Создаём и добавляем в БД новую запись
                Author item = new Author("Димооон");
                DatabaseHelper.db_context.authors.Add(item);
                DatabaseHelper.db_context.SaveChanges();
            });
            // Обновление данных таблицы
            this.UpdateData();
        }

        /// <summary>Событие нажатия на кнопку удаления выбранной записи</summary>
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            // Должна быть выбрана строчка
            if (this.Grid_Data.SelectedRows.Count > 0) {
                // Находим ID записи, которую необходимо удалить
                int selected_row_id = this.Grid_Data.SelectedRows[0].Index;
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

                // Обновление данных таблицы
                this.UpdateData();
            }
        }

        /// <summary>Обновляет данные в таблице</summary>
        private void UpdateData()
        {
            ExceptionHelper.CheckCode(this, () => {
                this.Grid_Data.DataSource = DatabaseHelper.db_context.authors.ToList();
            });
        }
    }
}
