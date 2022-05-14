
using CSharpStudyNetFramework.Helpers;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace CSharpStudyNetFramework.Forms
{
    /// <summary>Класс базовой формы</summary>
    public partial class Form_Base : MetroForm
    {
        /// <summary>Менеджер стилей для обычных форм</summary>
        protected static readonly MetroStyleManager MetroStyleManager_FormsAll;

        /// <summary>Менеджер стилей для форм с ошибками</summary>
        protected static readonly MetroStyleManager MetroStyleManager_FormsErrors;

        /// <summary>Конструктор формы</summary>
        static Form_Base()
        {
            // TODO: Загрузка информации о темах
            // ...
            MetroThemeStyle theme_forms_all = MetroThemeStyle.Light;
            MetroColorStyle style_forms_all = MetroColorStyle.Teal;
            MetroThemeStyle theme_forms_errors = theme_forms_all;
            MetroColorStyle style_forms_errors = MetroColorStyle.Red;
            // ...

            // Настройка менеджера стилей для обычных форм
            MetroStyleManager_FormsAll = new MetroStyleManager {
                Theme = theme_forms_all,
                Style = style_forms_all
            };

            // Настройка менеджера стилей для форм с ошибками
            MetroStyleManager_FormsErrors = new MetroStyleManager {
                Theme = theme_forms_errors,
                Style = style_forms_errors
            };
        }

        /// <summary>Конструктор формы</summary>
        public Form_Base()
        {
            this.InitializeComponent();
        }

        /// <summary>Устанавливает настраиваемую тему для форм</summary>
        protected void SetStyleManager(MetroStyleManager style_manager = null)
        {
            if (style_manager == null) {
                style_manager = MetroStyleManager_FormsAll;
            }
            // Установка темы для всех форм
            ThemeHelper.SetStyleManager(this, style_manager);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form_Base
            // 
            this.ClientSize = new System.Drawing.Size(545, 364);
            this.Name = "Form_Base";
            this.ResumeLayout(false);

        }
    }
}
