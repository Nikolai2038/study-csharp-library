using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Interfaces;
using System.Windows.Forms;

namespace CSharpStudyNetFramework.Helpers
{
    /// <summary>Вспомогательный класс для смены темы элементов формы</summary>
    internal abstract class ThemeHelper
    {
        /// <summary>Применяет указанную тему для элемента и всех дочерних для него</summary>
        /// <param name="element">Элемент</param>
        private static void SetTheme(Control element, MetroThemeStyle themeStyle)
        {
            // Если элемент является компонентом MetroFramework - устанавливаем для него тему
            if (element is IMetroControl) {
                (element as IMetroControl).Theme = themeStyle;
            } else {
                // Здесь по желанию можно сделать обработку стандартных элементов WindowsForms
                // ...
            }

            // Применяем тему для каждого из дочерних элементов
            foreach (Control child in element.Controls) {
                SetTheme(child, themeStyle);
            }
        }

        /// <summary>Применяет указанную тему для формы и всех дочерних элементов для неё</summary>
        /// <param name="form">Форма</param>
        private static void SetTheme(MetroForm form, MetroThemeStyle themeStyle)
        {
            form.Theme = themeStyle;
            // Применяем тему для каждого дочернего элемента формы
            foreach (Control child in form.Controls) {
                SetTheme(child, themeStyle);
            }
        }

        /// <summary>Применяет тёмную тему для формы и всех дочерних элементов для неё</summary>
        /// <param name="form">Форма</param>
        public static void SetThemeDark(MetroForm form)
        {
            SetTheme(form, MetroThemeStyle.Dark);
        }

        /// <summary>Применяет светлую тему для формы и всех дочерних элементов для неё</summary>
        /// <param name="form">Форма</param>
        public static void SetThemeLight(MetroForm form)
        {
            SetTheme(form, MetroThemeStyle.Light);
        }
    }
}
