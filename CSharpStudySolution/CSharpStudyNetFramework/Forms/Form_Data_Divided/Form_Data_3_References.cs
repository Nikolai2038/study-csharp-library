using CSharpStudyNetFramework.Helpers;
using CSharpStudyNetFramework.ORM.Models;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

// ######################################################################
// Форма данных - Вкладка "Справочники"
// ######################################################################

namespace CSharpStudyNetFramework.Forms.Form_Data_Divided
{
    /// <summary>Форма с данными</summary>
    public partial class Form_Data : Form_Base
    {
        /// <summary>Выбирает кнопку-вкладку</summary>
        /// <param name="tabs_buttons">Список кнопок-вкладок</param>
        /// <param name="tabs_containers">Список соответствующих контейнеров для кнопок-вкладок</param>
        /// <param name="selected_button">Выбранная кнопка-вкладка</param>
        private void SelectButtonTab(
            List<Button> tabs_buttons,
            List<Control> tabs_containers,
            Button selected_button
        )
        {
            int tabs_count = tabs_buttons.Count;

            // Дополнительные проверки на правильность кода
            if (tabs_count != tabs_containers.Count) {
                throw new Exception("Количество кнопок-вкладок не соответствует количеству контейнеров для них!");
            }
            if (!tabs_buttons.Contains(selected_button)) {
                throw new Exception("Указанная кнопка не найдена в переданном списке кнопок-вкладок!");
            }

            for (int tab_id = 0; tab_id < tabs_count; tab_id++) {
                Button tab_button = tabs_buttons[tab_id];
                Control tab_container = tabs_containers[tab_id];

                // Выбранную кнопку блокируем, а её соответствующий контейнер показываем
                if (tab_button.Equals(selected_button)) {
                    tab_button.Enabled = false;
                    tab_container.Enabled = true;
                    tab_container.Visible = true;
                    tab_container.Dock = DockStyle.Fill;
                }
                // Другие кнопки разблокируем, но все их соответствующие контейнеры скрываем
                else {
                    tab_button.Enabled = true;
                    tab_container.Enabled = false;
                    tab_container.Visible = false;
                    tab_container.Dock = DockStyle.None;
                }
            }

            this.UnfocusAll();
        }

        /// <summary>Нажатие на кнопку-вкладку на вкладке "Справочники"</summary>
        private void Button_References_Tab_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, false, () => {
                this.SelectButtonTab(
                    this.TabReferences_TabsButtons,
                    this.TabReferences_TabsContainers,
                    sender as Button
                );
            });

