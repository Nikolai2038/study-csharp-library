using MetroFramework;
using System.Windows.Forms;

namespace CSharpStudyNetFramework.Helpers
{
    /// <summary>Вспомогательный класс для вывод</summary>
    internal abstract class FormHelper
    {
        /// <summary>Выводит окно ошибки с указанным сообщением</summary>
        /// <param name="owner">Вкладелец окна (форма, из которой вызывается окно)</param>
        /// <param name="message">Сообщение</param>
        public static void SendErrorMessage(IWin32Window owner, string message)
        {
            MetroMessageBox.Show(
                owner,
                message,
                "Ошибка заполнения формы!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        /// <summary>Выводит окно успешного выполнения с указанным сообщением</summary>
        /// <param name="owner">Вкладелец окна (форма, из которой вызывается окно)</param>
        /// <param name="message">Сообщение</param>
        public static void SendSuccessMessage(IWin32Window owner, string message)
        {
            MetroMessageBox.Show(
                owner,
                message,
                "Успешно!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
