namespace QQAI2D
{
    internal static class ImageConverter
    {
        public static async Task<string> ToBase64(string imagePath)
        {
            var bytes = await File.ReadAllBytesAsync(imagePath);
            return Convert.ToBase64String(bytes);
        }
    }
}
