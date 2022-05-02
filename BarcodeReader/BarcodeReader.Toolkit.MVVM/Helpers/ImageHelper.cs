using System.Windows.Media.Imaging;

namespace BarcodeReader.Toolkit.MVVM.Helpers
{
    public static class ImageHelper
    {
        public static BitmapImage Convert(System.Drawing.Image image)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
            bitmap.StreamSource = memoryStream;
            bitmap.EndInit();
            return bitmap;
        }
    }
}