using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace CSharpStudyNetFramework.Forms
{
    /// <summary>Форма с сообщением об исключении и вариантами действий</summary>
    public partial class Form_Exception : MetroForm
    {
        /// <summary>Конструктор формы</summary>
        /// <param name="exception">Вызванное исключение</param>
        public Form_Exception(Exception exception)
        {
            this.InitializeComponent();
            this.TextBox_Exception.Text = exception.GetBaseException().Message;
            this.TextBox_Stack.Text = exception.GetBaseException().StackTrace;
            // Значение по умолчанию (случай закрытия формы)
            this.DialogResult = DialogResult.Abort;
        }

        /// <summary>Событие нажатия на кнопку повтора</summary>
        private void Button_Retry_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        /// <summary>Событие нажатия на кнопку остановки программы</summary>
        private void Button_Abort_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        /// <summary>Событие нажатия на кнопку игнорирования ошибки</summary>
        private void Button_Ignore_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Ignore;
            this.Close();
        }
    }
}
