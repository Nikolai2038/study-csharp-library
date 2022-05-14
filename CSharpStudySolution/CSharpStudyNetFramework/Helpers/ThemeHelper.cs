using MetroFramework.Components;
using MetroFramework.Forms;
using MetroFramework.Interfaces;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpStudyNetFramework.Helpers
{
    /// <summary>Вспомогательный класс для смены темы элементов формы</summary>
    internal abstract class ThemeHelper
    {
        /// <summary>Применяет указанную тему для элемента и всех дочерних для него</summary>
        /// <param name="element">Элемент</param>
        /// <param name="style_manager">Менеджер стилей</param>
        /// <param name="form">Форма</param>
        private static void SetTheme(Control element, MetroStyleManager style_manager, MetroForm form)
        {
            // Если элемент является компонентом MetroFramework - устанавливаем для него тему
            if (element is IMetroControl) {
                (element as IMetroControl).StyleManager = style_manager;
            }
            // Обработка стандартных компонентов
            else {
                // Если вкладка
                if (element is TabPage || element is ComboBox || element is NumericUpDown) {
                    if (style_manager.Theme == MetroFramework.MetroThemeStyle.Dark) {
                        element.BackColor = Color.FromArgb(16, 16, 16);
                        element.ForeColor = Color.White;
                        if (element is ComboBox) {
                            // Более тонкие рамки, но видны только в тёмной теме - в светлой выглядит не очень
                            (element as ComboBox).FlatStyle = FlatStyle.Flat;
                        }
                    } else if (style_manager.Theme == MetroFramework.MetroThemeStyle.Light) {
                        element.BackColor = Color.White;
                        element.ForeColor = Color.FromArgb(16, 16, 16);
                    }
                }
                // Если контейнер с разделителем
                else if (element is SplitContainer) {
                    Panel panel_1 = (element as SplitContainer).Panel1;
                    Panel panel_2 = (element as SplitContainer).Panel2;

                    // Если тема тёмная - панели тёмные, но сам контейнер (цвет разделителя) - светлый
                    if (style_manager.Theme == MetroFramework.MetroThemeStyle.Dark) {
                        element.BackColor = Color.Gray;
                        panel_1.BackColor = panel_2.BackColor = Color.FromArgb(16, 16, 16);
                        panel_1.ForeColor = panel_2.ForeColor = Color.White;
                    }
                    // Если тема светлая - панели светлые, но сам контейнер (цвет разделителя) - тёмный
                    else if (style_manager.Theme == MetroFramework.MetroThemeStyle.Light) {
                        element.BackColor = Color.LightGray;
                        panel_1.BackColor = panel_2.BackColor = Color.White;
                        panel_1.ForeColor = panel_2.ForeColor = Color.FromArgb(16, 16, 16);
                    }

                    // Отступы вокруг сплиттера
                    int splitter_margin = 4;
                    if ((element as SplitContainer).Orientation == Orientation.Horizontal) {
                        panel_1.Padding = new Padding(0, 0, 0, splitter_margin);
                        panel_2.Padding = new Padding(0, splitter_margin, 0, 0);
                    } else {
                        panel_1.Padding = new Padding(0, 0, splitter_margin, 0);
                        panel_2.Padding = new Padding(splitter_margin, 0, 0, 0);
                    }

                    // После завершения передвижения разделителя убираем с него фокус
                    (element as SplitContainer).SplitterMoved += (object sender, SplitterEventArgs e) => {
                        // Убираем фокус с любого элемента
                        form.ActiveControl = null;
                        form.Refresh();
                    };
                }
            }

            // Применяем тему для каждого из дочерних элементов
            foreach (Control child in element.Controls) {
                SetTheme(child, style_manager, form);
            }

            if (element is TabControl) {
                foreach (Control child in (element as TabControl).TabPages) {
                    SetTheme(child, style_manager, form);
                }
            }

            // Если элемент - таблица
            if (element is DataGridView) {
                (element as DataGridView).DefaultCellStyle.SelectionBackColor = (element as DataGridView).ColumnHeadersDefaultCellStyle.SelectionBackColor;
                // Убираю выделение заголовка столбца
                (element as DataGridView).ColumnHeadersDefaultCellStyle.SelectionBackColor = (element as DataGridView).ColumnHeadersDefaultCellStyle.BackColor;
                // Стиль ячеек
                (element as DataGridView).CellPainting += Grid_CellPainting;
                (element as DataGridView).DefaultCellStyle.Padding = new Padding(4, 2, 4, 2);
            }
        }

        /// <summary>Применяет указанную тему для формы и всех её дочерних элементов</summary>
        /// <param name="form">Форма</param>
        /// <param name="style_manager">Менеджер стилей</param>
        public static void SetStyleManager(MetroForm form, MetroStyleManager style_manager)
        {
            form.StyleManager = style_manager;
            // Применяем тему для каждого дочернего элемента формы
            foreach (Control child in form.Controls) {
                SetTheme(child, style_manager, form);
            }
        }


        /// <summary>Событие отрисовки ячейки</summary>
        private static void Grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int border_size = 1;

            DataGridView grid = sender as DataGridView;

            Color color_border_header = grid.ColumnHeadersDefaultCellStyle.ForeColor;
            Color color_border_cell = grid.DefaultCellStyle.ForeColor;

            // Стиль ячеек заголовков
            if (e.RowIndex == -1) {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);

                ControlPaint.DrawBorder(
                    e.Graphics,
                    e.CellBounds,
                    // Левая граница: в первом столбце как у обычных ячеек; в остальных - как у заголовков
                    e.ColumnIndex == 0 ? color_border_cell : color_border_header, border_size, ButtonBorderStyle.Solid,
                    // Верхняя граница: как у обычных ячеек
                    color_border_cell, border_size, ButtonBorderStyle.Solid,
                    // Правая граница: в последнем столбце как у обычных ячеек; в остальных - нет
                    color_border_cell, e.ColumnIndex == grid.ColumnCount - 1 ? border_size : 0, ButtonBorderStyle.Solid,
                    // Нижняя граница: нет
                    color_border_cell, 0, ButtonBorderStyle.Solid
                );
            }
            // Стиль обычных ячеек
            else if (e.RowIndex >= 0) {
                SolidBrush brush = new SolidBrush(grid.ColumnHeadersDefaultCellStyle.BackColor);
                e.Graphics.FillRectangle(brush, e.CellBounds);
                brush.Dispose();

                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentBackground);

                ControlPaint.DrawBorder(
                    e.Graphics,
                    e.CellBounds,
                    // Левая граница: есть
                    color_border_cell, border_size, ButtonBorderStyle.Solid,
                    // Верхняя граница: есть
                    color_border_cell, border_size, ButtonBorderStyle.Solid,
                    // Правая граница: есть только у последней ячейки
                    color_border_cell, e.ColumnIndex == grid.ColumnCount - 1 ? border_size : 0, ButtonBorderStyle.Solid,
                    // Нижняя граница: есть только у последней ячейки
                    color_border_cell, e.RowIndex == grid.RowCount - 1 ? border_size : 0, ButtonBorderStyle.Solid
                );
            } else {
                return;
            }

            // Передаём информацию о том, что отрисовку ячейки взяли на себя
            e.Handled = true;
        }
    }
}