            // Вызываем событие смены вкладки для изменения ширины столбцов таблиц
            this.TabControl_Data_SelectedIndexChanged(null, null);
        }

        /// <summary>Событие изменения текста в полях ввода формы "Автор"</summary>
        private void TextBox_References_Author_TextChanged(object sender, EventArgs e)
        {
            // Кнопка создания доступна только если введена фамилия и имя автора
            this.Button_References_Author_Create.Enabled = (this.TextBox_References_Author_LastName.Text.Trim() != "") && (this.TextBox_References_Author_FirstName.Text.Trim() != "");
        }

        /// <summary>Событие изменения текста в полях ввода формы "Жанр"</summary>
        private void TextBox_References_Group_TextChanged(object sender, EventArgs e)
        {
            // Кнопка создания доступна только если введено название жанра
            this.Button_References_Group_Create.Enabled = this.TextBox_References_Group_Title.Text.Trim() != "";
        }

        /// <summary>Событие изменения текста в полях ввода формы "Издатель"</summary>
        private void TextBox_References_Bookmaker_TextChanged(object sender, EventArgs e)
        {
            // Кнопка создания доступна только если введено название издателя
            this.Button_References_Bookmaker_Create.Enabled = this.TextBox_References_Bookmaker_Title.Text.Trim() != "";
        }

        /// <summary>Событие изменения выбранной строчки в таблице "Авторы"</summary>
        private void Grid_References_Author_SelectionChanged(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, false, () => {
                // Если выбрана строчка - заменяем текст в текстбоксах на значения из выбранной записи; разблокируем кнопки изменения и удаления
                if (this.Grid_References_Author.SelectedRows.Count > 0) {
                    this.Button_References_Author_Edit.Enabled = this.Button_References_Author_Delete.Enabled = true;

                    // Находим выбранную запись в БД
                    int selected_id = Convert.ToInt32(this.Grid_References_Author.SelectedRows[0].Cells[0].Value);
                    Author found_entity = DatabaseHelper.SelectFirstOrFormException(
                        DatabaseHelper.db.Authors,
                        selected_id
                    );

                    this.TextBox_References_Author_FirstName.Text = found_entity.FirstName;
                    this.TextBox_References_Author_LastName.Text = found_entity.LastName;
                    this.TextBox_References_Author_MiddleName.Text = found_entity.MiddleName;
                }
                // Если нет выбора - очищаем текстбоксы; блокируем кнопки изменения и удаления
                else {
                    this.Button_References_Author_Edit.Enabled = this.Button_References_Author_Delete.Enabled = false;

                    this.TextBox_References_Author_FirstName.Clear();
                    this.TextBox_References_Author_LastName.Clear();
                    this.TextBox_References_Author_MiddleName.Clear();
                }
            });
        }

        /// <summary>Событие изменения выбранной строчки в таблице "Жанры"</summary>
        private void Grid_References_Group_SelectionChanged(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, false, () => {
                // Если выбрана строчка - заменяем текст в текстбоксах на значения из выбранной записи; разблокируем кнопки изменения и удаления
                if (this.Grid_References_Group.SelectedRows.Count > 0) {
                    this.Button_References_Group_Edit.Enabled = this.Button_References_Group_Delete.Enabled = true;

                    // Находим выбранную запись в БД
                    int selected_id = Convert.ToInt32(this.Grid_References_Group.SelectedRows[0].Cells[0].Value);
                    Group found_entity = DatabaseHelper.SelectFirstOrFormException(
                        DatabaseHelper.db.Groups,
                        selected_id
                    );

                    this.TextBox_References_Group_Title.Text = found_entity.Title;
                }
                // Если нет выбора - очищаем текстбоксы; блокируем кнопки изменения и удаления
                else {
                    this.Button_References_Group_Edit.Enabled = this.Button_References_Group_Delete.Enabled = false;

                    this.TextBox_References_Group_Title.Clear();
                }
            });
        }

        /// <summary>Событие изменения выбранной строчки в таблице "Издатели"</summary>
        private void Grid_References_Bookmaker_SelectionChanged(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, false, () => {
                // Если выбрана строчка - заменяем текст в текстбоксах на значения из выбранной записи; разблокируем кнопки изменения и удаления
                if (this.Grid_References_Bookmaker.SelectedRows.Count > 0) {
                    this.Button_References_Bookmaker_Edit.Enabled = this.Button_References_Bookmaker_Delete.Enabled = true;

                    // Находим выбранную запись в БД
                    int selected_id = Convert.ToInt32(this.Grid_References_Bookmaker.SelectedRows[0].Cells[0].Value);
                    Bookmaker found_entity = DatabaseHelper.SelectFirstOrFormException(
                        DatabaseHelper.db.Bookmakers,
                        selected_id
                    );

                    this.TextBox_References_Bookmaker_Title.Text = found_entity.Title;
                    this.TextBox_References_Bookmaker_City.Text = found_entity.City;
                }
                // Если нет выбора - очищаем текстбоксы; блокируем кнопки изменения и удаления
                else {
                    this.Button_References_Bookmaker_Edit.Enabled = this.Button_References_Bookmaker_Delete.Enabled = false;

                    this.TextBox_References_Bookmaker_Title.Clear();
                    this.TextBox_References_Bookmaker_City.Clear();
                }
            });
        }

        /// <summary>Событие нажатия на кнопку создания во вкладке "Справочники" - "Авторы"</summary>
        private void Button_References_Author_Create_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, false, () => {
                // Создаём и сохраняем нового автора
                Author new_entity = new Author {
                    FirstName = this.TextBox_References_Author_FirstName.Text,
                    LastName = this.TextBox_References_Author_LastName.Text,
                    MiddleName = this.TextBox_References_Author_MiddleName.Text
                };

                // Проверяем, что такой же сущности не существует и добавляем/изменяем её
                DatabaseHelper.TryToAddOrEditEntity(DatabaseHelper.db.Authors, new_entity, true);

                DatabaseHelper.db.SaveChanges();
                this.UpdateCurrentSelectedTab();

                // Выбираем последнюю строчку в таблице
                this.Grid_References_Author.ClearSelection();
                this.Grid_References_Author.Rows[this.Grid_References_Author.Rows.Count - 1].Selected = true;

                FormHelper.SendSuccessMessage(this, "Автор успешно добавлен!");
            });
            this.UnfocusAll();
        }

        /// <summary>Событие нажатия на кнопку создания во вкладке "Справочники" - "Жанры"</summary>
        private void Button_References_Group_Create_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                // Создаём и сохраняем новый жанр
                Group new_entity = new Group {
                    Title = this.TextBox_References_Group_Title.Text
                };

                // Проверяем, что такой же сущности не существует и добавляем/изменяем её
                DatabaseHelper.TryToAddOrEditEntity(DatabaseHelper.db.Groups, new_entity, true);

                DatabaseHelper.db.SaveChanges();
                this.UpdateCurrentSelectedTab();

                // Выбираем последнюю строчку в таблице
                this.Grid_References_Group.ClearSelection();
                this.Grid_References_Group.Rows[this.Grid_References_Group.Rows.Count - 1].Selected = true;

                FormHelper.SendSuccessMessage(this, "Жанр успешно добавлен!");
            });
            this.UnfocusAll();
        }

        /// <summary>Событие нажатия на кнопку создания во вкладке "Справочники" - "Издатели"</summary>
        private void Button_References_Bookmaker_Create_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                // Создаём и сохраняем нового издателя
                Bookmaker new_entity = new Bookmaker {
                    Title = this.TextBox_References_Bookmaker_Title.Text,
                    City = this.TextBox_References_Bookmaker_City.Text
                };

                // Проверяем, что такой же сущности не существует и добавляем/изменяем её
                DatabaseHelper.TryToAddOrEditEntity(DatabaseHelper.db.Bookmakers, new_entity, true);

                DatabaseHelper.db.SaveChanges();
                this.UpdateCurrentSelectedTab();

                // Выбираем последнюю строчку в таблице
                this.Grid_References_Bookmaker.ClearSelection();
                this.Grid_References_Bookmaker.Rows[this.Grid_References_Bookmaker.Rows.Count - 1].Selected = true;

                FormHelper.SendSuccessMessage(this, "Издатель успешно добавлен!");
            });
            this.UnfocusAll();
        }

        /// <summary>Событие нажатия на кнопку изменения во вкладке "Справочники" - "Авторы"</summary>
        private void Button_References_Author_Edit_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                if (this.Grid_References_Author.SelectedRows.Count > 0) {
                    // Находим выбранного в таблице автора в БД
                    int selected_id = Convert.ToInt32(this.Grid_References_Author.SelectedRows[0].Cells[0].Value);
                    Author found_entity = DatabaseHelper.SelectFirstOrFormException(
                        DatabaseHelper.db.Authors,
                        selected_id
                    );

                    found_entity.FirstName = this.TextBox_References_Author_FirstName.Text;
                    found_entity.LastName = this.TextBox_References_Author_LastName.Text;
                    found_entity.MiddleName = this.TextBox_References_Author_MiddleName.Text;

                    // Проверяем, что такой же сущности не существует и добавляем/изменяем её
                    DatabaseHelper.TryToAddOrEditEntity(DatabaseHelper.db.Authors, found_entity, false);

                    DatabaseHelper.db.SaveChanges();

                    // Обновляем как справочник, так и каталог книг
                    this.UpdateData(new List<MetroGrid>() {
                        this.Grid_Books,
                        this.Grid_References_Author,
                    });

                    FormHelper.SendSuccessMessage(this, "Информация об авторе успешно отредактирована!");
                }
            });
            this.UnfocusAll();
        }

        /// <summary>Событие нажатия на кнопку изменения во вкладке "Справочники" - "Жанры"</summary>
        private void Button_References_Group_Edit_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                if (this.Grid_References_Group.SelectedRows.Count > 0) {
                    // Находим выбранный в таблице жанр в БД
                    int selected_id = Convert.ToInt32(this.Grid_References_Group.SelectedRows[0].Cells[0].Value);
                    Group found_entity = DatabaseHelper.SelectFirstOrFormException(
                        DatabaseHelper.db.Groups,
                        selected_id
                    );

                    found_entity.Title = this.TextBox_References_Group_Title.Text;

                    // Проверяем, что такой же сущности не существует и добавляем/изменяем её
                    DatabaseHelper.TryToAddOrEditEntity(DatabaseHelper.db.Groups, found_entity, false);

                    DatabaseHelper.db.SaveChanges();

                    // Обновляем как справочник, так и каталог книг
                    this.UpdateData(new List<MetroGrid>() {
                        this.Grid_Books,
                        this.Grid_References_Group,
                    });

                    FormHelper.SendSuccessMessage(this, "Информация о жанре успешно отредактирована!");
                }
            });
            this.UnfocusAll();
        }

        /// <summary>Событие нажатия на кнопку изменения во вкладке "Справочники" - "Издатели"</summary>
        private void Button_References_Bookmaker_Edit_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                if (this.Grid_References_Bookmaker.SelectedRows.Count > 0) {
                    // Находим выбранного в таблице издателя в БД
                    int selected_id = Convert.ToInt32(this.Grid_References_Bookmaker.SelectedRows[0].Cells[0].Value);
                    Bookmaker found_entity = DatabaseHelper.SelectFirstOrFormException(
                        DatabaseHelper.db.Bookmakers,
                        selected_id
                    );

                    found_entity.Title = this.TextBox_References_Bookmaker_Title.Text;
                    found_entity.City = this.TextBox_References_Bookmaker_City.Text;

                    // Проверяем, что такой же сущности не существует и добавляем/изменяем её
                    DatabaseHelper.TryToAddOrEditEntity(DatabaseHelper.db.Bookmakers, found_entity, false);

                    DatabaseHelper.db.SaveChanges();

                    // Обновляем как справочник, так и каталог книг
                    this.UpdateData(new List<MetroGrid>() {
                        this.Grid_Books,
                        this.Grid_References_Bookmaker,
                    });

                    FormHelper.SendSuccessMessage(this, "Информация об издателе успешно отредактирована!");
                }
            });
            this.UnfocusAll();
        }

        /// <summary>Событие нажатия на кнопку удаления во вкладке "Справочники" - "Авторы"</summary>
        private void Button_References_Author_Delete_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                if (this.Grid_References_Author.SelectedRows.Count > 0) {
                    // Удаляем все выбранные записи
                    foreach (DataGridViewRow row in this.Grid_References_Author.SelectedRows) {
                        // Находим выбранного в таблице автора в БД
                        int selected_id = Convert.ToInt32(row.Cells[0].Value);
                        Author found_entity = DatabaseHelper.SelectFirstOrFormException(
                            DatabaseHelper.db.Authors,
                            selected_id
                        );

                        DatabaseHelper.db.Authors.Remove(found_entity);
                        DatabaseHelper.db.SaveChanges();
                    }

                    // Обновляем как справочник, так и каталог книг
                    this.UpdateData(new List<MetroGrid>() {
                        this.Grid_Books,
                        this.Grid_References_Author,
                    });

                    // Снимаем выделение в таблице
                    this.Grid_References_Author.ClearSelection();

                    FormHelper.SendSuccessMessage(this, "Автор успешно удалён!");
                }
            });
            this.UnfocusAll();
        }

        /// <summary>Событие нажатия на кнопку удаления во вкладке "Справочники" - "Жанры"</summary>
        private void Button_References_Group_Delete_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                if (this.Grid_References_Group.SelectedRows.Count > 0) {
                    // Удаляем все выбранные записи
                    foreach (DataGridViewRow row in this.Grid_References_Group.SelectedRows) {
                        // Находим выбранный в таблице жанр в БД
                        int selected_id = Convert.ToInt32(row.Cells[0].Value);
                        Group found_entity = DatabaseHelper.SelectFirstOrFormException(
                            DatabaseHelper.db.Groups,
                            selected_id
                        );

                        DatabaseHelper.db.Groups.Remove(found_entity);
                        DatabaseHelper.db.SaveChanges();
                    }

                    // Обновляем как справочник, так и каталог книг
                    this.UpdateData(new List<MetroGrid>() {
                        this.Grid_Books,
                        this.Grid_References_Group,
                    });

                    // Снимаем выделение в таблице
                    this.Grid_References_Group.ClearSelection();

                    FormHelper.SendSuccessMessage(this, "Жанр успешно удалён!");
                }
            });
            this.UnfocusAll();
        }

        /// <summary>Событие нажатия на кнопку удаления во вкладке "Справочники" - "Издатели"</summary>
        private void Button_References_Bookmaker_Delete_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                if (this.Grid_References_Bookmaker.SelectedRows.Count > 0) {
                    // Удаляем все выбранные записи
                    foreach (DataGridViewRow row in this.Grid_References_Bookmaker.SelectedRows) {
                        // Находим выбранного в таблице издателя в БД
                        int selected_id = Convert.ToInt32(row.Cells[0].Value);
                        Bookmaker found_entity = DatabaseHelper.SelectFirstOrFormException(
                            DatabaseHelper.db.Bookmakers,
                            selected_id
                        );

                        DatabaseHelper.db.Bookmakers.Remove(found_entity);
                        DatabaseHelper.db.SaveChanges();
                    }

                    // Обновляем как справочник, так и каталог книг
                    this.UpdateData(new List<MetroGrid>() {
                        this.Grid_Books,
                        this.Grid_References_Bookmaker,
                    });

                    // Снимаем выделение в таблице
                    this.Grid_References_Bookmaker.ClearSelection();

                    FormHelper.SendSuccessMessage(this, "Издатель успешно удалён!");
                }
            });
            this.UnfocusAll();
        }
    }
}
