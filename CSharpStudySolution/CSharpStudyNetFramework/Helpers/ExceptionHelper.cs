using CSharpStudyNetFramework.Forms;
using System;
using System.Windows.Forms;

namespace CSharpStudyNetFramework.Helpers
{
    /// <summary>Делегат для кода, обрабатываемого хелпером исключений</summary>
    internal delegate void ExceptionHelperDelegate();

    /// <summary>Вспомогательный класс для обработки исключений</summary>
    internal abstract class ExceptionHelper
    {
        public static void CheckCode(IWin32Window owner, ExceptionHelperDelegate function)
        {
            try {
                // Вызываем код
                function();
            }
            // Если возникло исключение
            catch (Exception exception) {
                // Создаём и показываем форму выбора действия в режиме диалога
                Form_Exception form = new Form_Exception(exception);
                DialogResult dialogResult = form.ShowDialog();

                // ------------------------
                // Пример с MetroFramework
                // ------------------------
                // DialogResult dialogResult = MetroMessageBox.Show(
                //     owner,
                //     "\nИсключение:\n" + exception.GetBaseException().Message + "\n\n" +
                //     "Метод:\n" + exception.StackTrace,
                //     "Возникла ошибка!",
                //     MessageBoxButtons.AbortRetryIgnore,
                //     MessageBoxIcon.Error,
                //     MessageBoxDefaultButton.Button2,
                //     300
                // );
                // ------------------------

                // Если была выбрана остановка программы
                if (dialogResult == DialogResult.Abort) {
                    // Выход из программы с кодом 1
                    Environment.Exit(1);
                }
                // Если была выбрана попытка повторить
                else if (dialogResult == DialogResult.Retry) {
                    // Вызываем весь метод заново
                    CheckCode(owner, function);
                }
                // Иначе выполнение программы будет продолжено
            }
        }
    }
}
