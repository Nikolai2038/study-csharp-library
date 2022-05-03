using CSharpStudyNetFramework.Helpers;
using System;
using System.Linq;

namespace CSharpStudyNetFramework.Forms
{
    /// <summary>Форма с данными</summary>
    public partial class Form_Data : Form_Base
    {
        /// <summary>Конструктор формы</summary>
        public Form_Data() : base()
        {
            this.InitializeComponent();
            // Установка темы для формы
            this.SetStyleManager();
        }

        /// <summary>Событие загрузки формы</summary>
        private void Form_Data_Load(object sender, EventArgs e)
        {
            ExceptionHelper.CheckCode(this, () => {
                this.Grid_Data.DataSource = DatabaseHelper.db_context.authors.ToList();
            });
        }
    }
}
