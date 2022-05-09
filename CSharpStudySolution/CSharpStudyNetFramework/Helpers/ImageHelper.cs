using System.Drawing;
using System.IO;
using System.Text;

namespace CSharpStudyNetFramework.Helpers
{
    /// <summary>Вспомогательный класс для работы с изображениями</summary>
    internal abstract class ImageHelper
    {
        /// <summary>Преобразует изображение в строчку</summary>
        /// <param name="source">Изображение</param>
        /// <returns>Строчка</returns>
        public static string GetStringFromBitmap(Image source)
        {
            ImageConverter image_converter = new ImageConverter();
            return image_converter.ConvertToString(source);
        }

        /// <summary>Преобразует строчку в изображение</summary>
        /// <param name="source">Строчка</param>
        /// <returns>Изображение</returns>
        public static Bitmap GetBitmapFromString(string source)
        {
            // ImageConverter image_converter = new ImageConverter();
            // return image_converter.ConvertFromString(source) as Bitmap;

            byte[] image_bytes = Encoding.Unicode.GetBytes(source);
            using (MemoryStream stream = new MemoryStream(image_bytes)) {
                return new Bitmap(stream);
            }
        }
    }
}
