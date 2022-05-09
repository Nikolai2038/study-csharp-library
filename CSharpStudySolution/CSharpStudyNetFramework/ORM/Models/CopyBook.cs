﻿namespace CSharpStudyNetFramework.ORM.Models
{
    /// <summary>Сущность "Экземпляр книги"</summary>
    internal class CopyBook
    {
        public int? Id { get; set; }
        public int Number { get; set; }
        public bool IsGiven { get; set; }
        public bool IsLost { get; set; }
        public Book Book { get; set; }

        public override string ToString()
        {
            return this.Number.ToString();
        }
    }
}