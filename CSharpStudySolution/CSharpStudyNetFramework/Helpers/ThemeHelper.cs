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
        private static void SetTheme(Control element, MetroStyleManager style_manager)
        {
            // Если элемент является компонентом MetroFramework - устанавливаем для него тему
            if (element is IMetroControl) {
                (element as IMetroControl).StyleManager = style_manager;
            }
            // Обработка стандартных компонентов
            else {
                if (element is TabPage) {
                    if (style_manager.Theme == MetroFramework.MetroThemeStyle.Dark) {
                        (element as TabPage).BackColor = Color.FromArgb(16, 16, 16);
                        (element as TabPage).ForeColor = Color.White;
                    } else if (style_manager.Theme == MetroFramework.MetroThemeStyle.Light) {
                        (element as TabPage).BackColor = Color.White;
                        (element as TabPage).ForeColor = Color.FromArgb(16, 16, 16);
                    }
                }
            }

            // Применяем тему для каждого из дочерних элементов
            foreach (Control child in element.Controls) {
                SetTheme(child, style_manager);
            }

            if (element is TabControl) {
                foreach (Control child in (element as TabControl).TabPages) {
                    SetTheme(child, style_manager);
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
                SetTheme(child, style_manager);
            }
        }
    }
}
