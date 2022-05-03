using CSharpStudyNetFramework.Helpers;
using MetroFramework.Forms;
using System;
using System.Linq;

namespace CSharpStudyNetFramework.Forms
{
    /// <summary>Форма с данными</summary>
    public partial class Form_Data : MetroForm
    {
        /// <summary>Конструктор формы</summary>
        public Form_Data()
        {
            this.InitializeComponent();
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
