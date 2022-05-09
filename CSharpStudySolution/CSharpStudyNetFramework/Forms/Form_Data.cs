using CSharpStudyNetFramework.Extra;
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
        /// <summary>Список всех таблиц с данными</summary>
        private readonly List<MetroGrid> AllGrids;

        /// <summary>Список кнопок-вкладок на вкладке "Регистрация книг"</summary>
        private readonly List<Button> TabRegistration_TabsButtons;

        /// <summary>Список соответствующих контейнеров кнопок-вкладок на вкладке "Регистрация книг"</summary>
        private readonly List<Control> TabRegistration_TabsContainers;

        /// <summary>Список кнопок-вкладок на вкладке "Справочники"</summary>
        private readonly List<Button> TabReferences_TabsButtons;

        /// <summary>Список соответствующих контейнеров кнопок-вкладок на вкладке "Справочники"</summary>
        private readonly List<Control> TabReferences_TabsContainers;

        private readonly Dictionary<MetroGrid, List<ComboBox>> LinkedComboboxes;

        /// <summary>Конструктор формы</summary>
        public Form_Data() : base()
        {
            this.InitializeComponent();
            // Установка темы для формы
            this.SetStyleManager();

            // Список, который содержит все таблицы с данными (нужен для функции обновления всех таблиц)
            this.AllGrids = new List<MetroGrid> {
                this.Grid_Catalog,
                this.Grid_References_Author,
                this.Grid_References_Bookmaker,
                this.Grid_References_Group
            };

            // -------------------------------------------------------
            // Кнопки-вкладки
            // -------------------------------------------------------
            // Кнопки-вкладки на вкладке "Регистрация книг"
            this.TabRegistration_TabsButtons = new List<Button> {
                this.Button_Registration_Book_Tab,
                this.Button_Registration_CopyBook_Tab
            };
            // Соответствующие контейнеры кнопки-вкладки на вкладке "Регистрация книг"
            this.TabRegistration_TabsContainers = new List<Control> {
                this.Panel_Registration_Book,
                this.Panel_Registration_CopyBook
            };
            // Кнопки-вкладки на вкладке "Справочники"
            this.TabReferences_TabsButtons = new List<Button> {
                this.Button_References_Author_Tab,
                this.Button_References_Group_Tab,
                this.Button_References_Bookmaker_Tab
            };
            // Соответствующие контейнеры кнопки-вкладки на вкладке "Справочники"
            this.TabReferences_TabsContainers = new List<Control> {
                this.Panel_References_Author,
                this.Panel_References_Group,
                this.Panel_References_Bookmaker,
            };
            // -------------------------------------------------------

            // Комбобоксы, привязанные к таблицам - при обновлении таблиц обновляются и комбобоксы
            this.LinkedComboboxes = new Dictionary<MetroGrid, List<ComboBox>> {
                {
                    this.Grid_References_Author,
                    new List<ComboBox>() {
                        this.ComboBox_Registration_Book_Author
                    }
                },
                {
                    this.Grid_References_Group,
                    new List<ComboBox>() {
                        this.ComboBox_Registration_Book_Group
                    }
                },
                {
                    this.Grid_References_Bookmaker,
                    new List<ComboBox>() {
                        this.ComboBox_Registration_Book_Bookmaker
                    }
                },
                {
                    this.Grid_Catalog,
                    new List<ComboBox>() {
                        this.ComboBox_Registration_CopyBook_Book
                    }
                }
            };
        }

        /// <summary>Событие загрузки формы</summary>
        private void Form_Data_Load(object sender, EventArgs e)
        {
            // Обновление данных таблиц
            this.UpdateData();

            // -----------------------------
            // Выбор кнопок-вкладок
            // Вызываются напрямую (через PerformClick не выйдет, так как кнопки недоступны, если в другой вкладке)
            // -----------------------------
            // На вкладке "Регистрация книг" выбираем кнопку-вкладку "Регистрация книги"
            this.SelectButtonTab(
                this.TabRegistration_TabsButtons,
                this.TabRegistration_TabsContainers,
                this.Button_Registration_Book_Tab
            );
            // На вкладке "Справочники" выбираем кнопку-вкладку "Редактировать авторов"
            this.SelectButtonTab(
                this.TabReferences_TabsButtons,
                this.TabReferences_TabsContainers,
                this.Button_References_Author_Tab
            );
            // -----------------------------

            // Несмотря на обновление, данные, видимо, не успевают загрузиться, из-за чего зависимые сущности
            // всех записей равны null - поэтому вызываем повторный раз обновление каталога
            this.UpdateData(this.Grid_Catalog);
            this.UnfocusAll();
        }

        /// <summary>Убирает фокус со всех элементов</summary>
        private void UnfocusAll()
        {
            // Убираем фокус с любого элемента
            this.ActiveControl = null;
        }

        /// <summary>Обновляет таблицу. привязанную к текущей вкладке</summary>
        private void UpdateCurrentSelectedTab()
        {
            int selected_tab_index = this.TabControl_Data.SelectedIndex;
            MetroGrid grid_to_update;

            switch (selected_tab_index) {
                case 0:
                case 1:
                    grid_to_update = this.Grid_Catalog;
                    break;
                case 2:
                    // В зависимости от выбора кнопки-вкладки будет обновлена соответствующая таблица
                    if (!this.Button_References_Author_Tab.Enabled) {
                        grid_to_update = this.Grid_References_Author;
                    } else if (!this.Button_References_Group_Tab.Enabled) {
                        grid_to_update = this.Grid_References_Group;
                    } else if (!this.Button_References_Bookmaker_Tab.Enabled) {
                        grid_to_update = this.Grid_References_Bookmaker;
                    } else {
                        return;
                    }
                    break;
                default:
                    return;
            }

            // Обновляем данные таблицы на вкладке, на которую перешли
            this.UpdateData(grid_to_update);
        }

        /// <summary>Обновляет данные во всех таблицах</summary>
        /// <param name="grids_to_update">Список таблиц, данные которых нужно обновить. Если не указан - обновляются все таблицы</param>
        private void UpdateData(List<MetroGrid> grids_to_update = null)
        {
            // Если не указаны таблицы для обновления - обновляем все
            if (grids_to_update == null) {
                grids_to_update = this.AllGrids;
            }

            // Обновляем все гриды из указанного списка
            grids_to_update.ForEach(grid => {
                // Сохраняем ID выбранных строчек
                List<int> selected_rows_ids = new List<int>();
                foreach (DataGridViewRow row in grid.SelectedRows) {
                    selected_rows_ids.Add(row.Index);
                }

                // Обновляет сами данные в зависимости от таблицы
                this.FillData(grid);

                // Так как таблица обновилась - заново выбираем все строчки, которые были выбраны
                grid.ClearSelection();
                foreach (int selected_row_id in selected_rows_ids) {
                    // Выбираем строчку только если сохранённое значение выбранной строки не превышает количество строк
                    if (selected_row_id < grid.Rows.Count) {
                        grid.Rows[selected_row_id].Selected = true;
                    }
                }
            });
        }

        /// <summary>Обновляет данные в указанной таблице</summary>
        /// <param name="grid_to_update">Таблица, которую необходимо обновить</param>
        private void UpdateData(MetroGrid grid_to_update)
        {
            List<MetroGrid> grids_to_update = new List<MetroGrid> {
                grid_to_update
            };
            this.UpdateData(grids_to_update);
        }

        /// <summary>Обновляет данные таблицы в зависимости от того, какая она</summary>
        /// <param name="grid">Таблица данных</param>
        private void FillData(MetroGrid grid)
        {
            ExceptionHelper.CheckCode(this, () => {
                // Список замен для названий колонок
                Dictionary<string, string> replaces = new Dictionary<string, string> {
                    { "Id", "ID" }
                };
                // Данные для комбобоксов
                string[] data_for_comboboxes = null;

                // Если заполняется вкладка "Каталог книг"
                if (grid.Equals(this.Grid_Catalog)) {
                    // Содержимое текстового поля
                    string filter_string = this.TextBox_Catalog_Search.Text;

                    Func<Book, bool> filter_function;
                    // Если выбрана фильтрация по полю "Автор"
                    if (this.RadioButton_Catalog_Author.Checked) {
                        filter_function = book => {
                            if (book.Author == null) {
                                return false;
                            }
                            return book.Author.FullName.Contains(filter_string);
                        };
                    }
                    // Если выбрана фильтрация по полю "Жанр"
                    else if (this.RadioButton_Catalog_Group.Checked) {
                        filter_function = book => {
                            if (book.Group == null) {
                                return true;
                            }
                            return book.Group.Title.Contains(filter_string);
                        };
                    }
                    // Если выбрана фильтрация по полю "Издатель"
                    else if (this.RadioButton_Catalog_Bookmaker.Checked) {
                        filter_function = book => {
                            if (book.Bookmaker == null) {
                                return true;
                            }
                            return book.Bookmaker.Title.Contains(filter_string);
                        };
                    }
                    // Если выбрана фильтрация по полю "Дата регистрации"
                    else if (this.RadioButton_Catalog_RegistrationDate.Checked) {
                        filter_function = book => book.YearRegistr.Contains(filter_string);
                    }
                    // Иначе что-то пошло не так - никакие записи не выбираем
                    else {
                        filter_function = book => false;
                    }

                    // Из-за изменения полей выборки, её результат не является списком книг - это список
                    // анонимных объектов. Поэтому, обрабатываем отдельно значения для комбобоксов, чтобы
                    // в них успешно применились методы ToString()
                    IEnumerable<Book> data = DatabaseHelper.db.books.Where(filter_function);
                    data_for_comboboxes = DatabaseHelper.GetStringArrayForComboBoxes(data.ToList());
                    var data_for_grid = data.Select(book => new {
                        Id = book.Id,
                        Author = book.Author == null ? "-" : book.Author.ToString(),
                        Title = book.Title,
                        Group = book.Group == null ? "-" : book.Group.ToString(),
                        Bookmaker = book.Bookmaker == null ? "-" : book.Bookmaker.ToString(),
                        YearPublication = book.YearPublication,
                        YearRegistr = book.YearRegistr,
                    }).ToList();
                    grid.DataSource = data_for_grid;

                    replaces.Add("Author", "Автор");
                    replaces.Add("Title", "Название");
                    replaces.Add("Group", "Жанр");
                    replaces.Add("Bookmaker", "Издатель");
                    replaces.Add("YearPublication", "Год издания");
                    replaces.Add("YearRegistr", "Дата регистрации в библиотеке");
                }
                // Если заполняется вкладка "Справочники" - "Авторы"
                else if (grid.Equals(this.Grid_References_Author)) {
                    List<Author> data = DatabaseHelper.db.authors.ToList();
                    grid.DataSource = data;
                    replaces.Add("fName", "Имя");
                    replaces.Add("lName", "Фамилия");
                    replaces.Add("mName", "Отчество");
                    data_for_comboboxes = DatabaseHelper.GetStringArrayForComboBoxes(data);
                }
                // Если заполняется вкладка "Справочники" - "Жанры"
                else if (grid.Equals(this.Grid_References_Group)) {
                    List<Group> data = DatabaseHelper.db.groups.ToList();
                    grid.DataSource = data;
                    replaces.Add("Title", "Название");
                    data_for_comboboxes = DatabaseHelper.GetStringArrayForComboBoxes(data);
                }
                // Если заполняется вкладка "Справочники" - "Издатели"
                else if (grid.Equals(this.Grid_References_Bookmaker)) {
                    List<Bookmaker> data = DatabaseHelper.db.bookmakers.ToList();
                    grid.DataSource = data;
                    replaces.Add("Title", "Название");
                    replaces.Add("City", "Город");
                    data_for_comboboxes = DatabaseHelper.GetStringArrayForComboBoxes(data);
                }

                // Замена названий колонок
                foreach (DataGridViewColumn column in grid.Columns) {
                    foreach (KeyValuePair<string, string> replace in replaces) {
                        if (column.HeaderText == replace.Key) {
                            column.HeaderText = replace.Value;
                        }
                    }
                }

                // Обновляем данные для комбобоксов, если нужно
                if (data_for_comboboxes != null) {
                    bool is_exist = this.LinkedComboboxes.TryGetValue(grid, out List<ComboBox> linked_comboboxes);
                    if (is_exist) {
                        linked_comboboxes.ForEach(combobox => {
                            // Заполнение самого списка
                            combobox.Items.Clear();
                            combobox.Items.AddRange(data_for_comboboxes);
                            // Настройки для автодополнения
                            combobox.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                            combobox.AutoCompleteCustomSource.AddRange(data_for_comboboxes);
                            combobox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            combobox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        });
                    }
                }
            });
        }

        /// <summary>Событие нажатия на кнопку "Поиск" на вкладке "Каталог книг"</summary>
        private void Button_Catalog_Search_Click(object sender, EventArgs e)
        {
            this.UpdateData(this.Grid_Catalog);
            this.UnfocusAll();
        }

        /// <summary>Событие нажатия на кнопку "Сбросить фильтр" на вкладке "Каталог книг"</summary>
        private void Button_Catalog_Reset_Click(object sender, EventArgs e)
        {
            this.RadioButton_Catalog_Author.Select();
            this.TextBox_Catalog_Search.Text = "";
            this.UpdateData(this.Grid_Catalog);
            this.UnfocusAll();
        }


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

        /// <summary>Нажатие на кнопку-вкладку на вкладке "Регистрация книг"</summary>
        private void Button_Registration_Tab_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, () => {
                this.SelectButtonTab(
                    this.TabRegistration_TabsButtons,
                    this.TabRegistration_TabsContainers,
                    sender as Button
                );
            });
        }

        /// <summary>Нажатие на кнопку-вкладку на вкладке "Справочники"</summary>
        private void Button_References_Tab_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, () => {
                this.SelectButtonTab(
                    this.TabReferences_TabsButtons,
                    this.TabReferences_TabsContainers,
                    sender as Button
                );
            });
        }

        /// <summary>Событие изменения текста во вкладке "Справочники" - "Авторы"</summary>
        private void TextBox_References_Author_TextChanged(object sender, EventArgs e)
        {
            this.Button_References_Author_Create.Enabled = (this.TextBox_References_Author_FirstName.Text != "") && (this.TextBox_References_Author_LastName.Text != "");
        }

        /// <summary>Событие изменения текста во вкладке "Справочники" - "Жанры"</summary>
        private void TextBox_References_Group_TextChanged(object sender, EventArgs e)
        {
            this.Button_References_Group_Create.Enabled = this.TextBox_References_Group_Title.Text != "";
        }

        /// <summary>Событие изменения текста во вкладке "Справочники" - "Издатели"</summary>
        private void TextBox_References_Bookmaker_TextChanged(object sender, EventArgs e)
        {
            this.Button_References_Bookmaker_Create.Enabled = this.TextBox_References_Bookmaker_Title.Text != "";
        }

        /// <summary>Событие изменения выбранной строчки в таблице во вкладке "Справочники" - "Авторы"</summary>
        private void Grid_References_Author_SelectionChanged(object sender, EventArgs e)
        {
            // Кнопки изменения и удаления записи будут доступны только если выбрана строчка в таблице
            this.Button_References_Author_Edit.Enabled = this.Button_References_Author_Delete.Enabled =
                this.Grid_References_Author.SelectedRows.Count > 0;

            // Если выбрана строчка - заменяем текст в текстбоксах на значения из выбранной записи
            if (this.Grid_References_Author.SelectedRows.Count > 0) {
                DataGridViewRow selected_row = this.Grid_References_Author.SelectedRows[0];
                this.TextBox_References_Author_FirstName.Text = selected_row.Cells[1].Value.ToString();
                this.TextBox_References_Author_LastName.Text = selected_row.Cells[2].Value.ToString();
                this.TextBox_References_Author_MiddleName.Text = selected_row.Cells[3].Value.ToString();
            }
            // Если нет выбора - очищаем текстбоксы
            else {
                this.TextBox_References_Author_FirstName.Clear();
                this.TextBox_References_Author_LastName.Clear();
                this.TextBox_References_Author_MiddleName.Clear();
            }
        }

        /// <summary>Событие изменения выбранной строчки в таблице во вкладке "Справочники" - "Жанры"</summary>
        private void Grid_References_Group_SelectionChanged(object sender, EventArgs e)
        {
            // Кнопки изменения и удаления записи будут доступны только если выбрана строчка в таблице
            this.Button_References_Group_Edit.Enabled = this.Button_References_Group_Delete.Enabled =
                this.Grid_References_Group.SelectedRows.Count > 0;

            // Если выбрана строчка - заменяем текст в текстбоксах на значения из выбранной записи
            if (this.Grid_References_Group.SelectedRows.Count > 0) {
                DataGridViewRow selected_row = this.Grid_References_Group.SelectedRows[0];
                this.TextBox_References_Group_Title.Text = selected_row.Cells[1].Value.ToString();
            }
            // Если нет выбора - очищаем текстбоксы
            else {
                this.TextBox_References_Group_Title.Clear();
            }
        }

        /// <summary>Событие изменения выбранной строчки в таблице во вкладке "Справочники" - "Издатели"</summary>
        private void Grid_References_Bookmaker_SelectionChanged(object sender, EventArgs e)
        {
            // Кнопки изменения и удаления записи будут доступны только если выбрана строчка в таблице
            this.Button_References_Bookmaker_Edit.Enabled = this.Button_References_Bookmaker_Delete.Enabled =
                this.Grid_References_Bookmaker.SelectedRows.Count > 0;

            // Если выбрана строчка - заменяем текст в текстбоксах на значения из выбранной записи
            if (this.Grid_References_Bookmaker.SelectedRows.Count > 0) {
                DataGridViewRow selected_row = this.Grid_References_Bookmaker.SelectedRows[0];
                this.TextBox_References_Bookmaker_Title.Text = selected_row.Cells[1].Value.ToString();
                this.TextBox_References_Bookmaker_City.Text = selected_row.Cells[2].Value.ToString();
            }
            // Если нет выбора - очищаем текстбоксы
            else {
                this.TextBox_References_Bookmaker_Title.Clear();
                this.TextBox_References_Bookmaker_City.Clear();
            }
        }

        /// <summary>Событие нажатия на кнопку создания во вкладке "Справочники" - "Авторы"</summary>
        private void Button_References_Author_Create_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, () => {
                // Создаём и сохраняем нового автора
                Author new_entity = new Author {
                    fName = this.TextBox_References_Author_FirstName.Text,
                    lName = this.TextBox_References_Author_LastName.Text,
                    mName = this.TextBox_References_Author_MiddleName.Text
                };
                DatabaseHelper.db.authors.Add(new_entity);
                DatabaseHelper.db.SaveChanges();
                this.UpdateCurrentSelectedTab();
            });
        }

        /// <summary>Событие нажатия на кнопку создания во вкладке "Справочники" - "Жанры"</summary>
        private void Button_References_Group_Create_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, () => {
                // Создаём и сохраняем новый жанр
                Group new_entity = new Group {
                    Title = this.TextBox_References_Group_Title.Text
                };
                DatabaseHelper.db.groups.Add(new_entity);
                DatabaseHelper.db.SaveChanges();
                this.UpdateCurrentSelectedTab();
            });
        }

        /// <summary>Событие нажатия на кнопку создания во вкладке "Справочники" - "Издатели"</summary>
        private void Button_References_Bookmaker_Create_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, () => {
                // Создаём и сохраняем нового издателя
                Bookmaker new_entity = new Bookmaker {
                    Title = this.TextBox_References_Bookmaker_Title.Text,
                    City = this.TextBox_References_Bookmaker_City.Text
                };
                DatabaseHelper.db.bookmakers.Add(new_entity);
                DatabaseHelper.db.SaveChanges();
                this.UpdateCurrentSelectedTab();
            });
        }

        /// <summary>Событие нажатия на кнопку изменения во вкладке "Справочники" - "Авторы"</summary>
        private void Button_References_Author_Edit_Click(object sender, EventArgs e)
        {
            if (this.Grid_References_Author.SelectedRows.Count > 0) {
                // Изменяем и сохраняем выбранного автора в таблице
                int selected_id = Convert.ToInt32(this.Grid_References_Author.SelectedRows[0].Cells[0].Value);
                Author found_entity = DatabaseHelper.db.authors.FirstOrDefault(entity => entity.Id == selected_id);
                found_entity.fName = this.TextBox_References_Author_FirstName.Text;
                found_entity.lName = this.TextBox_References_Author_LastName.Text;
                found_entity.mName = this.TextBox_References_Author_MiddleName.Text;
                DatabaseHelper.db.authors.Update(found_entity);
                DatabaseHelper.db.SaveChanges();
                // Обновляем как справочник, так и каталог книг
                this.UpdateData(new List<MetroGrid>() {
                    this.Grid_Catalog,
                    this.Grid_References_Author,
                });
            }
        }

        /// <summary>Событие нажатия на кнопку изменения во вкладке "Справочники" - "Жанры"</summary>
        private void Button_References_Group_Edit_Click(object sender, EventArgs e)
        {
            if (this.Grid_References_Group.SelectedRows.Count > 0) {
                // Изменяем и сохраняем выбранный жанр в таблице
                int selected_id = Convert.ToInt32(this.Grid_References_Group.SelectedRows[0].Cells[0].Value);
                Group found_entity = DatabaseHelper.db.groups.FirstOrDefault(entity => entity.Id == selected_id);
                found_entity.Title = this.TextBox_References_Group_Title.Text;
                DatabaseHelper.db.groups.Update(found_entity);
                DatabaseHelper.db.SaveChanges();
                // Обновляем как справочник, так и каталог книг
                this.UpdateData(new List<MetroGrid>() {
                    this.Grid_Catalog,
                    this.Grid_References_Group,
                });
            }
        }

        /// <summary>Событие нажатия на кнопку изменения во вкладке "Справочники" - "Издатели"</summary>
        private void Button_References_Bookmaker_Edit_Click(object sender, EventArgs e)
        {
            if (this.Grid_References_Bookmaker.SelectedRows.Count > 0) {
                // Изменяем и сохраняем выбранного издателя в таблице
                int selected_id = Convert.ToInt32(this.Grid_References_Bookmaker.SelectedRows[0].Cells[0].Value);
                Bookmaker found_entity = DatabaseHelper.db.bookmakers.FirstOrDefault(entity => entity.Id == selected_id);
                found_entity.Title = this.TextBox_References_Bookmaker_Title.Text;
                found_entity.City = this.TextBox_References_Bookmaker_City.Text;
                DatabaseHelper.db.bookmakers.Update(found_entity);
                DatabaseHelper.db.SaveChanges();
                // Обновляем как справочник, так и каталог книг
                this.UpdateData(new List<MetroGrid>() {
                    this.Grid_Catalog,
                    this.Grid_References_Bookmaker,
                });
            }
        }

        /// <summary>Событие нажатия на кнопку удаления во вкладке "Справочники" - "Авторы"</summary>
        private void Button_References_Author_Delete_Click(object sender, EventArgs e)
        {
            if (this.Grid_References_Author.SelectedRows.Count > 0) {
                // Удаляем выбранного автора в таблице
                int selected_id = Convert.ToInt32(this.Grid_References_Author.SelectedRows[0].Cells[0].Value);
                Author found_entity = DatabaseHelper.db.authors.FirstOrDefault(entity => entity.Id == selected_id);
                DatabaseHelper.db.authors.Remove(found_entity);
                DatabaseHelper.db.SaveChanges();
                // Обновляем как справочник, так и каталог книг
                this.UpdateData(new List<MetroGrid>() {
                    this.Grid_Catalog,
                    this.Grid_References_Author,
                });
            }
        }

        /// <summary>Событие нажатия на кнопку удаления во вкладке "Справочники" - "Жанры"</summary>
        private void Button_References_Group_Delete_Click(object sender, EventArgs e)
        {
            if (this.Grid_References_Group.SelectedRows.Count > 0) {
                // Удаляем выбранный жанр в таблице
                int selected_id = Convert.ToInt32(this.Grid_References_Group.SelectedRows[0].Cells[0].Value);
                Group found_entity = DatabaseHelper.db.groups.FirstOrDefault(entity => entity.Id == selected_id);
                DatabaseHelper.db.groups.Remove(found_entity);
                DatabaseHelper.db.SaveChanges();
                // Обновляем как справочник, так и каталог книг
                this.UpdateData(new List<MetroGrid>() {
                    this.Grid_Catalog,
                    this.Grid_References_Group,
                });
            }
        }

        /// <summary>Событие нажатия на кнопку удаления во вкладке "Справочники" - "Издатели"</summary>
        private void Button_References_Bookmaker_Delete_Click(object sender, EventArgs e)
        {
            if (this.Grid_References_Bookmaker.SelectedRows.Count > 0) {
                // Удаляем выбранного издателя в таблице
                int selected_id = Convert.ToInt32(this.Grid_References_Bookmaker.SelectedRows[0].Cells[0].Value);
                Bookmaker found_entity = DatabaseHelper.db.bookmakers.FirstOrDefault(entity => entity.Id == selected_id);
                DatabaseHelper.db.bookmakers.Remove(found_entity);
                DatabaseHelper.db.SaveChanges();
                // Обновляем как справочник, так и каталог книг
                this.UpdateData(new List<MetroGrid>() {
                    this.Grid_Catalog,
                    this.Grid_References_Bookmaker,
                });
            }
        }

        /// <summary>Событие нажатия на кнопку регистрации новой книги</summary>
        private void Button_Registration_Book_Register_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, () => {
                // ------------
                // Автор книги
                // ------------
                Author selected_author;
                try {
                    selected_author = DatabaseHelper.db.authors.First(
                        // Тут нужно указывать поля сущностей напрямую, так как они транслируются в чистый SQL
                        entity => (entity.lName + " " + entity.fName + " " + entity.mName).Trim() == this.ComboBox_Registration_Book_Author.Text.Trim()
                    );
                } catch (Exception) {
                    throw new FormException("Выбранный автор не найден в базе данных!");
                }
                // ------------

                // ------------
                // Название книги
                // ------------
                string title = this.TextBox_Registration_Book_Title.Text.Trim();
                if (title == "") {
                    throw new FormException("Необходимо указать название книги!");
                }
                // ------------

                // ------------
                // Жанр книги
                // ------------
                Group selected_group;
                try {
                    selected_group = DatabaseHelper.db.groups.First(
                        // Тут нужно указывать поля сущностей напрямую, так как они транслируются в чистый SQL
                        entity => entity.Title.Trim() == this.ComboBox_Registration_Book_Group.Text.Trim()
                    );
                } catch (Exception) {
                    throw new FormException("Выбранный жанр не найден в базе данных!");
                }
                // ------------

                // ------------
                // Издатель книги
                // ------------
                Bookmaker selected_bookmaker;
                try {
                    selected_bookmaker = DatabaseHelper.db.bookmakers.First(
                        // Тут нужно указывать поля сущностей напрямую, так как они транслируются в чистый SQL
                        entity => entity.Title.Trim() == this.ComboBox_Registration_Book_Bookmaker.Text.Trim()
                    );
                } catch (Exception) {
                    throw new FormException("Выбранный издатель не найден в базе данных!");
                }
                // ------------

                // Создаём и сохраняем новую книгу
                Book new_entity = new Book {
                    Author = selected_author,
                    Title = title,
                    Group = selected_group,
                    Bookmaker = selected_bookmaker,
                    YearPublication = this.NumericUpDown_Registration_Book_Year.Value.ToString(),
                    YearRegistr = this.DateTime_Registration_Book_RegistrationDate.Value.ToString()
                };
                DatabaseHelper.db.books.Add(new_entity);
                DatabaseHelper.db.SaveChanges();
                this.UpdateCurrentSelectedTab();
            });
        }

        /// <summary>Событие нажатия на кнопку регистрации нового экземпляра книги</summary>
        private void Button_Registration_CopyBook_Register_Click(object sender, EventArgs e)
        {

        }
    }
}
