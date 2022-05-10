using CSharpStudyNetFramework.Helpers;
using CSharpStudyNetFramework.ORM.Models;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

// ######################################################################
// Форма данных - Дополнительные методы
// ######################################################################

namespace CSharpStudyNetFramework.Forms.Form_Data_Divided
{
    /// <summary>Форма с данными</summary>
    public partial class Form_Data : Form_Base
    {
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
                case 3:
                    this.UpdateData(this.Grid_Orders_Readers);
                    this.UpdateData(this.Grid_Orders_Orders);
                    return;
                case 5:
                    grid_to_update = this.Grid_Returns;
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
                    if (this.RadioButton_Books_Search_Author.Checked) {
                        filter_function = book => {
                            if (book.Author == null) {
                                // true будет только в случае, если передана пустая строчка
                                return filter_string == "";
                            }
                            return book.Author.FullName.Contains(filter_string);
                        };
                    }
                    // Если выбрана фильтрация по полю "Название"
                    else if (this.RadioButton_Books_Search_Title.Checked) {
                        filter_function = book => {
                            return book.Title.Contains(filter_string);
                        };
                    }
                    // Если выбрана фильтрация по полю "Жанр"
                    else if (this.RadioButton_Books_Search_Group.Checked) {
                        filter_function = book => {
                            if (book.Group == null) {
                                // true будет только в случае, если передана пустая строчка
                                return filter_string == "";
                            }
                            return book.Group.Title.Contains(filter_string);
                        };
                    }
                    // Если выбрана фильтрация по полю "Издатель"
                    else if (this.RadioButton_Books_Search_Bookmaker.Checked) {
                        filter_function = book => {
                            if (book.Bookmaker == null) {
                                // true будет только в случае, если передана пустая строчка
                                return filter_string == "";
                            }
                            return book.Bookmaker.Title.Contains(filter_string);
                        };
                    }
                    // Если выбрана фильтрация по полю "Год издания"
                    else if (this.RadioButton_Books_Search_PublicationYear.Checked) {
                        filter_function = book => {
                            return book.PublicationYear.ToString().Contains(filter_string);
                        };
                    }
                    // Если выбрана фильтрация по полю "Дата регистрации"
                    else if (this.RadioButton_Books_Search_RegistrationDate.Checked) {
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
                // Если заполняется вкладка "Формуляры" - "Читатели"
                else if (grid.Equals(this.Grid_Orders_Readers)) {
                    List<Reader> data = DatabaseHelper.db.Readers.ToList();

                    data_for_comboboxes = DatabaseHelper.GetStringArrayForComboBoxes(data);
                    grid.DataSource = data;
                }
                // Если заполняется вкладка "Формуляры" - "Записи"
                else if (grid.Equals(this.Grid_Orders_Orders)) {
                    List<Order> data = DatabaseHelper.db.Orders.ToList();

                    grid.DataSource = data;
                }
                // Если заполняется вкладка "Возврат книг"
                else if (grid.Equals(this.Grid_Returns)) {
                    List<Order> data = DatabaseHelper.db.Orders.ToList();

                    grid.DataSource = data;
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
    }
}
