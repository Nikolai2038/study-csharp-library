using CSharpStudyNetFramework.Forms.Form_Data_Divided;
using System;
using System.Windows.Forms;

namespace CSharpStudyNetFramework
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Data());
        }
    }
}
