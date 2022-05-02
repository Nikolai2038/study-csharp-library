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
            try {
                this.Grid_Data.DataSource = DatabaseHelper.db_context.authors.ToList();
            } catch (Exception exception) {
                DialogResult dialogResult = MetroMessageBox.Show(this,
                    "\nИсключение:\n" + exception.GetBaseException().Message + "\n\n" +
                    "Метод:\n" + exception.TargetSite,
                    "Возникла ошибка!",
                    MessageBoxButtons.AbortRetryIgnore,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button2,
                    300
                );
                // Если была выбрана "Cancel"
                if (dialogResult == DialogResult.Abort) {
                    // Выход из программы
                    Environment.Exit(1);
                } else if (dialogResult == DialogResult.Retry) {
                    // Вызываем метод заново
                    this.Form_Data_Load(sender, e);
                }
            }
        }
    }
}
