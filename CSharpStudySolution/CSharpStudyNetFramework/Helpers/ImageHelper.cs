using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace CSharpStudyNetFramework.Helpers
{
    /// <summary>Вспомогательный класс для работы с изображениями</summary>
    internal abstract class ImageHelper
    {
        /// <summary>Преобразовывает содержимое изображения в массив байт</summary>
        /// <param name="image">Изображение</param>
        /// <returns>Массив байт</returns>
        public static byte[] ImageToByteArray(Image image)
        {
            if (image == null) {
                return null;
            }
            using (MemoryStream stream = new MemoryStream()) {
                image.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }

        /// <summary>Преобразовывает массив байт в изображение</summary>
        /// <param name="bytes">Массив байт</param>
        /// <returns>Изображение</returns>
        public static Image ByteArrayToImage(byte[] bytes)
        {
            if (bytes == null) {
                return null;
            }
            using (MemoryStream stream = new MemoryStream(bytes)) {
                Image returnImage = Image.FromStream(stream, true, true);
                return returnImage;
            }
        }
    }
}
