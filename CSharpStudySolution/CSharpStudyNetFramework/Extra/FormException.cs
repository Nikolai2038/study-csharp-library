using System;

namespace CSharpStudyNetFramework.Extra
{
    /// <summary>Исключение, вызываемое при неправильном заполнении формы</summary>
    internal class FormException : Exception
    {
        /// <summary>Создаёт исключение</summary>
        /// <param name="message">Сообщение исключения</param>
        public FormException(string message) : base(message) { }
    }
}
