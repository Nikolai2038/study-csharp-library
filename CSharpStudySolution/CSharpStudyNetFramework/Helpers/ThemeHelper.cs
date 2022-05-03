using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;
using MetroFramework.Interfaces;
using System.Windows.Forms;

namespace CSharpStudyNetFramework.Helpers
{
    /// <summary>Вспомогательный класс для смены темы элементов формы</summary>
    internal abstract class ThemeHelper
    {
        private static readonly MetroStyleManager StyleManager_Dark_Default;
        private static readonly MetroStyleManager StyleManager_Light_Default;
        private static readonly MetroStyleManager StyleManager_Dark_Red;

        static ThemeHelper()
        {
            // Настройки тёмной темы
            StyleManager_Dark_Default = new MetroStyleManager {
                Theme = MetroThemeStyle.Dark
            };
            // Настройки светлой темы
            StyleManager_Light_Default = new MetroStyleManager {
                Theme = MetroThemeStyle.Light
            };
            // Настройки тёмной темы с красным оттенком
            StyleManager_Dark_Red = new MetroStyleManager {
                Theme = MetroThemeStyle.Dark,
                Style = MetroColorStyle.Red
            };
        }

        /// <summary>Применяет указанную тему для элемента и всех дочерних для него</summary>
        /// <param name="element">Элемент</param>
        /// <param name="style_manager">Менеджер стилей</param>
        private static void SetTheme(Control element, MetroStyleManager style_manager)
        {
            // Если элемент является компонентом MetroFramework - устанавливаем для него тему
            if (element is IMetroControl) {
                (element as IMetroControl).StyleManager = style_manager;
            } else {
                // Здесь по желанию можно сделать обработку стандартных элементов WindowsForms
                // ...
            }

            // Применяем тему для каждого из дочерних элементов
            foreach (Control child in element.Controls) {
                SetTheme(child, style_manager);
            }
        }

        /// <summary>Применяет указанную тему для формы и всех её дочерних элементов</summary>
        /// <param name="form">Форма</param>
        /// <param name="style_manager">Менеджер стилей</param>
        public static void SetTheme(
            MetroForm form,
            MetroThemeStyle theme = MetroThemeStyle.Default,
            MetroColorStyle style = MetroColorStyle.Default
        )
        {
            // Создаём менеджер стилей
            MetroStyleManager style_manager = new MetroStyleManager {
                Theme = theme,
                Style = style
            };

            // Применяем стили для формы
            form.StyleManager = style_manager;

            // Применяем стили для каждого дочернего элемента формы
            foreach (Control child in form.Controls) {
                SetTheme(child, style_manager);
            }
        }

        /// <summary>Применяет указанную тему для формы и всех её дочерних элементов</summary>
        /// <param name="form">Форма</param>
        /// <param name="style_manager">Менеджер стилей</param>
        private static void SetTheme(MetroForm form, MetroStyleManager style_manager)
        {
            form.StyleManager = style_manager;
            // Применяем тему для каждого дочернего элемента формы
            foreach (Control child in form.Controls) {
                SetTheme(child, style_manager);
            }
        }

        /// <summary>Применяет тёмную тему для формы и всех её дочерних элементов</summary>
        /// <param name="form">Форма</param>
        public static void SetThemeDark(MetroForm form)
        {
            SetTheme(form, StyleManager_Dark_Default);
        }

        /// <summary>Применяет светлую тему для формы и всех её дочерних элементов</summary>
        /// <param name="form">Форма</param>
        public static void SetThemeLight(MetroForm form)
        {
            SetTheme(form, StyleManager_Light_Default);
        }

        /// <summary>Применяет тёмную тему с красным оттенком для формы и всех её дочерних элементов</summary>
        /// <param name="form">Форма</param>
        public static void SetThemeDarkRed(MetroForm form)
        {
            SetTheme(form, StyleManager_Dark_Red);
        }
    }
}
