using CSharpStudyNetFramework.Extra;
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
        /// <summary>Изолированно выполняет переданный код - в случае исключения выводит форму для его обработки</summary>
        /// <param name="owner">Форма, в которой выполняется код</param>
        /// <param name="function">Сам код, который необходимо выполнить</param>
        /// <param name="is_block_form">Блокировать ли форму на время выполнения кода</param>
        public static void CheckCode(Form owner, bool is_block_form, ExceptionHelperDelegate function)
        {
            // Блокируем форму от нажатий
            if (is_block_form) {
                owner.Enabled = false;
            }

            try {
                // Вызываем код
                function();
            }
            // Если возникло исключение заполнения формы
            catch (FormException exception) {
                // Выводим сообщение и игнорируем ошибку
                FormHelper.SendErrorMessage(owner, exception.GetBaseException().Message);
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
                    CheckCode(owner, is_block_form, function);
                }
                // Иначе выполнение программы будет продолжено
            }

            // Разблокируем форму
            if (is_block_form) {
                owner.Enabled = true;
            }
        }
    }
}
