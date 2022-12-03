using System.Drawing.Imaging;

namespace QQAI2D
{
    internal class PhotosSaver
    {
        private readonly string _directory;
        private readonly bool _crop;
        private readonly string _photoName;

        private int _photoID;

        public PhotosSaver(string directory, string photoName, bool crop)
        {
            _directory = directory;
            _photoName = photoName;
            _crop = crop;
            _photoID = 1;
        }

        public void Save(byte[] bytes)
        {
            if (!Directory.Exists(_directory))
                Directory.CreateDirectory(_directory);

            using var ms = new MemoryStream(bytes);
            using var bitmap = Image.FromStream(ms);
            using var fileStream = File.Create($@"{_directory}\{_photoName}_{_photoID++}.jpg");

            if (_crop)
            {
                using var cropped = Crop(bitmap);
                cropped.Save(fileStream, ImageFormat.Jpeg);
            }
            else
            {
                bitmap.Save(fileStream, ImageFormat.Jpeg);
            }
        }

        private Bitmap Crop(Image image)
        {
            Rectangle cropRect = image switch
            {
                { Width: 1000, Height: 930 } => new Rectangle(new Point(508, 24), new Size(471, 705)),
                { Width: 800, Height: 1257 } => new Rectangle(new Point(20, 543), new Size(758, 504)),
                _ => throw new ArgumentException("invalid image")
            };

            Bitmap cropped = new Bitmap(cropRect.Width, cropRect.Height);
            using Graphics g = Graphics.FromImage(cropped);
            g.DrawImage(image, new Rectangle(0, 0, cropped.Width, cropped.Height), cropRect, GraphicsUnit.Pixel);
            return cropped;
        }
    }
}
