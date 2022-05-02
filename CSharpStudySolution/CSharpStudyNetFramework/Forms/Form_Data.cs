using CSharpStudyNetFramework.Helpers;
using MetroFramework;
using MetroFramework.Forms;
using System;
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
                    this.Grid_Data.DataSource = DatabaseHelper.db_context.authors;
                } catch (Exception exception) {
                    DialogResult dialogResult = MetroMessageBox.Show(this, exception.Message, "Возникла ошибка!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    // Если была выбрана "Cancel"
                    if (dialogResult == DialogResult.Cancel) {
                        // Выход из программы
                        Environment.Exit(1);
                    }
                }
            } while (true);
        }
    }
}
