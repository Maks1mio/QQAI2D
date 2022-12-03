using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QQAI2D
{
    internal class Uploader
    {
        private readonly HttpClient _client;
        private readonly string _image;
        private readonly int _uploadsCount;

        public Uploader(string imageBase64, int uploadsCount)
        {
            _image = imageBase64;
            _uploadsCount = uploadsCount;
            _client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };
        }

        public async IAsyncEnumerable<string> GetConvertedImagesURL()
        {
            var requestData = new RequestData(_image);

            for (int i = 0; i < _uploadsCount; i++)
            {
                var responseMessage = await _client.PostAsJsonAsync("https://ai.tu.qq.com/trpc.shadow_cv.ai_processor_cgi.AIProcessorCgi/Process", requestData);
                var responseStream = await responseMessage.Content.ReadAsStreamAsync();
                var response = await JsonSerializer.DeserializeAsync<Response>(responseStream);
                yield return JsonSerializer.Deserialize<Extra>(response.extra).URL;
            }
        }

        private class RequestData
        {
            [JsonPropertyName("busiId")]
            public string BusiID => "ai_painting_anime_img_entry";
            [JsonPropertyName("extra")]
            public string Extra => """{"face_rects":[],"version":2,"platform":"web","data_report":{"parent_trace_id":"7dcf28ca-9286-16a6-235b-3c8cca67fe9d","root_channel":"qq_sousuo","level":12}}""";
            [JsonPropertyName("images")]
            public string[] Images { get; init; }

            public RequestData(string imageBase64)
            {
                Images = new string[1] { imageBase64 };
            }
        }

        private class Response
        {
            public int code { get; set; }
            public string msg { get; set; }
            public List<object> images { get; set; }
            public List<object> faces { get; set; }
            public string extra { get; set; }
        }

        private class Extra
        {
            public string URL => $"https://activity.tu.qq.com/mqq/ai_painting_anime/share/{uuid}.jpg";
            public string uuid { get; set; }
        }
    }
}
