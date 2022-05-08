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
                if (element is TabPage) {
                    if (style_manager.Theme == MetroFramework.MetroThemeStyle.Dark) {
                        element.BackColor = Color.FromArgb(16, 16, 16);
                        element.ForeColor = Color.White;
                    } else if (style_manager.Theme == MetroFramework.MetroThemeStyle.Light) {
                        element.BackColor = Color.White;
                        element.ForeColor = Color.FromArgb(16, 16, 16);
                    }
                }
                // Если контейнер с разделителем
                else if (element is SplitContainer) {
                    // Если тема тёмная - панели тёмные, но сам контейнер (цвет разделителя) - светлый
                    if (style_manager.Theme == MetroFramework.MetroThemeStyle.Dark) {
                        element.BackColor = Color.White;
                        (element as SplitContainer).Panel1.BackColor = (element as SplitContainer).Panel2.BackColor = Color.FromArgb(16, 16, 16);
                        (element as SplitContainer).Panel1.ForeColor = (element as SplitContainer).Panel2.ForeColor = Color.White;
                    }
                    // Если тема светлая - панели светлые, но сам контейнер (цвет разделителя) - тёмный
                    else if (style_manager.Theme == MetroFramework.MetroThemeStyle.Light) {
                        element.BackColor = Color.LightGray;
                        (element as SplitContainer).Panel1.BackColor = (element as SplitContainer).Panel2.BackColor = Color.White;
                        (element as SplitContainer).Panel1.ForeColor = (element as SplitContainer).Panel2.ForeColor = Color.FromArgb(16, 16, 16);
                    }
                    // После завершения передвижения разделителя убираем с него фокус
                    (element as SplitContainer).SplitterMoved += (object sender, SplitterEventArgs e) => {
                        // Убираем фокус с любого элемента
                        form.ActiveControl = null;
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
    }
}
