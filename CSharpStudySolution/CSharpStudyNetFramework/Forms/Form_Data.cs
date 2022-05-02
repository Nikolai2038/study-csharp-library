using CSharpStudyNetFramework.Helpers;
using CSharpStudyNetFramework.ORM;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Linq;
using System.Windows.Forms;

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
            // В случае возникновения ошибки, повторяем скрипт пока выбирается "Retry"
            do {
                try {
                    CustomDbContext db_context = new CustomDbContext();
                    this.Grid_Data.DataSource = db_context.authors.ToList();
                    break;
                } catch (Exception exception) {
                    DialogResult dialogResult = MetroMessageBox.Show(this, exception.Message, "Возникла ошибка!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    // Если была выбрана "Cancel"
                    if (dialogResult == DialogResult.Abort) {
                        // Выход из программы
                        Environment.Exit(1);
                    }
                    else if (dialogResult == DialogResult.Ignore) {
                        // Продолжение выполнения программы
                        break;
                    }
                }
            } while (true);
        }
    }
}
