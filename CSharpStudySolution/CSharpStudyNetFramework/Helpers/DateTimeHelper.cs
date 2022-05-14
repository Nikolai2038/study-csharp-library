namespace CSharpStudyNetFramework.Helpers
{
    /// <summary>Вспомогательный класс для работы с датой и временем</summary>
    internal abstract class DateTimeHelper
    {
        /// <summary>Формат даты и времени, используемый в проекте (передаётся в методы .ToString())</summary>
        public static readonly string DateTimeFormat = "dd.MM.yyyy"; // Вместе со временем будет: "dd.MM.yyyy HH:mm:ss"
    }
}
