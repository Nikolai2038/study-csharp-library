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
                this.Grid_Books,
                this.Grid_CopyBooks,
                this.Grid_References_Author,
                this.Grid_References_Bookmaker,
                this.Grid_References_Group
            };

            // -------------------------------------------------------
            // Кнопки-вкладки
            // -------------------------------------------------------
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
                        this.ComboBox_Books_Author
                    }
                },
                {
                    this.Grid_References_Group,
                    new List<ComboBox>() {
                        this.ComboBox_Books_Group
                    }
                },
                {
                    this.Grid_References_Bookmaker,
                    new List<ComboBox>() {
                        this.ComboBox_Books_Bookmaker
                    }
                },
                {
                    this.Grid_Books,
                    new List<ComboBox>() {
                        this.ComboBox_CopyBooks_Book
                    }
                }
            };
        }

        /// <summary>Событие загрузки формы</summary>
        private void Form_Data_Load(object sender, EventArgs e)
        {
            // Добавление всплывающей подсказки для чекбокса "Поиск в реальном времени"
            ToolTip tool_tip = new ToolTip {
                ToolTipIcon = ToolTipIcon.Info,
                IsBalloon = true,
                ShowAlways = true,
                UseAnimation = true
            };
            tool_tip.SetToolTip(this.CheckBox_IsSearchInRealTime, "Если включен поиск в реальном времени, то данные в таблице будут обновляться сразу же после любого изменения параметров фильтрации.");

            // Обновление данных таблиц
            this.UpdateData();

            // -----------------------------
            // Выбор кнопок-вкладок
            // Вызываются напрямую (через PerformClick не выйдет, так как кнопки недоступны, если в другой вкладке)
            // -----------------------------
            // На вкладке "Справочники" выбираем кнопку-вкладку "Редактировать авторов"
            this.SelectButtonTab(
                this.TabReferences_TabsButtons,
                this.TabReferences_TabsContainers,
                this.Button_References_Author_Tab
            );
            // -----------------------------

            // Несмотря на обновление, данные, видимо, не успевают загрузиться, из-за чего зависимые сущности
            // всех записей равны null - поэтому вызываем повторный раз обновление каталога
            this.UpdateData(this.Grid_Books);
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
                    grid_to_update = this.Grid_Books;
                    break;
                case 1:
                    grid_to_update = this.Grid_CopyBooks;
                    break;
                case 2:
                    // В зависимости от выбора кнопки-вкладки (смотрим на отображение соответствующей панели) будет обновлена соответствующая таблица
                    if (this.Panel_References_Author.Visible) {
                        grid_to_update = this.Grid_References_Author;
                    } else if (this.Panel_References_Group.Visible) {
                        grid_to_update = this.Grid_References_Group;
                    } else if (this.Panel_References_Bookmaker.Visible) {
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
            ExceptionHelper.CheckCode(this, false, () => {
                // Список замен для названий колонок
                Dictionary<string, string> replaces = new Dictionary<string, string> {
                    // Замену ID добавляем для всех
                    { "Id", "ID" }
                };

                // Данные для комбобоксов
                string[] data_for_comboboxes = null;

                // Если заполняется вкладка "Книги"
                if (grid.Equals(this.Grid_Books)) {
                    // Содержимое текстового поля
                    string filter_string = this.TextBox_Books_Search.Text.Trim();

                    Func<Book, bool> filter_function;
                    // Если выбрана фильтрация по полю "Автор"
                    if (this.RadioButton_Books_Author.Checked) {
                        filter_function = book => {
                            if (book.Author == null) {
                                // true будет только в случае, если передана пустая строчка
                                return filter_string == "";
                            }
                            return book.Author.FullName.Contains(filter_string);
                        };
                    }
                    // Если выбрана фильтрация по полю "Название"
                    else if (this.RadioButton_Books_Title.Checked) {
                        filter_function = book => {
                            return book.Title.Contains(filter_string);
                        };
                    }
                    // Если выбрана фильтрация по полю "Жанр"
                    else if (this.RadioButton_Books_Group.Checked) {
                        filter_function = book => {
                            if (book.Group == null) {
                                // true будет только в случае, если передана пустая строчка
                                return filter_string == "";
                            }
                            return book.Group.Title.Contains(filter_string);
                        };
                    }
                    // Если выбрана фильтрация по полю "Издатель"
                    else if (this.RadioButton_Books_Bookmaker.Checked) {
                        filter_function = book => {
                            if (book.Bookmaker == null) {
                                // true будет только в случае, если передана пустая строчка
                                return filter_string == "";
                            }
                            return book.Bookmaker.Title.Contains(filter_string);
                        };
                    }
                    // Если выбрана фильтрация по полю "Год издания"
                    else if (this.RadioButton_Books_PublicationYear.Checked) {
                        filter_function = book => {
                            return book.PublicationYear.ToString().Contains(filter_string);
                        };
                    }
                    // Если выбрана фильтрация по полю "Дата регистрации"
                    else if (this.RadioButton_Books_RegistrationDate.Checked) {
                        filter_function = book => {
                            return book.RegistrationDate.ToString().Contains(filter_string);
                        };
                    }
                    // Иначе что-то пошло не так - никакие записи не выбираем
                    else {
                        filter_function = book => {
                            return false;
                        };
                    }

                    // Из-за изменения полей выборки, её результат не является списком книг - это список
                    // анонимных объектов. Поэтому, обрабатываем отдельно значения для комбобоксов, чтобы
                    // в них успешно применились методы ToString()
                    IEnumerable<Book> data = DatabaseHelper.db.Books.Where(filter_function);

                    data_for_comboboxes = DatabaseHelper.GetStringArrayForComboBoxes(data.ToList());
                    grid.DataSource = data.Select(book => {
                        return new {
                            book.Id,
                            Author = book.Author == null ? "-" : book.Author.ToString(),
                            book.Title,
                            Group = book.Group == null ? "-" : book.Group.ToString(),
                            Bookmaker = book.Bookmaker == null ? "-" : book.Bookmaker.ToString(),
                            book.PublicationYear,
                            book.RegistrationDate,
                        };
                    }).ToList();

                    replaces.Add("Author", "Автор");
                    replaces.Add("Title", "Название");
                    replaces.Add("Group", "Жанр");
                    replaces.Add("Bookmaker", "Издатель");
                    replaces.Add("PublicationYear", "Год издания");
                    replaces.Add("RegistrationDate", "Дата регистрации в библиотеке");
                }
                // Если заполняется вкладка "Экземпляры книг"
                else if (grid.Equals(this.Grid_CopyBooks)) {
                    List<CopyBook> data = DatabaseHelper.db.CopyBooks.ToList();

                    data_for_comboboxes = DatabaseHelper.GetStringArrayForComboBoxes(data);
                    grid.DataSource = data;

                    replaces.Add("Number", "Номер");
                    replaces.Add("IsGiven", "Выдана ли");
                    replaces.Add("IsLost", "Потеряна ли");
                    replaces.Add("Book", "Книга");
                }
                // Если заполняется вкладка "Справочники" - "Авторы"
                else if (grid.Equals(this.Grid_References_Author)) {
                    List<Author> data = DatabaseHelper.db.Authors.ToList();

                    data_for_comboboxes = DatabaseHelper.GetStringArrayForComboBoxes(data);
                    grid.DataSource = data;

                    replaces.Add("FirstName", "Имя");
                    replaces.Add("LastName", "Фамилия");
                    replaces.Add("MiddleName", "Отчество");
                }
                // Если заполняется вкладка "Справочники" - "Жанры"
                else if (grid.Equals(this.Grid_References_Group)) {
                    List<Group> data = DatabaseHelper.db.Groups.ToList();

                    data_for_comboboxes = DatabaseHelper.GetStringArrayForComboBoxes(data);
                    grid.DataSource = data;

                    replaces.Add("Title", "Название");
                }
                // Если заполняется вкладка "Справочники" - "Издатели"
                else if (grid.Equals(this.Grid_References_Bookmaker)) {
                    List<Bookmaker> data = DatabaseHelper.db.Bookmakers.ToList();

                    data_for_comboboxes = DatabaseHelper.GetStringArrayForComboBoxes(data);
                    grid.DataSource = data;

                    replaces.Add("Title", "Название");
                    replaces.Add("City", "Город");
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


        // ======================================================================
        // Вкладка "Справочники"
        // ======================================================================
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
            ExceptionHelper.CheckCode(this, false, () => {
                // Создаём и сохраняем нового автора
                Author new_entity = new Author {
                    FirstName = this.TextBox_References_Author_FirstName.Text,
                    LastName = this.TextBox_References_Author_LastName.Text,
                    MiddleName = this.TextBox_References_Author_MiddleName.Text
                };
                DatabaseHelper.db.Authors.Add(new_entity);
                DatabaseHelper.db.SaveChanges();
                this.UpdateCurrentSelectedTab();

                // Выбираем последнюю строчку в таблице
                this.Grid_References_Author.ClearSelection();
                this.Grid_References_Author.Rows[this.Grid_References_Author.Rows.Count - 1].Selected = true;

                FormHelper.SendSuccessMessage(this, "Автор успешно добавлен!");
            });
        }

        /// <summary>Событие нажатия на кнопку создания во вкладке "Справочники" - "Жанры"</summary>
        private void Button_References_Group_Create_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                // Создаём и сохраняем новый жанр
                Group new_entity = new Group {
                    Title = this.TextBox_References_Group_Title.Text
                };
                DatabaseHelper.db.Groups.Add(new_entity);
                DatabaseHelper.db.SaveChanges();
                this.UpdateCurrentSelectedTab();

                // Выбираем последнюю строчку в таблице
                this.Grid_References_Group.ClearSelection();
                this.Grid_References_Group.Rows[this.Grid_References_Group.Rows.Count - 1].Selected = true;

                FormHelper.SendSuccessMessage(this, "Жанр успешно добавлен!");
            });
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
                DatabaseHelper.db.Bookmakers.Add(new_entity);
                DatabaseHelper.db.SaveChanges();
                this.UpdateCurrentSelectedTab();

                // Выбираем последнюю строчку в таблице
                this.Grid_References_Bookmaker.ClearSelection();
                this.Grid_References_Bookmaker.Rows[this.Grid_References_Bookmaker.Rows.Count - 1].Selected = true;

                FormHelper.SendSuccessMessage(this, "Издатель успешно добавлен!");
            });
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

                    DatabaseHelper.db.Authors.Update(found_entity);
                    DatabaseHelper.db.SaveChanges();

                    // Обновляем как справочник, так и каталог книг
                    this.UpdateData(new List<MetroGrid>() {
                        this.Grid_Books,
                        this.Grid_References_Author,
                    });
                    FormHelper.SendSuccessMessage(this, "Информация об авторе успешно отредактирована!");
                }
            });
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

                    DatabaseHelper.db.Groups.Update(found_entity);
                    DatabaseHelper.db.SaveChanges();

                    // Обновляем как справочник, так и каталог книг
                    this.UpdateData(new List<MetroGrid>() {
                        this.Grid_Books,
                        this.Grid_References_Group,
                    });
                    FormHelper.SendSuccessMessage(this, "Информация о жанре успешно отредактирована!");
                }
            });
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

                    DatabaseHelper.db.Bookmakers.Update(found_entity);
                    DatabaseHelper.db.SaveChanges();

                    // Обновляем как справочник, так и каталог книг
                    this.UpdateData(new List<MetroGrid>() {
                        this.Grid_Books,
                        this.Grid_References_Bookmaker,
                    });
                    FormHelper.SendSuccessMessage(this, "Информация об издателе успешно отредактирована!");
                }
            });
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
        }
        // ======================================================================

        // ======================================================================
        // Вкладка "Книги"
        // ======================================================================
        /// <summary>Событие изменения выбранной строчки в таблице во вкладке "Книги"</summary>
        private void Grid_Books_SelectionChanged(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, false, () => {
                // Если выбрана строчка - заменяем текст в текстбоксах на значения из выбранной записи
                if (this.Grid_Books.SelectedRows.Count > 0) {
                    // Кнопки изменения и удаления делаем доступными
                    this.Button_Books_Edit.Enabled = this.Button_Books_Delete.Enabled = true;

                    // Находим сущность, выбранную в таблице
                    int selected_id = Convert.ToInt32(this.Grid_Books.SelectedRows[0].Cells[0].Value);
                    Book selected_book = DatabaseHelper.SelectFirstOrFormException(
                        DatabaseHelper.db.Books,
                        selected_id
                    );

                    // -----------------------------------------
                    // Заполняем форму значениями сущности
                    // -----------------------------------------
                    int selected_author_index_in_combobox = -1;
                    if (selected_book.Author != null) {
                        selected_author_index_in_combobox = this.ComboBox_Books_Author.Items.IndexOf(selected_book.Author.ToString());
                    }
                    this.ComboBox_Books_Author.SelectedIndex = selected_author_index_in_combobox;

                    this.TextBox_Books_Title.Text = selected_book.Title;

                    int selected_group_index_in_combobox = -1;
                    if (selected_book.Group != null) {
                        selected_group_index_in_combobox = this.ComboBox_Books_Group.Items.IndexOf(selected_book.Group.ToString());
                    }
                    this.ComboBox_Books_Group.SelectedIndex = selected_group_index_in_combobox;

                    int selected_bookmaker_index_in_combobox = -1;
                    if (selected_book.Bookmaker != null) {
                        selected_bookmaker_index_in_combobox = this.ComboBox_Books_Bookmaker.Items.IndexOf(selected_book.Bookmaker.ToString());
                    }
                    this.ComboBox_Books_Bookmaker.SelectedIndex = selected_bookmaker_index_in_combobox;

                    this.NumericUpDown_Books_Year.Value = selected_book.PublicationYear;
                    this.DateTime_Books_CopyBooksDate.Value = selected_book.RegistrationDate;

                    // Обновляем изображение
                    this.PictureBox_Books_Cover.Image = ImageHelper.ByteArrayToImage(selected_book.Photo);
                    // -----------------------------------------
                }
                // Если нет выбора - очищаем текстбоксы
                else {
                    // Кнопки изменения и удаления делаем недоступными
                    this.Button_Books_Edit.Enabled = this.Button_Books_Delete.Enabled = false;

                    // Очищаем форму (значения по умолчанию)
                    this.ComboBox_Books_Author.SelectedIndex = -1;
                    this.TextBox_Books_Title.Clear();
                    this.ComboBox_Books_Group.SelectedIndex = -1;
                    this.ComboBox_Books_Bookmaker.SelectedIndex = -1;
                    this.NumericUpDown_Books_Year.Value = 2000;
                    this.DateTime_Books_CopyBooksDate.Value = DateTime.Now;
                    this.PictureBox_Books_Cover.Image = null;
                }
            });
        }

        /// <summary>Событие нажатия на кнопку "Загрузить изображение обложки"</summary>
        private void Button_Books_AddCover_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, false, () => {
                if (this.OpenFileDialog_Book.ShowDialog() == DialogResult.OK) {
                    this.PictureBox_Books_Cover.Load(this.OpenFileDialog_Book.FileName);
                }
            });
        }

        /// <summary>Событие нажатия на кнопку "Добавить книгу"</summary>
        private void Button_Books_Create_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                this.CreateOrEditBook(true);
                this.UnfocusAll();

                // Выбираем последнюю строчку в таблице
                this.Grid_Books.ClearSelection();
                this.Grid_Books.Rows[this.Grid_Books.Rows.Count - 1].Selected = true;

                FormHelper.SendSuccessMessage(this, "Книга успешно добавлена!");
            });
        }

        /// <summary>Событие нажатия на кнопку "Изменить информацию о книге"</summary>
        private void Button_Books_Edit_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                this.CreateOrEditBook(false);
                this.UnfocusAll();
                FormHelper.SendSuccessMessage(this, "Книга успешно отредактирована!");
            });
        }

        /// <summary>Создаёт новую или изменяет выбранную книгу (смотрит на поля ввода)</summary>
        /// <param name="is_new">Если true - из введённых данных будет создана новая книга. Если false - будет изменена выбранная книга в таблице</param>
        private void CreateOrEditBook(bool is_new)
        {
            // Автор книги
            Author selected_author = DatabaseHelper.SelectFirstOrFormException(
                DatabaseHelper.db.Authors,
                this.ComboBox_Books_Author.Text
            );
            // Название книги
            string title = this.TextBox_Books_Title.Text.Trim();
            if (title == "") {
                throw new FormException("Необходимо указать название книги!");
            }
            // Жанр книги
            Group selected_group = DatabaseHelper.SelectFirstOrFormException(
                DatabaseHelper.db.Groups,
                this.ComboBox_Books_Group.Text
            );
            // Издатель книги
            Bookmaker selected_bookmaker = DatabaseHelper.SelectFirstOrFormException(
                DatabaseHelper.db.Bookmakers,
                this.ComboBox_Books_Bookmaker.Text
            );

            // Создание новой книги
            if (is_new) {
                // Создаём и сохраняем новую книгу
                Book new_entity = new Book {
                    Author = selected_author,
                    Title = title,
                    Group = selected_group,
                    Bookmaker = selected_bookmaker,
                    PublicationYear = Convert.ToInt32(this.NumericUpDown_Books_Year.Value),
                    RegistrationDate = this.DateTime_Books_CopyBooksDate.Value,
                    Photo = ImageHelper.ImageToByteArray(this.PictureBox_Books_Cover.Image)
                };
                DatabaseHelper.db.Books.Add(new_entity);
            }
            // Изменение выбранной книги
            else {
                if (this.Grid_Books.SelectedRows.Count > 0) {
                    // Изменяем и сохраняем выбранного автора в таблице
                    int selected_id = Convert.ToInt32(this.Grid_Books.SelectedRows[0].Cells[0].Value);
                    Book found_entity = DatabaseHelper.SelectFirstOrFormException(
                        DatabaseHelper.db.Books,
                        selected_id
                    );

                    // Обновление полей
                    found_entity.Author = selected_author;
                    found_entity.Title = title;
                    found_entity.Group = selected_group;
                    found_entity.Bookmaker = selected_bookmaker;
                    found_entity.PublicationYear = Convert.ToInt32(this.NumericUpDown_Books_Year.Value);
                    found_entity.RegistrationDate = this.DateTime_Books_CopyBooksDate.Value;
                    found_entity.Photo = ImageHelper.ImageToByteArray(this.PictureBox_Books_Cover.Image);

                    DatabaseHelper.db.Books.Update(found_entity);
                } else {
                    throw new FormException("Книга для изменения не выбрана!");
                }
            }

            DatabaseHelper.db.SaveChanges();
            this.UpdateCurrentSelectedTab();
        }

        /// <summary>Событие нажатия на кнопку "Удалить книгу"</summary>
        private void Button_Books_Delete_Click(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, true, () => {
                if (this.Grid_Books.SelectedRows.Count > 0) {
                    // Удаляем все выбранные записи
                    foreach (DataGridViewRow row in this.Grid_Books.SelectedRows) {
                        // Находим выбранную книгу в БД
                        int selected_id = Convert.ToInt32(row.Cells[0].Value);
                        Book found_entity = DatabaseHelper.SelectFirstOrFormException(
                            DatabaseHelper.db.Books,
                            selected_id
                        );

                        DatabaseHelper.db.Books.Remove(found_entity);
                        DatabaseHelper.db.SaveChanges();
                    }

                    // Обновляем таблицу (также обновит все связанные комбобоксы)
                    this.UpdateData(new List<MetroGrid>() {
                        this.Grid_Books,
                    });

                    // Снимаем выделение в таблице
                    this.Grid_Books.ClearSelection();

                    FormHelper.SendSuccessMessage(this, "Книга успешно удалёна!");
                }
            });
        }

        /// <summary>Событие изменения параметров фильтрации на вкладке "Книги"</summary>
        private void Component_Books_Search_ConditionsChanged(object sender, EventArgs e)
        {
            // Обновляем данные только если установлена галочка "Поиск в реальном времени"
            if (this.CheckBox_IsSearchInRealTime.Checked) {
                this.UpdateData(this.Grid_Books);
            }
        }

        /// <summary>Событие нажатия на кнопку "Поиск" на вкладке "Книги"</summary>
        private void Button_Books_Search_Click(object sender, EventArgs e)
        {
            this.UpdateData(this.Grid_Books);
            this.UnfocusAll();
        }

        /// <summary>Событие нажатия на кнопку "Сбросить фильтр" на вкладке "Книги"</summary>
        private void Button_Books_Reset_Click(object sender, EventArgs e)
        {
            this.RadioButton_Books_Author.Select();
            this.TextBox_Books_Search.Text = "";
            this.UpdateData(this.Grid_Books);
            this.UnfocusAll();
        }

        /// <summary>Событие изменения галочки "Поиск в реальном времени"</summary>
        private void CheckBox_IsSearchInRealTime_CheckedChanged(object sender, EventArgs e)
        {
            // Блокируем кнопку поиска, если включён поиск в реальном времени, и наоборот
            this.Button_Books_Search.Enabled = !this.CheckBox_IsSearchInRealTime.Checked;

            this.UpdateData(this.Grid_Books);
            this.UnfocusAll();
        }
        // ======================================================================


        // ======================================================================
        // Вкладка "Экземпляры книг"
        // ======================================================================
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
        // ======================================================================
    }
}
