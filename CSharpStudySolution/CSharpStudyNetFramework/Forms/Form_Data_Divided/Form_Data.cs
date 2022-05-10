using MetroFramework.Controls;
using System;
using System.Collections.Generic;
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
                this.Grid_References_Group,
                this.Grid_Orders_Readers,
                this.Grid_Orders_Orders,
                this.Grid_Returns
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

        /// <summary>Убирает фокус со всех элементов</summary>
        private void UnfocusAll()
        {
            // Убираем фокус с любого элемента
            this.ActiveControl = null;
        }
    }
}
