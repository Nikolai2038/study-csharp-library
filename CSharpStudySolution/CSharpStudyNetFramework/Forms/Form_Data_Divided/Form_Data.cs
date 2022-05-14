using CSharpStudyNetFramework.Helpers;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

// ######################################################################
// Форма данных - Основные методы и свойства
// ######################################################################

namespace CSharpStudyNetFramework.Forms.Form_Data_Divided
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

        /// <summary>Ассоциативный массив привязок комбобоксов к таблицам (при обновлении таблицы будут обновлены и связанные комбобоксы)</summary>
        private readonly Dictionary<MetroGrid, List<ComboBox>> LinkedComboboxes;

        /// <summary>ID предыдущей выбранной вкладки</summary>
        private int LastSelectedTabIndex = 0;

        /// <summary>Загрузилась ли форма</summary>
        private bool IsShown = false;

        /// <summary>Надписи "Нет данных" для каждой таблицы</summary>
        private readonly Dictionary<DataGridView, Label> GridWhenEmptyLabels;

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
                this.Grid_References_Authors,
                this.Grid_References_Bookmakers,
                this.Grid_References_Groups,
                this.Grid_Orders_Readers,
                this.Grid_Orders_Orders,
                this.Grid_Returns,
                this.Grid_Reports
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
                    this.Grid_References_Authors,
                    new List<ComboBox>() {
                        this.ComboBox_Books_Author
                    }
                },
                {
                    this.Grid_References_Groups,
                    new List<ComboBox>() {
                        this.ComboBox_Books_Group
                    }
                },
                {
                    this.Grid_References_Bookmakers,
                    new List<ComboBox>() {
                        this.ComboBox_Books_Bookmaker
                    }
                },
                {
                    this.Grid_Books,
                    new List<ComboBox>() {
                        this.ComboBox_CopyBooks_Book,
                        this.ComboBox_Issuance_Book
                    }
                },
                {
                    this.Grid_CopyBooks,
                    new List<ComboBox>() {
                        this.ComboBox_Issuance_CopyBook
                    }
                },
                {
                    this.Grid_Orders_Readers,
                    new List<ComboBox>() {
                        this.ComboBox_Issuance_Reader,
                        this.ComboBox_Returns_Reader,
                        this.ComboBox_Reports_Reader
                    }
                }
            };

            // --------------------------------------------
            // Задание ширины столбцов каждой таблицы
            // (Ширина указывается в относительных единицах друг относительно друга)
            // --------------------------------------------
            GridHelper.GridColumnsWidthUnits = new Dictionary<DataGridView, List<int>> {
                [this.Grid_Books] = new List<int>() {
                    1, 4, 4, 3, 2, 2, 4
                },
                [this.Grid_CopyBooks] = new List<int>() {
                    1, 10, 2, 2, 2
                },
                [this.Grid_References_Authors] = new List<int>() {
                    1, 4, 4, 4
                },
                [this.Grid_References_Groups] = new List<int>() {
                    1, 12
                },
                [this.Grid_References_Bookmakers] = new List<int>() {
                    1, 6, 6
                },
                [this.Grid_Orders_Readers] = new List<int>() {
                    1, 4, 4, 4, 8
                },
                [this.Grid_Orders_Orders] = new List<int>() {
                    1, 6, 6, 2, 3, 3, 3, 2, 2
                },
                [this.Grid_Returns] = new List<int>() {
                    1, 6, 6, 2, 3, 3, 3, 2, 2
                }
                // Для последней таблицы так пока что не получится сделать, так как количество её колонок непостоянно
            };
            // --------------------------------------------

            // --------------------------------------------
            // Надписи "Нет данных для отображения" для таблиц
            // --------------------------------------------
            // Каждой таблице соответствует свой Label
            this.GridWhenEmptyLabels = new Dictionary<DataGridView, Label> {
                { this.Grid_Books,                  this.Label_Books_WhenEmpty },
                { this.Grid_CopyBooks,              this.Label_CopyBooks_WhenEmpty },
                { this.Grid_References_Authors,     this.Label_References_Authors_WhenEmpty },
                { this.Grid_References_Bookmakers,  this.Label_References_Bookmakers_WhenEmpty },
                { this.Grid_References_Groups,      this.Label_References_Groups_WhenEmpty },
                { this.Grid_Orders_Readers,         this.Label_Orders_Readers_WhenEmpty },
                { this.Grid_Orders_Orders,          this.Label_Orders_Orders_WhenEmpty },
                { this.Grid_Returns,                this.Label_Returns_WhenEmpty },
                { this.Grid_Reports,                this.Label_Reports_WhenEmpty }
            };
            // --------------------------------------------
        }

        /// <summary>Событие загрузки формы</summary>
        private void Form_Data_Load(object sender, EventArgs e)
        {
            // Переход на эту вкладку необходим, чтобы её прогрузить
            // Иначе, если стартовать с любой другой вкладки, то потом, при переходе на вкладку 3 ("Формуляры")
            // вылетит исключение System.NullReferenceException (пока что без понятия, откуда оно берётся - ничего не понимаю)
            this.TabControl_Data.SelectedIndex = 3;
            // Переходим на первую вкладку, так как по умолчанию откроется вкладка, оставленная в дизайнере выбранной
            this.TabControl_Data.SelectedIndex = 0;

            // Добавление всплывающей подсказки для чекбокса "Поиск в реальном времени"
            ToolTip tool_tip = new ToolTip {
                ToolTipIcon = ToolTipIcon.Info,
                IsBalloon = true,
                ShowAlways = true,
                UseAnimation = true
            };
            tool_tip.SetToolTip(this.CheckBox_Books_Search_IsInRealTime, "Если включен поиск в реальном времени, то данные в таблице будут обновляться сразу же после любого изменения параметров фильтрации.");

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

        /// <summary>Событие показа формы</summary>
        private void Form_Data_Shown(object sender, EventArgs e)
        {
            this.IsShown = true;
            // Вызываем событие смены вкладки для изменения ширины столбцов таблиц
            this.TabControl_Data_SelectedIndexChanged(null, null);
        }

        /// <summary>Убирает фокус со всех элементов</summary>
        private void UnfocusAll()
        {
            // Убираем фокус с любого элемента
            this.ActiveControl = null;
        }

        /// <summary>Событие переключения вкладки</summary>
        private void TabControl_Data_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Только если форма уже загрузилась
            if (this.IsShown) {
                // Обновляем ширину столбцов в таблицах на вкладке
                // (потому что изменять их ширину получается только на активной вкладке)
                List<MetroGrid> grids_to_update = this.GetTabGridsOnTab();
                foreach (MetroGrid grid in grids_to_update) {
                    GridHelper.AutoResizeGrid(grid);
                }

                // Для старой вкладки сохраняем ширину столбцов
                List<MetroGrid> grids_to_save_columns_width = this.GetTabGridsOnTab(this.LastSelectedTabIndex);
                foreach (MetroGrid grid in grids_to_save_columns_width) {
                    GridHelper.SaveGridColumnsWidth(grid);
                }
            }

            // Сохраняем ID новой вкладки
            this.LastSelectedTabIndex = this.TabControl_Data.SelectedIndex;
        }

        /// <summary>Событие изменения размеров DataGridView</summary>
        private void Grid_SizeChanged(object sender, EventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            // Если для таблицы есть соответствующая надпись при отсутствии данных
            if (this.GridWhenEmptyLabels.ContainsKey(grid)) {
                // Центрируем Label по центру соответствующего ей DataGridView
                Label label = this.GridWhenEmptyLabels[grid];
                label.Location = new Point(
                    grid.Location.X + (grid.Width - label.Width) / 2,
                    grid.Location.Y + (grid.Height - label.Height) / 2
                );
            }
        }
    }
}
