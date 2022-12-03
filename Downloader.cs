namespace QQAI2D
{
    internal class Downloader
    {
        private readonly HttpClient _client;

        public Downloader()
        {
            _client = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };
        }

        public async Task<byte[]> Save(string url)
        {
            return await _client.GetByteArrayAsync(url);
        }
    }
}
